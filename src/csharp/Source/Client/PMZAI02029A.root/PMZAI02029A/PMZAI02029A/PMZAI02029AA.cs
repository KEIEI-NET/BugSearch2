//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：在庫マスタ一覧印刷
// プログラム概要   ：在庫マスタ一覧の印刷を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/01/13     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/20     修正内容：Mantis【12127】速度アップ対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/27     修正内容：Mantis【11394】ソート順設定の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/05/21     修正内容：Mantis【12126】フィードバック対応 原価額の算出修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/04     修正内容：Mantis【13432】仕入先の抽出条件を修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：高峰
// 修正日    2013/06/18     修正内容：Redmine#36533 
//                          原価は全社設定の掛率からしか算出していない障害の修正
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫マスタ一覧印刷アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ一覧印刷で使用するデータを取得する。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009.01.13</br>
    /// <br></br>
    /// </remarks>
    public class StockMasterTblAcs
    {
        #region ■ Constructor
		/// <summary>
        /// 在庫マスタ一覧印刷アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫マスタ一覧印刷アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30413 犬飼</br>
	    /// <br>Date       : 2009.01.13</br>
		/// </remarks>
		public StockMasterTblAcs()
		{
            this._iStockMasterTblDB = (IStockMasterTblDB)MediationStockMasterTblDB.GetStockMasterTblDB();
            this._goodsAcs = new GoodsAcs();
            // 2009.03.09 30413 犬飼 原単価の算出処理を変更 >>>>>>START
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            // 2009.03.09 30413 犬飼 原単価の算出処理を変更 <<<<<<END
        
            // ----- ADD 2013/06/18 gaofeng for Redmine#36533 ----- >>>>>
            this._companyInfAcs = new CompanyInfAcs();
            this._companyInf = new CompanyInf();
            this.SetUnitPriceCalculation(LoginInfoAcquisition.EnterpriseCode);
            // ----- ADD 2013/06/18 gaofeng for Redmine#36533 ----- <<<<<
        
            // 商品アクセスクラスの初期化
            string message = "";
            this._goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);

            // 2009.03.09 30413 犬飼 原単価の算出処理を変更 >>>>>>START
            // 税率取得
            TaxRateSet taxRateSet;
            if (this.TaxRateSetRead(out taxRateSet) == 0)
            {
                _taxRate = this.GetTaxRate(taxRateSet, DateTime.Now);
            }

            // 単価算出モジュールの初期データ設定
            this.ReadInitData();
            // 2009.03.09 30413 犬飼 原単価の算出処理を変更 <<<<<<END
        }

		/// <summary>
        /// 在庫マスタ一覧印刷表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫マスタ一覧印刷表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        static StockMasterTblAcs()
		{
			stc_Employee		= null;
			
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

        /// <summary>価格情報マスタキャッシュ</summary>
        private static List<List<GoodsUnitData>> _goodsUnitDataListList;

        // ADD 2009/04/20 ------>>>
        /// <summary>商品情報キャッシュディクショナリー</summary>
        private static Dictionary<string, GoodsUnitData> _goodsUnitDataList;
        // ADD 2009/04/20 ------<<<
        #endregion ■ Static Member

        #region ■ Private Member
        IStockMasterTblDB _iStockMasterTblDB;           // 在庫マスタ一覧印刷リモート
        GoodsAcs _goodsAcs;                             // 商品アクセスクラス
        // 2009.03.09 30413 犬飼 原単価の算出処理を変更 >>>>>>START
        TaxRateSetAcs _taxRateSetAcs;                   // 税率設定マスタアクセスクラス
        UnitPriceCalculation _unitPriceCalculation;     // 単価算出モジュール

        private double _taxRate = 0.0;                  // 税率
        // 2009.03.09 30413 犬飼 原単価の算出処理を変更 <<<<<<END
        
        private DataSet _printDataSet;  // 印刷DataSet

        // ----- ADD 2013/06/18 gaofeng for Redmine#36533 ----- >>>>>
        /// <summary>自社情報設定 アクセスクラス</summary>
        private CompanyInfAcs _companyInfAcs;
        private CompanyInf _companyInf = null; // 自社情報
        // ----- ADD 2013/06/18 gaofeng for Redmine#36533 ----- <<<<<

        #endregion ■ Private Member

        #region [public プロパティ]
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataSet PrintDataSet
        {
            get { return this._printDataSet; }
        }
        #endregion

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 請求データ取得
        /// <summary>
        /// 在庫マスタ一覧印刷データ取得
        /// </summary>
        /// <param name="cndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する在庫マスタ一覧印刷データを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public int SearchStockMasterTbl(object cndtn, out string errMsg)
        {
            return this.SearchStockMasterTblProc(cndtn, out errMsg);
        }

        /// <summary>
        /// 印刷情報のマスタデータ取得
        /// </summary>
        /// <param name="retMList">印刷情報のマスタデータ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="prpid">プログラムID</param>
        /// <param name="prinm">プリンタ名</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷情報のマスタデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        public int SearchMasterData(out ArrayList retMList, string enterpriseCode, string prpid, string prinm)
        {
            return this.SearchMasterDataProc(out retMList, enterpriseCode, prpid, prinm);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 在庫マスタ一覧印刷データ取得
        /// <summary>
        /// 在庫マスタ一覧印刷データ取得
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する在庫マスタ一覧印刷データを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private int SearchStockMasterTblProc(object cndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            // データセット・データテーブル生成
            _printDataSet = new DataSet();
            _printDataSet.Tables.Add(PMZAI02029AB.CreateBillListTable());
            
            try
            {
                ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl = (ExtrInfo_StockMasterTbl)cndtn;
                ExtrInfo_StockMasterTblWork extrInfo_StockMasterTblWork = new ExtrInfo_StockMasterTblWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevStockMasterTbl(extrInfo_StockMasterTbl, out extrInfo_StockMasterTblWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retList = null;
                status = this._iStockMasterTblDB.Search(out retList, (object)extrInfo_StockMasterTblWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevPrintData(extrInfo_StockMasterTbl, (ArrayList)retList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        if (_printDataSet.Tables[PMZAI02029AB.CT_Tbl_StockList].Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "在庫マスタ一覧印刷データの取得に失敗しました。";
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
        #endregion ◆ 帳票データ取得

        #region ◆ データ展開処理
        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="extrInfo_StockMasterTbl">UI抽出条件クラス</param>
        /// <param name="extrInfo_StockMasterTblWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevStockMasterTbl(ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl, out ExtrInfo_StockMasterTblWork extrInfo_StockMasterTblWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            extrInfo_StockMasterTblWork = new ExtrInfo_StockMasterTblWork();

            try
            {
                extrInfo_StockMasterTblWork.EnterpriseCode = extrInfo_StockMasterTbl.EnterpriseCode;                // 企業コード

                extrInfo_StockMasterTblWork.St_WarehouseCode = extrInfo_StockMasterTbl.St_WarehouseCode;            // 開始倉庫コード
                extrInfo_StockMasterTblWork.Ed_WarehouseCode = extrInfo_StockMasterTbl.Ed_WarehouseCode;            // 終了倉庫コード
                extrInfo_StockMasterTblWork.St_WarehouseShelfNo = extrInfo_StockMasterTbl.St_WarehouseShelfNo;      // 開始棚番
                extrInfo_StockMasterTblWork.Ed_WarehouseShelfNo = extrInfo_StockMasterTbl.Ed_WarehouseShelfNo;	    // 終了棚番
                // DEL 2009/06/04 ------>>>
                //extrInfo_StockMasterTblWork.St_SupplierCd = extrInfo_StockMasterTbl.St_SupplierCd;	              // 開始仕入先コード
                //extrInfo_StockMasterTblWork.Ed_SupplierCd = extrInfo_StockMasterTbl.Ed_SupplierCd;                  // 終了仕入先コード
                // DEL 2009/06/04 ------<<<
                extrInfo_StockMasterTblWork.St_GoodsMakerCd = extrInfo_StockMasterTbl.St_GoodsMakerCd;	            // 開始メーカーコード
                extrInfo_StockMasterTblWork.Ed_GoodsMakerCd = extrInfo_StockMasterTbl.Ed_GoodsMakerCd;	            // 終了メーカーコード
                extrInfo_StockMasterTblWork.St_GoodsLGroup = extrInfo_StockMasterTbl.St_GoodsLGroup;	            // 開始商品大分類
                extrInfo_StockMasterTblWork.Ed_GoodsLGroup = extrInfo_StockMasterTbl.Ed_GoodsLGroup;	            // 終了商品大分類
                extrInfo_StockMasterTblWork.St_GoodsMGroup = extrInfo_StockMasterTbl.St_GoodsMGroup;	            // 開始商品中分類
                extrInfo_StockMasterTblWork.Ed_GoodsMGroup = extrInfo_StockMasterTbl.Ed_GoodsMGroup;	            // 終了商品中分類
                extrInfo_StockMasterTblWork.St_BLGroupCode = extrInfo_StockMasterTbl.St_BLGroupCode;	            // 開始グループコード
                extrInfo_StockMasterTblWork.Ed_BLGroupCode = extrInfo_StockMasterTbl.Ed_BLGroupCode;	            // 終了グループコード
                extrInfo_StockMasterTblWork.St_BLGoodsCode = extrInfo_StockMasterTbl.St_BLGoodsCode;	            // 開始BLコード
                extrInfo_StockMasterTblWork.Ed_BLGoodsCode = extrInfo_StockMasterTbl.Ed_BLGoodsCode;	            // 終了BLコード
                extrInfo_StockMasterTblWork.St_GoodsNo = extrInfo_StockMasterTbl.St_GoodsNo;	                    // 開始品番
                extrInfo_StockMasterTblWork.Ed_GoodsNo = extrInfo_StockMasterTbl.Ed_GoodsNo;	                    // 終了品番
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region [取得データ展開処理]
        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="billCndtn">UI抽出条件クラス</param>
        /// <param name="printList">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private void DevPrintData(ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl, ArrayList printList)
        {
            DataTable table = _printDataSet.Tables[PMZAI02029AB.CT_Tbl_StockList];

            int regNo = 0;
            string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            # region [マスタ展開]
            // 端末番号（レジ番号）
            PosTerminalMg posTerminalMg;
            if (GetPosTerminalMg(out posTerminalMg, extrInfo_StockMasterTbl.EnterpriseCode) == 0)
            {
                regNo = posTerminalMg.CashRegisterNo;
            }
            # endregion

            // 仕入先コード設定
            ArrayList updPrintList = new ArrayList();
            foreach (RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork in printList)
            {
                if (rsltInfo_StockMasterTblWork.SupplierCd != 0)
                {
                    // 設定済
                    // TODO 仕入先名称取得
                }
                else
                {
                    // 未設定
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    GetGoodsMngInfo(ref goodsUnitData, rsltInfo_StockMasterTblWork);
                    if (goodsUnitData != null)
                    {
                        rsltInfo_StockMasterTblWork.SupplierCd = goodsUnitData.SupplierCd;
                        rsltInfo_StockMasterTblWork.SupplierSnm = goodsUnitData.SupplierSnm;
                    }
                }

                if (CheckSupplierCd(extrInfo_StockMasterTbl, rsltInfo_StockMasterTblWork.SupplierCd))
                {
                    // 抽出対象の仕入先
                    updPrintList.Add(rsltInfo_StockMasterTblWork);
                }
            }

            // ADD 2009/06/04 ------>>>
            if (updPrintList.Count == 0)
            {
                // 抽出対象が０件の場合は処理終了
                return;
            }
            // ADD 2009/06/04 ------<<<
                
            // 価格情報取得のため商品アクセスクラスから商品連結データを取得
            SetCacheGoodsUnitDataList(updPrintList);

            // 2009.03.09 30413 犬飼 原単価の算出処理を修正 >>>>>>START
            // 原価単価掛率マークのディクショナリー
            Dictionary<string, string> costUnPrcRateMarkDic = new Dictionary<string, string>();

            // 価格の設定
            ArrayList updPricePrintList = new ArrayList();
            foreach (RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork in updPrintList)
            {
                GoodsPrice wkGoodsPrice;
                GoodsUnitData wkGoodsUnitData;
                // 価格情報の取得
                GetListPrice(rsltInfo_StockMasterTblWork, out wkGoodsPrice, out wkGoodsUnitData);
                rsltInfo_StockMasterTblWork.ListPrice = wkGoodsPrice.ListPrice;
                //rsltInfo_StockMasterTblWork.SalesUnitCost = wkGoodsPrice.SalesUnitCost;

                // 原単価の算出
                if (wkGoodsPrice.PriceStartDate != DateTime.MinValue)
                {
                    UnitPriceCalcRet unitPriceCalcRet;
                    CalculateUnitCost(rsltInfo_StockMasterTblWork, wkGoodsUnitData, _taxRate, out unitPriceCalcRet);
                    rsltInfo_StockMasterTblWork.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                    if ((wkGoodsPrice.SalesUnitCost == 0) && (wkGoodsPrice.StockRate == 0))
                    {
                        if (unitPriceCalcRet.RateVal != 0.0)
                        {
                            // 掛率マスタから算出した原単価
                            string key = PMZAI02029AB.CreateKey(rsltInfo_StockMasterTblWork);
                            if (!costUnPrcRateMarkDic.ContainsKey(key))
                            {
                                costUnPrcRateMarkDic.Add(key, "*");
                            }
                        }
                    }
                }
                else
                {
                    rsltInfo_StockMasterTblWork.SalesUnitCost = wkGoodsPrice.SalesUnitCost;
                }
                // 2009.03.09 30413 犬飼 原単価の算出処理を修正 <<<<<<END

                updPricePrintList.Add(rsltInfo_StockMasterTblWork);
            }
            
            // コピー処理
            PMZAI02029AB.CopyToBillListTable(ref table, extrInfo_StockMasterTbl, updPricePrintList, regNo, sectionCode, costUnPrcRateMarkDic);
        }
        #endregion

        #region [プリンタ設定取得]
        /// <summary>
        /// プリンタ設定　全取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="prinm">プリンタ名</param>
        /// <returns></returns>
        /// <remarks>※プリンタ管理設定はローカルＸＭＬを読み込みます。</remarks>
        public List<PrtManage> SearchAllPrtManage(string enterpriseCode, string prinm)
        {
            PrtManageAcs _prtManageAcs = new PrtManageAcs();

            List<PrtManage> prtManageList = new List<PrtManage>();

            ArrayList retList;
            _prtManageAcs.SearchAll(out retList, enterpriseCode);

            foreach (PrtManage prtManage in retList)
            {
                if ((prtManage.LogicalDeleteCode == 0) || (prtManage.PrinterName.TrimEnd() == prinm.TrimEnd()))
                {
                    prtManageList.Add(prtManage);
                }
            }

            return prtManageList;
        }
        #endregion

        #region [端末設定取得]
        /// <summary>
        /// 端末設定取得処理
        /// </summary>
        /// <param name="posTerminalMg">POS端末管理設定</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        private int GetPosTerminalMg(out PosTerminalMg posTerminalMg, string enterpriseCode)
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search(out posTerminalMg, enterpriseCode);
        }
        #endregion
        #endregion ◆ データ展開処理

        #region ◎ 設定マスタ取得
        /// <summary>
        /// 印刷情報のマスタデータ取得
        /// </summary>
        /// <param name="retMList">印刷情報のマスタデータ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="prpid">プログラムID</param>
        /// <param name="prinm">プリンタ名</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷情報のマスタデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private int SearchMasterDataProc(out ArrayList retMList, string enterpriseCode, string prpid, string prinm)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            retMList = new ArrayList();

            // 伝票印刷設定マスタ取得
            List<SlipPrtSetWork> slipPrtSetWorkList = new List<SlipPrtSetWork>();
            SlipPrtSetWork paraSlipPrtSetWork = new SlipPrtSetWork();
            paraSlipPrtSetWork.EnterpriseCode = enterpriseCode;
            status = this.SearchSlipPrtSetProc(out slipPrtSetWorkList, paraSlipPrtSetWork);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMList.Add(slipPrtSetWorkList);
            }
            else
            {
                return status;
            }

            // 伝票タイプ管理設定マスタ取得
            List<CustSlipMngWork> custSlipMngWorkList = new List<CustSlipMngWork>();
            CustSlipMngWork paraCustSlipMngWork = new CustSlipMngWork();
            paraCustSlipMngWork.EnterpriseCode = enterpriseCode;
            status = this.SearchCustSlipMngProc(out custSlipMngWorkList, paraCustSlipMngWork);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMList.Add(custSlipMngWorkList);
            }
            else
            {
                return status;
            }

            // 自由帳票印字位置設定マスタ取得
            List<FrePrtPSetWork> frePrtPSetWorkList = new List<FrePrtPSetWork>();
            List<FrePprSrtOWork> frePprSrtOWorkList = new List<FrePprSrtOWork>();   // ADD 2009/04/27
            //status = this.SearchFrePrtPSetProc(out frePrtPSetWorkList, enterpriseCode, prpid);    // DEL 2009/04/27
            status = this.SearchFrePrtPSetProc(out frePrtPSetWorkList, out frePprSrtOWorkList, enterpriseCode, prpid);  // ADD 2009/04/27
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMList.Add(frePrtPSetWorkList);
                retMList.Add(frePprSrtOWorkList);   // ADD 2009/04/27
            }
            else
            {
                return status;
            }

            // プリンタ設定リスト
            List<PrtManage> prtManageList = null;
            prtManageList = SearchAllPrtManage(enterpriseCode, prinm);
            if (prtManageList != null)
            {
                retMList.Add(prtManageList);
            }

            return status;
        }
        #endregion

        #region ◆伝票印刷設定マスタ取得
        /// <summary>
        /// 伝票印刷設定マスタ取得
        /// </summary>
        /// <param name="slipPrtSetWorkList">抽出データリスト</param>
        /// <param name="paraSlipPrtSetWork">抽出条件</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 伝票印刷設定マスタのデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private int SearchSlipPrtSetProc(out List<SlipPrtSetWork> slipPrtSetWorkList, SlipPrtSetWork paraSlipPrtSetWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            object retObj = new object();
            object paraObj = paraSlipPrtSetWork;

            slipPrtSetWorkList = new List<SlipPrtSetWork>();

            ISlipPrtSetDB iSlipPrtSetDB = (ISlipPrtSetDB)MediationSlipPrtSetDB.GetSlipPrtSetDB();

            status = iSlipPrtSetDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == 0)
            {
                foreach (SlipPrtSetWork slipPrtSetWork in retObj as ArrayList)
                {
                    if (slipPrtSetWorkList.Contains(slipPrtSetWork))
                    {
                        slipPrtSetWorkList.Remove(slipPrtSetWork);
                    }
                    slipPrtSetWorkList.Add(slipPrtSetWork);
                }
            }

            return status;
        }
        #endregion ◆ 伝票印刷設定マスタ取得

        #region ◆伝票タイプ管理設定マスタ取得
        /// <summary>
        /// 伝票タイプ管理設定マスタ取得
        /// </summary>
        /// <param name="custSlipMngWorkList">抽出データリスト</param>
        /// <param name="paraCustSlipMngWork">抽出条件</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 伝票タイプ管理設定マスタのデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private int SearchCustSlipMngProc(out List<CustSlipMngWork> custSlipMngWorkList, CustSlipMngWork paraCustSlipMngWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            object retObj = new object();
            object paraObj = paraCustSlipMngWork;

            custSlipMngWorkList = new List<CustSlipMngWork>();

            ICustSlipMngDB iCustSlipMngDB = (ICustSlipMngDB)MediationCustSlipMngDB.GetCustSlipMngDB();

            status = iCustSlipMngDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == 0)
            {
                foreach (CustSlipMngWork custSlipMngWork in retObj as ArrayList)
                {
                    if (custSlipMngWorkList.Contains(custSlipMngWork))
                    {
                        custSlipMngWorkList.Remove(custSlipMngWork);
                    }
                    custSlipMngWorkList.Add(custSlipMngWork);
                }
            }

            return status;
        }
        #endregion ◆ 伝票タイプ管理設定マスタ取得

        #region ◆自由帳票印字位置設定マスタ取得
        /// <summary>
        /// 自由帳票印字位置設定マスタ取得
        /// </summary>
        /// <param name="frePrtPSetWorkList">抽出データリスト</param>
        /// <param name="frePprSrtOWorkList">ソート順設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="prpid">プログラムID</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票印字位置設定マスタのデータを取得する。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        //private int SearchFrePrtPSetProc(out List<FrePrtPSetWork> frePrtPSetWorkList, string enterpriseCode, string prpid)    // DEL 2009/04/27
        private int SearchFrePrtPSetProc(out List<FrePrtPSetWork> frePrtPSetWorkList, out List<FrePprSrtOWork> frePprSrtOWorkList, string enterpriseCode, string prpid)     // ADD 2009/04/27
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            object retObj = new object();
            byte[] printPos = null;
            bool msgDiv = true;
            string errMsg = "";

            frePrtPSetWorkList = new List<FrePrtPSetWork>();
            frePprSrtOWorkList = new List<FrePprSrtOWork>();    // ADD 2009/04/27

            IFrePrtPSetDB iFrePrtPSetDB = (IFrePrtPSetDB)MediationFrePrtPSetDB.GetFrePrtPSetDB();

            status = iFrePrtPSetDB.Read(enterpriseCode, prpid, 0, out retObj, out printPos, out msgDiv, out errMsg);

            if (status == 0)
            {
                foreach (ArrayList retList in retObj as CustomSerializeArrayList)
                {
                    // DEL 2009/04/27 ------>>>
                    //foreach (FrePrtPSetWork frePrtPSetWork in retList)
                    //{
                    //    frePrtPSetWork.PrintPosClassData = printPos;
                    //    if (frePrtPSetWorkList.Contains(frePrtPSetWork))
                    //    {
                    //        frePrtPSetWorkList.Remove(frePrtPSetWork);
                    //    }
                    //    // 印字位置データを復号化する
                    //    //（※注意：frePrtPSet更新はfrePrtPSetListの該当レコード更新を意味します）
                    //    FrePrtSettingController.DecryptPrintPosClassData(frePrtPSetWork);
                    //    frePrtPSetWorkList.Add(frePrtPSetWork);
                    //}
                    // DEL 2009/04/27 ------<<<

                    // ADD 2009/04/27 ------>>>
                    if (retList[0] is FrePrtPSetWork)
                    {
                        foreach (FrePrtPSetWork frePrtPSetWork in retList)
                        {
                            frePrtPSetWork.PrintPosClassData = printPos;
                            if (frePrtPSetWorkList.Contains(frePrtPSetWork))
                            {
                                frePrtPSetWorkList.Remove(frePrtPSetWork);
                            }
                            // 印字位置データを復号化する
                            //（※注意：frePrtPSet更新はfrePrtPSetListの該当レコード更新を意味します）
                            FrePrtSettingController.DecryptPrintPosClassData(frePrtPSetWork);
                            frePrtPSetWorkList.Add(frePrtPSetWork);
                        }
                    }
                    else if (retList[0] is FrePprSrtOWork)
                    {
                        frePprSrtOWorkList.AddRange((FrePprSrtOWork[])retList.ToArray(typeof(FrePprSrtOWork)));
                    }
                    // ADD 2009/04/27 ------<<<
                }
            }

            return status;
        }
        #endregion ◆ 自由帳票印字位置設定マスタ取得

        #region 商品アクセスクラス(商品管理情報取得)
        /// <summary>
        /// 商品アクセスクラス(商品管理情報取得)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データクラス</param>
        /// <param name="autoOrderResultWork">抽出結果データクラス</param>
        /// <remarks>
        /// <br>Note       : 商品管理情報を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.13</br>
        /// </remarks>
        private void GetGoodsMngInfo(ref GoodsUnitData goodsUnitData, RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork)
        {
            // 抽出条件設定
            goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;             // 企業コード
            goodsUnitData.SectionCode = rsltInfo_StockMasterTblWork.SectionCode;            // 拠点コード
            goodsUnitData.GoodsMakerCd = rsltInfo_StockMasterTblWork.GoodsMakerCd;          // メーカーコード
            goodsUnitData.GoodsNo = rsltInfo_StockMasterTblWork.GoodsNo;                    // 品番
            goodsUnitData.BLGoodsCode = rsltInfo_StockMasterTblWork.BLGoodsCode;            // BLコード
            goodsUnitData.GoodsMGroup = rsltInfo_StockMasterTblWork.GoodsMGroup;            // 商品中分類

            // 商品管理情報の取得
            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
        }
        #endregion

        #region 仕入先の抽出条件チェック
        /// <summary>
        /// 仕入先の抽出条件チェック
        /// </summary>
        /// <param name="extrInfo_StockMasterTbl">抽出条件</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <remarks>
        /// <br>Note       : 仕入先が抽出条件と一致するかチェック。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private bool CheckSupplierCd(ExtrInfo_StockMasterTbl extrInfo_StockMasterTbl, int supplierCd)
        {
            int ed_SupplierCode = extrInfo_StockMasterTbl.Ed_SupplierCd;
            if (ed_SupplierCode == 0)
            {
                // 終了未設定
                ed_SupplierCode = 999999;
            }

            if ((extrInfo_StockMasterTbl.St_SupplierCd <= supplierCd) && (supplierCd <= ed_SupplierCode))
            {
                // 抽出対象
                return true;
            }
            else
            {
                // 抽出対象外
                return false;
            }
        }
        #endregion

        #region 商品連結データのキャッシュ化
        /// <summary>
        /// 商品連結データのキャッシュ化
        /// </summary>
        /// <param name="printList">抽出結果</param>
        /// <remarks>
        /// <br>Note       : 商品連結データのキャッシュ化</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private void SetCacheGoodsUnitDataList(ArrayList printList)
        {
            GoodsAcs goodsAcs = new GoodsAcs();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            string message = "";
            goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);

            foreach (RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork in printList)
            {
                // 商品アクセスクラスの抽出条件を設定
                GoodsCndtn workGoodsCndtn = new GoodsCndtn();
                workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //workGoodsCndtn.SectionCode = rsltInfo_StockMasterTblWork.SectionCode.Trim();          // DEL 2009/05/21
                workGoodsCndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // ADD 2009/05/21 ログイン拠点
                workGoodsCndtn.GoodsNoSrchTyp = 0;
                workGoodsCndtn.GoodsMakerCd = rsltInfo_StockMasterTblWork.GoodsMakerCd;
                workGoodsCndtn.GoodsNo = rsltInfo_StockMasterTblWork.GoodsNo;
                workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

                goodsCndtnList.Add(workGoodsCndtn);
            }

            // ローカルキャッシュ初期化
            _goodsUnitDataListList = new List<List<GoodsUnitData>>();
            _goodsUnitDataList = new Dictionary<string, GoodsUnitData>();       // ADD 2009/04/20

            // 結合検索無し完全一致で商品情報を取得
            int status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out _goodsUnitDataListList, out message);
            // DEL 2009/04/20 ------>>>
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    _goodsUnitDataListList = null;
            //}
            // DEL 2009/04/20 ------<<<

            // ADD 2009/04/20 ------>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (List<GoodsUnitData> wkGoodsUnitDataList in _goodsUnitDataListList)
                {
                    // DEL 2009/05/21 ------>>>
                    //string key = wkGoodsUnitDataList[0].SectionCode.TrimEnd() + "-"
                    //           + wkGoodsUnitDataList[0].GoodsNo + "-"
                    //           + wkGoodsUnitDataList[0].GoodsMakerCd.ToString("0000");
                    // DEL 2009/05/21 ------<<<

                    if (wkGoodsUnitDataList[0].SectionCode.Trim() != LoginInfoAcquisition.Employee.BelongSectionCode.Trim())
                    {
                        string section = wkGoodsUnitDataList[0].SectionCode.Trim();
                    }

                    // ADD 2009/05/21 ------>>>
                    // キーを品番＋メーカーに修正
                    string key = wkGoodsUnitDataList[0].GoodsNo + "-"
                               + wkGoodsUnitDataList[0].GoodsMakerCd.ToString("0000");
                    // ADD 2009/05/21 ------<<<
                    
                    if (!_goodsUnitDataList.ContainsKey(key))
                    {
                        _goodsUnitDataList.Add(key, wkGoodsUnitDataList[0]);
                    }
                }
            }
            // ADD 2009/04/20 ------<<<
        }
        #endregion

        #region 価格情報の取得
        /// <summary>
        /// 価格情報の取得
        /// </summary>
        /// <param name="printList">抽出結果</param>
        /// <remarks>
        /// <br>Note       : 価格情報マスタを取得します</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.02.02</br>
        /// </remarks>
        private void GetListPrice(RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork, out GoodsPrice goodsPrice, out GoodsUnitData goodsUnitData)
        {
            goodsPrice = new GoodsPrice();
            goodsUnitData = new GoodsUnitData();

            // DEL 2009/04/20 ------>>>
            //if (_goodsUnitDataListList == null)
            //{
            //    return;
            //}

            //string nowDate = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);

            //foreach (List<GoodsUnitData> wkGoodsUnitDataList in _goodsUnitDataListList)
            //{
            //    foreach (GoodsUnitData wkGoodsUnitData in wkGoodsUnitDataList)
            //    {
            //        List<GoodsPrice> wkGoodsPriceList = wkGoodsUnitData.GoodsPriceList;

            //        foreach (GoodsPrice wkGoodsPrice in wkGoodsPriceList)
            //        {
            //            if ((wkGoodsPrice.PriceStartDateAdFormal.CompareTo(nowDate) <= 0) &&
            //                (wkGoodsPrice.GoodsMakerCd == rsltInfo_StockMasterTblWork.GoodsMakerCd) &&
            //                (wkGoodsPrice.GoodsNo == rsltInfo_StockMasterTblWork.GoodsNo))
            //            {
            //                goodsPrice = wkGoodsPrice.Clone();
            //                goodsUnitData = wkGoodsUnitData.Clone();
            //                return;
            //            }
            //        }
            //    }
            //}
            // DEL 2009/04/20 ------<<<

            // ADD 2009/04/20 ------>>>
            if (_goodsUnitDataList.Count == 0)
            {
                return;
            }

            string nowDate = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
            // DEL 2009/05/21 ------>>>
            //string key = rsltInfo_StockMasterTblWork.SectionCode.TrimEnd() + "-"
            //           + rsltInfo_StockMasterTblWork.GoodsNo + "-"
            //           + rsltInfo_StockMasterTblWork.GoodsMakerCd.ToString("0000");
            // DEL 2009/05/21 ------>>>
            
            // ADD 2009/05/21 ------>>>
            // キーを品番＋メーカーに修正
            string key = rsltInfo_StockMasterTblWork.GoodsNo + "-"
                       + rsltInfo_StockMasterTblWork.GoodsMakerCd.ToString("0000");
            // ADD 2009/05/21 ------<<<
            
            if (_goodsUnitDataList.ContainsKey(key))
            {
                GoodsUnitData wkGoodsUnitData = _goodsUnitDataList[key];

                List<GoodsPrice> wkGoodsPriceList = wkGoodsUnitData.GoodsPriceList;

                foreach (GoodsPrice wkGoodsPrice in wkGoodsPriceList)
                {
                    if ((wkGoodsPrice.PriceStartDateAdFormal.CompareTo(nowDate) <= 0) &&
                        (wkGoodsPrice.GoodsMakerCd == rsltInfo_StockMasterTblWork.GoodsMakerCd) &&
                        (wkGoodsPrice.GoodsNo == rsltInfo_StockMasterTblWork.GoodsNo))
                    {
                        goodsPrice = wkGoodsPrice.Clone();
                        goodsUnitData = wkGoodsUnitData.Clone();
                        return;
                    }
                }
            }
            // ADD 2009/04/20 ------<<<
        
            return;
        }
        #endregion

        #region 税率設定マスタアクセスクラス(Read)
        /// <summary>
        /// 税率設定マスタアクセスクラス(Read)
        /// </summary>
        /// <param name="taxRateSet">税率設定情報クラス</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタアクセスクラスから税率設定情報を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private int TaxRateSetRead(out TaxRateSet taxRateSet)
        {
            int status = -1;

            // 税率設定情報を取得
            status = this._taxRateSetAcs.Read(out taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                taxRateSet = new TaxRateSet();
            }
            return status;
        }
        #endregion

        #region 税率取得(税率設定マスタ)
        /// <summary>
        /// 税率取得(税率設定マスタ)
        /// </summary>
        /// <param name="taxRateSet">税率設定情報</param>
        /// <param name="targetDate">税率適用日</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        /// <remarks>
        /// <br>Note       : 税率取得情報から税率を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.28</br>
        /// </remarks>
        private double GetTaxRate(TaxRateSet taxRateSet, DateTime targetDate)
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }
        #endregion

        #region 原価単価計算処理(単価算出モジュール)
        /// <summary>
        /// 初期データ設定処理(単価算出モジュール)
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 単価算出モジュールの初期データを設定をします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.03.09</br>
        /// </remarks>
        private void ReadInitData()
        {
            int status = -1;
            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            ArrayList returnStockProcMoney;

            // 仕入金額データの取得
            status = stockProcMoneyAcs.Search(out returnStockProcMoney, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in (ArrayList)returnStockProcMoney)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            // 仕入金額端数処理区分設定マスタキャッシュ処理
            _unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }

        /// <summary>
        /// 原価単価計算処理(単価算出モジュール)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="taxRate">税率</param>
        /// <param name="unitPriceCalcRet">単価計算結果</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 原価単価計算を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.03.09</br>
        /// </remarks>
        private void CalculateUnitCost(RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork, GoodsUnitData goodsUnitData, double taxRate, out UnitPriceCalcRet unitPriceCalcRet)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList;
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcRet = new UnitPriceCalcRet();
            
            // パラメータ設定
            //unitPriceCalcParam.SectionCode = goodsUnitData.SectionCode.TrimEnd();           // 拠点コード // DEL 2013/06/18 gaofeng for Redmine#36533
            unitPriceCalcParam.SectionCode = rsltInfo_StockMasterTblWork.SectionCode.TrimEnd();// 在庫管理拠点を設定 // ADD 2013/06/18 gaofeng for Redmine#36533
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 品番
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                     // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BL商品コード
            unitPriceCalcParam.SupplierCd = rsltInfo_StockMasterTblWork.SupplierCd;         // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Now;                               // 価格適用日
            unitPriceCalcParam.CountFl = 1.0;                                               // 数量            
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // 課税区分
            unitPriceCalcParam.TaxRate = taxRate;                                           // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;   // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;     // 仕入単価端数処理コード
            
            // 原価単価計算処理
            _unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    // 原価単価を取得
                    unitPriceCalcRet = unitPriceCalcRetWk;
                    return;
                }
            }
        }
        #endregion

        // ---  ADD 2013/06/18 gaofeng for Redmine#36533 ------- >>>>>
        /// <summary>
        /// 掛率優先区分に追加
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率優先区分に追加する。</br>
        /// </remarks>
        public void SetUnitPriceCalculation(string enterpriseCode)
        {

            this._companyInfAcs.Read(out this._companyInf, enterpriseCode);

            // 掛率優先区分
            if (this._companyInf != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._companyInf.RatePriorityDiv;
            }
        }
        // ---  ADD 2013/06/18 gaofeng for Redmine#36533 ------- <<<<<

        #endregion ■ Private Method

    }
}
