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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���[�p���ݒ�����̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�p���ݒ���ݒ���s���܂��B
	///					 IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer : 97606 ���@�]���q</br>
	/// <br>Date       : 2005.03.22</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.28 22025 �c�� �L</br>
	/// <br>					�E�t���[���̍ŏ����Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.09 22024 ����@�_�u</br>
	/// <br>					�EView�́u/�~���v���u/10�~���v�ɏC��</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.09 22025 �c�� �L</br>
	/// <br>					�E�t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.13 22025 �c�� �L</br>
	/// <br>					�EUI�q��ʊe���ڂ̍��A�E�l�ߍœK���Ή�</br>
	/// <br>					�E�t���[���O���b�h�́u�v���r���[�敪�v�̕\�����e����A�C���f�b�N�X�̔ԍ����\��</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.18 22025 �c�� �L</br>
	/// <br>					�EForeColorDisabled��BackColorDisabled�̐ݒ�Ή�</br>
	/// <br>Update Note: 2005.07.05 23013 �q�@���l</br>
	/// <br>					�E�t���[���̍ŏI�ŏ����Ή�</br>
	/// <br>					�EArrowKeyControl��CatchMouse�v���p�e�B��True�ɐݒ�</br>
	/// <br>Update Note: 2005.07.06 23013 �q ���l</br>
	/// <br>					�E�r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C��</br>
	/// <br>Update Note: 2005.07.06 23013 �q ���l</br>
	/// <br>					�E�G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈��</br>
	/// <br>Update Note: 2005.07.11 23013 �q ���l</br>
	/// <br>					�E�r�����䏈���̒��ɍŏ����Ή��ǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.03 23006 ���� ���q</br>
	/// <br>					�E����{�^���ւ̃t�H�[�J�X�Z�b�g����</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.08  23006 ���� ���q</br>
	/// <br>				    �E��ƃR�[�h�擾����</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.24  23006 ���� ���q</br>
	/// <br>				    �ETMsgDisp���i�Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.19  23006 ���� ���q</br>
	/// <br>				    �EUI�q���Hide����Owner.Activate�����ǉ�</br>
    /// <br></br> 
    /// <br>Update Note : 2006.07.31  23006 ���� ���q</br>
    /// <br>                    �E�u���b�V���A�b�v�Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2006.08.30  23006 ���� ���q</br>
    /// <br>                    �E����N��������v���r���[�L���敪���̂��\�������悤�C��</br>
	/// <br></br>
	/// <br>			: 2007.02.06 18322 T.Kimura MA.NS�p�ɕύX</br>
	/// <br>			:                           �E��ʃX�L���ύX�Ή�</br>
	/// </remarks>
	public class SFCMN09140UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel PrintPaperCode_Title_Label;
		private Infragistics.Win.Misc.UltraLabel PrintPaperTypeNm_Title_Label;
		private Infragistics.Win.Misc.UltraLabel PrintPaperRow_TitleLabel;
		private Infragistics.Win.Misc.UltraLabel PrintPaperCol_TitleLabel;
		private Infragistics.Win.Misc.UltraLabel PrtPreviewExistCode_TitleLabel;
		private Broadleaf.Library.Windows.Forms.TEdit PrintPaperTypeNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit PrintPaperCol_tNedit;
		private Broadleaf.Library.Windows.Forms.TComboEditor PrtPreviewExistCode_tComboEditor;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel Guid_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TNedit PrintPaperCode_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PrintPaperRow_tNedit;
		private System.ComponentModel.IContainer components;
		# endregion

		/// <summary>
		/// ���[�p���ݒ�����̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�p���ݒ�����̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public SFCMN09140UA()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint	= false;
			this._canClose	= false;
			// TODO ���O�C���S���҂��擾���邵�Đݒ��؂�ւ���H
			this._canNew	= false;
			this._canDelete = false;
			this._canLogicalDeleteDataExtraction = false;
			this._canClose = true;			// �f�t�H���g:true�Œ�
			this._defaultAutoFillToColumn = true;
			this._canSpecificationSearch = false;

			// ��ƃR�[�h���擾����
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// �ϐ�������
			this._dataIndex = -1;
			this._prtPaperStAcs = new PrtPaperStAcs();
			this._prevPrtPaperSt = null;
			this._nextData = false;
			this._totalCount = 0;
			this._prtPaperStTable = new Hashtable();

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		}

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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09140UA));
            this.PrintPaperCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperTypeNm_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperRow_TitleLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperCol_TitleLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrtPreviewExistCode_TitleLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperTypeNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrintPaperCol_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PrtPreviewExistCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Bind_DataSet = new System.Data.DataSet();
            this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PrintPaperRow_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperTypeNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperCol_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrtPreviewExistCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperRow_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintPaperCode_Title_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.PrintPaperCode_Title_Label.Appearance = appearance1;
            this.PrintPaperCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrintPaperCode_Title_Label.Location = new System.Drawing.Point(24, 35);
            this.PrintPaperCode_Title_Label.Name = "PrintPaperCode_Title_Label";
            this.PrintPaperCode_Title_Label.Size = new System.Drawing.Size(146, 24);
            this.PrintPaperCode_Title_Label.TabIndex = 0;
            this.PrintPaperCode_Title_Label.Text = "���[�p���敪";
            // 
            // PrintPaperTypeNm_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.PrintPaperTypeNm_Title_Label.Appearance = appearance2;
            this.PrintPaperTypeNm_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrintPaperTypeNm_Title_Label.Location = new System.Drawing.Point(24, 70);
            this.PrintPaperTypeNm_Title_Label.Name = "PrintPaperTypeNm_Title_Label";
            this.PrintPaperTypeNm_Title_Label.Size = new System.Drawing.Size(146, 24);
            this.PrintPaperTypeNm_Title_Label.TabIndex = 1;
            this.PrintPaperTypeNm_Title_Label.Text = "���[�p���^�C�v";
            // 
            // PrintPaperRow_TitleLabel
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.PrintPaperRow_TitleLabel.Appearance = appearance3;
            this.PrintPaperRow_TitleLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrintPaperRow_TitleLabel.Location = new System.Drawing.Point(24, 105);
            this.PrintPaperRow_TitleLabel.Name = "PrintPaperRow_TitleLabel";
            this.PrintPaperRow_TitleLabel.Size = new System.Drawing.Size(146, 24);
            this.PrintPaperRow_TitleLabel.TabIndex = 2;
            this.PrintPaperRow_TitleLabel.Text = "���[�s�ʒu";
            // 
            // PrintPaperCol_TitleLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.PrintPaperCol_TitleLabel.Appearance = appearance4;
            this.PrintPaperCol_TitleLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrintPaperCol_TitleLabel.Location = new System.Drawing.Point(24, 140);
            this.PrintPaperCol_TitleLabel.Name = "PrintPaperCol_TitleLabel";
            this.PrintPaperCol_TitleLabel.Size = new System.Drawing.Size(146, 24);
            this.PrintPaperCol_TitleLabel.TabIndex = 3;
            this.PrintPaperCol_TitleLabel.Text = "���[���ʒu";
            // 
            // PrtPreviewExistCode_TitleLabel
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.PrtPreviewExistCode_TitleLabel.Appearance = appearance5;
            this.PrtPreviewExistCode_TitleLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrtPreviewExistCode_TitleLabel.Location = new System.Drawing.Point(24, 175);
            this.PrtPreviewExistCode_TitleLabel.Name = "PrtPreviewExistCode_TitleLabel";
            this.PrtPreviewExistCode_TitleLabel.Size = new System.Drawing.Size(146, 24);
            this.PrtPreviewExistCode_TitleLabel.TabIndex = 4;
            this.PrtPreviewExistCode_TitleLabel.Text = "�v���r���[�敪";
            // 
            // PrintPaperTypeNm_tEdit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintPaperTypeNm_tEdit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrintPaperTypeNm_tEdit.Appearance = appearance7;
            this.PrintPaperTypeNm_tEdit.AutoSelect = true;
            this.PrintPaperTypeNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintPaperTypeNm_tEdit.DataText = "";
            this.PrintPaperTypeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintPaperTypeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 25, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PrintPaperTypeNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PrintPaperTypeNm_tEdit.Location = new System.Drawing.Point(180, 70);
            this.PrintPaperTypeNm_tEdit.MaxLength = 25;
            this.PrintPaperTypeNm_tEdit.Name = "PrintPaperTypeNm_tEdit";
            this.PrintPaperTypeNm_tEdit.Size = new System.Drawing.Size(407, 24);
            this.PrintPaperTypeNm_tEdit.TabIndex = 1;
            // 
            // PrintPaperCol_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.PrintPaperCol_tNedit.ActiveAppearance = appearance8;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.PrintPaperCol_tNedit.Appearance = appearance9;
            this.PrintPaperCol_tNedit.AutoSelect = true;
            this.PrintPaperCol_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrintPaperCol_tNedit.DataText = "";
            this.PrintPaperCol_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintPaperCol_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.PrintPaperCol_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrintPaperCol_tNedit.Location = new System.Drawing.Point(180, 140);
            this.PrintPaperCol_tNedit.MaxLength = 5;
            this.PrintPaperCol_tNedit.Name = "PrintPaperCol_tNedit";
            this.PrintPaperCol_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PrintPaperCol_tNedit.Size = new System.Drawing.Size(52, 24);
            this.PrintPaperCol_tNedit.TabIndex = 3;
            // 
            // PrtPreviewExistCode_tComboEditor
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrtPreviewExistCode_tComboEditor.ActiveAppearance = appearance10;
            this.PrtPreviewExistCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrtPreviewExistCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrtPreviewExistCode_tComboEditor.ItemAppearance = appearance11;
            this.PrtPreviewExistCode_tComboEditor.Location = new System.Drawing.Point(180, 175);
            this.PrtPreviewExistCode_tComboEditor.Name = "PrtPreviewExistCode_tComboEditor";
            this.PrtPreviewExistCode_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.PrtPreviewExistCode_tComboEditor.TabIndex = 4;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(234, 227);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 5;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(364, 227);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 6;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(364, 227);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(494, 227);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Mode_Label
            // 
            appearance12.ForeColor = System.Drawing.Color.White;
            appearance12.TextHAlignAsString = "Center";
            appearance12.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance12;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(515, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 14;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 268);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(632, 23);
            this.ultraStatusBar1.TabIndex = 15;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Guid_Label
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.Guid_Label.Appearance = appearance19;
            this.Guid_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Guid_Label.Location = new System.Drawing.Point(220, 35);
            this.Guid_Label.Name = "Guid_Label";
            this.Guid_Label.Size = new System.Drawing.Size(395, 24);
            this.Guid_Label.TabIndex = 16;
            this.Guid_Label.Visible = false;
            // 
            // ultraLabel1
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance18;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(245, 105);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(85, 24);
            this.ultraLabel1.TabIndex = 17;
            this.ultraLabel1.Text = "/10�~��";
            // 
            // ultraLabel2
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance17;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Location = new System.Drawing.Point(245, 140);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(85, 24);
            this.ultraLabel2.TabIndex = 18;
            this.ultraLabel2.Text = "/10�~��";
            // 
            // PrintPaperCode_tNedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.PrintPaperCode_tNedit.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.PrintPaperCode_tNedit.Appearance = appearance16;
            this.PrintPaperCode_tNedit.AutoSelect = true;
            this.PrintPaperCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintPaperCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrintPaperCode_tNedit.DataText = "";
            this.PrintPaperCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintPaperCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PrintPaperCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrintPaperCode_tNedit.Location = new System.Drawing.Point(180, 35);
            this.PrintPaperCode_tNedit.MaxLength = 2;
            this.PrintPaperCode_tNedit.Name = "PrintPaperCode_tNedit";
            this.PrintPaperCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PrintPaperCode_tNedit.Size = new System.Drawing.Size(28, 24);
            this.PrintPaperCode_tNedit.TabIndex = 0;
            // 
            // PrintPaperRow_tNedit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.PrintPaperRow_tNedit.ActiveAppearance = appearance13;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.PrintPaperRow_tNedit.Appearance = appearance14;
            this.PrintPaperRow_tNedit.AutoSelect = true;
            this.PrintPaperRow_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrintPaperRow_tNedit.DataText = "";
            this.PrintPaperRow_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintPaperRow_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.PrintPaperRow_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrintPaperRow_tNedit.Location = new System.Drawing.Point(180, 105);
            this.PrintPaperRow_tNedit.MaxLength = 5;
            this.PrintPaperRow_tNedit.Name = "PrintPaperRow_tNedit";
            this.PrintPaperRow_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PrintPaperRow_tNedit.Size = new System.Drawing.Size(52, 24);
            this.PrintPaperRow_tNedit.TabIndex = 2;
            // 
            // SFCMN09140UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(632, 291);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.PrintPaperRow_tNedit);
            this.Controls.Add(this.PrintPaperCode_tNedit);
            this.Controls.Add(this.PrintPaperCol_tNedit);
            this.Controls.Add(this.PrintPaperTypeNm_tEdit);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.Guid_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.PrtPreviewExistCode_tComboEditor);
            this.Controls.Add(this.PrtPreviewExistCode_TitleLabel);
            this.Controls.Add(this.PrintPaperCol_TitleLabel);
            this.Controls.Add(this.PrintPaperRow_TitleLabel);
            this.Controls.Add(this.PrintPaperTypeNm_Title_Label);
            this.Controls.Add(this.PrintPaperCode_Title_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09140UA";
            this.Text = "���[�p���ݒ�";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperTypeNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperCol_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrtPreviewExistCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperRow_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;


		private PrtPaperStAcs _prtPaperStAcs;
		private PrtPaperSt _prevPrtPaperSt;

		//��r�pclone
		private PrtPaperSt _prtPaperStClone;
		
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _prtPaperStTable;

        // �� 20070206 18322 a MA.NS�p�ɕύX 
        /// <ummary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // �� 20070206 18322 a

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;
		// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE				= "�폜��";
		private const string PRINTPAPERCODE_TITLE		= "���[�p���敪";
		private const string PRINTPAPERTYPENM_TITLE		= "���[�p���^�C�v";
		private const string PRINTPAPERROW_TITLE		= "���[�s�ʒu";
		private const string PRINTPAPERCOL_TITLE		= "���[���ʒu";
		private const string PRTPREVIEWEXISTCODE_TITLE	= "�v���r���[�敪";
		private const string GUID_TITLE					= "GUID";
		private const string PRTPAPERST_TABLE			= "PRTPAPERST";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";


		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09140UA());
		}


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
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{					 
			get{ return this._canSpecificationSearch; }
		}

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
			tableName = PRTPAPERST_TABLE;
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
			ArrayList prtPaperStList = null;

			if (readCount == 0)
			{
				// ���݂̎������擾 �y�f�o�b�O�p�z
				//				DateTime t1 = DateTime.Now;

				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
				status = this._prtPaperStAcs.SearchAll(
					out prtPaperStList,
					this._enterpriseCode);

				// �|���������Ԃ�\�� �y�f�o�b�O�p�z
				//				float ms = (float)DateTime.Now.Subtract(t1).TotalMilliseconds;
				//				ultraStatusBar1.Text = ms.ToString() + "�_�b";

				this._totalCount = prtPaperStList.Count;
			}
			else
			{
				status = this._prtPaperStAcs.SearchAll(
					out prtPaperStList,
					out this._totalCount,
					out this._nextData,
					this._enterpriseCode,
					readCount,
					this._prevPrtPaperSt);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( prtPaperStList.Count > 0 ) {
						// �ŏI�̒��[�p���ݒ�I�u�W�F�N�g��ޔ�����
						this._prevPrtPaperSt = ((PrtPaperSt)prtPaperStList[prtPaperStList.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PrtPaperSt prtPaperSt in prtPaperStList)
					{
						PrtPaperStToDataSet(prtPaperSt.Clone(), index);
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
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFCMN09140U",							// �A�Z���u��ID
						"���[�p���ݒ�",                         // �v���O��������
						"Search",                               // ��������
						TMsgDisp.OPE_GET,                       // �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._prtPaperStAcs,				    // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> START
					this.Hide();
					// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> END
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
			ArrayList prtPaperSts = null;

			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._prtPaperStAcs.SearchAll(
				out prtPaperSts,
				out dummy,
				out this._nextData, 
				this._enterpriseCode,
				readCount,
				this._prevPrtPaperSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( prtPaperSts.Count > 0 ) {
						// �ŏI�̒��[�p���ݒ�N���X��ޔ�����
						this._prevPrtPaperSt = ((PrtPaperSt)prtPaperSts[prtPaperSts.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PrtPaperSt prtPaperSt in prtPaperSts)
					{
						index = this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows.Count;
						PrtPaperStToDataSet(prtPaperSt.Clone(), index);
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFCMN09140U",							// �A�Z���u��ID
						"���[�p���ݒ�",                         // �v���O��������
						"SearchNext",                           // ��������
						TMsgDisp.OPE_GET,                       // �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._prtPaperStAcs,				    // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> START
					this.Hide();
					// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> END
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
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PrtPaperSt prtPaperSt = (PrtPaperSt)this._prtPaperStTable[guid];

			int status = this._prtPaperStAcs.LogicalDelete(ref prtPaperSt);
			// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>> START
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
					ExclusiveTransaction(status);
					return status;
				}
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFCMN09140U",							// �A�Z���u��ID
						"���[�p���ݒ�",                         // �v���O��������
						"Delete",                               // ��������
						TMsgDisp.OPE_HIDE,                      // �I�y���[�V����
						"�폜�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._prtPaperStAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					return status;
				}
			}
			// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>> END

			// 2005.07.06 Read�͕s�v�ł�
			//			status = this._prtPaperStAcs.Read(out prtPaperSt, prtPaperSt.EnterpriseCode, prtPaperSt.PrintPaperCode);
			// 2005.07.06 Read�͕s�v�ł�

			PrtPaperStToDataSet(prtPaperSt.Clone(), this._dataIndex);

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
//			appearanceTable.Add(PRINTPAPERCODE_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));			// 2005.06.09 TOUMA DEL �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(PRINTPAPERCODE_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));		// 2005.06.09 TOUMA ADD �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(PRINTPAPERTYPENM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
//			appearanceTable.Add(PRINTPAPERROW_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));			// 2005.06.09 TOUMA DEL �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(PRINTPAPERROW_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));			// 2005.06.09 TOUMA ADD �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
//			appearanceTable.Add(PRINTPAPERCOL_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));			// 2005.06.09 TOUMA DEL �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(PRINTPAPERCOL_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));			// 2005.06.09 TOUMA DEL �t���[���ɕ\��������e�̕\���ʒu���E�l�߂ɕύX
			appearanceTable.Add(PRTPREVIEWEXISTCODE_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}



		/// <summary>
		/// ���[�p���ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="prtPaperSt">���[�p���ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ���[�p���ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrtPaperStToDataSet(PrtPaperSt prtPaperSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[PRTPAPERST_TABLE].NewRow();
				this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows.Count - 1;

				// ��������ƁA
				// ���C���t���[�����ŕ��������̒��o�r���Ŏq��ʂ��Ăяo����
				// �I�������s�łȂ����o�ŏI�s���Ăяo�����
				//this.DataIndex = index;
			}

			if (prtPaperSt.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][DELETE_DATE] = prtPaperSt.UpdateDateTimeJpInFormal;
			}
			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERCODE_TITLE] = prtPaperSt.PrintPaperCode.ToString();
			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERTYPENM_TITLE] = prtPaperSt.PrintPaperTypeNm;
////////////////////////////////////////////// 2005.06.09 TERASAKA DEL STA //
//			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERROW_TITLE] = System.String.Format("{0,5} /�~��", prtPaperSt.PrintPaperRow);
//			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERCOL_TITLE] = System.String.Format("{0,5} /�~��", prtPaperSt.PrintPaperCol);
// 2005.06.09 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2005.06.09 TERASAKA ADD STA //
			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERROW_TITLE] = System.String.Format("{0,5} �^ 10�~��", prtPaperSt.PrintPaperRow);
			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERCOL_TITLE] = System.String.Format("{0,5} �^ 10�~��", prtPaperSt.PrintPaperCol);
