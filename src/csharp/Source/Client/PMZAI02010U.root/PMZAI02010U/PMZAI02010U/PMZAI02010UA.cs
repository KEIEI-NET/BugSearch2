//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫月報年報
// プログラム概要   : 在庫月報年報UIフォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30416 長沼 賢二
// 作 成 日  2008/08/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/06  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/02/13  修正内容 : 障害対応11471(当期の場合の期間チェックを追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/05  修正内容 : 不具合対応[12172]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/23  修正内容 : 不具合対応[12678]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/02  修正内容 : 不具合対応[12995]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/24  修正内容 : 不具合対応[13584]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李魏
// 修 正 日  2015/09/25  修正内容 : 障害対応#47391
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
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/06
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
    /// 在庫月報年報UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫月報年報UIフォームクラス</br>
    /// <br>Programmer : 30416 長沼 賢二</br>
    /// <br>Date       : 2008.08.06</br>
    /// <br>Update     : 2008/10/06 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>Update Note: 2009.02.13 30452 上野 俊治</br>
    /// <br>            ・障害対応11471(当期の場合の期間チェックを追加)</br>
    /// <br>Update Note: 2009.02.17 30452 上野 俊治</br>
    /// <br>            ・障害対応11471(当期の設定方を修正)</br>
    /// <br>           : 2009/03/05       照田 貴志　不具合対応[12172]</br>
    /// <br>           : 2009/03/23       照田 貴志　不具合対応[12678]</br>
    /// <br>           : 2009/04/02       照田 貴志　不具合対応[12995]</br>
    /// <br>           : 2009/06/24       照田 貴志　不具合対応[13584]</br>
    /// </remarks>
	public partial class PMZAI02010UA : Form,
                                IPrintConditionInpType,					// 帳票共通（条件入力タイプ）
                                IPrintConditionInpTypeSelectedSection,	// 帳票業務（条件入力）拠点選択
                                IPrintConditionInpTypePdfCareer			// 帳票業務（条件入力）PDF出力履歴管理
	{
		#region ■ Constructor
		/// <summary>
        /// 在庫月報年報UIフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫月報年報UIフォームクラスの初期化およびインスタンスの生成を行う</br>
		/// <br>Programmer : 30416 長沼 賢二</br>
		/// <br>Date       : 2008.08.06</br>
		/// <br></br>
		/// </remarks>
		public PMZAI02010UA ()
		{
			InitializeComponent();

			// 企業コード取得
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// 拠点用のHashtable作成
			this._selectedSectionList	= new Hashtable();

            // 売上全体設定アクセスクラス
            stc_SalesTtlStAcs = new SalesTtlStAcs();

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            // ---ADD 2009/03/23 不具合対応[12678] -------------->>>>>
            // UI設定保存コンポーネント設定
            this.SetUIMemInputControl();
            // ---ADD 2009/03/23 不具合対応[12678] --------------<<<<<
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
        // 小計印刷リスト
        private Hashtable _summalyPrintDivs = new Hashtable();
		#endregion ◆ Interface member

		// 企業コード
		private string _enterpriseCode = "";
		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// 抽出条件クラス
        private StockMonthYearReportCndtn _stockMonthYearReportCndtn;

        // 倉庫ガイド用
        private Warehouse _wareHouse;
        private WarehouseAcs _wareHouseAcs;

        // 仕入先
        SupplierAcs _supplierAcs;

        // 商品コード用
        private MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        private GoodsAcs _goodsAcs;
        private GoodsUnitData _goodsUnitData;

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        // 商品大分類
        UserGuideAcs _userGuideAcs;

        // 商品中分類
        GoodsGroupUAcs _goodsGroupUAcs;

        // BLグループ
        BLGroupUAcs _bLGroupUAcs;

        SalesTtlStAcs stc_SalesTtlStAcs;                 // 売上全体設定アクセスクラス

        // --- ADD 2008/10/06 --------------------------------------------------------------------------------------------->>>>>
        // 以下、スペースキー押下でラジオボタンを変更
        /// <summary>金額単位ラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _moneyUnitDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 金額単位ラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>金額単位ラジオボタンのKeyPressイベントのヘルパ</value>
        public OptionSetKeyPressEventHelper MoneyUnitDivRadioKeyPressHelper
        {
            get { return _moneyUnitDivRadioKeyPressHelper; }
        }

        /// <summary>発行タイプラジオボタンのKeyPressイベントのヘルパ</summary>
        private readonly OptionSetKeyPressEventHelper _printTypeDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// 発行タイプラジオボタンのKeyPressイベントのヘルパを取得します。
        /// </summary>
        /// <value>発行タイプラジオボタンのKeyPressイベントのヘルパ</value>
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
        // --- ADD 2008/10/06 ---------------------------------------------------------------------------------------------<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		#region ◆ Interface member
        //--IPrintConditionInpTypePdfCareerのプロパティ用変数 -------------------------
		// クラスID
        private const string ct_ClassID         = "PMZAI02010UA";
		// プログラムID
        private const string ct_PGID            = "PMZAI02010U";
		//// 帳票名称
		private string _printName				= "在庫月報年報";
        // 帳票キー	
        private string _printKey                = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // 保留
        // 管理区分リスト
        private Hashtable _duplicationShelfNoList1 = new Hashtable();
        // 管理区分リスト
        private Hashtable _duplicationShelfNoList2 = new Hashtable();
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
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
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

			// 画面→抽出条件クラス
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// 抽出条件の設定
            printInfo.jyoken            = this._stockMonthYearReportCndtn;
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
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
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
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
        /// </remarks>
		public void Show ( object parameter )
		{
            this._stockMonthYearReportCndtn = new StockMonthYearReportCndtn();

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
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
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
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
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
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
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
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
        /// </remarks>
		public bool InitVisibleCheckSection ( bool isDefaultState )
		{
            //return isDefaultState;            //DEL 2009/04/02 不具合対応[12995]
            return false;                       //ADD 2009/04/02 不具合対応[12995]
		}
		#endregion

		#region ◎ 計上拠点選択処理( 未実装 )
        /// <summary>
        /// 計上拠点選択処理( 未実装 )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: 未実装</br>
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
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
                /* ---DEL 2009/03/05 不具合対応[12172] -------------------------------->>>>>
                DateTime thisMonth;
                _dateGetAcs.GetThisYearMonth( out thisMonth );
                this.tde_St_AddUpYearMonth.SetDateTime( thisMonth );
                this.tde_Ed_AddUpYearMonth.SetDateTime( thisMonth );
                   ---DEL 2009/03/05 不具合対応[12172] --------------------------------<<<<< */
                // ---ADD 2009/03/05 不具合対応[12172] -------------------------------->>>>>
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
                // ---ADD 2009/03/05 不具合対応[12172] --------------------------------<<<<<


                // 初期値セット・文字列
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;

                // 初期値セット・区分
                this.NewPageDivValue = 0;

                this.uos_MoneyUnitDiv.Value = 0;
                this.uos_PrintTypeDiv.Value = 0;

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
                this.SetIconImage( this.ub_St_GoodsNoGuide, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_GoodsNoGuide, Size16_Index.STAR1 );

                // ---ADD 2009/03/23 不具合対応[12678] ---------------->>>>>
                // 初期表示は全てチェックあり(前回値が保存されている場合は前回値を優先させる)
                for (int i = 0; i <= this.clb_SummalyPrintDivs.Items.Count - 1; i++)
                {
                    this.clb_SummalyPrintDivs.SetItemChecked(i, true);
                }

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();
                // ---ADD 2009/03/23 不具合対応[12678] ----------------<<<<<

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
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

			const string ct_InputError = "の入力が不正です";
			const string ct_NoInput	   = "を入力して下さい";
			const string ct_RangeError = "の範囲指定に誤りがあります";
            const string ct_FullRangeError = "は１２ヶ月の範囲内で入力して下さい";
            const string ct_ErrorOfNotOnYear = "は同一年度内で入力して下さい"; // ADD 2009/02/17

            // 対象年月（開始～終了）
            if ((StockMonthYearReportCndtn.PrintTypeState)this.uos_PrintTypeDiv.Value == StockMonthYearReportCndtn.PrintTypeState.ThisMonth  // ADD 2009/02/17
                && CallCheckDateRange( out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth ) == false )
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
            //// --- ADD 2009/02/13 -------------------------------->>>>>
            else if ((StockMonthYearReportCndtn.PrintTypeState)this.uos_PrintTypeDiv.Value == StockMonthYearReportCndtn.PrintTypeState.ThisPeriod
                && CallCheckDateRangeForPeriod(out cdrResult, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth) == false)
            {
                switch (cdrResult)
                {
                    // --- ADD 2009/02/17 -------------------------------->>>>>
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("開始対象年月{0}", ct_NoInput);
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
                            errMessage = string.Format("終了対象年月{0}", ct_NoInput);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了対象年月{0}", ct_InputError);
                            errComponent = this.tde_Ed_AddUpYearMonth;
                        }
                        break;
                    // --- ADD 2009/02/17 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("対象年月{0}", ct_RangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("対象年月{0}", ct_FullRangeError);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    // --- ADD 2009/02/17 -------------------------------->>>>>
                    case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
                        {
                            errMessage = string.Format("対象年月{0}", ct_ErrorOfNotOnYear);
                            errComponent = this.tde_St_AddUpYearMonth;
                        }
                        break;
                    // --- ADD 2009/02/17 --------------------------------<<<<<
                }
                status = false;
            }
            // --- ADD 2009/02/13 --------------------------------<<<<<
            // 倉庫コード
            else if (
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo( this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() ) > 0) )
            {
                errMessage = string.Format( "倉庫{0}", ct_RangeError );
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
                errMessage = string.Format( "メーカー{0}", ct_RangeError );
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            // 商品大分類
            /* --- DEL 2008/10/06 TEdit→TNEdit変更の為 ----------------------------------------------------------------->>>>>
            else if (
                (this.tNedit_GoodsLGroup_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsLGroup_St.DataText.TrimEnd().CompareTo( this.tNedit_GoodsLGroup_Ed.DataText.TrimEnd() ) > 0) )
               --- DEL 2008/10/06 ---------------------------------------------------------------------------------------<<<<< */
            else if (this.tNedit_GoodsLGroup_St.GetInt() > GetEndCode(this.tNedit_GoodsLGroup_Ed))          //ADD 2008/10/06
            {
                errMessage = string.Format( "商品大分類{0}", ct_RangeError );
                errComponent = this.tNedit_GoodsLGroup_St;
                status = false;
            }
            // 商品中分類
            /* --- DEL 2008/10/06 TEdit→TNEdit変更の為 ----------------------------------------------------------------->>>>>
            else if (
                (this.tNedit_GoodsMGroup_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_GoodsMGroup_St.DataText.TrimEnd().CompareTo( this.tNedit_GoodsMGroup_Ed.DataText.TrimEnd() ) > 0) )
               --- DEL 2008/10/06 ---------------------------------------------------------------------------------------<<<<< */
            else if (this.tNedit_GoodsMGroup_St.GetInt() > GetEndCode(this.tNedit_GoodsMGroup_Ed))          //ADD 2008/10/06
            {
                errMessage = string.Format( "商品中分類{0}", ct_RangeError );
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
            }
            // BLグループ
            /* --- DEL 2008/10/06 TEdit→TNEdit変更の為 ----------------------------------------------------------------->>>>>
            else if (
                (this.tNedit_BLGloupCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tNedit_BLGloupCode_St.DataText.TrimEnd().CompareTo( this.tNedit_BLGloupCode_Ed.DataText.TrimEnd() ) > 0) )
               --- DEL 2008/10/06 ---------------------------------------------------------------------------------------<<<<< */
            else if (this.tNedit_BLGloupCode_St.GetInt() > GetEndCode(this.tNedit_BLGloupCode_Ed))          //ADD 2008/10/06
            {
                //errMessage = string.Format( "BLグループ{0}", ct_RangeError );     //DEL 2008/10/06 文言変更
                errMessage = string.Format("グループコード{0}", ct_RangeError);     //ADD 2008/10/06
                errComponent = this.tNedit_BLGloupCode_St;
                status = false;
            }
            // 商品番号
            else if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
            (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() ) > 0) )
            {
                errMessage = string.Format( "品番{0}", ct_RangeError );
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

        // --- ADD 2009/02/13 -------------------------------->>>>>
        /// <summary>
        /// 日付チェック処理呼び出し(当期期間チェック)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRangeForPeriod(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            // --- DEL 2009/02/17 -------------------------------->>>>>
            //TDateEdit startPeriodDate = new TDateEdit();

            //// 発行タイプ：当期
            //int year;
            //List<DateTime> startMonthDate;
            //List<DateTime> endMonthDate;
            //List<DateTime> yearMonth;

            //this._dateGetAcs.GetFinancialYearTable(0, out startMonthDate, out endMonthDate, out yearMonth, out year);
            //startPeriodDate.SetDateTime(startMonthDate[0]);

            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref startPeriodDate, ref endDate, false, false);
            //return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
            // --- DEL 2009/02/17 --------------------------------<<<<<
            // --- ADD 2009/02/17 -------------------------------->>>>>
            // 当期の場合は、年度跨りチェックを行う
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref startDate, ref endDate, false, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
            // --- ADD 2009/02/17 --------------------------------<<<<<
        }
        // --- ADD 2009/02/13 --------------------------------<<<<<

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
                /* ---DEL 2009/04/02 不具合対応[12995] ------------------------------------>>>>>
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
                   ---DEL 2009/04/02 不具合対応[12995] ------------------------------------<<<<< */
                _selectedSectionList.Clear();           //ADD 2009/04/02 不具合対応[12995] ※全社固定


                // 拠点オプション
                this._stockMonthYearReportCndtn.IsOptSection = this._isOptSection;
                // 企業コード
                this._stockMonthYearReportCndtn.EnterpriseCode = this._enterpriseCode;

                /*  --- DEL 2008/10/10 検索条件印字時、変換されていると都合が悪い為、データ抽出の直前に変換をかけるようにする--->>>>>
                if ((StockMonthYearReportCndtn.PrintTypeState)this.uos_PrintTypeDiv.Value == StockMonthYearReportCndtn.PrintTypeState.ThisMonth)
                {
                    // 開始年月度
                    this.tde_St_AddUpYearMonth.LongDate = this.tde_St_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMMdd → YYYYMM01
                    this._stockMonthYearReportCndtn.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                }
                else
                {
                    List<DateTime> startMonthDate;
                    List<DateTime> endMonthDate;
                    List<DateTime> yearMonth;
                    int year;

                    _dateGetAcs.GetFinancialYearTable(0, out startMonthDate, out endMonthDate, out yearMonth, out year);
                    this._stockMonthYearReportCndtn.St_AddUpYearMonth = startMonthDate[0];
                }
                   --- DEL 2008/10/10 -----------------------------------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/10 ----------------------------------------------------------------------------------------->>>>>
                // 開始年月度
                this.tde_St_AddUpYearMonth.LongDate = this.tde_St_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMMdd → YYYYMM01
                this._stockMonthYearReportCndtn.St_AddUpYearMonth = this.tde_St_AddUpYearMonth.GetDateTime();
                // --- ADD 2008/10/10 -----------------------------------------------------------------------------------------<<<<<
                // 終了年月度
                this.tde_Ed_AddUpYearMonth.LongDate = this.tde_Ed_AddUpYearMonth.LongDate / 100 * 100 + 1;   // YYYYMMdd → YYYYMM01
                this._stockMonthYearReportCndtn.Ed_AddUpYearMonth = this.tde_Ed_AddUpYearMonth.GetDateTime();
                // 拠点コード
                this._stockMonthYearReportCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // 開始倉庫コード
                this._stockMonthYearReportCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.DataText;
                // 終了倉庫コード
                this._stockMonthYearReportCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.DataText;
                // 開始仕入先コード
                this._stockMonthYearReportCndtn.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                // 終了仕入先コード
                //this._stockMonthYearReportCndtn.Ed_SupplierCd = GetEndCode(this.tNedit_SupplierCd_Ed, 99999999);      //DEL 2008/10/10 桁数変更
                this._stockMonthYearReportCndtn.Ed_SupplierCd = GetEndCode(this.tNedit_SupplierCd_Ed, 999999);          //ADD 2008/10/10
                // 開始商品メーカーコード
                this._stockMonthYearReportCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // 終了商品メーカーコード
                this._stockMonthYearReportCndtn.Ed_GoodsMakerCd = GetEndCode(tNedit_GoodsMakerCd_Ed, 9999);
                // 開始商品番号
                this._stockMonthYearReportCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.Text;
                // 終了商品番号
                this._stockMonthYearReportCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text;

                // 発行タイプ
                this._stockMonthYearReportCndtn.PrintType = (StockMonthYearReportCndtn.PrintTypeState)this.uos_PrintTypeDiv.Value;
                // 金額単位
                this._stockMonthYearReportCndtn.MoneyUnit = (StockMonthYearReportCndtn.MoneyUnitState)this.uos_MoneyUnitDiv.Value;

                // 改ページ区分
                this._stockMonthYearReportCndtn.NewPageDiv = (StockMonthYearReportCndtn.NewPageDivState)this.NewPageDivValue;
                // 小計印刷区分
                for (int index = 0; index < this.clb_SummalyPrintDivs.Items.Count; index++)
                {
                    // チェック有無取得
                    StockMonthYearReportCndtn.SummaryPrintDivState printDivState;
                    if (this.clb_SummalyPrintDivs.GetItemChecked(index) == true)
                    {
                        printDivState = StockMonthYearReportCndtn.SummaryPrintDivState.Print;
                    }
                    else
                    {
                        printDivState = StockMonthYearReportCndtn.SummaryPrintDivState.None;
                    }

                    switch (index)
                    {
                        // 倉庫計
                        case 0: this._stockMonthYearReportCndtn.WarehouseSummaryPrintDiv = printDivState; break;
                        // 仕入先計
                        case 1: this._stockMonthYearReportCndtn.SupplierSummaryPrintDiv = printDivState; break;
                        // メーカー計
                        case 2: this._stockMonthYearReportCndtn.GoodsMakerSummaryPrintDiv = printDivState; break;
                        // 商品区分グループ計
                        case 3: this._stockMonthYearReportCndtn.LargeGoodsGanreSummaryPrintDiv = printDivState; break;
                        // 商品区分計
                        case 4: this._stockMonthYearReportCndtn.MediumGoodsGanreSummaryPrintDiv = printDivState; break;
                        // 商品区分詳細計
                        case 5: this._stockMonthYearReportCndtn.DetailGoodsGanreSummaryPrintDiv = printDivState; break;
                        // (例外)
                        default: break;
                    }
                }                

                // 開始商品大分類コード
                this._stockMonthYearReportCndtn.St_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_St.Text;
                // 終了商品大分類コード
                this._stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode = this.tNedit_GoodsLGroup_Ed.Text;
                // 開始商品中分類コード
                this._stockMonthYearReportCndtn.St_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_St.Text;
                // 終了商品中分類コード
                this._stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode = this.tNedit_GoodsMGroup_Ed.Text;
                // 開始BLグループコード
                this._stockMonthYearReportCndtn.St_DetailGoodsGanreCode = this.tNedit_BLGloupCode_St.Text;
                // 終了BLグループコード
                this._stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode = this.tNedit_BLGloupCode_Ed.Text;

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
                this._stockMonthYearReportCndtn.PartsManagementDivide1 = (string[])new ArrayList(this._duplicationShelfNoList1.Values).ToArray(typeof(string));

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
                this._stockMonthYearReportCndtn.PartsManagementDivide2 = (string[])new ArrayList(this._duplicationShelfNoList2.Values).ToArray(typeof(string));

                SalesTtlSt salesTtlSt;

                //GrossProfitRateCheck(out salesTtlSt);     //DEL 2008/10/06 salesTtlSt=null時でも印刷可とする為
                // --- ADD 2008/10/06 ---------------------------------------->>>>>
                int ret = GrossProfitRateCheck(out salesTtlSt);
                if (ret == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                // --- ADD 2008/10/06 ----------------------------------------<<<<<
                
                    this._stockMonthYearReportCndtn.GrsProfitCheckBest = salesTtlSt.GrsProfitCheckBest;
                    this._stockMonthYearReportCndtn.GrsProfitCheckLower = salesTtlSt.GrsProfitCheckLower;
                    this._stockMonthYearReportCndtn.GrsProfitCheckUpper = salesTtlSt.GrsProfitCheckUpper;
                    this._stockMonthYearReportCndtn.GrsProfitChkBestSign = salesTtlSt.GrsProfitChkBestSign;
                    this._stockMonthYearReportCndtn.GrsProfitChkLowSign = salesTtlSt.GrsProfitChkLowSign;
                    this._stockMonthYearReportCndtn.GrsProfitChkUprSign = salesTtlSt.GrsProfitChkUprSign;
                    this._stockMonthYearReportCndtn.GrsProfitChkMaxSign = salesTtlSt.GrsProfitChkMaxSign;

                }   //ADD 2008/10/06

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
		/// <br>Programmer : 30416 長沼　賢二</br>
		/// <br>Date       : 2008.08.06</br>
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
		/// <br>Programmer : 30416 長沼　賢二</br>
		/// <br>Date       : 2008.08.06</br>
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

        /// <summary>
        /// 粗利率チェック処理
        /// </summary>
        /// <returns></returns>
        private int GrossProfitRateCheck(out SalesTtlSt salesTtlSt)
        {
            int status = 0;
            //ArrayList retList;
            //SalesTtlSt salesTtlSt = new SalesTtlSt();
            SalesTtlSt palamTtlSt = new SalesTtlSt();

            palamTtlSt.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            palamTtlSt.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 売上全体マスタ取得
            /* --- DEL 2008/10/06 コンパイルエラーとなる為(Readメソッドが変更された) ------------------------------------------>>>>>
            //stc_SalesTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            status = stc_SalesTtlStAcs.Read(out salesTtlSt, palamTtlSt);
               --- DEL 2008/10/06 ---------------------------------------------------------------------------------------------<<<<< */
            status = stc_SalesTtlStAcs.Read(out salesTtlSt, palamTtlSt.EnterpriseCode, palamTtlSt.SectionCode);     //ADD 2008/10/06   
            
            //------ADD BY 李魏 K2015/09/25 for Redmine#47391 MKアシスト／在庫月報年報（ﾏｰｸ）------->>>>>>>
            //ログイン拠点コードを削除する場合
            if (salesTtlSt == null || salesTtlSt.LogicalDeleteCode != 0)
            {
                //拠点を「全社共通」をセットする
                palamTtlSt.SectionCode = "00";
                status = stc_SalesTtlStAcs.Read(out salesTtlSt, palamTtlSt.EnterpriseCode, palamTtlSt.SectionCode);
            }
            //------ADD BY 李魏 K2015/09/25 for Redmine#47391 MKアシスト／在庫月報年報（ﾏｰｸ）------->>>>>>>

            return status;
        }

        // ---ADD 2009/03/23 不具合対応[12678] ---------------------------------------->>>>>
        /// <summary>
        /// UIMemInputの保存項目設定
        /// </summary>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.uos_MoneyUnitDiv);
            saveCtrAry.Add(this.uos_PrintTypeDiv);
            saveCtrAry.Add(this.rb_NewPageDivEachSummaly);
            saveCtrAry.Add(this.rb_NewPageDivNone);
            saveCtrAry.Add(this.clb_SummalyPrintDivs);
            saveCtrAry.Add(this.clb_DuplicationShelfNo1);
            saveCtrAry.Add(this.clb_DuplicationShelfNo2);
            saveCtrAry.Add(this.tEdit_WarehouseCode_St);
            saveCtrAry.Add(this.tEdit_WarehouseCode_Ed);
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
            saveCtrAry.Add(this.tEdit_GoodsNo_St);
            saveCtrAry.Add(this.tEdit_GoodsNo_Ed);

            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        // ---ADD 2009/03/23 不具合対応[12678] ----------------------------------------<<<<<

        // ---ADD 2009/06/24 不具合対応[13584] ------------------------------------>>>>>
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
        // ---ADD 2009/06/24 不具合対応[13584] ------------------------------------<<<<<
        #endregion ■ Private Method

		#region ■ Control Event
		#region ◆ PMZAI02010UA
		#region ◎ PMZAI02010UA_Load Event
		/// <summary>
        /// PMZAI02010UA_Load Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer	: 30416 長沼 賢二</br>
        /// <br>Date		: 2008.08.06</br>
        /// </remarks>
        private void PMZAI02010UA_Load(object sender, EventArgs e)
		{
			string errMsg = string.Empty;

            // ---ADD 2008/10/06 ----------------------->>>>>
            // 必須色に変更
            this.tde_St_AddUpYearMonth.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);    // 対象年月From
            this.tde_Ed_AddUpYearMonth.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);    // 対象年月To
            // 品番ガイドボタン非表示(ロード時に一瞬見える為、コントロール自体もFalseに変更しておく)
            this.ub_St_GoodsNoGuide.Visible = false;
            this.ub_Ed_GoodsNoGuide.Visible = false;
            // ラジオボタンをスペースキーで変更可
            MoneyUnitDivRadioKeyPressHelper.ControlList.Add(this.uos_MoneyUnitDiv);             // 金額単位
            MoneyUnitDivRadioKeyPressHelper.StartSpaceKeyControl();

            PrintTypeDivRadioKeyPressHelper.ControlList.Add(this.uos_PrintTypeDiv);             // 発行タイプ
            PrintTypeDivRadioKeyPressHelper.StartSpaceKeyControl();

            NewPageDivRadioKeyPressHelper.ControlList.Add(this.rb_NewPageDivEachSummaly);       // 改頁
            NewPageDivRadioKeyPressHelper.ControlList.Add(this.rb_NewPageDivNone);
            NewPageDivRadioKeyPressHelper.StartSpaceKeyControl();
            // ---ADD 2008/10/06 -----------------------<<<<<

            this.SetDuplicationShelfNo(clb_DuplicationShelfNo1, 72);        //ADD 2009/06/24 不具合対応[13584]
            this.SetDuplicationShelfNo(clb_DuplicationShelfNo2, 73);        //ADD 2009/06/24 不具合対応[13584]

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
		}
		#endregion

        #endregion ◆ PMZAI02010UA

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


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// スライダーの拠点コードをもとにガイド起動
            //if ( this._selectedSectionList.Count == 1 ) {
            //    foreach ( DictionaryEntry de in this._selectedSectionList ) {
            //        sectionCode = de.Value.ToString().TrimEnd();
            //    }
            //}

            // 倉庫ガイド用の拠点コードを取得
            //sectionCode = GetWarehouseGuideSection( this._selectedSectionList );          //DEL 2009/04/02 不具合対応[12995]
            sectionCode = string.Empty;                                                     //ADD 2009/04/02 不具合対応[12995]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
        }

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
        /// 商品大分類グループガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_LargeGoodsGanreCodeGuide_Click( object sender, EventArgs e )
        {
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
        }
        /// <summary>
        /// 商品中分類ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGanreCodeGuide_Click( object sender, EventArgs e )
        {
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
        }
        /// <summary>
        /// BLグループガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_DetailGoodsGanreCodeGuide_Click( object sender, EventArgs e )
        {
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
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }

            targetControl.DataText = bLGroupU.BLGroupCode.ToString();

            // フォーカス移動
            nextControl.Focus();
        }
        /// <summary>
        /// 商品番号ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsNoGuid_Click( object sender, EventArgs e )
        {
            if ( this._goodsGuid == null )
            {
                this._goodsGuid = new MAKHN04110UA();
            }

            this._goodsUnitData = null;
            DialogResult status = this._goodsGuid.ShowGuide( this, this._enterpriseCode, out this._goodsUnitData );

            if ( status != DialogResult.OK )
                return;

            TEdit targetControl;
            Control nextControl;
            if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 )
            {
                targetControl = this.tEdit_GoodsNo_St;
                nextControl = this.tEdit_GoodsNo_Ed;
            }
            else if ( ((UltraButton)sender).Tag.ToString().CompareTo( "2" ) == 0 )
            {
                targetControl = this.tEdit_GoodsNo_Ed;
                nextControl = targetControl;
            }
            else
            {
                return;
            }

            targetControl.DataText = this._goodsUnitData.GoodsNo.TrimEnd();
            nextControl.Focus();
        }


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
        /// 小計印刷区分変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uos_SummalyPrintDiv_ValueChanged ( object sender, EventArgs e )
        {
            // 小計印字有りの場合のみ、改ページ区分を選択可とする（「小計毎」の改ページは小計を印字する場合のみ選択可）
            if ((int)(sender as UltraOptionSet).Value == (int)StockMonthYearReportCndtn.SummalyPrintDivState.Print)
            {
                this.NewPageDivEnabled = true;
            }
            else {
                this.NewPageDivEnabled = false;
                this.NewPageDivValue = (int)StockMonthYearReportCndtn.NewPageDivState.None;
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
                    return (int)StockMonthYearReportCndtn.NewPageDivState.EachSummaly;
                }
                else {
                    // しない
                    return (int)StockMonthYearReportCndtn.NewPageDivState.None;
                }
            }
            set {
                if (value == (int)StockMonthYearReportCndtn.NewPageDivState.EachSummaly)
                {
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
        // --- ADD 2008/10/06 ------------------------------------------------------------------>>>>>
        /// <summary>
        /// チェックリストボックスフォーカスEnter時、選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBox_Enter(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                // 選択状態
                ((ListBox)sender).SetSelected(0, true);
            }
        }
        /// <summary>
        /// チェックリストボックスフォーカスLeave時、選択解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBox_Leave(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox listBox = (ListBox)sender;

                // 選択状態解除
                if (listBox.SelectedItem != null)
                {
                    listBox.SetSelected(listBox.SelectedIndex, false);
                }
            }
        }
        // --- ADD 2008/10/06 ------------------------------------------------------------------<<<<<
    }
}