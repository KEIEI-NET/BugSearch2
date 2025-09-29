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
using Infragistics.Win.Misc;
//using Broadleaf.Application.Remoting.ParamData;  // DEL 2008/06/04

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����ݒ���s���܂��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.08.09</br>
    /// <br>Update Note: 2008/06/04 30414 �E�@�K�j</br>
    /// <br>                        ���_�e�[�u���폜</br>
    /// <br>Update Note: 2008/09/16 30452 ���@�r��</br>
    /// <br>                        ���_���̂��A�N�Z�X�N���X�o�R�Ŏ擾����悤�C��</br>
    /// </remarks>
    public class DCKHN09010UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        # region Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer Initial_Timer;
        private Broadleaf.Library.Windows.Forms.TEdit SectionGuideNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel Button_Panel;
        private TEdit SubSectionName_tEdit;
        private UltraLabel SubsectionName_Title_Label;
        private UltraLabel SubsectionCode_Title_Label;
        private TNedit tNedit_SubSectionCode;
        private UltraButton SectionGuide_ultraButton;
        private TEdit tEdit_SectionCode;
        private UiSetControl uiSetControl1;
        private UltraButton Renewal_Button;
        private System.ComponentModel.IContainer components;

        # endregion

        # region Constructor

        /// <summary>
        /// ����ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public DCKHN09010UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint                  = false;
            this._canClose                  = false;
            this._canNew                    = true;
            this._canDelete                 = true;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainGridTitle = "���_���";
            this._detailsGridTitle          = "����";
            this._defaultGridDisplayLayout  = MGridDisplayLayout.Vertical;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            this._targetTableName = "";
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // --- DEL 2008/09/16 -------------------------------->>>>>
            //this._secInfoAcs = new SecInfoAcs(1);         // ���_(�����[�g�Ǎ�)
            // --- DEL 2008/09/16 --------------------------------<<<<< 
            this._subsectionAcs = new SubSectionAcs();       // ����

            //this._mainTable = new Hashtable();  // DEL 2008/06/04
            this._detailsTable = new Hashtable();
            this._allSearchHash = new Hashtable();

            //GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            //this._mainIndexBuf = -2;  // DEL 2008/06/04
            this._detailsIndexBuf = -2;
            //this._targetTableBuf = "";  // DEL 2008/06/04

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // �A�C�R���p�_�~�[
            this._mainGridIcon = null;
            this._detailsGridIcon = null;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        # endregion

        # region Dispose

        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09010UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionGuideNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.SubsectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SubsectionName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SubSectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SubSectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubSectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 183);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(664, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(146, 10);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 8;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(273, 10);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 9;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(400, 10);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 10;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(527, 10);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 11;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance13;
            this.SectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(12, 85);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.SectionCode_Title_Label.TabIndex = 4;
            this.SectionCode_Title_Label.Text = "���_";
            // 
            // Mode_Label
            // 
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance11;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(559, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 23;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // SectionGuideNm_tEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.SectionGuideNm_tEdit.ActiveAppearance = appearance9;
            appearance10.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.SectionGuideNm_tEdit.Appearance = appearance10;
            this.SectionGuideNm_tEdit.AutoSelect = true;
            this.SectionGuideNm_tEdit.DataText = "";
            this.SectionGuideNm_tEdit.Enabled = false;
            this.SectionGuideNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionGuideNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionGuideNm_tEdit.Location = new System.Drawing.Point(190, 85);
            this.SectionGuideNm_tEdit.MaxLength = 6;
            this.SectionGuideNm_tEdit.Name = "SectionGuideNm_tEdit";
            this.SectionGuideNm_tEdit.ReadOnly = true;
            this.SectionGuideNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.SectionGuideNm_tEdit.TabIndex = 6;
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
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SectionGuide_ultraButton
            // 
            this.SectionGuide_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGuide_ultraButton.Location = new System.Drawing.Point(312, 85);
            this.SectionGuide_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGuide_ultraButton.Name = "SectionGuide_ultraButton";
            this.SectionGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_ultraButton.TabIndex = 7;
            ultraToolTipInfo1.ToolTipText = "���_�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_ultraButton, ultraToolTipInfo1);
            this.SectionGuide_ultraButton.Click += new System.EventHandler(this.SectionGuide_ultraButton_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(0, 129);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(664, 54);
            this.Button_Panel.TabIndex = 168;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(273, 10);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 9;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SubsectionCode_Title_Label
            // 
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.SubsectionCode_Title_Label.Appearance = appearance8;
            this.SubsectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SubsectionCode_Title_Label.Location = new System.Drawing.Point(12, 25);
            this.SubsectionCode_Title_Label.Name = "SubsectionCode_Title_Label";
            this.SubsectionCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.SubsectionCode_Title_Label.TabIndex = 0;
            this.SubsectionCode_Title_Label.Text = "����R�[�h";
            // 
            // SubsectionName_Title_Label
            // 
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.SubsectionName_Title_Label.Appearance = appearance7;
            this.SubsectionName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SubsectionName_Title_Label.Location = new System.Drawing.Point(12, 55);
            this.SubsectionName_Title_Label.Name = "SubsectionName_Title_Label";
            this.SubsectionName_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.SubsectionName_Title_Label.TabIndex = 2;
            this.SubsectionName_Title_Label.Text = "���喼";
            // 
            // SubSectionName_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SubSectionName_tEdit.ActiveAppearance = appearance12;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.SubSectionName_tEdit.Appearance = appearance14;
            this.SubSectionName_tEdit.AutoSelect = true;
            this.SubSectionName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SubSectionName_tEdit.DataText = "";
            this.SubSectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SubSectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SubSectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SubSectionName_tEdit.Location = new System.Drawing.Point(148, 55);
            this.SubSectionName_tEdit.MaxLength = 20;
            this.SubSectionName_tEdit.Name = "SubSectionName_tEdit";
            this.SubSectionName_tEdit.Size = new System.Drawing.Size(314, 24);
            this.SubSectionName_tEdit.TabIndex = 3;
            // 
            // tNedit_SubSectionCode
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.tNedit_SubSectionCode.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.tNedit_SubSectionCode.Appearance = appearance2;
            this.tNedit_SubSectionCode.AutoSelect = true;
            this.tNedit_SubSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SubSectionCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SubSectionCode.DataText = "";
            this.tNedit_SubSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SubSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SubSectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SubSectionCode.Location = new System.Drawing.Point(148, 25);
            this.tNedit_SubSectionCode.MaxLength = 2;
            this.tNedit_SubSectionCode.Name = "tNedit_SubSectionCode";
            this.tNedit_SubSectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SubSectionCode.Size = new System.Drawing.Size(35, 24);
            this.tNedit_SubSectionCode.TabIndex = 1;
            // 
            // tEdit_SectionCode
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCode.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.Appearance = appearance6;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCode.Location = new System.Drawing.Point(148, 85);
            this.tEdit_SectionCode.MaxLength = 2;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 5;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // DCKHN09010UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(664, 206);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.SectionGuide_ultraButton);
            this.Controls.Add(this.tNedit_SubSectionCode);
            this.Controls.Add(this.SubSectionName_tEdit);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.SubsectionName_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SubsectionCode_Title_Label);
            this.Controls.Add(this.SectionGuideNm_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCKHN09010UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "����ݒ�";
            this.Load += new System.EventHandler(this.MAKHN09230UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKHN09230UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKHN09230UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubSectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        #region IMasterMaintenanceMultiType �����o

        # region ��Properties
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
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
        # endregion ��Properties

        # region ��Public Methods
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SUBSECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(SUBSECTIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = DETAILS_TABLE;
        }
        # endregion ��Public Methods

        # region ��Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #endregion
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        #region Private Menbers

        // --- DEL 2008/09/16 -------------------------------->>>>>
        // private SecInfoAcs   _secInfoAcs;       // ���_�p�A�N�Z�X�N���X
        // --- DEL 2008/09/16 --------------------------------<<<<< 
        private SubSectionAcs _subsectionAcs;     // ����p�A�N�Z�X�N���X

        private string _enterpriseCode;         // ��ƃR�[�h
        //private Hashtable _mainTable;           // ���_�p�n�b�V���e�[�u��  // DEL 2008/06/04
        private Hashtable _detailsTable;        // ����p�n�b�V���e�[�u��
        private Hashtable _allSearchHash;       // �S���R�[�h�m�ۗp

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private string _mainGridTitle;
        private string _detailsGridTitle;
        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailsDataIndex;
        private Image _mainGridIcon;
        private Image _detailsGridIcon;
        private MGridDisplayLayout _defaultGridDisplayLayout;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            
        //_GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        //private int _mainIndexBuf;  // DEL 2008/06/04
        private int _detailsIndexBuf;
        //private string _targetTableBuf;  // DEL 2008/06/04

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �I�����̕ҏW�`�F�b�N�p
        private SubSection _SubsectionClone;

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE      = "�폜��";
        private const string SECTIONCODE_TITLE      = "���_�R�[�h";
        private const string SECTIONGUIDENM_TITLE   = "���_��";
        private const string SUBSECTIONCODE_TITLE   = "����R�[�h";
        private const string SUBSECTIONNAME_TITLE   = "���喼";

        // �e�[�u������
        //private const string MAIN_TABLE     = "SecInfoSet"; // ���_  // DEL 2008/06/04
        private const string DETAILS_TABLE  = "SubSection";  // ����

        // �K�C�h�L�[
        //private const string MAIN_GUID_KEY = "MainGuid";  // DEL 2008/06/04
        private const string DETAILS_GUID_KEY = "DetailsGuid";

        // ��ʃ��C�A�E�g�p�萔
        private const int BUTTON_LOCATION1_X = 146;     // ���S�폜�{�^���ʒuX
        private const int BUTTON_LOCATION2_X = 273;     // �����{�^���ʒuX
        private const int BUTTON_LOCATION3_X = 400;     // �ۑ��{�^���ʒuX
        private const int BUTTON_LOCATION4_X = 527;     // ����{�^���ʒuX
        private const int BUTTON_LOCATION_Y = 8;        // �{�^���ʒuY(����)

        // Message�֘A��`
        //private const string ASSEMBLY_ID = "MAKHN09330U";
        private const string ASSEMBLY_ID = "DCKHN09010U";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        #endregion

        # region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new DCKHN09010UA());
        }
        # endregion

        # region Properties

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
        /// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
        /// <value>�{���Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion

        # region Public Methods

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { false, true };
            return logicalDelete;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _detailsGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] gridIcon = { _mainGridIcon, _detailsGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// �V�K�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, true };
            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                newButtonEnabled[1] = false;
            }
            return newButtonEnabled;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, true };
            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                modifyButtonEnabled[1] = false;
            }
            return modifyButtonEnabled;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, true };
            // �e�f�[�^���Ȃ��ꍇ�́A����
            if (this._mainDataIndex < 0)
            {
                deleteButtonEnabled[1] = false;
            }
            return deleteButtonEnabled;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = DETAILS_TABLE;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// ���_��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // �N���A
                //this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();  // DEL 2008/06/04
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();  // ADD 2008/06/04
                //this._mainTable.Clear();  // DEL 2008/06/04
                this._detailsTable.Clear();  // ADD 2008/06/04

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                if (this._secInfoAcs.SecInfoSetList.Length > 0)
                {
                    
                    // �擾�������_���N���X���f�[�^�Z�b�g�֓W�J����
                    int index = 0;
                    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                    {
                        // ���_���N���X�f�[�^�Z�b�g�W�J����
                        MainToDataSet(secInfoSet.Clone(), index);
                        ++index;
                    }

                    totalCount = this._secInfoAcs.SecInfoSetList.Length;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                ArrayList retList = new ArrayList();
                status = this._subsectionAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (SubSection subSection in retList)
                        {
                            if (this._detailsTable.ContainsKey(subSection.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(subSection.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retList.Count;
                        break;
                    case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					    break;
				    default:
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"DCKHN09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"����ݒ�", 					    // �v���O��������
                        "Search", 					        // ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._subsectionAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					break;
                }
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
            }
            catch (Exception)
            {
                // �T�[�`
                TMsgDisp.Show(
                    this,								  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                    ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text,							  // �v���O��������
                    "Search",							  // ��������
                    TMsgDisp.OPE_GET,					  // �I�y���[�V����
                    ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                    status,								  // �X�e�[�^�X�l
                    // --- DEL 2008/09/16 -------------------------------->>>>>
                    //this._secInfoAcs,				      // �G���[�����������I�u�W�F�N�g
                    // --- DEL 2008/09/16 --------------------------------<<<<<
                    // --- ADD 2008/09/16 -------------------------------->>>>>
                    this._subsectionAcs,				      // �G���[�����������I�u�W�F�N�g
                    // --- ADD 2008/09/16 --------------------------------<<<<<
                    MessageBoxButtons.OK,				  // �\������{�^��
                    MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                status = -1;
                return status;
            }

            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 9;
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���匟������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList SubsectionList = null;

            // �I������Ă��鋒�_�R�[�h���擾����
            string sectionCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];

            // ����擾
            status = this._subsectionAcs.SearchAll(out SubsectionList, this._enterpriseCode, sectionCode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                        this._detailsTable.Clear();

                        int index = 0;
                        foreach ( SubSection subsection in SubsectionList )
                        {
                            if ( this._detailsTable.ContainsKey(subsection.FileHeaderGuid) == false )
                            {
                                DetailsToDataSet(subsection.Clone(), index);
                                ++index;
                            }
                        }

                        totalCount = SubsectionList.Count;

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �f�[�^�Ȃ��̏ꍇ�̓O���b�h���N���A
                        this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                        this._detailsTable.Clear();
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "DetailsDataSearch", 				// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            ERR_READ_MSG,						// �\�����郁�b�Z�[�W 
                            status, 							// �X�e�[�^�X�l
                            this._subsectionAcs, 			    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }

            return status;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // ������
            return 9;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName) {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    break;
                // ����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    // ����_���폜����
                    status = LogicalDeleteSubsection();
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            status = LogicalDeleteSubsection();  // ADD 2008/06/04

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̈ז�����
            return 0;
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            // ���_Grid
            Hashtable main = new Hashtable();
            main.Add(SECTIONCODE_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            main.Add(SECTIONGUIDENM_TITLE,  new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            main.Add(MAIN_GUID_KEY,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));

            // ����Grid
            Hashtable details = new Hashtable();
            details.Add(DELETE_DATE_TITLE,      new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            details.Add(SECTIONCODE_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(SUBSECTIONCODE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "",   Color.Black));
            details.Add(SUBSECTIONNAME_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(DETAILS_GUID_KEY,       new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));

            _hashtable = new Hashtable[2];
            _hashtable[0] = main;
            _hashtable[1] = details;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion

        # region Private Methods

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���_�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="secInfoSet">���_�ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���_�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void MainToDataSet(SecInfoSet secInfoSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][SECTIONCODE_TITLE] = secInfoSet.SectionCode;
            // ���_����
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = secInfoSet.SectionGuideNm;
            // GUID
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][MAIN_GUID_KEY] = secInfoSet.FileHeaderGuid;


            // �n�b�V���e�[�u���X�V
            if (this._mainTable.ContainsKey(secInfoSet.FileHeaderGuid) == true)
            {
                this._mainTable.Remove(secInfoSet.FileHeaderGuid);
            }
            this._mainTable.Add(secInfoSet.FileHeaderGuid, secInfoSet);
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// ����ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="subsection">����ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ����ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void DetailsToDataSet ( SubSection subsection, int index )
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[DETAILS_TABLE].NewRow();
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if ( subsection.LogicalDeleteCode == 0 )
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = subsection.UpdateDateTimeJpInFormal;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONCODE_TITLE] = subsection.SectionCode;

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���_����
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = GetSectionName(subsection.SectionCode);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // ����R�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SUBSECTIONCODE_TITLE] = subsection.SubSectionCode.ToString("00");
            // ���喼��
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SUBSECTIONNAME_TITLE] = subsection.SubSectionName;

            // GUID
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = subsection.FileHeaderGuid;

            // �n�b�V���e�[�u���X�V
            if ( this._detailsTable.ContainsKey(subsection.FileHeaderGuid) == true )
            {
                this._detailsTable.Remove(subsection.FileHeaderGuid);
            }
            this._detailsTable.Add(subsection.FileHeaderGuid, subsection);
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            /* --- DEL 2008/09/16 -------------------------------->>>>>
            string sectionName = "���o�^";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

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
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
            --- DEL 2008/09/16 -------------------------------->>>>> */
            // --- ADD 2008/09/16 -------------------------------->>>>>
            return this._subsectionAcs.GetSectionName(sectionCode);
            // --- ADD 2008/09/16 --------------------------------<<<<<
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// ����ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�폜����
        /// </summary>
        /// <param name="subsection">����ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        private void DeleteFromDataSet ( SubSection subsection, int index )
        {
            // �f�[�^�Z�b�g����s�폜���܂�
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // �n�b�V���e�[�u������폜���܂�
            if ( this._detailsTable.ContainsKey(subsection.FileHeaderGuid) == true ) {
                this._detailsTable.Remove(subsection.FileHeaderGuid);
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //DataTable mainTable     = new DataTable(MAIN_TABLE);    // ���_  // DEL 2008/06/04
            DataTable detailsTable  = new DataTable(DETAILS_TABLE); // ����

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            mainTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            mainTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));
            mainTable.Columns.Add(MAIN_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(mainTable);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(SUBSECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(SUBSECTIONNAME_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));

            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ���[�h���x��
            this.Mode_Label.Text = INSERT_MODE;

            // �{�^��
            this.Delete_Button.Visible  = true;  // ���S�폜�{�^��
            this.Revive_Button.Visible  = true;  // �����{�^��
            this.Ok_Button.Visible      = true;  // �ۑ��{�^��
            this.Cancel_Button.Visible = true;  // ����{�^��
            // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.Renewal_Button.Visible = true;  // �ŐV���{�^��
            // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �ۑ��{�^���ʒu
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu
            this.Renewal_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu

            // ���_��
            this.tEdit_SectionCode.Clear();
            this.SectionGuideNm_tEdit.Text = "";
            this.tEdit_SectionCode.Enabled = true;
            this.SectionGuideNm_tEdit.Enabled = false;

            // ���啔
            this.tNedit_SubSectionCode.Clear();
            this.SubSectionName_tEdit.Clear();
            this.tNedit_SubSectionCode.Enabled = true;
            this.SubSectionName_tEdit.Enabled = true;
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // UI��ʕ\�����̃`������}����ׂɁA�����ŃT�C�Y���ύX
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName) {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    break;
                // ����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    // �V�K�̏ꍇ
                    if (this._detailsDataIndex < 0) {
                        ScreenInputPermissionControl(3);                        // ��ʓ��͋�����
                    }
                    // �폜�̏ꍇ
                    else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DELETE_DATE_TITLE] != "") {
                        ScreenInputPermissionControl(5);                        // ��ʓ��͋�����
                    }
                    // �X�V�̏ꍇ
                    else {
                        ScreenInputPermissionControl(4);                        // ��ʓ��͋�����
                    }
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                ScreenInputPermissionControl(3);                        // ��ʓ��͋�����
            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                ScreenInputPermissionControl(5);                        // ��ʓ��͋�����
            }
            // �X�V�̏ꍇ
            else
            {
                ScreenInputPermissionControl(4);                        // ��ʓ��͋�����
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�e-�V�K, 1:�e-�X�V, 2:�e-�폜, 3:�q-�V�K, 4:�q-�X�V, 5:�q-�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType) {
                // 0:���_-�V�K
                case 0:
                    break;
                // 1:���_-�X�V
                case 1:
                    break;
                // 2:���_-�폜
                case 2:
                    break;
                // 3:����-�V�K
                case 3:
                    // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                    this.tEdit_SectionCode.Enabled = true;
                    this.SectionGuide_ultraButton.Enabled = true;
                    // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                    break;
                // 4:����-�X�V
                case 4:
                    // �\������
                    this.tNedit_SubSectionCode.Enabled = false;

                    // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                    this.tEdit_SectionCode.Enabled = true;
                    this.SectionGuide_ultraButton.Enabled = true;
                    // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                    break;
                // 5:����-�폜
                case 5:
                    // �\������
                    this.tNedit_SubSectionCode.Enabled = false;
                    this.SubSectionName_tEdit.Enabled = false;

                    // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_ultraButton.Enabled = false;
                    // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = false;
                    // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
                    this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu

                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                    // ���_���_���폜�̏ꍇ�͕����֎~
                    Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][MAIN_GUID_KEY];
                    SecInfoSet pustSecInfoSet = (SecInfoSet)this._mainTable[guid];
                    if (pustSecInfoSet.LogicalDeleteCode != 0) {
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
                        this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu
                    }
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                    break;
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    break;
                // ����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    SubSection subsection = new SubSection();

                    // �V�K�̏ꍇ
                    if (this._detailsDataIndex < 0) {
                        // ��ʓW�J����
                        SubsectionToScreen(subsection);

                        // �N���[���쐬
                        this._SubsectionClone = subsection.Clone();
                        DispToSubsection(ref this._SubsectionClone);

                        // �t�H�[�J�X�ݒ�
                        this.SubSectionCode_tNedit.Focus();
                    }
                    // �폜�̏ꍇ
                    else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DELETE_DATE_TITLE] != "") {
                        // �폜���[�h
                        this.Mode_Label.Text = DELETE_MODE;

                        // �\�����擾
                        Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DETAILS_GUID_KEY];
                        subsection = ( SubSection ) this._detailsTable[guid];

                        // ��ʓW�J����
                        SubsectionToScreen(subsection);
                    }
                    // �X�V�̏ꍇ
                    else {
                        // �X�V���[�h
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �\�����擾
                        Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DETAILS_GUID_KEY];
                        subsection = ( SubSection ) this._detailsTable[guid];

                        // ��ʓW�J����
                        SubsectionToScreen(subsection);

                        // �N���[���쐬
                        this._SubsectionClone = subsection.Clone();
                        DispToSubsection(ref this._SubsectionClone);

                        // �t�H�[�J�X�ݒ�
                        this.SubSectionName_tEdit.SelectAll();
                    }
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            SubSection subsection = new SubSection();

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // ��ʓW�J����
                SubsectionToScreen(subsection);

                // �N���[���쐬
                this._SubsectionClone = subsection.Clone();
                DispToSubsection(ref this._SubsectionClone);

                // �t�H�[�J�X�ݒ�
                this.tNedit_SubSectionCode.Focus();
            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // �폜���[�h
                this.Mode_Label.Text = DELETE_MODE;

                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                subsection = (SubSection)this._detailsTable[guid];

                // ��ʓW�J����
                SubsectionToScreen(subsection);
            }
            // �X�V�̏ꍇ
            else
            {
                // �X�V���[�h
                this.Mode_Label.Text = UPDATE_MODE;

                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                subsection = (SubSection)this._detailsTable[guid];

                // ��ʓW�J����
                SubsectionToScreen(subsection);

                // �N���[���쐬
                this._SubsectionClone = subsection.Clone();
                DispToSubsection(ref this._SubsectionClone);

                // �t�H�[�J�X�ݒ�
                this.SubSectionName_tEdit.SelectAll();
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            //_GridIndex�o�b�t�@�ێ�
            this._detailsIndexBuf = this._dataIndex;  // ADD 2008/06/04
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._detailsIndexBuf = this._detailsDataIndex;
            this._mainIndexBuf = this._mainDataIndex;
            this._targetTableBuf = this._targetTableName;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        /// <summary>
        /// ���_�N���X��ʓW�J����
        /// </summary>
        /// <param name="secInfoSet">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void SecInfoSetToScreen(SecInfoSet secInfoSet)
        {
            this.tEdit_SectionCode.Text     = secInfoSet.SectionCode;       // ���_�R�[�h
            this.SectionGuideNm_tEdit.Text  = secInfoSet.SectionGuideNm;    // ���_����
        }

        /// <summary>
        /// ����N���X��ʓW�J����
        /// </summary>
        /// <param name="Subsection">����I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void SubsectionToScreen(SubSection Subsection)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // ���_�R�[�h
            this.SectionCode_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];
            // ���_����
            this.SectionGuideNm_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONGUIDENM_TITLE];
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���_�R�[�h
            this.tEdit_SectionCode.DataText = Subsection.SectionCode.Trim();

            // ���_����
            this.SectionGuideNm_tEdit.DataText = GetSectionName(Subsection.SectionCode);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // ����R�[�h
            if (Subsection.SubSectionCode == 0) {
                this.tNedit_SubSectionCode.Text = "";
            }
            else {
                this.tNedit_SubSectionCode.Text = Subsection.SubSectionCode.ToString("00");
            }
            this.SubSectionName_tEdit.Text = Subsection.SubSectionName;                 // ���喼��

        }

        /// <summary>
        /// ��ʏ�񋒓_�N���X�i�[����
        /// </summary>
        /// <param name="secInfoSet">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
        {
            secInfoSet.SectionCode      = this.tEdit_SectionCode.Text;      // ���_�R�[�h
            secInfoSet.SectionGuideNm   = this.SectionGuideNm_tEdit.Text;   // ���_����
            secInfoSet.EnterpriseCode   = this._enterpriseCode;             // ��ƃR�[�h
        }

        /// <summary>
        /// ��ʏ�񕔖�N���X�i�[����
        /// </summary>
        /// <param name="Subsection">����I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂畔��I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void DispToSubsection(ref SubSection Subsection)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (Mode_Label.Text == INSERT_MODE) {
                // ���_�R�[�h
                Subsection.SectionCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // ��ƃR�[�h
            Subsection.EnterpriseCode = this._enterpriseCode;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName) {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    break;
                // ����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    Subsection.SectionCode   = this.SectionCode_tEdit.Text;
                    Subsection.SectionGuideNm = this.SectionGuideNm_tEdit.Text;
                    Subsection.SubSectionCode = ToInt( this.SubSectionCode_tNedit.Text );
                    Subsection.SubSectionName = this.SubSectionName_tEdit.Text;
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            Subsection.SectionCode = this.tEdit_SectionCode.DataText;
            Subsection.SubSectionCode = this.tNedit_SubSectionCode.GetInt();
            Subsection.SubSectionName = this.SubSectionName_tEdit.DataText;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName) {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    break;
                // ����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    // ����R�[�h
                    if (this.SubSectionCode_tNedit.Text == "") {
                        control = this.SubSectionCode_tNedit;
                        message = this.SubsectionCode_Title_Label.Text + "����͂��ĉ������B";
                        result = false;
                    }
                    // ���喼��
                    else if (this.SubSectionName_tEdit.Text.Trim() == "") {
                        control = this.SubSectionName_tEdit;
                        message = this.SubsectionName_Title_Label.Text + "����͂��ĉ������B";
                        result = false;
                    }
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ����R�[�h
            if (this.tNedit_SubSectionCode.Text == "")
            {
                control = this.tNedit_SubSectionCode;
                message = this.SubsectionCode_Title_Label.Text + "����͂��ĉ������B";
                result = false;
            }
            // ���喼��
            else if (this.SubSectionName_tEdit.Text.Trim() == "")
            {
                control = this.SubSectionName_tEdit;
                message = this.SubsectionName_Title_Label.Text + "����͂��ĉ������B";
                result = false;
            }
            // ���_�R�[�h
            else if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                control = this.tEdit_SectionCode;
                message = this.SectionCode_Title_Label.Text + "����͂��ĉ������B";
                result = false;
            }
            else if (GetSectionName(this.tEdit_SectionCode.DataText.Trim()) == "")
            {
                control = this.tEdit_SectionCode;
                message = "�}�X�^�ɓo�^����Ă��܂���B";
                result = false;
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            return result;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="saveTarget">�ۑ��}�X�^ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�E����̕ۑ��������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        //private bool SaveProc(string saveTarget)  // DEL 2008/06/04
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // �s���f�[�^���̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message)) {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (saveTarget) {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    break;
                // ����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    // ����X�V
                    if (!SaveSubsection()) {
                        return false;
                    }
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // ����X�V
            if (!SaveSubsection())
            {
                return false;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return true;
        }

        /// <summary>
        /// ����e�[�u���X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note       : Subsection�e�[�u���̍X�V���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private bool SaveSubsection()
        {
            Control control = null;
            SubSection Subsection = new SubSection();
            //SubSectionWork SubsectionWork = new SubSectionWork();  // DEL 2008/06/04

            // �o�^���R�[�h���擾
            if (this._detailsIndexBuf >= 0) {
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                Subsection = ( ( SubSection ) this._detailsTable[guid] ).Clone();
            }

            // SecInfoSet�N���X�Ƀf�[�^���i�[
            DispToSubsection(ref Subsection);

            // SecInfoSet�N���X���A�N�Z�X�N���X�ɓn���ēo�^�E�X�V
            int status = this._subsectionAcs.Write(ref Subsection);

            // �G���[����
            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash�X�V����
                    DetailsToDataSet(Subsection, this._detailsIndexBuf);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // �d������
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._subsectionAcs);
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();
                    return false;
                default:
                    // �o�^���s
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "SaveSubsection",				    // ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._subsectionAcs,				    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return false;
            }

            // �V�K�o�^������
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// ���� �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����̑Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            // �폜�Ώە���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            SubSection subsection = ( ( SubSection ) this._detailsTable[guid] ).Clone();

            status = this._subsectionAcs.LogicalDelete(ref subsection);
            
            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DetailsToDataSet(subsection, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._subsectionAcs);
                    // �t���[���X�V
                    DetailsToDataSet(subsection, _dataIndex);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "LogicalDeleteSubsection",	        // ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._subsectionAcs,			        // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // �t���[���X�V
                    DetailsToDataSet(subsection, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// ���� �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����̑Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private int PhysicalDeleteSubsection()
        {
            int status = 0;
            //int dummy = 0;
            Guid guid;

            // �폜�Ώە���擾
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            SubSection subsection = ( ( SubSection ) this._detailsTable[guid] ).Clone();

            // �����폜
            status = this._subsectionAcs.Delete(subsection);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DeleteFromDataSet(subsection, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._subsectionAcs);
                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "PhysicalDeleteSubsection",		    // ��������
                        TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                        ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._subsectionAcs,					// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // UI�q��ʋ����I������
                    EnforcedEndTransaction();

                    return status;
            }

            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuf = -2;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// ���_ ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����̑Ώۃ��R�[�h�𕜊����܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private int ReviveSubsection()
        {
            int status = 0;
            Guid guid;

            // �����Ώە���擾
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            SubSection Subsection = ( ( SubSection ) this._detailsTable[guid] ).Clone();

            // ����
            status = this._subsectionAcs.Revival(ref Subsection);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�W�J����
                    DetailsToDataSet(Subsection, this._dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._subsectionAcs);
                    return status;
                default:
                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        this.Text,							// �v���O��������
                        "ReviveSubsection",				    // ��������
                        TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                        ERR_RVV_MSG,						// �\�����郁�b�Z�[�W 
                        status,								// �X�e�[�^�X�l
                        this._subsectionAcs,					// �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    return status;
            }

            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE) 
            {
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                if (TargetTableName == MAIN_TABLE) 
                {
                    // �f�[�^�C���f�b�N�X������������
                    this._mainDataIndex = -1;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // ��ʃN���A����
                ScreenClear();
                // ��ʏ����ݒ菈��
                ScreenInitialSetting();
                // ��ʍč\�z����
                ScreenReconstruction();
            }
            else {
                this.DialogResult = DialogResult.OK;
                this._detailsIndexBuf = -2;

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this._mainIndexBuf = -2;
                this._targetTableBuf = "";
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                if (CanClose == true) {
                    this.Close();
                }
                else {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// UI�q��ʋ����I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// �d������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="control">�ΏۃR���g���[��</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̏d���������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                ERR_DPR_MSG, 	                    // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch ( TargetTableName ) {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE: 
                    control = this.SectionCode_tEdit;
                    break;
                // ����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    control = this.SubSectionCode_tNedit;
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            control = this.tNedit_SubSectionCode;  // ADD 2008/06/04
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
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
                case ( int ) ConstantManagement.DB_Status.ctDB_ALRDY_DELETE: 
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

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/6/4</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_SubSectionCode.Size = new System.Drawing.Size(36, 24);
            this.SubSectionName_tEdit.Size = new System.Drawing.Size(322, 24);
            this.tEdit_SectionCode.Size = new System.Drawing.Size(36, 24);
            this.SectionGuideNm_tEdit.Size = new System.Drawing.Size(115, 24);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load �C�x���g(MAKHN09230U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void MAKHN09230UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.SectionGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// Form.Closing �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void MAKHN09230UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this._mainIndexBuf = -2;  // DEL 2008/06/04
            this._detailsIndexBuf = -2;
            //this._targetTableBuf = "";  // DEL 2008/06/04

            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
            if ( CanClose == false ) {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void MAKHN09230UA_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Owner.Activate();

            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if ( this.Visible == false ) {
                return;
            }

            // ��ʃN���A����
            ScreenClear();

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^����
            //SaveProc(this._targetTableName);  // DEL 2008/06/04
            SaveProc();
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if ( this.Mode_Label.Text != DELETE_MODE ) {
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                switch ( this._targetTableName ) {
                    // ���_�e�[�u���̏ꍇ
                    case MAIN_TABLE:
                        break;
                    // ����e�[�u���̏ꍇ
                    case DETAILS_TABLE: 
                        // ���݂̉�ʏ����擾
                        SubSection subsection = new SubSection();
                        subsection = this._SubsectionClone.Clone();
                        DispToSubsection(ref subsection);
                        // �ŏ��Ɏ擾������ʏ��Ɣ�r
                        cloneFlg = this._SubsectionClone.Equals(subsection);
                        break;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // ���݂̉�ʏ����擾
                SubSection subsection = new SubSection();
                subsection = this._SubsectionClone.Clone();
                DispToSubsection(ref subsection);
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                cloneFlg = this._SubsectionClone.Equals(subsection);
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                if ( !( cloneFlg ) ) {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "",									// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);		// �\������{�^��

                    switch ( res ) {
                        case DialogResult.Yes:
                            //if ( SaveProc(this._targetTableName) ) {  // DEL 2008/06/04
                            if (SaveProc()) {
                                this.DialogResult = DialogResult.OK;
                                break;
                            }
                            else {
                                return;
                            }
                        case DialogResult.No: 
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        default:
                            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tNedit_SubSectionCode.Focus();
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

            if ( UnDisplaying != null ) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            if ( CanClose == true ) {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if ( result == DialogResult.OK ) {
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                switch ( this._targetTableName ) {
                    // ���_�e�[�u���̏ꍇ
                    case MAIN_TABLE:
                        break;
                    // ����e�[�u���̏ꍇ
                    case DETAILS_TABLE:
                        // ���啨���폜
                        PhysicalDeleteSubsection();
                        break;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // ���啨���폜
                PhysicalDeleteSubsection();
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch ( this._targetTableName ) {
                // ���_�e�[�u���̏ꍇ
                case MAIN_TABLE:
                    break;
                // ����e�[�u���̏ꍇ
                case DETAILS_TABLE:
                    // ���_����
                    ReviveSubsection();
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            ReviveSubsection();  // ADD 2008/06/04
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					 �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����񁨐��l�@�ϊ�
        /// </summary>
        /// <param name="text">������</param>
        /// <returns>���l</returns>
        private int ToInt( string text ) 
        {
            try {
                return Convert.ToInt32( text );
            }
            catch {
                return 0;
            }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private void SectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionGuideNm_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    //this.Ok_Button.Focus();
                    this.Renewal_Button.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        
            switch (e.PrevCtrl.Name)
            {
                //case "SubSectionCode_tNedit":
                case "tNedit_SubSectionCode":
                    // ����R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Right)
                    {
                        // ���喼�̂Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = this.SubSectionName_tEdit;
                    }
                    
                    // ���[�h�ύX����
                    // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = tNedit_SubSectionCode;
                        }
                    }
                    // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                    break;
                case "SubSectionName_tEdit":
                    // ���喼�̂Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Down)
                    {
                        // ���_�R�[�h�Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = tEdit_SectionCode;
                    }
                    break;
                case "tEdit_SectionCode":
                    // ���_�R�[�h�������͂̏ꍇ
                    if (this.tEdit_SectionCode.DataText.Trim() == "")
                    {
                        this.SectionGuideNm_tEdit.DataText = "";
                        return;
                    }

                    // ���_�R�[�h�擾
                    string sectionCode = this.tEdit_SectionCode.DataText;

                    // ���_���̎擾
                    this.SectionGuideNm_tEdit.DataText = GetSectionName(sectionCode);

                    // ���_�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Enter)
                    {
                        if (this.SectionGuideNm_tEdit.DataText != "")
                        {
                            // ���_�R�[�h�Ƀt�H�[�J�X���ڂ��܂�
                            //e.NextCtrl = this.Ok_Button;
                            e.NextCtrl = this.Renewal_Button;
                        }
                    }
                    break;
                case "Ok_Button":
                    // �ۑ��{�^���Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Up)
                    {
                        // ���_�K�C�h�{�^���Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = SectionGuide_ultraButton;
                    }
                    break;
                default:
                    break;
            }
        }

        // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._subsectionAcs = new SubSectionAcs();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ����R�[�h
            string subSecCd = tNedit_SubSectionCode.GetInt().ToString("00");

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSubSecCd = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][SUBSECTIONCODE_TITLE];
                if (subSecCd.Equals(dsSubSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̕���ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ����R�[�h�̃N���A
                        tNedit_SubSectionCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̕���ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ����R�[�h�̃N���A
                                tNedit_SubSectionCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        # endregion
    }
}
