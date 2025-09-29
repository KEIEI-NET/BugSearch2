//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 簡単問合せCTI アクセスクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/06  修正内容 : IAAE版から製品版へ変更(不要ロジック削除)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 簡単問合せCTI アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/06</br>
    /// </remarks>
    public class SimpleInqCTIAcs
    {
        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■ Public Enum

        /// <summary>
        /// 展開する伝票区分
        /// </summary>
        public enum ExtractSlipCdType : int
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>売上</summary>
            Sales = 1,
            /// <summary>返品</summary>
            Return = 2,
        }
        #endregion // Public Enum

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        ISearchSalesSlipDB _iSearchSalesSlipDB;
        private const string ct_DateFormat = "yyyy/MM/dd";
        private SimpleInqCTIDataSet _dataSet;
        private EmployeeAcs _employeeAcs;
        private int _rowNo = 0;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SimpleInqCTIAcs()
        {
            this._dataSet = new SimpleInqCTIDataSet();
            this._employeeAcs = new EmployeeAcs();

            if (_employeeList == null) _employeeList = new List<Employee>();
        }

        #endregion // Constructor

        // ===================================================================================== //
        // プライベートスタティック変数
        // ===================================================================================== //
        #region ■ Private Static Member

        private static List<Employee> _employeeList;

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■ Property

        /// <summary>データセット</summary>
        public SimpleInqCTIDataSet DataSet
        {
            get { return _dataSet; }
        }

        /// <summary>データビュー</summary>
        public DataView DataView
        {
            get { return _dataSet.SalesSlip.DefaultView; }
        }
        #endregion // Property

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■ Public Method

        /// <summary>
        /// 売上データを検索し、検索結果をデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="para">検索パラメータ</param>
        /// <param name="extractSlipCdType"></param>
        /// <param name="showEstimateInput"></param>
        /// <returns>STATUS</returns>
        public int Search(SalesSlipSearch para, int extractSlipCdType, bool showEstimateInput)
        {
            this._dataSet.SalesSlip.Rows.Clear();

            object returnSalesSlipSearchResult = null;
            SalesSlipSearchWork workPara = CreateParamDataFromUIData(para, extractSlipCdType, showEstimateInput);

            if (this._iSearchSalesSlipDB == null) this._iSearchSalesSlipDB = MediationSearchSalesSlipDB.GetSearchSalesSlipDB();
            int status = this._iSearchSalesSlipDB.Search(out returnSalesSlipSearchResult, workPara, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnSalesSlipSearchResult is ArrayList)
                {
                    this._rowNo = 0;

                    foreach (SalesSlipSearchResultWork data in (ArrayList)returnSalesSlipSearchResult)
                    {
                        SimpleInqCTIDataSet.SalesSlipRow row = _dataSet.SalesSlip.FindByEnterpriseCodeSearchSlipNumAcptAnOdrStatus(data.EnterpriseCode, data.SalesSlipNum, data.AcptAnOdrStatus);
                        if (row == null)
                        {
                            // 伝票番号と伝票種別の重複なし
                            this._rowNo++;
                            this.CacheSalesSlipSearchResult(data);
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 売上データ(明細)を検索し、検索結果をデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int SearchDetail(SalesSlipDetailSearch para, SalesSlipSearchResult slip)
        {
            int status = 0;
            this._dataSet.SalesDetail.Rows.Clear();

            object returnSalesSlipDetailSearchResult = null;
            SalesSlipDetailSearchWork workPara = CreateDetailParamDataFromUIData(para);


            if (this._iSearchSalesSlipDB == null) this._iSearchSalesSlipDB = MediationSearchSalesSlipDB.GetSearchSalesSlipDB();
            status = this._iSearchSalesSlipDB.SearchDetail(out returnSalesSlipDetailSearchResult, workPara, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnSalesSlipDetailSearchResult is ArrayList)
                {
                    foreach (SalesSlipDetailSearchResultWork data in (ArrayList)returnSalesSlipDetailSearchResult)
                    {
                        this.CacheSalesSlipDetailSearchResult(data, slip);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 売上データテーブルの行を初期化します。
        /// </summary>
        public void Clear()
        {
            this._dataSet.SalesSlip.Rows.Clear();
        }

        /// <summary>
        /// 従業員情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="data">従業員オブジェクト</param>
        /// <returns>STATUS</returns>
        public int GetEmployee(string enterpriseCode, string employeeCode, out Employee data)
        {
            int status = 0;

            if (_employeeList == null)
            {
                _employeeList = new List<Employee>();
            }

            if (_employeeList.Count == 0)
            {
                ArrayList aList;
                ArrayList aList2;
                status = this._employeeAcs.SearchOnlyEmployeeInfo(out aList, out aList2, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (aList != null) _employeeList = new List<Employee>((Employee[])aList.ToArray(typeof(Employee)));
                }
            }

            data = SearchStatic(employeeCode);

            if (data == null) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            return status;
        }


        /// <summary>
        /// 金額種別設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 金額種別設定マスタを取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/12/12</br>
        /// </remarks>
        public int ReadMoneyKind(string enterprisecode, out Dictionary<int, MoneyKind> moneyKindDic)
        {

            MoneyKindAcs _moneyKindAcs = new MoneyKindAcs();

            moneyKindDic = new Dictionary<int, MoneyKind>();

            int status;
            ArrayList retList = new ArrayList();

            status = _moneyKindAcs.SearchAll(out retList, enterprisecode);
            if (status == 0)
            {
                foreach (MoneyKind moneyKind in retList)
                {
                    // 金額設定区分が「0:入金」を使用
                    if (( moneyKind.LogicalDeleteCode == 0 ) && ( moneyKind.PriceStCode == 0 ))
                    {
                        moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                    }
                }
            }

            return ( status );
        }

        #endregion // Public Method

        // ===================================================================================== //
        // パブリックスタティックメソッド
        // ===================================================================================== //
        #region ■ Public Static Method


        /// <summary>
        /// パラメータオブジェクトからUIデータオブジェクトを生成します。
        /// </summary>
        /// <param name="data">パラメータオブジェクト</param>
        /// <returns>UIデータオブジェクト</returns>
        public static SalesSlipSearchResult CreateUIDataFromParamData(SalesSlipSearchResultWork work)
        {
            SalesSlipSearchResult data = new SalesSlipSearchResult();

            #region コピー
            data.AccRecConsTax = work.AccRecConsTax;
            data.AccRecDivCd = work.AccRecDivCd;
            data.AcptAnOdrStatus = work.AcptAnOdrStatus;
            data.AddresseeAddr1 = work.AddresseeAddr1;
            data.AddresseeAddr3 = work.AddresseeAddr3;
            data.AddresseeAddr4 = work.AddresseeAddr4;
            data.AddresseeCode = work.AddresseeCode;
            data.AddresseeFaxNo = work.AddresseeFaxNo;
            data.AddresseeName = work.AddresseeName;
            data.AddresseeName2 = work.AddresseeName2;
            data.AddresseePostNo = work.AddresseePostNo;
            data.AddresseeTelNo = work.AddresseeTelNo;
            data.AddUpADate = work.AddUpADate;
            data.AutoDepositCd = work.AutoDepositCd;
            data.AutoDepositSlipNo = work.AutoDepositSlipNo;
            data.BusinessTypeCode = work.BusinessTypeCode;
            data.BusinessTypeName = work.BusinessTypeName;
            data.CarMngCode = work.CarMngCode;
            data.CashRegisterNo = work.CashRegisterNo;
            data.CategoryNo = work.CategoryNo;
            data.ClaimCode = work.ClaimCode;
            data.ClaimSnm = work.ClaimSnm;
            data.CompleteCd = work.CompleteCd;
            data.ConsTaxLayMethod = work.ConsTaxLayMethod;
            data.ConsTaxRate = work.ConsTaxRate;
            data.CustomerCode = work.CustomerCode;
            data.CustomerName = work.CustomerName;
            data.CustomerName2 = work.CustomerName2;
            data.CustomerSnm = work.CustomerSnm;
            data.CustSlipNo = work.CustSlipNo;
            data.DebitNLnkSalesSlNum = work.DebitNLnkSalesSlNum;
            data.DebitNoteDiv = work.DebitNoteDiv;
            data.DelayPaymentDiv = work.DelayPaymentDiv;
            data.DeliveredGoodsDiv = work.DeliveredGoodsDiv;
            data.DeliveredGoodsDivNm = work.DeliveredGoodsDivNm;
            data.DemandAddUpSecCd = work.DemandAddUpSecCd;
            data.DepositAllowanceTtl = work.DepositAllowanceTtl;
            data.DepositAlwcBlnce = work.DepositAlwcBlnce;
            data.DetailRowCount = work.DetailRowCount;
            data.EdiSendDate = work.EdiSendDate;
            data.EdiTakeInDate = work.EdiTakeInDate;
            data.EnterpriseCode = work.EnterpriseCode;
            data.EraNameDispCd1 = work.EraNameDispCd1;
            data.EstimaTaxDivCd = work.EstimaTaxDivCd;
            data.EstimateDivide = work.EstimateDivide;
            data.EstimateFormNo = work.EstimateFormNo;
            data.EstimateFormPrtCd = work.EstimateFormPrtCd;
            data.EstimateNote1 = work.EstimateNote1;
            data.EstimateNote2 = work.EstimateNote2;
            data.EstimateNote3 = work.EstimateNote3;
            data.EstimateNote4 = work.EstimateNote4;
            data.EstimateNote5 = work.EstimateNote5;
            data.EstimateSubject = work.EstimateSubject;
            data.EstimateTitle1 = work.EstimateTitle1;
            data.EstimateTitle2 = work.EstimateTitle2;
            data.EstimateTitle3 = work.EstimateTitle3;
            data.EstimateTitle4 = work.EstimateTitle4;
            data.EstimateTitle5 = work.EstimateTitle5;
            data.EstimateValidityDate = work.EstimateValidityDate;
            data.Footnotes1 = work.Footnotes1;
            data.Footnotes2 = work.Footnotes2;
            data.FractionProcCd = work.FractionProcCd;
            data.FrontEmployeeCd = work.FrontEmployeeCd;
            data.FrontEmployeeNm = work.FrontEmployeeNm;
            data.FullModel = work.FullModel;
            data.HonorificTitle = work.HonorificTitle;
            data.InputAgenCd = work.InputAgenCd;
            data.InputAgenNm = work.InputAgenNm;
            data.ItdedPartsDisInTax = work.ItdedPartsDisInTax;
            data.ItdedPartsDisOutTax = work.ItdedPartsDisOutTax;
            data.ItdedSalesDisInTax = work.ItdedSalesDisInTax;
            data.ItdedSalesDisOutTax = work.ItdedSalesDisOutTax;
            data.ItdedSalesDisTaxFre = work.ItdedSalesDisTaxFre;
            data.ItdedSalesInTax = work.ItdedSalesInTax;
            data.ItdedSalesOutTax = work.ItdedSalesOutTax;
            data.ItdedWorkDisInTax = work.ItdedWorkDisInTax;
            data.ItdedWorkDisOutTax = work.ItdedWorkDisOutTax;
            data.ListPricePrintDiv = work.ListPricePrintDiv;
            data.LogicalDeleteCode = work.LogicalDeleteCode;
            data.MakerFullName = work.MakerFullName;
            data.ModelDesignationNo = work.ModelDesignationNo;
            data.ModelFullName = work.ModelFullName;
            data.OptionPringDivCd = work.OptionPringDivCd;
            data.OrderNumber = work.OrderNumber;
            data.OutputName = work.OutputName;
            data.PartsDiscountRate = work.PartsDiscountRate;
            data.PartsNoPrtCd = work.PartsNoPrtCd;
            data.PartySaleSlipNum = work.PartySaleSlipNum;
            data.PosReceiptNo = work.PosReceiptNo;
            data.PureGoodsTtlTaxExc = work.PureGoodsTtlTaxExc;
            data.RateUseCode = work.RateUseCode;
            data.RavorDiscountRate = work.RavorDiscountRate;
            data.ReconcileFlag = work.ReconcileFlag;
            data.RegiProcDate = work.RegiProcDate;
            data.ResultsAddUpSecCd = work.ResultsAddUpSecCd;
            data.RetGoodsReason = work.RetGoodsReason;
            data.RetGoodsReasonDiv = work.RetGoodsReasonDiv;
            data.SalAmntConsTaxInclu = work.SalAmntConsTaxInclu;
            data.SalesAreaCode = work.SalesAreaCode;
            data.SalesAreaName = work.SalesAreaName;
            data.SalesDate = work.SalesDate;
            data.SalesDisOutTax = work.SalesDisOutTax;
            data.SalesDisTtlTaxExc = work.SalesDisTtlTaxExc;
            data.SalesDisTtlTaxInclu = work.SalesDisTtlTaxInclu;
            data.SalesEmployeeCd = work.SalesEmployeeCd;
            data.SalesEmployeeNm = work.SalesEmployeeNm;
            data.SalesGoodsCd = work.SalesGoodsCd;
            data.SalesInpSecCd = work.SalesInpSecCd;
            data.SalesInputCode = work.SalesInputCode;
            data.SalesInputName = work.SalesInputName;
            data.SalesNetPrice = work.SalesNetPrice;
            data.SalesOutTax = work.SalesOutTax;
            data.SalesPriceFracProcCd = work.SalesPriceFracProcCd;
            data.SalesPrtSubttlExc = work.SalesPrtSubttlExc;
            data.SalesPrtSubttlInc = work.SalesPrtSubttlInc;
            data.SalesPrtTotalTaxExc = work.SalesPrtTotalTaxExc;
            data.SalesPrtTotalTaxInc = work.SalesPrtTotalTaxInc;
            data.SalesSlipCd = work.SalesSlipCd;
            data.SalesSlipNum = work.SalesSlipNum;
            data.SalesSlipPrintDate = work.SalesSlipPrintDate;
            data.SalesSubtotalTax = work.SalesSubtotalTax;
            data.SalesSubtotalTaxExc = work.SalesSubtotalTaxExc;
            data.SalesSubtotalTaxInc = work.SalesSubtotalTaxInc;
            data.SalesTotalTaxExc = work.SalesTotalTaxExc;
            data.SalesTotalTaxInc = work.SalesTotalTaxInc;
            data.SalesWorkSubttlExc = work.SalesWorkSubttlExc;
            data.SalesWorkSubttlInc = work.SalesWorkSubttlInc;
            data.SalesWorkTotalTaxExc = work.SalesWorkTotalTaxExc;
            data.SalesWorkTotalTaxInc = work.SalesWorkTotalTaxInc;
            data.SalSubttlSubToTaxFre = work.SalSubttlSubToTaxFre;
            data.SearchSlipDate = work.SearchSlipDate;
            data.SectionCode = work.SectionCode;
            data.SectionGuideNm = work.SectionGuideNm;
            data.ShipmentDay = work.ShipmentDay;
            data.SlipAddressDiv = work.SlipAddressDiv;
            data.SlipNote = work.SlipNote;
            data.SlipNote2 = work.SlipNote2;
            data.SlipNote3 = work.SlipNote3;
            data.SlipPrintDivCd = work.SlipPrintDivCd;
            data.SlipPrintFinishCd = work.SlipPrintFinishCd;
            data.SlipPrtSetPaperId = work.SlipPrtSetPaperId;
            data.StockGoodsTtlTaxExc = work.StockGoodsTtlTaxExc;
            data.SubSectionCode = work.SubSectionCode;
            data.SubSectionName = work.SubSectionName;
            data.TotalAmountDispWayCd = work.TotalAmountDispWayCd;
            data.TotalCost = work.TotalCost;
            data.TtlAmntDispRateApy = work.TtlAmntDispRateApy;
            data.UoeRemark1 = work.UoeRemark1;
            data.UoeRemark2 = work.UoeRemark2;
            #endregion // コピー

            return data;
        }

        #region 各種区分名称の取得

        /// <summary>
        /// 受注ステータス名称を取得します。
        /// </summary>
        /// <param name="code">受注ステータス</param>
        /// <returns>受注ステータス名称</returns>
        public static string GetAcptAnOdrStatusName(int code, int estimateDivide)
        {
            switch (code)
            {
                case 10:
                    switch (estimateDivide)
                    {
                        case 2:
                            return "単価見積";
                        case 3:
                            return "検索見積";
                        case 1:
                        default:
                            return "見積";
                    }
                case 20:
                    return "受注";
                case 30:
                    return "売上";
                case 40:
                    return "貸出";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 赤伝区分名称を取得します。
        /// </summary>
        /// <param name="code">赤伝区分</param>
        /// <returns>赤伝区分名称</returns>
        public static string GetDebitNoteDivName(int code)
        {
            switch (code)
            {
                case 0:
                    return "黒伝";
                case 1:
                    return "赤伝";
                case 2:
                    return "元黒";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 売上伝票区分名称を取得します。
        /// </summary>
        /// <param name="code">売上伝票区分</param>
        /// <returns>売上伝票区分名称</returns>
        public static string GetSalesSlipCdName(int code)
        {
            switch (code)
            {
                case 0:
                    return "現金売上";
                case 1:
                    return "現金返品";
                case 2:
                    return "値引";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 注文方法名称を取得します。
        /// </summary>
        /// <param name="code">注文方法コード</param>
        /// <returns>注文方法名称</returns>
        public static string GetWayToOrderName(int code)
        {
            switch (code)
            {
                case 0:
                    return "店頭";
                case 1:
                    return "電話";
                case 2:
                    return "FAX";
                case 3:
                    return "インターネット";
                case 4:
                    return "システム連動";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 売掛区分名称を取得します。
        /// </summary>
        /// <param name="code">売掛区分</param>
        /// <returns>売掛区分名称</returns>
        public static string GetAccRecDivName(int code)
        {
            switch (code)
            {
                case 0:
                    return "売掛なし";
                case 1:
                    return "売掛あり";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 総額表示方法区分名称を取得します。
        /// </summary>
        /// <param name="code">総額表示方法区分</param>
        /// <returns>総額表示方法区分名称</returns>
        public static string GetTotalAmountDispWayName(int code)
        {
            switch (code)
            {
                case 0:
                    return "しない";
                case 1:
                    return "する";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 売上商品区分名称を取得します。
        /// </summary>
        /// <param name="code">売上商品区分</param>
        /// <returns>売上商品区分名称</returns>
        public static string GetSalesGoodsCdName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "商品";
                    }
                case 1:
                    {
                        return "商品外";
                    }
                case 2:
                    {
                        return "消費税調整";
                    }
                case 3:
                    {
                        return "残高調整";
                    }
                case 4:
                    {
                        return "売掛用消費税調整";
                    }
                case 5:
                    {
                        return "売掛用残高調整";
                    }
                case 10:
                    {
                        return "売掛用消費税調整(自動)";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        #endregion // 各種区分名称の取得

        #endregion // Public Static Method

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        /// <summary>
        /// 売上データ検索結果オブジェクトをデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="data">売上データ検索結果オブジェクト</param>
        private void CacheSalesSlipSearchResult(SalesSlipSearchResultWork data)
        {
            try
            {
                _dataSet.SalesSlip.AddSalesSlipRow(this.RowFromUIData(data));
            }
            catch (ConstraintException)
            {
            }
        }

        /// <summary>
        /// 売上データ(明細)検索結果オブジェクトをデータテーブルにキャッシュします。
        /// </summary>
        /// <param name="data">売上データ検索結果オブジェクト</param>
        private void CacheSalesSlipDetailSearchResult(SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip)
        {
            try
            {
                _dataSet.SalesDetail.AddSalesDetailRow(this.DetailRowFromUIData(data, slip));
            }
            catch (ConstraintException)
            {
            }
        }


        /// <summary>
        /// 売上データ検索結果オブジェクトから売上データ検索結果行クラスを取得します。
        /// </summary>
        /// <param name="data">売上データ検索結果オブジェクト</param>
        /// <returns>売上データ検索結果行クラス</returns>
        private SimpleInqCTIDataSet.SalesSlipRow RowFromUIData(SalesSlipSearchResultWork data)
        {
            SimpleInqCTIDataSet.SalesSlipRow row = _dataSet.SalesSlip.NewSalesSlipRow();

            this.SetRowFromUIData(ref row, data);
            return row;
        }

        /// <summary>
        /// 売上データ(明細)検索結果オブジェクトから売上データ検索結果行クラスを取得します。
        /// </summary>
        /// <param name="data">売上データ検索結果オブジェクト</param>
        /// <returns>売上データ検索結果行クラス</returns>
        private SimpleInqCTIDataSet.SalesDetailRow DetailRowFromUIData(SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip)
        {
            SimpleInqCTIDataSet.SalesDetailRow row = _dataSet.SalesDetail.NewSalesDetailRow();

            this.SetDetailRowFromUIData(ref row, data, slip);
            return row;
        }

        private Employee SearchStatic(string employeeCode)
        {
            return _employeeList.Find(
                delegate(Employee emp)
                {
                    return ( emp.EmployeeCode.Trim().Equals(employeeCode.Trim()) );
                });
        }

        /// <summary>
        /// 売上データ検索結果ワーク→売上データ行クラス設定処理
        /// </summary>
        /// <param name="row">売上データ行クラス</param>
        /// <param name="data">売上データ検索結果ワークオブジェクト</param>
        private void SetRowFromUIData(ref SimpleInqCTIDataSet.SalesSlipRow row, SalesSlipSearchResultWork data)    // MEMO:検索結果を保持
        {
            #region 項目コピー
            long salesTotalTaxExc;
            long salesSubtotalTax;
            long salesTotalTaxInc;

            // taxIsSum = true(表示するのは外税＋内税), false(内税のみ)
            bool taxIsSum;
            # region [taxIsSum]
            switch (data.TotalAmountDispWayCd)
            {
                case 1:
                    {
                        // 総額表示する
                        taxIsSum = true;
                    }
                    break;
                case 0:
                default:
                    {
                        // 総額表示しない

                        switch (data.ConsTaxLayMethod)
                        {
                            // 0:伝票単位
                            case 0:
                            // 1:明細単位
                            case 1:
                                {
                                    taxIsSum = true;
                                }
                                break;
                            // 2:請求親
                            case 2:
                            // 3:請求子
                            case 3:
                            // 9:非課税
                            case 9:
                            default:
                                {
                                    taxIsSum = false;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            if (taxIsSum)
            {
                // 税＝外税＋内税
                salesTotalTaxExc = data.SalesTotalTaxExc;
                salesSubtotalTax = data.SalesSubtotalTax;
                salesTotalTaxInc = data.SalesTotalTaxInc;
            }
            else
            {
                // 税＝内税
                salesTotalTaxExc = data.SalesTotalTaxExc;
                salesSubtotalTax = data.SalAmntConsTaxInclu + data.SalesDisTtlTaxInclu;
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }

            # region [売上商品区分]
            if (( data.SalesGoodsCd == 2 ) || ( data.SalesGoodsCd == 4 ))
            {
                // 2:消費税調整,4:売掛用消費税調整
                salesTotalTaxExc = 0;
            }
            else if (( data.SalesGoodsCd == 3 ) || ( data.SalesGoodsCd == 5 ))
            {
                // 3:残高調整,5:売掛用残高調整
                salesTotalTaxExc = salesTotalTaxInc;
                salesSubtotalTax = 0;
            }
            # endregion

            // 値をセット
            row.SalesTotalTaxExc = salesTotalTaxExc;
            row.SalesSubtotalTax = salesSubtotalTax;
            row.SalesTotalTaxInc = salesTotalTaxInc;

            row.RowNo = _rowNo;
            row.EnterpriseCode = data.EnterpriseCode;

            row.AcptAnOdrStatus = data.AcptAnOdrStatus;
            row.AcptAnOdrStatusName = GetAcptAnOdrStatusName(data.AcptAnOdrStatus, data.EstimateDivide);
            row.SearchSlipNum = data.SalesSlipNum;
            row.DebitNoteDiv = data.DebitNoteDiv;
            row.DebitNoteDivName = GetDebitNoteDivName(data.DebitNoteDiv);
            row.SalesSlipCd = data.SalesSlipCd;
            row.SalesSlipCdName = GetSalesSlipCdName(data.SalesSlipCd);

            // 伝票日付 (伝票種別に従う(明細毎))
            if (data.AcptAnOdrStatus == 40)
            {
                // 貸出 → 出荷日をセットする
                row.SlipDateString = GetDateTimeString(data.ShipmentDay, ct_DateFormat);
            }
            else
            {
                // 貸出以外 → 売上日をセットする
                row.SlipDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);
            }

            // 出荷日
            row.ShipmentDayString = GetDateTimeString(data.ShipmentDay, ct_DateFormat);
            // 売上日
            row.SalesDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);
            // 計上日
            row.AddUpADateString = GetDateTimeString(data.AddUpADate, ct_DateFormat);

            row.FrontEmployeeNm = data.FrontEmployeeNm;
            row.SalesEmployeeNm = data.SalesEmployeeNm;
            row.AccRecDivCd = data.AccRecDivCd;
            row.AccRecDivName = GetAccRecDivName(data.AccRecDivCd);
            row.TotalAmountDispWayCd = data.TotalAmountDispWayCd;
            row.TotalAmountDispWayName = GetTotalAmountDispWayName(data.TotalAmountDispWayCd);

            row.TotalCost = data.TotalCost;
            row.SalesGoodsCd = data.SalesGoodsCd;
            row.SalesGoodsCdName = GetSalesGoodsCdName(data.SalesGoodsCd);
            row.ClaimCode = data.ClaimCode;
            row.ClaimName = data.ClaimSnm;
            row.CustomerCode = data.CustomerCode;
            row.CustomerName = data.CustomerName + " " + data.CustomerName2;
            row.SlipNote = data.SlipNote;
            row.SlipNote2 = data.SlipNote2;

            row.SearchSlipDate = data.SearchSlipDate;
            row.EstimateDivide = data.EstimateDivide;

            row.DetailRowCount = data.DetailRowCount;

            row.SectionName = data.SectionGuideNm;
            row.SubSectionName = data.SubSectionName;

            // 新規列を追加する
            row.InputAgenCd = data.InputAgenCd;
            row.InputAgenNm = data.InputAgenNm;
            row.SalesPrtTotalTaxInc = data.SalesPrtTotalTaxInc;
            row.SalesPrtTotalTaxExc = data.SalesPrtTotalTaxExc;
            row.SalesWorkTotalTaxInc = data.SalesWorkTotalTaxInc;
            row.SalesWorkTotalTaxExc = data.SalesWorkTotalTaxExc;
            row.SalesPrtSubttlInc = data.SalesPrtSubttlInc;
            row.SalesPrtSubttlExc = data.SalesPrtSubttlExc;
            row.SalesWorkSubttlInc = data.SalesWorkSubttlInc;
            row.SalesWorkSubttlExc = data.SalesWorkSubttlExc;
            row.SalesNetPrice = data.SalesNetPrice;
            row.SalesOutTax = data.SalesOutTax;
            row.ItdedPartsDisOutTax = data.ItdedPartsDisOutTax;
            row.ItdedPartsDisInTax = data.ItdedPartsDisInTax;
            row.ItdedWorkDisOutTax = data.ItdedWorkDisOutTax;
            row.ItdedWorkDisInTax = data.ItdedWorkDisInTax;
            row.ItdedSalesDisTaxFre = data.ItdedSalesDisTaxFre;
            row.PartsDiscountRate = data.PartsDiscountRate;
            row.RavorDiscountRate = data.RavorDiscountRate;
            row.OutputName = data.OutputName;
            row.CustSlipNo = data.CustSlipNo;
            row.SlipNote3 = data.SlipNote3;
            row.EstimateValidityDateString = GetDateTimeString(data.EstimateValidityDate, ct_DateFormat);
            row.PartsNoPrtCd = data.PartsNoPrtCd;
            row.OptionPringDivCd = data.OptionPringDivCd;
            row.RateUseCode = data.RateUseCode;

            // 発行者
            row.SalesInputCode = data.SalesInputCode;          // コード
            row.SalesInputName = data.SalesInputName;          // 表示名

            // 類別型式 (型式指定番号+類別番号)
            # region [類別型式 00000-0000]
            if (data.ModelDesignationNo == 0 && data.CategoryNo == 0)
            {
                row.CategoryModel = string.Empty;
            }
            else
            {
                row.CategoryModel = string.Empty;

                // 型式指定番号
                if (data.ModelDesignationNo == 0)
                {
                    row.CategoryModel += new string(' ', 5);
                }
                else
                {
                    row.CategoryModel += data.ModelDesignationNo.ToString("00000");
                }

                // ハイフン
                row.CategoryModel += '-';

                // 類別番号
                if (data.CategoryNo == 0)
                {
                }
                else
                {
                    row.CategoryModel += data.CategoryNo.ToString("0000");
                }
            }
            # endregion

            // 車種名称
            row.ModelFullName = data.ModelFullName;

            // 型式
            row.FullModel = data.FullModel;
            // 計上日
            row.AddUpADateString = GetDateTimeString(data.AddUpADate, ct_DateFormat);
            // リマーク1
            row.UoeRemark1 = data.UoeRemark1;
            // 管理番号
            row.CarMngCode = data.CarMngCode;
            // 伝票区分
            // 検索見積(data.EstimateDivide == 3)の時は空白
            if (data.EstimateDivide != 3)
            {
                switch (data.SalesSlipCd)
                {
                    case 0: //0:売上
                        if (data.AccRecDivCd == 0) // 0:売掛なし
                        {
                            row.SlipDivName = "現金売上";
                        }
                        else // 1:売掛
                        {
                            row.SlipDivName = "掛売上";
                        }
                        break;

                    case 1: //1:返品
                        if (data.AccRecDivCd == 0) // 0:売掛なし
                        {
                            row.SlipDivName = "現金返品";
                        }
                        else // 1:売掛
                        {
                            row.SlipDivName = "掛返品";
                        }
                        break;

                    case 2: //2:値引
                        if (data.AccRecDivCd == 0) // 0:売掛なし
                        {
                            row.SlipDivName = "値引";
                        }
                        else // 1:売掛
                        {
                            row.SlipDivName = "掛値引";
                        }
                        break;

                    case 100: //100:現金売上
                        if (data.AccRecDivCd == 0) // 0:売掛なし
                        {
                            row.SlipDivName = "現金売上";
                        }
                        else // 1:売掛
                        {
                            row.SlipDivName = "掛現金売上";
                        }
                        break;

                    case 101: //101:現金返品
                        if (data.AccRecDivCd == 0) // 0:売掛なし
                        {
                            row.SlipDivName = "現金返品";
                        }
                        else // 1:売掛
                        {
                            row.SlipDivName = "掛現金返品";
                        }
                        break;

                    case 102: //102:現金値引
                        if (data.AccRecDivCd == 0) // 0:売掛なし
                        {
                            row.SlipDivName = "現金値引";
                        }
                        else // 1:売掛
                        {
                            row.SlipDivName = "掛現金値引";
                        }
                        break;

                    default:
                        break;
                }
            }
            row.SalesSlipSearchResultWork = data;

            row.CarMngCode = data.CarMngCode;

            #endregion // 項目コピー
        }


        /// <summary>
        /// 売上データ検索結果ワーク→売上データ行クラス設定処理
        /// </summary>
        /// <param name="row">売上データ行クラス</param>
        /// <param name="data">売上データ検索結果ワークオブジェクト</param>
        private void SetDetailRowFromUIData(ref SimpleInqCTIDataSet.SalesDetailRow row, SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip)
        {
            #region 項目コピー

            long salesMoneyTaxExc;
            long salsePriceConsTax;
            long salesMoneyTaxInc;

            bool printTax = true;

            # region [printTax]
            switch (GetTaxPrintType(slip))
            {
                case 0:
                default:
                    {
                        // 伝票単位（明細毎の消費税は表示しない）
                        printTax = false;
                    }
                    break;
                case 1:
                    {
                        // 明細単位/総額表示
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        // 請求親子・非課税（課税区分＝内税のみ表示）
                        // 課税区分（0:課税,1:非課税,2:課税（内税））
                        switch (data.TaxationDivCd)
                        {
                            case 0:
                            case 1:
                            default:
                                {
                                    printTax = false;
                                }
                                break;
                            case 2:
                                {
                                    printTax = true;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            if (printTax)
            {
                // 税表示
                salesMoneyTaxExc = data.SalesMoneyTaxExc;
                salsePriceConsTax = data.SalesMoneyTaxInc - data.SalesMoneyTaxExc;
                salesMoneyTaxInc = data.SalesMoneyTaxInc;
            }
            else
            {
                // 税非表示
                salesMoneyTaxExc = data.SalesMoneyTaxExc;
                salsePriceConsTax = 0;
                salesMoneyTaxInc = salesMoneyTaxExc;
            }

            # region [売上商品区分]
            if (( slip.SalesGoodsCd == 2 ) || ( slip.SalesGoodsCd == 4 ))
            {
                // 2:消費税調整,4:売掛用消費税調整
                salesMoneyTaxExc = 0;
            }
            else if (( slip.SalesGoodsCd == 3 ) || ( slip.SalesGoodsCd == 5 ))
            {
                // 3:残高調整,5:売掛用残高調整
                salesMoneyTaxExc = salesMoneyTaxInc;
                salsePriceConsTax = 0;
            }
            # endregion


            // 値をセット
            row.SalesMoneyTaxExc = salesMoneyTaxExc;
            row.SalsePriceConsTax = salsePriceConsTax;
            row.SalesMoneyTaxInc = salesMoneyTaxInc;

            row.AcptAnOdrStatus = data.AcptAnOdrStatus;
            row.SalesSlipNum = data.SalesSlipNum;
            row.SalesRowNo = data.SalesRowNo;
            row.SectionCode = data.SectionCode;
            row.SubSectionCode = data.SubSectionCode;

            row.SalesDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);

            row.CommonSeqNo = data.CommonSeqNo;
            row.SalesSlipDtlNum = data.SalesSlipDtlNum;
            row.AcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
            row.SalesSlipDtlNumSrc = data.SalesSlipDtlNumSrc;
            row.SalesSlipCdDtl = data.SalesSlipCdDtl;

            row.DeliGdsCmpltDueDateString = GetDateTimeString(data.DeliGdsCmpltDueDate, ct_DateFormat);

            row.GoodsKindCode = data.GoodsKindCode;
            row.GoodsMakerCd = data.GoodsMakerCd;
            row.MakerName = data.MakerName;
            row.GoodsNo = data.GoodsNo;
            row.GoodsName = data.GoodsName;
            row.BLGoodsCode = data.BLGoodsCode;
            row.BLGoodsFullName = data.BLGoodsFullName;
            row.EnterpriseGanreCode = data.EnterpriseGanreCode;
            row.EnterpriseGanreName = data.EnterpriseGanreName;
            row.WarehouseCode = data.WarehouseCode;
            row.WarehouseName = data.WarehouseName;
            row.WarehouseShelfNo = data.WarehouseShelfNo;
            row.SalesOrderDivCd = data.SalesOrderDivCd;
            row.GoodsRateRank = data.GoodsRateRank;
            row.CustRateGrpCode = data.CustRateGrpCode;
            row.ListPriceRate = data.ListPriceRate;
            row.RateDivLPrice = data.RateDivLPrice;
            row.UnPrcCalcCdLPrice = data.UnPrcCalcCdLPrice;
            row.PriceCdLPrice = data.PriceCdLPrice;
            row.StdUnPrcLPrice = data.StdUnPrcLPrice;
            row.FracProcUnitLPrice = data.FracProcUnitLPrice;
            row.FracProcLPrice = data.FracProcLPrice;
            row.ListPriceTaxIncFl = data.ListPriceTaxIncFl;
            row.ListPriceTaxExcFl = data.ListPriceTaxExcFl;
            row.ListPriceChngCd = data.ListPriceChngCd;
            row.SalesRate = data.SalesRate;
            row.RateDivSalUnPrc = data.RateDivSalUnPrc;
            row.UnPrcCalcCdSalUnPrc = data.UnPrcCalcCdSalUnPrc;
            row.PriceCdSalUnPrc = data.PriceCdSalUnPrc;
            row.StdUnPrcSalUnPrc = data.StdUnPrcSalUnPrc;
            row.FracProcUnitSalUnPrc = data.FracProcUnitSalUnPrc;
            row.FracProcSalUnPrc = data.FracProcSalUnPrc;
            row.SalesUnPrcTaxIncFl = data.SalesUnPrcTaxIncFl;
            row.SalesUnPrcTaxExcFl = data.SalesUnPrcTaxExcFl;
            row.SalesUnPrcChngCd = data.SalesUnPrcChngCd;
            row.CostRate = data.CostRate;
            row.RateDivUnCst = data.RateDivUnCst;
            row.UnPrcCalcCdUnCst = data.UnPrcCalcCdUnCst;
            row.PriceCdUnCst = data.PriceCdUnCst;
            row.StdUnPrcUnCst = data.StdUnPrcUnCst;
            row.FracProcUnitUnCst = data.FracProcUnitUnCst;
            row.FracProcUnCst = data.FracProcUnCst;
            row.SalesUnitCost = data.SalesUnitCost;
            row.SalesUnitCostChngDiv = data.SalesUnitCostChngDiv;
            row.ShipmentCnt = data.ShipmentCnt;


            row.Cost = data.Cost;
            row.GrsProfitChkDiv = data.GrsProfitChkDiv;
            row.SalesGoodsCd = data.SalesGoodsCd;
            row.TaxationDivCd = data.TaxationDivCd;
            row.PartySlipNumDtl = data.PartySlipNumDtl;
            row.DtlNote = data.DtlNote;
            row.SupplierCd = data.SupplierCd;
            row.SupplierSnm = data.SupplierSnm;
            row.OrderNumber = data.OrderNumber;
            row.AcceptAnOrderCnt = data.AcceptAnOrderCnt;
            row.AcptAnOdrAdjustCnt = data.AcptAnOdrAdjustCnt;
            row.AcptAnOdrRemainCnt = data.AcptAnOdrRemainCnt;
            row.SlipMemo1 = data.SlipMemo1;
            row.SlipMemo2 = data.SlipMemo2;
            row.SlipMemo3 = data.SlipMemo3;
            row.InsideMemo1 = data.InsideMemo1;
            row.InsideMemo2 = data.InsideMemo2;
            row.InsideMemo3 = data.InsideMemo3;
            row.BfListPrice = data.BfListPrice;
            row.BfSalesUnitPrice = data.BfSalesUnitPrice;
            row.BfUnitCost = data.BfUnitCost;

            // 新規列を追加
            row.SalesRowDerivNo = data.SalesRowDerivNo;
            row.GoodsSearchDivCd = data.GoodsSearchDivCd;
            row.GoodsLGroup = data.GoodsLGroup;
            row.GoodsLGroupName = data.GoodsLGroupName;
            row.GoodsMGroup = data.GoodsMGroup;
            row.GoodsMGroupName = data.GoodsMGroupName;
            row.BLGroupCode = data.BLGroupCode;
            row.BLGroupName = data.BLGroupName;
            row.PrtBLGoodsCode = data.PrtBLGoodsCode;
            row.PrtBLGoodsName = data.PrtBLGoodsName;
            row.SalesCode = data.SalesCode;
            row.SalesCdNm = data.SalesCdNm;
            row.WorkManHour = data.WorkManHour;
            row.WayToOrder = data.WayToOrder;

            // 原価金額(原価単価 * 売上数)
            row.SalesUnitTotal = data.SalesUnitCost * data.AcceptAnOrderCnt;

            #endregion // 項目コピー
        }

        #endregion // Private Method

        // ===================================================================================== //
        // プライベートスタティックメソッド
        // ===================================================================================== //
        #region ■ Private Static Method

        /// <summary>
        /// リモート用のパラメータをUIデータから作成します。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="extractSlipCdType"></param>
        /// <param name="showEstimateInput"></param>
        /// <returns></returns>
        private static SalesSlipSearchWork CreateParamDataFromUIData(SalesSlipSearch data, int extractSlipCdType, bool showEstimateInput)
        {
            SalesSlipSearchWork work = new SalesSlipSearchWork();

            #region 項目コピー

            // 全て
            if (data.SalesSlipCd == -1)
            {
                // MEMO 暫定的に「検索見積」+「全て」の場合は売上伝票区分=0で作成
                if (data.AcptAnOdrStatus == 16)
                {
                    work.SalesSlipCd = 0;
                }
                else
                {
                    work.SalesSlipCd = -1;
                }
                work.AccRecDivCd = -1;
            }
            //現金売上
            else if (data.SalesSlipCd == 100)
            {
                work.SalesSlipCd = 0;
                work.AccRecDivCd = 0;
            }
            //現金返品
            else if (data.SalesSlipCd == 101)
            {
                work.SalesSlipCd = 1;
                work.AccRecDivCd = 0;
            }
            //掛売上・掛返品
            else
            {
                work.SalesSlipCd = data.SalesSlipCd;
                work.AccRecDivCd = 1;
            }

            //単価見積
            if (data.AcptAnOdrStatus == 15)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 2;
            }
            else if (data.AcptAnOdrStatus == 10)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 1;
            }
            // 検索見積
            else if (data.AcptAnOdrStatus == 16)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 3;
            }
            //その他
            else
            {
                work.AcptAnOdrStatus = data.AcptAnOdrStatus;
                work.EstimateDivide = 0;
            }

            if (extractSlipCdType == 1)
            {
                work.SalesSlipCd = 0;
            }

            if (showEstimateInput == false)
            {
                work.EstimateDivide = -1;
            }

            work.ClaimCode = data.ClaimCode;
            work.CustomerCode = data.CustomerCode;
            work.EnterpriseCode = data.EnterpriseCode;
            work.FrontEmployeeCd = data.FrontEmployeeCd;
            work.SalesEmployeeCd = data.SalesEmployeeCd;
            work.GoodsMakerCd = data.GoodsMakerCd;
            work.GoodsNo = data.GoodsNo;

            work.SalesDateSt = GetLongDate(data.SalesDateSt);
            work.SalesDateEd = GetLongDate(data.SalesDateEd);
            work.ShipmentDaySt = GetLongDate(data.SalesDateSt); // 出荷日条件も常に売上日をセット
            work.ShipmentDayEd = GetLongDate(data.SalesDateEd); // 出荷日条件も常に売上日をセット

            work.SalesInputCode = data.SalesInputCode;

            work.SalesSlipNumSt = data.SalesSlipNumSt;
            work.SalesSlipNumEd = data.SalesSlipNumEd;
            work.PartySaleSlipNum = data.PartySaleSlipNum;

            if (data.SearchSlipDateSt == DateTime.MinValue) work.SearchSlipDateSt = 0;
            else work.SearchSlipDateSt = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SearchSlipDateSt);
            if (data.SearchSlipDateEd == DateTime.MinValue) work.SearchSlipDateEd = 0;
            else work.SearchSlipDateEd = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SearchSlipDateEd);

            try
            {
                if (Int32.Parse(data.SectionCode.Trim()) == 0)
                {
                    work.SectionCode = string.Empty;
                }
                else
                {
                    work.SectionCode = data.SectionCode;
                }
            }
            catch
            {
                work.SectionCode = data.SectionCode;
            }
            work.SubSectionCode = data.SubSectionCode;
            // 型式*対応
            string searchText;
            int searchType;
            GetSearchType(data.FullModel, out searchText, out searchType);
            work.FullModel = searchText;
            work.FullModelSrchTyp = searchType;

            #endregion

            return work;
        }

        /// <summary>
        /// 日付数値取得処理
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetLongDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return ( ( date.Year * 10000 ) + ( date.Month * 100 ) + ( date.Day ) );
            }
        }

        /// <summary>
        /// UIデータオブジェクトからパラメータオブジェクトを生成します。
        /// </summary>
        /// <param name="data">UIデータオブジェクト</param>
        /// <returns>パラメータオブジェクト</returns>
        private static SalesSlipDetailSearchWork CreateDetailParamDataFromUIData(SalesSlipDetailSearch data)
        {
            SalesSlipDetailSearchWork work = new SalesSlipDetailSearchWork();

            work.EnterpriseCode = data.EnterpriseCode;
            work.AcptAnOdrStatus = data.AcptAnOdrStatus;
            work.SalesSlipNum = data.SalesSlipNum;
            return work;
        }

        /// <summary>
        /// 日付文字列を取得します。
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="format">フォーマット文字列</param>
        /// <returns>日付文字列</returns>
        private static string GetDateTimeString(DateTime date, string format)
        {
            if (date == DateTime.MinValue)
            {
                return "";
            }
            else
            {
                return date.ToString(format);
            }
        }

        /// <summary>
        /// 文字列あいまい検索情報取得
        /// </summary>
        /// <param name="originText">元の入力文字列</param>
        /// <param name="searchText">リモートアセンブリに渡す検索文字列</param>
        /// <param name="searchType">リモートアセンブリに渡す検索タイプ</param>
        /// <returns></returns>
        private static void GetSearchType(string originText, out string searchText, out int searchType)
        {
            searchText = originText;
            bool stLike = originText.StartsWith("*");
            bool edLike = originText.EndsWith("*");

            if (stLike)
            {
                // 先頭の * を取り除く
                searchText = searchText.Substring(1);
            }
            if (edLike)
            {
                // 末尾の * を取り除く
                searchText = searchText.Substring(0, searchText.Length - 1);
            }

            // 先頭＆末尾の*を取り除いてもまだ*がある場合→3:あいまい
            if (searchText.Contains("*"))
            {
                searchText = searchText.Replace("*", "");
                searchType = 3;
                return;
            }


            // 検索タイプの判定
            if (stLike)
            {
                if (edLike)
                {
                    // 3:あいまい
                    searchType = 3;
                }
                else
                {
                    // 2:後方一致
                    searchType = 2;
                }
            }
            else
            {
                if (edLike)
                {
                    // 1:前方一致
                    searchType = 1;
                }
                else
                {
                    // 0:完全一致
                    searchType = 0;
                }
            }
        }

        /// <summary>
        /// 消費税表示タイプ取得
        /// </summary>
        /// <param name="slipWork"></param>
        /// <returns>TaxPrintType（0:伝票単位, 1:明細単位/総額表示あり, 2:請求親/請求子/非課税）</returns>
        private static int GetTaxPrintType(SalesSlipSearchResult slip)
        {
            // 総額表示方法
            switch (slip.TotalAmountDispWayCd)
            {
                case 1:
                    // 総額表示する
                    return 1;
                case 0:
                default:
                    // 総額表示しない
                    switch (slip.ConsTaxLayMethod)
                    {
                        // 0:伝票単位
                        case 0:
                            return 0;
                        // 1:明細単位
                        case 1:
                            return 1;
                        // 2:請求親
                        case 2:
                        // 3:請求子
                        case 3:
                        // 9:非課税
                        case 9:
                        default:
                            return 2;
                    }
            }
        }
        #endregion // Private Static Method
    }
}
