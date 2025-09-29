using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Library;
using System.Reflection;
using System.IO;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using System.Xml;
using Microsoft.Win32;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
using System.Threading;//ADD 2021/06/10 田建委 PMKOBETSU-4144

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.01.18</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 PM.NS用に修正</br>
    /// <br>Date       : 2008.07.03</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 不具合修正</br>
    /// <br>Date       : 2009.05.25</br>
    /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
    /// <br>             在庫マスタが論理削除されている場合の変更</br>
    /// <br>UpdateNote : 2010/10/13 22018 鈴木 正臣</br>
    /// <br>             発注残数がマイナスになる時、ゼロで補正するよう修正。(卸商仕入受信or在庫入庫更新)</br>
    /// <br>UpdateNote : 施炳中</br>
    /// <br>Date       : 2011/07/12</br>
    /// <br>           : 連番No.1027 発注残がマイナスになる場合は、固定で０をセットしているが、卸商仕入受信が起動元となる場合は、発注残のマイナスを許可する。</br>
    /// <br>UpdateNote : 2011/07/20 施炳中 </br>
    /// <br>             Redmine#23074 先頭から「：」までの文字列が「PMUOE01300U」か否かの判定の対応</br>
    /// <br>UpdateNote : 2011/07/21 堀田 </br>
    /// <br>             Redmine#23074 先頭から「：」までの文字列が「PMUOE01300U」か否かの判定対応の取得元の修正</br>
    /// <br>UpdateNote : 2011/08/29 wangf </br>
    /// <br>             NSユーザー改良要望一覧_20110629_優先_PM7相違_障害_連番1016、在庫マスタの出荷可能数の更新仕様の変更修正の対応</br>
    /// <br>UpdateNote : 2011/11/29 30517 夏野 駿希</br>
    /// <br>             商品在庫一括登録修正検索時のタイムアウト時間を60秒に延長</br>
    /// <br>Update Note: 2012/05/29 zhangy3 </br>
    /// <br>管理番号   : 10801804-00 2012/06/27配信分</br>
    /// <br>             Redmine#30029 在庫マスタ一覧印刷 特定条件下での印刷不具合</br>
    /// <br>Update Note: 2013/10/09 yangyi</br>
    /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
    /// <br>UpdateNote : 2013/11/13 鄭慕鈞 </br>
    /// <br>管理番号   : 10904948-00 フタバ個別</br>
    /// <br>             Redmine#41201 機能:EMC取込手動:PMUOE01751UC　自動:PMUOE01770UC　SPK取込自動:PMUOE01800UC　手動:PMUOE01802UC　発注残のマイナスを許可する</br>
    /// <br>UpdateNote : K2014/01/06 wangl2 </br>
    /// <br>管理番号   : 10970522-00 フタバ個別</br>
    /// <br>UpdateNote : 2014/01/15 huangt </br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>             Redmine#40998 貸出数の変更を可能にするように修正</br>
    /// <br>Update Note: 2014/02/06 湯上 千加子</br>
    /// <br>管理番号   : </br>
    /// <br>           : SCM仕掛一覧№10632対応</br>
    /// <br>Update Note: 2014/08/13 劉超</br>
    /// <br>             PMSCM同期化対応の変更</br>
    /// <br>Update Note: K2020/03/25 陳艶丹</br>
    /// <br>管理番号   : 11600006-00 PMKOBETSU-3622対応</br>
    /// <br>             UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
    /// <br>Update Note: 2020/08/28 田建委</br>
    /// <br>管理番号   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 タイムアウト設定</br> 
    /// <br>Update Note: 2021/06/10 田建委</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>             PMKOBETSU-4144 デッドロック対応</br>
    /// </remarks>
    [Serializable]
    public class StockDB : RemoteWithAppLockDB, IStockDB, IFunctionCallTargetWrite, IFunctionCallTargetRead
    {
        // --- ADD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>>
        // リトライ回数-デフォルト：5回
        private const int RETRY_COUNT_DEFAULT = 5;
        // リトライ間隔-デフォルト：60秒
        private const int RETRY_INTERVAL_DEFAULT = 60;
        // ログ出力PGID
        private const string CURRENT_PGID = "MAZAI04134R";
        // エラーメッセージ
        private const string ERR_MEG_W = "WriteStockBlanketProcReTryデッドロック発生 リトライ回数：{0}回目";
        // エラーメッセージ
        private const string ERR_MEG_D = "DeleteStockProcReTryデッドロック発生 リトライ回数：{0}回目";
        // デッドロック1205
        private const int DEAD_LOCK_VALUE = 1205;
        // SavePoint(WriteStockBlanketProcReTry)
        private const string SAVEPPIONT_W = "WriteStockBlanketProcReTry";
        // SavePoint(DeleteStockProcReTry)
        private const string SAVEPPIONT_D = "DeleteStockProcReTry";
        // 定数(0)
        private const int ZERO_VALUE = 0;
        // --- ADD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<<

        /// <summary>
        /// 在庫DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        public StockDB()
            :
            base("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork", "STOCKRF")
        {
        }

        #region 定数
        /// <summary>処理区分</summary>
        public enum ct_ProcMode
        {
            /// <summary>仕入</summary>
            StockSlip = 0,
            /// <summary>移動</summary>
            StockMove = 1,
            /// <summary>販売</summary>
            Sales = 2,
            /// <summary>調整</summary>
            StockAdjust = 3
        }

        /// <summary>更新処理区分</summary>
        public enum ct_WriteMode
        {
            /// <summary>更新</summary>
            Write = 0,
            /// <summary>削除</summary>
            delete = 1
        }

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        #endregion

        #region 
        /// <summary>棚卸更新区分</summary>
        private int _whUpdateDiv = 0;
        #endregion

        #region [OtherRemote]
        private StockAcPayHistDB _stockAcPayHistDB = new StockAcPayHistDB();    //在庫受払履歴リモート
        private StockMngTtlStDB _stockMngTtlStDB = new StockMngTtlStDB();       //在庫管理全体設定
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の在庫情報LISTを戻します
        /// </summary>
        /// <param name="stockWork">検索結果</param>
        /// <param name="parastockWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int Search(out object stockWork, object parastockWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockProc(out stockWork, parastockWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Search");
                stockWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の在庫情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objstockWork">検索結果</param>
        /// <param name="parastockWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int SearchStockProc(out object objstockWork, object parastockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockWork stockWork = null;

            ArrayList stockWorkList = parastockWork as ArrayList;
            if (stockWorkList == null)
            {
                stockWork = parastockWork as StockWork;
            }
            else
            {
                if (stockWorkList.Count > 0)
                    stockWork = stockWorkList[0] as StockWork;
            }

            int status = SearchStockProc(out stockWorkList, stockWork, readMode, logicalMode, ref sqlConnection);
            objstockWork = stockWorkList;
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 指定された条件の在庫情報LISTを全て戻します(外部からのSqlConnectionを使用 自動回答処理専用)
        /// </summary>
        /// <param name="objstockWork">検索結果</param>
        /// <param name="parastockWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br></br>
        public int SearchStockForAutoSearchProc(out object objstockWork, object parastockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            List<StockWork> stockWork = new List<StockWork>();
            ArrayList stockWorkList;

            stockWork = parastockWork as List<StockWork>;

            int status = SearchStockProc(out stockWorkList, stockWork, readMode, logicalMode, ref sqlConnection);
            objstockWork = stockWorkList;
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWorkList">検索結果</param>
        /// <param name="stockWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int SearchStockProc(out ArrayList stockWorkList, StockWork stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockProcProc(out stockWorkList, stockWork, readMode, logicalMode, ref sqlConnection);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用 自動回答処理専用)
        /// </summary>
        /// <param name="stockWorkList">検索結果</param>
        /// <param name="stockWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br></br>
        public int SearchStockProc(out ArrayList stockWorkList, List<StockWork> stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockProcProc(out stockWorkList, stockWork, readMode, logicalMode, ref sqlConnection);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<


        /// <summary>
        /// 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWorkList">検索結果</param>
        /// <param name="stockWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>管理番号   : 10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30029 在庫マスタ一覧印刷 特定条件下での印刷不具合</br>
        private int SearchStockProcProc(out ArrayList stockWorkList, StockWork stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockWork, logicalMode);

                // 2011/11/29 Add >>>
                sqlCommand.CommandTimeout = 60;
                // 2011/11/29 Add <<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockWorkFromReader(ref myReader,0));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockWorkList = al;

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWorkList">検索結果</param>
        /// <param name="stockWork">検索パラメータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br></br>
        private int SearchStockProcProc(out ArrayList stockWorkList, List<StockWork> stockWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockWork, logicalMode);

                sqlCommand.CommandTimeout = 60;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockWorkFromReader(ref myReader, 0));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockWorkList = al;

            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の在庫を戻します
        /// </summary>
        /// <param name="parabyte">StockWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫を戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                StockWork stockWork = new StockWork();

                // XMLの読み込み
                stockWork = (StockWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockWork));
                if (stockWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(stockWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Read");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の在庫を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int ReadProc(ref StockWork stockWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref stockWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の在庫を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>管理番号   : 10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30029 在庫マスタ一覧印刷 特定条件下での印刷不具合</br>
        private int ReadProcProc(ref StockWork stockWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        stockWork = CopyToStockWorkFromReader(ref myReader,0);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の在庫を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int ReadProc(ref StockWork stockWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProcProc(ref stockWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の在庫を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>管理番号   : 10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30029 在庫マスタ一覧印刷 特定条件下での印刷不具合</br>
        private int ReadProcProc(ref StockWork stockWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        stockWork = CopyToStockWorkFromReader(ref myReader,0);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        #region [Write]
        /// <summary>
        /// 在庫情報を登録、更新します
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int Write(ref object stockWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            string resNm = "";
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(stockWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                //resNm = GetResourceName(((StockWork)paraList[0]).EnterpriseCode);
                string enterpriseCode = ((StockWork)paraList[0]).EnterpriseCode;
                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockDB.Write1:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockDB.Write1:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                //ＡＰロック
                status = Lock(resNm,sqlConnection,sqlTransaction);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    string retMsg = string.Empty;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                    }
                    base.WriteErrorLog(string.Format("StockDB.Write1_Lock:{0}", retMsg), status);
                }
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

                //write実行
                status = WriteStockProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                //戻り値セット
                stockWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Write(ref object stockWork)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                ////ＡＰアンロック
                //Release(resNm, sqlConnection, sqlTransaction);
                int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (sqlConnection == null)
                {
                    base.WriteErrorLog("StockDB.Write1_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                }
                else if (sqlTransaction == null)
                {
                    base.WriteErrorLog("StockDB.Write1_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                }
                else if (sqlTransaction.Connection == null)
                {
                    base.WriteErrorLog("StockDB.Write1_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                }
                else
                {
                    //●排他ロックを解除する
                    releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("StockDB.Write1_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                    }
                }
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        //sqlTransaction.Commit(); // DEL 劉超 2014/08/13
                    //----- ADD START 劉超 2014/08/13 ----->>>>>>
                    {
                        sqlTransaction.Commit();
                        //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                        //synchExecuteMng.SyncReqExecute();
                    }
                    //----- ADD END 劉超 2014/08/13 -----<<<<<<
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }

                }
                
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 在庫情報更新処理(排他有・在庫調整用)
        /// </summary>
        /// <param name="stockWorkList">在庫リスト</param>
        /// <param name="stockAcPayHistWorkList">在庫受払履歴リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int Write(ref ArrayList stockWorkList, ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                return status;
            }
            
            string resNm = "";
            try
            {
                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.Write2:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.Write2:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }
                else if (stockAcPayHistWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.Write2:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.Write2:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }

                if (resNm != "")
                {
                    //ＡＰロック
                    status = Lock(resNm, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            retMsg = "ロックタイムアウトが発生しました。";
                        }
                        else
                        {
                            retMsg = "排他ロックに失敗しました。";
                        }
                        base.WriteErrorLog(string.Format("StockDB.Write2_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                        return status;
                    }

                }

                //在庫データ更新
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteStockProc(ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫マスタの更新に失敗しました。";
                }

                //更新後の在庫データを在庫受払履歴データへ反映
                if (stockAcPayHistWorkList != null && stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //在庫受払履歴マスタ更新
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫受払履歴マスタの更新に失敗しました。";
                }
            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    ////ＡＰアンロック
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.Write2_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.Write2_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.Write2_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                    }
                    else
                    {
                        //●排他ロックを解除する
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.Write2_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }
            }
            return status;
        }

        /// <summary>
        /// 在庫一括登録からの在庫情報更新
        /// </summary>
        /// <param name="stockWorkList">在庫リスト</param>
        /// <param name="stockAcPayHistWorkList">在庫受払履歴リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int WriteStockBlanket(ref ArrayList stockWorkList, ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StockMngTtlStWork stockMngTtlStWork = null;     //在庫管理全体設定
            retMsg = "";
            
            string resNm = "";
            
            try
            {
                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.WriteStockBlanket:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteStockBlanket:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }
                else if (stockAcPayHistWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.WriteStockBlanket:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteStockBlanket:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }
                   
                if (resNm != "")
                {
                    //ＡＰロック
                    status = Lock(resNm,sqlConnection,sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            retMsg = "ロックタイムアウトが発生しました。";
                        }
                        else
                        {
                            retMsg = "排他ロックに失敗しました。";
                        }
                        base.WriteErrorLog(string.Format("StockDB.WriteStockBlanket_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                        return status;
                    }

                }
                
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                    return status;
                }

                //在庫管理全体設定取得
                if (stockWorkList != null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫管理全体設定情報取得に失敗しました。";
                }

                //在庫データ更新
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteStockBlanketProc((int)(int)ct_ProcMode.StockAdjust,(int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫マスタの更新に失敗しました。";
                }

                //更新後の在庫データを在庫受払履歴データへ反映
                if (stockAcPayHistWorkList != null && stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //在庫受払履歴マスタ更新
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫受払履歴マスタの更新に失敗しました。";
                }
            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    ////ＡＰアンロック
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStockBlanket_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStockBlanket_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStockBlanket_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                    }
                    else
                    {
                        //●排他ロックを解除する
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.WriteStockBlanket_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }

            }
            return status;
        }

        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- >>>>>
        /// <summary>
        /// 在庫一括登録からの在庫情報更新
        /// </summary>
        /// <param name="stockWorkList">在庫リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2014/01/10</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        /// <br></br>
        public int WriteStock(ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StockMngTtlStWork stockMngTtlStWork = null;     //在庫管理全体設定
            retMsg = "";

            string resNm = "";

            try
            {
                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.WriteStock:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteStock:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }

                if (resNm != "")
                {
                    //ＡＰロック
                    status = Lock(resNm, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            retMsg = "ロックタイムアウトが発生しました。";
                        }
                        else
                        {
                            retMsg = "排他ロックに失敗しました。";
                        }
                        base.WriteErrorLog(string.Format("StockDB.WriteStock_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                        return status;
                    }

                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                    return status;
                }

                //在庫管理全体設定取得
                if (stockWorkList != null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫管理全体設定情報取得に失敗しました。";
                }

                //在庫データ更新
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteStockBlanketProc((int)(int)ct_ProcMode.StockAdjust, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫マスタの更新に失敗しました。";
                }

            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    ////ＡＰアンロック
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStock_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStock_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteStock_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                    }
                    else
                    {
                        //●排他ロックを解除する
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.WriteStock_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }

            }
            return status;
        }
        // ----- ADD huangt 2014/01/15 Redmine#40998 貸出数の変更を可能にするように修正 ----- <<<<<

        /// <summary>
        /// 在庫一括登録からの在庫情報削除
        /// </summary>
        /// <param name="stockWorkList">在庫リスト</param>
        /// <param name="stockAcPayHistWorkList">在庫受払履歴リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int DeleteStockBlanket(ref ArrayList stockWorkList, ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";

            string resNm = "";

            try
            {
                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.DeleteStockBlanket:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.DeleteStockBlanket:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }
                else if (stockAcPayHistWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.DeleteStockBlanket:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.DeleteStockBlanket:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }

                if (resNm != "")
                {
                    //ＡＰロック
                    status = Lock(resNm, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            retMsg = "ロックタイムアウトが発生しました。";
                        }
                        else
                        {
                            retMsg = "排他ロックに失敗しました。";
                        }
                        base.WriteErrorLog(string.Format("StockDB.DeleteStockBlanket_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                        return status;
                    }

                }

                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                    return status;
                }

                //在庫マスタ物理削除
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteStockProc(stockWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫マスタの削除に失敗しました。";
                }

                //在庫受払履歴マスタ更新
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫受払履歴マスタの更新に失敗しました。";
                }
            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    ////ＡＰアンロック
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.DeleteStockBlanket_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.DeleteStockBlanket_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.DeleteStockBlanket_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                    }
                    else
                    {
                        //●排他ロックを解除する
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.DeleteStockBlanket_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }

            }

            return status;
        }

        /// <summary>
        /// 在庫情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int WriteStockProc(ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteStockProcProc(ref stockWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        private int WriteStockProcProc(ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            bool insflg = false;
            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        selectTxt = "";

                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (stockWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += " , ACPODRCOUNTRF=@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERCOUNTRF=@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += " , STOCKTOTALPRICERF=@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += " , LASTSALESDATERF=@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE1RF=@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE2RF=@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += " , SHIPMENTCNTRF=@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += " , ARRIVALCNTRF=@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += " , STOCKCREATEDATERF=@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            insflg = false;
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,MONTHORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKTOTALPRICERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSTOCKDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSALESDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                            selectTxt += "  ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,NMLSALODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKSUPPLIERCODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKCREATEDATERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += "  ,@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = selectTxt;

                            //SetInsertHeaderメソッドでlogicalDeleteCodeが上書きさせるため
                            int logicalDeleteCode = stockWork.LogicalDeleteCode;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            stockWork.LogicalDeleteCode = logicalDeleteCode;
                            insflg = true;
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                        SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                        SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                        SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                        SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                        SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                        paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                        //paraStockUnitPriceFl.Value = 0;
                        //paraStockTotalPrice.Value = 0;

                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                        paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                        paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                        paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                        paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                        paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                        paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                        paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);

                        if (insflg)
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                        }
                        else
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                        }
                        #endregion
                        
                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START 松本 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END 松本 2015/01/28 -----<<<<<<	
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockWorkList = al;

            return status;
        }

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        /// <summary>
        /// 出荷可能数設定処理
        /// </summary>
        /// <param name="stockWork">在庫データ</param>
        /// <br>Note       : 出荷可能数設定処理</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2011/08/29 wangf 連番1016の対応</br>
        private void SetShipmentPosCnt(ref StockWork stockWork)
        {
            // -- add wangf 2011/08/29 ---------->>>>>
            // 在庫管理全体設定の「現在庫表示区分」により、受注数は算出条件追加の判断
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();
            stockMngTtlStWork.EnterpriseCode = stockWork.EnterpriseCode;
            stockMngTtlStWork.SectionCode = "00";
            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);
            // 在庫管理全体設定読み込み
            int status = stockMngTtlStDB.Read(ref parabyte, 0);
            if (status == 0)
            {
                // XMLの読み込み
                stockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
            }
            // -- add wangf 2011/08/29 ----------<<<<<
            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
            //出荷可能数の計算式
            //出荷可能数＝仕入在庫数＋入荷数（未計上）ー 出荷数（未計上）ー 受注数 ー 移動中仕入在庫数
            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★

            // double型による計算では丸め誤差が発生してしまう為、decimal型にキャストして計算する
            decimal SupplierStock = (decimal)stockWork.SupplierStock;
            decimal ArrivalCnt = (decimal)stockWork.ArrivalCnt;
            decimal ShipmentCnt = (decimal)stockWork.ShipmentCnt;
            decimal AcpOdrCount = (decimal)stockWork.AcpOdrCount;
            decimal MovingSupliStock = (decimal)stockWork.MovingSupliStock;
            //stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - AcpOdrCount - MovingSupliStock); // del wangf 2011/08/29
            // -- add wangf 2011/08/29 ---------->>>>>
            if (stockMngTtlStWork.PreStckCntDspDiv == 0)
            {
                // 受注分含む
                stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - AcpOdrCount - MovingSupliStock);
            }
            else
            {
                // 受注分含まない
                stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - MovingSupliStock);
            }
            // -- add wangf 2011/08/29 ----------<<<<<
        }

        /// <summary>
        /// 金額計算処理
        /// </summary>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <param name="stockMngTtlStWork">在庫管理全体設定</param>
        /// <param name="wkStockWork">更新前在庫データ</param>
        /// <param name="stockWork">今回更新在庫データ</param>
        /// <br>Note       : 在庫評価方法により金額計算処理を行います</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.04.24</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        private void SetStockPrice(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref StockWork wkStockWork, ref StockWork stockWork)
        {

            if (wkStockWork != null)
            {
                //---既存データ有の場合---//

                //在庫評価方法により仕入単価の算出切替
                switch (stockMngTtlStWork.StockPointWay)
                {

                    //-------------------------------------------------------------------
                    //最終仕入原価法
                    //-------------------------------------------------------------------
                    case (int)ConstantManagement_Mobile.ct_StockPointWay.Last:

                        //☆★☆仕入単価設定☆★☆
                        //仕入単価 = 今回仕入単価 
                        if ((wkStockWork.LastStockDate <= stockWork.LastStockDate) && (stockWork.SupplierStock >= 0))//今回の仕入日が最終の仕入日より新しい場合かつ在庫数量が１以上の場合
                            wkStockWork.StockUnitPriceFl = stockWork.StockUnitPriceFl;

                        //☆★☆在庫保有総額設定☆★☆
                        //在庫保有総額 = 仕入単価 * 今回仕入在庫数
                        wkStockWork.StockTotalPrice = (Int64)CalculateConsTax.Fraction(wkStockWork.StockUnitPriceFl * wkStockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);
                        break;

                    //-------------------------------------------------------------------
                    //移動平均法
                    //-------------------------------------------------------------------
                    case (int)ConstantManagement_Mobile.ct_StockPointWay.Average:

                        //☆★☆在庫保有総額設定☆★☆
                        if (stockWork.StockTotalPrice != 0)
                            //在庫保有総額 += 今回在庫保有総額
                            wkStockWork.StockTotalPrice += stockWork.StockTotalPrice;
                        else
                            //在庫保有総額 += 今回仕入単価 * 今回仕入在庫数
                        wkStockWork.StockTotalPrice += (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);

                        //☆★☆仕入単価設定☆★☆
                        if (stockWork.SupplierStock >= 0)//在庫数量が１以上の場合
                            if (procMode == (int)ct_ProcMode.StockSlip || procMode == (int)ct_ProcMode.StockAdjust || procMode == (int)ct_ProcMode.StockMove)
                            {
                                if (wkStockWork.StockTotalPrice != 0 && wkStockWork.SupplierStock != 0)
                                {
                                    //仕入単価 = 端数処理（在庫保有総額 / 仕入在庫数）
                                    double dbluprice = wkStockWork.StockTotalPrice / wkStockWork.SupplierStock;
                                    if (dbluprice != 0)
                                        wkStockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(dbluprice, stockMngTtlStWork.FractionProcCd);
                                }
                                else
                                    wkStockWork.StockUnitPriceFl = 0;
                            }
                        break;

                    //-------------------------------------------------------------------
                    //個別単価法
                    //-------------------------------------------------------------------
                    case (int)ConstantManagement_Mobile.ct_StockPointWay.Individual:

                        //☆★☆在庫保有総額設定☆★☆
                        if (stockWork.StockTotalPrice != 0)
                            //在庫保有総額 += 今回在庫保有総額
                            wkStockWork.StockTotalPrice += stockWork.StockTotalPrice;
                        else
                            //在庫保有総額 += 今回仕入単価 * 今回仕入在庫数
                            wkStockWork.StockTotalPrice += (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);

                        //☆★☆仕入単価設定☆★☆
                        //if (stockWork.SupplierStock > 0)//在庫数量が１以上の場合
                        if (wkStockWork.StockTotalPrice != 0 && wkStockWork.SupplierStock != 0)
                        {
                            //仕入単価 = 端数処理（在庫保有総額 / 仕入在庫数）
                            wkStockWork.StockUnitPriceFl = CalculateConsTax.Fraction((wkStockWork.StockTotalPrice / wkStockWork.SupplierStock), stockMngTtlStWork.FractionProcCd);
                        }
                        else
                            wkStockWork.StockUnitPriceFl = 0;
                        break;
                }

                //新しい最終仕入年月日の方が最新の日付の場合最終仕入年月日を更新
                if (wkStockWork.LastStockDate <= stockWork.LastStockDate)
                    wkStockWork.LastStockDate = stockWork.LastStockDate;
            }
            else
            {
                if (stockWork.StockUnitPriceFl > 0)
                {
                    //---新規の場合---//
                    //在庫評価方法により仕入単価の算出切替
                    switch (stockMngTtlStWork.StockPointWay)
                    {

                        //-------------------------------------------------------------------
                        //最終仕入原価法
                        //-------------------------------------------------------------------
                        case (int)ConstantManagement_Mobile.ct_StockPointWay.Last:

                            //☆★☆在庫保有総額設定☆★☆
                            //在庫保有総額 = 今回仕入単価 * 今回仕入在庫数
                            stockWork.StockTotalPrice = (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);
                            break;

                        //-------------------------------------------------------------------
                        //移動平均法
                        //-------------------------------------------------------------------
                        case (int)ConstantManagement_Mobile.ct_StockPointWay.Average:

                            //☆★☆在庫保有総額設定☆★☆
                            //在庫保有総額 = 今回仕入単価 * 今回仕入在庫数
                            stockWork.StockTotalPrice = (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);

                            //☆★☆仕入単価設定☆★☆
                            if (stockWork.SupplierStock >= 0)//在庫数量が１以上の場合
                                if (procMode == (int)ct_ProcMode.StockSlip || procMode == (int)ct_ProcMode.StockAdjust || procMode == (int)ct_ProcMode.StockMove)
                                {
                                    if (stockWork.StockTotalPrice != 0 && stockWork.SupplierStock != 0)
                                    {
                                        //仕入単価 = 端数処理（在庫保有総額 / 仕入在庫数）
                                        double dbluprice = stockWork.StockTotalPrice / stockWork.SupplierStock;
                                        if (dbluprice != 0)
                                            stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction(dbluprice, stockMngTtlStWork.FractionProcCd);
                                    }
                                    else
                                        stockWork.StockUnitPriceFl = 0;
                                }
                            break;

                        //-------------------------------------------------------------------
                        //個別単価法
                        //-------------------------------------------------------------------
                        case (int)ConstantManagement_Mobile.ct_StockPointWay.Individual:

                            //☆★☆在庫保有総額設定☆★☆
                            //在庫保有総額 = 今回仕入単価 * 今回仕入在庫数
                            if (stockWork.StockTotalPrice == 0)
                                stockWork.StockTotalPrice = (Int64)CalculateConsTax.Fraction(stockWork.StockUnitPriceFl * stockWork.SupplierStock,stockMngTtlStWork.FractionProcCd);

                            //☆★☆仕入単価設定☆★☆
                            //if (stockWork.SupplierStock > 0)//在庫数量が１以上の場合
                            if (stockWork.StockTotalPrice != 0 && stockWork.SupplierStock != 0)
                            {
                                //仕入単価 = 端数処理（在庫保有総額 / 仕入在庫数）
                                stockWork.StockUnitPriceFl = (Int64)CalculateConsTax.Fraction((stockWork.StockTotalPrice / stockWork.SupplierStock), stockMngTtlStWork.FractionProcCd);
                            }
                            else
                                stockWork.StockUnitPriceFl = 0;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <param name="stockMngTtlStWork">在庫管理全体設定</param>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int StockAddCountUPProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return StockAddCountUPProcProc(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <param name="stockMngTtlStWork">在庫管理全体設定</param>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             在庫マスタが論理削除されている場合の変更</br>
        /// <br>UpdateNote : 2011/07/12 施炳中 </br>
        /// <br>             連番No.1027 発注残がマイナスになる場合は、固定で０をセットしているが、卸商仕入受信が起動元となる場合は、発注残のマイナスを許可する。</br>
        /// <br>UpdateNote : 2011/07/20 施炳中 </br>
        /// <br>             Redmine#23074 先頭から「：」までの文字列が「PMUOE01300U」か否かの判定の対応</br>
        /// <br>UpdateNote : 2011/07/21 堀田 </br>
        /// <br>             Redmine#23074 先頭から「：」までの文字列が「PMUOE01300U」か否かの判定対応の取得元の修正</br>
        /// <br>UpdateNote : 2013/11/13 鄭慕鈞 </br>
        /// <br>管理番号   : 10904948-00 フタバ個別</br>
        /// <br>             Redmine#41201 機能:EMC取込手動:PMUOE01751UC　自動:PMUOE01770UC　SPK取込自動:PMUOE01800UC　手動:PMUOE01802UC　発注残のマイナスを許可する</br>
        /// <br>Update Note: 2020/08/28 田建委</br>
        /// <br>             PMKOBETSU-4076 タイムアウト設定</br> 
        private int StockAddCountUPProcProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StockWork wkStockWork = null;
            bool insflg = false;
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        //更新チェック処理
                        //Selectコマンドの生成
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        sqlCommand.CommandTimeout = dbCommandTimeout;  //ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //現在のデータをクラスへ格納
                            wkStockWork = CopyToStockWorkFromReader(ref myReader,1);

                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //数量の更新
                            //数量の足し込み(渡されたパラメータの数量が考慮されているものとして単純に加算します。
                            //実際は通常ならプラス、赤伝や取り消しなど削除の場合はマイナスになります。)
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            
                            // double型のままで計算を行うと丸め誤差が生じる場合(例 0.37 + 0.31 = 0.67999999999999994)
                            // があるのでdecimal型にキャストして計算する
                            wkStockWork.SupplierStock = (double)((decimal)wkStockWork.SupplierStock + (decimal)stockWork.SupplierStock);
                            wkStockWork.AcpOdrCount = (double)((decimal)wkStockWork.AcpOdrCount + (decimal)stockWork.AcpOdrCount);
                            wkStockWork.SalesOrderCount = (double)((decimal)wkStockWork.SalesOrderCount + (decimal)stockWork.SalesOrderCount);
                            wkStockWork.MovingSupliStock = (double)((decimal)wkStockWork.MovingSupliStock + (decimal)stockWork.MovingSupliStock);
                            wkStockWork.ShipmentCnt = (double)((decimal)wkStockWork.ShipmentCnt + (decimal)stockWork.ShipmentCnt);
                            wkStockWork.ArrivalCnt = (double)((decimal)wkStockWork.ArrivalCnt + (decimal)stockWork.ArrivalCnt);

                            // --- UPD 2011/07/12 ---------->>>>>
                            // --- ADD m.suzuki 2010/10/13 ---------->>>>>
                            //  // 発注残数がマイナスになる場合はゼロで補正する。
                            //  if ( wkStockWork.SalesOrderCount < 0 )
                            //  {
                            //    wkStockWork.SalesOrderCount = 0;
                            //  }
                            //  // --- ADD m.suzuki 2010/10/13 ----------<<<<<
                            
                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //---起動元プロセスの取得
                            //Assembly myAssembly = Assembly.GetEntryAssembly();
                            //string path1 = myAssembly.Location;
                            //string path2 = Path.GetFileName(path1);
                            object obje = (object)this;
                            FileHeader filehd2 = new FileHeader(obje);

                            string path2 = filehd2.UpdAssemblyId1;
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            
                            // 卸商仕入受信以外で、発注残数がマイナスになる場合はゼロで補正
                            // --- ADD 2011/07/20 ---------->>>>>
                            int tempIndex = path2.IndexOf(":");
                            if (tempIndex > 0)
                            {
                                path2 = path2.Substring(0, tempIndex);
                            }
                            // --- ADD 2011/07/20 ----------<<<<<
                            
                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //if (path2 != "PMUOE01300U.exe")
                            //if (path2 != "PMUOE01300U")//DEL 2013/11/13　鄭慕鈞 Redmine#41201 システム障害一覧№2　発注残のマイナスを許可する「機能:EMC取込手動:PMUOE01751UC　自動:PMUOE01770UC　SPK取込自動:PMUOE01800UC　手動:PMUOE01802UC」
                            //if (path2 != "PMUOE01300U" && path2 != "PMUOE01751UC" && path2 != "PMUOE01770UC" && path2 != "PMUOE01800UC" && path2 != "PMUOE01802UC")//ADD 2013/11/13　鄭慕鈞 Redmine#41201 システム障害一覧№2　発注残のマイナスを許可する//DEL K2014/01/06　wangl2　フタバ
                            if (path2 != "PMUOE01300U" && path2 != "PMUOE01751UC" && path2 != "PMUOE01770UC" && path2 != "PMUOE01800UC" && path2 != "PMUOE01802UC" && path2 != "PMZAI01101UC")//ADD K2014/01/06　wangl2　フタバ
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            {
                                if (wkStockWork.SalesOrderCount < 0)
                                {
                                    wkStockWork.SalesOrderCount = 0;
                                }
                            }　　    
                            // --- UPD 2011/07/12 ----------<<<<<
                            //新しい最終売上日の方が最新の日付の場合最終売上日を更新
                            if (wkStockWork.LastSalesDate <= stockWork.LastSalesDate)
                                wkStockWork.LastSalesDate = stockWork.LastSalesDate;    //最終売上日

                            //新しい最終棚卸更新日の方が最新の日付の場合最終棚卸更新日を更新
                            if (wkStockWork.LastInventoryUpdate <= stockWork.LastInventoryUpdate)
                                wkStockWork.LastInventoryUpdate = stockWork.LastInventoryUpdate;    //最終棚卸更新日
                            
                            // 2009/06/26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //新しい最終仕入日の方が最新の日付の場合最終仕入日を更新
                            if (wkStockWork.LastStockDate <= stockWork.LastStockDate)
                                wkStockWork.LastStockDate = stockWork.LastStockDate;    //最終仕入日
                            // 2009/06/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            //出荷可能数設定処理
                            SetShipmentPosCnt(ref wkStockWork);

                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //仕入単価の更新
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            //調整データからの呼び出しの場合で棚番更新区分「0:する」の場合に棚番を更新する
                            if ((procMode == (int)ct_ProcMode.StockAdjust) && (_whUpdateDiv == 0))
                            {
                                wkStockWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                            }

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += " , ACPODRCOUNTRF=@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERCOUNTRF=@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += " , STOCKTOTALPRICERF=@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += " , LASTSALESDATERF=@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE1RF=@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE2RF=@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += " , SHIPMENTCNTRF=@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += " , ARRIVALCNTRF=@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += " , STOCKCREATEDATERF=@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            
                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wkStockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            stockWork = wkStockWork;    //パラメータ入れ替え

                            // --- ADD 2009/12/03 ---------->>>>>
                            // 在庫マスタが論理削除されている場合
                            if (stockWork.LogicalDeleteCode == 1)
                            {
                                stockWork.LogicalDeleteCode = 0;
                            }
                            // --- ADD 2009/12/03 ----------<<<<<

                            insflg = false;
                        }
                        else
                        {
                            #region 在庫データ新規作成処理
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,MONTHORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKTOTALPRICERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSTOCKDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSALESDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                            selectTxt += "  ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,NMLSALODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKSUPPLIERCODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKCREATEDATERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += "  ,@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;

                            //SetInsertHeaderメソッドでlogicalDeleteCodeが上書きさせるため
                            int logicalDeleteCode = stockWork.LogicalDeleteCode;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            stockWork.LogicalDeleteCode = logicalDeleteCode;
                            #endregion

                            // --- ADD 2009/12/03 ---------->>>>>
                            // 在庫マスタが未登録時
                            stockWork.StockUnitPriceFl = 0;
                            // --- ADD 2009/12/03 ----------<<<<<

                            //出荷可能数設定処理
                            SetShipmentPosCnt(ref stockWork);
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //仕入単価の更新
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            wkStockWork = null;
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            insflg = true;
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                        SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                        SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                        SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                        SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                        SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                        paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                        //paraStockUnitPriceFl.Value = 0;
                        //paraStockTotalPrice.Value = 0;

                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                        paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                        paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                        paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                        paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                        paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                        paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                        paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);

                        if (insflg)
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                        }
                        else
                        {
                            // 2009/06/26 MANTIS 13242 >>>>>>>>>>>>>>>>>>>>>>>>>>
                            //paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDateTime);
                            // 2009/06/26 <<<<<<<<<<<<<<<<<<<<<<<<<<
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                        }
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START 松本 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END 松本 2015/01/28 -----<<<<<<	
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockWorkList = al;

            return status;
        }

        /// <summary>
        /// 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <param name="stockMngTtlStWork">在庫管理全体設定</param>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2021/06/10 田建委</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 デッドロック対応</br>
        public int WriteStockBlanketProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>>
            //return WriteStockBlanketProcProc(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
            // リトライ回数
            int retryCnt = ZERO_VALUE;
            // ログ出力クラス
            OutLogCommon outLogCommonObj = new OutLogCommon();
            // リトライ設定ワーク
            RetrySet retrySettingInfo = new RetrySet();
            // リトライ設定取得出力部品
            RetryXmlGetCommon retryCommon = new RetryXmlGetCommon();
            retryCommon.GetXmlInfo(CURRENT_PGID, RETRY_COUNT_DEFAULT, RETRY_INTERVAL_DEFAULT, ref retrySettingInfo);

            return this.WriteStockBlanketProcReTry(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
            // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<<
        }

        // --- ADD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>> 
        /// <summary>
        /// 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <param name="stockMngTtlStWork">在庫管理全体設定</param>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="retryCnt">リトライ回数</param>
        /// <param name="outLogCommonObj">ログ出力クラス</param>
        /// <param name="retrySettingInfo">リトライ設定ワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 2021/06/10 田建委</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 デッドロック対応</br>
        private int WriteStockBlanketProcReTry(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref int retryCnt, OutLogCommon outLogCommonObj, RetrySet retrySettingInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();

            // リトライ回数
            retryCnt++;

            // savepiont設定
            sqlTransaction.Save(SAVEPPIONT_W);

            bool lastRetry = false;
            if (retryCnt == retrySettingInfo.RetryCount)
            {
                lastRetry = true;
            }

            // 在庫情報を登録、更新する
            status = WriteStockBlanketProcProc(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction, lastRetry);

            //デッドロックの場合
            if (status == DEAD_LOCK_VALUE)
            {
                // ログ出力
                outLogCommonObj.OutputServerLog(CURRENT_PGID, string.Format(ERR_MEG_W, retryCnt.ToString()), serverLoginInfoAcquisition.EnterpriseCode, serverLoginInfoAcquisition.EmployeeCode, null);
                // リトライ回数まで
                if (retryCnt >= retrySettingInfo.RetryCount)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//元のSTATUS値を復元
                }
                else
                {
                    // 設定してsavepointをロールバック
                    sqlTransaction.Rollback(SAVEPPIONT_W);
                    // リトライ間隔でsleep
                    Thread.Sleep(retrySettingInfo.RetryInterval * 1000);
                    // リトライ処理を行う
                    status = this.WriteStockBlanketProcReTry(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
                }
            }

            return status;
        }
        // --- ADD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<< 

        /// <summary>
        /// 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <param name="stockMngTtlStWork">在庫管理全体設定</param>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="lastRetry">リトライフラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>UpdateNote : 2011/07/12 施炳中 </br>
        /// <br>             連番No.1027 発注残がマイナスになる場合は、固定で０をセットしているが、卸商仕入受信が起動元となる場合は、発注残のマイナスを許可する。</br>
        /// <br>UpdateNote : 2011/07/20 施炳中 </br>
        /// <br>             Redmine#23074 先頭から「：」までの文字列が「PMUOE01300U」か否かの判定の対応</br>
        /// <br>UpdateNote : 2011/07/21 堀田 </br>
        /// <br>             Redmine#23074 先頭から「：」までの文字列が「PMUOE01300U」か否かの判定対応の取得元の修正</br>
        /// <br>Update Note: 2021/06/10 田建委</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 デッドロック対応</br>
        // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>>
        //private int WriteStockBlanketProcProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int WriteStockBlanketProcProc(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, bool lastRetry)
        // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StockWork wkStockWork = null;
            bool insflg = false;
            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        //更新チェック処理
                        //Selectコマンドの生成
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {

                            //現在のデータをクラスへ格納
                            wkStockWork = CopyToStockWorkFromReader(ref myReader,1);

                            // double型のままで計算を行うと丸め誤差が生じる場合(例 0.37 + 0.31 = 0.67999999999999994)
                            // があるのでdecimal型にキャストして計算する
                            wkStockWork.SupplierStock = (double)((decimal)wkStockWork.SupplierStock + (decimal)stockWork.SupplierStock);
                            wkStockWork.AcpOdrCount = (double)((decimal)wkStockWork.AcpOdrCount + (decimal)stockWork.AcpOdrCount);
                            wkStockWork.SalesOrderCount = (double)((decimal)wkStockWork.SalesOrderCount + (decimal)stockWork.SalesOrderCount);
                            wkStockWork.MovingSupliStock = (double)((decimal)wkStockWork.MovingSupliStock + (decimal)stockWork.MovingSupliStock);
                            wkStockWork.ShipmentCnt = (double)((decimal)wkStockWork.ShipmentCnt + (decimal)stockWork.ShipmentCnt);
                            wkStockWork.ArrivalCnt = (double)((decimal)wkStockWork.ArrivalCnt + (decimal)stockWork.ArrivalCnt);

                            // --- UPD 2011/07/12 ---------->>>>>
                            // --- ADD m.suzuki 2010/10/13 ---------->>>>>
                            //  // 発注残数がマイナスになる場合はゼロで補正する。
                            //  if ( wkStockWork.SalesOrderCount < 0 )
                            //  {
                            //    wkStockWork.SalesOrderCount = 0;
                            //  }
                            //  // --- ADD m.suzuki 2010/10/13 ----------<<<<<

                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //---起動元プロセスの取得
                            //Assembly myAssembly = Assembly.GetEntryAssembly();
                            //string path1 = myAssembly.Location;
                            //string path2 = Path.GetFileName(path1);
                            object obje = (object)this;
                            FileHeader filehd2 = new FileHeader(obje);

                            string path2 = filehd2.UpdAssemblyId1;
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            
                            // 卸商仕入受信以外で、発注残数がマイナスになる場合はゼロで補正
                            // --- ADD 2011/07/20 ---------->>>>>
                            int tempIndex = path2.IndexOf(":");
                            if (tempIndex > 0)
                            {
                                path2 = path2.Substring(0, tempIndex);
                            }
                            // --- ADD 2011/07/20 ----------<<<<<
                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //if (path2 != "PMUOE01300U.exe")
                            if (path2 != "PMUOE01300U")
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            {
                                if (wkStockWork.SalesOrderCount < 0)
                                {
                                    wkStockWork.SalesOrderCount = 0;
                                }
                            }
                            // --- UPD 2011/07/12 ----------<<<<<

                            //出荷可能数設定処理
                            SetShipmentPosCnt(ref wkStockWork);

                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //仕入単価の更新
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            //調整データからの呼び出しの場合で棚番更新区分「0:する」の場合に棚番を更新する
                            //if ((procMode == (int)ct_ProcMode.StockAdjust) && (_whUpdateDiv == 0))
                            //{
                            //    wkStockWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                            //}

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += " , ACPODRCOUNTRF=@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERCOUNTRF=@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += " , STOCKTOTALPRICERF=@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += " , LASTSALESDATERF=@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE1RF=@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE2RF=@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += " , SHIPMENTCNTRF=@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += " , ARRIVALCNTRF=@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += " , STOCKCREATEDATERF=@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                            //IFileHeader flhd = (IFileHeader)wkStockWork;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            //wkStockWorkの変動項目(数量等)のみをセットし、他項目は引数の内容で更新する
                            //stockWork.StockUnitPriceFl = wkStockWork.StockUnitPriceFl;
                            stockWork.SupplierStock = wkStockWork.SupplierStock;
                            stockWork.AcpOdrCount = wkStockWork.AcpOdrCount;
                            stockWork.SalesOrderCount = wkStockWork.SalesOrderCount;
                            stockWork.MovingSupliStock = wkStockWork.MovingSupliStock;
                            stockWork.ShipmentPosCnt = wkStockWork.ShipmentPosCnt;
                            stockWork.StockTotalPrice = wkStockWork.StockTotalPrice;
                            stockWork.ShipmentCnt = wkStockWork.ShipmentCnt;
                            stockWork.ArrivalCnt = wkStockWork.ArrivalCnt;
                            
                            //stockWork = wkStockWork;    //パラメータ入れ替え

                            insflg = false;
                        }
                        else
                        {
                            #region 在庫データ新規作成処理
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,MONTHORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKTOTALPRICERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSTOCKDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSALESDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                            selectTxt += "  ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,NMLSALODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKSUPPLIERCODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKCREATEDATERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += "  ,@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;

                            //SetInsertHeaderメソッドでlogicalDeleteCodeが上書きさせるため
                            int logicalDeleteCode = stockWork.LogicalDeleteCode;
                            
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            stockWork.LogicalDeleteCode = logicalDeleteCode;
                            #endregion

                            //出荷可能数設定処理
                            SetShipmentPosCnt(ref stockWork);
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //仕入単価の更新
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            wkStockWork = null;
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            insflg = true;
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                        SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                        SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                        SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                        SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                        SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                        paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                        //paraStockUnitPriceFl.Value = 0;
                        //paraStockTotalPrice.Value = 0;

                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                        paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                        paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                        paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                        paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                        paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                        paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                        paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);

                        if (insflg)
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                        }
                        else
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                        }

                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START 松本 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END 松本 2015/01/28 -----<<<<<<	
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>>
                //status = base.WriteSQLErrorLog(ex);

                //デットロックの場合、デッドロック値をstatusにセット、後のリトライ処理に利用
                if (ex.Number == DEAD_LOCK_VALUE)
                {
                    status = DEAD_LOCK_VALUE;
                }
                //デッドロック以外の場合、そのまま
                else
                {
                    status = base.WriteSQLErrorLog(ex);
                }
                // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<<
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>>
            //stockWorkList = al;
            if (status != DEAD_LOCK_VALUE && !lastRetry)
            {
                stockWorkList = al;
            }
            // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<<

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 在庫情報を論理削除します
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int LogicalDelete(ref object stockWork)
        {
            return LogicalDeleteStock(ref stockWork, 0);
        }

        /// <summary>
        /// 論理削除在庫情報を復活します
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除在庫情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int RevivalLogicalDelete(ref object stockWork)
        {
            return LogicalDeleteStock(ref stockWork, 1);
        }

        /// <summary>
        /// 在庫情報の論理削除を操作します
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報の論理削除を操作します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        private int LogicalDeleteStock(ref object stockWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(stockWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteStockProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    //sqlTransaction.Commit(); // DEL 劉超 2014/08/13
                //----- ADD START 劉超 2014/08/13 ----->>>>>>
                {
                    sqlTransaction.Commit();
                    //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                    //synchExecuteMng.SyncReqExecute();
                }
                //----- ADD END 劉超 2014/08/13 -----<<<<<<
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "StockDB.LogicalDeleteStock :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 在庫情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int LogicalDeleteStockProc(ref ArrayList stockWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockProcProc(ref stockWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        private int LogicalDeleteStockProcProc(ref ArrayList stockWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        //Selectコマンドの生成
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) stockWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else stockWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START 松本 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END 松本 2015/01/28 -----<<<<<<	
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockWorkList = al;

            return status;

        }
        
        #endregion

        #region [Delete]
        /// <summary>
        /// 在庫情報を物理削除します
        /// </summary>
        /// <param name="parabyte">在庫情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 在庫情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteStockProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    //sqlTransaction.Commit(); // DEL 劉超 2014/08/13
                //----- ADD START 劉超 2014/08/13 ----->>>>>>
                {
                    sqlTransaction.Commit();
                    //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                    //synchExecuteMng.SyncReqExecute();
                }
                //----- ADD END 劉超 2014/08/13 -----<<<<<<
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 在庫情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWorkList">在庫情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫情報を物理削除します(外部からのSqlConnection, SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>UpdateNote : 2021/06/10 田建委</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 デッドロック対応</br>
        public int DeleteStockProc(ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>>
            //return DeleteStockProcProc(stockWorkList, ref sqlConnection, ref sqlTransaction);
            // リトライ回数
            int retryCnt = ZERO_VALUE;
            // ログ出力クラス
            OutLogCommon outLogCommonObj = new OutLogCommon();
            // リトライ設定ワーク
            RetrySet retrySettingInfo = new RetrySet();
            // リトライ設定取得出力部品
            RetryXmlGetCommon retryCommon = new RetryXmlGetCommon();
            retryCommon.GetXmlInfo(CURRENT_PGID, RETRY_COUNT_DEFAULT, RETRY_INTERVAL_DEFAULT, ref retrySettingInfo);

            return this.DeleteStockProcReTry(stockWorkList, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
            // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<<
        }

        // --- ADD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>> 
        /// <summary>
        /// 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="retryCnt">リトライ回数</param>
        /// <param name="outLogCommonObj">ログ出力クラス</param>
        /// <param name="retrySettingInfo">リトライ設定ワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 2021/06/10 田建委</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 デッドロック対応</br>
        private int DeleteStockProcReTry(ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref int retryCnt, OutLogCommon outLogCommonObj, RetrySet retrySettingInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();

            // リトライ回数
            retryCnt++;

            // savepiont設定
            sqlTransaction.Save(SAVEPPIONT_D);

            // 在庫情報を物理削除する
            status = DeleteStockProcProc(stockWorkList, ref sqlConnection, ref sqlTransaction);

            //デッドロックの場合
            if (status == DEAD_LOCK_VALUE)
            {
                // ログ出力
                outLogCommonObj.OutputServerLog(CURRENT_PGID, string.Format(ERR_MEG_D, retryCnt.ToString()), serverLoginInfoAcquisition.EnterpriseCode, serverLoginInfoAcquisition.EmployeeCode, null);
                // リトライ回数まで
                if (retryCnt >= retrySettingInfo.RetryCount)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//元のSTATUS値を復元
                }
                else
                {
                    // 設定してsavepointをロールバック
                    sqlTransaction.Rollback(SAVEPPIONT_D);
                    // リトライ間隔でsleep
                    Thread.Sleep(retrySettingInfo.RetryInterval * 1000);
                    // リトライ処理を行う
                    status = this.DeleteStockProcReTry(stockWorkList, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
                }
            }

            return status;
        }
        // --- ADD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<< 

        /// <summary>
        /// 在庫情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWorkList">在庫情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫情報を物理削除します(外部からのSqlConnection, SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>UpdateNote : 2021/06/10 田建委</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 デッドロック対応</br>
        private int DeleteStockProcProc(ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt = "";

                for (int i = 0; i < stockWorkList.Count; i++)
                {
                    StockWork stockWork = stockWorkList[i] as StockWork;

                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "FROM STOCKRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "DELETE" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                    //----- ADD START 松本 2015/01/28 ----->>>>>>
                    sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                    sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                    //----- ADD END 松本 2015/01/28 -----<<<<<<	
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 ----->>>>>
                //status = base.WriteSQLErrorLog(ex);

                //デットロックの場合、デッドロック値をstatusにセット、後のリトライ処理に利用
                if (ex.Number == DEAD_LOCK_VALUE)
                {
                    status = DEAD_LOCK_VALUE;
                }
                //デッドロック以外の場合、そのまま
                else
                {
                    status = base.WriteSQLErrorLog(ex);
                }
                // --- UPD 2021/06/10 田建委 PMKOBETSU-4144 -----<<<<<
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockWork stockWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "STOCK.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (string.IsNullOrEmpty(stockWork.SectionCode) == false)
            {
                retstring += " AND STOCK.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
            }

            //倉庫コード
            if (string.IsNullOrEmpty(stockWork.WarehouseCode) == false)
            {
                retstring += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
            }

            //商品番号
            if (string.IsNullOrEmpty(stockWork.GoodsNo) == false)
            {
                retstring += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
            }

            //商品メーカーコード
            if (stockWork.GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
            }

            return retstring;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 検索条件文字列生成＋条件値設定 （自動回答処理専用）
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockWorkList">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br></br>
        private string MakeWhereString(ref SqlCommand sqlCommand, List<StockWork> stockWorkList, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "STOCK.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWorkList[0].EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (string.IsNullOrEmpty(stockWorkList[0].SectionCode) == false)
            {
                retstring += " AND STOCK.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWorkList[0].SectionCode);
            }

            // 商品番号・商品メーカーコードセット
            if (stockWorkList != null && stockWorkList.Count != 0)
            {
                bool searchFlag = false;
                for(int i = 0; i < stockWorkList.Count; i++)
                {
                    StockWork wk = stockWorkList[i];

                    if (!string.IsNullOrEmpty(wk.GoodsNo) && wk.GoodsMakerCd != 0)
                    {
                        if (i == 0)
                        {
                            retstring += " AND (  ";
                        }
                        else
                        {
                            retstring += " OR ";
                        }
                        searchFlag = true;
                        retstring += " ( STOCK.GOODSNORF='" + wk.GoodsNo + "'";
                        retstring += " AND STOCK.GOODSMAKERCDRF=" + wk.GoodsMakerCd.ToString().Trim() + " )" + Environment.NewLine;
                    }
                }
                if (searchFlag) retstring += " )  " + Environment.NewLine;
            }

            return retstring;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">0:別マスタからの取得項目もセット</param>
        /// <returns>StockWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            StockWork wkStockWork = new StockWork();

            #region クラスへ格納
            wkStockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            wkStockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            wkStockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
            wkStockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            wkStockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkStockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            wkStockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            wkStockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
            wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkStockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            wkStockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            wkStockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
            wkStockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            wkStockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
            wkStockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkStockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
            wkStockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
            wkStockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
            wkStockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
            wkStockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkStockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            wkStockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            wkStockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            
            if (mode == 0)
            {
                wkStockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                wkStockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            }
            #endregion

            return wkStockWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockWork[] StockWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is StockWork)
                    {
                        StockWork wkStockWork = paraobj as StockWork;
                        if (wkStockWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockWorkArray = (StockWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockWork[]));
                        }
                        catch (Exception) { }
                        if (StockWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockWork wkStockWork = (StockWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockWork));
                                if (wkStockWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region 在庫データ→在庫受払履歴データ
        /// <summary>
        /// 在庫情報を登録、更新します
        /// </summary>
        /// <param name="stockWorkList">在庫リスト</param>
        /// <param name="stockAcPayHistWorkList">在庫受払履歴リスト</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.02</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        private void SetstockAcPayHist(ref ArrayList stockWorkList, ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //更新後の在庫データの数量を在庫受払履歴データへ反映させる

            //在庫受払履歴データをループ
            for (int i = 0; i < stockAcPayHistWorkList.Count; i++)
            {
                StockAcPayHistWork wkStockAcPayHistWork = stockAcPayHistWorkList[i] as StockAcPayHistWork;
                StockWork wkStockWork = new StockWork();
                wkStockWork.EnterpriseCode = wkStockAcPayHistWork.EnterpriseCode;
                wkStockWork.GoodsMakerCd = wkStockAcPayHistWork.GoodsMakerCd;
                wkStockWork.GoodsNo = wkStockAcPayHistWork.GoodsNo;
                
                if (wkStockAcPayHistWork.AcPaySlipCd == (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveShipment)
                {
                    //wkStockWork.SectionCode = wkStockAcPayHistWork.BfSectionCode;
                    wkStockWork.WarehouseCode = wkStockAcPayHistWork.BfEnterWarehCode;
                }
                else if (wkStockAcPayHistWork.AcPaySlipCd == (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveArrival)
                {
                    //wkStockWork.SectionCode = wkStockAcPayHistWork.AfSectionCode;
                    wkStockWork.WarehouseCode = wkStockAcPayHistWork.AfEnterWarehCode;
                }
                else
                {
                    //wkStockWork.SectionCode = wkStockAcPayHistWork.SectionCode;
                    wkStockWork.WarehouseCode = wkStockAcPayHistWork.WarehouseCode;
                }
          

                int status = ReadProc(ref wkStockWork, 0, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    wkStockAcPayHistWork.SupplierStock = wkStockWork.SupplierStock;
                    wkStockAcPayHistWork.AcpOdrCount = wkStockWork.AcpOdrCount;
                    wkStockAcPayHistWork.SalesOrderCount = wkStockWork.SalesOrderCount;
                    wkStockAcPayHistWork.MovingSupliStock = wkStockWork.MovingSupliStock;
                    wkStockAcPayHistWork.NonAddUpShipmCnt = wkStockWork.ShipmentCnt;
                    wkStockAcPayHistWork.NonAddUpArrGdsCnt = wkStockWork.ArrivalCnt;
                    wkStockAcPayHistWork.ShipmentPosCnt = wkStockWork.ShipmentPosCnt;
                    
                    // double型による計算では丸め誤差が発生してしまう為、decimal型にキャストして計算する
                    decimal SupplierStock = (decimal)wkStockWork.SupplierStock;
                    decimal ArrivalCnt = (decimal)wkStockWork.ArrivalCnt;
                    decimal ShipmentCnt = (decimal)wkStockWork.ShipmentCnt;
                    decimal MovingSupliStock = (decimal)wkStockWork.MovingSupliStock;

                    wkStockAcPayHistWork.PresentStockCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - MovingSupliStock);
                }
            }
        }
        #endregion

        #region IOWriteテスト用
        /// <summary>
        /// 在庫情報を登録、更新します
        /// </summary>
        /// <param name="stockWork">StockWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : テスト用にIOWriteを直接呼出し在庫情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int Write(ref object stockWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = "";

            string origin = "";
            CustomSerializeArrayList paraList = stockWork as CustomSerializeArrayList;
            int position = 0;
            string param = "";
            object freeParam = null;
            string retItemInfo = "";
            SqlEncryptInfo sqlEncryptInfo = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                CustomSerializeArrayList cList = null;
                //write実行
                status = Write(origin, ref cList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    //sqlTransaction.Commit(); // DEL 劉超 2014/08/13
                //----- ADD START 劉超 2014/08/13 ----->>>>>>
                {
                    sqlTransaction.Commit();
                    //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                    //synchExecuteMng.SyncReqExecute();
                }
                //----- ADD END 劉超 2014/08/13 -----<<<<<<
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                stockWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockDB.Write(ref object stockWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 在庫排他パラメータ作成処理
        /// </summary>
        /// <param name="stocklist"></param>
        /// <param name="exparaList"></param>
        /// <br>Note       : 在庫排他用のパラメータを作成します。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        private void SetExpara(ArrayList stocklist, out List<StockExclsvDataParam> exparaList)
        {
            exparaList = new List<StockExclsvDataParam>();

            StockExclsvDataParam expara = null;
            for (int i = 0; i < stocklist.Count; i++)
            {
                expara = new StockExclsvDataParam();
                expara.EnterpriseCode = ((StockWork)stocklist[i]).EnterpriseCode;
                expara.WarehouseCode = ((StockWork)stocklist[i]).WarehouseCode;
                expara.GoodsMakerCd = ((StockWork)stocklist[i]).GoodsMakerCd;
                expara.GoodsNo = ((StockWork)stocklist[i]).GoodsNo;
                exparaList.Add(expara);
            }
        }
        #endregion

        #region IFunctionCallTargetWrite メンバ
        /// <summary>
        /// 在庫削除処理(IOWirte)
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの削除処理を行います。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int listPos_StockWork = 0;
            int listPos_StockAcPayHistWork = 0;
            ArrayList stockWorkList = null;
            ArrayList stockAcPayHistWorkList = null;
            StockMngTtlStWork stockMngTtlStWork = null;     //在庫管理全体設定

            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                return status;
            }
            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。更新対象パラメータが未指定です");
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockWorkList = paraList[position] as ArrayList;
                listPos_StockWork = position;
            }

            //リストから必要な情報を取得
            for (int i = 0; i < paraList.Count; i++)
            {
                ArrayList wkal = paraList[i] as ArrayList;
                if (wkal != null)
                {
                    if (wkal.Count > 0)
                    {
                        //在庫マスタでリストがNULLの場合
                        if (wkal[0] is StockWork && stockWorkList == null)
                        {
                            stockWorkList = wkal;
                            listPos_StockWork = i;//格納されていた位置を退避
                        }
                        //在庫受払履歴マスタの場合
                        if (wkal[0] is StockAcPayHistWork)
                        {
                            stockAcPayHistWorkList = wkal;
                            listPos_StockAcPayHistWork = i;//格納されていた位置を退避
                        }
                    }
                }
            }

            //在庫管理全体設定取得
            if (stockWorkList != null)
            {
                status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
            }

            //在庫マスタ更新
            if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = StockAddCountUPProc((int)ct_ProcMode.StockSlip, (int)ct_WriteMode.delete, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫マスタ更新に失敗しました。";
            }

            //更新後の在庫データを在庫受払履歴データへ反映
            if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

            //在庫受払履歴マスタ更新
            if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                
                //status = _stockAcPayHistDB.LogicalDeleteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                //伝票削除時にも受払履歴は追加するように修正
                status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫受払履歴マスタ更新に失敗しました。";
            }

            //更新結果を戻す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (stockWorkList != null)
                    paraList[listPos_StockWork] = stockWorkList;
                if (stockAcPayHistWorkList != null)
                    paraList[listPos_StockAcPayHistWork] = stockAcPayHistWorkList;
            }

            return status;
        }

        /// <summary>
        /// 在庫更新前処理(IOWrite)
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの更新前処理を行います。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        }
        
        /// <summary>
        /// 在庫削除前処理(IOWrite)現在未使用
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="list">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの削除前処理を行います。現在未使用</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList list, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// 在庫削除処理(IOWrite)在庫移動用
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの更新処理を行います。(在庫移動用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int WriteForStockMove(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            return WriteProc((int)ct_ProcMode.StockMove, origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        // --- ADD K2020/03/25 陳艶丹　デッドロックの対応 ---------->>>>>
        /// <summary>
        /// 在庫削除処理と在庫マスタの発注数の更新(IOWrite)在庫移動用
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="stockWorkList">在庫マスタの発注数の更新List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫データの更新処理を行います。(在庫移動用)</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        /// </remarks>
        public int WriteForStockMoveHandleDeadLock(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, ref ArrayList stockWorkList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            return WriteForStockMoveHandleDeadLock((int)ct_ProcMode.StockMove, origin, ref originList, ref paraList, ref stockWorkList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// 在庫更新処理(IOWrite)(在庫移動用)
        /// </summary>
        /// <param name="procMode">処理区分</param>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="stockOrderCountWorkList">在庫マスタの発注数の更新List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫データの更新処理を行います。</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        /// </remarks>
        private int WriteForStockMoveHandleDeadLock(int procMode, string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, ref ArrayList stockOrderCountWorkList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int listPos_StockWork = 0;
            int listPos_StockAcPayHistWork = 0;
            ArrayList stockWorkList = null;
            ArrayList stockAcPayHistWorkList = null;
            StockMngTtlStWork stockMngTtlStWork = null;     //在庫管理全体設定

            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                return status;
            }
            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。更新対象パラメータが未指定です");
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockWorkList = paraList[position] as ArrayList;
                listPos_StockWork = position;
            }
            string resNm = "";

            try
            {

                //リストから必要な情報を取得
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫マスタでリストがNULLの場合
                            if (wkal[0] is StockWork && stockWorkList == null)
                            {
                                stockWorkList = wkal;
                                listPos_StockWork = i;//格納されていた位置を退避
                            }
                            //在庫受払履歴マスタの場合
                            if (wkal[0] is StockAcPayHistWork)
                            {
                                stockAcPayHistWorkList = wkal;
                                listPos_StockAcPayHistWork = i;//格納されていた位置を退避
                            }
                        }
                    }
                }
                string enterpriseCode = string.Empty;
                if (stockWorkList != null)
                {
                    enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
                }
                else if (stockAcPayHistWorkList != null)
                {
                    enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
                }

                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockDB.WriteForStockMoveHandleDeadLock:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockDB.WriteForStockMoveHandleDeadLock:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = this.GetResourceName(enterpriseCode);
                if (resNm != "")
                {
                    //ＡＰロック
                    status = Lock(resNm, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            retMsg = "ロックタイムアウトが発生しました。";
                        }
                        else
                        {
                            retMsg = "排他ロックに失敗しました。";
                        }
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_Lock:{0}", retMsg), status);
                        return status;
                    }
                }

                //在庫管理全体設定取得
                if (stockWorkList != null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "プログラムエラー。在庫管理全体設定情報取得に失敗しました。";
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_GetStockMngTtlStWork:{0}", retMsg), status);
                    }
                }

                //在庫マスタ更新
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StockAddCountUPProc(procMode, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "プログラムエラー。在庫マスタ更新に失敗しました。";
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_StockAddCountUPProc1:{0}", retMsg), status);
                    }
                }

                //更新後の在庫データを在庫受払履歴データへ反映
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //在庫受払履歴データ更新
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //売上、仕入、調整の受払更新
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "プログラムエラー。在庫受払履歴マスタ更新に失敗しました。";
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_WriteStockAcPayHistProc:{0}", retMsg), status);
                    }
                }

                //更新結果を戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockWorkList != null)
                        paraList[listPos_StockWork] = stockWorkList;
                    if (stockAcPayHistWorkList != null)
                        paraList[listPos_StockAcPayHistWork] = stockAcPayHistWorkList;
                }

                //在庫マスタ発注数の更新
                if (stockOrderCountWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StockAddCountUPProc(procMode, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockOrderCountWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "プログラムエラー。在庫マスタ発注数の更新に失敗しました。";
                        base.WriteErrorLog(string.Format("StockDB.WriteForStockMoveHandleDeadLock_StockAddCountUPProc2:{0}", retMsg), status);
                    }
                }
            }
            finally
            {
                if (resNm != "")
                {
                    //ＡＰアンロック
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteForStockMoveData_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.WriteForStockMoveData_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteForStockMoveData_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                    }
                    else
                    {
                        //●排他ロックを解除する
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.WriteForStockMoveData_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                        }
                    }
                }
            }
            return status;
        }
        // --- ADD K2020/03/25 陳艶丹　デッドロックの対応 ----------<<<<<


        /// <summary>
        /// 在庫削除処理(IOWrite)在庫移動用
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <param name="whUpdateDiv">棚卸更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの更新処理を行います。(在庫移動用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int WriteForStockAdjust(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, int whUpdateDiv)
        {
            _whUpdateDiv = whUpdateDiv;
            return WriteProc((int)ct_ProcMode.StockAdjust, origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// 在庫更新処理(IOWrite)
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの更新処理を行います。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            return WriteProc((int)ct_ProcMode.StockSlip, origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// 在庫更新処理(IOWrite)
        /// </summary>
        /// <param name="procMode">処理区分</param>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの更新処理を行います。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int WriteProc(int procMode, string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int listPos_StockWork = 0;
            int listPos_StockAcPayHistWork = 0;
            ArrayList stockWorkList = null;
            ArrayList stockAcPayHistWorkList = null;
            StockMngTtlStWork stockMngTtlStWork = null;     //在庫管理全体設定
            
            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                return status;
            }
            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。更新対象パラメータが未指定です");
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockWorkList = paraList[position] as ArrayList;
                listPos_StockWork = position;
            }
            
            string resNm = "";
            
            try
            {
            
                //リストから必要な情報を取得
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫マスタでリストがNULLの場合
                            if (wkal[0] is StockWork && stockWorkList == null)
                            {
                                stockWorkList = wkal;
                                listPos_StockWork = i;//格納されていた位置を退避
                            }
                            //在庫受払履歴マスタの場合
                            if (wkal[0] is StockAcPayHistWork)
                            {
                                stockAcPayHistWorkList = wkal;
                                listPos_StockAcPayHistWork = i;//格納されていた位置を退避
                            }
                        }
                    }
                }

                if (stockWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockWork)stockWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockWork)stockWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.WriteProc:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteProc:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }
                else if (stockAcPayHistWorkList != null)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //resNm = GetResourceName(((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode);
                    string enterpriseCode = ((StockAcPayHistWork)stockAcPayHistWorkList[0]).EnterpriseCode;
                    // 企業コードが空欄の場合
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                            // サーバー側共通部品で空欄の企業コードが取得される場合
                            if (string.IsNullOrEmpty(enterpriseCode))
                            {
                                base.WriteErrorLog("StockDB.WriteProc:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                            }
                        }
                        catch
                        {
                            base.WriteErrorLog("StockDB.WriteProc:共通部品で企業コードを取得した際に例外が発生しました。", status);
                        }
                    }
                    // ロックリソース名
                    resNm = GetResourceName(enterpriseCode);
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }
                
                if (resNm != "")
                {   
                    //ＡＰロック
                    status = Lock(resNm,sqlConnection,sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            retMsg = "ロックタイムアウトが発生しました。";
                        }
                        else
                        {
                            retMsg = "排他ロックに失敗しました。";
                        }
                        base.WriteErrorLog(string.Format("StockDB.WriteProc_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                        return status;
                    }

                }
                
                //在庫管理全体設定取得
                if (stockWorkList != null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫管理全体設定情報取得に失敗しました。";
                }

                //在庫マスタ更新
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StockAddCountUPProc(procMode, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫マスタ更新に失敗しました。";
                }

                //更新後の在庫データを在庫受払履歴データへ反映
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //在庫受払履歴データ更新
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //if ((procMode == (int)ct_ProcMode.StockMove))
                    //{
                    //    //移動の受払更新
                    //    status = _stockAcPayHistDB.WriteStockMoveAcPayHistProc(ref stockAcPayHistWorkList, acPayHistDateTime, ref sqlConnection, ref sqlTransaction);
                    //}
                    //else
                    //{
                    //    //売上、仕入、調整の受払更新
                        status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
                    //}
                    
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫受払履歴マスタ更新に失敗しました。";
                }

                //更新結果を戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockWorkList != null)
                        paraList[listPos_StockWork] = stockWorkList;
                    if (stockAcPayHistWorkList != null)
                        paraList[listPos_StockAcPayHistWork] = stockAcPayHistWorkList;
                }
            }
            finally
            {
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    ////ＡＰアンロック
                    //Release(resNm,sqlConnection,sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteProc_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockDB.WriteProc_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockDB.WriteProc_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                    }
                    else
                    {
                        //●排他ロックを解除する
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockDB.WriteProc_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }
            }
            return status;
        }
        #endregion

        #region 在庫管理全体設定取得処理
        /// <summary>
        /// 在庫管理全体設定取得処理
        /// </summary>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="stockMngTtlStWork">在庫全体設定マスタ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定の取得処理を行います。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        private int GetStockMngTtlStWork(ArrayList stockList, out StockMngTtlStWork stockMngTtlStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockMngTtlStWork = new StockMngTtlStWork();
            if (stockList != null && stockList.Count > 0)
            {
                stockMngTtlStWork.EnterpriseCode = ((StockWork)stockList[0]).EnterpriseCode;   //企業コード
            }
            else
            {
                return status;
            }
 
            stockMngTtlStWork.SectionCode = "00";                 //全社共通設定を読み込み
 
            //在庫管理全体設定リード呼び出し
            status = _stockMngTtlStDB.ReadProc(ref stockMngTtlStWork, 0, ref sqlConnection, ref sqlTransaction);

            return status;
        }
        #endregion

        #region IFunctionCallTargetRead メンバ
        
        /// <summary>
        /// 在庫データ読込処理
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="paraList">呼び出し元List</param>
        /// <param name="retList">戻り値List</param>
        /// <param name="position">対象オブジェクト位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns></returns>
        /// <br>Note       : 在庫データの読込処理を行います。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int Read(string origin, ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, string param, ref object freeParam, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            ArrayList StockList = null;
            ArrayList StockretList = null;

            //リストから必要な情報を取得
            for (int i = 0; i < paraList.Count; i++)
            {
                ArrayList wkal = paraList[i] as ArrayList;
                if (wkal != null)
                {
                    if (wkal.Count > 0)
                    {
                        //在庫マスタの場合
                        if (wkal[0] is StockWork)
                        {
                            StockList = wkal;
                        }
                    }
                }
            }

            if (StockList != null)
            {
                status = ReadStockByStockCommonPara(StockList, out StockretList, ref sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && StockretList != null)
                    retList.Add(StockretList);
            }

            return status;
        }
        

        /// <summary>
        /// 在庫データ取得処理
        /// </summary>
        /// <param name="paraList">条件リスト</param>
        /// <param name="retList">結果リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データ取得処理を行います。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.25</br>
        public int ReadStockByStockCommonPara(ArrayList paraList, out ArrayList retList, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadStockByStockCommonParaProc(paraList, out retList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫データ取得処理
        /// </summary>
        /// <param name="paraList">条件リスト</param>
        /// <param name="retList">結果リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データ取得処理を行います。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.25</br>
        public int ReadStockByStockCommonPara(ArrayList paraList, out ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadStockByStockCommonParaProc(paraList, out retList, ref sqlConnection, ref sqlTransaction);
        }
            
        /// <summary>
        /// 在庫データ取得処理
        /// </summary>
        /// <param name="paraList">条件リスト</param>
        /// <param name="retList">結果リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データ取得処理を行います。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.25</br>
        public int ReadStockByStockCommonParaProc(ArrayList paraList, out ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadStockByStockCommonParaProcProc(paraList, out retList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫データ取得処理
        /// </summary>
        /// <param name="paraList">条件リスト</param>
        /// <param name="retList">結果リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データ取得処理を行います。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.25</br>
        /// <br>Update Note: 2012/05/29 zhangy3 </br>
        /// <br>管理番号   : 10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30029 在庫マスタ一覧印刷 特定条件下での印刷不具合</br>
        private int ReadStockByStockCommonParaProcProc(ArrayList paraList, out ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            retList = new ArrayList();
            StockWork stockWork = null;
            string selectTxt = "";
            try
            {
                if (paraList != null)
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        StockWork stockList = paraList[i] as StockWork;

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                        selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                        //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                        //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "ON " + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                        //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;//DEL 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED) " + Environment.NewLine;//ADD 2012/05/29 zhangy3 FOR Redmine #30029
                        selectTxt += "ON " + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                        if (sqlTransaction != null)
                            sqlCommand.Transaction = sqlTransaction;

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockList.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockList.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockList.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockList.GoodsNo);

                        if (myReader != null)
                            if (myReader.IsClosed == false) myReader.Close();

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            stockWork = CopyToStockWorkFromReader(ref myReader,0);
                            retList.Add(stockWork);
                        }
                    }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
        /// <summary>
        /// 在庫更新処理(棚卸過不足更新用)
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="stockMngTtlStWork">stockMngTtlStWork</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <param name="whUpdateDiv">棚卸更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの更新処理を行います。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        public int WriteFromInventory(string origin, StockMngTtlStWork stockMngTtlStWork, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, int whUpdateDiv)
        {
            _whUpdateDiv = whUpdateDiv;
            return WriteFromInventoryProc((int)ct_ProcMode.StockAdjust, origin, stockMngTtlStWork, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// 在庫更新処理(棚卸過不足更新用)
        /// </summary>
        /// <param name="procMode">処理区分</param>
        /// <param name="origin">呼び出し元</param>
        /// <param name="stockMngTtlStWork">stockMngTtlStWork</param>
        /// <param name="originList">呼び出し元List</param>
        /// <param name="paraList">物理削除List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫データの更新処理を行います。</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        public int WriteFromInventoryProc(int procMode, string origin, StockMngTtlStWork stockMngTtlStWork, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            int listPos_StockWork = 0;
            int listPos_StockAcPayHistWork = 0;
            ArrayList stockWorkList = null;
            ArrayList stockAcPayHistWorkList = null;

            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                return status;
            }
            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。更新対象パラメータが未指定です");
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockWorkList = paraList[position] as ArrayList;
                listPos_StockWork = position;
            }

            try
            {

                //リストから必要な情報を取得
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫マスタでリストがNULLの場合
                            if (wkal[0] is StockWork && stockWorkList == null)
                            {
                                stockWorkList = wkal;
                                listPos_StockWork = i;//格納されていた位置を退避
                            }
                            //在庫受払履歴マスタの場合
                            if (wkal[0] is StockAcPayHistWork)
                            {
                                stockAcPayHistWorkList = wkal;
                                listPos_StockAcPayHistWork = i;//格納されていた位置を退避
                            }
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //在庫管理全体設定取得
                if (stockWorkList != null && stockMngTtlStWork == null)
                {
                    status = GetStockMngTtlStWork(stockWorkList, out stockMngTtlStWork, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫管理全体設定情報取得に失敗しました。";
                }

                //在庫マスタ更新
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StockAddCountUPProcFromInvent(procMode, (int)ct_WriteMode.Write, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫マスタ更新に失敗しました。";
                }

                //更新後の在庫データを在庫受払履歴データへ反映
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        SetstockAcPayHist(ref stockWorkList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                //在庫受払履歴データ更新
                if (stockAcPayHistWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "プログラムエラー。在庫受払履歴マスタ更新に失敗しました。";
                }

                //更新結果を戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockWorkList != null)
                        paraList[listPos_StockWork] = stockWorkList;
                    if (stockAcPayHistWorkList != null)
                        paraList[listPos_StockAcPayHistWork] = stockAcPayHistWorkList;
                }
            }
            finally
            {

            }
            return status;
        }

        /// <summary>
        /// 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <param name="stockMngTtlStWork">在庫管理全体設定</param>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        public int StockAddCountUPProcFromInvent(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return StockAddCountUPProcProcFromInvent(procMode, writeMode, stockMngTtlStWork, ref stockWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <param name="stockMngTtlStWork">在庫管理全体設定</param>
        /// <param name="stockWorkList">StockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫情報を登録、更新します。また在庫が存在する場合数量項目については加算します。(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/10/09</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             在庫マスタが論理削除されている場合の変更</br>
        /// <br>UpdateNote : 2011/07/12 施炳中 </br>
        /// <br>             連番No.1027 発注残がマイナスになる場合は、固定で０をセットしているが、卸商仕入受信が起動元となる場合は、発注残のマイナスを許可する。</br>
        /// <br>UpdateNote : 2011/07/20 施炳中 </br>
        /// <br>             Redmine#23074 先頭から「：」までの文字列が「PMUOE01300U」か否かの判定の対応</br>
        /// <br>UpdateNote : 2011/07/21 堀田 </br>
        /// <br>             Redmine#23074 先頭から「：」までの文字列が「PMUOE01300U」か否かの判定対応の取得元の修正</br>
        private int StockAddCountUPProcProcFromInvent(int procMode, int writeMode, StockMngTtlStWork stockMngTtlStWork, ref ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StockWork wkStockWork = null;
            bool insflg = false;
            try
            {
                string selectTxt = "";

                if (stockWorkList != null)
                {
                    for (int i = 0; i < stockWorkList.Count; i++)
                    {
                        StockWork stockWork = stockWorkList[i] as StockWork;

                        //更新チェック処理
                        //Selectコマンドの生成
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                        selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        selectTxt += " AND STOCK.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //現在のデータをクラスへ格納
                            wkStockWork = CopyToStockWorkFromReader(ref myReader, 1);

                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //数量の更新
                            //数量の足し込み(渡されたパラメータの数量が考慮されているものとして単純に加算します。
                            //実際は通常ならプラス、赤伝や取り消しなど削除の場合はマイナスになります。)
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★

                            // double型のままで計算を行うと丸め誤差が生じる場合(例 0.37 + 0.31 = 0.67999999999999994)
                            // があるのでdecimal型にキャストして計算する
                            wkStockWork.SupplierStock = (double)((decimal)wkStockWork.SupplierStock + (decimal)stockWork.SupplierStock);
                            wkStockWork.AcpOdrCount = (double)((decimal)wkStockWork.AcpOdrCount + (decimal)stockWork.AcpOdrCount);
                            wkStockWork.SalesOrderCount = (double)((decimal)wkStockWork.SalesOrderCount + (decimal)stockWork.SalesOrderCount);
                            wkStockWork.MovingSupliStock = (double)((decimal)wkStockWork.MovingSupliStock + (decimal)stockWork.MovingSupliStock);
                            wkStockWork.ShipmentCnt = (double)((decimal)wkStockWork.ShipmentCnt + (decimal)stockWork.ShipmentCnt);
                            wkStockWork.ArrivalCnt = (double)((decimal)wkStockWork.ArrivalCnt + (decimal)stockWork.ArrivalCnt);

                            // --- UPD 2011/07/12 ---------->>>>>
                            // --- ADD m.suzuki 2010/10/13 ---------->>>>>
                            //  // 発注残数がマイナスになる場合はゼロで補正する。
                            //  if ( wkStockWork.SalesOrderCount < 0 )
                            //  {
                            //    wkStockWork.SalesOrderCount = 0;
                            //  }
                            //  // --- ADD m.suzuki 2010/10/13 ----------<<<<<

                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //---起動元プロセスの取得
                            //Assembly myAssembly = Assembly.GetEntryAssembly();
                            //string path1 = myAssembly.Location;
                            //string path2 = Path.GetFileName(path1);
                            object obje = (object)this;
                            FileHeader filehd2 = new FileHeader(obje);

                            string path2 = filehd2.UpdAssemblyId1;
                            // --- UPD 2011/07/21 ------------------<<<<<<

                            // 卸商仕入受信以外で、発注残数がマイナスになる場合はゼロで補正
                            // --- ADD 2011/07/20 ---------->>>>>
                            int tempIndex = path2.IndexOf(":");
                            if (tempIndex > 0)
                            {
                                path2 = path2.Substring(0, tempIndex);
                            }
                            // --- ADD 2011/07/20 ----------<<<<<

                            // --- UPD 2011/07/21 ------------------>>>>>>
                            //if (path2 != "PMUOE01300U.exe")
                            if (path2 != "PMUOE01300U")
                            // --- UPD 2011/07/21 ------------------<<<<<<
                            {
                                if (wkStockWork.SalesOrderCount < 0)
                                {
                                    wkStockWork.SalesOrderCount = 0;
                                }
                            }
                            // --- UPD 2011/07/12 ----------<<<<<
                            //新しい最終売上日の方が最新の日付の場合最終売上日を更新
                            if (wkStockWork.LastSalesDate <= stockWork.LastSalesDate)
                                wkStockWork.LastSalesDate = stockWork.LastSalesDate;    //最終売上日

                            //新しい最終棚卸更新日の方が最新の日付の場合最終棚卸更新日を更新
                            if (wkStockWork.LastInventoryUpdate <= stockWork.LastInventoryUpdate)
                                wkStockWork.LastInventoryUpdate = stockWork.LastInventoryUpdate;    //最終棚卸更新日

                            // 2009/06/26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //新しい最終仕入日の方が最新の日付の場合最終仕入日を更新
                            if (wkStockWork.LastStockDate <= stockWork.LastStockDate)
                                wkStockWork.LastStockDate = stockWork.LastStockDate;    //最終仕入日
                            // 2009/06/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            //出荷可能数設定処理
                            SetShipmentPosCntFromInvent(ref wkStockWork, stockMngTtlStWork);

                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //仕入単価の更新
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            //調整データからの呼び出しの場合で棚番更新区分「0:する」の場合に棚番を更新する
                            if ((procMode == (int)ct_ProcMode.StockAdjust) && (_whUpdateDiv == 0))
                            {
                                wkStockWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                            }

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKRF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += " , ACPODRCOUNTRF=@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERCOUNTRF=@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += " , STOCKTOTALPRICERF=@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += " , LASTSALESDATERF=@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += " , SALESORDERUNITRF=@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE1RF=@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += " , STOCKNOTE2RF=@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += " , SHIPMENTCNTRF=@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += " , ARRIVALCNTRF=@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += " , STOCKCREATEDATERF=@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wkStockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            stockWork = wkStockWork;    //パラメータ入れ替え

                            // --- ADD 2009/12/03 ---------->>>>>
                            // 在庫マスタが論理削除されている場合
                            if (stockWork.LogicalDeleteCode == 1)
                            {
                                stockWork.LogicalDeleteCode = 0;
                            }
                            // --- ADD 2009/12/03 ----------<<<<<

                            insflg = false;
                        }
                        else
                        {
                            #region 在庫データ新規作成処理
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,MONTHORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKTOTALPRICERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSTOCKDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTSALESDATERF" + Environment.NewLine;
                            selectTxt += "  ,LASTINVENTORYUPDATERF" + Environment.NewLine;
                            selectTxt += "  ,MINIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                            selectTxt += "  ,NMLSALODRCOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,SALESORDERUNITRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKSUPPLIERCODERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            selectTxt += "  ,DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                            selectTxt += "  ,PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,STOCKNOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKCREATEDATERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
                            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@MONTHORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKTOTALPRICE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSTOCKDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTSALESDATE" + Environment.NewLine;
                            selectTxt += "  ,@LASTINVENTORYUPDATE" + Environment.NewLine;
                            selectTxt += "  ,@MINIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@MAXIMUMSTOCKCNT" + Environment.NewLine;
                            selectTxt += "  ,@NMLSALODRCOUNT" + Environment.NewLine;
                            selectTxt += "  ,@SALESORDERUNIT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKSUPPLIERCODE" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            selectTxt += "  ,@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE1" + Environment.NewLine;
                            selectTxt += "  ,@PARTSMANAGEMENTDIVIDE2" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE1" + Environment.NewLine;
                            selectTxt += "  ,@STOCKNOTE2" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
                            selectTxt += "  ,@STOCKCREATEDATE" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;

                            //SetInsertHeaderメソッドでlogicalDeleteCodeが上書きさせるため
                            int logicalDeleteCode = stockWork.LogicalDeleteCode;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            stockWork.LogicalDeleteCode = logicalDeleteCode;
                            #endregion

                            // --- ADD 2009/12/03 ---------->>>>>
                            // 在庫マスタが未登録時
                            stockWork.StockUnitPriceFl = 0;
                            // --- ADD 2009/12/03 ----------<<<<<

                            //出荷可能数設定処理
                            SetShipmentPosCntFromInvent(ref stockWork, stockMngTtlStWork);
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            //仕入単価の更新
                            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
                            wkStockWork = null;
                            //SetStockPrice(procMode, writeMode, stockMngTtlStWork, ref wkStockWork, ref stockWork);

                            insflg = true;
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                        SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                        SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                        SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                        SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                        SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                        SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                        paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                        //paraStockUnitPriceFl.Value = 0;
                        //paraStockTotalPrice.Value = 0;

                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                        paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                        paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                        paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                        paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                        paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                        paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                        paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                        paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                        paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                        paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);

                        if (insflg)
                        {
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.CreateDateTime);
                        }
                        else
                        {
                            // 2009/06/26 MANTIS 13242 >>>>>>>>>>>>>>>>>>>>>>>>>>
                            //paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDateTime);
                            // 2009/06/26 <<<<<<<<<<<<<<<<<<<<<<<<<<
                            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                        }
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockWork);
                        //----- ADD START 松本 2015/01/28 ----->>>>>>
                        sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                        sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                        //----- ADD END 松本 2015/01/28 -----<<<<<<	
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockWorkList = al;

            return status;
        }

        /// <summary>
        /// 出荷可能数設定処理
        /// </summary>
        /// <param name="stockWork">在庫データ</param>
        /// <br>Note       : 出荷可能数設定処理</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2011/08/29 wangf 連番1016の対応</br>
        private void SetShipmentPosCntFromInvent(ref StockWork stockWork, StockMngTtlStWork stockMngTtlStWork)
        {
            if (stockMngTtlStWork==null)
            {
                // 在庫管理全体設定の「現在庫表示区分」により、受注数は算出条件追加の判断
                StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
                stockMngTtlStWork = new StockMngTtlStWork();
                stockMngTtlStWork.EnterpriseCode = stockWork.EnterpriseCode;
                stockMngTtlStWork.SectionCode = "00";
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);
                // 在庫管理全体設定読み込み
                int status = stockMngTtlStDB.Read(ref parabyte, 0);
                if (status == 0)
                {
                    // XMLの読み込み
                    stockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
                }
            }

            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★
            //出荷可能数の計算式
            //出荷可能数＝仕入在庫数＋入荷数（未計上）ー 出荷数（未計上）ー 受注数 ー 移動中仕入在庫数
            //☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★

            // double型による計算では丸め誤差が発生してしまう為、decimal型にキャストして計算する
            decimal SupplierStock = (decimal)stockWork.SupplierStock;
            decimal ArrivalCnt = (decimal)stockWork.ArrivalCnt;
            decimal ShipmentCnt = (decimal)stockWork.ShipmentCnt;
            decimal AcpOdrCount = (decimal)stockWork.AcpOdrCount;
            decimal MovingSupliStock = (decimal)stockWork.MovingSupliStock;

            if (stockMngTtlStWork.PreStckCntDspDiv == 0)
            {
                // 受注分含む
                stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - AcpOdrCount - MovingSupliStock);
            }
            else
            {
                // 受注分含まない
                stockWork.ShipmentPosCnt = (double)(SupplierStock + ArrivalCnt - ShipmentCnt - MovingSupliStock);
            }
        }

        // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<
    }

    #region 在庫比較クラス
    /// <summary>
    /// 在庫クラス比較クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    /// <br></br>
    /// <br>Update Note: 2007.09.25 長内 DC.NS用に修正</br>
    public class StockWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockWork cx = (StockWork)x;
            StockWork cy = (StockWork)y;

            //拠点コード
            //result = cx.SectionCode.CompareTo(cy.SectionCode);
            //倉庫コード
            result = cx.WarehouseCode.CompareTo(cy.WarehouseCode);
            //メーカーコード
            if (result == 0)
                result = cx.GoodsMakerCd - cy.GoodsMakerCd;
            //商品コード
            if (result == 0)
                result = string.Compare(cx.GoodsNo, cy.GoodsNo);

            //結果を返す
            return result;
        }
    }
    #endregion

}
