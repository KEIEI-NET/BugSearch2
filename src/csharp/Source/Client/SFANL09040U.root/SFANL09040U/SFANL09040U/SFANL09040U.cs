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
	/// ���[�o�͐ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�o�͐ݒ���s���܂��B
	///					 IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer : 23010 �����@�m</br>
	/// <br>Date       : 2005.08.12</br>
	/// <br>Update Note: 2005.09.02 22021 �J��</br> 
	/// <br>             �ۑ��m�F��̃G���^�[�L�[�������̃t�H�[�J�X�Ή�</br>
	/// <br>Update Note: 2005.09.08 22021 �J���@�͍K</br>
	/// <br>			 �E���O�C�����擾���i�̑g����</br>
	/// <br>Update Note: 2005.09.22 22021 �J���@�͍K</br>
	/// <br>			 �E���b�Z�[�W�\���̕ύX</br>
	/// <br>Update Note: 2005.10.19 22021 �J���@�͍K</br>
	/// <br>		   : �EUI�q���Hide����Owner.Activate�����ǉ�</br>
    /// <br>UpdateNote  : 2008/11/04 30462 �s�V�m���@�o�O�C��</br>
	/// </remarks>

	public class SFANL09040UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{	
		# region Private Members (Component)

		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.Misc.UltraLabel SectionCd_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel PrintFooter1_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel PrintFooter2_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel FooterPrintOutCd_ultraLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor FooterPrintOutCd_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TEdit SectionCd_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PrintFooter1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PrintFooter2_tEdit;
		private Infragistics.Win.Misc.UltraLabel SectionNm_ultraLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel ExtraCondHeadOutDiv_ultraLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor ExtraCondHeadOutDiv_tComboEditor;
		private System.ComponentModel.IContainer components;

	    # endregion
		
		# region Constructor
		/// <summary>
		/// ���[�o�͐ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�o�͐ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>

		public SFANL09040UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint				             = false;
			this._canNew					         = false;
			this._canDelete				             = false;
			this._canLogicalDeleteDataExtraction 	 = false;
			this._canClose				             = true;	
			this._defaultAutoFillToColumn		     = true;
			this._canSpecificationSearch		     = false;
			this._dataIndex                          = -1;
			
			//�@��ƃR�[�h���擾����
			// 2005.09.08 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//			this._enterpriseCode = "TBS1";	// �� �v�ύX
			// 2005.09.08 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			// �ŏ����Ή�
			this._indexBuf = -2;
			// ��r�p�N���[��
			this._prtOutSetClone = new PrtOutSet();
			// Work�pHashTable
			this._prtOutSetTable = new Hashtable();

			this._prtOutSetAcs   = new PrtOutSetAcs();
			this._prtOutSet      = new PrtOutSet();
			

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
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL09040UA));
            this.SectionCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrintFooter1_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrintFooter2_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.FooterPrintOutCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.FooterPrintOutCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SectionCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrintFooter1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrintFooter2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionNm_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ExtraCondHeadOutDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ExtraCondHeadOutDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.FooterPrintOutCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintFooter1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintFooter2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCondHeadOutDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // SectionCd_ultraLabel
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.SectionCd_ultraLabel.Appearance = appearance1;
            this.SectionCd_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SectionCd_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionCd_ultraLabel.Location = new System.Drawing.Point(16, 12);
            this.SectionCd_ultraLabel.Name = "SectionCd_ultraLabel";
            this.SectionCd_ultraLabel.Size = new System.Drawing.Size(100, 25);
            this.SectionCd_ultraLabel.TabIndex = 8;
            this.SectionCd_ultraLabel.Text = "���_�R�[�h";
            // 
            // PrintFooter1_ultraLabel
            // 
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.PrintFooter1_ultraLabel.Appearance = appearance2;
            this.PrintFooter1_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.PrintFooter1_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintFooter1_ultraLabel.Location = new System.Drawing.Point(16, 100);
            this.PrintFooter1_ultraLabel.Name = "PrintFooter1_ultraLabel";
            this.PrintFooter1_ultraLabel.Size = new System.Drawing.Size(144, 25);
            this.PrintFooter1_ultraLabel.TabIndex = 1;
            this.PrintFooter1_ultraLabel.Text = "���[�t�b�^�[����";
            // 
            // PrintFooter2_ultraLabel
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.PrintFooter2_ultraLabel.Appearance = appearance3;
            this.PrintFooter2_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.PrintFooter2_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintFooter2_ultraLabel.Location = new System.Drawing.Point(16, 136);
            this.PrintFooter2_ultraLabel.Name = "PrintFooter2_ultraLabel";
            this.PrintFooter2_ultraLabel.Size = new System.Drawing.Size(144, 25);
            this.PrintFooter2_ultraLabel.TabIndex = 3;
            this.PrintFooter2_ultraLabel.Text = "���[�t�b�^�[���E";
            // 
            // FooterPrintOutCd_ultraLabel
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.FooterPrintOutCd_ultraLabel.Appearance = appearance4;
            this.FooterPrintOutCd_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.FooterPrintOutCd_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FooterPrintOutCd_ultraLabel.Location = new System.Drawing.Point(16, 172);
            this.FooterPrintOutCd_ultraLabel.Name = "FooterPrintOutCd_ultraLabel";
            this.FooterPrintOutCd_ultraLabel.Size = new System.Drawing.Size(132, 25);
            this.FooterPrintOutCd_ultraLabel.TabIndex = 5;
            this.FooterPrintOutCd_ultraLabel.Text = "�t�b�^�[�o�͋敪";
            // 
            // FooterPrintOutCd_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FooterPrintOutCd_tComboEditor.ActiveAppearance = appearance5;
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.FooterPrintOutCd_tComboEditor.Appearance = appearance6;
            this.FooterPrintOutCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FooterPrintOutCd_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FooterPrintOutCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FooterPrintOutCd_tComboEditor.ItemAppearance = appearance7;
            this.FooterPrintOutCd_tComboEditor.Location = new System.Drawing.Point(196, 172);
            this.FooterPrintOutCd_tComboEditor.MaxDropDownItems = 18;
            this.FooterPrintOutCd_tComboEditor.Name = "FooterPrintOutCd_tComboEditor";
            this.FooterPrintOutCd_tComboEditor.Size = new System.Drawing.Size(115, 24);
            this.FooterPrintOutCd_tComboEditor.TabIndex = 3;
            // 
            // SectionCd_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionCd_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionCd_tEdit.Appearance = appearance9;
            this.SectionCd_tEdit.AutoSelect = true;
            this.SectionCd_tEdit.DataText = "";
            this.SectionCd_tEdit.Enabled = false;
            this.SectionCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionCd_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionCd_tEdit.Location = new System.Drawing.Point(196, 13);
            this.SectionCd_tEdit.MaxLength = 6;
            this.SectionCd_tEdit.Name = "SectionCd_tEdit";
            this.SectionCd_tEdit.Size = new System.Drawing.Size(68, 24);
            this.SectionCd_tEdit.TabIndex = 9;
            // 
            // PrintFooter1_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintFooter1_tEdit.ActiveAppearance = appearance10;
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.PrintFooter1_tEdit.Appearance = appearance11;
            this.PrintFooter1_tEdit.AutoSelect = true;
            this.PrintFooter1_tEdit.DataText = "";
            this.PrintFooter1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintFooter1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 25, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PrintFooter1_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintFooter1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PrintFooter1_tEdit.Location = new System.Drawing.Point(196, 100);
            this.PrintFooter1_tEdit.MaxLength = 25;
            this.PrintFooter1_tEdit.Name = "PrintFooter1_tEdit";
            this.PrintFooter1_tEdit.Size = new System.Drawing.Size(401, 24);
            this.PrintFooter1_tEdit.TabIndex = 1;
            // 
            // PrintFooter2_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintFooter2_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.PrintFooter2_tEdit.Appearance = appearance13;
            this.PrintFooter2_tEdit.AutoSelect = true;
            this.PrintFooter2_tEdit.DataText = "";
            this.PrintFooter2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintFooter2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 25, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PrintFooter2_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintFooter2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PrintFooter2_tEdit.Location = new System.Drawing.Point(196, 136);
            this.PrintFooter2_tEdit.MaxLength = 25;
            this.PrintFooter2_tEdit.Name = "PrintFooter2_tEdit";
            this.PrintFooter2_tEdit.Size = new System.Drawing.Size(401, 24);
            this.PrintFooter2_tEdit.TabIndex = 2;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 267);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(608, 23);
            this.ultraStatusBar1.TabIndex = 13;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Ok_Button
            // 
            this.Ok_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(348, 212);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 6;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(476, 212);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Mode_Label
            // 
            appearance14.ForeColor = System.Drawing.Color.White;
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance14.TextHAlignAsString = "Center";
            appearance14.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance14;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance15.TextHAlignAsString = "Center";
            appearance15.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance15;
            this.Mode_Label.Location = new System.Drawing.Point(500, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 14;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // SectionNm_ultraLabel
            // 
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.SectionNm_ultraLabel.Appearance = appearance16;
            this.SectionNm_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SectionNm_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionNm_ultraLabel.Location = new System.Drawing.Point(16, 47);
            this.SectionNm_ultraLabel.Name = "SectionNm_ultraLabel";
            this.SectionNm_ultraLabel.Size = new System.Drawing.Size(100, 25);
            this.SectionNm_ultraLabel.TabIndex = 10;
            this.SectionNm_ultraLabel.Text = "���_��";
            // 
            // SectionNm_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionNm_tEdit.ActiveAppearance = appearance17;
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance18;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.Enabled = false;
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionNm_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionNm_tEdit.Location = new System.Drawing.Point(196, 48);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 11;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(10, 84);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(590, 3);
            this.ultraLabel15.TabIndex = 12;
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
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ExtraCondHeadOutDiv_ultraLabel
            // 
            appearance22.TextHAlignAsString = "Left";
            appearance22.TextVAlignAsString = "Middle";
            this.ExtraCondHeadOutDiv_ultraLabel.Appearance = appearance22;
            this.ExtraCondHeadOutDiv_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ExtraCondHeadOutDiv_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExtraCondHeadOutDiv_ultraLabel.Location = new System.Drawing.Point(16, 208);
            this.ExtraCondHeadOutDiv_ultraLabel.Name = "ExtraCondHeadOutDiv_ultraLabel";
            this.ExtraCondHeadOutDiv_ultraLabel.Size = new System.Drawing.Size(176, 25);
            this.ExtraCondHeadOutDiv_ultraLabel.TabIndex = 15;
            this.ExtraCondHeadOutDiv_ultraLabel.Text = "���o�����w�b�_�o�͋敪";
            // 
            // ExtraCondHeadOutDiv_tComboEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ExtraCondHeadOutDiv_tComboEditor.ActiveAppearance = appearance19;
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.ExtraCondHeadOutDiv_tComboEditor.Appearance = appearance20;
            this.ExtraCondHeadOutDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ExtraCondHeadOutDiv_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExtraCondHeadOutDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ExtraCondHeadOutDiv_tComboEditor.ItemAppearance = appearance21;
            this.ExtraCondHeadOutDiv_tComboEditor.Location = new System.Drawing.Point(12, 240);
            this.ExtraCondHeadOutDiv_tComboEditor.MaxDropDownItems = 18;
            this.ExtraCondHeadOutDiv_tComboEditor.Name = "ExtraCondHeadOutDiv_tComboEditor";
            this.ExtraCondHeadOutDiv_tComboEditor.Size = new System.Drawing.Size(208, 24);
            this.ExtraCondHeadOutDiv_tComboEditor.TabIndex = 0;
            // 
            // SFANL09040UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(608, 290);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.ExtraCondHeadOutDiv_tComboEditor);
            this.Controls.Add(this.ExtraCondHeadOutDiv_ultraLabel);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionNm_ultraLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.PrintFooter2_tEdit);
            this.Controls.Add(this.PrintFooter1_tEdit);
            this.Controls.Add(this.SectionCd_tEdit);
            this.Controls.Add(this.FooterPrintOutCd_tComboEditor);
            this.Controls.Add(this.FooterPrintOutCd_ultraLabel);
            this.Controls.Add(this.PrintFooter2_ultraLabel);
            this.Controls.Add(this.PrintFooter1_ultraLabel);
            this.Controls.Add(this.SectionCd_ultraLabel);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFANL09040UA";
            this.Text = "���[�o�͐ݒ�";
            this.Load += new System.EventHandler(this.SFANL09040U_Load);
            this.VisibleChanged += new System.EventHandler(this.SFANL09040U_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFANL09040U_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.FooterPrintOutCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintFooter1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintFooter2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCondHeadOutDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion
		
		# region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{	
			System.Windows.Forms.Application.Run(new SFANL09040UA());
		}
		# endregion

		#region Private Menbers

		// �A�N�Z�X�N���X�����o
		private PrtOutSetAcs _prtOutSetAcs;
		// �f�[�^�N���X�����o
		private PrtOutSet _prtOutSet;
		// ���Code
		private string _enterpriseCode;
		// Work�pHashTable
		private Hashtable _prtOutSetTable;
		// _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;
		// ��r�pClone
		private PrtOutSet _prtOutSetClone;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;
		
		// Frame��Grid���KEY��� (Header��Title���ƂȂ�܂�)
		private const string SECTION_CODE_TITLE			    = "���_�R�[�h";
        //private const string SECTION_NAME_TITLE             = "���_����";       // DEL 2008/11/04 �s��Ή�[7308]
        private const string SECTION_NAME_TITLE             = "���_��";         // ADD 2008/11/04 �s��Ή�[7308]
		private const string EXTRA_COND_HEAD_OUT_DIV_TITLE	= "���o�����w�b�_�o�͋敪";
		private const string PRINT_FOOTER_TITLE�P			= "���[�t�b�^�[����";
		private const string PRINT_FOOTER_TITLE�Q			= "���[�t�b�^�[���E";
		private const string FOOTER_PRINT_OUT_CODE_TITLE	= "�t�b�^�[�o�͋敪";
		private const string GUID_KEY_TITLE			        = "Guid";

		// Frame��Grid�ɕ\��������e�[�u����
		private const string VIEW_TABLE = "VIEW_TABLE";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";	   
		private const string DELETE_MODE = "�폜���[�h";

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
		# endregion
		
		# region Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.11</br>
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
		/// <br>Programmer	: 23010�@�����@�m</br>
		/// <br>Date		: 2005.08.11</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{	
			int status = 0;
			int index = 0;
			ArrayList prtOutSetList = new ArrayList();

			status = this._prtOutSetAcs.Search(
				out prtOutSetList,
				this._enterpriseCode);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					foreach(PrtOutSet prtOutSet in prtOutSetList)
					{
						if (this._prtOutSetTable.ContainsKey(prtOutSet.FileHeaderGuid) == false)
						{
							prtOutSetToDataSet(prtOutSet.Clone(), index);
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
						"SFANL09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���[�o�͐ݒ�",						// �v���O��������
						"Search", 							// ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._prtOutSetAcs,	 				// �G���[�����������I�u�W�F�N�g
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
			totalCount = index;
			return status;

		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2005.08.11</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// �S�����o����׏�������
			return 9;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �I�𒆂̃f�[�^���폜���܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2005.08.11</br>
		/// </remarks>
		public int Delete()
		{
			// �폜��������
			return 0;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ������������s���܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2005.08.11</br>
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
		/// <br>Note		: �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2005.08.18</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(SECTION_CODE_TITLE			     ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black)); 
			appearanceTable.Add(SECTION_NAME_TITLE		�@       ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			
			// ���������
			appearanceTable.Add(EXTRA_COND_HEAD_OUT_DIV_TITLE    ,new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));
�@�@    	
			appearanceTable.Add(PRINT_FOOTER_TITLE�P    �@�@     ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(PRINT_FOOTER_TITLE�Q�@           ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(FOOTER_PRINT_OUT_CODE_TITLE	     ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			// GUID�͔�\��
			appearanceTable.Add(GUID_KEY_TITLE			         ,new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			return appearanceTable;
		}

		# endregion

		# region Private Method
		/// <summary>
		/// ���[�o�͐ݒ�f�[�^�Z�b�g����
		/// </summary>
		/// <param name="vlPntMtRtU">���[�o�͐ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note		: ���[�o�͐ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date		: 2005.08.18</br>
		/// </remarks>
		private void prtOutSetToDataSet(PrtOutSet prtOutSet, int index)
		{	
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ��ɂ���
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}
			
			// ���_�R�[�h
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTION_CODE_TITLE] = prtOutSet.SectionCode;
			// ���_����
//			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTION_NAME_TITLE] = prtOutSet.SectionName + "�@" + prtOutSet.SectionName2;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTION_NAME_TITLE] = prtOutSet.SectionName;
			// ���[�t�b�^�[����
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRINT_FOOTER_TITLE�P] = prtOutSet.PrintFooter1;
			// ���[�t�b�^�[���E
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRINT_FOOTER_TITLE�Q] = prtOutSet.PrintFooter2;
			// �t�b�^�[�o�͋敪
			switch(prtOutSet.FooterPrintOutCode)
			{
				case(0):
				{
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][FOOTER_PRINT_OUT_CODE_TITLE] = "����";
					break;
				}
				case(1):
				{
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][FOOTER_PRINT_OUT_CODE_TITLE] = "���Ȃ�";
					break;
				}
				default:
				{
					break;
				}
			}
			
			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// ���o�����w�b�_�o�͋敪
			switch(prtOutSet.ExtraCondHeadOutDiv)
			{
				case(0):
				{
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][EXTRA_COND_HEAD_OUT_DIV_TITLE] = "���y�[�W�o�͂���";
					break;
				}
				case(1):
				{
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][EXTRA_COND_HEAD_OUT_DIV_TITLE] = "�P�y�[�W�ڂ̂ݏo�͂���";
					break;
				}
				default:
				{
					break;
				}
			}
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// GUID
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][GUID_KEY_TITLE] = prtOutSet.FileHeaderGuid;

			if (this._prtOutSetTable.ContainsKey(prtOutSet.FileHeaderGuid) == true)
			{
				this._prtOutSetTable.Remove(prtOutSet.FileHeaderGuid);
			}
			this._prtOutSetTable.Add(prtOutSet.FileHeaderGuid, prtOutSet);	
	
		}

		/// <summary>
		/// �O���b�h�o�C���h����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �z�񍀖ڂ��O���b�h�փo�C���h���܂��B</br>
		/// <br>Programmer	: 23010 �����@�m</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{	
			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			DataTable viewTable	= new DataTable(VIEW_TABLE);
			viewTable.Columns.Add(SECTION_CODE_TITLE			�@ , typeof(string));
			viewTable.Columns.Add(SECTION_NAME_TITLE               , typeof(string));
			viewTable.Columns.Add(EXTRA_COND_HEAD_OUT_DIV_TITLE	   , typeof(string));
			viewTable.Columns.Add(PRINT_FOOTER_TITLE�P		       , typeof(string));
			viewTable.Columns.Add(PRINT_FOOTER_TITLE�Q		       , typeof(string));
			viewTable.Columns.Add(FOOTER_PRINT_OUT_CODE_TITLE	   , typeof(string));
			viewTable.Columns.Add(GUID_KEY_TITLE				   , typeof(Guid));
			this.Bind_DataSet.Tables.Add(viewTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			this.FooterPrintOutCd_tComboEditor.Items.Clear();
			this.FooterPrintOutCd_tComboEditor.Items.Add(0, "����");									
			this.FooterPrintOutCd_tComboEditor.Items.Add(1, "���Ȃ�");									
			this.FooterPrintOutCd_tComboEditor.MaxDropDownItems = this.FooterPrintOutCd_tComboEditor.Items.Count;

			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this.ExtraCondHeadOutDiv_tComboEditor.Items.Clear();
			this.ExtraCondHeadOutDiv_tComboEditor.Items.Add(0, "���y�[�W�o�͂���");									
			this.ExtraCondHeadOutDiv_tComboEditor.Items.Add(1, "�P�y�[�W�ڂ̂ݏo�͂���");									
			this.ExtraCondHeadOutDiv_tComboEditor.MaxDropDownItems = this.ExtraCondHeadOutDiv_tComboEditor.Items.Count;
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// ���������
			// 2005.11.18 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this.ExtraCondHeadOutDiv_ultraLabel.Visible = false;
			this.ExtraCondHeadOutDiv_tComboEditor.Visible = false;
			// 2005.11.18 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		
		}

		/// <summary>
		/// ��ʏ���������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏��������s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void ScreenClear()
		{	
			this.SectionCd_tEdit.Text			    = "";
			this.SectionNm_tEdit.Text			    = "";
			this.PrintFooter1_tEdit.Text			= "";
			this.PrintFooter2_tEdit.Text			= "";
			this.FooterPrintOutCd_tComboEditor.SelectedIndex = 0;
			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this.ExtraCondHeadOutDiv_tComboEditor.SelectedIndex = 0;
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
		/// <br>Programmer : 23010 ���� �m</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			if (this._dataIndex < 0)
			{
				// �V�K���[�h
				//���肦�Ȃ��̂Ŗ�����
			}
			else
			{
				// �ێ����Ă���f�[�^�Z�b�g���C���O���擾
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_KEY_TITLE];
				PrtOutSet prtOutSet = (PrtOutSet)this._prtOutSetTable[guid];
				
				// ���[�o�̓N���X��ʓW�J����
				PrtOutSetToScreen(prtOutSet);

				// �X�V���[�h
				this.Mode_Label.Text = UPDATE_MODE;

				// �����t�H�[�J�X��ݒ�@	
				this.PrintFooter1_tEdit.Focus();
				this.PrintFooter1_tEdit.SelectAll();
				
				// ����������\��
				// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				this.ExtraCondHeadOutDiv_tComboEditor.Focus();
				// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				//�N���[���쐬
				this._prtOutSetClone = prtOutSet.Clone();
  
				//��ʏ����r�p�N���[���ɃR�s�[����@�@�@�@�@   
				DispToPrtOutSet(ref this._prtOutSetClone);

				// �t���[���̍ŏ����Ή�
				this._indexBuf = this._dataIndex;
			}
		}

		/// <summary>
		/// ���_���N���X��ʓW�J����
		/// </summary>
		/// <param name="secInfoSet">���_���N���X</param>
		/// <remarks>
		/// <br>Note       : ���_���N���X��񂩂��ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void PrtOutSetToScreen(PrtOutSet prtOutSet)
		{	
			// ���_�R�[�h
			this.SectionCd_tEdit.Text = prtOutSet.SectionCode;
			// ���_����
			
			//2005.10.14 N.TANIFUJI DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
//			this.SectionNm_tEdit.Text = prtOutSet.SectionName + "�@" + prtOutSet.SectionName2;
			//2005.10.14 N.TANIFUJI DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
			
			//2005.10.14 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
			this.SectionNm_tEdit.Text = prtOutSet.SectionName; // + "�@" + prtOutSet.SectionName2;
			//2005.10.14 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

			// ���[�t�b�^�[�����@
			this.PrintFooter1_tEdit.Text = prtOutSet.PrintFooter1;
			// ���[�t�b�^�[���E
			this.PrintFooter2_tEdit.Text = prtOutSet.PrintFooter2;
			// �t�b�^�[�o�͋敪
			this.FooterPrintOutCd_tComboEditor.SelectedIndex = prtOutSet.FooterPrintOutCode;

			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// ���o�����w�b�_�o�͋敪
			this.ExtraCondHeadOutDiv_tComboEditor.SelectedIndex = prtOutSet.ExtraCondHeadOutDiv;
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		}

		/// <summary>
		/// ��ʏ�񋒓_���N���X�i�[����
		/// </summary>
		/// <param name="secInfoSet">���_���N���X</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂狒�_���N���X�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void DispToPrtOutSet(ref PrtOutSet prtOutSet)
		{
			if (prtOutSet == null)
			{
				// �V�K�̏ꍇ
				prtOutSet = new PrtOutSet();
			}
			// ��ƃR�[�h
			prtOutSet.EnterpriseCode = this._enterpriseCode;
			prtOutSet.SectionCode  = this.SectionCd_tEdit.Text.TrimEnd();
 //		    prtOutSet.SectionName  = this.SectionNm_tEdit.Text.TrimEnd();
			prtOutSet.PrintFooter1 = this.PrintFooter1_tEdit.Text.TrimEnd();
			prtOutSet.PrintFooter2 = this.PrintFooter2_tEdit.Text.TrimEnd();
			prtOutSet.FooterPrintOutCode = this.FooterPrintOutCd_tComboEditor.SelectedIndex;
			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			prtOutSet.ExtraCondHeadOutDiv = this.ExtraCondHeadOutDiv_tComboEditor.SelectedIndex;
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>�o�^���ʌ��ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �ۑ��������s���܂��B</br>
		/// <br>Programmer : 23010�@�����@�m</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private bool SavePrtOutSet()
		{
			PrtOutSet prtOutSet = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_KEY_TITLE];
//				prtOutSet = (PrtOutSet)this._prtOutSetTable[guid];
				prtOutSet = ((PrtOutSet)this._prtOutSetTable[guid]).Clone();
			}

			DispToPrtOutSet(ref prtOutSet);
			int status = this._prtOutSetAcs.Write(ref prtOutSet);    //�����ݏ���

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
					return false;
				}
				default:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// �T�[�`
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFANL09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���[�o�͐ݒ�",						// �v���O��������
						"SavePrtOutSet", 					// ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._prtOutSetAcs,	 				// �G���[�����������I�u�W�F�N�g
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

			prtOutSetToDataSet(prtOutSet, this.DataIndex);

			return true;
		}

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.19</br>
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
						"SFANL09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
						"SFANL09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
		# endregion

		#region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFANL09040U)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date	   : 2005.08.18</br>
		/// </remarks>
		private void SFANL09040U_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList	 = imageList25;
			this.Cancel_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image		= Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

			ScreenInitialSetting();		
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFANL09040U)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note �@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date	   : 2005.08.18</br>
		/// </remarks>
		private void SFANL09040U_VisibleChanged(object sender, System.EventArgs e)
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

			//�t���[���̍ŏ����Ή�
			if(this._indexBuf == this._dataIndex)
			{
				return;
			}

			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFANL09040)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 23010 �����@�m</br>
		/// <br>Date        : 2005.08.19</br>
		/// </remarks>
		private void SFANL09040U_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{	
			//Grid��IndexBuffer�i�[�p�ϐ�������
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
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 23010 �����@�m</br>
		/// <br>Date        : 2005.08.19</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// ���[�o�͓o�^����
			if (SavePrtOutSet() == false)
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

			// �t���[���̍ŏ����Ή�
			this._indexBuf = -2;
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 23010 �����@�m</br>
		/// <br>Date        : 2005.08.19</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			//�ۑ��m�F
			PrtOutSet cmpPrtOutSet = new PrtOutSet();
			cmpPrtOutSet = this._prtOutSetClone.Clone();
			//���݂̉�ʏ����擾����
			DispToPrtOutSet( ref cmpPrtOutSet);
			//�ŏ��Ɏ擾������ʏ��Ɣ�r
			if (!(this._prtOutSetClone.Equals(cmpPrtOutSet)))	
			{     
				//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
				// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// �ۑ��m�F
				DialogResult res = TMsgDisp.Show( 
					this, 								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
					"SFANL09040U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
					null, 								// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel );	// �\������{�^��
				// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				DialogResult res = MessageBox.Show("�ҏW���̃f�[�^�����݂��܂�"+"\r\n"+"\r\n"+"�o�^���Ă���낵���ł����H","�ۑ��m�F",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				switch(res)
				{
					case DialogResult.Yes:
					{
						if (SavePrtOutSet() == false)
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
			
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
				UnDisplaying(this, me);
			}
			// �t���[���̍ŏ����Ή�
			this._indexBuf = -2;
	
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
		/// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer  : 23010 �����@�m</br>
		/// <br>Date        : 2005.08.19</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		#endregion
	}
}
