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
    /// 支払残高元帳DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払残高元帳の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.10.03</br>
    /// <br></br>
    /// <br>Update Note: 2007.11.15  山田 明友</br>
    /// <br>             仕入先支払金額マスタレイアウト変更の対応</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.28  山田 明友</br>
    /// <br>             全拠点選択時に全拠点集計しているのを修正</br>
    /// <br></br>
    /// <br>Update Note: 2008.08.13  20081</br>
    /// <br>             ＰＭ.ＮＳ用に変更</br>
    /// <br></br>
    /// <br>Update Note: 2008.12.09  23012 畠中 啓次朗</br>
    /// <br>             ＰＭ.ＮＳ用に変更</br>
    /// </remarks>
    /// <br></br>
    /// <br>Update Note: 2008.12.25  23012 畠中 啓次朗</br>
    /// <br>             結果クラスの項目追加(仕様変更)</br>
    /// </remarks>
    [Serializable]
    public class PaymentBalanceLedgerDB : RemoteDB, IPaymentBalanceLedgerDB
    {
        /// <summary>
        /// 支払残高元帳DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        public PaymentBalanceLedgerDB()
            :
            base("DCKAK02576D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PaymentBalanceWork", "SUPLIERPAYRF")
        {
        }

        #region [SearchPaymentBalanceLedger]
        /// <summary>
        /// 指定された条件の支払残高元帳を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の支払残高元帳を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.03</br>
        public int SearchPaymentBalanceLedger(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_PaymentBalanceWork extrInfo_PaymentBalanceWork = null;
            //RsltInfo_PaymentBalanceWork rsltInfo_PaymentBalanceWork = null;

            ArrayList extrInfo_PaymentBalanceWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_PaymentBalanceWorkList == null)
            {
                extrInfo_PaymentBalanceWork = paraObj as ExtrInfo_PaymentBalanceWork;
            }
            else
            {
                if (extrInfo_PaymentBalanceWorkList.Count > 0)
                    extrInfo_PaymentBalanceWork = extrInfo_PaymentBalanceWorkList[0] as ExtrInfo_PaymentBalanceWork;
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
                status = SearchPaymentBalanceLedgerProc(ref retList, extrInfo_PaymentBalanceWork, ref sqlConnection);

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentBalanceLedgerDB.SearchPaymentBalanceLedger");
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
        /// 指定された条件の支払残高元帳を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_PaymentBalanceWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の支払残高元帳を戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.03</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15  山田 明友</br>
        /// <br>             仕入先支払金額マスタレイアウト変更の対応</br>
        private int SearchPaymentBalanceLedgerProc(ref ArrayList retList, ExtrInfo_PaymentBalanceWork extrInfo_PaymentBalanceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                #region [SQL文]

                //A:仕入先支払金額マスタ B:拠点情報設定ﾏｽﾀ C:仕入先ﾏｽﾀ D:従業員マスタ
                string sqlText = string.Empty;

                sqlText += "SELECT A.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,B.SECTIONGUIDENMRF AS ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += "    ,A.PAYEECODERF" + Environment.NewLine;
                // DEL 2008.12.09 >>>
                //sqlText += "    ,A.PAYEENAMERF" + Environment.NewLine;
                //sqlText += "    ,A.PAYEENAME2RF" + Environment.NewLine;
                //sqlText += "    ,A.PAYEESNMRF" + Environment.NewLine;
                // DEL 2008.12.09 <<<
                // ADD 2008.12.09 >>>
                sqlText += "    ,C.SUPPLIERNM1RF AS PAYEENAMERF" + Environment.NewLine;
                sqlText += "    ,C.SUPPLIERNM2RF AS PAYEENAME2RF" + Environment.NewLine;
                sqlText += "    ,C.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine;
                // ADD 2008.12.09 <<< 
                sqlText += "    ,A.ADDUPDATERF" + Environment.NewLine;
                sqlText += "    ,A.LASTTIMEPAYMENTRF" + Environment.NewLine;
                // ADD 2008.12.25 >>>
                sqlText += "    ,A.THISTIMESTOCKPRICERF" + Environment.NewLine;
                sqlText += "    ,A.THISSTCPRCTAXRF" + Environment.NewLine;
                // ADD 2008.12.25 <<<
                sqlText += "    ,A.THISTIMEPAYNRMLRF" + Environment.NewLine;
                sqlText += "    ,A.THISTIMETTLBLCPAYRF" + Environment.NewLine;
                sqlText += "    ,A.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                sqlText += "    ,A.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                sqlText += "    ,A.THISSTCKPRICRGDSRF" + Environment.NewLine;
                sqlText += "    ,A.THISSTCKPRICDISRF" + Environment.NewLine;
                sqlText += "    ,A.STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                sqlText += "    ,A.STOCKSLIPCOUNTRF" + Environment.NewLine;
                sqlText += "    ,A.STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                sqlText += "    ,A.STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                sqlText += "    ,C.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += "    ,D.SHORTNAMERF STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += "    ,C.PAYMENTCONDRF" + Environment.NewLine;
                sqlText += "    ,C.PAYMENTMONTHNAMERF" + Environment.NewLine;
                // ADD 2008.12.09 >>>
                sqlText += "    ,C.PAYMENTTOTALDAYRF" + Environment.NewLine;
                sqlText += "    ,C.PAYMENTDAYRF" + Environment.NewLine;
                // ADD 2008.12.09 <<<
                sqlText += " FROM SUPLIERPAYRF A" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF B ON A.ENTERPRISECODERF=B.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.ADDUPSECCODERF=B.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SUPPLIERRF C ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.PAYEECODERF=C.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN EMPLOYEERF D ON C.ENTERPRISECODERF=D.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND C.STOCKAGENTCODERF=D.EMPLOYEECODERF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                //Where句作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extrInfo_PaymentBalanceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_PaymentBalanceFromReader(ref myReader));

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
        /// <param name="extrInfo_PaymentBalanceWork">検索条件格納クラス</param>
        /// <returns>支払残高元帳抽出のSQL文字列</returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.03</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_PaymentBalanceWork extrInfo_PaymentBalanceWork)
        {
            //基本WHERE句の作成
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //●固定条件
            //企業コード
            retString.Append("A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentBalanceWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND A.LOGICALDELETECODERF=0 ");

            //親レコードのみを対象とする(仕入先コード=0のみ対象)
            retString.Append("AND A.SUPPLIERCDRF=0 ");

            //●これよりパラメータの値により動的変化の項目
            //計上拠点コード
            if (extrInfo_PaymentBalanceWork.PaymentAddupSecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_PaymentBalanceWork.PaymentAddupSecCodeList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND A.ADDUPSECCODERF IN (" + sectionString + ") ");
                }
            }

            //支払先コード
            if (extrInfo_PaymentBalanceWork.St_PayeeCode > 0)
            {
                retString.Append("AND A.PAYEECODERF>=@ST_PAYEECODE ");
                SqlParameter paraSt_PayeeCode = sqlCommand.Parameters.Add("@ST_PAYEECODE", SqlDbType.Int);
                paraSt_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentBalanceWork.St_PayeeCode);
            }
            if (extrInfo_PaymentBalanceWork.Ed_PayeeCode > 0)
            {
                retString.Append("AND A.PAYEECODERF<=@ED_PAYEECODE ");
                SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODE", SqlDbType.Int);
                paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentBalanceWork.Ed_PayeeCode);
            }

            //対象年月
            if (extrInfo_PaymentBalanceWork.St_AddUpYearMonth > 0)
            {
                retString.Append("AND A.ADDUPYEARMONTHRF>=@ST_ADDUPYEARMONTH ");
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ST_ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentBalanceWork.St_AddUpYearMonth);
            }
            if (extrInfo_PaymentBalanceWork.Ed_AddUpYearMonth > 0)
            {
                retString.Append("AND A.ADDUPYEARMONTHRF<=@ED_ADDUPYEARMONTH ");
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ED_ADDUPYEARMONTH", SqlDbType.Int);
                paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentBalanceWork.Ed_AddUpYearMonth);
            }

            ////0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:ﾌﾟﾗｽとﾏｲﾅｽ 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ
            //switch (extrInfo_PaymentBalanceWork.OutMoneyDiv)
            //{
            //    case 0:
            //        {
            //            break;
            //        }
            //    case 1:
            //        {
            //            retString.Append("AND A.STOCKTOTALPAYBALANCERF>=0 ");
            //            break;
            //        }
            //    case 2:
            //        {
            //            retString.Append("AND A.STOCKTOTALPAYBALANCERF>0 ");
            //            break;
            //        }
            //    case 3:
            //        {
            //            retString.Append("AND A.STOCKTOTALPAYBALANCERF=0 ");
            //            break;
            //        }
            //    case 4:
            //        {
            //            retString.Append("AND A.STOCKTOTALPAYBALANCERF!=0 ");
            //            break;
            //        }
            //    case 5:
            //        {
            //            retString.Append("AND A.STOCKTOTALPAYBALANCERF<=0 ");
            //            break;
            //        }
            //    case 6:
            //        {
            //            retString.Append("AND A.STOCKTOTALPAYBALANCERF<0 ");
            //            break;
            //        }
            //}

            //計上拠点コード＋支払先コード＋支払予定日順に並び替える
            retString.Append("ORDER BY A.ADDUPSECCODERF, A.PAYEECODERF, A.PAYMENTSCHEDULERF");

            return retString.ToString();
        }
        #endregion

        #region [支払残高元帳抽出結果クラス格納処理]
        /// <summary>
        /// 支払残高元帳抽出結果クラス格納処理 Reader → RsltInfo_PaymentBalanceWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_PaymentBalanceWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.03</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15  山田 明友</br>
        /// <br>             仕入先支払金額マスタレイアウト変更の対応</br>
        /// </remarks>
        private RsltInfo_PaymentBalanceWork CopyToRsltInfo_PaymentBalanceFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_PaymentBalanceWork wkRsltInfo_PaymentBalanceWork = new RsltInfo_PaymentBalanceWork();

            wkRsltInfo_PaymentBalanceWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_PaymentBalanceWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_PaymentBalanceWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkRsltInfo_PaymentBalanceWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkRsltInfo_PaymentBalanceWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkRsltInfo_PaymentBalanceWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkRsltInfo_PaymentBalanceWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_PaymentBalanceWork.LastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
            // ADD 2008.12.25 >>>
            wkRsltInfo_PaymentBalanceWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            wkRsltInfo_PaymentBalanceWork.ThisStcPrcTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF"));
            // ADD 2008.12.25 <<<
            wkRsltInfo_PaymentBalanceWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            wkRsltInfo_PaymentBalanceWork.ThisTimeTtlBlcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCPAYRF"));
            wkRsltInfo_PaymentBalanceWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            wkRsltInfo_PaymentBalanceWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            wkRsltInfo_PaymentBalanceWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            wkRsltInfo_PaymentBalanceWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            wkRsltInfo_PaymentBalanceWork.StockTotalPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
            wkRsltInfo_PaymentBalanceWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            wkRsltInfo_PaymentBalanceWork.StockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF"));
            wkRsltInfo_PaymentBalanceWork.StockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));
            wkRsltInfo_PaymentBalanceWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkRsltInfo_PaymentBalanceWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkRsltInfo_PaymentBalanceWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
            wkRsltInfo_PaymentBalanceWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
            // ADD 2008.12.09 >>>
            wkRsltInfo_PaymentBalanceWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
            wkRsltInfo_PaymentBalanceWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
            // ADD 2008.12.09 <<<
            return wkRsltInfo_PaymentBalanceWork;
        }

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.10.03</br>
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
