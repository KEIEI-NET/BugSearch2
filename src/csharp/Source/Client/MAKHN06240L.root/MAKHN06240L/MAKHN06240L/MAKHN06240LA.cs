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
    /// 自社名称設定LCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自社名称設定LCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20096　村瀬　勝也</br>
    /// <br>Date       : 2007.05.09</br>
    /// <br></br>
    /// <br>Update Note: 2008.02.05 980081 山田 明友</br>
    /// <br>           : 流通基幹対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.27 20081 疋田 勇人</br>
    /// <br>           : PM.NS用に変更</br>
    /// </remarks>
    public class CompanyNmLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 自社名称設定LCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.05.09</br>
        /// </remarks>
        public CompanyNmLcDB()
        {
        }
        // ↓ 2008.02.05 980081 a
        #region [Search]
        /// <summary>
        /// 指定された条件の自社名称設定LC情報LISTを戻します
        /// </summary>
        /// <param name="companyNmWorkList">検索結果</param>
        /// <param name="paraCompanyNmWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自社名称設定LC情報LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.28</br>
        public int Search(out List<CompanyNmWork> companyNmWorkList, CompanyNmWork paraCompanyNmWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            companyNmWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchCompanyNmWorkProcProc(out companyNmWorkList, paraCompanyNmWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "CompanyNmWorkLcDB.Search", 0);
                companyNmWorkList = new List<CompanyNmWork>();
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
        /// 指定された条件の自社名称設定LC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="companyNmWorkList">検索結果</param>
        /// <param name="companyNmWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自社名称設定LC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.28</br>
        public int SearchCompanyNmWorkProc(out List<CompanyNmWork> companyNmWorkList, CompanyNmWork companyNmWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchCompanyNmWorkProcProc(out companyNmWorkList, companyNmWork, readMode, logicalMode, ref sqlConnection);
            return status;
        }


        /// <summary>
        /// 指定された条件の自社名称設定LC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="companyNmWorkList">検索結果</param>
        /// <param name="companyNmWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自社名称設定LC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.28</br>
        private int SearchCompanyNmWorkProcProc(out List<CompanyNmWork> companyNmWorkList, CompanyNmWork companyNmWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<CompanyNmWork> listdata = new List<CompanyNmWork>();
            try
            {
                // 2008.05.27 upd start -------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM COMPANYNMRF  ", sqlConnection);
                string selectTxt = string.Empty;
                selectTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                selectTxt += "    ,POSTNORF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                selectTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                selectTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                selectTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                selectTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                selectTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                selectTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                selectTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                // 2008.05.27 upd end ----------------------------------<<
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, companyNmWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToCompanyNmWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "CompanyNmWorkLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            companyNmWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の自社名称設定LCを戻します
        /// </summary>
        /// <param name="companyNmWork">companyNmWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自社名称設定LCを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.28</br>
        public int Read(ref CompanyNmWork companyNmWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref companyNmWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "CompanyNmWorkLcDB.Read", 0);
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
        /// 指定された条件の自社名称設定LCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="companyNmWork">companyNmWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自社名称設定LCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.28</br>
        public int ReadProc(ref CompanyNmWork companyNmWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref companyNmWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件の自社名称設定LCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="companyNmWork">companyNmWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自社名称設定LCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.28</br>
        private int ReadProcProc(ref CompanyNmWork companyNmWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // 2008.05.27 upd start --------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYNAMECDRF, COMPANYPRRF, COMPANYNAME1RF, COMPANYNAME2RF, POSTNORF, ADDRESS1RF, ADDRESS2RF, ADDRESS3RF, ADDRESS4RF, COMPANYTELNO1RF, COMPANYTELNO2RF, COMPANYTELNO3RF, COMPANYTELTITLE1RF, COMPANYTELTITLE2RF, COMPANYTELTITLE3RF, TRANSFERGUIDANCERF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, COMPANYSETNOTE1RF, COMPANYSETNOTE2RF, IMAGEINFODIVRF, IMAGEINFOCODERF, COMPANYURLRF, COMPANYPRSENTENCE2RF, IMAGECOMMENTFORPRT1RF, IMAGECOMMENTFORPRT2RF FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD", sqlConnection))
                string selectTxt = string.Empty;
                selectTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                selectTxt += "    ,POSTNORF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                selectTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                selectTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                selectTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                selectTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                selectTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                selectTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                selectTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                selectTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                selectTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                selectTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                selectTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))    
                // 2008.05.27 upd end -----------------------------------<<
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCompanyNameCd = sqlCommand.Parameters.Add("@FINDCOMPANYNAMECD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyNmWork.EnterpriseCode);
                    findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companyNmWork.CompanyNameCd);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        companyNmWork = CopyToCompanyNmWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "CompanyNmWorkLcDB.Read", 0);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="companyNmWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.28</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CompanyNmWork companyNmWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyNmWork.EnterpriseCode);

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

            //各マスタのWhere文記述
            retstring += "ORDER BY COMPANYNAMECDRF ";

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CompanyNmWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CompanyNmWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.28</br>
        /// </remarks>
        private CompanyNmWork CopyToCompanyNmWorkFromReader(ref SqlDataReader myReader)
        {
            CompanyNmWork wkCompanyNmWork = new CompanyNmWork();

            #region クラスへ格納
            wkCompanyNmWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCompanyNmWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCompanyNmWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCompanyNmWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCompanyNmWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCompanyNmWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCompanyNmWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCompanyNmWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCompanyNmWork.CompanyNameCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYNAMECDRF"));
            wkCompanyNmWork.CompanyPr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRRF"));
            wkCompanyNmWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME1RF"));
            wkCompanyNmWork.CompanyName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYNAME2RF"));
            wkCompanyNmWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            wkCompanyNmWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            //wkCompanyNmWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF")); // 2008.05.27 del
            wkCompanyNmWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            wkCompanyNmWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            wkCompanyNmWork.CompanyTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO1RF"));
            wkCompanyNmWork.CompanyTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO2RF"));
            wkCompanyNmWork.CompanyTelNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNO3RF"));
            wkCompanyNmWork.CompanyTelTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE1RF"));
            wkCompanyNmWork.CompanyTelTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE2RF"));
            wkCompanyNmWork.CompanyTelTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELTITLE3RF"));
            wkCompanyNmWork.TransferGuidance = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSFERGUIDANCERF"));
            wkCompanyNmWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
            wkCompanyNmWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
            wkCompanyNmWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
            wkCompanyNmWork.CompanySetNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE1RF"));
            wkCompanyNmWork.CompanySetNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYSETNOTE2RF"));
            wkCompanyNmWork.ImageInfoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFODIVRF"));
            wkCompanyNmWork.ImageInfoCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IMAGEINFOCODERF"));
            wkCompanyNmWork.CompanyUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYURLRF"));
            wkCompanyNmWork.CompanyPrSentence2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYPRSENTENCE2RF"));
            wkCompanyNmWork.ImageCommentForPrt1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT1RF"));
            wkCompanyNmWork.ImageCommentForPrt2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IMAGECOMMENTFORPRT2RF"));
            #endregion

            return wkCompanyNmWork;
        }
        #endregion
        // ↑ 2008.02.05 980081 a
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
        /// <br>Date       : 2007.05.09</br>
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
                CompanyNmWork companyNmWork = new CompanyNmWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == companyNmWork.GetType())
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
                WriteErrorLog(ex, "DataSyncMngLcDB.Write", 0);
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
        /// <br>Date       : 2007.05.09</br>
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
        /// <br>Date       : 2007.05.09</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.27 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.27 upd start -------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM COMPANYNMRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.27 upd end ----------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        CompanyNmWork companyNmWork = paraSyncDataList[i] as CompanyNmWork;
                        
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // 2008.05.27 upd start ---------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM COMPANYNMRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD ", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                                sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                                sqlTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                                sqlTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                                sqlTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                                sqlTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                                sqlTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                                sqlTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                                sqlTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
                                sqlTxt += " FROM COMPANYNMRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ------------------------------------<<

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaCompanyNameCd = sqlCommand.Parameters.Add("@FINDCOMPANYNAMECD", SqlDbType.Int);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyNmWork.EnterpriseCode);
                                findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companyNmWork.CompanyNameCd);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    // 2008.05.27 upd start ------------------------------>>
                                    //sqlCommand.CommandText = "UPDATE COMPANYNMRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMPANYNAMECDRF=@COMPANYNAMECD , COMPANYPRRF=@COMPANYPR , COMPANYNAME1RF=@COMPANYNAME1 , COMPANYNAME2RF=@COMPANYNAME2 , POSTNORF=@POSTNO , ADDRESS1RF=@ADDRESS1 , ADDRESS2RF=@ADDRESS2 , ADDRESS3RF=@ADDRESS3 , ADDRESS4RF=@ADDRESS4 , COMPANYTELNO1RF=@COMPANYTELNO1 , COMPANYTELNO2RF=@COMPANYTELNO2 , COMPANYTELNO3RF=@COMPANYTELNO3 , COMPANYTELTITLE1RF=@COMPANYTELTITLE1 , COMPANYTELTITLE2RF=@COMPANYTELTITLE2 , COMPANYTELTITLE3RF=@COMPANYTELTITLE3 , TRANSFERGUIDANCERF=@TRANSFERGUIDANCE , ACCOUNTNOINFO1RF=@ACCOUNTNOINFO1 , ACCOUNTNOINFO2RF=@ACCOUNTNOINFO2 , ACCOUNTNOINFO3RF=@ACCOUNTNOINFO3 , COMPANYSETNOTE1RF=@COMPANYSETNOTE1 , COMPANYSETNOTE2RF=@COMPANYSETNOTE2 , IMAGEINFODIVRF=@IMAGEINFODIV , IMAGEINFOCODERF=@IMAGEINFOCODE , COMPANYURLRF=@COMPANYURL , COMPANYPRSENTENCE2RF=@COMPANYPRSENTENCE2 , IMAGECOMMENTFORPRT1RF=@IMAGECOMMENTFORPRT1 , IMAGECOMMENTFORPRT2RF=@IMAGECOMMENTFORPRT2 " +
                                    //"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE COMPANYNMRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , COMPANYNAMECDRF=@COMPANYNAMECD" + Environment.NewLine;
                                    sqlTxt += " , COMPANYPRRF=@COMPANYPR" + Environment.NewLine;
                                    sqlTxt += " , COMPANYNAME1RF=@COMPANYNAME1" + Environment.NewLine;
                                    sqlTxt += " , COMPANYNAME2RF=@COMPANYNAME2" + Environment.NewLine;
                                    sqlTxt += " , POSTNORF=@POSTNO" + Environment.NewLine;
                                    sqlTxt += " , ADDRESS1RF=@ADDRESS1" + Environment.NewLine;
                                    sqlTxt += " , ADDRESS3RF=@ADDRESS3" + Environment.NewLine;
                                    sqlTxt += " , ADDRESS4RF=@ADDRESS4" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELNO1RF=@COMPANYTELNO1" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELNO2RF=@COMPANYTELNO2" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELNO3RF=@COMPANYTELNO3" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELTITLE1RF=@COMPANYTELTITLE1" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELTITLE2RF=@COMPANYTELTITLE2" + Environment.NewLine;
                                    sqlTxt += " , COMPANYTELTITLE3RF=@COMPANYTELTITLE3" + Environment.NewLine;
                                    sqlTxt += " , TRANSFERGUIDANCERF=@TRANSFERGUIDANCE" + Environment.NewLine;
                                    sqlTxt += " , ACCOUNTNOINFO1RF=@ACCOUNTNOINFO1" + Environment.NewLine;
                                    sqlTxt += " , ACCOUNTNOINFO2RF=@ACCOUNTNOINFO2" + Environment.NewLine;
                                    sqlTxt += " , ACCOUNTNOINFO3RF=@ACCOUNTNOINFO3" + Environment.NewLine;
                                    sqlTxt += " , COMPANYSETNOTE1RF=@COMPANYSETNOTE1" + Environment.NewLine;
                                    sqlTxt += " , COMPANYSETNOTE2RF=@COMPANYSETNOTE2" + Environment.NewLine;
                                    sqlTxt += " , IMAGEINFODIVRF=@IMAGEINFODIV" + Environment.NewLine;
                                    sqlTxt += " , IMAGEINFOCODERF=@IMAGEINFOCODE" + Environment.NewLine;
                                    sqlTxt += " , COMPANYURLRF=@COMPANYURL" + Environment.NewLine;
                                    sqlTxt += " , COMPANYPRSENTENCE2RF=@COMPANYPRSENTENCE2" + Environment.NewLine;
                                    sqlTxt += " , IMAGECOMMENTFORPRT1RF=@IMAGECOMMENTFORPRT1" + Environment.NewLine;
                                    sqlTxt += " , IMAGECOMMENTFORPRT2RF=@IMAGECOMMENTFORPRT2" + Environment.NewLine;
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND COMPANYNAMECDRF=@FINDCOMPANYNAMECD" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.27 upd end --------------------------------<<
                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyNmWork.EnterpriseCode);
                                    findParaCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companyNmWork.CompanyNameCd);

                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    companyNmWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)companyNmWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //新規作成時のSQL文を生成
                                    // 2008.05.27 upd start ------------------------------>>
                                    //sqlCommand.CommandText = "INSERT INTO COMPANYNMRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYNAMECDRF, COMPANYPRRF, COMPANYNAME1RF, COMPANYNAME2RF, POSTNORF, ADDRESS1RF, ADDRESS2RF, ADDRESS3RF, ADDRESS4RF, COMPANYTELNO1RF, COMPANYTELNO2RF, COMPANYTELNO3RF, COMPANYTELTITLE1RF, COMPANYTELTITLE2RF, COMPANYTELTITLE3RF, TRANSFERGUIDANCERF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, COMPANYSETNOTE1RF, COMPANYSETNOTE2RF, IMAGEINFODIVRF, IMAGEINFOCODERF, COMPANYURLRF, COMPANYPRSENTENCE2RF, IMAGECOMMENTFORPRT1RF, IMAGECOMMENTFORPRT2RF) " +
                                    //"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYNAMECD, @COMPANYPR, @COMPANYNAME1, @COMPANYNAME2, @POSTNO, @ADDRESS1, @ADDRESS2, @ADDRESS3, @ADDRESS4, @COMPANYTELNO1, @COMPANYTELNO2, @COMPANYTELNO3, @COMPANYTELTITLE1, @COMPANYTELTITLE2, @COMPANYTELTITLE3, @TRANSFERGUIDANCE, @ACCOUNTNOINFO1, @ACCOUNTNOINFO2, @ACCOUNTNOINFO3, @COMPANYSETNOTE1, @COMPANYSETNOTE2, @IMAGEINFODIV, @IMAGEINFOCODE, @COMPANYURL, @COMPANYPRSENTENCE2, @IMAGECOMMENTFORPRT1, @IMAGECOMMENTFORPRT2)";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO COMPANYNMRF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                                    sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                                    sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                                    sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                                    sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                                    sqlTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                                    sqlTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                                    sqlTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                                    sqlTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                                    sqlTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                                    sqlTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
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
                                    sqlTxt += "    ,@COMPANYNAMECD" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYPR" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYNAME1" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYNAME2" + Environment.NewLine;
                                    sqlTxt += "    ,@POSTNO" + Environment.NewLine;
                                    sqlTxt += "    ,@ADDRESS1" + Environment.NewLine;
                                    sqlTxt += "    ,@ADDRESS3" + Environment.NewLine;
                                    sqlTxt += "    ,@ADDRESS4" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELNO1" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELNO2" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELNO3" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELTITLE1" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELTITLE2" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYTELTITLE3" + Environment.NewLine;
                                    sqlTxt += "    ,@TRANSFERGUIDANCE" + Environment.NewLine;
                                    sqlTxt += "    ,@ACCOUNTNOINFO1" + Environment.NewLine;
                                    sqlTxt += "    ,@ACCOUNTNOINFO2" + Environment.NewLine;
                                    sqlTxt += "    ,@ACCOUNTNOINFO3" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYSETNOTE1" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYSETNOTE2" + Environment.NewLine;
                                    sqlTxt += "    ,@IMAGEINFODIV" + Environment.NewLine;
                                    sqlTxt += "    ,@IMAGEINFOCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYURL" + Environment.NewLine;
                                    sqlTxt += "    ,@COMPANYPRSENTENCE2" + Environment.NewLine;
                                    sqlTxt += "    ,@IMAGECOMMENTFORPRT1" + Environment.NewLine;
                                    sqlTxt += "    ,@IMAGECOMMENTFORPRT2" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.27 upd end --------------------------------<<
                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)companyNmWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //新規作成時のSQL文を生成
                                // 2008.05.27 upd start ------------------------------>> 
                                //sqlCommand = new SqlCommand("INSERT INTO COMPANYNMRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMPANYNAMECDRF, COMPANYPRRF, COMPANYNAME1RF, COMPANYNAME2RF, POSTNORF, ADDRESS1RF, ADDRESS2RF, ADDRESS3RF, ADDRESS4RF, COMPANYTELNO1RF, COMPANYTELNO2RF, COMPANYTELNO3RF, COMPANYTELTITLE1RF, COMPANYTELTITLE2RF, COMPANYTELTITLE3RF, TRANSFERGUIDANCERF, ACCOUNTNOINFO1RF, ACCOUNTNOINFO2RF, ACCOUNTNOINFO3RF, COMPANYSETNOTE1RF, COMPANYSETNOTE2RF, IMAGEINFODIVRF, IMAGEINFOCODERF, COMPANYURLRF, COMPANYPRSENTENCE2RF, IMAGECOMMENTFORPRT1RF, IMAGECOMMENTFORPRT2RF) " +
                                //"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMPANYNAMECD, @COMPANYPR, @COMPANYNAME1, @COMPANYNAME2, @POSTNO, @ADDRESS1, @ADDRESS2, @ADDRESS3, @ADDRESS4, @COMPANYTELNO1, @COMPANYTELNO2, @COMPANYTELNO3, @COMPANYTELTITLE1, @COMPANYTELTITLE2, @COMPANYTELTITLE3, @TRANSFERGUIDANCE, @ACCOUNTNOINFO1, @ACCOUNTNOINFO2, @ACCOUNTNOINFO3, @COMPANYSETNOTE1, @COMPANYSETNOTE2, @IMAGEINFODIV, @IMAGEINFOCODE, @COMPANYURL, @COMPANYPRSENTENCE2, @IMAGECOMMENTFORPRT1, @IMAGECOMMENTFORPRT2)", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt = string.Empty;
                                sqlTxt += "INSERT INTO COMPANYNMRF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAMECDRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYPRRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAME1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYNAME2RF" + Environment.NewLine;
                                sqlTxt += "    ,POSTNORF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS1RF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS3RF" + Environment.NewLine;
                                sqlTxt += "    ,ADDRESS4RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELNO3RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE2RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYTELTITLE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TRANSFERGUIDANCERF" + Environment.NewLine;
                                sqlTxt += "    ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                                sqlTxt += "    ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                                sqlTxt += "    ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYSETNOTE1RF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYSETNOTE2RF" + Environment.NewLine;
                                sqlTxt += "    ,IMAGEINFODIVRF" + Environment.NewLine;
                                sqlTxt += "    ,IMAGEINFOCODERF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYURLRF" + Environment.NewLine;
                                sqlTxt += "    ,COMPANYPRSENTENCE2RF" + Environment.NewLine;
                                sqlTxt += "    ,IMAGECOMMENTFORPRT1RF" + Environment.NewLine;
                                sqlTxt += "    ,IMAGECOMMENTFORPRT2RF" + Environment.NewLine;
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
                                sqlTxt += "    ,@COMPANYNAMECD" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYPR" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYNAME1" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYNAME2" + Environment.NewLine;
                                sqlTxt += "    ,@POSTNO" + Environment.NewLine;
                                sqlTxt += "    ,@ADDRESS1" + Environment.NewLine;
                                sqlTxt += "    ,@ADDRESS3" + Environment.NewLine;
                                sqlTxt += "    ,@ADDRESS4" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELNO1" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELNO2" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELNO3" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELTITLE1" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELTITLE2" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYTELTITLE3" + Environment.NewLine;
                                sqlTxt += "    ,@TRANSFERGUIDANCE" + Environment.NewLine;
                                sqlTxt += "    ,@ACCOUNTNOINFO1" + Environment.NewLine;
                                sqlTxt += "    ,@ACCOUNTNOINFO2" + Environment.NewLine;
                                sqlTxt += "    ,@ACCOUNTNOINFO3" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYSETNOTE1" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYSETNOTE2" + Environment.NewLine;
                                sqlTxt += "    ,@IMAGEINFODIV" + Environment.NewLine;
                                sqlTxt += "    ,@IMAGEINFOCODE" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYURL" + Environment.NewLine;
                                sqlTxt += "    ,@COMPANYPRSENTENCE2" + Environment.NewLine;
                                sqlTxt += "    ,@IMAGECOMMENTFORPRT1" + Environment.NewLine;
                                sqlTxt += "    ,@IMAGECOMMENTFORPRT2" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end --------------------------------<<
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)companyNmWork;
                                fileHeader = new ClientFileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                                break;
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCompanyNameCd = sqlCommand.Parameters.Add("@COMPANYNAMECD", SqlDbType.Int);
                        SqlParameter paraCompanyPr = sqlCommand.Parameters.Add("@COMPANYPR", SqlDbType.NVarChar);
                        SqlParameter paraCompanyName1 = sqlCommand.Parameters.Add("@COMPANYNAME1", SqlDbType.NVarChar);
                        SqlParameter paraCompanyName2 = sqlCommand.Parameters.Add("@COMPANYNAME2", SqlDbType.NVarChar);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        //SqlParameter paraAddress2 = sqlCommand.Parameters.Add("@ADDRESS2", SqlDbType.Int); // 2008.05.27 del
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelNo1 = sqlCommand.Parameters.Add("@COMPANYTELNO1", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelNo2 = sqlCommand.Parameters.Add("@COMPANYTELNO2", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelNo3 = sqlCommand.Parameters.Add("@COMPANYTELNO3", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelTitle1 = sqlCommand.Parameters.Add("@COMPANYTELTITLE1", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelTitle2 = sqlCommand.Parameters.Add("@COMPANYTELTITLE2", SqlDbType.NVarChar);
                        SqlParameter paraCompanyTelTitle3 = sqlCommand.Parameters.Add("@COMPANYTELTITLE3", SqlDbType.NVarChar);
                        SqlParameter paraTransferGuidance = sqlCommand.Parameters.Add("@TRANSFERGUIDANCE", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraCompanySetNote1 = sqlCommand.Parameters.Add("@COMPANYSETNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraCompanySetNote2 = sqlCommand.Parameters.Add("@COMPANYSETNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraImageInfoDiv = sqlCommand.Parameters.Add("@IMAGEINFODIV", SqlDbType.Int);
                        SqlParameter paraImageInfoCode = sqlCommand.Parameters.Add("@IMAGEINFOCODE", SqlDbType.Int);
                        SqlParameter paraCompanyUrl = sqlCommand.Parameters.Add("@COMPANYURL", SqlDbType.NVarChar);
                        SqlParameter paraCompanyPrSentence2 = sqlCommand.Parameters.Add("@COMPANYPRSENTENCE2", SqlDbType.NVarChar);
                        SqlParameter paraImageCommentForPrt1 = sqlCommand.Parameters.Add("@IMAGECOMMENTFORPRT1", SqlDbType.NVarChar);
                        SqlParameter paraImageCommentForPrt2 = sqlCommand.Parameters.Add("@IMAGECOMMENTFORPRT2", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companyNmWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(companyNmWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(companyNmWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(companyNmWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(companyNmWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(companyNmWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(companyNmWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(companyNmWork.LogicalDeleteCode);
                        paraCompanyNameCd.Value = SqlDataMediator.SqlSetInt32(companyNmWork.CompanyNameCd);
                        paraCompanyPr.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyPr);
                        paraCompanyName1.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyName1);
                        paraCompanyName2.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyName2);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(companyNmWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(companyNmWork.Address1);
                        //paraAddress2.Value = SqlDataMediator.SqlSetInt32(companyNmWork.Address2); // 2008.05.27 del
                        paraAddress3.Value = SqlDataMediator.SqlSetString(companyNmWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(companyNmWork.Address4);
                        paraCompanyTelNo1.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyTelNo1);
                        paraCompanyTelNo2.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyTelNo2);
                        paraCompanyTelNo3.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyTelNo3);
                        paraCompanyTelTitle1.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyTelTitle1);
                        paraCompanyTelTitle2.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyTelTitle2);
                        paraCompanyTelTitle3.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyTelTitle3);
                        paraTransferGuidance.Value = SqlDataMediator.SqlSetString(companyNmWork.TransferGuidance);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(companyNmWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(companyNmWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(companyNmWork.AccountNoInfo3);
                        paraCompanySetNote1.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanySetNote1);
                        paraCompanySetNote2.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanySetNote2);
                        paraImageInfoDiv.Value = SqlDataMediator.SqlSetInt32(companyNmWork.ImageInfoDiv);
                        paraImageInfoCode.Value = SqlDataMediator.SqlSetInt32(companyNmWork.ImageInfoCode);
                        paraCompanyUrl.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyUrl);
                        paraCompanyPrSentence2.Value = SqlDataMediator.SqlSetString(companyNmWork.CompanyPrSentence2);
                        paraImageCommentForPrt1.Value = SqlDataMediator.SqlSetString(companyNmWork.ImageCommentForPrt1);
                        paraImageCommentForPrt2.Value = SqlDataMediator.SqlSetString(companyNmWork.ImageCommentForPrt2);

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
                status = WriteSQLErrorLog(ex, "DataSyncMngLcDB.WriteDataSyncMngProc", 0);
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
        /// <br>Date       : 2007.04.03</br>
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
