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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先実績修正DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先実績修正の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.23</br>
    /// <br></br>
    /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
    /// <br></br>
    /// <br>UpDateNote : 2008.06.02 20081 疋田 勇人 PM.NS用に修正</br>
    /// </remarks>
    [Serializable]
    public class CustRsltUpdDB : RemoteDB, ICustRsltUpdDB
    {
        /// <summary>
        /// 得意先実績修正DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// </remarks>
        public CustRsltUpdDB()
            :
            base("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork", "CUSTDMDPRCRF")
        {
        }

        #region [SearchAccRec 売掛金額マスタ]
        /// <summary>
        /// 得意先売掛金額マスタ読込
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="readMode">読込区分</param>
        /// <param name="retObj">得意先売掛金額マスタ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタ読込</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        public int SearchAccRec(string enterpriseCode, string sectionCode, int claimCode, int customerCode, int readMode, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retObj = null;
            
            CustomSerializeArrayList retcsaList = new CustomSerializeArrayList();

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //売掛金額マスタ抽出
                status = SearchAccRecProc(enterpriseCode, sectionCode, claimCode, customerCode, readMode, ref retcsaList, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.SearchAccRec");
                retObj = new CustomSerializeArrayList();
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

            retObj = retcsaList;

            return status;
        }

        /// <summary>
        /// 得意先売掛金額マスタ読込
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="readMode">読込区分</param>
        /// <param name="retcsaList">カスタムシリアライズリスト</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタ読込</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        private int SearchAccRecProc(string enterpriseCode, string sectionCode, int claimCode, int customerCode, int readMode, ref CustomSerializeArrayList retcsaList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList accRecList = new ArrayList();
            ArrayList accRecDepoTotalList = new ArrayList();
            ArrayList retList = new ArrayList();

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSTACC.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CLAIMCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CLAIMNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CLAIMNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CUSTOMERNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CUSTOMERNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ADDUPDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDOFFSETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.OFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.OFFSETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDSALESOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDSALESINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ITDEDSALESTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.SALESOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.SALESINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDRETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDRETTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLRETOUTERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLRETINNERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.THISSALESPRCTAXDISRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDDISINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLITDEDDISTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLDISOUTERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.TTLDISINNERTAXRF" + Environment.NewLine;
                // 2008.06.02 del start ---------------------------------->>
                //selectTxt += " ,CUSTACC.THISPAYOFFSETRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.THISPAYOFFSETTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.ITDEDPAYMOUTTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.ITDEDPAYMINTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.ITDEDPAYMTAXFREERF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.PAYMENTOUTTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.PAYMENTINTAXRF" + Environment.NewLine;
                // 2008.06.02 del end ------------------------------------<<
                selectTxt += " ,CUSTACC.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ACPODRTTL2TMBFACCRECRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ACPODRTTL3TMBFACCRECRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.MONTHADDUPEXPDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.STMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.LAMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.SALESSLIPCOUNTRF" + Environment.NewLine;
                // 2008.06.02 del start ---------------------------------->>
                //selectTxt += " ,CUSTACC.NONSTMNTAPPEARANCERF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.NONSTMNTISDONERF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.STMNTAPPEARANCERF" + Environment.NewLine;
                //selectTxt += " ,CUSTACC.STMNTISDONERF" + Environment.NewLine;
                // 2008.06.02 del end ------------------------------------<<
                selectTxt += " ,CUSTACC.CONSTAXLAYMETHODRF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.CONSTAXRATERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.FRACTIONPROCCDRF" + Environment.NewLine;
                selectTxt += "FROM CUSTACCRECRF AS CUSTACC" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                
                selectTxt += " WHERE" + Environment.NewLine;

                selectTxt += "     CUSTACC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                //計上拠点コード
                if (string.IsNullOrEmpty(sectionCode) == false)
                {
                    selectTxt += " AND CUSTACC.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                }

                //請求先先コード
                if (claimCode > 0)
                {
                    selectTxt += " AND CUSTACC.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(claimCode);
                }

                //得意先コード（得意先コード=０が集計レコードになる為、０の場合もWhere分対象とする）
                if (customerCode > 0)
                {
                    selectTxt += " AND (CUSTACC.CUSTOMERCODERF=@FINDCUSTOMERCODE OR CUSTACC.CUSTOMERCODERF=0)" + Environment.NewLine;
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
                }
                else
                {
                    selectTxt += " AND CUSTACC.CUSTOMERCODERF=0" + Environment.NewLine;
                }

                selectTxt += "ORDER BY CUSTACC.ADDUPDATERF DESC ,CUSTACC.CUSTOMERCODERF DESC" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                //計上日付退避用
                DateTime addupDate = DateTime.MinValue;

                while (myReader.Read())
                {

                    CustAccRecWork wkCustAccRecWork = CopyToCustAccRecWorkFromReader(ref myReader);

                    //計上日が変わったタイミングでリストを生成する
                    if (addupDate != DateTime.MinValue && addupDate != wkCustAccRecWork.AddUpDate)
                    {
                        //子レコードの抽出で、集計レコードのみ１件該当した場合は抽出対象としない
                        if (!(customerCode > 0 && accRecList.Count == 1 && (accRecList[0] as CustAccRecWork).CustomerCode == 0))
                        {
                            retList.Add(accRecList); //売掛金額マスタ追加

                            SearchAccRecDepoTotalProc(accRecList[0] as CustAccRecWork, ref accRecDepoTotalList);

                            retList.Add(accRecDepoTotalList);  //入金集計データ追加

                            retcsaList.Add(retList);
                        }

                        accRecList = new ArrayList();
                        accRecDepoTotalList = new ArrayList();
                        retList = new ArrayList();
                    }

                    accRecList.Add(wkCustAccRecWork);

                    addupDate = wkCustAccRecWork.AddUpDate; //計上日付退避

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                //最終レコードの処理
                if (accRecList.Count != 0)
                {
                    //子レコードの抽出で、集計レコードのみ１件該当した場合は抽出対象としない
                    if (!(customerCode > 0 && accRecList.Count == 1 && (accRecList[0] as CustAccRecWork).CustomerCode == 0))
                    {
                        retList.Add(accRecList); //売掛金額マスタ追加

                        SearchAccRecDepoTotalProc(accRecList[0] as CustAccRecWork, ref accRecDepoTotalList);

                        retList.Add(accRecDepoTotalList);  //入金集計データ追加

                        retcsaList.Add(retList);
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 売掛入金集計データ読込
        /// </summary>
        /// <param name="wkCustAccRecWork">売掛金額マスタ</param>
        /// <param name="retList">売掛入金集計データリスト</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売掛入金集計データ読込</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        private int SearchAccRecDepoTotalProc(CustAccRecWork wkCustAccRecWork, ref ArrayList retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SqlConnection sqlConnection = null;

            retList = new ArrayList();
            try
            {

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "  ,DEPOSITRF" + Environment.NewLine;
                selectTxt += " FROM ACCRECDEPOTOTALRF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.EnterpriseCode);

                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.AddUpSecCode);

                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustAccRecWork.ClaimCode);

                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustAccRecWork.AddUpDate);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AccRecDepoTotalWork wkAccRecDepoTotalWork = CopyToAccRecDepoTotalWorkFromReader(ref myReader);

                    retList.Add(wkAccRecDepoTotalWork);

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

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }

            return status;
        }

        #endregion

        #region [SearchDmdPrc 請求金額マスタ]
        /// <summary>
        /// 得意先請求金額マスタ読込
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="resultsSectCd">実績拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="readMode">読込区分</param>
        /// <param name="retObj">得意先請求金額マスタ</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタ読込</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        public int SearchDmdPrc(string enterpriseCode, string sectionCode, int claimCode, string resultsSectCd, int customerCode, int readMode, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retObj = null;

            CustomSerializeArrayList retcsaList = new CustomSerializeArrayList();

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //請求金額マスタ抽出
                status = SearchDmdPrcProc(enterpriseCode, sectionCode, claimCode, resultsSectCd, customerCode, readMode, ref retcsaList, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.SearchDmdPrc");
                retObj = new CustomSerializeArrayList();
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

            retObj = retcsaList;
            return status;
        }

        /// <summary>
        /// 得意先請求金額マスタ読込
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="resultsSectCd">実績拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="readMode">読込区分</param>
        /// <param name="retcsaList">カスタムシリアライズリスト</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタ読込</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        private int SearchDmdPrcProc(string enterpriseCode, string sectionCode, int claimCode, string resultsSectCd, int customerCode, int readMode, ref CustomSerializeArrayList retcsaList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList dmdPrcList = new ArrayList();
            ArrayList dmdDepoTotalList = new ArrayList();
            ArrayList retList = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSTDMD.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CLAIMCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CLAIMNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CLAIMNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.RESULTSSECTCDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CUSTOMERNAMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CUSTOMERNAME2RF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ADDUPDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.LASTTIMEDEMANDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMETTLBLCDMDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDOFFSETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.OFFSETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.OFFSETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDSALESOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDSALESINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ITDEDSALESTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.SALESOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.SALESINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDRETINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDRETTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLRETOUTERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLRETINNERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.THISSALESPRCTAXDISRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDDISINTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLITDEDDISTAXFREERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLDISOUTERTAXRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.TTLDISINNERTAXRF" + Environment.NewLine;
                // 2008.06.02 del start ---------------------->>
                //selectTxt += " ,CUSTDMD.THISPAYOFFSETRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.THISPAYOFFSETTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.ITDEDPAYMOUTTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.ITDEDPAYMINTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.ITDEDPAYMTAXFREERF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.PAYMENTOUTTAXRF" + Environment.NewLine;
                //selectTxt += " ,CUSTDMD.PAYMENTINTAXRF" + Environment.NewLine;
                // 2008.06.02 del end -----------------------<<
                selectTxt += " ,CUSTDMD.TAXADJUSTRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.BALANCEADJUSTRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.AFCALDEMANDPRICERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CADDUPUPDEXECDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.STARTCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.LASTCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.BILLPRINTDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.EXPECTEDDEPOSITDATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.COLLECTCONDRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CONSTAXLAYMETHODRF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.CONSTAXRATERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.FRACTIONPROCCDRF" + Environment.NewLine;
                // ADD 2009/06/18 >>>
                selectTxt += " ,CUSTDMD.BILLNORF" + Environment.NewLine;
                // ADD 2009/06/18 <<<
                selectTxt += "FROM CUSTDMDPRCRF AS CUSTDMD" + Environment.NewLine;
                
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt += " WHERE" + Environment.NewLine;

                selectTxt += "     CUSTDMD.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                //計上拠点コード
                if (string.IsNullOrEmpty(sectionCode) == false)
                {
                    selectTxt += " AND CUSTDMD.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                }

                //請求先コード
                if (claimCode > 0)
                {
                    selectTxt += " AND CUSTDMD.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(claimCode);
                }

                //実績拠点コード  
                if (customerCode > 0)
                {
                    //対象得意先レコードと集計レコードを抽出
                    selectTxt += "  AND ((CUSTDMD.RESULTSSECTCDRF=@FINDRESULTSSECTCD AND CUSTDMD.CUSTOMERCODERF=@FINDCUSTOMERCODE) OR (CUSTDMD.RESULTSSECTCDRF='00' AND CUSTDMD.CUSTOMERCODERF=0))" + Environment.NewLine;
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                    paraResultsSectCd.Value = SqlDataMediator.SqlSetString(resultsSectCd);

                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
                }
                else
                {
                    //集計レコードのみ抽出
                    selectTxt += "  AND (CUSTDMD.RESULTSSECTCDRF='00' AND CUSTDMD.CUSTOMERCODERF=0)" + Environment.NewLine;
                }

                selectTxt += "ORDER BY CUSTDMD.ADDUPDATERF DESC, CUSTDMD.RESULTSSECTCDRF DESC, CUSTDMD.CUSTOMERCODERF DESC" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                //計上日付退避用
                DateTime addupDate = DateTime.MinValue;

                while (myReader.Read())
                {
                    CustDmdPrcWork wkCustDmdPrcWork = CopyToCustDmdPrcWorkFromReader(ref myReader);

                    //計上日が変わったタイミングでリストを生成する
                    if (addupDate != DateTime.MinValue && addupDate != wkCustDmdPrcWork.AddUpDate)
                    {
                        //子レコードの抽出で、集計レコードのみ１件該当した場合は抽出対象としない
                        if (!(customerCode > 0 && dmdPrcList.Count == 1 && (dmdPrcList[0] as CustDmdPrcWork).CustomerCode == 0))
                        {
                            retList.Add(dmdPrcList); //請求金額マスタ追加

                            SearchDmdDepoTotalProc(dmdPrcList[0] as CustDmdPrcWork, ref dmdDepoTotalList);

                            retList.Add(dmdDepoTotalList);  //入金集計データ追加

                            retcsaList.Add(retList);
                        }

                        dmdPrcList = new ArrayList();
                        dmdDepoTotalList = new ArrayList();
                        retList = new ArrayList();
                    }

                    dmdPrcList.Add(wkCustDmdPrcWork);

                    addupDate = wkCustDmdPrcWork.AddUpDate; //計上日付退避
                        
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //最終レコードの処理
                if (dmdPrcList.Count != 0)
                {
                    //子レコードの抽出で、集計レコードのみ１件該当した場合は抽出対象としない
                    if (!(customerCode > 0 && dmdPrcList.Count == 1 && (dmdPrcList[0] as CustDmdPrcWork).CustomerCode == 0))
                    {
                        retList.Add(dmdPrcList); //請求金額マスタ追加

                        SearchDmdDepoTotalProc(dmdPrcList[0] as CustDmdPrcWork, ref dmdDepoTotalList);

                        retList.Add(dmdDepoTotalList);  //入金集計データ追加

                        retcsaList.Add(retList);
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 請求入金集計データ読込
        /// </summary>
        /// <param name="wkCustDmdPrcWork">請求金額マスタ</param>
        /// <param name="retList">請求入金集計データリスト</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求入金集計データ読込</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        private int SearchDmdDepoTotalProc(CustDmdPrcWork wkCustDmdPrcWork, ref ArrayList retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SqlConnection sqlConnection = null;

            retList = new ArrayList();
            try
            {

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "  ,MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "  ,DEPOSITRF" + Environment.NewLine;
                selectTxt += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.EnterpriseCode);

                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.AddUpSecCode);

                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustDmdPrcWork.ClaimCode);

                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustDmdPrcWork.AddUpDate);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    DmdDepoTotalWork wkDmdDepoTotalWork = CopyToDmdDepoTotalWorkFromReader(ref myReader);

                    retList.Add(wkDmdDepoTotalWork);

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
               
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }

            return status;
        }

        #endregion

        #region [WriteAccRec WriteTotalAccRec 売掛金額マスタ]
        /// <summary>
        /// 得意先売掛金額マスタを更新します
        /// </summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        public int WriteAccRec(ref object custAccRecWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;
            try
            {
                CustAccRecWork wkCustAccRecWork = custAccRecWork as CustAccRecWork;
                if (wkCustAccRecWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteAccRecProc(ref wkCustAccRecWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                custAccRecWork = wkCustAccRecWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.WriteAccRec(ref object custAccRecWork)");
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
        /// 得意先売掛金額マスタを更新します
        /// </summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        private int WriteAccRecProc(ref CustAccRecWork custAccRecWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retMsg = null;
            try
            {
                if (custAccRecWork != null)
                {
                    string selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  CUSTACC.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,CUSTACC.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "FROM CUSTACCRECRF AS CUSTACC" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     CUSTACC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND CUSTACC.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTACC.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTACC.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTACC.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    
                    //Selectコマンドの生成
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);
                    
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
                    
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != custAccRecWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (custAccRecWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "UPDATE CUSTACCRECRF SET" + Environment.NewLine;
                        selectTxt += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        selectTxt += ", UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += ", ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += ", FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += ", ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += ", CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                        selectTxt += ", CLAIMNAMERF=@CLAIMNAME" + Environment.NewLine;
                        selectTxt += ", CLAIMNAME2RF=@CLAIMNAME2" + Environment.NewLine;
                        selectTxt += ", CLAIMSNMRF=@CLAIMSNM" + Environment.NewLine;
                        selectTxt += ", CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                        selectTxt += ", CUSTOMERNAMERF=@CUSTOMERNAME" + Environment.NewLine;
                        selectTxt += ", CUSTOMERNAME2RF=@CUSTOMERNAME2" + Environment.NewLine;
                        selectTxt += ", CUSTOMERSNMRF=@CUSTOMERSNM" + Environment.NewLine;
                        selectTxt += ", ADDUPDATERF=@ADDUPDATE" + Environment.NewLine;
                        selectTxt += ", ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += ", LASTTIMEACCRECRF=@LASTTIMEACCREC" + Environment.NewLine;
                        selectTxt += ", THISTIMEFEEDMDNRMLRF=@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMEDISDMDNRMLRF=@THISTIMEDISDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMEDMDNRMLRF=@THISTIMEDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMETTLBLCACCRF=@THISTIMETTLBLCACC" + Environment.NewLine;
                        selectTxt += ", OFSTHISTIMESALESRF=@OFSTHISTIMESALES" + Environment.NewLine;
                        selectTxt += ", OFSTHISSALESTAXRF=@OFSTHISSALESTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETOUTTAXRF=@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETINTAXRF=@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETTAXFREERF=@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += ", OFFSETOUTTAXRF=@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += ", OFFSETINTAXRF=@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += ", THISTIMESALESRF=@THISTIMESALES" + Environment.NewLine;
                        selectTxt += ", THISSALESTAXRF=@THISSALESTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESOUTTAXRF=@ITDEDSALESOUTTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESINTAXRF=@ITDEDSALESINTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESTAXFREERF=@ITDEDSALESTAXFREE" + Environment.NewLine;
                        selectTxt += ", SALESOUTTAXRF=@SALESOUTTAX" + Environment.NewLine;
                        selectTxt += ", SALESINTAXRF=@SALESINTAX" + Environment.NewLine;
                        selectTxt += ", THISSALESPRICRGDSRF=@THISSALESPRICRGDS" + Environment.NewLine;
                        selectTxt += ", THISSALESPRCTAXRGDSRF=@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETOUTTAXRF=@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETINTAXRF=@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETTAXFREERF=@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += ", TTLRETOUTERTAXRF=@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += ", TTLRETINNERTAXRF=@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += ", THISSALESPRICDISRF=@THISSALESPRICDIS" + Environment.NewLine;
                        selectTxt += ", THISSALESPRCTAXDISRF=@THISSALESPRCTAXDIS" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISOUTTAXRF=@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISINTAXRF=@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISTAXFREERF=@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += ", TTLDISOUTERTAXRF=@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += ", TTLDISINNERTAXRF=@TTLDISINNERTAX" + Environment.NewLine;
                        // 2008.06.02 del start ----------------------------->>
                        //selectTxt += ", THISPAYOFFSETRF=@THISPAYOFFSET" + Environment.NewLine;
                        //selectTxt += ", THISPAYOFFSETTAXRF=@THISPAYOFFSETTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMOUTTAXRF=@ITDEDPAYMOUTTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMINTAXRF=@ITDEDPAYMINTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMTAXFREERF=@ITDEDPAYMTAXFREE" + Environment.NewLine;
                        //selectTxt += ", PAYMENTOUTTAXRF=@PAYMENTOUTTAX" + Environment.NewLine;
                        //selectTxt += ", PAYMENTINTAXRF=@PAYMENTINTAX" + Environment.NewLine;
                        // 2008.06.02 del end ------------------------------<<
                        selectTxt += ", TAXADJUSTRF=@TAXADJUST" + Environment.NewLine;
                        selectTxt += ", BALANCEADJUSTRF=@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += ", AFCALTMONTHACCRECRF=@AFCALTMONTHACCREC" + Environment.NewLine;
                        selectTxt += ", ACPODRTTL2TMBFACCRECRF=@ACPODRTTL2TMBFACCREC" + Environment.NewLine;
                        selectTxt += ", ACPODRTTL3TMBFACCRECRF=@ACPODRTTL3TMBFACCREC" + Environment.NewLine;
                        selectTxt += ", MONTHADDUPEXPDATERF=@MONTHADDUPEXPDATE" + Environment.NewLine;
                        selectTxt += ", STMONCADDUPUPDDATERF=@STMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += ", LAMONCADDUPUPDDATERF=@LAMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += ", SALESSLIPCOUNTRF=@SALESSLIPCOUNT" + Environment.NewLine;
                        // 2008.06.02 del start ----------------------------->>
                        //selectTxt += ", NONSTMNTAPPEARANCERF=@NONSTMNTAPPEARANCE" + Environment.NewLine;
                        //selectTxt += ", NONSTMNTISDONERF=@NONSTMNTISDONE" + Environment.NewLine;
                        //selectTxt += ", STMNTAPPEARANCERF=@STMNTAPPEARANCE" + Environment.NewLine;
                        //selectTxt += ", STMNTISDONERF=@STMNTISDONE" + Environment.NewLine;
                        // 2008.06.02 del end ------------------------------<<
                        selectTxt += ", CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD" + Environment.NewLine;
                        selectTxt += ", CONSTAXRATERF=@CONSTAXRATE" + Environment.NewLine;
                        selectTxt += ", FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                        selectTxt += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        selectTxt += " AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                        findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
                        
                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)custAccRecWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (custAccRecWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                        
                        //新規作成時のSQL文を生成
                        selectTxt = "";
                        selectTxt += "INSERT INTO CUSTACCRECRF" + Environment.NewLine;
                        selectTxt += "(" + Environment.NewLine;
                        selectTxt += "  CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += " ,ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMCODERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMNAMERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMNAME2RF" + Environment.NewLine;
                        selectTxt += " ,CLAIMSNMRF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERCODERF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERNAMERF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERSNMRF" + Environment.NewLine;
                        selectTxt += " ,ADDUPDATERF" + Environment.NewLine;
                        selectTxt += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += " ,LASTTIMEACCRECRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMETTLBLCACCRF" + Environment.NewLine;
                        selectTxt += " ,OFSTHISTIMESALESRF" + Environment.NewLine;
                        selectTxt += " ,OFSTHISSALESTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,OFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,OFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMESALESRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESINTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,SALESOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,SALESINTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRICRGDSRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLRETINNERTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRICDISRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRCTAXDISRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLDISINNERTAXRF" + Environment.NewLine;
                        // 2008.06.02 del start --------------------------->>
                        //selectTxt += " ,THISPAYOFFSETRF" + Environment.NewLine;
                        //selectTxt += " ,THISPAYOFFSETTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMOUTTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMINTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMTAXFREERF" + Environment.NewLine;
                        //selectTxt += " ,PAYMENTOUTTAXRF" + Environment.NewLine;
                        //selectTxt += " ,PAYMENTINTAXRF" + Environment.NewLine;
                        // 2008.06.02 del end -----------------------------<<
                        selectTxt += " ,TAXADJUSTRF" + Environment.NewLine;
                        selectTxt += " ,BALANCEADJUSTRF" + Environment.NewLine;
                        selectTxt += " ,AFCALTMONTHACCRECRF" + Environment.NewLine;
                        selectTxt += " ,ACPODRTTL2TMBFACCRECRF" + Environment.NewLine;
                        selectTxt += " ,ACPODRTTL3TMBFACCRECRF" + Environment.NewLine;
                        selectTxt += " ,MONTHADDUPEXPDATERF" + Environment.NewLine;
                        selectTxt += " ,STMONCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += " ,LAMONCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += " ,SALESSLIPCOUNTRF" + Environment.NewLine;
                        // 2008.06.02 del start --------------------------->>
                        //selectTxt += " ,NONSTMNTAPPEARANCERF" + Environment.NewLine;
                        //selectTxt += " ,NONSTMNTISDONERF" + Environment.NewLine;
                        //selectTxt += " ,STMNTAPPEARANCERF" + Environment.NewLine;
                        //selectTxt += " ,STMNTISDONERF" + Environment.NewLine;
                        // 2008.06.02 del end -----------------------------<<
                        selectTxt += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        selectTxt += " ,CONSTAXRATERF" + Environment.NewLine;
                        selectTxt += " ,FRACTIONPROCCDRF" + Environment.NewLine;
                        selectTxt += ")" + Environment.NewLine;
                        selectTxt += "VALUES" + Environment.NewLine;
                        selectTxt += "(" + Environment.NewLine;
                        selectTxt += "  @CREATEDATETIME" + Environment.NewLine;
                        selectTxt += " ,@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += " ,@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " ,@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += " ,@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " ,@CLAIMCODE" + Environment.NewLine;
                        selectTxt += " ,@CLAIMNAME" + Environment.NewLine;
                        selectTxt += " ,@CLAIMNAME2" + Environment.NewLine;
                        selectTxt += " ,@CLAIMSNM" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERCODE" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERNAME" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERNAME2" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERSNM" + Environment.NewLine;
                        selectTxt += " ,@ADDUPDATE" + Environment.NewLine;
                        selectTxt += " ,@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += " ,@LASTTIMEACCREC" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEDISDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMETTLBLCACC" + Environment.NewLine;
                        selectTxt += " ,@OFSTHISTIMESALES" + Environment.NewLine;
                        selectTxt += " ,@OFSTHISSALESTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += " ,@THISTIMESALES" + Environment.NewLine;
                        selectTxt += " ,@THISSALESTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESINTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@SALESOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@SALESINTAX" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRICRGDS" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRICDIS" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRCTAXDIS" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLDISINNERTAX" + Environment.NewLine;
                        // 2008.06.02 del start -------------------------->>
                        //selectTxt += " ,@THISPAYOFFSET" + Environment.NewLine;
                        //selectTxt += " ,@THISPAYOFFSETTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMOUTTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMINTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMTAXFREE" + Environment.NewLine;
                        //selectTxt += " ,@PAYMENTOUTTAX" + Environment.NewLine;
                        //selectTxt += " ,@PAYMENTINTAX" + Environment.NewLine;
                        // 2008.06.02 del end ----------------------------<<
                        selectTxt += " ,@TAXADJUST" + Environment.NewLine;
                        selectTxt += " ,@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += " ,@AFCALTMONTHACCREC" + Environment.NewLine;
                        selectTxt += " ,@ACPODRTTL2TMBFACCREC" + Environment.NewLine;
                        selectTxt += " ,@ACPODRTTL3TMBFACCREC" + Environment.NewLine;
                        selectTxt += " ,@MONTHADDUPEXPDATE" + Environment.NewLine;
                        selectTxt += " ,@STMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " ,@LAMONCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " ,@SALESSLIPCOUNT" + Environment.NewLine;
                        // 2008.06.02 del start ------------------------->>
                        //selectTxt += " ,@NONSTMNTAPPEARANCE" + Environment.NewLine;
                        //selectTxt += " ,@NONSTMNTISDONE" + Environment.NewLine;
                        //selectTxt += " ,@STMNTAPPEARANCE" + Environment.NewLine;
                        //selectTxt += " ,@STMNTISDONE" + Environment.NewLine;
                        // 2008.06.02 del end ---------------------------<<
                        selectTxt += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                        selectTxt += " ,@CONSTAXRATE" + Environment.NewLine;
                        selectTxt += " ,@FRACTIONPROCCD" + Environment.NewLine;
                        selectTxt += ")" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)custAccRecWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    #region Parameterオブジェクト作成
                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                    SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                    SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraLastTimeAccRec = sqlCommand.Parameters.Add("@LASTTIMEACCREC", SqlDbType.BigInt);
                    SqlParameter paraThisTimeFeeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEFEEDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDisDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDISDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeTtlBlcAcc = sqlCommand.Parameters.Add("@THISTIMETTLBLCACC", SqlDbType.BigInt);
                    SqlParameter paraOfsThisTimeSales = sqlCommand.Parameters.Add("@OFSTHISTIMESALES", SqlDbType.BigInt);
                    SqlParameter paraOfsThisSalesTax = sqlCommand.Parameters.Add("@OFSTHISSALESTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisTimeSales = sqlCommand.Parameters.Add("@THISTIMESALES", SqlDbType.BigInt);
                    SqlParameter paraThisSalesTax = sqlCommand.Parameters.Add("@THISSALESTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesTaxFree = sqlCommand.Parameters.Add("@ITDEDSALESTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraSalesInTax = sqlCommand.Parameters.Add("@SALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPricRgds = sqlCommand.Parameters.Add("@THISSALESPRICRGDS", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPrcTaxRgds = sqlCommand.Parameters.Add("@THISSALESPRCTAXRGDS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPricDis = sqlCommand.Parameters.Add("@THISSALESPRICDIS", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPrcTaxDis = sqlCommand.Parameters.Add("@THISSALESPRCTAXDIS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                    // 2008.06.02 del start ------------------------->>
                    //SqlParameter paraThisPayOffset = sqlCommand.Parameters.Add("@THISPAYOFFSET", SqlDbType.BigInt);
                    //SqlParameter paraThisPayOffsetTax = sqlCommand.Parameters.Add("@THISPAYOFFSETTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymOutTax = sqlCommand.Parameters.Add("@ITDEDPAYMOUTTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymInTax = sqlCommand.Parameters.Add("@ITDEDPAYMINTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymTaxFree = sqlCommand.Parameters.Add("@ITDEDPAYMTAXFREE", SqlDbType.BigInt);
                    //SqlParameter paraPaymentOutTax = sqlCommand.Parameters.Add("@PAYMENTOUTTAX", SqlDbType.BigInt);
                    //SqlParameter paraPaymentInTax = sqlCommand.Parameters.Add("@PAYMENTINTAX", SqlDbType.BigInt);
                    // 2008.06.02 del end ---------------------------<<
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                    SqlParameter paraAfCalTMonthAccRec = sqlCommand.Parameters.Add("@AFCALTMONTHACCREC", SqlDbType.BigInt);
                    SqlParameter paraAcpOdrTtl2TmBfAccRec = sqlCommand.Parameters.Add("@ACPODRTTL2TMBFACCREC", SqlDbType.BigInt);
                    SqlParameter paraAcpOdrTtl3TmBfAccRec = sqlCommand.Parameters.Add("@ACPODRTTL3TMBFACCREC", SqlDbType.BigInt);
                    SqlParameter paraMonthAddUpExpDate = sqlCommand.Parameters.Add("@MONTHADDUPEXPDATE", SqlDbType.Int);
                    SqlParameter paraStMonCAddUpUpdDate = sqlCommand.Parameters.Add("@STMONCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraLaMonCAddUpUpdDate = sqlCommand.Parameters.Add("@LAMONCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraSalesSlipCount = sqlCommand.Parameters.Add("@SALESSLIPCOUNT", SqlDbType.Int);
                    // 2008.06.02 del start ------------------------->>
                    //SqlParameter paraNonStmntAppearance = sqlCommand.Parameters.Add("@NONSTMNTAPPEARANCE", SqlDbType.BigInt);
                    //SqlParameter paraNonStmntIsdone = sqlCommand.Parameters.Add("@NONSTMNTISDONE", SqlDbType.BigInt);
                    //SqlParameter paraStmntAppearance = sqlCommand.Parameters.Add("@STMNTAPPEARANCE", SqlDbType.BigInt);
                    //SqlParameter paraStmntIsdone = sqlCommand.Parameters.Add("@STMNTISDONE", SqlDbType.BigInt);
                    // 2008.06.02 del end ---------------------------<<
                    SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                    SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                    #endregion

                    #region Parameterオブジェクト設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custAccRecWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custAccRecWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custAccRecWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custAccRecWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custAccRecWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                    paraClaimName.Value = SqlDataMediator.SqlSetString(custAccRecWork.ClaimName);
                    paraClaimName2.Value = SqlDataMediator.SqlSetString(custAccRecWork.ClaimName2);
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(custAccRecWork.ClaimSnm);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(custAccRecWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(custAccRecWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(custAccRecWork.CustomerSnm);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custAccRecWork.AddUpYearMonth);
                    paraLastTimeAccRec.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.LastTimeAccRec);
                    paraThisTimeFeeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeFeeDmdNrml);
                    paraThisTimeDisDmdNrml.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeDisDmdNrml);
                    paraThisTimeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeDmdNrml);
                    paraThisTimeTtlBlcAcc.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeTtlBlcAcc);
                    paraOfsThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.OfsThisTimeSales);
                    paraOfsThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.OfsThisSalesTax);
                    paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedOffsetOutTax);
                    paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedOffsetInTax);
                    paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedOffsetTaxFree);
                    paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.OffsetOutTax);
                    paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.OffsetInTax);
                    paraThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisTimeSales);
                    paraThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesTax);
                    paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedSalesOutTax);
                    paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedSalesInTax);
                    paraItdedSalesTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedSalesTaxFree);
                    paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.SalesOutTax);
                    paraSalesInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.SalesInTax);
                    paraThisSalesPricRgds.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesPricRgds);
                    paraThisSalesPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesPrcTaxRgds);
                    paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedRetOutTax);
                    paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedRetInTax);
                    paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedRetTaxFree);
                    paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlRetOuterTax);
                    paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlRetInnerTax);
                    paraThisSalesPricDis.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesPricDis);
                    paraThisSalesPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisSalesPrcTaxDis);
                    paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedDisOutTax);
                    paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedDisInTax);
                    paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlItdedDisTaxFree);
                    paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlDisOuterTax);
                    paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TtlDisInnerTax);
                    // 2008.06.02 del start --------------------------------------->>
                    //paraThisPayOffset.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisPayOffset);
                    //paraThisPayOffsetTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ThisPayOffsetTax);
                    //paraItdedPaymOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedPaymOutTax);
                    //paraItdedPaymInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedPaymInTax);
                    //paraItdedPaymTaxFree.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.ItdedPaymTaxFree);
                    //paraPaymentOutTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.PaymentOutTax);
                    //paraPaymentInTax.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.PaymentInTax);
                    // 2008.06.02 del end -----------------------------------------<<
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.TaxAdjust);
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.BalanceAdjust);
                    paraAfCalTMonthAccRec.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.AfCalTMonthAccRec);
                    paraAcpOdrTtl2TmBfAccRec.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.AcpOdrTtl2TmBfAccRec);
                    paraAcpOdrTtl3TmBfAccRec.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.AcpOdrTtl3TmBfAccRec);
                    paraMonthAddUpExpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.MonthAddUpExpDate);
                    paraStMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.StMonCAddUpUpdDate);
                    paraLaMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.LaMonCAddUpUpdDate);
                    paraSalesSlipCount.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.SalesSlipCount);
                    // 2008.06.02 del start --------------------------------------->>
                    //paraNonStmntAppearance.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.NonStmntAppearance);
                    //paraNonStmntIsdone.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.NonStmntIsdone);
                    //paraStmntAppearance.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.StmntAppearance);
                    //paraStmntIsdone.Value = SqlDataMediator.SqlSetInt64(custAccRecWork.StmntIsdone);
                    // 2008.06.02 del end -----------------------------------------<<
                    paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ConsTaxLayMethod);
                    paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(custAccRecWork.ConsTaxRate);
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.FractionProcCd);
                    #endregion

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
        /// 得意先売掛金額マスタの子レコード、集計レコードを更新します
        /// </summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタの子レコード、集計レコードを更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.02</br>
        public int WriteTotalAccRec(ref object custAccRecWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;
            try
            {
                ArrayList accRecDepoTotalList = null;
                CustAccRecWork wkCustAccRecWork = null;
                CustomSerializeArrayList csaList = custAccRecWork as CustomSerializeArrayList;

                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    if (csaList[i] is CustAccRecWork)
                    {
                        //売掛金額マスタ
                        wkCustAccRecWork = csaList[i] as CustAccRecWork;
                    }
                    else
                        if (csaList[i] is ArrayList)
                        {
                            //入金集計データ
                            accRecDepoTotalList = csaList[i] as ArrayList;
                        }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //売掛金額マスタ更新
                status = WriteAccRecProc(ref wkCustAccRecWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                //入金集計データ更新(集計レコードの更新の場合のみ)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && accRecDepoTotalList != null && wkCustAccRecWork.CustomerCode==0)
                {
                    status = WriteAccRecDepoTotal(ref accRecDepoTotalList, wkCustAccRecWork, ref sqlConnection, ref sqlTransaction);
                }
                
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
                base.WriteErrorLog(ex, "CustRsltUpdDB.WriteAccRec(ref object custAccRecWork)");
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
        /// 売掛入金集計データを更新します
        /// </summary>
        /// <param name="accRecDepoTotalList">売掛入金集計データList</param>
        /// <param name="wkCustAccRecWork">売掛入金集計データ削除用パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売掛入金集計データを更新します</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2009.01.08</br>
        /// </remarks>
        private int WriteAccRecDepoTotal(ref ArrayList accRecDepoTotalList, CustAccRecWork wkCustAccRecWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;
            //DELETEコマンドの生成
            try
            {
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM ACCRECDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustAccRecWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustAccRecWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();
                }

                for (int i = 0; i < accRecDepoTotalList.Count; i++)
                {
                    AccRecDepoTotalWork accRecDepoTotalWork = accRecDepoTotalList[i] as AccRecDepoTotalWork;

                    #region [Insert文作成]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO ACCRECDEPOTOTALRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "    ,CLAIMCODERF" + Environment.NewLine;
                    sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += "    ,DEPOSITRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    ,@CLAIMCODE" + Environment.NewLine;
                    sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += "    ,@DEPOSIT" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    #endregion  //[Insert文作成]

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)accRecDepoTotalWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクト作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                        SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                        SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                        SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                        SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                        #endregion

                        #region Parameterオブジェクト設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(accRecDepoTotalWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(accRecDepoTotalWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(accRecDepoTotalWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.AddUpSecCode);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.ClaimCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.CustomerCode);
                        paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(accRecDepoTotalWork.AddUpDate);
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.MoneyKindCode);
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(accRecDepoTotalWork.MoneyKindName);
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(accRecDepoTotalWork.MoneyKindDiv);
                        paraDeposit.Value = SqlDataMediator.SqlSetInt64(accRecDepoTotalWork.Deposit);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        #endregion

        #region [WriteDmdPrc WriteTotalDmdPrc 請求金額マスタ]
        /// <summary>
        /// 得意先請求金額マスタを更新します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        public int WriteDmdPrc(ref object custDmdPrcWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;

            //string sectionCode; // 2008.06.02 del
            //Int32 dmdProcNum;   // 2008.06.02 del
            try
            {
                CustDmdPrcWork wkCustDmdPrcWork = custDmdPrcWork as CustDmdPrcWork;
                if (wkCustDmdPrcWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
 
                /*
                //●請求処理通番の再採番
                //計上拠点コード
                sectionCode = wkCustDmdPrcWork.AddUpSecCode;

                status = CreateDmdProcNumProc(wkCustDmdPrcWork.EnterpriseCode, sectionCode, out dmdProcNum, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && dmdProcNum != 0)
                {
                    wkCustDmdPrcWork.DmdProcNum = dmdProcNum;
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //番号が取得出来なかった場合は終了
                else
                {
                    //部品からのステータス及びメッセージが無い場合はセット（ありえないが念のため）
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    if (retMsg == null || retMsg == "") retMsg = "請求処理通番が採番できませんでした。番号設定を見直してください。";
                    return status;
                }
                */

                //●write実行
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                    status = WriteDmdPrcProc(ref wkCustDmdPrcWork, out retMsg, ref sqlConnection, ref sqlTransaction);
                //}

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                custDmdPrcWork = wkCustDmdPrcWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustRsltUpdDB.WriteDmdPrc(ref object custDmdPrcWork)");
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
        /// 得意先請求金額マスタを更新します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        private int WriteDmdPrcProc(ref CustDmdPrcWork custDmdPrcWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retMsg = null;
            try
            {
                string selectTxt = "";

                if (custDmdPrcWork != null)
                {
                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  CUSTDMD.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,CUSTDMD.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "FROM CUSTDMDPRCRF AS CUSTDMD" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     CUSTDMD.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    selectTxt += " AND CUSTDMD.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    //Selectコマンドの生成
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    findParaResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != custDmdPrcWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (custDmdPrcWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "UPDATE CUSTDMDPRCRF SET" + Environment.NewLine;
                        selectTxt += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        selectTxt += ", UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += ", ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += ", FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += ", ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += ", CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                        selectTxt += ", CLAIMNAMERF=@CLAIMNAME" + Environment.NewLine;
                        selectTxt += ", CLAIMNAME2RF=@CLAIMNAME2" + Environment.NewLine;
                        selectTxt += ", CLAIMSNMRF=@CLAIMSNM" + Environment.NewLine;
                        selectTxt += ", RESULTSSECTCDRF=@RESULTSSECTCD" + Environment.NewLine;
                        selectTxt += ", CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                        selectTxt += ", CUSTOMERNAMERF=@CUSTOMERNAME" + Environment.NewLine;
                        selectTxt += ", CUSTOMERNAME2RF=@CUSTOMERNAME2" + Environment.NewLine;
                        selectTxt += ", CUSTOMERSNMRF=@CUSTOMERSNM" + Environment.NewLine;
                        selectTxt += ", ADDUPDATERF=@ADDUPDATE" + Environment.NewLine;
                        selectTxt += ", ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += ", LASTTIMEDEMANDRF=@LASTTIMEDEMAND" + Environment.NewLine;
                        selectTxt += ", THISTIMEFEEDMDNRMLRF=@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMEDISDMDNRMLRF=@THISTIMEDISDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMEDMDNRMLRF=@THISTIMEDMDNRML" + Environment.NewLine;
                        selectTxt += ", THISTIMETTLBLCDMDRF=@THISTIMETTLBLCDMD" + Environment.NewLine;
                        selectTxt += ", OFSTHISTIMESALESRF=@OFSTHISTIMESALES" + Environment.NewLine;
                        selectTxt += ", OFSTHISSALESTAXRF=@OFSTHISSALESTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETOUTTAXRF=@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETINTAXRF=@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDOFFSETTAXFREERF=@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += ", OFFSETOUTTAXRF=@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += ", OFFSETINTAXRF=@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += ", THISTIMESALESRF=@THISTIMESALES" + Environment.NewLine;
                        selectTxt += ", THISSALESTAXRF=@THISSALESTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESOUTTAXRF=@ITDEDSALESOUTTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESINTAXRF=@ITDEDSALESINTAX" + Environment.NewLine;
                        selectTxt += ", ITDEDSALESTAXFREERF=@ITDEDSALESTAXFREE" + Environment.NewLine;
                        selectTxt += ", SALESOUTTAXRF=@SALESOUTTAX" + Environment.NewLine;
                        selectTxt += ", SALESINTAXRF=@SALESINTAX" + Environment.NewLine;
                        selectTxt += ", THISSALESPRICRGDSRF=@THISSALESPRICRGDS" + Environment.NewLine;
                        selectTxt += ", THISSALESPRCTAXRGDSRF=@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETOUTTAXRF=@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETINTAXRF=@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDRETTAXFREERF=@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += ", TTLRETOUTERTAXRF=@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += ", TTLRETINNERTAXRF=@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += ", THISSALESPRICDISRF=@THISSALESPRICDIS" + Environment.NewLine;
                        selectTxt += ", THISSALESPRCTAXDISRF=@THISSALESPRCTAXDIS" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISOUTTAXRF=@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISINTAXRF=@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += ", TTLITDEDDISTAXFREERF=@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += ", TTLDISOUTERTAXRF=@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += ", TTLDISINNERTAXRF=@TTLDISINNERTAX" + Environment.NewLine;
                        // 2008.06.02 del start ------------------------->>
                        //selectTxt += ", THISPAYOFFSETRF=@THISPAYOFFSET" + Environment.NewLine;
                        //selectTxt += ", THISPAYOFFSETTAXRF=@THISPAYOFFSETTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMOUTTAXRF=@ITDEDPAYMOUTTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMINTAXRF=@ITDEDPAYMINTAX" + Environment.NewLine;
                        //selectTxt += ", ITDEDPAYMTAXFREERF=@ITDEDPAYMTAXFREE" + Environment.NewLine;
                        //selectTxt += ", PAYMENTOUTTAXRF=@PAYMENTOUTTAX" + Environment.NewLine;
                        //selectTxt += ", PAYMENTINTAXRF=@PAYMENTINTAX" + Environment.NewLine;
                        // 2008.06.02 del end ---------------------------<<
                        selectTxt += ", TAXADJUSTRF=@TAXADJUST" + Environment.NewLine;
                        selectTxt += ", BALANCEADJUSTRF=@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += ", AFCALDEMANDPRICERF=@AFCALDEMANDPRICE" + Environment.NewLine;
                        selectTxt += ", ACPODRTTL2TMBFBLDMDRF=@ACPODRTTL2TMBFBLDMD" + Environment.NewLine;
                        selectTxt += ", ACPODRTTL3TMBFBLDMDRF=@ACPODRTTL3TMBFBLDMD" + Environment.NewLine;
                        selectTxt += ", CADDUPUPDEXECDATERF=@CADDUPUPDEXECDATE" + Environment.NewLine;
                        selectTxt += ", STARTCADDUPUPDDATERF=@STARTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += ", LASTCADDUPUPDDATERF=@LASTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += ", SALESSLIPCOUNTRF=@SALESSLIPCOUNT" + Environment.NewLine;
                        selectTxt += ", BILLPRINTDATERF=@BILLPRINTDATE" + Environment.NewLine;
                        selectTxt += ", EXPECTEDDEPOSITDATERF=@EXPECTEDDEPOSITDATE" + Environment.NewLine;
                        selectTxt += ", COLLECTCONDRF=@COLLECTCOND" + Environment.NewLine;
                        selectTxt += ", CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD" + Environment.NewLine;
                        selectTxt += ", CONSTAXRATERF=@CONSTAXRATE" + Environment.NewLine;
                        selectTxt += ", FRACTIONPROCCDRF=@FRACTIONPROCCD" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        selectTxt += ", BILLNORF=@BILLNO" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
                        selectTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                        selectTxt += " AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                        selectTxt += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        selectTxt += " AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                        findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                        findParaResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)custDmdPrcWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (custDmdPrcWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        //新規作成時のSQL文を生成
                        selectTxt = "";
                        selectTxt += "INSERT INTO CUSTDMDPRCRF" + Environment.NewLine;
                        selectTxt += "(" + Environment.NewLine;
                        selectTxt += "  CREATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        selectTxt += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        selectTxt += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        selectTxt += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += " ,ADDUPSECCODERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMCODERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMNAMERF" + Environment.NewLine;
                        selectTxt += " ,CLAIMNAME2RF" + Environment.NewLine;
                        selectTxt += " ,CLAIMSNMRF" + Environment.NewLine;
                        selectTxt += " ,RESULTSSECTCDRF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERCODERF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERNAMERF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                        selectTxt += " ,CUSTOMERSNMRF" + Environment.NewLine;
                        selectTxt += " ,ADDUPDATERF" + Environment.NewLine;
                        selectTxt += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        selectTxt += " ,LASTTIMEDEMANDRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMEDMDNRMLRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMETTLBLCDMDRF" + Environment.NewLine;
                        selectTxt += " ,OFSTHISTIMESALESRF" + Environment.NewLine;
                        selectTxt += " ,OFSTHISSALESTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,OFFSETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,OFFSETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISTIMESALESRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESINTAXRF" + Environment.NewLine;
                        selectTxt += " ,ITDEDSALESTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,SALESOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,SALESINTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRICRGDSRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLRETINNERTAXRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRICDISRF" + Environment.NewLine;
                        selectTxt += " ,THISSALESPRCTAXDISRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        selectTxt += " ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        selectTxt += " ,TTLDISINNERTAXRF" + Environment.NewLine;
                        // 2008.06.02 del start -------------------------------->>
                        //selectTxt += " ,THISPAYOFFSETRF" + Environment.NewLine;
                        //selectTxt += " ,THISPAYOFFSETTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMOUTTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMINTAXRF" + Environment.NewLine;
                        //selectTxt += " ,ITDEDPAYMTAXFREERF" + Environment.NewLine;
                        //selectTxt += " ,PAYMENTOUTTAXRF" + Environment.NewLine;
                        //selectTxt += " ,PAYMENTINTAXRF" + Environment.NewLine;
                        // 2008.06.02 del end ---------------------------------<<
                        selectTxt += " ,TAXADJUSTRF" + Environment.NewLine;
                        selectTxt += " ,BALANCEADJUSTRF" + Environment.NewLine;
                        selectTxt += " ,AFCALDEMANDPRICERF" + Environment.NewLine;
                        selectTxt += " ,ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                        selectTxt += " ,ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                        selectTxt += " ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                        selectTxt += " ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += " ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                        selectTxt += " ,SALESSLIPCOUNTRF" + Environment.NewLine;
                        selectTxt += " ,BILLPRINTDATERF" + Environment.NewLine;
                        selectTxt += " ,EXPECTEDDEPOSITDATERF" + Environment.NewLine;
                        selectTxt += " ,COLLECTCONDRF" + Environment.NewLine;
                        selectTxt += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        selectTxt += " ,CONSTAXRATERF" + Environment.NewLine;
                        selectTxt += " ,FRACTIONPROCCDRF" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        selectTxt += " ,BILLNORF" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
                        selectTxt += ")" + Environment.NewLine;
                        selectTxt += "VALUES" + Environment.NewLine;
                        selectTxt += "(" + Environment.NewLine;
                        selectTxt += "  @CREATEDATETIME" + Environment.NewLine;
                        selectTxt += " ,@UPDATEDATETIME" + Environment.NewLine;
                        selectTxt += " ,@ENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " ,@FILEHEADERGUID" + Environment.NewLine;
                        selectTxt += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        selectTxt += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        selectTxt += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        selectTxt += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        selectTxt += " ,@ADDUPSECCODE" + Environment.NewLine;
                        selectTxt += " ,@CLAIMCODE" + Environment.NewLine;
                        selectTxt += " ,@CLAIMNAME" + Environment.NewLine;
                        selectTxt += " ,@CLAIMNAME2" + Environment.NewLine;
                        selectTxt += " ,@CLAIMSNM" + Environment.NewLine;
                        selectTxt += " ,@RESULTSSECTCD" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERCODE" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERNAME" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERNAME2" + Environment.NewLine;
                        selectTxt += " ,@CUSTOMERSNM" + Environment.NewLine;
                        selectTxt += " ,@ADDUPDATE" + Environment.NewLine;
                        selectTxt += " ,@ADDUPYEARMONTH" + Environment.NewLine;
                        selectTxt += " ,@LASTTIMEDEMAND" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEDISDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMEDMDNRML" + Environment.NewLine;
                        selectTxt += " ,@THISTIMETTLBLCDMD" + Environment.NewLine;
                        selectTxt += " ,@OFSTHISTIMESALES" + Environment.NewLine;
                        selectTxt += " ,@OFSTHISSALESTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@OFFSETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@OFFSETINTAX" + Environment.NewLine;
                        selectTxt += " ,@THISTIMESALES" + Environment.NewLine;
                        selectTxt += " ,@THISSALESTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESINTAX" + Environment.NewLine;
                        selectTxt += " ,@ITDEDSALESTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@SALESOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@SALESINTAX" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRICRGDS" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@TTLRETOUTERTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLRETINNERTAX" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRICDIS" + Environment.NewLine;
                        selectTxt += " ,@THISSALESPRCTAXDIS" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        selectTxt += " ,@TTLDISOUTERTAX" + Environment.NewLine;
                        selectTxt += " ,@TTLDISINNERTAX" + Environment.NewLine;
                        // 2008.06.02 del start -------------------------->>
                        //selectTxt += " ,@THISPAYOFFSET" + Environment.NewLine;
                        //selectTxt += " ,@THISPAYOFFSETTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMOUTTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMINTAX" + Environment.NewLine;
                        //selectTxt += " ,@ITDEDPAYMTAXFREE" + Environment.NewLine;
                        //selectTxt += " ,@PAYMENTOUTTAX" + Environment.NewLine;
                        //selectTxt += " ,@PAYMENTINTAX" + Environment.NewLine;
                        // 2008.06.02 del end ---------------------------<<
                        selectTxt += " ,@TAXADJUST" + Environment.NewLine;
                        selectTxt += " ,@BALANCEADJUST" + Environment.NewLine;
                        selectTxt += " ,@AFCALDEMANDPRICE" + Environment.NewLine;
                        selectTxt += " ,@ACPODRTTL2TMBFBLDMD" + Environment.NewLine;
                        selectTxt += " ,@ACPODRTTL3TMBFBLDMD" + Environment.NewLine;
                        selectTxt += " ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                        selectTxt += " ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                        selectTxt += " ,@SALESSLIPCOUNT" + Environment.NewLine;
                        selectTxt += " ,@BILLPRINTDATE" + Environment.NewLine;
                        selectTxt += " ,@EXPECTEDDEPOSITDATE" + Environment.NewLine;
                        selectTxt += " ,@COLLECTCOND" + Environment.NewLine;
                        selectTxt += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                        selectTxt += " ,@CONSTAXRATE" + Environment.NewLine;
                        selectTxt += " ,@FRACTIONPROCCD" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        selectTxt += " ,@BILLNO" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
                        selectTxt += ")" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)custDmdPrcWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    #region Parameterオブジェクト作成
                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                    SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@RESULTSSECTCD", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                    SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraLastTimeDemand = sqlCommand.Parameters.Add("@LASTTIMEDEMAND", SqlDbType.BigInt);
                    SqlParameter paraThisTimeFeeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEFEEDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDisDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDISDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDMDNRML", SqlDbType.BigInt);
                    SqlParameter paraThisTimeTtlBlcDmd = sqlCommand.Parameters.Add("@THISTIMETTLBLCDMD", SqlDbType.BigInt);
                    SqlParameter paraOfsThisTimeSales = sqlCommand.Parameters.Add("@OFSTHISTIMESALES", SqlDbType.BigInt);
                    SqlParameter paraOfsThisSalesTax = sqlCommand.Parameters.Add("@OFSTHISSALESTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisTimeSales = sqlCommand.Parameters.Add("@THISTIMESALES", SqlDbType.BigInt);
                    SqlParameter paraThisSalesTax = sqlCommand.Parameters.Add("@THISSALESTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesTaxFree = sqlCommand.Parameters.Add("@ITDEDSALESTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraSalesInTax = sqlCommand.Parameters.Add("@SALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPricRgds = sqlCommand.Parameters.Add("@THISSALESPRICRGDS", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPrcTaxRgds = sqlCommand.Parameters.Add("@THISSALESPRCTAXRGDS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPricDis = sqlCommand.Parameters.Add("@THISSALESPRICDIS", SqlDbType.BigInt);
                    SqlParameter paraThisSalesPrcTaxDis = sqlCommand.Parameters.Add("@THISSALESPRCTAXDIS", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                    // 2008.06.02 del start ------------------------------>>
                    //SqlParameter paraThisPayOffset = sqlCommand.Parameters.Add("@THISPAYOFFSET", SqlDbType.BigInt);
                    //SqlParameter paraThisPayOffsetTax = sqlCommand.Parameters.Add("@THISPAYOFFSETTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymOutTax = sqlCommand.Parameters.Add("@ITDEDPAYMOUTTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymInTax = sqlCommand.Parameters.Add("@ITDEDPAYMINTAX", SqlDbType.BigInt);
                    //SqlParameter paraItdedPaymTaxFree = sqlCommand.Parameters.Add("@ITDEDPAYMTAXFREE", SqlDbType.BigInt);
                    //SqlParameter paraPaymentOutTax = sqlCommand.Parameters.Add("@PAYMENTOUTTAX", SqlDbType.BigInt);
                    //SqlParameter paraPaymentInTax = sqlCommand.Parameters.Add("@PAYMENTINTAX", SqlDbType.BigInt);
                    // 2008.06.02 del end -------------------------------<<
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                    SqlParameter paraAfCalDemandPrice = sqlCommand.Parameters.Add("@AFCALDEMANDPRICE", SqlDbType.BigInt);
                    SqlParameter paraAcpOdrTtl2TmBfBlDmd = sqlCommand.Parameters.Add("@ACPODRTTL2TMBFBLDMD", SqlDbType.BigInt);
                    SqlParameter paraAcpOdrTtl3TmBfBlDmd = sqlCommand.Parameters.Add("@ACPODRTTL3TMBFBLDMD", SqlDbType.BigInt);
                    SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                    SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraSalesSlipCount = sqlCommand.Parameters.Add("@SALESSLIPCOUNT", SqlDbType.Int);
                    SqlParameter paraBillPrintDate = sqlCommand.Parameters.Add("@BILLPRINTDATE", SqlDbType.Int);
                    SqlParameter paraExpectedDepositDate = sqlCommand.Parameters.Add("@EXPECTEDDEPOSITDATE", SqlDbType.Int);
                    SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                    SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                    SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                    // ADD 2009/06/18 >>>
                    SqlParameter paraBillNo = sqlCommand.Parameters.Add("@BILLNO", SqlDbType.Int);
                    // ADD 2009/06/18 <<<

                    #endregion

                    #region Parameterオブジェクト設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custDmdPrcWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custDmdPrcWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custDmdPrcWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    paraClaimName.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimName);
                    paraClaimName2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimName2);
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimSnm);
                    paraResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerSnm);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custDmdPrcWork.AddUpYearMonth);
                    paraLastTimeDemand.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.LastTimeDemand);
                    paraThisTimeFeeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeFeeDmdNrml);
                    paraThisTimeDisDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeDisDmdNrml);
                    paraThisTimeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeDmdNrml);
                    paraThisTimeTtlBlcDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeTtlBlcDmd);
                    paraOfsThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OfsThisTimeSales);
                    paraOfsThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OfsThisSalesTax);
                    paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetOutTax);
                    paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetInTax);
                    paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetTaxFree);
                    paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OffsetOutTax);
                    paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OffsetInTax);
                    paraThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeSales);
                    paraThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesTax);
                    paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesOutTax);
                    paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesInTax);
                    paraItdedSalesTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesTaxFree);
                    paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.SalesOutTax);
                    paraSalesInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.SalesInTax);
                    paraThisSalesPricRgds.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPricRgds);
                    paraThisSalesPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPrcTaxRgds);
                    paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetOutTax);
                    paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetInTax);
                    paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetTaxFree);
                    paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlRetOuterTax);
                    paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlRetInnerTax);
                    paraThisSalesPricDis.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPricDis);
                    paraThisSalesPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPrcTaxDis);
                    paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisOutTax);
                    paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisInTax);
                    paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisTaxFree);
                    paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlDisOuterTax);
                    paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlDisInnerTax);
                    // 2008.06.02 del start ----------------------------->>
                    //paraThisPayOffset.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisPayOffset);
                    //paraThisPayOffsetTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisPayOffsetTax);
                    //paraItdedPaymOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedPaymOutTax);
                    //paraItdedPaymInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedPaymInTax);
                    //paraItdedPaymTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedPaymTaxFree);
                    //paraPaymentOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.PaymentOutTax);
                    //paraPaymentInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.PaymentInTax);
                    // 2008.06.02 del end ------------------------------<<
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TaxAdjust);
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.BalanceAdjust);
                    paraAfCalDemandPrice.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AfCalDemandPrice);
                    paraAcpOdrTtl2TmBfBlDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AcpOdrTtl2TmBfBlDmd);
                    paraAcpOdrTtl3TmBfBlDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AcpOdrTtl3TmBfBlDmd);
                    paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.CAddUpUpdExecDate);
                    paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.StartCAddUpUpdDate);
                    paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);
                    paraSalesSlipCount.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.SalesSlipCount);
                    paraBillPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.BillPrintDate);
                    paraExpectedDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.ExpectedDepositDate);
                    paraCollectCond.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CollectCond);
                    paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ConsTaxLayMethod);
                    paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(custDmdPrcWork.ConsTaxRate);
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.FractionProcCd);
                    // ADD 2009/06/18 >>>
                    paraBillNo.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.BillNo);
                    // ADD 2009/06/18 <<< 
                    #endregion

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
        /// 得意先請求金額マスタを更新します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.02</br>
        /// <br></br>
        public int WriteTotalDmdPrc(ref object custDmdPrcWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retMsg = null;

            try
            {
                ArrayList dmdDepoTotalList = null;
                CustDmdPrcWork wkCustDmdPrcWork = null;
                CustomSerializeArrayList csaList = custDmdPrcWork as CustomSerializeArrayList;

                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    if (csaList[i] is CustDmdPrcWork)
                    {
                        //請求金額マスタ
                        wkCustDmdPrcWork = csaList[i] as CustDmdPrcWork;
                    }
                    else
                        if (csaList[i] is ArrayList)
                        {
                            //入金集計データ
                            dmdDepoTotalList = csaList[i] as ArrayList;
                        }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //請求金額マスタの更新
                status = WriteDmdPrcProc(ref wkCustDmdPrcWork, out retMsg, ref sqlConnection, ref sqlTransaction);

                //入金集計データの更新(集計レコードの場合のみ更新)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && dmdDepoTotalList != null && wkCustDmdPrcWork.CustomerCode==0)
                {
                    status = WriteDepoTotalPrc(ref dmdDepoTotalList, wkCustDmdPrcWork, ref sqlConnection, ref sqlTransaction);
                }

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
                base.WriteErrorLog(ex, "CustRsltUpdDB.WriteDmdPrc(ref object custDmdPrcWork)");
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
        /// 請求入金集計データを更新します
        /// </summary>
        /// <param name="dmdDepoTotalList">請求入金集計データList</param>
        /// <param name="wkCustDmdPrcWork">請求入金集計データ削除用パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求入金集計データを更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2009.01.08</br>
        /// </remarks>
        private int WriteDepoTotalPrc(ref ArrayList dmdDepoTotalList, CustDmdPrcWork wkCustDmdPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;

            //Deleteコマンドの生成
            try
            {
                sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustDmdPrcWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustDmdPrcWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();
                }

                for (int i = 0; i < dmdDepoTotalList.Count; i++)
                {
                    DmdDepoTotalWork dmdDepoTotalWork = dmdDepoTotalList[i] as DmdDepoTotalWork;

                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DMDDEPOTOTALRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "    ,CLAIMCODERF" + Environment.NewLine;
                    sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += "    ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += "    ,DEPOSITRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    ,@CLAIMCODE" + Environment.NewLine;
                    sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += "    ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += "    ,@DEPOSIT" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    
                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dmdDepoTotalWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクト作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                        SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                        SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                        SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                        SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                        #endregion

                        #region Parameterオブジェクト設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdDepoTotalWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdDepoTotalWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dmdDepoTotalWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.AddUpSecCode);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.ClaimCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.CustomerCode);
                        paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdDepoTotalWork.AddUpDate);
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.MoneyKindCode);
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.MoneyKindName);
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.MoneyKindDiv);
                        paraDeposit.Value = SqlDataMediator.SqlSetInt64(dmdDepoTotalWork.Deposit);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        #endregion

        #region [DeleteAccRec 売掛金額マスタ]
        /// <summary>
        /// 得意先売掛金額マスタ情報を削除します
        /// </summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタ</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタ情報を削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.26</br>
        public int DeleteAccRec(object custAccRecWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                CustAccRecWork wkCustAccRecWork = custAccRecWork as CustAccRecWork;

                if (wkCustAccRecWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteAccRecProc(wkCustAccRecWork, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "CustRsltUpdDB.DeleteAccRec");
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
        /// 得意先売掛金額マスタ情報を削除します
        /// </summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタ情報を削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.26</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        private int DeleteAccRecProc(CustAccRecWork custAccRecWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSTACC.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTACC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "FROM CUSTACCRECRF AS CUSTACC" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     CUSTACC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND CUSTACC.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += " AND CUSTACC.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += " AND CUSTACC.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                selectTxt += " AND CUSTACC.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
                
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != custAccRecWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    selectTxt = "";
                    selectTxt += "DELETE" + Environment.NewLine;
                    selectTxt += "FROM CUSTACCRECRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += " AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    
                    //集計レコードの削除の場合は、子も全削除するため得意先を条件に入れない
                    if (custAccRecWork.CustomerCode != 0)
                    {
                        selectTxt += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    }

                    selectTxt += " AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    sqlCommand.CommandText = selectTxt;
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custAccRecWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.ClaimCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custAccRecWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custAccRecWork.AddUpDate);
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
        /// 得意先売掛金額マスタ情報を削除します
        /// </summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタ情報を削除後、集計レコードを更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.02</br>
        public int DeleteTotalAccRec(object custAccRecWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CustAccRecWork wkCustAccRecWork = null;
                //売掛金額マスタ
                wkCustAccRecWork = (custAccRecWork as CustomSerializeArrayList)[0] as CustAccRecWork;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //売掛金額マスタの削除
                status = DeleteAccRecProc(wkCustAccRecWork, ref sqlConnection, ref sqlTransaction);

                //売掛入金集計データ削除(集計レコードの削除の場合のみ)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wkCustAccRecWork.CustomerCode==0)
                {
                    status = DeleteAccRecDepoTotalProc(wkCustAccRecWork, ref sqlConnection, ref sqlTransaction);
                }

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
                base.WriteErrorLog(ex, "CustRsltUpdDB.DeleteAccRec");
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
        /// 売掛入金集計データ削除
        /// </summary>
        /// <param name="wkCustAccRecWork">売掛入金集計データ削除用パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売掛入金集計データ削除</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2009.01.08</br>
        private int DeleteAccRecDepoTotalProc(CustAccRecWork wkCustAccRecWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM ACCRECDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "  AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "  AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustAccRecWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustAccRecWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustAccRecWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            return status;
        }

        #endregion

        #region [DeleteDmdPrc 請求金額マスタ]
        /// <summary>
        /// 得意先請求金額マスタ情報を削除します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタ情報を削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.26</br>
        public int DeleteDmdPrc(object custDmdPrcWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                CustDmdPrcWork wkCustDmdPrcWork = custDmdPrcWork as CustDmdPrcWork;

                if (wkCustDmdPrcWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteDmdPrcProc(wkCustDmdPrcWork, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "CustRsltUpdDB.DeleteDmdPrc");
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
        /// 得意先請求金額マスタ情報を削除します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタ情報を削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.26</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        private int DeleteDmdPrcProc(CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUSTDMD.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,CUSTDMD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "FROM CUSTDMDPRCRF AS CUSTDMD" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     CUSTDMD.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                selectTxt += " AND CUSTDMD.ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add("@FINDRESULTSSECTCD", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                findParaResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != custDmdPrcWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    selectTxt = "";
                    selectTxt += "DELETE" + Environment.NewLine;
                    selectTxt += "FROM CUSTDMDPRCRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    selectTxt += " AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    
                    //集計レコードの削除の場合は子のレコードも全削除
                    if (custDmdPrcWork.CustomerCode > 0)
                    {
                        selectTxt += " AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                        selectTxt += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    }
                    selectTxt += " AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                    sqlCommand.CommandText = selectTxt;
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    findParaResultsSectCd.Value = custDmdPrcWork.ResultsSectCd;
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
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
        /// 得意先請求金額マスタ情報を削除後、集計レコードを更新します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタ情報を削除後、集計レコードを更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.02</br>
        public int DeleteTotalDmdPrc(object custDmdPrcWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CustDmdPrcWork wkCustDmdPrcWork = null;

                //請求金額マスタ
                wkCustDmdPrcWork = (custDmdPrcWork as CustomSerializeArrayList)[0] as CustDmdPrcWork;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //請求金額マスタ削除
                status = DeleteDmdPrcProc(wkCustDmdPrcWork, ref sqlConnection, ref sqlTransaction);

                //請求入金集計データ削除(集計レコードの削除の場合のみ)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && wkCustDmdPrcWork.CustomerCode==0)
                {
                    status = DeleteDmdDepoTotalProc(wkCustDmdPrcWork, ref sqlConnection, ref sqlTransaction);
                }

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
                base.WriteErrorLog(ex, "CustRsltUpdDB.DeleteDmdPrc");
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
        /// 請求入金集計データ削除
        /// </summary>
        /// <param name="wkCustDmdPrcWork">請求入金データ削除用パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求入金集計データ削除</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2009.01.08</br>
        private int DeleteDmdDepoTotalProc(CustDmdPrcWork wkCustDmdPrcWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                String sqlText = String.Empty;
                sqlText = String.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "        AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                sqlText += "        AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(wkCustDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(wkCustDmdPrcWork.ClaimCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(wkCustDmdPrcWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        #endregion

        #region [請求処理通番の自動採番]
        /// <summary>
        /// 請求処理通番を自動採番して返します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="dmdProcNum">請求処理通番の採番結果</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求処理通番を自動採番して返します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        private int CreateDmdProcNumProc(string enterpriseCode, string sectionCode, out Int32 dmdProcNum, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            dmdProcNum = 0;
            retMsg = "";

            NumberNumbering numberNumbering = new NumberNumbering();

            //番号範囲分ループ
            string firstNo = "";
            Int32 loopCnt = 0;	//最大ループカウンタ
            while (loopCnt <= 999999999)
            {
                string no;
                Int32 ptnCd;
                Int32 noCode;

                //noCode = 1400 ： 請求処理通番の採番
                noCode = 1400;

                //番号採番
                status = numberNumbering.Numbering(enterpriseCode, sectionCode, noCode, new string[0], out no, out ptnCd, out retMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //番号を数値型に変換
                    Int32 wkDmdProcNum = System.Convert.ToInt32(no);
                    //初回採番番号を保存
                    if (firstNo == "") firstNo = no;
                    //初回番号と同一番号が採番された場合ループカウンタをMaxにして終了
                    else if (firstNo.Equals(no))
                    {
                        loopCnt = 999999999;
                        break;
                    }
                    //請求処理通番挿入
                    dmdProcNum = wkDmdProcNum;
                }
                //採番できなかった場合には処理中断。
                else break;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;

                //同一番号がある場合にはループカウンタをインクリメントし再採番
                loopCnt++;
            }

            //全件ループしても取得出来ない場合
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                retMsg = "請求処理通番に空き番号がありません。削除可能な伝票を削除してください。";
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CustAccRecWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustAccRecWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        /// </remarks>
        private CustAccRecWork CopyToCustAccRecWorkFromReader(ref SqlDataReader myReader)
        {
            CustAccRecWork wkCustAccRecWork = new CustAccRecWork();

            #region クラスへ格納
            wkCustAccRecWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustAccRecWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustAccRecWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustAccRecWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustAccRecWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustAccRecWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustAccRecWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustAccRecWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustAccRecWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkCustAccRecWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkCustAccRecWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkCustAccRecWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkCustAccRecWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkCustAccRecWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustAccRecWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkCustAccRecWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkCustAccRecWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustAccRecWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkCustAccRecWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkCustAccRecWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF"));
            wkCustAccRecWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            wkCustAccRecWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
            wkCustAccRecWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkCustAccRecWork.ThisTimeTtlBlcAcc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACCRF"));
            wkCustAccRecWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkCustAccRecWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkCustAccRecWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
            wkCustAccRecWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
            wkCustAccRecWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
            wkCustAccRecWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
            wkCustAccRecWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
            wkCustAccRecWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkCustAccRecWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            wkCustAccRecWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            wkCustAccRecWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            wkCustAccRecWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));
            wkCustAccRecWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
            wkCustAccRecWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));
            wkCustAccRecWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkCustAccRecWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            wkCustAccRecWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
            wkCustAccRecWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
            wkCustAccRecWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
            wkCustAccRecWork.TtlRetOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"));
            wkCustAccRecWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
            wkCustAccRecWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkCustAccRecWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            wkCustAccRecWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
            wkCustAccRecWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
            wkCustAccRecWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
            wkCustAccRecWork.TtlDisOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF"));
            wkCustAccRecWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
            // 2008.06.02 del start ---------------------------------->>
            //wkCustAccRecWork.ThisPayOffset = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISPAYOFFSETRF"));
            //wkCustAccRecWork.ThisPayOffsetTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISPAYOFFSETTAXRF"));
            //wkCustAccRecWork.ItdedPaymOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMOUTTAXRF"));
            //wkCustAccRecWork.ItdedPaymInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMINTAXRF"));
            //wkCustAccRecWork.ItdedPaymTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMTAXFREERF"));
            //wkCustAccRecWork.PaymentOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTOUTTAXRF"));
            //wkCustAccRecWork.PaymentInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTINTAXRF"));
            // 2008.06.02 del end -----------------------------------<<
            wkCustAccRecWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkCustAccRecWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkCustAccRecWork.AfCalTMonthAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALTMONTHACCRECRF"));
            wkCustAccRecWork.AcpOdrTtl2TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFACCRECRF"));
            wkCustAccRecWork.AcpOdrTtl3TmBfAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFACCRECRF"));
            wkCustAccRecWork.MonthAddUpExpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHADDUPEXPDATERF"));
            wkCustAccRecWork.StMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STMONCADDUPUPDDATERF"));
            wkCustAccRecWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
            wkCustAccRecWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            // 2008.06.02 del start ---------------------------------->>
            //wkCustAccRecWork.NonStmntAppearance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NONSTMNTAPPEARANCERF"));
            //wkCustAccRecWork.NonStmntIsdone = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NONSTMNTISDONERF"));
            //wkCustAccRecWork.StmntAppearance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STMNTAPPEARANCERF"));
            //wkCustAccRecWork.StmntIsdone = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STMNTISDONERF"));
            // 2008.06.02 del end -----------------------------------<<
            wkCustAccRecWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkCustAccRecWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            wkCustAccRecWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            #endregion

            return wkCustAccRecWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CustDmdPrcWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustDmdPrcWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        /// </remarks>
        private CustDmdPrcWork CopyToCustDmdPrcWorkFromReader(ref SqlDataReader myReader)
        {
            CustDmdPrcWork wkCustDmdPrcWork = new CustDmdPrcWork();

            #region クラスへ格納
            wkCustDmdPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustDmdPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustDmdPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustDmdPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustDmdPrcWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustDmdPrcWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustDmdPrcWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustDmdPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustDmdPrcWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkCustDmdPrcWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkCustDmdPrcWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkCustDmdPrcWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkCustDmdPrcWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkCustDmdPrcWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));
            wkCustDmdPrcWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustDmdPrcWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkCustDmdPrcWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkCustDmdPrcWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustDmdPrcWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkCustDmdPrcWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkCustDmdPrcWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
            wkCustDmdPrcWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeTtlBlcDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCDMDRF"));
            wkCustDmdPrcWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkCustDmdPrcWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
            wkCustDmdPrcWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
            wkCustDmdPrcWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
            wkCustDmdPrcWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkCustDmdPrcWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            wkCustDmdPrcWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            wkCustDmdPrcWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            wkCustDmdPrcWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));
            wkCustDmdPrcWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
            wkCustDmdPrcWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));
            wkCustDmdPrcWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkCustDmdPrcWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            wkCustDmdPrcWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
            wkCustDmdPrcWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
            wkCustDmdPrcWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
            wkCustDmdPrcWork.TtlRetOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"));
            wkCustDmdPrcWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
            wkCustDmdPrcWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkCustDmdPrcWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            wkCustDmdPrcWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
            wkCustDmdPrcWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
            wkCustDmdPrcWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
            wkCustDmdPrcWork.TtlDisOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF"));
            wkCustDmdPrcWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
            // 2008.06.02 del start --------------------------->>
            //wkCustDmdPrcWork.ThisPayOffset = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISPAYOFFSETRF"));
            //wkCustDmdPrcWork.ThisPayOffsetTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISPAYOFFSETTAXRF"));
            //wkCustDmdPrcWork.ItdedPaymOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMOUTTAXRF"));
            //wkCustDmdPrcWork.ItdedPaymInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMINTAXRF"));
            //wkCustDmdPrcWork.ItdedPaymTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMTAXFREERF"));
            //wkCustDmdPrcWork.PaymentOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTOUTTAXRF"));
            //wkCustDmdPrcWork.PaymentInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTINTAXRF"));
            // 2008.06.02 del end -----------------------------<<
            wkCustDmdPrcWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkCustDmdPrcWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkCustDmdPrcWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
            wkCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
            wkCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
            wkCustDmdPrcWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkCustDmdPrcWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkCustDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            wkCustDmdPrcWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            wkCustDmdPrcWork.BillPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BILLPRINTDATERF"));
            wkCustDmdPrcWork.ExpectedDepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTEDDEPOSITDATERF"));
            wkCustDmdPrcWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkCustDmdPrcWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkCustDmdPrcWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            wkCustDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            // ADD 2009/06/18 >>>
            wkCustDmdPrcWork.BillNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLNORF"));
            // ADD 2009/06/18 <<<
            #endregion

            return wkCustDmdPrcWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → DmdDepoTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>DmdDepoTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2009.01.08</br>
        /// <br></br>
        /// </remarks>
        private DmdDepoTotalWork CopyToDmdDepoTotalWorkFromReader(ref SqlDataReader myReader)
        {
            DmdDepoTotalWork wkDmdDepoTotalWork = new DmdDepoTotalWork();

            #region クラスへ格納
            wkDmdDepoTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkDmdDepoTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkDmdDepoTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkDmdDepoTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkDmdDepoTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkDmdDepoTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkDmdDepoTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkDmdDepoTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkDmdDepoTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkDmdDepoTotalWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkDmdDepoTotalWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkDmdDepoTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkDmdDepoTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkDmdDepoTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkDmdDepoTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkDmdDepoTotalWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            #endregion

            return wkDmdDepoTotalWork;
        }


        /// <summary>
        /// クラス格納処理 Reader → AccRecDepoTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AccRecDepoTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2009.01.08</br>
        /// <br></br>
        /// </remarks>
        private AccRecDepoTotalWork CopyToAccRecDepoTotalWorkFromReader(ref SqlDataReader myReader)
        {
            AccRecDepoTotalWork wkAccRecDepoTotalWork = new AccRecDepoTotalWork();

            #region クラスへ格納
            wkAccRecDepoTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkAccRecDepoTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkAccRecDepoTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAccRecDepoTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkAccRecDepoTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkAccRecDepoTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkAccRecDepoTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkAccRecDepoTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkAccRecDepoTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkAccRecDepoTotalWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkAccRecDepoTotalWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkAccRecDepoTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkAccRecDepoTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkAccRecDepoTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkAccRecDepoTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkAccRecDepoTotalWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            #endregion

            return wkAccRecDepoTotalWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.28</br>
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
