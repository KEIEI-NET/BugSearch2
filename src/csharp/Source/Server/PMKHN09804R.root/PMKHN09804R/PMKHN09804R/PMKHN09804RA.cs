using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 初期取得マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 初期取得マスタを取得するリモートです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2010/04/22</br>
    /// <br>
    /// <br>Update Note : 2010/05/30 20056 對馬 大輔 </br>
    /// <br>              成果物統合</br>
    /// <br>
    /// <br>Update Note : 2011/09/27 20056 對馬 大輔 </br>
    /// <br>              在庫管理全体設定の取得追加</br>
    /// </remarks>
    [Serializable]
    public class VariousMasterSearchDB : RemoteWithAppLockDB, IVariousMasterSearchDB
    {
        /// <summary>
        /// 初期取得マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        public VariousMasterSearchDB()
            //:
            //base("PMKEN06064D", "Broadleaf.Application.Remoting.VariousMasterSearchDB", "JOINPARTSURF")
        {
        }

        /// <summary>
        /// 初期取得マスタ取得処理
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int Search(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(ref retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "VariousMasterSearchDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 初期取得マスタ取得処理
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        private int SearchProc(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProcP(ref retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 初期取得マスタ取得処理
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        private int SearchProcP(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
            for (int i = 0; i < paraList.Count; i++)
            {
                Type wktype = paraList[i].GetType();
                switch (wktype.Name)
                {
                    #region 部門
                    case "SubSectionWork":
                        {
                            SubSectionDB subSectionDB = new SubSectionDB();
                            ArrayList retal = new ArrayList();
                            SubSectionWork subSectionWork = paraList[i] as SubSectionWork;
                            status = subSectionDB.SearchSubSectionProc(out retal, subSectionWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 得意先掛率グループコードマスタ
                    case "CustRateGroupWork":
                        {
                            CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                            ArrayList retal = new ArrayList();
                            CustRateGroupWork custRateGroupWork = paraList[i] as CustRateGroupWork;
                            status = custRateGroupDB.Search(ref retal, custRateGroupWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 表示区分マスタ
                    case "PriceSelectSetWork":
                        {
                            PriceSelectSetDB priceSelectSetDB = new PriceSelectSetDB();
                            Object obj = new object();
                            ArrayList retal = new ArrayList();
                            PriceSelectSetWork priceSelectSetWork = paraList[i] as PriceSelectSetWork;
                            status = priceSelectSetDB.Search(out obj, priceSelectSetWork, readMode, logicalMode);
                            if (obj is ArrayList) retal = (ArrayList)obj;
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 備考ガイドマスタ
                    #endregion

                    #region 倉庫マスタ
                    case "WarehouseWork":
                        {
                            WarehouseDB warehouseDB = new WarehouseDB();
                            ArrayList retal = new ArrayList();
                            WarehouseWork warehouseWork = paraList[i] as WarehouseWork;
                            status = warehouseDB.SearchWarehouseProc(out retal, warehouseWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 受発注管理全体設定マスタ
                    case "AcptAnOdrTtlStWork":
                        {
                            AcptAnOdrTtlStDB acptAnOdrTtlStDB = new AcptAnOdrTtlStDB();
                            ArrayList retal = new ArrayList();
                            AcptAnOdrTtlStWork acptAnOdrTtlStWork = paraList[i] as AcptAnOdrTtlStWork;
                            status = acptAnOdrTtlStDB.SearchAcptAnOdrTtlStProc(out retal, acptAnOdrTtlStWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 売上全体設定マスタ
                    case "SalesTtlStWork":
                        {
                            SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
                            ArrayList retal = new ArrayList();
                            SalesTtlStWork salesTtlStWork = paraList[i] as SalesTtlStWork;
                            status = salesTtlStDB.SearchSalesTtlStProc(out retal, salesTtlStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 見積初期値設定マスタ
                    case "EstimateDefSetWork":
                        {
                            EstimateDefSetDB estimateDefSetDB = new EstimateDefSetDB();
                            ArrayList retal = new ArrayList();
                            EstimateDefSetWork estimateDefSetWork = paraList[i] as EstimateDefSetWork;
                            status = estimateDefSetDB.SearchEstimateDefSetProc(out retal, estimateDefSetWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 仕入在庫全体設定マスタ
                    case "StockTtlStWork":
                        {
                            StockTtlStDB stockTtlStDB = new StockTtlStDB();
                            ArrayList retal = new ArrayList();
                            StockTtlStWork stockTtlStWork = paraList[i] as StockTtlStWork;
                            status = stockTtlStDB.SearchStockTtlStProc(out retal, stockTtlStWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 全体初期値設定マスタ
                    case "AllDefSetWork":
                        {
                            AllDefSetDB allDefSetDB = new AllDefSetDB();
                            ArrayList retal = new ArrayList();
                            AllDefSetWork allDefSetWork = paraList[i] as AllDefSetWork;
                            status = allDefSetDB.Search(out retal, allDefSetWork, ref sqlConnection, logicalMode);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 自社情報設定マスタ
                    case "CompanyInfWork":
                        {
                            CompanyInfDB companyInfDB = new CompanyInfDB();
                            ArrayList retal = new ArrayList();
                            CompanyInfWork companyInfWork = paraList[i] as CompanyInfWork;
                            status = companyInfDB.Search(out retal, companyInfWork, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 税率設定マスタ
                    case "TaxRateSetWork":
                        {
                            TaxRateSetDB taxRateSetDB = new TaxRateSetDB();
                            ArrayList retal = new ArrayList();
                            TaxRateSetWork taxRateSetWork = paraList[i] as TaxRateSetWork;
                            status = taxRateSetDB.Search(out retal, taxRateSetWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 伝票印刷設定マスタ
                    case "SlipPrtSetWork":
                        {
                            SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();
                            ArrayList retal = new ArrayList();
                            SlipPrtSetWork slipPrtSetWork = paraList[i] as SlipPrtSetWork;
                            status = slipPrtSetDB.Search(out retal, slipPrtSetWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 得意先マスタ(伝票管理)
                    case "CustSlipMngWork":
                        {
                            CustSlipMngDB custSlipMngDB = new CustSlipMngDB();
                            ArrayList retal = new ArrayList();
                            CustSlipMngWork custSlipMngWork = paraList[i] as CustSlipMngWork;
                            status = custSlipMngDB.SearchCustSlipMngProc(out retal, custSlipMngWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region UOEガイド名称マスタ
                    case "UOEGuideNameWork":
                        {
                            UOEGuideNameDB uoeGuideNameDB = new UOEGuideNameDB();
                            ArrayList retal = new ArrayList();
                            UOEGuideNameWork uoeGuideNameWork = paraList[i] as UOEGuideNameWork;
                            status = uoeGuideNameDB.Search(ref retal, uoeGuideNameWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 従業員情報
                    case "EmployeeWork":
                        {
                            EmployeeDB employeeDB = new EmployeeDB();
                            Object obj = new object();
                            ArrayList retal = new ArrayList();
                            EmployeeWork employeeWork = paraList[i] as EmployeeWork;
                            status = employeeDB.Search(out obj, employeeWork, readMode, logicalMode);
                            if (obj is ArrayList) retal = (ArrayList)obj;
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region ユーザーガイド
                    case "UserGdBdUWork":
                        {
                            UserGdBdUWork temp = (UserGdBdUWork)paraList[i];

                            UserGdBdUDB userGdBdUDB = new UserGdBdUDB();
                            UserGdBdUWork[] usrGdBdLst = new UserGdBdUWork[1];
                            usrGdBdLst[0] = paraList[i] as UserGdBdUWork;

                            //返品理由(ユーザーガイド ガイド区分:91)
                            ArrayList retal = null;
                            usrGdBdLst[0].EnterpriseCode = temp.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 91;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //納品区分(ユーザーガイド ガイド区分:48)
                            retal = null;
                            usrGdBdLst[0].EnterpriseCode = temp.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 48;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //販売区分(ユーザーガイド ガイド区分:71)
                            retal = null;
                            usrGdBdLst[0].EnterpriseCode = temp.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 71;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //商品大分類(ユーザーガイド ガイド区分:70)
                            retal = null;
                            usrGdBdLst[0].EnterpriseCode = temp.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 70;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                            //自社分類(ユーザーガイド ガイド区分:41)
                            retal = null;
                            usrGdBdLst[0].EnterpriseCode = temp.EnterpriseCode;
                            usrGdBdLst[0].UserGuideDivCd = 41;
                            status = userGdBdUDB.Search(out retal, usrGdBdLst, 0, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);

                        }
                        break;
                    #endregion

                    #region 売上金額処理区分マスタ
                    case "SalesProcMoneyWork":
                        {
                            SalesProcMoneyDB salesProcMoneyDB = new SalesProcMoneyDB();
                            ArrayList retal = new ArrayList();
                            SalesProcMoneyWork salesProcMoneyWork = paraList[i] as SalesProcMoneyWork;
                            status = salesProcMoneyDB.SearchSalesProcMoneyProc(out retal, salesProcMoneyWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 仕入金額処理区分マスタ
                    case "StockProcMoneyWork":
                        {
                            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();
                            ArrayList retal = new ArrayList();
                            StockProcMoneyWork stockProcMoneyWork = paraList[i] as StockProcMoneyWork;
                            status = stockProcMoneyDB.SearchStockProcMoneyProc(out retal, stockProcMoneyWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 掛率優先管理マスタ
                    case "RateProtyMngWork":
                        {
                            RateProtyMngDB rateProtyMngDB = new RateProtyMngDB();
                            ArrayList retal = new ArrayList();
                            RateProtyMngWork rateProtyMngWork = paraList[i] as RateProtyMngWork;
                            status = rateProtyMngDB.SearchProc(out retal, rateProtyMngWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 商品中分類
                    case "GoodsGroupUWork":
                        {
                            GoodsGroupUWork temp = (GoodsGroupUWork)paraList[i];

                            GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
                            ArrayList retal = new ArrayList();
                            GoodsGroupUWork goodsGroupUWork = paraList[i] as GoodsGroupUWork;
                            goodsGroupUWork.EnterpriseCode = temp.EnterpriseCode;
                            status = goodsGroupUDB.Search(ref retal, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 優良設定
                    case "PrmSettingUWork":
                        {
                            PrmSettingUWork temp = (PrmSettingUWork)paraList[i];

                            PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
                            ArrayList retal = new ArrayList();
                            PrmSettingUWork prmSettingUWork = paraList[i] as PrmSettingUWork;
                            prmSettingUWork.EnterpriseCode = temp.EnterpriseCode;
                            status = prmSettingUDB.Search(ref retal, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region メーカー
                    case "MakerUWork":
                        {
                            MakerUWork temp = (MakerUWork)paraList[i];

                            MakerUDB makerUDB = new MakerUDB();
                            ArrayList retal = null;
                            MakerUWork makerUWork = new MakerUWork();
                            makerUWork.EnterpriseCode = temp.EnterpriseCode;
                            status = makerUDB.SearchMakerProc(out retal, makerUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region BLグループ
                    case "BLGroupUWork":
                        {
                            BLGroupUWork temp = (BLGroupUWork)paraList[i];

                            BLGroupUDB bLGroupUDB = new BLGroupUDB();
                            ArrayList retal = new ArrayList();
                            BLGroupUWork bLGroupUWork = paraList[i] as BLGroupUWork;
                            bLGroupUWork.EnterpriseCode = temp.EnterpriseCode;
                            status = bLGroupUDB.Search(ref retal, bLGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region BLコード
                    case "BLGoodsCdUWork":
                        {
                            BLGoodsCdUWork temp = (BLGoodsCdUWork)paraList[i];

                            BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                            ArrayList retal = null;
                            BLGoodsCdUWork bLGoodsCdUWork = paraList[i] as BLGoodsCdUWork;
                            bLGoodsCdUWork.EnterpriseCode = temp.EnterpriseCode;
                            status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 商品管理
                    case "GoodsMngWork":
                        {
                            GoodsMngWork temp = (GoodsMngWork)paraList[i];

                            GoodsMngDB goodsMngDB = new GoodsMngDB();
                            ArrayList retal = new ArrayList();
                            GoodsMngWork goodsMngWork = paraList[i] as GoodsMngWork;
                            goodsMngWork.EnterpriseCode = temp.EnterpriseCode;
                            status = goodsMngDB.SearchGoodsMngProc(out retal, goodsMngWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 離島価格
                    case "IsolIslandPrcWork":
                        {
                            IsolIslandPrcWork temp = (IsolIslandPrcWork)paraList[i];

                            IsolIslandPrcDB isolIslandPrcDB = new IsolIslandPrcDB();
                            ArrayList retal = new ArrayList();
                            IsolIslandPrcWork isolIslandPrcWork = paraList[i] as IsolIslandPrcWork;
                            isolIslandPrcWork.EnterpriseCode = temp.EnterpriseCode;
                            status = isolIslandPrcDB.Search(ref retal, isolIslandPrcWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    #region 仕入先
                    case "SupplierWork":
                        {
                            SupplierWork temp = (SupplierWork)paraList[i];

                            SupplierDB supplierDB = new SupplierDB();
                            ArrayList retal = new ArrayList();
                            SupplierWork supplierWork = paraList[i] as SupplierWork;
                            supplierWork.EnterpriseCode = temp.EnterpriseCode;
                            status = supplierDB.Search(out retal, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion

                    //>>>2010/05/30
                    #region SCM全体設定マスタ
                    case "SCMTtlStWork":
                        {
                            SCMTtlStDB scmTtlStDB = new SCMTtlStDB();
                            Object obj = new object();
                            ArrayList retal = new ArrayList();
                            SCMTtlStWork scmTtlStWork = paraList[i] as SCMTtlStWork;
                            status = scmTtlStDB.SearchSCMTtlStProc(out obj, scmTtlStWork, readMode, logicalMode, ref sqlConnection);
                            if (obj is ArrayList) retal = (ArrayList)obj;
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion
                    #region SCM納期設定マスタ
                    case "SCMDeliDateStWork":
                        {
                            SCMDeliDateStDB scmDeliDateStDB = new SCMDeliDateStDB();
                            ArrayList retal = new ArrayList();
                            SCMDeliDateStWork scmDeliDateStWork = paraList[i] as SCMDeliDateStWork;
                            status = scmDeliDateStDB.SearchSCMDeliDateStProc(out retal, scmDeliDateStWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion
                    //<<<2010/05/30

                    //>>>2011/09/27
                    #region 在庫管理全体設定
                    case "StockMngTtlStWork":
                        {
                            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
                            ArrayList retal = new ArrayList();
                            StockMngTtlStWork stockMngTtlStWork = paraList[i] as StockMngTtlStWork;
                            status = stockMngTtlStDB.SearchStockMngTtlStProc(out retal, stockMngTtlStWork, readMode, logicalMode, ref sqlConnection);
                            retCSAList.Add(retal);
                        }
                        break;
                    #endregion
                    //<<<2011/09/27

                }
            }

            retObj = retCSAList;

            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns></returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText)) return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
