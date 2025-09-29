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
    /// 支払一覧表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.09.18</br>
    /// <br></br>
    /// <br>Update Note: 2007.11.15  山田 明友</br>
    /// <br>             仕入先支払金額マスタレイアウト変更の対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.22  山田 明友</br>
    /// <br>             全拠点指定時に該当データ無しになる対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.23  30290</br>
    /// <br>             得意先・仕入先分離対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.08.11  20081</br>
    /// <br>             ＰＭ.ＮＳ用に変更</br>
    /// <br></br>
    /// <br>Update Note: 2008.11.11  23012 畠中 啓次朗</br>
    /// <br>             不具合修正</br>
    /// <br></br>
    /// <br>Update Note: 2008.11.19  23012 畠中 啓次朗</br>
    /// <br>             抽出条件追加</br>
    /// </remarks>
    [Serializable]
    public class PaymentTableDB : RemoteDB, IPaymentTableDB
    {
        /// <summary>
        /// 支払一覧表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public PaymentTableDB()
            :
            base("DCKAK02516D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PaymentTotalWork", "SUPLIERPAYRF")
        {
        }

        #region [SearchPaymentTable]
        /// <summary>
        /// 指定された条件の支払一覧表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の支払一覧表を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.18</br>
        public int SearchPaymentTable(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_PaymentTotalWork extrInfo_PaymentTotalWork = null;
            RsltInfo_PaymentTotalWork rsltInfo_PaymentTotalWork = null;

            ArrayList extrInfo_PaymentTotalWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_PaymentTotalWorkList == null)
            {
                extrInfo_PaymentTotalWork = paraObj as ExtrInfo_PaymentTotalWork;
            }
            else
            {
                if (extrInfo_PaymentTotalWorkList.Count > 0)
                    extrInfo_PaymentTotalWork = extrInfo_PaymentTotalWorkList[0] as ExtrInfo_PaymentTotalWork;
            }

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF", "SUPLIERPAYRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //●支払金額マスタ取得
                status = SearchPaymentTableProc(ref retList, extrInfo_PaymentTotalWork, ref sqlConnection);
                
                //●不足情報の取得
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        rsltInfo_PaymentTotalWork = retList[i] as RsltInfo_PaymentTotalWork;

                        //精算支払集計データ取得
                        status = this.SearchAccPayTotal(ref rsltInfo_PaymentTotalWork, ref sqlConnection);
                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    }
                }                
                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentTableDB.SearchPaymentTable");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)retList;
            return status;
        }

        /// <summary>
        /// 指定された条件の支払一覧表を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_PaymentTotalWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の支払一覧表を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.18</br>
        /// <br>Update Note: 2007.11.15  山田 明友</br>
        /// <br>             仕入先支払金額マスタレイアウト変更の対応</br>
        /// <br>             2008/04/23  30290</br>
        /// <br>             得意先・仕入先分離対応</br>
        private int SearchPaymentTableProc(ref ArrayList retList, ExtrInfo_PaymentTotalWork extrInfo_PaymentTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SQL文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     SUPLIERPAYRF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,SECINFOSETRF.SECTIONGUIDENMRF AS ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.RESULTSSECTCDRF" + Environment.NewLine; // ADD 2009.01.27 
                sqlText += "    ,SUPLIERPAYRF.PAYEECODERF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.PAYEENAMERF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.PAYEENAME2RF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.PAYEESNMRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.ADDUPDATERF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.LASTTIMEPAYMENTRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.THISTIMEPAYNRMLRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.THISTIMETTLBLCPAYRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.THISTIMESTOCKPRICERF" + Environment.NewLine; // ADD 2009.01.27
                sqlText += "    ,SUPLIERPAYRF.THISSTCKPRICRGDSRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.THISSTCKPRICDISRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.STOCKSLIPCOUNTRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                sqlText += "    ,SUPLIERPAYRF.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                sqlText += "    ,SUPPLIERRF.PAYMENTMONTHNAMERF" + Environment.NewLine;
                sqlText += "    ,SUPPLIERRF.PAYMENTDAYRF" + Environment.NewLine;
                sqlText += "    ,ACCPAY.CNT" + Environment.NewLine; // ADD 2009.01.27 
                sqlText += " FROM SUPLIERPAYRF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF ON" + Environment.NewLine;
                sqlText += " (SUPLIERPAYRF.ENTERPRISECODERF=SECINFOSETRF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPLIERPAYRF.ADDUPSECCODERF=SECINFOSETRF.SECTIONCODERF" + Environment.NewLine;
                sqlText += " )" + Environment.NewLine;
                sqlText += " LEFT JOIN SUPPLIERRF ON" + Environment.NewLine;
                sqlText += " (SUPLIERPAYRF.ENTERPRISECODERF=SUPPLIERRF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND SUPLIERPAYRF.PAYEECODERF=SUPPLIERRF.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " )" + Environment.NewLine;
                // 修正 2009.01.27 >>>
                sqlText += " LEFT JOIN" + Environment.NewLine;
                sqlText += " (" + Environment.NewLine;
                sqlText += "   SELECT" + Environment.NewLine;
                sqlText += "    ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "    ADDUPSECCODERF," + Environment.NewLine;
                sqlText += "    PAYEECODERF," + Environment.NewLine;
                sqlText += "    ADDUPDATERF," + Environment.NewLine;
                sqlText += "    COUNT(MONEYKINDCODERF) CNT" + Environment.NewLine;
                sqlText += "   FROM" + Environment.NewLine;
                sqlText += "    ACCPAYTOTALRF " + Environment.NewLine;
                sqlText += "   GROUP BY" + Environment.NewLine;
                sqlText += "    ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "    ADDUPSECCODERF," + Environment.NewLine;
                sqlText += "    PAYEECODERF," + Environment.NewLine;
                sqlText += "    ADDUPDATERF    " + Environment.NewLine;
                sqlText += " ) AS ACCPAY" + Environment.NewLine;
                sqlText += " ON SUPLIERPAYRF.ENTERPRISECODERF = ACCPAY.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND SUPLIERPAYRF.ADDUPSECCODERF = ACCPAY.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " AND SUPLIERPAYRF.ADDUPDATERF = ACCPAY.ADDUPDATERF" + Environment.NewLine;
                sqlText += " AND SUPLIERPAYRF.PAYEECODERF =  ACCPAY.PAYEECODERF" + Environment.NewLine;
                // 修正 2009.01.27 <<<

                sqlCommand.CommandText = sqlText;
                #endregion

                //Where句作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extrInfo_PaymentTotalWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_PaymentTotalFromReader(ref myReader));

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

            return status;
        }

        #endregion

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="extrInfo_PaymentTotalWork">検索条件格納クラス</param>
        /// <returns>支払一覧表抽出のSQL文字列</returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_PaymentTotalWork extrInfo_PaymentTotalWork)
        {
            //基本WHERE句の作成
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //●固定条件
            //企業コード
            retString.Append("SUPLIERPAYRF.ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentTotalWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND SUPLIERPAYRF.LOGICALDELETECODERF=0 " + Environment.NewLine);

            //支払内訳
            if (extrInfo_PaymentTotalWork.PayeeItems == 1)
            {
                //支払先のみ出力
                retString.Append("AND SUPLIERPAYRF.SUPPLIERCDRF=0 " + Environment.NewLine);
            }
            else if (extrInfo_PaymentTotalWork.PayeeItems == 2)
            {
                //仕入先のみ出力
                retString.Append("AND SUPLIERPAYRF.SUPPLIERCDRF!=0 " + Environment.NewLine);
            }

            //親レコードのみを対象とする(仕入先コード=0のみ対象)
            //retString.Append("AND SUPLIERPAYRF.SUPPLIERCDRF=0 ");  
            //retString.Append("AND SUPLIERPAYRF.CUSTOMERCODERF=0 ");

            //●これよりパラメータの値により動的変化の項目
            //計上拠点コード
            // ↓ 2008.01.22 980081 c
            //if (extrInfo_PaymentTotalWork.IsOptSection == false)
            if (extrInfo_PaymentTotalWork.PaymentAddupSecCodeList != null)
            // ↑ 2008.01.22 980081 c
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_PaymentTotalWork.PaymentAddupSecCodeList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND SUPLIERPAYRF.ADDUPSECCODERF IN (" + sectionString + ") " + Environment.NewLine);
                }
            }

            if (extrInfo_PaymentTotalWork.CAddUpUpdExecDate > DateTime.MinValue)
            {
                retString.Append("AND SUPLIERPAYRF.ADDUPDATERF=@CADDUPUPDEXECDATE " + Environment.NewLine);
                SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_PaymentTotalWork.CAddUpUpdExecDate);
            }

            ////計上年月日(締日)
            //if (extrInfo_PaymentTotalWork.St_CAddUpUpdExecDate > DateTime.MinValue)
            //{
            //    retString.Append("AND SUPLIERPAYRF.ADDUPDATERF>=@ST_CADDUPUPDEXECDATE ");
            //    SqlParameter paraSt_CAddUpUpdExecDate = sqlCommand.Parameters.Add("@ST_CADDUPUPDEXECDATE", SqlDbType.Int);
            //    paraSt_CAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_PaymentTotalWork.St_CAddUpUpdExecDate);
            //}
            //if (extrInfo_PaymentTotalWork.Ed_CAddUpUpdExecDate > DateTime.MinValue)
            //{
            //    retString.Append("AND SUPLIERPAYRF.ADDUPDATERF<=@ED_CADDUPUPDEXECDATE ");
            //    SqlParameter paraEd_CAddUpUpdExecDate = sqlCommand.Parameters.Add("@ED_CADDUPUPDEXECDATE", SqlDbType.Int);
            //    paraEd_CAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_PaymentTotalWork.Ed_CAddUpUpdExecDate);
            //}

            //支払先コード
            if (extrInfo_PaymentTotalWork.St_PayeeCode > 0)
            {
                // 2008.12.09 修正 >>>
                //retString.Append("AND SUPLIERPAYRF.PAYEECODERF>=@ST_PAYEECODE " + Environment.NewLine); 
                if (extrInfo_PaymentTotalWork.PayeeItems == 0)
                {
                    retString.Append("AND ( (CASE WHEN SUPLIERPAYRF.SUPPLIERCDRF =0 THEN SUPLIERPAYRF.PAYEECODERF ELSE SUPLIERPAYRF.SUPPLIERCDRF END )>=@ST_PAYEECODE) " + Environment.NewLine); 
                }
                else if (extrInfo_PaymentTotalWork.PayeeItems == 1)
                {
                    retString.Append("AND SUPLIERPAYRF.PAYEECODERF>=@ST_PAYEECODE AND SUPLIERPAYRF.SUPPLIERCDRF=0 " + Environment.NewLine); 
                }
                else
                {
                    retString.Append("AND SUPLIERPAYRF.SUPPLIERCDRF>=@ST_PAYEECODE AND SUPLIERPAYRF.SUPPLIERCDRF!=0 " + Environment.NewLine); 
                }
                // 2008.12.09 修正 <<<
                SqlParameter paraSt_PayeeCode = sqlCommand.Parameters.Add("@ST_PAYEECODE", SqlDbType.Int);
                paraSt_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentTotalWork.St_PayeeCode);
            }
            if (extrInfo_PaymentTotalWork.Ed_PayeeCode > 0)
            {
                //retString.Append("AND PAYEECODERF<=@ED_PAYEECODE "); // DEL 2008.11.10
                // 2008.12.09 修正 >>>
                //retString.Append("AND SUPLIERPAYRF.PAYEECODERF<=@ED_PAYEECODE " + Environment.NewLine); // ADD 2008.11.10
                if (extrInfo_PaymentTotalWork.PayeeItems == 0)
                {
                    retString.Append("AND ( (CASE WHEN SUPLIERPAYRF.SUPPLIERCDRF =0 THEN SUPLIERPAYRF.PAYEECODERF ELSE SUPLIERPAYRF.SUPPLIERCDRF END )<=@ED_PAYEECODE) " + Environment.NewLine);
                }
                else if (extrInfo_PaymentTotalWork.PayeeItems == 1)
                {
                    retString.Append("AND SUPLIERPAYRF.PAYEECODERF<=@ED_PAYEECODE AND SUPLIERPAYRF.SUPPLIERCDRF=0 " + Environment.NewLine);
                }
                else
                {
                    retString.Append("AND SUPLIERPAYRF.SUPPLIERCDRF<=@ED_PAYEECODE AND SUPLIERPAYRF.SUPPLIERCDRF!=0 " + Environment.NewLine);
                }
                // 2008.12.09 修正 <<<
                SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODE", SqlDbType.Int);
                paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentTotalWork.Ed_PayeeCode);
            }
            // 修正 2009.01.27 >>>
            #region DEL 2009.01.27 
            ////金額が全て\0は抽出しない　※取引が1件も存在しない
            //// ↓ 2007.11.15 980081 c
            ////retString.Append("AND (LASTTIMEPAYMENTRF != 0 OR THISTIMEPAYNRMLRF != 0 OR THISTIMEFEEPAYNRMLRF != 0 OR THISTIMEDISPAYNRMLRF != 0 OR THISTIMETTLBLCPAYRF != 0 OR THISNETSTCKPRICERF != 0 OR THISNETSTCPRCTAXRF != 0 OR ITDEDOFFSETOUTTAXRF != 0 OR ITDEDOFFSETINTAXRF != 0 OR ITDEDOFFSETTAXFREERF != 0 OR OFFSETOUTTAXRF != 0 OR OFFSETINTAXRF != 0 OR THISTIMESTOCKPRICERF != 0 OR THISSTCPRCTAXRF != 0 OR TTLITDEDSTCOUTTAXRF != 0 OR TTLITDEDSTCINTAXRF != 0 OR TTLITDEDSTCTAXFREERF != 0 OR TTLSTOCKOUTERTAXRF != 0 OR TTLSTOCKINNERTAXRF != 0 OR THISSTCKPRICRGDSRF != 0 OR THISSTCPRCTAXRGDSRF != 0 OR TTLITDEDRETOUTTAXRF != 0 OR TTLITDEDRETINTAXRF != 0 OR TTLITDEDRETTAXFREERF != 0 OR TTLRETOUTERTAXRF != 0 OR TTLRETINNERTAXRF != 0 OR THISSTCKPRICDISRF != 0 OR THISSTCPRCTAXDISRF != 0 OR TTLITDEDDISOUTTAXRF != 0 OR TTLITDEDDISINTAXRF != 0 OR TTLITDEDDISTAXFREERF != 0 OR TTLDISOUTERTAXRF != 0 OR TTLDISINNERTAXRF != 0 OR BALANCEADJUSTRF != 0) ");
            //// 2008.11.19 >>>>
            ////retString.Append("AND (LASTTIMEPAYMENTRF != 0 OR THISTIMEFEEPAYNRMLRF != 0 OR THISTIMEDISPAYNRMLRF != 0 OR THISTIMEPAYNRMLRF != 0 OR THISTIMETTLBLCPAYRF != 0 OR OFSTHISTIMESTOCKRF != 0 OR OFSTHISSTOCKTAXRF != 0 OR ITDEDOFFSETOUTTAXRF != 0 OR ITDEDOFFSETINTAXRF != 0 OR ITDEDOFFSETTAXFREERF != 0 OR OFFSETOUTTAXRF != 0 OR OFFSETINTAXRF != 0 OR THISTIMESTOCKPRICERF != 0 OR THISSTCPRCTAXRF != 0 OR TTLITDEDSTCOUTTAXRF != 0 OR TTLITDEDSTCINTAXRF != 0 OR TTLITDEDSTCTAXFREERF != 0 OR TTLSTOCKOUTERTAXRF != 0 OR TTLSTOCKINNERTAXRF != 0 OR THISSTCKPRICRGDSRF != 0 OR THISSTCPRCTAXRGDSRF != 0 OR TTLITDEDRETOUTTAXRF != 0 OR TTLITDEDRETINTAXRF != 0 OR TTLITDEDRETTAXFREERF != 0 OR TTLRETOUTERTAXRF != 0 OR TTLRETINNERTAXRF != 0 OR THISSTCKPRICDISRF != 0 OR THISSTCPRCTAXDISRF != 0 OR TTLITDEDDISOUTTAXRF != 0 OR TTLITDEDDISINTAXRF != 0 OR TTLITDEDDISTAXFREERF != 0 OR TTLDISOUTERTAXRF != 0 OR TTLDISINNERTAXRF != 0 OR TAXADJUSTRF != 0 OR BALANCEADJUSTRF != 0 OR STOCKTOTALPAYBALANCERF != 0)");
            //retString.Append("AND (" + Environment.NewLine);
            //retString.Append("LASTTIMEPAYMENTRF != 0"+ Environment.NewLine);
            //retString.Append(" OR THISTIMEFEEPAYNRMLRF != 0"+ Environment.NewLine);
            //retString.Append(" OR THISTIMEDISPAYNRMLRF != 0"+ Environment.NewLine);
            //retString.Append(" OR THISTIMEPAYNRMLRF != 0"+ Environment.NewLine);
            //retString.Append(" OR THISTIMETTLBLCPAYRF != 0"+ Environment.NewLine);
            //retString.Append(" OR OFSTHISTIMESTOCKRF != 0"+ Environment.NewLine);
            //retString.Append(" OR OFSTHISSTOCKTAXRF != 0"+ Environment.NewLine);
            //retString.Append(" OR ITDEDOFFSETOUTTAXRF != 0"+ Environment.NewLine);
            //retString.Append(" OR ITDEDOFFSETINTAXRF != 0"+ Environment.NewLine);
            //retString.Append(" OR ITDEDOFFSETTAXFREERF != 0"+ Environment.NewLine);
            //retString.Append(" OR OFFSETOUTTAXRF != 0"+ Environment.NewLine);
            //retString.Append(" OR OFFSETINTAXRF != 0"+ Environment.NewLine);
            //retString.Append(" OR THISTIMESTOCKPRICERF != 0" + Environment.NewLine);
            //retString.Append(" OR THISSTCPRCTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDSTCOUTTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDSTCINTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDSTCTAXFREERF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLSTOCKOUTERTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLSTOCKINNERTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR THISSTCKPRICRGDSRF != 0" + Environment.NewLine);
            //retString.Append(" OR THISSTCPRCTAXRGDSRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDRETOUTTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDRETINTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDRETTAXFREERF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLRETOUTERTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLRETINNERTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR THISSTCKPRICDISRF != 0" + Environment.NewLine);
            //retString.Append(" OR THISSTCPRCTAXDISRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDDISOUTTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDDISINTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLITDEDDISTAXFREERF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLDISOUTERTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TTLDISINNERTAXRF != 0" + Environment.NewLine);
            //retString.Append(" OR TAXADJUSTRF != 0" + Environment.NewLine);
            //retString.Append(" OR BALANCEADJUSTRF != 0" + Environment.NewLine);
            //retString.Append(" OR STOCKTOTALPAYBALANCERF != 0" + Environment.NewLine);
            //retString.Append(" OR STOCKTTL2TMBFBLPAYRF !=0" + Environment.NewLine);　// ADD 2008.11.19
            //retString.Append(" OR STOCKTTL3TMBFBLPAYRF !=0" + Environment.NewLine);　// ADD 2008.11.19
            //retString.Append(")" + Environment.NewLine);
            ////// ↑ 2007.11.15 980081 c
            //// 2008.11.19 <<<<
            #endregion
            retString.Append("AND (" + Environment.NewLine);
            retString.Append("     LASTTIMEPAYMENTRF != 0" + Environment.NewLine);
            retString.Append("     OR STOCKTTL2TMBFBLPAYRF != 0" + Environment.NewLine);
            retString.Append("     OR STOCKTTL3TMBFBLPAYRF != 0" + Environment.NewLine);
            retString.Append("     OR OFSTHISTIMESTOCKRF != 0" + Environment.NewLine);
            retString.Append("     OR OFSTHISSTOCKTAXRF != 0" + Environment.NewLine);
            retString.Append("     OR STOCKSLIPCOUNTRF != 0" + Environment.NewLine);
            retString.Append("     OR THISTIMEFEEPAYNRMLRF != 0" + Environment.NewLine);
            retString.Append("     OR THISTIMEDISPAYNRMLRF != 0" + Environment.NewLine);
            retString.Append("     OR ACCPAY.CNT != 0" + Environment.NewLine);
            retString.Append("    )" + Environment.NewLine);
            // 修正 2009.01.27 <<<

            //計上拠点コード＋支払先コード順に並び替える
            retString.Append("ORDER BY SUPLIERPAYRF.ADDUPSECCODERF, SUPLIERPAYRF.PAYEECODERF ");

            return retString.ToString();
        }
        #endregion

        /// <summary>
        /// 指定された条件の精算支払集計データを戻します
        /// </summary>
        /// <param name="rsltInfo_PaymentTotalWork">抽出結果パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の精算支払集計データを戻します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.08.11</br>
        private int SearchAccPayTotal(ref RsltInfo_PaymentTotalWork rsltInfo_PaymentTotalWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                //SQL文
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     MONEYKINDCODERF" + Environment.NewLine;
                sqlText += "    ,MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += "    ,MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += "    ,PAYMENTRF" + Environment.NewLine;
                sqlText += " FROM ACCPAYTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                sqlText += "    AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rsltInfo_PaymentTotalWork.EnterpriseCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(rsltInfo_PaymentTotalWork.AddUpSecCode);
                findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(rsltInfo_PaymentTotalWork.PayeeCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rsltInfo_PaymentTotalWork.PayeeCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rsltInfo_PaymentTotalWork.AddUpDate);

                myReader = sqlCommand.ExecuteReader();
                // ADD 2008.11.19 >>>
                //金種コードリスト
                rsltInfo_PaymentTotalWork.MoneyKindList = new ArrayList();
                // ADD 2008.11.19 <<<

                while(myReader.Read())
                {
                    RsltInfo_AccPayTotalWork rsltInfo_AccPayTotalWork = new RsltInfo_AccPayTotalWork();
                    rsltInfo_AccPayTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    rsltInfo_AccPayTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    rsltInfo_AccPayTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    rsltInfo_AccPayTotalWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    rsltInfo_PaymentTotalWork.MoneyKindList.Add(rsltInfo_AccPayTotalWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }                    
                // ADD 2008.11.19 >>>
                if (rsltInfo_PaymentTotalWork.MoneyKindList.Count ==0 )
                {
                    RsltInfo_AccPayTotalWork rsltInfo_AccPayTotalWork = new RsltInfo_AccPayTotalWork();
                    rsltInfo_AccPayTotalWork.MoneyKindCode = 0;
                    rsltInfo_AccPayTotalWork.MoneyKindName = "";
                    rsltInfo_AccPayTotalWork.MoneyKindDiv = 0;
                    rsltInfo_AccPayTotalWork.Payment = 0;
                    //金種コードリスト
                    rsltInfo_PaymentTotalWork.MoneyKindList = new ArrayList();
                    rsltInfo_PaymentTotalWork.MoneyKindList.Add(rsltInfo_AccPayTotalWork);
                }
                // ADD 2008.11.19 <<<
                
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

        #region [支払一覧表抽出結果クラス格納処理]
        /// <summary>
        /// 支払一覧表抽出結果クラス格納処理 Reader → RsltInfo_PaymentTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_PaymentTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.18</br>
        /// <br>Update Note: 2007.11.15  山田 明友</br>
        /// <br>             仕入先支払金額マスタレイアウト変更の対応</br>
        /// </remarks>
        private RsltInfo_PaymentTotalWork CopyToRsltInfo_PaymentTotalFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_PaymentTotalWork wkRsltInfo_PaymentTotalWork = new RsltInfo_PaymentTotalWork();

            #region クラスへ格納
            wkRsltInfo_PaymentTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRsltInfo_PaymentTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_PaymentTotalWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_PaymentTotalWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF")); // ADD 2009.01.27
            wkRsltInfo_PaymentTotalWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkRsltInfo_PaymentTotalWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkRsltInfo_PaymentTotalWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkRsltInfo_PaymentTotalWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkRsltInfo_PaymentTotalWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkRsltInfo_PaymentTotalWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            wkRsltInfo_PaymentTotalWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            wkRsltInfo_PaymentTotalWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkRsltInfo_PaymentTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_PaymentTotalWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_PaymentTotalWork.LastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
            wkRsltInfo_PaymentTotalWork.StockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF"));
            wkRsltInfo_PaymentTotalWork.StockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));
            wkRsltInfo_PaymentTotalWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            wkRsltInfo_PaymentTotalWork.ThisTimeTtlBlcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCPAYRF"));
            wkRsltInfo_PaymentTotalWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            wkRsltInfo_PaymentTotalWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF")); // ADD 2009.01.27
            wkRsltInfo_PaymentTotalWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            wkRsltInfo_PaymentTotalWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            wkRsltInfo_PaymentTotalWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            wkRsltInfo_PaymentTotalWork.StockTotalPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
            wkRsltInfo_PaymentTotalWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            wkRsltInfo_PaymentTotalWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
            wkRsltInfo_PaymentTotalWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
            wkRsltInfo_PaymentTotalWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
            wkRsltInfo_PaymentTotalWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
            #endregion

            return wkRsltInfo_PaymentTotalWork;
        }

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.18</br>
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
