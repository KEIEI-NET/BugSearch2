//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫組立・分解処理
// プログラム概要   : 在庫組立・分解処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 980035 金沢 貞義
// 作 成 日  2008/11/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 980035 金沢 貞義
// 作 成 日  2009/01/26  修正内容 : 不具合修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 980035 金沢 貞義
// 作 成 日  2009/02/03  修正内容 : 在庫調整データにセットする従業員名称を16バイトで切るように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/02/12  修正内容 : 障害対応11064(速度アップ対応)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 作 成 日  2009/02/26  修正内容 : 障害対応11945
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 作 成 日  2009/03/10  修正内容 : 障害対応12283
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/22  修正内容 : 障害対応13205
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2009/04/27  修正内容 : 不具合対応[13091]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2009/04/28  修正内容 : 不具合対応[13227]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 作 成 日  2009/05/07  修正内容 : 不具合対応[13226]
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 在庫組立・分解処理アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 在庫組立・分解処理アクセスクラスの機能を実装する。</br>
    /// <br>Programmer : 980035 金沢 貞義</br>
	/// <br>Date       : 2008.11.05</br>
    /// <br>UpdateNote : 2009.01.26　金沢 貞義</br>
    /// <br>             不具合修正</br>
    /// <br>UpdateNote : 2009.02.03　金沢 貞義</br>
    /// <br>             在庫調整データにセットする従業員名称を16バイトで切るように修正</br>
    /// <br>UpdateNote : 2009.02.12　上野 俊治</br>
    /// <br>             障害対応11064(速度アップ対応)</br>
    /// <br>UpdateNote : 2009.02.26　忍 幸史</br>
    /// <br>             障害対応11945</br>
    /// <br>UpdateNote : 2009.03.10　忍 幸史</br>
    /// <br>             障害対応12283</br>
    /// <br>           : 2009/04/22　犬飼</br>
    /// <br>             障害対応13205</br>
    /// <br>           : 2009/04/27　照田 貴志</br>
    /// <br>             不具合対応[13091]</br>
    /// <br>           : 2009/04/28　照田 貴志</br>
    /// <br>             不具合対応[13227]</br>
    /// <br>           : 2009/05/07　照田 貴志</br>
    /// <br>             不具合対応[13226]</br>
    /// </remarks>
	public class StckAssemOvhulAcs
	{
		# region Constructor
		/// <summary>
		/// 在庫組立・分解処理アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫組立・分解処理アクセスクラスのインスタンスを生成する。</br>
		/// </remarks>
		public StckAssemOvhulAcs()
		{			
			// ログイン情報生成 //			
			// 企業コード
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //ログイン従業員コード
            this._employeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
            //ログイン従業員名称
            this._employeeName = LoginInfoAcquisition.Employee.Name;
            // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			
			// リモートオブジェクト取得 //	
            // 各種アクセスクラス取得
            this._goodsAcs = new GoodsAcs();
            this._supplierAcs = new SupplierAcs();
            this._iStockAdjustDB = MediationStockAdjustDB.GetStockAdjustDB();
            this._secInfoAcs = new SecInfoAcs();

            //単価算出モジュール取得
            this._unitPriceCalculation = new UnitPriceCalculation();

            // 2009.02.03 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //ログイン拠点名称
            this._loginSectionGuideNm = this.LoadSecInfoSet();
            // 2009.02.03 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //在庫組立分解データセット格納
			this.PrtStckAssemOvhulDataSetting();
		}
		# endregion

        # region Public Const

        // テーブル設定		
        /// <summary>データソース名称（在庫組立分解）</summary>
        public const string ctPrtStckAssemOvhul_Table = "PrtStckAssemOvhul_Table";
        /// <summary>テーブル名称（在庫組立分解）</summary>
        public const string ctM_PrtStckAssemOvhul_Table = "m_PrtStckAssemOvhul_Table";

        // テーブル（在庫組立・分解処理）カラム設定
        /// <summary>№</summary>
        public const string ctDisplayNo = "DisplayNo";
        /// <summary>表示順位</summary>
        public const string ctDisplayOrder = "DisplayOrder";
        /// <summary>子商品番号</summary>	
        public const string ctSubGoodsNo = "SubGoodsNo";
        /// <summary>子商品名称</summary>
        public const string ctSubGoodsName = "SubGoodsName";
        /// <summary>子商品メーカーコード</summary>
        public const string ctSubGoodsMakerCd = "SubGoodsMakerCd";
        /// <summary>QTY（文字）</summary>
        public const string ctCntFlSt = "CntFlSt";
        /// <summary>QTY</summary>
        public const string ctCntFl = "CntFl";
        /// <summary>提供区分</summary>
        public const string ctDivision = "Division";
        /// <summary>子現在在庫数（文字）</summary>
        public const string ctShipmentPosCnt = "ShipmentPosCnt";
        /// <summary>子現在在庫数</summary>
        public const string ctSubSupplierStock = "SubSupplierStock";
        /// <summary>子倉庫コード</summary>
        public const string ctSubWarehouseCd = "SubWarehouseCd";

        /// <summary>提供区分 ユーザー</summary>
        public const string DIVISION_NAME_USER = "ユーザー";
        /// <summary>提供区分 提供</summary>
        public const string DIVISION_NAME_OFFER = "提供";

        #endregion

        # region Public Property
        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// <summary>
        /// 
        /// </summary>
        public double TaxRate
        {
            get { return this._taxRate; }
        }
        // --- ADD 2009/02/12 --------------------------------<<<<<
        #endregion

        # region Private Members

        // 変数 //		
		// ログイン情報
		private string _enterpriseCode;
        private string _loginSectionCode;
        // 2009.02.03 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private string _loginSectionGuideNm;
        // 2009.02.03 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //private List<string> _sectWarehouseCd;
        private string _targetWarehouseCd;
        // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private string _employeeCode;
        private string _employeeName;
        // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //private string _stockSectionCode;               //ADD 2009/04/27 不具合対応[13091]    //DEL 2009/05/07 不具合対応[13226]
        //private string _stockSectionGuideNm;            //ADD 2009/04/27 不具合対応[13091]    //DEL 2009/05/07 不具合対応[13226]

        private ArrayList _prtParentGoodsWorkList;
        private ArrayList _prtGoodsSetWorkList;
        private DataSet _prtGoodsSetDataSet;

		// リモートインターフェース //
        // 商品マスタアクセスクラス
        private GoodsAcs _goodsAcs = null;

        // 拠点アクセスクラス
        private SecInfoAcs _secInfoAcs = null;

        /// <summary>仕入先マスタ アクセスクラス</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>単価算出クラス</summary>
        private UnitPriceCalculation _unitPriceCalculation;

        /// <summary>在庫調整データ</summary>
        private IStockAdjustDB _iStockAdjustDB;

        private double _taxRate = 0; // ADD 2009/02/12

        # endregion

        # region Private Methods

        #region 商品情報取得処理

        /// <summary>
        /// 商品検索（セット情報）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <returns></returns>
        public int SearchGoodsAndGoodsSet(string enterpriseCode, string sectionCode, int goodsMakerCode, string goodsNo, out PartsInfoDataSet partsInfoDataSet)
        {
            return this.SearchGoodsAndGoodsSetProc(enterpriseCode, sectionCode, goodsMakerCode, goodsNo, out partsInfoDataSet);
        }

        /// <summary>
        /// 商品検索（同一品番表示情報取得）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <returns></returns>
        private int SearchGoodsAndGoodsSetProc(string enterpriseCode, string sectionCode, int goodsMakerCode, string goodsNo, out PartsInfoDataSet partsInfoDataSet)
        {
            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            string msg;
            //PartsInfoDataSet partsInfoDataSet;
            List<GoodsUnitData> goodsUnitDataList;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.GoodsMakerCd = goodsMakerCode;
            cndtn.GoodsNo = goodsNo;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.SearchUICntDivCd = 1; // PM.NS式画面制御
            //cndtn.PartsNoSearchDivCd = this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue;   //品番検索区分（0:PM7(セットのみ),1:結合・セット・代替あり）エントリからの部品検索時のみ有効
            //cndtn.PartsSearchPriDivCd = this.GetSalesTtlSt().PartsSearchPriDivCd;     //部品検索優先順区分（0:純正,1:優良）
            cndtn.IsSettingSupplier = 1; // ADD 2009/02/12

            //-----------------------------------------------------------------------------
            // 部品検索
            //-----------------------------------------------------------------------------
            int status = this.SearchPartsFromGoodsNo(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // 選択無し
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理

                    if (partsInfoDataSet.UsrGoodsInfo.Count >= 1)
                    {
                        //-------------------------------------------------------------------------
                        // 商品連結データオブジェクトリスト変換
                        //-------------------------------------------------------------------------
                        goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(false).ToArray(typeof(GoodsUnitData)));

                        //-------------------------------------------------------------------------
                        // 商品連結データ不足情報設定
                        //-------------------------------------------------------------------------
                        this.SettingGoodsUnitDataListFromVariousMst(cndtn, ref goodsUnitDataList);

                        //-----------------------------------------------------------------------------
                        // 単価情報取得
                        //-----------------------------------------------------------------------------
                        unitPriceCalcRetList = this.CalclationUnitPrice(cndtn, goodsUnitDataList);

                        //-----------------------------------------------------------------------------
                        // 単価情報を部品検索データセットへ反映
                        //-----------------------------------------------------------------------------
                        if ((unitPriceCalcRetList != null) && (unitPriceCalcRetList.Count != 0)) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    }
                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // 該当データ無し
                    this._prtGoodsSetDataSet = new DataSet(ctPrtStckAssemOvhul_Table);
                    this._prtParentGoodsWorkList = new ArrayList();
                    this._prtParentGoodsWorkList.Clear();
                    this._prtGoodsSetWorkList = new ArrayList();
                    this._prtGoodsSetWorkList.Clear();
                    break;
            }
            return status;
        }

        /// <summary>
        /// 商品検索（セット情報取得）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <returns></returns>
        public int ReadStckAssemOvhul(string enterpriseCode, string sectionCode, int goodsMakerCode, string goodsNo, PartsInfoDataSet partsInfoDataSet)
        {
            int status = 0;
            List<GoodsUnitData> goodsUnitData;
            List<GoodsUnitData> goodsUnitDataList;

            this._prtParentGoodsWorkList = new ArrayList();
            this._prtParentGoodsWorkList.Clear();
            this._prtGoodsSetWorkList = new ArrayList();
            this._prtGoodsSetWorkList.Clear();
            this._targetWarehouseCd = string.Empty;
            //this._sectWarehouseCd = partsInfoDataSet.ListPriorWarehouse;

            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.GoodsMakerCd = goodsMakerCode;
            cndtn.GoodsNo = goodsNo;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

            if (partsInfoDataSet.UsrGoodsInfo.Count >= 1)
            {
                //-------------------------------------------------------------------------
                // 商品連結データオブジェクトリスト変換
                //-------------------------------------------------------------------------
                goodsUnitData = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true).ToArray(typeof(GoodsUnitData)));
                if (goodsUnitData.Count == 0)
                {
                    this._prtGoodsSetDataSet = new DataSet(ctPrtStckAssemOvhul_Table);
                    if (partsInfoDataSet.Stock.Count == 0)
                    {
                        // 在庫未登録
                        return 91;
                    }
                    else
                    {
                        // セットマスタ未登録
                        return 92;
                    }
                }

                //-------------------------------------------------------------------------
                // 商品連結データ不足情報設定
                //-------------------------------------------------------------------------
                this.SettingGoodsUnitDataListFromVariousMst(cndtn, ref goodsUnitData);


                foreach (GoodsUnitData wkGoodsUnitData in goodsUnitData)
                {
                    this._prtParentGoodsWorkList.Add(CopyToParentGoodsFromGoodsUnitData(wkGoodsUnitData));
                }


                if (this._prtParentGoodsWorkList.Count >= 1)
                {
                    //-------------------------------------------------------------------------
                    // 商品連結データオブジェクトリスト変換（セット情報）
                    //-------------------------------------------------------------------------
                    ParentGoods targetParentGoodsWork = (ParentGoods)this._prtParentGoodsWorkList[0];
                    goodsUnitDataList = new List<GoodsUnitData>(partsInfoDataSet.GetGoodsList(4, targetParentGoodsWork.ParentGoodsMakerCd, targetParentGoodsWork.ParentGoodsNo));

                    //-------------------------------------------------------------------------
                    // 商品連結データ不足情報設定
                    //-------------------------------------------------------------------------
                    this.SettingGoodsUnitDataListFromVariousMst(cndtn, ref goodsUnitDataList);

                    //-------------------------------------------------------------------------
                    // 該当優先倉庫情報取得
                    //-------------------------------------------------------------------------
                    this._targetWarehouseCd = targetParentGoodsWork.ParentWarehouseCode.Trim();


                    foreach (GoodsUnitData wkGoodsUnitData in goodsUnitDataList)
                    {
                        this._prtGoodsSetWorkList.Add(CopyToSubGoodsSetFromGoodsUnitData(wkGoodsUnitData));
                    }
                    this._prtGoodsSetWorkList.Sort(new StckGoodsSetComparer());

                    //グリッドパラメータセット
                    PrtStckAssemOvhulDataSetting();
                }
                else
                {
                    this._prtGoodsSetDataSet = new DataSet(ctPrtStckAssemOvhul_Table);
                    status = 93;
                }
            }
            else
            {
                this._prtGoodsSetDataSet = new DataSet(ctPrtStckAssemOvhul_Table);
                status = 94;
            }

            return status;
        }

        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="cndtn">商品検索抽出条件クラス</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns></returns>
        private int SearchPartsFromGoodsNo(GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            return this._goodsAcs.SearchPartsFromGoodsNo(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg);
        }

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <param name="cndtn">商品検索抽出条件クラス</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private void SettingGoodsUnitDataListFromVariousMst(GoodsCndtn cndtn, ref List<GoodsUnitData> goodsUnitDataList)
        {
            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();
                this.SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData);
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;
        }

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <param name="cndtn">商品検索条件クラス</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        private void SettingGoodsUnitDataListFromVariousMst(ref GoodsUnitData goodsUnitData)
        {
            //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1); // ADD 2009/02/12
        }

        #region ●　単価算出処理
        /// <summary>
        /// 単価算出モジュールにより、単価を産出します。
        /// </summary>
        /// <param name="goodsCndtn">商品連結データ抽出条件オブジェクトリスト</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice(GoodsCndtn goodsCndtn, List<GoodsUnitData> goodsUnitDataList)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            // 仕入単価端数処理コードディクショナリ
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();
            // 仕入消費税端数処理コードディクショナリ
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();
            // 仕入単価端数処理コード
            int stockUnPrcFrcProcCd = 0;
            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = 0;

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BLコード
                    unitPriceCalcParam.CountFl = 0;                                                 // 数量
                    unitPriceCalcParam.CustomerCode = goodsCndtn.CustomerCode;                      // 得意先コード
                    unitPriceCalcParam.CustRateGrpCode = goodsCndtn.CustRateGrpCode;                // 得意先掛率グループコード
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // メーカーコード
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 商品番号
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
                    unitPriceCalcParam.PriceApplyDate = goodsCndtn.PriceApplyDate;                  // 価格適用日
                    unitPriceCalcParam.SalesUnPrcFrcProcCd = goodsCndtn.SalesUnPrcFrcProcCd;        // 売上単価端数処理コード
                    unitPriceCalcParam.SectionCode = goodsCndtn.SectionCode;                        // 拠点コード

                    if (stockUnPrcFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                    {
                        stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[goodsUnitData.SupplierCd];
                    }
                    else
                    {
                        stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                        stockUnPrcFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockUnPrcFrcProcCd);
                    }
                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // 仕入単価端数処理コード

                    unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                       // 仕入先コード
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // 課税区分
                    unitPriceCalcParam.TaxRate = goodsCndtn.TaxRate;                                // 税率
                    unitPriceCalcParam.TotalAmountDispWayCd = goodsCndtn.TotalAmountDispWayCd;      // 総額表示方法区分
                    unitPriceCalcParam.TtlAmntDspRateDivCd = goodsCndtn.TtlAmntDspRateDivCd;	    // 総額表示掛率適用区分
                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = goodsCndtn.SalesCnsTaxFrcProcCd;      // 売上消費税端数処理コード

                    if (stockCnsTaxFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                    {
                        stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[goodsUnitData.SupplierCd];
                    }
                    else
                    {
                        stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        stockCnsTaxFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockCnsTaxFrcProcCd);
                    }
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;                 // 仕入消費税端数処理コード

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }
        #endregion

        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// <summary>
        /// 税率取得処理
        /// </summary>
        /// <param name="taxRateSet"></param>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        private double GetTaxRate(TaxRateSet taxRateSet, DateTime addUpADate)
        {
            if (taxRateSet == null)
            {
                this._taxRate = 0;
            }
            else
            {
                this._taxRate = 0;

                if ((addUpADate >= taxRateSet.TaxRateStartDate) &&
                    (addUpADate <= taxRateSet.TaxRateEndDate))
                {
                    this._taxRate = taxRateSet.TaxRate;
                }
                else if ((addUpADate >= taxRateSet.TaxRateStartDate2) &&
                         (addUpADate <= taxRateSet.TaxRateEndDate2))
                {
                    this._taxRate = taxRateSet.TaxRate2;
                }
                else if ((addUpADate >= taxRateSet.TaxRateStartDate3) &&
                         (addUpADate <= taxRateSet.TaxRateEndDate3))
                {
                    this._taxRate = taxRateSet.TaxRate3;
                }
            }
            return this._taxRate;
        }
        // --- ADD 2009/02/12 --------------------------------<<<<<
        #endregion

        #region 拠点情報マスタ読込処理
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        private string LoadSecInfoSet()
        {
            SecInfoSet secInfoSet;
            //this._sectWarehouseCd = new List<string>();

            int status = this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

            string sectionName = string.Empty;
            if (status == 0)
            {
                sectionName = secInfoSet.SectionGuideNm;
            }

            return sectionName;
        }

        // ---ADD 2009/04/27 不具合対応[13091] ----------------------------------------->>>>>
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        private string LoadSecInfoSet(string sectionCode)
        {
            SecInfoSet secInfoSet;

            int status = this._secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);

            string sectionName = string.Empty;
            if (status == 0)
            {
                sectionName = secInfoSet.SectionGuideNm;
            }

            return sectionName;
        }
        // ---ADD 2009/04/27 不具合対応[13091] -----------------------------------------<<<<<
        #endregion

        #region 在庫組立分解データセット格納
        /// <summary>
        /// 在庫組立分解データセット格納
        /// </summary>	
        private void PrtStckAssemOvhulDataSetting()
        {
            DataSet dataSet = null;
            DataTable dt;
            DataRow dr;

            if (this._prtGoodsSetDataSet == null)
            {
                this._prtGoodsSetDataSet = new DataSet(ctPrtStckAssemOvhul_Table);
            }

            dataSet = this._prtGoodsSetDataSet;

            //既にデータテーブルが存在するか？
            if (dataSet.Tables.Contains(ctM_PrtStckAssemOvhul_Table))
            {
                dt = dataSet.Tables[ctM_PrtStckAssemOvhul_Table];
            }
            else
            {
                //テーブル作成
                dt = dataSet.Tables.Add(ctM_PrtStckAssemOvhul_Table);

                dt.Columns.Add(new DataColumn(ctDisplayNo, typeof(int)));		    // №
                dt.Columns.Add(new DataColumn(ctSubGoodsNo, typeof(string)));		// 子商品番号	
                dt.Columns.Add(new DataColumn(ctSubGoodsName, typeof(string)));     // 子商品名称
                dt.Columns.Add(new DataColumn(ctSubGoodsMakerCd, typeof(string)));  // 子商品メーカーコード
                dt.Columns.Add(new DataColumn(ctCntFlSt, typeof(string)));          // QTY（文字）
                dt.Columns.Add(new DataColumn(ctDivision, typeof(string)));         // 提供区分
                dt.Columns.Add(new DataColumn(ctShipmentPosCnt, typeof(string)));   // 子現在在庫数（文字）
                dt.Columns.Add(new DataColumn(ctCntFl, typeof(double)));            // QTY
                dt.Columns.Add(new DataColumn(ctSubSupplierStock, typeof(double))); // 子現在在庫数
                dt.Columns.Add(new DataColumn(ctSubWarehouseCd, typeof(string)));	// 倉庫コード
                dt.Columns.Add(new DataColumn(ctDisplayOrder, typeof(int)));		// 表示順位

                dt.Columns[ctDisplayNo].Caption = "№";				            // №
                dt.Columns[ctSubGoodsNo].Caption = "品番";				        // 子商品番号	
                dt.Columns[ctSubGoodsName].Caption = "品名";		            // 子商品名称
                dt.Columns[ctSubGoodsMakerCd].Caption = "ﾒｰｶｰ";                 // 子商品メーカーコード
                dt.Columns[ctCntFlSt].Caption = "QTY";				            // QTY
                dt.Columns[ctDivision].Caption = "提供";                        // 提供区分
                dt.Columns[ctShipmentPosCnt].Caption = "現在庫数";              // 子現在在庫数（文字）
            }

            dt.Clear();

            if (this._prtGoodsSetWorkList != null)
            {
                //データセット格納処理
                SubGoodsSet targetStckGoodsSetWork;

                for (int workCounter = 0; workCounter < this._prtGoodsSetWorkList.Count; workCounter++)
                {
                    targetStckGoodsSetWork = (SubGoodsSet)this._prtGoodsSetWorkList[workCounter];

                    // DataRowを作成
                    dr = dt.NewRow();

                    //データテーブル作成
                    // 表示順位
                    dr[ctDisplayNo] = workCounter + 1;

                    // 子商品番号	
                    dr[ctSubGoodsNo] = targetStckGoodsSetWork.SubGoodsNo;
                    // 子商品名称
                    dr[ctSubGoodsName] = targetStckGoodsSetWork.SubGoodsNameKana;
                    // 子商品メーカーコード
                    dr[ctSubGoodsMakerCd] = targetStckGoodsSetWork.SubGoodsMakerCd.ToString("0000");
                    // セットQTY（文字）
                    dr[ctCntFlSt] = targetStckGoodsSetWork.CntFl.ToString("N");
                    // セットQTY
                    dr[ctCntFl] = targetStckGoodsSetWork.CntFl;
                    // 子現在在庫数（文字）
                    dr[ctShipmentPosCnt] = targetStckGoodsSetWork.SubSupplierStock.ToString("N");
                    // 子現在在庫数
                    dr[ctSubSupplierStock] = targetStckGoodsSetWork.SubSupplierStock;
                    // 倉庫コード
                    dr[ctSubWarehouseCd] = targetStckGoodsSetWork.SubWarehouseCd;

                    // 提供区分
                    dr[ctDivision] =  targetStckGoodsSetWork.Division;

                    // 表示順位
                    dr[ctDisplayOrder] = targetStckGoodsSetWork.DisplayOrder;

                    dt.Rows.Add(dr);
                }
            }
        }
        #endregion

        #region 子品番次倉庫データセット格納
        /// <summary>
        /// 子品番次倉庫データセット格納
        /// </summary>	
        private void PrtStckAssemOvhulDataSetting(string warehouseCode)
        {
            DataSet dataSet = null;
            DataTable dt;
            DataRow dr;

            dataSet = this._prtGoodsSetDataSet;

            dt = dataSet.Tables[ctM_PrtStckAssemOvhul_Table];
            dt.Clear();

            if (this._prtGoodsSetWorkList != null)
            {
                //データセット格納処理
                SubGoodsSet targetStckGoodsSetWork;

                for (int workCounter = 0; workCounter < this._prtGoodsSetWorkList.Count; workCounter++)
                {
                    targetStckGoodsSetWork = (SubGoodsSet)this._prtGoodsSetWorkList[workCounter];

                    // DataRowを作成
                    dr = dt.NewRow();

                    //データテーブル作成
                    // 表示順位
                    dr[ctDisplayNo] = workCounter + 1;

                    // 子商品番号	
                    dr[ctSubGoodsNo] = targetStckGoodsSetWork.SubGoodsNo;
                    // 子商品名称
                    dr[ctSubGoodsName] = targetStckGoodsSetWork.SubGoodsNameKana;
                    // 子商品メーカーコード
                    dr[ctSubGoodsMakerCd] = targetStckGoodsSetWork.SubGoodsMakerCd.ToString("0000");
                    // セットQTY（文字）
                    dr[ctCntFlSt] = targetStckGoodsSetWork.CntFl.ToString("N");
                    // セットQTY
                    dr[ctCntFl] = targetStckGoodsSetWork.CntFl;
                    // 提供区分
                    dr[ctDivision] = targetStckGoodsSetWork.Division;
                    // 表示順位
                    dr[ctDisplayOrder] = targetStckGoodsSetWork.DisplayOrder;

                    // 子現在在庫数（文字）
                    dr[ctShipmentPosCnt] = "0.00";
                    // 子現在在庫数
                    dr[ctSubSupplierStock] = 0.00;
                    // 倉庫コード
                    dr[ctSubWarehouseCd] = string.Empty;


                    List<Stock> stock = targetStckGoodsSetWork.SubStockList;

                    // 拠点倉庫チェック
                    for (int ix = 0; ix < stock.Count; ix++)
                    {
                        if (stock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
                        {
                            dr[ctShipmentPosCnt] = stock[ix].ShipmentPosCnt.ToString("N");
                            dr[ctSubSupplierStock] = stock[ix].ShipmentPosCnt;
                            dr[ctSubWarehouseCd] = stock[ix].WarehouseCode;
                            break;
                        }
                    }

                    dt.Rows.Add(dr);
                }
            }
        }
        #endregion

        # endregion

        # region Public Methods

        #region 登録処理
        /// <summary>
		/// データ保存処理
		/// </summary>
		/// <param name="processDiv">処理区分</param>
		/// <param name="inputCnt">入力個数</param>
		/// <param name="retMsg">エラー時メッセージ</param>
		/// <returns>Status</returns>
        public int WriteDB(string warehouseCode, int processDiv, double inputCnt, out string retMsg)
        {
		    return WriteDBData(warehouseCode, processDiv, inputCnt, out retMsg);
		}

		/// <summary>
		/// 登録処理
		/// </summary>
		/// <param name="processDiv">処理区分</param>
		/// <param name="inputCnt">入力個数</param>
		/// <param name="retMsg">エラー時メッセージ</param>
		/// <returns>Status</returns>
        private int WriteDBData(string warehouseCode, int processDiv, double inputCnt, out string retMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			retMsg = "";		// エラー時メッセージ

            CustomSerializeArrayList saveData = this.CreateSaveData(warehouseCode, processDiv, inputCnt);
            object objSaveData = (object)saveData;

            if (saveData.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                status = this._iStockAdjustDB.WriteBatch(ref objSaveData, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //isSaved = true;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    foreach (Object data in (CustomSerializeArrayList)objSaveData)
                    {
                        if ((data is ArrayList) && ((ArrayList)data).Count > 0)
                        {
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }

            return status;
		}

        /// <summary>
        /// 保存用データ生成処理
        /// </summary>
        /// <returns>保存用データ(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : 保存用データを作成します。</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData(string warehouseCode, int processDiv, double inputCnt)
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList stockWorkList = new ArrayList();
            DateTime totalDay = DateTime.Today;

            #region DEL 2009/05/07 不具合対応[13226]
            //// --- ADD 2009/02/26 障害ID:11945対応------------------------------------------------------>>>>>
            //CustomSerializeArrayList tempList = new CustomSerializeArrayList();
            //// --- ADD 2009/02/26 障害ID:11945対応------------------------------------------------------<<<<<

            //// 在庫調整データを生成する。
            //// 2009.02.03 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////stockAdjustWorkList.Add(CreateStockAdjust(processDiv, totalDay));
            //StockAdjustWork targetStockAdjustWork = CreateStockAdjust(processDiv, totalDay);
            //// 2009.02.03 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //this._stockSectionCode = string.Empty;                                      //ADD 2009/04/27 不具合対応[13091]
            //this._stockSectionGuideNm = string.Empty;                                   //ADD 2009/04/27 不具合対応[13091]

            //// 在庫調整明細データを生成する。
            //CreateStockAdjustDtl(warehouseCode, processDiv, inputCnt, totalDay, ref stockAdjustDtlWorkList);

            //targetStockAdjustWork.StockSectionCd = this._stockSectionCode;              //ADD 2009/04/27 不具合対応[13091]
            //targetStockAdjustWork.StockSectionGuideNm = this._stockSectionGuideNm;      //ADD 2009/04/27 不具合対応[13091]

            //// 在庫マスタオブジェクトを生成する。
            //CreateStock(warehouseCode, processDiv, inputCnt, totalDay, ref stockWorkList);

            //// 2009.02.03 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 仕入金額小計算出
            //Int64 wkStockSubttlPrice = 0;
            //StockAdjustDtlWork targetStockAdjustDtlWork;

            //for (int ix = 0; ix < stockAdjustDtlWorkList.Count; ix++)
            //{
            //    targetStockAdjustDtlWork = (StockAdjustDtlWork)stockAdjustDtlWorkList[ix];
            //    wkStockSubttlPrice = wkStockSubttlPrice + targetStockAdjustDtlWork.StockPriceTaxExc;
            //}

            //targetStockAdjustWork.StockSubttlPrice = wkStockSubttlPrice;
            //stockAdjustWorkList.Add(targetStockAdjustWork);
            //// 2009.02.03 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //if (stockAdjustWorkList.Count > 0)
            //{
            //    // 在庫調整データ追加
            //    // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------>>>>>
            //    //saveDataList.Add(stockAdjustWorkList);
            //    tempList.Add(stockAdjustWorkList);
            //    // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------<<<<<
            //}

            //if (stockAdjustDtlWorkList.Count > 0)
            //{
            //    // 在庫調整明細データ追加
            //    // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------>>>>>
            //    //saveDataList.Add(stockAdjustDtlWorkList);
            //    tempList.Add(stockAdjustDtlWorkList);
            //    // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------<<<<<
            //}

            //if (stockWorkList.Count > 0)
            //{
            //    // 在庫マスタ追加
            //    // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------>>>>>
            //    //saveDataList.Add(stockWorkList);
            //    tempList.Add(stockWorkList);
            //    // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------<<<<<
            //}

            //// --- ADD 2009/02/26 障害ID:11945対応------------------------------------------------------>>>>>
            //saveDataList.Add(tempList);
            //// --- ADD 2009/02/26 障害ID:11945対応------------------------------------------------------<<<<<
            #endregion

            // ---ADD 2009/05/07 不具合対応[13226] ----------------------------->>>>>
            #region 親品番情報作成
            CustomSerializeArrayList tempList = new CustomSerializeArrayList();

            // 在庫調整データを生成する。
            StockAdjustWork targetStockAdjustWork = this.CreateStockAdjust(processDiv, totalDay);

            // 在庫調整明細データを生成する。(内部でStockSectionCodeを取得)
            string stockSectionCode = string.Empty;
            string stockSectionGuideNm = string.Empty;
            this.CreateStockAdjustDtlParentData(warehouseCode, processDiv, inputCnt, totalDay,
                                                ref stockAdjustDtlWorkList, out stockSectionCode, out stockSectionGuideNm);

            // 在庫調整データの仕入拠点を取得
            targetStockAdjustWork.StockSectionCd = stockSectionCode;
            targetStockAdjustWork.StockSectionGuideNm = stockSectionGuideNm;

            // 在庫調整データの仕入金額小計算出
            targetStockAdjustWork.StockSubttlPrice = this.GetStockSubttlPrice(stockAdjustDtlWorkList);
            stockAdjustWorkList.Add(targetStockAdjustWork);

            // 在庫マスタオブジェクトを生成する。
            this.CreateStockParentData(warehouseCode, processDiv, inputCnt, totalDay, ref stockWorkList);

            if (stockAdjustWorkList.Count > 0)
            {
                // 在庫調整データ追加
                tempList.Add(stockAdjustWorkList.Clone());
            }

            if (stockAdjustDtlWorkList.Count > 0)
            {
                // 在庫調整明細データ追加
                tempList.Add(stockAdjustDtlWorkList.Clone());
            }

            if (stockWorkList.Count > 0)
            {
                // 在庫マスタ追加
                tempList.Add(stockWorkList.Clone());
            }

            saveDataList.Add(tempList);
            #endregion

            #region 子品番情報作成
            for (int workCounter = 0; workCounter < this._prtGoodsSetWorkList.Count; workCounter++)
            {
                tempList = new CustomSerializeArrayList();

                // 在庫調整データを生成する。
                targetStockAdjustWork = this.CreateStockAdjust(processDiv, totalDay);

                // 在庫調整明細データを生成する。(内部でStockSectionCodeを取得)
                stockAdjustDtlWorkList.Clear();
                stockSectionCode = string.Empty;
                stockSectionGuideNm = string.Empty;
                this.CreateStockAdjustDtlChildData(warehouseCode, processDiv, inputCnt, totalDay, workCounter,
                                                   ref stockAdjustDtlWorkList, out stockSectionCode, out stockSectionGuideNm);

                // 在庫調整データの仕入拠点を取得
                targetStockAdjustWork.StockSectionCd = stockSectionCode;
                targetStockAdjustWork.StockSectionGuideNm = stockSectionGuideNm;

                // 在庫調整データの仕入金額小計算出
                targetStockAdjustWork.StockSubttlPrice = this.GetStockSubttlPrice(stockAdjustDtlWorkList);
                stockAdjustWorkList.Clear();
                stockAdjustWorkList.Add(targetStockAdjustWork);

                // 在庫マスタオブジェクトを生成する。
                stockWorkList.Clear();
                this.CreateStockChildData(warehouseCode, processDiv, inputCnt, totalDay, workCounter, ref stockWorkList);

                if (stockAdjustWorkList.Count > 0)
                {
                    // 在庫調整データ追加
                    tempList.Add(stockAdjustWorkList.Clone());
                }

                if (stockAdjustDtlWorkList.Count > 0)
                {
                    // 在庫調整明細データ追加
                    tempList.Add(stockAdjustDtlWorkList.Clone());
                }

                if (stockWorkList.Count > 0)
                {
                    // 在庫マスタ追加
                    tempList.Add(stockWorkList.Clone());
                }

                saveDataList.Add(tempList);
            }
            #endregion
            // ---ADD 2009/05/07 不具合対応[13226] -----------------------------<<<<<

            return saveDataList;
        }

        #region 在庫調整データ作成
        /// <summary>
        /// 在庫調整データワーククラス生成処理
        /// </summary>
        /// <param name="processDiv">処理区分</param>
        /// <param name="totalDay">処理日付</param>
        /// <returns>在庫調整データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データワーククラスを生成します。</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(int processDiv, DateTime totalDay)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // 2009.02.03 削除 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 拠点名称取得
            //string sectionGuideNm = this.LoadSecInfoSet();
            // 2009.02.03 削除 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            workData.SectionCode = this._loginSectionCode;
            // 拠点名称
            // 2009.02.03 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //workData.SectionGuideNm = sectionGuideNm;
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // 2009.02.03 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            if (processDiv == 0)
            {
                // 受払元伝票区分(60：組立)
                workData.AcPaySlipCd = 60;
            }
            else
            {
                // 受払元伝票区分(61：分解)
                workData.AcPaySlipCd = 61;
            }
            // 受払元取引区分(30：在庫数調整)
            workData.AcPayTransCd = 30;

            // 調整日付
            workData.AdjustDate = totalDay;
            // 入力日付
            workData.InputDay = totalDay;

            // ---DEL 2009/05/07 不具合対応[13226] ---------------------------------->>>>>
            //// 仕入拠点コード
            //workData.StockSectionCd = this._loginSectionCode;
            //// 仕入拠点名称
            //// 2009.02.03 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////workData.StockSectionGuideNm = sectionGuideNm;
            //workData.StockSectionGuideNm = this._loginSectionGuideNm;
            //// 2009.02.03 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // ---DEL 2009/05/07 不具合対応[13226] ----------------------------------<<<<<

            // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 仕入入力者コード
            workData.StockInputCode = this._employeeCode;
            // 2009.02.03 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 仕入入力者名称
            //workData.StockInputName = this._employeeName;
            // 2009.02.03 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // 仕入担当者コード
            workData.StockAgentCode = this._employeeCode;
            // 2009.02.03 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 仕入担当者名称
            //workData.StockAgentName = this._employeeName;
            if (this._employeeName.Length > 16)
            {
                // 仕入入力者名称
                workData.StockInputName = this._employeeName.Substring(0, 16);
                // 仕入担当者名称
                workData.StockAgentName = this._employeeName.Substring(0, 16);
            }
            else
            {
                // 仕入入力者名称
                workData.StockInputName = this._employeeName;
                // 仕入担当者名称
                workData.StockAgentName = this._employeeName;
            }
            // 2009.02.03 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return workData;
        }

        // ---ADD 2009/05/07 不具合対応[13226] ------------------------------------------>>>>>
        /// <summary>
        /// 仕入金額小計算出
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">在庫調整明細データ</param>
        /// <returns>仕入金額小計</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データを元に在庫調整データの仕入金額小計を算出します。</br>
        /// </remarks>
        private Int64 GetStockSubttlPrice(ArrayList stockAdjustDtlWorkList)
        {
            Int64 wkStockSubttlPrice = 0;
            StockAdjustDtlWork targetStockAdjustDtlWork;

            for (int ix = 0; ix < stockAdjustDtlWorkList.Count; ix++)
            {
                targetStockAdjustDtlWork = (StockAdjustDtlWork)stockAdjustDtlWorkList[ix];
                wkStockSubttlPrice = wkStockSubttlPrice + targetStockAdjustDtlWork.StockPriceTaxExc;
            }

            return wkStockSubttlPrice;
        }
        // ---ADD 2009/05/07 不具合対応[13226] ------------------------------------------<<<<<
        #endregion

        #region 在庫調整明細データ作成
        #region DEL 2009/05/07 不具合対応[13226]
        ///// <summary>
        ///// 在庫調整明細データワーククラス生成処理
        ///// </summary>
        ///// <param name="processDiv">処理区分</param>
        ///// <param name="totalDay">処理日付</param>
        ///// <param name="retList">在庫調整明細データリスト</param>
        ///// <returns>在庫調整明細データワーククラス</returns>
        ///// <remarks>
        ///// <br>Note       : 在庫調整明細データワーククラスを生成します。</br>
        ///// </remarks>
        //private void CreateStockAdjustDtl(string warehouseCode, int processDiv, double inputCnt, DateTime totalDay, ref ArrayList retList)
        //{
        //    #region 親品番情報作成
        //    ParentGoods parentData = (ParentGoods)this._prtParentGoodsWorkList[0];
        //    StockAdjustDtlWork workData = new StockAdjustDtlWork();

        //    // 企業コード
        //    workData.EnterpriseCode = this._enterpriseCode;
        //    // 拠点コード
        //    workData.SectionCode = this._loginSectionCode;
        //    // 2009.02.03 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //    // 拠点名称
        //    workData.SectionGuideNm = this._loginSectionGuideNm;
        //    // 2009.02.03 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //    // 在庫調整伝票番号
        //    workData.StockAdjustSlipNo = 0;
        //    // 在庫調整行番号
        //    workData.StockAdjustRowNo = retList.Count + 1;
        //    if (processDiv == 0)
        //    {
        //        // 受払元伝票区分(60：組立)
        //        workData.AcPaySlipCd = 60;
        //    }
        //    else
        //    {
        //        // 受払元伝票区分(61：分解)
        //        workData.AcPaySlipCd = 61;
        //    }
        //    // 受払元取引区分(30：在庫数調整)
        //    workData.AcPayTransCd = 30;
        //    // 調整日付
        //    workData.AdjustDate = totalDay;
        //    // 入力日付
        //    workData.InputDay = totalDay;

        //    // メーカーコード
        //    workData.GoodsMakerCd = parentData.ParentGoodsMakerCd;
        //    // メーカー名称
        //    workData.MakerName = parentData.ParentMakerName;
        //    // 商品コード
        //    workData.GoodsNo = parentData.ParentGoodsNo;
        //    // 商品名称
        //    workData.GoodsName = parentData.ParentGoodsName;
        //    // BLコード
        //    workData.BLGoodsCode = parentData.BLGoodsCode;
        //    // BLコード名称
        //    workData.BLGoodsFullName = parentData.BLGoodsFullName;
        //    // 明細備考
        //    // --- CHG 2009/03/10 障害ID:12283対応------------------------------------------------------>>>>>
        //    //workData.DtlNote = "在庫組立分解";
        //    workData.DtlNote = "";
        //    // --- CHG 2009/03/10 障害ID:12283対応------------------------------------------------------<<<<<

        //    // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //    // 定価（浮動）
        //    workData.ListPriceFl = parentData.ListPrice;
        //    // 仕入単価（税抜,浮動）
        //    workData.StockUnitPriceFl = parentData.SalesUnitCost;
        //    // 変更前仕入単価（浮動）
        //    workData.BfStockUnitPriceFl = parentData.SalesUnitCost;
        //    // オープン価格区分
        //    workData.OpenPriceDiv = parentData.OpenPriceDiv;
        //    // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //    // 調整数
        //    if (processDiv == 0)
        //    {
        //        // 組立
        //        workData.AdjustCount = inputCnt;
        //    }
        //    else
        //    {
        //        // 分解
        //        workData.AdjustCount = inputCnt * -1;
        //    }

        //    // 2009.02.03 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //    // 仕入金額（税抜き）
        //    Int64 wkStockPrice = (Int64)(workData.StockUnitPriceFl * workData.AdjustCount * 100);
        //    if ((wkStockPrice % 100) >= 50) wkStockPrice = (wkStockPrice / 100) + 1;
        //    else if ((wkStockPrice % 100) <= -50) wkStockPrice = (wkStockPrice / 100) - 1;
        //    else wkStockPrice = wkStockPrice / 100;
        //    workData.StockPriceTaxExc = wkStockPrice;
        //    // 2009.02.03 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //    // 倉庫チェック
        //    List<Stock> parentStock = parentData.ParentStockList;
        //    for (int ix = 0; ix < parentStock.Count; ix++)
        //    {
        //        if (parentStock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
        //        {
        //            // 倉庫コード
        //            workData.WarehouseCode = parentStock[ix].WarehouseCode.TrimEnd();
        //            // 倉庫名称
        //            workData.WarehouseName = parentStock[ix].WarehouseName.Trim();
        //            // 倉庫棚番
        //            workData.WarehouseShelfNo = parentStock[ix].WarehouseShelfNo;

        //            //this._stockSectionCode = parentStock[ix].SectionCode;                       //ADD 2009/04/27 不具合対応[13091]    //DEL 2009/05/07 不具合対応[13226]
        //            //this._stockSectionGuideNm = this.LoadSecInfoSet(this._stockSectionCode);    //ADD 2009/04/27 不具合対応[13091]    //DEL 2009/05/07 不具合対応[13226]
        //            break;
        //        }
        //    }

        //    retList.Add(workData);
        //    #endregion

        //    #region 子品番情報作成
        //    SubGoodsSet data;

        //    for (int workCounter = 0; workCounter < this._prtGoodsSetWorkList.Count; workCounter++)
        //    {
        //        data = (SubGoodsSet)this._prtGoodsSetWorkList[workCounter];
        //        workData = new StockAdjustDtlWork();

        //        // 企業コード
        //        workData.EnterpriseCode = this._enterpriseCode;
        //        // 拠点コード
        //        workData.SectionCode = this._loginSectionCode;
        //        // 2009.02.03 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //        // 拠点名称
        //        workData.SectionGuideNm = this._loginSectionGuideNm;
        //        // 2009.02.03 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //        // 在庫調整伝票番号
        //        workData.StockAdjustSlipNo = 0;
        //        // 在庫調整行番号
        //        workData.StockAdjustRowNo = retList.Count + 1;
        //        if (processDiv == 0)
        //        {
        //            // 受払元伝票区分(60：組立)
        //            workData.AcPaySlipCd = 60;
        //        }
        //        else
        //        {
        //            // 受払元伝票区分(61：分解)
        //            workData.AcPaySlipCd = 61;
        //        }
        //        // 受払元取引区分(30：在庫数調整)
        //        workData.AcPayTransCd = 30;
        //        // 調整日付
        //        workData.AdjustDate = totalDay;
        //        // 入力日付
        //        workData.InputDay = totalDay;

        //        // メーカーコード
        //        workData.GoodsMakerCd = data.SubGoodsMakerCd;
        //        // メーカー名称
        //        workData.MakerName = data.SubMakerName;
        //        // 商品コード
        //        workData.GoodsNo = data.SubGoodsNo;
        //        // 商品名称
        //        workData.GoodsName = data.SubGoodsName;
        //        // BLコード
        //        workData.BLGoodsCode = data.BLGoodsCode;
        //        // BLコード名称
        //        workData.BLGoodsFullName = data.BLGoodsFullName;
        //        // 明細備考
        //        // --- CHG 2009/03/10 障害ID:12283対応------------------------------------------------------>>>>>
        //        //workData.DtlNote = "在庫組立分解";
        //        workData.DtlNote = "";
        //        // --- CHG 2009/03/10 障害ID:12283対応------------------------------------------------------<<<<<
                
        //        // 2009.01.26 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //        // 定価（浮動）
        //        workData.ListPriceFl = data.ListPrice;
        //        // 仕入単価（税抜,浮動）
        //        workData.StockUnitPriceFl = data.SalesUnitCost;
        //        // 変更前仕入単価（浮動）
        //        workData.BfStockUnitPriceFl = data.SalesUnitCost;
        //        // オープン価格区分
        //        workData.OpenPriceDiv = data.OpenPriceDiv;
        //        // 2009.01.26 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //        // 調整数
        //        if (processDiv == 0)
        //        {
        //            // 組立
        //            workData.AdjustCount = inputCnt * data.CntFl * -1;
        //        }
        //        else
        //        {
        //            // 分解
        //            workData.AdjustCount = inputCnt * data.CntFl;
        //        }

        //        // 2009.02.03 追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //        // 仕入金額（税抜き）
        //        Int64 wkSubStockPrice = (Int64)(workData.StockUnitPriceFl * workData.AdjustCount * 100);
        //        if ((wkSubStockPrice % 100) >= 50) wkSubStockPrice = (wkSubStockPrice / 100) + 1;
        //        else if ((wkSubStockPrice % 100) <= -50) wkSubStockPrice = (wkSubStockPrice / 100) - 1;
        //        else wkSubStockPrice = wkSubStockPrice / 100;
        //        workData.StockPriceTaxExc = wkSubStockPrice;
        //        // 2009.02.03 追加 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //        // 倉庫チェック
        //        List<Stock> stock = data.SubStockList;
        //        for (int ix = 0; ix < stock.Count; ix++)
        //        {
        //            if (stock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
        //            {
        //                // 倉庫コード
        //                workData.WarehouseCode = stock[ix].WarehouseCode.TrimEnd();
        //                // 倉庫名称
        //                workData.WarehouseName = stock[ix].WarehouseName.Trim();
        //                // 倉庫棚番
        //                workData.WarehouseShelfNo = stock[ix].WarehouseShelfNo;
        //                break;
        //            }
        //        }
        //        retList.Add(workData);
        //    }
        //    #endregion
        //}
        #endregion

        // ---ADD 2009/05/07 不具合対応[13226] --------------------------------->>>>>
        /// <summary>
        /// 在庫調整明細データワーククラス生成処理(親品番情報のみ)
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="processDiv">処理区分</param>
        /// <param name="inputCnt">入力数</param>
        /// <param name="totalDay">処理日付</param>
        /// <param name="retList">在庫調整明細データ</param>
        /// <param name="stockSectionCode">仕入拠点コード</param>
        /// <param name="stockSectionGuideNm">仕入拠点名称</param>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データワーククラス(親品番情報のみ)を生成します。</br>
        /// </remarks>
        private void CreateStockAdjustDtlParentData(string warehouseCode, int processDiv, double inputCnt, DateTime totalDay,
                                                    ref ArrayList retList, out string stockSectionCode, out string stockSectionGuideNm)
        {
            #region 親品番情報作成
            ParentGoods parentData = (ParentGoods)this._prtParentGoodsWorkList[0];
            StockAdjustDtlWork workData = new StockAdjustDtlWork();

            stockSectionCode = string.Empty;
            stockSectionGuideNm = string.Empty;

            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            workData.SectionCode = this._loginSectionCode;
            // 拠点名称
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // 在庫調整伝票番号
            workData.StockAdjustSlipNo = 0;
            // 在庫調整行番号
            workData.StockAdjustRowNo = retList.Count + 1;
            if (processDiv == 0)
            {
                // 受払元伝票区分(60：組立)
                workData.AcPaySlipCd = 60;
            }
            else
            {
                // 受払元伝票区分(61：分解)
                workData.AcPaySlipCd = 61;
            }
            // 受払元取引区分(30：在庫数調整)
            workData.AcPayTransCd = 30;
            // 調整日付
            workData.AdjustDate = totalDay;
            // 入力日付
            workData.InputDay = totalDay;
            // メーカーコード
            workData.GoodsMakerCd = parentData.ParentGoodsMakerCd;
            // メーカー名称
            workData.MakerName = parentData.ParentMakerName;
            // 商品コード
            workData.GoodsNo = parentData.ParentGoodsNo;
            // 商品名称
            workData.GoodsName = parentData.ParentGoodsName;
            // BLコード
            workData.BLGoodsCode = parentData.BLGoodsCode;
            // BLコード名称
            workData.BLGoodsFullName = parentData.BLGoodsFullName;
            // 明細備考
            workData.DtlNote = "";
            // 定価（浮動）
            workData.ListPriceFl = parentData.ListPrice;
            // 仕入単価（税抜,浮動）
            workData.StockUnitPriceFl = parentData.SalesUnitCost;
            // 変更前仕入単価（浮動）
            workData.BfStockUnitPriceFl = parentData.SalesUnitCost;
            // オープン価格区分
            workData.OpenPriceDiv = parentData.OpenPriceDiv;
            // 調整数
            if (processDiv == 0)
            {
                // 組立
                workData.AdjustCount = inputCnt;
            }
            else
            {
                // 分解
                workData.AdjustCount = inputCnt * -1;
            }
            // 仕入金額（税抜き）
            Int64 wkStockPrice = (Int64)(workData.StockUnitPriceFl * workData.AdjustCount * 100);
            if ((wkStockPrice % 100) >= 50) wkStockPrice = (wkStockPrice / 100) + 1;
            else if ((wkStockPrice % 100) <= -50) wkStockPrice = (wkStockPrice / 100) - 1;
            else wkStockPrice = wkStockPrice / 100;
            workData.StockPriceTaxExc = wkStockPrice;

            // 倉庫チェック
            List<Stock> parentStock = parentData.ParentStockList;
            for (int ix = 0; ix < parentStock.Count; ix++)
            {
                if (parentStock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
                {
                    // 倉庫コード
                    workData.WarehouseCode = parentStock[ix].WarehouseCode.TrimEnd();
                    // 倉庫名称
                    workData.WarehouseName = parentStock[ix].WarehouseName.Trim();
                    // 倉庫棚番
                    workData.WarehouseShelfNo = parentStock[ix].WarehouseShelfNo;

                    //仕入拠点情報
                    stockSectionCode = parentStock[ix].SectionCode;
                    stockSectionGuideNm = this.LoadSecInfoSet(stockSectionCode);
                    break;
                }
            }

            retList.Add(workData);
            #endregion
        }

        /// <summary>
        /// 在庫調整明細データワーククラス生成処理(子品番情報のみ)
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="processDiv">処理区分</param>
        /// <param name="inputCnt">入力数</param>
        /// <param name="totalDay">処理日付</param>
        /// <param name="goodsSetIndex">子データのIndex</param>
        /// <param name="retList">在庫調整明細データ</param>
        /// <param name="stockSectionCode">仕入拠点コード</param>
        /// <param name="stockSectionGuideNm">仕入拠点名称</param>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データワーククラス(子品番情報のみ)を生成します。</br>
        /// </remarks>
        private void CreateStockAdjustDtlChildData(string warehouseCode, int processDiv, double inputCnt, DateTime totalDay, int goodsSetIndex,
                                                   ref ArrayList retList, out string stockSectionCode, out string stockSectionGuideNm)
        {
            #region 子品番情報作成
            StockAdjustDtlWork workData = new StockAdjustDtlWork();
            SubGoodsSet data;

            stockSectionCode = string.Empty;
            stockSectionGuideNm = string.Empty;

            data = (SubGoodsSet)this._prtGoodsSetWorkList[goodsSetIndex];
            workData = new StockAdjustDtlWork();

            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            workData.SectionCode = this._loginSectionCode;
            // 拠点名称
            workData.SectionGuideNm = this._loginSectionGuideNm;
            // 在庫調整伝票番号
            workData.StockAdjustSlipNo = 0;
            // 在庫調整行番号
            workData.StockAdjustRowNo = retList.Count + 1;
            if (processDiv == 0)
            {
                // 受払元伝票区分(60：組立)
                workData.AcPaySlipCd = 60;
            }
            else
            {
                // 受払元伝票区分(61：分解)
                workData.AcPaySlipCd = 61;
            }
            // 受払元取引区分(30：在庫数調整)
            workData.AcPayTransCd = 30;
            // 調整日付
            workData.AdjustDate = totalDay;
            // 入力日付
            workData.InputDay = totalDay;
            // メーカーコード
            workData.GoodsMakerCd = data.SubGoodsMakerCd;
            // メーカー名称
            workData.MakerName = data.SubMakerName;
            // 商品コード
            workData.GoodsNo = data.SubGoodsNo;
            // 商品名称
            workData.GoodsName = data.SubGoodsName;
            // BLコード
            workData.BLGoodsCode = data.BLGoodsCode;
            // BLコード名称
            workData.BLGoodsFullName = data.BLGoodsFullName;
            // 明細備考
            workData.DtlNote = "";
            // 定価（浮動）
            workData.ListPriceFl = data.ListPrice;
            // 仕入単価（税抜,浮動）
            workData.StockUnitPriceFl = data.SalesUnitCost;
            // 変更前仕入単価（浮動）
            workData.BfStockUnitPriceFl = data.SalesUnitCost;
            // オープン価格区分
            workData.OpenPriceDiv = data.OpenPriceDiv;
            // 調整数
            if (processDiv == 0)
            {
                // 組立
                workData.AdjustCount = inputCnt * data.CntFl * -1;
            }
            else
            {
                // 分解
                workData.AdjustCount = inputCnt * data.CntFl;
            }
            // 仕入金額（税抜き）
            Int64 wkSubStockPrice = (Int64)(workData.StockUnitPriceFl * workData.AdjustCount * 100);
            if ((wkSubStockPrice % 100) >= 50) wkSubStockPrice = (wkSubStockPrice / 100) + 1;
            else if ((wkSubStockPrice % 100) <= -50) wkSubStockPrice = (wkSubStockPrice / 100) - 1;
            else wkSubStockPrice = wkSubStockPrice / 100;
            workData.StockPriceTaxExc = wkSubStockPrice;
            // 倉庫チェック
            List<Stock> stock = data.SubStockList;
            for (int ix = 0; ix < stock.Count; ix++)
            {
                if (stock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
                {
                    // 倉庫コード
                    workData.WarehouseCode = stock[ix].WarehouseCode.TrimEnd();
                    // 倉庫名称
                    workData.WarehouseName = stock[ix].WarehouseName.Trim();
                    // 倉庫棚番
                    workData.WarehouseShelfNo = stock[ix].WarehouseShelfNo;

                    // 仕入拠点情報
                    stockSectionCode = stock[ix].SectionCode;
                    stockSectionGuideNm = this.LoadSecInfoSet(stockSectionCode);
                    break;
                }
            }
            retList.Add(workData);

            #endregion
        }
        // ---ADD 2009/05/07 不具合対応[13226] ---------------------------------<<<<<
        #endregion

        #region 在庫マスタデータ作成
        #region DEL 2009/05/07 不具合対応[13226]
        ///// <summary>
        ///// 在庫マスタクラス生成処理
        ///// </summary>
        ///// <param name="processDiv">処理区分</param>
        ///// <param name="totalDay">処理日付</param>
        ///// <param name="stockDictionary">在庫マスタワーククラス</param>
        ///// <remarks>
        ///// <br>Note       : 在庫マスタクラスを生成します。</br>
        ///// </remarks>
        //private void CreateStock(string warehouseCode, int processDiv, double inputCnt, DateTime totalDay, ref ArrayList retList)
        //{
        //    #region 親品番情報作成
        //    ParentGoods parentData = (ParentGoods)this._prtParentGoodsWorkList[0];
        //    StockWork workData = new StockWork();

        //    // 倉庫チェック
        //    List<Stock> parentStock = parentData.ParentStockList;
        //    for (int ix = 0; ix < parentStock.Count; ix++)
        //    {
        //        if (parentStock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
        //        {
        //            // 在庫データセット
        //            workData = CopyToStockWorkFromStock(parentStock[ix]);

        //            double wkDouble;
        //            double wkCnt;
        //            wkCnt = inputCnt;
        //            wkDouble = parentStock[ix].StockUnitPriceFl * wkCnt;
        //            Int64 longint;
        //            Int64.TryParse(wkDouble.ToString(), out longint);
        //            if (processDiv != 0)
        //            {
        //                wkCnt = wkCnt * -1;
        //                longint = longint * -1;
        //            }
        //            // 仕入在庫数
        //            workData.SupplierStock = wkCnt;
        //            // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------>>>>>
        //            //// 出荷可能数
        //            //workData.ShipmentPosCnt = workData.SupplierStock;
        //            //// 出庫保有総額
        //            //workData.StockTotalPrice = parentStock[ix].StockTotalPrice + longint;
        //            // 出荷可能数
        //            workData.ShipmentPosCnt = 0;
        //            // 出庫保有総額
        //            workData.StockTotalPrice = 0;
        //            // 入荷数
        //            workData.ArrivalCnt = 0;
        //            // 出荷数
        //            workData.ShipmentCnt = 0;
        //            // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------<<<<<

        //            // 受注数
        //            workData.AcpOdrCount = 0;
        //            // 発注数
        //            workData.SalesOrderCount = 0;
        //            // 移動中仕入在庫数
        //            workData.MovingSupliStock = 0;
        //            break;
        //        }
        //    }

        //    // 企業コード
        //    workData.EnterpriseCode = this._enterpriseCode;
        //    // 論理削除区分
        //    workData.LogicalDeleteCode = 0;
        //    // 拠点コード
        //    //workData.SectionCode = this._loginSectionCode;            //DEL 2009/04/28 不具合対応[13227]
        //    // メーカーコード
        //    workData.GoodsMakerCd = parentData.ParentGoodsMakerCd;
        //    // 品番
        //    workData.GoodsNo = parentData.ParentGoodsNo;
        //    // 更新年月日
        //    workData.UpdateDate = totalDay;

        //    retList.Add(workData);
        //    #endregion

        //    #region 子品番情報作成
        //    SubGoodsSet data;

        //    for (int workCounter = 0; workCounter < this._prtGoodsSetWorkList.Count; workCounter++)
        //    {
        //        data = (SubGoodsSet)this._prtGoodsSetWorkList[workCounter];
        //        workData = new StockWork();

        //        // 倉庫チェック
        //        List<Stock> stock = data.SubStockList;
        //        for (int ix = 0; ix < stock.Count; ix++)
        //        {
        //            if (stock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
        //            {
        //                // 在庫データセット
        //                workData = CopyToStockWorkFromStock(stock[ix]);

        //                double wkDouble;
        //                double wkCnt;
        //                wkCnt = data.CntFl * inputCnt;
        //                wkDouble = stock[ix].StockUnitPriceFl * wkCnt;
        //                Int64 longint;
        //                Int64.TryParse(wkDouble.ToString(), out longint);
        //                if (processDiv == 0)
        //                {
        //                    wkCnt = wkCnt * -1;
        //                    longint = longint * -1;
        //                }
        //                // 仕入在庫数
        //                workData.SupplierStock = wkCnt;
        //                // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------>>>>>
        //                //// 出荷可能数
        //                //workData.ShipmentPosCnt = workData.SupplierStock;
        //                //// 出庫保有総額
        //                //workData.StockTotalPrice = stock[ix].StockTotalPrice + longint;
        //                // 出荷可能数
        //                workData.ShipmentPosCnt = 0;
        //                // 出庫保有総額
        //                workData.StockTotalPrice = 0;
        //                // 入荷数
        //                workData.ArrivalCnt = 0;
        //                // 出荷数
        //                workData.ShipmentCnt = 0;
        //                // --- CHG 2009/02/26 障害ID:11945対応------------------------------------------------------<<<<<

        //                // 受注数
        //                workData.AcpOdrCount = 0;
        //                // 発注数
        //                workData.SalesOrderCount = 0;
        //                // 移動中仕入在庫数
        //                workData.MovingSupliStock = 0;
        //                break;
        //            }
        //        }

        //        // 企業コード
        //        workData.EnterpriseCode = this._enterpriseCode;
        //        // 論理削除区分
        //        workData.LogicalDeleteCode = 0;
        //        // 拠点コード
        //        //workData.SectionCode = this._loginSectionCode;        //DEL 2009/04/28 不具合対応[13227]
        //        // メーカーコード
        //        workData.GoodsMakerCd = data.SubGoodsMakerCd;
        //        // 品番
        //        workData.GoodsNo = data.SubGoodsNo;
        //        // 更新年月日
        //        workData.UpdateDate = totalDay;

        //        retList.Add(workData);
        //    }
        //    #endregion
        //}
        #endregion

        // ---ADD 2009/05/07 不具合対応[13226] --------------------------------->>>>>
        /// <summary>
        /// 在庫マスタクラス生成処理(親品番情報のみ)
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="processDiv">処理区分</param>
        /// <param name="inputCnt">入力数</param>
        /// <param name="totalDay">処理日付</param>
        /// <param name="retList">在庫マスタデータ</param>
        /// <remarks>
        /// <br>Note       : 在庫マスタクラス(親品番情報のみ)を生成します。</br>
        /// </remarks>
        private void CreateStockParentData(string warehouseCode, int processDiv, double inputCnt, DateTime totalDay, ref ArrayList retList)
        {
            #region 親品番情報作成
            ParentGoods parentData = (ParentGoods)this._prtParentGoodsWorkList[0];
            StockWork workData = new StockWork();

            // 倉庫チェック
            List<Stock> parentStock = parentData.ParentStockList;
            for (int ix = 0; ix < parentStock.Count; ix++)
            {
                if (parentStock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
                {
                    // 在庫データセット
                    workData = CopyToStockWorkFromStock(parentStock[ix]);

                    double wkDouble;
                    double wkCnt;
                    wkCnt = inputCnt;
                    wkDouble = parentStock[ix].StockUnitPriceFl * wkCnt;
                    Int64 longint;
                    Int64.TryParse(wkDouble.ToString(), out longint);
                    if (processDiv != 0)
                    {
                        wkCnt = wkCnt * -1;
                        longint = longint * -1;
                    }
                    // 仕入在庫数
                    workData.SupplierStock = wkCnt;
                    // 出荷可能数
                    workData.ShipmentPosCnt = 0;
                    // 出庫保有総額
                    workData.StockTotalPrice = 0;
                    // 入荷数
                    workData.ArrivalCnt = 0;
                    // 出荷数
                    workData.ShipmentCnt = 0;
                    // 受注数
                    workData.AcpOdrCount = 0;
                    // 発注数
                    workData.SalesOrderCount = 0;
                    // 移動中仕入在庫数
                    workData.MovingSupliStock = 0;
                    break;
                }
            }

            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 論理削除区分
            workData.LogicalDeleteCode = 0;
            // メーカーコード
            workData.GoodsMakerCd = parentData.ParentGoodsMakerCd;
            // 品番
            workData.GoodsNo = parentData.ParentGoodsNo;
            // 更新年月日
            workData.UpdateDate = totalDay;

            retList.Add(workData);
            #endregion
        }

        /// <summary>
        /// 在庫マスタクラス生成処理(子品番情報のみ)
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="processDiv">処理区分</param>
        /// <param name="inputCnt">入力数</param>
        /// <param name="totalDay">処理日付</param>
        /// <param name="goodsSetIndex">子データのIndex</param>
        /// <param name="retList">在庫マスタデータ</param>
        /// <remarks>
        /// <br>Note       : 在庫マスタクラス(子品番情報のみ)を生成します。</br>
        /// </remarks>
        private void CreateStockChildData(string warehouseCode, int processDiv, double inputCnt, DateTime totalDay, int goodsSetIndex, ref ArrayList retList)
        {
            #region 子品番情報作成
            StockWork workData = new StockWork();

            SubGoodsSet data;

            data = (SubGoodsSet)this._prtGoodsSetWorkList[goodsSetIndex];
            workData = new StockWork();

            // 倉庫チェック
            List<Stock> stock = data.SubStockList;
            for (int ix = 0; ix < stock.Count; ix++)
            {
                if (stock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
                {
                    // 在庫データセット
                    workData = CopyToStockWorkFromStock(stock[ix]);

                    double wkDouble;
                    double wkCnt;
                    wkCnt = data.CntFl * inputCnt;
                    wkDouble = stock[ix].StockUnitPriceFl * wkCnt;
                    Int64 longint;
                    Int64.TryParse(wkDouble.ToString(), out longint);
                    if (processDiv == 0)
                    {
                        wkCnt = wkCnt * -1;
                        longint = longint * -1;
                    }
                    // 仕入在庫数
                    workData.SupplierStock = wkCnt;
                    // 出荷可能数
                    workData.ShipmentPosCnt = 0;
                    // 出庫保有総額
                    workData.StockTotalPrice = 0;
                    // 入荷数
                    workData.ArrivalCnt = 0;
                    // 出荷数
                    workData.ShipmentCnt = 0;
                    // 受注数
                    workData.AcpOdrCount = 0;
                    // 発注数
                    workData.SalesOrderCount = 0;
                    // 移動中仕入在庫数
                    workData.MovingSupliStock = 0;
                    break;
                }
            }

            // 企業コード
            workData.EnterpriseCode = this._enterpriseCode;
            // 論理削除区分
            workData.LogicalDeleteCode = 0;
            // メーカーコード
            workData.GoodsMakerCd = data.SubGoodsMakerCd;
            // 品番
            workData.GoodsNo = data.SubGoodsNo;
            // 更新年月日
            workData.UpdateDate = totalDay;

            retList.Add(workData);

            #endregion
        }
        // ---ADD 2009/05/07 不具合対応[13226] ---------------------------------<<<<<
        #endregion

        #endregion

        #region 子商品情報DataSet取得
        /// <summary>
        /// 子商品情報ワークを返します
		/// </summary>
        /// <param name="dataSet">在庫組立分解ワーク（DataSet）</param>
		/// <returns>0: 成功</returns>
		public int Read(out DataSet dataSet)
		{
			if (this._prtGoodsSetDataSet == null)
				this._prtGoodsSetDataSet = new DataSet(ctPrtStckAssemOvhul_Table);

			dataSet = this._prtGoodsSetDataSet;

			return 0;
		}
		# endregion

        #region 子商品情報DataSet取得
        /// <summary>
        /// 子商品情報ワークを返します
        /// </summary>
        /// <param name="dataSet">在庫組立分解ワーク（DataSet）</param>
        /// <returns>0: 成功</returns>
        public int Read(string goodsNo, out DataSet dataSet)
        {
            if (this._prtGoodsSetDataSet == null)
                this._prtGoodsSetDataSet = new DataSet(ctPrtStckAssemOvhul_Table);

            //在庫組立分解データセット格納
            this.PrtStckAssemOvhulDataSetting();

            dataSet = this._prtGoodsSetDataSet;

            return 0;
        }
        # endregion

        #region 子商品情報DataSet取得（倉庫切替）
        /// <summary>
        /// 子商品情報ワークを返します
        /// </summary>
        /// <param name="dataSet">在庫組立分解ワーク（DataSet）</param>
        /// <returns>0: 成功</returns>
        public int ReadNext(string warehouseCode, out DataSet dataSet)
        {
            if (this._prtGoodsSetDataSet == null)
                this._prtGoodsSetDataSet = new DataSet(ctPrtStckAssemOvhul_Table);

            //子商品データセット格納
            this.PrtStckAssemOvhulDataSetting(warehouseCode);

            dataSet = this._prtGoodsSetDataSet;

            return 0;
        }
        # endregion

        #region 親商品情報取得
        /// <summary>
        /// 親商品情報ワークを返します
        /// </summary>
        /// <param name="dataSet">親商品情報ワーク（DataSet）</param>
        /// <returns>0: 成功</returns>
        public int Read(out ParentGoods parentGoods)
        {
            if (this._prtParentGoodsWorkList.Count > 0)
            {
                parentGoods = (ParentGoods)this._prtParentGoodsWorkList[0];
            }
            else
            {
                parentGoods = new ParentGoods();
            }

            return 0;
        }

        /// <summary>
        /// 親商品情報ワークを返します（次在庫情報）
        /// </summary>
        /// <param name="dataSet">親商品情報ワーク（DataSet）</param>
        /// <returns>0: 成功　-1:失敗</returns>
        public int ReadNext(string warehouseCode, out ParentGoods parentGoods)
        {
            if (this._prtParentGoodsWorkList.Count > 0)
            {
                parentGoods = (ParentGoods)this._prtParentGoodsWorkList[0];
                List<Stock> stock = parentGoods.ParentStockList;

                // 親在庫が１件以下の時には処理を終了する
                if (stock.Count <= 1) return -1;

                // 次在庫情報取得
                for (int ix = 0; ix < stock.Count; ix++)
                {
                    if (stock[ix].WarehouseCode.Trim() == warehouseCode.Trim())
                    {
                        int iCnt = 0;
                        if (ix < stock.Count - 1) iCnt = ix + 1;

                        parentGoods.ParentWarehouseCode = stock[iCnt].WarehouseCode.Trim();
                        parentGoods.ParentWarehouseName = stock[iCnt].WarehouseName;
                        parentGoods.ParentSupplierStock = stock[iCnt].SupplierStock;
                        parentGoods.ShipmentPosCnt = stock[iCnt].ShipmentPosCnt;
                        parentGoods.ParentMaximumStockCnt = stock[iCnt].MaximumStockCnt;
                        parentGoods.ParentMinimumStockCnt = stock[iCnt].MinimumStockCnt;
                    }
                }
            }
            else
            {
                parentGoods = new ParentGoods();
            }

            return 0;
        }
        # endregion

        #region クラスメンバーコピー処理
        /// <summary>
        /// クラスメンバーコピー処理（在庫組立・分解処理ワーククラス⇒在庫組立・分解親商品クラス）
        /// </summary>
        /// <param name="joinPartsUWork"></param>
        /// <returns></returns>
        private ParentGoods CopyToParentGoodsFromGoodsUnitData(GoodsUnitData wkData)
        {
            ParentGoods wkRet = new ParentGoods();

            wkRet.ParentGoodsNo = wkData.GoodsNo;
            wkRet.ParentGoodsName = wkData.GoodsName;
            wkRet.ParentGoodsNameKana = wkData.GoodsNameKana;
            wkRet.ParentGoodsMakerCd = wkData.GoodsMakerCd;
            wkRet.ParentMakerName = wkData.MakerName;
            wkRet.ParentMakerShortName = wkData.MakerShortName;
            wkRet.BLGoodsCode = wkData.BLGoodsCode;
            wkRet.BLGoodsFullName = wkData.BLGoodsFullName;
           
            wkRet.ParentStockList = wkData.StockList;

            // 2009.01.26 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (wkRet.ParentStockList.Count > 0)
            //{
            //    wkRet.ParentWarehouseCode = wkRet.ParentStockList[0].WarehouseCode.Trim();
            //    wkRet.ParentWarehouseName = wkRet.ParentStockList[0].WarehouseName;
            //    wkRet.ParentSupplierStock = wkRet.ParentStockList[0].SupplierStock;
            //    wkRet.ShipmentPosCnt      = wkRet.ParentStockList[0].ShipmentPosCnt;
            //    wkRet.ParentMaximumStockCnt = wkRet.ParentStockList[0].MaximumStockCnt;
            //    wkRet.ParentMinimumStockCnt = wkRet.ParentStockList[0].MinimumStockCnt;
            //}

            // 在庫情報取得
            // DEL 2009/04/22 ------>>>
            //wkRet.ParentWarehouseCode = wkData.SelectedWarehouseCode;
            //for (int ix = 0; ix < wkRet.ParentStockList.Count; ix++)
            //{
            //    if (wkRet.ParentStockList[ix].WarehouseCode.Trim() == wkRet.ParentWarehouseCode.Trim())
            //    {
            //        wkRet.ParentWarehouseName   = wkRet.ParentStockList[ix].WarehouseName;
            //        wkRet.ParentSupplierStock   = wkRet.ParentStockList[ix].SupplierStock;
            //        wkRet.ShipmentPosCnt        = wkRet.ParentStockList[ix].ShipmentPosCnt;
            //        wkRet.ParentMaximumStockCnt = wkRet.ParentStockList[ix].MaximumStockCnt;
            //        wkRet.ParentMinimumStockCnt = wkRet.ParentStockList[ix].MinimumStockCnt;
            //        break;
            //    }
            //}
            // DEL 2009/04/22 ------<<<
            
            // ADD 2009/04/22 ------>>>
            if (wkData.SelectedWarehouseCode != null)
            {
                // 管理拠点に有る場合
                wkRet.ParentWarehouseCode = wkData.SelectedWarehouseCode;
                for (int ix = 0; ix < wkRet.ParentStockList.Count; ix++)
                {
                    if (wkRet.ParentStockList[ix].WarehouseCode.Trim() == wkRet.ParentWarehouseCode.Trim())
                    {
                        wkRet.ParentWarehouseName = wkRet.ParentStockList[ix].WarehouseName;
                        wkRet.ParentSupplierStock = wkRet.ParentStockList[ix].SupplierStock;
                        wkRet.ShipmentPosCnt = wkRet.ParentStockList[ix].ShipmentPosCnt;
                        wkRet.ParentMaximumStockCnt = wkRet.ParentStockList[ix].MaximumStockCnt;
                        wkRet.ParentMinimumStockCnt = wkRet.ParentStockList[ix].MinimumStockCnt;
                        break;
                    }
                }
            }
            else
            {
                // 管理拠点に無い場合
                wkRet.ParentWarehouseCode = wkRet.ParentStockList[0].WarehouseCode;
                wkRet.ParentWarehouseName = wkRet.ParentStockList[0].WarehouseName;
                wkRet.ParentSupplierStock = wkRet.ParentStockList[0].SupplierStock;
                wkRet.ShipmentPosCnt = wkRet.ParentStockList[0].ShipmentPosCnt;
                wkRet.ParentMaximumStockCnt = wkRet.ParentStockList[0].MaximumStockCnt;
                wkRet.ParentMinimumStockCnt = wkRet.ParentStockList[0].MinimumStockCnt;
            }
            // ADD 2009/04/22 ------<<<
            
            // 価格情報取得
            DateTime wkDate = DateTime.Today;
            for (int ix = 0; ix < wkData.GoodsPriceList.Count; ix++)
            {
                if (wkData.GoodsPriceList[ix].PriceStartDate <= wkDate)
                {
                    wkRet.ListPrice     = wkData.GoodsPriceList[ix].ListPrice;
                    wkRet.SalesUnitCost = wkData.GoodsPriceList[ix].SalesUnitCost;
                    wkRet.OpenPriceDiv  = wkData.GoodsPriceList[ix].OpenPriceDiv;

                    if ((wkRet.ListPrice != 0) && (wkRet.SalesUnitCost == 0) && (wkData.GoodsPriceList[ix].StockRate != 0))
                    {
                        Int64 wkPrice;
                        Int64 wkRate;

                        // doubleのまま処理すると誤差が出る場合があるためintで計算する
                        Int64.TryParse((wkRet.ListPrice).ToString(), out wkPrice);
                        Int64.TryParse((wkData.GoodsPriceList[ix].StockRate * 100).ToString(), out wkRate);
                        wkPrice = (wkPrice * wkRate) / 100;
                        wkRet.SalesUnitCost = (double)wkPrice / 100;
                    }
                    break;
                }
            }
            // 2009.01.26 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return wkRet;
        }

        /// <summary>
        /// クラスメンバーコピー処理（在庫組立・分解処理ワーククラス⇒在庫組立・分解子商品クラス）
        /// </summary>
        /// <param name="joinPartsUWork"></param>
        /// <returns></returns>
        private SubGoodsSet CopyToSubGoodsSetFromGoodsUnitData(GoodsUnitData wkData)
        {
            SubGoodsSet wkRet = new SubGoodsSet();

            wkRet.DisplayOrder = wkData.SetDispOrder;
            wkRet.SubGoodsNo = wkData.GoodsNo;
            wkRet.SubGoodsName = wkData.GoodsName;
            wkRet.SubGoodsNameKana = wkData.GoodsNameKana;
            wkRet.SubGoodsMakerCd = wkData.GoodsMakerCd;
            wkRet.SubMakerName = wkData.MakerName;
            wkRet.BLGoodsCode = wkData.BLGoodsCode;
            wkRet.BLGoodsFullName = wkData.BLGoodsFullName;
            wkRet.CntFl = wkData.SetQty;

            switch (wkData.OfferKubun)
            {
                case 0:     // ユーザー登録
                case 1:     // 提供純正編集
                case 2:     // 提供優良編集
                    {
                        // ユーザー
                        wkRet.Division = DIVISION_NAME_USER;
                        break;
                    }
                case 3:     // 3:提供純正
                case 4:     // 4:提供優良
                case 5:     // 5:TBO
                case 7:     // 7:オリジナル
                    {
                        // 提供
                        wkRet.Division = DIVISION_NAME_OFFER;
                        break;
                    }
            }

            wkRet.SubStockList = wkData.StockList;

            // 拠点倉庫チェック
            for (int ix = 0; ix < wkRet.SubStockList.Count; ix++)
            {
                if (wkRet.SubStockList[ix].WarehouseCode.Trim() == this._targetWarehouseCd.Trim())
                {
                    wkRet.SubSupplierStock = wkRet.SubStockList[ix].SupplierStock;
                    wkRet.SubWarehouseCd = wkRet.SubStockList[ix].WarehouseCode;
                    wkRet.ShipmentPosCnt = wkRet.SubStockList[ix].ShipmentPosCnt;
                    break;
                }
            }

            // 2009.01.26 修正 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 価格情報取得
            DateTime wkDate = DateTime.Today;
            for (int ix = 0; ix < wkData.GoodsPriceList.Count; ix++)
            {
                if (wkData.GoodsPriceList[ix].PriceStartDate <= wkDate)
                {
                    wkRet.ListPrice     = wkData.GoodsPriceList[ix].ListPrice;
                    wkRet.SalesUnitCost = wkData.GoodsPriceList[ix].SalesUnitCost;
                    wkRet.OpenPriceDiv  = wkData.GoodsPriceList[ix].OpenPriceDiv;

                    if ((wkRet.ListPrice != 0) && (wkRet.SalesUnitCost == 0) && (wkData.GoodsPriceList[ix].StockRate != 0))
                    {
                        Int64 wkPrice;
                        Int64 wkRate;

                        // doubleのまま処理すると誤差が出る場合があるためintで計算する
                        Int64.TryParse((wkRet.ListPrice).ToString(), out wkPrice);
                        Int64.TryParse((wkData.GoodsPriceList[ix].StockRate * 100).ToString(), out wkRate);
                        wkPrice = (wkPrice * wkRate) / 100;
                        wkRet.SalesUnitCost = (double)wkPrice / 100;
                    }
                    break;
                }
            }
            // 2009.01.26 修正 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return wkRet;
        }

        /// <summary>
        /// セット商品比較クラス(表示順位順にソート）
        /// </summary>
        /// <remarks></remarks>
        private class StckGoodsSetComparer : Comparer<SubGoodsSet>
        {
            public override int Compare(SubGoodsSet x, SubGoodsSet y)
            {
                int result = x.DisplayOrder.CompareTo(y.DisplayOrder);

                return result;
            }
        }

        /// <summary>
        /// クラスメンバーコピー処理（在庫マスタワーク⇒在庫更新クラス）
        /// </summary>
        /// <param name="wkData"></param>
        /// <returns></returns>
        private StockWork CopyToStockWorkFromStock(Stock wkData)
        {
            StockWork wkRet = new StockWork();

            wkRet.CreateDateTime = wkData.CreateDateTime;
            wkRet.UpdateDateTime = wkData.UpdateDateTime;
            wkRet.EnterpriseCode = wkData.EnterpriseCode;
            wkRet.FileHeaderGuid = wkData.FileHeaderGuid;
            wkRet.UpdEmployeeCode = wkData.UpdEmployeeCode;
            wkRet.UpdAssemblyId1 = wkData.UpdAssemblyId1;
            wkRet.UpdAssemblyId2 = wkData.UpdAssemblyId2;
            wkRet.LogicalDeleteCode = wkData.LogicalDeleteCode;
            wkRet.SectionCode = wkData.SectionCode;
            wkRet.WarehouseCode = wkData.WarehouseCode;
            wkRet.GoodsMakerCd = wkData.GoodsMakerCd;
            wkRet.GoodsNo = wkData.GoodsNo;
            wkRet.StockUnitPriceFl = wkData.StockUnitPriceFl;
            wkRet.SupplierStock = wkData.SupplierStock;
            wkRet.AcpOdrCount = wkData.AcpOdrCount;
            wkRet.MonthOrderCount = wkData.MonthOrderCount;
            wkRet.SalesOrderCount = wkData.SalesOrderCount;
            wkRet.StockDiv = wkData.StockDiv;
            wkRet.MovingSupliStock = wkData.MovingSupliStock;
            wkRet.ShipmentPosCnt = wkData.ShipmentPosCnt;
            wkRet.StockTotalPrice = wkData.StockTotalPrice;
            wkRet.LastStockDate = wkData.LastStockDate;
            wkRet.LastSalesDate = wkData.LastSalesDate;
            wkRet.LastInventoryUpdate = wkData.LastInventoryUpdate;
            wkRet.MinimumStockCnt = wkData.MinimumStockCnt;
            wkRet.MaximumStockCnt = wkData.MaximumStockCnt;
            wkRet.NmlSalOdrCount = wkData.NmlSalOdrCount;
            wkRet.SalesOrderUnit = wkData.SalesOrderUnit;
            wkRet.StockSupplierCode = wkData.StockSupplierCode;
            wkRet.GoodsNoNoneHyphen = wkData.GoodsNoNoneHyphen;
            wkRet.WarehouseShelfNo = wkData.WarehouseShelfNo;
            wkRet.DuplicationShelfNo1 = wkData.DuplicationShelfNo1;
            wkRet.DuplicationShelfNo2 = wkData.DuplicationShelfNo2;
            wkRet.PartsManagementDivide1 = wkData.PartsManagementDivide1;
            wkRet.PartsManagementDivide2 = wkData.PartsManagementDivide2;
            wkRet.StockNote1 = wkData.StockNote1;
            wkRet.StockNote2 = wkData.StockNote2;
            wkRet.ShipmentCnt = wkData.ShipmentCnt;
            wkRet.ArrivalCnt = wkData.ArrivalCnt;
            wkRet.StockCreateDate = wkData.StockCreateDate;
            wkRet.UpdateDate = wkData.UpdateDate;

            return wkRet;
        }
        #endregion

        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// <summary>
        /// 対象価格から、税抜金額、税込金額、表示金額を計算します
        /// </summary>
        /// <param name="priceInputType">価格入力モード</param>
        /// <param name="targetPrice">対象価格</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="taxRate">税率</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="priceTaxExc">税抜金額</param>
        /// <param name="priceTaxInc">税込金額</param>
        /// <param name="priceDisplay">表示金額</param>
        public void CalclatePrice(double targetPrice, int taxationCode, int totalAmountDispWayCd, int consTaxLayMethod, double taxRate, out  double priceTaxExc, out  double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (targetPrice == 0) return;

            // 小数点第３位四捨五入
            int taxFracProcCd = 2;
            double taxFracProcUnit = 0.01;
            //this._salesSlipInputInitDataAcs.GetFractionProcInfo((int)SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // 総額表示しない
            if (totalAmountDispWayCd == 0)
            {
                // 課税区分「非課税」、転嫁方式：非課税
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税（内税）」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                }
            }
            // 総額表示する
            else
            {
                // 課税区分「非課税」、転嫁方式：非課税
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税（内税）」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
            }
        }

        /// <summary>
        /// 消費税転嫁方式
        /// </summary>
        public enum ConsTaxLayMethod : int
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
        /// 総額表示方法区分
        /// </summary>
        public enum TotalAmountDispWayCd : int
        {
            /// <summary>総額表示しない</summary>
            NoTotalAmount = 0,
            /// <summary>総額表示する</summary>
            TotalAmount = 1,
        }

        /// <summary>
        /// 税率設定処理
        /// </summary>
        public void SettingTaxRate()
        {
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            ArrayList al;

            int status = taxRateSetAcs.Search(out al, this._enterpriseCode, TaxRateSetAcs.SearchMode.Remote); // 常にサーバー参照

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    this._taxRate = this.GetTaxRate((TaxRateSet)al[0], DateTime.Today);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    break;
            }
        }
        // --- ADD 2009/02/12 --------------------------------<<<<<

        #endregion
    }
}
