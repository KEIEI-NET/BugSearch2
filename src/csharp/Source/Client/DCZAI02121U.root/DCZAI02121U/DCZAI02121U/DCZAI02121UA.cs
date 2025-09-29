using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/08 不具合対応[5686]
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
    /// 在庫入出荷一覧表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫入出荷一覧表UIフォームクラス</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br>UpdateNote : 2009/03/05 照田 貴志　不具合対応[12174]</br>
    /// <br>           : 2009/03/18 照田 貴志　不具合対応[12540]</br>
    /// <br>           : 2009/03/25 照田 貴志　不具合対応[12799]</br>
    /// <br>           : 2009/04/02 照田 貴志　不具合対応[12998]</br>
    /// </remarks>
	public partial class DCZAI02121UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫入出荷一覧表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫入出荷一覧表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// <br></br>
		/// </remarks>
		public DCZAI02121UA ()
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
        // 小計印刷リスト
        private Hashtable _summalyPrintDivs = new Hashtable();
        //--- ADD 2008/07/17 ----------<<<<<
        #endregion ◆ Interface member

		// 企業コード
		private string _enterpriseCode = "";
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
		private StockShipArrivalListCndtn _stockShipArrivalListCndtn;

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
        // DEL 2008/09/25 不具合対応[5613]---------->>>>>
        //private MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        //private GoodsUnitData _goodsUnitData;
        // DEL 2008/09/25 不具合対応[5613]----------<<<<<

        //--- ADD 2008/07/17 ---------->>>>>
        // 仕入先
        SupplierAcs _supplierAcs;

        // ユーザーガイド(商品大分類、自社分類)
        UserGuideAcs _userGuideAcs;

        // 商品中分類
        GoodsGroupUAcs _goodsGroupUAcs;

        // BLグループ
        BLGroupUAcs _bLGroupUAcs;
        //--- ADD 2008/07/17 ----------<<<<<

        //// 担当者ガイド用
        //EmployeeAcs _employeeAcs;
        //Employee _employee;

        //--- DEL 2008/07/30 ---------->>>>>
        //// 在庫検索(自社分類ガイド用)
        //private SearchStockAcs _searchStockAcs;
        //--- DEL 2008/07/30 ----------<<<<<

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        // ADD 2008/10/08 不具合対応[5686]---------->>>>>
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
        // ADD 2008/10/08 不具合対応[5686]----------<<<<<

        // ---ADD 2009/03/18 不具合対応[12540] ------------------------>>>>>
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
        // ---ADD 2009/03/18 不具合対応[12540] ------------------------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID         = "DCZAI02121UA";
		// プログラムID
        private const string ct_PGID            = "DCZAI02121U";
		//// 帳票名称
		private string _printName				= "在庫入出荷一覧表";
        // 帳票キー	
        private string _printKey                = "37a7488c-701e-49e2-ad1f-a56eda25b901";   // 保留
		#endregion ◆ Interface member

		// ExporerBar グループ名称
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// 出力条件
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

			printInfo.PrintPaperSetCd	= 0;    //(int)this._stockShipArrivalListCndtn.StockMoveFormalDiv;
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._stockShipArrivalListCndtn;
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void Show ( object parameter )
		{
            this._stockShipArrivalListCndtn = new StockShipArrivalListCndtn();

			// 抽出条件に起動パラメータをセット
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( parameter.ToString().CompareTo( "1" ) == 0 )
            //{
            //    this._stockShipArrivalListCndtn.StockMoveFormalDiv = StockMoveCndtn.StockMoveFormalDivState.StockMove;
            //    this._printKey = "461a402f-20c6-4b5e-817f-790237550131";
            //}
            //else if ( parameter.ToString().CompareTo( "2" ) == 0 )
            //{
            //    this._stockShipArrivalListCndtn.StockMoveFormalDiv = StockMoveCndtn.StockMoveFormalDivState.WareHouseMove;
            //    this._printKey = "edded41e-2702-4de3-95b7-3518c5fae7b1";
            //}
            //else
            //    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, "不正起動です", -1, MessageBoxButtons.OK );
            //this._printName = this._stockShipArrivalListCndtn.StockMoveFormalDivName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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

            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //// 倉庫移動の時には絞込み倉庫ガイド(ボタンは絞込み拠点)のEnabledも操作する
            //    //if ( this._stockShipArrivalListCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.WareHouseMove )
            //    //{
            //    //    ExtractWareHouseGuidSetProc( 
            //    //        this.ub_St_ExtractSectionGuid, this.ub_Ed_ExtractSectionGuid, 
            //    //        string.Empty, string.Empty );
            //    //}
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //}
            //else
            //{
            //    ExtractWareHouseGuidSetProc( 
            //        this.ub_St_WarehouseCodeGuide, this.ub_Ed_WarehouseCodeGuide, 
            //        "0", string.Empty );

            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //    //// 倉庫移動の時には絞込み倉庫ガイド(ボタンは絞込み拠点)のEnabledも操作する
            //    //if ( this._stockShipArrivalListCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.WareHouseMove )
            //    //{
            //    //    ExtractWareHouseGuidSetProc( 
            //    //        this.ub_St_ExtractSectionGuid, this.ub_Ed_ExtractSectionGuid, 
            //    //        "0", string.Empty );
            //    //}
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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
            //return isDefaultState;            //DEL 2009/04/02 不具合対応[12998]
            return false;                       //ADD 2009/04/02 不具合対応[12998]
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
                /* ---DEL 2009/03/05 不具合対応[12174] -------------------------------->>>>>
                DateTime thisMonth;
                _dateGetAcs.GetThisYearMonth( out thisMonth );
                this.tde_St_AddUpYearMonth.SetDateTime( thisMonth );
                this.tde_Ed_AddUpYearMonth.SetDateTime( thisMonth );
                   ---DEL 2009/03/05 不具合対応[12174] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12174] -------------------------------->>>>>
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
                // ---ADD 2009/03/05 不具合対応[12174] --------------------------------<<<<<

                // 初期値セット・文字列
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                this.tNedit_GoodsLGroup_St.DataText = string.Empty;
                this.tNedit_GoodsLGroup_Ed.DataText = string.Empty;
                this.tNedit_GoodsMGroup_St.DataText = string.Empty;
                this.tNedit_GoodsMGroup_Ed.DataText = string.Empty;
                this.tNedit_BLGloupCode_St.DataText = string.Empty;
                this.tNedit_BLGloupCode_Ed.DataText = string.Empty;


                // 初期値セット・数値
                //--- DEL 2008/07/16 ---------->>>>>
                //this.tne_St_CustomerCode.SetInt( 0 );
                //this.tne_Ed_CustomerCode.SetInt( 0 );
                //--- DEL 2008/07/16 ----------<<<<<
                //this.tne_Ed_CustomerCode.SetInt(Int32.Parse(new string('9', this.tne_Ed_CustomerCode.ExtEdit.Column)));

                //--- DEL 2008/07/16 ---------->>>>>
                //this.tne_St_GoodsMakerCd.SetInt(0);
                //this.tne_Ed_GoodsMakerCd.SetInt( 0 );
                //--- DEL 2008/07/16 ----------<<<<<
                //this.tne_Ed_GoodsMakerCd.SetInt(Int32.Parse(new string('9', this.tne_Ed_GoodsMakerCd.ExtEdit.Column)));

                //--- DEL 2008/07/16 ---------->>>>>
                //this.tne_St_BLGoodsCode.SetInt(0);
                //this.tne_Ed_BLGoodsCode.SetInt( 0 );
                //--- DEL 2008/07/16 ----------<<<<<
                //this.tne_Ed_BLGoodsCode.SetInt(Int32.Parse(new string('9', this.tne_Ed_BLGoodsCode.ExtEdit.Column)));

                //--- DEL 2008/07/16 ---------->>>>>
                //this.tne_St_EnterpriseGanreCode.SetInt(0);
                //this.tne_Ed_EnterpriseGanreCode.SetInt( 0 );
                //--- DEL 2008/07/16 ----------<<<<<
                //this.tne_Ed_EnterpriseGanreCode.SetInt(Int32.Parse(new string('9', this.tne_Ed_EnterpriseGanreCode.ExtEdit.Column)));

                this.tne_St_ShipArrivalCnt.SetInt( 0 );
                //this.tne_Ed_ShipArrivalCnt.SetInt(Int32.Parse(new string('9', this.tne_Ed_ShipArrivalCnt.ExtEdit.Column)));
                this.tne_Ed_ShipArrivalCnt.SetInt( 0 );
                this.tne_St_ShipArrivalCnt.Text = string.Empty;
                this.tne_Ed_ShipArrivalCnt.Text = string.Empty;

                //--- ADD 2008/07/16 ---------->>>>>
                this.tne_St_ShipArrivalCnt.SetInt(1);
                this.tne_Ed_ShipArrivalCnt.SetInt(999999999);
                //--- ADD 2008/07/16 ----------<<<<<
                
                // 初期値セット・区分
                //this.uos_ShipArrivalPrintDiv.Value = 0;       // DEL 2008.07.16
                this.ce_ShipArrivalPrintDiv.SelectedIndex = 0;  // ADD 2008.07.16
                //this.uos_ShipArrivalCntDiv.Value = 0;         // DEL 2008.07.16
                this.ce_ShipArrivalCntDiv.SelectedIndex = 0;    // ADD 2008.07.16

                this.NewPageDivValue = 0;                       //ADD 2009/03/18 不具合対応[12540]

                // ボタン設定
                this.SetIconImage(this.ub_St_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_WarehouseCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CustomerCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_LargeGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_LargeGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_MediumGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_MediumGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_DetailGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_DetailGoodsGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_EnterpriseGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_EnterpriseGanreCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                // DEL 2008/09/25 不具合対応[5613]---------->>>>>
                //this.SetIconImage(this.ub_St_GoodsNoGuide, Size16_Index.STAR1);
                //this.SetIconImage(this.ub_Ed_GoodsNoGuide, Size16_Index.STAR1);
                // DEL 2008/09/25 不具合対応[5613]----------<<<<<

                // ---ADD 2009/03/25 不具合対応[12799] ---------------->>>>>
                // 初期表示は全てチェックあり(前回値が保存されている場合は前回値を優先させる)
                for (int i = 0; i <= this.clb_SummalyPrintDivs.Items.Count - 1; i++)
                {
                    this.clb_SummalyPrintDivs.SetItemChecked(i, true);
                }
                // ---ADD 2009/03/25 不具合対応[12799] ----------------<<<<<

                // 初期フォーカスセット
                //this.uos_ShipArrivalPrintDiv.Focus();     // DEL 2008.07.16
                this.tde_St_AddUpYearMonth.Focus();         // ADD 2008.07.16
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
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;
            DateGetAcs.CheckDateResult cdResult;

			const string ct_InputError = "の入力が不正です";
            const string ct_NoInput = "を入力して下さい";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_FullRangeError = "は１２ヵ月の範囲内で入力して下さい";

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
            // 個数指定（開始 > 終了 → NG）
            else if ( this.tne_St_ShipArrivalCnt.GetInt() > this.tne_Ed_ShipArrivalCnt.GetInt() )
            {
                errMessage = string.Format( "個数指定{0}", ct_RangeError );
                errComponent = this.tne_St_ShipArrivalCnt;
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
                //errMessage = string.Format("倉庫コード{0}", ct_RangeError);       // DEL 2008.07.16
                errMessage = string.Format("倉庫{0}", ct_RangeError);               // ADD 2008.07.16
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
                //errMessage = string.Format("メーカーコード{0}", ct_RangeError);   // DEL 2008.07.16
                errMessage = string.Format("メーカー{0}", ct_RangeError);           // ADD 2008.07.16
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 商品区分グループ
            else if (
                (this.tNedit_GoodsLGroup_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsLGroup_St.DataText.TrimEnd().CompareTo( this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("商品区分グループ{0}", ct_RangeError); // DEL 2008.07.16
                errMessage = string.Format("商品大分類{0}", ct_RangeError);         // ADD 2008.07.16
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // 商品区分
            else if (
                (this.tNedit_GoodsMGroup_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsMGroup_St.DataText.TrimEnd().CompareTo( this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("商品区分{0}", ct_RangeError);         // DEL 2008.07.16
                errMessage = string.Format("商品中分類{0}", ct_RangeError);         // ADD 2008.07.16
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // 商品区分詳細
            else if (
                (this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_BLGloupCode_St.DataText.TrimEnd().CompareTo( this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("商品区分詳細{0}", ct_RangeError);     // DEL 2008.07.16
                errMessage = string.Format("グループコード{0}", ct_RangeError);     // ADD 2008.07.16
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // 自社分類（開始 > 終了 → NG）
            else if ( this.tNedit_EnterpriseGanreCode_St.GetInt() > GetEndCode( this.tNedit_EnterpriseGanreCode_Ed ) )
            {
                //errMessage = string.Format("自社分類{0}", ct_RangeError);         // DEL 2008.07.16
                errMessage = string.Format("商品区分{0}", ct_RangeError);           // ADD 2008.07.16
                errComponent = this.tNedit_EnterpriseGanreCode_St;
                status = false;
            }
            // ＢＬ商品コード（開始 > 終了 → NG）
            else if ( this.tNedit_BLGoodsCode_St.GetInt() > GetEndCode( this.tNedit_BLGoodsCode_Ed ) )
            {
                //errMessage = string.Format("ＢＬ商品コード{0}", ct_RangeError);   // DEL 2008.07.16
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);         // ADD 2008.07.16
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            // 商品番号
            else if (
               (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("商品番号{0}", ct_RangeError);         // DEL 2008.07.16
                errMessage = string.Format("品番{0}", ct_RangeError);               // ADD 2008.07.16
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
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate )
        {
            cdrResult = _dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 12, ref startDate, ref endDate, false, false );
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
            if ( targetDateEdit.LongDate < 10101 && targetDateEdit.GetDateTime() == DateTime.MinValue )
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
                /* ---DEL 2009/04/02 不具合対応[12998] -------------------------->>>>>
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
                   ---DEL 2009/04/02 不具合対応[12998] --------------------------<<<<< */
                _selectedSectionList.Clear();           //ADD 2009/04/02 不具合対応[12998] ※全社固定

                // 拠点オプション
                this._stockShipArrivalListCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                this._stockShipArrivalListCndtn.EnterpriseCode = this._enterpriseCode;
                // 開始年月度
                this.tde_St_AddUpYearMonth.LongDate = this.tde_St_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMMdd → YYYYMM01
                this._stockShipArrivalListCndtn.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                // 終了年月度
                this.tde_Ed_AddUpYearMonth.LongDate = this.tde_Ed_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMMdd → YYYYMM01
                this._stockShipArrivalListCndtn.Ed_AddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // 拠点コード
                this._stockShipArrivalListCndtn.SectionCodes = ( string[] ) new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 開始倉庫コード
                this._stockShipArrivalListCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;
                // 終了倉庫コード
                this._stockShipArrivalListCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;
                // 開始仕入先コード
                this._stockShipArrivalListCndtn.St_CustomerCode = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                //this._stockShipArrivalListCndtn.Ed_CustomerCode = GetEndCode(this.tne_Ed_CustomerCode, 999999999);// DEL 2008.07.17
                this._stockShipArrivalListCndtn.Ed_CustomerCode = GetEndCode(this.tNedit_SupplierCd_Ed, 99999999);    // ADD 2008.07.17
                // 開始商品メーカーコード
                this._stockShipArrivalListCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了商品メーカーコード
                //this._stockShipArrivalListCndtn.Ed_GoodsMakerCd = GetEndCode(this.tne_Ed_GoodsMakerCd, 999999);       // DEL 2008.07.17
                this._stockShipArrivalListCndtn.Ed_GoodsMakerCd = GetEndCode(this.tNedit_GoodsMakerCd_Ed, 999999);           // ADD 2008.07.17
                // 開始商品区分グループコード
                this._stockShipArrivalListCndtn.St_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_St.Text;
                // 終了商品区分グループコード
                this._stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_Ed.Text;
                // 開始商品区分コード
                this._stockShipArrivalListCndtn.St_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_St.Text;
                // 終了商品区分コード
                this._stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_Ed.Text;
                // 開始商品区分詳細コード
                this._stockShipArrivalListCndtn.St_DetailGoodsGanreCode = this.tNedit_BLGloupCode_St.Text;
                // 終了商品区分詳細コード
                this._stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode = this.tNedit_BLGloupCode_Ed.Text;
                // 開始自社分類コード
                this._stockShipArrivalListCndtn.St_EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode_St.GetInt();
                // 終了自社分類コード
                this._stockShipArrivalListCndtn.Ed_EnterpriseGanreCode = GetEndCode( this.tNedit_EnterpriseGanreCode_Ed, 99999 );
                // 開始ＢＬ商品コード
                this._stockShipArrivalListCndtn.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                // 終了ＢＬ商品コード
                //this._stockShipArrivalListCndtn.Ed_BLGoodsCode = GetEndCode(this.tne_Ed_BLGoodsCode, 99999999);       // DEL 2008.07.17
                this._stockShipArrivalListCndtn.Ed_BLGoodsCode = GetEndCode(this.tNedit_BLGoodsCode_Ed, 99999999);            // ADD 2008.07.17
                // 開始商品番号
                this._stockShipArrivalListCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.Text;
                // 終了商品番号
                this._stockShipArrivalListCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text;
                // 開始倉庫棚番
                this._stockShipArrivalListCndtn.St_WarehouseShelfNo = this.tEdit_WarehouseCode_St.Text;
                // 終了倉庫棚番
                this._stockShipArrivalListCndtn.Ed_WarehouseShelfNo = this.tEdit_WarehouseCode_St.Text;
                // 印刷タイプ
                //this._stockShipArrivalListCndtn.ShipArrivalPrintDiv = (StockShipArrivalListCndtn.ShipArrivalPrintDivState)this.uos_ShipArrivalPrintDiv.Value;
                this._stockShipArrivalListCndtn.ShipArrivalPrintDiv = (StockShipArrivalListCndtn.ShipArrivalPrintDivState)this.ce_ShipArrivalPrintDiv.SelectedIndex;

                // ---ADD 2009/03/18 不具合対応[12540] -------------------------------------------------------------------------->>>>>
                // 改ページ区分
                this._stockShipArrivalListCndtn.NewPageDiv = (StockShipArrivalListCndtn.NewPageDivState)this.NewPageDivValue;
                // ---ADD 2009/03/18 不具合対応[12540] --------------------------------------------------------------------------<<<<<

                // 在庫登録日
                this._stockShipArrivalListCndtn.StockCreateDate = this.tde_StockCreateDate.GetDateTime();
                // 在庫登録日指定区分
                this._stockShipArrivalListCndtn.StockCreateDateDiv = ( StockShipArrivalListCndtn.StockCreateDateDivState) this.ce_StockCreateDateDiv.SelectedIndex;
                // 出荷数指定区分
                //this._stockShipArrivalListCndtn.ShipArrivalCntDiv = (StockShipArrivalListCndtn.ShipArrivalCntDivState)this.uos_ShipArrivalCntDiv.Value;
                this._stockShipArrivalListCndtn.ShipArrivalCntDiv = (StockShipArrivalListCndtn.ShipArrivalCntDivState)this.ce_ShipArrivalCntDiv.SelectedIndex;
                // 開始入出荷数
                this._stockShipArrivalListCndtn.St_ShipArrivalCnt = this.tne_St_ShipArrivalCnt.GetInt();
                // 終了入出荷数
                this._stockShipArrivalListCndtn.Ed_ShipArrivalCnt = this.tne_Ed_ShipArrivalCnt.GetInt();
                //--- ADD 2008/07/17 ---------->>>>>
                // 小計印刷区分
                for (int index = 0; index < this.clb_SummalyPrintDivs.Items.Count; index++)
                {
                    // チェック有無取得
                    StockShipArrivalListCndtn.SummaryPrintDivState printDivState;
                    if (this.clb_SummalyPrintDivs.GetItemChecked(index) == true)
                    {
                        printDivState = StockShipArrivalListCndtn.SummaryPrintDivState.Print;
                    }
                    else
                    {
                        printDivState = StockShipArrivalListCndtn.SummaryPrintDivState.None;
                    }

                    switch (index)
                    {
                        // 倉庫計
                        case 0: this._stockShipArrivalListCndtn.WarehouseSummaryPrintDiv = printDivState; break;
                        // 仕入先計
                        case 1: this._stockShipArrivalListCndtn.SupplierSummaryPrintDiv = printDivState; break;
                        // メーカー計
                        case 2: this._stockShipArrivalListCndtn.GoodsMakerSummaryPrintDiv = printDivState; break;
                        // 商品区分グループ計
                        case 3: this._stockShipArrivalListCndtn.LargeGoodsGanreSummaryPrintDiv = printDivState; break;
                        // 商品区分計
                        case 4: this._stockShipArrivalListCndtn.MediumGoodsGanreSummaryPrintDiv = printDivState; break;
                        // 商品区分詳細計
                        case 5: this._stockShipArrivalListCndtn.DetailGoodsGanreSummaryPrintDiv = printDivState; break;
                        // (例外)
                        default: break;
                    }
                }                //--- ADD 2008/07/17 ----------<<<<<
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
        #region ◆ DCZAI02121UA
        #region ◎ DCZAI02121UA_Load Event
        /// <summary>
        /// DCZAI02121UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void DCZAI02121UA_Load ( object sender, EventArgs e )
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

            // ADD 2008/10/08 不具合対応[5686]---------->>>>>
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
                this.tNedit_GoodsLGroup_St
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
            // ADD 2008/10/08 不具合対応[5686]----------<<<<<

            // ---ADD 2009/03/18 不具合対応[12540] --------------------------------->>>>>
            // スペースキーの制御オブジェクトを設定
            NewPageDivRadioKeyPressHelper.ControlList.Add(this.rb_NewPageDivEachSummaly);
            NewPageDivRadioKeyPressHelper.ControlList.Add(this.rb_NewPageDivNone);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ---ADD 2009/03/18 不具合対応[12540] ---------------------------------<<<<<
		}
		#endregion

        #endregion ◆ DCZAI02121UA

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

            //// スライダーの拠点コードをもとにガイド起動
            //if ( this._selectedSectionList.Count == 1 ) {
            //    foreach ( DictionaryEntry de in this._selectedSectionList ) {
            //        sectionCode = de.Value.ToString().TrimEnd();
            //    }
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 倉庫ガイド用の拠点コードを取得
            //sectionCode = GetWarehouseGuideSection( this._selectedSectionList );          //DEL 2009/04/02 不具合対応[12998]
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            sectionCode = string.Empty;                                                     //ADD 2009/04/02 不具合対応[12998]

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

            // フォーカス移動
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
        private void ub_St_CustomerCodeGuide_Click ( object sender, EventArgs e )
        {
            //--- DEL 2008/07/30 ---------->>>>>
            //_customerGuideOK = false;

            //try {
            //    this._customerGuid = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //    this._customerGuid.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSelected);

            //    this._customerGuidSender = ( UltraButton ) sender;
            //    this._customerGuid.ShowDialog(this);
            //    this._customerGuidSender = null;

            //    this._customerGuid.Dispose();

            //    // 次フォーカス
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
            //catch ( Exception ) {
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

            TNedit targetControl;   // MOD 2008/09/29 不具合対応[5683] TEdit→TNedit
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

            // DEL 2008/09/29 不具合対応[5683]↓
            //targetControl.DataText = supplier.SupplierCd.ToString();
            targetControl.SetInt(supplier.SupplierCd);  // ADD 2008/09/29 不具合対応[5683]

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
        //private void CustomerSelected ( object sender, CustomerSearchRet customerSearchRet )
        //{
        //    try {
        //        if (_customerGuidSender != null) {
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
        //    catch ( Exception ) {
        //    }
        //}
        //--- DEL 2008/07/30 ----------<<<<<

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerCdGuide_Click ( object sender, EventArgs e )
        {
            if ( this._goodsAcs == null ) {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            MakerUMnt maker;
            int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            if (status != 0) return;

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
                nextControl = this.tNedit_GoodsLGroup_St;
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
        private void ub_St_LargeGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            //--- DEL 2008/07/17 ---------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //LGoodsGanre lGoodsGanre;
            //int status = this._goodsAcs.ExecuteLGoodsGanreGuid(this._enterpriseCode, out lGoodsGanre);
            //if ( status != 0 ) return;

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

            TNedit targetControl;   // MOD 2008/09/26 不具合対応[5683] TEdit→TNedit
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

            // DEL 2008/09/26 不具合対応[5683]↓
            //targetControl.DataText = userGdBd.GuideCode.ToString();
            targetControl.SetInt(userGdBd.GuideCode);   // ADD 2008/09/26 不具合対応[5683]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/17 ----------<<<<<
        }
        /// <summary>
        /// 商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            //--- DEL 2008/07/17 ---------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //MGoodsGanre mGoodsGanre;
            //int status = this._goodsAcs.ExecuteMGoodsGanreGuid(this._enterpriseCode, string.Empty, out mGoodsGanre);
            //if ( status != 0 ) return;

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
            //--- DEL 2008/07/17 ----------<<<<<

            //--- ADD 2008/07/17 ---------->>>>>
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            GoodsGroupU goodsGroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TNedit targetControl;   // MOD 2008/09/26 不具合対応[5683] TEdit→TNedit
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

            // DEL 2008/09/26 不具合対応[5683]↓
            //targetControl.DataText = goodsGroupU.GoodsMGroup.ToString();
            targetControl.SetInt(goodsGroupU.GoodsMGroup);  // ADD 2008/09/26 不具合対応[5683]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/17 ----------<<<<<
        }
        /// <summary>
        /// BLグループガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_DetailGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            //--- DEL 2008/07/17 ---------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //DGoodsGanre dGoodsGanre;
            //int status = this._goodsAcs.ExecuteDGoodsGanreGuid(this._enterpriseCode, out dGoodsGanre);
            //if ( status != 0 ) return;

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

            TNedit targetControl;   // MOD 2008/09/26 不具合対応[5683] TEdit→TNedit
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

            // DEL 2008/09/26 不具合対応[5683]↓
            //targetControl.DataText = bLGroupU.BLGroupCode.ToString();
            targetControl.SetInt(bLGroupU.BLGroupCode); // ADD 2008/09/26 不具合対応[5683]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/17 ----------<<<<<
        }
        /// <summary>
        /// 自社分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_EnterpriseGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            //--- DEL 2008/07/30 ---------->>>>>
            //if (this._searchStockAcs == null) {
            //    this._searchStockAcs = new SearchStockAcs();
            //}

            //UserGdBd userGdBd;
            //int status = this._searchStockAcs.ExecuteUserGuideGuid(this._enterpriseCode, out userGdBd);
            //if ( status != 0 ) return;

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

            TNedit targetControl;   // MOD 2008/09/26 不具合対応[5683] TEdit→TNedit
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

            // DEL 2008/09/26 不具合対応[5683]↓
            //targetControl.DataText = userGdBd.GuideCode.ToString();
            targetControl.SetInt(userGdBd.GuideCode);   // ADD 2008/09/26 不具合対応[5683]

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/30 ----------<<<<<
        }
        /// <summary>
        /// ＢＬ商品コードガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click ( object sender, EventArgs e )
        {
            if ( this._goodsAcs == null ) {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._goodsAcs.ExecuteBLGoodsCd( out blGoodsCdUMnt );
            if ( status != 0 ) return;

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

        // DEL 2008/09/25 不具合対応[5613]---------->>>>>
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
        //    Control nextControl;
        //    if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
        //    {
        //        targetControl = this.tEdit_GoodsNo_St;
        //        nextControl = this.tEdit_GoodsNo_Ed;
        //    }
        //    else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
        //    {
        //        targetControl = this.tEdit_GoodsNo_Ed;
        //        nextControl = targetControl;
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    targetControl.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
        //    nextControl.Focus();
        //}
        // DEL 2008/09/25 不具合対応[5613]----------<<<<<

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
        /// <summary>
        /// グループ圧縮処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }
        /// <summary>
        /// グループ展開処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // 常にキャンセル
            e.Cancel = true;
        }

        // ADD 2008/10/08 不具合対応[5686]---------->>>>>
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
        // ADD 2008/10/08 不具合対応[5686]----------<<<<<

#if false
		#region ◆ ueb_MainExplorerBar
		#region ◎ GroupCollapsing Event
		/// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroupが縮小される前に発生する。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
			{
				// グループの展開をキャンセル
				e.Cancel = true;
			}

		}
		#endregion
		#endregion ◆ ueb_MainExplorerBar

		#region ◆ ub_St_MainBfAfEnterWarehGuid
		#region ◎ Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがクリックされたときに発生する。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void ub_St_ExtractSectionGuid_Click ( object sender, EventArgs e )
		{
			int status = 0;
			string getCode = "";
			string sectionCode = "";

			if ( this._stockShipArrivalListCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
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

			
			if ( this._stockShipArrivalListCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
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

        #region ■ Private Propaty
        /// <summary>
        /// 改ページ区分Valueプロパティ
        /// </summary>
        private int NewPageDivValue
        {
            get
            {
                if (this.rb_NewPageDivEachSummaly.Checked)
                {
                    // 小計毎
                    return (int)StockShipArrivalListCndtn.NewPageDivState.EachSummaly;
                }
                else
                {
                    // しない
                    return (int)StockShipArrivalListCndtn.NewPageDivState.None;
                }
            }
            set
            {
                if (value == (int)StockShipArrivalListCndtn.NewPageDivState.EachSummaly)
                {
                    // 小計毎
                    this.rb_NewPageDivNone.Checked = false;
                    this.rb_NewPageDivEachSummaly.Checked = true;
                }
                else
                {
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
            get
            {
                return this.rb_NewPageDivEachSummaly.Enabled;
            }
            set
            {
                this.rb_NewPageDivEachSummaly.Enabled = value;
                this.rb_NewPageDivNone.Enabled = value;
            }
        }
        #endregion ■ Private Propaty


    }
}