// 2005.06.09 TERASAKA ADD END //////////////////////////////////////////////
//			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = prtPaperSt.PrtPreviewExistCode.ToString() + " " + prtPaperSt.PrtPreviewExistName;	// 2005.06.13 TOUMA DEL �C���f�b�N�X�̔ԍ����\��
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.30 TAKAHASHI DELETE START
            //this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = prtPaperSt.PrtPreviewExistName;													// 2005.06.13 TOUMA ADD �C���f�b�N�X�̔ԍ����\��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.30 TAKAHASHI DELETE END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.30 TAKAHASHI ADD START
            if (prtPaperSt.PrtPreviewExistName != null)
            {
                this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = prtPaperSt.PrtPreviewExistName;
            }
            else
            {
                if (prtPaperSt.PrtPreviewExistCode == 0)
                {
                    this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = "����";
                }
                else
                {
                    this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = "�L��";
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.30 TAKAHASHI ADD END

			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][GUID_TITLE] = prtPaperSt.FileHeaderGuid;
			//
			if (this._prtPaperStTable.ContainsKey(prtPaperSt.FileHeaderGuid) == true)
			{
				this._prtPaperStTable.Remove(prtPaperSt.FileHeaderGuid);
			}
			this._prtPaperStTable.Add(prtPaperSt.FileHeaderGuid, prtPaperSt);
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
			DataTable prtPaperStTable = new DataTable(PRTPAPERST_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			prtPaperStTable.Columns.Add(DELETE_DATE, typeof(string));
			prtPaperStTable.Columns.Add(PRINTPAPERCODE_TITLE, typeof(int));
			prtPaperStTable.Columns.Add(PRINTPAPERTYPENM_TITLE, typeof(string));
			prtPaperStTable.Columns.Add(PRINTPAPERROW_TITLE, typeof(string));
			prtPaperStTable.Columns.Add(PRINTPAPERCOL_TITLE, typeof(string));
			prtPaperStTable.Columns.Add(PRTPREVIEWEXISTCODE_TITLE, typeof(string));
			prtPaperStTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(prtPaperStTable);
		}

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
			// �R���{�{�b�N�X�̏�����
			// ���[�p���ݒ�N���X�ɃR�[�h���Z�b�g���Ė��̂��擾
			PrtPaperSt prtPaperSt = new PrtPaperSt();
			
			// �v�����^���
			PrtPreviewExistCode_tComboEditor.Items.Clear(); 
			foreach (int code in PrtPaperSt.PrtPreviewExistCodes)
			{
				prtPaperSt.PrtPreviewExistCode = code;
				PrtPreviewExistCode_tComboEditor.Items.Add(prtPaperSt.PrtPreviewExistCode, prtPaperSt.PrtPreviewExistName);
			}
			PrtPreviewExistCode_tComboEditor.MaxDropDownItems = PrtPreviewExistCode_tComboEditor.Items.Count;
						
//TODO ���ꁫ���̂��߂ɂ���Ă�̂��i�]
//			this.Ok_Button.Location = new System.Drawing.Point(550, 375);
//			this.Cancel_Button.Location = new System.Drawing.Point(675, 375);
//			this.Delete_Button.Location = new System.Drawing.Point(300, 375);
//			this.Revive_Button.Location = new System.Drawing.Point(425, 375);
		}

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.Guid_Label.Text = "";	
			this.PrintPaperCode_tNedit.Text = "";							
			this.PrintPaperTypeNm_tEdit.Text = "";
			this.PrintPaperRow_tNedit.SetInt(0);
			this.PrintPaperCol_tNedit.SetInt(0);
			this.PrtPreviewExistCode_tComboEditor.Value = 0;
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
			if (this._dataIndex < 0)
			{
				PrtPaperSt prtpaperst = new PrtPaperSt();
				//�N���[���쐬
				this._prtPaperStClone = prtpaperst.Clone(); 
				DispToPrtPaperSt(ref this._prtPaperStClone);

				// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;
				// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				this.PrintPaperCode_tNedit.Enabled = true;
				this.PrintPaperCode_tNedit.Focus();

				ScreenInputPermissionControl(true);
			}
			else
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
				PrtPaperSt prtPaperSt = (PrtPaperSt)this._prtPaperStTable[guid];

				PrtPaperStToScreen(prtPaperSt);

				if (prtPaperSt.LogicalDeleteCode == 0)
				{
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					this.Ok_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					ScreenInputPermissionControl(true);

					// �X�V���[�h�̏ꍇ�́A���[�p���敪�E���[�p���^�C�v���̂���͕s�Ƃ���
					this.PrintPaperCode_tNedit.Focus();
					this.PrintPaperCode_tNedit.Enabled = false;
					this.PrintPaperTypeNm_tEdit.Enabled = false;
					this.PrintPaperRow_tNedit.Focus();
					this.PrintPaperRow_tNedit.SelectAll();

					//�N���[���쐬
					this._prtPaperStClone = prtPaperSt.Clone();  
					//��ʏ����r�p�N���[���ɃR�s�[����@�@�@�@�@   
					DispToPrtPaperSt(ref this._prtPaperStClone);
					// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;
					// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
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

					this.Delete_Button.Focus();

					// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;
					// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				}
			}

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
			this.PrintPaperCode_tNedit.Enabled = enabled;
			this.PrintPaperTypeNm_tEdit.Enabled = enabled;
			this.PrintPaperRow_tNedit.Enabled = enabled;
			this.PrintPaperCol_tNedit.Enabled = enabled;
			this.PrtPreviewExistCode_tComboEditor.Enabled = enabled;
		}

		/// <summary>
		/// ���[�p���ݒ�N���X��ʓW�J����
		/// </summary>
		/// <param name="prtPaperSt">���[�p���ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���[�p���ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrtPaperStToScreen(PrtPaperSt prtPaperSt)
		{
			this.Guid_Label.Text = prtPaperSt.FileHeaderGuid.ToString();
			this.PrintPaperCode_tNedit.SetInt( prtPaperSt.PrintPaperCode );
			this.PrintPaperTypeNm_tEdit.Text = prtPaperSt.PrintPaperTypeNm;
			this.PrintPaperRow_tNedit.SetInt(prtPaperSt.PrintPaperRow);
			this.PrintPaperCol_tNedit.SetInt(prtPaperSt.PrintPaperCol);
			this.PrtPreviewExistCode_tComboEditor.Value = prtPaperSt.PrtPreviewExistCode;
		}

		/// <summary>
		/// ��ʏ�񒠕[�p���ݒ�N���X�i�[����
		/// </summary>
		/// <param name="prtPaperSt">���[�p���ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂璠�[�p���ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void DispToPrtPaperSt(ref PrtPaperSt prtPaperSt)
		{
			if (prtPaperSt == null)
			{
				// �V�K�̏ꍇ
				prtPaperSt = new PrtPaperSt();
			}

			prtPaperSt.EnterpriseCode		= this._enterpriseCode;								//��ƃR�[�h	
			prtPaperSt.PrintPaperCode		= this.PrintPaperCode_tNedit.GetInt();				//���[�p���敪
			prtPaperSt.PrintPaperTypeNm		= this.PrintPaperTypeNm_tEdit.Text;					//���[�p���^�C�v����
			prtPaperSt.PrintPaperRow		= this.PrintPaperRow_tNedit.GetInt();				//���[�s�ʒu
			prtPaperSt.PrintPaperCol		= this.PrintPaperCol_tNedit.GetInt();				//���[���ʒu
			prtPaperSt.PrtPreviewExistCode	= (int)this.PrtPreviewExistCode_tComboEditor.SelectedItem.DataValue;	//�v���r���[�敪
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

			if (this.PrintPaperCode_tNedit.GetInt() == 0)
			{
				control = this.PrintPaperCode_tNedit;
				message = this.PrintPaperCode_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}
			else if (this.PrintPaperTypeNm_tEdit.Text.Trim() == "")
			{
				control = this.PrintPaperTypeNm_tEdit;
				message = this.PrintPaperTypeNm_Title_Label.Text + "����͂��ĉ������B";
				result = false;
			}

			return result;
		}

		/// <summary>
		/// ���[�p���ݒ�o�^����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ���[�p���ݒ�o�^���s���܂��B</br>
		/// <br>Programmer : 22033�@�O��  �M�j</br>
		/// <br>Date       : 2005.04.30</br>
		/// </remarks>
		private bool SavePrtPaperSt()
		{
			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
					"SFCMN09140U",							// �A�Z���u��ID
					message,	                            // �\�����郁�b�Z�[�W
					0,   									// �X�e�[�^�X�l
					MessageBoxButtons.OK);					// �\������{�^��
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

				control.Focus();
				if(control is TEdit)  {((TEdit)control).SelectAll();}
				return false;
			}

			PrtPaperSt prtPaperSt = null;
			if (this._dataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
				prtPaperSt = ((PrtPaperSt)this._prtPaperStTable[guid]).Clone();
			}

			DispToPrtPaperSt(ref prtPaperSt);

			// TODO �����ŏ������݂Ȃ񂾂��ǁE�E�E
			int status = this._prtPaperStAcs.Write(ref prtPaperSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                                     // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO,                        // �G���[���x��
						"SFCMN09140U",							            // �A�Z���u��ID
						"���̒��[�p���ݒ�R�[�h�͊��Ɏg�p����Ă��܂��B",	// �\�����郁�b�Z�[�W
						status,									            // �X�e�[�^�X�l
						MessageBoxButtons.OK);					            // �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					return false;
				}
				// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>> START
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					ExclusiveTransaction(status);
					
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή��ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή��ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.06 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>> START
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.06 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>> END
					
					return false;
				}
				// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>> END
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFCMN09140U",							// �A�Z���u��ID
						"���[�p���ݒ�",     // �v���O��������
						"SavePrtPaperSt",                               // ��������
						TMsgDisp.OPE_UPDATE,                       // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._prtPaperStAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή��ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή��ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.06 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>> START
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.06 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>> END

					return false;
				}
			}

			PrtPaperStToDataSet(prtPaperSt, this._dataIndex);

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
				this.PrintPaperCode_tNedit.Focus();
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

				// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = -2;
				// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

			}

			return true;
		}

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
		/// <br>Programmer : 23013  �q�@���l</br>
		/// <br>Date       : 2005.07.11</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFCMN09140U",							// �A�Z���u��ID
						"���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFCMN09140U",							// �A�Z���u��ID
						"���ɑ��[�����폜����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
			}
		}

		/// <summary>
		/// Form.Load �C�x���g(SFCMN09140UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;

            // �� 20070206 18322 c MA.NS�p�ɕύX
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            // �� 20070206 18322 c

			this.Ok_Button.ImageList     = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
			this.Delete_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

			ScreenInitialSetting();		
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFCMN02000UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
	
			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFCMN02000UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 97606 ���@�]���q</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Form1_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END

				return;
			}

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
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
			SavePrtPaperSt();
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
			//�ۑ��m�F
			PrtPaperSt comparePrtPaperSt = new PrtPaperSt();
			comparePrtPaperSt = this._prtPaperStClone.Clone();  
			//���݂̉�ʏ����擾����
			DispToPrtPaperSt(ref comparePrtPaperSt);
			//�ŏ��Ɏ擾������ʏ��Ɣ�r
			if (!(this._prtPaperStClone.Equals(comparePrtPaperSt)))	
			{
				//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
					"SFCMN09140U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
					null, 					                              // �\�����郁�b�Z�[�W
					0, 					                                  // �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel);	                      // �\������{�^��
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

				switch(res)
				{
					case DialogResult.Yes:
					{
						// �ی���Ж��̓o�^����
						if(!SavePrtPaperSt()) 
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
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.03 TAKAHASHI ADD START
						this.Cancel_Button.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.03 TAKAHASHI ADD END

						return;
					}
				}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
			DialogResult result = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION,                      // �G���[���x��
				"SFCMN09140U", 					                         // �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B" + "\r\n" + 
				"��낵���ł����H", 				                     // �\�����郁�b�Z�[�W
				0, 						                                 // �X�e�[�^�X�l
				MessageBoxButtons.OKCancel,                              // �\������{�^��
				MessageBoxDefaultButton.Button2);                        // �����\���{�^��
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

			if (result == DialogResult.OK)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
				PrtPaperSt prtPaperSt = (PrtPaperSt)this._prtPaperStTable[guid];

				int status = this._prtPaperStAcs.Delete(prtPaperSt);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					default:
					{
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
						TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
							"SFCMN09140U",							// �A�Z���u��ID
							"���[�p���ݒ�",                         // �v���O��������
							"Delete_Button_Click",                  // ��������
							TMsgDisp.OPE_DELETE,                    // �I�y���[�V����
							"�폜�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
							status,									// �X�e�[�^�X�l
							this._prtPaperStAcs,					// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,					// �\������{�^��
							MessageBoxDefaultButton.Button1);		// �����\���{�^��
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

						// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> START
						this.Hide();
						// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> END
						return;
					}
				}
			}
			else
			{
				return;
			}

			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex].Delete();

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PrtPaperSt prtPaperSt = (PrtPaperSt)this._prtPaperStTable[guid];

			int status = this._prtPaperStAcs.Revival(ref prtPaperSt);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFCMN09140U",							// �A�Z���u��ID
						"���Ƀf�[�^�����S�폜����Ă��܂��B",	// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> START
					this.Hide();
					// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> END
					break;
				}
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFCMN09140U",							// �A�Z���u��ID
						"���[�p���ݒ�",                         // �v���O��������
						"Revive_Button_Click",                  // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�����Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._prtPaperStAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> START
					this.Hide();
					// 2005.07.08 �G���[���o����MessageBox��OK�{�^�������������Ƃ��AUI��ʂ���鏈�� >>>>>>>>>> END
					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			PrtPaperStToDataSet(prtPaperSt, this._dataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndex�o�b�t�@�ێ�
			this._indexBuf = -2;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
	}
}
