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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 更新履歴表示DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 更新履歴表示の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// <br></br>
    /// <br>Update Note: 23012 畠中</br>
    /// <br>Date       : 2008.10.30, 2008.11.05</br>
    /// <br>           : 不具合対応</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class UpdHisDspDB : RemoteDB, IUpdHisDspDB
    {
        /// <summary>
        /// 更新履歴表示DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        /// </remarks>
        public UpdHisDspDB()
            :
            base("PMKAU04106D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_UpdHisDspWork", "UPDHISDSPWORKRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の更新履歴表示データを戻します
        /// </summary>
        /// <param name="rsltInfo_UpdHisDspWork">検索結果</param>
        /// <param name="extrInfo_UpdHisDspWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の更新履歴表示データを戻します</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        public int Search(out object rsltInfo_UpdHisDspWork, object extrInfo_UpdHisDspWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rsltInfo_UpdHisDspWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchUpdHisDsp(out rsltInfo_UpdHisDspWork, extrInfo_UpdHisDspWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UpdHisDspDB.Search");
                rsltInfo_UpdHisDspWork = new ArrayList();
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
        /// 指定された条件の更新履歴表示データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objRsltInfo_UpdHisDspWork">検索結果</param>
        /// <param name="objExtrInfo_UpdHisDspWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の更新履歴表示データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        private int SearchUpdHisDsp(out object objRsltInfo_UpdHisDspWork, object objExtrInfo_UpdHisDspWork, ref SqlConnection sqlConnection)
        {
            ExtrInfo_UpdHisDspWork paramWork = null;

            ArrayList paramWorkList = objExtrInfo_UpdHisDspWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objExtrInfo_UpdHisDspWork as ExtrInfo_UpdHisDspWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ExtrInfo_UpdHisDspWork;
            }

            ArrayList rsltInfo_UpdHisDspWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // 更新履歴表示データを取得
            status = SearchUpdHisDspProc(out rsltInfo_UpdHisDspWork, paramWork, ref sqlConnection);

            objRsltInfo_UpdHisDspWork = rsltInfo_UpdHisDspWork;
            return status;

        }
        #endregion  //Search

        #region [SearchUpdHisDspProc]
        /// <summary>
        /// 指定された条件の更新履歴表示データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rsltInfo_UpdHisDspWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の更新履歴表示データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        private int SearchUpdHisDspProc(out ArrayList rsltInfo_UpdHisDspWorkList, ExtrInfo_UpdHisDspWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                String TblNm = String.Empty;
                //sqlText += "SELECT *" + Environment.NewLine;
                if (paramWork.DispDiv == 0)
                {
                    #region 請求締更新履歴
                    //sqlText += " FROM DMDCADDUPHISRF" + Environment.NewLine;      
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " DMD.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += " DMD.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += " DMD.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += " DMD.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += " DMD.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += " DMD.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += " DMD.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += " DMD.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += " DMD.ADDUPSECCODERF," + Environment.NewLine;
                    sqlText += " DMD.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += " DMD.STARTCADDUPUPDDATERF," + Environment.NewLine;
                    sqlText += " DMD.CADDUPUPDDATERF," + Environment.NewLine;
                    sqlText += " DMD.CADDUPUPDYEARMONTHRF," + Environment.NewLine;
                    sqlText += " DMD.CADDUPUPDEXECDATERF," + Environment.NewLine;
                    sqlText += " DMD.LASTCADDUPUPDDATERF," + Environment.NewLine;
                    sqlText += " DMD.DATAUPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += " DMD.PROCDIVCDRF," + Environment.NewLine;
                    sqlText += " DMD.ERRORSTATUSRF," + Environment.NewLine;
                    sqlText += " DMD.HISTCTLCDRF," + Environment.NewLine;
                    sqlText += " DMD.PROCRESULTRF," + Environment.NewLine;
                    sqlText += " DMD.CONVERTPROCESSDIVCDRF," + Environment.NewLine;
                    sqlText += " DMD.DATAUPDATEDATETIMERF," + Environment.NewLine; // ADD 2009.03.09
                    sqlText += " EMP.BELONGSECTIONCODERF," + Environment.NewLine;
                    sqlText += " SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += " DMDCADDUPHISRF AS DMD" + Environment.NewLine;
                    sqlText += "LEFT JOIN EMPLOYEERF AS EMP " + Environment.NewLine;
                    sqlText += " ON DMD.ENTERPRISECODERF = EMP.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND DMD.UPDEMPLOYEECODERF = EMP.EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                    sqlText += " ON DMD.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND EMP.BELONGSECTIONCODERF = SEC.SECTIONCODERF" + Environment.NewLine;
                    TblNm = "DMD.";
                    #endregion

                }
                else if (paramWork.DispDiv == 1)
                {
                    #region 支払締更新履歴
                    //sqlText += " FROM PAYMENTADDUPHISRF" + Environment.NewLine; 
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += " PAY.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += " PAY.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += " PAY.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += " PAY.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += " PAY.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += " PAY.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += " PAY.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += " PAY.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += " PAY.ADDUPSECCODERF," + Environment.NewLine;
                    sqlText += " PAY.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += " PAY.STARTCADDUPUPDDATERF," + Environment.NewLine;
                    sqlText += " PAY.CADDUPUPDDATERF," + Environment.NewLine;
                    sqlText += " PAY.CADDUPUPDYEARMONTHRF," + Environment.NewLine;
                    sqlText += " PAY.CADDUPUPDEXECDATERF," + Environment.NewLine;
                    sqlText += " PAY.LASTCADDUPUPDDATERF," + Environment.NewLine;
                    sqlText += " PAY.DATAUPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += " PAY.PROCDIVCDRF," + Environment.NewLine;
                    sqlText += " PAY.ERRORSTATUSRF," + Environment.NewLine;
                    sqlText += " PAY.HISTCTLCDRF," + Environment.NewLine;
                    sqlText += " PAY.PROCRESULTRF," + Environment.NewLine;
                    sqlText += " PAY.CONVERTPROCESSDIVCDRF," + Environment.NewLine;
                    sqlText += " PAY.DATAUPDATEDATETIMERF," + Environment.NewLine; // ADD 2009.03.09
                    sqlText += " EMP.BELONGSECTIONCODERF," + Environment.NewLine;
                    sqlText += " SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += " PAYMENTADDUPHISRF AS PAY" + Environment.NewLine;
                    sqlText += "LEFT JOIN EMPLOYEERF AS EMP " + Environment.NewLine;
                    sqlText += " ON PAY.ENTERPRISECODERF = EMP.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND PAY.UPDEMPLOYEECODERF = EMP.EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                    sqlText += " ON PAY.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND EMP.BELONGSECTIONCODERF = SEC.SECTIONCODERF" + Environment.NewLine;
                    TblNm = "PAY.";
                    #endregion

                }
                else
                {
                    #region 月次更新履歴
                    //sqlText += " FROM MONTHLYADDUPHISRF" + Environment.NewLine;  
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " MON.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += " MON.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += " MON.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += " MON.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += " MON.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += " MON.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += " MON.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += " MON.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += " MON.ACCRECACCPAYDIVRF," + Environment.NewLine;
                    sqlText += " MON.ADDUPSECCODERF," + Environment.NewLine;
                    sqlText += " MON.STMONCADDUPUPDDATERF," + Environment.NewLine;
                    sqlText += " MON.MONTHLYADDUPDATERF," + Environment.NewLine;
                    sqlText += " MON.MONTHADDUPYEARMONTHRF," + Environment.NewLine;
                    sqlText += " MON.MONTHADDUPEXPDATERF," + Environment.NewLine;
                    sqlText += " MON.LAMONCADDUPUPDDATERF," + Environment.NewLine;
                    sqlText += " MON.DATAUPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += " MON.PROCDIVCDRF," + Environment.NewLine;
                    sqlText += " MON.ERRORSTATUSRF," + Environment.NewLine;
                    sqlText += " MON.HISTCTLCDRF," + Environment.NewLine;
                    sqlText += " MON.PROCRESULTRF," + Environment.NewLine;
                    sqlText += " MON.CONVERTPROCESSDIVCDRF," + Environment.NewLine;
                    sqlText += " MON.DATAUPDATEDATETIMERF," + Environment.NewLine; // ADD 2009.03.09
                    sqlText += " EMP.BELONGSECTIONCODERF," + Environment.NewLine;
                    sqlText += " SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "MONTHLYADDUPHISRF AS MON" + Environment.NewLine;
                    sqlText += "LEFT JOIN EMPLOYEERF AS EMP " + Environment.NewLine;
                    sqlText += " ON MON.ENTERPRISECODERF = EMP.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND MON.UPDEMPLOYEECODERF = EMP.EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                    sqlText += " ON MON.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND EMP.BELONGSECTIONCODERF = SEC.SECTIONCODERF" + Environment.NewLine;
                    TblNm = "MON.";
                    #endregion
                }
                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, TblNm, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToUpdHisDspWorkFromReader(ref myReader,paramWork));

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

            rsltInfo_UpdHisDspWorkList = al;

            return status;
        }
        #endregion  //SearchUpdHisDspProc

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="extrInfo_UpdHisDspWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, String TblNm, ExtrInfo_UpdHisDspWork extrInfo_UpdHisDspWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            retString.Append( TblNm+"ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_UpdHisDspWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND "+TblNm+"LOGICALDELETECODERF=0 ");

            // 出力対象拠点
            if (extrInfo_UpdHisDspWork.AddupSecCodeList != null)
            {
                string sectionString = string.Empty;
                foreach (string sectionCode in extrInfo_UpdHisDspWork.AddupSecCodeList)
                {
                    if (sectionCode != string.Empty)
                    {
                        if (sectionString != string.Empty) sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != string.Empty)
                {
                    retString.Append("AND ADDUPSECCODERF IN (" + sectionString + ") ");
                }
            }

            // 開始締次更新年月日 終了締次更新年月日
            if ((extrInfo_UpdHisDspWork.DispDiv == 0) || (extrInfo_UpdHisDspWork.DispDiv == 1))
            {
                if (extrInfo_UpdHisDspWork.St_CAddUpUpdDate != 0)
                {
                    retString.Append("AND CADDUPUPDDATERF>=@ST_CADDUPUPDDATE ");
                    SqlParameter paraSt_CAddUpUpdDate = sqlCommand.Parameters.Add("@ST_CADDUPUPDDATE", SqlDbType.Int);
                    paraSt_CAddUpUpdDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.St_CAddUpUpdDate);
                }
                if (extrInfo_UpdHisDspWork.Ed_CAddUpUpdDate != 0)
                {
                    retString.Append("AND CADDUPUPDDATERF<=@ED_CADDUPUPDDATE ");
                    SqlParameter paraEd_CAddUpUpdDate = sqlCommand.Parameters.Add("@ED_CADDUPUPDDATE", SqlDbType.Int);
                    paraEd_CAddUpUpdDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.Ed_CAddUpUpdDate);
                }
            }
            else
            {
                if (extrInfo_UpdHisDspWork.St_CAddUpUpdDate != 0)
                {
                    //retString.Append("AND MONTHLYADDUPDATERF>=@ST_CADDUPUPDDATE "); DEL 2008.11.05
                    retString.Append("AND MONTHADDUPYEARMONTHRF>=@ST_CADDUPUPDDATE "); // ADD 2008.11.05
                    SqlParameter paraSt_CAddUpUpdDate = sqlCommand.Parameters.Add("@ST_CADDUPUPDDATE", SqlDbType.Int);
                    paraSt_CAddUpUpdDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.St_CAddUpUpdDate);
                }
                if (extrInfo_UpdHisDspWork.Ed_CAddUpUpdDate != 0)
                {
                    //retString.Append("AND MONTHLYADDUPDATERF<=@ED_CADDUPUPDDATE "); DEL 2008.11.05
                    retString.Append("AND MONTHADDUPYEARMONTHRF<=@ED_CADDUPUPDDATE "); // ADD 2008.11.05
                    SqlParameter paraEd_CAddUpUpdDate = sqlCommand.Parameters.Add("@ED_CADDUPUPDDATE", SqlDbType.Int);
                    paraEd_CAddUpUpdDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.Ed_CAddUpUpdDate);
                }
            }

            // 開始締次更新実行年月日 終了締次更新実行年月日
            if ((extrInfo_UpdHisDspWork.DispDiv == 0) || (extrInfo_UpdHisDspWork.DispDiv == 1))
            {
                if (extrInfo_UpdHisDspWork.St_CAddUpUpdExecDate != 0)
                {
                    retString.Append("AND CADDUPUPDEXECDATERF>=@ST_CADDUPUPDEXECDATE ");
                    SqlParameter paraSt_CAddUpUpdExecDate = sqlCommand.Parameters.Add("@ST_CADDUPUPDEXECDATE", SqlDbType.Int);
                    paraSt_CAddUpUpdExecDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.St_CAddUpUpdExecDate);
                }
                if (extrInfo_UpdHisDspWork.Ed_CAddUpUpdExecDate != 0)
                {
                    retString.Append("AND CADDUPUPDEXECDATERF<=@Ed_CAddUpUpdExecDate ");
                    SqlParameter paraEd_CAddUpUpdExecDate = sqlCommand.Parameters.Add("@Ed_CAddUpUpdExecDate", SqlDbType.Int);
                    paraEd_CAddUpUpdExecDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.Ed_CAddUpUpdExecDate);
                }
            }
            else
            {
                if (extrInfo_UpdHisDspWork.St_CAddUpUpdExecDate != 0)
                {
                    retString.Append("AND MONTHADDUPEXPDATERF>=@ST_CADDUPUPDEXECDATE ");
                    SqlParameter paraSt_CAddUpUpdExecDate = sqlCommand.Parameters.Add("@ST_CADDUPUPDEXECDATE", SqlDbType.Int);
                    paraSt_CAddUpUpdExecDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.St_CAddUpUpdExecDate);
                }
                if (extrInfo_UpdHisDspWork.Ed_CAddUpUpdExecDate != 0)
                {
                    retString.Append("AND MONTHADDUPEXPDATERF<=@Ed_CAddUpUpdExecDate ");
                    SqlParameter paraEd_CAddUpUpdExecDate = sqlCommand.Parameters.Add("@Ed_CAddUpUpdExecDate", SqlDbType.Int);
                    paraEd_CAddUpUpdExecDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.Ed_CAddUpUpdExecDate);
                }
            }
            // ADD 2008.10.30 >>>
            if (extrInfo_UpdHisDspWork.DispDiv == 2)
            {
                retString.Append("AND ACCRECACCPAYDIVRF = 0 ");
            }
            if (extrInfo_UpdHisDspWork.DispDiv == 3)
            {
                retString.Append("AND ACCRECACCPAYDIVRF = 1 ");
            }
            // ADD 2008.10.30 <<<

            // 処理種別
            if (extrInfo_UpdHisDspWork.ProcKnd != -1)
            {
                retString.Append("AND PROCDIVCDRF=@FINDPROCDIVCD ");
                SqlParameter findProcDivCd = sqlCommand.Parameters.Add("@FINDPROCDIVCD", SqlDbType.Int);
                findProcDivCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.ProcKnd);
            }

            // 結果種別
            if (extrInfo_UpdHisDspWork.RsltKnd != -1)
            {
                retString.Append("AND ERRORSTATUSRF=@FINDERRORSTATUS ");
                SqlParameter findErrorStatus = sqlCommand.Parameters.Add("@FINDERRORSTATUS", SqlDbType.Int);
                findErrorStatus.Value = SqlDataMediator.SqlSetInt32(extrInfo_UpdHisDspWork.RsltKnd);
            }

            return retString.ToString();
        }
        # endregion

        /// <summary>
        /// クラス格納処理 Reader → UOEGuideNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>UOEGuideNameWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private RsltInfo_UpdHisDspWork CopyToUpdHisDspWorkFromReader(ref SqlDataReader myReader, ExtrInfo_UpdHisDspWork paramWork)
        {
            RsltInfo_UpdHisDspWork rsltInfo_UpdHisDspWork = new RsltInfo_UpdHisDspWork();

            if (myReader != null)
            {
                # region クラスへ格納
                rsltInfo_UpdHisDspWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                rsltInfo_UpdHisDspWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));
                rsltInfo_UpdHisDspWork.ErrorStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERRORSTATUSRF"));
                rsltInfo_UpdHisDspWork.HistCtlCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTCTLCDRF"));
                rsltInfo_UpdHisDspWork.ProcResult = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROCRESULTRF"));
                rsltInfo_UpdHisDspWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONVERTPROCESSDIVCDRF"));
                rsltInfo_UpdHisDspWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                rsltInfo_UpdHisDspWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                rsltInfo_UpdHisDspWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                rsltInfo_UpdHisDspWork.DataUpdateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
                
                if (paramWork.DispDiv == 0)
                {
                    rsltInfo_UpdHisDspWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    rsltInfo_UpdHisDspWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
                    rsltInfo_UpdHisDspWork.CAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDDATERF"));
                    rsltInfo_UpdHisDspWork.CAddUpUpdYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("CADDUPUPDYEARMONTHRF"));
                    rsltInfo_UpdHisDspWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
                    rsltInfo_UpdHisDspWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
                }
                else if (paramWork.DispDiv == 1)
                {
                    rsltInfo_UpdHisDspWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    rsltInfo_UpdHisDspWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
                    rsltInfo_UpdHisDspWork.CAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDDATERF"));
                    rsltInfo_UpdHisDspWork.CAddUpUpdYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("CADDUPUPDYEARMONTHRF"));
                    rsltInfo_UpdHisDspWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
                    rsltInfo_UpdHisDspWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
                }
                else
                {
                    rsltInfo_UpdHisDspWork.AccRecAccPayDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECACCPAYDIVRF"));
                    rsltInfo_UpdHisDspWork.StMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STMONCADDUPUPDDATERF"));
                    rsltInfo_UpdHisDspWork.MonthlyAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
                    rsltInfo_UpdHisDspWork.MonthAddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("MONTHADDUPYEARMONTHRF"));
                    rsltInfo_UpdHisDspWork.MonthAddUpExpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHADDUPEXPDATERF"));
                    rsltInfo_UpdHisDspWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
                }

                # endregion
            }

            return rsltInfo_UpdHisDspWork;
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
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
        #endregion  //コネクション生成処理
    }

}
