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
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[12922]：スペースキーでの項目選択機能を実装
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
    /// 出荷商品分析表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品分析表UIフォームクラス</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.12.03</br>
    /// <br></br>
    /// <br>UpdateNote : 在庫登録日の初期値を空白にし、必須チェックを外した。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2008.04.03</br>
    /// <br>Update Note: 2008.10.20 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12189]</br>
    /// <br>Update Note: 2011/08/18 周雨</br>
    /// <br>            ・連番905の障害確認　抽出条件のコード入力しても、右側に対象項目名が出てこない（現場では帳票発行ミスが多発している）</br>
    /// <br>Update Note: 2011/08/30 王飛３</br>
    /// <br>            ・障害報告 #24164　名称のフォント色が全て黒（Black）で統一。</br>
    /// <br>            ・本体ソス改修なし</br>
    /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
    /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
    /// <br>Update Note: 2014/12/22 尹晶晶</br>
    /// <br>            ・明治産業　Seiken品番変更ＰＧ開発 帳票改良分対応</br>
    /// <br>Update Note: 2015/03/27 時シン</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : Redmine#44209の#423品番集計区分の名称変更</br>
    /// </remarks>
	public partial class DCTOK02050UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 出荷商品分析表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 出荷商品分析表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.12.03</br>
		/// <br></br>
		/// </remarks>
		public DCTOK02050UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl(); // ADD 2008/10/20
		}
		#endregion ■ Constructor

		#region ■ Private Member
		#region ◆ Interface member
		//--IPrintConditionInpTypeのプロパティ用変数 ----------------------------------
        // 抽出ボタン状態取得プロパティ
        private bool _canExtract				= false;
        // PDF出力ボタン状態取得プロパティ    
        private bool _canPdf					= true;
        // 印刷ボタン状態取得プロパティ
        private bool _canPrint					= true;
        // 抽出ボタン表示有無プロパティ
        private bool _visibledExtractButton		= false;
        // PDF出力ボタン表示有無プロパティ	
        private bool _visibledPdfButton			= true;
        // 印刷ボタン表示有無プロパティ
        private bool _visibledPrintButton		= true;

        //--IPrintConditionInpTypeSelectedSectionのプロパティ用変数 -------------------
        // 計上拠点選択表示取得プロパティ
        private bool _visibledSelectAddUpCd		= false;
        // 拠点オプション有無
        private bool _isOptSection				= false;
        // 本社機能有無
        private bool _isMainOfficeFunc			= false;
		// 選択拠点リスト
        private Hashtable _selectedSectionList	= new Hashtable();
		#endregion ◆ Interface member

		// 企業コード
		private string _enterpriseCode = "";
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
        private ExtrInfo_ShipGoodsAnalyze _extrInfo_ShipGoodsAnalyze;

        // 仕入先ガイド
        private SupplierAcs _supplierAcs; // ADD 2008/10/20

        // メーカーガイド
        private MakerAcs _makerAcs; // ADD 2008/10/20

        // ユーザマスタガイド（商品大分類用）
        private UserGuideAcs _userGuideAcs; // ADD 2008/10/20

        // 商品中分類ガイド
        private GoodsGroupUAcs _goodsGroupUAcs; // ADD 2008/10/20

        // グループコードガイド
        private BLGroupUAcs _blGroupUAcs; // ADD 2008/10/20

        // BLコードガイド
        private BLGoodsCdAcs _blGoodsCdAcs; // ADD 2008/10/20
        //----------------------- ADD 2011/08/18 ------------------->>>>>
        //仕入先
        private ArrayList _supplierList;
        //メーカー
        private ArrayList _makerList;
        //商品大分類
        private ArrayList _userGuideList;
        //商品中分類
        private ArrayList _goodsGroupUList;
        //BLコード
        private ArrayList _blGoodsCdList;
        //グループコード
        private ArrayList _blGroupUList;
        //未登入
        private string NOT_FOUND = "未登入";
        //----------------------- ADD 2011/08/18 -------------------<<<<<

        // 日付取得部品
        private DateGetAcs _dateGet;

        // 商品コード用
        //MAKHN04110UA _goodsGuid = new MAKHN04110UA(); // DEL 2008/10/20
        //GoodsAcs _goodsAcs; // DEL 2008/10/20
        //GoodsUnitData _goodsUnitData; // DEL 2008/10/20

        // ADD 2009/03/31 不具合対応[12922]：スペースキーでの項目選択機能を実装 ---------->>>>>
        /// <summary>集計方法ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _ttlTypeDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 集計方法ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>集計方法ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper TtlTypeDivRadioKeyPressHelper
        {
            get { return _ttlTypeDivRadioKeyPressHelper; }
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
        // ADD 2009/03/31 不具合対応[12922]：スペースキーでの項目選択機能を実装 ----------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID         = "DCTOK02050UA";
		// プログラムID
        private const string ct_PGID            = "DCTOK02050U";
		//// 帳票名称
		private string _printName				= "出荷商品分析表";
        // 帳票キー	
        private string _printKey                = "6a331761-63ad-4234-bd93-97a141a8c977";   // 保留
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
        private const string ct_ExBarGroupNm_ReportSortGroup        = "ReportSortGroup";        // ソート条件                 
        private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件
        
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
			SFCMN06001U printDialog	= new SFCMN06001U();		// 帳票選択ガイド
			SFCMN06002C printInfo	= parameter as SFCMN06002C;	// 印刷情報パラメータ

			// 企業コードをセット
			printInfo.enterpriseCode	= this._enterpriseCode;
			printInfo.kidopgid			= ct_PGID;				// 起動PGID

			// PDF出力履歴用
			printInfo.key				= this._printKey;
			printInfo.prpnm				= this._printName;

			printInfo.PrintPaperSetCd	= 0;
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._extrInfo_ShipGoodsAnalyze;
			printDialog.PrintInfo		= printInfo;
			
			// 帳票選択ガイド
			DialogResult dialogResult = printDialog.ShowDialog();

			if( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN ) {
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		public bool PrintBeforeCheck ()
		{
			bool status = true;

			string errMessage = "";
			Control errComponent = null;

			if( !this.ScreenInputCheck( ref errMessage, ref errComponent ) )
			{
				// メッセージを表示
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

				// コントロールにフォーカスをセット
				if( errComponent != null ) {
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		public void Show ( object parameter )
		{
            this._extrInfo_ShipGoodsAnalyze = new ExtrInfo_ShipGoodsAnalyze();

            this.Show();
			return;
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		public void SelectedAddUpCd (int addUpCd )
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// <br>Update Note: 2014/12/22 尹晶晶</br>
        /// <br>             明治産業　Seiken品番変更ＰＧ開発 帳票改良分対応</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // 初期値セット・日付
                // 処理年月を取得
                /* ---ADD 2009/03/05 不具合対応[12189] -------------------------------->>>>>
                DateTime yearMonth;
                this._dateGet.GetThisYearMonth(out yearMonth);
                this.tde_St_AddUpYearMonth.DateFormat = emDateFormat.df4Y2M;
                this.tde_St_AddUpYearMonth.SetDateTime(yearMonth);
                this.tde_Ed_AddUpYearMonth.DateFormat = emDateFormat.df4Y2M;
                this.tde_Ed_AddUpYearMonth.SetDateTime(yearMonth);
                // (年月日yyyyMMdd→年月yyyyMM→年月日yyyyMM01に変換)
                this.tde_St_AddUpYearMonth.LongDate = this.tde_St_AddUpYearMonth.LongDate / 100 * 100 + 1;
                this.tde_Ed_AddUpYearMonth.LongDate = this.tde_Ed_AddUpYearMonth.LongDate / 100 * 100 + 1;
                   ---ADD 2009/03/05 不具合対応[12189] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12189] -------------------------------->>>>>
                this.tde_St_AddUpYearMonth.DateFormat = emDateFormat.df4Y2M;
                this.tde_Ed_AddUpYearMonth.DateFormat = emDateFormat.df4Y2M;

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
                    this.tde_Ed_AddUpYearMonth.SetDateTime(currentTotalMonth);
                    this.tde_St_AddUpYearMonth.SetDateTime(currentTotalMonth.AddMonths(-11));
                }
                else
                {
                    // 当月を設定
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);

                    this.tde_Ed_AddUpYearMonth.SetDateTime(nowYearMonth);
                    this.tde_St_AddUpYearMonth.SetDateTime(nowYearMonth.AddMonths(-11));
                }
                // ---ADD 2009/03/05 不具合対応[12189] --------------------------------<<<<<

                // ↓ 2008.04.03 980081 c
                //this.tde_StockCreateDate.SetDateTime(TDateTime.GetSFDateNow());
                this.tde_StockCreateDate.Clear();
                // ↑ 2008.04.03 980081 c

                // 初期値セット・文字列
                // --- DEL 2008/10/20 -------------------------------->>>>>
                //this.tNedit_GoodsLGroup_St.DataText = string.Empty;
                //this.tNedit_GoodsLGroup_Ed.DataText = string.Empty;
                //this.tNedit_GoodsMGroup_St.DataText = string.Empty;
                //this.tNedit_GoodsMGroup_Ed.DataText = string.Empty;
                //this.tNedit_BLGloupCode_St.DataText = string.Empty;
                //this.tNedit_BLGloupCode_Ed.DataText = string.Empty;
                // --- DEL 2008/10/20 --------------------------------<<<<<

                // 初期値セット・数値
                this.tNedit_GoodsMakerCd_St.SetInt(0);
                this.tNedit_GoodsMakerCd_Ed.SetInt(0);
                // --- ADD 2008/10/20 -------------------------------->>>>>
                this.tNedit_GoodsLGroup_St.SetInt(0);
                this.tNedit_GoodsLGroup_Ed.SetInt(0);
                this.tNedit_GoodsMGroup_St.SetInt(0);
                this.tNedit_GoodsMGroup_Ed.SetInt(0);
                this.tNedit_BLGloupCode_St.SetInt(0);
                this.tNedit_BLGloupCode_Ed.SetInt(0);
                // --- ADD 2008/10/20 -------------------------------->>>>>
                this.tNedit_BLGoodsCode_St.SetInt(0);
                this.tNedit_BLGoodsCode_Ed.SetInt(0);
                this.tEdit_RankOrderMax.SetInt(Int32.Parse(new string('9', this.tEdit_RankOrderMax.ExtEdit.Column)));

                // 初期値セット・区分
                //this.tComboEditor_TtlType.Value = false; // DEL 2008/10/20
                this.uos_TtlTypeDiv.Value = 1; // ADD 2008/10/20
                this.tce_StockCreateDateDiv.Value = 0;
                this.tComboEditor_RsltTtlDiv.Value = 0;
                //this.tce_MoneyUnit.Value = 0; // DEL 2008/10/20
                this.tComboEditor_RankSection.Value = 0;
                this.tComboEditor_RankHighLow.Value = 0;
                //this.tce_SubttlPrintDiv.Value = 0; // DEL 2008/10/20
                this.uos_NewPageDiv.Value = 0;
                this.tComboEditor_SortOrderDiv.Value = 0;
                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                // 品番集計区分
                this.tComboEditor_GoodsNoTtlDiv.Value = 0;
                // 品番表示区分
                this.tComboEditor_GoodsNoShowDiv.Value = 0;
                //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                // ボタン設定
                this.SetIconImage(this.ub_St_SuplierCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SuplierCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_LargeGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_LargeGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_MediumGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_MediumGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_DetailGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_DetailGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                //this.SetIconImage(this.ub_St_GoodsNoGuide, Size16_Index.STAR1); // DEL 2008/10/20
                //this.SetIconImage(this.ub_Ed_GoodsNoGuide, Size16_Index.STAR1); // DEL 2008/10/20

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput(); // ADD 2008/10/20

                // 初期フォーカスセット
                //this.tComboEditor_TtlType.Focus(); // DEL 2008/10/20
                this.uos_TtlTypeDiv.Focus(); // ADD 2008/10/20
                this.uos_TtlTypeDiv.FocusedIndex = (int)this.uos_TtlTypeDiv.Value;  // ADD 2008/03/31 不具合対応[12922]：スペースキーでの項目選択機能を実装
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
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
			((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((UltraButton)settingControl).Appearance.Image = iconIndex;
		}
		#endregion

        #region ◎ 画面設定保存
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.uos_TtlTypeDiv);
            //saveCtrAry.Add(this.tde_St_AddUpYearMonth);           //DEL 2009/03/05 不具合対応[12189]
            //saveCtrAry.Add(this.tde_Ed_AddUpYearMonth);           //DEL 2009/03/05 不具合対応[12189]
            saveCtrAry.Add(this.tde_StockCreateDate);
            saveCtrAry.Add(this.tce_StockCreateDateDiv);
            saveCtrAry.Add(this.tComboEditor_RsltTtlDiv);
            saveCtrAry.Add(this.uos_PriceUnitDiv);
            saveCtrAry.Add(this.tComboEditor_RankSection);
            saveCtrAry.Add(this.tComboEditor_RankHighLow);
            saveCtrAry.Add(this.tEdit_RankOrderMax);
            //saveCtrAry.Add(this.tComboEditor_NewPageDiv); // DEL 2008/12/11
            saveCtrAry.Add(this.uos_NewPageDiv); // ADD 2008/12/11
            //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            // 品番集計区分
            saveCtrAry.Add(this.tComboEditor_GoodsNoTtlDiv);
            // 品番表示区分
            saveCtrAry.Add(this.tComboEditor_GoodsNoShowDiv);
            //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
            saveCtrAry.Add(this.tComboEditor_SortOrderDiv);

            saveCtrAry.Add(this.tNedit_SupplierCd_St);
            saveCtrAry.Add(this.tNedit_SupplierCd_Ed);
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_St);
            saveCtrAry.Add(this.tNedit_GoodsMakerCd_Ed);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsLGroup_Ed);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_St);
            saveCtrAry.Add(this.tNedit_GoodsMGroup_Ed);
            saveCtrAry.Add(this.tNedit_BLGloupCode_St);
            saveCtrAry.Add(this.tNedit_BLGloupCode_Ed);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_St);
            saveCtrAry.Add(this.tNedit_BLGoodsCode_Ed);
            saveCtrAry.Add(this.tEdit_GoodsNo_St);
            saveCtrAry.Add(this.tEdit_GoodsNo_Ed);
            // --------------------- ADD 2011/08/18 ------------------->>>>>
            saveCtrAry.Add(this.tEdit_SupplierCd_St);
            saveCtrAry.Add(this.tEdit_SupplierCd_Ed);
            saveCtrAry.Add(this.tEdit_GoodsMakerCd_St);
            saveCtrAry.Add(this.tEdit_GoodsMakerCd_Ed);
            saveCtrAry.Add(this.tEdit_GoodsLGroup_St);
            saveCtrAry.Add(this.tEdit_GoodsLGroup_Ed);
            saveCtrAry.Add(this.tEdit_GoodsMGroup_St);
            saveCtrAry.Add(this.tEdit_GoodsMGroup_Ed);
            saveCtrAry.Add(this.tEdit_BLGloupCode_St);
            saveCtrAry.Add(this.tEdit_BLGloupCode_Ed);
            saveCtrAry.Add(this.tEdit_BLGoodsCode_St);
            saveCtrAry.Add(this.tEdit_BLGoodsCode_Ed);
            // --------------------- ADD 2011/08/18 -------------------<<<<<

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion
		#endregion ◆ 画面初期化関係

        #region ◆ 画面項目制御
        // --- ADD 2008/12/11 -------------------------------->>>>>
        /// <summary>
        /// 改頁の設定を行う。
        /// </summary>
        private void SetNewPageDiv()
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

            if ((int)this.uos_TtlTypeDiv.CheckedItem.DataValue != 0) // 全社でない
            {
                valueListItem = new Infragistics.Win.ValueListItem();
                valueListItem.Tag = 0;
                valueListItem.DataValue = 0;
                valueListItem.DisplayText = "拠点";
                this.uos_NewPageDiv.Items.Add(valueListItem);
            }

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 1;
            valueListItem.DataValue = 1;
            valueListItem.DisplayText = "仕入先";
            this.uos_NewPageDiv.Items.Add(valueListItem);

            valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.Tag = 2;
            valueListItem.DataValue = 2;
            valueListItem.DisplayText = "しない";
            this.uos_NewPageDiv.Items.Add(valueListItem);
        }
        // --- ADD 2008/12/11 --------------------------------<<<<<
        #endregion

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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

            const string ct_NoInput = "を入力して下さい"; // ADD 2008/10/20
			const string ct_InputError = "の入力が不正です";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_RangeError1 = "の範囲指定に誤りがあります(１２ヶ月以内で設定して下さい)";

            // 対象年月（開始～終了）
            if (CallCheckDateRange(out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象年月{0}", ct_NoInput); // ADD 2008/10/20
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始対象年月{0}", ct_InputError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("終了対象年月{0}", ct_NoInput); // ADD 2008/10/20
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象年月{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象年月{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("対象年月{0}", ct_RangeError1);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                }
                status = false;
            }
            // 在庫登録日
            // ↓ 2008.04.03 980081 c
            //// (未入力許可しない)
            //else if ( ( this.tde_StockCreateDate.CheckInputData() != null ) || ( !this.DateEditInputCheck(this.tde_StockCreateDate, false) ) ) 
            // (未入力を許可する)
            else if ((this.tde_StockCreateDate.LongDate != 0) && (!this.DateEditInputCheck(this.tde_StockCreateDate, false))) 
            // ↑ 2008.04.03 980081 c
            {
                errMessage = string.Format("在庫登録日{0}", ct_InputError);
                errComponent = this.tde_StockCreateDate;
                status = false;
            }
            // --- ADD 2008/10/20 -------------------------------->>>>>
            // 順位付設定
            else if (this.tEdit_RankOrderMax.GetInt() == 0)
            {
                errMessage = string.Format("順位付け設定{0}", ct_NoInput);
                errComponent = this.tEdit_RankOrderMax;
                status = false;
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<
            // --- ADD 2008/10/20 -------------------------------->>>>>
            // 仕入先（開始 > 終了 → NG）
            else if ((this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()) && (this.tNedit_SupplierCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // --- ADD 2008/10/20 --------------------------------<<<<< 
            // メーカー（開始 > 終了 → NG）
            else if ((this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt()) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0))
            {
                errMessage = string.Format("メーカー{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 商品大分類
           // else if (
           //(this.tNedit_GoodsLGroup_St.DataText.TrimEnd() != string.Empty) &&
           //(this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() != string.Empty) &&
            //(this.tNedit_GoodsLGroup_St.DataText.TrimEnd().CompareTo(this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd()) > 0)) // DEL 2008/10/20
            else if ((this.tNedit_GoodsLGroup_St.GetInt() > this.tNedit_GoodsLGroup_Ed.GetInt()) && (this.tNedit_GoodsLGroup_Ed.GetInt() != 0)) // ADD 2008/10/20
            {
                errMessage = string.Format("商品大分類{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // 商品中分類
            //else if (
            //    (this.tNedit_GoodsMGroup_St.DataText.TrimEnd() != string.Empty) &&
            //    (this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() != string.Empty) &&
            //    (this.tNedit_GoodsMGroup_St.DataText.TrimEnd().CompareTo(this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd()) > 0)) // DEL 2008/10/20
            else if ((this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt()) && (this.tNedit_GoodsMGroup_Ed.GetInt() != 0)) // ADD 2008/10/20
            {
                errMessage = string.Format("商品中分類{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // グループコード
           // else if (
           //(this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty) &&
           //(this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty) &&
            //(this.tNedit_BLGloupCode_St.DataText.TrimEnd().CompareTo(this.tNedit_BLGloupCode_Ed.DataText.TrimEnd()) > 0)) // DEL 2008/10/20
            else if ((this.tNedit_BLGloupCode_St.GetInt() > this.tNedit_BLGloupCode_Ed.GetInt()) && (this.tNedit_BLGloupCode_Ed.GetInt() != 0)) // ADD 2008/10/20
            {
                errMessage = string.Format("グループコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // ＢＬ商品コード（開始 > 終了 → NG）
            else if ((this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt()) && (this.tNedit_BLGoodsCode_Ed.GetInt() != 0)) 
            {
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            // 商品番号
            else if (
                ( this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty ) &&
            ( this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0 ) ) 
            {
                errMessage = string.Format("品番{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }
            
            return status;
        }
		#endregion

		#region ◎ 日付入力チェック処理
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpYearMonth"></param>
        /// <param name="tde_Ed_AddUpYearMonth"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpYearMonth, ref TDateEdit tde_Ed_AddUpYearMonth)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
		/// <summary>
		/// 日付入力チェック処理
		/// </summary>
		/// <param name="targetDateEdit">チェック対象コントロール</param>
		/// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
		/// <returns>チェック結果(true/false)</returns>
		/// <remarks>
		/// <br>Note		: 日付入力のチェックを行う。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
		/// </remarks>
		private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowEmpty )
		{
			bool status = true;

			// 入力日付を数値型で取得
			int date = targetDateEdit.GetLongDate();
			int yy = date / 10000;
			int mm = ( date / 100 ) % 100;
			int dd = date % 100;

			// 日付未入力チェック
			if (( targetDateEdit.GetDateTime() == DateTime.MinValue ) || (targetDateEdit.GetLongDate() == 0))
			{
				if( allowEmpty == true ) 
				{
					return status;
				}
				else 
				{
					status = false;
				}
			}
			// システムサポートチェック
			else if( yy < 1900 )
			{
				status = false;
			}
			// 年月日別入力チェック
			else if( ( yy == 0 ) || ( mm == 0 ) || ( dd == 0 ) )
			{
				status = false;
			}
			// 単純日付妥当性チェック
			else if( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
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
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// <br>Update Note: 2014/12/22 尹晶晶</br>
        /// <br>             明治産業　Seiken品番変更ＰＧ開発 帳票改良分対応</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                // 拠点オプション
                this._extrInfo_ShipGoodsAnalyze.IsOptSection = this._isOptSection;
                // 企業コード
                this._extrInfo_ShipGoodsAnalyze.EnterpriseCode = this._enterpriseCode;

                // 対象年月
                Int32 iSMonth = 0;
                Int32 iEMonth = 0;
                // --- DEL 2008/10/20 -------------------------------->>>>>
                //iSMonth = this.tde_St_AddUpYearMonth.GetLongDate() / 100;
                //iEMonth = this.tde_Ed_AddUpYearMonth.GetLongDate() / 100;
                //this._extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth = iSMonth;
                //this._extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth = iEMonth;
                // --- DEL 2008/10/20 --------------------------------<<<<<
                // --- ADD 2008/10/20 -------------------------------->>>>>
                // DateTimeに変換
                iSMonth = (this.tde_St_AddUpYearMonth.GetLongDate() / 100) * 100 + 1;
                iEMonth = (this.tde_Ed_AddUpYearMonth.GetLongDate() / 100) * 100 + 1;
                this.tde_St_AddUpYearMonth.SetLongDate(iSMonth);
                this.tde_Ed_AddUpYearMonth.SetLongDate(iEMonth);
                this._extrInfo_ShipGoodsAnalyze.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                this._extrInfo_ShipGoodsAnalyze.Ed_AddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // --- ADD 2008/10/20 --------------------------------<<<<<

                // 拠点コード
                this._extrInfo_ShipGoodsAnalyze.SecCodeList = ( string[] ) new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // --- ADD 2008/10/20 -------------------------------->>>>>
                // 開始仕入先コード
                this._extrInfo_ShipGoodsAnalyze.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                this._extrInfo_ShipGoodsAnalyze.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
                // --- ADD 2008/10/20 --------------------------------<<<<<
                // 開始商品メーカーコード
                this._extrInfo_ShipGoodsAnalyze.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了商品メーカーコード
                //this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt(); // DEL 2008/10/20
                this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMakerCd = this.tNedit_GoodsMakerCd_Ed.GetInt(); // ADD 2008/10/20
                // --- DEL 2008/10/20 -------------------------------->>>>>
                //// 開始商品区分グループコード
                //this._extrInfo_ShipGoodsAnalyze.St_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_St.Text;
                //// 終了商品区分グループコード
                //this._extrInfo_ShipGoodsAnalyze.Ed_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_Ed.Text;
                //// 開始商品区分コード
                //this._extrInfo_ShipGoodsAnalyze.St_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_St.Text;
                //// 終了商品区分コード
                //this._extrInfo_ShipGoodsAnalyze.Ed_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_Ed.Text;
                //// 開始商品区分詳細コード
                //this._extrInfo_ShipGoodsAnalyze.St_DetailGoodsGanreCode = this.tNedit_BLGloupCode_St.Text;
                //// 終了商品区分詳細コード
                //this._extrInfo_ShipGoodsAnalyze.Ed_DetailGoodsGanreCode = this.tNedit_BLGloupCode_Ed.Text;
                // --- DEL 2008/10/20 --------------------------------<<<<<
                // --- ADD 2008/10/20 -------------------------------->>>>>
                // 開始商品大分類コード
                this._extrInfo_ShipGoodsAnalyze.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
                // 終了商品大分類コード
                this._extrInfo_ShipGoodsAnalyze.Ed_GoodsLGroup = this.tNedit_GoodsLGroup_Ed.GetInt();
                // 開始商品中分類コード
                this._extrInfo_ShipGoodsAnalyze.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
                // 終了商品中分類コード
                this._extrInfo_ShipGoodsAnalyze.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();
                // 開始グループコード
                this._extrInfo_ShipGoodsAnalyze.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
                // 終了グループコード
                this._extrInfo_ShipGoodsAnalyze.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
                // --- ADD 2008/10/20 --------------------------------<<<<<
                // 開始ＢＬ商品コード
                this._extrInfo_ShipGoodsAnalyze.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                // 終了ＢＬ商品コード
                //this._extrInfo_ShipGoodsAnalyze.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt(); // DEL 2008/10/20
                this._extrInfo_ShipGoodsAnalyze.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt(); // ADD 2008/10/20
                // 開始品番
                this._extrInfo_ShipGoodsAnalyze.St_GoodsNo = this.tEdit_GoodsNo_St.DataText;
                // 終了品番
                this._extrInfo_ShipGoodsAnalyze.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.DataText;
                // --- DEL 2008/10/20 -------------------------------->>>>>
                //// ↓ 2008.04.03 980081 a
                ////集計方法
                //if (this.uos_TtlTypeDiv.SelectedIndex == 0)
                //    this._extrInfo_ShipGoodsAnalyze.TotalWay = true;
                //else
                //    this._extrInfo_ShipGoodsAnalyze.TotalWay = false;
                //// ↑ 2008.04.03 980081 a
                // --- DEL 2008/10/20 --------------------------------<<<<<
                //集計方法
                this._extrInfo_ShipGoodsAnalyze.TtlType = (ExtrInfo_ShipGoodsAnalyze.TtlTypeState)this.uos_TtlTypeDiv.CheckedItem.DataValue; // ADD 2008/10/20
                // 在庫登録日
                //this._extrInfo_ShipGoodsAnalyze.Ex_StockCreateDate = this.tde_StockCreateDate.GetLongDate(); // DEL 2008/10/20
                this._extrInfo_ShipGoodsAnalyze.Ex_StockCreateDate = this.tde_StockCreateDate.GetDateTime(); // ADD 2008/10/20
                // 在庫登録日指定区分
                this._extrInfo_ShipGoodsAnalyze.BeforeAfterDiv = (ExtrInfo_ShipGoodsAnalyze.BeforeAfterDivState)this.tce_StockCreateDateDiv.SelectedIndex;
                // 在取指定区分
                this._extrInfo_ShipGoodsAnalyze.RsltTtlDiv = (ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState)this.tComboEditor_RsltTtlDiv.SelectedIndex;
                // 順位付け区分（拠点集計）
                this._extrInfo_ShipGoodsAnalyze.RankSection = (ExtrInfo_ShipGoodsAnalyze.RankSectionState)this.tComboEditor_RankSection.SelectedIndex;
                // 順位付け区分（上位・下位）
                this._extrInfo_ShipGoodsAnalyze.RankHighLow = (ExtrInfo_ShipGoodsAnalyze.RankHighLowState)this.tComboEditor_RankHighLow.SelectedIndex;
                // 印刷対象順位Max (ｘｘ位まで印字)
                this._extrInfo_ShipGoodsAnalyze.RankOrderMax = this.tEdit_RankOrderMax.GetInt();

                // -- ( 以下、UI側 制御用項目 ) -- 
                // 金額単位
                //this._extrInfo_ShipGoodsAnalyze.MoneyUnit = (ExtrInfo_ShipGoodsAnalyze.MoneyUnitState)this.tce_MoneyUnit.SelectedIndex; // DEL 2008/10/20
                this._extrInfo_ShipGoodsAnalyze.MoneyUnit = (ExtrInfo_ShipGoodsAnalyze.MoneyUnitState)this.uos_PriceUnitDiv.CheckedItem.DataValue; // ADD 2008/10/20
                // 小計印刷
                //this._extrInfo_ShipGoodsAnalyze.SubttlPrintDiv = (ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState)this.tce_SubttlPrintDiv.SelectedIndex; // DEL 2008/10/20
                // --- ADD 2008/10/20 -------------------------------->>>>>
                // 小計印刷　拠点
                if (this.CheckEditor_SubtotalSection.Checked) this._extrInfo_ShipGoodsAnalyze.SectionSumPrintDiv = ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.Do;
                else this._extrInfo_ShipGoodsAnalyze.SectionSumPrintDiv = ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.None;
                // 小計印刷　仕入先
                if (this.CheckEditor_SubtotalSuplier.Checked) this._extrInfo_ShipGoodsAnalyze.SuplierSumPrintDiv = ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.Do;
                else this._extrInfo_ShipGoodsAnalyze.SuplierSumPrintDiv = ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.None;
                // 小計印刷　メーカー
                if (this.CheckEditor_SubtotalMaker.Checked) this._extrInfo_ShipGoodsAnalyze.MakerSumPrintDiv = ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.Do;
                else this._extrInfo_ShipGoodsAnalyze.MakerSumPrintDiv = ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.None;
                // --- ADD 2008/10/20 --------------------------------<<<<<
                // 改頁区分
                this._extrInfo_ShipGoodsAnalyze.NewPageDiv = (ExtrInfo_ShipGoodsAnalyze.NewPageDivState)this.uos_NewPageDiv.CheckedItem.DataValue;
                // 印刷順
                this._extrInfo_ShipGoodsAnalyze.OrderPrintDiv = (ExtrInfo_ShipGoodsAnalyze.OrderPrintDivState)this.tComboEditor_SortOrderDiv.SelectedIndex;
                //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                // 品番集計区分
                this._extrInfo_ShipGoodsAnalyze.GoodsNoTtlDiv = (ExtrInfo_ShipGoodsAnalyze.GoodsNoTtlDivState)this.tComboEditor_GoodsNoTtlDiv.SelectedIndex;
                // 品番表示区分
                this._extrInfo_ShipGoodsAnalyze.GoodsNoShowDiv = (ExtrInfo_ShipGoodsAnalyze.GoodsNoShowDivState)this.tComboEditor_GoodsNoShowDiv.SelectedIndex;
                //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
			}
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
		#endregion

        #region ◎ コード最大値取得
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
        private int GetEndCode(TNedit tNedit)
        {
            // 画面上コンポーネントのColumnで終了コードを取得
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }
        /// <summary>
        /// 数値項目　終了コード取得処理
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }
        #endregion

        #endregion ◆ 印刷前処理

        #region ◆ ControlEventからCall
        #region ◎ 絞込み倉庫ガイドEnabledセット処理
        /// <summary>
		/// 絞込み倉庫ガイドEnabledセット処理
		/// </summary>
		/// <param name="targetSt">Enabledセット対象ボタン</param>
		/// <param name="targetEd">Enabledセット対象ボタン</param>
		/// <param name="compareStr1">比較対象文字列1</param>
		/// <param name="compareStr2">比較対象文字列2</param>
		private void ExtractWareHouseGuidSetProc( UltraButton targetSt, UltraButton targetEd, string compareStr1, string compareStr2 )
		{
			// 渡された文字列(絞込み拠点コード)が同じならばガイドボタンをクリック可能にする
			if ( compareStr1.CompareTo( compareStr2 ) == 0 ) 
			{
				targetSt.Enabled = true;
				targetEd.Enabled = true;
			}
			else
			{
				targetSt.Enabled = false;
				targetEd.Enabled = false;
			}
		}
		#endregion
		#endregion

		#region ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
		#region ◎ エラーメッセージ表示処理
		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.12.03</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
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
		#endregion

		#region ◎ エラーメッセージ表示処理
		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="procnm">発生メソッドID</param>
		/// <param name="ex">例外情報</param>
		/// <remarks>
		/// <br>Note       : エラーメッセージの表示を行います。</br>
		/// <br>Programmer : 20081 疋田　勇人</br>
		/// <br>Date       : 2007.12.03</br>
		/// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
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
		#endregion
		#endregion ◆ エラーメッセージ表示処理 ( +1のオーバーロード )
        // ------------------ ADD 2011/08/18 -------------------->>>>>
        #region ◆ 名称取得
        /// <summary>
        /// 名称取得処理
        /// </summary>
        /// <param name="code">コード</param>
        /// <param name="nameDiv">名称区分[0:仕入先,1:メーカー,2:商品大分類,3:商品中分類,4:グループコード,5:BLコード]</param>
        /// <returns>名称</returns>
        /// <remarks>
        /// <br>Note       : 名称を取得します。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>連番905</br>
        /// <br>Date       : 2011/08/18</br>
        /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
        /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
        /// </remarks>
        private string GetNameFromCode(string code, int nameDiv)
        {
            string name = string.Empty;

            if (code == string.Empty)
                code = "0";

            switch (nameDiv)
            {
                //仕入先
                case 0:
                    {
                        int supplierCode = Convert.ToInt32(code);
                        if (_supplierList == null || _supplierList.Count == 0)
                        {
                            if (this._supplierAcs == null)
                                this._supplierAcs = new SupplierAcs();

                            ArrayList outSupplierList;
                            int status = this._supplierAcs.SearchAll(out outSupplierList, this._enterpriseCode, "");
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _supplierList = outSupplierList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "仕入先情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }

                        if (_supplierList.Count != 0)
                        {
                            foreach (Supplier supplier in _supplierList)
                            {
                                if (supplier.SupplierCd == supplierCode)
                                {
                                    name = supplier.SupplierSnm;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //メーカー
                case 1:
                    {
                        int makerCode = Convert.ToInt32(code);
                        if (_makerList == null || _makerList.Count == 0)
                        {
                            if (_makerAcs == null)
                                _makerAcs = new MakerAcs();

                            ArrayList outList;
                            int status = this._makerAcs.SearchAll(out outList, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _makerList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "メーカー情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_makerList.Count != 0)
                        {
                            foreach (MakerUMnt makerUMnt in _makerList)
                            {
                                if (makerUMnt.GoodsMakerCd == makerCode)
                                {
                                    name = makerUMnt.MakerName;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //商品大分類
                case 2:
                    {
                        int userGuideCode = Convert.ToInt32(code);
                        if (_userGuideList == null || _userGuideList.Count == 0)
                        {
                            if (_userGuideAcs == null)
                                _userGuideAcs = new UserGuideAcs();

                            ArrayList outList;
                            int status = this._userGuideAcs.SearchAllBody(out outList, this._enterpriseCode, UserGuideAcsData.UserBodyData);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _userGuideList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "商品大分類情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_userGuideList.Count != 0)
                        {
                            foreach (UserGdBd userGdBd in _userGuideList)
                            {
                                if (userGdBd.GuideCode == userGuideCode && userGdBd.UserGuideDivCd == 70)
                                {
                                    name = userGdBd.GuideName;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //商品中分類
                case 3:
                    {
                        int goodsGroupUCode = Convert.ToInt32(code);
                        if (_goodsGroupUList == null || _goodsGroupUList.Count == 0)
                        {
                            if (_goodsGroupUAcs == null)
                                _goodsGroupUAcs = new GoodsGroupUAcs();

                            ArrayList outList;
                            int status = this._goodsGroupUAcs.SearchAll(out outList, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _goodsGroupUList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "商品中分類情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_goodsGroupUList.Count != 0)
                        {
                            foreach (GoodsGroupU goodgroupU in _goodsGroupUList)
                            {
                                if (goodgroupU.GoodsMGroup == goodsGroupUCode)
                                {
                                    name = goodgroupU.GoodsMGroupName;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                //グループコード
                case 4:
                    {
                        int blGroupUCode = Convert.ToInt32(code);
                        if (_blGroupUList == null || _blGroupUList.Count == 0)
                        {
                            if (_blGroupUAcs == null)
                                _blGroupUAcs = new BLGroupUAcs();

                            ArrayList outList;
                            int status = this._blGroupUAcs.SearchAll(out outList, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _blGroupUList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "グループコード情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_blGroupUList.Count != 0)
                        {
                            foreach (BLGroupU blGroupU in _blGroupUList)
                            {
                                if (blGroupU.BLGroupCode == blGroupUCode)
                                {
                                    //--- UPD 2011/09/09 ------------>>>>>
                                    //name = blGroupU.BLGroupName; 
                                    name = blGroupU.BLGroupKanaName;
                                    if (name == string.Empty)
                                    {
                                        name = " "; 
                                    }
                                    //--- UPD 2011/09/09 ------------<<<<<
                                    break;
                                }
                            }
                        }
                        break;
                    }
                //BLコード
                case 5:
                    {
                        int blGoodsCdCode = Convert.ToInt32(code);
                        if (_blGoodsCdList == null || _blGoodsCdList.Count == 0)
                        {
                            if (_blGoodsCdAcs == null)
                                _blGoodsCdAcs = new BLGoodsCdAcs();

                            ArrayList outList;
                            int status = this._blGoodsCdAcs.SearchAll(out outList, this._enterpriseCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _blGoodsCdList = outList;
                            }
                            else
                            {
                                TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_STOPDISP,
                                                this.Name,
                                                "BLコード情報の取得に失敗しました。",
                                                status,
                                                MessageBoxButtons.OK);
                                return NOT_FOUND;
                            }
                        }


                        if (_blGoodsCdList.Count != 0)
                        {
                            foreach (BLGoodsCdUMnt bLGoodsCdUMnt in _blGoodsCdList)
                            {
                                if (bLGoodsCdUMnt.BLGoodsCode == blGoodsCdCode)
                                {
                                    name = bLGoodsCdUMnt.BLGoodsHalfName;
                                    break;
                                }
                            }
                        }
                        break;
                    }

                default:
                    break;
            }
            if (name == string.Empty)
                return NOT_FOUND;
            else
                return name;
        }
        #endregion
        // ------------------ ADD 2011/08/18 --------------------<<<<<
		#endregion ■ Private Method

		#region ■ Control Event
        #region ◆ DCTOK02050UA
        #region ◎ DCTOK02050UA_Load Event
        /// <summary>
        /// DCTOK02050UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
        private void DCTOK02050UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // コントロール初期化
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            ParentToolbarSettingEvent(this);						// ツールバーボタン設定イベント起動

            // ADD 2009/03/31 不具合対応[12922]：スペースキーでの項目選択機能を実装 ---------->>>>>
            TtlTypeDivRadioKeyPressHelper.ControlList.Add(this.uos_TtlTypeDiv);
            TtlTypeDivRadioKeyPressHelper.StartSpaceKeyControl();

            PriceUnitDivRadioKeyPressHelper.ControlList.Add(this.uos_PriceUnitDiv);
            PriceUnitDivRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.uos_NewPageDiv);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 不具合対応[12922]：スペースキーでの項目選択機能を実装 ----------<<<<<
        }
		#endregion
        #endregion ◆ DCTOK02050UA

        #region ◆　ガイドボタンクリックイベント

        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_SuplierCdGuide_Click(object sender, EventArgs e)
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
                this.tEdit_SupplierCd_St.DataText = supplier.SupplierSnm;  //ADD 2011/08/18
                this.tNedit_SupplierCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                this.tEdit_SupplierCd_Ed.DataText = supplier.SupplierSnm;  //ADD 2011/08/18
                this.tNedit_GoodsMakerCd_St.Focus();
            }
            else
            {
                return;
            }

        }
        // --- ADD 2008/10/20 -------------------------------->>>>>

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerCdGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //MakerUMnt maker;
            //int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            //if (status != 0) return;

            //TNedit targetControl;
            //if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl =  this.tNedit_GoodsMakerCd_St;
            //else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tNedit_GoodsMakerCd_Ed;
            //else return;

            //targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // --- ADD 2008/10/20 -------------------------------->>>>>
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
                this.tEdit_GoodsMakerCd_St.DataText = makerUMnt.MakerName;  //ADD 2011/08/18
                this.tNedit_GoodsMakerCd_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                this.tEdit_GoodsMakerCd_Ed.DataText = makerUMnt.MakerName;  //ADD 2011/08/18
                this.tNedit_GoodsLGroup_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<
        }

        /// <summary>
        /// 商品大分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_LargeGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //LGoodsGanre lGoodsGanre;
            //int status = this._goodsAcs.ExecuteLGoodsGanreGuid(this._enterpriseCode, out lGoodsGanre);
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tNedit_GoodsLGroup_St;
            //else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tNedit_GoodsLGroup_Ed;
            //else return;

            //targetControl.DataText = lGoodsGanre.LargeGoodsGanreCode.ToString().TrimEnd();
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // --- ADD 2008/10/20 -------------------------------->>>>>
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
                this.tEdit_GoodsLGroup_St.DataText = userGdBd.GuideName;  //ADD 2011/08/18
                this.tNedit_GoodsLGroup_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);
                this.tEdit_GoodsLGroup_Ed.DataText = userGdBd.GuideName;  //ADD 2011/08/18
                this.tNedit_GoodsMGroup_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<
        }
        /// <summary>
        /// 商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //MGoodsGanre mGoodsGanre;
            //int status = this._goodsAcs.ExecuteMGoodsGanreGuid(this._enterpriseCode, string.Empty, out mGoodsGanre);
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tNedit_GoodsMGroup_St;
            //else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tNedit_GoodsMGroup_Ed;
            //else return;

            //targetControl.DataText = mGoodsGanre.MediumGoodsGanreCode.ToString().TrimEnd();
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // --- ADD 2008/10/20 -------------------------------->>>>>
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
                this.tEdit_GoodsMGroup_St.DataText = goodgroupU.GoodsMGroupName;  //ADD 2011/08/18
                this.tNedit_GoodsMGroup_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GoodsMGroup_Ed.SetInt(goodgroupU.GoodsMGroup);
                this.tEdit_GoodsMGroup_Ed.DataText = goodgroupU.GoodsMGroupName;  //ADD 2011/08/18
                this.tNedit_BLGloupCode_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<
        }
        /// <summary>
        /// グループコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2011/09/09 鄧潘ハン</br>
        /// <br>            ・案件一覧 連番905 でのテスト不具合についての改修</br>
        /// </remarks>
        private void ub_St_DetailGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //DGoodsGanre dGoodsGanre;
            //int status = this._goodsAcs.ExecuteDGoodsGanreGuid(this._enterpriseCode, out dGoodsGanre);
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tNedit_BLGloupCode_St;
            //else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tNedit_BLGloupCode_Ed;
            //else return;

            //targetControl.DataText = dGoodsGanre.DetailGoodsGanreCode.ToString().TrimEnd();
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // --- ADD 2008/10/20 -------------------------------->>>>>
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
                //this.tEdit_BLGloupCode_St.DataText = blGroupU.BLGroupName;  //ADD 2011/08/18 //DEL 2011/09/09
                this.tEdit_BLGloupCode_St.DataText = GetNameFromCode(blGroupU.BLGroupCode.ToString(), 4);//ADD 2011/09/09
                this.tNedit_BLGloupCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGloupCode_Ed.SetInt(blGroupU.BLGroupCode);
                //this.tEdit_BLGloupCode_Ed.DataText = blGroupU.BLGroupName;  //ADD 2011/08/18 //DEL 2011/09/09
                this.tEdit_BLGloupCode_Ed.DataText = GetNameFromCode(blGroupU.BLGroupCode.ToString(), 4);  //ADD 2011/09/09
                this.tNedit_BLGoodsCode_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<
        }
        /// <summary>
        /// ＢＬコードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click ( object sender, EventArgs e )
        {
            // --- DEL 2008/10/20 -------------------------------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //BLGoodsCdUMnt blGoodsCdUMnt;
            //int status = this._goodsAcs.ExecuteBLGoodsCd( out blGoodsCdUMnt );
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tNedit_BLGoodsCode_St;
            //else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tNedit_BLGoodsCode_Ed;
            //else return;

            //targetControl.DataText = blGoodsCdUMnt.BLGoodsCode.ToString().TrimEnd();
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // --- ADD 2008/10/20 -------------------------------->>>>>
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
                this.tEdit_BLGoodsCode_St.DataText = bLGoodsCdUMnt.BLGoodsHalfName;  //ADD 2011/08/18
                this.tNedit_BLGoodsCode_Ed.Focus();
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLGoodsCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.tEdit_BLGoodsCode_Ed.DataText = bLGoodsCdUMnt.BLGoodsHalfName;  //ADD 2011/08/18
                this.tEdit_GoodsNo_St.Focus();
            }
            else
            {
                return;
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<
        }
        // --- DEL 2008/10/20 -------------------------------->>>>>
        ///// <summary>
        ///// 商品番号ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_GoodsNoGuid_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsGuid == null ) {
        //        this._goodsGuid = new MAKHN04110UA();
        //    }

        //    this._goodsUnitData = null;
        //    DialogResult status = this._goodsGuid.ShowGuide(this, this._enterpriseCode, out this._goodsUnitData);

        //    if ( status != DialogResult.OK ) return;

        //    TEdit targetControl;
        //    if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tEdit_GoodsNo_St;
        //    else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tEdit_GoodsNo_Ed;
        //    else return;

        //    targetControl.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
        //}
        // --- DEL 2008/10/20 --------------------------------<<<<<
        #endregion

        /// <summary>
        /// 数値項目開始脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_Leave ( object sender, EventArgs e )
        {
            // 空白の場合は初期値をセット
            if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
                ( ( TNedit ) sender ).SetInt(0);
            }
        }
        /// <summary>
        /// 数値項目終了脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_Leave ( object sender, EventArgs e )
        {
            // 空白の場合は初期値をセット
            if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
                ((TNedit)sender).SetInt(0);
            }
        }

		#region ◆ ueb_MainExplorerBar
		#region ◎ GroupCollapsing Event
		/// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) ||
                ( e.Group.Key == ct_ExBarGroupNm_ReportSortGroup )   ||
                ( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
			{
				// グループの縮小をキャンセル
				e.Cancel = true;
			}
		}
		#endregion

		#region ◎ GroupExpanding Event
		/// <summary>
		/// GroupExpanding Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) ||
                ( e.Group.Key == ct_ExBarGroupNm_ReportSortGroup )   ||
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}

		}
		#endregion

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            if ((e.PrevCtrl == this.tComboEditor_GoodsNoShowDiv) && (e.Key == Keys.Down))
            {
                e.NextCtrl = this.tComboEditor_SortOrderDiv;
            }
            else 
            {
                //なし
            }
            if (((e.PrevCtrl == this.tNedit_SupplierCd_Ed) || (e.PrevCtrl == this.ub_Ed_SuplierCdGuide)) && (e.Key == Keys.Up))
            {
                e.NextCtrl = this.tComboEditor_SortOrderDiv;
            }
            else
            {
                //なし
            }
            //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
            // --------------------- ADD 2011/08/18 ------------------- >>>>>
            // 仕入先
            if (e.PrevCtrl == this.tNedit_SupplierCd_St)
            {
                //仕入先コード取得
                string supplierCd = this.tNedit_SupplierCd_St.DataText;
                // 仕入先名称取得
                if (!string.IsNullOrEmpty(supplierCd))   
                    this.tEdit_SupplierCd_St.DataText = GetNameFromCode(supplierCd, 0);
                else
                    this.tEdit_SupplierCd_St.DataText = "";

            }

            if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
            {
                //仕入先コード取得
                string supplierCd = this.tNedit_SupplierCd_Ed.DataText;
                // 仕入先名称取得
                if (!string.IsNullOrEmpty(supplierCd))
                    this.tEdit_SupplierCd_Ed.DataText = GetNameFromCode(supplierCd, 0);
                else
                    this.tEdit_SupplierCd_Ed.DataText = "";
            }

            //メーカー
            if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsMakerCd_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_GoodsMakerCd_St.DataText = GetNameFromCode(code, 1);
                else
                    this.tEdit_GoodsMakerCd_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsMakerCd_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_GoodsMakerCd_Ed.DataText = GetNameFromCode(code, 1);
                else
                    this.tEdit_GoodsMakerCd_Ed.DataText = "";
            }

            //商品大分類
            if (e.PrevCtrl == this.tNedit_GoodsLGroup_St)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsLGroup_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_GoodsLGroup_St.DataText = GetNameFromCode(code, 2);
                else
                    this.tEdit_GoodsLGroup_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsLGroup_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsLGroup_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_GoodsLGroup_Ed.DataText = GetNameFromCode(code, 2);
                else
                    this.tEdit_GoodsLGroup_Ed.DataText = "";
            }

            //商品中分類
            if (e.PrevCtrl == this.tNedit_GoodsMGroup_St)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsMGroup_St.DataText;       
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_GoodsMGroup_St.DataText = GetNameFromCode(code, 3);
                else
                    this.tEdit_GoodsMGroup_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_GoodsMGroup_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_GoodsMGroup_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_GoodsMGroup_Ed.DataText = GetNameFromCode(code, 3);
                else
                    this.tEdit_GoodsMGroup_Ed.DataText = "";
            }

            //グループコード
            if (e.PrevCtrl == this.tNedit_BLGloupCode_St)
            {
                //メーカーコード取得
                string code = this.tNedit_BLGloupCode_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_BLGloupCode_St.DataText = GetNameFromCode(code, 4);
                else
                    this.tEdit_BLGloupCode_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_BLGloupCode_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_BLGloupCode_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_BLGloupCode_Ed.DataText = GetNameFromCode(code, 4);
                else
                    this.tEdit_BLGloupCode_Ed.DataText = "";
            }

            //BLコード
            if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
            {
                //メーカーコード取得
                string code = this.tNedit_BLGoodsCode_St.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_BLGoodsCode_St.DataText = GetNameFromCode(code, 5);
                else
                    this.tEdit_BLGoodsCode_St.DataText = "";
            }

            if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
            {
                //メーカーコード取得
                string code = this.tNedit_BLGoodsCode_Ed.DataText;
                //メーカー名称取得
                if (!string.IsNullOrEmpty(code))
                    this.tEdit_BLGoodsCode_Ed.DataText = GetNameFromCode(code, 5);
                else
                    this.tEdit_BLGoodsCode_Ed.DataText = "";
            }
            // --------------------- ADD 2011/08/18 ------------------- <<<<<
        }


		#endregion ◆ ueb_MainExplorerBar

        #region ◆ UI保存 書込・読込イベント
        /// <summary>
        /// UI保存コンポーネント書込みイベント
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/10/20</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[3];

            if (this.CheckEditor_SubtotalSection.Checked) customizeData[0] = "1";
            else customizeData[0] = "0";

            if (this.CheckEditor_SubtotalSuplier.Checked) customizeData[1] = "1";
            else customizeData[1] = "0";

            if (this.CheckEditor_SubtotalMaker.Checked) customizeData[2] = "1";
            else customizeData[2] = "0";
        }

        /// <summary>
        /// UI保存コンポーネント読込みイベント
        /// </summary>
        /// <param name="targetControls"></param>
        /// <param name="customizeData"></param>
        /// <remarks>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/10/20</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if (customizeData.Length > 0)
            {
                if (customizeData[0] == "1") this.CheckEditor_SubtotalSection.Checked = true;
                else this.CheckEditor_SubtotalSection.Checked = false;

                if (customizeData[1] == "1") this.CheckEditor_SubtotalSuplier.Checked = true;
                else this.CheckEditor_SubtotalSuplier.Checked = false;

                if (customizeData[2] == "1") this.CheckEditor_SubtotalMaker.Checked = true;
                else this.CheckEditor_SubtotalMaker.Checked = false;
            }
        }

        #endregion

        /// <summary>
        /// 集計方法　ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/10/20</br>
        /// </remarks>
        private void uos_TtlTypeDiv_ValueChanged(object sender, EventArgs e)
        {
            // --- ADD 2008/12/11 -------------------------------->>>>>
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

            this.uos_NewPageDiv.ResetValueList();

            this.SetNewPageDiv();

            this.uos_NewPageDiv.Value = tmpObj;

            if (this.uos_NewPageDiv.CheckedItem == null)
            {
                this.uos_NewPageDiv.CheckedIndex = 0;
            }

            if (this.uos_NewPageDiv.Items.Count == 1)
            {
                // 選択肢が一つしかない場合は選択不可
                this.uos_NewPageDiv.Enabled = false;
            }
            else
            {
                this.uos_NewPageDiv.Enabled = true;
            }

            // 順位付設定
            if ((int)this.uos_TtlTypeDiv.CheckedItem.DataValue == 0)
            {
                // 全社の場合、順位付設定単位を全社固定にする
                this.tComboEditor_RankSection.SelectedItem.DataValue = 0;
                this.tComboEditor_RankSection.Enabled = false;
            }
            else
            {
                this.tComboEditor_RankSection.Enabled = true;
            }
            // --- ADD 2008/12/11 --------------------------------<<<<<

            // 小計
            if ((int)this.uos_TtlTypeDiv.CheckedItem.DataValue == 0)
            {
                // 全社の場合、小計印刷「拠点」を不可に
                this.CheckEditor_SubtotalSection.Checked = false;
                this.CheckEditor_SubtotalSection.Enabled = false;
            }
            else
            {
                this.CheckEditor_SubtotalSection.Enabled = true;
            }
        }

        //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>
        /// 品番集計区分SelectionChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GoodsNoTtlDiv_ValueChanged(object sender, EventArgs e)
        {
            if (tComboEditor_GoodsNoTtlDiv.Value.Equals(0))
            {
                tComboEditor_GoodsNoShowDiv.Value = 0;
                tComboEditor_GoodsNoShowDiv.Enabled = false;
            }
            else 
            {
                tComboEditor_GoodsNoShowDiv.Value = 0;
                tComboEditor_GoodsNoShowDiv.Enabled = true;
            }
        }
        //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<

#if false
        #region ◆ ub_St_MainBfAfEnterWarehGuid
        #region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがクリックされたときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void ub_St_MainBfAfEnterWarehGuid_Click ( object sender, EventArgs e )
		{
			int status = 0;
			string sectionCode = "";
			if ( this._wareHouseAcs == null )
				this._wareHouseAcs = new WarehouseAcs();

			// Todo:ガイド呼び出し
			this._wareHouse = new Warehouse();
			
			// 選択拠点取得
			if ( ( ( (UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 ) || ( ( (UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 ) )
			{
				// 主倉庫コードの場合はスライダーの拠点コードをもとにガイド起動
				if ( this._selectedSectionList.Count == 1 )
				{
					foreach( DictionaryEntry de in this._selectedSectionList )
					{
						sectionCode = de.Value.ToString().TrimEnd();
					}
				}
			}
			else
			{
				// 絞込み倉庫コードの場合は絞り込み拠点コードをもとにガイド起動
				sectionCode = this.te_St_ExtractSectionCd.Text.TrimEnd();
			}
			status = this._wareHouseAcs.ExecuteGuid( out this._wareHouse, this._enterpriseCode, sectionCode);
			if ( status != 0 ) return;

			string tag = (string)((UltraButton)sender).Tag;
			TEdit targetControl = null;
			if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )		targetControl = this.te_St_MainBfAfEnterWarehCd;
			else if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )	targetControl = this.te_Ed_MainBfAfEnterWarehCd;
			else if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "3" ) == 0 )	targetControl = this.te_St_ExtractWareHouseCd;
			else if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "4" ) == 0 )	targetControl = this.te_Ed_ExtractWareHouseCd;
			else return;

			// コード展開
			targetControl.DataText = this._wareHouse.WarehouseCode.TrimEnd();
		}
        #endregion
        #endregion ◆ ub_St_MainBfAfEnterWarehGuid

        #region ◆ ub_St_ExtractSectionGuid
        #region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがクリックされたときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void ub_St_ExtractSectionGuid_Click ( object sender, EventArgs e )
		{
			int status = 0;
			string getCode = "";
			string sectionCode = "";

			if ( this._stockAnalysisOrderListCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
			{
				// 在庫移動時
				if ( this._secInfoSetAcs == null ) this._secInfoSetAcs = new SecInfoSetAcs();
				this._secInfoSet = null;

				status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out this._secInfoSet );

				if ( status != 0 ) return;

				getCode = this._secInfoSet.SectionCode.TrimEnd();
			}
			else
			{
				// 倉庫移動
				if ( this._wareHouseAcs == null ) this._wareHouseAcs = new WarehouseAcs();
				this._wareHouse = null;
				// 選択拠点取得
				if ( this._selectedSectionList.Count == 1 )
				{
					foreach( DictionaryEntry de in this._selectedSectionList )
					{
						sectionCode = de.Value.ToString().TrimEnd();
					}
				}

				status = this._wareHouseAcs.ExecuteGuid( out this._wareHouse, this._enterpriseCode, sectionCode);

				if ( status != 0 ) return;

				getCode = this._wareHouse.WarehouseCode.TrimEnd();
			}

			if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )		this.te_St_ExtractSectionCd.DataText = getCode;
			else if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 ) this.te_Ed_ExtractSectionCd.DataText = getCode;

			
			if ( this._stockAnalysisOrderListCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
			{
				// 在庫移動のときは倉庫移動のガイドの表示判断
				if ( ( this.te_St_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0 ) || ( this.te_Ed_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0 ) )
				{
				    ExtractWareHouseGuidSetProc( 
				        this.ub_St_ExtractWareHouseGuid, this.ub_Ed_ExtractWareHouseGuid, 
				        this.te_St_ExtractSectionCd.DataText, this.te_Ed_ExtractSectionCd.DataText );
				}
			}

		}
        #endregion
        #endregion ◆ ub_St_ExtractSectionGuid

        #region ◆ ub_St_MakerCodeGuid
        #region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがクリックされたときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void ub_St_MakerCodeGuid_Click ( object sender, EventArgs e )
		{
			if ( this._makerInfoAcs == null ) {	this._makerInfoAcs = new MakerAcs(); }
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._makerInfo = new Maker();
            this._makerInfo = new MakerUMnt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			int status = this._makerInfoAcs.ExecuteGuid( this._enterpriseCode, out this._makerInfo );

			if ( status != 0 ) return;

            if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) { this.tne_St_MakerCode.SetInt(this._makerInfo.GoodsMakerCd); }
            else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) { this.tne_Ed_MakerCode.SetInt(this._makerInfo.GoodsMakerCd); }
			else return;
		}
        #endregion
        #endregion ◆ ub_St_MakerCodeGuid

        #region ◆ ub_St_GoodsGuid
        #region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがクリックされたときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void ub_St_GoodsGuid_Click ( object sender, EventArgs e )
		{
			if ( this._goodsGuid == null )
			{
				this._goodsGuid = new MAKHN04110UA();
			}

			this._goodsUnitData = null;
			DialogResult status = this._goodsGuid.ShowGuide(this, this._enterpriseCode, out this._goodsUnitData );

			if ( status != DialogResult.OK ) return;

			if ( ( (UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )		{ this.te_St_GoodsCd.DataText = this._goodsUnitData.GoodsNo.TrimEnd(); }
            else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) { this.te_Ed_GoodsCd.DataText = this._goodsUnitData.GoodsNo.TrimEnd(); }
			else return;


		}
        #endregion
        #endregion ◆ ub_St_GoodsGuid

        #region ◆ tne_St_StockMoveSlipNo
        #region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void tne_St_StockMoveSlipNo_Leave ( object sender, EventArgs e )
		{
		    // 空白の場合は初期値をセット
		    if ( ( (TNedit)sender ).DataText == string.Empty )
		    {
		        ( (TNedit)sender ).SetInt( 0 );
		    }
		}
        #endregion
        #endregion ◆ tne_St_StockMoveSlipNo

        #region ◆ tne_Ed_StockMoveSlipNo
        #region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void tne_Ed_StockMoveSlipNo_Leave ( object sender, EventArgs e )
		{
			// 空白またはゼロの場合は初期値をセット
			if ( ( ( (TNedit)sender ).DataText == string.Empty ) || ( ( (TNedit)sender ).GetInt() == 0 ) ) 
			{
				( (TNedit)sender ).SetInt( 999999999 );
			}

		}
        #endregion
        #endregion ◆ tne_Ed_StockMoveSlipNo

        #region ◆ tne_St_MakerCode
        #region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void tne_St_MakerCode_Leave ( object sender, EventArgs e )
		{
		    // 空白の場合は初期値をセット
		    if ( ( (TNedit)sender ).DataText == string.Empty )
		    {
		        ( (TNedit)sender ).SetInt( 0 );
		    }
		}
        #endregion
        #endregion ◆ tne_St_MakerCode_Leave

        #region ◆ tne_Ed_MakerCode
        #region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void tne_Ed_MakerCode_Leave ( object sender, EventArgs e )
		{
		    // 空白の場合は初期値をセット
		    if ( ( ((TNedit)sender).DataText == string.Empty ) || ( ((TNedit)sender).GetInt() == 0 ) )
		    {
		        ((TNedit)sender).SetInt( 999 );
		    }

		}
        #endregion
        #endregion ◆ tne_Ed_MakerCode

        #region ◆ te_St_ExtractSectionCd
        #region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void te_St_ExtractSectionCd_Leave ( object sender, EventArgs e )
		{
			if ( this.te_St_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0 )
			{
				ExtractWareHouseGuidSetProc( 
					this.ub_St_ExtractWareHouseGuid, this.ub_Ed_ExtractWareHouseGuid, 
					this.te_St_ExtractSectionCd.DataText, this.te_Ed_ExtractSectionCd.DataText );
			}
		}
        #endregion
        #endregion ◆ te_St_ExtractSectionCd

        #region ◆ te_Ed_ExtractSectionCd
        #region ◎ Leave Event
		/// <summary>
		/// Leave Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールでなくなったときに発生する。</br>
        /// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.12.03</br>
        /// </remarks>
		private void te_Ed_ExtractSectionCd_Leave ( object sender, EventArgs e )
		{
			if ( this.te_Ed_ExtractSectionCd.DataText.TrimEnd().CompareTo( "" ) != 0 )
			{
				ExtractWareHouseGuidSetProc( 
					this.ub_St_ExtractWareHouseGuid, this.ub_Ed_ExtractWareHouseGuid, 
					this.te_St_ExtractSectionCd.DataText, this.te_Ed_ExtractSectionCd.DataText );
			}
		}
        #endregion
        #endregion ◆ te_Ed_ExtractSectionCd

#endif

        #endregion ■ Control Event

        
    }
}