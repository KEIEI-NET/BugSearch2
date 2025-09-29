using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12918]：スペースキーでの項目選択機能を実装
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上推移表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上推移表UIフォームクラス</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br>Update Note: 2008.10.16 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>UpdateNote  : 2008/10/30 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2008/10/31 30462 行澤仁美　バグ修正</br>
    /// <br>Update Note: 2008.12.09  30452 上野 俊治</br>
    /// <br>            ・改頁不可の項目を選択できないよう修正(障害8962,8963)</br>
    /// <br>            ・エラーメッセージの修正(障害8959)</br>
    /// <br>            ・担当者コードに入力が無い場合の抽出条件を修正(障害8968)</br>
    /// <br>Update Note: 2008.12.17  30452 上野 俊治</br>
    /// <br>            ・印刷タイプ「数量」選択時は金額単位が選択不可になるよう修正(障害8942)</br>
    /// <br>Update Note: 2009.02.10 30452 上野 俊治</br>
    /// <br>            ・障害対応11314</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12186]</br>
    /// <br>Update Note: 2009/04/15 張莉莉</br>
    /// <br>            ・売上推移表（仕入先別）の追加</br>
    /// <br>Update Note: 2011/08/16 王飛３</br>
    /// <br>            ・連番905の障害確認　抽出条件のコード入力しても、右側に対象項目名が出てこない（現場では帳票発行ミスが多発している）</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/30 王飛３</br>
    /// <br>            ・障害報告 #24164　名称のフォント色が全て黒（Black）で統一。</br>
    /// <br>            ・本体ソス改修なし</br>
    /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
    /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
    /// <br>Update Note: 2014/12/16 劉超</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           :・明治産業様Seiken品番変更</br>
    /// <br>Update Note: 2015/03/27 時シン</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : Redmine#44209の#423品番集計区分の名称変更</br>
    /// <br>Update Note: 2015/04/22 時シン</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : Redmine#45436の#80 明細単位：品番或いはメーカーの時、「メーカー別印刷」を操作不可とする対応</br>
    /// </remarks>
    public partial class DCTOK02130UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer 		// 帳票業務（条件入力）PDF出力履歴管理
                                //IPrintConditionInpTypeChart
    {
        #region ■ Constructor
        /// <summary>
        /// 売上推移表UIフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上推移表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.21</br>
        /// <br></br>
        /// </remarks>
        public DCTOK02130UA ()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点用のHashtable作成
            this._selectedSectionList = new Hashtable();

            // --- DEL 2008/10/16 -------------------------------->>>>>
            // 表示可変項目は最初は非表示にしておく
            //this.pn_CustomerCndtn.Visible = false;
            //this.pn_EmployeeCndtn.Visible = false;
            //this.pn_GoodsInfoCndtn.Visible = false;
            //this.pn_GoodsNoCndtn.Visible = false;
            //this.clb_SumPrintDiv.Visible = false;
            //this.uos_NewPageDiv.Visible = false;

            //// 計印字区分の選択値名称を設定（取り得る全件）
            //this._sumPrintCheckDic = new Dictionary<int, string>();
            //this._sumPrintCheckDic.Add( (int)SumPrintItem.BLGoodsCode, "ＢＬ商品コード" );
            //this._sumPrintCheckDic.Add( (int)SumPrintItem.EnterpriseGanreCode, "自社分類" );
            //this._sumPrintCheckDic.Add( (int)SumPrintItem.DGoodsGanre, "商品区分詳細" );
            //this._sumPrintCheckDic.Add( (int)SumPrintItem.MGoodsGanre, "商品区分" );
            //this._sumPrintCheckDic.Add( (int)SumPrintItem.LGoodsGanre, "商品区分グループ" );
            //this._sumPrintCheckDic.Add( (int)SumPrintItem.Maker, "メーカー" );
            //this._sumPrintCheckDic.Add( (int)SumPrintItem.Employee, "担当者" );
            //this._sumPrintCheckDic.Add( (int)SumPrintItem.Customer, "得意先" );
            //// リストは生成して空のまま
            //this._sumPrintCheckDicKeyList = new List<int>();
            // --- DEL 2008/10/16 --------------------------------<<<<<

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl(); // ADD 2008/10/16
        }
        #endregion ■ Constructor

        #region ■ Private Member
        #region ◆ Interface member
        //--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract = false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf = true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint = true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton = false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton = true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton = true;

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd = false;
        // 拠点オプション有無
        private bool _isOptSection = false;
        // 本社機能有無
        private bool _isMainOfficeFunc = false;
        // 選択拠点リスト
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion ◆ Interface member

        #region ■ Privete Enum
        // --- DEL 2008/10/08 -------------------------------->>>>>
        ///// <summary>
        ///// 小計印字チェックアイテム
        ///// </summary>
        //private enum SumPrintItem
        //{
        //    /// <summary>ＢＬコード</summary>
        //    BLGoodsCode = 0,
        //    /// <summary>自社分類</summary>
        //    EnterpriseGanreCode = 1,
        //    /// <summary>商品区分詳細</summary>
        //    DGoodsGanre = 2,
        //    /// <summary>商品区分</summary>
        //    MGoodsGanre = 3,
        //    /// <summary>商品区分グループ</summary>
        //    LGoodsGanre = 4,
        //    /// <summary>メーカー</summary>
        //    Maker = 5,
        //    /// <summary>担当者</summary>
        //    Employee = 6,
        //    /// <summary>得意先</summary>
        //    Customer = 7,
        //}
        // --- DEL 2008/10/08 --------------------------------<<<<<
        #endregion

        // 企業コード
        private string _enterpriseCode = "";
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // 抽出条件クラス
        private SalesTransListCndtn _salesTransListCndtn;

        //// 拠点ガイド用
        //SecInfoSetAcs _secInfoSetAcs;

        //// 倉庫ガイド用
        //WarehouseAcs _wareHouseAcs;

        // 仕入先ガイド
        private SupplierAcs _supplierAcs;  // ADD 2009/04/15

        // 得意先ガイド用
        private UltraButton _customerGuideSender;
        //private SFTOK01370UA _customerGuid; // DEL 2008/10/16

        //// 商品コード用
        //private MAKHN04110UA _goodsGuid = new MAKHN04110UA(); // DEL 2008/10/16
        //private GoodsAcs _goodsAcs; // DEL 2008/10/16

        // 担当者ガイド用
        private EmployeeAcs _employeeAcs;

        // メーカーガイド
        private MakerAcs _makerAcs; // ADD 2008/10/16

        // ユーザマスタガイド（商品大分類用）
        private UserGuideAcs _userGuideAcs; // ADD 2008/10/16

        // 商品中分類ガイド
        private GoodsGroupUAcs _goodsGroupUAcs; // ADD 2008/10/16

        // グループコードガイド
        private BLGroupUAcs _blGroupUAcs; // ADD 2008/10/16

        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs; // ADD 2008/10/16

        // 在庫検索(自社分類ガイド用)
        //SearchStockAcs _searchStockAcs; // DEL 2008/10/16

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        // 改ページ区分制御用
        //private Dictionary<int, string> _sumPrintCheckDic;    // 計印字区分　選択名称 // DEL 2008/10/16
        //private List<int> _sumPrintCheckDicKeyList;           // 計印字区分　選択keyリスト // DEL 2008/10/16

        // ガイド後次項目ディクショナリ
        //private Dictionary<Control, Control> _nextControl; // DEL 2008/10/16

        // 得意先ガイド結果OK
        private bool _customerGuideOK;

        // ----- ADD 2011/08/16 ---------->>>>>
        private List<CustomerInfo> _retlist1;
        private ArrayList _retlist2;
        private ArrayList _retlist3;
        private ArrayList _retlist4;
        private ArrayList _retlist5;
        private ArrayList _retlist6;
        private ArrayList _retlist7;
        private ArrayList _retlist8;
        private ArrayList _retlist9;
        // ----- ADD 2011/08/16 ----------<<<<<


        // ADD 2009/03/31 不具合対応[12918]～[12920]：スペースキーでの項目選択機能を実装 ---------->>>>>
        #region ラジオボタンのスペースキー制御

        /// <summary>集計方法ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _groupBySectionDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 集計方法ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>集計方法ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper GroupBySectionDivRadioKeyPressHelper
        {
            get { return _groupBySectionDivRadioKeyPressHelper; }
        }

        /// <summary>印刷タイプラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _printTypeDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 印刷タイプラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>印刷タイプラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper PrintTypeDivRadioKeyPressHelper
        {
            get { return _printTypeDivRadioKeyPressHelper; }
        }

        /// <summary>金額単位ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _priceUnitDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 金額単位ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>金額単位ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper PriceUnitDivRadioKeyPressHelper
        {
            get { return _priceUnitDivRadioKeyPressHelper; }
        }

        /// <summary>在庫取寄指定ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _stockOrderDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 在庫取寄指定ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>在庫取寄指定ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper StockOrderDivRadioKeyPressHelper
        {
            get { return _stockOrderDivRadioKeyPressHelper; }
        }

        /// <summary>メーカー別印刷ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _makerPrintDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// メーカー別印刷ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>メーカー別印刷ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper MakerPrintDivRadioKeyPressHelper
        {
            get { return _makerPrintDivRadioKeyPressHelper; }
        }

        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _newPageDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper NewPageDivRadioKeyPressHelper
        {
            get { return _newPageDivRadioKeyPressHelper; }
        }

        #endregion  // ラジオボタンのスペースキー制御
        // ADD 2009/03/31 不具合対応[12918]～[12920]：スペースキーでの項目選択機能を実装 ----------<<<<<

        #endregion ■ Private Member

        #region ■ Private Const
        #region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
        // クラスID
        private const string ct_ClassID = "DCTOK02130UA";
        // プログラムID
        private const string ct_PGID = "DCTOK02130U";
        //// 帳票名称
        private string _printName = "売上推移表";
        // 帳票キー	
        private string _printKey = "acec2613-c476-422d-a78e-6bdc6491aaa8";
        #endregion ◆ Interface member

        // ExporerBar グループ名称
        private const string ct_ExBarGroupNm_SelectListGroup = "SelectListGroup";              // 出力条件
        private const string ct_ExBarGroupNm_ReportSortGroup = "ReportSortGroup";		        // ソート順
        private const string ct_ExBarGroupNm_ExtractConditionGroup = "ExtractConditionGroup";	// 抽出条件
        #endregion

        #region ■ IPrintConditionInpType メンバ
        #region ◆ Public Event
        /// <summary> 親ツールバー設定イベント </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion ◆ Public Event

        #region ◆ Public Property
        /// <summary> 抽出ボタン状態取得プロパティ </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF出力ボタン状態取得プロパティ </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> 印刷ボタン状態取得プロパティ </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> 抽出ボタン表示有無プロパティ </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF出力ボタン表示有無プロパティ </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> 印刷ボタン表示プロパティ </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>0( 固定 )</returns>
        public int Extract ( ref object parameter )
        {
            // 抽出処理は無いので処理終了
            return 0;
        }
        #endregion

        #region ◎ 印刷処理
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="parameter">パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷処理を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        public int Print ( ref object parameter )
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// 印刷情報パラメータ

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // 選択可能な帳票のリストは起動時のパラメータで制御
            printInfo.PrintPaperSetCd = (int)this._salesTransListCndtn.TotalType;


            // 画面→抽出条件クラス
            int status = this.SetExtraInfoFromScreen();
            if ( status != 0 )
            {
                return -1;
            }

            // 抽出条件の設定
            printInfo.jyoken = this._salesTransListCndtn;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if ( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN )
            {
                MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0 );
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region ◎ 印刷前確認処理
        /// <summary>
        /// 印刷前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        public bool PrintBeforeCheck ()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if ( !this.ScreenInputCheck( ref errMessage, ref errComponent ) )
            {
                // メッセージを表示
                this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

                // コントロールにフォーカスをセット
                if ( errComponent != null )
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion

        #region ◎ 画面表示処理
        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <param name="parameter">起動パラメータ</param>
        /// <remarks>
        /// <br>Note		: 画面表示を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        public void Show ( object parameter )
        {

            this._salesTransListCndtn = new SalesTransListCndtn();

            // 抽出条件に起動パラメータをセット
            if ( parameter.ToString().CompareTo( "1" ) == 0 )
            {
                // 1:得意先別
                this._salesTransListCndtn.TotalType = SalesTransListCndtn.TotalTypeState.EachCustomer;
                //this._printKey = "4aed0d04-c345-4fe8-b262-04ae7de12a98"; // DEL 2008/10/16

                // UI設定保存コンポーネント設定
                this.uiMemInput1.OptionCode = "1"; // ADD 2008/10/16
            }
            else if ( parameter.ToString().CompareTo( "2" ) == 0 )
            {
                // 2:担当者別
                this._salesTransListCndtn.TotalType = SalesTransListCndtn.TotalTypeState.EachEmployee;
                //this._printKey = "d165d95e-177c-4fc7-a26e-88c1f8b2baeb"; // DEL 2008/10/16

                // UI設定保存コンポーネント設定
                this.uiMemInput1.OptionCode = "2"; // ADD 2008/10/16
            }
            // --- ADD 2009/04/15 -------------------------------->>>>>
            else if (parameter.ToString().CompareTo("3") == 0)
            {
                // 4:仕入先別
                this._salesTransListCndtn.TotalType = SalesTransListCndtn.TotalTypeState.EachSupplier;

                // UI設定保存コンポーネント設定
                this.uiMemInput1.OptionCode = "3"; // ADD 2009/04/08
            }
            // --- ADD 2009/04/15 -------------------------------->>>>>
            else
            {
                // 0:商品別
                this._salesTransListCndtn.TotalType = SalesTransListCndtn.TotalTypeState.EachGoods;
                //this._printKey = "3563006b-22ad-424d-9e90-bb17ff54b380"; // DEL 2008/10/16

                // UI設定保存コンポーネント設定
                this.uiMemInput1.OptionCode = "0"; // ADD 2008/10/16
            }

            this.Show();

            return;
        }
        #endregion

        #region ◎ 改行ValueList取得
        /// <summary>
        /// 改行ValueList取得
        /// </summary>
        /// <returns></returns>
        private Infragistics.Win.ValueList GetNewPageDivValueList()
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

            switch (this._salesTransListCndtn.TotalType)
            {
                case SalesTransListCndtn.TotalTypeState.EachGoods: // 商品別
                    {
                        if ((int)this.uos_GroupBySectionDiv.CheckedItem.DataValue != 0 // 集計方法「全社」でない // ADD 2008/12/09
                            && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 6) // 明細単位「拠点」でない // ADD 2008/12/09
                        {
                            valueListItem = new Infragistics.Win.ValueListItem();
                            valueListItem.Tag = 0;
                            valueListItem.DataValue = 0;
                            valueListItem.DisplayText = "拠点";
                            valueList.ValueListItems.Add(valueListItem);
                        }

                        if ((int)this.tComboEditor_Detail.SelectedItem.DataValue != 5
                            && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 6)// 明細単位「拠点」「メーカー」でない // ADD 2008/12/09
                        {
                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 1;
                        valueListItem.DataValue = 1;
                        valueListItem.DisplayText = "メーカー";
                        valueList.ValueListItems.Add(valueListItem);
                        }

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 4;
                        valueListItem.DataValue = 4;
                        valueListItem.DisplayText = "しない";
                        valueList.ValueListItems.Add(valueListItem);

                        break;
                    }
                case SalesTransListCndtn.TotalTypeState.EachCustomer: // 得意先別
                    {
                        if ((int)this.uos_GroupBySectionDiv.CheckedItem.DataValue != 0 // 集計方法「全社」でない // ADD 2008/12/09
                            && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 6) // 明細単位「拠点」でない // ADD 2008/12/09
                        {
                            valueListItem = new Infragistics.Win.ValueListItem();
                            valueListItem.Tag = 0;
                            valueListItem.DataValue = 0;
                            valueListItem.DisplayText = "拠点";
                            valueList.ValueListItems.Add(valueListItem);
                        }

                        if ((int)this.tComboEditor_Detail.SelectedItem.DataValue != 6
                            && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 7)// 明細単位「拠点」「得意先」でない // ADD 2008/12/09
                        {
                            valueListItem = new Infragistics.Win.ValueListItem();
                            valueListItem.Tag = 2;
                            valueListItem.DataValue = 2;
                            valueListItem.DisplayText = "得意先";
                            valueList.ValueListItems.Add(valueListItem);
                        }

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 4;
                        valueListItem.DataValue = 4;
                        valueListItem.DisplayText = "しない";
                        valueList.ValueListItems.Add(valueListItem);

                        break;
                    }
                // --- ADD 2009/04/15 ------------------------------>>>>>
                case SalesTransListCndtn.TotalTypeState.EachSupplier: // 仕入先別
                    {
                        if ((int)this.uos_GroupBySectionDiv.CheckedItem.DataValue != 0 // 集計方法「全社」でない
                            && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 6) // 明細単位「拠点」でない
                        {
                            valueListItem = new Infragistics.Win.ValueListItem();
                            valueListItem.Tag = 0;
                            valueListItem.DataValue = 0;
                            valueListItem.DisplayText = "拠点";
                            valueList.ValueListItems.Add(valueListItem);
                        }

                        if ((int)this.tComboEditor_Detail.SelectedItem.DataValue != 6
                            && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 9)// 明細単位「拠点」「仕入先」でない
                        {
                            valueListItem = new Infragistics.Win.ValueListItem();
                            valueListItem.Tag = 5;
                            valueListItem.DataValue = 5;
                            valueListItem.DisplayText = "仕入先";
                            valueList.ValueListItems.Add(valueListItem);
                        }

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 4;
                        valueListItem.DataValue = 4;
                        valueListItem.DisplayText = "しない";
                        valueList.ValueListItems.Add(valueListItem);

                        break;
                    }
                // --- ADD 2009/04/15 ------------------------------<<<<<
                case SalesTransListCndtn.TotalTypeState.EachEmployee: // 担当者別
                    {
                        if ((int)this.uos_GroupBySectionDiv.CheckedItem.DataValue != 0 // 集計方法「全社」でない // ADD 2008/12/09
                            && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 6) // 明細単位「拠点」でない // ADD 2008/12/09
                        {
                            valueListItem = new Infragistics.Win.ValueListItem();
                            valueListItem.Tag = 0;
                            valueListItem.DataValue = 0;
                            valueListItem.DisplayText = "拠点";
                            valueList.ValueListItems.Add(valueListItem);
                        }

                        if ((int)this.tComboEditor_Detail.SelectedItem.DataValue != 6
                            && (int)this.tComboEditor_Detail.SelectedItem.DataValue != 8)// 明細単位「拠点」「担当者」でない // ADD 2008/12/09
                        {
                            valueListItem = new Infragistics.Win.ValueListItem();
                            valueListItem.Tag = 3;
                            valueListItem.DataValue = 3;
                            valueListItem.DisplayText = "担当者";
                            valueList.ValueListItems.Add(valueListItem);
                        }

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 4;
                        valueListItem.DataValue = 4;
                        valueListItem.DisplayText = "しない";
                        valueList.ValueListItems.Add(valueListItem);

                        break;
                    }
            }
            return valueList;
        }
        #endregion

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        #region ◎ 品番集計区分ValueList取得
        /// <summary>
        /// 品番集計区分valueList取得
        /// </summary>
        /// <returns></returns>
        private Infragistics.Win.ValueList GetGoodsNoTtlDivValueList()
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

            valueListItem.Tag = 0;
            valueListItem.DataValue = 0;
            //valueListItem.DisplayText = "別々";// DEL 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
            valueListItem.DisplayText = "通常";// ADD 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 1;
            valueListItem.DataValue = 1;
            valueListItem.DisplayText = "合算";
            valueList.ValueListItems.Add(valueListItem);

            return valueList;
        }
        #endregion

        #region ◎ 品番表示区分ValueList取得
        /// <summary>
        /// 品番表示区分valueList取得
        /// </summary>
        /// <returns></returns>
        private Infragistics.Win.ValueList GetGoodsNoShowDivValueList()
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

            valueListItem.Tag = 0;
            valueListItem.DataValue = 0;
            valueListItem.DisplayText = "新品番";
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 1;
            valueListItem.DataValue = 1;
            valueListItem.DisplayText = "旧品番";
            valueList.ValueListItems.Add(valueListItem);

            return valueList;
        }
        #endregion
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        #region ◎ 明細単位ValueList取得
        /// <summary>
        /// 明細単位valueList取得
        /// </summary>
        /// <returns></returns>
        private Infragistics.Win.ValueList GetDetailValueList()
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

            valueListItem.Tag = 0;
            valueListItem.DataValue = 0;
            valueListItem.DisplayText = "品番";
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 1;
            valueListItem.DataValue = 1;
            valueListItem.DisplayText = "ＢＬコード";
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 2;
            valueListItem.DataValue = 2;
            valueListItem.DisplayText = "グループコード";
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 3;
            valueListItem.DataValue = 3;
            valueListItem.DisplayText = "商品中分類";
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 4;
            valueListItem.DataValue = 4;
            valueListItem.DisplayText = "商品大分類";
            valueList.ValueListItems.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 5;
            valueListItem.DataValue = 5;
            valueListItem.DisplayText = "メーカー";
            valueList.ValueListItems.Add(valueListItem);

            switch (this._salesTransListCndtn.TotalType)
            {
                case SalesTransListCndtn.TotalTypeState.EachGoods:
                    {
                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 6;
                        valueListItem.DataValue = 6;
                        valueListItem.DisplayText = "拠点";
                        valueList.ValueListItems.Add(valueListItem);
                        break;
                    }
                case SalesTransListCndtn.TotalTypeState.EachCustomer:
                    {
                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 7;
                        valueListItem.DataValue = 7;
                        valueListItem.DisplayText = "得意先";
                        valueList.ValueListItems.Add(valueListItem);

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 6;
                        valueListItem.DataValue = 6;
                        valueListItem.DisplayText = "拠点";
                        valueList.ValueListItems.Add(valueListItem);
                        break;
                    }
                case SalesTransListCndtn.TotalTypeState.EachEmployee:
                    {
                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 8;
                        valueListItem.DataValue = 8;
                        valueListItem.DisplayText = "担当者";
                        valueList.ValueListItems.Add(valueListItem);

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 6;
                        valueListItem.DataValue = 6;
                        valueListItem.DisplayText = "拠点";
                        valueList.ValueListItems.Add(valueListItem);
                        break;
                    }
                // --- ADD 2009/04/15 ------------------------------->>>>>
                case SalesTransListCndtn.TotalTypeState.EachSupplier:
                    {
                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 9;
                        valueListItem.DataValue = 9;
                        valueListItem.DisplayText = "仕入先";
                        valueList.ValueListItems.Add(valueListItem);

                        valueListItem = new Infragistics.Win.ValueListItem();
                        valueListItem.Tag = 6;
                        valueListItem.DataValue = 6;
                        valueListItem.DisplayText = "拠点";
                        valueList.ValueListItems.Add(valueListItem);
                        break; 
                    }
                // --- ADD 2009/04/15 ------------------------------<<<<<
            }

            return valueList;
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpType メンバ

        #region ■ IPrintConditionInpTypeSelectedSection メンバ
        #region ◆ Public Property

        /// <summary> 本社機能プロパティ </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary> 拠点オプションプロパティ </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> 計上拠点選択表示取得プロパティ </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion ◆ Public Property

        #region ◆ Public Method

        #region ◎ 拠点選択処理
        /// <summary>
        /// 拠点選択処理
        /// </summary>
        /// <param name="sectionCode">選択拠点コード</param>
        /// <param name="checkState">選択状態</param>
        /// <remarks>
        /// <br>Note		: 拠点選択処理を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        public void CheckedSection ( string sectionCode, CheckState checkState )
        {
            // 拠点を選択した時
            if ( checkState == CheckState.Checked )
            {
                // 全社が選択された場合
                if ( sectionCode == "0" )
                {
                    this._selectedSectionList.Clear();

                }

                if ( !this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Add( sectionCode, sectionCode );
                }

            }
            // 拠点選択を解除した時
            else if ( checkState == CheckState.Unchecked )
            {
                if ( this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Remove( sectionCode );
                }
            }
        }
        #endregion

        #region ◎ 初期選択計上拠点設定処理( 未実装 )
        /// <summary>
        /// 初期選択計上拠点設定処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        public void InitSelectAddUpCd ( int addUpCd )
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #region ◎ 初期選択拠点設定処理
        /// <summary>
        /// 初期選択拠点設定処理
        /// </summary>
        /// <param name="sectionCodeLst">選択拠点コードリスト</param>
        /// <remarks>
        /// <br>Note		: 拠点リストの初期化を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        public void InitSelectSection ( string[] sectionCodeLst )
        {
            // 選択リスト初期化
            this._selectedSectionList.Clear();
            foreach ( string wk in sectionCodeLst )
            {
                this._selectedSectionList.Add( wk, wk );
            }
        }
        #endregion

        #region ◎ 初期拠点選択表示チェック処理
        /// <summary>
        /// 初期拠点選択表示チェック処理
        /// </summary>
        /// <param name="isDefaultState">true：スライダー表示　false：スライダー非表示</param>
        /// <remarks>
        /// <br>Note		: 拠点選択スライダーの表示有無を判定する。</br>
        /// <br>			: 拠点オプション、本社機能以外の個別の表示有無判定を行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        public bool InitVisibleCheckSection ( bool isDefaultState )
        {
            return isDefaultState;
        }
        #endregion

        #region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        public void SelectedAddUpCd ( int addUpCd )
        {
            // 計上拠点選択がないので未実装
        }
        #endregion

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypeSelectedSection メンバ

        #region ■ IPrintConditionInpTypePdfCareer メンバ
        #region ◆ Public Property

        /// <summary> 帳票キープロパティ </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> 帳票名プロパティ </summary>
        public string PrintName
        {
            get { return this._printName; }
        }

        #endregion ◆ Public Method
        #endregion ■ IPrintConditionInpTypePdfCareer メンバ

        #region ■ Private Method
        #region ◆ 画面初期化関係
        #region ◎ 画面初期化処理
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力項目の初期化を行う</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
		/// ----------------------------------------------------------------------------------------
		/// <br>UpdateNote	: 「出荷数指定」の初期値を「1～999999999」から「初期値なし」に変更</br>
		/// <br>Programmer	: 30191 馬淵 愛</br>
		/// <br>Date		: 2008.04.07</br>
        /// <br>Update Note : 2014/12/16 劉超</br>
        /// <br>管理番号    : 11070263-00</br>
        /// <br>            : 明治産業様Seiken品番変更</br>
        /// </remarks>
        private int InitializeScreen ( out string errMsg )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            // 位置調整用
            Point point; // ADD 2008/10/16

            try
            {
                // 初期値セット・文字列
                this.tEdit_EmployeeCode_St.DataText = string.Empty;
                this.tEdit_EmployeeCode_Ed.DataText = string.Empty;
                this.tNedit_GoodsLGroup_St.DataText = string.Empty;
                this.tNedit_GoodsLGroup_Ed.DataText = string.Empty;
                this.tNedit_GoodsMGroup_St.DataText = string.Empty;
                this.tNedit_GoodsMGroup_Ed.DataText = string.Empty;
                this.tNedit_BLGloupCode_St.DataText = string.Empty;
                this.tNedit_BLGloupCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;

                // --- DEL 2008/10/16 -------------------------------->>>>>
                //// 初期値セット・数値
                //this.tNedit_CustomerCode_St.SetInt( 0 );
                //this.tNedit_CustomerCode_Ed.SetInt( 0 );
                ////this.tNedit_CustomerCode_Ed.SetInt( Int32.Parse( new string( '9', this.tNedit_CustomerCode_Ed.ExtEdit.Column ) ) );
                //this.tNedit_GoodsMakerCd_St.SetInt( 0 );
                //this.tNedit_GoodsMakerCd_Ed.SetInt( 0 );
                ////this.tNedit_GoodsMakerCd_Ed.SetInt( Int32.Parse( new string( '9', this.tNedit_GoodsMakerCd_Ed.ExtEdit.Column ) ) );
                //this.tNedit_BLGoodsCode_St.SetInt( 0 );
                //this.tNedit_BLGoodsCode_Ed.SetInt( 0 );
                ////this.tNedit_BLGoodsCode_Ed.SetInt( Int32.Parse( new string( '9', this.tNedit_BLGoodsCode_Ed.ExtEdit.Column ) ) );
                ////this.tne_St_EnterpriseGanreCode.SetInt( 0 ); // DEL 2008/10/16
                ////this.tne_Ed_EnterpriseGanreCode.SetInt( 0 ); // DEL 2008/10/16

                //// 初期値セット・数値
                ////08.04.07 Mabuchi Delete START---------------------
                ////this.tne_St_ShipmentCnt.SetInt( 1 );
                ////this.tne_Ed_ShipmentCnt.SetInt( 999999999 );
                ////08.04.07 Mabuchi Delete END---------------------

                //// 初期値セット・区分
                //this.uos_GroupBySectionDiv.Value = 1;
                //this.uos_PrintTypeDiv.Value = 0;
                //this.uos_PriceUnitDiv.Value = 0;
                //this.uos_StockOrderDiv.Value = 0;
                //this.uos_NewPageDiv.Value = 0;
                // --- DEL 2008/10/16 --------------------------------<<<<<

                // 初期値セット・日付
                GetDateRange( ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth );

                // 小計印刷
                switch (this._salesTransListCndtn.TotalType)
                {
                    case SalesTransListCndtn.TotalTypeState.EachGoods:
                        {
                            this.CheckEditor_SubtotalCustomer.Visible = false;
                            this.CheckEditor_SubtotalEmployee.Visible = false;
                            this.CheckEditor_SubtotalSupplier.Visible = false;  // ADD 2009/04/15

                            this.CheckEditor_SubtotalMaker.Location = this.CheckEditor_SubtotalCustomer.Location;

                            point = this.CheckEditor_SubtotalMaker.Location;
                            point.X += this.CheckEditor_SubtotalMaker.Size.Width;

                            this.CheckEditor_SubtotalGoodsLGroup.Location = point;

                            point = this.CheckEditor_SubtotalGoodsLGroup.Location;
                            point.X += this.CheckEditor_SubtotalGoodsLGroup.Size.Width;

                            this.CheckEditor_SubtotalGoodsMGroup.Location = point;

                            break;
                        }
                    case SalesTransListCndtn.TotalTypeState.EachCustomer:
                        {
                            this.CheckEditor_SubtotalEmployee.Visible = false;
                            this.CheckEditor_SubtotalSupplier.Visible = false;  // ADD 2009/04/15
                            break;
                        }
                    case SalesTransListCndtn.TotalTypeState.EachEmployee:
                        {
                            this.CheckEditor_SubtotalEmployee.Location 
                                = this.CheckEditor_SubtotalCustomer.Location;

                            this.CheckEditor_SubtotalCustomer.Visible = false;
                            this.CheckEditor_SubtotalSupplier.Visible = false;  // ADD 2009/04/15
                            break;
                        }
                    // --- ADD 2009/04/15 --------------------------->>>>>
                    case SalesTransListCndtn.TotalTypeState.EachSupplier:
                        {
                            this.CheckEditor_SubtotalSupplier.Location
                                = this.CheckEditor_SubtotalCustomer.Location;

                            this.CheckEditor_SubtotalCustomer.Visible = false;
                            this.CheckEditor_SubtotalEmployee.Visible = false;
                            break;
                        }
                    // --- ADD 2009/04/15 ---------------------------<<<<<
                }

                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                if (this._salesTransListCndtn.TotalType == SalesTransListCndtn.TotalTypeState.EachGoods)
                {
                    // 品番集計区分
                    this.tComboEditor_GoodsNoTtlDiv.Enabled = true;
                    Infragistics.Win.ValueList valueList3 = this.GetGoodsNoTtlDivValueList();

                    this.tComboEditor_GoodsNoTtlDiv.ResetItems();

                    for (int i = 0; i < valueList3.ValueListItems.Count; i++)
                    {
                        Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                        vlltem.Tag = valueList3.ValueListItems[i].Tag;
                        vlltem.DataValue = valueList3.ValueListItems[i].DataValue;
                        vlltem.DisplayText = valueList3.ValueListItems[i].DisplayText;
                        this.tComboEditor_GoodsNoTtlDiv.Items.Add(vlltem);
                    }

                    this.tComboEditor_GoodsNoTtlDiv.Value = 0;

                    // 品番表示区分
                    this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                    Infragistics.Win.ValueList valueList4 = this.GetGoodsNoShowDivValueList();

                    this.tComboEditor_GoodsNoShowDiv.ResetItems();

                    for (int i = 0; i < valueList4.ValueListItems.Count; i++)
                    {
                        Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                        vlltem.Tag = valueList4.ValueListItems[i].Tag;
                        vlltem.DataValue = valueList4.ValueListItems[i].DataValue;
                        vlltem.DisplayText = valueList4.ValueListItems[i].DisplayText;
                        this.tComboEditor_GoodsNoShowDiv.Items.Add(vlltem);
                    }

                    this.tComboEditor_GoodsNoShowDiv.Value = 0;
                }
                else
                {
                    this.ultraLabel14.Visible = false;
                    this.ultraLabel19.Visible = false;
                    this.tComboEditor_GoodsNoTtlDiv.Visible = false;
                    this.tComboEditor_GoodsNoTtlDiv.Enabled = false;
                    this.tComboEditor_GoodsNoShowDiv.Visible = false;
                    this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                    this.uebcc_SelectList.Height = 240;
                    
                }
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                // 明細単位
                Infragistics.Win.ValueList valueList2 = this.GetDetailValueList();

                this.tComboEditor_Detail.ResetItems();

                for (int i = 0; i < valueList2.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList2.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList2.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList2.ValueListItems[i].DisplayText;
                    this.tComboEditor_Detail.Items.Add(vlltem);
                }

                this.tComboEditor_Detail.Value = 0;

                // 改頁 // ADD 2008/12/09 (設定順変更)
                Infragistics.Win.ValueList valueList1 = this.GetNewPageDivValueList();

                this.uos_NewPageDiv.ResetValueList();

                for (int i = 0; i < valueList1.ValueListItems.Count; i++)
                {
                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList1.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList1.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList1.ValueListItems[i].DisplayText;
                    this.uos_NewPageDiv.Items.Add(vlltem);
                }

                this.uos_NewPageDiv.Value = 0;
                
                // ボタン設定
                this.SetIconImage( this.ub_St_CustomerGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_CustomerGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_EmployeeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_EmployeeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_LargeGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_LargeGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_MediumGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_MediumGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_DetailGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_DetailGoodsGanreCodeGuide, Size16_Index.STAR1 );
                //this.SetIconImage(this.ub_St_EnterpriseGanreCodeGuide, Size16_Index.STAR1); // DEL 2008/10/16
                //this.SetIconImage(this.ub_Ed_EnterpriseGanreCodeGuide, Size16_Index.STAR1); // DEL 2008/10/16
                this.SetIconImage( this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_St_GoodsNoGuide, Size16_Index.STAR1 ); // DEL 2008/10/16
                //this.SetIconImage( this.ub_Ed_GoodsNoGuide, Size16_Index.STAR1 ); // DEL 2008/10/16
                this.SetIconImage(this.ub_St_SupplierGuide, Size16_Index.STAR1);  // ADD 2009/04/15
                this.SetIconImage(this.ub_Ed_SupplierGuide, Size16_Index.STAR1);  // ADD 2009/04/15

                // 表示位置制御
                switch (this._salesTransListCndtn.TotalType)
                {
                    case SalesTransListCndtn.TotalTypeState.EachGoods:
                        {
                            this.pn_CustomerCndtn.Visible = false;
                            this.pn_EmployeeCndtn.Visible = false;
                            this.pn_SupplierCndtn.Visible = false;  // ADD 2009/04/15

                            this.pn_GoodsInfoCndtn.Location = this.pn_CustomerCndtn.Location;

                            this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 175;
                        }
                        break;
                    case SalesTransListCndtn.TotalTypeState.EachCustomer:
                        {
                            this.pn_EmployeeCndtn.Visible = false;
                            this.pn_SupplierCndtn.Visible = false;  // ADD 2009/04/15

                            this.pn_GoodsInfoCndtn.Location = this.pn_EmployeeCndtn.Location;

                            this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 200;
                        }
                        break;
                    case SalesTransListCndtn.TotalTypeState.EachEmployee:
                        {
                            this.pn_CustomerCndtn.Visible = false;
                            this.pn_SupplierCndtn.Visible = false;  // ADD 2009/04/15

                            this.pn_GoodsInfoCndtn.Location = this.pn_EmployeeCndtn.Location;
                            this.pn_EmployeeCndtn.Location = this.pn_CustomerCndtn.Location;

                            this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 200;
                        }
                        break;
                    // --- ADD 2009/04/15 ---------------------------------->>>>>
                    case SalesTransListCndtn.TotalTypeState.EachSupplier:
                        {
                            this.pn_CustomerCndtn.Visible = false;
                            this.pn_EmployeeCndtn.Visible = false;

                            this.pn_SupplierCndtn.Location = this.pn_CustomerCndtn.Location;
                            this.pn_GoodsInfoCndtn.Location = this.pn_EmployeeCndtn.Location;

                            this.ueb_MainExplorerBar.Groups[2].Settings.ContainerHeight = 200;
                        }
                        break;
                    // --- ADD 2009/04/15 ----------------------------------<<<<<
                }

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput(); // ADD 2008/10/16

                // 初期フォーカスセット
                this.uos_GroupBySectionDiv.Focus();
                this.uos_GroupBySectionDiv.FocusedIndex = (int)this.uos_GroupBySectionDiv.Value;    // ADD 2008/03/31 不具合対応[12918]～[12920]：スペースキーでの項目選択機能を実装
            }
            catch ( Exception ex )
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        /// <summary>
        /// 日付取得処理
        /// </summary>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        private void GetDateRange( ref TDateEdit startDateEdit, ref TDateEdit endDateEdit )
        {
            /* ---DEL 2009/03/05 不具合対応[12186] -------------------------------->>>>>
            // 期首月
            List<DateTime> stDate;
            List<DateTime> edDate;
            List<DateTime> yearMonth;
            _dateGetAcs.GetFinancialYearTable( out stDate, out edDate, out yearMonth );
            
            startDateEdit.SetDateTime( yearMonth[0] );


            // 現在処理中年月
            DateTime thisYearMonth;
            _dateGetAcs.GetThisYearMonth( out thisYearMonth );

            endDateEdit.SetDateTime( thisYearMonth );
               ---DEL 2009/03/05 不具合対応[12186] --------------------------------<<<<< */
            // ---ADD 2009/03/05 不具合対応[12186] -------------------------------->>>>>
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                // 売上今回月次更新日を設定
                endDateEdit.SetDateTime(currentTotalMonth);
                startDateEdit.SetDateTime(currentTotalMonth.AddMonths(-11));
            }
            else
            {
                // 当月を設定
                DateTime nowYearMonth;
                this._dateGetAcs.GetThisYearMonth(out nowYearMonth);

                endDateEdit.SetDateTime(nowYearMonth);
                startDateEdit.SetDateTime(nowYearMonth.AddMonths(-11));
            }
            // ---ADD 2009/03/05 不具合対応[12186] --------------------------------<<<<<
        }
        #endregion

        #region ◎ ボタンアイコン設定処理
        /// <summary>
        /// ボタンアイコン設定処理
        /// </summary>
        /// <param name="settingControl">アイコンセットするコントロール</param>
        /// <param name="iconIndex">アイコンインデックス</param>
        private void SetIconImage ( object settingControl, Size16_Index iconIndex )
        {
            ( (UltraButton)settingControl ).ImageList = IconResourceManagement.ImageList16;
            ( (UltraButton)settingControl ).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion ◆ 画面初期化関係

        #region ◆ 印刷前処理
        #region ◎ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        private bool ScreenInputCheck ( ref string errMessage, ref Control errComponent )
        {
            bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_InputError = "の入力が不正です";
            const string ct_NoInput = "を入力して下さい";
            const string ct_RangeError = "の範囲指定に誤りがあります";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            const string ct_FullRangeError = "は１２ヶ月の範囲で指定して下さい";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki


            //--------------------------------------------------------------------------
            // 対象年月
            //--------------------------------------------------------------------------
            if ( CallCheckDateRange( out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth ) == false )
            {
                switch ( cdrResult )
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format( "開始対象年月{0}", ct_NoInput );
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format( "開始対象年月{0}", ct_InputError );
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format( "終了対象年月{0}", ct_NoInput );
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format( "終了対象年月{0}", ct_InputError );
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format( "対象年月{0}", ct_RangeError );
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format( "対象年月{0}", ct_FullRangeError );
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                }
                status = false;
            }
            //--------------------------------------------------------------------------
            // 出荷数
            //--------------------------------------------------------------------------
            // (開始 > 終了 → NG）
            //else if (this.tne_St_ShipmentCnt.GetInt() > GetEndCode(this.tne_Ed_ShipmentCnt)) // DEL 2009/02/10
            else if (!string.IsNullOrEmpty(this.tne_St_ShipmentCnt.Text)
                && !string.IsNullOrEmpty(this.tne_Ed_ShipmentCnt.Text)
                && this.tne_St_ShipmentCnt.GetInt() > this.tne_Ed_ShipmentCnt.GetInt()) // ADD 2009/02/10
            {
                errMessage = string.Format( "出荷数{0}", ct_RangeError );
                errComponent = this.tne_St_ShipmentCnt;
                status = false;
            }
            //--------------------------------------------------------------------------
            // 得意先
            //--------------------------------------------------------------------------
            // (開始 > 終了 → NG）
            else if ( this.tNedit_CustomerCode_St.GetInt() > GetEndCode(this.tNedit_CustomerCode_Ed) )
            {
                errMessage = string.Format( "得意先コード{0}", ct_RangeError );
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
            }

            // --- ADD 2009/04/15 ------------------------------------------->>>>>
            //--------------------------------------------------------------------------
            // 仕入先
            //--------------------------------------------------------------------------
            // (開始 > 終了 → NG）
            else if (this.tNedit_SupplierCd_St.GetInt() > GetEndCode(this.tNedit_SupplierCd_Ed))
            {
                errMessage = string.Format("仕入先コード{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // --- ADD 2009/04/15 -------------------------------------------<<<<<

            //--------------------------------------------------------------------------
            // 担当者コード
            //--------------------------------------------------------------------------
            else if (
                ( this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_EmployeeCode_St.DataText.TrimEnd().CompareTo( this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() ) > 0 ) )
            {
                errMessage = string.Format( "担当者コード{0}", ct_RangeError );
                errComponent = this.tEdit_EmployeeCode_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // メーカー
            //--------------------------------------------------------------------------
            // (開始 > 終了 → NG）
            else if ( this.tNedit_GoodsMakerCd_St.GetInt() > GetEndCode(this.tNedit_GoodsMakerCd_Ed) )
            {
                errMessage = string.Format( "メーカーコード{0}", ct_RangeError );
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // 商品大分類
            //--------------------------------------------------------------------------
            //else if (
            //     ( this.tNedit_GoodsLGroup_St.DataText.TrimEnd() != string.Empty ) &&
            //     ( this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() != string.Empty ) &&
            //     ( this.tNedit_GoodsLGroup_St.DataText.TrimEnd().CompareTo( this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() ) > 0 ) ) // DEL 2008/10/16
            else if (this.tNedit_GoodsLGroup_St.GetInt() > GetEndCode(this.tNedit_GoodsLGroup_Ed)) // ADD 2008/10/16
            {
                //errMessage = string.Format( "商品区分グループコード{0}", ct_RangeError ); // DEL 2008/10/16
                errMessage = string.Format("商品大分類コード{0}", ct_RangeError); // ADD 2008/10/16
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // 商品中分類
            //--------------------------------------------------------------------------
            //else if (
                 //( this.tNedit_GoodsMGroup_St.DataText.TrimEnd() != string.Empty ) &&
                 //( this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() != string.Empty ) &&
                 //( this.tNedit_GoodsMGroup_St.DataText.TrimEnd().CompareTo( this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() ) > 0 ) ) // DEL 2008/10/16
            else if (this.tNedit_GoodsMGroup_St.GetInt() > GetEndCode(this.tNedit_GoodsMGroup_Ed)) // ADD 2008/10/16
            {
                //errMessage = string.Format( "商品区分コード{0}", ct_RangeError ); // DEL 2008/10/16
                errMessage = string.Format("商品中分類コード{0}", ct_RangeError); // ADD 2008/10/16
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // グループコード
            //--------------------------------------------------------------------------
            //else if (
            //     ( this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty ) &&
            //     ( this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty ) &&
            //     ( this.tNedit_BLGloupCode_St.DataText.TrimEnd().CompareTo( this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() ) > 0 ) ) // DEL 2008/10/16
            else if (this.tNedit_BLGloupCode_St.GetInt() > GetEndCode(this.tNedit_BLGloupCode_Ed)) // ADD 2008/10/16
            {
                //errMessage = string.Format("商品区分詳細コード{0}", ct_RangeError); // DEL 2008/10/16
                errMessage = string.Format("グループコード{0}", ct_RangeError); // ADD 2008/10/16
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // --- DEL 2008/10/16 -------------------------------->>>>>
            ////--------------------------------------------------------------------------
            //// 自社分類コード
            ////--------------------------------------------------------------------------
            //// (開始 > 終了 → NG）
            //else if ( this.tne_St_EnterpriseGanreCode.GetInt() > GetEndCode( this.tne_Ed_EnterpriseGanreCode ) )
            //{
            //    errMessage = string.Format( "自社分類コード{0}", ct_RangeError );
            //    errComponent = this.tne_St_EnterpriseGanreCode;
            //    status = false;
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            //--------------------------------------------------------------------------
            // ＢＬコード
            //--------------------------------------------------------------------------
            // (開始 > 終了 → NG）
            else if ( this.tNedit_BLGoodsCode_St.GetInt() > GetEndCode(this.tNedit_BLGoodsCode_Ed) )
            {
                //errMessage = string.Format("ＢＬ商品コード{0}", ct_RangeError); // DEL 2008/10/16
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError); // ADD 2008/10/16
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // 商品番号
            //--------------------------------------------------------------------------
            else if (
                 ( this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty ) &&
                 ( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty ) &&
                 ( this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() ) > 0 ) )
            {
                //errMessage = string.Format( "商品番号{0}", ct_RangeError ); // DEL 2008/10/16
                errMessage = string.Format("品番{0}", ct_RangeError); // ADD 2008/10/16
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }
            return status;
        }
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpYearMonth"></param>
        /// <param name="tde_Ed_AddUpYearMonth"></param>
        /// <returns></returns>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpYearMonth, ref TDateEdit tde_Ed_AddUpYearMonth )
        {
            cdrResult = _dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, false );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>数値コード項目の内容を取得する</br>
        /// <br>　コード値＝ゼロ　→　ＭＡＸ値</br>
        /// <br>　コード値≠ゼロ　→　入力値</br>
        /// </remarks>
        private int GetEndCode( TNedit tNedit )
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode( tNedit, Int32.Parse( new string( '9', (tNedit.ExtEdit.Column) ) ) );
        }
        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode( TNedit tNedit, int endCodeOnDB )
        {
            if ( tNedit.GetInt() == 0 )
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion

        #region ◎ 日付入力チェック処理
        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="targetDateEdit">チェック対象コントロール</param>
        /// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
        /// <returns>チェック結果(true/false)</returns>
        /// <remarks>
        /// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        private bool DateEditInputCheck ( TDateEdit targetDateEdit, bool allowEmpty )
        {
            bool status = true;

            // 入力日付を数値型で取得
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = ( date / 100 ) % 100;
            int dd = date % 100;

            // 日付未入力チェック
            if ( targetDateEdit.GetDateTime() == DateTime.MinValue )
            {
                if ( allowEmpty == true )
                {
                    return status;
                }
                else
                {
                    status = false;
                }
            }
            // システムサポートチェック
            else if ( yy < 1900 )
            {
                status = false;
            }
            // 年月日別入力チェック
            else if ( ( yy == 0 ) || ( mm == 0 ) || ( dd == 0 ) )
            {
                status = false;
            }
            // 単純日付妥当性チェック
            else if ( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
            {
                status = false;
            }

            return status;
        }
        #endregion

        #region ◎ 抽出条件設定処理(画面→抽出条件)
        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 画面→抽出条件へ設定する。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// <br>Update Note : 2014/12/16 劉超</br>
        /// <br>管理番号    : 11070263-00</br>
        /// <br>            : 明治産業様Seiken品番変更</br>
        /// </remarks>
        private int SetExtraInfoFromScreen ()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                //------------------------------------------
                // ※帳票集計区分 TotalType は,起動時に
                // 　パラメータ受取のみでセットされる。
                //------------------------------------------

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 「全拠点」が選択されている場合はリストをクリア
                bool allSections = false;

                foreach ( object obj in _selectedSectionList.Values )
                {
                    if ( obj is string )
                    {
                        if ( (obj as string) == "0" )
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if ( allSections )
                {
                    _selectedSectionList.Clear();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 拠点オプション
                this._salesTransListCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                this._salesTransListCndtn.EnterpriseCode = this._enterpriseCode;

                // 拠点別集計区分
                this._salesTransListCndtn.TtlType = (SalesTransListCndtn.TtlTypeState)this.uos_GroupBySectionDiv.Value;
                // 金額単位区分
                this._salesTransListCndtn.PriceUnitDiv = (SalesTransListCndtn.PriceUnitDivState)this.uos_PriceUnitDiv.Value;

                // 計上拠点コード（複数指定）
                ArrayList sectionList = new ArrayList( this._selectedSectionList.Values );
                this._salesTransListCndtn.AddUpSecCodes = (string[])sectionList.ToArray( typeof( string ) );

                // 開始・終了日付
                SetDateRangeFromDisplay( ref this._salesTransListCndtn );

                // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
                // 終了範囲の入力チェック
                if (this.tNedit_CustomerCode_Ed.GetInt() == 0)
                {
                    this._salesTransListCndtn.Set_CustomerCode = false;
                }
                else
                {
                    this._salesTransListCndtn.Set_CustomerCode = true;
                }
                // --- ADD 2009/04/15 ---------------------->>>>>
                if (this.tNedit_SupplierCd_Ed.GetInt() == 0)
                {
                    this._salesTransListCndtn.Set_SupplierCode = false;
                }
                else
                {
                    this._salesTransListCndtn.Set_SupplierCode = true;
                }
                // --- ADD 2009/04/15 ----------------------<<<<<
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == string.Empty)
                {
                    this._salesTransListCndtn.Set_EmployeeCode = false;
                }
                else
                {
                    this._salesTransListCndtn.Set_EmployeeCode = true;
                }
                if (this.tNedit_GoodsMakerCd_Ed.GetInt() == 0)
                {
                    this._salesTransListCndtn.Set_GoodsMakerCd = false;
                }
                else
                {
                    this._salesTransListCndtn.Set_GoodsMakerCd = true;
                }
                if (this.tNedit_GoodsLGroup_Ed.GetInt() == 0)
                {
                    this._salesTransListCndtn.Set_GoodsLGroup = false;
                }
                else
                {
                    this._salesTransListCndtn.Set_GoodsLGroup = true;
                }
                if (this.tNedit_GoodsMGroup_Ed.GetInt() == 0)
                {
                    this._salesTransListCndtn.Set_GoodsMGroup = false;
                }
                else
                {
                    this._salesTransListCndtn.Set_GoodsMGroup = true;
                }
                if (this.tNedit_BLGloupCode_Ed.GetInt() == 0)
                {
                    this._salesTransListCndtn.Set_BLGloupCode = false;
                }
                else
                {
                    this._salesTransListCndtn.Set_BLGloupCode = true;
                }
                if (this.tNedit_BLGoodsCode_Ed.GetInt() == 0)
                {
                    this._salesTransListCndtn.Set_BLGoodsCode = false;
                }
                else
                {
                    this._salesTransListCndtn.Set_BLGoodsCode = true;
                }
                // ADD 2008/10/30 不具合対応[7203] ----------<<<<<

                // 在庫取寄区分
                this._salesTransListCndtn.StockOrderDiv = (SalesTransListCndtn.StockOrderDivState)this.uos_StockOrderDiv.Value;
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //// 開始部門コード
                //this._salesTransListCndtn.St_SubSectionCode = 0;     // (未使用)
                //// 終了部門コード
                //this._salesTransListCndtn.Ed_SubSectionCode = 99;    // (未使用)
                //// 開始課コード
                //this._salesTransListCndtn.St_MinSectionCode = 0;     // (未使用)
                //// 終了課コード
                //this._salesTransListCndtn.Ed_MinSectionCode = 99;    // (未使用)
                // --- DEL 2008/10/16 --------------------------------<<<<<
                // 開始従業員コード
                //this._salesTransListCndtn.St_EmployeeCode = this.tEdit_EmployeeCode_St.Text; // DLL 2008/10/16
                //if (this.tEdit_EmployeeCode_St.DataText == "") this._salesTransListCndtn.St_EmployeeCode = "0000"; // ADD 2008/10/16 // DEL 2008/12/09
                //else this._salesTransListCndtn.St_EmployeeCode = this.tEdit_EmployeeCode_St.DataText.PadLeft(4, '0'); // ADD 2008/10/16 // DEL 2008/12/09
                this._salesTransListCndtn.St_EmployeeCode = this.tEdit_EmployeeCode_St.DataText; // ADD 2008/12/09
                // 終了従業員コード
                //this._salesTransListCndtn.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.Text; // DLL 2008/10/16
                //if (this.tEdit_EmployeeCode_Ed.DataText == "") this._salesTransListCndtn.Ed_EmployeeCode = "9999"; // ADD 2008/10/16 // DEL 2008/12/09
                //else this._salesTransListCndtn.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.DataText.PadLeft(4, '0'); // ADD 2008/10/16 // DEL 2008/12/09
                this._salesTransListCndtn.Ed_EmployeeCode = this.tEdit_EmployeeCode_Ed.DataText; // ADD 2008/12/09
                // 開始得意先コード
                this._salesTransListCndtn.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();
                // 終了得意先コード
                this._salesTransListCndtn.Ed_CustomerCode = GetEndCode( this.tNedit_CustomerCode_Ed);
                // --- ADD 2009/04/15 ---------------------------->>>>>
                // 開始仕入先コード
                this._salesTransListCndtn.St_SupplierCode = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                this._salesTransListCndtn.Ed_SupplierCode = GetEndCode(this.tNedit_SupplierCd_Ed);
                // --- ADD 2009/04/15 ----------------------------<<<<<
                // 開始メーカーコード
                this._salesTransListCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了メーカーコード
                this._salesTransListCndtn.Ed_GoodsMakerCd = GetEndCode( this.tNedit_GoodsMakerCd_Ed);
                // 開始品番
                this._salesTransListCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.Text;
                // 終了品番
                this._salesTransListCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text;
                // 開始BLコード
                this._salesTransListCndtn.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                // 終了BLコード
                this._salesTransListCndtn.Ed_BLGoodsCode = GetEndCode( this.tNedit_BLGoodsCode_Ed);
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //// 開始商品区分グループコード
                //this._salesTransListCndtn.St_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_St.Text;
                //// 終了商品区分グループコード
                //this._salesTransListCndtn.Ed_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_Ed.Text;
                //// 開始商品区分コード
                //this._salesTransListCndtn.St_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_St.Text;
                //// 終了商品区分コード
                //this._salesTransListCndtn.Ed_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_Ed.Text;
                //// 開始商品区分詳細コード
                //this._salesTransListCndtn.St_DetailGoodsGanreCode = this.tNedit_BLGloupCode_St.Text;
                //// 終了商品区分詳細コード
                //this._salesTransListCndtn.Ed_DetailGoodsGanreCode = this.tNedit_BLGloupCode_Ed.Text;
                // --- DEL 2008/10/16 --------------------------------<<<<<
                // --- ADD 2008/10/16 -------------------------------->>>>>
                // 開始商品大分類コード
                this._salesTransListCndtn.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
                // 終了商品大分類コード
                this._salesTransListCndtn.Ed_GoodsLGroup = GetEndCode(this.tNedit_GoodsLGroup_Ed);
                // 開始商品中分類コード
                this._salesTransListCndtn.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                // 終了商品中分類コード
                this._salesTransListCndtn.Ed_GoodsMGroup = GetEndCode(this.tNedit_GoodsMGroup_Ed);
                // 開始グループコード
                this._salesTransListCndtn.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                // 終了グループコード
                this._salesTransListCndtn.Ed_BLGroupCode = GetEndCode(this.tNedit_BLGloupCode_Ed);
                // --- ADD 2008/10/16 --------------------------------<<<<<
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //// 開始自社分類コード
                //this._salesTransListCndtn.St_EnterpriseGanreCode = this.tne_St_EnterpriseGanreCode.GetInt();
                //// 終了自社分類コード
                //this._salesTransListCndtn.Ed_EnterpriseGanreCode = GetEndCode(this.tne_Ed_EnterpriseGanreCode, 9999);
                //// 開始仕入先コード
                //this._salesTransListCndtn.St_SupplierCd = 0;                 // (未使用)
                //// 終了仕入先コード
                //this._salesTransListCndtn.Ed_SupplierCd = 999999999;         // (未使用)
                // --- DEL 2008/10/16 --------------------------------<<<<<
                // 開始出荷数
                //this._salesTransListCndtn.St_ShipmentCnt = this.tne_St_ShipmentCnt.GetInt(); // DEL 2009/02/10
                // --- ADD 2009/02/10 -------------------------------->>>>>
                if (this.tne_St_ShipmentCnt.Text == string.Empty)
                {
                    this._salesTransListCndtn.St_ShipmentCnt = -99999999;
                    this._salesTransListCndtn.St_ShipmentCntNoInputFlg = true; // 未入力フラグ
                }
                else
                {
                    this._salesTransListCndtn.St_ShipmentCnt = this.tne_St_ShipmentCnt.GetInt();
                    this._salesTransListCndtn.St_ShipmentCntNoInputFlg = false; // 未入力フラグ
                }
                // --- ADD 2009/02/10 --------------------------------<<<<<

                // 終了出荷数
                //this._salesTransListCndtn.Ed_ShipmentCnt = this.tne_Ed_ShipmentCnt.GetInt(); // DEL 2008/10/16
                //this._salesTransListCndtn.Ed_ShipmentCnt = this.GetEndCode(this.tne_Ed_ShipmentCnt); // ADD 2008/10/16 // DEL 2009/02/10
                // --- ADD 2009/02/10 -------------------------------->>>>>
                if (this.tne_Ed_ShipmentCnt.Text == string.Empty)
                {
                    this._salesTransListCndtn.Ed_ShipmentCnt = 999999999;
                    this._salesTransListCndtn.Ed_ShipmentCntNoInputFlg = true; // 未入力フラグ
                }
                else
                {
                    this._salesTransListCndtn.Ed_ShipmentCnt = this.tne_Ed_ShipmentCnt.GetInt();
                    this._salesTransListCndtn.Ed_ShipmentCntNoInputFlg = false; // 未入力フラグ
                }
                // --- ADD 2009/02/10 --------------------------------<<<<<
                // 金額単位区分
                this._salesTransListCndtn.PriceUnitDiv = (SalesTransListCndtn.PriceUnitDivState)this.uos_PriceUnitDiv.Value;
                // 改ページ区分
                this._salesTransListCndtn.NewPageDiv = (SalesTransListCndtn.NewPageDivState)this.uos_NewPageDiv.Value;

                // 各種計印字区分設定
                //SetSumPrintDivFromCLB( ref this._salesTransListCndtn, this.clb_SumPrintDiv ); // DEL 2008/10/16
                SetSumPrintDivFromCLB(ref this._salesTransListCndtn); // ADD 2008/10/16

                // 印刷タイプ（金額・数量）
                this._salesTransListCndtn.PrintTypeDiv = (SalesTransListCndtn.PrintTypeDivState)this.uos_PrintTypeDiv.Value;

                // --- ADD 2008/10/16 -------------------------------->>>>>
                // メーカー別印刷
                this._salesTransListCndtn.MakerPrintDiv = (SalesTransListCndtn.MakerPrintDivState)this.uos_MakerPrintDiv.CheckedItem.DataValue;

                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                if (this._salesTransListCndtn.TotalType == SalesTransListCndtn.TotalTypeState.EachGoods) 
                {
                    //　明細単位が「品番」場合
                    if (this.tComboEditor_Detail.SelectedIndex == 0)
                    {
                        // 品番集計区分
                        this._salesTransListCndtn.GoodsNoTtlDiv = (SalesTransListCndtn.GoodsNoTtlDivState)this.tComboEditor_GoodsNoTtlDiv.Value;
                        // 品番集計区分が「合算」時
                        if (this.tComboEditor_GoodsNoTtlDiv.SelectedIndex == 1)
                        {
                            // 品番表示区分
                            this._salesTransListCndtn.GoodsNoShowDiv = (SalesTransListCndtn.GoodsNoShowDivState)this.tComboEditor_GoodsNoShowDiv.Value;
                        }
                    }
                }
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                // 明細単位(抽出条件用)
                this._salesTransListCndtn.Detail = this.tComboEditor_Detail.SelectedIndex;
                // 明細単位(ＵＩ制御用)
                this._salesTransListCndtn.DetailDataValue = (SalesTransListCndtn.DetailDataValueState)this.tComboEditor_Detail.SelectedItem.DataValue;
                // --- ADD 2008/10/16 --------------------------------<<<<<
            }
            catch ( Exception )
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        /// <summary>
        /// 開始・終了日付設定処理
        /// </summary>
        private void SetDateRangeFromDisplay ( ref SalesTransListCndtn targetCndtn )
        {
            int longDate = 0;

            // 開始月
            longDate = this.tde_St_AddUpYearMonth.GetLongDate();
            longDate = ( longDate / 100 ) * 100 + 1;
            this.tde_St_AddUpYearMonth.SetLongDate( longDate );
            targetCndtn.St_ThisYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();

            // 終了月
            longDate = this.tde_Ed_AddUpYearMonth.GetLongDate();
            longDate = ( longDate / 100 ) * 100 + 1;
            this.tde_Ed_AddUpYearMonth.SetLongDate( longDate );
            targetCndtn.Ed_ThisYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();

        }
        
        /// <summary>
        /// 各種計印字区分設定
        /// </summary>
        /// <param name="targetCndtn"></param>
        //private void SetSumPrintDivFromCLB(ref SalesTransListCndtn targetCndtn, CheckedListBox sourceClb) // DEL 2008/10/16
        private void SetSumPrintDivFromCLB(ref SalesTransListCndtn targetCndtn) // ADD 2008/10/16
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //for (int index = 0; index < sourceClb.Items.Count; index++)
            //{
            //    // チェック有無取得
            //    SalesTransListCndtn.SumPrintDivState sumPrintDiv;
            //    if (sourceClb.GetItemChecked(index))
            //    {
            //        sumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            //    }
            //    else
            //    {
            //        sumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;
            //    }

            //    if (_sumPrintCheckDicKeyList.Count <= index) continue;

            //    // 値セット
            //    // (リストのindex → リストに含まれる項目Itemのenum値)
            //    switch ((SumPrintItem)_sumPrintCheckDicKeyList[index])
            //    {
            //        case SumPrintItem.BLGoodsCode:
            //            targetCndtn.BLCodeSumPrintDiv = sumPrintDiv;
            //            break;
            //        case SumPrintItem.EnterpriseGanreCode:
            //            targetCndtn.EnterpriseGanreSumPrintDiv = sumPrintDiv;
            //            break;
            //        case SumPrintItem.DGoodsGanre:
            //            targetCndtn.DGoodsGanreSumPrintDiv = sumPrintDiv;
            //            break;
            //        case SumPrintItem.MGoodsGanre:
            //            targetCndtn.MGoodsGanreSumPrintDiv = sumPrintDiv;
            //            break;
            //        case SumPrintItem.LGoodsGanre:
            //            targetCndtn.LGoodsGanreSumPrintDiv = sumPrintDiv;
            //            break;
            //        case SumPrintItem.Maker:
            //            targetCndtn.MakerSumPrintDiv = sumPrintDiv;
            //            break;
            //        case SumPrintItem.Employee:
            //            targetCndtn.EmployeeSumPrintDiv = sumPrintDiv;
            //            break;
            //        case SumPrintItem.Customer:
            //            targetCndtn.CustomerSumPrintDiv = sumPrintDiv;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            //小計印刷
            // 拠点
            if (this.CheckEditor_SubtotalSection.Checked) targetCndtn.SectionSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.SectionSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;

            // 得意先
            if (this.CheckEditor_SubtotalCustomer.Checked) targetCndtn.CustomerSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.CustomerSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;

            // 仕入先　　// ADD 2009/04/15
            if (this.CheckEditor_SubtotalSupplier.Checked) targetCndtn.SupplierSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.SupplierSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;

            // 担当者
            if (this.CheckEditor_SubtotalEmployee.Checked) targetCndtn.EmployeeSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.EmployeeSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;

            // メーカー
            if (this.CheckEditor_SubtotalMaker.Checked) targetCndtn.MakerSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.MakerSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;

            // 商品大分類
            if (this.CheckEditor_SubtotalGoodsLGroup.Checked) targetCndtn.GoodsLGroupSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.GoodsLGroupSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;

            // 商品中分類
            if (this.CheckEditor_SubtotalGoodsMGroup.Checked) targetCndtn.GoodsMGroupSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.GoodsMGroupSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;

            // グループコード
            if (this.CheckEditor_SubtotalGroupCode.Checked) targetCndtn.BLGroupCodeSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.BLGroupCodeSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;

            // BLコード
            if (this.CheckEditor_SubtotalBl.Checked) targetCndtn.BLGoodsCodeSumPrintDiv = SalesTransListCndtn.SumPrintDivState.Print;
            else targetCndtn.BLGoodsCodeSumPrintDiv = SalesTransListCndtn.SumPrintDivState.None;
            // --- ADD 2008/10/16 --------------------------------<<<<<
        }
        

        #endregion

        #region ◎ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2014/12/16 劉超</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.uos_GroupBySectionDiv);
            //saveCtrAry.Add(this.tde_St_AddUpYearMonth);       //DEL 2009/03/05 不具合対応[12186]
            //saveCtrAry.Add(this.tde_Ed_AddUpYearMonth);       //DEL 2009/03/05 不具合対応[12186]
            //saveCtrAry.Add(this.tne_St_ShipmentCnt); // DEL 2009/02/12
            //saveCtrAry.Add(this.tne_Ed_ShipmentCnt); // DEL 2009/02/12
            saveCtrAry.Add(uos_PrintTypeDiv);
            saveCtrAry.Add(uos_PriceUnitDiv);
            saveCtrAry.Add(uos_StockOrderDiv);
            saveCtrAry.Add(this.uos_MakerPrintDiv);
            saveCtrAry.Add(this.uos_NewPageDiv);
            saveCtrAry.Add(this.tComboEditor_Detail);
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            saveCtrAry.Add(this.tComboEditor_GoodsNoTtlDiv);
            saveCtrAry.Add(this.tComboEditor_GoodsNoShowDiv);
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            saveCtrAry.Add(this.tNedit_CustomerCode_St);
            saveCtrAry.Add(this.tNedit_CustomerCode_Ed);
            saveCtrAry.Add(this.tEdit_CustomerCode_St_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_CustomerCode_Ed_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tNedit_SupplierCd_St);  // ADD 2009/04/15
            saveCtrAry.Add(this.tNedit_SupplierCd_Ed);  // ADD 2009/04/15
            saveCtrAry.Add(this.tEdit_SupplierCd_St_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_SupplierCd_Ed_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_EmployeeCode_St);
            saveCtrAry.Add(this.tEdit_EmployeeCode_Ed);
            saveCtrAry.Add(this.tEdit_EmployeeCode_St_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_EmployeeCode_Ed_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_St);
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_Ed);
            saveCtrAry.Add(this.tEdit_GoodsMakerCd_St_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_GoodsMakerCd_Ed_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tNedit_GoodsLGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_Ed);
            saveCtrAry.Add(this.tEdit_GoodsLGroup_St_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_GoodsLGroup_Ed_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tNedit_GoodsMGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_Ed);
            saveCtrAry.Add(this.tEdit_GoodsMGroup_St_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_GoodsMGroup_Ed_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tNedit_BLGloupCode_St);
            saveCtrAry.Add(this.tNedit_BLGloupCode_Ed);
            saveCtrAry.Add(this.tEdit_BLGloupCode_St_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_BLGloupCode_Ed_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tNedit_BLGoodsCode_St);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_Ed);
            saveCtrAry.Add(this.tEdit_BLGoodsCode_St_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_BLGoodsCode_Ed_Nm);// ADD 2011/08/16
            saveCtrAry.Add(this.tEdit_GoodsNo_St);
            saveCtrAry.Add(this.tEdit_GoodsNo_Ed);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region ◎　小計表示制御
        /// <summary>
        /// 小計単位の表示制御
        /// </summary>
        private void SubTotalSetting()
        {
            bool sectionIsAble = true;
            bool makerIsAble = true;

            if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 0) // 明細単位：品番
            {
                this.CheckEditor_SubtotalBl.Enabled = true;
                this.CheckEditor_SubtotalGroupCode.Enabled = true;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = true;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = true;
                makerIsAble = true;
                sectionIsAble = true;
                this.CheckEditor_SubtotalCustomer.Enabled = true;
                this.CheckEditor_SubtotalEmployee.Enabled = true;
                this.CheckEditor_SubtotalSupplier.Enabled = true; // ADD 2009/04/15
            }
            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 1) // 明細単位：BLコード
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Enabled = true;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = true;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = true;
                makerIsAble = true;
                sectionIsAble = true;
                this.CheckEditor_SubtotalCustomer.Enabled = true;
                this.CheckEditor_SubtotalEmployee.Enabled = true;
                this.CheckEditor_SubtotalSupplier.Enabled = true; // ADD 2009/04/15
            }
            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 2) // 明細単位：グループコード
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Checked = false;
                this.CheckEditor_SubtotalGroupCode.Enabled = false;

                this.CheckEditor_SubtotalGoodsMGroup.Enabled = true;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = true;
                makerIsAble = true;
                sectionIsAble = true;
                this.CheckEditor_SubtotalCustomer.Enabled = true;
                this.CheckEditor_SubtotalEmployee.Enabled = true;
                this.CheckEditor_SubtotalSupplier.Enabled = true; // ADD 2009/04/15
            }
            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 3) // 明細単位：中分類
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Checked = false;
                this.CheckEditor_SubtotalGroupCode.Enabled = false;

                this.CheckEditor_SubtotalGoodsMGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = false;

                this.CheckEditor_SubtotalGoodsLGroup.Enabled = true;
                makerIsAble = true;
                sectionIsAble = true;
                this.CheckEditor_SubtotalCustomer.Enabled = true;
                this.CheckEditor_SubtotalEmployee.Enabled = true;
                this.CheckEditor_SubtotalSupplier.Enabled = true; // ADD 2009/04/15
            }
            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 4) // 明細単位：大分類
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Checked = false;
                this.CheckEditor_SubtotalGroupCode.Enabled = false;

                this.CheckEditor_SubtotalGoodsMGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = false;

                this.CheckEditor_SubtotalGoodsLGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = false;

                makerIsAble = true;
                sectionIsAble = true;
                this.CheckEditor_SubtotalCustomer.Enabled = true;
                this.CheckEditor_SubtotalEmployee.Enabled = true;
                this.CheckEditor_SubtotalSupplier.Enabled = true; // ADD 2009/04/15
            }
            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 5) // 明細単位：メーカー
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Checked = false;
                this.CheckEditor_SubtotalGroupCode.Enabled = false;

                this.CheckEditor_SubtotalGoodsMGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = false;

                this.CheckEditor_SubtotalGoodsLGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = false;

                makerIsAble = false;

                sectionIsAble = true;
                this.CheckEditor_SubtotalCustomer.Enabled = true;
                this.CheckEditor_SubtotalEmployee.Enabled = true;
                this.CheckEditor_SubtotalSupplier.Enabled = true; // ADD 2009/04/15
            }
            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 6) // 明細単位：拠点
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Checked = false;
                this.CheckEditor_SubtotalGroupCode.Enabled = false;

                this.CheckEditor_SubtotalGoodsMGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = false;

                this.CheckEditor_SubtotalGoodsLGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = false;

                makerIsAble = false;
                sectionIsAble = false;

                switch (this._salesTransListCndtn.TotalType)
                {
                    case SalesTransListCndtn.TotalTypeState.EachGoods:
                        {
                            break;
                        }
                    case SalesTransListCndtn.TotalTypeState.EachCustomer:
                        {
                            this.CheckEditor_SubtotalCustomer.Checked = false;
                            this.CheckEditor_SubtotalCustomer.Enabled = false;

                            break;
                        }
                    case SalesTransListCndtn.TotalTypeState.EachEmployee:
                        {
                            this.CheckEditor_SubtotalEmployee.Checked = false;
                            this.CheckEditor_SubtotalEmployee.Enabled = false;

                            break;
                        }
                    // --- ADD 2009/04/15 ------------------------------->>>>>
                    case SalesTransListCndtn.TotalTypeState.EachSupplier:
                        {
                            this.CheckEditor_SubtotalSupplier.Checked = false;
                            this.CheckEditor_SubtotalSupplier.Enabled = false;

                            break;
                        }
                    // --- ADD 2009/04/15 -------------------------------<<<<<
                }
            }
            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 7) // 明細単位：得意先
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Checked = false;
                this.CheckEditor_SubtotalGroupCode.Enabled = false;

                this.CheckEditor_SubtotalGoodsMGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = false;

                this.CheckEditor_SubtotalGoodsLGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = false;

                makerIsAble = false;

                this.CheckEditor_SubtotalCustomer.Checked = false;
                this.CheckEditor_SubtotalCustomer.Enabled = false;

                sectionIsAble = true;
            }

            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 8) // 明細単位：担当者
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Checked = false;
                this.CheckEditor_SubtotalGroupCode.Enabled = false;

                this.CheckEditor_SubtotalGoodsMGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = false;

                this.CheckEditor_SubtotalGoodsLGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = false;

                makerIsAble = false;

                this.CheckEditor_SubtotalEmployee.Checked = false;
                this.CheckEditor_SubtotalEmployee.Enabled = false;

                sectionIsAble = true;
            }   
            // --- ADD 2009/04/15 ------------------------------->>>>>
            else if ((int)this.tComboEditor_Detail.SelectedItem.DataValue == 9) // 明細単位：仕入先
            {
                this.CheckEditor_SubtotalBl.Checked = false;
                this.CheckEditor_SubtotalBl.Enabled = false;

                this.CheckEditor_SubtotalGroupCode.Checked = false;
                this.CheckEditor_SubtotalGroupCode.Enabled = false;

                this.CheckEditor_SubtotalGoodsMGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsMGroup.Enabled = false;

                this.CheckEditor_SubtotalGoodsLGroup.Checked = false;
                this.CheckEditor_SubtotalGoodsLGroup.Enabled = false;

                makerIsAble = false;

                this.CheckEditor_SubtotalSupplier.Checked = false;
                this.CheckEditor_SubtotalSupplier.Enabled = false;

                sectionIsAble = true;
            }   
            // --- ADD 2009/04/15 -------------------------------<<<<<

            if ((int)this.uos_GroupBySectionDiv.CheckedItem.DataValue == 0) // 集計方法：全社
            {
                sectionIsAble = false;
            }

            if ((int)this.uos_MakerPrintDiv.CheckedItem.DataValue == 0) // メーカー別印刷：しない
            {
                makerIsAble = false;
            }

            if (makerIsAble)
            {
                this.CheckEditor_SubtotalMaker.Enabled = true;
            }
            else
            {
                this.CheckEditor_SubtotalMaker.Checked = false;
                this.CheckEditor_SubtotalMaker.Enabled = false;
            }

            if (sectionIsAble)
            {
                this.CheckEditor_SubtotalSection.Enabled = true;
            }
            else
            {
                this.CheckEditor_SubtotalSection.Checked = false;
                this.CheckEditor_SubtotalSection.Enabled = false;
            }
        }
        #endregion

        #endregion ◆ 印刷前処理

        // ----- ADD 2011/08/16 ---------->>>>>
        #region 名称取得
        /// <summary>
        /// 得意先略称取得処理
        /// </summary>
        /// <param name="customercode">得意先コード</param>
        /// <returns>得意先略称</returns>
        /// <remarks>
        /// <br>Note       : 得意先略称を取得します。</br>
        /// <br>Programmer : wf</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// </remarks>
        private string GetCustomerSNm(string customercode)
        {
            string customersnm = "未登入";
            if (_retlist1 == null)
            {
                _retlist1 = new List<CustomerInfo>();
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                customerInfoAcs.Search(this._enterpriseCode, false, true, out _retlist1);
            }

            foreach (CustomerInfo customerInfo in _retlist1)
            {
                if ((customerInfo.CustomerCode.ToString().TrimEnd().PadLeft(8, '0')).Equals(customercode))
                {
                    customersnm = customerInfo.CustomerSnm.Trim();
                }
            }

            return customersnm;
        }

        /// <summary>
        /// 担当者名取得処理
        /// </summary>
        /// <param name="employeecode">担当者コード</param>
        /// <returns>担当者名</returns>
        /// <remarks>
        /// <br>Note       : 担当者名を取得します。</br>
        /// <br>Programmer : wf</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// </remarks>
        private string GetEmployeeNm(string employeecode)
        {
            string employeenm = "未登入";
            if (_retlist2 == null || _retlist3 == null)
            {
                _retlist2 = new ArrayList();
                _retlist3 = new ArrayList();
                EmployeeAcs employeeAcs = new EmployeeAcs();
                employeeAcs.Search(out _retlist2, out _retlist3, this._enterpriseCode);
            }

            foreach (Employee employee in _retlist2)
            {
                if ((employee.EmployeeCode.TrimEnd().PadLeft(4, '0')).Equals(employeecode))
                {
                    employeenm = employee.Name.Trim();
                }
            }

            return employeenm;
        }

        /// <summary>
        /// 仕入先略称取得処理
        /// </summary>
        /// <param name="suppliercd">仕入先コード</param>
        /// <returns>仕入先略称</returns>
        /// <remarks>
        /// <br>Note       : 仕入先略称を取得します。</br>
        /// <br>Programmer : wf</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// </remarks>
        private string GetSupplierSNm(string suppliercd)
        {
            string suppliersnm = "未登入";
            if (_retlist4 == null)
            {
                _retlist4 = new ArrayList();
                SupplierAcs supplierAcs = new SupplierAcs();
                supplierAcs.Search(out _retlist4, this._enterpriseCode);
            }

            foreach (Supplier supplier in _retlist4)
            {
                if ((supplier.SupplierCd.ToString().Trim().PadLeft(6, '0')).Equals(suppliercd))
                {
                    suppliersnm = supplier.SupplierSnm.Trim();
                }
            }

            return suppliersnm;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="goodsmakercd">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : wf</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// </remarks>
        private string GetGoodsMakerNm(string goodsmakercd)
        {
            string goodsmakernm = "未登入";
            if (_retlist5 == null)
            {
                _retlist5 = new ArrayList();
                MakerAcs makerAcs = new MakerAcs();
                int status = makerAcs.SearchAll(out _retlist5, this._enterpriseCode);
            }

            foreach (MakerUMnt makerUMnt in _retlist5)
            {
                if ((makerUMnt.GoodsMakerCd.ToString().Trim().PadLeft(4, '0')).Equals(goodsmakercd))
                {
                    goodsmakernm = makerUMnt.MakerName.Trim();
                }
            }

            return goodsmakernm;
        }

        /// <summary>
        /// 商品大分類 ガイド名称取得処理
        /// </summary>
        /// <param name="goodslgroup">ガイドコード</param>
        /// <returns>ガイド名称</returns>
        /// <remarks>
        /// <br>Note       : ガイド名称を取得します。</br>
        /// <br>Programmer : wf</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// </remarks>
        private string GetGoodsLGroupNm(string goodslgroup)
        {
            string goodslgroupnm = "未登入";
            if (_retlist9 == null)
            {
                _retlist9 = new ArrayList();
                UserGuideAcs userGuideAcs = new UserGuideAcs();

                int status = userGuideAcs.SearchAllBody(out _retlist9, this._enterpriseCode, UserGuideAcsData.UserBodyData);
            }
            foreach (UserGdBd userGdBd in _retlist9)
            {
                if ((userGdBd.GuideCode.ToString().Trim().PadLeft(4, '0')).Equals(goodslgroup) && userGdBd.UserGuideDivCd == 70)
                {
                    goodslgroupnm = userGdBd.GuideName.Trim();
                }
            }

            return goodslgroupnm;
        }

        /// <summary>
        /// 商品中分類名称取得処理
        /// </summary>
        /// <param name="goodsmgroup">商品中分類コード</param>
        /// <returns>商品中分類名称</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類名称を取得します。</br>
        /// <br>Programmer : wf</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// </remarks>
        private string GetGoodsMGroupNm(string goodsmgroup)
        {
            string goodsmgroupnm = "未登入";
            if (_retlist6 == null)
            {
                _retlist6 = new ArrayList();

                GoodsGroupUAcs goodsGroupUAcs = new GoodsGroupUAcs();
                int status = goodsGroupUAcs.SearchAll(out _retlist6, this._enterpriseCode);
            }

            foreach (GoodsGroupU goodsGroupU in _retlist6)
            {
                if ((goodsGroupU.GoodsMGroup.ToString().Trim().PadLeft(4, '0')).Equals(goodsmgroup))
                {
                    goodsmgroupnm = goodsGroupU.GoodsMGroupName.Trim();
                }
            }

            return goodsmgroupnm;
        }

        /// <summary>
        /// BLグループコードカナ名称取得処理
        /// </summary>
        /// <param name="blgroupcode">BLグループコード</param>
        /// <returns>BLグループコードカナ名称</returns>
        /// <remarks>
        /// <br>Note       : BLグループコードカナ名称を取得します。</br>
        /// <br>Programmer : wf</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// </remarks>
        private string GetBlGroupKanaNm(string blgroupcode)
        {
            string blgroupkananm = "未登入";
            if (_retlist7 == null)
            {
                _retlist7 = new ArrayList();

                BLGroupUAcs blgroupAcs = new BLGroupUAcs();
                int status = blgroupAcs.SearchAll(out _retlist7, this._enterpriseCode);
            }

            foreach (BLGroupU bLGroupU in _retlist7)
            {
                if ((bLGroupU.BLGroupCode.ToString().Trim().PadLeft(5, '0')).Equals(blgroupcode.Trim().PadLeft(5, '0')))
                {
                    blgroupkananm = bLGroupU.BLGroupKanaName.Trim();
                }
            }

            return blgroupkananm;
        }

        /// <summary>
        /// BL商品コード名称（半角取得処理
        /// </summary>
        /// <param name="blgoodscode">BL商品コード</param>
        /// <returns>BL商品コード名称（半角）</returns>
        /// <remarks>
        /// <br>Note       : BL商品コード名称（半角）を取得します。</br>
        /// <br>Programmer : wf</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/16</br>
        /// </remarks>
        private string GetBlGoodsHalfNm(string blgoodscode)
        {
            string blgoodshalfnm = "未登入";
            if (_retlist8 == null)
            {
                _retlist8 = new ArrayList();

                BLGoodsCdAcs blgoodsAcs = new BLGoodsCdAcs();
                int status = blgoodsAcs.SearchAll(out _retlist8, this._enterpriseCode);
            }

            foreach (BLGoodsCdUMnt blGoodsCdUMnt in _retlist8)
            {
                if ((blGoodsCdUMnt.BLGoodsCode.ToString().Trim().PadLeft(5, '0')).Equals(blgoodscode))
                {
                    blgoodshalfnm = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                }
            }

            return blgoodshalfnm;
        }
        #endregion
        // ----- ADD 2011/08/16 ----------<<<<<

        # region ■ エラーメッセージ ■
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2006.03.24</br>
        /// </remarks>
        private void MsgDispProc ( emErrorLevel iLevel, string message, int status )
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
        }
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="procnm">発生メソッドID</param>
        /// <param name="ex">例外情報</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2006.03.24</br>
        /// </remarks>
        private void MsgDispProc ( string message, int status, string procnm, Exception ex )
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                this._printName,					// プログラム名称
                procnm, 							// 処理名称
                "",									// オペレーション
                errMessage,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
        }
        # endregion ■ エラーメッセージ ■

        #endregion ■ Private Method

        # region ■ コントロールイベント ■

        # region ■ フォームイベント ■
        /// <summary>
        /// MAUKK02010UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.11.21</br>
        /// </remarks>
        private void DCTOK02130UA_Load ( object sender, EventArgs e )
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen( out errMsg );
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
                return;
            }

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin( this );		// 画面スキン変更

            // 起動パラメータによる画面表示変更処理
            //SetDisplayControl( this._salesTransListCndtn.TotalType ); // DEL 2008/10/16

            ParentToolbarSettingEvent( this );						// ツールバーボタン設定イベント起動

            // ADD 2009/03/31 不具合対応[12918]～[12920]：スペースキーでの項目選択機能を実装 ---------->>>>>
            #region ラジオボタンのスペースキー制御

            GroupBySectionDivRadioKeyPressHelper.ControlList.Add(this.uos_GroupBySectionDiv);
            GroupBySectionDivRadioKeyPressHelper.StartSpaceKeyControl();

            PrintTypeDivRadioKeyPressHelper.ControlList.Add(this.uos_PrintTypeDiv);
            PrintTypeDivRadioKeyPressHelper.StartSpaceKeyControl();

            PriceUnitDivRadioKeyPressHelper.ControlList.Add(this.uos_PriceUnitDiv);
            PriceUnitDivRadioKeyPressHelper.StartSpaceKeyControl();

            StockOrderDivRadioKeyPressHelper.ControlList.Add(this.uos_StockOrderDiv);
            StockOrderDivRadioKeyPressHelper.StartSpaceKeyControl();

            MakerPrintDivRadioKeyPressHelper.ControlList.Add(this.uos_MakerPrintDiv);
            MakerPrintDivRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();

            #endregion  // ラジオボタンのスペースキー制御
            // ADD 2009/03/31 不具合対応[12918]～[12920]：スペースキーでの項目選択機能を実装 ----------<<<<<
        }
        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary>
        ///// 起動パラメータによる画面表示変更処理
        ///// </summary>
        ///// <param name="TotalTypeState"></param>
        //private void SetDisplayControl ( SalesTransListCndtn.TotalTypeState TotalTypeState )
        //{
        //    # region [パネル表示有無]
        //    switch ( TotalTypeState )
        //    {
        //        // 得意先別
        //        case SalesTransListCndtn.TotalTypeState.EachCustomer:
        //            {
        //                int cndtnPosition = this.pn_CustomerCndtn.Top;

        //                // 得意先
        //                SetCndtnPanelVisible( ref this.pn_CustomerCndtn, true, ref cndtnPosition );
        //                // 担当者
        //                SetCndtnPanelVisible( ref this.pn_EmployeeCndtn, false, ref cndtnPosition );
        //                // 商品条件
        //                SetCndtnPanelVisible( ref this.pn_GoodsInfoCndtn, false, ref cndtnPosition );
        //                // 商品番号
        //                //SetCndtnPanelVisible(ref this.pn_GoodsNoCndtn, false, ref cndtnPosition); // DEL 2008/10/16

        //                // （小計印刷チェックは非表示）
        //                //clb_SumPrintDiv.Items.Clear(); // DEL 2008/10/16
        //                //clb_SumPrintDiv.Visible = false; // DEL 2008/10/16
        //                lb_SumPrintDiv.Visible = false;

        //                // 改ページ区分
        //                uos_NewPageDiv.Items.Clear();
        //                uos_NewPageDiv.Items.Add( 1, "拠点" );
        //                uos_NewPageDiv.Items.Add( 0, "しない" );
        //                uos_NewPageDiv.Value = 1;
        //                this.uos_NewPageDiv.Visible = true;

        //            }
        //            break;
        //        // 担当者別
        //        case SalesTransListCndtn.TotalTypeState.EachEmployee:
        //            {
        //                int cndtnPosition = this.pn_CustomerCndtn.Top;

        //                // 得意先
        //                SetCndtnPanelVisible( ref this.pn_CustomerCndtn, false, ref cndtnPosition );
        //                // 担当者
        //                SetCndtnPanelVisible( ref this.pn_EmployeeCndtn, true, ref cndtnPosition );
        //                // 商品条件
        //                SetCndtnPanelVisible( ref this.pn_GoodsInfoCndtn, false, ref cndtnPosition );
        //                // 商品番号
        //                //SetCndtnPanelVisible( ref this.pn_GoodsNoCndtn, false, ref cndtnPosition ); // DEL 2008/10/16

        //                // （小計印刷チェックは非表示）
        //                //clb_SumPrintDiv.Items.Clear(); // DEL 2008/10/16
        //                //clb_SumPrintDiv.Visible = false; // DEL 2008/10/16
        //                lb_SumPrintDiv.Visible = false;

        //                // 改ページ区分
        //                uos_NewPageDiv.Items.Clear();
        //                uos_NewPageDiv.Items.Add( 1, "拠点" );
        //                uos_NewPageDiv.Items.Add( 0, "しない" );
        //                uos_NewPageDiv.Value = 1;
        //                this.uos_NewPageDiv.Visible = true;

        //            }
        //            break;
        //        // 商品別
        //        case SalesTransListCndtn.TotalTypeState.EachGoods:
        //            {
        //                int cndtnPosition = this.pn_CustomerCndtn.Top;

        //                // 得意先
        //                SetCndtnPanelVisible( ref this.pn_CustomerCndtn, false, ref cndtnPosition );
        //                // 担当者
        //                SetCndtnPanelVisible( ref this.pn_EmployeeCndtn, false, ref cndtnPosition );
        //                // 商品条件
        //                SetCndtnPanelVisible( ref this.pn_GoodsInfoCndtn, true, ref cndtnPosition );
        //                // 商品番号
        //                //SetCndtnPanelVisible( ref this.pn_GoodsNoCndtn, true, ref cndtnPosition ); // DEL 2008/10/16

        //                // 小計印刷チェック
        //                _sumPrintCheckDicKeyList.AddRange( new int[] { (int)SumPrintItem.BLGoodsCode,
        //                                                               (int)SumPrintItem.EnterpriseGanreCode,
        //                                                               (int)SumPrintItem.DGoodsGanre,
        //                                                               (int)SumPrintItem.MGoodsGanre,
        //                                                               (int)SumPrintItem.LGoodsGanre,
        //                                                               (int)SumPrintItem.Maker} );
        //                // --- DEL 2008/10/16 -------------------------------->>>>>
        //                //clb_SumPrintDiv.Items.Clear();
        //                //clb_SumPrintDiv.Items.AddRange( new object[] { _sumPrintCheckDic[(int)SumPrintItem.BLGoodsCode],
        //                //                                               _sumPrintCheckDic[(int)SumPrintItem.EnterpriseGanreCode],
        //                //                                               _sumPrintCheckDic[(int)SumPrintItem.DGoodsGanre],
        //                //                                               _sumPrintCheckDic[(int)SumPrintItem.MGoodsGanre],
        //                //                                               _sumPrintCheckDic[(int)SumPrintItem.LGoodsGanre],
        //                //                                               _sumPrintCheckDic[(int)SumPrintItem.Maker] } );
        //                //clb_SumPrintDiv.Height = 40;
        //                //// (全てチェック)
        //                //for ( int index = 0; index < clb_SumPrintDiv.Items.Count; index++ )
        //                //{
        //                //    clb_SumPrintDiv.SetItemChecked( index, true );
        //                //}
        //                //this.clb_SumPrintDiv.Visible = true;
        //                // --- DEL 2008/10/16 --------------------------------<<<<<

        //                // 改ページ区分
        //                uos_NewPageDiv.Items.Clear();
        //                uos_NewPageDiv.Items.Add( 1, "拠点" );
        //                uos_NewPageDiv.Items.Add( 2, "メーカー" );
        //                uos_NewPageDiv.Items.Add( 0, "しない" );
        //                uos_NewPageDiv.Value = 1;
        //                this.uos_NewPageDiv.Visible = true;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
            
        //    # endregion

        //    # region [ガイド後次項目ディクショナリ]

        //    // コントロールのリスト（フォーカス順）
        //    List<Control> controls = new List<Control>();

        //    // 得意先パネル
        //    if ( pn_CustomerCndtn.Visible )
        //    {
        //        controls.Add( tNedit_CustomerCode_St );
        //        controls.Add( tNedit_CustomerCode_Ed );
        //    }
        //    // 担当者パネル
        //    if ( pn_EmployeeCndtn.Visible )
        //    {
        //        controls.Add( tEdit_EmployeeCode_St );
        //        controls.Add( tEdit_EmployeeCode_Ed );
        //    }
        //    // メーカー・商品区分・ＢＬコードパネル
        //    if ( pn_GoodsInfoCndtn.Visible )
        //    {
        //        controls.Add( tNedit_GoodsMakerCd_St );
        //        controls.Add( tNedit_GoodsMakerCd_Ed );
        //        controls.Add( tNedit_GoodsLGroup_St );
        //        controls.Add( tNedit_GoodsLGroup_Ed );
        //        controls.Add( tNedit_GoodsMGroup_St );
        //        controls.Add( tNedit_GoodsMGroup_Ed );
        //        controls.Add( tNedit_BLGloupCode_St );
        //        controls.Add( tNedit_BLGloupCode_Ed );
        //        //controls.Add( tne_St_EnterpriseGanreCode ); // DEL 2008/10/16
        //        //controls.Add( tne_Ed_EnterpriseGanreCode ); // DEL 2008/10/16
        //        controls.Add( tNedit_BLGoodsCode_St );
        //        controls.Add( tNedit_BLGoodsCode_Ed );
        //    }
        //    // --- DEL 2008/10/16 -------------------------------->>>>>
        //    // 商品番号パネル
        //    //if ( pn_GoodsNoCndtn.Visible )
        //    //{
        //    //    controls.Add( tEdit_GoodsNo_St );
        //    //    controls.Add( tEdit_GoodsNo_Ed );
        //    //}
        //    // --- DEL 2008/10/16 --------------------------------<<<<<
        //    // 最終項目は最後に2重に格納する
        //    controls.Add( controls[controls.Count - 1] );

        //    // リストからディクショナリ生成
        //    _nextControl = new Dictionary<Control, Control>();
        //    for ( int index = 0; index < controls.Count-1; index++ )
        //    {
        //        _nextControl.Add( controls[index], controls[index + 1] );
        //    }

        //    # endregion
        //}
        // --- DEL 2008/10/16 --------------------------------<<<<<

        /// <summary>
        /// 抽出条件パネル表示有無制御
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="visible"></param>
        /// <param name="position"></param>
        private void SetCndtnPanelVisible ( ref Panel panel, bool visible, ref int position )
        {
            if ( visible )
            {
                panel.Visible = true;
                panel.Top = position;
                position = panel.Bottom;
            }
            else
            {
                panel.Visible = false;
            }
        }
        # endregion ■ フォームイベント ■

        # region ■ コントロール脱出イベント ■
        /// <summary>
        /// 数値項目開始脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( (TNedit)sender ).DataText == string.Empty )
            //{
            //    ( (TNedit)sender ).SetInt( 0 );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// 数値項目終了脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( (TNedit)sender ).DataText == string.Empty )
            //{
            //    string maxValueText = new string( '9', ( (TNedit)sender ).ExtEdit.Column );
            //    ( (TNedit)sender ).SetInt( Int32.Parse( maxValueText ) );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        # endregion ■ コントロール脱出イベント ■

        # region ■ ガイドボタンクリックイベント ■
        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_CustomerGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //_customerGuideOK = false;

            //// 押下されたボタンを退避
            //if ( sender is UltraButton )
            //{
            //    _customerGuideSender = (UltraButton)sender;
            //}

            //this._customerGuid = new SFTOK01370UA( SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY );
            //this._customerGuid.CustomerSelect += new CustomerSelectEventHandler( customerSearchForm_CustomerSelect );
            //this._customerGuid.ShowDialog( this );

            //if ( _customerGuideOK )
            //{
            //    if ( sender == ub_St_CustomerGuide )
            //    {
            //        _nextControl[tNedit_CustomerCode_St].Focus();
            //    }
            //    else
            //    {
            //        _nextControl[tNedit_CustomerCode_Ed].Focus();
            //    }
            //}
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            _customerGuideOK = false;

            // 押下されたボタンを退避
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                if (sender == ub_St_CustomerGuide)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.tNedit_GoodsMakerCd_St.Focus();
                }
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
        }
        /// <summary>
        /// 得意先ガイド選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        void customerSearchForm_CustomerSelect ( object sender, CustomerSearchRet customerSearchRet )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( customerSearchRet == null ) return;

            //if ( _customerGuideSender == this.ub_St_CustomerGuide )
            //{
            //    this.tNedit_CustomerCode_St.SetInt( customerSearchRet.CustomerCode );
            //}
            //else
            //{
            //    this.tNedit_CustomerCode_Ed.SetInt( customerSearchRet.CustomerCode );
            //}
            //_customerGuideOK = true;
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.ub_St_CustomerGuide)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                this.tEdit_CustomerCode_St_Nm.DataText = customerInfo.CustomerSnm.Trim();//  ADD 2011/08/16
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                this.tEdit_CustomerCode_Ed_Nm.DataText = customerInfo.CustomerSnm.Trim();//  ADD 2011/08/16
            }

            _customerGuideOK = true;
            // --- ADD 2008/10/16 --------------------------------<<<<<
        }
        // --- ADD 2009/04/15 -------------------------------->>>>>
        /// <summary>
        /// 仕入先ガイドクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_SupplierGuide_Click(object sender, EventArgs e)
        {
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }

            // 仕入先ガイド起動
            Supplier supplier;

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                this.tEdit_SupplierCd_St_Nm.DataText = supplier.SupplierSnm.Trim();//  ADD 2011/08/16
                this.tNedit_SupplierCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                this.tEdit_SupplierCd_Ed_Nm.DataText = supplier.SupplierSnm.Trim();//  ADD 2011/08/16
                this.tNedit_GoodsMakerCd_St.Focus();
            }
            else
            {
                return;
            }
        }
        // --- ADD 2009/04/15 --------------------------------<<<<<

        /// <summary>
        /// 担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_EmployeeGuide_Click ( object sender, EventArgs e )
        {
            if ( this._employeeAcs == null )
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid( this._enterpriseCode, true, out employee );

            if ( status == 0 )
            {
                if ( sender == this.ub_St_EmployeeGuide )
                {
                    this.tEdit_EmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_EmployeeCode_St_Nm.Text = employee.Name.TrimEnd();//  ADD 2011/08/16
                    //_nextControl[tEdit_EmployeeCode_St].Focus();// DEL 2008/10/16
                    //this.tNedit_GoodsMakerCd_St.Focus(); // ADD 2008/10/16  // DEL2008/10/31 不具合対応[7304]
                    this.tEdit_EmployeeCode_Ed.Focus(); // ADD 2008/10/31 不具合対応[7304]
                }
                else
                {
                    this.tEdit_EmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.tEdit_EmployeeCode_Ed_Nm.Text = employee.Name.TrimEnd();//  ADD 2011/08/16
                    //_nextControl[tEdit_EmployeeCode_Ed].Focus(); // DEL 2008/10/16
                    this.tNedit_GoodsMakerCd_St.Focus(); // ADD 2008/10/16
                }
            }
        }
        /// <summary>
        /// メーカーガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerCdGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( this._goodsAcs == null )
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            //}

            //MakerUMnt maker;
            //int status = this._goodsAcs.ExecuteMakerGuid( this._enterpriseCode, out maker );
            //if ( status != 0 ) return;

            //TNedit targetControl;
            //if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tNedit_GoodsMakerCd_St;
            //else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tNedit_GoodsMakerCd_Ed;
            //else return;

            //targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();
            //_nextControl[targetControl].Focus();
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            MakerUMnt makerUMnt;
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_GoodsMakerCd_St_Nm.DataText = makerUMnt.MakerName.Trim();//  ADD 2011/08/16
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_GoodsMakerCd_Ed_Nm.DataText = makerUMnt.MakerName.Trim();//  ADD 2011/08/16
                this.tNedit_GoodsLGroup_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
        }
        /// <summary>
        /// 商品大分類ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_LargeGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( this._goodsAcs == null )
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            //}

            //LGoodsGanre lGoodsGanre;
            //int status = this._goodsAcs.ExecuteLGoodsGanreGuid( this._enterpriseCode, out lGoodsGanre );
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tNedit_GoodsLGroup_St;
            //else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tNedit_GoodsLGroup_Ed;
            //else return;

            //targetControl.DataText = lGoodsGanre.LargeGoodsGanreCode.ToString().TrimEnd();
            //_nextControl[targetControl].Focus();
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            UserGdBd userGdBd;
            UserGdHd userGdHd;

            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsLGroup_St.SetInt(userGdBd.GuideCode);
                this.tEdit_GoodsLGroup_St_Nm.DataText = userGdBd.GuideName.Trim();//  ADD 2011/08/16
                this.tNedit_GoodsLGroup_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);
                this.tEdit_GoodsLGroup_Ed_Nm.DataText = userGdBd.GuideName.Trim();//  ADD 2011/08/16
                this.tNedit_GoodsMGroup_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
        }
        /// <summary>
        /// 商品中分類ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( this._goodsAcs == null )
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            //}

            //MGoodsGanre mGoodsGanre;
            //int status = this._goodsAcs.ExecuteMGoodsGanreGuid( this._enterpriseCode, string.Empty, out mGoodsGanre );
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tNedit_GoodsMGroup_St;
            //else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tNedit_GoodsMGroup_Ed;
            //else return;

            //targetControl.DataText = mGoodsGanre.MediumGoodsGanreCode.ToString().TrimEnd();
            //_nextControl[targetControl].Focus();
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // 商品中分類ガイド起動
            GoodsGroupU goodgroupU;

            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodgroupU, true);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GoodsMGroup_St.SetInt(goodgroupU.GoodsMGroup);
                this.tEdit_GoodsMGroup_St_Nm.DataText = goodgroupU.GoodsMGroupName.Trim();//  ADD 2011/08/16
                this.tNedit_GoodsMGroup_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);
                this.tEdit_GoodsMGroup_Ed_Nm.DataText = goodgroupU.GoodsMGroupName.Trim();//  ADD 2011/08/16
                this.tNedit_BLGloupCode_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
        }
        /// <summary>
        /// グループコードガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
        /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
        /// </remarks>
        private void ub_St_DetailGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( this._goodsAcs == null )
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            //}

            //DGoodsGanre dGoodsGanre;
            //int status = this._goodsAcs.ExecuteDGoodsGanreGuid( this._enterpriseCode, out dGoodsGanre );
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tNedit_BLGloupCode_St;
            //else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tNedit_BLGloupCode_Ed;
            //else return;

            //targetControl.DataText = dGoodsGanre.DetailGoodsGanreCode.ToString().TrimEnd();
            //_nextControl[targetControl].Focus();
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            // BLグループガイド起動
            BLGroupU blGroupU;

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGloupCode_St.SetInt(blGroupU.BLGroupCode);
                this.tEdit_BLGloupCode_St_Nm.DataText = this.GetBlGroupKanaNm(blGroupU.BLGroupCode.ToString());//ADD 2011/08/16
                this.tNedit_BLGloupCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                //this.tEdit_BLGloupCode_St_Nm.DataText = this.GetBlGroupKanaNm(blGroupU.BLGroupCode.ToString());//ADD 2011/08/16 //DEL 2011/09/09
                this.tEdit_BLGloupCode_Ed_Nm.DataText = this.GetBlGroupKanaNm(blGroupU.BLGroupCode.ToString());//ADD 2011/09/09
                this.tNedit_BLGoodsCode_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
        }
        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary>
        ///// 自社分類ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_EnterpriseGanreCodeGuide_Click( object sender, EventArgs e )
        //{
        //    if ( this._searchStockAcs == null )
        //    {
        //        this._searchStockAcs = new SearchStockAcs();
        //    }

        //    UserGdBd userGdBd;
        //    int status = this._searchStockAcs.ExecuteUserGuideGuid( this._enterpriseCode, out userGdBd );
        //    if ( status != 0 ) return;

        //    TNedit targetControl;
        //    if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0) targetControl = this.tne_St_EnterpriseGanreCode;
        //    else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0) targetControl = this.tne_Ed_EnterpriseGanreCode;
        //    else return;

        //    targetControl.SetInt( userGdBd.GuideCode );
        //    _nextControl[targetControl].Focus();
        //}
        // --- DEL 2008/10/16 --------------------------------<<<<<
        /// <summary>
        /// ＢＬコードガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( this._goodsAcs == null )
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            //}

            //BLGoodsCdUMnt blGoodsCdUMnt;
            //int status = this._goodsAcs.ExecuteBLGoodsCd( out blGoodsCdUMnt );
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tNedit_BLGoodsCode_St;
            //else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tNedit_BLGoodsCode_Ed;
            //else return;

            //targetControl.DataText = blGoodsCdUMnt.BLGoodsCode.ToString().TrimEnd();
            //_nextControl[targetControl].Focus();
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLGoodsCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tEdit_BLGoodsCode_St_Nm.DataText = bLGoodsCdUMnt.BLGoodsHalfName.Trim();//  ADD 2011/08/16
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tEdit_BLGoodsCode_Ed_Nm.DataText = bLGoodsCdUMnt.BLGoodsHalfName.Trim();//  ADD 2011/08/16
                this.tEdit_GoodsNo_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
        }
        /// <summary>
        /// 商品ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsNoGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //if ( this._goodsGuid == null )
            //{
            //    this._goodsGuid = new MAKHN04110UA();
            //}

            //GoodsUnitData goods;
            //DialogResult result = this._goodsGuid.ShowGuide( this, this._enterpriseCode, out goods );

            //if ( result != DialogResult.OK ) return;

            //TEdit targetControl;
            //if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tEdit_GoodsNo_St;
            //else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tEdit_GoodsNo_Ed;
            //else return;

            //targetControl.DataText = goods.GoodsNo;
            //_nextControl[targetControl].Focus();
            // --- DEL 2008/10/16 --------------------------------<<<<<
        }

        # endregion ■ ガイドボタンクリックイベント ■

        # region ■ グループ圧縮・展開イベント ■

        /// <summary>
        /// グループ圧縮イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ展開イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }

        # endregion ■ グループ圧縮・展開イベント ■

        #region ■ UI保存 書込・読込イベント ■
        /// <summary>
        /// UI保存コンポーネント書込みイベント
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/10/16</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            //customizeData = new string[8]; // DEL 2009/02/12
            customizeData = new string[11]; // ADD 2009/02/12

            if (this.CheckEditor_SubtotalSection.Checked) customizeData[0] = "1";
            else customizeData[0] = "0";

            if (this.CheckEditor_SubtotalMaker.Checked) customizeData[1] = "1";
            else customizeData[1] = "0";

            if (this.CheckEditor_SubtotalGoodsLGroup.Checked) customizeData[2] = "1";
            else customizeData[2] = "0";

            if (this.CheckEditor_SubtotalGoodsMGroup.Checked) customizeData[3] = "1";
            else customizeData[3] = "0";

            if (this.CheckEditor_SubtotalGroupCode.Checked) customizeData[4] = "1";
            else customizeData[4] = "0";

            if (this.CheckEditor_SubtotalBl.Checked) customizeData[5] = "1";
            else customizeData[5] = "0";

            if (this.CheckEditor_SubtotalEmployee.Checked) customizeData[6] = "1";
            else customizeData[6] = "0";

            if (this.CheckEditor_SubtotalCustomer.Checked) customizeData[7] = "1";
            else customizeData[7] = "0";

            if (this.CheckEditor_SubtotalSupplier.Checked) customizeData[10] = "1";  // ADD 2009/04/15
            else customizeData[10] = "0";  // ADD 2009/04/15

            // --- ADD 2009/02/12 -------------------------------->>>>>
            // 印刷範囲が0か未入力を分ける
            if (this.tne_St_ShipmentCnt.Text == string.Empty)
            {
                customizeData[8] = string.Empty;
            }
            else
            {
                customizeData[8] = this.tne_St_ShipmentCnt.GetInt().ToString();
            }

            if (this.tne_Ed_ShipmentCnt.Text == string.Empty)
            {
                customizeData[9] = string.Empty;
            }
            else
            {
                customizeData[9] = this.tne_Ed_ShipmentCnt.GetInt().ToString();
            }
            // --- ADD 2009/02/12 --------------------------------<<<<<
        }

        /// <summary>
        /// UI保存コンポーネント読込みイベント
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                if (customizeData[0] == "1") this.CheckEditor_SubtotalSection.Checked = true;
                else this.CheckEditor_SubtotalSection.Checked = false;

                if (customizeData[1] == "1") this.CheckEditor_SubtotalMaker.Checked = true;
                else this.CheckEditor_SubtotalMaker.Checked = false;

                if (customizeData[2] == "1") this.CheckEditor_SubtotalGoodsLGroup.Checked = true;
                else this.CheckEditor_SubtotalGoodsLGroup.Checked = false;

                if (customizeData[3] == "1") this.CheckEditor_SubtotalGoodsMGroup.Checked = true;
                else this.CheckEditor_SubtotalGoodsMGroup.Checked = false;

                if (customizeData[4] == "1") this.CheckEditor_SubtotalGroupCode.Checked = true;
                else this.CheckEditor_SubtotalGroupCode.Checked = false;

                if (customizeData[5] == "1") this.CheckEditor_SubtotalBl.Checked = true;
                else this.CheckEditor_SubtotalBl.Checked = false;

                if (customizeData[6] == "1") this.CheckEditor_SubtotalEmployee.Checked = true;
                else this.CheckEditor_SubtotalEmployee.Checked = false;

                if (customizeData[7] == "1") this.CheckEditor_SubtotalCustomer.Checked = true;
                else this.CheckEditor_SubtotalCustomer.Checked = false;

                if (customizeData[10] == "1") this.CheckEditor_SubtotalSupplier.Checked = true;  // ADD 2009/04/15
                else this.CheckEditor_SubtotalSupplier.Checked = false;  // ADD 2009/04/15

                // --- ADD 2009/02/10 -------------------------------->>>>>
                if (customizeData[8] == string.Empty) this.tne_St_ShipmentCnt.Text = string.Empty;
                else this.tne_St_ShipmentCnt.SetInt(Convert.ToInt32(customizeData[8]));

                if (customizeData[9] == string.Empty) this.tne_Ed_ShipmentCnt.Text = string.Empty;
                else this.tne_Ed_ShipmentCnt.SetInt(Convert.ToInt32(customizeData[9]));
                // --- ADD 2009/02/10 --------------------------------<<<<<
            }
        }

        #endregion

        // --- DEL 2009/02/10 -------------------------------->>>>>
        ///// <summary>
        ///// 数量脱出イベント処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tne_St_ShipmentCnt_Leave( object sender, EventArgs e )
        //{
        //    if ( (sender as TNedit).GetInt() == 0 )
        //    {
        //        (sender as TNedit).Text = "0";
        //    }

        //    // カンマ対応の為再セット
        //    (sender as TNedit).SetInt( (sender as TNedit).GetInt() );
        //}
        // --- DEL 2009/02/10 --------------------------------<<<<<

        // --- ADD 2008/10/16 -------------------------------->>>>>
        #region ■ リターンキー押下イベント ■
        /// <summary>
        /// リターンキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note : 2014/12/16 劉超</br>
        /// <br>管理番号    : 11070263-00</br>
        /// <br>            : 明治産業様Seiken品番変更</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // DEL 2008/10/30 不具合対応[7203] ---------->>>>>
            //if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
            //{
            //    if (this.tNedit_CustomerCode_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_CustomerCode_Ed.ExtEdit.Column))))
            //    {
            //        this.tNedit_CustomerCode_Ed.SetInt(0);
            //    }
            //}
            //else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
            //{
            //    if (this.tEdit_EmployeeCode_Ed.Text == "9999")
            //    {
            //        this.tEdit_EmployeeCode_Ed.Text = "";
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //{
            //    if (this.tNedit_GoodsMakerCd_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_GoodsMakerCd_Ed.ExtEdit.Column))))
            //    {
            //        this.tNedit_GoodsMakerCd_Ed.SetInt(0);
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
            //{
            //    if (this.tNedit_GoodsLGroup_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_GoodsLGroup_Ed.ExtEdit.Column))))
            //    {
            //        this.tNedit_GoodsLGroup_Ed.SetInt(0);
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
            //{
            //    if (this.tNedit_GoodsMGroup_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_GoodsMGroup_Ed.ExtEdit.Column))))
            //    {
            //        this.tNedit_GoodsMGroup_Ed.SetInt(0);
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
            //{
            //    if (this.tNedit_BLGloupCode_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_BLGloupCode_Ed.ExtEdit.Column))))
            //    {
            //        this.tNedit_BLGloupCode_Ed.SetInt(0);
            //    }
            //}
            //else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            //{
            //    if (this.tNedit_BLGoodsCode_Ed.GetInt() == Int32.Parse(new string('9', (tNedit_BLGoodsCode_Ed.ExtEdit.Column))))
            //    {
            //        this.tNedit_BLGoodsCode_Ed.SetInt(0);
            //    }
            //}
            //else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
            //{
            //    if (this.tEdit_GoodsNo_Ed.Text == "999999999999999999999999")
            //    {
            //        this.tEdit_GoodsNo_Ed.Text = "";
            //    }
            //}
            // DEL 2008/10/30 不具合対応[7203] ----------<<<<<
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            if (this._salesTransListCndtn.TotalType == SalesTransListCndtn.TotalTypeState.EachGoods 
                && e.PrevCtrl == this.CheckEditor_SubtotalGoodsMGroup)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.CheckEditor_SubtotalBl;
                }
            }

            if (this._salesTransListCndtn.TotalType == SalesTransListCndtn.TotalTypeState.EachGoods
                && e.PrevCtrl == this.tComboEditor_GoodsNoTtlDiv)
            {
                if (e.Key == Keys.Right && this.tComboEditor_GoodsNoShowDiv.Enabled == false)
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                }
                else if (e.Key == Keys.Right && this.tComboEditor_GoodsNoShowDiv.Enabled == true)
                {
                    e.NextCtrl = this.tComboEditor_GoodsNoShowDiv;
                }
                else
                {
                    //なし
                }
            }

            if (this._salesTransListCndtn.TotalType == SalesTransListCndtn.TotalTypeState.EachGoods
                && e.PrevCtrl == this.tComboEditor_GoodsNoShowDiv)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tComboEditor_Detail;
                }
            }
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

            // ----- ADD 2011/08/16 ---------->>>>>
            //得意先
            if (e.PrevCtrl == this.tNedit_CustomerCode_St)
            {
                string customercode = this.tNedit_CustomerCode_St.DataText;
                if (!string.IsNullOrEmpty(customercode))
                    this.tEdit_CustomerCode_St_Nm.DataText = GetCustomerSNm(customercode);
                else
                    this.tEdit_CustomerCode_St_Nm.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
            {
                string customercode = this.tNedit_CustomerCode_Ed.DataText;
                if (!string.IsNullOrEmpty(customercode))
                    this.tEdit_CustomerCode_Ed_Nm.DataText = GetCustomerSNm(customercode);
                else
                    this.tEdit_CustomerCode_Ed_Nm.DataText = "";
            }
            //担当者
            if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
            {
                string employeecode = this.tEdit_EmployeeCode_St.DataText;
                if (!string.IsNullOrEmpty(employeecode))
                    this.tEdit_EmployeeCode_St_Nm.DataText = GetEmployeeNm(employeecode);
                else
                    this.tEdit_EmployeeCode_St_Nm.DataText = "";
            }

            if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
            {
                string employeecode = this.tEdit_EmployeeCode_Ed.DataText;
                if (!string.IsNullOrEmpty(employeecode))
                    this.tEdit_EmployeeCode_Ed_Nm.DataText = GetEmployeeNm(employeecode);
                else
                    this.tEdit_EmployeeCode_Ed_Nm.DataText = "";
            }
            //仕入先
            if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                string suppliercd = this.tNedit_SupplierCd_St.DataText;
                if (!string.IsNullOrEmpty(suppliercd))
                    this.tEdit_SupplierCd_St_Nm.DataText = GetSupplierSNm(suppliercd);
                else
                    this.tEdit_SupplierCd_St_Nm.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                string suppliercd = this.tNedit_SupplierCd_Ed.DataText;
                if (!string.IsNullOrEmpty(suppliercd))
                    this.tEdit_SupplierCd_Ed_Nm.DataText = GetSupplierSNm(suppliercd);
                else
                    this.tEdit_SupplierCd_Ed_Nm.DataText = "";
            }
            //メーカー
            if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            {
                string goodsmakercd = this.tNedit_GoodsMakerCd_St.DataText;
                if (!string.IsNullOrEmpty(goodsmakercd))
                    this.tEdit_GoodsMakerCd_St_Nm.DataText = GetGoodsMakerNm(goodsmakercd);
                else
                    this.tEdit_GoodsMakerCd_St_Nm.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                string goodsmakercd = this.tNedit_GoodsMakerCd_Ed.DataText;
                if (!string.IsNullOrEmpty(goodsmakercd))
                    this.tEdit_GoodsMakerCd_Ed_Nm.DataText = GetGoodsMakerNm(goodsmakercd);
                else
                    this.tEdit_GoodsMakerCd_Ed_Nm.DataText = "";
            }
            //商品大分類
            if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
            {
                string goodslgroup = this.tNedit_GoodsLGroup_St.DataText;
                if (!string.IsNullOrEmpty(goodslgroup))
                    this.tEdit_GoodsLGroup_St_Nm.DataText = GetGoodsLGroupNm(goodslgroup);
                else
                    this.tEdit_GoodsLGroup_St_Nm.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
            {

                string goodslgroup = this.tNedit_GoodsLGroup_Ed.DataText;
                if (!string.IsNullOrEmpty(goodslgroup))
                    this.tEdit_GoodsLGroup_Ed_Nm.DataText = GetGoodsLGroupNm(goodslgroup);
                else
                    this.tEdit_GoodsLGroup_Ed_Nm.DataText = "";
            }
            //商品中分類
            if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
            {
                string goodsmgroup = this.tNedit_GoodsMGroup_St.DataText;
                if (!string.IsNullOrEmpty(goodsmgroup))
                    this.tEdit_GoodsMGroup_St_Nm.DataText = GetGoodsMGroupNm(goodsmgroup);
                else
                    this.tEdit_GoodsMGroup_St_Nm.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
            {
                string goodsmgroup = this.tNedit_GoodsMGroup_Ed.DataText;
                if (!string.IsNullOrEmpty(goodsmgroup))
                    this.tEdit_GoodsMGroup_Ed_Nm.DataText = GetGoodsMGroupNm(goodsmgroup);
                else
                    this.tEdit_GoodsMGroup_Ed_Nm.DataText = "";
            }
            //グループコード
            if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
            {
                string blgroupcode = this.tNedit_BLGloupCode_St.DataText;
                if (!string.IsNullOrEmpty(blgroupcode))
                    this.tEdit_BLGloupCode_St_Nm.DataText = GetBlGroupKanaNm(blgroupcode);
                else
                    this.tEdit_BLGloupCode_St_Nm.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
            {
                string blgroupcode = this.tNedit_BLGloupCode_Ed.DataText;
                if (!string.IsNullOrEmpty(blgroupcode))
                    this.tEdit_BLGloupCode_Ed_Nm.DataText = GetBlGroupKanaNm(blgroupcode);
                else
                    this.tEdit_BLGloupCode_Ed_Nm.DataText = "";
            }
            //BLコード
            if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
            {
                string blgoodscode = this.tNedit_BLGoodsCode_St.DataText;
                if (!string.IsNullOrEmpty(blgoodscode))
                    this.tEdit_BLGoodsCode_St_Nm.DataText = GetBlGoodsHalfNm(blgoodscode);
                else
                    this.tEdit_BLGoodsCode_St_Nm.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            {
                string blgoodscode = this.tNedit_BLGoodsCode_Ed.DataText;
                if (!string.IsNullOrEmpty(blgoodscode))
                    this.tEdit_BLGoodsCode_Ed_Nm.DataText = GetBlGoodsHalfNm(blgoodscode);
                else
                    this.tEdit_BLGoodsCode_Ed_Nm.DataText = "";
            }
            // ----- ADD 2011/08/16 ----------<<<<<

        }
        // --- ADD 2008/10/16 --------------------------------<<<<<
        #endregion

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary>
        /// 集計方法ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_GroupBySectionDiv_ValueChanged(object sender, EventArgs e)
        {
            // 小計
            this.SubTotalSetting();

            // --- ADD 2008/12/09 -------------------------------->>>>>
            // 改頁
            // 選択値を保存
            object tmpObj;
            
            if (this.uos_NewPageDiv.CheckedItem != null)
            {
                tmpObj = this.uos_NewPageDiv.CheckedItem.DataValue;
            }
            else
            {
                tmpObj = 0;
            }

            Infragistics.Win.ValueList valueList1 = this.GetNewPageDivValueList();

            this.uos_NewPageDiv.ResetValueList();

            for (int i = 0; i < valueList1.ValueListItems.Count; i++)
            {
                Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                vlltem.Tag = valueList1.ValueListItems[i].Tag;
                vlltem.DataValue = valueList1.ValueListItems[i].DataValue;
                vlltem.DisplayText = valueList1.ValueListItems[i].DisplayText;
                this.uos_NewPageDiv.Items.Add(vlltem);
            }

            this.uos_NewPageDiv.Value = tmpObj;

            if (this.uos_NewPageDiv.CheckedItem == null)
            {
                this.uos_NewPageDiv.CheckedIndex = 0;
            }
            // --- ADD 2008/12/09 --------------------------------<<<<<
            // --- ADD 2008/12/11 -------------------------------->>>>>
            if (this.uos_NewPageDiv.Items.Count == 1)
            {
                // 選択肢が一つしかない場合は選択不可
                this.uos_NewPageDiv.Enabled = false;
            }
            else
            {
                this.uos_NewPageDiv.Enabled = true;
            }
            // --- ADD 2008/12/11 --------------------------------<<<<<
        }

        /// <summary>
        /// メーカー別印刷ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_MakerPrint_ValueChanged(object sender, EventArgs e)
        {
            // 小計
            this.SubTotalSetting();
        }

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>
        /// 品番集計区分SelectionChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GoodsNoTtlDiv_SelectionChanged(object sender, EventArgs e)
        {
            // 品番集計区分が「合算」時
            if ((int)tComboEditor_GoodsNoTtlDiv.SelectedItem.DataValue == 1)
            {
                this.tComboEditor_GoodsNoShowDiv.Enabled = true;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
            }
            else
            {
                this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
            }
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        /// <summary>
        /// 明細単位SelectionChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2014/12/16 劉超</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        /// <br>Update Note: 2015/04/22 時シン</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : Redmine#45436の#80　明細単位：品番或いはメーカーの時、「メーカー別印刷」を操作不可とする対応</br>
        /// </remarks>
        private void tComboEditor_Detail_SelectionChanged(object sender, EventArgs e)
        {
            // メーカー別印刷
            if ((int)tComboEditor_Detail.SelectedItem.DataValue == 6
                || (int)tComboEditor_Detail.SelectedItem.DataValue == 7
                || (int)tComboEditor_Detail.SelectedItem.DataValue == 8
                || (int)tComboEditor_Detail.SelectedItem.DataValue == 9) // 拠点、得意先、担当者、仕入先
            {
                this.uos_MakerPrintDiv.Value = 0; // しない
                this.uos_MakerPrintDiv.Enabled = false;
                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                this.tComboEditor_GoodsNoTtlDiv.Enabled = false;
                this.tComboEditor_GoodsNoTtlDiv.Value = 0;
                this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            }
            //------ DEL START 2015/04/22 時シン FOR Redmine#45436の#80　明細単位：品番或いはメーカーの時、「メーカー別印刷」を操作不可とする対応 ------>>>>>
            //else if ((int)tComboEditor_Detail.SelectedItem.DataValue == 0
            //    || (int)tComboEditor_Detail.SelectedItem.DataValue == 5) // メーカー、品番
            //{
            //    this.uos_MakerPrintDiv.Value = 1; // する
            //    this.uos_MakerPrintDiv.Enabled = false;
            //}
            //------ DEL END 2015/04/22 時シン FOR Redmine#45436の#80　明細単位：品番或いはメーカーの時、「メーカー別印刷」を操作不可とする対応 ------<<<<<
            //------ ADD START 2015/04/22 時シン FOR Redmine#45436の#80　明細単位：品番或いはメーカーの時、「メーカー別印刷」を操作不可とする対応 ------>>>>>
            else if ((int)tComboEditor_Detail.SelectedItem.DataValue == 5) // メーカー
            {
                this.uos_MakerPrintDiv.Value = 1; // する
                this.uos_MakerPrintDiv.Enabled = false;
                this.tComboEditor_GoodsNoTtlDiv.Enabled = false;
                this.tComboEditor_GoodsNoTtlDiv.Value = 0;
                this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
            }
            //------ ADD END 2015/04/22 時シン FOR Redmine#45436の#80　明細単位：品番或いはメーカーの時、「メーカー別印刷」を操作不可とする対応 ------<<<<<
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            else if ((int)tComboEditor_Detail.SelectedItem.DataValue == 0) // 品番
            {
                this.tComboEditor_GoodsNoTtlDiv.Enabled = true;
                this.tComboEditor_GoodsNoTtlDiv.Value = 0;
                this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
                //------ ADD START 2015/04/22 時シン FOR Redmine#45436の#80　明細単位：品番或いはメーカーの時、「メーカー別印刷」を操作不可とする対応 ------>>>>>
                this.uos_MakerPrintDiv.Value = 1; // する
                this.uos_MakerPrintDiv.Enabled = false;
                //------ ADD END 2015/04/22 時シン FOR Redmine#45436の#80　明細単位：品番或いはメーカーの時、「メーカー別印刷」を操作不可とする対応 ------<<<<<
            }
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            else
            {
                this.uos_MakerPrintDiv.Enabled = true;
                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                this.tComboEditor_GoodsNoTtlDiv.Enabled = false;
                this.tComboEditor_GoodsNoTtlDiv.Value = 0;
                this.tComboEditor_GoodsNoShowDiv.Enabled = false;
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            }

            // 小計
            this.SubTotalSetting();

            // --- ADD 2008/12/09 -------------------------------->>>>>
            // 改頁
            // 選択値を保存
            object tmpObj;

            if (this.uos_NewPageDiv.CheckedItem != null)
            {
                tmpObj = this.uos_NewPageDiv.CheckedItem.DataValue;
            }
            else
            {
                tmpObj = 0;
            }

            Infragistics.Win.ValueList valueList1 = this.GetNewPageDivValueList();

            this.uos_NewPageDiv.ResetValueList();

            for (int i = 0; i < valueList1.ValueListItems.Count; i++)
            {
                Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                vlltem.Tag = valueList1.ValueListItems[i].Tag;
                vlltem.DataValue = valueList1.ValueListItems[i].DataValue;
                vlltem.DisplayText = valueList1.ValueListItems[i].DisplayText;
                this.uos_NewPageDiv.Items.Add(vlltem);
            }

            this.uos_NewPageDiv.Value = tmpObj;

            if (this.uos_NewPageDiv.CheckedItem == null)
            {
                this.uos_NewPageDiv.CheckedIndex = 0;
            }
            // --- ADD 2008/12/09 --------------------------------<<<<<
            // --- ADD 2008/12/11 -------------------------------->>>>>
            if (this.uos_NewPageDiv.Items.Count == 1)
            {
                // 選択肢が一つしかない場合は選択不可
                this.uos_NewPageDiv.Enabled = false;
            }
            else
            {
                this.uos_NewPageDiv.Enabled = true;
            }
            // --- ADD 2008/12/11 --------------------------------<<<<<
        }

        // --- ADD 2008/10/16 --------------------------------<<<<<

        // --- ADD 2008/12/17 -------------------------------->>>>>
        /// <summary>
        /// uos_PrintTypeDiv_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_PrintTypeDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)uos_PrintTypeDiv.CheckedItem.DataValue == 2) // 数量
            {
                this.uos_PriceUnitDiv.Enabled = false;
            }
            else
            {
                this.uos_PriceUnitDiv.Enabled = true;
            }
        }
        // --- ADD 2008/12/17 -------------------------------->>>>>

        # endregion ■ コントロールイベント ■
        

        //# region ■ チャート対応（グラフ） ■
        ///// <summary>
        ///// チャート表示可否
        ///// </summary>
        //public bool CanChart
        //{
        //    //get { return true; }
        //    get { return false; }
        //}
        ///// <summary>
        ///// チャート情報取得
        ///// </summary>
        ///// <param name="chartExtractMemberList"></param>
        ///// <returns></returns>
        //public int GetChartExtractMember ( out List<IChartExtract> chartExtractMemberList )
        //{
        //    chartExtractMemberList = new List<IChartExtract>();
        //    //chartExtractMemberList.Add( new SalesTransListChart(0) );   //←DCTOK02136Eの実装と参照設定が必要
        //    return 0;
        //}
        ///// <summary>
        ///// チャートボタン表示有無
        ///// </summary>
        //public bool VisibledChartButton
        //{
        //    //get { return true; }
        //    get { return false; }
        //}
        //# endregion ■ チャート対応（グラフ） ■
    }
}