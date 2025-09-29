//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫未出荷一覧表
// プログラム概要   : 在庫未出荷一覧表UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長沼 賢二
// 修 正 日  2008/07/17  修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/05  修正内容 : 不具合対応[12176]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/25  修正内容 : 不具合対応[12810]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 不具合対応[13104]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/24  修正内容 : 不具合対応[12996]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/24  修正内容 : 不具合対応[13587]
//----------------------------------------------------------------------------//
// 管理番号  11000127-00 作成担当 : cheny                                    
// 修 正 日  2014/08/11  修正内容 : redmine #43095 在庫未出荷一覧表画面表示不正
//---------------------------------------------------------------------------//
// 管理番号  11570226-00 作成担当 : 時シン
// 修 正 日  2019/11/06  修正内容 : PMKOBETSU-2425 対象年月の期間指定を３年とする対応
//---------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;   // ADD 2008/09/30 不具合対応[5710]
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/01 不具合対応[5710]
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
    /// 在庫未出荷一覧表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫未出荷一覧表UIフォームクラス</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>UpdateNote : 2008.07.17 30416 長沼 賢二</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12176]</br>
    /// <br>           : 2009/03/25       照田 貴志　不具合対応[12810]</br>
    /// <br>           : 2009/04/13       上野 俊治　不具合対応[13104]</br>
    /// <br>           : 2009/04/24       照田 貴志　不具合対応[12996]</br>
    /// <br>           : 2009/06/24       照田 貴志　不具合対応[13587]</br>
    /// <br>           : 2014/08/11       cheny　    redmine #43095 在庫未出荷一覧表画面表示不正</br>
    /// <br>Update Note: 2019/11/06 時シン</br>
    /// <br>管理番号   : 11570226-00 PMKOBETSU-2425 </br>
    /// <br>           : 対象年月の期間指定を３年とする対応</br>
    /// </remarks>
	public partial class DCZAI02161UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫未出荷一覧表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫未出荷一覧表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// <br></br>
		/// </remarks>
		public DCZAI02161UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();
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
        //--- ADD 2008/07/17 ---------->>>>>
        // 管理区分リスト
        private Hashtable _duplicationShelfNoList1 = new Hashtable();
        // 管理区分リスト
        private Hashtable _duplicationShelfNoList2 = new Hashtable();
        //--- ADD 2008/07/17 ----------<<<<<
		#endregion ◆ Interface member

		// 企業コード
		private string _enterpriseCode = "";
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
		private StockNoShipmentListCndtn _stockNoShipmentListCndtn;

        //// 拠点ガイド用
        //SecInfoSet _secInfoSet;
        //SecInfoSetAcs _secInfoSetAcs;

        // 倉庫ガイド用
        private Warehouse _wareHouse;
        private WarehouseAcs _wareHouseAcs;

        //--- DEL 2008/07/30 ---------->>>>>
        //// 仕入先ガイド用
        //private UltraButton _customerGuidSender = null;
        //private SFTOK01370UA _customerGuid;
        //private bool _customerGuideOK;
        //--- DEL 2008/07/30 ----------<<<<<

        // 商品コード用
        private GoodsAcs _goodsAcs;

        private BLGoodsCdAcs _bLGoodsCdAcs;// ADD BY cheny 2014/08/11 FOR redmine43095

        // DEL 2008/09/29 不具合対応[5708]---------->>>>>
        //private MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        //private GoodsUnitData _goodsUnitData;
        // DEL 2008/09/29 不具合対応[5708]----------<<<<<

        //// 担当者ガイド用
        //EmployeeAcs _employeeAcs;
        //Employee _employee;

        //--- DEL 2008/07/30 ---------->>>>>
        //// 在庫検索(自社分類ガイド用)
        //private SearchStockAcs _searchStockAcs;
        //--- DEL 2008/07/30 ----------<<<<<

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        //--- ADD 2008/07/17 ---------->>>>>
        // 仕入先
        SupplierAcs _supplierAcs;

        // 商品大分類
        UserGuideAcs _userGuideAcs;

        // 商品中分類
        GoodsGroupUAcs _goodsGroupUAcs;

        // BLグループ
        BLGroupUAcs _bLGroupUAcs;
        //--- ADD 2008/07/17 ----------<<<<<

        // ADD 2008/09/30 不具合対応[5710]---------->>>>>
        /// <summary>小計印刷ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _summalyPrintDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 小計印刷ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>小計印刷ラジオボタンのKeyPressイベントのヘルパ</value>
        private OptionSetKeyPressEventHelper SummalyPrintDivRadioKeyPressHelper
        {
            get { return _summalyPrintDivRadioKeyPressHelper; }
        }

        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly RadioKeyPressEventHelper _newPageDivRadioKeyPressHelper = new RadioKeyPressEventHelper();
        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        private RadioKeyPressEventHelper NewPageDivRadioKeyPressHelper
        {
            get { return _newPageDivRadioKeyPressHelper; }
        }

        /// <summary>出力順ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _printSortDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 出力順ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>出力順ラジオボタンのKeyPressイベントのヘルパ</value>
        private OptionSetKeyPressEventHelper PrintSortDivRadioKeyPressHelper
        {
            get { return _printSortDivRadioKeyPressHelper; }
        }
        // ADD 2008/09/30 不具合対応[5710]----------<<<<<

        // ADD 2008/10/07 不具合対応[5692]---------->>>>>
        /// <summary>範囲指定ガイドのフォーカス制御オブジェクトのリスト</summary>
        private readonly IList<GeneralRangeGuideUIController> _rangeGuideControllerList = new List<GeneralRangeGuideUIController>();
        /// <summary>
        /// 範囲指定ガイドのフォーカス制御オブジェクトのリストを取得します。
        /// </summary>
        /// <value>範囲指定ガイドのフォーカス制御オブジェクトのリスト</value>
        private IList<GeneralRangeGuideUIController> RangeGuideControllerList
        {
            get { return _rangeGuideControllerList; }
        }
        // ADD 2008/10/07 不具合対応[5692]----------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID         = "DCZAI02161UA";
		// プログラムID
        private const string ct_PGID            = "DCZAI02161U";
		//// 帳票名称
		private string _printName				= "在庫未出荷一覧表";
        // 帳票キー	
        private string _printKey                = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// 抽出条件

        private const string CtTextMessage = "対象年月の範囲が広いため、処理が遅くなる可能性があります。" + "\r\n" + "よろしいですか？"; // ADD 2019/11/06 時シン PMKOBETSU-2425 対象年月の期間指定を３年とする対応
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
        /// <br>Date		: 2007.09.19</br>
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
			printInfo.jyoken			= this._stockNoShipmentListCndtn;
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>Note        : 対象年月の期間指定を３年とする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2019/11/06</br>
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
            //----- ADD 2019/11/06 時シン PMKOBETSU-2425 対象年月の期間指定を３年とする対応 ----->>>>>
            // チェックOKの場合
            else
            {
                DateGetAcs.CheckDateRangeResult cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, false);
                
                // 対象年月が1年より大きくなった場合
                if (cdrResult != DateGetAcs.CheckDateRangeResult.OK)
                {
                    // 確定処理確認
                    DialogResult result = TMsgDisp.Show(
                        this,                                           // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_QUESTION,                // エラーレベル
                        ct_ClassID,                                     // アセンブリＩＤまたはクラスＩＤ
                        CtTextMessage,                 　               // 表示するメッセージ
                        0,                                              // ステータス値
                        MessageBoxButtons.YesNo,                        // メッセージ ボックスに [はい] ボタンと [いいえ] ボタンを含めます
                        MessageBoxDefaultButton.Button1);               // 表示するボタン

                    if (result != DialogResult.Yes)
                    {
                        status = false;
                    }
                }
            }
            //----- ADD 2019/11/06 時シン PMKOBETSU-2425 対象年月の期間指定を３年とする対応 -----<<<<<

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
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void Show ( object parameter )
		{
            this._stockNoShipmentListCndtn = new StockNoShipmentListCndtn();

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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 倉庫ガイドEnabled設定
            //// 拠点リストの要素が1つだけで1番目の要素が全社ではないときにTrueになる。
            //if ( ( this._selectedSectionList.Count == 1 ) && ( !this._selectedSectionList.ContainsKey( "0" ) ) )
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_WarehouseCodeGuide, this.ub_Ed_WarehouseCodeGuide, 
            //        string.Empty, string.Empty );
            //}
            //else
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_WarehouseCodeGuide, this.ub_Ed_WarehouseCodeGuide, 
            //        "0", string.Empty );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public bool InitVisibleCheckSection ( bool isDefaultState )
		{
            //return isDefaultState;            //DEL 2009/04/24 不具合対応[12996]
            return false;                       //ADD 2009/04/24 不具合対応[12996]
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
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // 初期値セット・日付
                this.tde_StockCreateDate.SetDateTime(TDateTime.GetSFDateNow());
                //this.tde_St_AddUpYearMonth.SetDateTime(TDateTime.GetSFDateNow());
                //this.tde_Ed_AddUpYearMonth.SetDateTime(TDateTime.GetSFDateNow());
                //// (年月日yyyyMMdd→年月yyyyMM→年月日yyyyMM01に変換)
                //this.tde_St_AddUpYearMonth.LongDate = this.tde_St_AddUpYearMonth.LongDate / 100 * 100 + 1;
                //this.tde_Ed_AddUpYearMonth.LongDate = this.tde_Ed_AddUpYearMonth.LongDate / 100 * 100 + 1;
                /* ---DEL 2009/03/05 不具合対応[12176] -------------------------------->>>>>
                DateTime thisMonth;
                _dateGetAcs.GetThisYearMonth( out thisMonth );
                this.tde_St_AddUpYearMonth.SetDateTime( thisMonth );
                this.tde_Ed_AddUpYearMonth.SetDateTime( thisMonth );
                   ---DEL 2009/03/05 不具合対応[12176] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12176] -------------------------------->>>>>
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
                    this.tde_St_AddUpYearMonth.SetDateTime(currentTotalMonth);
                    this.tde_Ed_AddUpYearMonth.SetDateTime(currentTotalMonth);
                }
                else
                {
                    // 当月を設定
                    DateTime nowYearMonth;
                    this._dateGetAcs.GetThisYearMonth(out nowYearMonth);

                    this.tde_St_AddUpYearMonth.SetDateTime(nowYearMonth);
                    this.tde_Ed_AddUpYearMonth.SetDateTime(nowYearMonth);
                }
                // ---ADD 2009/03/05 不具合対応[12176] --------------------------------<<<<<

                // 初期値セット・文字列
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                this.tEdit_WarehouseShelfNo_St.DataText = string.Empty;
                this.tEdit_WarehouseShelfNo_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;


                // 初期値セット・数値
                //--- DEL 2008/07/17 ---------->>>>>
                //this.tne_St_CustomerCode.SetInt( 0 );
                //this.tne_Ed_CustomerCode.SetInt( 0 );
                //--- DEL 2008/07/17 ----------<<<<<
                //this.tne_Ed_CustomerCode.SetInt(Int32.Parse(new string('9', this.tne_Ed_CustomerCode.ExtEdit.Column)));

                //--- DEL 2008/07/17 ---------->>>>>
                //this.tne_St_GoodsMakerCd.SetInt(0);
                //this.tne_Ed_GoodsMakerCd.SetInt( 0 );
                //--- DEL 2008/07/17 ----------<<<<<
                //this.tne_Ed_GoodsMakerCd.SetInt(Int32.Parse(new string('9', this.tne_Ed_GoodsMakerCd.ExtEdit.Column)));

                //--- DEL 2008/07/17 ---------->>>>>
                //this.tne_St_BLGoodsCode.SetInt(0);
                //this.tne_Ed_BLGoodsCode.SetInt( 0 );
                //--- DEL 2008/07/17 ----------<<<<<
                //this.tne_Ed_BLGoodsCode.SetInt(Int32.Parse(new string('9', this.tne_Ed_BLGoodsCode.ExtEdit.Column)));

                // 初期値セット・区分
                this.uos_SummalyPrintDiv.Value = 0;
                this.NewPageDivValue = 0;
                //this.ce_PrintSortDiv.Value = 0;       // DEL 2008.07.17
                this.uos_PrintSortDiv.Value = 0;        // ADD 2008.07.17
                this.ce_StockCreateDateDiv.Value = 0;
                this.ce_WarehouseShelfNoBreakDiv.Value = 0;


                // ボタン設定
                this.SetIconImage( this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_CustomerCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_CustomerCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_LargeGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_LargeGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_MediumGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_MediumGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_DetailGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_DetailGoodsGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_EnterpriseGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_EnterpriseGanreCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1 );

                // DEL 2008/09/29 不具合対応[5708]---------->>>>>
                //this.SetIconImage( this.ub_St_GoodsNoGuide, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_GoodsNoGuide, Size16_Index.STAR1 );
                // DEL 2008/09/29 不具合対応[5708]----------<<<<<

                // 初期フォーカスセット
                //this.tde_StockCreateDate.Focus();     // DEL 2008.07.17
                this.tde_St_AddUpYearMonth.Focus();     // ADD 2008.07.17
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
        /// <br>Date		: 2007.09.19</br>
        /// <br>Note        : 対象年月の期間指定を３年とする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2019/11/06</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;
            DateGetAcs.CheckDateResult cdResult;

			const string ct_InputError = "の入力が不正です";
			const string ct_NoInput	   = "を入力して下さい";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            //----- UPD 2019/11/06 時シン PMKOBETSU-2425 対象年月の期間指定を３年とする対応 ----->>>>>
            //const string ct_FullRangeError = "は１２ヶ月の範囲内で入力して下さい";
            const string ct_FullRangeError = "は３６ヶ月の範囲内で入力して下さい";
            //----- UPD 2019/11/06 時シン PMKOBETSU-2425 対象年月の期間指定を３年とする対応 -----<<<<<

            // 在庫登録日
            if ( CallCheckDate( out cdResult, ref tde_StockCreateDate ) == false )
            {
                switch ( cdResult )
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format( "在庫登録日{0}", ct_NoInput );
                            errComponent = this.tde_StockCreateDate;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format( "在庫登録日{0}", ct_InputError );
                            errComponent = this.tde_StockCreateDate;
                        }
                        break;
                }
                status = false;
            }
            // 対象年月（開始～終了）
            else if ( CallCheckDateRange( out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth ) == false )
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
            // 倉庫コード
            else if (
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo( this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("倉庫コード{0}", ct_RangeError);       // DEL 2008.07.17
                errMessage = string.Format("倉庫{0}", ct_RangeError);               // ADD 2008.07.17
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // 仕入先（開始 > 終了 → NG）
            else if ( this.tNedit_SupplierCd_St.GetInt() > GetEndCode( this.tNedit_SupplierCd_Ed ) )
            {
                errMessage = string.Format( "仕入先{0}", ct_RangeError );
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // メーカー（開始 > 終了 → NG）
            else if ( this.tNedit_GoodsMakerCd_St.GetInt() > GetEndCode( this.tNedit_GoodsMakerCd_Ed ) )
            {
                //errMessage = string.Format("メーカーコード{0}", ct_RangeError);   // DEL 2008.07.17
                errMessage = string.Format("メーカー{0}", ct_RangeError);           // ADD 2008.07.17
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 棚番
            else if (
               (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo( this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() ) > 0) )
            {
                errMessage = string.Format( "棚番{0}", ct_RangeError );
                errComponent = this.tEdit_WarehouseShelfNo_St;
                status = false;
            }
            // 商品区分グループ
            else if (
           (this.tNedit_GoodsLGroup_St.DataText.TrimEnd() != string.Empty) &&
           (this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() != string.Empty) &&
           (this.tNedit_GoodsLGroup_St.DataText.TrimEnd().CompareTo( this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("商品区分グループ{0}", ct_RangeError); // DEL 2008.07.17
                errMessage = string.Format("商品大分類{0}", ct_RangeError);         // ADD 2008.07.17
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // 商品区分
            else if (
                (this.tNedit_GoodsMGroup_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsMGroup_St.DataText.TrimEnd().CompareTo( this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("商品区分{0}", ct_RangeError);         // DEL 2008.07.17
                errMessage = string.Format("商品中分類{0}", ct_RangeError);         // ADD 2008.07.17
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // 商品区分詳細
            else if (
                (this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_BLGloupCode_St.DataText.TrimEnd().CompareTo( this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format( "商品区分詳細{0}", ct_RangeError );   // DEL 2008.07.17
                errMessage = string.Format("グループコード{0}", ct_RangeError);     // ADD 2008.07.17
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // 自社分類（開始 > 終了 → NG）
            else if ( this.tNedit_EnterpriseGanreCode_St.GetInt() > GetEndCode( this.tNedit_EnterpriseGanreCode_Ed ) )
            {
                //errMessage = string.Format("自社分類{0}", ct_RangeError);         // DEL 2008.07.17
                errMessage = string.Format("商品区分{0}", ct_RangeError);           // ADD 2008.07.17
                errComponent = this.tNedit_EnterpriseGanreCode_St;
                status = false;
            }
            // ＢＬ商品コード（開始 > 終了 → NG）
            else if ( this.tNedit_BLGoodsCode_St.GetInt() > GetEndCode( this.tNedit_BLGoodsCode_Ed ) )
            {
                //errMessage = string.Format("ＢＬ商品コード{0}", ct_RangeError);   // DEL 2008.07.17
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);         // ADD 2008.07.17
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            // 商品番号
            else if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
            (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("商品番号{0}", ct_RangeError);         // DEL 2008.07.17
                errMessage = string.Format("品番{0}", ct_RangeError);               // ADD 2008.07.17
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }


            return status;
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate( out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit )
        {
            cdResult = _dateGetAcs.CheckDate( ref targetDateEdit, false );
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult">チェック結果</param>
        /// <param name="startDate">開始日付</param>
        /// <param name="endDate">終了日付</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note        : 対象年月の期間指定を３年とする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2019/11/06</br>
        /// </remarks>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate )
        {
            //----- UPD 2019/11/06 時シン PMKOBETSU-2425 対象年月の期間指定を３年とする対応 ----->>>>>
            //cdrResult = _dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 12, ref startDate, ref endDate, false, false );
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 36, ref startDate, ref endDate, false, false);
            //----- UPD 2019/11/06 時シン PMKOBETSU-2425 対象年月の期間指定を３年とする対応 -----<<<<<
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
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
        /// <br>Date		: 2007.09.19</br>
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
			if( targetDateEdit.GetDateTime() == DateTime.MinValue )
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                // ---DEL 2009/04/24 不具合対応[12996] ------------------------------->>>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //// 「全拠点」が選択されている場合はリストをクリア
                //bool allSections = false;

                //foreach ( object obj in _selectedSectionList.Values )
                //{
                //    if ( obj is string )
                //    {
                //        if ( (obj as string) == "0" )
                //        {
                //            allSections = true;
                //            break;
                //        }
                //    }
                //}
                //if ( allSections )
                //{
                //    _selectedSectionList.Clear();
                //}
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                // ---DEL 2009/04/24 不具合対応[12996] ------------------------------->>>>>
                _selectedSectionList.Clear();           //ADD 2009/04/24 不具合対応[12996]

                // 拠点オプション
                this._stockNoShipmentListCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                this._stockNoShipmentListCndtn.EnterpriseCode = this._enterpriseCode;
                // 開始年月度
                this.tde_St_AddUpYearMonth.LongDate = this.tde_St_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMMdd → YYYYMM01
                this._stockNoShipmentListCndtn.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                // 終了年月度
                this.tde_Ed_AddUpYearMonth.LongDate = this.tde_Ed_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMMdd → YYYYMM01
                this._stockNoShipmentListCndtn.Ed_AddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // 拠点コード
                this._stockNoShipmentListCndtn.SectionCodes = ( string[] ) new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 開始倉庫コード
                this._stockNoShipmentListCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;
                // 終了倉庫コード
                this._stockNoShipmentListCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;
                // 開始仕入先コード
                this._stockNoShipmentListCndtn.St_CustomerCode = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                //this._stockNoShipmentListCndtn.Ed_CustomerCode = GetEndCode(this.tne_Ed_CustomerCode, 999999999);     // DEL 2008.07.17
                this._stockNoShipmentListCndtn.Ed_CustomerCode = GetEndCode(this.tNedit_SupplierCd_Ed, 99999999);        // ADD 2008.07.17
                // 開始商品メーカーコード
                this._stockNoShipmentListCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了商品メーカーコード
                //this._stockNoShipmentListCndtn.Ed_GoodsMakerCd = GetEndCode(tne_Ed_GoodsMakerCd, 999999);             // DEL 2008.07.17
                this._stockNoShipmentListCndtn.Ed_GoodsMakerCd = GetEndCode(tNedit_GoodsMakerCd_Ed, 999999);                 // ADD 2008.07.17
                // 開始倉庫棚番
                this._stockNoShipmentListCndtn.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.Text;
                // 終了倉庫棚番
                this._stockNoShipmentListCndtn.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.Text;
                // 開始ＢＬ商品コード
                this._stockNoShipmentListCndtn.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                // 終了ＢＬ商品コード
                //this._stockNoShipmentListCndtn.Ed_BLGoodsCode = GetEndCode(this.tne_Ed_BLGoodsCode, 99999999);        // DEL 2008.07.17
                this._stockNoShipmentListCndtn.Ed_BLGoodsCode = GetEndCode(this.tNedit_BLGoodsCode_Ed, 99999999);             // ADD 2008.07.17
                // 開始商品番号
                this._stockNoShipmentListCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.Text;
                // 終了商品番号
                this._stockNoShipmentListCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text;

                // 在庫登録日
                this._stockNoShipmentListCndtn.StockCreateDate = this.tde_StockCreateDate.GetDateTime();
                // 在庫登録日指定区分
                this._stockNoShipmentListCndtn.StockCreateDateDiv = ( StockNoShipmentListCndtn.StockCreateDateDivState) this.ce_StockCreateDateDiv.SelectedIndex;

                // 改ページ区分
                this._stockNoShipmentListCndtn.NewPageDiv = (StockNoShipmentListCndtn.NewPageDivState)this.NewPageDivValue;
                // 小計印刷区分
                this._stockNoShipmentListCndtn.SummalyPrintDiv = (StockNoShipmentListCndtn.SummalyPrintDivState)this.uos_SummalyPrintDiv.Value;
                // 印刷順区分
                //this._stockNoShipmentListCndtn.PrintSortDiv = (StockNoShipmentListCndtn.PrintSortDivState)this.ce_PrintSortDiv.Value;     // DEL 2008.07.17
                this._stockNoShipmentListCndtn.PrintSortDiv = (StockNoShipmentListCndtn.PrintSortDivState)this.uos_PrintSortDiv.Value;       // ADD 2008.07.17
                // 棚番ブレイク区分
                this._stockNoShipmentListCndtn.WarehouseShelfNoBreakDiv = (StockNoShipmentListCndtn.WarehouseShelfNoBreakDivState)this.ce_WarehouseShelfNoBreakDiv.Value;

                // 開始商品区分グループコード
                this._stockNoShipmentListCndtn.St_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_St.Text;
                // 終了商品区分グループコード
                this._stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_Ed.Text;
                // 開始商品区分コード
                this._stockNoShipmentListCndtn.St_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_St.Text;
                // 終了商品区分コード
                this._stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_Ed.Text;
                // 開始商品区分詳細コード
                this._stockNoShipmentListCndtn.St_DetailGoodsGanreCode = this.tNedit_BLGloupCode_St.Text;
                // 終了商品区分詳細コード
                this._stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode = this.tNedit_BLGloupCode_Ed.Text;
                // 開始自社分類コード
                this._stockNoShipmentListCndtn.St_EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode_St.GetInt();
                // 終了自社分類コード
                this._stockNoShipmentListCndtn.Ed_EnterpriseGanreCode = GetEndCode( this.tNedit_EnterpriseGanreCode_Ed, 999999 );

                //--- ADD 2008/07/17 ---------->>>>>
                // 部品管理区分１
                this._duplicationShelfNoList1.Clear();
                for (int index = 0; index < this.clb_DuplicationShelfNo1.Items.Count; index++)
                {
                    // チェック有無取得
                    if (this.clb_DuplicationShelfNo1.GetItemChecked(index) == true)
                    {
                        this._duplicationShelfNoList1.Add(index.ToString(), index.ToString());
                    }
                }
                this._stockNoShipmentListCndtn.PartsManagementDivide1 = (string[])new ArrayList(this._duplicationShelfNoList1.Values).ToArray(typeof(string));

                // 部品管理区分２
                this._duplicationShelfNoList2.Clear();
                for (int index = 0; index < this.clb_DuplicationShelfNo2.Items.Count; index++)
                {
                    // チェック有無取得
                    if (this.clb_DuplicationShelfNo2.GetItemChecked(index) == true)
                    {
                        this._duplicationShelfNoList2.Add(index.ToString(), index.ToString());
                    }
                }
                this._stockNoShipmentListCndtn.PartsManagementDivide2 = (string[])new ArrayList(this._duplicationShelfNoList2.Values).ToArray(typeof(string));
                //--- ADD 2008/07/17 ----------<<<<<
			}
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
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
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.03.24</br>
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
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.03.24</br>
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
		#endregion ■ Private Method

		#region ■ Control Event
        #region ◆ DCZAI02161UA
        #region ◎ DCZAI02161UA_Load Event
        /// <summary>
        /// DCZAI02161UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void DCZAI02161UA_Load ( object sender, EventArgs e )
		{
			string errMsg = string.Empty;

			// コントロール初期化
			int status = this.InitializeScreen( out errMsg );
			if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}

			// 画面イメージ統一
			this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

			ParentToolbarSettingEvent( this );						// ツールバーボタン設定イベント起動

            // ADD 2008/09/30 不具合対応[5710]---------->>>>>
            // スペースキーの制御オブジェクトを設定
            SummalyPrintDivRadioKeyPressHelper.ControlList.Add(this.uos_SummalyPrintDiv);
            SummalyPrintDivRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.rb_NewPageDivEachSummaly);
            NewPageDivRadioKeyPressHelper.ControlList.Add(this.rb_NewPageDivNone);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();

            PrintSortDivRadioKeyPressHelper.ControlList.Add(this.uos_PrintSortDiv);
            PrintSortDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2008/09/30 不具合対応[5710]----------<<<<<

            this.SetDuplicationShelfNo(clb_DuplicationShelfNo1, 72);        //ADD 2009/06/24 不具合対応[13587]
            this.SetDuplicationShelfNo(clb_DuplicationShelfNo2, 73);        //ADD 2009/06/24 不具合対応[13587]

            // ADD 2008/10/07 不具合対応[5692]---------->>>>>
            // 範囲指定ガイドのフォーカス制御オブジェクトの設定
            // 倉庫：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_WarehouseCode_St,
                this.ub_St_WarehouseCodeGuide,
                this.tEdit_WarehouseCode_Ed
            ));
            // 倉庫：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_WarehouseCode_Ed,
                this.ub_Ed_WarehouseCodeGuide,
                this.tNedit_SupplierCd_St
            ));

            // 仕入先：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_St,
                this.ub_St_CustomerCodeGuide,
                this.tNedit_SupplierCd_Ed
            ));
            // 仕入先：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_Ed,
                this.ub_Ed_CustomerCodeGuide,
                this.tNedit_GoodsMakerCd_St
            ));

            // メーカー：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_GoodsMakerCd_St,
                this.ub_St_GoodsMakerCdGuide,
                this.tNedit_GoodsMakerCd_Ed
            ));
            // メーカー：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_GoodsMakerCd_Ed,
                this.ub_Ed_GoodsMakerCdGuide,
                this.tEdit_WarehouseShelfNo_St
            ));

            // 商品大分類：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_GoodsLGroup_St,
                this.ub_St_LargeGoodsGanreCodeGuide,
                this.tNedit_GoodsLGroup_Ed
            ));
            // 商品大分類：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_GoodsLGroup_Ed,
                this.ub_Ed_LargeGoodsGanreCodeGuide,
                this.tNedit_GoodsMGroup_St
            ));

            // 商品中分類：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_GoodsMGroup_St,
                this.ub_St_MediumGoodsGanreCodeGuide,
                this.tNedit_GoodsMGroup_Ed
            ));
            // 商品中分類：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_GoodsMGroup_Ed,
                this.ub_Ed_MediumGoodsGanreCodeGuide,
                this.tNedit_BLGloupCode_St
            ));

            // グループコード：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_BLGloupCode_St,
                this.ub_St_DetailGoodsGanreCodeGuide,
                this.tNedit_BLGloupCode_Ed
            ));
            // グループコード：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_BLGloupCode_Ed,
                this.ub_Ed_DetailGoodsGanreCodeGuide,
                this.tNedit_EnterpriseGanreCode_St
            ));

            // 商品区分：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_EnterpriseGanreCode_St,
                this.ub_St_EnterpriseGanreCodeGuide,
                this.tNedit_EnterpriseGanreCode_Ed
            ));
            // 商品区分：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_EnterpriseGanreCode_Ed,
                this.ub_Ed_EnterpriseGanreCodeGuide,
                this.tNedit_BLGoodsCode_St
            ));

            // BLコード：開始
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_BLGoodsCode_St,
                this.ub_St_BLGoodsCodeGuide,
                this.tNedit_BLGoodsCode_Ed
            ));
            // BLコード：終了
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_BLGoodsCode_Ed,
                this.ub_Ed_BLGoodsCodeGuide,
                this.tEdit_GoodsNo_St
            ));

            foreach (GeneralRangeGuideUIController rangeGuideController in RangeGuideControllerList)
            {
                rangeGuideController.StartControl();
            }
            // ADD 2008/10/07 不具合対応[5692]----------<<<<<
		}
		#endregion

        #endregion ◆ DCZAI02161UA

        // ---ADD 2009/06/24 不具合対応[13587] --------------------------->>>>>
        /// <summary>
        /// 管理区分名称設定
        /// </summary>
        /// <param name="control">対象コントロール</param>
        /// <param name="guideDivCode">ガイド区分</param>
        private void SetDuplicationShelfNo(CheckedListBox control, int guideDivCode)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            //初期化
            for (int i = 0; i < 10; i++)
            {
                control.Items[i] = "未登録";
            }

            //読み込み
            ArrayList arrayList = null;
            int status = this._userGuideAcs.SearchDivCodeBody(out arrayList, this._enterpriseCode, guideDivCode, UserGuideAcsData.UserBodyData);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }
            if (arrayList == null)
            {
                return;
            }
            if (arrayList.Count == 0)
            {
                return;
            }

            //名称セット
            UserGdBd userGdBd = null;
            for (int i = 0; i < arrayList.Count; i++)
            {
                userGdBd = (UserGdBd)arrayList[i];
                if ((0 <= userGdBd.GuideCode) || (userGdBd.GuideCode <= 9))
                {
                    control.Items[userGdBd.GuideCode] = userGdBd.GuideName;
                }
            }
        }
        // ---ADD 2009/06/24 不具合対応[13587] ---------------------------<<<<<

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ub_St_WarehouseCodeGuide_Click ( object sender, EventArgs e )
        {
            int status = 0;
            string sectionCode = "";
            if ( this._wareHouseAcs == null )
                this._wareHouseAcs = new WarehouseAcs();

            this._wareHouse = new Warehouse();

            // ---DEL 2009/04/24 不具合対応[12996] ---------------------------------------->>>>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////// スライダーの拠点コードをもとにガイド起動
            ////if ( this._selectedSectionList.Count == 1 ) {
            ////    foreach ( DictionaryEntry de in this._selectedSectionList ) {
            ////        sectionCode = de.Value.ToString().TrimEnd();
            ////    }
            ////}

            //// 倉庫ガイド用の拠点コードを取得
            //sectionCode = GetWarehouseGuideSection( this._selectedSectionList );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // ---DEL 2009/04/24 不具合対応[12996] ----------------------------------------<<<<<

            status = this._wareHouseAcs.ExecuteGuid(out this._wareHouse, this._enterpriseCode, sectionCode);
            if ( status != 0 ) return;

            string tag = ( string ) ( ( UltraButton ) sender ).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            {
                targetControl = this.tEdit_WarehouseCode_St;
                nextControl = this.tEdit_WarehouseCode_Ed;
            }
            else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            {
                targetControl = this.tEdit_WarehouseCode_Ed;
                nextControl = this.tNedit_SupplierCd_St;
            }
            else
            {
                return;
            }

            // コード展開
            targetControl.DataText = this._wareHouse.WarehouseCode.TrimEnd();

            // フォーカス
            nextControl.Focus();
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 倉庫ガイド用拠点コード取得処理
        /// </summary>
        /// <param name="selectedSectionList"></param>
        /// <returns>倉庫ガイド用の指定拠点コード</returns>
        /// <remarks>
        /// <br>出力対象拠点の選択状況に応じて、拠点コードを返します</br>
        /// </remarks>
        private string GetWarehouseGuideSection( Hashtable selectedSectionList )
        {
            if ( selectedSectionList.Count >= 2 )
            {
                // 複数拠点が選択されていたら、未指定
                return string.Empty;
            }
            else if ( selectedSectionList.Count == 0 )
            {
                // 拠点が選択されていなければ、未指定
                return string.Empty;
            }
            else if ( selectedSectionList.Contains( "0" ) )
            {
                // 「全拠点」が選択されていたら、未指定
                return string.Empty;
            }

            // 選択されている拠点コードを返す
            foreach ( object obj in selectedSectionList.Values )
            {
                if ( obj is string )
                {
                    return (obj as string);
                }
            }

            return string.Empty;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_CustomerCodeGuide_Click( object sender, EventArgs e )
        {
            //--- DEL 2008/07/30 ---------->>>>>
            //_customerGuideOK = false;

            //try
            //{
            //    this._customerGuid = new SFTOK01370UA( SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY );
            //    this._customerGuid.CustomerSelect += new CustomerSelectEventHandler( this.CustomerSelected );

            //    this._customerGuidSender = (UltraButton)sender;
            //    this._customerGuid.ShowDialog( this );
            //    this._customerGuidSender = null;

            //    this._customerGuid.Dispose();

            //    if ( _customerGuideOK )
            //    {
            //        if ( sender == this.ub_St_CustomerCodeGuide )
            //        {
            //            this.tne_Ed_CustomerCode.Focus();
            //        }
            //        else
            //        {
            //            this.tne_St_GoodsMakerCd.Focus();
            //        }
            //    }
            //}
            //catch ( Exception )
            //{
            //}
            //--- DEL 2008/07/30 ----------<<<<<

            //--- ADD 2008/07/30 ---------->>>>>
            if (this._supplierAcs == null)
            {
                this._supplierAcs = new SupplierAcs();
            }

            Supplier supplier = new Supplier();

            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "");

            if (status != 0) return;

            TNedit targetControl;   // MOD 2008/09/30 不具合対応[5698] TEdit→TNedit
            Control nextControl = null;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SupplierCd_St;
                nextControl = this.tNedit_SupplierCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SupplierCd_Ed;
                nextControl = this.tNedit_GoodsMakerCd_St;
            }
            else
            {
                return;
            }

            // DEL 2008/09/30 不具合対応[5698]↓
            //targetControl.DataText = supplier.SupplierCd.ToString();
            targetControl.SetInt(supplier.SupplierCd);  // ADD 2008/09/30 不具合対応[5698]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/30 ----------<<<<<
        }
        //--- DEL 2008/07/30 ---------->>>>>
        ///// <summary>
        ///// 仕入先検索選択結果イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="customerSearchRet"></param>
        //private void CustomerSelected( object sender, CustomerSearchRet customerSearchRet )
        //{
        //    try
        //    {
        //        if ( _customerGuidSender != null )
        //        {
        //            TNedit targetControl = null;
        //            if ( _customerGuidSender.Tag.ToString().CompareTo( "1" ) == 0 )
        //            {
        //                targetControl = this.tne_St_CustomerCode;
        //            }
        //            else if ( _customerGuidSender.Tag.ToString().CompareTo( "2" ) == 0 )
        //            {
        //                targetControl = this.tne_Ed_CustomerCode;
        //            }
        //            else
        //            {
        //                return;
        //            }

        //            targetControl.SetInt( customerSearchRet.CustomerCode );
        //            _customerGuideOK = true;
        //        }
        //    }
        //    catch ( Exception )
        //    {
        //    }
        //}
        //--- DEL 2008/07/30 ---------->>>>>

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerCdGuide_Click( object sender, EventArgs e )
        {
            if ( this._goodsAcs == null )
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            }

            MakerUMnt maker;
            int status = this._goodsAcs.ExecuteMakerGuid( this._enterpriseCode, out maker );
            if ( status != 0 )
                return;

            TNedit targetControl;
            Control nextControl;
            if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                nextControl = this.tEdit_WarehouseShelfNo_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt( maker.GoodsMakerCd );
            nextControl.Focus();
        }

        /// <summary>
        /// 商品大分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_LargeGoodsGanreCodeGuide_Click( object sender, EventArgs e )
        {
            //--- DEL 2008/07/17 ---------->>>>>
            //if ( this._goodsAcs == null )
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            //}

            //LGoodsGanre lGoodsGanre;
            //int status = this._goodsAcs.ExecuteLGoodsGanreGuid( this._enterpriseCode, out lGoodsGanre );
            //if ( status != 0 )
            //    return;

            //TEdit targetControl;
            //Control nextControl;
            //if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            //{
            //    targetControl = this.te_St_LargeGoodsGanreCode;
            //    nextControl = this.te_Ed_LargeGoodsGanreCode;
            //}
            //else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            //{
            //    targetControl = this.te_Ed_LargeGoodsGanreCode;
            //    nextControl = this.te_St_MediumGoodsGanreCode;
            //}
            //else
            //{
            //    return;
            //}

            //targetControl.DataText = lGoodsGanre.LargeGoodsGanreCode.ToString().TrimEnd();
            //nextControl.Focus();
            //--- DEL 2008/07/17 ----------<<<<<

            //--- ADD 2008/07/17 ---------->>>>>
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status != 0) return;

            TNedit targetControl;   // MOD 2008/09/30 不具合対応[5698] TEdit→TNedit
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsLGroup_St;
                nextControl = this.tNedit_GoodsLGroup_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsLGroup_Ed;
                nextControl = this.tNedit_GoodsMGroup_St;
            }
            else
            {
                return;
            }

            // DEL 2008/09/30 不具合対応[5698]↓
            //targetControl.DataText = userGdBd.GuideCode.ToString();
            targetControl.SetInt(userGdBd.GuideCode);  // ADD 2008/09/30 不具合対応[5698]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/17 ----------<<<<<
        }
        /// <summary>
        /// 商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGanreCodeGuide_Click( object sender, EventArgs e )
        {
            //--- DEL 2008/07/17 ---------->>>>>
            //if ( this._goodsAcs == null )
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            //}

            //MGoodsGanre mGoodsGanre;
            //int status = this._goodsAcs.ExecuteMGoodsGanreGuid( this._enterpriseCode, string.Empty, out mGoodsGanre );
            //if ( status != 0 )
            //    return;

            //TEdit targetControl;
            //Control nextControl;
            //if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            //{
            //    targetControl = this.te_St_MediumGoodsGanreCode;
            //    nextControl = this.te_Ed_MediumGoodsGanreCode;
            //}
            //else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            //{
            //    targetControl = this.te_Ed_MediumGoodsGanreCode;
            //    nextControl = this.te_St_DetailGoodsGanreCode;
            //}
            //else
            //{
            //    return;
            //}

            //targetControl.DataText = mGoodsGanre.MediumGoodsGanreCode.ToString().TrimEnd();
            //nextControl.Focus();
            //--- DEL 2008/07/17 ---------->>>>>

            //--- ADD 2008/07/17 ---------->>>>>
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            GoodsGroupU goodsGroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TNedit targetControl;   // MOD 2008/09/30 不具合対応[5698] TEdit→TNedit
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMGroup_St;
                nextControl = this.tNedit_GoodsMGroup_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMGroup_Ed;
                nextControl = this.tNedit_BLGloupCode_St;
            }
            else
            {
                return;
            }

            // DEL 2008/09/30 不具合対応[5698]↓
            //targetControl.DataText = goodsGroupU.GoodsMGroup.ToString();
            targetControl.SetInt(goodsGroupU.GoodsMGroup);  // ADD 2008/09/30 不具合対応[5698]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/17 ----------<<<<<
        }
        /// <summary>
        /// BLグループガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_DetailGoodsGanreCodeGuide_Click( object sender, EventArgs e )
        {
            //--- DEL 2008/07/17 ---------->>>>>
            //if ( this._goodsAcs == null )
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            //}

            //DGoodsGanre dGoodsGanre;
            //int status = this._goodsAcs.ExecuteDGoodsGanreGuid( this._enterpriseCode, out dGoodsGanre );
            //if ( status != 0 )
            //    return;

            //TEdit targetControl;
            //Control nextControl;
            //if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            //{
            //    targetControl = this.te_St_DetailGoodsGanreCode;
            //    nextControl = this.te_Ed_DetailGoodsGanreCode;
            //}
            //else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            //{
            //    targetControl = this.te_Ed_DetailGoodsGanreCode;
            //    nextControl = this.tne_St_EnterpriseGanreCode;
            //}
            //else
            //{
            //    return;
            //}

            //targetControl.DataText = dGoodsGanre.DetailGoodsGanreCode.ToString().TrimEnd();
            //nextControl.Focus();
            //--- DEL 2008/07/17 ----------<<<<<

            //--- ADD 2008/07/17 ---------->>>>>
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TNedit targetControl;   // MOD 2008/09/30 不具合対応[5698] TEdit→TNedit
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGloupCode_St;
                nextControl = this.tNedit_BLGloupCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGloupCode_Ed;
                nextControl = this.tNedit_EnterpriseGanreCode_St;
            }
            else
            {
                return;
            }

            // DEL 2008/09/30 不具合対応[5698]↓
            //targetControl.DataText = bLGroupU.BLGroupCode.ToString();
            targetControl.SetInt(bLGroupU.BLGroupCode); // ADD 2008/09/30 不具合対応[5698]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/17 ----------<<<<<
        }
        /// <summary>
        /// 自社分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_EnterpriseGanreCodeGuide_Click( object sender, EventArgs e )
        {
            //--- DEL 2008/07/30 ---------->>>>>
            //if ( this._searchStockAcs == null )
            //{
            //    this._searchStockAcs = new SearchStockAcs();
            //}

            //UserGdBd userGdBd;
            //int status = this._searchStockAcs.ExecuteUserGuideGuid( this._enterpriseCode, out userGdBd );
            //if ( status != 0 )
            //    return;

            //TNedit targetControl;
            //Control nextControl;
            //if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            //{
            //    targetControl = this.tne_St_EnterpriseGanreCode;
            //    nextControl = this.tne_Ed_EnterpriseGanreCode;
            //}
            //else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            //{
            //    targetControl = this.tne_Ed_EnterpriseGanreCode;
            //    nextControl = this.tne_St_BLGoodsCode;
            //}
            //else
            //{
            //    return;
            //}

            //targetControl.SetInt( userGdBd.GuideCode );
            //nextControl.Focus();
            //--- DEL 2008/07/30 ----------<<<<<

            //--- ADD 2008/07/30 ---------->>>>>
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 41);

            if (status != 0) return;

            TNedit targetControl;   // MOD 2008/09/30 不具合対応[5698] TEdit→TNedit
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_EnterpriseGanreCode_St;
                nextControl = this.tNedit_EnterpriseGanreCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_EnterpriseGanreCode_Ed;
                nextControl = this.tNedit_BLGoodsCode_St;
            }
            else
            {
                return;
            }

            // DEL 2008/09/30 不具合対応[5698]↓
            //targetControl.DataText = userGdBd.GuideCode.ToString();
            targetControl.SetInt(userGdBd.GuideCode);   // ADD 2008/09/30 不具合対応[5698]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/30 ----------<<<<<

        }
        /// <summary>
        /// ＢＬ商品コードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : redmine #43095 在庫未出荷一覧表画面表示不正</br>
        /// <br>Programmer : cheny</br>
        /// <br>Date       : 2014/08/11</br>
        private void ub_St_BLGoodsCodeGuide_Click( object sender, EventArgs e )
        {
            if ( this._goodsAcs == null )
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial( this._enterpriseCode, "", out msg );
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            //int status = this._goodsAcs.ExecuteBLGoodsCd( out blGoodsCdUMnt );// DEL BY cheny 2014/08/11 FOR redmine43095
            // ADD BY cheny 2014/08/11 FOR redmine43095---->>>>
            if (this._bLGoodsCdAcs == null)
            {
                this._bLGoodsCdAcs = new BLGoodsCdAcs();
            }
            int status = this._bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
            // ADD BY cheny 2014/08/11 FOR redmine43095----<<<<
            if ( status != 0 )
                return;

            TNedit targetControl;
            Control nextControl;
            if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt( blGoodsCdUMnt.BLGoodsCode );
            nextControl.Focus();
        }

        // DEL 2008/09/29 不具合対応[5708]---------->>>>>
        ///// <summary>
        ///// 商品番号ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_GoodsNoGuid_Click( object sender, EventArgs e )
        //{
        //    if ( this._goodsGuid == null )
        //    {
        //        this._goodsGuid = new MAKHN04110UA();
        //    }

        //    this._goodsUnitData = null;
        //    DialogResult status = this._goodsGuid.ShowGuide( this, this._enterpriseCode, out this._goodsUnitData );

        //    if ( status != DialogResult.OK )
        //        return;

        //    TEdit targetControl;
        //    Control nextControl;
        //    if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
        //    {
        //        targetControl = this.te_St_GoodsNo;
        //        nextControl = this.te_Ed_GoodsNo;
        //    }
        //    else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
        //    {
        //        targetControl = this.te_Ed_GoodsNo;
        //        nextControl = targetControl;
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    targetControl.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
        //    nextControl.Focus();
        //}
        // DEL 2008/09/29 不具合対応[5708]----------<<<<<

        /// <summary>
        /// 数値項目開始脱出イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 空白の場合は初期値をセット
            //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
            //    ( ( TNedit ) sender ).SetInt(0);
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
            //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
            //    string maxValueText = new string('9', ((TNedit)sender).ExtEdit.Column);
            //    ( ( TNedit ) sender ).SetInt(Int32.Parse(maxValueText));
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        //--- DEL 2008/07/17 ---------->>>>>
        ///// <summary>
        ///// 印刷順変更後イベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ce_PrintSortDiv_ValueChanged ( object sender, EventArgs e )
        //{
        //    // 棚番順が選択されている時のみ、棚番ブレイク区分を入力可とする。
        //    if ((int)(sender as TComboEditor).Value == (int)StockNoShipmentListCndtn.PrintSortDivState.ByWarehouseShelfNo) {
        //        this.ce_WarehouseShelfNoBreakDiv.Enabled = true;
        //    }
        //    else {
        //        this.ce_WarehouseShelfNoBreakDiv.Enabled = false;
        //        this.ce_WarehouseShelfNoBreakDiv.Value = (int)StockNoShipmentListCndtn.WarehouseShelfNoBreakDivState.Length1;
        //    }
        //}
        //--- DEL 2008/07/17 ----------<<<<<
        //--- ADD 2008/07/17 ---------->>>>>
        /// <summary>
        /// 印刷順変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_PrintSortDiv_ValueChanged(object sender, EventArgs e)
        {
            // 棚番順が選択されている時のみ、棚番ブレイク区分を入力可とする。
            if ((int)(sender as UltraOptionSet).Value == (int)StockNoShipmentListCndtn.PrintSortDivState.ByWarehouseShelfNo)
            {
                this.ce_WarehouseShelfNoBreakDiv.Enabled = true;
            }
            else
            {
                this.ce_WarehouseShelfNoBreakDiv.Enabled = false;
                this.ce_WarehouseShelfNoBreakDiv.Value = (int)StockNoShipmentListCndtn.WarehouseShelfNoBreakDivState.Length1;
            }
        }
        //--- ADD 2008/07/17 ----------<<<<<
        /// <summary>
        /// 小計印刷区分変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_SummalyPrintDiv_ValueChanged ( object sender, EventArgs e )
        {
            // 小計印字有りの場合のみ、改ページ区分を選択可とする（「小計毎」の改ページは小計を印字する場合のみ選択可）
            if ((int)(sender as UltraOptionSet).Value == (int)StockNoShipmentListCndtn.SummalyPrintDivState.Print) {
                this.NewPageDivEnabled = true;
            }
            else {
                this.NewPageDivEnabled = false;
                this.NewPageDivValue = (int)StockNoShipmentListCndtn.NewPageDivState.None;
            }
        }
        /// <summary>
        /// グループ圧縮イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ展開イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }

        // ADD 2008/10/08 不具合対応[6214]---------->>>>>
        /// <summary>
        /// 矢印キーでのフォーカス遷移のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == this.tEdit_GoodsNo_St && e.NextCtrl == this.tNedit_BLGoodsCode_Ed)
            {
                e.NextCtrl = this.tNedit_BLGoodsCode_St;
            }
        }
        // ADD 2008/10/08 不具合対応[6214]----------<<<<<

        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_St_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_St.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_St.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_St.Text.Length - (this.tEdit_WarehouseShelfNo_St.SelectionStart + this.tEdit_WarehouseShelfNo_St.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// tEdit_WarehouseShelfNo_Ed_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_WarehouseShelfNo_Ed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                string prevStr = this.tEdit_WarehouseShelfNo_Ed.Text;
                string resultStr = prevStr.Substring(0, this.tEdit_WarehouseShelfNo_Ed.SelectionStart) // 選択前の部分
                                 + e.KeyChar.ToString() // 選択部が入力キーに置換される部分
                                 + prevStr.Substring(this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength,
                                                      this.tEdit_WarehouseShelfNo_Ed.Text.Length - (this.tEdit_WarehouseShelfNo_Ed.SelectionStart + this.tEdit_WarehouseShelfNo_Ed.SelectionLength)); // 選択後の部分

                Encoding sjis = Encoding.GetEncoding("Shift_JIS");

                int byteLength = sjis.GetByteCount(resultStr);

                // 8バイト(半角8桁、全角4桁)まで入力可
                if (byteLength > 8)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        // --- ADD 2009/04/13 --------------------------------<<<<<

		#endregion ■ Control Event

        #region ■ Private Propaty
        /// <summary>
        /// 改ページ区分Valueプロパティ
        /// </summary>
        private int NewPageDivValue
        {
            get {
                if (this.rb_NewPageDivEachSummaly.Checked) {
                    // 小計毎
                    return ( int ) StockNoShipmentListCndtn.NewPageDivState.EachSummaly;
                }
                else {
                    // しない
                    return ( int ) StockNoShipmentListCndtn.NewPageDivState.None;
                }
            }
            set {
                if ( value == ( int ) StockNoShipmentListCndtn.NewPageDivState.EachSummaly ) {
                    // 小計毎
                    this.rb_NewPageDivNone.Checked = false;
                    this.rb_NewPageDivEachSummaly.Checked = true;
                }
                else {
                    // しない
                    this.rb_NewPageDivEachSummaly.Checked = false;
                    this.rb_NewPageDivNone.Checked = true;
                }
            }
        }
        /// <summary>
        /// 改ページ区分Enabledプロパティ
        /// </summary>
        private bool NewPageDivEnabled
        {
            get {
                return this.rb_NewPageDivEachSummaly.Enabled;
            }
            set {
                this.rb_NewPageDivEachSummaly.Enabled = value;
                this.rb_NewPageDivNone.Enabled = value;
            }
        }
        #endregion ■ Public Propaty

    }
}