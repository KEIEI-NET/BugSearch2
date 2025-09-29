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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// 従業員LCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員LCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20098　村瀬　勝也</br>
    /// <br>Date       : 2007.04.05</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.15 山田 明友</br>
    /// <br>           : 権限レベル1・権限レベル2の追加</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.29 20081 疋田 勇人</br>
    /// <br>           : PM.NS用に変更</br>
    /// <br></br>
        /// </remarks>
    public class EmployeeLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 従業員LCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        /// </remarks>
        public EmployeeLcDB()
        {
        }


        /// <summary>
        /// 指定された企業コードの従業員LISTの件数を戻します
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="parabyte">検索パラメータ(readMode=0:EmployeeWorkクラス：企業コード)</param>	
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int SearchCnt(out int retCnt, EmployeeWork parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                return SearchCntProc(out retCnt, parabyte, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeLcDB.SearchCnt Exception=" + ex.Message, 0);
                retCnt = 0;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// 指定された企業コードの従業員LISTの件数を戻します
        /// </summary>
        /// <param name="parabyte">検索パラメータ(readMode=0:EmployeeWorkクラス：企業コード)</param>
        /// <param name="retCnt">検索結果</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchCntProc(out int retCnt, EmployeeWork parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            EmployeeWork employeeWork = null;

            retCnt = 0;
            string sqlTxt = string.Empty; // 2008.05.29 add

            ArrayList al = new ArrayList();
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                //コネクション文字列取得対応↑↑↑↑↑

                // paraデータの読み込み
                employeeWork = parabyte;

                //SQL文生成
                sqlConnection.Open();

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    // 2008.05.29 upd start --------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end -----------------------------------<<
                    //論理削除区分設定
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    // 2008.05.29 upd start --------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end -----------------------------------<<
                    //論理削除区分設定
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    // 2008.05.29 upd start --------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                    sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                    sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.29 upd end -----------------------------------<<
                }
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

                //データリード
                retCnt = (int)sqlCommand.ExecuteScalar();
                if (retCnt > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeLcDB.SearchCnt", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された企業コードの従業員LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="employeeWork">検索結果</param>
        /// <param name="paraemployeeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int Search(out List<EmployeeWork> employeeWork, EmployeeWork paraemployeeWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                bool nextData;
                int retTotalCnt;
                return SearchProc(out employeeWork, out retTotalCnt, out nextData, paraemployeeWork, readMode, logicalMode, 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeLcDB.Search Exception=" + ex.Message, 0);
                employeeWork = new List<EmployeeWork>();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// 指定された企業コードの従業員LISTを指定件数分全て戻します（論理削除除く）
        /// </summary>
        /// <param name="employeeWork">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="paraemployeeWork">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">検索件数</param>		
        /// <returns>STATUS</returns>
        public int SearchSpecification(out List<EmployeeWork> employeeWork, out int retTotalCnt, out bool nextData, EmployeeWork paraemployeeWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            try
            {
                return SearchProc(out employeeWork, out retTotalCnt, out nextData, paraemployeeWork, readMode, logicalMode, readCnt);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeLcDB.SearchSpecification Exception=" + ex.Message, 0);
                employeeWork = new List<EmployeeWork>();
                nextData = false;
                retTotalCnt = 0;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// 指定された企業コードの従業員LISTを全て戻します
        /// </summary>
        /// <param name="objemployeeWork">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>		
        /// <param name="nextData">次データ有無</param>
        /// <param name="paraemployeeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <returns>STATUS</returns>
        private int SearchProc(out List<EmployeeWork> objemployeeWork, out int retTotalCnt, out bool nextData, EmployeeWork paraemployeeWork, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommandCount = null;
            SqlCommand sqlCommand = null;

            EmployeeWork employeeWork = new EmployeeWork();
            employeeWork = null;

            objemployeeWork = null;

            //総件数を0で初期化
            retTotalCnt = 0;

            //件数指定リードの場合には指定件数＋１件リードする
            int _readCnt = readCnt;
            if (_readCnt > 0) _readCnt += 1;
            //次レコード無しで初期化
            nextData = false;

            string sqlTxt = string.Empty; // 2008.05.29 add

            List<EmployeeWork> listdata = new List<EmployeeWork>();
            
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                //コネクション文字列取得対応↑↑↑↑↑

                employeeWork = paraemployeeWork;

                //SQL文生成
                sqlConnection.Open();

                //件数指定リードで一件目リードの場合データ総件数を取得
                if ((readCnt > 0) && ((employeeWork.EmployeeCode == null) || (employeeWork.EmployeeCode == "")))
                {
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        // 2008.05.29 upd start -------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end ----------------------------------------<<
                        //論理削除区分設定
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                                (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        // 2008.05.29 upd start -------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end ----------------------------------------<<
                        //論理削除区分設定
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        // 2008.05.29 upd start -------------------------------------->>
                        //sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
                        sqlTxt += "SELECT COUNT (*)" + Environment.NewLine;
                        sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommandCount = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end ----------------------------------------<<
                    }
                    SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

                    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                }
                sqlTxt = string.Empty; // 2008.05.29 add

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        // 2008.05.29 upd start -------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                        sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end ----------------------------------------<<
                    }
                    else
                    {
                        //一件目リードの場合
                        if ((employeeWork.EmployeeCode == null) || (employeeWork.EmployeeCode == ""))
                        {
                            // 2008.05.29 upd start -------------------------------------->>
                            //sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                            sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end ----------------------------------------<<
                        }
                        //Nextリードの場合
                        else
                        {
                            // 2008.05.29 upd start -------------------------------------->>
                            //sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                            sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF>@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end ----------------------------------------<<
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                            paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        // 2008.05.29 upd start -------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                        sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end ----------------------------------------<<
                    }
                    else
                    {
                        //一件目リードの場合
                        if ((employeeWork.EmployeeCode == null) || (employeeWork.EmployeeCode == ""))
                        {
                            // 2008.05.29 upd start -------------------------------------->>
                            //sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                            sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end ----------------------------------------<<
                        }
                        //Nextリードの場合
                        else
                        {
                            // 2008.05.29 upd start -------------------------------------->>
                            //sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                            sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF<@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end ----------------------------------------<<
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                            paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        // 2008.05.29 upd start -------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,NAMERF" + Environment.NewLine;
                        sqlTxt += "    ,KANARF" + Environment.NewLine;
                        sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                        sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                        sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                        sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                        sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                        sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                        sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                        sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                        sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                        sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                        sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                        sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                        sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                        sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.29 upd end ----------------------------------------<<
                    }
                    else
                    {
                        //一件目リードの場合
                        if ((employeeWork.EmployeeCode == null) || (employeeWork.EmployeeCode == ""))
                        {
                            // 2008.05.29 upd start -------------------------------------->>
                            //sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                            sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end ----------------------------------------<<
                        }
                        else
                        {
                            // 2008.05.29 upd start -------------------------------------->>
                            //sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF>@FINDEMPLOYEECODE ORDER BY EMPLOYEECODERF", sqlConnection);
                            sqlTxt += "SELECT TOP" + Environment.NewLine;
                            sqlTxt += _readCnt.ToString() + Environment.NewLine;
                            sqlTxt += "    ,CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,NAMERF" + Environment.NewLine;
                            sqlTxt += "    ,KANARF" + Environment.NewLine;
                            sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                            sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                            sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                            sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                            sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                            sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                            sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                            sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                            sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                            sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                            sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                            sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND EMPLOYEECODERF>@FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " ORDER BY EMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                            // 2008.05.29 upd end ----------------------------------------<<
                            SqlParameter paraEmployeeCode2 = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                            paraEmployeeCode2.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
                        }
                    }
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int retCnt = 0;
                while (myReader.Read())
                {
                    //戻り値カウンタカウント
                    retCnt += 1;
                    if (readCnt > 0)
                    {
                        //戻り値の件数が取得指示件数を超えた場合終了
                        if (readCnt < retCnt)
                        {
                            nextData = true;
                            break;
                        }
                    }
                    EmployeeWork wkEmployeeWork = new EmployeeWork();

                    wkEmployeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkEmployeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkEmployeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkEmployeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkEmployeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkEmployeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkEmployeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkEmployeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkEmployeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    wkEmployeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    wkEmployeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                    wkEmployeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                    wkEmployeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                    wkEmployeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                    wkEmployeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                    wkEmployeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                    wkEmployeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                    wkEmployeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                    wkEmployeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                    wkEmployeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                    wkEmployeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                    wkEmployeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                    wkEmployeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                    wkEmployeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                    wkEmployeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                    wkEmployeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                    wkEmployeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                    wkEmployeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                    wkEmployeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                    wkEmployeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                    wkEmployeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                    // ↓ 2008.02.15 980081 a
                    wkEmployeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                    wkEmployeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                    // ↑ 2008.02.15 980081 a

                    listdata.Add(wkEmployeeWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeLcDB.SearchProc", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objemployeeWork = listdata;

            return status;

        }

        /// <summary>
        /// 指定された従業員Guidの従業員を戻します
        /// </summary>
        /// <param name="parabyte">EmployeeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        public int Read(ref EmployeeWork parabyte, int readMode)
        {
            try
            {
                EmployeeWork employeeWork = parabyte;

                int status = ReadProc(ref employeeWork, readMode);

                parabyte = employeeWork;

                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeDB.Read Exception=" + ex.Message, 0);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }


        /// <summary>
        /// 指定された従業員Guidの従業員を戻します
        /// </summary>
        /// <param name="employeeWork">EmployeeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        private int ReadProc(ref EmployeeWork employeeWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                //コネクション文字列取得対応↑↑↑↑↑


                sqlConnection.Open();

                // 2008.05.29 upd start -------------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                sqlTxt += "    ,KANARF" + Environment.NewLine;
                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 upd end ----------------------------------------<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

                //ログインＩＤが入っていたら
                if (employeeWork.LoginId != "")
                {
                    sqlCommand.CommandText += "AND LOGINIDRF=@FINDLOGINID";
                    SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);
                    findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
                }
                else
                {
                    sqlCommand.CommandText += "AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                    findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
                }

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read())
                {
                    employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    employeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    employeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                    employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                    employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                    employeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                    employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                    employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                    employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                    employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                    employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                    employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                    employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                    employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                    employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                    employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                    employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                    employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                    employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                    employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                    employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                    employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                    employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                    // ↓ 2008.02.15 980081 a
                    employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                    employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                    // ↑ 2008.02.15 980081 a

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeLcDB.ReadProc", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された従業員Guidの従業員を戻します
        /// </summary>
        /// <param name="employeeWork">EmployeeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        public int Read(ref EmployeeWork employeeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref employeeWork, readMode,  ref sqlConnection);
            return status;
        }


        /// <summary>
        /// 指定された従業員Guidの従業員を戻します
        /// </summary>
        /// <param name="employeeWork">EmployeeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        private int ReadProcProc(ref EmployeeWork employeeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                // 2008.05.29 add start -------------------------------->>
                //SqlCommand sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                sqlTxt += "    ,KANARF" + Environment.NewLine;
                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.29 add end ----------------------------------<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);

                //ログインＩＤが入っていたら
                if (employeeWork.LoginId != "")
                {
                    sqlCommand.CommandText += "AND LOGINIDRF=@FINDLOGINID";
                    SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);
                    findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
                }
                else
                {
                    sqlCommand.CommandText += "AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                    findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
                }

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    employeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    employeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                    employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                    employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                    employeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                    employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                    employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                    employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                    employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                    employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                    employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                    employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                    employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                    employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                    employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                    employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                    employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                    employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                    employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                    employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                    employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                    employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                    // ↓ 2008.02.15 980081 a
                    employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                    employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                    // ↑ 2008.02.15 980081 a

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeLcDB.Read", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeLcDB.Read Exception=" + ex.Message, 0);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            myReader.Close();

            return status;
        }

        /// <summary>
        /// 複数件数指定された企業コード、従業員コードの従業員情報を戻します
        /// </summary>
        /// <param name="retList">検索結果List</param>
        /// <param name="paraList">検索条件List</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        public int ReadList(out List<EmployeeWork> retList, List<EmployeeWork> paraList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            status = ReadListProc(out retList, paraList, readMode);

            return status;
        }


        /// <summary>
        /// 複数件数指定された企業コード、従業員コードの従業員情報を戻します
        /// </summary>
        /// <param name="retList">検索結果List</param>
        /// <param name="paraList">検索条件List</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        private int ReadListProc(out List<EmployeeWork> retList, List<EmployeeWork> paraList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            EmployeeWork employeeWork = null;
            retList = new List<EmployeeWork>();
            List<EmployeeWork> listdata = new List<EmployeeWork>();
            string sqlTxt = string.Empty; // 2008.05.29 add

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                foreach (EmployeeWork item in paraList)
                {
                    // 2008.05.29 upd start ------------------------------->> 
                    //SqlCommand sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE "
                    //    + "AND EMPLOYEECODERF=@FINDEMPLOYEECODE ", sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,NAMERF" + Environment.NewLine;
                    sqlTxt += "    ,KANARF" + Environment.NewLine;
                    sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                    sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                    sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                    sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                    sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                    sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                    sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                    sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                    sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                    sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                    sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                    sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                    sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                    sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                    SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    sqlTxt = string.Empty;
                    // 2008.05.29 upd end ---------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);
                    findParaEmployeecode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        employeeWork = new EmployeeWork();
                        employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        employeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                        employeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                        employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                        employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                        employeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                        employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                        employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                        employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                        employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                        employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                        employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                        employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                        employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                        employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                        employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                        employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                        employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                        employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                        employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                        employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                        employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                        employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                        // ↓ 2008.02.15 980081 a
                        employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                        employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));
                        // ↑ 2008.02.15 980081 a
                        listdata.Add(employeeWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader.IsClosed == false) myReader.Close();
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeLcDB.ReadList", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeLcDB.ReadList Exception=" + ex.Message, 0);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (myReader.IsClosed == false) myReader.Close();
            sqlConnection.Close();

            retList = listdata;
            return status;
        }

        #region [WriteSyncLocalData]
        /// <summary>
        /// ユーザデータシンク管理マスタ情報を登録、更新します
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        public int WriteSyncLocalData(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList syncDataList = new ArrayList();
            try
            {
                if (syncServiceWork == null) return status;
                if (paraSyncDataList == null) return status;

                //使用するパラメータのキャスト
                EmployeeWork employeeWork = new EmployeeWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == employeeWork.GetType())
                    {
                        break;
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                //dataSyncMngWorkList = syncDataList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "EmployeeLcDB.WriteSyncLocalData", 0);
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
        /// ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        public int WriteSyncLocalDataProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList syncDataList = new ArrayList();

            status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);

            return status;
        }


        /// <summary>
        /// ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.29 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.29 upd start ------------------------------------>>
                        //sqlCommand = new SqlCommand("DELETE FROM EMPLOYEERF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.29 upd end --------------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        EmployeeWork employeeWork = paraSyncDataList[i] as EmployeeWork;

                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // 2008.05.29 upd start ------------------------------------>>
                                //sqlCommand = new SqlCommand("SELECT * FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                                sqlTxt += "    ,KANARF" + Environment.NewLine;
                                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
                                sqlTxt += " FROM EMPLOYEERF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.29 upd end --------------------------------------<<
                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                                SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);

                                //Parameterオブジェクトへ値設定
                                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
                                findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
                                findParaLoginId.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    // ↓ 2008.02.15 980081 c
                                    //sqlCommand.CommandText = "UPDATE EMPLOYEERF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , EMPLOYEECODERF=@EMPLOYEECODE , NAMERF=@NAME , KANARF=@KANA , SHORTNAMERF=@SHORTNAME , SEXCODERF=@SEXCODE , SEXNAMERF=@SEXNAME , BIRTHDAYRF=@BIRTHDAY , COMPANYTELNORF=@COMPANYTELNO , PORTABLETELNORF=@PORTABLETELNO , POSTCODERF=@POSTCODE , BUSINESSCODERF=@BUSINESSCODE , FRONTMECHACODERF=@FRONTMECHACODE , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE , BELONGSECTIONCODERF=@BELONGSECTIONCODE , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR , LOGINIDRF=@LOGINID , LOGINPASSWORDRF=@LOGINPASSWORD , USERADMINFLAGRF=@USERADMINFLAG , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE , RETIREMENTDATERF=@RETIREMENTDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                                    // 2008.05.29 upd start ------------------------------------>>
                                    //sqlCommand.CommandText = "UPDATE EMPLOYEERF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , EMPLOYEECODERF=@EMPLOYEECODE , NAMERF=@NAME , KANARF=@KANA , SHORTNAMERF=@SHORTNAME , SEXCODERF=@SEXCODE , SEXNAMERF=@SEXNAME , BIRTHDAYRF=@BIRTHDAY , COMPANYTELNORF=@COMPANYTELNO , PORTABLETELNORF=@PORTABLETELNO , POSTCODERF=@POSTCODE , BUSINESSCODERF=@BUSINESSCODE , FRONTMECHACODERF=@FRONTMECHACODE , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE , BELONGSECTIONCODERF=@BELONGSECTIONCODE , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR , LOGINIDRF=@LOGINID , LOGINPASSWORDRF=@LOGINPASSWORD , USERADMINFLAGRF=@USERADMINFLAG , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE , RETIREMENTDATERF=@RETIREMENTDATE , AUTHORITYLEVEL1RF=@AUTHORITYLEVEL1 , AUTHORITYLEVEL2RF=@AUTHORITYLEVEL2 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE EMPLOYEERF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , NAMERF=@NAME" + Environment.NewLine;
                                    sqlTxt += " , KANARF=@KANA" + Environment.NewLine;
                                    sqlTxt += " , SHORTNAMERF=@SHORTNAME" + Environment.NewLine;
                                    sqlTxt += " , SEXCODERF=@SEXCODE" + Environment.NewLine;
                                    sqlTxt += " , SEXNAMERF=@SEXNAME" + Environment.NewLine;
                                    sqlTxt += " , BIRTHDAYRF=@BIRTHDAY" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELNORF=@COMPANYTELNO" + Environment.NewLine;
                                    sqlTxt += " , PORTABLETELNORF=@PORTABLETELNO" + Environment.NewLine;
                                    sqlTxt += " , POSTCODERF=@POSTCODE" + Environment.NewLine;
                                    sqlTxt += " , BUSINESSCODERF=@BUSINESSCODE" + Environment.NewLine;
                                    sqlTxt += " , FRONTMECHACODERF=@FRONTMECHACODE" + Environment.NewLine;
                                    sqlTxt += " , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE" + Environment.NewLine;
                                    sqlTxt += " , BELONGSECTIONCODERF=@BELONGSECTIONCODE" + Environment.NewLine;
                                    sqlTxt += " , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL" + Environment.NewLine;
                                    sqlTxt += " , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT" + Environment.NewLine;
                                    sqlTxt += " , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT" + Environment.NewLine;
                                    sqlTxt += " , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR" + Environment.NewLine;
                                    sqlTxt += " , LOGINIDRF=@LOGINID" + Environment.NewLine;
                                    sqlTxt += " , LOGINPASSWORDRF=@LOGINPASSWORD" + Environment.NewLine;
                                    sqlTxt += " , USERADMINFLAGRF=@USERADMINFLAG" + Environment.NewLine;
                                    sqlTxt += " , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE" + Environment.NewLine;
                                    sqlTxt += " , RETIREMENTDATERF=@RETIREMENTDATE" + Environment.NewLine;
                                    sqlTxt += " , AUTHORITYLEVEL1RF=@AUTHORITYLEVEL1" + Environment.NewLine;
                                    sqlTxt += " , AUTHORITYLEVEL2RF=@AUTHORITYLEVEL2" + Environment.NewLine;
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.29 upd end --------------------------------------<<
                                    // ↑ 2008.02.15 980081 c
                                    //KEYコマンドを再設定
                                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
                                    findParaEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);

                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)employeeWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //新規作成時のSQL文を生成
                                    // ↓ 2008.02.15 980081 c
                                    //sqlCommand.CommandText = "INSERT INTO EMPLOYEERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @NAME, @KANA, @SHORTNAME, @SEXCODE, @SEXNAME, @BIRTHDAY, @COMPANYTELNO, @PORTABLETELNO, @POSTCODE, @BUSINESSCODE, @FRONTMECHACODE, @INOUTSIDECOMPANYCODE, @BELONGSECTIONCODE, @LVRRTCSTGENERAL, @LVRRTCSTCARINSPECT, @LVRRTCSTBODYPAINT, @LVRRTCSTBODYREPAIR, @LOGINID, @LOGINPASSWORD, @USERADMINFLAG, @ENTERCOMPANYDATE, @RETIREMENTDATE)";
                                    // 2008.05.29 upd start ------------------------------------>>
                                    //sqlCommand.CommandText = "INSERT INTO EMPLOYEERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF, AUTHORITYLEVEL1RF, AUTHORITYLEVEL2RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @NAME, @KANA, @SHORTNAME, @SEXCODE, @SEXNAME, @BIRTHDAY, @COMPANYTELNO, @PORTABLETELNO, @POSTCODE, @BUSINESSCODE, @FRONTMECHACODE, @INOUTSIDECOMPANYCODE, @BELONGSECTIONCODE, @LVRRTCSTGENERAL, @LVRRTCSTCARINSPECT, @LVRRTCSTBODYPAINT, @LVRRTCSTBODYREPAIR, @LOGINID, @LOGINPASSWORD, @USERADMINFLAG, @ENTERCOMPANYDATE, @RETIREMENTDATE, @AUTHORITYLEVEL1, @AUTHORITYLEVEL2)";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO EMPLOYEERF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,NAMERF" + Environment.NewLine;
                                    sqlTxt += "    ,KANARF" + Environment.NewLine;
                                    sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                                    sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                                    sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                                    sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                                    sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                                    sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                                    sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                                    sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                                    sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                                    sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                                    sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                                    sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                                    sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
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
                                    sqlTxt += "    ,@EMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@NAME" + Environment.NewLine;
                                    sqlTxt += "    ,@KANA" + Environment.NewLine;
                                    sqlTxt += "    ,@SHORTNAME" + Environment.NewLine;
                                    sqlTxt += "    ,@SEXCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@SEXNAME" + Environment.NewLine;
                                    sqlTxt += "    ,@BIRTHDAY" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELNO" + Environment.NewLine;
                                    sqlTxt += "    ,@PORTABLETELNO" + Environment.NewLine;
                                    sqlTxt += "    ,@POSTCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@BUSINESSCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@FRONTMECHACODE" + Environment.NewLine;
                                    sqlTxt += "    ,@INOUTSIDECOMPANYCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@BELONGSECTIONCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@LVRRTCSTGENERAL" + Environment.NewLine;
                                    sqlTxt += "    ,@LVRRTCSTCARINSPECT" + Environment.NewLine;
                                    sqlTxt += "    ,@LVRRTCSTBODYPAINT" + Environment.NewLine;
                                    sqlTxt += "    ,@LVRRTCSTBODYREPAIR" + Environment.NewLine;
                                    sqlTxt += "    ,@LOGINID" + Environment.NewLine;
                                    sqlTxt += "    ,@LOGINPASSWORD" + Environment.NewLine;
                                    sqlTxt += "    ,@USERADMINFLAG" + Environment.NewLine;
                                    sqlTxt += "    ,@ENTERCOMPANYDATE" + Environment.NewLine;
                                    sqlTxt += "    ,@RETIREMENTDATE" + Environment.NewLine;
                                    sqlTxt += "    ,@AUTHORITYLEVEL1" + Environment.NewLine;
                                    sqlTxt += "    ,@AUTHORITYLEVEL2" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.29 upd end --------------------------------------<<
                                    // ↑ 2008.02.15 980081 c
                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)employeeWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //新規作成時のSQL文を生成
                                // ↓ 2008.02.15 980081 c
                                //sqlCommand = new SqlCommand("INSERT INTO EMPLOYEERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @NAME, @KANA, @SHORTNAME, @SEXCODE, @SEXNAME, @BIRTHDAY, @COMPANYTELNO, @PORTABLETELNO, @POSTCODE, @BUSINESSCODE, @FRONTMECHACODE, @INOUTSIDECOMPANYCODE, @BELONGSECTIONCODE, @LVRRTCSTGENERAL, @LVRRTCSTCARINSPECT, @LVRRTCSTBODYPAINT, @LVRRTCSTBODYREPAIR, @LOGINID, @LOGINPASSWORD, @USERADMINFLAG, @ENTERCOMPANYDATE, @RETIREMENTDATE)", sqlConnection, sqlTransaction);
                                // 2008.05.29 upd start ------------------------------------>>
                                //sqlCommand = new SqlCommand("INSERT INTO EMPLOYEERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF, AUTHORITYLEVEL1RF, AUTHORITYLEVEL2RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @NAME, @KANA, @SHORTNAME, @SEXCODE, @SEXNAME, @BIRTHDAY, @COMPANYTELNO, @PORTABLETELNO, @POSTCODE, @BUSINESSCODE, @FRONTMECHACODE, @INOUTSIDECOMPANYCODE, @BELONGSECTIONCODE, @LVRRTCSTGENERAL, @LVRRTCSTCARINSPECT, @LVRRTCSTBODYPAINT, @LVRRTCSTBODYREPAIR, @LOGINID, @LOGINPASSWORD, @USERADMINFLAG, @ENTERCOMPANYDATE, @RETIREMENTDATE, @AUTHORITYLEVEL1, @AUTHORITYLEVEL2)", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "INSERT INTO EMPLOYEERF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,EMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,NAMERF" + Environment.NewLine;
                                sqlTxt += "    ,KANARF" + Environment.NewLine;
                                sqlTxt += "    ,SHORTNAMERF" + Environment.NewLine;
                                sqlTxt += "    ,SEXCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SEXNAMERF" + Environment.NewLine;
                                sqlTxt += "    ,BIRTHDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNORF" + Environment.NewLine;
                                sqlTxt += "    ,PORTABLETELNORF" + Environment.NewLine;
                                sqlTxt += "    ,POSTCODERF" + Environment.NewLine;
                                sqlTxt += "    ,BUSINESSCODERF" + Environment.NewLine;
                                sqlTxt += "    ,FRONTMECHACODERF" + Environment.NewLine;
                                sqlTxt += "    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine;
                                sqlTxt += "    ,BELONGSECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,LVRRTCSTGENERALRF" + Environment.NewLine;
                                sqlTxt += "    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine;
                                sqlTxt += "    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine;
                                sqlTxt += "    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine;
                                sqlTxt += "    ,LOGINIDRF" + Environment.NewLine;
                                sqlTxt += "    ,LOGINPASSWORDRF" + Environment.NewLine;
                                sqlTxt += "    ,USERADMINFLAGRF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERCOMPANYDATERF" + Environment.NewLine;
                                sqlTxt += "    ,RETIREMENTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,AUTHORITYLEVEL1RF" + Environment.NewLine;
                                sqlTxt += "    ,AUTHORITYLEVEL2RF" + Environment.NewLine;
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
                                sqlTxt += "    ,@EMPLOYEECODE" + Environment.NewLine;
                                sqlTxt += "    ,@NAME" + Environment.NewLine;
                                sqlTxt += "    ,@KANA" + Environment.NewLine;
                                sqlTxt += "    ,@SHORTNAME" + Environment.NewLine;
                                sqlTxt += "    ,@SEXCODE" + Environment.NewLine;
                                sqlTxt += "    ,@SEXNAME" + Environment.NewLine;
                                sqlTxt += "    ,@BIRTHDAY" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELNO" + Environment.NewLine;
                                sqlTxt += "    ,@PORTABLETELNO" + Environment.NewLine;
                                sqlTxt += "    ,@POSTCODE" + Environment.NewLine;
                                sqlTxt += "    ,@BUSINESSCODE" + Environment.NewLine;
                                sqlTxt += "    ,@FRONTMECHACODE" + Environment.NewLine;
                                sqlTxt += "    ,@INOUTSIDECOMPANYCODE" + Environment.NewLine;
                                sqlTxt += "    ,@BELONGSECTIONCODE" + Environment.NewLine;
                                sqlTxt += "    ,@LVRRTCSTGENERAL" + Environment.NewLine;
                                sqlTxt += "    ,@LVRRTCSTCARINSPECT" + Environment.NewLine;
                                sqlTxt += "    ,@LVRRTCSTBODYPAINT" + Environment.NewLine;
                                sqlTxt += "    ,@LVRRTCSTBODYREPAIR" + Environment.NewLine;
                                sqlTxt += "    ,@LOGINID" + Environment.NewLine;
                                sqlTxt += "    ,@LOGINPASSWORD" + Environment.NewLine;
                                sqlTxt += "    ,@USERADMINFLAG" + Environment.NewLine;
                                sqlTxt += "    ,@ENTERCOMPANYDATE" + Environment.NewLine;
                                sqlTxt += "    ,@RETIREMENTDATE" + Environment.NewLine;
                                sqlTxt += "    ,@AUTHORITYLEVEL1" + Environment.NewLine;
                                sqlTxt += "    ,@AUTHORITYLEVEL2" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.29 upd end --------------------------------------<<
                                // ↑ 2008.02.15 980081 c
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)employeeWork;
                                fileHeader = new ClientFileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                                break;
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreatedatetime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterprisecode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileheaderguid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdemployeecode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraEmployeecode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraShortname = sqlCommand.Parameters.Add("@SHORTNAME", SqlDbType.NVarChar);
                        SqlParameter paraSexcode = sqlCommand.Parameters.Add("@SEXCODE", SqlDbType.Int);
                        SqlParameter paraSexname = sqlCommand.Parameters.Add("@SEXNAME", SqlDbType.NVarChar);
                        SqlParameter paraBirthday = sqlCommand.Parameters.Add("@BIRTHDAY", SqlDbType.Int);
                        SqlParameter paraCompanytelno = sqlCommand.Parameters.Add("@COMPANYTELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortabletelno = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPostcode = sqlCommand.Parameters.Add("@POSTCODE", SqlDbType.Int);
                        SqlParameter paraBusinesscode = sqlCommand.Parameters.Add("@BUSINESSCODE", SqlDbType.Int);
                        SqlParameter paraFrontmechacode = sqlCommand.Parameters.Add("@FRONTMECHACODE", SqlDbType.Int);
                        SqlParameter paraInoutsidecompanycode = sqlCommand.Parameters.Add("@INOUTSIDECOMPANYCODE", SqlDbType.Int);
                        SqlParameter paraBelongsectioncode = sqlCommand.Parameters.Add("@BELONGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraLvrRtCstGeneral = sqlCommand.Parameters.Add("@LVRRTCSTGENERAL", SqlDbType.BigInt);
                        SqlParameter paraLvrRtCstCarInspect = sqlCommand.Parameters.Add("@LVRRTCSTCARINSPECT", SqlDbType.BigInt);
                        SqlParameter paraLvrRtCstBodyPaint = sqlCommand.Parameters.Add("@LVRRTCSTBODYPAINT", SqlDbType.BigInt);
                        SqlParameter paraLvrRtCstBodyRepair = sqlCommand.Parameters.Add("@LVRRTCSTBODYREPAIR", SqlDbType.BigInt);
                        SqlParameter paraLoginid = sqlCommand.Parameters.Add("@LOGINID", SqlDbType.NVarChar);
                        SqlParameter paraLoginpassword = sqlCommand.Parameters.Add("@LOGINPASSWORD", SqlDbType.NVarChar);
                        SqlParameter paraUserAdminFlag = sqlCommand.Parameters.Add("@USERADMINFLAG", SqlDbType.Int);
                        SqlParameter paraEntercompanydate = sqlCommand.Parameters.Add("@ENTERCOMPANYDATE", SqlDbType.Int);
                        SqlParameter paraRetirementdate = sqlCommand.Parameters.Add("@RETIREMENTDATE", SqlDbType.Int);
                        // ↓ 2008.02.15 980081 a
                        SqlParameter paraAuthorityLevel1 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL1", SqlDbType.Int);
                        SqlParameter paraAuthorityLevel2 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL2", SqlDbType.Int);
                        // ↑ 2008.02.15 980081 a
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.CreateDateTime);
                        paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeWork.UpdateDateTime);
                        paraEnterprisecode.Value = SqlDataMediator.SqlSetString(employeeWork.EnterpriseCode);
                        paraFileheaderguid.Value = SqlDataMediator.SqlSetGuid(employeeWork.FileHeaderGuid);
                        paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.UpdEmployeeCode);
                        paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId1);
                        paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(employeeWork.UpdAssemblyId2);
                        paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(employeeWork.LogicalDeleteCode);
                        paraEmployeecode.Value = SqlDataMediator.SqlSetString(employeeWork.EmployeeCode);
                        paraName.Value = SqlDataMediator.SqlSetString(employeeWork.Name);
                        paraKana.Value = SqlDataMediator.SqlSetString(employeeWork.Kana);
                        paraShortname.Value = SqlDataMediator.SqlSetString(employeeWork.ShortName);
                        paraSexcode.Value = SqlDataMediator.SqlSetInt32(employeeWork.SexCode);
                        paraSexname.Value = SqlDataMediator.SqlSetString(employeeWork.SexName);
                        paraBirthday.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.Birthday);
                        paraCompanytelno.Value = SqlDataMediator.SqlSetString(employeeWork.CompanyTelNo);
                        paraPortabletelno.Value = SqlDataMediator.SqlSetString(employeeWork.PortableTelNo);
                        paraPostcode.Value = SqlDataMediator.SqlSetInt32(employeeWork.PostCode);
                        paraBusinesscode.Value = SqlDataMediator.SqlSetInt32(employeeWork.BusinessCode);
                        paraFrontmechacode.Value = SqlDataMediator.SqlSetInt32(employeeWork.FrontMechaCode);
                        paraInoutsidecompanycode.Value = SqlDataMediator.SqlSetInt32(employeeWork.InOutsideCompanyCode);
                        paraBelongsectioncode.Value = SqlDataMediator.SqlSetString(employeeWork.BelongSectionCode);
                        paraLvrRtCstGeneral.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstGeneral);
                        paraLvrRtCstCarInspect.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstCarInspect);
                        paraLvrRtCstBodyPaint.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstBodyPaint);
                        paraLvrRtCstBodyRepair.Value = SqlDataMediator.SqlSetInt64(employeeWork.LvrRtCstBodyRepair);
                        paraLoginid.Value = SqlDataMediator.SqlSetString(employeeWork.LoginId);
                        paraLoginpassword.Value = SqlDataMediator.SqlSetString(employeeWork.LoginPassword);
                        paraUserAdminFlag.Value = SqlDataMediator.SqlSetInt32(employeeWork.UserAdminFlag);
                        paraEntercompanydate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.EnterCompanyDate);
                        paraRetirementdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(employeeWork.RetirementDate);
                        // ↓ 2008.02.15 980081 a
                        paraAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(employeeWork.AuthorityLevel1);
                        paraAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(employeeWork.AuthorityLevel2);
                        // ↑ 2008.02.15 980081 a
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                    //ユーザデータシンク管理マスタへ更新
                    DataSyncMngWork dataSyncMngWork = new DataSyncMngWork();
                    DataSyncMngLcDB dataSyncMngLcDB = new DataSyncMngLcDB();
                    List<DataSyncMngWork> dataSyncMngWorkList = new List<DataSyncMngWork>();
                    dataSyncMngWork.EnterpriseCode = syncServiceWork.EnterpriseCode;
                    dataSyncMngWork.LastDataUpdDate = syncServiceWork.SyncDateTimeEd;
                    dataSyncMngWork.SyncExecDate = syncServiceWork.SyncExecDate;
                    dataSyncMngWork.ManagementTableName = syncServiceWork.ManagementTableName;
                    dataSyncMngWork.DataDeleteDateTime = syncServiceWork.DataDeleteDateTime;
                    dataSyncMngWorkList.Add(dataSyncMngWork);
                    status = dataSyncMngLcDB.WriteDataSyncMngProc(ref dataSyncMngWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "EmployeeLcDB.WriteSyncLocalDataProc", 0);
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

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
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
