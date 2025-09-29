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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;  //ADD 2008/11/10 shibuya


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 従業員詳細マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員詳細マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.16</br>
    /// <br></br>
    /// <br>Update Note: PM.NS用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.05.26</br>
    /// <br>Update Note: UOE略称区分追加</br>
    /// <br>Programmer : 30009 渋谷 大輔</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br>UpdateNote : 2009.03.02 20056 對馬 大輔　メール項目追加</br>
    /// </remarks>
    [Serializable]
    public class EmployeeDtlDB : RemoteDB, IEmployeeDtlDB, IGetSyncdataList
    {
        /// <summary>
        /// 従業員詳細マスタDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 21024　佐々木　健</br>														   
        /// <br>Date       : 2007.08.16</br>
        /// </remarks>
        public EmployeeDtlDB()
            :
        base("DCTOK09036D", "Broadleaf.Application.Remoting.ParamData.EmployeeDtlWork", "EMPLOYEEDTLRF")
        {
        }

        #region [Read]
        /// <summary>
        /// 指定された条件の従業員詳細マスタを戻します
        /// </summary>
        /// <param name="parabyte">EmployeeDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員詳細マスタを戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int Read( ref byte[] parabyte, int readMode )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();

                // XMLの読み込み
                employeeDtlWork = (EmployeeDtlWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeDtlWork));
                if (employeeDtlWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref employeeDtlWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(employeeDtlWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDtlDB.Read");
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
        /// 指定された条件の従業員詳細マスタを戻します
        /// </summary>
        /// <param name="paraobj">EmployeeDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員詳細マスタを戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int Read(ref object paraobj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                EmployeeDtlWork employeeDtlWork = paraobj as EmployeeDtlWork;

                if (employeeDtlWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref employeeDtlWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDtlDB.Read");
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
        /// 指定された条件の従業員詳細マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="employeeDtlWork">EmployeeDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員詳細マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int ReadProc( ref EmployeeDtlWork employeeDtlWork, int readMode, ref SqlConnection sqlConnection )
        {
            return this.ReadProcProc(ref employeeDtlWork, readMode, ref sqlConnection);
        }
        /// <summary>
        /// 指定された条件の従業員詳細マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="employeeDtlWork">EmployeeDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員詳細マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        private int ReadProcProc(ref EmployeeDtlWork employeeDtlWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            string sqlText = "";

            try
            {
                //Selectコマンドの生成
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                // 2008.05.26 del start --------------------------------------------->>
                //sqlText += " ,BELONGSUBSECTIONNAMERF" + Environment.NewLine;
                //sqlText += " ,BELONGMINSECTIONCODERF" + Environment.NewLine;
                //sqlText += " ,BELONGMINSECTIONNAMERF" + Environment.NewLine;
                //sqlText += " ,BELONGSALESAREACODERF" + Environment.NewLine;
                //sqlText += " ,BELONGSALESAREANAMERF" + Environment.NewLine;
                // 2008.05.26 del end -----------------------------------------------<<
                sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                // 2008.11.10 add start --------------------------------------------->>
                sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                // 2008.11.10 add end -----------------------------------------------<<
                // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2008.05.26 del start --------------------------------------------->>
                //sqlText += " ,OLDBELONGSECTIONCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSECTIONNMRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSUBSECCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSUBSECNMRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGMINSECCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGMINSECNMRF" + Environment.NewLine;
                //sqlText += " ,SECTIONCHGDATERF" + Environment.NewLine;
                // 2008.05.26 del end -----------------------------------------------<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;

                using ( SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection) )
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                    findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);
                    
#if DEBUG
                    Console.Clear();  //ADD 2008/11/10
                    Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));  //ADD 2008/11/10
