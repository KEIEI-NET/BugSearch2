//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �󔭒��S�̐ݒ�
// �v���O�����T�v   : �󔭒��Ǘ��S�̐ݒ�̐ݒ���s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���F �]
// �� �� ��  2007/12/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 96012 ���F �]
// �C �� ��  2007/12/21  �C�����e : HTML�̎󔭒��v�㎞����敪�̍��ږ��ԈႢ�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30415 �ēc �ύK
// �C �� ��  2008/06/06  �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30462 �s�V �m��
// �C �� ��  2008/10/09  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/11/06  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/19  �C�����e : �s��Ή�[13578]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10704766-00  �쐬�S���F����3
// �C �� ��  2011/07/28  �C�����e�F�A��909�@���_�ݒ���s�����Ƌ��_�K�C�h������ƑS�Ћ��ʂ̕ҏW���s�����Ƃ��Ă��܂��B
//                       ���_�R�[�h�Ƌ��_�K�C�h�̃t�H�[�J�X�ړ��̓��b�Z�[�W�\�����s��Ȃ��悤�ɏC�����Ă��������B
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/19 �s��Ή��ɂ�鋤�ʎd�l�̓W�J
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/19 �s��Ή��ɂ�鋤�ʎd�l�̓W�J
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	///	�󔭒��Ǘ��S�̐ݒ�N���X
	/// </summary>
	/// <remarks> 
	/// <br>note		: �󔭒��Ǘ��S�̐ݒ�̐ݒ���s���܂��B
	///					  IMasterMaintenanceSingleType���������Ă��܂��B</br>              
	/// <br>Programer	: ���F �]</br>                            
	/// <br>Date        : 2007.12.14</br>                              
    /// <br>Update Note : 2007.12.21 96012 ���F �]</br>
    /// <br> 			  HTML�̎󔭒��v�㎞����敪�̍��ږ��ԈႢ�C��</br>
    /// <br>Programmer :  30415 �ēc �ύK</br>
    /// <br>Date       :  2008/06/06</br>
    /// <br>UpdateNote   : 2008/10/09 30462 �s�V �m���@�o�O�C��</br>
    /// <br>             : 2008/11/06       �Ɠc �M�u�@�o�O�C��</br>
    /// <br>             : 2009/06/19       �Ɠc �M�u�@�s��Ή�[13578]</br>
    /// <br>UpdateNote : 2011/09/07 ����R</br>
    /// <br>        	 �E��Q�� #24169</br>
    /// </remarks>
    public class DCKHN09230UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.Misc.UltraLabel FaxOrderDiv_Title;
        private TComboEditor FaxOrderDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AcpOdrrSlipPrtDiv_Title;
        private TComboEditor AcpOdrrSlipPrtDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel EstmCountReflectDiv_Title;
        private TComboEditor EstmCountReflectDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel SectionNm_Label;
        private TEdit tEdit_SectionCodeAllowZero2;
        private TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraButton SectionGd_ultraButton;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private DataSet Bind_DataSet;
        private UiSetControl uiSetControl1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// DCKHN09230UA�R���X�g���N�^
		/// </summary>
		/// <remarks> 
		/// <br>note			:	�󔭒��Ǘ��S�̐ݒ�N���X�A�󔭒��Ǘ��S�̐ݒ�A�N�Z�X�N���X�𐶐����܂��B
		///							�t���[����ʂ̈���{�^����\���ݒ���s���܂��B</br>
		/// <br>Programer		:	���F �]</br>                            
        /// <br>Date			:	2007.12.14</br>                              
		/// </remarks>
		public DCKHN09230UA()
		{
			InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l
            this._canClose = false;	                      // ����@�\�i�f�t�H���gtrue�Œ�j
            this._canDelete = true;		                  // �폜�@�\
            this._canLogicalDeleteDataExtraction = true;  // �_���폜�f�[�^�\���@�\
            this._canNew = true;		                  // �V�K�쐬�@�\
            this._canPrint = false;	                      // ����@�\
            this._canSpecificationSearch = false;	      // �����w�茟���@�\
            this._defaultAutoFillToColumn = false;	      // ��T�C�Y���������@�\

			//�@��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ������
            this._dataIndex = -1;
            this._acptAnOdrTtlStAcs = new AcptAnOdrTtlStAcs();
            this._secInfoAcs = new SecInfoAcs(1);
            this._logicalDeleteMode = 0;
            this._acptAnOdrTtlStTable = new Hashtable();

            // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ADD 2008/09/16 �s��Ή�[5308] ---------->>>>>
            // ���_�K�C�h�̃t�H�[�J�X����
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.EstmCountReflectDiv_tComboEditor
            );
            // ADD 2008/09/16 �s��Ή�[5308] ----------<<<<<
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
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09230UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.EstmCountReflectDiv_Title = new Infragistics.Win.Misc.UltraLabel();
            this.EstmCountReflectDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AcpOdrrSlipPrtDiv_Title = new Infragistics.Win.Misc.UltraLabel();
            this.AcpOdrrSlipPrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.FaxOrderDiv_Title = new Infragistics.Win.Misc.UltraLabel();
            this.FaxOrderDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EstmCountReflectDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrrSlipPrtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxOrderDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(364, 216);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 11;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(489, 216);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 12;
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 268);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(630, 23);
            this.ultraStatusBar1.TabIndex = 25;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Mode_Label
            // 
            appearance25.ForeColor = System.Drawing.Color.White;
            appearance25.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance25.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance25.TextHAlignAsString = "Center";
            appearance25.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance25;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance26.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance26.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance26.TextHAlignAsString = "Center";
            appearance26.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance26;
            this.Mode_Label.Location = new System.Drawing.Point(499, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 18;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // EstmCountReflectDiv_Title
            // 
            this.EstmCountReflectDiv_Title.Location = new System.Drawing.Point(12, 115);
            this.EstmCountReflectDiv_Title.Name = "EstmCountReflectDiv_Title";
            this.EstmCountReflectDiv_Title.Size = new System.Drawing.Size(162, 14);
            this.EstmCountReflectDiv_Title.TabIndex = 31;
            this.EstmCountReflectDiv_Title.Text = "���ϐ����f�敪";
            // 
            // EstmCountReflectDiv_tComboEditor
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstmCountReflectDiv_tComboEditor.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstmCountReflectDiv_tComboEditor.Appearance = appearance17;
            this.EstmCountReflectDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.EstmCountReflectDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstmCountReflectDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstmCountReflectDiv_tComboEditor.ItemAppearance = appearance18;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "�o�א�";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "�󒍐�";
            this.EstmCountReflectDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.EstmCountReflectDiv_tComboEditor.Location = new System.Drawing.Point(180, 112);
            this.EstmCountReflectDiv_tComboEditor.MaxDropDownItems = 18;
            this.EstmCountReflectDiv_tComboEditor.Name = "EstmCountReflectDiv_tComboEditor";
            this.EstmCountReflectDiv_tComboEditor.Size = new System.Drawing.Size(434, 24);
            this.EstmCountReflectDiv_tComboEditor.TabIndex = 4;
            // 
            // AcpOdrrSlipPrtDiv_Title
            // 
            this.AcpOdrrSlipPrtDiv_Title.Location = new System.Drawing.Point(12, 145);
            this.AcpOdrrSlipPrtDiv_Title.Name = "AcpOdrrSlipPrtDiv_Title";
            this.AcpOdrrSlipPrtDiv_Title.Size = new System.Drawing.Size(162, 14);
            this.AcpOdrrSlipPrtDiv_Title.TabIndex = 33;
            this.AcpOdrrSlipPrtDiv_Title.Text = "�󒍓`�[���s�敪";
            // 
            // AcpOdrrSlipPrtDiv_tComboEditor
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AcpOdrrSlipPrtDiv_tComboEditor.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.AcpOdrrSlipPrtDiv_tComboEditor.Appearance = appearance14;
            this.AcpOdrrSlipPrtDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AcpOdrrSlipPrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AcpOdrrSlipPrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AcpOdrrSlipPrtDiv_tComboEditor.ItemAppearance = appearance15;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "���Ȃ�";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "����";
            this.AcpOdrrSlipPrtDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.AcpOdrrSlipPrtDiv_tComboEditor.Location = new System.Drawing.Point(180, 142);
            this.AcpOdrrSlipPrtDiv_tComboEditor.MaxDropDownItems = 18;
            this.AcpOdrrSlipPrtDiv_tComboEditor.Name = "AcpOdrrSlipPrtDiv_tComboEditor";
            this.AcpOdrrSlipPrtDiv_tComboEditor.Size = new System.Drawing.Size(434, 24);
            this.AcpOdrrSlipPrtDiv_tComboEditor.TabIndex = 5;
            // 
            // FaxOrderDiv_Title
            // 
            this.FaxOrderDiv_Title.Location = new System.Drawing.Point(12, 175);
            this.FaxOrderDiv_Title.Name = "FaxOrderDiv_Title";
            this.FaxOrderDiv_Title.Size = new System.Drawing.Size(162, 14);
            this.FaxOrderDiv_Title.TabIndex = 37;
            this.FaxOrderDiv_Title.Text = "�e�`�w�����敪";
            // 
            // FaxOrderDiv_tComboEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FaxOrderDiv_tComboEditor.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.FaxOrderDiv_tComboEditor.Appearance = appearance8;
            this.FaxOrderDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.FaxOrderDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FaxOrderDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FaxOrderDiv_tComboEditor.ItemAppearance = appearance9;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "���Ȃ�";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "����";
            this.FaxOrderDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.FaxOrderDiv_tComboEditor.Location = new System.Drawing.Point(180, 172);
            this.FaxOrderDiv_tComboEditor.MaxDropDownItems = 18;
            this.FaxOrderDiv_tComboEditor.Name = "FaxOrderDiv_tComboEditor";
            this.FaxOrderDiv_tComboEditor.Size = new System.Drawing.Size(434, 24);
            this.FaxOrderDiv_tComboEditor.TabIndex = 7;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(114, 216);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 9;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(239, 216);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 10;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // SectionNm_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SectionNm_Label.Appearance = appearance30;
            this.SectionNm_Label.Location = new System.Drawing.Point(301, 50);
            this.SectionNm_Label.Name = "SectionNm_Label";
            this.SectionNm_Label.Size = new System.Drawing.Size(210, 23);
            this.SectionNm_Label.TabIndex = 68;
            this.SectionNm_Label.Text = "���[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance78;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance79;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(114, 50);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero2.Leave += new System.EventHandler(this.tEdit_SectionCode_Leave);
            // 
            // SectionNm_tEdit
            // 
            this.SectionNm_tEdit.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance65;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionNm_tEdit.Location = new System.Drawing.Point(180, 50);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.ReadOnly = true;
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 2;
            // 
            // SectionGd_ultraButton
            // 
            this.SectionGd_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGd_ultraButton.Location = new System.Drawing.Point(149, 50);
            this.SectionGd_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGd_ultraButton.Name = "SectionGd_ultraButton";
            this.SectionGd_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGd_ultraButton.TabIndex = 1;
            this.SectionGd_ultraButton.Click += new System.EventHandler(this.SectionGd_ultraButton_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance2;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(12, 51);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SectionCode_Title_Label.TabIndex = 64;
            this.SectionCode_Title_Label.Text = "���_";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(12, 93);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(603, 3);
            this.ultraLabel17.TabIndex = 69;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // DCKHN09230UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(630, 291);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.SectionNm_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionGd_ultraButton);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.FaxOrderDiv_Title);
            this.Controls.Add(this.FaxOrderDiv_tComboEditor);
            this.Controls.Add(this.AcpOdrrSlipPrtDiv_Title);
            this.Controls.Add(this.AcpOdrrSlipPrtDiv_tComboEditor);
            this.Controls.Add(this.EstmCountReflectDiv_Title);
            this.Controls.Add(this.EstmCountReflectDiv_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCKHN09230UA";
            this.Text = "�󔭒��Ǘ��S�̐ݒ�";
            this.Load += new System.EventHandler(this.DCKHN09230UA_Load);
            this.VisibleChanged += new System.EventHandler(this.DCKHN09230UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DCKHN09230UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.EstmCountReflectDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrrSlipPrtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxOrderDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>
		/// ��ʔ�\���C�x���g
		/// </summary>
		/// <remarks>
		/// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
		/// </remarks>
		//public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;  // DEL 2008/06/06

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ������ɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region Private Members
        /* --- DEL 2008/06/06 -------------------------------->>>>>
		private AcptAnOdrTtlSt acptAnOdrTtlSt;
		private AcptAnOdrTtlStAcs acptAnOdrTtlStAcs;
		private string _enterpriseCode;
           --- DEL 2008/06/06 --------------------------------<<<<< */

        private AcptAnOdrTtlStAcs _acptAnOdrTtlStAcs;	// �󔭒��Ǘ��S�̐ݒ�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs;                 // ���_�}�X�^�A�N�Z�X�N���X
        private string _enterpriseCode;					// ��ƃR�[�h
        private int _logicalDeleteMode;					// ���[�h
        private Hashtable _acptAnOdrTtlStTable;			// �󔭒��Ǘ��S�̐ݒ�e�[�u��

		//��r�pclone
		private AcptAnOdrTtlSt _acptAnOdrTtlStClone;

		// �v���p�e�B�p
		/// <summary>
		/// �I���v���p�e�B
		/// </summary>
		/// <remarks>
		/// �A�Z���u�����I�����邩�A���Ȃ������擾���̓Z�b�g���܂��B
		/// </remarks>

        // --- ADD 2008/06/06 -------------------------------->>>>>
        // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        // �v���p�e�B�p
        private bool _canClose;
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canPrint;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        private bool isError = false; // ADD 2011/09/07

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        private const string GUID_TITLE = "GUID";
        private const string ACPTANODRTTLST_TABLE = "ACPTANODRTTLST"; // �e�[�u����

        // Frame��View�pGrid���KEY���i�w�b�_�̃^�C�g�����ƂȂ�܂��B�j
        private const string DELETE_DATE = "�폜��";
        private const string SECTIONCODE_TITLE = "�R�[�h";
        // DEL 2008/10/09 �s��Ή�[6469] ��
        //private const string SECTIONNAME_TITLE = "���_����";
        private const string SECTIONNAME_TITLE = "���_��";    // ADD 2008/10/09 �s��Ή�[6469]
        private const string ESTMCOUNTREFLECTDIV_TITLE = "���ϐ����f�敪";
        private const string ACPODRRSLIPPRTDIV_TITLE = "�󒍓`�[���s�敪";
        private const string FAXORDERDIV_TITLE = "�e�`�w�����敪";

        // ���ϐ����f�敪
        // ---DEL 2009/06/19 �s��Ή�[13578] -------------------------->>>>>
        //// 2009.03.18 30413 ���� �o�א���ݏo���ɕύX >>>>>>START
        ////private const string ESTMCOUNTREFLECTDIV_FORWARD = "�o�א�";
        //private const string ESTMCOUNTREFLECTDIV_FORWARD = "�ݏo��";
        //// 2009.03.18 30413 ���� �o�א���ݏo���ɕύX <<<<<<END
        // ---DEL 2009/06/19 �s��Ή�[13578] --------------------------<<<<<
        private const string ESTMCOUNTREFLECTDIV_FORWARD = "�o�א�";        //ADD 2009/06/19 �s��Ή�[13578]
        private const string ESTMCOUNTREFLECTDIV_RECEIVE = "�󒍐�";

        // �󒍓`�[���s�敪
        private const string ACPODRRSLIPPRTDIV_NO = "���Ȃ�";
        private const string ACPODRRSLIPPRTDIV_YES = "����";

        // �e�`�w�����敪
        private const string FAXORDERDIV_NO = "���Ȃ�";
        private const string FAXORDERDIV_YES = "����";

        // ���ݒ莞�Ɏg�p
        private const string UNREGISTER = "";
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        /* --- DEL 2008/06/06 -------------------------------->>>>>
        private const string HTML_HEADER_TITLE = "�ݒ荀��";
        private const string HTML_HEADER_VALUE = "�ݒ�l";
        private const string HTML_UNREGISTER = "���ݒ�";
        private const string HTML_ILLEGALVALUE = "�Y������";
           --- DEL 2008/06/06 --------------------------------<<<<< */
        
        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // ADD 2008/09/16 �s��Ή�[5308] ---------->>>>>
        /// <summary>���_�K�C�h�̐���I�u�W�F�N�g</summary>
        private readonly GeneralGuideUIController _sectionGuideController;
        /// <summary>
        /// ���_�K�C�h�̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���_�K�C�h�̐���I�u�W�F�N�g</value>
        private GeneralGuideUIController SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        // ADD 2008/09/16 �s��Ή�[5308] ----------<<<<<

#endregion

        # region Main
/// <summary>
/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
/// </summary>
[STAThread]
static void Main() 
{
    System.Windows.Forms.Application.Run(new DCKHN09230UA());
}
# endregion

        # region Properties
// --- ADD 2008/06/06 -------------------------------->>>>>
/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
public bool CanLogicalDeleteDataExtraction
{
    get
    {
        return this._canLogicalDeleteDataExtraction;
    }
}

/// <summary>�V�K�쐬�\�ݒ�v���p�e�B</summary>
/// <value>�V�K�쐬���\���ǂ����̐ݒ���擾���܂��B</value>
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

/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
/// <value>�����w�蒊�o���\���ǂ����̐ݒ���擾���܂��B</value>
public bool CanSpecificationSearch
{
    get
    {
        return this._canSpecificationSearch;
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
// --- ADD 2008/06/06 --------------------------------<<<<< 

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

        # region Public Methods
/// <summary>
///	�������
/// </summary>
/// <returns>�X�e�[�^�X</returns>
/// <remarks>
/// <br>Note			:	�i�������j</br>
/// <br>Programmer		:	���F �]</br>
/// <br>Date			:	2007.12.14</br>
/// </remarks>
public int Print()
{
    // ����p�A�Z���u�������[�h����i�������j
    return 0;
}

/* --- DEL 2008/06/06 -------------------------------->>>>>
/// <summary>
///	HTML�R�[�h�擾����
/// </summary>
/// <returns>HTML�R�[�h</returns>
/// <remarks>
/// <br>Note		: �r���[�p�̂g�s�l�k�R�[�h���擾���܂��B</br>
/// <br>Programmer	: ���F �]</br>
/// <br>Date		: 2007.12.14</br>
/// <br>Update Note : 2007.12.21 96012 ���F �]</br>
/// <br> 			  HTML�̎󔭒��v�㎞����敪�̍��ږ��ԈႢ�C��</br>
/// </remarks>
public string GetHtmlCode()
{
    string outCode = "";
    // tHtmlGenerate���i�̈����𐶐�����
    string[,] array = new string[9, 2];
    this.tHtmlGenerate1.Coltypes = new int[2];
    this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
    this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
    array[0, 0] = HTML_HEADER_TITLE; //�u�ݒ荀�ځv
    array[0, 1] = HTML_HEADER_VALUE; //�u�ݒ�l�v
    array[1, 0] = this.OrderNumberCompo_Title.Text;		// �����ԍ��\��
    array[3, 0] = this.EstmCountReflectDiv_Title.Text;  // ���ϐ����f�敪
    array[4, 0] = this.AcpOdrrSlipPrtDiv_Title.Text;    // �󒍓`�[���s�敪
    array[6, 0] = this.FaxOrderDiv_Title.Text;          // �e�`�w�����敪
    array[7, 0] = this.DotKulOrderDiv_Title.Text;       // �h�b�g�N�������敪
    int status = this.acptAnOdrTtlStAcs.Read(out this.acptAnOdrTtlSt, this._enterpriseCode);
    if (status == 0)
    {
        array[1, 1] = HTML_ILLEGALVALUE;
        array[2, 1] = HTML_ILLEGALVALUE;
        array[3, 1] = HTML_ILLEGALVALUE;
        array[4, 1] = HTML_ILLEGALVALUE;
        array[5, 1] = HTML_ILLEGALVALUE;
        array[6, 1] = HTML_ILLEGALVALUE;
        array[7, 1] = HTML_ILLEGALVALUE;
        array[8, 1] = HTML_ILLEGALVALUE;
        for (int iPos = 0; iPos < OrderNumberCompo_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.OrderNumberCompo.CompareTo(OrderNumberCompo_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[1, 1] = OrderNumberCompo_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
        for (int iPos = 0; iPos < EstmCountReflectDiv_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.EstmCountReflectDiv.CompareTo(EstmCountReflectDiv_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[3, 1] = EstmCountReflectDiv_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
        for (int iPos = 0; iPos < AcpOdrrSlipPrtDiv_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.AcpOdrrSlipPrtDiv.CompareTo(AcpOdrrSlipPrtDiv_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[4, 1] = AcpOdrrSlipPrtDiv_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
       for (int iPos = 0; iPos < FaxOrderDiv_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.FaxOrderDiv.CompareTo(FaxOrderDiv_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[6, 1] = FaxOrderDiv_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
        for (int iPos = 0; iPos < DotKulOrderDiv_tComboEditor.Items.Count; ++iPos)
        {
            if (acptAnOdrTtlSt.DotKulOrderDiv.CompareTo(DotKulOrderDiv_tComboEditor.Items[iPos].DataValue) == 0)
            {
                array[7, 1] = DotKulOrderDiv_tComboEditor.Items[iPos].DisplayText;
                break;
            }
        }
    }
    else
    {
        array[1, 1] = HTML_UNREGISTER;
        array[2, 1] = HTML_UNREGISTER;
        array[3, 1] = HTML_UNREGISTER;
        array[4, 1] = HTML_UNREGISTER;
        array[5, 1] = HTML_UNREGISTER;
        array[6, 1] = HTML_UNREGISTER;
        array[7, 1] = HTML_UNREGISTER;
        array[8, 1] = HTML_UNREGISTER;
    }
    this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);
    return outCode;
}
   --- DEL 2008/06/06 --------------------------------<<<<< */

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u����</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = ACPTANODRTTLST_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCnt">�S�Y������</param>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchAcptAnOdrTtlSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�茏�����̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // ������
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

        /// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̊e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE,
                new GridColAppearance(MGridColDispType.DeletionDataBoth,
                ContentAlignment.MiddleLeft, "", Color.Red));

            // ���_�R�[�h
            appearanceTable.Add(SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ���_����
            appearanceTable.Add(SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));


            // ���ϐ����f�敪
            appearanceTable.Add(ESTMCOUNTREFLECTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // �󒍓`�[���s�敪
            appearanceTable.Add(ACPODRRSLIPPRTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // �e�`�w�����敪
            appearanceTable.Add(FAXORDERDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        # endregion

		# region private Methods
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable acptAnOdrTtlStTable = new DataTable(ACPTANODRTTLST_TABLE);
            acptAnOdrTtlStTable.Columns.Add(DELETE_DATE, typeof(string));

            acptAnOdrTtlStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            acptAnOdrTtlStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));

            acptAnOdrTtlStTable.Columns.Add(ESTMCOUNTREFLECTDIV_TITLE , typeof(string));
            acptAnOdrTtlStTable.Columns.Add(ACPODRRSLIPPRTDIV_TITLE  , typeof(string));
            acptAnOdrTtlStTable.Columns.Add(FAXORDERDIV_TITLE, typeof(string));

            acptAnOdrTtlStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(acptAnOdrTtlStTable);
        }

		/// <summary>
		///	��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // �{�^���z�u
            int CANCELBUTTONLOCATION_X = this.Cancel_Button.Location.X;
            int OKBUTTONLOCATION_X = this.Ok_Button.Location.X;
            int DELETEBUTTONLOCATION_X = this.Revive_Button.Location.X;
            int BUTTONLOCATION_Y = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Ok_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Revive_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Delete_Button.Location = new System.Drawing.Point(DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y);

           // ���ϐ����f�敪
            this.EstmCountReflectDiv_tComboEditor.Items.Clear();
            this.EstmCountReflectDiv_tComboEditor.Items.Add(0, ESTMCOUNTREFLECTDIV_FORWARD);
            this.EstmCountReflectDiv_tComboEditor.Items.Add(1, ESTMCOUNTREFLECTDIV_RECEIVE);
            this.EstmCountReflectDiv_tComboEditor.MaxDropDownItems = this.EstmCountReflectDiv_tComboEditor.Items.Count;

            // �󒍓`�[���s�敪
            this.AcpOdrrSlipPrtDiv_tComboEditor.Items.Clear();
            this.AcpOdrrSlipPrtDiv_tComboEditor.Items.Add(0, ACPODRRSLIPPRTDIV_NO);
            this.AcpOdrrSlipPrtDiv_tComboEditor.Items.Add(1, ACPODRRSLIPPRTDIV_YES);
            this.AcpOdrrSlipPrtDiv_tComboEditor.MaxDropDownItems = this.AcpOdrrSlipPrtDiv_tComboEditor.Items.Count;

            // �e�`�w�����敪
            this.FaxOrderDiv_tComboEditor.Items.Clear();
            this.FaxOrderDiv_tComboEditor.Items.Add(0, FAXORDERDIV_NO);
            this.FaxOrderDiv_tComboEditor.Items.Add(1, FAXORDERDIV_YES);
            this.FaxOrderDiv_tComboEditor.MaxDropDownItems = this.FaxOrderDiv_tComboEditor.Items.Count;

		}

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCnt">�S�Y������</param>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int SearchAcptAnOdrTtlSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList acptAnOdrTtlSts = null;

            // ���o�Ώی�����0���̏ꍇ�͑S�����o�����s����
            status = this._acptAnOdrTtlStAcs.SearchAll(out acptAnOdrTtlSts, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in acptAnOdrTtlSts)
                        {
                            if (this._acptAnOdrTtlStTable.ContainsKey(acptAnOdrTtlSt.FileHeaderGuid) == false)
                            {
                                AcptAnOdrTtlStToDataSet(acptAnOdrTtlSt.Clone(), index);
                                index++;
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
                        // �T�[�`
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���Ϗ����l�ݒ�", 					// �v���O��������
                            "SearchAcptAnOdrTtlSt", 			// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._acptAnOdrTtlStAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }

            totalCnt = acptAnOdrTtlSts.Count;

            return status;
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g�_���폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            AcptAnOdrTtlSt acptAnOdrTtlSt = ((AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid]).Clone();

            // �󔭒��Ǘ��S�̐ݒ肪���݂��Ă��Ȃ�
            if (acptAnOdrTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/16 �s��Ή�[5286] ---------->>>>>
            // ���_�R�[�h���S�Ћ��ʂ̏ꍇ�A�폜�s��
            if (IsAllSection(acptAnOdrTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // �G���[���x��
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text, 				                                // �v���O��������
                    MethodBase.GetCurrentMethod().Name,                     // ��������
                    TMsgDisp.OPE_HIDE, 				                        // TODO:�I�y���[�V����
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // �\�����郁�b�Z�[�W
                    status, 						                        // �X�e�[�^�X�l
                    this,			                                        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 			                        // �\������{�^��
                    MessageBoxDefaultButton.Button1                         // �����\���{�^��
                );
                return status;
            }
            // ADD 2008/09/16 �s��Ή�[5286] ----------<<<<<

            status = this._acptAnOdrTtlStAcs.LogicalDelete(ref acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        AcptAnOdrTtlStToDataSet(acptAnOdrTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                // �r������
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
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���Ϗ����l�ݒ�", 					// �v���O��������
                            "LogicalDelete", 					// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._acptAnOdrTtlStAcs,			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        return status;
                    }
            }
            return status;
        }

        // ADD 2008/09/16 �s��Ή�[5286] ---------->>>>>
        /// <summary>
        /// �S�Аݒ肩���肵�܂��B
        /// </summary>
        /// <param name="acptAnOdrTtlSt">�󔭒��Ǘ��S�̐ݒ�</param>
        /// <returns><c>true</c> :�S�Аݒ�ł���B<br/><c>false</c>:�S�Аݒ�ł͂Ȃ��B</returns>
        /// <remarks>
        /// <br>Note       : �s��Ή�[5286]�ɂĒǉ�</br>
        /// <br>Programmer : 30434 �H�� �b�D</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private static bool IsAllSection(AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            return SectionUtil.IsAllSection(acptAnOdrTtlSt.SectionCode);
        }
        // ADD 2008/09/16 �s��Ή�[5286] ----------<<<<<

		/// <summary>
		///	��ʏ��|�󔭒��Ǘ��S�̐ݒ�N���X�i�[����
		/// </summary>
		/// <remarks>
		/// <br>Note			:	��ʏ�񂩂�󔭒��Ǘ��S�̐ݒ�N���X�Ƀf�[�^��
		///							�i�[���܂��B</br>
		/// <br>Programmer		:	���F �]</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void ScreenToAcptAnOdrTtlSt(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
		{
			if (acptAnOdrTtlSt == null)
			{
				// �V�K�̏ꍇ
				acptAnOdrTtlSt = new AcptAnOdrTtlSt();
			}
			//�w�b�_��
			acptAnOdrTtlSt.EnterpriseCode = this._enterpriseCode;
			//���ו�(�͈͊O��-1��ݒ�)
            //this.acptAnOdrTtlSt.OrderNumberCompo = (this.OrderNumberCompo_tComboEditor.Value == null) ? -1 : (Int32)this.OrderNumberCompo_tComboEditor.Value;  // DEL 2008/06/06
            acptAnOdrTtlSt.EstmCountReflectDiv = (this.EstmCountReflectDiv_tComboEditor.Value == null) ? -1 : (Int32)this.EstmCountReflectDiv_tComboEditor.Value;
            acptAnOdrTtlSt.AcpOdrrSlipPrtDiv = (this.AcpOdrrSlipPrtDiv_tComboEditor.Value == null) ? -1 : (Int32)this.AcpOdrrSlipPrtDiv_tComboEditor.Value;
            acptAnOdrTtlSt.FaxOrderDiv = (this.FaxOrderDiv_tComboEditor.Value == null) ? -1 : (Int32)this.FaxOrderDiv_tComboEditor.Value;
            //acptAnOdrTtlSt.DotKulOrderDiv = (this.DotKulOrderDiv_tComboEditor.Value == null) ? -1 : (Int32)this.DotKulOrderDiv_tComboEditor.Value;  // DEL 2008/06/06

            acptAnOdrTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText;  // ADD 2008/06/06
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g�W�J����
		/// </summary>
        /// <param name="estimateDefSet">�󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�N���X��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void AcptAnOdrTtlStToDataSet(AcptAnOdrTtlSt acptAnOdrTtlSt, int index)
        {
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count))
            {
                // �V�K�Ɣ��f���A�s��ǉ�����B
                DataRow dataRow = this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Add(dataRow);

                // index���ŏI�s�ԍ��ɂ���
                index = this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count - 1;
            }

            // �폜��
            if (acptAnOdrTtlSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][DELETE_DATE] = acptAnOdrTtlSt.UpdateDateTime;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][SECTIONCODE_TITLE] = acptAnOdrTtlSt.SectionCode;
            // ���_����
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == acptAnOdrTtlSt.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }
            // --- ADD 2008/11/06 ----------------------------------------------------------------------------->>>>>
            // ���_"00"���A"�S�Ћ���"��\��
            if ((string.IsNullOrEmpty(acptAnOdrTtlSt.SectionCode) == false) && (acptAnOdrTtlSt.SectionCode.Trim() == "00"))
            {
                this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][SECTIONNAME_TITLE] = "�S�Ћ���";
            }
            // --- ADD 2008/11/06 -----------------------------------------------------------------------------<<<<<

            // ���ϐ����f�敪
            switch (acptAnOdrTtlSt.EstmCountReflectDiv)
            {
                case 0:
                    wrkstr = ESTMCOUNTREFLECTDIV_FORWARD;          // �o�א�
                    break;
                case 1:
                    wrkstr = ESTMCOUNTREFLECTDIV_RECEIVE;          // �󒍐�
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][ESTMCOUNTREFLECTDIV_TITLE ] = wrkstr;

            // �󒍓`�[���s�敪
            switch (acptAnOdrTtlSt.AcpOdrrSlipPrtDiv)
            {
                case 0:
                    wrkstr = ACPODRRSLIPPRTDIV_NO;          // ���Ȃ�
                    break;
                case 1:
                    wrkstr = ACPODRRSLIPPRTDIV_YES;         // ����
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][ACPODRRSLIPPRTDIV_TITLE] = wrkstr;
 
    
            // �e�`�w�����敪
            switch (acptAnOdrTtlSt.FaxOrderDiv)
            {
                case 0:
                    wrkstr = FAXORDERDIV_NO;         // ���Ȃ�
                    break;
                case 1:
                    wrkstr = FAXORDERDIV_YES;        // ����
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][FAXORDERDIV_TITLE] = wrkstr;
     

            // GUID
            this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[index][GUID_TITLE] = acptAnOdrTtlSt.FileHeaderGuid;

            if (this._acptAnOdrTtlStTable.ContainsKey(acptAnOdrTtlSt.FileHeaderGuid) == true)
            {
                this._acptAnOdrTtlStTable.Remove(acptAnOdrTtlSt.FileHeaderGuid);
            }
            this._acptAnOdrTtlStTable.Add(acptAnOdrTtlSt.FileHeaderGuid, acptAnOdrTtlSt);
        }

		/// <summary>
		///	��ʏ��|�󔭒��Ǘ��S�̐ݒ�N���X�i�[����(�ۑ��m�F���b�Z�[�W�p)
		/// </summary>
		/// <param name="acptAnOdrTtlSt">�󔭒��Ǘ��S�̐ݒ�N���X</param>
		/// <remarks>
		/// <br>Note			:	��ʏ�񂩂�󔭒��Ǘ��S�̐ݒ�N���X�Ƀf�[�^��
		///							�i�[���܂��B</br>
		/// <br>Programmer		:	���F �]</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void DispToAcptAnOdrTtlSt(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            if (acptAnOdrTtlSt == null)
            {
                // �V�K�̏ꍇ
                acptAnOdrTtlSt = new AcptAnOdrTtlSt();
            }

            //�w�b�_��
            acptAnOdrTtlSt.EnterpriseCode = this._enterpriseCode;

            //���ו�(�͈͊O��-1��ݒ�)
            //acptAnOdrTtlSt.OrderNumberCompo = (this.OrderNumberCompo_tComboEditor.Value == null) ? -1 : (Int32)this.OrderNumberCompo_tComboEditor.Value;   // DEL 2008/06/06

            // ���ϐ����f�敪
            acptAnOdrTtlSt.EstmCountReflectDiv = (this.EstmCountReflectDiv_tComboEditor.Value == null) ? -1 : (Int32)this.EstmCountReflectDiv_tComboEditor.Value;
            
            // �󒍓`�[���s�敪
            acptAnOdrTtlSt.AcpOdrrSlipPrtDiv = (this.AcpOdrrSlipPrtDiv_tComboEditor.Value == null) ? -1 : (Int32)this.AcpOdrrSlipPrtDiv_tComboEditor.Value;
            
            // FAX���s�敪
            acptAnOdrTtlSt.FaxOrderDiv = (this.FaxOrderDiv_tComboEditor.Value == null) ? -1 : (Int32)this.FaxOrderDiv_tComboEditor.Value;
            
            //acptAnOdrTtlSt.DotKulOrderDiv = (this.DotKulOrderDiv_tComboEditor.Value == null) ? -1 : (Int32)this.DotKulOrderDiv_tComboEditor.Value;  // DEL 2008/06/06

            // ���_�R�[�h
            acptAnOdrTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd();  // ADD 2008/06/06
            // ADD 2008/09/17 �s��Ή�[5310] ---------->>>>>
            // uiSetControl��""�̂Ƃ�"00"��ݒ肷��̂ŁA�f�t�H���g�l��"00"�Ƃ���
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                acptAnOdrTtlSt.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/17 �s��Ή�[5310] ----------<<<<<
        }

        /// <summary>
		///	��ʓW�J����
		/// </summary>
		/// <remarks>
		/// <br>Note			:	�󔭒��Ǘ��S�̐ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer		:	���F �]</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void AcptAnOdrTtlStToScreen(AcptAnOdrTtlSt acptAnOdrTtlSt)
		{
            //this.OrderNumberCompo_tComboEditor.Value = acptAnOdrTtlSt.OrderNumberCompo;     // DEL 2008/06/06
            this.EstmCountReflectDiv_tComboEditor.Value = acptAnOdrTtlSt.EstmCountReflectDiv;
            this.AcpOdrrSlipPrtDiv_tComboEditor.Value = acptAnOdrTtlSt.AcpOdrrSlipPrtDiv;
            this.FaxOrderDiv_tComboEditor.Value = acptAnOdrTtlSt.FaxOrderDiv;
            //this.DotKulOrderDiv_tComboEditor.Value = acptAnOdrTtlSt.DotKulOrderDiv;         // DEL 2008/06/06

            this.tEdit_SectionCodeAllowZero2.Value = acptAnOdrTtlSt.SectionCode.TrimEnd();                // ADD 2008/06/06
            // ���_����
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == acptAnOdrTtlSt.SectionCode.TrimEnd())
                {
                    this.SectionNm_tEdit.Value = si.SectionGuideNm;
                    break;
                }
            }

            // --- ADD 2008/11/06 ----------------------------------->>>>>
            // �R�[�h��00�Ŗ��̎擾�ł��Ă��Ȃ��ꍇ�A"�S�Ћ���"���Z�b�g
            if ((this.tEdit_SectionCodeAllowZero2.Text == "00") &&
                (string.IsNullOrEmpty(this.SectionNm_tEdit.Text) == true))
            {
                this.SectionNm_tEdit.Value = "�S�Ћ���";
            }
            // --- ADD 2008/11/06 -----------------------------------<<<<<
        }

		/// <summary>
		///	�󔭒��Ǘ��S�̐ݒ��ʓW�J����
		/// </summary>
		/// <remarks>
		/// <br>Note			:	�󔭒��Ǘ��S�̐ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer		:	���F �]</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
		private void ScreenClear()
		{
            //this.OrderNumberCompo_tComboEditor.Clear();   // DEL 2008/06/06
            this.EstmCountReflectDiv_tComboEditor.Clear();
            this.AcpOdrrSlipPrtDiv_tComboEditor.Clear();
            this.FaxOrderDiv_tComboEditor.Clear();
            //this.DotKulOrderDiv_tComboEditor.Clear();     // DEL 2008/06/06

            // --- ADD 2008/06/06 -------------------------------->>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();            // ���_�R�[�h
            this.SectionNm_tEdit.Clear();            // ���_�K�C�h����
            // --- ADD 2008/06/06 --------------------------------<<<<< 
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
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
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
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
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[���N���[�Y�����j
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
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

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
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
		///			��ʃ`�F�b�N����
		/// </summary>
		/// <param name="control">�R���g���[��</param>
		/// <param name="checkMessage">���b�Z�[�W</param>
		/// <returns>true:����@false:�ُ�</returns>
		/// <remarks>
		/// <br>Note		:	��ʓ��̓f�[�^�̃`�F�b�N���ʂ�ԋp���܂��B</br>
		/// <br>Programer	:	���F �]</br>
        /// <br>Date		:	2007.12.14</br>
		/// </remarks>
		private bool CheckInputData(ref Control control,ref string checkMessage)
		{
            // --- ADD 2008/06/06 -------------------------------->>>>>
            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                checkMessage = this.SectionCode_Title_Label.Text + "��ݒ肵�ĉ������B";
                control = this.tEdit_SectionCodeAllowZero2;
                return false;
            }
            // --- ADD 2008/06/06 --------------------------------<<<<< 
            //// --- ADD 2011/09/07 -------------------------------->>>>>
            //if (this.tEdit_SectionCodeAllowZero2.TextLength == 1)
            //{
            //    checkMessage = SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND;
            //    return false;
            //}
            //// --- ADD 2011/09/07 --------------------------------<<<<<
            return true;
		}
		
		/// <summary>
		/// �r������
		/// </summary>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���F �]</br>
        /// <br>Date       : 2007.12.14</br>
		/// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        this.Hide();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        this.Hide();
                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void ScreenInputPermissionControl()
        {
            switch (this._logicalDeleteMode)
            {
                case -1:
                    {
                        // �V�K���[�h
                        this.Mode_Label.Text = INSERT_MODE;

                        // �{�^���̕\��
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // �R���g���[���̕\���ݒ�
                        ScreenInputPermissionControl(true);

                        // �����t�H�[�J�X���Z�b�g
                        this.tEdit_SectionCodeAllowZero2.Focus();

                        // ���_�R�[�h�̃R�����g�\��
                        SectionNm_Label.Visible = true;

                        break;
                    }
                case 1:
                    {
                        // �폜���[�h
                        this.Mode_Label.Text = DELETE_MODE;

                        // �{�^���̕\��
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Delete_Button.Visible = true;

                        // �R���g���[���̕\���ݒ�
                        ScreenInputPermissionControl(false);

                        // �����t�H�[�J�X���Z�b�g
                        this.Delete_Button.Focus();

                        // ���_�R�[�h�̃R�����g��\��
                        SectionNm_Label.Visible = false;

                        break;
                    }
                default:
                    {
                        // �X�V���[�h
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �{�^���̕\��
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // �R���g���[���̕\���ݒ�
                        ScreenInputPermissionControl(true);

                        // ���_�֌W�̃R���g���[�����g�p�s�ɂ���
                        tEdit_SectionCodeAllowZero2.Enabled = false;
                        SectionGd_ultraButton.Enabled = false;
                        SectionNm_tEdit.Enabled = false;

                        // ���_�R�[�h�̃R�����g��\��
                        SectionNm_Label.Visible = false;


                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="enabled">���͋��ݒ�l</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled)
        {
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;                     // ���_�R�[�h
            this.SectionGd_ultraButton.Enabled = enabled;               // �K�C�h�{�^�� 
            this.SectionNm_tEdit.Enabled = enabled;                     // ���_�K�C�h����
            this.EstmCountReflectDiv_tComboEditor.Enabled = enabled;    // ���ϐ����f�敪
            this.AcpOdrrSlipPrtDiv_tComboEditor.Enabled = enabled;      // �󒍓`�[���s�敪
            this.FaxOrderDiv_tComboEditor.Enabled = enabled;            // �e�`�w�����敪

            // ������h�~�̈�
            this.Enabled = true;
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g���S�폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�u�W�F�N�g�̊��S�폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            AcptAnOdrTtlSt acptAnOdrTtlSt = (AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid];

            // �󔭒��Ǘ��S�̐ݒ肪���݂��Ă��Ȃ�
            if (acptAnOdrTtlSt == null)
            {
                return -1;
            }

            // ADD 2008/09/16 �s��Ή�[5286] ---------->>>>>
            // ���_�R�[�h���S�Аݒ�̏ꍇ�A�폜�s��
            if (IsAllSection(acptAnOdrTtlSt))
            {
                TMsgDisp.Show(
                    this, 							                        // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // �G���[���x��
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text, 				                                // �v���O��������
                    MethodBase.GetCurrentMethod().Name,                     // ��������
                    TMsgDisp.OPE_DELETE, 				                    // TODO:�I�y���[�V����
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // �\�����郁�b�Z�[�W
                    status, 						                        // �X�e�[�^�X�l
                    this,			                                        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 			                        // �\������{�^��
                    MessageBoxDefaultButton.Button1                         // �����\���{�^��
                );
                return status;
            }
            // ADD 2008/09/16 �s��Ή�[5286] ----------<<<<<

            status = this._acptAnOdrTtlStAcs.Delete(acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �n�b�V���e�[�u������f�[�^���폜
                        this._acptAnOdrTtlStTable.Remove((Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // �f�[�^�Z�b�g����f�[�^���폜
                        this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex].Delete();
                        break;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // �����폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�󔭒��Ǘ��S�̐ݒ�", 				// �v���O��������
                            "PhysicalDelete", 					// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._acptAnOdrTtlStAcs,			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        ///�@�ۑ�����(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer		:	���F �]</br>
        /// <br>Date			:	2007.12.14</br>
        /// </remarks>
        private bool SaveProc()
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            bool result = false;

            Control control = null;
            string checkMessage = "";
            bool ret = true;
            //��ʃf�[�^���̓`�F�b�N����
            ret = CheckInputData(ref control, ref checkMessage);
            if (ret == false)
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    checkMessage, 						// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                control.Focus();
                return result;
            }
            AcptAnOdrTtlSt acptAnOdrTtlSt = null;
            // ��ʂ���󔭒��Ǘ��S�̐ݒ�\���N���X�Ƀf�[�^���Z�b�g���܂��B
            //ScreenToAcptAnOdrTtlSt();
            DispToAcptAnOdrTtlSt(ref acptAnOdrTtlSt);
            // �󔭒��Ǘ��S�̐ݒ�o�^
            int status = this._acptAnOdrTtlStAcs.Write(ref acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                            "DCKHN09230U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
                            0, 										// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        tEdit_SectionCode.Focus();
                        return result;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return result;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�󔭒��Ǘ��S�̐ݒ�", 				// �v���O��������
                            "SaveAcptAnOdrTtlSt", 				// ��������
                            TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._acptAnOdrTtlStAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return result;
                    }
            }
            DialogResult dialogResult = DialogResult.OK;
            Mode_Label.Text = UPDATE_MODE;
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.Cancel;
            this._acptAnOdrTtlStClone = null;
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

            result = true;
            return result;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            // --- ADD 2008/06/06 -------------------------------->>>>>
            bool result = false;

            // ���̓`�F�b�N
            Control control = null;
            string message = null;
            if (!CheckInputData(ref control, ref message))
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                // --- DEL 2011/09/07 -------------------------------->>>>>
                //control.Focus();
                //if( control is TNedit ) {
                //    ( ( TNedit )control ).SelectAll();
                //}
                //else if( control is TEdit ) {
                //    ( ( TEdit )control ).SelectAll();
                //}
                // --- DEL 2011/09/07 --------------------------------<<<<<
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return result;
            }

            // ----- ADD 2011/09/07 ---------->>>>>
            // ���_
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            AcptAnOdrTtlSt acptAnOdrTtlSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                acptAnOdrTtlSt = ((AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid]).Clone();
            }
            DispToAcptAnOdrTtlSt(ref acptAnOdrTtlSt);

            // ADD 2008/09/16 �s��Ή�[5311] ---------->>>>>
            // ���_�R�[�h�����݂��Ă��Ȃ��ꍇ�A�o�^���Ȃ��B
            //if (!SectionUtil.ExistsCode(acptAnOdrTtlSt.SectionCode))// DEL 2011/09/07
            if (!SectionUtil.ExistsCode(acptAnOdrTtlSt.SectionCode) || acptAnOdrTtlSt.SectionCode == "0")//ADD 2011/09/07
            {
                TMsgDisp.Show(
                    this, 								                    // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // �G���[���x��
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text, 		                                        // �v���O��������
                    MethodBase.GetCurrentMethod().Name, 					// ��������
                    TMsgDisp.OPE_UPDATE, 				                    // �I�y���[�V����
                    SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND,              // �\�����郁�b�Z�[�W
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// �X�e�[�^�X�l
                    this,			                                        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				                    // �\������{�^��
                    MessageBoxDefaultButton.Button1                         // �����\���{�^��
                );
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return false;
            }
            // ADD 2008/09/16 �s��Ή�[5311] ----------<<<<<

            int status = this._acptAnOdrTtlStAcs.Write(ref acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEW�̃f�[�^�Z�b�g���X�V
                        AcptAnOdrTtlStToDataSet(acptAnOdrTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                            "DCKHN09230U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
                            0, 										// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        tEdit_SectionCodeAllowZero2.Focus();
                        return result;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�󔭒��Ǘ��S�̐ݒ�", 			    // �v���O��������
                            "SaveProc", 						// ��������
                            TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._acptAnOdrTtlStAcs,			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
            // --- ADD 2008/06/06 --------------------------------<<<<< 
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : ���F �]</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            // acptAnOdrTtlSt�N���X
            this.acptAnOdrTtlSt = new AcptAnOdrTtlSt();
            int status = acptAnOdrTtlStAcs.Read(out this.acptAnOdrTtlSt, this._enterpriseCode);
            if (status == 0 || status == 9)
            {
                if (this.acptAnOdrTtlSt != null)
                {
                    Mode_Label.Text = UPDATE_MODE;
                    // �S�̏����\���ݒ�N���X��ʓW�J����
                    acptAnOdrTtlStToScreen();
                    // �����t�H�[�J�X�Z�b�g
                    this.OrderNumberCompo_tComboEditor.Focus();
                    //�N���[���쐬
                    this._acptAnOdrTtlStClone = this.acptAnOdrTtlSt.Clone();
                    //��ʏ����r�p�N���[���ɃR�s�[����@�@�@�@�@   
                    DispToAcptAnOdrTtlSt(ref this._acptAnOdrTtlStClone);
                }
            }
            else
            {
                // �T�[�`
                TMsgDisp.Show(
                    this, 									// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOP, 			// �G���[���x��
                    "DCKHN09230U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�󔭒��Ǘ��S�̐ݒ�", 						// �v���O��������
                    "ScreenReconstruction", 				// ��������
                    TMsgDisp.OPE_READ, 						// �I�y���[�V����
                    "�󔭒��Ǘ��S�̐ݒ�̓ǂݍ��݂Ɏ��s���܂����B", // �\�����郁�b�Z�[�W
                    status, 								// �X�e�[�^�X�l
                    this.acptAnOdrTtlStAcs, 					// �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 					// �\������{�^��
                    MessageBoxDefaultButton.Button1);		// �����\���{�^��
            }
               --- DEL 2008/06/06 --------------------------------<<<<< */

            if (this._dataIndex < 0)
            {
                // �V�K���[�h
                this._logicalDeleteMode = -1;

                AcptAnOdrTtlSt newAcptAnOdrTtlSt = new AcptAnOdrTtlSt();
                // ���Ϗ����l�ݒ�I�u�W�F�N�g����ʂɓW�J
                AcptAnOdrTtlStToScreen(newAcptAnOdrTtlSt);

                // �N���[���쐬
                this._acptAnOdrTtlStClone = newAcptAnOdrTtlSt.Clone();
                DispToAcptAnOdrTtlSt(ref this._acptAnOdrTtlStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                AcptAnOdrTtlSt acptAnOdrTtlSt = (AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid];

                // ���Ϗ����l�ݒ�I�u�W�F�N�g����ʂɓW�J
                AcptAnOdrTtlStToScreen(acptAnOdrTtlSt);

                if (acptAnOdrTtlSt.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this._logicalDeleteMode = 0;

                    // �N���[���쐬
                    this._acptAnOdrTtlStClone = acptAnOdrTtlSt.Clone();
                    DispToAcptAnOdrTtlSt(ref this._acptAnOdrTtlStClone);
                }
                else
                {
                    // �폜���[�h
                    this._logicalDeleteMode = 1;
                }
            }
            // _GridIndex�o�b�t�@�ێ��i���C���t���[���ŏ����Ή��j
            this._indexBuf = this._dataIndex;

            ScreenInputPermissionControl();
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g�_���폜��������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            AcptAnOdrTtlSt acptAnOdrTtlSt = ((AcptAnOdrTtlSt)this._acptAnOdrTtlStTable[guid]).Clone();

            // �󔭒��Ǘ��S�̐ݒ肪���݂��Ă��Ȃ�
            if (acptAnOdrTtlSt == null)
            {
                return -1;
            }

            status = this._acptAnOdrTtlStAcs.Revival(ref acptAnOdrTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        AcptAnOdrTtlStToDataSet(acptAnOdrTtlSt.Clone(), this._dataIndex);
                        break;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // �������s
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�󔭒��Ǘ��S�̐ݒ�", 				// �v���O��������
                            "Revival", 							// ��������
                            TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                            "�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._acptAnOdrTtlStAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }

                // --- ADD 2008/11/06 ---------------------------------------------------------->>>>>
                if ((sectionCode == "00") && (string.IsNullOrEmpty(sectionName) == true))
                {
                    sectionName = "�S�Ћ���";
                }
                // --- ADD 2008/11/06 ----------------------------------------------------------<<<<<
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        # endregion

		# region Control Events
		/// <summary>
		///	Form.Load �C�x���g(DCKHN09230UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer		:	���F �]</br>
		/// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void DCKHN09230UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // --- ADD 2008/06/06 -------------------------------->>>>>
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	// �����{�^��
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	// ���S�폜�{�^��

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1]; // ADD 2008/06/06
            // --- ADD 2008/06/06 --------------------------------<<<<< 

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

            // ���_�K�C�h�̃t�H�[�J�X����̊J�n
            SectionGuideController.StartControl();  // ADD 2008/09/16 �s��Ή�[5308]
        }

        /// <summary>
		///	Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	�ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///							�������܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            if (!SaveProc())
            {			// �o�^
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                ScreenClear();

                // �V�K���[�h
                this._logicalDeleteMode = -1;

                AcptAnOdrTtlSt newAcptAnOdrTtlSt = new AcptAnOdrTtlSt();
                // �󔭒��Ǘ��S�̐ݒ�I�u�W�F�N�g����ʂɓW�J
                AcptAnOdrTtlStToScreen(newAcptAnOdrTtlSt);

                // �N���[���쐬
                this._acptAnOdrTtlStClone = newAcptAnOdrTtlSt.Clone();
                DispToAcptAnOdrTtlSt(ref this._acptAnOdrTtlStClone);

                // _GridIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

                ScreenInputPermissionControl();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
                this._indexBuf = -2;

                if (this._canClose == true)
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
		///	Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	����{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///							�������܂��B</br>
		/// <br>Programmer		:	���F �]</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            //�ۑ��m�F
            AcptAnOdrTtlSt compareAcptAnOdrTtlSt = new AcptAnOdrTtlSt();
            if (this.acptAnOdrTtlSt != null)
            {
                compareAcptAnOdrTtlSt = this.acptAnOdrTtlSt.Clone();
                //���݂̉�ʏ����擾����
                DispToAcptAnOdrTtlSt(ref compareAcptAnOdrTtlSt);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if ((this._acptAnOdrTtlStClone == null)
                || (!(this._acptAnOdrTtlStClone.Equals(compareAcptAnOdrTtlSt))))
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������ 
                    // �ۑ��m�F
                    DialogResult res = TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                        "DCKHN09230U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 								// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	// �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                SaveAcptAnOdrTtlSt();
                                return;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                return;
                            }
                    }
                }
            }
            DialogResult dialogResult = DialogResult.Cancel;
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.Cancel;
            this._acptAnOdrTtlStClone = null;
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
               --- DEL 2008/06/06 --------------------------------<<<<< */

            // --- ADD 2008/06/06 -------------------------------->>>>>
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ���݂̉�ʏ����擾����
                AcptAnOdrTtlSt compareAcptAnOdrTtlSt = new AcptAnOdrTtlSt();
                compareAcptAnOdrTtlSt = this._acptAnOdrTtlStClone.Clone();
                DispToAcptAnOdrTtlSt(ref compareAcptAnOdrTtlSt);

                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._acptAnOdrTtlStClone.Equals(compareAcptAnOdrTtlSt)))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    // �ۑ��m�F
                    DialogResult res = TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                        "DCKHN09230", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 								// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	    // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
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
                                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            if (this._canClose)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            // --- ADD 2008/06/06 --------------------------------<<<<< 
        }

		/// <summary>
		///	Form.Closing �C�x���g(DCKHN09230UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note			:	�t�H�[�������O�ɁA���[�U�[���t�H�[�����
		///							�悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer		:	���F �]</br>
        /// <br>Date			:	2007.12.14</br>
		/// </remarks>
		private void DCKHN09230UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//this._acptAnOdrTtlStClone = null;  // DEL 2008/06/06

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;  // ADD 2008/06/06

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
		///				��ʂu�������������b���������C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void DCKHN09230UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();
                return;
            }

            // �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ������ꍇ�ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ������h�~�̈�
            this.Enabled = false;

            Initial_Timer.Enabled = true;
            ScreenClear();
        }

		/// <summary>
		/// ���s�L�[���䏈��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero2":
                    {
                        // ���_�R�[�h
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }

		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
        }

        /// <summary>
        /// ���_�R�[�h�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�\������</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status != 0)
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/09 �s��Ή�[6226]
                    return;
                }

                // �擾�f�[�^�\��
                this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                        ((Control)sender).Focus();
                    }
                }
                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                "DCKHN09230", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel, 		// �\������{�^��
                MessageBoxDefaultButton.Button2);	// �����\���{�^��

            if (result == DialogResult.OK)
            {
                if (PhysicalDelete() != 0)
                {
                    return;
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

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

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
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            if (Revival() != 0)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

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
        /// ���_�R�[�hEdit Leave����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���_���̕\������</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        {
            // ���_�R�[�h���͂���H
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');//ADD 2011/09/07
                // ���_�R�[�h���̐ݒ�
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());
            }
            else
            {
                // ���_�R�[�h���̃N���A
                this.SectionNm_tEdit.Text = "";
            }

            // --- ADD 2008/11/06 ------------------------------------------------->>>>>
            //if ((this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0') == "00") &&//DEL 2011/09/07
            if ((this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0') == "00") && this.tEdit_SectionCodeAllowZero2.Text != "" && //ADD 2011/09/07
                (string.IsNullOrEmpty(this.SectionNm_tEdit.Text) == true))
            {
                this.SectionNm_tEdit.Value = "�S�Ћ���";
            }
 

        }

        # endregion

        // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {


            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "DCKHN09230U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            isError = false;
            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }
            this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "���͂��ꂽ�R�[�h�̎󔭒��S�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[ACPTANODRTTLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "DCKHN09230U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̎󔭒��S�̐ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        isError = true; // ADD 2011/09/07
                        // ���_�R�[�h�A���̂̃N���A
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h�̎󔭒��S�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        "DCKHN09230U",                          // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    isError = true; // ADD 2011/09/07
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
                                // ���_�R�[�h�A���̂̃N���A
                                tEdit_SectionCodeAllowZero2.Clear();
                                SectionNm_tEdit.Clear();
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
