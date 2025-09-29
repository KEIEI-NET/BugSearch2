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
	/// ���z��ʓ��̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���z��ʐݒ���s���܂��B
	///					 IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer : 97134�@���� �딎</br>
	/// <br>Date       : 2005.06.24</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.28 22025 �c�� �L</br>
	/// <br>					�E�t���[���̍ŏ����Ή�</br>
	/// <br>Update Note: 2005.06.10 23001 �H�R�@����</br>
	/// <br>					�EView��ʂ̐��l���ڂ��E�l�ɕύX</br>
	/// <br>Update Note: 2005.06.13 22025 �c�� �L</br>
	/// <br>					�EUI�q��ʊe���ڂ̍��A�E�l�ߍœK���Ή�</br>
	/// <br>Update Note: 2005.09.02 22021 �J���@�͍K</br> 
	/// <br>					�E�ۑ��m�F��̃G���^�[�L�[�������̃t�H�[�J�X�Ή�</br>
	/// <br>Update Note: 2005.09.08 22021 �J���@�͍K</br>
	/// <br>					�E���O�C�����擾���i�̑g����</br>
	/// <br>Update Note: 2005.09.22 22021 �J���@�͍K</br>
	/// <br>					�E���b�Z�[�W�\���̕ύX</br>
	/// <br>Update Note: 2005.09.26 22021 �J���@�͍K</br>
	/// <br>					�E���S�폜�{�^���ł̃L�����Z���I����̃t�H�[�J�X�̒ǉ�</br>
	/// <br>Update Note: 2005.10.19 22021 �J���@�͍K</br>
	/// <br>		   :        �EUI�q���Hide����Owner.Activate�����ǉ�</br>
	/// <br>Update Note: 2005.12.17 23003 �|�c�@�܂���</br>
    /// <br>		   :        �E���[�U���̂ݓǍ��E�ҏW����悤�C��</br>	
    /// <br>Update Note: 2006.12.26 22022 �i�� �m�q</br>
    /// <br>					1.SF�ł𗬗p���g�єł��쐬</br>
	/// <br>Update Note: 2008.02.18 30167 ���@�O�M</br>
	/// <br>					1.���W�Ǘ��敪�͕s�v�Ȃ̂Ŕ�\���ɂ���</br>
    /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
    /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
    /// <br>Programmer : 2008/06/12 30415 �ēc �ύK</br>
    /// <br>                    ���ڍ폜�ׁ̈A�C��</br>
    /// </remarks>
	public class SFUKK09040UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
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
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Broadleaf.Library.Windows.Forms.TNedit MnyKindCord_tNedit;
        private Broadleaf.Library.Windows.Forms.TEdit MnyKindName_tEdit;
        private Infragistics.Win.Misc.UltraLabel MnyKindDivCd_Title_Label;
        private Broadleaf.Library.Windows.Forms.TComboEditor MnyKindDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel MnyKindCord_Title_Label;
        private Infragistics.Win.Misc.UltraLabel MnyKindName_Title_Label;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// ���z��ʏ����̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���z��ʏ����̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public SFUKK09040UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canNew = false;                           // MOD 2008/09/19 �s��Ή�[5433] true��false
            this._canDelete = false;                        // MOD 2008/09/19 �s��Ή�[5433] true��false
			this._canClose = true;		                    // �f�t�H���g:true�Œ�
			this._canLogicalDeleteDataExtraction = false;   // MOD 2008/09/22 �s��Ή�[5630] true��false
			this._canSpecificationSearch = false;
			this._defaultAutoFillToColumn = true;

			//�@��ƃR�[�h���擾����
			// 2005.09.08 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//			this._enterpriseCode = "TBS1";	// �� �v�ύX
			// 2005.09.08 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// �ϐ�������
			this._dataIndex = -1;
			this._nextData = false;
			this._totalCount = 0;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            this._mnykindAcs    = new MoneyKindAcs();
            this._prevMoneyKind = null;
            this._mnykindTable  = new Hashtable();
            this._mnykindDivTbl = new Hashtable();
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
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09040UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.MnyKindCord_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MnyKindCord_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MnyKindName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MnyKindName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MnyKindDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MnyKindDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindCord_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindDivCd_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 206);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(647, 23);
            this.ultraStatusBar1.TabIndex = 15;
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
            appearance19.ForeColor = System.Drawing.Color.White;
            appearance19.TextHAlignAsString = "Center";
            appearance19.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance19;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(540, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 14;
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
            this.Ok_Button.Location = new System.Drawing.Point(377, 161);
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
            this.Cancel_Button.Location = new System.Drawing.Point(511, 161);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(246, 161);
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
            this.Revive_Button.Location = new System.Drawing.Point(377, 161);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 6;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // MnyKindCord_tNedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.MnyKindCord_tNedit.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.MnyKindCord_tNedit.Appearance = appearance16;
            this.MnyKindCord_tNedit.AutoSelect = true;
            this.MnyKindCord_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MnyKindCord_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MnyKindCord_tNedit.DataText = "";
            this.MnyKindCord_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MnyKindCord_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MnyKindCord_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MnyKindCord_tNedit.Location = new System.Drawing.Point(124, 36);
            this.MnyKindCord_tNedit.MaxLength = 3;
            this.MnyKindCord_tNedit.Name = "MnyKindCord_tNedit";
            this.MnyKindCord_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MnyKindCord_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MnyKindCord_tNedit.Size = new System.Drawing.Size(35, 24);
            this.MnyKindCord_tNedit.TabIndex = 1;
            // 
            // MnyKindCord_Title_Label
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.TextVAlignAsString = "Middle";
            this.MnyKindCord_Title_Label.Appearance = appearance18;
            this.MnyKindCord_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MnyKindCord_Title_Label.Location = new System.Drawing.Point(12, 36);
            this.MnyKindCord_Title_Label.Name = "MnyKindCord_Title_Label";
            this.MnyKindCord_Title_Label.Size = new System.Drawing.Size(104, 24);
            this.MnyKindCord_Title_Label.TabIndex = 10;
            this.MnyKindCord_Title_Label.Text = "����R�[�h";
            // 
            // MnyKindName_Title_Label
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.TextVAlignAsString = "Middle";
            this.MnyKindName_Title_Label.Appearance = appearance17;
            this.MnyKindName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MnyKindName_Title_Label.Location = new System.Drawing.Point(12, 76);
            this.MnyKindName_Title_Label.Name = "MnyKindName_Title_Label";
            this.MnyKindName_Title_Label.Size = new System.Drawing.Size(104, 24);
            this.MnyKindName_Title_Label.TabIndex = 11;
            this.MnyKindName_Title_Label.Text = "���햼";
            // 
            // MnyKindName_tEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MnyKindName_tEdit.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.MnyKindName_tEdit.Appearance = appearance14;
            this.MnyKindName_tEdit.AutoSelect = true;
            this.MnyKindName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MnyKindName_tEdit.DataText = "";
            this.MnyKindName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MnyKindName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.MnyKindName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.MnyKindName_tEdit.Location = new System.Drawing.Point(124, 76);
            this.MnyKindName_tEdit.MaxLength = 30;
            this.MnyKindName_tEdit.Name = "MnyKindName_tEdit";
            this.MnyKindName_tEdit.Size = new System.Drawing.Size(496, 24);
            this.MnyKindName_tEdit.TabIndex = 2;
            // 
            // MnyKindDivCd_Title_Label
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.TextVAlignAsString = "Middle";
            this.MnyKindDivCd_Title_Label.Appearance = appearance8;
            this.MnyKindDivCd_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MnyKindDivCd_Title_Label.Location = new System.Drawing.Point(12, 116);
            this.MnyKindDivCd_Title_Label.Name = "MnyKindDivCd_Title_Label";
            this.MnyKindDivCd_Title_Label.Size = new System.Drawing.Size(96, 24);
            this.MnyKindDivCd_Title_Label.TabIndex = 12;
            this.MnyKindDivCd_Title_Label.Text = "����敪";
            // 
            // MnyKindDivCd_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MnyKindDivCd_tComboEditor.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.MnyKindDivCd_tComboEditor.Appearance = appearance6;
            this.MnyKindDivCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MnyKindDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MnyKindDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MnyKindDivCd_tComboEditor.ItemAppearance = appearance7;
            this.MnyKindDivCd_tComboEditor.Location = new System.Drawing.Point(124, 116);
            this.MnyKindDivCd_tComboEditor.MaxDropDownItems = 18;
            this.MnyKindDivCd_tComboEditor.Name = "MnyKindDivCd_tComboEditor";
            this.MnyKindDivCd_tComboEditor.Size = new System.Drawing.Size(144, 24);
            this.MnyKindDivCd_tComboEditor.TabIndex = 3;
            // 
            // SFUKK09040UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(647, 229);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.MnyKindDivCd_tComboEditor);
            this.Controls.Add(this.MnyKindDivCd_Title_Label);
            this.Controls.Add(this.MnyKindName_tEdit);
            this.Controls.Add(this.MnyKindCord_tNedit);
            this.Controls.Add(this.MnyKindName_Title_Label);
            this.Controls.Add(this.MnyKindCord_Title_Label);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09040UA";
            this.Text = "���z��ʐݒ�";
            this.Load += new System.EventHandler(this.SFUKK09040UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09040UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09040UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindCord_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindDivCd_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion
				
		#region Private Menbers
		//private InsurCoNmAcs _insurconmAcs;
	//	private InsurCoNm _prevInsurCoNm;
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
      //private Hashtable _insurconmTable;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuffer;
		//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE  = "�폜��";

        // DEL 2008/09/19 �s��Ή�[5416]��
        //private const string PRICE_TITLE = "���z�ݒ�敪";

        private const string DIV_TITLE    = "����敪";
		private const string CODE_TITLE   = "����R�[�h";
        private const string NAME_TITLE   = "���햼";   // MOD 2008/10/23 �s��Ή�[6943] "���햼��"��"���햼"
        // 2007.05.17  S.Koga  add --------------------------------------------
        private const string REGCODE_TITLE = "���W�Ǘ��敪�R�[�h";
        private const string REGTEXT_TITLE = "���W�Ǘ��敪";
        // --------------------------------------------------------------------
        private const string GUID_TITLE = "GUID";
		private const string MONEYSKIND_TABLE = "MONEYSKIND";

        private MoneyKindAcs _mnykindAcs;      //���z��ʃ}�X�^�A�N�Z�X�N���X
        private MoneyKind _prevMoneyKind;      //���z��ʃf�[�^�N���X�o�b�t�@
        private Hashtable _mnykindTable;       //���z��ʃe�[�u��
        //private string[] _priceSt  = {"����", "�T�[�r�X", "���|"};  // DEL 2008/06/12
        private string[] _priceSt = { "�����E�x��", "", "���|�E���|" };
        private Hashtable _mnykindDivTbl;   //����敪�ϊ��e�[�u��(�R�[�h�̖��̂�ϊ����܂�)

		//��r�pclone
		private MoneyKind _moneyKindClone;


		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";
        private const string VIEW_MODE   = "�Q�ƃ��[�h";
		#endregion
    
		# region Main
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09040UA());
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
		/// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = MONEYSKIND_TABLE;            
		}


        /// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList mnykindAry = null;

            //���z��ʋ敪�}�X�^��Ǎ��݁A�e�[�u���փZ�b�g
            SetMnyKindDivTbl();
            
            if (readCount == 0)
			{
				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
				status = this._mnykindAcs.SearchAll( out mnykindAry, 
                                                     this._enterpriseCode);
				this._totalCount = mnykindAry.Count;
			}else{
				status = this._mnykindAcs.SearchSpecificationAll(
							out mnykindAry,
							out this._totalCount,
							out this._nextData,
							this._enterpriseCode,
							readCount,
							this._prevMoneyKind);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( mnykindAry.Count > 0 ) {
						// �ŏI�̋��z��ʃI�u�W�F�N�g��ޔ�����
						this._prevMoneyKind = ((MoneyKind)mnykindAry[mnykindAry.Count - 1]).Clone();
					}

					int index = 0;
					foreach(MoneyKind mnykind in mnykindAry)
                    {
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                        //if (this._mnykindTable.ContainsKey(mnykind.FileHeaderGuid) == false)
                        if (this._mnykindTable.ContainsKey(CreateHashKey(mnykind)) == false)
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                        {
							InsutanceToDataSet(mnykind.Clone(), index);
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
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// �T�[�`
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���z��ʐݒ�",�@					// �v���O��������
						"Search", 							// ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._mnykindAcs,	 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

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
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		public int SearchNext(int readCount)
		{
                     
            int dummy = 0;
            ArrayList mnykindAry = null;

			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

            int status = this._mnykindAcs.SearchSpecificationAll(
							out mnykindAry,
							out dummy,
							out this._nextData, 
							this._enterpriseCode,
							readCount,
							this._prevMoneyKind);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( mnykindAry.Count > 0 ) {
						// �ŏI�̋��z��ʃN���X��ޔ�����
						this._prevMoneyKind = ((MoneyKind)mnykindAry[mnykindAry.Count - 1]).Clone();
                    }

					int index = 0;

                    foreach(MoneyKind moneykind in mnykindAry)
                    {
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                        //if (this._mnykindTable.ContainsKey(moneykind.FileHeaderGuid) == false)
						if (this._mnykindTable.ContainsKey(CreateHashKey(moneykind)) == false)
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                        {
							index = this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows.Count;
							InsutanceToDataSet(moneykind.Clone(), index);
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
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// �T�[�`
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���z��ʐݒ�",�@					// �v���O��������
						"Search", 							// ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._mnykindAcs,	 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

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
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		public int Delete()
		{

//TODO:�����e�i���X�������ց@�@SF�J�X�^�}�C�Y�ی���
//     Pegasus�ł͓����ݒ�ɂĎg�p����Ă������͍폜�ł��Ȃ��悤�ɂȂ��Ă��܂��̂�
//     �폜�̍ۂ͓����ݒ�}�X�^�i�H�j���m�F����K�v������܂��B

            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
            string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
            MoneyKind moneykind = (MoneyKind)this._mnykindTable[guid];

			/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            //�񋟃f�[�^�̎��͍폜�����Ȃ�
            if (moneykind.MoneyKindCode < 900)
			{
				// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				TMsgDisp.Show( 
					this, 									// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
					"SFUKK09040U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
					"�񋟃f�[�^�̂��߁A�폜�͂ł��܂���B", // �\�����郁�b�Z�[�W
					0, 										// �X�e�[�^�X�l
					MessageBoxButtons.OK );					// �\������{�^��
				// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				MessageBox.Show(
//					"�񋟃f�[�^�̂��߁A�폜�͂ł��܂���B",
//					"���̓`�F�b�N",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//    				MessageBoxDefaultButton.Button1);
				// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

                    return 0;
            }
			2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */

            //�_���폜
            int status = this._mnykindAcs.LogicalDelete(ref moneykind);
			////////////////////////////////////////////////2005 07.07 H.NAKAMURA DEL STA //////
//            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				MessageBox.Show(
//					"�폜�Ɏ��s���܂����B st = " + status.ToString(),
//					"�G���[",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
//				return status;
//			}
			////////////////////////////////////////////////2005 07.07 H.NAKAMURA DEL END //////

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>20050706 Misaki Insert Start
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return status;
				}
				default:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���z��ʐݒ�",�@					// �v���O��������
						"Delete", 							// ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._mnykindAcs,	 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"�폜�Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					this.Hide();
					return status;
				}
			}
			//200500706 Misaki Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			/////////////////2005 07.07 H.NAKAMURA DEL STA ////////////////////////////////////////
//            status = this._mnykindAcs.Read(ref moneykind, 1);
//			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				MessageBox.Show(
//					"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
//					"�G���[",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
//				return status;
//			}
			/////////////////2005 07.07 H.NAKAMURA DEL END /////////////////////////////////////////

			InsutanceToDataSet(moneykind.Clone(), this._dataIndex);
			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
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
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();
           
            appearanceTable.Add(DELETE_DATE,new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft,   "", Color.Red));

            // DEL 2008/09/19 �s��Ή�[5416]��
            //appearanceTable.Add(PRICE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable.Add(DIV_TITLE,  new GridColAppearance(MGridColDispType.Both,			  ContentAlignment.MiddleLeft,  "", Color.Black));
            appearanceTable.Add(CODE_TITLE,	new GridColAppearance(MGridColDispType.Both,			  ContentAlignment.MiddleRight, "", Color.Black));
			appearanceTable.Add(NAME_TITLE,	new GridColAppearance(MGridColDispType.Both,			  ContentAlignment.MiddleLeft,  "", Color.Black));
            // 2007.05.17  S.Koga  add ----------------------------------------
            appearanceTable.Add(REGCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

			//----- ueno upd ---------- start 2008.02.18 �s�v�Ȃ̂Ŕ�\���ɂ���
			appearanceTable.Add(REGTEXT_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- ueno upd ---------- end 2008.02.18

            // ----------------------------------------------------------------
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			return appearanceTable;
		}
		# endregion

		# region Private Methods

        /// <summary>
		/// ���z��ʃI�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="moneykind">���z��ʃI�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ���z��ʃN���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
        private void InsutanceToDataSet(MoneyKind moneykind, int index)
        {
            string mnykinddivnm = "";
            
            if ((index < 0) || (this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[MONEYSKIND_TABLE].NewRow();
				this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows.Count - 1;
			}

			if (moneykind.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][DELETE_DATE] = moneykind.UpdateDateTimeJpInFormal;
			}

			this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][CODE_TITLE]  = moneykind.MoneyKindCode;
			this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][NAME_TITLE]  = moneykind.MoneyKindName;
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][GUID_TITLE] = moneykind.FileHeaderGuid;
            this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][GUID_TITLE] = CreateHashKey(moneykind);
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end

            // DEL 2008/09/19 �s��Ή�[5416]��
            //this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][PRICE_TITLE] = this._priceSt[moneykind.PriceStCode];

            if(this._mnykindDivTbl.ContainsKey(moneykind.MoneyKindDiv))               // ����敪�R�[�h�������
                mnykinddivnm = (string)this._mnykindDivTbl[moneykind.MoneyKindDiv];   // ����敪���̂��Z�b�g

            this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][DIV_TITLE]   = mnykinddivnm;

            /* --- DEL 2008/06/12 -------------------------------->>>>>
                // 2007.05.17  S.Koga  add ----------------------------------------
                this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][REGCODE_TITLE] = moneykind.RegiMgCd;
                if (moneykind.RegiMgCd == 0)
                    this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][REGTEXT_TITLE] = "���W�Ǘ����Ȃ�";
                else if (moneykind.RegiMgCd == 1)
                    this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][REGTEXT_TITLE] = "���W�Ǘ�����";
                // ----------------------------------------------------------------
               --- DEL 2008/06/12 --------------------------------<<<<< */

            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //if (this._mnykindTable.ContainsKey(moneykind.FileHeaderGuid) == true)
			//{
			//	this._mnykindTable.Remove(moneykind.FileHeaderGuid);
			//}
			//this._mnykindTable.Add(moneykind.FileHeaderGuid, moneykind);
            if (this._mnykindTable.ContainsKey(CreateHashKey(moneykind)) == true)
            {
                this._mnykindTable.Remove(CreateHashKey(moneykind));
            }
            this._mnykindTable.Add(CreateHashKey(moneykind), moneykind);
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
        }


		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
            DataTable mnykindTable = new DataTable(MONEYSKIND_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			mnykindTable.Columns.Add(DELETE_DATE,   typeof(string));

            // DEL 2008/09/19 �s��Ή�[5416]��
            //mnykindTable.Columns.Add(PRICE_TITLE, typeof(string));

            mnykindTable.Columns.Add(CODE_TITLE,    typeof(int));
			mnykindTable.Columns.Add(NAME_TITLE,    typeof(string));
            mnykindTable.Columns.Add(DIV_TITLE, typeof(string));
            // 2007.05.17  S.Koga  add ----------------------------------------
            mnykindTable.Columns.Add(REGCODE_TITLE, typeof(int));
            mnykindTable.Columns.Add(REGTEXT_TITLE, typeof(string));
            // ----------------------------------------------------------------
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //mnykindTable.Columns.Add(GUID_TITLE, typeof(Guid));
            mnykindTable.Columns.Add(GUID_TITLE, typeof(string));
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end

            this.Bind_DataSet.Tables.Add(mnykindTable);
        }

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            ArrayList aryBuf = new ArrayList();
            IMnyKindDibComp Imnycmp = new IMnyKindDibComp();

            // DEL 2008/09/19 �s��Ή�[5416] ---------->>>>>
            ////���z�ݒ�敪
            //this.PriceStCd_tComboEditor.Clear();

            //for(int cnt=0; cnt < _priceSt.Length; cnt++)
            //{
            //    if (_priceSt[cnt] != "")
            //    {
            //        this.PriceStCd_tComboEditor.Items.Add(cnt, _priceSt[cnt]);
            //    }
            //}
            // DEL 2008/09/19 �s��Ή�[5416] ----------<<<<<

            //����R�[�h��KEY�ɂȂ��Ă��邽��KEY��񋓂���
            foreach(int cord in this._mnykindDivTbl.Keys)
            {               
                MnyKindDibInf mnykinddivinf = new MnyKindDibInf();      //�\���̂��쐬
                mnykinddivinf.mnykinddivCd = cord;                      //����R�[�h
                mnykinddivinf.mnykinddivNm = (string)this._mnykindDivTbl[cord];
                aryBuf.Add(mnykinddivinf);                              //���X�g�֒ǉ�
            }
            //���X�g������R�[�h���ŕ��ёւ���
            aryBuf.Sort(Imnycmp);
            
            //����敪�R���{�{�b�N�X�֍��ڒǉ�
            this.MnyKindDivCd_tComboEditor.Clear();   
            foreach(MnyKindDibInf mnyinf in aryBuf){
                this.MnyKindDivCd_tComboEditor.Items.Add(mnyinf.mnykinddivCd, mnyinf.mnykinddivNm);
            }

            /* --- DEL 2008/06/12 -------------------------------->>>>>
                // 2007.05.17  S.Koga  add ----------------------------------------
                // ���W�Ǘ��敪�R���{�{�b�N�X�֍��ڒǉ�
                this.RegiMgCd_tComboEditor.Items.Clear();
                this.RegiMgCd_tComboEditor.Items.Add(0, "���W�Ǘ����Ȃ�");
                this.RegiMgCd_tComboEditor.Items.Add(1, "���W�Ǘ�����");
                // ----------------------------------------------------------------
               --- DEL 2008/06/12 --------------------------------<<<<< */
		}

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private void ScreenClear()
		{
            this.MnyKindCord_tNedit.Clear();
			this.MnyKindName_tEdit.Clear();

            // DEL 2008/09/19 �s��Ή�[5416]��
            //this.PriceStCd_tComboEditor.SelectedIndex = 0;

            this.MnyKindDivCd_tComboEditor.SelectedIndex = 0;
            // 2007.05.17  S.Koga  add ----------------------------------------

			//----- ueno upd ---------- start 2008.02.18
			//this.RegiMgCd_tComboEditor.SelectedIndex = 1;	// ���W�Ǘ�����Œ�  // DEL 2008/06/12
			//----- ueno upd ---------- end 2008.02.18
            
            // ----------------------------------------------------------------
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void ScreenReconstruction()
		{

            if (this.DataIndex < 0)
            {
                MoneyKind mnykind = new MoneyKind();
                this._moneyKindClone = mnykind.Clone();     //�N���[���쐬
				DispToInsutance(ref this._moneyKindClone);

                // ----- �o�^���[�h ----- //
                //��ʕ\���ݒ�
				this.Mode_Label.Text = INSERT_MODE;
				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
                
                //���͉s�ݒ�

                // DEL 2008/09/19 �s��Ή�[5416]��
                //this.PriceStCd_tComboEditor.Enabled     = true;

                this.MnyKindDivCd_tComboEditor.Enabled  = true;
                this.MnyKindCord_tNedit.Enabled         = true;
                this.MnyKindName_tEdit.Enabled          = true;
                // 2007.05.17  S.Koga  add ------------------------------------
                //this.RegiMgCd_tComboEditor.Enabled      = true;  // DEL 2008/06/12
                // ------------------------------------------------------------

                // DEL 2008/09/19 �s��Ή�[5416]��
                //this.PriceStCd_tComboEditor.Focus();

				ScreenInputPermissionControl(true);
			}else{

                //�O���b�h��őI�����ꂽ�s�̈�ӂ̒l���擾
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                MoneyKind mnykind = (MoneyKind)this._mnykindTable[guid];
                InsutanceToDisp(mnykind);             //��ʂ֏��𔽉f

/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
                //�񋟕��̃f�[�^�̎��͏C�������Ȃ�
                if(mnykind.MoneyKindCode <= 899)
                {
					ScreenInputPermissionControl(false);
					this.Ok_Button.Visible     = false;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

                    this.Mode_Label.Text = VIEW_MODE;               //�Q�ƃ��[�h�ɐݒ�
                    return;
                }
2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */

				if (mnykind.LogicalDeleteCode == 0) 
				{
                    // ----- �X�V���[�h ----- //
                    //��ʕ\���ݒ�
                    this.Mode_Label.Text = UPDATE_MODE;
					this.Ok_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;
					ScreenInputPermissionControl(true);

					// �X�V���[�h�̏ꍇ�͋��z��ʃR�[�h�A���z�敪�A����敪����͕s�Ƃ���

                    // DEL 2008/09/19 �s��Ή�[5416]��
                    //this.PriceStCd_tComboEditor.Enabled     = false;

                    this.MnyKindDivCd_tComboEditor.Enabled  = false;    // MOD 2008/09/19 �s��Ή�[5433] true��false
                    this.MnyKindCord_tNedit.Enabled         = false;
                    // 2007.05.17  S.Koga  add --------------------------------
                    //this.RegiMgCd_tComboEditor.Enabled = true;  // DEL 2008/06/12
                    // --------------------------------------------------------

                    this.MnyKindName_tEdit.Focus();
                    this.MnyKindName_tEdit.SelectAll();

					//��ʏ����r�p�N���[���ɃR�s�[����@�@�@�@�@   
                    this._moneyKindClone = mnykind.Clone();     //�N���[���쐬
					DispToInsutance( ref this._moneyKindClone);
				}
				else
				{
					// �폜���[�h
					this.Mode_Label.Text = DELETE_MODE;

					this.Ok_Button.Visible = false;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;
                    this.Delete_Button.Focus();

					ScreenInputPermissionControl(false);

				}
            }
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			//_dataIndex�o�b�t�@�ێ�
			this._indexBuffer = this._dataIndex;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
            //���z��ʗp
            this.MnyKindCord_tNedit.Enabled         = enabled;
            this.MnyKindName_tEdit.Enabled          = enabled;

            // DEL 2008/09/19 �s��Ή�[5416]��
            //this.PriceStCd_tComboEditor.Enabled     = enabled;

            this.MnyKindDivCd_tComboEditor.Enabled  = enabled;
            // 2007.05.17  S.Koga  add ----------------------------------------
            //this.RegiMgCd_tComboEditor.Enabled      = enabled;  // DEL 2008/06/12
            // ----------------------------------------------------------------
		}

		/// <summary>
		/// ���z��ʃN���X��ʓW�J����
		/// </summary>
		/// <param name="moneykind">���z��ʃI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���z��ʃI�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        private void InsutanceToDisp(MoneyKind moneykind)
        {
            //���z��ʗp
            this.MnyKindCord_tNedit.SetInt(moneykind.MoneyKindCode);            //���z��ʃR�[�h
            this.MnyKindName_tEdit.Text             = moneykind.MoneyKindName;  //���z��ʖ���

            // DEL 2008/09/19 �s��Ή�[5416]��
            //this.PriceStCd_tComboEditor.Value       = moneykind.PriceStCode;    //���z�ݒ�敪

            this.MnyKindDivCd_tComboEditor.Value    = moneykind.MoneyKindDiv;   //����R�[�h
            // 2007.05.17  S.Koga  add ----------------------------------------
            //this.RegiMgCd_tComboEditor.Value        = moneykind.RegiMgCd;       //���W�Ǘ��敪  // DEL 2008/06/12
            // ----------------------------------------------------------------
        
        }


		/// <summary>
		/// ��ʏ����z��ʃN���X�i�[����
		/// </summary>
		/// <param name="moneykind">���z��ʃI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂���z��ʃI�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        private void DispToInsutance(ref MoneyKind moneykind)
		{
			if (moneykind == null)
            {				
				moneykind = new MoneyKind();    // �V�K�̏ꍇ
			}

			moneykind.EnterpriseCode  = this._enterpriseCode;			            //TODO:�v�ύX

            // DEL 2008/09/19 �s��Ή�[5416]�� 
            //moneykind.PriceStCode     = (int)this.PriceStCd_tComboEditor.Value;
            // ���z�敪
            moneykind.PriceStCode = 0;  // ADD 2008/09/19 �s��Ή�[5416]

            moneykind.MoneyKindDiv    = (int)this.MnyKindDivCd_tComboEditor.Value; //����敪
            moneykind.MoneyKindCode	  = this.MnyKindCord_tNedit.GetInt();           //����ʃR�[�h
            moneykind.MoneyKindName   = this.MnyKindName_tEdit.Text;      //���z��ʖ���
            // 2007.05.17  S.Koga  add ----------------------------------------
            //moneykind.RegiMgCd = (int)this.RegiMgCd_tComboEditor.Value;  // DEL 2008/06/12
            // ----------------------------------------------------------------
		}


		/// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
        {
            # region 2007.05.17  S.Koga  DLL
            //bool result = true;
            # endregion

            //���z��ʃR�[�h���`�F�b�N
            if (this.MnyKindCord_tNedit.GetInt() == 0)
            {
                control = this.MnyKindCord_tNedit;
                message = this.MnyKindCord_Title_Label.Text + "����͂��ĉ������B";
                // 2007.05.17  S.Koga  amend ----------------------------------
				//result = false;
                return false;
                // ------------------------------------------------------------
            }else 
/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            if (this.MnyKindCord_tNedit.GetInt() < 900)
            {
                control = this.MnyKindCord_tNedit;
                message = this.MnyKindCord_Title_Label.Text + "�́u900�v�ȏ����͂��ĉ������B";
				result = false;
            }else
2005.12.17 enokide DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */			
            if (this.MnyKindName_tEdit.Text.Trim() == "")
            {
            //���z��ʖ��̂��`�F�b�N
                control = this.MnyKindName_tEdit;
                message = this.MnyKindName_Title_Label.Text + "����͂��ĉ������B";
                // 2007.05.17  S.Koga  amend ----------------------------------
                //result = false;
                return false;
                // ------------------------------------------------------------
            }

            // 2007.05.17  S.Koga  add ----------------------------------------
        if (this.MnyKindDivCd_tComboEditor.Text.Equals(""))
        {
            //����敪���`�F�b�N
            control = this.MnyKindDivCd_tComboEditor;
            message = this.MnyKindDivCd_Title_Label.Text + "����͂��ĉ������B";
            return false;
        }

        /* --- DEL 2008/06/12 -------------------------------->>>>>
        if (this.RegiMgCd_tComboEditor.Text.Equals(""))
        {
            //����敪���`�F�b�N
            control = this.RegiMgCd_tComboEditor;
            message = this.RegiMgCd_Title_Label.Text + "����͂��ĉ������B";
            return false;
        }
           --- DEL 2008/06/12 --------------------------------<<<<< */
        
        // 2007.05.17  S.Koga  amend ----------------------------------
        //return result;
        return true;
        // ------------------------------------------------------------
    }

		/// <summary>
		/// ���z��ʕۑ�����
		/// </summary>
		/// <returns>�o�^���ʌ��ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʓo�^���s���܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private bool SaveMnyKind()
		{
			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// ���̓`�F�b�N
				TMsgDisp.Show( 
					this, 								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
					"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
					message, 							// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.OK );				// �\������{�^��
				// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				MessageBox.Show(
//					message,
//					"���̓`�F�b�N",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//					MessageBoxDefaultButton.Button1);
				// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				control.Focus();
				return false;
			}

            MoneyKind moneykind = null;
            if (this.DataIndex >= 0)
            {
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                //	moneykind = (MoneyKind)this._mnykindTable[guid];
				moneykind = ((MoneyKind)this._mnykindTable[guid]).Clone();
			}

            DispToInsutance(ref moneykind);
			int status = this._mnykindAcs.Write(ref moneykind);    //�����ݏ���

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// �R�[�h�d��
					TMsgDisp.Show( 
						this, 											// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO, 					// �G���[���x��
						"SFUKK09040U", 									// �A�Z���u���h�c�܂��̓N���X�h�c
						"���̋���R�[�h�͊��Ɏg�p����Ă��܂��B",		// �\�����郁�b�Z�[�W
						0, 												// �X�e�[�^�X�l
						MessageBoxButtons.OK );							// �\������{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						//"���̕ی���ЃR�[�h�͊��Ɏg�p����Ă��܂��B",
//						"���̋���R�[�h�͊��Ɏg�p����Ă��܂��B",
//                        "���̓`�F�b�N",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

                    this.MnyKindCord_tNedit.Focus();
					return false;
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start>>>>
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return false;
				}
				//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				default:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// �T�[�`
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���z��ʐݒ�",�@					// �v���O��������
						"SaveMnyKind", 						// ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._mnykindAcs,	 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"�o�^�Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					return false;
				}
			}

            InsutanceToDataSet(moneykind, this.DataIndex);

			return true;
		}

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
		/// <summary>
		/// �r������
		/// </summary>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 23010  �����@�m</br>
		/// <br>Date       : 2005.07.07	</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// ���[���X�V
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"���ɑ��[�����X�V����Ă��܂�",
//						"����",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					this.Hide();
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// ���[���폜
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"���ɑ��[�����폜����Ă��܂�",
//						"����",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					this.Hide();
					break;
				}
			}
		}
		//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
        /// <summary>
        /// HashTable�p�L�[�쐬
        /// </summary>
        /// <param name="makerUMnt">MoneyKind�N���X</param>
        /// <returns>Hash�e�[�u���p�L�[</returns>
        /// <remarks>
        /// <br>Note      : MoneyKind�N���X����n�b�V���e�[�u���p�̃L�[���쐬���܂��B</br>
        /// <br>Programer : 96012 ���F �]</br>
        /// <br>Date      : 2008.02.29</br>
        /// </remarks>
        private string CreateHashKey(MoneyKind moneyKind)
        {
            return moneyKind.EnterpriseCode + moneyKind.PriceStCode.ToString("d2") + moneyKind.MoneyKindCode.ToString("d3");
        }
        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
        # endregion

		#region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFUKK09040UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 97134�@���� �딎</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void SFUKK09040UA_Load(object sender, System.EventArgs e)
		{
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
		/// Form.Closing �C�x���g(SFUKK09040UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 97134�@���� �딎</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void SFUKK09040UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFUKK09040UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 97134�@���� �딎</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void SFUKK09040UA_VisibleChanged(object sender, System.EventArgs e)
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

			// 2005.07.07 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			if (this._indexBuffer == this._dataIndex)
			{
				return;
			}
			// 2005.07.07 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

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
		/// <br>Programmer  : 97134�@���� �딎</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// ���z��ʓo�^����
			if (SaveMnyKind() == false)
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

                // DEL 2008/09/19 �s��Ή�[5416]��
                //this.PriceStCd_tComboEditor.Focus();
                this.MnyKindCord_tNedit.Focus();    // ADD 2008/09/19 �s��Ή�[5416]

				// �N���[�����ēx�擾����
                MoneyKind moneykind = new MoneyKind();

				//�N���[���쐬
                this._moneyKindClone = moneykind.Clone();

				DispToInsutance( ref this._moneyKindClone);

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

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
				this._indexBuffer = -2;
				//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 97134�@���� �딎</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE && this.Mode_Label.Text != VIEW_MODE)
			{
                //�ۑ��m�F
                MoneyKind cmpMoneyKind = new MoneyKind();
                cmpMoneyKind = this._moneyKindClone.Clone();
				//���݂̉�ʏ����擾����
				DispToInsutance( ref cmpMoneyKind);
				//�ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._moneyKindClone.Equals(cmpMoneyKind)))	
				{
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// �ۑ��m�F
					DialogResult res = TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
						"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						null, 								// �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel );	// �\������{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					DialogResult res = MessageBox.Show("�ҏW���̃f�[�^�����݂��܂�"+"\r\n"+"\r\n"+"�o�^���Ă���낵���ł����H","�ۑ��m�F",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					switch(res)
					{
						case DialogResult.Yes:
						{
							// ���z��ʓo�^����
							if (SaveMnyKind() == false)
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
							// 2005.09.02 TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
							this.Cancel_Button.Focus();
							// 2005.09.02 TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
							return;
						}
					}
				}
			}
			
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
				UnDisplaying(this, me);
			}

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
		/// <br>Programmer  : 97134�@���� �딎</br>
		/// <br>Date        : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// ���S�폜�m�F
			DialogResult result = TMsgDisp.Show( 
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
				"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B" + "\r\n" + 
				"��낵���ł����H", 				// �\�����郁�b�Z�[�W
				0, 									// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel, 		// �\������{�^��
				MessageBoxDefaultButton.Button2 );	// �����\���{�^��
			// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
			// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			DialogResult result = MessageBox.Show(
//				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
//				"�폜�m�F",
//				MessageBoxButtons.OKCancel,
//				MessageBoxIcon.Exclamation,
//				MessageBoxDefaultButton.Button2);
			// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			if (result == DialogResult.OK)
			{
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];    //��د�ނ��폜ں��ޏ��擾
                string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];    //��د�ނ��폜ں��ޏ��擾
                // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                MoneyKind moneykind = (MoneyKind)this._mnykindTable[guid];                                          //�����R�s�[
                int status = this._mnykindAcs.Delete(moneykind);                                                    //�폜����

                switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this.DataIndex].Delete();
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
                        //this._mnykindTable.Remove(moneykind.FileHeaderGuid);
                        this._mnykindTable.Remove(CreateHashKey(moneykind));
                        // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
                        break;
					}
					////////////////////////////////////2005 07.07 H.NAKAMURA ADD STA //////////////
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						return ;
					}
					///////////////////////////////////2005 07.07 H.NAKAMURA ADD END //////////////
					default:
					{
						// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
						// �����폜
						TMsgDisp.Show( 
							this, 								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
							"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
							"���z��ʐݒ�",�@					// �v���O��������
							"Delete_Button_Click", 				// ��������
							TMsgDisp.OPE_GET, 					// �I�y���[�V����
							"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
							status, 							// �X�e�[�^�X�l
							this._mnykindAcs,	 				// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK, 				// �\������{�^��
							MessageBoxDefaultButton.Button1 );	// �����\���{�^��
						// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
						// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//						MessageBox.Show(
//							"�폜�Ɏ��s���܂����B st = " + status.ToString(),
//							"�G���[",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
						// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

						return;
					}
				}
			}
			else
			{
				// 2005.09.26 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				this.Delete_Button.Focus();
				// 2005.09.26 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
		/// <br>Programmer  : 97134�@���� �딎</br>
		/// <br>Date        : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
        /// <br>           : HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~)</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) Begin
            //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
            string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
            // 2008.02.29 96012 HashTable�̃L�[�ύX(FileHeaderGuid�̎g�p�֎~) end
            MoneyKind moneykind = (MoneyKind)this._mnykindTable[guid];
                
            //��������
            int status = this._mnykindAcs.Revival(ref moneykind);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				////////////////////////////////////2005 07.07 H.NAKAMURA ADD STA //////////////
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return ;
				}
				///////////////////////////////////2005 07.07 H.NAKAMURA ADD END //////////////
				
				///////////////////////////////////2005 07.07 H.NAKAMURA DEL STA //////////////