#endif

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        employeeDtlWork = CopyToEmployeeDtlWorkFromReader(ref myReader);
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
        /// 従業員詳細マスタ情報を登録、更新します
        /// </summary>
        /// <param name="employeeDtlWork">EmployeeDtlWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタ情報を登録、更新します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int Write(ref object employeeDtlWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(employeeDtlWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteMakerProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                employeeDtlWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDtlDB.Write(ref object EmployeeDtlWork)");
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
        /// 従業員詳細マスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeDtlWorkList">EmployeeDtlWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int WriteMakerProc( ref ArrayList employeeDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            return this.WriteMakerProcProc(ref employeeDtlWorkList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 従業員詳細マスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeDtlWorkList">EmployeeDtlWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        private int WriteMakerProcProc(ref ArrayList employeeDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = "";
            try
            {
                if (employeeDtlWorkList != null)
                {
                    for (int i = 0; i < employeeDtlWorkList.Count; i++)
                    {
                        EmployeeDtlWork employeeDtlWork = employeeDtlWorkList[i] as EmployeeDtlWork;

                        //Selectコマンドの生成
                        sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                        findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != employeeDtlWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (employeeDtlWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //Selectコマンドの生成
                            sqlText = "";
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF = @EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,BELONGSUBSECTIONCODERF = @BELONGSUBSECTIONCODE" + Environment.NewLine;
                            // 2008.05.26 del start --------------------------------------------->>
                            //sqlText += " ,BELONGSUBSECTIONNAMERF = @BELONGSUBSECTIONNAME" + Environment.NewLine;
                            //sqlText += " ,BELONGMINSECTIONCODERF = @BELONGMINSECTIONCODE" + Environment.NewLine;
                            //sqlText += " ,BELONGMINSECTIONNAMERF = @BELONGMINSECTIONNAME" + Environment.NewLine;
                            //sqlText += " ,BELONGSALESAREACODERF = @BELONGSALESAREACODE" + Environment.NewLine;
                            //sqlText += " ,BELONGSALESAREANAMERF = @BELONGSALESAREANAME" + Environment.NewLine;
                            // 2008.05.26 del end -----------------------------------------------<<
                            sqlText += " ,EMPLOYANALYSCODE1RF = @EMPLOYANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE2RF = @EMPLOYANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE3RF = @EMPLOYANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE4RF = @EMPLOYANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE5RF = @EMPLOYANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE6RF = @EMPLOYANALYSCODE6" + Environment.NewLine;
                            // 2008.11.10 add start --------------------------------------------->>
                            sqlText += " ,UOESNMDIVRF = @UOESNMDIV" + Environment.NewLine;
                            // 2008.11.10 add end -----------------------------------------------<<
                            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            // 2008.05.26 del start --------------------------------------------->>
                            //sqlText += " ,OLDBELONGSECTIONCDRF = @OLDBELONGSECTIONCD" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGSECTIONNMRF = @OLDBELONGSECTIONNM" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGSUBSECCDRF = @OLDBELONGSUBSECCD" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGSUBSECNMRF = @OLDBELONGSUBSECNM" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGMINSECCDRF = @OLDBELONGMINSECCD" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGMINSECNMRF = @OLDBELONGMINSECNM" + Environment.NewLine;
                            //sqlText += " ,SECTIONCHGDATERF = @SECTIONCHGDATE" + Environment.NewLine;
                            // 2008.05.26 del end -----------------------------------------------<<
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                                                      
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                            findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeDtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (employeeDtlWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //Selectコマンドの生成
                            sqlText += "INSERT INTO EMPLOYEEDTLRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                            // 2008.05.26 del start --------------------------------------------->>
                            //sqlText += " ,BELONGSUBSECTIONNAMERF" + Environment.NewLine;
                            //sqlText += " ,BELONGMINSECTIONCODERF" + Environment.NewLine;
                            //sqlText += " ,BELONGMINSECTIONNAMERF" + Environment.NewLine;
                            //sqlText += " ,BELONGSALESAREACODERF" + Environment.NewLine;
                            //sqlText += " ,BELONGSALESAREANAMERF" + Environment.NewLine;
                            // 2008.05.26 del end -----------------------------------------------<<
                            sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                            // 2008.11.10 add start --------------------------------------------->>
                            sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                            // 2008.11.10 add end -----------------------------------------------<<
                            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            // 2008.05.26 del start --------------------------------------------->>
                            //sqlText += " ,OLDBELONGSECTIONCDRF" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGSECTIONNMRF" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGSUBSECCDRF" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGSUBSECNMRF" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGMINSECCDRF" + Environment.NewLine;
                            //sqlText += " ,OLDBELONGMINSECNMRF" + Environment.NewLine;
                            //sqlText += " ,SECTIONCHGDATERF" + Environment.NewLine;
                            // 2008.05.26 del end -----------------------------------------------<<
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@BELONGSUBSECTIONCODE" + Environment.NewLine;
                            // 2008.05.26 del start --------------------------------------------->>
                            //sqlText += " ,@BELONGSUBSECTIONNAME" + Environment.NewLine;
                            //sqlText += " ,@BELONGMINSECTIONCODE" + Environment.NewLine;
                            //sqlText += " ,@BELONGMINSECTIONNAME" + Environment.NewLine;
                            //sqlText += " ,@BELONGSALESAREACODE" + Environment.NewLine;
                            //sqlText += " ,@BELONGSALESAREANAME" + Environment.NewLine;
                            // 2008.05.26 del end -----------------------------------------------<<
                            sqlText += " ,@EMPLOYANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@EMPLOYANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@EMPLOYANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@EMPLOYANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@EMPLOYANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@EMPLOYANALYSCODE6" + Environment.NewLine;
                            // 2008.11.10 add start --------------------------------------------->>
                            sqlText += " ,@UOESNMDIV" + Environment.NewLine;
                            // 2008.11.10 add end -----------------------------------------------<<
                            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            // 2008.05.26 del start --------------------------------------------->>
                            //sqlText += " ,@OLDBELONGSECTIONCD" + Environment.NewLine;
                            //sqlText += " ,@OLDBELONGSECTIONNM" + Environment.NewLine;
                            //sqlText += " ,@OLDBELONGSUBSECCD" + Environment.NewLine;
                            //sqlText += " ,@OLDBELONGSUBSECNM" + Environment.NewLine;
                            //sqlText += " ,@OLDBELONGMINSECCD" + Environment.NewLine;
                            //sqlText += " ,@OLDBELONGMINSECNM" + Environment.NewLine;
                            //sqlText += " ,@SECTIONCHGDATE" + Environment.NewLine;
                            // 2008.05.26 del end -----------------------------------------------<<
                            sqlText += ")" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeDtlWork;
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
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraBelongSubSectionCode = sqlCommand.Parameters.Add("@BELONGSUBSECTIONCODE", SqlDbType.Int);
                        // 2008.05.26 del start --------------------------------------------->>
                        //SqlParameter paraBelongSubSectionName = sqlCommand.Parameters.Add("@BELONGSUBSECTIONNAME", SqlDbType.NVarChar);
                        //SqlParameter paraBelongMinSectionCode = sqlCommand.Parameters.Add("@BELONGMINSECTIONCODE", SqlDbType.Int);
                        //SqlParameter paraBelongMinSectionName = sqlCommand.Parameters.Add("@BELONGMINSECTIONNAME", SqlDbType.NVarChar);
                        //SqlParameter paraBelongSalesAreaCode = sqlCommand.Parameters.Add("@BELONGSALESAREACODE", SqlDbType.Int);
                        //SqlParameter paraBelongSalesAreaName = sqlCommand.Parameters.Add("@BELONGSALESAREANAME", SqlDbType.NVarChar);
                        // 2008.05.26 del end -----------------------------------------------<<
                        SqlParameter paraEmployAnalysCode1 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode2 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode3 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode4 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode5 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraEmployAnalysCode6 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE6", SqlDbType.Int);
                        // 2008.11.10 add start --------------------------------------------->>
                        SqlParameter paraUOESnmDiv = sqlCommand.Parameters.Add("@UOESNMDIV", SqlDbType.NChar);
                        // 2008.11.10 add end -----------------------------------------------<<
                        // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.NChar);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.NChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.NChar);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.NChar);
                        // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // 2008.05.26 del start --------------------------------------------->>
                        //SqlParameter paraOldBelongSectionCd = sqlCommand.Parameters.Add("@OLDBELONGSECTIONCD", SqlDbType.NChar);
                        //SqlParameter paraOldBelongSectionNm = sqlCommand.Parameters.Add("@OLDBELONGSECTIONNM", SqlDbType.NVarChar);
                        //SqlParameter paraOldBelongSubSecCd = sqlCommand.Parameters.Add("@OLDBELONGSUBSECCD", SqlDbType.Int);
                        //SqlParameter paraOldBelongSubSecNm = sqlCommand.Parameters.Add("@OLDBELONGSUBSECNM", SqlDbType.NVarChar);
                        //SqlParameter paraOldBelongMinSecCd = sqlCommand.Parameters.Add("@OLDBELONGMINSECCD", SqlDbType.Int);
                        //SqlParameter paraOldBelongMinSecNm = sqlCommand.Parameters.Add("@OLDBELONGMINSECNM", SqlDbType.NVarChar);
                        //SqlParameter paraSectionChgDate = sqlCommand.Parameters.Add("@SECTIONCHGDATE", SqlDbType.Int);
                        // 2008.05.26 del end -----------------------------------------------<<
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeDtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeDtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(employeeDtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.LogicalDeleteCode);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);
                        paraBelongSubSectionCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.BelongSubSectionCode);
                        // 2008.05.26 del start --------------------------------------------->>
                        //paraBelongSubSectionName.Value = SqlDataMediator.SqlSetString(employeeDtlWork.BelongSubSectionName);
                        //paraBelongMinSectionCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.BelongMinSectionCode);
                        //paraBelongMinSectionName.Value = SqlDataMediator.SqlSetString(employeeDtlWork.BelongMinSectionName);
                        //paraBelongSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.BelongSalesAreaCode);
                        //paraBelongSalesAreaName.Value = SqlDataMediator.SqlSetString(employeeDtlWork.BelongSalesAreaName);
                        // 2008.05.26 del end -----------------------------------------------<<
                        paraEmployAnalysCode1.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode1);
                        paraEmployAnalysCode2.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode2);
                        paraEmployAnalysCode3.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode3);
                        paraEmployAnalysCode4.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode4);
                        paraEmployAnalysCode5.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode5);
                        paraEmployAnalysCode6.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.EmployAnalysCode6);
                        // 2008.11.10 add start --------------------------------------------->>
                        paraUOESnmDiv.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UOESnmDiv);
                        // 2008.11.10 add end -----------------------------------------------<<
                        // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(employeeDtlWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(employeeDtlWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.MailSendCode1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(employeeDtlWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(employeeDtlWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.MailSendCode2);
                        // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // 2008.05.26 del start --------------------------------------------->>
                        //paraOldBelongSectionCd.Value = SqlDataMediator.SqlSetString(employeeDtlWork.OldBelongSectionCd);
                        //paraOldBelongSectionNm.Value = SqlDataMediator.SqlSetString(employeeDtlWork.OldBelongSectionNm);
                        //paraOldBelongSubSecCd.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.OldBelongSubSecCd);
                        //paraOldBelongSubSecNm.Value = SqlDataMediator.SqlSetString(employeeDtlWork.OldBelongSubSecNm);
                        //paraOldBelongMinSecCd.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.OldBelongMinSecCd);
                        //paraOldBelongMinSecNm.Value = SqlDataMediator.SqlSetString(employeeDtlWork.OldBelongMinSecNm);
                        //paraSectionChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeDtlWork.SectionChgDate);
                        // 2008.05.26 del end -----------------------------------------------<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(employeeDtlWork);
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

            employeeDtlWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の従業員詳細マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="employeeDtlWork">検索結果</param>
        /// <param name="parseEmployeeDtlWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員詳細マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int Search(out object employeeDtlWork, object parseEmployeeDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            employeeDtlWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchEmployeeProc(out employeeDtlWork, parseEmployeeDtlWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDtlDB.Search");
                employeeDtlWork = new ArrayList();
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
        /// 指定された条件の従業員詳細マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objEmployeeDtlWork">検索結果</param>
        /// <param name="paraEmployeeDtlWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員詳細マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int SearchEmployeeProc(out object objEmployeeDtlWork, object paraEmployeeDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            EmployeeDtlWork EmployeeDtlWork = null;

            ArrayList EmployeeDtlWorkList = paraEmployeeDtlWork as ArrayList;
            if (EmployeeDtlWorkList == null)
            {
                EmployeeDtlWork = paraEmployeeDtlWork as EmployeeDtlWork;
            }
            else
            {
                if (EmployeeDtlWorkList.Count > 0)
                    EmployeeDtlWork = EmployeeDtlWorkList[0] as EmployeeDtlWork;
            }

            int status = SearchEmployeeProc(out EmployeeDtlWorkList, EmployeeDtlWork, readMode, logicalMode, ref sqlConnection);
            objEmployeeDtlWork = EmployeeDtlWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の従業員詳細マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="employeeDtlWorkList">検索結果</param>
        /// <param name="employeeDtlWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int SearchEmployeeProc( out ArrayList employeeDtlWorkList, EmployeeDtlWork employeeDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            return this.SearchEmployeeProcProc(out employeeDtlWorkList, employeeDtlWork, readMode, logicalMode,ref sqlConnection);
        }
        /// <summary>
        /// 指定された条件の従業員詳細マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="employeeDtlWorkList">検索結果</param>
        /// <param name="employeeDtlWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        private int SearchEmployeeProcProc(out ArrayList employeeDtlWorkList, EmployeeDtlWork employeeDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                // 2008.05.26 del start --------------------------------------------->>
                //sqlText += " ,BELONGSUBSECTIONNAMERF" + Environment.NewLine;
                //sqlText += " ,BELONGMINSECTIONCODERF" + Environment.NewLine;
                //sqlText += " ,BELONGMINSECTIONNAMERF" + Environment.NewLine;
                //sqlText += " ,BELONGSALESAREACODERF" + Environment.NewLine;
                //sqlText += " ,BELONGSALESAREANAMERF" + Environment.NewLine;
                // 2008.05.26 del end -----------------------------------------------<<
                sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                // 2008.11.10 add start --------------------------------------------->>
                sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                // 2008.11.10 add end -----------------------------------------------<<
                // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2008.05.26 del start --------------------------------------------->>
                //sqlText += " ,OLDBELONGSECTIONCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSECTIONNMRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSUBSECCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSUBSECNMRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGMINSECCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGMINSECNMRF" + Environment.NewLine;
                //sqlText += " ,SECTIONCHGDATERF" + Environment.NewLine;
                // 2008.05.26 del end -----------------------------------------------<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, employeeDtlWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToEmployeeDtlWorkFromReader(ref myReader));

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

            employeeDtlWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 従業員詳細マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="employeeDtlWork">EmployeeDtlWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int LogicalDelete(ref object employeeDtlWork)
        {
            return LogicalDeleteEmployee(ref employeeDtlWork, 0);
        }

        /// <summary>
        /// 論理削除従業員詳細マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="employeeDtlWork">EmployeeDtlWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除従業員詳細マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int RevivalLogicalDelete(ref object employeeDtlWork)
        {
            return LogicalDeleteEmployee(ref employeeDtlWork, 1);
        }

        /// <summary>
        /// 従業員詳細マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="employeeDtlWork">EmployeeDtlWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        private int LogicalDeleteEmployee(ref object employeeDtlWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(employeeDtlWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteEmployeeProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "EmployeeDtlDB.LogicalDeleteEmployee :" + procModestr);

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
        /// 従業員詳細マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeDtlWorkList">EmployeeDtlWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int LogicalDeleteEmployeeProc( ref ArrayList employeeDtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            return LogicalDeleteEmployeeProcProc(ref employeeDtlWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 従業員詳細マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeDtlWorkList">EmployeeDtlWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        private int LogicalDeleteEmployeeProcProc(ref ArrayList employeeDtlWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = "";

            try
            {
                if (employeeDtlWorkList != null)
                {
                    for (int i = 0; i < employeeDtlWorkList.Count; i++)
                    {
                        EmployeeDtlWork employeeDtlWork = employeeDtlWorkList[i] as EmployeeDtlWork;

                        //Selectコマンドの生成
                        sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                        findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != employeeDtlWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //Selectコマンドの生成
                            sqlText = "";
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                            findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeDtlWork;
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
                            else if (logicalDelCd == 0) employeeDtlWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else employeeDtlWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) employeeDtlWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeDtlWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(employeeDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(employeeDtlWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(employeeDtlWork);
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

            employeeDtlWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 従業員詳細マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">従業員詳細マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 従業員詳細マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
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

                status = DeleteEmployeeProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmployeeDtlDB.Delete");
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
        /// 従業員詳細マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">従業員詳細マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 従業員詳細マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
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

                status = DeleteEmployeeProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmployeeDtlDB.Delete");
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
        /// 従業員詳細マスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeDtlWorkList">従業員詳細マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 従業員詳細マスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int DeleteEmployeeProc(ArrayList employeeDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteEmployeeProcProc(employeeDtlWorkList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 従業員詳細マスタ戻りデータ情報を物理削除します(らのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="employeeDtlWorkList">従業員詳細マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 従業員詳細マスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        private int DeleteEmployeeProcProc(ArrayList employeeDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";
            try
            {

                for (int i = 0; i < employeeDtlWorkList.Count; i++)
                {
                    EmployeeDtlWork employeeDtlWork = employeeDtlWorkList[i] as EmployeeDtlWork;

                    sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                    findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != employeeDtlWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                        findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EmployeeCode);
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

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        public int GetSyncdataList( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,BELONGSUBSECTIONCODERF" + Environment.NewLine;
                // 2008.05.26 del start --------------------------------------------->>
                //sqlText += " ,BELONGSUBSECTIONNAMERF" + Environment.NewLine;
                //sqlText += " ,BELONGMINSECTIONCODERF" + Environment.NewLine;
                //sqlText += " ,BELONGMINSECTIONNAMERF" + Environment.NewLine;
                //sqlText += " ,BELONGSALESAREACODERF" + Environment.NewLine;
                //sqlText += " ,BELONGSALESAREANAMERF" + Environment.NewLine;
                // 2008.05.26 del end -----------------------------------------------<<
                sqlText += " ,EMPLOYANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,EMPLOYANALYSCODE6RF" + Environment.NewLine;
                // 2008.11.10 add start --------------------------------------------->>
                sqlText += " ,UOESNMDIVRF" + Environment.NewLine;
                // 2008.11.10 add end -----------------------------------------------<<
                // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2008.05.26 del start --------------------------------------------->>
                //sqlText += " ,OLDBELONGSECTIONCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSECTIONNMRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSUBSECCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGSUBSECNMRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGMINSECCDRF" + Environment.NewLine;
                //sqlText += " ,OLDBELONGMINSECNMRF" + Environment.NewLine;
                //sqlText += " ,SECTIONCHGDATERF" + Environment.NewLine;
                // 2008.05.26 del end -----------------------------------------------<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  EMPLOYEEDTLRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToEmployeeDtlWorkFromReader(ref myReader));
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

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
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

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="EmployeeDtlWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        /// </remarks>
        private string MakeWhereString( ref SqlCommand sqlCommand, EmployeeDtlWork EmployeeDtlWork, ConstantManagement.LogicalMode logicalMode )
        {
            string wkstring = "";
            string retstring = "WHERE " + Environment.NewLine;

            //企業コード
            retstring += "  ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(EmployeeDtlWork.EnterpriseCode);

            // 従業員コード
            if (IsValidParameter(EmployeeDtlWork.EmployeeCode))
            {
                retstring += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(EmployeeDtlWork.EmployeeCode);
            }
            else
            {
                retstring += "  AND EMPLOYEECODERF = EMPLOYEECODERF" + Environment.NewLine;
            }

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        private string MakeSyncWhereString( ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork )
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += "ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF >= @FINDUPDATEDATETIMEST " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }

        /// <summary>
        /// stringが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter( string value )
        {
            return !String.IsNullOrEmpty(value);
        }
        /// <summary>
        /// intが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter( int value, bool includeZero )
        {
            if (includeZero)
                return value >= 0;
            return value > 0;
        }
        /// <summary>
        /// DateTimeが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter( DateTime value )
        {
            return value > DateTime.MinValue;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            EmployeeDtlWork[] EmployeeDtlWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is EmployeeDtlWork)
                    {
                        EmployeeDtlWork wkEmployeeDtlWork = paraobj as EmployeeDtlWork;
                        if (wkEmployeeDtlWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkEmployeeDtlWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            EmployeeDtlWorkArray = (EmployeeDtlWork[])XmlByteSerializer.Deserialize(byteArray, typeof(EmployeeDtlWork[]));
                        }
                        catch (Exception) { }
                        if (EmployeeDtlWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(EmployeeDtlWorkArray);
                        }
                        else
                        {
                            try
                            {
                                EmployeeDtlWork wkEmployeeDtlWork = (EmployeeDtlWork)XmlByteSerializer.Deserialize(byteArray, typeof(EmployeeDtlWork));
                                if (wkEmployeeDtlWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkEmployeeDtlWork);
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

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → EmployeeDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmployeeDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.16</br>
        /// </remarks>
        private EmployeeDtlWork CopyToEmployeeDtlWorkFromReader( ref SqlDataReader myReader )
        {
            EmployeeDtlWork wkEmployeeDtlWork = new EmployeeDtlWork();

            #region クラスへ格納
            wkEmployeeDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEmployeeDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEmployeeDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEmployeeDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEmployeeDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEmployeeDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEmployeeDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEmployeeDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

            wkEmployeeDtlWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkEmployeeDtlWork.BelongSubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BELONGSUBSECTIONCODERF"));
            // 2008.05.26 del start --------------------------------------------->>
            //wkEmployeeDtlWork.BelongSubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSUBSECTIONNAMERF"));
            //wkEmployeeDtlWork.BelongMinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BELONGMINSECTIONCODERF"));
            //wkEmployeeDtlWork.BelongMinSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGMINSECTIONNAMERF"));
            //wkEmployeeDtlWork.BelongSalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BELONGSALESAREACODERF"));
            //wkEmployeeDtlWork.BelongSalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSALESAREANAMERF"));
            // 2008.05.26 del end -----------------------------------------------<<
            wkEmployeeDtlWork.EmployAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE1RF"));
            wkEmployeeDtlWork.EmployAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE2RF"));
            wkEmployeeDtlWork.EmployAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE3RF"));
            wkEmployeeDtlWork.EmployAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE4RF"));
            wkEmployeeDtlWork.EmployAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE5RF"));
            wkEmployeeDtlWork.EmployAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE6RF"));
            // 2008.11.10 add start --------------------------------------------->>
            wkEmployeeDtlWork.UOESnmDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESNMDIVRF"));
            // 2008.11.10 add end -----------------------------------------------<<
            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            wkEmployeeDtlWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
            wkEmployeeDtlWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
            wkEmployeeDtlWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
            wkEmployeeDtlWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
            wkEmployeeDtlWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
            wkEmployeeDtlWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
            wkEmployeeDtlWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
            wkEmployeeDtlWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2008.05.26 del start --------------------------------------------->>
            //wkEmployeeDtlWork.OldBelongSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDBELONGSECTIONCDRF"));
            //wkEmployeeDtlWork.OldBelongSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDBELONGSECTIONNMRF"));
            //wkEmployeeDtlWork.OldBelongSubSecCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDBELONGSUBSECCDRF"));
            //wkEmployeeDtlWork.OldBelongSubSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDBELONGSUBSECNMRF"));
            //wkEmployeeDtlWork.OldBelongMinSecCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OLDBELONGMINSECCDRF"));
            //wkEmployeeDtlWork.OldBelongMinSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDBELONGMINSECNMRF"));
            //wkEmployeeDtlWork.SectionChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SECTIONCHGDATERF"));
            // 2008.05.26 del end -----------------------------------------------<<
            #endregion

            return wkEmployeeDtlWork;
        }
        #endregion

    }
}