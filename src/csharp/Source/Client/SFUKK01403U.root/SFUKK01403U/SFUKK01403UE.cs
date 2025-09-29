//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入金伝票検索
// プログラム概要   : 入金伝票一覧の検索を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2012/12/24  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 王君
// 修 正 日  2013/02/07  修正内容 : 2013/03/13配信分 Redmine#33741の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    public partial class SFUKK01403UE : Form
    {
        /// <summary>
        /// 入金伝票検索コントロールクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金伝票の検索を行うコントロールクラスです。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>Update Note: 2013/02/07 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br></br>
        /// </remarks>
        public SFUKK01403UE()
        {
            InitializeComponent();
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #region [Private Number]

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// 検索ボタン

        /// <summary>入金伝票入力画面(入金型)アクセスクラス</summary>
        private InputDepositNormalTypeAcs _inputDepositNormalTypeAcs;

        /// <summary>入金情報(入金伝票)取得用パラメータ</summary>
        private InputDepositNormalTypeAcs.SearchDepositParameter _searchDepositParameter;

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>得意先情報クラス</summary>
        private CustomerInfoAcs _customerInfoAcs = new CustomerInfoAcs();

        // 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        /// <summary>画面フォーカス初期設定Flag</summary>
        private bool _focusSetFlag;

        private int _status;
        /// <summary>ログイン拠点コード</summary>
        private string _sectionCode;

        /// <summary>ログイン拠点名</summary>
        private string _sectionName;
        
        // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
        /// <summary>得意先コード</summary>
        private int _custCode;

        /// <summary>得意先名</summary>
        private string _custName;

        private bool _toolSearchFlag;
        // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
        #endregion

        # region [Dispose]
        /// <summary>
        /// 入金伝票入力画面(入金型)アクセスクラス
        /// </summary>
        public InputDepositNormalTypeAcs InputDepositNormalTypeAcsUE
        {
            set { _inputDepositNormalTypeAcs = value; }
            get { return _inputDepositNormalTypeAcs; }
        }

        /// <summary>
        /// 検索条件クラス
        /// </summary>
        public InputDepositNormalTypeAcs.SearchDepositParameter SearchDepositParameter
        {
            set { _searchDepositParameter = value; }
            get { return _searchDepositParameter; }
        }

        /// <summary>
        /// 検索結果status
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            set { _sectionCode = value; }
            get { return _sectionCode; }
        }

        /// <summary>
        /// 拠点名
        /// </summary>
        public string SectionName
        {
            set { _sectionName = value; }
            get { return _sectionName; }
        }
        #endregion

        #region [Private Methord]

        /// <summary>
        /// グリッド初期設定処理
        /// </summary>
        /// <param name="uGrid">入金グリッド</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : グリッドの初期設定を行います。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void InitializeGrid(UltraGrid uGrid)
        {
            // 入金グリッド
            if (uGrid.Name == "grdDepositList")
            {
                // 行選択モードの設定
                uGrid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            }
            // 行選択設定 行選択無しモード(アクティブのみ)
            uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            uGrid.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            uGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            // 行の外観設定
            uGrid.DisplayLayout.Override.RowAppearance.BackColor = Color.White;

            // 1行おきの外観設定
            uGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // 選択行の外観設定
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            // アクティブ行の外観設定
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            // ヘッダーの外観設定
            uGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;
            uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Left;
            uGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Alpha.Transparent;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;

            // 行セレクターの外観設定
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;

            // 行フィルターの設定
            uGrid.DisplayLayout.Override.RowFilterAction = RowFilterAction.HideFilteredOutRows;

            // 垂直方向のスクロールスタイル
            uGrid.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            // 複数画面表示(スプリッター)の表示設定
            uGrid.DisplayLayout.MaxRowScrollRegions = 1;

            // スクロールバー最終行制御
            uGrid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

            // ヘッダークリックアクション設定
            uGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

            // 「固定列」プッシュピンアイコンを消す
            uGrid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
        }

        /// <summary>
        /// 入金グリッドデータビューバインド処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金グリッドにデータビューをバインドします。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void BindingDsDepositView()
        {
            // 入金グリッドにViewをバインドする
            grdDepositList.DataSource = this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable].DefaultView;
        }

        /// <summary>
        /// 入金グリッド表示設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金グリッドの表示設定を行います。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// </remarks>
        private void SettingDepositGrid()
        {
            string moneyFormat = "#,##0;-#,##0;''";
            string zeroFormat = "000000000;''";
            string moneyFormatWith0yen = "#,##0;-#,##0";
   
            // --- 入金一覧バンド --- //
            ColumnsCollection pareColumns = grdDepositList.DisplayLayout.Bands[InputDepositNormalTypeAcs.ctDepositGuidDataTable].Columns;

            // 入金番号
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].Header.Caption = "入金伝票番号";
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].Width = 120;
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].Format = zeroFormat;

            // 入金計上日(計上日付を表示する)
            pareColumns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].Header.Caption = "入金日";
            pareColumns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].Width = 120;

            //得意先コード
            pareColumns[InputDepositNormalTypeAcs.ctCustomerCode].Header.Caption = "得意先コード";
            pareColumns[InputDepositNormalTypeAcs.ctCustomerCode].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[InputDepositNormalTypeAcs.ctCustomerCode].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctCustomerCode].Width = 100;

            //得意先名称
            pareColumns[InputDepositNormalTypeAcs.ctCustomerName].Header.Caption = "得意先名称";
            pareColumns[InputDepositNormalTypeAcs.ctCustomerName].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[InputDepositNormalTypeAcs.ctCustomerName].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctCustomerName].Width = 120;

            // 共通 入金額
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].Header.Caption = "入金金額";
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].Width = 100;
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].Format = moneyFormat;
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].Format = moneyFormatWith0yen; 

            // 共通 合計
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].Header.Caption = "入金合計";
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].Width = 100;
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].Format = moneyFormat;
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].Format = moneyFormatWith0yen;

            // 締
            pareColumns[InputDepositNormalTypeAcs.ctDepositClosedFlg].Header.Caption = "締";
            pareColumns[InputDepositNormalTypeAcs.ctDepositClosedFlg].CellAppearance.TextHAlign = HAlign.Center;
            pareColumns[InputDepositNormalTypeAcs.ctDepositClosedFlg].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDepositClosedFlg].Width = 30;

            // 摘要
            pareColumns[InputDepositNormalTypeAcs.ctOutline].Header.Caption = "摘要";
            pareColumns[InputDepositNormalTypeAcs.ctOutline].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[InputDepositNormalTypeAcs.ctOutline].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctOutline].Width = 120;

            // 入金グリッドを展開する (１行もデータが無くてもタイトルを表示する為)
            grdDepositList.Rows.ExpandAll(true);
        }

        /// <summary>
        /// 入金グリッド表示列変更処理
        /// </summary>
        /// <param name="checkDetail">詳細表示 有無</param>
        /// <param name="checkAllowance">引当表示 有無</param>
        /// <remarks>
        /// <br>Note       : 入金グリッドの表示列を変更します。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// </remarks>
        private void DetailViewSettingColumun(bool checkDetail, bool checkAllowance)
        {
            // >>>>>>>>>>>>>>>>>>>> //
            // --- 入金テーブル --- //
            // >>>>>>>>>>>>>>>>>>>> //
            UltraGridBand bdDeposit = grdDepositList.DisplayLayout.Bands[InputDepositNormalTypeAcs.ctDepositGuidDataTable];

            // >>> 入金テーブル 入金内訳関連の表示制御 >>> //
            // 共通 入金額
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit].Hidden = true;
            // 共通 手数料
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctFeeDeposit].Hidden = true;
            // 共通 値引
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDiscountDeposit].Hidden = true;
            // 摘要
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctOutline].Hidden = false;
            // 入金担当者
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositInputAgentNm].Hidden = true;
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositInputEmpCd].Hidden = true;  // 発行者コード
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositInputEmpNm].Hidden = true;  // 発行者名
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctCustomerCode].Hidden = false;
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctCustomerName].Hidden = false;

            // >>> 入金テーブル 入金合計関連の表示制御 >>> //
            // 表示
            // 共通 入金計
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositTotal].Hidden = false;
            //区分
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositNm].Hidden = true;
            // 引当
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctAllowDiv].Hidden = true;
            //金種
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositKindName].Hidden = true;
            //手数料
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctFeeDeposit].Hidden = true;
            //値引
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDiscountDeposit].Hidden = true;
            // 引当額 合計
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAllowance_Deposit].Hidden = true;
            // 入力担当者
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositInputAgentNm].Hidden = true;
            //未引当額
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAlwcBlnce_Deposit].Hidden = true;
            //売上伝票番号
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctSalesSlipNum].Hidden = true;
            //締日
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositClosedFlg].Hidden = true;

            // >>> 入金テーブル 常に非表示制御 >>> //
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDebitNoteCd].Hidden = true;			    // 入金赤伝区分
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDebitNoteNm].Hidden = true;			    // 入金赤伝名称
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDebitNoteLinkDepoNo].Hidden = true;			    // 赤黒入金連結番号
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDateDisp].Hidden = true;			        // 入金日(表示用)
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDate].Hidden = true;			            // 入金日
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAddUpADate].Hidden = true;			        // 計上日付
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAcptAnOdrStatus].Hidden = true;			// 受注ステータス
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctAutoDepositCd].Hidden = true;			            // 自動入金区分
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAllowance_Deposit].Hidden = true;			// 入金引当額 共通
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctBankCode].Hidden = true;	                        // 銀行コード
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctBankName].Hidden = true;                          // 銀行名称
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftNo].Hidden = true;                           // 手形番号
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftDivide].Hidden = true;                       // 手形区分
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftDivideName].Hidden = true;                   // 手形区分名称
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftKind].Hidden = true;                         // 手形種類
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftKindName].Hidden = true;                     // 手形種類名称
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftDrawingDate].Hidden = true;			        // 手形振出日
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftDrawingDate].Hidden = true;			        // 手形振出日
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDataRow].Hidden = true;			        // 自身のDataRow
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo1].Hidden = true;			            // 入金行番号1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode1].Hidden = true;			        // 金種コード1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName1].Hidden = true;			        // 金種名称1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv1].Hidden = true;			            // 金種区分1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit1].Hidden = true;			                // 入金金額1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm1].Hidden = true;			            // 有効期限1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo2].Hidden = true;			            // 入金行番号2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode2].Hidden = true;			        // 金種コード2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName2].Hidden = true;			        // 金種名称2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv2].Hidden = true;			            // 金種区分2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit2].Hidden = true;			                // 入金金額2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm2].Hidden = true;			            // 有効期限2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo3].Hidden = true;			            // 入金行番号3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode3].Hidden = true;			        // 金種コード3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName3].Hidden = true;			        // 金種名称3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv3].Hidden = true;			            // 金種区分3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit3].Hidden = true;			                // 入金金額3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm3].Hidden = true;			            // 有効期限3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo4].Hidden = true;			            // 入金行番号3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode4].Hidden = true;			        // 金種コード4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName4].Hidden = true;			        // 金種名称4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv4].Hidden = true;			            // 金種区分4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit4].Hidden = true;			                // 入金金額4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm4].Hidden = true;			            // 有効期限4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo5].Hidden = true;			            // 入金行番号5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode5].Hidden = true;			        // 金種コード5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName5].Hidden = true;			        // 金種名称5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv5].Hidden = true;			            // 金種区分5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit5].Hidden = true;			                // 入金金額5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm5].Hidden = true;			            // 有効期限5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo6].Hidden = true;			            // 入金行番号6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode6].Hidden = true;			        // 金種コード6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName6].Hidden = true;			        // 金種名称6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv6].Hidden = true;			            // 金種区分6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit6].Hidden = true;			                // 入金金額6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm6].Hidden = true;			            // 有効期限6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo7].Hidden = true;			            // 入金行番号7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode7].Hidden = true;			        // 金種コード7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName7].Hidden = true;			        // 金種名称7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv7].Hidden = true;			            // 金種区分7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit7].Hidden = true;			                // 入金金額7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm7].Hidden = true;			            // 有効期限7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo8].Hidden = true;			            // 入金行番号8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode8].Hidden = true;			        // 金種コード8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName8].Hidden = true;			        // 金種名称8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv8].Hidden = true;			            // 金種区分8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit8].Hidden = true;			                // 入金金額8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm8].Hidden = true;			            // 有効期限8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo9].Hidden = true;			            // 入金行番号9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode9].Hidden = true;			        // 金種コード9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName9].Hidden = true;			        // 金種名称9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv9].Hidden = true;			            // 金種区分9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit9].Hidden = true;			                // 入金金額9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm9].Hidden = true;			            // 有効期限9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo10].Hidden = true;			            // 入金行番号10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode10].Hidden = true;			        // 金種コード10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName10].Hidden = true;			        // 金種名称10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv10].Hidden = true;			            // 金種区分10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit10].Hidden = true;			                // 入金金額10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm10].Hidden = true;			            // 有効期限10
        }

        /// <summary>
        /// 得意先情報取得処理
        /// </summary>
        /// <param name="customerInfo">得意先情報オブジェクト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 得意先コードから対象の得意先情報を取得します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private int GetCustomerInfo(out CustomerInfo customerInfo, int customerCode)
        {
            customerInfo = new CustomerInfo();
            int status;

            try
            {
                status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, true, out customerInfo);
            }
            catch
            {
                status = -1;
                customerInfo = null;
            }

            return (status);
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this.tEdit_SectionCodeAllowZero.Clear();
                this.uLabel_SectionName.Text = "";
                return;
            }
            else
            {
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo = new CustomerInfo();
                this.tNedit_CustomerCode.DataText = customerSearchRet.CustomerCode.ToString();
                this.uLabel_CustomerName.Text = customerSearchRet.Name + " " + customerSearchRet.Name2;
            }
        }

        #endregion

        #region [Private Event]

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込む時に発生します。</br>
        /// <br>Programmer  : 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>Update Note : 2013/02/07 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void SFUKK01403UE_Load(object sender, EventArgs e)
        {
            //ログイン拠点
            this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
            this.uLabel_SectionName.Text = this.SectionName;
            this._enterpriseCode = this._searchDepositParameter.EnterpriseCode;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionCodeGuide_ultraButton.ImageList = imageList16;
            this.SectionCodeGuide_ultraButton.Appearance.Image = Size16_Index.STAR1;
            this.CustomerGuide_uButton.ImageList = imageList16;
            this.CustomerGuide_uButton.Appearance.Image = Size16_Index.STAR1;

            this.tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Search"];
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._closeButton.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;

            if (this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable] == null)
            {
                // 入金情報 DataSet Table 作成処理
                this._inputDepositNormalTypeAcs.CreateDepositGuidDataTable();
            }
            else
            {
                this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable].Clear();
            }

            // 入金グリッドデータビューバインド処理
            this.BindingDsDepositView();
            //グリッド表示設定処理   
            SettingDepositGrid();
            //グリッド表示列変更処理      
            DetailViewSettingColumun(true, true);
            this._focusSetFlag = true;
            this._toolSearchFlag = true;// ADD 王君 2013/02/07 Redmine#33741
        }

        /// <summary>入金ガイドグリッド初期設定処理処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 入金ガイドグリッド初期設定処理処理。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            // 入金グリッド
            if (uGrid.Name == "grdDepositList")
            {
                // 入金グリッド初期設定処理処理
                this.InitializeGrid(this.grdDepositList);
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドを起動する。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void CustomerGuide_uButton_Click(object sender, EventArgs e)
        {
            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// キーコントロール イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : キーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Update Note : 2013/02/07 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (_focusSetFlag && e.NextCtrl != null)
            {
                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                this._focusSetFlag = false;
            }
            if (e.PrevCtrl == null)
            {
                return;
            }
            switch(e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero":　//拠点コード
                    {
                        //------------------------------------
                        // 拠点コード取得
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();

                        tEdit_SectionCodeAllowZero_Enter(this.tEdit_SectionCodeAllowZero, new EventArgs());
                        UiSet uiset;
                        uiSetControl1.ReadUISet(out uiset, tEdit_SectionCodeAllowZero.Name);
                        string sectionCodeZero = new string('0', uiset.Column);
                        if (sectionCode == sectionCodeZero || string.IsNullOrEmpty(sectionCode) || "0".Equals(sectionCode))
                        {
                            this.tEdit_SectionCodeAllowZero.DataText = "00";
                            this.uLabel_SectionName.Text = "全社";
                            this.SectionCode = "00";
                            this.SectionName = "全社";
                            return;
                        }
                        else if (sectionCode != this.SectionCode)
                        {
                            if (_secInfoSetAcs == null)
                            {
                                _secInfoSetAcs = new SecInfoSetAcs();
                            }
                            if (sectionCode.Length == 1)
                            {
                                sectionCode = sectionCode.PadLeft(2, '0');
                            }
                            SecInfoSet sectionInfo;
                            if (sectionCode != sectionCodeZero)
                            {
                                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL 王君 2013/02/07 Redmine#33741
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD 王君 2013/02/07 Redmine#33741
                                {
                                    // パラメータに保存
                                    this.tEdit_SectionCodeAllowZero.DataText = sectionInfo.SectionCode.TrimEnd();
                                    this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                                    this.SectionCode = sectionInfo.SectionCode.TrimEnd();
                                    this.SectionName = sectionInfo.SectionGuideNm.TrimEnd();
                                }
                                // ----- DEL 王君 2013/02/07 Redmine#33741 ----->>>>>
                                //else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                // ----- DEL 王君 2013/02/07 Redmine#33741 -----<<<<<
                                // ----- ADD 王君 2013/02/07 Redmine#33741 ----->>>>>
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF) || (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode != 0))
                                // ----- ADD 王君 2013/02/07 Redmine#33741 -----<<<<<
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する拠点が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tEdit_SectionCodeAllowZero.Clear();
                                    this.uLabel_SectionName.Text = "";
                                    // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                    this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
                                    this.uLabel_SectionName.Text = this.SectionName;
                                    this._toolSearchFlag = false;
                                    // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    return;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "拠点名の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tEdit_SectionCodeAllowZero.Clear();
                                    this.uLabel_SectionName.Text = "";
                                    // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                    this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
                                    this.uLabel_SectionName.Text = this.SectionName;
                                    this._toolSearchFlag = false;
                                    // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    return;
                                }
                                if (e.ShiftKey == false)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Right:
                                            {
                                                e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                                break;
                                            }
                                        case Keys.Enter:
                                        case Keys.Tab:
                                            {
                                                if (status == 0)
                                                {
                                                    e.NextCtrl = this.tNedit_CustomerCode;
                                                    break;
                                                }
                                                else
                                                {
                                                    this.tEdit_SectionCodeAllowZero.Clear();
                                                    this.SectionCodeGuide_ultraButton.Text = "";
                                                    //SectionCodeGuide_ultraButton_Click(this.SectionCodeGuide_ultraButton, new EventArgs());  // DEL 王君 2013/02/07 Redmine#33741
                                                    break;
                                                }
                                            }
                                        case Keys.Down:
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                                break;
                                            }
                                    }
                                }
                                // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                else
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Enter:
                                        case Keys.Tab:
                                            {
                                                if (this.grdDepositList.Rows.Count > 0)
                                                {
                                                    this.grdDepositList.Focus();
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.CustomerGuide_uButton;
                                                }
                                                break;
                                            }
                                    }
                                }
                                // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                            }
                        }
                        else
                        {
                            // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                            if (e.ShiftKey == true)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Enter:
                                    case Keys.Tab:
                                        {
                                            if (this.grdDepositList.Rows.Count > 0)
                                            {
                                                this.grdDepositList.Focus();
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.CustomerGuide_uButton;
                                            }
                                            break;
                                        }
                                }
                            }
                            // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                        }
                        break;
                    }
                case "tNedit_CustomerCode": // 得意先コード
                    {
                        int code = this.tNedit_CustomerCode.GetInt();
                        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (code != 0)
                        {
                            CustomerInfo customerInfo;
                            int customerCode = this.tNedit_CustomerCode.GetInt();
                            //--------------------------------------------------------------------
                            // 得意先コードから得意先マスタを取得し、請求先コードと比較
                            // 得意先コードと請求先コードに差異がある場合は請求先コードで再検索
                            //--------------------------------------------------------------------
                            status = GetCustomerInfo(out customerInfo, customerCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.tNedit_CustomerCode.DataText = customerInfo.CustomerCode.ToString();
                                this.uLabel_CustomerName.Text = customerInfo.CustomerSnm;
                                // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                this._custCode = customerInfo.CustomerCode;
                                this._custName = customerInfo.CustomerSnm;
                                // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                if (this.tNedit_CustomerCode.GetInt() != 0)
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する得意先が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);
                                // ---- DEL 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                //this.tNedit_CustomerCode.Clear();
                                //this.uLabel_CustomerName.Text = "";
                                // ---- DEL 王君 2013/02/07 Redmine#33741 ----- <<<<<
                                // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                                this.tNedit_CustomerCode.DataText = this._custCode.ToString();
                                this.uLabel_CustomerName.Text = this._custName;
                                this._toolSearchFlag = false;
                                // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                                //e.NextCtrl = this.tNedit_CustomerCode; // DEL 王君 2013/02/07 Redmine#33741
                                e.NextCtrl = this.CustomerGuide_uButton; // ADD 王君 2013/02/07 Redmine#33741
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            this.uLabel_CustomerName.Text = "";
                        }
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                case Keys.Right:
                                    {
                                        if (status == 0)
                                        {
                                            e.NextCtrl = this.grdDepositList;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.CustomerGuide_uButton;
                                        }
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        if (status == 0)
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        // --- DEL 王君 2013/02/07 Redmine#33741 ---- >>>>>
                                        //if (status == 0)
                                        //{
                                        // --- DEL 王君 2013/02/07 Redmine#33741 ---- >>>>>
                                        if (this.grdDepositList.Rows.Count > 0)
                                        {
                                            e.NextCtrl = this.grdDepositList;
                                        }
                                        // --- DEL 王君 2013/02/07 Redmine#33741 ---- >>>>>
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        // --- ADD 王君 2013/02/07 Redmine#33741 ---- <<<<<
                                        /* --- DEL 王君 2013/02/07 Redmine#33741 ---- >>>>>
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                       // --- DEL 王君 2013/02/07 Redmine#33741 ---- >>>>>*/
                                        break;
                                    } 
                            }
                        }
                        // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                        break;
                    }
                case "SectionCodeGuide_ultraButton":　　//拠点ガイド
                    {
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                                case Keys.Left:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.CustomerGuide_uButton;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                        break;
                    }
                case "CustomerGuide_uButton":　　// 得意先ガイド
                    {
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Left:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.CustomerGuide_uButton;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                        break;
                    }
                case "grdDepositList":
                    {
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                    {
                                        if (this.grdDepositList.Rows.Count > 0 && this.grdDepositList.ActiveRow != null)
                                        {
                                            grdDepositList_DoubleClickRow(this.grdDepositList, new DoubleClickRowEventArgs(this.grdDepositList.ActiveRow, RowArea.CellArea));
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// DoubleClickRow イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　  : キーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void grdDepositList_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            int guidRowIndex = e.Row.Index;
            string slipNo = this.grdDepositList.Rows[guidRowIndex].Cells[InputDepositNormalTypeAcs.ctDepositSlipNo].Value.ToString();
            DataTable dt = this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable];
            DataRow dr = this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable].NewRow();
            DataRow[] drLike = dt.Select("DepositSlipNo = " + slipNo);
            if (drLike.Length > 0)
            {
                dr = drLike[0];
            }
            CustomerInfo customerInfo;
            //伝票の得意先コード
            int customerCode = Convert.ToInt32(dr[InputDepositNormalTypeAcs.ctCustomerCode].ToString());
            //得意先情報取得処理
            int statusCt = GetCustomerInfo(out customerInfo, customerCode);
            if (statusCt == 0)
            {
                // 納入先入力チェック
                if (customerInfo.IsCustomer != true)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "納入先は入力できません。",
                        -1,
                        MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    int claimCode = customerInfo.ClaimCode;
                    CustomerInfo claimInfo;
                    statusCt = GetCustomerInfo(out claimInfo, claimCode);
                    if (claimInfo.IsCustomer != true)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "納入先は入力できません。",
                        -1,
                        MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            else
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "得意先は存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                return;
            }
            this._inputDepositNormalTypeAcs.ClearDsDepositInfoUE();

            this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositDataTable].ImportRow(dr);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// ToolBarのclick・イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note　　　  : ToolBarのclick・イベント。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// <br>Update Note : 2013/02/07 王君</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // ----- ADD 王君 2013/02/07 Redmine#33741 ----->>>>>
                        this._toolSearchFlag = true;
                        if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero, null));
                        }
                        if (this.tNedit_CustomerCode.Focused)
                        {
                            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_CustomerCode, null));
                        }
                        // ----- ADD 王君 2013/02/07 Redmine#33741 -----<<<<<
                        string message;
                        /* ----- DEL 王君 2013/02/07 Redmine#33741 ----->>>>>
                        if (!"00".Equals(this.tEdit_SectionCodeAllowZero.DataText.TrimEnd()))
                        {
                            this._searchDepositParameter.AddUpSecCode = this.tEdit_SectionCodeAllowZero.DataText.TrimEnd();
                        }
                        else
                        {
                            this._searchDepositParameter.AddUpSecCode = "";
                        }
                        // ----- DEL 王君 2013/02/07 Redmine#33741 -----<<<<< */
                        // ----- ADD 王君 2013/02/07 Redmine#33741 ----- >>>>>
                        if ("00".Equals(this.SectionCode))
                        {
                            this._searchDepositParameter.AddUpSecCode = "";
                        }
                        else
                        {
                            this._searchDepositParameter.AddUpSecCode = this.SectionCode;
                        }
                        if (!this._toolSearchFlag)
                        {
                            return;
                        }
                        // ----- ADD 王君 2013/02/07 Redmine#33741 ----- <<<<<
                        this._searchDepositParameter.CustomerCode = this.tNedit_CustomerCode.GetInt();
                        this._status = _inputDepositNormalTypeAcs.SearchDepositGuidOnlyMode(this._searchDepositParameter, out message);
                        switch (this._status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    this.grdDepositList.Rows[0].Activate();// ADD 王君 2013/02/07 Redmine#33741
                                    this.grdDepositList.Focus();
                                    break;
                                }
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                {
                                    // 入金伝票が存在しなかった時
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                  this.Name,
                                                  message,
                                                  0,
                                                  MessageBoxButtons.OK);
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                                  this.Name,
                                                  "入金伝票の読込処理に失敗しました。" + "\r\n\r\n" + message,
                                                  this._status,
                                                  MessageBoxButtons.OK);
                                    return;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 拠点ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.DataText = sectionInfo.SectionCode.TrimEnd();
                this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
            }
            else
            {
                //前回拠点
                this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
                this.uLabel_SectionName.Text = this.SectionName;
            }
        }

        /// <summary>
        /// 拠点コードEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : 拠点コードEnterイベント。</br>
        /// <br>Programmer : 王君</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33741の対応</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Enter(object sender, EventArgs e)
        {
            // ゼロ詰め解除
            this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", this.tEdit_SectionCodeAllowZero.Text);
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note　　　  : Guidにキーが押された時に発生します。 </br>
        /// <br>Programmer  : 王君</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33741の対応</br>
        /// </remarks>
        private void grdDepositList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.grdDepositList.Rows.Count > 0 && this.grdDepositList.ActiveRow != null)
                        {
                            if (this.grdDepositList.Rows[0].Activated)
                            {
                                this.tNedit_CustomerCode.Focus();
                            }
                        }
                        break;
                    }
            }
        }
        #endregion
    }
}