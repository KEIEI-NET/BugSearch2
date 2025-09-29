//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �Ώۓ��Ӑ�ݒ�
// �v���O�����T�v   : �Ώۓ��Ӑ�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note      :   2011/05/06 杍^                         
//                  :   �o�f���́A���ږ��̕ύX                               
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �Ώۓ��Ӑ�ݒ� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �Ώۓ��Ӑ�ݒ���̐ݒ���s���܂��B
    ///					  IMasterMaintenanceArrayType���������Ă��܂��B</br>
    /// <br>Update Note:  2011/05/06 杍^</br>
    /// <br>�@�@�@�@�@�@�@�o�f���́A���ږ��̕ύX</br>
    /// </remarks>
    public class PMKHN09570UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
    {
        # region -- Private Members (Component) --

        private TArrowKeyControl tArrowKeyControl1;
        private IContainer components;
        private Infragistics.Win.Misc.UltraLabel Campaign_Label;
        private TNedit tNedit_CampaignCode;
        private TRetKeyControl tRetKeyControl1;
        private DataSet Bind_DataSet;
        private Timer Initial_Timer;
        private TImeControl tImeControl1;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private TEdit tEdit_CampaignName;
        private Infragistics.Win.Misc.UltraButton uButton_CampaignGuide;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private TImeControl tImeControl2;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Guid_Button;
        private Infragistics.Win.Misc.UltraButton DeleteRow_Button;
        private UltraGrid uGrid_Customer;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;

        # endregion

        #region -- Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h --
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09570UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.tNedit_CampaignCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Campaign_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.uButton_CampaignGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_CampaignName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tImeControl2 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Guid_Button = new Infragistics.Win.Misc.UltraButton();
            this.DeleteRow_Button = new Infragistics.Win.Misc.UltraButton();
            this.uGrid_Customer = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CampaignCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CampaignName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Customer)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 462);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(608, 23);
            this.ultraStatusBar1.TabIndex = 47;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = null;
            this.tImeControl1.OutControl = null;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 20;
            // 
            // tNedit_CampaignCode
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance22.TextHAlignAsString = "Right";
            this.tNedit_CampaignCode.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            this.tNedit_CampaignCode.Appearance = appearance23;
            this.tNedit_CampaignCode.AutoSelect = true;
            this.tNedit_CampaignCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CampaignCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CampaignCode.DataText = "";
            this.tNedit_CampaignCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CampaignCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CampaignCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tNedit_CampaignCode.Location = new System.Drawing.Point(151, 44);
            this.tNedit_CampaignCode.MaxLength = 6;
            this.tNedit_CampaignCode.Name = "tNedit_CampaignCode";
            this.tNedit_CampaignCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CampaignCode.Size = new System.Drawing.Size(66, 24);
            this.tNedit_CampaignCode.TabIndex = 1;
            this.tNedit_CampaignCode.TabStop = false;
            // 
            // Campaign_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.Campaign_Label.Appearance = appearance9;
            this.Campaign_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Campaign_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Campaign_Label.Location = new System.Drawing.Point(12, 44);
            this.Campaign_Label.Name = "Campaign_Label";
            this.Campaign_Label.Size = new System.Drawing.Size(133, 24);
            this.Campaign_Label.TabIndex = 61;
            this.Campaign_Label.Text = "�L�����y�[���R�[�h";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(471, 413);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(340, 413);
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
            this.Delete_Button.Location = new System.Drawing.Point(212, 413);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 7;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(340, 413);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 9;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // uButton_CampaignGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CampaignGuide.Appearance = appearance12;
            this.uButton_CampaignGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CampaignGuide.Location = new System.Drawing.Point(483, 44);
            this.uButton_CampaignGuide.Name = "uButton_CampaignGuide";
            this.uButton_CampaignGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CampaignGuide.TabIndex = 2;
            this.uButton_CampaignGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CampaignGuide.Click += new System.EventHandler(this.uButton_ModelGuide_Click);
            // 
            // tEdit_CampaignName
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.tEdit_CampaignName.ActiveAppearance = appearance1;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.tEdit_CampaignName.Appearance = appearance2;
            this.tEdit_CampaignName.AutoSelect = true;
            this.tEdit_CampaignName.DataText = "";
            this.tEdit_CampaignName.Enabled = false;
            this.tEdit_CampaignName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CampaignName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CampaignName.Location = new System.Drawing.Point(225, 44);
            this.tEdit_CampaignName.MaxLength = 15;
            this.tEdit_CampaignName.Name = "tEdit_CampaignName";
            this.tEdit_CampaignName.ReadOnly = true;
            this.tEdit_CampaignName.Size = new System.Drawing.Size(252, 24);
            this.tEdit_CampaignName.TabIndex = 68;
            this.tEdit_CampaignName.TabStop = false;
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(496, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 69;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // tImeControl2
            // 
            this.tImeControl2.InControl = null;
            this.tImeControl2.OutControl = null;
            this.tImeControl2.OwnerForm = this;
            this.tImeControl2.PutLength = 15;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Guid_Button
            // 
            this.Guid_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Guid_Button.Location = new System.Drawing.Point(116, 91);
            this.Guid_Button.Name = "Guid_Button";
            this.Guid_Button.Size = new System.Drawing.Size(161, 29);
            this.Guid_Button.TabIndex = 4;
            this.Guid_Button.Text = "���Ӑ�޲��(&G)";
            this.Guid_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Guid_Button.Click += new System.EventHandler(this.Guid_Button_Click);
            // 
            // DeleteRow_Button
            // 
            this.DeleteRow_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteRow_Button.Location = new System.Drawing.Point(12, 91);
            this.DeleteRow_Button.Name = "DeleteRow_Button";
            this.DeleteRow_Button.Size = new System.Drawing.Size(98, 29);
            this.DeleteRow_Button.TabIndex = 3;
            this.DeleteRow_Button.Text = "�폜(&D)";
            this.DeleteRow_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DeleteRow_Button.Click += new System.EventHandler(this.DeleteRow_Button_Click);
            // 
            // uGrid_Customer
            // 
            this.uGrid_Customer.Location = new System.Drawing.Point(12, 126);
            this.uGrid_Customer.Name = "uGrid_Customer";
            this.uGrid_Customer.Size = new System.Drawing.Size(582, 270);
            this.uGrid_Customer.TabIndex = 5;
            this.uGrid_Customer.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.uGrid_Customer_ClickCellButton);
            this.uGrid_Customer.AfterExitEditMode += new System.EventHandler(this.uGrid_Customer_AfterExitEditMode);
            this.uGrid_Customer.VisibleChanged += new System.EventHandler(this.uGrid_Customer_VisibleChanged);
            this.uGrid_Customer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uGrid_Customer_KeyPress);
            this.uGrid_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Customer_KeyDown);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(212, 413);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 6;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // PMKHN09570UA
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(608, 485);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Guid_Button);
            this.Controls.Add(this.DeleteRow_Button);
            this.Controls.Add(this.uGrid_Customer);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.tEdit_CampaignName);
            this.Controls.Add(this.uButton_CampaignGuide);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Campaign_Label);
            this.Controls.Add(this.tNedit_CampaignCode);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PMKHN09570UA";
            this.Text = "�Ώۓ��Ӑ�ݒ�";
            this.Load += new System.EventHandler(this.PMKHN09570UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09570UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMKHN09570UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CampaignCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CampaignName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Customer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        # endregion

        #region -- Private Members --
        private CampaignLinkAcs _campaignLinkAcs;
        private CustomerInfoAcs _customerInfoAcs = null;    // ���Ӑ���A�N�Z�X�N���X

        private CampaignLink _campaignLink;
        private CampaignLink[] _campaignLinkCloneList;
        
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _mainTable;
        private Hashtable _detailTable;
        private Hashtable _detailCloneTable;

        // ���Ӑ���L���b�V��
        private ArrayList _customerList;

        // ���Ӑ���_�C�A���O
        private int _customerCode;
        private string _customerName;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private string _mainGridTitle;
        private string _detailsGridTitle;
        private string _targetTableName;
        private int _mainDataIndex;
        private int _detailsDataIndex;
        private Image _mainGridIcon;
        private Image _detailsGridIcon;
        private MGridDisplayLayout _defaultGridDisplayLayout;

        // Fream��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string I_DELETEDATE = "�폜��";
        private const string I_CAMPAIGN_CODE = "�L�����y�[���R�[�h";
        private const string I_CAMPAIGN_NAME = "�L�����y�[����";
        private const string I_CAMPAIGN_GUID = "CAMPAIGN_GUID";
        private const string I_CAMPAIGN_TABLE = "CAMPAIGN_TABLE";

        private const string S_DELETEDATE = "�폜��";
        private const string S_CAMPAIGN_CODE = "�ݒ�L�����y�[���R�[�h";
        private const string S_CUSTOMER_CODE = "���Ӑ�R�[�h";
        private const string S_CUSTOMER_NAME = "���Ӑ於";
        private const string S_CUSTOMER_GUID = "CUSTOMER_GUID";
        private const string S_CUSTOMER_TABLE = "CUSTOMER_TABLE";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        private const string REFERENCE_MODE = "�Q�ƃ��[�h";

        // UI��Grid�\���p
        private const string MY_SCREEN_CUSTOMER_CODE = "���Ӑ�R�[�h";
        private const string MY_SCREEN_CUSTOMER_NAME = "���Ӑ於";
        private const string MY_SCREEN_ODER = "No.";
        private const string MY_SCREEN_GUID = "MY_SCREEN_GUID";
        private const string MY_SCREEN_TABLE = "MY_SCREEN_TABLE";
        private const string MY_SCREEN_ID = "ID";                               // ��ƁE���i���̂Ȃ�(�ҏW�s�A��\��)

        //UI�O���b�h�p�f�[�^�e�[�u��
        private DataTable _bindTable;

        // Grid��IndexBuffer�i�[�p�ϐ�
        private int _mainIndexBuffer;
        private int _detailsIndexBuffer;
        private string _targetTableBuffer;

        // Grid�ύX�t���O
        private bool _gridUpdFlg = true;

        // �A�Z���u�����
        private const string PG_ID = "PMKHN09570U";
        //private const string PG_NAME = "�L�����y�[���֘A�}�X�^";  // DEL 2011/05/06
        private const string PG_NAME = "�Ώۓ��Ӑ�ݒ�";            // ADD 2011/05/06

        // Message�֘A��`
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        # endregion

        # region -- Constructor --
		/// <summary>
        /// �Ώۓ��Ӑ�ݒ� �t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �Ώۓ��Ӑ�ݒ� �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09570UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._mainGridTitle = "�L�����y�[��";
            this._detailsGridTitle = "���Ӑ�";
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;
            this._targetTableName = "";
            this._mainGridIcon = null;
            this._detailsGridIcon = null;

            // �K�C�h�{�^���̉摜�C���[�W�ǉ�
            this.uButton_CampaignGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // �ϐ�������
            this._campaignLinkAcs = new CampaignLinkAcs();

            this._campaignLink = new CampaignLink();
            this._campaignLinkCloneList = new CampaignLink[1];

            this._totalCount = 0;
            this._mainTable = new Hashtable();
            this._detailTable = new Hashtable();
            this._detailCloneTable = new Hashtable();

            this._bindTable = new DataTable(MY_SCREEN_TABLE);

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";

            // �L���b�V�����擾
            this.GetCacheData();
		}
		# endregion

        # region -- Dispose --
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

        # region -- Main --
        /// <summary>���C������</summary>
        /// <value></value>
        /// <remarks>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</remarks>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09570UA());
        }
        # endregion

        # region -- Events --
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        # endregion
        
        # region -- Properties --
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
            get { return this._canNew; }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

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
        # endregion

        # region -- Public Methods --
        /// <summary>
        /// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �O���b�h�^�C�g�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�^�C�g�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] strRet = new string[2];
            strRet[0] = this._mainGridTitle;
            strRet[1] = this._detailsGridTitle;
            return strRet;
        }

        /// <summary>
        /// �O���b�h�A�C�R�����X�g�擾����
        /// </summary>
        /// <returns>�O���b�h�A�C�R�����X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] objRet = new Image[2];
            objRet[0] = this._mainGridIcon;
            objRet[1] = this._detailsGridIcon;
            return objRet;
        }

        /// <summary>
        /// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
        /// </summary>
        /// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
        /// </summary>
        /// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
        /// <br></br>
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
        /// <br></br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �C���{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �폜�{�^���̗L���ݒ胊�X�g�擾����
        /// </summary>
        /// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
        /// <remarks>
        /// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�\���p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // �O���b�h�\���p�f�[�^�Z�b�g��ݒ�
            bindDataSet = this.Bind_DataSet;

            // �Q�̃e�[�u�����̂̐ݒ�
            string[] strRet = new string[2];
            strRet[0] = I_CAMPAIGN_TABLE;
            strRet[1] = S_CUSTOMER_TABLE;
            tableName = strRet;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList campaignLinkList = null;

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._campaignLinkAcs.SearchAll(out campaignLinkList, this._enterpriseCode);

                this._totalCount = campaignLinkList.Count;
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        List<int> campaignCodeList = new List<int>();
                        int index = 0;
                        foreach (CampaignLink campaignLink in campaignLinkList)
                        {
                            if (!campaignCodeList.Contains(campaignLink.CampaignCode))
                            {
                                campaignCodeList.Add(campaignLink.CampaignCode);
                                // �Ώۓ��Ӑ�ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                                CampaignLinkToDataSet(campaignLink.Clone(), index);
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
                        // �T�[�`���� ���[�J�[�}�X�^�ǂݍ��ݎ��s
                        TMsgDisp.Show(
                            this, 									    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 			    // �G���[���x��
                            PG_ID,      							    // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,	        					    // �v���O��������
                            "Search", 								    // ��������
                            TMsgDisp.OPE_GET, 						    // �I�y���[�V����
                            //"�L�����y�[���֘A���̓ǂݍ��݂Ɏ��s���܂����B",  // �\�����郁�b�Z�[�W  // DEL 2011/05/06
                            "�Ώۓ��Ӑ�ݒ�}�X�^���̓ǂݍ��݂Ɏ��s���܂����B",  // �\�����郁�b�Z�[�W // ADD 2011/05/06
                            status, 								    // �X�e�[�^�X�l
                            this._campaignLinkAcs,	 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 					    // �\������{�^��
                            MessageBoxDefaultButton.Button1);		    // �����\���{�^��
                        
                        break;
                    }
            }

            // �߂�l�Z�b�g
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
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // ������
            return 9;
        }

        /// <summary>
        /// ���׃f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrModelNameU = new ArrayList();

            // ���ݕێ����Ă���Ԏ햼�̃f�[�^���N���A����
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Clear();
            this._detailTable.Clear();

            // ADD 2009/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
            // readCount�����̏ꍇ�A�����I��
            if (readCount < 0) return 0;
            // ADD 2009/03/24 �s��Ή�[12693]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<

            // �I������Ă��郁�[�J�[�f�[�^���擾����
            int guid = (int)this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[this._mainDataIndex][I_CAMPAIGN_GUID];
            CampaignLink campaignLink = (CampaignLink)this._mainTable[guid];

            // ���[�J�[�R�[�h�w�� �Ԏ햼�̌��������i�_���폜�܂ށj
            status = this._campaignLinkAcs.SearchDetail(out arrModelNameU, this._enterpriseCode, campaignLink.CampaignCode);

            this._totalCount = arrModelNameU.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �擾�����Ԏ햼�̃N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (CampaignLink wkCampaignLink in arrModelNameU)
                        {
                            // �Ԏ햼�̃N���X�f�[�^�Z�b�g�W�J����
                            CustomerToDataSet(wkCampaignLink.Clone(), index);
                            ++index;
                        }

                        // �\�[�g
                        //this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].DefaultView.Sort = S_MODELCODE + ", " + S_MODELSUBCODE + " ASC";
                        
                        break;
                    }
                default:
                    {
                        // ���׃f�[�^��������
                        TMsgDisp.Show(
                            this, 								        // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		        // �G���[���x��
                            PG_ID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,        					        // �v���O��������
                            "DetailsDataSearch", 				        // ��������
                            TMsgDisp.OPE_GET, 					        // �I�y���[�V����
                            "�Ԏ햼�̏��̓ǂݍ��݂Ɏ��s���܂����B",	// �\�����郁�b�Z�[�W
                            status, 							        // �X�e�[�^�X�l
                            this._campaignLinkAcs, 				        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				        // �\������{�^��
                            MessageBoxDefaultButton.Button1);	        // �����\���{�^��
                        
                        break;
                    }
            }

            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// ���׃l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            return 9;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            ArrayList logDelList = new ArrayList();
            CampaignLink campaignLink = new CampaignLink();

            int maxRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[i][S_CUSTOMER_GUID];
                campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();
                logDelList.Add(campaignLink);
            }


            status = this._campaignLinkAcs.LogicalDelete(ref logDelList);
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
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._campaignLinkAcs);
                        return status;
                    }
                case -2:
                    {
                        //���Ɛݒ�Ŏg�p��
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            PG_ID,
                            "���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        return status;
                    }
                default:
                    {
                        // �_���폜�����̎��s
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            PG_ID,	        					// �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							// �v���O��������
                            "Delete",							// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._campaignLinkAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
             int index = 0;
            int logDelCnt = 0;         // 0�̓��C��Grid���A0�ȊO�͏ڍ�Grid���
            // �_���폜���R�[�h��DataSet�ɔ��f
            foreach (CampaignLink wkPartsPosCodeU in logDelList)
            {
                if (logDelCnt == 0)
                {
                    index = this._mainDataIndex;
                    CampaignLinkToDataSet(wkPartsPosCodeU.Clone(), index);
                }


                CustomerToDataSet(wkPartsPosCodeU.Clone(), logDelCnt++);
            }
            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����@�\�����ׁ̈A�������B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Print()
        {
            // ����@�\�����̈ז�����
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <param name="appearanceTable">�O���b�h�O��</param>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // ���C���O���b�h
            Hashtable mainAppearanceTable = new Hashtable();

            // �폜��
            // ADD 2008/03/24 �s��Ή�[12693]���F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
            mainAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���[�J�[�R�[�h
            mainAppearanceTable.Add(I_CAMPAIGN_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000", Color.Black));
            // ���[�J�[��
            mainAppearanceTable.Add(I_CAMPAIGN_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���[�J�[���GUID
            mainAppearanceTable.Add(I_CAMPAIGN_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));


            // �T�u�O���b�h
            Hashtable detailsAppearanceTable = new Hashtable();

            // �폜��
            detailsAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // �ݒ胁�[�J�[�R�[�h
            detailsAppearanceTable.Add(S_CAMPAIGN_CODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // �Ԏ�R�[�h
            detailsAppearanceTable.Add(S_CUSTOMER_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00000000", Color.Black));
            // �Ԏ햼
            detailsAppearanceTable.Add(S_CUSTOMER_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �Ԏ���GUID
            detailsAppearanceTable.Add(S_CUSTOMER_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
        }

        # endregion

        # region -- Control Events --
        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09570UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();
        }

        /// <summary>
        /// ��ʃN���[�Y�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[������悤�Ƃ������ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09570UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";
            
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// ��ʕ\����ԕύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ��ʂ̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09570UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();
                return;
            }

            if (this._targetTableName == S_CUSTOMER_TABLE)
            {
                if (this._detailsIndexBuffer == this._detailsDataIndex)
                {
                    return;
                }
            }
            else
            {
                if (this._mainIndexBuffer == this._mainDataIndex)
                {
                    return;
                }
            }

            // ��ʏ���������
            ScreenClear();

            // ��ʕ\���^�C�}�[ON
            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// �ۑ��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            this.Ok_Button.Focus();
            if (!SaveProc())
            {
                return;
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // �V�K���[�h�̏ꍇ�͉�ʂ��I���������ɘA�����͂��\�Ƃ���B
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // ��ʂ�������
                this.ScreenClear();

                // ��ʂ��č\�z
                this.ScreenReconstruction();
                
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // Grid��IndexBuffer�i�[�p�ϐ�������
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = -2;
                this._targetTableBuffer = "";

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
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �X�V�L���t���O
            bool isUpdate = false;

            // UI��ʂ�Grid�s�����擾
            int maxRow = this._bindTable.Rows.Count;

            //�ۑ��m�F
            if (this._mainDataIndex >= 0)
            {
                // �X�V���[�h
                if (maxRow > 0)
                {
                    // UI��ʂ�Grid��1���ȏ�o�^����Ă��邱��
                    ArrayList updateList = new ArrayList();
                    ArrayList deleteList = new ArrayList();

                    // �X�V�f�[�^�̗L�����m�F
                    UpdateCompare(out updateList, out deleteList);

                    if ((updateList.Count != 0) || (deleteList.Count != 0))
                    {
                        // �X�V�^�폜���R�[�h���L��
                        isUpdate = true;
                    }
                }
            }
            else
            {
                // �V�K���[�h
                ArrayList partsList = new ArrayList();
                // ��ʏ����擾
                this.DispToCampaignLink(ref partsList);
                if (partsList.Count > 0)
                {
                    // ���Ӑ�̐ݒ�L
                    isUpdate = true;
                }
                //else if (partsList.Count == 1)
                //{
                //    // ���ʂ̐ݒ�̂�
                //    CampaignLink compPartsPosCode = new CampaignLink();
                //    ArrayList compRet = compPartsPosCode.Compare((CampaignLink)partsList[0]);
                //    if (compRet.Count > 1)
                //    {
                //        // ��ƃR�[�h�ȊO�̐ݒ荀�ڗL
                //        isUpdate = true;
                //    }
                //}
            }

            //�ŏ��Ɏ擾������ʏ��Ɣ�r
            if (isUpdate)
            {
                // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                // �ۑ��m�F
                DialogResult res = TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                    PG_ID,       						// �A�Z���u���h�c�܂��̓N���X�h�c
                    null, 								// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);	// �\������{�^��
                
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            if (!SaveProc())
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
                            this.Cancel_Button.Focus();
                            return;
                        }
                }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // Grid��IndexBuffer�i�[�p�ϐ�������
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";
            
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
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
                PG_ID,					        						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
                0,														// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,								// �\������{�^��
                MessageBoxDefaultButton.Button2);						// �����\���{�^��


            if (result == DialogResult.OK)
            {
                ArrayList deleteList = new ArrayList();
                CampaignLink campaignLink = new CampaignLink();

                // Form ����Grid�̏����擾
                int maxRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count;
                for (int i = 0; i < maxRow; i++)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[i][S_CUSTOMER_GUID];
                    campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();
                    deleteList.Add(campaignLink);
                }

                // �����폜����
                status = this._campaignLinkAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[this._mainDataIndex].Delete();
                            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Clear();

                            // ���C��Grid�Ɩ���Grid�̃e�[�u�����폜
                            int delCnt = 0;
                            foreach (CampaignLink wkPartsPosCodeU in deleteList)
                            {
                                if (delCnt == 0)
                                {
                                    // ���C��Grid�̃e�[�u��
                                    this._mainTable.Remove(wkPartsPosCodeU.CampaignCode);
                                    delCnt++;
                                }
                                
                                // ����Grid�̃e�[�u��
                                this._detailTable.Remove(wkPartsPosCodeU.FileHeaderGuid);
                            }

                            
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._campaignLinkAcs);

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._detailsIndexBuffer = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								    // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                                PG_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                PG_NAME,							    // �v���O��������
                                "Delete_Button_Click",				    // ��������
                                TMsgDisp.OPE_DELETE,				    // �I�y���[�V����
                                ERR_RDEL_MSG,						    // �\�����郁�b�Z�[�W 
                                status,								    // �X�e�[�^�X�l
                                this._campaignLinkAcs,				    // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				    // �\������{�^��
                                MessageBoxDefaultButton.Button1);	    // �����\���{�^��

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._detailsIndexBuffer = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
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
            this._detailsIndexBuffer = -2;

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
        /// <br>Note �@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList reviveList = new ArrayList();
            CampaignLink campaignLink = new CampaignLink();

            // Form ����Grid�̏����擾
            int maxRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[i][S_CUSTOMER_GUID];
                campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();
                reviveList.Add(campaignLink);
            }

            // ��������
            status = this._campaignLinkAcs.Revival(ref reviveList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._campaignLinkAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._detailsIndexBuffer = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            PG_ID,		        				  // �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							  // �v���O��������
                            "Revive_Button_Click",				  // ��������
                            TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
                            ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._campaignLinkAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._detailsIndexBuffer = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // DataSet�W�J����
            int index = 0;
            int reviveCnt = 0;

            // �ĕ`����s���̂ŁA���ݕێ����Ă��閾��Grid�f�[�^���N���A����
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Clear();
            this._detailTable.Clear();

            foreach (CampaignLink wkPartsPosCodeU in reviveList)
            {
                if (reviveCnt == 0)
                {
                    // ���C��Grid
                    index = this._mainDataIndex;
                    CampaignLinkToDataSet(wkPartsPosCodeU, index);
                }

                // ����Grid
                CustomerToDataSet(wkPartsPosCodeU, reviveCnt);
                reviveCnt++;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuffer = -2;

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
        /// �Ԏ햼�̃K�C�h�{�^�������C�x���g
        /// </summary>
        /// <param name="sender">�R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̃K�C�h�{�^���������̏������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void uButton_ModelGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // �K�C�h�N��
                int status = _campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    // ���ʃZ�b�g
                    this.tNedit_CampaignCode.SetInt(campaignSt.CampaignCode);
                    this.tEdit_CampaignName.Text = campaignSt.CampaignName;

                    // ���t�H�[�J�X
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();

            // ���[�h�ύX�\�t���O��ݒ�
            CanChangeMode = IsInsertMode();
        }

        /// <summary>
        /// �V�K���[�h�ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�V�K���[�h�ł��B<br/>
        /// <c>false</c>:�V�K���[�h�ł͂���܂���B
        /// </returns>
        private bool IsInsertMode()
        {
            return this.Mode_Label.Text.Equals(INSERT_MODE);
        }

        /// <summary>���[�h�ύX�\�t���O</summary>
        private bool _canChangeMode = false;
        /// <summary>���[�h�ύX�\�t���O���擾�܂��͐ݒ肵�܂��B</summary>
        private bool CanChangeMode
        {
            get { return _canChangeMode; }
            set { _canChangeMode = value; }
        }

        /// <summary>
        /// ���^�[���L�[�ړ��C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���^�[���L�[�������̐�����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CampaignCode":         // �L�����y�[���R�[�h
                    {
                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                        string campaignName = "";

                        if (campaignCode != 0)
                        {
                            // �L�����y�[�����̂̎擾
                            campaignName = this._campaignLinkAcs.GetCampaignName(campaignCode);

                            if (campaignName != "")
                            {
                                this.tEdit_CampaignName.Text = campaignName;

                                // �J�[�\������
                                // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                this.uGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                e.NextCtrl = null;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�Y������L�����y�[���R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                                // ���Ӑ�̃N���A
                                this.tNedit_CampaignCode.Clear();
                                this.tEdit_CampaignName.Text = "";

                                // �J�[�\������
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // ������
                            // ���Ӑ�̃N���A
                            this.tNedit_CampaignCode.Clear();
                            this.tEdit_CampaignName.Text = "";
                        }

                        break;
                    }
                case "DeleteRow_Button":            // GRID�폜�{�^��
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        this.uGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "uGrid_Customer":      // �O���b�h
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // �K�C�h�{�^���Ƀt�H�[�J�X������
                                        if (this.uGrid_Customer.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

                                            if ((this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // �Z���̃X�^�C�����{�^���ŁA�Z���̍ŏI�s�̏ꍇ
                                                if ((int)this.uGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                                                {
                                                    // �ŏI�s�̏ꍇ�A�s��ǉ�
                                                    this.tbsPartsList_AddRow();
                                                }
                                            }
                                        }

                                        // ���̃Z���ֈړ�
                                        bool moveFlg = this.MoveNextAllowEditCell(false);
                                        if (moveFlg)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        else if (!this._gridUpdFlg)
                                        {
                                            this.MovePrevAllowEditCell(false);
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        if (this.MovePrevAllowEditCell(false))
                                        {
                                            // �O���b�h���̃t�H�[�J�X����
                                            e.NextCtrl = null;
                                        }
                                        else if (e.NextCtrl.Name == "DeleteRow_Button")
                                        {
                                            // �O���b�h���ł̃t�H�[�J�X����Ɏ��s�����ꍇ
                                            e.NextCtrl = this.tNedit_CampaignCode;
                                        }

                                        break;
                                    }
                            }
                        }
                        break;
                    }
                //case "Ok_Button":
                case "Renewal_Button":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        int rowIdx = this.uGrid_Customer.Rows.Count - 1;
                                        // �A�N�e�B�u�s���ŏI�s�ɐݒ�
                                        this.uGrid_Customer.ActiveRow = this.uGrid_Customer.Rows[rowIdx];
                                        // �A�N�e�B�u�Z���𓾈Ӑ�R�[�h�ɐݒ�(�t�H�[�J�X�J�ڂ̂���)
                                        this.uGrid_Customer.ActiveCell = this.uGrid_Customer.Rows[rowIdx].Cells[MY_SCREEN_CUSTOMER_CODE];
                                        // ���Ӑ�R�[�h��ҏW���[�h�ɂ��ăt�H�[�J�X���ړ�
                                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                                        {
                                            // �K�C�h�{�^���փt�H�[�J�X�ړ�
                                            this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        // GRID�̓��Ӑ�R�[�h�փt�H�[�J�X����
                                        int rowIdx = this.uGrid_Customer.Rows.Count - 1;
                                        // �A�N�e�B�u�s���ŏI�s�ɐݒ�
                                        this.uGrid_Customer.ActiveRow = this.uGrid_Customer.Rows[rowIdx];
                                        // �A�N�e�B�u�Z���𓾈Ӑ�R�[�h�ɐݒ�(�t�H�[�J�X�J�ڂ̂���)
                                        this.uGrid_Customer.ActiveCell = this.uGrid_Customer.Rows[rowIdx].Cells[MY_SCREEN_CUSTOMER_CODE];
                                        // ���Ӑ�R�[�h��ҏW���[�h�ɂ��ăt�H�[�J�X���ړ�
                                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                                        {
                                            // �K�C�h�{�^���փt�H�[�J�X�ړ�
                                            this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                                        }
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }

            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "PartsPosName_tEdit":          // ���ʖ�
                    case "uGrid_Customer":      // �O���b�h
                        {
                            if ((this._mainDataIndex < 0) || (this._detailsDataIndex < 0))
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = tNedit_CampaignCode;
                                }
                            }
                            break;
                        }
                }
            }

            string currentCampaignCode = this.tNedit_CampaignCode.Text.Trim();

            if (CanChangeMode)
            {
                // �V�K���[�h�̏ꍇ�̂�
                if ((this._mainDataIndex < 0) || (this._detailsDataIndex < 0))
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tNedit_CampaignCode;
                    }
                }
            }
            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }

        

        # endregion

        #region -- Private Methods --
        /// <summary>
        /// �Ώۓ��Ӑ�ݒ���f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="campaignLink">�Ώۓ��Ӑ�ݒ�</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �Ώۓ��Ӑ�ݒ���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CampaignLinkToDataSet(CampaignLink campaignLink, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].NewRow();
                this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ��ɂ���
                index = this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Count - 1;
            }

            // �폜��
            if (campaignLink.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][S_DELETEDATE] = campaignLink.UpdateDateTimeJpInFormal;
            }
            
            // �L�����y�[���R�[�h
            this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][I_CAMPAIGN_CODE] = campaignLink.CampaignCode;
            
            // �L�����y�[������
            this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][I_CAMPAIGN_NAME] = this._campaignLinkAcs.GetCampaignName(campaignLink.CampaignCode);

            // �L�����y�[�����GUID
            this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][I_CAMPAIGN_GUID] = campaignLink.CampaignCode;
            
            // �n�b�V�������p��GUID�Z�b�g
            if (this._mainTable.ContainsKey(campaignLink.CampaignCode))
            {
                this._mainTable.Remove(campaignLink.CampaignCode);
            }
            this._mainTable.Add(campaignLink.CampaignCode, campaignLink);
        }

        

        /// <summary>
        /// ���Ӑ���f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="campaignLink">�Ώۓ��Ӑ�ݒ�</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �Ώۓ��Ӑ�ݒ���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CustomerToDataSet(CampaignLink campaignLink, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].NewRow();
                this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count - 1;
            }

            // �폜��
            if (campaignLink.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", campaignLink.UpdateDateTime);
            }

            // �ݒ�L�����y�[���R�[�h
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CAMPAIGN_CODE] = campaignLink.CampaignCode;

            // ���Ӑ�R�[�h
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_CODE] = campaignLink.CustomerCode;

            // ���Ӑ於
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_NAME] = GetCustomerName(campaignLink.CustomerCode);

            // ���Ӑ���GUID
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_GUID] = campaignLink.FileHeaderGuid;

            // �n�b�V�������p��GUID�Z�b�g
            if (this._detailTable.ContainsKey(campaignLink.FileHeaderGuid) == true)
            {
                this._detailTable.Remove(campaignLink.FileHeaderGuid);
            }
            this._detailTable.Add(campaignLink.FileHeaderGuid, campaignLink);
        }

        /// <summary>
        /// �Ώۓ��Ӑ�ݒ� �N���X��ʓW�J����
        /// </summary>
        /// <param name="campaignLink">�Ώۓ��Ӑ�ݒ� �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �Ώۓ��Ӑ�ݒ� �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CampaignLinkToScreen(CampaignLink[] campaignLink)
        {
            int i = 0;
            int maxRow = campaignLink.Length;
            DataRow bindRow;

            // �L�����y�[���R�[�h
            this.tNedit_CampaignCode.SetInt(campaignLink[i].CampaignCode);
            // �L�����y�[����
            this.tEdit_CampaignName.Text = this._campaignLinkAcs.GetCampaignName(campaignLink[i].CampaignCode);

            // ���Ӑ���
            for (; i < maxRow; i++)
            {
                bindRow = this._bindTable.NewRow();

                bindRow[MY_SCREEN_ID] = "";                                                         // Grid��ID(��\��)
                bindRow[MY_SCREEN_ODER] = i + 1;                                                    // �\������
                bindRow[MY_SCREEN_CUSTOMER_CODE] = campaignLink[i].CustomerCode.ToString("d08");    // ���Ӑ�R�[�h
                bindRow[MY_SCREEN_CUSTOMER_NAME] = GetCustomerName(campaignLink[i].CustomerCode);   // ���Ӑ於

                this._bindTable.Rows.Add(bindRow);
            }
        }

        /// <summary>
        /// ��ʏ��Ώۓ��Ӑ�ݒ� �N���X�i�[����
        /// </summary>
        /// <param name="campaignLinkList">�Ώۓ��Ӑ�ݒ� �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�Ώۓ��Ӑ�ݒ� �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void DispToCampaignLink(ref ArrayList campaignLinkList)
        {
            int index;
            int rowCnt = this._bindTable.Rows.Count;

            CampaignLink campaignLink;
            campaignLinkList = new ArrayList();

            for (index = 0; index < rowCnt; index++)
            {
                campaignLink = new CampaignLink();

                campaignLink.EnterpriseCode = this._enterpriseCode;                                 // ��ƃR�[�h
                campaignLink.CampaignCode = this.tNedit_CampaignCode.GetInt();                      // �L�����y�[���R�[�h

                // �����͂̓��Ӑ��SKIP
                string code = (string)this._bindTable.Rows[index][MY_SCREEN_CUSTOMER_CODE];
                if (code == "")
                {
                    continue;
                }

                // ����Grid�p�̏��擾
                campaignLink.CustomerCode = Int32.Parse(code);                                      // ���Ӑ�R�[�h
                    
                campaignLinkList.Add(campaignLink);
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // ���C���e�[�u���̗��`
            DataTable mainDt = new DataTable(I_CAMPAIGN_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            mainDt.Columns.Add(S_DELETEDATE, typeof(string));           // �폜��
            mainDt.Columns.Add(I_CAMPAIGN_CODE, typeof(int));			// �L�����y�[���R�[�h
            mainDt.Columns.Add(I_CAMPAIGN_NAME, typeof(string));		// �L�����y�[����
            mainDt.Columns.Add(I_CAMPAIGN_GUID, typeof(int));           // �L�����y�[�����GUID

            this.Bind_DataSet.Tables.Add(mainDt);

            // ���׃e�[�u���̗��`
            DataTable detailDt = new DataTable(S_CUSTOMER_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            detailDt.Columns.Add(S_DELETEDATE, typeof(string));         // �폜��
            detailDt.Columns.Add(S_CAMPAIGN_CODE, typeof(int));			// �ݒ�L�����y�[���R�[�h
            detailDt.Columns.Add(S_CUSTOMER_CODE, typeof(int));			// ���Ӑ�R�[�h
            detailDt.Columns.Add(S_CUSTOMER_NAME, typeof(string));		// ���Ӑ於
            detailDt.Columns.Add(S_CUSTOMER_GUID, typeof(Guid));        // ���Ӑ���GUID

            this.Bind_DataSet.Tables.Add(detailDt);
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �X�L�[�}�̐ݒ�
            DataTableSchemaSetting();

            // GRID�̏����ݒ�
            GridInitialSetting();
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._mainDataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
                
                // ��ʓ��͋����䏈��
                ScreenPermissionControl(INSERT_MODE);
                
                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = this._detailsDataIndex;
                this._targetTableBuffer = this._targetTableName;
                
                //�N���[���쐬
                CampaignLink campaignLink = new CampaignLink();
                this._campaignLinkCloneList = new CampaignLink[1];
                this._campaignLinkCloneList[0] = campaignLink.Clone();

                // �O���b�h�s��ǉ�
                this.tbsPartsList_AddRow();

                // �t�H�[�J�X�ݒ�
                this.tNedit_CampaignCode.Focus();
            }
            else
            {
                // �ڍ�Grid�̍s�����擾
                int rowCnt = 0;         // �s���J�E���^
                int maxRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count;
                CampaignLink[] campaignLinkList = new CampaignLink[maxRow];

                // �I���L�����y�[���̓��Ӑ�����擾
                for (; rowCnt < maxRow; rowCnt++)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[rowCnt][S_CUSTOMER_GUID];
                    campaignLinkList[rowCnt] = (CampaignLink)this._detailTable[guid];
                }

                if (campaignLinkList[0].LogicalDeleteCode == 0)
                {
                        // �X�V���[�h
                        this.Mode_Label.Text = UPDATE_MODE;

                        // ��ʓ��͋����䏈��
                        ScreenPermissionControl(UPDATE_MODE);

                        // ��ʓW�J����
                        CampaignLinkToScreen(campaignLinkList);

                        tbsPartsList_AddRow();

                        //�N���[���쐬
                        this._campaignLinkCloneList = new CampaignLink[maxRow];
                        for (int i = 0; i < maxRow; i++)
                        {
                            this._campaignLinkCloneList[i] = campaignLinkList[i].Clone();
                        }
                        
                        // �t�H�[�J�X�ݒ�
                        this.Cancel_Button.Focus();
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenPermissionControl(DELETE_MODE);

                    // ��ʓW�J����
                    CampaignLinkToScreen(campaignLinkList);

                    this.uGrid_Customer.Rows[0].Selected = false;
                    this.uGrid_Customer.ActiveCell = null;
                    this.uGrid_Customer.ActiveRow = null;
                    
                    //�N���[���쐬
                    this._campaignLinkCloneList = new CampaignLink[maxRow];
                    for (int i = 0; i < maxRow; i++)
                    {
                        this._campaignLinkCloneList[i] = campaignLinkList[i].Clone();
                    }

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                // Fream��Index/Table�o�b�t�@�ێ�
                this._mainIndexBuffer = this._mainDataIndex;
                this._detailsIndexBuffer = this._detailsDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }
        }

        /// <summary>
        /// ��ʋ����䏈��
        /// </summary>
        /// <param name="screenMode">��ʃ��[�h</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h���ɓ��́^�{�^���̋��𐧌䂵�܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // �V�K
            if (screenMode.Equals(INSERT_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;
                this.uButton_CampaignGuide.Visible = true;
                this.uButton_CampaignGuide.Enabled = true;
                this.Guid_Button.Visible = true;

                // ���͐ݒ�
                this.tNedit_CampaignCode.Enabled = true;
                this.uGrid_Customer.Enabled = true;
            }
            // �X�V
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;
                this.uButton_CampaignGuide.Visible = true;
                this.uButton_CampaignGuide.Enabled = false;
                this.Guid_Button.Visible = true;

                // ���͐ݒ�
                this.tNedit_CampaignCode.Enabled = false;
                this.uGrid_Customer.Enabled = true;
            }
            // �폜
            else if (screenMode.Equals(DELETE_MODE))
            {
                // �{�^���ݒ�
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.Renewal_Button.Visible = false;
                this.uButton_CampaignGuide.Visible = true;
                this.uButton_CampaignGuide.Enabled = false;
                this.Guid_Button.Visible = false;

                // ���͐ݒ�
                this.tNedit_CampaignCode.Enabled = false;
                this.uGrid_Customer.Enabled = false;
            }
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏��������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_CampaignCode.Clear();           // �L�����y�[���R�[�h
            this.tEdit_CampaignName.Text = "";          // �L�����y�[����

            this._bindTable.Clear();                    // Grid�s�̃N���A
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="loginID">���O�C��ID</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // �L�����y�[���R�[�h
            if (this.tNedit_CampaignCode.Text == "0" || this.tNedit_CampaignCode.Text.Trim() == "")
            {
                control = this.tNedit_CampaignCode;
                message = this.Campaign_Label.Text + "����͂��ĉ������B";
                return false;
            }
            else if (this._campaignLinkAcs.GetCampaignName(this.tNedit_CampaignCode.GetInt()) == "")
            {
                control = this.tNedit_CampaignCode;
                message = "�Y������L�����y�[���R�[�h�����݂��܂���B";
                return false;
            }

            // Grid
            if (this._bindTable.Rows.Count == 0)
            {
                control = this.uGrid_Customer;
                message = "���Ӑ�R�[�h���P���ȏ�o�^���ĉ������B";
                return false;
            }
            else if (this._bindTable.Rows.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < this._bindTable.Rows.Count; i++)
                {
                    string code = (string)this._bindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                    if (code.Trim() != "")
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    control = this.uGrid_Customer;
                    message = "���Ӑ�R�[�h���o�^����Ă��܂���B";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �Ώۓ��Ӑ�ݒ� ���o�^����
        /// </summary>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : �Ώۓ��Ӑ�ݒ� ���o�^���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";

            ArrayList updateList = new ArrayList();
            ArrayList deleteList = new ArrayList();
            
            // ��ʓ��̓`�F�b�N
            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            if (this._mainDataIndex >= 0)
            {
                // �X�V���́A�X�V�Ώۂƍ폜�Ώۂ��擾
                this.UpdateCompare(out updateList, out deleteList);

                // �폜�Ώۂ�����ΊY�����R�[�h���폜
                if (deleteList.Count != 0)
                {
                    status = this._campaignLinkAcs.Delete(deleteList);
                }
            }
            else
            {
                //�V�K�̏ꍇ�A��ʏ��������N���X�ɐݒ�
                this.DispToCampaignLink(ref updateList);
            }
            

            // �o�^�^�X�V����
            status = this._campaignLinkAcs.Write(ref updateList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            PG_ID,				        		// �A�Z���u���h�c�܂��̓N���X�h�c
                            ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��

                        this.tNedit_CampaignCode.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._campaignLinkAcs);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._detailsIndexBuffer = -2;

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
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							// �v���O��������
                            "SaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._campaignLinkAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._detailsIndexBuffer = -2;

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
            }

            // DataSet�W�J����
            int index = 0;
            
            if (this._mainDataIndex >= 0)
            {
                // �폜�\��DataSet�̍s�����擾
                int delOK = deleteList.Count - updateList.Count;

                foreach (CampaignLink campaignLink in deleteList)
                {
                    // �폜���R�[�h�𖾍�Grid��Table����폜
                    this._detailTable.Remove(campaignLink.FileHeaderGuid);
                }

                // �X�V���R�[�h��DataSet�ɔ��f
                foreach (CampaignLink campaignLink in updateList)
                {
                    // ����Grid��DataSet���X�V
                    index = this._detailsDataIndex;
                    CustomerToDataSet(campaignLink.Clone(), index);
                }
            }
            else
            {
                // ���C��Grid��DataSet�ɒǉ�
                index = this._mainTable.Count;
                CampaignLinkToDataSet(((CampaignLink)updateList[0]).Clone(), index);
            }

            return true;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            PG_ID,		        				// �A�Z���u���h�c�܂��̓N���X�h�c
                            PG_NAME,							// �v���O��������
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
        }

        #endregion

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �L�����y�[���R�[�h
            int campaignCode = tNedit_CampaignCode.GetInt();
            
            for (int i = 0; i < this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCampaignCode = (int)this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[i][I_CAMPAIGN_CODE];
                if (campaignCode == dsCampaignCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[i][I_DELETEDATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PG_ID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          //"���͂��ꂽ�R�[�h�̃L�����y�[���֘A�}�X�^���͊��ɍ폜����Ă��܂��B", // �\�����郁�b�Z�[�W   // DEL 2011/05/06
                          "���͂��ꂽ�R�[�h�̑Ώۓ��Ӑ�ݒ�}�X�^���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W   // ADD 2011/05/06
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �L�����y�[���R�[�h�A���̂̃N���A
                        tNedit_CampaignCode.Clear();
                        tEdit_CampaignName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PG_ID,                                  // �A�Z���u���h�c�܂��̓N���X�h�c
                        //"���͂��ꂽ�R�[�h�̃L�����y�[���֘A�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W  // DEL 2011/05/06
                        "���͂��ꂽ�R�[�h�̑Ώۓ��Ӑ�ݒ�}�X�^��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W            // ADD 2011/05/06
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // �ꎞ�I�ɏڍ׃e�[�u�����X�V
                                int selectedMainDataIndex = GetSelectedMainDataIndex();

                                this._mainDataIndex = i;
                                this._detailsDataIndex = 0;
                                int dummy = 0;
                                DetailsDataSearch(ref dummy, 0);

                                // ��ʍĕ`��
                                ScreenClear();
                                ScreenReconstruction();

                                // �ڍ׃e�[�u�������ɖ߂�
                                this._mainDataIndex = selectedMainDataIndex;
                                dummy = 0;
                                DetailsDataSearch(ref dummy, 0);

                                // TODO:���[�h�ύX�\�t���O�𗎂Ƃ�
                                CanChangeMode = false;
                                break;
                            }
                        case DialogResult.No:
                            {
                                // �L�����y�[���R�[�h�A���̂̃N���A
                                tNedit_CampaignCode.Clear();
                                tEdit_CampaignName.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���݁A�I������Ă��郁�C���f�[�^�̃C���f�b�N�X���擾���܂��B
        /// </summary>
        /// <returns>���݁A�I������Ă��郁�C���f�[�^�̃C���f�b�N�X</returns>
        private int GetSelectedMainDataIndex()
        {
            if (this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count.Equals(0)) return 0;

            Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[0][S_CUSTOMER_GUID];
            CampaignLink campaignLink = (CampaignLink)this._detailTable[guid];

            for (int i = 0; i < this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Count; i++)
            {
                string campaignCode = this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[i][I_CAMPAIGN_CODE].ToString();
                if (campaignLink.CampaignCode.Equals(int.Parse(campaignCode.Trim())))
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            return GetCustomerName(customerCode, false);
        }

        /// <summary>
        /// ���Ӑ於�̂��擾���܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="throwsExceptionWhenCodeIsNotFound">�Y�����链�Ӑ�R�[�h���Ȃ��ꍇ�A��O�𓊓�����t���O</param>
        /// <returns>���Ӑ於��</returns>
        /// <exception cref="ArgumentException">
        /// <c>throwsExceptionWhenCodeIsNotFound</c>��<c>true</c>�̂Ƃ��A
        /// ���Ӑ�}�X�^�ɊY�����链�Ӑ�R�[�h�����݂��Ȃ��ꍇ�A��������܂��B
        /// </exception>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br></br>
        /// </remarks>
        private string GetCustomerName(
            int customerCode,
            bool throwsExceptionWhenCodeIsNotFound
        )
        {
            string customerName = string.Empty;
            CustomerInfo customerInfo = new CustomerInfo();

            bool codeIsFound = false;
            try
            {
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        codeIsFound = true;
                        customerName = customerSearchRet.Snm.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        codeIsFound = true;
                        customerName = customerInfo.CustomerSnm.Trim();
                    }
                }
            }
            catch
            {
                customerName = string.Empty;
            }

            if (!codeIsFound && throwsExceptionWhenCodeIsNotFound)
            {
                throw new ArgumentException("customerCode(=" + customerCode.ToString() + ") is not found.");
            }

            return customerName;
        }

        /// <summary>
        /// �L���b�V�����擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�̖��̂��L���b�V�����B</br>
        /// </remarks>
        private void GetCacheData()
        {
            // ���Ӑ於�̃��X�g�擾
            this.GetCustomerNameList();

        }

        /// <summary>
        /// ���Ӑ於�̃��X�g�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂̃��X�g���擾���܂��B</br>
        /// </remarks>
        private void GetCustomerNameList()
        {
            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            this._customerList = new ArrayList();

            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                {
                    // �_���폜�f�[�^�͓ǂݍ��܂Ȃ�
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }

        /// <summary>
        /// Control.VisibleChange �C�x���g(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_VisibleChanged(object sender, System.EventArgs e)
        {
            // �A�N�e�B�u�Z���E�A�N�e�B�u�s�𖳌�
            this.uGrid_Customer.ActiveCell = null;
        }

        /// <summary>
        /// Control.KeyDown �C�x���g (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // �A�N�e�B�u�Z����null�̎��͏������s�킸�I��
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return;
            }

            // �O���b�h��Ԏ擾()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

            //�h���b�v�_�E����Ԃ̎��͏������Ȃ�(UltraGrid�̃f�t�H���g�̓����ɂ���)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ���L�[
                    case Keys.Up:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = MoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Down:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = MoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ���L�[
                    case Keys.Left:
                        {
                            // ��̃Z���ֈړ�
                            nextControl = MoveAboveCell();
                            e.Handled = true;

                            break;
                        }
                    // ���L�[
                    case Keys.Right:
                        {
                            // ���̃Z���ֈړ�
                            nextControl = MoveBelowCell();
                            e.Handled = true;

                            break;
                        }
                    case Keys.Space:
                        {
                            if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                            {
                                UltraGridCell ultraGridCell = this.uGrid_Customer.ActiveCell;
                                CellEventArgs cellEventArgs = new CellEventArgs(ultraGridCell);
                                uGrid_Customer_ClickCellButton(sender, cellEventArgs);
                            }
                            break;
                        }
                }
                
                if (nextControl != null)
                {
                    nextControl.Focus();
                }
            }
        }

        /// <summary>
        ///	ultraGrid.AfterExitEditMode �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃Z���ҏW�I���C�x���g�����B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Customer.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Customer.ActiveCell;

            // ���Ӑ�R�[�h
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                string code = cell.Value != null ? cell.Value.ToString() : string.Empty;
                this._gridUpdFlg = true;

                if ((code != "") && (int.Parse(code) != 0))
                {
                    // ���͗L
                    int customerCode = int.Parse(code);
                    string customerName = GetCustomerName(customerCode);
                    
                    if (customerName != "")
                    {
                        bool AddFlg = true;     // �ǉ��t���O
                        int maxRow = this._bindTable.Rows.Count;

                        // ���Ӑ�R�[�h�̏d���`�F�b�N
                        for (int i = 0; i < maxRow; i++)
                        {
                            if (cell.Row.Index == i)
                            {
                                // �����s����SKIP
                                continue;
                            }

                            string wkTbsPartsCode = this._bindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE].ToString();
                            if ((wkTbsPartsCode != "") && (int.Parse(wkTbsPartsCode) == customerCode))
                            {
                                // �d���R�[�h�L
                                AddFlg = false;
                                break;
                            }
                        }

                        if (AddFlg)
                        {
                            // ���Ӑ�R�[�h�̒ǉ�
                            // �I����������Cell�ɐݒ�
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = customerCode.ToString("d08");   // ���Ӑ�R�[�h
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = customerName;                   // ���Ӑ�i��

                            if ((int)cell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                            {
                                // �ŏI�s�̏ꍇ�A�s��ǉ�
                                this.tbsPartsList_AddRow();
                            }
                        }
                        else
                        {
                            // �d���G���[��\��
                            TMsgDisp.Show(
                                this,								    // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                                PG_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�I���������Ӑ�R�[�h���d�����Ă��܂��B",	    // �\�����郁�b�Z�[�W 
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				    // �\������{�^��

                            // ���Ӑ�R�[�h�A���Ӑ於���N���A
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // ���Ӑ�R�[�h
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // ���Ӑ於

                            // Grid�ύX�Ȃ�
                            this._gridUpdFlg = false;
                        }
                    }
                    else
                    {
                        // �_���폜�f�[�^�͐ݒ�s��
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���Ӑ�R�[�h [" + customerCode.ToString("d08") + "] �ɊY������f�[�^�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                        // ���Ӑ�R�[�h�A���Ӑ於���N���A
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // ���Ӑ�R�[�h
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // ���Ӑ於

                        // Grid�ύX�Ȃ�
                        this._gridUpdFlg = false;
                    }
                }
                else
                {
                    // ������
                    // ���Ӑ�R�[�h�A���Ӑ於���N���A
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // ���Ӑ�R�[�h
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // ���Ӑ於
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress �C�x���g(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̃L�[�����C�x���g�����B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Customer.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Customer.ActiveCell;

            // ���Ӑ�R�[�h�̓��͌����`�F�b�N
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z�������̃Z���Ɉړ����܂��B</br>
        /// <br></br>
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

            // �ŉ��i�Z���̎�
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
            {
                // �ۑ��{�^���ֈړ�
                // --- CHG 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                //return this.Ok_Button;
                return this.Renewal_Button;
                // --- CHG 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
            }
            // �ŉ��i�Z���łȂ���
            else
            {
                // �Z���ړ��O�A�N�e�B�u�Z���̃C���f�b�N�X
                int prevCol = this.uGrid_Customer.ActiveCell.Column.Index;
                int prevRow = this.uGrid_Customer.ActiveCell.Row.Index;

                // ���̃Z���Ɉړ�
                performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

                // �Z�����ړ����Ă��Ȃ���
                if ((prevCol == this.uGrid_Customer.ActiveCell.Column.Index) &&
                    (prevRow == this.uGrid_Customer.ActiveCell.Row.Index))
                {
                    // �ۑ��{�^���ֈړ�
                    // --- CHG 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    //return this.Ok_Button;
                    return this.Renewal_Button;
                    // --- CHG 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
                }
                // �Z�����ړ����Ă�
                else
                {
                    if (performActionResult)
                    {
                        if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        }
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// ��̃Z���ֈړ�����
        /// </summary>
        /// <returns>���̃R���g���[��</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�N�e�B�u�Z������̃Z���Ɉړ����܂��B</br>
        /// <br></br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // �A�N�e�B�u�Z����null
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return null;
            }

            // �O���b�h��Ԏ擾
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

            // �ŏ�i�Z���̎�
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst)
            {
                // �ړ����Ȃ�
                //return null;
                // �L�����y�[���R�[�h�ֈړ�
                return this.tNedit_CampaignCode;
            }
            // �őO�Z���łȂ���
            else
            {
                // ��̃Z���Ɉړ�
                performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                if (performActionResult)
                {
                    if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	���̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// <br></br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Customer.ActiveCell != null))
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
                            int rowIdx = this.uGrid_Customer.ActiveCell.Row.Index;
                            if ((this._bindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "") &&
                                (this._gridUpdFlg))
                            {
                                // ���Ӑ�R�[�h�������͂̏ꍇ(���Ӑ�R�[�h�擾���s���͏���)
                                break;
                            }
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Prev�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Prev�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// Note			:	�O�̓��͉\�ȃZ���Ƀt�H�[�J�X���ړ����鏈�����s���܂��B<br />
        /// <br></br>
        /// </remarks>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Customer.ActiveCell != null))
            {
                if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }
            else
            {
                while (!moved)
                {
                    performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (performActionResult)
                    {
                        if ((this.uGrid_Customer.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Customer.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else if (this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button)
                        {
                            // �A�N�e�B�u�Z�����{�^��
                            moved = false;
                            int rowIdx = this.uGrid_Customer.ActiveCell.Row.Index;
                            if (this._bindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                            {
                                // ���Ӑ�R�[�h�������͂̏ꍇ
                                break;
                            }
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (moved)
            {
                this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            return performActionResult;
        }

        /// <summary>
        ///	ultraGrid.Click �C�x���g(Cell Button)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID��Cell Button���N���b�N�C�x���g�����B</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_ClickCellButton(object sender, CellEventArgs e)
        {
           
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._bindTable.Rows.Count;

                // ���Ӑ�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    string code = (string)this._bindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE];
                    if (code == "")
                    {
                        continue;
                    }

                    int customerCode = Int32.Parse(code);
                    if (customerCode == _customerCode)
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // �I����������Cell�ɐݒ�
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = _customerCode.ToString("d08");    // ���Ӑ�R�[�h
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = _customerName;                    // ���Ӑ於

                    if ((int)e.Cell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                    {
                        // �ŏI�s�̏ꍇ�A�s��ǉ�
                        this.tbsPartsList_AddRow();
                    }

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.MoveNextAllowEditCell(false);
                }
                else
                {
                    // �d���G���[��\��
                    TMsgDisp.Show(
                        this,								    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                        PG_ID,      						    // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�I���������Ӑ�R�[�h���d�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				    // �\������{�^��

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void DeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.uGrid_Customer.Rows.Count < 1)
            {
                // �f�o�b�O�p
                this.tbsPartsList_AddRow();
            }

            if (this.uGrid_Customer.ActiveRow == null)
            {
                // �폜����s�����I��
                message = "�폜���链�Ӑ�R�[�h��I�����ĉ������B";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.uGrid_Customer.Focus();
            }
            else if (this.uGrid_Customer.Rows.Count == 1)
            {
                // Grid�̍s����1�s�̏ꍇ�͍폜�s��
                message = "�S�Ă̓��Ӑ���폜�͂ł��܂���";

                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.uGrid_Customer.Focus();
            }
            else
            {
                // UI��ʂ�Grid����I���s���폜
                // �I���s��index���擾
                int delIndex = (int)this.uGrid_Customer.ActiveRow.Cells[MY_SCREEN_ODER].Value - 1;

                // �I���s�̍폜
                this.uGrid_Customer.ActiveRow.Delete();

                // �폜���Grid�s�����擾
                int maxRow = this._bindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // �폜�����s�ȍ~�̕\�����ʂ��X�V����
                    this._bindTable.Rows[index][MY_SCREEN_ODER] = index + 1;
                }
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Guid_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Guid_Button_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // �ǉ��t���O
                int maxRow = this._bindTable.Rows.Count;

                // ���Ӑ�R�[�h�̏d���`�F�b�N
                for (int i = 0; i < maxRow; i++)
                {
                    string code = this._bindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE].ToString();
                    if ((code != "") && (int.Parse(code) == _customerCode))
                    {
                        // �d���R�[�h�L
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    int lastRow = this._bindTable.Rows.Count - 1;

                    if (this._bindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                    {
                        // �ŏI�s����
                        this._bindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE] = _customerCode.ToString("d08");
                        this._bindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_NAME] = _customerName;
                    }
                    else
                    {
                        // �K�C�h�őI���������Ӑ�R�[�h��ǉ�
                        DataRow bindRow;

                        bindRow = this._bindTable.NewRow();

                        // ���Ӑ����Grid�ɒǉ�
                        bindRow[MY_SCREEN_ID] = "";
                        bindRow[MY_SCREEN_ODER] = this._bindTable.Rows.Count + 1;
                        bindRow[MY_SCREEN_CUSTOMER_CODE] = _customerCode.ToString("d08");
                        bindRow[MY_SCREEN_CUSTOMER_NAME] = _customerName;

                        this._bindTable.Rows.Add(bindRow);
                    }

                    // �V�K�s��ǉ�
                    this.tbsPartsList_AddRow();

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    // �d���G���[��\��
                    string message = "�I���������Ӑ�R�[�h�͑I���ςł��B";

                    TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                        PG_ID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message,							// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��

                    ((Control)sender).Focus();
                }
            }           
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// �O���b�h�o�C���h����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �z�񍀖ڂ��O���b�h�փo�C���h���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void DataTableSchemaSetting()
        {
            _bindTable.Columns.Clear();

            // �X�L�[�}�̐ݒ�
            _bindTable.Columns.Add(MY_SCREEN_ID, typeof(string));
            _bindTable.Columns.Add(MY_SCREEN_ODER, typeof(int));
            _bindTable.Columns.Add(MY_SCREEN_CUSTOMER_CODE, typeof(string));
            _bindTable.Columns.Add(MY_SCREEN_GUID, typeof(Button));
            _bindTable.Columns[MY_SCREEN_GUID].Caption = "";
            _bindTable.Columns.Add(MY_SCREEN_CUSTOMER_NAME, typeof(string));
        }

        /// <summary>
        ///	UI��ʂ�GRID�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�̏����ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // �f�[�^�\�[�X�֒ǉ�
            this.uGrid_Customer.DataSource = _bindTable;

            // �O���b�h�̔w�i�F
            this.uGrid_Customer.DisplayLayout.Appearance.BackColor = Color.White;
            this.uGrid_Customer.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.uGrid_Customer.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �s�̒ǉ��s��
            this.uGrid_Customer.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // �s�̃T�C�Y�ύX�s��
            this.uGrid_Customer.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // �s�̍폜�s��
            this.uGrid_Customer.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // ��̈ړ��s��
            this.uGrid_Customer.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            this.uGrid_Customer.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // ��̌����s��
            this.uGrid_Customer.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // �t�B���^�̎g�p�s��
            this.uGrid_Customer.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            
            // �^�C�g���̊O�ϐݒ�
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // �O���b�h�̑I����@��ݒ�i�Z���P�̂̑I���̂݋��j
            this.uGrid_Customer.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Customer.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // �݂��Ⴂ�̍s�̐F��ύX
            this.uGrid_Customer.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�\������
            this.uGrid_Customer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            
            this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.uGrid_Customer.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid_Customer.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            
            // �uID�v�͕ҏW�s�i�Œ荀�ڂƂ��Đݒ�j
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;

            // ���Ӑ�R�[�h��̐ݒ�
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellActivation = Activation.AllowEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].TabStop = true;

            // �K�C�h�{�^���̐ݒ�
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].TabStop = true;

            // BL�i����̐ݒ�
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].CellActivation = Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].TabStop = false;

            //�������\����
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ID].Hidden = true;

            // �Z���̕��̐ݒ�
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width = 50;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].Width = 100;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Width = 20;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].Width = 380;

            // �I���s�̊O�ϐݒ�
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // �A�N�e�B�u�s�̊O�ϐݒ�
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // �s�Z���N�^�̊O�ϐݒ�
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // �r���̐F��ύX
            this.uGrid_Customer.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
        }

        /// <summary>
        ///	Grid �V�K�s�̒ǉ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRID�ɐV�K�s��ǉ����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void tbsPartsList_AddRow()
        {
            if (this._bindTable.Rows.Count == 99)
            {
                // MAX99�s�Ƃ���
                return;
            }

            // �K�C�h�őI���������Ӑ�R�[�h��ǉ�
            DataRow bindRow;

            bindRow = this._bindTable.NewRow();

            // ���Ӑ����Grid�ɒǉ�
            bindRow[MY_SCREEN_ID] = "";
            bindRow[MY_SCREEN_ODER] = this._bindTable.Rows.Count + 1;
            bindRow[MY_SCREEN_CUSTOMER_CODE] = "";
            bindRow[MY_SCREEN_CUSTOMER_NAME] = "";

            this._bindTable.Rows.Add(bindRow);
        }

        /// <summary>
        /// �X�V�O��̃f�[�^��r�ƍX�V�Ώۊi�[����
        /// </summary>
        /// <param name="updateList">�X�V�Ώۃ��R�[�h���i�[</param>
        /// <param name="deleteList">�폜�Ώۃ��R�[�h���i�[</param>
        /// <remarks>
        /// <br>Note       : �X�V�O��̃f�[�^���r���čX�V�^�폜�Ώۃf�[�^���i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void UpdateCompare(out ArrayList updateList, out ArrayList deleteList)
        {
            updateList = new ArrayList();
            deleteList = new ArrayList();

            CampaignLink campaignLink;
            
            // Form ����Grid����UI��ʂ�Grid���擾���Ĕ�r
            int index;
            int detailRowCnt = this._detailTable.Count;             // ����Grid�̍s��
            int uiGridRowCnt = this._bindTable.Rows.Count;          // UI��ʂ�Grid�s��

            // ����Grid���̍s�������r
            for (index = 0; index < detailRowCnt; index++)
            {
                // ����Grid�����擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_GUID];
                campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();

                if (index >= uiGridRowCnt)
                {
                    // ����Grid�s����UI��ʂ�Grid�s���ȏ�̏ꍇ�̓��[�v�𔲂���
                    break;
                }

                // UI��ʂ�Grid���瓾�Ӑ�R�[�h���擾
                string code = (string)this._bindTable.Rows[index][MY_SCREEN_CUSTOMER_CODE];
                int customerCode = 0;
                if (code != "")
                {
                    customerCode = Int32.Parse(code);
                }

                if (campaignLink.CustomerCode != customerCode)
                {
                    // ���Ӑ�R�[�h���s��v�̏ꍇ�A����Grid�����폜�Ώۂɒǉ�
                    deleteList.Add(campaignLink);

                    if (customerCode != 0)
                    {
                        // ��L�[���ς��̂ŁAUI��ʂ�Grid���͐V�K�ǉ��ƂȂ�
                        campaignLink = new CampaignLink();
                        campaignLink.EnterpriseCode = this._enterpriseCode;                 // ��ƃR�[�h
                        campaignLink.CampaignCode = this.tNedit_CampaignCode.GetInt();      // �L�����y�[���R�[�h
                        campaignLink.CustomerCode = customerCode;                           // ���Ӑ�R�[�h
                        updateList.Add(campaignLink);
                    }
                }
            }

            if (detailRowCnt < uiGridRowCnt)
            {
                // ����Grid�̍s�����UI��ʂ�Grid�s��������
                for (index = detailRowCnt; index < uiGridRowCnt; index++)
                {
                    string code = (string)this._bindTable.Rows[index][MY_SCREEN_CUSTOMER_CODE];
                    int customerCode = 0;
                    if (code == "")
                    {
                        // ���Ӑ�R�[�h�����͂̍s��SKIP
                        continue;
                    }
                    else
                    {
                        customerCode = Int32.Parse(code);
                    }

                    // �V�K�ǉ��Ƃ��čX�V�Ώۂɒǉ�
                    campaignLink = new CampaignLink();
                    campaignLink.EnterpriseCode = this._enterpriseCode;                     // ��ƃR�[�h
                    campaignLink.CampaignCode = this.tNedit_CampaignCode.GetInt();          // �L�����y�[���R�[�h
                    campaignLink.CustomerCode = customerCode;                               // ���Ӑ�R�[�h
                    updateList.Add(campaignLink);
                }
            }
            else if (uiGridRowCnt < detailRowCnt)
            {
                // ����Grid�̍s�����UI��ʂ�Grid�s�������Ȃ�
                for (index = uiGridRowCnt; index < detailRowCnt; index++)
                {
                    // �폜�Ώۂɒǉ�
                    Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_GUID];
                    campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();
                    deleteList.Add(campaignLink);
                }
            }
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <param name="NumberFlg">���l���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// Note			:	�����ꂽ�L�[�����l�̂ݗL���ɂ��鏈�����s���܂��B<br />
        /// <br></br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }

            // �����ꂽ�L�[�����l�ȊO�A�����l�ȊO���͕s��
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                // �}�C�i�X(�����_)�����͉\���H
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                // �����_�ȉ�������0���H
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // �����_�����ɑ��݂��邩�H
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // �����_�����ɑ��݂��邩�H
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // �����������͉\�����ȏ�ŁA�J�[�\���ʒu�������_�ȍ~
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // �������̌��������͉\�����𒴂���
                        return false;
                    }
                }
                else
                {
                    // �����_������O��ɐ������̌���������
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart) + key
                       + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if (_strResult.Contains("."))
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else if ((_strResult[0] == '-') && (_strResult.Contains(".")))
                {
                    if (_strResult.Length > (keta + 2))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            _customerCode = 0;
            _customerName = "";

            if (customerSearchRet == null)
            {
                return;
            }

            // ���Ӑ�R�[�h
            _customerCode = customerSearchRet.CustomerCode;

            // ���Ӑ於��
            _customerName = customerSearchRet.Snm.Trim();
        }

        /// <summary>
        /// �ŐV��񏈗�
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // �ŐV���擾
            GetCacheData();
            this._campaignLinkAcs.Renewal();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PG_ID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
    }
}
