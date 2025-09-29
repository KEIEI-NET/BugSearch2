//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/05/25  修正内容 : INT⇒DATETIME変更バグ
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/06/25  修正内容 : 送信側で更新したマスタが「更新のみ」では受信されない場合がある 
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/07/26  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/08/20  修正内容 : myReaderからDクラスへ項目転記を行っている個所はメソッド化する
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/08  修正内容 : #23777 ソースレビュー
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先マスタ(伝票番号)READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ(伝票番号)処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APCustSlipNoSetDB : RemoteDB
    {
        /// <summary>
        /// 得意先マスタ(伝票番号)READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APCustSlipNoSetDB()
            : base("PMKYO06141D", "Broadleaf.Application.Remoting.ParamData.APCustSlipNoSetWork", "CUSTSLIPNOSETRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 得意先マスタ(伝票番号)の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="custSlipNoSetArrList">得意先マスタ(伝票番号)データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票番号)データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchCustSlipNoSet(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList custSlipNoSetArrList, out string retMessage)
        {
            return SearchCustSlipNoSetProc(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
        }
        /// <summary>
        /// 得意先マスタ(伝票番号)の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="custSlipNoSetArrList">得意先マスタ(伝票番号)データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票番号)データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// 
        private int SearchCustSlipNoSetProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList custSlipNoSetArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custSlipNoSetArrList = new ArrayList();
            APCustSlipNoSetWork custSlipNoSetWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPYEARMONTHRF, PRESENTCUSTSLIPNORF, STARTCUSTSLIPNORF, ENDCUSTSLIPNORF FROM CUSTSLIPNOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //得意先マスタ(伝票番号)データ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    custSlipNoSetWork = new APCustSlipNoSetWork();

                    custSlipNoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    custSlipNoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    custSlipNoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    custSlipNoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    custSlipNoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    custSlipNoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    custSlipNoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    custSlipNoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    custSlipNoSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    custSlipNoSetWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                    custSlipNoSetWork.PresentCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRESENTCUSTSLIPNORF"));
                    custSlipNoSetWork.StartCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STARTCUSTSLIPNORF"));
                    custSlipNoSetWork.EndCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ENDCUSTSLIPNORF"));

                    custSlipNoSetArrList.Add(custSlipNoSetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APCustSlipNoSetDB.SearchCustSlipNoSet Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        /// <summary>
        /// 得意先マスタ(伝票番号)の計数検索処理
        /// </summary>
        /// <param name="custSlipNoSetWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票番号)データ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchCustSlipNoSetCount(APCustSlipNoSetWork custSlipNoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchCustSlipNoSetCountProc(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 得意先マスタ(伝票番号)の計数検索処理
        /// </summary>
        /// <param name="custSlipNoSetWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(伝票番号)データ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchCustSlipNoSetCountProc(APCustSlipNoSetWork custSlipNoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM CUSTSLIPNOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                // MOD 2009/06/25 --->>>
                if (custSlipNoSetWork.AddUpYearMonth == DateTime.MinValue)
                {
                    findParaAddUpYearMonth.Value = 0;
                }
                else
                {
                    findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custSlipNoSetWork.AddUpYearMonth);
                }
                // MOD 2009/06/25 --->>>

                // 拠点情報設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APSecInfoSetDB.SearchSecInfoSet Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }


        #endregion

        # region [Delete]
        /// <summary>
        ///  得意先マスタ（伝票番号）データ削除
        /// </summary>
        /// <param name="apCustSlipNoSetWork">得意先マスタ（伝票番号）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ(伝票番号)データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APCustSlipNoSetWork apCustSlipNoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apCustSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  得意先マスタ（伝票番号）データ削除
        /// </summary>
        /// <param name="apCustSlipNoSetWork">得意先マスタ（伝票番号）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ(伝票番号)データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(APCustSlipNoSetWork apCustSlipNoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM CUSTSLIPNOSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = apCustSlipNoSetWork.EnterpriseCode;
            findParaCustomerCode.Value = apCustSlipNoSetWork.CustomerCode;
            if (apCustSlipNoSetWork.AddUpYearMonth == DateTime.MinValue)
            {
                findParaAddUpYearMonth.Value = 0;
            }
            else
            {
                findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(apCustSlipNoSetWork.AddUpYearMonth);
            }


            // 得意先マスタ（伝票番号）データを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 得意先マスタ（伝票番号）登録
        /// </summary>
        /// <param name="apCustSlipNoSetWork">得意先マスタ（伝票番号）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ(伝票番号)データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APCustSlipNoSetWork apCustSlipNoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apCustSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 得意先マスタ（伝票番号）登録
        /// </summary>
        /// <param name="apCustSlipNoSetWork">得意先マスタ（伝票番号）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ(伝票番号)データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(APCustSlipNoSetWork apCustSlipNoSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO CUSTSLIPNOSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPYEARMONTHRF, PRESENTCUSTSLIPNORF, STARTCUSTSLIPNORF, ENDCUSTSLIPNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @ADDUPYEARMONTH, @PRESENTCUSTSLIPNO, @STARTCUSTSLIPNO, @ENDCUSTSLIPNO)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
            SqlParameter paraPresentCustSlipNo = sqlCommand.Parameters.Add("@PRESENTCUSTSLIPNO", SqlDbType.BigInt);
            SqlParameter paraStartCustSlipNo = sqlCommand.Parameters.Add("@STARTCUSTSLIPNO", SqlDbType.BigInt);
            SqlParameter paraEndCustSlipNo = sqlCommand.Parameters.Add("@ENDCUSTSLIPNO", SqlDbType.BigInt);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apCustSlipNoSetWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apCustSlipNoSetWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apCustSlipNoSetWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apCustSlipNoSetWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apCustSlipNoSetWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apCustSlipNoSetWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apCustSlipNoSetWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apCustSlipNoSetWork.LogicalDeleteCode);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(apCustSlipNoSetWork.CustomerCode);
            // MOD 2009/05/25 --->>>
            if (apCustSlipNoSetWork.AddUpYearMonth == DateTime.MinValue)
            {
                paraAddUpYearMonth.Value = 0;
            }
            else
            {
                paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(apCustSlipNoSetWork.AddUpYearMonth);
            }
            // MOD 2009/05/25 ---<<<
            paraPresentCustSlipNo.Value = SqlDataMediator.SqlSetInt64(apCustSlipNoSetWork.PresentCustSlipNo);
            paraStartCustSlipNo.Value = SqlDataMediator.SqlSetInt64(apCustSlipNoSetWork.StartCustSlipNo);
            paraEndCustSlipNo.Value = SqlDataMediator.SqlSetInt64(apCustSlipNoSetWork.EndCustSlipNo);


            // 得意先マスタ（伝票番号）データを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 ソースレビュー
        ///// <summary>
        ///// 得意先マスタ(伝票番号)の検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="paramList">検索条件</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="custSlipNoSetArrList">得意先マスタ(伝票番号)データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先マスタ(伝票番号)データREADLISTを全て戻します</br>
        ///// <br>Programmer : 孫東響</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int SearchCustSlipNoSet(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList custSlipNoSetArrList, out string retMessage)
        //{
        //    return SearchCustSlipNoSetProc(enterpriseCodes, paramList, sqlConnection,
        //                           sqlTransaction, out custSlipNoSetArrList, out retMessage);
        //}
        ///// <summary>
        ///// 得意先マスタ(伝票番号)の検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="paramList">検索条件</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="custSlipNoSetArrList">得意先マスタ(伝票番号)データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先マスタ(伝票番号)データREADLISTを全て戻します</br>
        ///// <br>Programmer : 孫東響</br>
        ///// <br>Date       : 2011.07.26</br>
        //private int SearchCustSlipNoSetProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList custSlipNoSetArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    custSlipNoSetArrList = new ArrayList();
        //    //APCustSlipNoSetWork custSlipNoSetWork = null;//DEL 2011/08/20 途中納品チェック
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    APCustomerProcParamWork param = paramList as APCustomerProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPYEARMONTHRF, PRESENTCUSTSLIPNORF, STARTCUSTSLIPNORF, ENDCUSTSLIPNORF FROM CUSTSLIPNOSETRF ";
        //        sqlStr += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

        //        if (param.UpdateDateTimeBegin != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
        //            SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
        //        }
        //        if (param.UpdateDateTimeEnd != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
        //            SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
        //        }
        //        if (param.CustomerCodeBeginRF != 0)
        //        {
        //            sqlStr += " AND CUSTOMERCODERF >= @CUSTOMERCODEBEGINRF";
        //            SqlParameter customerCodeBeginRF = sqlCommand.Parameters.Add("@CUSTOMERCODEBEGINRF", SqlDbType.Int);
        //            customerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeBeginRF);
        //        }
        //        if (param.CustomerCodeEndRF != 0)
        //        {
        //            sqlStr += " AND CUSTOMERCODERF <= @CUSTOMERCODEENDRF";
        //            SqlParameter customerCodeEndRF = sqlCommand.Parameters.Add("@CUSTOMERCODEENDRF", SqlDbType.Int);
        //            customerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeEndRF);
        //        }

        //        //Prameterオブジェクトの作成
        //        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

        //        //Parameterオブジェクトへ値設定
        //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);


        //        //得意先マスタ(伝票番号)データ用SQL
        //        sqlCommand.CommandText = sqlStr;

        //        // 読み込み
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        //            //custSlipNoSetWork = new APCustSlipNoSetWork();

        //            //custSlipNoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //            //custSlipNoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            //custSlipNoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //            //custSlipNoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //            //custSlipNoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //            //custSlipNoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //            //custSlipNoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //            //custSlipNoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //            //custSlipNoSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //            //custSlipNoSetWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
        //            //custSlipNoSetWork.PresentCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRESENTCUSTSLIPNORF"));
        //            //custSlipNoSetWork.StartCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STARTCUSTSLIPNORF"));
        //            //custSlipNoSetWork.EndCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ENDCUSTSLIPNORF"));

        //            //custSlipNoSetArrList.Add(custSlipNoSetWork);
        //            //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        //            #endregion DEL
        //            custSlipNoSetArrList.Add(CopyFromMyReaderToAPCustSlipNoSetWork(myReader));//ADD 2011/08/20 途中納品チェック
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "APCustSlipNoSetDB.SearchCustSlipNoSet Exception=" + ex.Message);
        //        retMessage = ex.Message;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();

        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }
        //    return status;
        //}

        ////-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        ///// <summary>
        ///// 得意先マスタ(伝票番号)データを取得
        ///// </summary>
        ///// <param name="myReader"></param>
        ///// <returns></returns>
        ///// <br>Note       : 得意先マスタ(伝票番号)データを戻します</br>
        ///// <br>Programmer : 馮文雄</br>
        ///// <br>Date       : 2011/08/20</br>
        //private APCustSlipNoSetWork CopyFromMyReaderToAPCustSlipNoSetWork(SqlDataReader myReader)
        //{
        //    APCustSlipNoSetWork custSlipNoSetWork = new APCustSlipNoSetWork();

        //    custSlipNoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    custSlipNoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    custSlipNoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    custSlipNoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    custSlipNoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //    custSlipNoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //    custSlipNoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //    custSlipNoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    custSlipNoSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    custSlipNoSetWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
        //    custSlipNoSetWork.PresentCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRESENTCUSTSLIPNORF"));
        //    custSlipNoSetWork.StartCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STARTCUSTSLIPNORF"));
        //    custSlipNoSetWork.EndCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ENDCUSTSLIPNORF"));

        //    return custSlipNoSetWork;
        //}
        ////-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        #endregion
        #endregion
        #endregion 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
    }
}

