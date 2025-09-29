
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
using Broadleaf.Library.Text;
using Infragistics.Win.Misc;
using Broadleaf.Application.Common;


namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ��������ݒ��ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>Node       : ��������ݒ���s���N���X�ł��B</br>
	/// <br>Programmer : 23010 �����@�m</br>
	/// <br>Date       : 2005.08.06</br>
	/// <br>Update Note:2005.09.02 22021 �J��</br> 
	/// <br>            �ۑ��m�F��̃G���^�[�L�[�������̃t�H�[�J�X�Ή�</br>
	/// <br>Update Note:2005.09.08 22021 �J���@�͍K</br>
	/// <br>			���O�C�����擾���i�̑g����</br>
	/// <br>Update Note:2005.09.20 22021 �J���@�͍K</br>
	/// <br>			���Ӑ�d�b�ԍ��󎚋敪�̒ǉ�</br>
	/// <br>Update Note:2005.09.22 22021 �J���@�͍K</br>
	/// <br>			���b�Z�[�W�\���̕ύX</br>
	/// <br>Update Note: 2005.10.19 22021 �J���@�͍K</br>
	/// <br>		   : �EUI�q���Hide����Owner.Activate�����ǉ�</br>
	/// <br>Update Note: 2006.01.27 22021 �J���@�͍K</br>
	/// <br>		   : �E����������ꎞ���f������ǉ�</br>
	/// <br>Update Note: 2006.04.10 23001 �H�R�@����</br>
	/// <br>           : 1.���������Ѓv���e�N�g������̂P�`�S�����Ж��ē����o���P�`�S�ɕύX</br>
	/// <br>Update Note: 2006.06.01 23001 �H�R�@����</br>
	/// <br>                        1.�W���\��\�o�͋敪��ǉ�</br>
	/// <br>                        2.�W���\��\�W���\��z�i����p�j��ǉ�</br>
	/// <br>                        3.�W���\��\�o�̓^�C�v��ǉ�</br>
    /// <br>Update Note: 2007.06.27 20031 �É�@���S��</br>
    /// <br>			�E��ʕ\�����ږ��̕ύX(���v�������o�͋敪��������(��)�o�͋敪)</br>
    /// <br>			�E�e�[�u���C���ɂ�鍀�ڍ폜</br>
    /// <br>                1.�����O��t�o�͋敪���폜</br>
    /// <br>                2.����������ŏo�͋敪���폜</br>
    /// <br>                3.���������Ѓv���e�N�g������̂P�`�S���폜</br>
    /// <br>                4.�������E�v�P�A�Q���폜</br>
    /// <br>                5.�W���\��\�o�͋敪���폜</br>
    /// <br>                6.�W���\��\�W���\��z�i����p�j���폜</br>
    /// <br>                7.�W���\��\�o�̓^�C�v���폜</br>
    /// <br>Update Note: 2007.07.12 20031 �É�@���S��</br>
    /// <br>			�E���Ж��󎚋敪�ɍ��ڒǉ�</br>
    /// <br>			�E���Ж��󎚋敪�̃R���{�{�b�N�X�f�[�^�̈�����ύX</br>
    /// <br>			�@�iSelectedIndex �� SelectedItem�j</br>
    /// <br>Update Note: 2008.11.10 30452 ���@�r��</br>
    /// <br>			�E�ȉ��̍��ږ��̂�ύX</br>
    /// <br>			�E�������i���v�j�ˁ@�������o�͋敪</br>
    /// <br>			�E�������i���ׁA�`�[���v�j�ˁ@�̎����o�͋敪</br>
    /// </remarks>
	public class SFUKK09080UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
	{	
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private Broadleaf.Library.Windows.Forms.THtmlGenerate tHtmlGenerate1;
		private System.Windows.Forms.GroupBox ChangeNumber_groupBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private Broadleaf.Library.Windows.Forms.TComboEditor BillTableOutCd_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TComboEditor TotalBillOutputDiv_tComboEditor;
        private Broadleaf.Library.Windows.Forms.TComboEditor DetailBillOutputCode_tComboEditor;
        private Broadleaf.Library.Windows.Forms.TComboEditor BillLastDayPrtDiv_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TComboEditor BillCoNmPrintOutCd_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TComboEditor BillBankNmPrintOut_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel BillTableOutCd_ultraLabel;
        private Infragistics.Win.Misc.UltraLabel BillLastDayPrtDiv_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel BillBankNmPrintOut_ultraLabel;
        private Infragistics.Win.Misc.UltraLabel BillCoNmPrintOutCd_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel TotalBillOutputDiv_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel DetailBillOutputCode_ultraLa��el;
		private Infragistics.Win.Misc.UltraLabel CustTelNoPrtDivCd_ultraLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor CustTelNoPrtDivCd_tComboEditor;
        private TArrowKeyControl tArrowKeyControl1;
		private System.ComponentModel.IContainer components;
		#endregion 
		
		# region Constructor
		/// <summary>
		/// ��������ݒ��ʃN���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��������ݒ��ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2005.08.06</br>
		/// </remarks>
		public SFUKK09080UA()
		{
			InitializeComponent();

			// billPrtSt�N���X�A�N�Z�X�N���X
			this.billPrtStAcs = new BillPrtStAcs() ;

			// billPrtSt�N���X
			this.billPrtSt = new BillPrtSt();


			//�@��ƃR�[�h���擾����
			// 2005.09.08 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//			this._enterpriseCode = "TBS1";	// �� �v�ύX
			// 2005.09.08 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// ����\�t���O��ݒ肵�܂��B
			// Frame�̈���{�^���̕\����\���̐���Ɏg�p���܂��B
			_canPrint = false;

			// ��ʃN���[�Y����ݒ肵�܂��B
			// Close��Hide���̐���Ɏg�p���܂��B
			_canClose = false;

		}
		#endregion
		
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
		#endregion

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09080UA));
            this.BillTableOutCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.BillTableOutCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.TotalBillOutputDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DetailBillOutputCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BillLastDayPrtDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillLastDayPrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ChangeNumber_groupBox = new System.Windows.Forms.GroupBox();
            this.TotalBillOutputDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DetailBillOutputCode_ultraLa��el = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CustTelNoPrtDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CustTelNoPrtDivCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillBankNmPrintOut_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillCoNmPrintOutCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillCoNmPrintOutCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BillBankNmPrintOut_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BillTableOutCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBillOutputDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBillOutputCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillLastDayPrtDiv_tComboEditor)).BeginInit();
            this.ChangeNumber_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustTelNoPrtDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillCoNmPrintOutCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillBankNmPrintOut_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // BillTableOutCd_ultraLabel
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.BillTableOutCd_ultraLabel.Appearance = appearance1;
            this.BillTableOutCd_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillTableOutCd_ultraLabel.Location = new System.Drawing.Point(24, 32);
            this.BillTableOutCd_ultraLabel.Name = "BillTableOutCd_ultraLabel";
            this.BillTableOutCd_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.BillTableOutCd_ultraLabel.TabIndex = 3;
            this.BillTableOutCd_ultraLabel.Text = "�����ꗗ�\";
            // 
            // Ok_Button
            // 
            this.Ok_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(255, 366);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 4;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(385, 366);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 406);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(527, 23);
            this.ultraStatusBar1.TabIndex = 8;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance2;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance3;
            this.Mode_Label.Location = new System.Drawing.Point(395, 10);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 6;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
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
            // BillTableOutCd_tComboEditor
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillTableOutCd_tComboEditor.ActiveAppearance = appearance8;
            appearance25.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillTableOutCd_tComboEditor.Appearance = appearance25;
            this.BillTableOutCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BillTableOutCd_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillTableOutCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillTableOutCd_tComboEditor.ItemAppearance = appearance26;
            this.BillTableOutCd_tComboEditor.Location = new System.Drawing.Point(208, 33);
            this.BillTableOutCd_tComboEditor.MaxDropDownItems = 18;
            this.BillTableOutCd_tComboEditor.Name = "BillTableOutCd_tComboEditor";
            this.BillTableOutCd_tComboEditor.Size = new System.Drawing.Size(264, 24);
            this.BillTableOutCd_tComboEditor.TabIndex = 0;
            // 
            // TotalBillOutputDiv_tComboEditor
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TotalBillOutputDiv_tComboEditor.ActiveAppearance = appearance14;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            this.TotalBillOutputDiv_tComboEditor.Appearance = appearance28;
            this.TotalBillOutputDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.TotalBillOutputDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TotalBillOutputDiv_tComboEditor.ItemAppearance = appearance29;
            this.TotalBillOutputDiv_tComboEditor.Location = new System.Drawing.Point(208, 65);
            this.TotalBillOutputDiv_tComboEditor.MaxDropDownItems = 18;
            this.TotalBillOutputDiv_tComboEditor.Name = "TotalBillOutputDiv_tComboEditor";
            this.TotalBillOutputDiv_tComboEditor.Size = new System.Drawing.Size(264, 24);
            this.TotalBillOutputDiv_tComboEditor.TabIndex = 1;
            // 
            // DetailBillOutputCode_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DetailBillOutputCode_tComboEditor.ActiveAppearance = appearance17;
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            this.DetailBillOutputCode_tComboEditor.Appearance = appearance31;
            this.DetailBillOutputCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DetailBillOutputCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DetailBillOutputCode_tComboEditor.ItemAppearance = appearance32;
            this.DetailBillOutputCode_tComboEditor.Location = new System.Drawing.Point(208, 97);
            this.DetailBillOutputCode_tComboEditor.MaxDropDownItems = 18;
            this.DetailBillOutputCode_tComboEditor.Name = "DetailBillOutputCode_tComboEditor";
            this.DetailBillOutputCode_tComboEditor.Size = new System.Drawing.Size(264, 24);
            this.DetailBillOutputCode_tComboEditor.TabIndex = 2;
            // 
            // BillLastDayPrtDiv_ultraLabel
            // 
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.BillLastDayPrtDiv_ultraLabel.Appearance = appearance20;
            this.BillLastDayPrtDiv_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillLastDayPrtDiv_ultraLabel.Location = new System.Drawing.Point(24, 24);
            this.BillLastDayPrtDiv_ultraLabel.Name = "BillLastDayPrtDiv_ultraLabel";
            this.BillLastDayPrtDiv_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.BillLastDayPrtDiv_ultraLabel.TabIndex = 13;
            this.BillLastDayPrtDiv_ultraLabel.Text = "�����󎚐ݒ�";
            // 
            // BillLastDayPrtDiv_tComboEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillLastDayPrtDiv_tComboEditor.ActiveAppearance = appearance7;
            appearance22.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillLastDayPrtDiv_tComboEditor.Appearance = appearance22;
            this.BillLastDayPrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BillLastDayPrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillLastDayPrtDiv_tComboEditor.ItemAppearance = appearance23;
            this.BillLastDayPrtDiv_tComboEditor.Location = new System.Drawing.Point(208, 25);
            this.BillLastDayPrtDiv_tComboEditor.MaxDropDownItems = 18;
            this.BillLastDayPrtDiv_tComboEditor.Name = "BillLastDayPrtDiv_tComboEditor";
            this.BillLastDayPrtDiv_tComboEditor.Size = new System.Drawing.Size(232, 24);
            this.BillLastDayPrtDiv_tComboEditor.TabIndex = 1;
            // 
            // ChangeNumber_groupBox
            // 
            this.ChangeNumber_groupBox.Controls.Add(this.BillTableOutCd_tComboEditor);
            this.ChangeNumber_groupBox.Controls.Add(this.TotalBillOutputDiv_tComboEditor);
            this.ChangeNumber_groupBox.Controls.Add(this.DetailBillOutputCode_tComboEditor);
            this.ChangeNumber_groupBox.Controls.Add(this.BillTableOutCd_ultraLabel);
            this.ChangeNumber_groupBox.Controls.Add(this.TotalBillOutputDiv_ultraLabel);
            this.ChangeNumber_groupBox.Controls.Add(this.DetailBillOutputCode_ultraLa��el);
            this.ChangeNumber_groupBox.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChangeNumber_groupBox.Location = new System.Drawing.Point(16, 40);
            this.ChangeNumber_groupBox.Name = "ChangeNumber_groupBox";
            this.ChangeNumber_groupBox.Size = new System.Drawing.Size(494, 136);
            this.ChangeNumber_groupBox.TabIndex = 0;
            this.ChangeNumber_groupBox.TabStop = false;
            this.ChangeNumber_groupBox.Text = "����o�͋��z�敪";
            // 
            // TotalBillOutputDiv_ultraLabel
            // 
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.TotalBillOutputDiv_ultraLabel.Appearance = appearance33;
            this.TotalBillOutputDiv_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalBillOutputDiv_ultraLabel.Location = new System.Drawing.Point(24, 64);
            this.TotalBillOutputDiv_ultraLabel.Name = "TotalBillOutputDiv_ultraLabel";
            this.TotalBillOutputDiv_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.TotalBillOutputDiv_ultraLabel.TabIndex = 4;
            this.TotalBillOutputDiv_ultraLabel.Text = "�������o�͋敪";
            // 
            // DetailBillOutputCode_ultraLa��el
            // 
            appearance34.TextHAlignAsString = "Left";
            appearance34.TextVAlignAsString = "Middle";
            this.DetailBillOutputCode_ultraLa��el.Appearance = appearance34;
            this.DetailBillOutputCode_ultraLa��el.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DetailBillOutputCode_ultraLa��el.Location = new System.Drawing.Point(24, 96);
            this.DetailBillOutputCode_ultraLa��el.Name = "DetailBillOutputCode_ultraLa��el";
            this.DetailBillOutputCode_ultraLa��el.Size = new System.Drawing.Size(231, 25);
            this.DetailBillOutputCode_ultraLa��el.TabIndex = 5;
            this.DetailBillOutputCode_ultraLa��el.Text = "�̎����o�͋敪";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CustTelNoPrtDivCd_tComboEditor);
            this.groupBox1.Controls.Add(this.CustTelNoPrtDivCd_ultraLabel);
            this.groupBox1.Controls.Add(this.BillBankNmPrintOut_ultraLabel);
            this.groupBox1.Controls.Add(this.BillCoNmPrintOutCd_ultraLabel);
            this.groupBox1.Controls.Add(this.BillCoNmPrintOutCd_tComboEditor);
            this.groupBox1.Controls.Add(this.BillBankNmPrintOut_tComboEditor);
            this.groupBox1.Controls.Add(this.BillLastDayPrtDiv_ultraLabel);
            this.groupBox1.Controls.Add(this.BillLastDayPrtDiv_tComboEditor);
            this.groupBox1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(16, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 160);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "������";
            // 
            // CustTelNoPrtDivCd_tComboEditor
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustTelNoPrtDivCd_tComboEditor.ActiveAppearance = appearance4;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.CustTelNoPrtDivCd_tComboEditor.Appearance = appearance9;
            this.CustTelNoPrtDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CustTelNoPrtDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustTelNoPrtDivCd_tComboEditor.ItemAppearance = appearance10;
            this.CustTelNoPrtDivCd_tComboEditor.Location = new System.Drawing.Point(208, 121);
            this.CustTelNoPrtDivCd_tComboEditor.MaxDropDownItems = 18;
            this.CustTelNoPrtDivCd_tComboEditor.Name = "CustTelNoPrtDivCd_tComboEditor";
            this.CustTelNoPrtDivCd_tComboEditor.Size = new System.Drawing.Size(147, 24);
            this.CustTelNoPrtDivCd_tComboEditor.TabIndex = 9;
            // 
            // CustTelNoPrtDivCd_ultraLabel
            // 
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.CustTelNoPrtDivCd_ultraLabel.Appearance = appearance11;
            this.CustTelNoPrtDivCd_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustTelNoPrtDivCd_ultraLabel.Location = new System.Drawing.Point(24, 120);
            this.CustTelNoPrtDivCd_ultraLabel.Name = "CustTelNoPrtDivCd_ultraLabel";
            this.CustTelNoPrtDivCd_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.CustTelNoPrtDivCd_ultraLabel.TabIndex = 22;
            this.CustTelNoPrtDivCd_ultraLabel.Text = "���Ӑ�d�b�ԍ��󎚋敪";
            // 
            // BillBankNmPrintOut_ultraLabel
            // 
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.BillBankNmPrintOut_ultraLabel.Appearance = appearance12;
            this.BillBankNmPrintOut_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillBankNmPrintOut_ultraLabel.Location = new System.Drawing.Point(24, 88);
            this.BillBankNmPrintOut_ultraLabel.Name = "BillBankNmPrintOut_ultraLabel";
            this.BillBankNmPrintOut_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.BillBankNmPrintOut_ultraLabel.TabIndex = 21;
            this.BillBankNmPrintOut_ultraLabel.Text = "��s���󎚋敪";
            // 
            // BillCoNmPrintOutCd_ultraLabel
            // 
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.BillCoNmPrintOutCd_ultraLabel.Appearance = appearance13;
            this.BillCoNmPrintOutCd_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillCoNmPrintOutCd_ultraLabel.Location = new System.Drawing.Point(24, 56);
            this.BillCoNmPrintOutCd_ultraLabel.Name = "BillCoNmPrintOutCd_ultraLabel";
            this.BillCoNmPrintOutCd_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.BillCoNmPrintOutCd_ultraLabel.TabIndex = 20;
            this.BillCoNmPrintOutCd_ultraLabel.Text = "���Ж��󎚋敪";
            // 
            // BillCoNmPrintOutCd_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillCoNmPrintOutCd_tComboEditor.ActiveAppearance = appearance5;
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillCoNmPrintOutCd_tComboEditor.Appearance = appearance15;
            this.BillCoNmPrintOutCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BillCoNmPrintOutCd_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillCoNmPrintOutCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillCoNmPrintOutCd_tComboEditor.ItemAppearance = appearance16;
            this.BillCoNmPrintOutCd_tComboEditor.Location = new System.Drawing.Point(208, 57);
            this.BillCoNmPrintOutCd_tComboEditor.MaxDropDownItems = 18;
            this.BillCoNmPrintOutCd_tComboEditor.Name = "BillCoNmPrintOutCd_tComboEditor";
            this.BillCoNmPrintOutCd_tComboEditor.Size = new System.Drawing.Size(192, 24);
            this.BillCoNmPrintOutCd_tComboEditor.TabIndex = 7;
            // 
            // BillBankNmPrintOut_tComboEditor
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillBankNmPrintOut_tComboEditor.ActiveAppearance = appearance6;
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillBankNmPrintOut_tComboEditor.Appearance = appearance18;
            this.BillBankNmPrintOut_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BillBankNmPrintOut_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillBankNmPrintOut_tComboEditor.ItemAppearance = appearance19;
            this.BillBankNmPrintOut_tComboEditor.Location = new System.Drawing.Point(208, 89);
            this.BillBankNmPrintOut_tComboEditor.MaxDropDownItems = 18;
            this.BillBankNmPrintOut_tComboEditor.Name = "BillBankNmPrintOut_tComboEditor";
            this.BillBankNmPrintOut_tComboEditor.Size = new System.Drawing.Size(147, 24);
            this.BillBankNmPrintOut_tComboEditor.TabIndex = 8;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // SFUKK09080UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(527, 429);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChangeNumber_groupBox);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09080UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���������l�ݒ�";
            this.Load += new System.EventHandler(this.SFUKK09080UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09080UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09080UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.BillTableOutCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBillOutputDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBillOutputCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillLastDayPrtDiv_tComboEditor)).EndInit();
            this.ChangeNumber_groupBox.ResumeLayout(false);
            this.ChangeNumber_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustTelNoPrtDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillCoNmPrintOutCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillBankNmPrintOut_tComboEditor)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09080UA());
		}
		#endregion 

		#region Private Members

		//��������f�[�^�N���X
		private BillPrtSt billPrtSt;
		//��������A�N�Z�X�N���X
		private BillPrtStAcs billPrtStAcs;
		// ��ƃR�[�h
		private string _enterpriseCode;
		// ��r�pclone
		private BillPrtSt _billPrtStClone;
		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canClose;
		//�t���[���̃^�C�g��
		private const string HTML_HEADER_TITLE	= "�ݒ荀��";
		private const string HTML_HEADER_VALUE	= "�ݒ�l";
		//���ݒ�̏ꍇ
		private const string HTML_UNREGISTER	= "���ݒ�";
		// �ҏW���[�h
		private const string UPDATE_MODE		= "�X�V���[�h";

        // 2007.07.12  S.Koga  ADD --------------------------------------------
        //private const string BILLCONMPRINTOUTCD_MYIMAGE = "���Љ摜�ň������";  // DEL 2008/06/13
        // --------------------------------------------------------------------

        // --- ADD 2008/06/13 -------------------------------->>>>>
        private const string BILLCONMPRINTOUTCD_OWN     = "���Ж�";
        private const string BILLCONMPRINTOUTCD_SECTION = "���_��";
        private const string BILLCONMPRINTOUTCD_BITMAP  = "�r�b�g�}�b�v";
        private const string BILLCONMPRINTOUTCD_NO      = "�󎚂��Ȃ�";
        // --- ADD 2008/06/13 --------------------------------<<<<< 

		#endregion

		# region Events
		/// <summary>
		/// ��ʔ�\���C�x���g
		/// </summary>
		/// <remarks>
		/// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
		/// </remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region Properties
		/// <summary>
		/// ����v���p�e�B
		/// </summary>
		/// <remarks>
		/// ����\���ǂ����̐ݒ���擾���܂��B�ifalse�Œ�j
		/// </remarks>
		public bool CanPrint
		{
			get{ return _canPrint; }
		}

		/// <summary>
		/// ��ʃN���[�Y�v���p�e�B
		/// </summary>
		/// <remarks>
		/// ��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B
		/// false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B
		/// </remarks>
		public bool CanClose
		{
			get{ return _canClose; }
			set{ _canClose = value; }
		}
		# endregion
		
		#region public Method
		/// <summary>
		///	�������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note			:	�i�������j</br>
		/// <br>Programmer		:	23010 �����@�m</br>
		/// <br>Date			:	2005.08.06</br>
		/// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

		/// <summary>
		///	HTML�R�[�h�擾����
		/// </summary>
		/// <returns>HTML�R�[�h</returns>
		/// <remarks>
		/// <br>Note			:	�t���[���p�̂g�s�l�k�R�[�h���擾���܂��B</br>
		/// <br>Programmer		:	23010 �����@�m</br>
		/// <br>Date			:	2005.08.06</br>
		/// </remarks>
		public string GetHtmlCode()
		{
			string outCode = "";

			// tHtmlGenerate���i�̈����𐶐�����
// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            // 2007.06.27  S.Koga  amend --------------------------------------
            //string [,] array = new string[20,2];
            //string[,] array = new string[9, 2];  // DEL 2008/06/13
            string[,] array = new string[8, 2];  // ADD 2008/06/13
            // ----------------------------------------------------------------
// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.06.01 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//string [,] array = new string[17,2];
// 2006.06.01 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			this.tHtmlGenerate1.Coltypes = new int[2];

			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
				
			array[0,0]	= HTML_HEADER_TITLE;										//�u�ݒ荀�ځv
			array[0,1]	= HTML_HEADER_VALUE;										//�u�ݒ�l�v

			array[1,0]	= this.BillTableOutCd_ultraLabel.Text + "�o�͋敪";			// �����ꗗ�\�o�͋敪
            //array[2,0]	= this.TotalBillOutputDiv_ultraLabel.Text +"�o�͋敪";		// ������(��)�o�͋敪 // DEL 2008/11/10
            //array[3,0]	= this.DetailBillOutputCode_ultraLa��el.Text + "�o�͋敪";�@�@// ���א������o�͋敪 // DEL 2008/11/10
            array[2, 0] = this.TotalBillOutputDiv_ultraLabel.Text;		// ������(��)�o�͋敪 // ADD 2008/11/10
            array[3, 0] = this.DetailBillOutputCode_ultraLa��el.Text;�@�@// ���א������o�͋敪 // ADD 2008/11/10
            # region 2007.06.27  S.Koga  DEL
            //array[4,0]	= this.BillBfRmonOutltem_ultraLabel.Text;					// �����O����o�͍���
            # endregion
// 2006.04.10 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            # region 2007.06.27  S.Koga  DEL
            //array[5,0]	= this.BillConstTaxOutPutCd_ultraLabel.Text;				// ����������ŏo�͋敪
            # endregion
            //array[6, 0] = this.BillLastDayPrtDiv_ultraLabel.Text;					// �����������󎚋敪
            array[4, 0] = this.BillLastDayPrtDiv_ultraLabel.Text;					// �����������󎚋敪
            # region 2007.06.27  S.Koga  DEL
            //array[7,0]	= this.BillEpProtectPrtNm1_ultraLabel.Text;					// ���������Ѓv���e�N�g�������1
            //array[8,0]	= this.BillEpProtectPrtNm2_ultraLabel.Text;					// ���������Ѓv���e�N�g�������2
            //array[9,0]	= this.BillEpProtectPrtNm3_ultraLabel.Text;					// ���������Ѓv���e�N�g�������3
            //array[10,0] = this.BillEpProtectPrtNm4_ultraLabel.Text;					// ���������Ѓv���e�N�g�������4
            # endregion
            //array[11,0] = this.BillPrtSuspendCnt_ultraLabel.Text;					// ����������ꎞ���f����
            //array[5, 0] = this.BillPrtSuspendCnt_ultraLabel.Text;					// ����������ꎞ���f����  // DEL 2008/06/13
            //array[12,0] = this.BillCoNmPrintOutCd_ultraLabel.Text;					// ���������Ж��󎚋敪
            array[5, 0] = this.BillCoNmPrintOutCd_ultraLabel.Text;					// ���������Ж��󎚋敪
            //array[13,0] = this.BillBankNmPrintOut_ultraLabel.Text;					// ��������s���󎚋敪
            array[6, 0] = this.BillBankNmPrintOut_ultraLabel.Text;					// ��������s���󎚋敪
            //array[14,0] = this.CustTelNoPrtDivCd_ultraLabel.Text;					// ���Ӑ�d�b�ԍ��󎚋敪
            array[7, 0] = this.CustTelNoPrtDivCd_ultraLabel.Text;					// ���Ӑ�d�b�ԍ��󎚋敪
            # region 2007.06.27  S.Koga  DEL
            //array[15,0] = this.BillOutline1_ultraLabel.Text;						// �������E�v1
            //array[16,0] = this.BillOutline2_ultraLabel.Text;						// �������E�v2
            # endregion
// 2006.04.10 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.04.10 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			array[5,0]	= "������"+this.BillConstTaxOutPutCd_ultraLabel.Text;		// ����������ŏo�͋敪
//			array[6,0]	= "������"+this.BillLastDayPrtDiv_ultraLabel.Text;			// �����������󎚋敪
//			array[7,0]	= "������"+this.BillEpProtectPrtNm1_ultraLabel.Text;		// ���������Ѓv���e�N�g�������1
//			array[8,0]	= "������"+this.BillEpProtectPrtNm2_ultraLabel.Text;		// ���������Ѓv���e�N�g�������2
//			array[9,0]	= "������"+this.BillEpProtectPrtNm3_ultraLabel.Text;		// ���������Ѓv���e�N�g�������3
//			array[10,0] = "������"+this.BillEpProtectPrtNm4_ultraLabel.Text;		// ���������Ѓv���e�N�g�������4
//			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			array[11,0] = "������"+this.BillPrtSuspendCnt_ultraLabel.Text;			// ����������ꎞ���f����
//			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
//			array[12,0] = "������"+this.BillCoNmPrintOutCd_ultraLabel.Text;			// ���������Ж��󎚋敪
//			array[13,0] = "������"+this.BillBankNmPrintOut_ultraLabel.Text;			// ��������s���󎚋敪
//			
//			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			array[14,0] = this.CustTelNoPrtDivCd_ultraLabel.Text;					// ���Ӑ�d�b�ԍ��󎚋敪
//			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
//			
//			array[15,0] = "������"+this.BillOutline1_ultraLabel.Text;				// �������E�v1
//			array[16,0] = "������"+this.BillOutline2_ultraLabel.Text;				// �������E�v2
// 2006.04.10 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //array[ 17, 0 ] = this.ClctMnyPlnDocOutType_Title_Label.Text;            // �W���\��\�o�̓^�C�v
            //array[ 18, 0 ] = this.ClctMnyPlnDocVarCst_Title_Label.Text;             // �W���\��\�W���\��z�i����p�j
            //array[ 19, 0 ] = this.ClctMnyPlnDocOutCd_Title_Label.Text;              // �W���\��\�o�͋敪
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

            //�f�[�^�ǂݍ���															
			int status = this.billPrtStAcs.Read(out billPrtSt,this._enterpriseCode);
			if (status == 0)
			{	
				// �����ꗗ�\�o�͋敪
				switch(billPrtSt.BillTableOutCd)
				{
					case 0:
						array[1,1] = "�S�ďo��";
						break;
					case 1:
						array[1,1] = "�O�ƃv���X���z���o��";
						break;
					case 2:
						array[1,1] = "�v���X���z�̂ݏo��";
						break;
					case 3:
						array[1,1] = "�O�̂ݏo��";
						break;
					case 4:
						array[1,1] = "�v���X���z�ƃ}�C�i�X���z���o��";
						break;
					case 5:
						array[1,1] = "�O�ƃ}�C�i�X���z���o��";
						break;
					case 6:
						array[1,1] = "�}�C�i�X���z�̂ݏo��";
						break;
					default:
						array[1,1] = HTML_UNREGISTER;
						break;
				}
				// ������(���v)�o�͋敪
				switch(billPrtSt.TotalBillOutputDiv)
				{
					case 0:
						array[2,1] = "�S�ďo��";
						break;
					case 1:
						array[2,1] = "�O�ƃv���X���z���o��";
						break;
					case 2:
						array[2,1] = "�v���X���z�̂ݏo��";
						break;
					case 3:
						array[2,1] = "�O�̂ݏo��";
						break;
					case 4:
						array[2,1] = "�v���X���z�ƃ}�C�i�X���z���o��";
						break;
					case 5:
						array[2,1] = "�O�ƃ}�C�i�X���z���o��";
						break;
					case 6:
						array[2,1] = "�}�C�i�X���z�̂ݏo��";
						break;
					default:
						array[2,1] = HTML_UNREGISTER;
						break;
				}
				// ������(���ׁA�`�[���v)�o�͋敪
				switch(billPrtSt.DetailBillOutputCode)
				{
					case 0:
						array[3,1] = "�S�ďo��";
						break;
					case 1:
						array[3,1] = "�O�ƃv���X���z���o��";
						break;
					case 2:
						array[3,1] = "�v���X���z�̂ݏo��";
						break;
					case 3:
						array[3,1] = "�O�̂ݏo��";
						break;
					case 4:
						array[3,1] = "�v���X���z�ƃ}�C�i�X���z���o��";
						break;
					case 5:
						array[3,1] = "�O�ƃ}�C�i�X���z���o��";
						break;
					case 6:
						array[3,1] = "�}�C�i�X���z�̂ݏo��";
						break;
					default:
						array[3,1] = HTML_UNREGISTER;
						break;
                }
                # region 2007.06.27  S.Koga  DEL
                //// �������O����o�͍���
                //switch(billPrtSt.BillBfRmonOutItem)
                //{
                //    case 0:
                //        array[4,1] = "�O���";
                //        break;
                //    case 1:
                //        array[4,1] = "�������";
                //        break;
                //    default:
                //        array[4,1] = HTML_UNREGISTER;
                //        break;
                //}
                //// ����������ŏo�͋敪
                //switch(billPrtSt.BillConsTaxOutPutCd)
                //{
                //    case 0:
                //        array[5,1] = "����ŕ�";
                //        break;
                //    case 1:
                //        array[5,1] = "����ō���";
                //        break;
                //    default:
                //        array[5,1] = HTML_UNREGISTER;
                //        break;
                //}
                # endregion
                // �����������󎚋敪
				switch(billPrtSt.BillLastDayPrtDiv)
				{
					case 0:
                        //array[6,1] = "���l��";
                        array[4, 1] = "���l��";
                        break;
					case 1:
                        //array[6,1] = "�Q�W�`�R�P���͖����ƈ�";
                        array[4, 1] = "�Q�W�`�R�P���͖����ƈ�";
                        break;
					default:
                        //array[6,1] = HTML_UNREGISTER;
                        array[4, 1] = HTML_UNREGISTER;
                        break;
				}
                # region 2007.06.27  S.Koga  DEL
                //// ���������Ѓv���e�N�g�������
                //array[7,1]  =  billPrtSt.BillEpProtectPrtNm1;
                //array[8,1]  =  billPrtSt.BillEpProtectPrtNm2;
                //array[9,1]  =  billPrtSt.BillEpProtectPrtNm3;
                //array[10,1] =  billPrtSt.BillEpProtectPrtNm4;�@	�@ 
                # endregion
                // ����������ꎞ���f����
                //array[11,1] =  billPrtSt.BillPrtSuspendCnt.ToString(); 
                //array[5, 1] = billPrtSt.BillPrtSuspendCnt.ToString();  // DEL 2008/06/13

                // ���������Ж��󎚋敪
				switch(billPrtSt.BillCoNmPrintOutCd)
				{
					case 0:
                        //array[12,1] = "�󎚂���";
                        //array[5, 1] = "�󎚂���";  // DEL 2008/06/13
                        array[5, 1] = BILLCONMPRINTOUTCD_OWN;  // ADD 2008/06/13
                        break;
					case 1:
                        //array[12,1] = "�󎚂��Ȃ�";
                        //array[5, 1] = "�󎚂��Ȃ�";  // DEL 2008/06/13
                        array[5, 1] = BILLCONMPRINTOUTCD_SECTION;  // ADD 2008/06/13
                        break;
                    // 2007.07.12  S.Koga  ADD --------------------------------
                    case 2:
                        //array[5, 1] = BILLCONMPRINTOUTCD_MYIMAGE;  // DEL 2008/06/13
                        array[5, 1] = BILLCONMPRINTOUTCD_BITMAP;  // ADD 2008/06/13
                        break;
                    // --------------------------------------------------------
                    // --- ADD 2008/06/13 -------------------------------->>>>>
                    case 3:
                        array[5, 1] = BILLCONMPRINTOUTCD_NO;
                        break;
                    // --- ADD 2008/06/13 --------------------------------<<<<< 
                    default:
                        //array[12,1] = HTML_UNREGISTER;
                        array[5, 1] = HTML_UNREGISTER;
                        break;
				}
				// ��������s���󎚋敪
				switch(billPrtSt.BillBankNmPrintOut)
				{
					case 0:
                        //array[13,1] = "�󎚂���";
                        array[6, 1] = "�󎚂���";
                        break;
					case 1:
                        //array[13,1] = "�󎚂��Ȃ�";
                        array[6, 1] = "�󎚂��Ȃ�";
                        break;
					default:
                        //array[13,1] = HTML_UNREGISTER;
                        array[6, 1] = HTML_UNREGISTER;
                        break;
				}
				
				// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// ���Ӑ�d�b�ԍ��󎚋敪
				switch(billPrtSt.CustTelNoPrtDivCd)
				{
					case 0:
                        //array[14,1] = "�󎚂��Ȃ�";
                        array[7, 1] = "�󎚂��Ȃ�"; 
                        break;
					case 1:
                        //array[14,1] = "�󎚂���";
                        array[7, 1] = "�󎚂���";
                        break;
					default:
						//array[14,1] = HTML_UNREGISTER;
                        array[7, 1] = HTML_UNREGISTER;
                        break;
				}
                // 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

                # region 2007.06.27  S.Koga  DEL
                ////�������E�v
                //array[15,1] = billPrtSt.BillOutline1;
                //array[16,1] = billPrtSt.BillOutline2;

                // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                //// �W���\��\�o�̓^�C�v
                //switch( billPrtSt.ClctMnyPlnDocOutType ) {
                //    case 0:
                //    {
                //        array[ 17, 1 ] = "�������^�C�v";
                //        break;
                //    }
                //    case 1:
                //    {
                //        array[ 17, 1 ] = "����^�C�v(�x�����ɍ��킹���W��)";
                //        break;
                //    }
                //    default:
                //    {
                //        array[ 17, 1 ] = HTML_UNREGISTER;
                //        break;
                //    }
                //}

                //// �W���\��\�W���\��z�i����p�j
                //switch( billPrtSt.ClctMnyPlnDocVarCst ) {
                //    case 0:
                //    {
                //        array[ 18, 1 ] = "�󒍂Ɠ��l(�x�����ɍ��킹��)";
                //        break;
                //    }
                //    case 1:
                //    {
                //        array[ 18, 1 ] = "�W���\�茎�̒������܂߂�";
                //        break;
                //    }
                //    case 2:
                //    {
                //        array[ 18, 1 ] = "�����W��";
                //        break;
                //    }
                //    //case 3:
                //    //{
                //    //    array[ 18, 1 ] = "�����W��";
                //    //    break;
                //    //}
                //    default:
                //    {
                //        array[ 18, 1 ] = HTML_UNREGISTER;
                //        break;
                //    }
                //}

                //// �W���\��\�o�͋敪
                //switch( billPrtSt.ClctMnyPlnDocOutCd ) {
                //    case 0:
                //    {
                //        array[ 19, 1 ] = "�S�ďo��";
                //        break;
                //    }
                //    case 1:
                //    {
                //        array[ 19, 1 ] = "�O�ƃv���X���z���o��";
                //        break;
                //    }
                //    case 2:
                //    {
                //        array[ 19, 1 ] = "�v���X���z�̂ݏo��";
                //        break;
                //    }
                //    case 3:
                //    {
                //        array[ 19, 1 ] = "�O�̂ݏo��";
                //        break;
                //    }
                //    case 4:
                //    {
                //        array[ 19, 1 ] = "�v���X���z�ƃ}�C�i�X���z";
                //        break;
                //    }
                //    case 5:
                //    {
                //        array[ 19, 1 ] = "�O�ƃ}�C�i�X���z���o��";
                //        break;
                //    }
                //    case 6:
                //    {
                //        array[ 19, 1 ] = "�}�C�i�X���z�̂ݏo��";
                //        break;
                //    }
                //    default:
                //    {
                //        array[ 19, 1 ] = HTML_UNREGISTER;
                //        break;
                //    }
                //}
// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                # endregion
            }
			else
			{
				array[1,1]	= HTML_UNREGISTER;
				array[2,1]	= HTML_UNREGISTER;
				array[3,1]	= HTML_UNREGISTER;
				array[4,1]	= HTML_UNREGISTER;
				array[5,1]	= HTML_UNREGISTER;
				array[6,1]	= HTML_UNREGISTER;
				array[7,1]	= HTML_UNREGISTER;
				//array[8,1]	= HTML_UNREGISTER;  // DEL 2008/06/13
                # region 2007.06.27  S.Koga  DEL
                //array[9,1]  = HTML_UNREGISTER;
                //array[10,1] = HTML_UNREGISTER;
                //array[11,1] = HTML_UNREGISTER;
                //array[12,1] = HTML_UNREGISTER;
                //array[13,1] = HTML_UNREGISTER;
                //array[14,1] = HTML_UNREGISTER;
                //array[15,1] = HTML_UNREGISTER;
                //array[16,1] = HTML_UNREGISTER;
// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                //array[17,1] = HTML_UNREGISTER;
                //array[18,1] = HTML_UNREGISTER;
                //array[19,1] = HTML_UNREGISTER;
                // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                # endregion
            }
			// �f�[�^�̂Q�����z��݂̂��w�肵�āA�v���p�e�B���g�p���ăO���b�h�\������
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);

			return outCode;	
		}

		#endregion

		# region private Method
		/// <summary>
		///	��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note			:	��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer		:	23010 �����@�m</br>
		/// <br>Date			:	2005.08.06</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{	
			//�����ꗗ�\�o�͋敪
			this.BillTableOutCd_tComboEditor.Items.Clear();
			this.BillTableOutCd_tComboEditor.Items.Add(0,"�S�ďo��");
			this.BillTableOutCd_tComboEditor.Items.Add(1,"�O�ƃv���X���z���o��");
			this.BillTableOutCd_tComboEditor.Items.Add(2,"�v���X���z�̂ݏo��");
			this.BillTableOutCd_tComboEditor.Items.Add(3,"�O�̂ݏo��");
			this.BillTableOutCd_tComboEditor.Items.Add(4,"�v���X���z�ƃ}�C�i�X���z���o��");
			this.BillTableOutCd_tComboEditor.Items.Add(5,"�O�ƃ}�C�i�X���z���o��");
			this.BillTableOutCd_tComboEditor.Items.Add(6,"�}�C�i�X���z�̂ݏo��");
			this.BillTableOutCd_tComboEditor.MaxDropDownItems = this.BillTableOutCd_tComboEditor.Items.Count;
			//������(���v)�o�͋敪
			this.TotalBillOutputDiv_tComboEditor.Items.Clear();
			this.TotalBillOutputDiv_tComboEditor.Items.Add(0,"�S�ďo��");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(1,"�O�ƃv���X���z���o��");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(2,"�v���X���z�̂ݏo��");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(3,"�O�̂ݏo��");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(4,"�v���X���z�ƃ}�C�i�X���z���o��");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(5,"�O�ƃ}�C�i�X���z���o��");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(6,"�}�C�i�X���z�̂ݏo��");
			this.TotalBillOutputDiv_tComboEditor.MaxDropDownItems = this.TotalBillOutputDiv_tComboEditor.Items.Count;
			//������(���ׁA�`�[���v)�o�͋敪
			this.DetailBillOutputCode_tComboEditor.Items.Clear();
			this.DetailBillOutputCode_tComboEditor.Items.Add(0,"�S�ďo��");
			this.DetailBillOutputCode_tComboEditor.Items.Add(1,"�O�ƃv���X���z���o��");
			this.DetailBillOutputCode_tComboEditor.Items.Add(2,"�v���X���z�̂ݏo��");
			this.DetailBillOutputCode_tComboEditor.Items.Add(3,"�O�̂ݏo��");
			this.DetailBillOutputCode_tComboEditor.Items.Add(4,"�v���X���z�ƃ}�C�i�X���z���o��");
			this.DetailBillOutputCode_tComboEditor.Items.Add(5,"�O�ƃ}�C�i�X���z���o��");
			this.DetailBillOutputCode_tComboEditor.Items.Add(6,"�}�C�i�X���z�̂ݏo��");
			this.DetailBillOutputCode_tComboEditor.MaxDropDownItems = this.DetailBillOutputCode_tComboEditor.Items.Count;
            # region 2007.06.27  S.Koga  DEL
            ////�����O����o�͍���
            //this.BillBfRmonOutltem_tComboEditor.Items.Clear();
            //this.BillBfRmonOutltem_tComboEditor.Items.Add(0,"�O���");
            //this.BillBfRmonOutltem_tComboEditor.Items.Add(1,"�������");
            //this.BillBfRmonOutltem_tComboEditor.MaxDropDownItems = this.BillBfRmonOutltem_tComboEditor.Items.Count;
            ////����������ŏo�͋敪
            //this.BillConstTaxOutPutCd_tComboEditor.Items.Clear();
            //this.BillConstTaxOutPutCd_tComboEditor.Items.Add(0,"����ŕ�");
            //this.BillConstTaxOutPutCd_tComboEditor.Items.Add(1,"����ō���");
            //this.BillConstTaxOutPutCd_tComboEditor.MaxDropDownItems = this.BillConstTaxOutPutCd_tComboEditor.Items.Count;
            # endregion
            //�����������󎚋敪
			this.BillLastDayPrtDiv_tComboEditor.Items.Clear();
			this.BillLastDayPrtDiv_tComboEditor.Items.Add(0,"���l��");
			this.BillLastDayPrtDiv_tComboEditor.Items.Add(1,"�Q�W�`�R�P���͖����ƈ�");
			this.BillLastDayPrtDiv_tComboEditor.MaxDropDownItems = this.BillLastDayPrtDiv_tComboEditor.Items.Count;
			
            //���������Ж��󎚋敪
			this.BillCoNmPrintOutCd_tComboEditor.Items.Clear();
            /* --- DEL 2008/06/13 -------------------------------->>>>>
			this.BillCoNmPrintOutCd_tComboEditor.Items.Add(1,"�󎚂��Ȃ�");
			this.BillCoNmPrintOutCd_tComboEditor.Items.Add(0,"�󎚂���");
            // 2007.07.12  S.Koga  ADD ----------------------------------------
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(2, BILLCONMPRINTOUTCD_MYIMAGE);
            // ----------------------------------------------------------------
               --- DEL 2008/06/13 --------------------------------<<<<< */
            // --- ADD 2008/06/13 -------------------------------->>>>>
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(0,BILLCONMPRINTOUTCD_OWN);
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(1,BILLCONMPRINTOUTCD_SECTION);
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(2,BILLCONMPRINTOUTCD_BITMAP);
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(3, BILLCONMPRINTOUTCD_NO);
            // --- ADD 2008/06/13 --------------------------------<<<<< 
            this.BillCoNmPrintOutCd_tComboEditor.MaxDropDownItems = this.BillCoNmPrintOutCd_tComboEditor.Items.Count;
			
            //��������s���󎚋敪
			this.BillBankNmPrintOut_tComboEditor.Items.Clear();
			this.BillBankNmPrintOut_tComboEditor.Items.Add(1,"�󎚂��Ȃ�");
			this.BillBankNmPrintOut_tComboEditor.Items.Add(0,"�󎚂���");
			//this.BillBankNmPrintOut_tComboEditor.Items.Add(1,"�󎚂��Ȃ�");
			this.BillBankNmPrintOut_tComboEditor.MaxDropDownItems = this.BillBankNmPrintOut_tComboEditor.Items.Count;

			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//���Ӑ�d�b�ԍ��󎚋敪
			this.CustTelNoPrtDivCd_tComboEditor.Items.Clear();
			this.CustTelNoPrtDivCd_tComboEditor.Items.Add(0,"�󎚂��Ȃ�");
			this.CustTelNoPrtDivCd_tComboEditor.Items.Add(1,"�󎚂���");
			this.CustTelNoPrtDivCd_tComboEditor.MaxDropDownItems = this.CustTelNoPrtDivCd_tComboEditor.Items.Count;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            // �W���\��\�o�̓^�C�v
