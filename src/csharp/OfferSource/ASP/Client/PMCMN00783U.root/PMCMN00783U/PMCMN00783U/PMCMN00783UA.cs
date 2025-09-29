#define DISP_ERRDIALOG		// �G���[�_�C�A���O�\�����s��

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;      // 2009.05.12 Add

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ύX�ē��ʒm��ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ύX�ē��ʒm���s����ʂł��B</br>
	/// <br>Programmer : 21027  �{��  ���u�Y</br>
	/// <br>Date       : 2007.03.15</br>
	/// <br>Update Note: 2007.09.19  21027 �{��  ���u�Y</br>
	/// <br>           :   1.�u����ʒm���Ɋւ��č���\�����Ȃ��v�`�F�b�N�{�b�N�X���f�t�H���gOFF�ɂ���悤�Ɏd�l�ύX</br>
	/// <br>           : 2008.01.07  90027 Kouguchi</br>
	/// <br>           :   1.�V���C�A�E�g�Ή�</br>
    /// <br></br>
    /// <br>           : 2008.11.20  21024�@���X�� ��</br>
    /// <br>           :   PM.NS�p�ɕύX</br>
    /// <br></br>
    /// <br>           : 2009.05.12  21024�@���X�� ��</br>
    /// <br>           :   ���W�X�g����ON�EOFF��؂�ւ����悤�ɏC��</br>
    /// </remarks>
	public partial class PMCMN00783UA : Form
	{
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public PMCMN00783UA()
		{
			InitializeComponent();

			// �w�i�ݒ菈��(��ǉ��Ή��̈וʏ���)
			System.Reflection.Assembly myAssem = System.Reflection.Assembly.GetExecutingAssembly();
			this.pnl_Top.BackgroundImage =
				new Bitmap(myAssem.GetManifestResourceStream("Broadleaf.Windows.Forms.Images.NotifyPopupBackground_top.png"));
			this.pnl_Body.BackgroundImage =
				new Bitmap(myAssem.GetManifestResourceStream("Broadleaf.Windows.Forms.Images.NotifyPopupBackground_body.png"));
			this.pnl_Bottom.BackgroundImage =
				new Bitmap(myAssem.GetManifestResourceStream("Broadleaf.Windows.Forms.Images.NotifyPopupBackground_bottom.png"));

			IsWindowless = false;
        }


        #region Static Fields
		/// <summary>���������t���O</summary>
		internal static bool IsSuccess;
		/// <summary>�E�B���h�E�N���L��</summary>
		internal static bool IsWindowless;
		/// <summary>�v���Z�X�I���p�����C�x���g</summary>
		internal static ManualResetEvent ExitSyncEvent = new ManualResetEvent(false);

		/// <summary>PMC�v���Z�X</summary>
		private static Process PmcProcess;
		/// <summary>��ƔF�؏��</summary>
		private static CompanyAuthInfoWork CompanyAuthInfo;
		/// <summary>�A�v���P�[�V�����\���ێ��N���X</summary>
		private static ChangeInfoCheckAppConfig AppConfig;
		/// <summary>�O��f�[�^�ێ��N���X</summary>
		private static LatestChangeInfoData[] LatestDataArray;

        //Del  ������  2008.01.07 Kouguchi
        ///// <summary>�X�VPG�z�M���</summary>
        //private static PgMulcasGdWork PgMulcasInf;
        ///// <summary>�X�VPG�z�M���</summary>
        //private static SvrMntInfoWork SvrMntInfNml;
        ///// <summary>�X�VPG�z�M���</summary>
        //private static SvrMntInfoWork SvrMntInfEmg;
        //Del  ������  2008.01.07 Kouguchi

        //Add  ������  2008.01.07 Kouguchi
        /// <summary>�ύX�ē����(�X�V PG�z�M���)</summary>
        private static ChangGidncWork ChangGidncInf1;
        /// <summary>�ύX�ē����(�X�V ��������e���)</summary>
        private static ChangGidncWork ChangGidncInf2;
        /// <summary>�ύX�ē����(�X�V �f�[�^�����e���)</summary>
        private static ChangGidncWork ChangGidncInf3;
        /// <summary>�ύX�ē����(�X�V �ً}�����e���)</summary>
        private static ChangGidncWork ChangGidncInf4;
        /// <summary>�ύX�ē����(�X�V�󎚈ʒu�����[�X���)</summary>
        private static ChangGidncWork ChangGidncInf5;
        //Add  ������  2008.01.07 Kouguchi


		/// <summary>�A�v���P�[�V�����\���N���X�p�V���A���C�Y�L�[</summary>
		private static readonly string[] AppConfigKey = new string[] { typeof(PMCMN00783UA).Name, "AppConfigKey" };
		/// <summary>�A�v���P�[�V�����ݒ�t�@�C����</summary>
		private static readonly string AppConfigFileName = "PMCMN00783U_Config.dat";
		/// <summary>�O��f�[�^�N���X�p�V���A���C�Y�L�[</summary>
		private static readonly string[] LatestDataKey = new string[] { typeof(PMCMN00783UA).Name, "LatestDataKey" };
		/// <summary>�O��f�[�^�t�@�C����</summary>
        private static readonly string LatestDataFileName = Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData, "PMCMN00783U_Data.dat");

		/// <summary>�ē��`�F�b�N�Ԋu(sec)</summary>
		private static int CheckTimeSpan = 3600;
		/// <summary>�X�V�`�F�b�NWeb�T�[�r�XURL</summary>
		private static string WebServiceURL = String.Empty;
		/// <summary>�ύX�ē��ʒm�g�b�v�y�[�WURL</summary>
		private static string WebTopPageURL = String.Empty;


        private static string WebTopPageURL2 = "";  //Add 2007.01.07 Kouguchi
        private static int SW_ChangGidncInf2 = 0;  //Add 2008.03.27 Kouguchi
        private static int SW_ChangGidncInf3 = 0;  //Add 2008.03.27 Kouguchi
        #endregion


        #region Fields
		/// <summary>�X�N���[������</summary>
		private int screenWidth;
		/// <summary>�X�N���[������</summary>
		private int screenHeight;
		/// <summary>�I�����t���O</summary>
		private bool canCloseFlg = false;
        #endregion


        #region Constants
		/// <summary>PMC�v���Z�X����</summary>
		private const string ctKEY_PMCProcessName = "ProductManageClient";
		/// <summary>PGID</summary>
		internal const string ctPGID = "PMCMN00783U";
        #endregion


        #region Properties
		/// <summary>
		/// �E�B���h�E���\�����ꂽ�Ƃ��ɂ��̃E�B���h�E���A�N�e�B�u�ɂ��邩�ǂ����������l���擾���܂��B
		/// </summary>
		/// <value>
		/// �E�B���h�E���\�����ꂽ�Ƃ��ɂ��̃E�B���h�E���A�N�e�B�u�ɂ��Ȃ��ꍇ�� True�B����ȊO�̏ꍇ�� false�B����l�� false �ł��B
		/// </value>
		protected override bool ShowWithoutActivation
		{
			get { return true; }
        }
        #endregion


        #region Static Methods

        #region �A�v���P�[�V���������ݒ菈��
        /// <summary>
		/// �A�v���P�[�V���������ݒ菈��
		/// </summary>
		public static void InitializeApplication()
		{
			IsSuccess = true;
			IsWindowless = true;
			if (IsSuccess) SetProcessWatcher(ctKEY_PMCProcessName);  //���i�Ǘ��N���C�A���g�v���Z�X�Ď�����
            if (IsSuccess) GetApplicationConfig();                   //�A�v���P�[�V�����\�����擾����
            if (IsSuccess) SetCompanyAuthInfo();                     //�F�؏��擾����
            if (IsSuccess) CheckChangeInfoWaitRoop(false);           //�ύX�ē��X�V�`�F�b�N�ҋ@���[�v����

#if DISP_ERRDIALOG
			if (!IsSuccess)
			{
				MessageBox.Show(
					"PM.NS �ύX�ē��ʒm�N���C�A���g�̋N���Ɏ��s���܂����B",
                    "PM.NS �ύX�ē��ʒm",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
#endif
		}
        #endregion

        #region ���i�Ǘ��N���C�A���g�v���Z�X�Ď�����
        /// <summary>
		/// ���i�Ǘ��N���C�A���g�v���Z�X�Ď�����
		/// </summary>
		/// <param name="processName">�v���Z�X����</param>
		private static void SetProcessWatcher(string processName)
		{
			try
			{
				// ���̂��v���Z�X�擾
				Process[] getByNameAry = Process.GetProcessesByName(processName);

				if ((getByNameAry != null) && (getByNameAry.Length > 0))
				{
					// PMC��1���������オ���Ă��Ȃ��͂�(�b��)
					PmcProcess = getByNameAry[0];
				}
				PmcProcess.EnableRaisingEvents = true;
				PmcProcess.Exited += new EventHandler(pmcProcess_Exited);
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"���i�Ǘ��N���C�A���g�v���Z�X�̎擾�Ɏ��s���܂����B",
					0,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				IsSuccess = false;
			}
        }
        #endregion

        #region ���i�Ǘ��N���C�A���g�I���C�x���g�n���h��
        /// <summary>
		/// ���i�Ǘ��N���C�A���g�I���C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private static void pmcProcess_Exited(object sender, EventArgs e)
		{
			// Web�T�[�r�X��M���͏I�������ҋ@
			ExitSyncEvent.WaitOne();

			// �Ď��v���Z�X�I��
			EndProcess();
        }
        #endregion

        #region �Ď��v���Z�X�I������
        /// <summary>
		/// �Ď��v���Z�X�I������
		/// </summary>
		private static void EndProcess()
		{
			// ApplicationRun���s�O
			if (IsWindowless)
			{
                //Process�̏I��
				Environment.Exit(0);
			}
			// ApplicationRun���s��
			else
			{
                //Application�̏I��
				System.Windows.Forms.Application.Exit();
                //Process�̏I��
				Environment.Exit(0);
			}
        }
        #endregion

        #region �A�v���P�[�V�����\�����擾����
        /// <summary>
		/// �A�v���P�[�V�����\�����擾����
		/// </summary>
		private static void GetApplicationConfig()
		{
			try
			{
				// �A�v���P�[�V�����\�����擾
				if (UserSettingController.ExistUserSetting(AppConfigFileName))
				{
					AppConfig = UserSettingController.DecryptionDeserializeUserSetting<ChangeInfoCheckAppConfig>(AppConfigFileName, AppConfigKey);
				}
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"�A�v���P�[�V�����\�����̎擾�Ɏ��s���܂����B",
					0,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
			}

			if (AppConfig == null)
			{
				IsSuccess = false;

				MessageBox.Show(
					"�A�v���P�[�V�����\�����̎擾�Ɏ��s���܂����B",
                    "PM.NS �ύX�ē��ʒm",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
			else
			{
				WebServiceURL = AppConfig.WebServiceURL;	// �X�V�`�F�b�NWeb�T�[�r�XURL
                // 2008.11.20 Add >>>
                if (WebServiceURL.Contains("%Infomation%"))
                {
                    WebServiceURL = WebServiceURL.Replace("%Infomation%", GetWebTopPageURLFromPMC());
                }
                // 2008.11.20 Add <<<

				CheckTimeSpan = AppConfig.CheckTimeSpan;	// �X�V�`�F�b�N�Ԋu(sec)
				WebTopPageURL = AppConfig.WebTopPageURL;	// �ύX�ē��g�b�v�y�[�W
                // 2008.11.20 Add >>>
                if (WebTopPageURL.Contains("%Infomation%"))
                {
                    WebTopPageURL = WebTopPageURL.Replace("%Infomation%", GetWebTopPageURLFromPMC());
                }
                // 2008.11.20 Add <<<
            }
        }
        #endregion

        #region �O��ʒm�f�[�^�Ǎ��ݏ���
        /// <summary>
		/// �O��ʒm�f�[�^�Ǎ��ݏ���
		/// </summary>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>true:�Ǎ��ݐ���</description></item>
		/// <item><description>false:�Ǎ��ݎ��s/�O��f�[�^����</description></item>
		/// </list>
		/// </returns>
		private static bool ReadLatestChangeInfoData()
		{
			bool retBool = false;

			try
			{
				// �A�v���P�[�V�����\�����擾
				if (UserSettingController.ExistUserSetting(LatestDataFileName))
				{
					LatestDataArray = UserSettingController.DecryptionDeserializeUserSetting<LatestChangeInfoData[]>(LatestDataFileName, LatestDataKey);
				}
			}
			catch (Exception) 
            { 
            }

			if ((LatestDataArray != null) && (LatestDataArray.Length > 0))
			{
				retBool = true;
			}

			return retBool;
        }
        #endregion

        #region �O��ʒm�f�[�^�����ݏ���
        /// <summary>
		/// �O��ʒm�f�[�^�����ݏ���
		/// </summary>
		/// <param name="updateLatestData">�ۑ��f�[�^�X�V�L���t���O</param>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>true:�����ݐ���</description></item>
		/// <item><description>false:�����ݎ��s/�����ݑΏۃf�[�^����</description></item>
		/// </list>
		/// </returns>
		private static bool WriteLatestChangeInfoData(bool updateLatestData)
		{
			if (updateLatestData)
			{
				if ((LatestDataArray == null) || (LatestDataArray.Length == 0))
				{
					LatestDataArray = new LatestChangeInfoData[1];
					LatestDataArray[0] = new LatestChangeInfoData();
					LatestDataArray[0].ProductCode = CompanyAuthInfo.ProductInfoWork.ProductCode;
				}

                //Del ������ 2008.01.07 Kouguchi
                ////�X�VPG�z�M��񂪂���ꍇ
                //if (PgMulcasInf != null)   LatestDataArray[0].MulticastVersion = PgMulcasInf.MulticastVersion;
                ////�X�V��������e��񂪂���ꍇ
                //if (SvrMntInfEmg != null)  LatestDataArray[0].EmgServerMainteConsNo = SvrMntInfEmg.ServerMainteConsNo;
                ////�X�VPG�z�M��񂪂���ꍇ
                //if (SvrMntInfNml != null)  LatestDataArray[0].NmlServerMainteConsNo = SvrMntInfNml.ServerMainteConsNo;
                //Del ������ 2008.01.07 Kouguchi

                //Add ������ 2008.01.07 Kouguchi
                //�ύX�ē����(�X�V PG�z�M���)������ꍇ
                if (ChangGidncInf1 != null)  LatestDataArray[0].MulticastVersion      = ChangGidncInf1.McastGidncVersionCd;
                //�ύX�ē����(�X�V ��������e���)������ꍇ
                if (ChangGidncInf2 != null)  LatestDataArray[0].NmlServerMainteConsNo = ChangGidncInf2.MulticastConsNo;
                //�ύX�ē����(�X�V �f�[�^�����e���)������ꍇ
                if (ChangGidncInf3 != null)  LatestDataArray[0].DatServerMainteConsNo = ChangGidncInf3.MulticastConsNo;
                //�ύX�ē����(�X�V �ً}�����e���)������ꍇ
                if (ChangGidncInf4 != null)  LatestDataArray[0].EmgServerMainteConsNo = ChangGidncInf4.MulticastConsNo;
                //�ύX�ē����(�X�V �󎚈ʒu�����[�X���)������ꍇ
                if (ChangGidncInf5 != null)  LatestDataArray[0].PrintPositionConsNo   = ChangGidncInf5.MulticastConsNo;
                //Add ������ 2008.01.07 Kouguchi

			}
			else
			{
				if ((LatestDataArray == null) || (LatestDataArray.Length == 0)) return false;
			}

			try
			{
				UserSettingController.EncryptionSerializeUserSetting(LatestDataArray, LatestDataFileName, LatestDataKey);
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"�O��ʒm�f�[�^�̕ۑ��Ɏ��s���܂����B",
					0,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return false;
			}

			return true;
        }
        #endregion

        #region �F�؏��擾����
        /// <summary>
		/// �F�؏��擾����
		/// </summary>
		private static void SetCompanyAuthInfo()
		{
			try
			{
				// ��ƔF�؏����擾
				CompanyAuthInfo = LoginInfoAcquisition.ToObject(typeof(CompanyAuthInfoWork)) as CompanyAuthInfoWork;

				if (CompanyAuthInfo == null)
				{
					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_NODISP,
						ctPGID,
						"�F�؏��̎擾�Ɏ��s���܂����B",
						0,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

					IsSuccess = false;
				}
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"�F�؏��̎擾�ɂăG���[���������܂����B",
					0,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				IsSuccess = false;
			}
        }
        #endregion

        #region �ύX�ē��X�V�`�F�b�N�ҋ@���[�v����
        /// <summary>
		/// �ύX�ē��X�V�`�F�b�N�ҋ@���[�v����
		/// </summary>
		/// <param name="firstWait">����ҋ@�L���t���O</param>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>0:�X�V���L��őҋ@���[�v�E�o</description></item>
		/// <item><description>-99:�G���[�����ɂđҋ@���[�v�E�o</description></item>
		/// </list>
		/// </returns>
		private static int CheckChangeInfoWaitRoop(bool firstWait)
		{
			int status = 0;

			try
			{
				// �w�莞�ԑҋ@
				if (firstWait)
				{
					Thread.Sleep(CheckTimeSpan * 1000);
				}

				while (true)
				{
                    // 2009.05.12 Add >>>
                    if (!CheckContinueProcess())
                    {
                        // �w�莞�ԑҋ@
                        Thread.Sleep(CheckTimeSpan * 1000);
                        continue;
                    }
                    // 2009.05.12 Add <<<

					// �ύX�ē��̗L�����m�F
					status = CheckChangeInfo();

					if (status == 0)			// �X�V���L��
					{
						break;
					}
					else if (status == 4)		// �X�V��񖳂�
					{
					}
					else						// �G���[
					{
						IsSuccess = false;
						status = -99;
						break;
					}

					// �w�莞�ԑҋ@
					Thread.Sleep(CheckTimeSpan * 1000);
				}
			}
			catch (Exception)
			{
				IsSuccess = false;
				status = -99;
			}

			return status;
        }
        #endregion

        #region �ύX�ē��L���`�F�b�N����
        /// <summary>
		/// �ύX�ē��L���`�F�b�N����
		/// </summary>
		/// <returns>
		/// �`�F�b�N�X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>0:�X�V�f�[�^�L��</description></item>
		/// <item><description>4:�X�V�f�[�^����</description></item>
		/// <item><description>9:�`�F�b�N�G���[</description></item>
		/// <item><description>-99:�ُ�I��</description></item>
		/// </list>
		/// </returns>
		private static int CheckChangeInfo()
		{
			SFCMN00782AServices webService = new SFCMN00782AServices(WebServiceURL);
            
            webService.Timeout = 60000;		// TimeOut:1��

			//PgMulcasGdParaWork checkParam = new PgMulcasGdParaWork();  //Del 2008.01.07 Kouguchi
            ChangGidncParaWork changGidncParaWork = new ChangGidncParaWork();  //Add 2008.01.07 Kouguchi

            //Del ������ 2008.01.07 Kouguchi
            //checkParam.ProductCode = CompanyAuthInfo.ProductInfoWork.ProductCode;
            //checkParam.McastOfferDivCd = 0;
            //checkParam.UpdateGroupCode = new string[0];
            //checkParam.EnterpriseCode = String.Empty;
            //checkParam.MulticastSystemDivCd = -1;
            //checkParam.StdDate = Int64.Parse(String.Format("{0:yyyyMMddHHmm}", DateTime.Now));
            //checkParam.OpenDtTmDiv = IsBroadleaf(CompanyAuthInfo.EnterpriseInfoWork.EnterpriseCode) ? 1 : 2;
            //Del ������ 2008.01.07 Kouguchi

            //Add ������ 2008.01.07 Kouguchi
            changGidncParaWork.ProductCode = CompanyAuthInfo.ProductInfoWork.ProductCode;                 //�p�b�P�[�W�敪
			changGidncParaWork.McastOfferDivCd = 0;                                                       //�z�M�񋟋敪
			changGidncParaWork.UpdateGroupCode = new string[0];                                           //�X�V�O���[�v�R�[�h
			changGidncParaWork.EnterpriseCode = String.Empty;                                             //��ƃR�[�h
			changGidncParaWork.MulticastSystemDivCd = -1;                                                 //�z�M�V�X�e���敪
			changGidncParaWork.StdDate = Int64.Parse(String.Format("{0:yyyyMMddHHmm}", DateTime.Now));    //���
			changGidncParaWork.OpenDtTmDiv = IsBroadleaf(CompanyAuthInfo.EnterpriseInfoWork.EnterpriseCode) ? 1 : 2;   //���J�����敪

			changGidncParaWork.McastGidncCntntsCd = 0;                                                    //�ē��敪
            //Add ������ 2008.01.07 Kouguchi


			int status = 0;

			ExitSyncEvent.Reset();		// Web�T�[�r�X���̓v���Z�X�̏I�����s��Ȃ�
			try
			{
//TEST�p
//System.Windows.Forms.MessageBox.Show("TEST");
//TEST�p

                //status = webService.SearchNewInfo(checkParam, out PgMulcasInf, out SvrMntInfNml, out SvrMntInfEmg);  //Del 2008.01.07 Kouguchi
				status = webService.SearchNewInfo(changGidncParaWork, out ChangGidncInf1, out ChangGidncInf2, out ChangGidncInf3, out ChangGidncInf4, out ChangGidncInf5);  //Add 2008.01.07 Kouguchi  ���m�F

//TEST�p
//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//{
//    if (ChangGidncInf1 != null) System.Windows.Forms.MessageBox.Show("CG1=" + ChangGidncInf1.McastGidncCntntsCd.ToString() + " " + ChangGidncInf1.MulticastConsNo.ToString());
//    if (ChangGidncInf2 != null) System.Windows.Forms.MessageBox.Show("CG2=" + ChangGidncInf2.McastGidncCntntsCd.ToString() + " " + ChangGidncInf2.MulticastConsNo.ToString());
//    if (ChangGidncInf3 != null) System.Windows.Forms.MessageBox.Show("CG3=" + ChangGidncInf3.McastGidncCntntsCd.ToString() + " " + ChangGidncInf3.MulticastConsNo.ToString());
//    if (ChangGidncInf4 != null) System.Windows.Forms.MessageBox.Show("CG4=" + ChangGidncInf4.McastGidncCntntsCd.ToString() + " " + ChangGidncInf4.MulticastConsNo.ToString());
//    if (ChangGidncInf5 != null) System.Windows.Forms.MessageBox.Show("CG5=" + ChangGidncInf5.McastGidncCntntsCd.ToString() + " " + ChangGidncInf5.MulticastConsNo.ToString());
//}
//TEST�p

                //Add ������ 2008.01.07 Kouguchi
                string ChgWork = "0000";  //�ύX�L���t���O(0:�ύX�Ȃ�,1:�ύX����   �������� 1�Ԗ�:��۸��єz�M,2�Ԗ�:������or�ް����,3�Ԗ�:�ً}���,4�Ԗ�:�󎚈ʒu�ذ�)

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (ChangGidncInf1 != null) ChgWork = "1" + ChgWork.Substring(1, 3);
                    if (ChangGidncInf2 != null) ChgWork = ChgWork.Substring(0, 1) + "1" + ChgWork.Substring(2, 2);
                    if (ChangGidncInf3 != null) ChgWork = ChgWork.Substring(0, 1) + "1" + ChgWork.Substring(2, 2);
                    if (ChangGidncInf4 != null) ChgWork = ChgWork.Substring(0, 2) + "1" + ChgWork.Substring(3, 1);
                    if (ChangGidncInf5 != null) ChgWork = ChgWork.Substring(0, 3) + "1";
                }


                WebTopPageURL2 = "&CHG=" + ChgWork;
                //WebTopPageURL2 = "?CHG=" + ChgWork;
                //Add ������ 2008.01.07 Kouguchi


				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// �ŏI�ʒm���擾
						if (ReadLatestChangeInfoData())
						{
                            for (int i = 0; i < LatestDataArray.Length; i++)
							{
								if (LatestDataArray[i].ProductCode == CompanyAuthInfo.ProductInfoWork.ProductCode)
								{
									// �ŏI�ʒm���Ɣ�r����
									status = CompareToLatestData(i);
									break;
								}
							}

                            //Add ������ 2008.03.27 Kouguchi
                            if ((SW_ChangGidncInf2 == 1) && (SW_ChangGidncInf3 == 1))
                            {
                                WebTopPageURL2 = WebTopPageURL2.Substring(0,6) + "0" + WebTopPageURL2.Substring(7,2);
                            }
                            //Add ������ 2008.02.27 Kouguchi

						}
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						status = 4;
						break;
					default:
						TMsgDisp.Show(
							emErrorLevel.ERR_LEVEL_NODISP,
							ctPGID,
							"�ύX�ē��X�V���̎擾[Web�T�[�r�X]�Ɏ��s���܂����B",
							status,
							MessageBoxButtons.OK,
							MessageBoxDefaultButton.Button1);
						status = 9;
						break;
				}
			}
			catch (System.Net.WebException ex)
			{
				if ( ex.Message.Contains("�^�C���A�E�g") || ex.Message.Contains("�ڑ����\�������ɕ����܂���") )
				{
					// �^�C���A�E�g/�ڑ��G���[�͍X�V�f�[�^�����Ƃ��ď���
					status = 4;
				}
				else
				{
					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_NODISP,
						ctPGID,
						"�ύX�ē��X�V���擾��[Web�T�[�r�X]�ɂăG���[���������܂����B",
						-99,
						ex,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					status = -99;
				}
			}
			catch (Exception ex)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_NODISP,
					ctPGID,
					"�ύX�ē��X�V���擾��[Web�T�[�r�X]�ɂăG���[���������܂����B",
					-99,
					ex,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				status = -99;
			}
			finally
			{
				ExitSyncEvent.Set();
			}

			return status;
        }
        #endregion

        #region �T�|�[�g��ƃR�[�h���菈��
        /// <summary>
		/// �T�|�[�g��ƃR�[�h���菈��
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>T:�T�|�[�g��ƃR�[�h, F:���[�U�[��ƃR�[�h</returns>
		private static bool IsBroadleaf(string enterpriseCode)
		{
			return enterpriseCode.StartsWith("0140150842030");
        }
        #endregion

        #region �O��f�[�^��r����
        /// <summary>
		/// �O��f�[�^��r����
		/// </summary>
		/// <param name="latestDataIndex"></param>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>0:�X�V�f�[�^�L��</description></item>
		/// <item><description>4:�X�V�f�[�^����</description></item>
		/// </list>
		/// </returns>
		private static int CompareToLatestData(int latestDataIndex)
		{
			int status = 4;


			// �z�M���
			//if (PgMulcasInf != null)  //Del 2008.01.07 Kouguchi
			if (ChangGidncInf1 != null)  //Add 2008.01.07 Kouguchi
			{
				// �o�[�W����������or�Â��ꍇ�͖����ɂ���
				//if (LatestDataArray[latestDataIndex].MulticastVersion.CompareTo(PgMulcasInf.MulticastVersion) >= 0)  //Del 2008.01.07 Kouguchi
				if (LatestDataArray[latestDataIndex].MulticastVersion.CompareTo(ChangGidncInf1.McastGidncVersionCd) >= 0)  //Add 2008.01.07 Kouguchi
				{
					//PgMulcasInf = null;  //Del 2008.01.07 Kouguchi
					ChangGidncInf1 = null;  //Add 2008.01.07 Kouguchi

                    WebTopPageURL2 = WebTopPageURL2.Substring(0,5) + "0" + WebTopPageURL2.Substring(6,3);  //Add 2008.01.07 Kouguchi
                }
				else
				{
					status = 0;
				}
			}

			// ��������e���
			//if (SvrMntInfNml != null)  //Del 2008.01.07 Kouguchi
			if (ChangGidncInf2 != null)
			{
				// �A�Ԃ�����or�Â��ꍇ�͖����ɂ���
				//if (LatestDataArray[latestDataIndex].NmlServerMainteConsNo >= SvrMntInfNml.ServerMainteConsNo)  //Del 2008.01.07 Kouguchi
				if (LatestDataArray[latestDataIndex].NmlServerMainteConsNo >= ChangGidncInf2.MulticastConsNo)  //Add 2008.01.07 Kouguchi
				{
					//SvrMntInfNml = null;  //Del 2008.01.07 Kouguchi
					ChangGidncInf2 = null;  //Add 2008.01.07 Kouguchi

                    //WebTopPageURL2 = WebTopPageURL2.Substring(0,6) + "0" + WebTopPageURL2.Substring(7,2);  //Add 2008.01.07 Kouguchi  //Del 2008.03.27 Kouguchi
                    SW_ChangGidncInf2 = 1;  //Add 2008.03.27 Kouguchi
                }
				else
				{
					status = 0;
				}
			}

            //Add ������ 2008.01.07 Kouguchi
			// �f�[�^�����e���
			if (ChangGidncInf3 != null)
			{
				// �A�Ԃ�����or�Â��ꍇ�͖����ɂ���
				if (LatestDataArray[latestDataIndex].DatServerMainteConsNo >= ChangGidncInf3.MulticastConsNo) 
				{
					ChangGidncInf3 = null;

                    //WebTopPageURL2 = WebTopPageURL2.Substring(0,6) + "0" + WebTopPageURL2.Substring(7,2);  //Add 2008.01.07 Kouguchi  //Del 2008.03.27 Kouguchi
                    SW_ChangGidncInf3 = 1;  //Add 2008.03.27 Kouguchi
                }
				else
				{
					status = 0;
				}
			}
            //Add ������ 2008.01.07 Kouguchi

            // �ً}�����e���
			//if (SvrMntInfEmg != null)  //Del 2008.01.07 Kouguhci
            if (ChangGidncInf4 != null)  //Add 2008.01.07 Kouguchi
            {
                // �A�Ԃ�����or�Â��ꍇ�͖����ɂ���
                //if (LatestDataArray[latestDataIndex].EmgServerMainteConsNo >= SvrMntInfEmg.ServerMainteConsNo)  //Del 2008.01.07 Kouguchi
                if (LatestDataArray[latestDataIndex].EmgServerMainteConsNo >= ChangGidncInf4.MulticastConsNo)  //Add 2008.01.07 Kouguchi
                {
                    //SvrMntInfEmg = null;  //Del 2008.01.07 Kouguhci
                    ChangGidncInf4 = null;  //Add 2008.01.07 Kouguchi

                    WebTopPageURL2 = WebTopPageURL2.Substring(0,7) + "0" + WebTopPageURL2.Substring(8,1);  //Add 2008.01.07 Kouguchi
                }
                else
                {
                    status = 0;
                }
            }

            //Add ������ 2008.01.07 Kouguchi
			// �󎚈ʒu�����[�X���
			if (ChangGidncInf5 != null)
			{
				// �A�Ԃ�����or�Â��ꍇ�͖����ɂ���
				if (LatestDataArray[latestDataIndex].PrintPositionConsNo >= ChangGidncInf5.MulticastConsNo)
				{
					ChangGidncInf5 = null;

                    WebTopPageURL2 = WebTopPageURL2.Substring(0,8) + "0";  //Add 2008.01.07 Kouguchi
				}
				else
				{
					status = 0;
				}
			}
            //Add ������ 2008.01.07 Kouguchi

			return status;
        }
        #endregion

        #region �e�Ɩ��A�v���N��
        /// <summary>
		/// �e�Ɩ��A�v�����N�����܂�
		/// </summary>
		/// <param name="appFullPath">�Ɩ��A�v���̃t���p�X</param>
		/// <param name="param">�N���p�����[�^</param>
		private static void StartChildApplication(string appFullPath, string param)
		{
			// �N���v���O�������݃`�F�b�N
			if (System.IO.File.Exists(appFullPath) == false)
			{
				return;
			}

			// �Ɩ��A�v���ɓn���p�����[�^ 
			string paramata = string.Format("{0} {1} {2}", Program.MainArgs[0], Program.MainArgs[1], param);

			// 0:AccessTicket, 1:�|�[�g�ԍ�
			System.Diagnostics.Process process = System.Diagnostics.Process.Start(appFullPath, paramata);
        }
        #endregion

        #endregion


        #region Private Methods (Control's EventHandler)

        #region �t�H�[���\���O�C�x���g�n���h��
        /// <summary>
		/// �t�H�[���\���O�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void SFCMN00783UA_Load(object sender, EventArgs e)
		{
            // �ʒm���x���ݒ�
			this.SetInfoLabel();
            // �����\���ʒu�ݒ�
			this.SetFormLocation();
        }
        #endregion

        #region �t�H�[���\����C�x���g�n���h��
        /// <summary>
		/// �t�H�[���\����C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void SFCMN00783UA_Shown(object sender, EventArgs e)
		{
			// �^�C�}�[�ɂ��t�F�[�h�C���\�������J�n
			this.timr_OpenClose.Tag = "Open";
			this.timr_OpenClose.Enabled = true;
        }
        #endregion 

        #region �I�[�v��/�N���[�Y����^�C�}�[�C�x���g�n���h��
        /// <summary>
		/// �I�[�v��/�N���[�Y����^�C�}�[�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void timr_OpenClose_Tick(object sender, EventArgs e)
		{
			switch ((string)this.timr_OpenClose.Tag)
			{
				case "Open":
					// �t�F�[�h�C���\������
					if (this.Location.Y <= this.screenHeight - this.Size.Height)
					{
						this.TopMost = true;
						this.timr_OpenClose.Tag = "End";
					}
					else
					{
						this.Location = new Point(this.screenWidth - this.Size.Width, this.Location.Y - 3);
					}
					break;
				case "Close":
					// �t�F�[�h�A�E�g�\������
					if (this.Opacity <= 0)
					{
						this.timr_OpenClose.Enabled = false;
						this.timr_OpenClose.Tag = "WaitRoop";
						this.Hide();

						if (this.chk_ThisTimeOnly.Checked)
						{
							// ����̏���ۑ�
							WriteLatestChangeInfoData(true);
						}
						this.timr_OpenClose.Enabled = true;
					}
					else
					{
						this.Opacity = this.Opacity - 0.02;
					}
					break;
				case "WaitRoop":
					this.timr_OpenClose.Enabled = false;

					// �X�V�`�F�b�N�ҋ@����
					if (CheckChangeInfoWaitRoop(true) == 0)
					{
						this.DisplayForm();
					}
					else
					{
#if DISP_ERRDIALOG
						MessageBox.Show(
                            "PM.NS �ύX�ē��ʒm�N���C�A���g�ɂăG���[���������܂����B",
                            "PM.NS �ύX�ē��ʒm",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1);
#endif
						this.canCloseFlg = true;

						// �Ď��v���Z�X�I��
						EndProcess();
					}
					break;
				case "End":
				default:
					this.TopMost = false;
					// �^�C�}�[�I������
					this.timr_OpenClose.Enabled = false;
					this.timr_OpenClose.Tag = null;
					break;
			}
        }
        #endregion

        #region �t�H�[���I���O�C�x���g�n���h��
        /// <summary>
		/// �t�H�[���I���O�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void SFCMN00783UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.canCloseFlg)
			{
				if (e.CloseReason == CloseReason.UserClosing)
				{
					e.Cancel = true;
				}

				this.timr_OpenClose.Tag = "Close";
				this.timr_OpenClose.Enabled = true;
			}
        }
        #endregion

        #region �ύX���e�ʒm���x���N���b�N�C�x���g�n���h��
        /// <summary>
		/// �ύX���e�ʒm���x���N���b�N�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�����I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void lbl_Info_Click(object sender, EventArgs e)
		{
			//StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", WebTopPageURL));  //Del 2008.01.07 Kouguchi

            // 2008.11.20 Update >>>
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", WebTopPageURL + "SFCMN00771W.aspx?TICKET=" + CompanyAuthInfo.AccessTicket.ToString() + WebTopPageURL2.ToString()));  //Add 2008.01.07 Kouguchi
            StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:1 /Lmt:2 /Mhf:1 /BrwsTyp:1 /Prdct:2 {0}", WebTopPageURL + "SFCMN00771W.aspx?TICKET=" + CompanyAuthInfo.AccessTicket.ToString() + WebTopPageURL2.ToString())); 
            // 2008.11.20 Update <<<

            //Test�p (NsBrowser �̃A�h���X��\������)
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:0 /Mhf:1 /BrwsTyp:1 {0}", WebTopPageURL + "SFCMN00771W.aspx?TICKET=" + CompanyAuthInfo.AccessTicket.ToString() + WebTopPageURL2.ToString()));

            ////StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", WebTopPageURL + WebTopPageURL2.ToString()));  //Add 2008.01.07 Kouguchi
        }
        #endregion

        #endregion


        #region Private Methods

        #region �t�H�[����\�����郁�\�b�h
        /// <summary>
		/// �t�H�[����\�����郁�\�b�h
		/// </summary>
		private void DisplayForm()
		{
			// ��ʂ�\��
			this.Show();

			// �ʒm���x���ݒ�
			this.SetInfoLabel();

			// �t�H�[���ʒu�ݒ�
			this.SetFormLocation();

			// �����x���A
			this.Opacity = 1.0f;

			// 2007.09.19 Chg T.Sugawa @�`�F�b�N�{�b�N�X�̓f�t�H���gOFF�Ɏd�l�ύX
			//// �`�F�b�N�{�b�N�XON
			//this.chk_ThisTimeOnly.Checked = true;
			// �`�F�b�N�{�b�N�XOFF
			this.chk_ThisTimeOnly.Checked = false;

			this.timr_OpenClose.Tag = "Open";
			this.timr_OpenClose.Enabled = true;
        }
        #endregion 

        #region �t�H�[�������ʒu�ݒ菈��
        /// <summary>
		/// �t�H�[�������ʒu�ݒ菈��
		/// </summary>
		private void SetFormLocation()
		{
			//�t�H�[���̈ʒu����
			this.screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
			this.screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

			this.Location = new Point(this.screenWidth, this.screenHeight);
        }
        #endregion

        #region �ʒm���x���ݒ菈��
        /// <summary>
		/// �ʒm���x���ݒ菈��
		/// </summary>
		private void SetInfoLabel()
		{
			List<Label> infoLabels = new List<Label>();

			// �ً}�����e���
			//if (SvrMntInfEmg != null)  //Del 2008.01.07 Kouguchi
			if (ChangGidncInf4 != null)  //Add 2008.01.07 Kouguchi
			{
				this.lbl_Info01.Visible = true;
				infoLabels.Add(this.lbl_Info01);
			}
			else
			{
				this.lbl_Info01.Visible = false;
			}

            //Del ������ 2008.01.07 Kouguchi
            //// �z�M���
            //if (PgMulcasInf != null)
            //{
            //    this.lbl_Info02.Visible = true;
            //    infoLabels.Add(this.lbl_Info02);
            //}
            //else
            //{
            //    this.lbl_Info02.Visible = false;
            //}
            //// ��������e���
            //if (SvrMntInfNml != null)
            //{
            //    this.lbl_Info03.Visible = true;
            //    infoLabels.Add(this.lbl_Info03);
            //}
            //else
            //{
            //    this.lbl_Info03.Visible = false;
            //}
            //Del ������ 2008.01.07 Kouguchi

            //Add ������ 2008.01.07 Kouguchi
            // �z�M���E��������e���E�T�[�o�[�����e���E�󎚈ʒu�����[�X���
			if ( (ChangGidncInf1 != null) || (ChangGidncInf2 != null) || (ChangGidncInf3 != null)  || (ChangGidncInf5 != null))
			{
				this.lbl_Info02.Visible = true;
				infoLabels.Add(this.lbl_Info02);
			}
			else
			{
				this.lbl_Info02.Visible = false;
			}

    		this.lbl_Info03.Visible = false;
            //Add ������ 2008.01.07 Kouguchi


			// ���x���ʒu/�t�H�[���T�C�Y�ݒ�
			switch (infoLabels.Count)
			{
				case 1:
					this.Height = 140;
					infoLabels[0].Location = new Point(40, 20);
					break;
				case 2:
					this.Height = 140;
					infoLabels[0].Location = new Point(40, 10);
					infoLabels[1].Location = new Point(40, 35);
					break;
				case 3:
					this.Height = 170;
					infoLabels[0].Location = new Point(40, 10);
					infoLabels[1].Location = new Point(40, 35);
					infoLabels[2].Location = new Point(40, 60);
					break;
			}
        }
        #endregion

        // 2008.11.20 Add >>>
        #region �F�؏����Infomation��URL�擾
        /// <summary>
        /// �F�؏����Infomation��URL�擾
        /// </summary>
        /// <returns></returns>
        private static string GetWebTopPageURLFromPMC()
        {
            string webTopPageURL = string.Empty;
            webTopPageURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.IndexCode_Infomation);	// �X�V�`�F�b�NWeb�T�[�r�XURL
            webTopPageURL += LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Infomation, ConstantManagement_SF_PRO.IndexCode_Infomation);

            return webTopPageURL;
        }
        #endregion
        // 2008.11.20 Add <<<

        // 2009.05.12 Add >>>
        #region ���W�X�g���ł̏������s�`�F�b�N
        /// <summary>
        /// �����𑱍s���邩�`�F�b�N
        /// </summary>
        /// <returns>True:�������s�AFalse:�����I��</returns>
        private static bool CheckContinueProcess()
        {
            bool ret = false;
            RegistryKey key = null;
            try
            {
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman", false);

                if (key == null)
                {
                    return false;
                }

                object objValue = key.GetValue("Information", null);

                if (objValue != null && objValue is Int32)
                {
                    if ((Int32)objValue == 1)
                    {
                        ret = true;
                    }
                }
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
            return ret;
        }
        #endregion
        // 2009.05.12 Add <<<

        #endregion


    }

}

