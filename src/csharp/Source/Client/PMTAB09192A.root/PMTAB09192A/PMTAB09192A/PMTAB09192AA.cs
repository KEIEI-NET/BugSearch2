//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : PMTAB�����\���]�ƈ��ݒ�}�X�^
// �v���O�����T�v   : PMTAB�����\���]�ƈ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/09/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using System.Runtime.Remoting;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTAB�����\���]�ƈ��ݒ�}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 31065 �L�� ���O</br>
    /// <br>Date       : 2014/09/19</br>
    /// <br></br>
    /// </remarks>
    public class PmtDefEmpAcs
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        //PMTAB�����\���]�ƈ��ݒ�}�X�^
        private IPmtDefEmpDB _iPmtDefEmpDB = null;

        #endregion

        #region Constructor

        /// <summary>
        ///PMTAB�����\���]�ƈ��ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public PmtDefEmpAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iPmtDefEmpDB = (IPmtDefEmpDB)MediationPmtDefEmpDB.GetPmtDefEmpDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                //////////this._iPmtDefEmpDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iPmtDefEmpDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB�����\���]�ƈ��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="loginAgenCode">���O�C���S���҃R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Read(out PmtDefEmp pmtDefEmp, string enterpriseCode, string loginAgenCode)
        {
            try
            {
                // �L�[���̐ݒ�
                pmtDefEmp = null;
                PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();
                pmtDefEmpWork.EnterpriseCode = enterpriseCode;
                pmtDefEmpWork.LoginAgenCode = loginAgenCode;

                // PMTAB�����\���]�ƈ��ݒ�}�X�^���[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = pmtDefEmpWork as object;

                // PMTAB�����\���]�ƈ��ݒ�}�X�^�ǂݍ���
                int status = this._iPmtDefEmpDB.Read(ref paraObj, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ǂݍ��݌��ʂ�PMTAB�����\���]�ƈ��ݒ�}�X�^���[�J�[�N���X�ɐݒ�
                    PmtDefEmpWork wkPmtDefEmpWork = (PmtDefEmpWork)paraObj;
                    // PMTAB�����\���]�ƈ��ݒ�}�X�^���[�J�[�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�ɃR�s�[
                    pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork(wkPmtDefEmpWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                //////////this._iPmtDefEmpDB = null;
                //�ʐM�G���[��-1��߂�
                pmtDefEmp = null;
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Write(ref PmtDefEmp pmtDefEmp)
        {
            PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();
            ArrayList paraList = new ArrayList();

            // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X�Ƀ����o�R�s�[
            pmtDefEmpWork = this.CopyToPmtDefEmpWorkFromPmtDefEmp(pmtDefEmp);

            // PMTAB�����\���]�ƈ��ݒ�}�X�^�̓o�^�E�X�V����ݒ�
            paraList.Add(pmtDefEmpWork);

            object paraObj = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // PMTAB�����\���]�ƈ��ݒ�}�X�^��������
                status = this._iPmtDefEmpDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;

                    pmtDefEmp = new PmtDefEmp();

                    // PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�Ƀ����o�R�s�[
                    pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork((PmtDefEmpWork)paraList[0]);
                }
            }
            catch (Exception e)
            {
                // �I�t���C������null���Z�b�g
                //////////this._iPmtDefEmpDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="PmtDefEmpList">PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X</param>
        /// <param name="parsePmtDefEmp">��ƃR�[�h</param>
        /// <param name="retTotalCnt">����</param>
        /// <param name="readMode"></param>
        /// <param name="readCnt">����</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Search(ref List<PmtDefEmp> pmtDefEmpList, PmtDefEmp parsePmtDefEmp, out int retTotalCnt, int readMode, int readCnt, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            Object objPmtDefEmpWorkList = null;
            PmtDefEmpWork parsePmtDefEmpWork = null;
            ArrayList pmtDefEmpWorkResultList = null;
            List<PmtDefEmpWork> pmtDefEmpWorkList = null;

            retTotalCnt = 0;
            parsePmtDefEmpWork = new PmtDefEmpWork();
            parsePmtDefEmpWork.EnterpriseCode = parsePmtDefEmp.EnterpriseCode;
            parsePmtDefEmpWork.LoginAgenCode = parsePmtDefEmp.LoginAgenCode;

            //��������
            status = _iPmtDefEmpDB.Search(ref objPmtDefEmpWorkList, parsePmtDefEmpWork, readMode, logicalMode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            //���ʂ�߂�
            pmtDefEmpWorkResultList = objPmtDefEmpWorkList as ArrayList;

            if (pmtDefEmpWorkResultList != null)
            {
                pmtDefEmpWorkList = new List<PmtDefEmpWork>((PmtDefEmpWork[])pmtDefEmpWorkResultList.ToArray(typeof(PmtDefEmpWork)));
            }

            if (pmtDefEmpWorkList != null)
            {
                pmtDefEmpList = new List<PmtDefEmp>();
                PmtDefEmp pmtDefEmp = null;
                foreach (PmtDefEmpWork pmtDefEmpWork in pmtDefEmpWorkList)
                {
                    pmtDefEmp = null;
                    pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork(pmtDefEmpWork);
                    pmtDefEmpList.Add(pmtDefEmp);
                }
            }

            return status;
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int LogicalDelete(ref PmtDefEmp pmtDefEmp)
        {

            ArrayList paraList = new ArrayList();
            PmtDefEmpWork PmtDefEmpWork = new PmtDefEmpWork();

            // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X�Ƀ����o�R�s�[
            PmtDefEmpWork = this.CopyToPmtDefEmpWorkFromPmtDefEmp(pmtDefEmp);

            paraList.Add(PmtDefEmpWork);

            Object objPmtDefEmpWorkList = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;


            // �_���폜����
            status = _iPmtDefEmpDB.LogicalDelete(ref objPmtDefEmpWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                paraList = (ArrayList)objPmtDefEmpWorkList;

                pmtDefEmp = new PmtDefEmp();

                // PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�Ƀ����o�R�s�[
                pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork((PmtDefEmpWork)paraList[0]);

                return status;
            }
            return status;
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int Delete(ref PmtDefEmp pmtDefEmp)
        {

            PmtDefEmpWork PmtDefEmpWork = new PmtDefEmpWork();

            ArrayList paraList = new ArrayList();

            // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X�Ƀ����o�R�s�[
            PmtDefEmpWork = this.CopyToPmtDefEmpWorkFromPmtDefEmp(pmtDefEmp);

            paraList.Add(PmtDefEmpWork);

            Object objPmtDefEmpWorkList = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //�����폜����
            status = _iPmtDefEmpDB.Delete(objPmtDefEmpWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objPmtDefEmpWorkList;

                pmtDefEmp = new PmtDefEmp();

                // PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�Ƀ����o�R�s�[
                pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork((PmtDefEmpWork)paraList[0]);

                return status;
            }

            return status;
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref PmtDefEmp pmtDefEmp)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();

            ArrayList paraList = new ArrayList();

            // PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X�Ƀ����o�R�s�[
            pmtDefEmpWork = this.CopyToPmtDefEmpWorkFromPmtDefEmp(pmtDefEmp);

            paraList.Add(pmtDefEmpWork);

            Object objPmtDefEmpWorkList = paraList;

            //��������
            status = _iPmtDefEmpDB.RevivalLogicalDelete(ref objPmtDefEmpWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objPmtDefEmpWorkList;

                pmtDefEmp = new PmtDefEmp();

                // PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�Ƀ����o�R�s�[
                pmtDefEmp = this.CopyToPmtDefEmpFromPmtDefEmpWork((PmtDefEmpWork)paraList[0]);

                return status;
            }

            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iPMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X��PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�j
        /// </summary>
        /// <param name="PmtDefEmpWork">PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X</param>
        /// <returns>PMTAB�����\���]�ƈ��ݒ�}�X�^</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private PmtDefEmp CopyToPmtDefEmpFromPmtDefEmpWork(PmtDefEmpWork pmtDefEmpWork)
        {
            PmtDefEmp pmtDefEmp = new PmtDefEmp();
            pmtDefEmp.CreateDateTime = pmtDefEmpWork.CreateDateTime;
            pmtDefEmp.UpdateDateTime = pmtDefEmpWork.UpdateDateTime;
            pmtDefEmp.EnterpriseCode = pmtDefEmpWork.EnterpriseCode;
            pmtDefEmp.FileHeaderGuid = pmtDefEmpWork.FileHeaderGuid;
            pmtDefEmp.UpdEmployeeCode = pmtDefEmpWork.UpdEmployeeCode;
            pmtDefEmp.UpdAssemblyId1 = pmtDefEmpWork.UpdAssemblyId1;
            pmtDefEmp.UpdAssemblyId2 = pmtDefEmpWork.UpdAssemblyId2;
            pmtDefEmp.LogicalDeleteCode = pmtDefEmpWork.LogicalDeleteCode;
            pmtDefEmp.LoginAgenCode = pmtDefEmpWork.LoginAgenCode;
            pmtDefEmp.SalesEmpDiv = pmtDefEmpWork.SalesEmpDiv;
            pmtDefEmp.SalesEmployeeCd = pmtDefEmpWork.SalesEmployeeCd;
            pmtDefEmp.FrontEmpDiv = pmtDefEmpWork.FrontEmpDiv;
            pmtDefEmp.FrontEmployeeCd = pmtDefEmpWork.FrontEmployeeCd;
            pmtDefEmp.SalesInputDiv = pmtDefEmpWork.SalesInputDiv;
            pmtDefEmp.SalesInputCode = pmtDefEmpWork.SalesInputCode;

            return pmtDefEmp;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iPMTAB�����\���]�ƈ��ݒ�}�X�^�N���X��PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="PmtDefEmp">PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X</param>
        /// <returns>PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�N���X����PMTAB�����\���]�ƈ��ݒ�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 31065 �L�� ���O</br>
        /// <br>Date       : 2014/09/19</br>
        /// </remarks>
        private PmtDefEmpWork CopyToPmtDefEmpWorkFromPmtDefEmp(PmtDefEmp pmtDefEmp)
        {
            PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();

            pmtDefEmpWork.CreateDateTime = pmtDefEmp.CreateDateTime;
            pmtDefEmpWork.UpdateDateTime = pmtDefEmp.UpdateDateTime;
            pmtDefEmpWork.EnterpriseCode = pmtDefEmp.EnterpriseCode;
            pmtDefEmpWork.FileHeaderGuid = pmtDefEmp.FileHeaderGuid;
            pmtDefEmpWork.UpdEmployeeCode = pmtDefEmp.UpdEmployeeCode;
            pmtDefEmpWork.UpdAssemblyId1 = pmtDefEmp.UpdAssemblyId1;
            pmtDefEmpWork.UpdAssemblyId2 = pmtDefEmp.UpdAssemblyId2;
            pmtDefEmpWork.LogicalDeleteCode = pmtDefEmp.LogicalDeleteCode;
            pmtDefEmpWork.LoginAgenCode = pmtDefEmp.LoginAgenCode;
            pmtDefEmpWork.SalesEmpDiv = pmtDefEmp.SalesEmpDiv;
            pmtDefEmpWork.SalesEmployeeCd = pmtDefEmp.SalesEmployeeCd;
            pmtDefEmpWork.FrontEmpDiv = pmtDefEmp.FrontEmpDiv;
            pmtDefEmpWork.FrontEmployeeCd = pmtDefEmp.FrontEmployeeCd;
            pmtDefEmpWork.SalesInputDiv = pmtDefEmp.SalesInputDiv;
            pmtDefEmpWork.SalesInputCode = pmtDefEmp.SalesInputCode;

            return pmtDefEmpWork;
        }

        #endregion
    }
}