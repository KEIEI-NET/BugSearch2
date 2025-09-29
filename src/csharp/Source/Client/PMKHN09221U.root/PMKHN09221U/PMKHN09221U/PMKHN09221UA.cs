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
using Broadleaf.Windows.Forms;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// ���i�����ݒ�}�X�^ �t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���i�����ݒ���s���܂��B
    ///					 IMasterMaintenanceSingleType���������Ă��܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.19</br>
    /// <br></br>
    /// <br>Update Note: BL�R�[�h�X�V�敪�̒ǉ�(MANTIS[0014774])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/12/11</br>    
    /// <br></br>
    /// <br>Update Note: �I�[�v�����i�敪�̍��ڃ^�C�g���ύX(MANTIS[0015345])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/28</br>    
    /// <br>Update Note: Redmine#8191 �u���i�O�Ή��v�̑I�����̕����s���̑Ή�</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/11/29</br>
    /// <br>Update Note: Redmine#8191�̑Ή�</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/12/05</br> 
    /// <br>Update Note: �w�ʍX�V�s��Ή�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/06/26</br>  
    /// <br>Update Note: BL�R�[�h�X�V�s��Ή�</br>
    /// <br>Programmer : �{�{</br>
    /// <br>Date       : 2013/01/31</br>  
    /// </remarks>
	public class PMKHN09221UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel lblPartsLayer;
		private Infragistics.Win.Misc.UltraLabel lblName;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraLabel lblPrice;
		private Infragistics.Win.Misc.UltraLabel lblOpenPrice;
        private Infragistics.Win.Misc.UltraLabel lblPriceMngCnt;
        private Infragistics.Win.Misc.UltraLabel lblPriceChgProc;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private THtmlGenerate tHtmlGenerate1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPriceChgProc;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPriceMngCnt;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOpenPrice;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPartsLayer;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPrice;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbName;
        private Infragistics.Win.Misc.UltraLabel lblBLGoodsCdUpd;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbBLGoodsCdUpd;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// ���i�����ݒ�����̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�����̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public PMKHN09221UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canNew = false;
			this._canDelete = false;
			this._canClose = true;		// �f�t�H���g:true�Œ�
			this._canLogicalDeleteDataExtraction = false;
			this._canSpecificationSearch = false;
			this._defaultAutoFillToColumn = false;

			//�@��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;


			// �ϐ�������
			this._dataIndex = -1;
            this._PriceChgSetAcs = new PriceChgSetAcs();
			this._prevPriceChgSet = null;
			this._nextData = false;
			this._totalCount = 0;
			this._priceChgSetTable = new Hashtable();
            
			this._indexBuf = -2;
		
		}
		# endregion

		# region Dispose
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
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09221UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.lblPartsLayer = new Infragistics.Win.Misc.UltraLabel();
            this.lblName = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.lblOpenPrice = new Infragistics.Win.Misc.UltraLabel();
            this.lblPriceMngCnt = new Infragistics.Win.Misc.UltraLabel();
            this.lblPriceChgProc = new Infragistics.Win.Misc.UltraLabel();
            this.lblPrice = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.cmbPartsLayer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbOpenPrice = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbPriceMngCnt = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbPriceChgProc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbPrice = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbBLGoodsCdUpd = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblBLGoodsCdUpd = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartsLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOpenPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriceMngCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriceChgProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBLGoodsCdUpd)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 330);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(542, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Mode_Label
            // 
            appearance41.ForeColor = System.Drawing.Color.White;
            appearance41.TextHAlignAsString = "Center";
            appearance41.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance41;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(415, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(280, 284);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 136;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(405, 284);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 137;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // lblPartsLayer
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.lblPartsLayer.Appearance = appearance1;
            this.lblPartsLayer.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblPartsLayer.Location = new System.Drawing.Point(33, 74);
            this.lblPartsLayer.Name = "lblPartsLayer";
            this.lblPartsLayer.Size = new System.Drawing.Size(135, 24);
            this.lblPartsLayer.TabIndex = 92;
            this.lblPartsLayer.Text = "�w�ʍX�V�敪";
            // 
            // lblName
            // 
            appearance40.TextVAlignAsString = "Middle";
            this.lblName.Appearance = appearance40;
            this.lblName.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(33, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(135, 24);
            this.lblName.TabIndex = 91;
            this.lblName.Text = "���̍X�V�敪";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(155, 284);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 135;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Visible = false;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(280, 284);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 136;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Visible = false;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // lblOpenPrice
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.lblOpenPrice.Appearance = appearance38;
            this.lblOpenPrice.Location = new System.Drawing.Point(33, 185);
            this.lblOpenPrice.Name = "lblOpenPrice";
            this.lblOpenPrice.Size = new System.Drawing.Size(135, 23);
            this.lblOpenPrice.TabIndex = 93;
            this.lblOpenPrice.Text = "���i�O�Ή�";
            // 
            // lblPriceMngCnt
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.lblPriceMngCnt.Appearance = appearance37;
            this.lblPriceMngCnt.Location = new System.Drawing.Point(33, 215);
            this.lblPriceMngCnt.Name = "lblPriceMngCnt";
            this.lblPriceMngCnt.Size = new System.Drawing.Size(135, 23);
            this.lblPriceMngCnt.TabIndex = 96;
            this.lblPriceMngCnt.Text = "���i�Ǘ�����";
            // 
            // lblPriceChgProc
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.lblPriceChgProc.Appearance = appearance43;
            this.lblPriceChgProc.Location = new System.Drawing.Point(33, 245);
            this.lblPriceChgProc.Name = "lblPriceChgProc";
            this.lblPriceChgProc.Size = new System.Drawing.Size(135, 23);
            this.lblPriceChgProc.TabIndex = 101;
            this.lblPriceChgProc.Text = "���i���������敪";
            this.lblPriceChgProc.Visible = false;
            // 
            // lblPrice
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.lblPrice.Appearance = appearance25;
            this.lblPrice.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblPrice.Location = new System.Drawing.Point(33, 155);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(135, 24);
            this.lblPrice.TabIndex = 116;
            this.lblPrice.Text = "���i�X�V�敪";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(7, 142);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(530, 3);
            this.ultraLabel17.TabIndex = 120;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // tHtmlGenerate1
            // 
            this.tHtmlGenerate1.Align = Broadleaf.Library.Windows.Forms.align.center;
            this.tHtmlGenerate1.coltype = true;
            this.tHtmlGenerate1.Guusuucolor = System.Drawing.Color.PaleTurquoise;
            this.tHtmlGenerate1.GuusuuRow = true;
            this.tHtmlGenerate1.HaikeiColor = System.Drawing.Color.AliceBlue;
            this.tHtmlGenerate1.HightBR = 1;
            this.tHtmlGenerate1.koteicolcolor = System.Drawing.Color.RoyalBlue;
            this.tHtmlGenerate1.koteifontcolor = System.Drawing.Color.White;
            this.tHtmlGenerate1.RowBackColor = System.Drawing.Color.Transparent;
            this.tHtmlGenerate1.RowFontColor = System.Drawing.Color.Black;
            this.tHtmlGenerate1.RowFontSize = 7;
            this.tHtmlGenerate1.SelectedBackColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleColor = System.Drawing.Color.Navy;
            this.tHtmlGenerate1.TitleFontColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleFontSize = 7;
            // 
            // cmbPartsLayer
            // 
            this.cmbPartsLayer.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem15.DataValue = 0;
            valueListItem15.DisplayText = "����i�񋟖��ݒ蕪�͍X�V���j";
            valueListItem16.DataValue = 1;
            valueListItem16.DisplayText = "���Ȃ�";
            valueListItem17.DataValue = 2;
            valueListItem17.DisplayText = "����i�������X�V�j";
            this.cmbPartsLayer.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem15,
            valueListItem16,
            valueListItem17});
            this.cmbPartsLayer.Location = new System.Drawing.Point(197, 74);
            this.cmbPartsLayer.Name = "cmbPartsLayer";
            this.cmbPartsLayer.Size = new System.Drawing.Size(254, 24);
            this.cmbPartsLayer.TabIndex = 129;
            // 
            // cmbOpenPrice
            // 
            this.cmbOpenPrice.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem13.DataValue = 0;
            valueListItem13.DisplayText = "���i�����p��";
            valueListItem14.DataValue = 1;
            valueListItem14.DisplayText = "0�ōX�V����";
            this.cmbOpenPrice.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem13,
            valueListItem14});
            this.cmbOpenPrice.Location = new System.Drawing.Point(197, 185);
            this.cmbOpenPrice.Name = "cmbOpenPrice";
            this.cmbOpenPrice.Size = new System.Drawing.Size(177, 24);
            this.cmbOpenPrice.TabIndex = 132;
            // 
            // cmbPriceMngCnt
            // 
            this.cmbPriceMngCnt.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem10.DataValue = 3;
            valueListItem10.DisplayText = "3";
            valueListItem11.DataValue = 4;
            valueListItem11.DisplayText = "4";
            valueListItem12.DataValue = 5;
            valueListItem12.DisplayText = "5";
            this.cmbPriceMngCnt.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12});
            this.cmbPriceMngCnt.Location = new System.Drawing.Point(197, 215);
            this.cmbPriceMngCnt.Name = "cmbPriceMngCnt";
            this.cmbPriceMngCnt.Size = new System.Drawing.Size(177, 24);
            this.cmbPriceMngCnt.TabIndex = 133;
            // 
            // cmbPriceChgProc
            // 
            this.cmbPriceChgProc.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem8.DataValue = 0;
            valueListItem8.DisplayText = "�V���N�Ɠ���";
            valueListItem9.DataValue = 1;
            valueListItem9.DisplayText = "�蓮����";
            this.cmbPriceChgProc.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9});
            this.cmbPriceChgProc.Location = new System.Drawing.Point(197, 245);
            this.cmbPriceChgProc.Name = "cmbPriceChgProc";
            this.cmbPriceChgProc.Size = new System.Drawing.Size(177, 24);
            this.cmbPriceChgProc.TabIndex = 134;
            this.cmbPriceChgProc.Visible = false;
            // 
            // cmbName
            // 
            this.cmbName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "����";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "���Ȃ�";
            this.cmbName.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.cmbName.Location = new System.Drawing.Point(197, 44);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(177, 24);
            this.cmbName.TabIndex = 128;
            // 
            // cmbPrice
            // 
            this.cmbPrice.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem4.DataValue = 0;
            valueListItem4.DisplayText = "����";
            valueListItem5.DataValue = 1;
            valueListItem5.DisplayText = "���Ȃ�";
            this.cmbPrice.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5});
            this.cmbPrice.Location = new System.Drawing.Point(197, 155);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(177, 24);
            this.cmbPrice.TabIndex = 131;
            // 
            // cmbBLGoodsCdUpd
            // 
            this.cmbBLGoodsCdUpd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "����i�񋟖��ݒ蕪�͍X�V���j";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "���Ȃ�";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "����i�������X�V�j";
            this.cmbBLGoodsCdUpd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cmbBLGoodsCdUpd.Location = new System.Drawing.Point(197, 104);
            this.cmbBLGoodsCdUpd.Name = "cmbBLGoodsCdUpd";
            this.cmbBLGoodsCdUpd.Size = new System.Drawing.Size(254, 24);
            this.cmbBLGoodsCdUpd.TabIndex = 130;
            // 
            // lblBLGoodsCdUpd
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.lblBLGoodsCdUpd.Appearance = appearance39;
            this.lblBLGoodsCdUpd.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblBLGoodsCdUpd.Location = new System.Drawing.Point(33, 104);
            this.lblBLGoodsCdUpd.Name = "lblBLGoodsCdUpd";
            this.lblBLGoodsCdUpd.Size = new System.Drawing.Size(135, 24);
            this.lblBLGoodsCdUpd.TabIndex = 131;
            this.lblBLGoodsCdUpd.Text = "BL���ލX�V�敪";
            // 
            // PMKHN09221UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(542, 353);
            this.Controls.Add(this.lblBLGoodsCdUpd);
            this.Controls.Add(this.cmbBLGoodsCdUpd);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.cmbPriceChgProc);
            this.Controls.Add(this.cmbPriceMngCnt);
            this.Controls.Add(this.cmbOpenPrice);
            this.Controls.Add(this.cmbPartsLayer);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPriceMngCnt);
            this.Controls.Add(this.lblOpenPrice);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.lblPartsLayer);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.lblPriceChgProc);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09221UA";
            this.Text = "�񋟃f�[�^�X�V�ݒ�";
            this.Load += new System.EventHandler(this.PMKHN09221UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09221UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09221UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartsLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOpenPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriceMngCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriceChgProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBLGoodsCdUpd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
		# endregion
				
		#region Private Members
        private PriceChgSetAcs _PriceChgSetAcs;
        private PriceChgSet _prevPriceChgSet;
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _priceChgSetTable;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;

		private int _indexBuf;

        // HTML���
        private const string HTML_HEADER_TITLE = "�ݒ荀��";
        private const string HTML_HEADER_VALUE = "�ݒ�l";
        private const string HTML_UNREGISTER = "���ݒ�";
        
        // �G���[�o�͏��
        private const string CT_PGID = "PMKHN09221U";
        private const string CT_PGNM = "���i�����ݒ�";

		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE = "�폜��";
		//private const string CODE_TITLE = "�ŗ��R�[�h";
                
        private const string GUID_TITLE = "GUID";

        private const string PRICECHGSET_TABLE = "PRICECHGSET";

		//��r�pclone
        private PriceChgSet _priceChgSetClone;

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

		// 2005.06.21 ���ݒ莞�A�u���ݒ�v�ł͂Ȃ��󔒂ŕ\������B >>>> START
		//private const string UNREGISTER = "���ݒ�";
		private const string UNREGISTER = "";
		// 2005.06.21 ���ݒ莞�A�u���ݒ�v�ł͂Ȃ��󔒂ŕ\������B >>>> END

		string pgId = "PMKHN09221U";
        string pgNm = "���i�����ݒ�";
        string obj = "PriceChgSetAcs";
		
		#endregion
    
		# region Main
        //private static string[] _parameter;
        //private static System.Windows.Forms.Form _form = null;
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
        static void Main(String[] args) 
		{
            //try
            //{
            //    string msg = "";
            //    _parameter = args;
            //    //�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
            //    int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
            //    if (status == 0)
            //    {
            //        _form = new PMKHN09221UA();
            //        System.Windows.Forms.Application.Run(_form);
            //    }
            //    if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", msg, 0, MessageBoxButtons.OK);
            //}
            //catch (Exception ex)
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            //}
            //finally
            //{
            //    ApplicationStartControl.EndApplication();
            //}
			System.Windows.Forms.Application.Run(new PMKHN09221UA());
		}
		# endregion

		# region Properties
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get{ return this._canLogicalDeleteDataExtraction; }
		}

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get{ return this._canClose; }
			set{ this._canClose = value; }
		}

		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get{ return this._canNew; }
		}

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get{ return this._canDelete; }
		}

		/// <summary>�����w��Ǎ��ݒ�v���p�e�B</summary>
		/// <value>�����w��Ǎ����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanSpecificationSearch
		{
			get{ return this._canSpecificationSearch; }
		}

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get{ return this._dataIndex; }
			set{ this._dataIndex = value; }
		}

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get{ return this._defaultAutoFillToColumn; }
		}
		# endregion

		# region Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = PRICECHGSET_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList priceChgSets = null;

			if (readCount == 0)
			{
				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
				status = this._PriceChgSetAcs.SearchAll(
							out priceChgSets,
							this._enterpriseCode);

				this._totalCount = priceChgSets.Count;
			}
			else
			{
				status = this._PriceChgSetAcs.SearchSpecificationAll(
							out priceChgSets,
							out this._totalCount,
							out this._nextData,
							this._enterpriseCode,
							readCount,
							this._prevPriceChgSet);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( priceChgSets.Count > 0 ) {
						// �ŏI�̉��i�����ݒ�I�u�W�F�N�g��ޔ�����
						this._prevPriceChgSet = ((PriceChgSet)priceChgSets[priceChgSets.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PriceChgSet priceChgSet in priceChgSets)
					{
						if (this._priceChgSetTable.ContainsKey(priceChgSet.FileHeaderGuid) == false)
						{
							PriceChgSetToDataSet(priceChgSet.Clone(), index);
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
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"Search",
						TMsgDisp.OPE_READ,
						"�Ǎ��݂Ɏ��s���܂����B",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

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
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			int dummy = 0;
			ArrayList priceChgSets = null;

			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._PriceChgSetAcs.SearchSpecificationAll(
							out priceChgSets,
							out dummy,
							out this._nextData, 
							this._enterpriseCode,
							readCount,
							this._prevPriceChgSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( priceChgSets.Count > 0 ) {
						// �ŏI�̉��i�����ݒ�N���X��ޔ�����
						this._prevPriceChgSet = ((PriceChgSet)priceChgSets[priceChgSets.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PriceChgSet priceChgSet in priceChgSets)
					{
						if (this._priceChgSetTable.ContainsKey(priceChgSet.FileHeaderGuid) == false)
						{
							index = this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows.Count;
							PriceChgSetToDataSet(priceChgSet.Clone(), index);
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
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"SearchNext",
						TMsgDisp.OPE_READ,
						"�Ǎ��݂Ɏ��s���܂����B",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

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
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public int Delete()
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PriceChgSet priceChgSet = (PriceChgSet)this._priceChgSetTable[guid];

			int status = this._PriceChgSetAcs.LogicalDelete(ref priceChgSet);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //2005.07.06 �r������Ή��@�O��>>>>>START
				if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"���ɑ��[�����폜����Ă��܂�",
						status,
						MessageBoxButtons.OK);

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return status;
				}	
				else
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"Delete",
						TMsgDisp.OPE_DELETE,
						"�폜�Ɏ��s���܂����B",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return status;
				}
			}

			status = this._PriceChgSetAcs.Read(out priceChgSet, priceChgSet.EnterpriseCode);

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_STOP,
					pgId,
					pgNm,
					"Delete",
					TMsgDisp.OPE_READ,
					"�Ǎ��݂Ɏ��s���܂����B",
					status,
					obj,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				return status;
			}

			PriceChgSetToDataSet(priceChgSet.Clone(), this._dataIndex);

			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.05.06</br>
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
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE,		new GridColAppearance(MGridColDispType.DeletionDataBoth,ContentAlignment.MiddleLeft,"",Color.Red));
			//appearanceTable.Add(CODE_TITLE,			new GridColAppearance(MGridColDispType.None,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(lblName.Text,   	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(lblPartsLayer.Text,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
            // 2009/12/11 Add >>>
            appearanceTable.Add(lblBLGoodsCdUpd.Text, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2009/12/11 Add <<<
			appearanceTable.Add(lblPrice.Text,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(lblOpenPrice.Text,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(lblPriceMngCnt.Text,new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));

            // DEL 2009/01/22 �s��Ή�[9898] ��
            //appearanceTable.Add(lblPriceChgProc.Text,new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX

			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,			ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// ���i�����ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
        /// <param name="priceChgSet">���i�����ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
        private void PriceChgSetToDataSet(PriceChgSet priceChgSet, int index)
		{

			if ((index < 0) || (this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[PRICECHGSET_TABLE].NewRow();
				this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows.Count - 1;
			}

			// �_���폜���t
			if (priceChgSet.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][DELETE_DATE] = string.Empty;
			}
			else
			{
				this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][DELETE_DATE] = priceChgSet.UpdateDateTimeJpInFormal;
			}

			// ���̍X�V�敪
			this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblName.Text] = priceChgSet.NameUpdDiv;

			// �w�ʍX�V�敪
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblPartsLayer.Text] = priceChgSet.PartsLayerUpdDiv;

            // 2009/12/11 Add >>>
            // BL�R�[�h�X�V�敪
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblBLGoodsCdUpd.Text] = priceChgSet.BLGoodsCdUpdDiv;
            // 2009/12/11 Add <<<

			// ���i�X�V�敪
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblPrice.Text] = priceChgSet.PriceUpdDiv;
            
            // �I�[�v�����i�敪
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblOpenPrice.Text] = priceChgSet.OpenPriceDiv;

            // ���i�Ǘ�����
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblPriceMngCnt.Text] = priceChgSet.PriceMngCnt;

            // ���i���������敪
            // DEL 2009/01/22 �s��Ή�[9898] ��
            //this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblPriceChgProc.Text] = priceChgSet.PriceChgProcDiv;

			this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][GUID_TITLE] = priceChgSet.FileHeaderGuid;

			if (this._priceChgSetTable.ContainsKey(priceChgSet.FileHeaderGuid) == true)
			{
				this._priceChgSetTable.Remove(priceChgSet.FileHeaderGuid);
			}
			this._priceChgSetTable.Add(priceChgSet.FileHeaderGuid, priceChgSet);
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable priceChgSetTable = new DataTable(PRICECHGSET_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			priceChgSetTable.Columns.Add(DELETE_DATE, typeof(string));
            priceChgSetTable.Columns.Add(lblName.Text, typeof(int));
            priceChgSetTable.Columns.Add(lblPartsLayer.Text, typeof(int));
            // 2009/12/11 Add >>>
            priceChgSetTable.Columns.Add(lblBLGoodsCdUpd.Text, typeof(int));
            // 2009/12/11 Add <<<
            priceChgSetTable.Columns.Add(lblPrice.Text, typeof(int));
            priceChgSetTable.Columns.Add(lblOpenPrice.Text, typeof(int));
            priceChgSetTable.Columns.Add(lblPriceMngCnt.Text, typeof(int));

            // DEL 2009/01/22 �s��Ή�[9898] ��
            //priceChgSetTable.Columns.Add(lblPriceChgProc.Text, typeof(int));            
			
            priceChgSetTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(priceChgSetTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            
        }

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void ScreenClear()
		{
			
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
        /// <br>Update Note: 2008.06.03 30413 ����</br>
        /// <br>             �E�C���^�[�t�F�[�X���V���O���^�C�v�ɕύX������</br>
        /// <br>               ��ʍč\�z�������V���O���^�C�v�����ɒu������</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            const string ctPROCNM = "ScreenReconstruction";
            int status = 0;

            this._prevPriceChgSet = new PriceChgSet();

            // ���i�����ݒ�f�[�^�擾
            status = this._PriceChgSetAcs.Read(out this._prevPriceChgSet, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this._prevPriceChgSet == null)
                {
                    this._prevPriceChgSet = new PriceChgSet();
                }

                this.Mode_Label.Text = UPDATE_MODE;

                // ���i�����ݒ��ʓW�J����
                this.PriceChgSetToDataSet(this._prevPriceChgSet);
                // ��r�p�N���[���쐬
                this._priceChgSetClone = this._prevPriceChgSet.Clone();
                // ��ʏ����r�p�N���[���ɃR�s�[
                this.DispToPriceChgSet(ref this._priceChgSetClone);

                // ��ʓ��͋�����
                ScreenInputPermissionControl(true);

                // �����t�H�[�J�X���Z�b�g
                this.cmbName.Focus();
            }
            else
            {
                // ���[�h
                TMsgDisp.Show(
                    this,                                 // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                    CT_PGID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                    CT_PGNM,                              // �v���O��������
                    ctPROCNM,                             // ��������
                    TMsgDisp.OPE_READ,                    // �I�y���[�V����
                    "�ǂݍ��݂Ɏ��s���܂����B",           // �\�����郁�b�Z�[�W
                    status,                               // �X�e�[�^�X�l
                    this._PriceChgSetAcs,                  // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,                 // �\������{�^��
                    MessageBoxDefaultButton.Button1);    // �����\���{�^��

                this.Mode_Label.Text = UPDATE_MODE;

                this._prevPriceChgSet = new PriceChgSet();

                // ���i�����ݒ��ʓW�J����
                this.PriceChgSetToDataSet(this._prevPriceChgSet);
                // ��r�p�N���[���쐬
                this._priceChgSetClone = this._prevPriceChgSet.Clone();
                // ��ʏ����r�p�N���[���ɃR�s�[
                this.DispToPriceChgSet(ref this._priceChgSetClone);

                // ��ʓ��͋�����
                ScreenInputPermissionControl(true);

                // �����t�H�[�J�X���Z�b�g
                this.cmbName.Focus();
            }
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
            this.cmbName.Enabled = enabled;
            this.cmbPartsLayer.Enabled = enabled;
            // 2009/12/11 Add >>>
            this.cmbBLGoodsCdUpd.Enabled = enabled;
            // 2009/12/11 Add <<<
            this.cmbPrice.Enabled = enabled;
            this.cmbOpenPrice.Enabled = enabled;
            this.cmbPriceMngCnt.Enabled = enabled;
            this.cmbPriceChgProc.Enabled = enabled;
		}

		/// <summary>
		/// ���i�����ݒ�N���X��ʓW�J����
		/// </summary>
        /// <param name="priceChgSet">���i�����ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
        private void PriceChgSetToDataSet(PriceChgSet priceChgSet)
		{
            this.cmbName.Value = priceChgSet.NameUpdDiv;
            this.cmbPartsLayer.Value = priceChgSet.PartsLayerUpdDiv;
            // 2009/12/11 Add >>>
            this.cmbBLGoodsCdUpd.Value = priceChgSet.BLGoodsCdUpdDiv;
            // 2009/12/11 Add <<<
            this.cmbPrice.Value = priceChgSet.PriceUpdDiv;
            this.cmbOpenPrice.Value = priceChgSet.OpenPriceDiv;
            this.cmbPriceMngCnt.Value = priceChgSet.PriceMngCnt;
            this.cmbPriceChgProc.Value = priceChgSet.PriceChgProcDiv;
		}

		/// <summary>
		/// ��ʏ�񉿊i�����ݒ�N���X�i�[����
		/// </summary>
        /// <param name="priceChgSet">���i�����ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂牿�i�����ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
        private void DispToPriceChgSet(ref PriceChgSet priceChgSet)
		{
			if (priceChgSet == null)
			{
				// �V�K�̏ꍇ
				priceChgSet = new PriceChgSet();
			}

			priceChgSet.EnterpriseCode		= this._enterpriseCode;
            priceChgSet.NameUpdDiv = (int)this.cmbName.Value;
            priceChgSet.PartsLayerUpdDiv = (int)cmbPartsLayer.Value;
            // 2009/12/11 Add >>>
            priceChgSet.BLGoodsCdUpdDiv = (int)cmbBLGoodsCdUpd.Value;
            // 2009/12/11 Add <<<
            priceChgSet.PriceUpdDiv = (int)cmbPrice.Value;
            priceChgSet.OpenPriceDiv = (int)cmbOpenPrice.Value;
            priceChgSet.PriceMngCnt = (int)cmbPriceMngCnt.Value;
            priceChgSet.PriceChgProcDiv = (int)cmbPriceChgProc.Value;
		}

		/// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{			
			
			return true;
		}

		/// <summary>
		/// ���͓��t�̗L�����`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �N�������󔒂��ƃ`�F�b�N������Ȃ����߁AUI���ł��L�����`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.05.07</br>
		/// </remarks>
		private bool CheckDateEffect( Control control )
		{
			//���炩�̓��͂����邪�A�N�E���E���̂��Âꂩ�ɓ��͂��Ȃ���΁A�x���B
			if (((TDateEdit)control).LongDate != 0)
			{
				int lYear = Convert.ToInt32((((TDateEdit)control).LongDate) / 10000);
				int lMonth =  Convert.ToInt32(((((TDateEdit)control).LongDate) % 10000) / 100);
				int lDay = (((TDateEdit)control).LongDate) % 100;
      
				if ((lDay == 0) || (lMonth == 0) || (lYear == 0))
				{
       �@          return false;
				}
			}
			return true;    
		}

		/// <summary>
		/// ���i�����ݒ�ۑ�����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�o�^���s���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private bool SavePriceChgProcSet()
		{
			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					pgId,
					message,
					0,
					MessageBoxButtons.OK);

				control.Focus();
				return false;
			}

			PriceChgSet priceChgSet = null;
            // 2008.06.03 30413 ���� �V���O���^�C�v�ɕύX >>>>>>START
            // �}���`�^�C�v���̃��X�g�I���C���f�b�N�X�ł͍X�V�������s���Ȃ��ׁA
            // ��r�p�N���[�������ʏ��ȊO��ݒ肷��
            //if (this.DataIndex >= 0)
			//{
				//Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//taxrateset = ((PriceChgSet)this._taxratesetTable[guid]).Clone();
			//}
            priceChgSet = this._priceChgSetClone.Clone();
            // 2008.06.03 30413 ���� �V���O���^�C�v�ɕύX <<<<<<End
			
			DispToPriceChgSet(ref priceChgSet);
            
			int status = this._PriceChgSetAcs.Write(ref priceChgSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"���̉��i�����ݒ�R�[�h�͊��Ɏg�p����Ă��܂��B",
						0,
						MessageBoxButtons.OK);
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{

					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"���ɑ��[�����X�V����Ă��܂�",
						status,
						MessageBoxButtons.OK);

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
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
                        "SavePriceChgProcSet",
						TMsgDisp.OPE_UPDATE,
						"�o�^�Ɏ��s���܂����B",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
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

			PriceChgSetToDataSet(priceChgSet, this.DataIndex);

			return true;
		}
		# endregion

		#region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFSSH09460UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void PMKHN09221UA_Load(object sender, System.EventArgs e)
		{
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFSSH09460UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void PMKHN09221UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
		/// Control.VisibleChanged �C�x���g(SFSSH09460UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void PMKHN09221UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				return;
			}

			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			// �V�K���[�h�ȊO�̏ꍇ
			//if(this._dataIndex >= 0)
			//{
			//	// �t���[���őI������Ă��郌�R�[�h��GUID���擾
			//	Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			//	// ��L�̃��R�[�h���N���X�ɃZ�b�g
			//	PriceChgSet taxRateSet = (PriceChgSet)this._taxratesetTable[guid];
			//	// ���݂̉�ʂ̃L�[���ƃN���X�̃L�[�����r
			//	// ������������ȉ��̏������L�����Z������
			//	if ( this.TaxRateProperNounNm_tEdit.Text.Trim() == taxRateSet.TaxRateProperNounNm.Trim() )
			//	{
			//		return;
			//	}
			//		// ���C���t���[���̑I�����ύX���ꂽ�ꍇ
			//	else
			//	{
			//		// �Ǎ��݂��s���ׂɃt���O��������
			//		this._minFlg = false;
			//	}
			//}

			//// �t���O��true��������ȉ��̏������L�����Z������
			//if (this._minFlg == false)
			//{
			//	this._minFlg = true;
			//}
			//else
			//{
			//	return;
			//}
			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            // ���i�����ݒ�o�^����
			if (SavePriceChgProcSet() == false)
			{
				return;
			}
			
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// �o�^���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				this.DataIndex = -1;

				ScreenClear();
				this.cmbName.Focus();
				// �N���[�����ēx�擾����
				PriceChgSet newPriceChgSet = new PriceChgSet();
				//�N���[���쐬
				this._priceChgSetClone = newPriceChgSet.Clone(); 
				DispToPriceChgSet( ref this._priceChgSetClone);

			}
			else
			{
				this.DialogResult = DialogResult.OK;

				if (CanClose == true)
				{
					this.Close();
				}
				else
				{
					this.Hide();
				}

				this._indexBuf = -2;
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            DialogResult res = DialogResult.Cancel;

			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE)
			{
				//�ۑ��m�F
				PriceChgSet comparePriceChgSet = new PriceChgSet();
				comparePriceChgSet = this._priceChgSetClone.Clone();  

				//���݂̉�ʏ����擾����
				DispToPriceChgSet( ref comparePriceChgSet);
				//�ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._priceChgSetClone.Equals(comparePriceChgSet)))	
				{
                    res = TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        pgId,
                        "",
                        0,
                        MessageBoxButtons.YesNoCancel);
					switch(res)
					{
						case DialogResult.Yes:
						{
							// ���i�����ݒ�o�^����
							if (SavePriceChgProcSet() ==false)
							{
								return;
							}

							break;
						}
						case DialogResult.No:
						{
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
			
			if (UnDisplaying != null)
			{
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(res);
				UnDisplaying(this, me);
			}

            this.DialogResult = res;
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
		/// <br>Note�@�@�@  : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult result = TMsgDisp.Show(this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				pgId,
				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
				0,
				MessageBoxButtons.OKCancel,
				MessageBoxDefaultButton.Button2);

			if (result == DialogResult.OK)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
				PriceChgSet priceChgSet = (PriceChgSet)this._priceChgSetTable[guid];

				int status = this._PriceChgSetAcs.Delete(priceChgSet);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[this.DataIndex].Delete();
						this._priceChgSetTable.Remove(priceChgSet.FileHeaderGuid);

						break;
					}
					default:
					{
						TMsgDisp.Show(this,
							emErrorLevel.ERR_LEVEL_STOP,
							pgId,
							pgNm,
							"Delete_Button_Click",
							TMsgDisp.OPE_DELETE,
							"�폜�Ɏ��s���܂����B",
							status,
							obj,
							MessageBoxButtons.OK,
							MessageBoxDefaultButton.Button1);
						return;
					}
				}
			}
			else
			{
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
		/// <br>Note�@�@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PriceChgSet priceChgSet = (PriceChgSet)_priceChgSetTable[guid];

			int status = this._PriceChgSetAcs.Revival(ref priceChgSet);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"���Ƀf�[�^�����S�폜����Ă��܂��B" ,
						status,
						MessageBoxButtons.OK);

					break;
				}
				default:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"Delete",
						TMsgDisp.OPE_UPDATE,
						"�����Ɏ��s���܂����B",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			PriceChgSetToDataSet(priceChgSet, this.DataIndex);

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
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}
		# endregion
		

        #region IMasterMaintenanceSingleType �����o

        /// <summary>
        /// ��ʃN���[�Y�v���p�e�B
        /// </summary>
        /// <remarks>
        /// ��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B
        /// false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B
        /// </remarks>
        bool IMasterMaintenanceSingleType.CanClose
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

        /// <summary>
        /// ����v���p�e�B
        /// </summary>
        /// <remarks>
        /// ����\���ǂ����̐ݒ���擾���܂��B�ifalse�Œ�j
        /// </remarks>
        bool IMasterMaintenanceSingleType.CanPrint
        {
            get { 
                return this._canPrint;
            }
        }
        
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.03</br>
        /// </remarks>
        int IMasterMaintenanceSingleType.Print()
        {
            // ����A�Z���u�������[�h����i�������j
            return 0;
        }

        /// <summary>
        /// HTML�R�[�h�擾����
        /// </summary>
        /// <returns>HTML�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : HTML�R�[�h�̎擾���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.03</br>
        /// </remarks>
        String IMasterMaintenanceSingleType.GetHtmlCode()
        {
            const string ctPROCNM = "GetHtmlCode";
            string outCode = "";

            // tHtmlGenerate���i�̈����𐶐�����
            List<string> titleList = new List<string>();
            List<string> valueList = new List<string>();
            titleList.Add(HTML_HEADER_TITLE);							// �u�ݒ荀�ځv
            valueList.Add(HTML_HEADER_VALUE);							// �u�ݒ�l�v

            // �ݒ荀�ڃ^�C�g���ݒ�
            titleList.Add(lblName.Text);             // ���̍X�V�敪
            titleList.Add(lblPartsLayer.Text);    // �w�ʍX�V�敪
            // 2009/12/11 Add >>>
            titleList.Add(lblBLGoodsCdUpd.Text);    // BL�R�[�h�X�V�敪
            // 2009/12/11 Add <<<
            titleList.Add(lblPrice.Text);    // ���i�X�V�敪
            titleList.Add(lblOpenPrice.Text);     // �I�[�v�����i�敪
            titleList.Add(lblPriceMngCnt.Text);      // ���i�Ǘ�����

            // DEL 2009/01/22 �s��Ή�[9898] ��
            //titleList.Add(lblPriceChgProc.Text);       // ���i���������敪

            string[] kubun = new string[] { "����","���Ȃ�"};
            //string[] kubun2 = new string[] { "���i�����p��", "0�ōX�V" };  // DEL by gezh 2011/11/29 redmine#8191
            //string[] kubun2 = new string[] { "���i�����p��", "0�ōX�V" };    // ADD by gezh 2011/11/29 redmine#8191  //DEL BY ������ on 2011/12/05 for redmine#8191
            string[] kubun2 = new string[] { "���i�����p��", "0�ōX�V����" };  //ADD BY ������ 2011/12/05 redmine#8191
            string[] kubun3 = new string[] { "�V���N�Ɠ���", "�蓮����" };
            string[] kubun4 = new string[] { "����i�񋟖��ݒ蕪�͍X�V���j", "���Ȃ�", "����i�������X�V�j" }; // ADD 2012/06/26 ���� �w�ʍX�V�s��Ή�
            // ���i�����ݒ�f�[�^�擾
            int status = 0;
            status = this._PriceChgSetAcs.Read(out this._prevPriceChgSet, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // ���i�����ݒ�擾�f�[�^�ݒ�
                        if (this._prevPriceChgSet != null)
                        {
                            valueList.Add(kubun[this._prevPriceChgSet.NameUpdDiv]);
                            //valueList.Add(kubun[this._prevPriceChgSet.PartsLayerUpdDiv]); // DEL 2012/06/26 ���� �w�ʍX�V�s��Ή�
                            valueList.Add(kubun4[this._prevPriceChgSet.PartsLayerUpdDiv]); // ADD 2012/06/26 ���� �w�ʍX�V�s��Ή�
                            // 2009/12/11 Add >>>
                            //valueList.Add(kubun[this._prevPriceChgSet.BLGoodsCdUpdDiv]); // DEL 2013/01/31 T.Miyamoto
                            valueList.Add(kubun4[this._prevPriceChgSet.BLGoodsCdUpdDiv]);  // ADD 2013/01/31 T.Miyamoto
                            // 2009/12/11 Add <<<
                            valueList.Add(kubun[this._prevPriceChgSet.PriceUpdDiv]);
                            valueList.Add(kubun2[this._prevPriceChgSet.OpenPriceDiv]);
                            valueList.Add(this._prevPriceChgSet.PriceMngCnt.ToString());
                            valueList.Add(kubun3[this._prevPriceChgSet.PriceChgProcDiv]);
                        }
                        else
                        {
                            // ���ݒ�
                            for (int ix = 0; ix < titleList.Count; ix++)
                            {
                                valueList.Add(HTML_UNREGISTER);
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        // ���ݒ�
                        for (int ix = 0; ix < titleList.Count; ix++)
                        {
                            valueList.Add(HTML_UNREGISTER);
                        }
                        break;
                    }
                default:
                    {
                        // ���[�h
                        TMsgDisp.Show(
                            this,                                 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                            CT_PGID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM,                              // �v���O��������
                            ctPROCNM,                             // ��������
                            TMsgDisp.OPE_READ,                    // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",           // �\�����郁�b�Z�[�W
                            status,                               // �X�e�[�^�X�l
                            this._PriceChgSetAcs,                  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                 // �\������{�^��
                            MessageBoxDefaultButton.Button1);    // �����\���{�^��

                        // ���ݒ�
                        for (int ix = 0; ix < titleList.Count; ix++)
                        {
                            valueList.Add(HTML_UNREGISTER);
                        }
                        break;
                    }
            }

            this.tHtmlGenerate1.Coltypes = new int[2];
            this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
            this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

            // �z��ɃR�s�[
            string[,] array = new string[titleList.Count, 2];
            for (int ix = 0; ix < array.GetLength(0); ix++)
            {
                array[ix, 0] = titleList[ix];
                array[ix, 1] = valueList[ix];
            }

            this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);

            return outCode;
        }        
        #endregion
    }
}