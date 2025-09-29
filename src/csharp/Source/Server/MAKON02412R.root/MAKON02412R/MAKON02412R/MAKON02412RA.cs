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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先元帳支払伝票抽出DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先元帳支払伝票抽出の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.05.08</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>           : 2007.12.04 流通基幹対応</br>
    /// <br>Update Note: FSI斎藤 和宏</br>
    /// <br>           : 2012/11/01 支払データに値引額・手数料額が反映されていない問題対応</br>
    /// </remarks>
    [Serializable]
    public class LedgerPaymentSlpWorkDB : RemoteDB
    {
        /// <summary>
        /// 仕入先元帳支払伝票抽出DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        /// </remarks>
        public LedgerPaymentSlpWorkDB()
            :
        base("MAKON02413D", "Broadleaf.Application.Remoting.ParamData.LedgerPaymentSlpWork", "PAYMENTSLPRF") //基底クラスのコンストラクタ
        {
        }

        #region 支払取得処理
        /// <summary>
        /// 指定された企業コードの仕入先元帳支払伝票抽出LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="ledgerPaymentSlpWork">検索結果（支払）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳支払伝票抽出LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        public int Search(out object ledgerPaymentSlpWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ledgerPaymentSlpWork = null;

            try
            {
                status = SearchProc(out ledgerPaymentSlpWork, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerPaymentSlpWorkDB.Search Exception=" + ex.Message);
                ledgerPaymentSlpWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの仕入先元帳支払伝票抽出LISTを全て戻します
        /// </summary>
        /// <param name="ledgerPaymentSlpWork">検索結果（支払）</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <param name="sqlConnection">SQLConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入先元帳支払伝票抽出LISTを全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>
        /// <br></br>
        /// <br>Update Note: 支払データに値引額・手数料額が反映されていない問題対応</br>
        /// <br>             消費税額表示不正対応</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2012/11/01 </br>
        private int SearchProc(out object ledgerPaymentSlpWork, string enterpriseCode, ArrayList addUpSecCodeList,
            int startSupplierCd, int endSupplierCd, int startAddUpDate, int endAddUpDate, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ledgerPaymentSlpWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            string sqlText = string.Empty;

            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   MAIN.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += "  ,MAIN.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYEECODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYEENAMERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYEENAME2RF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYEESNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.UPDATESECCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTDATERF" + Environment.NewLine;
                sqlText += "  ,MAIN.ADDUPADATERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += "  ,MAIN.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += "  ,MAIN.OUTLINERF" + Environment.NewLine;
                // --- ADD 2012/11/01 ---------->>>>>
                // 手数料と値引額を取得
                sqlText += "  ,MAIN.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += "  ,MAIN.DISCOUNTPAYMENTRF" + Environment.NewLine;
                // --- ADD 2012/11/01 ----------<<<<<
                sqlText += "  ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += "  ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += "  ,DTL.PAYMENTRF" + Environment.NewLine;
                sqlText += "  ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM PAYMENTSLPRF AS MAIN" + Environment.NewLine;
                sqlText += "LEFT JOIN PAYMENTDTLRF AS DTL ON (MAIN.ENTERPRISECODERF=DTL.ENTERPRISECODERF AND MAIN.SUPPLIERFORMALRF=DTL.SUPPLIERFORMALRF AND MAIN.PAYMENTSLIPNORF=DTL.PAYMENTSLIPNORF ) " + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    // Where文の作成
                    bool result = this.MakeWhereString(sqlCommand, enterpriseCode, addUpSecCodeList, startSupplierCd, endSupplierCd, startAddUpDate, endAddUpDate);
                    if (!result) return status;

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            this.SetListFromSQLReader(ref status, ref al, myReader);
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LedgerPaymentSlpWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            ledgerPaymentSlpWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SQLConnection</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">拠点コードリスト</param>
        /// <param name="startSupplierCd">仕入先コード(開始)</param>
        /// <param name="endSupplierCd">仕入先コード(終了)</param>
        /// <param name="startAddUpDate">計上日付(開始)</param>
        /// <param name="endAddUpDate">計上日付(終了)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>		
        /// <br></br>
        /// <br>Update Note: 980081  山田 明友</br>
        /// <br>           : 2007.12.04 流通基幹対応</br>
        private bool MakeWhereString(SqlCommand sqlCommand, string enterpriseCode, ArrayList addUpSecCodeList, int startSupplierCd, int endSupplierCd, 
            int startAddUpDate, int endAddUpDate)
        {
            #region WHERE文作成
            sqlCommand.CommandText += " WHERE";

            // 企業コード
            sqlCommand.CommandText += " MAIN.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            // 論理削除区分
            sqlCommand.CommandText += " AND MAIN.LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //支払先コード
            if (startSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND MAIN.PAYEECODERF>=@STPAYEECODE";
                SqlParameter paraStSupplierCode = sqlCommand.Parameters.Add("@STPAYEECODE", SqlDbType.Int);
                paraStSupplierCode.Value = SqlDataMediator.SqlSetInt32(startSupplierCd);
            }
            if (endSupplierCd != 0)
            {
                sqlCommand.CommandText += " AND MAIN.PAYEECODERF<=@EDPAYEECODE";
                SqlParameter paraEdSupplierCode = sqlCommand.Parameters.Add("@EDPAYEECODE", SqlDbType.Int);
                paraEdSupplierCode.Value = SqlDataMediator.SqlSetInt32(endSupplierCd);
            }

            // 計上日付
            if (startAddUpDate <= endAddUpDate)
            {
                if (startAddUpDate == endAddUpDate)
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPADATERF=@FINDADDUPADATE";
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPADATE", SqlDbType.Int);
                    paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                }
                else
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPADATERF>=@FINDSTARTADDUPADATE AND MAIN.ADDUPADATERF<=@FINDENDADDUPADATE";
                    SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTADDUPADATE", SqlDbType.Int);
                    paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startAddUpDate);
                    SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDADDUPADATE", SqlDbType.Int);
                    paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endAddUpDate);
                }
            }
            else
            {
                return false;
            }

            // 計上拠点
            StringBuilder whereSectionCode = new StringBuilder();
            if (addUpSecCodeList.Count > 0)
            {
                if (addUpSecCodeList.Count == 1)
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPSECCODERF='" + addUpSecCodeList[0] + "'";
                }
                else
                {
                    sqlCommand.CommandText += " AND MAIN.ADDUPSECCODERF IN (";
                    string str = "";
                    for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
                    {
                        if (ix != 0)
                        {
                            str += ",";
                        }
                        str += "'" + addUpSecCodeList[ix] + "'";
                    }
                    sqlCommand.CommandText += str + ")";
                }
            }

            #endregion
            return true;
        }

        /// <summary>
        /// 仕入先元帳支払伝票リスト格納処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <param name="al">仕入先元帳支払伝票リスト</param>
        /// <param name="myReader">SQLDataReader</param>
        /// <br>Note       : SQLDataReaderの情報を仕入先元帳支払伝票リストにセットします。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>		
        private void SetListFromSQLReader(ref int status, ref ArrayList al, SqlDataReader myReader)
        {
            if (al == null)
            {
                al = new ArrayList();
            }

            LedgerPaymentSlpWork _ledgerPaymentSlpWork;

            while (myReader.Read())
            {
                _ledgerPaymentSlpWork = new LedgerPaymentSlpWork();
                this.CopyToDataClassFromSelectData(ref _ledgerPaymentSlpWork, myReader);
                al.Add(_ledgerPaymentSlpWork);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }

        /// <summary>
        /// SQLデータリーダー→仕入先元帳支払伝票ワーク
        /// </summary>
        /// <param name="_ledgerPaymentSlpWork">仕入先元帳支払伝票ワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SQLデータリーダーに保持している内容を仕入先元帳支払伝票ワークにコピーします。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.05.08</br>		
        /// <br></br>
        /// <br>Update Note: 980081  山田 明友</br>
        /// <br>           : 2007.12.04 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: FSI斎藤 和宏</br>
        /// <br>Date       : 2012/11/01 支払データに値引額・手数料額が反映されていない問題対応
        /// <br>             </br>
        private void CopyToDataClassFromSelectData(ref LedgerPaymentSlpWork _ledgerPaymentSlpWork, SqlDataReader myReader)
        {
            #region 仕入先元帳支払伝票ワークへ格納
            _ledgerPaymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            _ledgerPaymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            _ledgerPaymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
            _ledgerPaymentSlpWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            _ledgerPaymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            _ledgerPaymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            _ledgerPaymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            _ledgerPaymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            _ledgerPaymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            _ledgerPaymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            _ledgerPaymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            _ledgerPaymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            _ledgerPaymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            _ledgerPaymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
            _ledgerPaymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            _ledgerPaymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            _ledgerPaymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
            _ledgerPaymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            _ledgerPaymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
            _ledgerPaymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
            _ledgerPaymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
            _ledgerPaymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
            _ledgerPaymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            _ledgerPaymentSlpWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
            _ledgerPaymentSlpWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            _ledgerPaymentSlpWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            _ledgerPaymentSlpWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            _ledgerPaymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
            // --- ADD 2012/11/01 ---------->>>>>
            // 値引額と手数料額
            _ledgerPaymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
            _ledgerPaymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
            // --- ADD 2012/11/01 ----------<<<<<

            _ledgerPaymentSlpWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));

            #endregion
        }
    }
}
