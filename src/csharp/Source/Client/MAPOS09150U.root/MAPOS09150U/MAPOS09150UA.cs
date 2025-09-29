//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �[���Ǘ��ݒ�}�X�^
// �v���O�����T�v   : �[���Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/05  �C�����e : SCM�I�v�V�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �� �� ��  2009/08/11  �C�����e : IP�A�h���X�̓��͐���̕ύX����ђǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �� �� ��  2009/09/24  �C�����e : ���[�����̓o�^�������Ȃ��d�l�Ƃ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2009/06/29  �C�����e : Mantis.15667�@�d�l�ύX
//----------------------------------------------------------------------------//
//#define _ADMIN_MODE_    // �����I�ɊǗ��҃��[�h�ɂ���t���O ���ʏ�͖����ɂ��Ă������ƁI

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;   // ADD 2009/06/05
using Microsoft.VisualBasic;    // ADD 2009/06/05

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

using Broadleaf.Application.Resources;// 2010/06/29 Add

namespace Broadleaf.Windows.Forms
{
	/// <summary>�[���Ǘ��ݒ�(���[�J��DB��p)�N���X</summary>
	/// <remarks> 
	/// <br>note			:	���[�J��DB�݂̂ɕێ�����POS�[���̐ݒ���s���܂��B
	///							IMasterMaintenanceSingleType���������Ă��܂��B</br>              
	/// <br>Programer		:	�É�@���S��</br>                            
	/// <br>Date			:	2007.04.16</br>
    /// <br></br>
    /// <br>UpdateNote      :   2007.06.11  �Éꏬ�S���@���ڒǉ��Ή�</br>
    /// <br></br>
    /// <br>UpdateNote      :   2007.07.03  �Éꏬ�S���@�V�K���ɃG���[�����������Q���C��</br>
    /// <br></br>
    /// <br>UpdateNote      :   2007.07.05  �Éꏬ�S���@���_�������_����[���ݒu���_�ɕύX</br>
    /// </remarks>
    //public class MAPOS09150UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType   // DEL 2009/06/05
    public class MAPOS09150UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType      // ADD 2009/06/05
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel CashRegisterNo_Title;
		private Broadleaf.Library.Windows.Forms.THtmlGenerate tHtmlGenerate1;
        private System.Windows.Forms.Timer Initial_Timer;
        private TNedit CashRegisterNo_tNedit;
        private TComboEditor UseLanguageDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel UseLanguageDivCd_Title;
        private DataSet Bind_DataSet;
        private TEdit tEdit_MachineName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TNedit tNedit_MachineIpAddr1;
        private TNedit tNedit_MachineIpAddr4;
        private TNedit tNedit_MachineIpAddr3;
        private TNedit tNedit_MachineIpAddr2;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private System.ComponentModel.IContainer components;
        private bool _scmFlg = false;    // 2010/06/29 Add
        private ArrayList _serverPosTerminalList = new ArrayList(); // 2010/06/29 Add
		# endregion

		# region Constructor
		/// <summary>MAPOS09150UA�R���X�g���N�^</summary>
		/// <remarks> 
		/// <br>note        :	�[���Ǘ��ݒ�A�N�Z�X�N���X�𐶐����܂��B
		///						�t���[����ʂ̈���{�^����\���ݒ���s���܂��B</br>
		/// <br>Programer   :	�É�@���S��</br>                            
		/// <br>Date        :	2007.04.16</br>                              
		/// </remarks>
		public MAPOS09150UA()
        {
        #if _ADMIN_MODE_
            LoginInfoAcquisition.Employee.UserAdminFlag = 1;    // ���̊Ǘ��Ґݒ�
        #endif

			InitializeComponent();

			// companyInf�N���X�A�N�Z�X�N���X
			this._posTerminalMgAcs = new PosTerminalMgAcs();

			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_���擾
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            # region 2007.07.05  S.Koga  DEL
            //this._sectionGuideName = this.posTerminalMgAcs.GetSecInfo(this._sectionCode);
            # endregion

            // ����\�t���O��ݒ肵�܂��B
			// Frame�̈���{�^���̕\����\���̐���Ɏg�p���܂��B
			_canPrint = false;

            // ADD 2009/06/05 ------>>>
            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �ϐ�������
            this._dataIndex = -1;
            this._totalCount = 0;
            this._posTerminalMgTable = new Hashtable();

            // 2010/06/29 Add >>>
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus scmPs;
            scmPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (scmPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                _scmFlg = true;
            }
            else
            {
                _scmFlg = false;
            }
            // 2010/06/29 Add <<<

            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            {
                // 2010/06/29 SCM�I�v�V�������L���Ȃ�Ǘ��҃��[�h�Ŏ��s Add >>>
                if (_scmFlg == true)
                {
                    // 2010/06/29 Add <<<
                    // �Ǘ��҃��[�h
                    this._canNew = true;
                    this._canDelete = true;
                    this._canClose = true;
                    this._defaultAutoFillToColumn = false;
                    this._canSpecificationSearch = false;
                    this._canLogicalDeleteDataExtraction = true;
                    // 2010/06/29 Add >>>
                }
                else
                {
                    // ��ʃ��[�U�[���[�h
                    this._canNew = false;
                    this._canDelete = false;
                    this._canClose = true;
                    this._defaultAutoFillToColumn = false;
                    this._canSpecificationSearch = false;
                    this._canLogicalDeleteDataExtraction = false;
                }
                // 2010/06/29 Add <<<
            }
            else
            {
                // ��ʃ��[�U�[���[�h
                this._canNew = false;
                this._canDelete = false;
                this._canClose = true;
                this._defaultAutoFillToColumn = false;
                this._canSpecificationSearch = false;
                this._canLogicalDeleteDataExtraction = false;
            }
            
            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ���[�J���}�V�����擾
            GetHostInfo();
            // ADD 2009/06/05 ------<<<
        }
		# endregion

