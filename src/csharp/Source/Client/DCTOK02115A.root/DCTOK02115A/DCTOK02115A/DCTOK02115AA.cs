using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上実績表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 売上実績表で使用するデータを取得する。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.11.26</br>
    /// <br>Update Note  : 2008.10.08 30452 上野 俊治</br>
    /// <br>              ・PM.NS対応</br>
    /// <br>Update Note  : 2008/10/23       照田 貴志</br>
    /// <br>              ・バグ修正、仕様変更対応</br>
    /// <br>Update Note  : 2008/12/04 30452 上野 俊治</br>
    /// <br>              ・バグ修正</br>
    /// <br>Update Note  : 200/02/06 30414 忍 幸史</br>
    /// <br>              ・速度UP対応</br>
    /// <br>Update Note: 2009.04.11 張莉莉</br>
    /// <br>            ・売上実績表（仕入先別）の追加</br>
    /// <br>Update Note  : 2009/06/24 張莉莉</br>
    /// <br>             ・仕入コードは「0」の場合、仕入名は「未登録」へ変更</br>
    /// <br>Update Note  : 2009/11/05 30517　夏野 駿希</br>
    /// <br>             ・MANTIS：13509，14459：当月，当期共に出荷数，純売上高，粗利額が0なら印字しない様に修正</br>
    /// <br>Update Note  : 2010/05/13　長内 数馬</br>
    /// <br>             ・明細単位「品番」以外で品名取得を行わないように修正</br>
    /// <br>Update Note  : 2014/12/16 李 侠</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             : 明治産業様Seiken品番変更</br>
    /// </remarks>
    public class SalesRsltListAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 売上実績表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上実績表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesRsltListAcs()
        {
            this._goodsAcs = new GoodsAcs();                 // 商品マスタアクセスクラス     //ADD 2008/10/23
            this._iSalesRsltListResultDB = (ISalesRsltListResultDB)MediationSalesRsltListResultDB.GetSalesRsltListResultDB();

        }

        /// <summary>
        /// 売上実績表アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上実績表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        static SalesRsltListAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs = new SecInfoAcs(1);    // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach (SecInfoSet secInfoSet in secInfoSetList)
            {
                // 既存でなければ
                if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode))
                {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
        }
        #endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス

        private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        #endregion ■ Static Member

        #region ■ Private Member
        ISalesRsltListResultDB _iSalesRsltListResultDB;

        private DataTable _stockManagementListDt;			// 印刷DataTable
        private DataView _stockManagementListDataView;	// 印刷DataView

        private GoodsAcs _goodsAcs;                     // 商品マスタアクセスクラス     //ADD 2008/10/23
        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView StockManagementListDataView
        {
            get { return this._stockManagementListDataView; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 入金データ取得
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="salesRsltListCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public int SearchMain(SalesRsltListCndtn salesRsltListCndtn, out string errMsg)
        {
            return this.SearchProc(salesRsltListCndtn, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 在庫移動データ取得
        /// <summary>
        /// 在庫移動データ取得
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する在庫移動データを取得する。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private int SearchProc(SalesRsltListCndtn salesRsltListCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                DCTOK02114EA.CreateDataTable(ref this._stockManagementListDt);

                SalesRsltListCndtnWork salesRsltListCndtnWork = new SalesRsltListCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevStockMoveCndtn(salesRsltListCndtn, out salesRsltListCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iSalesRsltListResultDB.Search(out retWorkList, salesRsltListCndtnWork);

                // テスト用
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevStockMoveData(salesRsltListCndtn, (ArrayList)retWorkList);

                        // 2009/11/05 Add >>>
                        if (this._stockManagementListDataView.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }
                        // 2009/11/05 Add <<<

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "売上月次集計データの取得に失敗しました。";
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
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="salesRsltListCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Update Note: 2014/12/16 李 侠</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 明治産業様Seiken品番変更</br>
        /// </remarks>
        private int DevStockMoveCndtn(SalesRsltListCndtn salesRsltListCndtn, out SalesRsltListCndtnWork salesRsltListCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            salesRsltListCndtnWork = new SalesRsltListCndtnWork();
            try
            {
                salesRsltListCndtnWork.EnterpriseCode = salesRsltListCndtn.EnterpriseCode;  // 企業コード

                // 抽出条件パラメータセット
                if (salesRsltListCndtn.SectionCodes.Length != 0)
                {
                    if (salesRsltListCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        //salesRsltListCndtnWork.AddUpSecCodes = null; // DEL 2008/10/08
                        salesRsltListCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        //salesRsltListCndtnWork.AddUpSecCodes = salesRsltListCndtn.AddUpSecCodes; // DEL 2008/10/08
                        salesRsltListCndtnWork.SectionCodes = salesRsltListCndtn.SectionCodes;
                    }
                }
                else
                {
                    //salesRsltListCndtnWork.AddUpSecCodes = null; // DEL 2008/10/08
                    salesRsltListCndtnWork.SectionCodes = null;
                }
                // --- DEL 2008/10/08 -------------------------------->>>>>
                //salesRsltListCndtnWork.GroupBySectionDiv = (int)salesRsltListCndtn.GroupBySectionDiv; // 拠点別集計区分
                //salesRsltListCndtnWork.PrintSelectDiv = (int)salesRsltListCndtn.PrintSelectDiv; // 帳票集計区分
                //salesRsltListCndtnWork.St_ThisMonth = GetYearMonthFromDateTime(salesRsltListCndtn.St_ThisMonth); // 開始当月
                //salesRsltListCndtnWork.Ed_ThisMonth = GetYearMonthFromDateTime(salesRsltListCndtn.Ed_ThisMonth); // 終了当月
                //salesRsltListCndtnWork.St_ThisYearMonth = GetYearMonthFromDateTime(salesRsltListCndtn.St_ThisYearMonth); // 開始当期月
                //salesRsltListCndtnWork.Ed_ThisYearMonth = GetYearMonthFromDateTime(salesRsltListCndtn.Ed_ThisYearMonth); // 終了当期月
                //salesRsltListCndtnWork.StockOrderDiv = (int)salesRsltListCndtn.StockOrderDiv; // 在庫取寄区分
                //salesRsltListCndtnWork.St_SubSectionCode = salesRsltListCndtn.St_SubSectionCode; // 開始部門コード
                //salesRsltListCndtnWork.Ed_SubSectionCode = salesRsltListCndtn.Ed_SubSectionCode; // 終了部門コード
                //salesRsltListCndtnWork.St_MinSectionCode = salesRsltListCndtn.St_MinSectionCode; // 開始課コード
                //salesRsltListCndtnWork.Ed_MinSectionCode = salesRsltListCndtn.Ed_MinSectionCode; // 終了課コード
                //salesRsltListCndtnWork.St_EmployeeCode = salesRsltListCndtn.St_EmployeeCode; // 開始従業員コード
                //salesRsltListCndtnWork.Ed_EmployeeCode = salesRsltListCndtn.Ed_EmployeeCode; // 終了従業員コード
                //salesRsltListCndtnWork.St_CustomerCode = salesRsltListCndtn.St_CustomerCode; // 開始得意先コード
                //salesRsltListCndtnWork.Ed_CustomerCode = salesRsltListCndtn.Ed_CustomerCode; // 終了得意先コード
                //salesRsltListCndtnWork.St_GoodsMakerCd = salesRsltListCndtn.St_GoodsMakerCd; // 開始商品メーカーコード
                //salesRsltListCndtnWork.Ed_GoodsMakerCd = salesRsltListCndtn.Ed_GoodsMakerCd; // 終了商品メーカーコード
                //salesRsltListCndtnWork.St_GoodsNo = salesRsltListCndtn.St_GoodsNo; // 開始商品番号
                //salesRsltListCndtnWork.Ed_GoodsNo = salesRsltListCndtn.Ed_GoodsNo; // 終了商品番号
                //salesRsltListCndtnWork.St_BLGoodsCode = salesRsltListCndtn.St_BLGoodsCode; // 開始BL商品コード
                //salesRsltListCndtnWork.Ed_BLGoodsCode = salesRsltListCndtn.Ed_BLGoodsCode; // 終了BL商品コード
                //salesRsltListCndtnWork.St_LargeGoodsGanreCode = salesRsltListCndtn.St_LargeGoodsGanreCode; // 開始商品区分グループコード
                //salesRsltListCndtnWork.Ed_LargeGoodsGanreCode = salesRsltListCndtn.Ed_LargeGoodsGanreCode; // 終了商品区分グループコード
                //salesRsltListCndtnWork.St_MediumGoodsGanreCode = salesRsltListCndtn.St_MediumGoodsGanreCode; // 開始商品区分コード
                //salesRsltListCndtnWork.Ed_MediumGoodsGanreCode = salesRsltListCndtn.Ed_MediumGoodsGanreCode; // 終了商品区分コード
                //salesRsltListCndtnWork.St_DetailGoodsGanreCode = salesRsltListCndtn.St_DetailGoodsGanreCode; // 開始商品区分詳細コード
                //salesRsltListCndtnWork.Ed_DetailGoodsGanreCode = salesRsltListCndtn.Ed_DetailGoodsGanreCode; // 終了商品区分詳細コード
                //salesRsltListCndtnWork.St_EnterpriseGanreCode = salesRsltListCndtn.St_EnterpriseGanreCode; // 開始自社分類コード
                //salesRsltListCndtnWork.Ed_EnterpriseGanreCode = salesRsltListCndtn.Ed_EnterpriseGanreCode; // 終了自社分類コード
                //salesRsltListCndtnWork.St_SupplierCd = salesRsltListCndtn.St_SupplierCd; // 開始仕入先コード
                //salesRsltListCndtnWork.Ed_SupplierCd = salesRsltListCndtn.Ed_SupplierCd; // 終了仕入先コード

                //salesRsltListCndtnWork.St_TotalSalesCount = salesRsltListCndtn.St_ShipmentCnt;  // 開始出荷数
                //salesRsltListCndtnWork.Ed_TotalSalesCount = salesRsltListCndtn.Ed_ShipmentCnt;  // 終了出荷数
                // --- DEL 2008/10/08 --------------------------------<<<<<
                // --- ADD 2008/10/08 -------------------------------->>>>>
                salesRsltListCndtnWork.TotalType = (int)salesRsltListCndtn.TotalType; // 集計単位
                salesRsltListCndtnWork.TtlType = (int)salesRsltListCndtn.TtlType; // 集計方法
                salesRsltListCndtnWork.PrintRangeDiv = (int)salesRsltListCndtn.PrintRangeDiv; // 出荷指定区分
                salesRsltListCndtnWork.RsltTtlDivCd = (int)salesRsltListCndtn.RsltTtlDivCd; // 在庫取寄区分
                if (salesRsltListCndtn.TotalType == SalesRsltListCndtn.TotalTypeState.EachWareHouse
                    && salesRsltListCndtn.PrintRangeDiv == SalesRsltListCndtn.PrintRangeDivState.AnnualYearMonth) // 当期印刷
                {
                    // 当期印刷は"する"で渡し、帳票印字をUIで制御
                    salesRsltListCndtnWork.AnnualPrintDiv = (int)SalesRsltListCndtn.AnnualPrintDivState.Print;
                }
                else
                {
                    salesRsltListCndtnWork.AnnualPrintDiv = (int)salesRsltListCndtn.AnnualPrintDiv;
                }
                salesRsltListCndtnWork.MakerPrintDiv = (int)salesRsltListCndtn.MakerPrintDiv;       // メーカー別印刷
                salesRsltListCndtnWork.Detail = salesRsltListCndtn.Detail;                          // 明細単位
                salesRsltListCndtnWork.PrintType = (int)salesRsltListCndtn.PrintType;               // 発行タイプ
                salesRsltListCndtnWork.AddUpYearMonthSt = salesRsltListCndtn.AddUpYearMonthSt;      // 開始対象年月（当月）
                salesRsltListCndtnWork.AddUpYearMonthEd = salesRsltListCndtn.AddUpYearMonthEd;      // 終了対象年月（当月）
                salesRsltListCndtnWork.AnnualAddUpYearMonthSt = salesRsltListCndtn.AnnualAddUpYearMonthSt;  // 開始対象年月（当期）
                salesRsltListCndtnWork.AnnualAddUpYaerMonthEd = salesRsltListCndtn.AnnualAddUpYaerMonthEd;  // 終了対象年月（当期）
                // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更-------------------------------->>>>>
                // 実績表(商品別)で明細単位は「品番」の場合、品番集計区分と品番表示区分
                if (salesRsltListCndtn.TotalType == SalesRsltListCndtn.TotalTypeState.EachGoods
                    && salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo)
                {
                    salesRsltListCndtnWork.GoodsNoSumDiv = (int)salesRsltListCndtn.GoodsNoSumDiv;       // 品番集計区分
                    salesRsltListCndtnWork.GoodsNoDisDiv = (int)salesRsltListCndtn.GoodsNoDisDiv;       // 品番表示区分
                }
                else
                {
                    salesRsltListCndtnWork.GoodsNoSumDiv = -1;
                    salesRsltListCndtnWork.GoodsNoDisDiv = -1;
                }
                // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更--------------------------------<<<<<
                salesRsltListCndtnWork.SalesDateSt = salesRsltListCndtn.SalesDateSt;                // 開始対象期間（期間）
                salesRsltListCndtnWork.SalesDateEd = salesRsltListCndtn.SalesDateEd;                // 終了対象期間（期間）
                salesRsltListCndtnWork.AnnualSalesDateSt = salesRsltListCndtn.AnnualSalesDateSt;    // 開始対象期間（当期）
                salesRsltListCndtnWork.AnnualSalesDateEd = salesRsltListCndtn.AnnualSalesDateEd;    // 開始対象期間（当期）
                salesRsltListCndtnWork.PrintRangeSt = salesRsltListCndtn.PrintRangeSt;              // 開始印刷範囲指定
                //salesRsltListCndtnWork.PrintRangeEd = salesRsltListCndtn.PrintRangeEd;              // 終了印刷範囲指定               //DEL 2008/10/23 ""とALL9入力の区別をつける必要がある為
                //salesRsltListCndtnWork.PrintRangeEd = this.GetEndCode(salesRsltListCndtn.PrintRangeEd, 9);      // 終了印刷範囲指定     //ADD 2008/10/23 // DEL 2009/02/12
                salesRsltListCndtnWork.PrintRangeEd = salesRsltListCndtn.PrintRangeEd;              // 終了印刷範囲指定 // ADD 2009/02/12
                salesRsltListCndtnWork.CustomerCodeSt = salesRsltListCndtn.CustomerCodeSt;          // 開始得意先コード
                //salesRsltListCndtnWork.CustomerCodeEd = salesRsltListCndtn.CustomerCodeEd;          // 終了得意先コード               //DEL 2008/10/23 ""とALL9入力の区別をつける必要がある為
                salesRsltListCndtnWork.CustomerCodeEd = this.GetEndCode(salesRsltListCndtn.CustomerCodeEd, 8);  // 終了得意先コード     //ADD 2008/10/23
                salesRsltListCndtnWork.SupplierCodeSt = salesRsltListCndtn.SupplierCodeSt;          // 開始仕入先コード　　　　　　　//ADD 2009/04/11
                salesRsltListCndtnWork.SupplierCodeEd = this.GetEndCode(salesRsltListCndtn.SupplierCodeEd, 6);  // 終了仕入先コード     //ADD 2009/04/11

                salesRsltListCndtnWork.EmployeeCodeSt = salesRsltListCndtn.EmployeeCodeSt;          // 開始従業員コード
                //salesRsltListCndtnWork.EmployeeCodeEd = salesRsltListCndtn.EmployeeCodeEd;          // 終了従業員コード               //DEL 2008/10/23 ""とALL9入力の区別をつける必要がある為
                //salesRsltListCndtnWork.EmployeeCodeEd = this.GetEndCode(salesRsltListCndtn.EmployeeCodeEd, 4);  // 終了従業員コード     //ADD 2008/10/23
                salesRsltListCndtnWork.EmployeeCodeEd = salesRsltListCndtn.EmployeeCodeEd;  // 終了従業員コード     //ADD 2008/12/04
                salesRsltListCndtnWork.WarehouseCodeSt = salesRsltListCndtn.WarehouseCodeSt;        // 開始倉庫コード
                salesRsltListCndtnWork.WarehouseCodeEd = salesRsltListCndtn.WarehouseCodeEd;        // 終了倉庫コード
                salesRsltListCndtnWork.GoodsMakerCdSt = salesRsltListCndtn.GoodsMakerCdSt;          // 開始メーカーコード
                //salesRsltListCndtnWork.GoodsMakerCdEd = salesRsltListCndtn.GoodsMakerCdEd;          // 終了メーカーコード             //DEL 2008/10/23 ""とALL9入力の区別をつける必要がある為
                salesRsltListCndtnWork.GoodsMakerCdEd = this.GetEndCode(salesRsltListCndtn.GoodsMakerCdEd, 4);  // 終了メーカーコード   //ADD 2008/10/23
                salesRsltListCndtnWork.GoodsLGroupSt = salesRsltListCndtn.GoodsLGroupSt;            // 開始大分類コード
                //salesRsltListCndtnWork.GoodsLGroupEd = salesRsltListCndtn.GoodsLGroupEd;            // 終了大分類コード               //DEL 2008/10/23 ""とALL9入力の区別をつける必要がある為
                salesRsltListCndtnWork.GoodsLGroupEd = this.GetEndCode(salesRsltListCndtn.GoodsLGroupEd, 4);    // 終了大分類コード     //ADD 2008/10/23
                salesRsltListCndtnWork.GoodsMGroupSt = salesRsltListCndtn.GoodsMGroupSt;            // 開始中分類コード
                //salesRsltListCndtnWork.GoodsMGroupEd = salesRsltListCndtn.GoodsMGroupEd;            // 終了中分類コード               //DEL 2008/10/23 ""とALL9入力の区別をつける必要がある為
                salesRsltListCndtnWork.GoodsMGroupEd = this.GetEndCode(salesRsltListCndtn.GoodsMGroupEd, 4);    // 終了中分類コード     //ADD 2008/10/23
                salesRsltListCndtnWork.BLGroupCodeSt = salesRsltListCndtn.BLGroupCodeSt;            // 開始グループコード
                //salesRsltListCndtnWork.BLGroupCodeEd = salesRsltListCndtn.BLGroupCodeEd;            // 終了グループコード             //DEL 2008/10/23 ""とALL9入力の区別をつける必要がある為
                salesRsltListCndtnWork.BLGroupCodeEd = this.GetEndCode(salesRsltListCndtn.BLGroupCodeEd, 5);    // 終了グループコード   //ADD 2008/10/23
                salesRsltListCndtnWork.BLGoodsCodeSt = salesRsltListCndtn.BLGoodsCodeSt;            // 開始ＢＬコード
                //salesRsltListCndtnWork.BLGoodsCodeEd = salesRsltListCndtn.BLGoodsCodeEd;            // 終了ＢＬコード                 //DEL 2008/10/23 ""とALL9入力の区別をつける必要がある為
                salesRsltListCndtnWork.BLGoodsCodeEd = this.GetEndCode(salesRsltListCndtn.BLGoodsCodeEd, 5);    // 終了ＢＬコード       //ADD 2008/10/23
                salesRsltListCndtnWork.GoodsNoSt = salesRsltListCndtn.GoodsNoSt;                    // 開始品番
                salesRsltListCndtnWork.GoodsNoEd = salesRsltListCndtn.GoodsNoEd;                    // 終了品番
                // --- ADD 2008/10/08 --------------------------------<<<<< 
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        /// <summary>
        /// 年月取得処理（YYYYMM ← DateTime）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetYearMonthFromDateTime(DateTime dateTime)
        {
            // 年月をYYYYMMのintで返す
            return (dateTime.Year * 100 + dateTime.Month);
        }
        #endregion

        #region ◎ 取得データ展開処理
        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private void DevStockMoveData(SalesRsltListCndtn salesRsltListCndtn, ArrayList resultWork)
        {
            DataRow dr;

            foreach (SalesRsltListResultWork salesRsltListResultWork in resultWork)
            {
                dr = this._stockManagementListDt.NewRow();
                // 取得データ展開
                #region 取得データ展開
                dr[DCTOK02114EA.ct_Col_AddUpSecCode] = salesRsltListResultWork.AddUpSecCode; // 計上拠点コード
                dr[DCTOK02114EA.ct_Col_CompanyName1] = salesRsltListResultWork.CompanyName1; // 自社名称1
                //dr[DCTOK02114EA.ct_Col_CompanyName2] = salesRsltListResultWork.CompanyName2; // 自社名称2 // DEL 2008/10/08
                //dr[DCTOK02114EA.ct_Col_SectionGuideNm] = salesRsltListResultWork.SectionGuideNm; // 拠点ガイド名称 // DEL 2008/10/08
                dr[DCTOK02114EA.ct_Col_WarehouseCode] = salesRsltListResultWork.WarehouseCode; // 倉庫コード// ADD 2008/10/08
                dr[DCTOK02114EA.ct_Col_WarehouseName] = salesRsltListResultWork.WarehouseName; // 倉庫名称 // ADD 2008/10/08
                dr[DCTOK02114EA.ct_Col_EmployeeCode] = salesRsltListResultWork.EmployeeCode; // 従業員コード
                //dr[DCTOK02114EA.ct_Col_EmployeeName] = salesRsltListResultWork.EmployeeName; // 従業員名称 // DEL 2008/10/08
                dr[DCTOK02114EA.ct_Col_EmployeeName] = salesRsltListResultWork.Name; // 従業員名称 // ADD 2008/10/08
                dr[DCTOK02114EA.ct_Col_CustomerCode] = salesRsltListResultWork.CustomerCode; // 得意先コード
                dr[DCTOK02114EA.ct_Col_CustomerSnm] = salesRsltListResultWork.CustomerSnm; // 得意先略称

                dr[DCTOK02114EA.ct_Col_SupplierCode] = salesRsltListResultWork.SupplierCode; // 仕入先コード // ADD 2009/04/11
                if (salesRsltListResultWork.SupplierCode == 0 || string.Empty.Equals(salesRsltListResultWork.SupplierSnm))    // add 2009/06/24
                {
                    dr[DCTOK02114EA.ct_Col_SupplierSnm] = "未登録";
                }
                else
                {
                    dr[DCTOK02114EA.ct_Col_SupplierSnm] = salesRsltListResultWork.SupplierSnm; // 仕入先略称 // ADD 2009/04/11
                }

                dr[DCTOK02114EA.ct_Col_GoodsMakerCd] = salesRsltListResultWork.GoodsMakerCd; // 商品メーカーコード
                //dr[DCTOK02114EA.ct_Col_MakerName] = salesRsltListResultWork.MakerName; // メーカー名称 // DEL 2008/10/08
                dr[DCTOK02114EA.ct_Col_MakerShortName] = salesRsltListResultWork.MakerShortName; // メーカー略称 // ADD 2008/10/08
                //dr[DCTOK02114EA.ct_Col_LargeGoodsGanreCode] = salesRsltListResultWork.LargeGoodsGanreCode; // 商品区分グループコード // DEL 2008/10/08
                dr[DCTOK02114EA.ct_Col_GoodsLGroup] = salesRsltListResultWork.GoodsLGroup; // 商品大分類コード // ADD 2008/10/08
                //dr[DCTOK02114EA.ct_Col_LargeGoodsGanreName] = salesRsltListResultWork.LargeGoodsGanreName; // 商品区分グループ名称 // DEL 2008/10/08
                dr[DCTOK02114EA.ct_Col_GoodsLGroupName] = salesRsltListResultWork.GoodsLGroupName; // 商品大分類名称 // ADD 2008/10/08
                //dr[DCTOK02114EA.ct_Col_MediumGoodsGanreCode] = salesRsltListResultWork.MediumGoodsGanreCode; // 商品区分コード // DEL 2008/10/08
                dr[DCTOK02114EA.ct_Col_GoodsMGroup] = salesRsltListResultWork.GoodsMGroup; // 商品中分類コード // ADD 2008/10/08
                //dr[DCTOK02114EA.ct_Col_MediumGoodsGanreName] = salesRsltListResultWork.MediumGoodsGanreName; // 商品区分名称 // DEL 2008/10/08
                dr[DCTOK02114EA.ct_Col_GoodsMGroupName] = salesRsltListResultWork.GoodsMGroupName; // 商品中分類名称 // ADD 2008/10/08
                //dr[DCTOK02114EA.ct_Col_DetailGoodsGanreCode] = salesRsltListResultWork.DetailGoodsGanreCode; // 商品区分詳細コード // DEL 2008/10/08
                //dr[DCTOK02114EA.ct_Col_BLGroupCode] = salesRsltListResultWork.BLGoodsCode; // グループコード // ADD 2008/10/08 → // DEL 2008/10/23 取得する項目が違う(BLGoodsCodeになっている)
                dr[DCTOK02114EA.ct_Col_BLGroupCode] = salesRsltListResultWork.BLGroupCode; // グループコード                        // ADD 2008/10/23
                //dr[DCTOK02114EA.ct_Col_DetailGoodsGanreName] = salesRsltListResultWork.DetailGoodsGanreName; // 商品区分詳細名称 // DEL 2008/10/08
                dr[DCTOK02114EA.ct_Col_BLGroupKanaName] = salesRsltListResultWork.BLGroupKanaName; // グループコード名称
                dr[DCTOK02114EA.ct_Col_BLGoodsCode] = salesRsltListResultWork.BLGoodsCode; // BL商品コード
                dr[DCTOK02114EA.ct_Col_BLGoodsHalfName] = salesRsltListResultWork.BLGoodsHalfName; // BL商品コード名称（半角）
                dr[DCTOK02114EA.ct_Col_GoodsNo] = salesRsltListResultWork.GoodsNo; // 商品番号
                //dr[DCTOK02114EA.ct_Col_GoodsShortName] = salesRsltListResultWork.GoodsShortName; // 商品名略称 // DEL 2008/10/08
                // --- ADD 2008/10/23 ----------------------------------------------------------------------------------->>>>>
                if (!string.IsNullOrEmpty(salesRsltListResultWork.GoodsNo))  // ADD 2010/05/13 //明細単位が品番の場合のみ品名の取得を行う
                {  // ADD 2010/05/13
                    // 品名取得
                    if (string.IsNullOrEmpty(salesRsltListResultWork.GoodsNameKana.Trim()) == false)
                    {
                        dr[DCTOK02114EA.ct_Col_GoodsNameKana] = salesRsltListResultWork.GoodsNameKana;                      // 商品名称カナ
                    }
                    else
                    {
                        // 商品マスタ（提供）の名称取得
                        // --- CHG 2009/02/06 速度UP対応------------------------------------------------------>>>>>
                        //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                        //GoodsUnitData goodsUnitData = new GoodsUnitData();
                        //string msg = string.Empty;
                        //GoodsCndtn cndtn = new GoodsCndtn();
                        //cndtn.EnterpriseCode = salesRsltListCndtn.EnterpriseCode;           // 企業コード
                        //cndtn.GoodsMakerCd = salesRsltListResultWork.GoodsMakerCd;          // メーカーコード
                        //cndtn.GoodsNo = salesRsltListResultWork.GoodsNo;                    // 品番
                        //cndtn.SectionCode = salesRsltListResultWork.AddUpSecCode;           // 拠点コード
                        //int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out goodsUnitDataList, out msg);
                        //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        //{
                        //    if (goodsUnitDataList.Count > 0)
                        //    {
                        //        //取得できた場合
                        //        goodsUnitData = goodsUnitDataList[0];
                        //        if (goodsUnitData.OfferKubun == 0)
                        //        {
                        //            // 提供データ以外
                        //            dr[DCTOK02114EA.ct_Col_GoodsNameKana] = salesRsltListResultWork.BLGoodsHalfName;        // BL商品コード名称（半角）
                        //        }
                        //        else
                        //        {
                        //            // 提供データ
                        //            dr[DCTOK02114EA.ct_Col_GoodsNameKana] = goodsUnitData.GoodsNameKana;                    // 提供データの名称カナ
                        //        }
                        //    }
                        //    else
                        //    {
                        //        // 取得できなかった場合
                        //        dr[DCTOK02114EA.ct_Col_GoodsNameKana] = salesRsltListResultWork.BLGoodsHalfName;            // BL商品コード名称（半角）
                        //    }                        
                        //}
                        //else
                        //{
                        //    // 取得できなかった場合
                        //    dr[DCTOK02114EA.ct_Col_GoodsNameKana] = salesRsltListResultWork.BLGoodsHalfName;                // BL商品コード名称（半角）
                        //}
                        string goodsName = "";
                        // -- UPD 2010/05/13 -------------------------------------------------------->>>
                        //int status = GoodsAcs.GetGoodsNameKana(salesRsltListResultWork.GoodsMakerCd, salesRsltListResultWork.GoodsNo, out goodsName);
                        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (salesRsltListResultWork.GoodsMakerCd != 0)
                        {
                            status = GoodsAcs.GetGoodsNameKana(salesRsltListResultWork.GoodsMakerCd, salesRsltListResultWork.GoodsNo, out goodsName);
                        }
                        // -- UPD 2010/05/13 --------------------------------------------------------<<<
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (string.IsNullOrEmpty(goodsName) == false)
                            {
                                dr[DCTOK02114EA.ct_Col_GoodsNameKana] = goodsName;
                            }
                            else
                            {
                                dr[DCTOK02114EA.ct_Col_GoodsNameKana] = salesRsltListResultWork.BLGoodsHalfName;
                            }
                        }
                        else
                        {
                            dr[DCTOK02114EA.ct_Col_GoodsNameKana] = salesRsltListResultWork.BLGoodsHalfName;
                        }
                        // --- CHG 2009/02/06 速度UP対応------------------------------------------------------<<<<<
                    }
                }  // ADD 2010/05/13
                // --- ADD 2008/10/23 -----------------------------------------------------------------------------------<<<<<

                // --- DEL 2008/10/08 -------------------------------->>>>>
                //dr[DCTOK02114EA.ct_Col_SalesTimes] = salesRsltListResultWork.SalesTimes; // 当月売上回数
                //dr[DCTOK02114EA.ct_Col_TotalSalesCount] = salesRsltListResultWork.TotalSalesCount; // 当月売上数計
                //dr[DCTOK02114EA.ct_Col_SalesTotalTaxExc] = salesRsltListResultWork.SalesTotalTaxExc; // 当月売上伝票合計（税抜き）
                //dr[DCTOK02114EA.ct_Col_SalesRetGoodsPrice] = salesRsltListResultWork.SalesRetGoodsPrice; // 当月返品額
                //dr[DCTOK02114EA.ct_Col_DiscountPrice] = salesRsltListResultWork.DiscountPrice; // 当月値引金額
                //dr[DCTOK02114EA.ct_Col_GrossProfit] = salesRsltListResultWork.GrossProfit; // 当月粗利金額
                //dr[DCTOK02114EA.ct_Col_TtlSalesTimes] = salesRsltListResultWork.TtlSalesTimes; // 当期売上回数
                //dr[DCTOK02114EA.ct_Col_TtlTotalSalesCount] = salesRsltListResultWork.TtlTotalSalesCount; // 当期売上数計
                //dr[DCTOK02114EA.ct_Col_TtlSalesTotalTaxExc] = salesRsltListResultWork.TtlSalesTotalTaxExc; // 当期売上伝票合計（税抜き）
                //dr[DCTOK02114EA.ct_Col_TtlSalesRetGoodsPrice] = salesRsltListResultWork.TtlSalesRetGoodsPrice; // 当期返品額
                //dr[DCTOK02114EA.ct_Col_TtlDiscountPrice] = salesRsltListResultWork.TtlDiscountPrice; // 当期値引金額
                //dr[DCTOK02114EA.ct_Col_TtlGrossProfit] = salesRsltListResultWork.TtlGrossProfit; // 当期粗利金額
                //dr[DCTOK02114EA.ct_Col_SalesPrice] = 0;         // 当月純売上金額 (←別途算出)
                //dr[DCTOK02114EA.ct_Col_GrossProfitRate] = 0;    // 当月粗利率     (←別途算出)
                //dr[DCTOK02114EA.ct_Col_TtlSalesPrice] = 0;      // 当期純売上金額 (←別途算出)
                //dr[DCTOK02114EA.ct_Col_TtlGrossProfitRate] = 0; // 当期粗利率     (←別途算出)
                // --- DEL 2008/10/08 --------------------------------<<<<<
                // --- ADD 2008/10/08 -------------------------------->>>>>
                dr[DCTOK02114EA.ct_Col_MonthTotalSalesCount] = salesRsltListResultWork.MonthTotalSalesCount; // 当月出荷額
                dr[DCTOK02114EA.ct_Col_MonthSalesMoney] = salesRsltListResultWork.MonthSalesMoney; // 当月売上額
                dr[DCTOK02114EA.ct_Col_MonthSalesRetGoodsPrice] = salesRsltListResultWork.MonthSalesRetGoodsPrice; // 当月返品額
                dr[DCTOK02114EA.ct_Col_MonthDiscountPrice] = salesRsltListResultWork.MonthDiscountPrice; // 当月値引額
                dr[DCTOK02114EA.ct_Col_MonthGrossProfit] = salesRsltListResultWork.MonthGrossProfit; // 当月粗利額

                dr[DCTOK02114EA.ct_Col_AnnualTotalSalesCount] = salesRsltListResultWork.AnnualTotalSalesCount; // 当期出荷額
                dr[DCTOK02114EA.ct_Col_AnnualSalesMoney] = salesRsltListResultWork.AnnualSalesMoney; // 当期売上額
                dr[DCTOK02114EA.ct_Col_AnnualSalesRetGoodsPrice] = salesRsltListResultWork.AnnualSalesRetGoodsPrice; // 当期返品額
                dr[DCTOK02114EA.ct_Col_AnnualDiscountPrice] = salesRsltListResultWork.AnnualDiscountPrice; // 当期値引額
                dr[DCTOK02114EA.ct_Col_AnnualGrossProfit] = salesRsltListResultWork.AnnualGrossProfit; // 当期粗利額
                // --- ADD 2008/10/08 --------------------------------<<<<<
                #endregion

                // 金額・率の計算とセット
                SetPriceAndRate(ref dr);

                // --- DEL 2008/10/08 -------------------------------->>>>>
                //// (金額単位適用前の元の金額を内部保持)
                //dr[DCTOK02114EA.ct_Col_SalesTotalTaxExcOrg] = dr[DCTOK02114EA.ct_Col_SalesTotalTaxExc]; // 当月売上伝票合計（税抜き）
                //dr[DCTOK02114EA.ct_Col_SalesRetGoodsPriceOrg] = dr[DCTOK02114EA.ct_Col_SalesRetGoodsPrice]; // 当月返品額
                //dr[DCTOK02114EA.ct_Col_DiscountPriceOrg] = dr[DCTOK02114EA.ct_Col_DiscountPrice]; // 当月値引金額
                //dr[DCTOK02114EA.ct_Col_GrossProfitOrg] = dr[DCTOK02114EA.ct_Col_GrossProfit]; // 当月粗利金額
                //dr[DCTOK02114EA.ct_Col_SalesPriceOrg] = dr[DCTOK02114EA.ct_Col_SalesPrice];         // 当月純売上金額
                //dr[DCTOK02114EA.ct_Col_TtlSalesTotalTaxExcOrg] = dr[DCTOK02114EA.ct_Col_TtlSalesTotalTaxExc]; // 当期売上伝票合計（税抜き）
                //dr[DCTOK02114EA.ct_Col_TtlSalesRetGoodsPriceOrg] = dr[DCTOK02114EA.ct_Col_TtlSalesRetGoodsPrice]; // 当期返品額
                //dr[DCTOK02114EA.ct_Col_TtlDiscountPriceOrg] = dr[DCTOK02114EA.ct_Col_TtlDiscountPrice]; // 当期値引金額
                //dr[DCTOK02114EA.ct_Col_TtlGrossProfitOrg] = dr[DCTOK02114EA.ct_Col_TtlGrossProfit]; // 当期粗利金額
                //dr[DCTOK02114EA.ct_Col_TtlSalesPriceOrg] = dr[DCTOK02114EA.ct_Col_TtlSalesPrice];      // 当期純売上金額
                // --- DEL 2008/10/08 --------------------------------<<<<<

                dr[DCTOK02114EA.ct_Col_MonthGrossProfitOrg] = dr[DCTOK02114EA.ct_Col_MonthGrossProfit]; // 当月粗利金額 // ADD 2008/10/08
                dr[DCTOK02114EA.ct_Col_AnnualGrossProfitOrg] = dr[DCTOK02114EA.ct_Col_AnnualGrossProfit]; // 当期粗利金額 // ADD 2008/10/08
  
                
                // 2009/11/05 Add >>>
                // 当月，当期共に出荷数・純売上金額・粗利額が0ならContinue
                if (salesRsltListResultWork.MonthTotalSalesCount == 0 &
                    salesRsltListResultWork.MonthSalesMoney + salesRsltListResultWork.MonthSalesRetGoodsPrice + salesRsltListResultWork.MonthDiscountPrice == 0 &
                    salesRsltListResultWork.MonthGrossProfit == 0 &
                    salesRsltListResultWork.AnnualTotalSalesCount == 0 &
                    salesRsltListResultWork.AnnualSalesMoney + salesRsltListResultWork.AnnualSalesRetGoodsPrice + salesRsltListResultWork.AnnualDiscountPrice == 0 &
                    salesRsltListResultWork.AnnualGrossProfit == 0
                    )
                    continue;
                // 2009/11/05 Add <<<


                // 金額単位の適用
                ReflectPriceUnit(salesRsltListCndtn, ref dr);

                // TableにAdd
                this._stockManagementListDt.Rows.Add(dr);
            }

            // DataView作成
            this._stockManagementListDataView = new DataView(this._stockManagementListDt, "", GetSortOrder(salesRsltListCndtn), DataViewRowState.CurrentRows);
        }
        /// <summary>
        /// 金額・率　計算処理
        /// </summary>
        private void SetPriceAndRate(ref DataRow row)
        {
            //----------------------------------------------------------
            // 当月
            //----------------------------------------------------------

            // 純売上 (売上-返品)
            // --- DEL 2008/10/08 -------------------------------->>>>>
            //Int64 salesPrice = (Int64)row[DCTOK02114EA.ct_Col_SalesTotalTaxExc]
            //                   - (Int64)row[DCTOK02114EA.ct_Col_SalesRetGoodsPrice];
            //                   //- (Int64)row[DCTOK02114EA.ct_Col_DiscountPrice];// 値引を引いた金額が「売上」に格納されているので減算不要
            //row[DCTOK02114EA.ct_Col_SalesPrice] = salesPrice;
            // --- DEL 2008/10/08 --------------------------------<<<<<
            // --- ADD 2008/10/08 -------------------------------->>>>>
            // 純売上 (売上 + 返品額 + 値引額)
            Int64 salesPrice = (Int64)row[DCTOK02114EA.ct_Col_MonthSalesMoney]
                                + (Int64)row[DCTOK02114EA.ct_Col_MonthSalesRetGoodsPrice]
                                + (Int64)row[DCTOK02114EA.ct_Col_MonthDiscountPrice];

            row[DCTOK02114EA.ct_Col_MonthPureSalesMoney] = salesPrice;
            row[DCTOK02114EA.ct_Col_MonthPureSalesMoneyOrg] = salesPrice;

            // 粗利率 (粗利 / 純売上 * 100(%))
            decimal grossProfitRate;
            if ((Int64)row[DCTOK02114EA.ct_Col_MonthGrossProfit] != 0 && salesPrice != 0)
            {
                grossProfitRate = (decimal)((Int64)row[DCTOK02114EA.ct_Col_MonthGrossProfit]) / (decimal)salesPrice * 100;
            }
            else
            {
                grossProfitRate = 0;
            }

            row[DCTOK02114EA.ct_Col_MonthGrossProfitRate] = (double)grossProfitRate;
            // --- ADD 2008/10/08 --------------------------------<<<<<

            //----------------------------------------------------------
            // 当期
            //----------------------------------------------------------

            // 純売上 (売上-返品)
            // --- DEL 2008/10/08 -------------------------------->>>>>
            //Int64 ttlSalesPrice = (Int64)row[DCTOK02114EA.ct_Col_TtlSalesTotalTaxExc]
            //                      - (Int64)row[DCTOK02114EA.ct_Col_TtlSalesRetGoodsPrice];
            //                      //- (Int64)row[DCTOK02114EA.ct_Col_TtlDiscountPrice];// 値引を引いた金額が「売上」に格納されているので減算不要
            //row[DCTOK02114EA.ct_Col_TtlSalesPrice] = ttlSalesPrice;
            // --- DEL 2008/10/08 --------------------------------<<<<<
            // --- ADD 2008/10/08 -------------------------------->>>>>
            // 純売上 (売上 + 返品額 + 値引額)
            Int64 ttlSalesPrice = (Int64)row[DCTOK02114EA.ct_Col_AnnualSalesMoney]
                                + (Int64)row[DCTOK02114EA.ct_Col_AnnualSalesRetGoodsPrice]
                                + (Int64)row[DCTOK02114EA.ct_Col_AnnualDiscountPrice];

            row[DCTOK02114EA.ct_Col_AnnualPureSalesMoney] = ttlSalesPrice;
            row[DCTOK02114EA.ct_Col_AnnualPureSalesMoneyOrg] = ttlSalesPrice;

            // 粗利率 (粗利 / 純売上 * 100(%))
            decimal ttlGrossProfitRate;
            if ((Int64)row[DCTOK02114EA.ct_Col_AnnualGrossProfit] != 0 && ttlSalesPrice != 0)
            {
                ttlGrossProfitRate = (decimal)((Int64)row[DCTOK02114EA.ct_Col_AnnualGrossProfit]) / (decimal)ttlSalesPrice * 100;
            }
            else
            {
                ttlGrossProfitRate = 0;
            }
            row[DCTOK02114EA.ct_Col_AnnualGrossProfitRate] = (double)ttlGrossProfitRate;
            // --- ADD 2008/10/08 --------------------------------<<<<<
        }
        /// <summary>
        /// 金額単位　適用処理
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="row"></param>
        /// <remarks>
        /// <br>各種金額項目に金額単位によるまるめ処理を適用します。（切り捨て固定）</br>
        /// <br>※注意：本メソッド実行前に全ての金額計算・率計算が終了している事を前提とします。</br>
        /// </remarks>
        private void ReflectPriceUnit(SalesRsltListCndtn salesRsltListCndtn, ref DataRow row)
        {
            int priceUnit = 1;

            if (salesRsltListCndtn.PriceUnitDiv == SalesRsltListCndtn.PriceUnitDivState.One)
            {
                // 処理は不要
                return;
            }
            else if (salesRsltListCndtn.PriceUnitDiv == SalesRsltListCndtn.PriceUnitDivState.Thousand)
            {
                // 千円単位
                priceUnit = 1000;
            }

            // 各種金額項目を丸める (金額 / 金額単位)
            // --- DEL 2008/10/08 -------------------------------->>>>>
            //row[DCTOK02114EA.ct_Col_SalesTotalTaxExc] = (Int64)( (decimal)((Int64)row[DCTOK02114EA.ct_Col_SalesTotalTaxExc]) / (decimal)priceUnit );        // 売上
            //row[DCTOK02114EA.ct_Col_SalesRetGoodsPrice] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_SalesRetGoodsPrice] ) / (decimal)priceUnit );  // 返品
            //row[DCTOK02114EA.ct_Col_DiscountPrice] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_DiscountPrice] ) / (decimal)priceUnit );            // 値引
            //row[DCTOK02114EA.ct_Col_GrossProfit] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_GrossProfit] ) / (decimal)priceUnit );                // 粗利
            //row[DCTOK02114EA.ct_Col_SalesPrice] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_SalesPrice] ) / (decimal)priceUnit );                  // 純売上

            //row[DCTOK02114EA.ct_Col_TtlSalesTotalTaxExc] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_TtlSalesTotalTaxExc] ) / (decimal)priceUnit );        // 売上
            //row[DCTOK02114EA.ct_Col_TtlSalesRetGoodsPrice] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_TtlSalesRetGoodsPrice] ) / (decimal)priceUnit );  // 返品
            //row[DCTOK02114EA.ct_Col_TtlDiscountPrice] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_TtlDiscountPrice] ) / (decimal)priceUnit );            // 値引
            //row[DCTOK02114EA.ct_Col_TtlGrossProfit] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_TtlGrossProfit] ) / (decimal)priceUnit );                // 粗利
            //row[DCTOK02114EA.ct_Col_TtlSalesPrice] = (Int64)( (decimal)( (Int64)row[DCTOK02114EA.ct_Col_TtlSalesPrice] ) / (decimal)priceUnit );                  // 純売上
            // --- DEL 2008/10/08 --------------------------------<<<<<
            // --- ADD 2008/10/08 -------------------------------->>>>>
            row[DCTOK02114EA.ct_Col_MonthSalesMoney] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_MonthSalesMoney]) / (decimal)priceUnit); // 当月売上額
            row[DCTOK02114EA.ct_Col_MonthSalesRetGoodsPrice] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_MonthSalesRetGoodsPrice]) / (decimal)priceUnit); // 当月返品額
            row[DCTOK02114EA.ct_Col_MonthDiscountPrice] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_MonthDiscountPrice]) / (decimal)priceUnit); // 当月値引額
            row[DCTOK02114EA.ct_Col_MonthGrossProfit] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_MonthGrossProfit]) / (decimal)priceUnit); // 当月粗利額
            row[DCTOK02114EA.ct_Col_MonthPureSalesMoney] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_MonthPureSalesMoney]) / (decimal)priceUnit); // 当月純売上額

            row[DCTOK02114EA.ct_Col_AnnualSalesMoney] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_AnnualSalesMoney]) / (decimal)priceUnit); // 当期売上額
            row[DCTOK02114EA.ct_Col_AnnualSalesRetGoodsPrice] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_AnnualSalesRetGoodsPrice]) / (decimal)priceUnit); // 当期売上額
            row[DCTOK02114EA.ct_Col_AnnualDiscountPrice] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_AnnualDiscountPrice]) / (decimal)priceUnit); // 当期売上額
            row[DCTOK02114EA.ct_Col_AnnualGrossProfit] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_AnnualGrossProfit]) / (decimal)priceUnit); // 当期売上額
            row[DCTOK02114EA.ct_Col_AnnualPureSalesMoney] = (Int64)((decimal)((Int64)row[DCTOK02114EA.ct_Col_AnnualPureSalesMoney]) / (decimal)priceUnit); // 当期純売上額
            // --- ADD 2008/10/08 --------------------------------<<<<<
        }
        /// <summary>
        /// 拠点ガイド名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点ガイド名称</returns>
        private string GetSectionGuideNm(string sectionCode)
        {
            if (stc_SectionDic.ContainsKey(sectionCode))
            {
                return stc_SectionDic[sectionCode].SectionGuideNm;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region ◎ ソート順作成
        /// <summary>
        /// ソート順作成
        /// </summary>
        /// <returns>ソート文字列</returns>
        private string GetSortOrder(SalesRsltListCndtn salesRsltListCndtn)
        {
            StringBuilder strSortOrder = new StringBuilder();


            // 拠点別・全社集計により変動、倉庫別も処理しない
            //if ( salesRsltListCndtn.GroupBySectionDiv == SalesRsltListCndtn.GroupBySectionDivState.BySection ) // DEL 2008/10/08
            if (salesRsltListCndtn.TotalType != SalesRsltListCndtn.TotalTypeState.EachWareHouse
                && salesRsltListCndtn.TtlType == SalesRsltListCndtn.TtlTypeState.BySection) // ADD 2008/10/08
            {
                // 拠点コード
                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_AddUpSecCode));
            }


            // 印刷タイプ別のソート順設定
            switch (salesRsltListCndtn.TotalType)
            {
                // 得意先別
                case SalesRsltListCndtn.TotalTypeState.EachCustomer:
                    {
                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsLGroup
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMaker
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.Customer)
                        {
                            strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_CustomerCode));
                        }


                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        // --- DEL 2008/10/08 -------------------------------->>>>>
                        //// 得意先
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_CustomerCode ) );
                        //// メーカー
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_GoodsMakerCd ) );
                        //// BL商品コード
                        //strSortOrder.Append( string.Format( "{0}", DCTOK02114EA.ct_Col_BLGoodsCode ) );
                        // --- DEL 2008/10/08 --------------------------------<<<<<
                    }
                    break;
                // --- ADD 2009/04/11 -------------------------------->>>>>
                // 仕入別
                case SalesRsltListCndtn.TotalTypeState.EachSupplier:
                    {
                        if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsLGroup
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMaker
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.Supplier)
                        {
                            strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_SupplierCode));
                        }
                    }
                    break;
                // --- ADD 2009/04/11 --------------------------------<<<<<
                // 担当者別
                case SalesRsltListCndtn.TotalTypeState.EachEmployee:
                    {
                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsLGroup
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMaker
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.Employee)
                        {
                            strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_EmployeeCode));
                        }
                        // --- ADD 2008/10/08 --------------------------------<<<<<
                        // --- DEL 2008/10/08 -------------------------------->>>>>
                        //// 担当者
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_EmployeeCode ) );
                        //// メーカー
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_GoodsMakerCd ) );
                        //// BL商品コード
                        //strSortOrder.Append( string.Format( "{0}", DCTOK02114EA.ct_Col_BLGoodsCode ) );
                        // --- DEL 2008/10/08 --------------------------------<<<<<
                    }
                    break;
                // 商品別
                case SalesRsltListCndtn.TotalTypeState.EachGoods:
                    {
                        // --- DEL 2008/10/08 -------------------------------->>>>>
                        //// メーカー
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_GoodsMakerCd ) );
                        //// 商品区分グループ
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_LargeGoodsGanreCode ) );
                        //// 商品区分
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_MediumGoodsGanreCode ) );
                        //// 商品区分詳細
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_DetailGoodsGanreCode ) );
                        //// BL商品コード
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_BLGoodsCode ) );
                        //// 商品番号
                        //strSortOrder.Append( string.Format( "{0}", DCTOK02114EA.ct_Col_GoodsNo ) );
                        // --- DEL 2008/10/08 --------------------------------<<<<<
                    }
                    break;
                // 倉庫別
                case SalesRsltListCndtn.TotalTypeState.EachWareHouse:
                    {
                        // --- ADD 2008/10/08 -------------------------------->>>>>
                        if (salesRsltListCndtn.PrintType == SalesRsltListCndtn.PrintTypeState.SectionWarehouse)
                        {
                            if (salesRsltListCndtn.TtlType == SalesRsltListCndtn.TtlTypeState.BySection)
                            {
                                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_AddUpSecCode));
                            }


                            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsLGroup
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMaker
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.Warehouse)
                            {
                                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_WarehouseCode));
                            }
                        }
                        else if (salesRsltListCndtn.PrintType == SalesRsltListCndtn.PrintTypeState.WarehouseCustomer)
                        {

                            strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_WarehouseCode));

                            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsLGroup
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMaker
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.Customer)
                            {
                                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_CustomerCode));
                            }
                        }
                        else if (salesRsltListCndtn.PrintType == SalesRsltListCndtn.PrintTypeState.WarehouseSection)
                        {
                            strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_WarehouseCode));

                            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsLGroup
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMaker
                                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.Section)
                            {
                                if (salesRsltListCndtn.TtlType == SalesRsltListCndtn.TtlTypeState.BySection)
                                {
                                    strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_AddUpSecCode));
                                }
                            }
                        }

                        break;
                        // --- ADD 2008/10/08 --------------------------------<<<<< 
                    }
                // (想定外)
                default:
                    // --- DEL 2008/10/08 -------------------------------->>>>>
                    //// メーカー
                    //strSortOrder.Append( string.Format( "{0},", DCTOK02114EA.ct_Col_GoodsMakerCd ) );
                    //// 商品番号
                    //strSortOrder.Append( string.Format( "{0}", DCTOK02114EA.ct_Col_GoodsNo ) );
                    // --- DEL 2008/10/08 --------------------------------<<<<<
                    break;
            }

            // --- ADD 2008/10/08 -------------------------------->>>>>
            //　メーカー以下は共通
            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsLGroup
                            || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMaker)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_GoodsMakerCd));
            }

            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsLGroup)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_GoodsLGroup));
            }

            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoodsMGroup)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_GoodsMGroup));
            }

            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGroupCode)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_BLGroupCode));
            }

            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo
                || salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.BLGoodsCode)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_BLGoodsCode));
            }

            if (salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02114EA.ct_Col_GoodsNo));
            }

            // 余分な"," を削除
            if (strSortOrder.Length != 0) // ADD 2008/12/05
            {
                strSortOrder.Remove(strSortOrder.Length - 1, 1);
            }
            // --- ADD 2008/10/08 --------------------------------<<<<<

            return strSortOrder.ToString();
        }
        #endregion

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
        /// <br>Programmer : 22018 kubo</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

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

        #region テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            //SalesRsltListResultWork param1 = new SalesRsltListResultWork();

            //param1.AddUpSecCode = "01";
            //param1.CompanyName1 = "拠点名称は最大桁１桁";
            //param1.GoodsMakerCd = 1234;
            //param1.MakerShortName = "メーカーは最大１０桁";
            //param1.GoodsLGroup = 1234;
            //param1.GoodsLGroupName = "商品大分類は最低１桁";
            //param1.GoodsMGroup = 1234;
            //param1.GoodsMGroupName = "商品中分類は最低１桁";
            //param1.BLGroupCode = 1234;
            //param1.BLGroupKanaName = "0BLｸﾞﾙｰﾌﾟｺｰﾄﾞﾊﾊﾝｶｸｹﾀ";
            //param1.BLGoodsCode = 1234;
            //param1.BLGoodsHalfName = "0BLｺｰﾄﾞﾊﾊﾝｶｸ20ｹﾀﾃﾞｹﾀ";
            //param1.GoodsNo = "111112222233333444445555";
            //param1.GoodsNameKana = "12345678901234567890";
            //param1.CustomerCode = 12345678;
            //param1.CustomerSnm = "得意先名称は最大２０桁かな４５６７８９桁";
            //param1.EmployeeCode = "1234";
            //param1.Name = "従業員名称は最大１桁";
            //param1.WarehouseCode = "123456";
            //param1.WarehouseName = "倉庫名称は最大１０桁";

            //param1.MonthTotalSalesCount = 123456789;
            //param1.MonthSalesMoney = 200000000;
            //param1.MonthSalesRetGoodsPrice = 0;
            //param1.MonthDiscountPrice = 0;
            //param1.MonthGrossProfit = 100000000;

            //param1.AnnualTotalSalesCount = 123456789;
            //param1.AnnualSalesMoney = 400000000;
            //param1.AnnualSalesRetGoodsPrice = 0;
            //param1.AnnualDiscountPrice = 0;
            //param1.AnnualGrossProfit = 200000000;

            //paramlist.Add(param1);

            SalesRsltListResultWork param2 = new SalesRsltListResultWork();

            param2.AddUpSecCode = "";
            param2.CompanyName1 = "";
            param2.GoodsMakerCd = 0;
            param2.MakerShortName = "";
            param2.GoodsLGroup = 0;
            param2.GoodsLGroupName = "";
            param2.GoodsMGroup = 0;
            param2.GoodsMGroupName = "";
            param2.BLGroupCode = 0;
            param2.BLGroupKanaName = "";
            param2.BLGoodsCode = 0;
            param2.BLGoodsHalfName = "";
            param2.GoodsNo = "";
            param2.GoodsNameKana = "";
            param2.CustomerCode = 0;
            param2.CustomerSnm = "";
            param2.EmployeeCode = "";
            param2.Name = "";
            param2.WarehouseCode = "";
            param2.WarehouseName = "";

            param2.MonthTotalSalesCount = 0;
            param2.MonthSalesMoney = 0;
            param2.MonthSalesRetGoodsPrice = 0;
            param2.MonthDiscountPrice = 0;
            param2.MonthGrossProfit = 0;

            param2.AnnualTotalSalesCount = 0;
            param2.AnnualSalesMoney = 0;
            param2.AnnualSalesRetGoodsPrice = 0;
            param2.AnnualDiscountPrice = 0;
            param2.AnnualGrossProfit = 0;

            paramlist.Add(param2);

            retList = (object)paramlist;

            return 0;
        }
        #endregion

        // --- ADD 2008/10/23 ------------------------------------------------->>>>>
        /// <summary>
        /// 終了コード取得処理(値が無い場合はALL9で埋める)
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="length">桁数</param>
        /// <returns></returns>
        private int GetEndCode(int value, int length)
        {
            if ((value == 0) || (string.IsNullOrEmpty(value.ToString())))
            {
                return Int32.Parse(new string('9', (length)));
            }
            else
            {
                return value;
            }
        }
        private string GetEndCode(string value, int length)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new string('9', (length));
            }
            else
            {
                return value;
            }
        }
        // --- ADD 2008/10/23 -------------------------------------------------<<<<<
        #endregion ■ Private Method
    }
}
