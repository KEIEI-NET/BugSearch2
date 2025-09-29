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
    /// 操作履歴ログデータDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 操作履歴ログデータの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.07.24</br>
    /// <br></br>
    /// <br>Update Note: 書込み処理(Write)の重複チェック処理削除 </br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.22</br>
    /// <br></br>
    /// <br>Update Note: 抽出不具合修正 </br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.05</br>
    /// <br></br>
    /// <br>Update Note: 書込不具合修正 </br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br></br>
    /// <br>Update Note: DSPログ、通信ログデータ照会の抽出で端末番号は完全一致で抽出するように修正 </br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2011/02/24</br>
    /// <br></br>
    /// <br>Update Note: 照会プログラムのログ出力機能対応 </br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2011/03/18</br>
    /// <br></br>
    /// <br>Update Note: #24648 論理削除の排他検索処理修正 </br>
    /// <br>Programmer : 孫　東響</br>
    /// <br>Date       : 2011/09/13</br>
    /// <br>Update Note: K2016/10/28 時シン</br>
    /// <br>管理番号   : 11202046-00</br>
    /// <br>           : 神姫産業㈱ 時刻検索条件の追加</br>
    /// <br>Update Note: 2021/12/15  陳艶丹</br>
    /// <br>管理番号   : 11770181-00</br>
    /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OprtnHisLogDB : RemoteDB, IOprtnHisLogDB
    {
        /// <summary>
        /// 操作履歴ログデータDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        /// <br></br>
        /// <br>Update Note: 書込み処理(Write)の重複チェック処理削除 </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.22</br>
        /// <br></br>
        /// <br>Update Note: 抽出不具合修正 </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.05</br>
        /// <br></br>
        /// <br>Update Note: 書込不具合修正 </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.12.02</br>
        /// <br>Update Note: K2016/10/28 時シン</br>
        /// <br>管理番号   : 11202046-00</br>
        /// <br>           : 神姫産業㈱ 時刻検索条件の追加</br>
        /// <br>Update Note: 2021/12/15  陳艶丹</br>
        /// <br>管理番号   : 11770181-00</br>
        /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        public OprtnHisLogDB() : base("MACMN00116D", "Broadleaf.Application.Remoting.ParamData.OprtnHisLogWork", "OPRTNHISLOGRF")
        {
        }

        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
        #region Const members
        private const long CT_TICKSPERDAY = 864000000000;
        private const long CT_TICKSPERSEC = 10000000;
        #endregion
        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<

        #region [Read]
        /// <summary>
        /// 指定された条件の操作履歴ログデータを戻します
        /// </summary>
        /// <param name="oprtnHisLogWork">oprtnHisLogResultWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int Read(ref object oprtnHisLogWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (oprtnHisLogWork == null) return status;

                //パラメータのキャスト
                OprtnHisLogWork oprtnhisLogWork = oprtnHisLogWork as OprtnHisLogWork;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Read実行
                status = this.ReadProc(ref oprtnhisLogWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Read");
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
        /// 指定された条件の操作履歴ログデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="oprtnHislogWork">OprtnHisLogWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int ReadProc(ref OprtnHisLogWork oprtnHislogWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref oprtnHislogWork, readMode, ref sqlConnection);
        }
        /// <summary>
        /// 指定された条件の操作履歴ログデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="oprtnHislogWork">OprtnHisLogWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        private int ReadProcProc(ref OprtnHisLogWork oprtnHislogWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Selectコマンドの生成
                #region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,LOGDATACREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAGUIDRF" + Environment.NewLine;
                sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJCLASSIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMASSAGERF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                //Prameterオブジェクトの作成
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogDataCreateDateTime = sqlCommand.Parameters.Add("@FINDLOGDATACREATEDATETIME", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnHislogWork.EnterpriseCode);
                findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnHislogWork.LogDataCreateDateTime);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    oprtnHislogWork = CopyToOprtnHisLogWorkFromReader(ref myReader);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
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
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

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

        #region [Search]
        /// <summary>
        /// 指定された条件の操作履歴ログデータ情報LISTを戻します
        /// </summary>
        /// <param name="oprtnHisLogWork">検索結果</param>
        /// <param name="paraoprtnHisLogSrchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータ情報LISTを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int Search(ref object oprtnHisLogWork, object paraoprtnHisLogSrchWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (paraoprtnHisLogSrchWork == null) return status;

                //パラメータのキャスト
                ArrayList oprtnHisLogArray = oprtnHisLogWork as ArrayList;
                if (oprtnHisLogArray == null)
                {
                    oprtnHisLogArray = new ArrayList();
                }

                OprtnHisLogSrchWork oprtnHisLogSrchWork = paraoprtnHisLogSrchWork as OprtnHisLogSrchWork;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search実行
                status = SearchOprtnHisLogProc(ref oprtnHisLogArray, oprtnHisLogSrchWork, readMode, logicalMode, ref sqlConnection);
                oprtnHisLogWork = oprtnHisLogArray;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Search");
                oprtnHisLogWork = new ArrayList();
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

        /// <summary>
        /// 指定された条件の操作履歴ログデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="oprtnHisLogWork">検索結果</param>
        /// <param name="paraoprtnHisLogSrchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int SearchOprtnHisLogProc(ref object oprtnHisLogWork, OprtnHisLogSrchWork paraoprtnHisLogSrchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            oprtnHisLogWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                status = SearchOprtnHisLogProc(ref al, paraoprtnHisLogSrchWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.SearchOprtnHisLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            oprtnHisLogWork = al;
            
            return status;
        }

        /// <summary>
        /// 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="oprtnHisLogSrchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int SearchOprtnHisLogProc(ref ArrayList al, OprtnHisLogSrchWork oprtnHisLogSrchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchOprtnHisLogProcProc(ref al, oprtnHisLogSrchWork, readMode, logicalMode, ref sqlConnection);
        }
        /// <summary>
        /// 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="oprtnHisLogSrchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        private int SearchOprtnHisLogProcProc(ref ArrayList al, OprtnHisLogSrchWork oprtnHisLogSrchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Selectコマンドの生成
                #region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,LOGDATACREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAGUIDRF" + Environment.NewLine;
                sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJCLASSIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMASSAGERF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                //----- UPD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
                //sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                //
                //sqlCommand.CommandText = sqlText;
                ////WHERE句
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, oprtnHisLogSrchWork, logicalMode);
                if (!oprtnHisLogSrchWork.TimeSearchFlag)
                {
                    //検索条件－時刻を追加しない場合、既存通りのSQLを生成
                    sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    //WHERE句
                    sqlCommand.CommandText += MakeWhereString( ref sqlCommand, oprtnHisLogSrchWork, logicalMode );
                }
                else
                {
                    //検索条件－時刻を追加する場合、サブクエリで既存通りの取得を行った上で時刻抽出するSQLを生成
                    StringBuilder subQuelyStrings = new StringBuilder();
                    string subQuelyAsName = "OPLOG";

                    subQuelyStrings.AppendLine( " FROM (" );
                    subQuelyStrings.AppendLine( " SELECT * FROM OPRTNHISLOGRF" );
                    subQuelyStrings.AppendLine( MakeWhereString( ref sqlCommand, oprtnHisLogSrchWork, logicalMode ) );
                    subQuelyStrings.AppendLine( " ) AS " + subQuelyAsName + " " );

                    sqlCommand.CommandText = sqlText + subQuelyStrings.ToString();
                    //WHERE句
                    sqlCommand.CommandText += MakeTimeSpanWhereString( ref sqlCommand, oprtnHisLogSrchWork, subQuelyAsName );
                }
                //----- UPD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToOprtnHisLogWorkFromReader(ref myReader));

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
                }
            }

            return status;
        }
        #endregion

        #region [SearchUOE]
        /// <summary>
        /// 指定された条件の操作履歴ログデータ情報LISTを戻します
        /// </summary>
        /// <param name="oprtnHisLogWork">検索結果</param>
        /// <param name="paraoprationLogOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータ情報LISTを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int SearchUOE(ref object oprtnHisLogWork, object paraoprationLogOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (paraoprationLogOrderWork == null) return status;

                //パラメータのキャスト
                ArrayList oprtnHisLogArray = oprtnHisLogWork as ArrayList;
                if (oprtnHisLogArray == null)
                {
                    oprtnHisLogArray = new ArrayList();
                }

                OprationLogOrderWork oprationLogOrderWork = paraoprationLogOrderWork as OprationLogOrderWork;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search実行
                status = SearchUOEProc(ref oprtnHisLogArray, oprationLogOrderWork, readMode, logicalMode, ref sqlConnection);
                oprtnHisLogWork = oprtnHisLogArray;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Search");
                oprtnHisLogWork = new ArrayList();
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

        /// <summary>
        /// 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="oprationLogOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int SearchUOEProc(ref ArrayList al, OprationLogOrderWork oprationLogOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchUOEProcProc(ref al, oprationLogOrderWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="oprationLogOrderWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の操作履歴ログデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        private int SearchUOEProcProc(ref ArrayList al, OprationLogOrderWork oprationLogOrderWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Selectコマンドの生成
                #region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,LOGDATACREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAGUIDRF" + Environment.NewLine;
                sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJCLASSIDRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                sqlText += " ,LOGDATAMASSAGERF" + Environment.NewLine;
                sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                //WHERE句
                sqlCommand.CommandText += MakeUOEWhereString(ref sqlCommand, oprationLogOrderWork, logicalMode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToOprtnHisLogWorkFromReader(ref myReader));

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
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 操作履歴ログデータ情報を登録、更新します
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報を登録、更新します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int Write(ref object oprtnHisLogWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (oprtnHisLogWork == null) return status;

                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(oprtnHisLogWork);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteOprtnHisLogProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    //ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                oprtnHisLogWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Write(ref object oprtnHisLogWork)");
                //ロールバック
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
        /// 操作履歴ログデータ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="oprtnHisLogWorkList">OprtnHisLogWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int WriteOprtnHisLogProc(ref ArrayList oprtnHisLogWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteOprtnHisLogProcProc(ref oprtnHisLogWorkList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 操作履歴ログデータ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="oprtnHisLogWorkList">OprtnHisLogWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        private int WriteOprtnHisLogProcProc(ref ArrayList oprtnHisLogWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (oprtnHisLogWorkList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < oprtnHisLogWorkList.Count; i++)
                    {
                        OprtnHisLogWork oprtnhislogWork = oprtnHisLogWorkList[i] as OprtnHisLogWork;
                        sqlCommand.Parameters.Clear(); // ADD 2008.12.02
                        // DEL 2008.10.22 >>>
                        #region
                        /*
                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaLogDataCreateDateTime = sqlCommand.Parameters.Add("@FINDLOGDATACREATEDATETIME", SqlDbType.BigInt);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                        findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時
                            
                            if (_updateDateTime != oprtnhislogWork.UpdateDateTime)
                            {
                                
                                //新規登録で該当データ有りの場合には重複
                                if (oprtnhislogWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                //既存データで更新日時違いの場合には排他
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }
                                
                                sqlCommand.Cancel();

                                if (myReader.IsClosed == false) myReader.Close();
                                
                                return status;
                            }
                            
                            

                            //Updateコマンドの生成
                            #region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += " SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,LOGDATACREATEDATETIMERF=@LOGDATACREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,LOGDATAGUIDRF=@LOGDATAGUID" + Environment.NewLine;
                            sqlText += " ,LOGINSECTIONCDRF=@LOGINSECTIONCD" + Environment.NewLine;
                            sqlText += " ,LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;
                            sqlText += " ,LOGDATAMACHINENAMERF=@LOGDATAMACHINENAME" + Environment.NewLine;
                            sqlText += " ,LOGDATAAGENTCDRF=@LOGDATAAGENTCD" + Environment.NewLine;
                            sqlText += " ,LOGDATAAGENTNMRF=@LOGDATAAGENTNM" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF=@LOGDATAOBJBOOTPROGRAMNM" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJASSEMBLYIDRF=@LOGDATAOBJASSEMBLYID" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJASSEMBLYNMRF=@LOGDATAOBJASSEMBLYNM" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJCLASSIDRF=@LOGDATAOBJCLASSID" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJPROCNMRF=@LOGDATAOBJPROCNM" + Environment.NewLine;
                            sqlText += " ,LOGDATAOPERATIONCDRF=@LOGDATAOPERATIONCD" + Environment.NewLine;
                            sqlText += " ,LOGOPERATERDTPROCLVLRF=@LOGOPERATERDTPROCLVL" + Environment.NewLine;
                            sqlText += " ,LOGOPERATERFUNCLVLRF=@LOGOPERATERFUNCLVL" + Environment.NewLine;
                            sqlText += " ,LOGDATASYSTEMVERSIONRF=@LOGDATASYSTEMVERSION" + Environment.NewLine;
                            sqlText += " ,LOGOPERATIONSTATUSRF=@LOGOPERATIONSTATUS" + Environment.NewLine;
                            sqlText += " ,LOGDATAMASSAGERF=@LOGDATAMASSAGE" + Environment.NewLine;
                            sqlText += " ,LOGOPERATIONDATARF=@LOGOPERATIONDATA" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                            findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)oprtnhislogWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (oprtnhislogWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                         */
                        #endregion
                        // DEL 2008.10.22 <<<

                        //Insertコマンドの生成
                        #region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,LOGDATACREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,LOGDATAGUIDRF" + Environment.NewLine;
                            sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                            sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJCLASSIDRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                            sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                            sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                            sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                            sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                            sqlText += " ,LOGDATAMASSAGERF" + Environment.NewLine;
                            sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@LOGDATACREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@LOGDATAGUID" + Environment.NewLine;
                            sqlText += " ,@LOGINSECTIONCD" + Environment.NewLine;
                            sqlText += " ,@LOGDATAKINDCD" + Environment.NewLine;
                            sqlText += " ,@LOGDATAMACHINENAME" + Environment.NewLine;
                            sqlText += " ,@LOGDATAAGENTCD" + Environment.NewLine;
                            sqlText += " ,@LOGDATAAGENTNM" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJBOOTPROGRAMNM" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJASSEMBLYID" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJASSEMBLYNM" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJCLASSID" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOBJPROCNM" + Environment.NewLine;
                            sqlText += " ,@LOGDATAOPERATIONCD" + Environment.NewLine;
                            sqlText += " ,@LOGOPERATERDTPROCLVL" + Environment.NewLine;
                            sqlText += " ,@LOGOPERATERFUNCLVL" + Environment.NewLine;
                            sqlText += " ,@LOGDATASYSTEMVERSION" + Environment.NewLine;
                            sqlText += " ,@LOGOPERATIONSTATUS" + Environment.NewLine;
                            sqlText += " ,@LOGDATAMASSAGE" + Environment.NewLine;
                            sqlText += " ,@LOGOPERATIONDATA" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)oprtnhislogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        //} // DEL 2008.10.22 

                        //if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraLogDataCreateDateTime = sqlCommand.Parameters.Add("@LOGDATACREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraLogDataGuid = sqlCommand.Parameters.Add("@LOGDATAGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraLoginSectionCd = sqlCommand.Parameters.Add("@LOGINSECTIONCD", SqlDbType.NChar);
                        SqlParameter paraLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);
                        SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                        SqlParameter paraLogDataAgentCd = sqlCommand.Parameters.Add("@LOGDATAAGENTCD", SqlDbType.NChar);
                        SqlParameter paraLogDataAgentNm = sqlCommand.Parameters.Add("@LOGDATAAGENTNM", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjBootProgramNm = sqlCommand.Parameters.Add("@LOGDATAOBJBOOTPROGRAMNM", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjAssemblyID = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjAssemblyNm = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYNM", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjClassID = sqlCommand.Parameters.Add("@LOGDATAOBJCLASSID", SqlDbType.NVarChar);
                        SqlParameter paraLogDataObjProcNm = sqlCommand.Parameters.Add("@LOGDATAOBJPROCNM", SqlDbType.NVarChar);
                        SqlParameter paraLogDataOperationCd = sqlCommand.Parameters.Add("@LOGDATAOPERATIONCD", SqlDbType.Int);
                        SqlParameter paraLogOperaterDtProcLvl = sqlCommand.Parameters.Add("@LOGOPERATERDTPROCLVL", SqlDbType.NVarChar);
                        SqlParameter paraLogOperaterFuncLvl = sqlCommand.Parameters.Add("@LOGOPERATERFUNCLVL", SqlDbType.NVarChar);
                        SqlParameter paraLogDataSystemVersion = sqlCommand.Parameters.Add("@LOGDATASYSTEMVERSION", SqlDbType.NVarChar);
                        SqlParameter paraLogOperationStatus = sqlCommand.Parameters.Add("@LOGOPERATIONSTATUS", SqlDbType.Int);
                        SqlParameter paraLogDataMassage = sqlCommand.Parameters.Add("@LOGDATAMASSAGE", SqlDbType.NVarChar);
                        SqlParameter paraLogOperationData = sqlCommand.Parameters.Add("@LOGOPERATIONDATA", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(oprtnhislogWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogicalDeleteCode);
                        paraLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);
                        paraLoginSectionCd.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LoginSectionCd);
                        paraLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogDataKindCd);
                        paraLogDataMachineName.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataMachineName);
                        paraLogDataAgentCd.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataAgentCd);
                        paraLogDataAgentNm.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataAgentNm);
                        paraLogDataObjBootProgramNm.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjBootProgramNm);
                        paraLogDataObjAssemblyID.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjAssemblyID);
                        paraLogDataObjAssemblyNm.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjAssemblyNm);
                        paraLogDataObjClassID.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjClassID);
                        paraLogDataObjProcNm.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataObjProcNm);
                        paraLogDataOperationCd.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogDataOperationCd);
                        paraLogOperaterDtProcLvl.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogOperaterDtProcLvl);
                        paraLogOperaterFuncLvl.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogOperaterFuncLvl);
                        paraLogDataSystemVersion.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataSystemVersion);
                        paraLogOperationStatus.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogOperationStatus);
                        paraLogDataMassage.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogDataMassage);
                        paraLogOperationData.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.LogOperationData);

                        //ログデータGUID
                        Guid guidValue = Guid.NewGuid();
                        paraLogDataGuid.Value = guidValue;
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(oprtnhislogWork);
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
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            oprtnHisLogWorkList = al;

            return status;
        }
        // --- ADD m.suzuki 2011/03/18 ---------->>>>>
        # region [照会用]
        // --- ADD m.suzuki 2011/04/05 ---------->>>>>
        /// <summary>
        /// 照会用操作履歴ログ書き込み処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="pgName"></param>
        /// <param name="message"></param>
        public void WriteOprtnHisLogForReference( ref SqlConnection sqlConnection, string enterpriseCode, string pgName, string message )
        {
            // ログに書き込むIDが未指定の場合、照会共通として"DCCMN04000U"とする。
            WriteOprtnHisLogForReference( ref sqlConnection, enterpriseCode, pgName, message, "DCCMN04000U", 0 );
        }
        // --- ADD m.suzuki 2011/04/05 ----------<<<<<
        /// <summary>
        /// 照会用操作履歴ログ書き込み処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="pgName"></param>
        /// <param name="message"></param>
        /// <param name="logDataObjAssemblyID"></param>
        /// <param name="logDataOperationCd"></param>
        // --- UPD m.suzuki 2011/04/05 ---------->>>>>
        //public void WriteOprtnHisLogForReference( ref SqlConnection sqlConnection, string enterpriseCode, string pgName, string message )
        public void WriteOprtnHisLogForReference( ref SqlConnection sqlConnection, string enterpriseCode, string pgName, string message, string logDataObjAssemblyID, int logDataOperationCd )
        // --- UPD m.suzuki 2011/04/05 ----------<<<<<
        {
            SqlTransaction sqlTransaction = null;
            try
            {
                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction( (IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default );

                ArrayList writeList = new ArrayList();
                OprtnHisLogWork oprtnhislogWork = new OprtnHisLogWork();
                # region [書き込み内容のセット]
                Broadleaf.Library.Diagnostics.LogTextData logTextData = new Broadleaf.Library.Diagnostics.LogTextData( "", "", 0, new Exception() );
                oprtnhislogWork.EnterpriseCode = enterpriseCode;
                // --- UPD m.suzuki 2011/04/05 ---------->>>>>
                //oprtnhislogWork.LogDataObjAssemblyID = "DCCMN04000U";
                oprtnhislogWork.LogDataObjAssemblyID = logDataObjAssemblyID;
                // --- UPD m.suzuki 2011/04/05 ----------<<<<<
                oprtnhislogWork.LogDataObjAssemblyNm = pgName;
                oprtnhislogWork.LogDataObjClassID = this.GetType().Name;
                // --- UPD m.suzuki 2010/00/00 ---------->>>>>
                //oprtnhislogWork.LogDataOperationCd = 0;
                oprtnhislogWork.LogDataOperationCd = logDataOperationCd;
                // --- UPD m.suzuki 2010/00/00 ----------<<<<<
                oprtnhislogWork.LogDataMassage = message;
                oprtnhislogWork.LogDataCreateDateTime = DateTime.Now;
                oprtnhislogWork.LogDataMachineName = logTextData.ClientAuthInfoWork.MachineUserId;
                oprtnhislogWork.LogDataAgentCd = logTextData.EmployeeAuthInfoWork.EmployeeWork.EmployeeCode;
                oprtnhislogWork.LogDataAgentNm = logTextData.EmployeeAuthInfoWork.EmployeeWork.Name;
                oprtnhislogWork.LoginSectionCd = logTextData.EmployeeAuthInfoWork.EmployeeWork.BelongSectionCode;
                oprtnhislogWork.LogOperaterDtProcLvl = logTextData.EmployeeAuthInfoWork.EmployeeWork.AuthorityLevel1.ToString();
                oprtnhislogWork.LogOperaterFuncLvl = logTextData.EmployeeAuthInfoWork.EmployeeWork.AuthorityLevel2.ToString();
                # endregion
                writeList.Add( oprtnhislogWork );

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogProc( ref writeList, ref sqlConnection, ref sqlTransaction );

                //コミット
                sqlTransaction.Commit();
            }
            catch
            {
            }
            if ( sqlTransaction != null ) sqlTransaction.Dispose();
        }
        /// <summary>
        /// クライアントアセンブリチェック処理
        /// </summary>
        /// <param name="pgid"></param>
        public bool CheckClientAssemblyId( string pgid )
        {
            try
            {
                return this.GetClientAssemblyId().Contains( pgid );
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// クライアントアセンブリＩＤ取得処理
        /// </summary>
        /// <returns></returns>
        public string GetClientAssemblyId()
        {
            try
            {
                Broadleaf.Library.Diagnostics.LogTextData logTextData = new Broadleaf.Library.Diagnostics.LogTextData( "", "", 0, new Exception() );
                return logTextData.ClientAuthInfoWork.UpdAssemblyId;
            }
            catch
            {
                return string.Empty;
            }
        }
        # endregion
        // --- ADD m.suzuki 2011/03/18 ----------<<<<<
        #endregion

        #region [Delete]
        /// <summary>
        /// 操作履歴ログデータ情報を物理削除します
        /// </summary>
        /// <param name="oprtnHisLogWork">操作履歴ログデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 操作履歴ログデータ情報を物理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int Delete(object oprtnHisLogWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (oprtnHisLogWork == null) return status;

                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(oprtnHisLogWork);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Delete実行
                status = DeleteOprtnHisLogProc(paraList, ref sqlConnection, ref sqlTransaction);
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    //ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Delete");
                //ロールバック
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
        /// 操作履歴ログデータ情報を物理削除します
        /// </summary>
        /// <param name="oprtnhislogWorkList">操作履歴ログデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 操作履歴ログデータ情報を物理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int DeleteOprtnHisLogProc(ArrayList oprtnhislogWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteOprtnHisLogProcProc(oprtnhislogWorkList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 操作履歴ログデータ情報を物理削除します
        /// </summary>
        /// <param name="oprtnhislogWorkList">操作履歴ログデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 操作履歴ログデータ情報を物理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        private int DeleteOprtnHisLogProcProc(ArrayList oprtnhislogWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (oprtnhislogWorkList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < oprtnhislogWorkList.Count; i++)
                    {
                        OprtnHisLogWork oprtnhislogWork = oprtnhislogWorkList[i] as OprtnHisLogWork;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaLogDataCreateDateTime = sqlCommand.Parameters.Add("@FINDLOGDATACREATEDATETIME", SqlDbType.BigInt);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                        findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時
                            
                            if (_updateDateTime != oprtnhislogWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }

                            //Deleteコマンドの生成
                            #region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);
                            findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);
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

        #region [DeleteUOE]
        /// <summary>
        /// 操作履歴ログデータ情報を物理削除します
        /// </summary>
        /// <param name="paraoprationLogOrderWork">操作履歴ログデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 操作履歴ログデータ情報を物理削除します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.12.02</br>
        public int DeleteUOE(object paraoprationLogOrderWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (paraoprationLogOrderWork == null) return status;

                ////パラメータのキャスト
                //ArrayList paraList = CastToArrayListFromPara(oprtnHisLogWork);


                OprationLogOrderWork oprationLogOrderWork = paraoprationLogOrderWork as OprationLogOrderWork;


                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Delete実行
                status = DeleteUOEProc(oprationLogOrderWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    //ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OprtnHisLogDB.Delete");
                //ロールバック
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
        /// 操作履歴ログデータ情報(UOE分)を物理削除します
        /// </summary>
        /// <param name="oprationLogOrderWork">操作履歴ログデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 操作履歴ログデータ情報を物理削除します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.12.02</br>
        public int DeleteUOEProc(OprationLogOrderWork oprationLogOrderWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteUOEProcProc(oprationLogOrderWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 操作履歴ログデータ情報を物理削除します
        /// </summary>
        /// <param name="oprationLogOrderWork">操作履歴ログデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 操作履歴ログデータ情報を物理削除します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.12.02</br>
        private int DeleteUOEProcProc(OprationLogOrderWork oprationLogOrderWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (oprationLogOrderWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    foreach (string seccdstr in oprationLogOrderWork.SectionCodes)
                    {

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND LOGINSECTIONCDRF=@LOGINSECTIONCD" + Environment.NewLine;
                        sqlText += " AND LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaLoginSectionCd = sqlCommand.Parameters.Add("@LOGINSECTIONCD", SqlDbType.NChar);
                        SqlParameter findParaLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.EnterpriseCode);
                        findParaLoginSectionCd.Value = SqlDataMediator.SqlSetString(seccdstr);
                        findParaLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprationLogOrderWork.LogDataKindCd);
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時

                            //if (_updateDateTime != oprtnhislogWork.UpdateDateTime)
                            //{
                            //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            //    sqlCommand.Cancel();
                            //    return status;
                            //}

                            //Deleteコマンドの生成
                            #region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += " AND LOGINSECTIONCDRF=@LOGINSECTIONCD" + Environment.NewLine;
                            sqlText += " AND LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.EnterpriseCode);
                            findParaLoginSectionCd.Value = SqlDataMediator.SqlSetString(seccdstr);
                            findParaLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprationLogOrderWork.LogDataKindCd);

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


        #region [LogicalDelete]
        /// <summary>
        /// 操作履歴ログデータ情報を論理削除します
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報を論理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int LogicalDelete(ref object oprtnHisLogWork)
        {
            return LogicalDeleteOprtnHisLog(ref oprtnHisLogWork, 0);
        }

        /// <summary>
        /// 論理削除操作履歴ログデータ情報を復活します
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除操作履歴ログデータ情報を復活します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int RevivalLogicalDelete(ref object oprtnHisLogWork)
        {
            return LogicalDeleteOprtnHisLog(ref oprtnHisLogWork, 1);
        }

        /// <summary>
        /// 操作履歴ログデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="oprtnHisLogWork">OprtnHisLogWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        private int LogicalDeleteOprtnHisLog(ref object oprtnHisLogWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータチェック
                if (oprtnHisLogWork == null) return status;

                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(oprtnHisLogWork);

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //LogicalDelete実行
                status = LogicalDeleteOprtnHisLogProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    //ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                {
                    procModestr = "LogicalDelete";
                }
                else
                {
                    procModestr = "RevivalLogicalDelete";
                }
                base.WriteErrorLog(ex, "OprtnHisLogDB.LogicalDeleteOprtnHisLog :" + procModestr);

                //ロールバック
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
        /// 操作履歴ログデータ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="oprtnHisLogWorkList">OprtnHisLogWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        public int LogicalDeleteOprtnHisLogProc(ref ArrayList oprtnHisLogWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteOprtnHisLogProcProc(ref oprtnHisLogWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 操作履歴ログデータ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="oprtnHisLogWorkList">OprtnHisLogWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 操作履歴ログデータ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        private int LogicalDeleteOprtnHisLogProcProc(ref ArrayList oprtnHisLogWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            int logicalDelCd = 0;
            ArrayList al = new ArrayList();

            try
            {
                if (oprtnHisLogWorkList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < oprtnHisLogWorkList.Count; i++)
                    {
                        OprtnHisLogWork oprtnhislogWork = oprtnHisLogWorkList[i] as OprtnHisLogWork;

                        //Selectコマンドの生成
                        #region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM OPRTNHISLOGRF" + Environment.NewLine;
                        //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;//DEL 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                        sqlText += " WHERE FILEHEADERGUIDRF=@FINDFILEHEADERGUID" + Environment.NewLine;//ADD 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                        sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);//DEL 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDFILEHEADERGUID", SqlDbType.UniqueIdentifier);//ADD 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                        SqlParameter findParaLogDataCreateDateTime = sqlCommand.Parameters.Add("@FINDLOGDATACREATEDATETIME", SqlDbType.BigInt);

                        //Parameterオブジェクトへ値設定
                        //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);//DEL 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetGuid(oprtnhislogWork.FileHeaderGuid);//ADD 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                        findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時
                            if (_updateDateTime != oprtnhislogWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }

                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //Updateコマンドの生成
                            #region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPRTNHISLOGRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;//DEL 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                            sqlText += " WHERE FILEHEADERGUIDRF=@FINDFILEHEADERGUID" + Environment.NewLine;//ADD 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                            sqlText += " AND LOGDATACREATEDATETIMERF=@FINDLOGDATACREATEDATETIME" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEYコマンドを再設定
                            //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.EnterpriseCode);//DEL 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetGuid(oprtnhislogWork.FileHeaderGuid);//ADD 2011/09/13 sundx #24648 論理削除の排他検索処理修正
                            findParaLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.LogDataCreateDateTime);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)oprtnhislogWork;
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

                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;                         //既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) oprtnhislogWork.LogicalDeleteCode = 1;                  //論理削除フラグをセット
                            else oprtnhislogWork.LogicalDeleteCode = 3;                                         //完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) oprtnhislogWork.LogicalDeleteCode = 0;                       //論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;                 //完全削除はデータなしを戻す
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnhislogWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(oprtnhislogWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(oprtnhislogWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(oprtnhislogWork);
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
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            oprtnHisLogWorkList = al;

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="oprtnHisLogSrchWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        /// <br>Update Note: 23015 森本 大輝</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, OprtnHisLogSrchWork oprtnHisLogSrchWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprtnHisLogSrchWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //ログイン拠点コード
            if (oprtnHisLogSrchWork.LoginSectionCd != null)
            {
                string sectionCdstr = "";
                foreach (string seccdstr in oprtnHisLogSrchWork.LoginSectionCd)
                {
                    if (sectionCdstr != "")
                    {
                        sectionCdstr += ",";
                    }
                    sectionCdstr += "'" + seccdstr + "'";
                }
                if (sectionCdstr != "")
                {
                    retstring += "AND LOGINSECTIONCDRF IN (" + sectionCdstr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //ログデータ作成日時
            retstring += "AND LOGDATACREATEDATETIMERF>=@STLOGDATACREATEDATETIME ";
            SqlParameter paraStLogDataCreateDateTime = sqlCommand.Parameters.Add( "@STLOGDATACREATEDATETIME", SqlDbType.BigInt );
            paraStLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks( oprtnHisLogSrchWork.St_LogDataCreateDateTime );
            //----- UPD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
            //retstring += "AND LOGDATACREATEDATETIMERF<=@EDLOGDATACREATEDATETIME ";
            //SqlParameter paraEdLogDataCreateDateTime = sqlCommand.Parameters.Add("@EDLOGDATACREATEDATETIME", SqlDbType.BigInt);
            //paraEdLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnHisLogSrchWork.Ed_LogDataCreateDateTime);
            if (!oprtnHisLogSrchWork.TimeSearchFlagOverDay)
            {
                retstring += "AND LOGDATACREATEDATETIMERF<=@EDLOGDATACREATEDATETIME ";
                SqlParameter paraEdLogDataCreateDateTime = sqlCommand.Parameters.Add("@EDLOGDATACREATEDATETIME", SqlDbType.BigInt);
                paraEdLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnHisLogSrchWork.Ed_LogDataCreateDateTime);
            }
            else
            {
                //24時間を超える場合、00:00:00～24:00:00で検索する
                retstring += "AND LOGDATACREATEDATETIMERF<@EDLOGDATACREATEDATETIME ";
                SqlParameter paraEdLogDataCreateDateTime = sqlCommand.Parameters.Add("@EDLOGDATACREATEDATETIME", SqlDbType.BigInt);
                paraEdLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprtnHisLogSrchWork.Ed_LogDataCreateDateTime);
            }
            //----- UPD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
            
            //ログデータ種別区分コード
            if (oprtnHisLogSrchWork.LogDataKindCd != -1)
            {
                retstring += " AND LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;
                SqlParameter paraLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);
                paraLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprtnHisLogSrchWork.LogDataKindCd);
            }

            //ログデータ端末名(曖昧検索)
            if (oprtnHisLogSrchWork.LogDataMachineName != "")
            {
                retstring += " AND LOGDATAMACHINENAMERF LIKE @LOGDATAMACHINENAME" + Environment.NewLine;
                SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                paraLogDataMachineName.Value = "%" + SqlDataMediator.SqlSetString(oprtnHisLogSrchWork.LogDataMachineName) + "%"; 
            }

            //ログデータ担当者コード
            if (oprtnHisLogSrchWork.LogDataAgentCd != "")
            {
                retstring += " AND LOGDATAAGENTCDRF=@LOGDATAAGENTCD" + Environment.NewLine;
                SqlParameter paraLogDataAgentCd = sqlCommand.Parameters.Add("@LOGDATAAGENTCD", SqlDbType.NChar);
                paraLogDataAgentCd.Value = SqlDataMediator.SqlSetString(oprtnHisLogSrchWork.LogDataAgentCd);
            }

            //ログデータ対象アセンブリID
            if (oprtnHisLogSrchWork.LogDataObjAssemblyID != "")
            {
                retstring += " AND LOGDATAOBJASSEMBLYIDRF=@LOGDATAOBJASSEMBLYID" + Environment.NewLine;
                SqlParameter paraLogDataObjAssemblyID = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYID", SqlDbType.NVarChar);
                paraLogDataObjAssemblyID.Value = SqlDataMediator.SqlSetString(oprtnHisLogSrchWork.LogDataObjAssemblyID);
            }

            //ログデータオペレーションコード
            // if (oprtnHisLogSrchWork.LogDataOperationCd != 0) // DEL 2008.11.05 
            if (oprtnHisLogSrchWork.LogDataOperationCd != -1) // ADD 2008.11.05
            {
                retstring += " AND LOGDATAOPERATIONCDRF=@LOGDATAOPERATIONCD" + Environment.NewLine;
                SqlParameter paraLogDataOperationCd = sqlCommand.Parameters.Add("@LOGDATAOPERATIONCD", SqlDbType.Int);
                paraLogDataOperationCd.Value = SqlDataMediator.SqlSetInt32(oprtnHisLogSrchWork.LogDataOperationCd);
            }

            return retstring;
        }

        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 ----->>>>>
        /// <summary>
        /// 時刻検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="oprtnHisLogSrchWork">検索条件格納クラス</param>
        /// <param name="subQuelyAsName">サブクエリ名</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 神姫産業㈱個別機能用時刻検索条件作成</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : K2016/10/28</br>
        /// <br>管理番号   : 11202046-00</br>
        /// <br>Update Note: 2021/12/15  陳艶丹</br>
        /// <br>管理番号   : 11770181-00</br>
        /// <br>           : テキスト出力機能追加と時刻検索条件の追加対応</br>
        /// </remarks>
        private string MakeTimeSpanWhereString( ref SqlCommand sqlCommand, OprtnHisLogSrchWork oprtnHisLogSrchWork, string subQuelyAsName)
        {
            StringBuilder whereStrings = new StringBuilder();

            whereStrings.AppendLine(" WHERE ");

            // 検索条件－時刻を追加する
            if (!oprtnHisLogSrchWork.TimeSearchFlag2)
            {
                //通常時間帯のみの場合 ※深夜時間帯のみの場合を含む
                // 時刻抽出条件を追加する
            	whereStrings.AppendFormat("        CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) >= @STSECONDS ", subQuelyAsName);
                whereStrings.AppendLine();
                //----- UPD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 ----->>>>>
                if (!oprtnHisLogSrchWork.TimeSearchFlagOverDay)
                {
                    whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) <= @EDSECONDS ", subQuelyAsName);
                    whereStrings.AppendLine();
                }
                else
                {
                    //24時間を超える場合、00:00:00～24:00:00で検索する
                    whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) < 86400 ", subQuelyAsName);
                    whereStrings.AppendLine();
                }
                //----- UPD 陳艶丹 2021/12/15 テキスト出力機能追加と時刻検索条件の追加対応 -----<<<<<
            }
            else
            {
                //開始時刻＜24:00:00＜終了時刻の（日付を跨ぐ）場合

                whereStrings.AppendLine(" ( ");

                #region //通常時間帯

                whereStrings.AppendFormat("	       {0}.LOGDATACREATEDATETIMERF<@EDLOGDATACREATEDATETIME2 ", subQuelyAsName);
                whereStrings.AppendLine();
            	whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) >= @STSECONDS ", subQuelyAsName);
                whereStrings.AppendLine();
            	whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) < 86400 ", subQuelyAsName);
                whereStrings.AppendLine();

                // 通常時間帯の終了日付のパラメータセット
                SqlParameter paraEdLogDataCreateDateTime2 = sqlCommand.Parameters.Add( "@EDLOGDATACREATEDATETIME2", SqlDbType.BigInt );
                DateTime paramEndDate = oprtnHisLogSrchWork.Ed_LogDataCreateDateTime;
                paramEndDate = paramEndDate.Date;
                paraEdLogDataCreateDateTime2.Value = SqlDataMediator.SqlSetDateTimeFromTicks( paramEndDate );

                #endregion //通常時間帯

                whereStrings.AppendLine(" ) OR ( ");

                #region //深夜時間帯

                whereStrings.AppendFormat("        {0}.LOGDATACREATEDATETIMERF>=@STLOGDATACREATEDATETIME2 ", subQuelyAsName);
                whereStrings.AppendLine();
                whereStrings.AppendFormat("    AND CAST(({0}.LOGDATACREATEDATETIMERF % 864000000000) / 10000000 AS INT) <= @EDSECONDS2 ", subQuelyAsName);
                whereStrings.AppendLine();

                // 深夜時間帯の日付（＋１日）のパラメータセット
                SqlParameter paraStLogDataCreateDateTime2 = sqlCommand.Parameters.Add( "@STLOGDATACREATEDATETIME2", SqlDbType.BigInt );
                DateTime paramStartDate = oprtnHisLogSrchWork.St_LogDataCreateDateTime.AddDays( 1 );
                paramStartDate = paramStartDate.Date;
                paraStLogDataCreateDateTime2.Value = SqlDataMediator.SqlSetDateTimeFromTicks( paramStartDate );

                // 深夜時間帯の終了時刻のパラメータセット
                SqlParameter paraSeconds_Ed2 = sqlCommand.Parameters.Add( "@EDSECONDS2", SqlDbType.Int );
                int edTime2 = oprtnHisLogSrchWork.SearchHourEd2 * 3600 + oprtnHisLogSrchWork.SearchMinuteEd2 * 60 + oprtnHisLogSrchWork.SearchSecondEd2;
                paraSeconds_Ed2.Value = SqlDataMediator.SqlSetInt32( edTime2 );

                #endregion //深夜時間帯

                whereStrings.AppendLine(" ) ");
            }

            SqlParameter paraSeconds_St = sqlCommand.Parameters.Add( "@STSECONDS", SqlDbType.Int );
            SqlParameter paraSeconds_Ed = sqlCommand.Parameters.Add( "@EDSECONDS", SqlDbType.Int );
            int stTime = oprtnHisLogSrchWork.SearchHourSt * 3600 + oprtnHisLogSrchWork.SearchMinuteSt * 60 + oprtnHisLogSrchWork.SearchSecondSt;
            paraSeconds_St.Value = SqlDataMediator.SqlSetInt32( stTime );
            int edTime = oprtnHisLogSrchWork.SearchHourEd * 3600 + oprtnHisLogSrchWork.SearchMinuteEd * 60 + oprtnHisLogSrchWork.SearchSecondEd;
            paraSeconds_Ed.Value = SqlDataMediator.SqlSetInt32( edTime );

            return whereStrings.ToString();
        }
        //----- ADD 時シン K2016/10/28 神姫産業㈱ 時刻検索条件の追加 -----<<<<<
        #endregion

        #region [Where文作成処理 UOE用]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="oprationLogOrderWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        /// <br>Update Note: 23015 森本 大輝</br>
        private string MakeUOEWhereString(ref SqlCommand sqlCommand, OprationLogOrderWork oprationLogOrderWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //ログイン拠点コード
            if (oprationLogOrderWork.SectionCodes != null)
            {
                string sectionCdstr = "";
                foreach (string seccdstr in oprationLogOrderWork.SectionCodes)
                {
                    if (sectionCdstr != "")
                    {
                        sectionCdstr += ",";
                    }
                    sectionCdstr += "'" + seccdstr + "'";
                }
                if (sectionCdstr != "")
                {
                    retstring += "AND LOGINSECTIONCDRF IN (" + sectionCdstr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //ログデータ作成日時
            if (oprationLogOrderWork.St_LogDataCreateDateTime != DateTime.MinValue)
            {
                retstring += "AND LOGDATACREATEDATETIMERF>=@STLOGDATACREATEDATETIME ";
                SqlParameter paraStLogDataCreateDateTime = sqlCommand.Parameters.Add("@STLOGDATACREATEDATETIME", SqlDbType.BigInt);
                paraStLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprationLogOrderWork.St_LogDataCreateDateTime);
            }
            if (oprationLogOrderWork.Ed_LogDataCreateDateTime != DateTime.MinValue)
            {
                retstring += "AND LOGDATACREATEDATETIMERF<@EDLOGDATACREATEDATETIME ";
                SqlParameter paraEdLogDataCreateDateTime = sqlCommand.Parameters.Add("@EDLOGDATACREATEDATETIME", SqlDbType.BigInt);
                paraEdLogDataCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(oprationLogOrderWork.Ed_LogDataCreateDateTime);
            }
            //ログデータ種別区分コード
            if (oprationLogOrderWork.LogDataKindCd != -1)
            {
                retstring += " AND LOGDATAKINDCDRF=@LOGDATAKINDCD" + Environment.NewLine;
                SqlParameter paraLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);
                paraLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(oprationLogOrderWork.LogDataKindCd);
            }

            //ログデータ端末名(曖昧検索)
            if (oprationLogOrderWork.LogDataMachineName != "")
            {
                // -- UPD 2011/02/24 --------------------------------------------------->>>
                //retstring += " AND LOGDATAMACHINENAMERF LIKE @LOGDATAMACHINENAME" + Environment.NewLine;
                //SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                //paraLogDataMachineName.Value = "%" + SqlDataMediator.SqlSetString(oprationLogOrderWork.LogDataMachineName) + "%";

                retstring += " AND LOGDATAMACHINENAMERF=@LOGDATAMACHINENAME" + Environment.NewLine;
                SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                paraLogDataMachineName.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.LogDataMachineName);
                // -- UPD 2011/02/24 ---------------------------------------------------<<<
            }

            //ログデータ対象クラスID(中身：発注先コード)
            if (oprationLogOrderWork.LogDataObjClassID != "")
            {
                retstring += " AND LOGDATAOBJCLASSIDRF=@LOGDATAOBJCLASSID" + Environment.NewLine;
                SqlParameter paraLogDataObjClassID = sqlCommand.Parameters.Add("@LOGDATAOBJCLASSID", SqlDbType.NVarChar);
                paraLogDataObjClassID.Value = SqlDataMediator.SqlSetString(oprationLogOrderWork.LogDataObjClassID);
            }
            return retstring;
        }
        #endregion


        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → OprtnHisLogWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>OprtnHisLogWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
        private OprtnHisLogWork CopyToOprtnHisLogWorkFromReader(ref SqlDataReader myReader)
        {
            OprtnHisLogWork wkOprtnHisLogWork = new OprtnHisLogWork();

            #region クラスへ格納
            wkOprtnHisLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkOprtnHisLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkOprtnHisLogWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkOprtnHisLogWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkOprtnHisLogWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkOprtnHisLogWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkOprtnHisLogWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkOprtnHisLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkOprtnHisLogWork.LogDataCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("LOGDATACREATEDATETIMERF"));
            wkOprtnHisLogWork.LogDataGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("LOGDATAGUIDRF"));
            wkOprtnHisLogWork.LoginSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINSECTIONCDRF"));
            wkOprtnHisLogWork.LogDataKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGDATAKINDCDRF"));
            wkOprtnHisLogWork.LogDataMachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAMACHINENAMERF"));
            wkOprtnHisLogWork.LogDataAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAAGENTCDRF"));
            wkOprtnHisLogWork.LogDataAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAAGENTNMRF"));
            wkOprtnHisLogWork.LogDataObjBootProgramNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJBOOTPROGRAMNMRF"));
            wkOprtnHisLogWork.LogDataObjAssemblyID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJASSEMBLYIDRF"));
            wkOprtnHisLogWork.LogDataObjAssemblyNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJASSEMBLYNMRF"));
            wkOprtnHisLogWork.LogDataObjClassID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJCLASSIDRF"));
            wkOprtnHisLogWork.LogDataObjProcNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAOBJPROCNMRF"));
            wkOprtnHisLogWork.LogDataOperationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGDATAOPERATIONCDRF"));
            wkOprtnHisLogWork.LogOperaterDtProcLvl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGOPERATERDTPROCLVLRF"));
            wkOprtnHisLogWork.LogOperaterFuncLvl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGOPERATERFUNCLVLRF"));
            wkOprtnHisLogWork.LogDataSystemVersion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATASYSTEMVERSIONRF"));
            wkOprtnHisLogWork.LogOperationStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGOPERATIONSTATUSRF"));
            wkOprtnHisLogWork.LogDataMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGDATAMASSAGERF"));
            wkOprtnHisLogWork.LogOperationData = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGOPERATIONDATARF"));
            #endregion

            return wkOprtnHisLogWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            OprtnHisLogWork[] OprtnHisLogWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is OprtnHisLogWork)
                    {
                        OprtnHisLogWork wkOprtnHisLogWork = paraobj as OprtnHisLogWork;
                        if (wkOprtnHisLogWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkOprtnHisLogWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            OprtnHisLogWorkArray = (OprtnHisLogWork[])XmlByteSerializer.Deserialize(byteArray, typeof(OprtnHisLogWork[]));
                        }
                        catch (Exception) { }
                        if (OprtnHisLogWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(OprtnHisLogWorkArray);
                        }
                        else
                        {
                            try
                            {
                                OprtnHisLogWork wkOprtnHisLogWork = (OprtnHisLogWork)XmlByteSerializer.Deserialize(byteArray, typeof(OprtnHisLogWork));
                                if (wkOprtnHisLogWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkOprtnHisLogWork);
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
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.24</br>
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
