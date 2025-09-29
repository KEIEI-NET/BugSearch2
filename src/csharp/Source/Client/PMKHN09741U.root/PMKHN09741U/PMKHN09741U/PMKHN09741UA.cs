//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 従業員ロール設定マスタ
// プログラム概要   : 従業員ロール設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸　伸悟
// 作 成 日  2013/02/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸　伸悟
// 作 成 日  2013/02/25  修正内容 : システムテスト障害№127対応
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
    /// 従業員ロール設定マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 従業員ロール設定マスタを行います。
    ///                   IMasterMaintenanceMultiTypeを実装しています。</br>
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
        /// 従業員ロール設定マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 従業員ロール設定マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09741UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;
            this._targetTableName = "";

            //  企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._dataIndex = -1;
            this._detailsDataIndex = -1;
            this._employeeRoleStAcs = new EmployeeRoleStAcs();
            this._totalCount = 0;
            this._employeeRoleStTable = new Hashtable();
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();
        }
        #endregion

        private System.ComponentModel.IContainer components;

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
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

        #region -- Windows フォーム デザイナで生成されたコード --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
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
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(621, 133);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "閉じる(&X)";
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
            this.Ok_Button.Text = "保存(&S)";
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
            this.Mode_Label.Text = "更新モード";
            // 
            // Employee_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Employee_uLabel.Appearance = appearance4;
            this.Employee_uLabel.Location = new System.Drawing.Point(16, 44);
            this.Employee_uLabel.Name = "Employee_uLabel";
            this.Employee_uLabel.Size = new System.Drawing.Size(123, 24);
            this.Employee_uLabel.TabIndex = 171;
            this.Employee_uLabel.Text = "従業員";
            // 
            // RoleGroup_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.RoleGroup_uLabel.Appearance = appearance22;
            this.RoleGroup_uLabel.Location = new System.Drawing.Point(16, 74);
            this.RoleGroup_uLabel.Name = "RoleGroup_uLabel";
            this.RoleGroup_uLabel.Size = new System.Drawing.Size(123, 24);
            this.RoleGroup_uLabel.TabIndex = 179;
            this.RoleGroup_uLabel.Text = "ロールグループ";
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
            this.Revive_Button.Text = "復活(&R)";
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
            this.Delete_Button.Text = "完全削除(&D)";
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
            this.Renewal_Button.Text = "最新情報(&I)";
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
            this.uLabel_EmployeeName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.uLabel_RoleGroupName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tNedit_EmployeeCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
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
            this.tNedit_RoleGroupCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
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
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(16, 11);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(417, 24);
            this.ultraLabel1.TabIndex = 171;
            this.ultraLabel1.Text = "従業員コードにゼロを入力すると共通設定になります";
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09741UA";
            this.Text = "従業員ロール設定";
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
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        // 従業員ロールマスタアクセスクラス
        private EmployeeRoleStAcs _employeeRoleStAcs;
        private Hashtable _employeeRoleStTable;

        // 従業員マスタアクセスクラス
        private EmployeeAcs _employeeAcs;
        private Hashtable _employeeTb = null;

        // ロールグループ名称マスタアクセスクラス
        private RoleGroupNameStAcs _roleGroupNameStAcs;
        private Hashtable _roleGroupNameStTable;

        private SecInfoAcs _secInfoAcs = new SecInfoAcs();

        private int _totalCount;
        private string _enterpriseCode;

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // プロパティ用
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

        //_dataIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        private const string PROGRAM_ID = "PMKHN09741U";    // プログラムID

        // View用Gridに表示させるテーブル名
        private const string VIEW_MAIN_TABLE = "VIEW_MAIN_TABLE";
        private const string VIEW_DETAIL_TABLE = "VIEW_DETAIL_TABLE";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const String VIEW_MAIN_TITLE = "従業員";
        private const string VIEW_EMPLOYEE_CODE = "従業員コード";
        private const string VIEW_EMPLOYEE_NAME = "従業員名称";

        private const string VIEW_DETAIL_TITLE = "ロールグループ";
        private const string VIEW_DELETE_DATE = "削除日";
        private const string VIEW_ROLEGROUP_CODE = "ロールグループコード";
        private const string VIEW_ROLEGROUP_NAME = "ロールグループ名称";
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string DELETE_MODE = "削除モード";
        private const string VIEW_MODE = "参照モード";

        // 入力チェック
        private const string ct_InputError = "の入力が不正です";
        private const string ct_NoInput = "を入力して下さい";

        private const string ct_ZERO_NAME = "共通設定";

        #endregion

        #region -- Main --
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09741UA());
        }
        # endregion

        #region -- Properties --
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
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

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>データセットの選択データインデックスプロパティ</summary>
        /// <value>データセットの選択データインデックスを取得または設定します。</value>
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

        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
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
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 先頭から指定件数分のデータを検索し、</br>
        /// <br>              抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            retList = null;

            // --- DEL 2013/02/25 三戸 2013/03/06配信分 システムテスト障害№127 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Clear();
            //this._employeeRoleStTable.Clear();
            // --- DEL 2013/02/25 三戸 2013/03/06配信分 システムテスト障害№127 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // 全検索
            status = this._employeeRoleStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        string Key = "";

                        // --- ADD 2013/02/25 三戸 2013/03/06配信分 システムテスト障害№127 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        bool viewFlg = false;

                        if (this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Count > 0)
                        {
                            foreach (EmployeeRoleSt employeeRoleSt in retList)
                            {
                                if (Key != employeeRoleSt.EmployeeCode.Trim())
                                {
                                    // 従業員の再表示が必要かチェック
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
                        // --- ADD 2013/02/25 三戸 2013/03/06配信分 システムテスト障害№127 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        foreach (EmployeeRoleSt employeeRoleSt in retList)
                        {
                            if (employeeRoleSt.EmployeeCode.Trim() == "0000") employeeRoleSt.EmployeeName = ct_ZERO_NAME;
                            if (Key != employeeRoleSt.EmployeeCode.Trim())
                            {
                                // 従業員ロール設定情報クラスのデータセット展開処理
                                EmployeeRoleStToMainDataSet(employeeRoleSt.Clone(), index);
                                Key = employeeRoleSt.EmployeeCode.Trim();
                            }
                            ++index;
                        }
                        break;
                    }

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // --- ADD 2013/02/25 三戸 2013/03/06配信分 システムテスト障害№127 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Clear();
                        this._employeeRoleStTable.Clear();
                        // --- ADD 2013/02/25 三戸 2013/03/06配信分 システムテスト障害№127 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        break;
                    }

                default:
                    {
                        // --- ADD 2013/02/25 三戸 2013/03/06配信分 システムテスト障害№127 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Clear();
                        this._employeeRoleStTable.Clear();
                        // --- ADD 2013/02/25 三戸 2013/03/06配信分 システムテスト障害№127 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,            // エラーレベル
                            PROGRAM_ID,                             // アセンブリID
                            this.Text,                              // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",             // 表示するメッセージ
                            status,                                 // ステータス値
                            this._employeeRoleStAcs,               // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                   // 表示するボタン
                            MessageBoxDefaultButton.Button1);       // 初期表示ボタン

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定した件数分のネクストデータを検索します。</br>
        /// <br></br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 9;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 選択中のデータを削除します。</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
            EmployeeRoleSt employeeRoleSt = (EmployeeRoleSt)this._employeeRoleStTable[guid];

            int status;

            // 従業員ロール設定情報の論理削除処理
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
                        // 論理削除
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            PROGRAM_ID,                         // アセンブリＩＤまたはクラスＩＤ
                            this.Text,                          // プログラム名称
                            "Delete",                           // 処理名称
                            TMsgDisp.OPE_HIDE,                  // オペレーション
                            "削除に失敗しました。",             // 表示するメッセージ
                            status,                             // ステータス値
                            this._employeeRoleStAcs,           // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return status;
                    }
            }

            int dummy = 0;
            this.Search(ref dummy, 0);

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 印刷処理を実行します。(未実装)</br>
        /// <br></br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <param name="appearanceTable">グリッド外観</param>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br></br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // メイングリッド
            Hashtable mainAppearanceTable = new Hashtable();

            // 従業員コード
            mainAppearanceTable.Add(VIEW_EMPLOYEE_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 従業員名称
            mainAppearanceTable.Add(VIEW_EMPLOYEE_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // サブグリッド
            Hashtable detailsAppearanceTable = new Hashtable();

            // 削除日
            detailsAppearanceTable.Add(VIEW_DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ロールグループコード
            detailsAppearanceTable.Add(VIEW_ROLEGROUP_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ロールグループ名称
            detailsAppearanceTable.Add(VIEW_ROLEGROUP_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // Guid
            detailsAppearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
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
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br></br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // グリッド表示用データセットを設定
            bindDataSet = this.Bind_DataSet;

            // ２つのテーブル名称の設定
            string[] strRet = new string[2];
            strRet[0] = VIEW_MAIN_TABLE;
            strRet[1] = VIEW_DETAIL_TABLE;
            tableName = strRet;
        }

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
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
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
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
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
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
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
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
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
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
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
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
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br></br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._dataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// 明細データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 黄海霞</br>
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
                    // 従業員ロール設定情報クラスのデータセット展開処理
                    EmployeeRoleStToDetailDataSet(employeeRoleSt.Clone(), index);
                }
                ++index;
            }

            return status;
        }

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            return 9;
        }

        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>捜査対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }
        # endregion

        #region -- Private Methods --
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                // 従業員グリッドで新規ボタン押下
                EmployeeRoleSt employeeRoleSt = new EmployeeRoleSt();

                this._indexBuf = this._dataIndex;

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tNedit_EmployeeCode.Focus();
            }
            else if (this._detailsDataIndex < 0)
            {
                // ロールグループグリッドで新規ボタン押下
                EmployeeRoleSt employeeRoleSt = new EmployeeRoleSt();

                this._indexBuf = this._detailsDataIndex;

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                this.tNedit_EmployeeCode.Enabled = false;
                this.uButton_EmployeeGuide.Enabled = false;

                // 従業員コード
                this.tNedit_EmployeeCode.DataText = (string)this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[DataIndex][VIEW_EMPLOYEE_CODE];
                this.uLabel_EmployeeName.Text = (string)this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[DataIndex][VIEW_EMPLOYEE_NAME];

                // フォーカス設定
                this.tNedit_RoleGroupCode.Focus();
            }
            else
                {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
                EmployeeRoleSt employeeRoleSt = (EmployeeRoleSt)this._employeeRoleStTable[guid];

                // 従業員ロール設定クラス画面展開処理
                EmployeeRoleStToScreen(employeeRoleSt);

                if (employeeRoleSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = VIEW_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(VIEW_MODE);

                    // フォーカス設定
                    this.Cancel_Button.Focus();
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
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
        /// 従業員ロール設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="employeeRoleSt">従業員ロール設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : ロールグループ設定クラスをデータセットに格納します。</br>
        /// <br></br>
        /// </remarks>
        private void EmployeeRoleStToMainDataSet(EmployeeRoleSt employeeRoleSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows.Count - 1;
            }

            // 従業員コード
            this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[index][VIEW_EMPLOYEE_CODE] = employeeRoleSt.EmployeeCode;

            // 従業員名称
            this.Bind_DataSet.Tables[VIEW_MAIN_TABLE].Rows[index][VIEW_EMPLOYEE_NAME] = employeeRoleSt.EmployeeName;
        }

        /// <summary>
        /// 従業員ロール設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="employeeRoleSt">従業員ロール設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : ロールグループ設定クラスをデータセットに格納します。</br>
        /// <br></br>
        /// </remarks>
        private void EmployeeRoleStToDetailDataSet(EmployeeRoleSt employeeRoleSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows.Count - 1;
            }

            if (employeeRoleSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[index][VIEW_DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[index][VIEW_DELETE_DATE] = employeeRoleSt.UpdateDateTimeJpInFormal;
            }

            // ロールグループコード
            this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[index][VIEW_ROLEGROUP_CODE] = employeeRoleSt.RoleGroupCode;

            // ロールグループ名称
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
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable mainDt = new DataTable(VIEW_MAIN_TABLE);

            // Addを行う順番が、列の表示順位となります。
            mainDt.Columns.Add(VIEW_EMPLOYEE_CODE, typeof(string));         // 従業員コード
            mainDt.Columns.Add(VIEW_EMPLOYEE_NAME, typeof(string));         // 従業員名称
            this.Bind_DataSet.Tables.Add(mainDt);

            // 明細テーブルの列定義
            DataTable detailDt = new DataTable(VIEW_DETAIL_TABLE);
            // Addを行う順番が、列の表示順位となります。
            detailDt.Columns.Add(VIEW_DELETE_DATE, typeof(string));         // 削除日
            detailDt.Columns.Add(VIEW_ROLEGROUP_CODE, typeof(int));			// ロールグループコード
            detailDt.Columns.Add(VIEW_ROLEGROUP_NAME, typeof(string));	    // ロールグループ名称
            detailDt.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));        // Guid

            this.Bind_DataSet.Tables.Add(detailDt);
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面をクリアします。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_EmployeeCode.DataText = "";         // 従業員コード
            this.uLabel_EmployeeName.Text = "";             // 従業員名称
            this.tNedit_RoleGroupCode.DataText = "";        // ロールグループコード
            this.uLabel_RoleGroupName.Text = "";            // ロールグループ名称
        }

        /// <summary>
        /// 従業員ロール設定クラス画面展開処理
        /// </summary>
        /// <param name="employeeRoleSt">従業員ロール設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 従業員ロール設定オブジェクトから画面にデータを展開します。</br>
        /// <br></br>
        /// </remarks>
        private void EmployeeRoleStToScreen(EmployeeRoleSt employeeRoleSt)
        {

            this.tNedit_EmployeeCode.DataText = employeeRoleSt.EmployeeCode;    // 従業員コード
            this.uLabel_EmployeeName.Text = employeeRoleSt.EmployeeName;        // 従業員名称
            this.tNedit_RoleGroupCode.SetInt(employeeRoleSt.RoleGroupCode);     // ロールグループコード
            this.uLabel_RoleGroupName.Text = employeeRoleSt.RoleGroupName;      // ロールグループ名称
        }

        /// <summary>
        /// 画面情報従業員ロール設定クラス格納処理
        /// </summary>
        /// <param name="employeeRoleSt">従業員ロール設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から従業員ロール設定オブジェクトにデータを格納します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToEmployeeRoleSt(ref EmployeeRoleSt employeeRoleSt)
        {
            if (employeeRoleSt == null)
            {
                // 新規の場合
                employeeRoleSt = new EmployeeRoleSt();
            }

            //企業コード
            employeeRoleSt.EnterpriseCode = this._enterpriseCode;

            // 従業員コード
            employeeRoleSt.EmployeeCode = this.tNedit_EmployeeCode.DataText;

            // ロールグループコード
            employeeRoleSt.RoleGroupCode = this.tNedit_RoleGroupCode.GetInt();
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // フォームを非表示化する。
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
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PROGRAM_ID,                         // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0,                                  // ステータス値
                            MessageBoxButtons.OK);              // 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PROGRAM_ID,                         // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0,                                  // ステータス値
                            MessageBoxButtons.OK);              // 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 従業員ロール設定画面入力チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 従業員ロール設定画面の入力チェックをします。</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // 従業員コード
            if (this.tNedit_EmployeeCode.DataText == "")
            {
                message = this.Employee_uLabel.Text + "を設定して下さい。";
                control = this.tNedit_EmployeeCode;
                return false;
            }

            // ロールグループコード
            if (this.tNedit_RoleGroupCode.DataText == "")
            {
                message = this.RoleGroup_uLabel.Text + "を設定して下さい。";
                control = this.tNedit_RoleGroupCode;
                return false;
            }

            return true;
        }

        /// <summary>
        ///  保存処理(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            //画面データ入力チェック処理
            Control control = null;
            string message = null;

            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this,                               // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    PROGRAM_ID,                         // アセンブリＩＤまたはクラスＩＤ
                    message,                            // 表示するメッセージ
                    0,                                  // ステータス値
                    MessageBoxButtons.OK);              // 表示するボタン
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

            // 画面情報を取得
            ScreenToEmployeeRoleSt(ref employeeRoleSt);
            // 登録・更新処理
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
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        CloseForm(DialogResult.OK);
                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,            // エラーレベル
                            PROGRAM_ID,                             // アセンブリID
                            this.Text,                              // プログラム名称
                            "SaveProc",                             // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",                 // 表示するメッセージ
                            status,                                 // ステータス値
                            this._employeeRoleStAcs,                // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                   // 表示するボタン
                            MessageBoxDefaultButton.Button1);       // 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return false;
                    }
            }
            //// 従業員ロール設定情報クラスのデータセット展開処理
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

            // 従業員追加
            if (grdInsertFlg) EmployeeRoleStToMainDataSet(employeeRoleSt, this.DataIndex);

            if (_detailsEmployeeCode == null) _detailsEmployeeCode = employeeRoleSt.EmployeeCode.Trim();
            if (_detailsEmployeeCode == employeeRoleSt.EmployeeCode.Trim())
            {
                // ロールグループ追加
                EmployeeRoleStToDetailDataSet(employeeRoleSt, this._detailsDataIndex);
            }

            result = true;
            return result;
        }


        /// <summary>
        ///  競合中メッセージ表示
        /// </summary>
        /// <remarks>
        /// <br>Note        : 該当コードが使用されている場合にメッセージを表示します。</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this,                               // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,                         // アセンブリＩＤまたはクラスＩＤ
                "このコードは既に使用されています",// 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OK);              // 表示するボタン
            tNedit_RoleGroupCode.Focus();

            control = tNedit_RoleGroupCode;
        }

        # endregion

        # region -- Control Events --
        /// <summary>
        /// Form.Load イベント(PMKHN09741UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09741UA_Load(object sender, System.EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
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
        /// Form.Closing イベント(PMKHN09741UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note        : フォームを閉じる前に、ユーザーがフォームを閉じ
        ///                   ようとしたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09741UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    int dummy = 0;
                    this.Search(ref dummy, 0);

                    // 画面非表示イベント
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
        /// Form.VisibleChanged イベント(PMKHN09741UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォームの表示・非表示が切り替えられ
        ///                   たときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09741UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
                this.Owner.Activate();
                return;
            }

            // 自分自身が非表示になった場合、
            // またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex) return;

            // 画面クリア
            ScreenClear();

            Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // 登録・更新処理
            if (!SaveProc()) return;

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                this.tNedit_RoleGroupCode.DataText = "";        // ロールグループコード
                this.uLabel_RoleGroupName.Text = "";            // ロールグループ名称
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
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if ((this.Mode_Label.Text != DELETE_MODE) && (this.Mode_Label.Text != VIEW_MODE))
            {
                // 画面のデータを取得する
                EmployeeRoleSt compareEmployeeRoleSt = new EmployeeRoleSt();

                // 画面情報と起動時のクローンと比較し変更を監視する
                if (this.tNedit_RoleGroupCode.GetInt() > 0)
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        PROGRAM_ID,                                           // アセンブリＩＤまたはクラスＩＤ
                        null,                                                 // 表示するメッセージ
                        0,                                                    // ステータス値
                        MessageBoxButtons.YesNoCancel);                       // 表示するボタン

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

                //// 画面非表示イベント
                //if (UnDisplaying != null)
                //{
                //    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                //    UnDisplaying(this, me);
                //}
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// Timer.Tick イベント(timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///                   スレッドで実行されます。</br>
        /// <br></br>
        /// </remarks>
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Timer.Enabled = false;

            // 画面表示処理
            ScreenReconstruction();
        }
        #endregion

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this,                               // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,                         // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？",                 // 表示するメッセージ
                0,                                  // ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);   // 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
            EmployeeRoleSt employeeRoleSt = (EmployeeRoleSt)this._employeeRoleStTable[guid];

            // 完全削除処理
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
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // 完全削除
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                            PROGRAM_ID,                         // アセンブリＩＤまたはクラスＩＤ
                            this.Text,                          // プログラム名称
                            "Delete_Button_Click",              // 処理名称
                            TMsgDisp.OPE_DELETE,                // オペレーション
                            "削除に失敗しました。",             // 表示するメッセージ
                            status,                             // ステータス値
                            this._employeeRoleStAcs,           // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);  // 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_DETAIL_TABLE].Rows[this._detailsDataIndex][VIEW_GUID_KEY_TITLE];
            EmployeeRoleSt employeeRoleSt = ((EmployeeRoleSt)this._employeeRoleStTable[guid]).Clone();

            // 復活処理
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
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,                               // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            PROGRAM_ID,                         // アセンブリＩＤまたはクラスＩＤ
                            this.Text,                          // プログラム名称
                            "Revive_Button_Click",              // 処理名称
                            TMsgDisp.OPE_UPDATE,                // オペレーション
                            "復活に失敗しました。",             // 表示するメッセージ
                            status,                             // ステータス値
                            this._employeeRoleStAcs,           // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 受付従業員コード
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
                        // 入力チェック
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "従業員が存在しません。",
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
            // ロールグループコード
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
                        // 入力チェック
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "ロールグループコードが存在しません。",
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
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            // 従業員マスタ再取得
            this._employeeAcs = null;
            this._employeeTb = null;
            GetAllEmployeeNm();
            //受付従業員名称
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

            // ロールグループ名称マスタ再取得
            this._roleGroupNameStAcs = null;
            this._roleGroupNameStTable = null;
            GetAllRoleGroupNm();
            this.uLabel_RoleGroupName.Text = GetRoleGroupNm(this.tNedit_RoleGroupCode.GetInt());

            TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,                           // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。",           // 表示するメッセージ
                          0,                                    // ステータス値
                          MessageBoxButtons.OK);                // 表示するボタン
        }

        /// <summary>
        /// uButton_EmployeeGuide_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 従業員ガイド表示</br>
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
        /// 従業員名称の取得
        /// </summary>
        /// <param name="employeeCode"> 従業員コード</param>
        /// <returns>従業員名称</returns>
        /// <remarks>
        /// <br>Note       : 従業員名称の取得を行います。</br>
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
        /// 従業員名称の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員名称の取得を行います。</br>
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
        /// ロールグループ名称の取得
        /// </summary>
        /// <param name="roleGroupCode"> ロールグループコード</param>
        /// <returns>ロールグループ名称</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ名称の取得を行います。</br>
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
        /// ロールグループ名称の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : ロールグループ名称の取得を行います。</br>
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
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ロールグループ名称ガイド表示</br>
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
