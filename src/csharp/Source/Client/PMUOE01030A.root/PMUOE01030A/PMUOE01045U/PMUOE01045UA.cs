//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M�p�_�C�A���O�N���X
// �v���O�����T�v   : �t�n�d����M�p�_�C�A���O�N���X������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : ����
// �� �� ��  2010/05/07  �C�����e : PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : 杍^
// �� �� ��  2013/08/15  �C�����e : ��������(����)�����̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �t�n�d����M�p�_�C�A���O�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �t�n�d����M�p�_�C�A���O��\�����܂��B</br>
	/// <br>Programmer : 96186 ���� �T��</br>
	/// <br>Date       : 2008.06.19</br>
	/// <br></br>
	/// <br>UpdateNote : </br>
    /// <br>UpDate</br>
    /// <br>2010/05/07 ���� PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
	/// </remarks>
	public class UoeSndRcvDialog : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Timer Close_Timer;
        private System.Windows.Forms.Panel Container1_Panel;
        private PictureBox pictLogo1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_SndRcvStatus;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Connect;
        private Timer Open_Timer;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_GUIDE01;
		private System.ComponentModel.IContainer components;

        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new UoeSndRcvDialog());
        }
        /// <summary>
        /// �t�n�d����M�p�_�C�A���O�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �t�n�d����M�p�_�C�A���O�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 96186 ���� �T��</br>
		/// <br>Date       : 2005.06.19</br>
		/// </remarks>
		public UoeSndRcvDialog()
		{
			InitializeComponent();

            this._uoeSndRcvAcs = new UoeSndRcvAcs();

            this._uoeSndRcvAcs._msg_psfclr += new UoeSndRcvAcs.msg_psfclrEventHandler(this.msg_psfclr);
            this._uoeSndRcvAcs._msg_pssput += new UoeSndRcvAcs.msg_pssputEventHandler(this.msg_pssput);

            // ---- ADD 2013/08/15 杍^ ---- >>>>>
            //OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---- ADD 2013/08/15 杍^ ---- <<<<<
		}
        /// <summary>
        /// �C���X�^���X�擾����
        /// </summary>
        /// <returns></returns>
        public static UoeSndRcvDialog GetInstance()
        {
            if (_uoeSndRcvDialog == null)
            {
                _uoeSndRcvDialog = new UoeSndRcvDialog();
            }
            return _uoeSndRcvDialog;
        }
        # endregion

        # region �g�p����Ă��郊�\�[�X�㏈��
        /// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
        }
        # endregion

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UoeSndRcvDialog));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            this.Close_Timer = new System.Windows.Forms.Timer(this.components);
            this.Container1_Panel = new System.Windows.Forms.Panel();
            this.ultraLabel_SndRcvStatus = new Infragistics.Win.Misc.UltraLabel();
            this.pictLogo1 = new System.Windows.Forms.PictureBox();
            this.ultraLabel_Connect = new Infragistics.Win.Misc.UltraLabel();
            this.Open_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraLabel_GUIDE01 = new Infragistics.Win.Misc.UltraLabel();
            this.Container1_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo1)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_Timer
            // 
            this.Close_Timer.Interval = 1;
            this.Close_Timer.Tick += new System.EventHandler(this.Close_Timer_Tick);
            // 
            // Container1_Panel
            // 
            this.Container1_Panel.BackColor = System.Drawing.Color.White;
            this.Container1_Panel.Controls.Add(this.ultraLabel_SndRcvStatus);
            this.Container1_Panel.Controls.Add(this.pictLogo1);
            this.Container1_Panel.Location = new System.Drawing.Point(4, 24);
            this.Container1_Panel.Name = "Container1_Panel";
            this.Container1_Panel.Size = new System.Drawing.Size(315, 61);
            this.Container1_Panel.TabIndex = 8;
            // 
            // ultraLabel_SndRcvStatus
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel_SndRcvStatus.Appearance = appearance2;
            this.ultraLabel_SndRcvStatus.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_SndRcvStatus.Location = new System.Drawing.Point(62, 9);
            this.ultraLabel_SndRcvStatus.Name = "ultraLabel_SndRcvStatus";
            this.ultraLabel_SndRcvStatus.Size = new System.Drawing.Size(246, 24);
            this.ultraLabel_SndRcvStatus.TabIndex = 1403;
            // 
            // pictLogo1
            // 
            this.pictLogo1.Image = ((System.Drawing.Image)(resources.GetObject("pictLogo1.Image")));
            this.pictLogo1.Location = new System.Drawing.Point(6, 6);
            this.pictLogo1.Name = "pictLogo1";
            this.pictLogo1.Size = new System.Drawing.Size(50, 50);
            this.pictLogo1.TabIndex = 12;
            this.pictLogo1.TabStop = false;
            // 
            // ultraLabel_Connect
            // 
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel_Connect.Appearance = appearance1;
            this.ultraLabel_Connect.AutoSize = true;
            this.ultraLabel_Connect.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Connect.Location = new System.Drawing.Point(6, 3);
            this.ultraLabel_Connect.Name = "ultraLabel_Connect";
            this.ultraLabel_Connect.Size = new System.Drawing.Size(60, 17);
            this.ultraLabel_Connect.TabIndex = 1402;
            this.ultraLabel_Connect.Text = "�ڑ���F";
            // 
            // Open_Timer
            // 
            this.Open_Timer.Interval = 1;
            this.Open_Timer.Tick += new System.EventHandler(this.Open_Timer_Tick);
            // 
            // ultraLabel_GUIDE01
            // 
            appearance97.ForeColorDisabled = System.Drawing.Color.Black;
            appearance97.TextVAlignAsString = "Middle";
            this.ultraLabel_GUIDE01.Appearance = appearance97;
            this.ultraLabel_GUIDE01.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_GUIDE01.Location = new System.Drawing.Point(6, 87);
            this.ultraLabel_GUIDE01.Name = "ultraLabel_GUIDE01";
            this.ultraLabel_GUIDE01.Size = new System.Drawing.Size(313, 24);
            this.ultraLabel_GUIDE01.TabIndex = 1404;
            // 
            // UoeSndRcvDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(324, 113);
            this.ControlBox = false;
            this.Controls.Add(this.ultraLabel_GUIDE01);
            this.Controls.Add(this.ultraLabel_Connect);
            this.Controls.Add(this.Container1_Panel);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UoeSndRcvDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UOE����M����";
            this.Shown += new System.EventHandler(this.UoeSndRcvDialog_Shown);
            this.Container1_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        // ===================================================================================== //
        // �萔�Q
        // ===================================================================================== //
        #region Private Const Member
        private const int DEFAULT_CLIENT_WIDTH = 256;
        private const int    DEFAULT_CLIENT_HEIGHT = 135;  
		private const int    DEFAULT_TIME   = 2;

        // ---- ADD 2013/08/15 杍^ --- >>>>>
        //���b�Z�[�W�Z�b�g�֌W
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ���񋓑�
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>�������[�U</summary>
            OFF = 0,
            /// <summary>�L�����[�U</summary>
            ON = 1,
        }
        #endregion

        /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
        private int _opt_FuTaBa;//OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj

        //��pUSB�p
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- ADD 2013/08/15 杍^ --- <<<<<

        # region ���b�Z�[�W���t�h�ɕ\������t�B�[���h����
        private const int P_HED = 0;
        private const int P_MSG = 1;
        private const int P_GUIDE01 = 2;
        # endregion

        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
        //�_�C�A���O�C���X�^���X
        private static UoeSndRcvDialog _uoeSndRcvDialog = null;

        //�t�n�d����M�����A�N�Z�X�N���X
        private UoeSndRcvAcs _uoeSndRcvAcs = null;

		//�t�n�d���M�w�b�_�[�N���X
		private UoeSndHed _uoeSndHed = null;

		//�t�n�d��M�w�b�_�[�N���X
		private UoeRecHed _uoeRecHed = null;

        //�d����M���[�h true:�d����M���� false:�ʏ폈��
        private bool _processStockSlipDtRecvDiv = false;

        //�G���[�X�e�[�^�X
        private int _status = 0;

        //�G���[���b�Z�[�W
        private string _message = "";
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        # region �ڑ���Text
        /// <summary>
        /// �ڑ���Text
        /// </summary>
        public string ultraLabel_Connect_Text
        {
            get
            {
                return this.ultraLabel_Connect.Text;
            }
            set
            {
                this.ultraLabel_Connect.Text = value;
            }
        }
        # endregion

        # region ����M���Text
        /// <summary>
        /// ����M���Text
        /// </summary>
        public string ultraLabel_SndRcvStatus_Text
        {
            get
            {
                return this.ultraLabel_SndRcvStatus.Text;
            }
            set
            {
                this.ultraLabel_SndRcvStatus.Text = value;
            }
        }
        # endregion

        # region ����M���Text
        /// <summary>
        /// ����M���Text
        /// </summary>
        public string ultraLabel_GUIDE01_Text
        {
            get
            {
                return this.ultraLabel_GUIDE01.Text;
            }
            set
            {
                this.ultraLabel_GUIDE01.Text = value;
            }
        }
        # endregion

        # endregion

        /// <summary>
        /// �_�C�A���O�\������
        /// </summary>
        /// <param name="uoeSndHed">�t�n�d���M�I�u�W�F�N�g</param>
        /// <param name="uoeRecHed">�t�n�d��M�I�u�W�F�N�g</param>
        /// <param name="processStockSlipDtRecvDiv">�d����M���[�h true:�d����M���� false:�ʏ폈��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Update Note : 2010/05/07 ����</br>
        /// <br>              PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// </remarks>
        public int ShowDialog(UoeSndHed uoeSndHed, out UoeRecHed uoeRecHed, bool processStockSlipDtRecvDiv, out string message)
		{
            uoeRecHed = null;
            message = "";

            try
            {
                //��ʂ̏�����
                ultraLabel_Connect_Text = "�ڑ���F";
                ultraLabel_SndRcvStatus_Text = "";
                ultraLabel_GUIDE01_Text = "";

                // ---ADD 2010/05/07 ------------------>>>>>
                // �D��UOE Web�p�̕\��
                if (UoeSndRcvAcs.IsOtherMakerUOEWeb(uoeSndHed.CommAssemblyId))
                {
                    ultraLabel_Connect_Text += GetWebServerName(uoeSndHed.CommAssemblyId, uoeSndHed);
                    ultraLabel_SndRcvStatus_Text = "�ʐM���ł��B���΂炭���҂��������B";
                }
                // ---ADD 2010/05/07 ------------------<<<<<

                //�ϐ��̏�����
                _processStockSlipDtRecvDiv = processStockSlipDtRecvDiv;
                _uoeSndHed = uoeSndHed;
                _uoeRecHed = null;
                _status = 0;
                _message = "";

                //this.ShowDialog(); // DEL 2013/08/15 杍^

                // ---- ADD 2013/08/15 杍^ --- >>>
                //�t�^�oUSB��p:Option.ON
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    //���b�Z�[�W���擾
                    msgShowSolt = System.Threading.Thread.GetNamedDataSlot(MSGSHOWSOLT);
                    //���b�Z�[�W���Ȃ��ꍇ�A�����̏����A���̏ꍇ�͔�������(����)����
                    if (System.Threading.Thread.GetData(msgShowSolt) == null
                        || (System.Threading.Thread.GetData(msgShowSolt) != null && (Int32)System.Threading.Thread.GetData(msgShowSolt) == 4)
                        || (System.Threading.Thread.GetData(msgShowSolt) != null && (Int32)System.Threading.Thread.GetData(msgShowSolt) == 2))
                    {
                        this.ShowDialog();
                    }
                    else
                    {
                        //��������(����)����
                        this.AutoSndRcv();
                    }
                    
                }
                else
                {
                    this.ShowDialog();
                }
                // ---- ADD 2013/08/15 杍^ --- <<<

                uoeRecHed = _uoeRecHed;
                message = _message;
            }
            catch (Exception ex)
            {
                uoeRecHed = null;
                _status = -1;
                _message = ex.Message;
                message = ex.Message;
                CloseDialog();
            }
            return (_status);
		}

        /// <summary>
        /// ��ʃN���[�Y����
        /// </summary>
        public void CloseDialog()
        {
            this.Close();
        }

        /// <summary>
        /// Timer.Tick �C�x���g(Open_Timer_Tick)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Open_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Open_Timer.Enabled = false;

                //�t�n�d���M�ҏW�A�N�Z�X�N���X
                if (_uoeSndRcvAcs == null)
                {
                    _uoeSndRcvAcs = new UoeSndRcvAcs();
                }
                //�t�n�d����M����
                _uoeRecHed = new UoeRecHed();
                _status = _uoeSndRcvAcs.UoeSndRcv(
                                                _uoeSndHed,
                                            out _uoeRecHed,
                                            _processStockSlipDtRecvDiv,
                                            out _message);
                CloseTimerSetting(2);
            }
            catch (Exception ex)
            {
                _uoeRecHed = null;
                _status = -1;
                _message = ex.Message;
                CloseDialog();
            }
        }
        // ---- ADD 2013/08/15 杍^ --- >>>>>
        /// <summary>
        /// ��������(����)�����̒ǉ�
        /// </summary>
        private void AutoSndRcv()
        {
            try
            {
                //�t�n�d���M�ҏW�A�N�Z�X�N���X
                if (_uoeSndRcvAcs == null)
                {
                    _uoeSndRcvAcs = new UoeSndRcvAcs();
                }

                //�t�n�d����M����
                _uoeRecHed = new UoeRecHed();
                _status = _uoeSndRcvAcs.UoeSndRcv(
                                                _uoeSndHed,
                                            out _uoeRecHed,
                                            _processStockSlipDtRecvDiv,
                                            out _message);
            }
            catch (Exception ex)
            {
                _uoeRecHed = null;
                _status = -1;
                _message = ex.Message;
            }
        }
        // ---- ADD 2013/08/15 杍^ --- <<<<<

        /// <summary>
        /// Timer.Tick �C�x���g(Close_Timer_Tick)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Close_Timer_Tick(object sender, System.EventArgs e)
		{
            this.Close_Timer.Enabled = false;
            CloseDialog();
		}

        /// <summary>
        /// �J�n�^�C�}�[���䏈��
        /// </summary>
        /// <param name="displayTime">���ԁi�b�P�ʁj</param>
        private void OpenTimerSetting(int displayTime)
        {
            if (displayTime == 0)
            {
                this.Open_Timer.Interval = DEFAULT_TIME * 1000;
            }
            else
            {
                this.Open_Timer.Interval = displayTime * 1000;
            }
            this.Open_Timer.Enabled = true;
        }

        /// <summary>
        /// �I���^�C�}�[���䏈��
        /// </summary>
        /// <param name="displayTime">���ԁi�b�P�ʁj</param>
        private void CloseTimerSetting(int displayTime)
		{
			if (displayTime == 0)
			{
				this.Close_Timer.Interval = DEFAULT_TIME * 1000;
			}
			else
			{
				this.Close_Timer.Interval = displayTime * 1000;
			}
			this.Close_Timer.Enabled = true;
		}

        /// <summary>
        /// �t�H�[���\���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void UoeSndRcvDialog_Shown(object sender, EventArgs e)
        {
            this.OpenTimerSetting(1);
        }

        # region ���b�Z�[�W�N���A
        /// <summary>
        /// ���b�Z�[�W�N���A
        /// </summary>
        /// <param name="fld">�N���A�t�B�[���h</param>
        void msg_psfclr(int fld)
        {
            switch (fld)
            {
                case P_HED:
                    this.ultraLabel_Connect_Text = "�ڑ���F";
                    break;
                case P_MSG:
                    ultraLabel_SndRcvStatus_Text = "";
                    break;
                case P_GUIDE01:
                    ultraLabel_GUIDE01_Text = "";
                    break;
            }
        }
        # endregion

        # region ���b�Z�[�W�\��
        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="fld">�\���t�B�[���h</param>
        /// <param name="text">�\���e�L�X�g</param>
        void msg_pssput(int fld, string text)
        {
            switch (fld)
            {
                case P_HED:
                    this.ultraLabel_Connect_Text = "�ڑ���F" + text;
                    break;
                case P_MSG:
                    ultraLabel_SndRcvStatus_Text = text;
                    break;
                case P_GUIDE01:
                    ultraLabel_GUIDE01_Text = text;
                    break;
            }
        }
        # endregion

        // ---ADD 2010/05/07 ------------------>>>>>
        /// <summary>
        /// Web�T�[�o�̖��̂��擾���܂��B
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <param name="uoeSndHed">�������</param>
        /// <returns>
        /// <c>EnumUoeConst.ctCommAssemblyId_1004</c>�̏ꍇ�A�����Y�Ƃ�Ԃ��܂��B
        /// (�Y���Ȃ��̏ꍇ�A<c>string.Empty</c>��Ԃ��܂�)
        /// </returns>
        public static string GetWebServerName(string commAssemblyId, UoeSndHed uoeSndHed)
        {

			

            switch (commAssemblyId)
            {
                case EnumUoeConst.ctCommAssemblyId_1004:
                    return "�����Y��";
                case EnumUoeConst.ctCommAssemblyId_1003:
                    //������}�X�^�̎擾
                    UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = new UoeSndRcvJnlAcs();

                    UOESupplier _supplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uoeSndHed.UOESupplierCd);
                    if (_supplier != null)
                    {
                        return _supplier.UOESupplierName;
                    }
                    else
                    {
                        return string.Empty;
                    }
                default:
                    return string.Empty;
            }
        }
        // ---ADD 2010/05/07 ------------------<<<<<
	}
}
