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
using Broadleaf.Library.Diagnostics;  //ADD 2008/07/07 D.Tanaka

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 支払確認表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払確認表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.09.20</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.10  980081 山田 明友</br>
    /// <br>           : EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更</br>
    /// <br>Update Note: 2008.04.23  30290</br>
    /// <br>           : 得意先･仕入先分離対応</br>
    /// <br></br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Date       : 2008/07/07</br>
    /// <br>           : 99076 田中 大介</br>
    /// </remarks>
    [Serializable]
    //public class PaymentListWorkDB : RemoteDB, IPaymentListWorkDB             DEL 2008/07/07
    public class PaymentListWorkDB : RemoteWithAppLockDB, IPaymentListWorkDB  //ADD 2008/07/07
    {
        /// <summary>
        /// 支払確認表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        /// <br></br>
        /// <br>Note       : 3つのSearchは同じ結果を返してます。（UI開発時に個々に変える可能性あり)</br>
        /// <br>Date       : 2008/07/07</br>
        /// <br>           : 99076 田中 大介</br>
        /// </remarks>
        public PaymentListWorkDB()
            :
        base("DCKAK02536D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpListResultWork", "PAYMENTSLPRF") //基底クラスのコンストラクタ
        {
        }

        #region 支払確認表(簡易)
        /// <summary>
        /// 支払確認表(抜粋・詳細)LISTを戻します
        /// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(抜粋・詳細)</param>
        /// <param name="paymentSlpCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払確認表(抜粋・詳細)LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        public int SearchDepsitOnly(out object paymentSlpListResultWork, object paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paymentSlpListResultWork = null;

            PaymentSlpCndtnWork _paymentSlpCndtnWork = paymentSlpCndtnWork as PaymentSlpCndtnWork;

            try
            {
                status = SearchDepsitOnlyProc(out paymentSlpListResultWork, _paymentSlpCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitOnly Exception=" + ex.Message);
                paymentSlpListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 支払確認表(抜粋・詳細)LISTを戻します
        /// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(抜粋・詳細)</param>
        /// <param name="_paymentSlpCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払確認表(抜粋・詳細)LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        private int SearchDepsitOnlyProc(out object paymentSlpListResultWork, PaymentSlpCndtnWork _paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            paymentSlpListResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //●暗号化部品準備処理 ※2008/07/07 現状はコメントアウト（暗号化は別途対応）
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //支払データ取得実行部
                status = SearchDepsitOnlyAction(ref al, ref sqlConnection, _paymentSlpCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepositOnlyProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //暗号化キークローズ
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paymentSlpListResultWork = al;

            return status;
        }
        #endregion

        #region 支払確認表(金種別集計)
        /// <summary>
        /// 支払確認表(金種別集計)LISTを戻します
        /// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(抜粋・詳細)</param>
        /// <param name="paymentSlpCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払確認表(金種別集計)LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        public int SearchDepsitKind(out object paymentSlpListResultWork, object paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paymentSlpListResultWork = null;

            PaymentSlpCndtnWork _paymentSlpCndtnWork = paymentSlpCndtnWork as PaymentSlpCndtnWork;

            try
            {
                status = SearchDepsitKindProc(out paymentSlpListResultWork, _paymentSlpCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitOnly Exception=" + ex.Message);
                paymentSlpListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 支払確認表(金種別集計)LISTを戻します
        /// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(金種別集計)</param>
        /// <param name="_paymentSlpCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払確認表(金種別集計)LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        private int SearchDepsitKindProc(out object paymentSlpListResultWork, PaymentSlpCndtnWork _paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            paymentSlpListResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //●暗号化部品準備処理 2008/07/07 現状はコメントアウト（暗号化は別途対応）
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //支払データ取得実行部
                status = SearchDepsitKindAction(ref al, ref sqlConnection, _paymentSlpCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepositKindProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //暗号化キークローズ
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paymentSlpListResultWork = al;

            return status;
        }
        #endregion

        // 2008/07/07 DEL-Start ※7/8レビューで総合計は不要となった -------------- >>>>>
        #region 支払確認表(総合計)
        /*
        /// <summary>
        /// 支払確認表(総合計)LISTを戻します
        /// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(総合計)</param>
        /// <param name="paymentSlpCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sectionDepositDiv">sectionDepositDiv</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払確認表(総合計)LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        public int SearchAllTotal(out object paymentSlpListResultWork, object paymentSlpCndtnWork, int readMode, int sectionDepositDiv, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            paymentSlpListResultWork = null;

            PaymentSlpCndtnWork _paymentSlpCndtnWork = paymentSlpCndtnWork as PaymentSlpCndtnWork;

            try
            {
                status = SearchAllTotalProc(out paymentSlpListResultWork, _paymentSlpCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchAllTotal Exception=" + ex.Message);
                paymentSlpListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 支払確認表(総合計)LISTを戻します
        /// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(総合計)</param>
        /// <param name="_paymentSlpCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払確認表(総合計)LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        private int SearchAllTotalProc(out object paymentSlpListResultWork, PaymentSlpCndtnWork _paymentSlpCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            paymentSlpListResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //●暗号化部品準備処理  2008/07/07 現状はコメントアウト（暗号化は別途対応）
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //総合計取得実行部
                status = SearchAllTotalAction(ref al, ref sqlConnection, _paymentSlpCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchAllTotalProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //暗号化キークローズ
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paymentSlpListResultWork = al;

            return status;
        }
         */
        #endregion
        // 2008/07/07 DEL-End ---------------------------------------------------- <<<<<


        #region 支払確認表(簡易)取得処理(SQL実行部)
        /// <summary>
        /// 支払確認表(抜粋・詳細)取得処理(SQL実行部)
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_paymentSlpCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchDepsitOnlyAction(ref ArrayList al, ref SqlConnection sqlConnection, PaymentSlpCndtnWork _paymentSlpCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //--- UPD 2008/07/07 D.Tanaka --->>>
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " SLP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEESNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDESNMRF PAYMENTINPSECTIONNMRF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " ,SECI2.SECTIONGUIDESNMRF ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTDATERF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPADATERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.AUTOPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTNORF" + Environment.NewLine;
                sqlText += " ,SLP.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += " ,SLP.OUTLINERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKCODERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKNAMERF" + Environment.NewLine;
                //sqlText += " ,SLP.CREATEDATETIMERF" + Environment.NewLine; // ADD 2009/02/18
                sqlText += " ,SLP.INPUTDAYRF" + Environment.NewLine; // ADD 2009/03/26
                sqlText += " ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                // 修正 2009.01.26 >>>
                //sqlText += " ,DTL.PAYMENTRF PAYMENTMEIRF" + Environment.NewLine;
                sqlText += " ,(CASE WHEN DEBITNOTEDIVRF = 1 THEN  DTL.PAYMENTRF * -1 ELSE DTL.PAYMENTRF END) AS PAYMENTMEIRF" + Environment.NewLine;
                // 修正 2009.01.26 <<<
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS SLP LEFT OUTER JOIN PAYMENTDTLRF AS DTL" + Environment.NewLine;   // 支払伝票マスタ、支払明細データ
                sqlText += "    ON  SLP.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009.01.26 >>>
                //sqlText += "    AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += "       AND ((SLP.DEBITNOTEDIVRF != 1 AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF) OR" + Environment.NewLine;
                sqlText += "       (SLP.DEBITNOTEDIVRF = 1 AND SLP.DEBITNOTELINKPAYNORF = DTL.PAYMENTSLIPNORF))" + Environment.NewLine;
                // 修正 2009.01.26 <<<
                sqlText += "  LEFT OUTER JOIN SUPPLIERRF AS SPPL" + Environment.NewLine;                        // 仕入先マスタ
                sqlText += "    ON  SLP.ENTERPRISECODERF = SPPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.SUPPLIERCDRF = SPPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                      // 拠点情報設定マスタ
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.PAYMENTINPSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI2" + Environment.NewLine;
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.ADDUPSECCODERF = SECI2.SECTIONCODERF" + Environment.NewLine;

                //※支払伝票は入金ゼロ（金種ALLゼロ円）の『明細レコードなし』伝票の登録が可能な為、"LEFT OUTER JOIN" とする。

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [DC.NS-SQL文]
                /* DEL
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文の作成
                sqlCommand.CommandText += "SELECT " +
                                          "A.DEBITNOTEDIVRF, " +
                                          "A.PAYMENTSLIPNORF, " +
                                          "A.SUPPLIERSLIPNORF, " +
                                          "A.SUPPLIERCDRF, " +
                                          "A.SUPPLIERNM1RF, " +
                                          "A.SUPPLIERNM2RF, " +
                                          "B.KANARF AS KANARF, ";
                if (_paymentSlpCndtnWork.IsOptSection == false)
                {
                    sqlCommand.CommandText += "A.PAYMENTINPSECTIONCDRF, " +
                                              "C.SECTIONGUIDENMRF AS PAYMENTINPSECTIONNMRF, " +
                                              "A.ADDUPSECCODERF, " +
                                              "D.SECTIONGUIDENMRF AS ADDUPSECNAMERF, ";
                }
                else
                {
                    // 全社選択
                    sqlCommand.CommandText += "'' PAYMENTINPSECTIONCDRF, " +  // 支払入力拠点コード
                                              "'' PAYMENTINPSECTIONNMRF, " +  // 支払入力拠点名称
                                              "'' ADDUPSECCODERF, " +         // 計上拠点コード
                                              "'' ADDUPSECNAMERF, ";          // 計上拠点名称
                }

                sqlCommand.CommandText += "A.UPDATESECCDRF, " +
                                          "A.SUBSECTIONCODERF, " +
                                          "A.MINSECTIONCODERF, " +
                                          "A.PAYMENTDATERF, " +
                                          "A.ADDUPADATERF, " +
                                          "A.PAYMENTMONEYKINDCODERF, " +
                                          "A.PAYMENTMONEYKINDNAMERF, " +
                                          "A.PAYMENTMONEYKINDDIVRF, " +
                                          "A.PAYMENTTOTALRF, " +
                                          "A.PAYMENTRF, " +
                                          "A.FEEPAYMENTRF, " +
                                          "A.DISCOUNTPAYMENTRF, " +
                                          "A.REBATEPAYMENTRF, " +
                                          "A.AUTOPAYMENTRF, " +
                                          "A.CREDITORLOANCDRF, " +
                                          "A.CREDITCOMPANYCODERF, " +
                                          "A.DRAFTDRAWINGDATERF, " +
                                          "A.DRAFTPAYTIMELIMITRF, " +
                                          "A.DRAFTKINDRF, " +
                                          "A.DRAFTKINDNAMERF, " +
                                          "A.DRAFTDIVIDERF, " +
                                          "A.DRAFTDIVIDENAMERF, " +
                                          "A.DRAFTNORF, " +
                                          "A.DEBITNOTELINKPAYNORF, " +
                                          "A.PAYMENTAGENTCODERF, " +
                                          "A.PAYMENTAGENTNAMERF, " +
                                          "A.PAYMENTINPUTAGENTCDRF, " +
                                          "A.PAYMENTINPUTAGENTNMRF, " +
                                          "A.OUTLINERF, " +
                                          "A.BANKCODERF, " +
                                          "A.BANKNAMERF, " +
                                          "A.EDISENDDATERF, " +
                                          "A.EDITAKEINDATERF, " +
                                          "A.TEXTEXTRADATERF " +
                                          //"E.CREDITCOMPANYNAME " +
                                          "FROM PAYMENTSLPRF A " +
                                          "LEFT JOIN SUPPLIERRF B ON B.ENTERPRISECODERF=A.ENTERPRISECODERF AND B.SUPPLIERCDRF=A.SUPPLIERCDRF " +
                                          "LEFT JOIN SECINFOSETRF C ON C.ENTERPRISECODERF=A.ENTERPRISECODERF AND C.SECTIONCODERF=A.PAYMENTINPSECTIONCDRF " +
                                          "LEFT JOIN SECINFOSETRF D ON D.ENTERPRISECODERF=A.ENTERPRISECODERF AND D.SECTIONCODERF=A.ADDUPSECCODERF ";
                //"LEFT JOIN CREDITCMPRF E ON E.ENTERPRISECODERF=A.ENTERPRISECODERF AND E.CREDITCOMPANYCODERF=A.CREDITCOMPANYCODERF ";
                // ※2008/07/07 A→SLP、B→SPPL、C→SECI、D→SECI2

                 */
                # endregion
                //--- UPD 2008/07/07 D.Tanaka ---<<<

                //WHERE文(ORDER BY分も含む)の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

#if DEBUG
                Console.Clear();  //ADD 2008/07/07
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));  //ADD 2008/07/07
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();

                    // 2008/07/07 UPD-Start -------------------------------------------------- >>>>>
                    #region paymentSlpListResultWorkに値をセット
                    paymentSlpListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpListResultWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpListResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpListResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    paymentSlpListResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    paymentSlpListResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                    paymentSlpListResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                    paymentSlpListResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    paymentSlpListResultWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpListResultWork.PaymentInpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONNMRF"));
                    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    paymentSlpListResultWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpListResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpListResultWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpListResultWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpListResultWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpListResultWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpListResultWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    //paymentSlpListResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // ADD 2009/02/18
                    paymentSlpListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    paymentSlpListResultWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
                    paymentSlpListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    paymentSlpListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    paymentSlpListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    paymentSlpListResultWork.PaymentMei = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTMEIRF"));
                    paymentSlpListResultWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                    #endregion

                    #region OLD-DC.NSクラスへ格納
                    /*
                    paymentSlpListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpListResultWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpListResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpListResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpListResultWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpListResultWork.PaymentInpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONNMRF"));
                    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    paymentSlpListResultWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpListResultWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                    paymentSlpListResultWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                    paymentSlpListResultWork.PaymentMoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF"));
                    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpListResultWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                    paymentSlpListResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpListResultWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                    paymentSlpListResultWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                    paymentSlpListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpListResultWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                    paymentSlpListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpListResultWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpListResultWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpListResultWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpListResultWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpListResultWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    paymentSlpListResultWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    // ↓ 2007.12.10 980081 c
                    //paymentSlpListResultWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    paymentSlpListResultWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    // ↑ 2007.12.10 980081 c
                    paymentSlpListResultWork.TextExtraDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TEXTEXTRADATERF"));
                    //paymentSlpListResultWork.CreditCompanyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYNAMERF"));
                    //paymentSlpListResultWork.CashPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHPAYMENTRF"));
                    //paymentSlpListResultWork.TransferPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRANSFERPAYMENTRF"));
                    //paymentSlpListResultWork.DraftPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTPAYMENTRF"));
                    //paymentSlpListResultWork.OffsetPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETPAYMENTRF"));
                    //paymentSlpListResultWork.CheckPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKPAYMENTRF"));
                    //paymentSlpListResultWork.FutureCheckPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUTURECHECKPAYMENTRF"));
                    //paymentSlpListResultWork.OtherPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHERPAYMENTRF"));
                     */
                    #endregion
                    // 2008/07/07 UPD-End ---------------------------------------------------- <<<<<

                    al.Add(paymentSlpListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitOnlyAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region 支払確認表(金種別集計)取得処理(SQL実行部)
        /// <summary>
        /// 支払確認表(金種別集計)取得処理(SQL実行部)
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_paymentSlpCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchDepsitKindAction(ref ArrayList al, ref SqlConnection sqlConnection, PaymentSlpCndtnWork _paymentSlpCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //--- UPD 2008/07/07 D.Tanaka --->>>
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " SLP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEESNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDESNMRF PAYMENTINPSECTIONNMRF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " ,SECI2.SECTIONGUIDESNMRF ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTDATERF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPADATERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.AUTOPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTNORF" + Environment.NewLine;
                sqlText += " ,SLP.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += " ,SLP.OUTLINERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKCODERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                // 修正 2009.01.26 >+>>
                //sqlText += " ,DTL.PAYMENTRF PAYMENTMEIRF" + Environment.NewLine;
                sqlText += " ,(CASE WHEN DEBITNOTEDIVRF = 1 THEN  DTL.PAYMENTRF * -1 ELSE DTL.PAYMENTRF END) AS PAYMENTMEIRF" + Environment.NewLine;
                // 修正 2009.01.26 <<<
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS SLP LEFT OUTER JOIN PAYMENTDTLRF AS DTL" + Environment.NewLine;   // 支払伝票マスタ、支払明細データ
                sqlText += "    ON  SLP.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009.01.26 >>>
                //sqlText += "    AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += "       AND ((SLP.DEBITNOTEDIVRF != 1 AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF) OR" + Environment.NewLine;
                sqlText += "       (SLP.DEBITNOTEDIVRF = 1 AND SLP.DEBITNOTELINKPAYNORF = DTL.PAYMENTSLIPNORF))" + Environment.NewLine;
                // 修正 2009.01.26 <<<
                sqlText += "  LEFT OUTER JOIN SUPPLIERRF AS SPPL" + Environment.NewLine;                        // 仕入先マスタ
                sqlText += "    ON  SLP.ENTERPRISECODERF = SPPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.SUPPLIERCDRF = SPPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                      // 拠点情報設定マスタ
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.PAYMENTINPSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI2" + Environment.NewLine;
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.ADDUPSECCODERF = SECI2.SECTIONCODERF" + Environment.NewLine;

                //※支払伝票は入金ゼロ（金種ALLゼロ円）の『明細レコードなし』伝票の登録が可能な為、"LEFT OUTER JOIN" とする。

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //WHERE文(GROUP BY分も含む)の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();

                    #region paymentSlpListResultWorkに値をセット
                    paymentSlpListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpListResultWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpListResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpListResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    paymentSlpListResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    paymentSlpListResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                    paymentSlpListResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                    paymentSlpListResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    paymentSlpListResultWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpListResultWork.PaymentInpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONNMRF"));
                    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    paymentSlpListResultWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpListResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpListResultWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpListResultWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpListResultWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpListResultWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpListResultWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    paymentSlpListResultWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
                    paymentSlpListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    paymentSlpListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    paymentSlpListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    paymentSlpListResultWork.PaymentMei = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTMEIRF"));
                    paymentSlpListResultWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                    #endregion

                    al.Add(paymentSlpListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }


                # region [DC.NS-SQL文＆各金種の集計]
                /* 削除
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文の作成
                sqlCommand.CommandText += "SELECT ";
                if (_paymentSlpCndtnWork.IsOptSection == false)
                {
                    sqlCommand.CommandText += "A.ADDUPSECCODERF, " +
                                              "D.SECTIONGUIDENMRF AS ADDUPSECNAMERF, ";
                }
                else
                {
                    sqlCommand.CommandText += "'' ADDUPSECCODERF, " +
                                              "'' ADDUPSECNAMERF, ";
                }
                sqlCommand.CommandText += "A.ADDUPADATERF, " +
                                          "A.PAYMENTMONEYKINDDIVRF, " +
                                          "SUM (A.PAYMENTTOTALRF) AS PAYMENTTOTALRF " +
                                          "FROM PAYMENTSLPRF A " +
                                          "LEFT JOIN SECINFOSETRF D ON D.ENTERPRISECODERF=A.ENTERPRISECODERF AND D.SECTIONCODERF=A.ADDUPSECCODERF ";

                //WHERE文(GROUP BY分も含む)の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                bool firstFlg = true;
                DateTime addUpADate = DateTime.MinValue;
                string addUpSecCode = null;
                string addUpSecName = null;
                Int64 cashPayment = 0;
                Int64 transferPayment = 0;
                Int64 draftPayment = 0;
                Int64 offsetPayment = 0;
                Int64 checkPayment = 0;
                Int64 futureCheckPayment = 0;
                Int64 otherPayment = 0;
                Int64 feePayment = 0;
                Int64 discountPayment = 0;
                while (myReader.Read())
                {
                    if (firstFlg == true)
                    {
                        firstFlg = false;
                        addUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));            // 計上拠点コード
                        addUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));            // 計上拠点名称
                        addUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));  // 計上日付 
                    }
                    else if (addUpADate != SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF")) || addUpSecCode != SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF")))
                    {
                        PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();
                        #region paymentSlpListResultWorkに値をセット
                        paymentSlpListResultWork.AddUpSecCode = addUpSecCode;
                        paymentSlpListResultWork.AddUpSecName = addUpSecName;
                        paymentSlpListResultWork.AddUpADate = addUpADate;

                        paymentSlpListResultWork.CashPayment = cashPayment;
                        paymentSlpListResultWork.TransferPayment = transferPayment;
                        paymentSlpListResultWork.DraftPayment = draftPayment;
                        paymentSlpListResultWork.OffsetPayment = offsetPayment;
                        paymentSlpListResultWork.CheckPayment = checkPayment;
                        paymentSlpListResultWork.FutureCheckPayment = futureCheckPayment;
                        paymentSlpListResultWork.OtherPayment = otherPayment;
                        paymentSlpListResultWork.FeePayment = feePayment;
                        paymentSlpListResultWork.DiscountPayment = discountPayment;
                        #endregion
                        al.Add(paymentSlpListResultWork);
                        
                        addUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        addUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                        addUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        cashPayment = 0;
                        transferPayment = 0;
                        draftPayment = 0;
                        offsetPayment = 0;
                        checkPayment = 0;
                        futureCheckPayment = 0;
                        otherPayment = 0;
                        feePayment = 0;
                        discountPayment = 0;
                    }

                    switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDDIVRF")))
                    {
                        case 101://現金
                            {
                                cashPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 102://振込
                            {
                                transferPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 105://手形
                            {
                                draftPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 106://相殺
                            {
                                offsetPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 107://小切手
                            {
                                checkPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 108://先付小切手
                            {
                                futureCheckPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 109://その他
                            {
                                otherPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 110://手数料
                            {
                                feePayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                        case 111://値引
                            {
                                discountPayment += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                                break;
                            }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (firstFlg == false)
                {
                    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();
                    #region paymentSlpListResultWorkに値をセット
                    paymentSlpListResultWork.AddUpSecCode = addUpSecCode;
                    paymentSlpListResultWork.AddUpSecName = addUpSecName;
                    paymentSlpListResultWork.AddUpADate = addUpADate;

                    paymentSlpListResultWork.CashPayment = cashPayment;
                    paymentSlpListResultWork.TransferPayment = transferPayment;
                    paymentSlpListResultWork.DraftPayment = draftPayment;
                    paymentSlpListResultWork.OffsetPayment = offsetPayment;
                    paymentSlpListResultWork.CheckPayment = checkPayment;
                    paymentSlpListResultWork.FutureCheckPayment = futureCheckPayment;
                    paymentSlpListResultWork.OtherPayment = otherPayment;
                    paymentSlpListResultWork.FeePayment = feePayment;
                    paymentSlpListResultWork.DiscountPayment = discountPayment;
                    #endregion
                    al.Add(paymentSlpListResultWork);
                }
                 */
                # endregion
                //--- UPD 2008/07/07 D.Tanaka ---<<<
            }
            
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitKindAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        // 2008/07/07 DEL-Start ※7/8レビューで総合計は不要となった -------------- >>>>>
        #region 支払確認表(総合計)取得処理(SQL実行部)
        /*
        /// <summary>
        /// 支払確認表(総合計)取得処理(SQL実行部)
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_paymentSlpCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchAllTotalAction(ref ArrayList al, ref SqlConnection sqlConnection, PaymentSlpCndtnWork _paymentSlpCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //--- UPD 2008/07/07 D.Tanaka --->>>
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " SLP.DEBITNOTEDIVRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SLP.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,SLP.PAYEESNMRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPSECTIONCDRF" + Environment.NewLine;
                sqlText += " ,SECI.SECTIONGUIDESNMRF PAYMENTINPSECTIONNMRF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += " ,SECI2.SECTIONGUIDESNMRF ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTDATERF" + Environment.NewLine;
                sqlText += " ,SLP.ADDUPADATERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.FEEPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.AUTOPAYMENTRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDRAWINGDATERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDRF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += " ,SLP.DRAFTNORF" + Environment.NewLine;
                sqlText += " ,SLP.DEBITNOTELINKPAYNORF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTCDRF" + Environment.NewLine;
                sqlText += " ,SLP.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
                sqlText += " ,SLP.OUTLINERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKCODERF" + Environment.NewLine;
                sqlText += " ,SLP.BANKNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += " ,DTL.PAYMENTRF PAYMENTMEIRF" + Environment.NewLine;
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  PAYMENTSLPRF AS SLP LEFT OUTER JOIN PAYMENTDTLRF AS DTL" + Environment.NewLine;   // 支払伝票マスタ、支払明細データ
                sqlText += "    ON  SLP.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.PAYMENTSLIPNORF = DTL.PAYMENTSLIPNORF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SUPPLIERRF AS SPPL" + Environment.NewLine;                        // 仕入先マスタ
                sqlText += "    ON  SLP.ENTERPRISECODERF = SPPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.SUPPLIERCDRF = SPPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI" + Environment.NewLine;                      // 拠点情報設定マスタ
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.PAYMENTINPSECTIONCDRF = SECI.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS SECI2" + Environment.NewLine;
                sqlText += "    ON  SLP.ENTERPRISECODERF = SECI2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SLP.ADDUPSECCODERF = SECI2.SECTIONCODERF" + Environment.NewLine;

                //※支払伝票は入金ゼロ（金種ALLゼロ円）の『明細レコードなし』伝票の登録が可能な為、"LEFT OUTER JOIN" とする。

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //WHERE文(GROUP BY分も含む)の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();

                    #region paymentSlpListResultWorkに値をセット
                    paymentSlpListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    paymentSlpListResultWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                    paymentSlpListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    paymentSlpListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    paymentSlpListResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    paymentSlpListResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    paymentSlpListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    paymentSlpListResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    paymentSlpListResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                    paymentSlpListResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                    paymentSlpListResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    paymentSlpListResultWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
                    paymentSlpListResultWork.PaymentInpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONNMRF"));
                    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    paymentSlpListResultWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                    paymentSlpListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                    paymentSlpListResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    paymentSlpListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    paymentSlpListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    paymentSlpListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    paymentSlpListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    paymentSlpListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    paymentSlpListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    paymentSlpListResultWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
                    paymentSlpListResultWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
                    paymentSlpListResultWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                    paymentSlpListResultWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
                    paymentSlpListResultWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
                    paymentSlpListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    paymentSlpListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    paymentSlpListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    paymentSlpListResultWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
                    paymentSlpListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    paymentSlpListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    paymentSlpListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    paymentSlpListResultWork.PaymentMei = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTMEIRF"));
                    paymentSlpListResultWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                    #endregion

                    al.Add(paymentSlpListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // 2008/07/07 削除
                # region [DC.NS-SQL文＆各金種の集計]
                //sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文の作成
                //sqlCommand.CommandText += "SELECT ";
                //if (_paymentSlpCndtnWork.IsOptSection == false)
                //{
                //    sqlCommand.CommandText += "A.ADDUPSECCODERF, " +
                //                              "D.SECTIONGUIDENMRF AS ADDUPSECNAMERF, ";
                //}
                //else
                //{
                //    sqlCommand.CommandText += "'' ADDUPSECCODERF, " +
                //                              "'' ADDUPSECNAMERF, ";
                //}
                //sqlCommand.CommandText += "A.PAYMENTMONEYKINDCODERF, " +
                //                          "A.PAYMENTMONEYKINDNAMERF, " +
                //                          "SUM (A.PAYMENTTOTALRF) AS PAYMENTTOTALRF, " +
                //                          "SUM (A.PAYMENTRF) AS PAYMENTRF, " +
                //                          "SUM (A.FEEPAYMENTRF) AS FEEPAYMENTRF, " +
                //                          "SUM (A.DISCOUNTPAYMENTRF) AS DISCOUNTPAYMENTRF, " +
                //                          "SUM (A.REBATEPAYMENTRF) AS REBATEPAYMENTRF " +
                //                          "FROM PAYMENTSLPRF A " +
                //                          "LEFT JOIN SECINFOSETRF D ON D.ENTERPRISECODERF=A.ENTERPRISECODERF AND D.SECTIONCODERF=A.ADDUPSECCODERF ";

                //WHERE文(GROUP BY分も含む)の作成
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _paymentSlpCndtnWork, logicalMode);

                //myReader = sqlCommand.ExecuteReader();

                //while (myReader.Read())
                //{
                //    PaymentSlpListResultWork paymentSlpListResultWork = new PaymentSlpListResultWork();

                //    #region paymentSlpListResultWorkに値をセット
                //    paymentSlpListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                //    paymentSlpListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                //    paymentSlpListResultWork.PaymentMoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDCODERF"));
                //    paymentSlpListResultWork.PaymentMoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONEYKINDNAMERF"));
                //    paymentSlpListResultWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                //    paymentSlpListResultWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                //    paymentSlpListResultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                //    paymentSlpListResultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                //    paymentSlpListResultWork.RebatePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEPAYMENTRF"));
                //    #endregion

                //    al.Add(paymentSlpListResultWork);

                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                # endregion
                //--- UPD 2008/07/07 D.Tanaka ---<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentListWorkDB.SearchDepsitOnlyAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
         */
        #endregion
        // 2008/07/07 DEL-End ---------------------------------------------------- <<<<<

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_paymentSlpCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, PaymentSlpCndtnWork _paymentSlpCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            
            string retstring = "WHERE ";

            //企業コード
            retstring += "SLP.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.EnterpriseCode );

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SLP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SLP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //支払計上拠点コード
            if (_paymentSlpCndtnWork.IsOptSection == false)
            {
                if (_paymentSlpCndtnWork.PaymentAddupSecCodeList != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _paymentSlpCndtnWork.PaymentAddupSecCodeList)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND SLP.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                    }
                }
            }

            //計上日条件設定
            if (_paymentSlpCndtnWork.St_AddUpADate != DateTime.MinValue)
            {
                int startymd = TDateTime.DateTimeToLongDate(_paymentSlpCndtnWork.St_AddUpADate);
                retstring += " AND SLP.ADDUPADATERF >= " + startymd.ToString();
            }
            if (_paymentSlpCndtnWork.Ed_AddUpADate != DateTime.MinValue)
            {
                if (_paymentSlpCndtnWork.St_AddUpADate == DateTime.MinValue)
                {
                    retstring += " AND (SLP.ADDUPADATERF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }

                int endymd = TDateTime.DateTimeToLongDate(_paymentSlpCndtnWork.Ed_AddUpADate);
                retstring += " SLP.ADDUPADATERF <= " + endymd.ToString();

                if (_paymentSlpCndtnWork.St_AddUpADate == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
            }

            //入力日条件設定
            if (_paymentSlpCndtnWork.St_InputDate != DateTime.MinValue)
            {
                int startymd = TDateTime.DateTimeToLongDate(_paymentSlpCndtnWork.St_InputDate);
                //retstring += " AND SLP.PAYMENTDATERF >= " + startymd.ToString();
                retstring += " AND SLP.INPUTDAYRF >= " + startymd.ToString();  // ADD 2009/03/26
            }
            if (_paymentSlpCndtnWork.Ed_InputDate != DateTime.MinValue)
            {
                if (_paymentSlpCndtnWork.St_InputDate == DateTime.MinValue)
                {
                    //retstring += " AND (SLP.PAYMENTDATERF IS NULL OR";
                    retstring += " AND (SLP.INPUTDAYRF IS NULL OR";  // ADD 2009/03/26
                }
                else
                {
                    retstring += " AND";
                }

                int endymd = TDateTime.DateTimeToLongDate(_paymentSlpCndtnWork.Ed_InputDate);
                //retstring += " SLP.PAYMENTDATERF <= " + endymd.ToString();
                retstring += " SLP.INPUTDAYRF <= " + endymd.ToString();  // ADD 2009/03/26

                if (_paymentSlpCndtnWork.St_InputDate == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
            }

            //支払先コード設定
            if (_paymentSlpCndtnWork.St_PayeeCode != 0)
            {
                retstring += " AND SLP.SUPPLIERCDRF>=@STPAYEECODE";
                SqlParameter paraStPayeeCode = sqlCommand.Parameters.Add("@STPAYEECODE", SqlDbType.Int);
                paraStPayeeCode.Value = SqlDataMediator.SqlSetInt32(_paymentSlpCndtnWork.St_PayeeCode);
            }
            if (_paymentSlpCndtnWork.Ed_PayeeCode != 0)
            {
                retstring += " AND SLP.SUPPLIERCDRF<=@EDPAYEECODE";
                SqlParameter paraEdPayeeCode = sqlCommand.Parameters.Add("@EDPAYEECODE", SqlDbType.Int);
                paraEdPayeeCode.Value = SqlDataMediator.SqlSetInt32(_paymentSlpCndtnWork.Ed_PayeeCode);
            }

            //カナ設定
            if (_paymentSlpCndtnWork.St_PayeeKana != "")
            {
                retstring += " AND SPPL.SUPPLIERKANARF>=@STKANA";
                SqlParameter paraStPayeeKana = sqlCommand.Parameters.Add("@STKANA", SqlDbType.NVarChar);
                paraStPayeeKana.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.St_PayeeKana);
            }
            if (_paymentSlpCndtnWork.Ed_PayeeKana != "")
            {
                retstring += " AND (SPPL.SUPPLIERKANARF<=@EDKANA OR SPPL.SUPPLIERKANARF LIKE @EDKANA)";
                SqlParameter paraEdPayeeKana = sqlCommand.Parameters.Add("@EDKANA", SqlDbType.NVarChar);
                paraEdPayeeKana.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.Ed_PayeeKana + "% ");
            }

            //担当者区分によりチェックを行う担当者項目を変更します
            switch (_paymentSlpCndtnWork.EmployeeKindDiv)
            {
                case 0: //支払担当
                    {
                        if (_paymentSlpCndtnWork.St_EmployeeCode != "")
                        {
                            retstring += " AND SLP.PAYMENTAGENTCODERF>=@STEMPLOYEECODE";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STEMPLOYEECODE", SqlDbType.NVarChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.St_EmployeeCode);
                        }
                        if (_paymentSlpCndtnWork.Ed_EmployeeCode != "")
                        {
                            retstring += " AND SLP.PAYMENTAGENTCODERF<=@EDEMPLOYEECODE";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDEMPLOYEECODE", SqlDbType.NVarChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.Ed_EmployeeCode);
                        }
                        break;
                    }
                case 1: //入力担当
                    {
                        if (_paymentSlpCndtnWork.St_EmployeeCode != "")
                        {
                            retstring += " AND SLP.PAYMENTINPUTAGENTCDRF>=@STEMPLOYEECODE";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STEMPLOYEECODE", SqlDbType.NVarChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.St_EmployeeCode);
                        }
                        if (_paymentSlpCndtnWork.Ed_EmployeeCode != "")
                        {
                            retstring += " AND SLP.PAYMENTINPUTAGENTCDRF<=@EDEMPLOYEECODE";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDEMPLOYEECODE", SqlDbType.NVarChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentSlpCndtnWork.Ed_EmployeeCode);
                        }
                        break;
                    }
            }

            //支払伝票番号設定
            if (_paymentSlpCndtnWork.St_PaymentSlipNo != 0)
            {
                retstring += " AND SLP.PAYMENTSLIPNORF>=@STPAYMENTSLIPNO";
                SqlParameter paraStPaymentSlipNo = sqlCommand.Parameters.Add("@STPAYMENTSLIPNO", SqlDbType.Int);
                paraStPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(_paymentSlpCndtnWork.St_PaymentSlipNo);
            }
            if (_paymentSlpCndtnWork.Ed_PaymentSlipNo != 0)
            {
                retstring += " AND SLP.PAYMENTSLIPNORF<=@EDPAYMENTSLIPNO";
                SqlParameter paraEdPaymentSlipNo = sqlCommand.Parameters.Add("@EDPAYMENTSLIPNO", SqlDbType.Int);
                paraEdPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(_paymentSlpCndtnWork.Ed_PaymentSlipNo);
            }

            //支払金種設定
            if (_paymentSlpCndtnWork.PaymentKind != null)
            {
                ArrayList paymentKindArray = new ArrayList(_paymentSlpCndtnWork.PaymentKind);
                if ((paymentKindArray != null) && (paymentKindArray.Count > 0))
                {
                    string paymentKindint = "";
                    int kindint;
                    for (int i = 0; i < paymentKindArray.Count; i++)
                    {
                        kindint = Convert.ToInt32(paymentKindArray[i]);
                        if (kindint != -1)
                        {
                            if (paymentKindint != "")
                            {
                                paymentKindint += ",";
                            }
                            paymentKindint += "'" + kindint + "'";
                        }
                    }

                    if (paymentKindint != "")
                    {
                        //retstring += " AND SLP.PAYMENTMONEYKINDCODERF IN (" + paymentKindint + ") ";    2008/07/07 DEL
                        retstring += " AND DTL.MONEYKINDCODERF IN (" + paymentKindint + ") ";           //2008/07/07 ADD
                    }
                }
            }
            #endregion

            #region ソート順作成
            // 2008/07/07 DEL-Start ※UI側でソートする-------------------------------- >>>>>
            /*
            switch (_paymentSlpCndtnWork.PrintDiv)
            {
                case 1: //総合計
                    {
                        if (_paymentSlpCndtnWork.IsOptSection == false)
                        {
                            //retstring += " GROUP BY SLP.ADDUPSECCODERF, SECI2.SECTIONGUIDENMRF, SLP.PAYMENTMONEYKINDCODERF, SLP.PAYMENTMONEYKINDNAMERF ";   2008/07/07 DEL
                            retstring += " GROUP BY SLP.ADDUPSECCODERF, SECI2.SECTIONGUIDESNMRF, DTL.MONEYKINDCODERF, DTL.MONEYKINDNAMERF ";               // 2008/07/07 ADD
                        }
                        else
                        {
                            //retstring += " GROUP BY SLP.PAYMENTMONEYKINDCODERF, SLP.PAYMENTMONEYKINDNAMERF ";  2008/07/07 DEL
                            retstring += " GROUP BY DTL.MONEYKINDCODERF, DTL.MONEYKINDNAMERF ";                //2008/07/07 ADD
                        }
                        break;
                    }
                case 2: //簡易
                //case 3: //詳細    2008/07/07 DEL
                    {
                        retstring += " ORDER BY ";
                        if (_paymentSlpCndtnWork.IsOptSection == false)
                        {
                            retstring += "SLP.ADDUPSECCODERF, ";      // 計上拠点
                        }
                        retstring += "SLP.ADDUPADATERF, ";

                        switch (_paymentSlpCndtnWork.SortOrderDiv)
                        {
                            case 0: //支払先コード順
                                {
                                    retstring += "SLP.SUPPLIERCDRF ";
                                    break;
                                }
                            case 1: //支払先カナ順
                                {
                                    retstring += "SPPL.SUPPLIERKANARF ";
                                    break;
                                }
                            case 2: //支払担当コード順
                                {
                                    retstring += "SLP.PAYMENTAGENTCODERF ";
                                    break;
                                }
                        }
                        break;
                    }
                //case 4: //金種別集計  2008/07/07 DEL
                case 3: //金種別集計    2008/07/07 ADD
                    {
                        retstring += " GROUP BY ";

                        if (_paymentSlpCndtnWork.IsOptSection == false)
                        {
                            retstring += "SLP.ADDUPSECCODERF, SECI2.SECTIONGUIDESNMRF, ";   //2008/07/07 ADD
                            //retstring += "SLP.ADDUPSECCODERF, SECI2.SECTIONGUIDENMRF, ";    2008/07/07 DEL
                        }
                        retstring += "SLP.SUPPLIERCDRF, SLP.SUPPLIERSNMRF, DTL.MONEYKINDCODERF, DTL.MONEYKINDNAMERF ";  //2008/07/07 ADD
                        //retstring += "SLP.ADDUPADATERF, SLP.PAYMENTMONEYKINDDIVRF ";                                    2008/07/07 DEL
                        break;
                    }
            }
             */
            // 2008/07/07 DEL-End ---------------------------------------------------- <<<<<
            #endregion
            return retstring;
        }
    }
}
