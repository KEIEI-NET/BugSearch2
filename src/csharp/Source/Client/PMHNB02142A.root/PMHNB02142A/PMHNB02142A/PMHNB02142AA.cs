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
    /// 出荷商品優良対応表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 出荷商品優良対応表で使用するデータを取得する。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.14</br>
    /// <br>Update Note  : 2008.12.12 30452 上野 俊治</br>
    /// <br>              ・2つめの優良品情報の粗利率計算時のデータ取得元を修正。</br>
    /// <br>Update Note  : 2008.12.16 30452 上野 俊治</br>
    /// <br>              ・商品マスタ検索結果のチェック時、企業コードの条件を削除。</br>
    /// <br>Update Note  : 2008.12.17 30452 上野 俊治</br>
    /// <br>              ・商品マスタ検索処理を修正。</br>
    /// <br>Update Note  : 2009.01.13 30452 上野 俊治</br>
    /// <br>              ・障害対応9687（優良品情報検索時、商品連結データ不足情報設定処理を追加）</br>
    /// <br>Update Note  : 2009.01.13 30452 上野 俊治</br>
    /// <br>              ・障害対応9544（リモートより拠点リストにない拠点コードが返る場合、</br>
    /// <br>              　印刷対象とするよう修正。取得出来ない項目は空白にする。）</br>
    /// <br>Update Note  : 2009.01.15 30452 上野 俊治</br>
    /// <br>              ・障害対応10088（率計算でプラスになるよう補正していた処理を削除）</br>
    /// <br>Update Note  : 2009.01.15 30452 上野 俊治</br>
    /// <br>              ・障害対応10098（在庫リストindex取得時、拠点コードの条件を削除）</br>
    /// <br>Update Note  : 2009.02.13 30452 上野 俊治</br>
    /// <br>              ・障害対応11281（商品マスタに存在しない場合も印字対象とするよう修正）</br>
    /// <br>Update Note  : 2009.02.16 30452 上野 俊治</br>
    /// <br>              ・障害対応11530（速度アップ対応）</br>
    /// <br>Update Note  : 2009.02.18 30452 上野 俊治</br>
    /// <br>              ・障害対応11281（純正品情報の不足情報取得処理追加）</br>
    /// <br>Update Note  : 2009/02/21 30452 上野 俊治</br>
    /// <br>              ・障害対応11281（グループコードはリモート抽出結果より取得するよう修正）</br>
    /// <br>Update Note  : 2012/04/09 李亜博</br>
    /// <br>              ・2012/05/24配信分 Redmine#29336 出荷商品優良対応表 印刷時にエラーが表示される 障害対応の修正</br>
    /// <br>Update Note  : 2014/12/16 劉超</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更</br>
    /// <br>Update Note  : 2015/03/05 劉超</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更 システム障害の対応(品番表示)</br>
    /// <br>Update Note  : 2015/04/07 呉軍</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更 システム障害№57価格表示不正の対応</br>
    /// <br>Update Note  : 2015/04/13 時シン</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             : Redmine#45436NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応</br>
    /// </remarks>
    public class ShipGdsPrimeListAsc
    {
        #region ■ コンストラクタ
		/// <summary>
        /// 出荷商品優良対応表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 出荷商品優良対応表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.14</br>
		/// </remarks>
		public ShipGdsPrimeListAsc()
		{
            this._iShipGdsPrimeListResultWorkDB = (IShipGdsPrimeListResultWorkDB)MediationShipGdsPrimeListResultWorkDB.GetShipGdsPrimeListResultWorkDB();

            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd(); // ADD 2009/02/16
            string loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(); // ADD 2009/02/16
            string msg;

            this._goodsAcs = new GoodsAcs(); // 商品マスタ
            this._goodsAcs.SearchInitial(enterpriseCode, loginSectionCode, out msg); // ADD 2009/02/16
            //this._joinPartsUAcs = new JoinPartsUAcs(); // 結合マスタ
		}

		/// <summary>
        /// 出荷商品優良対応表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 出荷商品優良対応表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.14</br>
		/// </remarks>
        static ShipGdsPrimeListAsc()
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
        IShipGdsPrimeListResultWorkDB _iShipGdsPrimeListResultWorkDB;

        private DataTable _shipGdsPrimeListDt; // リモート抽出結果保持DataTable
        private DataTable _printDt; // 印刷DataTable
        private DataView _printDv;	// 印刷DataView

        private GoodsAcs _goodsAcs; // 商品マスタ
        #endregion

        #region ■ Publicプロパティ
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView ShipGdsPrimeListDataView
        {
            get { return this._printDv; }
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
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.14</br>
        /// </remarks>
        public int SearchMain(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, out string errMsg)
        {
            return this.SearchProc(shipGdsPrimeListCndtn, out errMsg);
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
        /// 検索処理
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private int SearchProc(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            // 純正品情報取得(リモート検索、商品マスタ検索)
            status = this.SearchPureGoodsProc(shipGdsPrimeListCndtn, ref errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // 優良品情報取得(リモート検索、商品マスタ検索)
            this.GetPartsInfo(shipGdsPrimeListCndtn);

            // --- ADD 2009/01/08 -------------------------------->>>>>
            // 実績(純売上額、粗利額、在庫数量、取寄数量、価格)のない品番を除く
            this.RemoveNoResultGoodsRow();

            if (this._shipGdsPrimeListDt.Rows.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            // --- ADD 2009/01/08 --------------------------------<<<<<

            // 順位付設定 (結合区分も反映)
            this.SetOrder(shipGdsPrimeListCndtn, ref errMsg);
            
            if (this._shipGdsPrimeListDt.Rows.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // フィルタ、ソート処理 (順位フィルタ、印刷順ソート)
            this.FilterAndSort(shipGdsPrimeListCndtn);

            // 帳票印字用テーブル作成
            this.MakePrintTable(shipGdsPrimeListCndtn);

            // DataView作成
            this._printDv = new DataView(this._printDt, "", "", DataViewRowState.CurrentRows);

            return status;
        }

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.14</br>
        /// </remarks>
        private int SearchPureGoodsProc(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02145EA.CreateDataTable(ref this._shipGdsPrimeListDt);

                ShipGdsPrimeListCndtnWork shipGdsPrimeListCndtnWork = new ShipGdsPrimeListCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevListCndtn(shipGdsPrimeListCndtn, out shipGdsPrimeListCndtnWork, ref errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                // リモート検索(純正品)
                status = this._iShipGdsPrimeListResultWorkDB.Search(out retWorkList, shipGdsPrimeListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // テスト用
                //status = this.testProcPure(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevListData(shipGdsPrimeListCndtn, (ArrayList)retWorkList, ref errMsg);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "出荷商品優良対応表データの取得に失敗しました。";
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
        /// <br>Date         : 2008.11.14</br>
        /// <br>Update Note  : 2014/12/16 劉超</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更</br>
        /// </remarks>
        private int DevListCndtn(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, out ShipGdsPrimeListCndtnWork shipGdsPrimeListCndtnWork, ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            shipGdsPrimeListCndtnWork = new ShipGdsPrimeListCndtnWork();
            try
            {
                shipGdsPrimeListCndtnWork.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;  // 企業コード

                // 抽出条件パラメータセット
                if (shipGdsPrimeListCndtn.SectionCodes.Length != 0)
                {
                    if (shipGdsPrimeListCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        shipGdsPrimeListCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        shipGdsPrimeListCndtnWork.SectionCodes = shipGdsPrimeListCndtn.SectionCodes;
                    }
                }
                else
                {
                    shipGdsPrimeListCndtnWork.SectionCodes = null;
                }

                if (shipGdsPrimeListCndtn.PrintType == ShipGdsPrimeListCndtn.PrintTypeState.Month)
                {
                    shipGdsPrimeListCndtnWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AddUpYearMonth; // 開始対象年月
                    shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AddUpYearMonth; // 終了対象年月
                }
                else
                {
                    shipGdsPrimeListCndtnWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AnnualAddUpYearMonth; // 開始対象年月
                    shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AnnualAddUpYearMonth; // 終了対象年月
                }
                
                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                shipGdsPrimeListCndtnWork.GoodsNoTtlDiv = (int)shipGdsPrimeListCndtn.GoodsNoTtlDiv; // 品番集計区分
                if (shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    shipGdsPrimeListCndtnWork.GoodsNoShowDiv = (int)shipGdsPrimeListCndtn.GoodsNoShowDiv; // 品番表示区分
                }
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                
                shipGdsPrimeListCndtnWork.St_GoodsMakerCd = shipGdsPrimeListCndtn.St_GoodsMakerCd; // 開始メーカーコード
                if (shipGdsPrimeListCndtn.Ed_GoodsMakerCd == 0) shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = 99;
                else shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = shipGdsPrimeListCndtn.Ed_GoodsMakerCd; // 終了メーカーコード
                
                shipGdsPrimeListCndtnWork.St_GoodsLGroup = shipGdsPrimeListCndtn.St_GoodsLGroup; // 開始商品大分類コード
                if (shipGdsPrimeListCndtn.Ed_GoodsLGroup == 0) shipGdsPrimeListCndtnWork.Ed_GoodsLGroup = 9999;
                else shipGdsPrimeListCndtnWork.Ed_GoodsLGroup = shipGdsPrimeListCndtn.Ed_GoodsLGroup; // 終了商品大分類コード

                shipGdsPrimeListCndtnWork.St_GoodsMGroup = shipGdsPrimeListCndtn.St_GoodsMGroup; // 開始商品中分類コード
                if (shipGdsPrimeListCndtn.Ed_GoodsMGroup == 0) shipGdsPrimeListCndtnWork.Ed_GoodsMGroup = 9999;
                else shipGdsPrimeListCndtnWork.Ed_GoodsMGroup = shipGdsPrimeListCndtn.Ed_GoodsMGroup; // 終了商品中分類コード
                
                shipGdsPrimeListCndtnWork.St_BLGroupCode = shipGdsPrimeListCndtn.St_BLGroupCode; // 開始グループコード
                if (shipGdsPrimeListCndtn.Ed_BLGroupCode == 0) shipGdsPrimeListCndtnWork.Ed_BLGroupCode = 99999;
                else shipGdsPrimeListCndtnWork.Ed_BLGroupCode = shipGdsPrimeListCndtn.Ed_BLGroupCode; // 終了グループコード

                shipGdsPrimeListCndtnWork.St_BLGoodsCode = shipGdsPrimeListCndtn.St_BLGoodsCode; // 開始ＢＬコード
                if (shipGdsPrimeListCndtn.Ed_BLGoodsCode == 0) shipGdsPrimeListCndtnWork.Ed_BLGoodsCode = 99999;
                else shipGdsPrimeListCndtnWork.Ed_BLGoodsCode = shipGdsPrimeListCndtn.Ed_BLGoodsCode; // 終了ＢＬコード

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
        /// <br>Date         : 2008.11.14</br>
        /// </remarks>
        private void DevListData(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, ArrayList resultWork, ref string errMsg)
        {
            // リモート抽出結果をリモート抽出結果用DataTable(PMHNB02145EA)に展開
            DataRow dr;

            foreach (ShipGdsPrimeListResultWork shipGdsPrimeListResultWork in resultWork)
            {
                dr = this._shipGdsPrimeListDt.NewRow();

                dr[PMHNB02145EA.ct_Col_EnterpriseCode] = shipGdsPrimeListResultWork.EnterpriseCode; // 企業コード
                dr[PMHNB02145EA.ct_Col_AddUpSecCode] = shipGdsPrimeListResultWork.AddUpSecCode; // 計上拠点コード
                dr[PMHNB02145EA.ct_Col_SectionGuideSnm] = shipGdsPrimeListResultWork.SectionGuideSnm; // 拠点ガイド名称
                dr[PMHNB02145EA.ct_Col_GoodsMakerCd] = shipGdsPrimeListResultWork.GoodsMakerCd; // メーカーコード
                dr[PMHNB02145EA.ct_Col_GoodsNo] = shipGdsPrimeListResultWork.GoodsNo; // 商品番号
                dr[PMHNB02145EA.ct_Col_St_SalesTimes] = shipGdsPrimeListResultWork.St_SalesTimes; // 売上回数(在庫)
                dr[PMHNB02145EA.ct_Col_St_TotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount; // 売上数計(在庫)
                dr[PMHNB02145EA.ct_Col_St_SalesMoney] = shipGdsPrimeListResultWork.St_SalesMoney; // 売上金額(在庫)
                dr[PMHNB02145EA.ct_Col_St_SalesRetGoodsPrice] = shipGdsPrimeListResultWork.St_SalesRetGoodsPrice; // 返品額(在庫)
                dr[PMHNB02145EA.ct_Col_St_DiscountPrice] = shipGdsPrimeListResultWork.St_DiscountPrice; // 値引金額(在庫)
                dr[PMHNB02145EA.ct_Col_St_GrossProfit] = shipGdsPrimeListResultWork.St_GrossProfit; // 粗利金額(在庫)
                dr[PMHNB02145EA.ct_Col_Or_SalesTimes] = shipGdsPrimeListResultWork.Or_SalesTimes; // 売上回数(取寄)
                dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount] = shipGdsPrimeListResultWork.Or_TotalSalesCount; // 売上数計(取寄)
                dr[PMHNB02145EA.ct_Col_Or_SalesMoney] = shipGdsPrimeListResultWork.Or_SalesMoney; // 売上金額(取寄)
                dr[PMHNB02145EA.ct_Col_Or_SalesRetGoodsPrice] = shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice; // 返品額(取寄)
                dr[PMHNB02145EA.ct_Col_Or_DiscountPrice] = shipGdsPrimeListResultWork.Or_DiscountPrice; // 値引金額(取寄)
                dr[PMHNB02145EA.ct_Col_Or_GrossProfit] = shipGdsPrimeListResultWork.Or_GrossProfit; // 粗利金額(取寄)
                dr[PMHNB02145EA.ct_Col_BLGroupCode] = shipGdsPrimeListResultWork.BLGroupCode; // BLグループコード // ADD 2009/02/13

                dr[PMHNB02145EA.ct_Col_Sum_TotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount 
                                                                + shipGdsPrimeListResultWork.Or_TotalSalesCount; // 売上数計(在庫+取寄)

                // --- DEL 2009/02/16 -------------------------------->>>>>
                //List<GoodsUnitData> goodsUnitDataList;

                //// 商品情報取得
                //int status =this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, out goodsUnitDataList, out errMsg);

                //// --- DEL 2009/02/13 -------------------------------->>>>>
                ////if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                ////    || goodsUnitDataList.Count == 0)
                ////{
                ////    // 0件の場合、印字対象にしない
                ////    continue;
                ////}
                //// --- DEL 2009/02/13 -------------------------------->>>>>

                //if (goodsUnitDataList.Count != 0) // ADD 2009/02/13
                //{

                //    GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                //    dr[PMHNB02145EA.ct_Col_GoodsMakerName] = goodsUnitData.MakerShortName; // メーカー名称
                //    dr[PMHNB02145EA.ct_Col_GoodsMGroup] = goodsUnitData.GoodsMGroup; // 商品中分類コード
                //    dr[PMHNB02145EA.ct_Col_GoodsMGroupName] = goodsUnitData.GoodsMGroupName; // 商品中分類名称
                //    dr[PMHNB02145EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // BLグループコード
                //    dr[PMHNB02145EA.ct_Col_BLGroupCodeName] = goodsUnitData.BLGroupName; // BLグループコード名称
                //    dr[PMHNB02145EA.ct_Col_SuplierCode] = goodsUnitData.SupplierCd; // 仕入先コード(純正品では使用しない)
                //    dr[PMHNB02145EA.ct_Col_GoodsName] = goodsUnitData.GoodsNameKana; // 品名

                //    // 在庫リストのIndex検索
                //    int index = GetStockListIndex(shipGdsPrimeListResultWork, goodsUnitData);

                //    if (index != -1)
                //    {
                //        dr[PMHNB02145EA.ct_Col_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // 棚番
                //        dr[PMHNB02145EA.ct_Col_SupplierStock] = goodsUnitData.StockList[index].SupplierStock; // 現在庫（仕入在庫数）
                //    }
                //    else
                //    {
                //        // 在庫リストが0件の場合、表示は行う。（棚番と現在庫はカラ）
                //    }

                //    // 価格情報のインデックスを取得
                //    index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

                //    if (index != -1)
                //    {
                //        dr[PMHNB02145EA.ct_Col_ListPrice] = goodsUnitData.GoodsPriceList[index].ListPrice; // 価格
                //    }
                //    else
                //    {
                //        // 価格リストが0件の場合、表示は行う。（価格はカラ）
                //    }
                //}
                // --- DEL 2009/02/16 -------------------------------->>>>>

                this._shipGdsPrimeListDt.Rows.Add(dr);
            }
        }

        // --- DEL 2009/02/16 -------------------------------->>>>>
        ///// <summary>
        ///// 商品情報取得処理
        ///// </summary>
        ///// <param name="shipGdsPrimeListResultWork"></param>
        ///// <param name="goodsUnitDataList"></param>
        ///// <param name="errMsg"></param>
        ///// <returns></returns>
        //private int GetGoodsUnitDataList(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, out List<GoodsUnitData> goodsUnitDataList, out string errMsg)
        //{
        //    GoodsCndtn goodsCndtn = new GoodsCndtn();

        //    goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
        //    goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
        //    goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;

        //    int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out errMsg);

        //    return status;
        //}
        // --- DEL 2009/02/16 --------------------------------<<<<<

        /// <summary>
        /// 条件に合致する在庫リストのindexを取得する
        /// </summary>
        /// <returns></returns>
        private int GetStockListIndex(string enterpriseCode, string sectionCode , GoodsUnitData goodsUnitData)
        {
            // --- ADD 2009/01/13 -------------------------------->>>>>
            // 拠点マスタに合致する拠点コードが無い場合、該当なし(-1)を返す
            if (!stc_SectionDic.ContainsKey(sectionCode))
            {
                return -1;
            }
            // --- ADD 2009/01/13 --------------------------------<<<<<

            // 拠点マスタデータの取得
            SecInfoSet secInfoSet = stc_SectionDic[sectionCode];

            // 拠点倉庫コード(優先順)
            string SectWarehouseCd1 = secInfoSet.SectWarehouseCd1;
            string SectWarehouseCd2 = secInfoSet.SectWarehouseCd2;
            string SectWarehouseCd3 = secInfoSet.SectWarehouseCd3;

            int index;

            // 在庫リストのインデックスを取得
            index = this.CheckStockList(enterpriseCode, sectionCode ,goodsUnitData, goodsUnitData.StockList, SectWarehouseCd1);

            if (index == -1)
            {
                index = this.CheckStockList(enterpriseCode, sectionCode ,goodsUnitData, goodsUnitData.StockList, SectWarehouseCd2);

                if (index == -1)
                {
                    index = this.CheckStockList(enterpriseCode, sectionCode ,goodsUnitData, goodsUnitData.StockList, SectWarehouseCd3);

                }
            }

            return index;
        }

        /// <summary>
        /// 条件に合致する在庫リストのindexを取得する
        /// </summary>
        /// <returns></returns>
        private int GetStockListIndex(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, GoodsUnitData goodsUnitData)
        {
            // --- ADD 2009/01/13 -------------------------------->>>>>
            // 拠点マスタに合致する拠点コードが無い場合、該当なし(-1)を返す
            if (!stc_SectionDic.ContainsKey(shipGdsPrimeListResultWork.AddUpSecCode))
            {
                return -1;
            }
            // --- ADD 2009/01/13 --------------------------------<<<<<

            // 拠点マスタデータの取得
            SecInfoSet secInfoSet = stc_SectionDic[shipGdsPrimeListResultWork.AddUpSecCode];

            // 拠点倉庫コード(優先順)
            string SectWarehouseCd1 = secInfoSet.SectWarehouseCd1;
            string SectWarehouseCd2 = secInfoSet.SectWarehouseCd2;
            string SectWarehouseCd3 = secInfoSet.SectWarehouseCd3;

            int index;

            // 在庫リストのインデックスを取得
            index = this.CheckStockList(shipGdsPrimeListResultWork, goodsUnitData.StockList, SectWarehouseCd1);

            if (index == -1)
            {
                index = this.CheckStockList(shipGdsPrimeListResultWork, goodsUnitData.StockList, SectWarehouseCd2);

                if (index == -1)
                {
                    index = this.CheckStockList(shipGdsPrimeListResultWork, goodsUnitData.StockList, SectWarehouseCd3);

                }
            }

            return index;
        }

        /// <summary>
        /// 倉庫拠点コードに合致するStockリストIndexを検索する
        /// </summary>
        /// <param name="shipGdsPrimeListResultWork"></param>
        /// <param name="stockList"></param>
        /// <param name="SectWarehouseCd"></param>
        /// <returns></returns>
        private int CheckStockList(string enterpriseCode, string sectionCode, GoodsUnitData goodsUnitData, List<Stock> stockList, string SectWarehouseCd)
        {
            Stock stock;
            int index = -1;

            for (int i = 0; i < stockList.Count; i++)
            {
                stock = stockList[i];

                if (stock.EnterpriseCode.Trim() == enterpriseCode.Trim()
                    //&& stock.SectionCode.Trim() == sectionCode.Trim() // DEL 2009/01/15
                        && stock.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                        && stock.GoodsNo.Trim() == goodsUnitData.GoodsNo.Trim()
                        && stock.WarehouseCode.Trim() == SectWarehouseCd.Trim())
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// 倉庫拠点コードに合致するStockリストIndexを検索する
        /// </summary>
        /// <param name="shipGdsPrimeListResultWork"></param>
        /// <param name="stockList"></param>
        /// <param name="SectWarehouseCd"></param>
        /// <returns></returns>
        private int CheckStockList(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, List<Stock> stockList, string SectWarehouseCd)
        {
            Stock stock;
            int index = -1;

            for (int i = 0; i < stockList.Count; i++)
            {
                stock = stockList[i];

                if (stock.EnterpriseCode.Trim() == shipGdsPrimeListResultWork.EnterpriseCode.Trim()
                    //&& stock.SectionCode.Trim() == shipGdsPrimeListResultWork.AddUpSecCode.Trim() // DEL 2009/01/15
                        && stock.GoodsMakerCd == shipGdsPrimeListResultWork.GoodsMakerCd
                        && stock.GoodsNo.Trim() == shipGdsPrimeListResultWork.GoodsNo.Trim()
                        && stock.WarehouseCode.Trim() == SectWarehouseCd.Trim())
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// システム日付に合致する価格リストのindexを取得する
        /// </summary>
        /// <br>Update Note  : 2015/04/07 呉軍</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             : 明治産業様Seiken品番変更 システム障害№57価格表示不正の対応</br>
        /// <returns></returns>
        private int GetGoodsPriceListIndex(List<GoodsPrice> goodsPriceList)
        {
            // 価格情報の取得
            List<DateTime> priceStartDateList = new List<DateTime>();
            

            // 開始日リストの作成
            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                priceStartDateList.Add(goodsPrice.PriceStartDate);
            }

            // 日付順にソート
            priceStartDateList.Sort();

            int index = -1;
            if (priceStartDateList.Count == 0)
            {
            }
            else if (priceStartDateList.Count == 1)
            {
                if (priceStartDateList[0] <= DateTime.Now)
                {
                    index = 0;
                }
            }
            else
            {
                for (int i = 1; i < priceStartDateList.Count; i++)
                {
                    if (priceStartDateList[i - 1] <= DateTime.Now
                        && priceStartDateList[i] >= DateTime.Now)
                    {
                        //index = i;     // DEL 2015/04/07 呉軍 明治産業様Seiken品番変更 システム障害№57価格表示不正の対応
                        index = i - 1;   // ADD 2015/04/07 呉軍 明治産業様Seiken品番変更 システム障害№57価格表示不正の対応
                        break;
                    }
                }

                // 最大の日付が現在日時より前
                if (priceStartDateList[priceStartDateList.Count - 1] <= DateTime.Now)
                {
                    index = priceStartDateList.Count - 1;
                }

                // --- ADD 2015/04/07 呉軍 明治産業様Seiken品番変更 システム障害№57価格表示不正の対応-->>>>>
                if (index >= 0)
                {
                    GoodsPrice goodsPrice = new GoodsPrice();
                    DateTime priceStartDate = priceStartDateList[index];
                    for (int newIndex = 0; newIndex < goodsPriceList.Count; newIndex++)
                    {
                        goodsPrice = goodsPriceList[newIndex];
                        if (priceStartDate.Equals(goodsPrice.PriceStartDate))
                        {
                            index = newIndex;
                            break;
                        }
                    }
                }
                // --- ADD 2015/04/07 呉軍 明治産業様Seiken品番変更 システム障害№57価格表示不正の対応--<<<<<
            }

            return index;
        }

        /// <summary>
        /// 優良品情報取得処理
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <remarks>
        /// <br>Update Note  : 2014/12/16 劉超</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更</br>
        /// <br>Update Note  : 2015/03/05 劉超</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更 システム障害対応(品番表示)</br>
        /// </remarks>
        private void GetPartsInfo(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            GoodsCndtn goodsCndtn = new GoodsCndtn(); // ADD 2009/02/16

            ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // ADD 2009/02/16

            // 純正品1件毎に処理
            foreach (DataRow dr in this._shipGdsPrimeListDt.Rows)
            {
                // 商品情報取得
                //GoodsCndtn goodsCndtn = new GoodsCndtn(); // DEL 2009/02/16

                goodsCndtn.EnterpriseCode = dr[PMHNB02145EA.ct_Col_EnterpriseCode].ToString();
                goodsCndtn.SectionCode = dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString(); // ADD 2008/12/17
                goodsCndtn.GoodsNo = dr[PMHNB02145EA.ct_Col_GoodsNo].ToString();
                goodsCndtn.GoodsMakerCd = (int)dr[PMHNB02145EA.ct_Col_GoodsMakerCd];
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search; // ADD 2008/12/17

                goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/16
                goodsCndtn.IsSettingVariousMst = 1; // ADD 2009/02/16

                PartsInfoDataSet partsInfoDataSet;
                List<GoodsUnitData> GoodsUnitDataList;
                string msg;

                // 商品マスタ検索(結合品検索)
                this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, false, out partsInfoDataSet, out GoodsUnitDataList, out msg);

                // --- ADD 2009/02/16 -------------------------------->>>>>
                if (GoodsUnitDataList == null || GoodsUnitDataList.Count == 0)
                {
                    // 以降の情報を取得しない
                    continue;
                }

                // 親情報取得
                this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet, goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, GoodsAcs.GoodsKind.Parent, out GoodsUnitDataList);

                if (GoodsUnitDataList == null || GoodsUnitDataList.Count == 0)
                {
                    continue;
                }

                // --- ADD 2009.02.18 -------------------------------->>>>>
                GoodsUnitData parentGoodsUnitData = GoodsUnitDataList[0];
 
                // 商品連結データ不足情報設定処理呼出し
                this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref parentGoodsUnitData, 1);
                // --- ADD 2009.02.18 --------------------------------<<<<<

                //this.SetParentInfo(GoodsUnitDataList[0], dr); // DEL 2009.02.18
                this.SetParentInfo(parentGoodsUnitData, dr); // ADD 2009.02.18

                // --- ADD 2009/02/16 --------------------------------<<<<<

                // 結合子データのみを取出し
                this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet, goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, GoodsAcs.GoodsKind.ChildJoin, out GoodsUnitDataList); // ADD 2008/12/17

                // テスト用
                //this.testProcGoods(out GoodsUnitDataList);

                // 帳票印字対象優良品 情報リスト
                List<GoodsUnitData> printGoodsUnitDataList = new List<GoodsUnitData>();
                ArrayList printShipGdsPrimeListResultList = new ArrayList();

                // 月次集計データ情報取得
                for (int i = 0; i < GoodsUnitDataList.Count; i++)
                {
                    GoodsUnitData goodsUnitData = GoodsUnitDataList[i];

                    // --- DEL 2008/12/17 -------------------------------->>>>>
                    //if (
                    //    //goodsCndtn.EnterpriseCode == goodsUnitData.EnterpriseCode // DEL 2008/12/16
                    //    goodsCndtn.GoodsNo == goodsUnitData.GoodsNo
                    //    && goodsCndtn.GoodsMakerCd == goodsUnitData.GoodsMakerCd)
                    //{
                    //    // 純正品は除く
                    //    continue;
                    //}
                    // --- DEL 2008/12/17 --------------------------------<<<<<
                    
                    //ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // DEL 2009/02/16

                    // 抽出条件展開  --------------------------------------------------------------
                    int status = this.DevPartnerListCndtn(shipGdsPrimeListCndtn, dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString(), goodsUnitData,
                                                          ref shipGdsPrmListCndtnPartnerWork);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        continue;
                    }

                    ArrayList shipGdsPrmListCndtnPartnerWorkList = new ArrayList();
                    shipGdsPrmListCndtnPartnerWorkList.Add(shipGdsPrmListCndtnPartnerWork);

                    object retWorkList = null;

                    // リモート検索(優良品)
                    status = this._iShipGdsPrimeListResultWorkDB.SearchPartner(out retWorkList, shipGdsPrmListCndtnPartnerWorkList, 0, ConstantManagement.LogicalMode.GetData0);

                    // テスト用
                    //this.testProcParts(out retWorkList);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        || ((ArrayList)retWorkList).Count == 0)
                    {
                        continue;
                    }
                    //------ DEL START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                    // 新旧商品を確定した後、商品連結データを取得する。
                    //// --- ADD 2009/01/13 -------------------------------->>>>>
                    //// 商品連結データ不足情報設定処理呼出し
                    ////this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData); // DEL 2009/02/16
                    //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1); // ADD 2009/02/16
                    //// --- ADD 2009/01/13 --------------------------------<<<<<
                    //------ DEL END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                    string shipGoodsNo = string.Empty;
                    ArrayList resultList = retWorkList as ArrayList;
                    string tempGoodsNo = string.Empty; //ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更のシステム障害対応(品番の表示)
                    ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = new ShipGdsPrimeListResultWork();
                    for (int j = 0; j < resultList.Count; j++)
                    {
                        shipGdsPrimeListResultWork = resultList[j] as ShipGdsPrimeListResultWork;
                    }
                    //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                    // 品番集計区分は「合算」且つ品番表示区分が「旧品番」場合
                    if ((shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn.GoodsNoTtlDivState.Together) &&
                        (shipGdsPrimeListCndtn.GoodsNoShowDiv == ShipGdsPrimeListCndtn.GoodsNoShowDivState.OldGoodsNo))
                    {
                        GoodsCndtn goodsCndtnChg = new GoodsCndtn();
                        List<GoodsUnitData> GoodsUnitDataListChg;
                        goodsCndtnChg.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;
                        //goodsCndtnChg.SectionCode = dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString();
                        goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;
                        // 旧品番表示の場合、旧品番を一時退避します。
                        tempGoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;//ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示)
                        goodsCndtnChg.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                        //goodsCndtnChg.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;
                        goodsCndtnChg.IsSettingSupplier = 1;
                        goodsCndtnChg.IsSettingVariousMst = 1;
                        //this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnChg, false, out GoodsUnitDataListChg, out msg); // DEL 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応
                        //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------>>>>>
                        goodsCndtnChg.GoodsKindCode = 9;
                        this._goodsAcs.Search(goodsCndtnChg, out GoodsUnitDataListChg, out msg);
                        //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------<<<<<
                        if (GoodsUnitDataListChg == null || GoodsUnitDataListChg.Count == 0)
                        {
                            // 旧商品の在庫情報がないため、新商品を使用します。
                            goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                            //this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnChg, false, out GoodsUnitDataListChg, out msg); // DEL 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応
                            this._goodsAcs.Search(goodsCndtnChg, out GoodsUnitDataListChg, out msg); // ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応
                            if (GoodsUnitDataListChg == null || GoodsUnitDataListChg.Count == 0)
                            {
                                // 新商品がないため、既存のまま新商品を使用します。
                            }
                            else
                            {
                                // 新商品があるため、新商品を使用します。
                                goodsUnitData = GoodsUnitDataListChg[0];
                            }                           
                        }
                        else
                        {
                            // 旧商品があるため、旧商品を使用します。
                            goodsUnitData = GoodsUnitDataListChg[0];
                        }
                    }
                    // 品番集計区分は「合算」且つ品番表示区分が「新品番」場合
                    else if ((shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn.GoodsNoTtlDivState.Together) &&
                        (shipGdsPrimeListCndtn.GoodsNoShowDiv == ShipGdsPrimeListCndtn.GoodsNoShowDivState.NewGoodsNo))
                    {
                        GoodsCndtn goodsCndtnChg = new GoodsCndtn();
                        List<GoodsUnitData> GoodsUnitDataListChg;
                        goodsCndtnChg.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;
                        //goodsCndtnChg.SectionCode = dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString();
                        goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                        // 新品番表示の場合、新品番を一時退避します。
                        tempGoodsNo = shipGdsPrimeListResultWork.GoodsNo;//ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示)
                        goodsCndtnChg.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                        //goodsCndtnChg.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;
                        goodsCndtnChg.IsSettingSupplier = 1;
                        goodsCndtnChg.IsSettingVariousMst = 1;
                        //this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnChg, false, out GoodsUnitDataListChg, out msg);// DEL 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応
                        //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------>>>>>
                        goodsCndtnChg.GoodsKindCode = 9;
                        this._goodsAcs.Search(goodsCndtnChg, out GoodsUnitDataListChg, out msg);
                        //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------<<<<<
                        if (GoodsUnitDataListChg == null || GoodsUnitDataListChg.Count == 0)
                        {
                            // 新商品の在庫情報がないため、旧新商品を使用します。
                            goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;
                            //this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnChg, false, out GoodsUnitDataListChg, out msg); // DEL 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応
                            this._goodsAcs.Search(goodsCndtnChg, out GoodsUnitDataListChg, out msg); // ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応
                            if (GoodsUnitDataListChg == null || GoodsUnitDataListChg.Count == 0)
                            {
                                // 旧商品がないため、既存のままを使用します。
                            }
                            else
                            {
                                // 旧商品が存在の場合、旧商品を使用します。
                                goodsUnitData = GoodsUnitDataListChg[0];
                            }
                        }
                        else
                        {
                            // 新商品が存在の場合、既存のまま新商品を使用します。
                            goodsUnitData = GoodsUnitDataListChg[0];
                        }
                    }
                    else
                    {
                        // 品番集計区分は「別々」の場合、既存のままで処理します。
                    }

                    // 商品連結データ不足情報設定処理呼出し
                    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1);

                    //------ ADD START 2015/03/05 劉超 明治産業様Seiken品番変更(品番の表示) ------>>>>>
                    // 品番集計区分は「合算」
                    if (shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn.GoodsNoTtlDivState.Together) 
                    {
                        if (!tempGoodsNo.Equals(goodsUnitData.GoodsNo))
                        {
                            // 一時退避した品番を商品マスタに切り替えします。
                            goodsUnitData.GoodsNo = tempGoodsNo;
                            // 倉庫情報を取得するために、倉庫情報の商品番号も切り替えします。
                            if (goodsUnitData.StockList != null && goodsUnitData.StockList.Count > 0)
                            {
                                foreach (Stock stock in goodsUnitData.StockList)
                                {
                                    stock.GoodsNo = tempGoodsNo;
                                }
                            }
                        }
                    }
                    else
                    {
                        // 品番集計区分は「別々」の場合、既存のままで処理します。
                    }
                    //------ ADD END 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示) ------<<<<<
                    //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                    // 月次データまで正常に取得出来た場合のみ、印字用データに保存
                    printGoodsUnitDataList.Add(goodsUnitData);
                    printShipGdsPrimeListResultList.Add(((ArrayList)retWorkList)[0]);
                }

                // 優良品情報を保存
                dr[PMHNB02145EA.ct_Col_PartsCount] = printGoodsUnitDataList.Count;
                dr[PMHNB02145EA.ct_Col_GoodsUnitDataList] = printGoodsUnitDataList;
                dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList] = printShipGdsPrimeListResultList;
            }
        }

        // --- ADD 2009/02/16 -------------------------------->>>>>
        /// <summary>
        /// 純正品情報設定
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="dr"></param>
        private void SetParentInfo(GoodsUnitData goodsUnitData, DataRow dr)
        {
            dr[PMHNB02145EA.ct_Col_GoodsMakerName] = goodsUnitData.MakerShortName; // メーカー名称
            dr[PMHNB02145EA.ct_Col_GoodsMGroup] = goodsUnitData.GoodsMGroup; // 商品中分類コード
            dr[PMHNB02145EA.ct_Col_GoodsMGroupName] = goodsUnitData.GoodsMGroupName; // 商品中分類名称
            //dr[PMHNB02145EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // BLグループコード // DEL 2009/02/21
            //dr[PMHNB02145EA.ct_Col_BLGroupCodeName] = goodsUnitData.BLGroupName; // BLグループコード名称 // DEL 2009/02/21
            // --- ADD 2009/02/21 -------------------------------->>>>>
            if (dr[PMHNB02145EA.ct_Col_BLGroupCode] == null
                || dr[PMHNB02145EA.ct_Col_BLGroupCode].ToString() == string.Empty
                || (int)dr[PMHNB02145EA.ct_Col_BLGroupCode] == 0)
            {
                dr[PMHNB02145EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // BLグループコード
                dr[PMHNB02145EA.ct_Col_BLGroupCodeName] = goodsUnitData.BLGroupName; // BLグループコード名称
            }
            // --- ADD 2009/02/21 --------------------------------<<<<<
            dr[PMHNB02145EA.ct_Col_SuplierCode] = goodsUnitData.SupplierCd; // 仕入先コード(純正品では使用しない)
            dr[PMHNB02145EA.ct_Col_GoodsName] = goodsUnitData.GoodsNameKana; // 品名

            // 在庫リストのIndex検索
            int index = GetStockListIndex(dr[PMHNB02145EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);
            if (index != -1)
            {
                dr[PMHNB02145EA.ct_Col_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // 棚番
                dr[PMHNB02145EA.ct_Col_SupplierStock] = goodsUnitData.StockList[index].SupplierStock; // 現在庫（仕入在庫数）
            }
            else
            {
                // 在庫リストが0件の場合、表示は行う。（棚番と現在庫はカラ）
            }

            // 価格情報のインデックスを取得
            index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

            if (index != -1)
            {
                dr[PMHNB02145EA.ct_Col_ListPrice] = goodsUnitData.GoodsPriceList[index].ListPrice; // 価格
            }
            else
            {
                // 価格リストが0件の場合、表示は行う。（価格はカラ）
            }
        }
        // --- ADD 2009/02/16 --------------------------------<<<<<

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
        /// <br>Date         : 2008.11.14</br>
        /// <br>Update Note  : 2014/12/16 劉超</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更</br>
        /// </remarks>
        private int DevPartnerListCndtn(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, string sectionCode, GoodsUnitData goodsUnitData,
            ref ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // DEL 2009/02/16

            try
            {
                // 抽出条件より設定
                shipGdsPrmListCndtnPartnerWork.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;  // 企業コード
                shipGdsPrmListCndtnPartnerWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AddUpYearMonth; // 開始対象年月
                shipGdsPrmListCndtnPartnerWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AddUpYearMonth; // 終了対象年月
                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv = (int)shipGdsPrimeListCndtn.GoodsNoTtlDiv; // 品番集計区分
                if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                {
                    shipGdsPrmListCndtnPartnerWork.GoodsNoShowDiv = (int)shipGdsPrimeListCndtn.GoodsNoShowDiv; // 品番表示区分
                }
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

                // 優良商品情報1より設定
                shipGdsPrmListCndtnPartnerWork.SectionCode = sectionCode; // 拠点コード
                shipGdsPrmListCndtnPartnerWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd; // メーカーコード
                shipGdsPrmListCndtnPartnerWork.GoodsNo = goodsUnitData.GoodsNo; // 品番コード
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        // --- ADD 2009/01/08 -------------------------------->>>>>
        /// <summary>
        /// 無実績レコード除外処理
        /// </summary>
        /// <remarks>
        /// <br>Note       　: 純正品番、優良品番全てに実績が無いレコードを除外する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2009.01.08</br>
        /// </remarks>
        private void RemoveNoResultGoodsRow()
        {
            DataTable tmpTable = this._shipGdsPrimeListDt.Copy();
            this._shipGdsPrimeListDt.Clear();

            foreach (DataRow dr in tmpTable.Rows)
            {
                // 実績有無フラグ(true:あり)
                bool existResultFlg = false;

                #region 純正品チェック
                if (
                    (Int64)dr[PMHNB02145EA.ct_Col_St_SalesMoney]
                    + (Int64)dr[PMHNB02145EA.ct_Col_St_SalesRetGoodsPrice]
                    + (Int64)dr[PMHNB02145EA.ct_Col_St_DiscountPrice]
                    + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesMoney]
                    + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesRetGoodsPrice]
                    + (Int64)dr[PMHNB02145EA.ct_Col_Or_DiscountPrice]
                    != 0)
                {
                    // 純売上額あり
                    existResultFlg = true;
                }

                if (!existResultFlg
                    &&
                    (Int64)dr[PMHNB02145EA.ct_Col_St_GrossProfit]
                    + (Int64)dr[PMHNB02145EA.ct_Col_Or_GrossProfit]
                    != 0
                    )
                {
                    // 粗利額あり
                    existResultFlg = true;
                }

                if (!existResultFlg
                    &&
                    (double)dr[PMHNB02145EA.ct_Col_St_TotalSalesCount] != 0)
                {
                    // 売上数計（在庫）あり
                    existResultFlg = true;
                }

                if (!existResultFlg
                    &&
                    (double)dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount] != 0)
                {
                    // 売上数計（取寄）あり
                    existResultFlg = true;
                }

                // --- ADD 2009/03/13 -------------------------------->>>>>
                if (!existResultFlg
                    &&
                    (double)dr[PMHNB02145EA.ct_Col_ListPrice] != 0)
                {
                    // 価格あり
                    existResultFlg = true;
                }
                // --- ADD 2009/03/13 --------------------------------<<<<<
                #endregion

                #region 優良品チェック

                if (!existResultFlg
                    && dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList] != null
                    && ((ArrayList)dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList]).Count != 0)
                {
                    // 純正品の実績が無いかつ優良品が存在する場合、優良品の実績チェック
                    //foreach (ShipGdsPrimeListResultWork shipGdsPrimeListResultWork in (ArrayList)(dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])) // DEL 2009/03/13
                    for (int i = 0; i < ((ArrayList)(dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])).Count; i++) // ADD 2009/03/13
                    {
                        ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)(dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList]))[i]; // ADD 2009/03/13
                        //GoodsUnitData goodsUnitData = (GoodsUnitData)((ArrayList)dr[PMHNB02145EA.ct_Col_GoodsUnitDataList])[i]; // DEL 李亜博 2012/04/09 Redmine#29336
                        GoodsUnitData goodsUnitData = ((List<GoodsUnitData>)(dr[PMHNB02145EA.ct_Col_GoodsUnitDataList]))[i];  //ADD 李亜博 2012/04/09 Redmine#29336

                        if (
                            shipGdsPrimeListResultWork.St_SalesMoney
                            + shipGdsPrimeListResultWork.St_SalesRetGoodsPrice
                            + shipGdsPrimeListResultWork.St_DiscountPrice
                            + shipGdsPrimeListResultWork.Or_SalesMoney
                            + shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice
                            + shipGdsPrimeListResultWork.Or_DiscountPrice
                            != 0
                            )
                        {
                            // 純売上額あり
                            existResultFlg = true;
                            break;
                        }

                        if (!existResultFlg
                            &&
                            shipGdsPrimeListResultWork.St_GrossProfit
                            + shipGdsPrimeListResultWork.Or_GrossProfit
                            != 0
                            )
                        {
                            // 粗利額あり
                            existResultFlg = true;
                            break;
                        }

                        if (!existResultFlg
                            &&
                            shipGdsPrimeListResultWork.St_TotalSalesCount != 0)
                        {
                            // 売上数計（在庫）あり
                            existResultFlg = true;
                            break;
                        }

                        if (!existResultFlg
                            &&
                            shipGdsPrimeListResultWork.Or_TotalSalesCount != 0)
                        {
                            // 売上数計（取寄）あり
                            existResultFlg = true;
                            break;
                        }

                        // --- ADD 2009/03/13 -------------------------------->>>>>
                        // 価格情報のインデックスを取得
                        int index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

                        double price = 0;
                        if (index != -1)
                        {
                            price = goodsUnitData.GoodsPriceList[index].ListPrice; // 価格
                        }

                        if (!existResultFlg
                            &&
                            price != 0)
                        {
                            // 価格あり
                            existResultFlg = true;
                            break;
                        }
                        // --- ADD 2009/03/13 --------------------------------<<<<<
                    }
                }
                #endregion

                if (existResultFlg)
                {
                    // 実績がある場合は印字対象とする
                    this._shipGdsPrimeListDt.ImportRow(dr);
                }
            }
        }
        // --- ADD 2009/01/08 --------------------------------<<<<<

        /// <summary>
        /// 順位の設定を行う
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn">抽出条件</param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private void SetOrder(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, ref string errMsg)
        {
            string savAddUpSecCode = ""; // 拠点コード
            string savCode = ""; // 順位付で指定した単位(メーカー、商品中分類、グループコード) 
            int orderNo = 0; // 順位
            int orderNoPls = 0; // 順位加算値
            double savTotls = -1;  
            double nowTotls = 0;

            DataTable tmpTable = this._shipGdsPrimeListDt.Copy();
            this._shipGdsPrimeListDt.Clear();

            // 結合区分を反映
            // 順位付設定順に並び替え
            DataRow[] sortedDrList = tmpTable.Select(this.GetFilterStringForOrder(shipGdsPrimeListCndtn), this.GetSortStringForOrder(shipGdsPrimeListCndtn));

            for (int i = 0; i < sortedDrList.Length; i++)
            {
                DataRow dr = sortedDrList[i];

                //拠点-指定した単位毎
                string tmpAddUpSecCode = (string)dr[PMHNB02145EA.ct_Col_AddUpSecCode];

                string tmpCode;
                if (shipGdsPrimeListCndtn.RankSection == ShipGdsPrimeListCndtn.RankSectionState.Maker)
                {
                    tmpCode = dr[PMHNB02145EA.ct_Col_GoodsMakerCd].ToString();
                }
                else if (shipGdsPrimeListCndtn.RankSection == ShipGdsPrimeListCndtn.RankSectionState.GoodsMGroup)
                {
                    tmpCode = (string)dr[PMHNB02145EA.ct_Col_GoodsMGroup].ToString();
                }
                else
                {
                    tmpCode = (string)dr[PMHNB02145EA.ct_Col_BLGroupCode].ToString();
                }

                // 拠点と指定した単位のいづれかが異なる場合、順位付情報を初期化
                if (savAddUpSecCode.Trim() != tmpAddUpSecCode.Trim()
                    || savCode.Trim() != tmpCode.Trim())
                {
                    savAddUpSecCode = tmpAddUpSecCode;
                    savCode = tmpCode;
                    orderNo = 0;
                    orderNoPls = 0;
                    savTotls = -1;
                }

                nowTotls = (double)dr[PMHNB02145EA.ct_Col_Sum_TotalSalesCount];

                if (savTotls == nowTotls)
                {
                    orderNoPls++;
                }
                else
                {
                    // 順位は最大値以上も振る
                    savTotls = nowTotls;
                    orderNo += orderNoPls;
                    orderNoPls = 0;
                }

                if (orderNoPls == 0)
                {
                    orderNo++;
                }

                dr[PMHNB02145EA.ct_Col_Order] = orderNo;

                this._shipGdsPrimeListDt.ImportRow(dr);
            }
        }

        /// <summary>
        /// 順位付用フィルタ文字列作成
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetFilterStringForOrder(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            if (shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.Combine)
            {
                return PMHNB02145EA.ct_Col_PartsCount + " > 0";
            }
            else if (shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.NotCombine)
            {
                return PMHNB02145EA.ct_Col_PartsCount + " = 0";
            }
            else // 全て
            {
                // フィルタなし
                return "";
            }
        }

        /// <summary>
        /// 順位付用ソート文字列作成
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetSortStringForOrder(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            StringBuilder sb = new StringBuilder();

            // 拠点 + 順位付で指定した単位 + 売上数計(在庫+取寄)の(上位or下位)でソート
            sb.Append(PMHNB02145EA.ct_Col_AddUpSecCode);
            sb.Append(", ");

            switch (shipGdsPrimeListCndtn.RankSection)
            {
                case ShipGdsPrimeListCndtn.RankSectionState.Maker:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_GoodsMakerCd);
                        break;
                    }
                case ShipGdsPrimeListCndtn.RankSectionState.BLGroupCode:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_BLGroupCode);
                        break;
                    }
                case ShipGdsPrimeListCndtn.RankSectionState.GoodsMGroup:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_GoodsMGroup);
                        break;
                    }
            }

            sb.Append(", ");
            sb.Append(PMHNB02145EA.ct_Col_Sum_TotalSalesCount);

            if (shipGdsPrimeListCndtn.RankHighLow == ShipGdsPrimeListCndtn.RankHighLowState.High)
            {
                sb.Append(" DESC");
            }
            else
            {
                sb.Append(" ASC");
            }

            return sb.ToString();
        }

        /// <summary>
        /// フィルタ、ソート処理を行う
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn">抽出条件</param>
        private void FilterAndSort(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            DataTable tmpTable = this._shipGdsPrimeListDt.Copy();
            this._shipGdsPrimeListDt.Clear();

            DataRow[] drList = tmpTable.Select(this.GetFilterString(shipGdsPrimeListCndtn), this.GetSortString(shipGdsPrimeListCndtn));

            foreach(DataRow dr in drList)
            {
                this._shipGdsPrimeListDt.ImportRow(dr);
            }
        }

        /// <summary>
        /// フィルタ文字列を取得する
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetFilterString(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            return PMHNB02145EA.ct_Col_Order + " <=" + shipGdsPrimeListCndtn.RankOrderMax;
        }

        /// <summary>
        /// ソート文字列を取得する
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetSortString(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            StringBuilder sb = new StringBuilder();

            // 拠点 + 順位付で指定した単位 + 順位 + 品番でソート
            sb.Append(PMHNB02145EA.ct_Col_AddUpSecCode);
            sb.Append(", ");

            switch (shipGdsPrimeListCndtn.RankSection)
            {
                case ShipGdsPrimeListCndtn.RankSectionState.Maker:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_GoodsMakerCd);
                        break;
                    }
                case ShipGdsPrimeListCndtn.RankSectionState.BLGroupCode:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_BLGroupCode);
                        break;
                    }
                case ShipGdsPrimeListCndtn.RankSectionState.GoodsMGroup:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_GoodsMGroup);
                        break;
                    }
            }
            sb.Append(", ");

            sb.Append(PMHNB02145EA.ct_Col_Order);
            sb.Append(", ");

            sb.Append(PMHNB02145EA.ct_Col_GoodsNo);

            return sb.ToString();
        }

        /// <summary>
        /// 帳票印字用テーブルの1行データを作成する
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn">抽出条件</param>
        private void MakePrintTable(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            // 帳票印字用テーブル作成
            PMHNB02145EB.CreateDataTable(ref this._printDt);

            // 帳票印字用テーブルに追加する1行情報(PMHNB02145EB)
            DataRow printRow;

            foreach (DataRow dr in this._shipGdsPrimeListDt.Rows)
            {
                if ((Int32)dr[PMHNB02145EA.ct_Col_PartsCount] == 0)
                {
                    if (shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.All
                    || shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.NotCombine)
                    {
                        // 1行のみ作成
                        printRow = this._printDt.NewRow();

                        #region 純正品情報
                        // 純正品情報設定
                        printRow[PMHNB02145EB.ct_Col_RowNumber] = 0; // 行番号
                        printRow[PMHNB02145EB.ct_Col_AddUpSecCode] = dr[PMHNB02145EA.ct_Col_AddUpSecCode]; // 拠点コード
                        printRow[PMHNB02145EB.ct_Col_SectionGuideSnm] = dr[PMHNB02145EA.ct_Col_SectionGuideSnm]; // 拠点略称
                        printRow[PMHNB02145EB.ct_Col_Pure_WarehouseShelfNo] = dr[PMHNB02145EA.ct_Col_WarehouseShelfNo]; // 棚番
                        printRow[PMHNB02145EB.ct_Col_Pure_MakerCode] = dr[PMHNB02145EA.ct_Col_GoodsMakerCd]; // メーカーコード
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsMakerName] = dr[PMHNB02145EA.ct_Col_GoodsMakerName]; // メーカー名称
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsMGroup] = dr[PMHNB02145EA.ct_Col_GoodsMGroup]; // 商品中分類コード
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsMGroupName] = dr[PMHNB02145EA.ct_Col_GoodsMGroupName]; // 商品中分類名称
                        printRow[PMHNB02145EB.ct_Col_Pure_BLGroupCode] = dr[PMHNB02145EA.ct_Col_BLGroupCode]; // グループコード
                        printRow[PMHNB02145EB.ct_Col_Pure_BLGroupCodeName] = dr[PMHNB02145EA.ct_Col_BLGroupCodeName]; // グループコード名称
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsNo] = dr[PMHNB02145EA.ct_Col_GoodsNo]; // 品番
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsName] = dr[PMHNB02145EA.ct_Col_GoodsName]; // 品名
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsPrice] = dr[PMHNB02145EA.ct_Col_ListPrice]; // 価格
                        printRow[PMHNB02145EB.ct_Col_Pure_SupplierStock] = dr[PMHNB02145EA.ct_Col_SupplierStock]; // 現在庫(仕入在庫数)
                        printRow[PMHNB02145EB.ct_Col_Pure_StockTotalSalesCount] = dr[PMHNB02145EA.ct_Col_St_TotalSalesCount]; // 売上数計(在庫)
                        printRow[PMHNB02145EB.ct_Col_Pure_OrderTotalSalesCount] = dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount]; // 売上数計(取寄)

                        printRow[PMHNB02145EB.ct_Col_Pure_StockTotalSalesCountSum] = dr[PMHNB02145EA.ct_Col_St_TotalSalesCount];
                        printRow[PMHNB02145EB.ct_Col_Pure_OrderTotalSalesCountSum] = dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount];

                        // 粗利率計算
                        Int64 pureSalesMoneySum = (Int64)dr[PMHNB02145EA.ct_Col_St_SalesMoney] + (Int64)dr[PMHNB02145EA.ct_Col_St_SalesRetGoodsPrice] + (Int64)dr[PMHNB02145EA.ct_Col_St_DiscountPrice]
                                                 + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesMoney] + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesRetGoodsPrice] + (Int64)dr[PMHNB02145EA.ct_Col_Or_DiscountPrice];

                        Int64 grossProfitSum = (Int64)dr[PMHNB02145EA.ct_Col_St_GrossProfit] + (Int64)dr[PMHNB02145EA.ct_Col_Or_GrossProfit];

                        printRow[PMHNB02145EB.ct_Col_Pure_GrossProfitRate] = this.GetRatio(grossProfitSum, pureSalesMoneySum);

                        // 1行に含まれる優良品数
                        printRow[PMHNB02145EB.ct_Col_PartsCount] = 0;

                        #endregion

                        this._printDt.Rows.Add(printRow);
                    }
                }
                else
                {
                    if (shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.All
                    || shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.Combine)
                    {
                        // 優良品情報分 帳票印字行作成
                        for (int i = 0; i < (Int32)dr[PMHNB02145EA.ct_Col_PartsCount]; i = i + 2)
                        {
                            printRow = this._printDt.NewRow();

                            #region 純正品情報
                            // 純正品情報設定
                            printRow[PMHNB02145EB.ct_Col_RowNumber] = i; // 行番号
                            printRow[PMHNB02145EB.ct_Col_AddUpSecCode] = dr[PMHNB02145EA.ct_Col_AddUpSecCode]; // 拠点コード
                            printRow[PMHNB02145EB.ct_Col_SectionGuideSnm] = dr[PMHNB02145EA.ct_Col_SectionGuideSnm]; // 拠点略称
                            printRow[PMHNB02145EB.ct_Col_Pure_WarehouseShelfNo] = dr[PMHNB02145EA.ct_Col_WarehouseShelfNo]; // 棚番
                            printRow[PMHNB02145EB.ct_Col_Pure_MakerCode] = dr[PMHNB02145EA.ct_Col_GoodsMakerCd]; // メーカーコード
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsMakerName] = dr[PMHNB02145EA.ct_Col_GoodsMakerName]; // メーカー名称
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsMGroup] = dr[PMHNB02145EA.ct_Col_GoodsMGroup]; // 商品中分類コード
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsMGroupName] = dr[PMHNB02145EA.ct_Col_GoodsMGroupName]; // 商品中分類名称
                            printRow[PMHNB02145EB.ct_Col_Pure_BLGroupCode] = dr[PMHNB02145EA.ct_Col_BLGroupCode]; // グループコード
                            printRow[PMHNB02145EB.ct_Col_Pure_BLGroupCodeName] = dr[PMHNB02145EA.ct_Col_BLGroupCodeName]; // グループコード名称
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsNo] = dr[PMHNB02145EA.ct_Col_GoodsNo]; // 品番
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsName] = dr[PMHNB02145EA.ct_Col_GoodsName]; // 品名
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsPrice] = dr[PMHNB02145EA.ct_Col_ListPrice]; // 価格
                            printRow[PMHNB02145EB.ct_Col_Pure_SupplierStock] = dr[PMHNB02145EA.ct_Col_SupplierStock]; // 現在庫(仕入在庫数)
                            printRow[PMHNB02145EB.ct_Col_Pure_StockTotalSalesCount] = dr[PMHNB02145EA.ct_Col_St_TotalSalesCount]; // 売上数計(在庫)
                            printRow[PMHNB02145EB.ct_Col_Pure_OrderTotalSalesCount] = dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount]; // 売上数計(取寄)

                            // 粗利率計算
                            Int64 pureSalesMoneySum = (Int64)dr[PMHNB02145EA.ct_Col_St_SalesMoney] + (Int64)dr[PMHNB02145EA.ct_Col_St_SalesRetGoodsPrice] + (Int64)dr[PMHNB02145EA.ct_Col_St_DiscountPrice]
                                                     + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesMoney] + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesRetGoodsPrice] + (Int64)dr[PMHNB02145EA.ct_Col_Or_DiscountPrice];

                            Int64 grossProfitSum = (Int64)dr[PMHNB02145EA.ct_Col_St_GrossProfit] + (Int64)dr[PMHNB02145EA.ct_Col_Or_GrossProfit];

                            printRow[PMHNB02145EB.ct_Col_Pure_GrossProfitRate] = this.GetRatio(grossProfitSum, pureSalesMoneySum);

                            if (i == 0)
                            {
                                // 同明細1行目であれば、計印字用売上数計を設定
                                printRow[PMHNB02145EB.ct_Col_Pure_StockTotalSalesCountSum] = dr[PMHNB02145EA.ct_Col_St_TotalSalesCount];
                                printRow[PMHNB02145EB.ct_Col_Pure_OrderTotalSalesCountSum] = dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount];
                            }
                            #endregion

                            #region 優良品情報1
                            // 優良品商品情報1
                            GoodsUnitData goodsUnitData = ((List<GoodsUnitData>)(dr[PMHNB02145EA.ct_Col_GoodsUnitDataList]))[i];

                            printRow[PMHNB02145EB.ct_Col_Parts1_GoodsNo] = goodsUnitData.GoodsNo; // 品番
                            printRow[PMHNB02145EB.ct_Col_Parts1_MakerCode] = goodsUnitData.GoodsMakerCd; // メーカーコード
                            printRow[PMHNB02145EB.ct_Col_Parts1_BLGroupCode] = goodsUnitData.BLGroupCode; // BLグループコード
                            printRow[PMHNB02145EB.ct_Col_Parts1_SuplierCode] = goodsUnitData.SupplierCd; // 仕入先コード

                            // 在庫リストのIndex検索
                            int index = GetStockListIndex(dr[PMHNB02145EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);

                            if (index != -1)
                            {
                                printRow[PMHNB02145EB.ct_Col_Parts1_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // 棚番
                                printRow[PMHNB02145EB.ct_Col_Parts1_SupplierStock] = goodsUnitData.StockList[index].SupplierStock; // 現在庫（仕入在庫数）
                            }
                            
                            // 価格情報のインデックスを取得
                            index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

                            if (index != -1)
                            {
                                printRow[PMHNB02145EB.ct_Col_Parts1_GoodsPrice] = goodsUnitData.GoodsPriceList[index].ListPrice; // 価格
                            }

                            // 優良品月次集計データ情報1
                            ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])[i];

                            printRow[PMHNB02145EB.ct_Col_Parts1_StockTotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount;
                            printRow[PMHNB02145EB.ct_Col_Parts1_OrderTotalSalesCount] = shipGdsPrimeListResultWork.Or_TotalSalesCount;
                            printRow[PMHNB02145EB.ct_Col_Parts_StockTotalSalesCountSum] = (double)printRow[PMHNB02145EB.ct_Col_Parts_StockTotalSalesCountSum] + shipGdsPrimeListResultWork.St_TotalSalesCount;
                            printRow[PMHNB02145EB.ct_Col_Parts_OrderTotalSalesCountSum] = (double)printRow[PMHNB02145EB.ct_Col_Parts_OrderTotalSalesCountSum] + shipGdsPrimeListResultWork.Or_TotalSalesCount;

                            // 粗利率計算
                            pureSalesMoneySum = shipGdsPrimeListResultWork.St_SalesMoney + shipGdsPrimeListResultWork.St_SalesRetGoodsPrice + shipGdsPrimeListResultWork.St_DiscountPrice
                                                     + shipGdsPrimeListResultWork.Or_SalesMoney + shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice + shipGdsPrimeListResultWork.Or_DiscountPrice;

                            grossProfitSum = shipGdsPrimeListResultWork.St_GrossProfit + shipGdsPrimeListResultWork.Or_GrossProfit;

                            printRow[PMHNB02145EB.ct_Col_Parts1_GrossProfitRate] = this.GetRatio(grossProfitSum, pureSalesMoneySum); // 粗利率 

                            // 1行に含まれる優良品数 (2つある場合は上書き)
                            printRow[PMHNB02145EB.ct_Col_PartsCount] = 1;
                            #endregion

                            #region 優良品情報2
                            // 優良品情報2設定
                            if (i + 1 < (Int32)dr[PMHNB02145EA.ct_Col_PartsCount])
                            {
                                goodsUnitData = ((List<GoodsUnitData>)(dr[PMHNB02145EA.ct_Col_GoodsUnitDataList]))[i + 1];

                                printRow[PMHNB02145EB.ct_Col_Parts2_GoodsNo] = goodsUnitData.GoodsNo; // 品番
                                printRow[PMHNB02145EB.ct_Col_Parts2_MakerCode] = goodsUnitData.GoodsMakerCd; // メーカーコード
                                printRow[PMHNB02145EB.ct_Col_Parts2_BLGroupCode] = goodsUnitData.BLGroupCode; // BLグループコード
                                printRow[PMHNB02145EB.ct_Col_Parts2_SuplierCode] = goodsUnitData.SupplierCd; // 仕入先コード

                                // 在庫リストのIndex検索
                                index = GetStockListIndex(dr[PMHNB02145EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);

                                if (index != -1)
                                {
                                    printRow[PMHNB02145EB.ct_Col_Parts2_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // 棚番
                                    printRow[PMHNB02145EB.ct_Col_Parts2_SupplierStock] = goodsUnitData.StockList[index].SupplierStock; // 現在庫（仕入在庫数）
                                }

                                // 価格情報のインデックスを取得
                                index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

                                if (index != -1)
                                {
                                    printRow[PMHNB02145EB.ct_Col_Parts2_GoodsPrice] = goodsUnitData.GoodsPriceList[index].ListPrice; // 価格
                                }

                                // 優良品月次集計データ情報2
                                //shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])[i]; // DEL 2008/12/09
                                shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])[i + 1]; // ADD 2008/12/12

                                printRow[PMHNB02145EB.ct_Col_Parts2_StockTotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount;
                                printRow[PMHNB02145EB.ct_Col_Parts2_OrderTotalSalesCount] = shipGdsPrimeListResultWork.Or_TotalSalesCount;
                                printRow[PMHNB02145EB.ct_Col_Parts_StockTotalSalesCountSum] = (double)printRow[PMHNB02145EB.ct_Col_Parts_StockTotalSalesCountSum] + shipGdsPrimeListResultWork.St_TotalSalesCount;
                                printRow[PMHNB02145EB.ct_Col_Parts_OrderTotalSalesCountSum] = (double)printRow[PMHNB02145EB.ct_Col_Parts_OrderTotalSalesCountSum] + shipGdsPrimeListResultWork.Or_TotalSalesCount;

                                // 粗利率計算
                                pureSalesMoneySum = shipGdsPrimeListResultWork.St_SalesMoney + shipGdsPrimeListResultWork.St_SalesRetGoodsPrice + shipGdsPrimeListResultWork.St_DiscountPrice
                                                         + shipGdsPrimeListResultWork.Or_SalesMoney + shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice + shipGdsPrimeListResultWork.Or_DiscountPrice;

                                grossProfitSum = shipGdsPrimeListResultWork.St_GrossProfit + shipGdsPrimeListResultWork.Or_GrossProfit;

                                printRow[PMHNB02145EB.ct_Col_Parts2_GrossProfitRate] = this.GetRatio(grossProfitSum, pureSalesMoneySum); // 粗利率 
                                
                                // 1行に含まれる優良品数
                                printRow[PMHNB02145EB.ct_Col_PartsCount] = 2;
                            }
                            #endregion

                            this._printDt.Rows.Add(printRow);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetRatio(Int64 num, Int64 den)
        {
            decimal workRate;

            decimal numerator = Convert.ToDecimal(num);
            decimal denominator = Convert.ToDecimal(den);

            if (denominator == 0)
            {
                workRate = 0.00M;
            }
            else
            {
                workRate = (numerator / denominator) * 100;
            }
            //if (workRate < 0) workRate = workRate * -1; // DEL 2009/01/15

            return Convert.ToDouble(workRate);
        }

        #endregion

        #region テストデータ
        /// <summary>
        /// テストデータ(純正品検索)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcPure(out object obj)
        {
            ArrayList paramlist = new ArrayList();

            ShipGdsPrimeListResultWork param = new ShipGdsPrimeListResultWork();

            param.EnterpriseCode = "0101150842020000"; // 企業コード
            param.AddUpSecCode = "01    "; // 計上拠点コード
            param.SectionGuideSnm = "拠点1"; // 拠点ガイド名称
            param.GoodsMakerCd = 1; // メーカーコード
            param.GoodsNo = "90915-10003"; // 商品番号
            param.St_SalesTimes = 10000; // 売上回数(在庫)
            param.St_TotalSalesCount = 10000; // 売上数計(在庫)
            param.St_SalesMoney = 10000; // 売上金額(在庫)
            param.St_SalesRetGoodsPrice = 10000; // 返品額(在庫)
            param.St_DiscountPrice = 10000; // 値引金額(在庫)
            param.St_GrossProfit = 10000; // 粗利金額(在庫)
            param.Or_SalesTimes = 10000; // 売上回数(取寄)
            param.Or_TotalSalesCount = 10000; // 売上数計(取寄)
            param.Or_SalesMoney = 10000; // 売上金額(取寄)
            param.Or_SalesRetGoodsPrice = 10000; // 返品額(取寄)
            param.Or_DiscountPrice = 10000; // 値引金額(取寄)
            param.Or_GrossProfit = 10000; // 粗利金額(取寄)

            paramlist.Add(param);

            obj = (object)paramlist;

            return 0;
        }


        /// <summary>
        /// テストデータ(商品マスタ検索)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcGoods(out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            GoodsUnitData goods1 = new GoodsUnitData();

            goods1.EnterpriseCode = "0101150842020000"; // 企業コード
            goods1.SectionCode = "01    "; // 計上拠点コード
            goods1.GoodsMakerCd = 2; // メーカーコード
            goods1.GoodsNo = "test2"; // 商品番号
            goods1.SupplierCd = 2;

            goods1.StockList = new List<Stock>();
            goods1.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods1);

            GoodsUnitData goods2 = new GoodsUnitData();

            goods2.EnterpriseCode = "0101150842020000"; // 企業コード
            goods2.SectionCode = "01    "; // 計上拠点コード
            goods2.GoodsMakerCd = 3; // メーカーコード
            goods2.GoodsNo = "test3"; // 商品番号
            goods2.SupplierCd = 3;

            goods2.StockList = new List<Stock>();
            goods2.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods2);

            GoodsUnitData goods3 = new GoodsUnitData();

            goods3.EnterpriseCode = "0101150842020000"; // 企業コード
            goods3.SectionCode = "01    "; // 計上拠点コード
            goods3.GoodsMakerCd = 4; // メーカーコード
            goods3.GoodsNo = "test4"; // 商品番号
            goods3.SupplierCd = 4;

            goods3.StockList = new List<Stock>();
            goods3.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods3); 

            return 0;
        }

        /// <summary>
        /// テストデータ(優良品検索)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcParts(out object obj)
        {
            ArrayList paramlist = new ArrayList();

            ShipGdsPrimeListResultWork param = new ShipGdsPrimeListResultWork();

            param.EnterpriseCode = "0101150842020000"; // 企業コード
            param.AddUpSecCode = "01    "; // 計上拠点コード
            param.SectionGuideSnm = "拠点1"; // 拠点ガイド名称
            param.GoodsMakerCd = 2; // メーカーコード
            param.GoodsNo = "test1"; // 商品番号
            param.St_SalesTimes = 20000; // 売上回数(在庫)
            param.St_TotalSalesCount = 20000; // 売上数計(在庫)
            param.St_SalesMoney = 20000; // 売上金額(在庫)
            param.St_SalesRetGoodsPrice = 20000; // 返品額(在庫)
            param.St_DiscountPrice = 20000; // 値引金額(在庫)
            param.St_GrossProfit = 20000; // 粗利金額(在庫)
            param.Or_SalesTimes = 20000; // 売上回数(取寄)
            param.Or_TotalSalesCount = 20000; // 売上数計(取寄)
            param.Or_SalesMoney = 20000; // 売上金額(取寄)
            param.Or_SalesRetGoodsPrice = 20000; // 返品額(取寄)
            param.Or_DiscountPrice = 20000; // 値引金額(取寄)
            param.Or_GrossProfit = 20000; // 粗利金額(取寄)

            paramlist.Add(param);

            obj = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
