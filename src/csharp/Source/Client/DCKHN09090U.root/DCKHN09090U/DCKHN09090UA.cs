# region ��using

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win.Misc;

using Microsoft.VisualBasic;
using System.Collections.Generic;

# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �a�k���i�R�[�h�}�X�^ �t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: �a�k���i�R�[�h�}�X�^���̐ݒ���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer	: 96186 ���ԗT��</br>
	/// <br>Date		: 2007.08.01</br>
	/// <br>UpdateNote  : 2008.02.29 30167�@���@�O�M</br>
	/// <br>            : �n�b�V���L�[��GUID����e�[�u���v���C�}���L�[�ɏC��</br>
	/// <br>UpdateNote  : 2008.03.31 30167�@���@�O�M</br>
	/// <br>            : �X�V��ʋN�����L�[���ڂ�ݒ�ł��Ă��܂��s��C��</br>
	/// <br>            : �񋟉�ʋN�����e���ڂ�ݒ�ł��Ă��܂��s��C��</br>
    /// <br>UpdateNote  : 2008/06/10 30414�@�E�@�K�j</br>
    /// <br>            : �uBL�O���[�v�R�[�h�v�uBL�O���[�v�R�[�h���́v�u���i�|���O���[�v�R�[�h�v�u���i�|���O���[�v���́v�ǉ�</br>
    /// <br>            : �u���i�敪�O���[�v�R�[�h�v�u���i�敪�O���[�v�R�[�h���́v�u���i�敪�R�[�h�v�u���i�敪�R�[�h���́v�u���i�敪�ڍׁv�u���i�敪�ڍז��́v�폜</br>
    /// <br>UpdateNote  : 2009/03/17 30452�@���@�r��</br>
    /// <br>            : �J�i���͕⏕�̏o�͐��ݒ�</br>
    /// </remarks>
    public class DCKHN09090UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
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
        private Infragistics.Win.Misc.UltraLabel Guid_Label;
        private TEdit BLGoodsFullNameRF_tEdit;
        private Infragistics.Win.Misc.UltraLabel BLGoodsFullName_Title_Label;
        private Infragistics.Win.Misc.UltraLabel BLGoodsCode_Title_Label;
		private Infragistics.Win.Misc.UltraLabel BLGoodsHalfName_Title_Label;
		private Infragistics.Win.Misc.UltraLabel BLGoodsGenreCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel Division_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
		private UltraLabel ultraLabel1;
        private TNedit tNedit_BLGoodsCode;
        private UltraLabel DivisionName_Label;
        private TComboEditor EquipGenre_tComboEditor;
        private TNedit tNedit_BLGloupCode;
        private UltraLabel GoodsRateGrp_uLabel;
        private UltraLabel BLGloup_uLabel;
        private TEdit GoodsRateGrpName_tEdit;
        private TNedit tNedit_GoodsRateGrpCode;
        private TEdit BLGloupName_tEdit;
        private UltraButton GoodsRateGrpGuide_Button;
        private UltraButton BLGloupGuide_Button;
        private UiSetControl uiSetControl1;
        private TImeControl tImeControl1;
        private TEdit tEdit_BLGoodsHalfName;
        private UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		# endregion

		# region ��Constructor
		/// <summary>
        /// �a�k���i�R�[�h�}�X�^ �t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �a�k���i�R�[�h�}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 96186 ���ԗT��</br>
		/// <br>Date       : 2007.08.01</br>
		/// </remarks>
        public DCKHN09090UA()
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
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

			//�@��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �ϐ�������
			this._dataIndex = -1;
			this._secInfoAcs = new SecInfoAcs();
			this._bLGoodsCdAcs = new BLGoodsCdAcs();
            //this._userGuideAcs = new UserGuideAcs();  // iitani d 2007.05.18
			 
			this._totalCount = 0;
            this._bLGoodsCdUMntTable = new Hashtable();

			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			// ���_OP�̔���
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            this._bLGroupUAcs = new BLGroupUAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();

            // �e��}�X�^�Ǎ�
            ReadBLGroup();
            ReadGoodsRateGrp();
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
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("��ٰ�ߺ��ރK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���i�����ރK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09090UA));
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
            this.BLGoodsFullNameRF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.BLGoodsCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsFullName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsHalfName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsGenreCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Division_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.BLGloupGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.GoodsRateGrpGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGoodsCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DivisionName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EquipGenre_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BLGloup_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsRateGrp_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGloupCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BLGloupName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_GoodsRateGrpCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GoodsRateGrpName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.tEdit_BLGoodsHalfName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsFullNameRF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipGenre_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGloupName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsRateGrpCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BLGoodsHalfName)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(253, 448);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 11;
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 499);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(520, 23);
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
            appearance25.ForeColor = System.Drawing.Color.White;
            appearance25.TextHAlignAsString = "Center";
            appearance25.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance25;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(400, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 23);
            this.Mode_Label.TabIndex = 658;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(128, 448);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 10;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(253, 448);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 11;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(378, 448);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 12;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // BLGoodsFullNameRF_tEdit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLGoodsFullNameRF_tEdit.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLGoodsFullNameRF_tEdit.Appearance = appearance16;
            this.BLGoodsFullNameRF_tEdit.AutoSelect = true;
            this.BLGoodsFullNameRF_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BLGoodsFullNameRF_tEdit.DataText = "";
            this.BLGoodsFullNameRF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLGoodsFullNameRF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.BLGoodsFullNameRF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.BLGoodsFullNameRF_tEdit.Location = new System.Drawing.Point(161, 150);
            this.BLGoodsFullNameRF_tEdit.MaxLength = 20;
            this.BLGoodsFullNameRF_tEdit.Name = "BLGoodsFullNameRF_tEdit";
            this.BLGoodsFullNameRF_tEdit.Size = new System.Drawing.Size(330, 24);
            this.BLGoodsFullNameRF_tEdit.TabIndex = 1;
            this.BLGoodsFullNameRF_tEdit.ValueChanged += new System.EventHandler(this.BLGoodsFullNameRF_tEdit_ValueChanged);
            // 
            // BLGoodsCode_Title_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.BLGoodsCode_Title_Label.Appearance = appearance6;
            this.BLGoodsCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsCode_Title_Label.Location = new System.Drawing.Point(23, 111);
            this.BLGoodsCode_Title_Label.Name = "BLGoodsCode_Title_Label";
            this.BLGoodsCode_Title_Label.Size = new System.Drawing.Size(123, 24);
            this.BLGoodsCode_Title_Label.TabIndex = 610;
            this.BLGoodsCode_Title_Label.Text = "BL����";
            // 
            // BLGoodsFullName_Title_Label
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.BLGoodsFullName_Title_Label.Appearance = appearance28;
            this.BLGoodsFullName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsFullName_Title_Label.Location = new System.Drawing.Point(23, 150);
            this.BLGoodsFullName_Title_Label.Name = "BLGoodsFullName_Title_Label";
            this.BLGoodsFullName_Title_Label.Size = new System.Drawing.Size(123, 24);
            this.BLGoodsFullName_Title_Label.TabIndex = 611;
            this.BLGoodsFullName_Title_Label.Text = "BL���ޖ�";
            // 
            // Guid_Label
            // 
            this.Guid_Label.Location = new System.Drawing.Point(381, 34);
            this.Guid_Label.Name = "Guid_Label";
            this.Guid_Label.Size = new System.Drawing.Size(240, 25);
            this.Guid_Label.TabIndex = 46;
            this.Guid_Label.Visible = false;
            // 
            // BLGoodsHalfName_Title_Label
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.BLGoodsHalfName_Title_Label.Appearance = appearance24;
            this.BLGoodsHalfName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsHalfName_Title_Label.Location = new System.Drawing.Point(23, 189);
            this.BLGoodsHalfName_Title_Label.Name = "BLGoodsHalfName_Title_Label";
            this.BLGoodsHalfName_Title_Label.Size = new System.Drawing.Size(123, 24);
            this.BLGoodsHalfName_Title_Label.TabIndex = 600;
            this.BLGoodsHalfName_Title_Label.Text = "BL���ޖ�(��)";
            // 
            // BLGoodsGenreCode_Title_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.BLGoodsGenreCode_Title_Label.Appearance = appearance10;
            this.BLGoodsGenreCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsGenreCode_Title_Label.Location = new System.Drawing.Point(23, 228);
            this.BLGoodsGenreCode_Title_Label.Name = "BLGoodsGenreCode_Title_Label";
            this.BLGoodsGenreCode_Title_Label.Size = new System.Drawing.Size(123, 24);
            this.BLGoodsGenreCode_Title_Label.TabIndex = 640;
            this.BLGoodsGenreCode_Title_Label.Text = "��������";
            // 
            // Division_Label
            // 
            this.Division_Label.Location = new System.Drawing.Point(208, 55);
            this.Division_Label.Name = "Division_Label";
            this.Division_Label.Size = new System.Drawing.Size(240, 25);
            this.Division_Label.TabIndex = 66;
            this.Division_Label.Visible = false;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(23, 272);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(480, 3);
            this.ultraLabel15.TabIndex = 621;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // BLGloupGuide_Button
            // 
            this.BLGloupGuide_Button.Location = new System.Drawing.Point(219, 295);
            this.BLGloupGuide_Button.Name = "BLGloupGuide_Button";
            this.BLGloupGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.BLGloupGuide_Button.TabIndex = 5;
            ultraToolTipInfo2.ToolTipText = "��ٰ�ߺ��ރK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.BLGloupGuide_Button, ultraToolTipInfo2);
            this.BLGloupGuide_Button.Click += new System.EventHandler(this.BLGloupGuide_Button_Click);
            // 
            // GoodsRateGrpGuide_Button
            // 
            this.GoodsRateGrpGuide_Button.Location = new System.Drawing.Point(219, 364);
            this.GoodsRateGrpGuide_Button.Name = "GoodsRateGrpGuide_Button";
            this.GoodsRateGrpGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.GoodsRateGrpGuide_Button.TabIndex = 8;
            ultraToolTipInfo1.ToolTipText = "���i�����ރK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.GoodsRateGrpGuide_Button, ultraToolTipInfo1);
            this.GoodsRateGrpGuide_Button.Click += new System.EventHandler(this.GoodsRateGrpGuide_Button_Click);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel1.Location = new System.Drawing.Point(21, 88);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(480, 3);
            this.ultraLabel1.TabIndex = 627;
            // 
            // tNedit_BLGoodsCode
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode.Appearance = appearance9;
            this.tNedit_BLGoodsCode.AutoSelect = true;
            this.tNedit_BLGoodsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_BLGoodsCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode.DataText = "";
            this.tNedit_BLGoodsCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_BLGoodsCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_BLGoodsCode.Location = new System.Drawing.Point(161, 111);
            this.tNedit_BLGoodsCode.MaxLength = 8;
            this.tNedit_BLGoodsCode.Name = "tNedit_BLGoodsCode";
            this.tNedit_BLGoodsCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGoodsCode.Size = new System.Drawing.Size(43, 24);
            this.tNedit_BLGoodsCode.TabIndex = 0;
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
            this.DivisionName_Label.Location = new System.Drawing.Point(21, 50);
            this.DivisionName_Label.Name = "DivisionName_Label";
            this.DivisionName_Label.Size = new System.Drawing.Size(172, 24);
            this.DivisionName_Label.TabIndex = 2296;
            this.DivisionName_Label.Text = "���[�U�[�f�[�^";
            // 
            // EquipGenre_tComboEditor
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EquipGenre_tComboEditor.ActiveAppearance = appearance29;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            this.EquipGenre_tComboEditor.Appearance = appearance30;
            this.EquipGenre_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.EquipGenre_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EquipGenre_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EquipGenre_tComboEditor.ItemAppearance = appearance31;
            this.EquipGenre_tComboEditor.Location = new System.Drawing.Point(161, 228);
            this.EquipGenre_tComboEditor.MaxDropDownItems = 18;
            this.EquipGenre_tComboEditor.Name = "EquipGenre_tComboEditor";
            this.EquipGenre_tComboEditor.Size = new System.Drawing.Size(151, 24);
            this.EquipGenre_tComboEditor.TabIndex = 3;
            // 
            // BLGloup_uLabel
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.BLGloup_uLabel.Appearance = appearance7;
            this.BLGloup_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGloup_uLabel.Location = new System.Drawing.Point(23, 295);
            this.BLGloup_uLabel.Name = "BLGloup_uLabel";
            this.BLGloup_uLabel.Size = new System.Drawing.Size(123, 24);
            this.BLGloup_uLabel.TabIndex = 2298;
            this.BLGloup_uLabel.Text = "��ٰ�ߺ���";
            // 
            // GoodsRateGrp_uLabel
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.GoodsRateGrp_uLabel.Appearance = appearance21;
            this.GoodsRateGrp_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.GoodsRateGrp_uLabel.Location = new System.Drawing.Point(23, 364);
            this.GoodsRateGrp_uLabel.Name = "GoodsRateGrp_uLabel";
            this.GoodsRateGrp_uLabel.Size = new System.Drawing.Size(123, 24);
            this.GoodsRateGrp_uLabel.TabIndex = 2299;
            this.GoodsRateGrp_uLabel.Text = "���i������";
            // 
            // tNedit_BLGloupCode
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode.ActiveAppearance = appearance13;
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode.Appearance = appearance14;
            this.tNedit_BLGloupCode.AutoSelect = true;
            this.tNedit_BLGloupCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGloupCode.DataText = "";
            this.tNedit_BLGloupCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGloupCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_BLGloupCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_BLGloupCode.Location = new System.Drawing.Point(161, 295);
            this.tNedit_BLGloupCode.MaxLength = 5;
            this.tNedit_BLGloupCode.Name = "tNedit_BLGloupCode";
            this.tNedit_BLGloupCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGloupCode.Size = new System.Drawing.Size(35, 24);
            this.tNedit_BLGloupCode.TabIndex = 4;
            // 
            // BLGloupName_tEdit
            // 
            this.BLGloupName_tEdit.AcceptsTab = true;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLGloupName_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLGloupName_tEdit.Appearance = appearance12;
            this.BLGloupName_tEdit.AutoSelect = true;
            this.BLGloupName_tEdit.DataText = "";
            this.BLGloupName_tEdit.Enabled = false;
            this.BLGloupName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLGloupName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.BLGloupName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.BLGloupName_tEdit.Location = new System.Drawing.Point(161, 325);
            this.BLGloupName_tEdit.MaxLength = 20;
            this.BLGloupName_tEdit.Name = "BLGloupName_tEdit";
            this.BLGloupName_tEdit.ReadOnly = true;
            this.BLGloupName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.BLGloupName_tEdit.TabIndex = 6;
            // 
            // tNedit_GoodsRateGrpCode
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.tNedit_GoodsRateGrpCode.ActiveAppearance = appearance4;
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.tNedit_GoodsRateGrpCode.Appearance = appearance5;
            this.tNedit_GoodsRateGrpCode.AutoSelect = true;
            this.tNedit_GoodsRateGrpCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsRateGrpCode.DataText = "";
            this.tNedit_GoodsRateGrpCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsRateGrpCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_GoodsRateGrpCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_GoodsRateGrpCode.Location = new System.Drawing.Point(161, 364);
            this.tNedit_GoodsRateGrpCode.MaxLength = 5;
            this.tNedit_GoodsRateGrpCode.Name = "tNedit_GoodsRateGrpCode";
            this.tNedit_GoodsRateGrpCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsRateGrpCode.Size = new System.Drawing.Size(35, 24);
            this.tNedit_GoodsRateGrpCode.TabIndex = 7;
            // 
            // GoodsRateGrpName_tEdit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsRateGrpName_tEdit.ActiveAppearance = appearance26;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsRateGrpName_tEdit.Appearance = appearance27;
            this.GoodsRateGrpName_tEdit.AutoSelect = true;
            this.GoodsRateGrpName_tEdit.DataText = "";
            this.GoodsRateGrpName_tEdit.Enabled = false;
            this.GoodsRateGrpName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsRateGrpName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsRateGrpName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.GoodsRateGrpName_tEdit.Location = new System.Drawing.Point(161, 394);
            this.GoodsRateGrpName_tEdit.MaxLength = 20;
            this.GoodsRateGrpName_tEdit.Name = "GoodsRateGrpName_tEdit";
            this.GoodsRateGrpName_tEdit.ReadOnly = true;
            this.GoodsRateGrpName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.GoodsRateGrpName_tEdit.TabIndex = 9;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = this.BLGoodsFullNameRF_tEdit;
            this.tImeControl1.OutControl = this.tEdit_BLGoodsHalfName;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 20;
            // 
            // tEdit_BLGoodsHalfName
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_BLGoodsHalfName.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_BLGoodsHalfName.Appearance = appearance23;
            this.tEdit_BLGoodsHalfName.AutoSelect = true;
            this.tEdit_BLGoodsHalfName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_BLGoodsHalfName.DataText = "";
            this.tEdit_BLGoodsHalfName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_BLGoodsHalfName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_BLGoodsHalfName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.tEdit_BLGoodsHalfName.Location = new System.Drawing.Point(161, 189);
            this.tEdit_BLGoodsHalfName.MaxLength = 40;
            this.tEdit_BLGoodsHalfName.Name = "tEdit_BLGoodsHalfName";
            this.tEdit_BLGoodsHalfName.Size = new System.Drawing.Size(337, 24);
            this.tEdit_BLGoodsHalfName.TabIndex = 2;
            this.tEdit_BLGoodsHalfName.ValueChanged += new System.EventHandler(this.tEdit_BLGoodsHalfName_ValueChanged);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(128, 448);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 10;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // DCKHN09090UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(520, 522);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.tEdit_BLGoodsHalfName);
            this.Controls.Add(this.GoodsRateGrpGuide_Button);
            this.Controls.Add(this.BLGloupGuide_Button);
            this.Controls.Add(this.GoodsRateGrpName_tEdit);
            this.Controls.Add(this.tNedit_GoodsRateGrpCode);
            this.Controls.Add(this.BLGloupName_tEdit);
            this.Controls.Add(this.tNedit_BLGloupCode);
            this.Controls.Add(this.GoodsRateGrp_uLabel);
            this.Controls.Add(this.BLGloup_uLabel);
            this.Controls.Add(this.EquipGenre_tComboEditor);
            this.Controls.Add(this.DivisionName_Label);
            this.Controls.Add(this.tNedit_BLGoodsCode);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.Division_Label);
            this.Controls.Add(this.BLGoodsGenreCode_Title_Label);
            this.Controls.Add(this.BLGoodsHalfName_Title_Label);
            this.Controls.Add(this.Guid_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.BLGoodsFullNameRF_tEdit);
            this.Controls.Add(this.BLGoodsFullName_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.BLGoodsCode_Title_Label);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCKHN09090UA";
            this.Text = "BL���ރ}�X�^";
            this.Load += new System.EventHandler(this.DCKHN09090UA_Load);
            this.VisibleChanged += new System.EventHandler(this.DCKHN09090UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DCKHN09090UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsFullNameRF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipGenre_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGloupName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsRateGrpCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BLGoodsHalfName)).EndInit();
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
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList makerUMntretList = null;

            // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
            status = this._bLGoodsCdAcs.SearchAll(
                        out makerUMntretList,
                        this._enterpriseCode);

            this._totalCount = makerUMntretList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (BLGoodsCdUMnt lgoodsgranre in makerUMntretList)
                        {
							//----- ueno upd ---------- start 2008.02.29
							// �n�b�V���L�[�擾
							string hashKey = CreateHashKey(lgoodsgranre);
							
							//if (this._bLGoodsCdUMntTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
							if (this._bLGoodsCdUMntTable.ContainsKey(hashKey) == false)
                            {
                                // DataSet�W�J
                                MakerUMntToDataSet(lgoodsgranre.Clone(), index);
                                ++index;
                            }
							//----- ueno upd ---------- end 2008.02.29
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
                            this._bLGoodsCdAcs,				  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        break;
                    }
            }

            totalCount = this._totalCount;
            
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
        /// </remarks>
		public int SearchNext(int readCount)
		{
			// �l�N�X�g�f�[�^���������i�������j
			return 0;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;

			//----- ueno upd ---------- start 2008.02.29
			// �n�b�V���L�[�擾
			string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
			BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[hashKey]).Clone();

			//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
			//BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[guid]).Clone();
			//----- ueno upd ---------- end 2008.02.29

			if (bLGoodsCdUMnt.Division == DIVISION_OFR)
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

			status = this._bLGoodsCdAcs.LogicalDelete(ref bLGoodsCdUMnt);
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
					ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._bLGoodsCdAcs);
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
						this._bLGoodsCdAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��

					return status;
				}
			}

			// �f�[�^�Z�b�g�W�J����
			MakerUMntToDataSet(bLGoodsCdUMnt.Clone(), this._dataIndex);
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

			appearanceTable.Add(BLGoodsCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			appearanceTable.Add(BLGoodsCdDerivedNo_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            appearanceTable.Add(BLGoodsFullName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(BLGoodsHalfName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			appearanceTable.Add(BLGoodsGenreCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(LargeGoodsGanreCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(LargeGoodsGanreName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(MediumGoodsGanreCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(MediumGoodsGanreName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(DetailGoodsGanreCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(DetailGoodsGanreName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // BL�O���[�v�R�[�h
            appearanceTable.Add(BLGloupCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // BL�O���[�v�R�[�h����
            appearanceTable.Add(BLGloupCodeName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���i�|���O���[�v�R�[�h
            appearanceTable.Add(GoodsRateGrpCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���i�|���O���[�v����
            appearanceTable.Add(GoodsRateGrpName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ��������
            appearanceTable.Add(EquipGenre_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

            appearanceTable.Add(DIVISION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(DIVISIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			return appearanceTable;
		}
		# endregion

		# endregion

		#region ��Private Menbers
		private BLGoodsCdAcs _bLGoodsCdAcs;
		private SecInfoAcs _secInfoAcs;
		private int _totalCount;
		private string _enterpriseCode;
        private Hashtable _bLGoodsCdUMntTable;
		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private BLGoodsCdUMnt _makerUClone;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;
		/// <summary>���_�I�v�V�����t���O</summary>
		private bool _optSection = false;

        // �f�[�^�敪(0:���[�U�[ 1:��)
        private int _divisionCode;

        private BLGroupUAcs _bLGroupUAcs;
        private GoodsGroupUAcs _goodsGroupUAcs;

        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		
		# endregion

		# region ��Consts
		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE = "�폜��";
		private const string SECTIONNAME_TITLE = "�������_";

        private const string BLGoodsCode_TITLE = "BL����";
        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		private const string BLGoodsCdDerivedNo_TITLE	= "�}��";
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        private const string BLGoodsFullName_TITLE = "BL���ޖ�";
        private const string BLGoodsHalfName_TITLE = "BL���ޖ�(��)";
        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		private const string BLGoodsGenreCode_TITLE	= "BL���i����";
		private const string LargeGoodsGanreCode_TITLE	= "���i�敪�O���[�v";
		private const string LargeGoodsGanreName_TITLE	= "���i�敪�O���[�v����";
		private const string MediumGoodsGanreCode_TITLE	= "���i�敪";
		private const string MediumGoodsGanreName_TITLE	= "���i�敪����";
		private const string DetailGoodsGanreCode_TITLE	= "���i�敪�ڍ�";
		private const string DetailGoodsGanreName_TITLE	= "���i�敪�ڍז���";
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        private const string EquipGenre_TITLE           = "��������";
        private const string BLGloupCode_TITLE = "��ٰ�ߺ���";
        private const string BLGloupCodeName_TITLE = "��ٰ�ߺ��ޖ�";
        private const string GoodsRateGrpCode_TITLE     = "���i�����ރR�[�h";
        private const string GoodsRateGrpName_TITLE = "���i�����ޖ�";
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
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

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        // ��������
        private const int EQUIPGANRE_CODE_0         = 0;
        private const int EQUIPGANRE_CODE_1001      = 1001;
        private const int EQUIPGANRE_CODE_1005      = 1005;
        private const int EQUIPGANRE_CODE_1010      = 1010;
        private const string EQUIPGANRE_NAME_0      = "����";
        private const string EQUIPGANRE_NAME_1001   = "�o�b�e���[";
        private const string EQUIPGANRE_NAME_1005   = "�^�C��";
        private const string EQUIPGANRE_NAME_1010   = "�I�C��";
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";
		private const string REFERENCE_MODE = "�Q�ƃ��[�h";

		// �R���g���[������
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";

		// Message�֘A��`
		private const string ASSEMBLY_ID	= "DCKHN09090U";
		private const string PG_NM			= "BL���ރ}�X�^";
		private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG	= "����BL���ނ͊��Ɏg�p����Ă��܂��B";
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
			System.Windows.Forms.Application.Run(new DCKHN09090UA());
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
        /// �a�k���i�R�[�h�}�X�^ �I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="bLGoodsCdUMnt">�a�k���i�R�[�h�}�X�^ �I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : �a�k���i�R�[�h�}�X�^ �N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void MakerUMntToDataSet(BLGoodsCdUMnt bLGoodsCdUMnt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[MAKERU_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count - 1;
			}

			if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DELETE_DATE] = bLGoodsCdUMnt.UpdateDateTimeJpInFormal;
            }

			//BL���i�R�[�h
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsCode_TITLE] = bLGoodsCdUMnt.BLGoodsCode.ToString("00000");
			//�}��
			//this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsCdDerivedNo_TITLE] = bLGoodsCdUMnt.BLGoodsCdDerivedNo;
			//BL���i�R�[�h���́i�S�p�j
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsFullName_TITLE] = bLGoodsCdUMnt.BLGoodsFullName;
			//BL���i�R�[�h���́i���p�j
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsHalfName_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName;

            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			//BL���i����
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsGenreCode_TITLE] = bLGoodsCdUMnt.BLGoodsGenreCode;
			//���i�敪�O���[�v�R�[�h
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][LargeGoodsGanreCode_TITLE] = bLGoodsCdUMnt.LargeGoodsGanreCode;
			//���i�敪�O���[�v����
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][LargeGoodsGanreName_TITLE] = bLGoodsCdUMnt.LargeGoodsGanreName;
			//���i�敪�R�[�h
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MediumGoodsGanreCode_TITLE] = bLGoodsCdUMnt.MediumGoodsGanreCode;
			//���i�敪����
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MediumGoodsGanreName_TITLE] = bLGoodsCdUMnt.MediumGoodsGanreName;
			//���i�敪�ڍ׃R�[�h
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DetailGoodsGanreCode_TITLE] = bLGoodsCdUMnt.DetailGoodsGanreCode;
			//���i�敪�ڍז���
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DetailGoodsGanreName_TITLE] = bLGoodsCdUMnt.DetailGoodsGanreName;
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // BL�O���[�v�R�[�h
            if (bLGoodsCdUMnt.BLGloupCode == 0)
            {
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGloupCode_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGloupCode_TITLE] = bLGoodsCdUMnt.BLGloupCode.ToString("00000");
            }
            // BL�O���[�v�R�[�h����
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGloupCodeName_TITLE] = GetBLGroupName(bLGoodsCdUMnt.BLGloupCode);
            // ���i�|���O���[�v�R�[�h
            if (bLGoodsCdUMnt.GoodsRateGrpCode == 0)
            {
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsRateGrpCode_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsRateGrpCode_TITLE] = bLGoodsCdUMnt.GoodsRateGrpCode.ToString("0000");
            }
            // ���i�|���O���[�v����
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsRateGrpName_TITLE] = GetGoodsRateGrpName(bLGoodsCdUMnt.GoodsRateGrpCode);
            // ��������
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][EquipGenre_TITLE] = GetEquipGenreName(bLGoodsCdUMnt.BLGoodsGenreCode);
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

            //�f�[�^�[�敪
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DIVISION_TITLE] = bLGoodsCdUMnt.Division;
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DIVISIONNAME_TITLE] = bLGoodsCdUMnt.DivisionName;

			//----- ueno upd ---------- start 2008.02.29
			// �n�b�V���L�[�擾
			string hashKey = CreateHashKey(bLGoodsCdUMnt);

			// �L�[�ݒ�
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GUID_TITLE] = hashKey;

			if (this._bLGoodsCdUMntTable.ContainsKey(hashKey))
			{
				this._bLGoodsCdUMntTable.Remove(hashKey);
			}
			this._bLGoodsCdUMntTable.Add(hashKey, bLGoodsCdUMnt);

			//// GUID
			//this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GUID_TITLE] = bLGoodsCdUMnt.FileHeaderGuid;

			//if (this._bLGoodsCdUMntTable.ContainsKey(bLGoodsCdUMnt.FileHeaderGuid))
			//{
			//    this._bLGoodsCdUMntTable.Remove(bLGoodsCdUMnt.FileHeaderGuid);
			//}
			//this._bLGoodsCdUMntTable.Add(bLGoodsCdUMnt.FileHeaderGuid, bLGoodsCdUMnt);
			//----- ueno upd ---------- end 2008.02.29
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable makerUTable = new DataTable(MAKERU_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			makerUTable.Columns.Add(DELETE_DATE,           typeof(string));

			//BL���i�R�[�h
			makerUTable.Columns.Add(BLGoodsCode_TITLE, typeof(string));
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			//�}��
			makerUTable.Columns.Add(BLGoodsCdDerivedNo_TITLE, typeof(int));
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            //BL���i�R�[�h���́i�S�p�j
			makerUTable.Columns.Add(BLGoodsFullName_TITLE, typeof(string));
			//BL���i�R�[�h���́i���p�j
			makerUTable.Columns.Add(BLGoodsHalfName_TITLE, typeof(string));

            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			//BL���i����
			makerUTable.Columns.Add(BLGoodsGenreCode_TITLE, typeof(int));
			//���i�敪�O���[�v�R�[�h
			makerUTable.Columns.Add(LargeGoodsGanreCode_TITLE, typeof(string));
			//���i�敪�O���[�v����
			makerUTable.Columns.Add(LargeGoodsGanreName_TITLE, typeof(string));
			//���i�敪�R�[�h
			makerUTable.Columns.Add(MediumGoodsGanreCode_TITLE, typeof(string));
			//���i�敪����
			makerUTable.Columns.Add(MediumGoodsGanreName_TITLE, typeof(string));
			//���i�敪�ڍ׃R�[�h
			makerUTable.Columns.Add(DetailGoodsGanreCode_TITLE, typeof(string));
			//���i�敪�ڍז���
			makerUTable.Columns.Add(DetailGoodsGanreName_TITLE, typeof(string));
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // BL�O���[�v�R�[�h
            makerUTable.Columns.Add(BLGloupCode_TITLE, typeof(string));
            // BL�O���[�v�R�[�h����
            makerUTable.Columns.Add(BLGloupCodeName_TITLE, typeof(string));
            // ���i�|���O���[�v�R�[�h
            makerUTable.Columns.Add(GoodsRateGrpCode_TITLE, typeof(string));
            // ���i�|���O���[�v����
            makerUTable.Columns.Add(GoodsRateGrpName_TITLE, typeof(string));
            // ��������
            makerUTable.Columns.Add(EquipGenre_TITLE, typeof(string));
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

            //�f�[�^�敪
			makerUTable.Columns.Add(DIVISION_TITLE, typeof(int));
			makerUTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));

			//----- ueno upd ---------- start 2008.02.29
			// GUID
			//makerUTable.Columns.Add(GUID_TITLE, typeof(Guid));
			makerUTable.Columns.Add(GUID_TITLE, typeof(string));
			//----- ueno upd ---------- end 2008.02.29

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
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
            this.Ok_Button.Location = new System.Drawing.Point(359, 490);
            this.Cancel_Button.Location = new System.Drawing.Point(484, 490);
            this.Delete_Button.Location = new System.Drawing.Point(234, 490);
            this.Revive_Button.Location = new System.Drawing.Point(359, 490);
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // ��������
            this.EquipGenre_tComboEditor.Items.Add(EQUIPGANRE_CODE_0, EQUIPGANRE_NAME_0);         // ����
            this.EquipGenre_tComboEditor.Items.Add(EQUIPGANRE_CODE_1001, EQUIPGANRE_NAME_1001);   // �o�b�e���[
            this.EquipGenre_tComboEditor.Items.Add(EQUIPGANRE_CODE_1005, EQUIPGANRE_NAME_1005);   // �^�C��
            this.EquipGenre_tComboEditor.Items.Add(EQUIPGANRE_CODE_1010, EQUIPGANRE_NAME_1010);   // �I�C��
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
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

			this.tNedit_BLGoodsCode.Clear();
			//this.BLGoodsCdDerivedNoRF_tNedit.Clear();
			this.BLGoodsFullNameRF_tEdit.Clear();
			this.tEdit_BLGoodsHalfName.Clear();
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			this.BLGoodsGenreCodeRF_tNedit.Clear();
			this.LargeGoodsGanreCodeRF_tEdit.Clear();
			this.LargeGoodsGanreNameRF_tEdit.Clear();
			this.MediumGoodsGanreCodeRF_tEdit.Clear();
			this.MediumGoodsGanreNameRF_tEdit.Clear();
			this.DetailGoodsGanreCodeRF_tEdit.Clear();
			this.DetailGoodsGanreNameRF_tEdit.Clear();
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            this.EquipGenre_tComboEditor.SelectedIndex = 0;
            this.tNedit_BLGloupCode.Clear();
            this.BLGloupName_tEdit.Clear();
            this.tNedit_GoodsRateGrpCode.Clear();
            this.GoodsRateGrpName_tEdit.Clear();
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			if (this.DataIndex < 0)
			{
				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;
				Division_Label.Text = DIVISION_USR_NAME;
				DivisionName_Label.Text = DIVISION_USR_NAME_TITLE;

                // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                // �f�[�^�敪
                this._divisionCode = DIVISION_USR;
                // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

				// �{�^���ݒ�
				this.Ok_Button.Visible = true;
                this.Renewal_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;
                                       				
				// ��ʓ��͋����䏈��
				//----- ueno upd ---------- start 2008.03.31
				ScreenInputPermissionControl(INSERT_MODE);
				//----- ueno upd ---------- end 2008.03.31

				BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();

				//�N���[���쐬
				this._makerUClone = bLGoodsCdUMnt.Clone(); 

                // ��ʏ��i�[
				DispToBLGoodsCdUMnt(ref this._makerUClone);

				// �t�H�[�J�X�ݒ�
				this.tNedit_BLGoodsCode.Focus();
			}
			else
			{
				//----- ueno upd ---------- start 2008.02.29
				// �n�b�V���L�[�擾
				string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				BLGoodsCdUMnt bLGoodsCdUMnt = (BLGoodsCdUMnt)this._bLGoodsCdUMntTable[hashKey];

				//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//BLGoodsCdUMnt bLGoodsCdUMnt = (BLGoodsCdUMnt)this._bLGoodsCdUMntTable[guid];
				//----- ueno upd ---------- end 2008.02.29

                // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                // �f�[�^�敪
                this._divisionCode = bLGoodsCdUMnt.Division;
                // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

				if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
				{
                    ////----- ueno upd ---------- end 2008.03.31
                    ////if (Division_Label.Text == DIVISION_OFR_NAME)
                    //if (bLGoodsCdUMnt.Division == DIVISION_OFR)
                    ////----- ueno upd ---------- end 2008.03.31
                    //{
                    //    // �Q�ƃ��[�h
                    //    this.Mode_Label.Text = REFERENCE_MODE;

                    //    // �{�^���ݒ�
                    //    this.Ok_Button.Visible = false;
                    //    this.Delete_Button.Visible = false;
                    //    this.Revive_Button.Visible = false;

                    //    // ��ʓW�J����
                    //    MakerUMntToScreen(bLGoodsCdUMnt);

                    //    //�N���[���쐬
                    //    this._makerUClone = bLGoodsCdUMnt.Clone();

                    //    // ��ʏ��i�[
                    //    DispToBLGoodsCdUMnt(ref this._makerUClone);

                    //    //_dataIndex�o�b�t�@�ێ�
                    //    this._indexBuf = this._dataIndex;

                    //    // ��ʓ��͋����䏈��
                    //    //----- ueno upd ---------- start 2008.03.31
                    //    ScreenInputPermissionControl(REFERENCE_MODE);
                    //    //----- ueno upd ---------- end 2008.03.31
                    //}
                    //else
                    //{
						// �X�V���[�h
						this.Mode_Label.Text = UPDATE_MODE;

						// �{�^���ݒ�
						this.Ok_Button.Visible = true;
                        this.Renewal_Button.Visible = true;
						this.Delete_Button.Visible = false;
						this.Revive_Button.Visible = false;

						// ��ʓ��͋����䏈��
						//----- ueno upd ---------- start 2008.03.31
						ScreenInputPermissionControl(UPDATE_MODE);
						//----- ueno upd ---------- end 2008.03.31

						// ��ʓW�J����
						MakerUMntToScreen(bLGoodsCdUMnt);

						//�N���[���쐬
						this._makerUClone = bLGoodsCdUMnt.Clone();

                        // ��ʏ��i�[
						DispToBLGoodsCdUMnt(ref this._makerUClone);

						//_dataIndex�o�b�t�@�ێ�
						this._indexBuf = this._dataIndex;

						// �X�V���[�h�̏ꍇ�́A�a�k���i�R�[�h�}�X�^�R�[�h-�}�ł���͕s�Ƃ���
						//this.BLGoodsCodeRF_tNedit.Enabled = false;
						//this.BLGoodsCdDerivedNoRF_tNedit.Enabled = false;

						// �t�H�[�J�X�ݒ�
						this.BLGoodsFullNameRF_tEdit.Focus();
						this.BLGoodsFullNameRF_tEdit.SelectAll();
					//}
				}
				else
				{
					// �폜���[�h
					this.Mode_Label.Text = DELETE_MODE;

					// �{�^���ݒ�
					this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;
					
					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;

					// ��ʓ��͋����䏈��
					//----- ueno upd ---------- start 2008.03.31
					ScreenInputPermissionControl(DELETE_MODE);
					//----- ueno upd ---------- end 2008.03.31

					// ��ʓW�J����
					MakerUMntToScreen(bLGoodsCdUMnt);

					// �t�H�[�J�X�ݒ�
					this.Delete_Button.Focus();
				}
			}
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="mode">�ҏW���[�h</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
		/// <br>UpdateNote : 2008.03.31 30167�@���@�O�M</br>
		/// <br>Note       : �e���[�h���̏����ǉ�</br>
        /// </remarks>
		private void ScreenInputPermissionControl(string mode)
		{
			//----- ueno add ---------- start 2008.03.31
			switch(mode)
			{
				case INSERT_MODE:		// �V�K
					{
						this.tNedit_BLGoodsCode.Enabled = true;				// BL���i�R�[�h
						this.BLGoodsFullNameRF_tEdit.Enabled = true;			// BL���i����
						this.tEdit_BLGoodsHalfName.Enabled = true;			// BL���i���́i�J�i�j
                        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
						this.BLGoodsGenreCodeRF_tNedit.Enabled = true;			// BL���i����
                        this.LargeGoodsGanreCodeRF_tUltraBtn.Enabled = true;	// ���i�敪�O���[�v�K�C�h
                        this.LargeGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪�O���[�v
                        this.MediumGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪
                        this.DetailGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪�ڍ�
                        this.LargeGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪�O���[�v����
                        this.MediumGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪����
                        this.DetailGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪�ڍז���
                           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                        this.EquipGenre_tComboEditor.Enabled = true;            // ��������
                        this.tNedit_BLGloupCode.Enabled = true;                 // BL�O���[�v�R�[�h
                        this.BLGloupGuide_Button.Enabled = true;                // BL�O���[�v�K�C�h�{�^��
                        this.tNedit_GoodsRateGrpCode.Enabled = true;            // ���i�|���O���[�v�R�[�h
                        this.GoodsRateGrpGuide_Button.Enabled = true;           // ���i�|���O���[�v�K�C�h�{�^��
                        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
                        break;
					}
				case UPDATE_MODE:		// �X�V
					{
						this.tNedit_BLGoodsCode.Enabled = false;				// BL���i�R�[�h
                        this.BLGoodsFullNameRF_tEdit.Enabled = true;			// BL���i����
                        this.tEdit_BLGoodsHalfName.Enabled = true;			// BL���i���́i�J�i�j
                        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
						this.BLGoodsGenreCodeRF_tNedit.Enabled = false;			// BL���i����
						this.LargeGoodsGanreCodeRF_tUltraBtn.Enabled = true;	// ���i�敪�O���[�v�K�C�h
						this.LargeGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪�O���[�v
						this.MediumGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪
						this.DetailGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪�ڍ�
						this.LargeGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪�O���[�v����
						this.MediumGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪����
						this.DetailGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪�ڍז���
                           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                        this.EquipGenre_tComboEditor.Enabled = true;           // ��������
                        this.tNedit_BLGloupCode.Enabled = true;                 // BL�O���[�v�R�[�h
                        this.BLGloupGuide_Button.Enabled = true;                // BL�O���[�v�K�C�h�{�^��
                        this.tNedit_GoodsRateGrpCode.Enabled = true;            // ���i�|���O���[�v�R�[�h
                        this.GoodsRateGrpGuide_Button.Enabled = true;           // ���i�|���O���[�v�K�C�h�{�^��
                        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
                        break;
					}
				case DELETE_MODE:		// �폜
				case REFERENCE_MODE:	// �Q��
					{
						this.tNedit_BLGoodsCode.Enabled = false;				// BL���i�R�[�h
						this.BLGoodsFullNameRF_tEdit.Enabled = false;			// BL���i����
						this.tEdit_BLGoodsHalfName.Enabled = false;			// BL���i���́i�J�i�j
                        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
						this.BLGoodsGenreCodeRF_tNedit.Enabled = false;			// BL���i����
						this.LargeGoodsGanreCodeRF_tUltraBtn.Enabled = false;	// ���i�敪�O���[�v�K�C�h
						this.LargeGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪�O���[�v
						this.MediumGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪
						this.DetailGoodsGanreCodeRF_tEdit.Enabled = false;		// ���i�敪�ڍ�
						this.LargeGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪�O���[�v����
						this.MediumGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪����
						this.DetailGoodsGanreNameRF_tEdit.Enabled = false;		// ���i�敪�ڍז���
                           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                        this.EquipGenre_tComboEditor.Enabled = false;           // ��������
                        this.tNedit_BLGloupCode.Enabled = false;                // BL�O���[�v�R�[�h
                        this.BLGloupGuide_Button.Enabled = false;               // BL�O���[�v�K�C�h�{�^��
                        this.tNedit_GoodsRateGrpCode.Enabled = false;           // ���i�|���O���[�v�R�[�h
                        this.GoodsRateGrpGuide_Button.Enabled = false;          // ���i�|���O���[�v�K�C�h�{�^��
                        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
                        break;
					}
			}
			
			//this.BLGoodsCodeRF_tNedit.Enabled = enabled;
			////this.BLGoodsCdDerivedNoRF_tNedit.Enabled = enabled;
			//this.BLGoodsFullNameRF_tEdit.Enabled = enabled;
			//this.tEdit_BLGoodsHalfName.Enabled = enabled;
			//this.BLGoodsGenreCodeRF_tNedit.Enabled = enabled;
			//this.LargeGoodsGanreCodeRF_tUltraBtn.Enabled = enabled;

			//this.LargeGoodsGanreCodeRF_tEdit.Enabled = false;
			//this.MediumGoodsGanreCodeRF_tEdit.Enabled = false;
			//this.DetailGoodsGanreCodeRF_tEdit.Enabled = false;
			//this.LargeGoodsGanreNameRF_tEdit.Enabled = false;
			//this.MediumGoodsGanreNameRF_tEdit.Enabled = false;
			//this.DetailGoodsGanreNameRF_tEdit.Enabled = false;

			//----- ueno add ---------- end 2008.03.31
		}

		/// <summary>
        /// �a�k���i�R�[�h�}�X�^ �N���X��ʓW�J����
		/// </summary>
		/// <param name="bLGoodsCdUMnt">�a�k���i�R�[�h�}�X�^ �I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �a�k���i�R�[�h�}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void MakerUMntToScreen(BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			this.Guid_Label.Text = bLGoodsCdUMnt.FileHeaderGuid.ToString();
			this.Division_Label.Text = bLGoodsCdUMnt.Division.ToString();
			this.DivisionName_Label.Text = bLGoodsCdUMnt.DivisionName;

			//this.BLGoodsCodeRF_tNedit.Text = bLGoodsCdUMnt.BLGoodsCode.ToString();
			this.tNedit_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);

			//this.BLGoodsCdDerivedNoRF_tNedit.Text = bLGoodsCdUMnt.BLGoodsCdDerivedNo.ToString();
			this.BLGoodsFullNameRF_tEdit.Text = bLGoodsCdUMnt.BLGoodsFullName;
			this.tEdit_BLGoodsHalfName.Text = bLGoodsCdUMnt.BLGoodsHalfName;
			//this.BLGoodsGenreCodeRF_tNedit.Text = bLGoodsCdUMnt.BLGoodsGenreCode.ToString();

            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			this.BLGoodsGenreCodeRF_tNedit.SetInt(bLGoodsCdUMnt.BLGoodsGenreCode);
			this.LargeGoodsGanreCodeRF_tEdit.Text = bLGoodsCdUMnt.LargeGoodsGanreCode;
			this.LargeGoodsGanreNameRF_tEdit.Text = bLGoodsCdUMnt.LargeGoodsGanreName;
			this.MediumGoodsGanreCodeRF_tEdit.Text = bLGoodsCdUMnt.MediumGoodsGanreCode;
			this.MediumGoodsGanreNameRF_tEdit.Text = bLGoodsCdUMnt.MediumGoodsGanreName;
			this.DetailGoodsGanreCodeRF_tEdit.Text = bLGoodsCdUMnt.DetailGoodsGanreCode;
			this.DetailGoodsGanreNameRF_tEdit.Text = bLGoodsCdUMnt.DetailGoodsGanreName;
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            this.EquipGenre_tComboEditor.Value = bLGoodsCdUMnt.BLGoodsGenreCode;
            this.tNedit_BLGloupCode.SetInt(bLGoodsCdUMnt.BLGloupCode);
            this.BLGloupName_tEdit.DataText = GetBLGroupName(bLGoodsCdUMnt.BLGloupCode);
            this.tNedit_GoodsRateGrpCode.SetInt(bLGoodsCdUMnt.GoodsRateGrpCode);
            this.GoodsRateGrpName_tEdit.DataText = GetGoodsRateGrpName(bLGoodsCdUMnt.GoodsRateGrpCode);
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
        }

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>
        /// ��ʏ��a�k���i�R�[�h�}�X�^ �N���X�i�[����
		/// </summary>
		/// <param name="bLGoodsCdUMnt">�a�k���i�R�[�h�}�X�^ �I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʏ�񂩂�a�k���i�R�[�h�}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void DispToBLGoodsCdUMnt(ref BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			if (bLGoodsCdUMnt == null)
			{
				// �V�K�̏ꍇ
				bLGoodsCdUMnt = new BLGoodsCdUMnt();
			}

			//�f�[�^�敪
			bLGoodsCdUMnt.EnterpriseCode = this._enterpriseCode;

			if (this.Division_Label.Text == null || this.Division_Label.Text == "")
			{
				bLGoodsCdUMnt.Division = DIVISION_USR;
			}
			else
			{
				bLGoodsCdUMnt.Division = int.Parse(this.Division_Label.Text);
			}
			bLGoodsCdUMnt.DivisionName = this.DivisionName_Label.Text;


			//BL���i�R�[�h
			if (this.tNedit_BLGoodsCode.Text == "0"
                || this.tNedit_BLGoodsCode.Text == "")
            {
				bLGoodsCdUMnt.BLGoodsCode = 0;
				//makerU.GoodsMakerCd = "";
			}
            else
            {
				bLGoodsCdUMnt.BLGoodsCode = int.Parse(this.tNedit_BLGoodsCode.Text);
            }

			//BL���i�R�[�h�}��
			//if (this.BLGoodsCdDerivedNoRF_tNedit.Text == "0"
			//	|| this.BLGoodsCdDerivedNoRF_tNedit.Text == "")
			//{
			//	//bLGoodsCdUMnt.BLGoodsCdDerivedNo = 0;
			//	//makerU.BLGoodsCdDerivedNo = "";
			//}
			//else
			//{
			//	bLGoodsCdUMnt.BLGoodsCdDerivedNo = int.Parse(this.BLGoodsCdDerivedNoRF_tNedit.Text);
			//}


			//BL���i�R�[�h���́i�S�p�j
			bLGoodsCdUMnt.BLGoodsFullName = this.BLGoodsFullNameRF_tEdit.Text;
			//BL���i�R�[�h���́i���p�j
			bLGoodsCdUMnt.BLGoodsHalfName = this.tEdit_BLGoodsHalfName.Text;
			//BL���i����
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            if (this.EquipGenre_tComboEditor.Value == null)
            {
                bLGoodsCdUMnt.BLGoodsGenreCode = EQUIPGANRE_CODE_0;
            }
            else
            {
                bLGoodsCdUMnt.BLGoodsGenreCode = (int)this.EquipGenre_tComboEditor.Value;
            }
            // BL�O���[�v�R�[�h
            bLGoodsCdUMnt.BLGloupCode = this.tNedit_BLGloupCode.GetInt();
            // ���i�|���O���[�v�R�[�h
            bLGoodsCdUMnt.GoodsRateGrpCode = this.tNedit_GoodsRateGrpCode.GetInt();
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			if (this.BLGoodsGenreCodeRF_tNedit.Text == "0"
				|| this.BLGoodsGenreCodeRF_tNedit.Text == "")
			{
				bLGoodsCdUMnt.BLGoodsGenreCode = 0;
			}
			else
			{
				bLGoodsCdUMnt.BLGoodsGenreCode = int.Parse(this.BLGoodsGenreCodeRF_tNedit.Text);
			}
			//���i�敪�O���[�v�R�[�h
			bLGoodsCdUMnt.LargeGoodsGanreCode = this.LargeGoodsGanreCodeRF_tEdit.Text;
			//���i�敪�O���[�v����
			bLGoodsCdUMnt.LargeGoodsGanreName = this.LargeGoodsGanreNameRF_tEdit.Text;
			//���i�敪�R�[�h
			bLGoodsCdUMnt.MediumGoodsGanreCode = this.MediumGoodsGanreCodeRF_tEdit.Text;
			//���i�敪����
			bLGoodsCdUMnt.MediumGoodsGanreName = this.MediumGoodsGanreNameRF_tEdit.Text;
			//���i�敪�ڍ׃R�[�h
			bLGoodsCdUMnt.DetailGoodsGanreCode = this.DetailGoodsGanreCodeRF_tEdit.Text;
			//���i�敪�ڍז���
			bLGoodsCdUMnt.DetailGoodsGanreName = this.DetailGoodsGanreNameRF_tEdit.Text;
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        }

        #region DEL 2008/06/10 Partsman�p�ɕύX
        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
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
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
		{
			bool result = true;

            //if (this.LargeGoodsGanreCodeRF_tNedit.Text == "0" || this.LargeGoodsGanreCodeRF_tNedit.Text == "")
            if ((this.tNedit_BLGoodsCode.Text == "") || (this.tNedit_BLGoodsCode.Text == "0"))
			{
				// BL���i�R�[�h
				control = this.tNedit_BLGoodsCode;
				message = this.BLGoodsCode_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
            //else if (this.BLGoodsCdDerivedNoRF_tNedit.Text.Trim() == "")
            //{
            //	// BL���i�R�[�h�}��
            //	control = this.BLGoodsCdDerivedNoRF_tNedit;
            //	message = this.BLGoodsCode_Title_Label.Text + "����͂��ĉ������B";
            //	result = false;
            //}
            else if (this.BLGoodsFullNameRF_tEdit.Text.Trim() == "")
            {
                // BL���i����
                control = this.BLGoodsFullNameRF_tEdit;
                message = this.BLGoodsFullName_Title_Label.Text + "����͂��ĉ������B";
                result = false;
            }
            else if (this.tEdit_BLGoodsHalfName.Text.Trim() == "")
            {
                // BL���i����(�J�i)
                control = this.tEdit_BLGoodsHalfName;
                message = this.BLGoodsHalfName_Title_Label.Text + "����͂��ĉ������B";
                result = false;
            }
			else if ((this.BLGoodsGenreCodeRF_tNedit.Text == "") || (this.BLGoodsGenreCodeRF_tNedit.Text == "0"))
			{
				// BL���i����
				control = this.BLGoodsGenreCodeRF_tNedit;
				message = this.BLGoodsGenreCode_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
            
            return result;
		}
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/10 Partsman�p�ɕύX

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="loginID">���O�C��ID</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            if ((this.tNedit_BLGoodsCode.Text == "") || (this.tNedit_BLGoodsCode.Text == "0"))
            {
                // BL���i�R�[�h
                control = this.tNedit_BLGoodsCode;
                message = this.BLGoodsCode_Title_Label.Text + "����͂��ĉ������B";
                return (false);
            }

            if (this._divisionCode == DIVISION_USR)
            {
                if (this.tNedit_BLGoodsCode.GetInt() < 9000)
                {
                    control = this.tNedit_BLGoodsCode;
                    message = "BL���ނ�9000�ȏ�̐��l����͂��Ă��������B";
                    return (false);
                }
            }

            if (this.BLGoodsFullNameRF_tEdit.Text.Trim() == "")
            {
                // BL���i����
                control = this.BLGoodsFullNameRF_tEdit;
                message = this.BLGoodsFullName_Title_Label.Text + "����͂��ĉ������B";
                return (false);
            }

            if (this.tEdit_BLGoodsHalfName.Text.Trim() == "")
            {
                // BL���i����(�J�i)
                control = this.tEdit_BLGoodsHalfName;
                message = this.BLGoodsHalfName_Title_Label.Text + "����͂��ĉ������B";
                return (false);
            }

            if (this.EquipGenre_tComboEditor.Value == null)
            {
                // ��������
                control = this.EquipGenre_tComboEditor;
                message = this.BLGoodsGenreCode_Title_Label.Text + "��I�����ĉ������B";
                return (false);
            }

            if (this.tNedit_BLGloupCode.DataText != "")
            {
                // BL�O���[�v�R�[�h
                if (GetBLGroupName(this.tNedit_BLGloupCode.GetInt()) == "")
                {
                    control = this.tNedit_BLGloupCode;
                    message = "�}�X�^�ɓo�^����Ă��܂���B";
                    return (false);
                }
            }

            if (this.tNedit_GoodsRateGrpCode.DataText != "")
            {
                // ���i�|���O���[�v�R�[�h
                if (GetGoodsRateGrpName(this.tNedit_GoodsRateGrpCode.GetInt()) == "")
                {
                    control = this.tNedit_GoodsRateGrpCode;
                    message = "�}�X�^�ɓo�^����Ă��܂���B";
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// BL�O���[�v�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�ꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private void ReadBLGroup()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            ArrayList retList;

            int status = this._bLGroupUAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (BLGroupU bLGroupU in retList)
                {
                    if (bLGroupU.LogicalDeleteCode == 0)
                    {
                        this._blGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// BL�O���[�v���̎擾����
        /// </summary>
        /// <param name="blGroupCode">BL�O���[�v�R�[�h</param>
        /// <remarks>
        /// <br>Note       : BL�O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            string blGroupName = "";

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
            }

            return blGroupName;
        }

        /// <summary>
        /// ���i�|���O���[�v�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�|���O���[�v�ꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private void ReadGoodsRateGrp()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            ArrayList retList;

            int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (GoodsGroupU goodsGroupU in retList)
                {
                    if (goodsGroupU.LogicalDeleteCode == 0)
                    {
                        this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// ���i�|���O���[�v���̎擾����
        /// </summary>
        /// <param name="goodsGroupUCode">���i�|���O���[�v�R�[�h</param>
        /// <remarks>
        /// <returns>���i�|���O���[�v����</returns>
        /// <br>Note       : ���i�|���O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private string GetGoodsRateGrpName(int goodsGroupUCode)
        {
            string goodsGroupUName = "";

            if (this._goodsGroupUDic.ContainsKey(goodsGroupUCode))
            {
                goodsGroupUName = this._goodsGroupUDic[goodsGroupUCode].GoodsMGroupName.Trim();
            }

            return goodsGroupUName;
        }

        /// <summary>
        /// �������ޖ��̎擾����
        /// </summary>
        /// <param name="goodsRateGrpCode">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �������ޖ��̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private string GetEquipGenreName(int EquipGenreCode)
        {
            string EquipGenreName = "";

            switch (EquipGenreCode)
            {
                case EQUIPGANRE_CODE_0:
                    EquipGenreName = EQUIPGANRE_NAME_0;
                    break;
                case EQUIPGANRE_CODE_1001:
                    EquipGenreName = EQUIPGANRE_NAME_1001;
                    break;
                case EQUIPGANRE_CODE_1005:
                    EquipGenreName = EQUIPGANRE_NAME_1005;
                    break;
                case EQUIPGANRE_CODE_1010:
                    EquipGenreName = EQUIPGANRE_NAME_1010;
                    break;
                default:
                    break;
            }

            return EquipGenreName;
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ� False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̔�r���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            bLGoodsCdUMnt = this._makerUClone.Clone();

            // ��ʏ��擾
            DispToBLGoodsCdUMnt(ref bLGoodsCdUMnt);
            
            // �ŏ��Ɏ擾������ʏ��Ɣ�r
            if (!(this._makerUClone.Equals(bLGoodsCdUMnt)))
            {
                //��ʏ�񂪕ύX����Ă����ꍇ
                return (false);
            }

            return (true);
        }

        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

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

		//----- ueno add ---------- start 2008.02.29
		# region HashTable�pKey�쐬
		/// <summary>
		/// HashTable�pKey�쐬
		/// </summary>
		/// <param name="bLGoodsCdUMnt">�a�k���i�N���X</param>
		/// <returns>Hash�pKey</returns>
		/// <remarks>
		/// <br>Note       : �a�k���i�N���X����n�b�V���e�[�u���p��
		///					 �L�[���쐬���܂��B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.02.29</br>
		/// </remarks>
		private string CreateHashKey(BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			return bLGoodsCdUMnt.BLGoodsCode.ToString("d8");
		}
		#endregion HashTable�pKey�쐬
		//----- ueno add ---------- end 2008.02.29

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/6/9</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_BLGoodsCode.Size = new System.Drawing.Size(60, 24);
            this.BLGoodsFullNameRF_tEdit.Size = new System.Drawing.Size(337, 24);
            this.tEdit_BLGoodsHalfName.Size = new System.Drawing.Size(337, 24);
            this.EquipGenre_tComboEditor.Size = new System.Drawing.Size(151, 24);
            this.tNedit_BLGloupCode.Size = new System.Drawing.Size(52, 24);
            this.BLGloupName_tEdit.Size = new System.Drawing.Size(337, 24);
            this.tNedit_GoodsRateGrpCode.Size = new System.Drawing.Size(52, 24);
            this.GoodsRateGrpName_tEdit.Size = new System.Drawing.Size(337, 24);
        }
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

		# endregion

		#region ��Control Events
		/// <summary>
		/// Form.Load �C�x���g(DCKHN09090UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void DCKHN09090UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            //this.LargeGoodsGanreCodeRF_tUltraBtn.ImageList = imageList16;  // DEL 2008/06/10

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            //this.LargeGoodsGanreCodeRF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;  // DEL 2008/06/10

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.BLGloupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
        /// Form.Closing �C�x���g(DCKHN09090UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void DCKHN09090UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// Control.VisibleChanged �C�x���g(DCKHN09090UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void DCKHN09090UA_VisibleChanged(object sender, System.EventArgs e)
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

            // ��ʃN���A
			ScreenClear();

            Initial_Timer.Enabled = true;
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
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            if ((this._divisionCode == DIVISION_OFR) && (CompareOriginalScreen() == true))
            {
                // �񋟃f�[�^�@���@��ʏ�񖢕ύX�̏ꍇ
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
            else
            {
                if (SaveProc() == false)
                {
                    return;
                }
            }
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			if (SaveProc() == false)
			{
				return;
			}
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            
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

				//----- ueno upd ---------- start 2008.03.31
                // ��ʓ��͋����䏈��
				ScreenInputPermissionControl(INSERT_MODE);
				//----- ueno upd ---------- end 2008.03.31

				// �N���[�����ēx�擾����
				BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
				
				//�N���[���쐬
				this._makerUClone = bLGoodsCdUMnt.Clone(); 

                // ��ʏ��i�[
				DispToBLGoodsCdUMnt(ref this._makerUClone);

				this.tNedit_BLGoodsCode.Focus();
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
        /// �a�k���i�R�[�h�}�X�^ ���o�^����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
        /// <br>Note       : �a�k���i�R�[�h�}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private bool SaveProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			Control control = null;
			string message = null;
			string loginID = "";

			BLGoodsCdUMnt bLGoodsCdUMnt = null;

			if (this.DataIndex >= 0)
			{
				//----- ueno upd ---------- start 2008.02.29
				// �n�b�V���L�[�擾
				string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[hashKey]).Clone();

				//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[guid]).Clone();
				//----- ueno upd ---------- end 2008.02.29
			}

            // ���̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
				TMsgDisp.Show( 
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
					message,							// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);				// �\������{�^��

				control.Focus();
				return false;
			}

            // ��ʏ��i�[
			this.DispToBLGoodsCdUMnt(ref bLGoodsCdUMnt);

			status = this._bLGoodsCdAcs.Write(ref bLGoodsCdUMnt);
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

					this.tNedit_BLGoodsCode.Focus();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // �r������
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._bLGoodsCdAcs);

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
						this._bLGoodsCdAcs,					// �G���[�����������I�u�W�F�N�g
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
			MakerUMntToDataSet(bLGoodsCdUMnt, this.DataIndex);
			
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
                // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                // ��ʏ���r
                if (!CompareOriginalScreen())
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (SaveProc() == false)
                                {
                                    return;
                                }

                                this.DialogResult = DialogResult.OK;

                                break;
                            }
                        case DialogResult.No:
                            {
                                this.DialogResult = DialogResult.Cancel;

                                break;
                            }
                        default:
                            {
                                // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tNedit_BLGoodsCode.Focus();
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
                // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

                /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
				//�ۑ��m�F
				BLGoodsCdUMnt compareBLGoodsCdUMnt = new BLGoodsCdUMnt();
				compareBLGoodsCdUMnt = this._makerUClone.Clone();  

				//���݂̉�ʏ����擾����
				DispToBLGoodsCdUMnt(ref compareBLGoodsCdUMnt);

				//�ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._makerUClone.Equals(compareBLGoodsCdUMnt)))	
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
							this.Cancel_Button.Focus();
							return;
						}
					}
				}
                   --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
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
				//----- ueno upd ---------- start 2008.02.29
				// �n�b�V���L�[�擾
				string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[hashKey]).Clone();

				//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[guid]).Clone();
				//----- ueno upd ---------- end 2008.02.29

				status = this._bLGoodsCdAcs.Delete(bLGoodsCdUMnt);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();

						//----- ueno upd ---------- start 2008.02.29
						this._bLGoodsCdUMntTable.Remove(hashKey);
						//this._bLGoodsCdUMntTable.Remove(bLGoodsCdUMnt.FileHeaderGuid);
						//----- ueno upd ---------- end 2008.02.29

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
                        // �r������
						ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._bLGoodsCdAcs);

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
							this._bLGoodsCdAcs,					  // �G���[�����������I�u�W�F�N�g
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
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			//----- ueno upd ---------- start 2008.02.29
			// �n�b�V���L�[�擾
			string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
			BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)_bLGoodsCdUMntTable[hashKey]).Clone();

			//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
			//BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)_bLGoodsCdUMntTable[guid]).Clone();
			//----- ueno upd ---------- end 2008.02.29

			status = this._bLGoodsCdAcs.Revival(ref bLGoodsCdUMnt);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // �r��
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._bLGoodsCdAcs);

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
						this._bLGoodsCdAcs,					  // �G���[�����������I�u�W�F�N�g
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
			MakerUMntToDataSet(bLGoodsCdUMnt, this.DataIndex);

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

            // �e��}�X�^�Ǎ�
            ReadBLGroup();
            ReadGoodsRateGrp();

            // ��ʍč\�z����
			ScreenReconstruction();
		}

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Control.Click �C�x���g(BLGloupGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : BL�O���[�v�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private void BLGloupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU bLGroupU = new BLGroupU();
                BLGroupUAcs bLGroupUAcs = new BLGroupUAcs();

                status = bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);
                if (status == 0)
                {
                    this.tNedit_BLGloupCode.SetInt(bLGroupU.BLGroupCode);
                    this.BLGloupName_tEdit.DataText = bLGroupU.BLGroupName.Trim();

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_GoodsRateGrpCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(GoodsRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : ���i�|���O���[�v�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private void GoodsRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();
                GoodsGroupUAcs goodsGroupUAcs = new GoodsGroupUAcs();

                status = goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
                if (status == 0)
                {
                    this.tNedit_GoodsRateGrpCode.SetInt(goodsGroupU.GoodsMGroup);
                    this.GoodsRateGrpName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();

                    // �t�H�[�J�X�ݒ�
                    //this.Ok_Button.Focus();
                    this.Renewal_Button.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// TEdit.ValueChanged �C�x���g �C�x���g(Name_tEdit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���̂�ύX�����ۂɔ������܂��B</br>
        /// <br>Programmer  : 30414 �E�@�K�j</br>
        /// <br>Date        : 2008/06/10</br>
        /// </remarks>
        private void BLGoodsFullNameRF_tEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.BLGoodsFullNameRF_tEdit.DataText.Equals(""))
            {
                this.tEdit_BLGoodsHalfName.Clear();
            }
        }

        /// <summary>
        /// ValueChanged �C�x���g(tEdit_BLGoodsHalfName)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̒l���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/11</br>
        /// </remarks>
        private void tEdit_BLGoodsHalfName_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = (TEdit)sender;

            // ���p�ɕϊ�
            tEdit.Text = Strings.StrConv(tEdit.Text.Trim(), VbStrConv.Narrow, 0);
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_BLGloupCode":
                    if ((this.tNedit_BLGloupCode.DataText == "") || (this.tNedit_BLGloupCode.GetInt() == 0))
                    {
                        this.BLGloupName_tEdit.DataText = "";
                        return;
                    }

                    // BL�O���[�v�R�[�h�擾
                    int bLGroupCode = this.tNedit_BLGloupCode.GetInt();

                    // BL�O���[�v���̎擾
                    this.BLGloupName_tEdit.DataText = GetBLGroupName(bLGroupCode);

                    if (e.Key == Keys.Enter)
                    {
                        // �t�H�[�J�X�ݒ�
                        if (this.BLGloupName_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_GoodsRateGrpCode;
                        }
                    }
                    break;
                case "tNedit_GoodsRateGrpCode":
                    if ((this.tNedit_GoodsRateGrpCode.DataText == "") || (this.tNedit_GoodsRateGrpCode.GetInt() == 0))
                    {
                        this.GoodsRateGrpName_tEdit.DataText = "";
                        return;
                    }

                    // ���i�|���O���[�v�R�[�h�擾
                    int goodsRateGrpCode = this.tNedit_GoodsRateGrpCode.GetInt();

                    // ���i�|���O���[�v���̎擾
                    this.GoodsRateGrpName_tEdit.DataText = GetGoodsRateGrpName(goodsRateGrpCode);

                    if (e.Key == Keys.Enter)
                    {
                        // �t�H�[�J�X�ݒ�
                        if (this.GoodsRateGrpName_tEdit.DataText.Trim() != "")
                        {
                            //e.NextCtrl = this.Ok_Button;
                            e.NextCtrl = this.Renewal_Button;
                        }
                    }
                    break;
                case "tNedit_BLGoodsCode":
                    // BL���i�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Right)
                    {
                        // BL���i���̂Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = BLGoodsFullNameRF_tEdit;
                    }

                    // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = tNedit_BLGoodsCode;
                        }
                    }
                    // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                    break;
                case "EquipGenre_tComboEditor":
                    // �������ނɃt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Down)
                    {
                        // BL�O���[�v�R�[�h�Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = tNedit_BLGloupCode;
                    }
                    break;
                case "Ok_Button":
                case "Cancel_Button":
                    // �ۑ��{�^���A����{�^���Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Up)
                    {
                        // ���i�|���O���[�v�K�C�h�{�^���Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = GoodsRateGrpGuide_Button;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            ReadBLGroup();
            ReadGoodsRateGrp();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "DCKHN09090U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // BL�R�[�h
            int blGoodsCode = tNedit_BLGoodsCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsBLGoodsCode = int.Parse((string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][BLGoodsCode_TITLE]);
                if (blGoodsCode == dsBLGoodsCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��BL�R�[�h�}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // BL�R�[�h�̃N���A
                        tNedit_BLGoodsCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h��BL�R�[�h�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // BL�R�[�h�̃N���A
                                tNedit_BLGoodsCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
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
		}
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        
# endregion

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		# region �K�C�h����
		/// <summary>
		/// ���i�K�C�h
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LargeGoodsGanreCodeRF_tUltraBtn_Click(object sender, EventArgs e)
		{
			if (sender is UltraButton)
			{
				DGoodsGanreAcs dGoodsGanreAcs = new DGoodsGanreAcs();
				DGoodsGanre dGoodsGanre = new DGoodsGanre();

				if (dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre, 1) == 0)
				{
					//�啪��
					this.LargeGoodsGanreCodeRF_tEdit.Text = dGoodsGanre.LargeGoodsGanreCode;
					this.LargeGoodsGanreNameRF_tEdit.Text = dGoodsGanre.LargeGoodsGanreName;

					//������
					this.MediumGoodsGanreCodeRF_tEdit.Text = dGoodsGanre.MediumGoodsGanreCode;
					this.MediumGoodsGanreNameRF_tEdit.Text = dGoodsGanre.MediumGoodsGanreName;


					//������
					this.DetailGoodsGanreCodeRF_tEdit.Text = dGoodsGanre.DetailGoodsGanreCode;
					this.DetailGoodsGanreNameRF_tEdit.Text = dGoodsGanre.DetailGoodsGanreName;

					this.LargeGoodsGanreCodeRF_tEdit.Focus();
				}
			}
			else
			{
				return;
			}			

		}

		# endregion
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
    }

    # region �a�k���i�R�[�h�}�X�^������͈̓N���X
    /// <summary>
    /// �a�k���i�R�[�h�}�X�^������͈̓N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �a�k���i�R�[�h�}�X�^������͈͂̃N���X�ł��B</br>
    /// <br>Programmer : 96186 ���ԗT��</br>
    /// <br>Date       : 2007.08.01</br>
    /// <br></br>
	/// </remarks>
	public class sendMakerUMntData
	{
		/// <summary>
        /// �a�k���i�R�[�h�}�X�^������͈̓N���X�f�[�^�Z�b�g����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����p�̃f�[�^�Z�b�g�ł��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public DataSet dataSet;

		/// <summary>
        /// �a�k���i�R�[�h�}�X�^���n�b�V���e�[�u��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����p�̃n�b�V���e�[�u���ł��B</br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public Hashtable emphashtable;
	}
	# endregion

    # region �a�k���i�R�[�h�}�X�^��������o�����N���X
    /// <summary>
    /// �a�k���i�R�[�h�}�X�^��������o�����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �a�k���i�R�[�h�}�X�^��������o�����̃N���X�ł��B</br>
    /// <br>Programmer : 96186 ���ԗT��</br>
    /// <br>Date       : 2007.08.01</br>
    /// <br></br>
	/// </remarks>
	public class ConditionData
	{
		/// <summary>
        /// �J�n�a�k���i�R�[�h�}�X�^�R�[�h
		/// </summary>
		public int StartMakerUMntCode;
		/// <summary>
        /// �I���a�k���i�R�[�h�}�X�^�R�[�h
		/// </summary>
        public int EndMakerUMntCode;
	}
	# endregion
}
