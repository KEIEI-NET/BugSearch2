//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム概要   : 出品一括更新 アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/01/22   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 出品一括更新 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 出品一括更新で使用するデータを取得する。</br>
    /// <br>Programmer  : 宋剛</br>
    /// <br>Date        : 2016/01/22</br>
    /// </remarks>
    public class PartsMaxStockUpdateAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 出品一括更新データテキスト出力アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 出品一括更新データテキスト出力アクセスクラスの初期化を行う。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public PartsMaxStockUpdateAcs()
        {
            this._iPartsMaxStockUpdDB = (IPartsMaxStockUpdDB)MediationPartsMaxStockUpdDB.GetPartsMaxStockUpdDB();


            #region ◎ 売価算出用データ初期化
            // 全て仕入情報取得
            GetAllSuppInfo();

            // 売上金額処理区分設定と自社情報を取得
            GetSalesProcMoneyInfo();

            // 税率情報取得
            GetTaxInfo();

            // 売上全体初期値取得
            GetSalesTtlStInfo();
            #endregion
        }

        /// <summary>
        /// 得意先相関情報取得（得意先掛率グループ情報など）
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <remarks>
        /// <br>Note        : 得意先相関情報取得（得意先掛率グループ情報など）</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public void InitCustomerInfo(PartsMaxStockUpdateCndtnWork cndtnWork)
        {
            // 得意先掛率グループ情報リスト取得処理
            GetAllCustomRateGroupList(cndtnWork);

            // 得意先情報取得
            GetCustomerInfo(cndtnWork);
        }
        #endregion ■ Constructor

        #region ■ Private Member
        private IPartsMaxStockUpdDB _iPartsMaxStockUpdDB;
        /// <summary></summary>
        private string M_022 = "関連項目取得中にエラーが発生しました。\r\n[項目={0},ステータス={1},メッセージ={2}]";
        #region ◎ Private Member(売価・売価率計算)
        // すべて仕入先情報リスト
        Dictionary<int, Supplier> _allSupplierDic;

        // 得意先掛率アクセス
        CustRateGroupAcs _custRateGroupAcs;

        // 得意先の得意先掛率グループDictionary
        Dictionary<int, List<CustRateGroup>> _gustRateGroupList = new Dictionary<int, List<CustRateGroup>>();

        // 単価算出処理を行う
        UnitPriceCalculation _unitPriceCalculation = new UnitPriceCalculation();

        // 得意先情報
        CustomerInfo _customerInfo;

        // 請求先情報
        CustomerInfo _claimInfo;

        // 税率設定
        TaxRateSet _taxRateSet;

        // 税率
        double _taxRateOfNow = 0;

        // 売上全体初期設定アクセス
        SalesTtlStAcs _salesTtlStAcs = new SalesTtlStAcs();

        // 売上全体初期設定情報
        SalesTtlSt _salesTtlSt = null;

        // 仕入先アクセス
        SupplierAcs _supplierAcs;

        // 純正メーカー最大コード
        private static readonly Int32 ctPureGoodsMakerCode = 999;
        #endregion

        #endregion ■ Private Member

        #region ■ Private Method

        #region ◎ 件数取得
        /// <summary>
        /// 件数取得
        /// </summary>
        /// <param name="moveCount">移動データ検索結果</param>
        /// <param name="cndtnWork">抽出条件</param>
        /// <param name="errMessage"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : 件数を取得する。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public int SearchCount(out int moveCount, PartsMaxStockUpdateCndtnWork cndtnWork, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            moveCount = 0; // 移動データ検索件数

            //-----------------------------------------------------------------------------
            // データ検索
            //-----------------------------------------------------------------------------
            errMessage = string.Empty;

            try
            {
                status = this._iPartsMaxStockUpdDB.SearchCount(out moveCount, (object)cndtnWork, out errMessage);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region ◎ 出品・在庫一括更新情報データ取得
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="retDataList">データリスト</param>
        /// <param name="cndtnWork">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="loopIndex">分割index</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public int SearchMain(out ArrayList retDataList, PartsMaxStockUpdateCndtnWork cndtnWork, out string errMsg,int loopIndex)
        {
            retDataList = null;
            return this.SearchProc(out retDataList, cndtnWork, out errMsg, loopIndex);
        }


        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="retDataList">データリスト</param>
        /// <param name="cndtnWork">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="loopIndex">分割index</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int SearchProc(out ArrayList retDataList, PartsMaxStockUpdateCndtnWork cndtnWork, out string errMsg, int loopIndex)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            retDataList = null;
            try
            {
                // データ取得  
                object retList = null;

        
                status = this._iPartsMaxStockUpdDB.Search(out retList,
                    cndtnWork,
                    out errMsg, loopIndex);
 

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        retDataList = (ArrayList)retList;

                        if (retDataList.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }

                        // 性能アップ
                        // 単価計算処理
                        string salesCalMessage = string.Empty;
                        status = PriceCalculation(ref retDataList, cndtnWork, out salesCalMessage);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            errMsg = string.Format(this.M_022, "売価率、販売単価", status, salesCalMessage);
                        }

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "データの取得に失敗しました";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        
        #endregion

        #region ◎ 売価と売価率の計算処理
        /// <summary>
        /// 売価と売価率の計算処理
        /// </summary>
        /// <param name="retDataList">出品・在庫一括更新データリスト</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売価と売価率の計算処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int PriceCalculation(ref ArrayList retDataList,
                    PartsMaxStockUpdateCndtnWork cndtnWork, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            ArrayList tempAl = (ArrayList)retDataList;
            //　フィルター処理を行います
            ArrayList retList = new ArrayList();

            try
            {
                string enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                string message = string.Empty;


                for (int i = 0; i < tempAl.Count; i++)
                {
                    PartsMaxStockUpdateResultWork tempWork = (PartsMaxStockUpdateResultWork)tempAl[i];

                    List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();

                    // 単価計算
                    GetPriceMain(cndtnWork, tempWork, out unitPriceCalcRetList);

                    if ((null != unitPriceCalcRetList) && (unitPriceCalcRetList.Count > 0))
                    {

                        for (int j = 0; j < unitPriceCalcRetList.Count; j++)
                        {
                            UnitPriceCalcRet unitPriceInfo = unitPriceCalcRetList[j];

                            switch (unitPriceInfo.UnitPriceKind)
                            {
                                case UnitPriceCalculation.ctUnitPriceKind_ListPrice: // 定価
                                    ((PartsMaxStockUpdateResultWork)tempAl[i]).ListPrice = unitPriceInfo.UnitPriceTaxExcFl;
                                    break;

                                case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice: // 売上単価
                                    ((PartsMaxStockUpdateResultWork)tempAl[i]).SalesUnitCost = unitPriceInfo.UnitPriceTaxExcFl;

                                    // 売価率の場合、設定します。
                                    if (unitPriceInfo.UnitPrcCalcDiv == (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal)
                                    {
                                        ((PartsMaxStockUpdateResultWork)tempAl[i]).SalesRateVal = unitPriceInfo.RateVal;
                                    }

                                    break;
                            }
                        }
                    }

                    // 売価がない場合、定価を設定する
                    if (((PartsMaxStockUpdateResultWork)tempAl[i]).SalesUnitCost == 0)
                    {
                        // 0:ゼロを表示　1:定価を表示
                        if (_salesTtlSt.UnPrcNonSettingDiv == 0)
                        {
                            ((PartsMaxStockUpdateResultWork)tempAl[i]).SalesUnitCost = 0;
                        }
                        else
                        {
                            ((PartsMaxStockUpdateResultWork)tempAl[i]).SalesUnitCost = ((PartsMaxStockUpdateResultWork)tempAl[i]).ListPrice;
                        }
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                status = -1;
                errMessage = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 全て仕入先情報検索
        /// </summary>
        private void GetAllSuppInfo()
        {
            // 初期化全て仕入先Dictionary
            _allSupplierDic = new Dictionary<int, Supplier>();

            // 全て仕入先情報を取得する
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }
            ArrayList retList = new ArrayList();
            int status = _supplierAcs.Search(out retList, LoginInfoAcquisition.EnterpriseCode);

            if (0 == status)
            {
                foreach (Supplier supplierWork in retList)
                {
                    if (!_allSupplierDic.ContainsKey(supplierWork.SupplierCd))
                    {
                        _allSupplierDic.Add(supplierWork.SupplierCd, supplierWork);
                    }
                }
            }

        }

        /// <summary>
        /// 得意先掛率グループ情報リスト取得処理
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <returns>得意先掛率グループ情報リスト</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ情報リスト取得処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void GetAllCustomRateGroupList(PartsMaxStockUpdateCndtnWork cndtnWork)
        {
            // 得意先掛率グループ情報
            ArrayList custRateGroupList;

            if (null == _custRateGroupAcs)
            {
                _custRateGroupAcs = new CustRateGroupAcs();
            }

            int status = _custRateGroupAcs.Search(out custRateGroupList, LoginInfoAcquisition.EnterpriseCode,cndtnWork.CustomerCode,
                    ConstantManagement.LogicalMode.GetData0);

            if (status == 0)
            {
                foreach (CustRateGroup tempCustRateGroup in custRateGroupList)
                {
                    if (_gustRateGroupList.ContainsKey(tempCustRateGroup.CustomerCode))
                    {
                        _gustRateGroupList[tempCustRateGroup.CustomerCode].Add(tempCustRateGroup);
                    }
                    else
                    {
                        List<CustRateGroup> tempCustRateGroupList = new List<CustRateGroup>();
                        tempCustRateGroupList.Add(tempCustRateGroup);
                        _gustRateGroupList.Add(tempCustRateGroup.CustomerCode, tempCustRateGroupList);
                    }
                }
            }
        } 

        /// <summary>
        /// 売上金額処理区分設定と自社情報を取得
        /// </summary>
        private void GetSalesProcMoneyInfo()
        {
            // 売上金額処理区分設定を取得
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            ArrayList aList;
            salesProcMoneyAcs.IsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
            int status_SalesProcMoneyAcs = salesProcMoneyAcs.Search(out aList, LoginInfoAcquisition.EnterpriseCode);
            List<SalesProcMoney> _salesProcMoneyList = new List<SalesProcMoney>();
            if (status_SalesProcMoneyAcs == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) _salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }

            _unitPriceCalculation.CacheSalesProcMoneyList(_salesProcMoneyList);




            CompanyInf companyInf;
            int status_CompanyInf = GetCompanyInf(out companyInf, LoginInfoAcquisition.EnterpriseCode);
            if (status_CompanyInf == (int)ConstantManagement.DB_Status.ctDB_NORMAL && companyInf != null)
            {
                _unitPriceCalculation.RatePriorityDiv = companyInf.RatePriorityDiv;
            }
        }

        /// <summary>
        /// 引数より自社情報設定マスタ取得処理
        /// </summary>
        /// <param name="companyInf">自社情報</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 引数より自社情報設定マスタ取得処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private int GetCompanyInf(out CompanyInf companyInf, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();

            status = companyInfAcs.Read(out companyInf, enterpriseCode);
            return status;
        }

        /// <summary>
        /// 得意先と請求先情報の取得
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        private void GetCustomerInfo(PartsMaxStockUpdateCndtnWork cndtnWork)
        {
            // 得意先名称取得
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            _customerInfo = new CustomerInfo();

            customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, cndtnWork.CustomerCode, out _customerInfo);


            _claimInfo = new CustomerInfo();

            if (null != _customerInfo && _customerInfo.ClaimCode != 0)
            {
                customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, _customerInfo.ClaimCode, out _claimInfo);
            }
        }

        private DateTime GetDateTimeFormInt(int dataTime)
        {
            DateTime tempDate = DateTime.MinValue;
            try
            {
                if (0 != dataTime)
                {
                    tempDate = DateTime.ParseExact(dataTime.ToString(),
                                        "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                }
            }
            catch
            {
                tempDate = DateTime.MinValue;
            }

            return tempDate;
        }

        /// <summary>
        /// 単価算出処理
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="resultWork">出品一括更新データ</param>
        /// <param name="unitPriceCalcRetList">単価算出したデータ</param>
        private void GetPriceMain(
            PartsMaxStockUpdateCndtnWork cndtnWork,
            PartsMaxStockUpdateResultWork resultWork,
            out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {

            // 価格計算用商品連結データリスト
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            // 価格計算用パラメータリスト
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            // 得意先コード取得
            int customerCode = cndtnWork.CustomerCode;

            #region 1 商品連結データオブジェクト設定
            // 商品連結データオブジェクト初期化
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            // メーカーコード  	
            goodsUnitData.GoodsMakerCd = resultWork.GoodsMakerCd;

            // 品番   
            goodsUnitData.GoodsNo = resultWork.GoodsNo;

            #region 価格リスト取得


            // 価格リスト取得
            goodsUnitData.GoodsPriceList = new List<GoodsPrice>();
            GoodsPrice tempGoodsPrice = new GoodsPrice();
            tempGoodsPrice.GoodsMakerCd = resultWork.GoodsMakerCd;
            tempGoodsPrice.GoodsNo = resultWork.GoodsNo;
            tempGoodsPrice.PriceStartDate = GetDateTimeFormInt(resultWork.PriceStartDate);
            tempGoodsPrice.ListPrice = resultWork.ListPrice;
            tempGoodsPrice.SalesUnitCost = resultWork.GpuSalesUnitCost; // 価格マスタの原価単価
            tempGoodsPrice.StockRate = resultWork.StockRate;
            tempGoodsPrice.OpenPriceDiv = resultWork.OpenPriceDiv;
            tempGoodsPrice.OfferDate = GetDateTimeFormInt(resultWork.OfferDate);
            tempGoodsPrice.UpdateDate = GetDateTimeFormInt(resultWork.UpdateDate);

            goodsUnitData.GoodsPriceList.Add(tempGoodsPrice);
            #endregion

            // 課税区分
            goodsUnitData.TaxationDivCd = resultWork.TaxationDivCd;

            // リスト追加
            goodsUnitDataList.Add(goodsUnitData);
            #endregion 1 商品連結データオブジェクト設定

            #region 2 単価計算パラメータ設定
            // 単価計算パラメータ
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            // BLコード
            unitPriceCalcParam.BLGoodsCode = resultWork.BLGoodsCode;
            // BLグループコード
            unitPriceCalcParam.BLGroupCode = resultWork.BLGroupCode;
            // 数量
            unitPriceCalcParam.CountFl = 0;
            // 得意先コード
            unitPriceCalcParam.CustomerCode = cndtnWork.CustomerCode;

            #region 得意先掛率グループ情報リスト
            List<CustRateGroup> tempCustRateGroupList = new List<CustRateGroup>();
            // 得意先掛率グループ情報リスト取得処理
            tempCustRateGroupList = GetCustomRateGroupList(LoginInfoAcquisition.EnterpriseCode, cndtnWork.CustomerCode);

            // 得意先掛率グループデータ取得
            CustRateGroup tempCustRateGroup = this.GetCustRateGroup(ref tempCustRateGroupList, resultWork.GoodsMakerCd);
            if (null == tempCustRateGroup)
            {
                // 得意先掛率グループコード
                unitPriceCalcParam.CustRateGrpCode = -1;
            }
            else
            {
                // 得意先掛率グループコード
                unitPriceCalcParam.CustRateGrpCode = tempCustRateGroup.CustRateGrpCode;
            }
            #endregion

            // メーカーコード
            unitPriceCalcParam.GoodsMakerCd = resultWork.GoodsMakerCd;
            // 品番
            unitPriceCalcParam.GoodsNo = resultWork.GoodsNo;
            // ＢＬ商品コードマスタの商品掛率グループコード
            unitPriceCalcParam.GoodsRateGrpCode = resultWork.GoodsRateGrpCode;
            // 商品マスタの商品掛率ランク
            unitPriceCalcParam.GoodsRateRank = resultWork.GoodsRateRank;
            // 適用日:システム日付
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;
            // 得意先の売上消費税端数処理コード
            unitPriceCalcParam.SalesCnsTaxFrcProcCd = _customerInfo.SalesCnsTaxFrcProcCd;
            // 得意先の売上単価端数処理コード
            unitPriceCalcParam.SalesUnPrcFrcProcCd = _customerInfo.SalesUnPrcFrcProcCd;
            // 倉庫の管理拠点コード
            unitPriceCalcParam.SectionCode = resultWork.SectionCode;
            // 仕入先コード
            unitPriceCalcParam.SupplierCd = resultWork.SupplierCd;
            // 商品マスタの課税区分
            unitPriceCalcParam.TaxationDivCd = resultWork.TaxationDivCd;
            // 総額表示方法区分
            unitPriceCalcParam.TotalAmountDispWayCd = 0;
            // 総額表示掛率適用区分 0:(税込金額×掛率) 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)  
            unitPriceCalcParam.TtlAmntDspRateDivCd = 0;

            if (resultWork.SupplierCd != 0)
            {
                if (_allSupplierDic.ContainsKey(resultWork.SupplierCd))
                {
                    Supplier supplierWork = _allSupplierDic[resultWork.SupplierCd];


                    unitPriceCalcParam.StockCnsTaxFrcProcCd = supplierWork.StockCnsTaxFrcProcCd;                     // 仕入消費税端数処理コード   

                    unitPriceCalcParam.StockUnPrcFrcProcCd = supplierWork.StockUnPrcFrcProcCd;                      // 仕入単価端数処理コード    
                }
            }

            #region 消費税転嫁方式
            // 消費税転嫁方式
            if (cndtnWork.CustomerCode == 0)
            {
                // 消費税設定の消費税転嫁方式
                unitPriceCalcParam.ConsTaxLayMethod = _taxRateSet.ConsTaxLayMethod;
            }
            else
            {
                // 請求先の消費税転嫁方式
                unitPriceCalcParam.ConsTaxLayMethod = (_customerInfo.CustCTaXLayRefCd == 0) ? _taxRateSet.ConsTaxLayMethod : _claimInfo.ConsTaxLayMethod;
            }
            #endregion


            unitPriceCalcParamList.Add(unitPriceCalcParam);

            #endregion 2 単価計算パラメータ設定

            // 定価
            List<UnitPriceCalcRet> listPriceList = new List<UnitPriceCalcRet>();
            // 売単価
            List<UnitPriceCalcRet> salesUnitPriceList = new List<UnitPriceCalcRet>();
            // 定価
            _unitPriceCalculation.CalculateListPrice(unitPriceCalcParamList, goodsUnitDataList, out listPriceList);
            // 売単価
            _unitPriceCalculation.CalculateSalesUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out salesUnitPriceList);

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            if ((null != listPriceList) && (listPriceList.Count > 0))
            {
                unitPriceCalcRetList.AddRange(listPriceList.ToArray());
            }

            if ((null != salesUnitPriceList) && (salesUnitPriceList.Count > 0))
            {
                unitPriceCalcRetList.AddRange(salesUnitPriceList.ToArray());
            }
        }

        /// <summary>
        /// 得意先掛率グループ情報リスト取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先掛率グループ情報リスト</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ情報リスト取得処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private List<CustRateGroup> GetCustomRateGroupList(string enterpriseCode, int customerCode)
        {
            List<CustRateGroup> custRateGroupList = new List<CustRateGroup>();
            // 得意先があるの場合
            if (customerCode != 0)
            {
                // 得意先の得意先掛率グループ情報が存在する場合。
                if (_gustRateGroupList.ContainsKey(customerCode))
                {
                    custRateGroupList = _gustRateGroupList[customerCode];
                }
            }

            return custRateGroupList;
        }

        /// <summary>
        ///  得意先掛率グループ取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先掛率グループ情報リスト</param>
        /// <param name="goodsMakerCode">商品メーカーコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ取得処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private CustRateGroup GetCustRateGroup(ref List<CustRateGroup> custRateGroupList, int goodsMakerCode)
        {
            int pureCode = (goodsMakerCode <= ctPureGoodsMakerCode) ? 0 : 1; // 0:純正 1:優良

            // 単独キー
            CustRateGroup custRateGroup = custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == goodsMakerCode) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup;

            // 共通キー
            custRateGroup = custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == 0) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (custRateGroup != null)
            {

                return custRateGroup;
            }


            return null;
        }

        /// <summary>
        /// 税率情報取得
        /// </summary>
        private void GetTaxInfo()
        {
            // 税率設定情報取得
            if (null == _taxRateSet)
            {
                _taxRateSet = GetTaxRateSet(LoginInfoAcquisition.EnterpriseCode);

                // 税率情報取得
                _taxRateOfNow = GetTaxRate(_taxRateSet, DateTime.Now);
            }
        }

        /// <summary>
        /// 税率設定情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>税率設定情報</returns>
        /// <remarks>
        /// <br>Note       : 税率設定情報を取得処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private static TaxRateSet GetTaxRateSet(string enterpriseCode)
        {
            TaxRateSet _taxRateSet = null;
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                if (_taxRateSet == null)
                {
                    int status = taxRateSetAcs.Read(out _taxRateSet, enterpriseCode, 0);
                }

                if (_taxRateSet == null)
                {
                    _taxRateSet = new TaxRateSet();
                }

                return _taxRateSet;
            }
        }

        /// <summary>
        /// 税率を取得処理
        /// </summary>
        /// <param name="taxRateSet">税率設定情報</param>
        /// <param name="targetDate">税率適用日</param>
        /// <returns>税率</returns>
        /// <remarks>
        /// <br>Note       : 税率を取得処理を行う。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private static double GetTaxRate(
            TaxRateSet taxRateSet,
            DateTime targetDate)
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }

        /// <summary>
        /// 売上全体初期値取得
        /// </summary>
        /// <returns>売上全体初期値</returns>
        private void GetSalesTtlStInfo()
        {
            _salesTtlSt = new SalesTtlSt();
            int status = _salesTtlStAcs.Read(out _salesTtlSt, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = _salesTtlStAcs.Read(out _salesTtlSt, LoginInfoAcquisition.EnterpriseCode, "00");
            }
        }


        #endregion

        #endregion ■ Private Method
    }
}
