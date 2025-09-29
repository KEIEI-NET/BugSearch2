//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      フォームクラス                                  //
//                  :   PMKHN09721U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
    /// ロールグループ名称設定マスタフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : ロールグループ名称設定マスタを行います。
    ///                   IMasterMaintenanceMultiTypeを実装しています。</br>
    /// </remarks>
    public class PMKHN09721UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel RoleGroupCode_uLabel;
        private Broadleaf.Library.Windows.Forms.TNedit RoleGroupCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel RoleGroupName_uLabel;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private UiSetControl uiSetControl1;
        private TEdit RoleGroupName_tEdit;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        #endregion

        #region -- Constructor --
        /// <summary>
        /// ロールグループ名称設定マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : ロールグループ名称設定マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09721UA()
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

            //  企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._dataIndex = -1;
            this._roleGroupNameStAcs = new RoleGroupNameStAcs();
            this._totalCount = 0;
            this._roleGroupNameStTable = new Hashtable();

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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09721UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RoleGroupCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RoleGroupCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.RoleGroupName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.RoleGroupName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGroupCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGroupName_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(543, 126);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 15;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(416, 126);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 184);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(686, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(563, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "更新モード";
            // 
            // RoleGroupCode_uLabel
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.RoleGroupCode_uLabel.Appearance = appearance10;
            this.RoleGroupCode_uLabel.Location = new System.Drawing.Point(16, 44);
            this.RoleGroupCode_uLabel.Name = "RoleGroupCode_uLabel";
            this.RoleGroupCode_uLabel.Size = new System.Drawing.Size(165, 24);
            this.RoleGroupCode_uLabel.TabIndex = 171;
            this.RoleGroupCode_uLabel.Text = "ロールグループコード";
            // 
            // RoleGroupCode_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.RoleGroupCode_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.RoleGroupCode_tNedit.Appearance = appearance9;
            this.RoleGroupCode_tNedit.AutoSelect = true;
            this.RoleGroupCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.RoleGroupCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.RoleGroupCode_tNedit.DataText = "";
            this.RoleGroupCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RoleGroupCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.RoleGroupCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.RoleGroupCode_tNedit.Location = new System.Drawing.Point(201, 44);
            this.RoleGroupCode_tNedit.MaxLength = 4;
            this.RoleGroupCode_tNedit.Name = "RoleGroupCode_tNedit";
            this.RoleGroupCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.RoleGroupCode_tNedit.Size = new System.Drawing.Size(59, 24);
            this.RoleGroupCode_tNedit.TabIndex = 0;
            // 
            // RoleGroupName_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.RoleGroupName_uLabel.Appearance = appearance22;
            this.RoleGroupName_uLabel.Location = new System.Drawing.Point(16, 74);
            this.RoleGroupName_uLabel.Name = "RoleGroupName_uLabel";
            this.RoleGroupName_uLabel.Size = new System.Drawing.Size(165, 24);
            this.RoleGroupName_uLabel.TabIndex = 179;
            this.RoleGroupName_uLabel.Text = "ロールグループ名称";
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
            this.Revive_Button.Location = new System.Drawing.Point(415, 126);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 14;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(287, 126);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 13;
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
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(286, 126);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 13;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // RoleGroupName_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.RoleGroupName_tEdit.ActiveAppearance = appearance12;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Left";
            this.RoleGroupName_tEdit.Appearance = appearance29;
            this.RoleGroupName_tEdit.AutoSelect = true;
            this.RoleGroupName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.RoleGroupName_tEdit.DataText = "";
            this.RoleGroupName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RoleGroupName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.RoleGroupName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.RoleGroupName_tEdit.Location = new System.Drawing.Point(201, 74);
            this.RoleGroupName_tEdit.MaxLength = 20;
            this.RoleGroupName_tEdit.Name = "RoleGroupName_tEdit";
            this.RoleGroupName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.RoleGroupName_tEdit.TabIndex = 1;
            // 
            // PMKHN09721UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(686, 207);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.RoleGroupName_tEdit);
            this.Controls.Add(this.RoleGroupName_uLabel);
            this.Controls.Add(this.RoleGroupCode_tNedit);
            this.Controls.Add(this.RoleGroupCode_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09721UA";
            this.Text = "ロールグループ名称設定";
            this.Load += new System.EventHandler(this.PMKHN09721UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09721UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09721UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.RoleGroupCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGroupName_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region -- Events --
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        private RoleGroupNameStAcs _roleGroupNameStAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _roleGroupNameStTable;

        private SecInfoAcs _secInfoAcs = new SecInfoAcs();

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 保存比較用Clone
        private RoleGroupNameSt _roleGroupNameStClone;

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndexバッファ（メインフレーム最小化対応）
        private int _indexBuf;

        // 新規モードからモード変更対応
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMKHN09721U";    // プログラムID

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

        // FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";

        private const string VIEW_ROLEGROUP_CODE = "ロールグループコード";
        private const string VIEW_ROLEGROUP_NAME = "ロールグループ名称";

        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 入力チェック
        private const string ct_InputError = "の入力が不正です";
        private const string ct_NoInput = "を入力して下さい";

        #endregion

        #region -- Main --
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09721UA());
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
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note        : フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
        /// <br></br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

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
            ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._roleGroupNameStTable.Clear();

            // 全検索
            status = this._roleGroupNameStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;

                        foreach (RoleGroupNameSt roleGroupNameSt in retList)
                        {
                            // ロールグループ名称設定情報クラスのデータセット展開処理
                            RoleGroupNameStToDataSet(roleGroupNameSt.Clone(), index);
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
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,            // エラーレベル
                            PROGRAM_ID,                             // アセンブリID
                            this.Text,                              // プログラム名称
                            "Search",                               // 処理名称
                            TMsgDisp.OPE_GET,                       // オペレーション
                            "読み込みに失敗しました。",             // 表示するメッセージ
                            status,                                 // ステータス値
                            this._roleGroupNameStAcs,               // エラーが発生したオブジェクト
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
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameStTable[guid];

            int status;

            // ロールグループ名称設定情報の論理削除処理
            status = this._roleGroupNameStAcs.LogicalDelete(ref roleGroupNameSt);
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
                            this._roleGroupNameStAcs,           // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                        return status;
                    }
            }

            // ロールグループ名称設定情報クラスのデータセット展開処理
            RoleGroupNameStToDataSet(roleGroupNameSt.Clone(), this.DataIndex);

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
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br></br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ロールグループコード
            appearanceTable.Add(VIEW_ROLEGROUP_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ロールグループ名称
            appearanceTable.Add(VIEW_ROLEGROUP_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
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
                RoleGroupNameSt roleGroupNameSt = new RoleGroupNameSt();
                //クローン作成
                this._roleGroupNameStClone = roleGroupNameSt.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToRoleGroupNameSt(ref this._roleGroupNameStClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.RoleGroupCode_tNedit.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameStTable[guid];

                // ロールグループ名称設定クラス画面展開処理
                RoleGroupNameStToScreen(roleGroupNameSt);

                if (roleGroupNameSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.RoleGroupName_tEdit.Focus();

                    // クローン作成
                    this._roleGroupNameStClone = roleGroupNameSt.Clone();

                    // 画面情報を比較用クローンにコピーします
                    ScreenToRoleGroupNameSt(ref this._roleGroupNameStClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

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
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;
                        this.RoleGroupName_tEdit.Enabled = true;

                        if (mode == INSERT_MODE)
                        {
                            // 新規モード
                            this.RoleGroupCode_tNedit.Enabled = true;
                        }
                        else
                        {
                            // 更新モード
                            this.RoleGroupCode_tNedit.Enabled = false;
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.RoleGroupCode_tNedit.Enabled = false;
                        this.RoleGroupName_tEdit.Enabled = false;

                        break;
                    }
            }
        }

        /// <summary>
        /// ロールグループ名称設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="roleGroupNameSt">ロールグループ名称設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : ロールグループ設定クラスをデータセットに格納します。</br>
        /// <br></br>
        /// </remarks>
        private void RoleGroupNameStToDataSet(RoleGroupNameSt roleGroupNameSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (roleGroupNameSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = roleGroupNameSt.UpdateDateTimeJpInFormal;
            }

            // ロールグループコード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ROLEGROUP_CODE] = roleGroupNameSt.RoleGroupCode;

            // ロールグループ名称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ROLEGROUP_NAME] = roleGroupNameSt.RoleGroupName;

            // Guid
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = roleGroupNameSt.FileHeaderGuid;

            if (this._roleGroupNameStTable.ContainsKey(roleGroupNameSt.FileHeaderGuid) == true)
            {
                this._roleGroupNameStTable.Remove(roleGroupNameSt.FileHeaderGuid);
            }
            this._roleGroupNameStTable.Add(roleGroupNameSt.FileHeaderGuid, roleGroupNameSt);
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
            DataTable roleGroupNameStTable = new DataTable(VIEW_TABLE);

            // Addを行う順番が、列の表示順位となります。

            roleGroupNameStTable.Columns.Add(DELETE_DATE, typeof(string));                  // 削除日

            roleGroupNameStTable.Columns.Add(VIEW_ROLEGROUP_CODE, typeof(int));             // ロールグループコード
            roleGroupNameStTable.Columns.Add(VIEW_ROLEGROUP_NAME, typeof(string));          // ロールグループ名称

            roleGroupNameStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));             // Guid

            this.Bind_DataSet.Tables.Add(roleGroupNameStTable);
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
            this.RoleGroupCode_tNedit.DataText = "";                // ロールグループコード
            this.RoleGroupName_tEdit.DataText = "";                 // ロールグループ名称
        }

        /// <summary>
        /// ロールグループ名称設定クラス画面展開処理
        /// </summary>
        /// <param name="roleGroupNameSt">ロールグループ名称設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : ロールグループ名称設定オブジェクトから画面にデータを展開します。</br>
        /// <br></br>
        /// </remarks>
        private void RoleGroupNameStToScreen(RoleGroupNameSt roleGroupNameSt)
        {
            // ロールグループコード
            this.RoleGroupCode_tNedit.SetInt(roleGroupNameSt.RoleGroupCode);

            // ロールグループ名称
            this.RoleGroupName_tEdit.DataText = roleGroupNameSt.RoleGroupName;
        }

        /// <summary>
        /// 画面情報ロールグループ名称設定クラス格納処理
        /// </summary>
        /// <param name="roleGroupNameSt">ロールグループ名称設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からロールグループ名称設定オブジェクトにデータを格納します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToRoleGroupNameSt(ref RoleGroupNameSt roleGroupNameSt)
        {
            if (roleGroupNameSt == null)
            {
                // 新規の場合
                roleGroupNameSt = new RoleGroupNameSt();
            }

            //企業コード
            roleGroupNameSt.EnterpriseCode = this._enterpriseCode;

            // ロールグループコード
            roleGroupNameSt.RoleGroupCode = this.RoleGroupCode_tNedit.GetInt();

            // ロールグループ名称
            roleGroupNameSt.RoleGroupName = this.RoleGroupName_tEdit.DataText;
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

            // 比較用クローンクリア
            this._roleGroupNameStClone = null;

            // フォームを非表示化する。
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
        /// ロールグループ名称設定画面入力チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ロールグループ名称設定画面の入力チェックをします。</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // ロールグループコード
            if (this.RoleGroupCode_tNedit.DataText == "")
            {
                message = this.RoleGroupCode_uLabel.Text + "を設定して下さい。";
                control = this.RoleGroupCode_tNedit;
                return false;
            }

            // ロールグループ名称
            if (this.RoleGroupName_tEdit.DataText == "")
            {
                message = this.RoleGroupName_uLabel.Text + "を設定して下さい。";
                control = this.RoleGroupName_tEdit;
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

            RoleGroupNameSt roleGroupNameSt = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                roleGroupNameSt = ((RoleGroupNameSt)this._roleGroupNameStTable[guid]).Clone();
            }

            // 画面情報を取得
            ScreenToRoleGroupNameSt(ref roleGroupNameSt);
            // 登録・更新処理
            int status = this._roleGroupNameStAcs.Write(ref roleGroupNameSt);

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

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

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
                        TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,            // エラーレベル
                            PROGRAM_ID,                             // アセンブリID
                            this.Text,                              // プログラム名称
                            "SaveProc",                             // 処理名称
                            TMsgDisp.OPE_UPDATE,                    // オペレーション
                            "登録に失敗しました。",                 // 表示するメッセージ
                            status,                                 // ステータス値
                            this._roleGroupNameStAcs,               // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                   // 表示するボタン
                            MessageBoxDefaultButton.Button1);       // 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return false;
                    }
            }

            // ロールグループ名称設定情報クラスのデータセット展開処理
            RoleGroupNameStToDataSet(roleGroupNameSt, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

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
            RoleGroupCode_tNedit.Focus();

            control = RoleGroupCode_tNedit;
        }

        # endregion

        # region -- Control Events --
        /// <summary>
        /// Form.Load イベント(PMKHN09721UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09721UA_Load(object sender, System.EventArgs e)
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
        }

        /// <summary>
        /// Form.Closing イベント(PMKHN09721UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note        : フォームを閉じる前に、ユーザーがフォームを閉じ
        ///                   ようとしたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09721UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Form.VisibleChanged イベント(PMKHN09721UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォームの表示・非表示が切り替えられ
        ///                   たときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09721UA_VisibleChanged(object sender, System.EventArgs e)
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
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

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
            if (!SaveProc())
            {
                return;
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
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                RoleGroupNameSt compareRoleGroupNameSt = new RoleGroupNameSt();

                compareRoleGroupNameSt = this._roleGroupNameStClone.Clone();
                ScreenToRoleGroupNameSt(ref compareRoleGroupNameSt);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._roleGroupNameStClone.Equals(compareRoleGroupNameSt))))
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
                                if (!SaveProc())
                                {
                                    return;
                                }
                                return;
                            }
                        case DialogResult.No:
                            {
                                // 画面非表示イベント
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                break;
                            }
                        default:
                            {
                                // 新規モードからモード変更対応
                                if (_modeFlg)
                                {
                                    RoleGroupCode_tNedit.Focus();
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
                this.Hide();
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
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameStTable[guid];

            // 完全削除処理
            int status = this._roleGroupNameStAcs.Delete(roleGroupNameSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._roleGroupNameStTable.Remove(roleGroupNameSt.FileHeaderGuid);

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
                            this._roleGroupNameStAcs,           // エラーが発生したオブジェクト
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
                this.Hide();
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
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            RoleGroupNameSt roleGroupNameSt = ((RoleGroupNameSt)this._roleGroupNameStTable[guid]).Clone();

            // 復活処理
            status = this._roleGroupNameStAcs.Revival(ref roleGroupNameSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ロールグループ名称設定情報クラスのデータセット展開処理
                        RoleGroupNameStToDataSet(roleGroupNameSt, this._dataIndex);
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
                            this._roleGroupNameStAcs,           // エラーが発生したオブジェクト
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
                this.Hide();
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

            // 新規モードからモード変更対応
            _modeFlg = false;

            if (e.PrevCtrl == RoleGroupCode_tNedit)
            {
                // 新規モードからモード変更対応
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // 最新情報ボタンは更新チェックから外す
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = RoleGroupCode_tNedit;
                    }
                }
            }
            else if (e.PrevCtrl == Renewal_Button)
            {
                // 最新情報ボタンからの遷移時、更新チェックを追加
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "RoleGroupCode_tNedit")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = RoleGroupCode_tNedit;
                    }
                }
            }
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            string msg = "入力されたコードのロールグループ名称設定情報が既に登録されています。\n編集を行いますか？";

            // ロールグループコード
            int roleGroupNameCode = RoleGroupCode_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsRoleGroupNameCode = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_ROLEGROUP_CODE];
                if (roleGroupNameCode == dsRoleGroupNameCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this,                     // 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,                           // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのロールグループ名称設定情報は既に削除されています。",           // 表示するメッセージ
                          0,                                    // ステータス値
                          MessageBoxButtons.OK);                // 表示するボタン
                        // ロールグループコードのクリア
                        RoleGroupCode_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ロールグループコードのクリア
                                RoleGroupCode_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,                           // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。",           // 表示するメッセージ
                          0,                                    // ステータス値
                          MessageBoxButtons.OK);                // 表示するボタン
        }


    }
}