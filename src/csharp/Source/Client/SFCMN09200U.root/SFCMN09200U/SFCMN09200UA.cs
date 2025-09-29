using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
//using Broadleaf.Resouces;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Management;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �v�����^�Ǘ������̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �v�����^�Ǘ����ݒ���s���܂��B
	///					 IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer : 97606 ���@�]���q</br>
	/// <br>Date       : 2005.03.22</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.27 22025 �c�� �L</br>
	/// <br>			�E�t���[���̍ŏ����Ή�</br>
	/// <br>Update Note: 2005.06.09 22025 �c�� �L</br>
	/// <br>			�E�t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX</br>
	/// <br>Update Note: 2005.06.13 22011 ���� ���l</br>
	/// <br>			�E���E�E�l�߂��œK��(�v���p�e�B�̕ύX�̂�)</br> 
	/// <br>Update Note: 2005.06.21 22011 ���� ���l</br>
	/// <br>			�E���x�����N���b�N���Ă��t�H�[�J�X�����x���Ɉڂ�Ȃ��悤�C��(�v���p�e�B�̕ύX�̂�)</br> 
	/// <br>			�E���l���ڂŃ[���̗}��(�v���p�e�B�̕ύX�̂�)</br> 
	/// <br>Update Note: 2005.06.23 22011 ���� ���l</br>
	/// <br>			�E���͕s���ڂ̕����F�����ɐݒ�(�v���p�e�B�̕ύX�̂�)</br>
	/// <br>			�E�t�H�[���ɖ��ʂȗ]�����������̂Ńf�U�C�i��Ńg���~���O</br>
	/// <br>			�E�����ނ̃R���{�{�b�N�X��MaxDropDownItems��18�ɕύX(�v���p�e�B�̕ύX�̂�)</br>	  
	/// <br>Update Note: 2005.06.24 22011 ���� ���l</br>
	/// <br>			�EtNEdit��ForeColer��Black�ɕύX(�v���p�e�B�̕ύX�̂�)</br>
	/// <br>			�EtNEdit��Text�ɒ��ڒl�������Ȃ��悤�ύX</br>
	/// <br>Update Note: 2005.07.01 22011 ���� ���l</br>
	/// <br>			�E���͕s���ڂ�IMEMode��Disable�ɕύX(�v���p�e�B�̕ύX�̂�)</br>
	/// <br>Update Note: 2005.07.02 22011 ���� ���l</br>
	/// <br>            �E�ŏ����Ή���V���W�b�N�ɕύX</br>
	/// <br>Update Note: 2005.07.06 22011 ���� ���l</br>
	/// <br>            �E�r������Ή�</br>
	/// <br>Update Note: 2005.07.07 22011 ���� ���l</br>
	/// <br>            �E�G���[�������N���[�Y�����ǉ�</br>
	/// <br>Update Note:2005.07.11 22011 ����</br> 
	/// <br>            NetAdvantege 2005 Vol.1�Ή�(���R���p�C��)</br>
	/// <br>Update Note:2005.07.12 22011 ����</br> 
	/// <br>            �r������̃��b�Z�[�W���C��</br>
	/// <br>Update Note:2005.09.14 22011 ����</br> 
	/// <br>            ���O�C�����擾���i�g�p</br>
	/// <br>Update Note:2005.09.20 22011 ����</br> 
	/// <br>            MessageBox��TMsgDisp�ɕύX</br>
	/// <br>Update Note:2005.09.26 22011 ����</br> 
	/// <br>            �폜�m�F�_�C�A���O�ŃL�����Z�����������ɍ폜�{�^���փt�H�[�J�X</br>
	/// <br>Update Note:2005.10.19 22011 ����</br> 
	/// <br>            �_�C�A���O�\����t���[�������̃E�B���h�E�̌��ɉ�肱�ތ��ۂւ̑Ή�</br> 
	/// <br></br>
	/// <br>Update Note : 2007.02.06 18322 T.Kimura MA.NS�p�ɕύX</br>
	/// <br>			:                           �E��ʃX�L���ύX�Ή�</br>
    /// <br>Update Note : 2007.04.02 20031 �É�</br>
    /// <br>			: �v�����^�Ǘ�No.�̃O���b�h�\���^�𕶎���(string)���琔�l(Int32)�ɕύX</br>
    /// <br>Update Note : 2008.06.10 30413 ����</br>
    /// <br>             �EPM.NS�Ή� (�v�����^��ނ����ڂ���폜)</br>
    /// </remarks>
	public class SFCMN09200UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel Guid_Label;
		private Broadleaf.Library.Windows.Forms.TEdit PrinterPort_tEdit;
		private Infragistics.Win.Misc.UltraLabel PrinterName_Title_Label;
        private Infragistics.Win.Misc.UltraLabel PrinterMngNo_Title_Label;
		private Broadleaf.Library.Windows.Forms.TComboEditor PrinterName_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel PrinterPort_Title_Label;
		private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TNedit PrinterMngNo_tNedit;
        private Infragistics.Win.Misc.UltraLabel PrinterKind_Title_Label;
        private TComboEditor PrinterKind_tComboEditor;
		private System.ComponentModel.IContainer components;
		# endregion

		#region Constractor
		/// <summary>
		/// �v�����^�Ǘ������̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ������̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public SFCMN09200UA()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint  = false;
			this._canClose  = false;
			this._canNew    = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose  = true;			// �f�t�H���g:true�Œ�
			this._defaultAutoFillToColumn = true;
			this._canSpecificationSearch = false;

			//�@��ƃR�[�h���擾����
			//2005.09.14 ---START
			//2005.09.14 this._enterpriseCode = "TBS1";	// �� �v�ύX
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			//2005.09.14 ---START

			// �ϐ�������
			this._dataIndex = -1;
			this._prtManageAcs = new PrtManageAcs();
			this._prevPrtManage = null;
			this._nextData = false;
			this._totalCount = 0;
			this._prtManageTable = new Hashtable();

			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// �ŏ�������p�t���O
			//2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

		}
		#endregion

		#region Dispose
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09200UA));
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.PrinterMngNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrinterName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrinterPort_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrinterPort_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrinterName_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PrinterMngNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PrinterKind_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrinterKind_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterPort_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterName_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterMngNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterKind_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(540, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 9;
            // 
            // Delete_Button
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.Delete_Button.Appearance = appearance2;
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(140, 200);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 3;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.Revive_Button.Appearance = appearance3;
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(265, 200);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 4;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.Ok_Button.Appearance = appearance4;
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(390, 200);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 5;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Button.Appearance = appearance5;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(515, 200);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 244);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(652, 23);
            this.ultraStatusBar1.TabIndex = 5;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // PrinterMngNo_Title_Label
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.PrinterMngNo_Title_Label.Appearance = appearance19;
            this.PrinterMngNo_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrinterMngNo_Title_Label.Location = new System.Drawing.Point(15, 50);
            this.PrinterMngNo_Title_Label.Name = "PrinterMngNo_Title_Label";
            this.PrinterMngNo_Title_Label.Size = new System.Drawing.Size(120, 24);
            this.PrinterMngNo_Title_Label.TabIndex = 10;
            this.PrinterMngNo_Title_Label.Text = "�v�����^�Ǘ�No";
            // 
            // Guid_Label
            // 
            this.Guid_Label.Location = new System.Drawing.Point(210, 50);
            this.Guid_Label.Name = "Guid_Label";
            this.Guid_Label.Size = new System.Drawing.Size(428, 25);
            this.Guid_Label.TabIndex = 8;
            this.Guid_Label.Visible = false;
            // 
            // PrinterName_Title_Label
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.PrinterName_Title_Label.Appearance = appearance18;
            this.PrinterName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrinterName_Title_Label.Location = new System.Drawing.Point(15, 85);
            this.PrinterName_Title_Label.Name = "PrinterName_Title_Label";
            this.PrinterName_Title_Label.Size = new System.Drawing.Size(120, 24);
            this.PrinterName_Title_Label.TabIndex = 11;
            this.PrinterName_Title_Label.Text = "�v�����^��";
            // 
            // PrinterPort_Title_Label
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.PrinterPort_Title_Label.Appearance = appearance13;
            this.PrinterPort_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrinterPort_Title_Label.Location = new System.Drawing.Point(15, 120);
            this.PrinterPort_Title_Label.Name = "PrinterPort_Title_Label";
            this.PrinterPort_Title_Label.Size = new System.Drawing.Size(120, 24);
            this.PrinterPort_Title_Label.TabIndex = 12;
            this.PrinterPort_Title_Label.Text = "�v�����^�p�X";
            // 
            // PrinterPort_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterPort_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterPort_tEdit.Appearance = appearance9;
            this.PrinterPort_tEdit.AutoSelect = true;
            this.PrinterPort_tEdit.DataText = "";
            this.PrinterPort_tEdit.Enabled = false;
            this.PrinterPort_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrinterPort_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 128, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PrinterPort_tEdit.Location = new System.Drawing.Point(140, 120);
            this.PrinterPort_tEdit.MaxLength = 128;
            this.PrinterPort_tEdit.Name = "PrinterPort_tEdit";
            this.PrinterPort_tEdit.Size = new System.Drawing.Size(469, 24);
            this.PrinterPort_tEdit.TabIndex = 2;
            // 
            // PrinterName_tComboEditor
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterName_tComboEditor.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterName_tComboEditor.Appearance = appearance15;
            this.PrinterName_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrinterName_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrinterName_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrinterName_tComboEditor.ItemAppearance = appearance16;
            this.PrinterName_tComboEditor.Location = new System.Drawing.Point(140, 85);
            this.PrinterName_tComboEditor.MaxDropDownItems = 18;
            this.PrinterName_tComboEditor.Name = "PrinterName_tComboEditor";
            this.PrinterName_tComboEditor.Size = new System.Drawing.Size(480, 24);
            this.PrinterName_tComboEditor.TabIndex = 1;
            this.PrinterName_tComboEditor.ValueChanged += new System.EventHandler(this.PrinterName_tComboEditor_ValueChanged);
            // 
            // PrinterMngNo_tNedit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            this.PrinterMngNo_tNedit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            this.PrinterMngNo_tNedit.Appearance = appearance7;
            this.PrinterMngNo_tNedit.AutoSelect = true;
            this.PrinterMngNo_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrinterMngNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrinterMngNo_tNedit.DataText = "";
            this.PrinterMngNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrinterMngNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PrinterMngNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrinterMngNo_tNedit.Location = new System.Drawing.Point(140, 50);
            this.PrinterMngNo_tNedit.MaxLength = 4;
            this.PrinterMngNo_tNedit.Name = "PrinterMngNo_tNedit";
            this.PrinterMngNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PrinterMngNo_tNedit.Size = new System.Drawing.Size(43, 24);
            this.PrinterMngNo_tNedit.TabIndex = 0;
            // 
            // PrinterKind_Title_Label
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.PrinterKind_Title_Label.Appearance = appearance17;
            this.PrinterKind_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrinterKind_Title_Label.Location = new System.Drawing.Point(12, 155);
            this.PrinterKind_Title_Label.Name = "PrinterKind_Title_Label";
            this.PrinterKind_Title_Label.Size = new System.Drawing.Size(120, 24);
            this.PrinterKind_Title_Label.TabIndex = 13;
            this.PrinterKind_Title_Label.Text = "�v�����^���";
            // 
            // PrinterKind_tComboEditor
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterKind_tComboEditor.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterKind_tComboEditor.Appearance = appearance11;
            this.PrinterKind_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrinterKind_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrinterKind_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrinterKind_tComboEditor.ItemAppearance = appearance12;
            this.PrinterKind_tComboEditor.Location = new System.Drawing.Point(140, 155);
            this.PrinterKind_tComboEditor.MaxDropDownItems = 2;
            this.PrinterKind_tComboEditor.Name = "PrinterKind_tComboEditor";
            this.PrinterKind_tComboEditor.Size = new System.Drawing.Size(175, 24);
            this.PrinterKind_tComboEditor.TabIndex = 14;
            // 
            // SFCMN09200UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(652, 267);
            this.Controls.Add(this.PrinterKind_tComboEditor);
            this.Controls.Add(this.PrinterKind_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.PrinterMngNo_tNedit);
            this.Controls.Add(this.PrinterPort_tEdit);
            this.Controls.Add(this.PrinterName_tComboEditor);
            this.Controls.Add(this.PrinterPort_Title_Label);
            this.Controls.Add(this.PrinterName_Title_Label);
            this.Controls.Add(this.Guid_Label);
            this.Controls.Add(this.PrinterMngNo_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09200UA";
            this.Text = "�v�����^�ݒ�";
            this.Load += new System.EventHandler(this.SFCMN09200UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09200UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09200UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterPort_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterName_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterMngNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterKind_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

		#region Private Members
		private PrtManageAcs _prtManageAcs;
		private PrtManage _prevPrtManage;
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _prtManageTable;
		private PrtManage _prtManageClone;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
		// �ŏ�������p�t���O
		//2005.07.02 private bool _minFlg;
		private int _indexBuf;
		//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
		// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE		= "�폜��";
		private const string PRINTERMNGNO_TITLE	= "�v�����^�Ǘ�No";
		private const string PRINTERNAME_TITLE	= "�v�����^��";
		private const string PRINTERPORT_TITLE	= "�v�����^�p�X";
        private const string PRINTERKIND_TITLE = "�v�����^���";
        // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
		//private const string PRINTERKIND_TITLE	= "���";
        // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
		private const string GUID_TITLE			= "GUID";
		private const string PRTMANAGE_TABLE	= "PRTMANAGE";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

        // �� 20070206 18322 a MA.NS�p�ɕύX
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // �� 20070206 18322 a

		// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
		private const string PGID = "SFCMN9200U";
		// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09200UA());
		}

		#region Property
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

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾���܂��B</value>
		public bool CanSpecificationSearch
		{
			get{ return this._canSpecificationSearch; }
		}
		#endregion
 
		#region Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = PRTMANAGE_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList prtManageList = null;

//			if (readCount == 0)
//			{
				// ���݂̎������擾 �y�f�o�b�O�p�z
				//				DateTime t1 = DateTime.Now;

				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
				status = this._prtManageAcs.SearchAll(
					out prtManageList,
					this._enterpriseCode);

				// �|���������Ԃ�\�� �y�f�o�b�O�p�z
				//				float ms = (float)DateTime.Now.Subtract(t1).TotalMilliseconds;
				//				ultraStatusBar1.Text = ms.ToString() + "�_�b";

				this._totalCount = prtManageList.Count;
//			}
/*************************************************************************************************
			// �����w�茟���̋@�\���O�� 2005.04.28 M.Ito
			else
			{
				status = this._prtManageAcs.SearchSpecificationAllPrtManage(
					out prtManageList,
					out this._totalCount,
					out this._nextData,
					this._enterpriseCode,
					readCount,
					this._prevPrtManage);
			}
 *************************************************************************************************/
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( prtManageList.Count > 0 ) {
						// �ŏI�̃v�����^�Ǘ��I�u�W�F�N�g��ޔ�����
						this._prevPrtManage = ((PrtManage)prtManageList[prtManageList.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PrtManage prtManage in prtManageList)
					{
						PrtManageToDataSet(prtManage.Clone(), index);
						++index;
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					if(ExclusiveControl(status) == false)
					{
						break;
					}
					// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
						"�G���[",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
						2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "�v�����^�Ǘ����ݒ�", "Search",TMsgDisp.OPE_READ,
						"�ǂݍ��݂Ɏ��s���܂����B",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					CloseUI();
					//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
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
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			int dummy = 0;
			ArrayList prtManages = null;

			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._prtManageAcs.SearchSpecificationAll(
				out prtManages,
				out dummy,
				out this._nextData, 
				this._enterpriseCode,
				readCount,
				this._prevPrtManage);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( prtManages.Count > 0 ) {
						// �ŏI�̃v�����^�Ǘ��N���X��ޔ�����
						this._prevPrtManage = ((PrtManage)prtManages[prtManages.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PrtManage prtManage in prtManages)
					{
						index = this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Count;
						PrtManageToDataSet(prtManage.Clone(), index);
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					if(ExclusiveControl(status) == false)
					{
						break;
					}
					// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
						"�G���[",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "�v�����^�Ǘ����ݒ�", "SearchNext",TMsgDisp.OPE_READ,
						"�ǂݍ��݂Ɏ��s���܂����B",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					
					//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					CloseUI();
					//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
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
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Delete()
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PrtManage prtManage = (PrtManage)this._prtManageTable[guid];

			int status = this._prtManageAcs.LogicalDelete(ref prtManage);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				if(ExclusiveControl(status) == false)
				{
					return status;
				}
				// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				/* 2005.09.20
				    MessageBox.Show(
					"�폜�Ɏ��s���܂����B st = " + status.ToString(),
					"�G���[",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
				2005.09.20 */
				TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
					PGID, "�v�����^�Ǘ����ݒ�", "Delete",TMsgDisp.OPE_DELETE,
					"�폜�Ɏ��s���܂����B",status,
					"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

				//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				CloseUI();
				//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				return status;
			}

			status = this._prtManageAcs.Read(out prtManage, prtManage.EnterpriseCode, prtManage.PrinterMngNo);

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				if(ExclusiveControl(status) == false)
				{
					return status;
				}
				// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				/* 2005.09.20
				MessageBox.Show(
					"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
					"�G���[",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
					2005.09.20 */
				TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
					PGID, "�v�����^�Ǘ����ݒ�", "Delete",TMsgDisp.OPE_DELETE,
					"�ǂݍ��݂Ɏ��s���܂����B",status,
					"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				CloseUI();
				//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				return status;
			}

			PrtManageToDataSet(prtManage.Clone(), this._dataIndex);

			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
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
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth,ContentAlignment.MiddleLeft,"",Color.Red));
//			appearanceTable.Add(PRINTERMNGNO_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));	// 2005.06.09 TOUMA DEL �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(PRINTERMNGNO_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(PRINTERNAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(PRINTERPORT_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            appearanceTable.Add(PRINTERKIND_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
			//appearanceTable.Add(PRINTERKIND_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// �v�����^�Ǘ��I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ��N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrtManageToDataSet(PrtManage prtManage, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[PRTMANAGE_TABLE].NewRow();
				this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Count - 1;

				// ��������ƁA
				// ���C���t���[�����ŕ��������̒��o�r���Ŏq��ʂ��Ăяo����
				// �I�������s�łȂ����o�ŏI�s���Ăяo�����
				//this.DataIndex = index;
			}

			if (prtManage.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][DELETE_DATE] = prtManage.UpdateDateTimeJpInFormal;
			}

			this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERMNGNO_TITLE] = prtManage.PrinterMngNo.ToString();
			this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERNAME_TITLE]  = prtManage.PrinterName;
			this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERPORT_TITLE]  = prtManage.PrinterPort;
            if (prtManage.PrinterKind == 0)
                this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERKIND_TITLE] = "���[�U�[�v�����^";
            else
                this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERKIND_TITLE] = "�h�b�g�v�����^";
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
			//this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERKIND_TITLE]  = prtManage.DefaultSvfCtlName;
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
			this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][GUID_TITLE] = prtManage.FileHeaderGuid;
			//
			if (this._prtManageTable.ContainsKey(prtManage.FileHeaderGuid) == true)
			{
				this._prtManageTable.Remove(prtManage.FileHeaderGuid);
			}
			this._prtManageTable.Add(prtManage.FileHeaderGuid, prtManage);
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable prtManageTable = new DataTable(PRTMANAGE_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			prtManageTable.Columns.Add(DELETE_DATE, typeof(string));
            //2007.04.02  S.Koga  amend ------------------------------------------------------------------------
			//prtManageTable.Columns.Add(PRINTERMNGNO_TITLE, typeof(string));
            prtManageTable.Columns.Add(PRINTERMNGNO_TITLE, typeof(Int32));
            // -------------------------------------------------------------------------------------------------
			prtManageTable.Columns.Add(PRINTERNAME_TITLE, typeof(string));
			prtManageTable.Columns.Add(PRINTERPORT_TITLE, typeof(string));
            prtManageTable.Columns.Add(PRINTERKIND_TITLE, typeof(string));
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
			//prtManageTable.Columns.Add(PRINTERKIND_TITLE, typeof(string));
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
			prtManageTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(prtManageTable);
		}

		private System.Management.ManagementObjectSearcher _mos;
		private System.Management.ManagementObjectCollection _moc;
		private Hashtable _printerInfoTable = new Hashtable();

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			this.PrinterName_tComboEditor.Items.Clear();
            this.PrinterKind_tComboEditor.Items.Clear();
			// �v�����^�[����WIN32�̃N�G�����g���Ď擾
			_mos = new System.Management.ManagementObjectSearcher("Select * from Win32_Printer");
			_moc = _mos.Get();
		
			// �v�����^��񋓂���
			foreach(System.Management.ManagementObject mo in _moc)
			{
				// �v�����^���ꎞ�i�[�pHashtable
				Hashtable wkprt = new Hashtable();
		
				// ����
                wkprt.Add("Name", mo["Name"]);
				// ���
				wkprt.Add("Status",mo["Status"]);
				// �|�[�g�ԍ�
				wkprt.Add("PortName",mo["PortName"]);
//				// �L���v�V����
//				wkprt.Add("Caption",mo["Caption"]);
//				// �f�B�X�N���v�V����
//				wkprt.Add("Description",mo["Description"]);
//				// �h���C�o�h�c
//				wkprt.Add("DeviceID",mo["DeviceID"]);
//				// �h���C�o����
//				wkprt.Add("DriverName",mo["DriverName"]);
//				// �ꏊ
//				wkprt.Add("Location",mo["Location"]);
//				// �v�����^���
//				wkprt.Add("PrinterState",mo["PrinterState"]);
//				// �T�[�o�[����
//				wkprt.Add("SeverName",mo["ServerName"]);
//				// ���L����
//				wkprt.Add("ShareName",mo["ShareName"]);
//				// ��ԏ��
//				wkprt.Add("StatusInfo",mo["StatusInfo"]);
		
				//
				_printerInfoTable.Add(mo["Name"],wkprt);
				// �R���{�{�b�N�X�ɒǉ�
				PrinterName_tComboEditor.Items.Add(mo["Name"]);

                if (PrinterKind_tComboEditor.Items.Count == 0)
                {
                    // �R���{�{�b�N�X�ɒǉ�
                    PrinterKind_tComboEditor.Items.Add("���[�U�[�v�����^");
                    PrinterKind_tComboEditor.Items.Add("�h�b�g�v�����^");
                    PrinterKind_tComboEditor.MaxDropDownItems = PrinterKind_tComboEditor.Items.Count;
                }
//				// �f�t�H���g�̃v�����^�����ׂ�
//				if ((((uint) mo["Attributes"]) & 4) == 4)
//				{
//					// �R���{��Text�Ƀf�t�H���g�̃v�����^����\��
//					PrinterName_tComboEditor.Text = mo["Name"].ToString();
//				}
			}
			if (PrinterName_tComboEditor.Items.Count > 0)
				this.PrinterName_tComboEditor.MaxDropDownItems = PrinterName_tComboEditor.Items.Count;

            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
			// �v�����^���
			//PrtManage prtManageTemp = new PrtManage();
			//this.PrinterKind_tComboEditor.Items.Clear();
			//foreach (string code in PrtManage.PrinterKindCodes)
			//	this.PrinterKind_tComboEditor.Items.Add(code, prtManageTemp.GetPrinterKindName(code));
			//if (PrinterKind_tComboEditor.Items.Count > 0)
			//	this.PrinterKind_tComboEditor.MaxDropDownItems = PrinterKind_tComboEditor.Items.Count;
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END

			// �{�^���̈ʒu�𒲐�����
			// �I���{�^���̉�ʃf�U�C���̈ʒu����v�Z����
			System.Drawing.Point buttonLocation = this.Cancel_Button.Location;
			buttonLocation.X -= this.Cancel_Button.Size.Width;
			this.Ok_Button.Location = buttonLocation;
			this.Revive_Button.Location = buttonLocation;
			buttonLocation.X -= this.Cancel_Button.Size.Width;
			this.Delete_Button.Location = buttonLocation;
		}

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// <br>Update Note: 2005.06.24 22011 ���� ���l</br>
		/// <br>			�EtNEdit��Text�ɒ��ڒl�������Ȃ��悤�ύX</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.Guid_Label.Text = "";	
			// 2005.06.24 ���� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// 2005.06.24 this.PrinterMngNo_tNedit.Text = "";							
			this.PrinterMngNo_tNedit.SetInt(0);							
			// 2005.06.24 ���� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			this.PrinterName_tComboEditor.Text = "";
			this.PrinterPort_tEdit.Text = "";
            this.PrinterKind_tComboEditor.Text = "";
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
			//this.PrinterKind_tComboEditor.Text = "";
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			PrtManage prtManage;
			if (this._dataIndex < 0)
			{
				prtManage = new PrtManage();			
				// �o�^���[�h
				this.Mode_Label.Text = INSERT_MODE;
				//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;
				//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			
				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				this.PrinterMngNo_tNedit.Enabled = true;
				this.PrinterMngNo_tNedit.Focus();

				ScreenInputPermissionControl(true);

			}
			else
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				prtManage = (PrtManage)this._prtManageTable[guid];
				PrtManageToScreen(prtManage);

				if (prtManage.LogicalDeleteCode == 0)
				{
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					this.Ok_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					ScreenInputPermissionControl(true);
					
					// �X�V���[�h�̏ꍇ�́A�v�����^�Ǘ��R�[�h�̂ݓ��͕s�Ƃ���
					this.PrinterMngNo_tNedit.Enabled = false;
					this.PrinterName_tComboEditor.Focus();
					//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;
					//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			
				}
				else
				{
					// �폜���[�h
					this.Mode_Label.Text = DELETE_MODE;

					this.Ok_Button.Visible = false;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;

					ScreenInputPermissionControl(false);
					//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;
					//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					this.Delete_Button.Focus();
				}
			}
			// �V�K�̖����͏�Ԃ��o�b�N�A�b�v
			this._prtManageClone = prtManage.Clone();
			DispToPrtManage(ref this._prtManageClone);
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = this._dataIndex;
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
			this.PrinterMngNo_tNedit.Enabled = enabled;
			this.PrinterName_tComboEditor.Enabled = enabled;

            this.PrinterKind_tComboEditor.Enabled = enabled;
