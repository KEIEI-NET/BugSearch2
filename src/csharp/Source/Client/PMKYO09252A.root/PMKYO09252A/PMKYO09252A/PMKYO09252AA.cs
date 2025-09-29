//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ڑ���ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ڑ���ݒ�}�X�^�̓o�^�E�ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Microsoft.Win32;
using Broadleaf.Library.Resources;
using System.Security;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����_�ݒ�}�X�^�����e�i���X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�Ǘ��ڑ���ݒ�}�X�^�����e�i���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.04.23</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class SecMngConnectStAcs
    {
        # region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        private ISecMngConnectStDB _iSecMngConnectStDB = null;
        # endregion

        # region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public SecMngConnectStAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iSecMngConnectStDB = (ISecMngConnectStDB)MediationSecMngConnectStDB.GetSecMngConnectStDB();
        }
        # endregion

        # region -- �������� --
        /// <summary>���_�Ǘ��ڑ���ݒ�}�X�^�ǂݏ���</summary>
        /// <param name="secMngConnectSt">���_�Ǘ��ڑ���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ڑ���ݒ�}�X�^��ǂݍ��݂܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Search(out SecMngConnectSt secMngConnectSt, string enterpriseCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            secMngConnectSt = null;

            SecMngConnectStWork secMngConnectStWork = new SecMngConnectStWork();
            ArrayList resList = new ArrayList();
            try
            {
                secMngConnectStWork.EnterpriseCode = enterpriseCode;
                secMngConnectStWork.SectionCode = "0";

                object objResList = new object();

                //�ǂ�DB�̃f�[�^
                status = this._iSecMngConnectStDB.Search(out objResList, secMngConnectStWork, 0, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    resList = objResList as ArrayList;

                    SecMngConnectStWork resWork = (SecMngConnectStWork)resList[0];
                    // �N���X�������o�R�s�[
                    secMngConnectSt = CopyToSecMngConnectStFromSecMngConnectStWork(resWork);
                }
            }
            catch (Exception)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>���W�X�g���ǂݏ���</summary>
        /// <param name="secMngConnectSt">���_�Ǘ��ڑ���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���W�X�g����ǂݍ��݂܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int GetRegistryKey(out SecMngConnectSt secMngConnectSt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            secMngConnectSt = new SecMngConnectSt();

            try
            {
                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 == null)
                {
                    rKey1 = Registry.LocalMachine.CreateSubKey(rKeyName1);
                }

                if (rKey2 == null)
                {
                    rKey2 = Registry.LocalMachine.CreateSubKey(rKeyName2);
                }

                if (rKey1 != null && rKey2 != null)
                {
                    // ���W�X�g���捞
                    string apServerIpAddress = rKey1.GetValue("%Domain%").ToString();
                    string sbServerIpAddress = rKey2.GetValue("%DataSource%").ToString();
                    secMngConnectSt.ApServerIpAddress = apServerIpAddress;
                    secMngConnectSt.DbServerIpAddress = sbServerIpAddress;
                }
            }
            catch (IOException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (SecurityException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (Exception)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        # endregion

        # region -- �o�^��X�V���� --
        /// <summary>�ڑ���ݒ�}�X�^�o�^�E�X�V����</summary>
        /// <param name="secMngConnectSt">�ڑ���ݒ�}�X�^�N���X</param>
        /// <returns>�X�V���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ڑ���ݒ�}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Write(ref SecMngConnectSt secMngConnectSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SecMngConnectStWork secMngConnectStWork = CopyToSecMngConnectStWorkFromSecMngConnectSt(secMngConnectSt);

            try
            {
                object objSecMngConnectStWork = secMngConnectStWork;

                // �T�[�o�[�p�ڑ���X�V����
                status = this._iSecMngConnectStDB.UpdateRegistryKeyValue(ref objSecMngConnectStWork);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ���s�[���i���[���j�̃��W�X�g�����X�V����B
                    status = this.UpdateRegistryKeyValue(ref secMngConnectStWork);
                }

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ���_�Ǘ��ڑ���}�X�^�X�V����
                    status = this._iSecMngConnectStDB.Write(ref objSecMngConnectStWork);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    secMngConnectStWork = objSecMngConnectStWork as SecMngConnectStWork;
                    secMngConnectSt = CopyToSecMngConnectStFromSecMngConnectStWork(secMngConnectStWork);
                }
            }
            catch (Exception)
            {
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���W�X�g���̃L�[���ڂ��X�V����(���s�[���i���[���j)
        /// </summary>
        /// <remarks>
        /// <param name="secMngConnectStWork">�ڑ���ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���W�X�g���̃L�[���ڂ��X�V���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        private int UpdateRegistryKeyValue(ref SecMngConnectStWork secMngConnectStWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 == null)
                {
                    rKey1 = Registry.LocalMachine.CreateSubKey(rKeyName1);
                }

                if (rKey2 == null)
                {
                    rKey2 = Registry.LocalMachine.CreateSubKey(rKeyName2);
                }

                if (rKey1 != null && rKey2 != null)
                {
                    rKey1.SetValue("%Domain%", secMngConnectStWork.ApServerIpAddress, RegistryValueKind.String);
                    rKey2.SetValue("%DataSource%", secMngConnectStWork.DbServerIpAddress, RegistryValueKind.String);

                    // ����%RequiredServerVersion%�����ݎ��ɂ͍X�V�ΏۊO
                    if (rKey1.GetValue("RequiredServerVersion") == null)
                    {
                        rKey1.SetValue("RequiredServerVersion", "0", RegistryValueKind.DWord);
                    }
                }
            }
            catch (IOException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (SecurityException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (Exception)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        # endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�ڑ���ݒ�}�X�^���[�N�N���X�ːڑ���ݒ�}�X�^�N���X�j
        /// </summary>
        /// <param name="secMngConnectStWork">�����_�ݒ�}�X�^���[�N�N���X</param>
        /// <returns>�ڑ���ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �ڑ���ݒ�}�X�^���[�N�N���X����ڑ���ݒ�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private SecMngConnectSt CopyToSecMngConnectStFromSecMngConnectStWork(SecMngConnectStWork secMngConnectStWork)
        {
            SecMngConnectSt secMngConnectSt = new SecMngConnectSt();

            secMngConnectSt.CreateDateTime = secMngConnectStWork.CreateDateTime;
            secMngConnectSt.UpdateDateTime = secMngConnectStWork.UpdateDateTime;
            secMngConnectSt.EnterpriseCode = secMngConnectStWork.EnterpriseCode;
            secMngConnectSt.FileHeaderGuid = secMngConnectStWork.FileHeaderGuid;
            secMngConnectSt.UpdEmployeeCode = secMngConnectStWork.UpdEmployeeCode;
            secMngConnectSt.UpdAssemblyId1 = secMngConnectStWork.UpdAssemblyId1;
            secMngConnectSt.UpdAssemblyId2 = secMngConnectStWork.UpdAssemblyId2;
            secMngConnectSt.LogicalDeleteCode = secMngConnectStWork.LogicalDeleteCode;
            secMngConnectSt.SectionCode = secMngConnectStWork.SectionCode;
            secMngConnectSt.ConnectPointDiv = secMngConnectStWork.ConnectPointDiv;
            secMngConnectSt.ApServerIpAddress = secMngConnectStWork.ApServerIpAddress;
            secMngConnectSt.DbServerIpAddress = secMngConnectStWork.DbServerIpAddress;

            return secMngConnectSt;
        }

        /// <summary>�N���X�����o�[�R�s�[�����i�ڑ���ݒ�}�X�^�N���X�ːڑ���ݒ�}�X�^���[�N�N���X�j</summary>
        /// <param name="secMngConnectSt">�ڑ���ݒ�}�X�^���[�N�N���X</param>
        /// <returns>�ڑ���ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �ڑ���ݒ�}�X�^�N���X����ڑ���ݒ�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private SecMngConnectStWork CopyToSecMngConnectStWorkFromSecMngConnectSt(SecMngConnectSt secMngConnectSt)
        {
            SecMngConnectStWork secMngConnectStWork = new SecMngConnectStWork();

            secMngConnectStWork.CreateDateTime = secMngConnectSt.CreateDateTime;
            secMngConnectStWork.UpdateDateTime = secMngConnectSt.UpdateDateTime;
            secMngConnectStWork.EnterpriseCode = secMngConnectSt.EnterpriseCode;
            secMngConnectStWork.FileHeaderGuid = secMngConnectSt.FileHeaderGuid;
            secMngConnectStWork.UpdEmployeeCode = secMngConnectSt.UpdEmployeeCode;
            secMngConnectStWork.UpdAssemblyId1 = secMngConnectSt.UpdAssemblyId1;
            secMngConnectStWork.UpdAssemblyId2 = secMngConnectSt.UpdAssemblyId2;
            secMngConnectStWork.LogicalDeleteCode = secMngConnectSt.LogicalDeleteCode;
            secMngConnectStWork.SectionCode = secMngConnectSt.SectionCode;
            secMngConnectStWork.ConnectPointDiv = secMngConnectSt.ConnectPointDiv;
            secMngConnectStWork.ApServerIpAddress = secMngConnectSt.ApServerIpAddress;
            secMngConnectStWork.DbServerIpAddress = secMngConnectSt.DbServerIpAddress;

            return secMngConnectStWork;
        }
        # endregion
    }
}