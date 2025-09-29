//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP連携マスタ設定
// プログラム概要   : TSP連携マスタ設定を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11670305-00  作成担当 : 3H 劉星光
// 作 成 日 : 2020/11/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// TSP連携マスタ設定フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : TSP連携マスタの設定を行うクラスです。</br>
	/// <br>Programmer : 3H 劉星光</br>
	/// <br>Date       : 2020/11/23</br>
    /// </remarks>
	public class PMTSP09000UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region Private Members (Component)
		private System.Data.DataSet Bind_DataSet;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Save_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel CustomerNameCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SendCode_Title_Label;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerNameCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraButton CustomerGuide_Button;
		private Broadleaf.Library.Windows.Forms.TEdit CustomerName_tEdit;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private TComboEditor SendCode_tComboEditor;
        private TComboEditor DebitNSendCode_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DebitNSendCode_Title_Label;
        private TNedit SendEnterpriseCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel SendEnterpriseCode_Title_Label;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructor
		/// <summary>
        /// TSP連携設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : TSP連携設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 3H 劉星光</br>
		/// <br>Date       : 2020/11/23</br>
		/// </remarks>
        public PMTSP09000UA()
        {
            InitializeComponent();

            // プロパティ初期値
            this._canClose = false;                       // 閉じる機能（デフォルトtrue固定）
            this._canDelete = true;                       // 削除機能
            this._canLogicalDeleteDataExtraction = true;  // 論理削除データ表示機能
            this._canNew = true;                          // 新規作成機能
            this._canPrint = false;                       // 印刷機能
            this._canSpecificationSearch = false;         // 件数指定検索機能
            this._defaultAutoFillToColumn = false;        // 列サイズ自動調整機能

            // データセット初期化
            this.Bind_DataSet = new DataSet();
            this._tspCprtStWorkTable = new Hashtable();
            // データセット列情報構築処理
            DataSetColumnConstruction();
            this._customerInfoAcs = new CustomerInfoAcs();
            // TSP連携設定アクセス
            this._tspCprtStAcs = new TspCprtStAcs();
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // グリッド選択インデックス
            this._dataIndex = -1;
            // _GridIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;
        }
		#endregion

        #region Private Members
        /// <summary>TSP連携設定アクセスクラス</summary>
        private TspCprtStAcs _tspCprtStAcs;
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>ハッシュテーブ</summary>
        private Hashtable _tspCprtStWorkTable;
        /// <summary>得意先情報アクセスクラス</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>比較用clone</summary>	
        private TspCprtStWork _compareTspCprtStWork;
		
		// プロパティ用
		private bool	_canClose;
		private bool	_canDelete;
		private bool	_canLogicalDeleteDataExtraction;
		private bool	_canNew;
		private bool	_canPrint;
		private bool	_canSpecificationSearch;
		private int		_dataIndex;
		private bool	_defaultAutoFillToColumn;
        // _GridIndexバッファ（メインフレーム最小化対応）
        private int     _indexBuf;
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;

        /// <summary>プログラムID</summary>
        private const string CT_PGID = "PMTSP09000U";

		// FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
        /// <summary>テーブル名称</summary>
        public static readonly string TSPCPRTST_TABLE = "TSPCPRTST";
        /// <summary>削除日</summary>
		private const string DELETE_DATE				= "削除日";
        /// <summary>得意先コード</summary>
        private const string CUSTOMERCODE_TITLE         = "得意先コード";
        /// <summary>送信区分</summary>
        private const string SENDCODE_TITLE             = "送信区分";
        /// <summary>赤伝送信区分</summary>
        private const string DEBITNSENDCODE_TITLE       = "赤伝送信区分";
        /// <summary>企業コード</summary>
        private const string SENDENTERPRISECODE_TITLE   = "企業コード";
        /// <summary>GUID</summary>
		private const string GUID_TITLE					= "GUID";
		
		// 編集モード
		private const string INSERT_MODE				= "新規モード";
		private const string UPDATE_MODE				= "更新モード";
		private const string DELETE_MODE				= "削除モード";
		#endregion

		#region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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
		#endregion

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("得意先ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMTSP09000UA));
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.CustomerNameCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SendCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerNameCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.SendCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DebitNSendCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DebitNSendCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SendEnterpriseCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SendEnterpriseCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNameCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitNSendCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendEnterpriseCode_tNedit)).BeginInit();
            this.SuspendLayout();
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
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(579, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "更新モード";
            // 
            // CustomerGuide_Button
            // 
            this.CustomerGuide_Button.Location = new System.Drawing.Point(535, 30);
            this.CustomerGuide_Button.Name = "CustomerGuide_Button";
            this.CustomerGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.CustomerGuide_Button.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "得意先ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustomerGuide_Button, ultraToolTipInfo1);
            this.CustomerGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerGuide_Button.Click += new System.EventHandler(this.CustomerGuide_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(175, 226);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(300, 226);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 7;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Save_Button.Location = new System.Drawing.Point(425, 226);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(125, 34);
            this.Save_Button.TabIndex = 9;
            this.Save_Button.Text = "保存(&S)";
            this.Save_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(550, 226);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 262);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(684, 23);
            this.ultraStatusBar1.TabIndex = 59;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // CustomerNameCode_Title_Label
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.CustomerNameCode_Title_Label.Appearance = appearance68;
            this.CustomerNameCode_Title_Label.Location = new System.Drawing.Point(20, 31);
            this.CustomerNameCode_Title_Label.Name = "CustomerNameCode_Title_Label";
            this.CustomerNameCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CustomerNameCode_Title_Label.TabIndex = 34;
            this.CustomerNameCode_Title_Label.Text = "得意先";
            // 
            // SendCode_Title_Label
            // 
            appearance33.TextVAlignAsString = "Middle";
            this.SendCode_Title_Label.Appearance = appearance33;
            this.SendCode_Title_Label.Location = new System.Drawing.Point(20, 91);
            this.SendCode_Title_Label.Name = "SendCode_Title_Label";
            this.SendCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SendCode_Title_Label.TabIndex = 40;
            this.SendCode_Title_Label.Text = "送信区分";
            // 
            // CustomerNameCode_tNedit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Right";
            appearance10.TextVAlignAsString = "Middle";
            this.CustomerNameCode_tNedit.ActiveAppearance = appearance10;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance34.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Right";
            appearance34.TextVAlignAsString = "Middle";
            this.CustomerNameCode_tNedit.Appearance = appearance34;
            this.CustomerNameCode_tNedit.AutoSelect = true;
            this.CustomerNameCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CustomerNameCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerNameCode_tNedit.DataText = "";
            this.CustomerNameCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNameCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CustomerNameCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CustomerNameCode_tNedit.Location = new System.Drawing.Point(151, 31);
            this.CustomerNameCode_tNedit.MaxLength = 8;
            this.CustomerNameCode_tNedit.Name = "CustomerNameCode_tNedit";
            this.CustomerNameCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.CustomerNameCode_tNedit.Size = new System.Drawing.Size(76, 24);
            this.CustomerNameCode_tNedit.TabIndex = 1;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(7, 70);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel17.TabIndex = 39;
            // 
            // CustomerName_tEdit
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.TextVAlignAsString = "Middle";
            this.CustomerName_tEdit.ActiveAppearance = appearance60;
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextVAlignAsString = "Middle";
            this.CustomerName_tEdit.Appearance = appearance61;
            this.CustomerName_tEdit.AutoSelect = true;
            this.CustomerName_tEdit.DataText = "";
            this.CustomerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CustomerName_tEdit.Location = new System.Drawing.Point(257, 31);
            this.CustomerName_tEdit.MaxLength = 16;
            this.CustomerName_tEdit.Name = "CustomerName_tEdit";
            this.CustomerName_tEdit.ReadOnly = true;
            this.CustomerName_tEdit.Size = new System.Drawing.Size(274, 24);
            this.CustomerName_tEdit.TabIndex = 0;
            this.CustomerName_tEdit.TabStop = false;
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
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(300, 226);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 8;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SendCode_tComboEditor
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.SendCode_tComboEditor.ActiveAppearance = appearance11;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.SendCode_tComboEditor.Appearance = appearance12;
            this.SendCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SendCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            this.SendCode_tComboEditor.ItemAppearance = appearance13;
            valueListItem3.DataValue = "ValueListItem0";
            valueListItem3.DisplayText = "0:自動";
            valueListItem4.DataValue = "ValueListItem1";
            valueListItem4.DisplayText = "1:一括";
            this.SendCode_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.SendCode_tComboEditor.Location = new System.Drawing.Point(151, 90);
            this.SendCode_tComboEditor.Name = "SendCode_tComboEditor";
            this.SendCode_tComboEditor.Size = new System.Drawing.Size(100, 24);
            this.SendCode_tComboEditor.TabIndex = 3;
            // 
            // DebitNSendCode_tComboEditor
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance65.ForeColor = System.Drawing.Color.Black;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            appearance65.TextVAlignAsString = "Middle";
            this.DebitNSendCode_tComboEditor.ActiveAppearance = appearance65;
            appearance66.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextVAlignAsString = "Middle";
            this.DebitNSendCode_tComboEditor.Appearance = appearance66;
            this.DebitNSendCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DebitNSendCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.ForeColor = System.Drawing.Color.Black;
            appearance67.ForeColorDisabled = System.Drawing.Color.Black;
            this.DebitNSendCode_tComboEditor.ItemAppearance = appearance67;
            valueListItem1.DataValue = "ValueListItem0";
            valueListItem1.DisplayText = "0:する";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "1:しない";
            this.DebitNSendCode_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.DebitNSendCode_tComboEditor.Location = new System.Drawing.Point(151, 134);
            this.DebitNSendCode_tComboEditor.Name = "DebitNSendCode_tComboEditor";
            this.DebitNSendCode_tComboEditor.Size = new System.Drawing.Size(100, 24);
            this.DebitNSendCode_tComboEditor.TabIndex = 4;
            // 
            // DebitNSendCode_Title_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.DebitNSendCode_Title_Label.Appearance = appearance4;
            this.DebitNSendCode_Title_Label.Location = new System.Drawing.Point(20, 135);
            this.DebitNSendCode_Title_Label.Name = "DebitNSendCode_Title_Label";
            this.DebitNSendCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.DebitNSendCode_Title_Label.TabIndex = 61;
            this.DebitNSendCode_Title_Label.Text = "赤伝送信区分";
            // 
            // SendEnterpriseCode_tNedit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.SendEnterpriseCode_tNedit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.White;
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.SendEnterpriseCode_tNedit.Appearance = appearance17;
            this.SendEnterpriseCode_tNedit.AutoSelect = true;
            this.SendEnterpriseCode_tNedit.BackColor = System.Drawing.Color.White;
            this.SendEnterpriseCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SendEnterpriseCode_tNedit.DataText = "";
            this.SendEnterpriseCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SendEnterpriseCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SendEnterpriseCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SendEnterpriseCode_tNedit.Location = new System.Drawing.Point(151, 177);
            this.SendEnterpriseCode_tNedit.MaxLength = 16;
            this.SendEnterpriseCode_tNedit.Name = "SendEnterpriseCode_tNedit";
            this.SendEnterpriseCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.SendEnterpriseCode_tNedit.Size = new System.Drawing.Size(139, 24);
            this.SendEnterpriseCode_tNedit.TabIndex = 5;
            // 
            // SendEnterpriseCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SendEnterpriseCode_Title_Label.Appearance = appearance2;
            this.SendEnterpriseCode_Title_Label.Location = new System.Drawing.Point(20, 177);
            this.SendEnterpriseCode_Title_Label.Name = "SendEnterpriseCode_Title_Label";
            this.SendEnterpriseCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SendEnterpriseCode_Title_Label.TabIndex = 63;
            this.SendEnterpriseCode_Title_Label.Text = "企業コード";
            // 
            // PMTSP09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 285);
            this.Controls.Add(this.SendEnterpriseCode_tNedit);
            this.Controls.Add(this.SendEnterpriseCode_Title_Label);
            this.Controls.Add(this.DebitNSendCode_tComboEditor);
            this.Controls.Add(this.DebitNSendCode_Title_Label);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.SendCode_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CustomerNameCode_tNedit);
            this.Controls.Add(this.CustomerName_tEdit);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.CustomerNameCode_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.CustomerGuide_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SendCode_Title_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMTSP09000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TSP連携マスタ設定";
            this.Load += new System.EventHandler(this.PMTSP09000UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMTSP09000UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMTSP09000UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNameCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitNSendCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendEnterpriseCode_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
		}
		#endregion

        #region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMTSP09000UA());
        }
        #endregion

        #region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった時に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region Properties
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

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
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

        /// <summary>新規作成可能設定プロパティ</summary>
        /// <value>新規作成が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷が可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
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
        #endregion

        #region Public Methods
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();
            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 得意先コード
            appearanceTable.Add(CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 送信区分
            appearanceTable.Add(SENDCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // 赤伝送信区分
            appearanceTable.Add(DEBITNSENDCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // 送信企業コード
            appearanceTable.Add(SENDENTERPRISECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // GUID
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleCenter, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = TSPCPRTST_TABLE;
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchTspCprtStWork(ref totalCnt, readCnt);
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // 未実装
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCnt">全該当件数</param>
        /// <param name="readCnt">抽出対象件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int SearchTspCprtStWork(ref int totalCnt, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; ;

            // データセットのクリア
            this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Clear();
            this._tspCprtStWorkTable.Clear();

            // 検索条件の設定
            ArrayList tspCprtWorkList = null;
            TspCprtStWork tspCprtWork = new TspCprtStWork();
            tspCprtWork.EnterpriseCode = this._enterpriseCode;

            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._tspCprtStAcs.SearchAll(tspCprtWork, out tspCprtWorkList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (TspCprtStWork tspCprtStWork in tspCprtWorkList)
                        {
                            if (this._tspCprtStWorkTable.ContainsKey(tspCprtStWork.FileHeaderGuid) == false)
                            {
                                TspCprtStWorkToDataSet(tspCprtStWork.Clone(), index);
                                index++;
                            }
                        }
                        totalCnt = tspCprtWorkList.Count;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                default:
                    break;
            }
            return status;
        }

        /// <summary>
        /// TSP連携設定オブジェクト展開処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : TSP連携設定クラスをDataSetに格納します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void TspCprtStWorkToDataSet(TspCprtStWork tspCprtStWork, int index)
        {
            if ((index < 0) || (index >= this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count))
            {
                // 新規と判断し、行を追加する。
                DataRow dataRow = this.Bind_DataSet.Tables[TSPCPRTST_TABLE].NewRow();
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Add(dataRow);

                // indexを最終行番号にする
                index = this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (tspCprtStWork.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][DELETE_DATE] = tspCprtStWork.UpdateDateTimeJpInFormal;
            }

            // 得意先コード
            this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][CUSTOMERCODE_TITLE] = Convert.ToString(tspCprtStWork.CustomerCode).PadLeft(8, '0');
            // 送信区分
            if (tspCprtStWork.SendCode == 0)
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][SENDCODE_TITLE] = "自動";
            }
            else
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][SENDCODE_TITLE] = "一括";
            }

            // 赤伝送信区分
            if (tspCprtStWork.DebitNSendCode == 0)
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][DEBITNSENDCODE_TITLE] = "する";
            }
            else
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][DEBITNSENDCODE_TITLE] = "しない";
            }

            // 送信企業コード
            this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][SENDENTERPRISECODE_TITLE] = Convert.ToString(tspCprtStWork.SendEnterpriseCode).PadLeft(16, '0');

            // GUID
            this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][GUID_TITLE] = tspCprtStWork.FileHeaderGuid;

            if (this._tspCprtStWorkTable.ContainsKey(tspCprtStWork.FileHeaderGuid) == true)
            {
                this._tspCprtStWorkTable.Remove(tspCprtStWork.FileHeaderGuid);
            }
            this._tspCprtStWorkTable.Add(tspCprtStWork.FileHeaderGuid, tspCprtStWork);

        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // TSP連携設定マスタテーブル
            DataTable tspCprtStWorkTable = new DataTable(TSPCPRTST_TABLE);
            // Addを行う順番が、列の表示順位となります。
            tspCprtStWorkTable.Columns.Add(DELETE_DATE, typeof(string));              // 削除日
            tspCprtStWorkTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));       // 得意先コード
            tspCprtStWorkTable.Columns.Add(SENDCODE_TITLE, typeof(string));           // 送信区分
            tspCprtStWorkTable.Columns.Add(DEBITNSENDCODE_TITLE, typeof(string));     // 赤伝送信区分
            tspCprtStWorkTable.Columns.Add(SENDENTERPRISECODE_TITLE, typeof(string)); // 送信企業コード
            tspCprtStWorkTable.Columns.Add(GUID_TITLE, typeof(Guid));                 // GUID
            this.Bind_DataSet.Tables.Add(tspCprtStWorkTable);
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // ボタン配置
            int CANCELBUTTONLOCATION_X = this.Cancel_Button.Location.X;
            int OKBUTTONLOCATION_X = this.Save_Button.Location.X;
            int DELETEBUTTONLOCATION_X = this.Renewal_Button.Location.X;
            int BUTTONLOCATION_Y = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Save_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Revive_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Delete_Button.Location = new System.Drawing.Point(DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y);

            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 画面入力許可制御
                this.ScreenItemsSetting(0);
                this.CustomerNameCode_tNedit.Focus();
            }
            else
            {
                // 削除の場合
                if ((string)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][DELETE_DATE] != "")
                {
                    // 画面入力許可制御
                    this.ScreenItemsSetting(2);
                }
                // 更新の場合
                else
                {
                    // 画面入力許可制御
                    this.ScreenItemsSetting(1);
                    this.SendCode_tComboEditor.Focus();
                }
            }

        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.CustomerNameCode_tNedit.Clear();		         // 得意先コード
            this.CustomerName_tEdit.Clear();		             // 得意先名称
            this.SendCode_tComboEditor.SelectedIndex = 0;        // 送信区分
            this.DebitNSendCode_tComboEditor.SelectedIndex = 0;  // 赤伝送信区分
            this.SendEnterpriseCode_tNedit.Clear();		         // 企業コード
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            TspCprtStWork tspCprtStWork = new TspCprtStWork();
            tspCprtStWork.EnterpriseCode = this._enterpriseCode;
            // 新規の場合
            if (this._dataIndex < 0)
            {
                // クローン作成
                this._compareTspCprtStWork = tspCprtStWork.Clone();
                // TSP連携マスタ設定オブジェクトを画面に展開
                TspCprtStWorkToScreen(tspCprtStWork);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                tspCprtStWork = (TspCprtStWork)this._tspCprtStWorkTable[guid];
                // クローン作成
                this._compareTspCprtStWork = tspCprtStWork.Clone();
                // TSP連携マスタ設定オブジェクトを画面に展開
                TspCprtStWorkToScreen(this._compareTspCprtStWork);
            }
            // _GridIndexバッファ保持（メインフレーム最小化対応）
            this._indexBuf = this._dataIndex;
        }

        /// <summary>
        /// 画面初期制御
        /// </summary>
        /// <param name="mode">モード(0:新規 1:更新 2:ロジック削除)</param>
        /// <remarks>
        /// <br>Note　　　 : 画面初期制御を行います。</br>
        /// <br>Programmer : 3H 李金銘</br>
        /// <br>Date       : K2018/02/28</br>
        /// </remarks>
        private void ScreenItemsSetting(int mode)
        {
            // ボタン制御処理
            this.SetButton(mode);
            // 画面項目制御処理
            this.SetMenuItem(mode);
        }

        /// <summary>
        /// ボタン制御処理
        /// </summary>
        /// <param name="mode">モード(0:新規 1:更新 2:ロジック削除)</param>
        /// <remarks>
        /// <br>Note　　　 : ボタン制御を行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void SetButton(int mode)
        {
            // 保存ボタン
            this.Save_Button.Visible = mode == 2 ? false : true;
            // 最新情報取得ボタン
            this.Renewal_Button.Visible = mode == 2 ? false : true;
            // 復活ボタン
            this.Revive_Button.Visible = mode == 2 ? true : false;
            // 完全削除ボタン
            this.Delete_Button.Visible = mode == 2 ? true : false;
        }

        /// <summary>
        /// 画面項目制御処理
        /// </summary>
        /// <param name="mode">モード(0:新規 1:更新 2:ロジック削除)</param>
        /// <remarks>
        /// <br>Note　　　 : 画面項目制御を行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void SetMenuItem(int mode)
        {
            switch (mode)
            {
                case 0:
                    Mode_Label.Text = INSERT_MODE;
                    break;
                case 1:
                    Mode_Label.Text = UPDATE_MODE;
                    break;
                case 2:
                    Mode_Label.Text = DELETE_MODE;
                    break;
                default:
                    Mode_Label.Text = INSERT_MODE;
                    break;
            }

            // 得意先コード
            this.CustomerNameCode_tNedit.Enabled = mode == 0 ? true : false;
            // 得意先名称ガイド
            this.CustomerGuide_Button.Enabled = mode == 0 ? true : false;
            // 送信区分
            this.SendCode_tComboEditor.Enabled = mode == 2 ? false : true;
            // 赤伝送信区分
            this.DebitNSendCode_tComboEditor.Enabled = mode == 2 ? false : true;
            // 送信企業コード
            this.SendEnterpriseCode_tNedit.Enabled = mode == 2 ? false : true;
        }

        /// <summary>
        /// TSP連携設定クラス画面展開処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携オブジェクト</param>
        /// <remarks>
        /// <br>Note       : TSP連携設定オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void TspCprtStWorkToScreen(TspCprtStWork tspCprtStWork)
        {
            // 得意先コード
            if (tspCprtStWork.CustomerCode == 0)
            {
                this.CustomerNameCode_tNedit.Clear();
                // 得意先名称
                CustomerName_tEdit.Clear();
            }
            else
            {
                // 得意先コード
                this.CustomerNameCode_tNedit.SetInt(tspCprtStWork.CustomerCode);
                // 得意先名称
                CustomerInfo customerInfo;
                int customerCode = CustomerNameCode_tNedit.GetInt();
                this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if ((customerInfo != null) && (!string.IsNullOrEmpty(customerInfo.CustomerSnm)))
                {
                    // 得意先名称
                    CustomerName_tEdit.Text = customerInfo.CustomerSnm.TrimEnd();
                }
                else
                {
                    // 得意先名称
                    CustomerName_tEdit.Text = string.Empty;
                }
            }
            this.SendCode_tComboEditor.SelectedIndex = tspCprtStWork.SendCode;		            // 送信区分
            this.DebitNSendCode_tComboEditor.SelectedIndex = tspCprtStWork.DebitNSendCode;		// 赤伝送信区分
            this.SendEnterpriseCode_tNedit.DataText = tspCprtStWork.SendEnterpriseCode;			// 送信企業コード
        }

        /// <summary>
        /// TSP連携設定クラス格納処理
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携設定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からTSP連携設定オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void DispToTspCprtStWork(ref TspCprtStWork tspCprtStWork)
        {
            if (tspCprtStWork == null)
            {
                tspCprtStWork = new TspCprtStWork();
            }
            tspCprtStWork.EnterpriseCode = this._enterpriseCode;					       // 企業コード
            tspCprtStWork.CustomerCode = this.CustomerNameCode_tNedit.GetInt();            // 得意先コード
            tspCprtStWork.SendCode = this.SendCode_tComboEditor.SelectedIndex;             // 送信区分
            tspCprtStWork.DebitNSendCode = this.DebitNSendCode_tComboEditor.SelectedIndex; // 赤伝送信区分
            tspCprtStWork.SendEnterpriseCode = this.SendEnterpriseCode_tNedit.Text.Trim(); // 送信企業コード
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面入力の不正チェックを行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = false;

            // 得意先コード
            if (this.CustomerNameCode_tNedit.GetInt() == 0)
            {
                message = this.CustomerNameCode_Title_Label.Text + "を入力してください。";
                control = this.CustomerNameCode_tNedit;
                return result;
            }

            // 送信企業コード
            if (Convert.ToInt64(this.SendEnterpriseCode_tNedit.Value) == 0)
            {
                message = this.SendEnterpriseCode_Title_Label.Text + "を入力してください。";
                control = this.SendEnterpriseCode_tNedit;
                return result;
            }
            return true; ;
        }

        /// <summary>
        /// TSP連携設定保存処理
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : TSP連携設定の保存を行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            // 入力チェック
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,   // エラーレベル
                              CT_PGID, 						        // アセンブリＩＤまたはクラスＩＤ
                              message, 							    // 表示するメッセージ
                              0, 									// ステータス値
                              MessageBoxButtons.OK);				// 表示するボタン
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

            TspCprtStWork tspCprtStWork = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                tspCprtStWork = ((TspCprtStWork)this._tspCprtStWorkTable[guid]).Clone();
            }
            DispToTspCprtStWork(ref tspCprtStWork);

            int status = this._tspCprtStAcs.Write(ref tspCprtStWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEWのデータセットを更新
                        TspCprtStWorkToDataSet(tspCprtStWork.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                                      CT_PGID, 							    // アセンブリＩＤまたはクラスＩＤ
                                      "この得意先は既に使用されています。", // 表示するメッセージ
                                      0, 									// ステータス値
                                      MessageBoxButtons.OK);				// 表示するボタン
                        this.CustomerNameCode_tNedit.Focus();
                        this.CustomerNameCode_tNedit.SelectAll();
                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP,      // エラーレベル
                                      CT_PGID,                          // アセンブリＩＤまたはクラスＩＤ
                                      "TSP連携マスタ設定",              // プログラム名称
                                      "SaveProc",                       // 処理名称
                                      TMsgDisp.OPE_INSERT,              // オペレーション
                                      "登録に失敗しました。",           // 表示するメッセージ
                                      status,                           // ステータス値
                                      this._tspCprtStAcs,               // エラーが発生したオブジェクト
                                      MessageBoxButtons.OK,             // 表示するボタン
                                      MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            return true;
        }

        /// <summary>
        /// TSP連携マスタオブジェクト論理削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタオブジェクトの論理削除を行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            TspCprtStWork tspCprtStWork = ((TspCprtStWork)this._tspCprtStWorkTable[guid]).Clone();

            // TSP連携設定が存在していない
            if (tspCprtStWork == null)
            {
                return -1;
            }

            status = this._tspCprtStAcs.LogicalDelete(ref tspCprtStWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        TspCprtStWorkToDataSet(tspCprtStWork.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP,      // エラーレベル
                                      CT_PGID,                          // アセンブリＩＤまたはクラスＩＤ
                                      "TSP連携マスタ設定",              // プログラム名称
                                      "LogicalDelete",                  // 処理名称
                                      TMsgDisp.OPE_DELETE,              // オペレーション
                                      "削除に失敗しました。",           // 表示するメッセージ
                                      status,                           // ステータス値
                                      this._tspCprtStAcs,               // エラーが発生したオブジェクト
                                      MessageBoxButtons.OK,             // 表示するボタン
                                      MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// TSP連携マスタオブジェクト論理削除復活処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタオブジェクトの論理削除復活を行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            TspCprtStWork tspCprtStWork = ((TspCprtStWork)this._tspCprtStWorkTable[guid]).Clone();

            // TSP連携マスタが存在していない
            if (tspCprtStWork == null)
            {
                return -1;
            }

            status = this._tspCprtStAcs.Relive(ref tspCprtStWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        TspCprtStWorkToDataSet(tspCprtStWork.Clone(), this._dataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP,      // エラーレベル
                                      CT_PGID,                          // アセンブリＩＤまたはクラスＩＤ
                                      "TSP連携マスタ設定",              // プログラム名称
                                      "Revival",                        // 処理名称
                                      TMsgDisp.OPE_RECIEVE,             // オペレーション
                                      "復活に失敗しました。",           // 表示するメッセージ
                                      status,                           // ステータス値
                                      this._tspCprtStAcs,               // エラーが発生したオブジェクト
                                      MessageBoxButtons.OK,             // 表示するボタン
                                      MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// TSP連携設定オブジェクト完全削除処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : TSP連携設定オブジェクトの完全削除を行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            TspCprtStWork tspCprtStWork = (TspCprtStWork)this._tspCprtStWorkTable[guid];

            // TSP連携設定が存在していない
            if (tspCprtStWork == null)
            {
                return -1;
            }

            status = this._tspCprtStAcs.Delete(tspCprtStWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ハッシュテーブルからデータを削除
                        this._tspCprtStWorkTable.Remove((Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // データセットからデータを削除
                        this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex].Delete();
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // 物理削除
                        TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_STOP,      // エラーレベル
                                      CT_PGID,                          // アセンブリＩＤまたはクラスＩＤ
                                      "TSP連携マスタ設定",              // プログラム名称
                                      "PhysicalDelete",                 // 処理名称
                                      TMsgDisp.OPE_DELETE,              // オペレーション
                                      "削除に失敗しました。",           // 表示するメッセージ
                                      status,                           // ステータス値
                                      this._tspCprtStAcs,               // エラーが発生したオブジェクト
                                      MessageBoxButtons.OK,             // 表示するボタン
                                      MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
		/// <remarks>
		/// <br>Note       : 排他処理を行います</br>
		/// <br>Programmer : 3H 劉星光</br>
		/// <br>Date       : 2020/11/23</br>
		/// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(this, 							  // 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                                      CT_PGID, 						      // アセンブリＩＤまたはクラスＩＤ
                                      "既に他端末より更新されています。", // 表示するメッセージ
                                      0, 								  // ステータス値
                                      MessageBoxButtons.OK);			  // 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(this, 							  // 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                                      CT_PGID, 						      // アセンブリＩＤまたはクラスＩＤ
                                      "既に他端末より削除されています。", // 表示するメッセージ
                                      0, 								  // ステータス値
                                      MessageBoxButtons.OK);			  // 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
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
            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
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
		#endregion

        #region Control Events
        /// <summary>
        /// Form.Load イベント(PMTSP09000UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void PMTSP09000UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Save_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.CustomerGuide_Button.ImageList = imageList16;

            this.Save_Button.Appearance.Image = Size24_Index.SAVE;	         // 保存ボタン
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;     // 最新情報ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;	     // 閉じるボタン
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;      // 復活ボタン
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;       // 完全削除ボタン
            this.CustomerGuide_Button.Appearance.Image = Size16_Index.STAR1; // 得意先ガイドボタン

            // 画面を構築
            ScreenInitialSetting();
        }

        /// <summary>
        /// Form.Closing イベント(PMTSP09000UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void PMTSP09000UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // _GridIndexバッファ初期化
            this._indexBuf = -2;

            if (this._canClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Form.VisibleChanged イベント(PMTSP09000UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void PMTSP09000UA_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }
            // _GridIndexバッファ（メインフレーム最小化対応）
            // ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // 画面初期化処理
            ScreenInitialSetting();
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Timer.Tick イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。
        ///                   この処理は、システムが提供するスレッド プール
        ///	                  スレッドで実行されます。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click イベント(save_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Save_Button_Click(object sender, System.EventArgs e)
        {
            // 登録
            if (!SaveProc())
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                ScreenClear();
                TspCprtStWork tspCprtStWork = new TspCprtStWork();
                tspCprtStWork.EnterpriseCode = this._enterpriseCode;
                // TSP連携設定オブジェクトを画面に展開
                TspCprtStWorkToScreen(tspCprtStWork);
                // クローン作成
                this._compareTspCprtStWork = tspCprtStWork.Clone();
                // _GridIndexバッファ保持
                this._indexBuf = this._dataIndex;
                CustomerNameCode_tNedit.Focus();

            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // _GridIndexバッファ初期化（メインフレーム最小化対応）
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
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 現在の画面情報を取得する
                TspCprtStWork tspCprtStWork = new TspCprtStWork();
                tspCprtStWork = this._compareTspCprtStWork.Clone();
                DispToTspCprtStWork(ref tspCprtStWork);

                // 最初に取得した画面情報と比較
                if (!(this._compareTspCprtStWork.Equals(tspCprtStWork)))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                    // 保存確認
                    DialogResult res = TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                        CT_PGID, 						    // アセンブリＩＤまたはクラスＩＤ
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
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                if (_modeFlg)
                                {
                                    CustomerNameCode_tNedit.Focus();
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

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            if (this._canClose)
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
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            DialogResult res = TMsgDisp.Show(this,
                     emErrorLevel.ERR_LEVEL_QUESTION,
                     CT_PGID,
                     "現在表示中のTSP連携マスタ設定を復活します。\r\nよろしいですか？",
                     0,
                     MessageBoxButtons.YesNo,
                     MessageBoxDefaultButton.Button1);

            if (res != DialogResult.Yes)
            {
                return;
            }

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

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
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
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                CT_PGID, 						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel, 		// 表示するボタン
                MessageBoxDefaultButton.Button2);	// 初期表示ボタン

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

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
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
        /// Control.Click イベント(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, System.EventArgs e)
        {
            // 得意先ガイド表示
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            customerSearchForm.ShowDialog(this);
        }

        #region 得意先選択ガイドボタンクリック時イベント
        /// <summary>
        /// 得意先選択ガイドボタンクリック時発生イベント
        /// </summary>
        /// <param name="sender">PMKHN4002Eフォームオブジェクト</param>
        /// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンクリックイベントを行います。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
            if (customerSearchRet == null) return;
            string sErrMsg = string.Empty;
            int iERR_LEVEL = 0;
            // DBデータを読み出す(キャッシュを使用)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, out customerInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (customerInfo.LogicalDeleteCode == 1)
                        {
                            sErrMsg = "選択した得意先は既に削除されています。";
                            iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_EXCLAMATION;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    sErrMsg = "選択した得意先は得意先情報入力が行われていない為、使用出来ません。";
                    iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_EXCLAMATION;
                    break;
                default:
                    sErrMsg = "得意先情報の取得に失敗しました。";
                    iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_STOP;
                    break;
            }

            if (!string.IsNullOrEmpty(sErrMsg))
            {

                TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                              (emErrorLevel)iERR_LEVEL, // エラーレベル
                              CT_PGID,					// アセンブリＩＤまたはクラスＩＤ
                              sErrMsg,                  // 表示するメッセージ
                              0, 						// ステータス値
                              MessageBoxButtons.OK);	// 表示するボタン
                CustomerNameCode_tNedit.Clear();
                CustomerName_tEdit.Clear();
                CustomerNameCode_tNedit.Focus();
            }
            else
            {
                // 得意先情報をUIに設定
                this.CustomerNameCode_tNedit.SetInt(customerInfo.CustomerCode);
                this.CustomerName_tEdit.Text = customerInfo.CustomerSnm.TrimEnd();
                SendCode_tComboEditor.Focus();
            }
        }
        #endregion

        /// <summary>
        /// 得意先変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先変更処理。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private Control SetCustomerCode()
        {
            Control e = null;

            // 得意先コード未入力の場合、
            int iCustomerCode = CustomerNameCode_tNedit.GetInt();

            if (iCustomerCode == 0)
            {
                return e;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            TspCprtStWork tspCprtStWork = new TspCprtStWork();
            tspCprtStWork.EnterpriseCode = this._enterpriseCode;
            string sErrMsg = string.Empty;
            int iERR_LEVEL = 0;

            // グリッドからデータを取得する
            for (int i = 0; i < this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                Int32 tempCustomerCd = Convert.ToInt32(this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[i][CUSTOMERCODE_TITLE].ToString().Trim());
                if (tempCustomerCd == iCustomerCode)
                {
                    this._dataIndex = i;
                    Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[i][GUID_TITLE];
                    tspCprtStWork = (TspCprtStWork)this._tspCprtStWorkTable[guid];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                DialogResult res = TMsgDisp.Show(this,                                   // 親ウィンドウフォーム
                                                 emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                                                 CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                                                 "入力されたコードのTSP連携マスタ設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                                                 0,                                      // ステータス値
                                                 MessageBoxButtons.YesNo);               // 表示するボタン
                switch (res)
                {
                    case DialogResult.Yes:
                        {

                            // 画面展開処理
                            TspCprtStWorkToScreen(tspCprtStWork);
                            this._compareTspCprtStWork = tspCprtStWork.Clone();
                            // ロジック削除の場合
                            if (tspCprtStWork.LogicalDeleteCode == 1)
                            {
                                // 画面入力許可制御
                                this.ScreenItemsSetting(2);

                            }
                            // 更新の場合
                            else
                            {
                                // 画面入力許可制御
                                this.ScreenItemsSetting(1);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            // 得意先コードのクリア
                            CustomerNameCode_tNedit.Clear();
                            CustomerName_tEdit.Clear();
                            e = CustomerNameCode_tNedit;
                            return e;
                        }
                }

            }
            else
            {
                CustomerInfo customerInfo;
                status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, iCustomerCode, out customerInfo);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (customerInfo.LogicalDeleteCode == 1)
                            {
                                sErrMsg = "入力した得意先は既に削除されています。";
                                iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_EXCLAMATION;
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        sErrMsg = "入力した得意先は得意先情報入力が行われていない為、使用出来ません。";
                        iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_EXCLAMATION;
                        break;
                    default:
                        sErrMsg = "得意先情報の取得に失敗しました。";
                        iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_STOP;
                        break;
                }

                if (!string.IsNullOrEmpty(sErrMsg))
                {
                    TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                      (emErrorLevel)iERR_LEVEL,             // エラーレベル
                      CT_PGID,						        // アセンブリＩＤまたはクラスＩＤ
                      sErrMsg,                              // 表示するメッセージ
                      0, 									// ステータス値
                      MessageBoxButtons.OK);				// 表示するボタン
                    CustomerNameCode_tNedit.Text = string.Empty;
                    CustomerName_tEdit.Text = string.Empty;
                    e = CustomerNameCode_tNedit;
                }
                else
                {

                    tspCprtStWork.CustomerCode = customerInfo.CustomerCode;
                    // 画面入力許可制御
                    this.ScreenItemsSetting(0);
                    // 画面展開処理
                    TspCprtStWorkToScreen(tspCprtStWork);
                    this._compareTspCprtStWork = tspCprtStWork.Clone();
                    this.CustomerNameCode_tNedit.SetInt(customerInfo.CustomerCode);
                    this.CustomerName_tEdit.Text = customerInfo.CustomerSnm.TrimEnd();
                    e = SendCode_tComboEditor;
                }

            }
            return e;
        }

        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 3H 劉星光</br>
        /// <br>Date		: 2020/11/23</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }
            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                // 得意先コード
                case "CustomerNameCode_tNedit":
                    {
                        // 得意先コード再検索
                        Control control = this.SetCustomerCode();

                        if (control != null)
                        {
                            e.NextCtrl = control;
                        }

                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Renewal_Button Clickイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: Renewal_Button Clickイベント。</br>
        /// <br>Programmer	: 3H 劉星光</br>
        /// <br>Date		: 2020/11/23</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 検索条件の設定
            ArrayList tspCprtWorkList = null;
            this._customerInfoAcs = new CustomerInfoAcs();
            // TSP連携設定アクセス
            this._tspCprtStAcs = new TspCprtStAcs();
            TspCprtStWork tspCprtWork = new TspCprtStWork();
            tspCprtWork.EnterpriseCode = this._enterpriseCode;
            // 抽出対象件数が0件の場合は全件抽出を実行する
            status = this._tspCprtStAcs.SearchAll(tspCprtWork, out tspCprtWorkList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        // データセットのクリア
                        this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Clear();
                        this._tspCprtStWorkTable.Clear();
                        foreach (TspCprtStWork tspCprtStWork in tspCprtWorkList)
                        {
                            if (this._tspCprtStWorkTable.ContainsKey(tspCprtStWork.FileHeaderGuid) == false)
                            {
                                if (tspCprtStWork.CustomerCode == CustomerNameCode_tNedit.GetInt())
                                {
                                    // クローン作成
                                    this._compareTspCprtStWork = tspCprtStWork.Clone();
                                    // TSP連携マスタ設定オブジェクトを画面に展開
                                    TspCprtStWorkToScreen(this._compareTspCprtStWork);
                                }
                                TspCprtStWorkToDataSet(tspCprtStWork.Clone(), index);
                                index++;
                            }
                        }

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }
                        TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                                      emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                                      CT_PGID,						        // アセンブリＩＤまたはクラスＩＤ
                                      "最新情報を取得しました。", 			// 表示するメッセージ
                                      0, 									// ステータス値
                                      MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    break;
                default:
                    TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                                  emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                                  CT_PGID,						        // アセンブリＩＤまたはクラスＩＤ
                                  "最新情報を取得失敗。", 			// 表示するメッセージ
                                  0, 									// ステータス値
                                  MessageBoxButtons.OK);				// 表示するボタン
                    break;
            }
        }
        #endregion

    }
}