//			this.PrinterPort_tEdit.Enabled = enabled;
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
			//this.PrinterKind_tComboEditor.Enabled = enabled;
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
		}

		/// <summary>
		/// �v�����^�Ǘ��N���X��ʓW�J����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ��I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrtManageToScreen(PrtManage prtManage)
		{
			this.Guid_Label.Text = prtManage.FileHeaderGuid.ToString();
			this.PrinterMngNo_tNedit.SetInt( prtManage.PrinterMngNo );
            this.PrinterName_tComboEditor.Value = prtManage.PrinterName;
            if( prtManage.PrinterKind == 0)
            this.PrinterKind_tComboEditor.Value = "���[�U�[�v�����^";
            else
                this.PrinterKind_tComboEditor.Value = "�h�b�g�v�����^";
			this.PrinterPort_tEdit.Text = prtManage.PrinterPort;
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
			//this.PrinterKind_tComboEditor.Value = prtManage.DefaultSvfCtlCode;
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
		}

		/// <summary>
		/// ��ʏ��v�����^�Ǘ��N���X�i�[����
		/// </summary>
		/// <param name="prtManage">�v�����^�Ǘ��I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�v�����^�Ǘ��I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void DispToPrtManage(ref PrtManage prtManage)
		{
			if (prtManage == null)
			{
				// �V�K�̏ꍇ
				prtManage = new PrtManage();
			}

			prtManage.EnterpriseCode		= this._enterpriseCode;								//��ƃR�[�h				�� �v�ύX
			prtManage.PrinterMngNo			= this.PrinterMngNo_tNedit.GetInt();				//�v�����^�Ǘ�No
			prtManage.PrinterName			= this.PrinterName_tComboEditor.Text;				//�v�����^��
			prtManage.PrinterPort			= this.PrinterPort_tEdit.Text;						//�v�����^�|�[�g�i�p�X�j
            if (this.PrinterKind_tComboEditor.Text == "���[�U�[�v�����^")
                prtManage.PrinterKind = 0;
            else
                prtManage.PrinterKind = 1;
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
			//if(this.PrinterKind_tComboEditor.SelectedIndex < 0)
			//{
			//	prtManage.DefaultSvfCtlCode = "";
			//	prtManage.ImgPrtSvfCtlCode  = "";
			//}
			//else
			//{
			//	prtManage.DefaultSvfCtlCode	= (string)this.PrinterKind_tComboEditor.SelectedItem.DataValue;	//SVF����R�[�h�i�f�t�H���g�l�j
			//	prtManage.ImgPrtSvfCtlCode	= (string)this.PrinterKind_tComboEditor.SelectedItem.DataValue;	//SVF����R�[�h�i�C���[�W����j
			//}
			//prtManage.SvfCtlCodeUseCode		= 0;	//SVF����R�[�h�g�p�敪 0:�f�t�H���g,1:�C���[�W
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
		}

		/// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			if (this.PrinterMngNo_tNedit.GetInt() == 0)
			{
				control = this.PrinterMngNo_tNedit;
				message = this.PrinterMngNo_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
			else if (this.PrinterName_tComboEditor.Text.Trim() == "")
			{
				control = this.PrinterName_tComboEditor;
				message = this.PrinterName_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
            else if (this.PrinterKind_tComboEditor.Text.Trim() == "")
            {
                control = this.PrinterKind_tComboEditor;
                message = this.PrinterKind_Title_Label.Text + "����͂��ĉ������B";
                result = false;
            }
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 >>>>>>START
            //else if (this.PrinterKind_tComboEditor.SelectedIndex < 0)
            //{
            //	control = this.PrinterKind_tComboEditor;
            //	message = this.PrinterKind_Title_Label.Text + "����͂��ĉ������B";
            //	result = false;
            //}
            // 2008.06.10 30413 ���� �v�����^��ނ̍폜 <<<<<<END
            else
            {
                // �d���`�F�b�N
                foreach (PrtManage prtManage in _prtManageTable.Values)
                {
                    if ((this.DataIndex < 0) ||
                       ((this.DataIndex >= 0) &&
                        (prtManage.FileHeaderGuid != (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE])))
                    {
                        if (PrinterName_tComboEditor.SelectedItem.DisplayText == prtManage.PrinterName)
                        {
                            control = this.PrinterName_tComboEditor;
                            message = "�����v�����^�͓o�^�ł��܂���";
                            result = false;
                            break;
                        }
                    }
                }
            }

			return result;
		}

		/// <summary>
		/// �v�����^�ݒ���o�^
		/// </summary>
		/// <param name="control">�t�H�[�J�X�Z�b�g�R���g���[��(�G���[��)</param>
		/// <returns>�o�^OK/�o�^NG</returns>
		private bool RegistData(out Control control)
		{
			control = null;

			// ���̓`�F�b�N
			string message = null;
			if (!ScreenDataCheck(ref control, ref message))
			{
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				/*2005.09.20
				MessageBox.Show(message,		
					"���̓`�F�b�N",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
					2005.09.20*/
				TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
					PGID,message,0,MessageBoxButtons.OK);
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

				control.Focus();
				return false;
			}
			PrtManage prtManage = null;
			if (this._dataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				prtManage = ((PrtManage)this._prtManageTable[guid]).Clone();
			}

			DispToPrtManage(ref prtManage);

			int status = this._prtManageAcs.Write(ref prtManage);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"���̃v�����^�Ǘ��R�[�h�͊��Ɏg�p����Ă��܂��B",
						"���",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
						PGID,"���̃v�����^�Ǘ��R�[�h�͊��Ɏg�p����Ă��܂��B",status,MessageBoxButtons.OK);
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					control = this.PrinterMngNo_tNedit;
					control.Focus();
					return false;
				}
				default:
				{
					// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					if(ExclusiveControl(status) == false)
					{
						return false;
					}
					// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"�o�^�Ɏ��s���܂����B st = " + status.ToString(),
						"�G���[",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "�v�����^�Ǘ����ݒ�", "RegistData",TMsgDisp.OPE_UPDATE,
						"�ǂݍ��݂Ɏ��s���܂����B",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

					//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					CloseUI();
					//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					return false;
				}
			}

			PrtManageToDataSet(prtManage, this._dataIndex);

			return true;
		}

		/// <summary>
		/// �I���O�ҏW���`�F�b�N
		/// </summary>
		/// <param name="control">�o�^�`�F�b�NNG���̃t�H�[�J�X�ړ���</param>
		/// <returns>true:�I����/false:�I���s��</returns>
		/// <remarks>
		/// <br>Note       : �q��ʏI�����ɕҏW���Ȃ�o�^�m�F���s��</br>
		/// <br>Programmer : 99032 �ɓ� ���I</br>
		/// <br>Date       : 2005.04.28</br>
		/// </remarks>
		private bool CheckEditingClose(out Control control)
		{
			control = null;
			bool closeOK = true;

			// ���͏�Ԃ��擾
			PrtManage comparePrtManage = new PrtManage();
			comparePrtManage = this._prtManageClone.Clone();
			DispToPrtManage(ref comparePrtManage);
			// ���͏�Ԃ�������ԂƔ�r
			if(this._prtManageClone.Equals(comparePrtManage) == false)
			{
				// �ҏW��
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				/* 2005.09.20
				switch (MessageBox.Show("�ҏW���̃f�[�^�����݂��܂�\r\n\r\n�o�^���Ă���낵���ł����H",
										"�ۑ��m�F",
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Question))
				2005.09.20 */
				switch(TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_QUESTION,
					PGID,"�ҏW���̃f�[�^�����݂��܂�\r\n\r\n�o�^���Ă���낵���ł����H",0,MessageBoxButtons.YesNoCancel))
						// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				{
					case DialogResult.Yes:
					{
						// �o�^����
						if(RegistData(out control) == false)   {closeOK = false;}

						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						break;
					}
					case DialogResult.Cancel:
					{
						// Close�L�����Z��
						closeOK = false;

                        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                        //this.Cancel_Button.Focus();
                        if (_modeFlg)
                        {
                            control = PrinterMngNo_tNedit;
                            _modeFlg = false;
                        }
                        else
                        {
                            this.Cancel_Button.Focus();
                        }
                        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
							UnDisplaying(this, me);
						}
						
						break;
					}
				}
			}
			return closeOK;
		}


		// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
		/// <summary>
		///	�r�����䏈��
		/// </summary>
		/// <remarks>
		/// <br>Programmer		:	���� ���l</br>
		/// <br>Note            :   �c�a�ɔr�����䂪�|�����Ă����ۂɃ��b�Z�[�W��\����UI��ʂ����</br>
		/// <br>Date			:	2005.07.06</br>
		/// </remarks>
		private bool ExclusiveControl(int Status)
		{
			// ���ɍX�V���|�����Ă����Ƃ�
			if(Status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
			{
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				// 2005.09.20MessageBox.Show(
				// 2005.09.20	"���ɑ��[�����X�V����Ă��܂�",
				// 2005.09.20	"����",
				// 2005.09.20	MessageBoxButtons.OK,
				// 2005.09.20	MessageBoxIcon.Exclamation,
				// 2005.09.20	MessageBoxDefaultButton.Button1);
				TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
					PGID, "���ɑ��[�����X�V����Ă��܂�", 0, MessageBoxButtons.OK);

				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				CloseUI();	
				return false;
			}
			// ���ɍ폜����Ă����Ƃ�
			if(Status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
			{
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				// 2005.09.20 MessageBox.Show(
				// 2005.09.20 	"���ɑ��[���ō폜����Ă��܂�",
				// 2005.09.20 	"����",
				// 2005.09.20 	MessageBoxButtons.OK,
				// 2005.09.20 	MessageBoxIcon.Exclamation,
				// 2005.09.20 	MessageBoxDefaultButton.Button1);
				TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
					PGID, "���ɑ��[���ō폜����Ă��܂�", 0, MessageBoxButtons.OK);
				// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				CloseUI();
				return false;
			}
			return true;
		}

		// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

		//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
		/// <summary>
		///	UI��ʏI������
		/// </summary>
		/// <remarks>
		/// <br>Programmer		:	���� ���l</br>
		/// <br>Note            :   UI��ʂ����</br>
		/// <br>Date			:	2005.07.06</br>
		/// </remarks>
		private void CloseUI()
		{
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}
		//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

		#endregion

		#region Events
		/// <summary>
		/// Form.Load �C�x���g(SFCMN09200UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void SFCMN09200UA_Load(object sender, System.EventArgs e)
		{
            // �� 20070206 18322 a MA.NS�p�ɕύX
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            // �� 20070206 18322 a

            // ���̃J�[�\����ێ�
			Cursor preCursor = Cursor.Current;
			// �J�[�\���������v�ɂ���
			Cursor.Current = Cursors.WaitCursor;

			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList     = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
			this.Delete_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();

			// �J�[�\����߂�
			Cursor.Current = preCursor;

		}

		/// <summary>
		/// Form.Closing �C�x���g(SFCMN09200UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void SFCMN09200UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// �ŏ�������t���O�̏�����
			//2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;

				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFCMN09200UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void SFCMN09200UA_VisibleChanged(object sender, System.EventArgs e)
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
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			
			
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
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			Control control = null;

			if(RegistData(out control) == false)
			{
				return;
			}
