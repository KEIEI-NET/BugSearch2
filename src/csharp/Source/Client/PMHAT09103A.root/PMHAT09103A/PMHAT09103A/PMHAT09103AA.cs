//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定処理
// プログラム概要   : 発注点設定処理アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11100937-00 作成担当 : 許雁波  
// 修 正 日  2015/06/03  修正内容 : Redmine#45978 イスコジャパン 同一倉庫内で同一品番が複数印字される修正
//----------------------------------------------------------------------------//
// 管理番号  11100937-00 作成担当 : 金慶園
// 修 正 日  2015/07/13  修正内容 : Redmine#45978 東海自動車課題対応案件No.3:商品マスタの商品属性が、0：純正の商品しか対象とならず、
//                                                1:その他を設定している優良品番が抽出対象外となってしまう。
//----------------------------------------------------------------------------//
// 管理番号  11100937-00 作成担当 : 許雁波
// 修 正 日  2015/08/13  修正内容 : Redmine#45978の#93と#94 仕入先取得、原単価算出の障害対応。
//----------------------------------------------------------------------------//
// 管理番号  11100937-00 作成担当 : 許雁波
// 修 正 日  2015/08/26  修正内容 : Redmine#45978  自社設定の掛率優先順位区分を参照していない障害対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注点設定処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定処理で使用するデータを取得する。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// </remarks>
    public class OrderPointStSimulationAcs
    {
        #region ■ Constructor
		/// <summary>
        /// 発注点設定処理アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 発注点設定処理アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 劉学智</br>
	    /// <br>Date       : 2009.04.13</br>
        /// <br>UpdateNote : Redmine#45978 自社設定の掛率優先順位区分を参照していない障害対応</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2015/08/26</br>
		/// </remarks>
		public OrderPointStSimulationAcs()
		{
            this._iOrderPointStSimulationDB = (IOrderPointStSimulationDB)MediationOrderPointStSimulationDB.GetOrderPointStSimulationDB();
            this._goodsAcs = new GoodsAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._taxRateSet = new TaxRateSet();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this._stockMngTtlSt = new StockMngTtlSt();
            // ---- ADD 許雁波 2015/08/26 FOR Redmine45978 自社設定の掛率優先順位区分を参照していない障害対応 ---->>>>
            this._companyInfAcs = new CompanyInfAcs(); 
            SetUnitPriceCalculation();  // 自社設定掛率優先順位区分(原単価算出用)　
            // ---- ADD 許雁波 2015/08/26 FOR Redmine45978 自社設定の掛率優先順位区分を参照していない障害対応 ----<<<<

        }

		/// <summary>
        /// 発注点設定処理表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 発注点設定処理表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        static OrderPointStSimulationAcs()
		{
			stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス
			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        #endregion ■ Static Member

        #region ■ Private Member
        IOrderPointStSimulationDB _iOrderPointStSimulationDB;           // 発注点設定処理リモート
        private DataSet _dataSet;  // 印刷DataSet
        private TaxRateSetAcs _taxRateSetAcs;           // 税率設定マスタアクセスクラス
        private TaxRateSet _taxRateSet;
        // 商品連結データローカルキャッシュ
        private Dictionary<string, GoodsUnitData> _goodsUnitDataDic;
        // 商品アクセス
        private GoodsAcs _goodsAcs;
        // 商品アクセスクラスの抽出条件
        private List<GoodsCndtn> _goodsCndtnList;
        private UnitPriceCalculation _unitPriceCalculation;
        // 在庫管理全体設定マスタアクセス
        private StockMngTtlStAcs _stockMngTtlStAcs;
        // 自社設定マスタアクセス
        CompanyInfAcs _companyInfAcs; // ADD 許雁波 2015/08/26 FOR Redmine45978 自社設定の掛率優先順位区分を参照していない障害対応
        private StockMngTtlSt _stockMngTtlSt;
        #endregion ■ Private Member

        #region ■ Const Member
        private const string ct_septation = "^";
        #endregion ■ Const Member

        #region [public プロパティ]
        /// <summary>
        /// データセット(読み取り専用)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }
        #endregion

        #region ■ Public Method
        #region ◎ データ取得
        /// <summary>
        /// 発注点設定処理データ取得
        /// </summary>
        /// <param name="cndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する発注点設定処理データを取得する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public int Search(ExtrInfo_OrderPointStSimulationWorkTbl cndtn, out string errMsg)
        {
            return this.SearchProc(cndtn, out errMsg);
        }
        #endregion
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◎ 発注点設定処理データ取得
        /// <summary>
        /// 発注点設定処理データ取得
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する発注点設定処理データを取得する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int SearchProc(ExtrInfo_OrderPointStSimulationWorkTbl cndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            try
            {
                // DataTable Create ----------------------------------------------------------
                OrderPointStSimulationTbl.CreateDataTableOrderPointStSimulationTbl(ref this._dataSet);

                ExtrInfo_OrderPointStSimulationWork paramWork = new ExtrInfo_OrderPointStSimulationWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevOrderPointStSimulationWorkTbl(cndtn, out paramWork, out errMsg);
                // データ取得  ----------------------------------------------------------------
                object retList = null;
                object retStockList = null;
                status = this._iOrderPointStSimulationDB.Search(out retList, out retStockList, paramWork);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        status = DevOrderPointStSimulationWorkListData(cndtn, this._dataSet.Tables[OrderPointStSimulationTbl.Col_Tbl_Result_OrderPointStSimulation], (ArrayList)retList, (ArrayList)retStockList);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "発注点設定処理データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region ◆ データ展開処理
        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="workTbl">UI抽出条件クラス</param>
        /// <param name="work">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevOrderPointStSimulationWorkTbl(ExtrInfo_OrderPointStSimulationWorkTbl workTbl, out ExtrInfo_OrderPointStSimulationWork work, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            work = new ExtrInfo_OrderPointStSimulationWork();

            try
            {
                work.EnterpriseCode = workTbl.EnterpriseCode;               // 企業コード
                work.SettingCode = workTbl.SettingCode;                     // 設定コード
                work.St_WarehouseCode = workTbl.St_WarehouseCode;           // 開始倉庫コード
                work.Ed_WarehouseCode = workTbl.Ed_WarehouseCode;           // 終了倉庫コード
                work.St_SupplierCd = workTbl.St_SupplierCd;	                // 開始仕入先コード
                work.Ed_SupplierCd = workTbl.Ed_SupplierCd;                 // 終了仕入先コード
                work.St_GoodsMakerCd = workTbl.St_GoodsMakerCd;	            // 開始メーカーコード
                work.Ed_GoodsMakerCd = workTbl.Ed_GoodsMakerCd;	            // 終了メーカーコード
                work.St_GoodsMGroup = workTbl.St_GoodsMGroup;	            // 開始商品中分類
                work.Ed_GoodsMGroup = workTbl.Ed_GoodsMGroup;	            // 終了商品中分類
                work.St_BLGroupCode = workTbl.St_BLGroupCode;	            // 開始グループコード
                work.Ed_BLGroupCode = workTbl.Ed_BLGroupCode;	            // 終了グループコード
                work.St_BLGoodsCode = workTbl.St_BLGoodsCode;	            // 開始BLコード
                work.Ed_BLGoodsCode = workTbl.Ed_BLGoodsCode;	            // 終了BLコード
                work.SumMethod = workTbl.SumMethodCd;	                    // 集計方法
                work.OutPutDiv = workTbl.OutPutDiv;	                        // 出力順
                work.StckShipMonthSt = workTbl.StckShipMonthSt;             // 在庫出荷対象開始月
                work.StckShipMonthEd = workTbl.StckShipMonthEd;             // 在庫出荷対象終了月
                work.ManagementDivide1 = workTbl.ManagementDivide1;         // 管理区分１
                work.ManagementDivide2 = workTbl.ManagementDivide2;         // 管理区分２
                // ADD 2009/07/14
                work.OrderApplyDiv = workTbl.OrderApplyDiv;                 // 発注適用区分 
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
                #endregion

        #region ◎ 発注点設定処理データ展開処理
        /// <summary>
        /// 発注点設定処理データ展開処理
        /// </summary>
        /// <param name="paramWork">抽出条件クラス</param>
        /// <param name="orderPointStDt">展開対象DataTable</param>
        /// <param name="orderPointStWorkList">取得データ</param>
        /// <param name="stockList">在庫データリスト</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定処理データを展開する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int DevOrderPointStSimulationWorkListData(ExtrInfo_OrderPointStSimulationWorkTbl paramWork, DataTable orderPointStDt, ArrayList orderPointStWorkList, ArrayList stockList)
        {
            _goodsCndtnList = new List<GoodsCndtn>();
            foreach (OrderPointStSimulationWork orderPointStSimulationWork in orderPointStWorkList)
            {
                // 商品アクセスクラスの抽出条件を設定
                GoodsCndtn workGoodsCndtn = new GoodsCndtn();
                workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                workGoodsCndtn.SectionCode = orderPointStSimulationWork.SectionCode;
                workGoodsCndtn.MakerName = orderPointStSimulationWork.GoodsMakerNm;
                workGoodsCndtn.GoodsNoSrchTyp = 0;
                workGoodsCndtn.GoodsMakerCd = orderPointStSimulationWork.GoodsMakerCd;
                workGoodsCndtn.GoodsNo = orderPointStSimulationWork.GoodsNo;
                workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                // ------------------ ADD BY 金慶園 2015/07/13 FOR 東海自動車課題対応案件No.3------------------------>>>>>
                // 商品属性:0 純正 1:その他 の商品取得
                workGoodsCndtn.GoodsKindCode = 9;
                // ------------------ ADD BY 金慶園 2015/07/13 FOR 東海自動車課題対応案件No.3------------------------<<<<<
                this._goodsCndtnList.Add(workGoodsCndtn);
            }
            this.GoodsRead(this._goodsCndtnList);

            // 税率を取得する
            this.ReadTaxRate();

            // 在庫管理全体設定マスタを取得する
            this.ReadStockMngTtlSt();

            // 端数区分の設定
            paramWork.FractionProcCd = this._stockMngTtlSt.FractionProcCd;

            for (int i = 0; i < orderPointStWorkList.Count; i++)
            {
                OrderPointStSimulationWork orderPointStSimulationWork = (OrderPointStSimulationWork)orderPointStWorkList[i];
                StockWork stockWork = (StockWork)stockList[i];

                DataSetOrderPointStSimulation(paramWork, orderPointStDt, orderPointStSimulationWork, stockWork);
            }

            if (orderPointStDt.Rows.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion

        /// <summary>
        /// 取得データ設定処理
        /// </summary>
        /// <param name="paramWork">抽出条件クラス</param>
        /// <param name="orderPointStDt">展開対象DataTable</param>
        /// <param name="work">取得データ</param>
        /// <param name="stockWork">在庫データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを設定する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br>Note       : Redmine#45978の#93と#94 仕入先取得、原単価算出の障害対応。</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2015/08/13</br>
        /// </remarks>
        private void DataSetOrderPointStSimulation(ExtrInfo_OrderPointStSimulationWorkTbl paramWork, DataTable orderPointStDt, OrderPointStSimulationWork work, StockWork stockWork)
        {
            string key = string.Empty;
            if (work.GoodsMakerCd == 0)
            {
                key = work.GoodsNo;
            }
            else
            {
                key = work.GoodsMakerCd.ToString("d04") + ct_septation + work.GoodsNo;
            }
            if (!this._goodsUnitDataDic.ContainsKey(key))
            {
                return;
            }
            GoodsUnitData goodsUnitData = this._goodsUnitDataDic[key];
            
            // ------------------ ADD 許雁波 2015/06/03 同一倉庫内で同一品番が複数印字される修正 ------------------------>>>>>
            // 在庫管理拠点より仕入先を取得する
            goodsUnitData.SectionCode = work.SectionCode;  // ADD 許雁波 2015/08/13 仕入先取得、原単価算出の障害対応
            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);  // ADD 許雁波 2015/08/13 仕入先取得、原単価算出の障害対応
            // 上記商品アクセス部品中には拠点をリセットしたので、再設定する
            goodsUnitData.SectionCode = work.SectionCode;  // ADD 許雁波 2015/08/13 仕入先取得、原単価算出の障害対応
            // 取得した仕入先コードが入力範囲以外の場合、印字対象外とする
            if (paramWork.St_SupplierCd != 0 && goodsUnitData.SupplierCd < paramWork.St_SupplierCd)
            {
                return;
            }
            if (paramWork.Ed_SupplierCd != 0 && goodsUnitData.SupplierCd > paramWork.Ed_SupplierCd)
            {
                return;
            }
            // ------------------ ADD 許雁波 2015/06/03 同一倉庫内で同一品番が複数印字される修正 ------------------------<<<<<
            DataRow dr;
            dr = orderPointStDt.NewRow();

            #region 発注点設定処理データ展開
            dr[OrderPointStSimulationTbl.Col_UpdateDateTime] = work.UpdateDateTime;
            dr[OrderPointStSimulationTbl.Col_EnterpriseCode] = work.EnterpriseCode;
            dr[OrderPointStSimulationTbl.Col_SectionCode] = work.SectionCode;
            dr[OrderPointStSimulationTbl.Col_SectionName] = work.SectionName;
            dr[OrderPointStSimulationTbl.Col_PatterNo] = work.PatterNo;
            dr[OrderPointStSimulationTbl.Col_PatternNoDerivedNo] = work.PatternNoDerivedNo;
            dr[OrderPointStSimulationTbl.Col_SettingCode] = work.PatterNo;
            dr[OrderPointStSimulationTbl.Col_WarehouseCode] = work.WarehouseCode;
            dr[OrderPointStSimulationTbl.Col_WarehouseName] = work.WarehouseName;
            dr[OrderPointStSimulationTbl.Col_SupplierCd] = goodsUnitData.SupplierCd;
            if (goodsUnitData.SupplierCd == 0)
            {
                dr[OrderPointStSimulationTbl.Col_SupplierName] = "未登録";
            }
            else
            {
                dr[OrderPointStSimulationTbl.Col_SupplierName] = goodsUnitData.SupplierSnm;
            }
            dr[OrderPointStSimulationTbl.Col_GoodsMakerCd] = work.GoodsMakerCd;
            dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd] = work.GoodsMakerCd.ToString("d04");
            dr[OrderPointStSimulationTbl.Col_GoodsMakerName] = work.GoodsMakerNm;
            dr[OrderPointStSimulationTbl.Col_GoodsMGroup] = goodsUnitData.GoodsMGroup;
            dr[OrderPointStSimulationTbl.Col_BLGroupCode] = goodsUnitData.BLGroupCode;
            dr[OrderPointStSimulationTbl.Col_BLGoodsCode] = goodsUnitData.BLGoodsCode;
            dr[OrderPointStSimulationTbl.Col_StckShipMonthSt] = work.StckShipMonthSt;
            dr[OrderPointStSimulationTbl.Col_StckShipMonthEd] = work.StckShipMonthEd;
            dr[OrderPointStSimulationTbl.Col_OrderApplyDiv] = work.OrderApplyDiv;
            dr[OrderPointStSimulationTbl.Col_ShipScopeMore] = work.ShipScopeMore;
            dr[OrderPointStSimulationTbl.Col_ShipScopeLess] = work.ShipScopeLess;
            dr[OrderPointStSimulationTbl.Col_MinimumStockCnt] = work.MinimumStockCnt;
            dr[OrderPointStSimulationTbl.Col_MaximumStockCnt] = work.MaximumStockCnt;
            dr[OrderPointStSimulationTbl.Col_SalesOrderUnit] = work.SalesOrderUnit;
            dr[OrderPointStSimulationTbl.Col_OrderPProcUpdFlg] = work.OrderPProcUpdFlg;
            dr[OrderPointStSimulationTbl.Col_GoodsNo] = work.GoodsNo;
            dr[OrderPointStSimulationTbl.Col_GoodsName] = work.GoodsName;
            dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo] = work.WarehouseShelfNo;
            // 在庫マスタ情報の設定
            dr[OrderPointStSimulationTbl.Col_Stock_CreateDateTime] = stockWork.CreateDateTime;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdateDateTime] = stockWork.UpdateDateTime;
            dr[OrderPointStSimulationTbl.Col_Stock_EnterpriseCode] = stockWork.EnterpriseCode;
            dr[OrderPointStSimulationTbl.Col_Stock_FileHeaderGuid] = stockWork.FileHeaderGuid;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdEmployeeCode] = stockWork.UpdEmployeeCode;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdAssemblyId1] = stockWork.UpdAssemblyId1;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdAssemblyId2] = stockWork.UpdAssemblyId2;
            dr[OrderPointStSimulationTbl.Col_Stock_LogicalDeleteCode] = stockWork.LogicalDeleteCode;
            dr[OrderPointStSimulationTbl.Col_Stock_SectionCode] = stockWork.SectionCode;
            dr[OrderPointStSimulationTbl.Col_Stock_WarehouseCode] = stockWork.WarehouseCode;
            dr[OrderPointStSimulationTbl.Col_Stock_GoodsMakerCd] = stockWork.GoodsMakerCd;
            dr[OrderPointStSimulationTbl.Col_Stock_GoodsNo] = stockWork.GoodsNo;
            dr[OrderPointStSimulationTbl.Col_Stock_StockUnitPriceFl] = stockWork.StockUnitPriceFl;
            dr[OrderPointStSimulationTbl.Col_Stock_SupplierStock] = stockWork.SupplierStock;
            dr[OrderPointStSimulationTbl.Col_Stock_AcpOdrCount] = stockWork.AcpOdrCount;
            dr[OrderPointStSimulationTbl.Col_Stock_MonthOrderCount] = stockWork.MonthOrderCount;
            dr[OrderPointStSimulationTbl.Col_Stock_SalesOrderCount] = stockWork.SalesOrderCount;
            dr[OrderPointStSimulationTbl.Col_Stock_StockDiv] = stockWork.StockDiv;
            dr[OrderPointStSimulationTbl.Col_Stock_MovingSupliStock] = stockWork.MovingSupliStock;
            dr[OrderPointStSimulationTbl.Col_Stock_ShipmentPosCnt] = stockWork.ShipmentPosCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_StockTotalPrice] = stockWork.StockTotalPrice;
            dr[OrderPointStSimulationTbl.Col_Stock_LastStockDate] = stockWork.LastStockDate;
            dr[OrderPointStSimulationTbl.Col_Stock_LastSalesDate] = stockWork.LastSalesDate;
            dr[OrderPointStSimulationTbl.Col_Stock_LastInventoryUpdate] = stockWork.LastInventoryUpdate;
            dr[OrderPointStSimulationTbl.Col_Stock_MinimumStockCnt] = stockWork.MinimumStockCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_MaximumStockCnt] = stockWork.MaximumStockCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_NmlSalOdrCount] = stockWork.NmlSalOdrCount;
            dr[OrderPointStSimulationTbl.Col_Stock_SalesOrderUnit] = stockWork.SalesOrderUnit;
            dr[OrderPointStSimulationTbl.Col_Stock_StockSupplierCode] = stockWork.StockSupplierCode;
            dr[OrderPointStSimulationTbl.Col_Stock_GoodsNoNoneHyphen] = stockWork.GoodsNoNoneHyphen;
            dr[OrderPointStSimulationTbl.Col_Stock_WarehouseShelfNo] = stockWork.WarehouseShelfNo;
            dr[OrderPointStSimulationTbl.Col_Stock_DuplicationShelfNo1] = stockWork.DuplicationShelfNo1;
            dr[OrderPointStSimulationTbl.Col_Stock_DuplicationShelfNo2] = stockWork.DuplicationShelfNo2;
            dr[OrderPointStSimulationTbl.Col_Stock_PartsManagementDivide1] = stockWork.PartsManagementDivide1;
            dr[OrderPointStSimulationTbl.Col_Stock_PartsManagementDivide2] = stockWork.PartsManagementDivide2;
            dr[OrderPointStSimulationTbl.Col_Stock_StockNote1] = stockWork.StockNote1;
            dr[OrderPointStSimulationTbl.Col_Stock_StockNote2] = stockWork.StockNote2;
            dr[OrderPointStSimulationTbl.Col_Stock_ShipmentCnt] = stockWork.ShipmentCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_ArrivalCnt] = stockWork.ArrivalCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_StockCreateDate] = stockWork.StockCreateDate;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdateDate] = stockWork.UpdateDate;
            // 原価単価
            double oldPrice = GetStockUnitPrice(goodsUnitData);
            dr[OrderPointStSimulationTbl.Col_OldPrice] = oldPrice;
            double nowStock = work.NowPrice;
            dr[OrderPointStSimulationTbl.Col_NowPrice] = work.NowPrice;
            double oldMinCnt = work.OldMinCnt;
            dr[OrderPointStSimulationTbl.Col_OldMinCnt] = work.OldMinCnt;
            double oldMaxCnt = work.OldMaxCnt;
            dr[OrderPointStSimulationTbl.Col_OldMaxCnt] = work.OldMaxCnt;
            double newMinCnt = work.NewMinCnt;
            dr[OrderPointStSimulationTbl.Col_NewMinCnt] = work.NewMinCnt;
            double newMaxCnt = work.NewMaxCnt;
            dr[OrderPointStSimulationTbl.Col_NewMaxCnt] = work.NewMaxCnt;

            double nowStockPrice = oldPrice * nowStock;
            double oldMinPrice = oldPrice * oldMinCnt;
            double oldMaxPrice = oldPrice * oldMaxCnt;
            double newMinPrice = oldPrice * newMinCnt;
            double newMaxPrice = oldPrice * newMaxCnt;
            switch (this._stockMngTtlSt.FractionProcCd)
            {
                case 1: // 切捨て
                    nowStockPrice = CalculateConsTax.Floor(nowStockPrice);
                    oldMinPrice = CalculateConsTax.Floor(oldMinPrice);
                    oldMaxPrice = CalculateConsTax.Floor(oldMaxPrice);
                    newMinPrice = CalculateConsTax.Floor(newMinPrice);
                    newMaxPrice = CalculateConsTax.Floor(newMaxPrice);
                    break;
                case 2: // 四捨五入
                    nowStockPrice = CalculateConsTax.Round(nowStockPrice);
                    oldMinPrice = CalculateConsTax.Round(oldMinPrice);
                    oldMaxPrice = CalculateConsTax.Round(oldMaxPrice);
                    newMinPrice = CalculateConsTax.Round(newMinPrice);
                    newMaxPrice = CalculateConsTax.Round(newMaxPrice);
                    break;
                case 3: // 切上げ
                    nowStockPrice = CalculateConsTax.Ceiling(nowStockPrice);
                    oldMinPrice = CalculateConsTax.Ceiling(oldMinPrice);
                    oldMaxPrice = CalculateConsTax.Ceiling(oldMaxPrice);
                    newMinPrice = CalculateConsTax.Ceiling(newMinPrice);
                    newMaxPrice = CalculateConsTax.Ceiling(newMaxPrice);
                    break;
            }
            dr[OrderPointStSimulationTbl.Col_NowStockPrice] = nowStockPrice;
            dr[OrderPointStSimulationTbl.Col_OldMinPrice] = oldMinPrice;
            dr[OrderPointStSimulationTbl.Col_OldMaxPrice] = oldMaxPrice;
            dr[OrderPointStSimulationTbl.Col_NewMinPrice] = newMinPrice;
            dr[OrderPointStSimulationTbl.Col_NewMaxPrice] = newMaxPrice;
            #endregion

            // TableにAdd
            orderPointStDt.Rows.Add(dr);
        }

        /// <summary>
        /// データのフィルタ処理
        /// </summary>
        /// <param name="outPutDiv">出力区分</param>
        /// <param name="fractionProcCd">端数区分</param>
        /// <param name="dr">該当行</param>
        /// <param name="lastDr">前回行</param>
        /// <param name="isSame">同じかどうか</param>
        /// <param name="lastWarehouseCode">前回倉庫コード</param>
        /// <param name="lastSupplierCd">前回仕入先コード</param>
        /// <param name="lastGoodsMakerCd">前回メーカーコード</param>
        /// <param name="lastWarehouseShelfNo">前回棚番</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : データのフィルタ処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.04</br>
        /// </remarks>
        public void DataFilter(Int32 outPutDiv, Int32 fractionProcCd, ref DataRow dr, ref DataRow lastDr, out bool isSame, ref string lastWarehouseCode, ref string lastSupplierCd, ref string lastWarehouseShelfNo, ref string lastGoodsMakerCd)
        {
            isSame = false;
            if (dr[OrderPointStSimulationTbl.Col_WarehouseCode].Equals(lastDr[OrderPointStSimulationTbl.Col_WarehouseCode]) &&
                dr[OrderPointStSimulationTbl.Col_SupplierCd].Equals(lastDr[OrderPointStSimulationTbl.Col_SupplierCd]) &&
                dr[OrderPointStSimulationTbl.Col_GoodsMakerCd].Equals(lastDr[OrderPointStSimulationTbl.Col_GoodsMakerCd]) &&
                dr[OrderPointStSimulationTbl.Col_GoodsMGroup].Equals(lastDr[OrderPointStSimulationTbl.Col_GoodsMGroup]) &&
                dr[OrderPointStSimulationTbl.Col_BLGroupCode].Equals(lastDr[OrderPointStSimulationTbl.Col_BLGroupCode]) &&
                dr[OrderPointStSimulationTbl.Col_BLGoodsCode].Equals(lastDr[OrderPointStSimulationTbl.Col_BLGoodsCode]) &&
                dr[OrderPointStSimulationTbl.Col_GoodsNo].Equals(lastDr[OrderPointStSimulationTbl.Col_GoodsNo]))
            {
                isSame = true;
            }

            string nowWarehouseCode = dr[OrderPointStSimulationTbl.Col_WarehouseCode].ToString().TrimEnd();
            switch (outPutDiv)
            {
                case 0:
                    // 品番順
                    if (nowWarehouseCode.Equals(lastWarehouseCode) && 
                        dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString().Equals(lastSupplierCd) &&
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                    {
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd] = string.Empty;
                    }
                    else
                    {
                        if (!nowWarehouseCode.Equals(lastWarehouseCode))
                        {
                            lastWarehouseCode = nowWarehouseCode;
                            lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString().Equals(lastSupplierCd))
                        {
                            lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                        {
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                    }
                    break;
                case 1:
                    // 棚番順
                    if (nowWarehouseCode.Equals(lastWarehouseCode) &&
                        dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].Equals(lastWarehouseShelfNo))
                    {
                        dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo] = string.Empty;
                    }
                    else
                    {
                        if (!nowWarehouseCode.Equals(lastWarehouseCode))
                        {
                            lastWarehouseCode = nowWarehouseCode;
                            lastWarehouseShelfNo = dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].Equals(lastWarehouseShelfNo))
                        {
                            lastWarehouseShelfNo = dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].ToString();
                        }
                    }
                    break;
                case 2:
                    // メーカー・品番順
                    if (nowWarehouseCode.Equals(lastWarehouseCode) && 
                        dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString().Equals(lastSupplierCd) &&
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                    {
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd] = string.Empty;
                    }
                    else
                    {
                        if (!nowWarehouseCode.Equals(lastWarehouseCode))
                        {
                            lastWarehouseCode = nowWarehouseCode;
                            lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString().Equals(lastSupplierCd))
                        {
                            lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                        {
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                    }
                    break;
                case 3:
                    // メーカー・棚番順
                    if (nowWarehouseCode.Equals(lastWarehouseCode) &&
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                    {
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd] = string.Empty;
                    }
                    else
                    {
                        if (!nowWarehouseCode.Equals(lastWarehouseCode))
                        {
                            lastWarehouseCode = nowWarehouseCode;
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                        {
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                    }
                    break;
            }
        }

        #region 商品アクセスクラス(結合検索無し完全一致)
        /// <summary>
        /// 商品アクセスクラス(結合検索無し完全一致)
        /// </summary>
        /// <param name="goodsCndtnList">商品抽出条件クラスリスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 結合検索無し完全一致で商品情報リストを取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.04</br>
        /// </remarks>
        private int GoodsRead(List<GoodsCndtn> goodsCndtnList)
        {
            int status = -1;
            string msg;
            List<List<GoodsUnitData>> goodsUnitDataListList = new List<List<GoodsUnitData>>();

            // 商品連結データローカルキャッシュをクリア
            _goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();

            // 結合検索無し完全一致で商品情報を取得
            // 商品マスタの検索
            foreach (GoodsCndtn goodsCndtn in goodsCndtnList)
            {
                List<GoodsUnitData> outGoodsUnitDataListList;
                status = this._goodsAcs.Search(goodsCndtn, out outGoodsUnitDataListList, out msg);
                if (outGoodsUnitDataListList != null && outGoodsUnitDataListList.Count > 0)
                {
                    goodsUnitDataListList.Add(outGoodsUnitDataListList);
                }
            }
            if ((goodsUnitDataListList != null) && (goodsUnitDataListList.Count != 0))
            {
                for (int i = 0; i < goodsUnitDataListList.Count; i++)
                {
                    List<GoodsUnitData> goodsUnitDataList = goodsUnitDataListList[i];

                    for (int j = 0; j < goodsUnitDataList.Count; j++)
                    {
                        GoodsUnitData goodsUnitData = goodsUnitDataList[j];
                        string key = goodsUnitData.GoodsMakerCd.ToString("d04") + ct_septation + goodsUnitData.GoodsNo;
                        if (_goodsUnitDataDic.ContainsKey(key))
                        {
                            // 同一商品が存在している場合は削除
                            _goodsUnitDataDic.Remove(key);
                        }
                        _goodsUnitDataDic.Add(key, goodsUnitData);

                        key = goodsUnitData.GoodsNo;
                        if (_goodsUnitDataDic.ContainsKey(key))
                        {
                            // 同一商品が存在している場合は削除
                            _goodsUnitDataDic.Remove(key);
                        }
                        _goodsUnitDataDic.Add(key, goodsUnitData);
                    }
                }
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <remarks>
        /// Note       : 税率設定マスタを取得します。<br />
        /// Programer  : 劉学智<br />
        /// Date       : 2009.05.04<br/>
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
        /// 在庫管理全体設定マスタ取得処理
        /// </summary>
        /// <remarks>
        /// Note       : 在庫管理全体設定マスタを取得します。<br />
        /// Programer  : 劉学智<br />
        /// Date       : 2009.05.04<br/>
        /// </remarks>
        private void ReadStockMngTtlSt()
        {
            int status;

            ArrayList stockMngTtlStList;
            try
            {
                // 在庫管理全体設定マスタ取得
                status = this._stockMngTtlStAcs.Search(out stockMngTtlStList, LoginInfoAcquisition.EnterpriseCode);
                if (stockMngTtlStList != null && stockMngTtlStList.Count > 0)
                {
                    foreach (StockMngTtlSt work in stockMngTtlStList)
                    {
                        if (work.SectionCode.Trim() == "00")
                        {
                            this._stockMngTtlSt = work;
                            break;
                        }
                    }
                }
            }
            catch
            {
                this._stockMngTtlStAcs = new StockMngTtlStAcs();
            }
        }

        /// <summary>
        /// 原単価取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>原単価</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ、商品連結データより原単価を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.04</br>
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.04</br>
        /// <br>Note       : Redmine#45978の#93と#94 仕入先取得、原単価算出の障害対応。</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2015/08/13</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            //unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // 拠点コード  // DEL 許雁波 2015/08/13 追加障害
            unitPriceCalcParam.SectionCode = goodsUnitData.SectionCode;    // ADD 許雁波 2015/08/13 仕入先取得、原単価算出の障害対応
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            //unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // 商品掛率グループコード  // DEL 許雁波 2015/08/13 追加障害
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;    // ADD 許雁波 2015/08/13 仕入先取得、原単価算出の障害対応
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                         // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);    // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.TotalAmountDispWayCd = 0;                                                // 総額表示方法区分
            unitPriceCalcParam.TtlAmntDspRateDivCd = 1;                                                 // 総額表示掛率適用区分
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード
            unitPriceCalcParam.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;                    // 消費税転嫁方式

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

        /// ----ADD 許雁波 2015/08/26 FOR Redmine45978 自社設定の掛率優先順位区分を参照していない障害対応 ---->>>>
        /// <summary>
        /// 掛率優先区分をセットします。
        /// </summary>
        /// <remarks>掛率優先区分をセットします。</remarks>
        private void SetUnitPriceCalculation()
        {
            CompanyInf companyInf = null;                 // 自社情報
            this._companyInfAcs.Read(out companyInf, LoginInfoAcquisition.EnterpriseCode);

            if (companyInf != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = companyInf.RatePriorityDiv;
            }
        }
        // ----ADD 許雁波 2015/08/26 FOR Redmine45978 自社設定の掛率優先順位区分を参照していない障害対応 ----<<<<

        #endregion ◆ データ展開処理

        #region ◆ 帳票設定データ取得

        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = string.Empty;

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
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
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票設定データ取得

        #region ◎ 在庫マスタ更新処理
        /// <summary>
        /// 在庫マスタ更新処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <param name="orderPointStList">発注点設定データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: 在庫マスタ更新処理を行います。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public int StockUpdate(DataSet ds, List<OrderPointSt> orderPointStList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            ArrayList stockWorkAl = new ArrayList();
            ArrayList orderPointStWorkList = new ArrayList();
            object objStockWorkAl;
            object objOrderPointStWorkAl;
            // 在庫管理全体設定マスタの取得
            this.ReadStockMngTtlSt();

            try
            {
                foreach (DataRow dr in ds.Tables[OrderPointStSimulationTbl.Col_Tbl_Result_OrderPointStSimulation].Rows)
                {
                    StockWork stockWork = new StockWork();
                    stockWork.CreateDateTime = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_CreateDateTime]);
                    stockWork.UpdateDateTime = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_UpdateDateTime]);
                    stockWork.EnterpriseCode = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_EnterpriseCode]);
                    stockWork.FileHeaderGuid = (Guid)dr[OrderPointStSimulationTbl.Col_Stock_FileHeaderGuid];
                    stockWork.UpdEmployeeCode = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_UpdEmployeeCode]);
                    stockWork.UpdAssemblyId1 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_UpdAssemblyId1]);
                    stockWork.UpdAssemblyId2 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_UpdAssemblyId2]);
                    stockWork.LogicalDeleteCode = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_LogicalDeleteCode]);
                    stockWork.SectionCode = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_SectionCode]);
                    stockWork.WarehouseCode = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_WarehouseCode]);
                    stockWork.GoodsMakerCd = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_GoodsMakerCd]);
                    stockWork.GoodsNo = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_GoodsNo]);
                    stockWork.StockUnitPriceFl = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_StockUnitPriceFl]);
                    stockWork.SupplierStock = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_SupplierStock]);
                    stockWork.AcpOdrCount = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_AcpOdrCount]);
                    stockWork.MonthOrderCount = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_MonthOrderCount]);
                    stockWork.SalesOrderCount = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_SalesOrderCount]);
                    stockWork.StockDiv = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_StockDiv]);
                    stockWork.MovingSupliStock = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_MovingSupliStock]);
                    stockWork.ShipmentPosCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_ShipmentPosCnt]);
                    stockWork.StockTotalPrice = Convert.ToInt64(dr[OrderPointStSimulationTbl.Col_Stock_StockTotalPrice]);
                    stockWork.LastStockDate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_LastStockDate]);
                    stockWork.LastSalesDate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_LastSalesDate]);
                    stockWork.LastInventoryUpdate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_LastInventoryUpdate]);
                    stockWork.MinimumStockCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_MinimumStockCnt]);
                    stockWork.MaximumStockCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_MaximumStockCnt]);
                    stockWork.NmlSalOdrCount = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_NmlSalOdrCount]);
                    if (this._stockMngTtlSt.LotUseDivCd == 0)
                    {
                        // 発注マスタの発注単位
                        stockWork.SalesOrderUnit = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_SalesOrderUnit]);
                    }
                    else
                    {
                        // 在庫マスタの発注単位
                        stockWork.SalesOrderUnit = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_SalesOrderUnit]);
                    }
                    stockWork.StockSupplierCode = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_StockSupplierCode]);
                    stockWork.GoodsNoNoneHyphen = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_GoodsNoNoneHyphen]);
                    stockWork.WarehouseShelfNo = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_WarehouseShelfNo]);
                    stockWork.DuplicationShelfNo1 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_DuplicationShelfNo1]);
                    stockWork.DuplicationShelfNo2 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_DuplicationShelfNo2]);
                    stockWork.PartsManagementDivide1 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_PartsManagementDivide1]);
                    stockWork.PartsManagementDivide2 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_PartsManagementDivide2]);
                    stockWork.StockNote1 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_StockNote1]);
                    stockWork.StockNote2 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_StockNote2]);
                    stockWork.ShipmentCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_ShipmentCnt]);
                    stockWork.ArrivalCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_ArrivalCnt]);
                    stockWork.StockCreateDate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_StockCreateDate]);
                    stockWork.UpdateDate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_UpdateDate]);
                    stockWorkAl.Add(stockWork);
                }
                
                foreach (OrderPointSt orderPointSt in orderPointStList)
                {
                    OrderPointStWork orderPointStWork = new OrderPointStWork();
                    orderPointStWork.CreateDateTime = orderPointSt.CreateDateTime;
                    orderPointStWork.UpdateDateTime = orderPointSt.UpdateDateTime;
                    orderPointStWork.EnterpriseCode = orderPointSt.EnterpriseCode;
                    orderPointStWork.FileHeaderGuid = orderPointSt.FileHeaderGuid;
                    orderPointStWork.UpdEmployeeCode = orderPointSt.UpdEmployeeCode;
                    orderPointStWork.UpdAssemblyId1 = orderPointSt.UpdAssemblyId1;
                    orderPointStWork.UpdAssemblyId2 = orderPointSt.UpdAssemblyId2;
                    orderPointStWork.LogicalDeleteCode = orderPointSt.LogicalDeleteCode;
                    orderPointStWork.PatterNo = orderPointSt.PatterNo;
                    orderPointStWork.PatternNoDerivedNo = orderPointSt.PatternNoDerivedNo;
                    orderPointStWork.WarehouseCode = orderPointSt.WarehouseCode;
                    orderPointStWork.SupplierCd = orderPointSt.SupplierCd;
                    orderPointStWork.GoodsMakerCd = orderPointSt.GoodsMakerCd;
                    orderPointStWork.GoodsMGroup = orderPointSt.GoodsMGroup;
                    orderPointStWork.BLGroupCode = orderPointSt.BLGroupCode;
                    orderPointStWork.BLGoodsCode = orderPointSt.BLGoodsCode;
                    orderPointStWork.StckShipMonthSt = orderPointSt.StckShipMonthSt;
                    orderPointStWork.StckShipMonthEd = orderPointSt.StckShipMonthEd;
                    orderPointStWork.OrderApplyDiv = orderPointSt.OrderApplyDiv;
                    orderPointStWork.StockCreateDate = orderPointSt.StockCreateDate;
                    orderPointStWork.ShipScopeMore = orderPointSt.ShipScopeMore;
                    orderPointStWork.ShipScopeLess = orderPointSt.ShipScopeLess;
                    orderPointStWork.MinimumStockCnt = orderPointSt.MinimumStockCnt;
                    orderPointStWork.MaximumStockCnt = orderPointSt.MaximumStockCnt;
                    orderPointStWork.SalesOrderUnit = orderPointSt.SalesOrderUnit;
                    orderPointStWork.OrderPProcUpdFlg = 1;
                    orderPointStWorkList.Add(orderPointStWork);
                }
                objStockWorkAl = stockWorkAl;
                objOrderPointStWorkAl = orderPointStWorkList;
                status = this._iOrderPointStSimulationDB.Write(ref objStockWorkAl, ref objOrderPointStWorkAl, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion ◎ 在庫マスタ更新処理
        #endregion ■ Private Method
    }
}
