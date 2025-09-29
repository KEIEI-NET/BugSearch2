//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入分析表
// プログラム概要   : 仕入分析表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/11/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/01/30  修正内容 : 在庫額の計算を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【13136】残案件No.19 端数処理
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入分析表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 仕入分析表使用するデータを取得する。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.10</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2009.01.30</br>
    /// <br>             : 在庫額の計算を修正</br>
    /// <br>             : </br>
    /// </remarks>
    public class SlipHistAnalyzeAcs
    {
        #region ■ コンストラクタ
        /// <summary>
        /// 仕入分析表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入分析表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.10</br>
		/// </remarks>
        public SlipHistAnalyzeAcs()
		{
            this._iSlipHistAnalyzeResultWorkDB = (ISlipHistAnalyzeResultWorkDB)MediationSlipHistAnalyzeResultWorkDB.GetSlipHistAnalyzeResultWorkDB();
		}

        /// <summary>
        /// 仕入分析表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入分析表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.10</br>
		/// </remarks>
        static SlipHistAnalyzeAcs()
		{
            stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs      = new SecInfoAcs(1);    // 拠点アクセスクラス
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // 拠点Dictionary

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // 既存でなければ
                if ( !stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) )
                {
                    // 追加
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
        }
        #endregion 

        #region ■ Static変数
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス

        private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        #endregion

        #region ■ Private変数
        ISlipHistAnalyzeResultWorkDB _iSlipHistAnalyzeResultWorkDB;

        private DataTable _slipHistAnalyzeDt;			// 印刷DataTable
        private DataView _slipHistAnalyzeDv;	        // 印刷DataView

        #endregion

        #region ■ Publicプロパティ
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView SlipHistAnalyzeDataView
        {
            get { return this._slipHistAnalyzeDv; }
        }
        #endregion

        #region ■ Publicメソッド
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="salesRsltListCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note         : 印刷するデータを取得する。</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.10</br>
        /// </remarks>
        public int SearchMain(SlipHistAnalyzeParam slipHistAnalyzeParam, out string errMsg)
        {
            return this.SearchProc(slipHistAnalyzeParam, out errMsg);
        }

        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
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

        #region ■ Privateメソッド
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.10</br>
        /// </remarks>
        private int SearchProc(SlipHistAnalyzeParam slipHistAnalyzeParam, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKOU02025EA.CreateDataTable(ref this._slipHistAnalyzeDt);

                SlipHistAnalyzeParamWork slipHistAnalyzeParamWork = new SlipHistAnalyzeParamWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevListCndtn(slipHistAnalyzeParam, out slipHistAnalyzeParamWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iSlipHistAnalyzeResultWorkDB.Search(out retWorkList, slipHistAnalyzeParamWork, 0, ConstantManagement.LogicalMode.GetData0);

                // テスト用
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevListData(slipHistAnalyzeParam, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "仕入分析表データの取得に失敗しました。";
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

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="salesRsltListCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       　: 画面抽出条件をリモート抽出条件へ展開する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.10</br>
        /// </remarks>
        private int DevListCndtn(SlipHistAnalyzeParam slipHistAnalyzeParam, out SlipHistAnalyzeParamWork slipHistAnalyzeParamWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            slipHistAnalyzeParamWork = new SlipHistAnalyzeParamWork();
            try
            {
                slipHistAnalyzeParamWork.EnterpriseCode = slipHistAnalyzeParam.EnterpriseCode;  // 企業コード

                // 抽出条件パラメータセット
                if (slipHistAnalyzeParam.SectionCodes.Length != 0)
                {
                    if (slipHistAnalyzeParam.IsSelectAllSection)
                    {
                        // 全社の時
                        slipHistAnalyzeParamWork.SectionCodes = null;
                    }
                    else
                    {
                        slipHistAnalyzeParamWork.SectionCodes = slipHistAnalyzeParam.SectionCodes;
                    }
                }
                else
                {
                    slipHistAnalyzeParamWork.SectionCodes = null;
                }

                slipHistAnalyzeParamWork.StSupplierCd = slipHistAnalyzeParam.StSupplierCd; // 開始仕入先コード
                if (slipHistAnalyzeParam.EdSupplierCd == 0) slipHistAnalyzeParamWork.EdSupplierCd = 999999;
                else slipHistAnalyzeParamWork.EdSupplierCd = slipHistAnalyzeParam.EdSupplierCd; // 終了仕入先コード
                slipHistAnalyzeParamWork.StAddUpYearMonth = slipHistAnalyzeParam.StAddUpYearMonth; // 開始年度
                slipHistAnalyzeParamWork.EdAddUpYearMonth = slipHistAnalyzeParam.EdAddUpYearMonth; // 終了年度
                slipHistAnalyzeParamWork.StAnnualAddUpYearMonth = slipHistAnalyzeParam.StAnnualAddUpYearMonth; // 開始計上年月
                slipHistAnalyzeParamWork.EdAnnualAddUpYearMonth = slipHistAnalyzeParam.EdAnnualAddUpYearMonth; // 終了計上年月
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <remarks>
        /// <br>Note       　: リモート抽出結果を帳票印字用DataTableへ展開する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.10</br>
        /// </remarks>
        private void DevListData(SlipHistAnalyzeParam slipHistAnalyzeParam, ArrayList resultWork)
        {
            // リモート抽出結果をリモート抽出結果用DataTableに展開
            DataRow dr;
            // 純仕入合計Dictionary
            // key:構成比単位 value：構成比単位毎の純仕入額合計
            string dicKey;
            Dictionary<string, long> pureTotalPriceSumDic = new Dictionary<string, long>(); ; // (当月)
            Dictionary<string, long> annualPureTotalPriceSumDic = new Dictionary<string, long>(); // (当期)

            foreach (SlipHistAnalyzeResultWork slipHistAnalyzeResultWork in resultWork)
            {
                dr = this._slipHistAnalyzeDt.NewRow();

                // 2009.03.02 30413 犬飼 返品・値引の符号を反転させる >>>>>>START
                // リモート抽出結果項目
                dr[PMKOU02025EA.ct_Col_AddUpSecCode] = slipHistAnalyzeResultWork.AddUpSecCode; // 計上拠点コード
                dr[PMKOU02025EA.ct_Col_SectionGuideSnm] = slipHistAnalyzeResultWork.SectionGuideSnm; // 拠点ガイド略称
                dr[PMKOU02025EA.ct_Col_SupplierCd] = slipHistAnalyzeResultWork.SupplierCd; // 仕入先コード
                dr[PMKOU02025EA.ct_Col_SupplierSnm] = slipHistAnalyzeResultWork.SupplierSnm; // 仕入先略称
                dr[PMKOU02025EA.ct_Col_TotalPrice] = slipHistAnalyzeResultWork.TotalPrice; // 仕入金額合計(当月)
                //dr[PMKOU02025EA.ct_Col_RetGoodsPrice] = slipHistAnalyzeResultWork.RetGoodsPrice; // 仕入返品額(当月)
                //dr[PMKOU02025EA.ct_Col_TotalDiscount] = slipHistAnalyzeResultWork.TotalDiscount; // 仕入値引計(当月)
                dr[PMKOU02025EA.ct_Col_RetGoodsPrice] = -(slipHistAnalyzeResultWork.RetGoodsPrice); // 仕入返品額(当月)
                dr[PMKOU02025EA.ct_Col_TotalDiscount] = -(slipHistAnalyzeResultWork.TotalDiscount); // 仕入値引計(当月)
                dr[PMKOU02025EA.ct_Col_TotalPriceStock] = slipHistAnalyzeResultWork.TotalPriceStock; // 仕入金額合計(当月在庫)
                dr[PMKOU02025EA.ct_Col_TotalPriceTotal] = slipHistAnalyzeResultWork.TotalPriceTotal; // 仕入金額合計(当月合計)
                dr[PMKOU02025EA.ct_Col_AnnualTotalPrice] = slipHistAnalyzeResultWork.AnnualTotalPrice; // 仕入金額合計(当期)
                //dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPrice] = slipHistAnalyzeResultWork.AnnualRetGoodsPrice; // 仕入返品額(当期)
                //dr[PMKOU02025EA.ct_Col_AnnualTotalDiscount] = slipHistAnalyzeResultWork.AnnualTotalDiscount; // 仕入値引計(当期)
                dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPrice] = -(slipHistAnalyzeResultWork.AnnualRetGoodsPrice); // 仕入返品額(当期)
                dr[PMKOU02025EA.ct_Col_AnnualTotalDiscount] = -(slipHistAnalyzeResultWork.AnnualTotalDiscount); // 仕入値引計(当期)
                dr[PMKOU02025EA.ct_Col_AnnualTotalPriceStock] = slipHistAnalyzeResultWork.AnnualTotalPriceStock; // 仕入金額合計(当期在庫)
                dr[PMKOU02025EA.ct_Col_AnnualTotalPriceTotal] = slipHistAnalyzeResultWork.AnnualTotalPriceTotal; // 仕入金額合計(当期合計)
                // 2009.03.02 30413 犬飼 返品・値引の符号を反転させる <<<<<<END
            
                // 当月項目
                dr[PMKOU02025EA.ct_Col_PureTotalPrice] = slipHistAnalyzeResultWork.TotalPrice 
                                                        + slipHistAnalyzeResultWork.RetGoodsPrice 
                                                        + slipHistAnalyzeResultWork.TotalDiscount; // 純仕入(当月)

                //dr[PMKOU02025EA.ct_Col_StockPrice] = slipHistAnalyzeResultWork.TotalPriceStock 
                //                                    + slipHistAnalyzeResultWork.RetGoodsPrice
                //                                    + slipHistAnalyzeResultWork.TotalDiscount; // 在庫額(当月) // DEL 2009/01/30
                dr[PMKOU02025EA.ct_Col_StockPrice] = slipHistAnalyzeResultWork.TotalPriceStock; // 在庫額(当月) // ADD 2009/01/30

                dr[PMKOU02025EA.ct_Col_OrderPrice] = slipHistAnalyzeResultWork.TotalPriceTotal 
                                                    - slipHistAnalyzeResultWork.TotalPriceStock; // 取寄額(当月)

                // 当期項目
                dr[PMKOU02025EA.ct_Col_AnnualPureTotalPrice] = slipHistAnalyzeResultWork.AnnualTotalPrice
                                                              + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                                                              + slipHistAnalyzeResultWork.AnnualTotalDiscount; // 純仕入(当期)

                //dr[PMKOU02025EA.ct_Col_AnnualStockPrice] = slipHistAnalyzeResultWork.AnnualTotalPriceStock
                //                                          + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                //                                          + slipHistAnalyzeResultWork.AnnualTotalDiscount; // 在庫額（当期） // DEL 2009/01/30
                dr[PMKOU02025EA.ct_Col_AnnualStockPrice] = slipHistAnalyzeResultWork.AnnualTotalPriceStock; // 在庫額（当期） // ADD 2009/01/30

                dr[PMKOU02025EA.ct_Col_AnnualOrderPrice] = slipHistAnalyzeResultWork.AnnualTotalPriceTotal
                                                          - slipHistAnalyzeResultWork.AnnualTotalPriceStock; // 取寄額（当期）

                // 2009.03.02 30413 犬飼 返品・値引の符号を反転させる >>>>>>START
                // 率計算用項目(金額単位を適用しない)
                dr[PMKOU02025EA.ct_Col_TotalPriceOrg] = slipHistAnalyzeResultWork.TotalPrice; // 仕入金額合計(当月)
                //dr[PMKOU02025EA.ct_Col_RetGoodsPriceOrg] = slipHistAnalyzeResultWork.RetGoodsPrice; // 仕入返品額(当月)
                //dr[PMKOU02025EA.ct_Col_TotalDiscountOrg] = slipHistAnalyzeResultWork.TotalDiscount; // 仕入値引計(当月)
                dr[PMKOU02025EA.ct_Col_RetGoodsPriceOrg] = -(slipHistAnalyzeResultWork.RetGoodsPrice); // 仕入返品額(当月)
                dr[PMKOU02025EA.ct_Col_TotalDiscountOrg] = -(slipHistAnalyzeResultWork.TotalDiscount); // 仕入値引計(当月)
                dr[PMKOU02025EA.ct_Col_AnnualTotalPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPrice; // 仕入金額合計(当期)
                //dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPriceOrg] = slipHistAnalyzeResultWork.AnnualRetGoodsPrice; // 仕入返品額(当期)
                //dr[PMKOU02025EA.ct_Col_AnnualTotalDiscountOrg] = slipHistAnalyzeResultWork.AnnualTotalDiscount; // 仕入値引計(当期)
                dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPriceOrg] = -(slipHistAnalyzeResultWork.AnnualRetGoodsPrice); // 仕入返品額(当期)
                dr[PMKOU02025EA.ct_Col_AnnualTotalDiscountOrg] = -(slipHistAnalyzeResultWork.AnnualTotalDiscount); // 仕入値引計(当期)
                // 2009.03.02 30413 犬飼 返品・値引の符号を反転させる <<<<<<END
            
                dr[PMKOU02025EA.ct_Col_PureTotalPriceOrg] = slipHistAnalyzeResultWork.TotalPrice
                                                        + slipHistAnalyzeResultWork.RetGoodsPrice
                                                        + slipHistAnalyzeResultWork.TotalDiscount; // 純仕入(当月)

                //dr[PMKOU02025EA.ct_Col_StockPriceOrg] = slipHistAnalyzeResultWork.TotalPriceStock
                //                                    + slipHistAnalyzeResultWork.RetGoodsPrice
                //                                    + slipHistAnalyzeResultWork.TotalDiscount; // 在庫額(当月) // DEL 2009/01/30
                dr[PMKOU02025EA.ct_Col_StockPriceOrg] = slipHistAnalyzeResultWork.TotalPriceStock; // 在庫額(当月) // ADD 2009/01/30

                dr[PMKOU02025EA.ct_Col_OrderPriceOrg] = slipHistAnalyzeResultWork.TotalPriceTotal
                                                    - slipHistAnalyzeResultWork.TotalPriceStock; // 取寄額(当月)

                dr[PMKOU02025EA.ct_Col_AnnualPureTotalPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPrice
                                                              + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                                                              + slipHistAnalyzeResultWork.AnnualTotalDiscount; // 純仕入(当期)

                //dr[PMKOU02025EA.ct_Col_AnnualStockPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPriceStock
                //                                          + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                //                                          + slipHistAnalyzeResultWork.AnnualTotalDiscount; // 在庫額（当期） // DEL 2009/01/30
                dr[PMKOU02025EA.ct_Col_AnnualStockPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPriceStock; // 在庫額（当期） // ADD 2009/01/30

                dr[PMKOU02025EA.ct_Col_AnnualOrderPriceOrg] = slipHistAnalyzeResultWork.AnnualTotalPriceTotal
                                                          - slipHistAnalyzeResultWork.AnnualTotalPriceStock; // 取寄額（当期）

                // 構成比単位用 純仕入合計
                if (slipHistAnalyzeParam.ConstUnitDiv == SlipHistAnalyzeParam.ConstUnitDivState.Total)
                {
                    // 総合計
                    dicKey = string.Empty;
                }
                else
                {
                    if (slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
                    {
                        dicKey = slipHistAnalyzeResultWork.AddUpSecCode;
                    }
                    else
                    {
                        dicKey = slipHistAnalyzeResultWork.SupplierCd.ToString();
                    }
                }

                // 当月
                if (pureTotalPriceSumDic.ContainsKey(dicKey))
                {
                    // 同キー値の場合加算
                    pureTotalPriceSumDic[dicKey] = pureTotalPriceSumDic[dicKey]
                                                        + slipHistAnalyzeResultWork.TotalPrice
                                                        + slipHistAnalyzeResultWork.RetGoodsPrice
                                                        + slipHistAnalyzeResultWork.TotalDiscount;
                }
                else
                {
                    // 新規追加
                    pureTotalPriceSumDic.Add(dicKey, slipHistAnalyzeResultWork.TotalPrice
                                                        + slipHistAnalyzeResultWork.RetGoodsPrice
                                                        + slipHistAnalyzeResultWork.TotalDiscount);
                }

                // 当期
                if (annualPureTotalPriceSumDic.ContainsKey(dicKey))
                {
                    annualPureTotalPriceSumDic[dicKey] = annualPureTotalPriceSumDic[dicKey]
                                                        + slipHistAnalyzeResultWork.AnnualTotalPrice
                                                        + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                                                        + slipHistAnalyzeResultWork.AnnualTotalDiscount;
                }
                else
                {
                    annualPureTotalPriceSumDic.Add(dicKey, slipHistAnalyzeResultWork.AnnualTotalPrice
                                                        + slipHistAnalyzeResultWork.AnnualRetGoodsPrice
                                                        + slipHistAnalyzeResultWork.AnnualTotalDiscount);
                }

                this._slipHistAnalyzeDt.Rows.Add(dr);
            }

            // 構成比単位
            foreach (DataRow workDr in this._slipHistAnalyzeDt.Rows)
            {
                if (slipHistAnalyzeParam.ConstUnitDiv == SlipHistAnalyzeParam.ConstUnitDivState.Total)
                {
                    workDr[PMKOU02025EA.ct_Col_PureTotalPriceSum] = pureTotalPriceSumDic[string.Empty];
                    workDr[PMKOU02025EA.ct_Col_AnnualPureTotalPriceSum] = annualPureTotalPriceSumDic[string.Empty];
                }
                else
                {
                    if (slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
                    {
                        workDr[PMKOU02025EA.ct_Col_PureTotalPriceSum] = pureTotalPriceSumDic[workDr[PMKOU02025EA.ct_Col_AddUpSecCode].ToString()];
                        workDr[PMKOU02025EA.ct_Col_AnnualPureTotalPriceSum] = annualPureTotalPriceSumDic[workDr[PMKOU02025EA.ct_Col_AddUpSecCode].ToString()];
                    }
                    else
                    {
                        workDr[PMKOU02025EA.ct_Col_PureTotalPriceSum] = pureTotalPriceSumDic[workDr[PMKOU02025EA.ct_Col_SupplierCd].ToString()];
                        workDr[PMKOU02025EA.ct_Col_AnnualPureTotalPriceSum] = annualPureTotalPriceSumDic[workDr[PMKOU02025EA.ct_Col_SupplierCd].ToString()];
                    }
                }
            }

            // 金額単位適用
            //this.SetMoneyUnit(slipHistAnalyzeParam);      // DEL 2009/04/13

            // DataView作成
            // 発行タイプによりソート
            this._slipHistAnalyzeDv = new DataView(this._slipHistAnalyzeDt, "", this.GetSortStr(slipHistAnalyzeParam), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// 金額単位適用
        /// </summary>
        /// <param name="slipHistAnalyzeParam"></param>
        private void SetMoneyUnit(SlipHistAnalyzeParam slipHistAnalyzeParam)
        {
            int moneyUnit = 1;

            if (slipHistAnalyzeParam.MoneyUnitDiv == SlipHistAnalyzeParam.MoneyUnitDivState.One)
            {
                // 処理は不要
                return;
            }
            else if (slipHistAnalyzeParam.MoneyUnitDiv == SlipHistAnalyzeParam.MoneyUnitDivState.Thousand)
            {
                // 千円単位
                moneyUnit = 1000;
            }

            foreach (DataRow dr in this._slipHistAnalyzeDt.Rows)
            {
                dr[PMKOU02025EA.ct_Col_TotalPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_TotalPrice]) / (decimal)moneyUnit); // 仕入金額合計(当月)
                dr[PMKOU02025EA.ct_Col_RetGoodsPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_RetGoodsPrice]) / (decimal)moneyUnit); // 仕入返品額(当月)
                dr[PMKOU02025EA.ct_Col_TotalDiscount] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_TotalDiscount]) / (decimal)moneyUnit); // 仕入値引計(当月)
                dr[PMKOU02025EA.ct_Col_PureTotalPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_PureTotalPrice]) / (decimal)moneyUnit); // 純仕入（当月）
                dr[PMKOU02025EA.ct_Col_StockPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_StockPrice]) / (decimal)moneyUnit); // 在庫額（当月）
                dr[PMKOU02025EA.ct_Col_OrderPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_OrderPrice]) / (decimal)moneyUnit); // 取寄額（当月）

                dr[PMKOU02025EA.ct_Col_AnnualTotalPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualTotalPrice]) / (decimal)moneyUnit); // 仕入金額合計(当期)
                dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualRetGoodsPrice]) / (decimal)moneyUnit); // 仕入返品額(当期)
                dr[PMKOU02025EA.ct_Col_AnnualTotalDiscount] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualTotalDiscount]) / (decimal)moneyUnit); // 仕入値引計(当期)
                dr[PMKOU02025EA.ct_Col_AnnualPureTotalPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualPureTotalPrice]) / (decimal)moneyUnit); // 純仕入（当期）
                dr[PMKOU02025EA.ct_Col_AnnualStockPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualStockPrice]) / (decimal)moneyUnit); // 在庫額（当期）
                dr[PMKOU02025EA.ct_Col_AnnualOrderPrice] = (Int64)((decimal)((Int64)dr[PMKOU02025EA.ct_Col_AnnualOrderPrice]) / (decimal)moneyUnit); // 取寄額（当期）
            }
        }

        /// <summary>
        /// ソート文字列取得
        /// </summary>
        /// <param name="slipHistAnalyzeParam"></param>
        /// <returns></returns>
        private string GetSortStr(SlipHistAnalyzeParam slipHistAnalyzeParam)
        {
            if (slipHistAnalyzeParam.PrintType == SlipHistAnalyzeParam.PrintTypeState.Section)
            {
                return PMKOU02025EA.ct_Col_AddUpSecCode + ", " + PMKOU02025EA.ct_Col_SupplierCd;
            }
            else
            {
                return PMKOU02025EA.ct_Col_SupplierCd + ", " + PMKOU02025EA.ct_Col_AddUpSecCode;
            }
        }

        #endregion

        #region テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            SlipHistAnalyzeResultWork param1 = new SlipHistAnalyzeResultWork();

            param1.AddUpSecCode = "1"; // 計上拠点コード
            param1.SectionGuideSnm = "拠点の最大桁数１０桁"; // 拠点ガイド略称
            param1.SupplierCd = 1; // 仕入先コード
            param1.SupplierSnm = "仕入先の最大桁１０桁"; // 仕入先略称
            param1.TotalPrice = 100; // 仕入金額合計(当月)
            param1.RetGoodsPrice = 10; // 仕入返品額(当月)
            param1.TotalDiscount = 20; // 仕入値引計(当月)
            param1.TotalPriceStock = 1000; // 仕入金額合計(当月在庫)
            param1.TotalPriceTotal = 200; // 仕入金額合計(当月合計)
            param1.AnnualTotalPrice = 1000; // 仕入金額合計(当期)
            param1.AnnualRetGoodsPrice = 30; // 仕入返品額(当期)
            param1.AnnualTotalDiscount = 20; // 仕入値引計(当期)
            param1.AnnualTotalPriceStock = 10000; // 仕入金額合計(当期在庫)
            param1.AnnualTotalPriceTotal = 2500; // 仕入金額合計(当期合計)

            paramlist.Add(param1);

            SlipHistAnalyzeResultWork param2 = new SlipHistAnalyzeResultWork();

            param2.AddUpSecCode = "2"; // 計上拠点コード
            param2.SectionGuideSnm = "拠点の最大桁数１０桁"; // 拠点ガイド略称
            param2.SupplierCd = 1; // 仕入先コード
            param2.SupplierSnm = "仕入先の最大桁１０桁"; // 仕入先略称
            param2.TotalPrice = 100; // 仕入金額合計(当月)
            param2.RetGoodsPrice = 10; // 仕入返品額(当月)
            param2.TotalDiscount = 20; // 仕入値引計(当月)
            param2.TotalPriceStock = 1000; // 仕入金額合計(当月在庫)
            param2.TotalPriceTotal = 200; // 仕入金額合計(当月合計)
            param2.AnnualTotalPrice = 1000; // 仕入金額合計(当期)
            param2.AnnualRetGoodsPrice = 30; // 仕入返品額(当期)
            param2.AnnualTotalDiscount = 20; // 仕入値引計(当期)
            param2.AnnualTotalPriceStock = 10000; // 仕入金額合計(当期在庫)
            param2.AnnualTotalPriceTotal = 2500; // 仕入金額合計(当期合計)
            
            paramlist.Add(param2);

            SlipHistAnalyzeResultWork param3 = new SlipHistAnalyzeResultWork();

            param3.AddUpSecCode = ""; // 計上拠点コード
            param3.SectionGuideSnm = ""; // 拠点ガイド略称
            param3.SupplierCd = 0; // 仕入先コード
            param3.SupplierSnm = ""; // 仕入先略称
            param3.TotalPrice = 0; // 仕入金額合計(当月)
            param3.RetGoodsPrice = 0; // 仕入返品額(当月)
            param3.TotalDiscount = 0; // 仕入値引計(当月)
            param3.TotalPriceStock = 0; // 仕入金額合計(当月在庫)
            param3.TotalPriceTotal = 0; // 仕入金額合計(当月合計)
            param3.AnnualTotalPrice = 0; // 仕入金額合計(当期)
            param3.AnnualRetGoodsPrice = 0; // 仕入返品額(当期)
            param3.AnnualTotalDiscount = 0; // 仕入値引計(当期)
            param3.AnnualTotalPriceStock = 0; // 仕入金額合計(当期在庫)
            param3.AnnualTotalPriceTotal = 0; // 仕入金額合計(当期合計)

            paramlist.Add(param3);

            retList = (object)paramlist;

            return 0;

        }
        #endregion
    }
}
