//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���[�J�[�ݒ�}�X�^
// �v���O�����T�v   : ���[�J�[�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2008/06/11  �C�����e : PM.NS�Ή�
//                                : �񋟂c�a�i���i���[�J�[���̃}�X�^�j�̃f�[�^�͎Q�Ƃ݂̂ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30462 �s�V �m��
// �� �� ��  2008/10/07  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/12  �C�����e : MANTIS�y13467�z���[�J�[���̂̍폜
//----------------------------------------------------------------------------//

# region ��using
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���[�J�[�}�X�^ �t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: ���[�J�[�}�X�^���̐ݒ���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer	: 96186 ���ԗT��</br>
	/// <br>Date		: 2007.08.01</br>
    /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
    /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
    /// <br>           : 2008.06.11 30413 ����</br>
    /// <br>           : PM.NS�Ή�</br>
    /// <br>           : �񋟂c�a�i���i���[�J�[���̃}�X�^�j�̃f�[�^�͎Q�Ƃ݂̂ɕύX</br>
    /// <br>UpdateNote   : 2008/10/07 30462 �s�V �m���@�o�O�C��</br>
    /// </remarks>
    public class MAKHN09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region ��Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private System.Windows.Forms.Timer Initial_Timer;
        private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.TImeControl tImeControl1;
        private Infragistics.Win.Misc.UltraLabel Guid_Label;
        private TEdit MakerNameRF_tEdit;
        private Infragistics.Win.Misc.UltraLabel MakerName_Title_Label;
		private Infragistics.Win.Misc.UltraLabel GoodsMakerCd_Title_Label;
        private TEdit MakerKanaNameRF_tEdit;
        private Infragistics.Win.Misc.UltraLabel MakerKanaName_Title_Label;
		private Infragistics.Win.Misc.UltraLabel DisplayOrder_Title_Label;
		private Infragistics.Win.Misc.UltraLabel Division_Label;
		private TNedit GoodsMakerCdRF_tNedit;
		private TNedit DisplayOrderRF_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.Misc.UltraLabel DivisionName_Label;
		private UiSetControl uiSetControl1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region ��Constructor
		/// <summary>
        /// ���[�J�[�}�X�^ �t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.08.01</br>
		/// </remarks>
        public MAKHN09110UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// �f�t�H���g:true�Œ�
            // 2007.03.28  S.Koga  amend --------------------------------------------------
			//this._defaultAutoFillToColumn = false;
            this._defaultAutoFillToColumn = true;
            // ----------------------------------------------------------------------------
            this._canSpecificationSearch = false;

			//�@��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �ϐ�������
			this._dataIndex = -1;
			this._secInfoAcs = new SecInfoAcs();
			this._makerUAcs = new MakerAcs();
            //this._userGuideAcs = new UserGuideAcs();  // iitani d 2007.05.18
			 
			this._prevmakerU = null;
#if False
			this._nextData = false;
#endif
			this._totalCount = 0;
            this._makerUTable = new Hashtable();

			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			// ���_OP�̔���
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
		}
		# endregion

		# region ��Dispose
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

		#region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKHN09110UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.MakerNameRF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MakerKanaNameRF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MakerName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MakerKanaName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DisplayOrder_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Division_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsMakerCdRF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DisplayOrderRF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.DivisionName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerNameRF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerKanaNameRF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCdRF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayOrderRF_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(448, 267);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 4;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 314);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(722, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(604, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(320, 267);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 2;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(448, 267);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 3;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(579, 267);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = this.MakerNameRF_tEdit;
            this.tImeControl1.OutControl = this.MakerKanaNameRF_tEdit;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 30;
            // 
            // MakerNameRF_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerNameRF_tEdit.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerNameRF_tEdit.Appearance = appearance15;
            this.MakerNameRF_tEdit.AutoSelect = true;
            this.MakerNameRF_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MakerNameRF_tEdit.DataText = "";
            this.MakerNameRF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MakerNameRF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.MakerNameRF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.MakerNameRF_tEdit.Location = new System.Drawing.Point(208, 145);
            this.MakerNameRF_tEdit.MaxLength = 30;
            this.MakerNameRF_tEdit.Name = "MakerNameRF_tEdit";
            this.MakerNameRF_tEdit.Size = new System.Drawing.Size(484, 24);
            this.MakerNameRF_tEdit.TabIndex = 60;
            this.MakerNameRF_tEdit.ValueChanged += new System.EventHandler(this.MakerNameRF_tEdit_ValueChanged);
            // 
            // MakerKanaNameRF_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerKanaNameRF_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerKanaNameRF_tEdit.Appearance = appearance8;
            this.MakerKanaNameRF_tEdit.AutoSelect = true;
            this.MakerKanaNameRF_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MakerKanaNameRF_tEdit.DataText = "";
            this.MakerKanaNameRF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MakerKanaNameRF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, true, true, false, true));
            this.MakerKanaNameRF_tEdit.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.MakerKanaNameRF_tEdit.Location = new System.Drawing.Point(208, 185);
            this.MakerKanaNameRF_tEdit.MaxLength = 20;
            this.MakerKanaNameRF_tEdit.Name = "MakerKanaNameRF_tEdit";
            this.MakerKanaNameRF_tEdit.Size = new System.Drawing.Size(175, 24);
            this.MakerKanaNameRF_tEdit.TabIndex = 61;
            this.MakerKanaNameRF_tEdit.ValueChanged += new System.EventHandler(this.MakerKanaNameRF_tEdit_ValueChanged);
            // 
            // GoodsMakerCd_Title_Label
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.GoodsMakerCd_Title_Label.Appearance = appearance17;
            this.GoodsMakerCd_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.GoodsMakerCd_Title_Label.Location = new System.Drawing.Point(23, 105);
            this.GoodsMakerCd_Title_Label.Name = "GoodsMakerCd_Title_Label";
            this.GoodsMakerCd_Title_Label.Size = new System.Drawing.Size(191, 24);
            this.GoodsMakerCd_Title_Label.TabIndex = 10;
            this.GoodsMakerCd_Title_Label.Text = "���[�J�[�R�[�h";
            // 
            // MakerName_Title_Label
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.MakerName_Title_Label.Appearance = appearance16;
            this.MakerName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MakerName_Title_Label.Location = new System.Drawing.Point(23, 145);
            this.MakerName_Title_Label.Name = "MakerName_Title_Label";
            this.MakerName_Title_Label.Size = new System.Drawing.Size(191, 24);
            this.MakerName_Title_Label.TabIndex = 11;
            this.MakerName_Title_Label.Text = "���[�J�[��";
            // 
            // Guid_Label
            // 
            this.Guid_Label.Location = new System.Drawing.Point(208, 52);
            this.Guid_Label.Name = "Guid_Label";
            this.Guid_Label.Size = new System.Drawing.Size(240, 25);
            this.Guid_Label.TabIndex = 46;
            this.Guid_Label.Visible = false;
            // 
            // MakerKanaName_Title_Label
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.MakerKanaName_Title_Label.Appearance = appearance11;
            this.MakerKanaName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MakerKanaName_Title_Label.Location = new System.Drawing.Point(23, 185);
            this.MakerKanaName_Title_Label.Name = "MakerKanaName_Title_Label";
            this.MakerKanaName_Title_Label.Size = new System.Drawing.Size(191, 24);
            this.MakerKanaName_Title_Label.TabIndex = 61;
            this.MakerKanaName_Title_Label.Text = "���[�J�[��(��)";
            // 
            // DisplayOrder_Title_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.DisplayOrder_Title_Label.Appearance = appearance6;
            this.DisplayOrder_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DisplayOrder_Title_Label.Location = new System.Drawing.Point(23, 226);
            this.DisplayOrder_Title_Label.Name = "DisplayOrder_Title_Label";
            this.DisplayOrder_Title_Label.Size = new System.Drawing.Size(191, 24);
            this.DisplayOrder_Title_Label.TabIndex = 64;
            this.DisplayOrder_Title_Label.Text = "�\������";
            // 
            // Division_Label
            // 
            this.Division_Label.Location = new System.Drawing.Point(393, 55);
            this.Division_Label.Name = "Division_Label";
            this.Division_Label.Size = new System.Drawing.Size(240, 25);
            this.Division_Label.TabIndex = 66;
            this.Division_Label.Visible = false;
            // 
            // GoodsMakerCdRF_tNedit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.GoodsMakerCdRF_tNedit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.GoodsMakerCdRF_tNedit.Appearance = appearance5;
            this.GoodsMakerCdRF_tNedit.AutoSelect = true;
            this.GoodsMakerCdRF_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GoodsMakerCdRF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GoodsMakerCdRF_tNedit.DataText = "";
            this.GoodsMakerCdRF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsMakerCdRF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GoodsMakerCdRF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GoodsMakerCdRF_tNedit.Location = new System.Drawing.Point(208, 104);
            this.GoodsMakerCdRF_tNedit.MaxLength = 4;
            this.GoodsMakerCdRF_tNedit.Name = "GoodsMakerCdRF_tNedit";
            this.GoodsMakerCdRF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GoodsMakerCdRF_tNedit.Size = new System.Drawing.Size(51, 24);
            this.GoodsMakerCdRF_tNedit.TabIndex = 59;
            // 
            // DisplayOrderRF_tNedit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.DisplayOrderRF_tNedit.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.DisplayOrderRF_tNedit.Appearance = appearance3;
            this.DisplayOrderRF_tNedit.AutoSelect = true;
            this.DisplayOrderRF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DisplayOrderRF_tNedit.DataText = "";
            this.DisplayOrderRF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DisplayOrderRF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.DisplayOrderRF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DisplayOrderRF_tNedit.Location = new System.Drawing.Point(208, 226);
            this.DisplayOrderRF_tNedit.MaxLength = 3;
            this.DisplayOrderRF_tNedit.Name = "DisplayOrderRF_tNedit";
            this.DisplayOrderRF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DisplayOrderRF_tNedit.Size = new System.Drawing.Size(35, 24);
            this.DisplayOrderRF_tNedit.TabIndex = 65;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(23, 90);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(681, 3);
            this.ultraLabel15.TabIndex = 121;
            // 
            // DivisionName_Label
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.Yellow;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.DivisionName_Label.Appearance = appearance1;
            this.DivisionName_Label.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.DivisionName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.DivisionName_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DivisionName_Label.Location = new System.Drawing.Point(23, 53);
            this.DivisionName_Label.Name = "DivisionName_Label";
            this.DivisionName_Label.Size = new System.Drawing.Size(172, 24);
            this.DivisionName_Label.TabIndex = 2297;
            this.DivisionName_Label.Text = "���[�U�[�f�[�^";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // MAKHN09110UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(722, 337);
            this.Controls.Add(this.DivisionName_Label);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.DisplayOrderRF_tNedit);
            this.Controls.Add(this.GoodsMakerCdRF_tNedit);
            this.Controls.Add(this.Division_Label);
            this.Controls.Add(this.DisplayOrder_Title_Label);
            this.Controls.Add(this.MakerKanaNameRF_tEdit);
            this.Controls.Add(this.MakerKanaName_Title_Label);
            this.Controls.Add(this.Guid_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.MakerNameRF_tEdit);
            this.Controls.Add(this.MakerName_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.GoodsMakerCd_Title_Label);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKHN09110UA";
            this.Text = "���[�J�[�}�X�^";
            this.Load += new System.EventHandler(this.MAKHN09110UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKHN09110UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKHN09110UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerNameRF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerKanaNameRF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCdRF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayOrderRF_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ��IMasterMaintenanceArrayType�����o�[

		# region ��Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ��Properties
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
			}
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose;
			}
			set
			{
				this._canClose = value;
			}
		}

		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get
			{
				return this._dataIndex;
			}
			set
			{
				this._dataIndex = value;
			}
		}

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{
				return this._defaultAutoFillToColumn;
			}
		}
		# endregion

		# region ��Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.08.01</br>
		/// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = MAKERU_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList makerUMntretList = null;


            if (readCount == 0)
			{
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._makerUAcs.SearchAll(
                            out makerUMntretList,
                            this._enterpriseCode);

                this._totalCount = makerUMntretList.Count;
			}
            else
            {
#if False
				 
				status = this._makerUAcs.SearchAll(
                            out makerUMntretList,
                            out this._totalCount,
                            out this._nextData,
                            this._enterpriseCode,
                            readCount,
                            this._prevmakerU);
#endif
			}

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ŏI�̃��[�J�[�}�X�^�I�u�W�F�N�g��ޔ�����
                        this._prevmakerU = ((MakerUMnt)makerUMntretList[makerUMntretList.Count - 1]).Clone();

                        int index = 0;
                        foreach (MakerUMnt lgoodsgranre in makerUMntretList)
                        {
                            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                            //if (this._makerUTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
                            if (this._makerUTable.ContainsKey(CreateHashKey(lgoodsgranre)) == false)
                            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                            {
                                MakerUMntToDataSet(lgoodsgranre.Clone(), index);
                                ++index;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Search",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._makerUAcs,				  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        break;
                    }
            }

            totalCount = this._totalCount;

            // iitani ���f�[�^
            //makerUMntretList = new ArrayList();
            //MakerUMnt LG1 = new MakerUMnt();
            //LG1.EnterpriseCode = this._enterpriseCode;
            //LG1.LargeGoodsGanreCode = 1;
            //LG1.LargeGoodsGanreName = "��";
            //LG1.CreateDateTime = DateTime.Now.Date.Ticks;
            //LG1.UpdateDateTime = DateTime.Now.Date.Ticks;
            //Guid guid1 = new Guid("{28732AC1-1FF8-D211-BA4B-00A0C93EC93B}");
            //LG1.FileHeaderGuid = guid1;
            //makerUMntretList.Add(LG1);

            //MakerUMnt LG2 = new MakerUMnt();
            //LG2.EnterpriseCode = this._enterpriseCode;
            //LG2.LargeGoodsGanreCode = 999;
            //LG2.LargeGoodsGanreName = "��������������������";
            //LG2.CreateDateTime = DateTime.Now.Date.Ticks;
            //LG2.UpdateDateTime = DateTime.Now.Date.Ticks;
            //Guid guid2 = new Guid("{28732AC1-1FF8-D211-BA4B-00A0C93EC93C}");
            //LG2.FileHeaderGuid = guid2;
            //makerUMntretList.Add(LG2);

            //this._totalCount = makerUMntretList.Count;
            //readCount = 2;

            // �ŏI�̃��[�J�[�}�X�^�I�u�W�F�N�g��ޔ�����
            //this._prevmakerU = ((MakerUMnt)makerUMntretList[makerUMntretList.Count - 1]).Clone();

            //int index = 0;
            //foreach (MakerUMnt lgoodsgranre in makerUMntretList)
            //{
            //    if (this._makerUTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
            //    {
            //        MakerUMntToDataSet(lgoodsgranre.Clone(), index);
            //        ++index;
            //    }
            //}
            /////////////////////////////////////end

            // �ŏI�̃��[�J�[�}�X�^�I�u�W�F�N�g��ޔ�����
            
            return status;
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		public int SearchNext(int readCount)
		{
#if False
			int dummy = 0;
#endif
			int status = 0;
            ArrayList makerUMntretList = null;

			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

#if False
			status = this._makerUAcs.SearchAll(
                            out makerUMntretList,
							out dummy,
							out this._nextData,
							this._enterpriseCode,
							readCount,
							this._prevmakerU);

#endif
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // �ŏI�̃��[�J�[�}�X�^�N���X��ޔ�����
                    this._prevmakerU = ((MakerUMnt)makerUMntretList[makerUMntretList.Count - 1]).Clone();

					int index = 0;
                    foreach (MakerUMnt lgoodsgranre in makerUMntretList)
					{
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                        //if (this._makerUTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
                        if (this._makerUTable.ContainsKey(CreateHashKey(lgoodsgranre)) == false)
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                        {
							index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count;
                            MakerUMntToDataSet(lgoodsgranre.Clone(), index);
						}
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(
						this,								  // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
						ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							  // �v���O��������
						"SearchNext",						  // ��������
						TMsgDisp.OPE_GET,					  // �I�y���[�V����
						ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
						this._makerUAcs,				  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��

					break;
				}
			}

			return status;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
            MakerUMnt makerU = ((MakerUMnt)this._makerUTable[guid]).Clone();

			if (makerU.Division == DIVISION_OFR)
			{
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					ASSEMBLY_ID,
					"���̃��R�[�h�͒񋟃f�[�^�̂��ߍ폜�ł��܂���",
					status,
					MessageBoxButtons.OK);
				this.Hide();

				return -2;
			}

			status = this._makerUAcs.LogicalDelete(ref makerU);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._makerUAcs);
					return status;
				}

				case -2:
				{
					//���Ɛݒ�Ŏg�p��
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						ASSEMBLY_ID,
						"���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
						status,
						MessageBoxButtons.OK);
					this.Hide();

					return status;
				}

				default:
				{
					TMsgDisp.Show(
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"Delete",							// ��������
						TMsgDisp.OPE_HIDE,					// �I�y���[�V����
						ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						this._makerUAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��

					return status;
				}
			}

			// �f�[�^�Z�b�g�W�J����
			MakerUMntToDataSet(makerU.Clone(), this._dataIndex);
			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 2008.06.11 30413 ���� ���[�J�[�R�[�h�͉E�l >>>>>>START
            // DEL 2008/10/07 �s��Ή�[6296] ��
            //appearanceTable.Add(GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "0000", Color.Black));   // ADD 2008/10/07 �s��Ή�[6296]
            // 2008.06.11 30413 ���� ���[�J�[�R�[�h�͉E�l <<<<<<END
			appearanceTable.Add(MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(MAKERSHORTNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));    // DEL 2009/06/12
			appearanceTable.Add(MAKERKANANAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.06.11 30413 ���� �\�����ʂ͉E�l >>>>>>START
            appearanceTable.Add(DISPLAYORDER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 2008.06.11 30413 ���� �\�����ʂ͉E�l <<<<<<END
            appearanceTable.Add(DIVISION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(DIVISIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			return appearanceTable;
		}
		# endregion

		# endregion

		#region ��Private Menbers
		private MakerAcs _makerUAcs;
		private MakerUMnt _prevmakerU;
		private SecInfoAcs _secInfoAcs;
		//private UserGuideAcs _userGuideAcs;  // iitani d  2007.05.18
#if False
		private bool _nextData;
#endif
		private int _totalCount;
		private string _enterpriseCode;
        private Hashtable _makerUTable;
		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private MakerUMnt _makerUClone;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;
		/// <summary>���_�I�v�V�����t���O</summary>
		private bool _optSection = false;

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		# endregion

		# region ��Consts
		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE = "�폜��";
		private const string SECTIONNAME_TITLE = "�������_";
		private const string GOODSMAKERCD_TITLE = "���[�J�[�R�[�h";
		private const string MAKERNAME_TITLE = "���[�J�[��";
        //private const string MAKERSHORTNAME_TITLE = "���[�J�[����";   // DEL 2009/06/12
		private const string MAKERKANANAME_TITLE = "���[�J�[��(��)";
		private const string DISPLAYORDER_TITLE = "�\������";
		private const string DIVISION_TITLE = "�f�[�^�敪�R�[�h";
		private const string DIVISIONNAME_TITLE = "�f�[�^�敪";

		private const string GUID_TITLE = "GUID";
		private const string MAKERU_TABLE = "LGOODSGANRE";
		
		//�f�[�^�敪
		private const int DIVISION_USR = 0;
		private const int DIVISION_OFR = 1;	

		private const string DIVISION_USR_NAME = "0";
		private const string DIVISION_OFR_NAME = "1";

		private const string DIVISION_USR_NAME_TITLE = "���[�U�[�f�[�^";
		private const string DIVISION_OFR_NAME_TITLE = "�񋟃f�[�^";	

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";
		private const string REFERENCE_MODE = "�Q�ƃ��[�h";

		// �R���g���[������
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";

		// Message�֘A��`
		private const string ASSEMBLY_ID	= "MAKHN09110U";
		private const string PG_NM			= "���[�J�[�}�X�^";
		private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG	= "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
		private const string ERR_RDEL_MSG	= "�폜�Ɏ��s���܂����B";
		private const string ERR_UPDT_MSG	= "�o�^�Ɏ��s���܂����B";
		private const string ERR_RVV_MSG	= "�����Ɏ��s���܂����B";
		private const string ERR_800_MSG	= "���ɑ��[�����X�V����Ă��܂�";
		private const string ERR_801_MSG	= "���ɑ��[�����폜����Ă��܂�";
		private const string SDC_RDEL_MSG	= "�}�X�^����폜����Ă��܂�";
		#endregion
    
		# region ��Main
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new MAKHN09110UA());
		}
		# endregion

		#region ��IMasterMaintenanceInputStart Members
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paraTable"></param>
		/// <returns></returns>
		public DialogResult ShowDialog(Hashtable paraTable)
		{
			this.ShowDialog();
			return this.DialogResult;
		}
		#endregion

		# region ��Private Methods
		/// <summary>
        /// ���[�J�[�}�X�^ �I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
        /// <param name="makerU">���[�J�[�}�X�^ �I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^ �N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void MakerUMntToDataSet(MakerUMnt makerU, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[MAKERU_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count - 1;
			}

			if (makerU.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DELETE_DATE] = makerU.UpdateDateTimeJpInFormal;
            }

			//���[�J�[�R�[�h
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GOODSMAKERCD_TITLE] = makerU.GoodsMakerCd;
			//���[�J�[��
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MAKERNAME_TITLE] = makerU.MakerName;
			//���[�J�[����
            //this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MAKERSHORTNAME_TITLE] = makerU.MakerShortName;     // DEL 2009/06/12
            //���[�J�[��(��)
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MAKERKANANAME_TITLE] = makerU.MakerKanaName;
			//�\������
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DISPLAYORDER_TITLE] = makerU.DisplayOrder;
			//�f�[�^�[�敪
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DIVISION_TITLE] = makerU.Division;
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DIVISIONNAME_TITLE] = makerU.DivisionName;
			// GUID
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GUID_TITLE] = makerU.FileHeaderGuid;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GUID_TITLE] = CreateHashKey(makerU);
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end

            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //if (this._makerUTable.ContainsKey(makerU.FileHeaderGuid))
			//{
			//	this._makerUTable.Remove(makerU.FileHeaderGuid);
			//}
			//this._makerUTable.Add(makerU.FileHeaderGuid, makerU);
            if (this._makerUTable.ContainsKey(CreateHashKey(makerU)))
            {
                this._makerUTable.Remove(CreateHashKey(makerU));
            }
            this._makerUTable.Add(CreateHashKey(makerU), makerU);
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
        }

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable makerUTable = new DataTable(MAKERU_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			makerUTable.Columns.Add(DELETE_DATE,           typeof(string));

			//���[�J�[�R�[�h
			makerUTable.Columns.Add(GOODSMAKERCD_TITLE, typeof(int));
			//���[�J�[��
			makerUTable.Columns.Add(MAKERNAME_TITLE, typeof(string));
			//���[�J�[����
            //makerUTable.Columns.Add(MAKERSHORTNAME_TITLE, typeof(string));    // DEL 2009/06/12
            //���[�J�[��(��)
			makerUTable.Columns.Add(MAKERKANANAME_TITLE, typeof(string));
			//�\������
			makerUTable.Columns.Add(DISPLAYORDER_TITLE, typeof(int));
			//�f�[�^�敪
			makerUTable.Columns.Add(DIVISION_TITLE, typeof(int));
			makerUTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));

			// GUID
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //makerUTable.Columns.Add(GUID_TITLE, typeof(Guid));
            makerUTable.Columns.Add(GUID_TITLE, typeof(string));
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end

			this.Bind_DataSet.Tables.Add(makerUTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
            // DEL 2009/06/12 ------>>>
            //this.Ok_Button.Location = new System.Drawing.Point(448, 313);
            //this.Cancel_Button.Location = new System.Drawing.Point(579, 313);
            //this.Delete_Button.Location = new System.Drawing.Point(320, 313);
            //this.Revive_Button.Location = new System.Drawing.Point(448, 313);
            // DEL 2009/06/12 ------<<<
            // ADD 2009/06/12 ------>>>
            this.Ok_Button.Location = new System.Drawing.Point(448, 267);
            this.Cancel_Button.Location = new System.Drawing.Point(579, 267);
            this.Delete_Button.Location = new System.Drawing.Point(320, 267);
            this.Revive_Button.Location = new System.Drawing.Point(448, 267);
            // ADD 2009/06/12 ------<<<
        }

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ScreenClear()
		{
			this.Guid_Label.Text = "";
			this.Division_Label.Text = "";
			this.DivisionName_Label.Text = "";
			this.GoodsMakerCdRF_tNedit.Clear();
			this.MakerNameRF_tEdit.Clear();
            //this.MakerShortNameRF_tEdit.Clear();  // DEL 2009/06/12
			this.MakerKanaNameRF_tEdit.Clear();
			this.DisplayOrderRF_tNedit.Clear();
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			if (this.DataIndex < 0)
			{
				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;
				DivisionName_Label.Text = DIVISION_USR_NAME_TITLE;
				Division_Label.Text = DIVISION_USR_NAME;

				// �{�^���ݒ�
				this.Ok_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;
                                       				
				// ��ʓ��͋����䏈��
				ScreenInputPermissionControl(true);
				MakerUMnt makerU = new MakerUMnt();

				//�N���[���쐬
				this._makerUClone = makerU.Clone(); 

				DispToMakerUMnt(ref this._makerUClone);

				// �t�H�[�J�X�ݒ�
				this.GoodsMakerCdRF_tNedit.Focus();
			}
			else
			{
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                MakerUMnt makerU = (MakerUMnt)this._makerUTable[guid];
				
				if (makerU.LogicalDeleteCode == 0)
				{
					// ��ʓ��͋����䏈��
                    // 2008.06.11 30413 ���� �񋟃f�[�^�̏ꍇ�͎Q�� >>>>>>START
                    //if (Division_Label.Text == DIVISION_OFR_NAME)
                    if (makerU.Division == DIVISION_OFR)
                    // 2008.06.11 30413 ���� �񋟃f�[�^�̏ꍇ�͎Q�� <<<<<<END
					{
						// �Q�ƃ��[�h
						this.Mode_Label.Text = REFERENCE_MODE;

						// �{�^���ݒ�
						this.Ok_Button.Visible = false;
						this.Delete_Button.Visible = false;
						this.Revive_Button.Visible = false;

						// ��ʓW�J����
						MakerUMntToScreen(makerU);

						//�N���[���쐬
						this._makerUClone = makerU.Clone();
						DispToMakerUMnt(ref this._makerUClone);
						//_dataIndex�o�b�t�@�ێ�
						this._indexBuf = this._dataIndex;

						// ��ʓ��͋����䏈��
						ScreenInputPermissionControl(false);
					}
					else
					{
						// �X�V���[�h
						this.Mode_Label.Text = UPDATE_MODE;

						// �{�^���ݒ�
						this.Ok_Button.Visible = true;
						this.Delete_Button.Visible = false;
						this.Revive_Button.Visible = false;

						// ��ʓW�J����
						MakerUMntToScreen(makerU);

						//�N���[���쐬
						this._makerUClone = makerU.Clone();
						DispToMakerUMnt(ref this._makerUClone);
						//_dataIndex�o�b�t�@�ێ�
						this._indexBuf = this._dataIndex;

						// ��ʓ��͋����䏈��
						ScreenInputPermissionControl(true);

						// �X�V���[�h�̏ꍇ�́A���[�J�[�}�X�^�R�[�h�̂ݓ��͕s�Ƃ���
						this.GoodsMakerCdRF_tNedit.Enabled = false;

						// �t�H�[�J�X�ݒ�
						this.MakerNameRF_tEdit.Focus();
						this.MakerNameRF_tEdit.SelectAll();
					}
				}
				else
				{
					// �폜���[�h
					this.Mode_Label.Text = DELETE_MODE;

					// �{�^���ݒ�
					this.Ok_Button.Visible = false;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;
					
					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;

					// ��ʓ��͋����䏈��
					ScreenInputPermissionControl(false);

					// ��ʓW�J����
					MakerUMntToScreen(makerU);

					// �t�H�[�J�X�ݒ�
					this.Delete_Button.Focus();
				}

			}
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
			this.GoodsMakerCdRF_tNedit.Enabled = enabled;
            this.MakerNameRF_tEdit.Enabled = enabled;
            //this.MakerShortNameRF_tEdit.Enabled = enabled;    // DEL 2009/06/12
			this.MakerKanaNameRF_tEdit.Enabled = enabled;
			this.DisplayOrderRF_tNedit.Enabled = enabled;
		}

		/// <summary>
        /// ���[�J�[�}�X�^ �N���X��ʓW�J����
		/// </summary>
        /// <param name="makerU">���[�J�[�}�X�^ �I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void MakerUMntToScreen(MakerUMnt makerU)
		{
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //this.Guid_Label.Text = makerU.FileHeaderGuid.ToString();
            this.Guid_Label.Text = CreateHashKey(makerU).ToString();
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
            this.Division_Label.Text = makerU.Division.ToString();
			this.DivisionName_Label.Text = makerU.DivisionName;
			//this.GoodsMakerCdRF_tNedit.Text = makerU.GoodsMakerCd.ToString();
			this.GoodsMakerCdRF_tNedit.SetInt(makerU.GoodsMakerCd);

			this.MakerNameRF_tEdit.Text = makerU.MakerName;
            //this.MakerShortNameRF_tEdit.Text = makerU.MakerShortName;     // DEL 2009/06/12
			this.MakerKanaNameRF_tEdit.Text = makerU.MakerKanaName;
			//this.DisplayOrderRF_tNedit.Text = makerU.DisplayOrder.ToString();
			this.DisplayOrderRF_tNedit.SetInt(makerU.DisplayOrder);
		}

		/// <summary>
		/// Value�`�F�b�N�����iint�j
		/// </summary>
		/// <param name="sorce">tCombo��Value</param>
		/// <returns>�`�F�b�N��̒l</returns>
		/// <remarks>
		/// <br>Note       : tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private int ValueToInt(object sorce)
		{
			int dest = 0;
			try
			{
				dest = Convert.ToInt32(sorce);
			}
			catch
			{
				return dest;
			}
			return dest;
		}

		/// <summary>
        /// ��ʏ�񃁁[�J�[�}�X�^ �N���X�i�[����
		/// </summary>
        /// <param name="makerU">���[�J�[�}�X�^ �I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʏ�񂩂烁�[�J�[�}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void DispToMakerUMnt(ref MakerUMnt makerU)
		{
            if (makerU == null)
			{
				// �V�K�̏ꍇ
                makerU = new MakerUMnt();
			}

            makerU.EnterpriseCode = this._enterpriseCode;

			if (this.Division_Label.Text == null || this.Division_Label.Text == "")
			{
				makerU.Division = DIVISION_USR;
			}
			else
			{
				makerU.Division = int.Parse(this.Division_Label.Text);
			}
			makerU.DivisionName = this.DivisionName_Label.Text;

			if (this.GoodsMakerCdRF_tNedit.Text == "0" || this.GoodsMakerCdRF_tNedit.Text == "")
            //if (this.GoodsMakerCdRF_tNedit.Text == null || this.GoodsMakerCdRF_tNedit.Text == "")
            {
				makerU.GoodsMakerCd = 0;
				//makerU.GoodsMakerCd = "";
			}
            else
            {
				makerU.GoodsMakerCd = int.Parse(this.GoodsMakerCdRF_tNedit.Text);
				//makerU.GoodsMakerCd = this.GoodsMakerCdRF_tNedit.Text;  
            }
			makerU.MakerName = this.MakerNameRF_tEdit.Text;

            //makerU.MakerShortName = this.MakerShortNameRF_tEdit.Text;     // DEL 2009/06/12
			makerU.MakerKanaName = this.MakerKanaNameRF_tEdit.Text;


			//if (this.DisplayOrderRF_tNedit.Text == null	|| this.DisplayOrderRF_tNedit.Text == "")
			if (this.DisplayOrderRF_tNedit.Text == "0"	|| this.DisplayOrderRF_tNedit.Text == "")
			{
				makerU.DisplayOrder = 0;
			}
			else
			{
				makerU.DisplayOrder = int.Parse(this.DisplayOrderRF_tNedit.Text);
			}
		}

		/// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="loginID">���O�C��ID</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        // 2007.03.27  S.Koga  amdne ------------------------------------------------------
 		//private bool ScreenDataCheck(ref Control control, ref string message, ref Infragistics.Win.UltraWinTabControl.UltraTab selectedTab, string loginID)
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        // --------------------------------------------------------------------------------
		{
			bool result = true;

			if (this.GoodsMakerCdRF_tNedit.Text == "0" || this.GoodsMakerCdRF_tNedit.Text == "")
            //if (this.GoodsMakerCdRF_tNedit.Text == "")
			{
                // ���[�J�[�R�[�h
				control = this.GoodsMakerCdRF_tNedit;
				message = this.GoodsMakerCd_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
			else if (this.MakerNameRF_tEdit.Text.Trim() == "")
			{
                // ���[�J�[��
				control = this.MakerNameRF_tEdit;
                message = this.MakerName_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
            // DEL 2009/06/12 ------>>>
            //else if (this.MakerShortNameRF_tEdit.Text.Trim() == "")
            //{
            //    // ���[�J�[����
            //    control = this.MakerShortNameRF_tEdit;
            //    message = this.MakerShortName_Title_Label.Text + "����͂��ĉ������B";
            //    result = false;
            //}
            // DEL 2009/06/12 ------<<<
            else if (this.MakerKanaNameRF_tEdit.Text.Trim() == "")
			{
                // ���[�J�[��(��)
				control = this.MakerKanaNameRF_tEdit;
				message = this.MakerKanaName_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
/*
			//else if (this.DisplayOrderRF_tNedit.Text.Trim() == "")
			else if (this.DisplayOrderRF_tNedit.Text == "0" || this.DisplayOrderRF_tNedit.Text == "")
			{
				// �\������
				control = this.DisplayOrderRF_tNedit;
				message = this.DisplayOrder_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
*/
			return result;
		}

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="operation">�I�y���[�V����</param>
		/// <param name="erObject">�G���[�I�u�W�F�N�g</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ExclusiveTransaction(int status, string operation, object erObject)
		{				   
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"ExclusiveTransaction",				// ��������
						operation,							// �I�y���[�V����
						ERR_800_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						erObject,							// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"ExclusiveTransaction",				// ��������
						operation,							// �I�y���[�V����
						ERR_801_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						erObject,							// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					break;
				}
			}
		}
        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="makerUMnt">MakerUMnt�N���X</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note      : MakerUMnt�N���X����n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programer : 96012 ���F �]</br>
        /// <br>Date      : 2008.02.29</br>
        /// </remarks>
        private string CreateHashKey(MakerUMnt makerUMnt)
        {
            return makerUMnt.GoodsMakerCd.ToString("d6");
        }
        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
        # endregion

		#region ��Control Events
		/// <summary>
		/// Form.Load �C�x���g(MAKHN09110UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void MAKHN09110UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
        /// Form.Closing �C�x���g(MAKHN09110UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void MAKHN09110UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
        /// Control.VisibleChanged �C�x���g(MAKHN09110UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void MAKHN09110UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (SaveProc() == false)
			{
				return;
			}
			// �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// �f�[�^�C���f�b�N�X������������
				this.DataIndex = -1;

				// ��ʃN���A����
				ScreenClear();

				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;
				DivisionName_Label.Text = DIVISION_USR_NAME_TITLE;
				Division_Label.Text = DIVISION_USR_NAME;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				ScreenInputPermissionControl(true);

				// �N���[�����ēx�擾����
				MakerUMnt makerU = new MakerUMnt();
				
				//�N���[���쐬
				this._makerUClone = makerU.Clone(); 
				DispToMakerUMnt(ref this._makerUClone);

				this.GoodsMakerCdRF_tNedit.Focus();
			}
			else
			{
				if (UnDisplaying != null)
				{
					MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
					UnDisplaying(this, me);
				}

				this.DialogResult = DialogResult.OK;

				this._indexBuf = -2;

				if (CanClose == true)
				{
					this.Close();
				}
				else
				{
					this.Hide();
				}
			}
		}

		/// <summary>
        /// ���[�J�[�}�X�^ ���o�^����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private bool SaveProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			Control control = null;
			string message = null;
			string loginID = "";
            // 2007.03.27  S.Koga  delete -------------------------------------------------
            //Infragistics.Win.UltraWinTabControl.UltraTab selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
            // ----------------------------------------------------------------------------

			MakerUMnt makerU = null;

			if (this.DataIndex >= 0)
			{
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                makerU = ((MakerUMnt)this._makerUTable[guid]).Clone();
			}

            // 2007.03.27  S.Koga  amend --------------------------------------------------
            //if (!ScreenDataCheck(ref control, ref message, ref selectedTab, loginID))
            if (!ScreenDataCheck(ref control, ref message, loginID))
            // ----------------------------------------------------------------------------
            {
				TMsgDisp.Show( 
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
					message,							// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);				// �\������{�^��

                // 2007.03.27  S.Koga  delete ---------------------------------------------
                //this.MainTabControl.SelectedTab = selectedTab;
                // ------------------------------------------------------------------------
				control.Focus();
				return false;
			}

			this.DispToMakerUMnt(ref makerU);

			status = this._makerUAcs.Write(ref makerU);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						MessageBoxButtons.OK);				// �\������{�^��

                    // 2007.03.27  S.Koga  delete -----------------------------------------
                    //this.MainTabControl.SelectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                    // --------------------------------------------------------------------
					this.GoodsMakerCdRF_tNedit.Focus();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._makerUAcs);

					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					
					return false;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"SaveProc",							// ��������
						TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
						ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						this._makerUAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					
					return false;
				}
			}

			// DataSet�W�J����
			MakerUMntToDataSet(makerU, this.DataIndex);
			
			return true;
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//�ۑ��m�F
				MakerUMnt compareMakerUMnt = new MakerUMnt();
				compareMakerUMnt = this._makerUClone.Clone();  
				//���݂̉�ʏ����擾����
				DispToMakerUMnt(ref compareMakerUMnt);
				//�ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._makerUClone.Equals(compareMakerUMnt)))	
				{
					//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					DialogResult res = TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						"",									// �\�����郁�b�Z�[�W 
						0,									// �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel);		// �\������{�^��

					switch(res)
					{
						case DialogResult.Yes:
						{
							if (SaveProc() == false)
							{
								return;
							}

							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
								UnDisplaying(this, me);
							}

							break;
						}
						case DialogResult.No:
						{
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
							}

							break;
						}
						default:
						{
							// 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                GoodsMakerCdRF_tNedit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                            return;
						}
					}
				}
			}

			this.DialogResult = DialogResult.Cancel;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			int status = 0;
			DialogResult result = TMsgDisp.Show( 
				this,													// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
				ASSEMBLY_ID,											// �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
				0,														// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel,								// �\������{�^��
				MessageBoxDefaultButton.Button2);						// �����\���{�^��


			if (result == DialogResult.OK)
			{
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                MakerUMnt makerU = ((MakerUMnt)this._makerUTable[guid]).Clone();

				status = this._makerUAcs.Delete(makerU);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                        //this._makerUTable.Remove(makerU.FileHeaderGuid);
                        this._makerUTable.Remove(CreateHashKey(makerU));
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._makerUAcs);

						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						this.DialogResult = DialogResult.Cancel;
						this._indexBuf = -2;

						if (CanClose == true)
						{
							this.Close();
						}
						else
						{
							this.Hide();
						}
						
						return;
					}
					default:
					{
						TMsgDisp.Show( 
							this,								  // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
							ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
							this.Text,							  // �v���O��������
							"Delete_Button_Click",				  // ��������
							TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
							ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
							status,								  // �X�e�[�^�X�l
							this._makerUAcs,					  // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				  // �\������{�^��
							MessageBoxDefaultButton.Button1);	  // �����\���{�^��
						
						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						this.DialogResult = DialogResult.Cancel;
						this._indexBuf = -2;

						if (CanClose == true)
						{
							this.Close();
						}
						else
						{
							this.Hide();
						}
						
						return;
					}
				}
			}
			else
			{
				this.Delete_Button.Focus();
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note �@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
            MakerUMnt makerU = ((MakerUMnt)_makerUTable[guid]).Clone();

			status = this._makerUAcs.Revival(ref makerU);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._makerUAcs);

					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					
					return;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								  // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
						ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							  // �v���O��������
						"Revive_Button_Click",				  // ��������
						TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
						ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
						this._makerUAcs,					  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��

					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					
					return;
				}
			}

			// DataSet�W�J����
			MakerUMntToDataSet(makerU, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer  : 96186 ���ԗT��</br>
        /// <br>Date        : 2007.08.01</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		/// TRetKeyControl.ChangeFocus �C�x���g �C�x���g(tRetKeyControl1)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�J�X���J�ڂ���ۂɔ������܂��B</br>
        /// <br>Programmer  : 96186 ���ԗT��</br>
        /// <br>Date        : 2007.08.01</br>
        /// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "GoodsMakerCdRF_tNedit":
                    // ���[�J�[�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = GoodsMakerCdRF_tNedit;
                        }
                    }
                    break;
            }
            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }

        /// <summary>
        /// MakerNameRF_tEdit_ValueChanged
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̒l���ύX�����Ɣ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.09.16</br>
        /// </remarks>
        private void MakerNameRF_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            if (tEdit.Text == "")
            {
                this.MakerKanaNameRF_tEdit.Text = "";
            }
        }

        /// <summary>
        /// MakerKanaNameRF_tEdit_ValueChanged
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[��(��)�̒l���ύX�����Ɣ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.09.16</br>
        /// </remarks>
        private void MakerKanaNameRF_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;
            // �S�p�J�i�𔼊p�łɋ����ϊ�
            tEdit.Text = Microsoft.VisualBasic.Strings.StrConv(tEdit.Text, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }

		# endregion

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���[�J�[�R�[�h
            int makerCd = GoodsMakerCdRF_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsMakerCd = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GOODSMAKERCD_TITLE];
                if (makerCd == dsMakerCd)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̃��[�J�[�}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���[�J�[�R�[�h�̃N���A
                        GoodsMakerCdRF_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̃��[�J�[�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���[�J�[�R�[�h�̃N���A
                                GoodsMakerCdRF_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }

    # region ���[�J�[�}�X�^������͈̓N���X
    /// <summary>
    /// ���[�J�[�}�X�^������͈̓N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���[�J�[�}�X�^������͈͂̃N���X�ł��B</br>
    /// <br>Programmer : 96186 ���ԗT��</br>
    /// <br>Date       : 2007.08.01</br>
    /// <br></br>
	/// </remarks>
	public class sendMakerUMntData
	{
		/// <summary>
        /// ���[�J�[�}�X�^������͈̓N���X�f�[�^�Z�b�g����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����p�̃f�[�^�Z�b�g�ł��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public DataSet dataSet;

		/// <summary>
        /// ���[�J�[�}�X�^���n�b�V���e�[�u��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����p�̃n�b�V���e�[�u���ł��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public Hashtable emphashtable;
	}
	# endregion

    # region ���[�J�[�}�X�^��������o�����N���X
    /// <summary>
    /// ���[�J�[�}�X�^��������o�����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���[�J�[�}�X�^��������o�����̃N���X�ł��B</br>
    /// <br>Programmer : 96186 ���ԗT��</br>
    /// <br>Date       : 2007.08.01</br>
    /// <br></br>
	/// </remarks>
	public class ConditionData
	{
		/// <summary>
        /// �J�n���[�J�[�}�X�^�R�[�h
		/// </summary>
		public int StartMakerUMntCode;
		/// <summary>
        /// �I�����[�J�[�}�X�^�R�[�h
		/// </summary>
        public int EndMakerUMntCode;
	}
	# endregion
}