//            this.ClctMnyPlnDocOutType_tComboEditor.Items.Clear();
//            this.ClctMnyPlnDocOutType_tComboEditor.Items.Add( 0, "�������^�C�v" );
//            this.ClctMnyPlnDocOutType_tComboEditor.Items.Add( 1, "����^�C�v(�x�����ɍ��킹���W��)" );
//            this.ClctMnyPlnDocOutType_tComboEditor.MaxDropDownItems = this.ClctMnyPlnDocOutType_tComboEditor.Items.Count;

//            // �W���\��\�W���\��z�i����p�j
//            this.ClctMnyPlnDocVarCst_tComboEditor.Items.Clear();
//            this.ClctMnyPlnDocVarCst_tComboEditor.Items.Add( 0, "�󒍂Ɠ��l(�x�����ɍ��킹��)" );
//            this.ClctMnyPlnDocVarCst_tComboEditor.Items.Add( 1, "�W���\�茎�̒������܂߂�" );
//            this.ClctMnyPlnDocVarCst_tComboEditor.Items.Add( 2, "�����W��" );
////			this.ClctMnyPlnDocVarCst_tComboEditor.Items.Add( 3, "�����W��" );
//            this.ClctMnyPlnDocVarCst_tComboEditor.MaxDropDownItems = this.ClctMnyPlnDocVarCst_tComboEditor.Items.Count;

