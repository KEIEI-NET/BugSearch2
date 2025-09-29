//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ復旧処理 アクセスクラス
// プログラム概要   : ＵＯＥ復旧処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 : 【要件No.4】
//                                   処理区分の入力制御を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/01/21  修正内容 : Redmine#2512対応
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 楊明俊
// 修 正 日  2010/03/08  修正内容 : PM1006 処理区分の入力制御の対応
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : gaoyh
// 修 正 日  2010/04/26  修正内容 : PM1007 三菱UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 曹文傑
// 修 正 日  2010/12/31  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 朱 猛
// 修 正 日  2011/01/30  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : liyp
// 修 正 日  2011/03/01  修正内容 : 日産UOE自動化B対応
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 施炳中
// 修 正 日  2011/05/10  修正内容 : マツダUOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号  　　　　　  作成担当 : 田建委
// 修 正 日  2012/11/02  修正内容 : 2012/12/12配信分 Redmine#33224
//                                  復旧処理が自拠点のみを拾って送信する修正
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 李侠
// 修 正 日  2015/01/16  修正内容 : Redmine#44501
//                                  グリッド列使用・未使用判定のメソッドに通信アセンブリ「1003、1004」の追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ復旧処理アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ復旧処理の制御全般を行います。</br>
	/// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2008/12/01</br>
	/// <br></br>
	/// <br>UpdateNote : 2009/01/19 照田 貴志　不具合対応[9934]</br>
    /// <br>             2009/01/26 照田 貴志　不具合対応[10464]</br>
    /// <br>UpdateNote : 2010/03/08 楊明俊　PM1006</br>
    /// <br>             処理区分の入力制御の対応</br>
    /// <br>UpdateNote : 2010/04/26 gaoyh　PM1007</br>
    /// <br>             三菱UOE-WEB対応に伴う仕様追加</br>
    /// <br>UpdateNote : 2010/12/31 曹文傑</br>
    /// <br>             UOE自動化改良</br>
    /// <br>UpdateNote : 2011/01/30 朱 猛</br>
    /// <br>             UOE自動化改良</br>
    /// <br>UpdateNote : 2011/03/01 liyp</br>
    /// <br>             日産UOE自動化B対応</br>
    /// <br>UpdateNote : 2011/05/10 施炳中</br>
    /// <br>             マツダUOE-WEB対応に伴う仕様追加</br>
    /// <br>Update Note: 2012/11/02 田建委</br>
    /// <br>管理番号   : 10801804-00、2012/12/12配信分</br>
    /// <br>             Redmine#33224 復旧処理が自拠点のみを拾って送信する修正。</br>
    /// <br>Update Note: 2015/01/16 李 侠</br>
    /// <br>管理番号   : 11070149-00 RedMine#44501</br>
    /// <br>           : グリッド列使用・未使用判定のメソッドに通信アセンブリ「1003、1004」の追加</br>
	/// </remarks>
	public class StockInputAcs
	{
		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//アクセスクラス
		private static StockInputAcs _stockInputAcs;
		private StockInputInitDataAcs _stockInputInitDataAcs;
		private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs;

		//データーテーブル
		private StockInputDataSet _dataSet;
		private StockInputDataSet.OrderExpansionDataTable _orderDataTable;
		private StockInputDataSet.OrderExpansionDataTable _orderExpansionCache;

        //データセット
        private DataSet _sndDataSet = new DataSet();

        // グリッド検索結果データビュー
        private DataView _searchDataView = null;

		//変数
		private string _enterpriseCode;
		private bool _isDataCanged = false;

        // ---ADD 2009/01/26 不具合対応[10464] ----------------------------------------------->>>>>
        //構造体
        #region GridColEnableInfo構造体
        /// <summary>
        /// グリッド列使用/未使用判定　構造体
        /// </summary>
        internal struct GridColEnableStatusInfo
        {
            private bool _uoeSectionSlipNo;     //UOE拠点伝票番号
            private bool _boSlipNo1;            //BO伝票番号1
            private bool _boSlipNo2;            //BO伝票番号2
            private bool _boSlipNo3;            //BO伝票番号3
            private bool _makerFollow;          //メーカーフォロー
            private bool _boManagementNo;       //BO管理番号

            /// <summary>
            /// データ追加
            /// </summary>
            /// <param name="uoeSectionSlipNo">UOE拠点伝票番号</param>
            /// <param name="boSlipNo1">BO伝票番号1</param>
            /// <param name="boSlipNo2">BO伝票番号2</param>
            /// <param name="boSlipNo3">BO伝票番号3</param>
            /// <param name="makerFollow">メーカーフォロー</param>
            /// <param name="boManagementNo">BO管理番号</param>
            public void Add(bool uoeSectionSlipNo, bool boSlipNo1, bool boSlipNo2, bool boSlipNo3, bool makerFollow, bool boManagementNo)
            {
                _uoeSectionSlipNo = uoeSectionSlipNo;
                _boSlipNo1 = boSlipNo1;
                _boSlipNo2 = boSlipNo2;
                _boSlipNo3 = boSlipNo3;
                _makerFollow = makerFollow;
                _boManagementNo = boManagementNo;
            }

            /// <summary>UOE拠点伝票番号</summary>
            public bool UOESectionSlipNo { get { return _uoeSectionSlipNo; } }
            /// <summary>BO伝票番号1</summary>
            public bool BOSlipNo1 { get { return _boSlipNo1; } }
            /// <summary>BO伝票番号2</summary>
            public bool BOSlipNo2 { get { return _boSlipNo2; } }
            /// <summary>BO伝票番号3</summary>
            public bool BOSlipNo3 { get { return _boSlipNo3; } }
            /// <summary>メーカーフォロー</summary>
            public bool MakerFollow { get { return _makerFollow; } }
            /// <summary>BO管理番号</summary>
            public bool BOManagementNo { get { return _boManagementNo; } }
        }
        #endregion

        //HashTable
        Hashtable _gridColEnableStatusHTable = null;        // グリッド列使用/未使用判定(key：通信アセンブリID)
        // ---ADD 2009/01/26 不具合対応[10464] -----------------------------------------------<<<<<
		# endregion

		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
        #region Public Const Member

        // 各種ステータス
        public const int ROWSTATUS_NORMAL = 0;
        public const int ROWSTATUS_COPY = 1;
        public const int ROWSTATUS_CUT = 2;
        public const int EDITSTATUS_AllOK = 0;
        public const int EDITSTATUS_StockCountOnly = 1;
        public const int EDITSTATUS_AllDisable = 2;
        public const int EDITSTATUS_AllReadOnly = 3;
        public const string PRODUCT_NUMBER_STRING = "＊＊＊";
        public const int MODE_PRODUCTNUMBER_INPUT = 0;
        public const int MODE_BELONGINFO_INPUT = 1;
        public const int MODE_STOCKSLIP_INPUT_NORMAL = 0;
        public const int MODE_STOCKSLIP_INPUT_RETURN = 1;
        public const int MODE_STOCKSLIP_INPUT_RED = 2;
        public const int MODE_STOCKSLIP_INPUT_TRUSTADDUP = 3;
        public const int MODE_STOCKSLIP_INPUT_CHANGESTOCKSTATUS = 4;
        public const int MODE_STOCKSLIP_INPUT_READONLY = 9;

        /// <summary>初期明細行数</summary>
        public static readonly int ctCOUNT_RowInit = 50;
        /// <summary>明細最大行数</summary>
        public static readonly int ctCOUNT_RowMax = 999;
        /// <summary>明細行追加単位行数</summary>
        public static readonly int ctCOUNT_RowAdd = 1;

		// メッセージ
		private const string MESSAGE_NotFound = "更新対象のデータが存在しません。";

		//業務区分
        private const Int32 ctTerminalDiv_Restore = 1;	//復旧
        private const Int32 ctTerminalDiv_Cancel = 2;   //取消処理
        #endregion

        // ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Events
		/// <summary>データ変更後発生イベント</summary>
		public event EventHandler DataChanged;
		# endregion

		// ===================================================================================== //
		// 列挙体
		// ===================================================================================== //
		# region Enums
		/// <summary>
		/// 仕入単価入力モード
		/// </summary>
		public enum StockUnitPriceInputType : int
		{
			StockUnitPriceFl = 0,
			StockUnitTaxPrice = 1,
			StockUnitPriceFlDisplay = 2            
		}
		#endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region ＵＯＥ送受信制御アクセスクラス
        /// <summary>
        /// ＵＯＥ送受信制御アクセスクラス
        /// </summary>
        public UoeSndRcvCtlAcs uoeSndRcvCtlAcs
        {
            get { return _stockInputInitDataAcs.uoeSndRcvCtlAcs; }
        }
        # endregion

        # region ＵＯＥ送受信ＪＮＬアクセスクラス
        /// <summary>
        /// ＵＯＥ送受信ＪＮＬアクセスクラス
        /// </summary>
        public UoeSndRcvJnlAcs uoeSndRcvJnlAcs
        {
            get { return _stockInputInitDataAcs.uoeSndRcvJnlAcs; }
        }
        # endregion

        # region ＵＯＥ発注データアクセスクラス
        /// <summary>
        /// ＵＯＥ発注データアクセスクラス
        /// </summary>
        public UOEOrderDtlAcs uOEOrderDtlAcs
        {
            get { return _stockInputInitDataAcs.uOEOrderDtlAcs; }
        }
        # endregion

        # region データセット取得処理
        /// <summary>
        /// データセット取得処理
        /// </summary>
        public DataSet sndDataSet
		{
            get { return this._sndDataSet; }
		}
        # endregion

        # region UOE発注＜DataTable＞
        /// <summary>
        /// UOE発注＜DataTable＞
        /// </summary>
        public DataTable UOEOrderDtlTable
        {
            get { return this.sndDataSet.Tables[UOEOrderDtlSchema.CT_SendUOEOrderDtlDataTable]; }
        }
        # endregion

        # region 仕入明細＜DataTable＞
        /// <summary>
        /// 仕入明細＜DataTable＞
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this.sndDataSet.Tables[StockDetailSchema.CT_SendStockDetailDataTable]; }
        }
        # endregion

        # region 発注検索データセット取得処理
        /// <summary>
		/// 発注検索データセット取得処理
		/// </summary>
		/// <returns>伝票検索データセット</returns>
		public StockInputDataSet DataSet
		{
			get { return this._dataSet; }
		}
        # endregion

        # region 発注検索データテーブル取得処理
        /// <summary>
		/// 発注検索データテーブル取得処理
		/// </summary>
		/// <returns>伝票検索データセット</returns>
		public StockInputDataSet.OrderExpansionDataTable orderDataTable
		{
			get { return _orderDataTable; }
		}
        # endregion

        # region 発注検索データキャッシュテーブル取得処理
        /// <summary>
		/// 発注検索データキャッシュテーブル取得処理
		/// </summary>
		/// <returns>伝票検索データセット</returns>
		public StockInputDataSet.OrderExpansionDataTable OrderExpansionCache
		{
			get { return this._orderExpansionCache; }
			set { this._orderExpansionCache = value; }
		}
        # endregion

        # region グリッド検索結果データビュー
        /// <summary>
        /// グリッド検索結果データビュー
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        public DataView searchDataView
        {
            get { return this._searchDataView; }
            set { this._searchDataView = value; }
        }
        # endregion

        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private StockInputAcs ()
        {
            // 変数初期化
            this._dataSet = new StockInputDataSet();
			this._orderDataTable = this._dataSet.OrderExpansion;
#if False
			this._orderExpansion = new OrderExpansion();
#endif

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._stockInputInitDataAcs = StockInputInitDataAcs.GetInstance();
			this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();

   			//DataSet初期化
            _sndDataSet = new DataSet();

            //データセットクリア処理
			ClearOrderFormListResultTbl();

            this._searchDataView = new DataView();

            //HashTable初期化
            this.CreateGridColEnableStatusHTable();     //グリッド列使用/未使用判定HashTable    //ADD 2009/01/26 不具合対応[10464]
        }

        /// <summary>
        /// ＵＯＥ復旧処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>ＵＯＥ復旧処理アクセスクラス インスタンス</returns>
        public static StockInputAcs GetInstance ()
        {
            if ( _stockInputAcs == null ) {
                _stockInputAcs = new StockInputAcs();
            }

            return _stockInputAcs;
        }

        // ---ADD 2009/01/26 不具合対応[10464] -------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド列使用/未使用判定HashTable作成
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote  : 2010/03/08 楊明俊 処理区分の入力制御の対応</br>
        /// <br>UpdateNote  : 2010/12/31 曹文傑 UOE自動化改良</br>
        /// <br>UpdateNote  : 2011/01/30 朱 猛 UOE自動化改良</br>
        /// <br>UpdateNote  : 2011/03/01 liyp  日産UOE自動化B対応</br>
        /// <br>UpdateNote  : 2011/05/10 施炳中 グリッド列使用/未使用判定HashTableの変更</br>
        /// <br>Update Note : 2015/01/16 李 侠</br>
        /// <br>管理番号    : 11070149-00 RedMine#44501</br>
        /// <br>            : グリッド列使用・未使用判定のメソッドに通信アセンブリ「1003、1004」の追加</br>
        /// </remarks>
        private void CreateGridColEnableStatusHTable()
        {
            //通信アセンブリID、UOE拠点伝票番号Status、BO伝票番号1Status、BO伝票番号2Status、BO伝票番号3Status、メーカーフォローStatus、BO管理番号Status
            this.AddGridColEnableStatusHTable(0, false, false, false, false, false, false);         //値なし
            this.AddGridColEnableStatusHTable(102, true, true, true, true, true, false);            //トヨタ
            this.AddGridColEnableStatusHTable(103, true, true, true, true, true, false);            //トヨタ UOE Web // ADD 2009/12/29 xuxh
            this.AddGridColEnableStatusHTable(202, true, true, true, true, true, true);             //日産
            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            this.AddGridColEnableStatusHTable(203, true, true, true, true, true, true);             //日産 UOE Web 
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
            this.AddGridColEnableStatusHTable(204, true, true, true, true, true, true);             //日産 UOE Web（自動） // ADD 2010/12/31
            this.AddGridColEnableStatusHTable(301, true, true, true, false, true, false);           //三菱
            this.AddGridColEnableStatusHTable(302, true, true, true, false, true, false);           //三菱 UOE Web // ADD 2010/04/26 gaoyh
            this.AddGridColEnableStatusHTable(303, true, true, true, false, true, false);           //三菱 UOE Web（自動） // ADD 2010/12/31
            this.AddGridColEnableStatusHTable(401, true, true, true, false, true, false);           //旧マツダ
            this.AddGridColEnableStatusHTable(402, true, true, true, false, true, false);           //新マツダ
            this.AddGridColEnableStatusHTable(501, true, true, false, false, false, false);         //ホンダ
            this.AddGridColEnableStatusHTable(502, true, true, false, false, false, false);         //ホンダ e-Parts // ADD 2009/12/29 xuxh
            this.AddGridColEnableStatusHTable(1001, true, true, false, false, false, false);        //優良
            // --- ADD 2015/01/16 李侠 グリッド列使用・未使用判定の追加---------------------------------------->>>>>
            this.AddGridColEnableStatusHTable(1003, true, true, false, false, false, false);        //御NET-WEB
            this.AddGridColEnableStatusHTable(1004, true, true, false, false, false, false);        //明治産業WEB
            // --- ADD 2015/01/16 李侠 グリッド列使用・未使用判定の追加----------------------------------------<<<<<
            this.AddGridColEnableStatusHTable(104, true, true, true, true, true, false);            // トヨタ自動処理 // ADD 2011/01/30 朱 猛
            // --- ADD 2011/03/01 ---------------------------------------->>>>>
            this.AddGridColEnableStatusHTable(205, true, true, true, true, true, true);             //日産 UOE Web 
            this.AddGridColEnableStatusHTable(206, true, true, true, true, true, true);             //日産 UOE Web 
            // --- ADD 2011/03/01 ----------------------------------------<<<<<
            // --- ADD 2011/05/10 ---------------------------------------->>>>>
            this.AddGridColEnableStatusHTable(403, true, true, true, false, true, false);           //マツダWEB
            // --- ADD 2011/05/10 ----------------------------------------<<<<<
        }
        // ---ADD 2009/01/26 不具合対応[10464] --------------------------------------------------------<<<<<

        # endregion

		// ===================================================================================== //
		// DBデータアクセス処理
		// ===================================================================================== //
		# region ＵＯＥ発注データ検索

		# region 発注データテーブル キャッシュ処理
		/// <summary>
		/// 発注データテーブル キャッシュ処理
		/// </summary>
		private void CacheStockSlipTable()
		{
			if (OrderExpansionCache == null)
			{
				OrderExpansionCache = new StockInputDataSet.OrderExpansionDataTable();
			}

			this.orderDataTable.AcceptChanges();
            OrderExpansionCache = (StockInputDataSet.OrderExpansionDataTable)this._orderDataTable.Copy();
		}

		/// <summary>
		/// データセットクリア処理
		/// </summary>
		private void ClearOrderFormListResultTbl()
		{
			//グリッド用テーブルのクリア
            this.orderDataTable.Rows.Clear();

            UOEOrderDtlSchema.SettingDataSet(ref _sndDataSet, UOEOrderDtlSchema.CT_SendUOEOrderDtlDataTable);    //UOE発注データ
            StockDetailSchema.SettingDataSet(ref _sndDataSet, StockDetailSchema.CT_SendStockDetailDataTable);    //仕入明細

			// キャッシュデータの取り直し(クリア状態にする)
			this.CacheStockSlipTable();
		}

		/// <summary>
		/// OrderExpansionRowの比較
		/// </summary>
		/// <param name="sourceRow"></param>
		/// <returns></returns>
		private bool CompareRowCache(StockInputDataSet.OrderExpansionRow sourceRow)
		{
			StockInputDataSet.OrderExpansionRow targetRow;

			targetRow = this.OrderExpansionCache.FindByOrderNo(sourceRow.OrderNo);

			return (CompareRow(sourceRow, targetRow));
		}

		/// <summary>
		/// OrderExpansionRowの比較
		/// </summary>
		/// <param name="sourceRow"></param>
		/// <param name="targetRow"></param>
		/// <returns></returns>
		private bool CompareRow(StockInputDataSet.OrderExpansionRow sourceRow, StockInputDataSet.OrderExpansionRow targetRow)
		{
			bool result = false;

			if ((sourceRow == null) || (targetRow == null))
			{
				return false;
			}
            if((targetRow.OnlineNo != sourceRow.OnlineNo)
            || (targetRow.OnlineRowNo != sourceRow.OnlineRowNo)
            || (targetRow.GoodsNo != sourceRow.GoodsNo)
            || (targetRow.GoodsName != sourceRow.GoodsName)
            || (targetRow.GoodsMakerCd != sourceRow.GoodsMakerCd)
            || (targetRow.MakerName != sourceRow.MakerName)
            || (targetRow.AnswerPartsNo != sourceRow.AnswerPartsNo)
            || (targetRow.AcceptAnOrderCnt != sourceRow.AcceptAnOrderCnt)
            || (targetRow.AnswerListPrice != sourceRow.AnswerListPrice)
            || (targetRow.AnswerSalesUnitCost != sourceRow.AnswerSalesUnitCost)
            || (targetRow.UOESectionSlipNo != sourceRow.UOESectionSlipNo)
            || (targetRow.UOESectOutGoodsCnt != sourceRow.UOESectOutGoodsCnt)
            || (targetRow.BOSlipNo1 != sourceRow.BOSlipNo1)
            || (targetRow.BOShipmentCnt1 != sourceRow.BOShipmentCnt1)
            || (targetRow.BOSlipNo2 != sourceRow.BOSlipNo2)
            || (targetRow.BOShipmentCnt2 != sourceRow.BOShipmentCnt2)
            || (targetRow.BOSlipNo3 != sourceRow.BOSlipNo3)
            || (targetRow.BOShipmentCnt3 != sourceRow.BOShipmentCnt3)
            || (targetRow.MakerFollowCnt != sourceRow.MakerFollowCnt)
            || (targetRow.BOManagementNo != sourceRow.BOManagementNo)
            || (targetRow.EOAlwcCount != sourceRow.EOAlwcCount)
            || (targetRow.SupplierCd != sourceRow.SupplierCd)
            || (targetRow.SupplierSnm != sourceRow.SupplierSnm)
            || (targetRow.UoeRemark1 != sourceRow.UoeRemark1)
            || (targetRow.UoeRemark2 != sourceRow.UoeRemark2)
            || (targetRow.UOEDeliGoodsDiv != sourceRow.UOEDeliGoodsDiv)
            || (targetRow.DeliveredGoodsDivNm != sourceRow.DeliveredGoodsDivNm)
            || (targetRow.FollowDeliGoodsDiv != sourceRow.FollowDeliGoodsDiv)
            || (targetRow.FollowDeliGoodsDivNm != sourceRow.FollowDeliGoodsDivNm)
            || (targetRow.UOEResvdSection != sourceRow.UOEResvdSection)
            || (targetRow.UOEResvdSectionNm != sourceRow.UOEResvdSectionNm)
            || (targetRow.EmployeeCode != sourceRow.EmployeeCode)
            || (targetRow.EmployeeName != sourceRow.EmployeeName))
			{
				result = false;
			}
			else
			{
				result = true;
			}

			return result;
		}

        # endregion

		# region ■ ＵＯＥ発注データ 検索処理 ■
		/// <summary>
		/// ＵＯＥ発注データ 検索処理
		/// </summary>
		/// <param name="inpDisplay">検索条件クラス</param>
		/// <param name="message">メッセージ</param>
		/// <returns>ステータス</returns>
		public int SearchDB(InpDisplay inpDisplay, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				//テーブルクリア
				this.ClearOrderFormListResultTbl();

				//ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;

                List<UOEOrderDtlWork> list = new List<UOEOrderDtlWork>();
                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out message);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    return(status);
                }
                if((uOEOrderDtlWorkList.Count != stockDetailWorkList.Count)
                || (uOEOrderDtlWorkList.Count == 0)
                || (stockDetailWorkList.Count == 0))
                {
                    message = "条件に一致するデータは存在しません。";
                    return ((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND);
                }

                //-----------------------------------------------------------
                // ＵＯＥ発注データの格納
                //-----------------------------------------------------------
                int i = 0;
                int onlineNoBf = -1;
                string processDivBf = string.Empty;
                foreach(UOEOrderDtlWork uOEOrderDtlWork in uOEOrderDtlWorkList)
                {
                    //-----------------------------------------------------------
                    // 画面表示用DataTableの設定
                    //-----------------------------------------------------------
                    # region 画面表示用DataTableの設定
                    #region エラーメッセージ、処理区分設定
                    // エラーメッセージ、処理区分
                    string processDiv = "";
                    string dataSendErrMsg = "";

                    //if ((uOEOrderDtlWork.OnlineNo == 200000654) && (uOEOrderDtlWork.OnlineRowNo == 1))        //テスト用
                    //{
                    //    uOEOrderDtlWork.DataSendCode = 3;
                    //}

                    if (uOEOrderDtlWork.DataSendCode == 2)
                    {
                        processDiv = "1";     // 処理区分：発注
                        dataSendErrMsg = "送信エラー";
                    }
                    else if (uOEOrderDtlWork.DataSendCode == 3)
                    {
                        processDiv = "2";     // 処理区分：回答埋込
                        dataSendErrMsg = "受信エラー";
                    }
                    else if (uOEOrderDtlWork.DataSendCode == 4)
                    {
                        processDiv = "2";     // 処理区分：回答埋込
                        dataSendErrMsg = "その他";
                    }

                    // オンライン番号が同じものは合わせる
                    if (onlineNoBf == uOEOrderDtlWork.OnlineNo)
                    {
                        //processDiv = processDivBf;
                        processDiv = "";
                    }
                    #endregion

                    i++;
                    this.orderDataTable.AddOrderExpansionRow(
                        //グリッド制御用
                                                i,								    // NoDisplay
                                                i,								    // No
                                                ROWSTATUS_NORMAL,					// RowStatus
                                                uOEOrderDtlWork.UOESupplierCd,
                                                uOEOrderDtlWork.UOESupplierName,
                                                uOEOrderDtlWork.CommAssemblyId,
                                                uOEOrderDtlWork.OnlineNo,
                                                uOEOrderDtlWork.OnlineRowNo,
                                                uOEOrderDtlWork.DataSendCode,
                                                dataSendErrMsg,
                                                uOEOrderDtlWork.CashRegisterNo,
                                                uOEOrderDtlWork.SendTerminalNo,
                                                uOEOrderDtlWork.InputDay,
                                                uOEOrderDtlWork.CustomerCode,
                                                uOEOrderDtlWork.CustomerSnm,
                                                uOEOrderDtlWork.GoodsNo,
                                                uOEOrderDtlWork.GoodsName,
                                                uOEOrderDtlWork.GoodsMakerCd,
                                                uOEOrderDtlWork.MakerName,
                                                uOEOrderDtlWork.AnswerPartsNo,
                                                uOEOrderDtlWork.AcceptAnOrderCnt,
                                                uOEOrderDtlWork.AnswerListPrice,
                                                uOEOrderDtlWork.AnswerSalesUnitCost,
                                                uOEOrderDtlWork.UOESectionSlipNo,
                                                uOEOrderDtlWork.UOESectOutGoodsCnt,
                                                uOEOrderDtlWork.BOSlipNo1,
                                                uOEOrderDtlWork.BOShipmentCnt1,
                                                uOEOrderDtlWork.BOSlipNo2,
                                                uOEOrderDtlWork.BOShipmentCnt2,
                                                uOEOrderDtlWork.BOSlipNo3,
                                                uOEOrderDtlWork.BOShipmentCnt3,
                                                uOEOrderDtlWork.MakerFollowCnt,
                                                uOEOrderDtlWork.BOManagementNo,
                                                uOEOrderDtlWork.EOAlwcCount,
                                                uOEOrderDtlWork.SupplierCd,
                                                uOEOrderDtlWork.SupplierSnm,
                                                uOEOrderDtlWork.UoeRemark1,
                                                uOEOrderDtlWork.UoeRemark2,
                                                uOEOrderDtlWork.UOEDeliGoodsDiv,
                                                uOEOrderDtlWork.DeliveredGoodsDivNm,
                                                uOEOrderDtlWork.FollowDeliGoodsDiv,
                                                uOEOrderDtlWork.FollowDeliGoodsDivNm,
                                                uOEOrderDtlWork.UOEResvdSection,
                                                uOEOrderDtlWork.UOEResvdSectionNm,
                                                uOEOrderDtlWork.EmployeeCode,
                                                uOEOrderDtlWork.EmployeeName,
                                                false,								    //InpSelect
                                                processDiv,                             //InpProcessDiv
                                                uOEOrderDtlWork.AnswerPartsNo,          //InpAnswerPartsNo
                                                uOEOrderDtlWork.AcceptAnOrderCnt,	    //InpAcceptAnOrderCnt
                                                uOEOrderDtlWork.AnswerListPrice,        //InpAnswerListPrice
                                                uOEOrderDtlWork.AnswerSalesUnitCost,    //InpAnswerSalesUnitCost
                                                uOEOrderDtlWork.UOESectionSlipNo,       //InpUOESectionSlipNo
                                                uOEOrderDtlWork.UOESectOutGoodsCnt,     //InpSectOutGoodsCnt
                                                uOEOrderDtlWork.BOSlipNo1,              //InpBOSlipNo1
                                                uOEOrderDtlWork.BOShipmentCnt1,         //InpBOShipmentCnt1
                                                uOEOrderDtlWork.BOSlipNo2,              //InpBOSlipNo2
                                                uOEOrderDtlWork.BOShipmentCnt2,         //InpBOShipmentCnt2
                                                uOEOrderDtlWork.BOSlipNo3,              //InpBOSlipNo3
                                                uOEOrderDtlWork.BOShipmentCnt3,         //InpBOShipmentCnt3
                                                uOEOrderDtlWork.MakerFollowCnt,         //InpMakerFollowCnt
                                                uOEOrderDtlWork.BOManagementNo,         //InpBOManagementNo
                                                uOEOrderDtlWork.EOAlwcCount);           //InpEOAlwcCount

                    this._searchDataView.Table = this.orderDataTable;
                    this._searchDataView.RowFilter = "";
                    # endregion

                    //-----------------------------------------------------------
                    // ＵＯＥ発注データをDataTableの設定
                    //-----------------------------------------------------------
                    # region ＵＯＥ発注データをDataTableの設定
                    DataRow dr = UOEOrderDtlTable.NewRow();
                    CreateUOEOrderDtlSchema(ref dr, uOEOrderDtlWork);
                    UOEOrderDtlTable.Rows.Add(dr);
                    # endregion

                    //処理区分設定(オンライン番号同一判定)用
                    onlineNoBf = uOEOrderDtlWork.OnlineNo;
                    processDivBf = processDiv;
                }

                IsDataChanged = true; 

                // 検索データのキャッシュ
                //this.CacheStockSlipTable();

                //-----------------------------------------------------------
                //仕入明細の格納
                //-----------------------------------------------------------
                # region 仕入明細の格納をDataTableの設定
                foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                {
                    DataRow dr = StockDetailTable.NewRow();
                    CreateStockDetailSchema(ref dr, stockDetailWork);
                    StockDetailTable.Rows.Add(dr);
                }
                # endregion
            }
			catch (Exception ex)
			{
				message = ex.Message;
				return -1;
			}
			return status;
		}
        # endregion

        # region ＵＯＥ発注データの検索
        /// <summary>
        /// ＵＯＥ発注データの検索
        /// </summary>
        /// <param name="onlineNo">オンライン番号</param>
        /// <param name="onlineRowNo">オンライン行番号</param>
        /// <param name="uOEOrderDtlWork">ＵＯＥ発注データ</param>
        /// <param name="uOEOrderDtlWork">仕入明細</param>
        /// <returns>ステータス</returns>
        private int FindUOEOrderDtlSchema(Int32 onlineNo, Int32 onlineRowNo, out UOEOrderDtlWork uOEOrderDtlWork, out StockDetailWork stockDetailWork)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWork = new UOEOrderDtlWork();
            stockDetailWork = new StockDetailWork();

            try
            {
                status = FindUOEOrderDtlSchema(onlineNo, onlineRowNo, out uOEOrderDtlWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = FindStockDetailSchema(uOEOrderDtlWork.SupplierFormal, uOEOrderDtlWork.StockSlipDtlNum, out stockDetailWork);
                }
                if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    uOEOrderDtlWork = null;
                    stockDetailWork = null;
                }
            }
            catch (Exception)
            {
                uOEOrderDtlWork = null;
                stockDetailWork = null;
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// ＵＯＥ発注データの検索
        /// </summary>
        /// <param name="onlineNo">オンライン番号</param>
        /// <param name="onlineRowNo">オンライン行番号</param>
        /// <param name="uOEOrderDtlWork">ＵＯＥ発注データ</param>
        /// <returns>ステータス</returns>
        private int FindUOEOrderDtlSchema(Int32 onlineNo, Int32 onlineRowNo, out UOEOrderDtlWork uOEOrderDtlWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWork = new UOEOrderDtlWork();

            try
            {
                //Findパラメータ設定
                object[] findObject = new object[2];
                findObject[0] = onlineNo;
                findObject[1] = onlineRowNo;
                DataRow findRow = UOEOrderDtlTable.Rows.Find(findObject);

                uOEOrderDtlWork = CreateUOEOrderDtlWorkFromSchema(findRow);
            }
            catch (Exception)
            {
                uOEOrderDtlWork = null;
                status = -1;
            }
            return status;
        }
        # endregion

        # region 仕入明細データの検索
        /// <summary>
        /// 仕入明細データの検索
        /// </summary>
        /// <param name="onlineNo">仕入形式</param>
        /// <param name="onlineRowNo">仕入明細通番</param>
        /// <param name="uOEOrderDtlWork">仕入明細</param>
        /// <returns>ステータス</returns>
        private int FindStockDetailSchema(Int32 supplierFormal, Int64 stockSlipDtlNum, out StockDetailWork stockDetailWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            stockDetailWork = new StockDetailWork();

            try
            {
                //Findパラメータ設定
                object[] findObject = new object[2];
                findObject[0] = supplierFormal;
                findObject[1] = stockSlipDtlNum;
                DataRow findRow = StockDetailTable.Rows.Find(findObject);

                stockDetailWork = CreateStockDetailWorkFromSchema(findRow);
            }
            catch (Exception)
            {
                stockDetailWork = null;
                status = -1;
            }
            return status;
        }
        # endregion

        # region ＵＯＥ発注データテーブルRow作成
        /// <summary>
        /// ＵＯＥ発注データテーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">ＵＯＥ発注データクラス</param>
        private void CreateUOEOrderDtlSchema(ref DataRow dr, UOEOrderDtlWork rst)
        {
            dr[UOEOrderDtlSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// 作成日時
            dr[UOEOrderDtlSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// 更新日時
            dr[UOEOrderDtlSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// 企業コード
            dr[UOEOrderDtlSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            dr[UOEOrderDtlSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// 更新従業員コード
            dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// 更新アセンブリID1
            dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// 更新アセンブリID2
            dr[UOEOrderDtlSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// 論理削除区分
            dr[UOEOrderDtlSchema.ct_Col_SystemDivCd] = rst.SystemDivCd;	// システム区分
            dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderNo] = rst.UOESalesOrderNo;	// UOE発注番号
            dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderRowNo] = rst.UOESalesOrderRowNo;	// UOE発注行番号
            dr[UOEOrderDtlSchema.ct_Col_SendTerminalNo] = rst.SendTerminalNo;	// 送信端末番号
            dr[UOEOrderDtlSchema.ct_Col_UOESupplierCd] = rst.UOESupplierCd;	// UOE発注先コード
            dr[UOEOrderDtlSchema.ct_Col_UOESupplierName] = rst.UOESupplierName;	// UOE発注先名称
            dr[UOEOrderDtlSchema.ct_Col_CommAssemblyId] = rst.CommAssemblyId;	// 通信アセンブリID
            dr[UOEOrderDtlSchema.ct_Col_OnlineNo] = rst.OnlineNo;	// オンライン番号
            dr[UOEOrderDtlSchema.ct_Col_OnlineRowNo] = rst.OnlineRowNo;	// オンライン行番号
            dr[UOEOrderDtlSchema.ct_Col_SalesDate] = rst.SalesDate;	// 売上日付
            dr[UOEOrderDtlSchema.ct_Col_InputDay] = rst.InputDay;	// 入力日
            dr[UOEOrderDtlSchema.ct_Col_DataUpdateDateTime] = rst.DataUpdateDateTime;	// データ更新日時
            dr[UOEOrderDtlSchema.ct_Col_UOEKind] = rst.UOEKind;	// UOE種別
            dr[UOEOrderDtlSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum;	// 売上伝票番号
            dr[UOEOrderDtlSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus;	// 受注ステータス
            dr[UOEOrderDtlSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum;	// 売上明細通番
            dr[UOEOrderDtlSchema.ct_Col_SectionCode] = rst.SectionCode;	// 拠点コード
            dr[UOEOrderDtlSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// 部門コード
            dr[UOEOrderDtlSchema.ct_Col_CustomerCode] = rst.CustomerCode;	// 得意先コード
            dr[UOEOrderDtlSchema.ct_Col_CustomerSnm] = rst.CustomerSnm;	// 得意先略称
            dr[UOEOrderDtlSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo;	// レジ番号
            dr[UOEOrderDtlSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo;	// 共通通番
            dr[UOEOrderDtlSchema.ct_Col_SupplierFormal] = rst.SupplierFormal;	// 仕入形式
            dr[UOEOrderDtlSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo;	// 仕入伝票番号
            dr[UOEOrderDtlSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum;	// 仕入明細通番
            dr[UOEOrderDtlSchema.ct_Col_BoCode] = rst.BoCode;	// BO区分
            dr[UOEOrderDtlSchema.ct_Col_UOEDeliGoodsDiv] = rst.UOEDeliGoodsDiv;	// 納品区分
            dr[UOEOrderDtlSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm;	// 納品区分名称
            dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDiv] = rst.FollowDeliGoodsDiv;	// フォロー納品区分
            dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDivNm] = rst.FollowDeliGoodsDivNm;	// フォロー納品区分名称
            dr[UOEOrderDtlSchema.ct_Col_UOEResvdSection] = rst.UOEResvdSection;	// UOE指定拠点
            dr[UOEOrderDtlSchema.ct_Col_UOEResvdSectionNm] = rst.UOEResvdSectionNm;	// UOE指定拠点名称
            dr[UOEOrderDtlSchema.ct_Col_EmployeeCode] = rst.EmployeeCode;	// 従業員コード
            dr[UOEOrderDtlSchema.ct_Col_EmployeeName] = rst.EmployeeName;	// 従業員名称
            dr[UOEOrderDtlSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd;	// 商品メーカーコード
            dr[UOEOrderDtlSchema.ct_Col_MakerName] = rst.MakerName;	// メーカー名称
            dr[UOEOrderDtlSchema.ct_Col_GoodsNo] = rst.GoodsNo;	// 商品番号
            dr[UOEOrderDtlSchema.ct_Col_GoodsNoNoneHyphen] = rst.GoodsNoNoneHyphen;	// ハイフン無商品番号
            dr[UOEOrderDtlSchema.ct_Col_GoodsName] = rst.GoodsName;	// 商品名称
            dr[UOEOrderDtlSchema.ct_Col_WarehouseCode] = rst.WarehouseCode;	// 倉庫コード
            dr[UOEOrderDtlSchema.ct_Col_WarehouseName] = rst.WarehouseName;	// 倉庫名称
            dr[UOEOrderDtlSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo;	// 倉庫棚番
            dr[UOEOrderDtlSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt;	// 受注数量
            dr[UOEOrderDtlSchema.ct_Col_ListPrice] = rst.ListPrice;	// 定価（浮動）
            dr[UOEOrderDtlSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost;	// 原価単価
            dr[UOEOrderDtlSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// 仕入先コード
            dr[UOEOrderDtlSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// 仕入先略称
            dr[UOEOrderDtlSchema.ct_Col_UoeRemark1] = rst.UoeRemark1;	// ＵＯＥリマーク１
            dr[UOEOrderDtlSchema.ct_Col_UoeRemark2] = rst.UoeRemark2;	// ＵＯＥリマーク２
            dr[UOEOrderDtlSchema.ct_Col_ReceiveDate] = rst.ReceiveDate;	// 受信日付
            dr[UOEOrderDtlSchema.ct_Col_ReceiveTime] = rst.ReceiveTime;	// 受信時刻
            dr[UOEOrderDtlSchema.ct_Col_AnswerMakerCd] = rst.AnswerMakerCd;	// 回答メーカーコード
            dr[UOEOrderDtlSchema.ct_Col_AnswerPartsNo] = rst.AnswerPartsNo;	// 回答品番
            dr[UOEOrderDtlSchema.ct_Col_AnswerPartsName] = rst.AnswerPartsName;	// 回答品名
            dr[UOEOrderDtlSchema.ct_Col_SubstPartsNo] = rst.SubstPartsNo;	// 代替品番
            dr[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt] = rst.UOESectOutGoodsCnt;	// UOE拠点出庫数
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1] = rst.BOShipmentCnt1;	// BO出庫数1
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2] = rst.BOShipmentCnt2;	// BO出庫数2
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3] = rst.BOShipmentCnt3;	// BO出庫数3
            dr[UOEOrderDtlSchema.ct_Col_MakerFollowCnt] = rst.MakerFollowCnt;	// メーカーフォロー数
            dr[UOEOrderDtlSchema.ct_Col_NonShipmentCnt] = rst.NonShipmentCnt;	// 未出庫数
            dr[UOEOrderDtlSchema.ct_Col_UOESectStockCnt] = rst.UOESectStockCnt;	// UOE拠点在庫数
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount1] = rst.BOStockCount1;	// BO在庫数1
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount2] = rst.BOStockCount2;	// BO在庫数2
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount3] = rst.BOStockCount3;	// BO在庫数3
            dr[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo] = rst.UOESectionSlipNo;	// UOE拠点伝票番号
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo1] = rst.BOSlipNo1;	// BO伝票番号１
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo2] = rst.BOSlipNo2;	// BO伝票番号２
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo3] = rst.BOSlipNo3;	// BO伝票番号３
            dr[UOEOrderDtlSchema.ct_Col_EOAlwcCount] = rst.EOAlwcCount;	// EO引当数
            dr[UOEOrderDtlSchema.ct_Col_BOManagementNo] = rst.BOManagementNo;	// BO管理番号
            dr[UOEOrderDtlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice;	// 回答定価
            dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost;	// 回答原価単価
            dr[UOEOrderDtlSchema.ct_Col_UOESubstMark] = rst.UOESubstMark;	// UOE代替マーク
            dr[UOEOrderDtlSchema.ct_Col_UOEStockMark] = rst.UOEStockMark;	// UOE在庫マーク
            dr[UOEOrderDtlSchema.ct_Col_PartsLayerCd] = rst.PartsLayerCd;	// 層別コード
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1] = rst.MazdaUOEShipSectCd1;	// UOE出荷拠点コード１（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2] = rst.MazdaUOEShipSectCd2;	// UOE出荷拠点コード２（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3] = rst.MazdaUOEShipSectCd3;	// UOE出荷拠点コード３（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1] = rst.MazdaUOESectCd1;	// UOE拠点コード１（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2] = rst.MazdaUOESectCd2;	// UOE拠点コード２（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3] = rst.MazdaUOESectCd3;	// UOE拠点コード３（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4] = rst.MazdaUOESectCd4;	// UOE拠点コード４（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5] = rst.MazdaUOESectCd5;	// UOE拠点コード５（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6] = rst.MazdaUOESectCd6;	// UOE拠点コード６（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7] = rst.MazdaUOESectCd7;	// UOE拠点コード７（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1] = rst.MazdaUOEStockCnt1;	// UOE在庫数１（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2] = rst.MazdaUOEStockCnt2;	// UOE在庫数２（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3] = rst.MazdaUOEStockCnt3;	// UOE在庫数３（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4] = rst.MazdaUOEStockCnt4;	// UOE在庫数４（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5] = rst.MazdaUOEStockCnt5;	// UOE在庫数５（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6] = rst.MazdaUOEStockCnt6;	// UOE在庫数６（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7] = rst.MazdaUOEStockCnt7;	// UOE在庫数７（マツダ）
            dr[UOEOrderDtlSchema.ct_Col_UOEDistributionCd] = rst.UOEDistributionCd;	// UOE卸コード
            dr[UOEOrderDtlSchema.ct_Col_UOEOtherCd] = rst.UOEOtherCd;	// UOE他コード
            dr[UOEOrderDtlSchema.ct_Col_UOEHMCd] = rst.UOEHMCd;	// UOEＨＭコード
            dr[UOEOrderDtlSchema.ct_Col_BOCount] = rst.BOCount;	// ＢＯ数
            dr[UOEOrderDtlSchema.ct_Col_UOEMarkCode] = rst.UOEMarkCode;	// UOEマークコード
            dr[UOEOrderDtlSchema.ct_Col_SourceShipment] = rst.SourceShipment;	// 出荷元
            dr[UOEOrderDtlSchema.ct_Col_ItemCode] = rst.ItemCode;	// アイテムコード
            dr[UOEOrderDtlSchema.ct_Col_UOECheckCode] = rst.UOECheckCode;	// UOEチェックコード
            dr[UOEOrderDtlSchema.ct_Col_HeadErrorMassage] = rst.HeadErrorMassage;	// ヘッドエラーメッセージ
            dr[UOEOrderDtlSchema.ct_Col_LineErrorMassage] = rst.LineErrorMassage;	// ラインエラーメッセージ
            dr[UOEOrderDtlSchema.ct_Col_DataSendCode] = rst.DataSendCode;	// データ送信区分
            dr[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = rst.DataRecoverDiv;	// データ復旧区分
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec] = rst.EnterUpdDivSec;	// 入庫更新区分（拠点）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1] = rst.EnterUpdDivBO1;	// 入庫更新区分（BO1）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2] = rst.EnterUpdDivBO2;	// 入庫更新区分（BO2）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3] = rst.EnterUpdDivBO3;	// 入庫更新区分（BO3）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker] = rst.EnterUpdDivMaker;	// 入庫更新区分（ﾒｰｶｰ）
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO] = rst.EnterUpdDivEO;	// 入庫更新区分（EO）
            dr[UOEOrderDtlSchema.ct_Col_DtlRelationGuid] = rst.DtlRelationGuid;	// 明細関連付けGUID
        }
        # endregion

        # region ＵＯＥ発注データ＜DataRow → クラス＞作成
        /// <summary>
        /// ＵＯＥ発注データ＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">ＵＯＥ発注データ</param>
        private UOEOrderDtlWork CreateUOEOrderDtlWorkFromSchema(DataRow dr)
        {
            UOEOrderDtlWork rst = new UOEOrderDtlWork();

            try
            {
                rst.CreateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_CreateDateTime];	// 作成日時
                rst.UpdateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_UpdateDateTime];	// 更新日時
                rst.EnterpriseCode = (string)dr[UOEOrderDtlSchema.ct_Col_EnterpriseCode];	// 企業コード
                rst.FileHeaderGuid = (Guid)dr[UOEOrderDtlSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[UOEOrderDtlSchema.ct_Col_UpdEmployeeCode];	// 更新従業員コード
                rst.UpdAssemblyId1 = (string)dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId1];	// 更新アセンブリID1
                rst.UpdAssemblyId2 = (string)dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId2];	// 更新アセンブリID2
                rst.LogicalDeleteCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_LogicalDeleteCode];	// 論理削除区分
                rst.SystemDivCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_SystemDivCd];	// システム区分
                rst.UOESalesOrderNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderNo];	// UOE発注番号
                rst.UOESalesOrderRowNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderRowNo];	// UOE発注行番号
                rst.SendTerminalNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_SendTerminalNo];	// 送信端末番号
                rst.UOESupplierCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESupplierCd];	// UOE発注先コード
                rst.UOESupplierName = (string)dr[UOEOrderDtlSchema.ct_Col_UOESupplierName];	// UOE発注先名称
                rst.CommAssemblyId = (string)dr[UOEOrderDtlSchema.ct_Col_CommAssemblyId];	// 通信アセンブリID
                rst.OnlineNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_OnlineNo];	// オンライン番号
                rst.OnlineRowNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_OnlineRowNo];	// オンライン行番号
                rst.SalesDate = (DateTime)dr[UOEOrderDtlSchema.ct_Col_SalesDate];	// 売上日付
                rst.InputDay = (DateTime)dr[UOEOrderDtlSchema.ct_Col_InputDay];	// 入力日
                rst.DataUpdateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_DataUpdateDateTime];	// データ更新日時
                rst.UOEKind = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOEKind];	// UOE種別
                rst.SalesSlipNum = (string)dr[UOEOrderDtlSchema.ct_Col_SalesSlipNum];	// 売上伝票番号
                rst.AcptAnOdrStatus = (Int32)dr[UOEOrderDtlSchema.ct_Col_AcptAnOdrStatus];	// 受注ステータス
                rst.SalesSlipDtlNum = (Int64)dr[UOEOrderDtlSchema.ct_Col_SalesSlipDtlNum];	// 売上明細通番
                rst.SectionCode = (string)dr[UOEOrderDtlSchema.ct_Col_SectionCode];	// 拠点コード
                rst.SubSectionCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_SubSectionCode];	// 部門コード
                rst.CustomerCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_CustomerCode];	// 得意先コード
                rst.CustomerSnm = (string)dr[UOEOrderDtlSchema.ct_Col_CustomerSnm];	// 得意先略称
                rst.CashRegisterNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_CashRegisterNo];	// レジ番号
                rst.CommonSeqNo = (Int64)dr[UOEOrderDtlSchema.ct_Col_CommonSeqNo];	// 共通通番
                rst.SupplierFormal = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierFormal];	// 仕入形式
                rst.SupplierSlipNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierSlipNo];	// 仕入伝票番号
                rst.StockSlipDtlNum = (Int64)dr[UOEOrderDtlSchema.ct_Col_StockSlipDtlNum];	// 仕入明細通番
                rst.BoCode = (string)dr[UOEOrderDtlSchema.ct_Col_BoCode];	// BO区分
                rst.UOEDeliGoodsDiv = (string)dr[UOEOrderDtlSchema.ct_Col_UOEDeliGoodsDiv];	// 納品区分
                rst.DeliveredGoodsDivNm = (string)dr[UOEOrderDtlSchema.ct_Col_DeliveredGoodsDivNm];	// 納品区分名称
                rst.FollowDeliGoodsDiv = (string)dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDiv];	// フォロー納品区分
                rst.FollowDeliGoodsDivNm = (string)dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDivNm];	// フォロー納品区分名称
                rst.UOEResvdSection = (string)dr[UOEOrderDtlSchema.ct_Col_UOEResvdSection];	// UOE指定拠点
                rst.UOEResvdSectionNm = (string)dr[UOEOrderDtlSchema.ct_Col_UOEResvdSectionNm];	// UOE指定拠点名称
                rst.EmployeeCode = (string)dr[UOEOrderDtlSchema.ct_Col_EmployeeCode];	// 従業員コード
                rst.EmployeeName = (string)dr[UOEOrderDtlSchema.ct_Col_EmployeeName];	// 従業員名称
                rst.GoodsMakerCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_GoodsMakerCd];	// 商品メーカーコード
                rst.MakerName = (string)dr[UOEOrderDtlSchema.ct_Col_MakerName];	// メーカー名称
                rst.GoodsNo = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsNo];	// 商品番号
                rst.GoodsNoNoneHyphen = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsNoNoneHyphen];	// ハイフン無商品番号
                rst.GoodsName = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsName];	// 商品名称
                rst.WarehouseCode = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseCode];	// 倉庫コード
                rst.WarehouseName = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseName];	// 倉庫名称
                rst.WarehouseShelfNo = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseShelfNo];	// 倉庫棚番
                rst.AcceptAnOrderCnt = (Double)dr[UOEOrderDtlSchema.ct_Col_AcceptAnOrderCnt];	// 受注数量
                rst.ListPrice = (Double)dr[UOEOrderDtlSchema.ct_Col_ListPrice];	// 定価（浮動）
                rst.SalesUnitCost = (Double)dr[UOEOrderDtlSchema.ct_Col_SalesUnitCost];	// 原価単価
                rst.SupplierCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierCd];	// 仕入先コード
                rst.SupplierSnm = (string)dr[UOEOrderDtlSchema.ct_Col_SupplierSnm];	// 仕入先略称
                rst.UoeRemark1 = (string)dr[UOEOrderDtlSchema.ct_Col_UoeRemark1];	// ＵＯＥリマーク１
                rst.UoeRemark2 = (string)dr[UOEOrderDtlSchema.ct_Col_UoeRemark2];	// ＵＯＥリマーク２
                rst.ReceiveDate = (DateTime)dr[UOEOrderDtlSchema.ct_Col_ReceiveDate];	// 受信日付
                rst.ReceiveTime = (Int32)dr[UOEOrderDtlSchema.ct_Col_ReceiveTime];	// 受信時刻
                rst.AnswerMakerCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_AnswerMakerCd];	// 回答メーカーコード
                rst.AnswerPartsNo = (string)dr[UOEOrderDtlSchema.ct_Col_AnswerPartsNo];	// 回答品番
                rst.AnswerPartsName = (string)dr[UOEOrderDtlSchema.ct_Col_AnswerPartsName];	// 回答品名
                rst.SubstPartsNo = (string)dr[UOEOrderDtlSchema.ct_Col_SubstPartsNo];	// 代替品番
                rst.UOESectOutGoodsCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt];	// UOE拠点出庫数
                rst.BOShipmentCnt1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1];	// BO出庫数1
                rst.BOShipmentCnt2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2];	// BO出庫数2
                rst.BOShipmentCnt3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3];	// BO出庫数3
                rst.MakerFollowCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_MakerFollowCnt];	// メーカーフォロー数
                rst.NonShipmentCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_NonShipmentCnt];	// 未出庫数
                rst.UOESectStockCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESectStockCnt];	// UOE拠点在庫数
                rst.BOStockCount1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount1];	// BO在庫数1
                rst.BOStockCount2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount2];	// BO在庫数2
                rst.BOStockCount3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount3];	// BO在庫数3
                rst.UOESectionSlipNo = (string)dr[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo];	// UOE拠点伝票番号
                rst.BOSlipNo1 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo1];	// BO伝票番号１
                rst.BOSlipNo2 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo2];	// BO伝票番号２
                rst.BOSlipNo3 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo3];	// BO伝票番号３
                rst.EOAlwcCount = (Int32)dr[UOEOrderDtlSchema.ct_Col_EOAlwcCount];	// EO引当数
                rst.BOManagementNo = (string)dr[UOEOrderDtlSchema.ct_Col_BOManagementNo];	// BO管理番号
                rst.AnswerListPrice = (Double)dr[UOEOrderDtlSchema.ct_Col_AnswerListPrice];	// 回答定価
                rst.AnswerSalesUnitCost = (Double)dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];	// 回答原価単価
                rst.UOESubstMark = (string)dr[UOEOrderDtlSchema.ct_Col_UOESubstMark];	// UOE代替マーク
                rst.UOEStockMark = (string)dr[UOEOrderDtlSchema.ct_Col_UOEStockMark];	// UOE在庫マーク
                rst.PartsLayerCd = (string)dr[UOEOrderDtlSchema.ct_Col_PartsLayerCd];	// 層別コード
                rst.MazdaUOEShipSectCd1 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1];	// UOE出荷拠点コード１（マツダ）
                rst.MazdaUOEShipSectCd2 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2];	// UOE出荷拠点コード２（マツダ）
                rst.MazdaUOEShipSectCd3 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3];	// UOE出荷拠点コード３（マツダ）
                rst.MazdaUOESectCd1 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1];	// UOE拠点コード１（マツダ）
                rst.MazdaUOESectCd2 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2];	// UOE拠点コード２（マツダ）
                rst.MazdaUOESectCd3 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3];	// UOE拠点コード３（マツダ）
                rst.MazdaUOESectCd4 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4];	// UOE拠点コード４（マツダ）
                rst.MazdaUOESectCd5 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5];	// UOE拠点コード５（マツダ）
                rst.MazdaUOESectCd6 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6];	// UOE拠点コード６（マツダ）
                rst.MazdaUOESectCd7 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7];	// UOE拠点コード７（マツダ）
                rst.MazdaUOEStockCnt1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1];	// UOE在庫数１（マツダ）
                rst.MazdaUOEStockCnt2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2];	// UOE在庫数２（マツダ）
                rst.MazdaUOEStockCnt3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3];	// UOE在庫数３（マツダ）
                rst.MazdaUOEStockCnt4 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4];	// UOE在庫数４（マツダ）
                rst.MazdaUOEStockCnt5 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5];	// UOE在庫数５（マツダ）
                rst.MazdaUOEStockCnt6 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6];	// UOE在庫数６（マツダ）
                rst.MazdaUOEStockCnt7 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7];	// UOE在庫数７（マツダ）
                rst.UOEDistributionCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEDistributionCd];	// UOE卸コード
                rst.UOEOtherCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEOtherCd];	// UOE他コード
                rst.UOEHMCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEHMCd];	// UOEＨＭコード
                rst.BOCount = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOCount];	// ＢＯ数
                rst.UOEMarkCode = (string)dr[UOEOrderDtlSchema.ct_Col_UOEMarkCode];	// UOEマークコード
                rst.SourceShipment = (string)dr[UOEOrderDtlSchema.ct_Col_SourceShipment];	// 出荷元
                rst.ItemCode = (string)dr[UOEOrderDtlSchema.ct_Col_ItemCode];	// アイテムコード
                rst.UOECheckCode = (string)dr[UOEOrderDtlSchema.ct_Col_UOECheckCode];	// UOEチェックコード
                rst.HeadErrorMassage = (string)dr[UOEOrderDtlSchema.ct_Col_HeadErrorMassage];	// ヘッドエラーメッセージ
                rst.LineErrorMassage = (string)dr[UOEOrderDtlSchema.ct_Col_LineErrorMassage];	// ラインエラーメッセージ
                rst.DataSendCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_DataSendCode];	// データ送信区分
                rst.DataRecoverDiv = (Int32)dr[UOEOrderDtlSchema.ct_Col_DataRecoverDiv];	// データ復旧区分
                rst.EnterUpdDivSec = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec];	// 入庫更新区分（拠点）
                rst.EnterUpdDivBO1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1];	// 入庫更新区分（BO1）
                rst.EnterUpdDivBO2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2];	// 入庫更新区分（BO2）
                rst.EnterUpdDivBO3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3];	// 入庫更新区分（BO3）
                rst.EnterUpdDivMaker = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker];	// 入庫更新区分（ﾒｰｶｰ）
                rst.EnterUpdDivEO = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO];	// 入庫更新区分（EO）
                rst.DtlRelationGuid = (Guid)dr[UOEOrderDtlSchema.ct_Col_DtlRelationGuid];	// 明細関連付けGUID
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion

        # region 仕入明細テーブルRow作成
        /// <summary>
        /// 仕入明細テーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">仕入明細クラス</param>
        private void CreateStockDetailSchema(ref DataRow dr, StockDetailWork rst)
        {
            dr[StockDetailSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// 作成日時
            dr[StockDetailSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// 更新日時
            dr[StockDetailSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// 企業コード
            dr[StockDetailSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            dr[StockDetailSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// 更新従業員コード
            dr[StockDetailSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// 更新アセンブリID1
            dr[StockDetailSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// 更新アセンブリID2
            dr[StockDetailSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// 論理削除区分
            dr[StockDetailSchema.ct_Col_AcceptAnOrderNo] = rst.AcceptAnOrderNo;	// 受注番号
            dr[StockDetailSchema.ct_Col_SupplierFormal] = rst.SupplierFormal;	// 仕入形式
            dr[StockDetailSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo;	// 仕入伝票番号
            dr[StockDetailSchema.ct_Col_StockRowNo] = rst.StockRowNo;	// 仕入行番号
            dr[StockDetailSchema.ct_Col_SectionCode] = rst.SectionCode;	// 拠点コード
            dr[StockDetailSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// 部門コード
            dr[StockDetailSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo;	// 共通通番
            dr[StockDetailSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum;	// 仕入明細通番
            dr[StockDetailSchema.ct_Col_SupplierFormalSrc] = rst.SupplierFormalSrc;	// 仕入形式（元）
            dr[StockDetailSchema.ct_Col_StockSlipDtlNumSrc] = rst.StockSlipDtlNumSrc;	// 仕入明細通番（元）
            dr[StockDetailSchema.ct_Col_AcptAnOdrStatusSync] = rst.AcptAnOdrStatusSync;	// 受注ステータス（同時）
            dr[StockDetailSchema.ct_Col_SalesSlipDtlNumSync] = rst.SalesSlipDtlNumSync;	// 売上明細通番（同時）
            dr[StockDetailSchema.ct_Col_StockSlipCdDtl] = rst.StockSlipCdDtl;	// 仕入伝票区分（明細）
            dr[StockDetailSchema.ct_Col_StockInputCode] = rst.StockInputCode;	// 仕入入力者コード
            dr[StockDetailSchema.ct_Col_StockInputName] = rst.StockInputName;	// 仕入入力者名称
            dr[StockDetailSchema.ct_Col_StockAgentCode] = rst.StockAgentCode;	// 仕入担当者コード
            dr[StockDetailSchema.ct_Col_StockAgentName] = rst.StockAgentName;	// 仕入担当者名称
            dr[StockDetailSchema.ct_Col_GoodsKindCode] = rst.GoodsKindCode;	// 商品属性
            dr[StockDetailSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd;	// 商品メーカーコード
            dr[StockDetailSchema.ct_Col_MakerName] = rst.MakerName;	// メーカー名称
            dr[StockDetailSchema.ct_Col_MakerKanaName] = rst.MakerKanaName;	// メーカーカナ名称
            dr[StockDetailSchema.ct_Col_CmpltMakerKanaName] = rst.CmpltMakerKanaName;	// メーカーカナ名称（一式）
            dr[StockDetailSchema.ct_Col_GoodsNo] = rst.GoodsNo;	// 商品番号
            dr[StockDetailSchema.ct_Col_GoodsName] = rst.GoodsName;	// 商品名称
            dr[StockDetailSchema.ct_Col_GoodsNameKana] = rst.GoodsNameKana;	// 商品名称カナ
            dr[StockDetailSchema.ct_Col_GoodsLGroup] = rst.GoodsLGroup;	// 商品大分類コード
            dr[StockDetailSchema.ct_Col_GoodsLGroupName] = rst.GoodsLGroupName;	// 商品大分類名称
            dr[StockDetailSchema.ct_Col_GoodsMGroup] = rst.GoodsMGroup;	// 商品中分類コード
            dr[StockDetailSchema.ct_Col_GoodsMGroupName] = rst.GoodsMGroupName;	// 商品中分類名称
            dr[StockDetailSchema.ct_Col_BLGroupCode] = rst.BLGroupCode;	// BLグループコード
            dr[StockDetailSchema.ct_Col_BLGroupName] = rst.BLGroupName;	// BLグループコード名称
            dr[StockDetailSchema.ct_Col_BLGoodsCode] = rst.BLGoodsCode;	// BL商品コード
            dr[StockDetailSchema.ct_Col_BLGoodsFullName] = rst.BLGoodsFullName;	// BL商品コード名称（全角）
            dr[StockDetailSchema.ct_Col_EnterpriseGanreCode] = rst.EnterpriseGanreCode;	// 自社分類コード
            dr[StockDetailSchema.ct_Col_EnterpriseGanreName] = rst.EnterpriseGanreName;	// 自社分類名称
            dr[StockDetailSchema.ct_Col_WarehouseCode] = rst.WarehouseCode;	// 倉庫コード
            dr[StockDetailSchema.ct_Col_WarehouseName] = rst.WarehouseName;	// 倉庫名称
            dr[StockDetailSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo;	// 倉庫棚番
            dr[StockDetailSchema.ct_Col_StockOrderDivCd] = rst.StockOrderDivCd;	// 仕入在庫取寄せ区分
            dr[StockDetailSchema.ct_Col_OpenPriceDiv] = rst.OpenPriceDiv;	// オープン価格区分
            dr[StockDetailSchema.ct_Col_GoodsRateRank] = rst.GoodsRateRank;	// 商品掛率ランク
            dr[StockDetailSchema.ct_Col_CustRateGrpCode] = rst.CustRateGrpCode;	// 得意先掛率グループコード
            dr[StockDetailSchema.ct_Col_SuppRateGrpCode] = rst.SuppRateGrpCode;	// 仕入先掛率グループコード
            dr[StockDetailSchema.ct_Col_ListPriceTaxExcFl] = rst.ListPriceTaxExcFl;	// 定価（税抜，浮動）
            dr[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = rst.ListPriceTaxIncFl;	// 定価（税込，浮動）
            dr[StockDetailSchema.ct_Col_StockRate] = rst.StockRate;	// 仕入率
            dr[StockDetailSchema.ct_Col_RateSectStckUnPrc] = rst.RateSectStckUnPrc;	// 掛率設定拠点（仕入単価）
            dr[StockDetailSchema.ct_Col_RateDivStckUnPrc] = rst.RateDivStckUnPrc;	// 掛率設定区分（仕入単価）
            dr[StockDetailSchema.ct_Col_UnPrcCalcCdStckUnPrc] = rst.UnPrcCalcCdStckUnPrc;	// 単価算出区分（仕入単価）
            dr[StockDetailSchema.ct_Col_PriceCdStckUnPrc] = rst.PriceCdStckUnPrc;	// 価格区分（仕入単価）
            dr[StockDetailSchema.ct_Col_StdUnPrcStckUnPrc] = rst.StdUnPrcStckUnPrc;	// 基準単価（仕入単価）
            dr[StockDetailSchema.ct_Col_FracProcUnitStcUnPrc] = rst.FracProcUnitStcUnPrc;	// 端数処理単位（仕入単価）
            dr[StockDetailSchema.ct_Col_FracProcStckUnPrc] = rst.FracProcStckUnPrc;	// 端数処理（仕入単価）
            dr[StockDetailSchema.ct_Col_StockUnitPriceFl] = rst.StockUnitPriceFl;	// 仕入単価（税抜，浮動）
            dr[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = rst.StockUnitTaxPriceFl;	// 仕入単価（税込，浮動）
            dr[StockDetailSchema.ct_Col_StockUnitChngDiv] = rst.StockUnitChngDiv;	// 仕入単価変更区分
            dr[StockDetailSchema.ct_Col_BfStockUnitPriceFl] = rst.BfStockUnitPriceFl;	// 変更前仕入単価（浮動）
            dr[StockDetailSchema.ct_Col_BfListPrice] = rst.BfListPrice;	// 変更前定価
            dr[StockDetailSchema.ct_Col_RateBLGoodsCode] = rst.RateBLGoodsCode;	// BL商品コード（掛率）
            dr[StockDetailSchema.ct_Col_RateBLGoodsName] = rst.RateBLGoodsName;	// BL商品コード名称（掛率）
            dr[StockDetailSchema.ct_Col_RateGoodsRateGrpCd] = rst.RateGoodsRateGrpCd;	// 商品掛率グループコード（掛率）
            dr[StockDetailSchema.ct_Col_RateGoodsRateGrpNm] = rst.RateGoodsRateGrpNm;	// 商品掛率グループ名称（掛率）
            dr[StockDetailSchema.ct_Col_RateBLGroupCode] = rst.RateBLGroupCode;	// BLグループコード（掛率）
            dr[StockDetailSchema.ct_Col_RateBLGroupName] = rst.RateBLGroupName;	// BLグループ名称（掛率）
            dr[StockDetailSchema.ct_Col_StockCount] = rst.StockCount;	// 仕入数
            dr[StockDetailSchema.ct_Col_OrderCnt] = rst.OrderCnt;	// 発注数量
            dr[StockDetailSchema.ct_Col_OrderAdjustCnt] = rst.OrderAdjustCnt;	// 発注調整数
            dr[StockDetailSchema.ct_Col_OrderRemainCnt] = rst.OrderRemainCnt;	// 発注残数
            dr[StockDetailSchema.ct_Col_RemainCntUpdDate] = rst.RemainCntUpdDate;	// 残数更新日
            dr[StockDetailSchema.ct_Col_StockPriceTaxExc] = rst.StockPriceTaxExc;	// 仕入金額（税抜き）
            dr[StockDetailSchema.ct_Col_StockPriceTaxInc] = rst.StockPriceTaxInc;	// 仕入金額（税込み）
            dr[StockDetailSchema.ct_Col_StockGoodsCd] = rst.StockGoodsCd;	// 仕入商品区分
            dr[StockDetailSchema.ct_Col_StockPriceConsTax] = rst.StockPriceConsTax;	// 仕入金額消費税額
            dr[StockDetailSchema.ct_Col_TaxationCode] = rst.TaxationCode;	// 課税区分
            dr[StockDetailSchema.ct_Col_StockDtiSlipNote1] = rst.StockDtiSlipNote1;	// 仕入伝票明細備考1
            dr[StockDetailSchema.ct_Col_SalesCustomerCode] = rst.SalesCustomerCode;	// 販売先コード
            dr[StockDetailSchema.ct_Col_SalesCustomerSnm] = rst.SalesCustomerSnm;	// 販売先略称
            dr[StockDetailSchema.ct_Col_SlipMemo1] = rst.SlipMemo1;	// 伝票メモ１
            dr[StockDetailSchema.ct_Col_SlipMemo2] = rst.SlipMemo2;	// 伝票メモ２
            dr[StockDetailSchema.ct_Col_SlipMemo3] = rst.SlipMemo3;	// 伝票メモ３
            dr[StockDetailSchema.ct_Col_InsideMemo1] = rst.InsideMemo1;	// 社内メモ１
            dr[StockDetailSchema.ct_Col_InsideMemo2] = rst.InsideMemo2;	// 社内メモ２
            dr[StockDetailSchema.ct_Col_InsideMemo3] = rst.InsideMemo3;	// 社内メモ３
            dr[StockDetailSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// 仕入先コード
            dr[StockDetailSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// 仕入先略称
            dr[StockDetailSchema.ct_Col_AddresseeCode] = rst.AddresseeCode;	// 納品先コード
            dr[StockDetailSchema.ct_Col_AddresseeName] = rst.AddresseeName;	// 納品先名称
            dr[StockDetailSchema.ct_Col_DirectSendingCd] = rst.DirectSendingCd;	// 直送区分
            dr[StockDetailSchema.ct_Col_OrderNumber] = rst.OrderNumber;	// 発注番号
            dr[StockDetailSchema.ct_Col_WayToOrder] = rst.WayToOrder;	// 注文方法
            dr[StockDetailSchema.ct_Col_DeliGdsCmpltDueDate] = rst.DeliGdsCmpltDueDate;	// 納品完了予定日
            dr[StockDetailSchema.ct_Col_ExpectDeliveryDate] = rst.ExpectDeliveryDate;	// 希望納期
            dr[StockDetailSchema.ct_Col_OrderDataCreateDiv] = rst.OrderDataCreateDiv;	// 発注データ作成区分
            dr[StockDetailSchema.ct_Col_OrderDataCreateDate] = rst.OrderDataCreateDate;	// 発注データ作成日
            dr[StockDetailSchema.ct_Col_OrderFormIssuedDiv] = rst.OrderFormIssuedDiv;	// 発注書発行済区分
            dr[StockDetailSchema.ct_Col_StockCountDifference] = rst.StockCountDifference;	// 仕入差分数
            dr[StockDetailSchema.ct_Col_DtlRelationGuid] = rst.DtlRelationGuid;	// 明細関連付けGUID
        }
        # endregion

        # region 仕入明細＜DataRow → クラス＞作成
        /// <summary>
        /// 仕入明細＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <returns>仕入明細</returns>
        private StockDetailWork CreateStockDetailWorkFromSchema(DataRow dr)
        {
            StockDetailWork rst = new StockDetailWork();

            try
            {
                rst.CreateDateTime = (DateTime)dr[StockDetailSchema.ct_Col_CreateDateTime];	// 作成日時
                rst.UpdateDateTime = (DateTime)dr[StockDetailSchema.ct_Col_UpdateDateTime];	// 更新日時
                rst.EnterpriseCode = (string)dr[StockDetailSchema.ct_Col_EnterpriseCode];	// 企業コード
                rst.FileHeaderGuid = (Guid)dr[StockDetailSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[StockDetailSchema.ct_Col_UpdEmployeeCode];	// 更新従業員コード
                rst.UpdAssemblyId1 = (string)dr[StockDetailSchema.ct_Col_UpdAssemblyId1];	// 更新アセンブリID1
                rst.UpdAssemblyId2 = (string)dr[StockDetailSchema.ct_Col_UpdAssemblyId2];	// 更新アセンブリID2
                rst.LogicalDeleteCode = (Int32)dr[StockDetailSchema.ct_Col_LogicalDeleteCode];	// 論理削除区分
                rst.AcceptAnOrderNo = (Int32)dr[StockDetailSchema.ct_Col_AcceptAnOrderNo];	// 受注番号
                rst.SupplierFormal = (Int32)dr[StockDetailSchema.ct_Col_SupplierFormal];	// 仕入形式
                rst.SupplierSlipNo = (Int32)dr[StockDetailSchema.ct_Col_SupplierSlipNo];	// 仕入伝票番号
                rst.StockRowNo = (Int32)dr[StockDetailSchema.ct_Col_StockRowNo];	// 仕入行番号
                rst.SectionCode = (string)dr[StockDetailSchema.ct_Col_SectionCode];	// 拠点コード
                rst.SubSectionCode = (Int32)dr[StockDetailSchema.ct_Col_SubSectionCode];	// 部門コード
                rst.CommonSeqNo = (Int64)dr[StockDetailSchema.ct_Col_CommonSeqNo];	// 共通通番
                rst.StockSlipDtlNum = (Int64)dr[StockDetailSchema.ct_Col_StockSlipDtlNum];	// 仕入明細通番
                rst.SupplierFormalSrc = (Int32)dr[StockDetailSchema.ct_Col_SupplierFormalSrc];	// 仕入形式（元）
                rst.StockSlipDtlNumSrc = (Int64)dr[StockDetailSchema.ct_Col_StockSlipDtlNumSrc];	// 仕入明細通番（元）
                rst.AcptAnOdrStatusSync = (Int32)dr[StockDetailSchema.ct_Col_AcptAnOdrStatusSync];	// 受注ステータス（同時）
                rst.SalesSlipDtlNumSync = (Int64)dr[StockDetailSchema.ct_Col_SalesSlipDtlNumSync];	// 売上明細通番（同時）
                rst.StockSlipCdDtl = (Int32)dr[StockDetailSchema.ct_Col_StockSlipCdDtl];	// 仕入伝票区分（明細）
                rst.StockInputCode = (string)dr[StockDetailSchema.ct_Col_StockInputCode];	// 仕入入力者コード
                rst.StockInputName = (string)dr[StockDetailSchema.ct_Col_StockInputName];	// 仕入入力者名称
                rst.StockAgentCode = (string)dr[StockDetailSchema.ct_Col_StockAgentCode];	// 仕入担当者コード
                rst.StockAgentName = (string)dr[StockDetailSchema.ct_Col_StockAgentName];	// 仕入担当者名称
                rst.GoodsKindCode = (Int32)dr[StockDetailSchema.ct_Col_GoodsKindCode];	// 商品属性
                rst.GoodsMakerCd = (Int32)dr[StockDetailSchema.ct_Col_GoodsMakerCd];	// 商品メーカーコード
                rst.MakerName = (string)dr[StockDetailSchema.ct_Col_MakerName];	// メーカー名称
                rst.MakerKanaName = (string)dr[StockDetailSchema.ct_Col_MakerKanaName];	// メーカーカナ名称
                rst.CmpltMakerKanaName = (string)dr[StockDetailSchema.ct_Col_CmpltMakerKanaName];	// メーカーカナ名称（一式）
                rst.GoodsNo = (string)dr[StockDetailSchema.ct_Col_GoodsNo];	// 商品番号
                rst.GoodsName = (string)dr[StockDetailSchema.ct_Col_GoodsName];	// 商品名称
                rst.GoodsNameKana = (string)dr[StockDetailSchema.ct_Col_GoodsNameKana];	// 商品名称カナ
                rst.GoodsLGroup = (Int32)dr[StockDetailSchema.ct_Col_GoodsLGroup];	// 商品大分類コード
                rst.GoodsLGroupName = (string)dr[StockDetailSchema.ct_Col_GoodsLGroupName];	// 商品大分類名称
                rst.GoodsMGroup = (Int32)dr[StockDetailSchema.ct_Col_GoodsMGroup];	// 商品中分類コード
                rst.GoodsMGroupName = (string)dr[StockDetailSchema.ct_Col_GoodsMGroupName];	// 商品中分類名称
                rst.BLGroupCode = (Int32)dr[StockDetailSchema.ct_Col_BLGroupCode];	// BLグループコード
                rst.BLGroupName = (string)dr[StockDetailSchema.ct_Col_BLGroupName];	// BLグループコード名称
                rst.BLGoodsCode = (Int32)dr[StockDetailSchema.ct_Col_BLGoodsCode];	// BL商品コード
                rst.BLGoodsFullName = (string)dr[StockDetailSchema.ct_Col_BLGoodsFullName];	// BL商品コード名称（全角）
                rst.EnterpriseGanreCode = (Int32)dr[StockDetailSchema.ct_Col_EnterpriseGanreCode];	// 自社分類コード
                rst.EnterpriseGanreName = (string)dr[StockDetailSchema.ct_Col_EnterpriseGanreName];	// 自社分類名称
                rst.WarehouseCode = (string)dr[StockDetailSchema.ct_Col_WarehouseCode];	// 倉庫コード
                rst.WarehouseName = (string)dr[StockDetailSchema.ct_Col_WarehouseName];	// 倉庫名称
                rst.WarehouseShelfNo = (string)dr[StockDetailSchema.ct_Col_WarehouseShelfNo];	// 倉庫棚番
                rst.StockOrderDivCd = (Int32)dr[StockDetailSchema.ct_Col_StockOrderDivCd];	// 仕入在庫取寄せ区分
                rst.OpenPriceDiv = (Int32)dr[StockDetailSchema.ct_Col_OpenPriceDiv];	// オープン価格区分
                rst.GoodsRateRank = (string)dr[StockDetailSchema.ct_Col_GoodsRateRank];	// 商品掛率ランク
                rst.CustRateGrpCode = (Int32)dr[StockDetailSchema.ct_Col_CustRateGrpCode];	// 得意先掛率グループコード
                rst.SuppRateGrpCode = (Int32)dr[StockDetailSchema.ct_Col_SuppRateGrpCode];	// 仕入先掛率グループコード
                rst.ListPriceTaxExcFl = (Double)dr[StockDetailSchema.ct_Col_ListPriceTaxExcFl];	// 定価（税抜，浮動）
                rst.ListPriceTaxIncFl = (Double)dr[StockDetailSchema.ct_Col_ListPriceTaxIncFl];	// 定価（税込，浮動）
                rst.StockRate = (Double)dr[StockDetailSchema.ct_Col_StockRate];	// 仕入率
                rst.RateSectStckUnPrc = (string)dr[StockDetailSchema.ct_Col_RateSectStckUnPrc];	// 掛率設定拠点（仕入単価）
                rst.RateDivStckUnPrc = (string)dr[StockDetailSchema.ct_Col_RateDivStckUnPrc];	// 掛率設定区分（仕入単価）
                rst.UnPrcCalcCdStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_UnPrcCalcCdStckUnPrc];	// 単価算出区分（仕入単価）
                rst.PriceCdStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_PriceCdStckUnPrc];	// 価格区分（仕入単価）
                rst.StdUnPrcStckUnPrc = (Double)dr[StockDetailSchema.ct_Col_StdUnPrcStckUnPrc];	// 基準単価（仕入単価）
                rst.FracProcUnitStcUnPrc = (Double)dr[StockDetailSchema.ct_Col_FracProcUnitStcUnPrc];	// 端数処理単位（仕入単価）
                rst.FracProcStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_FracProcStckUnPrc];	// 端数処理（仕入単価）
                rst.StockUnitPriceFl = (Double)dr[StockDetailSchema.ct_Col_StockUnitPriceFl];	// 仕入単価（税抜，浮動）
                rst.StockUnitTaxPriceFl = (Double)dr[StockDetailSchema.ct_Col_StockUnitTaxPriceFl];	// 仕入単価（税込，浮動）
                rst.StockUnitChngDiv = (Int32)dr[StockDetailSchema.ct_Col_StockUnitChngDiv];	// 仕入単価変更区分
                rst.BfStockUnitPriceFl = (Double)dr[StockDetailSchema.ct_Col_BfStockUnitPriceFl];	// 変更前仕入単価（浮動）
                rst.BfListPrice = (Double)dr[StockDetailSchema.ct_Col_BfListPrice];	// 変更前定価
                rst.RateBLGoodsCode = (Int32)dr[StockDetailSchema.ct_Col_RateBLGoodsCode];	// BL商品コード（掛率）
                rst.RateBLGoodsName = (string)dr[StockDetailSchema.ct_Col_RateBLGoodsName];	// BL商品コード名称（掛率）
                rst.RateGoodsRateGrpCd = (Int32)dr[StockDetailSchema.ct_Col_RateGoodsRateGrpCd];	// 商品掛率グループコード（掛率）
                rst.RateGoodsRateGrpNm = (string)dr[StockDetailSchema.ct_Col_RateGoodsRateGrpNm];	// 商品掛率グループ名称（掛率）
                rst.RateBLGroupCode = (Int32)dr[StockDetailSchema.ct_Col_RateBLGroupCode];	// BLグループコード（掛率）
                rst.RateBLGroupName = (string)dr[StockDetailSchema.ct_Col_RateBLGroupName];	// BLグループ名称（掛率）
                rst.StockCount = (Double)dr[StockDetailSchema.ct_Col_StockCount];	// 仕入数
                rst.OrderCnt = (Double)dr[StockDetailSchema.ct_Col_OrderCnt];	// 発注数量
                rst.OrderAdjustCnt = (Double)dr[StockDetailSchema.ct_Col_OrderAdjustCnt];	// 発注調整数
                rst.OrderRemainCnt = (Double)dr[StockDetailSchema.ct_Col_OrderRemainCnt];	// 発注残数
                rst.RemainCntUpdDate = (DateTime)dr[StockDetailSchema.ct_Col_RemainCntUpdDate];	// 残数更新日
                rst.StockPriceTaxExc = (Int64)dr[StockDetailSchema.ct_Col_StockPriceTaxExc];	// 仕入金額（税抜き）
                rst.StockPriceTaxInc = (Int64)dr[StockDetailSchema.ct_Col_StockPriceTaxInc];	// 仕入金額（税込み）
                rst.StockGoodsCd = (Int32)dr[StockDetailSchema.ct_Col_StockGoodsCd];	// 仕入商品区分
                rst.StockPriceConsTax = (Int64)dr[StockDetailSchema.ct_Col_StockPriceConsTax];	// 仕入金額消費税額
                rst.TaxationCode = (Int32)dr[StockDetailSchema.ct_Col_TaxationCode];	// 課税区分
                rst.StockDtiSlipNote1 = (string)dr[StockDetailSchema.ct_Col_StockDtiSlipNote1];	// 仕入伝票明細備考1
                rst.SalesCustomerCode = (Int32)dr[StockDetailSchema.ct_Col_SalesCustomerCode];	// 販売先コード
                rst.SalesCustomerSnm = (string)dr[StockDetailSchema.ct_Col_SalesCustomerSnm];	// 販売先略称
                rst.SlipMemo1 = (string)dr[StockDetailSchema.ct_Col_SlipMemo1];	// 伝票メモ１
                rst.SlipMemo2 = (string)dr[StockDetailSchema.ct_Col_SlipMemo2];	// 伝票メモ２
                rst.SlipMemo3 = (string)dr[StockDetailSchema.ct_Col_SlipMemo3];	// 伝票メモ３
                rst.InsideMemo1 = (string)dr[StockDetailSchema.ct_Col_InsideMemo1];	// 社内メモ１
                rst.InsideMemo2 = (string)dr[StockDetailSchema.ct_Col_InsideMemo2];	// 社内メモ２
                rst.InsideMemo3 = (string)dr[StockDetailSchema.ct_Col_InsideMemo3];	// 社内メモ３
                rst.SupplierCd = (Int32)dr[StockDetailSchema.ct_Col_SupplierCd];	// 仕入先コード
                rst.SupplierSnm = (string)dr[StockDetailSchema.ct_Col_SupplierSnm];	// 仕入先略称
                rst.AddresseeCode = (Int32)dr[StockDetailSchema.ct_Col_AddresseeCode];	// 納品先コード
                rst.AddresseeName = (string)dr[StockDetailSchema.ct_Col_AddresseeName];	// 納品先名称
                rst.DirectSendingCd = (Int32)dr[StockDetailSchema.ct_Col_DirectSendingCd];	// 直送区分
                rst.OrderNumber = (string)dr[StockDetailSchema.ct_Col_OrderNumber];	// 発注番号
                rst.WayToOrder = (Int32)dr[StockDetailSchema.ct_Col_WayToOrder];	// 注文方法
                rst.DeliGdsCmpltDueDate = (DateTime)dr[StockDetailSchema.ct_Col_DeliGdsCmpltDueDate];	// 納品完了予定日
                rst.ExpectDeliveryDate = (DateTime)dr[StockDetailSchema.ct_Col_ExpectDeliveryDate];	// 希望納期
                rst.OrderDataCreateDiv = (Int32)dr[StockDetailSchema.ct_Col_OrderDataCreateDiv];	// 発注データ作成区分
                rst.OrderDataCreateDate = (DateTime)dr[StockDetailSchema.ct_Col_OrderDataCreateDate];	// 発注データ作成日
                rst.OrderFormIssuedDiv = (Int32)dr[StockDetailSchema.ct_Col_OrderFormIssuedDiv];	// 発注書発行済区分
                rst.StockCountDifference = (Double)dr[StockDetailSchema.ct_Col_StockCountDifference];	// 仕入差分数
                rst.DtlRelationGuid = (Guid)dr[StockDetailSchema.ct_Col_DtlRelationGuid];	// 明細関連付けGUID
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion

		# region ■ 画面データクラス→＜検索用＞条件抽出クラス ■
		/// <summary>
		/// 画面データクラス→＜検索用＞条件抽出クラス
		/// </summary>
		/// <param name="inpDisplay">画面データクラス</param>
        /// <remarks>
        /// <br>Update Note: 2012/11/02 田建委</br>
        /// <br>管理番号   : 10801804-00、2012/12/12配信分</br>
        /// <br>             Redmine#33224 復旧処理が自拠点のみを拾って送信する修正。</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(InpDisplay inpDisplay)
		{
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();

            para.EnterpriseCode = inpDisplay.EnterpriseCode;
            para.CashRegisterNo = inpDisplay.CashRegisterNo;
            para.SystemDivCd = inpDisplay.SystemDivCd;
            para.St_OnlineNo = inpDisplay.UOESalesOrderNoSt;
            para.Ed_OnlineNo = inpDisplay.UOESalesOrderNoEd;
            para.St_InputDay = inpDisplay.SalesDateSt;
            para.Ed_InputDay = inpDisplay.SalesDateEd;
            para.CustomerCode = inpDisplay.CustomerCode;
            para.UOESupplierCd = inpDisplay.UOESupplierCd;
            //----- ADD 2012/11/02 田建委 Redmine#33224 ---------->>>>>
            if (LoginInfoAcquisition.Employee != null)
            {
                para.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            //----- ADD 2012/11/02 田建委 Redmine#33224 ----------<<<<<

            // 送信フラグ
            int[] dataSendCodes = new int[] { 2, 3, 4 };
            para.DataSendCodes = dataSendCodes;

            return para;
		}
		# endregion

		# endregion

		# region ■ 画面データクラス→＜送受信制御用＞条件抽出クラス ■
		/// <summary>
		/// 画面データクラス→＜送受信制御用＞条件抽出クラス
		/// </summary>
		/// <param name="inpDisplay">画面データクラス</param>
		/// <returns></returns>
		private UoeSndRcvCtlPara ToUoeSndRcvCtlParaFromInpDisplay(InpDisplay inpDisplay)
		{
			UoeSndRcvCtlPara uoeSndRcvCtlPara = new UoeSndRcvCtlPara();

			uoeSndRcvCtlPara.BusinessCode = inpDisplay.BusinessCode;
			uoeSndRcvCtlPara.EnterpriseCode = inpDisplay.EmployeeCode;
			uoeSndRcvCtlPara.SystemDivCd = inpDisplay.SystemDivCd;
            uoeSndRcvCtlPara.ProcessDiv = 1;            //0：通常、1：復旧
			return uoeSndRcvCtlPara;
		}
		# endregion

        #region ■ 復旧データの取得処理
        /// <summary>
        /// 復旧データの取得処理
        /// </summary>
        /// <param name="businessCode">業務区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データリスト</param>
        /// <param name="stockDetailWorkList">仕入明細リスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        public int GetSndDatakFromRowData(int businessCode, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
		{
			// 戻値
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            message = "";
            string processDivBf = "";
            Int32 onlineNoBf = -1;

			try
			{
                //DataViewの作成
				DataView orderDataView = new DataView(this.orderDataTable);
                string viewString = "";
                //if (businessCode == ctTerminalDiv_Estm)
                //{
                //    viewString = string.Format("{0} < '1000'", this._orderDataTable.CommAssemblyIdColumn.ColumnName);
                //}
                //else
                //{
                //    viewString = "";
                //}
                viewString = "";
                orderDataView.RowFilter = viewString;

				for (int ix = 0; ix < orderDataView.Count; ix++)
				{
					StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    //同一オンライン番号の場合、処理区分が入っていない為、その時は前の値を引き継ぐ
                    if (onlineNoBf == (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName])
                    {
                        dataRow[this._orderDataTable.InpProcessDivColumn.ColumnName] = processDivBf;
                    }

                    //データ取得処理
                    Int32 onlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];
                    Int32 onlineRowNo = (Int32)dataRow[this.orderDataTable.OnlineRowNoColumn.ColumnName];
                    onlineNoBf = onlineNo;
                    processDivBf = dataRow[this.orderDataTable.InpProcessDivColumn.ColumnName].ToString();
                    //string commAssemblyId = (string)dataRow[this.orderDataTable.CommAssemblyIdColumn.ColumnName];

                    ////優良メーカーで見積処理の場合は、対象外
                    //if((businessCode == ctTerminalDiv_Estm)
                    //&& (uoeSndRcvJnlAcs.ChkCommAssemblyId(commAssemblyId) == false))
                    //{
                    //    continue;
                    //}

                    UOEOrderDtlWork uOEOrderDtlWork = null;
                    StockDetailWork stockDetailWork = null;

                    status = FindUOEOrderDtlSchema(onlineNo, onlineRowNo, out uOEOrderDtlWork, out stockDetailWork);
                    if((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    && (uOEOrderDtlWork != null)
                    && (stockDetailWork != null))
                    {
                        //UOE発注データ更新
                        UpdateUOEOrderDtlWorkFromRowData(ref uOEOrderDtlWork, dataRow);

                        uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                        stockDetailWorkList.Add(stockDetailWork);
                    }
				}
			}
			catch (Exception ex)
			{
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
				message = ex.Message;
                status = -1;
            }

			return status;
		}
		#endregion

        # region ■ 画面入力用DataTable→書き込み用クラス(UOEOrderDtlWork)
        /// <summary>
        /// 画面入力用DataTable→書き込み用クラス(UOEOrderDtlWork)
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">UOE発注データリスト</param>
        /// <param name="dataRow">データオブジェクト</param>
        private void UpdateUOEOrderDtlWorkFromRowData(ref UOEOrderDtlWork uOEOrderDtlWork, StockInputDataSet.OrderExpansionRow dataRow)
        {
            string processDiv = dataRow[this.orderDataTable.InpProcessDivColumn.ColumnName].ToString();

            if (processDiv == "1")
            {
                uOEOrderDtlWork.DataSendCode = 1;       //送信区分
                uOEOrderDtlWork.DataRecoverDiv = 0;     //復旧区分
            }
            else if (processDiv == "2")
            {
                uOEOrderDtlWork.AnswerPartsNo = (string)dataRow[this.orderDataTable.AnswerPartsNoColumn.ColumnName];                    //回答品番
                //uOEOrderDtlWork.AcceptAnOrderCnt = (double)dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName];              //数量        //DEL 2009/01/19 不具合対応[9932]
                uOEOrderDtlWork.AnswerListPrice = (double)dataRow[this.orderDataTable.AnswerListPriceColumn.ColumnName];                //定価
                uOEOrderDtlWork.AnswerSalesUnitCost = (double)dataRow[this.orderDataTable.AnswerSalesUnitCostColumn.ColumnName];        //単価
                uOEOrderDtlWork.UOESectionSlipNo = (string)dataRow[this.orderDataTable.UOESectionSlipNoColumn.ColumnName];              //伝票番号1
                uOEOrderDtlWork.UOESectOutGoodsCnt = (int)dataRow[this.orderDataTable.UOESectOutGoodsCntColumn.ColumnName];             //出荷数1
                uOEOrderDtlWork.BOSlipNo1 = (string)dataRow[this.orderDataTable.BOSlipNo1Column.ColumnName];                            //伝票番号2
                uOEOrderDtlWork.BOShipmentCnt1 = (int)dataRow[this.orderDataTable.BOShipmentCnt1Column.ColumnName];                     //出荷数2
                uOEOrderDtlWork.BOSlipNo2 = (string)dataRow[this.orderDataTable.BOSlipNo2Column.ColumnName];                            //伝票番号3
                uOEOrderDtlWork.BOShipmentCnt2 = (int)dataRow[this.orderDataTable.BOShipmentCnt2Column.ColumnName];                     //出荷数3
                uOEOrderDtlWork.BOSlipNo3 = (string)dataRow[this.orderDataTable.BOSlipNo3Column.ColumnName];                            //伝票番号4
                uOEOrderDtlWork.BOShipmentCnt3 = (int)dataRow[this.orderDataTable.BOShipmentCnt3Column.ColumnName];                     //出荷数4
                uOEOrderDtlWork.MakerFollowCnt = (int)dataRow[this.orderDataTable.MakerFollowCntColumn.ColumnName];                     //メーカーフォロー
                uOEOrderDtlWork.BOManagementNo = (string)dataRow[this.orderDataTable.BOManagementNoColumn.ColumnName];                  //EO
                uOEOrderDtlWork.EOAlwcCount = (int)dataRow[this.orderDataTable.EOAlwcCountColumn.ColumnName];                           //EO出荷数
                uOEOrderDtlWork.DataSendCode = 5;       //送信区分
                uOEOrderDtlWork.DataRecoverDiv = 9;     //復旧区分
            }
        }
   		# endregion

		# region ■ データ保存処理
		/// <summary>
		/// データ保存処理
		/// </summary>
        /// <param name="stockSectionCd">拠点コード</param>
        /// <param name="stockAddUpSectionCd">計上拠点</param>
        /// <param name="stockExpansion">在庫マスタ</param>
        /// <param name="retMessage">Message</param>
		/// <returns>STATUS</returns>
		public int WriteDB(InpDisplay inpDisplay, out string message)        
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
                //復旧データ取得処理
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;

                status = GetSndDatakFromRowData(inpDisplay.BusinessCode, out uOEOrderDtlWorkList, out stockDetailWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0) return (-1);

				//ＵＯＥ送受信制御の呼び出し
                UoeSndRcvCtlPara uoeSndRcvCtlPara = ToUoeSndRcvCtlParaFromInpDisplay(inpDisplay);

                status = _uoeSndRcvCtlAcs.UoeSndRcvCtl(
                                            uoeSndRcvCtlPara,
                                            uOEOrderDtlWorkList,
                                            stockDetailWorkList,
                                            out message);
            }
			catch (Exception ex)
			{
				message = ex.Message;
				return -1;
			}
            return status;
		}
		# endregion

        #region ＵＯＥ発注データ削除件数取得
        /// <summary>
        /// ＵＯＥ発注データ削除件数取得
        /// </summary>
        /// <returns></returns>
        public int GetDeleteCount()
        {
            int count = 0;

			try
			{
        	    DataView orderDataView = new DataView(this.orderDataTable);
				orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                count = orderDataView.Count;
            }
			catch (Exception)
			{
                count = 0;
			}
            return count;
        }
        # endregion

        #region ＵＯＥ発注データ削除処理
        /// <summary>
		/// ＵＯＥ発注データ削除処理
		/// </summary>
		/// <param name="enterpriseCode"></param>
		/// <param name="headerInfo"></param>
		/// <param name="retMessage"></param>
		/// <returns></returns>
		public int DeleteDB(out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
                // 削除対象のＵＯＥ発注データの取得
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;
                
                status = GetUOEOrderDtlWorkFromRowData(2, out uOEOrderDtlWorkList, out stockDetailWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0) return (-1);

                //ＵＯＥ発注データ削除処理
                if ((status = uOEOrderDtlAcs.Delete(uOEOrderDtlWorkList, out message)) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					return (status);
				}
            }
			catch (Exception ex)
			{
				message = ex.Message;
				return -1;
			}
			return status;
		}
		# endregion

		#region 選択データの取得処理
        /// <summary>
        /// 選択データの取得処理
        /// </summary>
        /// <param name="mode">0:全て 1:変更データ 2:選択データ</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データリスト</param>
        /// <param name="stockDetailWorkList">仕入明細リスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        public int GetUOEOrderDtlWorkFromRowData(int mode, out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, out string message)
		{
			// 戻値
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            message = "";

			try
			{
				DataView orderDataView = new DataView(this.orderDataTable);
				if (mode == 2)
				{
					orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
				}

				for (int ix = 0; ix < orderDataView.Count; ix++)
				{
					StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);
					
					//変更データのみ抽出
					if((mode == 1) && (CompareRowCache(dataRow) != false)) continue;

                    //データ取得処理
                    Int32 onlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];
                    Int32 onlineRowNo = (Int32)dataRow[this.orderDataTable.OnlineRowNoColumn.ColumnName];

                    UOEOrderDtlWork uOEOrderDtlWork = null;
                    StockDetailWork stockDetailWork = null;

                    status = FindUOEOrderDtlSchema(onlineNo, onlineRowNo, out uOEOrderDtlWork, out stockDetailWork);
                    if((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    && (uOEOrderDtlWork != null)
                    && (stockDetailWork != null))
                    {
                        uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                        stockDetailWorkList.Add(stockDetailWork);
                    }
				}
			}
			catch (Exception ex)
			{
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
				message = ex.Message;
                status = -1;
            }

			return status;
		}
		#endregion

		// ===================================================================================== //
		//  入力データ全般操作処理
		// ===================================================================================== //
		# region Input Data Control Methods
		#region データ変更フラグ
        /// <summary>データ変更フラグプロパティ（true:変更あり false:変更なし）</summary>
		public bool IsDataChanged
		{
			get
			{
				return this._isDataCanged;
			}
			set
			{
				this._isDataCanged = value;

				if (this.DataChanged != null)
				{
					this.DataChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		#region 保存データチェック処理
		/// <summary>
		/// 保存データチェック処理
		/// </summary>
        /// <param name="errorItemNameList">エラー項目名称リスト</param>
        /// <param name="errorItemList">エラー項目リスト</param>
        /// <param name="errorRow">エラー発生行情報</param>
		/// <returns>-2：数値入力エラー、-1：未入力エラー、0：正常</returns>
        /// <remarks>
        /// <br>UpdateNote  : 2010/03/08 楊明俊 処理区分の入力制御の対応</br>
        /// </remarks>
		public int SaveDataCheck(out List<string> errorItemNameList,out List<string> errorItemList, out StockInputDataSet.OrderExpansionRow errorRow)
		{
            errorItemNameList = new List<string>();
            errorItemList = new List<string>();
            errorRow = null;

            string processDivBf = "";
            int totalCnt = 0;
            int status = 0;

			foreach (StockInputDataSet.OrderExpansionRow row in this._orderDataTable)
			{
                errorRow = row;
                status = 0;
                totalCnt = 0;

                //処理区分：発注
                if (row.InpProcessDiv == "1")
                {
                    processDivBf = row.InpProcessDiv;
                    continue;
                }
                //処理区分：回答埋込
                else if (row.InpProcessDiv == "2")
                {
                    processDivBf = row.InpProcessDiv;
                }
                //処理区分：なし(同一オンライン番号のデータ)
                else if (row.InpProcessDiv == "")
                {
                    //※処理区分は同一オンライン番号内で一番最初のデータに合わせる
                    if (processDivBf == "1")
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
                // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
                int commAssemblyId = 0;
                if (row.CommAssemblyId != "")
                {
                    commAssemblyId = int.Parse(row.CommAssemblyId);
                }
                // ---UPD 2010/03/08 ---------------------------------------->>>>>
                //if (commAssemblyId == 103 || commAssemblyId == 502)
                if (IsUoeWeb(commAssemblyId))
                // ---UPD 2010/03/08 ----------------------------------------<<<<<
                {
                    //if (row.InpProcessDiv != "2" || row.InpProcessDiv != "")// DEL 2010/01/21
                    if (row.InpProcessDiv != "2" && row.InpProcessDiv != "")// ADD 2010/01/21
                    {
                        errorItemNameList.Add("処理区分");
                        errorItemList.Add(this._orderDataTable.InpProcessDivColumn.ColumnName);
                    }
                }

　　　　　　　// ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<

                // ---ADD 2009/01/26 不具合対応[10464] --------------------------------------------->>>>>
                GridColEnableStatusInfo gridColEnableStatusInfo = this.GetGridColEnableStatus(row.CommAssemblyId);
                // 拠点
                if (gridColEnableStatusInfo.UOESectionSlipNo == false)
                {
                    if (string.IsNullOrEmpty(row.InpUOESectionSlipNo) == false)
                    {
                        errorItemNameList.Add("UOE拠点伝票番号");
                        errorItemList.Add(this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName);
                    }
                    if (row.InpUOESectOutGoodsCnt != 0)
                    {
                        errorItemNameList.Add("UOE拠点出庫数");
                        errorItemList.Add(this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName);
                    }
                }
                // BO1
                if (gridColEnableStatusInfo.BOSlipNo1 == false)
                {
                    if (string.IsNullOrEmpty(row.InpBOSlipNo1) == false)
                    {
                        errorItemNameList.Add("BO伝票番号1");
                        errorItemList.Add(this._orderDataTable.InpBOSlipNo1Column.ColumnName);
                    }
                    if (row.InpBOShipmentCnt1 != 0)
                    {
                        errorItemNameList.Add("BO出庫数1");
                        errorItemList.Add(this._orderDataTable.InpBOShipmentCnt1Column.ColumnName);
                    }
                }
                // BO2
                if (gridColEnableStatusInfo.BOSlipNo2 == false)
                {
                    if (string.IsNullOrEmpty(row.InpBOSlipNo2) == false)
                    {
                        errorItemNameList.Add("BO伝票番号2");
                        errorItemList.Add(this._orderDataTable.InpBOSlipNo2Column.ColumnName);
                    }
                    if (row.InpBOShipmentCnt2 != 0)
                    {
                        errorItemNameList.Add("BO出庫数2");
                        errorItemList.Add(this._orderDataTable.InpBOShipmentCnt2Column.ColumnName);
                    }
                }
                // BO3
                if (gridColEnableStatusInfo.BOSlipNo3 == false)
                {
                    if (string.IsNullOrEmpty(row.InpBOSlipNo3) == false)
                    {
                        errorItemNameList.Add("BO伝票番号3");
                        errorItemList.Add(this._orderDataTable.InpBOSlipNo3Column.ColumnName);
                    }
                    if (row.InpBOShipmentCnt3 != 0)
                    {
                        errorItemNameList.Add("BO出庫数3");
                        errorItemList.Add(this._orderDataTable.InpBOShipmentCnt3Column.ColumnName);
                    }
                }
                // メーカーフォロー
                if (gridColEnableStatusInfo.MakerFollow == false)
                {
                    if (row.InpMakerFollowCnt != 0)
                    {
                        errorItemNameList.Add("ﾒｰｶｰﾌｫﾛｰ数");
                        errorItemList.Add(this._orderDataTable.InpMakerFollowCntColumn.ColumnName);
                    }
                }
                // BO管理番号
                if (gridColEnableStatusInfo.BOManagementNo == false)
                {
                    if (string.IsNullOrEmpty(row.InpBOManagementNo) == false)
                    {
                        errorItemNameList.Add("BO管理番号");
                        errorItemList.Add(this._orderDataTable.InpBOManagementNoColumn.ColumnName);
                    }
                    if (row.InpEOAlwcCount != 0)
                    {
                        errorItemNameList.Add("EO引当数");
                        errorItemList.Add(this._orderDataTable.InpEOAlwcCountColumn.ColumnName);
                    }
                }

                if (errorItemNameList.Count > 0)
                {
                    status = -3;        //設定不可項目入力
                    break;
                }

                // ---ADD 2009/01/26 不具合対応[10464] ---------------------------------------------<<<<<

                //回答品番
                row.AnswerPartsNo = row.InpAnswerPartsNo;               //ADD 2009/01/19 不具合対応[9934]
                if (string.IsNullOrEmpty(row.AnswerPartsNo))
                {
                    errorItemNameList.Add("回答品番");
                    errorItemList.Add(this._orderDataTable.InpAnswerPartsNoColumn.ColumnName);
                }
                /* ---DEL 2009/01/19 不具合対応[9932] --------------------------------------------->>>>>
                //数量
                if (row.AcceptAnOrderCnt == 0)
                {
                    errorItemNameList.Add("数量");
                    errorItemList.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName);
                }
                   ---DEL 2009/01/19 不具合対応[9932] ---------------------------------------------<<<<< */
                //定価
                row.AnswerListPrice = row.InpAnswerListPrice;           //ADD 2009/01/19 不具合対応[9934]
                if (row.AnswerListPrice == 0)
                {
                    errorItemNameList.Add("定価");
                    errorItemList.Add(this._orderDataTable.InpAnswerListPriceColumn.ColumnName);
                }
                //単価
                row.AnswerSalesUnitCost = row.InpAnswerSalesUnitCost;   //ADD 2009/01/19 不具合対応[9934]
                if (row.AnswerSalesUnitCost == 0)
                {
                    errorItemNameList.Add("単価");
                    errorItemList.Add(this._orderDataTable.InpAnswerSalesUnitCostColumn.ColumnName);
                }

                //UOE拠点伝票番号かUOE拠点出庫数のいずれかが入力されている場合、両方入力されているか？
                row.UOESectionSlipNo = row.InpUOESectionSlipNo;         //ADD 2009/01/19 不具合対応[9934]
                row.UOESectOutGoodsCnt = row.InpUOESectOutGoodsCnt;     //ADD 2009/01/19 不具合対応[9934]
                if ((string.IsNullOrEmpty(row.UOESectionSlipNo) == false) || (row.UOESectOutGoodsCnt != 0))
                {
                    if (string.IsNullOrEmpty(row.UOESectionSlipNo))
                    {
                        errorItemNameList.Add("UOE拠点伝票番号");
                        errorItemList.Add(this._orderDataTable.InpUOESectionSlipNoColumn.ColumnName);
                    }
                    if (row.UOESectOutGoodsCnt == 0)
                    {
                        errorItemNameList.Add("UOE拠点出庫数");
                        errorItemList.Add(this._orderDataTable.InpUOESectOutGoodsCntColumn.ColumnName);
                    }

                    totalCnt = totalCnt + row.UOESectOutGoodsCnt;
                }
                //BO伝票番号1かBO出庫数1のいずれかが入力されている場合、両方入力されているか？
                row.BOSlipNo1 = row.InpBOSlipNo1;                       //ADD 2009/01/19 不具合対応[9934]
                row.BOShipmentCnt1 = row.InpBOShipmentCnt1;             //ADD 2009/01/19 不具合対応[9934]
                if ((string.IsNullOrEmpty(row.BOSlipNo1) == false) || (row.BOShipmentCnt1 != 0))
                {
                    if (string.IsNullOrEmpty(row.BOSlipNo1))
                    {
                        errorItemNameList.Add("BO伝票番号1");
                        errorItemList.Add(this._orderDataTable.InpBOSlipNo1Column.ColumnName);
                    }
                    if (row.BOShipmentCnt1 == 0)
                    {
                        errorItemNameList.Add("BO出庫数1");
                        errorItemList.Add(this._orderDataTable.InpBOShipmentCnt1Column.ColumnName);
                    }

                    totalCnt = totalCnt + row.BOShipmentCnt1;
                }
                //BO伝票番号2かBO出庫数2のいずれかが入力されている場合、両方入力されているか？
                row.BOSlipNo2 = row.InpBOSlipNo2;                       //ADD 2009/01/19 不具合対応[9934]
                row.BOShipmentCnt2 = row.InpBOShipmentCnt2;             //ADD 2009/01/19 不具合対応[9934]
                if ((string.IsNullOrEmpty(row.BOSlipNo2) == false) || (row.BOShipmentCnt2 != 0))
                {
                    if (string.IsNullOrEmpty(row.BOSlipNo2))
                    {
                        errorItemNameList.Add("BO伝票番号2");
                        errorItemList.Add(this._orderDataTable.InpBOSlipNo2Column.ColumnName);
                    }
                    if (row.BOShipmentCnt2 == 0)
                    {
                        errorItemNameList.Add("BO出庫数2");
                        errorItemList.Add(this._orderDataTable.InpBOShipmentCnt2Column.ColumnName);
                    }

                    totalCnt = totalCnt + row.BOShipmentCnt2;
                }
                //BO伝票番号3かBO出庫数3のいずれかが入力されている場合、両方入力されているか？
                row.BOSlipNo3 = row.InpBOSlipNo3;                       //ADD 2009/01/19 不具合対応[9934]
                row.BOShipmentCnt3 = row.InpBOShipmentCnt3;             //ADD 2009/01/19 不具合対応[9934]
                if ((string.IsNullOrEmpty(row.BOSlipNo3) == false) || (row.BOShipmentCnt3 != 0))
                {
                    if (string.IsNullOrEmpty(row.BOSlipNo3))
                    {
                        errorItemNameList.Add("BO伝票番号3");
                        errorItemList.Add(this._orderDataTable.InpBOSlipNo3Column.ColumnName);
                    }
                    if (row.BOShipmentCnt3 == 0)
                    {
                        errorItemNameList.Add("BO出庫数3");
                        errorItemList.Add(this._orderDataTable.InpBOShipmentCnt3Column.ColumnName);
                    }

                    totalCnt = totalCnt + row.BOShipmentCnt3;
                }
                //メーカーフォロー数
                row.MakerFollowCnt = row.InpMakerFollowCnt;             //ADD 2009/01/19 不具合対応[9934]
                if (row.MakerFollowCnt != 0)
                {
                    totalCnt = totalCnt + row.MakerFollowCnt;
                }
                //BO管理番号かEO引当数のいずれかが入力されている場合、両方入力されているか？
                row.BOManagementNo = row.InpBOManagementNo;             //ADD 2009/01/19 不具合対応[9934]
                row.EOAlwcCount = row.InpEOAlwcCount;                   //ADD 2009/01/19 不具合対応[9934]
                if ((string.IsNullOrEmpty(row.BOManagementNo) == false) || (row.EOAlwcCount != 0))
                {
                    if (string.IsNullOrEmpty(row.BOManagementNo))
                    {
                        errorItemNameList.Add("BO管理番号");
                        errorItemList.Add(this._orderDataTable.InpBOManagementNoColumn.ColumnName);
                    }
                    if (row.EOAlwcCount == 0)
                    {
                        errorItemNameList.Add("EO引当数");
                        errorItemList.Add(this._orderDataTable.InpEOAlwcCountColumn.ColumnName);
                    }

                    totalCnt = totalCnt + row.EOAlwcCount;
                }

                if (errorItemNameList.Count > 0)
                {
                    status = -1;        //未入力
                    break;
                }

                //入力値合計チェック
                if (totalCnt > row.AcceptAnOrderCnt)
                {
                    errorItemList.Add(this._orderDataTable.InpAcceptAnOrderCntColumn.ColumnName);
                    status = -2;
                    break;
                }
			}
            if (status == 0)
			{
                errorRow = null;
			}
            return status;
        }
		#endregion
		# endregion

		// ===================================================================================== //
		// 仕入明細データ操作処理
		// ===================================================================================== //
		# region OrderExpansion Control Methods

		# region 明細データテーブル行初期設定処理
		/// <summary>
		/// 明細データテーブル行初期設定処理
		/// </summary>
		public void OrderRowInitialSetting(int defaultRowCount)
		{
			this._orderDataTable.BeginLoadData();
			this._orderDataTable.Rows.Clear();

			for (int i = 1; i <= defaultRowCount; i++)
			{
				StockInputDataSet.OrderExpansionRow row = this._orderDataTable.NewOrderExpansionRow();
				row.OrderNo = i;
				row.OrderNoDisplay = i;

				this._orderDataTable.AddOrderExpansionRow(row);
			}

			this._orderDataTable.EndLoadData();
		}
		# endregion

		/// <summary>
		/// 仕入明細データテーブルクリエイト処理
		/// </summary>
		/// <param name="stockExpansion">仕入データクラス</param>
		/// <param name="productStockList">仕入明細データクラスリスト</param>
		/// <param name="stockExplaDataList">仕入詳細データクラスリスト</param>
		//private StockInputDataSet.OrderExpansionDataTable CreateStockDetailDataTable(OrderExpansion stockExpansion, List<OrderExpansion> productStockList)
		private StockInputDataSet.OrderExpansionDataTable CreateStockDetailDataTable()
		{
			StockInputDataSet.OrderExpansionDataTable stockDataTable = new StockInputDataSet.OrderExpansionDataTable();
			return stockDataTable;
		}

		/// <summary>
        /// 有効入力行存在判定
        /// </summary>
        /// <returns>行存在チェック結果（True : 行あり / False : 行なし）</returns>
        public bool StockRowExists()
        {
            if ( this._orderDataTable.Rows.Count > 0 )
			{
                return true;
            }
            else
			{
                return false;
            }
        }

		/// <summary>
		/// 仕入明細データテーブルStockRowNo列初期化処理
		/// </summary>
		public void InitializeProductStockStockRowNoColumn()
		{
			this._orderDataTable.BeginLoadData();
			for (int i = 0; i < this._orderDataTable.Rows.Count; i++)
			{
				this._orderDataTable[i].OrderNo = i + 1;
				this._orderDataTable[i].OrderNoDisplay = i + 1;
			}
			this._orderDataTable.EndLoadData();
		}

		/// <summary>
		/// 明細データテーブルRowStatus列初期化処理
		/// </summary>
		public void InitializeProductStockRowStatusColumn()
		{
			StockInputDataSet.OrderExpansionRow[] rows = (StockInputDataSet.OrderExpansionRow[])this._orderDataTable.Select(this._orderDataTable.RowStatusColumn.ColumnName + " <> " + ROWSTATUS_NORMAL.ToString());

			this._orderDataTable.BeginLoadData();
			foreach (StockInputDataSet.OrderExpansionRow row in rows)
			{
				row.RowStatus = ROWSTATUS_NORMAL;
			}
			this._orderDataTable.EndLoadData();
		}

		/// <summary>
		/// 明細データテーブルRowStatus列値設定処理
		/// </summary>
		/// <param name="stockRowNoList">仕入明細行番号リスト</param>
		/// <param name="rowStatus">RowStatus値</param>
		public void SetProductStockRowStatusColumn(List<int> stockRowNoList, int rowStatus)
		{
			this._orderDataTable.BeginLoadData();
			foreach (int OrderNo in stockRowNoList)
			{
				StockInputDataSet.OrderExpansionRow row = this._orderDataTable.FindByOrderNo(OrderNo);
				if (row.GoodsName == "") continue;

				row.RowStatus = rowStatus;
			}
			this._orderDataTable.EndLoadData();
		}
/*
		/// <summary>
		/// コピー仕入明細行存在チェック処理
		/// </summary>
		/// <returns>true:コピーデータが存在する false:存在しない</returns>
		public bool ExistCopyProductStockRow()
		{
			object value = this._orderDataTable.Compute("COUNT(" + this._orderDataTable.RowStatusColumn.ColumnName + ")", this._orderDataTable.RowStatusColumn.ColumnName + " <> " + ROWSTATUS_NORMAL.ToString());
			if (value is System.DBNull) return false;

			int count = (int)value;

			if (count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// コピー仕入明細行番号取得処理
		/// </summary>
		/// <returns>行番号リスト</returns>
		public List<int> GetCopyProductStockRowNo()
		{
			StockInputDataSet.OrderExpansionRow[] rows = (StockInputDataSet.OrderExpansionRow[])this._orderDataTable.Select(this._orderDataTable.RowStatusColumn.ColumnName + " <> " + ROWSTATUS_NORMAL.ToString());

			if ((rows != null) && (rows.Length > 0))
			{
				List<int> stockRowNoList = new List<int>();
				foreach (StockInputDataSet.OrderExpansionRow row in rows)
				{
					stockRowNoList.Add(row.OrderNo);
				}

				return stockRowNoList;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 仕入明細行削除処理
		/// </summary>
		/// <param name="stockRowNoList">削除行StockRowNoリスト</param>
		public void DeleteProductStockRow(List<int> stockRowNoList)
		{
			this.DeleteProductStockRow(stockRowNoList, true, false);
		}

		/// <summary>
		/// ＵＯＥ復旧処理明細行削除処理
		/// </summary>
		/// <param name="stockRowNoList">削除行StockRowNoリスト</param>
		/// <param name="deleteStockExplaData">true:仕入詳細データを削除する false:仕入詳細データを削除しない</param>
		/// <param name="isRowCountChange">true:行数を変更する false:行数を変更するは変更しない</param>
		public void DeleteProductStockRow(List<int> stockRowNoList, bool deleteStockExplaData, bool changeRowCount)
		{
			this._orderDataTable.BeginLoadData();
			foreach (int stockRowNo in stockRowNoList)
			{
				StockInputDataSet.OrderExpansionRow targetRow = this._orderDataTable.FindByOrderNo(stockRowNo);
				if (targetRow == null) continue;

				this._orderDataTable.RemoveOrderExpansionRow(targetRow);
			}

			// 仕入明細データテーブルStockRowNo列初期化処理
			this.InitializeProductStockStockRowNoColumn();
			this._orderDataTable.EndLoadData();
		}
*/
        /// <summary>
        /// 在庫行追加処理
        /// </summary>
        public void AddStockRow ()
        {
            int rowCount = this._orderDataTable.Rows.Count;

            StockInputDataSet.OrderExpansionRow row = this._orderDataTable.NewOrderExpansionRow();
            row.OrderNo = rowCount + 1;
            row.OrderNoDisplay = rowCount + 1;
            this._orderDataTable.AddOrderExpansionRow(row);
        }

		# region 表示用行番号調整処理
		/// <summary>
		/// 表示用行番号調整処理
		/// </summary>
		public void AdjustRowNo()
		{
			int no = 1;
			foreach (StockInputDataSet.OrderExpansionRow row in this._orderDataTable)
			{
				if (row != null)
				{
					row.OrderNo = no;
					row.OrderNoDisplay = no;
					no++;
				}
			}
		}
		# endregion

		/// <summary>
		/// 仕入明細行集約処理
		/// </summary>
		/// <param name="stockRowNo">集約基準仕入行番号</param>
		public void ConcentrateProductStockRow(int stockRowNo)
		{
            StockInputDataSet.OrderExpansionRow sourceRow = this._orderDataTable.FindByOrderNo(stockRowNo);
			List<int> deleteStockRowNoList = new List<int>();


			// 仕入明細データテーブルStockRowNo列初期化処理
			this.InitializeProductStockStockRowNoColumn();

			// 仕入詳細データDataTable明細圧縮処理
			deleteStockRowNoList.Add(stockRowNo);

		}

		/// <summary>
		/// マスタテーブルSelect処理
		/// </summary>
		/// <param name="filterExpression">フィルタをかけるための基準</param>
		/// <param name="stockDataTable">在庫マスタテーブル</param>
		/// <returns>在庫列配列</returns>
		private StockInputDataSet.OrderExpansionRow[] SelectStockRows(string filterExpression, StockInputDataSet.OrderExpansionDataTable stockDataTable)
		{
			StockInputDataSet.OrderExpansionRow[] productStockRowArray = null;

			try
			{
				DataRow[] rowArray = stockDataTable.Select(filterExpression);

				if (rowArray != null)
				{
					productStockRowArray = (StockInputDataSet.OrderExpansionRow[])rowArray;
				}
			}
			catch { }

			return productStockRowArray;
		}

		/// <summary>
		/// 行クリア処理
		/// </summary>
		/// <param name="stockRowNoList">製番GUID</param>
		public void ClearStockRow(List<int> stockRowNoList)
		{
			foreach (int stockRowNo in stockRowNoList)
			{
				// 製造番号行クリア処理
				this.ClearStockRow(stockRowNo);
			}
		}

		/// <summary>
		/// 明細行クリア処理
		/// </summary>
		/// <param name="stockRowNo">行番号</param>
		public void ClearStockRow(int stockRowNo)
		{
			StockInputDataSet.OrderExpansionRow row = this._orderDataTable.FindByOrderNo(stockRowNo);

			if (row != null)
			{
				this.ClearStockRow(row);
			}
		}

		/// <summary>
		/// 行クリア処理
		/// </summary>
		/// <param name="row">仕入明細データテーブル行クラス</param>
		private void ClearStockRow(StockInputDataSet.OrderExpansionRow row)
		{
			if (row == null) return;

            row.UOESupplierCd = 0;
            row.UOESupplierName = "";
            row.CommAssemblyId = "";
            row.OnlineNo = 0;
            row.OnlineRowNo = 0;
            row.DataSendCode = 0;
            row.DataSendErrMsg = "";
            row.CashRegisterNo = 0;
            row.CashRegisterNo2 = 0;
            row.InputDay = DateTime.MinValue;
            row.CustomerCode = 0;
            row.CustomerSnm = "";
            row.GoodsNo = "";
            row.GoodsName = "";
            row.GoodsMakerCd = 0;
            row.MakerName = "";
            row.AnswerPartsNo = "";
            row.AcceptAnOrderCnt = 0;
            row.AnswerListPrice = 0;
            row.AnswerSalesUnitCost = 0;
            row.UOESectionSlipNo = "";
            row.UOESectOutGoodsCnt = 0;
            row.BOSlipNo1 = "";
            row.BOShipmentCnt1 = 0;
            row.BOSlipNo2 = "";
            row.BOShipmentCnt2 = 0;
            row.BOSlipNo3 = "";
            row.BOShipmentCnt3 = 0;
            row.MakerFollowCnt = 0;
            row.BOManagementNo = "";
            row.EOAlwcCount = 0;
            row.SupplierCd = 0;
            row.SupplierSnm = "";
            row.UoeRemark1 = "";
            row.UoeRemark2 = "";
            row.UOEDeliGoodsDiv = "";
            row.DeliveredGoodsDivNm = "";
            row.FollowDeliGoodsDiv = "";
            row.FollowDeliGoodsDivNm = "";
            row.UOEResvdSection = "";
            row.UOEResvdSectionNm = "";
            row.EmployeeCode = "";
            row.EmployeeName = "";
            row.InpSelect = false;          //InpSelect
            row.InpProcessDiv = "";         //InpProcessDiv
            row.AnswerPartsNo = "";         //InpAnswerPartsNo
            row.AcceptAnOrderCnt = 0;	    //InpAcceptAnOrderCnt
            row.AnswerListPrice = 0;        //InpAnswerListPrice
            row.AnswerSalesUnitCost = 0;    //InpAnswerSalesUnitCost
            row.UOESectionSlipNo = "";      //InpUOESectionSlipNo
            row.UOESectOutGoodsCnt = 0;     //InpSectOutGoodsCnt
            row.BOSlipNo1 = "";             //InpBOSlipNo1
            row.BOShipmentCnt1 = 0;         //InpBOShipmentCnt1
            row.BOSlipNo2 = "";             //InpBOSlipNo2
            row.BOShipmentCnt2 = 0;         //InpBOShipmentCnt2
            row.BOSlipNo3 = "";             //InpBOSlipNo3
            row.BOShipmentCnt3 = 0;         //InpBOShipmentCnt3
            row.MakerFollowCnt = 0;         //InpMakerFollowCnt
            row.BOManagementNo = "";        //InpBOManagementNo
            row.EOAlwcCount = 0;            //InpEOAlwcCount
		}

		/// <summary>
		/// 明細行クラス複製処理
		/// </summary>
		/// <param name="row">在庫明細行クラス</param>
		/// <returns>複製後在庫明細行クラス</returns>
		private StockInputDataSet.OrderExpansionRow CloneStockRow(StockInputDataSet.OrderExpansionRow sourceRow)
		{
			StockInputDataSet.OrderExpansionRow targetRow = sourceRow;
			return targetRow;
		}


		#region 選択・非選択状態処理
		/// <summary>
		/// 選択・非選択状態処理
		/// </summary>
		/// <param name="_uniqueID">ユニークID</param>
		/// <remarks>
		/// <br>Note       : 抽出データを初期化します。</br>
		/// <br>Programer  : 980023  飯谷 耕平</br>
		/// <br>Date       : 2007.07.09</br>
		/// </remarks>
		public void SelectedRow(int _uniqueID)
		{
			// ------------------------------------------------------------//
			// Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
			// DataTableに更新をかける。                                   //
			// ------------------------------------------------------------//
			DataRow _row = this.orderDataTable.Rows.Find(_uniqueID);

			// 一致する行が存在する！
			if (_row != null)
			{
				bool selectDisplay = (bool)_row[this.orderDataTable.InpSelectColumn.ColumnName];

				_row.BeginEdit();
				_row[this.orderDataTable.InpSelectColumn.ColumnName] = !selectDisplay;
				_row.EndEdit();

			}
		}
		# endregion

		#region 選択・非選択状態処理(指定型)
		/// <summary>
		/// 選択・非選択状態処理(指定型)
		/// </summary>
		/// <param name="_uniqueID">ユニークID</param>
		/// <param name="selected">true:選択,false:非選択</param>
		/// <remarks>
		/// <br>Note       : 抽出データを初期化します。</br>
		/// <br>Programer  : 980023  飯谷 耕平</br>
		/// <br>Date       : 2007.07.09</br>
		/// </remarks>
		public void SelectedRow(int _uniqueID, bool selected)
		{
			// ------------------------------------------------------------//
			// Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
			// DataTableに更新をかける。                                   //
			// ------------------------------------------------------------//
			DataRow _row = this.orderDataTable.Rows.Find(_uniqueID);

			// 一致する行が存在する！
			if (_row != null)
			{
				_row.BeginEdit();
				_row[this.orderDataTable.InpSelectColumn.ColumnName] = selected;
				_row.EndEdit();
			}
		}
		# endregion
/*
        #region ヘッダー部入力値の保存処理
        /// <summary>
        /// ヘッダー部入力値の保存処理
        /// </summary>
        /// <param name="inpHedDisplay"> ヘッダー部入力クラス</param>
        /// <param name="sw">0:全て 1:リマーク１＆２ 2:納品区分＆Ｈ納品区分＆指定拠点</param>
        public void UpdtHedaerItem(InpHedDisplay inpHedDisplay, int sw)
        {
            DataView orderDataView = new DataView(this.orderDataTable);

            string rowFilterString = "";

            switch(sw)
            {
                //オンライン番号・オンライン行番号
                case 0:
                    rowFilterString = String.Format("{0} = {1} AND {2} = {3}",
                                                    this.orderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo,
                                                    this.orderDataTable.OnlineRowNoColumn.ColumnName, inpHedDisplay.OnlineRowNo
                                                    );
                    break;
                //オンライン番号
                case 1:
                    rowFilterString = String.Format("{0} = {1}",
                                                    this.orderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);
                    break;
                //オンライン番号・発注番号
                case 2:
                    rowFilterString = String.Format("{0} = {1} AND {2} = {3}",
                                                    this.orderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo,
                                                    this.orderDataTable.UOESupplierCdColumn.ColumnName, inpHedDisplay.UOESupplierCd
                                                    );
                    break;
                default:
                    rowFilterString = "";
                    break;
            }
            orderDataView.RowFilter = rowFilterString;


            //ＵＯＥ発注先の取得
            UOESupplier uOESupplier = this._stockInputInitDataAcs.GetUOESupplier(inpHedDisplay.UOESupplierCd);
            if (uOESupplier == null) return;

            //仕入先の取得
            Supplier supplier = _stockInputInitDataAcs.GetSupplier(uOESupplier.SupplierCd);
            string supplierSnm = "";
            if (supplier != null)
            {
                supplierSnm = supplier.SupplierSnm;
            }

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                StockInputDataSet.OrderExpansionRow dataRow = (StockInputDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                switch (sw)
                {
                    //オンライン番号・オンライン行番号
                    case 0:
                        dataRow[this.orderDataTable.UOESupplierCdColumn.ColumnName] = inpHedDisplay.UOESupplierCd;              // UOE発注先コード
                        dataRow[this.orderDataTable.UOESupplierNameColumn.ColumnName] = inpHedDisplay.UOESupplierName;          // UOE発注先名称
                        dataRow[this.orderDataTable.CommAssemblyIdColumn.ColumnName] = uOESupplier.CommAssemblyId;              // 通信アセンブリID

                        dataRow[this.orderDataTable.UOEResvdSectionColumn.ColumnName] = inpHedDisplay.UOEResvdSection;          // UOE指定拠点
                        dataRow[this.orderDataTable.UOEResvdSectionNmColumn.ColumnName] = inpHedDisplay.UOEResvdSectionNm;      // UOE指定拠点名称
                        dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName] = inpHedDisplay.EmployeeCode;                // 従業員コード
                        dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName] = inpHedDisplay.EmployeeName;                // 従業員名称

                        dataRow[this.orderDataTable.UOEDeliGoodsDivColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;          // UOE納品区分
                        dataRow[this.orderDataTable.DeliveredGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;  // 納品区分名称
                        dataRow[this.orderDataTable.FollowDeliGoodsDivColumn.ColumnName] = inpHedDisplay.FollowDeliGoodsDiv;    // フォロー納品区分
                        dataRow[this.orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.FollowDeliGoodsDivNm;// フォロー納品区分名称

                        dataRow[this.orderDataTable.SupplierCdColumn.ColumnName] = uOESupplier.SupplierCd;                      // 仕入先コード
                        dataRow[this.orderDataTable.SupplierSnmColumn.ColumnName] = supplierSnm;                                // 仕入先略称
                        
                        dataRow[this.orderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // ＵＯＥリマーク１
                        dataRow[this.orderDataTable.UoeRemark2Column.ColumnName] = inpHedDisplay.UoeRemark2;                    // ＵＯＥリマーク２
                        break;

                    //オンライン番号
                    case 1:
                        dataRow[this.orderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // ＵＯＥリマーク１
                        dataRow[this.orderDataTable.UoeRemark2Column.ColumnName] = inpHedDisplay.UoeRemark2;                    // ＵＯＥリマーク２
                        break;
                    //オンライン番号・発注番号
                    case 2:
                        dataRow[this.orderDataTable.UOEDeliGoodsDivColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;          // UOE納品区分
                        dataRow[this.orderDataTable.DeliveredGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;  // 納品区分名称
                        dataRow[this.orderDataTable.FollowDeliGoodsDivColumn.ColumnName] = inpHedDisplay.FollowDeliGoodsDiv;    // フォロー納品区分
                        dataRow[this.orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.FollowDeliGoodsDivNm;// フォロー納品区分名称
                        dataRow[this.orderDataTable.UOEResvdSectionColumn.ColumnName] = inpHedDisplay.UOEResvdSection;          // UOE指定拠点
                        dataRow[this.orderDataTable.UOEResvdSectionNmColumn.ColumnName] = inpHedDisplay.UOEResvdSectionNm;      // UOE指定拠点名称
                        break;
                    default:
                        rowFilterString = "";
                        break;
                }


            }
        }
		# endregion
*/
		# endregion

        // ---ADD 2009/01/26 不具合対応[10464] -------------------------------------------------------->>>>>
        // ===================================================================================== //
        // グリッド列使用/未使用判定関連
        // ===================================================================================== //
        # region
        /// <summary>
        ///
        /// グリッド列使用/未使用判定HashTableデータ追加
        /// </summary>
        /// <param name="key">通信アセンブリID　※int型</param>
        /// <param name="status1">UOE拠点伝票番号ステータス(True：使用、False：未使用)</param>
        /// <param name="status2">BO伝票番号1ステータス(True：使用、False：未使用)</param>
        /// <param name="status3">BO伝票番号2ステータス(True：使用、False：未使用)</param>
        /// <param name="status4">BO伝票番号3ステータス(True：使用、False：未使用)</param>
        /// <param name="status5">メーカーフォローステータス(True：使用、False：未使用)</param>
        /// <param name="status6">BO管理番号ステータス(True：使用、False：未使用)</param>
        private void AddGridColEnableStatusHTable(int key, bool status1, bool status2, bool status3, bool status4, bool status5, bool status6)
        {
            if (this._gridColEnableStatusHTable == null)
            {
                this._gridColEnableStatusHTable = new Hashtable();
            }

            GridColEnableStatusInfo gridColEnableStatusInfo = new GridColEnableStatusInfo();
            gridColEnableStatusInfo.Add(status1, status2, status3, status4, status5, status6);

            // HashTableに追加(key：通信アセンブリID ※int型)
            this._gridColEnableStatusHTable[key] = gridColEnableStatusInfo;
        }

        /// <summary>
        /// グリッド列使用/未使用ステータス取得
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns></returns>
        private GridColEnableStatusInfo GetGridColEnableStatus(string commAssemblyId)
        {
            // int型に変換不可のものは全て0とする
            int key = 0;
            int.TryParse(commAssemblyId, out key);

            // 変換可でも、keyでないものは全て0とする
            if (this._gridColEnableStatusHTable.ContainsKey(key) == false)
            {
                key = 0;
            }

            return (GridColEnableStatusInfo)this._gridColEnableStatusHTable[key];
        }
        #endregion
        // ---ADD 2009/01/26 不具合対応[10464] --------------------------------------------------------<<<<<

        // ===================================================================================== //
		// その他
		// ===================================================================================== //
		# region Other Methods

	    /// <summary>
		/// ログ出力(DEBUG)処理
		/// </summary>
		/// <param name="pMsg">メッセージ</param>
		public static void WriteLog(string pMsg)
		{
			#if DEBUG
			System.IO.FileStream _fs;										// ファイルストリーム
			System.IO.StreamWriter _sw;										// ストリームwriter
			_fs = new System.IO.FileStream("MAZAI04400U.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
			if (_sw != null)
				_sw.Close();
			if (_fs != null)
				_fs.Close();
			#endif
		}
		# endregion

		# region ArrayList値チェック
		/// <summary>
		/// ArrayList値チェック
		/// </summary>
		/// <param name="ary">ArrayList</param>
		/// <returns>true:正常 false:ｴﾗｰ</returns>
		private bool AryChk(ArrayList ary)
		{
			bool status = true;
			if (ary == null)
			{
				status = false;
			}
			else
			{
				if(ary.Count == 0)
				{
					status = false;
				}
			}
			return (status);
		}
		# endregion
        // ---ADD 2010/03/08 ---------------------------------------->>>>>
        # region 通信アセンブリIDがUOE(web)の判断
        /// <summary>
        /// 通信アセンブリIDがUOE(web)の判断
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>
        /// <c>true</c>:UOE(web)です。</br>
        /// <c>false</c>:UOE(web)ではありません。</br>
        /// </returns>
        /// <see cref="UoeSndRcvCtlAcs"/>
        /// <remarks>
        /// <br>Note		: 通信アセンブリIDがUOE(web)であるか判断します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        public static bool IsUoeWeb(int commAssemblyId)
        {
            if (commAssemblyId < 0) return false;

            //
            return UoeSndRcvCtlAcs.IsUoeWeb(commAssemblyId.ToString("0000"));
        }
        # endregion

        # region 通信アセンブリIDが回答埋込の判断
        /// <summary>
        /// 通信アセンブリIDが回答埋込の判断
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>
        /// 通信アセンブリIDが以下の場合、回答埋込となります。
        /// ①トヨタ電子カタログ：通信アセンブリID == "0103"
        /// ②日産web-UOE：通信アセンブリID == "0203"
        /// </returns>
        /// <remarks>
        /// <br>Note		: 通信アセンブリIDが回答埋込のみであるか判断します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/03/08</br>
        /// <br>Update Note : 2010/12/31 曹文傑</br>
        /// <br>              UOE自動化改良</br>
        /// <br>Update Note : 2011/01/30 朱 猛</br>
        /// <br>              UOE自動化改良</br>
        /// <br>UpdateNote  : 2011/03/01 liyp </br>
        /// <br>              日産UOE自動化B対応</br>
        /// <br>UpdateNote  : 2011/05/10 施炳中 </br>
        /// <br>              回答埋込のみとなる判断するメソッドにマツダWebUOEを追加</br>
        /// </remarks>
        public static bool IsWritingAnswerOnly(String commAssemblyId)
        {
            if (String.IsNullOrEmpty(commAssemblyId)) return false;

            //送受信制御の定数を使用
            switch (commAssemblyId)
            {
                case EnumUoeConst.ctCommAssemblyId_0103:
                    return true; // トヨタ電子カタログ
                case EnumUoeConst.ctCommAssemblyId_0203:
                    return true; // 日産web-UOE
                // ------------- ADD 2010/04/26 gaoyh -------------------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0302:
                    return true; // 三菱web-UOE
                // ------------- ADD 2010/04/26 gaoyh --------------------------<<<<<
                // ------------- ADD 2010/12/31 ------------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0204:
                    return true; // 日産web-UOE(自動)
                case EnumUoeConst.ctCommAssemblyId_0303:
                    return true; // 三菱web-UOE(自動)
                // ------------- ADD 2010/12/31 -------------------<<<<<
                // ------------- ADD 2011/01/30 ------------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0104:
                    return true; // トヨタ自動処理
                // ------------- ADD 2011/01/30 -------------------<<<<<
                // ---ADD 2011/03/01-------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0205:
                    return true;
                case EnumUoeConst.ctCommAssemblyId_0206:
                    return true;
                // ---ADD 2011/03/01--------------<<<<<
                // ---ADD 2011/05/10-------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0403:
                    return true;
                // ---ADD 2011/05/10--------------<<<<<
                default:
                    return false;
            }
        }
        # endregion
        // ---ADD 2010/03/08 ----------------------------------------<<<<<
    }
}