/*************************************************************************************************
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				MessageBox.Show(
					message,
					"���̓`�F�b�N",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);

				control.Focus();
				return;
			}

			PrtManage prtManage = null;
			if (this._dataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				prtManage = (PrtManage)this._prtManageTable[guid];
			}

			DispToPrtManage(ref prtManage);

			int status = this._prtManageAcs.Write(ref prtManage);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					MessageBox.Show(
						"���̃v�����^�Ǘ��R�[�h�͊��Ɏg�p����Ă��܂��B",
						"���",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1);
					this.PrinterMngNo_tNedit.Focus();
					return;
				}
				default:
				{
					MessageBox.Show(
						"�o�^�Ɏ��s���܂����B st = " + status.ToString(),
						"�G���[",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
					return;
				}
			}

			PrtManageToDataSet(prtManage, this._dataIndex);
 *************************************************************************************************/

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			// �o�^���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				this._dataIndex = -1;

				ScreenClear();
				this.PrinterMngNo_tNedit.Focus();
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

				// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				// �ŏ�������t���O�̏�����
				// 2005.07.02 this._minFlg = false;
				this._indexBuf = -2;
				//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �ҏW���Ȃ�o�^�m�F��\��
			Control control;
			Control nowFocusd = this.ActiveControl;
			if(CheckEditingClose(out control) == false)   
			{
				if(control == null)   {nowFocusd.Focus();}
				else                  {control.Focus();}
				return;
			}
			
			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// �ŏ�������t���O�̏�����
			// 2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			this.DialogResult = DialogResult.Cancel;

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
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			/* 2005.09.20
			DialogResult result = MessageBox.Show(
				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
				"�폜�m�F",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Exclamation,
				MessageBoxDefaultButton.Button2);
			2005.09.20 */
			DialogResult result = TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
				PGID,"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",0,MessageBoxButtons.OKCancel,
				MessageBoxDefaultButton.Button2);
			// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

			if (result == DialogResult.OK)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				PrtManage prtManage = (PrtManage)this._prtManageTable[guid];

				int status = this._prtManageAcs.Delete(prtManage);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex].Delete();
						this._prtManageTable.Remove(guid);
						break;
					}
					default:
					{
						// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
						if(ExclusiveControl(status) == false)
						{
							return;
						}
						// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
						
						// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
						/* 2005.09.20
						MessageBox.Show(
							"�폜�Ɏ��s���܂����B st = " + status.ToString(),
							"�G���[",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1);
						2005.09.20 */
						TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
							PGID, "�v�����^�Ǘ����ݒ�", "Delete_Button_Click",TMsgDisp.OPE_DELETE,
							"�폜�Ɏ��s���܂����B",status,
							"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
						// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

						//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
						CloseUI();
						//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
						return;
					}
				}
			}
			else
			{
				// 2005.09.26 >>>>>>>>>>>>>>>>>>>>>>>>>>START
				Delete_Button.Focus();
				// 2005.09.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// �ŏ�������t���O�̏�����
			// 2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			this.DialogResult = DialogResult.OK;

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
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PrtManage prtManage = (PrtManage)this._prtManageTable[guid];

			int status = this._prtManageAcs.Revival(ref prtManage);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"���Ƀf�[�^�����S�폜����Ă��܂��B" + status.ToString(),
						"���",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "�v�����^�Ǘ����ݒ�", "Revive_Button_Click",TMsgDisp.OPE_UPDATE,
						"���Ƀf�[�^�����S�폜����Ă��܂��B",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					break;
				}
				default:
				{
					// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					if(ExclusiveControl(status) == false)
					{
						break;
					}
					// 2005.07.06 ���� �r������Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"�����Ɏ��s���܂����B st = " + status.ToString(),
						"�G���[",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "�v�����^�Ǘ����ݒ�", "Revive_Button_Click",TMsgDisp.OPE_UPDATE,
						"�����Ɏ��s���܂����B",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 ���� MsgDisp�Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

					//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					CloseUI();
					//2005.07.07 ���� �G���[�������N���[�Y�����ǉ�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			PrtManageToDataSet(prtManage, this._dataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// �ŏ�������t���O�̏�����
			// 2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 ���� �V�t���[���ŏ����Ή�>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			this.DialogResult = DialogResult.OK;

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
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		/// PrinterName_tComboEditor_ValueChanged �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �v�����^����I���������A�v�����^�|�[�g��\�����܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrinterName_tComboEditor_ValueChanged(object sender, System.EventArgs e)
		{
			if(PrinterName_tComboEditor.Text == null)   return;      // �ŏ������e�t�H�[���ŏ������e�t�H�[���\���� Text=null �ő����Ă��܂��̂�

			Hashtable ht = (Hashtable)_printerInfoTable[PrinterName_tComboEditor.Text.Trim()];
			if (ht != null)
				PrinterPort_tEdit.Text = (string)ht["PortName"];
		}
		#endregion

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ChanageFocus �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "PrinterMngNo_tNedit":
                    {
                        // �v�����^�Ǘ�No.
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = PrinterMngNo_tNedit;
                            }
                        }
                        break;
                    }
            }
        }
        
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �v�����^�Ǘ�No.
            int printerMngNo = PrinterMngNo_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsPrinterMngNo = (int)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[i][PRINTERMNGNO_TITLE];
                if (printerMngNo == dsPrinterMngNo)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PGID,						            // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̃v�����^�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �v�����^�Ǘ�No.�̃N���A
                        PrinterMngNo_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PGID,                                   // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̃v�����^�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // �v�����^�Ǘ�No.�̃N���A
                                PrinterMngNo_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
	}
}
