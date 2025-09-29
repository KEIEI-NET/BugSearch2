//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：倉庫設定マスタ
// プログラム概要   ：倉庫設定の登録・修正・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍　幸史
// 修正日    2008/06/04     修正内容：「得意先」「主管倉庫」「在庫一括リマーク」追加、「倉庫備考2～5」削除
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/10/09     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/16     修正内容：Mantis【12826】速度アップ対応
//                                  ：Mantis【13189】マスメン最新情報対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修 正 日  2009/06/29     修正内容：MANTIS【13347】対応
//----------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;   // ADD 2009/04/16
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
    /// 拠点設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点設定を行います。
    /// <br>Programmer : 22022 段上 知子</br>
    /// <br>Date       : 2006.12.22</br>
    /// <br>Note       : 拠点情報の取得先をリモートに修正。
    /// <br>Programmer : 980023 飯谷 耕平</br>
    /// <br>Date       : 2007.05.23</br>
	/// <br>Update Note: 2007.08.28 30167 上野　弘貴</br>
	/// <br>			新規モード時のみテーブルデータの再取得をするよう修正</br>
	/// <br>Update Note: 2008.03.03 30167 上野　弘貴</br>
	/// <br>			・項目ゼロ埋め対応（画面デザインにコンポーネント追加、
	///					　Tedit、TNeditの設定変更）
	///					・倉庫名称の項目名を変更（ゼロ埋めＸＭＬで使用されているため）</br>
    /// <br>Update Note: 2008/06/04 30414 忍　幸史</br>
    /// <br>			・「得意先」「主管倉庫」「在庫一括リマーク」追加、「倉庫備考2～5」削除</br>
    /// <br>UpdateNote   : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// </remarks>
    public class MAKHN09330UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
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
        private Infragistics.Win.Misc.UltraLabel Section_Title_Label;
        private System.Data.DataSet Bind_DataSet;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Panel Button_Panel;
        private TEdit WarehouseCdName_tEdit;
        private UltraLabel DivideLine_Label;
        private UltraLabel WarehouseName_Title_Label;
        private UltraLabel WarehouseCode_Title_Label;
        private TEdit tEdit_SectionCode;
        private TEdit tEdit_WarehouseCode;
        private UltraLabel WarehouseNote1_Title_Label;
        private TEdit WarehouseNote1_tEdit;
        private UltraLabel Customer_Title_uLabel;
        private TEdit MainMngWarehouseNm_tEdit;
        private TEdit CustomerName_tEdit;
        private UltraButton MainMngWarehouseGuide_Button;
        private UltraButton CustomerGuide_Button;
        private UltraLabel StockBlnktRemark_Title_uLabel;
        private UltraLabel MainMngWarehouse_Title_uLabel;
        private TEdit StockBlnktRemark2_tEdit;
        private TEdit StockBlnktRemark1_tEdit;
        private UltraButton SectionGuide_Button;
        private TEdit tEdit_MainMngWarehouseCd;
        private UiSetControl uiSetControl1;
        private TNedit tNedit_CustomerCode;
        private UltraButton Renewal_Button;
        private System.ComponentModel.IContainer components;

        # endregion

        # region Constructor

        /// <summary>
        /// 拠点設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public MAKHN09330UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint                  = false;
            this._canClose                  = false;
            this._canNew                    = true;
            this._canDelete                 = true;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainGridTitle             = "拠点情報";
            this._detailsGridTitle          = "倉庫";
            this._defaultGridDisplayLayout  = MGridDisplayLayout.Vertical;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._dataIndex = -1;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // 企業コードを取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._targetTableName = "";
            this._mainDataIndex = -2;
            this._detailsDataIndex = -2;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // ----- iitani c ---------- start  2007.05.23
            //this._secInfoAcs    = new SecInfoAcs();         // 拠点
            this._secInfoAcs = new SecInfoAcs(1);         // 拠点(リモート読込)
            // ----- iitani c ---------- start  2007.05.23
            this._warehouseAcs = new WarehouseAcs();       // 倉庫

            this._customerInfoAcs = new CustomerInfoAcs();  // ADD 2008/06/04

            //this._mainTable = new Hashtable();  // DEL 2008/06/04
            this._detailsTable = new Hashtable();
            //this._allSearchHash = new Hashtable();  // DEL 2008/06/04

            //GridIndexバッファ（メインフレーム最小化対応）
            //this._mainIndexBuf = -2;  // DEL 2008/06/04
            this._detailsIndexBuf = -2;
            //this._targetTableBuf = "";  // DEL 2008/06/04

            // ADD 2009/04/16 ------>>>
            // キャッシュ情報取得
            this.GetCacheData();
            // ADD 2009/04/16 ------<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // アイコン用ダミー
            this._mainGridIcon = null;
            this._detailsGridIcon = null;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        # endregion

        # region Dispose

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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("得意先ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("倉庫ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKHN09330UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Section_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionGuideNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.CustomerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.MainMngWarehouseGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.WarehouseCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.WarehouseName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.WarehouseCdName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WarehouseNote1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.WarehouseNote1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Customer_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MainMngWarehouseNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.StockBlnktRemark1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.StockBlnktRemark2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MainMngWarehouse_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.StockBlnktRemark_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_MainMngWarehouseCd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCdName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseNote1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMngWarehouseNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MainMngWarehouseCd)).BeginInit();
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 340);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(814, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(296, 10);
            this.Delete_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 15;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(423, 10);
            this.Revive_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 16;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(550, 10);
            this.Ok_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 17;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(677, 10);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 18;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Section_Title_Label
            // 
            this.Section_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Section_Title_Label.Location = new System.Drawing.Point(12, 85);
            this.Section_Title_Label.Name = "Section_Title_Label";
            this.Section_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.Section_Title_Label.TabIndex = 140;
            this.Section_Title_Label.Text = "管理拠点";
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(709, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 230;
            this.Mode_Label.Text = "更新モード";
            // 
            // SectionGuideNm_tEdit
            // 
            this.SectionGuideNm_tEdit.ActiveAppearance = appearance7;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionGuideNm_tEdit.Appearance = appearance8;
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
            this.SectionGuideNm_tEdit.TabIndex = 4;
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
            // CustomerGuide_Button
            // 
            this.CustomerGuide_Button.Location = new System.Drawing.Point(558, 142);
            this.CustomerGuide_Button.Name = "CustomerGuide_Button";
            this.CustomerGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.CustomerGuide_Button.TabIndex = 8;
            ultraToolTipInfo3.ToolTipText = "得意先ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustomerGuide_Button, ultraToolTipInfo3);
            this.CustomerGuide_Button.Click += new System.EventHandler(this.CustomerGuide_Button_Click);
            // 
            // MainMngWarehouseGuide_Button
            // 
            this.MainMngWarehouseGuide_Button.Location = new System.Drawing.Point(550, 172);
            this.MainMngWarehouseGuide_Button.Name = "MainMngWarehouseGuide_Button";
            this.MainMngWarehouseGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.MainMngWarehouseGuide_Button.TabIndex = 11;
            ultraToolTipInfo2.ToolTipText = "倉庫ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.MainMngWarehouseGuide_Button, ultraToolTipInfo2);
            this.MainMngWarehouseGuide_Button.Click += new System.EventHandler(this.MainMngWarehouseGuide_Button_Click);
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(309, 85);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 5;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Renewal_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(0, 286);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(814, 54);
            this.Button_Panel.TabIndex = 168;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(423, 10);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 16;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // WarehouseCode_Title_Label
            // 
            this.WarehouseCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.WarehouseCode_Title_Label.Location = new System.Drawing.Point(12, 25);
            this.WarehouseCode_Title_Label.Name = "WarehouseCode_Title_Label";
            this.WarehouseCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.WarehouseCode_Title_Label.TabIndex = 160;
            this.WarehouseCode_Title_Label.Text = "倉庫コード";
            // 
            // WarehouseName_Title_Label
            // 
            this.WarehouseName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.WarehouseName_Title_Label.Location = new System.Drawing.Point(12, 55);
            this.WarehouseName_Title_Label.Name = "WarehouseName_Title_Label";
            this.WarehouseName_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.WarehouseName_Title_Label.TabIndex = 170;
            this.WarehouseName_Title_Label.Text = "倉庫名";
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(12, 124);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(795, 3);
            this.DivideLine_Label.TabIndex = 24;
            // 
            // WarehouseCdName_tEdit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WarehouseCdName_tEdit.ActiveAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.WarehouseCdName_tEdit.Appearance = appearance4;
            this.WarehouseCdName_tEdit.AutoSelect = true;
            this.WarehouseCdName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.WarehouseCdName_tEdit.DataText = "";
            this.WarehouseCdName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WarehouseCdName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.WarehouseCdName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.WarehouseCdName_tEdit.Location = new System.Drawing.Point(148, 55);
            this.WarehouseCdName_tEdit.MaxLength = 20;
            this.WarehouseCdName_tEdit.Name = "WarehouseCdName_tEdit";
            this.WarehouseCdName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.WarehouseCdName_tEdit.TabIndex = 2;
            // 
            // tEdit_SectionCode
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCode.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.Appearance = appearance6;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SectionCode.Location = new System.Drawing.Point(148, 85);
            this.tEdit_SectionCode.MaxLength = 6;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 3;
            // 
            // tEdit_WarehouseCode
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_WarehouseCode.ActiveAppearance = appearance14;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_WarehouseCode.Appearance = appearance25;
            this.tEdit_WarehouseCode.AutoSelect = true;
            this.tEdit_WarehouseCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_WarehouseCode.DataText = "";
            this.tEdit_WarehouseCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.tEdit_WarehouseCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_WarehouseCode.Location = new System.Drawing.Point(148, 25);
            this.tEdit_WarehouseCode.MaxLength = 6;
            this.tEdit_WarehouseCode.Name = "tEdit_WarehouseCode";
            this.tEdit_WarehouseCode.Size = new System.Drawing.Size(51, 24);
            this.tEdit_WarehouseCode.TabIndex = 1;
            // 
            // WarehouseNote1_tEdit
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.WarehouseNote1_tEdit.ActiveAppearance = appearance21;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            this.WarehouseNote1_tEdit.Appearance = appearance22;
            this.WarehouseNote1_tEdit.AutoSelect = true;
            this.WarehouseNote1_tEdit.DataText = "";
            this.WarehouseNote1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.WarehouseNote1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.WarehouseNote1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.WarehouseNote1_tEdit.Location = new System.Drawing.Point(148, 232);
            this.WarehouseNote1_tEdit.MaxLength = 40;
            this.WarehouseNote1_tEdit.Name = "WarehouseNote1_tEdit";
            this.WarehouseNote1_tEdit.Size = new System.Drawing.Size(639, 24);
            this.WarehouseNote1_tEdit.TabIndex = 14;
            // 
            // WarehouseNote1_Title_Label
            // 
            this.WarehouseNote1_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.WarehouseNote1_Title_Label.Location = new System.Drawing.Point(12, 232);
            this.WarehouseNote1_Title_Label.Name = "WarehouseNote1_Title_Label";
            this.WarehouseNote1_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.WarehouseNote1_Title_Label.TabIndex = 180;
            this.WarehouseNote1_Title_Label.Text = "倉庫備考";
            // 
            // Customer_Title_uLabel
            // 
            this.Customer_Title_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.Customer_Title_uLabel.Location = new System.Drawing.Point(12, 142);
            this.Customer_Title_uLabel.Name = "Customer_Title_uLabel";
            this.Customer_Title_uLabel.Size = new System.Drawing.Size(130, 24);
            this.Customer_Title_uLabel.TabIndex = 169;
            this.Customer_Title_uLabel.Text = "得意先";
            // 
            // CustomerName_tEdit
            // 
            this.CustomerName_tEdit.ActiveAppearance = appearance11;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.CustomerName_tEdit.Appearance = appearance12;
            this.CustomerName_tEdit.AutoSelect = true;
            this.CustomerName_tEdit.DataText = "";
            this.CustomerName_tEdit.Enabled = false;
            this.CustomerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CustomerName_tEdit.Location = new System.Drawing.Point(230, 142);
            this.CustomerName_tEdit.MaxLength = 40;
            this.CustomerName_tEdit.Name = "CustomerName_tEdit";
            this.CustomerName_tEdit.ReadOnly = true;
            this.CustomerName_tEdit.Size = new System.Drawing.Size(314, 24);
            this.CustomerName_tEdit.TabIndex = 7;
            // 
            // MainMngWarehouseNm_tEdit
            // 
            this.MainMngWarehouseNm_tEdit.ActiveAppearance = appearance15;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            this.MainMngWarehouseNm_tEdit.Appearance = appearance16;
            this.MainMngWarehouseNm_tEdit.AutoSelect = true;
            this.MainMngWarehouseNm_tEdit.DataText = "";
            this.MainMngWarehouseNm_tEdit.Enabled = false;
            this.MainMngWarehouseNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MainMngWarehouseNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.MainMngWarehouseNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.MainMngWarehouseNm_tEdit.Location = new System.Drawing.Point(206, 172);
            this.MainMngWarehouseNm_tEdit.MaxLength = 40;
            this.MainMngWarehouseNm_tEdit.Name = "MainMngWarehouseNm_tEdit";
            this.MainMngWarehouseNm_tEdit.ReadOnly = true;
            this.MainMngWarehouseNm_tEdit.Size = new System.Drawing.Size(330, 24);
            this.MainMngWarehouseNm_tEdit.TabIndex = 10;
            // 
            // StockBlnktRemark1_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockBlnktRemark1_tEdit.ActiveAppearance = appearance17;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockBlnktRemark1_tEdit.Appearance = appearance18;
            this.StockBlnktRemark1_tEdit.AutoSelect = true;
            this.StockBlnktRemark1_tEdit.DataText = "";
            this.StockBlnktRemark1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.StockBlnktRemark1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.StockBlnktRemark1_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StockBlnktRemark1_tEdit.Location = new System.Drawing.Point(148, 202);
            this.StockBlnktRemark1_tEdit.MaxLength = 3;
            this.StockBlnktRemark1_tEdit.Name = "StockBlnktRemark1_tEdit";
            this.StockBlnktRemark1_tEdit.Size = new System.Drawing.Size(43, 24);
            this.StockBlnktRemark1_tEdit.TabIndex = 12;
            // 
            // StockBlnktRemark2_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockBlnktRemark2_tEdit.ActiveAppearance = appearance19;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockBlnktRemark2_tEdit.Appearance = appearance20;
            this.StockBlnktRemark2_tEdit.AutoSelect = true;
            this.StockBlnktRemark2_tEdit.DataText = "";
            this.StockBlnktRemark2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.StockBlnktRemark2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.StockBlnktRemark2_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StockBlnktRemark2_tEdit.Location = new System.Drawing.Point(198, 202);
            this.StockBlnktRemark2_tEdit.MaxLength = 5;
            this.StockBlnktRemark2_tEdit.Name = "StockBlnktRemark2_tEdit";
            this.StockBlnktRemark2_tEdit.Size = new System.Drawing.Size(51, 24);
            this.StockBlnktRemark2_tEdit.TabIndex = 13;
            // 
            // MainMngWarehouse_Title_uLabel
            // 
            this.MainMngWarehouse_Title_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.MainMngWarehouse_Title_uLabel.Location = new System.Drawing.Point(12, 172);
            this.MainMngWarehouse_Title_uLabel.Name = "MainMngWarehouse_Title_uLabel";
            this.MainMngWarehouse_Title_uLabel.Size = new System.Drawing.Size(130, 24);
            this.MainMngWarehouse_Title_uLabel.TabIndex = 176;
            this.MainMngWarehouse_Title_uLabel.Text = "主管倉庫";
            // 
            // StockBlnktRemark_Title_uLabel
            // 
            this.StockBlnktRemark_Title_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.StockBlnktRemark_Title_uLabel.Location = new System.Drawing.Point(12, 202);
            this.StockBlnktRemark_Title_uLabel.Name = "StockBlnktRemark_Title_uLabel";
            this.StockBlnktRemark_Title_uLabel.Size = new System.Drawing.Size(130, 24);
            this.StockBlnktRemark_Title_uLabel.TabIndex = 177;
            this.StockBlnktRemark_Title_uLabel.Text = "在庫一括リマーク";
            // 
            // tEdit_MainMngWarehouseCd
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MainMngWarehouseCd.ActiveAppearance = appearance1;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_MainMngWarehouseCd.Appearance = appearance2;
            this.tEdit_MainMngWarehouseCd.AutoSelect = true;
            this.tEdit_MainMngWarehouseCd.DataText = "";
            this.tEdit_MainMngWarehouseCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MainMngWarehouseCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.tEdit_MainMngWarehouseCd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_MainMngWarehouseCd.Location = new System.Drawing.Point(148, 172);
            this.tEdit_MainMngWarehouseCd.MaxLength = 6;
            this.tEdit_MainMngWarehouseCd.Name = "tEdit_MainMngWarehouseCd";
            this.tEdit_MainMngWarehouseCd.Size = new System.Drawing.Size(51, 24);
            this.tEdit_MainMngWarehouseCd.TabIndex = 9;
            this.tEdit_MainMngWarehouseCd.ValueChanged += new System.EventHandler(this.tEdit_MainMngWarehouseCd_ValueChanged);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // tNedit_CustomerCode
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.tNedit_CustomerCode.ActiveAppearance = appearance9;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_CustomerCode.Appearance = appearance10;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(148, 142);
            this.tNedit_CustomerCode.MaxLength = 12;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode.TabIndex = 6;
            // 
            // MAKHN09330UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(814, 363);
            this.Controls.Add(this.tNedit_CustomerCode);
            this.Controls.Add(this.tEdit_MainMngWarehouseCd);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.MainMngWarehouseGuide_Button);
            this.Controls.Add(this.CustomerGuide_Button);
            this.Controls.Add(this.StockBlnktRemark_Title_uLabel);
            this.Controls.Add(this.MainMngWarehouse_Title_uLabel);
            this.Controls.Add(this.StockBlnktRemark2_tEdit);
            this.Controls.Add(this.StockBlnktRemark1_tEdit);
            this.Controls.Add(this.MainMngWarehouseNm_tEdit);
            this.Controls.Add(this.CustomerName_tEdit);
            this.Controls.Add(this.Customer_Title_uLabel);
            this.Controls.Add(this.WarehouseNote1_Title_Label);
            this.Controls.Add(this.WarehouseNote1_tEdit);
            this.Controls.Add(this.tEdit_WarehouseCode);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.WarehouseCdName_tEdit);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.WarehouseName_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.WarehouseCode_Title_Label);
            this.Controls.Add(this.SectionGuideNm_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Section_Title_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKHN09330UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "倉庫設定";
            this.Load += new System.EventHandler(this.MAKHN09230UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKHN09230UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKHN09230UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCdName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseNote1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainMngWarehouseNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MainMngWarehouseCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        # region Events

        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

        # endregion
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        #region Private Menbers

        private SecInfoAcs   _secInfoAcs;       // 拠点用アクセスクラス
        private WarehouseAcs _warehouseAcs;     // 倉庫用アクセスクラス
        private CustomerInfoAcs _customerInfoAcs;  // ADD 2008/06/04

        private string _enterpriseCode;         // 企業コード
        //private Hashtable _mainTable;           // 拠点用ハッシュテーブル  // DEL 2008/06/04
        private Hashtable _detailsTable;        // 倉庫用ハッシュテーブル
        //private Hashtable _allSearchHash;       // 全レコード確保用  // DEL 2008/06/04

        // プロパティ用
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
        private bool _cusotmerGuideSelected;
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // ADD 2009/04/16 ------>>>
        // 得意先情報キャッシュ
        private ArrayList _customerList;
        // 倉庫情報キャッシュ
        private Dictionary<string, Warehouse> _warehouseDic;
        // ADD 2009/04/16 ------<<<
        
        //_GridIndexバッファ（メインフレーム最小化対応）
        //private int _mainIndexBuf;  // DEL 2008/06/04
        private int _detailsIndexBuf;
        //private string _targetTableBuf;  // DEL 2008/06/04

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        // 終了時の編集チェック用
        private Warehouse _warehouseClone;

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string DELETE_DATE_TITLE      = "削除日";
        private const string SECTIONCODE_TITLE      = "管理拠点コード";
        private const string SECTIONGUIDENM_TITLE   = "管理拠点名";
        private const string WAREHOUSECODE_TITLE    = "倉庫コード";
        private const string WAREHOUSENAME_TITLE    = "倉庫名";
        private const string WAREHOUSENOTE_TITLE   = "倉庫備考";
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string WAREHOUSENOTE2_TITLE   = "倉庫備考2";
        private const string WAREHOUSENOTE3_TITLE   = "倉庫備考3";
        private const string WAREHOUSENOTE4_TITLE   = "倉庫備考4";
        private const string WAREHOUSENOTE5_TITLE   = "倉庫備考5";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string CUSTOMERCODE_TITLE = "得意先コード";
        private const string CUSTOMERNAME_TITLE = "得意先名";
        private const string MAINMNGWAREHOUSECD_TITLE = "主管倉庫コード";
        private const string MAINMNGWAREHOUSENM_TITLE = "主管倉庫名";
        private const string STOCKBLNKREMARK_TITLE = "在庫一括リマーク";
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // テーブル名称
        //private const string MAIN_TABLE     = "SecInfoSet"; // 拠点  // DEL 2008/06/04
        private const string DETAILS_TABLE  = "Warehouse";  // 倉庫

        // ガイドキー
        private const string MAIN_GUID_KEY = "MainGuid";
        private const string DETAILS_GUID_KEY = "DetailsGuid";

        // 画面レイアウト用定数
        private const int BUTTON_LOCATION1_X = 296;     // 完全削除ボタン位置X
        private const int BUTTON_LOCATION2_X = 423;     // 復活ボタン位置X
        private const int BUTTON_LOCATION3_X = 550;     // 保存ボタン位置X
        private const int BUTTON_LOCATION4_X = 677;     // 閉じるボタン位置X
        private const int BUTTON_LOCATION_Y = 10;        // ボタン位置Y(共通)

        // Message関連定義
        private const string ASSEMBLY_ID = "MAKHN09330U";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";

        #endregion

        # region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAKHN09330UA());
        }
        # endregion

        # region Properties

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

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        #region IMasterMaintenanceMultiType メンバ

        # region ▼Properties
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
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
        # endregion ▼Properties

        # region ▼Public Methods
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add(DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(WAREHOUSECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(WAREHOUSENAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(WAREHOUSENOTE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(CUSTOMERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(MAINMNGWAREHOUSECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(MAINMNGWAREHOUSENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(STOCKBLNKREMARK_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(DETAILS_GUID_KEY, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = DETAILS_TABLE;
        }
        # endregion ▼Public Methods

        # region ▼Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #endregion
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        # region Public Methods
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { false, true };
            return logicalDelete;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _detailsGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] gridIcon = { _mainGridIcon, _detailsGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] defaultAutoFill = { true, true };
            return defaultAutoFill;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
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
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, true };
            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                newButtonEnabled[1] = false;
            }
            return newButtonEnabled;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] modifyButtonEnabled = { false, true };
            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                modifyButtonEnabled[1] = false;
            }
            return modifyButtonEnabled;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, true };
            // 親データがない場合は、無効
            if (this._mainDataIndex < 0)
            {
                deleteButtonEnabled[1] = false;
            }
            return deleteButtonEnabled;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = DETAILS_TABLE;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 拠点検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            totalCount = 0;

            try
            {
                // クリア
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
                this._mainTable.Clear();
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                this._detailsTable.Clear();
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                if (this._secInfoAcs.SecInfoSetList.Length > 0)
                {
                    // 取得した拠点情報クラスをデータセットへ展開する
                    int index = 0;
                    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                    {
                        // 拠点情報クラスデータセット展開処理
                        MainToDataSet(secInfoSet.Clone(), index);
                        ++index;
                    }

                    totalCount = this._secInfoAcs.SecInfoSetList.Length;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                ArrayList retList = new ArrayList();
                status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        int index = 0;
            
                        foreach (Warehouse warehouse in retList)
                        {
                            if (this._detailsTable.ContainsKey(warehouse.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(warehouse.Clone(), index);
                                ++index;
                            }
                        }
                        totalCount = retList.Count;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAKHN09330U", 						// アセンブリＩＤまたはクラスＩＤ
                            "倉庫設定", 					    // プログラム名称
                            "Search", 					        // 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._warehouseAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                }
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
            }
            catch (Exception)
            {
                // サーチ
                TMsgDisp.Show(
                    this,								  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                    ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                    this.Text,							  // プログラム名称
                    "Search",							  // 処理名称
                    TMsgDisp.OPE_GET,					  // オペレーション
                    ERR_READ_MSG,						  // 表示するメッセージ 
                    status,								  // ステータス値
                    this._secInfoAcs,				      // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,				  // 表示するボタン
                    MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                status = -1;
                return status;
            }

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // 実装なし
            return 9;
        }

        /// <summary>
        /// 倉庫検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList WarehouseList = null;

            // 選択されている拠点コードを取得する
            //string sectionCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];  // DEL 2008/06/04

            // 倉庫取得
            //status = this._warehouseAcs.SearchAll(out WarehouseList, this._enterpriseCode, sectionCode);  // DEL 2008/06/04
            status = this._warehouseAcs.SearchAll(out WarehouseList, this._enterpriseCode);  // ADD 2008/06/04
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                        this._detailsTable.Clear();

                        int index = 0;
                        foreach (Warehouse warehouse in WarehouseList)
                        {
                            if (this._detailsTable.ContainsKey(warehouse.FileHeaderGuid) == false)
                            {
                                DetailsToDataSet(warehouse.Clone(), index);
                                ++index;
                            }
                        }

                        totalCount = WarehouseList.Count;

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // データなしの場合はグリッドをクリア
                        this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Clear();
                        this._detailsTable.Clear();
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "DetailsDataSearch", 				// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            ERR_READ_MSG,						// 表示するメッセージ 
                            status, 							// ステータス値
                            this._warehouseAcs, 			    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }

            return status;
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            // 未実装
            return 9;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Delete()
        {
            int status = 0;

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 倉庫テーブルの場合
                case DETAILS_TABLE:
                    {
                        // 倉庫論理削除処理
                        status = LogicalDeleteWarehouse();
                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 倉庫論理削除処理
            status = LogicalDeleteWarehouse();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Print()
        {
            // 印刷機能無しの為未実装
            return 0;
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            // 拠点Grid
            Hashtable main = new Hashtable();
            main.Add(SECTIONCODE_TITLE,     new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            main.Add(SECTIONGUIDENM_TITLE,  new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            main.Add(MAIN_GUID_KEY,         new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));

            // 倉庫Grid
            Hashtable details = new Hashtable();
            details.Add(DELETE_DATE_TITLE,      new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            details.Add(SECTIONCODE_TITLE,      new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSECODE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENAME_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENOTE_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            
            details.Add(WAREHOUSENOTE2_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENOTE3_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENOTE4_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            details.Add(WAREHOUSENOTE5_TITLE,   new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "",   Color.Black));
            
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
        /// 拠点オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="warehouse">拠点設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 拠点設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void MainToDataSet(SecInfoSet secInfoSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
                this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][SECTIONCODE_TITLE] = secInfoSet.SectionCode;
            // 拠点名称
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = secInfoSet.SectionGuideNm;
            // GUID
            this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][MAIN_GUID_KEY] = secInfoSet.FileHeaderGuid;


            // ハッシュテーブル更新
            if (this._mainTable.ContainsKey(secInfoSet.FileHeaderGuid) == true)
            {
                this._mainTable.Remove(secInfoSet.FileHeaderGuid);
            }
            this._mainTable.Add(secInfoSet.FileHeaderGuid, secInfoSet);
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 倉庫設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="warehouse">倉庫設定オブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 倉庫設定クラスをデータセットに格納します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void DetailsToDataSet(Warehouse warehouse, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[DETAILS_TABLE].NewRow();
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Add(dataRow);

                // indexを行の最終行番号する
                index = this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count - 1;
            }

            // 論理削除区分
            if (warehouse.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DELETE_DATE_TITLE] = warehouse.UpdateDateTimeJpInFormal;
            }

            // 拠点コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONCODE_TITLE] = warehouse.SectionCode;
            // 倉庫コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSECODE_TITLE] = warehouse.WarehouseCode;
            // 倉庫名称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENAME_TITLE] = warehouse.WarehouseName;
            // 倉庫備考
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE_TITLE] = warehouse.WarehouseNote1;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE2_TITLE] = warehouse.WarehouseNote2;
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE3_TITLE] = warehouse.WarehouseNote3;
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE4_TITLE] = warehouse.WarehouseNote4;
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][WAREHOUSENOTE5_TITLE] = warehouse.WarehouseNote5;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 拠点名称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][SECTIONGUIDENM_TITLE] = GetSectionName(warehouse.SectionCode);
            // 得意先コード
            if (warehouse.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODE_TITLE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERCODE_TITLE] = warehouse.CustomerCode.ToString("00000000");
            }

            // 得意先名称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][CUSTOMERNAME_TITLE] = GetCustomerName(warehouse.CustomerCode);

            // 主管倉庫コード
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][MAINMNGWAREHOUSECD_TITLE] = warehouse.MainMngWarehouseCd;

            // 主管倉庫名称
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][MAINMNGWAREHOUSENM_TITLE] = GetWarehouseName(warehouse.MainMngWarehouseCd);

            // 在庫一括リマーク
            if ((warehouse.StockBlnktRemark != null) && (warehouse.StockBlnktRemark.Length >= 8))
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STOCKBLNKREMARK_TITLE] = warehouse.StockBlnktRemark.Substring(0, 3) + " " +
                                                                                             warehouse.StockBlnktRemark.Substring(3, 5);
            }
            else
            {
                this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][STOCKBLNKREMARK_TITLE] = warehouse.StockBlnktRemark;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // GUID
            this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[index][DETAILS_GUID_KEY] = warehouse.FileHeaderGuid;
            
            // ハッシュテーブル更新
            if (this._detailsTable.ContainsKey(warehouse.FileHeaderGuid) == true)
            {
                this._detailsTable.Remove(warehouse.FileHeaderGuid);
            }
            this._detailsTable.Add(warehouse.FileHeaderGuid, warehouse);
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            int status;
            CustomerInfo customerInfo = new CustomerInfo();

            try
            {
                // DEL 2009/04/16 ------>>>
                //status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                //if (status == 0)
                //{
                //    customerName = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                //}
                // DEL 2009/04/16 ------<<<

                // ADD 2009/04/16 ------>>>
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        customerName = customerSearchRet.Name.Trim() + customerSearchRet.Name2.Trim();
                        break;
                    }
                }

                if (customerName == "")
                {
                    status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        customerName = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                    }
                }
                // ADD 2009/04/16 ------<<<
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            // DEL 2009/04/16 ------>>>
            //int status;
            //WarehouseAcs warehouseAcs = new WarehouseAcs();
            //ArrayList retList = new ArrayList();
            // DEL 2009/04/16 ------<<<
                
            try
            {
                // DEL 2009/04/16 ------>>>
                //status = warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                //if (status == 0)
                //{
                //    foreach (Warehouse warehouse in retList)
                //    {
                //        if (warehouse.LogicalDeleteCode == 0)
                //        {
                //            if (warehouse.WarehouseCode.Trim() == warehouseCode.Trim().PadLeft(4, '0'))
                //            {
                //                warehouseName = warehouse.WarehouseName.Trim();
                //                break;
                //            }
                //        }
                //    }
                //}
                // DEL 2009/04/16 ------<<<

                // ADD 2009/04/16 ------>>>
                if (_warehouseDic.ContainsKey(warehouseCode.Trim().PadLeft(4, '0')))
                {
                    Warehouse warehouse = _warehouseDic[warehouseCode.Trim().PadLeft(4, '0')];
                    warehouseName = warehouse.WarehouseName.Trim();
                }
                // ADD 2009/04/16 ------<<<
            }
            catch
            {
                warehouseName = "";
            }

            return warehouseName;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            // DEL 2009/04/16 ------>>>
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //secInfoAcs.ResetSectionInfo();
            // DEL 2009/04/16 ------<<<
                
            try
            {
                //foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)      // DEL 2009/04/16
                foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)       // ADD 2009/04/16
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
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // ADD 2009/06/29 ------>>>
        /// <summary>
        /// 得意先存在チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>true：OK、false：NG</returns>
        /// <remarks>
        /// <br>Note       : 得意先が存在するかチェックします。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            int status;
            CustomerInfo customerInfo = new CustomerInfo();

            try
            {
                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        check = true;
                        break;
                    }
                }

                if (!check)
                {
                    status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                    if (status == 0)
                    {
                        check = true;
                    }
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        // ADD 2009/06/29 ------<<<
        
        // ADD 2009/04/16 ------>>>
        /// <summary>
        /// キャッシュ情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先と倉庫の名称をキャッシュ化。</br>
        /// </remarks>
        private void GetCacheData()
        {
            // 得意先名称リスト取得
            this.GetCustomerNameList();
            // 倉庫名称リスト取得
            this.GetWarehouseNameList();
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
        /// 倉庫名称リスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫名称リストを取得します。</br>
        /// </remarks>
        private void GetWarehouseNameList()
        {
            int status;
            WarehouseAcs warehouseAcs = new WarehouseAcs();
            ArrayList retList = new ArrayList();

            _warehouseDic = new Dictionary<string, Warehouse>();

            status = warehouseAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (Warehouse warehouse in retList)
                {
                    if (warehouse.LogicalDeleteCode == 0)
                    {
                        if (!_warehouseDic.ContainsKey(warehouse.WarehouseCode.Trim()))
                        {
                            _warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
        }
        // ADD 2009/04/16 ------<<<
                
        #region DEL 2008/06/04 Partsman用に変更
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //DataTable mainTable     = new DataTable(MAIN_TABLE);    // 拠点  // DEL 2008/06/04
            DataTable detailsTable  = new DataTable(DETAILS_TABLE); // 倉庫

            // Addを行う順番が、列の表示順位となります。
            mainTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            mainTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));
            mainTable.Columns.Add(MAIN_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(mainTable);
            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSECODE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENAME_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE2_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE3_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE4_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE5_TITLE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/04 Partsman用に変更

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable detailsTable = new DataTable(DETAILS_TABLE); // 倉庫

            // Addを行う順番が、列の表示順位となります。
            detailsTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSECODE_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENAME_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(SECTIONGUIDENM_TITLE, typeof(string));
            detailsTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));
            detailsTable.Columns.Add(CUSTOMERNAME_TITLE, typeof(string));
            detailsTable.Columns.Add(MAINMNGWAREHOUSECD_TITLE, typeof(string));
            detailsTable.Columns.Add(MAINMNGWAREHOUSENM_TITLE, typeof(string));
            detailsTable.Columns.Add(STOCKBLNKREMARK_TITLE, typeof(string));
            detailsTable.Columns.Add(WAREHOUSENOTE_TITLE, typeof(string));
            detailsTable.Columns.Add(DETAILS_GUID_KEY, typeof(Guid));
            this.Bind_DataSet.Tables.Add(detailsTable);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void ScreenClear()
        {
            // モードラベル
            this.Mode_Label.Text = INSERT_MODE;

            // ボタン
            this.Delete_Button.Visible  = true;  // 完全削除ボタン
            this.Revive_Button.Visible  = true;  // 復活ボタン
            this.Ok_Button.Visible      = true;  // 保存ボタン
            this.Cancel_Button.Visible  = true;  // 閉じるボタン
            this.Renewal_Button.Visible = true;  // 最新情報ボタン  // ADD 2009/04/16
            this.Delete_Button.Location = new Point(BUTTON_LOCATION1_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
            this.Revive_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 復活ボタン位置
            this.Ok_Button.Location     = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 保存ボタン位置
            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            SectionGuide_Button.Visible = true;
            CustomerGuide_Button.Visible = true;
            MainMngWarehouseGuide_Button.Visible = true;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // 拠点部
            this.tEdit_SectionCode.Clear();
            this.SectionGuideNm_tEdit.Text = "";
            //this.SectionCode_tEdit.Enabled = false;  // DEL 2008/06/04
            this.tEdit_SectionCode.Enabled = true;  // ADD 2008/06/03
            this.SectionGuideNm_tEdit.Enabled = false;

            // 倉庫部
            this.tEdit_WarehouseCode.Clear();
            this.WarehouseCdName_tEdit.Clear();
            this.WarehouseNote1_tEdit.Clear();
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.WarehouseNote2_tEdit.Clear();
            this.WarehouseNote3_tEdit.Clear();
            this.WarehouseNote4_tEdit.Clear();
            this.WarehouseNote5_tEdit.Clear();
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            this.tEdit_WarehouseCode.Enabled = true;
            this.WarehouseCdName_tEdit.Enabled = true;
            this.WarehouseNote1_tEdit.Enabled = true;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.WarehouseNote2_tEdit.Enabled = true;
            this.WarehouseNote3_tEdit.Enabled = true;
            this.WarehouseNote4_tEdit.Enabled = true;
            this.WarehouseNote5_tEdit.Enabled = true;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this.tNedit_CustomerCode.Clear();
            this.CustomerName_tEdit.Clear();
            this.tEdit_MainMngWarehouseCd.Clear();
            this.MainMngWarehouseNm_tEdit.Clear();
            this.StockBlnktRemark1_tEdit.Clear();
            this.StockBlnktRemark2_tEdit.Clear();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // UI画面表示時のチラつきを抑える為に、ここでサイズ等変更
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 倉庫テーブルの場合
                case DETAILS_TABLE:
                    {
                        // 新規の場合
                        if (this._detailsDataIndex < 0)
                        {
                            ScreenInputPermissionControl(3);                        // 画面入力許可制御
                            break;
                        }
                        // 削除の場合
                        if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DELETE_DATE_TITLE] != "")
                        {
                            ScreenInputPermissionControl(5);                        // 画面入力許可制御
                            break;
                        }
                        // 更新の場合
                        else
                        {
                            ScreenInputPermissionControl(4);                        // 画面入力許可制御
                            break;
                        }
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 新規の場合
            if (this._dataIndex < 0)
            {
                ScreenInputPermissionControl(3);                        // 画面入力許可制御
            }
            else
            {
                // 削除の場合
                if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
                {
                    ScreenInputPermissionControl(5);                        // 画面入力許可制御
                }
                // 更新の場合
                else
                {
                    ScreenInputPermissionControl(4);                        // 画面入力許可制御
                }
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="setType">設定タイプ 0:親-新規, 1:親-更新, 2:親-削除, 3:子-新規, 4:子-更新, 5:子-削除</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void ScreenInputPermissionControl(int setType)
        {
            switch (setType)
            {
                // 0:拠点-新規
                case 0:
                    {
                        break;
                    }
                // 1:拠点-更新
                case 1:
                    {
                        break;
                    }
                // 2:拠点-削除
                case 2:
                    {
                        break;
                    }
                // 3:倉庫-新規
                case 3:
                    {
                        // ボタン
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Renewal_Button.Visible = true;     // ADD 2009/04/16

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;
                        this.tEdit_MainMngWarehouseCd.Enabled = true;
                        this.MainMngWarehouseGuide_Button.Enabled = true;
                        this.StockBlnktRemark1_tEdit.Enabled = true;
                        this.StockBlnktRemark2_tEdit.Enabled = true;

                        SectionGuide_Button.Visible = true;
                        CustomerGuide_Button.Visible = true;
                        MainMngWarehouseGuide_Button.Visible = true;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        break;
                    }
                // 4:倉庫-更新
                case 4:
                    {
                        // 表示項目
                        this.tEdit_WarehouseCode.Enabled = false;

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;
                        this.tEdit_MainMngWarehouseCd.Enabled = true;
                        this.MainMngWarehouseGuide_Button.Enabled = true;
                        this.StockBlnktRemark1_tEdit.Enabled = true;
                        this.StockBlnktRemark2_tEdit.Enabled = true;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        // ボタン
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;
                        this.Renewal_Button.Visible = true;     // ADD 2009/04/16

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        SectionGuide_Button.Visible = true;
                        CustomerGuide_Button.Visible = true;
                        MainMngWarehouseGuide_Button.Visible = true;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        break;
                    }
                // 5:倉庫-削除
                case 5:
                    {
                        // 表示項目
                        this.tEdit_WarehouseCode.Enabled = false;
                        this.WarehouseCdName_tEdit.Enabled = false;
                        this.WarehouseNote1_tEdit.Enabled = false;
                        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                        this.WarehouseNote2_tEdit.Enabled = false;
                        this.WarehouseNote3_tEdit.Enabled = false;
                        this.WarehouseNote4_tEdit.Enabled = false;
                        this.WarehouseNote5_tEdit.Enabled = false;
                           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_MainMngWarehouseCd.Enabled = false;
                        this.MainMngWarehouseGuide_Button.Enabled = false;
                        this.StockBlnktRemark1_tEdit.Enabled = false;
                        this.StockBlnktRemark2_tEdit.Enabled = false;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        // ボタン
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Renewal_Button.Visible = false;    // ADD 2009/04/16
                        this.Delete_Button.Location = new Point(BUTTON_LOCATION2_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
                        this.Revive_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 復活ボタン位置
                        this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置

                        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                        SectionGuide_Button.Visible = true;
                        CustomerGuide_Button.Visible = true;
                        MainMngWarehouseGuide_Button.Visible = true;
                        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                        // 拠点が論理削除の場合は復活禁止
                        Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][MAIN_GUID_KEY];
                        SecInfoSet pustSecInfoSet = (SecInfoSet)this._mainTable[guid];
                        if (pustSecInfoSet.LogicalDeleteCode != 0)
                        {
                            this.Revive_Button.Visible = false;
                            this.Delete_Button.Location = new Point(BUTTON_LOCATION3_X, BUTTON_LOCATION_Y); // 完全削除ボタン位置
                            this.Cancel_Button.Location = new Point(BUTTON_LOCATION4_X, BUTTON_LOCATION_Y); // 閉じるボタン位置
                        }
                           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                        break;
                    }
            }
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 倉庫テーブルの場合
                case DETAILS_TABLE:
                    {
                        Warehouse warehouse = new Warehouse();
                        // 新規の場合
                        if (this._detailsDataIndex < 0)
                        {
                            // 画面展開処理
                            WarehouseToScreen(warehouse);

                            // クローン作成
                            this._warehouseClone = warehouse.Clone();
                            DispToWarehouse(ref this._warehouseClone);

                            // フォーカス設定
                            this.WarehouseCode_tEdit.Focus();

                            break;
                        }
                        // 削除の場合
                        if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DELETE_DATE_TITLE] != "")
                        {
                            // 削除モード
                            this.Mode_Label.Text = DELETE_MODE;

                            // 表示情報取得
                            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DETAILS_GUID_KEY];
                            warehouse = (Warehouse)this._detailsTable[guid];

                            // 画面展開処理
                            WarehouseToScreen(warehouse);

                            break;
                        }
                        // 更新の場合
                        else
                        {
                            // 更新モード
                            this.Mode_Label.Text = UPDATE_MODE;

                            // 表示情報取得
                            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._detailsDataIndex][DETAILS_GUID_KEY];
                            warehouse = (Warehouse)this._detailsTable[guid];

                            // 画面展開処理
                            WarehouseToScreen(warehouse);

                            // クローン作成
                            this._warehouseClone = warehouse.Clone();
                            DispToWarehouse(ref this._warehouseClone);

                            // フォーカス設定
                            this.WarehouseCdName_tEdit.SelectAll();

                            break;
                        }
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            Warehouse warehouse = new Warehouse();
            // 新規の場合
            if (this._dataIndex < 0)
            {
                // 画面展開処理
                WarehouseToScreen(warehouse);

                // クローン作成
                this._warehouseClone = warehouse.Clone();
                DispToWarehouse(ref this._warehouseClone);

                // フォーカス設定
                this.tEdit_WarehouseCode.Focus();
            }
            else
            {
                // 削除の場合
                if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DELETE_DATE_TITLE] != "")
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // 表示情報取得
                    Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                    warehouse = (Warehouse)this._detailsTable[guid];

                    // 画面展開処理
                    WarehouseToScreen(warehouse);
                }
                // 更新の場合
                else
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 表示情報取得
                    Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                    warehouse = (Warehouse)this._detailsTable[guid];

                    // 画面展開処理
                    WarehouseToScreen(warehouse);

                    // クローン作成
                    this._warehouseClone = warehouse.Clone();
                    DispToWarehouse(ref this._warehouseClone);

                    // フォーカス設定
                    this.WarehouseCdName_tEdit.SelectAll();
                }
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            //_GridIndexバッファ保持
            this._detailsIndexBuf = this._dataIndex;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = this._mainDataIndex;
            this._targetTableBuf = this._targetTableName;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 拠点クラス画面展開処理
        /// </summary>
        /// <param name="warehouse">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void SecInfoSetToScreen(SecInfoSet secInfoSet)
        {
            this.SectionCode_tEdit.Text     = secInfoSet.SectionCode;       // 拠点コード
            this.SectionGuideNm_tEdit.Text  = secInfoSet.SectionGuideNm;    // 拠点名称
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 倉庫クラス画面展開処理
        /// </summary>
        /// <param name="warehouse">倉庫オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void WarehouseToScreen(Warehouse warehouse)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 拠点コード
            this.SectionCode_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];
            // 拠点名称
            this.SectionGuideNm_tEdit.Text = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONGUIDENM_TITLE];
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.Trim();    // 倉庫コード
            this.WarehouseCdName_tEdit.Text = warehouse.WarehouseName.Trim();    // 倉庫名称
            this.WarehouseNote1_tEdit.Text = warehouse.WarehouseNote1.Trim();  // 倉庫備考1
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.WarehouseNote2_tEdit.Text = warehouse.WarehouseNote2;  // 倉庫備考2
            this.WarehouseNote3_tEdit.Text = warehouse.WarehouseNote3;  // 倉庫備考3
            this.WarehouseNote4_tEdit.Text = warehouse.WarehouseNote4;  // 倉庫備考4
            this.WarehouseNote5_tEdit.Text = warehouse.WarehouseNote5;  // 倉庫備考5
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 拠点コード
            this.tEdit_SectionCode.DataText = warehouse.SectionCode.Trim();
            // 拠点名称
            this.SectionGuideNm_tEdit.DataText = GetSectionName(warehouse.SectionCode);

            // 得意先コード
            this.tNedit_CustomerCode.SetInt(warehouse.CustomerCode);
            // 得意先名称
            this.CustomerName_tEdit.DataText = GetCustomerName(warehouse.CustomerCode);

            // 主管倉庫コード
            this.tEdit_MainMngWarehouseCd.DataText = warehouse.MainMngWarehouseCd.Trim();
            // 主管倉庫名称
            this.MainMngWarehouseNm_tEdit.DataText = GetWarehouseName(warehouse.MainMngWarehouseCd);

            // 在庫一括リマーク
            if (warehouse.StockBlnktRemark.Trim() != "")
            {
                this.StockBlnktRemark1_tEdit.DataText = warehouse.StockBlnktRemark.Substring(0, 3).Trim();
                this.StockBlnktRemark2_tEdit.DataText = warehouse.StockBlnktRemark.Substring(3, 5).Trim();
            }
            else
            {
                this.StockBlnktRemark1_tEdit.DataText = "";
                this.StockBlnktRemark2_tEdit.DataText = "";
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面情報拠点クラス格納処理
        /// </summary>
        /// <param name="secInfoSet">拠点オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からオブジェクトにデータを格納します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
        {
            secInfoSet.SectionCode      = this.SectionCode_tEdit.Text;      // 拠点コード
            secInfoSet.SectionGuideNm   = this.SectionGuideNm_tEdit.Text;   // 拠点名称
            secInfoSet.EnterpriseCode   = this._enterpriseCode;             // 企業コード
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 画面情報倉庫クラス格納処理
        /// </summary>
        /// <param name="warehouse">倉庫オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から倉庫オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void DispToWarehouse(ref Warehouse warehouse)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (Mode_Label.Text == INSERT_MODE)
            {
                // 拠点コード
                warehouse.SectionCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE];
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // 企業コード
            warehouse.EnterpriseCode = this._enterpriseCode;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 倉庫テーブルの場合
                case DETAILS_TABLE:
                    {
                        warehouse.SectionCode   = this.SectionCode_tEdit.Text;
                        warehouse.WarehouseCode = this.WarehouseCode_tEdit.Text;
                        warehouse.WarehouseName = this.WarehouseCdName_tEdit.Text;
                        warehouse.WarehouseNote1 = this.WarehouseNote1_tEdit.Text;
                        warehouse.WarehouseNote2 = this.WarehouseNote2_tEdit.Text;
                        warehouse.WarehouseNote3 = this.WarehouseNote3_tEdit.Text;
                        warehouse.WarehouseNote4 = this.WarehouseNote4_tEdit.Text;
                        warehouse.WarehouseNote5 = this.WarehouseNote5_tEdit.Text;
                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouse.SectionCode = this.tEdit_SectionCode.Text;
            warehouse.WarehouseCode = this.tEdit_WarehouseCode.Text;
            warehouse.WarehouseName = this.WarehouseCdName_tEdit.Text;
            warehouse.WarehouseNote1 = this.WarehouseNote1_tEdit.Text;
            warehouse.CustomerCode = this.tNedit_CustomerCode.GetInt();
            warehouse.MainMngWarehouseCd = this.tEdit_MainMngWarehouseCd.DataText.Trim();
            warehouse.StockBlnktRemark = this.StockBlnktRemark1_tEdit.DataText.Trim().PadRight(3, ' ') + this.StockBlnktRemark2_tEdit.DataText.Trim().PadRight(5, ' ');
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
           bool result = true;
           
           switch (this._targetTableName)
           {
               // 拠点テーブルの場合
               case MAIN_TABLE:
                   {
                       break;
                   }
               // 倉庫テーブルの場合
               case DETAILS_TABLE:
                   {
                       // 倉庫コード
                       if (this.WarehouseCode_tEdit.Text == "")
                       {
                           control = this.WarehouseCode_tEdit;
                           message = this.WarehouseCode_Title_Label.Text + "を入力して下さい。";
                           result = false;
                       }
                       // 倉庫名称
                       else if (this.WarehouseCdName_tEdit.Text.Trim() == "")
                       {
                           control = this.WarehouseCdName_tEdit;
                           message = this.WarehouseName_Title_Label.Text + "を入力して下さい。";
                           result = false;
                       }
                       break;
                   }
           }
              --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 倉庫コード
            if (this.tEdit_WarehouseCode.Text == "")
            {
                control = this.tEdit_WarehouseCode;
                message = this.WarehouseCode_Title_Label.Text + "を入力して下さい。";
                return (false);
            }
            // 倉庫名称
            if (this.WarehouseCdName_tEdit.Text.Trim() == "")
            {
                control = this.WarehouseCdName_tEdit;
                message = this.WarehouseName_Title_Label.Text + "を入力して下さい。";
                return (false);
            }
            // 拠点コード
            if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                control = this.tEdit_SectionCode;
                message = this.Section_Title_Label.Text + "を入力して下さい。";
                return (false);
            }
            if (GetSectionName(this.tEdit_SectionCode.DataText.Trim()) == "")
            {
                control = this.tEdit_SectionCode;
                message = "マスタに登録されていません。";
                return (false);
            }
            // 得意先コード
            if (this.tNedit_CustomerCode.DataText.Trim() != "")
            {
                //if (GetCustomerName(this.tNedit_CustomerCode.GetInt()) == "") // DEL 2009/06/29
                if (!CheckCustomer(this.tNedit_CustomerCode.GetInt()))  // ADD 2009/06/29
                {
                    control = this.tNedit_CustomerCode;
                    message = "マスタに登録されていません。";
                    return (false);
                }

                // ADD 2008/10/09 不具合対応[6401] ---------->>>>>
                if (this.tEdit_MainMngWarehouseCd.DataText.Trim() == "")
                {
                    control = this.tEdit_MainMngWarehouseCd;
                    message = "主管倉庫を設定してください。";
                    return (false);
                }
                // ADD 2008/10/09 不具合対応[6401] ----------<<<<<
            }
            // 主管倉庫コード
            if (this.tEdit_MainMngWarehouseCd.DataText.Trim() != "")
            {
                if (GetWarehouseName(this.tEdit_MainMngWarehouseCd.DataText.Trim()) == "")
                {
                    control = this.tEdit_MainMngWarehouseCd;
                    message = "マスタに登録されていません。";
                    return (false);
                }

                // ADD 2008/10/09 不具合対応[6401][6402] ---------->>>>>
                if (this.tNedit_CustomerCode.DataText.Trim() == "")
                {
                    control = this.tNedit_CustomerCode;
                    message = "得意先を設定してください。";
                    return (false);
                }

                int status = 0;
                ArrayList retList = new ArrayList();
                status = this._warehouseAcs.SearchAll(out retList, this._enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        foreach (Warehouse warehouse in retList)
                        {
                            if (warehouse.WarehouseCode.Trim() == this.tEdit_MainMngWarehouseCd.DataText.Trim())
                            {
                                if (warehouse.MainMngWarehouseCd.Trim() != "")
                                {
                                    control = this.tEdit_MainMngWarehouseCd;
                                    message = "委託倉庫のため設定できません。";
                                    return (false);
                                }

                                // ADD 2008/12/05 不具合対応[8764] ---------->>>>>
                                if (warehouse.LogicalDeleteCode != 0)
                                {
                                    control = this.tEdit_MainMngWarehouseCd;
                                    message = "削除済み倉庫のため設定できません。";
                                    return (false);
                                }
                                // ADD 2008/12/05 不具合対応[8764] ----------<<<<<
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    
                }
                // ADD 2008/10/09 不具合対応[6401][6402] ----------<<<<<

            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return (true);
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="saveTarget">保存マスタ (PrdExchPNU/PrdExchPPU)</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note　　　 : 拠点・倉庫の保存処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        //private bool SaveProc(string saveTarget)  // DEL 2008/06/04
        private bool SaveProc()
        {
            Control control = null;
            string message = null;

            // 不正データ入力チェック
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (saveTarget)
            {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 倉庫テーブルの場合
                case DETAILS_TABLE:
                    {
                        // 倉庫更新
                        if (!SaveWarehouse())
                        {
                            return false;
                        }
						//----- ueno ---------- start 2007.08.28
						// フレーム更新処理はここでは不要
						//int dataCnt = 0;
                        //DetailsDataSearch(ref dataCnt, 0);
						//----- ueno ---------- end   2007.08.28

                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 倉庫更新
            if (!SaveWarehouse())
            {
                return false;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return true;
        }

        /// <summary>
        /// 倉庫テーブル更新
        /// </summary>
        /// <return>更新結果status</return>
        /// <remarks>
        /// <br>Note       : Warehouseテーブルの更新を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private bool SaveWarehouse()
        {
            Control control = null;
            Warehouse warehouse = new Warehouse();
            //WarehouseWork warehouseWork = new WarehouseWork();  // DEL 2008/06/04

            // 登録レコード情報取得
            if (this._detailsIndexBuf >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
                warehouse = ((Warehouse)this._detailsTable[guid]).Clone();
            }

            // SecInfoSetクラスにデータを格納
            DispToWarehouse(ref warehouse);

            // SecInfoSetクラスをアクセスクラスに渡して登録・更新
            int status = this._warehouseAcs.Write(ref warehouse);

            // エラー処理
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet/Hash更新処理
                        DetailsToDataSet(warehouse, this._detailsIndexBuf);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // 重複処理
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._warehouseAcs);
                        // UI子画面強制終了処理
                        EnforcedEndTransaction();
                        return false;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "SaveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._warehouseAcs,				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return false;
                    }
            }

            // 新規登録時処理
            NewEntryTransaction();

            return true;
        }

        /// <summary>
        /// 倉庫 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の対象レコードをマスタから論理削除します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int LogicalDeleteWarehouse()
        {
            int status = 0;
            int dummy = 0;

            // 削除対象倉庫取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            Warehouse warehouse = ((Warehouse)this._detailsTable[guid]).Clone();

            status = this._warehouseAcs.LogicalDelete(ref warehouse);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet更新の為
                        DetailsDataSearch(ref dummy, 0);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._warehouseAcs);
                        // フレーム更新
                        DetailsDataSearch(ref dummy, 0);
                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "LogicalDeleteWarehouse",	        // 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._warehouseAcs,			        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        // フレーム更新
                        DetailsDataSearch(ref dummy, 0);
                        return status;
                    }
            }

            return status;
        }

        /// <summary>
        /// 倉庫 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の対象レコードをマスタから物理削除します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int PhysicalDeleteWarehouse()
        {
            int status = 0;
            int dummy = 0;
            Guid guid;

            // 削除対象倉庫取得
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            Warehouse warehouse = ((Warehouse)this._detailsTable[guid]).Clone();

            // 物理削除
            status = this._warehouseAcs.Delete(warehouse);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet更新の為
                        DetailsDataSearch(ref dummy, 0);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._warehouseAcs);

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "PhysicalDeleteWarehouse",		    // 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._warehouseAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        // UI子画面強制終了処理
                        EnforcedEndTransaction();

                        return status;
                    }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;
            this._detailsIndexBuf = -2;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return status;
        }

        /// <summary>
        /// 拠点 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の対象レコードを復活します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int ReviveWarehouse()
        {
            int status = 0;
            Guid guid;

            // 復活対象倉庫取得
            guid = (Guid)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[this._dataIndex][DETAILS_GUID_KEY];
            Warehouse warehouse = ((Warehouse)this._detailsTable[guid]).Clone();

            // 復活
            status = this._warehouseAcs.Revival(ref warehouse);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet展開処理
                        DetailsToDataSet(warehouse, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._warehouseAcs);
                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "ReviveWarehouse",				    // 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_RVV_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._warehouseAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
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

            return status;
        }

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                if (TargetTableName == MAIN_TABLE)
                {
                    // データインデックスを初期化する
                    this._mainDataIndex = -1;
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                
                //----- ueno ---------- start 2007.08.28
				// フレーム更新
				int dataCnt = 0;
				DetailsDataSearch(ref dataCnt, 0);
				//----- ueno ---------- end   2007.08.28

                // 画面クリア処理
                ScreenClear();
                // 画面初期設定処理
                ScreenInitialSetting();
                // 画面再構築処理
                ScreenReconstruction();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this._detailsIndexBuf = -2;
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this._mainIndexBuf = -2;
                this._targetTableBuf = "";
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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
        /// UI子画面強制終了処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void EnforcedEndTransaction()
        {
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;
            this._detailsIndexBuf = -2;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._mainIndexBuf = -2;
            this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

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
        /// 重複処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の重複処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                ERR_DPR_MSG, 	                    // 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            control = this.tEdit_WarehouseCode;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (TargetTableName)
            {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    {
                        control = this.SectionCode_tEdit;
                        break;
                    }
                // 倉庫テーブルの場合
                case DETAILS_TABLE:
                    {
                        control = this.WarehouseCode_tEdit;
                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="operation">オペレーション</param>
        /// <param name="erObject">エラーオブジェクト</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
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
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
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
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
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

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/6/4</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_WarehouseCode.Size = new System.Drawing.Size(52, 24);
            this.WarehouseCdName_tEdit.Size = new System.Drawing.Size(337, 24);
            this.tEdit_SectionCode.Size = new System.Drawing.Size(36, 24);
            this.SectionGuideNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(76, 24);
            this.CustomerName_tEdit.Size = new System.Drawing.Size(322, 24);
            this.tEdit_MainMngWarehouseCd.Size = new System.Drawing.Size(52, 24);
            this.MainMngWarehouseNm_tEdit.Size = new System.Drawing.Size(337, 24);
            this.StockBlnktRemark1_tEdit.Size = new System.Drawing.Size(44, 24);
            this.StockBlnktRemark2_tEdit.Size = new System.Drawing.Size(52, 24);
            this.WarehouseNote1_tEdit.Size = new System.Drawing.Size(639, 24);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load イベント(MAKHN09230U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void MAKHN09230UA_Load(object sender, System.EventArgs e)
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList25 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList25;
            this.Cancel_Button.ImageList = imageList25;
            this.Revive_Button.ImageList = imageList25;
            this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;    // ADD 2009/04/16

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;    // ADD 2009/04/16

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            MainMngWarehouseGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // コントロールサイズ設定
            SetControlSize();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// Form.Closing イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void MAKHN09230UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this._mainIndexBuf = -2;  // DEL 2008/06/04
            this._detailsIndexBuf = -2;
            //this._targetTableBuf = "";  // DEL 2008/06/04

            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Control.VisibleChanged イベント(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void MAKHN09230UA_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Owner.Activate();

            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                return;
            }

            // 画面クリア処理
            ScreenClear();

            // 画面初期設定処理
            ScreenInitialSetting();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;// ADD 2009/01/19 不具合対応[9896]

                // 登録処理
                //SaveProc(this._targetTableName);  // DEL 2008/06/04
                SaveProc();
            }
            finally
            {
                Cursor.Current = Cursors.Default;   // ADD 2009/01/19 不具合対応[9896]
            }
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
			bool cloneFlg = true;

			// 削除モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE)
			{
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
				switch (this._targetTableName)
                {
                    // 拠点テーブルの場合
                    case MAIN_TABLE:
					{
						break;
                    }
                    // 倉庫テーブルの場合
                    case DETAILS_TABLE:
                    {
                        // 現在の画面情報を取得
                        Warehouse warehouse = new Warehouse();
                        warehouse = this._warehouseClone.Clone();
                        DispToWarehouse(ref warehouse);
                        // 最初に取得した画面情報と比較
                        cloneFlg = this._warehouseClone.Equals(warehouse);
                        break;
                    }
				}
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // 現在の画面情報を取得
                Warehouse warehouse = new Warehouse();
                warehouse = this._warehouseClone.Clone();
                DispToWarehouse(ref warehouse);
                // 最初に取得した画面情報と比較
                cloneFlg = this._warehouseClone.Equals(warehouse);
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

				if(!(cloneFlg))
				{
					// 画面情報が変更されていた場合は、保存確認メッセージを表示する
					DialogResult res = TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						"",									// 表示するメッセージ 
						0,									// ステータス値
						MessageBoxButtons.YesNoCancel);		// 表示するボタン

					switch (res)
					{
						case DialogResult.Yes:
						{
                            //if (SaveProc(this._targetTableName))  // DEL 2008/06/04
                            if (SaveProc())
							{
								this.DialogResult = DialogResult.OK;
								break;
							}
							else
							{
								return;
							}
						}
						case DialogResult.No:
						{
							this.DialogResult = DialogResult.Cancel;
							break;
						}
						default:
						{
							// 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tEdit_WarehouseCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
							return;
						}
					}
				}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;
			this._detailsIndexBuf = -2;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			this._mainIndexBuf = -2;				   
			this._targetTableBuf = "";
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
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
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン

            if (result == DialogResult.OK)
            {
                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // 倉庫物理削除
                PhysicalDeleteWarehouse();
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                switch (this._targetTableName)
                {
                    // 拠点テーブルの場合
                    case MAIN_TABLE:
                        {
                            break;
                        }
                    // 倉庫テーブルの場合
                    case DETAILS_TABLE:
                        {
                            // 倉庫物理削除
                            PhysicalDeleteWarehouse();
                            break;
                        }
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // 拠点復活
            ReviveWarehouse();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (this._targetTableName)
            {
                // 拠点テーブルの場合
                case MAIN_TABLE:
                    {
                        break;
                    }
                // 倉庫テーブルの場合
                case DETAILS_TABLE:
                    {
                        // 拠点復活
                        ReviveWarehouse();
                        break;
                    }
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
        ///					 この処理は、システムが提供するスレッド プール
        ///					 スレッドで実行されます。</br>
        /// <br>Programmer : 22022 段上 知子</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
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

                    this.tNedit_CustomerCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click イベント(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._cusotmerGuideSelected == true)
                {
                    this.tEdit_MainMngWarehouseCd.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note　　　 : 得意先ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 得意先コード
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            // 得意先名称
            this.CustomerName_tEdit.DataText = customerSearchRet.Name.Trim();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Control.Click イベント(MainMngWarehouseGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 主管倉庫ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void MainMngWarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                Warehouse warehouse = new Warehouse();

                status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
                if (status == 0)
                {
                    this.tEdit_MainMngWarehouseCd.DataText = warehouse.WarehouseCode.Trim();
                    this.MainMngWarehouseNm_tEdit.DataText = warehouse.WarehouseName.Trim();

                    this.StockBlnktRemark1_tEdit.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_WarehouseCode":
                    {
                        // 倉庫コード
                        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_WarehouseCode;
                            }
                        }
                        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                        break;
                    }
                case "tEdit_SectionCode":
                    // 管理拠点コードにフォーカスがある場合
                    if (this.tEdit_SectionCode.DataText.Trim() == "")
                    {
                        this.SectionGuideNm_tEdit.DataText = "";
                        return;
                    }

                    // 管理拠点コード取得
                    string sectionCode = this.tEdit_SectionCode.DataText;

                    // 管理拠点名称取得
                    this.SectionGuideNm_tEdit.DataText = GetSectionName(sectionCode);

                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        if (this.SectionGuideNm_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                        }
                    }
                    break;
                case "tNedit_CustomerCode":
                    // 得意先コードにフォーカスがある場合
                    if (this.tNedit_CustomerCode.DataText.Trim() == "")
                    {
                        this.CustomerName_tEdit.DataText = "";
                        return;
                    }

                    // 得意先コード取得
                    int customerCode = this.tNedit_CustomerCode.GetInt();

                    // 得意先名称取得
                    this.CustomerName_tEdit.DataText = GetCustomerName(customerCode);

                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        //if (this.CustomerName_tEdit.DataText.Trim() != "")    // DEL 2009/06/29
                        if (CheckCustomer(customerCode))    // ADD 2009/06/29
                        {
                            e.NextCtrl = this.tEdit_MainMngWarehouseCd;
                        }
                    }
                    break;
                case "tEdit_MainMngWarehouseCd":
                    // 主管倉庫コードにフォーカスがある場合
                    if (this.tEdit_MainMngWarehouseCd.DataText.Trim() == "")
                    {
                        this.MainMngWarehouseNm_tEdit.DataText = "";
                        return;
                    }

                    // 主管倉庫コードを取得
                    string warehouseCode = this.tEdit_MainMngWarehouseCd.DataText;

                    // 主管倉庫名称を空にします
                    this.MainMngWarehouseNm_tEdit.DataText = GetWarehouseName(warehouseCode);

                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        if (this.MainMngWarehouseNm_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.StockBlnktRemark1_tEdit;
                        }
                    }
                    break;
                case "WarehouseCdName_tEdit":
                    // 倉庫名称にフォーカスがある場合
                    if (e.Key == Keys.Down)
                    {
                        // 管理拠点コードにフォーカスを移します
                        e.NextCtrl = tEdit_SectionCode;
                    }
                    break;
                case "SectionGuide_Button":
                    // 管理拠点ガイドボタンにフォーカスがある場合
                    if (e.Key == Keys.Down)
                    {
                        // 得意先コードにフォーカスを移します
                        e.NextCtrl = tNedit_CustomerCode;
                    }
                    break;
                case "WarehouseNote1_tEdit":
                    // 倉庫備考にフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 在庫一括リマーク１にフォーカスを移します
                        e.NextCtrl = StockBlnktRemark1_tEdit;
                    }
                    break;
                default:
                    break;
            }
        }

        private void tEdit_MainMngWarehouseCd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            // ADD 2009/04/16 ------>>>
            _secInfoAcs.ResetSectionInfo();
            GetCacheData();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
            // ADD 2009/04/16 ------<<<
        }
                
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 倉庫コード
            string warehouseCode = tEdit_WarehouseCode.Text.TrimEnd().PadLeft(4, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[DETAILS_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsWarehouseCode = (string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][WAREHOUSECODE_TITLE];
                if (warehouseCode.Equals(dsWarehouseCode.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[DETAILS_TABLE].Rows[i][DELETE_DATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの倉庫設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 倉庫コードのクリア
                        tEdit_WarehouseCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの倉庫設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 倉庫コードのクリア
                                tEdit_WarehouseCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        # endregion
    }
}
