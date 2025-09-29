//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ŗ��ݒ�
// �v���O�����T�v   : �ŗ��ݒ�}�X�^�̏C�����s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2008/06/03  �C�����e : Partsman�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �C �� ��  2008/11/06  �C�����e : ���ږ��̕ύX�@�u�ŗ��ŗL���́v���u����Ŏ�ށv
//                                :               �u�\���^������́v���u�\���^������v
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/06/19  �C�����e : MANTIS�y13568�z���ږ��̕ύX�@�u�\���^������v���u�\�����v
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : �A����
// �C �� ��  2014/02/18  �C�����e : Redmine#42120 �ŗ��ݒ�}�X�^�Ƀ`�F�b�N��ǉ�����
//----------------------------------------------------------------------------//

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
	/// �ŗ����̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ŗ��ݒ���s���܂��B
	///					 IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer : 21041�@�����@��</br>
	/// <br>Date       : 2004.04.01</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.27 22025 �c�� �L</br>
	/// <br>					�E�t���[���̍ŏ����Ή�</br>
	/// <br>Update Note: 2005.06.09 22025 �c�� �L</br>
	/// <br>					�E�t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX</br>
	/// <br>Update Note: 2005.06.10 96138 ���� ����</br>
	/// <br>					�E�^�C�g�����u�ŗ��ݒ�v�ƕύX�B�i�v���p�e�B�ɂĕύX�B�j</br>
	/// <br>Update Note: 2005.06.13 96138 ���� ����</br>
	/// <br>					�EUI��ʐ��l���ڂ̉E�l�ߑΉ��B�i�v���p�e�B�ɂĕύX�B�j</br>
	/// <br>Update Note: 2005.06.18 96138 ����  ����</br>
	/// <br>           : �E�g�p�s���ڂ̕����F�A�w�i�F�̐ݒ��ύX�B�v���p�e�B�ɂĕύX�B</br>
	/// <br>           : �EFontColorDisabled = Black�ABackColorDisabled = Control</br>
	/// <br>Update Note: 2005.06.20 96138 ����  ����</br>
	/// <br>           : �E�ŗ����ڕ\���̍œK���B</br>
	/// <br>Update Note: 2005.06.21 96138 ����  ����</br>
	/// <br>           : �E���ݒ莞�A�u���ݒ�v�ł͂Ȃ��󔒂ŕ\������B</br>
	/// <br>Update Note: 2005.06.21 96138 ����  ����</br>
	/// <br>           : �@IME���[�h Off��Disable�֕ύX�B�v���p�e�B�ɂĕύX�B</br>	
	/// <br>Update Note: 2005.06.23 96138 ����  ����</br>
	/// <br>           : �E�R���{�{�b�N�X��MaxDropDownItems��18�ɕύX�B�v���p�e�B�ɂĕύX�B</br>	
	/// <br>Update Note: 2005.06.24 96138 ����  ����</br>
	/// <br>           : �ETNedit�f�t�H���g�ݒ�̍œK���B�v���p�e�B�ɂĕύX�B</br>	
	/// <br>Update Note: 2005.06.30 21020 ����  �T��</br>
	/// <br>           : �ETDateEdit��ImeMode�v���p�e�B��Disable�ɕύX</br>	
	/// <br>Update Note: 2005.07.02 22035 �O���@�O��</br>
	/// <br>           : �E�t���[���̍ŏ����Ή�����</br>
	/// <br>Update Note: 2005.07.06 22035 �O���@�O��</br>
	/// <br>           : �r������Ή�</br>
	/// <br>Update Note: 2005.07.12 22035 �O���@�O��</br>
	/// <br>           : �r������R�����g�ύX</br>
	/// <br>Update Note: 2005.09.09 23003 enokida</br>
	/// <br>           : ���O�C�����擾�Ή�</br>
	/// <br>Update Note: 2005.09.20 23003 enokida</br>
	/// <br>           : Message���i�Ή�</br>
	/// <br>Update Note: 2005.10.19 22021 �J���@�͍K</br>
	/// <br>		   : �EUI�q���Hide����Owner.Activate�����ǉ�</br>
	/// <br></br>
	/// <br>Update Note	: 2007.02.06 18322 T.Kimura MA.NS�p�ɕύX</br>
	/// <br>			:                           �E��ʃX�L���ύX�Ή�</br>
	/// <br></br>
	/// <br>Update Note	: 2007.08.01 18322 T.Kimura MK.NS�p�ɘa��琼��ɓ��t��ύX</br>
    /// <br>Update Note: 2007.08.16 980035 ���� ��`</br>
    /// <br>			 �E�[�������敪���폜���ď���œ]�ŕ�����ǉ�</br>
    /// <br>Update Note: 2008.03.06 980035 ���� ��`</br>
    /// <br>			 �EDC.NS�Ή��i���t�̏d���`�F�b�N�ǉ��j</br>
    /// <br>Update Note: 2008.06.03 30413 ����</br>
    /// <br>             �EPM.NS�Ή� (�C���^�[�t�F�[�X���V���O���^�C�v�ɕύX)</br>
    /// <br>Update Note: 2008.11.06 30452 ��� �r��</br>
    /// <br>             �E���ږ��̕ύX</br>
    /// <br>             �u�ŗ��ŗL���́v���u����Ŏ�ށv</br>
    /// <br>             �u�\���^������́v���u�\���^������v</br>
    /// <br>Update Note: 2014/02/18 �A����</br>
    /// <br>           : Redmine#42120 �ŗ��ݒ�}�X�^�Ƀ`�F�b�N��ǉ�����</br>
    /// </remarks>
	public class SFUKK09000UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
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
		private Infragistics.Win.Misc.UltraLabel Name_Title_Label;
		private Infragistics.Win.Misc.UltraLabel AgencyCodeCode_Title_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TLine tLine3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Broadleaf.Library.Windows.Forms.TLine tLine4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Broadleaf.Library.Windows.Forms.TEdit TaxRateName_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TaxRateProperNounNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit TaxRate_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit TaxRate2_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit TaxRate3_tNedit;
		private Broadleaf.Library.Windows.Forms.TComboEditor ConsTaxLayMethod_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel ConsTaxLayMethod_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRateDate1_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRate1_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRate2_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRateDate2_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRateDate3_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRate3_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateEndDate3_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateStartDate3_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateEndDate2_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateStartDate2_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateEndDate_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateStartDate_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private THtmlGenerate tHtmlGenerate1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �ŗ������̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ŗ������̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public SFUKK09000UA()
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

			// 2005.09.09 enokida ADD ���O�C�����擾�Ή� >>>>>>>>>>>>>>>>> START
			//�@��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.09 enokida ADD ���O�C�����擾�Ή� <<<<<<<<<<<<<<<<< END


			// �ϐ�������
			this._dataIndex = -1;
			this._taxratesetAcs = new TaxRateSetAcs();
			this._prevTaxRateSet = null;
			this._nextData = false;
			this._totalCount = 0;
			this._taxratesetTable = new Hashtable();
            
			//2005.07.02 �t���[���̍ŏ����Ή����ǁ@�O��>>>>>START
			this._indexBuf = -2;
			//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//// �ŏ�������p�t���O
			//this._minFlg = false;
			//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			//2005.07.02 �t���[���̍ŏ����Ή�����  �O��<<<<<<END
		
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
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09000UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.TaxRateName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Name_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AgencyCodeCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.TaxRateDate1_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRateProperNounNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TaxRate1_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRate_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine3 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRate2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TaxRate2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRateDate2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tLine4 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRateDate3_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRate3_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRate3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ConsTaxLayMethod_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxLayMethod_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRateEndDate3_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateStartDate3_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateEndDate2_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateStartDate2_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateEndDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateStartDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateProperNounNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate3_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxLayMethod_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 478);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(677, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
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
            this.Mode_Label.Location = new System.Drawing.Point(545, 5);
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
            this.Ok_Button.Location = new System.Drawing.Point(415, 425);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(540, 425);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 15;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // TaxRateName_tEdit
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TaxRateName_tEdit.ActiveAppearance = appearance32;
            this.TaxRateName_tEdit.AlwaysInEditMode = true;
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance33.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            this.TaxRateName_tEdit.Appearance = appearance33;
            this.TaxRateName_tEdit.AutoSelect = true;
            this.TaxRateName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.TaxRateName_tEdit.DataText = "��ʏ����";
            this.TaxRateName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TaxRateName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TaxRateName_tEdit.Location = new System.Drawing.Point(145, 95);
            this.TaxRateName_tEdit.MaxLength = 24;
            this.TaxRateName_tEdit.Name = "TaxRateName_tEdit";
            this.TaxRateName_tEdit.Size = new System.Drawing.Size(401, 24);
            this.TaxRateName_tEdit.TabIndex = 1;
            this.TaxRateName_tEdit.Text = "��ʏ����";
            // 
            // Name_Title_Label
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.Name_Title_Label.Appearance = appearance39;
            this.Name_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Name_Title_Label.Location = new System.Drawing.Point(10, 95);
            this.Name_Title_Label.Name = "Name_Title_Label";
            this.Name_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.Name_Title_Label.TabIndex = 92;
            this.Name_Title_Label.Text = "�\����";
            // 
            // AgencyCodeCode_Title_Label
            // 
            appearance40.TextVAlignAsString = "Middle";
            this.AgencyCodeCode_Title_Label.Appearance = appearance40;
            this.AgencyCodeCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.AgencyCodeCode_Title_Label.Location = new System.Drawing.Point(10, 40);
            this.AgencyCodeCode_Title_Label.Name = "AgencyCodeCode_Title_Label";
            this.AgencyCodeCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.AgencyCodeCode_Title_Label.TabIndex = 91;
            this.AgencyCodeCode_Title_Label.Text = "����Ŏ��";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(290, 425);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 12;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Visible = false;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(415, 425);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 13;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Visible = false;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // TaxRateDate1_Label
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.TaxRateDate1_Label.Appearance = appearance38;
            this.TaxRateDate1_Label.Location = new System.Drawing.Point(10, 185);
            this.TaxRateDate1_Label.Name = "TaxRateDate1_Label";
            this.TaxRateDate1_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRateDate1_Label.TabIndex = 93;
            this.TaxRateDate1_Label.Text = "�ŗ�������P";
            // 
            // TaxRateProperNounNm_tEdit
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TaxRateProperNounNm_tEdit.ActiveAppearance = appearance30;
            appearance31.BackColor = System.Drawing.Color.Transparent;
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            this.TaxRateProperNounNm_tEdit.Appearance = appearance31;
            this.TaxRateProperNounNm_tEdit.AutoSelect = true;
            this.TaxRateProperNounNm_tEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateProperNounNm_tEdit.DataText = "��ʏ����";
            this.TaxRateProperNounNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateProperNounNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TaxRateProperNounNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TaxRateProperNounNm_tEdit.Location = new System.Drawing.Point(145, 40);
            this.TaxRateProperNounNm_tEdit.MaxLength = 24;
            this.TaxRateProperNounNm_tEdit.Name = "TaxRateProperNounNm_tEdit";
            this.TaxRateProperNounNm_tEdit.ReadOnly = true;
            this.TaxRateProperNounNm_tEdit.Size = new System.Drawing.Size(401, 24);
            this.TaxRateProperNounNm_tEdit.TabIndex = 0;
            this.TaxRateProperNounNm_tEdit.Text = "��ʏ����";
            // 
            // TaxRate1_Label
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.TaxRate1_Label.Appearance = appearance37;
            this.TaxRate1_Label.Location = new System.Drawing.Point(10, 220);
            this.TaxRate1_Label.Name = "TaxRate1_Label";
            this.TaxRate1_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRate1_Label.TabIndex = 96;
            this.TaxRate1_Label.Text = "�ŗ��P";
            // 
            // TaxRate_tNedit
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Right";
            this.TaxRate_tNedit.ActiveAppearance = appearance28;
            appearance29.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            this.TaxRate_tNedit.Appearance = appearance29;
            this.TaxRate_tNedit.AutoSelect = true;
            this.TaxRate_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxRate_tNedit.DataText = "";
            this.TaxRate_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRate_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TaxRate_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxRate_tNedit.Location = new System.Drawing.Point(145, 220);
            this.TaxRate_tNedit.MaxLength = 5;
            this.TaxRate_tNedit.Name = "TaxRate_tNedit";
            this.TaxRate_tNedit.NullText = "0.0";
            this.TaxRate_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxRate_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaxRate_tNedit.Size = new System.Drawing.Size(51, 24);
            this.TaxRate_tNedit.TabIndex = 5;
            this.TaxRate_tNedit.Leave += new System.EventHandler(this.TaxRate_tNedit_Leave);
            // 
            // ultraLabel2
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance36;
            this.ultraLabel2.Location = new System.Drawing.Point(335, 185);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel2.TabIndex = 99;
            this.ultraLabel2.Text = "�`";
            // 
            // tLine3
            // 
            this.tLine3.BackColor = System.Drawing.Color.Transparent;
            this.tLine3.LineStyle = Broadleaf.Library.Windows.Forms.emLineStyle.lsDash;
            this.tLine3.Location = new System.Drawing.Point(10, 255);
            this.tLine3.Name = "tLine3";
            this.tLine3.Size = new System.Drawing.Size(645, 5);
            this.tLine3.TabIndex = 101;
            this.tLine3.Text = "tLine3";
            // 
            // ultraLabel3
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance42;
            this.ultraLabel3.Location = new System.Drawing.Point(335, 270);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel3.TabIndex = 105;
            this.ultraLabel3.Text = "�`";
            // 
            // TaxRate2_tNedit
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Right";
            this.TaxRate2_tNedit.ActiveAppearance = appearance34;
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Right";
            this.TaxRate2_tNedit.Appearance = appearance35;
            this.TaxRate2_tNedit.AutoSelect = true;
            this.TaxRate2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxRate2_tNedit.DataText = "";
            this.TaxRate2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRate2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TaxRate2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxRate2_tNedit.Location = new System.Drawing.Point(145, 305);
            this.TaxRate2_tNedit.MaxLength = 5;
            this.TaxRate2_tNedit.Name = "TaxRate2_tNedit";
            this.TaxRate2_tNedit.NullText = "0.0";
            this.TaxRate2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxRate2_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaxRate2_tNedit.Size = new System.Drawing.Size(51, 24);
            this.TaxRate2_tNedit.TabIndex = 8;
            this.TaxRate2_tNedit.Leave += new System.EventHandler(this.TaxRate2_tNedit_Leave);
            // 
            // TaxRate2_Label
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.TaxRate2_Label.Appearance = appearance44;
            this.TaxRate2_Label.Location = new System.Drawing.Point(10, 305);
            this.TaxRate2_Label.Name = "TaxRate2_Label";
            this.TaxRate2_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRate2_Label.TabIndex = 102;
            this.TaxRate2_Label.Text = "�ŗ��Q";
            // 
            // TaxRateDate2_Label
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.TaxRateDate2_Label.Appearance = appearance43;
            this.TaxRateDate2_Label.Location = new System.Drawing.Point(10, 270);
            this.TaxRateDate2_Label.Name = "TaxRateDate2_Label";
            this.TaxRateDate2_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRateDate2_Label.TabIndex = 101;
            this.TaxRateDate2_Label.Text = "�ŗ�������Q";
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.LineStyle = Broadleaf.Library.Windows.Forms.emLineStyle.lsDash;
            this.tLine4.Location = new System.Drawing.Point(10, 340);
            this.tLine4.Name = "tLine4";
            this.tLine4.Size = new System.Drawing.Size(645, 5);
            this.tLine4.TabIndex = 107;
            this.tLine4.Text = "tLine4";
            // 
            // ultraLabel6
            // 
            appearance45.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance45;
            this.ultraLabel6.Location = new System.Drawing.Point(335, 350);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel6.TabIndex = 111;
            this.ultraLabel6.Text = "�`";
            // 
            // TaxRateDate3_Label
            // 
            appearance46.TextVAlignAsString = "Middle";
            this.TaxRateDate3_Label.Appearance = appearance46;
            this.TaxRateDate3_Label.Location = new System.Drawing.Point(10, 355);
            this.TaxRateDate3_Label.Name = "TaxRateDate3_Label";
            this.TaxRateDate3_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRateDate3_Label.TabIndex = 107;
            this.TaxRateDate3_Label.Text = "�ŗ�������R";
            // 
            // TaxRate3_Label
            // 
            appearance47.TextVAlignAsString = "Middle";
            this.TaxRate3_Label.Appearance = appearance47;
            this.TaxRate3_Label.Location = new System.Drawing.Point(10, 390);
            this.TaxRate3_Label.Name = "TaxRate3_Label";
            this.TaxRate3_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRate3_Label.TabIndex = 108;
            this.TaxRate3_Label.Text = "�ŗ��R";
            // 
            // TaxRate3_tNedit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Right";
            this.TaxRate3_tNedit.ActiveAppearance = appearance26;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Right";
            this.TaxRate3_tNedit.Appearance = appearance27;
            this.TaxRate3_tNedit.AutoSelect = true;
            this.TaxRate3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxRate3_tNedit.DataText = "";
            this.TaxRate3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRate3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TaxRate3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxRate3_tNedit.Location = new System.Drawing.Point(145, 390);
            this.TaxRate3_tNedit.MaxLength = 5;
            this.TaxRate3_tNedit.Name = "TaxRate3_tNedit";
            this.TaxRate3_tNedit.NullText = "0.0";
            this.TaxRate3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxRate3_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaxRate3_tNedit.Size = new System.Drawing.Size(51, 24);
            this.TaxRate3_tNedit.TabIndex = 11;
            this.TaxRate3_tNedit.Leave += new System.EventHandler(this.TaxRate3_tNedit_Leave);
            // 
            // ConsTaxLayMethod_Label
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ConsTaxLayMethod_Label.Appearance = appearance25;
            this.ConsTaxLayMethod_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ConsTaxLayMethod_Label.Location = new System.Drawing.Point(10, 132);
            this.ConsTaxLayMethod_Label.Name = "ConsTaxLayMethod_Label";
            this.ConsTaxLayMethod_Label.Size = new System.Drawing.Size(130, 24);
            this.ConsTaxLayMethod_Label.TabIndex = 116;
            this.ConsTaxLayMethod_Label.Text = "����œ]�ŕ���";
            // 
            // ConsTaxLayMethod_tComboEditor
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxLayMethod_tComboEditor.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.ConsTaxLayMethod_tComboEditor.Appearance = appearance23;
            this.ConsTaxLayMethod_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ConsTaxLayMethod_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ConsTaxLayMethod_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxLayMethod_tComboEditor.ItemAppearance = appearance24;
            this.ConsTaxLayMethod_tComboEditor.Location = new System.Drawing.Point(145, 135);
            this.ConsTaxLayMethod_tComboEditor.MaxDropDownItems = 18;
            this.ConsTaxLayMethod_tComboEditor.Name = "ConsTaxLayMethod_tComboEditor";
            this.ConsTaxLayMethod_tComboEditor.Size = new System.Drawing.Size(150, 24);
            this.ConsTaxLayMethod_tComboEditor.TabIndex = 2;
            // 
            // ultraLabel1
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance21;
            this.ultraLabel1.Location = new System.Drawing.Point(202, 221);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel1.TabIndex = 117;
            this.ultraLabel1.Text = "��";
            // 
            // ultraLabel4
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance20;
            this.ultraLabel4.Location = new System.Drawing.Point(202, 306);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel4.TabIndex = 118;
            this.ultraLabel4.Text = "��";
            // 
            // ultraLabel5
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance19;
            this.ultraLabel5.Location = new System.Drawing.Point(202, 391);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(24, 21);
            this.ultraLabel5.TabIndex = 119;
            this.ultraLabel5.Text = "��";
            // 
            // TaxRateEndDate3_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.TextHAlignAsString = "Right";
            this.TaxRateEndDate3_tDateEdit.ActiveEditAppearance = appearance1;
            this.TaxRateEndDate3_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateEndDate3_tDateEdit.CalendarDisp = true;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.TaxRateEndDate3_tDateEdit.EditAppearance = appearance2;
            this.TaxRateEndDate3_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateEndDate3_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateEndDate3_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.TaxRateEndDate3_tDateEdit.LabelAppearance = appearance3;
            this.TaxRateEndDate3_tDateEdit.Location = new System.Drawing.Point(370, 350);
            this.TaxRateEndDate3_tDateEdit.Name = "TaxRateEndDate3_tDateEdit";
            this.TaxRateEndDate3_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateEndDate3_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateEndDate3_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateEndDate3_tDateEdit.TabIndex = 10;
            this.TaxRateEndDate3_tDateEdit.TabStop = true;
            // 
            // TaxRateStartDate3_tDateEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.TaxRateStartDate3_tDateEdit.ActiveEditAppearance = appearance4;
            this.TaxRateStartDate3_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateStartDate3_tDateEdit.CalendarDisp = true;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.TaxRateStartDate3_tDateEdit.EditAppearance = appearance5;
            this.TaxRateStartDate3_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateStartDate3_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateStartDate3_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.TaxRateStartDate3_tDateEdit.LabelAppearance = appearance6;
            this.TaxRateStartDate3_tDateEdit.Location = new System.Drawing.Point(145, 350);
            this.TaxRateStartDate3_tDateEdit.Name = "TaxRateStartDate3_tDateEdit";
            this.TaxRateStartDate3_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateStartDate3_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateStartDate3_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateStartDate3_tDateEdit.TabIndex = 9;
            this.TaxRateStartDate3_tDateEdit.TabStop = true;
            // 
            // TaxRateEndDate2_tDateEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.TextHAlignAsString = "Right";
            this.TaxRateEndDate2_tDateEdit.ActiveEditAppearance = appearance7;
            this.TaxRateEndDate2_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateEndDate2_tDateEdit.CalendarDisp = true;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.TaxRateEndDate2_tDateEdit.EditAppearance = appearance8;
            this.TaxRateEndDate2_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateEndDate2_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateEndDate2_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.TaxRateEndDate2_tDateEdit.LabelAppearance = appearance9;
            this.TaxRateEndDate2_tDateEdit.Location = new System.Drawing.Point(370, 270);
            this.TaxRateEndDate2_tDateEdit.Name = "TaxRateEndDate2_tDateEdit";
            this.TaxRateEndDate2_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateEndDate2_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateEndDate2_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateEndDate2_tDateEdit.TabIndex = 7;
            this.TaxRateEndDate2_tDateEdit.TabStop = true;
            // 
            // TaxRateStartDate2_tDateEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Right";
            this.TaxRateStartDate2_tDateEdit.ActiveEditAppearance = appearance10;
            this.TaxRateStartDate2_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateStartDate2_tDateEdit.CalendarDisp = true;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.TaxRateStartDate2_tDateEdit.EditAppearance = appearance11;
            this.TaxRateStartDate2_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateStartDate2_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateStartDate2_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.TaxRateStartDate2_tDateEdit.LabelAppearance = appearance12;
            this.TaxRateStartDate2_tDateEdit.Location = new System.Drawing.Point(145, 270);
            this.TaxRateStartDate2_tDateEdit.Name = "TaxRateStartDate2_tDateEdit";
            this.TaxRateStartDate2_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateStartDate2_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateStartDate2_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateStartDate2_tDateEdit.TabIndex = 6;
            this.TaxRateStartDate2_tDateEdit.TabStop = true;
            // 
            // TaxRateEndDate_tDateEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.TaxRateEndDate_tDateEdit.ActiveEditAppearance = appearance13;
            this.TaxRateEndDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateEndDate_tDateEdit.CalendarDisp = true;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.TaxRateEndDate_tDateEdit.EditAppearance = appearance14;
            this.TaxRateEndDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateEndDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateEndDate_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.TaxRateEndDate_tDateEdit.LabelAppearance = appearance15;
            this.TaxRateEndDate_tDateEdit.Location = new System.Drawing.Point(370, 185);
            this.TaxRateEndDate_tDateEdit.Name = "TaxRateEndDate_tDateEdit";
            this.TaxRateEndDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateEndDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateEndDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateEndDate_tDateEdit.TabIndex = 4;
            this.TaxRateEndDate_tDateEdit.TabStop = true;
            // 
            // TaxRateStartDate_tDateEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.TextHAlignAsString = "Right";
            this.TaxRateStartDate_tDateEdit.ActiveEditAppearance = appearance16;
            this.TaxRateStartDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateStartDate_tDateEdit.CalendarDisp = true;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.TaxRateStartDate_tDateEdit.EditAppearance = appearance17;
            this.TaxRateStartDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateStartDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateStartDate_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance18.TextHAlignAsString = "Left";
            appearance18.TextVAlignAsString = "Middle";
            this.TaxRateStartDate_tDateEdit.LabelAppearance = appearance18;
            this.TaxRateStartDate_tDateEdit.Location = new System.Drawing.Point(145, 185);
            this.TaxRateStartDate_tDateEdit.Name = "TaxRateStartDate_tDateEdit";
            this.TaxRateStartDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateStartDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateStartDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateStartDate_tDateEdit.TabIndex = 3;
            this.TaxRateStartDate_tDateEdit.TabStop = true;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(10, 75);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(650, 3);
            this.ultraLabel17.TabIndex = 120;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel7.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel7.Location = new System.Drawing.Point(10, 170);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(650, 3);
            this.ultraLabel7.TabIndex = 121;
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
            // SFUKK09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(677, 501);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.TaxRateEndDate3_tDateEdit);
            this.Controls.Add(this.TaxRateStartDate3_tDateEdit);
            this.Controls.Add(this.TaxRateEndDate2_tDateEdit);
            this.Controls.Add(this.TaxRateStartDate2_tDateEdit);
            this.Controls.Add(this.TaxRateEndDate_tDateEdit);
            this.Controls.Add(this.TaxRateStartDate_tDateEdit);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ConsTaxLayMethod_tComboEditor);
            this.Controls.Add(this.ConsTaxLayMethod_Label);
            this.Controls.Add(this.TaxRate3_tNedit);
            this.Controls.Add(this.TaxRate_tNedit);
            this.Controls.Add(this.TaxRateProperNounNm_tEdit);
            this.Controls.Add(this.TaxRateName_tEdit);
            this.Controls.Add(this.TaxRate2_tNedit);
            this.Controls.Add(this.tLine4);
            this.Controls.Add(this.tLine3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.TaxRate1_Label);
            this.Controls.Add(this.TaxRateDate1_Label);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Name_Title_Label);
            this.Controls.Add(this.AgencyCodeCode_Title_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.TaxRateDate2_Label);
            this.Controls.Add(this.TaxRate2_Label);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.TaxRateDate3_Label);
            this.Controls.Add(this.TaxRate3_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09000UA";
            this.Text = "�ŗ��ݒ�";
            this.Load += new System.EventHandler(this.SFUKK09000UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09000UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09000UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateProperNounNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate3_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxLayMethod_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
        // 2008.06.03 30413 ���� �V���O���^�C�v�ɕύX >>>>>>START
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
        // 2008.06.03 30413 ���� �V���O���^�C�v�ɕύX <<<<<<END
		# endregion
				
		#region Private Members
		private TaxRateSetAcs _taxratesetAcs;
		private TaxRateSet _prevTaxRateSet;
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _taxratesetTable;

        // �� 20070206 18322 a MA.NS�p�ɕύX
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // �� 20070206 18322 a

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;

        //2005.07.02 �t���[���̍ŏ����Ή�����  �O��>>>>>>START
		private int _indexBuf;
		//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		//// �ŏ�������p�t���O
		//private bool _minFlg;
		//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		//2005.07.02 �t���[���̍ŏ����Ή����ǁ@�O��<<<<<<END

        // 2008.06.03 30413 ���� �V���O���^�C�v�ɕύX >>>>>>START
        // HTML���
        private const string HTML_HEADER_TITLE = "�ݒ荀��";
        private const string HTML_HEADER_VALUE = "�ݒ�l";
        private const string HTML_UNREGISTER = "���ݒ�";
        private const string HTML_PERIOD = "�`";
        private const string TAXRATE1_UPDATE = "�ŗ�������P";
        private const string TAXRATE2_UPDATE = "�ŗ�������Q";
        private const string TAXRATE3_UPDATE = "�ŗ�������R";
        
        // �ŗ��ݒ�f�[�^�擾���̈���
        private int TAXRATE_CODE_PUBLIC = 0;    //��ʏ����(�Œ�)

        // �G���[�o�͏��
        private const string CT_PGID = "SFUKK09000U";
        private const string CT_PGNM = "�ŗ��ݒ�";
        // 2008.06.03 30413 ���� �V���O���^�C�v�ɕύX <<<<<<END

		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE = "�폜��";
		private const string CODE_TITLE = "�ŗ��R�[�h";
        //private const string PROPERNOUNNM_TITLE = "�ŗ��ŗL����"; // DEL 2008/11/06
        private const string PROPERNOUNNM_TITLE = "����Ŏ��"; // ADD 2008/11/06
        //private const string NAME_TITLE = "�\���^�������"; // DEL 2008/11/06
        //private const string NAME_TITLE = "�\���^�����"; // ADD 2008/11/06   // DEL 2009/06/19
        private const string NAME_TITLE = "�\����"; // ADD 2009/06/19
        // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
		//private const string FRACTION_TITLE = "�[������";
        private const string FRACTION_TITLE = "����œ]�ŕ���";
        // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
        private const string STARTDATE1_TITLE = "�J�n���P";
		private const string ENDDATE1_TITLE = "�I�����P";
		private const string TAXRATE1_TITLE = "�ŗ��P";
		private const string STARTDATE2_TITLE = "�J�n���Q";
		private const string ENDDATE2_TITLE = "�I�����Q";
		private const string TAXRATE2_TITLE = "�ŗ��Q";
		private const string STARTDATE3_TITLE = "�J�n���R";
		private const string ENDDATE3_TITLE = "�I�����R";
		private const string TAXRATE3_TITLE = "�ŗ��R";
		private const string GUID_TITLE = "GUID";

		private const string TAXRATESET_TABLE = "TAXRATESET";

		//��r�pclone
		private TaxRateSet _taxRateSetClone;

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

		// 2005.06.21 ���ݒ莞�A�u���ݒ�v�ł͂Ȃ��󔒂ŕ\������B >>>> START
		//private const string UNREGISTER = "���ݒ�";
		private const string UNREGISTER = "";
		// 2005.06.21 ���ݒ莞�A�u���ݒ�v�ł͂Ȃ��󔒂ŕ\������B >>>> END

        // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
        //// ����Œ[�������敪
        //private const string TAXFRACPROC_NON = "�������Ȃ�";
        //private const string TAXFRACPROC_1CUT   = "���ꌅ�؎�";
        //private const string TAXFRACPROC_1ROUND = "���ꌅ�l�̌ܓ�";
        //private const string TAXFRACPROC_1RAISE = "���ꌅ�؏�";
        //private const string TAXFRACPROC_2CUT   = "���񌅐؎�";
        //private const string TAXFRACPROC_2ROUND = "���񌅎l�̌ܓ�";
        //private const string TAXFRACPROC_2RAISE = "���񌅐؏�";
        //private const string TAXFRACPROC_3CUT   = "���O���؎�";
        //private const string TAXFRACPROC_3ROUND = "���O���l�̌ܓ�";
        //private const string TAXFRACPROC_3RAISE = "���O���؏�";
        //private const string TAXFRACPROC_CUT    = "�~�����؎�";
        //private const string TAXFRACPROC_ROUND  = "�~�����l�̌ܓ�";
		//private const string TAXFRACPROC_RAISE  = "�~�����؏�";
        // ����œ]�ŕ���
        // 2008.12.18 30413 ���� ���̂�ύX >>>>>>START
        //private const string CONSTAXLAY_SLIP        = "�`�[�P��";
        //private const string CONSTAXLAY_DETAILS     = "���גP��";
        private const string CONSTAXLAY_SLIP = "�`�[�]��";
        private const string CONSTAXLAY_DETAILS = "���ד]��";
        // 2008.12.18 30413 ���� ���̂�ύX <<<<<<END
        private const string CONSTAXLAY_CLAIMPARENT = "�����e";
        private const string CONSTAXLAY_CLAIMCHILD  = "�����q";
        // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
		
		//2005.09.20 enokida ADD MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
		string pgId = "SFUKK09000U";
		string pgNm = "�ŗ��ݒ�";
		string obj = "TaxRateSetAcs";
		//2005.09.20 enokida ADD MessageBox�Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
		#endregion
    
		# region Main
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09000UA());
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
			tableName = TAXRATESET_TABLE;
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
			ArrayList taxratesets = null;

			if (readCount == 0)
			{
				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
				status = this._taxratesetAcs.SearchAll(
							out taxratesets,
							this._enterpriseCode);

				this._totalCount = taxratesets.Count;
			}
			else
			{
				status = this._taxratesetAcs.SearchSpecificationAll(
							out taxratesets,
							out this._totalCount,
							out this._nextData,
							this._enterpriseCode,
							readCount,
							this._prevTaxRateSet);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( taxratesets.Count > 0 ) {
						// �ŏI�̐ŗ��I�u�W�F�N�g��ޔ�����
						this._prevTaxRateSet = ((TaxRateSet)taxratesets[taxratesets.Count - 1]).Clone();
					}

					int index = 0;
					foreach(TaxRateSet taxrateset in taxratesets)
					{
						if (this._taxratesetTable.ContainsKey(taxrateset.FileHeaderGuid) == false)
						{
							TaxratesetToDataSet(taxrateset.Clone(), index);
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
					//2005.09.17 enokida �ύX MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);

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
			ArrayList taxratesets = null;

			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._taxratesetAcs.SearchSpecificationAll(
							out taxratesets,
							out dummy,
							out this._nextData, 
							this._enterpriseCode,
							readCount,
							this._prevTaxRateSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( taxratesets.Count > 0 ) {
						// �ŏI�̐ŗ��N���X��ޔ�����
						this._prevTaxRateSet = ((TaxRateSet)taxratesets[taxratesets.Count - 1]).Clone();
					}

					int index = 0;
					foreach(TaxRateSet taxrateset in taxratesets)
					{
						if (this._taxratesetTable.ContainsKey(taxrateset.FileHeaderGuid) == false)
						{
							index = this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows.Count;
							TaxratesetToDataSet(taxrateset.Clone(), index);
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
					//2005.09.17 enokida �ύX MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);

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
			Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			TaxRateSet taxrateset = (TaxRateSet)this._taxratesetTable[guid];

			int status = this._taxratesetAcs.LogicalDelete(ref taxrateset);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //2005.07.06 �r������Ή��@�O��>>>>>START
				if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
				{

					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"���ɑ��[�����폜����Ă��܂�",
						status,
						MessageBoxButtons.OK);
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
                    //2005.07.12 �r������R�����g�ύX�@�O��>>>>>START
//					MessageBox.Show(
//						"���ɑ��[�����폜����Ă��܂�",
//						"����",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					//MessageBox.Show(
					//	"���ɑ��[���ō폜����Ă��܂�",
					//	"����",
					//	MessageBoxButtons.OK,
					//	MessageBoxIcon.Exclamation,
					//	MessageBoxDefaultButton.Button1);
                    //2005.07.12 �r������R�����g�ύX�@�O��<<<<<<END

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
					//2005.09.17 enokida �ύX MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"�폜�Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
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
				//MessageBox.Show(
				//	"�폜�Ɏ��s���܂����B st = " + status.ToString(),
				//	"�G���[",
				//	MessageBoxButtons.OK,
				//	MessageBoxIcon.Error,
				//	MessageBoxDefaultButton.Button1);
				//return status;
                //2005.07.06 �r������Ή��@�O��<<<<<<END
			}

			status = this._taxratesetAcs.Read(out taxrateset, taxrateset.EnterpriseCode, taxrateset.TaxRateCode);

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				//2005.09.17 enokida �ύX MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
				//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//				MessageBox.Show(
//					"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
//					"�G���[",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
				return status;
			}

			TaxratesetToDataSet(taxrateset.Clone(), this._dataIndex);

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
			appearanceTable.Add(CODE_TITLE,			new GridColAppearance(MGridColDispType.None,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(PROPERNOUNNM_TITLE,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(NAME_TITLE,			new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(FRACTION_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(STARTDATE1_TITLE,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(ENDDATE1_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
//			appearanceTable.Add(TAXRATE1_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));	// 2005.06.09 TOUMA DEL �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(TAXRATE1_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(STARTDATE2_TITLE,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(ENDDATE2_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
//			appearanceTable.Add(TAXRATE2_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));	// 2005.06.09 TOUMA DEL �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(TAXRATE2_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(STARTDATE3_TITLE,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(ENDDATE3_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
//			appearanceTable.Add(TAXRATE3_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));	// 2005.06.09 TOUMA DEL �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(TAXRATE3_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX


			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,			ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// �ŗ��I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="taxrateset">�ŗ��I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �ŗ��N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void TaxratesetToDataSet(TaxRateSet taxrateset, int index)
		{
			Double ix = 0;

			if ((index < 0) || (this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[TAXRATESET_TABLE].NewRow();
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows.Count - 1;
			}

			// �_���폜���t
			if (taxrateset.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][DELETE_DATE] = taxrateset.UpdateDateTimeJpInFormal;
			}

			// �ŗ��R�[�h�i��\���j 
			this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][CODE_TITLE] = taxrateset.TaxRateCode;

			// �Œ�ŗ�����
			this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][PROPERNOUNNM_TITLE] = taxrateset.TaxRateProperNounNm;

			// �\���^����p����
			this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][NAME_TITLE] = taxrateset.TaxRateName;

            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            //// �[������
			//string wrkstr;
			//switch(taxrateset.FractionProcCd)
			//{
			//	case 0:
			//		wrkstr = TAXFRACPROC_NON;// "�������Ȃ�"
			//		break;
			//	case 11:
			//		wrkstr = TAXFRACPROC_1CUT;//"���ꌅ�؎�"
			//		break;
			//	case 12:
			//		wrkstr = TAXFRACPROC_1ROUND;//"���ꌅ�l�̌ܓ�"
			//		break;
			//	case 13:
			//		wrkstr = TAXFRACPROC_1RAISE;//"���ꌅ�؏�";
			//		break;
			//	case 21:
			//		wrkstr = TAXFRACPROC_2CUT;// "���񌅐؎�"
			//		break;
			//	case 22:
			//		wrkstr = TAXFRACPROC_2ROUND;//"���񌅎l�̌ܓ�";
			//		break;
			//	case 23:
			//		wrkstr = TAXFRACPROC_2RAISE;//"���񌅐؏�";
			//		break;
			//	case 31:
			//		wrkstr = TAXFRACPROC_3CUT;  //"���O���؎�";
			//		break;
			//	case 32:
			//		wrkstr = TAXFRACPROC_3ROUND; //"���O���l�̌ܓ�";
			//		break;
			//	case 33:
			//		wrkstr = TAXFRACPROC_3RAISE; //"���O���؏�";
			//		break;
			//	case -11:
			//		wrkstr = TAXFRACPROC_CUT;    //"�~�����؎�";
			//		break;
			//	case -12:
			//		wrkstr = TAXFRACPROC_ROUND;  //"�~�����l�̌ܓ�";
			//		break;
			//	case -13:
			//		wrkstr = TAXFRACPROC_RAISE;  //"�~�����؏�";
			//		break;
            //	default:
            //		wrkstr = UNREGISTER;
            //		break;
            //}
            // ����œ]�ŕ���
            string wrkstr;
            switch (taxrateset.ConsTaxLayMethod)
            {
                case 0:
                    wrkstr = CONSTAXLAY_SLIP;       // "�`�[�P��"
                    break;
                case 1:
                    wrkstr = CONSTAXLAY_DETAILS;    //"���גP��"
                    break;
                case 2:
                    wrkstr = CONSTAXLAY_CLAIMPARENT;//"�����e"
                    break;
                case 3:
                    wrkstr = CONSTAXLAY_CLAIMCHILD; //"�����q"
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
            this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][FRACTION_TITLE] = wrkstr;

			// �ŗ�������P �J�n��
			if (taxrateset.TaxRateStartDate != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE1_TITLE] = taxrateset.TaxRateStartDateJpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE1_TITLE] = UNREGISTER;
			}

			// �ŗ�������Q �J�n��
			if (taxrateset.TaxRateStartDate2 != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE2_TITLE] = taxrateset.TaxRateStartDate2JpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE2_TITLE] = UNREGISTER;
			}

			// �ŗ�������R �J�n��
			if (taxrateset.TaxRateStartDate3 != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE3_TITLE] = taxrateset.TaxRateStartDate3JpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE3_TITLE] = UNREGISTER;
			}

			// �ŗ�������P �I����
			if (taxrateset.TaxRateEndDate != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE1_TITLE] = taxrateset.TaxRateEndDateJpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE1_TITLE] = UNREGISTER;
			}

			// �ŗ�������Q �I����
			if (taxrateset.TaxRateEndDate2 != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE2_TITLE] = taxrateset.TaxRateEndDate2JpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE2_TITLE] = UNREGISTER;
			}

			// �ŗ�������R �I����
			if (taxrateset.TaxRateEndDate3 != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE3_TITLE] = taxrateset.TaxRateEndDate3JpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE3_TITLE] = UNREGISTER;
			}

			// �ŗ��P ��������t���͎��ɂ́u���ݒ�v�ł͂Ȃ��u0.0���v�ƕ\������
			if ((taxrateset.TaxRate != 0) ||
			   ((taxrateset.TaxRateStartDate != DateTime.MinValue) || (taxrateset.TaxRateEndDate != DateTime.MinValue)))
			{
				ix = taxrateset.TaxRate * 100;
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE1_TITLE] = ix.ToString("f1")+"%";
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE1_TITLE] = UNREGISTER;
			}

			// �ŗ��Q ��������t���͎��ɂ́u���ݒ�v�ł͂Ȃ��u0.0���v�ƕ\������
			if ((taxrateset.TaxRate2 != 0) || 
			   ((taxrateset.TaxRateStartDate2 != DateTime.MinValue) || (taxrateset.TaxRateEndDate2 != DateTime.MinValue)))
			{
				ix = taxrateset.TaxRate2 * 100;
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE2_TITLE] = ix.ToString("f1")+"%";
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE2_TITLE] = UNREGISTER;
			}

			// �ŗ��R ��������t���͎��ɂ́u���ݒ�v�ł͂Ȃ��u0.0���v�ƕ\������
			if ((taxrateset.TaxRate3 != 0) ||
			   ((taxrateset.TaxRateStartDate3 != DateTime.MinValue) || (taxrateset.TaxRateEndDate3 != DateTime.MinValue)))
			{
				ix = taxrateset.TaxRate3 * 100;
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE3_TITLE] = ix.ToString("f1")+"%";
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE3_TITLE] = UNREGISTER;
			}

			this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][GUID_TITLE] = taxrateset.FileHeaderGuid;

			if (this._taxratesetTable.ContainsKey(taxrateset.FileHeaderGuid) == true)
			{
				this._taxratesetTable.Remove(taxrateset.FileHeaderGuid);
			}
			this._taxratesetTable.Add(taxrateset.FileHeaderGuid, taxrateset);
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
			DataTable taxratesetTable = new DataTable(TAXRATESET_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			taxratesetTable.Columns.Add(DELETE_DATE, typeof(string));
			taxratesetTable.Columns.Add(CODE_TITLE, typeof(int));
			taxratesetTable.Columns.Add(PROPERNOUNNM_TITLE, typeof(string));
			taxratesetTable.Columns.Add(NAME_TITLE, typeof(string));
			taxratesetTable.Columns.Add(FRACTION_TITLE, typeof(string));
			taxratesetTable.Columns.Add(STARTDATE1_TITLE, typeof(string));
			taxratesetTable.Columns.Add(ENDDATE1_TITLE, typeof(string));
			taxratesetTable.Columns.Add(TAXRATE1_TITLE, typeof(string));
			taxratesetTable.Columns.Add(STARTDATE2_TITLE, typeof(string));
			taxratesetTable.Columns.Add(ENDDATE2_TITLE, typeof(string));
			taxratesetTable.Columns.Add(TAXRATE2_TITLE, typeof(string));
			taxratesetTable.Columns.Add(STARTDATE3_TITLE, typeof(string));
			taxratesetTable.Columns.Add(ENDDATE3_TITLE, typeof(string));
			taxratesetTable.Columns.Add(TAXRATE3_TITLE, typeof(string));
			taxratesetTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(taxratesetTable);
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
            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            ////�[�������敪�̺����ޯ���ɏ��Z�b�g
            //FractionProc_tComboEditor.Items.Clear();
            //FractionProc_tComboEditor.Items.Add(0,TAXFRACPROC_NON);
            //FractionProc_tComboEditor.Items.Add(11,TAXFRACPROC_1CUT);
            //FractionProc_tComboEditor.Items.Add(12,TAXFRACPROC_1ROUND);
            //FractionProc_tComboEditor.Items.Add(13,TAXFRACPROC_1RAISE);
            //FractionProc_tComboEditor.Items.Add(21,TAXFRACPROC_2CUT);
            //FractionProc_tComboEditor.Items.Add(22,TAXFRACPROC_2ROUND);
            //FractionProc_tComboEditor.Items.Add(23,TAXFRACPROC_2RAISE);
            //FractionProc_tComboEditor.Items.Add(31,TAXFRACPROC_3CUT);
            //FractionProc_tComboEditor.Items.Add(32,TAXFRACPROC_3ROUND);
            //FractionProc_tComboEditor.Items.Add(33,TAXFRACPROC_3RAISE);
            //FractionProc_tComboEditor.Items.Add(-11,TAXFRACPROC_CUT);
            //FractionProc_tComboEditor.Items.Add(-12,TAXFRACPROC_ROUND);
            //FractionProc_tComboEditor.Items.Add(-13,TAXFRACPROC_RAISE);
            //FractionProc_tComboEditor.MaxDropDownItems = FractionProc_tComboEditor.Items.Count;
            //����œ]�ŕ����̺����ޯ���ɏ��Z�b�g
            ConsTaxLayMethod_tComboEditor.Items.Clear();
            ConsTaxLayMethod_tComboEditor.Items.Add(0, CONSTAXLAY_SLIP);
            ConsTaxLayMethod_tComboEditor.Items.Add(1, CONSTAXLAY_DETAILS);
            ConsTaxLayMethod_tComboEditor.Items.Add(2, CONSTAXLAY_CLAIMPARENT);
            ConsTaxLayMethod_tComboEditor.Items.Add(3, CONSTAXLAY_CLAIMCHILD);
            ConsTaxLayMethod_tComboEditor.MaxDropDownItems = ConsTaxLayMethod_tComboEditor.Items.Count;
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
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
			this.TaxRateProperNounNm_tEdit.Clear();
			this.TaxRateName_tEdit.Clear();
            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.FractionProc_tComboEditor.Value = 0;
            this.ConsTaxLayMethod_tComboEditor.Value = 0;
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
            this.TaxRate_tNedit.Clear();
			this.TaxRate2_tNedit.Clear();
			this.TaxRate3_tNedit.Clear();
			this.TaxRateStartDate_tDateEdit.Clear();
			this.TaxRateStartDate2_tDateEdit.Clear();
			this.TaxRateStartDate3_tDateEdit.Clear();
			this.TaxRateEndDate_tDateEdit.Clear();
			this.TaxRateEndDate2_tDateEdit.Clear();
			this.TaxRateEndDate3_tDateEdit.Clear();
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

            this._prevTaxRateSet = new TaxRateSet();

            // �ŗ��ݒ�f�[�^�擾
            status = this._taxratesetAcs.Read(out this._prevTaxRateSet, this._enterpriseCode, TAXRATE_CODE_PUBLIC);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this._prevTaxRateSet == null)
                {
                    this._prevTaxRateSet = new TaxRateSet();
                }

                this.Mode_Label.Text = UPDATE_MODE;

                // �ŗ��ݒ��ʓW�J����
                this.TaxratesetToDataSet(this._prevTaxRateSet);
                // ��r�p�N���[���쐬
                this._taxRateSetClone = this._prevTaxRateSet.Clone();
                // ��ʏ����r�p�N���[���ɃR�s�[
                this.DispToTaxrateset(ref this._taxRateSetClone);

                // ��ʓ��͋�����
                ScreenInputPermissionControl(true);

                // �����t�H�[�J�X���Z�b�g
                this.TaxRateName_tEdit.Focus();
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
                    this._taxratesetAcs,                  // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,                 // �\������{�^��
                    MessageBoxDefaultButton.Button1);    // �����\���{�^��

                this.Mode_Label.Text = UPDATE_MODE;

                this._prevTaxRateSet = new TaxRateSet();

                // �ŗ��ݒ��ʓW�J����
                this.TaxratesetToDataSet(this._prevTaxRateSet);
                // ��r�p�N���[���쐬
                this._taxRateSetClone = this._prevTaxRateSet.Clone();
                // ��ʏ����r�p�N���[���ɃR�s�[
                this.DispToTaxrateset(ref this._taxRateSetClone);

                // ��ʓ��͋�����
                ScreenInputPermissionControl(true);

                // �����t�H�[�J�X���Z�b�g
                this.TaxRateName_tEdit.Focus();
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
			this.TaxRateProperNounNm_tEdit.Enabled = enabled;
			this.TaxRateName_tEdit.Enabled = enabled;
            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.FractionProc_tComboEditor.Enabled = enabled;
            this.ConsTaxLayMethod_tComboEditor.Enabled = enabled;
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
            this.TaxRate_tNedit.Enabled = enabled;
			this.TaxRate2_tNedit.Enabled = enabled;
			this.TaxRate3_tNedit.Enabled = enabled;
			this.TaxRateStartDate_tDateEdit.Enabled = enabled;
			this.TaxRateStartDate2_tDateEdit.Enabled = enabled;
			this.TaxRateStartDate3_tDateEdit.Enabled = enabled;
			this.TaxRateEndDate_tDateEdit.Enabled = enabled;
			this.TaxRateEndDate2_tDateEdit.Enabled = enabled;
			this.TaxRateEndDate3_tDateEdit.Enabled = enabled;
		}

		/// <summary>
		/// �ŗ��N���X��ʓW�J����
		/// </summary>
		/// <param name="taxrateset">�ŗ��I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �ŗ��I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void TaxratesetToDataSet(TaxRateSet taxrateset)
		{
			this.TaxRateProperNounNm_tEdit.Text = taxrateset.TaxRateProperNounNm;
			this.TaxRateName_tEdit.Text = taxrateset.TaxRateName;
            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            //this.FractionProc_tComboEditor.Value = taxrateset.FractionProcCd;
            this.ConsTaxLayMethod_tComboEditor.Value = taxrateset.ConsTaxLayMethod;
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<

			// �e���t���ŏ��l�̏ꍇ�͕\�����Ȃ�
			if (taxrateset.TaxRateStartDate != DateTime.MinValue)
			{
				this.TaxRateStartDate_tDateEdit.SetDateTime(taxrateset.TaxRateStartDate);
			}

			if (taxrateset.TaxRateStartDate2 != DateTime.MinValue)
			{
				this.TaxRateStartDate2_tDateEdit.SetDateTime(taxrateset.TaxRateStartDate2);
			}

			if (taxrateset.TaxRateStartDate3 != DateTime.MinValue)
			{
				this.TaxRateStartDate3_tDateEdit.SetDateTime(taxrateset.TaxRateStartDate3);
			}

			if (taxrateset.TaxRateEndDate != DateTime.MinValue)
			{
				this.TaxRateEndDate_tDateEdit.SetDateTime(taxrateset.TaxRateEndDate);
			}

			if (taxrateset.TaxRateEndDate2 != DateTime.MinValue)
			{
				this.TaxRateEndDate2_tDateEdit.SetDateTime(taxrateset.TaxRateEndDate2);
			}

			if (taxrateset.TaxRateEndDate3 != DateTime.MinValue)
			{
				this.TaxRateEndDate3_tDateEdit.SetDateTime(taxrateset.TaxRateEndDate3);
			}

			this.TaxRate_tNedit.SetValue(taxrateset.TaxRate * 100);
			this.TaxRate2_tNedit.SetValue(taxrateset.TaxRate2 * 100);
			this.TaxRate3_tNedit.SetValue(taxrateset.TaxRate3 * 100);
		}

		/// <summary>
		/// ��ʏ��ŗ��N���X�i�[����
		/// </summary>
		/// <param name="taxrateset">�ŗ��I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�ŗ��I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
 		private void DispToTaxrateset(ref TaxRateSet taxrateset)
		{
			if (taxrateset == null)
			{
				// �V�K�̏ꍇ
				taxrateset = new TaxRateSet();
			}

			taxrateset.EnterpriseCode		= this._enterpriseCode;			// �� �v�ύX
			taxrateset.TaxRateProperNounNm	= this.TaxRateProperNounNm_tEdit.Text;
			taxrateset.TaxRateName			= this.TaxRateName_tEdit.Text;
            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            //taxrateset.FractionProcCd = (int)this.FractionProc_tComboEditor.Value;
            taxrateset.ConsTaxLayMethod = (int)this.ConsTaxLayMethod_tComboEditor.Value;
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
            taxrateset.TaxRateStartDate = this.TaxRateStartDate_tDateEdit.GetDateTime();
			taxrateset.TaxRateStartDate2	= this.TaxRateStartDate2_tDateEdit.GetDateTime();
			taxrateset.TaxRateStartDate3	= this.TaxRateStartDate3_tDateEdit.GetDateTime();
			taxrateset.TaxRateEndDate		= this.TaxRateEndDate_tDateEdit.GetDateTime();
			taxrateset.TaxRateEndDate2		= this.TaxRateEndDate2_tDateEdit.GetDateTime();
			taxrateset.TaxRateEndDate3		= this.TaxRateEndDate3_tDateEdit.GetDateTime();
			taxrateset.TaxRate				= this.TaxRate_tNedit.GetValue() / 100;
			taxrateset.TaxRate2				= this.TaxRate2_tNedit.GetValue() / 100;
			taxrateset.TaxRate3				= this.TaxRate3_tNedit.GetValue() / 100;
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
        /// <br>Note       : Redmine#42120 �ŗ��ݒ�}�X�^�Ƀ`�F�b�N��ǉ�����</br>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2014/02/18</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			// �\���^����p����
			if (this.TaxRateName_tEdit.Text.Trim() == "")
			{
				control = this.TaxRateName_tEdit;
				message = this.Name_Title_Label.Text + "����͂��ĉ������B";
				return false;
			}
			
            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            // �[������
			//if ((int)this.FractionProc_tComboEditor.Value == -1)
			//{
			//	control = this.FractionProc_tComboEditor;
			//	message = this.FractionProc_Label.Text + "��I�����ĉ������B";
			//	return false;
			//}
            // ����œ]��
            if ((int)this.ConsTaxLayMethod_tComboEditor.Value == -1)
            {
                control = this.ConsTaxLayMethod_tComboEditor;
                message = this.ConsTaxLayMethod_Label.Text + "��I�����ĉ������B";
                return false;
            }
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
			
			// �ŋ�������P�J�n��
			if (this.TaxRateStartDate_tDateEdit.LongDate == 0)
			{
				control = this.TaxRateStartDate_tDateEdit;
				message = this.TaxRateDate1_Label.Text + "����͂��ĉ������B";
				return false;
			}
			
			// �ŋ�������P�I����
			if (this.TaxRateEndDate_tDateEdit.LongDate == 0)
			{
				control = this.TaxRateEndDate_tDateEdit;
				message = this.TaxRateDate1_Label.Text + "����͂��ĉ������B";
				return false;
			}
			
			//--���t�̗L�����`�F�b�N--//
			if ((TaxRateStartDate_tDateEdit.CheckInputData() != null) ||
				!(CheckDateEffect(TaxRateStartDate_tDateEdit)))
			{
				message = "�ŗ�������P�̊J�n�����s���ł��B";
				control = TaxRateStartDate_tDateEdit;
				return false;
			}
			if ((TaxRateEndDate_tDateEdit.CheckInputData() != null) ||
				!(CheckDateEffect(TaxRateEndDate_tDateEdit)))
			{
				message = "�ŗ�������P�̏I�������s���ł��B";
				control = TaxRateEndDate_tDateEdit;
				return false;
			}

			//--�L�����̑召�`�F�b�N--//
			if (TaxRateStartDate_tDateEdit.LongDate >= TaxRateEndDate_tDateEdit.LongDate)
			{
				control = TaxRateStartDate_tDateEdit;
				message = "�ŗ�������P�͈̔͂��s���ł��B";
				return false;
			}

			// �ŋ�������Q�������͐ŗ��Q�̂��Âꂩ�����͂���Ă����ꍇ
			if ((this.TaxRate2_tNedit.GetValue() != 0) || 
				(this.TaxRateStartDate2_tDateEdit.LongDate != 0) ||
				(this.TaxRateEndDate2_tDateEdit.LongDate != 0))
			{
				// �ŋ�������Q�J�n��
				if (this.TaxRateStartDate2_tDateEdit.LongDate == 0)
				{
					control = this.TaxRateStartDate2_tDateEdit;
					message = this.TaxRateDate2_Label.Text + "����͂��ĉ������B";
					return false;
				}
			
				// �ŋ�������Q�I����
				if (this.TaxRateEndDate2_tDateEdit.LongDate == 0)
				{
					control = this.TaxRateEndDate2_tDateEdit;
					message = this.TaxRateDate2_Label.Text + "����͂��ĉ������B";
					return false;
				}
			
				//--���t�̗L�����`�F�b�N--//
				if ((TaxRateStartDate2_tDateEdit.CheckInputData() != null) ||
					!(CheckDateEffect(TaxRateStartDate2_tDateEdit)))
				{
					message = "�ŗ�������Q�̊J�n�����s���ł��B";
					control = TaxRateStartDate2_tDateEdit;
					return false;
				}
				if ((TaxRateEndDate2_tDateEdit.CheckInputData() != null) ||
					!(CheckDateEffect(TaxRateEndDate2_tDateEdit)))
				{
					message = "�ŗ�������Q�̏I�������s���ł��B";
					control = TaxRateEndDate2_tDateEdit;
					return false;
				}

				//--�L�����̑召�`�F�b�N--//
				if (TaxRateStartDate2_tDateEdit.LongDate >= TaxRateEndDate2_tDateEdit.LongDate)
				{
					control = TaxRateStartDate2_tDateEdit;
					message = "�ŗ�������Q�͈̔͂��s���ł��B";
					return false;
				}

                // 2008.03.06 �ǉ� >>>>>>>>>>>>>>>>>>>>
				//--�L�����̏d���`�F�b�N--//
                if ( (TaxRateEndDate_tDateEdit.LongDate   >= TaxRateStartDate2_tDateEdit.LongDate) ||
                    ((TaxRateStartDate_tDateEdit.LongDate >  TaxRateStartDate2_tDateEdit.LongDate) &&
                     (TaxRateEndDate2_tDateEdit.LongDate  >= TaxRateStartDate_tDateEdit.LongDate )))
				{
					control = TaxRateStartDate2_tDateEdit;
                    message = "�ŗ�������Q�͈̔͂��ŗ�������P�͈̔͂Əd�����Ă܂��B";
					return false;
				}
                // 2008.03.06 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }

			// �ŋ�������R�������͐ŗ��R�̂��Âꂩ�����͂���Ă����ꍇ
			if ((this.TaxRate3_tNedit.GetValue() != 0) || 
				(this.TaxRateStartDate3_tDateEdit.LongDate != 0) ||
				(this.TaxRateEndDate3_tDateEdit.LongDate != 0))
			{
				// �ŋ�������R�J�n��
				if (this.TaxRateStartDate3_tDateEdit.LongDate == 0)
				{
					control = this.TaxRateStartDate3_tDateEdit;
					message = this.TaxRateDate3_Label.Text + "����͂��ĉ������B";
					return false;
				}
			
				// �ŋ�������R�I����
				if (this.TaxRateEndDate3_tDateEdit.LongDate == 0)
				{
					control = this.TaxRateEndDate3_tDateEdit;
					message = this.TaxRateDate3_Label.Text + "����͂��ĉ������B";
					return false;
				}
			
				//--���t�̗L�����`�F�b�N--//
				if ((TaxRateStartDate3_tDateEdit.CheckInputData() != null) ||
					!(CheckDateEffect(TaxRateStartDate3_tDateEdit)))
				{
					message = "�ŗ�������R�̊J�n�����s���ł��B";
                    // 2007.03.27  S.Koga  amend ------------------------------------------
                    //control = TaxRateStartDate_tDateEdit;
                    control = TaxRateStartDate3_tDateEdit;
                    // --------------------------------------------------------------------
                    return false;
				}
				if ((TaxRateEndDate3_tDateEdit.CheckInputData() != null) ||
					!(CheckDateEffect(TaxRateEndDate3_tDateEdit)))
				{
					message = "�ŗ�������R�̏I�������s���ł��B";
                    // 2007.03.27  S.Koga  amend ------------------------------------------
					//control = TaxRateEndDate_tDateEdit;
                    control = TaxRateEndDate3_tDateEdit;
                    // --------------------------------------------------------------------
                    return false;
				}

				//--�L�����̑召�`�F�b�N--//
				if (TaxRateStartDate3_tDateEdit.LongDate >= TaxRateEndDate3_tDateEdit.LongDate)
				{
					control = TaxRateStartDate3_tDateEdit;
					message = "�ŗ�������R�͈̔͂��s���ł��B";
					return false;
				}

                // 2008.03.06 �ǉ� >>>>>>>>>>>>>>>>>>>>
                //--�L�����̏d���`�F�b�N--//
                if ( (TaxRateEndDate_tDateEdit.LongDate   >= TaxRateStartDate3_tDateEdit.LongDate) ||
                    ((TaxRateStartDate_tDateEdit.LongDate >  TaxRateStartDate3_tDateEdit.LongDate) &&
                     (TaxRateEndDate3_tDateEdit.LongDate  >= TaxRateStartDate_tDateEdit.LongDate )))
                {
                    control = TaxRateStartDate3_tDateEdit;
                    message = "�ŗ�������R�͈̔͂��ŗ�������P�͈̔͂Əd�����Ă܂��B";
                    return false;
                }
                if ( (TaxRateEndDate2_tDateEdit.LongDate   >= TaxRateStartDate3_tDateEdit.LongDate) ||
                    ((TaxRateStartDate2_tDateEdit.LongDate >  TaxRateStartDate3_tDateEdit.LongDate) &&
                     (TaxRateEndDate3_tDateEdit.LongDate   >= TaxRateStartDate2_tDateEdit.LongDate)))
                {
                    control = TaxRateStartDate3_tDateEdit;
                    message = "�ŗ�������R�͈̔͂��ŗ�������Q�͈̔͂Əd�����Ă܂��B";
                    return false;
                }
                // 2008.03.06 �ǉ� <<<<<<<<<<<<<<<<<<<<
            }

            //-----ADD �A���� 2014/02/18 Redmine#42120 �ŗ��ݒ�}�X�^�Ƀ`�F�b�N��ǉ�����----->>>>>
            // �ŋ�������Q�������͐ŗ��Q�̂��Âꂩ�����͂���Ă����ꍇ
            if ((this.TaxRate2_tNedit.GetValue() != 0) ||
                (this.TaxRateStartDate2_tDateEdit.LongDate != 0) ||
                (this.TaxRateEndDate2_tDateEdit.LongDate != 0))
            {
                //�ŗ�������Ŋ���1�Ɗ���2�̊Ԃɋ󔒂�����
                if (TaxRateStartDate2_tDateEdit.GetDateTime() > TaxRateEndDate_tDateEdit.GetDateTime().AddDays(1))
                {
                    control = TaxRateStartDate2_tDateEdit;
                    message = "�ŗ�������P�Ɛŗ�������Q�̊Ԃɋ󔒊��Ԃ�����܂��B�󔒊��Ԃ������悤�ɐݒ肵�ĉ������B";
                    return false;
                }
            }
            //�ŋ�������R�������͐ŗ��R�̂��Âꂩ�����͂���Ă����ꍇ
            if ((this.TaxRate3_tNedit.GetValue() != 0) ||
                (this.TaxRateStartDate3_tDateEdit.LongDate != 0) ||
                (this.TaxRateEndDate3_tDateEdit.LongDate != 0))
            {
                //�ŋ�������Q�������͐ŗ��Q�̂��Âꂩ�����͂���Ă����ꍇ
                if ((this.TaxRate2_tNedit.GetValue() != 0) ||
                (this.TaxRateStartDate2_tDateEdit.LongDate != 0) ||
                (this.TaxRateEndDate2_tDateEdit.LongDate != 0))
                {
                    //�ŗ�������Ŋ���2�Ɗ���3�̊Ԃɋ󔒂�����
                    if (TaxRateStartDate3_tDateEdit.GetDateTime() > TaxRateEndDate2_tDateEdit.GetDateTime().AddDays(1))
                    {
                        control = TaxRateStartDate3_tDateEdit;
                        message = "�ŗ�������Q�Ɛŗ�������R�̊Ԃɋ󔒊��Ԃ�����܂��B�󔒊��Ԃ������悤�ɐݒ肵�ĉ������B";
                        return false;
                    }
                }
                else
                {
                    //�ŗ�������Ŋ���1�Ɗ���3�̊Ԃɋ󔒂�����
                    if (TaxRateStartDate3_tDateEdit.GetDateTime() > TaxRateEndDate_tDateEdit.GetDateTime().AddDays(1))
                    {
                        control = TaxRateStartDate3_tDateEdit;
                        message = "�ŗ�������P�Ɛŗ�������R�̊Ԃɋ󔒊��Ԃ�����܂��B�󔒊��Ԃ������悤�ɐݒ肵�ĉ������B";
                        return false;
                    }
                }
            }
            //-----ADD �A���� 2014/02/18 Redmine#42120 �ŗ��ݒ�}�X�^�Ƀ`�F�b�N��ǉ�����-----<<<<<
			
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
       �@ return false;
				}
			}
			return true;    
		}

		/// <summary>
		/// �ŗ��ۑ�����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��o�^���s���܂��B</br>
		/// <br>Programmer : 21041�@�����@��</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private bool SaveTaxRateSet()
		{
			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					pgId,
					message,
					0,
					MessageBoxButtons.OK);
				//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//				MessageBox.Show(
