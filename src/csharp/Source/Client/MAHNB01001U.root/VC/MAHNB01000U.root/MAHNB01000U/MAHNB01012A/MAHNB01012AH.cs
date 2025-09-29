using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

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
using Broadleaf.Library.Text;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売仕入同時入力アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売仕入同時入力の制御全般を行います。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2008.01.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.01.21 20056 對馬 大輔 新規作成</br>
    /// <br>Update Note : 2010/03/01 李占川 PM.NS保守依頼５次改良対応</br>
    /// <br>              単価モジュールの掛率優先管理マスタキャッシュ処理を使用するように変更</br>
    /// <br>Update Note: 2011/08/15 Redmine#23578 譚洪 連番16での掛率算出の修正内容の対応</br>
    /// </remarks>
    public class SalesSlipStockInfoInputAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members
        private static SalesSlipStockInfoInputAcs _salesSlipStockInfoInputAcs;
        private StockTemp _stockTemp;
        private CustomerInfoAcs _customerInfoAcs;
        private SupplierAcs _supplierAcs;
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private StockPriceCalculate _stockPriceCalculate;
        private int _salesRowNo = 0;
        private string _enterpriseCode;
        private UnitPriceCalculation _unitPriceCalculation;
        private SalesInputDataSet.SalesDetailRow _salesDetailRow;
        private Dictionary<SalesSlipInputAcs.GoodsInfoKey, GoodsUnitData> _goodsUnitDataInfo;
        #endregion

        // ===================================================================================== //
        // 外部に提供する定数群
        // ===================================================================================== //
        # region Public Readonly Members
        /// <summary>発注用ダミー仕入伝票番号</summary>
        public static readonly string ctDummyPartySalesSilpNum = "DummyPartySalesSilpNum";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private SalesSlipStockInfoInputAcs()
        {
            this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._stockPriceCalculate = new StockPriceCalculate();
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            this._salesSlipInputInitDataAcs.CacheStockProcMoneyList += new SalesSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._unitPriceCalculation.CacheStockProcMoneyList);
            this._salesSlipInputInitDataAcs.CacheStockProcMoneyList += new SalesSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._stockPriceCalculate.CacheStockProcMoneyList);
            this._salesSlipInputInitDataAcs.CacheRateProtyMngList += new SalesSlipInputInitDataAcs.CacheRateProtyMngListEventHandler(this._unitPriceCalculation.CacheRateProtyMngAllList); // ADD 2010/03/01
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }
        /// <summary>
        /// 売仕入同時入力アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>売仕入同時入力アクセスクラス インスタンス</returns>
        public static SalesSlipStockInfoInputAcs GetInstance()
        {
            if (_salesSlipStockInfoInputAcs == null)
            {
                _salesSlipStockInfoInputAcs = new SalesSlipStockInfoInputAcs();
            }

            return _salesSlipStockInfoInputAcs;
        }
        #endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ■Delegete
        /// <summary>売上情報画面セットイベント</summary>
        public delegate void SetDisplayStockInfoEventHandler(StockTemp stockTemp);
        /// <summary>売上情報キャッシュイベント</summary>
        public delegate void CacheStockTempEventHandler(int salesRowNo, StockTemp stockTemp);
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■Events
        /// <summary>列最新情報設定イベント</summary>
        public event SetDisplayStockInfoEventHandler SetDisplay;
        /// <summary>列最新情報設定イベント</summary>
        public event CacheStockTempEventHandler CacheStockTemp;
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Properties
        /// <summary>仕入情報プロパティ</summary>
        public StockTemp StockTemp
        {
            get { return this._stockTemp; }
            set { this._stockTemp = value; }
        }

        /// <summary>売上明細データ行オブジェクト</summary>
        public SalesInputDataSet.SalesDetailRow SalesDetailRow
        {
            get { return _salesDetailRow; }
            set { _salesDetailRow = value; }
        }

        /// <summary>商品連結情報ディクショナリ</summary>
        public Dictionary<SalesSlipInputAcs.GoodsInfoKey, GoodsUnitData> GoodsUnitDataInfo
        {
            get { return this._goodsUnitDataInfo; }
            set { this._goodsUnitDataInfo = value; }
        }
        #endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■ Enums
        /// <summary>
        /// 単価種類
        /// </summary>
        public enum UnitPriceKind
        {
            /// <summary>売上単価</summary>
            SalesUnitPrice = 1,
            /// <summary>売上原価</summary>
            SalesUnitCost = 2,
            /// <summary>仕入単価</summary>
            StockUnitPrice = 3,
            /// <summary>定価</summary>
            ListPrice = 4,
        }

        /// <summary>
        /// 仕入形式
        /// </summary>
        public enum SupplierFormal
        {
            /// <summary>設定なし</summary>
            Non = -1,
            /// <summary>仕入</summary>
            Stock = 0,
            /// <summary>入荷</summary>
            ArrivalGoods = 1,
            /// <summary>発注</summary>
            Order = 2,
        }

        /// <summary>
        /// 仕入伝票区分
        /// </summary>
        public enum SupplierSlipCd
        {
            /// <summary>仕入</summary>
            Stock = 10,
            /// <summary>返品</summary>
            RetGoods = 20,
        }

        /// <summary>
        /// 買掛区分
        /// </summary>
        public enum AccPayDivCd : int
        {
            /// <summary>買掛なし</summary>
            NonAccPay = 0,
            /// <summary>買掛</summary>
            AccPay = 1,
        }
        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■Public Methods
        // ----  ADD 2011/08/15 ------>>>>
        /// <summary>
        /// 掛率優先区分をセットします。
        /// </summary>
        /// <remarks>掛率優先区分をセットします。</remarks>
        public void SetUnitPriceCalculation()
        {
            if (this._salesSlipInputInitDataAcs.GetCompanyInf() != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._salesSlipInputInitDataAcs.GetCompanyInf().RatePriorityDiv;
            }
        }
        // ----  ADD 2011/08/15 ------<<<<

        /// <summary>
        /// 仕入情報オブジェクトを画面に設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="stockTemp">仕入情報オブジェクト</param>
        /// <param name="salesDetailRow">売上明細データ行オブジェクト</param>
        public void SettingStockTemp(int salesRowNo, StockTemp stockTemp, SalesInputDataSet.SalesDetailRow salesDetailRow)
        {
            this._stockTemp = stockTemp;
            this._salesRowNo = salesRowNo;
            this._salesDetailRow = salesDetailRow;

            this.SetDisplayCall();
        }

        /// <summary>
        /// 仕入情報キャッシュ処理
        /// </summary>
        /// <param name="stockTemp">仕入情報オブジェクト</param>
        public void Cache(StockTemp stockTemp)
        {
            if (stockTemp == null) return;

            this._stockTemp = stockTemp.Clone();

            this.CacheCall(stockTemp);
        }

        /// <summary>
        /// 仕入情報データに得意先（仕入先）の情報を設定します。
        /// </summary>
        /// <param name="stockTemp">仕入情報データオブジェクト</param>
        /// <param name="salesDetailRow">売上明細データ行オブジェクト</param>
        public void DataSettingStockTemp(ref StockTemp stockTemp, SalesInputDataSet.SalesDetailRow salesDetailRow)
        {
            // 商品名称
            if (stockTemp.GoodsName != salesDetailRow.GoodsName) stockTemp.GoodsName = salesDetailRow.GoodsName;

        }

        /// <summary>
        /// 仕入情報データに得意先（仕入先）の情報を設定します。
        /// </summary>
        /// <param name="stockTemp">仕入情報データオブジェクト（ref）</param>
        /// <param name="supplier">仕入先マスタオブジェクト</param>
        public void SettingStockTempFromSupplier(ref StockTemp stockTemp, Supplier supplier)
        {
            if ((stockTemp == null) || (supplier == null))
            {
                stockTemp.SupplierCd = 0;				        // 仕入先コード
                stockTemp.SupplierNm1 = string.Empty;	        // 仕入先名称１
                stockTemp.SupplierNm2 = string.Empty;	        // 仕入先名称２
                stockTemp.SupplierSnm = string.Empty;	        // 仕入先略称
                stockTemp.BusinessTypeCode = 0;			        // 業種コード
                stockTemp.BusinessTypeName = string.Empty;		// 業種名称
                stockTemp.StockAddUpSectionCd = string.Empty;	// 仕入計上拠点
                stockTemp.SalesAreaCode = 0;			        // 販売エリアコード
                stockTemp.SalesAreaName = string.Empty;			// 販売エリア名称
                stockTemp.SuppRateGrpCode = 0;			        // 仕入先掛率グループコード

                stockTemp.PayeeCode = 0;				        // 支払先コード
                stockTemp.PayeeSnm = string.Empty;				// 支払先略称
                stockTemp.SuppCTaxLayCd = 0;			        // 消費税転嫁方式
                stockTemp.SuppTtlAmntDspWayCd = 0;              // 仕入先総額表示方法区分

                stockTemp.PayeeName = string.Empty;             // 支払先名称１
                stockTemp.PayeeName2 = string.Empty;            // 支払先名称２
                stockTemp.TotalDay = 0;                         // 締日
                stockTemp.NTimeCalcStDate = 0;                  // 次回来勘開始日
            }
            else
            {
                if (supplier == null) supplier = new Supplier();

                // 支払先情報取得
                Supplier payeeSupplier;
                int status = this._supplierAcs.Read(out payeeSupplier, supplier.EnterpriseCode, supplier.PayeeCode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    payeeSupplier = new Supplier();
                }

                if (payeeSupplier == null)
                {
                    payeeSupplier = new Supplier();
                }

                // 仕入先情報
                stockTemp.SupplierCd = supplier.SupplierCd;				    // 仕入先コード
                stockTemp.SupplierNm1 = supplier.SupplierNm1;				// 仕入先名称１
                stockTemp.SupplierNm2 = supplier.SupplierNm2;				// 仕入先名称２
                stockTemp.SupplierSnm = supplier.SupplierSnm;				// 仕入先略称
                stockTemp.BusinessTypeCode = supplier.BusinessTypeCode;		// 業種コード
                stockTemp.BusinessTypeName = supplier.BusinessTypeName;		// 業種名称
                stockTemp.SalesAreaCode = supplier.SalesAreaCode;			// 販売エリアコード
                stockTemp.SalesAreaName = supplier.SalesAreaName;			// 販売エリア名称

                if (!string.IsNullOrEmpty(supplier.StockAgentCode.Trim()))
                {
                    Employee employee = this._salesSlipInputInitDataAcs.GetEmployee(supplier.StockAgentCode);
                    if (employee != null)
                    {
                        stockTemp.StockAgentCode = supplier.StockAgentCode.Trim();
                        string name = supplier.StockAgentName;
                        if (name.Length > 16) name = name.Substring(0, 16);
                        stockTemp.StockAgentName = name;
                    }
                }

                // 仕入計上拠点
                stockTemp.StockAddUpSectionCd = supplier.PaymentSectionCode;

                //this.SuppRateGrpCodeSetting(ref stockTemp, customerInfo, custSuppli); // 仕入先掛率グループコード

                // 消費税の端数処理区分
                double fractionProcUnit;
                int fractionProcCd;
                this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, supplier.StockCnsTaxFrcProcCd, 999999999, out fractionProcUnit, out fractionProcCd);
                stockTemp.StockFractionProcCd = fractionProcCd;

                // 以下、支払先情報
                stockTemp.PayeeCode = payeeSupplier.SupplierCd;
                stockTemp.PayeeSnm = payeeSupplier.SupplierSnm;
                stockTemp.PayeeName = payeeSupplier.SupplierNm1;
                stockTemp.PayeeName2 = payeeSupplier.SupplierNm2;
                stockTemp.TotalDay = payeeSupplier.PaymentTotalDay;
                stockTemp.NTimeCalcStDate = payeeSupplier.NTimeCalcStDate;

                this.SettingAddUpDate(ref stockTemp);

                // 仕入在庫全体設定マスタ情報取得
                StockTtlSt stockTtlSt = this._salesSlipInputInitDataAcs.GetStockTtlSt();

                // 全体初期値設定マスタ情報取得
                AllDefSet allDefSet = this._salesSlipInputInitDataAcs.GetAllDefSet();

                if (stockTtlSt == null) stockTtlSt = new StockTtlSt();

                // 仕入先マスタの仕入先消費税転嫁方式参照区分が
                // 「1:仕入先参照」の場合は得意先仕入情報マスタの「仕入先消費税転嫁方式コード」を設定する
                // 「0:全体設定参照」の場合は税率設定マスタの「消費税転嫁方式コード」を設定する
                stockTemp.SuppCTaxLayCd = (payeeSupplier.SuppCTaxLayRefCd == 1) ? payeeSupplier.SuppCTaxLayCd : this._salesSlipInputInitDataAcs.GetConsTaxLayMethod(0);

                // 仕入先マスタの仕入先総額表示方法参照区分が
                // ｢1:仕入先参照」の場合は得意先仕入情報マスタの「仕入先総額表示方法区分」を設定する
                // ｢0:全体設定参照」の場合は全体初期値設定マスタの「総額表示方法区分」を設定する
                stockTemp.SuppTtlAmntDspWayCd = (payeeSupplier.StckTtlAmntDspWayRef == 1) ? payeeSupplier.SuppTtlAmntDspWayCd : allDefSet.TotalAmountDispWayCd;

                // 総額表示掛率適用区分
                stockTemp.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;
            }
        }

        /// <summary>
        /// 所属情報設定処理
        /// </summary>
        /// <param name="stockSlip">仕入れデータオブジェクト</param>
        public void SettingStockTempStockFromAgentBelongInfo(ref StockTemp stockTemp)
        {
            string belongSecCd;
            int belongSubSecCd;
            this._salesSlipInputInitDataAcs.GetBelongInfo_FromEmployee(stockTemp.StockAgentCode, out belongSecCd, out belongSubSecCd);

            stockTemp.StockSectionCd = belongSecCd;
            stockTemp.SubSectionCode = belongSubSecCd;
        }

        /// <summary>
        /// 仕入情報オブジェクトの数量を設定します。（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        public void SettingStockTempStockCnt(ref StockTemp stockTemp, double stockCount)
        {

            if (stockTemp == null) return;

            //--------------------------------------------
            // 新規登録行
            //--------------------------------------------
            if (stockTemp.StockSlipDtlNum == 0)
            {
                if (stockTemp.EditStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                {
                    // 計上新規
                    stockTemp.StockCount = stockCount;
                    stockTemp.OrderCnt = stockTemp.OrderCnt;
                    stockTemp.OrderAdjustCnt = 0;
                    stockTemp.OrderRemainCnt = stockTemp.OrderCnt - stockTemp.StockCount;
                }
                else
                {
                    // 新規
                    stockTemp.StockCount = stockCount;
                    stockTemp.OrderCnt = stockCount;
                    stockTemp.OrderAdjustCnt = 0;
                    stockTemp.OrderRemainCnt = stockCount;
                }
            }
            else
            //--------------------------------------------
            // 既存修正行
            //--------------------------------------------
            {
                double adjustCnt = stockCount - stockTemp.StockCount; // 入力前との差分
                stockTemp.StockCount = stockCount;
                stockTemp.OrderCnt = stockTemp.StockCount;
                stockTemp.OrderAdjustCnt = stockTemp.OrderAdjustCnt + adjustCnt;
                stockTemp.OrderRemainCnt = stockTemp.OrderRemainCnt + adjustCnt;
            }

            //// 掛率から単価を再計算
            //this.SalesDetailRowGoodsPriceSetting(ref row);

        }

        /// <summary>
        /// 仕入単価設定処理
        /// </summary>
        /// <param name="stockTemp"></param>
        /// <param name="row"></param>
        public void SettingStockTempFromStockUnitPrice(ref StockTemp stockTemp, SalesInputDataSet.SalesDetailRow row)
        {
            // 単価算出
            this.CalclationUnitPrice(ref stockTemp);

            //// 原単価連動区分
            //switch (this._salesSlipInputInitDataAcs.GetAllDefSet().UnCstLinkDiv)
            //{
            //    // しない
            //    case 0:
            //        // 単価算出
            //        this.CalclationUnitPrice(ref stockTemp);
            //        break;
            //    // する
            //    case 1:
            //        // 単価算出
            //        this.CalclationUnitPrice(ref stockTemp);
            //        if ((stockTemp.StockUnitPriceFl == 0) && (stockTemp.StockUnitTaxPriceFl == 0))
            //        {
            //            stockTemp.StockUnitPriceFl = row.SalesUnitCostTaxExc;
            //            stockTemp.StockUnitTaxPriceFl = row.SalesUnitCostTaxInc;
            //        }
            //        break;
            //    // 相互
            //    case 2:
            //        stockTemp.StockUnitPriceFl = row.SalesUnitCostTaxExc;
            //        stockTemp.StockUnitTaxPriceFl = row.SalesUnitCostTaxInc;
            //        break;
            //}
        }

        /// <summary>
        /// 仕入情報オブジェクトの仕入形式を設定
        /// </summary>
        /// <param name="stockTemp"></param>
        /// <param name="supplierFormal"></param>
        public void SettingStockTempFromSupplierFormal(ref StockTemp stockTemp, int supplierFormal)
        {
            if (stockTemp == null) return;

            stockTemp.SupplierFormal = supplierFormal;
        }

        /// <summary>
        /// 仕入情報オブジェクトの仕入伝票番号を設定
        /// </summary>
        /// <param name="stockTemp"></param>
        /// <param name="partySalesSlipNum"></param>
        public void SettingStockTempFromPartySalesSilpNum(ref StockTemp stockTemp, string partySalesSlipNum)
        {
            if (stockTemp == null) return;

            stockTemp.PartySaleSlipNum = partySalesSlipNum;
        }

        /// <summary>
        /// 表示している仕入単価の値を取得します。
        /// </summary>
        /// <param name="stockTemp">仕入情報オブジェクト</param>
        /// <returns>表示単価</returns>
        public double GetUnitPriceDisplay(StockTemp stockTemp)
        {
            return ((stockTemp.SuppTtlAmntDspWayCd == 1) || (stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)) ? stockTemp.StockUnitTaxPriceFl : stockTemp.StockUnitPriceFl;
        }

        /// <summary>
        /// 表示している定価の値を取得します。
        /// </summary>
        /// <param name="stockTemp">仕入情報オブジェクト</param>
        /// <returns>表示定価</returns>
        public double GetListPriceDisplay(StockTemp stockTemp)
        {
            return ((stockTemp.SuppTtlAmntDspWayCd == 1) || (stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)) ? stockTemp.ListPriceTaxIncFl : stockTemp.ListPriceTaxExcFl;
        }

        /// <summary>
        /// 入力した仕入単価を仕入情報オブジェクトにセットします。
        /// </summary>
        /// <param name="stockTemp">仕入情報オブジェクト</param>
        /// <param name="stockUnitPriceDisplay">入力した仕入単価</param>
        public void UnitPriceSetting(ref StockTemp stockTemp, double stockUnitPriceDisplay)
        {
            double stockUnitPriceTaxExc;
            double stockUnitPriceTaxInc;

            int taxationDivCd = stockTemp.TaxationCode;
            if (stockTemp.SuppCTaxLayCd == (int)SalesSlipInputAcs.ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            // 表示価格より税抜き、税込み価格を算出する
            this.CalcTaxExcAndTaxInc(taxationDivCd, stockTemp.SupplierCd, stockTemp.SupplierConsTaxRate, stockTemp.SuppTtlAmntDspWayCd, stockUnitPriceDisplay, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc);

            stockTemp.StockUnitPriceFl = stockUnitPriceTaxExc;
            stockTemp.StockUnitTaxPriceFl = stockUnitPriceTaxInc;
            stockTemp.StockUnitChngDiv = 1;
        }

        /// <summary>
        /// 入力した定価を同時仕入オブジェクトにセットします。
        /// </summary>
        /// <param name="stockTemp">仕入情報オブジェクト</param>
        /// <param name="listPriceDisplay">入力した定価</param>
        public void ListPriceSetting(ref StockTemp stockTemp, double listPriceDisplay)
        {
            double listPriceTaxExcFl;
            double listPriceTaxIncFl;

            int taxationDivCd = stockTemp.TaxationCode;
            if (stockTemp.SuppCTaxLayCd == (int)SalesSlipInputAcs.ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            // 表示価格より税抜き、税込み価格を算出する
            this.CalcTaxExcAndTaxInc(taxationDivCd, stockTemp.SupplierSlipCd, stockTemp.SupplierConsTaxRate, stockTemp.SuppTtlAmntDspWayCd, listPriceDisplay, out listPriceTaxExcFl, out listPriceTaxIncFl);

            stockTemp.ListPriceTaxExcFl = listPriceTaxExcFl;
            stockTemp.ListPriceTaxIncFl = listPriceTaxIncFl;
        }

        ///// <summary>
        ///// 仕入単価再計算チェック
        ///// </summary>
        ///// <param name="stockTemp">仕入情報オブジェクト</param>
        ///// <returns></returns>
        //public bool SalesUnitPriceReCalcCheck(StockTemp stockTemp)
        //{
        //    bool ret = false;

        //    switch (stockTemp.UnPrcCalcCdStckUnPrc)
        //    {
        //        case (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal:				// 基準単価×掛率
        //            {
        //                double targetPrice = (stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc) ? stockTemp.StockUnitTaxPriceFl : stockTemp.StockUnitPriceFl;
        //                if (targetPrice != stockTemp.StdUnPrcStckUnPrc)
        //                {
        //                    ret = true;
        //                }
        //                break;
        //            }

        //        case (int)UnitPriceCalculation.UnitPrcCalcDiv.UpRate:				// 原価×原価UP率
        //        case (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:	// 原価÷(1-粗利率)
        //            {
        //                break;
        //            }
        //    }

        //    return ret;
        //}

        /// <summary>
        /// 単価算出モジュールにより、単価を算出します。
        /// </summary>
        /// <param name="stockTemp">仕入情報オブジェクト</param>
        public void CalclationUnitPrice(ref StockTemp stockTemp)
        {
            //if (this._salesSlipInputInitDataAcs.GetAllDefSet().UnCstLinkDiv == 2) return; // 原単価連動が相互の場合、掛率算出しない

            if ((stockTemp.GoodsMakerCd == 0) || (string.IsNullOrEmpty(stockTemp.GoodsNo))) return; // メーカー・品番未入力時は、掛率算出しない

            int SalesUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.BLGoodsCode = stockTemp.RateBLGoodsCode;							// BLコード
            unitPriceCalcParam.GoodsRateGrpCode = stockTemp.RateGoodsRateGrpCd;                 // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = stockTemp.RateBLGroupCode;                         // BLグループコード
            unitPriceCalcParam.SectionCode = stockTemp.SectionCode;								// 拠点コード
            unitPriceCalcParam.CountFl = stockTemp.StockCount;									// 数量
            unitPriceCalcParam.CustomerCode = stockTemp.SupplierCd; 							// 得意先コード
            unitPriceCalcParam.CustRateGrpCode = stockTemp.CustRateGrpCode;						// 得意先掛率グループコード
            unitPriceCalcParam.SupplierCd = stockTemp.SupplierCd;								// 仕入先コード
            //unitPriceCalcParam.SuppRateGrpCode = stockTemp.SuppRateGrpCode;						// 仕入先掛率グループコード
            //unitPriceCalcParam.DetailGoodsGanreCode = stockTemp.BLGroupCode;        			// 商品区分詳細コード
            //unitPriceCalcParam.EnterpriseGanreCode = stockTemp.EnterpriseGanreCode;				// 自社分類コード
            unitPriceCalcParam.GoodsMakerCd = stockTemp.GoodsMakerCd;							// メーカーコード
            unitPriceCalcParam.GoodsNo = stockTemp.GoodsNo;										// 商品番号
            unitPriceCalcParam.GoodsRateRank = stockTemp.GoodsRateRank;							// 商品掛率ランク
            //unitPriceCalcParam.LargeGoodsGanreCode = stockTemp.GoodsLGroup;     				// 商品区分グループコード
            //unitPriceCalcParam.ListPriceTaxExcFl = stockTemp.ListPriceTaxExcFl;					// 定価税込
            //unitPriceCalcParam.ListPriceTaxIncFl = stockTemp.ListPriceTaxIncFl;					// 定価税
            //unitPriceCalcParam.MediumGoodsGanreCode = stockTemp.GoodsMGroup;	        		// 商品区分コード
            unitPriceCalcParam.PriceApplyDate = (stockTemp.SupplierFormal == (int)SalesSlipStockInfoInputAcs.SupplierFormal.Stock) ? stockTemp.StockDate : stockTemp.ArrivalGoodsDay;
            unitPriceCalcParam.SalesUnPrcFrcProcCd = SalesUnPrcFrcProcCd;						// 売上単価端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = SalesUnPrcFrcProcCd;                       // 仕入単価端数処理コード
            unitPriceCalcParam.SectionCode = stockTemp.SectionCode;								// 拠点コード
            unitPriceCalcParam.TaxationDivCd = stockTemp.TaxationCode;							// 課税区分

            int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
            unitPriceCalcParam.TaxRate = stockTemp.SupplierConsTaxRate;							// 税率
            unitPriceCalcParam.TotalAmountDispWayCd = stockTemp.SuppTtlAmntDspWayCd;			// 総額表示方法区分
            unitPriceCalcParam.TtlAmntDspRateDivCd = stockTemp.TtlAmntDispRateApy;				// 総額表示掛率適用区分

            // ここ
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromDic(stockTemp.GoodsMakerCd, stockTemp.GoodsNo);
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            if (unitPriceCalcRetList != null)
            {
                foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
                {
                    if (unitPriceCalcRet.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                    {
                        //--------------------------------------------
                        // 仕入単価
                        //--------------------------------------------
                        this.StockTempRateInfoClear(ref stockTemp);
                        stockTemp.RateDivStckUnPrc = unitPriceCalcRet.RateSettingDivide;	// 掛率設定区分
                        stockTemp.RateSectStckUnPrc = unitPriceCalcRet.SectionCode;			// 掛率取得拠点コード
                        stockTemp.UnPrcCalcCdStckUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;	// 単価算出区分
                        stockTemp.PriceCdStckUnPrc = unitPriceCalcRet.PriceDiv;				// 価格区分
                        stockTemp.StdUnPrcStckUnPrc = unitPriceCalcRet.StdUnitPrice;		// 基準価格
                        stockTemp.StockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;	// 単価（税抜）
                        stockTemp.StockUnitTaxPriceFl = unitPriceCalcRet.UnitPriceTaxIncFl;	// 単価（税込）
                        stockTemp.StockRate = unitPriceCalcRet.RateVal;						// 掛率
                        stockTemp.FracProcUnitStcUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;// 端数処理単位
                        stockTemp.FracProcStckUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;	// 端数処理区分
                        stockTemp.RateBLGoodsCode = stockTemp.BLGoodsCode;					// BL商品コード(掛率)
                        stockTemp.RateBLGoodsName = stockTemp.BLGoodsFullName;				// BL商品名称(掛率)
                        stockTemp.RateGoodsRateGrpCd = stockTemp.GoodsMGroup;               // 商品掛率グループコード（掛率）
                        stockTemp.RateGoodsRateGrpNm = stockTemp.GoodsMGroupName;           // 商品掛率グループ名称（掛率）
                        stockTemp.RateBLGroupCode = stockTemp.BLGroupCode;                  // BLグループコード（掛率）
                        stockTemp.RateBLGroupName = stockTemp.BLGroupName;                  // BLグループ名称（掛率）
                        stockTemp.BfStockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;	// 変更前原価（税抜き）
                        stockTemp.StockUnitChngDiv = 0;										// 単価変更区分
                        stockTemp.OpenPriceDiv = unitPriceCalcRet.OpenPriceDiv;				// オープン価格区分
                    }
                }
            }
        }

        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="stockTemp">仕入情報データオブジェクト</param>
        public void CalculationStockPrice(ref StockTemp stockTemp)
        {
            // 仕入金額金額を算定
            long stockPriceTaxInc;
            long stockPriceTaxExc;
            double taxRate = stockTemp.SupplierConsTaxRate;

            // 得意先マスタから消費税端数処理情報を取得
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);
            
            int stockPriceFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd); // 仕入金額端数処理コード
            int taxationCode = stockTemp.TaxationCode;

            // 非課税
            if (stockTemp.SuppCTaxLayCd == (int)SalesSlipInputAcs.ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }

            double stockUnitPrice = 0;
            if ((stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc) || (stockTemp.SuppTtlAmntDspWayCd == 1))
            {
                stockUnitPrice = stockTemp.StockUnitTaxPriceFl;
            }
            else
            {
                stockUnitPrice = stockTemp.StockUnitPriceFl;
            }

            // 総額表示時は内税で計算する
            if ((stockTemp.TaxationCode != (int)CalculateTax.TaxationCode.TaxInc) && (stockTemp.SuppTtlAmntDspWayCd == 1)) taxationCode = 2;

            if (this.CalculationStockPrice(
                stockTemp.StockCount,
                stockUnitPrice,
                taxationCode,
                taxRate,
                fracProcUnit,
                fracProcCd,
                stockPriceFrcProcCd,
                out stockPriceTaxInc,
                out stockPriceTaxExc))
            {
                stockTemp.StockPriceTaxExc = stockPriceTaxExc;
                stockTemp.StockPriceTaxInc = stockPriceTaxInc;
                //ここ
                //stockTemp.StockPriceConsTax = (long)((decimal)stockTemp.StockPriceTaxInc - (decimal)stockTemp.StockPriceTaxExc);
                stockTemp.StockPriceConsTaxDetail = (long)((decimal)stockTemp.StockPriceTaxInc - (decimal)stockTemp.StockPriceTaxExc);
            }
        }

        /// <summary>
        /// 単価情報確認用オブジェクト取得
        /// </summary>
        /// <param name="StockTemp">仕入情報オブジェクト</param>
        /// <returns>単価情報確認用オブジェクト</returns>
        public UnPrcInfoConf GetUnitPriceInfoConf(StockTemp stockTemp)
        {
            UnPrcInfoConf unPrcInfoConf = new UnPrcInfoConf();

            if (stockTemp != null)
            {
                unPrcInfoConf.CustomerCode = stockTemp.SupplierCd;  					// 得意先コード
                unPrcInfoConf.CustomerSnm = stockTemp.SupplierSnm;						// 得意先略称
                unPrcInfoConf.SupplierCd = stockTemp.SupplierCd;						// 仕入先コード
                unPrcInfoConf.SupplierSnm = stockTemp.SupplierSnm;						// 仕入先略称
                unPrcInfoConf.CustRateGrpCode = stockTemp.CustRateGrpCode;				// 得意先掛率グループコード
                unPrcInfoConf.GoodsNo = stockTemp.GoodsNo;								// 商品番号
                unPrcInfoConf.GoodsName = stockTemp.GoodsName;							// 商品名称
                unPrcInfoConf.GoodsMakerCd = stockTemp.GoodsMakerCd;					// 商品メーカーコード
                unPrcInfoConf.MakerName = stockTemp.MakerName;							// メーカー名称
                unPrcInfoConf.BLGoodsCode = stockTemp.RateBLGoodsCode;					// BL商品コード
                unPrcInfoConf.BLGoodsFullName = stockTemp.RateBLGoodsName;				// BL商品コード名称（全角）
                unPrcInfoConf.GoodsRateGrpCode = stockTemp.RateGoodsRateGrpCd;          // 商品掛率グループコード（掛率）
                unPrcInfoConf.GoodsRateGrpCodeNm = stockTemp.RateGoodsRateGrpNm;        // 商品掛率グループ名称（掛率）
                unPrcInfoConf.BLGroupCode = stockTemp.RateBLGroupCode;                  // BLグループコード（掛率）
                unPrcInfoConf.BLGroupName = stockTemp.RateBLGroupName;                  // BLグループ名称（掛率）
                unPrcInfoConf.GoodsRateRank = stockTemp.GoodsRateRank;					// 商品掛率ランク
                unPrcInfoConf.PriceApplyDate = (stockTemp.SupplierFormal == (int)SalesSlipStockInfoInputAcs.SupplierFormal.Stock) ? stockTemp.StockDate : stockTemp.ArrivalGoodsDay;	// 価格適用日
                unPrcInfoConf.CountFl = stockTemp.StockCount;    						// 数量

                unPrcInfoConf.RateSettingDivide = stockTemp.RateDivStckUnPrc;		// 掛率設定区分
                unPrcInfoConf.UnitPrcCalcDiv = stockTemp.UnPrcCalcCdStckUnPrc;		// 単価算出区分
                unPrcInfoConf.RateVal = stockTemp.StockRate;						// 掛率
                unPrcInfoConf.UnPrcFracProcUnit = stockTemp.FracProcUnitStcUnPrc;	// 単価端数処理単位
                unPrcInfoConf.UnPrcFracProcDiv = stockTemp.FracProcStckUnPrc;		// 単価端数処理区分
                unPrcInfoConf.StdUnitPrice = stockTemp.StdUnPrcStckUnPrc;			// 基準単価
                unPrcInfoConf.SectionCode = stockTemp.RateSectStckUnPrc;			// 掛率設定拠点

                unPrcInfoConf.UnitPriceTaxExcFl = stockTemp.StockUnitPriceFl;       // 単価（税抜）
                unPrcInfoConf.UnitPriceTaxIncFl = stockTemp.StockUnitTaxPriceFl;    // 単価（税込）
            }

            return unPrcInfoConf;
        }

        /// <summary>
        /// 単価確認画面結果クラスより、単価情報設定を設定します。
        /// </summary>
        /// <param name="unPrcInfoConfRet">単価確認画面結果オブジェクト</param>
        /// <param name="stockTemp">仕入情報オブジェクト</param>
        public void UnPrcInfoSetting(UnPrcInfoConfRet unPrcInfoConfRet, ref StockTemp stockTemp)
        {
            if (stockTemp == null) return;
            // 売上単価
            stockTemp.UnPrcCalcCdStckUnPrc = unPrcInfoConfRet.UnitPrcCalcDiv;		// 単価算出区分
            stockTemp.StockRate = unPrcInfoConfRet.RateVal;							// 掛率
            stockTemp.StdUnPrcStckUnPrc = unPrcInfoConfRet.StdUnitPrice;			// 基準単価
            stockTemp.StockUnitPriceFl = unPrcInfoConfRet.UnitPriceTaxExcFl;        // 単価（税抜）
            stockTemp.StockUnitTaxPriceFl = unPrcInfoConfRet.UnitPriceTaxIncFl;     // 単価（税込）
            stockTemp.FracProcUnitStcUnPrc = unPrcInfoConfRet.UnPrcFracProcUnit;	// 端数処理単位
            stockTemp.FracProcStckUnPrc = unPrcInfoConfRet.UnPrcFracProcDiv;		// 端数処理区分
        }

        /// <summary>
        /// 計上日を設定します。
        /// </summary>
        /// <param name="salesTemp"></param>
        public void SettingAddUpDate(ref StockTemp stockTemp)
        {
            DateTime addUpDate;
            int delayPaymentDiv;
            SalesSlipInputAcs.CalcAddUpDate(stockTemp.StockDate, stockTemp.TotalDay, stockTemp.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

            stockTemp.StockAddUpADate = addUpDate;
            stockTemp.DelayPaymentDiv = delayPaymentDiv;
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// 画面表示イベント実行
        /// </summary>
        private void SetDisplayCall()
        {
            if (this.SetDisplay != null)
            {
                this.SetDisplay(this._stockTemp);
            }
        }

        /// <summary>
        /// キャッシュイベントコール処理
        /// </summary>
        /// <param name="stockTemp"></param>
        private void CacheCall(StockTemp stockTemp)
        {
            if (this.CacheStockTemp != null)
            {
                this.CacheStockTemp(this._salesRowNo, stockTemp);
            }
        }

        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="unitPrice">単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="taxFracProcUnit">消費税端数処理単位</param>
        /// <param name="taxFracProcCd">消費税端数処理区分</param>
        /// <param name="fracProcCode">端数処理コード</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <returns></returns>
        private bool CalculationStockPrice(double count, double unitPrice, int taxationCode, double taxRate, double taxFracProcUnit, int taxFracProcCd, int fracProcCode, out long stockPriceTaxInc, out long stockPriceTaxExc)
        {
            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;

            // 仕入数が0または仕入単価が0の場合はすべて0で終了
            if ((count == 0) || (unitPrice == 0)) return true;

            // 外税の場合
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = unitPrice;	// 単価（税抜き）
                double unitPriceInc;				// 単価（税込み）
                double unitPriceTax;				// 単価（消費税）
                long priceExc = 0;					// 価格（税抜き）
                long priceInc;						// 価格（税込み）
                long priceTax;						// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;		// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;		// 仕入金額（税抜き）		
            }
            // 内税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;				// 単価（税抜き）
                double unitPriceInc = unitPrice;	// 単価（税込み）
                double unitPriceTax;				// 単価（消費税）
                long priceExc;						// 価格（税抜き）
                long priceInc = 0;					// 価格（税込み）
                long priceTax;						// 価格（消費税）

                this._stockPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;		// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;		// 仕入金額（税抜き）
            }
            // 非課税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = unitPrice;	// 単価（税抜き）
                double unitPriceInc;				// 単価（税込み）
                double unitPriceTax;				// 単価（消費税）
                long priceExc = 0;					// 価格（税抜き）
                long priceInc;						// 価格（税込み）
                long priceTax;						// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceExc;		// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;		// 仕入金額（税込み）
            }

            return true;
        }

        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        public void CalcTaxExcAndTaxInc(int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // 得意先マスタから消費税端数処理情報を取得
            int salesTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, customerCode, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // 内税品
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // 外税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // 総額表示している場合は税込み価格
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // 非課税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }

        /// <summary>
        /// 同時売上オブジェクトの掛率関係の情報をクリアします。
        /// </summary>
        /// <param name="salesTemp"></param>
        private void StockTempRateInfoClear(ref StockTemp stockTemp)
        {
            stockTemp.RateDivStckUnPrc = string.Empty;	// 掛率設定区分
            stockTemp.RateSectStckUnPrc = string.Empty;	// 掛率取得拠点コード
            stockTemp.UnPrcCalcCdStckUnPrc = 0;	// 単価算出区分
            stockTemp.PriceCdStckUnPrc = 0;		// 価格区分
            stockTemp.StdUnPrcStckUnPrc = 0;	// 基準価格
            stockTemp.StockUnitPriceFl = 0;	    // 単価（税抜）
            stockTemp.StockUnitTaxPriceFl = 0;	// 単価（税込）
            stockTemp.StockRate = 0;			// 掛率
            stockTemp.FracProcUnitStcUnPrc = 0; // 端数処理単位
            stockTemp.FracProcStckUnPrc = 0;	// 端数処理区分
            stockTemp.RateBLGoodsCode = 0;		// BL商品コード(掛率)
            stockTemp.RateBLGoodsName = string.Empty;		// BL商品名称(掛率)
            stockTemp.RateGoodsRateGrpCd = 0;   // 商品掛率グループコード（掛率）
            stockTemp.RateGoodsRateGrpNm = string.Empty; // 商品掛率グループ名称（掛率）
            stockTemp.RateBLGroupCode = 0;      // BLグループコード（掛率）
            stockTemp.RateBLGroupName = string.Empty; // BLグループ名称（掛率）
            stockTemp.BfStockUnitPriceFl = 0;	// 変更前原価（税抜き）
            stockTemp.StockUnitChngDiv = 0;		// 単価変更区分
            stockTemp.OpenPriceDiv = 0;			// オープン価格区分
        }

        /// <summary>
        /// 商品連結データオブジェクト取得(商品Dictionaryより取得)
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns></returns>
        private GoodsUnitData GetGoodsUnitDataFromDic(int goodsMakerCode, string goodsNo)
        {
            GoodsUnitData goodsUnitData = null;
            SalesSlipInputAcs.GoodsInfoKey goodsInfoKey = new SalesSlipInputAcs.GoodsInfoKey(goodsNo, goodsMakerCode);
            if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) goodsUnitData = this._goodsUnitDataInfo[goodsInfoKey];
            return goodsUnitData;
        }
        #endregion

        // ===================================================================================== //
        // スタティックメソッド
        // ===================================================================================== //
        #region ■Static Methods
        /// <summary>
        /// 表示用仕入伝票区分分より、データ用の仕入伝票区分、買掛区分をセットします
        /// </summary>
        /// <param name="stockSlip">仕入オブジェクト</param>
        static public void SetSlipCdAndAccPayDivCdFromDisplay(int supplierSlipDisplay, ref StockTemp stockTemp)
        {
            int supplierSlipCd;
            int accPayDivCd;

            GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay(supplierSlipDisplay, out supplierSlipCd, out accPayDivCd);

            stockTemp.SupplierSlipCd = supplierSlipCd;
            stockTemp.AccPayDivCd = accPayDivCd;
        }

        /// <summary>
        /// 表示用仕入伝票区分より、仕入伝票区分、買掛区分を取得します。
        /// </summary>
        /// <param name="supplierSlipDisplay">表示用仕入伝票区分</param>
        /// <param name="supplierSlipCd">仕入伝票区分</param>
        /// <param name="accPayDivCd">買掛区分</param>
        static public void GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay(int supplierSlipDisplay, out int supplierSlipCd, out int accPayDivCd)
        {
            // 初期値は掛仕入
            supplierSlipCd = 10;
            accPayDivCd = 1;
            switch (supplierSlipDisplay)
            {
                case 10:                                    // 掛仕入
                    {
                        supplierSlipCd = 10;
                        accPayDivCd = 1;
                        break;
                    }
                case 20:                                    // 掛返品
                    {
                        supplierSlipCd = 20;
                        accPayDivCd = 1;
                        break;
                    }
                case 30:                                    // 現金仕入
                    {
                        supplierSlipCd = 10;
                        accPayDivCd = 0;
                        break;
                    }
                case 40:                                    // 現金返品
                    {
                        supplierSlipCd = 20;
                        accPayDivCd = 0;
                        break;
                    }
            }
        }

        ///// <summary>
        ///// データの仕入伝票区分、買掛区分より、表示用仕入伝票区分をセットします。
        ///// </summary>
        ///// <param name="stockSlip">仕入オブジェクト</param>
        //static public void SetDisplayFromSlipCdAndAccPayDivCd(ref StockTemp stockTemp)
        //{
        //    stockTemp.SupplierSlipDisplay = GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(stockTemp.SupplierSlipCd, stockTemp.AccPayDivCd);
        //}

        /// <summary>
        /// 仕入伝票区分、買掛区分より、表示用仕入伝票区分します。
        /// </summary>
        /// <param name="supplierSlipCd">仕入伝票区分</param>
        /// <param name="accPayDivCd">買掛区分</param>
        /// <returns>表示用仕入伝票区分</returns>
        static public int GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(int supplierSlipCd, int accPayDivCd)
        {
            // 10:掛仕入
            // 20:掛返品
            // 30:現金仕入
            // 40:現金返品
            int value = 0;
            switch (supplierSlipCd)
            {
                case 10:
                    {
                        value = 10;
                        break;
                    }
                case 20:
                    {
                        value = 20;
                        break;
                    }
            }
            switch (accPayDivCd)
            {
                case 0:
                    {
                        value += 20;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return value;
        }
        #endregion

    }
}