//            // �W���\��\�o�͋敪
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Clear();
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 0, "�S�ďo��" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 1, "�O�ƃv���X���z���o��" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 2, "�v���X���z�̂ݏo��" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 3, "�O�̂ݏo��" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 4, "�v���X���z�ƃ}�C�i�X���z" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 5, "�O�ƃ}�C�i�X���z���o��" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 6, "�}�C�i�X���z�̂ݏo��" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.MaxDropDownItems = this.ClctMnyPlnDocOutCd_tComboEditor.Items.Count;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

        }
		
		/// <summary>
		///	��������ݒ��ʓW�J����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��������ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void BillPrtStToScreen()
		{
			//�����ꗗ�\�o�͋敪
			this.BillTableOutCd_tComboEditor.SelectedIndex = this.billPrtSt.BillTableOutCd;
			//������(��)�o�͋敪
			this.TotalBillOutputDiv_tComboEditor.SelectedIndex = this.billPrtSt.TotalBillOutputDiv;
			//���א������o�͋敪
			this.DetailBillOutputCode_tComboEditor.SelectedIndex = this.billPrtSt.DetailBillOutputCode;
            # region 2007.06.27  S.Koga  DEL
            ////�����O����o�͍���
            //this.BillBfRmonOutltem_tComboEditor.SelectedIndex = this.billPrtSt.BillBfRmonOutItem;
            ////����������ŏo�͋敪
            //this.BillConstTaxOutPutCd_tComboEditor.SelectedIndex = this.billPrtSt.BillConsTaxOutPutCd;
            # endregion
            //�����������󎚋敪
			this.BillLastDayPrtDiv_tComboEditor.SelectedIndex = this.billPrtSt.BillLastDayPrtDiv;
            # region 2007.06.27  S.Koga  DEL
            ////���������Ѓv���e�N�g�������
            //this.BillEpProtectPrtNm1_tEdit.DataText = billPrtSt.BillEpProtectPrtNm1.TrimEnd();
            //this.BillEpProtectPrtNm2_tEdit.DataText = billPrtSt.BillEpProtectPrtNm2.TrimEnd();
            //this.BillEpProtectPrtNm3_tEdit.DataText = billPrtSt.BillEpProtectPrtNm3.TrimEnd();
            //this.BillEpProtectPrtNm4_tEdit.DataText = billPrtSt.BillEpProtectPrtNm4.TrimEnd();
            # endregion
            // 2006.01.27 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			//���������Ж��󎚋敪
//			this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex = this.billPrtSt.BillCoNmPrintOutCd;
//			//��������s���󎚋敪
//			this.BillBankNmPrintOut_tComboEditor.SelectedIndex = this.billPrtSt.BillBankNmPrintOut;
			// 2006.01.27 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//���������Ж��󎚋敪
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            //if(this.billPrtSt.BillCoNmPrintOutCd == 0)
            //{
            //    this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex = 1;
            //}
            //else
            //{
            //    this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex = 0;
            //}
            this.BillCoNmPrintOutCd_tComboEditor.Value = this.billPrtSt.BillCoNmPrintOutCd;
            // ----------------------------------------------------------------
			//��������s���󎚋敪
			if(this.billPrtSt.BillBankNmPrintOut == 0)
			{
				this.BillBankNmPrintOut_tComboEditor.SelectedIndex = 1;
			}
			else
			{
				this.BillBankNmPrintOut_tComboEditor.SelectedIndex = 0;
			}
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//���Ӑ�d�b�ԍ��󎚋敪
			this.CustTelNoPrtDivCd_tComboEditor.SelectedIndex = this.billPrtSt.CustTelNoPrtDivCd;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            ////�����E�v
            //this.BillOutline1_tEdit.DataText = this.billPrtSt.BillOutline1.TrimEnd();
            //this.BillOutline2_tEdit.DataText = this.billPrtSt.BillOutline2.TrimEnd();	
            # endregion
            // 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//����������ꎞ���f����
			//this.BillPrtSuspendCnt_tNedit1.SetInt(this.billPrtSt.BillPrtSuspendCnt);  // DEL 2008/06/13
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// �W���\��\�o�͋敪
            //this.ClctMnyPlnDocOutCd_tComboEditor.Value   = this.billPrtSt.ClctMnyPlnDocOutCd;
            //// �W���\��\�W���\��z�i����p�j
            //this.ClctMnyPlnDocVarCst_tComboEditor.Value  = this.billPrtSt.ClctMnyPlnDocVarCst;
            //// �W���\��\�o�̓^�C�v
            //this.ClctMnyPlnDocOutType_tComboEditor.Value = this.billPrtSt.ClctMnyPlnDocOutType;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion
        }

		/// <summary>
		///	��ʏ��ː�������ݒ�N���X�i�[����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʏ�񂩂琿������ݒ�N���X�Ƀf�[�^��
		///					 �i�[���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void ScreenTobillPrtSt()
		{
			if (billPrtSt == null)
			{
				// �V�K�̏ꍇ
				billPrtSt = new BillPrtSt();
			}
			//---�w�b�_��--//
			this.billPrtSt.EnterpriseCode = this._enterpriseCode;      //��ƃR�[�h

			//---�f�[�^��--//
			//��������ݒ�Ǘ��R�[�h�i0�Œ�)
			this.billPrtSt.BillPrtStMngCd       = 0; 
			//�����ꗗ�\�o�͋敪
			this.billPrtSt.BillTableOutCd       = this.BillTableOutCd_tComboEditor.SelectedIndex;
			//������(��)�o�͋敪
			this.billPrtSt.TotalBillOutputDiv   =  this.TotalBillOutputDiv_tComboEditor.SelectedIndex;
			//���א������o�͋敪
			this.billPrtSt.DetailBillOutputCode =  this.DetailBillOutputCode_tComboEditor.SelectedIndex;
            # region 2007.06.27  S.Koga  DEL
            ////�����O����o�͍���
            //this.billPrtSt.BillBfRmonOutItem    = this.BillBfRmonOutltem_tComboEditor.SelectedIndex;
            ////����������ŏo�͋敪
            //this.billPrtSt.BillConsTaxOutPutCd  =  this.BillConstTaxOutPutCd_tComboEditor.SelectedIndex;
            # endregion
            //�����������󎚋敪
			this.billPrtSt.BillLastDayPrtDiv    =  this.BillLastDayPrtDiv_tComboEditor.SelectedIndex;
            # region 2007.06.27  S.Koga  DEL
            ////���������Ѓv���e�N�g�������
            //this.billPrtSt.BillEpProtectPrtNm1  = this.BillEpProtectPrtNm1_tEdit.DataText.TrimEnd();
            //this.billPrtSt.BillEpProtectPrtNm2  = this.BillEpProtectPrtNm2_tEdit.DataText.TrimEnd();	
            //this.billPrtSt.BillEpProtectPrtNm3	= this.BillEpProtectPrtNm3_tEdit.DataText.TrimEnd(); 
            //this.billPrtSt.BillEpProtectPrtNm4	= this.BillEpProtectPrtNm4_tEdit.DataText.TrimEnd(); 
            # endregion
            // 2006.01.27 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			//���������Ж��󎚋敪
//			this.billPrtSt.BillCoNmPrintOutCd	= this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex;
//			//��������s���󎚋敪
//			this.billPrtSt.BillBankNmPrintOut   =  this.BillBankNmPrintOut_tComboEditor.SelectedIndex;
			// 2006.01.27 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			

			// 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//���������Ж��󎚋敪
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            //if(this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex == 0)
            //{
            //    this.billPrtSt.BillCoNmPrintOutCd = 1;
            //}
            //else
            //{
            //    this.billPrtSt.BillCoNmPrintOutCd = 0;
            //}
            if (this.BillCoNmPrintOutCd_tComboEditor.SelectedItem != null)
                this.billPrtSt.BillCoNmPrintOutCd = (int)this.BillCoNmPrintOutCd_tComboEditor.SelectedItem.DataValue;
            // ----------------------------------------------------------------
			//��������s���󎚋敪
			if(this.BillBankNmPrintOut_tComboEditor.SelectedIndex == 0)
			{
				this.billPrtSt.BillBankNmPrintOut = 1;
			}
			else
			{
				this.billPrtSt.BillBankNmPrintOut = 0;
			}
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//���Ӑ�d�b�ԍ��󎚋敪
			this.billPrtSt.CustTelNoPrtDivCd    =  this.CustTelNoPrtDivCd_tComboEditor.SelectedIndex;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            ////�����E�v
            //this.billPrtSt.BillOutline1         = this.BillOutline1_tEdit.DataText.TrimEnd();
            //this.billPrtSt.BillOutline2         = this.BillOutline2_tEdit.DataText.TrimEnd();			
            # endregion

            // 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//�������ꎞ���f����
			//this.billPrtSt.BillPrtSuspendCnt    = TStrConv.StrToIntDef(this.BillPrtSuspendCnt_tNedit1.DataText, 0);  // DEL 2008/06/13		
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// �W���\��\�o�͋敪
            //if( this.ClctMnyPlnDocOutCd_tComboEditor.SelectedIndex < 0 ) {
            //    // ���I��
            //    this.billPrtSt.ClctMnyPlnDocOutCd = 0;
            //}
            //else {
            //    this.billPrtSt.ClctMnyPlnDocOutCd = ( int )this.ClctMnyPlnDocOutCd_tComboEditor.Value;
            //}

            //// �W���\��\�W���\��z�i����p�j
            //if( this.ClctMnyPlnDocVarCst_tComboEditor.SelectedIndex < 0 ) {
            //    // ���I��
            //    this.billPrtSt.ClctMnyPlnDocVarCst = 0;
            //}
            //else {
            //    this.billPrtSt.ClctMnyPlnDocVarCst = ( int )this.ClctMnyPlnDocVarCst_tComboEditor.Value;
            //}

            //// �W���\��\�o�̓^�C�v
            //if( this.ClctMnyPlnDocOutType_tComboEditor.SelectedIndex < 0 ) {
            //    // ���I��
            //    this.billPrtSt.ClctMnyPlnDocOutType = 0;
            //}
            //else {
            //    this.billPrtSt.ClctMnyPlnDocOutType = ( int )this.ClctMnyPlnDocOutType_tComboEditor.Value;
            //}
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

        }
		/// <summary>
		///	�����S�̐ݒ��ʏ���������
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʏ������������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void ScreenClear()
		{
			//�����ꗗ�\�o�͋敪
			this.BillTableOutCd_tComboEditor.SelectedIndex = 0;
			//������(���v)�o�͋敪
			this.TotalBillOutputDiv_tComboEditor.SelectedIndex = 0;
			//������(���ׁA�`�[���v)�o�͋敪
			this.DetailBillOutputCode_tComboEditor.SelectedIndex = 0;
            # region 2007.06.27  S.Koga  DEL
            ////�����O����o�͍���
            //this.BillBfRmonOutltem_tComboEditor.SelectedIndex = 0;
            ////����������ŏo�͋敪
            //this.BillConstTaxOutPutCd_tComboEditor.SelectedIndex = 0;
            # endregion

            //�����������󎚋敪
			this.BillLastDayPrtDiv_tComboEditor.SelectedIndex = 0;
            # region 2007.06.27  S.Koga  DEL
            ////���������Ѓv���e�N�g�������
            //this.BillEpProtectPrtNm1_tEdit.DataText  = "";
            //this.BillEpProtectPrtNm2_tEdit.DataText  = "";
            //this.BillEpProtectPrtNm3_tEdit.DataText  = "";
            //this.BillEpProtectPrtNm4_tEdit.DataText  = "";
            # endregion
            //���������Ж��󎚋敪
			this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex = 0;
			//��������s���󎚋敪
			this.BillBankNmPrintOut_tComboEditor.SelectedIndex = 0;
			
			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//���Ӑ�d�b�ԍ��󎚋敪
			this.CustTelNoPrtDivCd_tComboEditor.SelectedIndex = 0;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            ////�����E�v
            //this.BillOutline1_tEdit.DataText = "";
            //this.BillOutline2_tEdit.DataText = "";
            # endregion

            // 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//����������ꎞ���f����
			//this.BillPrtSuspendCnt_tNedit1.DataText = "";  // DEL 2008/06/13
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// �W���\��\�o�͋敪
            //this.ClctMnyPlnDocOutCd_tComboEditor.SelectedIndex   = 0;
            //// �W���\��\�W���\��z�i����p�j
            //this.ClctMnyPlnDocVarCst_tComboEditor.SelectedIndex  = 0;
            //// �W���\��\�o�̓^�C�v
            //this.ClctMnyPlnDocOutType_tComboEditor.SelectedIndex = 0;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

        }

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			int status = billPrtStAcs.Read(out this.billPrtSt, this._enterpriseCode);
			if (status == 0)
			{
				Mode_Label.Text = UPDATE_MODE;
				// �S�̏����\���ݒ�N���X��ʓW�J����
				BillPrtStToScreen();

				this.BillTableOutCd_tComboEditor.Focus();
			}
			//��ʂɕ\������������U�f�[�^�N���X�ɃZ�b�g
			ScreenTobillPrtSt();

			//��ʏ����r�p�N���[���ɃR�s�[����
			this._billPrtStClone = this.billPrtSt.Clone();

			return;
		}

		/// <summary>
		/// �f�[�^�ۑ���������
		/// </summary>
		/// <returns>�ۑ����ʁitrue:OK�^false:�G���[�݂�j</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�̓o�^�X�V�������s���܂�</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private bool DataSaveProc()
		{
			bool blRes = true;

			// ��ʂ��琿���S�̐ݒ�\���N���X�Ƀf�[�^���Z�b�g���܂��B
			ScreenTobillPrtSt();

			// �����S�̐ݒ�o�^����
			int status = this.billPrtStAcs.Write( ref billPrtSt);			
			if (status != 0)
			{
				if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			
					// ���[���X�V
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"SFUKK09080U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"���ɑ��[�����X�V����Ă��܂�",
//						"����",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return blRes = false;
				}
				else
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// �o�^���s
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKK09080U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"����������ݒ�", 					// �v���O��������
						"DataSaveProc", 					// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this.billPrtStAcs,	 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"�����S�̐ݒ�̓o�^�Ɏ��s���܂���",
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return blRes = false;
				}
			}
			Mode_Label.Text = UPDATE_MODE;
			return blRes;
		}
		#endregion

		# region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFUKK09080UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2005.08.06</br>
		/// </remarks>
		private void SFUKK09080UA_Load(object sender, System.EventArgs e)
		{
			// �{�^���̃A�C�R���̈ʒu��ݒ�
			ImageList imageList24 = IconResourceManagement.ImageList24;
			this.Ok_Button.ImageList		= imageList24;
			this.Cancel_Button.ImageList	= imageList24;
			this.Ok_Button.Appearance.Image		= Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image	= Size24_Index.CLOSE;
			// ��ʏ���������
			ScreenInitialSetting();
		}
		
		/// <summary>
		/// Timer.Tick �C�x���g(Initial_Timer.Tick)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///                  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///	                 �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}
		
		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFUKK09080UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23010 ���� �m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void SFUKK09080UA_VisibleChanged(object sender, System.EventArgs e)
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
			if (this._billPrtStClone != null)
			{
				return;
			}
			Initial_Timer.Enabled = true;

			ScreenClear();
		}

		/// <summary>
		///	Form.Closing �C�x���g(SFUKK09080UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note	   : �t�H�[�������O�ɁA���[�U�[���t�H�[�����
		///					 �悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void SFUKK09080UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._billPrtStClone = null;
			
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}
		
		/// <summary>
		///	Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///					 �������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			//�ۑ�����
			if (!DataSaveProc()) 
			{return;}

			DialogResult dialogResult = DialogResult.OK;

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}
		
			this.DialogResult = dialogResult;
			this._billPrtStClone = null;

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
		///	Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///					 �������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult dialogResult = DialogResult.Cancel;
		  
			//��ʏ����Ƃ肠�����Z�b�g
			ScreenTobillPrtSt();
		
			//�ύX�����邩�ǂ�������
			if (!_billPrtStClone.Equals(billPrtSt))
			{
				// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// �ۑ��m�F
				DialogResult result = TMsgDisp.Show( 
					this, 								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
					"SFUKK09080U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
					null, 								// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel );	// �\������{�^��
				// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			
//				result = MessageBox.Show( 
//					"�ҏW���̃f�[�^�����݂��܂�"+"\r\n"+"\r\n"+"�o�^���Ă���낵���ł����H",
//					"�ۑ��m�F",
//					MessageBoxButtons.YesNoCancel,
//					MessageBoxIcon.Question,
//					MessageBoxDefaultButton.Button1);
				// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				switch(result)
				{
						//�ۑ�����
					case DialogResult.Yes:
					{
						//�ۑ������֐�
						if (!DataSaveProc())
						{return;}
						dialogResult = DialogResult.OK;
						break;
					}
						//�������Ȃ�
					case DialogResult.Cancel:
					{
						// 2005.09.02 TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
						this.Cancel_Button.Focus();
						// 2005.09.02 TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
						return;
					}

						//�ۑ����Ȃ��ŏI��
					case DialogResult.No:
					{
						dialogResult = DialogResult.Cancel;
						break;
					}
					default:
					{ break;}
				}
			}

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;
			this._billPrtStClone = null;

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

        # region 2007.06.27  S.Koga  DEL
        ///// <summary>
        ///// TComboEditor.SelectionChanged �C�x���g (ClctMnyPlnDocOutType_tComboEditor)
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �o�̓^�C�v�R���{�{�b�N�X�̑I����Ԃ��ς�������ɔ������܂��B</br>
        ///// <br>Programmer : 23001 �H�R�@����</br>
        ///// <br>Date       : 2006.06.06</br>
        ///// </remarks>
        //private void ClctMnyPlnDocOutType_tComboEditor_SelectionChanged( object sender, EventArgs e )
        //{
        //    int selectedValue = 0;

        //    if( this.ClctMnyPlnDocOutType_tComboEditor.SelectedIndex >= 0 ) {
        //        selectedValue = ( int )this.ClctMnyPlnDocOutType_tComboEditor.Value;
        //    }

        //    switch( selectedValue ) {
        //        // �������^�C�v
        //        case 0:
        //        {
        //            // �W���\��z(����p)�𖳌��ɂ���
        //            this.ClctMnyPlnDocVarCst_tComboEditor.Enabled = false;
        //            break;
        //        }
        //        // ����^�C�v(�x�����ɍ��킹���W��)
        //        case 1:
        //        {
        //            // �W���\��z(����p)��L���ɂ���
        //            this.ClctMnyPlnDocVarCst_tComboEditor.Enabled = true;
        //            break;
        //        }
        //        default:
        //        {
        //            break;
        //        }
        //    }
        //}
        # endregion
        #endregion

    }
	
}
