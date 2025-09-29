//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y                                       //
// �v���O��������   �FPMTAB�S�̐ݒ�i���Ӑ�ʁj�}�X�^                   //
// �v���O�����T�v   �FPMTAB�S�̐ݒ�i���Ӑ�ʁj�̓o�^�E�C���E�폜���s�� //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// �Ǘ��ԍ�  10902622-01     �쐬�S���F���|��
// �C����    2013/05/31�@    �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01     �쐬�S���F�g��
// �C����    2013/08/08�@    �C�����e�F���Ӑ�f�t�H���g�Ή�
// ---------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// BLP���M�ݒ�}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLP���M�ݒ�}�X�^���s���܂��B</br>
    /// <br>Programmer : ���|��</br>
    /// <br>Date       : 2013/05/31</br>
    /// </remarks>
    public class PMTAB09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
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
        private Broadleaf.Library.Windows.Forms.TEdit CustomerCdGuideNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel CustomerCd_Title_Label;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel Button_Panel;
        private UltraButton CustomerCdGuide_ultraButton;
        private UiSetControl uiSetControl1;
        private UltraButton Renewal_Button;
        private UltraLabel ultraLabel15;
        private UltraLabel BlpSendDiv_Title_Lable;
        private TComboEditor BlpSendDiv_tComboEditor;
        private TNedit tNedit_CustomerCode;
        private System.ComponentModel.IContainer components;

        # endregion

        # region Constructor

        /// <summary>
        /// BLP���M�ݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PMTAB09110UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint                  = false;
            this._canClose                  = false;
            this._canNew                    = true;
            this._canDelete                 = true;

            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._pmTabTtlStCustAcs = new PmTabTtlStCustAcs();       // PMTAB�S�̐ݒ�i���Ӑ�j

            this._detailsTable = new Hashtable();
            this._allSearchHash = new Hashtable();

            this._detailsIndexBuf = -2;

            GetCacheData();
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���Ӑ�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMTAB09110UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerCdGuideNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.CustomerCdGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.BlpSendDiv_Title_Lable = new Infragistics.Win.Misc.UltraLabel();
            this.BlpSendDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCdGuideNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlpSendDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 194);
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
            this.Delete_Button.TabIndex = 4;
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
            this.Revive_Button.TabIndex = 6;
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
            this.Ok_Button.TabIndex = 7;
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
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // CustomerCd_Title_Label
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.CustomerCd_Title_Label.Appearance = appearance3;
            this.CustomerCd_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CustomerCd_Title_Label.Location = new System.Drawing.Point(32, 47);
            this.CustomerCd_Title_Label.Name = "CustomerCd_Title_Label";
            this.CustomerCd_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.CustomerCd_Title_Label.TabIndex = 4;
            this.CustomerCd_Title_Label.Text = "���Ӑ�R�[�h";
            // 
            // Mode_Label
            // 
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance11;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(552, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 23;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // CustomerCdGuideNm_tEdit
            // 
            this.CustomerCdGuideNm_tEdit.AcceptsTab = true;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.CustomerCdGuideNm_tEdit.ActiveAppearance = appearance16;
            appearance1.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.CustomerCdGuideNm_tEdit.Appearance = appearance1;
            this.CustomerCdGuideNm_tEdit.AutoSelect = true;
            this.CustomerCdGuideNm_tEdit.DataText = "";
            this.CustomerCdGuideNm_tEdit.Enabled = false;
            this.CustomerCdGuideNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCdGuideNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerCdGuideNm_tEdit.Location = new System.Drawing.Point(330, 47);
            this.CustomerCdGuideNm_tEdit.MaxLength = 6;
            this.CustomerCdGuideNm_tEdit.Name = "CustomerCdGuideNm_tEdit";
            this.CustomerCdGuideNm_tEdit.ReadOnly = true;
            this.CustomerCdGuideNm_tEdit.Size = new System.Drawing.Size(237, 24);
            this.CustomerCdGuideNm_tEdit.TabIndex = 2;
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
            // CustomerCdGuide_ultraButton
            // 
            this.CustomerCdGuide_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.CustomerCdGuide_ultraButton.Location = new System.Drawing.Point(299, 47);
            this.CustomerCdGuide_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.CustomerCdGuide_ultraButton.Name = "CustomerCdGuide_ultraButton";
            this.CustomerCdGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.CustomerCdGuide_ultraButton.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "���Ӑ�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustomerCdGuide_ultraButton, ultraToolTipInfo1);
            this.CustomerCdGuide_ultraButton.Click += new System.EventHandler(this.uButton_CustomerCodeGuid_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(0, 134);
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
            this.Renewal_Button.TabIndex = 5;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(12, 81);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(640, 3);
            this.ultraLabel15.TabIndex = 169;
            // 
            // BlpSendDiv_Title_Lable
            // 
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.BlpSendDiv_Title_Lable.Appearance = appearance13;
            this.BlpSendDiv_Title_Lable.BackColorInternal = System.Drawing.Color.Transparent;
            this.BlpSendDiv_Title_Lable.Location = new System.Drawing.Point(31, 93);
            this.BlpSendDiv_Title_Lable.Name = "BlpSendDiv_Title_Lable";
            this.BlpSendDiv_Title_Lable.Size = new System.Drawing.Size(171, 24);
            this.BlpSendDiv_Title_Lable.TabIndex = 2385;
            this.BlpSendDiv_Title_Lable.Text = "�a�k�o�`�[���M�敪";
            // 
            // BlpSendDiv_tComboEditor
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BlpSendDiv_tComboEditor.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            this.BlpSendDiv_tComboEditor.Appearance = appearance45;
            this.BlpSendDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BlpSendDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BlpSendDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BlpSendDiv_tComboEditor.ItemAppearance = appearance79;
            this.BlpSendDiv_tComboEditor.Location = new System.Drawing.Point(208, 93);
            this.BlpSendDiv_tComboEditor.Name = "BlpSendDiv_tComboEditor";
            this.BlpSendDiv_tComboEditor.Size = new System.Drawing.Size(193, 24);
            this.BlpSendDiv_tComboEditor.TabIndex = 3;
            // 
            // tNedit_CustomerCode
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode.ActiveAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance18;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(208, 47);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode.TabIndex = 1;
            this.tNedit_CustomerCode.ValueChanged += new System.EventHandler(this.tNedit_CustomerCode_ValueChanged);
            // 
            // PMTAB09110UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(664, 217);
            this.Controls.Add(this.tNedit_CustomerCode);
            this.Controls.Add(this.BlpSendDiv_tComboEditor);
            this.Controls.Add(this.BlpSendDiv_Title_Lable);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.CustomerCdGuide_ultraButton);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.CustomerCd_Title_Label);
            this.Controls.Add(this.CustomerCdGuideNm_tEdit);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMTAB09110UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BLP�`�[���M�ݒ�}�X�^";
            this.Load += new System.EventHandler(this.PMTAB09110UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMTAB09110UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMTAB09110UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCdGuideNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlpSendDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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

        /// <summary>GetAppearanceTable</summary>
        /// <value>AppearanceTable���擾�܂��͐ݒ肵�܂��B</value>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(CUSTOMERCODENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(BLPSENDDIVNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>GetBindDataSet</summary>
        /// <value>BindDataSet���擾�܂��͐ݒ肵�܂��B</value>
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

        #region Private Menbers

        private PmTabTtlStCustAcs _pmTabTtlStCustAcs;     // BLP���M�ݒ�}�X�^�p�A�N�Z�X�N���X

        private string _enterpriseCode;         // ��ƃR�[�h
        private Hashtable _detailsTable;        // BLP���M�ݒ�}�X�^�p�n�b�V���e�[�u��
        private Hashtable _allSearchHash;       // �S���R�[�h�m�ۗp

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;

        private int _dataIndex;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canSpecificationSearch;
        private bool _defaultAutoFillToColumn;

        private bool _modeFlg = false;

        private int _detailsIndexBuf;

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;

        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        private CustomerInfoAcs _customerInfoAcs = null;�@//���Ӑ�}�X�^�p
        // ���Ӑ�L���b�V��
        private Dictionary<string, CustomerInfo> _customerInfoDic;

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �I�����̕ҏW�`�F�b�N�p
        private PmTabTtlStCust _PmTabTtlStCustClone;

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE      = "�폜��";
        private const string CUSTOMERCODE_TITLE      = "���Ӑ�R�[�h";
        private const string CUSTOMERCODENM_TITLE = "���Ӑ於";
        private const string BLPSENDDIVNM_TITLE = "BLP���M�敪";
        
        //����i�ԑI���敪
        private const string BLPSENDDIVNM_VALUE0 = "���M���Ȃ�";
        private const string BLPSENDDIVNM_VALUE1 = "���M����";

        // �e�[�u������
        private const string DETAILS_TABLE = "PmTabTtlStCust";  // PMTAB�S�̐ݒ�}�X�^�i���Ӑ�ʁj

        // �K�C�h�L�[
        private const string DETAILS_GUID_KEY = "DetailsGuid";

        // ��ʃ��C�A�E�g�p�萔
        private const int BUTTON_LOCATION1_X = 146;     // ���S�폜�{�^���ʒuX
        private const int BUTTON_LOCATION2_X = 273;     // �����{�^���ʒuX
        private const int BUTTON_LOCATION3_X = 400;     // �ۑ��{�^���ʒuX
        private const int BUTTON_LOCATION4_X = 527;     // ����{�^���ʒuX
        private const int BUTTON_LOCATION_Y = 8;        // �{�^���ʒuY(����)

        // Message�֘A��`
        private const string ASSEMBLY_ID = "PMTAB09110U";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        // ADD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private const string CUSTOMER_DEFAULT_NAME = "�f�t�H���g";
        private const string CUSTOMER_DEFAULT_CODE_DISP = "00000000";
        private const int CUSTOMER_DEFAULT_CODE = 0;
        /// <summary>
        /// ���Ӑ�R�[�h���͗��ŁA�f�t�H���g�R�[�h�����͂��ꂽ��
        /// </summary>
        private bool isCustomerCodeDefaultInput = false;
        /// <summary>
        /// �\������Ă��链�Ӑ�R�[�h���f�t�H���g�R�[�h�ł��邩
        /// </summary>
        private bool isCustomerCodeDefaultDisp = false;
        // ADD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        # region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMTAB09110UA());
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

        # endregion

        # region Public Methods

        /// <summary>
        /// ���Ӑ挟������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // �N���A
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();  
                this._detailsTable.Clear();  

                ArrayList retList = new ArrayList();
                status = this._pmTabTtlStCustAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
                        foreach (PmTabTtlStCust pmTabTtlStCust in retList)
                        {
                            if (this._detailsTable.ContainsKey(pmTabTtlStCust.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(pmTabTtlStCust.Clone(), index);
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
						"PMTAB09110U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        // UPD 2013/08/07 Redmine#39735 --------------------------------------->>>>>
                        //"�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)", 					    // �v���O��������
                        "BLP���M�ݒ�}�X�^", 					    // �v���O��������
                        // UPD 2013/08/07 Redmine#39735 ---------------------------------------<<<<<
                        "Search", 					        // ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._pmTabTtlStCustAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					break;
                }
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
                    this._pmTabTtlStCustAcs,				      // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
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
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            status = LogicalDeleteSubsection();  

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̈ז�����
            return 0;
        }

        # endregion

        # region Private Methods

        /// <summary>
        /// BLP���M�ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="pmTabTtlStCust">BLP���M�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : BLP���M�ݒ�}�X�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DetailsToDataSet(PmTabTtlStCust pmTabTtlStCust, int index)
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
            if (pmTabTtlStCust.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = pmTabTtlStCust.UpdateDateTimeJpInFormal;
            }

            // ���Ӑ�R�[�h
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODE_TITLE] = pmTabTtlStCust.CustomerCode.PadLeft(8,'0');

            // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //string custNm = this.GetCustomNm(pmTabTtlStCust.CustomerCode);
            //if (custNm == "")
            //{
            //    custNm = "���o�^";
            //}
            //// ���Ӑ於��
            //this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODENM_TITLE] = custNm;
            #endregion
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODENM_TITLE] = GetCustomerNameForDefault(pmTabTtlStCust.CustomerCode);
            // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ����i�ԑI���敪
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][BLPSENDDIVNM_TITLE] = this.GetBlpSendDivNm(pmTabTtlStCust.BlpSendDiv);

            // GUID
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = pmTabTtlStCust.FileHeaderGuid;

            // �n�b�V���e�[�u���X�V
            if (this._detailsTable.ContainsKey(pmTabTtlStCust.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(pmTabTtlStCust.FileHeaderGuid);
            }
            this._detailsTable.Add(pmTabTtlStCust.FileHeaderGuid, pmTabTtlStCust);
        }

        /// <summary>
        /// BLP���M�ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�폜����
        /// </summary>
        /// <param name="pmTabTtlStCust">BLP���M�ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        private void DeleteFromDataSet(PmTabTtlStCust pmTabTtlStCust, int index)
        {
            // �f�[�^�Z�b�g����s�폜���܂�
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index].Delete();

            // �n�b�V���e�[�u������폜���܂�
            if (this._detailsTable.ContainsKey(pmTabTtlStCust.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(pmTabTtlStCust.FileHeaderGuid);
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable detailsTable  = new DataTable(DETAILS_TABLE); // PMTAB�S�̐ݒ�}�X�^

            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(CUSTOMERCODENM_TITLE, typeof(string));
            detailsTable.Columns.Add(BLPSENDDIVNM_TITLE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
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
            this.Renewal_Button.Visible = true;  // �ŐV���{�^��
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �ۑ��{�^���ʒu
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu
            this.Renewal_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // �����{�^���ʒu

            // ���Ӑ敔
            this.tNedit_CustomerCode.Clear();
            this.CustomerCdGuideNm_tEdit.Text = "";
            this.tNedit_CustomerCode.Enabled = true;
            this.CustomerCdGuideNm_tEdit.Enabled = false;
            this.CustomerCdGuide_ultraButton.Enabled = true;

            //����i�ԑI���敪
            this.BlpSendDiv_tComboEditor.Items.Clear();
            this.BlpSendDiv_tComboEditor.Items.Add(0,BLPSENDDIVNM_VALUE0);
            this.BlpSendDiv_tComboEditor.Items.Add(1,BLPSENDDIVNM_VALUE1);
            this.BlpSendDiv_tComboEditor.Enabled = true;


        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                ScreenInputPermissionControl(1);                        // ��ʓ��͋�����
            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                ScreenInputPermissionControl(2);                        // ��ʓ��͋�����
            }
            // �X�V�̏ꍇ
            else
            {
                ScreenInputPermissionControl(3);                        // ��ʓ��͋�����
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�e-�V�K, 1:�e-�X�V, 2:�e-�폜, 3:�q-�V�K, 4:�q-�X�V, 5:�q-�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType) {
                // 1:�V�K
                case 1:
                    this.tNedit_CustomerCode.Enabled = true;
                    this.CustomerCdGuide_ultraButton.Enabled = true;
                    this.CustomerCdGuideNm_tEdit.Enabled = false;
                    this.BlpSendDiv_tComboEditor.Enabled = true;

                    // �{�^��
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Renewal_Button.Visible = true;

                    break;
                // 2:�X�V
                case 3:
                    // �\������
                    this.tNedit_CustomerCode.Enabled = false;
                    this.CustomerCdGuideNm_tEdit.Enabled = false;
                    this.CustomerCdGuide_ultraButton.Enabled = false;
                    this.BlpSendDiv_tComboEditor.Enabled = true;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Revive_Button.Visible = false;
                    this.Delete_Button.Visible = false;
                    this.Renewal_Button.Visible = true;

                    break;
                // 3:�폜
                case 2:
                    // �\������
                    this.tNedit_CustomerCode.Enabled = false;
                    this.CustomerCdGuideNm_tEdit.Enabled = false;
                    this.CustomerCdGuide_ultraButton.Enabled = false;
                    this.BlpSendDiv_tComboEditor.Enabled = false;

                    // �{�^��
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // ���S�폜�{�^���ʒu
                    this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // �����{�^���ʒu
                    this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // ����{�^���ʒu
                    break;
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // ��ʓW�J����
                SubsectionToScreen(pmTabTtlStCust);

                // �N���[���쐬
                this._PmTabTtlStCustClone = pmTabTtlStCust.Clone();
                DispToSubsection(ref this._PmTabTtlStCustClone);

            }
            // �폜�̏ꍇ
            else if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
            {
                // �폜���[�h
                this.Mode_Label.Text = DELETE_MODE;

                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStCust = (PmTabTtlStCust)this._detailsTable[guid];

                // ��ʓW�J����
                SubsectionToScreen(pmTabTtlStCust);
            }
            // �X�V�̏ꍇ
            else
            {
                // �X�V���[�h
                this.Mode_Label.Text = UPDATE_MODE;

                // �\�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStCust = (PmTabTtlStCust)this._detailsTable[guid];

                // ��ʓW�J����
                SubsectionToScreen(pmTabTtlStCust);

                // �N���[���쐬
                this._PmTabTtlStCustClone = pmTabTtlStCust.Clone();
                DispToSubsection(ref this._PmTabTtlStCustClone);

            }

            this._detailsIndexBuf = this._dataIndex; 

        }

        /// <summary>
        /// PMT�S�̐ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="pmTabTtlStCust">PMT�S�̐ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void SubsectionToScreen(PmTabTtlStCust pmTabTtlStCust)
        {
            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode.DataText = pmTabTtlStCust.CustomerCode.Trim();

            if (this.tNedit_CustomerCode.DataText == "")
            {
                // ���Ӑ於��
                this.CustomerCdGuideNm_tEdit.DataText = "";
            }
            else
            {
                // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //string custNm = this.GetCustomNm(pmTabTtlStCust.CustomerCode.Trim());
                //if (custNm == "")
                //{
                //    custNm = "���o�^";
                //}
                #endregion
                // ���Ӑ於��
                this.CustomerCdGuideNm_tEdit.DataText = GetCustomerNameForDefault(pmTabTtlStCust.CustomerCode);
                // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            }
           
            // ����i�ԑI���敪
            this.BlpSendDiv_tComboEditor.SelectedIndex = pmTabTtlStCust.BlpSendDiv;

        }

        // ADD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���Ӑ於�̎擾�@�f�t�H���g�Ή�
        /// </summary>
        /// <param name="code">���Ӑ�R�[�h</param>
        /// <returns></returns>
        private string GetCustomerNameForDefault(string code)
        {
            string custNm = string.Empty;
            int customercode;
            if (int.TryParse(code.Trim(), out customercode))
            {
                if (customercode.Equals(CUSTOMER_DEFAULT_CODE))
                {
                    custNm = CUSTOMER_DEFAULT_NAME;
                }
                else
                {
                    custNm = this.GetCustomNm(code.Trim());
                }
            }
            if (custNm == "")
            {
                custNm = "���o�^";
            }
         
            return custNm;
        }
        // ADD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// ��ʏ��S�̐ݒ�N���X�i�[����
        /// </summary>
        /// <param name="pmTabTtlStCust">PMTAB�S�̐ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�S�̐ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void DispToSubsection(ref PmTabTtlStCust pmTabTtlStCust)
        {
            // ��ƃR�[�h
            pmTabTtlStCust.EnterpriseCode = this._enterpriseCode;

            // �V�K���[�h�̂݁A���Ӑ���X�V�K�v
            if (this._dataIndex < 0)
            {
                // ���Ӑ�R�[�h
                pmTabTtlStCust.CustomerCode = this.tNedit_CustomerCode.DataText;
            }
            
            // ����i�ԑI���敪
            pmTabTtlStCust.BlpSendDiv = this.BlpSendDiv_tComboEditor.SelectedIndex;

        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = true;

            // ���Ӑ�R�[�h
            if (this.tNedit_CustomerCode.DataText.Trim() == "")
            {
                control = this.tNedit_CustomerCode;
                message = this.CustomerCd_Title_Label.Text + "����͂��ĉ������B";
                result = false;
            }
            return result;
        }


        /// <summary>
        /// ��ʓ��͏�񑶍݃`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏�񑶍݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool DateExistCheck(ref Control control, ref string message)
        {
            bool result = true;

            if (this.GetCustomNm(this.tNedit_CustomerCode.DataText.ToString()) == "")
            {
                control = this.tNedit_CustomerCode;
                message = "���Ӑ�R�[�h�����݂��܂���B";
                this.tNedit_CustomerCode.Clear();
                this.CustomerCdGuideNm_tEdit.Clear();
                result = false;
            }

            return result;
        }


        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�EPMTAB�S�̐ݒ�}�X�^�̕ۑ��������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
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

            if(this._dataIndex <0 )
            {
                if(ModeChangeProc())
                {
                    this.tNedit_CustomerCode.Focus();
                    return false;
                }
            }

            // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //if (!DateExistCheck(ref control, ref message))
            //{
            //    TMsgDisp.Show(
            //        this, 								// �e�E�B���h�E�t�H�[��
            //        emErrorLevel.ERR_LEVEL_INFO, �@�@ �@// �G���[���x��
            //        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
            //        message, 							// �\�����郁�b�Z�[�W
            //        0, 									// �X�e�[�^�X�l
            //        MessageBoxButtons.OK);				// �\������{�^��

            //    control.Focus();
            //    return false;
            //}
            #endregion
            // �f�t�H���g�ł͖����ꍇ�ɑ��݃`�F�b�N
            if (!CustomerCdGuideNm_tEdit.Text.Trim().Equals(CUSTOMER_DEFAULT_NAME))
            {
                if (!DateExistCheck(ref control, ref message))
                {
                    TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, �@�@ �@// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message, 							// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    control.Focus();
                    return false;
                }
            }
            // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>

            // PMTAB�S�̐ݒ�}�X�^�X�V
            if (!SaveSubsection())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// BLP���M�ݒ�}�X�^�e�[�u���X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note       : Subsection�e�[�u���̍X�V���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private bool SaveSubsection()
        {
            Control control = null;
            PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();

            // �o�^���R�[�h���擾
            if (this._detailsIndexBuf >= 0) {
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                pmTabTtlStCust = ((PmTabTtlStCust)this._detailsTable[guid]).Clone();
            }

            // SecInfoSet�N���X�Ƀf�[�^���i�[
            DispToSubsection(ref pmTabTtlStCust);

            // SecInfoSet�N���X���A�N�Z�X�N���X�ɓn���ēo�^�E�X�V
            int status = this._pmTabTtlStCustAcs.Write(ref pmTabTtlStCust);

            // �G���[����
            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet/Hash�X�V����
                    DetailsToDataSet(pmTabTtlStCust, this._detailsIndexBuf);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // �d������
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pmTabTtlStCustAcs);
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
                        this._pmTabTtlStCustAcs,				    // �G���[�����������I�u�W�F�N�g
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
        /// BLP���M�ݒ�}�X�^ �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BLP���M�ݒ�}�X�^�̑Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            // �폜�Ώ�PMTAB�S�̐ݒ�}�X�^�擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStCust pmTabTtlStCust = ((PmTabTtlStCust)this._detailsTable[guid]).Clone();

            status = this._pmTabTtlStCustAcs.LogicalDelete(ref pmTabTtlStCust);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DetailsToDataSet(pmTabTtlStCust, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._pmTabTtlStCustAcs);
                    // �t���[���X�V
                    DetailsToDataSet(pmTabTtlStCust, _dataIndex);
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
                        this._pmTabTtlStCustAcs,			        // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,				// �\������{�^��
                        MessageBoxDefaultButton.Button1);	// �����\���{�^��

                    // �t���[���X�V
                    DetailsToDataSet(pmTabTtlStCust, _dataIndex);

                    return status;
            }

            return status;
        }

        /// <summary>
        /// BLP���M�ݒ�}�X�^ �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BLP���M�ݒ�}�X�^�̑Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int PhysicalDeleteSubsection()
        {
            int status = 0;
            //int dummy = 0;
            Guid guid;

            // �폜�Ώ�BLP���M�ݒ�}�X�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStCust pmTabTtlStCust = ((PmTabTtlStCust)this._detailsTable[guid]).Clone();

            // �����폜
            status = this._pmTabTtlStCustAcs.Delete(pmTabTtlStCust);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�X�V
                    DeleteFromDataSet(pmTabTtlStCust, _dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._pmTabTtlStCustAcs);
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
                        this._pmTabTtlStCustAcs,					// �G���[�����������I�u�W�F�N�g
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

            if (CanClose == true) {
                this.Close();
            }
            else {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ� ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �S�̐ݒ蓾�Ӑ�ʂ̑Ώۃ��R�[�h�𕜊����܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int ReviveSubsection()
        {
            int status = 0;
            Guid guid;

            // �����Ώ�BLP���M�ݒ�}�X�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            PmTabTtlStCust pmTabTtlStCust = ((PmTabTtlStCust)this._detailsTable[guid]).Clone();

            // ����
            status = this._pmTabTtlStCustAcs.Revival(ref pmTabTtlStCust);

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // DataSet�W�J����
                    DetailsToDataSet(pmTabTtlStCust, this._dataIndex);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pmTabTtlStCustAcs);
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
                        this._pmTabTtlStCustAcs,					// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null) {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;

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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
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

            control = this.tNedit_CustomerCode;

        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
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

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void SetControlSize()
        {
            //����i�ԑI���敪
            this.BlpSendDiv_tComboEditor.Items.Clear();
            this.BlpSendDiv_tComboEditor.Items.Add(0,BLPSENDDIVNM_VALUE0);
            this.BlpSendDiv_tComboEditor.Items.Add(1, BLPSENDDIVNM_VALUE1);
        }

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load �C�x���g(MAKHN09230U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09110UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.CustomerCdGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();

            // ADD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �f�U�C�i�Őݒ肳�ꂽ���e(0�\������)���L���ɂȂ�Ȃ��̂ŁA�����ōĐݒ�
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            // ADD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// Form.Closing �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09110UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._detailsIndexBuf = -2;

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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void PMTAB09110UA_VisibleChanged(object sender, System.EventArgs e)
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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^����
            SaveProc();
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if ( this.Mode_Label.Text != DELETE_MODE ) {

                // ���݂̉�ʏ����擾
                PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();
                pmTabTtlStCust = this._PmTabTtlStCustClone.Clone();
                DispToSubsection(ref pmTabTtlStCust);
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                cloneFlg = this._PmTabTtlStCustClone.Equals(pmTabTtlStCust);

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
                            if (_modeFlg)
                            {
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
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

                // BLP���M�ݒ�}�X�^�����폜
                PhysicalDeleteSubsection();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            ReviveSubsection();  
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
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        /// <summary>
        /// ���Ӑ�K�C�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCodeGuid_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                this.BlpSendDiv_tComboEditor.Focus();
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        this.tNedit_CustomerCode.Focus();
                    }
                }
            }

        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            if (this._customerInfoAcs == null)
            {
                this._customerInfoAcs = new CustomerInfoAcs();
            }

            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.CustomerCdGuideNm_tEdit.DataText = customerInfo.CustomerSnm;

            _customerGuideOK = true;
        }

        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: ���|��</br>
        /// <br>Date		: 2013/05/31</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;
        
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode":

                    if (this.tNedit_CustomerCode.DataText.Trim() == "")
                    {
                        this.CustomerCdGuideNm_tEdit.DataText = "";
                    }
                    else
                    {
                        // ���Ӑ�R�[�h�擾
                        int customerCode = this.tNedit_CustomerCode.GetInt();
                        // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region ���\�[�X
                        ////�@���Ӑ於�̂̎擾
                        //CustomerInfo customerInfo;
                        //if (this._customerInfoAcs == null)
                        //{
                        //    this._customerInfoAcs = new CustomerInfoAcs();
                        //}
                        //int status = this._customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out customerInfo);

                        //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        //{
                        //    this.CustomerCdGuideNm_tEdit.DataText = customerInfo.CustomerSnm;
                        //}
                        //else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //{
                        //    TMsgDisp.Show(
                        //        this,
                        //        emErrorLevel.ERR_LEVEL_INFO,
                        //        this.Name,
                        //        "���Ӑ�R�[�h�����݂��܂���B",
                        //        status,
                        //        MessageBoxButtons.OK);

                        //    this.tNedit_CustomerCode.Clear();
                        //    this.CustomerCdGuideNm_tEdit.Clear();

                        //    e.NextCtrl = e.PrevCtrl;

                        //    break;
                        //}
                        //else
                        //{
                        //    TMsgDisp.Show(this,
                        //                  emErrorLevel.ERR_LEVEL_STOPDISP,
                        //                  this.Name,
                        //                  "���Ӑ���̎擾�Ɏ��s���܂����B",
                        //                  status,
                        //                  MessageBoxButtons.OK);

                        //    this.tNedit_CustomerCode.Clear();
                        //    this.CustomerCdGuideNm_tEdit.Clear();

                        //    e.NextCtrl = e.PrevCtrl;

                        //    break;
                        //}
                        #endregion

                        if (customerCode.Equals(CUSTOMER_DEFAULT_CODE))
                        {
                            this.CustomerCdGuideNm_tEdit.DataText = CUSTOMER_DEFAULT_NAME;
                            isCustomerCodeDefaultInput = true;
                        }
                        else
                        {
                            //�@���Ӑ於�̂̎擾
                            CustomerInfo customerInfo;
                            if (this._customerInfoAcs == null)
                            {
                                this._customerInfoAcs = new CustomerInfoAcs();
                            }
                            int status = this._customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out customerInfo);

                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                this.CustomerCdGuideNm_tEdit.DataText = customerInfo.CustomerSnm;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "���Ӑ�R�[�h�����݂��܂���B",
                                    status,
                                    MessageBoxButtons.OK);

                                this.tNedit_CustomerCode.Clear();
                                this.CustomerCdGuideNm_tEdit.Clear();

                                e.NextCtrl = e.PrevCtrl;

                                break;
                            }
                            else
                            {
                                TMsgDisp.Show(this,
                                              emErrorLevel.ERR_LEVEL_STOPDISP,
                                              this.Name,
                                              "���Ӑ���̎擾�Ɏ��s���܂����B",
                                              status,
                                              MessageBoxButtons.OK);

                                this.tNedit_CustomerCode.Clear();
                                this.CustomerCdGuideNm_tEdit.Clear();

                                e.NextCtrl = e.PrevCtrl;

                                break;
                            }
                        }
                        // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    }

                    // ���Ӑ�R�[�h�Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Right)
                    {
                        if (this.tNedit_CustomerCode.DataText.Trim() == "")
                        {
                            e.NextCtrl = this.CustomerCdGuide_ultraButton;
                        }
                        else 
                        {
                            e.NextCtrl = this.BlpSendDiv_tComboEditor;
                        }
                    }
                    // ���[�h�ύX����
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                        }
                    }
                    break;
                case "BlpSendDiv_tComboEditor":
                    if(e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.tNedit_CustomerCode;
                    }
                    break;
                case "Ok_Button":
                    // �ۑ��{�^���Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Up)
                    {
                        // ���Ӑ�K�C�h�{�^���Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = this.BlpSendDiv_tComboEditor;
                    }
                    break;
                default:
                    break;
            }


            // ADD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            switch (e.NextCtrl .Name)
            {
                case "tNedit_CustomerCode":
                    if (tNedit_CustomerCode.GetInt().Equals(CUSTOMER_DEFAULT_CODE) && !tNedit_CustomerCode.Text.Equals(string.Empty))
                    {
                        isCustomerCodeDefaultDisp = true;
                    }
                    break;
            }
            // ADD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._pmTabTtlStCustAcs = new PmTabTtlStCustAcs();

            this.GetCacheData();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���Ӑ�R�[�h
            string customerCode = this.tNedit_CustomerCode.Text.PadLeft(8,'0');

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dbCustCd = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][CUSTOMERCODE_TITLE];

                if (customerCode.Equals(dbCustCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��BLP���M�ݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // PMTAB�S�̐ݒ�}�X�^�R�[�h�̃N���A
                        this.tNedit_CustomerCode.Clear();
                        this.CustomerCdGuideNm_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h��BLP���M�ݒ�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // ���Ӑ�R�[�h�̃N���A
                                this.tNedit_CustomerCode.Clear();
                                this.CustomerCdGuideNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                } 
            }
            return false;
        }

        /// <summary>
        /// �a�k�o���M�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="blpSendDiv">�a�k�o���M�敪</param>
        /// <returns>�a�k�o���M�敪����</returns>
        /// <remarks>
        /// <br>Note       : �a�k�o���M�敪����a�k�o���M�敪���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetBlpSendDivNm(int blpSendDiv)
        {
            string str = string.Empty;

            switch (blpSendDiv)
            {
                case 0:
                    str = BLPSENDDIVNM_VALUE0;
                    break;
                case 1:
                    str = BLPSENDDIVNM_VALUE1;
                    break;
                default:
                    break;
            }
            return str;
        }
               
        /// <summary>
        /// ���Ӑ於�̂��擾
        /// </summary>
        /// <param name="customercode"></param>
        /// <returns></returns>
        private string GetCustomNm(string customercode)
        {
            //�@���Ӑ於�̂̎擾
            string customerNm = "";
            CustomerInfo customerinfo = null;
            try
            {
                if (_customerInfoDic.ContainsKey(customercode.PadLeft(8,'0')))
                {
                    customerinfo = _customerInfoDic[customercode.PadLeft(8,'0')];
                    customerNm = customerinfo.CustomerSnm.Trim();
                    return customerNm;
                }
                else 
                {
                    return customerNm;
                }
            }
            catch
            {
                return customerNm;
            }

        }

        /// <summary>
        /// ���Ӑ�}�X�^�̃��[�J���L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�̃��[�J���L���b�V�����쐬���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void GetCacheData()
        {
            int status;
            List<CustomerInfo> retList = new List<CustomerInfo>();
            // ���Ӑ�}�X�^�̃��[�J���L���b�V�����N���A
            _customerInfoDic = new Dictionary<string, CustomerInfo>();

            bool cacheFlag = true;
            bool issetting = true;

            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            // ���Ӑ�}�X�^�̎擾
            status = customerInfoAcs.Search(LoginInfoAcquisition.EnterpriseCode, cacheFlag, issetting, out retList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (CustomerInfo wkCustomerInfo in retList)
                {
                    if (wkCustomerInfo.LogicalDeleteCode == 0)
                    {
                        string key = wkCustomerInfo.CustomerCode.ToString().PadLeft(8,'0');
                        if (_customerInfoDic.ContainsKey(key))
                        {
                            // ���ɃL���b�V���ɑ��݂��Ă���ꍇ�͍폜
                            _customerInfoDic.Remove(key);
                        }
                        _customerInfoDic.Add(key, wkCustomerInfo);
                    }
                }
            }
        }

        /// <summary>
        /// ���Ӑ�R�[�htNedit_CustomerCode_ValueChanged�����A�����ȊO���͂ł��Ȃ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�htNedit_CustomerCode_ValueChanged�����A�����ȊO���͂ł��Ȃ�</br>
        /// <br></br>
        /// </remarks>
        private void tNedit_CustomerCode_ValueChanged(object sender, EventArgs e)
        {
            // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region �R���g���[���̃v���p�e�B(ExtEdit)�Ő����ȊO���͂ł��Ȃ��悤���䂵�Ă���̂ŕs�v
            //Regex x = new Regex("^[0-9]*$");
            //if (!(x.IsMatch(this.tNedit_CustomerCode.Text)))
            //{
            //    this.tNedit_CustomerCode.Clear();
            //    this.tNedit_CustomerCode.Focus();
            //}
            #endregion
            
            // NumEdit�v���p�e�B��"0�\������"�ɂ��Ă��邪�A0����͂����ꍇ�A
            // �ŏI�I�ɃN���A����󕶎����ݒ肳��Ă��܂��̂ŁA�ȉ��Őݒ肷��
            if (isCustomerCodeDefaultInput && tNedit_CustomerCode.Text.Equals(string.Empty))
            {
                tNedit_CustomerCode.Text = CUSTOMER_DEFAULT_CODE_DISP;
                isCustomerCodeDefaultInput = false;
            }

            // ���Ӑ�R�[�h��"00000000"���ݒ肳��Ă���ꍇ�A�t�H�[�J�X�擾���ɁA�S�ăN���A����ċ󕶎��ɂȂ��Ă��܂��̂ŁA
            // �ȉ���"0"��ݒ肷��
            if (isCustomerCodeDefaultDisp)
            {
                tNedit_CustomerCode.Text = CUSTOMER_DEFAULT_CODE.ToString();
                isCustomerCodeDefaultDisp = false;
            }
            // UPD �g�� 2013/08/08 ���Ӑ�f�t�H���g�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        # endregion
    }
}
