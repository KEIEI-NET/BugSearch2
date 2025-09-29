//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���엚�����O�f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : ���엚�����O�f�[�^�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���엚�����O�f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d������A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeOprtnHisLogAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeOprtnHisLogAcs()
		{
			//��ƃR�[�h���擾����
			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//���O�C�����_�R�[�h
			_loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            //�N���v���O��������
            _logDataObjBootProgramNm = Path.GetFileName(Environment.GetCommandLineArgs()[0]);

			//���엚�����O����
			_oprtnHisLogList = new List<OprtnHisLog>();

			//���엚�����O �����[�g�I�u�W�F�N�g
			this._iOprtnHisLogDB = (IOprtnHisLogDB)MediationOprtnHisLogDB.GetOprtnHisLogDB();
		}
		/// <summary>
		/// �A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
		/// <returns></returns>
		public static UoeOprtnHisLogAcs GetInstance()
		{
			if (_uoeOprtnHisLogAcs == null)
			{
				_uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
			}

			return _uoeOprtnHisLogAcs;
		}

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		//�A�N�Z�X�N���X �C���X�^���X
		private static UoeOprtnHisLogAcs _uoeOprtnHisLogAcs;

		//���엚�����O�f�[�^���X�g
		private List<OprtnHisLog> _oprtnHisLogList = new List<OprtnHisLog>();

		//��ƃR�[�h
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

		//���O�C�����_�R�[�h
        private string _loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

		//�[����
		private string _logDataMachineName = "";

		//���O�f�[�^�S���҃R�[�h
		private string _logDataAgentCd = "";

		//���O�f�[�^�S���Җ�
		private string _logDataAgentNm = "";

		//�N���v���O��������
        private string _logDataObjBootProgramNm = "";

		//���엚�����O �����[�g
		private IOprtnHisLogDB _iOprtnHisLogDB = null;

		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// �[����
		/// </summary>
		public string LogDataMachineName
		{
			get { return this._logDataMachineName; }
			set { this._logDataMachineName = value; }
		}

		/// <summary>
		/// ���O�f�[�^�S���҃R�[�h
		/// </summary>
		public string LogDataAgentCd
		{
			get { return this._logDataAgentCd; }
			set { this._logDataAgentCd = value; }
		}

		/// <summary>
		/// ���O�f�[�^�S���Җ�
		/// </summary>
		public string LogDataAgentNm
		{
			get { return this._logDataAgentNm; }
			set { this._logDataAgentNm = value; }
		}
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		# region ���엚�����O�f�[�^�̏���������
		/// <summary>
		/// ���엚�����O�f�[�^�̏���������
		/// </summary>
		public void OprtnHisLogInit()
		{
			if (_oprtnHisLogList == null )
			{
                _oprtnHisLogList = new List<OprtnHisLog>();
            }
            else
            {
				_oprtnHisLogList.Clear();
			}
		}
		# endregion

        # region �ʐM���O��������
        /// <summary>
        /// �ʐM���O��������
        /// </summary>
        /// <param name="logDataObjProcNm"></param>
        /// <param name="logDataOperationCd"></param>
        /// <param name="logDataMassage"></param>
        /// <param name="len"></param>
        public void log_update(object sender, string logDataObjProcNm, Int32 logDataOperationCd, byte[] logDataMassage, int len, Int32 uOESupplierCd)
        {
            log_update(sender, logDataObjProcNm, logDataOperationCd, logDataMassage, len, (int)EnumUoeConst.ctOprtnHisLogFlush.ct_OFF);
        }

        /// <summary>
        /// �ʐM���O��������
        /// </summary>
        /// <param name="logDataObjProcNm">���\�b�h��</param>
        /// <param name="logDataOperationCd">���O�f�[�^�I�y���[�V�����R�[�h</param>
        /// <param name="logDataMassage">���O�f�[�^</param>
        /// <param name="len"></param>
        /// <param name="mode">0:�t���b�V���Ȃ� 1:�t���b�V������</param>
        public void log_update(object sender, string logDataObjProcNm, Int32 logDataOperationCd, byte[] logDataMassage, int len, Int32 uOESupplierCd, int mode)
        {
            string logDataMassageString = changeHex(logDataMassage, len);

            try
            {
                Type type = sender.GetType();


                OprtnHisLog oprtnHisLog = new OprtnHisLog();

                //���O�f�[�^��ʋ敪�R�[�h
                //0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)
                oprtnHisLog.LogDataKindCd = (Int32)EnumUoeConst.ctLogDataKindCd.ct_TERM;

                //���O�f�[�^�ΏۃA�Z���u��ID
                oprtnHisLog.LogDataObjAssemblyID = type.Assembly.GetName().Name;

                //���O���������񂾃A�Z���u������
                oprtnHisLog.LogDataObjAssemblyNm = type.Assembly.GetName().Name;

                //���O�f�[�^�Ώۏ�����
                //���O���������ލۂ̏�����(���\�b�h��)
                oprtnHisLog.LogDataObjProcNm = logDataObjProcNm;

                //���O�f�[�^�I�y���[�V�����R�[�h
                //������e�R�[�h(0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��)
                oprtnHisLog.LogDataOperationCd = logDataOperationCd;

                //�v���O�����̃o�[�W�������̃o�[�W����
                oprtnHisLog.LogDataSystemVersion = type.Assembly.GetName().Version.ToString();

                //���O�I�y���[�V�����X�e�[�^�X
                oprtnHisLog.LogOperationStatus = 0;

                //���O�f�[�^���b�Z�[�W
                oprtnHisLog.LogDataMassage = logDataMassageString;

                //������R�[�h
                oprtnHisLog.LogDataObjClassID = uOESupplierCd.ToString("d6");

                //���O�I�y���[�V�����f�[�^
                oprtnHisLog.LogOperationData = "";

                //���엚�����O�f�[�^�̍X�V
                _uoeOprtnHisLogAcs.OprtnHisLogUpdt(oprtnHisLog, mode);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// �ʐM���O�t���b�V������
        /// </summary>
        public void log_update()
        {
            _uoeOprtnHisLogAcs.OprtnHisLogFlush();

        }
        # endregion

        # region �c�r�o���O��������
        /// <summary>
        /// �c�r�o���O��������
        /// </summary>
        /// <param name="logDataObjProcNm"></param>
        /// <param name="logDataOperationCd"></param>
        /// <param name="logOperationStatus"></param>
        /// <param name="logDataMassage"></param>
        public void logd_update(object sender, string logDataObjProcNm, string logDataObjAssemblyNm, Int32 logDataOperationCd, Int32 logOperationStatus, string logDataMassage, Int32 uOESupplierCd)
        {
            try
            {
                Type type = sender.GetType();

                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                //�o�[�W�����̎擾
                System.Version ver = asm.GetName().Version;

		        //�c�r�o���O�N���X
		        OprtnHisLog _dipLog = new OprtnHisLog();

                //���O�f�[�^��ʋ敪�R�[�h
                //0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)
                _dipLog.LogDataKindCd = (Int32)EnumUoeConst.ctLogDataKindCd.ct_DSP;

                //���O�f�[�^�ΏۃA�Z���u��ID
                _dipLog.LogDataObjAssemblyID = type.Assembly.GetName().Name;

                //���O���������񂾃A�Z���u������
                _dipLog.LogDataObjAssemblyNm = logDataObjAssemblyNm;

                //���O�f�[�^�Ώۏ�����
                //���O���������ލۂ̏�����(���\�b�h��)
                _dipLog.LogDataObjProcNm = logDataObjProcNm;

                //���O�f�[�^�I�y���[�V�����R�[�h
                //������e�R�[�h(0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��)
                _dipLog.LogDataOperationCd = logDataOperationCd;

                //�v���O�����̃o�[�W�������̃o�[�W����
                _dipLog.LogDataSystemVersion = type.Assembly.GetName().Version.ToString();

                //���O�I�y���[�V�����X�e�[�^�X
                _dipLog.LogOperationStatus = logOperationStatus;

                //���O�f�[�^���b�Z�[�W
                _dipLog.LogDataMassage = logDataMassage;

                //������R�[�h
                _dipLog.LogDataObjClassID = uOESupplierCd.ToString("d6");

                //���O�I�y���[�V�����f�[�^
                _dipLog.LogOperationData = "";

                //���엚�����O�f�[�^�̍X�V
                _uoeOprtnHisLogAcs.OprtnHisLogUpdt(_dipLog, (int)EnumUoeConst.ctOprtnHisLogFlush.ct_ON);
            }
            catch (Exception)
            {
            }
        }
        # endregion
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region ���엚�����O�f�[�^�̃t���b�V������
        /// <summary>
        /// ���엚�����O�f�[�^�̃t���b�V������
        /// </summary>
        private void OprtnHisLogFlush()
        {
            string message = "";
            OprtnHisLogFlush(out message);
        }

        /// <summary>
        /// ���엚�����O�f�[�^�̃t���b�V������
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private int OprtnHisLogFlush(out string message)
        {


            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            try
            {
                if (_oprtnHisLogList.Count > 0)
                {
                    status = OprtnHisLogWrite(_oprtnHisLogList, out message);
                    OprtnHisLogInit();
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region ���엚�����O�f�[�^�̍X�V
        /// <summary>
        /// ���엚�����O�f�[�^�̍X�V
        /// </summary>
        /// <param name="oprtnHisLog"></param>
        /// <param name="mode"></param>
        private void OprtnHisLogUpdt(OprtnHisLog oprtnHisLog, int mode)
        {
            string message = "";

            OprtnHisLogUpdt(oprtnHisLog, mode, out message);
        }

        /// <summary>
        /// ���엚�����O�f�[�^�̍X�V
        /// </summary>
        /// <param name="oprtnHisLog"></param>
        /// <param name="mode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private int OprtnHisLogUpdt(OprtnHisLog oprtnHisLog, int mode, out string message)
        {
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            try
            {
                OprtnHisLog log = oprtnHisLog;

                //��ƃR�[�h
                log.EnterpriseCode = _enterpriseCode;

                //���t
                log.LogDataCreateDateTime = DateTime.Now;

                //���O�f�[�^GUID
                log.LogDataGuid = Guid.NewGuid();

                //���O�C�����_�R�[�h
                log.LoginSectionCd = _loginSectionCd;

                //�[����
                log.LogDataMachineName = _logDataMachineName;

                //���O�f�[�^�S���҃R�[�h
                log.LogDataAgentCd = _logDataAgentCd;

                //���O�f�[�^�S���Җ�
                log.LogDataAgentNm = _logDataAgentNm;

                //�N���v���O��������
                log.LogDataObjBootProgramNm = _logDataObjBootProgramNm;

                _oprtnHisLogList.Add(log);
                if (mode == 1)
                {
                    status = OprtnHisLogFlush(out message);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region �ʐM���O�l�̂P�U�i�ϊ�
        /// <summary>
        /// �ʐM���O�l�̂P�U�i�ϊ�
        /// </summary>
        /// <param name="src"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private string changeHex(byte[] src, int len)
        {
            string dst = "";

            try
            {
                for (int i = 0; i < len; i++)
                {
                    int srcInt = UoeCommonFnc.ToInt32FromByteNum(src[i]);
                    dst += String.Format("{0:X2}", srcInt);
                }
            }
            catch (Exception)
            {
                dst = "";
            }

            return (dst);
        }
        # endregion

		# region ���엚�����O�f�[�^�̍X�V
		/// <summary>
		/// ���엚�����O�f�[�^�̍X�V
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private int OprtnHisLogWrite(List<OprtnHisLog> list, out string message)
		{
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
				//�X�V����������
				ArrayList oprtnHisLogWorkList = new ArrayList(); 
				
				foreach(OprtnHisLog log in list)
				{
					OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();

					oprtnHisLogWork.CreateDateTime = log.CreateDateTime;	// �쐬����
					oprtnHisLogWork.UpdateDateTime = log.UpdateDateTime;	// �X�V����
					oprtnHisLogWork.EnterpriseCode = log.EnterpriseCode;	// ��ƃR�[�h
					//oprtnHisLogWork.FileHeaderGuid = log.FileHeaderGuid;	// GUID
					oprtnHisLogWork.UpdEmployeeCode = log.UpdEmployeeCode;	// �X�V�]�ƈ��R�[�h
					oprtnHisLogWork.UpdAssemblyId1 = log.UpdAssemblyId1;	// �X�V�A�Z���u��ID1
					oprtnHisLogWork.UpdAssemblyId2 = log.UpdAssemblyId2;	// �X�V�A�Z���u��ID2
					oprtnHisLogWork.LogicalDeleteCode = log.LogicalDeleteCode;	// �_���폜�敪
					oprtnHisLogWork.LogDataCreateDateTime = log.LogDataCreateDateTime;	// ���O�f�[�^�쐬����
					oprtnHisLogWork.LogDataGuid = log.LogDataGuid;	// ���O�f�[�^GUID
					oprtnHisLogWork.LoginSectionCd = log.LoginSectionCd;	// ���O�C�����_�R�[�h
					oprtnHisLogWork.LogDataKindCd = log.LogDataKindCd;	// ���O�f�[�^��ʋ敪�R�[�h
					oprtnHisLogWork.LogDataMachineName = log.LogDataMachineName;	// ���O�f�[�^�[����
					oprtnHisLogWork.LogDataAgentCd = log.LogDataAgentCd;	// ���O�f�[�^�S���҃R�[�h
					oprtnHisLogWork.LogDataAgentNm = log.LogDataAgentNm;	// ���O�f�[�^�S���Җ�
					oprtnHisLogWork.LogDataObjBootProgramNm = log.LogDataObjBootProgramNm;	// ���O�f�[�^�ΏۋN���v���O��������
					oprtnHisLogWork.LogDataObjAssemblyID = log.LogDataObjAssemblyID;	// ���O�f�[�^�ΏۃA�Z���u��ID
					oprtnHisLogWork.LogDataObjAssemblyNm = log.LogDataObjAssemblyNm;	// ���O�f�[�^�ΏۃA�Z���u������
					oprtnHisLogWork.LogDataObjClassID = log.LogDataObjClassID;	// (UOE������R�[�h)���O�f�[�^�ΏۃN���XID
					oprtnHisLogWork.LogDataObjProcNm = log.LogDataObjProcNm;	// ���O�f�[�^�Ώۏ�����
					oprtnHisLogWork.LogDataOperationCd = log.LogDataOperationCd;	// ���O�f�[�^�I�y���[�V�����R�[�h
					oprtnHisLogWork.LogOperaterDtProcLvl = log.LogOperaterDtProcLvl;	// ���O�f�[�^�I�y���[�^�[�f�[�^�������x��
					oprtnHisLogWork.LogOperaterFuncLvl = log.LogOperaterFuncLvl;	// ���O�f�[�^�I�y���[�^�[�@�\�������x��
					oprtnHisLogWork.LogDataSystemVersion = log.LogDataSystemVersion;	// ���O�f�[�^�V�X�e���o�[�W����
					oprtnHisLogWork.LogOperationStatus = log.LogOperationStatus;	// ���O�I�y���[�V�����X�e�[�^�X

                    // ���O�f�[�^���b�Z�[�W
                    string logDataMassage = log.LogDataMassage;
                    if (log.LogDataMassage.Length > 500)
                    {
                        logDataMassage = log.LogDataMassage.Substring(0, 500);
                    }
                    oprtnHisLogWork.LogDataMassage = logDataMassage;

                    // ���O�I�y���[�V�����f�[�^
                    string logOperationData = log.LogOperationData;
                    if (log.LogOperationData.Length > 80)
                    {
                        logOperationData = log.LogOperationData.Substring(0, 80);
                    }
                    oprtnHisLogWork.LogOperationData = logOperationData;

					oprtnHisLogWorkList.Add(oprtnHisLogWork);
				}

                object oprtnHisLogWorkListObject = oprtnHisLogWorkList;

                status = _iOprtnHisLogDB.Write(ref oprtnHisLogWorkListObject);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					status = -1;
					message = "���엚�����O�̏������݂Ɏ��s���܂��B";
				}

			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion
		# endregion
	}
}
