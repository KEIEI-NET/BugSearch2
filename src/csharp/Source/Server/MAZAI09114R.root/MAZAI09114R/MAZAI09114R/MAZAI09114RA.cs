using System;
using System.Collections;
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫管理全体設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫管理全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.03.02</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 数馬 PM.NS用に修正</br>
    /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
    /// <br>Update Note: 2011/08/29 周雨 連番 1016 「現在庫表示区分」をに追加</br>
    /// <br>Update Note: 2012/06/08 lanl #Redmine30282 「棚卸データ削除区分」をに追加</br>
    /// <br>Update Note: 2012/07/02 三戸　伸悟「移動時在庫自動登録区分」を画面に追加</br>
    /// <br>Update Note: 2014/10/27 wangf </br>
    /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
    /// </remarks>
    [Serializable]
    public class StockMngTtlStDB : RemoteDB, IStockMngTtlStDB
    {
        /// <summary>
        /// 在庫管理全体設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        public StockMngTtlStDB()
            :
            base("MAZAI09116D", "Broadleaf.Application.Remoting.ParamData.StockMngTtlStWork", "STOCKMNGTTLSTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="stockmngttlstWork">検索結果</param>
        /// <param name="parastockmngttlstWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int Search(out object stockmngttlstWork, object parastockmngttlstWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockmngttlstWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockMngTtlStProc(out stockmngttlstWork, parastockmngttlstWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Search");
                stockmngttlstWork = new ArrayList();
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
        /// 指定された条件の在庫管理全体設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objstockmngttlstWork">検索結果</param>
        /// <param name="parastockmngttlstWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int SearchStockMngTtlStProc(out object objstockmngttlstWork, object parastockmngttlstWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockMngTtlStWork stockmngttlstWork = null; 

            ArrayList stockmngttlstWorkList = parastockmngttlstWork as ArrayList;
            if (stockmngttlstWorkList == null)
            {
                stockmngttlstWork = parastockmngttlstWork as StockMngTtlStWork;
            }
            else
            {
                if (stockmngttlstWorkList.Count > 0)
                    stockmngttlstWork = stockmngttlstWorkList[0] as StockMngTtlStWork;
            }

            int status = SearchStockMngTtlStProc(out stockmngttlstWorkList, stockmngttlstWork, readMode, logicalMode, ref sqlConnection);
            objstockmngttlstWork = stockmngttlstWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">検索結果</param>
        /// <param name="stockmngttlstWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int SearchStockMngTtlStProc(out ArrayList stockmngttlstWorkList, StockMngTtlStWork stockmngttlstWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchStockMngTtlStProcProc(out stockmngttlstWorkList, stockmngttlstWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">検索結果</param>
        /// <param name="stockmngttlstWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private int SearchStockMngTtlStProcProc(out ArrayList stockmngttlstWorkList, StockMngTtlStWork stockmngttlstWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                selectTxt += "SELECT STK.*, SEC.SECTIONGUIDENMRF,STK2.STOCKMOVEFIXCODERF AS STOCKMOVEFIXCODE FROM STOCKMNGTTLSTRF AS STK" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN STOCKMNGTTLSTRF AS STK2" + Environment.NewLine;
                selectTxt += " ON STK2.ENTERPRISECODERF =STK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK2.SECTIONCODERF = '00' " + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockmngttlstWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockMngTtlStWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            stockmngttlstWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                StockMngTtlStWork stockmngttlstWork = new StockMngTtlStWork();

                // XMLの読み込み
                stockmngttlstWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMngTtlStWork));
                if (stockmngttlstWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockmngttlstWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(stockmngttlstWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Read");
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
        /// 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// 
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int ReadProc(ref StockMngTtlStWork stockmngttlstWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref stockmngttlstWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private int ReadProcProc(ref StockMngTtlStWork stockmngttlstWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;
                selectTxt += "SELECT STK.*, SEC.SECTIONGUIDENMRF,STK2.STOCKMOVEFIXCODERF AS STOCKMOVEFIXCODE FROM STOCKMNGTTLSTRF AS STK" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN STOCKMNGTTLSTRF AS STK2" + Environment.NewLine;
                selectTxt += " ON STK2.ENTERPRISECODERF =STK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STK2.SECTIONCODERF = '00' " + Environment.NewLine;
                selectTxt += " WHERE STK.ENTERPRISECODERF=@FINDENTERPRISECODE AND STK.SECTIONCODERF=@FINDSECTIONCODE";

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        stockmngttlstWork = CopyToStockMngTtlStWorkFromReader(ref myReader);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 在庫管理全体設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2012/06/13 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30437 №1002 No.33 在庫全体設定 全社レコード更新時に発生するサーバーエラーの修正</br>
        public int Write(ref object stockmngttlstWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(stockmngttlstWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteStockMngTtlStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                // DEL yangyi 2012/06/13 Redmine#30437 ------------->>>>>
                //StockMngTtlStWork paraWork = paraList[0] as StockMngTtlStWork;
                
                ////全社設定を更新した場合は、他の項目にも反映させる
                //if (paraWork.SectionCode == _allSecCode)
                //{
                //    UpdateAllSecStockMngTtlSt(ref paraList, ref sqlConnection, ref sqlTransaction);
                //}
                // DEL yangyi 2012/06/13 Redmine#30437 -------------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                stockmngttlstWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMngTtlStDB.Write(ref object stockmngttlstWork)");
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
        /// 在庫管理全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int WriteStockMngTtlStProc(ref ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteStockMngTtlStProcProc(ref stockmngttlstWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             #Redmine30282 「棚卸データ削除区分」をに追加　</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        private int WriteStockMngTtlStProcProc(ref ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockmngttlstWorkList != null)
                {
                    for (int i = 0; i < stockmngttlstWorkList.Count; i++)
                    {
                        StockMngTtlStWork stockmngttlstWork = stockmngttlstWorkList[i] as StockMngTtlStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM STOCKMNGTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockmngttlstWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (stockmngttlstWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += "UPDATE STOCKMNGTTLSTRF SET " + Environment.NewLine;
                            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , STOCKMOVEFIXCODERF=@STOCKMOVEFIXCODE" + Environment.NewLine;
                            sqlText += " , STOCKPOINTWAYRF=@STOCKPOINTWAY" + Environment.NewLine;
                            sqlText += " , FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
                            // --- ADD 2009/12/02 ---------->>>>>
                            // 棚卸運用区分
                            sqlText += " , INVENTORYMNGDIVRF=@INVENTORYMNGDIV" + Environment.NewLine;
                            // --- ADD 2009/12/02 ----------<<<<<
                            // ------------- ADD 2011/08/29 ---------------- >>>>>
                            // 現在庫表示区分
                            sqlText += " , PRESTCKCNTDSPDIVRF=@PRESTCKCNTDSPDIV" + Environment.NewLine;
                            // ------------- ADD 2011/08/29 ---------------- <<<<<
                            // ------------- ADD 2012/06/08 Redmine#30282 ---------------- >>>>>
                            // 棚卸データ削除区分
                            sqlText += " , INVNTRYDTDELDIVRF=@INVNTRYDTDELDIV" + Environment.NewLine;
                            // ------------- ADD 2012/06/08 Redmine#30282 ---------------- <<<<<
                            // --- ADD 三戸 2012/07/02 ---------->>>>>
                            // 移動時在庫自動登録区分
                            sqlText += " , MOVESTOCKAUTOINSDIVRF=@MOVESTOCKAUTOINSDIV" + Environment.NewLine;
                            // --- ADD 三戸 2012/07/02 ----------<<<<<
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
                            // 移動伝票出力先区分
                            sqlText += " , MOVESLIPOUTPUTDIVRF=@MOVESLIPOUTPUTDIV" + Environment.NewLine;
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
                            sqlText += " , STOCKTOLERNCSHIPMDIVRF=@STOCKTOLERNCSHIPMDIV" + Environment.NewLine;
                            sqlText += " , INVNTRYPRTODRINIDIVRF=@INVNTRYPRTODRINIDIV" + Environment.NewLine;
                            sqlText += " , MAXSTKCNTOVERODERDIVRF=@MAXSTKCNTOVERODERDIV" + Environment.NewLine;
                            sqlText += " , SHELFNODUPLDIVRF=@SHELFNODUPLDIV" + Environment.NewLine;
                            sqlText += " , LOTUSEDIVCDRF=@LOTUSEDIVCD" + Environment.NewLine;
                            sqlText += " , SECTDSPDIVCDRF=@SECTDSPDIVCD" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmngttlstWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockmngttlstWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += "INSERT INTO STOCKMNGTTLSTRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,STOCKMOVEFIXCODERF" + Environment.NewLine;
                            sqlText += "  ,STOCKPOINTWAYRF" + Environment.NewLine;
                            sqlText += "  ,FRACTIONPROCCDRF" + Environment.NewLine;
                            // --- ADD 2009/12/02 ---------->>>>>
                            // 棚卸運用区分
                            sqlText += "  ,INVENTORYMNGDIVRF" + Environment.NewLine;
                            // --- ADD 2009/12/02 ----------<<<<<
                            // -------------- ADD 2011/08/29 ---------------- >>>>>
                            // 現在庫表示区分
                            sqlText += "  ,PRESTCKCNTDSPDIVRF" + Environment.NewLine;
                            // -------------- ADD 2011/08/29 ---------------- <<<<<
                            // -------------- ADD 2012/06/08 Redmine#30282 ---------------- >>>>>
                            // 棚卸データ削除区分
                            sqlText += "  ,INVNTRYDTDELDIVRF" + Environment.NewLine;
                            // -------------- ADD 2012/06/08 Redmine#30282 ---------------- <<<<<
                            // --- ADD 三戸 2012/07/02 ---------->>>>>
                            // 移動時在庫自動登録区分
                            sqlText += "  ,MOVESTOCKAUTOINSDIVRF" + Environment.NewLine;
                            // --- ADD 三戸 2012/07/02 ----------<<<<<
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
                            // 移動伝票出力先区分
                            sqlText += "  ,MOVESLIPOUTPUTDIVRF" + Environment.NewLine;
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
                            sqlText += "  ,STOCKTOLERNCSHIPMDIVRF" + Environment.NewLine;
                            sqlText += "  ,INVNTRYPRTODRINIDIVRF" + Environment.NewLine;
                            sqlText += "  ,MAXSTKCNTOVERODERDIVRF" + Environment.NewLine;
                            sqlText += "  ,SHELFNODUPLDIVRF" + Environment.NewLine;
                            sqlText += "  ,LOTUSEDIVCDRF" + Environment.NewLine;
                            sqlText += "  ,SECTDSPDIVCDRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@STOCKMOVEFIXCODE" + Environment.NewLine; ;
                            sqlText += "  ,@STOCKPOINTWAY" + Environment.NewLine;
                            sqlText += "  ,@FRACTIONPROCCD" + Environment.NewLine;
                            // --- ADD 2009/12/02 ---------->>>>>
                            // 棚卸運用区分
                            sqlText += "  ,@INVENTORYMNGDIV" + Environment.NewLine;
                            // --- ADD 2009/12/02 ----------<<<<<
                            // ------------------- ADD 2011/08/29 ---------->>>>>
                            // 現在庫表示区分
                            sqlText += "  ,@PRESTCKCNTDSPDIV" + Environment.NewLine;
                            // ------------------- ADD 2011/08/29 ----------<<<<<
                            // ------------------- ADD 2012/06/08 Redmine#30282 ---------->>>>>
                            // 棚卸データ削除区分
                            sqlText += "  ,@INVNTRYDTDELDIV" + Environment.NewLine;
                            // ------------------- ADD 2012/06/08 Redmine#30282 ----------<<<<<
                            // --- ADD 三戸 2012/07/02 ---------->>>>>
                            // 移動時在庫自動登録区分
                            sqlText += "  ,@MOVESTOCKAUTOINSDIV" + Environment.NewLine;
                            // --- ADD 三戸 2012/07/02 ----------<<<<<
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
                            // 移動伝票出力先区分
                            sqlText += "  ,@MOVESLIPOUTPUTDIV" + Environment.NewLine;
                            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
                            sqlText += "  ,@STOCKTOLERNCSHIPMDIV" + Environment.NewLine;
                            sqlText += "  ,@INVNTRYPRTODRINIDIV" + Environment.NewLine;
                            sqlText += "  ,@MAXSTKCNTOVERODERDIV" + Environment.NewLine;
                            sqlText += "  ,@SHELFNODUPLDIV" + Environment.NewLine;
                            sqlText += "  ,@LOTUSEDIVCD" + Environment.NewLine;
                            sqlText += "  ,@SECTDSPDIVCD" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmngttlstWork;
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
                        SqlParameter paraStockMoveFixCode = sqlCommand.Parameters.Add("@STOCKMOVEFIXCODE", SqlDbType.Int);
                        SqlParameter paraStockPointWay = sqlCommand.Parameters.Add("@STOCKPOINTWAY", SqlDbType.Int);
                        SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                        // --- ADD 2009/12/02 ---------->>>>>
                        // 棚卸運用区分
                        SqlParameter paraInventoryMngDiv = sqlCommand.Parameters.Add("@INVENTORYMNGDIV", SqlDbType.Int);
                        // --- ADD 2009/12/02 ----------<<<<<
                        // -------------------- ADD 2011/08/29 -------------------- >>>>>
                        // 現在庫表示区分
                        SqlParameter paraPreStckCntDspDiv = sqlCommand.Parameters.Add("@PRESTCKCNTDSPDIV", SqlDbType.Int);
                        // -------------------- ADD 2011/08/29 -------------------- <<<<<
                        // -------------------- ADD 2012/06/08 Redmine#30282 -------------------- >>>>>
                        // 棚卸データ削除区分
                        SqlParameter paraInvntryDtDelDiv = sqlCommand.Parameters.Add("@INVNTRYDTDELDIV", SqlDbType.Int);
                        // -------------------- ADD 2012/06/08 Redmine#30282 -------------------- <<<<<
                        // --- ADD 三戸 2012/07/02 ---------->>>>>
                        // 移動時在庫自動登録区分
                        SqlParameter paraMoveStockAutoInsDiv = sqlCommand.Parameters.Add("@MOVESTOCKAUTOINSDIV",SqlDbType.Int);
                        // --- ADD 三戸 2012/07/02 ----------<<<<<
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
                        // 移動伝票出力先区分
                        SqlParameter paraMoveSlipOutPutDiv = sqlCommand.Parameters.Add("@MOVESLIPOUTPUTDIV", SqlDbType.Int);
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
                        SqlParameter paraStockTolerncShipmDiv = sqlCommand.Parameters.Add("@STOCKTOLERNCSHIPMDIV", SqlDbType.Int);
                        SqlParameter paraInvntryPrtOdrIniDiv = sqlCommand.Parameters.Add("@INVNTRYPRTODRINIDIV", SqlDbType.Int);
                        SqlParameter paraMaxStkCntOverOderDiv = sqlCommand.Parameters.Add("@MAXSTKCNTOVERODERDIV", SqlDbType.Int);
                        SqlParameter paraShelfNoDuplDiv = sqlCommand.Parameters.Add("@SHELFNODUPLDIV", SqlDbType.Int);
                        SqlParameter paraLotUseDivCd = sqlCommand.Parameters.Add("@LOTUSEDIVCD", SqlDbType.Int);
                        SqlParameter paraSectDspDivCd = sqlCommand.Parameters.Add("@SECTDSPDIVCD", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockmngttlstWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);
                        paraStockMoveFixCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockMoveFixCode);
                        paraStockPointWay.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockPointWay);
                        paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.FractionProcCd);
                        // --- ADD 2009/12/02 ---------->>>>>
                        // 棚卸運用区分
                        paraInventoryMngDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InventoryMngDiv);
                        // --- ADD 2009/12/02 ----------<<<<<
                        // ------------------- ADD 2011/08/29 --------------------- >>>>>
                        // 現在庫表示区分
                        paraPreStckCntDspDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.PreStckCntDspDiv);
                        // ------------------- ADD 2011/08/29 --------------------- <<<<<
                        // ------------------- ADD 2012/06/08 Redmine#30282 --------------------- >>>>>
                        // 棚卸データ削除区分
                        paraInvntryDtDelDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InvntryDtDelDiv);
                        // ------------------- ADD 2012/06/08 Redmine#30282 --------------------- <<<<<
                        // --- ADD 三戸 2012/07/02 ---------->>>>>
                        // 移動時在庫自動登録区分
                        paraMoveStockAutoInsDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.MoveStockAutoInsDiv);
                        // --- ADD 三戸 2012/07/02 ----------<<<<<
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
                        // 移動伝票出力先区分
                        paraMoveSlipOutPutDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.MoveSlipOutPutDiv);
                        // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
                        paraStockTolerncShipmDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockTolerncShipmDiv);
                        paraInvntryPrtOdrIniDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InvntryPrtOdrIniDiv);
                        paraMaxStkCntOverOderDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.MaxStkCntOverOderDiv);
                        paraShelfNoDuplDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.ShelfNoDuplDiv);
                        paraLotUseDivCd.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.LotUseDivCd);
                        paraSectDspDivCd.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.SectDspDivCd);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmngttlstWork);
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockmngttlstWorkList = al;

            return status;
        }

        // DEL yangyi 2012/06/13 Redmine#30437 ------------->>>>>
        /// <summary>
        /// 全社共通項目を更新する
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2009/12/02 朱俊成 棚卸運用区分の追加</br>
        //private int UpdateAllSecStockMngTtlSt(ref ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    SqlCommand sqlCommand = null;
        //    ArrayList al = new ArrayList();
        //    try
        //    {
        //        if (stockmngttlstWorkList != null)
        //        {
        //            StockMngTtlStWork stockmngttlstWork = stockmngttlstWorkList[0] as StockMngTtlStWork;

        //            sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
        //            # region 更新時のSQL文生成
        //            string sqlText = string.Empty;
        //            sqlText += "UPDATE STOCKMNGTTLSTRF SET " + Environment.NewLine;
        //            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
        //            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
        //            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
        //            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
        //            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
        //            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
        //            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
        //            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
        //            sqlText += " , STOCKMOVEFIXCODERF=@STOCKMOVEFIXCODE" + Environment.NewLine;
        //            sqlText += " , STOCKPOINTWAYRF=@STOCKPOINTWAY" + Environment.NewLine;
        //            sqlText += " , FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
        //            // --- ADD 2009/12/02 ---------->>>>>
        //            // 棚卸運用区分
        //            sqlText += " , INVENTORYMNGDIVRF=@INVENTORYMNGDIV" + Environment.NewLine;
        //            // --- ADD 2009/12/02 ----------<<<<<
        //            // ------------- ADD 2011/08/29 ---------------- >>>>>
        //            // 現在庫表示区分
        //            sqlText += " , PRESTCKCNTDSPDIVRF=@PRESTCKCNTDSPDIV" + Environment.NewLine;
        //            // ------------- ADD 2011/08/29 ---------------- <<<<<
        //            // ------------- ADD 2012/06/07 ---------------- >>>>>
        //            // 棚卸データ削除区分
        //            sqlText += " , INVNTRYDTDELDIVRF=@INVNTRYDTDELDIV" + Environment.NewLine;
        //            // ------------- ADD 2012/06/07 ---------------- <<<<<
        //            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;//DEL 2012/06/07
        //            sqlText += "  AND SECTIONCODERF<>'00'" + Environment.NewLine;
        //            sqlCommand.CommandText = sqlText;

        //            //更新ヘッダ情報を設定
        //            object obj = (object)this;
        //            IFileHeader flhd = (IFileHeader)stockmngttlstWork;
        //            FileHeader fileHeader = new FileHeader(obj);
        //            fileHeader.SetUpdateHeader(ref flhd, obj);
        //            #endregion

        //            #region Parameterオブジェクトの作成(更新用)
        //            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
        //            //SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);// DEL 2012/06/07
        //            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
        //            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
        //            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
        //            SqlParameter paraStockMoveFixCode = sqlCommand.Parameters.Add("@STOCKMOVEFIXCODE", SqlDbType.Int);
        //            SqlParameter paraStockPointWay = sqlCommand.Parameters.Add("@STOCKPOINTWAY", SqlDbType.Int);
        //            SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
        //            // --- ADD 2009/12/02 ---------->>>>>
        //            // 棚卸運用区分
        //            SqlParameter paraInventoryMngDiv = sqlCommand.Parameters.Add("@INVENTORYMNGDIV", SqlDbType.Int);
        //            // --- ADD 2009/12/02 ----------<<<<<
        //            // -------------------- ADD 2011/08/29 -------------------- >>>>>
        //            // 現在庫表示区分
        //            SqlParameter paraPreStckCntDspDiv = sqlCommand.Parameters.Add("@PRESTCKCNTDSPDIV", SqlDbType.Int);
        //            // -------------------- ADD 2011/08/29 -------------------- <<<<<
        //            // -------------------- ADD 2012/06/07 -------------------- >>>>>
        //            // 棚卸データ削除区分
        //            SqlParameter paraInvntryDtDelDiv = sqlCommand.Parameters.Add("@INVNTRYDTDELDIV", SqlDbType.Int);
        //            // -------------------- ADD 2012/06/07 -------------------- <<<<<
        //            #endregion

        //            #region Parameterオブジェクトへ値設定(更新用)
        //            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.CreateDateTime);
        //            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.UpdateDateTime);
        //            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
        //            //paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockmngttlstWork.FileHeaderGuid);// DEL 2012/06/07
        //            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdEmployeeCode);
        //            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId1);
        //            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId2);
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.LogicalDeleteCode);
        //            paraStockMoveFixCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockMoveFixCode);
        //            paraStockPointWay.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.StockPointWay);
        //            paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.FractionProcCd);
        //            // --- ADD 2009/12/02 ---------->>>>>
        //            // 棚卸運用区分
        //            paraInventoryMngDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InventoryMngDiv);
        //            // --- ADD 2009/12/02 ----------<<<<<
        //            // ------------------- ADD 2011/08/29 --------------------- >>>>>
        //            // 現在庫表示区分
        //            paraPreStckCntDspDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.PreStckCntDspDiv);
        //            // ------------------- ADD 2011/08/29 --------------------- <<<<<
        //            // ------------------- ADD 2012/06/07 --------------------- >>>>>
        //            // 棚卸データ削除区分
        //            paraInvntryDtDelDiv.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.InvntryDtDelDiv);
        //            // ------------------- ADD 2012/06/07 --------------------- <<<<<
        //            #endregion

        //            sqlCommand.ExecuteNonQuery();

        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }

        //    return status;
        //}
        // DEL yangyi 2012/06/13 Redmine#30437 -------------<<<<<
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 在庫管理全体設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int LogicalDelete(ref object stockmngttlstWork)
        {
            return LogicalDeleteStockMngTtlSt(ref stockmngttlstWork, 0);
        }

        /// <summary>
        /// 論理削除在庫管理全体設定マスタ情報を復活します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除在庫管理全体設定マスタ情報を復活します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int RevivalLogicalDelete(ref object stockmngttlstWork)
        {
            return LogicalDeleteStockMngTtlSt(ref stockmngttlstWork, 1);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private int LogicalDeleteStockMngTtlSt(ref object stockmngttlstWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(stockmngttlstWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteStockMngTtlStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "StockMngTtlStDB.LogicalDeleteStockMngTtlSt :" + procModestr);

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
        /// 在庫管理全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int LogicalDeleteStockMngTtlStProc(ref ArrayList stockmngttlstWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteStockMngTtlStProcProc(ref stockmngttlstWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private int LogicalDeleteStockMngTtlStProcProc(ref ArrayList stockmngttlstWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockmngttlstWorkList != null)
                {
                    for (int i = 0; i < stockmngttlstWorkList.Count; i++)
                    {
                        StockMngTtlStWork stockmngttlstWork = stockmngttlstWorkList[i] as StockMngTtlStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM STOCKMNGTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockmngttlstWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE STOCKMNGTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmngttlstWork;
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
                            else if (logicalDelCd == 0) stockmngttlstWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else stockmngttlstWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockmngttlstWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmngttlstWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmngttlstWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmngttlstWork);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockmngttlstWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 在庫管理全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">在庫管理全体設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
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

                status = DeleteStockMngTtlStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "StockMngTtlStDB.Delete");
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
        /// 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">在庫管理全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        public int DeleteStockMngTtlStProc(ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteStockMngTtlStProcProc(stockmngttlstWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">在庫管理全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫管理全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private int DeleteStockMngTtlStProcProc(ArrayList stockmngttlstWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < stockmngttlstWorkList.Count; i++)
                {
                    StockMngTtlStWork stockmngttlstWork = stockmngttlstWorkList[i] as StockMngTtlStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM STOCKMNGTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockmngttlstWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM STOCKMNGTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

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
	    /// <param name="stockmngttlstWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMngTtlStWork stockmngttlstWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "STK.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(stockmngttlstWork.SectionCode) == false)
            {
                retstring += "AND STK.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockmngttlstWork.SectionCode);
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND STK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND STK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        /// <br>Update Note: 2012/06/08 lanl</br>
        /// <br>             #Redmine30282 「棚卸データ削除区分」をに追加　</br>
        /// <br>Update Note: 2012/07/02 三戸　伸悟</br>
        /// <br>             「移動時在庫自動登録区分」を画面に追加　</br>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>           : Redmine#43854画面に列「移動伝票出力先区分」追加</br>
        /// </remarks>
        private StockMngTtlStWork CopyToStockMngTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            StockMngTtlStWork wkStockMngTtlStWork = new StockMngTtlStWork();

            #region クラスへ格納
            wkStockMngTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockMngTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockMngTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockMngTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockMngTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockMngTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockMngTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockMngTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockMngTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockMngTtlStWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStockMngTtlStWork.StockMoveFixCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFIXCODE"));
            wkStockMngTtlStWork.StockPointWay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKPOINTWAYRF"));
            wkStockMngTtlStWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            // --- ADD 2009/12/02 ---------->>>>>
            // 棚卸運用区分
            wkStockMngTtlStWork.InventoryMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYMNGDIVRF"));
            // --- ADD 2009/12/02 ----------<<<<<
            // ---------------------- ADD 2011/08/29 ----------------------- >>>>>
            // 現在庫表示区分
            wkStockMngTtlStWork.PreStckCntDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRESTCKCNTDSPDIVRF"));
            // ---------------------- ADD 2011/08/29 ----------------------- <<<<<
            // ---------------------- ADD 2012/06/08 Redmine#30282 ----------------------- >>>>>
            // 棚卸データ削除区分
            wkStockMngTtlStWork.InvntryDtDelDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVNTRYDTDELDIVRF"));
            // ---------------------- ADD 2012/06/08 Redmine#30282 ----------------------- <<<<<
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            wkStockMngTtlStWork.MoveStockAutoInsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTOCKAUTOINSDIVRF"));
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加--------->>>>
            // 移動伝票出力先区分
            wkStockMngTtlStWork.MoveSlipOutPutDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESLIPOUTPUTDIVRF"));
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 列「移動伝票出力先区分」追加---------<<<<
            wkStockMngTtlStWork.StockTolerncShipmDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKTOLERNCSHIPMDIVRF"));
            wkStockMngTtlStWork.InvntryPrtOdrIniDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVNTRYPRTODRINIDIVRF"));
            wkStockMngTtlStWork.MaxStkCntOverOderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAXSTKCNTOVERODERDIVRF"));
            wkStockMngTtlStWork.ShelfNoDuplDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHELFNODUPLDIVRF"));
            wkStockMngTtlStWork.LotUseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOTUSEDIVCDRF"));
            wkStockMngTtlStWork.SectDspDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTDSPDIVCDRF"));
            #endregion

            return wkStockMngTtlStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockMngTtlStWork[] StockMngTtlStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is StockMngTtlStWork)
                    {
                        StockMngTtlStWork wkStockMngTtlStWork = paraobj as StockMngTtlStWork;
                        if (wkStockMngTtlStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockMngTtlStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockMngTtlStWorkArray = (StockMngTtlStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockMngTtlStWork[]));
                        }
                        catch (Exception) { }
                        if (StockMngTtlStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockMngTtlStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockMngTtlStWork wkStockMngTtlStWork = (StockMngTtlStWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockMngTtlStWork));
                                if (wkStockMngTtlStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockMngTtlStWork);
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
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.02</br>
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
    }
}
