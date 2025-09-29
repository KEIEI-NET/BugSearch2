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
    /// 従業員ロール設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員ロール設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30747 三戸　伸悟</br>
    /// <br>Date       : 2013/02/07</br>
    /// </remarks>
    [Serializable]
    public class EmployeeRoleStDB : RemoteDB, IEmployeeRoleStDB
    {
        /// <summary>
        /// 従業員ロール設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        public EmployeeRoleStDB()
            :
            base("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork", "EMPLOYEEROLESTRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の従業員ロール設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="employeeRoleStWork">検索結果</param>
        /// <param name="paraemployeeRoleStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員ロール設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int Search(out object employeeRoleStWork, object paraemployeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            employeeRoleStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchEmployeeRoleStProc(out employeeRoleStWork, paraemployeeRoleStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeRoleStDB.Search");
                employeeRoleStWork = new ArrayList();
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
        /// 指定された条件の従業員ロール設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objemployeeRoleStWork">検索結果</param>
        /// <param name="paraemployeeRoleStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員ロール設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int SearchEmployeeRoleStProc(out object objemployeeRoleStWork, object paraemployeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            EmployeeRoleStWork employeeRoleStWork = null;

            ArrayList employeeRoleStWorkList = paraemployeeRoleStWork as ArrayList;
            if (employeeRoleStWorkList == null)
            {
                employeeRoleStWork = paraemployeeRoleStWork as EmployeeRoleStWork;
            }
            else
            {
                if (employeeRoleStWorkList.Count > 0)
                    employeeRoleStWork = employeeRoleStWorkList[0] as EmployeeRoleStWork;
            }

            int status = SearchEmployeeRoleStProc(out employeeRoleStWorkList, employeeRoleStWork, readMode, logicalMode, ref sqlConnection);
            objemployeeRoleStWork = employeeRoleStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の従業員ロール設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="employeeRoleStWorkList">検索結果</param>
        /// <param name="employeeRoleStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員ロール設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int SearchEmployeeRoleStProc(out ArrayList employeeRoleStWorkList, EmployeeRoleStWork employeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchEmployeeRoleStProcProc(out employeeRoleStWorkList, employeeRoleStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の従業員ロール設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="employeeRoleStWorkList">検索結果</param>
        /// <param name="employeeRoleStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員ロール設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        private int SearchEmployeeRoleStProcProc(out ArrayList employeeRoleStWorkList, EmployeeRoleStWork employeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += "SELECT  A.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   A.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   A.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,   A.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,   A.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   A.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,   A.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,   A.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,   A.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   A.ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,   B.ROLEGROUPNAMERF" + Environment.NewLine;
                selectTxt += "    ,   C.NAMERF" + Environment.NewLine;
                selectTxt += "FROM    EMPLOYEEROLESTRF  A" + Environment.NewLine;
                selectTxt += "LEFT JOIN ROLEGRPNAMESTRF B" + Environment.NewLine;
                selectTxt += " ON  A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND A.ROLEGROUPCODERF  = B.ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += " AND B.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF      C" + Environment.NewLine;
                selectTxt += " ON  A.ENTERPRISECODERF = C.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND A.EMPLOYEECODERF   = C.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " AND C.LOGICALDELETECODERF = 0" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, employeeRoleStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToEmployeeRoleStWorkFromReader(ref myReader));

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

            employeeRoleStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の従業員ロール設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">EmployeeRoleStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員ロール設定マスタを戻します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                EmployeeRoleStWork employeeRoleStWork = new EmployeeRoleStWork();

                // XMLの読み込み
                employeeRoleStWork = (EmployeeRoleStWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeRoleStWork));
                if (employeeRoleStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref employeeRoleStWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(employeeRoleStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeRoleStDB.Read");
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
        /// 指定された条件の従業員ロール設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員ロール設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int ReadProc(ref EmployeeRoleStWork employeeRoleStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref employeeRoleStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の従業員ロール設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員ロール設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        private int ReadProcProc(ref EmployeeRoleStWork employeeRoleStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += "SELECT  CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,   EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "FROM    EMPLOYEEROLESTRF" + Environment.NewLine;
                selectTxt += "WHERE   ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND   EMPLOYEECODERF  = @FINDEMPLOYEECODE" + Environment.NewLine;
                selectTxt += "  AND   ROLEGROUPCODERF  = @FINDROLEGROUPCODE" + Environment.NewLine;
                #endregion

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                    SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);        // 従業員コード
                    SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ロールグループコード

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);             // 企業コード
                    findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                 // 従業員コード
                    findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                // ロールグループコード

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        employeeRoleStWork = CopyToEmployeeRoleStWorkFromReader(ref myReader);
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
        /// 従業員ロール設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int Write(ref object employeeRoleStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(employeeRoleStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteEmployeeRoleStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                EmployeeRoleStWork paraWork = paraList[0] as EmployeeRoleStWork;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                employeeRoleStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeRoleStDB.Write(ref object employeeRoleStWork)");
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
        /// 従業員ロール設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeRoleStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int WriteEmployeeRoleStProc(ref ArrayList employeeRoleStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteEmployeeRoleStProcProc(ref employeeRoleStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員ロール設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeRoleStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        private int WriteEmployeeRoleStProcProc(ref ArrayList employeeRoleStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (employeeRoleStWorkList != null)
                {
                    foreach (EmployeeRoleStWork employeeRoleStWork in employeeRoleStWorkList)
                    {
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM EMPLOYEEROLESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                        SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);        // 従業員コード
                        SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ロールグループコード

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);             // 企業コード
                        findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                 // 従業員コード
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                // ロールグループコード

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時
                            if (_updateDateTime != employeeRoleStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (employeeRoleStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += "UPDATE  EMPLOYEEROLESTRF" + Environment.NewLine;
                            sqlText += "SET     CREATEDATETIMERF    = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   UPDATEDATETIMERF    = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   ENTERPRISECODERF    = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,   FILEHEADERGUIDRF    = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,   UPDEMPLOYEECODERF   = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID1RF    = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID2RF    = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,   LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,   EMPLOYEECODERF      = @EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPCODERF     = @ROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "WHERE   ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND   EMPLOYEECODERF      = @FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND   ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);     // 企業コード
                            findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);         // 従業員コード
                            findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);        // ロールグループコード

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeRoleStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (employeeRoleStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += "INSERT INTO EMPLOYEEROLESTRF (" + Environment.NewLine;
                            sqlText += "        CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,   EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                            sqlText += ") VALUES (" + Environment.NewLine;
                            sqlText += "        @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,   @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,   @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,   @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,   @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,   @EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   @ROLEGROUPCODE" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeRoleStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);           // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);           // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);            // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier); // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);          // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);         // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);         // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);        // 論理削除区分
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);                // 従業員コード
                        SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@ROLEGROUPCODE", SqlDbType.Int);                // ロールグループコード
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeRoleStWork.CreateDateTime);      // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeRoleStWork.UpdateDateTime);      // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);                 // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(employeeRoleStWork.FileHeaderGuid);                   // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdEmployeeCode);               // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdAssemblyId1);                 // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdAssemblyId2);                 // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.LogicalDeleteCode);            // 論理削除区分
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                     // 従業員コード
                        paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                    // ロールグループコード
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(employeeRoleStWork);
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

            employeeRoleStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 従業員ロール設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="employeeRoleStWork">employeeRoleStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int LogicalDelete(ref object employeeRoleStWork)
        {
            return LogicalDeleteEmployeeRoleSt(ref employeeRoleStWork, 0);
        }

        /// <summary>
        /// 論理削除従業員ロール設定マスタ情報を復活します
        /// </summary>
        /// <param name="employeeRoleStWork">employeeRoleStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除従業員ロール設定マスタ情報を復活します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int RevivalLogicalDelete(ref object employeeRoleStWork)
        {
            return LogicalDeleteEmployeeRoleSt(ref employeeRoleStWork, 1);
        }

        /// <summary>
        /// 従業員ロール設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="employeeRoleStWork">employeeRoleStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        private int LogicalDeleteEmployeeRoleSt(ref object employeeRoleStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(employeeRoleStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteEmployeeRoleStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "EmployeeRoleStDB.LogicalDeleteEmployeeRoleSt :" + procModestr);

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
        /// 従業員ロール設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeRoleStWorkList">employeeRoleStWorkListオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int LogicalDeleteEmployeeRoleStProc(ref ArrayList employeeRoleStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteEmployeeRoleStProcProc(ref employeeRoleStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員ロール設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeRoleStWorkList">employeeRoleStWorkListオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員ロール設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        private int LogicalDeleteEmployeeRoleStProcProc(ref ArrayList employeeRoleStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (employeeRoleStWorkList != null)
                {
                    for (int i = 0; i < employeeRoleStWorkList.Count; i++)
                    {
                        EmployeeRoleStWork employeeRoleStWork = employeeRoleStWorkList[i] as EmployeeRoleStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM EMPLOYEEROLESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                        SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);        // 従業員コード
                        SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ロールグループコード

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);             // 企業コード
                        findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                 // 従業員コード
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                // ロールグループコード

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != employeeRoleStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE EMPLOYEEROLESTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE";

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);         // 企業コード
                            findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);             // 従業員コード
                            findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);            // ロールグループコード

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeRoleStWork;
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
                            else if (logicalDelCd == 0) employeeRoleStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else employeeRoleStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) employeeRoleStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;    //既に復活している場合はそのまま正常を戻す
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeRoleStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(employeeRoleStWork);
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

            employeeRoleStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 従業員ロール設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">従業員ロール設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
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

                status = DeleteEmployeeRoleStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmployeeRoleStDB.Delete");
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
        /// 従業員ロール設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeRoleStWorkList">従業員ロール設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int DeleteEmployeeRoleStProc(ArrayList employeeRoleStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteEmployeeRoleStProcProc(employeeRoleStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員ロール設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeRoleStWorkList">従業員ロール設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 従業員ロール設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        private int DeleteEmployeeRoleStProcProc(ArrayList employeeRoleStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < employeeRoleStWorkList.Count; i++)
                {
                    EmployeeRoleStWork employeeRoleStWork = employeeRoleStWorkList[i] as EmployeeRoleStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM EMPLOYEEROLESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                    SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);        // 従業員コード
                    SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ロールグループコード

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);             // 企業コード
                    findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                 // 従業員コード
                    findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                // ロールグループコード

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != employeeRoleStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM EMPLOYEEROLESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE";

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);         // 企業コード
                        findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);             // 従業員コード
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);            // ロールグループコード
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
        /// <param name="employeeRoleStWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, EmployeeRoleStWork employeeRoleStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE   ";

            //企業コード
            retstring += "A.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);

            //従業員コード
            if (employeeRoleStWork.EmployeeCode != "")
            {
                retstring += "  AND   A.EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);
            }

            //ロールグループコード
            if (employeeRoleStWork.RoleGroupCode != 0)
            {
                retstring += "  AND   A.ROLEGROUPCODERF = @FINDROLEGROUPCODE" + Environment.NewLine;
                SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);
            }

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND   A.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND   A.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
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
        /// クラス格納処理 Reader → EmployeeRoleStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmployeeRoleStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private EmployeeRoleStWork CopyToEmployeeRoleStWorkFromReader(ref SqlDataReader myReader)
        {
            EmployeeRoleStWork wkEmployeeRoleStWork = new EmployeeRoleStWork();

            #region クラスへ格納
            wkEmployeeRoleStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));   // 作成日時
            wkEmployeeRoleStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));   // 更新日時
            wkEmployeeRoleStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));              // 企業コード
            wkEmployeeRoleStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                // GUID
            wkEmployeeRoleStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));            // 更新従業員コード
            wkEmployeeRoleStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));              // 更新アセンブリID1
            wkEmployeeRoleStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));              // 更新アセンブリID2
            wkEmployeeRoleStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));         // 論理削除区分
            wkEmployeeRoleStWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));                  // 従業員コード
            wkEmployeeRoleStWork.RoleGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEGROUPCODERF"));                 // ロールグループコード
            wkEmployeeRoleStWork.RoleGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ROLEGROUPNAMERF"));                // ロールグループ名称
            wkEmployeeRoleStWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));                          // 従業員名称
            #endregion

            return wkEmployeeRoleStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            EmployeeRoleStWork[] EmployeeRoleStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is EmployeeRoleStWork)
                    {
                        EmployeeRoleStWork wkEmployeeRoleStWork = paraobj as EmployeeRoleStWork;
                        if (wkEmployeeRoleStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkEmployeeRoleStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            EmployeeRoleStWorkArray = (EmployeeRoleStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(EmployeeRoleStWork[]));
                        }
                        catch (Exception) { }
                        if (EmployeeRoleStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(EmployeeRoleStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                EmployeeRoleStWork wkEmployeeRoleStWork = (EmployeeRoleStWork)XmlByteSerializer.Deserialize(byteArray, typeof(EmployeeRoleStWork));
                                if (wkEmployeeRoleStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkEmployeeRoleStWork);
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
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
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