//					message,
//					"���̓`�F�b�N",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//					MessageBoxDefaultButton.Button1);

				control.Focus();
				return false;
			}

			TaxRateSet taxrateset = null;
            // 2008.06.03 30413 ���� �V���O���^�C�v�ɕύX >>>>>>START
            // �}���`�^�C�v���̃��X�g�I���C���f�b�N�X�ł͍X�V�������s���Ȃ��ׁA
            // ��r�p�N���[�������ʏ��ȊO��ݒ肷��
            //if (this.DataIndex >= 0)
			//{
				//Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//taxrateset = ((TaxRateSet)this._taxratesetTable[guid]).Clone();
			//}
            taxrateset = this._taxRateSetClone.Clone();
            // 2008.06.03 30413 ���� �V���O���^�C�v�ɕύX <<<<<<End
			
			DispToTaxrateset(ref taxrateset);
            
			int status = this._taxratesetAcs.Write(ref taxrateset);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"���̐ŗ��R�[�h�͊��Ɏg�p����Ă��܂��B",
						0,
						MessageBoxButtons.OK);
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"���̐ŗ��R�[�h�͊��Ɏg�p����Ă��܂��B",
//						"���",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);
					return false;
				}
                //2005.07.06 �r������Ή��@�O��>>>>>START
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{

					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"���ɑ��[�����X�V����Ă��܂�",
						status,
						MessageBoxButtons.OK);
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
                    //2005.07.12 �r������R�����g�ύX�@�O��>>>>>START
