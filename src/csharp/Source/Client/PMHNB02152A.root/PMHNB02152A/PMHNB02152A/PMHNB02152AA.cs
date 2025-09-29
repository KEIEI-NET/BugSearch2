using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 出荷商品優良対応表2アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 出荷商品優良対応表2で使用するデータを取得する。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.25</br>
    /// <br>Update Note  : 2008.12.09 30452 上野 俊治</br>
    /// <br>              ・結合品が無い場合も合計値をセットするよう修正。(フィルタ処理用)</br>
    /// <br>Update Note  : 2009.01.13 30452 上野 俊治</br>
    /// <br>              ・障害対応9687（優良品情報検索時、商品連結データ不足情報設定処理を追加）</br>
    /// <br>Update Note  : 2009.01.13 30452 上野 俊治</br>
    /// <br>              ・障害対応9544（リモートより拠点リストにない拠点コードが返る場合、</br>
    /// <br>              　印刷対象とするよう修正。取得出来ない項目は空白にする。）</br>
    /// <br>Update Note  : 2009.01.15 30452 上野 俊治</br>
    /// <br>              ・障害対応10098（在庫リストindex取得時、拠点コードの条件を削除）</br>
    /// <br>Update Note  : 2009.02.13 30452 上野 俊治</br>
    /// <br>              ・障害対応11281（商品マスタに存在しない場合も印字対象とするよう修正）</br>
    /// <br>Update Note  : 2009.02.17 30452 上野 俊治</br>
    /// <br>              ・障害対応11531（速度アップ対応）</br>
    /// <br>Update Note  : 2009/02/27 30452 上野 俊治</br>
    /// <br>              ・障害対応12036（グループコードはリモート抽出結果より取得するよう修正）</br>
    /// <br>Update Note  : 2014/12/30 尹晶晶</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更</br>
    /// <br>Update Note  : 2015/03/05 劉超</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更 システム障害の対応(品番表示)</br>
    /// <br>Update Note  : 2015/04/02 李侠</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更 システム障害の対応(仕入先の補足の判断)</br>
    /// <br>Update Note  : 2015/04/10 時シン</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :「出力区分」が有効になっている対応</br>
    /// <br>Update Note  : 2015/04/13 時シン</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             : Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応</br>
    /// </remarks>
    public class ShipGdsPrimeListAsc2
    {
        #region ■ コンストラクタ
		/// <summary>
        /// 出荷商品優良対応表2アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 出荷商品優良対応表2アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public ShipGdsPrimeListAsc2()
		{
            this._iShipGdsPrimeListResultWorkDB = (IShipGdsPrimeListResultWorkDB)MediationShipGdsPrimeListResultWorkDB.GetShipGdsPrimeListResultWorkDB();

            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd(); // ADD 2009/02/17
            string loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(); // ADD 2009/02/17
            string msg;

            this._goodsAcs = new GoodsAcs(); // 商品マスタ
            this._goodsAcs.SearchInitial(enterpriseCode, loginSectionCode, out msg); // ADD 2009/02/17
            //this._joinPartsUAcs = new JoinPartsUAcs(); // 結合マスタ // DEL 2009/02/17
		}

		/// <summary>
        /// 出荷商品優良対応表2アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 出荷商品優良対応表2アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.25</br>
		/// </remarks>
        static ShipGdsPrimeListAsc2()
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
        //private JoinPartsUAcs _joinPartsUAcs; // 結合マスタ // DEL 2009/02/17
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
        /// <br>Date         : 2008.11.25</br>
        /// </remarks>
        public int SearchMain(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2, out string errMsg)
        {
            return this.SearchProc(shipGdsPrimeListCndtn2, out errMsg);
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
        private int SearchProc(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            // 検索元情報取得(リモート検索、商品マスタ検索)
            status = this.SearchMainInfo(shipGdsPrimeListCndtn2, ref errMsg);
            if (this._shipGdsPrimeListDt.Rows.Count == 0)
            {
                // 画面指定の商品0件の場合エラー。
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 検索先情報取得(リモート検索、商品マスタ検索)
            this.SearchSubInfo(shipGdsPrimeListCndtn2, ref errMsg);

            // 帳票印字用テーブル作成
            this.MakePrintTable(shipGdsPrimeListCndtn2);
            if (this._printDt.Rows.Count == 0)
            {
                // 印字対象0行の場合エラー。
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // DataView作成
            this._printDv = new DataView(this._printDt, this.GetFilterString(shipGdsPrimeListCndtn2), this.GetSortString(), DataViewRowState.CurrentRows);

            if (this._printDv.Count == 0)
            {
                // 印字対象0行の場合エラー。
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

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
        /// <br>Date         : 2008.11.25</br>
        /// </remarks>
        private int SearchMainInfo(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2, ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02155EA.CreateDataTable(ref this._shipGdsPrimeListDt);

                ShipGdsPrimeListCndtnWork shipGdsPrimeListCndtnWork = new ShipGdsPrimeListCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevListCndtn(shipGdsPrimeListCndtn2, out shipGdsPrimeListCndtnWork, ref errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iShipGdsPrimeListResultWorkDB.Search(out retWorkList, shipGdsPrimeListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // テスト用
                //status = this.testProcMain(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevListData(shipGdsPrimeListCndtn2, (ArrayList)retWorkList, ref errMsg);
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
        /// <br>Date         : 2008.11.25</br>
        /// <br>Update Note  : 2014/12/30 尹晶晶</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更</br>
        /// </remarks>
        private int DevListCndtn(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn, out ShipGdsPrimeListCndtnWork shipGdsPrimeListCndtnWork, ref string errMsg)
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

                if (shipGdsPrimeListCndtn.PrintType == ShipGdsPrimeListCndtn2.PrintTypeState.Month)
                {
                    shipGdsPrimeListCndtnWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AddUpYearMonth; // 開始対象年月
                    shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AddUpYearMonth; // 終了対象年月
                }
                else
                {
                    shipGdsPrimeListCndtnWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AnnualAddUpYearMonth; // 開始対象年月
                    shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AnnualAddUpYearMonth; // 終了対象年月
                }

                // 開始メーカーコード
                if (shipGdsPrimeListCndtn.St_GoodsMakerCd == 0)
                {
                    if (shipGdsPrimeListCndtn.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                    {
                        shipGdsPrimeListCndtnWork.St_GoodsMakerCd = 0;
                    }
                    else
                    {
                        shipGdsPrimeListCndtnWork.St_GoodsMakerCd = 100;
                    }
                }
                else
                {
                    shipGdsPrimeListCndtnWork.St_GoodsMakerCd = shipGdsPrimeListCndtn.St_GoodsMakerCd;
                }

                // 終了メーカーコード
                if (shipGdsPrimeListCndtn.Ed_GoodsMakerCd == 0)
                {
                    if (shipGdsPrimeListCndtn.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                    {
                        shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = 99;
                    }
                    else
                    {
                        shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = 9999;
                    }
                }
                else
                {
                    shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = shipGdsPrimeListCndtn.Ed_GoodsMakerCd;
                }

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

                shipGdsPrimeListCndtnWork.ShipCount = shipGdsPrimeListCndtn.ShipCount; // 出荷回数

                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                shipGdsPrimeListCndtnWork.GoodsNoTtlDiv = (int)shipGdsPrimeListCndtn.GoodsNoTtlDiv; // 品番集計区分
                if (shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    shipGdsPrimeListCndtnWork.GoodsNoShowDiv = (int)shipGdsPrimeListCndtn.GoodsNoShowDiv; // 品番表示区分
                }
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
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
        /// <br>Date         : 2008.11.25</br>
        /// <br>Update Note  : 2014/12/30 尹晶晶</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更</br>
        /// <br>Update Note  : 2015/03/05 劉超</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更 システム障害対応(品番表示)</br>
        /// <br>Update Note  : 2015/04/10 時シン</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :「出力区分」が有効になっている対応</br>
        /// </remarks>
        private void DevListData(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn, ArrayList resultWork, ref string errMsg)
        {
            // リモート抽出結果をリモート抽出結果用DataTable(PMHNB02155EA)に展開
            DataRow dr;

            GoodsCndtn goodsCndtn = new GoodsCndtn(); // ADD 2009/02/17
            bool stockFlag = false;  // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応
            foreach (ShipGdsPrimeListResultWork shipGdsPrimeListResultWork in resultWork)
            {
                stockFlag = false;  // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応
                dr = this._shipGdsPrimeListDt.NewRow();

                dr[PMHNB02155EA.ct_Col_EnterpriseCode] = shipGdsPrimeListResultWork.EnterpriseCode; // 企業コード
                dr[PMHNB02155EA.ct_Col_AddUpSecCode] = shipGdsPrimeListResultWork.AddUpSecCode; // 計上拠点コード
                dr[PMHNB02155EA.ct_Col_SectionGuideSnm] = shipGdsPrimeListResultWork.SectionGuideSnm; // 拠点ガイド名称
                dr[PMHNB02155EA.ct_Col_GoodsMakerCd] = shipGdsPrimeListResultWork.GoodsMakerCd; // メーカーコード
                //dr[PMHNB02155EA.ct_Col_GoodsNo] = shipGdsPrimeListResultWork.GoodsNo; // 商品番号  // DEL  2014/12/30 尹晶晶 FOR Redmine#44209改良
                dr[PMHNB02155EA.ct_Col_St_SalesTimes] = shipGdsPrimeListResultWork.St_SalesTimes; // 売上回数(在庫)
                dr[PMHNB02155EA.ct_Col_St_TotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount; // 売上数計(在庫)
                dr[PMHNB02155EA.ct_Col_St_SalesMoney] = shipGdsPrimeListResultWork.St_SalesMoney; // 売上金額(在庫)
                dr[PMHNB02155EA.ct_Col_St_SalesRetGoodsPrice] = shipGdsPrimeListResultWork.St_SalesRetGoodsPrice; // 返品額(在庫)
                dr[PMHNB02155EA.ct_Col_St_DiscountPrice] = shipGdsPrimeListResultWork.St_DiscountPrice; // 値引金額(在庫)
                dr[PMHNB02155EA.ct_Col_St_GrossProfit] = shipGdsPrimeListResultWork.St_GrossProfit; // 粗利金額(在庫)
                dr[PMHNB02155EA.ct_Col_Or_SalesTimes] = shipGdsPrimeListResultWork.Or_SalesTimes; // 売上回数(取寄)
                dr[PMHNB02155EA.ct_Col_Or_TotalSalesCount] = shipGdsPrimeListResultWork.Or_TotalSalesCount; // 売上数計(取寄)
                dr[PMHNB02155EA.ct_Col_Or_SalesMoney] = shipGdsPrimeListResultWork.Or_SalesMoney; // 売上金額(取寄)
                dr[PMHNB02155EA.ct_Col_Or_SalesRetGoodsPrice] = shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice; // 返品額(取寄)
                dr[PMHNB02155EA.ct_Col_Or_DiscountPrice] = shipGdsPrimeListResultWork.Or_DiscountPrice; // 値引金額(取寄)
                dr[PMHNB02155EA.ct_Col_Or_GrossProfit] = shipGdsPrimeListResultWork.Or_GrossProfit; // 粗利金額(取寄)
                dr[PMHNB02155EA.ct_Col_BLGroupCode] = shipGdsPrimeListResultWork.BLGroupCode; // グループコード // ADD 2009/02/13

                List<GoodsUnitData> goodsUnitDataList;
                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                // 品番集計区分は「合算」且つ品番表示区分が「旧品番」場合
                int status;
                string disGoodsNo = string.Empty; //ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更のシステム障害対応(品番の表示)
                if ((shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total) &&
                    (shipGdsPrimeListCndtn.GoodsNoShowDiv == ShipGdsPrimeListCndtn2.GoodsNoShowDivState.Old))
                {
                    goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
                    goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;
                    // 旧品番表示の場合、旧品番を一時退避します。
                    disGoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;//ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示)
                    goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                    // 品番表示区分が「旧品番」場合、商品マスタを取る。
                    //status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg); // DEL 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応
                    //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------>>>>>
                    goodsCndtn.IsSettingSupplier = 1;
                    goodsCndtn.IsSettingVariousMst = 1;
                    goodsCndtn.GoodsKindCode = 9;
                    this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);
                    //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------<<<<<
                    if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                    {
                        //  旧商品マスタが存在しない場合、新品番の商品マスタを取る。
                        goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                        //status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg); // DEL 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応            
                        //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------>>>>>
                        this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);
                        if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                        {
                            // 新商品がないため、提供分データを取得します。
                            status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg);
                        }
                        //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------<<<<<
                    }
                    else
                    {
                        // 何もしない
                    }
                }
                else if ((shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total) &&
                    (shipGdsPrimeListCndtn.GoodsNoShowDiv == ShipGdsPrimeListCndtn2.GoodsNoShowDivState.New))
                {
                    goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
                    goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                    // 新品番表示の場合、新品番を一時退避します。
                    disGoodsNo = shipGdsPrimeListResultWork.GoodsNo;//ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示)
                    goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                    // 品番表示区分が「新品番」場合、商品マスタを取る。
                    //status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg); // DEL 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応
                    //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------>>>>>
                    goodsCndtn.IsSettingSupplier = 1;
                    goodsCndtn.IsSettingVariousMst = 1;
                    goodsCndtn.GoodsKindCode = 9;
                    this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);
                    //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------<<<<<
                    if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                    {
                        //  新商品マスタが存在しない場合、旧品番の商品マスタを取る。
                        goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;
                        //status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg); // DEL 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応            
                        //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------>>>>>
                        this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);
                        if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                        {
                            // 新商品がないため、提供分データを取得します。
                            goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                            status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg);
                        }
                        //----- ADD 2015/04/13 時シン Redmine#45436 NO.74 品番集計区分「合算」品番表示区分「旧品番」で出力すると、棚番が取得されない対応------<<<<<
                    }
                    else
                    {
                        // 何もしない
                    }
                }
                else
                {
                    goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
                    goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                    goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                    // 商品情報取得
                    status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg);
                }
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
                //------ DEL START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                // 商品情報取得
                //int status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg);
                //------ DEL START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>

                // テスト用
                //int status = this.testProcMainGoods(out goodsUnitDataList);

                // --- DEL 2009/02/13 -------------------------------->>>>>
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                //    || goodsUnitDataList.Count == 0)
                //{
                //    // 0件の場合、印字対象にしない
                //    continue;
                //}
                // --- DEL 2009/02/13 --------------------------------<<<<<

                //if (goodsUnitDataList.Count != 0)                                 //DEL 2014/12/30 尹晶晶 FOR Redmine#44209改良
                if (goodsUnitDataList != null && goodsUnitDataList.Count != 0)      //ADD 2014/12/30 尹晶晶 FOR Redmine#44209改良
                {
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                    // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 ----->>>>>
                    if (goodsUnitData.StockList != null && goodsUnitData.StockList.Count > 0)
                    {
                        stockFlag = true;
                    }
                    // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 -----<<<<<

                    //dr[PMHNB02155EA.ct_Col_GoodsNo] = goodsUnitData.GoodsNo;          //ADD 2014/12/30 尹晶晶 FOR Redmine#44209改良 //DEL 2015/03/05 劉超 明治産業様Seiken品番変更(品番の表示)
                    //------ ADD START 2015/03/05 劉超 明治産業様Seiken品番変更(品番の表示) ------>>>>>
                    // 品番集計区分は「合算」
                    if (shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        // 一時退避した品番を商品マスタに切り替えします。
                        dr[PMHNB02155EA.ct_Col_GoodsNo] = disGoodsNo;　// 商品番号表示用
                        dr[PMHNB02155EA.ct_Col_OldGoodsNo] = goodsUnitData.GoodsNo; // 商品番号検索用
                    }
                    else
                    {
                        // 品番集計区分は「別々」の場合
                        dr[PMHNB02155EA.ct_Col_GoodsNo] = goodsUnitData.GoodsNo;// 商品番号表示用
                        dr[PMHNB02155EA.ct_Col_OldGoodsNo] = goodsUnitData.GoodsNo; // 商品番号検索用
                    }
                    //------ ADD END 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示) ------<<<<<
                    //dr[PMHNB02155EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // BLグループコード // DEL 2009/02/27
                    dr[PMHNB02155EA.ct_Col_GoodsName] = goodsUnitData.GoodsNameKana; // 品名
                    dr[PMHNB02155EA.ct_Col_GoodsLGroup] = goodsUnitData.GoodsLGroup; // 商品大分類
                    dr[PMHNB02155EA.ct_Col_GoodsMGroup] = goodsUnitData.GoodsMGroup; // 商品中分類
                    if (shipGdsPrimeListResultWork.BLGroupCode == 0) // ADD 2009/02/27
                    {
                        dr[PMHNB02155EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // グループコード
                    }

                    // 在庫リストのIndex検索
                    //int index = GetStockListIndex(shipGdsPrimeListResultWork, goodsUnitData); //DEL 2015/03/05 劉超 明治産業様Seiken品番変更(品番の表示)
                    //------ ADD START 2015/03/05 劉超 明治産業様Seiken品番変更(品番の表示) ------>>>>>
                    int index = GetStockListIndex(dr[PMHNB02155EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);
                    //------ ADD END 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示) ------<<<<<

                    if (index != -1)
                    {
                        dr[PMHNB02155EA.ct_Col_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // 棚番
                    }
                    else
                    {
                        // 在庫リストが0件の場合、表示は行う。（棚番はstring.empty）
                    }
                }
                //------ ADD START 2015/03/05 劉超 明治産業様Seiken品番変更(品番の表示) ------>>>>>
                // 商品情報が存在しない場合、実績の品番を表示します。
                else
                {
                    // 品番集計区分は「合算」
                    if (shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        // 一時退避した品番を商品マスタに切り替えします。
                        dr[PMHNB02155EA.ct_Col_GoodsNo] = disGoodsNo;　// 商品番号表示用
                        dr[PMHNB02155EA.ct_Col_OldGoodsNo] = disGoodsNo; // 商品番号検索用
                    }
                    else
                    {
                        // 品番集計区分は「別々」の場合
                        dr[PMHNB02155EA.ct_Col_GoodsNo] = shipGdsPrimeListResultWork.GoodsNo;// 商品番号表示用
                        dr[PMHNB02155EA.ct_Col_OldGoodsNo] = shipGdsPrimeListResultWork.GoodsNo; // 商品番号検索用
                    }
                }
                //------ ADD END 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示) ------<<<<<

                dr[PMHNB02155EA.ct_Col_StockYNFlag] = stockFlag;// ADD 2015/04/10 時シン 「出力区分」が有効になっている対応
                this._shipGdsPrimeListDt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 商品情報取得処理
        /// </summary>
        /// <param name="shipGdsPrimeListResultWork"></param>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <br>Update Note  : 2014/12/30 尹晶晶</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更</br>
        private int GetGoodsUnitDataList(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, GoodsCndtn goodsCndtn,
            out List<GoodsUnitData> goodsUnitDataList, out string errMsg)
        {
            //GoodsCndtn goodsCndtn = new GoodsCndtn(); // DEL 2009/02/17
            //------ DEL START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            //goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
            //goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
            //goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
            //------ DEL START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>

            goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/17
            goodsCndtn.IsSettingVariousMst = 1; // ADD 2009/02/17

            int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out errMsg);

            return status;
        }

        /// <summary>
        /// 条件に合致する在庫リストのindexを取得する
        /// </summary>
        /// <returns></returns>
        private int GetStockListIndex(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, GoodsUnitData goodsUnitData)
        {
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

        // <summary>
        /// 検索先情報取得
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       　: 検索先の情報を取得する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.25</br>
        /// <br>Update Note  : 2014/12/30 尹晶晶</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更</br>
        /// <br>Update Note  : 2015/03/05 劉超</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更 システム障害対応(品番表示)</br>
        /// <br>Update Note  : 2015/04/02 李侠</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更 システム障害の対応(仕入先の補足の判断)</br>
        /// <br>Update Note  : 2015/04/10 時シン</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :「出力区分」が有効になっている対応</br>
        /// </remarks>
        private void SearchSubInfo(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2, ref string errMsg)
        {
            GoodsCndtn goodsCndtn = new GoodsCndtn(); // ADD 2009/02/17
            ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // ADD 2009/02/17
            bool stockFlag = false; // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応

            // 検索元1件毎に処理
            foreach (DataRow dr in this._shipGdsPrimeListDt.Rows)
            {
                stockFlag = false; // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応
                // 商品情報取得
                //GoodsCndtn goodsCndtn = new GoodsCndtn(); // DEL 2009/02/17

                goodsCndtn.EnterpriseCode = dr[PMHNB02155EA.ct_Col_EnterpriseCode].ToString();
                //goodsCndtn.GoodsNo = dr[PMHNB02155EA.ct_Col_GoodsNo].ToString(); //DEL 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示)
                goodsCndtn.GoodsNo = dr[PMHNB02155EA.ct_Col_OldGoodsNo].ToString();//ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示)
                goodsCndtn.GoodsMakerCd = (int)dr[PMHNB02155EA.ct_Col_GoodsMakerCd];

                goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/17
                goodsCndtn.IsSettingVariousMst = 1; // ADD 2009/02/17
                
                PartsInfoDataSet partsInfoDataSet;
                List<GoodsUnitData> GoodsUnitDataList;
                string msg;

                if (shipGdsPrimeListCndtn2.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                {
                    // 純正品から優良品の検索の場合、拠点コードと結合検索区分を追加
                    goodsCndtn.SectionCode = dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString();
                    goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;

                    // 商品マスタ検索(純正品から優良品検索)
                    this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, false, out partsInfoDataSet, out GoodsUnitDataList, out msg);

                    // 結合子データのみを取出し
                    this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet,
                        goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, GoodsAcs.GoodsKind.ChildJoin, out GoodsUnitDataList);

                    // テスト用
                    //this.testProcSubGoods(out GoodsUnitDataList);
                }
                else
                {
                    // 商品マスタ検索(優良品から純正品検索)
                    this._goodsAcs.SearchPartsForSrcParts(goodsCndtn, out partsInfoDataSet, out GoodsUnitDataList, out msg);

                    // テスト用
                    //this.testProcSubGoods(out GoodsUnitDataList);
                }

                // 帳票印字対象結合品 情報リスト
                List<GoodsUnitData> printGoodsUnitDataList = new List<GoodsUnitData>();
                ArrayList printShipGdsPrimeListResultList = new ArrayList();

                // 商品別売上月次集計データ情報取得
                for (int i = 0; i < GoodsUnitDataList.Count; i++)
                {
                    GoodsUnitData goodsUnitData = GoodsUnitDataList[i];

                    //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    int joinDispOrder = 0;
                    if (shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        joinDispOrder = goodsUnitData.JoinDispOrder; // 結合表示順位
                    }
                    //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                    //ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // DEL 2009/02/17

                    // 抽出条件展開  --------------------------------------------------------------
                    int status = this.DevPartnerListCndtn(shipGdsPrimeListCndtn2, dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString(), goodsUnitData,
                                                          ref shipGdsPrmListCndtnPartnerWork);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        continue;
                    }

                    ArrayList shipGdsPrmListCndtnPartnerWorkList = new ArrayList();
                    shipGdsPrmListCndtnPartnerWorkList.Add(shipGdsPrmListCndtnPartnerWork);

                    object retWorkList = null;

                    // リモート検索(検索先)
                    status = this._iShipGdsPrimeListResultWorkDB.SearchPartner(out retWorkList, shipGdsPrmListCndtnPartnerWorkList, 0, ConstantManagement.LogicalMode.GetData0);

                    // テスト用
                    //this.testProcSub(out retWorkList);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        || ((ArrayList)retWorkList).Count == 0)
                    {
                        continue;
                    }

                    //------ DEL START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 新旧商品を確定した後、商品連結データを取得する。
                    //// --- ADD 2009/01/13 -------------------------------->>>>>
                    //if (shipGdsPrimeListCndtn2.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                    //{
                    //    // 商品連結データ不足情報設定処理呼出し
                    //    //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData); // DEL 2009/02/17
                    //    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1); // ADD 2009/02/17
                    //}
                    //// --- ADD 2009/01/13 --------------------------------<<<<<
                    //------ DEL END 2014/12/30 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                    string shipGoodsNo = string.Empty;
                    ArrayList resultList = retWorkList as ArrayList;
                    string tempGoodsNo = string.Empty; //ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更のシステム障害対応(品番の表示)
                    ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = new ShipGdsPrimeListResultWork();
                    for (int j = 0; j < resultList.Count; j++)
                    {
                        shipGdsPrimeListResultWork = resultList[j] as ShipGdsPrimeListResultWork;
                    }
                    //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                    // 品番集計区分は「合算」且つ品番表示区分が「旧品番」場合
                    if ((shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total) &&
                        (shipGdsPrimeListCndtn2.GoodsNoShowDiv == ShipGdsPrimeListCndtn2.GoodsNoShowDivState.Old))
                    {
                        GoodsCndtn goodsCndtnChg = new GoodsCndtn();
                        List<GoodsUnitData> GoodsUnitDataListChg;
                        goodsCndtnChg.EnterpriseCode = shipGdsPrimeListCndtn2.EnterpriseCode;
                        //goodsCndtnChg.SectionCode = dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString();
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
                    else if ((shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total) &&
                        (shipGdsPrimeListCndtn2.GoodsNoShowDiv == ShipGdsPrimeListCndtn2.GoodsNoShowDivState.New))
                    {
                        GoodsCndtn goodsCndtnChg = new GoodsCndtn();
                        List<GoodsUnitData> GoodsUnitDataListChg;
                        goodsCndtnChg.EnterpriseCode = shipGdsPrimeListCndtn2.EnterpriseCode;
                        //goodsCndtnChg.SectionCode = dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString();
                        goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                        // 新品番表示の場合、新品番を一時退避します。
                        tempGoodsNo = shipGdsPrimeListResultWork.GoodsNo;//ADD 2015/03/05 劉超 FOR 明治産業様Seiken品番変更(品番の表示)
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

                    if (shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        goodsUnitData.JoinDispOrder = joinDispOrder; // 結合表示順位
                    }

                    //------ ADD START 2015/04/02 李侠 明治産業様Seiken品番変更(仕入先の補足の判断) ------>>>>>
                    if (shipGdsPrimeListCndtn2.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                    {
                        //------ ADD END 2015/04/02 李侠 明治産業様Seiken品番変更(仕入先の補足の判断) ------<<<<<
                        // 商品連結データ不足情報設定処理呼出し
                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1);
                    }// ADD 2015/04/02 李侠 明治産業様Seiken品番変更(仕入先の補足の判断)
                    //------ ADD START 2015/03/05 劉超 明治産業様Seiken品番変更(品番の表示) ------>>>>>
                    // 品番集計区分は「合算」
                    if (shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        // 一時退避した品番を商品マスタに切り替えします。
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
                    //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                    // 月次データまで正常に取得出来た場合のみ、印字用データに保存
                    // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 ----->>>>>
                    // 在庫品の判断
                    if (goodsUnitData.StockList != null && goodsUnitData.StockList.Count > 0)
                    {
                        stockFlag = true;
                    }
                    // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 -----<<<<<
                    printGoodsUnitDataList.Add(goodsUnitData);
                    printShipGdsPrimeListResultList.Add(((ArrayList)retWorkList)[0]);
                }

                // 結合品情報を保存
                // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 ----->>>>>
                if (stockFlag == true)
                {
                    dr[PMHNB02155EA.ct_Col_StockYNFlag] = stockFlag;
                }
                // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 -----<<<<<
                dr[PMHNB02155EA.ct_Col_PartsCount] = printGoodsUnitDataList.Count;
                dr[PMHNB02155EA.ct_Col_GoodsUnitDataList] = printGoodsUnitDataList;
                dr[PMHNB02155EA.ct_Col_ShipGdsPrimeListResultList] = printShipGdsPrimeListResultList;
            }
        }

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <param name="sectionCode"></param>
        /// <param name="goodsUnitData"></param>
        /// <param name="shipGdsPrmListCndtnPartnerWork"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       　: 画面抽出条件をリモート抽出条件へ展開する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.25</br>
        /// <br>Update Note  : 2014/12/30 尹晶晶</br>
        /// <br>管理番号     : 11070263-00</br>
        /// <br>             :・明治産業様Seiken品番変更</br>
        /// </remarks>
        private int DevPartnerListCndtn(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn, string sectionCode, GoodsUnitData goodsUnitData,
            ref ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // DEL 2009/02/17

            try
            {
                // 抽出条件より設定
                shipGdsPrmListCndtnPartnerWork.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;  // 企業コード
                shipGdsPrmListCndtnPartnerWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AddUpYearMonth; // 開始対象年月
                shipGdsPrmListCndtnPartnerWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AddUpYearMonth; // 終了対象年月
                //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
                shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv = (int)shipGdsPrimeListCndtn.GoodsNoTtlDiv; // 品番集計区分
                if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                {
                    shipGdsPrmListCndtnPartnerWork.GoodsNoShowDiv = (int)shipGdsPrimeListCndtn.GoodsNoShowDiv; // 品番表示区分
                }
                //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

                // 結合商品情報より設定
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

        /// <summary>
        /// 取得結合品データ展開処理
        /// </summary>
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <remarks>
        /// <br>Note       　: リモート抽出結果を帳票印字用DataTableへ展開する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.11.25</br>
        /// </remarks>
        private void DevPartnerListData(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn, ArrayList resultWork1, DataRow workDr, ref string errMsg)
        {
            foreach (ShipGdsPrimeListResultWork shipGdsPrimeListResultWork in resultWork1)
            {
                DataRow printDr = this._printDt.NewRow();


            }
        }

        /// <summary>
        /// 帳票印字用テーブルの1行データを作成する
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn">抽出条件</param>
        private void MakePrintTable(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn)
        {
            // 帳票印字用テーブル作成
            PMHNB02155EB.CreateDataTable(ref this._printDt);

            // 帳票印字用テーブルに追加する1行情報(PMHNB02155EB)
            DataRow printRow;

            // 売上回数(在庫)合計値保持Dic
            // Key:同検索元キー、Value:売上回数の合計
            Dictionary<int, int> stockSalesTimesDic = new Dictionary<int, int>();
            // 売上回数(取寄)合計値保持Dic
            Dictionary<int, int> orderSalesTimesDic = new Dictionary<int, int>();
            // 売上回数(合計)合計値保持Dic
            Dictionary<int, int> sumSalesTimesDic = new Dictionary<int, int>();

            for (int j = 0; j < this._shipGdsPrimeListDt.Rows.Count; j++ )
            {
                DataRow dr = this._shipGdsPrimeListDt.Rows[j];

                if ((Int32)dr[PMHNB02155EA.ct_Col_PartsCount] == 0)
                {
                    // DEL 2015/04/10 時シン 「出力区分」が有効になっている対応 ----->>>>>
                    //if (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.All
                    //|| shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Order)
                    // DEL 2015/04/10 時シン 「出力区分」が有効になっている対応 -----<<<<<
                    // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 ----->>>>>
                    if (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.All
                        || (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Order && !(bool)dr[PMHNB02155EA.ct_Col_StockYNFlag])
                        || (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Stock && (bool)dr[PMHNB02155EA.ct_Col_StockYNFlag]))
                    // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 -----<<<<<
                    {
                        // 1行のみ作成
                        printRow = this._printDt.NewRow();

                        printRow[PMHNB02155EB.ct_Col_SubInfoCount] = 0; // 検索先情報(帳票右側)の有無
                        printRow[PMHNB02155EB.ct_Col_AddUpSecCode] = dr[PMHNB02155EA.ct_Col_AddUpSecCode]; // 拠点コード
                        printRow[PMHNB02155EB.ct_Col_SectionGuideSnm] = dr[PMHNB02155EA.ct_Col_SectionGuideSnm]; // 拠点略称
                        printRow[PMHNB02155EB.ct_Col_Main_WarehouseShelfNo] = dr[PMHNB02155EA.ct_Col_WarehouseShelfNo]; // 棚番
                        printRow[PMHNB02155EB.ct_Col_Main_BLGroupCode] = dr[PMHNB02155EA.ct_Col_BLGroupCode]; // グループコード
                        printRow[PMHNB02155EB.ct_Col_Main_GoodsNo] = dr[PMHNB02155EA.ct_Col_GoodsNo]; // 品番
                        printRow[PMHNB02155EB.ct_Col_Main_GoodsName] = dr[PMHNB02155EA.ct_Col_GoodsName]; // 品名
                        printRow[PMHNB02155EB.ct_Col_Main_St_SalesTimes] = dr[PMHNB02155EA.ct_Col_St_SalesTimes]; // 売上回数(在庫)
                        printRow[PMHNB02155EB.ct_Col_Main_Or_SalesTimes] = dr[PMHNB02155EA.ct_Col_Or_SalesTimes]; // 売上回数(取寄)
                        printRow[PMHNB02155EB.ct_Col_Main_Sum_SalesTimes] = (int)dr[PMHNB02155EA.ct_Col_St_SalesTimes]
                                                                               + (int)dr[PMHNB02155EA.ct_Col_Or_SalesTimes]; // 売上回数(合計)

                        // 同明細キー
                        printRow[PMHNB02155EB.ct_Col_DetailUnitKey] = j;

                        // ソート用項目
                        printRow[PMHNB02155EB.ct_Col_Sort_GoodsMakerCd] = dr[PMHNB02155EA.ct_Col_GoodsMakerCd]; // メーカーコード
                        printRow[PMHNB02155EB.ct_Col_Sort_GoodsLGroup] = dr[PMHNB02155EA.ct_Col_GoodsLGroup]; // 商品大分類コード
                        printRow[PMHNB02155EB.ct_Col_Sort_GoodsMGroup] = dr[PMHNB02155EA.ct_Col_GoodsMGroup]; // 商品中分類コード
                        printRow[PMHNB02155EB.ct_Col_Sort_BLGroupCode] = dr[PMHNB02155EA.ct_Col_BLGroupCode]; // グループコード

                        // --- ADD 2008/12/25 -------------------------------->>>>>
                        // フィルタ用項目(合計値)
                        printRow[PMHNB02155EB.ct_Col_SubTotal_St_SalesTimes] = dr[PMHNB02155EA.ct_Col_St_SalesTimes];
                        printRow[PMHNB02155EB.ct_Col_SubTotal_Or_SalesTimes] = dr[PMHNB02155EA.ct_Col_Or_SalesTimes];
                        printRow[PMHNB02155EB.ct_Col_SubTotal_Sum_SalesTimes] = (int)dr[PMHNB02155EA.ct_Col_St_SalesTimes]
                                                                               + (int)dr[PMHNB02155EA.ct_Col_Or_SalesTimes];
                        // --- ADD 2008/12/25 --------------------------------<<<<<

                        this._printDt.Rows.Add(printRow);
                    }
                }
                else
                {
                    // DEL 2015/04/10 時シン 「出力区分」が有効になっている対応 ----->>>>>
                    //if (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.All
                    //|| shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Stock)
                    // DEL 2015/04/10 時シン 「出力区分」が有効になっている対応 -----<<<<<
                    // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 ----->>>>>
                    if (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.All
                        || (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Order && !(bool)dr[PMHNB02155EA.ct_Col_StockYNFlag])
                        || (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Stock && (bool)dr[PMHNB02155EA.ct_Col_StockYNFlag]))
                    // ADD 2015/04/10 時シン 「出力区分」が有効になっている対応 -----<<<<<
                    {
                        // 結合品情報分 帳票印字行作成
                        for (int i = 0; i < (Int32)dr[PMHNB02155EA.ct_Col_PartsCount]; i++)
                        {
                            printRow = this._printDt.NewRow();

                            #region 検索元情報
                            printRow[PMHNB02155EB.ct_Col_SubInfoCount] = 1; // 検索先情報(帳票右側)の有無
                            printRow[PMHNB02155EB.ct_Col_AddUpSecCode] = dr[PMHNB02155EA.ct_Col_AddUpSecCode]; // 拠点コード
                            printRow[PMHNB02155EB.ct_Col_SectionGuideSnm] = dr[PMHNB02155EA.ct_Col_SectionGuideSnm]; // 拠点略称
                            printRow[PMHNB02155EB.ct_Col_Main_WarehouseShelfNo] = dr[PMHNB02155EA.ct_Col_WarehouseShelfNo]; // 棚番
                            printRow[PMHNB02155EB.ct_Col_Main_BLGroupCode] = dr[PMHNB02155EA.ct_Col_BLGroupCode]; // グループコード
                            printRow[PMHNB02155EB.ct_Col_Main_GoodsNo] = dr[PMHNB02155EA.ct_Col_GoodsNo]; // 品番
                            printRow[PMHNB02155EB.ct_Col_Main_GoodsName] = dr[PMHNB02155EA.ct_Col_GoodsName]; // 品名
                            printRow[PMHNB02155EB.ct_Col_Main_St_SalesTimes] = dr[PMHNB02155EA.ct_Col_St_SalesTimes]; // 売上回数(在庫)
                            printRow[PMHNB02155EB.ct_Col_Main_Or_SalesTimes] = dr[PMHNB02155EA.ct_Col_Or_SalesTimes]; // 売上回数(取寄)
                            printRow[PMHNB02155EB.ct_Col_Main_Sum_SalesTimes] = (int)dr[PMHNB02155EA.ct_Col_St_SalesTimes]
                                                                                   + (int)dr[PMHNB02155EA.ct_Col_Or_SalesTimes]; // 売上回数(合計)

                            // 同明細（同結合元）キー
                            printRow[PMHNB02155EB.ct_Col_DetailUnitKey] = j;

                            // ソート用項目
                            printRow[PMHNB02155EB.ct_Col_Sort_GoodsMakerCd] = dr[PMHNB02155EA.ct_Col_GoodsMakerCd]; // メーカーコード
                            printRow[PMHNB02155EB.ct_Col_Sort_GoodsLGroup] = dr[PMHNB02155EA.ct_Col_GoodsLGroup]; // 商品大分類コード
                            printRow[PMHNB02155EB.ct_Col_Sort_GoodsMGroup] = dr[PMHNB02155EA.ct_Col_GoodsMGroup]; // 商品中分類コード
                            printRow[PMHNB02155EB.ct_Col_Sort_BLGroupCode] = dr[PMHNB02155EA.ct_Col_BLGroupCode]; // グループコード
                            #endregion

                            #region 検索先情報

                            GoodsUnitData goodsUnitData = ((List<GoodsUnitData>)(dr[PMHNB02155EA.ct_Col_GoodsUnitDataList]))[i];

                            printRow[PMHNB02155EB.ct_Col_Sub_DisplayOrder] = goodsUnitData.JoinDispOrder; // 結合表示順位
                            printRow[PMHNB02155EB.ct_Col_Sub_GoodsNo] = goodsUnitData.GoodsNo; // 品番
                            printRow[PMHNB02155EB.ct_Col_Sub_MakerCode] = goodsUnitData.GoodsMakerCd; // メーカーコード
                            printRow[PMHNB02155EB.ct_Col_Sub_SuplierCode] = goodsUnitData.SupplierCd; // 仕入先コード

                            // 在庫リストのIndex検索
                            int index = GetStockListIndex(dr[PMHNB02155EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);

                            if (index != -1)
                            {
                                printRow[PMHNB02155EB.ct_Col_Sub_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // 棚番
                            }

                            // 結合品月次集計データ情報
                            ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)dr[PMHNB02155EA.ct_Col_ShipGdsPrimeListResultList])[i];

                            printRow[PMHNB02155EB.ct_Col_Sub_St_SalesTimes] = shipGdsPrimeListResultWork.St_SalesTimes; // 売上回数(在庫)
                            printRow[PMHNB02155EB.ct_Col_Sub_Or_SalesTimes] = shipGdsPrimeListResultWork.Or_SalesTimes; // 売上回数(取寄)
                            printRow[PMHNB02155EB.ct_Col_Sub_Sum_SalesTimes] = shipGdsPrimeListResultWork.St_SalesTimes + shipGdsPrimeListResultWork.Or_SalesTimes; // 売上回数(合計)

                            // 同明細計の取得
                            if (stockSalesTimesDic.ContainsKey(j))
                            {
                                // 同明細のDicがある場合は追加
                                stockSalesTimesDic[j] += shipGdsPrimeListResultWork.St_SalesTimes;
                                orderSalesTimesDic[j] += shipGdsPrimeListResultWork.Or_SalesTimes;
                                sumSalesTimesDic[j] += shipGdsPrimeListResultWork.St_SalesTimes + shipGdsPrimeListResultWork.Or_SalesTimes;
                            }
                            else
                            {
                                // 同明細のDicがない場合は新規
                                stockSalesTimesDic.Add(j, shipGdsPrimeListResultWork.St_SalesTimes);
                                orderSalesTimesDic.Add(j, shipGdsPrimeListResultWork.Or_SalesTimes);
                                sumSalesTimesDic.Add(j, shipGdsPrimeListResultWork.St_SalesTimes + shipGdsPrimeListResultWork.Or_SalesTimes);
                            }

                            #endregion

                            this._printDt.Rows.Add(printRow);
                        }
                    }
                }
            }

            // 検索先の合計値（棚番、在庫、取寄）設定
            foreach (DataRow dr in this._printDt.Rows)
            {
                if (stockSalesTimesDic.ContainsKey((int)dr[PMHNB02155EB.ct_Col_DetailUnitKey]))
                {
                    // 検索元の売上数計 + 検索先の売上数計
                    // 同明細(同検索元)の行には同じ合計値を設定、帳票側で表示制御を行う。
                    dr[PMHNB02155EB.ct_Col_SubTotal_St_SalesTimes] = (int)dr[PMHNB02155EB.ct_Col_Main_St_SalesTimes] + stockSalesTimesDic[(int)dr[PMHNB02155EB.ct_Col_DetailUnitKey]];
                    dr[PMHNB02155EB.ct_Col_SubTotal_Or_SalesTimes] = (int)dr[PMHNB02155EB.ct_Col_Main_Or_SalesTimes] + orderSalesTimesDic[(int)dr[PMHNB02155EB.ct_Col_DetailUnitKey]];
                    dr[PMHNB02155EB.ct_Col_SubTotal_Sum_SalesTimes] =(int)dr[PMHNB02155EB.ct_Col_Main_Sum_SalesTimes] +  sumSalesTimesDic[(int)dr[PMHNB02155EB.ct_Col_DetailUnitKey]];
                }
            }
        }

        /// <summary>
        /// 条件に合致する在庫リストのindexを取得する
        /// </summary>
        /// <returns></returns>
        private int GetStockListIndex(string enterpriseCode, string sectionCode, GoodsUnitData goodsUnitData)
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
            index = this.CheckStockList(enterpriseCode, sectionCode, goodsUnitData, goodsUnitData.StockList, SectWarehouseCd1);

            if (index == -1)
            {
                index = this.CheckStockList(enterpriseCode, sectionCode, goodsUnitData, goodsUnitData.StockList, SectWarehouseCd2);

                if (index == -1)
                {
                    index = this.CheckStockList(enterpriseCode, sectionCode, goodsUnitData, goodsUnitData.StockList, SectWarehouseCd3);

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
        /// フィルタ文字列を取得する
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetFilterString(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2)
        {
            // 出荷回数によるフィルタ文字列を作成する
            StringBuilder filterSb = new StringBuilder();

            // 検索元
            filterSb.Append(PMHNB02155EB.ct_Col_SubTotal_Sum_SalesTimes);
            filterSb.Append(" >= ");
            filterSb.Append(shipGdsPrimeListCndtn2.ShipCount);

            return filterSb.ToString();
        }

        /// <summary>
        /// ソート文字列を取得する
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetSortString()
        {
            // 検索元：拠点 - メーカー - 商品大分類- 商品中分類 - グループコード - 品番 順
            // 検索先：順位 - 仕入先 - メーカー - 品番 順
            StringBuilder sortSb = new StringBuilder();

            // 検索元
            sortSb.Append(PMHNB02155EB.ct_Col_AddUpSecCode);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sort_GoodsMakerCd);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sort_GoodsLGroup);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sort_GoodsMGroup);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sort_BLGroupCode);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Main_GoodsNo);
            sortSb.Append(", ");

            // 検索先
            sortSb.Append(PMHNB02155EB.ct_Col_Sub_DisplayOrder);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sub_SuplierCode);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sub_MakerCode);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sub_GoodsNo);

            return sortSb.ToString();
        }
        #endregion

        #region テストデータ
        /// <summary>
        /// テストデータ(純正品検索)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcMain(out object obj)
        {
            ArrayList paramlist = new ArrayList();

            ShipGdsPrimeListResultWork param = new ShipGdsPrimeListResultWork();

            param.EnterpriseCode = "0101150842020000"; // 企業コード
            param.AddUpSecCode = "01    "; // 計上拠点コード
            param.SectionGuideSnm = "拠点1"; // 拠点ガイド名称
            param.GoodsMakerCd = 1111; // メーカーコード
            param.GoodsNo = "123456789012345678901234"; // 商品番号
            param.St_SalesTimes = 1000000; // 売上回数(在庫)
            param.St_TotalSalesCount = 1000000; // 売上数計(在庫)
            param.St_SalesMoney = 1000000; // 売上金額(在庫)
            param.St_SalesRetGoodsPrice = 1000000; // 返品額(在庫)
            param.St_DiscountPrice = 1000000; // 値引金額(在庫)
            param.St_GrossProfit = 1000000; // 粗利金額(在庫)
            param.Or_SalesTimes = 1000000; // 売上回数(取寄)
            param.Or_TotalSalesCount = 1000000; // 売上数計(取寄)
            param.Or_SalesMoney = 1000000; // 売上金額(取寄)
            param.Or_SalesRetGoodsPrice = 1000000; // 返品額(取寄)
            param.Or_DiscountPrice = 1000000; // 値引金額(取寄)
            param.Or_GrossProfit = 1000000; // 粗利金額(取寄)

            paramlist.Add(param);

            obj = (object)paramlist;

            return 0;
        }

        /// <summary>
        /// テストデータ(商品マスタ検索)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcMainGoods(out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            GoodsUnitData goods1 = new GoodsUnitData();

            goods1.EnterpriseCode = "0101150842020000"; // 企業コード
            goods1.SectionCode = "01    "; // 計上拠点コード
            goods1.GoodsMakerCd = 1111; // メーカーコード
            goods1.GoodsNo = "123456789012345678901234"; // 商品番号
            goods1.GoodsNameKana = "12345678901234567890";
            goods1.SupplierCd = 1;

            goods1.StockList = new List<Stock>();
            goods1.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods1);

            return 0;
        }

        /// <summary>
        /// テストデータ(商品マスタ検索)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcSubGoods(out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            GoodsUnitData goods1 = new GoodsUnitData();

            goods1.EnterpriseCode = "0101150842020000"; // 企業コード
            goods1.SectionCode = "01    "; // 計上拠点コード
            goods1.GoodsMakerCd = 2222; // メーカーコード
            goods1.GoodsNo = "111111111122222222224444"; // 商品番号
            goods1.SupplierCd = 2;

            goods1.StockList = new List<Stock>();
            goods1.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods1);

            GoodsUnitData goods2 = new GoodsUnitData();

            goods2.EnterpriseCode = "0101150842020000"; // 企業コード
            goods2.SectionCode = "01    "; // 計上拠点コード
            goods2.GoodsMakerCd = 3333; // メーカーコード
            goods2.GoodsNo = "333333333344444444445555"; // 商品番号
            goods2.SupplierCd = 3;

            goods2.StockList = new List<Stock>();
            goods2.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods2);

            GoodsUnitData goods3 = new GoodsUnitData();

            goods3.EnterpriseCode = "0101150842020000"; // 企業コード
            goods3.SectionCode = "01    "; // 計上拠点コード
            goods3.GoodsMakerCd = 4444; // メーカーコード
            goods3.GoodsNo = "666666666677777777778888"; // 商品番号
            goods3.SupplierCd = 4;

            goods3.StockList = new List<Stock>();
            goods3.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods3);

            return 0;
        }

        /// <summary>
        /// テストデータ(結合品検索)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcSub(out object obj)
        {
            ArrayList paramlist = new ArrayList();

            ShipGdsPrimeListResultWork param = new ShipGdsPrimeListResultWork();

            param.EnterpriseCode = "0101150842020000"; // 企業コード
            param.AddUpSecCode = "01    "; // 計上拠点コード
            param.SectionGuideSnm = "拠点1"; // 拠点ガイド名称
            param.GoodsMakerCd = 5555; // メーカーコード
            param.GoodsNo = "999999999988888888887777"; // 商品番号
            param.St_SalesTimes = 2000000; // 売上回数(在庫)
            param.St_TotalSalesCount = 2000000; // 売上数計(在庫)
            param.St_SalesMoney = 2000000; // 売上金額(在庫)
            param.St_SalesRetGoodsPrice = 2000000; // 返品額(在庫)
            param.St_DiscountPrice = 2000000; // 値引金額(在庫)
            param.St_GrossProfit = 2000000; // 粗利金額(在庫)
            param.Or_SalesTimes = 2000000; // 売上回数(取寄)
            param.Or_TotalSalesCount = 2000000; // 売上数計(取寄)
            param.Or_SalesMoney = 2000000; // 売上金額(取寄)
            param.Or_SalesRetGoodsPrice = 2000000; // 返品額(取寄)
            param.Or_DiscountPrice = 2000000; // 値引金額(取寄)
            param.Or_GrossProfit = 2000000; // 粗利金額(取寄)

            paramlist.Add(param);

            obj = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
