//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �n���f�B�^�[�~�i�����O�C�����擾�A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i�����O�C�����擾�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���R
// �� �� ��  2017/06/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �� �� ��  2017/08/11  �C�����e : �n���f�B�^�[�~�i���񎟊J���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00 �쐬�S�� : ��
// �� �� ��  2020/04/08  �C�����e : �n���f�B�d���ꎞ�݌ɓo�^�Ή�
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i�����O�C�����擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i�����O�C�����擾�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2017/06/05</br>
    /// <br>Update Note: 杍^</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br>�Ǘ��ԍ�   : 11370074-00</br>
    /// <br>           : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
    /// </remarks>
    public class HandyLoginInfoAcs
    {
        #region [�萔]
        // ���擾������ɏI�������X�e�[�^�X
        private const int StatusNomal = 0;
        // ۸޲�ID��������Ȃ��X�e�[�^�X
        private const int StatusNotFound = 4;
        // �Ǎ����̃^�C���A�E�g�X�e�[�^�X
        private const int StatusTimeout = 5;
        // DB�������ŃG���[�����������X�e�[�^�X
        private const int StatusError = -1;
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNamePgid = "PMHND00010A_";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>�f�t�H���g���O�t�@�C�����̓����t�H�[�}�b�g</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>�f�t�H���g���O���e�t�H�[�}�b�g</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>��ƃR�[�h</summary>
        private const string EnterpriseCode = "��ƃR�[�h:";
        /// <summary>���O�C��ID</summary>
        private const string LoginId = "���O�C��ID:";
        /// <summary>�R���s���[�^��</summary>
        private const string MachineName = "�R���s���[�^��:";
        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ErrorMsgNull = "����������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ErrorMsgParam = "���̓p�����[�^�G���[���������܂����B";

        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
        /// <summary>�I�v�V����OFF�u0:OFF(�g�p�s��)�v</summary>
        private const int OptionOff = 0;
        /// <summary>�I�v�V����ON�u1:ON(�g�p��)�v</summary>
        private const int OptionOn = 1;
        // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
        #endregion

        // ===================================================================================== //
        // Static �ϐ�
        // ===================================================================================== //
        #region Static Members
        /// <summary>���O�p���b�N</summary>
        static object LogLockObj = null;
        #endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public HandyLoginInfoAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// �n���f�B�^�[�~�i�����O�C�����擾����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i�����O�C�������擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/05</br>
        /// <br>Update Note: 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// <br>�Ǘ��ԍ�   : 11370074-00</br>
        /// <br>           : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
        /// </remarks>
        public int SearchHandyLoginInfo(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;

            // ��������
            HandyLoginInfoCondWork handyLoginInfoCondWork = condObj as HandyLoginInfoCondWork;
            // �p�����[�^��null�̏ꍇ�A
            if (handyLoginInfoCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(handyLoginInfoCondWork, ErrorMsgNull);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �K�{���͍��ڃ`�F�b�N
                if (string.IsNullOrEmpty(handyLoginInfoCondWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(handyLoginInfoCondWork.LoginId.Trim())
                    || string.IsNullOrEmpty(handyLoginInfoCondWork.MachineName.Trim()))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(handyLoginInfoCondWork, ErrorMsgParam);
                    return status;
                }
            }

            try
            {
                #region ���O�C�������擾����
                // �����[�g�擾
                IHandyLoginInfoDB iHandyLoginInfoDB = (IHandyLoginInfoDB)MediationHandyLoginInfoDB.GetHandyLoginInfoDB();

                // �n���f�B�^�[�~�i�����O�C�����擾�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(handyLoginInfoCondWork);
                byte[] retByte = null;

                status = iHandyLoginInfoDB.Search(condByte, out retByte);

                // ���擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ԋp�p�����[�^�Z�b�g
                    object handyLoginInfoWorkObj = XmlByteSerializer.Deserialize(retByte, typeof(HandyLoginInfoWork));

                    // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                    HandyLoginInfoWork handyLoginInfoWork = (HandyLoginInfoWork)handyLoginInfoWorkObj;

                    // �d���x���Ǘ��u0:OFF(�g�p�s��) 1:ON(�g�p��)�v
                    PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        handyLoginInfoWork.SupPayManageOp = OptionOn;
                    }
                    else
                    {
                        handyLoginInfoWork.SupPayManageOp = OptionOff;
                    }

                    // �n���f�BOP(�Г�)�u0:OFF(�g�p�s��) 1:ON(�g�p��)�v
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InspMng_Company);
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        handyLoginInfoWork.HandyHouOp = OptionOn;
                    }
                    else
                    {
                        handyLoginInfoWork.HandyHouOp = OptionOff;
                    }

                    // �n���f�BOP(�d��)�u0:OFF(�g�p�s��) 1:ON(�g�p��)�v
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InspMng_Stock);
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        handyLoginInfoWork.HandySupOp = OptionOn;
                    }
                    else
                    {
                        handyLoginInfoWork.HandySupOp = OptionOff;
                    }

                    // --- ADD 2020/04/08 ---------->>>>>
                    // �n���f�BOP(�݌ɓo�^)�u0:OFF(�g�p�s��) 1:ON(�g�p��)�v
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InsStock);
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        handyLoginInfoWork.HandyZaikoRegistOp = OptionOn;
                    }
                    else
                    {
                        handyLoginInfoWork.HandyZaikoRegistOp = OptionOff;
                    }
                    // --- ADD 2020/04/08 ----------<<<<<

                    retObj = handyLoginInfoWorkObj;
                    // ------ ADD 2017/08/11 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<

                    status = StatusNomal;
                }
                // ۸޲�ID��������Ȃ��ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // �Ǎ����̃^�C���A�E�g�ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB�������ŃG���[�����������ꍇ
                else
                {
                    status = StatusError;
                }
                #endregion
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(handyLoginInfoCondWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �������Ȃ�
            }

            return status;
        }
        # endregion

        # region [private Methods]
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="handyLoginInfoCondWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(HandyLoginInfoCondWork handyLoginInfoCondWork, string errMsg)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + PathLog;

            lock (LogLockObj)
            {
                // �t�H���_�����݂��Ȃ��ꍇ�A
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                // �p�����[�^��null�ł͂Ȃ��ꍇ�A�G���[���b�Z�[�W�Ɉ����̖��O�ƒl���o�͂��܂��B
                if (handyLoginInfoCondWork != null)
                {
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + handyLoginInfoCondWork.EnterpriseCode);
                    // ���O�C��ID
                    writer.WriteLine(LoginId + handyLoginInfoCondWork.LoginId);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyLoginInfoCondWork.MachineName);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}