//					MessageBox.Show(
//						"���ɑ��[�����X�V����Ă��܂�",
//						"����",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					//MessageBox.Show(
					//	"���ɑ��[���ō폜����Ă��܂�",
					//	"����",
					//	MessageBoxButtons.OK,
					//	MessageBoxIcon.Exclamation,
					//	MessageBoxDefaultButton.Button1);
                    //2005.07.12 �r������R�����g�ύX�@�O��<<<<<<END

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
					//2005.09.17 enokida �ύX MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"SaveTaxRateSet",
						TMsgDisp.OPE_UPDATE,
						"�o�^�Ɏ��s���܂����B",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					//2005.09.17 enokida �ύX MessageBox�Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"�o�^�Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
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
				//default:
				//{
				//	MessageBox.Show(
				//		"�o�^�Ɏ��s���܂����B st = " + status.ToString(),
				//		"�G���[",
				//		MessageBoxButtons.OK,
				//		MessageBoxIcon.Error,
				//		MessageBoxDefaultButton.Button1);
				//	return false;
				//}
                //2005.07.06 �r������Ή��@�O��<<<<<<END

			}

			TaxratesetToDataSet(taxrateset, this.DataIndex);

			return true;
		}
		# endregion

		#region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFUKK09000UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void SFUKK09000UA_Load(object sender, System.EventArgs e)
		{
            // �� 20070206 18322 a MA.NS�p�ɕύX
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            // �� 20070206 18322 a

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
        /// Form.Closing �C�x���g(SFUKK09000UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void SFUKK09000UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��>>>>>>STRAT
			this._indexBuf = -2;
			//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//// �ŏ�������t���O�̏�����
			//this._minFlg = false;
			//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��<<<<<<END

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
        /// Control.VisibleChanged �C�x���g(SFUKK09000UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 21041�@�����@��</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void SFUKK09000UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				//2005.10.19 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				//2005.10.19 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
				return;
			}

            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��>>>>>>START
			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//if (this._minFlg == false)
		    //{
			//	// �L�[���̏�����
			//	this.TaxRateProperNounNm_tEdit.Clear();
			//}														  

			// �V�K���[�h�ȊO�̏ꍇ
			//if(this._dataIndex >= 0)
			//{
			//	// �t���[���őI������Ă��郌�R�[�h��GUID���擾
			//	Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			//	// ��L�̃��R�[�h���N���X�ɃZ�b�g
			//	TaxRateSet taxRateSet = (TaxRateSet)this._taxratesetTable[guid];
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
			//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��<<<<<<END
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
            // �ŗ��o�^����
			if (SaveTaxRateSet() == false)
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
				this.TaxRateProperNounNm_tEdit.Focus();
				// �N���[�����ēx�擾����
				TaxRateSet newTaxRateSet = new TaxRateSet();
				//�N���[���쐬
				this._taxRateSetClone = newTaxRateSet.Clone(); 
				DispToTaxrateset( ref this._taxRateSetClone);

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

                //2005.07.02�@�t���[���̍ŏ����Ή����ǁ@�O��>>>>>>START
				this._indexBuf = -2;
				//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//// �ŏ�������t���O�̏�����
				//this._minFlg = false;
				//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��<<<<<<END
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
            // 2008.06.03 30413 ���� �o�^��ɉ�ʂɕύX�����f����Ȃ��_���C�� >>>>>>START
            DialogResult res = DialogResult.Cancel;
            // 2008.06.03 30413 ���� �o�^��ɉ�ʂɕύX�����f����Ȃ��_���C�� <<<<<<END

			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE)
			{
				//�ۑ��m�F
				TaxRateSet compareTaxRateSet = new TaxRateSet();
				compareTaxRateSet = this._taxRateSetClone.Clone();  

				//���݂̉�ʏ����擾����
				DispToTaxrateset( ref compareTaxRateSet);
				//�ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._taxRateSetClone.Equals(compareTaxRateSet)))	
				{
					//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					//DialogResult res = MessageBox.Show("�ҏW���̃f�[�^�����݂��܂�"+"\r\n"+"\r\n"+"�o�^���Ă���낵���ł����H","�ۑ��m�F",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);

					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
                    // 2008.06.03 30413 ���� �o�^��ɉ�ʂɕύX�����f����Ȃ��_���C�� >>>>>>START
					//DialogResult res = TMsgDisp.Show(this,
					//	emErrorLevel.ERR_LEVEL_SAVECONFIRM,
					//	pgId,
					//	"",
					//	0,
					//	MessageBoxButtons.YesNoCancel);
                    res = TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        pgId,
                        "",
                        0,
                        MessageBoxButtons.YesNoCancel);
                    // 2008.06.03 30413 ���� �o�^��ɉ�ʂɕύX�����f����Ȃ��_���C�� <<<<<<END
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
					switch(res)
					{
						case DialogResult.Yes:
						{
							// �ŗ��o�^����
							if (SaveTaxRateSet() ==false)
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
                // TODO Cancel�̏ꍇ�A�o�^��ɉ�ʂɕύX�����f����Ă��Ȃ��BOK���Ɣ��f�����B
                // 2008.06.03 30413 ���� �o�^��ɉ�ʂɕύX�����f����Ȃ��_���C�� >>>>>>START
				//MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(res);
                // 2008.06.03 30413 ���� �o�^��ɉ�ʂɕύX�����f����Ȃ��_���C�� <<<<<<END
				UnDisplaying(this, me);
			}

            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��>>>>>START
			//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//// �ŏ�������t���O�̏�����
			//this._minFlg = false;
			//// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			//this.DialogResult = DialogResult.Cancel;
            // 2008.06.03 30413 ���� �o�^��ɉ�ʂɕύX�����f����Ȃ��_���C�� >>>>>>START
            //this.DialogResult = DialogResult.Cancel;
            this.DialogResult = res;
            // 2008.06.03 30413 ���� �o�^��ɉ�ʂɕύX�����f����Ȃ��_���C�� <<<<<<END
            this._indexBuf = -2;
            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��<<<<<<END
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
			//2005.09.17 Message���i�Ή� �ύX <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
			DialogResult result = TMsgDisp.Show(this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				pgId,
				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
				0,
				MessageBoxButtons.OKCancel,
				MessageBoxDefaultButton.Button2);
			//2005.09.17 Message���i�Ή� �ύX <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//			DialogResult result = MessageBox.Show(
//				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
//				"�폜�m�F",
//				MessageBoxButtons.OKCancel,
//				MessageBoxIcon.Exclamation,
//				MessageBoxDefaultButton.Button2);

			if (result == DialogResult.OK)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
				TaxRateSet taxrateset = (TaxRateSet)this._taxratesetTable[guid];

				int status = this._taxratesetAcs.Delete(taxrateset);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this.DataIndex].Delete();
						this._taxratesetTable.Remove(taxrateset.FileHeaderGuid);

						break;
					}
					default:
					{
						//2005.09.17 enokida �ύX MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
						//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

//						MessageBox.Show(
//							"�폜�Ɏ��s���܂����B st = " + status.ToString(),
//							"�G���[",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
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

            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��>>>>>>START
			this._indexBuf = -2;
            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��<<<<<<END
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
			Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			TaxRateSet taxrateset = (TaxRateSet)_taxratesetTable[guid];

			int status = this._taxratesetAcs.Revival(ref taxrateset);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"���Ƀf�[�^�����S�폜����Ă��܂��B" ,
						status,
						MessageBoxButtons.OK);
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

