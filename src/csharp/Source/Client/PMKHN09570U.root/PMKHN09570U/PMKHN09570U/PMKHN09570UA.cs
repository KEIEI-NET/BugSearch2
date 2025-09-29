//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 対象得意先設定
// プログラム概要   : 対象得意先設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note      :   2011/05/06 譚洪                         
//                  :   ＰＧ名称、項目名の変更                               
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
    /// 対象得意先設定 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 対象得意先設定情報の設定を行います。
    ///					  IMasterMaintenanceArrayTypeを実装しています。</br>
    /// <br>Update Note:  2011/05/06 譚洪</br>
    /// <br>　　　　　　　ＰＧ名称、項目名の変更</br>
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

        #region -- Windows フォーム デザイナで生成されたコード --
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
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
            this.Campaign_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Campaign_Label.Location = new System.Drawing.Point(12, 44);
            this.Campaign_Label.Name = "Campaign_Label";
            this.Campaign_Label.Size = new System.Drawing.Size(133, 24);
            this.Campaign_Label.TabIndex = 61;
            this.Campaign_Label.Text = "キャンペーンコード";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(471, 413);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "閉じる(&X)";
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
            this.Revive_Button.Text = "復活(&R)";
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
            this.Delete_Button.Text = "完全削除(&D)";
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
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // uButton_CampaignGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CampaignGuide.Appearance = appearance12;
            this.uButton_CampaignGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Mode_Label.Text = "更新モード";
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
            this.Guid_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Guid_Button.Location = new System.Drawing.Point(116, 91);
            this.Guid_Button.Name = "Guid_Button";
            this.Guid_Button.Size = new System.Drawing.Size(161, 29);
            this.Guid_Button.TabIndex = 4;
            this.Guid_Button.Text = "得意先ｶﾞｲﾄﾞ(&G)";
            this.Guid_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Guid_Button.Click += new System.EventHandler(this.Guid_Button_Click);
            // 
            // DeleteRow_Button
            // 
            this.DeleteRow_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteRow_Button.Location = new System.Drawing.Point(12, 91);
            this.DeleteRow_Button.Name = "DeleteRow_Button";
            this.DeleteRow_Button.Size = new System.Drawing.Size(98, 29);
            this.DeleteRow_Button.TabIndex = 3;
            this.DeleteRow_Button.Text = "削除(&D)";
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
            this.Renewal_Button.Text = "最新情報(&I)";
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PMKHN09570UA";
            this.Text = "対象得意先設定";
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
        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先情報アクセスクラス

        private CampaignLink _campaignLink;
        private CampaignLink[] _campaignLinkCloneList;
        
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _mainTable;
        private Hashtable _detailTable;
        private Hashtable _detailCloneTable;

        // 得意先情報キャッシュ
        private ArrayList _customerList;

        // 得意先情報ダイアログ
        private int _customerCode;
        private string _customerName;

        // プロパティ用
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

        // FreamのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string I_DELETEDATE = "削除日";
        private const string I_CAMPAIGN_CODE = "キャンペーンコード";
        private const string I_CAMPAIGN_NAME = "キャンペーン名";
        private const string I_CAMPAIGN_GUID = "CAMPAIGN_GUID";
        private const string I_CAMPAIGN_TABLE = "CAMPAIGN_TABLE";

        private const string S_DELETEDATE = "削除日";
        private const string S_CAMPAIGN_CODE = "設定キャンペーンコード";
        private const string S_CUSTOMER_CODE = "得意先コード";
        private const string S_CUSTOMER_NAME = "得意先名";
        private const string S_CUSTOMER_GUID = "CUSTOMER_GUID";
        private const string S_CUSTOMER_TABLE = "CUSTOMER_TABLE";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";
        private const string REFERENCE_MODE = "参照モード";

        // UIのGrid表示用
        private const string MY_SCREEN_CUSTOMER_CODE = "得意先コード";
        private const string MY_SCREEN_CUSTOMER_NAME = "得意先名";
        private const string MY_SCREEN_ODER = "No.";
        private const string MY_SCREEN_GUID = "MY_SCREEN_GUID";
        private const string MY_SCREEN_TABLE = "MY_SCREEN_TABLE";
        private const string MY_SCREEN_ID = "ID";                               // 作業・部品名称など(編集不可、非表示)

        //UIグリッド用データテーブル
        private DataTable _bindTable;

        // GridのIndexBuffer格納用変数
        private int _mainIndexBuffer;
        private int _detailsIndexBuffer;
        private string _targetTableBuffer;

        // Grid変更フラグ
        private bool _gridUpdFlg = true;

        // アセンブリ情報
        private const string PG_ID = "PMKHN09570U";
        //private const string PG_NAME = "キャンペーン関連マスタ";  // DEL 2011/05/06
        private const string PG_NAME = "対象得意先設定";            // ADD 2011/05/06

        // Message関連定義
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        # endregion

        # region -- Constructor --
		/// <summary>
        /// 対象得意先設定 フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 対象得意先設定 フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09570UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canLogicalDeleteDataExtraction = true;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._mainGridTitle = "キャンペーン";
            this._detailsGridTitle = "得意先";
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;
            this._targetTableName = "";
            this._mainGridIcon = null;
            this._detailsGridIcon = null;

            // ガイドボタンの画像イメージ追加
            this.uButton_CampaignGuide.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 変数初期化
            this._campaignLinkAcs = new CampaignLinkAcs();

            this._campaignLink = new CampaignLink();
            this._campaignLinkCloneList = new CampaignLink[1];

            this._totalCount = 0;
            this._mainTable = new Hashtable();
            this._detailTable = new Hashtable();
            this._detailCloneTable = new Hashtable();

            this._bindTable = new DataTable(MY_SCREEN_TABLE);

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";

            // キャッシュ情報取得
            this.GetCacheData();
		}
		# endregion

        # region -- Dispose --
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
        # endregion

        # region -- Main --
        /// <summary>メイン処理</summary>
        /// <value></value>
        /// <remarks>アプリケーションのメイン エントリ ポイントです。</remarks>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09570UA());
        }
        # endregion

        # region -- Events --
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        # endregion
        
        # region -- Properties --
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
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

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
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

        # region -- Public Methods --
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
            strRet[0] = this._mainGridTitle;
            strRet[1] = this._detailsGridTitle;
            return strRet;
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
            objRet[0] = this._mainGridIcon;
            objRet[1] = this._detailsGridIcon;
            return objRet;
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
            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
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
            blRet[1] = false;
            return blRet;
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
            blRet[0] = true;
            blRet[1] = false;
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
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
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
            strRet[0] = I_CAMPAIGN_TABLE;
            strRet[1] = S_CUSTOMER_TABLE;
            tableName = strRet;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList campaignLinkList = null;

            if (readCount == 0)
            {
                // 抽出対象件数が0の場合は全件抽出を実行する
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
                                // 対象得意先設定情報クラスのデータセット展開処理
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
                        // サーチ結果 メーカーマスタ読み込み失敗
                        TMsgDisp.Show(
                            this, 									    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 			    // エラーレベル
                            PG_ID,      							    // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,	        					    // プログラム名称
                            "Search", 								    // 処理名称
                            TMsgDisp.OPE_GET, 						    // オペレーション
                            //"キャンペーン関連情報の読み込みに失敗しました。",  // 表示するメッセージ  // DEL 2011/05/06
                            "対象得意先設定マスタ情報の読み込みに失敗しました。",  // 表示するメッセージ // ADD 2011/05/06
                            status, 								    // ステータス値
                            this._campaignLinkAcs,	 				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 					    // 表示するボタン
                            MessageBoxDefaultButton.Button1);		    // 初期表示ボタン
                        
                        break;
                    }
            }

            // 戻り値セット
            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 未実装
            return 9;
        }

        /// <summary>
        /// 明細データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrModelNameU = new ArrayList();

            // 現在保持している車種名称データをクリアする
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Clear();
            this._detailTable.Clear();

            // ADD 2009/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;
            // ADD 2009/03/24 不具合対応[12693]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            // 選択されているメーカーデータを取得する
            int guid = (int)this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[this._mainDataIndex][I_CAMPAIGN_GUID];
            CampaignLink campaignLink = (CampaignLink)this._mainTable[guid];

            // メーカーコード指定 車種名称検索処理（論理削除含む）
            status = this._campaignLinkAcs.SearchDetail(out arrModelNameU, this._enterpriseCode, campaignLink.CampaignCode);

            this._totalCount = arrModelNameU.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 取得した車種名称クラスをデータセットへ展開する
                        int index = 0;
                        foreach (CampaignLink wkCampaignLink in arrModelNameU)
                        {
                            // 車種名称クラスデータセット展開処理
                            CustomerToDataSet(wkCampaignLink.Clone(), index);
                            ++index;
                        }

                        // ソート
                        //this.Bind_DataSet.Tables[S_MODELNAMEU_TABLE].DefaultView.Sort = S_MODELCODE + ", " + S_MODELSUBCODE + " ASC";
                        
                        break;
                    }
                default:
                    {
                        // 明細データ検索処理
                        TMsgDisp.Show(
                            this, 								        // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		        // エラーレベル
                            PG_ID, 						                // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,        					        // プログラム名称
                            "DetailsDataSearch", 				        // 処理名称
                            TMsgDisp.OPE_GET, 					        // オペレーション
                            "車種名称情報の読み込みに失敗しました。",	// 表示するメッセージ
                            status, 							        // ステータス値
                            this._campaignLinkAcs, 				        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				        // 表示するボタン
                            MessageBoxDefaultButton.Button1);	        // 初期表示ボタン
                        
                        break;
                    }
            }

            totalCount = this._totalCount;

            return status;
        }

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            return 9;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30413 犬飼</br>
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
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._campaignLinkAcs);
                        return status;
                    }
                case -2:
                    {
                        //主作業設定で使用中
                        TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            PG_ID,
                            "このレコードは主作業設定で使用されているため削除できません",
                            status,
                            MessageBoxButtons.OK);
                        this.Hide();

                        return status;
                    }
                default:
                    {
                        // 論理削除処理の失敗
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            PG_ID,	        					// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "Delete",							// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._campaignLinkAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }

            // データセット展開処理
             int index = 0;
            int logDelCnt = 0;         // 0はメインGrid情報、0以外は詳細Grid情報
            // 論理削除レコードをDataSetに反映
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
        /// 印刷処理
        /// </summary>
        /// <param></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷機能無しの為、未実装。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しの為未実装
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <param name="appearanceTable">グリッド外観</param>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            // メイングリッド
            Hashtable mainAppearanceTable = new Hashtable();

            // 削除日
            // ADD 2008/03/24 不具合対応[12693]↓：「削除済データの表示」は最上位項目で制御
            mainAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // メーカーコード
            mainAppearanceTable.Add(I_CAMPAIGN_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000", Color.Black));
            // メーカー名
            mainAppearanceTable.Add(I_CAMPAIGN_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // メーカー情報GUID
            mainAppearanceTable.Add(I_CAMPAIGN_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));


            // サブグリッド
            Hashtable detailsAppearanceTable = new Hashtable();

            // 削除日
            detailsAppearanceTable.Add(S_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 設定メーカーコード
            detailsAppearanceTable.Add(S_CAMPAIGN_CODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 車種コード
            detailsAppearanceTable.Add(S_CUSTOMER_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "00000000", Color.Black));
            // 車種名
            detailsAppearanceTable.Add(S_CUSTOMER_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 車種情報GUID
            detailsAppearanceTable.Add(S_CUSTOMER_GUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
        }

        # endregion

        # region -- Control Events --
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09570UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
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

            // 画面初期設定処理
            ScreenInitialSetting();
        }

        /// <summary>
        /// 画面クローズイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを閉じようとした時に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09570UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";
            
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// 画面表示状態変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 画面の表示状態が変わったときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09570UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
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

            // 画面初期化処理
            ScreenClear();

            // 画面表示タイマーON
            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// 保存ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされた時に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            this.Ok_Button.Focus();
            if (!SaveProc())
            {
                return;
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了させずに連続入力を可能とする。
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // 画面を初期化
                this.ScreenClear();

                // 画面を再構築
                this.ScreenReconstruction();
                
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // GridのIndexBuffer格納用変数初期化
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = -2;
                this._targetTableBuffer = "";

                // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
                // フォームを非表示化する。
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
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 閉じるボタンコントロールがクリックされた時に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // 更新有無フラグ
            bool isUpdate = false;

            // UI画面のGrid行数を取得
            int maxRow = this._bindTable.Rows.Count;

            //保存確認
            if (this._mainDataIndex >= 0)
            {
                // 更新モード
                if (maxRow > 0)
                {
                    // UI画面のGridに1件以上登録されていること
                    ArrayList updateList = new ArrayList();
                    ArrayList deleteList = new ArrayList();

                    // 更新データの有無を確認
                    UpdateCompare(out updateList, out deleteList);

                    if ((updateList.Count != 0) || (deleteList.Count != 0))
                    {
                        // 更新／削除レコードが有り
                        isUpdate = true;
                    }
                }
            }
            else
            {
                // 新規モード
                ArrayList partsList = new ArrayList();
                // 画面情報を取得
                this.DispToCampaignLink(ref partsList);
                if (partsList.Count > 0)
                {
                    // 得意先の設定有
                    isUpdate = true;
                }
                //else if (partsList.Count == 1)
                //{
                //    // 部位の設定のみ
                //    CampaignLink compPartsPosCode = new CampaignLink();
                //    ArrayList compRet = compPartsPosCode.Compare((CampaignLink)partsList[0]);
                //    if (compRet.Count > 1)
                //    {
                //        // 企業コード以外の設定項目有
                //        isUpdate = true;
                //    }
                //}
            }

            //最初に取得した画面情報と比較
            if (isUpdate)
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                // 保存確認
                DialogResult res = TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                    PG_ID,       						// アセンブリＩＤまたはクラスＩＤ
                    null, 								// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.YesNoCancel);	// 表示するボタン
                
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

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // GridのIndexBuffer格納用変数初期化
            this._mainIndexBuffer = -2;
            this._detailsIndexBuffer = -2;
            this._targetTableBuffer = "";
            
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
                PG_ID,					        						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
                0,														// ステータス値
                MessageBoxButtons.OKCancel,								// 表示するボタン
                MessageBoxDefaultButton.Button2);						// 初期表示ボタン


            if (result == DialogResult.OK)
            {
                ArrayList deleteList = new ArrayList();
                CampaignLink campaignLink = new CampaignLink();

                // Form 明細Gridの情報を取得
                int maxRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count;
                for (int i = 0; i < maxRow; i++)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[i][S_CUSTOMER_GUID];
                    campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();
                    deleteList.Add(campaignLink);
                }

                // 物理削除処理
                status = this._campaignLinkAcs.Delete(deleteList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[this._mainDataIndex].Delete();
                            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Clear();

                            // メインGridと明細Gridのテーブルを削除
                            int delCnt = 0;
                            foreach (CampaignLink wkPartsPosCodeU in deleteList)
                            {
                                if (delCnt == 0)
                                {
                                    // メインGridのテーブル
                                    this._mainTable.Remove(wkPartsPosCodeU.CampaignCode);
                                    delCnt++;
                                }
                                
                                // 明細Gridのテーブル
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
                                this,								    // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	    // エラーレベル
                                PG_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                                PG_NAME,							    // プログラム名称
                                "Delete_Button_Click",				    // 処理名称
                                TMsgDisp.OPE_DELETE,				    // オペレーション
                                ERR_RDEL_MSG,						    // 表示するメッセージ 
                                status,								    // ステータス値
                                this._campaignLinkAcs,				    // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				    // 表示するボタン
                                MessageBoxDefaultButton.Button1);	    // 初期表示ボタン

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
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList reviveList = new ArrayList();
            CampaignLink campaignLink = new CampaignLink();

            // Form 明細Gridの情報を取得
            int maxRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count;
            for (int i = 0; i < maxRow; i++)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[i][S_CUSTOMER_GUID];
                campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();
                reviveList.Add(campaignLink);
            }

            // 復活処理
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
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            PG_ID,		        				  // アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							  // プログラム名称
                            "Revive_Button_Click",				  // 処理名称
                            TMsgDisp.OPE_UPDATE,				  // オペレーション
                            ERR_RVV_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._campaignLinkAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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

            // DataSet展開処理
            int index = 0;
            int reviveCnt = 0;

            // 再描画を行うので、現在保持している明細Gridデータをクリアする
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Clear();
            this._detailTable.Clear();

            foreach (CampaignLink wkPartsPosCodeU in reviveList)
            {
                if (reviveCnt == 0)
                {
                    // メインGrid
                    index = this._mainDataIndex;
                    CampaignLinkToDataSet(wkPartsPosCodeU, index);
                }

                // 明細Grid
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
        /// 車種名称ガイドボタン押下イベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 車種名称ガイドボタン押下時の処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private void uButton_ModelGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CampaignSt campaignSt;

                // ガイド起動
                int status = _campaignLinkAcs.CampaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    // 結果セット
                    this.tNedit_CampaignCode.SetInt(campaignSt.CampaignCode);
                    this.tEdit_CampaignName.Text = campaignSt.CampaignName;

                    // 次フォーカス
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Timer.Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br></br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();

            // モード変更可能フラグを設定
            CanChangeMode = IsInsertMode();
        }

        /// <summary>
        /// 新規モードであるか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :新規モードです。<br/>
        /// <c>false</c>:新規モードではありません。
        /// </returns>
        private bool IsInsertMode()
        {
            return this.Mode_Label.Text.Equals(INSERT_MODE);
        }

        /// <summary>モード変更可能フラグ</summary>
        private bool _canChangeMode = false;
        /// <summary>モード変更可能フラグを取得または設定します。</summary>
        private bool CanChangeMode
        {
            get { return _canChangeMode; }
            set { _canChangeMode = value; }
        }

        /// <summary>
        /// リターンキー移動イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : リターンキー押下時の制御を行います。</br>
        /// <br></br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CampaignCode":         // キャンペーンコード
                    {
                        int campaignCode = this.tNedit_CampaignCode.GetInt();
                        string campaignName = "";

                        if (campaignCode != 0)
                        {
                            // キャンペーン名称の取得
                            campaignName = this._campaignLinkAcs.GetCampaignName(campaignCode);

                            if (campaignName != "")
                            {
                                this.tEdit_CampaignName.Text = campaignName;

                                // カーソル制御
                                // GRIDの得意先コードへフォーカス制御
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
                                "該当するキャンペーンコードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                                // 得意先のクリア
                                this.tNedit_CampaignCode.Clear();
                                this.tEdit_CampaignName.Text = "";

                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                        else
                        {
                            // 未入力
                            // 得意先のクリア
                            this.tNedit_CampaignCode.Clear();
                            this.tEdit_CampaignName.Text = "";
                        }

                        break;
                    }
                case "DeleteRow_Button":            // GRID削除ボタン
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // GRIDの得意先コードへフォーカス制御
                                        this.uGrid_Customer.Rows[0].Cells[MY_SCREEN_CUSTOMER_CODE].Activate();
                                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "uGrid_Customer":      // グリッド
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        // ガイドボタンにフォーカスがある
                                        if (this.uGrid_Customer.ActiveCell != null)
                                        {
                                            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

                                            if ((this.uGrid_Customer.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Button) &&
                                                (status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
                                            {
                                                // セルのスタイルがボタンで、セルの最終行の場合
                                                if ((int)this.uGrid_Customer.ActiveCell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                                                {
                                                    // 最終行の場合、行を追加
                                                    this.tbsPartsList_AddRow();
                                                }
                                            }
                                        }

                                        // 次のセルへ移動
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
                                            // グリッド内のフォーカス制御
                                            e.NextCtrl = null;
                                        }
                                        else if (e.NextCtrl.Name == "DeleteRow_Button")
                                        {
                                            // グリッド内でのフォーカス制御に失敗した場合
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
                                        // GRIDの得意先コードへフォーカス制御
                                        int rowIdx = this.uGrid_Customer.Rows.Count - 1;
                                        // アクティブ行を最終行に設定
                                        this.uGrid_Customer.ActiveRow = this.uGrid_Customer.Rows[rowIdx];
                                        // アクティブセルを得意先コードに設定(フォーカス遷移のため)
                                        this.uGrid_Customer.ActiveCell = this.uGrid_Customer.Rows[rowIdx].Cells[MY_SCREEN_CUSTOMER_CODE];
                                        // 得意先コードを編集モードにしてフォーカスを移動
                                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                                        {
                                            // ガイドボタンへフォーカス移動
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
                                        // GRIDの得意先コードへフォーカス制御
                                        int rowIdx = this.uGrid_Customer.Rows.Count - 1;
                                        // アクティブ行を最終行に設定
                                        this.uGrid_Customer.ActiveRow = this.uGrid_Customer.Rows[rowIdx];
                                        // アクティブセルを得意先コードに設定(フォーカス遷移のため)
                                        this.uGrid_Customer.ActiveCell = this.uGrid_Customer.Rows[rowIdx].Cells[MY_SCREEN_CUSTOMER_CODE];
                                        // 得意先コードを編集モードにしてフォーカスを移動
                                        this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                        if (this._bindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                                        {
                                            // ガイドボタンへフォーカス移動
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

            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "PartsPosName_tEdit":          // 部位名
                    case "uGrid_Customer":      // グリッド
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
                // 新規モードの場合のみ
                if ((this._mainDataIndex < 0) || (this._detailsDataIndex < 0))
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tNedit_CampaignCode;
                    }
                }
            }
            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        

        # endregion

        #region -- Private Methods --
        /// <summary>
        /// 対象得意先設定情報データセット展開処理
        /// </summary>
        /// <param name="campaignLink">対象得意先設定</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 対象得意先設定をデータセットへ格納します。</br>
        /// <br></br>
        /// </remarks>
        private void CampaignLinkToDataSet(CampaignLink campaignLink, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].NewRow();
                this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号にする
                index = this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (campaignLink.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][S_DELETEDATE] = campaignLink.UpdateDateTimeJpInFormal;
            }
            
            // キャンペーンコード
            this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][I_CAMPAIGN_CODE] = campaignLink.CampaignCode;
            
            // キャンペーン名称
            this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][I_CAMPAIGN_NAME] = this._campaignLinkAcs.GetCampaignName(campaignLink.CampaignCode);

            // キャンペーン情報GUID
            this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[index][I_CAMPAIGN_GUID] = campaignLink.CampaignCode;
            
            // ハッシュ検索用にGUIDセット
            if (this._mainTable.ContainsKey(campaignLink.CampaignCode))
            {
                this._mainTable.Remove(campaignLink.CampaignCode);
            }
            this._mainTable.Add(campaignLink.CampaignCode, campaignLink);
        }

        

        /// <summary>
        /// 得意先情報データセット展開処理
        /// </summary>
        /// <param name="campaignLink">対象得意先設定</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 対象得意先設定をデータセットへ格納します。</br>
        /// <br></br>
        /// </remarks>
        private void CustomerToDataSet(CampaignLink campaignLink, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].NewRow();
                this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count - 1;
            }

            // 削除日
            if (campaignLink.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_DELETEDATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_DELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", campaignLink.UpdateDateTime);
            }

            // 設定キャンペーンコード
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CAMPAIGN_CODE] = campaignLink.CampaignCode;

            // 得意先コード
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_CODE] = campaignLink.CustomerCode;

            // 得意先名
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_NAME] = GetCustomerName(campaignLink.CustomerCode);

            // 得意先情報GUID
            this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_GUID] = campaignLink.FileHeaderGuid;

            // ハッシュ検索用にGUIDセット
            if (this._detailTable.ContainsKey(campaignLink.FileHeaderGuid) == true)
            {
                this._detailTable.Remove(campaignLink.FileHeaderGuid);
            }
            this._detailTable.Add(campaignLink.FileHeaderGuid, campaignLink);
        }

        /// <summary>
        /// 対象得意先設定 クラス画面展開処理
        /// </summary>
        /// <param name="campaignLink">対象得意先設定 オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 対象得意先設定 オブジェクトから画面にデータを展開します。</br>
        /// <br></br>
        /// </remarks>
        private void CampaignLinkToScreen(CampaignLink[] campaignLink)
        {
            int i = 0;
            int maxRow = campaignLink.Length;
            DataRow bindRow;

            // キャンペーンコード
            this.tNedit_CampaignCode.SetInt(campaignLink[i].CampaignCode);
            // キャンペーン名
            this.tEdit_CampaignName.Text = this._campaignLinkAcs.GetCampaignName(campaignLink[i].CampaignCode);

            // 得意先情報
            for (; i < maxRow; i++)
            {
                bindRow = this._bindTable.NewRow();

                bindRow[MY_SCREEN_ID] = "";                                                         // GridのID(非表示)
                bindRow[MY_SCREEN_ODER] = i + 1;                                                    // 表示順位
                bindRow[MY_SCREEN_CUSTOMER_CODE] = campaignLink[i].CustomerCode.ToString("d08");    // 得意先コード
                bindRow[MY_SCREEN_CUSTOMER_NAME] = GetCustomerName(campaignLink[i].CustomerCode);   // 得意先名

                this._bindTable.Rows.Add(bindRow);
            }
        }

        /// <summary>
        /// 画面情報対象得意先設定 クラス格納処理
        /// </summary>
        /// <param name="campaignLinkList">対象得意先設定 オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から対象得意先設定 オブジェクトにデータを格納します。</br>
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

                campaignLink.EnterpriseCode = this._enterpriseCode;                                 // 企業コード
                campaignLink.CampaignCode = this.tNedit_CampaignCode.GetInt();                      // キャンペーンコード

                // 未入力の得意先はSKIP
                string code = (string)this._bindTable.Rows[index][MY_SCREEN_CUSTOMER_CODE];
                if (code == "")
                {
                    continue;
                }

                // 明細Grid用の情報取得
                campaignLink.CustomerCode = Int32.Parse(code);                                      // 得意先コード
                    
                campaignLinkList.Add(campaignLink);
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // メインテーブルの列定義
            DataTable mainDt = new DataTable(I_CAMPAIGN_TABLE);

            // Addを行う順番が、列の表示順位となります。
            mainDt.Columns.Add(S_DELETEDATE, typeof(string));           // 削除日
            mainDt.Columns.Add(I_CAMPAIGN_CODE, typeof(int));			// キャンペーンコード
            mainDt.Columns.Add(I_CAMPAIGN_NAME, typeof(string));		// キャンペーン名
            mainDt.Columns.Add(I_CAMPAIGN_GUID, typeof(int));           // キャンペーン情報GUID

            this.Bind_DataSet.Tables.Add(mainDt);

            // 明細テーブルの列定義
            DataTable detailDt = new DataTable(S_CUSTOMER_TABLE);

            // Addを行う順番が、列の表示順位となります。
            detailDt.Columns.Add(S_DELETEDATE, typeof(string));         // 削除日
            detailDt.Columns.Add(S_CAMPAIGN_CODE, typeof(int));			// 設定キャンペーンコード
            detailDt.Columns.Add(S_CUSTOMER_CODE, typeof(int));			// 得意先コード
            detailDt.Columns.Add(S_CUSTOMER_NAME, typeof(string));		// 得意先名
            detailDt.Columns.Add(S_CUSTOMER_GUID, typeof(Guid));        // 得意先情報GUID

            this.Bind_DataSet.Tables.Add(detailDt);
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // スキーマの設定
            DataTableSchemaSetting();

            // GRIDの初期設定
            GridInitialSetting();
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._mainDataIndex < 0)
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;
                
                // 画面入力許可制御処理
                ScreenPermissionControl(INSERT_MODE);
                
                // FreamのIndex/Tableバッファ保持
                this._mainIndexBuffer = -2;
                this._detailsIndexBuffer = this._detailsDataIndex;
                this._targetTableBuffer = this._targetTableName;
                
                //クローン作成
                CampaignLink campaignLink = new CampaignLink();
                this._campaignLinkCloneList = new CampaignLink[1];
                this._campaignLinkCloneList[0] = campaignLink.Clone();

                // グリッド行を追加
                this.tbsPartsList_AddRow();

                // フォーカス設定
                this.tNedit_CampaignCode.Focus();
            }
            else
            {
                // 詳細Gridの行数を取得
                int rowCnt = 0;         // 行数カウンタ
                int maxRow = this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows.Count;
                CampaignLink[] campaignLinkList = new CampaignLink[maxRow];

                // 選択キャンペーンの得意先情報を取得
                for (; rowCnt < maxRow; rowCnt++)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[rowCnt][S_CUSTOMER_GUID];
                    campaignLinkList[rowCnt] = (CampaignLink)this._detailTable[guid];
                }

                if (campaignLinkList[0].LogicalDeleteCode == 0)
                {
                        // 更新モード
                        this.Mode_Label.Text = UPDATE_MODE;

                        // 画面入力許可制御処理
                        ScreenPermissionControl(UPDATE_MODE);

                        // 画面展開処理
                        CampaignLinkToScreen(campaignLinkList);

                        tbsPartsList_AddRow();

                        //クローン作成
                        this._campaignLinkCloneList = new CampaignLink[maxRow];
                        for (int i = 0; i < maxRow; i++)
                        {
                            this._campaignLinkCloneList[i] = campaignLinkList[i].Clone();
                        }
                        
                        // フォーカス設定
                        this.Cancel_Button.Focus();
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 画面入力許可制御処理
                    ScreenPermissionControl(DELETE_MODE);

                    // 画面展開処理
                    CampaignLinkToScreen(campaignLinkList);

                    this.uGrid_Customer.Rows[0].Selected = false;
                    this.uGrid_Customer.ActiveCell = null;
                    this.uGrid_Customer.ActiveRow = null;
                    
                    //クローン作成
                    this._campaignLinkCloneList = new CampaignLink[maxRow];
                    for (int i = 0; i < maxRow; i++)
                    {
                        this._campaignLinkCloneList[i] = campaignLinkList[i].Clone();
                    }

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                // FreamのIndex/Tableバッファ保持
                this._mainIndexBuffer = this._mainDataIndex;
                this._detailsIndexBuffer = this._detailsDataIndex;
                this._targetTableBuffer = this._targetTableName;
            }
        }

        /// <summary>
        /// 画面許可制御処理
        /// </summary>
        /// <param name="screenMode">画面モード</param>
        /// <remarks>
        /// <br>Note       : 画面モード毎に入力／ボタンの許可を制御します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenPermissionControl(string screenMode)
        {
            // 新規
            if (screenMode.Equals(INSERT_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;
                this.uButton_CampaignGuide.Visible = true;
                this.uButton_CampaignGuide.Enabled = true;
                this.Guid_Button.Visible = true;

                // 入力設定
                this.tNedit_CampaignCode.Enabled = true;
                this.uGrid_Customer.Enabled = true;
            }
            // 更新
            else if (screenMode.Equals(UPDATE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;
                this.uButton_CampaignGuide.Visible = true;
                this.uButton_CampaignGuide.Enabled = false;
                this.Guid_Button.Visible = true;

                // 入力設定
                this.tNedit_CampaignCode.Enabled = false;
                this.uGrid_Customer.Enabled = true;
            }
            // 削除
            else if (screenMode.Equals(DELETE_MODE))
            {
                // ボタン設定
                this.Ok_Button.Visible = false;
                this.Delete_Button.Visible = true;
                this.Revive_Button.Visible = true;
                this.Renewal_Button.Visible = false;
                this.uButton_CampaignGuide.Visible = true;
                this.uButton_CampaignGuide.Enabled = false;
                this.Guid_Button.Visible = false;

                // 入力設定
                this.tNedit_CampaignCode.Enabled = false;
                this.uGrid_Customer.Enabled = false;
            }
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tNedit_CampaignCode.Clear();           // キャンペーンコード
            this.tEdit_CampaignName.Text = "";          // キャンペーン名

            this._bindTable.Clear();                    // Grid行のクリア
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <param name="loginID">ログインID</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            // キャンペーンコード
            if (this.tNedit_CampaignCode.Text == "0" || this.tNedit_CampaignCode.Text.Trim() == "")
            {
                control = this.tNedit_CampaignCode;
                message = this.Campaign_Label.Text + "を入力して下さい。";
                return false;
            }
            else if (this._campaignLinkAcs.GetCampaignName(this.tNedit_CampaignCode.GetInt()) == "")
            {
                control = this.tNedit_CampaignCode;
                message = "該当するキャンペーンコードが存在しません。";
                return false;
            }

            // Grid
            if (this._bindTable.Rows.Count == 0)
            {
                control = this.uGrid_Customer;
                message = "得意先コードを１件以上登録して下さい。";
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
                    message = "得意先コードが登録されていません。";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 対象得意先設定 情報登録処理
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 対象得意先設定 情報登録を行います。</br>
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
            
            // 画面入力チェック
            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            if (this._mainDataIndex >= 0)
            {
                // 更新時は、更新対象と削除対象を取得
                this.UpdateCompare(out updateList, out deleteList);

                // 削除対象があれば該当レコードを削除
                if (deleteList.Count != 0)
                {
                    status = this._campaignLinkAcs.Delete(deleteList);
                }
            }
            else
            {
                //新規の場合、画面情報を条件クラスに設定
                this.DispToCampaignLink(ref updateList);
            }
            

            // 登録／更新処理
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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            PG_ID,				        		// アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン

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
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "SaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._campaignLinkAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

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

            // DataSet展開処理
            int index = 0;
            
            if (this._mainDataIndex >= 0)
            {
                // 削除可能なDataSetの行数を取得
                int delOK = deleteList.Count - updateList.Count;

                foreach (CampaignLink campaignLink in deleteList)
                {
                    // 削除レコードを明細GridのTableから削除
                    this._detailTable.Remove(campaignLink.FileHeaderGuid);
                }

                // 更新レコードをDataSetに反映
                foreach (CampaignLink campaignLink in updateList)
                {
                    // 明細GridのDataSetを更新
                    index = this._detailsDataIndex;
                    CustomerToDataSet(campaignLink.Clone(), index);
                }
            }
            else
            {
                // メインGridのDataSetに追加
                index = this._mainTable.Count;
                CampaignLinkToDataSet(((CampaignLink)updateList[0]).Clone(), index);
            }

            return true;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_800_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            PG_ID,		        				// アセンブリＩＤまたはクラスＩＤ
                            PG_NAME,							// プログラム名称
                            "ExclusiveTransaction",				// 処理名称
                            operation,							// オペレーション
                            ERR_801_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            erObject,							// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        break;
                    }
            }
        }

        #endregion

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // キャンペーンコード
            int campaignCode = tNedit_CampaignCode.GetInt();
            
            for (int i = 0; i < this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsCampaignCode = (int)this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[i][I_CAMPAIGN_CODE];
                if (campaignCode == dsCampaignCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[I_CAMPAIGN_TABLE].Rows[i][I_DELETEDATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PG_ID,						        // アセンブリＩＤまたはクラスＩＤ
                          //"入力されたコードのキャンペーン関連マスタ情報は既に削除されています。", // 表示するメッセージ   // DEL 2011/05/06
                          "入力されたコードの対象得意先設定マスタ情報は既に削除されています。", 			// 表示するメッセージ   // ADD 2011/05/06
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // キャンペーンコード、名称のクリア
                        tNedit_CampaignCode.Clear();
                        tEdit_CampaignName.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PG_ID,                                  // アセンブリＩＤまたはクラスＩＤ
                        //"入力されたコードのキャンペーン関連マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ  // DEL 2011/05/06
                        "入力されたコードの対象得意先設定マスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ            // ADD 2011/05/06
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 一時的に詳細テーブルを更新
                                int selectedMainDataIndex = GetSelectedMainDataIndex();

                                this._mainDataIndex = i;
                                this._detailsDataIndex = 0;
                                int dummy = 0;
                                DetailsDataSearch(ref dummy, 0);

                                // 画面再描画
                                ScreenClear();
                                ScreenReconstruction();

                                // 詳細テーブルを元に戻す
                                this._mainDataIndex = selectedMainDataIndex;
                                dummy = 0;
                                DetailsDataSearch(ref dummy, 0);

                                // TODO:モード変更可能フラグを落とす
                                CanChangeMode = false;
                                break;
                            }
                        case DialogResult.No:
                            {
                                // キャンペーンコード、名称のクリア
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
        /// 現在、選択されているメインデータのインデックスを取得します。
        /// </summary>
        /// <returns>現在、選択されているメインデータのインデックス</returns>
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
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            return GetCustomerName(customerCode, false);
        }

        /// <summary>
        /// 得意先名称を取得します。
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="throwsExceptionWhenCodeIsNotFound">該当する得意先コードがない場合、例外を投入するフラグ</param>
        /// <returns>得意先名称</returns>
        /// <exception cref="ArgumentException">
        /// <c>throwsExceptionWhenCodeIsNotFound</c>が<c>true</c>のとき、
        /// 得意先マスタに該当する得意先コードが存在しない場合、投入されます。
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
        /// キャッシュ情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先の名称をキャッシュ化。</br>
        /// </remarks>
        private void GetCacheData()
        {
            // 得意先名称リスト取得
            this.GetCustomerNameList();

        }

        /// <summary>
        /// 得意先名称リスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先名称のリストを取得します。</br>
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
                    // 論理削除データは読み込まない
                    if (customerSearchRet.LogicalDeleteCode != 1)
                    {
                        this._customerList.Add(customerSearchRet);
                    }
                }
            }
        }

        /// <summary>
        /// Control.VisibleChange イベント(UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_VisibleChanged(object sender, System.EventArgs e)
        {
            // アクティブセル・アクティブ行を無効
            this.uGrid_Customer.ActiveCell = null;
        }

        /// <summary>
        /// Control.KeyDown イベント (UI_UltraGrid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : キーが押されたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            // アクティブセルがnullの時は処理を行わず終了
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return;
            }

            // グリッド状態取得()
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

            //ドロップダウン状態の時は処理しない(UltraGridのデフォルトの動きにする)
            Control nextControl = null;
            if ((e.Control == false) && (e.Shift == false) && (e.Alt == false) &&
                ((status & Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown) != Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown))
            {

                switch (e.KeyCode)
                {
                    // ↑キー
                    case Keys.Up:
                        {
                            // 上のセルへ移動
                            nextControl = MoveAboveCell();
                            e.Handled = true;
                            break;
                        }
                    // ↓キー
                    case Keys.Down:
                        {
                            // 下のセルへ移動
                            nextControl = MoveBelowCell();
                            e.Handled = true;
                            break;
                        }
                    // ←キー
                    case Keys.Left:
                        {
                            // 上のセルへ移動
                            nextControl = MoveAboveCell();
                            e.Handled = true;

                            break;
                        }
                    // →キー
                    case Keys.Right:
                        {
                            // 下のセルへ移動
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
        ///	ultraGrid.AfterExitEditMode イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのセル編集終了イベント処理。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Customer.ActiveCell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Customer.ActiveCell;

            // 得意先コード
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                string code = cell.Value != null ? cell.Value.ToString() : string.Empty;
                this._gridUpdFlg = true;

                if ((code != "") && (int.Parse(code) != 0))
                {
                    // 入力有
                    int customerCode = int.Parse(code);
                    string customerName = GetCustomerName(customerCode);
                    
                    if (customerName != "")
                    {
                        bool AddFlg = true;     // 追加フラグ
                        int maxRow = this._bindTable.Rows.Count;

                        // 得意先コードの重複チェック
                        for (int i = 0; i < maxRow; i++)
                        {
                            if (cell.Row.Index == i)
                            {
                                // 同じ行数はSKIP
                                continue;
                            }

                            string wkTbsPartsCode = this._bindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE].ToString();
                            if ((wkTbsPartsCode != "") && (int.Parse(wkTbsPartsCode) == customerCode))
                            {
                                // 重複コード有
                                AddFlg = false;
                                break;
                            }
                        }

                        if (AddFlg)
                        {
                            // 得意先コードの追加
                            // 選択した情報をCellに設定
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = customerCode.ToString("d08");   // 得意先コード
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = customerName;                   // 得意先品名

                            if ((int)cell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                            {
                                // 最終行の場合、行を追加
                                this.tbsPartsList_AddRow();
                            }
                        }
                        else
                        {
                            // 重複エラーを表示
                            TMsgDisp.Show(
                                this,								    // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                                PG_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                                "選択した得意先コードが重複しています。",	    // 表示するメッセージ 
                                0,									    // ステータス値
                                MessageBoxButtons.OK);				    // 表示するボタン

                            // 得意先コード、得意先名をクリア
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // 得意先コード
                            cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // 得意先名

                            // Grid変更なし
                            this._gridUpdFlg = false;
                        }
                    }
                    else
                    {
                        // 論理削除データは設定不可
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先コード [" + customerCode.ToString("d08") + "] に該当するデータが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // 得意先コード、得意先名をクリア
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // 得意先コード
                        cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // 得意先名

                        // Grid変更なし
                        this._gridUpdFlg = false;
                    }
                }
                else
                {
                    // 未入力
                    // 得意先コード、得意先名をクリア
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = "";     // 得意先コード
                    cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = "";     // 得意先名
                }
            }
        }

        /// <summary>
        ///	ultraGrid.KeyPress イベント(Cell)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのキー押下イベント処理。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Customer.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Customer.ActiveCell;

            // 得意先コードの入力桁数チェック
            if (cell.Column.Key == MY_SCREEN_CUSTOMER_CODE)
            {
                // 編集モード中？
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
        /// 下のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを下のセルに移動します。</br>
        /// <br></br>
        /// </remarks>
        private Control MoveBelowCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

            // 最下段セルの時
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowLast) == Infragistics.Win.UltraWinGrid.UltraGridState.RowLast)
            {
                // 保存ボタンへ移動
                // --- CHG 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                //return this.Ok_Button;
                return this.Renewal_Button;
                // --- CHG 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
            }
            // 最下段セルでない時
            else
            {
                // セル移動前アクティブセルのインデックス
                int prevCol = this.uGrid_Customer.ActiveCell.Column.Index;
                int prevRow = this.uGrid_Customer.ActiveCell.Row.Index;

                // 下のセルに移動
                performActionResult = this.uGrid_Customer.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);

                // セルが移動していない時
                if ((prevCol == this.uGrid_Customer.ActiveCell.Column.Index) &&
                    (prevRow == this.uGrid_Customer.ActiveCell.Row.Index))
                {
                    // 保存ボタンへ移動
                    // --- CHG 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                    //return this.Ok_Button;
                    return this.Renewal_Button;
                    // --- CHG 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<
                }
                // セルが移動してる
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
        /// 上のセルへ移動処理
        /// </summary>
        /// <returns>次のコントロール</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアクティブセルを上のセルに移動します。</br>
        /// <br></br>
        /// </remarks>
        private Control MoveAboveCell()
        {
            bool performActionResult;

            // アクティブセルがnull
            if (this.uGrid_Customer.ActiveCell == null)
            {
                return null;
            }

            // グリッド状態取得
            Infragistics.Win.UltraWinGrid.UltraGridState status = this.uGrid_Customer.CurrentState;

            // 最上段セルの時
            if ((status & Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst) == Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst)
            {
                // 移動しない
                //return null;
                // キャンペーンコードへ移動
                return this.tNedit_CampaignCode;
            }
            // 最前セルでない時
            else
            {
                // 上のセルに移動
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
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	次の入力可能なセルにフォーカスを移動する処理を行います。<br />
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
                            // アクティブセルがボタン
                            moved = false;
                            int rowIdx = this.uGrid_Customer.ActiveCell.Row.Index;
                            if ((this._bindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "") &&
                                (this._gridUpdFlg))
                            {
                                // 得意先コードが未入力の場合(得意先コード取得失敗等は除く)
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
        /// 前入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はPrevに移動させない false:ActiveCellに関係なくPrevに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// Note			:	前の入力可能なセルにフォーカスを移動する処理を行います。<br />
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
                            // アクティブセルがボタン
                            moved = false;
                            int rowIdx = this.uGrid_Customer.ActiveCell.Row.Index;
                            if (this._bindTable.Rows[rowIdx][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                            {
                                // 得意先コードが未入力の場合
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
        ///	ultraGrid.Click イベント(Cell Button)
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDのCell Buttonをクリックイベント処理。</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_Customer_ClickCellButton(object sender, CellEventArgs e)
        {
           
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._bindTable.Rows.Count;

                // 得意先コードの重複チェック
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
                        // 重複コード有
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    // 選択した情報をCellに設定
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_CODE].Value = _customerCode.ToString("d08");    // 得意先コード
                    e.Cell.Row.Cells[MY_SCREEN_CUSTOMER_NAME].Value = _customerName;                    // 得意先名

                    if ((int)e.Cell.Row.Cells[MY_SCREEN_ODER].Value == this._bindTable.Rows.Count)
                    {
                        // 最終行の場合、行を追加
                        this.tbsPartsList_AddRow();
                    }

                    // 次のコントロールへフォーカスを移動
                    this.MoveNextAllowEditCell(false);
                }
                else
                {
                    // 重複エラーを表示
                    TMsgDisp.Show(
                        this,								    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // エラーレベル
                        PG_ID,      						    // アセンブリＩＤまたはクラスＩＤ
                        "選択した得意先コードが重複しています。",	// 表示するメッセージ 
                        0,									    // ステータス値
                        MessageBoxButtons.OK);				    // 表示するボタン

                    ((Control)sender).Focus();
                }
            }
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Control.Click イベント(DeleteRow_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void DeleteRow_Button_Click(object sender, EventArgs e)
        {
            string message = "";

            if (this.uGrid_Customer.Rows.Count < 1)
            {
                // デバッグ用
                this.tbsPartsList_AddRow();
            }

            if (this.uGrid_Customer.ActiveRow == null)
            {
                // 削除する行が未選択
                message = "削除する得意先コードを選択して下さい。";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.uGrid_Customer.Focus();
            }
            else if (this.uGrid_Customer.Rows.Count == 1)
            {
                // Gridの行数が1行の場合は削除不可
                message = "全ての得意先を削除はできません";

                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.uGrid_Customer.Focus();
            }
            else
            {
                // UI画面のGridから選択行を削除
                // 選択行のindexを取得
                int delIndex = (int)this.uGrid_Customer.ActiveRow.Cells[MY_SCREEN_ODER].Value - 1;

                // 選択行の削除
                this.uGrid_Customer.ActiveRow.Delete();

                // 削除後のGrid行数を取得
                int maxRow = this._bindTable.Rows.Count;

                for (int index = delIndex; index < maxRow; index++)
                {
                    // 削除した行以降の表示順位を更新する
                    this._bindTable.Rows[index][MY_SCREEN_ODER] = index + 1;
                }
            }
        }

        /// <summary>
        /// Control.Click イベント(Guid_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Guid_Button_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerCode != 0)
            {
                bool AddFlg = true;     // 追加フラグ
                int maxRow = this._bindTable.Rows.Count;

                // 得意先コードの重複チェック
                for (int i = 0; i < maxRow; i++)
                {
                    string code = this._bindTable.Rows[i][MY_SCREEN_CUSTOMER_CODE].ToString();
                    if ((code != "") && (int.Parse(code) == _customerCode))
                    {
                        // 重複コード有
                        AddFlg = false;
                        break;
                    }
                }

                if (AddFlg)
                {
                    int lastRow = this._bindTable.Rows.Count - 1;

                    if (this._bindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE].ToString() == "")
                    {
                        // 最終行が空き
                        this._bindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_CODE] = _customerCode.ToString("d08");
                        this._bindTable.Rows[lastRow][MY_SCREEN_CUSTOMER_NAME] = _customerName;
                    }
                    else
                    {
                        // ガイドで選択した得意先コードを追加
                        DataRow bindRow;

                        bindRow = this._bindTable.NewRow();

                        // 得意先情報をGridに追加
                        bindRow[MY_SCREEN_ID] = "";
                        bindRow[MY_SCREEN_ODER] = this._bindTable.Rows.Count + 1;
                        bindRow[MY_SCREEN_CUSTOMER_CODE] = _customerCode.ToString("d08");
                        bindRow[MY_SCREEN_CUSTOMER_NAME] = _customerName;

                        this._bindTable.Rows.Add(bindRow);
                    }

                    // 新規行を追加
                    this.tbsPartsList_AddRow();

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    // 重複エラーを表示
                    string message = "選択した得意先コードは選択済です。";

                    TMsgDisp.Show(
                        this,								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                        PG_ID,      						// アセンブリＩＤまたはクラスＩＤ
                        message,							// 表示するメッセージ 
                        0,									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン

                    ((Control)sender).Focus();
                }
            }           
            else
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// グリッドバインド処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 配列項目をグリッドへバインドします。</br>
        /// <br></br>
        /// </remarks>
        private void DataTableSchemaSetting()
        {
            _bindTable.Columns.Clear();

            // スキーマの設定
            _bindTable.Columns.Add(MY_SCREEN_ID, typeof(string));
            _bindTable.Columns.Add(MY_SCREEN_ODER, typeof(int));
            _bindTable.Columns.Add(MY_SCREEN_CUSTOMER_CODE, typeof(string));
            _bindTable.Columns.Add(MY_SCREEN_GUID, typeof(Button));
            _bindTable.Columns[MY_SCREEN_GUID].Caption = "";
            _bindTable.Columns.Add(MY_SCREEN_CUSTOMER_NAME, typeof(string));
        }

        /// <summary>
        ///	UI画面のGRID初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDの初期設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // データソースへ追加
            this.uGrid_Customer.DataSource = _bindTable;

            // グリッドの背景色
            this.uGrid_Customer.DisplayLayout.Appearance.BackColor = Color.White;
            this.uGrid_Customer.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
            this.uGrid_Customer.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 行の追加不可
            this.uGrid_Customer.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            // 行のサイズ変更不可
            this.uGrid_Customer.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            // 行の削除不可
            this.uGrid_Customer.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            // 列の移動不可
            this.uGrid_Customer.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            // 列のサイズ変更不可
            this.uGrid_Customer.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            // 列の交換不可
            this.uGrid_Customer.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // フィルタの使用不可
            this.uGrid_Customer.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            
            // タイトルの外観設定
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            this.uGrid_Customer.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // グリッドの選択方法を設定（セル単体の選択のみ許可）
            this.uGrid_Customer.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Customer.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            // 互い違いの行の色を変更
            this.uGrid_Customer.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクタ表示無し
            this.uGrid_Customer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            
            this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = Color.FromArgb(247, 227, 156);
            this.uGrid_Customer.DisplayLayout.Override.ActiveCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.uGrid_Customer.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            
            // 「ID」は編集不可（固定項目として設定）
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].TabStop = false;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].CellAppearance.ForeColor = Color.White;

            // 得意先コード列の設定
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellActivation = Activation.AllowEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].TabStop = true;

            // ガイドボタンの設定
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellActivation = Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].ButtonDisplayStyle = ButtonDisplayStyle.Always;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].TabStop = true;

            // BL品名列の設定
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].CellActivation = Activation.NoEdit;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].TabStop = false;

            //特定列を非表示に
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ID].Hidden = true;

            // セルの幅の設定
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_ODER].Width = 50;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_CODE].Width = 100;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_GUID].Width = 20;
            this.uGrid_Customer.DisplayLayout.Bands[0].Columns[MY_SCREEN_CUSTOMER_NAME].Width = 380;

            // 選択行の外観設定
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // アクティブ行の外観設定
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            this.uGrid_Customer.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // 行セレクタの外観設定
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
            this.uGrid_Customer.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 罫線の色を変更
            this.uGrid_Customer.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
        }

        /// <summary>
        ///	Grid 新規行の追加
        /// </summary>
        /// <remarks>
        /// <br>Note	   : GRIDに新規行を追加します。</br>
        /// <br></br>
        /// </remarks>
        private void tbsPartsList_AddRow()
        {
            if (this._bindTable.Rows.Count == 99)
            {
                // MAX99行とする
                return;
            }

            // ガイドで選択した得意先コードを追加
            DataRow bindRow;

            bindRow = this._bindTable.NewRow();

            // 得意先情報をGridに追加
            bindRow[MY_SCREEN_ID] = "";
            bindRow[MY_SCREEN_ODER] = this._bindTable.Rows.Count + 1;
            bindRow[MY_SCREEN_CUSTOMER_CODE] = "";
            bindRow[MY_SCREEN_CUSTOMER_NAME] = "";

            this._bindTable.Rows.Add(bindRow);
        }

        /// <summary>
        /// 更新前後のデータ比較と更新対象格納処理
        /// </summary>
        /// <param name="updateList">更新対象レコードを格納</param>
        /// <param name="deleteList">削除対象レコードを格納</param>
        /// <remarks>
        /// <br>Note       : 更新前後のデータを比較して更新／削除対象データを格納します。</br>
        /// <br></br>
        /// </remarks>
        private void UpdateCompare(out ArrayList updateList, out ArrayList deleteList)
        {
            updateList = new ArrayList();
            deleteList = new ArrayList();

            CampaignLink campaignLink;
            
            // Form 明細Grid情報とUI画面のGridを取得して比較
            int index;
            int detailRowCnt = this._detailTable.Count;             // 明細Gridの行数
            int uiGridRowCnt = this._bindTable.Rows.Count;          // UI画面のGrid行数

            // 明細Grid情報の行数分を比較
            for (index = 0; index < detailRowCnt; index++)
            {
                // 明細Grid情報を取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_GUID];
                campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();

                if (index >= uiGridRowCnt)
                {
                    // 明細Grid行数がUI画面のGrid行数以上の場合はループを抜ける
                    break;
                }

                // UI画面のGridから得意先コードを取得
                string code = (string)this._bindTable.Rows[index][MY_SCREEN_CUSTOMER_CODE];
                int customerCode = 0;
                if (code != "")
                {
                    customerCode = Int32.Parse(code);
                }

                if (campaignLink.CustomerCode != customerCode)
                {
                    // 得意先コードが不一致の場合、明細Grid情報を削除対象に追加
                    deleteList.Add(campaignLink);

                    if (customerCode != 0)
                    {
                        // 主キーが変わるので、UI画面のGrid情報は新規追加となる
                        campaignLink = new CampaignLink();
                        campaignLink.EnterpriseCode = this._enterpriseCode;                 // 企業コード
                        campaignLink.CampaignCode = this.tNedit_CampaignCode.GetInt();      // キャンペーンコード
                        campaignLink.CustomerCode = customerCode;                           // 得意先コード
                        updateList.Add(campaignLink);
                    }
                }
            }

            if (detailRowCnt < uiGridRowCnt)
            {
                // 明細Gridの行数よりUI画面のGrid行数が多い
                for (index = detailRowCnt; index < uiGridRowCnt; index++)
                {
                    string code = (string)this._bindTable.Rows[index][MY_SCREEN_CUSTOMER_CODE];
                    int customerCode = 0;
                    if (code == "")
                    {
                        // 得意先コード未入力の行はSKIP
                        continue;
                    }
                    else
                    {
                        customerCode = Int32.Parse(code);
                    }

                    // 新規追加として更新対象に追加
                    campaignLink = new CampaignLink();
                    campaignLink.EnterpriseCode = this._enterpriseCode;                     // 企業コード
                    campaignLink.CampaignCode = this.tNedit_CampaignCode.GetInt();          // キャンペーンコード
                    campaignLink.CustomerCode = customerCode;                               // 得意先コード
                    updateList.Add(campaignLink);
                }
            }
            else if (uiGridRowCnt < detailRowCnt)
            {
                // 明細Gridの行数よりUI画面のGrid行数が少ない
                for (index = uiGridRowCnt; index < detailRowCnt; index++)
                {
                    // 削除対象に追加
                    Guid guid = (Guid)this.Bind_DataSet.Tables[S_CUSTOMER_TABLE].Rows[index][S_CUSTOMER_GUID];
                    campaignLink = ((CampaignLink)this._detailTable[guid]).Clone();
                    deleteList.Add(campaignLink);
                }
            }
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <param name="NumberFlg">数値入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// Note			:	押されたキーが数値のみ有効にする処理を行います。<br />
        /// <br></br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg, Boolean NumberFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }

            // 押されたキーが数値以外、かつ数値以外入力不可
            if (!Char.IsDigit(key) && !NumberFlg)
            {
                return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                // マイナス(小数点)が入力可能か？
                if (minusFlg == false)
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                // 小数点以下桁数が0か？
                if (priod == 0)
                {
                    return false;
                }
                else
                {
                    // 小数点が既に存在するか？
                    if (_strResult.Contains("."))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // 小数点が既に存在するか？
                if (_strResult.Contains("."))
                {
                    int index = _strResult.IndexOf('.');
                    string strDecimal = _strResult.Substring(index + 1);

                    if ((strDecimal.Length >= priod) && (selstart > index))
                    {
                        // 小数桁が入力可能桁数以上で、カーソル位置が小数点以降
                        return false;
                    }
                    else if (((keta - priod) < index))
                    {
                        // 整数部の桁数が入力可能桁数を超えた
                        return false;
                    }
                }
                else
                {
                    // 小数点桁数を前提に整数部の桁数を決定
                    if (((keta - priod) <= _strResult.Length))
                    {
                        return false;
                    }
                }
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart) + key
                       + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
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
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
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

            // 得意先コード
            _customerCode = customerSearchRet.CustomerCode;

            // 得意先名称
            _customerName = customerSearchRet.Snm.Trim();
        }

        /// <summary>
        /// 最新情報処理
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // 最新情報取得
            GetCacheData();
            this._campaignLinkAcs.Renewal();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PG_ID,						        // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
    }
}
