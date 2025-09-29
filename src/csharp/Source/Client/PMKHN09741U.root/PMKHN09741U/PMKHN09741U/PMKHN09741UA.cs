//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �]�ƈ����[���ݒ�}�X�^
// �v���O�����T�v   : �]�ƈ����[���ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�ˁ@�L��
// �� �� ��  2013/02/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�ˁ@�L��
// �� �� ��  2013/02/25  �C�����e : �V�X�e���e�X�g��Q��127�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �]�ƈ����[���ݒ�}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �]�ƈ����[���ݒ�}�X�^���s���܂��B
    ///                   IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// </remarks>
    public class PMKHN09741UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
    {
        #region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel Employee_uLabel;
        private Infragistics.Win.Misc.UltraLabel RoleGroup_uLabel;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton uButton_RoleGroupGuide;
        private Infragistics.Win.Misc.UltraButton uButton_EmployeeGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_RoleGroupName;
        private Infragistics.Win.Misc.UltraLabel uLabel_EmployeeName;
        private TNedit tNedit_EmployeeCode;
        private TNedit tNedit_RoleGroupCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        #endregion

        #region -- Constructor --
        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �]�ƈ����[���ݒ�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09741UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;
            this._targetTableName = "";

            //  ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._detailsDataIndex = -1;
            this._employeeRoleStAcs = new EmployeeRoleStAcs();
            this._totalCount = 0;
            this._employeeRoleStTable = new Hashtable();
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ���t�擾���i
            this._dateGetAcs = DateGetAcs.GetInstance();
        }
        #endregion

        private System.ComponentModel.IContainer components;

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

        #region -- Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09741UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Employee_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RoleGroup_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.uButton_EmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_RoleGroupGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_EmployeeName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_RoleGroupName = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_EmployeeCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_RoleGroupCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_RoleGroupCode)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(621, 133);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(494, 133);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 5;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 196);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(759, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance11;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(635, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Employee_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Employee_uLabel.Appearance = appearance4;
            this.Employee_uLabel.Location = new System.Drawing.Point(16, 44);
            this.Employee_uLabel.Name = "Employee_uLabel";
            this.Employee_uLabel.Size = new System.Drawing.Size(123, 24);
            this.Employee_uLabel.TabIndex = 171;
            this.Employee_uLabel.Text = "�]�ƈ�";
            // 
            // RoleGroup_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.RoleGroup_uLabel.Appearance = appearance22;
            this.RoleGroup_uLabel.Location = new System.Drawing.Point(16, 74);
            this.RoleGroup_uLabel.Name = "RoleGroup_uLabel";
            this.RoleGroup_uLabel.Size = new System.Drawing.Size(123, 24);
            this.RoleGroup_uLabel.TabIndex = 179;
            this.RoleGroup_uLabel.Text = "���[���O���[�v";
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
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
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
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(493, 133);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 5;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(365, 133);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(364, 133);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 4;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // uButton_EmployeeGuide
            // 
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EmployeeGuide.Appearance = appearance6;
            this.uButton_EmployeeGuide.Location = new System.Drawing.Point(227, 45);
            this.uButton_EmployeeGuide.Name = "uButton_EmployeeGuide";
            this.uButton_EmployeeGuide.Size = new System.Drawing.Size(24, 23);
            this.uButton_EmployeeGuide.TabIndex = 1;
            this.uButton_EmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EmployeeGuide.Click += new System.EventHandler(this.uButton_EmployeeGuide_Click);
            // 
            // uButton_RoleGroupGuide
            // 
            appearance127.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance127.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_RoleGroupGuide.Appearance = appearance127;
            this.uButton_RoleGroupGuide.Location = new System.Drawing.Point(227, 75);
            this.uButton_RoleGroupGuide.Name = "uButton_RoleGroupGuide";
            this.uButton_RoleGroupGuide.Size = new System.Drawing.Size(24, 23);
            this.uButton_RoleGroupGuide.TabIndex = 3;
            this.uButton_RoleGroupGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_RoleGroupGuide.Click += new System.EventHandler(this.uButton_RoleGroupGuide_Click);
            // 
            // uLabel_EmployeeName
            // 
            appearance7.BackColor = System.Drawing.Color.Gainsboro;
            appearance7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.uLabel_EmployeeName.Appearance = appearance7;
            this.uLabel_EmployeeName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_EmployeeName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_EmployeeName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_EmployeeName.Location = new System.Drawing.Point(257, 44);
            this.uLabel_EmployeeName.Name = "uLabel_EmployeeName";
            this.uLabel_EmployeeName.Size = new System.Drawing.Size(413, 24);
            this.uLabel_EmployeeName.TabIndex = 1307;
            this.uLabel_EmployeeName.WrapText = false;
            // 
            // uLabel_RoleGroupName
            // 
            appearance1.BackColor = System.Drawing.Color.Gainsboro;
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.uLabel_RoleGroupName.Appearance = appearance1;
            this.uLabel_RoleGroupName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_RoleGroupName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_RoleGroupName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_RoleGroupName.Location = new System.Drawing.Point(257, 74);
            this.uLabel_RoleGroupName.Name = "uLabel_RoleGroupName";
            this.uLabel_RoleGroupName.Size = new System.Drawing.Size(413, 24);
            this.uLabel_RoleGroupName.TabIndex = 1307;
            this.uLabel_RoleGroupName.WrapText = false;
            // 
            // tNedit_EmployeeCode
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.tNedit_EmployeeCode.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.tNedit_EmployeeCode.Appearance = appearance3;
            this.tNedit_EmployeeCode.AutoSelect = true;
            this.tNedit_EmployeeCode.AutoSize = false;
            this.tNedit_EmployeeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_EmployeeCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_EmployeeCode.DataText = "";
            this.tNedit_EmployeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_EmployeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_EmployeeCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.tNedit_EmployeeCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_EmployeeCode.Location = new System.Drawing.Point(145, 44);
            this.tNedit_EmployeeCode.MaxLength = 4;
            this.tNedit_EmployeeCode.Name = "tNedit_EmployeeCode";
            this.tNedit_EmployeeCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_EmployeeCode.Size = new System.Drawing.Size(76, 24);
            this.tNedit_EmployeeCode.TabIndex = 0;
            // 
            // tNedit_RoleGroupCode
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.TextHAlignAsString = "Right";
            this.tNedit_RoleGroupCode.ActiveAppearance = appearance26;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance38.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Right";
            this.tNedit_RoleGroupCode.Appearance = appearance38;
            this.tNedit_RoleGroupCode.AutoSelect = true;
            this.tNedit_RoleGroupCode.AutoSize = false;
            this.tNedit_RoleGroupCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_RoleGroupCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_RoleGroupCode.DataText = "";
            this.tNedit_RoleGroupCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_RoleGroupCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_RoleGroupCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.tNedit_RoleGroupCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_RoleGroupCode.Location = new System.Drawing.Point(145, 74);
            this.tNedit_RoleGroupCode.MaxLength = 4;
            this.tNedit_RoleGroupCode.Name = "tNedit_RoleGroupCode";
            this.tNedit_RoleGroupCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_RoleGroupCode.Size = new System.Drawing.Size(76, 24);
            this.tNedit_RoleGroupCode.TabIndex = 2;
            // 
            // ultraLabel1
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance10;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(16, 11);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(417, 24);
            this.ultraLabel1.TabIndex = 171;
            this.ultraLabel1.Text = "�]�ƈ��R�[�h�Ƀ[������͂���Ƌ��ʐݒ�ɂȂ�܂�";
            // 
            // PMKHN09741UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(759, 219);
            this.Controls.Add(this.tNedit_RoleGroupCode);
            this.Controls.Add(this.tNedit_EmployeeCode);
            this.Controls.Add(this.uLabel_RoleGroupName);
            this.Controls.Add(this.uLabel_EmployeeName);
            this.Controls.Add(this.uButton_RoleGroupGuide);
            this.Controls.Add(this.uButton_EmployeeGuide);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.RoleGroup_uLabel);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.Employee_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09741UA";
            this.Text = "�]�ƈ����[���ݒ�";
            this.Load += new System.EventHandler(this.PMKHN09741UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09741UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09741UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_RoleGroupCode)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region -- Events --
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        // �]�ƈ����[���}�X�^�A�N�Z�X�N���X
        private EmployeeRoleStAcs _employeeRoleStAcs;
        private Hashtable _employeeRoleStTable;

        // �]�ƈ��}�X�^�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs;
        private Hashtable _employeeTb = null;

        // ���[���O���[�v���̃}�X�^�A�N�Z�X�N���X
        private RoleGroupNameStAcs _roleGroupNameStAcs;
        private Hashtable _roleGroupNameStTable;

        private SecInfoAcs _secInfoAcs = new SecInfoAcs();

        private int _totalCount;
        private string _enterpriseCode;

        // ���t�擾���i
        private DateGetAcs _dateGetAcs;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private int _detailsDataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;
        private MGridDisplayLayout _defaultGridDisplayLayout;
        private string _targetTableName;
        private ArrayList retList = null;
        private string _detailsEmployeeCode = null;

        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        private const string PROGRAM_ID = "PMKHN09741U";    // �v���O����ID

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_MAIN_TABLE = "VIEW_MAIN_TABLE";
        private const string VIEW_DETAIL_TABLE = "VIEW_DETAIL_TABLE";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const String VIEW_MAIN_TITLE = "�]�ƈ�";
        private const string VIEW_EMPLOYEE_CODE = "�]�ƈ��R�[�h";
        private const string VIEW_EMPLOYEE_NAME = "�]�ƈ�����";

        private const string VIEW_DETAIL_TITLE = "���[���O���[�v";
        private const string VIEW_DELETE_DATE = "�폜��";
        private const string VIEW_ROLEGROUP_CODE = "���[���O���[�v�R�[�h";
        private const string VIEW_ROLEGROUP_NAME = "���[���O���[�v����";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string DELETE_MODE = "�폜���[�h";
        private const string VIEW_MODE = "�Q�ƃ��[�h";

        // ���̓`�F�b�N
        private const string ct_InputError = "�̓��͂��s���ł�";
        private const string ct_NoInput = "����͂��ĉ�����";

        private const string ct_ZERO_NAME = "���ʐݒ�";

        #endregion

        #region -- Main --
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09741UA());
        }
        # endregion

        #region -- Properties --
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
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

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
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
        #endregion

        #region -- Public Methods --
        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �擪����w�茏�����̃f�[�^���������A</br>
        /// <br>              ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            retList = null;

            // --- DEL 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��127 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Clear();
            //this._employeeRoleStTable.Clear();
            // --- DEL 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��127 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // �S����
            status = this._employeeRoleStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        string Key = "";

                        // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��127 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        bool viewFlg = false;

                        if (this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Count > 0)
                        {
                            foreach (EmployeeRoleSt employeeRoleSt in retList)
                            {
                                if (Key != employeeRoleSt.EmployeeCode.Trim())
                                {
                                    // �]�ƈ��̍ĕ\�����K�v���`�F�b�N
                                    if (this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[index][VIEW_EMPLOYEE_CODE].ToString() != employeeRoleSt.EmployeeCode)
                                    {
                                        viewFlg = true;
                                        break;
                                    }
                                    Key = employeeRoleSt.EmployeeCode.Trim();
                                    if (this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Count > index) ++index;
                                }
                            }
                            if (this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Count > index) viewFlg = true;
                        }
                        else
                        {
                            viewFlg = true;
                        }

                        if (!viewFlg) break;

                        index = 0;
                        Key = "";

                        this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Clear();
                        this._employeeRoleStTable.Clear();
                        // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��127 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        foreach (EmployeeRoleSt employeeRoleSt in retList)
                        {
                            if (employeeRoleSt.EmployeeCode.Trim() == "0000") employeeRoleSt.EmployeeName = ct_ZERO_NAME;
                            if (Key != employeeRoleSt.EmployeeCode.Trim())
                            {
                                // �]�ƈ����[���ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                                EmployeeRoleStToMainDataSet(employeeRoleSt.Clone(), index);
                                Key = employeeRoleSt.EmployeeCode.Trim();
                            }
                            ++index;
                        }
                        break;
                    }

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��127 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Clear();
                        this._employeeRoleStTable.Clear();
                        // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��127 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        break;
                    }

                default:
                    {
                        // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��127 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Clear();
                        this._employeeRoleStTable.Clear();
                        // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��127 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,            // �G���[���x��
                            PROGRAM_ID,                             // �A�Z���u��ID
                            this.Text,                              // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                                 // �X�e�[�^�X�l
                            this._employeeRoleStAcs,               // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                   // �\������{�^��
                            MessageBoxDefaultButton.Button1);       // �����\���{�^��

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
        /// <br>Note        : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
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
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
            EmployeeRoleSt employeeRoleSt = (EmployeeRoleSt)this._employeeRoleStTable[guid];

            int status;

            // �]�ƈ����[���ݒ���̘_���폜����
            status = this._employeeRoleStAcs.LogicalDelete(ref employeeRoleSt);
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
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,                          // �v���O��������
                            "Delete",                           // ��������
                            TMsgDisp.OPE_HIDE,                  // �I�y���[�V����
                            "�폜�Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._employeeRoleStAcs,           // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        return status;
                    }
            }

            int dummy = 0;
            this.Search(ref dummy, 0);

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br></br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <param name="appearanceTable">�O���b�h�O��</param>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // ���C���O���b�h
            Hashtable mainAppearanceTable = new Hashtable();

            // �]�ƈ��R�[�h
            mainAppearanceTable.Add(VIEW_EMPLOYEE_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �]�ƈ�����
            mainAppearanceTable.Add(VIEW_EMPLOYEE_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // �T�u�O���b�h
            Hashtable detailsAppearanceTable = new Hashtable();

            // �폜��
            detailsAppearanceTable.Add(VIEW_DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���[���O���[�v�R�[�h
            detailsAppearanceTable.Add(VIEW_ROLEGROUP_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[���O���[�v����
            detailsAppearanceTable.Add(VIEW_ROLEGROUP_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // Guid
            detailsAppearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
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
            strRet[0] = VIEW_MAIN_TITLE;
            strRet[1] = VIEW_DETAIL_TITLE;
            return strRet;
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
            strRet[0] = VIEW_MAIN_TABLE;
            strRet[1] = VIEW_DETAIL_TABLE;
            tableName = strRet;
        }

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
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
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
            objRet[0] = null;
            objRet[1] = null;
            return objRet;
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
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
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
            this._dataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// ���׃f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;

            this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows.Clear();
            this._employeeRoleStTable.Clear();

            int index = 0;

            if (this._dataIndex < 0)
            {
                _detailsEmployeeCode = null;
                return status;
            }

            _detailsEmployeeCode = ((string)this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[this._dataIndex][VIEW_EMPLOYEE_CODE]).Trim();

            foreach (EmployeeRoleSt employeeRoleSt in retList)
            {
                if (_detailsEmployeeCode == employeeRoleSt.EmployeeCode.Trim())
                {
                    // �]�ƈ����[���ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                    EmployeeRoleStToDetailDataSet(employeeRoleSt.Clone(), index);
                }
                ++index;
            }

            return status;
        }

        /// <summary>
        /// ���׃l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            return 9;
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

        #region -- Private Methods --
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                // �]�ƈ��O���b�h�ŐV�K�{�^������
                EmployeeRoleSt employeeRoleSt = new EmployeeRoleSt();

                this._indexBuf = this._dataIndex;

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.tNedit_EmployeeCode.Focus();
            }
            else if (this._detailsDataIndex < 0)
            {
                // ���[���O���[�v�O���b�h�ŐV�K�{�^������
                EmployeeRoleSt employeeRoleSt = new EmployeeRoleSt();

                this._indexBuf = this._detailsDataIndex;

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                this.tNedit_EmployeeCode.Enabled = false;
                this.uButton_EmployeeGuide.Enabled = false;

                // �]�ƈ��R�[�h
                this.tNedit_EmployeeCode.DataText = (string)this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[DataIndex][VIEW_EMPLOYEE_CODE];
                this.uLabel_EmployeeName.Text = (string)this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[DataIndex][VIEW_EMPLOYEE_NAME];

                // �t�H�[�J�X�ݒ�
                this.tNedit_RoleGroupCode.Focus();
            }
            else
                {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
                EmployeeRoleSt employeeRoleSt = (EmployeeRoleSt)this._employeeRoleStTable[guid];

                // �]�ƈ����[���ݒ�N���X��ʓW�J����
                EmployeeRoleStToScreen(employeeRoleSt);

                if (employeeRoleSt.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = VIEW_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(VIEW_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Cancel_Button.Focus();
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
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
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = false; 
                        
                        this.tNedit_EmployeeCode.Enabled = true;
                        this.tNedit_RoleGroupCode.Enabled = true;
                        this.uButton_EmployeeGuide.Enabled = true;
                        this.uButton_RoleGroupGuide.Enabled = true;

                        break;
                    }
                case VIEW_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = false;

                        this.tNedit_RoleGroupCode.Enabled = false;
                        this.tNedit_EmployeeCode.Enabled = false;
                        this.uButton_EmployeeGuide.Enabled = false;
                        this.uButton_RoleGroupGuide.Enabled = false;

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;

                        this.tNedit_RoleGroupCode.Enabled = false;
                        this.tNedit_EmployeeCode.Enabled = false;
                        this.uButton_EmployeeGuide.Enabled = false;
                        this.uButton_RoleGroupGuide.Enabled = false;

                        break;
                    }
            }
        }

        /// <summary>
        /// �]�ƈ����[���ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="employeeRoleSt">�]�ƈ����[���ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void EmployeeRoleStToMainDataSet(EmployeeRoleSt employeeRoleSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Count - 1;
            }

            // �]�ƈ��R�[�h
            this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[index][VIEW_EMPLOYEE_CODE] = employeeRoleSt.EmployeeCode;

            // �]�ƈ�����
            this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[index][VIEW_EMPLOYEE_NAME] = employeeRoleSt.EmployeeName;
        }

        /// <summary>
        /// �]�ƈ����[���ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="employeeRoleSt">�]�ƈ����[���ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void EmployeeRoleStToDetailDataSet(EmployeeRoleSt employeeRoleSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows.Count - 1;
            }

            if (employeeRoleSt.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[index][VIEW_DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[index][VIEW_DELETE_DATE] = employeeRoleSt.UpdateDateTimeJpInFormal;
            }

            // ���[���O���[�v�R�[�h
            this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[index][VIEW_ROLEGROUP_CODE] = employeeRoleSt.RoleGroupCode;

            // ���[���O���[�v����
            this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[index][VIEW_ROLEGROUP_NAME] = employeeRoleSt.RoleGroupName;

            // Guid
            this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = employeeRoleSt.FileHeaderGuid;

            if (this._employeeRoleStTable.ContainsKey(employeeRoleSt.FileHeaderGuid) == true)
            {
                this._employeeRoleStTable.Remove(employeeRoleSt.FileHeaderGuid);
            }
            this._employeeRoleStTable.Add(employeeRoleSt.FileHeaderGuid, employeeRoleSt);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable mainDt = new DataTable(VIEW_MAIN_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            mainDt.Columns.Add(VIEW_EMPLOYEE_CODE, typeof(string));         // �]�ƈ��R�[�h
            mainDt.Columns.Add(VIEW_EMPLOYEE_NAME, typeof(string));         // �]�ƈ�����
            this.Bind_DataSet.Tables.Add(mainDt);

            // ���׃e�[�u���̗��`
            DataTable detailDt = new DataTable(VIEW_DETAIL_TABLE);
            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            detailDt.Columns.Add(VIEW_DELETE_DATE, typeof(string));         // �폜��
            detailDt.Columns.Add(VIEW_ROLEGROUP_CODE, typeof(int));			// ���[���O���[�v�R�[�h
            detailDt.Columns.Add(VIEW_ROLEGROUP_NAME, typeof(string));	    // ���[���O���[�v����
            detailDt.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));        // Guid

            this.Bind_DataSet.Tables.Add(detailDt);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_EmployeeCode.DataText = "";         // �]�ƈ��R�[�h
            this.uLabel_EmployeeName.Text = "";             // �]�ƈ�����
            this.tNedit_RoleGroupCode.DataText = "";        // ���[���O���[�v�R�[�h
            this.uLabel_RoleGroupName.Text = "";            // ���[���O���[�v����
        }

        /// <summary>
        /// �]�ƈ����[���ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="employeeRoleSt">�]�ƈ����[���ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �]�ƈ����[���ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void EmployeeRoleStToScreen(EmployeeRoleSt employeeRoleSt)
        {

            this.tNedit_EmployeeCode.DataText = employeeRoleSt.EmployeeCode;    // �]�ƈ��R�[�h
            this.uLabel_EmployeeName.Text = employeeRoleSt.EmployeeName;        // �]�ƈ�����
            this.tNedit_RoleGroupCode.SetInt(employeeRoleSt.RoleGroupCode);     // ���[���O���[�v�R�[�h
            this.uLabel_RoleGroupName.Text = employeeRoleSt.RoleGroupName;      // ���[���O���[�v����
        }

        /// <summary>
        /// ��ʏ��]�ƈ����[���ݒ�N���X�i�[����
        /// </summary>
        /// <param name="employeeRoleSt">�]�ƈ����[���ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�]�ƈ����[���ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToEmployeeRoleSt(ref EmployeeRoleSt employeeRoleSt)
        {
            if (employeeRoleSt == null)
            {
                // �V�K�̏ꍇ
                employeeRoleSt = new EmployeeRoleSt();
            }

            //��ƃR�[�h
            employeeRoleSt.EnterpriseCode = this._enterpriseCode;

            // �]�ƈ��R�[�h
            employeeRoleSt.EmployeeCode = this.tNedit_EmployeeCode.DataText;

            // ���[���O���[�v�R�[�h
            employeeRoleSt.RoleGroupCode = this.tNedit_RoleGroupCode.GetInt();
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

            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                //this.Hide();
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0,                                  // �X�e�[�^�X�l
                            MessageBoxButtons.OK);              // �\������{�^��
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
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0,                                  // �X�e�[�^�X�l
                            MessageBoxButtons.OK);              // �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �]�ƈ����[���ݒ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����[���ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // �]�ƈ��R�[�h
            if (this.tNedit_EmployeeCode.DataText == "")
            {
                message = this.Employee_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.tNedit_EmployeeCode;
                return false;
            }

            // ���[���O���[�v�R�[�h
            if (this.tNedit_RoleGroupCode.DataText == "")
            {
                message = this.RoleGroup_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.tNedit_RoleGroupCode;
                return false;
            }

            return true;
        }

        /// <summary>
        ///  �ۑ�����(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ۑ��������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            //��ʃf�[�^���̓`�F�b�N����
            Control control = null;
            string message = null;

            if (!ScreenDataCheck(ref control, ref message))
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this,                               // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                    message,                            // �\�����郁�b�Z�[�W
                    0,                                  // �X�e�[�^�X�l
                    MessageBoxButtons.OK);              // �\������{�^��
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            EmployeeRoleSt employeeRoleSt = null;

            if (this._detailsDataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
                employeeRoleSt = ((EmployeeRoleSt)this._employeeRoleStTable[guid]).Clone();
            }

            // ��ʏ����擾
            ScreenToEmployeeRoleSt(ref employeeRoleSt);
            // �o�^�E�X�V����
            int status = this._employeeRoleStAcs.Write(ref employeeRoleSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        CloseForm(DialogResult.OK);
                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,            // �G���[���x��
                            PROGRAM_ID,                             // �A�Z���u��ID
                            this.Text,                              // �v���O��������
                            "SaveProc",                             // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",                 // �\�����郁�b�Z�[�W
                            status,                                 // �X�e�[�^�X�l
                            this._employeeRoleStAcs,                // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                   // �\������{�^��
                            MessageBoxDefaultButton.Button1);       // �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return false;
                    }
            }
            //// �]�ƈ����[���ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            employeeRoleSt.EmployeeName = this.uLabel_EmployeeName.Text;
            employeeRoleSt.RoleGroupName = this.uLabel_RoleGroupName.Text;

            bool grdInsertFlg = true;
            string Key = employeeRoleSt.EmployeeCode;

            foreach (DataRow wkRow in this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows)
            {
                if (Key == ((string)wkRow[VIEW_EMPLOYEE_CODE]).Trim())
                {
                    grdInsertFlg = false;
                    break;
                }
            }

            // �]�ƈ��ǉ�
            if (grdInsertFlg) EmployeeRoleStToMainDataSet(employeeRoleSt, this.DataIndex);

            if (_detailsEmployeeCode == null) _detailsEmployeeCode = employeeRoleSt.EmployeeCode.Trim();
            if (_detailsEmployeeCode == employeeRoleSt.EmployeeCode.Trim())
            {
                // ���[���O���[�v�ǉ�
                EmployeeRoleStToDetailDataSet(employeeRoleSt, this._detailsDataIndex);
            }

            result = true;
            return result;
        }


        /// <summary>
        ///  ���������b�Z�[�W�\��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �Y���R�[�h���g�p����Ă���ꍇ�Ƀ��b�Z�[�W��\�����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this,                               // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�͊��Ɏg�p����Ă��܂�",// �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OK);              // �\������{�^��
            tNedit_RoleGroupCode.Focus();

            control = tNedit_RoleGroupCode;
        }

        # endregion

        # region -- Control Events --
        /// <summary>
        /// Form.Load �C�x���g(PMKHN09741UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09741UA_Load(object sender, System.EventArgs e)
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
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            this.uButton_EmployeeGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_RoleGroupGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// Form.Closing �C�x���g(PMKHN09741UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///                   �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09741UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    int dummy = 0;
                    this.Search(ref dummy, 0);

                    // ��ʔ�\���C�x���g
                    if (UnDisplaying != null)
                    {
                        MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                        UnDisplaying(this, me);
                    }
                }
                //e.Cancel = true;
                //this.Hide();
            }
        }

        /// <summary>
        /// Form.VisibleChanged �C�x���g(PMKHN09741UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[���̕\���E��\�����؂�ւ����
        ///                   ���Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09741UA_VisibleChanged(object sender, System.EventArgs e)
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
            if (this._indexBuf == this._dataIndex) return;

            // ��ʃN���A
            ScreenClear();

            Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^�E�X�V����
            if (!SaveProc()) return;

            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                this.tNedit_RoleGroupCode.DataText = "";        // ���[���O���[�v�R�[�h
                this.uLabel_RoleGroupName.Text = "";            // ���[���O���[�v����
                this.tNedit_RoleGroupCode.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                //this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if ((this.Mode_Label.Text != DELETE_MODE) && (this.Mode_Label.Text != VIEW_MODE))
            {
                // ��ʂ̃f�[�^���擾����
                EmployeeRoleSt compareEmployeeRoleSt = new EmployeeRoleSt();

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if (this.tNedit_RoleGroupCode.GetInt() > 0)
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        PROGRAM_ID,                                           // �A�Z���u���h�c�܂��̓N���X�h�c
                        null,                                                 // �\�����郁�b�Z�[�W
                        0,                                                    // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);                       // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc()) return;
                                break;
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

                //int dummy = 0;
                //this.Search(ref dummy, 0);

                //// ��ʔ�\���C�x���g
                //if (UnDisplaying != null)
                //{
                //    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                //    UnDisplaying(this, me);
                //}
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                //this.Hide();
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///                   ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///                   �X���b�h�Ŏ��s����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Timer.Enabled = false;

            // ��ʕ\������
            ScreenReconstruction();
        }
        #endregion

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this,                               // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H",                 // �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);   // �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
            EmployeeRoleSt employeeRoleSt = (EmployeeRoleSt)this._employeeRoleStTable[guid];

            // ���S�폜����
            int status = this._employeeRoleStAcs.Delete(employeeRoleSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int dummy = 0;
                        this.Search(ref dummy, 0);

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
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,                          // �v���O��������
                            "Delete_Button_Click",              // ��������
                            TMsgDisp.OPE_DELETE,                // �I�y���[�V����
                            "�폜�Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._employeeRoleStAcs,           // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);  // �����\���{�^��
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
                //this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
            EmployeeRoleSt employeeRoleSt = ((EmployeeRoleSt)this._employeeRoleStTable[guid]).Clone();

            // ��������
            status = this._employeeRoleStAcs.Revival(ref employeeRoleSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int dummy = 0;
                        this.Search(ref dummy, 0);
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
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,                          // �v���O��������
                            "Revive_Button_Click",              // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            "�����Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._employeeRoleStAcs,           // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
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
                //this.Hide();
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // ��t�]�ƈ��R�[�h
            if (e.PrevCtrl == tNedit_EmployeeCode)
            {
                int EmployeeCd = tNedit_EmployeeCode.GetInt();
                if (EmployeeCd != 0)
                {
                    if (this._employeeAcs == null)
                    {
                        this._employeeAcs = new EmployeeAcs();
                    }
                    string employeeNm = GetEmployeeNm(EmployeeCd.ToString().PadLeft(4, '0'));
                    if (string.IsNullOrEmpty(employeeNm))
                    {
                        // ���̓`�F�b�N
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�]�ƈ������݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);
                        tNedit_EmployeeCode.Clear();
                        uLabel_EmployeeName.Text = "";
                        e.NextCtrl = tNedit_EmployeeCode;
                        e.NextCtrl.Select();
                        return;
                    }
                    else
                    {
                        this.uLabel_EmployeeName.Text = employeeNm;
                    }
                }
                else
                {
                    if (tNedit_EmployeeCode.Text == "")
                    {
                        this.uLabel_EmployeeName.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_EmployeeName.Text = ct_ZERO_NAME;
                    }
                }
            }
            // ���[���O���[�v�R�[�h
            else if (e.PrevCtrl == tNedit_RoleGroupCode)
            {
                int RoleGroupCd = tNedit_RoleGroupCode.GetInt();
                if (RoleGroupCd != 0)
                {
                    if (this._roleGroupNameStAcs == null)
                    {
                        this._roleGroupNameStAcs = new RoleGroupNameStAcs();
                    }
                    string RoleGroupNm = GetRoleGroupNm(RoleGroupCd);
                    if (string.IsNullOrEmpty(RoleGroupNm))
                    {
                        // ���̓`�F�b�N
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "���[���O���[�v�R�[�h�����݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);
                        tNedit_RoleGroupCode.Clear();
                        uLabel_RoleGroupName.Text = "";
                        e.NextCtrl = tNedit_RoleGroupCode;
                        e.NextCtrl.Select();
                        return;
                    }
                    else
                    {
                        this.uLabel_RoleGroupName.Text = RoleGroupNm;
                    }
                }
                else
                {
                    this.uLabel_RoleGroupName.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// �ŐV���{�^���N���b�N
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            // �]�ƈ��}�X�^�Ď擾
            this._employeeAcs = null;
            this._employeeTb = null;
            GetAllEmployeeNm();
            //��t�]�ƈ�����
            int EmployeeCd = tNedit_EmployeeCode.GetInt();
            if (EmployeeCd != 0)
            {
                this.uLabel_EmployeeName.Text = GetEmployeeNm(this.tNedit_EmployeeCode.Text);
            }
            else
            {
                if (tNedit_EmployeeCode.Text == "")
                {
                    this.uLabel_EmployeeName.Text = string.Empty;
                }
                else
                {
                    this.uLabel_EmployeeName.Text = ct_ZERO_NAME;
                }
            }

            // ���[���O���[�v���̃}�X�^�Ď擾
            this._roleGroupNameStAcs = null;
            this._roleGroupNameStTable = null;
            GetAllRoleGroupNm();
            this.uLabel_RoleGroupName.Text = GetRoleGroupNm(this.tNedit_RoleGroupCode.GetInt());

            TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,                           // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B",           // �\�����郁�b�Z�[�W
                          0,                                    // �X�e�[�^�X�l
                          MessageBoxButtons.OK);                // �\������{�^��
        }

        /// <summary>
        /// uButton_EmployeeGuide_Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �]�ƈ��K�C�h�\��</br>
        /// </remarks>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                tNedit_EmployeeCode.Value = employee.EmployeeCode.TrimEnd();
                uLabel_EmployeeName.Text = employee.Name;
            }

        }

        /// <summary>
        /// �]�ƈ����̂̎擾
        /// </summary>
        /// <param name="employeeCode"> �]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����̂̎擾���s���܂��B</br>
        /// </remarks>
        private string GetEmployeeNm(string employeeCode)
        {

            string EmployeeNm = string.Empty;
            if (_employeeTb == null)
            {
                GetAllEmployeeNm();
            }
            if (_employeeTb != null && _employeeTb.ContainsKey(employeeCode.PadLeft(4, '0').TrimEnd()))
            {
                EmployeeNm = (string)_employeeTb[employeeCode.PadLeft(4, '0').TrimEnd()];
            }
            return EmployeeNm;
        }

        /// <summary>
        /// �]�ƈ����̂̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �]�ƈ����̂̎擾���s���܂��B</br>
        /// </remarks>
        private void GetAllEmployeeNm()
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            if (this._employeeTb == null)
            {
                _employeeTb = new Hashtable();
            }
            else
            {
                _employeeTb.Clear();
            }

            ArrayList employeeList;
            ArrayList employeeDtlList;
            int status = this._employeeAcs.SearchAll(out employeeList, out employeeDtlList, this._enterpriseCode);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Employee employee in employeeList)
                {
                    if (employee.LogicalDeleteCode == 0)
                    {
                        _employeeTb.Add(employee.EmployeeCode.TrimEnd(), employee.Name);
                    }
                }
            }
        }
        /// <summary>
        /// ���[���O���[�v���̂̎擾
        /// </summary>
        /// <param name="roleGroupCode"> ���[���O���[�v�R�[�h</param>
        /// <returns>���[���O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̂̎擾���s���܂��B</br>
        /// </remarks>
        private string GetRoleGroupNm(int roleGroupCode)
        {

            string RoleGroupNm = string.Empty;
            if (_roleGroupNameStTable == null)
            {
                GetAllRoleGroupNm();
            }
            if (_roleGroupNameStTable != null && _roleGroupNameStTable.ContainsKey(roleGroupCode))
            {
                RoleGroupNm = (string)_roleGroupNameStTable[roleGroupCode];
            }
            return RoleGroupNm;
        }

        /// <summary>
        /// ���[���O���[�v���̂̎擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̂̎擾���s���܂��B</br>
        /// </remarks>
        private void GetAllRoleGroupNm()
        {
            if (this._roleGroupNameStAcs == null)
            {
                this._roleGroupNameStAcs = new RoleGroupNameStAcs();
            }
            if (this._roleGroupNameStTable == null)
            {
                _roleGroupNameStTable = new Hashtable();
            }
            else
            {
                _roleGroupNameStTable.Clear();
            }

            ArrayList roleGroupList;
            int status = this._roleGroupNameStAcs.SearchAll(out roleGroupList, this._enterpriseCode);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (RoleGroupNameSt roleGroup in roleGroupList)
                {
                    if (roleGroup.LogicalDeleteCode == 0)
                    {
                        _roleGroupNameStTable.Add(roleGroup.RoleGroupCode, roleGroup.RoleGroupName);
                    }
                }
            }
        }

        /// <summary>
        /// uButton_RoleGroupGuide_Click
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[���O���[�v���̃K�C�h�\��</br>
        /// </remarks>
        private void uButton_RoleGroupGuide_Click(object sender, EventArgs e)
        {
            if (this._roleGroupNameStAcs == null)
            {
                this._roleGroupNameStAcs = new RoleGroupNameStAcs();
            }

            RoleGroupNameSt roleGroup;

            int status = this._roleGroupNameStAcs.ExecuteGuid(this._enterpriseCode, out roleGroup);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                tNedit_RoleGroupCode.Value = roleGroup.RoleGroupCode;
                uLabel_RoleGroupName.Text = roleGroup.RoleGroupName;
            }
        }
    }
}
