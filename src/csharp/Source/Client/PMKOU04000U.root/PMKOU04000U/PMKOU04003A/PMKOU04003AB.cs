//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入先電子元帳行アクセスクラス
// プログラム概要   : 仕入先電子元帳で使用するアクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI千田 晃久
// 修 正 日  2013/01/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI冨樫 紗由里
// 修 正 日  2013/03/01  修正内容 : システムテスト障害No233対応
//                                  返品計上タブの棚番情報をセットするように修正
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 譚洪
// 修 正 日  2014/01/07  修正内容 : Redmine#41771 仕入伝票入力消費税8%増税対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    public partial class SuppPtrStockDetailAcs
    {

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SuppPtrStockDetailAcs()
        {
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 自拠点コード取得
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            //仕入返品計上更新部品のインスタンス取得
            this._stockSlipRetPlnAcs = StockSlipRetPlnAcs.GetInstance();

            // データセットを作成
            this._detailDataSet = new SuppPtrStcDetailDataSet();

            // 仕入先マスタアクセスクラス
            this._supplierAcs = new SupplierAcs();

            // 仕入金額処理設定アクセスクラス
            this._stockProcMoneyAcs = new StockProcMoneyAcs();

            // 仕入金額処理区分設定リスト取得
            this.GetStockProcMonyList();

            // 仕入金額算出モジュール
            this._stockPriceCalculate = new StockPriceCalculate();
            this._stockPriceCalculate.CacheStockProcMoneyList(this._stockProcMoneyList);

            // 税率設定マスタアクセスクラス
            this._taxRateSetAcs = new TaxRateSetAcs();
        }

        #endregion // コンストラクタ

        # region enum
        /// <summary>
        /// 総額表示方法区分
        /// </summary>
        internal enum TotalAmountDispWayCd : int
        {
            /// <summary>総額表示しない</summary>
            NoTotalAmount = 0,
            /// <summary>総額表示する</summary>
            TotalAmount = 1,
        }
        /// <summary>
        /// 消費税転嫁方式
        /// </summary>
        internal enum ConsTaxLayMethod : int
        {
            /// <summary>伝票転嫁</summary>
            SlipLay = 0,
            /// <summary>明細転嫁</summary>
            DetailLay = 1,
            /// <summary>請求親</summary>
            DemandParentLay = 2,
            /// <summary>請求子</summary>
            DemandChildLay = 3,
            /// <summary>非課税</summary>
            TaxExempt = 9,
        }
        /// <summary>
        /// 仕入伝票区分（明細）
        /// </summary>
        internal enum StockSlipCdDtl : int
        {
            /// <summary>仕入</summary>
            Stock = 0,
            /// <summary>返品</summary>
            RetGoods = 1,
            /// <summary>値引</summary>
            Discount = 2,
        }
        /// <summary>
        /// 商品区分
        /// </summary>
        internal enum SalesGoodsCd : int
        {
            /// <summary>商品</summary>
            Goods = 0,
            /// <summary>商品外</summary>
            NonGoods = 1,
            /// <summary>消費税調整</summary>
            ConsTaxAdjust = 2,
            /// <summary>残高調整</summary>
            BalanceAdjust = 3,
            /// <summary>売掛用消費税調整</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>売掛用残高調整</summary>
            AccRecBalanceAdjust = 5,
        }
        # endregion

        # region const
        /// <summary>端数処理対象金額区分（売上金額）</summary>
        internal const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        internal const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        internal const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        # endregion

        # region struct
        # region [仕入伝票論理KEY]
        /// <summary>
        /// 仕入伝票論理KEY
        /// </summary>
        private struct StockSlipLogicalKey
        {
            /// <summary>企業コード</summary>
            private string _enterpriseCode;
            /// <summary>仕入先</summary>
            private int _supplierCd;
            /// <summary>仕入日</summary>
            private DateTime _stockDate;
            /// <summary>伝票区分</summary>
            private int _supplierSlipCd;
            /// <summary>伝票番号</summary>
            private string _partySaleSlipNum;
            /// <summary>拠点コード</summary>
            private string _sectionCode;

            /// <summary>
            /// 企業コード
            /// </summary>
            public string EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }
            /// <summary>
            /// 仕入先
            /// </summary>
            public int SupplierCd
            {
                get { return _supplierCd; }
                set { _supplierCd = value; }
            }
            /// <summary>
            /// 仕入日
            /// </summary>
            public DateTime StockDate
            {
                get { return _stockDate; }
                set { _stockDate = value; }
            }
            /// <summary>
            /// 伝票区分
            /// </summary>
            public int SupplierSlipCd
            {
                get { return _supplierSlipCd; }
                set { _supplierSlipCd = value; }
            }
            /// <summary>
            /// 伝票番号
            /// </summary>
            /// <remarks>相手先の伝票番号</remarks>
            public string PartySaleSlipNum
            {
                get { return _partySaleSlipNum; }
                set { _partySaleSlipNum = value; }
            }
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="enterpriseCode">企業コード</param>
            /// <param name="supplierCd">仕入先</param>
            /// <param name="stockDate">仕入日</param>
            /// <param name="supplierSlipCd">伝票区分</param>
            /// <param name="partySaleSlipNum">伝票番号</param>
            /// <param name="sectionCode">拠点コード</param>
            public StockSlipLogicalKey(string enterpriseCode, int supplierCd, DateTime stockDate, int supplierSlipCd, string partySaleSlipNum, string sectionCode)
            {
                _enterpriseCode = enterpriseCode;
                _supplierCd = supplierCd;
                _stockDate = stockDate;
                _supplierSlipCd = supplierSlipCd;
                _partySaleSlipNum = partySaleSlipNum;
                _sectionCode = sectionCode;
            }
        }
        # endregion
        # region [商品KEY]
        /// <summary>
        /// 商品KEY
        /// </summary>
        private struct GoodsKey
        {
            /// <summary>品番</summary>
            private string _goodsNo;
            /// <summary>メーカー</summary>
            private int _goodsMakerCd;
            /// <summary>
            /// 品番
            /// </summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>
            /// メーカー
            /// </summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="goodsNo">品番</param>
            /// <param name="goodsMakerCd">メーカー</param>
            public GoodsKey(string goodsNo, int goodsMakerCd)
            {
                _goodsNo = goodsNo;
                _goodsMakerCd = goodsMakerCd;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="goodsUnitData">商品</param>
            public GoodsKey(GoodsUnitData goodsUnitData)
            {
                _goodsNo = goodsUnitData.GoodsNo;
                _goodsMakerCd = goodsUnitData.GoodsMakerCd;
            }
        }
        # endregion
        # endregion

        # region class
        # region [赤伝登録パラメータ]
        /// <summary>
        /// 赤伝登録パラメータ
        /// </summary>
        public class RedSlipWriteParameter
        {
            /// <summary>企業コード</summary>
            private string _enterpriseCode;
            /// <summary>伝票区分</summary>
            private int _slipCd;
            /// <summary>入力従業員コード</summary>
            private string _inputEmployeeCd;
            /// <summary>入力従業員名称</summary>
            private string _inputEmployeeNm;
            /// <summary>売上日</summary>
            private DateTime _salesDate;
            /// <summary>手数料率(取寄)</summary>
            private double _feeRateOfOrder;
            /// <summary>手数料額(取寄)</summary>
            private Int64 _feePriceOfOrder;
            /// <summary>手数料率(在庫)</summary>
            private double _feeRateOfStock;
            /// <summary>手数料額(在庫)</summary>
            private Int64 _feePriceOfStock;
            /// <summary>手数料率(合計)</summary>
            private double _feeRateOfTotal;
            /// <summary>手数料額(合計)</summary>
            private Int64 _feePriceOfTotal;
            /// <summary>販売区分</summary>
            private Int32 _salesCodeDiv;
            /// <summary>得意先注番</summary>
            private string _partySalesSlipNo;
            /// <summary>備考１</summary>
            private string _slipNote;
            /// <summary>備考２</summary>
            private string _slipNote2;
            /// <summary>備考３</summary>
            private string _slipNote3;
            /// <summary>返品理由</summary>
            private string _returnReason;
            /// <summary>返品理由コード</summary>
            private Int32 _returnReasonDiv;
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>得意先コード</summary>
            private int _customerCode;
            /// <summary>車両走行距離</summary>
            private int _mileage;
            /// <summary>車輌備考</summary>
            private string _carNote;

            /// <summary>
            /// 車輌備考
            /// </summary>
            public string CarNote
            {
                get { return _carNote; }
                set { _carNote = value; }
            }
            /// <summary>
            /// 車両走行距離
            /// </summary>
            public int Mileage
            {
                get { return _mileage; }
                set { _mileage = value; }
            }

            /// <summary>
            /// 企業コード
            /// </summary>
            public string EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }
            /// <summary>
            /// 伝票区分
            /// </summary>
            public int SlipCd
            {
                get { return _slipCd; }
                set { _slipCd = value; }
            }
            /// <summary>
            /// 入力従業員コード
            /// </summary>
            public string InputEmployeeCd
            {
                get { return _inputEmployeeCd; }
                set { _inputEmployeeCd = value; }
            }
            /// <summary>
            /// 入力従業員名称
            /// </summary>
            public string InputEmployeeNm
            {
                get { return _inputEmployeeNm; }
                set { _inputEmployeeNm = value; }
            }
            /// <summary>
            /// 売上日
            /// </summary>
            public DateTime SalesDate
            {
                get { return _salesDate; }
                set { _salesDate = value; }
            }
            /// <summary>
            /// 手数料率(取寄)
            /// </summary>
            public double FeeRateOfOrder
            {
                get { return _feeRateOfOrder; }
                set { _feeRateOfOrder = value; }
            }
            /// <summary>
            /// 手数料額(取寄)
            /// </summary>
            public Int64 FeePriceOfOrder
            {
                get { return _feePriceOfOrder; }
                set { _feePriceOfOrder = value; }
            }
            /// <summary>
            /// 手数料率(在庫)
            /// </summary>
            public double FeeRateOfStock
            {
                get { return _feeRateOfStock; }
                set { _feeRateOfStock = value; }
            }
            /// <summary>
            /// 手数料額(在庫)
            /// </summary>
            public Int64 FeePriceOfStock
            {
                get { return _feePriceOfStock; }
                set { _feePriceOfStock = value; }
            }
            /// <summary>
            /// 手数料率(合計)
            /// </summary>
            public double FeeRateOfTotal
            {
                get { return _feeRateOfTotal; }
                set { _feeRateOfTotal = value; }
            }
            /// <summary>
            /// 手数料額(合計)
            /// </summary>
            public Int64 FeePriceOfTotal
            {
                get { return _feePriceOfTotal; }
                set { _feePriceOfTotal = value; }
            }
            /// <summary>
            /// 販売区分
            /// </summary>
            public Int32 SalesCodeDiv
            {
                get { return _salesCodeDiv; }
                set { _salesCodeDiv = value; }
            }
            /// <summary>
            /// 得意先注番
            /// </summary>
            public string PartySalesSlipNo
            {
                get { return _partySalesSlipNo; }
                set { _partySalesSlipNo = value; }
            }
            /// <summary>
            /// 備考１
            /// </summary>
            public string SlipNote
            {
                get { return _slipNote; }
                set { _slipNote = value; }
            }
            /// <summary>
            /// 備考２
            /// </summary>
            public string SlipNote2
            {
                get { return _slipNote2; }
                set { _slipNote2 = value; }
            }
            /// <summary>
            /// 備考３
            /// </summary>
            public string SlipNote3
            {
                get { return _slipNote3; }
                set { _slipNote3 = value; }
            }
            /// <summary>
            /// 返品理由
            /// </summary>
            public string ReturnReason
            {
                get { return _returnReason; }
                set { _returnReason = value; }
            }
            /// <summary>
            /// 返品理由コード
            /// </summary>
            public Int32 RetGoodsReasonDiv
            {
                get { return _returnReasonDiv; }
                set { _returnReasonDiv = value; }
            }
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public RedSlipWriteParameter()
            {
                _enterpriseCode = string.Empty;
                _slipCd = 0;
                _inputEmployeeCd = string.Empty;
                _inputEmployeeNm = string.Empty;
                _salesDate = DateTime.MinValue;
                _feeRateOfOrder = 0;
                _feePriceOfOrder = 0;
                _feeRateOfStock = 0;
                _feePriceOfStock = 0;
                _feeRateOfTotal = 0;
                _feePriceOfTotal = 0;
                _salesCodeDiv = 0;
                _partySalesSlipNo = string.Empty;
                _slipNote = string.Empty;
                _slipNote2 = string.Empty;
                _slipNote3 = string.Empty;
                _returnReason = string.Empty;
                _sectionCode = string.Empty;
                _customerCode = 0;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="enterpriseCode">企業コード</param>
            /// <param name="slipCd">伝票区分</param>
            /// <param name="inputEmployeeCd">入力従業員コード</param>
            /// <param name="inputEmployeeNm">入力従業員名称</param>
            /// <param name="salesDate">売上日</param>
            /// <param name="feeRateOfOrder">手数料率(取寄)</param>
            /// <param name="feePriceOfOrder">手数料額(取寄)</param>
            /// <param name="feeRateOfStock">手数料率(在庫)</param>
            /// <param name="feePriceOfStock">手数料額(在庫)</param>
            /// <param name="feeRateOfTotal">手数料率(合計)</param>
            /// <param name="feePriceOfTotal">手数料額(合計)</param>
            /// <param name="salesCodeDiv">販売区分</param>
            /// <param name="partySalesSlipNo">得意先注番</param>
            /// <param name="slipNote">備考１</param>
            /// <param name="slipNote2">備考２</param>
            /// <param name="slipNote3">備考３</param>
            /// <param name="returnReason">返品理由</param>
            /// <param name="returnReasonDiv">返品理由コード</param>
            /// <param name="sectionCode">拠点コード</param>
            /// <param name="customerCode">得意先コード</param>
            public RedSlipWriteParameter(string enterpriseCode, int slipCd, string inputEmployeeCd, string inputEmployeeNm, DateTime salesDate, double feeRateOfOrder, Int64 feePriceOfOrder, double feeRateOfStock, Int64 feePriceOfStock, double feeRateOfTotal, Int64 feePriceOfTotal, Int32 salesCodeDiv, string partySalesSlipNo, string slipNote, string slipNote2, string slipNote3, string returnReason, int returnReasonDiv, string sectionCode, int customerCode)
            {
                _enterpriseCode = enterpriseCode;
                _slipCd = slipCd;
                _inputEmployeeCd = inputEmployeeCd;
                _inputEmployeeNm = inputEmployeeNm;
                _salesDate = salesDate;
                _feeRateOfOrder = feeRateOfOrder;
                _feePriceOfOrder = feePriceOfOrder;
                _feeRateOfStock = feeRateOfStock;
                _feePriceOfStock = feePriceOfStock;
                _feeRateOfTotal = feeRateOfTotal;
                _feePriceOfTotal = feePriceOfTotal;
                _salesCodeDiv = salesCodeDiv;
                _partySalesSlipNo = partySalesSlipNo;
                _slipNote = slipNote;
                _slipNote2 = slipNote2;
                _slipNote3 = slipNote3;
                _returnReason = returnReason;
                _returnReasonDiv = returnReasonDiv;
                _sectionCode = sectionCode;
                _customerCode = customerCode;
            }
        }
        # endregion

        /// <summary>
        /// 仕入金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
        # endregion

        #region プライベート変数
        private string _enterpriseCode = string.Empty;             // 企業コード
        private StockSlipRetPlnAcs _stockSlipRetPlnAcs = null;     // 仕入返品予定計上更新部品アクセス
        private SuppPtrStcDetailDataSet _detailDataSet = null;     // 明細データ格納データセット
        private SupplierAcs _supplierAcs = null;                   // 仕入先マスタアクセスクラス
        private Supplier _supplier = null;							// 計上対象の仕入先情報
        private StockProcMoneyAcs _stockProcMoneyAcs = null;       // 仕入金額処理設定アクセスクラス
        private List<StockProcMoney> _stockProcMoneyList = null;   // 仕入金額処理区分設定リスト
        private StockPriceCalculate _stockPriceCalculate = null;   // 仕入金額算出モジュール
        private Dictionary<GoodsKey, GoodsUnitData> _goodsUnitDataDic;  // 商品ディクショナリ
        private GoodsAcs _goodsAcs;                                // 商品アクセスクラス
        private string _loginSectionCode = string.Empty;           // 自拠点コード
        private TaxRateSetAcs _taxRateSetAcs = null;                // 税率設定マスタアクセスクラス
        TaxRateSet _taxRateSet = null;                              // 税率情報
        private double _taxRate = 0.0;                              // 税率(税率設定マスタから取得)
       #endregion

        /// <summary>
        /// 返品予定データ削除処理
        /// </summary>
        /// <param name="para">返品計上用パラメータ</param>
        /// <param name="delSlipView">削除対象伝票リスト</param>
        /// <param name="delRetSlipView">削除対象伝票リスト(返品計上使用分)</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        public int DeleteSlip(RetGdsAddUpWriteParameter para, DataRow[] delSlipView, SuppPtrStcDetailDataSet.RetGdsStcListDataTable delRetGdsStcList, out string errorMessage)
        {

            errorMessage = string.Empty;
            StockSlipWork stockSlipWork = new StockSlipWork();
            ArrayList stockSlipWorkList = new ArrayList();
            Int32 retSuppSlipNo = 0;

            foreach (DataRow rowView in delSlipView)
            {

                // stockSlipWorkに値を設定する
                stockSlipWork = new StockSlipWork();
                // 削除対象伝票から仕入伝票番号を取得し、返品計上使用分DataSetから対応データを抽出する
                retSuppSlipNo = ConvertInt32Column(rowView[_detailDataSet.StcList.SupplierSlipNoColumn.ColumnName]);
                DataRow[] delRetRows = delRetGdsStcList.Select(string.Format("{0} = {1}", delRetGdsStcList.SupplierSlipNoColumn.ColumnName, retSuppSlipNo));
                SlcListFromStockSlipWorkData(para, rowView, delRetRows[0], out stockSlipWork);

                // stockSlipWorkListに追加する
                stockSlipWorkList.Add(stockSlipWork);

            }

            object dataObj = (object)stockSlipWorkList;

            // 返品予定データ削除処理(PMKAK01100Acs)
            int status = _stockSlipRetPlnAcs.DeleteStockSlipRetPln(ref dataObj, out errorMessage);

            return status;
        }

        /// <summary>
        /// 返品計上処理
        /// </summary>
        /// <param name="para">返品計上用パラメータ</param>
        /// <param name="regGdsDetail">赤伝データセット</param>
        /// <param name="stcList">仕入伝票データセット</param>
        /// <param name="retGdsStcList">仕入伝票データセット(返品計上使用分)</param>
        /// <param name="StcDetail">仕入明細データセット</param>
        /// <param name="RetGdsStcDetail">仕入明細データセット(返品計上使用分)</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// <br>Note       : システムテスト障害No233対応 返品計上タブの棚番情報をセットするように修正</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2013/03/01</br>
        /// </remarks>
        public int WriteRetGoodsAddUp(RetGdsAddUpWriteParameter para, DataView regGdsDetail, SuppPtrStcDetailDataSet.StcListDataTable stcList, SuppPtrStcDetailDataSet.RetGdsStcListDataTable retGdsStcList, SuppPtrStcDetailDataSet.StcDetailDataTable StcDetail, SuppPtrStcDetailDataSet.RetGdsStcDetailDataTable RetGdsStcDetail, out string errMessage)                      
        {
            // エラーメッセージを初期化する
            errMessage = string.Empty;

            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            書き込みパラメータリスト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 仕入明細追加情報リスト
            //              --SlipDetailAddInfoWork 仕入明細追加情報データオブジェクト
            //------------------------------------------------------------------------------------
            CustomSerializeArrayList dataList = new CustomSerializeArrayList();

            // 仕入明細データオブジェクト
            StockDetailWork stockDetailWork = null;
            // 仕入データオブジェクト
            StockSlipWork stockSlipWork = new StockSlipWork();
            // 仕入明細リスト
            List<StockDetailWork> stockDetailWorkList = null;

            // 仕入明細追加情報リスト
            ArrayList slipDtlAdInfoWorkList = null;

            // 退避用伝票番号
            string retGdsSlipNum = string.Empty;
            string preRetGdsSlipNum = string.Empty;
            // 仕入伝票番号
            Int32 retSuppSlipNo = 0;

            // 仕入先情報取得
            if (this._supplierAcs.Read(out this._supplier, this._enterpriseCode, para.SupplierCode) != 0 ||
                this._supplier == null)
            {
                errMessage = "仕入先マスタの取得に失敗しました。";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            // 税率情報取得
            if (this.TaxRateSetRead(out this._taxRateSet) != 0 ||
                this._taxRateSet == null)
            {
                errMessage = "税率情報マスタの取得に失敗しました。";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else
            {
                //this._taxRate = this.GetTaxRate(this._taxRateSet, DateTime.Now); // DEL 譚洪 2014/01/07 
                this._taxRate = this.GetTaxRate(this._taxRateSet, para.RetGdsDate); // ADD 譚洪 2014/01/07 
            }

            // グリッドの情報をソート
            // 返品伝票番号,倉庫番号,仕入伝票番号,明細行番号
            string sortString = string.Format("{0} ,{1} ,{2} ,{3}",
                _detailDataSet.RedSlipDetail.RetGdsSlipNumColumn.ColumnName,
                _detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName,
                _detailDataSet.RedSlipDetail.SupplierSlipNoColumn.ColumnName,
                _detailDataSet.RedSlipDetail.StockRowNoColumn.ColumnName);
            regGdsDetail.Sort = sortString;

            // 画面上のグリッドの行数分ループ
            foreach (DataRowView rowView in regGdsDetail)
            {
                // 退避用倉庫コード
                Int32 retWarehouseCode = 0;
                string warehouseCode = string.Empty;
                string shelfNo = string.Empty; //ADD 2013/03/01 システム障害No233

                // グリッドの情報から仕入伝票番号を取得する
                retSuppSlipNo = ConvertInt32Column(rowView[_detailDataSet.RedSlipDetail.SupplierSlipNoColumn.ColumnName]);
                if (retSuppSlipNo == 0)
                {
                    // 仕入伝票番号が0の場合
                    errMessage = "仕入伝票番号が0です";
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else
                {
                    // グリッドの情報から返品伝票番号を取得する
                    retGdsSlipNum = ConvertStringColumn(rowView[_detailDataSet.RedSlipDetail.RetGdsSlipNumColumn.ColumnName]);

                    // グリッドの情報から倉庫コードを取得する
                    warehouseCode = ConvertStringColumn(rowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName]);
                    // グリッドの情報から棚番を取得する
                    shelfNo = ConvertStringColumn(rowView[_detailDataSet.RedSlipDetail.ShelfNoColumn.ColumnName]); //ADD 2013/03/01 システム障害No233

                    if (retGdsSlipNum == string.Empty && (!Int32.TryParse(warehouseCode, out retWarehouseCode) || retWarehouseCode == 0))
                    {
                        // 返品伝票番号と倉庫コードのどちらも未入力の場合
                        errMessage = "返品伝票番号と倉庫コードのどちらも未入力です";
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }

                    // 返品伝票番号もしくは倉庫コードが変わった場合
                    if ((retGdsSlipNum != string.Empty && retWarehouseCode == 0 && retGdsSlipNum != preRetGdsSlipNum) ||
                        (preRetGdsSlipNum != string.Empty && retWarehouseCode != 0) ||
                        (retGdsSlipNum == string.Empty && retWarehouseCode != 0))
                    {
                        if (stockSlipWork.SupplierSlipNo != 0)
                        {
                            // 統合リストに仕入データを追加する(仕入返品計上)
                            RedSlipAddUpList(para, preRetGdsSlipNum, stockSlipWork, ref stockDetailWorkList, ref slipDtlAdInfoWorkList, ref dataList);
                        }

                        // 返品伝票番号の更新
                        preRetGdsSlipNum = retGdsSlipNum;

                        // 仕入伝票データを取得する
                        DataRow[] rows = stcList.Select(string.Format("{0} = {1}", stcList.SupplierSlipNoColumn.ColumnName, retSuppSlipNo));
                        DataRow[] retRows = retGdsStcList.Select(string.Format("{0} = {1}", retGdsStcList.SupplierSlipNoColumn.ColumnName, retSuppSlipNo));
                        if (rows.Length > 0 && retRows.Length >0)
                        {
                            // DataRowからワークに変換
                            SlcListFromStockSlipWorkData(para, rows[0], retRows[0], out stockSlipWork);
                        }
                        else
                        {
                            // 仕入伝票を取得できなかった場合
                            errMessage = "仕入伝票データを取得出来ませんでした";
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }

                        // 仕入明細リストの初期化
                        stockDetailWorkList = new List<StockDetailWork>();

                        // 仕入明細追加情報リスト
                        slipDtlAdInfoWorkList = new ArrayList();
                    }
                }

                // 仕入明細データの取得
                int SupplierSlipNo = ConvertInt32Column(rowView[_detailDataSet.RedSlipDetail.SupplierSlipNoColumn.ColumnName]); // 仕入伝票番号
                int StockRowNo = ConvertInt32Column(rowView[_detailDataSet.RedSlipDetail.StockRowNoColumn.ColumnName]); // 仕入行番号
                if (SupplierSlipNo > 0 && StockRowNo > 0)
                {
                    DataRow[] rows = StcDetail.Select(
                        string.Format("{0} = {1} AND {2} = {3}",
                        StcDetail.SupplierSlipNoColumn.ColumnName, SupplierSlipNo,
                        StcDetail.StockRowNoColumn.ColumnName, StockRowNo));
                    // 返品計上用仕入明細データ
                    DataRow[] retRows = RetGdsStcDetail.Select(
                        string.Format("{0} = {1} AND {2} = {3}",
                        RetGdsStcDetail.SupplierSlipNoColumn.ColumnName, SupplierSlipNo,
                        RetGdsStcDetail.StockRowNoColumn.ColumnName, StockRowNo));

                    if (rows.Length > 0 && retRows.Length > 0)
                    {
                        // DataRowからワークに変換
                        RedSlipFromStockDetailWorkData(para, rows[0], retRows[0], out stockDetailWork);

                        // グリッドに入力された返品数を「仕入数」にセットする
                        double returnCount = ConvertDoubleColumn(rowView[_detailDataSet.RedSlipDetail.ReturnCntColumn.ColumnName]);

                        // 画面表示上-1を掛けているため、それを戻す
                        returnCount *= -1.0;
                        stockDetailWork.StockCount = returnCount;

                        // グリッドに入力された倉庫コードを「倉庫コード」にセットする
                        stockDetailWork.WarehouseCode = warehouseCode;
                        // グリッドに表示された棚番をセットする
                        stockDetailWork.WarehouseShelfNo = shelfNo; //ADD 2013/03/01 システム障害No233
         
                        stockDetailWorkList.Add(stockDetailWork);

                        // 仕入明細データオブジェクト(仕入返品計上)に追加する
                        slipDtlAdInfoWorkList.Add(new SlipDetailAddInfoWork());
                    }
                    else
                    {
                        // 仕入明細を取得できなかった場合
                        errMessage = "仕入明細データを取得出来ませんでした";
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }

            // 最後のデータ登録
            RedSlipAddUpList(para, preRetGdsSlipNum, stockSlipWork, ref stockDetailWorkList, ref slipDtlAdInfoWorkList, ref dataList);

            object dataObj = (object)dataList;

            // 仕入返品予定データ計上処理(PMKAK01100A)
            int status = _stockSlipRetPlnAcs.AddUpStockSlipRetPln((object)dataObj, out errMessage);

            return status;
        }

        /// <summary>
        /// 統合リストに仕入データを追加する(仕入返品計上)
        /// </summary>
        /// <param name="para">返品計上用パラメータ</param>
        /// <param name="GdsSlipNum">伝票番号</param>
        /// <param name="stockSlipWork">仕入データオブジェクト</param>
        /// <param name="redStockDetailList">仕入明細データオブジェクトリスト</param>
        /// <param name="slipDtlAdInfoWorkList">仕入明細リスト</param>
        /// <param name="dataList">仕入リスト</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private void RedSlipAddUpList(RetGdsAddUpWriteParameter para, string GdsSlipNum, StockSlipWork stockSlipWork, ref List<StockDetailWork> redStockDetailList, ref ArrayList slipDtlAdInfoWorkList, ref CustomSerializeArrayList dataList)
        {
            if (redStockDetailList.Count <= 0)
            {
                // 明細データが無い場合はリストに追加しない
                return;
            }

            // 仕入返品処理パラメータの作成
            StockSlipLogicalKey key = new StockSlipLogicalKey();
            key.EnterpriseCode = para.EnterpriseCode;
            key.SectionCode = para.SectionCode;
            key.SupplierCd = para.SupplierCode;
            key.StockDate = para.RetGdsDate;
            key.PartySaleSlipNum = GdsSlipNum;
            RedSlipWriteParameter parameter = new RedSlipWriteParameter();
            parameter.SectionCode = para.SectionCode;
            parameter.SlipCd = para.SlipCd;
            parameter.SalesDate = DateTime.MinValue;
            parameter.InputEmployeeCd = para.StockAgentCd;
            parameter.InputEmployeeNm = para.StockAgentNm;
            parameter.ReturnReason = para.ReturnReason;
            parameter.FeePriceOfTotal = para.FeePriceOfTotal;
            parameter.EnterpriseCode = this._enterpriseCode;
            parameter.RetGoodsReasonDiv = para.RetGoodsReasonDiv;
            parameter.SlipNote = para.SlipNote;
            parameter.SlipNote2 = para.SlipNote2;

            // 仕入返品データの取得
            CreateRedStockSlip(key, ref stockSlipWork, ref redStockDetailList, parameter, para.RetGdsDate);

            // --- ADD 譚洪 2014/01/07 ------------ >>>>>>
            // 消費税転嫁方式編集判断メソッドの返値がtrueの場合、
            if (CheckConsTaxLayMethod(stockSlipWork))
            {
                // 仕入データ(StockSlipRf).仕入先消費税転嫁方式(SuppCTaxLayCdRF)＝０：伝票単位
                stockSlipWork.SuppCTaxLayCd = 0;
            }
            // --- ADD 譚洪 2014/01/07 ------------ <<<<<<

            if (GdsSlipNum != string.Empty && parameter.FeePriceOfTotal != 0)
            {
                // 手数料明細追加処理
                AddFeeDetail(ref redStockDetailList, ref stockSlipWork, parameter);

                // 仕入明細データオブジェクト(仕入返品計上)に追加する
                slipDtlAdInfoWorkList.Add(new SlipDetailAddInfoWork());
            }

            #region [伝票金額算出]
            // 手数料明細が追加される可能性があるため、このタイミングで伝票金額算出を行う

            // 仕入先マスタから消費税端数処理情報を取得
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlipWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            this.GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // MAKON01112Aの共通クラス使用
            StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, redStockDetailList, fracProcUnit, fracProcCd);
            #endregion

            // 仕入明細リストのデータ変換
            ArrayList detailList = new ArrayList();
            detailList.AddRange(redStockDetailList.ToArray());

            // 統合リストに仕入データを追加する(仕入返品計上)
            CustomSerializeArrayList stockSlipDataList = new CustomSerializeArrayList();
            stockSlipDataList.Add(stockSlipWork);
            stockSlipDataList.Add(detailList);
            stockSlipDataList.Add(slipDtlAdInfoWorkList);
            dataList.Add(stockSlipDataList);
        }

        // --- ADD 譚洪 2014/01/07 ---------->>>>>
        /// <summary>
        /// 消費税転嫁方式編集判断メソッド
        /// </summary>
        /// <param name="stockSlip">仕入データ</param>
        /// <remarks>
        /// <br>Note       : 消費税転嫁方式編集判断を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/01/07</br>
        /// </remarks>
        /// <returns>true:存在する false:存在しない</returns>
        private bool CheckConsTaxLayMethod(StockSlipWork stockSlipWork)
        {
            bool consTaxLayMethodFlg = false;

            // ①元黒の消費税転嫁方式が、請求親又は請求子の場合、
            if (stockSlipWork.SuppCTaxLayCd == 2 || stockSlipWork.SuppCTaxLayCd == 3)
            {
                // ②税率設定が２件以上ある場合、
                if (this._taxRateSet.TaxRateStartDate2 != DateTime.MinValue
                    || this._taxRateSet.TaxRateStartDate3 != DateTime.MinValue)
                {
                    // ③元黒売上日付と赤伝売上日付で、税率が違う場合、
                    if (stockSlipWork.SupplierConsTaxRate != this._taxRate)
                    {
                        consTaxLayMethodFlg = true;
                    }
                }
            }

            return consTaxLayMethodFlg;
        }
        // --- ADD 譚洪 2014/01/07 ----------<<<<<

        /// <summary>
        /// 仕入金額処理区分設定リスト取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private void GetStockProcMonyList()
        {
            ArrayList al = null;
            int status = this._stockProcMoneyAcs.Search(out al, _enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (al != null)
                {
                    this._stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])al.ToArray(typeof(StockProcMoney)));
                }
            }
            return;
        }

        /// <summary>
        /// StcListとRetGdsStcList→stockSlipWork移項処理
        /// </summary>
        /// <param name="para">返品計上用パラメータ</param>
        /// <param name="listRowView">仕入データオブジェクト</param>
        /// <param name="retListRow">仕入データオブジェクト(返品計上使用分)</param>
        /// <returns>仕入データワークオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        public void SlcListFromStockSlipWorkData(RetGdsAddUpWriteParameter para, DataRow listRowView, DataRow retListRow, out StockSlipWork stockSlipWork)
        {
            stockSlipWork = new StockSlipWork();

            stockSlipWork.EnterpriseCode = para.EnterpriseCode; // 企業コード	
            stockSlipWork.SupplierFormal = ConvertInt32Column(listRowView[_detailDataSet.StcList.SupplierFormalColumn.ColumnName]); // 仕入形式	
            stockSlipWork.SupplierSlipNo = ConvertInt32Column(listRowView[_detailDataSet.StcList.SupplierSlipNoColumn.ColumnName]); // 仕入伝票番号	
            stockSlipWork.SectionCode = ConvertStringColumn(listRowView[_detailDataSet.StcList.SectionCdColumn.ColumnName]); // 拠点コード
            stockSlipWork.DebitNoteDiv = ConvertInt32Column(listRowView[_detailDataSet.StcList.DebitNoteDivColumn.ColumnName]); // 赤伝区分	
            stockSlipWork.SupplierSlipCd = ConvertInt32Column(listRowView[_detailDataSet.StcList.SupplierSlipCdColumn.ColumnName]); // 仕入伝票区分	
            stockSlipWork.AccPayDivCd = ConvertInt32Column(listRowView[_detailDataSet.StcList.AccPayDivCdColumn.ColumnName]); // 買掛区分	
            stockSlipWork.StockDate = ConvertDateTimeColumn(listRowView[_detailDataSet.StcList.StockDateColumn.ColumnName]); // 仕入日	
            stockSlipWork.StockAddUpADate = ConvertDateTimeColumn(listRowView[_detailDataSet.StcList.StockAddUpADateColumn.ColumnName]); // 仕入計上日付	
            stockSlipWork.SupplierCd = ConvertInt32Column(listRowView[_detailDataSet.StcList.SupplierCdColumn.ColumnName]); // 仕入先コード	
            stockSlipWork.SupplierSnm = ConvertStringColumn(listRowView[_detailDataSet.StcList.SupplierSnmColumn.ColumnName]); // 仕入先略称	
            stockSlipWork.StockInputName = ConvertStringColumn(listRowView[_detailDataSet.StcList.StockInputNameColumn.ColumnName]); // 仕入入力者名称	
            stockSlipWork.StockAgentName = ConvertStringColumn(listRowView[_detailDataSet.StcList.StockAgentNameColumn.ColumnName]); // 仕入担当者名称	
            stockSlipWork.StockTtlPricTaxExc = ConvertInt64Column(listRowView[_detailDataSet.StcList.StockTtlPricTaxExcColumn.ColumnName]); // 仕入金額計（税抜き）	
            stockSlipWork.StockPriceConsTax = ConvertInt64Column(listRowView[_detailDataSet.StcList.StockPriceConsTaxColumn.ColumnName]); // 仕入金額消費税額	
            stockSlipWork.PartySaleSlipNum = ConvertStringColumn(listRowView[_detailDataSet.StcList.PartySaleSlipNumColumn.ColumnName]); // 相手先伝票番号	
            stockSlipWork.SupplierSlipNote1 = ConvertStringColumn(listRowView[_detailDataSet.StcList.SupplierSlipNote1Column.ColumnName]); // 仕入伝票備考1	
            stockSlipWork.SupplierSlipNote2 = ConvertStringColumn(listRowView[_detailDataSet.StcList.SupplierSlipNote2Column.ColumnName]); // 仕入伝票備考2	
            stockSlipWork.UoeRemark1 = ConvertStringColumn(listRowView[_detailDataSet.StcList.UoeRemark1Column.ColumnName]); // ＵＯＥリマーク１	
            stockSlipWork.UoeRemark2 = ConvertStringColumn(listRowView[_detailDataSet.StcList.UoeRemark2Column.ColumnName]); // ＵＯＥリマーク２	

            // 別データセットから取得
            stockSlipWork.LogicalDeleteCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.LogicalDeleteCdColumn.ColumnName]); // 論理削除区分
            stockSlipWork.SubSectionCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SubSectionCodeColumn.ColumnName]); // 部門コード
            stockSlipWork.DebitNLnkSuppSlipNo = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.DebitNLnkSuppSlipNoColumn.ColumnName]); // 赤黒連結仕入伝票番号
            stockSlipWork.StockGoodsCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.StockGoodsCdColumn.ColumnName]); // 仕入商品区分	
            stockSlipWork.StockSectionCd = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.StockSectionCdColumn.ColumnName]); // 仕入拠点コード	
            stockSlipWork.StockAddUpSectionCd = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.StockAddUpSectionCdColumn.ColumnName]); // 仕入計上拠点コード	
            stockSlipWork.StockSlipUpdateCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.StockSlipUpdateCdColumn.ColumnName]); // 仕入伝票更新区分
            stockSlipWork.InputDay = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.InputDayColumn.ColumnName]); // 入力日
            stockSlipWork.ArrivalGoodsDay = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.ArrivalGoodsDayColumn.ColumnName]); // 入荷日
            stockSlipWork.DelayPaymentDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.DelayPaymentDivColumn.ColumnName]); // 来勘区分
            stockSlipWork.PayeeCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.PayeeCodeColumn.ColumnName]); // 支払先コード
            stockSlipWork.PayeeSnm = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.PayeeSnmColumn.ColumnName]); // 支払先略称
            stockSlipWork.SupplierNm1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.SupplierNm1Column.ColumnName]); // 仕入先名1
            stockSlipWork.SupplierNm2 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.SupplierNm2Column.ColumnName]); // 仕入先名2
            stockSlipWork.BusinessTypeCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.BusinessTypeCodeColumn.ColumnName]); // 業種コード
            stockSlipWork.BusinessTypeName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.BusinessTypeNameColumn.ColumnName]); // 業種名称
            stockSlipWork.SalesAreaCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SalesAreaCodeColumn.ColumnName]); // 販売エリアコード
            stockSlipWork.SalesAreaName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.SalesAreaNameColumn.ColumnName]); // 販売エリア名称
            stockSlipWork.StockInputCode = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.StockInputCodeColumn.ColumnName]); // 仕入入力者コード
            stockSlipWork.StockAgentCode = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.StockAgentCodeColumn.ColumnName]); // 仕入担当者コード
            stockSlipWork.SuppTtlAmntDspWayCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SuppTtlAmntDspWayCdColumn.ColumnName]); // 仕入先総額表示方法区分	
            stockSlipWork.TtlAmntDispRateApy = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.TtlAmntDispRateApyColumn.ColumnName]); // 総額表示掛率適用区分	
            stockSlipWork.StockTotalPrice = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockTotalPriceColumn.ColumnName]); // 仕入金額合計	
            stockSlipWork.StockSubttlPrice = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockSubttlPriceColumn.ColumnName]); // 仕入金額小計	
            stockSlipWork.StockTtlPricTaxInc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockTtlPricTaxIncColumn.ColumnName]); // 仕入金額計（税込み）	
            stockSlipWork.StockNetPrice = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockNetPriceColumn.ColumnName]); // 仕入正価金額
            stockSlipWork.TtlItdedStcOutTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.TtlItdedStcOutTaxColumn.ColumnName]); // 仕入外税対象額合計	
            stockSlipWork.TtlItdedStcInTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.TtlItdedStcInTaxColumn.ColumnName]); // 仕入内税対象額合計	
            stockSlipWork.TtlItdedStcTaxFree = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.TtlItdedStcTaxFreeColumn.ColumnName]); // 仕入非課税対象額合計	
            stockSlipWork.StockOutTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockOutTaxColumn.ColumnName]); // 仕入金額消費税額（外税）	
            stockSlipWork.StckPrcConsTaxInclu = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StckPrcConsTaxIncluColumn.ColumnName]); // 仕入金額消費税額（内税）	
            stockSlipWork.StckDisTtlTaxExc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StckDisTtlTaxExcColumn.ColumnName]); // 仕入値引金額計（税抜き）	
            stockSlipWork.ItdedStockDisOutTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.ItdedStockDisOutTaxColumn.ColumnName]); // 仕入値引外税対象額合計	
            stockSlipWork.ItdedStockDisInTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.ItdedStockDisInTaxColumn.ColumnName]); // 仕入値引内税対象額合計	
            stockSlipWork.ItdedStockDisTaxFre = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.ItdedStockDisTaxFreColumn.ColumnName]); // 仕入値引非課税対象額合計	
            stockSlipWork.StockDisOutTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockDisOutTaxColumn.ColumnName]); // 仕入値引消費税額（外税）	
            stockSlipWork.StckDisTtlTaxInclu = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StckDisTtlTaxIncluColumn.ColumnName]); // 仕入値引消費税額（内税）	
            stockSlipWork.TaxAdjust = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.TaxAdjustColumn.ColumnName]); // 消費税調整額	
            stockSlipWork.BalanceAdjust = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.BalanceAdjustColumn.ColumnName]); // 残高調整額	
            stockSlipWork.SuppCTaxLayCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SuppCTaxLayCdColumn.ColumnName]); // 仕入先消費税転嫁方式コード	
            stockSlipWork.SupplierConsTaxRate = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcList.SupplierConsTaxRateColumn.ColumnName]); // 仕入先消費税税率	
            stockSlipWork.AccPayConsTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.AccPayConsTaxColumn.ColumnName]); // 買掛消費税	
            stockSlipWork.StockFractionProcCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.StockFractionProcCdColumn.ColumnName]); // 仕入端数処理区分	
            stockSlipWork.AutoPayment = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.AutoPaymentColumn.ColumnName]); // 自動支払区分	
            stockSlipWork.AutoPaySlipNum = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.AutoPaySlipNumColumn.ColumnName]); // 自動支払伝票番号	
            stockSlipWork.DetailRowCount = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.DetailRowCountColumn.ColumnName]); // 明細行数	
            stockSlipWork.EdiSendDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.EdiSendDateColumn.ColumnName]); // ＥＤＩ送信日	
            stockSlipWork.EdiTakeInDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.EdiTakeInDateColumn.ColumnName]); // ＥＤＩ取込日	
            stockSlipWork.SlipPrintDivCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SlipPrintDivCdColumn.ColumnName]); // 伝票発行区分	
            stockSlipWork.SlipPrintFinishCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SlipPrintFinishCdColumn.ColumnName]); // 伝票発行済区分	
            stockSlipWork.StockSlipPrintDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.StockSlipPrintDateColumn.ColumnName]); // 仕入伝票発行日	
            stockSlipWork.SlipPrtSetPaperId = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.SlipPrtSetPaperIdColumn.ColumnName]); // 伝票印刷設定用帳票ID	
            stockSlipWork.SlipAddressDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SlipAddressDivColumn.ColumnName]); // 伝票住所区分	
            stockSlipWork.AddresseeCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.AddresseeCodeColumn.ColumnName]); // 納品先コード	
            stockSlipWork.AddresseeName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeNameColumn.ColumnName]); // 納品先名称	
            stockSlipWork.AddresseeName2 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeName2Column.ColumnName]); // 納品先名称2	
            stockSlipWork.AddresseePostNo = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseePostNoColumn.ColumnName]); // 納品先郵便番号	
            stockSlipWork.AddresseeAddr1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeAddr1Column.ColumnName]); // 納品先住所1(都道府県市区郡・町村・字)	
            stockSlipWork.AddresseeAddr3 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeAddr3Column.ColumnName]); // 納品先住所3(番地)	
            stockSlipWork.AddresseeAddr4 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeAddr4Column.ColumnName]); // 納品先住所4(アパート名称)	
            stockSlipWork.AddresseeTelNo = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeTelNoColumn.ColumnName]); // 納品先電話番号	
            stockSlipWork.AddresseeFaxNo = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeFaxNoColumn.ColumnName]); // 納品先FAX番号	
            stockSlipWork.DirectSendingCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.DirectSendingCdColumn.ColumnName]); // 直送区分

        }

        /// <summary>
        /// StcDetailとRetGdsStcDetail→stockDetailWork移項処理
        /// </summary>
        /// <param name="para">返品計上用パラメータ</param>
        /// <param name="listRow">仕入データオブジェクト</param>
        /// <param name="retListRow">仕入データオブジェクト(返品計上使用分)</param>
        /// <returns>仕入明細データオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/25</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        public void RedSlipFromStockDetailWorkData(RetGdsAddUpWriteParameter para, DataRow listRow, DataRow retListRow, out StockDetailWork stockDetailWork)
        {
            stockDetailWork = new StockDetailWork();

            stockDetailWork.EnterpriseCode = para.EnterpriseCode;                                                                               // 企業コード
            stockDetailWork.StockRowNo = ConvertInt32Column(listRow[_detailDataSet.StcDetail.StockRowNoColumn.ColumnName]); // 行No
            stockDetailWork.SupplierFormal = ConvertInt32Column(listRow[_detailDataSet.StcDetail.SupplierFormalColumn.ColumnName]); // 仕入形式
            stockDetailWork.StockSlipCdDtl = ConvertInt32Column(listRow[_detailDataSet.StcDetail.StockSlipCdDtlColumn.ColumnName]); // 明細区分
            stockDetailWork.StockAgentName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.StockAgentNameColumn.ColumnName]); // 担当者名
            stockDetailWork.GoodsName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.GoodsNameColumn.ColumnName]); // 品名
            stockDetailWork.GoodsNo = ConvertStringColumn(listRow[_detailDataSet.StcDetail.GoodsNoColumn.ColumnName]); // 品番
            stockDetailWork.GoodsMakerCd = ConvertInt32Column(listRow[_detailDataSet.StcDetail.GoodsMakerCdColumn.ColumnName]); // メーカーコード
            stockDetailWork.MakerName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.MakerNameColumn.ColumnName]); // メーカー名称
            stockDetailWork.BLGoodsCode = ConvertInt32Column(listRow[_detailDataSet.StcDetail.BLGoodsCodeColumn.ColumnName]); // BLコード
            stockDetailWork.BLGroupCode = ConvertInt32Column(listRow[_detailDataSet.StcDetail.BLGroupCodeColumn.ColumnName]); // BLグループ
            stockDetailWork.StockUnitPriceFl = ConvertDoubleColumn(listRow[_detailDataSet.StcDetail.StockUnitPriceFlColumn.ColumnName]); // 原単価
            stockDetailWork.ListPriceTaxExcFl = ConvertDoubleColumn(listRow[_detailDataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName]); // 標準価格
            stockDetailWork.OpenPriceDiv = ConvertInt32Column(listRow[_detailDataSet.StcDetail.OpenPriceDivColumn.ColumnName]); // オープン価格区分
            // 返品データ扱いとするのでマイナスにする
            stockDetailWork.StockPriceConsTax = -1 * ConvertInt64Column(listRow[_detailDataSet.StcDetail.StockPriceConsTaxColumn.ColumnName]); // 仕入金額消費税額
            stockDetailWork.StockInputName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.StockInputNameColumn.ColumnName]); // 発行者
            stockDetailWork.SupplierCd = ConvertInt32Column(listRow[_detailDataSet.StcDetail.SupplierCdColumn.ColumnName]); // 仕入先コード
            stockDetailWork.SupplierSnm = ConvertStringColumn(listRow[_detailDataSet.StcDetail.SupplierSnmColumn.ColumnName]); // 仕入先名
            stockDetailWork.StockOrderDivCd = ConvertInt32Column(listRow[_detailDataSet.StcDetail.StockOrderDivCdColumn.ColumnName]); // 在取
            stockDetailWork.WarehouseCode = ConvertStringColumn(listRow[_detailDataSet.StcDetail.WarehouseCdColumn.ColumnName]); // 倉庫コード
            stockDetailWork.WarehouseName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.WarehouseNameColumn.ColumnName]); // 倉庫
            stockDetailWork.WarehouseShelfNo = ConvertStringColumn(listRow[_detailDataSet.StcDetail.WarehouseShelfNoColumn.ColumnName]); // 棚番
            stockDetailWork.SupplierSlipNo = ConvertInt32Column(listRow[_detailDataSet.StcDetail.SupplierSlipNoColumn.ColumnName]); // 仕入SEQ/支払No
            stockDetailWork.BfStockUnitPriceFl = ConvertDoubleColumn(listRow[_detailDataSet.StcDetail.BfStockUnitPriceFlColumn.ColumnName]); // 変更前仕入単価（浮動）
            stockDetailWork.BfListPrice = ConvertDoubleColumn(listRow[_detailDataSet.StcDetail.BfListPriceColumn.ColumnName]); // 変更前定価
            stockDetailWork.LogicalDeleteCode = ConvertInt32Column(listRow[_detailDataSet.StcDetail.LogicalDeleteCodeColumn.ColumnName]); // 論理削除区分

            // 別データセットから取得
            stockDetailWork.AcceptAnOrderNo = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.AcceptAnOrderNoColumn.ColumnName]); // 受注番号
            stockDetailWork.CommonSeqNo = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.CommonSeqNoColumn.ColumnName]); // 共通通番
            stockDetailWork.StockSlipDtlNum = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.StockSlipDtlNumColumn.ColumnName]); // 仕入明細通番
            stockDetailWork.SupplierFormalSrc = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.SupplierFormalSrcColumn.ColumnName]); // 仕入形式（元）
            stockDetailWork.StockSlipDtlNumSrc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.StockSlipDtlNumSrcColumn.ColumnName]); // 仕入明細通番（元）
            stockDetailWork.AcptAnOdrStatusSync = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.AcptAnOdrStatusSyncColumn.ColumnName]); // 受注ステータス（同時）
            stockDetailWork.SalesSlipDtlNumSync = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.SalesSlipDtlNumSyncColumn.ColumnName]); // 売上明細通番（同時）
            stockDetailWork.SubSectionCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.SubSectionCodeColumn.ColumnName]); // 部門コード
            stockDetailWork.StockInputCode = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockInputCodeColumn.ColumnName]); // 仕入入力者コード
            stockDetailWork.StockAgentCode = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockAgentCodeColumn.ColumnName]); // 仕入担当者コード
            stockDetailWork.GoodsKindCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.GoodsKindCodeColumn.ColumnName]); // 商品属性
            stockDetailWork.MakerKanaName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.MakerKanaNameColumn.ColumnName]); // メーカーカナ名称
            stockDetailWork.CmpltMakerKanaName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.CmpltMakerKanaNameColumn.ColumnName]); // メーカーカナ名称（一式）
            stockDetailWork.GoodsNameKana = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.GoodsNameKanaColumn.ColumnName]); // 商品名称カナ
            stockDetailWork.GoodsLGroup = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.GoodsLGroupColumn.ColumnName]); // 商品大分類コード
            stockDetailWork.GoodsLGroupName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.GoodsLGroupNameColumn.ColumnName]); // 商品大分類名称
            stockDetailWork.GoodsMGroup = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.GoodsMGroupColumn.ColumnName]); // 商品中分類コード
            stockDetailWork.GoodsMGroupName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.GoodsMGroupNameColumn.ColumnName]); // 商品中分類名称
            stockDetailWork.BLGroupName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.BLGroupNameColumn.ColumnName]); // BLグループコード名称
            stockDetailWork.BLGoodsFullName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.BLGoodsFullNameColumn.ColumnName]); // BL商品コード名称（全角）
            stockDetailWork.EnterpriseGanreCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.EnterpriseGanreCodeColumn.ColumnName]); // 自社分類コード
            stockDetailWork.EnterpriseGanreName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.EnterpriseGanreNameColumn.ColumnName]); // 自社分類名称
            stockDetailWork.GoodsRateRank = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.GoodsRateRankColumn.ColumnName]); // 商品掛率ランク
            stockDetailWork.CustRateGrpCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.CustRateGrpCodeColumn.ColumnName]); // 得意先掛率グループコード
            stockDetailWork.SuppRateGrpCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.SuppRateGrpCodeColumn.ColumnName]); // 仕入先掛率グループコード
            stockDetailWork.ListPriceTaxIncFl = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.ListPriceTaxIncFlColumn.ColumnName]); // 定価（税込，浮動）
            stockDetailWork.StockRate = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockRateColumn.ColumnName]); // 仕入率
            stockDetailWork.RateSectStckUnPrc = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateSectStckUnPrcColumn.ColumnName]); // 掛率設定拠点（仕入単価）
            stockDetailWork.RateDivStckUnPrc = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateDivStckUnPrcColumn.ColumnName]); // 掛率設定区分（仕入単価）
            stockDetailWork.UnPrcCalcCdStckUnPrc = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.UnPrcCalcCdStckUnPrcColumn.ColumnName]); // 単価算出区分（仕入単価）
            stockDetailWork.PriceCdStckUnPrc = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.PriceCdStckUnPrcColumn.ColumnName]); // 価格区分（仕入単価）
            stockDetailWork.StdUnPrcStckUnPrc = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.StdUnPrcStckUnPrcColumn.ColumnName]); // 基準単価（仕入単価）
            stockDetailWork.FracProcUnitStcUnPrc = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.FracProcUnitStcUnPrcColumn.ColumnName]); // 端数処理単位（仕入単価）
            stockDetailWork.FracProcStckUnPrc = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.FracProcStckUnPrcColumn.ColumnName]); // 端数処理（仕入単価）
            stockDetailWork.StockUnitTaxPriceFl = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockUnitTaxPriceFlColumn.ColumnName]); // 仕入単価（税込，浮動）
            stockDetailWork.StockUnitChngDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.StockUnitChngDivColumn.ColumnName]); // 仕入単価変更区分
            stockDetailWork.RateBLGoodsCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.RateBLGoodsCodeColumn.ColumnName]); // BL商品コード（掛率）
            stockDetailWork.RateBLGoodsName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateBLGoodsNameColumn.ColumnName]); // BL商品コード名称（掛率）
            stockDetailWork.RateGoodsRateGrpCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.RateGoodsRateGrpCdColumn.ColumnName]); // 商品掛率グループコード（掛率）
            stockDetailWork.RateGoodsRateGrpNm = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateGoodsRateGrpNmColumn.ColumnName]); // 商品掛率グループ名称（掛率）
            stockDetailWork.RateBLGroupCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.RateBLGroupCodeColumn.ColumnName]); // BLグループコード（掛率）
            stockDetailWork.RateBLGroupName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateBLGroupNameColumn.ColumnName]); // BLグループ名称（掛率）
            stockDetailWork.OrderCnt = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderCntColumn.ColumnName]); // 発注数量
            stockDetailWork.OrderAdjustCnt = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderAdjustCntColumn.ColumnName]); // 発注調整数
            stockDetailWork.OrderRemainCnt = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderRemainCntColumn.ColumnName]); // 発注残数
            stockDetailWork.RemainCntUpdDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcDetail.RemainCntUpdDateColumn.ColumnName]); // 残数更新日
            stockDetailWork.StockPriceTaxExc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.StockPriceTaxExcColumn.ColumnName]); // 仕入金額（税抜き）
            stockDetailWork.StockPriceTaxInc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.StockPriceTaxIncColumn.ColumnName]); // 仕入金額（税込み）
            stockDetailWork.StockGoodsCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.StockGoodsCdColumn.ColumnName]); // 仕入商品区分
            stockDetailWork.TaxationCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.TaxationCodeColumn.ColumnName]); // 課税区分
            stockDetailWork.StockDtiSlipNote1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockDtiSlipNote1Column.ColumnName]); // 仕入伝票明細備考1
            stockDetailWork.SalesCustomerCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.SalesCustomerCodeColumn.ColumnName]); // 販売先コード
            stockDetailWork.SalesCustomerSnm = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.SalesCustomerSnmColumn.ColumnName]); // 販売先略称
            stockDetailWork.SlipMemo1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.SlipMemo1Column.ColumnName]); // 伝票メモ１
            stockDetailWork.SlipMemo2 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.SlipMemo2Column.ColumnName]); // 伝票メモ２
            stockDetailWork.SlipMemo3 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.SlipMemo3Column.ColumnName]); // 伝票メモ３
            stockDetailWork.InsideMemo1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.InsideMemo1Column.ColumnName]); // 社内メモ１
            stockDetailWork.InsideMemo2 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.InsideMemo2Column.ColumnName]); // 社内メモ２
            stockDetailWork.InsideMemo3 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.InsideMemo3Column.ColumnName]); // 社内メモ３
            stockDetailWork.AddresseeCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.AddresseeCodeColumn.ColumnName]); // 納品先コード
            stockDetailWork.AddresseeName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.AddresseeNameColumn.ColumnName]); // 納品先名称
            stockDetailWork.DirectSendingCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.DirectSendingCdColumn.ColumnName]); // 直送区分
            stockDetailWork.OrderNumber = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderNumberColumn.ColumnName]); // 発注番号
            stockDetailWork.WayToOrder = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.WayToOrderColumn.ColumnName]); // 注文方法
            stockDetailWork.DeliGdsCmpltDueDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcDetail.DeliGdsCmpltDueDateColumn.ColumnName]); // 納品完了予定日
            stockDetailWork.ExpectDeliveryDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcDetail.ExpectDeliveryDateColumn.ColumnName]); // 希望納期
            stockDetailWork.OrderDataCreateDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.OrderDataCreateDivColumn.ColumnName]); // 発注データ作成区分
            stockDetailWork.OrderDataCreateDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderDataCreateDateColumn.ColumnName]); // 発注データ作成日
            stockDetailWork.OrderFormIssuedDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.OrderFormIssuedDivColumn.ColumnName]); // 発注書発行済区分

            if (listRow[_detailDataSet.StcDetail.GoodsMakerCdColumn.ColumnName] != DBNull.Value &&
                (string)listRow[_detailDataSet.StcDetail.GoodsMakerCdColumn.ColumnName] != string.Empty)
            {
                stockDetailWork.GoodsMakerCd = Int32.Parse((string)listRow[_detailDataSet.StcDetail.GoodsMakerCdColumn.ColumnName]);        // 商品メーカーコード
            }
            if(listRow[_detailDataSet.StcDetail.BLGroupCodeColumn.ColumnName] != DBNull.Value &&
               (string)listRow[_detailDataSet.StcDetail.BLGroupCodeColumn.ColumnName] != string.Empty)
            {
                stockDetailWork.BLGroupCode = Int32.Parse((string)listRow[_detailDataSet.StcDetail.BLGroupCodeColumn.ColumnName]);          // BLグループコード 
            }
            if(listRow[_detailDataSet.StcDetail.BLGoodsCodeColumn.ColumnName] != DBNull.Value &&
               (string)listRow[_detailDataSet.StcDetail.BLGoodsCodeColumn.ColumnName] != string.Empty)
            {
                stockDetailWork.BLGoodsCode = Int32.Parse((string)listRow[_detailDataSet.StcDetail.BLGoodsCodeColumn.ColumnName]);          // BL商品コード
            }

        }

        #region ■データコンバート用
        private String ConvertStringColumn(object column)
        {
            return (column is String) ? column as String : String.Empty;
        }
        private Int32 ConvertInt32Column(object column)
        {
            return (column is Int32) ? (Int32)column : 0;
        }
        private Int64 ConvertInt64Column(object column)
        {
            return (column is Int64) ? (Int64)column : 0;
        }
        private Double ConvertDoubleColumn(object column)
        {
            return (column is Double) ? (Double)column : 0;
        }
        private DateTime ConvertDateTimeColumn(object column)
        {
            return (column is DateTime) ? (DateTime)column : DateTime.MinValue;
        }
        #endregion ■データコンバート用

        #region ■PMKAU04003AB.csからのコピー

        /// <summary>
        /// 登録用仕入返品伝票生成（追加用）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="redStockSlip">仕入データオブジェクト</param>
        /// <param name="redStockDetailList">仕入明細データオブジェクトリスト</param>
        /// <param name="parameter">赤伝登録パラメータ</param>
        /// <param name="stockDateForUpdate">更新日付</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private void CreateRedStockSlip(StockSlipLogicalKey key, ref StockSlipWork redStockSlip, ref List<StockDetailWork> redStockDetailList, RedSlipWriteParameter parameter, DateTime stockDateForUpdate)
        {
            //--------------------------------------------------------------------
            // ※売上データ読み込み時に同時に取得した、
            // 　同時入力仕入データを元にして、新たに追加用レコードを生成します。
            //--------------------------------------------------------------------
            int supplierSlipCd; // 10:仕入,20:返品
            int stockSlipCdDtl; // 0:仕入,1:返品,2:値引

            if (parameter.SlipCd == 10)
            {
                supplierSlipCd = 10; // 10:仕入
                stockSlipCdDtl = 0;  // 0:仕入
            }
            else
            {
                supplierSlipCd = 20; // 20:返品
                stockSlipCdDtl = 1;  // 1:返品
            }

            DateTime inputDay = parameter.SalesDate;
            DateTime stockDate = key.StockDate;
            string stockInputCode = parameter.InputEmployeeCd;
            string stockInputName = parameter.InputEmployeeNm;
            int retGoodsReasonDiv = parameter.RetGoodsReasonDiv;
            string retGoodsReason = parameter.ReturnReason;
            string partySaleSlipNum = key.PartySaleSlipNum;

            # region [伝票]
            redStockSlip.CreateDateTime = DateTime.MinValue; // 作成日時
            redStockSlip.UpdateDateTime = DateTime.MinValue; // 更新日時
            redStockSlip.EnterpriseCode = this._enterpriseCode; // 企業コード
            redStockSlip.FileHeaderGuid = Guid.Empty; // GUID
            redStockSlip.UpdEmployeeCode = string.Empty; // 更新従業員コード
            redStockSlip.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
            redStockSlip.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
            redStockSlip.LogicalDeleteCode = 0; // 論理削除区分
            redStockSlip.SectionCode = this._loginSectionCode; // 拠点コードはログイン拠点を入れる
            redStockSlip.DebitNoteDiv = 0; // 赤伝区分
            redStockSlip.DebitNLnkSuppSlipNo = 0; // 赤黒連結仕入伝票番号
            redStockSlip.SupplierSlipCd = supplierSlipCd; // 仕入伝票区分
            redStockSlip.StockSlipUpdateCd = 0; // 仕入伝票更新区分
            redStockSlip.InputDay = inputDay; // 入力日
            redStockSlip.ArrivalGoodsDay = stockDate; // 入荷日
            if (stockDateForUpdate != null && stockDateForUpdate != DateTime.MinValue)
            {
                redStockSlip.StockDate = stockDateForUpdate; // 仕入日 グリッド上で入力された仕入日
            }
            else
            {
                redStockSlip.StockDate = stockDate; // 仕入日
            }
            redStockSlip.StockAddUpADate = stockDate; // 仕入計上日付
            redStockSlip.DelayPaymentDiv = 0; // 来勘区分
            redStockSlip.StockInputCode = stockInputCode; // 仕入入力者コード
            redStockSlip.StockInputName = stockInputName; // 仕入入力者名称
            redStockSlip.StockAgentCode = stockInputCode; // 仕入担当者コード
            redStockSlip.StockAgentName = stockInputName; // 仕入担当者名称
            redStockSlip.RetGoodsReasonDiv = retGoodsReasonDiv; // 返品理由コード
            redStockSlip.RetGoodsReason = retGoodsReason; // 返品理由
            redStockSlip.PartySaleSlipNum = partySaleSlipNum; // 相手先伝票番号
            redStockSlip.SupplierSlipNote1 = parameter.SlipNote; // 仕入伝票備考1
            redStockSlip.SupplierSlipNote2 = parameter.SlipNote2; // 仕入伝票備考2
            redStockSlip.DetailRowCount = redStockDetailList.Count; // 明細行数
            redStockSlip.EdiSendDate = DateTime.MinValue; // ＥＤＩ送信日
            redStockSlip.EdiTakeInDate = DateTime.MinValue; // ＥＤＩ取込日
            redStockSlip.UoeRemark1 = string.Empty; // ＵＯＥリマーク１
            redStockSlip.UoeRemark2 = string.Empty; // ＵＯＥリマーク２
            redStockSlip.SlipPrintDivCd = 0; // 伝票発行区分
            redStockSlip.SlipPrintFinishCd = 0; // 伝票発行済区分
            redStockSlip.StockSlipPrintDate = DateTime.MinValue; // 仕入伝票発行日
            redStockSlip.SlipPrtSetPaperId = string.Empty; // 伝票印刷設定用帳票ID
            # endregion

            // 明細ループ
            for (int index = 0; index < redStockDetailList.Count; index++)
            {
                StockDetailWork redStockDetail = redStockDetailList[index];
                int supplierFormalSrc = redStockDetail.SupplierFormal;
                long stockSlipDtlNumSrc = redStockDetail.StockSlipDtlNum;

                # region [明細]
                redStockDetail.CreateDateTime = DateTime.MinValue; // 作成日時
                redStockDetail.UpdateDateTime = DateTime.MinValue; // 更新日時
                redStockDetail.EnterpriseCode = this._enterpriseCode; // 企業コード
                redStockDetail.FileHeaderGuid = Guid.Empty; // GUID
                redStockDetail.UpdEmployeeCode = string.Empty; // 更新従業員コード
                redStockDetail.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
                redStockDetail.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
                redStockDetail.LogicalDeleteCode = 0; // 論理削除区分
                redStockDetail.StockRowNo = (index + 1); // 仕入行番号
                redStockDetail.SectionCode = redStockSlip.SectionCode; // 拠点コード ログイン拠点を入れる
                redStockDetail.AcptAnOdrStatusSync = 30; // 受注ステータス（同時）=30:売上
                redStockDetail.StockSlipCdDtl = stockSlipCdDtl; // 仕入伝票区分（明細）
                redStockDetail.StockInputCode = redStockSlip.StockInputCode; // 仕入入力者コード
                redStockDetail.StockInputName = redStockSlip.StockInputName; // 仕入入力者名称
                redStockDetail.StockAgentCode = redStockSlip.StockAgentCode; // 仕入担当者コード
                redStockDetail.StockAgentName = redStockSlip.StockAgentName; // 仕入担当者名称
                redStockDetail.RemainCntUpdDate = DateTime.MinValue; // 残数更新日
                redStockDetail.StockDtiSlipNote1 = string.Empty; // 仕入伝票明細備考1
                redStockDetail.SlipMemo1 = string.Empty; // 伝票メモ１
                redStockDetail.SlipMemo2 = string.Empty; // 伝票メモ２
                redStockDetail.SlipMemo3 = string.Empty; // 伝票メモ３
                redStockDetail.InsideMemo1 = string.Empty; // 社内メモ１
                redStockDetail.InsideMemo2 = string.Empty; // 社内メモ２
                redStockDetail.InsideMemo3 = string.Empty; // 社内メモ３
                redStockDetail.SupplierCd = redStockSlip.SupplierCd; // 仕入先コード
                redStockDetail.SupplierSnm = redStockSlip.SupplierSnm; // 仕入先略称
                redStockDetail.AddresseeCode = 0; // 納品先コード
                redStockDetail.AddresseeName = string.Empty; // 納品先名称
                redStockDetail.DirectSendingCd = 0; // 直送区分
                redStockDetail.OrderNumber = string.Empty; // 発注番号
                redStockDetail.WayToOrder = 0; // 注文方法
                redStockDetail.DeliGdsCmpltDueDate = DateTime.MinValue; // 納品完了予定日
                redStockDetail.ExpectDeliveryDate = DateTime.MinValue; // 希望納期
                redStockDetail.OrderDataCreateDiv = 0; // 発注データ作成区分
                redStockDetail.OrderDataCreateDate = DateTime.MinValue; // 発注データ作成日
                redStockDetail.OrderFormIssuedDiv = 0; // 発注書発行済区分
                # endregion

                # region [明細金額算出]
                double stockUnitPriceTaxExc;
                double stockUnitPriceTaxInc;
                long stockPriceConsTax;
                long stockPriceTaxExc;
                long stockPriceTaxInc;
                // 算出
                CalculateStockPrice(redStockSlip, redStockDetail, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax);
                // 格納
                redStockDetail.StockUnitPriceFl = stockUnitPriceTaxExc;
                redStockDetail.StockUnitTaxPriceFl = stockUnitPriceTaxInc;
                redStockDetail.StockPriceTaxExc = stockPriceTaxExc;
                redStockDetail.StockPriceTaxInc = stockPriceTaxInc;
                redStockDetail.StockPriceConsTax = stockPriceConsTax;
                # endregion
            }
        }

        /// <summary>
        /// 指定した消費税率を元に仕入明細データ行オブジェクトの金額情報を更新します。
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="stockDetail">仕入明細データオブジェクト</param>
        /// <param name="stockUnitPriceFl">仕入単価（税抜，浮動）</param>
        /// <param name="stockUnitTaxPriceFl">仕入単価（税込，浮動）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceConsTax">仕入金額消費税額</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        public void CalculateStockPrice(StockSlipWork stockSlip, StockDetailWork stockDetail, out double stockUnitPriceFl, out double stockUnitTaxPriceFl, out long stockPriceTaxExc, out long stockPriceTaxInc, out long stockPriceConsTax)
        {
            stockUnitPriceFl = 0;
            stockUnitTaxPriceFl = 0;
            stockPriceTaxExc = 0;
            stockPriceTaxInc = 0;
            stockPriceConsTax = 0;

            // 計上処理以外からコールされた場合は仕入先情報を取得
            if (this._supplier == null)
            {
                // 仕入先情報取得
                if (this._supplierAcs.Read(out this._supplier, this._enterpriseCode, stockSlip.SupplierCd) != 0 ||
                    this._supplier == null)
                {
                    return;
                }
            }

            // 原単価(税込)算出
            this.CalcTaxExcAndTaxIncForStock(stockDetail.TaxationCode, stockSlip.SupplierCd, this._taxRate, this._supplier.SuppTtlAmntDspWayCd, stockDetail.StockUnitPriceFl, out stockUnitPriceFl, out stockUnitTaxPriceFl);


            // 仕入金額端数処理コード
            int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);
            // 消費税端数処理区分
            int taxFracProcCode = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);


            // 非課税時は税込金額＝税抜き金額
            if (stockSlip.SuppCTaxLayCd == 9)
            {
                stockDetail.StockPriceTaxInc = stockDetail.StockPriceTaxExc;
                stockDetail.StockUnitTaxPriceFl = stockDetail.StockUnitPriceFl;
            }
            else
            {
                // 課税区分が「外税」の場合
                if (stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    double stockUnitPrice = stockDetail.StockUnitPriceFl;

                    if (this.CalculateStockPrice(
                        stockDetail.StockCount,
                        stockUnitPrice,
                        stockDetail.TaxationCode,
                        stockSlip.SupplierConsTaxRate,
                        stockMoneyFrcProcCd,
                        taxFracProcCode,
                        out stockPriceTaxInc,
                        out stockPriceTaxExc,
                        out stockPriceConsTax))
                    {
                        if (stockDetail.StockGoodsCd <= 1)
                        {
                            stockDetail.StockPriceTaxInc = stockPriceTaxInc;
                        }
                    }
                }
                // 課税区分が「内税」の場合
                else if (stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    double stockUnitPrice = stockDetail.StockUnitPriceFl;

                    if (this.CalculateStockPrice(
                        stockDetail.StockUnitPriceFl,
                        stockUnitPrice,
                        stockDetail.TaxationCode,
                        stockSlip.SupplierConsTaxRate,
                        stockMoneyFrcProcCd,
                        taxFracProcCode,
                        out stockPriceTaxInc,
                        out stockPriceTaxExc,
                        out stockPriceConsTax))
                    {
                        if (stockDetail.StockGoodsCd <= 1)
                        {
                            stockDetail.StockPriceTaxExc = stockPriceTaxExc;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private void CalcTaxExcAndTaxIncForStock(int taxationCode, int supplierCd, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // 仕入先マスタから消費税端数処理情報を取得
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, supplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            this.GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

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
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="stockCount">仕入数</param>
        /// <param name="stockUnitPrice">仕入単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="taxFracProcCode">消費税端数処理区分</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceConsTax">仕入消費税</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private bool CalculateStockPrice(double stockCount, double stockUnitPrice, int taxationCode, double taxRate, int stockMoneyFrcProcCd, int taxFracProcCode,
            out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax)
        {
            double taxFracProcUnit;
            int taxFracProcCd;
            GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;
            stockPriceConsTax = 0;

            // 仕入数が0または仕入単価が0の場合はすべて0で終了
            if ((stockCount == 0) || (stockUnitPrice == 0)) return true;

            // 外税の場合
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = stockUnitPrice;	// 単価（税抜き）
                double unitPriceInc;					// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc = 0;						// 価格（税抜き）
                long priceInc;							// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;			// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;			// 仕入金額（税抜き）		
                stockPriceConsTax = priceTax;			// 仕入消費税
            }
            // 内税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;					// 単価（税抜き）
                double unitPriceInc = stockUnitPrice;	// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc;							// 価格（税抜き）
                long priceInc = 0;						// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;			// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;			// 仕入金額（税抜き）
                stockPriceConsTax = priceTax;			// 仕入消費税
            }
            // 非課税の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = stockUnitPrice;	// 単価（税抜き）
                double unitPriceInc;					// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc = 0;						// 価格（税抜き）
                long priceInc;							// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceExc;			// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;			// 仕入金額（税込み）
                stockPriceConsTax = priceTax;			// 仕入消費税
            }

            return true;
        }

        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        public void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<StockProcMoney> stockProcMoneyList = this._stockProcMoneyList.FindAll(
                delegate(StockProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            stockProcMoneyList.Sort(new StockProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            StockProcMoney stockProcMoney = stockProcMoneyList.Find(
                delegate(StockProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if (stockProcMoney != null)
            {
                fractionProcUnit = stockProcMoney.FractionProcUnit;
                fractionProcCd = stockProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 登録用赤伝　手数料明細追加処理
        /// </summary>
        /// <param name="redStockDetailList">仕入明細データオブジェクトリスト</param>
        /// <param name="redStockSlip">仕入データオブジェクト</param>
        /// <param name="parameter">赤伝登録パラメータ</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private void AddFeeDetail(ref List<StockDetailWork> redStockDetailList, ref StockSlipWork redStockSlip, RedSlipWriteParameter parameter)
        {
            # region [データ準備]
            // 品名
            const string feeName = "返品手数料額";

            // 課税区分・税抜金額・税込金額
            int taxationCode = 0;
            long stockMoneyTaxExc;
            long stockMoneyTaxInc;
            long stockPriceConsTax;
            this.CalculateSalesMoneyForFee(redStockSlip, parameter.FeePriceOfTotal, out taxationCode, out stockMoneyTaxExc, out stockMoneyTaxInc, out stockPriceConsTax);
            # endregion

            StockDetailWork feeDetail = new StockDetailWork();

            string stockInputCode = parameter.InputEmployeeCd;
            string stockInputName = parameter.InputEmployeeNm;

            # region [手数料データ格納]
            feeDetail.CreateDateTime = DateTime.MinValue; // 作成日時
            feeDetail.UpdateDateTime = DateTime.MinValue; // 更新日時
            feeDetail.EnterpriseCode = parameter.EnterpriseCode; // 企業コード
            feeDetail.FileHeaderGuid = Guid.Empty; // GUID
            feeDetail.UpdEmployeeCode = string.Empty; // 更新従業員コード
            feeDetail.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
            feeDetail.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
            feeDetail.LogicalDeleteCode = 0; // 論理削除区分
            feeDetail.AcceptAnOrderNo = 0; // 受注番号
            feeDetail.SupplierFormal = 0; // 仕入形式 3:仕入返品予定
            feeDetail.SupplierSlipNo = 0; // 仕入伝票番号
            feeDetail.StockRowNo = redStockDetailList.Count + 1; // 仕入行番号
            feeDetail.SectionCode = redStockDetailList[0].SectionCode; // 拠点コード
            feeDetail.SubSectionCode = redStockDetailList[0].SubSectionCode; // 部門コード
            feeDetail.CommonSeqNo = 0; // 共通通番
            feeDetail.StockSlipDtlNum = 0; // 仕入明細通番
            feeDetail.SupplierFormalSrc = 0; // 仕入形式（元）
            feeDetail.StockSlipDtlNumSrc = 0; // 仕入明細通番（元）
            feeDetail.AcptAnOdrStatusSync = 0; // 受注ステータス(同時)
            feeDetail.SalesSlipDtlNumSync = 0; // 売上明細通番（同時）
            feeDetail.StockSlipCdDtl = (int)StockSlipCdDtl.Discount; // 仕入伝票区分（明細）　←2:値引
            feeDetail.StockInputCode = stockInputCode; // 仕入入力者コード
            feeDetail.StockInputName = stockInputName; // 仕入入力者名称
            feeDetail.StockAgentCode = stockInputCode; // 仕入担当者コード
            feeDetail.StockAgentName = stockInputName; // 仕入担当者名称
            feeDetail.GoodsKindCode = 0; // 商品属性
            feeDetail.GoodsMakerCd = 0; // 商品メーカーコード
            feeDetail.MakerName = string.Empty; // メーカー名称
            feeDetail.MakerKanaName = string.Empty; // メーカーカナ名称
            feeDetail.CmpltMakerKanaName = string.Empty; // メーカーカナ名称（一式）
            feeDetail.GoodsNo = string.Empty; // 商品番号
            feeDetail.GoodsName = feeName; // 商品名称　←「返品手数料額」
            feeDetail.GoodsNameKana = feeName; // 商品名称カナ　←「返品手数料額」
            feeDetail.GoodsLGroup = 0; // 商品大分類コード
            feeDetail.GoodsLGroupName = string.Empty; // 商品大分類名称
            feeDetail.GoodsMGroup = 0; // 商品中分類コード
            feeDetail.GoodsMGroupName = string.Empty; // 商品中分類名称
            feeDetail.BLGroupCode = 0; // BLグループコード
            feeDetail.BLGroupName = string.Empty; // BLグループコード名称
            feeDetail.BLGoodsCode = 0; // BL商品コード
            feeDetail.BLGoodsFullName = string.Empty; // BL商品コード名称（全角）
            feeDetail.EnterpriseGanreCode = 0; // 自社分類コード
            feeDetail.EnterpriseGanreName = string.Empty; // 自社分類名称
            feeDetail.WarehouseCode = string.Empty; // 倉庫コード
            feeDetail.WarehouseName = string.Empty; // 倉庫名称
            feeDetail.WarehouseShelfNo = string.Empty; // 倉庫棚番
            feeDetail.StockOrderDivCd = 0; // 仕入在庫取寄せ区分
            feeDetail.OpenPriceDiv = 0; // オープン価格区分
            feeDetail.GoodsRateRank = string.Empty; // 商品掛率ランク
            feeDetail.CustRateGrpCode = 0; // 得意先掛率グループコード
            feeDetail.SuppRateGrpCode = 0; // 仕入先掛率グループコード
            feeDetail.ListPriceTaxExcFl = 0; // 定価（税抜，浮動）
            feeDetail.ListPriceTaxIncFl = 0; // 定価（税込，浮動）
            feeDetail.StockRate = 0; // 仕入率
            feeDetail.RateSectStckUnPrc = string.Empty; // 掛率設定拠点（仕入単価）
            feeDetail.RateDivStckUnPrc = string.Empty; // 掛率設定区分（仕入単価）
            feeDetail.UnPrcCalcCdStckUnPrc = 0; // 単価算出区分（仕入単価）
            feeDetail.PriceCdStckUnPrc = 0; // 価格区分（仕入単価）
            feeDetail.StdUnPrcStckUnPrc = 0; // 基準単価（仕入単価）
            feeDetail.FracProcUnitStcUnPrc = 0; // 端数処理単位（仕入単価）
            feeDetail.FracProcStckUnPrc = 0; // 端数処理（仕入単価）
            feeDetail.StockUnitPriceFl = 0; // 仕入単価（税抜，浮動）
            feeDetail.StockUnitTaxPriceFl = 0; // 仕入単価（税込，浮動）
            feeDetail.StockUnitChngDiv = 0; // 仕入単価変更区分
            feeDetail.BfStockUnitPriceFl = 0; // 変更前仕入単価（浮動）
            feeDetail.BfListPrice = 0; // 変更前定価
            feeDetail.RateBLGoodsCode = 0; // BL商品コード（掛率）
            feeDetail.RateBLGoodsName = string.Empty; // BL商品コード名称（掛率）
            feeDetail.RateGoodsRateGrpCd = 0; // 商品掛率グループコード（掛率）
            feeDetail.RateGoodsRateGrpNm = string.Empty; // 商品掛率グループ名称（掛率）
            feeDetail.RateBLGroupCode = 0; // BLグループコード（掛率）
            feeDetail.RateBLGroupName = string.Empty; // BLグループ名称（掛率）
            feeDetail.StockCount = 0; // 仕入数
            feeDetail.OrderCnt = 0; // 受注数量
            feeDetail.OrderAdjustCnt = 0; // 受注調整数
            feeDetail.OrderRemainCnt = 0; // 受注残数
            feeDetail.RemainCntUpdDate = DateTime.MinValue; // 残数更新日
            feeDetail.StockPriceTaxExc = stockMoneyTaxExc; // 仕入金額（税抜き）　←手数料額
            feeDetail.StockPriceTaxInc = stockMoneyTaxInc; // 仕入金額（税込み）　←手数料額
            feeDetail.StockGoodsCd = 0; // 仕入商品区分
            feeDetail.StockPriceConsTax = stockPriceConsTax; // 仕入金額消費税額
            feeDetail.TaxationCode = taxationCode; // 課税区分
            feeDetail.StockDtiSlipNote1 = string.Empty; // 仕入伝票明細備考1
            feeDetail.SalesCustomerCode = 0; // 販売先コード
            feeDetail.SalesCustomerSnm = string.Empty; // 販売先略称
            feeDetail.SlipMemo1 = string.Empty; // 伝票メモ１
            feeDetail.SlipMemo2 = string.Empty; // 伝票メモ２
            feeDetail.SlipMemo3 = string.Empty; // 伝票メモ３
            feeDetail.InsideMemo1 = string.Empty; // 社内メモ１
            feeDetail.InsideMemo2 = string.Empty; // 社内メモ２
            feeDetail.InsideMemo3 = string.Empty; // 社内メモ３
            feeDetail.SupplierCd = 0; // 仕入先コード
            feeDetail.SupplierSnm = string.Empty; // 仕入先略称
            feeDetail.AddresseeCode = 0; // 納品先コード
            feeDetail.AddresseeName = string.Empty; // 納品先略称
            feeDetail.DirectSendingCd = 0; // 直送区分
            feeDetail.OrderNumber = string.Empty; // 発注番号
            feeDetail.WayToOrder = 0; // 注文方法
            feeDetail.DeliGdsCmpltDueDate = DateTime.MinValue; // 納品完了予定日
            feeDetail.ExpectDeliveryDate = DateTime.MinValue; // 希望納期
            feeDetail.OrderDataCreateDiv = 0; // 発注データ作成区分
            feeDetail.OrderDataCreateDate = DateTime.MinValue; // 発注データ作成日
            feeDetail.OrderFormIssuedDiv = 0; // 発注書発行済区分
            # endregion

            redStockDetailList.Add(feeDetail);

            // 手数料明細を仕入明細データとして１件追加したので、明細行数も加算
            redStockSlip.DetailRowCount++;
        }

        /// <summary>
        /// 手数料金額算出処理
        /// </summary>
        /// <param name="redSalesSlip">仕入データオブジェクト</param>
        /// <param name="salesMoneyDisplay">売上金額</param>
        /// <param name="taxationDivCd">課税区分</param>
        /// <param name="salesMoneyTaxExc">売上金額（税抜き）</param>
        /// <param name="salesMoneyTaxInc">売上金額（税抜き）</param>
        /// <param name="salesPriceConsTax"売上金額消費税額></param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private void CalculateSalesMoneyForFee(StockSlipWork redStockSlip, long salesMoneyDisplay, out int taxationDivCd, out long salesMoneyTaxExc, out long salesMoneyTaxInc, out long salesPriceConsTax)
        {
            // 金額処理コード取得
            int salesTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, redStockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);


            // 税端数処理区分コード・単位取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // 非課税
            if (redStockSlip.SuppCTaxLayCd == (int)ConsTaxLayMethod.TaxExempt)
            {
                salesMoneyTaxExc = salesMoneyDisplay;
                salesMoneyTaxInc = salesMoneyDisplay;
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 総額表示しない
            else if (redStockSlip.SuppTtlAmntDspWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
            {
                salesMoneyTaxExc = salesMoneyDisplay;
                salesMoneyTaxInc = salesMoneyDisplay + CalculateTax.GetTaxFromPriceExc(redStockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoneyDisplay);
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxExc;
            }
            // 総額表示する
            else
            {
                salesMoneyTaxExc = salesMoneyDisplay - CalculateTax.GetTaxFromPriceInc(redStockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoneyDisplay);
                salesMoneyTaxInc = salesMoneyDisplay;
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
            }

            salesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
        }

        #endregion

        /// <summary>
        /// 商品情報読み込み
        /// </summary>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <returns>status</returns>
        /// <br>Note       : 商品情報取得します。</br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        public int ReadGoods(string goodsNo, int goodsMakerCd, out GoodsUnitData goodsUnitData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            goodsUnitData = null;

            if (_goodsAcs == null)
            {
                _goodsAcs = new GoodsAcs();
                string retMessage;
                _goodsAcs.SearchInitial(_enterpriseCode, _loginSectionCode, out retMessage);

                // 商品ディクショナリ生成
                _goodsUnitDataDic = new Dictionary<GoodsKey, GoodsUnitData>();
            }

            // キャッシュから探す
            GoodsKey key = new GoodsKey(goodsNo, goodsMakerCd);
            if (_goodsUnitDataDic.ContainsKey(key))
            {
                goodsUnitData = _goodsUnitDataDic[key];
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                // 商品読み込み(goodsUnitDataには在庫リストが含まれる)
                status = _goodsAcs.Read(this._enterpriseCode, goodsMakerCd, goodsNo, ConstantManagement.LogicalMode.GetData0, out goodsUnitData);

                // ディクショナリに追加
                if (!_goodsUnitDataDic.ContainsKey(new GoodsKey(goodsUnitData)))
                {
                    _goodsUnitDataDic.Add(new GoodsKey(goodsUnitData), goodsUnitData);
                }
            }
            return status;
        }

        /// <summary>
        /// 在庫取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="warehouseCode">在庫コード</param>
        /// <param name="retStock">在庫</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 在庫を取得します。</br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        public int SelectStock(GoodsUnitData goodsUnitData, string warehouseCode, out Stock retStock)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retStock = null;

            // パラメータチェック処理
            if (goodsUnitData == null ||
                 warehouseCode.Trim() == string.Empty ||
                 goodsUnitData.StockList == null ||
                 goodsUnitData.StockList.Count == 0)
            {
                return status;
            }

            // リスト内から探す
            retStock = goodsUnitData.StockList.Find(
                        delegate(Stock stock)
                        {
                            return (stock.WarehouseCode.Trim() == warehouseCode.Trim());
                        }
                        );

            if (retStock != null)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        # region [赤伝仕入明細売上金額算出]
        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="redSlipRow">赤伝情報データセット</param>
        /// <param name="listRow">仕入情報データセット</param>
        /// <param name="listRow">仕入情報データセット(返品計上使用分)</param>
        /// <param name="detailRow">仕入明細情報データセット</param>
        /// <param name="retDetailRow">仕入明細情報データセット(返品計上使用分)</param>
        /// <param name="stockPriceTaxExc">返品伝票金額</param>
        /// <remarks>
        /// <br>Note       : 仕入金額を計算します。</br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        public void CalculationSalesMoney(SuppPtrStcDetailDataSet.RedSlipDetailRow redSlipRow, SuppPtrStcDetailDataSet.StcListRow listRow,　SuppPtrStcDetailDataSet.RetGdsStcListRow retListRow, SuppPtrStcDetailDataSet.StcDetailRow detailRow, SuppPtrStcDetailDataSet.RetGdsStcDetailRow retDetailRow, out long stockPriceTaxExc)
        {
            // 返品計上用パラメータ初期化
            RetGdsAddUpWriteParameter para = new SuppPtrStockDetailAcs.RetGdsAddUpWriteParameter();
            // 仕入データ初期化
            StockSlipWork stockSlip = new StockSlipWork();
            // 仕入明細初期化
            StockDetailWork stockDetail = new StockDetailWork();
            // パラメータに企業コード設定
            para.EnterpriseCode = this._enterpriseCode;
            // 仕入データ作成
            SlcListFromStockSlipWorkData(para, listRow, retListRow, out stockSlip);
            // 仕入明細データ作成
            RedSlipFromStockDetailWorkData(para, detailRow, retDetailRow, out stockDetail);

            // RedSlipDetailRowの返品数を仕入明細データの仕入数にセットする
            stockDetail.StockCount = redSlipRow.ReturnCnt;
            // RedSlipDetailRowの原価を仕入明細データの仕入単価にセットする
            stockDetail.StockUnitPriceFl = redSlipRow.StockUnitPrice;
            // 仕入金額再計算
            double stockUnitPriceTaxExc;  // 仕入単価（税抜，浮動）
            double stockUnitPriceTaxInc;  // 仕入単価（税込，浮動）
            long stockPriceConsTax;       // 仕入金額消費税額
            long stockPriceTaxInc;        // 仕入金額（税込み）
            // 金額情報算出
            CalculateStockPrice(stockSlip, stockDetail, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax);
        }

        #endregion

        #region class
        #region パラメータ
        /// <summary>
        /// 返品計上用パラメータ
        /// </summary>
        /// <remarks>
        /// <br>Note       : [仕入返品計上] 新規追加</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        public class RetGdsAddUpWriteParameter
        {
            /// <summary>企業コード</summary>
            private string _enterpriseCode;
            /// <summary>伝票区分</summary>
            private int _slipCd;
            /// <summary>担当者従業員コード</summary>
            private string _stockAgentCd;
            /// <summary>担当者従業員名称</summary>
            private string _stockAgentNm;
            /// <summary>返品日付</summary>
            private DateTime _retGdsDate;
            /// <summary>手数料額(合計)</summary>
            private Int64 _feePriceOfTotal;
            /// <summary>備考１</summary>
            private string _slipNote;
            /// <summary>備考２</summary>
            private string _slipNote2;
            /// <summary>返品理由</summary>
            private string _returnReason;
            /// <summary>返品理由コード</summary>
            private Int32 _returnReasonDiv;
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>仕入先コード</summary>
            private int _supplierCode;

            /// <summary>
            /// 企業コード
            /// </summary>
            public string EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }
            /// <summary>
            /// 伝票区分
            /// </summary>
            public int SlipCd
            {
                get { return _slipCd; }
                set { _slipCd = value; }
            }

            /// <summary>
            /// 担当従業員コード
            /// </summary>
            public string StockAgentCd
            {
                get { return _stockAgentCd; }
                set { _stockAgentCd = value; }
            }

            /// <summary>
            /// 担当従業員名称
            /// </summary>
            public string StockAgentNm
            {
                get { return _stockAgentNm; }
                set { _stockAgentNm = value; }
            }

            /// <summary>
            /// 返品日付
            /// </summary>
            public DateTime RetGdsDate
            {
                get { return _retGdsDate; }
                set { _retGdsDate = value; }
            }

            /// <summary>
            /// 手数料額(合計)
            /// </summary>
            public Int64 FeePriceOfTotal
            {
                get { return _feePriceOfTotal; }
                set { _feePriceOfTotal = value; }
            }

            /// <summary>
            /// 備考１
            /// </summary>
            public string SlipNote
            {
                get { return _slipNote; }
                set { _slipNote = value; }
            }

            /// <summary>
            /// 備考２
            /// </summary>
            public string SlipNote2
            {
                get { return _slipNote2; }
                set { _slipNote2 = value; }
            }

            /// <summary>
            /// 返品理由
            /// </summary>
            public string ReturnReason
            {
                get { return _returnReason; }
                set { _returnReason = value; }
            }

            /// <summary>
            /// 返品理由コード
            /// </summary>
            public Int32 RetGoodsReasonDiv
            {
                get { return _returnReasonDiv; }
                set { _returnReasonDiv = value; }
            }

            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }

            /// <summary>
            /// 仕入先コード
            /// </summary>
            public int SupplierCode
            {
                get { return _supplierCode; }
                set { _supplierCode = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public RetGdsAddUpWriteParameter()
            {
                _enterpriseCode = string.Empty;
                _slipCd = 0;
                _stockAgentCd = string.Empty;
                _stockAgentNm = string.Empty;
                _retGdsDate = DateTime.MinValue;
                _feePriceOfTotal = 0;
                _slipNote = string.Empty;
                _slipNote2 = string.Empty;
                _returnReason = string.Empty;
                _sectionCode = string.Empty;
                _supplierCode = 0;
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="enterpriseCode">企業コード</param>
            /// <param name="slipCd">伝票区分</param>
            /// <param name="stockAgentCd">担当者従業員コード</param>
            /// <param name="stockAgentNm">担当者従業員名称</param>
            /// <param name="retGdsDate">返品日付</param>
            /// <param name="feePriceOfTotal">手数料額(合計)</param>
            /// <param name="slipNote">備考１</param>
            /// <param name="slipNote2">備考２</param>
            /// <param name="returnReason">返品理由</param>
            /// <param name="returnReasonDiv">返品理由コード</param>
            /// <param name="sectionCode">拠点コード</param>
            /// <param name="supplierCode">仕入先コード</param>
            public RetGdsAddUpWriteParameter(string enterpriseCode, int slipCd, string stockAgentCd, string stockAgentNm, DateTime retGdsDate, double feeRateOfOrder, Int64 feePriceOfOrder, double feeRateOfStock, Int64 feePriceOfStock, double feeRateOfTotal, Int64 feePriceOfTotal, Int32 salesCodeDiv, string partySalesSlipNo, string slipNote, string slipNote2, string slipNote3, string returnReason, int returnReasonDiv, string sectionCode, int supplierCode)
            {
                _enterpriseCode = enterpriseCode;
                _slipCd = slipCd;
                _stockAgentCd = stockAgentCd;
                _stockAgentNm = stockAgentNm;
                _retGdsDate = retGdsDate;
                _feePriceOfTotal = feePriceOfTotal;
                _slipNote = slipNote;
                _slipNote2 = slipNote2;
                _returnReason = returnReason;
                _returnReasonDiv = returnReasonDiv;
                _sectionCode = sectionCode;
                _supplierCode = supplierCode;
            }
        }
    #endregion パラメータ
    #endregion クラス

        #region[税率マスタ取得]
        /// <summary>
        /// 税率設定マスタアクセスクラス
        /// </summary>
        /// <param name="taxRateSet">税率設定情報クラス</param>
        /// <returns>status</returns>
        private int TaxRateSetRead(out TaxRateSet taxRateSet)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 税率設定情報を取得
            status = this._taxRateSetAcs.Read(out taxRateSet, this._enterpriseCode, 0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                taxRateSet = new TaxRateSet();
            }
            return status;
        }

        /// <summary>
        /// 税率取得(税率設定マスタ)
        /// </summary>
        /// <param name="taxRateSet">税率設定情報</param>
        /// <param name="targetDate">税率適用日</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        private double GetTaxRate(TaxRateSet taxRateSet, DateTime targetDate)
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }
        #endregion[税率マスタ取得]
    }
}