//					MessageBox.Show(
//						"���Ƀf�[�^�����S�폜����Ă��܂��B" + status.ToString(),
//						"���",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);

					break;
				}
				default:
				{
					
					//2005.09.17 enokida �ύX MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
					//2005.09.17 enokida �ύX MessageBox�Ή�<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"�����Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);

					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			TaxratesetToDataSet(taxrateset, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��>>>>>>START
			this._indexBuf = -2;
            //2005.07.02  �t���[���̍ŏ����Ή����ǁ@�O��<<<<<<END

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
		// 2005.06.20 �ŗ����ڕ\���̍œK���B >>>> START
		private void TaxRate_tNedit_Leave(object sender, System.EventArgs e)
		{
			Double value = TaxRate_tNedit.GetValue();
			TaxRate_tNedit.Text = value.ToString("#0.0");		
		}

		private void TaxRate2_tNedit_Leave(object sender, System.EventArgs e)
		{
			Double value = TaxRate2_tNedit.GetValue();
			TaxRate2_tNedit.Text = value.ToString("#0.0");				
		}

		private void TaxRate3_tNedit_Leave(object sender, System.EventArgs e)
		{
			Double value = TaxRate3_tNedit.GetValue();
			TaxRate3_tNedit.Text = value.ToString("#0.0");						
		}
        // 2005.06.20 �ŗ����ڕ\���̍œK���B >>>> END

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
            titleList.Add(PROPERNOUNNM_TITLE);             // �ŗ��ŗL����
            titleList.Add(NAME_TITLE);    // �\���^�������
            titleList.Add(FRACTION_TITLE);    // ����œ]�ŕ���
            titleList.Add(TAXRATE1_UPDATE);     // �ŗ�������P
            titleList.Add(this.TaxRate1_Label.Text);      // �ŗ��P
            titleList.Add(TAXRATE2_UPDATE);    // �ŗ�������Q
            titleList.Add(this.TaxRate2_Label.Text);       // �ŗ��Q
            titleList.Add(TAXRATE3_UPDATE);       // �ŗ�������R
            titleList.Add(this.TaxRate3_Label.Text);       // �ŗ��R

            // �ŗ��ݒ�f�[�^�擾
            int status = 0;
            status = this._taxratesetAcs.Read(out this._prevTaxRateSet, this._enterpriseCode, TAXRATE_CODE_PUBLIC);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // �ŗ��ݒ�擾�f�[�^�ݒ�
                        if (this._prevTaxRateSet != null)
                        {
                            valueList.Add(this._prevTaxRateSet.TaxRateProperNounNm);
                            valueList.Add(this._prevTaxRateSet.TaxRateName);

                            // ����œ]�ŕ���
                            string wrkstr;
                            switch (_prevTaxRateSet.ConsTaxLayMethod)
                            {
                                case 0:
                                    wrkstr = CONSTAXLAY_SLIP;       // "�`�[�P��"
                                    break;
                                case 1:
                                    wrkstr = CONSTAXLAY_DETAILS;    //"���גP��"
                                    break;
                                case 2:
                                    wrkstr = CONSTAXLAY_CLAIMPARENT;//"�����e"
                                    break;
                                case 3:
                                    wrkstr = CONSTAXLAY_CLAIMCHILD; //"�����q"
                                    break;
                                default:
                                    wrkstr = UNREGISTER;
                                    break;
                            }
                            valueList.Add(wrkstr);
                            valueList.Add(this._prevTaxRateSet.TaxRateStartDateAdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDateAdFormal);
                            valueList.Add(this._prevTaxRateSet.TaxRate.ToString("#0.0%"));
                            // 2008.09.25 30413 ���� �ŗ�������Ɛŗ��𖢐ݒ莞�͋󔒂ɏC�� >>>>>>START
                            //valueList.Add(this._prevTaxRateSet.TaxRateStartDate2AdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDate2AdFormal);
                            //valueList.Add(this._prevTaxRateSet.TaxRate2.ToString("#0.0%"));
                            //valueList.Add(this._prevTaxRateSet.TaxRateStartDate3AdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDate3AdFormal);
                            //valueList.Add(this._prevTaxRateSet.TaxRate3.ToString("#0.0%"));

                            // �ŗ�������Q �J�n���`�I����
                            if ((this._prevTaxRateSet.TaxRateStartDate2 != DateTime.MinValue) && (this._prevTaxRateSet.TaxRateEndDate2 != DateTime.MinValue))
                            {
                                // �J�n���ƏI�����������Ƃ��ݒ肳��Ă���
                                valueList.Add(this._prevTaxRateSet.TaxRateStartDate2AdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDate2AdFormal);
                            }
                            else
                            {
                                // ��L�ȊO�͋�
                                valueList.Add(UNREGISTER);
                            }

                            // �ŗ��Q
                            if (this._prevTaxRateSet.TaxRate2 != 0.0)
                            {
                                // �ŗ����ݒ肳��Ă���
                                valueList.Add(this._prevTaxRateSet.TaxRate2.ToString("#0.0%"));
                            }
                            else
                            {
                                // ��L�ȊO�͋�
                                valueList.Add(UNREGISTER);
                            }
                            
                            // �ŗ�������R �J�n���`�I����
                            if ((this._prevTaxRateSet.TaxRateStartDate3 != DateTime.MinValue) && (this._prevTaxRateSet.TaxRateEndDate3 != DateTime.MinValue))
                            {
                                // �J�n���ƏI�����������Ƃ��ݒ肳��Ă���
                                valueList.Add(this._prevTaxRateSet.TaxRateStartDate3AdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDate3AdFormal);
                            }
                            else
                            {
                                // ��L�ȊO�͋�
                                valueList.Add(UNREGISTER);
                            }

                            // �ŗ��R
                            if (this._prevTaxRateSet.TaxRate3 != 0.0)
                            {
                                // �ŗ����ݒ肳��Ă���
                                valueList.Add(this._prevTaxRateSet.TaxRate3.ToString("#0.0%"));
                            }
                            else
                            {
                                // ��L�ȊO�͋�
                                valueList.Add(UNREGISTER);
                            }
                            // 2008.09.25 30413 ���� �ŗ�������Ɛŗ��𖢐ݒ莞�͋󔒂ɏC�� <<<<<<END
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
                            this._taxratesetAcs,                  // �G���[�����������I�u�W�F�N�g
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

        /// <summary>Control.ChangeFocus �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�J�X�ړ����ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.09.25</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            bool canChangeFocus = true;
            string message = "";

            switch (e.PrevCtrl.Name)
            {
                // 2008.10.03 30413 ���� �t�H�[�J�X�����ύX >>>>>>START
                case "ConsTaxLayMethod_tComboEditor":
                    {
                        if (e.Key == Keys.Down)
                        {
                            // ���L�[�̏ꍇ�́A�ŗ�������P�̔N�ɋ����t�H�[�J�X�ړ�
                            e.NextCtrl = null;
                            this.TaxRateStartDate_tDateEdit.Focus();                            
                        }
                        break;
                    }
                // 2008.10.03 30413 ���� �t�H�[�J�X�����ύX <<<<<<END
                case "TaxRateStartDate_tDateEdit":
                    {
                        // �ŗ�������P(�J�n)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate1_Label.Text + "�̊J�n�����s���ł��B";
                            canChangeFocus = false;
                        }
                        break;
                    }
                case "TaxRateEndDate_tDateEdit":
                    {
                        // �ŗ�������P(�I��)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate1_Label.Text + "�̏I�������s���ł��B";
                            canChangeFocus = false;
                        }
                        // 2008.10.03 30413 ���� �t�H�[�J�X�����ύX >>>>>>START
                        else
                        {
                            if (e.Key == Keys.Down)
                            {
                                // ���L�[�̏ꍇ�́A�ŗ��P�ɋ����t�H�[�J�X�ړ�
                                e.NextCtrl = this.TaxRate_tNedit;
                            }
                        }
                        // 2008.10.03 30413 ���� �t�H�[�J�X�����ύX <<<<<<END
                        break;
                    }
                case "TaxRateStartDate2_tDateEdit":
                    {
                        // �ŗ�������Q(�J�n)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate2_Label.Text + "�̊J�n�����s���ł��B";
                            canChangeFocus = false;
                        }
                        break;
                    }
                case "TaxRateEndDate2_tDateEdit":
                    {
                        // �ŗ�������Q(�I��)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate2_Label.Text + "�̏I�������s���ł��B";
                            canChangeFocus = false;
                        }
                        // 2008.10.03 30413 ���� �t�H�[�J�X�����ύX >>>>>>START
                        else
                        {
                            if (e.Key == Keys.Down)
                            {
                                // ���L�[�̏ꍇ�́A�ŗ��Q�ɋ����t�H�[�J�X�ړ�
                                e.NextCtrl = this.TaxRate2_tNedit;
                            }
                        }
                        // 2008.10.03 30413 ���� �t�H�[�J�X�����ύX <<<<<<END
                        break;
                    }
                case "TaxRateStartDate3_tDateEdit":
                    {
                        // �ŗ�������R(�J�n)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate3_Label.Text + "�̊J�n�����s���ł��B";                            
                            canChangeFocus = false;
                        }
                        break;
                    }
                case "TaxRateEndDate3_tDateEdit":
                    {
                        // �ŗ�������R(�I��)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate3_Label.Text + "�̏I�������s���ł��B";
                            canChangeFocus = false;
                        }
                        // 2008.10.03 30413 ���� �t�H�[�J�X�����ύX >>>>>>START
                        else
                        {
                            if (e.Key == Keys.Down)
                            {
                                // ���L�[�̏ꍇ�́A�ŗ��R�ɋ����t�H�[�J�X�ړ�
                                e.NextCtrl = this.TaxRate3_tNedit;
                            }
                        }
                        // 2008.10.03 30413 ���� �t�H�[�J�X�����ύX <<<<<<END
                        break;
                    }
            }

            // �t�H�[�J�X����
            if (canChangeFocus == false)
            {
                if (message != "")
                {
                    // �G���[���b�Z�[�W������Ε\��
                    TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                pgId,
                                message,
                                0,
                                MessageBoxButtons.OK);
                }

                e.NextCtrl = e.PrevCtrl;

                // ���݂̍��ڂ���ړ������A�e�L�X�g�S�I����ԂƂ���
                e.NextCtrl.Select();
            }
        }
    }
}