//				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//				{
//					MessageBox.Show(
//						"���Ƀf�[�^�����S�폜����Ă��܂��B" + status.ToString(),
//						"���",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);
//
//					break;
//				}
				//////////////////////////////////2005 07.07 H.NAKAMURA DEL END ////////////////
				default:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// �������s
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKK09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���z��ʐݒ�",�@�@ 				// �v���O��������
						"Revive_Button_Click", 				// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._mnykindAcs, 					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"�����Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					this.Hide();
					return;
				}
			}


            InsutanceToDataSet(moneykind, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
		/// <br>Programmer  : 97134�@���� �딎</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}


		/// <summary>
		/// ���z��ʋ敪�e�[�u�쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���z��ʋ敪�e�[�u���쐬���܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        private void SetMnyKindDivTbl()
        {
			MnyKindDivAcs mnyKindDivAcs = new MnyKindDivAcs();
			ArrayList mnyKindDivList;
            mnyKindDivAcs.Search(out mnyKindDivList);

            // 2007.05.17  S.Koga  amend --------------------------------------
            // ���z��ʂ�K�{���ڂɂ��邽�߁A��̃f�[�^���폜
            // ----------------------------------------------------------------
            //int[] divCd = new int[mnyKindDivList.Count + 1];
            //string[] divName = new string[ mnyKindDivList.Count + 1 ];
            int[] divCd = new int[mnyKindDivList.Count];
            string[] divName = new string[mnyKindDivList.Count];

            //divCd[0]   = 0;		// ���z��ʋ敪
            //divName[0] = " ";	// ���z��ʖ���
            //int ix = 1;
            int ix = 0;
            // ----------------------------------------------------------------
			foreach( MnyKindDiv mnyKindDiv in mnyKindDivList )
			{
				divCd[ix]	= mnyKindDiv.MoneyKindDiv;		// ���z��ʋ敪
				divName[ix] = mnyKindDiv.MoneyKindDivName;	// ���z��ʖ���
				ix++;
			}


//// ------------------------------------------------------>>
//            //TODO:�����e�i���X��������   2005.06.22 SF���ϲ�� ���� 
//            //     �����_�ł͋��z��ʋ敪�}�X�^�̃����[�g���i���������߁A���̎擾�͂ł��܂���B
//            //     �����[�g���i������͂����ł���Searchҿ��ނ��g�p���S�f�[�^�̎擾���s���ĉ������B           
//            
//            //�����[�g���i���������̂��߃e�X�g�p�Ƀf�[�^���Z�b�g����
//            //�e�X�g�p���W�b�N
//            string[] divName = {"�����E���؎�","�U����","�N���W�b�g","�萔��","��`","���E","���̑�","�l����","�a�����",
//                                 "�T�[�r�X","��������","�N���[��","�������"};
//            int[]    divCd    = {101,102,103,104,105,106,107,108,109,
//                                  201,202,203,204};
//// ------------------------------------------------------>>

            
            //�ϊ��e�[�u���փZ�b�g
            for(int cnt = 0; cnt <divName.Length ; cnt++) {
                this._mnykindDivTbl.Add(divCd[cnt],   divName[cnt]); //���ނ𷰂ɖ��̂�l�ɂ��Z�b�g
            }
        }
		# endregion


        //���z��ʋ敪�p�\����
        struct MnyKindDibInf
        {
            public int    mnykinddivCd;
            public string mnykinddivNm;        
        }

        //
		/// <summary>
		/// ����R�[�h�����ё֗p�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����R�[�h���ɕ��ёւ��܂��B</br>
		/// <br>Programmer : 97134�@���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        public class IMnyKindDibComp : IComparer  
        {
            int IComparer.Compare( Object x, Object y )  
            {
                return ((MnyKindDibInf)x).mnykinddivCd - ((MnyKindDibInf)y).mnykinddivCd;
            }
        }

	}


}
