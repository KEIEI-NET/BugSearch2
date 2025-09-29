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
    /// 在庫看板印刷アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 在庫看板印刷で使用するデータを取得する。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.12.12</br>
    /// <br>Update Note  : 2009.01.06 30452 上野 俊治</br>
    /// <br>              ・障害対応9625(印刷タイプ「在庫数分」の場合、在庫数分印刷するよう修正)</br>
    /// <br>Update Note  : 2009/03/24 30452 上野 俊治</br>
    /// <br>              ・障害対応12717</br>
    /// </remarks>
    public class StockSignPrintAcs
    {
        #region ■ コンストラクタ
		/// <summary>
        /// 在庫看板印刷アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫看板印刷アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.12</br>
		/// </remarks>
		public StockSignPrintAcs()
		{
            this._iStockSignOrderWorkDB = (IStockSignOrderWorkDB)MediationStockSignOrderWorkDB.GetStockSignOrderWorkDB();
		}

		/// <summary>
        /// 売上内容分析表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 売上内容分析表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.11.11</br>
		/// </remarks>
        static StockSignPrintAcs()
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
        IStockSignOrderWorkDB _iStockSignOrderWorkDB;

        private DataTable _stockSignResultDt; // リモート抽出結果DataTable
        private DataTable _printDt;           // 印刷DataTable (帳票１行データ)
        private DataView _stockSignResultDv;  // 印刷DataView

        #endregion

        #region ■ Publicプロパティ
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView StockSignResultDataView
        {
            get { return this._stockSignResultDv; }
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
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        public int SearchMain(StockSignOrderCndtn stockSignOrderCndtn, out string errMsg)
        {
            return this.SearchProc(stockSignOrderCndtn, out errMsg);
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
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        private int SearchProc(StockSignOrderCndtn stockSignOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMZAI02059EA.CreateDataTable(ref this._stockSignResultDt);
                PMZAI02059EB.CreateDataTable(ref this._printDt);

                StockSignOrderCndtnWork stockSignOrderCndtnWork = new StockSignOrderCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevListCndtn(stockSignOrderCndtn, out stockSignOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iStockSignOrderWorkDB.Search(out retWorkList, stockSignOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevListData(stockSignOrderCndtn, (ArrayList)retWorkList);
                        if (this._printDt.Rows.Count != 0) // ADD 2009/03/23
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "在庫看板印刷データの取得に失敗しました。";
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
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        private int DevListCndtn(StockSignOrderCndtn stockSignOrderCndtn, out StockSignOrderCndtnWork stockSignOrderCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            stockSignOrderCndtnWork = new StockSignOrderCndtnWork();
            try
            {
                stockSignOrderCndtnWork.EnterpriseCode = stockSignOrderCndtn.EnterpriseCode;  // 企業コード

                // 抽出条件パラメータセット
                if (stockSignOrderCndtn.SectionCodes.Length != 0)
                {
                    if (stockSignOrderCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        stockSignOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        stockSignOrderCndtnWork.SectionCodes = stockSignOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    stockSignOrderCndtnWork.SectionCodes = null;
                }

                stockSignOrderCndtnWork.St_WarehouseCode = stockSignOrderCndtn.St_WarehouseCode; // 倉庫コード(開始)
                stockSignOrderCndtnWork.Ed_WarehouseCode = stockSignOrderCndtn.Ed_WarehouseCode; // 倉庫コード(終了)
                stockSignOrderCndtnWork.St_GoodsMakerCd = stockSignOrderCndtn.St_GoodsMakerCd; // 商品メーカーコード(開始)
                if (stockSignOrderCndtn.Ed_GoodsMakerCd == 0) stockSignOrderCndtnWork.Ed_GoodsMakerCd = 9999;
                else stockSignOrderCndtnWork.Ed_GoodsMakerCd = stockSignOrderCndtn.Ed_GoodsMakerCd; // 商品メーカーコード(終了)
                stockSignOrderCndtnWork.St_WarehouseShelfNo = stockSignOrderCndtn.St_WarehouseShelfNo; // 倉庫棚番(開始)
                stockSignOrderCndtnWork.Ed_WarehouseShelfNo = stockSignOrderCndtn.Ed_WarehouseShelfNo; // 倉庫棚番(終了)
                stockSignOrderCndtnWork.St_GoodsNo = stockSignOrderCndtn.St_GoodsNo; // 商品番号(開始)
                stockSignOrderCndtnWork.Ed_GoodsNo = stockSignOrderCndtn.Ed_GoodsNo; // 商品番号(終了)
                stockSignOrderCndtnWork.PrintType = (int)stockSignOrderCndtn.PrintType; // 印刷順


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
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        private void DevListData(StockSignOrderCndtn stockSignOrderCndtn, ArrayList resultWork)
        {
            // リモート抽出結果をDataTableに展開
            DataRow dr;

            foreach (StockSignResultWork stockSignResultWork in resultWork)
            {
                dr = this._stockSignResultDt.NewRow();

                dr[PMZAI02059EA.ct_Col_EnterpriseCode] = stockSignResultWork.EnterpriseCode; // 企業コード
                dr[PMZAI02059EA.ct_Col_WarehouseCode] = stockSignResultWork.WarehouseCode; // 倉庫コード
                dr[PMZAI02059EA.ct_Col_WarehouseShelfNo] = stockSignResultWork.WarehouseShelfNo; // 倉庫棚番
                dr[PMZAI02059EA.ct_Col_GoodsNo] = stockSignResultWork.GoodsNo; // 商品番号
                dr[PMZAI02059EA.ct_Col_GoodsNameKana] = stockSignResultWork.GoodsNameKana; // 商品名称カナ
                dr[PMZAI02059EA.ct_Col_MinimumStockCnt] = stockSignResultWork.MinimumStockCnt; // 最低在庫数
                dr[PMZAI02059EA.ct_Col_MaximumStockCnt] = stockSignResultWork.MaximumStockCnt; // 最高在庫数
                dr[PMZAI02059EA.ct_Col_StockCreateDate] = stockSignResultWork.StockCreateDate; // 在庫登録日
                dr[PMZAI02059EA.ct_Col_PriceStartDate] = stockSignResultWork.PriceStartDate; // 価格開始日
                dr[PMZAI02059EA.ct_Col_ListPrice] = stockSignResultWork.ListPrice; // 定価（浮動）
                dr[PMZAI02059EA.ct_Col_GoodsMakerCd] = stockSignResultWork.GoodsMakerCd; // 商品メーカーコード
                dr[PMZAI02059EA.ct_Col_SectionCode] = stockSignResultWork.SectionCode; // 拠点コード
                dr[PMZAI02059EA.ct_Col_SupplierStock] = stockSignResultWork.SupplierStock; // 仕入在庫数 // ADD 2009/01/06

                this._stockSignResultDt.Rows.Add(dr);
            }

            // 価格開始日チェック
            DateTime now = DateTime.Now;

            foreach (DataRow row in this._stockSignResultDt.Rows)
            {
                if (((DateTime)row[PMZAI02059EA.ct_Col_PriceStartDate]).CompareTo(now) > 0)
                {
                    // 価格開始日が現在より先であれば定価は0
                    row[PMZAI02059EA.ct_Col_ListPrice] = 0;
                }
            }

            // --- ADD 2009/01/06 -------------------------------->>>>>
            // 印刷タイプ「在庫枚数分」の場合、現在庫数分設定
            this.AddRowByStockNum(stockSignOrderCndtn);
            // --- ADD 2009/01/06 --------------------------------<<<<<
            // --- ADD 2009/03/23 -------------------------------->>>>>
            if (this._stockSignResultDt.Rows.Count == 0)
            {
                return;
            }
            // --- ADD 2009/03/23 --------------------------------<<<<<

            // ソート処理
            DataTable newTable = this._stockSignResultDt.Copy();
            this._stockSignResultDt.Clear();

            DataRow[] sortRowList = newTable.Select("", this.GetSortStr(stockSignOrderCndtn));

            foreach (DataRow sortRow in sortRowList)
            {
                this._stockSignResultDt.ImportRow(sortRow);
            }

            // 印字する列数
            int columnNum;

            if (stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Dot_ThreeByNine
                || stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Laser_ThreeByNine)
            {
                columnNum = 3;
            }
            else if (stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Laser_FourByEleven)
            {
                columnNum = 4;
            }
            else
            {
                columnNum = 5;
            }

            // 帳票印字１行データDataTableへの詰替処理
            // 開始行の設定
            if (stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Laser_FourByEleven
                || stockSignOrderCndtn.LabelType == StockSignOrderCndtn.LabelTypeState.Laser_ThreeByNine)
            {
                // レーザーの場合、画面指定分空行を設定
                for (int j = 0; j < (int)stockSignOrderCndtn.PrintStartRow; j++)
                {
                    // 空行を作成
                    DataRow newRow = this._printDt.NewRow();
                    this._printDt.Rows.Add(newRow);
                }
            }
            else
            {
                // ドットの場合、帳票上で1行目を空けているので
                // （画面指定-1）分空行を設定
                for (int j = 0; j < (int)stockSignOrderCndtn.PrintStartRow - 1; j++)
                {
                    // 空行を作成
                    DataRow newRow = this._printDt.NewRow();
                    this._printDt.Rows.Add(newRow);
                }
            }

            // リモート抽出結果から帳票１行データに詰替え
            for (int i = 0; i < this._stockSignResultDt.Rows.Count; i++)
            {
                DataRow stockSignRow = this._stockSignResultDt.Rows[i];

                if (i == 0
                    || i % columnNum == 0)
                {
                    // 列数で割り切れれば1列目
                    DataRow newRow = this._printDt.NewRow();

                    newRow[PMZAI02059EB.ct_Col_InvisibleRow] = 1;
                    newRow[PMZAI02059EB.ct_Col_DataNum] = 1;
                    newRow[PMZAI02059EB.ct_Col_SectionCode1] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // 拠点コード
                    newRow[PMZAI02059EB.ct_Col_WarehouseCode1] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// 倉庫コード
                    newRow[PMZAI02059EB.ct_Col_GoodsMakerCd1] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// メーカーコード
                    newRow[PMZAI02059EB.ct_Col_WarehouseShelfNo1] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// 倉庫棚番
                    newRow[PMZAI02059EB.ct_Col_GoodsNo1] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// 品番
                    newRow[PMZAI02059EB.ct_Col_GoodsNameKana1] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// 品名
                    newRow[PMZAI02059EB.ct_Col_MinimumStockCnt1] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// 最低在庫数
                    newRow[PMZAI02059EB.ct_Col_MaximumStockCnt1] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// 最高在庫数
                    newRow[PMZAI02059EB.ct_Col_StockCreateDate1] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// 在庫登録日
                    newRow[PMZAI02059EB.ct_Col_ListPrice1] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// 定価（浮動）

                    this._printDt.Rows.Add(newRow);
                }
                else if (i % columnNum == 1)
                {
                    // 列数の剰余が1であれば1列目
                    DataRow row = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    row[PMZAI02059EB.ct_Col_DataNum] = 2;
                    row[PMZAI02059EB.ct_Col_SectionCode2] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // 拠点コード
                    row[PMZAI02059EB.ct_Col_WarehouseCode2] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// 倉庫コード
                    row[PMZAI02059EB.ct_Col_GoodsMakerCd2] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// メーカーコード
                    row[PMZAI02059EB.ct_Col_WarehouseShelfNo2] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// 倉庫棚番
                    row[PMZAI02059EB.ct_Col_GoodsNo2] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// 品番
                    row[PMZAI02059EB.ct_Col_GoodsNameKana2] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// 品名
                    row[PMZAI02059EB.ct_Col_MinimumStockCnt2] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// 最低在庫数
                    row[PMZAI02059EB.ct_Col_MaximumStockCnt2] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// 最高在庫数
                    row[PMZAI02059EB.ct_Col_StockCreateDate2] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// 在庫登録日
                    row[PMZAI02059EB.ct_Col_ListPrice2] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// 定価（浮動）
                }
                else if (i % columnNum == 2)
                {
                    DataRow row = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    row[PMZAI02059EB.ct_Col_DataNum] = 3;
                    row[PMZAI02059EB.ct_Col_SectionCode3] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // 拠点コード
                    row[PMZAI02059EB.ct_Col_WarehouseCode3] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// 倉庫コード
                    row[PMZAI02059EB.ct_Col_GoodsMakerCd3] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// メーカーコード
                    row[PMZAI02059EB.ct_Col_WarehouseShelfNo3] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// 倉庫棚番
                    row[PMZAI02059EB.ct_Col_GoodsNo3] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// 品番
                    row[PMZAI02059EB.ct_Col_GoodsNameKana3] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// 品名
                    row[PMZAI02059EB.ct_Col_MinimumStockCnt3] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// 最低在庫数
                    row[PMZAI02059EB.ct_Col_MaximumStockCnt3] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// 最高在庫数
                    row[PMZAI02059EB.ct_Col_StockCreateDate3] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// 在庫登録日
                    row[PMZAI02059EB.ct_Col_ListPrice3] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// 定価（浮動）
                }
                else if (i % columnNum == 3)
                {
                    DataRow row = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    row[PMZAI02059EB.ct_Col_DataNum] = 4;
                    row[PMZAI02059EB.ct_Col_SectionCode4] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // 拠点コード
                    row[PMZAI02059EB.ct_Col_WarehouseCode4] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// 倉庫コード
                    row[PMZAI02059EB.ct_Col_GoodsMakerCd4] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// メーカーコード
                    row[PMZAI02059EB.ct_Col_WarehouseShelfNo4] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// 倉庫棚番
                    row[PMZAI02059EB.ct_Col_GoodsNo4] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// 品番
                    row[PMZAI02059EB.ct_Col_GoodsNameKana4] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// 品名
                    row[PMZAI02059EB.ct_Col_MinimumStockCnt4] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// 最低在庫数
                    row[PMZAI02059EB.ct_Col_MaximumStockCnt4] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// 最高在庫数
                    row[PMZAI02059EB.ct_Col_StockCreateDate4] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// 在庫登録日
                    row[PMZAI02059EB.ct_Col_ListPrice4] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// 定価（浮動）
                }
                else if (i % columnNum == 4)
                {
                    DataRow row = this._printDt.Rows[this._printDt.Rows.Count - 1];

                    row[PMZAI02059EB.ct_Col_DataNum] = 5;
                    row[PMZAI02059EB.ct_Col_SectionCode5] = stockSignRow[PMZAI02059EA.ct_Col_SectionCode]; // 拠点コード
                    row[PMZAI02059EB.ct_Col_WarehouseCode5] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseCode];// 倉庫コード
                    row[PMZAI02059EB.ct_Col_GoodsMakerCd5] = stockSignRow[PMZAI02059EA.ct_Col_GoodsMakerCd];// メーカーコード
                    row[PMZAI02059EB.ct_Col_WarehouseShelfNo5] = stockSignRow[PMZAI02059EA.ct_Col_WarehouseShelfNo];// 倉庫棚番
                    row[PMZAI02059EB.ct_Col_GoodsNo5] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNo];// 品番
                    row[PMZAI02059EB.ct_Col_GoodsNameKana5] = stockSignRow[PMZAI02059EA.ct_Col_GoodsNameKana];// 品名
                    row[PMZAI02059EB.ct_Col_MinimumStockCnt5] = stockSignRow[PMZAI02059EA.ct_Col_MinimumStockCnt];// 最低在庫数
                    row[PMZAI02059EB.ct_Col_MaximumStockCnt5] = stockSignRow[PMZAI02059EA.ct_Col_MaximumStockCnt];// 最高在庫数
                    row[PMZAI02059EB.ct_Col_StockCreateDate5] = stockSignRow[PMZAI02059EA.ct_Col_StockCreateDate];// 在庫登録日
                    row[PMZAI02059EB.ct_Col_ListPrice5] = stockSignRow[PMZAI02059EA.ct_Col_ListPrice];// 定価（浮動）
                }
            }

            // DataView作成
            // 発行タイプによりソート
            this._stockSignResultDv = new DataView(this._printDt, "", "", DataViewRowState.CurrentRows);
        }

        // --- ADD 2009/01/06 -------------------------------->>>>>
        /// <summary>
        /// 在庫数分Row追加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       　: 在庫数分行数を増やす</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2009.01.06</br>
        /// </remarks>
        private void AddRowByStockNum(StockSignOrderCndtn stockSignOrderCndtn)
        {
            if (stockSignOrderCndtn.PrintType == StockSignOrderCndtn.PrintTypeState.StockNum)
            {
                DataTable tmpDt = this._stockSignResultDt.Copy();
                this._stockSignResultDt.Clear();

                // 仕入在庫数(int)
                int stockNum;

                foreach (DataRow dr in tmpDt.Rows)
                {
                    // int型に変換(切捨て)
                    stockNum = (int)((double)dr[PMZAI02059EA.ct_Col_SupplierStock]);

                    // 在庫数分行追加
                    // 切捨て結果が0になる場合は印字しない
                    for (int i = 0; i < stockNum; i++)
                    {
                        this._stockSignResultDt.ImportRow(dr);
                    }
                }
            }
        }
        // --- ADD 2009/01/06 --------------------------------<<<<<

        /// <summary>
        /// DataView用ソート文字列取得
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       　: ソート文字列を取得する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.12</br>
        /// </remarks>
        private string GetSortStr(StockSignOrderCndtn stockSignOrderCndtn)
        {
            StringBuilder sortStr = new StringBuilder();

            sortStr.Append(PMZAI02059EA.ct_Col_SectionCode);
            sortStr.Append(", ");

            sortStr.Append(PMZAI02059EA.ct_Col_WarehouseCode);
            sortStr.Append(", ");

            sortStr.Append(PMZAI02059EA.ct_Col_GoodsMakerCd);
            sortStr.Append(", ");

            if (stockSignOrderCndtn.PrintOrder == StockSignOrderCndtn.PrintOrderState.ShelfNo)
            {
                // 拠点-倉庫-メーカー-棚番-品番順
                sortStr.Append(PMZAI02059EA.ct_Col_WarehouseShelfNo);
                sortStr.Append(", ");
            }
            else
            {
                // 拠点-倉庫-メーカー-品番順
            }

            sortStr.Append(PMZAI02059EA.ct_Col_GoodsNo);

            return sortStr.ToString();

        }
        #endregion
    }
}
