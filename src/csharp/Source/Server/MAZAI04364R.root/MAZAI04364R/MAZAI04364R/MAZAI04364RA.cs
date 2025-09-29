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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫調整データDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫調整データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.02.14</br>
    /// <br></br>
    /// <br>Update Note: 2008.1.11 横川 DC.NS用に修正</br>
    /// <br>Update Note: 2008.08.05 長内 PM.NS用に修正</br>
    /// <br>Update Note: 2009.04.09 長内 受払履歴の拠点コードセット内容変更</br>
    /// <br>Update Note: 2009.05.25 長内 棚卸データ更新メソッドの複数伝票対応</br>
    /// <br>Update Note: 2009.06.15 長内 過不足更新で棚番が更新されない不具合の修正</br>
    /// <br>Update Note: 2009/07/30 畠中 在庫調整データ登録時の担当者名称切り捨て処理修正</br>
    /// <br>Update Note: 2010/12/20 曹文傑 障害改良対応ｘ月</br>
    /// <br>             在庫仕入データ登録時、在庫マスタの最終仕入日が更新されない不具合を修正</br>
    /// <br>Update Note: 2011/08/11 孫東響 SCM対応-拠点管理（10704767-00）</br>
    /// <br>             在庫調整データ受信時に在庫マスタの更新を行う</br>
    /// <br>Update Note: 2011/09/02 孫東響 #24259</br>
    /// <br>             ①「値がセットされていない」修正</br>
    /// <br>             ②「在庫受払データが作成されない。」修正</br>
    /// <br>Update Note: 2011/09/06 孫東響 SCM対応-拠点管理（10704767-00）</br>
    /// <br>             #24355受信時の更新処理</br>
    /// <br>Update Note: 2011/09/16 孫東響 SCM対応-拠点管理（10704767-00）</br>
    /// <br>             #25139 拠点管理　在庫仕入データ受信処理　棚卸調整データについて</br>
    /// <br>Update Note: 2013/10/09 yangyi</br>
    /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
    /// <br>Update Note: K2015/08/21 陳嘯</br>
    /// <br>             redmine#46790  棚卸過不足更新　メモリアウトの修正</br>
    /// <br>Update Note: K2015/09/09 陳嘯</br>
    /// <br>             redmine#46790  在庫調整明細データの定価セット不正の対応</br>
    /// <br>Update Note: ハンディターミナル在庫仕入（UOE以外）の登録処理で最終仕入日の補足</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    [Serializable]
    public class StockAdjustDB : RemoteWithAppLockDB, IStockAdjustDB
    {
        private StockDB _stockDB = new StockDB();
        private InventoryExcDefUpdateDB _inventoryExcDefUpdateDB = new InventoryExcDefUpdateDB();
        private GoodsPriceUDB _goodsPriceUDB = new GoodsPriceUDB();
        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
        private InventInputSearchDB _inventInputSearchDB = null; // 棚卸リモート
        private TtlDayCalcDB _ttlDayCalcDB; // 締日算出リモート
        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<
        //ADD 2011/09/02 孫東響 #24259 ------------------->>>>>
        private SecInfoSetDB _secInfoDB = new SecInfoSetDB();
        private Hashtable secInfoSetWorkHash = new Hashtable();    
        private bool _isRecv = false;
        //ADD 2011/09/02 孫東響 #24259 -------------------<<<<<
        private string _secCode = string.Empty;//ADD 2011/09/16 sundx #25139
        private enum ct_ProcMode
        {
            /// <summary>調整</summary>
            Adjust = 0,
            /// <summary>一括登録</summary>
            BatchInpt = 1,
            /// <summary>棚卸</summary>
            Inventory = 2
        }

        private enum ct_WriteMode
        {
            /// <summary>追加更新</summary>
            Write = 0,
            /// <summary>削除</summary>
            Delete = 1
        }

        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
        /// <summary>
        /// 棚卸IInventInputSearchDBプロパティ
        /// </summary>
        private InventInputSearchDB inventInputSearchDB
        {
            get
            {
                if (this._inventInputSearchDB == null)
                {
                    // 棚卸リモート を生成
                    this._inventInputSearchDB = new InventInputSearchDB();
                }

                return this._inventInputSearchDB;
            }
        }

        /// <summary>
        /// 締日算出ITtlDayCalcDBプロパティ
        /// </summary>
        private TtlDayCalcDB ttlDayCalcDB
        {
            get
            {
                if (this._ttlDayCalcDB == null)
                {
                    // 締日算出リモート を生成
                    this._ttlDayCalcDB = new TtlDayCalcDB();
                }

                return this._ttlDayCalcDB;
            }
        }
        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<

        /// <summary>
        /// 在庫調整データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        /// </remarks>
        public StockAdjustDB()
            :
            base("MAZAI04366D", "Broadleaf.Application.Remoting.ParamData.StockAdjustWork", "STOCKADJUSTRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の在庫調整データ情報LISTを戻します
        /// </summary>
        /// <param name="stockAdjustWork">検索結果</param>
        /// <param name="parastockAdjustWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データ情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int Search(out object stockAdjustWork, object parastockAdjustWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockAdjustWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockAdjustProc(out stockAdjustWork, parastockAdjustWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Search");
                stockAdjustWork = new ArrayList();
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
        /// 指定された条件の在庫調整データ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objstockAdjustWork">検索結果</param>
        /// <param name="parastockAdjustWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int SearchStockAdjustProc(out object objstockAdjustWork, object parastockAdjustWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockAdjustWork stockadjustWork = null;

            ArrayList stockadjustWorkList = parastockAdjustWork as ArrayList;
            if (stockadjustWorkList == null)
            {
                stockadjustWork = parastockAdjustWork as StockAdjustWork;
            }
            else
            {
                if (stockadjustWorkList.Count > 0)
                    stockadjustWork = stockadjustWorkList[0] as StockAdjustWork;
            }

            int status = SearchStockAdjustProc(out stockadjustWorkList, stockadjustWork, readMode, logicalMode, ref sqlConnection);
            objstockAdjustWork = stockadjustWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の在庫調整データ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockadjustWorkList">検索結果</param>
        /// <param name="stockadjustWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int SearchStockAdjustProc(out ArrayList stockadjustWorkList, StockAdjustWork stockadjustWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockAdjustProcProc(out stockadjustWorkList, stockadjustWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の在庫調整データ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockadjustWorkList">検索結果</param>
        /// <param name="stockadjustWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int SearchStockAdjustProcProc(out ArrayList stockadjustWorkList, StockAdjustWork stockadjustWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM STOCKADJUSTRF  ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockadjustWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockAdjustWorkFromReader(ref myReader));

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

            stockadjustWorkList = al;

            return status;
        }

        /// <summary>
        /// 指定された条件の在庫調整データ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="bfstockadjustDtlWorkList">検索結果</param>
        /// <param name="stockadjustWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int SearchStockAdjustDtlProc(out ArrayList bfstockadjustDtlWorkList, StockAdjustWork stockadjustWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            bfstockadjustDtlWorkList = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty;

            ArrayList al = new ArrayList();
            try
            {
                sqlTxt += "SELECT * FROM STOCKADJUSTDTLRF" + Environment.NewLine;
                sqlTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += " AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO" + Environment.NewLine;


                if (sqlTransaction != null)
                {
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                }
                else
                {
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAdjustDtlWork work = CopyToStockAdjustDtlWorkFromReader(ref myReader);
                    bfstockadjustDtlWorkList.Add(work);
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の在庫調整データ情報LISTを戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="stockAdjustSlipNo">伝票番号</param>
        /// <param name="stockAdjustWork">在庫調整データ</param>
        /// <param name="stockAdjustDtlWork">在庫調整明細データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データ情報LISTを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.09.02</br>
        public int SearchSlipAndDtl(string enterpriseCode, int stockAdjustSlipNo, ref ArrayList stockAdjustWork , ref ArrayList stockAdjustDtlWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            StockAdjustWork parastockAdjustWork = new StockAdjustWork();
            parastockAdjustWork.EnterpriseCode = enterpriseCode;
            parastockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
            SqlTransaction sqlTransaction = null; //未使用

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //在庫調整データ
                status = SearchStockAdjustProcProc(out stockAdjustWork, parastockAdjustWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //在庫調整明細データ
                    status = SearchStockAdjustDtlProc(out stockAdjustDtlWork, parastockAdjustWork, ref sqlConnection, ref sqlTransaction);

                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Search");
                stockAdjustWork = new ArrayList();
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

            return status;
        }

        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の在庫調整データを戻します
        /// </summary>
        /// <param name="paraobj">StockAdjustWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int Read(ref object paraobj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                StockAdjustWork stockadjustWork = paraobj as StockAdjustWork;
                if (stockadjustWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockadjustWork, readMode, ref sqlConnection);

                paraobj = stockadjustWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Read");
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
        /// 指定された条件の在庫調整データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockadjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int ReadProc(ref StockAdjustWork stockadjustWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref stockadjustWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の在庫調整データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockadjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫調整データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int ReadProcProc(ref StockAdjustWork stockadjustWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO", sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                    findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        stockadjustWork = CopyToStockAdjustWorkFromReader(ref myReader);
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
        /// 在庫調整データ情報を登録、更新します。(在庫仕入入力用)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int Write(ref object stockAdjustWork, out string retMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            retMsg = string.Empty;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = this.Write(ref stockAdjustWork, out retMsg, ref sqlConnection,ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
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
        /// 在庫調整データ情報を登録、更新します。(在庫仕入入力用:UOE以外)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int Write(ref object stockAdjustWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref stockAdjustWork, out retMsg, ref sqlConnection, ref sqlTransaction, 0);
        }

        /// <summary>
        /// 在庫調整データ情報を登録、更新します。(在庫仕入入力用:UOE)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します (UOE分はシェアチェック回避)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteNoLock(ref object stockAdjustWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref stockAdjustWork, out retMsg, ref sqlConnection, ref sqlTransaction, 1);
        }

        /// <summary>
        /// 在庫調整データ情報を登録、更新します。(在庫仕入入力用)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="LockMode">シェアチェック判定(0:あり,1:なし)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        //public int Write(ref object stockAdjustWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int WriteProc(ref object stockAdjustWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int LockMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlEncryptInfo sqlEncryptInfo = null;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";
            

            ArrayList stockAdjustWorkList = null;       //在庫調整データリスト
            ArrayList stockAdjustDtlWorkList = null;    //在庫調整明細データリスト
            ArrayList bfstockAdjustDtlWorkList = null;  //在庫調整明細データリスト(前回値)
            ArrayList stockAcPayHistWorkList = null;    //在庫受払履歴リスト
            ArrayList goodsPriceUList = null;            //価格更新リスト
            ArrayList stockWorkList = new ArrayList();             //在庫リスト

            ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
            Dictionary<string, string> dic = new Dictionary<string, string>(); //倉庫リスト 

            bool uoeflg = false;

            string resNm = "";

            try
            {
                //パラメータのキャスト
                CustomSerializeArrayList paraList = stockAdjustWork as CustomSerializeArrayList;
                if (paraList == null) return status;

                //リストから必要な情報を取得
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫調整データの場合
                            if (wkal[0] is StockAdjustWork)
                            {
                                stockAdjustWorkList = wkal;
                            }
                            //在庫調整明細データの場合
                            else if (wkal[0] is StockAdjustDtlWork)
                            {
                                stockAdjustDtlWorkList = wkal;
                            }
                            //価格リストの場合
                            else if (wkal[0] is GoodsPriceUWork)
                            {
                                goodsPriceUList = wkal;
                            }
                        }
                    }
                }

                if (LockMode != 1)
                {
                    // システムロック(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                    if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
                    {
                        StockAdjustDtlWork _stockAdjustDtlWork = stockAdjustDtlWorkList[0] as StockAdjustDtlWork;
                        foreach (StockAdjustDtlWork st in stockAdjustDtlWorkList)
                        {
                            if (dic.ContainsKey(st.WarehouseCode.Trim()) == false)
                            {
                                dic.Add(st.WarehouseCode.Trim(), st.WarehouseCode.Trim());
                            }
                        }
                        foreach (string wCode in dic.Keys)
                        {
                            ShareCheckInfo info = new ShareCheckInfo();
                            info.Keys.Add(_stockAdjustDtlWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                            status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                            infoList.Add(info);
                            if (status != 0) return status;
                        }
                    }
                    // システムロック(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                //在庫仕入でＡＰロック
                resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);

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

                    return status;
                }

                //---在庫調整伝票番号採番---
                if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                {
                    status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                }
                else
                {
                    stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                    //前回値取得
                    status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);
                }

                //発注計上のチェック True:発注計上
                uoeflg = CheckSendAddUp(stockAdjustDtlWorkList);

                //発注データ更新
                if (uoeflg && stockAdjustDtlWorkList != null)
                {
                    StockSlipDB stockSlipDB = new StockSlipDB();
                    ArrayList parastockDetailList = CopyToParaStockDetailFromStockAdjustDtl(stockAdjustDtlWorkList, bfstockAdjustDtlWorkList, (int)ct_WriteMode.Write);

                    //仕入リモートの発注計上メソッドの呼び出し
                    status = stockSlipDB.UpdateOrderRemainCnt(new StockSlipWork(), parastockDetailList, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                }

                //write実行
                //在庫調整データ更新
                if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整データの更新に失敗しました。";
                }

                //在庫調整明細データ更新
                if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整明細データの更新に失敗しました。";
                }

                //在庫系データ作成処理 (在庫受払履歴データ作成)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = TransStockData(true, (int)ct_WriteMode.Write, bfstockAdjustDtlWorkList, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                }

                //在庫データ更新
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    string origin = "";
                    CustomSerializeArrayList originList = null;
                    CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                    tempparaList.Add(stockWorkList);
                    tempparaList.Add(stockAcPayHistWorkList);
                    int position = 0;
                    string param = "";
                    object freeParam = null;
                    int shelfNoUpdateDiv = 1;  //1:棚番更新しない（棚番更新は棚卸用）

                    status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                }

                //商品価格更新
                if (goodsPriceUList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = _goodsPriceUDB.UpDatePrice(ref goodsPriceUList, ref sqlConnection, ref sqlTransaction);
                }


                //戻り値セット
                stockAdjustWork = paraList;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
            }
            finally
            {
                //ＡＰアンロック
                Release(resNm, sqlConnection, sqlTransaction);

                if (LockMode != 1)
                {
                    // システムロック解除(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (status == 0 || status == 9)
                    {
                        foreach (ShareCheckInfo info in infoList)
                        {
                            status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        }
                    }
                    // システムロック解除(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }

            return status;
        }

        /// <summary>
        /// 在庫調整明細データより、発注計上のデータかを判断します。
        /// </summary>
        /// <param name="stockAdjustDtlList">stockAdjustDtlListオブジェクト</param>
        /// <returns>true:発注計上,false:発注計上以外</returns>
        /// <br>Note       : 発注計上データかのチェックを行います</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        private bool CheckSendAddUp(ArrayList stockAdjustDtlList)
        {
            foreach(StockAdjustDtlWork work in stockAdjustDtlList)
            {
                //仕入明細通番（元）が入ってるデータが１件でも存在した場合は発注計上あり
                if (work.StockSlipDtlNumSrc != 0) return true;
            }

            return false;
        }

        /// <summary>
        /// 在庫調整明細データから仕入明細データリストに仕入明細通番をセットします。
        /// </summary>
        /// <param name="stockAdjustDtlList">stockAdjustDtlListオブジェクト</param>
        /// <param name="bfstockAdjustDtlList">前回値明細リスト</param>
        /// <param name="writeMode">更新モード</param>
        /// <returns>true:発注計上,false:発注計上以外</returns>
        /// <br>Note       : 発注計上データかのチェックを行います</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        private ArrayList CopyToParaStockDetailFromStockAdjustDtl(ArrayList stockAdjustDtlList, ArrayList bfstockAdjustDtlList, int writeMode)
        {
            ArrayList al = new ArrayList();

            for (int i = 0; i < stockAdjustDtlList.Count; i++)
            {
                StockAdjustDtlWork work = stockAdjustDtlList[i] as StockAdjustDtlWork;

                Double adjustCount = work.AdjustCount;

                if (bfstockAdjustDtlList != null)
                {
                    StockAdjustDtlWork bfwork = bfstockAdjustDtlList[i] as StockAdjustDtlWork;

                    adjustCount -= bfwork.AdjustCount;
                }

                StockDetailWork stockDetailWork = new StockDetailWork();

                if (work.StockSlipDtlNumSrc != 0)
                {
                    //仕入データリモートの発注計上処理に合わせて仮想的に仕入データを作成する
                    stockDetailWork.EnterpriseCode = work.EnterpriseCode;
                    stockDetailWork.SupplierFormalSrc = work.SupplierFormalSrc;
                    stockDetailWork.StockSlipDtlNumSrc = work.StockSlipDtlNumSrc;
                    if (writeMode == (int)ct_WriteMode.Write)
                    {
                        stockDetailWork.StockCountDifference = adjustCount;
                    }
                    else
                    {
                        stockDetailWork.StockCountDifference = adjustCount * -1;
                    }
                }

                al.Add(stockDetailWork);
            }

            return al;
        }

        /// <summary>
        /// 在庫調整データ情報を登録、更新します(在庫一括登録、商品在庫マスメン用)
        /// </summary>
        /// <param name="stockAdjustCustList">stockAdjustCustListオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        /// <br>Update Note: 2008.9.12 長内 引数にstockModeを追加</br>
        public int WriteBatch(ref object stockAdjustCustList, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = "";

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = WriteBatch(ref stockAdjustCustList, out retMsg, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.WriteBatch(ref object stockAdjustCustList, out string retMsg, int stockMode)");
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
        /// 在庫調整データ情報を登録、更新します(在庫一括登録、商品在庫マスメン、在庫分解、組立用)
        /// </summary>
        /// <param name="stockAdjustCustList">stockAdjustCustListオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        /// <br>Update Note: 2008.9.12 長内 PM.NS用に修正</br>
        public int WriteBatch(ref object stockAdjustCustList, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            ArrayList stockAdjustWorkList = null;       //在庫調整データリスト
            ArrayList stockAdjustDtlWorkList = null;    //在庫調整明細データリスト
            ArrayList stockWorkList = null;             //在庫リスト
            ArrayList stockWriteList = null;            //更新用在庫リスト
            ArrayList stockDeleteList = null;           //削除用在庫リスト
            ArrayList stockAcPayHistWorkList = null;    //在庫受払履歴リスト

            string resNm = "";
            string enterpriseCode = ""; // 2009/08/03

            //パラメータのキャスト
            CustomSerializeArrayList stockAdjustCsList = stockAdjustCustList as CustomSerializeArrayList;
            if (stockAdjustCsList == null) return status;

            try
            {
                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    // -- ADD 2009/08/03 ------------------------------>>>
                    stockAdjustWorkList = null;       //在庫調整データリスト
                    stockAdjustDtlWorkList = null;    //在庫調整明細データリスト
                    stockWorkList = null;             //在庫リスト
                    stockWriteList = null;            //更新用在庫リスト
                    stockDeleteList = null;           //削除用在庫リスト
                    stockAcPayHistWorkList = null;    //在庫受払履歴リスト
                    // -- ADD 2009/08/03 ------------------------------<<<

                    //リストから必要な情報を取得
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        ArrayList wkal = paraList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //在庫調整データの場合
                                if (wkal[0] is StockAdjustWork)
                                {
                                    stockAdjustWorkList = wkal;
                                    enterpriseCode = (wkal[0] as StockAdjustWork).EnterpriseCode;  // 2009/08/03

                                }
                                //在庫調整明細データの場合
                                if (wkal[0] is StockAdjustDtlWork)
                                {
                                    stockAdjustDtlWorkList = wkal;
                                    enterpriseCode = (wkal[0] as StockAdjustDtlWork).EnterpriseCode;  // 2009/08/03
                                }
                                //在庫の場合
                                if (wkal[0] is StockWork)
                                {
                                    stockWorkList = wkal;
                                    enterpriseCode = (wkal[0] as StockWork).EnterpriseCode;  // 2009/08/03
                                }
                            }
                        }
                    }

                    // 2009/08/03 ------------>>>
                    //if (stockAdjustWorkList != null && resNm != "")
                    if (enterpriseCode != "" && resNm == "")
                    // 2009/08/03 ------------<<<
                    {

                        // 2009/08/03 ------------------------->>>
                        //StockAdjustWork stockadjustWork = stockAdjustWorkList[0] as StockAdjustWork;
                        //resNm = GetResourceName(stockadjustWork.EnterpriseCode);
                        resNm = GetResourceName(enterpriseCode);
                        // 2009/08/03 -------------------------<<<

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

                            return status;
                        }
                    }

                    //---在庫調整伝票番号採番---
                    if (stockAdjustWorkList != null)
                    {
                        StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                        if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                        {
                            status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                            wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                        }
                        else
                            stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                    }

                    //write実行
                    //在庫調整データ更新
                    if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整データの更新に失敗しました。";
                    }

                    //在庫調整明細データ更新
                    if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整明細データの更新に失敗しました。";
                    }

                    //在庫系データ作成処理
                    // 2009/08/03 ------------>>>
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockAdjustWorkList != null)
                    // 2009/08/03 ------------<<<
                    {
                        //受払リストを作成、在庫リストは作成しない
                        TransStockData(false,(int)ct_WriteMode.Write, null, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList,ref stockWorkList, (int)ct_ProcMode.BatchInpt, ref sqlConnection, ref sqlTransaction);
                    }

                    if (stockWorkList != null)
                    {
                        //更新用、削除用のリストを作成
                        CreateStockWriteDelList(stockWorkList, out stockWriteList, out stockDeleteList);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    //在庫データ更新
                    if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if ((stockWriteList != null) && (stockWriteList.Count != 0))
                        {
                            status = _stockDB.WriteStockBlanket(ref stockWriteList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction, out retMsg);
                        }
                        if ((stockDeleteList != null) && (stockDeleteList.Count != 0))
                        {
                            //更新用のリストが存在する場合はWriteStockBlanketにて受払履歴データが作成されている。
                            //二重作成防止のため、受払リストをクリアー
                            if ((stockWriteList != null) && (stockWriteList.Count != 0))
                            {
                                stockAcPayHistWorkList.Clear();
                            }

                            //削除対象の在庫が存在した場合は物理削除
                            status = _stockDB.DeleteStockBlanket(ref stockDeleteList, ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction, out retMsg);
                        }
                    }
                }
                
            }
            finally
            {
                //ＡＰアンロック
                // 2009/08/03 -------->>>
                //if (stockAdjustWorkList != null && resNm != "")
                if (resNm != "")
                // 2009/08/03 --------<<<
                {
                    Release(resNm, sqlConnection, sqlTransaction);
                }
            }

            return status;
        }

        /// <summary>
        /// 在庫調整データ情報のみを登録、更新します(ＵＯＥ用)
        /// </summary>
        /// <param name="stockAdjustCustList">stockAdjustCustListオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報のみを登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        /// <br>Update Note: 2008.9.12 長内 PM.NS用に修正</br>
        public int WriteStockAdjustSlipDtl(ref object stockAdjustCustList, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            ArrayList stockAdjustWorkList = null;       //在庫調整データリスト
            ArrayList stockAdjustDtlWorkList = null;    //在庫調整明細データリスト

            string resNm = "";

            //パラメータのキャスト
            CustomSerializeArrayList stockAdjustCsList = stockAdjustCustList as CustomSerializeArrayList;
            if (stockAdjustCsList == null) return status;

            try
            {
                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    //リストから必要な情報を取得
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        ArrayList wkal = paraList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //在庫調整データの場合
                                if (wkal[0] is StockAdjustWork)
                                {
                                    stockAdjustWorkList = wkal;
                                }
                                //在庫調整明細データの場合
                                if (wkal[0] is StockAdjustDtlWork)
                                {
                                    stockAdjustDtlWorkList = wkal;
                                }
                            }
                        }
                    }

                    if (stockAdjustWorkList != null && resNm != "")
                    {
                        StockAdjustWork stockadjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                        resNm = GetResourceName(stockadjustWork.EnterpriseCode);
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

                            return status;
                        }
                    }

                    //---在庫調整伝票番号採番---
                    if (stockAdjustWorkList != null)
                    {
                        StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                        if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                        {
                            status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                            wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                        }
                        else
                            stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                    }

                    //write実行
                    //在庫調整データ更新
                    if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整データの更新に失敗しました。";
                    }

                    //在庫調整明細データ更新
                    if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整明細データの更新に失敗しました。";
                    }

                }
            }
            finally
            {
                //ＡＰアンロック
                if (stockAdjustWorkList != null && resNm != "")
                {
                    Release(resNm, sqlConnection, sqlTransaction);
                }
            }

            return status;
        }


        /// <summary>   
        /// 在庫調整データ情報を登録、更新します。（過不足更新用）
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="shelfNoUpdateDiv">棚番更新区分 (0:する 1:しない)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        /// <br>Update Note: 2013/10/09 yangyi</br>
        /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
        /// <br>Update Note: K2015/08/21 陳嘯</br>
        /// <br>             Redmine#46790 棚卸過不足更新　メモリアウトの修正</br>

        //public int WriteInventory(ref object stockAdjustWork, out string retMsg, int shelfNoUpdateDiv) // DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
        public int WriteInventory(object stockAdjustWork, out string retMsg, int shelfNoUpdateDiv) // ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            string resNm = "";

            // ----- ADD 2013/10/09 ---------->>>>>
            // 在庫管理全体設定
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork(); ;
            // ----- ADD 2013/10/09 ----------<<<<<

            //コネクション生成
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // トランザクション開始
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            try
            {

                //パラメータのキャスト
                CustomSerializeArrayList stockAdjustCsList = stockAdjustWork as CustomSerializeArrayList;
                if (stockAdjustCsList == null) return status;

                // システムロック(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
                Dictionary<string, string> dic = new Dictionary<string, string>(); //倉庫リスト 

                StockAdjustDtlWork _stockAdjustDtlWork = null;

                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    ArrayList stockAdjustDtlWorkList = ListUtils.Find(paraList, typeof(StockAdjustDtlWork), ListUtils.FindType.Array) as ArrayList;

                    if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
                    {
                        foreach (StockAdjustDtlWork st in stockAdjustDtlWorkList)
                        {
                            _stockAdjustDtlWork = stockAdjustDtlWorkList[0] as StockAdjustDtlWork;
                            if (dic.ContainsKey(st.WarehouseCode.Trim()) == false)
                            {
                                dic.Add(st.WarehouseCode.Trim(), st.WarehouseCode.Trim());
                            }
                        }
                    }
                }
                foreach (string wCode in dic.Keys)
                {
                    ShareCheckInfo info = new ShareCheckInfo();
                    info.Keys.Add(_stockAdjustDtlWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    infoList.Add(info);
                    if (status != 0) return status;
                }
                // システムロック(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                ArrayList inventoryDataUpdateList = ListUtils.Find(stockAdjustCsList[0] as CustomSerializeArrayList, typeof(InventoryDataUpdateWork), ListUtils.FindType.Array) as ArrayList;

                if (inventoryDataUpdateList != null && inventoryDataUpdateList.Count > 0)
                {
                    InventoryDataUpdateWork inventoryDataUpdateWork = inventoryDataUpdateList[0] as InventoryDataUpdateWork;
                    resNm = GetResourceName(inventoryDataUpdateWork.EnterpriseCode);
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

                        return status;
                    }

                }

                // ----- ADD 2013/10/09 ---------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 在庫管理全体設定の「現在庫表示区分」により、受注数は算出条件追加の判断
                    if (inventoryDataUpdateList != null && inventoryDataUpdateList.Count > 0)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryDataUpdateList[0] as InventoryDataUpdateWork;
                        stockMngTtlStWork.EnterpriseCode = inventoryDataUpdateWork.EnterpriseCode;
                    }

                    stockMngTtlStWork.SectionCode = "00";
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(stockMngTtlStWork);
                    // 在庫管理全体設定読み込み
                    status = stockMngTtlStDB.Read(ref parabyte, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XMLの読み込み
                        stockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
                    }
                    else
                    {
                        stockMngTtlStWork = null;
                        retMsg = "プログラムエラー。在庫管理全体設定情報取得に失敗しました。";

                    }
                }
                // ----- ADD 2013/10/09 ----------<<<<<

                try
                {
                    foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        ArrayList stockAdjustWorkList = null;           //在庫調整データリスト
                        ArrayList stockAdjustDtlWorkList = null;        //在庫調整明細データリスト
                        ArrayList stockWorkList = null;                 //在庫リスト
                        //ArrayList trgStockWorkList = null;              //更新対象在庫リスト //2009/06/15
                        ArrayList stockAcPayHistWorkList = null;        //在庫受払履歴リスト
                        ArrayList inventoryDataUpdateWorkList = null;   //棚卸更新リスト


                        //リストから必要な情報を取得
                        for (int i = 0; i < paraList.Count; i++)
                        {
                            ArrayList wkal = paraList[i] as ArrayList;
                            if (wkal != null)
                            {
                                if (wkal.Count > 0)
                                {
                                    //在庫調整データの場合
                                    if (wkal[0] is StockAdjustWork)
                                    {
                                        stockAdjustWorkList = wkal;
                                    }
                                    //在庫調整明細データの場合
                                    if (wkal[0] is StockAdjustDtlWork)
                                    {
                                        stockAdjustDtlWorkList = wkal;
                                    }
                                    //在庫の場合
                                    if (wkal[0] is StockWork)
                                    {
                                        stockWorkList = wkal;
                                    }
                                    //棚卸更新の場合
                                    if (wkal[0] is InventoryDataUpdateWork)
                                    {
                                        inventoryDataUpdateWorkList = wkal;
                                    }

                                }
                            }
                        }

                        // 2009/06/15 >>>>>>>>>>>>>>>>>>>>>>>>
                        ////更新対象となる在庫ﾃﾞｰﾀの取得
                        //if (inventoryDataUpdateWorkList != null && inventoryDataUpdateWorkList.Count > 0)
                        //{
                        //    status = _inventoryExcDefUpdateDB.SearchStockFromInventoryProc(inventoryDataUpdateWorkList, out trgStockWorkList, ref sqlConnection, ref sqlTransaction);
                        //}
                        // 2009/06/15 <<<<<<<<<<<<<<<<<<<<<<<<

                        //---在庫調整伝票番号採番---
                        if (stockAdjustWorkList != null && stockAdjustWorkList.Count > 0)
                        {
                            StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;
                            if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                            {
                                status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                                wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                            }
                            else
                                stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                        }


                        //write実行
                        //在庫調整データ更新
                        if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整データの更新に失敗しました。";
                        }

                        //在庫調整明細データ更新
                        if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整明細データの更新に失敗しました。";
                        }

                        //在庫系データ作成処理
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockAdjustWorkList != null && stockAdjustDtlWorkList != null)
                        {
                            TransStockData(false, (int)ct_WriteMode.Write, null, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Inventory, ref sqlConnection, ref sqlTransaction);
                        }

                        // 2009/06/15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        ////最終棚卸更新日の更新用の更新対象在庫リストを追加
                        //if (stockWorkList == null) stockWorkList = trgStockWorkList;
                        //else
                        //    stockWorkList.AddRange(trgStockWorkList);
                        // 2009/06/15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        //在庫データ更新
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockWorkList != null && stockWorkList.Count > 0)
                        {
                            string origin = "";
                            CustomSerializeArrayList originList = null;
                            CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();

                            if (stockWorkList != null && stockWorkList.Count > 0)
                                tempparaList.Add(stockWorkList);
                            if (stockAcPayHistWorkList != null && stockAcPayHistWorkList.Count > 0)
                                tempparaList.Add(stockAcPayHistWorkList);
                            int position = 0;
                            string param = "";
                            object freeParam = null;
                            //status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);                  //DEL 2013/10/09
                            status = _stockDB.WriteFromInventory(origin, stockMngTtlStWork, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);  //ADD 2013/10/09

                        }

                        //棚卸データの更新
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && inventoryDataUpdateWorkList != null)
                        {
                            status = _inventoryExcDefUpdateDB.WriteLastInventoryUpdateProc(ref inventoryDataUpdateWorkList, ref sqlConnection, ref sqlTransaction);
                        }

                    }
                }
                finally
                {
                    //ＡＰアンロック
                    if (resNm != "")
                    {
                        Release(resNm, sqlConnection, sqlTransaction);
                    }

                    // システムロック解除(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (infoList != null && infoList.Count != 0)
                    {
                        foreach (ShareCheckInfo info in infoList)
                        {
                            status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        }
                    }
                    // システムロック解除(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                    
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //base.WriteErrorLog(ex, "StockAdjustDB.WriteInventory(ref object stockAdjustWork)"); // DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
                base.WriteErrorLog(ex, "StockAdjustDB.WriteInventory(object stockAdjustWork)"); // ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
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

        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
        /// <summary>
        /// 棚卸検索(過不足專用)
        /// </summary>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="inventInputUpdateCndtnWork">更新パラメータ</param>
        /// <param name="isSaved">isSaved</param>
        /// <param name="secInfoSetDic">拠点コードと名称</param>
        /// <param name="warehouseDic">倉庫コードと名称</param>
        /// <param name="makerUMntDic">メーカコードと名称</param>
        /// <param name="blGoodsCdUMntDic">BL商品コードと名称</param>
        /// <param name="message">message</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データ検索と過不足更新</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        public int SearchInventAndUpdate(object paraobj, object inventInputUpdateCndtnWork, out bool isSaved, object secInfoSetDic, object warehouseDic, object makerUMntDic, object blGoodsCdUMntDic, out string message)
        {
            Dictionary<string, List<GoodsPriceUWork>> dicPriceList;
            Dictionary<string, InventoryDataUpdateWork> inventoryDataDictionary;
            object retObj;
            object retObjDic;
            message = string.Empty;
            isSaved = false;
            InventInputUpdateCndtnWork inventUpdateWork = inventInputUpdateCndtnWork as InventInputUpdateCndtnWork;
            int fractionProcCd = inventUpdateWork.FractionProcCd;
            int inventoryMngDiv = inventUpdateWork.InventoryMngDiv;
            // 棚卸検索(過不足專用)
            int status = this.inventInputSearchDB.SearchInvent(out retObj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out retObjDic);

            dicPriceList = new Dictionary<string, List<GoodsPriceUWork>>();
            inventoryDataDictionary = new Dictionary<string, InventoryDataUpdateWork>();
            if (retObjDic != null)
            {
                dicPriceList = retObjDic as Dictionary<string, List<GoodsPriceUWork>>;
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (ArrayList retArray in (ArrayList)retObj)
                {
                    // 戻りリストの要素の型がInventoryDataUpdateWorkならばデータ展開
                    if ((retArray.Count > 0) && (retArray[0] is InventoryDataUpdateWork))
                    {
                        foreach (InventoryDataUpdateWork data in retArray)
                        {
                            // 過不足更新区分=0:未更新場合
                            // 商品マスタが未登録又は、論理削除の場合
                            if (data.ToleranceUpdateCd == 0 && data.GoodsDiv == 0 && !"ｶｼﾀﾞｼ".Equals(data.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(data.WarehouseShelfNo))
                            {
                                // データテーブルキャッシュ
                                Cache(data, ref inventoryDataDictionary);
                            }
                        }
                    }
                }
                status = this.Save(retObj, inventUpdateWork, out isSaved, out message, secInfoSetDic, warehouseDic, makerUMntDic, blGoodsCdUMntDic, dicPriceList, inventoryDataDictionary);
            }

            return status;
        }

        /// <summary>
        /// データテーブルキャッシュ処理
        /// </summary>
        /// <param name="inventoryDataUpdateWork">棚卸データ検索結果オブジェクト</param>
        /// <param name="inventoryDataDictionary">棚卸データ検索結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 棚卸データ検索結果オブジェクトをデータテーブルにキャッシュします。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private void Cache(InventoryDataUpdateWork inventoryDataUpdateWork, ref Dictionary<string, InventoryDataUpdateWork> inventoryDataDictionary)
        {
            inventoryDataDictionary.Add(CreatKey(inventoryDataUpdateWork), inventoryDataUpdateWork);
        }

        /// <summary>
        /// keyの設定
        /// </summary>
        /// <param name="work">work</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : keyの設定を行います。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private string CreatKey(InventoryDataUpdateWork work)
        {
            StringBuilder key = new StringBuilder();

            if (work != null)
            {
                // 拠点コード
                key.Append(work.SectionCode);
                // 棚卸通番
                key.Append(work.InventorySeqNo.ToString());
                // 倉庫コード
                key.Append(work.WarehouseCode);
            }

            return key.ToString();
        }

        /// <summary>
        /// 棚卸データを保存します。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データを保存します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/13</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>           : Redmine#46790 棚卸過不足更新　メモリアウトの修正</br>
        /// </remarks>
        private int Save(object retObj, InventInputUpdateCndtnWork inventInputUpdateCndtnWork, out bool isSaved, out string message, object secInfoSetDic, object warehouseDic, object makerUMntDic, object blGoodsCdUMntDic,
            Dictionary<string, List<GoodsPriceUWork>> dicPriceList, Dictionary<string, InventoryDataUpdateWork> inventoryDataDictionary)
        {
            isSaved = false;
            int status = -1;
            message = "";

            // 保存用データ生成処理
            CustomSerializeArrayList saveData = this.CreateSaveData(retObj, inventInputUpdateCndtnWork, secInfoSetDic, warehouseDic, makerUMntDic, blGoodsCdUMntDic, dicPriceList, inventoryDataDictionary);
            object objSaveData = (object)saveData;

            if (saveData.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                // 在庫調整データ情報を登録、更新します。
                status = this.WriteInventory(objSaveData, out message, inventInputUpdateCndtnWork.ShelfNoDiv);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    isSaved = true;
                }
            }
            return status;
        }

        #region 保存用データ生成処理
        /// <summary>
        /// 保存用データ生成処理
        /// </summary>
        /// <returns>保存用データ(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : 保存用データを作成します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData(object retObj, InventInputUpdateCndtnWork inventUpdatePara, object secInfoSetDic, object warehouseDic, object makerUMntDic, object blGoodsCdUMntDic,
            Dictionary<string, List<GoodsPriceUWork>> dicPriceList, Dictionary<string, InventoryDataUpdateWork> inventoryDataDictionary)
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList stockWorkList = new ArrayList();
            ArrayList inventoryDataList = new ArrayList();
            Dictionary<string, StockWork> stockDictionary = new Dictionary<string, StockWork>();
            Dictionary<string, List<ArrayList>> dataTableDic = new Dictionary<string, List<ArrayList>>();
            Dictionary<string, DateTime> totalDayDic = new Dictionary<string, DateTime>();

            // グリッドの明細が無い場合、処理を抜ける
            if (retObj == null)
            {
                return saveDataList;
            }

            foreach (ArrayList al in (CustomSerializeArrayList)retObj)
            {
                if ((al.Count > 0) && (al[0] is InventoryDataUpdateWork))
                {
                    foreach (InventoryDataUpdateWork wkInventoryDataUpdateWork in al)
                    {

                        string strKey = wkInventoryDataUpdateWork.EnterpriseCode + "," + wkInventoryDataUpdateWork.SectionCode + ","
                                             + wkInventoryDataUpdateWork.InventorySeqNo.ToString() + "," + wkInventoryDataUpdateWork.WarehouseCode;

                        ArrayList al1 = new ArrayList();
                        if (dataTableDic.ContainsKey(strKey))
                        {

                            al1.Add(wkInventoryDataUpdateWork);
                            dataTableDic[strKey].Add(al1);
                        }
                        else
                        {
                            List<ArrayList> list = new List<ArrayList>();
                            al1.Add(wkInventoryDataUpdateWork);
                            list.Add(al1);
                            dataTableDic.Add(strKey, list);

                        }
                    }
                }

            }

            foreach (InventoryDataUpdateWork workData in inventoryDataDictionary.Values)
            {
                CustomSerializeArrayList csArrayList = new CustomSerializeArrayList();


                // 棚卸データ作成
                inventoryDataList.Clear();
                // 棚卸運用区分＝ＰＭ．ＮＳ
                if (inventUpdatePara.InventoryMngDiv == 0)
                {
                    workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;          //棚卸過不足数(棚卸数－実施日帳簿数)
                    workData.InventoryTlrncPrice
                        = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl, inventUpdatePara.FractionProcCd);   //棚卸過不足金額(棚卸過不足数×仕入単価(浮動))
                    workData.LastInventoryUpdate = DateTime.Today;                                              //棚卸最終更新日
                    workData.StockTotalExec = workData.StockAmount;                                             //在庫総数(実施日)
                    workData.ToleranceUpdateCd = 1;                                                             //過不足更新区分　1:更新
                }
                // 棚卸運用区分＝ＰＭ７
                else
                {
                    workData.LastInventoryUpdate = DateTime.Today;                                              //棚卸最終更新日
                    workData.StockTotalExec = workData.StockTotal;                                              //在庫総数(実施日) = 在庫総数
                    workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockTotalExec;       //棚卸過不足数(棚卸数－在庫総数（実施日）)
                    workData.InventoryTlrncPrice
                        = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl, inventUpdatePara.FractionProcCd);   //棚卸過不足金額(棚卸過不足数×仕入単価(浮動))
                    workData.ToleranceUpdateCd = 1;                                                             //過不足更新区分　1:更新
                }

                inventoryDataList.Add(workData);
                csArrayList.Add(inventoryDataList.Clone());

                //不正データの対応
                string wareHouseCodeStr = workData.WarehouseCode;
                if (wareHouseCodeStr.Trim().Length < 4)
                {
                    wareHouseCodeStr = wareHouseCodeStr.Trim().PadLeft(4, '0').PadRight(6, ' ');
                }
                string strKey = workData.EnterpriseCode + "," + workData.SectionCode + "," + workData.InventorySeqNo.ToString() + "," + wareHouseCodeStr;

                List<ArrayList> rows = new List<ArrayList>();

                if (dataTableDic.ContainsKey(strKey))
                {
                    rows = dataTableDic[strKey];
                }
                if (rows.Count == 0)
                {
                    saveDataList.Add(csArrayList);      //棚卸データのみ
                    continue;
                }
                ArrayList row = (ArrayList)rows[0];

                if (row.Count > 0)
                {
                    InventoryDataUpdateWork inventoryDataUpdateWork = (InventoryDataUpdateWork)row[0];
                    // 初期化
                    stockAdjustWorkList.Clear();            //在庫調整
                    stockAdjustDtlWorkList.Clear();         //在庫調整明細
                    stockDictionary.Clear();                //在庫1
                    stockWorkList.Clear();                  //在庫2

                    // 過不足数チェック
                    if (inventoryDataUpdateWork.InventoryTolerancCnt != 0)
                    {
                        // 在庫調整明細データ作成
                        this.CreateStockAdjustDtl(inventoryDataUpdateWork, inventUpdatePara, ref stockAdjustDtlWorkList, secInfoSetDic, warehouseDic, makerUMntDic, blGoodsCdUMntDic, dicPriceList, ref totalDayDic);


                        // 在庫調整データ作成
                        StockAdjustWork stockAdjustWork = this.CreateStockAdjust(inventoryDataUpdateWork, inventUpdatePara, secInfoSetDic, ref totalDayDic);

                        // --[在庫調整データ]仕入金額小計を求める
                        long stockPriceTaxExec = 0;
                        foreach (StockAdjustDtlWork work in stockAdjustDtlWorkList)
                        {
                            stockPriceTaxExec += work.StockPriceTaxExc;
                        }
                        stockAdjustWork.StockSubttlPrice = stockPriceTaxExec;

                        stockAdjustWorkList.Add(stockAdjustWork);


                        // 作成したデータを追加
                        csArrayList.Add(stockAdjustWorkList.Clone());       //在庫調整
                        csArrayList.Add(stockAdjustDtlWorkList.Clone());    //在庫調整明細                        
                    }

                    // 在庫データ作成
                    // 棚卸運用区分＝ＰＭ．ＮＳ
                    if (inventUpdatePara.InventoryMngDiv == 0)
                    {
                        inventoryDataUpdateWork.InventoryTolerancCnt = inventoryDataUpdateWork.InventoryStockCnt - inventoryDataUpdateWork.StockAmount;     //仕入在庫数(棚卸過不足数：棚卸数－実施日帳簿数)
                    }
                    // 棚卸運用区分＝ＰＭ７
                    else
                    {
                        inventoryDataUpdateWork.InventoryTolerancCnt = inventoryDataUpdateWork.InventoryStockCnt - inventoryDataUpdateWork.StockTotal;     //仕入在庫数(棚卸過不足数：棚卸数－実施日帳簿数)
                    }
                    this.CreateStock(inventoryDataUpdateWork, ref stockDictionary, warehouseDic);

                    foreach (StockWork stockWork in stockDictionary.Values)
                    {
                        stockWorkList.Add(stockWork);
                    }

                    // 作成したデータを追加
                    csArrayList.Add(stockWorkList.Clone());             //在庫
                    
                }

                saveDataList.Add(csArrayList);
            }

            return saveDataList;
        }
        #endregion

        #region StockTotalPriceToLong(在庫金額算出)
        /// <summary>
        /// 金額算出(Long型で返す)
        /// </summary>
        /// <param name="unitCount">数量</param>
        /// <param name="unitCost">原価</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <returns>合計金額</returns>
        /// <remarks>
        /// <br>Note       : 金額を算出し、在庫管理全体設定の端数処理区分に従って端数処理を行います。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        public long GetTotalPriceToLong(double unitCount, double unitCost, int fractionProcCd)
        {
            long longStockTotalPrice = 0;
            double doubleStockTotalPrice = unitCost * unitCount;       // 原単価×数量

            // 在庫全体管理設定の端数処理区分に従う
            switch (fractionProcCd)
            {
                case 1:
                    {
                        // 切り捨て
                        longStockTotalPrice = (long)(doubleStockTotalPrice / 1);
                        break;
                    }
                case 2:
                    {
                        // 四捨五入
                        if (doubleStockTotalPrice >= 0)
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);
                        }
                        else
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice - 0.5) / 1);
                        }
                        break;
                    }
                case 3:
                    {
                        // 切り上げ
                        if (doubleStockTotalPrice % 1 == 0)
                        {
                            longStockTotalPrice = (long)(doubleStockTotalPrice);
                        }
                        else
                        {
                            if (doubleStockTotalPrice >= 0)
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);
                            }
                            else
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice - 1) / 1);
                            }
                        }
                        break;
                    }
                default:
                    {
                        longStockTotalPrice = (long)(doubleStockTotalPrice);
                        break;
                    }
            }

            return longStockTotalPrice;
        }
        #endregion

        /// <summary>
        /// 在庫調整明細データワーククラス生成処理
        /// </summary>
        /// <param name="data">棚卸更新データワーククラス</param>
        /// <param name="retList">在庫調整明細データリスト</param>
        /// <param name="inventUpdatePara">過不足更新パラメータ</param>
        /// <param name="secInfoSetDic">拠点コードと名称</param>
        /// <param name="warehouseDic">倉庫コードと名称</param>
        /// <param name="makerUMntDic">メーカコードと名称</param>
        /// <param name="blGoodsCdUMntDic">BL商品コードと名称</param>
        /// <param name="dicPriceList">dicPriceList</param>
        /// <param name="totalDayDic">totalDayDic</param>
        /// <returns>在庫調整明細データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データワーククラスを生成します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private void CreateStockAdjustDtl(InventoryDataUpdateWork data, InventInputUpdateCndtnWork inventUpdatePara, ref ArrayList retList, object secInfoSetDic, object warehouseDic,
            object makerUMntDic, object blGoodsCdUMntDic, Dictionary<string, List<GoodsPriceUWork>> dicPriceList, ref Dictionary<string, DateTime> totalDayDic)
        {
            StockAdjustDtlWork workData = new StockAdjustDtlWork();

            // 企業コード
            workData.EnterpriseCode = data.EnterpriseCode;
            // 拠点コード
            workData.SectionCode = inventUpdatePara.SectionCode;
            // 拠点名
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim(), secInfoSetDic);
            // 在庫調整伝票番号
            workData.StockAdjustSlipNo = 0;
            // 在庫調整行番号
            workData.StockAdjustRowNo = retList.Count + 1;
            // 受払元伝票区分(50:棚卸)
            workData.AcPaySlipCd = 50;
            // 受払元取引区分(40:過不足更新)
            workData.AcPayTransCd = 40;
            // 調整日付
            // 前回締処理日取得
            DateTime prevTotalDay = GetPrevTotalDay(data.SectionCode, inventUpdatePara.EnterpriseCode, ref totalDayDic);
            if (data.InventoryDate <= prevTotalDay)
            {
                // 棚卸実施日をセット
                workData.AdjustDate = prevTotalDay.AddDays(1);
            }
            else
            {
                // 棚卸日をセット
                workData.AdjustDate = data.InventoryDate;
            }
            // 入力日付
            workData.InputDay = DateTime.Now;
            // メーカーコード
            workData.GoodsMakerCd = data.GoodsMakerCd;
            // メーカー名称
            workData.MakerName = GetMakerName(data.GoodsMakerCd, makerUMntDic);
            // 商品コード
            workData.GoodsNo = data.GoodsNo;
            // 商品名称
            workData.GoodsName = data.GoodsName;
            // 仕入単価
            workData.StockUnitPriceFl = data.AdjstCalcCost;
            // 変更前仕入単価
            workData.BfStockUnitPriceFl = workData.StockUnitPriceFl;
            // 調整数
            workData.AdjustCount = data.InventoryTolerancCnt;
            // 明細備考
            workData.DtlNote = "";
            // 倉庫コード
            workData.WarehouseCode = data.WarehouseCode;
            // 倉庫名称
            workData.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim(), warehouseDic);
            // BLコード
            workData.BLGoodsCode = data.BLGoodsCode;
            // BLコード名称
            workData.BLGoodsFullName = GetBLGoodsName(data.BLGoodsCode, blGoodsCdUMntDic);
            // 倉庫棚番
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // 仕入金額
            //在庫管理全体設定の端数処理区分を使用するように修正
            long retMoney;
            FractionCalculate.FracCalcMoney(data.InventoryTolerancCnt * data.AdjstCalcCost, 1.00, inventUpdatePara.FractionProcCd, out retMoney);
            workData.StockPriceTaxExc = retMoney;

            // 定価
            if (data.InventoryDate <= prevTotalDay)
            {
                // 棚卸実施日をセット
                workData.ListPriceFl = GetListPriceFl2(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate, dicPriceList);
            }
            else
            {
                // 棚卸日をセット 
                workData.ListPriceFl = GetListPriceFl2(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate, dicPriceList);
            }

            retList.Add(workData);
        }

        /// <summary>
        /// 在庫調整データワーククラス生成処理
        /// </summary>
        /// <param name="data">棚卸更新データワーククラス</param>
        /// <param name="inventUpdatePara">過不足更新パラメータ</param>
        /// <param name="secInfoSetDic">拠点コードと名称</param>
        /// <param name="totalDayDic">totalDayDic</param>
        /// <returns>在庫調整データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データワーククラスを生成します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(InventoryDataUpdateWork data, InventInputUpdateCndtnWork inventUpdatePara, object secInfoSetDic, ref Dictionary<string, DateTime> totalDayDic)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // 企業コード
            workData.EnterpriseCode = data.EnterpriseCode;
            // 拠点コード
            workData.SectionCode = inventUpdatePara.SectionCode;
            // 拠点名
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim(), secInfoSetDic);
            // 受払元伝票区分(50：棚卸)
            workData.AcPaySlipCd = 50;
            // 受払元取引区分(40：過不足更新)
            workData.AcPayTransCd = 40;
            // 調整日付
            // 前回締処理日取得
            DateTime prevTotalDay = GetPrevTotalDay(data.SectionCode, inventUpdatePara.EnterpriseCode, ref totalDayDic);
            if (data.InventoryDate <= prevTotalDay)
            {
                // 棚卸実施日をセット
                workData.AdjustDate = prevTotalDay.AddDays(1);
            }
            else
            {
                // 棚卸日をセット
                workData.AdjustDate = data.InventoryDate;
            }
            // 入力日付
            workData.InputDay = DateTime.Now;
            // 仕入拠点コード
            workData.StockSectionCd = data.SectionCode;
            // 仕入拠点名称
            workData.StockSectionGuideNm = GetSectionName(data.SectionCode.Trim(), secInfoSetDic);
            // 仕入入力者コード
            workData.StockInputCode = inventUpdatePara.EmployeeCode;
            // 仕入入力者名称
            workData.StockInputName = inventUpdatePara.EmployeeName;
            // 仕入担当者コード
            workData.StockAgentCode = inventUpdatePara.EmployeeCode;
            // 仕入担当者名称
            workData.StockAgentName = inventUpdatePara.EmployeeName;

            return workData;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="_makerUMntDic">メーカコードと名称</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private string GetMakerName(int makerCode, object _makerUMntDic)
        {
            string makerName = "";
            Dictionary<int, string> makerUMntDic;
            makerUMntDic = _makerUMntDic as Dictionary<int, string>;

            if (makerUMntDic.ContainsKey(makerCode))
            {
                makerName = makerUMntDic[makerCode];
            }

            return makerName;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="_secInfoSetDic">拠点コードと名称</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        public string GetSectionName(string sectionCode, object _secInfoSetDic)
        {
            string sectionName = "";
            Dictionary<string, string> secInfoSetDic;
            secInfoSetDic = _secInfoSetDic as Dictionary<string, string>;

            if (secInfoSetDic.ContainsKey(sectionCode.PadLeft(2, '0')))
            {
                sectionName = secInfoSetDic[sectionCode.PadLeft(2, '0')];
            }

            return sectionName;
        }

        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="_warehouseDic">倉庫コードと名称</param>
        /// <returns>倉庫名称</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名称を取得します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        public string GetWarehouseName(string warehouseCode, object _warehouseDic)
        {
            string warehouseName = "";
            Dictionary<string, string> warehouseDic;
            warehouseDic = _warehouseDic as Dictionary<string, string>;

            if (warehouseDic.ContainsKey(warehouseCode))
            {
                warehouseName = warehouseDic[warehouseCode];
            }

            return warehouseName;
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="_blGoodsCdUMntDic">BLコードと名称</param>
        /// <returns>BKコード名称</returns>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode, object _blGoodsCdUMntDic)
        {
            string blGoodsName = "";
            Dictionary<int, string> blGoodsCdUMntDic;
            blGoodsCdUMntDic = _blGoodsCdUMntDic as Dictionary<int, string>;

            if (blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                blGoodsName = blGoodsCdUMntDic[blGoodsCode];
            }

            return blGoodsName;
        }

        /// <summary>
        /// 最終月次更新日取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="enterpriseCode">拠点コード</param>
        /// <param name="totalDayDic">totalDayDic</param>
        /// <returns>最終月次更新日</returns>
        /// <remarks>
        /// <br>Note       : 最終月次更新日を取得します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private DateTime GetPrevTotalDay(string sectionCode, string enterpriseCode, ref Dictionary<string, DateTime> totalDayDic)
        {

            DateTime prevTotalDay = new DateTime();

            int status = 0;
            if (totalDayDic.ContainsKey(sectionCode))
            {
                prevTotalDay = totalDayDic[sectionCode];
            }
            else
            {
                try
                {
                    status = GetHisTotalDayMonthly(enterpriseCode, sectionCode, out prevTotalDay);

                    if (prevTotalDay == DateTime.MinValue)
                    {
                        status = GetHisTotalDayMonthly(enterpriseCode, string.Empty, out prevTotalDay);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        prevTotalDay = new DateTime();
                    }
                    totalDayDic.Add(sectionCode, prevTotalDay);
                }
                catch
                {
                    prevTotalDay = new DateTime();
                }
            }
            return prevTotalDay;
        }

        /// <summary>
        /// 締日取得処理【履歴・月次売掛＆買掛】
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 最終月次更新日を取得します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private int GetHisTotalDayMonthly(string enterpriseCode, string sectionCode, out DateTime prevTotalDay)
        {
            int status = -1;
            // 初期化
            prevTotalDay = DateTime.MinValue;

            DateTime[] retPrevTotalDay = new DateTime[2];

            // 売掛
            status = GetHisTotalDayMonthlyAccRecPayProc(enterpriseCode, sectionCode, out retPrevTotalDay[0], 0);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // 買掛
            status = GetHisTotalDayMonthlyAccRecPayProc(enterpriseCode, sectionCode, out retPrevTotalDay[1], 1);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            //--------------------------------------
            // 売掛処理日と買掛処理日を比較（小さい方を採用）
            //--------------------------------------
            if (retPrevTotalDay[0] >= retPrevTotalDay[1])
            {
                // 売掛≧買掛　→　買掛を返す
                prevTotalDay = retPrevTotalDay[1];

            }
            else
            {
                // 売掛＜買掛　→　売掛を返す
                prevTotalDay = retPrevTotalDay[0];
            }
            return status;
        }

        /// <summary>
        /// 締日取得処理（履歴・月次買掛）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode"></param>
        /// <param name="prevTotalDay"></param>
        /// <param name="procDiv"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 最終月次更新日を取得します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private int GetHisTotalDayMonthlyAccRecPayProc(string enterpriseCode, string sectionCode, out DateTime prevTotalDay, int procDiv)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            TtlDayCalcRetWork retWork;

            # region [随時リモート抽出]
            // 検索パラメータ生成
            TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
            paraWork.EnterpriseCode = enterpriseCode;
            paraWork.SectionCode = sectionCode;
            paraWork.WithMasterDiv = 1;
            paraWork.ProcDiv = procDiv;

            // リモート呼び出し
            object retObj;
            status = ttlDayCalcDB.SearchHisMonthly(out retObj, paraWork);
            # endregion

            CustomSerializeArrayList customSerializeArrayList = (retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList;
            // 全拠点の前回締処理日
            DateTime allSectionPrevDate = DateTime.MinValue;
            for (int index = 0; index < customSerializeArrayList.Count; index++)
            {
                retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);
                prevTotalDay = GetDateTime(retWork.TotalDay);
                // 全社結果(全拠点で一番大きい値を使用)
                if (allSectionPrevDate < prevTotalDay)
                {
                    allSectionPrevDate = prevTotalDay;
                }
            }
            prevTotalDay = allSectionPrevDate;
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }


        /// <summary>
        /// DateTime取得処理(yyyymmdd → yyyy/mm/dd)
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private static DateTime GetDateTime(int longDate)
        {
            if (longDate == 0)
            {
                return DateTime.MinValue;
            }
            else
            {
                try
                {
                    return new DateTime(longDate / 10000, (longDate / 100) % 100, longDate % 100);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        private double GetListPriceFl2(int makerCode, string goodsNo, DateTime targetDate, Dictionary<string, List<GoodsPriceUWork>> dicPriceList)
        {
            double listPriceFl = 0;

            string keyStr = goodsNo + "," + makerCode.ToString();
            List<GoodsPriceUWork> goodsPriceUWorkList = new List<GoodsPriceUWork>();

            if (dicPriceList.ContainsKey(keyStr))
            {
                foreach (GoodsPriceUWork work in dicPriceList[keyStr])
                {
                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
                    goodsPriceUWork.ListPrice = work.ListPrice;
                    goodsPriceUWork.PriceStartDate = work.PriceStartDate;
                    goodsPriceUWorkList.Add(goodsPriceUWork);
                }
                GoodsPriceUWork retGoodsPriceUWork = this.GetGoodsPriceFromGoodsPriceUWorkList(targetDate, goodsPriceUWorkList);

                if (retGoodsPriceUWork != null)
                {
                    listPriceFl = retGoodsPriceUWork.ListPrice;
                }
            }
            else
            {
                listPriceFl = 0;
            }

            return listPriceFl;
        }

        /// <summary>
        /// 指定日条件該当価格情報データオブジェクト取得処理
        /// </summary>
        /// <param name="targetDateTime"></param>
        /// <param name="goodsPriceUWorkList"></param>
        /// <returns></returns>
        private GoodsPriceUWork GetGoodsPriceFromGoodsPriceUWorkList(DateTime targetDateTime, List<GoodsPriceUWork> goodsPriceUWorkList)
        {
            // --- DEL 陳嘯 K2015/09/09 Redmine#46790 在庫調整明細データの定価セット不正の対応 ----->>>>>
            //if ((goodsPriceUWorkList != null) && (goodsPriceUWorkList.Count != 0))
            //{
            //    foreach (GoodsPriceUWork goodsPriceUWork in goodsPriceUWorkList)
            //    {
            //        if (goodsPriceUWork.PriceStartDate != DateTime.MinValue)
            //        {
            //            if (goodsPriceUWork.PriceStartDate <= targetDateTime)
            //            {
            //                return goodsPriceUWork;
            //            }
            //        }
            //    }
            //}
            // --- DEL 陳嘯 K2015/09/09 Redmine#46790 在庫調整明細データの定価セット不正の対応 -----<<<<<
            // --- ADD 陳嘯 K2015/09/09 Redmine#46790 在庫調整明細データの定価セット不正の対応 ----->>>>>
            DateTime priceStartDateFirst = DateTime.MinValue;
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
            if ((goodsPriceUWorkList != null) && (goodsPriceUWorkList.Count != 0))
            {
                for (int i = 0; i < goodsPriceUWorkList.Count; i++)
                {
                    if (goodsPriceUWorkList[i].PriceStartDate > priceStartDateFirst && goodsPriceUWorkList[i].PriceStartDate <= targetDateTime)
                    {
                        priceStartDateFirst = goodsPriceUWorkList[i].PriceStartDate;
                        goodsPriceUWork = goodsPriceUWorkList[i];
                    }
                }
                return goodsPriceUWork;
            }
            // --- ADD 陳嘯 K2015/09/09 Redmine#46790 在庫調整明細データの定価セット不正の対応 -----<<<<<
            return null;
        }

        /// <summary>
        /// 在庫マスタクラス生成処理
        /// </summary>
        /// <param name="data">棚卸更新データワーククラス</param>
        /// <param name="stockDictionary">在庫マスタDictionary</param>
        /// <param name="warehouseDic">倉庫コードと名称</param>
        /// <remarks>
        /// <br>Note       : 在庫マスタクラスを生成します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private void CreateStock(InventoryDataUpdateWork data, ref Dictionary<string, StockWork> stockDictionary, object warehouseDic)
        {
            string stockKey = CreateStockKey(data);

            bool isNew = false;
            StockWork workData = null;
            if (stockDictionary.ContainsKey(stockKey))
            {
                workData = stockDictionary[stockKey];
            }
            else
            {
                workData = new StockWork();
                isNew = true;
            }

            // 企業コード
            workData.EnterpriseCode = data.EnterpriseCode;
            // 論理削除区分
            workData.LogicalDeleteCode = 0;
            // 拠点コード
            workData.SectionCode = data.SectionCode;
            // メーカーコード
            workData.GoodsMakerCd = data.GoodsMakerCd;
            // 品番
            workData.GoodsNo = data.GoodsNo;
            // 仕入単価
            workData.StockUnitPriceFl = data.StockUnitPriceFl;
            // 仕入在庫数
            workData.SupplierStock = data.InventoryTolerancCnt;
            // 出荷可能数
            workData.ShipmentPosCnt = workData.SupplierStock;

            if (data.InventoryTolerancCnt < 0)
            {
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                // 出庫保有総額
                workData.StockTotalPrice = workData.StockTotalPrice - longint;
            }
            else if (data.InventoryTolerancCnt > 0)
            {
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                // 出庫保有総額
                workData.StockTotalPrice = workData.StockTotalPrice + longint;
            }
            if (data.InventoryNewDiv == 1)
            {
                if (workData.LastStockDate < data.LastStockDate)
                {
                    // 最終仕入年月日
                    workData.LastStockDate = data.LastStockDate;
                }
            }
            else
            {
                if (workData.LastStockDate < data.LastStockDate)
                {
                    // 最終仕入年月日
                    workData.LastStockDate = data.LastStockDate;
                }
            }
            // 最終棚卸更新日
            workData.LastInventoryUpdate = data.InventoryDay;
            // 倉庫コード
            workData.WarehouseCode = data.WarehouseCode.TrimEnd();
            // 倉庫名
            workData.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim(), warehouseDic);
            // ハイフン無商品番号
            workData.GoodsNoNoneHyphen = "";
            // 倉庫棚番
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // 重複棚番1
            workData.DuplicationShelfNo1 = data.DuplicationShelfNo1;
            // 重複棚番2
            workData.DuplicationShelfNo2 = data.DuplicationShelfNo2;
            // 在庫登録日
            workData.StockCreateDate = DateTime.Today;
            // 更新年月日
            workData.UpdateDate = DateTime.Today;
            if (isNew)
            {
                stockDictionary.Add(stockKey, workData);
            }
        }

        /// <summary>
        /// 在庫情報キー文字列生成処理
        /// </summary>
        /// <param name="data">棚卸更新データワーククラス</param>
        /// <returns>在庫情報キー文字列</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報キー文字列を生成します。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private string CreateStockKey(InventoryDataUpdateWork data)
        {
            return data.SectionCode.Trim() + data.GoodsMakerCd + "-" + data.GoodsNo.Trim();
        }
        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<

        /// <summary>
        /// 在庫調整データ情報を登録、更新します。(委託補充用)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="warehouseList">シェアチェック用倉庫リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteEntrust(ref object stockAdjustWork, out string retMsg, ref object warehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            retMsg = string.Empty;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = this.WriteEntrust(ref stockAdjustWork, ref warehouseList, out retMsg, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
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
        /// 在庫調整データ情報を登録、更新します。(委託補充用)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="warehouseList">シェアチェック用倉庫リスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteEntrust(ref object stockAdjustWork, ref object warehouseList, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlEncryptInfo sqlEncryptInfo = null;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            ArrayList stockAdjustWorkList = null;       //在庫調整データリスト
            ArrayList stockAdjustDtlWorkList = null;    //在庫調整明細データリスト
            ArrayList bfstockAdjustDtlWorkList = null;  //在庫調整明細データリスト(前回値)
            ArrayList stockAcPayHistWorkList = null;    //在庫受払履歴リスト

            string resNm = "";

            if (stockAdjustWork == null) return status;

            CustomSerializeArrayList stockAdjustCsList = stockAdjustWork as CustomSerializeArrayList;
            //ArrayList wList = ListUtils.Find(stockAdjustCsList, typeof(string), ListUtils.FindType.Array) as ArrayList;
            CustomSerializeArrayList wList = warehouseList as CustomSerializeArrayList;
            if (wList == null) wList = new CustomSerializeArrayList();

            ArrayList infoList = new ArrayList();

            // システムロック(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            CustomSerializeArrayList letList = stockAdjustWork as CustomSerializeArrayList;
            ArrayList paramList1 = new ArrayList();
            paramList1 = letList[0] as ArrayList;
            ArrayList rockList1 = ListUtils.Find(paramList1, typeof(StockAdjustDtlWork), ListUtils.FindType.Array) as ArrayList;
            StockAdjustDtlWork _stockMoveWork1 = rockList1[0] as StockAdjustDtlWork;

            foreach (string whouse in wList)
            {
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(_stockMoveWork1.EnterpriseCode, ShareCheckType.WareHouse, "", whouse);
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                if (status != 0) return status;
                infoList.Add(info);
            }
            // システムロック(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                foreach (CustomSerializeArrayList paraList in stockAdjustCsList)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    ArrayList stockWorkList = new ArrayList();             //在庫リスト

                    //リストから必要な情報を取得
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        ArrayList wkal = paraList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //在庫調整データの場合
                                if (wkal[0] is StockAdjustWork)
                                {
                                    stockAdjustWorkList = wkal;
                                }
                                //在庫調整明細データの場合
                                else if (wkal[0] is StockAdjustDtlWork)
                                {
                                    stockAdjustDtlWorkList = wkal;
                                }
                            }
                        }
                        else
                        {
                            wkal = new ArrayList();
                        }
                    }

                    StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                    if (resNm == "")
                    {
                        //在庫仕入でＡＰロック
                        resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);

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

                            return status;
                        }
                    }

                    //---在庫調整伝票番号採番---
                    if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                    {
                        status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                        wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                    }
                    else
                    {
                        stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                        //前回値取得
                        status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);
                    }

                    //write実行
                    //在庫調整データ更新
                    if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteStockAdjustProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整データの更新に失敗しました。";
                    }

                    //在庫調整明細データ更新
                    if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteDelInsStockAdjustDtlProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整明細データの更新に失敗しました。";
                    }

                    //在庫系データ作成処理 (在庫受払履歴データ作成)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        TransStockData(true, (int)ct_WriteMode.Write, bfstockAdjustDtlWorkList, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                    }

                    //在庫データ更新
                    if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                        tempparaList.Add(stockWorkList);
                        tempparaList.Add(stockAcPayHistWorkList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        int shelfNoUpdateDiv = 1;  //1:棚番更新しない（棚番更新は棚卸用）

                        status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.WriteEntrust(ref object stockAdjustWork)");
            }
            finally
            {
                //ＡＰアンロック
                if (resNm != "")
                {
                    Release(resNm, sqlConnection, sqlTransaction);
                }

                // システムロック(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (status == 0 || status == 4)
                {
                    foreach (ShareCheckInfo info2 in infoList)
                    {
                        status = this.ShareCheck(info2, LockControl.Release, sqlConnection, sqlTransaction);
                    }
                }
                // システムロック(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            return status;
        }
        
        /// <summary>
        /// 在庫調整データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustWorkList">StockAdjustWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteStockAdjustProc(ref ArrayList stockAdjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteStockAdjustProcProc(ref stockAdjustWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫調整データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustWorkList">StockAdjustWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int WriteStockAdjustProcProc(ref ArrayList stockAdjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockAdjustWorkList != null)
                {
                    for (int i = 0; i < stockAdjustWorkList.Count; i++)
                    {
                        StockAdjustWork stockadjustWork = stockAdjustWorkList[i] as StockAdjustWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockadjustWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (stockadjustWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE STOCKADJUSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , STOCKADJUSTSLIPNORF=@STOCKADJUSTSLIPNO , ACPAYSLIPCDRF=@ACPAYSLIPCD , ACPAYTRANSCDRF=@ACPAYTRANSCD , ADJUSTDATERF=@ADJUSTDATE , INPUTDAYRF=@INPUTDAY , STOCKSECTIONCDRF=@STOCKSECTIONCD , STOCKINPUTCODERF=@STOCKINPUTCODE , STOCKINPUTNAMERF=@STOCKINPUTNAME , STOCKAGENTCODERF=@STOCKAGENTCODE , STOCKAGENTNAMERF=@STOCKAGENTNAME , STOCKSUBTTLPRICERF=@STOCKSUBTTLPRICE , SLIPNOTERF=@SLIPNOTE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockadjustWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO STOCKADJUSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @STOCKSECTIONCD, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @STOCKSUBTTLPRICE, @SLIPNOTE)";
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
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
                        SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                        SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                        SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                        SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                        SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                        SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                        SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                        SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                        SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);
                        SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockadjustWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.SectionCode);
                        paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);
                        paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.AcPaySlipCd);
                        paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.AcPayTransCd);
                        paraAdjustDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustWork.AdjustDate);
                        paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustWork.InputDay);
                        paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockSectionCd);
                        paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockInputCode);
                        // 修正 2009/07/30 >>>
                        if (stockadjustWork.StockInputName.Length > 16)
                        {
                            // 16桁で切り捨て
                            stockadjustWork.StockInputName = stockadjustWork.StockInputName.Substring(0, 16);
                        }
                        // 修正 2009/07/30 <<<
                        paraStockInputName.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockInputName);
                        paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockAgentCode);
                        // 修正 2009/07/30 >>>
                        if (stockadjustWork.StockAgentName.Length > 16)
                        {
                            // 16桁で切り捨て
                            stockadjustWork.StockAgentName = stockadjustWork.StockAgentName.Substring(0, 16);
                        }
                        // 修正 2009/07/30 <<<
                        paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockadjustWork.StockAgentName);
                        paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockadjustWork.StockSubttlPrice);
                        paraSlipNote.Value = SqlDataMediator.SqlSetString(stockadjustWork.SlipNote);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockadjustWork);
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

            stockAdjustWorkList = al;

            return status;
        }

        /// <summary>
        /// 在庫調整明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteStockAdjustDtlProc(int stockAdjustSlipNo, ref ArrayList stockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteStockAdjustDtlProcProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫調整明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int WriteStockAdjustDtlProcProc(int stockAdjustSlipNo, ref ArrayList stockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockAdjustDtlWorkList != null)
                {
                    for (int i = 0; i < stockAdjustDtlWorkList.Count; i++)
                    {
                        StockAdjustDtlWork stockadjustdtlWork = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        //在庫調整伝票番号が 0 の場合
                        if (stockadjustdtlWork.StockAdjustSlipNo == 0)
                            stockadjustdtlWork.StockAdjustSlipNo = stockAdjustSlipNo;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                        findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockadjustdtlWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (stockadjustdtlWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE STOCKADJUSTDTLRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , STOCKADJUSTSLIPNORF=@STOCKADJUSTSLIPNO , STOCKADJUSTROWNORF=@STOCKADJUSTROWNO , SUPPLIERFORMALSRCRF=@SUPPLIERFORMALSRC , STOCKSLIPDTLNUMSRCRF=@STOCKSLIPDTLNUMSRC , ACPAYSLIPCDRF=@ACPAYSLIPCD , ACPAYTRANSCDRF=@ACPAYTRANSCD , ADJUSTDATERF=@ADJUSTDATE , INPUTDAYRF=@INPUTDAY , GOODSMAKERCDRF=@GOODSMAKERCD , MAKERNAMERF=@MAKERNAME , GOODSNORF=@GOODSNO , GOODSNAMERF=@GOODSNAME , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL , BFSTOCKUNITPRICEFLRF=@BFSTOCKUNITPRICEFL , ADJUSTCOUNTRF=@ADJUSTCOUNT , DTLNOTERF=@DTLNOTE , WAREHOUSECODERF=@WAREHOUSECODE , WAREHOUSENAMERF=@WAREHOUSENAME , BLGOODSCODERF=@BLGOODSCODE , BLGOODSFULLNAMERF=@BLGOODSFULLNAME , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO , LISTPRICEFLRF=@LISTPRICEFL , OPENPRICEDIVRF=@OPENPRICEDIV , STOCKPRICETAXEXCRF=@STOCKPRICETAXEXC WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                            findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustdtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockadjustdtlWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO STOCKADJUSTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @STOCKADJUSTROWNO, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @ADJUSTCOUNT, @DTLNOTE, @WAREHOUSECODE, @WAREHOUSENAME, @BLGOODSCODE, @BLGOODSFULLNAME, @WAREHOUSESHELFNO, @LISTPRICEFL, @OPENPRICEDIV, @STOCKPRICETAXEXC)";
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustdtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
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
                        SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                        SqlParameter paraStockAdjustRowNo = sqlCommand.Parameters.Add("@STOCKADJUSTROWNO", SqlDbType.Int);
                        SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                        SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                        SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                        SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                        SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                        SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                        SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                        SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                        SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockadjustdtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.SectionCode);
                        paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                        paraStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);
                        paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.SupplierFormalSrc);
                        paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockadjustdtlWork.StockSlipDtlNumSrc);
                        paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.AcPaySlipCd);
                        paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.AcPayTransCd);
                        paraAdjustDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustdtlWork.AdjustDate);
                        paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustdtlWork.InputDay);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.GoodsName);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.StockUnitPriceFl);
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.BfStockUnitPriceFl);
                        paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.AdjustCount);
                        paraDtlNote.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.DtlNote);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseName);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.BLGoodsFullName);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseShelfNo);
                        paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.ListPriceFl);
                        paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.OpenPriceDiv);
                        paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockadjustdtlWork.StockPriceTaxExc);
                        #endregion  // Parameterオブジェクトへ値設定(更新用)

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockadjustdtlWork);
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

            stockAdjustDtlWorkList = al;

            return status;
        }

        /// <summary>
        /// 在庫調整明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int WriteDelInsStockAdjustDtlProc(int stockAdjustSlipNo, ref ArrayList stockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteDelInsStockAdjustDtlProcProc(stockAdjustSlipNo, ref stockAdjustDtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫調整明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustSlipNo">在庫調整伝票番号</param>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整明細データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int WriteDelInsStockAdjustDtlProcProc(int stockAdjustSlipNo, ref ArrayList stockAdjustDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockAdjustDtlWorkList != null)
                {
                    if (stockAdjustDtlWorkList.Count > 0)
                    {
                        StockAdjustDtlWork stockadjustdtlWork = stockAdjustDtlWorkList[0] as StockAdjustDtlWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO ", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustSlipNo);

                        sqlCommand.ExecuteNonQuery();

                        for (int i = 0; i < stockAdjustDtlWorkList.Count; i++)
                        {
                            stockadjustdtlWork = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                            //在庫調整伝票番号が 0 の場合
                            if (stockadjustdtlWork.StockAdjustSlipNo == 0)
                                stockadjustdtlWork.StockAdjustSlipNo = stockAdjustSlipNo;

                            //新規作成時のSQL文を生成
                            sqlCommand = new SqlCommand("INSERT INTO STOCKADJUSTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, STOCKADJUSTROWNORF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, ADJUSTCOUNTRF, DTLNOTERF, WAREHOUSECODERF, WAREHOUSENAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, WAREHOUSESHELFNORF, LISTPRICEFLRF, OPENPRICEDIVRF, STOCKPRICETAXEXCRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @STOCKADJUSTROWNO, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @ADJUSTCOUNT, @DTLNOTE, @WAREHOUSECODE, @WAREHOUSENAME, @BLGOODSCODE, @BLGOODSFULLNAME, @WAREHOUSESHELFNO, @LISTPRICEFL, @OPENPRICEDIV, @STOCKPRICETAXEXC)", sqlConnection, sqlTransaction);
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustdtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

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
                            SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                            SqlParameter paraStockAdjustRowNo = sqlCommand.Parameters.Add("@STOCKADJUSTROWNO", SqlDbType.Int);
                            SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                            SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                            SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                            SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                            SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                            SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                            SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                            SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                            SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                            SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                            SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                            SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                            SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                            SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                            SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                            SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                            SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                            #endregion  // Parameterオブジェクトの作成(更新用)

                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockadjustdtlWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.LogicalDeleteCode);
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.SectionCode);
                            paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                            paraStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);
                            paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.SupplierFormalSrc);
                            paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockadjustdtlWork.StockSlipDtlNumSrc);
                            paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.AcPaySlipCd);
                            paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.AcPayTransCd);
                            paraAdjustDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustdtlWork.AdjustDate);
                            paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockadjustdtlWork.InputDay);
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.GoodsMakerCd);
                            paraMakerName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.MakerName);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.GoodsNo);
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.GoodsName);
                            paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.StockUnitPriceFl);
                            paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.BfStockUnitPriceFl);
                            paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.AdjustCount);
                            paraDtlNote.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.DtlNote);
                            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseCode);
                            paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseName);
                            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.BLGoodsCode);
                            paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.BLGoodsFullName);
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.WarehouseShelfNo);
                            paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockadjustdtlWork.ListPriceFl);
                            paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.OpenPriceDiv);
                            paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockadjustdtlWork.StockPriceTaxExc);
                            #endregion // Parameterオブジェクトへ値設定(更新用)

                            sqlCommand.ExecuteNonQuery();
                            al.Add(stockadjustdtlWork);
                        }
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAdjustDtlWorkList = al;

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 在庫調整データ情報を論理削除します
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int LogicalDelete(ref object stockAdjustWork)
        {
            return LogicalDeleteStockAdjust(ref stockAdjustWork, 0);
        }

        /// <summary>
        /// 論理削除在庫調整データ情報を復活します
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除在庫調整データ情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int RevivalLogicalDelete(ref object stockAdjustWork)
        {
            return LogicalDeleteStockAdjust(ref stockAdjustWork, 1);
        }

        /// <summary>
        /// 在庫調整データ情報の論理削除を操作します
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報の論理削除を操作します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int LogicalDeleteStockAdjust(ref object stockAdjustWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(stockAdjustWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteStockAdjustProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
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
                base.WriteErrorLog(ex, "StockAdjustDB.LogicalDeleteStockAdjust :" + procModestr);

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
        /// 在庫調整データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustWorkList">StockAdjustWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int LogicalDeleteStockAdjustProc(ref ArrayList stockAdjustWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockAdjustProcProc(ref stockAdjustWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫調整データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustWorkList">StockAdjustWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int LogicalDeleteStockAdjustProcProc(ref ArrayList stockAdjustWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockAdjustWorkList != null)
                {
                    for (int i = 0; i < stockAdjustWorkList.Count; i++)
                    {
                        StockAdjustWork stockadjustWork = stockAdjustWorkList[i] as StockAdjustWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockadjustWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE STOCKADJUSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustWork;
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
                            else if (logicalDelCd == 0) stockadjustWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else stockadjustWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockadjustWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockadjustWork);
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

            stockAdjustWorkList = al;

            return status;

        }

        /// <summary>
        /// 在庫調整明細データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整明細データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int LogicalDeleteStockAdjustDtlProc(ref ArrayList stockAdjustDtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockAdjustDtlProcProc(ref stockAdjustDtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫調整明細データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">StockAdjustDtlWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整明細データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int LogicalDeleteStockAdjustDtlProcProc(ref ArrayList stockAdjustDtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockAdjustDtlWorkList != null)
                {
                    for (int i = 0; i < stockAdjustDtlWorkList.Count; i++)
                    {
                        StockAdjustDtlWork stockadjustdtlWork = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                        findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockadjustdtlWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE STOCKADJUSTDTLRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                            findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockadjustdtlWork;
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
                            else if (logicalDelCd == 0) stockadjustdtlWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else stockadjustdtlWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockadjustdtlWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockadjustdtlWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockadjustdtlWork);
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

            stockAdjustDtlWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 在庫調整データ情報を登録、更新します。(在庫調整入力用)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫調整データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int Delete(ref object stockAdjustWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            retMsg = "";
            string retItemInfo = "";


            ArrayList stockAdjustWorkList = null;       //在庫調整データリスト
            ArrayList stockAdjustDtlWorkList = null;    //在庫調整明細データリスト
            ArrayList bfstockAdjustDtlWorkList = null;  //在庫調整明細データリスト(前回値)
            ArrayList stockWorkList = new ArrayList();             //在庫リスト
            ArrayList stockAcPayHistWorkList = null;    //在庫受払履歴リスト

            string resNm = "";

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //パラメータのキャスト
                CustomSerializeArrayList paraList = stockAdjustWork as CustomSerializeArrayList;
                if (paraList == null) return status;

                //リストから必要な情報を取得
                for (int i = 0; i < paraList.Count; i++)
                {
                    ArrayList wkal = paraList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫調整データの場合
                            if (wkal[0] is StockAdjustWork)
                            {
                                stockAdjustWorkList = wkal;
                            }
                            //在庫調整明細データの場合
                            else if (wkal[0] is StockAdjustDtlWork)
                            {
                                stockAdjustDtlWorkList = wkal;
                            }
                        }
                    }
                }

                StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;

                resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);
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

                    return status;
                }

                try
                {
                    //---在庫調整伝票番号採番---
                    //前回値取得
                    status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);

                    //発注計上のチェック True:発注計上
                    bool uoeflg = CheckSendAddUp(bfstockAdjustDtlWorkList);

                    //発注データ更新
                    if (uoeflg && bfstockAdjustDtlWorkList != null)
                    {
                        StockSlipDB stockSlipDB = new StockSlipDB();
                        ArrayList parastockDetailList = CopyToParaStockDetailFromStockAdjustDtl(bfstockAdjustDtlWorkList, null, (int)ct_WriteMode.Delete);

                        //仕入リモートの発注計上メソッドの呼び出し
                        status = stockSlipDB.UpdateOrderRemainCnt(new StockSlipWork(), parastockDetailList, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    }

                    //write実行
                    //在庫調整データ削除
                    if (stockAdjustWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = LogicalDeleteStockAdjustProc(ref stockAdjustWorkList, 0, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整データの削除に失敗しました。";
                    }

                    //在庫調整明細データ削除
                    if (stockAdjustDtlWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = LogicalDeleteStockAdjustDtlProc(ref stockAdjustDtlWorkList, 0, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) retMsg = "在庫調整明細データの削除に失敗しました。";
                    }

                    //前回値リストを今回更新リストの値で更新
                    for (int i = 0; i < bfstockAdjustDtlWorkList.Count; i++)
                    {
                        //実テーブルにはない項目のため、前回値のリストでは取得出来ない項目を更新
                        //受払作成時に使用する

                        StockAdjustDtlWork bfwork = bfstockAdjustDtlWorkList[i] as StockAdjustDtlWork;
                        StockAdjustDtlWork work = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        bfwork.SectionGuideNm = work.SectionGuideNm;
                        bfwork.SupplierCd = work.SupplierCd;
                        bfwork.SupplierSnm = work.SupplierSnm;
                    }

                    //在庫系データ作成処理 (在庫受払履歴データ作成)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //削除時は前回値で受払履歴を作成する
                        TransStockData(true, (int)ct_WriteMode.Delete, null, ref stockAdjustWorkList, ref bfstockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                    }

                    //在庫データ更新
                    if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                        tempparaList.Add(stockWorkList);
                        tempparaList.Add(stockAcPayHistWorkList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        int shelfNoUpdateDiv = 1;  //1:棚番更新しない（棚番更新は棚卸用）

                        status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                    }

                    //戻り値セット
                    stockAdjustWork = paraList;
                }
                finally
                {
                    //ＡＰアンロック
                    Release(resNm, sqlConnection, sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
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

        /*
        /// <summary>
        /// 在庫調整データ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">在庫調整データ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 在庫調整データ情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(paraobj);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteStockAdjustProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAdjustDB.Delete");
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
        */

        /// <summary>
        /// 在庫調整データ情報を物理削除します(外部からのSqlConnection AND SqlTranactionを使用)
        /// </summary>
        /// <param name="stockadjustWorkList">在庫調整データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫調整データ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int DeleteStockAdjustProc(ArrayList stockadjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAdjustProcProc(stockadjustWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫調整データ情報を物理削除します(外部からのSqlConnection AND SqlTranactionを使用)
        /// </summary>
        /// <param name="stockadjustWorkList">在庫調整データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫調整データ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int DeleteStockAdjustProcProc(ArrayList stockadjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < stockadjustWorkList.Count; i++)
                {
                    StockAdjustWork stockadjustWork = stockadjustWorkList[i] as StockAdjustWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                    findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockadjustWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustWork.StockAdjustSlipNo);
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

        /// <summary>
        /// 在庫調整明細データ情報を物理削除します(外部からのSqlConnection AMD SqlTranactionを使用)
        /// </summary>
        /// <param name="stockadjustdtlWorkList">在庫調整明細データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫調整明細データ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        public int DeleteStockAdjustDtlProc(ArrayList stockadjustdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAdjustDtlProcProc(stockadjustdtlWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫調整明細データ情報を物理削除します(外部からのSqlConnection AMD SqlTranactionを使用)
        /// </summary>
        /// <param name="stockadjustdtlWorkList">在庫調整明細データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫調整明細データ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private int DeleteStockAdjustDtlProcProc(ArrayList stockadjustdtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < stockadjustdtlWorkList.Count; i++)
                {
                    StockAdjustDtlWork stockadjustdtlWork = stockadjustdtlWorkList[i] as StockAdjustDtlWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                    SqlParameter findParaStockAdjustRowNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTROWNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                    findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                    findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockadjustdtlWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM STOCKADJUSTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO AND STOCKADJUSTROWNORF=@FINDSTOCKADJUSTROWNO";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockadjustdtlWork.EnterpriseCode);
                        findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustSlipNo);
                        findParaStockAdjustRowNo.Value = SqlDataMediator.SqlSetInt32(stockadjustdtlWork.StockAdjustRowNo);
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

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockAdjustWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAdjustWork stockAdjustWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockAdjustWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            if (stockAdjustWork.StockAdjustSlipNo != 0)
            {
                retstring += " AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO" + Environment.NewLine;
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);
                findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(stockAdjustWork.StockAdjustSlipNo);
            }


            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockAdjustWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockAdjustWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        /// </remarks>
        private StockAdjustWork CopyToStockAdjustWorkFromReader(ref SqlDataReader myReader)
        {
            StockAdjustWork wkStockAdjustWork = new StockAdjustWork();

            #region クラスへ格納
            wkStockAdjustWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockAdjustWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockAdjustWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockAdjustWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockAdjustWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockAdjustWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockAdjustWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockAdjustWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockAdjustWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockAdjustWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
            wkStockAdjustWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            wkStockAdjustWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            wkStockAdjustWork.AdjustDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
            wkStockAdjustWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockAdjustWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            wkStockAdjustWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            wkStockAdjustWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            wkStockAdjustWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkStockAdjustWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkStockAdjustWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            wkStockAdjustWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            #endregion

            return wkStockAdjustWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → StockAdjustDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockAdjustDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.14</br>
        /// </remarks>
        private StockAdjustDtlWork CopyToStockAdjustDtlWorkFromReader(ref SqlDataReader myReader)
        {
            StockAdjustDtlWork wkStockAdjustDtlWork = new StockAdjustDtlWork();

            #region クラスへ格納
            wkStockAdjustDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockAdjustDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockAdjustDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockAdjustDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockAdjustDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockAdjustDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockAdjustDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockAdjustDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockAdjustDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockAdjustDtlWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
            wkStockAdjustDtlWork.StockAdjustRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
            wkStockAdjustDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
            wkStockAdjustDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
            wkStockAdjustDtlWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            wkStockAdjustDtlWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            wkStockAdjustDtlWork.AdjustDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
            wkStockAdjustDtlWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockAdjustDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockAdjustDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockAdjustDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockAdjustDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockAdjustDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockAdjustDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            wkStockAdjustDtlWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
            wkStockAdjustDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
            wkStockAdjustDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockAdjustDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockAdjustDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockAdjustDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockAdjustDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockAdjustDtlWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
            wkStockAdjustDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkStockAdjustDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            #endregion  // クラスへ格納

            return wkStockAdjustDtlWork;
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
        /// <br>Date       : 2007.02.14</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockAdjustWork[] StockAdjustWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is StockAdjustWork)
                    {
                        StockAdjustWork wkStockAdjustWork = paraobj as StockAdjustWork;
                        if (wkStockAdjustWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockAdjustWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockAdjustWorkArray = (StockAdjustWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockAdjustWork[]));
                        }
                        catch (Exception) { }
                        if (StockAdjustWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockAdjustWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockAdjustWork wkStockAdjustWork = (StockAdjustWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockAdjustWork));
                                if (wkStockAdjustWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockAdjustWork);
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
        /// <br>Date       : 2007.02.14</br>
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

        #region 在庫調整伝票番号採番
        /// <summary>
        /// 在庫調整伝票番号を採番して返します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockAdjustSlipNo">採番結果</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動伝票番号を採番して返します</br>
        /// <br>Programmer : 21015 金巻　芳則</br>
        /// <br>Date       : 2007.02.07</br>
        private int CreateStockAdjustSlipNo(string enterpriseCode, string sectionCode, out int stockAdjustSlipNo, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            stockAdjustSlipNo = 0;

            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMsg = null;
            retItemInfo = null;

            NumberingManager numberingManager = new NumberingManager();

            //番号範囲分ループ
            Int32 loopCnt = 1;

            while (loopCnt <= 999999999)
            {
                long no;

                //在庫調整伝票番号は拠点非依存だから拠点コードは全社
                status = numberingManager.GetSerialNumber(enterpriseCode, sectionCode, SerialNumberCode.StockAdjustSlipNo,  out no);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //番号を数値型に変換
                    Int32 tmpStockAdjustSlipNo = System.Convert.ToInt32(no);
                    SqlDataReader myReader = null;

                    //空き番チェック
                    try
                    {
                        //Selectコマンドの生成
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT STOCKADJUSTSLIPNORF FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO ", sqlConnection, sqlTransaction))
                        {

                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                            findParaStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(tmpStockAdjustSlipNo);

                            myReader = sqlCommand.ExecuteReader();
                            //データ無しの場合には戻り値をセット
                            if (!myReader.Read())
                            {
                                stockAdjustSlipNo = tmpStockAdjustSlipNo;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        retMsg = "在庫調整伝票番号採番中にエラーが発生しました。";
                        retItemInfo = "StockAdjustSlipNo";

                        //基底クラスに例外を渡して処理してもらう
                        status = base.WriteSQLErrorLog(ex);
                        break;
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                }
                //採番できなかった場合には処理中断。
                else break;

                //同一番号がある場合にはループカウンタをインクリメントし再採番
                loopCnt++;
            }

            //全件ループしても取得出来ない場合
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                retMsg = "在庫調整伝票番号に空き番号がありません。削除可能な伝票を削除してください。";
                retItemInfo = "StockAdjustSlipNo";
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }
        #endregion

        #region 在庫調整データ→在庫受払履歴データ
        /// <summary>
        /// 在庫受払履歴データ作成処理
        /// </summary>
        /// <param name="createStock"></param>
        /// <param name="writeMode"></param>
        /// <param name="bfstockAdjustDtlWorkList"></param>
        /// <param name="stockAdjustList"></param>
        /// <param name="stockAdjustDtlList"></param>
        /// <param name="stockAcPayHistList"></param>
        /// <param name="stockList"></param>
        /// <param name="procMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        /// <remarks>DC.NSでは、在庫受払履歴はあるが、在庫受払履歴詳細はない。</remarks>
        /// <remarks>在庫受払履歴に明細データをもつように変更されている。</remarks>
        private int TransStockData(bool createStock,int writeMode, ArrayList bfstockAdjustDtlWorkList, ref ArrayList stockAdjustList, ref ArrayList stockAdjustDtlList, out ArrayList stockAcPayHistList,ref ArrayList stockList ,int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            stockAcPayHistList = new ArrayList();   //在庫受払履歴リスト

            StockAdjustWork stockAdjustWork = stockAdjustList[0] as StockAdjustWork; //調整データのヘッダは必ず1レコード分存在する前提
            StockAdjustDtlWorkComparer stockAdjustDtlWorkComparer = new StockAdjustDtlWorkComparer();

            Dictionary<string, StockWork> stockDic = new Dictionary<string, StockWork>();

            //在庫調整明細リストのソート
            if (stockAdjustDtlList != null)
            {
                stockAdjustDtlList.Sort(stockAdjustDtlWorkComparer);
            }

            if (bfstockAdjustDtlWorkList != null)
            {
                bfstockAdjustDtlWorkList.Sort(stockAdjustDtlWorkComparer);
            }

            if (stockAdjustDtlList != null)
            {
                for (int i = 0; i < stockAdjustDtlList.Count; i++)
                {

                    //在庫調整明細データ取得
                    StockAdjustDtlWork stockAdjustDtlWork = stockAdjustDtlList[i] as StockAdjustDtlWork;

                    StockAdjustDtlWork bfstockAdjustDtlWork = null;
                    StockAcPayHistWork stockAcPayHistWork = null;

                    if (bfstockAdjustDtlWorkList != null)
                    {
                        bfstockAdjustDtlWork = bfstockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        //修正伝票の場合、数量、金額の差分をセット
                        stockAdjustDtlWork.AdjustCount -= bfstockAdjustDtlWork.AdjustCount;
                        stockAdjustDtlWork.StockPriceTaxExc -= bfstockAdjustDtlWork.StockPriceTaxExc;
                    }

                    //在庫仕入入力、委託補充の場合はリモートで在庫リストを生成する
                    if (createStock == true)
                    {
                        if (stockDic.ContainsKey(CreateKeyStockString(stockAdjustDtlWork)))
                        {
                            StockWork stockWork = stockDic[CreateKeyStockString(stockAdjustDtlWork)] as StockWork;
                            stockWork = CopyStockWorkFromStockAdjustDtlWork(stockWork, stockAdjustDtlWork, procMode, writeMode);
                        }
                        else
                        {

                            StockWork stockWork = CopyStockWorkFromStockAdjustDtlWork(null, stockAdjustDtlWork, procMode, writeMode);

                            stockDic.Add(CreateKeyStockString(stockAdjustDtlWork), stockWork);
                            stockList.Add(stockWork);
                        }
                    }

                    //在庫受払履歴データ
                    if (bfstockAdjustDtlWork == null)
                    {
                        //前回値無し＝新規作成
                        stockAcPayHistWork = CopyStockAcPayHisWorkFromStockAdjustWork(stockAdjustWork, stockAdjustDtlWork, procMode, writeMode);
                    }
                    else
                    {
                        if (
                            (stockAdjustDtlWork.AdjustCount != 0) ||
                            (stockAdjustDtlWork.StockPriceTaxExc != 0) ||
                            (stockAdjustDtlWork.ListPriceFl != bfstockAdjustDtlWork.ListPriceFl) ||
                            (stockAdjustDtlWork.StockUnitPriceFl != bfstockAdjustDtlWork.StockUnitPriceFl)
                            )
                        {
                            //修正時
                            //調整数、仕入金額、定価、仕入単価、明細備考のいずれかの項目が変更された場合のみ登録する
                            stockAcPayHistWork = CopyStockAcPayHisWorkFromStockAdjustWork(stockAdjustWork, stockAdjustDtlWork, procMode, writeMode);
                        }
                    }

                    //在庫調整明細から在庫受払履歴を作成
                    if (stockAcPayHistWork != null)
                        stockAcPayHistList.Add(stockAcPayHistWork);
                }
            }

            return status;
        }
        #endregion

        #region 在庫更新用、削除用リスト作成(商品在庫マスメン用)
        /// <summary>
        /// 在庫更新用、削除リスト作成(商品在庫マスメン用)
        /// </summary>
        /// <param name="stockWorkList">在庫リスト</param>
        /// <param name="stockWriteList">在庫更新用リスト</param>
        /// <param name="stockDeleteList">在庫削除用リスト</param>
        /// <returns></returns>
        private int CreateStockWriteDelList(ArrayList stockWorkList, out ArrayList stockWriteList, out ArrayList stockDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            stockWriteList = new ArrayList();
            stockDeleteList = new ArrayList();

            foreach (StockWork stockWork in stockWorkList)
            {
                if (stockWork.LogicalDeleteCode == 3)
                {
                    //削除用リスト作成
                    stockDeleteList.Add(stockWork);
                }
                else
                {
                    //更新用リスト作成
                    stockWriteList.Add(stockWork);
                }
            }

            return status;
        }
        #endregion

        #region キー用文字列作成
        /// <summary>
        /// Key用文字列作成処理
        /// </summary>
        /// <param name="stockAdjustDtlWork"></param>
        /// <returns></returns>
        private string CreateKeyStockString(StockAdjustDtlWork stockAdjustDtlWork)
        {
            string retString = "";
            retString =
                stockAdjustDtlWork.EnterpriseCode + "-" +
                stockAdjustDtlWork.WarehouseCode + "-" +
                stockAdjustDtlWork.GoodsMakerCd.ToString("%06d") + "-" +
                stockAdjustDtlWork.GoodsNo;
            return retString;
        }
        #endregion

        #region クラス格納処理
        /// <summary>
        /// 在庫データ・在庫調整データ・在庫調整明細データ → 在庫受払履歴データ
        /// </summary>
        /// <param name="stockAdjustWork">在庫調整データ</param>
        /// <param name="stockAdjustDtlWork">在庫調整明細データ</param>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <returns>在庫受払明細</returns>
        private StockAcPayHistWork CopyStockAcPayHisWorkFromStockAdjustWork(StockAdjustWork stockAdjustWork, StockAdjustDtlWork stockAdjustDtlWork, int procMode, int writeMode)
        {
            StockAcPayHistWork retStockAcPayHistWork = new StockAcPayHistWork();
            int mark = 1;
            if (writeMode == (int)ct_WriteMode.Write)
            {
                mark = 1;
            }
            else
            {
                mark = -1;
            }
                
            #region 格納処理
            //在庫調整データ、在庫調整明細データからセット
            retStockAcPayHistWork.EnterpriseCode = stockAdjustDtlWork.EnterpriseCode;       //企業コード

            retStockAcPayHistWork.IoGoodsDay = stockAdjustDtlWork.AdjustDate;               //入出荷日←調整日付
            retStockAcPayHistWork.AddUpADate = stockAdjustDtlWork.AdjustDate;               //計上日付←調整日
            retStockAcPayHistWork.AcPaySlipCd = stockAdjustDtlWork.AcPaySlipCd;             //受払元伝票区分
            retStockAcPayHistWork.AcPaySlipNum = stockAdjustDtlWork.StockAdjustSlipNo.ToString();    //受払元伝票番号←在庫調整伝票番号
            retStockAcPayHistWork.AcPaySlipRowNo = stockAdjustDtlWork.StockAdjustRowNo;     //受払元行番号←在庫調整行番号

            if (writeMode == (int)ct_WriteMode.Delete)
            {
                retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip;           //受払元取引区分
            }
            else
            {
                retStockAcPayHistWork.AcPayTransCd = stockAdjustDtlWork.AcPayTransCd;           //受払元取引区分
            }

            // 2009/04/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //retStockAcPayHistWork.InputSectionCd = stockAdjustWork.StockSectionCd;           //入力拠点コード
            //retStockAcPayHistWork.InputSectionGuidNm = stockAdjustWork.StockSectionGuideNm;  //入力拠点ガイド名称
            retStockAcPayHistWork.InputSectionCd = stockAdjustDtlWork.SectionCode;             //入力拠点コード
            retStockAcPayHistWork.InputSectionGuidNm = stockAdjustDtlWork.SectionGuideNm;      //入力拠点ガイド名称
            // 2009/04/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            retStockAcPayHistWork.InputAgenCd = stockAdjustWork.StockInputCode;                //入力担当者コード
            retStockAcPayHistWork.InputAgenNm = stockAdjustWork.StockInputName;                //入力担当者名称
            retStockAcPayHistWork.AcPayNote = stockAdjustDtlWork.DtlNote;                   //受払備考 = 明細備考(DtlNote)
            retStockAcPayHistWork.GoodsMakerCd = stockAdjustDtlWork.GoodsMakerCd;           //メーカーコード
            retStockAcPayHistWork.MakerName = stockAdjustDtlWork.MakerName;                 //メーカー名称
            retStockAcPayHistWork.GoodsNo = stockAdjustDtlWork.GoodsNo;                     //商品コード
            retStockAcPayHistWork.GoodsName = stockAdjustDtlWork.GoodsName;                 //商品名称
            retStockAcPayHistWork.BLGoodsCode = stockAdjustDtlWork.BLGoodsCode;             //BL商品コード
            retStockAcPayHistWork.BLGoodsFullName = stockAdjustDtlWork.BLGoodsFullName;     //BL商品コード名称(全角)
            retStockAcPayHistWork.WarehouseCode = stockAdjustDtlWork.WarehouseCode;         //倉庫コード
            retStockAcPayHistWork.WarehouseName = stockAdjustDtlWork.WarehouseName;         //倉庫名称
            retStockAcPayHistWork.ShelfNo = stockAdjustDtlWork.WarehouseShelfNo;            //棚番
            // 2009/04/09 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //retStockAcPayHistWork.SectionCode = stockAdjustDtlWork.SectionCode;             //拠点コード
            //retStockAcPayHistWork.SectionGuideNm = stockAdjustDtlWork.SectionGuideNm;       //拠点ガイド名称
            retStockAcPayHistWork.SectionCode = stockAdjustWork.StockSectionCd;               //拠点コード
            retStockAcPayHistWork.SectionGuideNm = stockAdjustWork.StockSectionGuideNm;       //拠点ガイド名称
            // 2009/04/09 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            retStockAcPayHistWork.SupplierCd = stockAdjustDtlWork.SupplierCd;               //仕入先コード
            retStockAcPayHistWork.SupplierSnm = stockAdjustDtlWork.SupplierSnm;             //仕入先略称

            //補充出庫の場合は出庫に値をセット
            if (retStockAcPayHistWork.AcPaySlipCd == (int)ct_AcPaySlipCd_PM.replaceShip)
            {
                retStockAcPayHistWork.SalesUnPrcTaxExcFl = stockAdjustDtlWork.StockUnitPriceFl;   //売上単価 ← 仕入単価
                retStockAcPayHistWork.ShipmentCnt = stockAdjustDtlWork.AdjustCount * mark * -1;              //出荷数 ← 調整数
                retStockAcPayHistWork.SalesMoney = stockAdjustDtlWork.StockPriceTaxExc * mark * -1;         //売上金額 ← 仕入金額
            }
            else
            {
                retStockAcPayHistWork.StockUnitPriceFl = stockAdjustDtlWork.StockUnitPriceFl;   //仕入単価
                retStockAcPayHistWork.ArrivalCnt = stockAdjustDtlWork.AdjustCount * mark;              //入荷数 ← 調整数
                retStockAcPayHistWork.StockPrice = stockAdjustDtlWork.StockPriceTaxExc * mark;         //仕入金額
            }
            retStockAcPayHistWork.OpenPriceDiv = stockAdjustDtlWork.OpenPriceDiv;           //オープン価格区分
            retStockAcPayHistWork.ListPriceTaxExcFl = stockAdjustDtlWork.ListPriceFl;       //定価

            //ADD 2011/09/02 #24259------------------------------------------------------------------------------------------------->>>>>
            if (_isRecv)
            {
                retStockAcPayHistWork.SectionGuideNm = GetSecNameBySecCode(retStockAcPayHistWork.SectionCode);//拠点名称
                retStockAcPayHistWork.InputSectionGuidNm = GetSecNameBySecCode(retStockAcPayHistWork.InputSectionCd);//入力拠点ガイド名称
            }
            //ADD 2011/09/02 #24259------------------------------------------------------------------------------------------------<<<<<

            #endregion // 格納処理

            return retStockAcPayHistWork;
        }

        /// <summary>
        /// 在庫調整明細データ → 在庫マスタ
        /// </summary>
        /// <param name="retStockWork">在庫マスタ</param>
        /// <param name="stockAdjustDtlWork">在庫調整明細データ</param>
        /// <param name="procMode">処理モード</param>
        /// <param name="writeMode">更新モード</param>
        /// <returns>在庫</returns>
        /// <remarks>
        /// <br>UpdateNote : 2010/12/20 曹文傑 障害改良対応ｘ月</br>
        /// <br>             在庫仕入データ登録時、在庫マスタの最終仕入日が更新されない不具合を修正</br>
        /// <br>UpdateNote : ハンディターミナル在庫仕入（UOE以外）の登録処理で最終仕入日の補足</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private StockWork CopyStockWorkFromStockAdjustDtlWork(StockWork retStockWork,StockAdjustDtlWork stockAdjustDtlWork, int procMode, int writeMode)
        {
            if (retStockWork == null)
                retStockWork = new StockWork();

            int mark = 1;
            if (writeMode == (int)ct_WriteMode.Write)
            {
                mark = 1;
            }
            else
            {
                mark = -1;
            }

            retStockWork.EnterpriseCode = stockAdjustDtlWork.EnterpriseCode;
            retStockWork.WarehouseCode = stockAdjustDtlWork.WarehouseCode;
            retStockWork.GoodsMakerCd = stockAdjustDtlWork.GoodsMakerCd;
            retStockWork.GoodsNo = stockAdjustDtlWork.GoodsNo;
            retStockWork.SupplierStock += stockAdjustDtlWork.AdjustCount * mark;
            retStockWork.SectionCode = stockAdjustDtlWork.SectionCode;

            //仕入明細通番（元）が存在している場合は発注残も更新する
            if (stockAdjustDtlWork.StockSlipDtlNumSrc != 0)
            {
                retStockWork.SalesOrderCount += stockAdjustDtlWork.AdjustCount * mark * - 1;
            }

            // ---ADD 2010/12/20---------->>>>>
            //最終仕入日には、在庫調整明細データの調整日付をセットする
            if ((stockAdjustDtlWork.UpdAssemblyId1 != string.Empty)
                && (stockAdjustDtlWork.UpdAssemblyId1.IndexOf("MAZAI04350") >= 0))
            {
                retStockWork.LastStockDate = stockAdjustDtlWork.AdjustDate;
            }
            // ------ ADD 2017/08/11 譚洪 ハンディターミナル在庫仕入（UOE以外）の登録処理で最終仕入日の補足 --------- >>>>
            else if ((stockAdjustDtlWork.UpdAssemblyId1 != string.Empty)
                && (stockAdjustDtlWork.UpdAssemblyId1.IndexOf("PMHND00003A") >= 0))
            {
                retStockWork.LastStockDate = stockAdjustDtlWork.AdjustDate;
            }
            // ------ ADD 2017/08/11 譚洪 ハンディターミナル在庫仕入（UOE以外）の登録処理で最終仕入日の補足 --------- <<<<
            else
            {
                //なし。
            }
            // ---ADD 2010/12/20----------<<<<<

            // ADD 2011/09/16 sundx #25139 ----------------------------------------------->>>>>
            if (_isRecv)
            {
                //在庫拠点コードを在庫調整データ．仕入拠点コードに設定
                retStockWork.SectionCode = _secCode;
                
                //ハイフン無品番
                retStockWork.GoodsNoNoneHyphen = stockAdjustDtlWork.GoodsNo.Replace("-", "");
                //倉庫棚番
                retStockWork.WarehouseShelfNo = stockAdjustDtlWork.WarehouseShelfNo;
            }
            // ADD 2011/09/16 sundx #25139 -----------------------------------------------<<<<<

            return retStockWork;
        }
        #endregion

        #region ADD 2011/08/11 孫東響 SCM対応-拠点管理（10704767-00）在庫調整データ受信時に在庫マスタの更新を行う        
        /// <summary>
        /// 在庫調整データ受信更新処理
        /// </summary>
        /// <param name="stockAdjustWorkList">受信した在庫調整データリスト</param>
        /// <param name="stockAdjustDtlWorkList">受信した在庫調整データ明細リスト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">エラー情報</param>
        /// <returns>ステータス</returns>
        public int WriteForReceiveData(ArrayList stockAdjustWorkList, ArrayList stockAdjustDtlWorkList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)        
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlEncryptInfo sqlEncryptInfo = null;
            int stockAdjustSlipNo = 0;
            retMsg = "";
            string retItemInfo = "";

            ArrayList bfstockAdjustDtlWorkList = null;  //在庫調整明細データリスト(前回値)
            ArrayList stockAcPayHistWorkList = null;    //在庫受払履歴リスト
            ArrayList stockWorkList = new ArrayList();             //在庫リスト

            ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
            Dictionary<string, string> dic = new Dictionary<string, string>(); //倉庫リスト 

            //bool uoeflg = false;//DEL 2011/09/07 sundx #24355
            string resNm = "";

            try
            {
                if (stockAdjustWorkList == null || stockAdjustDtlWorkList == null || stockAdjustWorkList.Count == 0 || stockAdjustDtlWorkList.Count == 0)
                    return status;

                //ADD 2011/09/02 #24259------------------------------->>>>>
                //コネクション生成
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //拠点設定の取得
                    status = GetSecInfoSetWork(stockAdjustDtlWorkList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "拠点設定の取得に失敗しました。";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }
                //ADD 2011/09/02 #24259-------------------------------<<<<<

                StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;
                _secCode = wkStockAdjustWork.StockSectionCd;//ADD 2011/09/16 sundx #25139
                //在庫仕入でＡＰロック
                resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);

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

                    return status;
                }

                //---在庫調整伝票番号採番---
                if (wkStockAdjustWork.StockAdjustSlipNo == 0)
                {
                    status = CreateStockAdjustSlipNo(wkStockAdjustWork.EnterpriseCode, wkStockAdjustWork.SectionCode, out stockAdjustSlipNo, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    wkStockAdjustWork.StockAdjustSlipNo = stockAdjustSlipNo;
                }
                else
                {
                    stockAdjustSlipNo = wkStockAdjustWork.StockAdjustSlipNo;
                    //前回値取得
                    status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);
                    if (bfstockAdjustDtlWorkList.Count == 0)
                        bfstockAdjustDtlWorkList = null;
                }

                #region DEL 
                //DEL 2011/09/07 sundx #24355 ------------------------------------------------------------------------------------->>>>>
                ////発注計上のチェック True:発注計上
                //uoeflg = CheckSendAddUp(stockAdjustDtlWorkList);

                ////発注データ更新
                //if (uoeflg && stockAdjustDtlWorkList != null)
                //{
                //    StockSlipDB stockSlipDB = new StockSlipDB();
                //    ArrayList parastockDetailList = CopyToParaStockDetailFromStockAdjustDtl(stockAdjustDtlWorkList, bfstockAdjustDtlWorkList, (int)ct_WriteMode.Write);

                //    //仕入リモートの発注計上メソッドの呼び出し
                //    status = stockSlipDB.UpdateOrderRemainCnt(new StockSlipWork(), parastockDetailList, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //}
                //DEL 2011/09/07 sundx #24355 -------------------------------------------------------------------------------------<<<<<
                #endregion

                //write実行
                //在庫系データ作成処理 (在庫受払履歴データ作成)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = TransStockData(true, (int)ct_WriteMode.Write, bfstockAdjustDtlWorkList, ref stockAdjustWorkList, ref stockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                }

                //在庫データ更新
                if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    string origin = "";
                    CustomSerializeArrayList originList = null;
                    CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                    tempparaList.Add(stockWorkList);
                    tempparaList.Add(stockAcPayHistWorkList);
                    int position = 0;
                    string param = "";
                    object freeParam = null;
                    int shelfNoUpdateDiv = 1;  //1:棚番更新しない（棚番更新は棚卸用）

                    status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
            }
            finally
            {
                //ＡＰアンロック
                Release(resNm, sqlConnection, sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// 在庫調整データ受信更新処理
        /// </summary>
        /// <param name="stockAdjustWorkList">受信した在庫調整データリスト</param>
        /// <param name="stockAdjustDtlWorkList">受信した在庫調整データ明細リスト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">エラー情報</param>
        /// <returns>ステータス</returns>
        public int DeleteForReceiveData(ArrayList stockAdjustWorkList, ArrayList stockAdjustDtlWorkList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlEncryptInfo sqlEncryptInfo = null;
            retMsg = "";
            string retItemInfo = "";

            ArrayList bfstockAdjustDtlWorkList = null;  //在庫調整明細データリスト(前回値)
            ArrayList stockWorkList = new ArrayList();  //在庫リスト
            ArrayList stockAcPayHistWorkList = null;    //在庫受払履歴リスト

            string resNm = "";

            try
            {
                //ADD 2011/09/02 #24259------------------------------->>>>>
                //コネクション生成
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //拠点設定の取得
                    status = GetSecInfoSetWork(stockAdjustDtlWorkList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "拠点設定の取得に失敗しました。";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;                    
                }
                
                //ADD 2011/09/02 #24259-------------------------------<<<<<

                StockAdjustWork wkStockAdjustWork = stockAdjustWorkList[0] as StockAdjustWork;
                _secCode = wkStockAdjustWork.StockSectionCd;//ADD 2011/09/16 sundx #25139
                resNm = GetResourceName(wkStockAdjustWork.EnterpriseCode);
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

                    return status;
                }

                try
                {
                    //---在庫調整伝票番号採番---
                    //前回値取得
                    status = SearchStockAdjustDtlProc(out bfstockAdjustDtlWorkList, wkStockAdjustWork, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //既存拠点データは存在しない時、処理終了
                        if (bfstockAdjustDtlWorkList.Count == 0)
                            return status;
                        //既存拠点データの論理区分は1の時、処理終了
                        StockAdjustDtlWork dtlWork = bfstockAdjustDtlWorkList[0] as StockAdjustDtlWork;
                        if (dtlWork.LogicalDeleteCode == 1)
                            return status;
                    }
                    else
                    {
                        //エラー発生時、処理終了
                        return status;
                    }
                    #region DEL 
                    //DEL 2011/09/07 sundx #24355 --------------------------------------------------------------------------------->>>>>
                    ////発注計上のチェック True:発注計上
                    //bool uoeflg = CheckSendAddUp(bfstockAdjustDtlWorkList);

                    ////発注データ更新
                    //if (uoeflg && bfstockAdjustDtlWorkList != null)
                    //{
                    //    StockSlipDB stockSlipDB = new StockSlipDB();
                    //    ArrayList parastockDetailList = CopyToParaStockDetailFromStockAdjustDtl(bfstockAdjustDtlWorkList, null, (int)ct_WriteMode.Delete);

                    //    //仕入リモートの発注計上メソッドの呼び出し
                    //    status = stockSlipDB.UpdateOrderRemainCnt(new StockSlipWork(), parastockDetailList, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //}
                    //DEL 2011/09/07 sundx #24355 --------------------------------------------------------------------------------->>>>>
                    #endregion

                    //write実行                   
                    //前回値リストを今回更新リストの値で更新
                    for (int i = 0; i < bfstockAdjustDtlWorkList.Count; i++)
                    {
                        //実テーブルにはない項目のため、前回値のリストでは取得出来ない項目を更新
                        //受払作成時に使用する

                        StockAdjustDtlWork bfwork = bfstockAdjustDtlWorkList[i] as StockAdjustDtlWork;
                        StockAdjustDtlWork work = stockAdjustDtlWorkList[i] as StockAdjustDtlWork;

                        bfwork.SectionGuideNm = work.SectionGuideNm;
                        bfwork.SupplierCd = work.SupplierCd;
                        bfwork.SupplierSnm = work.SupplierSnm;
                    }

                    //在庫系データ作成処理 (在庫受払履歴データ作成)
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //削除時は前回値で受払履歴を作成する
                        TransStockData(true, (int)ct_WriteMode.Delete, null, ref stockAdjustWorkList, ref bfstockAdjustDtlWorkList, out stockAcPayHistWorkList, ref stockWorkList, (int)ct_ProcMode.Adjust, ref sqlConnection, ref sqlTransaction);
                    }

                    //在庫データ更新
                    if (stockWorkList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList tempparaList = new CustomSerializeArrayList();
                        tempparaList.Add(stockWorkList);
                        tempparaList.Add(stockAcPayHistWorkList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        int shelfNoUpdateDiv = 1;  //1:棚番更新しない（棚番更新は棚卸用）

                        status = _stockDB.WriteForStockAdjust(origin, ref originList, ref tempparaList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, shelfNoUpdateDiv);
                    }
                }
                finally
                {
                    //ＡＰアンロック
                    Release(resNm, sqlConnection, sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockAdjustDB.Write(ref object stockAdjustWork)");
            }
            return status;
        }
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="secCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称を取得します。</br>
        /// <br>Programmer  : 孫東響</br>
        /// <br>Date        : 2011/09/02</br>
        /// </remarks>
        private string GetSecNameBySecCode(string secCode)
        {
            if (string.IsNullOrEmpty(secCode))
            {
                return null;
            }
            if (secInfoSetWorkHash.Contains(secCode))
            {
                return secInfoSetWorkHash[secCode].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 拠点設定マスタ取得
        /// </summary>
        /// <param name="stockAdjustDtlWorkList">在庫調整明細リスト</param>
        /// <param name="secinfoSetWorkHash">拠点情報</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>ステータス</returns>
        private int GetSecInfoSetWork(ArrayList stockAdjustDtlWorkList, ref Hashtable secinfoSetWorkHash, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secinfoSetWorkHash = new Hashtable();

            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
                secInfoSetWork.EnterpriseCode = ((StockAdjustDtlWork)stockAdjustDtlWorkList[0]).EnterpriseCode;   //企業コード
            else
                return status;

            ArrayList secInfoList = new ArrayList();

            //拠点設定Seach呼び出し
            status = _secInfoDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //拠点名称をHashTableに格納
                foreach (SecInfoSetWork sec in secInfoList)
                {
                    secinfoSetWorkHash.Add(sec.SectionCode, sec.SectionGuideNm);

                }
            }

            return status;
        }
        #endregion
    }

    #region 比較クラス
    /// <summary>
    /// 在庫調整明細クラス比較クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    public class StockAdjustDtlWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x">比較オブジェクトｘ</param>
        /// <param name="y">比較オブジェクトｙ</param>
        /// <returns>result</returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockAdjustDtlWork cx = (StockAdjustDtlWork)x;
            StockAdjustDtlWork cy = (StockAdjustDtlWork)y;
    
            //在庫調整伝票番号
            result = cx.StockAdjustSlipNo - cy.StockAdjustSlipNo;
            //在庫調整行番号
            if (result == 0)
                result = cx.StockAdjustRowNo - cy.StockAdjustRowNo;

            //結果を返す
            return result;
        }
    }
    /// <summary>
    /// 在庫クラス比較クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    public class StockWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x">比較オブジェクトｘ</param>
        /// <param name="y">比較オブジェクトｙ</param>
        /// <returns>result</returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockWork cx = (StockWork)x;
            StockWork cy = (StockWork)y;

            //倉庫コード
            //if (result == 0)
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

 
    /// <summary>
    /// 棚卸更新クラス比較クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    public class InventoryDataUpdateWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x">比較オブジェクトｘ</param>
        /// <param name="y">比較オブジェクトｙ</param>
        /// <returns>result</returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            InventoryDataUpdateWork cx = (InventoryDataUpdateWork)x;
            InventoryDataUpdateWork cy = (InventoryDataUpdateWork)y;

            //拠点コード
            result = cx.SectionCode.CompareTo(cy.SectionCode);
            //倉庫コード
            if (result == 0)
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
    #endregion  // 比較クラス

}
