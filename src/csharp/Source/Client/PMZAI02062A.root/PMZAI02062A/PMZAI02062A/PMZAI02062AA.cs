//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 委託在庫補充処理
// プログラム概要   : 委託在庫補充処理で使用するデータの取得・更新を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 作 成 日  2008/11/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/27  修正内容 : 不具合対応[13091]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/15  修正内容 : 不具合対応[13209]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/21  修正内容 : 不具合対応[13209]フィードバック対応
//                                  在庫調整データの担当者名称は16桁で切捨て
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/09/06  修正内容 : 2012/09/19配信分、PM保守案件Redmine#32179　補充元商品無し時「無視して更新」
//                                  の区分を選択して実行時、補充元の在庫マスタが新規作成される。
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 委託在庫補充処理表印刷アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 委託在庫補充処理表のアクセスクラスです。</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/11/12</br>
    /// <br>UpdateNote : 2009/04/27 照田 貴志　不具合対応[13091]</br>
    /// <br>Update Note: 2012/09/06 李亜博</br>
    /// <br>           : 10801804-00、2012/09/19配信分、PM保守案件Redmine#32179の対応</br>
    /// <br>           : 補充元商品無し時「無視して更新」の区分を選択して実行時、補充元の在庫マスタが新規作成される。</br>
    /// </remarks>
    public class TrustStockOrderAcs
    {
        #region ■ Private Members

        private ITrustStockOrderWorkDB _iTrustStockOrderWorkDB;
        private IStockAdjustDB _iStockAdjustDB;

        /// <summary> 帳票出力設定アクセスクラス </summary>
        private PrtOutSetAcs _prtOutSetAcs;

        private GoodsAcs _goodsAcs;
        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        private StockProcMoneyAcs _stockProcMoneyAcs;   // 単価算出クラスアクセスクラス
        private SecInfoAcs _secInfoAcs;                 // 拠点アクセスクラス

        private Dictionary<string, SecInfoSet> _secInfoSetDic;

        private UnitPriceCalculation _unitPriceCalculation;
        private TaxRateSet _taxRateSet;

        // ADD 2009/05/15 ------>>>
        private WarehouseAcs _warehouseAcs;             // 倉庫マスタアクセスクラス
        private Dictionary<string, Warehouse> _warehouseDic;
        // ADD 2009/05/15 ------>>>
        
        #endregion ■ Private Members


        # region ■ Constractor
        /// <summary>
        /// 委託在庫補充処理表印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 委託在庫補充処理表のアクセスクラスのコンストラクタです。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
		public TrustStockOrderAcs()
        {
            this._prtOutSetAcs = new PrtOutSetAcs();

            string errMsg;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out errMsg);

            this._taxRateSetAcs = new TaxRateSetAcs();
            this._stockProcMoneyAcs = new StockProcMoneyAcs();

            this._taxRateSet = new TaxRateSet();
            this._unitPriceCalculation = new UnitPriceCalculation();

            this._secInfoAcs = new SecInfoAcs();
            ReadSecInfoSet();

            this._iTrustStockOrderWorkDB = (ITrustStockOrderWorkDB)MediationTrustStockOrderWorkDB.GetTrustStockOrderWorkDB();
            this._iStockAdjustDB = (IStockAdjustDB)MediationStockAdjustDB.GetStockAdjustDB();

            // ADD 2009/05/15 ------>>>
            this._warehouseAcs = new WarehouseAcs();
            this._warehouseDic = new Dictionary<string, Warehouse>();
            ReadWarehouse();
            // ADD 2009/05/15 ------<<<
        }
        # endregion ■ Constractor


        #region ■ Public Methods
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="extrInfo">帳票出力条件</param>
        /// <param name="dataTable">データテーブル</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 条件に適したデータを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        public int Search(TrustStockOrderCndtn extrInfo, out DataTable dataTable, out string errMsg)
        {
            dataTable = new DataTable();
            errMsg = "";
            List<TrustStockResult> trustStockResultList;
            
            return Search(extrInfo, out dataTable, out trustStockResultList, out errMsg);
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="extrInfo">帳票出力条件</param>
        /// <param name="dataTable">データテーブル</param>
        /// <param name="trustStockResultList">委託在庫補充処理データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 条件に適したデータを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        public int Search(TrustStockOrderCndtn extrInfo, out DataTable dataTable, out List<TrustStockResult> trustStockResultList, out string errMsg)
        {
            dataTable = new DataTable();
            trustStockResultList = new List<TrustStockResult>();
            errMsg = "";

            // クラスメンバコピー処理
            TrustStockOrderCndtnWork paraWork = CopyToTrustStockOrderCndtnWorkFromTrustStockOrderCndtn(extrInfo);

            object retObj;
            object paraOb = paraWork; ;

            int status = this._iTrustStockOrderWorkDB.Search(out retObj, paraOb, 0, ConstantManagement.LogicalMode.GetData0);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // データテーブル作成
                        PMZAI02069EA.CreateDataTableTrustStockOrder(ref dataTable);

                        ArrayList retList = retObj as ArrayList;

                        foreach (TrustStockResultWork trustStockResultWork in retList)
                        {
                            // クラスメンバコピー処理
                            trustStockResultList.Add(CopyToTrustStockResultFromTrustStockResultWork(trustStockResultWork));
                        }

                        // 委託在庫補充データ設定
                        SetDataTableFromTrustStockOrder(ref dataTable, trustStockResultList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    }
                default:
                    {
                        errMsg = "委託在庫補充データの取得に失敗しました。";
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            prtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                status = this._prtOutSetAcs.Read(out prtOutSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    default:
                        errMsg = "帳票出力設定の読込に失敗しました";
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                prtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return (status);
        }

        /// <summary>
        /// 在庫マスタ更新処理
        /// </summary>
        /// <param name="trustStockResultList">委託在庫補充処理データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 委託在庫補充データを基に、在庫マスタを更新します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        public int WriteStock(List<TrustStockResult> trustStockResultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // DEL 2009/05/15 ------>>>
            //CustomSerializeArrayList registTruList;
            //CustomSerializeArrayList registRepList;
            // DEL 2009/05/15 ------<<<
            CustomSerializeArrayList warehouseList;

            // DEL 2009/05/15 ------>>>
            //// 在庫更新データ作成
            //CreateSaveData(trustStockResultList, out registTruList, out registRepList, out warehouseList);

            //// 在庫調整データリストと在庫調整明細データリストを追加
            //CustomSerializeArrayList registList = new CustomSerializeArrayList();

            //registList.Add(registTruList);    
            //registList.Add(registRepList);
            // DEL 2009/05/15 ------<<<
            
            //registList.Add(warehouseList);

            // ADD 2009/05/15 ------>>>
            // 委託元と補充元の在庫調整データ
            CustomSerializeArrayList registList;

            // 在庫更新データ作成
            CreateSaveData(trustStockResultList, out registList, out warehouseList);
            // ADD 2009/05/15 ------<<<
            
            object paraObj = registList;
            string retMessage = "";
            object wareObj = warehouseList;

            try
            {
                // 更新処理
                status = this._iStockAdjustDB.WriteEntrust(ref paraObj, out retMessage, ref wareObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion ■ Public Methods


        #region ■ Private Methods
        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// Note       : 拠点マスタ読み込み、バッファに保持します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2009/01/20<br />
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// Note       : 拠点名を取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2009/01/20<br />
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
            }

            return "";
        }

        /// <summary>
        /// 単価算出クラス初期データ読込処理
        /// </summary>
        /// <remarks>
        /// Note       : 単価算出クラスに必要な初期データを読み込みます。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        private void ReadInitData()
        {
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList retStockProcMoneyList;

            int status = this._stockProcMoneyAcs.Search(out retStockProcMoneyList, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in retStockProcMoneyList)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }
            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// 原単価取得処理
        /// </summary>
        /// <param name="stock">在庫マスタ</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>原単価</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ、商品連結データより原単価を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private Double GetStockUnitPrice(GoodsUnitData goodsUnitData)
        {
            Double stockUnitPrice = 0;

            // 商品連結データから単価算出結果オブジェクトを取得
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData);

            // 単価算出結果オブジェクトより原単価取得
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// 単価算出結果オブジェクト取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>単価算出結果オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データより単価算出結果オブジェクトを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/07/24</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                         // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);    // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <remarks>
        /// Note       : 税率設定マスタを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        private void ReadTaxRate()
        {
            int status;

            try
            {
                // 税率設定マスタ取得(税率コード=0固定)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }

        /// <summary>
        /// 在庫マスタ更新データ作成処理
        /// </summary>
        /// <param name="trustStockResultList">委託在庫補充処理データリスト</param>
        /// <param name="stockAdjustWorkList">在庫調整データリスト</param>
        /// <param name="stockAdjustDtlWorkList">在庫調整明細データリスト</param>
        /// <remarks>
        /// <br>Note       : 在庫調整データリスト、在庫調整明細データリストを作成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void CreateSaveData(List<TrustStockResult> trustStockResultList, out CustomSerializeArrayList registTruList, out CustomSerializeArrayList registRepList, out CustomSerializeArrayList warehouseList)
        {
            string tru_StockSectionCode = string.Empty;     //ADD 2009/04/27 不具合対応[13091]
            string rep_StockSectionCode = string.Empty;     //ADD 2009/04/27 不具合対応[13091]

            registTruList = new CustomSerializeArrayList();
            registRepList = new CustomSerializeArrayList();
            warehouseList = new CustomSerializeArrayList();

            ArrayList tru_StockAdjustWorkList = new ArrayList();
            ArrayList rep_StockAdjustWorkList = new ArrayList();
            ArrayList tru_StockAdjustDtlWorkList = new ArrayList();
            ArrayList rep_StockAdjustDtlWorkList = new ArrayList();

            // 倉庫Dictionary作成
            Dictionary<string, string> warehouseDic = new Dictionary<string, string>();

            // 商品連結データDictionary取得
            Dictionary<string, GoodsUnitData> goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
            GetGoodsUnitDataDic(ref goodsUnitDataDic, trustStockResultList);

            long tru_StockPriceTaxExc = 0;
            long rep_StockPriceTaxExc = 0;

            int stockAdjustRowNo = 1;
            // 在庫調整明細データワークリスト作成
            foreach (TrustStockResult trustStockResult in trustStockResultList)
            {
                StockAdjustDtlWork tru_ParaDtlWork = new StockAdjustDtlWork();
                StockAdjustDtlWork rep_ParaDtlWork = new StockAdjustDtlWork();

                string key;
                GoodsUnitData goodsUnitData;
                GoodsPrice goodsPrice;

                //---------------------------------------
                // 委託倉庫側の在庫調整明細データ作成
                //---------------------------------------
                tru_ParaDtlWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                tru_ParaDtlWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                tru_ParaDtlWork.SectionGuideNm = GetSectionName(tru_ParaDtlWork.SectionCode);
                tru_ParaDtlWork.StockAdjustRowNo = stockAdjustRowNo;
                tru_ParaDtlWork.AcPaySlipCd = 70;
                tru_ParaDtlWork.AcPayTransCd = 30;
                tru_ParaDtlWork.AdjustDate = DateTime.Today;
                tru_ParaDtlWork.InputDay = DateTime.Today;
                tru_ParaDtlWork.GoodsMakerCd = trustStockResult.GoodsMakerCd;
                tru_ParaDtlWork.MakerName = trustStockResult.MakerShortName;
                tru_ParaDtlWork.GoodsNo = trustStockResult.GoodsNo;
                tru_ParaDtlWork.GoodsName = trustStockResult.GoodsName;

                key = trustStockResult.GoodsMakerCd.ToString("0000") + trustStockResult.GoodsNo.Trim();
                if (goodsUnitDataDic.ContainsKey(key))
                {
                    goodsUnitData = (GoodsUnitData)goodsUnitDataDic[key];
                }
                else
                {
                    goodsUnitData = new GoodsUnitData();
                }

                tru_ParaDtlWork.StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                tru_ParaDtlWork.BfStockUnitPriceFl = tru_ParaDtlWork.StockUnitPriceFl;
                tru_ParaDtlWork.AdjustCount = trustStockResult.ReplenishCount;
                tru_ParaDtlWork.WarehouseCode = trustStockResult.Tru_WarehouseCode.PadLeft(4, '0');
                tru_ParaDtlWork.WarehouseName = trustStockResult.Tru_WarehouseName;
                tru_ParaDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
                tru_ParaDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;
                tru_ParaDtlWork.WarehouseShelfNo = trustStockResult.Tru_WarehouseShelfNo;

                goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsUnitData.GoodsPriceList);
                if (goodsPrice == null)
                {
                    tru_ParaDtlWork.ListPriceFl = 0;
                    tru_ParaDtlWork.OpenPriceDiv = 0;
                }
                else
                {
                    tru_ParaDtlWork.ListPriceFl = goodsPrice.ListPrice;
                    tru_ParaDtlWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                }

                tru_ParaDtlWork.StockPriceTaxExc = (long)(tru_ParaDtlWork.StockUnitPriceFl * tru_ParaDtlWork.AdjustCount);
                tru_StockPriceTaxExc += tru_ParaDtlWork.StockPriceTaxExc;

                // 倉庫Dictionaryに追加
                if (!warehouseDic.ContainsKey(tru_ParaDtlWork.WarehouseCode))
                {
                    warehouseDic.Add(tru_ParaDtlWork.WarehouseCode, tru_ParaDtlWork.WarehouseCode);
                }

                // ---ADD 2009/04/27 不具合対応[13091] -------------------------------------------------------------------------->>>>>
                if (string.IsNullOrEmpty(tru_StockSectionCode.Trim()))
                {
                    tru_StockSectionCode = this.GetStockSectionCodeFromStockList(tru_ParaDtlWork.WarehouseCode, goodsUnitData.StockList);
                }
                // ---ADD 2009/04/27 不具合対応[13091] --------------------------------------------------------------------------<<<<<

                //---------------------------------------
                // 補充元倉庫側の在庫調整明細データ作成
                //---------------------------------------
                rep_ParaDtlWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                rep_ParaDtlWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                rep_ParaDtlWork.SectionGuideNm = GetSectionName(rep_ParaDtlWork.SectionCode);
                rep_ParaDtlWork.StockAdjustRowNo = stockAdjustRowNo;
                rep_ParaDtlWork.AcPaySlipCd = 71;
                rep_ParaDtlWork.AcPayTransCd = 30;
                rep_ParaDtlWork.AdjustDate = DateTime.Today;
                rep_ParaDtlWork.InputDay = DateTime.Today;
                rep_ParaDtlWork.GoodsMakerCd = trustStockResult.GoodsMakerCd;
                rep_ParaDtlWork.MakerName = trustStockResult.MakerShortName;
                rep_ParaDtlWork.GoodsNo = trustStockResult.GoodsNo;
                rep_ParaDtlWork.GoodsName = trustStockResult.GoodsName;
                key = trustStockResult.GoodsMakerCd.ToString("0000") + trustStockResult.GoodsNo.Trim();
                if (goodsUnitDataDic.ContainsKey(key))
                {
                    goodsUnitData = (GoodsUnitData)goodsUnitDataDic[key];
                }
                else
                {
                    goodsUnitData = new GoodsUnitData();
                }

                rep_ParaDtlWork.StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                rep_ParaDtlWork.BfStockUnitPriceFl = rep_ParaDtlWork.StockUnitPriceFl;
                rep_ParaDtlWork.AdjustCount = trustStockResult.ReplenishCount * -1;
                rep_ParaDtlWork.WarehouseCode = trustStockResult.Rep_WarehouseCode.PadLeft(4, '0');
                rep_ParaDtlWork.WarehouseName = trustStockResult.Rep_WarehouseName;
                rep_ParaDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
                rep_ParaDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;
                rep_ParaDtlWork.WarehouseShelfNo = trustStockResult.Rep_WarehouseShelfNo;

                goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsUnitData.GoodsPriceList);
                if (goodsPrice == null)
                {
                    rep_ParaDtlWork.ListPriceFl = 0;
                    rep_ParaDtlWork.OpenPriceDiv = 0;
                }
                else
                {
                    rep_ParaDtlWork.ListPriceFl = goodsPrice.ListPrice;
                    rep_ParaDtlWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                }

                rep_ParaDtlWork.StockPriceTaxExc = (long)(rep_ParaDtlWork.StockUnitPriceFl * rep_ParaDtlWork.AdjustCount);
                rep_StockPriceTaxExc += rep_ParaDtlWork.StockPriceTaxExc;

                // 倉庫Dictionaryに追加
                if (!warehouseDic.ContainsKey(rep_ParaDtlWork.WarehouseCode))
                {
                    warehouseDic.Add(rep_ParaDtlWork.WarehouseCode, rep_ParaDtlWork.WarehouseCode);
                }

                // ---ADD 2009/04/27 不具合対応[13091] -------------------------------------------------------------------------->>>>>
                if (string.IsNullOrEmpty(rep_StockSectionCode.Trim()))
                {
                    rep_StockSectionCode = this.GetStockSectionCodeFromStockList(rep_ParaDtlWork.WarehouseCode, goodsUnitData.StockList);
                }
                // ---ADD 2009/04/27 不具合対応[13091] --------------------------------------------------------------------------<<<<<

                // 在庫調整明細データワークリストに追加
                tru_StockAdjustDtlWorkList.Add(tru_ParaDtlWork);
                rep_StockAdjustDtlWorkList.Add(rep_ParaDtlWork);

                stockAdjustRowNo++;
            }

            StockAdjustWork tru_ParaWork = new StockAdjustWork();
            StockAdjustWork rep_ParaWork = new StockAdjustWork();

            //---------------------------------------
            // 委託倉庫側の在庫調整データ作成
            //---------------------------------------
            tru_ParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            tru_ParaWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            tru_ParaWork.SectionGuideNm = GetSectionName(tru_ParaWork.SectionCode);
            tru_ParaWork.AcPaySlipCd = 70;
            tru_ParaWork.AcPayTransCd = 30;
            tru_ParaWork.AdjustDate = DateTime.Today;
            tru_ParaWork.InputDay = DateTime.Today;
            //tru_ParaWork.StockSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;        //DEL 2009/04/27 不具合対応[13091]
            tru_ParaWork.StockSectionCd = tru_StockSectionCode;                                     //ADD 2009/04/27 不具合対応[13091]
            tru_ParaWork.StockSectionGuideNm = GetSectionName(tru_ParaWork.StockSectionCd);
            tru_ParaWork.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;
            tru_ParaWork.StockInputName = LoginInfoAcquisition.Employee.Name;
            tru_ParaWork.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
            tru_ParaWork.StockAgentName = LoginInfoAcquisition.Employee.Name;
            tru_ParaWork.StockSubttlPrice = tru_StockPriceTaxExc;

            //---------------------------------------
            // 補充元倉庫側の在庫調整データ作成
            //---------------------------------------
            rep_ParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            rep_ParaWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            rep_ParaWork.SectionGuideNm = GetSectionName(rep_ParaWork.SectionCode);
            rep_ParaWork.AcPaySlipCd = 71;
            rep_ParaWork.AcPayTransCd = 30;
            rep_ParaWork.AdjustDate = DateTime.Today;
            rep_ParaWork.InputDay = DateTime.Today;
            //rep_ParaWork.StockSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;        //DEL 2009/04/27 不具合対応[13091]
            rep_ParaWork.StockSectionCd = rep_StockSectionCode;                                     //DEL 2009/04/27 不具合対応[13091]
            rep_ParaWork.StockSectionGuideNm = GetSectionName(rep_ParaWork.StockSectionCd);
            rep_ParaWork.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;
            rep_ParaWork.StockInputName = LoginInfoAcquisition.Employee.Name;
            rep_ParaWork.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
            rep_ParaWork.StockAgentName = LoginInfoAcquisition.Employee.Name;
            rep_ParaWork.StockSubttlPrice = rep_StockPriceTaxExc;

            // 在庫調整データワークリストに追加
            tru_StockAdjustWorkList.Add(tru_ParaWork);
            rep_StockAdjustWorkList.Add(rep_ParaWork);

            registTruList.Add(tru_StockAdjustWorkList);
            registTruList.Add(tru_StockAdjustDtlWorkList);

            registRepList.Add(rep_StockAdjustWorkList);
            registRepList.Add(rep_StockAdjustDtlWorkList);

            // 倉庫Dictionaryを倉庫リストにコピー
            foreach (string warehouseCode in warehouseDic.Keys)
            {
                warehouseList.Add(warehouseCode);
            }
        }

        // ADD 2009/05/15 ------>>>
        /// <summary>
        /// 在庫マスタ更新データ作成処理
        /// </summary>
        /// <param name="trustStockResultList">委託在庫補充処理データリスト</param>
        /// <param name="registList">委託元と補充元の在庫調整データリスト</param>
        /// <param name="warehouseList">倉庫データリスト</param>
        /// <remarks>
        /// <br>Note       : 在庫調整データリスト、在庫調整明細データリストを作成します。</br>
        /// <br>Update Note: 2012/09/06 李亜博</br>
        /// <br>           : 10801804-00、2012/09/19配信分、PM保守案件Redmine#32179の対応</br>
        /// <br>           : 補充元商品無し時「無視して更新」の区分を選択して実行時、補充元の在庫マスタが新規作成される。</br>
        /// </remarks>
        private void CreateSaveData(List<TrustStockResult> trustStockResultList, out CustomSerializeArrayList registList, out CustomSerializeArrayList warehouseList)
        {
            registList = new CustomSerializeArrayList();
            warehouseList = new CustomSerializeArrayList();

            // 倉庫Dictionary作成
            Dictionary<string, string> warehouseDic = new Dictionary<string, string>();

            // 商品連結データDictionary取得
            Dictionary<string, GoodsUnitData> goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
            GetGoodsUnitDataDic(ref goodsUnitDataDic, trustStockResultList);

            // 委託元と補充元の在庫調整明細データワークディクショナリー
            Dictionary<string, ArrayList> tru_StockAdjustDtlDic = new Dictionary<string, ArrayList>();
            Dictionary<string, ArrayList> rep_StockAdjustDtlDic = new Dictionary<string, ArrayList>();

            // 委託元と補充元の仕入金額ディクショナリー
            Dictionary<string, long> tru_StockPriceTaxExcDic = new Dictionary<string, long>();
            Dictionary<string, long> rep_StockPriceTaxExcDic = new Dictionary<string, long>();

            int stockAdjustRowNo = 1;
            // 在庫調整明細データワーク作成
            foreach (TrustStockResult trustStockResult in trustStockResultList)
            {
                StockAdjustDtlWork tru_ParaDtlWork = new StockAdjustDtlWork();
                StockAdjustDtlWork rep_ParaDtlWork = new StockAdjustDtlWork();

                string key;
                GoodsUnitData goodsUnitData;
                GoodsPrice goodsPrice;

                //---------------------------------------
                // 委託倉庫側の在庫調整明細データ作成
                //---------------------------------------
                tru_ParaDtlWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                tru_ParaDtlWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                tru_ParaDtlWork.SectionGuideNm = GetSectionName(tru_ParaDtlWork.SectionCode);
                tru_ParaDtlWork.StockAdjustRowNo = stockAdjustRowNo;
                tru_ParaDtlWork.AcPaySlipCd = 70;
                tru_ParaDtlWork.AcPayTransCd = 30;
                tru_ParaDtlWork.AdjustDate = DateTime.Today;
                tru_ParaDtlWork.InputDay = DateTime.Today;
                tru_ParaDtlWork.GoodsMakerCd = trustStockResult.GoodsMakerCd;
                tru_ParaDtlWork.MakerName = trustStockResult.MakerShortName;
                tru_ParaDtlWork.GoodsNo = trustStockResult.GoodsNo;
                tru_ParaDtlWork.GoodsName = trustStockResult.GoodsName;

                key = trustStockResult.GoodsMakerCd.ToString("0000") + trustStockResult.GoodsNo.Trim();
                if (goodsUnitDataDic.ContainsKey(key))
                {
                    goodsUnitData = (GoodsUnitData)goodsUnitDataDic[key];
                }
                else
                {
                    goodsUnitData = new GoodsUnitData();
                }

                tru_ParaDtlWork.StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                tru_ParaDtlWork.BfStockUnitPriceFl = tru_ParaDtlWork.StockUnitPriceFl;
                tru_ParaDtlWork.AdjustCount = trustStockResult.ReplenishCount;
                tru_ParaDtlWork.WarehouseCode = trustStockResult.Tru_WarehouseCode.PadLeft(4, '0');
                tru_ParaDtlWork.WarehouseName = trustStockResult.Tru_WarehouseName;
                tru_ParaDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
                tru_ParaDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;
                tru_ParaDtlWork.WarehouseShelfNo = trustStockResult.Tru_WarehouseShelfNo;

                goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsUnitData.GoodsPriceList);
                if (goodsPrice == null)
                {
                    tru_ParaDtlWork.ListPriceFl = 0;
                    tru_ParaDtlWork.OpenPriceDiv = 0;
                }
                else
                {
                    tru_ParaDtlWork.ListPriceFl = goodsPrice.ListPrice;
                    tru_ParaDtlWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                }

                tru_ParaDtlWork.StockPriceTaxExc = (long)(tru_ParaDtlWork.StockUnitPriceFl * tru_ParaDtlWork.AdjustCount);
                
                // 倉庫Dictionaryに追加
                if (!warehouseDic.ContainsKey(tru_ParaDtlWork.WarehouseCode))
                {
                    warehouseDic.Add(tru_ParaDtlWork.WarehouseCode, tru_ParaDtlWork.WarehouseCode);
                }

                // 在庫調整明細データを倉庫単位に登録
                AddParaDtlWorkDic(tru_ParaDtlWork.WarehouseCode, tru_ParaDtlWork, ref tru_StockAdjustDtlDic);
                // 仕入金額を倉庫単位に集計
                AddStockPriceTaxExcDic(tru_ParaDtlWork.WarehouseCode, tru_ParaDtlWork.StockPriceTaxExc, ref tru_StockPriceTaxExcDic);

                //---------------------------------------
                // 補充元倉庫側の在庫調整明細データ作成
                //---------------------------------------
                // ------ ADD 2012/09/06 李亜博 for Redmine#32179 -------->>>>
                if (trustStockResult.GoodsFlg != 1)
                {
                // ------ ADD 2012/09/06 李亜博 for Redmine#32179 --------<<<<
                    rep_ParaDtlWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    rep_ParaDtlWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                    rep_ParaDtlWork.SectionGuideNm = GetSectionName(rep_ParaDtlWork.SectionCode);
                    rep_ParaDtlWork.StockAdjustRowNo = stockAdjustRowNo;
                    rep_ParaDtlWork.AcPaySlipCd = 71;
                    rep_ParaDtlWork.AcPayTransCd = 30;
                    rep_ParaDtlWork.AdjustDate = DateTime.Today;
                    rep_ParaDtlWork.InputDay = DateTime.Today;
                    rep_ParaDtlWork.GoodsMakerCd = trustStockResult.GoodsMakerCd;
                    rep_ParaDtlWork.MakerName = trustStockResult.MakerShortName;
                    rep_ParaDtlWork.GoodsNo = trustStockResult.GoodsNo;
                    rep_ParaDtlWork.GoodsName = trustStockResult.GoodsName;
                    key = trustStockResult.GoodsMakerCd.ToString("0000") + trustStockResult.GoodsNo.Trim();
                    if (goodsUnitDataDic.ContainsKey(key))
                    {
                        goodsUnitData = (GoodsUnitData)goodsUnitDataDic[key];
                    }
                    else
                    {
                        goodsUnitData = new GoodsUnitData();
                    }

                    rep_ParaDtlWork.StockUnitPriceFl = GetStockUnitPrice(goodsUnitData);
                    rep_ParaDtlWork.BfStockUnitPriceFl = rep_ParaDtlWork.StockUnitPriceFl;
                    rep_ParaDtlWork.AdjustCount = trustStockResult.ReplenishCount * -1;
                    rep_ParaDtlWork.WarehouseCode = trustStockResult.Rep_WarehouseCode.PadLeft(4, '0');
                    rep_ParaDtlWork.WarehouseName = trustStockResult.Rep_WarehouseName;
                    rep_ParaDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
                    rep_ParaDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;
                    rep_ParaDtlWork.WarehouseShelfNo = trustStockResult.Rep_WarehouseShelfNo;

                    goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsUnitData.GoodsPriceList);
                    if (goodsPrice == null)
                    {
                        rep_ParaDtlWork.ListPriceFl = 0;
                        rep_ParaDtlWork.OpenPriceDiv = 0;
                    }
                    else
                    {
                        rep_ParaDtlWork.ListPriceFl = goodsPrice.ListPrice;
                        rep_ParaDtlWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                    }

                    rep_ParaDtlWork.StockPriceTaxExc = (long)(rep_ParaDtlWork.StockUnitPriceFl * rep_ParaDtlWork.AdjustCount);

                    // 倉庫Dictionaryに追加
                    if (!warehouseDic.ContainsKey(rep_ParaDtlWork.WarehouseCode))
                    {
                        warehouseDic.Add(rep_ParaDtlWork.WarehouseCode, rep_ParaDtlWork.WarehouseCode);
                    }

                    // 在庫調整明細データを倉庫単位に登録
                    AddParaDtlWorkDic(rep_ParaDtlWork.WarehouseCode, rep_ParaDtlWork, ref rep_StockAdjustDtlDic);
                    // 仕入金額を倉庫単位に集計
                    AddStockPriceTaxExcDic(rep_ParaDtlWork.WarehouseCode, rep_ParaDtlWork.StockPriceTaxExc, ref rep_StockPriceTaxExcDic);
                }// ADD 2012/09/06 李亜博 for Redmine#32179 
            }

            // ADD 2009/05/21 ------>>>
            // 在庫調整データは名称16桁
            string employeeName = LoginInfoAcquisition.Employee.Name;
            if (employeeName.Length > 16)
            {
                // 16桁で切り捨て
                employeeName = employeeName.Substring(0, 16);
            }
            // ADD 2009/05/21 ------<<<
            
            // 委託倉庫側の在庫調整データ作成
            foreach (string truKey in tru_StockAdjustDtlDic.Keys)
            {
                StockAdjustWork tru_ParaWork = new StockAdjustWork();

                //---------------------------------------
                // 委託倉庫側の在庫調整データ作成
                //---------------------------------------
                tru_ParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                tru_ParaWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                tru_ParaWork.SectionGuideNm = GetSectionName(tru_ParaWork.SectionCode);
                tru_ParaWork.AcPaySlipCd = 70;
                tru_ParaWork.AcPayTransCd = 30;
                tru_ParaWork.AdjustDate = DateTime.Today;
                tru_ParaWork.InputDay = DateTime.Today;
                tru_ParaWork.StockSectionCd = GetSectionCodeFromWarehouse(truKey);
                tru_ParaWork.StockSectionGuideNm = GetSectionName(tru_ParaWork.StockSectionCd);
                tru_ParaWork.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;
                //tru_ParaWork.StockInputName = LoginInfoAcquisition.Employee.Name;     // DEL 2009/05/21
                tru_ParaWork.StockInputName = employeeName;                             // ADD 2009/05/21
                tru_ParaWork.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
                //tru_ParaWork.StockAgentName = LoginInfoAcquisition.Employee.Name;     // DEL 2009/05/21
                tru_ParaWork.StockAgentName = employeeName;                             // ADD 2009/05/21
                tru_ParaWork.StockSubttlPrice = tru_StockPriceTaxExcDic[truKey];

                // 委託元の在庫調整データを作成
                CustomSerializeArrayList registTruList = new CustomSerializeArrayList();

                ArrayList tru_StockAdjustWorkList = new ArrayList();
                ArrayList tru_StockAdjustDtlWorkList = tru_StockAdjustDtlDic[truKey];

                // 在庫調整データワークリストに追加
                tru_StockAdjustWorkList.Add(tru_ParaWork);

                registTruList.Add(tru_StockAdjustWorkList);
                registTruList.Add(tru_StockAdjustDtlWorkList);

                // 委託元の在庫調整データをリストに追加
                registList.Add(registTruList);
            }

            // 補充元倉庫側の在庫調整データ作成
            foreach (string repKey in rep_StockAdjustDtlDic.Keys)
            {
                StockAdjustWork rep_ParaWork = new StockAdjustWork();

                //---------------------------------------
                // 補充元倉庫側の在庫調整データ作成
                //---------------------------------------
                rep_ParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                rep_ParaWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                rep_ParaWork.SectionGuideNm = GetSectionName(rep_ParaWork.SectionCode);
                rep_ParaWork.AcPaySlipCd = 71;
                rep_ParaWork.AcPayTransCd = 30;
                rep_ParaWork.AdjustDate = DateTime.Today;
                rep_ParaWork.InputDay = DateTime.Today;
                rep_ParaWork.StockSectionCd = GetSectionCodeFromWarehouse(repKey);
                rep_ParaWork.StockSectionGuideNm = GetSectionName(rep_ParaWork.StockSectionCd);
                rep_ParaWork.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;
                //rep_ParaWork.StockInputName = LoginInfoAcquisition.Employee.Name;     // DEL 2009/05/21
                rep_ParaWork.StockInputName = employeeName;                             // ADD 2009/05/21
                rep_ParaWork.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
                //rep_ParaWork.StockAgentName = LoginInfoAcquisition.Employee.Name;     // DEL 2009/05/21
                rep_ParaWork.StockAgentName = employeeName;                             // ADD 2009/05/21
                rep_ParaWork.StockSubttlPrice = rep_StockPriceTaxExcDic[repKey];

                // 補充元の在庫調整データを作成
                CustomSerializeArrayList registRepList = new CustomSerializeArrayList();

                ArrayList rep_StockAdjustWorkList = new ArrayList();
                ArrayList rep_StockAdjustDtlWorkList = rep_StockAdjustDtlDic[repKey];

                // 在庫調整データワークリストに追加
                rep_StockAdjustWorkList.Add(rep_ParaWork);

                registRepList.Add(rep_StockAdjustWorkList);
                registRepList.Add(rep_StockAdjustDtlWorkList);

                // 補充元の在庫調整データをリストに追加
                registList.Add(registRepList);
            }

            // 倉庫Dictionaryを倉庫リストにコピー
            foreach (string warehouseCode in warehouseDic.Keys)
            {
                warehouseList.Add(warehouseCode);
            }
        }
        // ADD 2009/05/15 ------<<<
            
        // ---ADD 2009/04/27 不具合対応[13091] --------------------------------------------------------->>>>>
        /// <summary>
        /// 仕入拠点取得
        /// </summary>
        /// <param name="warehouseCode">倉庫</param>
        /// <param name="stockList">在庫リスト</param>
        /// <returns>仕入拠点</returns>
        private string GetStockSectionCodeFromStockList(string warehouseCode, List<Stock> stockList)
        {
            string stockSectionCode = string.Empty;

            for (int i = 0; i < stockList.Count; i++)
            {
                if (stockList[i].WarehouseCode.Trim() == warehouseCode.Trim())
                {
                    stockSectionCode = stockList[i].SectionCode;
                    break;
                }
            }
            return stockSectionCode;
        }
        // ---ADD 2009/04/27 不具合対応[13091] ---------------------------------------------------------<<<<<

        // ADD 2009/05/15 ------>>>
        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫マスタ読み込み、バッファに保持します。</br>
        /// <br />
        /// </remarks>
        private void ReadWarehouse()
        {
            this._warehouseDic = new Dictionary<string, Warehouse>();

            ArrayList retList;
            int status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);

            if (status == 0)
            {
                foreach (Warehouse warehouse in retList)
                {
                    string key = warehouse.WarehouseCode.Trim().PadLeft(4, '0');
                    if (!this._warehouseDic.ContainsKey(key))
                    {
                        this._warehouseDic.Add(key, warehouse);
                    }
                }
            }
        }

        /// <summary>
        /// 倉庫管理拠点コード取得
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>管理拠点コード</returns>
        /// <remarks>
        /// <br>Note       : 倉庫の管理拠点コードを取得します。</br>
        /// <br />
        /// </remarks>
        private string GetSectionCodeFromWarehouse(string warehouseCode)
        {
            string key = warehouseCode.Trim().PadLeft(4, '0');

            if (this._warehouseDic.ContainsKey(key))
            {
                return this._warehouseDic[key].SectionCode.Trim().PadLeft(2, '0');
            }

            return "";
        }

        /// <summary>
        /// 在庫調整明細データワーク追加
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="stockAdjustDtlWork">在庫調整明細データワーク</param>
        /// <param name="dictionary">在庫調整明細データディクショナリー</param>
        /// <remarks>
        /// <br>Note       : 倉庫単位で在庫調整明細データを追加します。</br>
        /// <br />
        /// </remarks>
        private void AddParaDtlWorkDic(string warehouseCode, StockAdjustDtlWork stockAdjustDtlWork, ref Dictionary<string, ArrayList> dictionary)
        {
            string key = warehouseCode.Trim().PadLeft(4, '0');
            ArrayList list;

            if (!dictionary.ContainsKey(key))
            {
                list = new ArrayList();
                list.Add(stockAdjustDtlWork);
                dictionary.Add(key, list);
            }
            else
            {
                list = dictionary[key];
                // 在庫調整行番号の更新
                stockAdjustDtlWork.StockAdjustRowNo += list.Count;
                list.Add(stockAdjustDtlWork);
                dictionary.Remove(key);
                dictionary.Add(key, list);
            }
        }

        /// <summary>
        /// 仕入金額追加
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="stockPriceTaxExc">仕入金額</param>
        /// <param name="dictionary">仕入金額ディクショナリー</param>
        /// <remarks>
        /// <br>Note       : 倉庫単位で仕入金額を集計します。</br>
        /// <br />
        /// </remarks>
        private void AddStockPriceTaxExcDic(string warehouseCode, long stockPriceTaxExc, ref Dictionary<string, long> dictionary)
        {
            string key = warehouseCode.Trim().PadLeft(4, '0');

            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, stockPriceTaxExc);
            }
            else
            {
                long wk = dictionary[key] + stockPriceTaxExc;
                dictionary.Remove(key);
                dictionary.Add(key, wk);
            }
        }
        // ADD 2009/05/15 ------<<<
        
        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索 4:ハイフン無し完全一致</returns>
        /// <remarks>
        /// Note       : 商品検索タイプを取得します。<br />
        /// Programer  : 30414 忍 幸史<br />
        /// Date       : 2008/07/24<br />
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                // *が存在しない
                if (searchCode.Contains("-") == true)
                {
                    // ハイフン含む
                    return 0;
                }
                else
                {
                    // ハイフン含まない
                    return 4;
                }
            }
        }

        /// <summary>
        /// 商品連結データDictionary取得処理
        /// </summary>
        /// <param name="goodsUnitDataDic">商品連結データDictionary</param>
        /// <param name="trustStockResultList">委託在庫補充処理リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データDictionaryを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private int GetGoodsUnitDataDic(ref Dictionary<string, GoodsUnitData> goodsUnitDataDic, List<TrustStockResult> trustStockResultList)
        {
            goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();

            string searchCode;

            // 商品抽出条件リスト作成のため、メーカーコード・品番の重複を排除
            Dictionary<string, TrustStockResult> trustStockResultDic = new Dictionary<string, TrustStockResult>();
            foreach (TrustStockResult trustStockResult in trustStockResultList)
            {
                string key = trustStockResult.GoodsMakerCd.ToString("0000") + trustStockResult.GoodsNo.Trim();

                if (trustStockResultDic.ContainsKey(key))
                {
                    continue;
                }

                trustStockResultDic.Add(key, trustStockResult);
            }

            // Dictionaryから商品抽出条件リスト作成
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            foreach (TrustStockResult trustStockResult in trustStockResultDic.Values)
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                goodsCndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                goodsCndtn.GoodsMakerCd = trustStockResult.GoodsMakerCd;
                goodsCndtn.GoodsNoSrchTyp = GetSearchType(trustStockResult.GoodsNo, out searchCode);    // 商品番号検索区分
                goodsCndtn.GoodsNo = searchCode;                                                        // 品番
                goodsCndtn.GoodsKindCode = 9;

                goodsCndtnList.Add(goodsCndtn);
            }

            // 商品連結データリスト取得
            string errMsg;
            List<List<GoodsUnitData>> retGoodsUnitDataList;
            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out retGoodsUnitDataList, out errMsg);
            if (status == 0)
            {
                foreach (List<GoodsUnitData> goodsUnitDataList in retGoodsUnitDataList)
                {
                    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                    {
                        string key = goodsUnitData.GoodsMakerCd.ToString("0000") + goodsUnitData.GoodsNo.Trim();

                        if (goodsUnitDataDic.ContainsKey(key))
                        {
                            continue;
                        }

                        goodsUnitDataDic.Add(key, goodsUnitData);
                    }
                }
            }
            else
            {
                return (status);
            }

            return (0);
        }

        /// <summary>
        /// データテーブル設定処理
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        /// <param name="trustStockResultList">委託在庫補充データリスト</param>
        /// <remarks>
        /// <br>Note       : 委託在庫補充データをデータテーブルに設定します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private void SetDataTableFromTrustStockOrder(ref DataTable dataTable, List<TrustStockResult> trustStockResultList)
        {
            foreach (TrustStockResult trustStockResult in trustStockResultList)
            {
                DataRow dr = dataTable.NewRow();
                
                dr[PMZAI02069EA.ct_Col_MakerCode] = trustStockResult.GoodsMakerCd.ToString("0000");
                dr[PMZAI02069EA.ct_Col_MakerName] = trustStockResult.MakerShortName.Trim();
                dr[PMZAI02069EA.ct_Col_GoodsNo] = trustStockResult.GoodsNo.Trim();
                dr[PMZAI02069EA.ct_Col_GoodsName] = trustStockResult.GoodsName.Trim();
                dr[PMZAI02069EA.ct_Col_AfWarehouseCode] = trustStockResult.Tru_WarehouseCode.Trim();
                dr[PMZAI02069EA.ct_Col_AfWarehouseName] = trustStockResult.Tru_WarehouseName.Trim();
                dr[PMZAI02069EA.ct_Col_AfWarehouseShelfNo] = trustStockResult.Tru_WarehouseShelfNo.Trim();
                dr[PMZAI02069EA.ct_Col_MaximumStockCnt] = trustStockResult.MaximumStockCnt;
                dr[PMZAI02069EA.ct_Col_AfSupplierStock] = trustStockResult.Tru_ShipmentPosCnt;
                dr[PMZAI02069EA.ct_Col_Replenishment] = trustStockResult.ReplenishCount;
                dr[PMZAI02069EA.ct_Col_BfWarehouseCode] = trustStockResult.Rep_WarehouseCode.Trim();
                dr[PMZAI02069EA.ct_Col_BfWarehouseName] = trustStockResult.Rep_WarehouseName.Trim();
                dr[PMZAI02069EA.ct_Col_BfWarehouseShelfNo] = trustStockResult.Rep_WarehouseShelfNo.Trim();
                dr[PMZAI02069EA.ct_Col_BfSupplierStock] = trustStockResult.Rep_ShipmentPosCnt;
                dr[PMZAI02069EA.ct_Col_BfAfterSupplierStock] = trustStockResult.ReplenishNStockCount;
                if (trustStockResult.GoodsFlg == 0)
                {
                    dr[PMZAI02069EA.ct_Col_Note] = "";
                }
                else
                {
                    dr[PMZAI02069EA.ct_Col_Note] = "補充元在庫ﾏｽﾀ未登録";
                }

                dataTable.Rows.Add(dr);
            }
        }

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="para">移動在庫補充処理条件クラス</param>
        /// <returns>移動在庫補充処理条件ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private TrustStockOrderCndtnWork CopyToTrustStockOrderCndtnWorkFromTrustStockOrderCndtn(TrustStockOrderCndtn para)
        {
            TrustStockOrderCndtnWork paraWork = new TrustStockOrderCndtnWork();

            paraWork.EnterpriseCode = para.EnterpriseCode;
            paraWork.ReplenishLackStock = para.ReplenishLackStock;
            paraWork.ReplenishNoneGoods = para.ReplenishNoneGoods;
            paraWork.St_WarehouseCode = para.St_WarehouseCode;
            paraWork.Ed_WarehouseCode = para.Ed_WarehouseCode;
            paraWork.St_GoodsMakerCd = para.St_GoodsMakerCd;
            paraWork.Ed_GoodsMakerCd = para.Ed_GoodsMakerCd;
            paraWork.St_GoodsNo = para.St_GoodsNo;
            paraWork.Ed_GoodsNo = para.Ed_GoodsNo;

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="para">移動在庫補充処理結果ワーククラス</param>
        /// <returns>移動在庫補充処理結果クラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        private TrustStockResult CopyToTrustStockResultFromTrustStockResultWork(TrustStockResultWork retWork)
        {
            TrustStockResult ret = new TrustStockResult();

            ret.EnterpriseCode = retWork.EnterpriseCode;
            ret.GoodsMakerCd = retWork.GoodsMakerCd;
            ret.MakerShortName = retWork.MakerShortName;
            ret.GoodsNo = retWork.GoodsNo;
            ret.GoodsName = retWork.GoodsName;
            ret.MaximumStockCnt = retWork.MaximumStockCnt;
            ret.Rep_ShipmentPosCnt = retWork.Rep_ShipmentPosCnt;
            ret.Rep_WarehouseCode = retWork.Rep_WarehouseCode;
            ret.Rep_WarehouseName = retWork.Rep_WarehouseName;
            ret.Rep_WarehouseShelfNo = retWork.Rep_WarehouseShelfNo;
            ret.ReplenishCount = retWork.ReplenishCount;
            ret.ReplenishNStockCount = retWork.ReplenishNStockCount;
            ret.Tru_ShipmentPosCnt = retWork.Tru_ShipmentPosCnt;
            ret.Tru_WarehouseCode = retWork.Tru_WarehouseCode;
            ret.Tru_WarehouseName = retWork.Tru_WarehouseName;
            ret.Tru_WarehouseShelfNo = retWork.Tru_WarehouseShelfNo;
            ret.GoodsFlg = retWork.GoodsFlg;

            return ret;
        }
        #endregion ■ Private Methods
    }
}
