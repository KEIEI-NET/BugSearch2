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
	/// ＵＯＥ手入力発注アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ手入力発注の制御全般を行います。</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.12</br>
	/// <br></br>
    /// <br>Update Note  : 2009.05.25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// <br>Update Note  : K2012/06/20 30517 夏野 駿希</br>
    /// <br>              ・10802197-00 山形部品個別対応</br>
    /// <br>              　常に非在庫品として処理が行われる様に修正する。</br>
    /// <br>Update Note: 2012/08/30 袁磊</br>
    /// <br>管理番号   : 10801804-00 2012/09/12配信分</br>
    /// <br>             Redmine#31884 手入力発注処理修正の対応</br>
    /// <br>Update Note  : K2012/12/11 FSI佐々木 貴英</br>
    /// <br>              ・10802197-01 山形部品個別対応</br>
    /// <br>              　山形部品完全個別オプション判定追加</br>
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
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;
        private UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs = null;

        // 2009.05.25 START >>>>>>
        private UoeOrderInfoAcs _uoeOrderInfoAcs = null;
        // 2009.05.25 END   <<<<<<

		//データーテーブル
		private StockInputDataSet _dataSet;
		private StockInputDataSet.OrderExpansionDataTable _orderDataTable;
		private StockInputDataSet.OrderExpansionDataTable _orderExpansionCache;
		
		//リモートオブジェクト

		//変数
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _loginSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
        private string _employeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
        private string _employeeName = LoginInfoAcquisition.Employee.Name;

		private bool _isDataCanged = false;
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
		/// <summary>
		/// 発注検索データセット取得処理
		/// </summary>
		/// <returns>伝票検索データセット</returns>
		public StockInputDataSet DataSet
		{
			get { return this._dataSet; }
		}

		/// <summary>
		/// 発注検索データテーブル取得処理
		/// </summary>
		/// <returns>伝票検索データセット</returns>
		public StockInputDataSet.OrderExpansionDataTable orderDataTable
		{
			get { return _orderDataTable; }
		}

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
            this._stockInputInitDataAcs = StockInputInitDataAcs.GetInstance();
			this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
			this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
            this._uoeSndRcvCtlInitAcs = UoeSndRcvCtlInitAcs.GetInstance();

            // 2009.05.25 START >>>>>>
            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();
            // 2009.05.25 END   <<<<<<
			ClearOrderFormListResultTbl();
        }

        /// <summary>
        /// ＵＯＥ手入力発注アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>ＵＯＥ手入力発注アクセスクラス インスタンス</returns>
        public static StockInputAcs GetInstance ()
        {
            if ( _stockInputAcs == null ) {
                _stockInputAcs = new StockInputAcs();
            }

            return _stockInputAcs;
        }

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
			OrderExpansionCache = (StockInputDataSet.OrderExpansionDataTable)this.orderDataTable.Copy();
		}

		/// <summary>
		/// データセットクリア処理
		/// </summary>
		private void ClearOrderFormListResultTbl()
		{
			this.orderDataTable.Rows.Clear();

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

            if ((targetRow.InpGoodsNo != sourceRow.InpGoodsNo)
            || (targetRow.InpGoodsNoGuideButton != sourceRow.InpGoodsNoGuideButton)
            || (targetRow.InpAcceptAnOrderCnt != sourceRow.InpAcceptAnOrderCnt)
            || (targetRow.InpBoCode != sourceRow.InpBoCode)
            || (targetRow.InpGoodsMakerCd != sourceRow.InpGoodsMakerCd)
            || (targetRow.InpBLGoodsCode != sourceRow.InpBLGoodsCode)
            || (targetRow.InpBLGoodsName != sourceRow.InpBLGoodsName)
            || (targetRow.InpMakerName != sourceRow.InpMakerName)
            || (targetRow.DspBLGoodsName != sourceRow.DspBLGoodsName)
            || (targetRow.DspStockCnt != sourceRow.DspStockCnt)
            || (targetRow.DspWarehouseName != sourceRow.DspWarehouseName)
            || (targetRow.DspWarehouseShelfNo != sourceRow.DspWarehouseShelfNo)
            || (targetRow.WarehouseCode != sourceRow.WarehouseCode)
            || (targetRow.WarehouseName != sourceRow.WarehouseName)
            || (targetRow.WarehouseShelfNo != sourceRow.WarehouseShelfNo)
            || (targetRow.BoCode != sourceRow.BoCode)
            || (targetRow.GoodsMakerCd != sourceRow.GoodsMakerCd)
            || (targetRow.MakerName != sourceRow.MakerName)
            || (targetRow.GoodsNo != sourceRow.GoodsNo)
            || (targetRow.GoodsNoNoneHyphen != sourceRow.GoodsNoNoneHyphen)
            || (targetRow.GoodsName != sourceRow.GoodsName)
            || (targetRow.AcceptAnOrderCnt != sourceRow.AcceptAnOrderCnt)
            || (targetRow.UoeRemark1 != sourceRow.UoeRemark1)
            || (targetRow.UoeRemark2 != sourceRow.UoeRemark2)
            || (targetRow.GoodsKindCode != sourceRow.GoodsKindCode)
            || (targetRow.MakerKanaName != sourceRow.MakerKanaName)
            || (targetRow.GoodsNameKana != sourceRow.GoodsNameKana)
            || (targetRow.GoodsLGroup != sourceRow.GoodsLGroup)
            || (targetRow.GoodsLGroupName != sourceRow.GoodsLGroupName)
            || (targetRow.GoodsMGroup != sourceRow.GoodsMGroup)
            || (targetRow.GoodsMGroupName != sourceRow.GoodsMGroupName)
            || (targetRow.BLGroupCode != sourceRow.BLGroupCode)
            || (targetRow.BLGroupName != sourceRow.BLGroupName)
            || (targetRow.BLGoodsCode != sourceRow.BLGoodsCode)
            || (targetRow.BLGoodsFullName != sourceRow.BLGoodsFullName)
            || (targetRow.StockOrderDivCd != sourceRow.StockOrderDivCd)
            || (targetRow.OpenPriceDiv != sourceRow.OpenPriceDiv)
            || (targetRow.ListPriceTaxExcFl != sourceRow.ListPriceTaxExcFl)
            || (targetRow.ListPriceTaxIncFl != sourceRow.ListPriceTaxIncFl)
            || (targetRow.BfListPrice != sourceRow.BfListPrice)
            || (targetRow.RateBLGoodsCode != sourceRow.RateBLGoodsCode)
            || (targetRow.RateBLGoodsName != sourceRow.RateBLGoodsName)
            || (targetRow.TaxationCode != sourceRow.TaxationCode)
            || (targetRow.ListPrice != sourceRow.ListPrice)
            || (targetRow.SalesUnitCost != sourceRow.SalesUnitCost))
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
			return uoeSndRcvCtlPara;
		}
		# endregion

		# region データ保存処理
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
				//ＵＯＥ発注データ取得
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;
                status = GetToUOEOrderDtlFromRowData(out uOEOrderDtlWorkList, out stockDetailWorkList, inpDisplay, out message);
                if (status != 0)
                {
                    return (status);
                }

				//ＵＯＥ送受信制御の呼び出し
                UoeSndRcvCtlPara uoeSndRcvCtlPara = ToUoeSndRcvCtlParaFromInpDisplay(inpDisplay);
                if ((status = _uoeSndRcvCtlAcs.UoeSndRcvCtl(
                        uoeSndRcvCtlPara,
                        uOEOrderDtlWorkList,
                        stockDetailWorkList,
                        out message)) == 0)
                {
                    // テーブルクリア処理
                    this._orderDataTable.Rows.Clear();
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

        // 2009.05.25 START >>>>>>
        # region データ保存処理(ホンダ UOE WEB専用)
        /// <summary>
        /// データ保存処理(ホンダ UOE WEB専用)
        /// </summary>
        /// <param name="stockSectionCd">拠点コード</param>
        /// <param name="stockAddUpSectionCd">計上拠点</param>
        /// <param name="stockExpansion">在庫マスタ</param>
        /// <param name="retMessage">Message</param>
        /// <returns>STATUS</returns>
        public int ePartsWriteDB(InpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //ＵＯＥ発注データ取得
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;
                status = GetToUOEOrderDtlFromRowData(out uOEOrderDtlWorkList, out stockDetailWorkList, inpDisplay, out message);
                if (status != 0)
                {
                    return (status);
                }

                //ＵＯＥ送受信制御の呼び出し
                if ((status = _uoeOrderInfoAcs.WriteUOEOrderDtl(
                    ref uOEOrderDtlWorkList,
                    ref stockDetailWorkList,
                    0,
                    out message)) == 0)
                {
                    // テーブルクリア処理
                    this._orderDataTable.Rows.Clear();
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
        // 2009.05.25 END   <<<<<<

        #region UOE発注テーブルデータ取得処理(DataRow→UOEOrderDtlWorkList)
        /// <summary>
		/// UOE発注テーブルデータ取得処理(DataRow→UOEOrderDtlWorkList)
		/// </summary>
		/// <returns>UOE発注データリスト</returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: 山形部品完全個別オプション判定追加</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : K2012/12/11 </br>
        /// </remarks>
        private int GetToUOEOrderDtlFromRowData(out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, InpDisplay inpDisplay, out string message)
		{
			// 戻値
            int status = 0;
            message = "";
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();

			try
			{
                //発注先マスタ取得
                UOESupplier uOESupplier = _stockInputInitDataAcs.GetUOESupplier(inpDisplay.UOESupplierCd);
                if (uOESupplier == null)
                {
                    uOEOrderDtlWorkList = null;
                    return -1;
                }

                //部門コード
                int subSectionCode = 0;
                EmployeeDtl employeeDtl = _stockInputInitDataAcs.GetEmployeeDtl(_enterpriseCode, _employeeCode);
                if(employeeDtl != null)
                {
                    subSectionCode = employeeDtl.BelongSubSectionCode;
                }

                // 仕入先略称
                Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(uOESupplier.SupplierCd);
                if (supplier == null)
                {
                    message = "仕入先の取得に失敗しました。";
                    return (-1);
                }

                // ADD K2012/12/11 START >>>>>>
                // 山形部品完全個別オプション判定
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                    ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
                // ADD K2012/12/11 END <<<<<<

                for (int i = 0; i < orderDataTable.Count; i++)
                {
                    if ((string)orderDataTable[i].GoodsNo.Trim() == "") continue;

                    //-----------------------------------------------------------
                    // UOE発注データの設定
                    //-----------------------------------------------------------
                    # region UOE発注データの設定
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    uOEOrderDtlWork.EnterpriseCode = _enterpriseCode;	// 企業コード
                    uOEOrderDtlWork.SystemDivCd = inpDisplay.SystemDivCd;	// システム区分
                    uOEOrderDtlWork.LogicalDeleteCode = 0;                  //論理削除区分

                    uOEOrderDtlWork.SendTerminalNo = _stockInputInitDataAcs.cashRegisterNo;	// 送信端末番号

                    uOEOrderDtlWork.UOESupplierCd = inpDisplay.UOESupplierCd;	// UOE発注先コード
                    uOEOrderDtlWork.UOESupplierName = inpDisplay.UOESupplierName;	// UOE発注先名称
                    uOEOrderDtlWork.CommAssemblyId = uOESupplier.CommAssemblyId;	// 通信アセンブリID
                    uOEOrderDtlWork.SalesDate = DateTime.Now;	// 売上日付
                    uOEOrderDtlWork.InputDay = DateTime.Now;	// 入力日
                    uOEOrderDtlWork.DataUpdateDateTime = DateTime.Now;	// データ更新日時
                    uOEOrderDtlWork.UOEKind = 0;	// UOE種別
                    uOEOrderDtlWork.SectionCode = inpDisplay.SectionCode;	// 拠点コード
                    uOEOrderDtlWork.SubSectionCode = subSectionCode;        // 部門コード

                    uOEOrderDtlWork.CashRegisterNo = _stockInputInitDataAcs.cashRegisterNo;	// レジ番号(端末番号)
                    uOEOrderDtlWork.SupplierFormal = 2; //仕入形式 0:仕入,1:入荷,2:発注　（受注ステータス）

                    uOEOrderDtlWork.BoCode = (string)orderDataTable[i].BoCode;	// BO区分
                    uOEOrderDtlWork.UOEDeliGoodsDiv = inpDisplay.UOEDeliGoodsDiv;	// 納品区分
                    uOEOrderDtlWork.DeliveredGoodsDivNm = inpDisplay.DeliveredGoodsDivNm;	// 納品区分名称
                    uOEOrderDtlWork.FollowDeliGoodsDiv = inpDisplay.FollowDeliGoodsDiv;	// フォロー納品区分
                    uOEOrderDtlWork.FollowDeliGoodsDivNm = inpDisplay.FollowDeliGoodsDivNm;	// フォロー納品区分名称
                    uOEOrderDtlWork.UOEResvdSection = inpDisplay.UOEResvdSection;	// UOE指定拠点
                    uOEOrderDtlWork.UOEResvdSectionNm = inpDisplay.UOEResvdSectionNm;	// UOE指定拠点名称
                    uOEOrderDtlWork.EmployeeCode = inpDisplay.EmployeeCode;	// 従業員コード
                    uOEOrderDtlWork.EmployeeName = inpDisplay.EmployeeName;	// 従業員名称
                    uOEOrderDtlWork.GoodsMakerCd = (Int32)orderDataTable[i].GoodsMakerCd;	// 商品メーカーコード
                    uOEOrderDtlWork.MakerName = (string)orderDataTable[i].MakerName;	// メーカー名称
                    uOEOrderDtlWork.GoodsNo = (string)orderDataTable[i].GoodsNo;	// 商品番号
                    uOEOrderDtlWork.GoodsNoNoneHyphen = (string)orderDataTable[i].GoodsNoNoneHyphen;	// ハイフン無商品番号
                    uOEOrderDtlWork.GoodsName = (string)orderDataTable[i].GoodsName;	// 商品名称                  
                    // DEL K2012/12/11 START >>>>>>
                    //// upd K2012/06/20 >>>
                    ////uOEOrderDtlWork.WarehouseCode = (string)orderDataTable[i].WarehouseCode;	// 倉庫コード
                    ////uOEOrderDtlWork.WarehouseName = (string)orderDataTable[i].WarehouseName;	// 倉庫名称
                    ////uOEOrderDtlWork.WarehouseShelfNo = (string)orderDataTable[i].WarehouseShelfNo;	// 倉庫棚番
                    //uOEOrderDtlWork.WarehouseCode = string.Empty;	// 倉庫コード
                    //uOEOrderDtlWork.WarehouseName = string.Empty;	// 倉庫名称
                    //uOEOrderDtlWork.WarehouseShelfNo = string.Empty;	// 倉庫棚番
                    //// upd K2012/06/20 <<<
                    // DEL K2012/12/11 END <<<<<<
                    // ADD K2012/12/11 START >>>>>>
                    // 山形部品完全個別オプション判定が有効の場合、常に未在庫品とする
                    if (PurchaseStatus.Contract == ps)
                    {
                        uOEOrderDtlWork.WarehouseCode = string.Empty;	// 倉庫コード
                        uOEOrderDtlWork.WarehouseName = string.Empty;	// 倉庫名称
                        uOEOrderDtlWork.WarehouseShelfNo = string.Empty;	// 倉庫棚番
                    }
                    else
                    {
                        uOEOrderDtlWork.WarehouseCode = (string)orderDataTable[i].WarehouseCode;	// 倉庫コード
                        uOEOrderDtlWork.WarehouseName = (string)orderDataTable[i].WarehouseName;	// 倉庫名称
                        uOEOrderDtlWork.WarehouseShelfNo = (string)orderDataTable[i].WarehouseShelfNo;	// 倉庫棚番
                    }
                    // ADD K2012/12/11 END <<<<<<

                    uOEOrderDtlWork.AcceptAnOrderCnt = (Double)orderDataTable[i].AcceptAnOrderCnt;	// 受注数量
                    uOEOrderDtlWork.ListPrice = (Double)orderDataTable[i].ListPrice;	// 定価（浮動）
                    uOEOrderDtlWork.SalesUnitCost = (Double)orderDataTable[i].SalesUnitCost;	// 原価単価

                    uOEOrderDtlWork.SupplierCd = uOESupplier.SupplierCd;	// 仕入先コード
                    uOEOrderDtlWork.SupplierSnm = supplier.SupplierSnm;	// 仕入先略称
                    uOEOrderDtlWork.UoeRemark1 = inpDisplay.UoeRemark1;	// ＵＯＥリマーク１
                    uOEOrderDtlWork.UoeRemark2 = inpDisplay.UoeRemark2;	// ＵＯＥリマーク２

                    uOEOrderDtlWork.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_Process;   //0:未処理,1:処理中,2:送信エラー,3:受信エラー,5:回答埋め込み,9:正常終了

                    uOEOrderDtlWorkList.Add(uOEOrderDtlWork);
                    #endregion

                    //-----------------------------------------------------------
                    // 仕入明細の設定
                    //-----------------------------------------------------------
                    # region 仕入明細の設定
                    StockDetailWork stockDetailWork = new StockDetailWork();
 
                    //仕入形式
                    stockDetailWork.SupplierFormal = 2; //2:発注

                    //仕入行番号
                    stockDetailWork.StockRowNo = i + 1;

                    //企業コード
                    stockDetailWork.EnterpriseCode = _enterpriseCode;

                    //拠点コード
                    stockDetailWork.SectionCode = _loginSectionCode;

                    // 部門コード
                    stockDetailWork.SubSectionCode = subSectionCode;

                    //部門コード
                    stockDetailWork.SubSectionCode = subSectionCode;

                    //仕入形式（元）
                    stockDetailWork.SupplierFormalSrc = 0;

                    //仕入入力者コード
                    stockDetailWork.StockInputCode = _employeeCode;

                    //仕入入力者名称
                    stockDetailWork.StockInputName = _employeeName;

                    //仕入担当者コード
                    stockDetailWork.StockAgentCode = inpDisplay.EmployeeCode;

                    //仕入担当者名称
                    stockDetailWork.StockAgentName = inpDisplay.EmployeeName;

                    //商品属性
                    stockDetailWork.GoodsKindCode = (Int32)orderDataTable[i].GoodsKindCode;

                    //商品メーカーコード
                    stockDetailWork.GoodsMakerCd = (Int32)orderDataTable[i].GoodsMakerCd;

                    //メーカー名称
                    stockDetailWork.MakerName = (string)orderDataTable[i].MakerName;

                    //メーカーカナ名称
                    stockDetailWork.MakerKanaName = (string)orderDataTable[i].MakerKanaName;

                    //商品番号
                    stockDetailWork.GoodsNo = (string)orderDataTable[i].GoodsNo;

                    //商品名称
                    stockDetailWork.GoodsName = (string)orderDataTable[i].GoodsName;

                    //商品名称カナ
                    stockDetailWork.GoodsNameKana = (string)orderDataTable[i].GoodsNameKana;

                    //商品大分類コード
                    stockDetailWork.GoodsLGroup = (Int32)orderDataTable[i].GoodsLGroup;

                    //商品大分類名称
                    stockDetailWork.GoodsLGroupName = (string)orderDataTable[i].GoodsLGroupName;

                    //商品中分類コード
                    stockDetailWork.GoodsMGroup = (Int32)orderDataTable[i].GoodsMGroup;

                    //商品中分類名称
                    stockDetailWork.GoodsMGroupName = (string)orderDataTable[i].GoodsMGroupName;

                    //BLグループコード
                    stockDetailWork.BLGroupCode = (Int32)orderDataTable[i].BLGroupCode;

                    //BLグループコード名称
                    stockDetailWork.BLGroupName = (string)orderDataTable[i].BLGroupName;

                    //BL商品コード
                    stockDetailWork.BLGoodsCode = (Int32)orderDataTable[i].BLGoodsCode;

                    //BL商品コード名称（全角）
                    stockDetailWork.BLGoodsFullName = (string)orderDataTable[i].BLGoodsFullName;

                    // DEL K2012/12/11 START >>>>>>
                    #region DEL
                    //// upd K2012/06/20 >>>
                    //#region DEL
                    //////倉庫コード
                    ////stockDetailWork.WarehouseCode = (string)orderDataTable[i].WarehouseCode;

                    //////倉庫名称
                    ////stockDetailWork.WarehouseName = (string)orderDataTable[i].WarehouseName;

                    //////倉庫棚番
                    ////stockDetailWork.WarehouseShelfNo = (string)orderDataTable[i].WarehouseShelfNo;

                    //////仕入在庫取寄せ区分
                    ////stockDetailWork.StockOrderDivCd = (Int32)orderDataTable[i].StockOrderDivCd;
                    //#endregion DEL
                    ////倉庫コード
                    //stockDetailWork.WarehouseCode = string.Empty;

                    ////倉庫名称
                    //stockDetailWork.WarehouseName = string.Empty;

                    ////倉庫棚番
                    //stockDetailWork.WarehouseShelfNo = string.Empty;

                    ////仕入在庫取寄せ区分
                    //stockDetailWork.StockOrderDivCd = 0;
                    //// upd K2012/06/20 <<<
                    #endregion DEL
                    // DEL K2012/12/11 END <<<<<<
                    // ADD K2012/12/11 START >>>>>>
                    // 山形部品完全個別オプション判定が有効の場合、常に未在庫品とする
                    if (PurchaseStatus.Contract == ps)
                    {
                        //倉庫コード
                        stockDetailWork.WarehouseCode = string.Empty;

                        //倉庫名称
                        stockDetailWork.WarehouseName = string.Empty;

                        //倉庫棚番
                        stockDetailWork.WarehouseShelfNo = string.Empty;

                        //仕入在庫取寄せ区分
                        stockDetailWork.StockOrderDivCd = 0;
                    }
                    else
                    {
                        //倉庫コード
                        stockDetailWork.WarehouseCode = (string)orderDataTable[i].WarehouseCode;

                        //倉庫名称
                        stockDetailWork.WarehouseName = (string)orderDataTable[i].WarehouseName;

                        //倉庫棚番
                        stockDetailWork.WarehouseShelfNo = (string)orderDataTable[i].WarehouseShelfNo;

                        //仕入在庫取寄せ区分
                        stockDetailWork.StockOrderDivCd = (Int32)orderDataTable[i].StockOrderDivCd;
                    }
                    // ADD K2012/12/11 END <<<<<<

                    //オープン価格区分
                    stockDetailWork.OpenPriceDiv = (Int32)orderDataTable[i].OpenPriceDiv;

                    //定価（税抜，浮動）
                    stockDetailWork.ListPriceTaxExcFl = (double)orderDataTable[i].ListPriceTaxExcFl;

                    //定価（税込，浮動）
                    stockDetailWork.ListPriceTaxIncFl = (double)orderDataTable[i].ListPriceTaxIncFl;

                    //仕入単価変更区分
                    stockDetailWork.StockUnitChngDiv = 0;   //0:変更なし

                    //変更前仕入単価（浮動）
                    stockDetailWork.BfStockUnitPriceFl = (double)orderDataTable[i].SalesUnitCost;

                    //変更前定価
                    stockDetailWork.BfListPrice = (double)orderDataTable[i].ListPriceTaxExcFl;

                    //課税区分
                    stockDetailWork.TaxationCode = (Int32)orderDataTable[i].TaxationCode;

                    //仕入単価（税抜，浮動）
                    stockDetailWork.StockUnitPriceFl = (double)orderDataTable[i].SalesUnitCost;

                    //仕入単価（税込，浮動）
                    stockDetailWork.StockUnitTaxPriceFl = _stockInputInitDataAcs.GetStockPriceTaxInc(
                                                                stockDetailWork.StockUnitPriceFl,
                                                                stockDetailWork.TaxationCode,
                                                                supplier.StockCnsTaxFrcProcCd);

                    // 仕入金額の算出
                    #region 仕入金額
                    long stockPriceTaxInc = 0;
                    long stockPriceTaxExc = 0;
                    long stockPriceConsTax = 0;

                    bool bStatus = _stockInputInitDataAcs.CalculationStockPrice(
                        (double)orderDataTable[i].AcceptAnOrderCnt,
                        stockDetailWork.StockUnitPriceFl,
                        stockDetailWork.TaxationCode,
                        supplier.StockMoneyFrcProcCd,
                        supplier.StockCnsTaxFrcProcCd,
                        out stockPriceTaxInc,
                        out stockPriceTaxExc,
                        out stockPriceConsTax);

                    if (bStatus == true)
                    {
                        //仕入金額（税抜き）
                        stockDetailWork.StockPriceTaxExc = stockPriceTaxExc;

                        //仕入金額（税込み）
                        stockDetailWork.StockPriceTaxInc = stockPriceTaxInc;
                    }
                    else
                    {
                        stockDetailWork.StockPriceTaxExc = 0;
                        stockDetailWork.StockPriceTaxInc = 0;
                    }
                    #endregion

                    //BL商品コード（掛率）
                    stockDetailWork.RateBLGoodsCode = (Int32)orderDataTable[i].RateBLGoodsCode;

                    //BL商品コード名称（掛率）
                    stockDetailWork.RateBLGoodsName = (string)orderDataTable[i].RateBLGoodsName;

                    //発注数量
                    stockDetailWork.OrderCnt = (Double)orderDataTable[i].AcceptAnOrderCnt;

                    //発注残数
                    stockDetailWork.OrderRemainCnt = (Double)orderDataTable[i].AcceptAnOrderCnt;

                    //仕入数
                    stockDetailWork.StockCount = (Double)orderDataTable[i].AcceptAnOrderCnt;

                    //仕入先コード
                    stockDetailWork.SupplierCd = uOESupplier.SupplierCd;

                    //仕入先略称
                    stockDetailWork.SupplierSnm = supplier.SupplierSnm;

                    //注文方法
                    stockDetailWork.WayToOrder = 2;

                    //発注データ作成日
                    stockDetailWork.OrderDataCreateDate = DateTime.Now;

                    //発注書発行済区分
                    stockDetailWork.OrderFormIssuedDiv = 0;

                    stockDetailWorkList.Add(stockDetailWork);
                    #endregion
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
                status = -1;
			}
            if (status != 0)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
            }

            return status;
		}
		#endregion

        // ===================================================================================== //
		// 入力データ全般操作処理
		// ===================================================================================== //
		# region Input Data Control Methods
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

		#region 保存データチェック処理
		/// <summary>
		/// 保存データチェック処理
		/// </summary>
        /// <param name="displayNow">ヘッダー部入力項目</param>
        /// <param name="itemNameList">項目名称リスト</param>
		/// <param name="itemList)">項目リスト</param>
		/// <returns>true:保存可 false:保存不可</returns>
		public bool SaveDataCheck(InpDisplay displayNow, out List<string> itemNameList, out List<string> itemList, out int count)
		{
			itemNameList = new List<string>();
			itemList = new List<string>();
			count = 0;

			//明細部
			foreach (StockInputDataSet.OrderExpansionRow row in this._orderDataTable)
			{
				//品番入力チェック
				if (row.InpGoodsNo.Trim() == "") continue;

				//数量
                if((displayNow.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
				|| ((displayNow.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Estmt) && (this._uoeSndRcvJnlAcs.ChkCommAssemblyId(displayNow.UOESupplierCd) == true))
				|| ((displayNow.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Stock) && (this._uoeSndRcvJnlAcs.ChkCommAssemblyId(displayNow.UOESupplierCd) == false)))
                {
                    if(row.InpAcceptAnOrderCnt == 0)
				    {
					    itemNameList.Add("数量");
					    itemList.Add("OrderExpansion");
				    }
                }

				//BO区分
                if((displayNow.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                && (_stockInputInitDataAcs.UOEGuideExists(1, displayNow.UOESupplierCd, row.BoCode) == false))
                //&& (row.InpBoCode.Trim() == ""))
				{
					itemNameList.Add("BO区分");
					itemList.Add("OrderExpansion");
				}

				//メーカーコード
                if (row.GoodsMakerCd == 0)
				{
					itemNameList.Add("メーカー");
					itemList.Add("OrderExpansion");
				}

                //品名
                if (row.GoodsName.Trim() == "")
                {
                    itemNameList.Add("品名");
                    itemList.Add("OrderExpansion");
                }



				if (itemNameList.Count > 0) break;
				count++;
			}
			if (itemNameList.Count > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
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
		/// 仕入明細行貼り付け処理
		/// </summary>
		/// <param name="copyStockRowNoList">コピー元行番号リスト</param>
		/// <param name="pasteIndex">貼り付け行Index</param>
		public void PasteProductStockRow(List<int> copyStockRowNoList, int pasteIndex)
		{
			int pasteTargetStockRowNo = this._orderDataTable[pasteIndex].OrderNo;

			this._orderDataTable.BeginLoadData();
			List<int> cutStockRowNoList = new List<int>();
			List<int> pasteStockRowNoList = new List<int>();
			List<StockInputDataSet.OrderExpansionRow> copyStockRowList = new List<StockInputDataSet.OrderExpansionRow>();

			foreach (int stockRowNo in copyStockRowNoList)
			{
				StockInputDataSet.OrderExpansionRow row = this._orderDataTable.FindByOrderNo(stockRowNo);

				if (row != null)
				{
					copyStockRowList.Add(this.CloneStockRow(row));

					if (row.RowStatus == ROWSTATUS_CUT)
					{
						cutStockRowNoList.Add(row.OrderNo);
					}
				}
			}

			if (cutStockRowNoList.Count > 0)
			{
				// 仕入明細行クリア処理
				for (int i = 0; i < cutStockRowNoList.Count; i++)
				{
					this.ClearStockRow(this._orderDataTable.FindByOrderNo(cutStockRowNoList[i]));
				}
			}

			Dictionary<string, string> newGoodsSetKeyDictionary = new Dictionary<string, string>();
			for (int i = 0; i < copyStockRowList.Count; i++)
			{
				StockInputDataSet.OrderExpansionRow sourceRow = copyStockRowList[i];

				if (this._orderDataTable.Count == (pasteIndex + i))
				{
					this.AddStockRow();
				}

				StockInputDataSet.OrderExpansionRow targetRow = this._orderDataTable[pasteIndex + i];

				this.CopyStockRow(sourceRow, targetRow);


				pasteStockRowNoList.Add(targetRow.OrderNo);
			}

			this._orderDataTable.EndLoadData();

			// 最終行に商品名称が設定されている場合は１行追加
			if (this._orderDataTable[this._orderDataTable.Count - 1].GoodsName != "")
			{
				this.AddStockRow();
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
		/// ＵＯＥ手入力発注明細行削除処理
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
		/// 仕入明細行挿入処理
		/// </summary>
		/// <param name="insertIndex">挿入行Index</param>
		public void InsertProductStockRow(int insertIndex)
		{
			this.InsertProductStockRow(insertIndex, 1);
		}

		/// <summary>
		/// 仕入明細行挿入処理（オーバーロード）
		/// </summary>
		/// <param name="insertIndex">挿入行Index</param>
		/// <param name="line">挿入段数</param>
		public void InsertProductStockRow(int insertIndex, int line)
		{
			this._orderDataTable.BeginLoadData();
			int lastRowIndex = this._orderDataTable.Rows.Count - 1;
			int stockRowNo = -1;
			if (insertIndex >= 0)
			{
				stockRowNo = this._orderDataTable[insertIndex].OrderNo;
			}
			else
			{
				insertIndex = 0;
			}

			// 仕入明細行追加処理
			for (int i = 0; i < line; i++)
			{
				this.AddStockRow();
			}

			// 最終行から挿入対象行までの行情報を指定段ずつ下にコピーする
			if (lastRowIndex != -1)
			{
				for (int i = lastRowIndex; i >= insertIndex; i--)
				{
					StockInputDataSet.OrderExpansionRow sourceRow = this._orderDataTable.FindByOrderNo(this._orderDataTable[i].OrderNo);
					StockInputDataSet.OrderExpansionRow targetRow = this._orderDataTable.FindByOrderNo(this._orderDataTable[i + line].OrderNo);

					this.CopyStockRow(sourceRow, targetRow);
				}
			}

			// 挿入対象行をクリアする
			StockInputDataSet.OrderExpansionRow clearRow = this._orderDataTable.FindByOrderNo(this._orderDataTable[insertIndex].OrderNo);
			this.ClearStockRow(clearRow);
			this._orderDataTable.EndLoadData();
           
		}

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
		/// 仕入明細行展開処理
		/// </summary>
		/// <param name="spreadIndex">展開基準行Index</param>
		public void SpreadProductStockRow(int spreadIndex)
		{
			int stockRowNo = this._orderDataTable[spreadIndex].OrderNo;

            StockInputDataSet.OrderExpansionRow sourceRow = this._orderDataTable.FindByOrderNo(stockRowNo);
            int stockCount = 1;

			if (stockCount < 0)
			{
				stockCount = stockCount * -1;
			}

			if (stockCount <= 1) return;

			// 展開したい行数分だけ新規に行を追加する
			this.InsertProductStockRow(spreadIndex + 1, stockCount - 1);
			for (int i = 1; i < stockCount; i++)
			{
				StockInputDataSet.OrderExpansionRow targetRow = this._orderDataTable[spreadIndex + i];
				this.CopyStockRow(sourceRow, targetRow);
			}
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
		/// 行コピー処理
		/// </summary>
		/// <param name="sourceRow">コピー元在庫マスタテーブル行クラス</param>
		/// <param name="targetRow">コピー先在庫マスタテーブル行クラス</param>
		private void CopyStockRow(StockInputDataSet.OrderExpansionRow sourceRow, StockInputDataSet.OrderExpansionRow targetRow)
		{            
			if ((sourceRow == null) || (targetRow == null)) return;

			//row.RowStatus = ROWSTATUS_NORMAL;
            targetRow.InpGoodsNo = sourceRow.InpGoodsNo;
            //targetRow.InpGoodsNoGuideButton = sourceRow.InpGoodsNoGuideButton;
            targetRow.InpAcceptAnOrderCnt = sourceRow.InpAcceptAnOrderCnt;
            targetRow.InpBoCode = sourceRow.InpBoCode;
            targetRow.InpGoodsMakerCd = sourceRow.InpGoodsMakerCd;
            targetRow.InpBLGoodsCode = sourceRow.InpBLGoodsCode;
            targetRow.InpBLGoodsName = sourceRow.InpBLGoodsName;
            targetRow.InpMakerName = sourceRow.InpMakerName;
            targetRow.DspBLGoodsName = sourceRow.DspBLGoodsName;
            targetRow.DspStockCnt = sourceRow.DspStockCnt;
            targetRow.DspWarehouseName = sourceRow.DspWarehouseName;
            targetRow.DspWarehouseShelfNo = sourceRow.DspWarehouseShelfNo;
            targetRow.WarehouseCode = sourceRow.WarehouseCode;
            targetRow.WarehouseName = sourceRow.WarehouseName;
            targetRow.WarehouseShelfNo = sourceRow.WarehouseShelfNo;
            targetRow.BoCode = sourceRow.BoCode;
            targetRow.GoodsMakerCd = sourceRow.GoodsMakerCd;
            targetRow.MakerName = sourceRow.MakerName;
            targetRow.GoodsNo = sourceRow.GoodsNo;
            targetRow.GoodsNoNoneHyphen = sourceRow.GoodsNoNoneHyphen;
            targetRow.GoodsName = sourceRow.GoodsName;
            targetRow.AcceptAnOrderCnt = sourceRow.AcceptAnOrderCnt;
            targetRow.UoeRemark1 = sourceRow.UoeRemark1;
            targetRow.UoeRemark2 = sourceRow.UoeRemark2;
            targetRow.GoodsKindCode = sourceRow.GoodsKindCode;
            targetRow.MakerKanaName = sourceRow.MakerKanaName;
            targetRow.GoodsNameKana = sourceRow.GoodsNameKana;
            targetRow.GoodsLGroup = sourceRow.GoodsLGroup;
            targetRow.GoodsLGroupName = sourceRow.GoodsLGroupName;
            targetRow.GoodsMGroup = sourceRow.GoodsMGroup;
            targetRow.GoodsMGroupName = sourceRow.GoodsMGroupName;
            targetRow.BLGroupCode = sourceRow.BLGroupCode;
            targetRow.BLGroupName = sourceRow.BLGroupName;
            targetRow.BLGoodsCode = sourceRow.BLGoodsCode;
            targetRow.BLGoodsFullName = sourceRow.BLGoodsFullName;
            targetRow.StockOrderDivCd = sourceRow.StockOrderDivCd;
            targetRow.OpenPriceDiv = sourceRow.OpenPriceDiv;
            targetRow.ListPriceTaxExcFl = sourceRow.ListPriceTaxExcFl;
            targetRow.ListPriceTaxIncFl = sourceRow.ListPriceTaxIncFl;
            targetRow.BfListPrice = sourceRow.BfListPrice;
            targetRow.RateBLGoodsCode = sourceRow.RateBLGoodsCode;
            targetRow.RateBLGoodsName = sourceRow.RateBLGoodsName;
            targetRow.TaxationCode = sourceRow.TaxationCode;
            targetRow.ListPrice = sourceRow.ListPrice;
            targetRow.SalesUnitCost = sourceRow.SalesUnitCost;
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
			row.EditStatus = 0;
			row.RowStatus = ROWSTATUS_NORMAL;

            row.InpGoodsNo = "";
            //row.InpGoodsNoGuideButton = "";
            row.InpAcceptAnOrderCnt = 0;
            row.InpBoCode = "";
            row.InpGoodsMakerCd = "";
            row.InpBLGoodsCode = 0;
            row.InpBLGoodsName = "";
            row.InpMakerName = 0;
            row.DspBLGoodsName = "";
            //row.DspStockCnt = 0; // DEL 袁磊 2012/08/30 redmine#31884
            row.DspStockCnt = ""; // ADD 袁磊 2012/08/30 redmine#31884
            row.DspWarehouseName = "";
            row.DspWarehouseShelfNo = "";
            row.WarehouseCode = "";
            row.WarehouseName = "";
            row.WarehouseShelfNo = "";
            row.BoCode = "";
            row.GoodsMakerCd = 0;
            row.MakerName = "";
            row.GoodsNo = "";
            row.GoodsNoNoneHyphen = "";
            row.GoodsName = "";
            row.AcceptAnOrderCnt = 0;
            row.UoeRemark1 = "";
            row.UoeRemark2 = "";
            row.GoodsKindCode = 0;
            row.MakerKanaName = "";
            row.GoodsNameKana = "";
            row.GoodsLGroup = 0;
            row.GoodsLGroupName = "";
            row.GoodsMGroup = 0;
            row.GoodsMGroupName = "";
            row.BLGroupCode = 0;
            row.BLGroupName = "";
            row.BLGoodsCode = 0;
            row.BLGoodsFullName = "";
            row.StockOrderDivCd = 0;
            row.OpenPriceDiv = 0;
            row.ListPriceTaxExcFl = 0;
            row.ListPriceTaxIncFl = 0;
            row.BfListPrice = 0;
            row.RateBLGoodsCode = 0;
            row.RateBLGoodsName = "";
            row.TaxationCode = 0;
            row.ListPrice = 0;
            row.SalesUnitCost = 0;
        }

		/// <summary>
		/// 明細行クラス複製処理
		/// </summary>
		/// <param name="row">在庫明細行クラス</param>
		/// <returns>複製後在庫明細行クラス</returns>
		private StockInputDataSet.OrderExpansionRow CloneStockRow(StockInputDataSet.OrderExpansionRow sourceRow)
		{
			StockInputDataSet.OrderExpansionRow targetRow = this._orderDataTable.NewOrderExpansionRow();

			//row.RowStatus = ROWSTATUS_NORMAL;
            targetRow.InpGoodsNo = sourceRow.InpGoodsNo;
            targetRow.InpGoodsNoGuideButton = sourceRow.InpGoodsNoGuideButton;
            targetRow.InpAcceptAnOrderCnt = sourceRow.InpAcceptAnOrderCnt;
            targetRow.InpBoCode = sourceRow.InpBoCode;
            targetRow.InpGoodsMakerCd = sourceRow.InpGoodsMakerCd;
            targetRow.InpBLGoodsCode = sourceRow.InpBLGoodsCode;
            targetRow.InpBLGoodsName = sourceRow.InpBLGoodsName;
            targetRow.InpMakerName = sourceRow.InpMakerName;
            targetRow.DspBLGoodsName = sourceRow.DspBLGoodsName;
            targetRow.DspStockCnt = sourceRow.DspStockCnt;
            targetRow.DspWarehouseName = sourceRow.DspWarehouseName;
            targetRow.DspWarehouseShelfNo = sourceRow.DspWarehouseShelfNo;
            targetRow.WarehouseCode = sourceRow.WarehouseCode;
            targetRow.WarehouseName = sourceRow.WarehouseName;
            targetRow.WarehouseShelfNo = sourceRow.WarehouseShelfNo;
            targetRow.BoCode = sourceRow.BoCode;
            targetRow.GoodsMakerCd = sourceRow.GoodsMakerCd;
            targetRow.MakerName = sourceRow.MakerName;
            targetRow.GoodsNo = sourceRow.GoodsNo;
            targetRow.GoodsNoNoneHyphen = sourceRow.GoodsNoNoneHyphen;
            targetRow.GoodsName = sourceRow.GoodsName;
            targetRow.AcceptAnOrderCnt = sourceRow.AcceptAnOrderCnt;
            targetRow.UoeRemark1 = sourceRow.UoeRemark1;
            targetRow.UoeRemark2 = sourceRow.UoeRemark2;
            targetRow.GoodsKindCode = sourceRow.GoodsKindCode;
            targetRow.MakerKanaName = sourceRow.MakerKanaName;
            targetRow.GoodsNameKana = sourceRow.GoodsNameKana;
            targetRow.GoodsLGroup = sourceRow.GoodsLGroup;
            targetRow.GoodsLGroupName = sourceRow.GoodsLGroupName;
            targetRow.GoodsMGroup = sourceRow.GoodsMGroup;
            targetRow.GoodsMGroupName = sourceRow.GoodsMGroupName;
            targetRow.BLGroupCode = sourceRow.BLGroupCode;
            targetRow.BLGroupName = sourceRow.BLGroupName;
            targetRow.BLGoodsCode = sourceRow.BLGoodsCode;
            targetRow.BLGoodsFullName = sourceRow.BLGoodsFullName;
            targetRow.StockOrderDivCd = sourceRow.StockOrderDivCd;
            targetRow.OpenPriceDiv = sourceRow.OpenPriceDiv;
            targetRow.ListPriceTaxExcFl = sourceRow.ListPriceTaxExcFl;
            targetRow.ListPriceTaxIncFl = sourceRow.ListPriceTaxIncFl;
            targetRow.BfListPrice = sourceRow.BfListPrice;
            targetRow.RateBLGoodsCode = sourceRow.RateBLGoodsCode;
            targetRow.RateBLGoodsName = sourceRow.RateBLGoodsName;
            targetRow.TaxationCode = sourceRow.TaxationCode;
            targetRow.ListPrice = sourceRow.ListPrice;
            targetRow.SalesUnitCost = sourceRow.SalesUnitCost;
			return targetRow;
		}
		# endregion

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

	}
}
