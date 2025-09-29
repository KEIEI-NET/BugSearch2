using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// 端末管理マスタローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 端末管理マスタのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20096　村瀬　勝也</br>
    /// <br>Date       : 2007.04.13</br>
    /// <br></br>
    /// <br>Update Note: テーブルの使用言語区分フィールド追加に伴う修正</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.04.24</br>
    /// <br></br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.05.30</br>
    /// <br>Update Note: 項目追加</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2009.05.20</br>
    /// </remarks>
    public class PosTerminalMgLcDB
    {
        /// <summary>
        /// 端末管理マスタローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public PosTerminalMgLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の端末管理マスタ情報LISTを戻します
        /// </summary>
        /// <param name="posTerminalMgWorkList">検索結果</param>
        /// <param name="paraposTerminalMgWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int Search(out List<PosTerminalMgWork> posTerminalMgWorkList, PosTerminalMgWork paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            posTerminalMgWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchPosTerminalMgProcProc(out posTerminalMgWorkList, paraposTerminalMgWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.Search", 0);
                posTerminalMgWorkList = new List<PosTerminalMgWork>();
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
        /// 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="posterminalmgWorkList">検索結果</param>
        /// <param name="posterminalmgWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int SearchPosTerminalMgProc(out List<PosTerminalMgWork> posterminalmgWorkList, PosTerminalMgWork posterminalmgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            status = SearchPosTerminalMgProcProc(out posterminalmgWorkList, posterminalmgWork, readMode, logicalMode, ref sqlConnection);

            return status;

        }

        /// <summary>
        /// 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="posterminalmgWorkList">検索結果</param>
        /// <param name="posterminalmgWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        private int SearchPosTerminalMgProcProc(out List<PosTerminalMgWork> posterminalmgWorkList, PosTerminalMgWork posterminalmgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty; // 2008.05.30 add

            List<PosTerminalMgWork> listdata = new List<PosTerminalMgWork>();
            try
            {
                // 2008.05.30 upd start -------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM POSTERMINALMGRF  ", sqlConnection);
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                sqlTxt += "    ,POSPCTERMCDRF" + Environment.NewLine;
                sqlTxt += "    ,USELANGUAGEDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,USECULTUREDIVCDRF" + Environment.NewLine;
                // ADD 2009.5.20 ------>>
                sqlTxt += "    ,MACHINEIPADDRRF " + Environment.NewLine;
                sqlTxt += "    ,MACHINENAMERF " + Environment.NewLine;
                // ADD 2009.5.20 ------<<
                sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.30 upd end ----------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, posterminalmgWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    listdata.Add(CopyToPosTerminalMgWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)if (!myReader.IsClosed) myReader.Close();
            }

            posterminalmgWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の端末管理マスタを戻します
        /// </summary>
        /// <param name="posterminalmgWork">PosTerminalMgWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタを戻します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int Read(ref PosTerminalMgWork posterminalmgWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref posterminalmgWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.Read", 0);
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
        /// 指定された条件の端末管理マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="posterminalmgWork">PosTerminalMgWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        private int ReadProc(ref PosTerminalMgWork posterminalmgWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    // 2008.05.30 upd start -------------------------->>
                    //string commandText = "SELECT * FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                    sqlTxt += "    ,POSPCTERMCDRF" + Environment.NewLine;
                    sqlTxt += "    ,USELANGUAGEDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,USECULTUREDIVCDRF" + Environment.NewLine;
                    // ADD 2009.5.20 ------>>
                    sqlTxt += "    ,MACHINEIPADDRRF " + Environment.NewLine;
                    sqlTxt += "    ,MACHINENAMERF " + Environment.NewLine;
                    // ADD 2009.5.20 ------<<
                    sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    string commandText = sqlTxt;
                    // 2008.05.30 upd end ----------------------------<<
                    // 2008.05.30 del start -------------------------->>
                    //if (posterminalmgWork.SectionCode != string.Empty)
                    //{
                    //    commandText = commandText + "AND SECTIONCODERF=@FINDSECTIONCODE";
                    //    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    //    findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode);
                    //}
                    // 2008.05.30 del end ----------------------------<<
                    if (posterminalmgWork.CashRegisterNo != 0)
                    {
                        commandText = commandText + "AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);
                    }
                    sqlCommand.CommandText = commandText;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Connection = sqlConnection;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);                    

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);                    

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        posterminalmgWork = CopyToPosTerminalMgWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.Read", 0);
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
        /// 端末管理マスタ情報を登録、更新します
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int Write(ref List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WritePosTerminalMgProcProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                posTerminalMgWorkList = paraList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.Write(ref object posTerminalMgWork)", 0);
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
        /// 端末管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int WritePosTerminalMgProc(ref List<PosTerminalMgWork> posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
            if (paraList == null) return status;


            status = WritePosTerminalMgProcProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            return status;
        }


        /// <summary>
        /// 端末管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        private int WritePosTerminalMgProcProc(ref List<PosTerminalMgWork> posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            List<PosTerminalMgWork> listdata = new List<PosTerminalMgWork>();
            string sqlTxt = string.Empty; // 2008.05.30 add
            try
            {
                if (posTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posTerminalMgWorkList.Count; i++)
                    {
                        PosTerminalMgWork posterminalmgWork = posTerminalMgWorkList[i];

                        //Selectコマンドの生成
                        // 2008.05.30 upd start --------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.30 upd end -----------------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.30 del
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode);           // 2008.05.30 del
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != posterminalmgWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (posterminalmgWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 2008.05.30 upd start --------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO , POSPCTERMCDRF = @POSPCTERMCD , USELANGUAGEDIVCDRF = @USELANGUAGEDIVCD , USECULTUREDIVCDRF = @USECULTUREDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                            sqlTxt += "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , CASHREGISTERNORF=@CASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += " , POSPCTERMCDRF=@POSPCTERMCD" + Environment.NewLine;
                            sqlTxt += " , USELANGUAGEDIVCDRF=@USELANGUAGEDIVCD" + Environment.NewLine;
                            sqlTxt += " , USECULTUREDIVCDRF=@USECULTUREDIVCD" + Environment.NewLine;
                            // ADD 2009.5.20 ------>>
                            sqlTxt += " , MACHINEIPADDRRF = @MACHINEIPADDR" + Environment.NewLine;
                            sqlTxt += " , MACHINENAMERF = @MACHINENAME" + Environment.NewLine;
                            // ADD 2009.5.20 ------<<
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.30 upd end -----------------------------------------<<
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (posterminalmgWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            // 2008.05.30 upd start --------------------------------------->>
                            //sqlCommand.CommandText = "INSERT INTO POSTERMINALMGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF, POSPCTERMCDRF, USELANGUAGEDIVCDRF, USECULTUREDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CASHREGISTERNO, @POSPCTERMCD, @USELANGUAGEDIVCD, @USECULTUREDIVCD)";
                            sqlTxt += "INSERT INTO POSTERMINALMGRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSPCTERMCDRF" + Environment.NewLine;
                            sqlTxt += "    ,USELANGUAGEDIVCDRF" + Environment.NewLine;
                            sqlTxt += "    ,USECULTUREDIVCDRF" + Environment.NewLine;
                            // ADD 2009.5.20 ------>>
                            sqlTxt += "    ,MACHINEIPADDRRF" + Environment.NewLine;
                            sqlTxt += "    ,MACHINENAMERF" + Environment.NewLine;
                            // ADD 2009.5.20 ------<<
                            sqlTxt += " )" + Environment.NewLine;
                            sqlTxt += " VALUES" + Environment.NewLine;
                            sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    ,@CASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += "    ,@POSPCTERMCD" + Environment.NewLine;
                            sqlTxt += "    ,@USELANGUAGEDIVCD" + Environment.NewLine;
                            sqlTxt += "    ,@USECULTUREDIVCD" + Environment.NewLine;
                            // ADD 2009.5.20 ------>>
                            sqlTxt += "    ,@MACHINEIPADDR" + Environment.NewLine;
                            sqlTxt += "    ,@MACHINENAME" + Environment.NewLine;
                            // ADD 2009.5.20 ------<<
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.30 upd end -----------------------------------------<<
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
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
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraPosPCTermCd = sqlCommand.Parameters.Add("@POSPCTERMCD", SqlDbType.Int);
                        SqlParameter paraUseLanguageDivCd = sqlCommand.Parameters.Add("@USELANGUAGEDIVCD", SqlDbType.NVarChar);
                        SqlParameter paraUseCultureDivCd = sqlCommand.Parameters.Add("@USECULTUREDIVCD", SqlDbType.NVarChar);
                        // ADD 2009.5.20 ------>>
                        SqlParameter paraMachineIpAddr = sqlCommand.Parameters.Add("@MACHINEIPADDR", SqlDbType.NVarChar);  // 端末IPアドレス
                        SqlParameter paraMachineName = sqlCommand.Parameters.Add("@MACHINENAME", SqlDbType.NVarChar);  // 端末名称
                        // ADD 2009.5.20 ------<<
                        #endregion
                        
                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posterminalmgWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posterminalmgWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(posterminalmgWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.LogicalDeleteCode);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);
                        paraPosPCTermCd.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.PosPCTermCd);
                        paraUseLanguageDivCd.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UseLanguageDivCd);
                        paraUseCultureDivCd.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UseCultureDivCd);
                        // ADD 2009.5.20 ------>>
                        paraMachineIpAddr.Value = SqlDataMediator.SqlSetString(posterminalmgWork.MachineIpAddr);  // 端末IPアドレス
                        paraMachineName.Value = SqlDataMediator.SqlSetString(posterminalmgWork.MachineName);  // 端末名称
                        // ADD 2009.5.20 ------<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        listdata.Add(posterminalmgWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.WritePosTerminalMgProc", 0);
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

            posTerminalMgWorkList = listdata;

            return status;
        }
        #endregion

        #region [ChangeLanguage]
        /* 言語のみの変更画面はないため、コメントアウトする。将来的に必要になるとメンテして使うこと。
         
        /// <summary>
        /// 言語設定変更のみの処理を行います
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクトのリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 言語設定変更のみの処理を行います</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.04.24</br>
        public int ChangeLanguage(List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
                if (paraList == null)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    return status;
                }
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = ChangeLanguageProc(paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                posTerminalMgWorkList = paraList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.ChangeLanguage(object posTerminalMgWork)", 0);
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
        /// 端末管理マスタ情報の言語設定を更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報の言語設定を更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.04.24</br>
        private int ChangeLanguageProc(List<PosTerminalMgWork> posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            List<PosTerminalMgWork> listdata = new List<PosTerminalMgWork>();
            try
            {
                if (posTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posTerminalMgWorkList.Count; i++)
                    {
                        PosTerminalMgWork posterminalmgWork = posTerminalMgWorkList[i];

                        string SqlText = "";
                        SqlText += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(SqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != posterminalmgWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (posterminalmgWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , USELANGUAGEDIVCDRF = @USELANGUAGEDIVCD USECULTUREDIVCDRF = @USECULTUREDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraUseLanguageDivCd = sqlCommand.Parameters.Add("@USELANGUAGEDIVCD", SqlDbType.NVarChar);
                        SqlParameter paraUseCultureDivCd = sqlCommand.Parameters.Add("@USECULTUREDIVCD", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posterminalmgWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId2);
                        paraUseLanguageDivCd.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UseLanguageDivCd);
                        paraUseCultureDivCd.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UseCultureDivCd);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        listdata.Add(posterminalmgWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.ChangeLanguageProc", 0);
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

            posTerminalMgWorkList = listdata;

            return status;
        }
        */
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 端末管理マスタ情報を論理削除します
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を論理削除します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int LogicalDelete(ref List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            return LogicalDeletePosTerminalMg(ref posTerminalMgWorkList, 0);
        }

        /// <summary>
        /// 論理削除端末管理マスタ情報を復活します
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除端末管理マスタ情報を復活します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int RevivalLogicalDelete(ref List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            return LogicalDeletePosTerminalMg(ref posTerminalMgWorkList, 1);
        }

        /// <summary>
        /// 端末管理マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        private int LogicalDeletePosTerminalMg(ref List<PosTerminalMgWork> posTerminalMgWorkList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeletePosTerminalMgProcProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                WriteErrorLog(ex, "PosTerminalMgLcDB.LogicalDeletePosTerminalMg :" + procModestr, 0);

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
        /// 端末管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int LogicalDeletePosTerminalMgProc(ref List<PosTerminalMgWork> posTerminalMgWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
            if (paraList == null) return status;

            status = LogicalDeletePosTerminalMgProcProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
            return status;
        }

        /// <summary>
        /// 端末管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">PosTerminalMgWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        private int LogicalDeletePosTerminalMgProcProc(ref List<PosTerminalMgWork> posTerminalMgWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            List<PosTerminalMgWork> listdata = new List<PosTerminalMgWork>();
            string sqlTxt = string.Empty; // 2008.05.30 add

            try
            {
                if (posTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posTerminalMgWorkList.Count; i++)
                    {
                        PosTerminalMgWork posterminalmgWork = posTerminalMgWorkList[i];

                        //Selectコマンドの生成
                        // 2008.05.30 upd start --------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.30 upd end -----------------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.30 del
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != posterminalmgWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // 2008.05.30 upd start --------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                            sqlTxt += "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.30 upd end -----------------------------------------<<
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
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
                            else if (logicalDelCd == 0) posterminalmgWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else posterminalmgWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) posterminalmgWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posterminalmgWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posterminalmgWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        listdata.Add(posterminalmgWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.LogicalDeletePosTerminalMgProc", 0);
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

            posTerminalMgWorkList = listdata;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 端末管理マスタ情報を物理削除します
        /// </summary>
        /// <param name="posTerminalMgWorkList">端末管理マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 端末管理マスタ情報を物理削除します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int Delete(List<PosTerminalMgWork> posTerminalMgWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {

                List<PosTerminalMgWork> paraList = posTerminalMgWorkList;
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeletePosTerminalMgProcProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                WriteErrorLog(ex, "PosTerminalMgLcDB.Delete", 0);

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
        /// 端末管理マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="posterminalmgWorkList">端末管理マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 端末管理マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int DeletePosTerminalMgProc(List<PosTerminalMgWork> posterminalmgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<PosTerminalMgWork> paraList = posterminalmgWorkList;
            if (paraList == null) return status;
            status = DeletePosTerminalMgProcProc(paraList, ref sqlConnection, ref sqlTransaction);
            return status;

        }


        /// <summary>
        /// 端末管理マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="posterminalmgWorkList">端末管理マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 端末管理マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        private int DeletePosTerminalMgProcProc(List<PosTerminalMgWork> posterminalmgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty; // 2008.05.30 add
            try
            {

                for (int i = 0; i < posterminalmgWorkList.Count; i++)
                {
                    PosTerminalMgWork posterminalmgWork = posterminalmgWorkList[i];
                    // 2008.05.30 upd start ------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO", sqlConnection, sqlTransaction);
                    sqlTxt = string.Empty;
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    // 2008.05.30 upd end ---------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.30 del
                    SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                    findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != posterminalmgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        // 2008.05.30 upd start ------------------------------->>
                        //sqlCommand.CommandText = "DELETE FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM POSTERMINALMGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.30 upd end ---------------------------------<<

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(posterminalmgWork.SectionCode); // 2008.05.30 del
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posterminalmgWork.CashRegisterNo);
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
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.DeletePosTerminalMgProc", 0);
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
        /// <param name="posTerminalMgWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PosTerminalMgWork posTerminalMgWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);

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



            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PosTerminalMgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PosTerminalMgWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        private PosTerminalMgWork CopyToPosTerminalMgWorkFromReader(ref SqlDataReader myReader)
        {
            PosTerminalMgWork wkPosTerminalMgWork = new PosTerminalMgWork();

            #region クラスへ格納
            wkPosTerminalMgWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkPosTerminalMgWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkPosTerminalMgWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkPosTerminalMgWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkPosTerminalMgWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkPosTerminalMgWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkPosTerminalMgWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkPosTerminalMgWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //wkPosTerminalMgWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkPosTerminalMgWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            wkPosTerminalMgWork.PosPCTermCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSPCTERMCDRF"));
            wkPosTerminalMgWork.UseLanguageDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USELANGUAGEDIVCDRF"));
            wkPosTerminalMgWork.UseCultureDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USECULTUREDIVCDRF"));
            // ADD 2009.5.20 ------>>
            wkPosTerminalMgWork.MachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINEIPADDRRF"));  // 端末IPアドレス
            wkPosTerminalMgWork.MachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINENAMERF"));  // 端末名称
            // ADD 2009.5.20 ------<<
            #endregion

            return wkPosTerminalMgWork;
        }
        #endregion

        #region [バックアップ端末管理マスタ情報関連処理ー現在は不要]
        //PM.NSは使わない予定であるが、念のため残しておく。
#if false   
        #region [BkReWrite]
        /// <summary>
        /// バックアップデータより端末管理マスタ情報を元に戻します
        /// </summary>
        /// <param name="posBkTerminalMgWorkList">BkPosTerminalMgWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : バックアップデータより端末管理マスタ情報を元に戻します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.07.04</br>
        public int BkReWrite(ref ArrayList posBkTerminalMgWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                ArrayList paraList = posBkTerminalMgWorkList;
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteBkRePosTerminalMgProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                posBkTerminalMgWorkList = paraList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.BkReWrite(ref object posBkTerminalMgWork)", 0);
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
        /// バックアップデータより端末管理マスタ情報を元に戻します (外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posBkTerminalMgWorkList">PosBkReTerminalMgWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : バックアップデータより端末管理マスタ情報を元に戻します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.07.03</br>
        public int WriteBkRePosTerminalMgProc(ref ArrayList posBkTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            try
            {
                if (posBkTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posBkTerminalMgWorkList.Count; i++)
                    {
                        BkPosTerminalMgWork bkposterminalmgWork = (BkPosTerminalMgWork)posBkTerminalMgWorkList[i];

                        //バックアップの動きが特殊なため、注意が必要
                        //企業、拠点、レジ番号がプライマリになっているが、画面の制御にて企業で1行しかデータが出来ない仕様らしく
                        //既存レコードチェックは企業コードのみ

                        //Selectコマンドの生成
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO", sqlConnection, sqlTransaction);
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        //SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.SectionCode);
                        //findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
 
                            //sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO , POSPCTERMCDRF = @POSPCTERMCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO";
                            sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO , POSPCTERMCDRF = @POSPCTERMCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.SectionCode);
                            //findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.CashRegisterNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bkposterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
 
                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO POSTERMINALMGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF, POSPCTERMCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CASHREGISTERNO, @POSPCTERMCD)";
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bkposterminalmgWork;
                            ClientFileHeader fileHeader = new ClientFileHeader(obj);
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
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraPosPCTermCd = sqlCommand.Parameters.Add("@POSPCTERMCD", SqlDbType.Int);
        #endregion

        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bkposterminalmgWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bkposterminalmgWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(bkposterminalmgWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(bkposterminalmgWork.SectionCode);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.CashRegisterNo);
                        paraPosPCTermCd.Value = SqlDataMediator.SqlSetInt32(bkposterminalmgWork.PosPCTermCd);
        #endregion

                        sqlCommand.ExecuteNonQuery();
                        listdata.Add(bkposterminalmgWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "PosTerminalMgLcDB.WriteBkPosTerminalMgProc", 0);
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

            posBkTerminalMgWorkList = listdata;

            return status;
        }
        #endregion

        #region [BkSearch]
        /// <summary>
        /// 指定された条件のバックアップ用端末管理マスタ情報LISTを戻します
        /// </summary>
        /// <param name="bkposTerminalMgArrayList">検索結果</param>
        /// <param name="paraposTerminalMgWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のバックアップ用端末管理マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        public int BkSearch(out ArrayList bkposTerminalMgArrayList, PosTerminalMgWork paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //List<BkPosTerminalMgWork> bkposTerminalMgWorkList = null;
            List<PosTerminalMgWork> posTerminalMgWorkList = null;
            bkposTerminalMgArrayList = null;
            ArrayList al = new ArrayList();

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchPosTerminalMgProc(out posTerminalMgWorkList, paraposTerminalMgWork, readMode, logicalMode, ref sqlConnection);
                
                //バックアップデータ用に加工
                if (posTerminalMgWorkList != null)
                {
                    for (int i = 0; i < posTerminalMgWorkList.Count; i++)
                    {
                        PosTerminalMgWork posTerminalMgWork = posTerminalMgWorkList[i];
                        BkPosTerminalMgWork bkposTerminalMgWork = new BkPosTerminalMgWork();
                        bkposTerminalMgWork = CopyToBkPosTerminalMgWorkFromPosTerminalMgWork(posTerminalMgWork);
                        al.Add(bkposTerminalMgWork);
                    }
                }
                bkposTerminalMgArrayList = al;
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "PosTerminalMgLcDB.BkSearch", 0);
                posTerminalMgWorkList = new List<PosTerminalMgWork>();
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

        #endregion

        #region [バックアップ用クラス変換処理]
        /// <summary>
        /// クラス格納処理 PosTerminalMgWork → BkPosTerminalMgWork
        /// </summary>
        /// <param name="posTerminalMgWork">posTerminalMgWork</param>
        /// <returns>BkPosTerminalMgWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        private BkPosTerminalMgWork CopyToBkPosTerminalMgWorkFromPosTerminalMgWork(PosTerminalMgWork posTerminalMgWork)
        {
            BkPosTerminalMgWork wkBkPosTerminalMgWork = new BkPosTerminalMgWork();

        #region クラスへ格納
            wkBkPosTerminalMgWork.CreateDateTime = posTerminalMgWork.CreateDateTime;
            wkBkPosTerminalMgWork.UpdateDateTime = posTerminalMgWork.UpdateDateTime;
            wkBkPosTerminalMgWork.EnterpriseCode = posTerminalMgWork.EnterpriseCode;
            wkBkPosTerminalMgWork.FileHeaderGuid = posTerminalMgWork.FileHeaderGuid;
            wkBkPosTerminalMgWork.UpdEmployeeCode = posTerminalMgWork.UpdEmployeeCode;
            wkBkPosTerminalMgWork.UpdAssemblyId1 = posTerminalMgWork.UpdAssemblyId1;
            wkBkPosTerminalMgWork.UpdAssemblyId2 = posTerminalMgWork.UpdAssemblyId2;
            wkBkPosTerminalMgWork.LogicalDeleteCode = posTerminalMgWork.LogicalDeleteCode;
            wkBkPosTerminalMgWork.SectionCode = posTerminalMgWork.SectionCode;
            wkBkPosTerminalMgWork.CashRegisterNo = posTerminalMgWork.CashRegisterNo;
            wkBkPosTerminalMgWork.PosPCTermCd = posTerminalMgWork.PosPCTermCd; 
        #endregion

            return wkBkPosTerminalMgWork;
        }
        #endregion
#endif
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_UserDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [エラーログ出力処理]
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}