		# region Dispose
		/// <summary>�g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B</summary>
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
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAPOS09150UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CashRegisterNo_Title = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.CashRegisterNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.UseLanguageDivCd_Title = new Infragistics.Win.Misc.UltraLabel();
            this.UseLanguageDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tEdit_MachineName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_MachineIpAddr1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_MachineIpAddr2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_MachineIpAddr3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_MachineIpAddr4 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseLanguageDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MachineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr4)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(142, 196);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 8;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(273, 196);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(120, 34);
            this.Cancel_Button.TabIndex = 9;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 240);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(405, 23);
            this.ultraStatusBar1.TabIndex = 10;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // Mode_Label
            // 
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance9.TextHAlignAsString = "Center";
            appearance9.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance9;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance10;
            this.Mode_Label.Location = new System.Drawing.Point(278, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 6;
            // 
            // CashRegisterNo_Title
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.CashRegisterNo_Title.Appearance = appearance12;
            this.CashRegisterNo_Title.Location = new System.Drawing.Point(12, 62);
            this.CashRegisterNo_Title.Name = "CashRegisterNo_Title";
            this.CashRegisterNo_Title.Size = new System.Drawing.Size(115, 24);
            this.CashRegisterNo_Title.TabIndex = 8;
            this.CashRegisterNo_Title.Text = "�[���ԍ�";
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
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
            // CashRegisterNo_tNedit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.CashRegisterNo_tNedit.ActiveAppearance = appearance3;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.CashRegisterNo_tNedit.Appearance = appearance11;
            this.CashRegisterNo_tNedit.AutoSelect = true;
            this.CashRegisterNo_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CashRegisterNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CashRegisterNo_tNedit.DataText = "";
            this.CashRegisterNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CashRegisterNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CashRegisterNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CashRegisterNo_tNedit.Location = new System.Drawing.Point(133, 62);
            this.CashRegisterNo_tNedit.MaxLength = 3;
            this.CashRegisterNo_tNedit.Name = "CashRegisterNo_tNedit";
            this.CashRegisterNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.CashRegisterNo_tNedit.Size = new System.Drawing.Size(36, 24);
            this.CashRegisterNo_tNedit.TabIndex = 0;
            // 
            // UseLanguageDivCd_Title
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.UseLanguageDivCd_Title.Appearance = appearance13;
            this.UseLanguageDivCd_Title.Location = new System.Drawing.Point(12, 92);
            this.UseLanguageDivCd_Title.Name = "UseLanguageDivCd_Title";
            this.UseLanguageDivCd_Title.Size = new System.Drawing.Size(115, 24);
            this.UseLanguageDivCd_Title.TabIndex = 12;
            this.UseLanguageDivCd_Title.Text = "�g�p����敪";
            // 
            // UseLanguageDivCd_tComboEditor
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.UseLanguageDivCd_tComboEditor.ActiveAppearance = appearance4;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance1.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.UseLanguageDivCd_tComboEditor.Appearance = appearance1;
            this.UseLanguageDivCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UseLanguageDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.UseLanguageDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UseLanguageDivCd_tComboEditor.ItemAppearance = appearance2;
            this.UseLanguageDivCd_tComboEditor.Location = new System.Drawing.Point(133, 92);
            this.UseLanguageDivCd_tComboEditor.Name = "UseLanguageDivCd_tComboEditor";
            this.UseLanguageDivCd_tComboEditor.Size = new System.Drawing.Size(128, 24);
            this.UseLanguageDivCd_tComboEditor.TabIndex = 1;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tEdit_MachineName
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Left";
            this.tEdit_MachineName.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Left";
            this.tEdit_MachineName.Appearance = appearance6;
            this.tEdit_MachineName.AutoSelect = true;
            this.tEdit_MachineName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_MachineName.DataText = "";
            this.tEdit_MachineName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MachineName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 128, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_MachineName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_MachineName.Location = new System.Drawing.Point(133, 153);
            this.tEdit_MachineName.MaxLength = 128;
            this.tEdit_MachineName.Name = "tEdit_MachineName";
            this.tEdit_MachineName.Size = new System.Drawing.Size(190, 24);
            this.tEdit_MachineName.TabIndex = 6;
            // 
            // ultraLabel1
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance24;
            this.ultraLabel1.Location = new System.Drawing.Point(12, 123);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(115, 24);
            this.ultraLabel1.TabIndex = 12;
            this.ultraLabel1.Text = "IP�A�h���X";
            // 
            // ultraLabel2
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance15;
            this.ultraLabel2.Location = new System.Drawing.Point(12, 153);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(115, 24);
            this.ultraLabel2.TabIndex = 12;
            this.ultraLabel2.Text = "�[����";
            // 
            // tNedit_MachineIpAddr1
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr1.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr1.Appearance = appearance21;
            this.tNedit_MachineIpAddr1.AutoSelect = true;
            this.tNedit_MachineIpAddr1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_MachineIpAddr1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MachineIpAddr1.DataText = "";
            this.tNedit_MachineIpAddr1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MachineIpAddr1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MachineIpAddr1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MachineIpAddr1.Location = new System.Drawing.Point(133, 123);
            this.tNedit_MachineIpAddr1.MaxLength = 3;
            this.tNedit_MachineIpAddr1.Name = "tNedit_MachineIpAddr1";
            this.tNedit_MachineIpAddr1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MachineIpAddr1.Size = new System.Drawing.Size(36, 24);
            this.tNedit_MachineIpAddr1.TabIndex = 2;
            this.tNedit_MachineIpAddr1.ValueChanged += new System.EventHandler(this.tNedit_MachineIpAddr1_ValueChanged);
            // 
            // tNedit_MachineIpAddr2
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr2.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr2.Appearance = appearance19;
            this.tNedit_MachineIpAddr2.AutoSelect = true;
            this.tNedit_MachineIpAddr2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_MachineIpAddr2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MachineIpAddr2.DataText = "";
            this.tNedit_MachineIpAddr2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MachineIpAddr2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MachineIpAddr2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MachineIpAddr2.Location = new System.Drawing.Point(185, 123);
            this.tNedit_MachineIpAddr2.MaxLength = 3;
            this.tNedit_MachineIpAddr2.Name = "tNedit_MachineIpAddr2";
            this.tNedit_MachineIpAddr2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MachineIpAddr2.Size = new System.Drawing.Size(36, 24);
            this.tNedit_MachineIpAddr2.TabIndex = 3;
            this.tNedit_MachineIpAddr2.ValueChanged += new System.EventHandler(this.tNedit_MachineIpAddr2_ValueChanged);
            // 
            // tNedit_MachineIpAddr3
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr3.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr3.Appearance = appearance17;
            this.tNedit_MachineIpAddr3.AutoSelect = true;
            this.tNedit_MachineIpAddr3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_MachineIpAddr3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MachineIpAddr3.DataText = "";
            this.tNedit_MachineIpAddr3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MachineIpAddr3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MachineIpAddr3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MachineIpAddr3.Location = new System.Drawing.Point(237, 123);
            this.tNedit_MachineIpAddr3.MaxLength = 3;
            this.tNedit_MachineIpAddr3.Name = "tNedit_MachineIpAddr3";
            this.tNedit_MachineIpAddr3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MachineIpAddr3.Size = new System.Drawing.Size(36, 24);
            this.tNedit_MachineIpAddr3.TabIndex = 4;
            this.tNedit_MachineIpAddr3.ValueChanged += new System.EventHandler(this.tNedit_MachineIpAddr3_ValueChanged);
            // 
            // tNedit_MachineIpAddr4
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr4.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.tNedit_MachineIpAddr4.Appearance = appearance8;
            this.tNedit_MachineIpAddr4.AutoSelect = true;
            this.tNedit_MachineIpAddr4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_MachineIpAddr4.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MachineIpAddr4.DataText = "";
            this.tNedit_MachineIpAddr4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MachineIpAddr4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MachineIpAddr4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MachineIpAddr4.Location = new System.Drawing.Point(288, 123);
            this.tNedit_MachineIpAddr4.MaxLength = 3;
            this.tNedit_MachineIpAddr4.Name = "tNedit_MachineIpAddr4";
            this.tNedit_MachineIpAddr4.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MachineIpAddr4.Size = new System.Drawing.Size(36, 24);
            this.tNedit_MachineIpAddr4.TabIndex = 5;
            this.tNedit_MachineIpAddr4.ValueChanged += new System.EventHandler(this.tNedit_MachineIpAddr4_ValueChanged);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(142, 196);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 8;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(13, 196);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 7;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // ultraLabel3
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance23;
            this.ultraLabel3.Location = new System.Drawing.Point(170, 128);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(14, 24);
            this.ultraLabel3.TabIndex = 12;
            this.ultraLabel3.Text = ".";
            // 
            // ultraLabel4
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance22;
            this.ultraLabel4.Location = new System.Drawing.Point(222, 128);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(14, 24);
            this.ultraLabel4.TabIndex = 12;
            this.ultraLabel4.Text = ".";
            // 
            // ultraLabel5
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance14;
            this.ultraLabel5.Location = new System.Drawing.Point(273, 128);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(14, 24);
            this.ultraLabel5.TabIndex = 12;
            this.ultraLabel5.Text = ".";
            // 
            // MAPOS09150UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(405, 263);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.tEdit_MachineName);
            this.Controls.Add(this.UseLanguageDivCd_tComboEditor);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.UseLanguageDivCd_Title);
            this.Controls.Add(this.tNedit_MachineIpAddr4);
            this.Controls.Add(this.tNedit_MachineIpAddr3);
            this.Controls.Add(this.tNedit_MachineIpAddr2);
            this.Controls.Add(this.tNedit_MachineIpAddr1);
            this.Controls.Add(this.CashRegisterNo_tNedit);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CashRegisterNo_Title);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAPOS09150UA";
            this.Text = "�[���Ǘ��ݒ�";
            this.Load += new System.EventHandler(this.MAPOS09150UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAPOS09150UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAPOS09150UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.CashRegisterNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseLanguageDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MachineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MachineIpAddr4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>
		/// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
		/// </remarks>
        //public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;    // DEL 2009/06/05
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;       // ADD 2009/06/05
		# endregion

		#region Private Members
        //private PosTerminalMg posTerminalMg;  // DEL 2009/06/05
		private PosTerminalMgAcs _posTerminalMgAcs;
		private string _enterpriseCode;
        private string _sectionCode;
        # region 2007.07.05  S.Koga  DEL
        //private string _sectionGuideName;
        # endregion

        //��r�pclone
        private PosTerminalMg _posTerminalMgClone;

        // ADD 2009/06/05 ------>>>
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private int _totalCount;
        private Hashtable _posTerminalMgTable;
        // ADD 2009/06/05 ------<<<
        
        // �v���p�e�B�p
		private bool _canPrint;
		/// <summary>�I���v���p�e�B</summary>
		/// <remarks>
		/// �A�Z���u�����I�����邩�A���Ȃ������擾���̓Z�b�g���܂��B
		/// </remarks>
		private bool _canClose;

        // ADD 2009/06/05 ------>>>
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        // �z�X�g��
        string _hostName = ""; 
        // IP�A�h���X
        IPAddress _address = null;
        // ADD 2009/06/05 ------<<<
        
        // ���C���t���[���O���b�h�p�\�����ڃ^�C�g��
        private const string HTML_HEADER_TITLE = "�ݒ荀��";
		private const string HTML_HEADER_VALUE = "�ݒ�l";
		private const string HTML_UNREGISTER = "���ݒ�";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

        // 2007.06.11  S.Koga  ADD --------------------------------------------
        // POS/PC�[���敪
        private const string POSPCTERM_1 = "POS�[���g�p";
        private const string POSPCTERM_2 = "PC�[���g�p";
        // --------------------------------------------------------------------

        //--- ADD 2008/06/18 ---------->>>>>
        private const string USELANGUAGEDIV_1 = "���{��";
        private const string USELANGUAGEDIV_2 = "�p��";
        private const string USELANGUAGEDIV_3 = "���V�A��";
        private const string USELANGUAGEDIV_4 = "������";
        private const string USELANGUAGEDIV_5 = "�A���r�A��";

        private const string USELANGUAGEDIVCD_1 = "ja";
        private const string USELANGUAGEDIVCD_2 = "en";
        private const string USELANGUAGEDIVCD_3 = "ru";
        private const string USELANGUAGEDIVCD_4 = "zh-CN";
        private const string USELANGUAGEDIVCD_5 = "ar";

        private const string USECULTUREDIVCD_1 = "ja-JP";
        private const string USECULTUREDIVCD_2 = "en-US";
        private const string USECULTUREDIVCD_3 = "ru-RU";
        private const string USECULTUREDIVCD_4 = "zh-CN";
        private const string USECULTUREDIVCD_5 = "ar-AE";
        //--- ADD 2008/06/18 ----------<<<<<

        // ADD 2009/06/05 ------>>>
        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

        private const string PROGRAM_ID = "MAPOS09150U";    // �v���O����ID

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";

        private const string VIEW_CASH_REGISTER_NO_TITLE = "�[���ԍ�";
        private const string VIEW_USE_LANGUAGE_DIV_CD_TITLE = "�g�p����敪";
        private const string VIEW_MACHINE_IP_ADDR_TITLE = "IP�A�h���X";
        private const string VIEW_MACHINE_NAME_TITLE = "�[����";
        private const string VIEW_GUID_KEY_TITLE = "Guid";
        // ADD 2009/06/05 ------<<<
        
        #endregion

		# region Main
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new MAPOS09150UA());
		}
		# endregion

		# region Properties
		/// <summary>����v���p�e�B</summary>
		/// <remarks>
		/// ����\���ǂ����̐ݒ���擾���܂��B�ifalse�Œ�j
		/// </remarks>
		public bool CanPrint
		{
			get{ return _canPrint; }
		}

		/// <summary>��ʃN���[�Y�v���p�e�B</summary>
		/// <remarks>
		/// ��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B
		/// false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B
		/// </remarks>
		public bool CanClose
		{
			get{ return _canClose; }
			set{ _canClose = value; }
		}

        // ADD 2009/06/05 ------>>>
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
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

        /*----------------------------------------------------------------------------------*/
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

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        // ADD 2009/06/05 ------<<<
        
		# endregion

		# region Public Methods
		/// <summary>�������</summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note			:	�i�������j</br>
		/// <br>Programmer		:	�É�@���S��</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

        // DEL 2009/06/05 ------>>>
        ///// <summary>HTML�R�[�h�擾����</summary>
        ///// <returns>HTML�R�[�h</returns>
        ///// <remarks>
        ///// <br>Note			:	�r���[�p�̂g�s�l�k�R�[�h���擾���܂��B</br>
        ///// <br>Programmer		:	�É�@���S��</br>
        ///// <br>Date			:	2007.04.16</br>
        ///// </remarks>
        //public string GetHtmlCode()
        //{
        //    string outCode = "";

        //    // tHtmlGenerate���i�̈����𐶐�����
        //    // 2007.06.11  S.Koga  amend --------------------------------------
        //    //string [,] array = new string[3,2];
        //    //string[,] array = new string[4, 2];       // DEL 2008/06/18
        //    string[,] array = new string[3, 2];         // ADD 2008/06/18
        //    // ----------------------------------------------------------------
			
        //    this.tHtmlGenerate1.Coltypes = new int[2];

        //    this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
        //    this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
				
        //    array[0,0] = HTML_HEADER_TITLE; //�u�ݒ荀�ځv
        //    array[0,1] = HTML_HEADER_VALUE; //�u�ݒ�l�v

        //    //array[1,0] = this.Section_Title.Text;            //���_       // DEL 2008/06/18
        //    //array[2, 0] = this.CashRegisterNo_Title.Text;    //���W�ԍ�   // DEL 2008/06/18
        //    array[1, 0] = this.CashRegisterNo_Title.Text;    //�[���ԍ�     // ADD 2008/06/18
        //    // 2007.06.11  S.Koga  ADD ----------------------------------------
        //    //array[3, 0] = this.PosPCTerm_Title.Text;        // POS/PC�[���敪     // DEL 2008/06/18
        //    // ----------------------------------------------------------------

        //    array[2, 0] = this.UseLanguageDivCd_Title.Text;   // �g�p����敪       // ADD 2008/06/18

        //    // ���W�ԍ��擾
        //    int status = this.posTerminalMgAcs.Search(out this.posTerminalMg, this._enterpriseCode);

        //    if (status == 0)
        //    {
        //        // 2007.07.05  S.Koga  AMEND ----------------------------------
        //        // ���_
        //        //if (!this._sectionGuideName.Equals(""))
        //        //{
        //        //    array[1, 1] = this._sectionGuideName;
        //        //}
        //        //else
        //        //{
        //        //    array[1, 1] = HTML_UNREGISTER;
        //        //}
        //        // �[���ݒu���_
        //        //array[1, 1] = GetSectionName(posTerminalMg.SectionCode);      // DEL 2008/06/18
        //        // ------------------------------------------------------------

        //        // �[���ԍ�
        //        //array[2, 1] = posTerminalMg.CashRegisterNo.ToString();        // DEL 2008/06/18
        //        array[1, 1] = posTerminalMg.CashRegisterNo.ToString();
        //        //--- DEL 2008/06/18 ---------->>>>>
        //        // 2007.06.11  S.Koga  ADD ------------------------------------
        //        // POS/PC�[���敪
        //        //switch (posTerminalMg.PosPCTermCd)
        //        //{
        //        //    case 1: // POS�[���g�p
        //        //        {
        //        //            array[3, 1] = POSPCTERM_1;
        //        //            break;
        //        //        }
        //        //    case 2: // PC�[���g�p
        //        //        {
        //        //            array[3, 1] = POSPCTERM_2;
        //        //            break;
        //        //        }
        //        //    default:
        //        //        {
        //        //            array[3, 1] = HTML_UNREGISTER;
        //        //            break;
        //        //        }
        //        //}
        //        // ------------------------------------------------------------
        //        //--- DEL 2008/06/18 ----------<<<<<
        //        //--- ADD 2008/06/18 ---------->>>>>
        //        if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_1;
        //        }
        //        else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_2;
        //        }
        //        else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_3;
        //        }
        //        else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_4;
        //        }
        //        else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
        //        {
        //            array[2, 1] = USELANGUAGEDIV_5;
        //        }
        //        else
        //        {
        //            array[2, 1] = HTML_UNREGISTER;
        //        }
        //        //--- ADD 2008/06/18 ----------<<<<<
        //    }
        //    else
        //    {
        //        // 2007.07.05  S.Koga  AMEND ----------------------------------
        //        // �� �o�^�f�[�^���Ȃ��ꍇ�̒[���ݒu���_�̃t���[����\����"���ݒ�"�Ƃ��܂��B
        //        // ------------------------------------------------------------
        //        //if (!this._sectionGuideName.Equals(""))
        //        //{
        //        //    array[1, 1] = this._sectionGuideName;
        //        //}
        //        //else
        //        //{
        //        //    array[1, 1] = HTML_UNREGISTER;
        //        //}
        //        array[1, 1] = HTML_UNREGISTER;
        //        // ------------------------------------------------------------
        //        array[2, 1] = HTML_UNREGISTER;
        //        // 2007.06.11  S.Koga  ADD ------------------------------------
        //        //array[3, 1] = HTML_UNREGISTER;        // DEL 2008/06/18
        //        // ------------------------------------------------------------
        //    }

        //    this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);
        //    return outCode;
        //}
        // DEL 2009/06/05 ------<<<
		
        // ADD 2009/06/05 ------>>>
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
        ///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._posTerminalMgTable.Clear();

            // �S����
            status = this._posTerminalMgAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 2010/06/29 Add >>>
                        status = this._posTerminalMgAcs.SearchServer(out _serverPosTerminalList, this._enterpriseCode);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                // 2010/06/29 Add <<<
                                int index = 0;
                                // ��L�ȊO�́A�������ʂ�W�J
                                foreach (PosTerminalMg posTerminalMg in retList)
                                {
                                    // �[���Ǘ��ݒ�̃f�[�^�Z�b�g�W�J����
                                    PosTerminalMgToDataSet(posTerminalMg.Clone(), index);
                                    ++index;
                                }

                                break;
                            // 2010/06/29 Add >>>
                            default:
                                {
                                    TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                                        PROGRAM_ID,							    // �A�Z���u��ID
                                        this.Text,              �@�@            // �v���O��������
                                        "Search",                               // ��������
                                        TMsgDisp.OPE_GET,                       // �I�y���[�V����
                                        "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                                        status,									// �X�e�[�^�X�l
                                        this._posTerminalMgAcs,					// �G���[�����������I�u�W�F�N�g
                                        MessageBoxButtons.OK,					// �\������{�^��
                                        MessageBoxDefaultButton.Button1);		// �����\���{�^��

                                    break;
                                }
                        }
                        break;
                        // 2010/06/29 Add <<<
                    }

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }

                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            PROGRAM_ID,							    // �A�Z���u��ID
                            this.Text,              �@�@            // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._posTerminalMgAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 9;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            PosTerminalMg posTerminalMg = (PosTerminalMg)this._posTerminalMgTable[guid];

            int status;

            // �[���Ǘ��ݒ���̘_���폜����
            status = this._posTerminalMgAcs.LogicalDelete(ref posTerminalMg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._posTerminalMgAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // �[���Ǘ��ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            PosTerminalMgToDataSet(posTerminalMg.Clone(), this.DataIndex);

            return status;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // �[���ԍ�
            appearanceTable.Add(VIEW_CASH_REGISTER_NO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000", Color.Black));
            // �g�p����敪
            appearanceTable.Add(VIEW_USE_LANGUAGE_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // IP�A�h���X
            appearanceTable.Add(VIEW_MACHINE_IP_ADDR_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �[����
            appearanceTable.Add(VIEW_MACHINE_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        // ADD 2009/06/05 ------<<<
        
		# endregion

		# region private Methods

        /// <summary>���_�K�C�h���̎擾����</summary>
        /// <param name="sectioncode">���_�R�[�h</param>
        /// <returns>�w�肳�ꂽ���_�R�[�h�̋��_�K�C�h����</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�R�[�h�̃K�C�h���̂��擾���܂��B</br>
        /// <br>            : �K�C�h���̂����݂��Ȃ��ꍇ��"���ݒ�"��Ԃ��܂��B</br>
        /// <br>Programmer  : 20031 �É�@���S��</br>
        /// <br>Date        : 2007.07.05</br>
        /// </remarks>
        private string GetSectionName(string sectioncode)
        {
            string sectionname = "";

            if (!this._posTerminalMgAcs.GetSectionName(out sectionname, sectioncode))
                sectionname = HTML_UNREGISTER;

            return sectionname;
        }

		/// <summary>��ʏ����ݒ菈��</summary>
		/// <remarks>
		/// <br>Note			:	��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer		:	�É�@���S��</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // 2007.07.05  S.Koga  AMEND --------------------------------------
            //// ���_�R�[�h
            //this.SectionCode_tEdit.Clear();
            //// ���_����
            //this.SectionGuideNm_tEdit.Clear();
            //--- DEL 2008/06/18 ---------->>>>>
            //// �[���ݒu���_
            //this.Section_tComboEditor.Items.Clear();              // DEL 2008/06/18
            //Hashtable sectionList = this.posTerminalMgAcs.GetSecInfoList();
            //ArrayList keys = new ArrayList();
            //foreach (string key in sectionList.Keys)
            //    keys.Add(key);
            //for (int count = 0; count < sectionList.Count; count++)
            //{
            //    string sectioncode = keys[count].ToString();
            //    this.Section_tComboEditor.Items.Add(sectioncode, sectionList[sectioncode].ToString());
            //}
            //this.Section_tComboEditor.SelectedIndex = -1;
            //--- DEL 2008/06/18 ----------<<<<<
            
            // ----------------------------------------------------------------
            // �[���ԍ�
            this.CashRegisterNo_tNedit.Clear();
            //--- DEL 2008/06/18 ---------->>>>>
            // POS/PC�[���敪
            //this.PosPCTerm_tComboEditor.Items.Clear();
            //this.PosPCTerm_tComboEditor.Items.Add(0, " ");
            //this.PosPCTerm_tComboEditor.Items.Add(1, POSPCTERM_1);
            //this.PosPCTerm_tComboEditor.Items.Add(2, POSPCTERM_2);
            //this.PosPCTerm_tComboEditor.SelectedIndex = 0;
            //--- DEL 2008/06/18 ----------<<<<<

            //--- ADD 2008/06/18 ---------->>>>>
            // �g�p����敪
            this.UseLanguageDivCd_tComboEditor.Items.Clear();
            this.UseLanguageDivCd_tComboEditor.Items.Add(0, USELANGUAGEDIV_1);
            this.UseLanguageDivCd_tComboEditor.Items.Add(1, USELANGUAGEDIV_2);
            this.UseLanguageDivCd_tComboEditor.Items.Add(2, USELANGUAGEDIV_3);
            this.UseLanguageDivCd_tComboEditor.Items.Add(3, USELANGUAGEDIV_4);
            this.UseLanguageDivCd_tComboEditor.Items.Add(4, USELANGUAGEDIV_5);
            //--- ADD 2008/06/18 ----------<<<<<

        }

        ///// <summary>��ʏ��|�[���Ǘ��ݒ�N���X�i�[����</summary>
        ///// <remarks>
        ///// <br>Note			:	��ʏ�񂩂�[���Ǘ��ݒ�N���X�Ƀf�[�^��
        /////							�i�[���܂��B</br>
        ///// <br>Programmer		:	�É�@���S��</br>
        ///// <br>Date			:	2007.04.16</br>
        ///// </remarks>
        //private void ScreenToPosTerminalMg()
        //{
        //    // �V�K�̏ꍇ
        //    posTerminalMg = new PosTerminalMg();
			
        //    //�w�b�_��
        //    this.posTerminalMg.EnterpriseCode = this._enterpriseCode;

        //    // 2007.07.05  S.Koga  AMEND --------------------------------------
        //    // ���_�R�[�h
        //    //this.posTerminalMg.SectionCode    = this.SectionCode_tEdit.Text;

        //    //--- DEL 2008/06/18 ---------->>>>>
        //    //// �[���ݒu���_
        //    //if(this.Section_tComboEditor.SelectedItem != null)
        //    //    this.posTerminalMg.SectionCode = this.Section_tComboEditor.SelectedItem.DataValue.ToString();
        //    //// ----------------------------------------------------------------
        //    //--- DEL 2008/06/18 ----------<<<<<

        //    // �[���ԍ�
        //    this.posTerminalMg.CashRegisterNo = this.CashRegisterNo_tNedit.GetInt();

        //    //--- DEL 2008/06/18 ---------->>>>>
        //    //// POS/PC�[���敪
        //    //if(this.PosPCTerm_tComboEditor.SelectedItem != null)
        //    //    this.posTerminalMg.PosPCTermCd = (int)this.PosPCTerm_tComboEditor.SelectedItem.DataValue;
        //    //--- DEL 2008/06/18 ----------<<<<<

        //    //--- ADD 2008/06/18 ---------->>>>>
        //    // �g�p����敪
        //    if (this.UseLanguageDivCd_tComboEditor.SelectedItem != null)
        //    {
        //        if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_1)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_1;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_1;
        //        }
        //        else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_2)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_2;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_2;
        //        }
        //        else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_3)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_3;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_3;
        //        }
        //        else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_4)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_4;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_4;
        //        }
        //        else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_5)
        //        {
        //            this.posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_5;
        //            this.posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_5;
        //        }
        //    }
        //    //--- ADD 2008/06/18 ----------<<<<<

        //}

		/// <summary>��ʏ��|�[���Ǘ��ݒ�N���X�i�[����(�ۑ��m�F���b�Z�[�W�p)</summary>
		/// <param name="posTerminalMg">�[���Ǘ��ݒ�N���X</param>
		/// <remarks>
		/// <br>Note			:	��ʏ�񂩂�[���Ǘ��ݒ�N���X�Ƀf�[�^��
		///							�i�[���܂��B</br>
		/// <br>Programmer		:	�É�@���S��</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
        private void DispToPosTerminalMg(ref PosTerminalMg posTerminalMg)
        {
            if (posTerminalMg == null)
            {
                // �V�K�̏ꍇ
                posTerminalMg = new PosTerminalMg();
            }
            
            //�w�b�_��
            posTerminalMg.EnterpriseCode = this._enterpriseCode;

            //���ו�
            // 2007.07.05  S.Koga  AMEND --------------------------------------
            // ���_�R�[�h
            //posTerminalMg.SectionCode = this.SectionCode_tEdit.Text;
            //--- DEL 2008/06/18 ---------->>>>>
            //// �[���ݒu���_
            //if (this.Section_tComboEditor.SelectedItem != null)
            //    posTerminalMg.SectionCode = this.Section_tComboEditor.SelectedItem.DataValue.ToString();
            //// ----------------------------------------------------------------
            //--- DEL 2008/06/18 ----------<<<<<
            posTerminalMg.CashRegisterNo = this.CashRegisterNo_tNedit.GetInt();
            //--- DEL 2008/06/18 ---------->>>>>
            //// POS/PC�[���敪
            //if (this.PosPCTerm_tComboEditor.SelectedItem != null)
            //    posTerminalMg.PosPCTermCd = (int)this.PosPCTerm_tComboEditor.SelectedItem.DataValue;
            //--- DEL 2008/06/18 ----------<<<<<
            // DEL 2009/06/09 ------>>>
            //--- ADD 2008/06/18 ---------->>>>>
            //// �g�p����敪
            //if (this.UseLanguageDivCd_tComboEditor.SelectedItem != null)
            //    posTerminalMg.UseLanguageDivCd = this.UseLanguageDivCd_tComboEditor.SelectedItem.DataValue.ToString();
            //--- ADD 2008/06/18 ----------<<<<<
            // DEL 2009/06/09 ------<<<

            // ADD 2009/06/09 ------>>>
            // �g�p����敪
            if (this.UseLanguageDivCd_tComboEditor.SelectedItem != null)
            {
                if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_1)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_1;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_1;
                }
                else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_2)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_2;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_2;
                }
                else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_3)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_3;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_3;
                }
                else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_4)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_4;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_4;
                }
                else if (this.UseLanguageDivCd_tComboEditor.SelectedItem.ToString() == USELANGUAGEDIV_5)
                {
                    posTerminalMg.UseLanguageDivCd = USELANGUAGEDIVCD_5;
                    posTerminalMg.UseCultureDivCd = USECULTUREDIVCD_5;
                }
            }
            // ADD 2009/06/09 ------<<<

            // ADD 2009/06/05 ------>>>
            // IP�A�h���X
            string ipaddres = string.Format("{0}.{1}.{2}.{3}", tNedit_MachineIpAddr1.DataText, tNedit_MachineIpAddr2.DataText, tNedit_MachineIpAddr3.DataText, tNedit_MachineIpAddr4.DataText);
            posTerminalMg.MachineIpAddr = ipaddres;
            // �[������
            posTerminalMg.MachineName = tEdit_MachineName.Text;
            // ADD 2009/06/05 ------<<<
        }	

        ///// <summary>��ʓW�J����</summary>
        ///// <remarks>
        ///// <br>Note			:	�[���Ǘ��ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
        ///// <br>Programmer		:	�É�@���S��</br>
        ///// <br>Date			:	2007.04.16</br>
        ///// </remarks>
        //private void companyInfToScreen()
        //{
        //    # region 2007.07.05  S.Koga  DEL
        //    //this.SectionCode_tEdit.Text = this._sectionCode;
        //    //this.SectionGuideNm_tEdit.Text = this._sectionGuideName;
        //    # endregion
        //    if (posTerminalMg != null)
        //    {
        //        // 2007.07.05  S.Koga  ADD ------------------------------------
        //        //this.Section_tComboEditor.Value = this.posTerminalMg.SectionCode;                 // DEL 2008/06/18
        //        // ------------------------------------------------------------
        //        this.CashRegisterNo_tNedit.SetInt(this.posTerminalMg.CashRegisterNo);
        //        //this.PosPCTerm_tComboEditor.Value = this.posTerminalMg.PosPCTermCd;               // DEL 2008/06/18

        //        //--- ADD 2008/06/18 ---------->>>>>
        //        if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_1;
        //        }
        //        else if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_2;
        //        }
        //        else if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_3;
        //        }
        //        else if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_4;
        //        }
        //        else if (this.posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_5;
        //        }
        //        else
        //        {
        //            this.UseLanguageDivCd_tComboEditor.Text = null;
        //        }
        //        //--- ADD 2008/06/18 ----------<<<<<
        //    }
        //    // 2007.07.05  S.Koga  ADD ----------------------------------------
        //    //--- DEL 2008/06/18 ---------->>>>>
        //    //else
        //    //    this.Section_tComboEditor.Value = this._sectionCode;
        //    //--- DEL 2008/06/18 ----------<<<<<
        //    // ----------------------------------------------------------------
        //    //this.PosPCTerm_tComboEditor.Value = this.posTerminalMg.PosPCTermCd;
        //}

		/// <summary>�[���Ǘ��ݒ��ʓW�J����</summary>
		/// <remarks>
		/// <br>Note			:	�[���Ǘ��ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer		:	�É�@���S��</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void ScreenClear()
		{
            // 2007.07.05  S.Koga  AMEND --------------------------------------
            //this.SectionCode_tEdit.Clear();
            //this.SectionGuideNm_tEdit.Clear();
            //this.Section_tComboEditor.SelectedIndex = -1;         // DEL 2008/06/18
            // ----------------------------------------------------------------
            this.CashRegisterNo_tNedit.Clear();
            //this.PosPCTerm_tComboEditor.SelectedIndex = 0;        // DEL 2008/06/18
            this.UseLanguageDivCd_tComboEditor.SelectedIndex = -1;  // ADD 2008/06/18

            // ADD 2009/06/05 ------>>>
            this.tNedit_MachineIpAddr1.Clear();
            this.tNedit_MachineIpAddr2.Clear();
            this.tNedit_MachineIpAddr3.Clear();
            this.tNedit_MachineIpAddr4.Clear();
            this.tEdit_MachineName.Clear();
            // ADD 2009/06/05 ------<<<
		}

        /// <summary>��ʃ`�F�b�N����</summary>
		/// <param name="control">�R���g���[��</param>
		/// <param name="checkMessage">���b�Z�[�W</param>
		/// <returns>true:����@false:�ُ�</returns>
		/// <remarks>
		/// <br>Note		:	��ʓ��̓f�[�^�̃`�F�b�N���ʂ�ԋp���܂��B</br>
		/// <br>Programer	:	�É�@���S��</br>
		/// <br>Date		:	2007.04.16</br>
		/// </remarks>
		private bool CheckInputData(ref Control control,ref string checkMessage)
		{
            //--- DEL 2008/06/18 ---------->>>>>
            //// 2007.07.05  S.Koga  ADD ----------------------------------------
            //// �[���ݒu���_
            //if (this.Section_tComboEditor.SelectedItem == null)
            //{
            //    control = this.Section_tComboEditor;
            //    checkMessage = this.Section_Title.Text + "��I�����ĉ������B";
            //    return false;
            //}
            //--- DEL 2008/06/18 ----------<<<<<

            // ----------------------------------------------------------------
		    // ����`���R�[�h
            if (this.CashRegisterNo_tNedit.Text == "0" || this.CashRegisterNo_tNedit.Text == "")
            {
                control = this.CashRegisterNo_tNedit;
                checkMessage = this.CashRegisterNo_Title.Text + "����͂��ĉ������B";
                return false;
            }
            // ADD 2009/06/05 ------>>>
            else
            {
                if ((this._posTerminalMgClone.CashRegisterNo != 0) &&
                    (this.CashRegisterNo_tNedit.GetInt() != this._posTerminalMgClone.CashRegisterNo))
                {
                    // �[���ԍ����ύX���ꂽ�ꍇ�A�T�[�o�[�̓o�^�ςݒ[���ԍ��Əd�����Ȃ����`�F�b�N
                    PosTerminalMg readPosTerminalMg;
                    int status = this._posTerminalMgAcs.Read(out readPosTerminalMg, this._enterpriseCode, this.CashRegisterNo_tNedit.GetInt());
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (readPosTerminalMg != null))
                    {
                        control = this.CashRegisterNo_tNedit;
                        checkMessage = string.Format("{0}:�y{1}�z�͑��̒[���Ŏg�p���̂��߁A\n�ʂ�{2}��ݒ肵�ĉ������B", this.CashRegisterNo_Title.Text, this.CashRegisterNo_tNedit.GetInt(), this.CashRegisterNo_Title.Text);
                        return false;
                    }
                }
            }
            // ADD 2009/06/05 ------<<<
            
            //--- DEL 2008/06/18 ---------->>>>>
            //// POS/PC�[���敪
            //if((this.PosPCTerm_tComboEditor.SelectedItem == null) || ((int)this.PosPCTerm_tComboEditor.SelectedItem.DataValue == 0)){
            //    control = this.PosPCTerm_tComboEditor;
            //    checkMessage = this.PosPCTerm_Title.Text + "��I�����ĉ������B";
            //    return false;
            //}
            //--- DEL 2008/06/18 ----------<<<<<

            //--- ADD 2008/06/18 ---------->>>>>
            // �g�p����敪
            if (this.UseLanguageDivCd_tComboEditor.SelectedItem == null)
            {
                control = this.UseLanguageDivCd_tComboEditor;
                checkMessage = this.UseLanguageDivCd_Title.Text + "��I�����ĉ������B";
                return false;
            }
            //--- ADD 2008/06/18 ----------<<<<<

            // ADD 2009/06/05 ------>>>
            // 2010/06/29 >>>
            //if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1 && _scmFlg == true)
            // 2010/06/29 <<<
            {
                // IP�A�h���X
                if (tNedit_MachineIpAddr1.DataText == "")
                {
                    control = this.tNedit_MachineIpAddr1;
                    checkMessage = this.ultraLabel1.Text + "��ݒ肵�ĉ������B";
                    return false;
                }
                else if (tNedit_MachineIpAddr2.DataText == "")
                {
                    control = this.tNedit_MachineIpAddr2;
                    checkMessage = this.ultraLabel1.Text + "��ݒ肵�ĉ������B";
                    return false;
                }
                else if (tNedit_MachineIpAddr3.DataText == "")
                {
                    control = this.tNedit_MachineIpAddr3;
                    checkMessage = this.ultraLabel1.Text + "��ݒ肵�ĉ������B";
                    return false;
                }
                else if (tNedit_MachineIpAddr4.DataText == "")
                {
                    control = this.tNedit_MachineIpAddr4;
                    checkMessage = this.ultraLabel1.Text + "��ݒ肵�ĉ������B";
                    return false;
                }

                if (tNedit_MachineIpAddr1.GetInt() > 255)
                {
                    control = this.tNedit_MachineIpAddr1;
                    checkMessage = this.ultraLabel1.Text + "�́y0.0.0.0�z�`�y255.255.255.255�z��\n�͈͂Őݒ肵�ĉ������B";
                    return false;
                }
                else if (tNedit_MachineIpAddr2.GetInt() > 255)
                {
                    control = this.tNedit_MachineIpAddr2;
                    checkMessage = this.ultraLabel1.Text + "�́y0.0.0.0�z�`�y255.255.255.255�z��\n�͈͂Őݒ肵�ĉ������B";
                    return false;
                }
                else if (tNedit_MachineIpAddr3.GetInt() > 255)
                {
                    control = this.tNedit_MachineIpAddr3;
                    checkMessage = this.ultraLabel1.Text + "�́y0.0.0.0�z�`�y255.255.255.255�z��\n�͈͂Őݒ肵�ĉ������B";
                    return false;
                }
                else if (tNedit_MachineIpAddr4.GetInt() > 255)
                {
                    control = this.tNedit_MachineIpAddr4;
                    checkMessage = this.ultraLabel1.Text + "�́y0.0.0.0�z�`�y255.255.255.255�z��\n�͈͂Őݒ肵�ĉ������B";
                    return false;
                }

                // �[������
                if (tEdit_MachineName.DataText == "")
                {
                    control = this.tEdit_MachineName;
                    checkMessage = this.ultraLabel2.Text + "��ݒ肵�ĉ������B";
                    return false;
                }
            }
            // ADD 2009/06/05 ------<<<

            return true;
		}
		
		/// <summary>�r������</summary>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.16</br>
		/// </remarks>
        //private void ExclusiveTransaction(int status)
        private void ExclusiveTransaction(int status, bool hide)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// ���[���X�V
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"MAPOS09150U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
                    //this.Hide();
                    if (hide == true)
                    {
                        CloseForm(DialogResult.Cancel);
                    }
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// ���[���폜
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"MAPOS09150U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
                    //this.Hide();
                    if (hide == true)
                    {
                        CloseForm(DialogResult.Cancel);
                    }
					break;
				}
			}
		}

        // ADD 2009/06/05 ------>>>
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable scmTtlStTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B

            scmTtlStTable.Columns.Add(DELETE_DATE, typeof(string));			                // �폜��

            scmTtlStTable.Columns.Add(VIEW_CASH_REGISTER_NO_TITLE, typeof(int));            // �[���ԍ�
            scmTtlStTable.Columns.Add(VIEW_USE_LANGUAGE_DIV_CD_TITLE, typeof(string));      // �g�p����敪
            scmTtlStTable.Columns.Add(VIEW_MACHINE_IP_ADDR_TITLE, typeof(string));          // IP�A�h���X
            scmTtlStTable.Columns.Add(VIEW_MACHINE_NAME_TITLE, typeof(string));             // �[����
            
            scmTtlStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                   // Guid

            this.Bind_DataSet.Tables.Add(scmTtlStTable);
        }

        /// <summary>
        /// �[���Ǘ��ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="posTerminalMg">�[���Ǘ��ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �[���Ǘ��ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PosTerminalMgToDataSet(PosTerminalMg posTerminalMg, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (posTerminalMg.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = posTerminalMg.UpdateDateTimeJpInFormal;
            }

            // �[���ԍ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CASH_REGISTER_NO_TITLE] = posTerminalMg.CashRegisterNo;
            // �g�p����敪
            string useLanguageDivCd = "";
            if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
            {
                useLanguageDivCd = USELANGUAGEDIV_1;
            }
            else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
            {
                useLanguageDivCd = USELANGUAGEDIV_2;
            }
            else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
            {
                useLanguageDivCd = USELANGUAGEDIV_3;
            }
            else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
            {
                useLanguageDivCd = USELANGUAGEDIV_4;
            }
            else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
            {
                useLanguageDivCd = USELANGUAGEDIV_5;
            }
            else
            {
                useLanguageDivCd = HTML_UNREGISTER;
            }
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_USE_LANGUAGE_DIV_CD_TITLE] = useLanguageDivCd;

            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            {
                // 2010/06/29 Add >>>
                if (_scmFlg)
                {
                    // 2010/06/29 Add <<<
                    // �Ǘ��҃��[�h
                    // IP�A�h���X
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_IP_ADDR_TITLE] = posTerminalMg.MachineIpAddr;
                    // �[����
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = posTerminalMg.MachineName;
                    // 2010/06/29 Add >>>
                }
                else
                {
                    // ��ʃ��[�U�[���[�h
                    // IP�A�h���X
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_IP_ADDR_TITLE] = _address.ToString();
                    // �[����
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = _hostName;
                }
                // 2010/06/29 Add <<<
            }
            else
            {
                // ��ʃ��[�U�[���[�h
                // IP�A�h���X
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_IP_ADDR_TITLE] = _address.ToString();
                // �[����
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MACHINE_NAME_TITLE] = _hostName;
            }

            // Guid
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = posTerminalMg.FileHeaderGuid;

            if (this._posTerminalMgTable.ContainsKey(posTerminalMg.FileHeaderGuid) == true)
            {
                this._posTerminalMgTable.Remove(posTerminalMg.FileHeaderGuid);
            }
            this._posTerminalMgTable.Add(posTerminalMg.FileHeaderGuid, posTerminalMg);
        }

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ��r�p�N���[���N���A
            this._posTerminalMgClone = null;

            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.CashRegisterNo_tNedit.Enabled = true;
                        this.UseLanguageDivCd_tComboEditor.Enabled = true;

                        if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
                        {
                            // 2010/06/29 Add SCM�I�v�V�������L���Ȃ�Ǘ��҃��[�h�Ŏ��s >>>
                            if (_scmFlg == true)
                            {
                                // 2010/06/29 Add <<<
                                // �Ǘ��҃��[�h
                                this.tNedit_MachineIpAddr1.Enabled = true;
                                this.tNedit_MachineIpAddr2.Enabled = true;
                                this.tNedit_MachineIpAddr3.Enabled = true;
                                this.tNedit_MachineIpAddr4.Enabled = true;
                                this.tEdit_MachineName.Enabled = true;
                                // 2010/06/29 Add >>>
                            }
                            else
                            {
                                // ��ʃ��[�U�[���[�h
                                this.tNedit_MachineIpAddr1.Enabled = false;
                                this.tNedit_MachineIpAddr2.Enabled = false;
                                this.tNedit_MachineIpAddr3.Enabled = false;
                                this.tNedit_MachineIpAddr4.Enabled = false;
                                this.tEdit_MachineName.Enabled = false;
                            }
                            // 2010/06/29 Add <<<
                        }
                        else
                        {
                            // ��ʃ��[�U�[���[�h
                            this.tNedit_MachineIpAddr1.Enabled = false;
                            this.tNedit_MachineIpAddr2.Enabled = false;
                            this.tNedit_MachineIpAddr3.Enabled = false;
                            this.tNedit_MachineIpAddr4.Enabled = false;
                            this.tEdit_MachineName.Enabled = false;
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.CashRegisterNo_tNedit.Enabled = false;
                        this.UseLanguageDivCd_tComboEditor.Enabled = false;
                        this.tNedit_MachineIpAddr1.Enabled = false;
                        this.tNedit_MachineIpAddr2.Enabled = false;
                        this.tNedit_MachineIpAddr3.Enabled = false;
                        this.tNedit_MachineIpAddr4.Enabled = false;
                        this.tEdit_MachineName.Enabled = false;
                        
                        break;
                    }
            }
        }

        /// <summary>
        /// �[���Ǘ��ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="posTerminalMg">�[���Ǘ��ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �[���Ǘ��ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PosTerminalMgToScreen(PosTerminalMg posTerminalMg)
        {
            // 2010/06/29 Add >>>
            bool serverFlg = false;
            bool adminFlg = false;
            PosTerminalMg serverPosTerminalMg = new PosTerminalMg();
            // Admin�Ń��O�C������SCM�t���O���L���Ȃ�Ǘ��҂Ŏ��s
            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            {
                if (_scmFlg == true)
                {
                    adminFlg = true;
                }
            }
            // ���삵�Ă���[���̒[���Ǘ��ݒ肪USER_AP�ɂ��邩�`�F�b�N
            if (adminFlg == false)
            {
                foreach (PosTerminalMg chkPosTerminalMg in _serverPosTerminalList)
                {
                    if (chkPosTerminalMg.MachineIpAddr == _address.ToString())
                    {
                        serverFlg = true;
                        serverPosTerminalMg = chkPosTerminalMg;
                        break;
                    }
                }
            }
            // �Ǘ��҂ł͂Ȃ��A�ݒ肪USER_AP�ɂ���ꍇ�͏����\����USER_AP�̓��e�ŕ\������B
            if (adminFlg == false && serverFlg == true)
            {
                // �[���ԍ�
                this.CashRegisterNo_tNedit.SetInt(serverPosTerminalMg.CashRegisterNo);

                // �g�p����敪
                if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_1;
                }
                else if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_2;
                }
                else if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_3;
                }
                else if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_4;
                }
                else if (serverPosTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_5;
                }
                else
                {
                    this.UseLanguageDivCd_tComboEditor.Text = null;
                }

                // IP�A�h���X
                string[] parts;
                parts = Strings.Split(serverPosTerminalMg.MachineIpAddr, ".", -1, CompareMethod.Binary);
                if (parts.Length >= 4)
                {
                    this.tNedit_MachineIpAddr1.DataText = parts[0];
                    this.tNedit_MachineIpAddr2.DataText = parts[1];
                    this.tNedit_MachineIpAddr3.DataText = parts[2];
                    this.tNedit_MachineIpAddr4.DataText = parts[3];
                }
                // �[����
                this.tEdit_MachineName.Text = serverPosTerminalMg.MachineName;
            }
            else
            {
                // 2010/06/29 Add <<<
                // �[���ԍ�
                this.CashRegisterNo_tNedit.SetInt(posTerminalMg.CashRegisterNo);

                // �g�p����敪
                if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_1)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_1;
                }
                else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_2)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_2;
                }
                else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_3)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_3;
                }
                else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_4)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_4;
                }
                else if (posTerminalMg.UseLanguageDivCd == USELANGUAGEDIVCD_5)
                {
                    this.UseLanguageDivCd_tComboEditor.Text = USELANGUAGEDIV_5;
                }
                else
                {
                    this.UseLanguageDivCd_tComboEditor.Text = null;
                }

                if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
                {
                    // 2010/06/29 Add SCM�I�v�V�������L���Ȃ�Ǘ��҃��[�h�Ŏ��s >>>
                    if (_scmFlg == true)
                    {
                        // 2010/06/29 Add <<<
                        // �Ǘ��҃��[�h
                        // IP�A�h���X
                        string[] parts;
                        parts = Strings.Split(posTerminalMg.MachineIpAddr, ".", -1, CompareMethod.Binary);
                        if (parts.Length >= 4)
                        {
                            this.tNedit_MachineIpAddr1.DataText = parts[0];
                            this.tNedit_MachineIpAddr2.DataText = parts[1];
                            this.tNedit_MachineIpAddr3.DataText = parts[2];
                            this.tNedit_MachineIpAddr4.DataText = parts[3];
                        }
                        // �[����
                        this.tEdit_MachineName.Text = posTerminalMg.MachineName;
                        // 2010/06/29 Add >>>
                    }
                    else
                    {
                        // ��ʃ��[�U�[���[�h
                        string[] parts;
                        parts = Strings.Split(_address.ToString(), ".", -1, CompareMethod.Binary);
                        if (parts.Length >= 4)
                        {
                            this.tNedit_MachineIpAddr1.DataText = parts[0];
                            this.tNedit_MachineIpAddr2.DataText = parts[1];
                            this.tNedit_MachineIpAddr3.DataText = parts[2];
                            this.tNedit_MachineIpAddr4.DataText = parts[3];
                        }
                        this.tEdit_MachineName.Text = _hostName;
                    }
                    // 2010/06/29 Add <<<
                }
                else
                {
                    // ��ʃ��[�U�[���[�h
                    string[] parts;
                    parts = Strings.Split(_address.ToString(), ".", -1, CompareMethod.Binary);
                    if (parts.Length >= 4)
                    {
                        this.tNedit_MachineIpAddr1.DataText = parts[0];
                        this.tNedit_MachineIpAddr2.DataText = parts[1];
                        this.tNedit_MachineIpAddr3.DataText = parts[2];
                        this.tNedit_MachineIpAddr4.DataText = parts[3];
                    }
                    this.tEdit_MachineName.Text = _hostName;
                }
            }   // 2010/06/29 Add
        }

        /// <summary>
        /// ���[�J���}�V�����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J���}�V�������擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void GetHostInfo()
        {
            // ���[�J���}�V������IP�A�h���X���擾
            _hostName = Dns.GetHostName();


            // DEL 2009/08/11 IP�A�h���X�̓��͐���̕ύX����ђǉ� ---------->>>>>
            //IPAddress[] adrList = Dns.GetHostAddresses(_hostName);
            //foreach (IPAddress address in adrList)
            //{
            //    _address = address;
            //}
            // DEL 2009/08/11 IP�A�h���X�̓��͐���̕ύX����ђǉ� ----------<<<<<
            // ADD 2009/08/11 IP�A�h���X�̓��͐���̕ύX����ђǉ� ---------->>>>>
            // IP�A�h���X���擾
            IPHostEntry ipHostEntry = Dns.GetHostEntry(_hostName);
            foreach (IPAddress ipAddress in ipHostEntry.AddressList)
            {
                if (IsIPv4Address(ipAddress.ToString()))
                {
                    _address = ipAddress;
                    break;
                }
            }
            // ADD 2009/08/11 IP�A�h���X�̓��͐���̕ύX����ђǉ� ----------<<<<<
        }
        // ADD 2009/06/05 ------<<<

		# endregion

		# region Control Events
		/// <summary>Form.Load �C�x���g(MAPOS09150UA)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer		:	�É�@���S��</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void MAPOS09150UA_Load(object sender, System.EventArgs e)
		{
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;

			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;
            // ADD 2009/06/05 ------>>>
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            // ADD 2009/06/05 ------<<<
            
			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            // ADD 2009/06/05 ------>>>
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            // ADD 2009/06/05 ------<<<
            

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

        /// <summary>Control.Click �C�x���g(Ok_Button)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	�ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///							�������܂��B</br>
		/// <br>Programmer		:	�É�@���S��</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			SavePosTerminalMg();
		}

		/// <summary>�ۑ�����(SavePosTerminalMg())</summary>
		/// <remarks>
		/// <br>Note�@�@�@      : �ۑ��������s���܂��B</br>
		/// <br>Programmer		:	�É�@���S��</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void SavePosTerminalMg()
		{

			Control control = null;
			string checkMessage = "";
			bool ret = true;

			//��ʃf�[�^���̓`�F�b�N����
			ret = CheckInputData( ref control ,ref checkMessage );
			if(ret == false )
			{
				// ���̓`�F�b�N
				TMsgDisp.Show( 
					this, 								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
					"MAPOS09150U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
					checkMessage, 						// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.OK );				// �\������{�^��

				control.Focus();
				return;
			}

            // DEL 2009/06/05 ------>>>
            //// ��ʂ���[���Ǘ��ݒ�\���N���X�Ƀf�[�^���Z�b�g���܂��B
            //ScreenToPosTerminalMg();
            // DEL 2009/06/05 ------<<<

            // ADD 2009/06/05 ------>>>
            // �[���Ǘ��ł́A�e�[�u���L�[���ڂ��C���\�̂��߁A
            // �X�V���͊������R�[�h�̍폜���V�K�쐬�Ƃ���
            PosTerminalMg posTerminalMg = null;

            // ��ʏ����擾
            DispToPosTerminalMg(ref posTerminalMg);
            // ADD 2009/06/05 ------<<<

            // ADD 2009/09/24 ���[�����̓o�^�������Ȃ��d�l�Ƃ��� ---------->>>>>
            // ���[�����̓o�^���������ꍇ�̏���
            if (!GetReadyToWrite(posTerminalMg)) return;
            // ADD 2009/09/24 ���[�����̓o�^�������Ȃ��d�l�Ƃ��� ----------<<<<<

			// �[���Ǘ��ݒ�}�X�^�o�^
            //int status = this.posTerminalMgAcs.Write( ref posTerminalMg, this._posTerminalMgClone);   // DEL 2009/06/05
            // ADD 2009/06/05 ------>>>
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this.DataIndex < 0)
            {
                // �V�K
                status = this._posTerminalMgAcs.WriteAll(ref posTerminalMg, null);
            }
            else
            {
                // �X�V
                status = this._posTerminalMgAcs.WriteAll(ref posTerminalMg, this._posTerminalMgClone);
            }
            // ADD 2009/06/05 ------<<<
            
            switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    //ExclusiveTransaction(status);
                    ExclusiveTransaction(status, true);
                    return ;
				}
				default:
				{
					// �o�^���s
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"MAPOS09150U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"�[���Ǘ��ݒ�", 					// �v���O��������
						"SavePosTerminalMg", 				// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._posTerminalMgAcs, 			// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					
					return ;
				}
			}

            // �[���Ǘ��ݒ���N���X�̃f�[�^�Z�b�g�W�J����
			PosTerminalMgToDataSet(posTerminalMg, this.DataIndex);

			DialogResult dialogResult = DialogResult.OK;

			Mode_Label.Text = UPDATE_MODE;

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;    // ADD 2009/06/05

			this._posTerminalMgClone = null;

			this.DialogResult = dialogResult;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
            // 2010/07/01 Add >>>
            // �ۑ���Č�������B
            int totalCount = 0;
            int readCount = 0;
            Search(ref totalCount, readCount);
            // 2010/07/01 Add <<<
		}

		/// <summary>Control.Click �C�x���g(Cancel_Button)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	����{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///							�������܂��B</br>
		/// <br>Programmer		:	�É�@���S��</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            ////�ۑ��m�F
            //PosTerminalMg comparePosTerminalMg = new PosTerminalMg();
            //comparePosTerminalMg = this.posTerminalMg.Clone();   
            ////���݂̉�ʏ����擾����
            //DispToPosTerminalMg(ref comparePosTerminalMg);
            ////�ŏ��Ɏ擾������ʏ��Ɣ�r 
            //if (!(this._posTerminalMgClone.Equals(comparePosTerminalMg)))	
            //{
            //    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������ 
            //    // �ۑ��m�F
            //    DialogResult res = TMsgDisp.Show( 
            //        this, 								// �e�E�B���h�E�t�H�[��
            //        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
            //        "MAPOS09150U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
            //        null, 								// �\�����郁�b�Z�[�W
            //        0, 									// �X�e�[�^�X�l
            //        MessageBoxButtons.YesNoCancel );	// �\������{�^��
            //    switch(res)
            //    {
            //        case DialogResult.Yes:
            //        {
            //            SavePosTerminalMg();
            //            return;
            //        }
            //        case DialogResult.No:
            //        {
            //            break;
            //        }
            //        default:
            //        {
            //            return;
            //        }
            //    }
            //}

            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                PosTerminalMg compareSCMTtlSt = new PosTerminalMg();

                compareSCMTtlSt = this._posTerminalMgClone.Clone();
                DispToPosTerminalMg(ref compareSCMTtlSt);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._posTerminalMgClone.Equals(compareSCMTtlSt))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        PROGRAM_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                SavePosTerminalMg();
                                return;
                            }
                        case DialogResult.No:
                            {
                                // ��ʔ�\���C�x���g
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

			DialogResult dialogResult = DialogResult.Cancel;
            this._indexBuf = -2;    // ADD 2009/06/05

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			this._posTerminalMgClone = null;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>Form.Closing �C�x���g(MAPOS09150UA)</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note			:	�t�H�[�������O�ɁA���[�U�[���t�H�[�����
		///							�悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer		:	�É�@���S��k</br>
		/// <br>Date			:	2007.04.16</br>
		/// </remarks>
		private void MAPOS09150UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._posTerminalMgClone = null;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		/// <summary>���VisibleChange�C�x���g</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MAPOS09150UA_VisibleChanged(object sender, System.EventArgs e)
		{
			
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				return;
			}

			// �f�[�^���Z�b�g����Ă����甲����
			if(this._posTerminalMgClone != null)
			{
				return;
			}

			Initial_Timer.Enabled = true;

			ScreenClear();		
		}

		/// <summary>��ʍč\�z����</summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.16</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            // DEL 2009/06/05 ------>>>
            //// companyInf�N���X
            //this.posTerminalMg = new PosTerminalMg();

            //int status = posTerminalMgAcs.Search(out this.posTerminalMg, this._enterpriseCode);
            //if (status == 0 || status == 9) 
            //{
                
            //    Mode_Label.Text = UPDATE_MODE;

            //    // �S�̏����\���ݒ�N���X��ʓW�J����
            //    companyInfToScreen();

            //    # region 2007.07.05  S.Koga  DEL
            //    //this.SectionCode_tEdit.Enabled = false;
            //    //this.SectionGuideNm_tEdit.Enabled = false;
            //    # endregion

            //    // �����t�H�[�J�X�Z�b�g
            //    // 2007.07.05  S.Koga  AMEND ----------------------------------
            //    //this.CashRegisterNo_tNedit.Focus();
            //    //this.CashRegisterNo_tNedit.SelectAll();
            //    //this.Section_tComboEditor.Focus();            // DEL 2008/06/18
            //    //this.Section_tComboEditor.SelectAll();
            //    // ------------------------------------------------------------

            //    if (this.posTerminalMg == null)
            //    {
            //        this.posTerminalMg = new PosTerminalMg();
            //    }
            //    //�N���[���쐬
            //    this._posTerminalMgClone = this.posTerminalMg.Clone();  
            //    //��ʏ����r�p�N���[���ɃR�s�[����@�@�@�@�@   
            //    DispToPosTerminalMg(ref this._posTerminalMgClone);

            //}
            //else
            //{
            //    // �T�[�`
            //    TMsgDisp.Show( 
            //        this, 									// �e�E�B���h�E�t�H�[��
            //        emErrorLevel.ERR_LEVEL_STOP, 			// �G���[���x��
            //        "MAPOS09150U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
            //        "�[���Ǘ��ݒ�", 						// �v���O��������
            //        "ScreenReconstruction", 				// ��������
            //        TMsgDisp.OPE_READ, 						// �I�y���[�V����
            //        "�[���Ǘ��ݒ�}�X�^�̓ǂݍ��݂Ɏ��s���܂����B", // �\�����郁�b�Z�[�W
            //        status, 								// �X�e�[�^�X�l
            //        this.posTerminalMgAcs, 					// �G���[�����������I�u�W�F�N�g
            //        MessageBoxButtons.OK, 					// �\������{�^��
            //        MessageBoxDefaultButton.Button1 );		// �����\���{�^��
            //    return;
            //}
            // DEL 2009/06/05 ------<<<

            // ADD 2009/06/05 ------>>>
            if (this.DataIndex < 0)
            {
                PosTerminalMg posTerminalMg = new PosTerminalMg();
                //�N���[���쐬
                this._posTerminalMgClone = posTerminalMg.Clone();
                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                DispToPosTerminalMg(ref this._posTerminalMgClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.CashRegisterNo_tNedit.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                PosTerminalMg posTerminalMg = (PosTerminalMg)this._posTerminalMgTable[guid];

                // �[���Ǘ��ݒ�N���X��ʓW�J����
                PosTerminalMgToScreen(posTerminalMg);

                if (posTerminalMg.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    // 2010/06/29 >>>
                    if (string.IsNullOrEmpty(posTerminalMg.MachineIpAddr))
                        this.Mode_Label.Text = INSERT_MODE;
                    else
                    // 2010/06/29 <<<
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.CashRegisterNo_tNedit.Focus();

                    // �N���[���쐬
                    this._posTerminalMgClone = posTerminalMg.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    DispToPosTerminalMg(ref this._posTerminalMgClone);

                    if (LoginInfoAcquisition.Employee.UserAdminFlag != 1)
                    {
                        // 2010/06/29 Del �����ŏ����݂͍s��Ȃ� >>>
                        //// ��ʃ��[�U�[���[�h
                        //// �T�[�o�[�Ɏ��[�����o�^����Ă��邩�m�F
                        //PosTerminalMg readPosTerminalMg;
                        //int status = this._posTerminalMgAcs.Read(out readPosTerminalMg, this._enterpriseCode, this._posTerminalMgClone.CashRegisterNo);
                        //if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                        //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        //{
                        //    // �T�[�o�[�ɓo�^����Ă��Ȃ��ꍇ�͓o�^����
                        //    PosTerminalMg writePosTerminalMg = new PosTerminalMg();
                        //    DispToPosTerminalMg(ref writePosTerminalMg);
                        //    status = this._posTerminalMgAcs.WriteServer(ref writePosTerminalMg, null);
                        //    switch (status)
                        //    {
                        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        //            {
                        //                break;
                        //            }
                        //        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        //        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        //            {
                        //                ExclusiveTransaction(status, true);
                        //                return;
                        //            }
                        //        default:
                        //            {
                        //                // �o�^���s
                        //                TMsgDisp.Show(
                        //                    this, 								// �e�E�B���h�E�t�H�[��
                        //                    emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                        //                    "MAPOS09150U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        //                    "�[���Ǘ��ݒ�", 					// �v���O��������
                        //                    "ScreenReconstruction", 			// ��������
                        //                    TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                        //                    "�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                        //                    status, 							// �X�e�[�^�X�l
                        //                    this._posTerminalMgAcs, 			// �G���[�����������I�u�W�F�N�g
                        //                    MessageBoxButtons.OK, 				// �\������{�^��
                        //                    MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        //                return;
                        //            }
                        //    }
                        //}
                        // 2010/06/29 Del <<<
                    }
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
            // ADD 2009/06/05 ------<<<
        }

		/// <summary>���s�L�[���䏈��</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            // ADD 2009/08/11 IP�A�h���X�̓��͐���̕ύX����ђǉ� ---------->>>>>
            // IP�A�h���X�̒l��␳
            if (e.PrevCtrl == this.tNedit_MachineIpAddr1)
            {
                SetDefaultIPAddressText(this.tNedit_MachineIpAddr1, true);
            }
            else if (e.PrevCtrl == this.tNedit_MachineIpAddr2)
            {
                SetDefaultIPAddressText(this.tNedit_MachineIpAddr2, true);
            }
            else if (e.PrevCtrl == this.tNedit_MachineIpAddr3)
            {
                SetDefaultIPAddressText(this.tNedit_MachineIpAddr3, true);
            }
            else if (e.PrevCtrl == this.tNedit_MachineIpAddr4)
            {
                SetDefaultIPAddressText(this.tNedit_MachineIpAddr4, true);
            }
            // ADD 2009/08/11 IP�A�h���X�̓��͐���̕ύX����ђǉ� ----------<<<<<
		}

		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

        // ADD 2009/06/05 ------>>>
        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            PosTerminalMg posTerminalMg = (PosTerminalMg)this._posTerminalMgTable[guid];

            // ���S�폜����
            int status = this._posTerminalMgAcs.Delete(posTerminalMg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._posTerminalMgTable.Remove(posTerminalMg.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // ���S�폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._posTerminalMgAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
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
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            PosTerminalMg posTerminalMg = ((PosTerminalMg)this._posTerminalMgTable[guid]).Clone();

            // ��������
            status = this._posTerminalMgAcs.Revival(ref posTerminalMg);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �[���Ǘ��ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        PosTerminalMgToDataSet(posTerminalMg, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._posTerminalMgAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }
        // ADD 2009/06/05 ------<<<

        // ADD 2009/08/11 IP�A�h���X�̓��͐���̕ύX����ђǉ� ---------->>>>>
        #region IP�A�h���X

        /// <summary>
        /// IP�A�h���X(1�u���b�N��)��ValueChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tNedit_MachineIpAddr1_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultIPAddressText(this.tNedit_MachineIpAddr1, false);
        }

        /// <summary>
        /// IP�A�h���X(2�u���b�N��)��ValueChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tNedit_MachineIpAddr2_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultIPAddressText(this.tNedit_MachineIpAddr2, false);
        }

        /// <summary>
        /// IP�A�h���X(3�u���b�N��)��ValueChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tNedit_MachineIpAddr3_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultIPAddressText(this.tNedit_MachineIpAddr3, false);
        }

        /// <summary>
        /// IP�A�h���X(4�u���b�N��)��ValueChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tNedit_MachineIpAddr4_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultIPAddressText(this.tNedit_MachineIpAddr4, false);
        }

        /// <summary>
        /// �f�t�H���gIP�A�h���X�e�L�X�g��ݒ肵�܂��B
        /// </summary>
        /// <param name="textBox">�e�L�X�g�{�b�N�X</param>
        /// <param name="emptyIsZero"><c>string.Empty</c>��<c>"0"</c>�ɐݒ肷��t���O</param>
        private static void SetDefaultIPAddressText(
            TNedit textBox,
            bool emptyIsZero
        )
        {
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                if (emptyIsZero) textBox.Text = "0";
                return;
            }

            int ipAddressValue = int.Parse(textBox.Text.Trim());
            if (ipAddressValue > 255)
            {
                textBox.Text = "255";
            }
            else if (ipAddressValue < 0)
            {
                textBox.Text = "0";
            }
        }

        /// <summary>
        /// IPv4�A�h���X�ł��邩���肵�܂��B
        /// </summary>
        /// <param name="ipAddress">IP�A�h���X</param>
        /// <returns>
        /// <c>true</c> :IPv4�A�h���X�ł��B<br/>
        /// <c>false</c>:IPv4�A�h���X�ł͂���܂���B
        /// </returns>
        private static bool IsIPv4Address(string ipAddress)
        {
            // TODO:���Ԃ�A�W���I�Ȕ�����@������Ǝv���܂��B
            string[] ipAddressTokens = ipAddress.Trim().Split('.');
            if (!ipAddressTokens.Length.Equals(4))
            {
                return false;
            }
            foreach (string ipAddressToken in ipAddressTokens)
            {
                int ipAddressNumber = 0;
                if (!int.TryParse(ipAddressToken, out ipAddressNumber))
                {
                    return false;
                }
            }
            return true;
        }

        # endregion // IP�A�h���X
        // ADD 2009/08/11 IP�A�h���X�̓��͐���̕ύX����ђǉ� ----------<<<<<

        // ADD 2009/09/24 ���[�����̓o�^�������Ȃ��d�l�Ƃ��� ---------->>>>>
        #region �����ݑO����

        /// <summary>
        /// �����ޏ��������܂��B
        /// </summary>
        /// <param name="writingRecord">�����ޒ[���Ǘ��ݒ�f�[�^</param>
        /// <returns>
        /// <c>trur</c> :��������<br/>
        /// <c>false</c>:����������
        /// <para>
        /// ���[���������ɓo�^����Ă���ꍇ<br/>
        /// �Ǘ��҃��[�h<br/>
        /// ���b�Z�[�W���\������A<c>false</c>��Ԃ��܂��B<br/>
        /// ��ʃ��[�U�[���[�h<br/>
        /// �Y���f�[�^�����S�폜���A����������I�������ꍇ�A<c>true</c>��Ԃ��܂��B
        /// </para>
        /// </returns>
        private bool GetReadyToWrite(PosTerminalMg writingRecord)
        {
            IList<PosTerminalMg> foundRecordList = FindAllByMachineName(writingRecord.MachineName);
            if (foundRecordList.Count.Equals(0)) return true;   // ���[�����Ȃ�
            if (
                foundRecordList.Count.Equals(1)
                    &&
                foundRecordList[0].CashRegisterNo.Equals(writingRecord.CashRegisterNo)
            ) return true;  // �����ޒ[���Ǘ��ݒ�f�[�^���g

            if (IsAdminMode())
            {
                // ���b�Z�[�W���o��
                string msg = string.Format(
                    "�[�����F{0} �͊��Ƀ}�X�^�ɓo�^����Ă��܂��B\n�Y���f�[�^�����S�폜�̌�A�ēx�A�o�^���Ă��������B",
                    writingRecord.MachineName
                );
                MessageBox.Show(msg, PROGRAM_ID, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tEdit_MachineName.Focus();
                return false;
            }

            // ���S�폜
            foreach (PosTerminalMg deletingRecord in foundRecordList)
            {
                // �����ޒ[���Ǘ��ݒ�f�[�^���g�͖���
                if (deletingRecord.CashRegisterNo.Equals(writingRecord.CashRegisterNo)) continue;

                int status = this._posTerminalMgAcs.Delete(deletingRecord);
                if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    string msg = "���[�����f�[�^�̊��S�폜�Ɏ��s���܂����B";
                    MessageBox.Show(msg, PROGRAM_ID, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �Ǘ��҃��[�h�ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�Ǘ��҃��[�h�ł��B<br/>
        /// <c>false</c>:�Ǘ��҃��[�h�ł͂���܂���B
        /// </returns>
        private static bool IsAdminMode()
        {
            const int USER_ADMIN = 1;
            // 2010/07/01 >>>
            //return LoginInfoAcquisition.Employee.UserAdminFlag.Equals(USER_ADMIN);
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus scmPs;
            scmPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (scmPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract && LoginInfoAcquisition.Employee.UserAdminFlag.Equals(USER_ADMIN))
                return true;
            return false;
            // 2010/07/01 <<<
        }

        /// <summary>
        /// �[�����Ō������܂��B
        /// </summary>
        /// <param name="machineName">�[����</param>
        /// <returns>�������ꂽ�[���Ǘ��ݒ�f�[�^�̃��X�g ����������0���̏ꍇ�A��̃��X�g��Ԃ��܂��B</returns>
        private IList<PosTerminalMg> FindAllByMachineName(string machineName)
        {
            List<PosTerminalMg> foundRecordList = null;
            {
                ArrayList searchedList = null;    // 1�p����

                int status = this._posTerminalMgAcs.SearchServer(out searchedList, this._enterpriseCode);
                if (searchedList != null && searchedList.Count > 0)
                {
                    List<PosTerminalMg> searchedRecordList = new List<PosTerminalMg>(
                        (PosTerminalMg[])searchedList.ToArray(typeof(PosTerminalMg))
                    );
                    foundRecordList = searchedRecordList.FindAll(delegate(PosTerminalMg item)
                    {
                        return item.MachineName.Trim().Equals(machineName.Trim());
                    });
                }
            }
            return foundRecordList ?? new List<PosTerminalMg>();
        }

        #endregion // �����ݑO����
        // ADD 2009/09/24 ���[�����̓o�^�������Ȃ��d�l�Ƃ��� ----------<<<<<

        #endregion
    }
}
