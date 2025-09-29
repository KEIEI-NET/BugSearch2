//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫分析順位表
// プログラム概要   : 在庫分析順位表UIフォーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2006 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/09/30  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/05  修正内容 : 不具合対応[12175]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/06  修正内容 : 不具合対応[13001]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/13  修正内容 : 不具合対応[13103]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/04  修正内容 : 不具合対応[13424]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/24  修正内容 : 不具合対応[13585]
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/31 不具合対応[6217]：スペースキーでの項目選択機能を実装
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
    /// 在庫分析順位表UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫分析順位表UIフォームクラス</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br>Update     : 2008/09/30 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>           : 2009/03/05 照田 貴志　不具合対応[12175]</br>
    /// <br>           : 2009/04/06 照田 貴志　不具合対応[13001]</br>
    /// <br>           : 2009/04/13 上野 俊治　不具合対応[13103]</br>
    /// <br>           : 2009/06/04 照田 貴志　不具合対応[13424]　出荷数指定の桁数(プロパティ)を変更</br>
    /// <br>           : 2009/06/24 照田 貴志　不具合対応[13585]</br>
    /// </remarks>
	public partial class DCZAI02141UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫分析順位表UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫分析順位表UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2007.09.19</br>
		/// <br></br>
		/// </remarks>
		public DCZAI02141UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            // ガイド後次フォーカス制御
            SettingGuideNextFocusControl();
		}
        /// <summary>
        /// ガイド後次フォーカス制御
        /// </summary>
        private void SettingGuideNextFocusControl()
        {
            _guideNextFocusControl = new GuideNextFocusControl();

            // これ以前はガイドに関係ないので省略
            _guideNextFocusControl.AddRange( new Control[] { tEdit_WarehouseCode_St, tEdit_WarehouseCode_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tNedit_SupplierCd_St, tNedit_SupplierCd_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tNedit_GoodsMakerCd_St, tNedit_GoodsMakerCd_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tNedit_GoodsLGroup_St, tNedit_GoodsLGroup_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tNedit_GoodsMGroup_St, tNedit_GoodsMGroup_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tNedit_BLGloupCode_St, tNedit_BLGloupCode_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tNedit_BLGoodsCode_St, tNedit_BLGoodsCode_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tEdit_WarehouseShelfNo_St, tEdit_WarehouseShelfNo_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tEdit_GoodsNo_St, tEdit_GoodsNo_Ed } );
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
        // 管理区分リスト
        private Hashtable _duplicationShelfNoList1 = new Hashtable();
        // 管理区分リスト
        private Hashtable _duplicationShelfNoList2 = new Hashtable();
		#endregion ◆ Interface member

		// 企業コード
		private string _enterpriseCode = "";
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
		private StockAnalysisOrderListCndtn _stockAnalysisOrderListCndtn;

        //// 拠点ガイド用
        //private SecInfoSet _secInfoSet;
        //private SecInfoSetAcs _secInfoSetAcs;

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
        private MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        private GoodsAcs _goodsAcs;
        private GoodsUnitData _goodsUnitData;

        //--- ADD 2008/07/24 ---------->>>>>
        // 仕入先
        SupplierAcs _supplierAcs;
        // 商品大分類
        UserGuideAcs _userGuideAcs;
        // 商品中分類
        GoodsGroupUAcs _goodsGroupUAcs;
        // BLグループ
        BLGroupUAcs _bLGroupUAcs;
        //--- ADD 2008/07/24 ----------<<<<<

        //// 担当者ガイド用
        //private EmployeeAcs _employeeAcs;
        //private Employee _employee;

        //// 在庫検索(自社分類ガイド用)
        //private SearchStockAcs _searchStockAcs;

        // ガイド後次フォーカス制御
        private GuideNextFocusControl _guideNextFocusControl;

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        // ADD 2009/03/31 不具合対応[6217]：スペースキーでの項目選択機能を実装 ---------->>>>>
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

        /// <summary>改頁ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly RadioKeyPressEventHelper _newPageDivRadioKeyPressHelper = new RadioKeyPressEventHelper();
        /// <summary>
        /// 改頁ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>改頁ラジオボタンのKeyPressイベントのヘルパ</value>
        public RadioKeyPressEventHelper NewPageDivRadioKeyPressHelper
        {
            get { return _newPageDivRadioKeyPressHelper; }
        }
        // ADD 2009/03/31 不具合対応[6217]：スペースキーでの項目選択機能を実装 ----------<<<<<

        #endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID         = "DCZAI02141UA";
		// プログラムID
        private const string ct_PGID            = "DCZAI02141U";
		//// 帳票名称
		private string _printName				= "在庫分析順位表";
        // 帳票キー	
        private string _printKey                = "6a331761-63ad-4234-bd93-97a141a8c977";   // 保留
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

			printInfo.PrintPaperSetCd	= 0;    //(int)this._stockAnalysisOrderListCndtn.StockMoveFormalDiv;
			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
			printInfo.jyoken			= this._stockAnalysisOrderListCndtn;
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
            this._stockAnalysisOrderListCndtn = new StockAnalysisOrderListCndtn();

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
            //return isDefaultState;            //DEL 2009/04/06 不具合対応[13001]
            return false;                       //ADD 2009/04/06 不具合対応[13001]
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
                this.tde_StockCreateDate.SetDateTime( TDateTime.GetSFDateNow() );
                //this.tde_St_AddUpYearMonth.SetDateTime(TDateTime.GetSFDateNow());
                //this.tde_Ed_AddUpYearMonth.SetDateTime(TDateTime.GetSFDateNow());
                /* ---DEL 2009/03/05 不具合対応[12175] -------------------------------->>>>>
                DateTime stDate;
                DateTime edDate;
                _dateGetAcs.GetPeriod( DateGetAcs.ProcModeDivState.PastMonths, 1, out stDate, out edDate );
                this.tde_St_AddUpYearMonth.SetDateTime( stDate );
                this.tde_Ed_AddUpYearMonth.SetDateTime( edDate );
                   ---DEL 2009/03/05 不具合対応[12175] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12175] -------------------------------->>>>>
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
                // ---ADD 2009/03/05 不具合対応[12175] --------------------------------<<<<<

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
                this.tNedit_SupplierCd_St.SetInt( 0 );
                this.tNedit_SupplierCd_Ed.SetInt( 0 );
                //this.tne_Ed_CustomerCode.SetInt(Int32.Parse(new string('9', this.tne_Ed_CustomerCode.ExtEdit.Column)));

                this.tNedit_GoodsMakerCd_St.SetInt( 0 );
                this.tNedit_GoodsMakerCd_Ed.SetInt( 0 );
                //this.tne_Ed_GoodsMakerCd.SetInt(Int32.Parse(new string('9', this.tne_Ed_GoodsMakerCd.ExtEdit.Column)));

                this.tNedit_BLGoodsCode_St.SetInt( 0 );
                this.tNedit_BLGoodsCode_Ed.SetInt( 0 );
                //this.tne_Ed_BLGoodsCode.SetInt(Int32.Parse(new string('9', this.tne_Ed_BLGoodsCode.ExtEdit.Column)));

                this.tne_St_ShipmentCnt.SetInt( 0 );
                this.tne_St_ShipmentCnt.Text = string.Empty;
                //this.tne_Ed_ShipmentCnt.SetInt( Int32.Parse( new string( '9', this.tne_Ed_ShipmentCnt.ExtEdit.Column ) ) );
                this.tne_Ed_ShipmentCnt.SetInt( 0 );
                this.tne_Ed_ShipmentCnt.Text = string.Empty;

                //this.tne_StockOrderMax.SetInt(Int32.Parse(new string('9', this.tne_StockOrderMax.ExtEdit.Column)));
                this.tne_StockOrderMax.SetInt( 0 );
                this.tne_StockOrderMax.Text = string.Empty;

                //--- ADD 2008.07.17 ---------->>>>>
                this.tne_St_ShipmentCnt.SetInt(1);
                this.tne_Ed_ShipmentCnt.SetInt(999999999);

                this.tne_StockOrderMax.SetInt(999999999);
                //--- ADD 2008.07.17 ----------<<<<<

                // 初期値セット・区分
                /* --- DEL 2008/09/30 印刷タイプ「全社計」選択時、改頁は「しない」固定とする為(コントロールをUltraOptionSet→RadioButtonに変更)--->>>>>
                //this.uos_OrderPrintDiv.Value = 0;     // DEL 2008/07/17
                //this.uos_MoneyUnitDiv.Value = 0;      // DEL 2008/07/17
                this.uos_NewPageDiv.Value = 0;
                   --- DEL 2008/09/30 ------------------------------------------------------------------------------------------------------------<<<<< */
                this.NewPageDivValue = (int)StockAnalysisOrderListCndtn.PrintTypeDivState.ByWarehouse;
                this.uos_PrintTypeDiv.Value = 0;

                this.ce_OrderPrintDiv.Value = 0;        // ADD 2008/07/17
                this.ce_MoneyUnitDiv.Value = 0;         // ADD 2008/07/17

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
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_GoodsNoGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsNoGuide, Size16_Index.STAR1);

                // --- ADD 2008/09/30 ----------------->>>>>
                // 必須色に変更
                this.tde_St_AddUpYearMonth.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
                this.tde_Ed_AddUpYearMonth.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
                this.tde_StockCreateDate.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);
                this.ce_StockCreateDateDiv.Appearance.BackColor = Color.FromArgb(179, 219, 231);
                // 非表示
                this.ub_St_GoodsNoGuide.Visible = false;        // 品番From
                this.ub_Ed_GoodsNoGuide.Visible = false;        // 品番To
                // --- ADD 2008/09/30 -----------------<<<<<

                // 初期フォーカスセット
                this.tde_St_AddUpYearMonth.Focus();
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

        #region ◎ 管理区分名称設定処理 ADD 2009/06/24 不具合対応[13585]
        // ---ADD 2009/06/24 不具合対応[13585] --------------->>>>>
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
        // ---ADD 2009/06/24 不具合対応[13585] ---------------<<<<<
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
			const string ct_NoInput	   = "を入力して下さい";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_FullRangeError = "は１２ヶ月の範囲で入力して下さい";

            // 対象年月（開始・終了）
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
            // 在庫登録日
            // (未入力許可しない)
            else if ( CallCheckDate( out cdResult, ref tde_StockCreateDate ) == false )
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
            // ---ADD 2008/09/30 -------------------------------------------------------------------------------------------->>>>>
            // マイナス入力可により、1桁多くなる為上限、下限の設定が必要
            // 個数指定（開始が-999999999.99～999999999.99の範囲外 → NG）
            else if (( this.tne_St_ShipmentCnt.GetValue() < -999999999.99) || (999999999.99 < this.tne_St_ShipmentCnt.GetValue()))
            {
                errMessage = string.Format("個数指定{0}", ct_RangeError);
                errComponent = this.tne_St_ShipmentCnt;
                status = false;
            }
            // 個数指定（終了が-999999999.99～999999999.99の範囲外 → NG）
            else if ((this.tne_Ed_ShipmentCnt.GetValue() < -999999999.99) || (999999999.99 < this.tne_Ed_ShipmentCnt.GetValue()))
            {
                errMessage = string.Format("個数指定{0}", ct_RangeError);
                errComponent = this.tne_Ed_ShipmentCnt;
                status = false;
            }
            // ---ADD 2008/09/30 --------------------------------------------------------------------------------------------<<<<<
            // 個数指定（開始 > 終了 → NG）
            //else if ( this.tne_St_ShipmentCnt.GetInt() > GetEndCode(this.tne_Ed_ShipmentCnt) )                    //DEL 2008/09/30 Int→Double
            else if ( this.tne_St_ShipmentCnt.GetValue() > GetEndCode(this.tne_Ed_ShipmentCnt, 999999999.99) )      //ADD 2008/09/30
            {
                errMessage = string.Format( "個数指定{0}", ct_RangeError );
                errComponent = this.tne_St_ShipmentCnt;
                status = false;
            }
            // 倉庫コード
            if (
                ( this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty ) &&
                ( this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo(this.tEdit_WarehouseCode_Ed.DataText.TrimEnd()) > 0 ) ) 
            {
                //errMessage = string.Format("倉庫コード{0}", ct_RangeError);   // DEL 2008.07.24
                errMessage = string.Format("倉庫{0}", ct_RangeError);           // ADD 2008.07.24
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            // 仕入先（開始 > 終了 → NG）
            else if ( this.tNedit_SupplierCd_St.GetInt() > GetEndCode(this.tNedit_SupplierCd_Ed) ) {
                errMessage = string.Format("仕入先{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }
            // メーカー（開始 > 終了 → NG）
            else if ( this.tNedit_GoodsMakerCd_St.GetInt() > GetEndCode(this.tNedit_GoodsMakerCd_Ed) ) {
                //errMessage = string.Format("メーカーコード{0}", ct_RangeError);   // DEL 2008.07.24
                errMessage = string.Format("メーカー{0}", ct_RangeError);           // ADD 2008.07.24
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 商品区分グループ
            /* --- DEL 2008/09/30 TEdit→TNedit変更の為 ------------------------------------------------------------------>>>>>
            else if (
                ( this.tNedit_GoodsLGroup_St.DataText.TrimEnd() != string.Empty ) &&
                ( this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() != string.Empty ) &&
                ( this.tNedit_GoodsLGroup_St.DataText.TrimEnd().CompareTo(this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd()) > 0 ) ) 
               --- DEL 2008/09/30 ----------------------------------------------------------------------------------------<<<<< */
            else if (this.tNedit_GoodsLGroup_St.GetInt() > GetEndCode(this.tNedit_GoodsLGroup_Ed))      //ADD 2008/09/30
            {
                //errMessage = string.Format("商品区分グループ{0}", ct_RangeError);     // DEL 2008.07.24
                errMessage = string.Format("商品大分類{0}", ct_RangeError);             // ADD 2008.07.24
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // 商品区分
            /* --- DEL 2008/09/30 TEdit→TNedit変更の為 ------------------------------------------------------------------>>>>>
            else if (
                ( this.tNedit_GoodsMGroup_St.DataText.TrimEnd() != string.Empty ) &&
                ( this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() != string.Empty ) &&
                ( this.tNedit_GoodsMGroup_St.DataText.TrimEnd().CompareTo(this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd()) > 0 ) ) 
               --- DEL 2008/09/30 ----------------------------------------------------------------------------------------<<<<< */
            else if (this.tNedit_GoodsMGroup_St.GetInt() > GetEndCode(this.tNedit_GoodsMGroup_Ed))      //ADD 2008/09/30
            {
                //errMessage = string.Format("商品区分{0}", ct_RangeError);     // DEL 2008.07.24
                errMessage = string.Format("商品中分類{0}", ct_RangeError);     // ADD 2008.07.24
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // 商品区分詳細
            /* --- DEL 2008/09/30 TEdit→TNedit変更の為 ------------------------------------------------------------------>>>>>
            else if (
                ( this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty ) &&
                ( this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty ) &&
                ( this.tNedit_BLGloupCode_St.DataText.TrimEnd().CompareTo(this.tNedit_BLGloupCode_Ed.DataText.TrimEnd()) > 0 ) ) 
               --- DEL 2008/09/30 ----------------------------------------------------------------------------------------<<<<< */
            else if (this.tNedit_BLGloupCode_St.GetInt() > GetEndCode(this.tNedit_BLGloupCode_Ed))      //ADD 2008/09/30
            {
                //errMessage = string.Format("商品区分詳細{0}", ct_RangeError);     // DEL 2008.07.24
                errMessage = string.Format("グループコード{0}", ct_RangeError);     // ADD 2008.07.24
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // ＢＬ商品コード（開始 > 終了 → NG）
            else if ( this.tNedit_BLGoodsCode_St.GetInt() > GetEndCode( this.tNedit_BLGoodsCode_Ed ) )
            {
                //errMessage = string.Format("ＢＬ商品コード{0}", ct_RangeError);   // DEL 2008.07.24
                errMessage = string.Format("ＢＬコード{0}", ct_RangeError);         // ADD 2008.07.24
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
            }
            // 倉庫棚番
            else if (
               (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() != string.Empty) &&
               (this.tEdit_WarehouseShelfNo_St.DataText.TrimEnd().CompareTo( this.tEdit_WarehouseShelfNo_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format( "倉庫棚番{0}", ct_RangeError );   // DEL 2008.07.24
                errMessage = string.Format("棚番{0}", ct_RangeError);           // ADD 2008.07.24
                errComponent = this.tEdit_WarehouseShelfNo_St;
                status = false;
            }
            // 商品番号
            else if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() ) > 0) )
            {
                //errMessage = string.Format("商品番号{0}", ct_RangeError);     // DEL 2008.07.24
                errMessage = string.Format("品番{0}", ct_RangeError);           // ADD 2008.07.24
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }

            return status;
        }
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit )
        {
            cdrResult = _dateGetAcs.CheckDateRange( DateGetAcs.YmdType.YearMonth, 12, ref startDateEdit, ref endDateEdit, false, false );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
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
                /* ---DEL 2009/04/06 不具合対応[13001] ------------------------->>>>>
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
                   ---DEL 2009/04/06 不具合対応[13001] -------------------------<<<<< */
                _selectedSectionList.Clear();           //ADD 2009/04/06 不具合対応[13001]

                // 拠点オプション
                this._stockAnalysisOrderListCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                this._stockAnalysisOrderListCndtn.EnterpriseCode = this._enterpriseCode;
                // 開始年月度
                this.tde_St_AddUpYearMonth.LongDate = this.tde_St_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMM01
                this._stockAnalysisOrderListCndtn.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                // 終了年月度
                this.tde_Ed_AddUpYearMonth.LongDate = this.tde_Ed_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMM01
                this._stockAnalysisOrderListCndtn.Ed_AddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // 拠点コード
                this._stockAnalysisOrderListCndtn.SectionCodes = ( string[] ) new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 開始倉庫コード
                this._stockAnalysisOrderListCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;
                // 終了倉庫コード
                this._stockAnalysisOrderListCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;
                // 開始仕入先コード
                this._stockAnalysisOrderListCndtn.St_CustomerCode = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                /* --- DEL 2008/09/30 桁数変更の為 ------------------------------------------------------------------------------------>>>>>
                //this._stockAnalysisOrderListCndtn.Ed_CustomerCode = GetEndCode(this.tne_Ed_CustomerCode, 999999999);      // DEL 2008.07.17
                this._stockAnalysisOrderListCndtn.Ed_CustomerCode = GetEndCode(this.tNedit_SupplierCd_Ed, 99999999);         // ADD 2008.07.17
                   --- DEL 2008/09/30 -------------------------------------------------------------------------------------------------<<<<< */
                this._stockAnalysisOrderListCndtn.Ed_CustomerCode = GetEndCode(this.tNedit_SupplierCd_Ed, 999999);          //ADD 2008/09/30
                // 開始商品メーカーコード
                this._stockAnalysisOrderListCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了商品メーカーコード
                //this._stockAnalysisOrderListCndtn.Ed_GoodsMakerCd = GetEndCode( this.tne_Ed_GoodsMakerCd, 999999 );       // DEL 2008.07.17
                this._stockAnalysisOrderListCndtn.Ed_GoodsMakerCd = GetEndCode(this.tNedit_GoodsMakerCd_Ed, 9999);             // ADD 2008.07.17
                // 開始商品区分グループコード
                this._stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_St.Text;
                // 終了商品区分グループコード
                this._stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_Ed.Text;
                // 開始商品区分コード
                this._stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_St.Text;
                // 終了商品区分コード
                this._stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_Ed.Text;
                // 開始商品区分詳細コード
                this._stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode = this.tNedit_BLGloupCode_St.Text;
                // 終了商品区分詳細コード
                this._stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode = this.tNedit_BLGloupCode_Ed.Text;
                // 開始ＢＬ商品コード
                this._stockAnalysisOrderListCndtn.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
                // 終了ＢＬ商品コード
                //this._stockAnalysisOrderListCndtn.Ed_BLGoodsCode = GetEndCode( this.tne_Ed_BLGoodsCode, 99999999 );       // DEL 2008.07.17
                this._stockAnalysisOrderListCndtn.Ed_BLGoodsCode = GetEndCode(this.tNedit_BLGoodsCode_Ed, 99999);              // ADD 2008.07.17
                // 開始商品番号
                this._stockAnalysisOrderListCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.Text;
                // 終了商品番号
                this._stockAnalysisOrderListCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text;
                // 開始倉庫棚番
                this._stockAnalysisOrderListCndtn.St_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_St.Text;
                // 終了倉庫棚番
                this._stockAnalysisOrderListCndtn.Ed_WarehouseShelfNo = this.tEdit_WarehouseShelfNo_Ed.Text;
                // 在庫登録日
                this._stockAnalysisOrderListCndtn.StockCreateDate = this.tde_StockCreateDate.GetDateTime();
                // 在庫登録日指定区分
                this._stockAnalysisOrderListCndtn.StockCreateDateDiv = ( StockAnalysisOrderListCndtn.StockCreateDateDivState) this.ce_StockCreateDateDiv.SelectedIndex;
                // 開始入出荷数
                //this._stockAnalysisOrderListCndtn.St_ShipmentCnt = this.tne_St_ShipmentCnt.GetInt();                      //DEL 2008/09/30 Int→Double
                this._stockAnalysisOrderListCndtn.St_ShipmentCnt = this.tne_St_ShipmentCnt.GetValue();                      //ADD 2008/09/30
                // 終了入出荷数
                //this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt = GetEndCode( this.tne_Ed_ShipmentCnt, 999999999 );      //DEL 2008/09/30 Int→Double
                this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt = GetEndCode(this.tne_Ed_ShipmentCnt, 999999999.99);       //ADD 2008/09/30
                
                // 印刷タイプ(予備項目)
                this._stockAnalysisOrderListCndtn.ShipArrivalPrintDiv = 0;
                // 開始自社分類コード(予備項目)
                this._stockAnalysisOrderListCndtn.St_EnterpriseGanreCode = 0;
                // 終了自社分類コード(予備項目)
                this._stockAnalysisOrderListCndtn.Ed_EnterpriseGanreCode = 9999;

                // -- ( 以下、UI側 制御用項目 ) -- 
                // 印刷タイプ（印刷順）
                //thgais._stockAnalysisOrderListCndtn.OrderPrintType = (StockAnalysisOrderListCndtn.OrderPrintTypeState)this.uos_OrderPrintDiv.Value;     // DEL 2008/07/17
                this._stockAnalysisOrderListCndtn.OrderPrintType = (StockAnalysisOrderListCndtn.OrderPrintTypeState)this.ce_OrderPrintDiv.Value;       // ADD 2008/07/17
                // 順位付け区分（上位・下位）
                this._stockAnalysisOrderListCndtn.StockOrderDiv = (StockAnalysisOrderListCndtn.StockOrderDivState)this.ce_StockOrderDiv.Value;
                // 印刷対象順位Max (ｘｘ位まで印字)
                this._stockAnalysisOrderListCndtn.StockOrderMax = GetEndCode( this.tne_StockOrderMax, 999999999 );
                // 金額単位
                //this._stockAnalysisOrderListCndtn.MoneyUnit = (StockAnalysisOrderListCndtn.MoneyUnitState)this.uos_MoneyUnitDiv.Value;        // DEL 2008/07/17
                this._stockAnalysisOrderListCndtn.MoneyUnit = (StockAnalysisOrderListCndtn.MoneyUnitState)this.ce_MoneyUnitDiv.Value;           // ADD 2008/07/17
                // 改ページ区分
                //this._stockAnalysisOrderListCndtn.NewPageDiv = (StockAnalysisOrderListCndtn.NewPageDivState)this.uos_NewPageDiv.Value;        // DEL 2008/09/30 コントロール変更の為
                this._stockAnalysisOrderListCndtn.NewPageDiv = (StockAnalysisOrderListCndtn.NewPageDivState)this.NewPageDivValue;               // ADD 2008/09/30
                //--- ADD 2008/07/24 ---------->>>>>
                // 印刷タイプ
                this._stockAnalysisOrderListCndtn.PrintTypeDiv = (StockAnalysisOrderListCndtn.PrintTypeDivState)this.uos_PrintTypeDiv.Value;
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
                this._stockAnalysisOrderListCndtn.PartsManagementDivide1 = (string[])new ArrayList(this._duplicationShelfNoList1.Values).ToArray(typeof(string));

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
                this._stockAnalysisOrderListCndtn.PartsManagementDivide2 = (string[])new ArrayList(this._duplicationShelfNoList2.Values).ToArray(typeof(string));
                //--- ADD 2008/07/24 ----------<<<<<
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
        // ---ADD 2008/09/30 ---------------------------------------->>>>>
        /// <summary>
        /// 数値項目　終了コード取得処理(Double型)
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private Double GetEndCode(TNedit tNedit, Double endCodeOnDB)
        {
            if (tNedit.GetValue() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetValue();
            }
        }
        // ---ADD 2008/09/30 ----------------------------------------<<<<<
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
		#region ◆ MAUKK02010UA
		#region ◎ MAUKK02010UA_Load Event
		/// <summary>
		/// MAUKK02010UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void DCZAI02141UA_Load ( object sender, EventArgs e )
		{
			string errMsg = string.Empty;

            // ---ADD 2008/10/01 ------------------------------------------->>>>>
            // Enter/Tab押下時、ガイドにフォーカスを当てない
            ub_St_WarehouseCodeGuide.TabStop = false;               // 倉庫From
            ub_Ed_WarehouseCodeGuide.TabStop = false;               // 倉庫To
            ub_St_CustomerCodeGuide.TabStop = false;                // 仕入先From
            ub_Ed_CustomerCodeGuide.TabStop = false;                // 仕入先To
            ub_St_GoodsMakerCdGuide.TabStop = false;                // メーカーFrom
            ub_Ed_GoodsMakerCdGuide.TabStop = false;                // メーカーTo
            ub_St_LargeGoodsGanreCodeGuide.TabStop = false;         // 商品大分類From
            ub_Ed_LargeGoodsGanreCodeGuide.TabStop = false;         // 商品大分類To
            ub_St_MediumGoodsGanreCodeGuide.TabStop = false;        // 商品中分類From
            ub_Ed_MediumGoodsGanreCodeGuide.TabStop = false;        // 商品中分類To
            ub_St_DetailGoodsGanreCodeGuide.TabStop = false;        // グループコードFrom
            ub_Ed_DetailGoodsGanreCodeGuide.TabStop = false;        // グループコードTo
            ub_St_BLGoodsCodeGuide.TabStop = false;                 // BLコードFrom
            ub_Ed_BLGoodsCodeGuide.TabStop = false;                 // BLコードTo
            // ---ADD 2008/10/01 -------------------------------------------<<<<<

            this.SetDuplicationShelfNo(clb_DuplicationShelfNo1, 72);        //ADD 2009/06/24 不具合対応[13585]
            this.SetDuplicationShelfNo(clb_DuplicationShelfNo2, 73);        //ADD 2009/06/24 不具合対応[13585]

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

            // ADD 2009/03/31 不具合対応[6217]：スペースキーでの項目選択機能を実装 ---------->>>>>
            PrintTypeDivRadioKeyPressHelper.ControlList.Add(this.uos_PrintTypeDiv);
            PrintTypeDivRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.rb_NewPageDivByWarehouse);
            NewPageDivRadioKeyPressHelper.ControlList.Add(this.rb_NewPageDivNone);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ADD 2009/03/31 不具合対応[6217]：スペースキーでの項目選択機能を実装 ----------<<<<<
		}
		#endregion

    	#endregion ◆ MAUKK02010UA

        # region [ガイドイベント]
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 倉庫ガイド用の拠点コードを取得
            sectionCode = GetWarehouseGuideSection( this._selectedSectionList );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            status = this._wareHouseAcs.ExecuteGuid(out this._wareHouse, this._enterpriseCode, sectionCode);
            if ( status != 0 ) return;

            string tag = ( string ) ( ( UltraButton ) sender ).Tag;
            TEdit targetControl = null;
            if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tEdit_WarehouseCode_St;
            else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tEdit_WarehouseCode_Ed;
            else return;

            // コード展開
            targetControl.DataText = this._wareHouse.WarehouseCode.TrimEnd();
            // 次フォーカス
            _guideNextFocusControl.GetNextControl( targetControl ).Focus();
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

            //    // 次フォーカス
            //    if ( _customerGuideOK )
            //    {
            //        if ( _customerGuidSender.Tag.ToString().CompareTo( "1" ) == 0 ) _guideNextFocusControl.GetNextControl( tne_St_CustomerCode ).Focus();
            //        else if ( _customerGuidSender.Tag.ToString().CompareTo( "2" ) == 0 ) _guideNextFocusControl.GetNextControl( tne_Ed_CustomerCode ).Focus();
            //    }
            //    this._customerGuidSender = null;

            //    this._customerGuid.Dispose();
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

            TEdit targetControl;
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

            targetControl.DataText = supplier.SupplierCd.ToString();

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
        //            if ( _customerGuidSender.Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tne_St_CustomerCode;
        //            else if ( _customerGuidSender.Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tne_Ed_CustomerCode;
        //            else return;

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
            if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl =  this.tNedit_GoodsMakerCd_St;
            else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tNedit_GoodsMakerCd_Ed;
            else return;

            targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();

            // 次フォーカス
            _guideNextFocusControl.GetNextControl( targetControl ).Focus();
        }

        /// <summary>
        /// 商品区分グループガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_LargeGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            //--- DEL 2008/07/24 ---------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //LGoodsGanre lGoodsGanre;
            //int status = this._goodsAcs.ExecuteLGoodsGanreGuid(this._enterpriseCode, out lGoodsGanre);
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.te_St_LargeGoodsGanreCode;
            //else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.te_Ed_LargeGoodsGanreCode;
            //else return;

            //targetControl.DataText = lGoodsGanre.LargeGoodsGanreCode.ToString().TrimEnd();
            //// 次フォーカス
            //_guideNextFocusControl.GetNextControl( targetControl ).Focus();
            //--- DEL 2008/07/24 ----------<<<<<

            //--- ADD 2008/07/24 ---------->>>>>
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status != 0) return;

            TEdit targetControl;
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

            targetControl.DataText = userGdBd.GuideCode.ToString();

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/24 ----------<<<<<
        }
        /// <summary>
        /// 商品区分ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            //--- DEL 2008/07/24 ---------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //MGoodsGanre mGoodsGanre;
            //int status = this._goodsAcs.ExecuteMGoodsGanreGuid(this._enterpriseCode, string.Empty, out mGoodsGanre);
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.te_St_MediumGoodsGanreCode;
            //else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.te_Ed_MediumGoodsGanreCode;
            //else return;

            //targetControl.DataText = mGoodsGanre.MediumGoodsGanreCode.ToString().TrimEnd();
            //// 次フォーカス
            //_guideNextFocusControl.GetNextControl( targetControl ).Focus();
            //--- DEL 2008/07/24 ----------<<<<<

            //--- ADD 2008/07/24 ---------->>>>>
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            GoodsGroupU goodsGroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TEdit targetControl;
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
            targetControl.DataText = goodsGroupU.GoodsMGroup.ToString();

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/24 ----------<<<<<
        }
        /// <summary>
        /// 商品区分詳細ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_DetailGoodsGanreCodeGuide_Click ( object sender, EventArgs e )
        {
            //--- DEL 2008/07/24 ---------->>>>>
            //if ( this._goodsAcs == null ) {
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //DGoodsGanre dGoodsGanre;
            //int status = this._goodsAcs.ExecuteDGoodsGanreGuid(this._enterpriseCode, out dGoodsGanre);
            //if ( status != 0 ) return;

            //TEdit targetControl;
            //if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.te_St_DetailGoodsGanreCode;
            //else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.te_Ed_DetailGoodsGanreCode;
            //else return;

            //targetControl.DataText = dGoodsGanre.DetailGoodsGanreCode.ToString().TrimEnd();
            //// 次フォーカス
            //_guideNextFocusControl.GetNextControl( targetControl ).Focus();
            //--- DEL 2008/07/24 ----------<<<<<

            //--- ADD 2008/07/24 ---------->>>>>
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // ガイドデータサーチモード(1:リモート)

            if (status != 0) return;

            TEdit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGloupCode_St;
                nextControl = this.tNedit_BLGloupCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGloupCode_Ed;
                nextControl = this.tNedit_BLGoodsCode_St;
            }
            else
            {
                return;
            }

            targetControl.DataText = bLGroupU.BLGroupCode.ToString();

            // フォーカス移動
            nextControl.Focus();
            //--- ADD 2008/07/24 ----------<<<<<
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

            TEdit targetControl;
            if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tNedit_BLGoodsCode_St;
            else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tNedit_BLGoodsCode_Ed;
            else return;

            targetControl.DataText = blGoodsCdUMnt.BLGoodsCode.ToString().TrimEnd();
            // 次フォーカス
            _guideNextFocusControl.GetNextControl( targetControl ).Focus();
        }
        /// <summary>
        /// 商品番号ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsNoGuid_Click ( object sender, EventArgs e )
        {
            if ( this._goodsGuid == null ) {
                this._goodsGuid = new MAKHN04110UA();
            }

            this._goodsUnitData = null;
            DialogResult status = this._goodsGuid.ShowGuide(this, this._enterpriseCode, out this._goodsUnitData);

            if ( status != DialogResult.OK ) return;

            TEdit targetControl;
            if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("1") == 0 ) targetControl = this.tEdit_GoodsNo_St;
            else if ( ( ( UltraButton ) sender ).Tag.ToString().CompareTo("2") == 0 ) targetControl = this.tEdit_GoodsNo_Ed;
            else return;

            targetControl.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
            // 次フォーカス
            _guideNextFocusControl.GetNextControl( targetControl ).Focus();
        }
        # endregion

        # region [進入・脱出]
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
        /// 出荷数脱出イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_ShipmentCnt_Leave( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// スペースなど数値変換してゼロになる場合は"0"をセットする
            //if ( (sender as TNedit).GetInt() == 0 )
            //{
            //    (sender as TNedit).Text = "0";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        # endregion

        # region [グループ圧縮・展開]
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
        # endregion

        #region [棚番入力制御]
        // --- ADD 2009/04/13 -------------------------------->>>>>
        /// <summary>
        /// tEdit_WarehouseShelfNo_St_KeyPressイベント
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
        /// tEdit_WarehouseShelfNo_Ed_KeyPressイベント
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
        #endregion

        #endregion ■ Control Event

        # region ■ ガイド後次フォーカス制御クラス ■
        /// <summary>
        /// ガイド後次フォーカス制御クラス
        /// </summary>
        internal class GuideNextFocusControl
        {
            private List<Control> _controls;
            private Dictionary<Control, int> _indexDic;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public GuideNextFocusControl()
            {
                _controls = new List<Control>();
                _indexDic = new Dictionary<Control, int>();
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="control"></param>
            public void Add( Control control )
            {
                _controls.Add( control );
                if ( !_indexDic.ContainsKey( control ) )
                {
                    _indexDic.Add( control, _controls.Count - 1 );
                }
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="collection"></param>
            public void AddRange( IEnumerable<Control> collection )
            {
                int stIndex = _controls.Count;
                _controls.AddRange( collection );
                int edIndex = _controls.Count - 1;

                for ( int i = stIndex; i <= edIndex; i++ )
                {
                    if ( !_indexDic.ContainsKey( _controls[i] ) )
                    {
                        _indexDic.Add( _controls[i], i );
                    }
                }
            }
            /// <summary>
            /// 対象コントロールクリア
            /// </summary>
            public void Clear()
            {
                _controls.Clear();
                _indexDic.Clear();
            }
            /// <summary>
            /// 次コントロール取得
            /// </summary>
            /// <param name="control"></param>
            /// <returns></returns>
            public Control GetNextControl( Control control )
            {
                int index = _indexDic[control];
                index++;

                for ( int i = index; i < _controls.Count; i++ )
                {
                    if ( !_controls[i].Visible || !_controls[i].Enabled )
                    {
                        continue;
                    }

                    if ( _controls[i] is TEdit )
                    {
                        if ( (_controls[i] as TEdit).ReadOnly == true )
                        {
                            continue;
                        }
                    }

                    return _controls[i];
                }
                return _controls[_controls.Count - 1];
            }
        }
        # endregion ■ ガイド後次フォーカス制御クラス ■

        // ---ADD 2008/09/30 ------------------------------------------------------------------------------------->>>>>
        /// <summary>
        /// 印刷タイプラジオボタン値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_PrintTypeDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)(sender as UltraOptionSet).Value == (int)StockAnalysisOrderListCndtn.PrintTypeDivState.ByWarehouse)
            {
                // 倉庫別
                this.NewPageDivEnabled = true;                                                      // 改ページ区分Enableプロパティ
            }
            else
            {
                // 全社計
                this.NewPageDivEnabled = false;                                                     // 改ページ区分Enableプロパティ
                this.NewPageDivValue = (int)StockAnalysisOrderListCndtn.PrintTypeDivState.Total;    // 改ページ区分Valueプロパティ
            }
        }

        /// <summary>
        /// 改ページ区分Valueプロパティ
        /// </summary>
        private int NewPageDivValue
        {
            get
            {
                if (this.rb_NewPageDivByWarehouse.Checked)
                {
                    // 倉庫毎
                    return (int)StockAnalysisOrderListCndtn.NewPageDivState.ByWarehouse;
                }
                else
                {
                    // しない
                    return (int)StockAnalysisOrderListCndtn.NewPageDivState.None;
                }
            }
            set
            {
                if (value == (int)StockAnalysisOrderListCndtn.NewPageDivState.ByWarehouse)
                {
                    // 倉庫毎
                    this.rb_NewPageDivNone.Checked = false;
                    this.rb_NewPageDivByWarehouse.Checked = true;
                }
                else
                {
                    // しない
                    this.rb_NewPageDivByWarehouse.Checked = false;
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
                return this.rb_NewPageDivByWarehouse.Enabled;   // 倉庫毎
            }
            set
            {
                this.rb_NewPageDivByWarehouse.Enabled = value;  // 倉庫毎
                this.rb_NewPageDivNone.Enabled = value;         // しない
            }
        }
        // ---ADD 2008/09/30 -------------------------------------------------------------------------------------<<<<<
    }
}