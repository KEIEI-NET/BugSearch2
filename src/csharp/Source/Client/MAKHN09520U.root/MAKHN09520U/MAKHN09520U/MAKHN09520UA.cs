# region ��using
using Infragistics.Win.Misc;
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// ���i�Ǘ����}�X�^ �t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: ���i�Ǘ����̐ݒ���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer  : 980035 ����@��`</br>
    /// <br>Date        : 2007.08.27</br>
    /// <br>Update Note : 2008.02.28 980035 ���� ��`</br>
    /// <br>              �E�s��Ή�</br>
	/// <br>Update Note : 2008.03.28 30167 ���@�O�M</br>
	///	<br>			  �E�A���o�^���A2���ڈȍ~���_�f�[�^���ݒ肳��Ȃ��s��C��</br>
	/// <br>Update Note : 2008.03.28 30167 ���@�O�M</br>
	///	<br>			  �E���_�R�[�h�[���f�[�^���\���E�ݒ�ł��Ȃ��s��C��</br>
	/// <br>Update Note : 2008.03.31 30167 ���@�O�M</br>
	///	<br>			  �E���_�R�[�h�A�N�e�B�u���̕\���s��C��</br>
    /// <br></br>
    /// <br>Update Note : 2008.04.24 20056 ���n ���</br>
    ///	<br>			�EPM.NS ���ʏC�� ���Ӑ�E�d���敪���Ή�</br>
    /// <br>Update Note : 2008.08.22 30350 �N�� ����</br>
    ///	<br>			�EPM.NS�p�ɏC��</br>
    /// <br>Update Note : 2009.08.02 22008 ���� ���n</br>
    ///	<br>			�E�����ރR�[�h�ݒ�̃��R�[�h�͍폜�s�Ƃ���</br>
    /// <br>Update Note : 2009/11/25 30517 �Ė� �x��</br>
    ///	<br>			�EMANTIS:13894 ���_+�i�ԂŐV�K���[�h�̎���BL�R�[�h�ƒ����ނ�\�����Ȃ�</br>
    /// <br>Update Note : 2010/12/03 ������</br>
    ///	<br>			�E���_�{���[�J�[�V�K�o�^���̕s��C��</br>
    /// <br>Update Note : 2012/09/21 ���� redmine#32367</br>
    /// <br>�� �� �� �� : 10801804-00</br>
    ///	<br>			�E���_�{�����ށ{���[�J�[�{BL�R�[�h�Ƌ��_�{�����ށ{���[�J�[�̒ǉ�</br>
    /// <br>Update Note : 2012/10/08 ������ redmine#32367</br>
    /// <br>�� �� �� �� : 10801804-00 2012/11/14�z�M��</br>
    ///	<br>			�E��Q�ꗗ�̑Ή� �p�^���u���_�{�����ށ{���[�J�[�{BL�R�[�h�v</br>
    /// <br>Update Note : 2018/11/08 ���O</br>
    /// <br>�� �� �� �� : 11370033-00</br>
    ///	<br>			�Eredmine#49781 ���i�Ǘ����}�X�^�̍폜�d�l�ύX�̑Ή�</br>
    /// </remarks>
    public class MAKHN09520UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region ��Private Const
        // --- ADD 2018/11/08 ���O for redmine#49781 ---------->>>>>
        /// <summary>�폜�̊m�F���b�Z�[�W</summary>
        private const string DeleteMessage = "�D�ǐݒ�}�X�^�ō쐬���ꂽ���R�[�h�ł��B" + "\r\n" +
                                             "���S�폜�ƂȂ�܂����A��낵���ł����H" + "\r\n" + "\r\n" +
                                             "�폜��A�Đݒ肷��ꍇ�͗D�ǐݒ�}�X�^���" + "\r\n" +
                                             "�ݒ肵�Ă��������B";
        // --- ADD 2018/11/08 ���O for redmine#49781 ----------<<<<<
        # endregion
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
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TEdit tEdit_SectionCodeAllowZero;
        private TNedit tNedit_SupplierLot;
        private TEdit SupplierNm_tEdit;
        private TNedit tNedit_SupplierCd;
        private TEdit SectionName_tEdit;
        private UltraLabel SectionCode_Label;
        private UltraLabel GoodsMakerCd_Label;
        private UltraLabel ParentGoodsCode_Label;
        private TNedit tNedit_GoodsMakerCd;
        private UltraLabel BLGoodsCode_Label;
        private TNedit tNedit_BLGoodsCode;
        private TEdit tEdit_GoodsNo;
        private TEdit GoodsName_tEdit;
        private TEdit GoodsMakerName_tEdit;
        private UiSetControl uiSetControl1;
        private UltraLabel SupplierLot_Label;
        private UltraLabel SupplierCd_Label;
        private UltraLabel ultraLabel1;
        private TEdit BLGoodsName_tEdit;
        private UltraLabel SetKind_Label;
        private UltraLabel ultraLabel6;
        private TComboEditor SetKind_tComboEditor;
        private UltraLabel ultraLabel17;
        private UltraButton SupplierGd_ultraButton;
        private UltraButton BLGoodsGuide_Button;
        private UltraButton GoodsMakerGuide_Button;
        private UltraButton SectionGuide_Button;
        private TNedit tNedit_GoodsMGroup;
        private UltraLabel ultraLabel2;
        private UltraButton GoodsMGroupGuidButton;
        private TEdit tEdit_GoodsMGroupName;
		private System.ComponentModel.IContainer components;
        private Int32 _blGoodsCode = 0;//ADD 2012/09/21 ���� for redmine#32367 

		# endregion

		# region ��Constructor
		/// <summary>
        /// ���i�Ǘ����}�X�^ �t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
		/// </remarks>
        public MAKHN09520UA()
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
            this._defaultAutoFillToColumn = true;
            this._canSpecificationSearch = false;

			//�@��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 2008.02.28 �ǉ� >>>>>>>>>>>>>>>>>>>>
            //�@���O�C���S���ҏ������_�R�[�h�擾
            this._belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._belongSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
            // 2008.02.28 �ǉ� <<<<<<<<<<<<<<<<<<<<

			// �ϐ�������
			this._dataIndex = -1;
            this._goodsMngAcs = new GoodsMngAcs();
			 
			this._totalCount = 0;
            this._goodsMngTable = new Hashtable();

            this._supplierAcs = new SupplierAcs(); // ADD 2008.04.24
            this._bLGoodsCdAcs = new BLGoodsCdAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();

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
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKHN09520UA));
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
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SupplierLot = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsMakerCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ParentGoodsCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.SupplierLot_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGoodsCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SetKind_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.SetKind_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsMakerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.BLGoodsGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SupplierGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMGroup = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_GoodsMGroupName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMGroupGuidButton = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKind_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsMGroupName)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(434, 355);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            //this.Ok_Button.TabIndex = 14; //DEL 2012/09/21 ���� for redmine#32367
            this.Ok_Button.TabIndex = 16; //ADD 2012/09/21 ���� for redmine#32367
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 398);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(700, 23);
            this.ultraStatusBar1.TabIndex = 11;
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
            appearance56.ForeColor = System.Drawing.Color.White;
            appearance56.TextHAlignAsString = "Center";
            appearance56.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance56;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(575, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 12;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(309, 355);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            //this.Delete_Button.TabIndex = 13; //DEL 2012/09/21 ���� for redmine#32367
            this.Delete_Button.TabIndex = 15; //ADD 2012/09/21 ���� for redmine#32367
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(434, 355);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            //this.Revive_Button.TabIndex = 15; //DEL 2012/09/21 ���� for redmine#32367
            this.Revive_Button.TabIndex = 17; //ADD 2012/09/21 ���� for redmine#32367
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(559, 355);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            //this.Cancel_Button.TabIndex = 16; //DEL 2012/09/21 ���� for redmine#32367
            this.Cancel_Button.TabIndex = 18; //ADD 2012/09/21 ���� for redmine#32367
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
            this.tImeControl1.InControl = null;
            this.tImeControl1.OutControl = null;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 30;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero.Appearance = appearance2;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(125, 100);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 1;
            this.tEdit_SectionCodeAllowZero.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.tEdit_SectionCodeAllowZero_BeforeEnterEditMode);
            // 
            // tNedit_SupplierLot
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance28.TextHAlignAsString = "Right";
            this.tNedit_SupplierLot.ActiveAppearance = appearance28;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            this.tNedit_SupplierLot.Appearance = appearance29;
            this.tNedit_SupplierLot.AutoSelect = true;
            this.tNedit_SupplierLot.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierLot.DataText = "";
            this.tNedit_SupplierLot.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierLot.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.End, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierLot.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierLot.Location = new System.Drawing.Point(125, 320);
            this.tNedit_SupplierLot.MaxLength = 4;
            this.tNedit_SupplierLot.Name = "tNedit_SupplierLot";
            this.tNedit_SupplierLot.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SupplierLot.Size = new System.Drawing.Size(43, 24);
            //this.tNedit_SupplierLot.TabIndex = 12; //DEL 2012/09/21 ���� for redmine#32367
            this.tNedit_SupplierLot.TabIndex = 14; //ADD 2012/09/21 ���� for redmine#32367
            // 
            // SupplierNm_tEdit
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierNm_tEdit.ActiveAppearance = appearance35;
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance36.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance36.Cursor = System.Windows.Forms.Cursors.Default;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            appearance36.TextVAlignAsString = "Middle";
            this.SupplierNm_tEdit.Appearance = appearance36;
            this.SupplierNm_tEdit.AutoSelect = true;
            this.SupplierNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SupplierNm_tEdit.DataText = "";
            this.SupplierNm_tEdit.Enabled = false;
            this.SupplierNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SupplierNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SupplierNm_tEdit.Location = new System.Drawing.Point(190, 290);
            this.SupplierNm_tEdit.MaxLength = 20;
            this.SupplierNm_tEdit.Name = "SupplierNm_tEdit";
            this.SupplierNm_tEdit.Size = new System.Drawing.Size(330, 24);
            this.SupplierNm_tEdit.TabIndex = 28;
            this.SupplierNm_tEdit.Tag = "False";
            // 
            // tNedit_SupplierCd
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SupplierCd.ActiveAppearance = appearance37;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_SupplierCd.Appearance = appearance38;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(125, 290);
            this.tNedit_SupplierCd.MaxLength = 6;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(59, 24);
            //this.tNedit_SupplierCd.TabIndex = 10; //DEL 2012/09/21 ���� for redmine#32367
            this.tNedit_SupplierCd.TabIndex = 12; //ADD 2012/09/21 ���� for redmine#32367
            // 
            // SectionName_tEdit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionName_tEdit.ActiveAppearance = appearance40;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance41.Cursor = System.Windows.Forms.Cursors.Default;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextVAlignAsString = "Middle";
            this.SectionName_tEdit.Appearance = appearance41;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SectionName_tEdit.Location = new System.Drawing.Point(166, 100);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.Size = new System.Drawing.Size(82, 24);
            this.SectionName_tEdit.TabIndex = 3;
            this.SectionName_tEdit.Tag = "False";
            // 
            // SectionCode_Label
            // 
            this.SectionCode_Label.Location = new System.Drawing.Point(30, 103);
            this.SectionCode_Label.Name = "SectionCode_Label";
            this.SectionCode_Label.Size = new System.Drawing.Size(79, 23);
            this.SectionCode_Label.TabIndex = 0;
            this.SectionCode_Label.Text = "���_";
            // 
            // GoodsMakerCd_Label
            // 
            this.GoodsMakerCd_Label.Location = new System.Drawing.Point(30, 191);
            this.GoodsMakerCd_Label.Name = "GoodsMakerCd_Label";
            this.GoodsMakerCd_Label.Size = new System.Drawing.Size(79, 23);
            this.GoodsMakerCd_Label.TabIndex = 4;
            this.GoodsMakerCd_Label.Text = "���[�J�[";
            // 
            // ParentGoodsCode_Label
            // 
            this.ParentGoodsCode_Label.Location = new System.Drawing.Point(30, 132);
            this.ParentGoodsCode_Label.Name = "ParentGoodsCode_Label";
            this.ParentGoodsCode_Label.Size = new System.Drawing.Size(79, 23);
            this.ParentGoodsCode_Label.TabIndex = 8;
            this.ParentGoodsCode_Label.Text = "�i��";
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_GoodsMakerCd.Appearance = appearance6;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(125, 190);
            this.tNedit_GoodsMakerCd.MaxLength = 4;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 6;
            this.tNedit_GoodsMakerCd.ValueChanged += new System.EventHandler(this.tNedit_GoodsMakerCd_ValueChanged);
            // 
            // tEdit_GoodsNo
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_GoodsNo.Appearance = appearance45;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_GoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(125, 130);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(353, 24);
            this.tEdit_GoodsNo.TabIndex = 4;
            // 
            // GoodsName_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsName_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance47.Cursor = System.Windows.Forms.Cursors.Default;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextVAlignAsString = "Middle";
            this.GoodsName_tEdit.Appearance = appearance47;
            this.GoodsName_tEdit.AutoSelect = true;
            this.GoodsName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GoodsName_tEdit.DataText = "";
            this.GoodsName_tEdit.Enabled = false;
            this.GoodsName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GoodsName_tEdit.Location = new System.Drawing.Point(125, 160);
            this.GoodsName_tEdit.MaxLength = 15;
            this.GoodsName_tEdit.Name = "GoodsName_tEdit";
            this.GoodsName_tEdit.Size = new System.Drawing.Size(345, 24);
            this.GoodsName_tEdit.TabIndex = 5;
            this.GoodsName_tEdit.Tag = "False";
            // 
            // GoodsMakerName_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsMakerName_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance8.Cursor = System.Windows.Forms.Cursors.Default;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.GoodsMakerName_tEdit.Appearance = appearance8;
            this.GoodsMakerName_tEdit.AutoSelect = true;
            this.GoodsMakerName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GoodsMakerName_tEdit.DataText = "";
            this.GoodsMakerName_tEdit.Enabled = false;
            this.GoodsMakerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsMakerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsMakerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GoodsMakerName_tEdit.Location = new System.Drawing.Point(174, 190);
            this.GoodsMakerName_tEdit.MaxLength = 30;
            this.GoodsMakerName_tEdit.Name = "GoodsMakerName_tEdit";
            this.GoodsMakerName_tEdit.Size = new System.Drawing.Size(314, 24);
            this.GoodsMakerName_tEdit.TabIndex = 24;
            this.GoodsMakerName_tEdit.Tag = "False";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // SupplierLot_Label
            // 
            this.SupplierLot_Label.Location = new System.Drawing.Point(30, 321);
            this.SupplierLot_Label.Name = "SupplierLot_Label";
            this.SupplierLot_Label.Size = new System.Drawing.Size(91, 23);
            this.SupplierLot_Label.TabIndex = 294;
            this.SupplierLot_Label.Text = "���ʃ��b�g";
            // 
            // SupplierCd_Label
            // 
            this.SupplierCd_Label.Location = new System.Drawing.Point(30, 291);
            this.SupplierCd_Label.Name = "SupplierCd_Label";
            this.SupplierCd_Label.Size = new System.Drawing.Size(91, 23);
            this.SupplierCd_Label.TabIndex = 295;
            this.SupplierCd_Label.Text = "�d����";
            // 
            // BLGoodsCode_Label
            // 
            this.BLGoodsCode_Label.Location = new System.Drawing.Point(30, 221);
            this.BLGoodsCode_Label.Name = "BLGoodsCode_Label";
            this.BLGoodsCode_Label.Size = new System.Drawing.Size(89, 23);
            this.BLGoodsCode_Label.TabIndex = 296;
            this.BLGoodsCode_Label.Text = "BL�R�[�h";
            // 
            // tNedit_BLGoodsCode
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_BLGoodsCode.ActiveAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_BLGoodsCode.Appearance = appearance10;
            this.tNedit_BLGoodsCode.AutoSelect = true;
            this.tNedit_BLGoodsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_BLGoodsCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode.DataText = "";
            this.tNedit_BLGoodsCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGoodsCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGoodsCode.Location = new System.Drawing.Point(125, 221);
            this.tNedit_BLGoodsCode.MaxLength = 5;
            this.tNedit_BLGoodsCode.Name = "tNedit_BLGoodsCode";
            this.tNedit_BLGoodsCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_BLGoodsCode.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGoodsCode.TabIndex = 8;
            this.tNedit_BLGoodsCode.ValueChanged += new System.EventHandler(this.tNedit_BLGoodsCode_ValueChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(30, 162);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(79, 23);
            this.ultraLabel1.TabIndex = 299;
            this.ultraLabel1.Text = "�i��";
            // 
            // BLGoodsName_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLGoodsName_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance12.Cursor = System.Windows.Forms.Cursors.Default;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.BLGoodsName_tEdit.Appearance = appearance12;
            this.BLGoodsName_tEdit.AutoSelect = true;
            this.BLGoodsName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BLGoodsName_tEdit.DataText = "";
            this.BLGoodsName_tEdit.Enabled = false;
            this.BLGoodsName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLGoodsName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.BLGoodsName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BLGoodsName_tEdit.Location = new System.Drawing.Point(183, 221);
            this.BLGoodsName_tEdit.MaxLength = 20;
            this.BLGoodsName_tEdit.Name = "BLGoodsName_tEdit";
            this.BLGoodsName_tEdit.Size = new System.Drawing.Size(314, 24);
            this.BLGoodsName_tEdit.TabIndex = 26;
            this.BLGoodsName_tEdit.Tag = "False";
            // 
            // SetKind_Label
            // 
            this.SetKind_Label.Location = new System.Drawing.Point(12, 36);
            this.SetKind_Label.Name = "SetKind_Label";
            this.SetKind_Label.Size = new System.Drawing.Size(109, 23);
            this.SetKind_Label.TabIndex = 300;
            this.SetKind_Label.Text = "���̓p�^�[��";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(464, 99);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(220, 23);
            this.ultraLabel6.TabIndex = 304;
            this.ultraLabel6.Text = "�� �[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // SetKind_tComboEditor
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SetKind_tComboEditor.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.TextVAlignAsString = "Middle";
            this.SetKind_tComboEditor.Appearance = appearance19;
            this.SetKind_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SetKind_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SetKind_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SetKind_tComboEditor.ItemAppearance = appearance20;
            this.SetKind_tComboEditor.Location = new System.Drawing.Point(125, 35);
            this.SetKind_tComboEditor.Name = "SetKind_tComboEditor";
            this.SetKind_tComboEditor.Size = new System.Drawing.Size(275, 24);
            this.SetKind_tComboEditor.TabIndex = 0;
            this.SetKind_tComboEditor.ValueChanged += new System.EventHandler(this.SetKind_tComboEditor_ValueChanged);
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(8, 78);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(683, 3);
            this.ultraLabel17.TabIndex = 307;
            // 
            // GoodsMakerGuide_Button
            // 
            this.GoodsMakerGuide_Button.Location = new System.Drawing.Point(494, 189);
            this.GoodsMakerGuide_Button.Name = "GoodsMakerGuide_Button";
            this.GoodsMakerGuide_Button.Size = new System.Drawing.Size(26, 26);
            this.GoodsMakerGuide_Button.TabIndex = 7;
            this.GoodsMakerGuide_Button.Click += new System.EventHandler(this.GoodsMakerGuide_Button_Click);
            // 
            // BLGoodsGuide_Button
            // 
            this.BLGoodsGuide_Button.Location = new System.Drawing.Point(503, 219);
            this.BLGoodsGuide_Button.Name = "BLGoodsGuide_Button";
            this.BLGoodsGuide_Button.Size = new System.Drawing.Size(26, 26);
            this.BLGoodsGuide_Button.TabIndex = 9;
            this.BLGoodsGuide_Button.Click += new System.EventHandler(this.BLGoodsGuide_Button_Click);
            // 
            // SupplierGd_ultraButton
            // 
            this.SupplierGd_ultraButton.Location = new System.Drawing.Point(526, 288);
            this.SupplierGd_ultraButton.Name = "SupplierGd_ultraButton";
            this.SupplierGd_ultraButton.Size = new System.Drawing.Size(26, 26);
            //this.SupplierGd_ultraButton.TabIndex = 11; //DEL 2012/09/21 ���� for redmine#32367
            this.SupplierGd_ultraButton.TabIndex = 13; //ADD 2012/09/21 ���� for redmine#32367
            this.SupplierGd_ultraButton.Click += new System.EventHandler(this.SupplierGd_ultraButton_Click);
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(254, 99);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 26);
            this.SectionGuide_Button.TabIndex = 2;
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(30, 250);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(79, 23);
            this.ultraLabel2.TabIndex = 308;
            this.ultraLabel2.Text = "������";
            // 
            // tNedit_GoodsMGroup
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMGroup.ActiveAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_GoodsMGroup.Appearance = appearance4;
            this.tNedit_GoodsMGroup.AutoSelect = true;
            this.tNedit_GoodsMGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMGroup.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMGroup.DataText = "";
            this.tNedit_GoodsMGroup.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMGroup.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMGroup.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMGroup.Location = new System.Drawing.Point(125, 251);
            this.tNedit_GoodsMGroup.MaxLength = 5;
            this.tNedit_GoodsMGroup.Name = "tNedit_GoodsMGroup";
            this.tNedit_GoodsMGroup.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMGroup.Size = new System.Drawing.Size(43, 24);
            //this.tNedit_GoodsMGroup.TabIndex = 309; //DEL 2012/09/21 ���� for redmine#32367
            this.tNedit_GoodsMGroup.TabIndex = 10; //ADD 2012/09/21 ���� for redmine#32367
            // 
            // tEdit_GoodsMGroupName
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsMGroupName.ActiveAppearance = appearance48;
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance49.Cursor = System.Windows.Forms.Cursors.Default;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.tEdit_GoodsMGroupName.Appearance = appearance49;
            this.tEdit_GoodsMGroupName.AutoSelect = true;
            this.tEdit_GoodsMGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tEdit_GoodsMGroupName.DataText = "";
            this.tEdit_GoodsMGroupName.Enabled = false;
            this.tEdit_GoodsMGroupName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsMGroupName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_GoodsMGroupName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_GoodsMGroupName.Location = new System.Drawing.Point(174, 251);
            this.tEdit_GoodsMGroupName.MaxLength = 20;
            this.tEdit_GoodsMGroupName.Name = "tEdit_GoodsMGroupName";
            this.tEdit_GoodsMGroupName.Size = new System.Drawing.Size(314, 24);
            this.tEdit_GoodsMGroupName.TabIndex = 310;
            this.tEdit_GoodsMGroupName.Tag = "False";
            // 
            // GoodsMGroupGuidButton
            // 
            this.GoodsMGroupGuidButton.Location = new System.Drawing.Point(495, 249);
            this.GoodsMGroupGuidButton.Name = "GoodsMGroupGuidButton";
            this.GoodsMGroupGuidButton.Size = new System.Drawing.Size(26, 26);
            //this.GoodsMGroupGuidButton.TabIndex = 311; //DEL 2012/09/21 ���� for redmine#32367
            // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
            this.GoodsMGroupGuidButton.TabIndex = 11;
            this.GoodsMGroupGuidButton.Click += new System.EventHandler(this.GoodsMGroupGuidButton_Click);
            // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
            // 
            // MAKHN09520UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(700, 421);
            this.Controls.Add(this.GoodsMGroupGuidButton);
            this.Controls.Add(this.tEdit_GoodsMGroupName);
            this.Controls.Add(this.tNedit_GoodsMGroup);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.SupplierGd_ultraButton);
            this.Controls.Add(this.BLGoodsGuide_Button);
            this.Controls.Add(this.GoodsMakerGuide_Button);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.SetKind_Label);
            this.Controls.Add(this.BLGoodsName_tEdit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tNedit_BLGoodsCode);
            this.Controls.Add(this.BLGoodsCode_Label);
            this.Controls.Add(this.SupplierCd_Label);
            this.Controls.Add(this.SupplierLot_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.Controls.Add(this.tNedit_SupplierLot);
            this.Controls.Add(this.SupplierNm_tEdit);
            this.Controls.Add(this.tNedit_SupplierCd);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.SectionCode_Label);
            this.Controls.Add(this.GoodsMakerCd_Label);
            this.Controls.Add(this.ParentGoodsCode_Label);
            this.Controls.Add(this.tNedit_GoodsMakerCd);
            this.Controls.Add(this.tEdit_GoodsNo);
            this.Controls.Add(this.GoodsName_tEdit);
            this.Controls.Add(this.GoodsMakerName_tEdit);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SetKind_tComboEditor);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKHN09520UA";
            this.Text = "���i�Ǘ����}�X�^";
            this.Load += new System.EventHandler(this.MAKHN09520UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKHN09520UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKHN09520UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKind_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsMGroupName)).EndInit();
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

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region ��Enums
        /// <summary>
        /// �d����R���|�w��
        /// </summary>
        private enum SupplierMode
        {
            Supplier1 = 1,
            Supplier2 = 2,
            Supplier3 = 3,
        }
        #endregion
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.08.22 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //���[�J�[�R�[�h�ϐ�
        int prvGoodsMakerCd = 0;
        GoodsAcs goodsAcs;

        // ADD 2008.08.22 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		# region ��Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList goodsMngList = null;

            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
            // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
            //status = this._goodsMngAcs.SearchAll(this._enterpriseCode, out goodsMngList);

            // ���_�f�[�^�N���X
            SecInfoSet secInfoSet;

            // ���_�f�[�^�N���X�C���X�^���X��
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._belongSectionCode);
            if (status == 0)
            {
                // 2008.12.25 [9570]
                //this._mainOfficeFuncFlag = secInfoSet.MainOfficeFuncFlag;
                this._mainOfficeFuncFlag = 1;
                // 2008.12.25 [9570]
                this._belongSectionName  = secInfoSet.SectionGuideNm;
            }

            // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
            status = this._goodsMngAcs.SearchAll(this._enterpriseCode, out goodsMngList, this._mainOfficeFuncFlag, this._belongSectionCode);
            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<

            this._totalCount = goodsMngList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (GoodsMng lgoodsgranre in goodsMngList)
                        {
                            if (this._goodsMngTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
                            {
                                GoodsMngToDataSet(lgoodsgranre.Clone(), index);
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
                            this._goodsMngAcs,				  // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2018/11/08 ���O</br>
        /// <br>�@�@�@�@�@ : redmine#49781 ���i�Ǘ����}�X�^�̍폜�d�l�ύX�̑Ή�</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;
            Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
            GoodsMng goodsMng = ((GoodsMng)this._goodsMngTable[guid]).Clone();

            // -- 2009/08/02 ------------------------------>>
            //if (goodsMng.SectionCode != "" && goodsMng.BLGoodsCode != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == "")
            if ((goodsMng.SectionCode != "" && goodsMng.BLGoodsCode != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == "") ||
                 (goodsMng.SectionCode != "" && goodsMng.GoodsMGroup != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == ""))
            // -- 2009/08/02 ------------------------------<<
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                ArrayList wkList = new ArrayList();
                object objret = wkList;
                PrmSettingUWork primeSettingParaWork = new PrmSettingUWork();
                primeSettingParaWork.EnterpriseCode = goodsMng.EnterpriseCode;
                primeSettingParaWork.SectionCode = goodsMng.SectionCode;
                primeSettingParaWork.GoodsMGroup = goodsMng.GoodsMGroup;
                primeSettingParaWork.PartsMakerCd = goodsMng.GoodsMakerCd;
                primeSettingParaWork.TbsPartsCode = goodsMng.BLGoodsCode;
                primeSettingParaWork.PrimeDisplayCode = -1;

                this._goodsMngAcs.GetPrimeSettingMng(ref objret, primeSettingParaWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                if (objret != null)
                {
                    if (((ArrayList)objret).Count == 0)
                    {
                        status = this._goodsMngAcs.LogicalDelete(ref goodsMng);
                    }
                    // --- ADD 2018/11/08 ���O for redmine#49781 ---------->>>>>
                    else
                    {
                        DialogResult Dialog = TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_QUESTION,
                           ASSEMBLY_ID,
                           DeleteMessage,
                           0,
                           MessageBoxButtons.YesNo,
                           MessageBoxDefaultButton.Button2);
                        if (Dialog == DialogResult.Yes)
                        {
                            status = this._goodsMngAcs.Delete(goodsMng);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();
                                this._goodsMngTable.Remove(goodsMng.FileHeaderGuid);
                                return status;
                            }
                        }
                        else
                        {

                            this.Hide();
                            return status;
                        }
                    }
                    // --- ADD 2018/11/08 ���O for redmine#49781 ----------<<<<<
                }
                // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
            }
            else
            {
                status = this._goodsMngAcs.LogicalDelete(ref goodsMng);
            }
            //MessageBox.Show(status.ToString(), "");
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
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._goodsMngAcs);
					return status;
				}
            �@�@// --- DEL 2018/11/08 ���O for redmine#49781 ---------->>>>>
                //case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                //{
                //    //�폜�s��
                //    TMsgDisp.Show(this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        ASSEMBLY_ID,
                //        "���̃��R�[�h�͗D�ǐݒ�}�X�^�ō폜���ĉ�����",
                //        status,
                //        MessageBoxButtons.OK);
                //    this.Hide();

                //    return status;
                //}
                // --- DEL 2018/11/08 ���O for redmine#49781 ----------<<<<<
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
                        this._goodsMngAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��

					return status;
				}
			}

			// �f�[�^�Z�b�g�W�J����
            GoodsMngToDataSet(goodsMng.Clone(), this._dataIndex);
			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            #region ���O���b�h��ݒ�
            /******************
             *�@�폜��            
             *�A�_���폜�敪      
             *�B���_�R�[�h        
             *�C���_�K�C�h����    
             *�D���i���[�J�[�R�[�h
             *�E���[�J�[����      
             *�F���i�R�[�h        
             *�G���i����          
             *�HBL�R�[�h
             *�IBL����
             *�I�d����R�[�h    
             *�J�d���於��      
             *�M�������b�g           
             ******************/

            appearanceTable.Add(GoodsMngAcs.DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(GoodsMngAcs.LOGICALDELETE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GoodsMngAcs.SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));         // ���_�R�[�h
            appearanceTable.Add(GoodsMngAcs.SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));      // ���_�K�C�h����
            appearanceTable.Add(GoodsMngAcs.GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));       // ���i���[�J�[�R�[�h
            appearanceTable.Add(GoodsMngAcs.MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));           // ���[�J�[����
            appearanceTable.Add(GoodsMngAcs.GOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));             // ���i�R�[�h
            appearanceTable.Add(GoodsMngAcs.GOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));           // ���i����
            appearanceTable.Add(GoodsMngAcs.GOODSMGROUP_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));             // �����ރR�[�h
            appearanceTable.Add(GoodsMngAcs.GOODSMGROUPNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));           // �����ޖ���
            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
            appearanceTable.Add(GoodsMngAcs.BLGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));        // BL�R�[�h
            appearanceTable.Add(GoodsMngAcs.BLGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));        // BL�R�[�h����
            appearanceTable.Add(GoodsMngAcs.SUPPLIERCD1_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));        // �d����R�[�h
            appearanceTable.Add(GoodsMngAcs.SUPPLIERSNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));       // �d���於��
            appearanceTable.Add(GoodsMngAcs.SUPPLIERLOT1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));       // �������b�g
            appearanceTable.Add(GoodsMngAcs.FILEHEADERGUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));     // �f�[�^�e�[�u���J��������           
            #endregion

            //appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			return appearanceTable;
		}
		# endregion

		# endregion

		#region ��Private Menbers
        private GoodsMngAcs _goodsMngAcs;
		private int _totalCount;
		private string _enterpriseCode;
        private Hashtable _goodsMngTable;
        // 2008.02.28 �ǉ� >>>>>>>>>>>>>>>>>>>>
        private string _belongSectionCode;
        private string _belongSectionName = "";
        private SupplierAcs _supplierAcs; // ADD 2008.04.24
        private BLGoodsCdAcs _bLGoodsCdAcs;
        private GoodsGroupUAcs _goodsGroupUAcs;
        private Dictionary<int, GoodsGroupU> _goodsGroupDic;

        //�@�{�Ћ@�\�t���O
        private int _mainOfficeFuncFlag = 0;
        // 2008.02.28 �ǉ� <<<<<<<<<<<<<<<<<<<<

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
        private GoodsMng _goodsMngClone;

        // 2008.08.22 �ǉ� >>>>>>>>>>>>>>>>>>>>
        // ���[�N�f�[�^�֘A
        //private string _chgSrcGoodsNoWork = "";		// �d����i��
        private string _chgDestGoodsNoWork = "";	// �i��
        // 2008.08.22 �ǉ� <<<<<<<<<<<<<<<<<<<<

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;
		/// <summary>���_�I�v�V�����t���O</summary>
		private bool _optSection = false;
		# endregion

		# region ��Consts
        private const string MAKERU_TABLE = "LGOODSGANRE";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

		// �R���g���[������
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";

        //�ݒ���
        private const string SETKIND_SECTIONGOODS = "���_�{�i��";
        private const string SETKIND_SECTIONMAKER = "���_�{���[�J�[";
        private const string SETKIND_SECTIONBLMAKER = "���_�{���[�J�[�{BL�R�[�h";
        private const int SETKIND_SECTIONGOODS_VALUE = 0;
        //private const int SETKIND_SECTIONMAKER_VALUE = 1; // DEL 2012/09/21 ���� for redmine#32367
        //private const int SETKIND_SECTIONBLMAKER_VALUE = 2; // DEL 2012/09/21 ���� for redmine#32367
        // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
        private const string SETKIND_SECTIONMGROUPMAKERBL = "���_�{�����ށ{���[�J�[�{BL�R�[�h";
        private const string SETKIND_SECTIONMGROUPMAKER = "���_�{�����ށ{���[�J�[";
        private const int SETKIND_SECTIONMGROUPMAKERBL_VALUE = 1;
        private const int SETKIND_SECTIONMGROUPMAKER_VALUE = 2;
        private const int SETKIND_SECTIONMAKER_VALUE = 3;
        // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<

		// Message�֘A��`
		private const string ASSEMBLY_ID	= "MAKHN09520U";
		private const string PG_NM			= "���i�Ǘ����}�X�^";
		private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG	= "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
		private const string ERR_RDEL_MSG	= "�폜�Ɏ��s���܂����B";
		private const string ERR_UPDT_MSG	= "�o�^�Ɏ��s���܂����B";
		private const string ERR_RVV_MSG	= "�����Ɏ��s���܂����B";
		private const string ERR_800_MSG	= "���ɑ��[�����X�V����Ă��܂�";
		private const string ERR_801_MSG	= "���ɑ��[�����폜����Ă��܂�";
		private const string SDC_RDEL_MSG	= "�}�X�^����폜����Ă��܂�";

        // 2008.02.28 �ǉ� >>>>>>>>>>>>>>>>>>>>
        private const string ON_MSG         = "����";
        private const string OFF_MSG        = "���Ȃ�";
        // 2008.02.28 �ǉ� <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region enum
        /// <summary>
        /// ���̓G���[�`�F�b�N�X�e�[�^�X
        /// </summary>
        private enum InputChkStatus
        {
            // ������
            NotInput = -1,
            // ���݂��Ȃ�
            NotExist = -2,
            // ���̓~�X
            InputErr = -3,
            // ����
            Normal = 0,
            // �L�����Z��
            Cancel = 1
        }

        /// <summary>
        /// ��ʃf�[�^�ݒ�X�e�[�^�X
        /// </summary>
        private enum DispSetStatus
        {
            // �N���A
            Clear = 0,
            // �X�V
            Update = 1,
            // ���ɖ߂�
            Back = 2
        }
        #endregion enum



		# region ��Main
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new MAKHN09520UA());
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
        /// ���i�Ǘ����}�X�^ �I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
        /// <param name="goodsMng">���i�Ǘ����}�X�^ �I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^ �N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private void GoodsMngToDataSet(GoodsMng goodsMng, int index)
		{

			if ((index < 0) || (this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[MAKERU_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count - 1;
			}

            if (goodsMng.LogicalDeleteCode == 0)
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.DELETE_DATE] = "";
            }
			else
			{
                //this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.DELETE_DATE] =TDateTime.DateTimeToString("ggYY/MM/DD", goodsMng.UpdateDateTime);
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.DELETE_DATE] = goodsMng.UpdateDateTime;
            }

            #region �����_�R�[�h
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SECTIONCODE_TITLE] = goodsMng.SectionCode;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SECTIONGUIDENM_TITLE] = goodsMng.SectionGuideNm;
            #endregion

            #region �����i���[�J�[
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSMAKERCD_TITLE] = goodsMng.GoodsMakerCd;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.MAKERNAME_TITLE] = goodsMng.GoodsMakerName;
            #endregion

            #region �����i�R�[�h
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSNO_TITLE] = goodsMng.GoodsNo;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSNAME_TITLE] = goodsMng.GoodsName;
            #endregion

            #region ��BL�R�[�h
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.BLGOODSCODE_TITLE] = goodsMng.BLGoodsCode;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.BLGOODSNAME_TITLE] = goodsMng.BLGoodsName;
            #endregion

            #region �����i������
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSMGROUP_TITLE] = goodsMng.GoodsMGroup;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSMGROUPNM_TITLE] = goodsMng.GoodsMGroupNm;
            #endregion
            

            #region ��������P
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SUPPLIERCD1_TITLE] = goodsMng.SupplierCd1;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SUPPLIERSNM_TITLE] = goodsMng.SupplierSnm;
            #endregion

            #region �����ʃ��b�g
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SUPPLIERLOT1_TITLE] = goodsMng.SupplierLot1;
            #endregion
           
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.FILEHEADERGUID_TITLE] = goodsMng.FileHeaderGuid;

            if (this._goodsMngTable.ContainsKey(goodsMng.FileHeaderGuid))
            {
                this._goodsMngTable.Remove(goodsMng.FileHeaderGuid);
            }
            this._goodsMngTable.Add(goodsMng.FileHeaderGuid, goodsMng);

        }

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
            DataTable goodsMngTable = new DataTable(MAKERU_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            goodsMngTable.Columns.Add(GoodsMngAcs.DELETE_DATE, typeof(string));

            // ���_�R�[�h
            goodsMngTable.Columns.Add(GoodsMngAcs.SECTIONCODE_TITLE, typeof(string));
            goodsMngTable.Columns.Add(GoodsMngAcs.SECTIONGUIDENM_TITLE, typeof(string));

            // ���i���[�J�[
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSMAKERCD_TITLE, typeof(int));
            goodsMngTable.Columns.Add(GoodsMngAcs.MAKERNAME_TITLE, typeof(string));

            // ���i�R�[�h
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSNO_TITLE, typeof(string));
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSNAME_TITLE, typeof(string));

            // BL�R�[�h
            goodsMngTable.Columns.Add(GoodsMngAcs.BLGOODSCODE_TITLE, typeof(int));
            goodsMngTable.Columns.Add(GoodsMngAcs.BLGOODSNAME_TITLE, typeof(string));

            // ���i�����ރR�[�h
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSMGROUP_TITLE, typeof(int));
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSMGROUPNM_TITLE, typeof(string));
 
            // ������
            goodsMngTable.Columns.Add(GoodsMngAcs.SUPPLIERCD1_TITLE, typeof(int));
            goodsMngTable.Columns.Add(GoodsMngAcs.SUPPLIERSNM_TITLE, typeof(string));

            // �������b�g
            goodsMngTable.Columns.Add(GoodsMngAcs.SUPPLIERLOT1_TITLE, typeof(int));

            // GUID
            goodsMngTable.Columns.Add(GoodsMngAcs.FILEHEADERGUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(goodsMngTable);
        }

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.Ok_Button.Location = new System.Drawing.Point(450, 330);
            //this.Cancel_Button.Location = new System.Drawing.Point(575, 330);
            //this.Delete_Button.Location = new System.Drawing.Point(325, 330);
            //this.Revive_Button.Location = new System.Drawing.Point(450, 330);
            Point point = new Point();
            point.X = this.Cancel_Button.Location.X;
            point.Y = this.Cancel_Button.Location.Y;

            point.X = point.X - this.Ok_Button.Size.Width;
            this.Ok_Button.Location     = point;
            this.Revive_Button.Location = point;

            point.X = point.X - this.Delete_Button.Size.Width;
            this.Delete_Button.Location = point;
            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
            // �ݒ���
            this.SetKind_tComboEditor.Items.Clear();
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTIONGOODS_VALUE, SETKIND_SECTIONGOODS);
            // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTIONMGROUPMAKERBL_VALUE, SETKIND_SECTIONMGROUPMAKERBL);
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTIONMGROUPMAKER_VALUE, SETKIND_SECTIONMGROUPMAKER);
            // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTIONMAKER_VALUE, SETKIND_SECTIONMAKER);
            this.SetKind_tComboEditor.MaxDropDownItems = this.SetKind_tComboEditor.Items.Count;
        }

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2012/10/08 ������ </br>
        ///	<br>		   �Eredmine#32367 ��Q�ꗗ�̑Ή�</br>
        /// </remarks>
		private void ScreenClear()
		{
            this.SetKind_tComboEditor.SelectedIndex = 0;
            this.tEdit_SectionCodeAllowZero.Clear();
            this.SectionName_tEdit.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.GoodsMakerName_tEdit.Clear();
            this.tEdit_GoodsNo.Clear();
            this.GoodsName_tEdit.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.BLGoodsName_tEdit.Clear();
            this.tNedit_SupplierCd.Clear();
            this.SupplierNm_tEdit.Clear();
            this.tNedit_SupplierLot.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.tEdit_GoodsMGroupName.Clear();
            _blGoodsCode = 0;//ADD 2012/10/08 ������ for redmine#32367
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void ScreenReconstruction()
		{

			if (this.DataIndex < 0)
			{
				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                
                //_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;
                                       				
				// ��ʓ��͋����䏈��
				ScreenInputPermissionControl(true);

                // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
                // �����l�ݒ�
                if (this._mainOfficeFuncFlag != 1)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = this._belongSectionCode;
                    this.SectionName_tEdit.DataText = this._belongSectionName;
                }
                // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<

                GoodsMng goodsMng = new GoodsMng();
				//�N���[���쐬
                this._goodsMngClone = goodsMng.Clone(); 
                DispToGoodsMng(ref this._goodsMngClone);

				// �t�H�[�J�X�ݒ�
                // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
                //this.tEdit_SectionCodeAllowZero.Focus();
                //this.tEdit_SectionCodeAllowZero.SelectAll();

                // �����t�H�[�J�X���Z�b�g
                this.SetKind_tComboEditor.Focus();

                //if (this._mainOfficeFuncFlag == 1)
                //{

                //    this.tEdit_SectionCodeAllowZero.Focus();
                //    this.tEdit_SectionCodeAllowZero.SelectAll();
                //}
                //else
                //{
                //    this.tNedit_GoodsMakerCd.Focus();
                //    this.tNedit_GoodsMakerCd.SelectAll();
                //}
                // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
            }
			else
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
                GoodsMng goodsMng = (GoodsMng)this._goodsMngTable[guid];

                if (goodsMng.LogicalDeleteCode == 0)
				{
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					// �{�^���ݒ�
					this.Ok_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					// ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(false);

					// ��ʓW�J����
                    MakerUMntToScreen(goodsMng);

					//�N���[���쐬
                    this._goodsMngClone = goodsMng.Clone();
                    DispToGoodsMng(ref this._goodsMngClone);
                    //_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;
                    

				}
				else
				{
					// �폜���[�h
					this.Mode_Label.Text = DELETE_MODE;

					// �{�^���ݒ�
					this.Ok_Button.Visible = false;
					this.Revive_Button.Visible = true;
                    this.Delete_Button.Visible = true;
					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;

					// ��ʓ��͋����䏈��
					ScreenInputPermissionControl(false);

					// ��ʓW�J����
                    MakerUMntToScreen(goodsMng);

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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {
            // ���[�h�ɂ���ē��͋��𐧌�
            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.tEdit_SectionCodeAllowZero.Enabled        = enabled;
            //this.tNedit_GoodsMakerCd.Enabled      = enabled;
            //this.tEdit_GoodsNo.Enabled            = enabled;
            //this.SectionGuide_Button.Enabled      = enabled;  // ���_�K�C�h�{�^��
            //this.GoodsMakerGuide_Button.Enabled   = enabled;  // ���i���[�J�[�K�C�h�{�^��
            this.tNedit_GoodsMGroup.Enabled = false;
            this.tEdit_GoodsMGroupName.Enabled = false;
            this.GoodsMGroupGuidButton.Enabled = false;
            if (this._mainOfficeFuncFlag == 1)
            {
                // �{�Џ���
                this.tEdit_SectionCodeAllowZero.Enabled = enabled;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.tEdit_GoodsNo.Enabled = enabled;
                this.SectionGuide_Button.Enabled = enabled;  // ���_�K�C�h�{�^��
                this.GoodsMakerGuide_Button.Enabled = false;  // ���i���[�J�[�K�C�h�{�^��
                this.tNedit_BLGoodsCode.Enabled = false;
                this.BLGoodsGuide_Button.Enabled = false;
                this.SetKind_tComboEditor.Visible = enabled;
                this.SetKind_Label.Visible = enabled;
                this.ultraLabel6.Visible = enabled;
            }
            else
            {
                // ���_����
                this.tEdit_SectionCodeAllowZero.Enabled = false;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.tEdit_GoodsNo.Enabled = enabled;
                this.SectionGuide_Button.Enabled = false;    // ���_�K�C�h�{�^��
                this.GoodsMakerGuide_Button.Enabled = false;  // ���i���[�J�[�K�C�h�{�^��
                this.tNedit_BLGoodsCode.Enabled = enabled;
                this.BLGoodsGuide_Button.Enabled = enabled;
                this.SetKind_tComboEditor.Visible = enabled;
                this.SetKind_Label.Visible = enabled;
                this.ultraLabel6.Visible = enabled;
            }
            if (this.Mode_Label.Text == DELETE_MODE)
            { 
                this.tNedit_SupplierCd.Enabled = enabled;
                this.tNedit_SupplierLot.Enabled = enabled;
                this.SupplierGd_ultraButton.Enabled = enabled;  
            }
            else
            {
                this.tNedit_SupplierCd.Enabled = true;
                this.tNedit_SupplierLot.Enabled = true;
                this.SupplierGd_ultraButton.Enabled = true;
            }
                // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        }
		/// <summary>
        /// ���i�Ǘ����}�X�^ �N���X��ʓW�J����
		/// </summary>
        /// <param name="goodsMng">���i�Ǘ����ݒ�}�X�^ �I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private void MakerUMntToScreen(GoodsMng goodsMng)
        {
           // MakerUMnt makerUMnt;
            MakerAcs makerAcs = new MakerAcs();
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            List<GoodsUnitData> list = new List<GoodsUnitData>();
            GoodsUnitData goodsUnitData = new GoodsUnitData();


            #region �����_�R�[�h
            if (goodsMng.SectionCode != string.Empty)
            {
                this.tEdit_SectionCodeAllowZero.DataText = goodsMng.SectionCode;

            }
            if (goodsMng.SectionGuideNm != string.Empty)
            {
                this.SectionName_tEdit.DataText = goodsMng.SectionGuideNm;
            }
            #endregion

            #region �����i���[�J�[

            if (goodsMng.GoodsMakerCd != 0)
            {
                this.tNedit_GoodsMakerCd.SetInt(goodsMng.GoodsMakerCd);
            }
            if (goodsMng.GoodsMakerName != string.Empty)
            {
                this.GoodsMakerName_tEdit.DataText = goodsMng.GoodsMakerName;
            }
            #endregion

            #region �����i�R�[�h
            if (goodsMng.GoodsNo != string.Empty)
            {
                this.tEdit_GoodsNo.DataText = goodsMng.GoodsNo;
            }
            if (goodsMng.GoodsName != string.Empty)
            {
                this.GoodsName_tEdit.DataText = goodsMng.GoodsName;
            }
            #endregion

            #region ���d����
            if (goodsMng.SupplierCd1 != 0)
            {
                this.tNedit_SupplierCd.SetInt(goodsMng.SupplierCd1);
            }
            if (goodsMng.SupplierSnm != string.Empty)
            {
                this.SupplierNm_tEdit.DataText = goodsMng.SupplierSnm;
            }
            #endregion


            #region ��BL�R�[�h
            if (goodsMng.BLGoodsCode != 0)
            {
                this.tNedit_BLGoodsCode.SetInt(goodsMng.BLGoodsCode);
            }
            if (goodsMng.BLGoodsName != string.Empty)
            {
                this.BLGoodsName_tEdit.DataText = goodsMng.BLGoodsName;
            }
            #endregion

            #region �����i�����ރR�[�h
            if (goodsMng.GoodsMGroup != 0)
            {
                this.tNedit_GoodsMGroup.SetInt(goodsMng.GoodsMGroup);
            }
            if (goodsMng.GoodsMGroupNm != string.Empty)
            {
                this.tEdit_GoodsMGroupName.DataText = goodsMng.GoodsMGroupNm;
            }
            #endregion


            #region ���������b�g�P
            this.tNedit_SupplierLot.SetInt(goodsMng.SupplierLot1);
            #endregion
        }

		/// <summary>
		/// Value�`�F�b�N�����iint�j
		/// </summary>
		/// <param name="sorce">tCombo��Value</param>
		/// <returns>�`�F�b�N��̒l</returns>
		/// <remarks>
		/// <br>Note       : tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
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
        /// ��ʏ��i�[����
        /// </summary>
        /// <param name="goodsMng">���i�Ǘ����f�[�^�N���X</param>
        /// <remarks>
        /// Note       : ��ʏ��̃f�[�^�N���X�i�[�������s���܂�<br />
        /// Programmer : 980035 ����@��`<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        private void DispToGoodsMng(ref GoodsMng goodsMng)
        {
            if (goodsMng == null)
            {
                // �V�K�̏ꍇ
                goodsMng = new GoodsMng();
            }

            goodsMng.EnterpriseCode = this._enterpriseCode;

            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                goodsMng.SectionCode = "00";                  // ���_�R�[�h
            }
            else
            {
                goodsMng.SectionCode        = this.tEdit_SectionCodeAllowZero.DataText;                  // ���_�R�[�h
            }
            if (goodsMng.SectionCode == "00")
            {
                goodsMng.SectionGuideNm = "�S�Ћ���";
            }
            else
            {
                goodsMng.SectionGuideNm = this.SectionName_tEdit.DataText;                  // ���_����
            }

            goodsMng.GoodsMakerCd       = this.tNedit_GoodsMakerCd.GetInt();                // ���i���[�J�[�R�[�h
            goodsMng.GoodsMakerName     = this.GoodsMakerName_tEdit.DataText;               // ���[�J�[����
            goodsMng.GoodsNo            = this.tEdit_GoodsNo.DataText;                      // ���i�R�[�h
            goodsMng.GoodsName          = this.GoodsName_tEdit.DataText;                    // ���i����
            //goodsMng.BLGoodsCode      = this.tNedit_BLGoodsCode.GetInt();               // BL�R�[�h
            //goodsMng.BLGoodsName      = this.BLGoodsName_tEdit.DataText;                // BL�R�[�h����
            goodsMng.SupplierCd1        = this.tNedit_SupplierCd.GetInt();                 // �d����R�[�h
            goodsMng.SupplierSnm�@      = this.SupplierNm_tEdit.DataText;                    // �d���於��
            goodsMng.SupplierLot1       = this.tNedit_SupplierLot.GetInt();                // �������b�g
            //goodsMng.GoodsMGroup        = this.tNedit_GoodsMGroup.GetInt();                        // �����ރR�[�h
            //goodsMng.GoodsMGroupNm      = this.tEdit_GoodsMGroupName.DataText;                   // �����ޖ���
            // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
            goodsMng.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();               // BL�R�[�h
            goodsMng.BLGoodsName = this.BLGoodsName_tEdit.DataText;                // BL�R�[�h����
            goodsMng.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();                        // �����ރR�[�h
            goodsMng.GoodsMGroupNm = this.tEdit_GoodsMGroupName.DataText;                   // �����ޖ���
            // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
		{
			bool result = true;

            #region �����i�����̓`�F�b�N

            #region < ���_�R�[�h����/���i���[�J�[,�i��,BL�R�[�h���̓`�F�b�N >
            
            //���_�R�[�h�������͂̏ꍇ
            if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd() == "")
            {
                message = this.SectionCode_Label.Text + "����͂��Ă��������B";
                control = this.tEdit_SectionCodeAllowZero;
                result = false;
            }
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                //���_�{���[�J�[�������͂̏ꍇ
                if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                {
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        message = this.GoodsMakerCd_Label.Text + "����͂��Ă��������B";
                        control = this.tNedit_GoodsMakerCd;
                        result = false;
                    }
                }

                //���_�{�i�Ԃ������͂̏ꍇ
                else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONGOODS)
                {
                    if (this.tEdit_GoodsNo.DataText == "")
                    {
                        message = this.ParentGoodsCode_Label.Text + "����͂��Ă��������B";
                        control = this.tEdit_GoodsNo;
                        result = false;
                    }
                }

                ////���_�{���[�J�[�{BL�R�[�h�������͂̏ꍇ
                //else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONBLMAKER)
                //{
                //    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                //    {
                //        message = this.GoodsMakerCd_Label.Text + "����͂��Ă��������B";
                //        control = this.tNedit_GoodsMakerCd;
                //        result = false;
                //    }
                //    else if (this.tNedit_BLGoodsCode.GetInt() == 0)
                //    {
                //        message = this.BLGoodsCode_Label.Text + "����͂��Ă��������B";
                //        control = this.tNedit_BLGoodsCode;
                //        result = false;
                //    }

                //}
                // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                //���_�{�����ށ{���[�J�[�{BL�R�[�h�������͂̏ꍇ
                else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL)
                {
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        message = this.GoodsMakerCd_Label.Text + "����͂��Ă��������B";
                        control = this.tNedit_GoodsMakerCd;
                        result = false;
                    }
                    if (this.tNedit_BLGoodsCode.GetInt() == 0)
                    {
                        message = this.BLGoodsCode_Label.Text + "����͂��Ă��������B";
                        control = this.tNedit_BLGoodsCode;
                        result = false;
                    }
                }
                //���_�{�����ށ{���[�J�[�������͂̏ꍇ
                else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
                {
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        message = this.GoodsMakerCd_Label.Text + "����͂��Ă��������B";
                        control = this.tNedit_GoodsMakerCd;
                        result = false;
                    }
                    if (this.tNedit_GoodsMGroup.GetInt() == 0)
                    {
                        message = this.ultraLabel2.Text + "����͂��Ă��������B";
                        control = this.tNedit_GoodsMGroup;
                        result = false;
                    }
                }
                // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
            }
            //�d����R�[�h��������
            if (this.tNedit_SupplierCd.GetInt() == 0)
            {
                message = this.SupplierCd_Label.Text + "����͂��Ă��������B";
                control = this.tNedit_SupplierCd;
                result = false;
            }

            
            #endregion

            #endregion

			return result;
		}


        // 2008.08.22 �ǉ� >>>>>>>>>>>>>>>>>>>>
        #region �i�Ԑݒ�G���[�`�F�b�N����
        /// <summary>
        /// ���i��֐ݒ�G���[�`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�̃G���[�`�F�b�N���s���܂��B
        ///					  �����I�u�W�F�N�g:���_�R�[�h, ���[�J�[�R�[�h, ���[�J�[����, ���i�R�[�h
        ///					  ���ʃI�u�W�F�N�g:���i�}�X�^�������ʃX�e�[�^�X, ���i�R�[�h, ���i����, ���[�J�[�R�[�h, ���[�J�[����</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int CheckGoodsNo(GoodsCndtn goodsCndtn, out GoodsUnitData goodsUnitData)
        {
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsUnitData = null;

            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (goodsCndtn == null) return ret;

                string message;
                List<GoodsUnitData> list = new List<GoodsUnitData>();
                status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out list, out message);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�}�X�^�f�[�^�N���X
                    goodsUnitData = (GoodsUnitData)list[0];

                    ret = (int)InputChkStatus.Normal;
                }
                else if (status == -1)
                {
                    // �I���_�C�A���O�ŃL�����Z��
                    ret = (int)InputChkStatus.Cancel;
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }
        #endregion �i�Ԑݒ�G���[�`�F�b�N����

        #region ��֐�i�Ԑݒ菈��
        /// <summary>
        /// ��֐�i�Ԑݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus"></param>
        /// <param name="goodsUnitData"></param>
        /// 
        /// <remarks>
        /// <br>Note        : ��֐�i�Ԃ���ʂɐݒ肵�܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgDestGoodsNo(DispSetStatus dispSetStatus, ref bool canChangeFocus, GoodsUnitData goodsUnitData)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.tEdit_GoodsNo.Clear();
                            this.GoodsName_tEdit.Clear();


                            // ���݃f�[�^�N���A
                            this._chgDestGoodsNoWork = "";

                            // �t�H�[�J�X
                            canChangeFocus = false;
                         
                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.tEdit_GoodsNo.Text = this._chgDestGoodsNoWork;

                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((goodsUnitData != null))
                            {

                                this.tEdit_GoodsNo.Text = goodsUnitData.GoodsNo;	         // �i��
                                this.GoodsName_tEdit.Text = goodsUnitData.GoodsName;	     // �i��
                                this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd); // ���[�J�[�R�[�h
                                this.GoodsMakerName_tEdit.Text = goodsUnitData.MakerName;    // ���[�J�[��
                                // 2009/11/25 Del >>>
                                // �X�V����BL�R�[�h��BL���̂�\�����Ȃ�
                                //this.tNedit_BLGoodsCode.SetInt(goodsUnitData.BLGoodsCode); �@// BL�R�[�h
                                //this.BLGoodsName_tEdit.Text = goodsUnitData.BLGoodsFullName; // BL��
                                // 2009/11/25 Del <<<
                                
                                prvGoodsMakerCd = goodsUnitData.GoodsMakerCd;

                                // ���݃f�[�^�ۑ�
                                this._chgDestGoodsNoWork = this.tEdit_GoodsNo.Text;

                                BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
                                _bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, goodsUnitData.BLGoodsCode);

                                // 2009/11/25 Del >>>
                                // �X�V���͒����ރR�[�h�ƒ����ޖ��̂�\�����Ȃ�
                                //this.tNedit_GoodsMGroup.SetInt(bLGoodsCdUMnt.GoodsRateGrpCode);

                                //if (this._goodsGroupDic.ContainsKey(bLGoodsCdUMnt.GoodsRateGrpCode))
                                //{
                                //    this.tEdit_GoodsMGroupName.Text = this._goodsGroupDic[bLGoodsCdUMnt.GoodsRateGrpCode].GoodsMGroupName.Trim();
                                //}
                                // 2009/11/25 Del <<<
                   
                                
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion �i�Ԑݒ菈��

        // 2008.08.22 �ǉ� <<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="operation">�I�y���[�V����</param>
		/// <param name="erObject">�G���[�I�u�W�F�N�g</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
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
		# endregion

		#region ��Control Events
		/// <summary>
		/// Form.Load �C�x���g(MAKHN09520UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void MAKHN09520UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;
            goodsAcs = new GoodsAcs();
            string message;
            goodsAcs.SearchInitial(this._enterpriseCode, this._belongSectionCode, out message);

			this.Ok_Button.ImageList     = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

            this.SectionGuide_Button.ImageList           = imageList16;
            this.GoodsMakerGuide_Button.ImageList        = imageList16;
            this.SupplierGd_ultraButton.ImageList        = imageList16;
            this.BLGoodsGuide_Button.ImageList           = imageList16;
            this.GoodsMGroupGuidButton.ImageList         = imageList16;
            // �����{�^���̃A�C�R���ݒ�
            this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.SectionGuide_Button.Appearance.Image           = Size16_Index.STAR1;
            this.GoodsMakerGuide_Button.Appearance.Image        = Size16_Index.STAR1;
            this.SupplierGd_ultraButton.Appearance.Image        = Size16_Index.STAR1;
            this.BLGoodsGuide_Button.Appearance.Image           = Size16_Index.STAR1;
            this.GoodsMGroupGuidButton.Appearance.Image         = Size16_Index.STAR1;

			// ��ʏ����ݒ菈��
            ScreenInitialSetting();
            ReadGoodsMGroup();
		}

		/// <summary>
        /// Form.Closing �C�x���g(MAKHN09520UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private void MAKHN09520UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void MAKHN09520UA_VisibleChanged(object sender, System.EventArgs e)
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2012/10/08 ������ </br>
        ///	<br>		   �Eredmine#32367 ��Q�ꗗ�̑Ή�</br>
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
                this.tEdit_SectionCodeAllowZero.Clear();
                this.SectionName_tEdit.Clear();
                this.tNedit_GoodsMakerCd.Clear();
                this.GoodsMakerName_tEdit.Clear();
                this.tEdit_GoodsNo.Clear();
                this.GoodsName_tEdit.Clear();
                this.tNedit_BLGoodsCode.Clear();
                this.BLGoodsName_tEdit.Clear();
                this.tNedit_SupplierCd.Clear();
                this.SupplierNm_tEdit.Clear();
                this.tNedit_SupplierLot.Clear();
                this.tNedit_GoodsMGroup.Clear();
                this.tEdit_GoodsMGroupName.Clear();
                _blGoodsCode = 0;//ADD 2012/10/08 ������ for redmine#32367 

				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				ScreenInputPermissionControl(true);

				//----- ueno add ---------- start 2008.03.28
				// �����l�ݒ�


				if (this._mainOfficeFuncFlag != 1)
				{
					this.tEdit_SectionCodeAllowZero.DataText = this._belongSectionCode;
					this.SectionName_tEdit.DataText = this._belongSectionName;
				}
				//----- ueno add ---------- end 2008.03.28

				// �N���[�����ēx�擾����
                GoodsMng goodsMng = new GoodsMng();
				
				//�N���[���쐬
                this._goodsMngClone = goodsMng.Clone(); 
                DispToGoodsMng(ref this._goodsMngClone);

				// �t�H�[�J�X�ݒ�
				//----- ueno add ---------- start 2008.03.28
				//this.tEdit_SectionCodeAllowZero.Focus();
				//this.tEdit_SectionCodeAllowZero.SelectAll();
				
				if (this._mainOfficeFuncFlag == 1)
				{
					this.tEdit_SectionCodeAllowZero.Focus();
					this.tEdit_SectionCodeAllowZero.SelectAll();
				}
				else
				{
					this.tNedit_GoodsMakerCd.Focus();
					this.tNedit_GoodsMakerCd.SelectAll();
				}
				//----- ueno add ---------- end 2008.03.28
                //if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                //{
                //    this.SetKind_tComboEditor.SelectedIndex = 1;
                //    this.
                //}
                //else
                //{
                //    this.SetKind_tComboEditor.SelectedIndex = 0;
                //}
                SetKind_tComboEditor_ValueChanged(sender, e);
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
        /// ���i�Ǘ����}�X�^ ���o�^����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private bool SaveProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			Control control = null;
			string message = null;
			string loginID = "";

            GoodsMng goodsMng = null;

			//----- ueno add ---------- start 2008.03.31
			// ���_�R�[�h�[���l�ߏ���
			this.tEdit_SectionCodeAllowZero.Text = GetZeroPaddedTextProc(this.tEdit_SectionCodeAllowZero.Text, this.tEdit_SectionCodeAllowZero.ExtEdit.Column);
			//----- ueno add ---------- end 2008.03.31

			if (this.DataIndex >= 0)
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
                goodsMng = ((GoodsMng)this._goodsMngTable[guid]).Clone();
			}

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

            this.DispToGoodsMng(ref goodsMng);

            status = this._goodsMngAcs.Write(ref goodsMng);
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
						//ERR_DPR_MSG,						// �\�����郁�b�Z�[�W  // DEL 2012/09/21 ���� redmine#32367
                        ERR_800_MSG, // ADD 2012/09/21 ���� redmine#32367
						status,								// �X�e�[�^�X�l
						MessageBoxButtons.OK);				// �\������{�^��

                    this.tEdit_SectionCodeAllowZero.Focus();
                    this.tEdit_SectionCodeAllowZero.SelectAll();
					
					//----- ueno add ---------- end 2008.03.31
					// �擪�̃[���l�߂��폜
					this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text);
					//----- ueno add ---------- end 2008.03.31
					
                    return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._goodsMngAcs);

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

					//----- ueno add ---------- end 2008.03.31
					// �擪�̃[���l�߂��폜
					this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text);
					//----- ueno add ---------- end 2008.03.31

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
                        this._goodsMngAcs,					// �G���[�����������I�u�W�F�N�g
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

					//----- ueno add ---------- end 2008.03.31
					// �擪�̃[���l�߂��폜
					this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text);
					//----- ueno add ---------- end 2008.03.31
					
					return false;
				}
			}

			// DataSet�W�J����
            GoodsMngToDataSet(goodsMng, this.DataIndex);
			
			return true;
		}

		//----- ueno del ---------- start 2008.03.31
		////----- ueno add ---------- start 2008.03.28
		///// <summary>
		///// ���_�R�[�h�[�����ߏ���
		///// </summary>
		///// <param name="goodsMngtEdit_SectionCodeAllowZero">���_�R�[�h</param>
		///// <remarks>
		///// <br>Note       : ���_�R�[�h���[�����߂��܂��B</br>
		///// <br>Programer  : 30167 ���@�O�M</br>
		///// <br>Date       : 2008.03.28</br>
		///// </remarks>
		//private void ZeroFillSectionCode(ref TEdit goodsMngtEdit_SectionCodeAllowZero)
		//{
		//    string wkStr = goodsMngtEdit_SectionCodeAllowZero.DataText;

		//    goodsMngtEdit_SectionCodeAllowZero.DataText = wkStr.PadLeft(6, '0');
		//}
		////----- ueno add ---------- end 2008.03.28
		//----- ueno del ---------- end 2008.03.31

		//----- ueno add ---------- start 2008.03.31
		/// <summary>
		/// �[�����ߌ�e�L�X�g�擾��������
		/// </summary>
		/// <param name="fullText">���͍ς݃e�L�X�g</param>
		/// <param name="columnCount">���͉\����</param>
		/// <returns>�[�����߂����e�L�X�g</returns>
		/// <br>Note       : ��������[�����߂��܂��B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.31</br>
		private static string GetZeroPaddedTextProc(string fullText, int columnCount)
		{
			if (fullText.Trim() != string.Empty)
			{
				// �[���l�ߏ���
				return fullText.PadLeft(columnCount, '0');
			}
			else
			{
				return string.Empty;
			}
		}
		
		/// <summary>
		/// �����񁨐��l�ϊ�
		/// </summary>
		/// <param name="str"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		static int GetIntFromString(string str, int defaultValue)
		{
			try
			{
				return Int32.Parse(str);
			}
			catch
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// �[�����߃L�����Z����e�L�X�g�擾��������
		/// </summary>
		/// <param name="fullText">���͍ς݃e�L�X�g</param>
		/// <returns>�[�����߃L�����Z�������e�L�X�g</returns>
		/// <br>Note       : �����񂩂�[�����폜���܂��B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.31</br>
		private static string GetZeroPadCanceledTextProc(string fullText)
		{
			if (fullText.Trim() != string.Empty)
			{
				int cnt = 0;
				string wkStr = fullText;
				
				// �擪�̃[���l�߂��폜
				while (fullText.StartsWith("0"))
				{
					fullText = fullText.Substring(1, fullText.Length - 1);
					cnt++;
				}
				
				// �I�[���[���̏ꍇ�A���ʃR�[�h�Ƃ���
				if (wkStr.Length == cnt)
				{
					fullText = "0";
				}
				return fullText;
			}
			else
			{
				return string.Empty;
			}
		}
		//----- ueno add ---------- end 2008.03.31

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//�ۑ��m�F
                GoodsMng compareGoodsMng = new GoodsMng();
                compareGoodsMng = this._goodsMngClone.Clone();  
				//���݂̉�ʏ����擾����
                DispToGoodsMng(ref compareGoodsMng);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._goodsMngClone.Equals(compareGoodsMng)))	
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2018/11/08 ���O</br>
        /// <br>�@�@�@�@�@ : redmine#49781 ���i�Ǘ����}�X�^�̍폜�d�l�ύX�̑Ή�</br>
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
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
                GoodsMng goodsMng = ((GoodsMng)this._goodsMngTable[guid]).Clone();

                // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                if ((goodsMng.SectionCode != "" && goodsMng.BLGoodsCode != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == "") ||
                 (goodsMng.SectionCode != "" && goodsMng.GoodsMGroup != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == ""))
                {
                    ArrayList wkList = new ArrayList();
                    object objret = wkList;
                    PrmSettingUWork primeSettingParaWork = new PrmSettingUWork();
                    primeSettingParaWork.EnterpriseCode = goodsMng.EnterpriseCode;
                    primeSettingParaWork.SectionCode = goodsMng.SectionCode;
                    primeSettingParaWork.GoodsMGroup = goodsMng.GoodsMGroup;
                    primeSettingParaWork.PartsMakerCd = goodsMng.GoodsMakerCd;
                    primeSettingParaWork.TbsPartsCode = goodsMng.BLGoodsCode;
                    primeSettingParaWork.PrimeDisplayCode = -1;

                    this._goodsMngAcs.GetPrimeSettingMng(ref objret, primeSettingParaWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                    if (objret != null)
                    {
                        if (((ArrayList)objret).Count == 0)
                        {
                            status = this._goodsMngAcs.Delete(goodsMng);
                        }
                        else
                        {
                            // --- UPD 2018/11/08 ���O for redmine#49781 ---------->>>>>
                            //TMsgDisp.Show(this,
                            //emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            //ASSEMBLY_ID,
                            //"���̃��R�[�h�͗D�ǐݒ�}�X�^�ō폜���ĉ�����",
                            //0,
                            //MessageBoxButtons.OK);
                            //this.Hide();
                            //return;
                            DialogResult Dialog = TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_QUESTION,
                                   ASSEMBLY_ID,
                                   DeleteMessage,
                                   0,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxDefaultButton.Button2);
                            if (Dialog == DialogResult.Yes)
                            {
                                status = this._goodsMngAcs.Delete(goodsMng);
                            }
                            else
                            {
                                return;
                            }
                            // --- UPD 2018/11/08 ���O for redmine#49781 ----------<<<<<
                        }
                    }
                }
                else
                {
                    status = this._goodsMngAcs.Delete(goodsMng);
                }
                // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
                switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();
                        this._goodsMngTable.Remove(goodsMng.FileHeaderGuid);

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._goodsMngAcs);

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
                            this._goodsMngAcs,					  // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
            GoodsMng goodsMng = ((GoodsMng)_goodsMngTable[guid]).Clone();

            status = this._goodsMngAcs.Revival(ref goodsMng);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._goodsMngAcs);

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
                        this._goodsMngAcs,					  // �G���[�����������I�u�W�F�N�g
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
            GoodsMngToDataSet(goodsMng, this.DataIndex);

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
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date        : 2007.08.27</br>
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
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            GoodsUnitData goodsUnitData = null;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

			//----- ueno add ---------- start 2008.03.31
			// �ҏW�O�C�x���g�ꎞ��~
			this.tEdit_SectionCodeAllowZero.BeforeEnterEditMode -= this.tEdit_SectionCodeAllowZero_BeforeEnterEditMode;
			//----- ueno add ---------- end 2008.03.31
            bool canChangeFocus = true;
            DispSetStatus dispSetStatus = DispSetStatus.Clear;

            if (e.NextCtrl == this.tNedit_GoodsMakerCd)
            {
                prvGoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            }


            //GoodsMngtEdit_SectionCodeAllowZero

            switch (e.PrevCtrl.Name)
            {
                #region �����_��񌟍�
				case "tEdit_SectionCodeAllowZero":
                    {
                        #region < ���̓`�F�b�N >
                        if (this.tEdit_SectionCodeAllowZero.DataText != "")
                        {
							//----- ueno add ---------- start 2008.03.28
							// ���_�R�[�h�[���l�ߏ���
							this.tEdit_SectionCodeAllowZero.Text = GetZeroPaddedTextProc(this.tEdit_SectionCodeAllowZero.Text, this.tEdit_SectionCodeAllowZero.ExtEdit.Column);

                             //���_�R�[�h���[���̏ꍇ�A���ʂƂ���
                            if (this.tEdit_SectionCodeAllowZero.DataText == "00")
                            {
                                this.SectionName_tEdit.DataText = "�S�Ћ���";
                                if (e.Key == Keys.Return)
                                {
                                    if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    //else //DEL 2012/09/21 ���� for redmine#32367
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONGOODS) //ADD 2012/09/21 ���� for redmine#32367
                                    {
                                        e.NextCtrl = tEdit_GoodsNo;
                                        e.NextCtrl.Select();
                                    }
                                    // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
                                }
                                break;
                            }

							//----- ueno add ---------- end 2008.03.28

                            // ���_�f�[�^�N���X
                            SecInfoSet secInfoSet;
                            // ���_�f�[�^�N���X�C���X�^���X��
                            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();

                            #region < ���_���擾���� >
                            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.DataText);
                            #endregion

                            #region < ��ʕ\������ >

                            if (status == 0 && secInfoSet.LogicalDeleteCode != 1)
                            {
                                #region -- �擾�f�[�^�W�J --
                                // �擾�f�[�^�\��
                                // ���_����ʕ\��
                                this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm;
                                if (e.Key == Keys.Return)
                                {
                                    if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    //else //DEL 2012/09/21 ���� for redmine#32367
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONGOODS) //ADD 2012/09/21 ���� for redmine#32367
                                    {
                                        e.NextCtrl = tEdit_GoodsNo;
                                        e.NextCtrl.Select();
                                    }
                                    // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
                                }
                                #endregion
                            }
                            else
                            {
                                #region -- �擾���s --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Clear();
                                this.SectionName_tEdit.Clear();
                                e.NextCtrl = SectionGuide_Button;
                                e.NextCtrl.Select();

                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero.Clear();
                            this.SectionName_tEdit.Clear();
                        }


                        #endregion
                        break;
                    }

                #endregion

                #region �����[�J�[��񌟍�
                case "tNedit_GoodsMakerCd":
                    {
                        #region < �[�����̓`�F�b�N >
                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {

                            // ���[�J�[�f�[�^�N���X
                            //Maker maker;
                            MakerUMnt makerUMnt;
                            // ���i�f�[�^�N���X�C���X�^���X��
                            MakerAcs makerAcs = new MakerAcs();

                            #region < ���[�J�[���擾���� >
                            makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());
                            #endregion

                            #region < ��ʕ\������ >

                            if (makerUMnt != null && makerUMnt.LogicalDeleteCode !=1)
                            {
                                #region -- �擾�f�[�^�W�J --
                                // ���[�J�[����ʕ\��
                                this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                                if (e.Key == Keys.Return)
                                {
                                    if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                                    {
                                        e.NextCtrl.Select();
                                        e.NextCtrl = tNedit_SupplierCd;
                                    }
                                    //else //DEL 2012/09/21 ���� for redmine#32367
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL) //ADD 2012/09/21 ���� for redmine#32367
                                    {
                                        e.NextCtrl.Select();
                                        e.NextCtrl = tNedit_BLGoodsCode;
                                    }
                                    // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
                                    {
                                        e.NextCtrl.Select();
                                        e.NextCtrl = tNedit_GoodsMGroup;
                                    }
                                    // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
                                }
                                #endregion
                            }
                            else
                            {
                                #region -- �擾���s --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_GoodsMakerCd.Clear();
                                this.GoodsMakerName_tEdit.Clear();
                                e.NextCtrl.Select();
                                e.NextCtrl = GoodsMakerGuide_Button;

                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Clear();
                            this.GoodsMakerName_tEdit.Clear();
                        }

                        if (prvGoodsMakerCd != tNedit_GoodsMakerCd.GetInt())
                        {
                            // ���i���̓N���A
                            this.tEdit_GoodsNo.Clear();
                            this.GoodsName_tEdit.Clear();
                        }
                        #endregion

                        break;
                    }

                #endregion

                #region �����i��񌟍�
                case "tEdit_GoodsNo":
                    {
                        #region < ����̓`�F�b�N >
                        if (this.tEdit_GoodsNo.DataText != "")
                        {
                            //string searchCode;
                            // �����̎�ނ��擾
                            //int searchType = this.GetSearchType(this.tEdit_GoodsNo.DataText, out searchCode);
                            //��ʂ̏�����
                            this.GoodsName_tEdit.DataText = "";
                            this.tNedit_GoodsMakerCd.Clear();
                            this.tNedit_BLGoodsCode.Clear();
                            this._blGoodsCode = 0;//ADD 2012/10/08 ������for redmine#32367
                            this.GoodsMakerName_tEdit.DataText = "";
                            this.BLGoodsName_tEdit.DataText = "";
                            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
                            // ���������̐ݒ�
                            GoodsCndtn goodsCndtn = new GoodsCndtn();
                            goodsCndtn.EnterpriseCode = this._enterpriseCode;
                            goodsCndtn.GoodsMakerCd   = this.tNedit_GoodsMakerCd.GetInt();
                            goodsCndtn.MakerName      = this.GoodsMakerName_tEdit.DataText;
                            //goodsCndtn.BLGoodsCode    = this.tNedit_BLGoodsCode.GetInt();
                            //goodsCndtn.BLGoodsName    = this.BLGoodsName_tEdit.DataText;
                            goodsCndtn.GoodsNo = this.tEdit_GoodsNo.DataText;//searchCode;
                            //goodsCndtn.GoodsNoSrchTyp = searchType;
                            //GoodsAcs goodsAcs         = new GoodsAcs();
                            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<

                            // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                            goodsCndtn.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                            goodsCndtn.BLGoodsName = this.BLGoodsName_tEdit.DataText;
                            goodsCndtn.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
                            goodsCndtn.GoodsMGroupName = this.tEdit_GoodsMGroupName.DataText;
                            // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<

                            // 2008.08.22 �C�� >>>>>>>>>>>>>>>>>>>>
                            //List<GoodsUnitData> goodsUnitDataList;
                            //string message;
                            // 2008.08.22 �C�� <<<<<<<<<<<<<<<<<<<<

                            #region < ���i�������� >



                            // 2008.08.22 �C�� >>>>>>>>>>>>>>>>>>>>
                            /* 
                            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
                            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
                            //int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
                            int status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
                            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
                            */

                            // ���݃`�F�b�N
                            switch (CheckGoodsNo(goodsCndtn, out goodsUnitData))
                            {
                              case (int)InputChkStatus.Normal:
                                    {
                                        dispSetStatus = DispSetStatus.Update;
                                        break;
                                     }   
                              case (int)InputChkStatus.NotInput:
                                    {
                                        dispSetStatus = DispSetStatus.Clear;
                                        break;
                                    }
                              case (int)InputChkStatus.Cancel:
                                    {
                                        dispSetStatus = DispSetStatus.Clear;
                                        break;
                                    }       
                              default:
                                   {
                                        TMsgDisp.Show(
                                                this, 												// �e�E�B���h�E�t�H�[��
                                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                                this.Name,											// �A�Z���u��ID
                                                "�w�肳�ꂽ�����ŕi�Ԃ͑��݂��܂���ł����B",       // �\�����郁�b�Z�[�W
                                                0,													// �X�e�[�^�X�l
                                                MessageBoxButtons.OK);								// �\������{�^��
                                        
                                                //dispSetStatus = this._chgSrcGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                                                break;
                                    }
                             }   
                            // �f�[�^�ݒ�
                             DispSetChgDestGoodsNo(dispSetStatus, ref canChangeFocus, goodsUnitData);

                            // 2008.08.22 �C�� <<<<<<<<<<<<<<<<<<<<
                            #endregion

                            #region < ��ʕ\������ >
                            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                            //{
                            //    #region -- �擾�f�[�^�W�J --
                            //    // ���i�}�X�^�f�[�^�N���X
                            //    GoodsUnitData goodsUnitData = new GoodsUnitData();
                            //    goodsUnitData = goodsUnitDataList[0];

                            //    // ���i����ʕ\��
                            //    this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                            //    this.GoodsMakerName_tEdit.DataText = goodsUnitData.MakerName;
                            //    this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                            //    this.GoodsName_tEdit.DataText = goodsUnitData.GoodsName;
                            //    #endregion
                            //}
                            //else
                            //    // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
                            //    if (status == -1)
                            //    {
                            //        #region -- �L�����Z�� --
                            //        e.NextCtrl = e.PrevCtrl;
                            //        #endregion
                            //    }
                            //    else
                            //    // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
                            //    {
                            //        #region -- �擾���s --
                            //        TMsgDisp.Show(
                            //            this,
                            //            emErrorLevel.ERR_LEVEL_INFO,
                            //            this.Name,
                            //            "���i�R�[�h [" + searchCode + "] �ɊY������f�[�^�����݂��܂���B",
                            //            -1,
                            //            MessageBoxButtons.OK);

                            //        // ���i���N���A
                            //        this.tEdit_GoodsNo.Clear();
                            //        this.GoodsName_tEdit.Clear();
                            //       #endregion
                            
                            #endregion
                        }
                        else
                        {
                            // ���i�R�[�h�����ɖ߂�
                            this.tEdit_GoodsNo.DataText = "";
                            // ���i���̂̃N���A
                            this.GoodsName_tEdit.DataText = "";
                            this.tNedit_GoodsMakerCd.Clear();
                            this.tNedit_BLGoodsCode.Clear();
                            this._blGoodsCode = 0;//ADD 2012/10/08 ������for redmine#32367
                            this.GoodsMakerName_tEdit.DataText = "";
                            this.BLGoodsName_tEdit.DataText = "";
                            this.tNedit_GoodsMGroup.Clear();
                            this.tEdit_GoodsMGroupName.DataText = "";

                        }
                        if (canChangeFocus == false)
                        {
                            e.NextCtrl = e.PrevCtrl;
                            e.NextCtrl.Select();
                        }

                        #endregion

                        break;
                    }
                #endregion

                //#region BL�R�[�h����
                //case "tNedit_BLGoodsCode":
                //    {
                //        #region < �[�����̓`�F�b�N >
                //        if (this.tNedit_BLGoodsCode.GetInt() != 0)
                //        {

                //            // ���[�J�[�f�[�^�N���X
                //            BLGoodsCdUMnt bLGoodsCdUMnt;
                //            // ���i�f�[�^�N���X�C���X�^���X��
                //            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();

                //            #region < BL�R�[�h���擾���� >
                //            bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                //            #endregion

                //            #region < ��ʕ\������ >

                //            if (bLGoodsCdUMnt != null && bLGoodsCdUMnt.LogicalDeleteCode !=1)
                //            {
                //                #region -- �擾�f�[�^�W�J --
                //                // BL�R�[�h����ʕ\��
                //                this.BLGoodsName_tEdit.DataText = bLGoodsCdUMnt.BLGoodsFullName;
                //                if (e.Key == Keys.Return)
                //                {
                //                    e.NextCtrl.Select();
                //                    e.NextCtrl = tNedit_SupplierCd;
                //                }
                //                #endregion
                //            }
                //            else
                //            {
                //                #region -- �擾���s --
                //                TMsgDisp.Show(
                //                    this,
                //                    emErrorLevel.ERR_LEVEL_INFO,
                //                    this.Name,
                //                    "�Y������f�[�^�����݂��܂���B",
                //                    -1,
                //                    MessageBoxButtons.OK);

                //                this.tNedit_BLGoodsCode.Clear();
                //                this.BLGoodsName_tEdit.Clear();
                //                e.NextCtrl.Select();
                //                e.NextCtrl = e.PrevCtrl;

                //                #endregion
                //            }
                //            #endregion
                //        }
                //        else
                //        {
                //            this.tNedit_BLGoodsCode.Clear();
                //            this.BLGoodsName_tEdit.Clear();
                //        }
                //        #endregion

                //        break;
                //    }



                //#endregion

                // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                #region BL�R�[�h����
                case "tNedit_BLGoodsCode":
                    {
                        #region < �[�����̓`�F�b�N >
                        if (this.tNedit_BLGoodsCode.GetInt() != _blGoodsCode)
                        {
                            if (this.tNedit_BLGoodsCode.GetInt() != 0)
                            {
                                // ���[�J�[�f�[�^�N���X
                                BLGoodsCdUMnt bLGoodsCdUMnt;
                                // ���i�f�[�^�N���X�C���X�^���X��
                                BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();

                                #region < BL�R�[�h���擾���� >
                                int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                                #endregion

                                #region < ��ʕ\������ >

                                if (status == 0 && bLGoodsCdUMnt != null && bLGoodsCdUMnt.LogicalDeleteCode != 1)
                                {
                                    #region -- �擾�f�[�^�W�J --
                                    // BL�R�[�h����ʕ\��
                                    this.BLGoodsName_tEdit.DataText = bLGoodsCdUMnt.BLGoodsFullName;
                                    _blGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                                    BLGoodsCdUMnt bLGoodsCdUMnt2;
                                    BLGroupU bLGroupU;
                                    GoodsGroupU goodsGroupU;
                                    UserGdBdU userGdBdU;

                                    GoodsAcs _goodsAcs = new GoodsAcs();
                                    _goodsAcs.GetBLGoodsRelation(this.tNedit_BLGoodsCode.GetInt(), out bLGoodsCdUMnt2, out bLGroupU, out goodsGroupU, out userGdBdU);
                                    if (goodsGroupU != null)
                                    {
                                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                                        this.tEdit_GoodsMGroupName.Text = goodsGroupU.GoodsMGroupName;
                                    }
                                    if (e.Key == Keys.Return)
                                    {
                                        e.NextCtrl.Select();
                                        e.NextCtrl = tNedit_SupplierCd;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region -- �擾���s --
                                    //_blGoodsCode = 0; //DEL 2012/10/08 ������for redmine#32367

                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������f�[�^�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.tNedit_BLGoodsCode.Clear();
                                    this._blGoodsCode = 0;//ADD 2012/10/08 ������for redmine#32367
                                    this.BLGoodsName_tEdit.Clear();
                                    this.tNedit_GoodsMGroup.Clear();
                                    this.tEdit_GoodsMGroupName.Clear();
                                    e.NextCtrl.Select();
                                    e.NextCtrl = BLGoodsGuide_Button;
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                this.tNedit_BLGoodsCode.Clear();
                                this._blGoodsCode = 0;//ADD 2012/10/08 ������for redmine#32367
                                this.BLGoodsName_tEdit.Clear();
                                this.tNedit_GoodsMGroup.Clear();
                                this.tEdit_GoodsMGroupName.Clear();
                            }
                        }
                        if (this.tNedit_BLGoodsCode.GetInt() != 0)
                        {
                            if (e.Key == Keys.Return)
                            {
                                e.NextCtrl.Select();
                                e.NextCtrl = tNedit_SupplierCd;
                            }
                        }
                        #endregion

                            break;
                        }
                #endregion

                #region �����ތ���
                case "tNedit_GoodsMGroup":
                    {
                        #region < �[�����̓`�F�b�N >
                        if (this.tNedit_GoodsMGroup.GetInt() != 0)
                        {
                            GoodsGroupU goodsGroupU;
                            GoodsGroupUAcs goodsGroupUAcs = new GoodsGroupUAcs();

                            #region < �����ޏ��擾���� >
                            int status = goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, this.tNedit_GoodsMGroup.GetInt());
                            #endregion

                            #region < ��ʕ\������ >

                            if (status == 0 && goodsGroupU !=null && goodsGroupU.LogicalDeleteCode != 1)//LogicalDeleteCode�_���폜�敪(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)
                            {
                                #region -- �擾�f�[�^�W�J --
                                // ����ʕ\��
                                this.tEdit_GoodsMGroupName.DataText = goodsGroupU.GoodsMGroupName;
                                if (e.Key == Keys.Return)
                                {
                                    e.NextCtrl.Select();
                                    e.NextCtrl = tNedit_SupplierCd;
                                }
                                #endregion
                            }
                            else
                            {
                                #region -- �擾���s --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_GoodsMGroup.Clear();
                                this.tEdit_GoodsMGroupName.Clear();
                                e.NextCtrl.Select();
                                e.NextCtrl = GoodsMGroupGuidButton;
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tNedit_GoodsMGroup.Clear();
                            this.tEdit_GoodsMGroupName.Clear();
                        }
                        #endregion

                        break;
                    }
                #endregion
                // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<

                #region ���d����
                case "tNedit_SupplierCd":
                    {
                        #region < ���̓`�F�b�N >
                        if (this.tNedit_SupplierCd.GetInt() != 0)
                        {
                            // ������f�[�^�N���X
                            Supplier supplier;
                            // ������f�[�^�N���X�C���X�^���X��
                            SupplierAcs supplierInfoAcs = new SupplierAcs();

                            #region < �������擾���� >
                            int status = supplierInfoAcs.Read(out supplier, this._enterpriseCode, this.tNedit_SupplierCd.GetInt());
                            #endregion

                            #region < ��ʕ\������ >

                            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
                            if ((status == 0) && (supplier.LogicalDeleteCode != 1))
    
                            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
                            {
                                #region -- �擾�f�[�^�W�J --
                                // �擾�f�[�^�\��
                                // ��������ʕ\��
                                this.SupplierNm_tEdit.DataText = supplier.SupplierSnm;

                                if (e.Key == Keys.Return)
                                {
                                    e.NextCtrl = tNedit_SupplierLot;
                                    e.NextCtrl.Select();
                                }
                                #endregion
                            }
                            else
                            {
                                #region -- �擾���s --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "�Y������f�[�^�����݂��܂���B",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_SupplierCd.Clear();
                                this.SupplierNm_tEdit.Clear();
                                e.NextCtrl = SupplierGd_ultraButton;
                                e.NextCtrl.Select();
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tNedit_SupplierCd.Clear();
                            this.SupplierNm_tEdit.Clear();
                        }
                        #endregion

                        if (this.SettingSupplier(SupplierMode.Supplier1) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            e.NextCtrl = e.PrevCtrl;
                            e.NextCtrl.Select();
                        }
                        break;
                    }

                #endregion
            }
            if (e.PrevCtrl == Ok_Button && e.Key == Keys.Up)
            {
                e.NextCtrl = tNedit_SupplierLot;
                e.NextCtrl.Select();
            }

            //----- ueno add ---------- start 2008.03.31
			// �ҏW�O�C�x���g�ĊJ
			this.tEdit_SectionCodeAllowZero.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.tEdit_SectionCodeAllowZero_BeforeEnterEditMode);
			//----- ueno add ---------- end 2008.03.31

            // --- DEL 2012/10/08 ������for redmine#32367 ---------->>>>>
            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            //switch (e.NextCtrl.Name)
            //{
            //    case "tNedit_SupplierCd":       // �d����R�[�h
            //    case "tNedit_SupplierLot":      // ���ʃ��b�g
            //        {
            //            if (this._dataIndex < 0)
            //            {
            //                if (ModeChangeProc())
            //                {
            //                    e.NextCtrl = tEdit_SectionCodeAllowZero;
            //                }
            //            }
            //            break;
            //        }
            //}
            // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            // --- DEL 2012/10/08 ������for redmine#32367 ----------<<<<<

            // --- ADD 2012/10/08 ������for redmine#32367 ---------->>>>>
            if ( (this.SetKind_tComboEditor.Text ==  SETKIND_SECTIONGOODS) //���_�{�i��
                || (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)�@//���_�{���[�J�[ 
                || (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL && this.tNedit_GoodsMakerCd.GetInt() != 0 && this.tNedit_BLGoodsCode.GetInt() != 0)�@// ���_�{���[�J�[�{�����ށ{�a�k
                || (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER && this.tNedit_GoodsMakerCd.GetInt() != 0 && this.tNedit_GoodsMGroup.GetInt() != 0))�@// ���_�{���[�J�[�{������
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_SupplierCd":       // �d����R�[�h
                    case "tNedit_SupplierLot":      // ���ʃ��b�g
                        {
                            if (this._dataIndex < 0)
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = tEdit_SectionCodeAllowZero;
                                }
                            }
                            break;
                        }
                }
            }
            // --- ADD 2012/10/08 ������for redmine#32367 ----------<<<<<
        }

        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        /// <remarks>
        /// Note			:	����������@���擾���鏈�����s���܂��B<br />
        /// Programmer      :   980035 ����@��`<br />
        /// Date            :   2007.08.27<br />
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *�����݂��Ȃ����ߊ��S��v����
                return 0;
            }
        }

        # endregion

		# region �K�C�h����
        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ���_�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            //----- ueno add ---------- start 2008.03.28
            // ���ʃR�[�h�L��
            //int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
            //----- ueno add ---------- end 2008.03.28

            if (status != 0) return;

            // �擾�f�[�^�\��
            this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode;
            this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm;
            if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
            {
                tNedit_GoodsMakerCd.Focus();
            }
            else
            {
                tEdit_GoodsNo.Focus();
            }

        }

        /// <summary>
        /// Control.Click �C�x���g(GoodsMakerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ���i���[�J�[�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void GoodsMakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = new MakerUMnt();

            //���[�J�[�K�C�h�N��
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            // �擾�f�[�^�\��
            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
            this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;

            // ���i�f�[�^�Ƃ̐���������邽�ߏ��i���̃N���A
            this.tEdit_GoodsNo.Clear();
            this.GoodsName_tEdit.Clear();

            if (this.tNedit_GoodsMakerCd.GetInt() != 0)
            {
                if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                {
                    tNedit_SupplierCd.Focus();
                }
                else
                {
                    tNedit_BLGoodsCode.Focus();
                }
            }
        }


        //// 2008.08.22 >>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// Control.Click �C�x���g(BLGoodsCodeGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : BL�R�[�h�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30350�@�N��@����</br>
        /// <br>Date        : 2008.08.22</br>
        /// <br>Update Note : 2012/10/08 ������ </br>
        ///	<br>			�Eredmine#32367 ��Q�ꗗ�̑Ή�</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {

            // ���������̐ݒ�
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();

            //BL�R�[�h�K�C�h�N��
            int status = bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            // �擾�f�[�^�\��
            this.tNedit_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
            //_blGoodsCode = this.tNedit_BLGoodsCode.GetInt();//ADD 2012/09/21 ���� for redmine#32367 //DEL 2012/10/08 ������ for redmine#32367
            this.BLGoodsName_tEdit.DataText = bLGoodsCdUMnt.BLGoodsFullName;
            if (this.tNedit_BLGoodsCode.GetInt() != 0)
            {   // --- ADD 2012/10/08 ������ for redmine#32367 ---------->>>>>
                if (this.tNedit_BLGoodsCode.GetInt() != _blGoodsCode)
                {
                    _blGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                    // --- ADD 2012/10/08 ������ for redmine#32367 ----------<<<<<

                    // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                    BLGroupU bLGroupU;
                    GoodsGroupU goodsGroupU;
                    UserGdBdU userGdBdU;
                    GoodsAcs _goodsAcs = new GoodsAcs();
                    _goodsAcs.GetBLGoodsRelation(this.tNedit_BLGoodsCode.GetInt(), out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);
                    if (goodsGroupU != null)
                    {
                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                        this.tEdit_GoodsMGroupName.Text = goodsGroupU.GoodsMGroupName;
                    }
                    // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
                }//ADD 2012/10/08 ������ for redmine#32367
                tNedit_SupplierCd.Focus();
            }
        }
        //// 2008.08.22 �C�� <<<<<<<<<<<<<<<<<<<<




        /// <summary>
        /// Control.Click �C�x���g(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �d����K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void SupplierGd_ultraButton_Click(object sender, EventArgs e)
        {
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ���Ӑ�K�C�h
            //Infragistics.Win.Misc.UltraButton _pushBtn = (Infragistics.Win.Misc.UltraButton)sender;
            //PMKHN04001UA customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_SUPPLIER, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);

            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect1);
            //customerSearchForm.ShowDialog(this);


            //// 2008.08.22 >>>>>>>>>>>>>>>>>>>>>>>>>>

            //Supplier supplier;
            //this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
            //this.SettingSupplier(SupplierMode.Supplier1, supplier.SupplierCd);

            TNedit CodeCtrl = new TNedit();
            TEdit NameCtrl = new TEdit();

            CodeCtrl = this.tNedit_SupplierCd;
            NameCtrl = this.SupplierNm_tEdit;

            Supplier supplier;
            SupplierAcs supplierAcs = new SupplierAcs();

            int status = supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CodeCtrl.SetInt(supplier.SupplierCd);
                NameCtrl.DataText = supplier.SupplierNm1;
            }
            if (this.tNedit_SupplierCd.GetInt() != 0)
            {
                tNedit_SupplierLot.Focus();
            }
           // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //// 2008.08.22 �C�� <<<<<<<<<<<<<<<<<<<<
        }




        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>���Ӑ�I���������C�x���g</summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        //private void CustomerSearchForm_CustomerSelect1(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //        if (customerInfo.SupplierDiv == 0)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "���Ӑ�͑I���o���܂���B",
        //                status,
        //                MessageBoxButtons.OK);
        //            return;
        //        }
        //        // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //            //"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
        //            "�I�������d����͊��ɍ폜����Ă��܂��B",
        //            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //                      //"���Ӑ���̎擾�Ɏ��s���܂����B",
        //                      "�d������̎擾�Ɏ��s���܂����B",
        //                      // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    this.SupplierCd1_tNedit.Text = customerInfo.CustomerCode.ToString();
        //    this.SupplierNm1_tEdit.Text = customerInfo.Name;
        //}

        //private void CustomerSearchForm_CustomerSelect2(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //        if (customerInfo.SupplierDiv == 0)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "���Ӑ�͑I���o���܂���B",
        //                status,
        //                MessageBoxButtons.OK);
        //            return;
        //        }
        //        // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //            //"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
        //            "�I�������d����͊��ɍ폜����Ă��܂��B",
        //            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //                      //"���Ӑ���̎擾�Ɏ��s���܂����B",
        //                      "�d������̎擾�Ɏ��s���܂����B",
        //                      // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    this.SupplierCd2_tNedit.Text = customerInfo.CustomerCode.ToString();
        //    this.SupplierNm2_tEdit.Text = customerInfo.Name;
        //}

        //private void CustomerSearchForm_CustomerSelect3(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //        if (customerInfo.SupplierDiv == 0)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "���Ӑ�͑I���o���܂���B",
        //                status,
        //                MessageBoxButtons.OK);
        //            return;
        //        }
        //        // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //            //"�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
        //            "�I�������d����͊��ɍ폜����Ă��܂��B",
        //            // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      // 2008.02.28 �C�� >>>>>>>>>>>>>>>>>>>>
        //                      //"���Ӑ���̎擾�Ɏ��s���܂����B",
        //                      "�d������̎擾�Ɏ��s���܂����B",
        //                      // 2008.02.28 �C�� <<<<<<<<<<<<<<<<<<<<
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    this.SupplierCd3_tNedit.Text = customerInfo.CustomerCode.ToString();
        //    this.SupplierNm3_tEdit.Text = customerInfo.Name;
        //}
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        # endregion

		//----- ueno add ---------- start 2008.03.31
		/// <summary>
		/// tEdit_SectionCodeAllowZero_BeforeEnterEditMode
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note        : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
		/// <br>Programmer  : 30167 ���@�O�M</br>
		/// <br>Date        : 2008.03.31</br>
		/// </remarks>
		private void tEdit_SectionCodeAllowZero_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// ChangeFocus�C�x���g�ꎞ��~
			this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

			// �擪�̃[���l�߂��폜
			this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text);

			// ChangeFocus�C�x���g�ĊJ
			this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
		}
		//----- ueno add ---------- end 2008.03.31

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d������ݒ菈��
        /// </summary>
        /// <param name="supplierMode">�d����R���|�w��</param>
        private int SettingSupplier(SupplierMode supplierMode)
        {
            TNedit CodeCtrl = new TNedit();

            switch (supplierMode)
            {
                case SupplierMode.Supplier1:
                    CodeCtrl = this.tNedit_SupplierCd;
                    break;
            }

            return this.SettingSupplier(supplierMode, CodeCtrl.GetInt());
        }

        /// <summary>
        /// �ݒ��ʕύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ݒ��ʂ��ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/18</br>
        /// <br>Update Note: 2012/10/08 ������ </br>
        ///	<br>		   �Eredmine#32367 ��Q�ꗗ�̑Ή�</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            ////���_�{���[�J�[�{BL�R�[�h
            //if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONBLMAKER)
            //   {
            //       this.tNedit_GoodsMakerCd.Enabled = true;
            //       this.tEdit_GoodsNo.Enabled = false;
            //       this.GoodsMakerGuide_Button.Enabled = true;  // ���i���[�J�[�K�C�h�{�^��
            //       this.tNedit_BLGoodsCode.Enabled = true;
            //       this.BLGoodsGuide_Button.Enabled = true;
            //   }

               //���_�{���[�J�[
               if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
               {
                   this.tNedit_GoodsMakerCd.Enabled = true;
                   this.tEdit_GoodsNo.Enabled = false;
                   this.GoodsMakerGuide_Button.Enabled = true;  // ���i���[�J�[�K�C�h�{�^��
                   this.tNedit_BLGoodsCode.Enabled = false;
                   this.BLGoodsGuide_Button.Enabled = false;
                   // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                   this.tNedit_GoodsMGroup.Enabled = false;
                   this.GoodsMGroupGuidButton.Enabled = false;
                   // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
               }

               //���_�{�i��
               //else //DEL 2012/09/21 ���� for redmine#32367
               else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONGOODS) //ADD 2012/09/21 ���� for redmine#32367
               {
                   this.tNedit_GoodsMakerCd.Enabled = true;
                   this.tEdit_GoodsNo.Enabled = true;
                   this.GoodsMakerGuide_Button.Enabled = false;  // ���i���[�J�[�K�C�h�{�^��
                   this.tNedit_GoodsMakerCd.Enabled = false;
                   this.tNedit_BLGoodsCode.Enabled = false;
                   this.BLGoodsGuide_Button.Enabled = false;
                   // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
                   this.tNedit_GoodsMGroup.Enabled = false;
                   this.GoodsMGroupGuidButton.Enabled = false;
                   // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
               }
               // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
               //���_�{�����ށ{���[�J�[�{BL�R�[�h
               else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL)
               {
                   this.tNedit_GoodsMakerCd.Enabled = true;
                   this.tEdit_GoodsNo.Enabled = false;
                   this.GoodsMakerGuide_Button.Enabled = true;  // ���i���[�J�[�K�C�h�{�^��
                   this.tNedit_BLGoodsCode.Enabled = true;
                   this.BLGoodsGuide_Button.Enabled = true;
                   this.tNedit_GoodsMGroup.Enabled = false;
                   this.GoodsMGroupGuidButton.Enabled = false;
               }
               //���_�{�����ށ{���[�J�[
               else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
               {
                   this.tNedit_GoodsMakerCd.Enabled = true;
                   this.tEdit_GoodsNo.Enabled = false;
                   this.GoodsMakerGuide_Button.Enabled = true;  // ���i���[�J�[�K�C�h�{�^��
                   this.tNedit_BLGoodsCode.Enabled = false;
                   this.BLGoodsGuide_Button.Enabled = false;
                   this.tNedit_GoodsMGroup.Enabled = true;
                   this.GoodsMGroupGuidButton.Enabled = true;
               }
               // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
               if (this._mainOfficeFuncFlag == 1)
               {
                   this.tEdit_SectionCodeAllowZero.Clear();
                   this.SectionName_tEdit.Clear();
               }
               this.tNedit_GoodsMakerCd.Clear();
               this.GoodsMakerName_tEdit.Clear();
               this.tEdit_GoodsNo.Clear();
               this.GoodsName_tEdit.Clear();
               this.tNedit_BLGoodsCode.Clear();
               this.BLGoodsName_tEdit.Clear();
               this.tNedit_SupplierCd.Clear();
               this.SupplierNm_tEdit.Clear();
               this.tNedit_SupplierLot.Clear();
               this.tNedit_GoodsMGroup.Clear();
               this.tEdit_GoodsMGroupName.Clear();
               _blGoodsCode = 0;//ADD 2012/10/08 ������ for redmine#32367 
        }
        
        /// <summary>
        /// �d������ݒ菈��
        /// </summary>
        /// <param name="supplierMode">�d����R���|�w��</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        private int SettingSupplier(SupplierMode supplierMode, int supplierCode)
        {
            TNedit CodeCtrl = new TNedit();
            TEdit NameCtrl = new TEdit();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            switch (supplierMode)
            {
                case SupplierMode.Supplier1:
                    CodeCtrl = this.tNedit_SupplierCd;
                    NameCtrl = this.SupplierNm_tEdit;
                    break;

            }

            if (CodeCtrl.GetInt() != 0)
            {
                Supplier supplier;
                SupplierAcs supplierAcs = new SupplierAcs();

                status = supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CodeCtrl.SetInt(supplier.SupplierCd);
                    NameCtrl.DataText = supplier.SupplierSnm;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�I�������d����͊��ɍ폜����Ă��܂��B",
                        status,
                        MessageBoxButtons.OK);
                    CodeCtrl.Clear();
                    NameCtrl.Clear();
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "�d������̎擾�Ɏ��s���܂����B",
                        status,
                        MessageBoxButtons.OK);
                    //CodeCtrl.Clear();
                    NameCtrl.Clear();
                }
            }
            else
            {
                CodeCtrl.Clear();
               NameCtrl.Clear();
            }

            return status;

        }
        /// <summary>
        /// ���i�����ޓǍ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�����ވꗗ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30350 �N��@����</br>
        /// <br>Date       : 2009/01/09</br>
        /// </remarks>
        private void ReadGoodsMGroup()
        {
            this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

            ArrayList retList;

            int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (GoodsGroupU goodsGroupU in retList)
                {
                    if (goodsGroupU.LogicalDeleteCode == 0)
                    {
                        this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                    }
                }
            }

            return;
        }


        private void tNedit_GoodsMakerCd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tNedit_BLGoodsCode_ValueChanged(object sender, EventArgs e)
        {

        }


        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        /// <br>Update Note : 2010/12/03 ������</br>
        ///	<br>			�E���_�{���[�J�[�V�K�o�^���̕s��C��</br>
        /// <br>Update Note : 2012/10/08 ������ </br>
        ///	<br>			�Eredmine#32367 ��Q�ꗗ�̑Ή�</br>
        private bool ModeChangeProc()
        {
            string msg = "���͂��ꂽ�R�[�h�̏��i�Ǘ����}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');
            //// ���i�����ރR�[�h
            //int goodsMGroup = tNedit_GoodsMGroup.GetInt();
            // ���[�J�[�R�[�h
            int makerCd = tNedit_GoodsMakerCd.GetInt();
            //// BL�R�[�h
            //int blGoodsCode = tNedit_BLGoodsCode.GetInt();
            // �i��
            string goodsNo = tEdit_GoodsNo.Text.TrimEnd();
            // ---ADD 2010/12/03----------->>>>>
            // ���i�����ރR�[�h
            int goodsMGroup = tNedit_GoodsMGroup.GetInt();
            // BL�R�[�h
            int blGoodsCode = tNedit_BLGoodsCode.GetInt();
            // ---ADD 2010/12/03-----------<<<<<

            for (int i = 0; i < this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.SECTIONCODE_TITLE];
                //int dsGoodsMGroup = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.GOODSMGROUP_TITLE];
                int dsMakerCd = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.GOODSMAKERCD_TITLE];
                //int dsBLGoodsCode = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.BLGOODSCODE_TITLE];
                string dsGoodsNo = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.GOODSNO_TITLE];
                // ---UPD 2010/12/03----------->>>>>
                //if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                //    //(goodsMGroup == dsGoodsMGroup) &&
                //    (makerCd == dsMakerCd) &&
                //    //(blGoodsCode == dsBLGoodsCode) &&
                //    (goodsNo.Equals(dsGoodsNo.TrimEnd())))

                // ���i�����ރR�[�h
                int dsGoodsMGroup = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.GOODSMGROUP_TITLE];
                // BL�R�[�h
                int dsBLGoodsCode = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.BLGOODSCODE_TITLE];
                if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                    (goodsMGroup == dsGoodsMGroup) &&
                    (makerCd == dsMakerCd) &&
                    (blGoodsCode == dsBLGoodsCode) &&
                    (goodsNo.Equals(dsGoodsNo.TrimEnd())))
                // ---UPD 2010/12/03-----------<<<<<
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̏��i�Ǘ����}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�A���i�����ރR�[�h�A���[�J�[�R�[�h�ABL�R�[�h�A�i�Ԃ̃N���A
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionName_tEdit.Clear();
                        tNedit_GoodsMGroup.Clear();
                        tEdit_GoodsMGroupName.Clear();
                        tNedit_GoodsMakerCd.Clear();
                        GoodsMakerName_tEdit.Clear();
                        tNedit_BLGoodsCode.Clear();
                        BLGoodsName_tEdit.Clear();
                        tEdit_GoodsNo.Clear();
                        GoodsName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h�̏��i�Ǘ����}�X�^��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,   // �\�����郁�b�Z�[�W
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
                                // ���_�R�[�h�A���i�����ރR�[�h�A���[�J�[�R�[�h�ABL�R�[�h�A�i�Ԃ̃N���A
                                tEdit_SectionCodeAllowZero.Clear();
                                SectionName_tEdit.Clear();
                                tNedit_GoodsMGroup.Clear();
                                tEdit_GoodsMGroupName.Clear();
                                tNedit_GoodsMakerCd.Clear();
                                GoodsMakerName_tEdit.Clear();
                                tNedit_BLGoodsCode.Clear();
                                BLGoodsName_tEdit.Clear();
                                tEdit_GoodsNo.Clear();
                                GoodsName_tEdit.Clear();
                                _blGoodsCode = 0;//ADD 2012/10/08 ������ for redmine#32367  
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        // --- ADD 2012/09/21 ���� for redmine#32367 ---------->>>>>
        /// <summary>
        /// Control.Click �C�x���g(GoodsMGroupGuidButton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2012/09/21 ���� for redmine#32367</br>
        ///	<br>			�E���_�{�����ށ{���[�J�[�{BL�R�[�h�Ƌ��_�{�����ށ{���[�J�[�̒ǉ�</br>
        private void GoodsMGroupGuidButton_Click(object sender, EventArgs e)
        {
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }
            GoodsGroupU goodsGroupU;
            //�����ރK�C�h�N��
            int status = _goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
            if (status != 0) return;

            // �擾�f�[�^�\��
            this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
            this.tEdit_GoodsMGroupName.DataText = goodsGroupU.GoodsMGroupName;
            if (this.tNedit_GoodsMGroup.GetInt() != 0)
            {
                tNedit_SupplierCd.Focus();
            }
        }
        // --- ADD 2012/09/21 ���� for redmine#32367 ----------<<<<<
    }
}
