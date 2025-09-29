//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11770021-00 作成担当 : 陳艶丹
// 作 成 日  2021/04/12  修正内容 : 新規作成
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
    /// 得意先マスタ(メモ情報)READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ(メモ情報)処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2021/04/12</br>
    /// </remarks>
    public class APCustomerMemoDB : RemoteDB
    {
        /// <summary>
        /// 得意先マスタ(メモ情報)READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        /// </remarks>
        public APCustomerMemoDB()
            : base("PMKYO06141D", "Broadleaf.Application.Remoting.ParamData.APCustomerMEMOWork", "CUSTOMERMEMORF")
        {

        }

        #region [Read]
        /// <summary>
        /// 得意先マスタ(メモ情報)の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="customerMemoArrList">得意先マスタ(メモ情報)データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(メモ情報)データREADLISTを全て戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        public int SearchCustomerMemo(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList customerMemoArrList, out string retMessage)
        {
            return SearchCustomerMemoProc(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerMemoArrList, out retMessage);
        }
        /// <summary>
        /// 得意先マスタ(メモ情報)の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="customerMemoArrList">得意先マスタ(メモ情報)データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(メモ情報)データREADLISTを全て戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        private int SearchCustomerMemoProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList customerMemoArrList, out string retMessage)
        {
            //初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            customerMemoArrList = new ArrayList();
            APCustomerMemoWork customerMemoWork = null;
            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;

            try
            {
                //SQL作成
                sqlStr.Append("SELECT ");
                sqlStr.Append(" CREATEDATETIMERF, ");
                sqlStr.Append(" UPDATEDATETIMERF, ");
                sqlStr.Append(" ENTERPRISECODERF, ");
                sqlStr.Append(" FILEHEADERGUIDRF, ");
                sqlStr.Append(" UPDEMPLOYEECODERF, ");
                sqlStr.Append(" UPDASSEMBLYID1RF, ");
                sqlStr.Append(" UPDASSEMBLYID2RF, ");
                sqlStr.Append(" LOGICALDELETECODERF, ");
                sqlStr.Append(" CUSTOMERCODERF, ");
                sqlStr.Append(" NOTEINFORF, ");
                sqlStr.Append(" ISNULL(DISPLAYDIVCODERF, 0) AS DISPLAYDIVCODERF ");
                sqlStr.Append("FROM ");
                sqlStr.Append(" CUSTOMERMEMORF ");
                sqlStr.Append("WHERE ");
                sqlStr.Append(" ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sqlStr.Append(" UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND  ");
                sqlStr.Append(" UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF ");

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                    // 読み込み
                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        customerMemoWork = new APCustomerMemoWork();

                        customerMemoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        customerMemoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        customerMemoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        customerMemoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        customerMemoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        customerMemoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        customerMemoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        customerMemoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        customerMemoWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        customerMemoWork.NoteInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTEINFORF"));
                        customerMemoWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYDIVCODERF"));

                        customerMemoArrList.Add(customerMemoWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APCustomerMemoDB.SearchCustomerMemoProc Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "APCustomerMemoDB.SearchCustomerMemoProc Exception=" + e.Message);
                retMessage = e.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// 得意先マスタ(メモ情報)の計数検索処理
        /// </summary>
        /// <param name="customerMemoWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(メモ情報)データ計数を全て戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        public int SearchCustomerMemoCount(APCustomerMemoWork customerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchCustomerMemoCountProc(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 得意先マスタ(メモ情報)の計数検索処理
        /// </summary>
        /// <param name="customerMemoWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ(メモ情報)データ計数を全て戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        private int SearchCustomerMemoCountProc(APCustomerMemoWork customerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            //初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;

            try
            {
                //SQL作成
                sqlStr.Append("SELECT ");
                sqlStr.Append(" CREATEDATETIMERF ");
                sqlStr.Append("FROM ");
                sqlStr.Append(" CUSTOMERMEMORF ");
                sqlStr.Append("WHERE ");
                sqlStr.Append(" ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sqlStr.Append(" CUSTOMERCODERF=@FINDCUSTOMERCODE  ");

                //Selectコマンドの生成
                using (sqlCommand = new SqlCommand(sqlStr.ToString(), sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerMemoWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerMemoWork.CustomerCode);

                    // 読み込み
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APCustomerMemoDB.SearchCustomerMemoCount Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "APCustomerMemoDB.SearchCustomerMemoCount Exception=" + e.Message);
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
        ///  得意先マスタ（メモ情報）データ削除
        /// </summary>
        /// <param name="apCustomerMemoWork">得意先マスタ（メモ情報）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（メモ情報）データを削除する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        public void Delete(APCustomerMemoWork apCustomerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apCustomerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  得意先マスタ（メモ情報）データ削除
        /// </summary>
        /// <param name="apCustomerMemoWork">得意先マスタ（メモ情報）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（メモ情報）データを削除する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        private void DeleteProc(APCustomerMemoWork apCustomerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            //初期化
            StringBuilder sqlStr = new StringBuilder();

            try
            {
                //SQL作成
                sqlStr.Append("DELETE ");
                sqlStr.Append("FROM ");
                sqlStr.Append(" CUSTOMERMEMORF ");
                sqlStr.Append("WHERE ");
                sqlStr.Append(" ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sqlStr.Append(" CUSTOMERCODERF=@FINDCUSTOMERCODE  ");

                //deleteコマンドの生成
                using (sqlCommand = new SqlCommand(sqlStr.ToString(), sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = apCustomerMemoWork.EnterpriseCode;
                    findParaCustomerCode.Value = apCustomerMemoWork.CustomerCode;

                    // 得意先マスタ（メモ情報）データを削除する
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APCustomerMemoDB.Delete Exception=" + ex.Message);
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "APCustomerMemoDB.Delete Exception=" + e.Message);
            }
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 得意先マスタ（メモ情報）登録
        /// </summary>
        /// <param name="apCustomerMemoWork">得意先マスタ（メモ情報）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（メモ情報）データを登録する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        public void Insert(APCustomerMemoWork apCustomerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apCustomerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 得意先マスタ（メモ情報）登録
        /// </summary>
        /// <param name="apCustomerMemoWork">得意先マスタ（メモ情報）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（メモ情報）データを登録する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/04/12</br>
        private void InsertProc(APCustomerMemoWork apCustomerMemoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            //初期化
            StringBuilder sqlStr = new StringBuilder();

            try
            {
                //SQL作成
                sqlStr.Append("INSERT INTO  ");
                sqlStr.Append(" CUSTOMERMEMORF ");
                sqlStr.Append("(CREATEDATETIMERF, ");
                sqlStr.Append(" UPDATEDATETIMERF, ");
                sqlStr.Append(" ENTERPRISECODERF, ");
                sqlStr.Append(" FILEHEADERGUIDRF, ");
                sqlStr.Append(" UPDEMPLOYEECODERF, ");
                sqlStr.Append(" UPDASSEMBLYID1RF, ");
                sqlStr.Append(" UPDASSEMBLYID2RF, ");
                sqlStr.Append(" LOGICALDELETECODERF, ");
                sqlStr.Append(" CUSTOMERCODERF, ");
                sqlStr.Append(" NOTEINFORF, ");
                sqlStr.Append(" DISPLAYDIVCODERF) ");
                sqlStr.Append("VALUES ");
                sqlStr.Append("(@CREATEDATETIME, ");
                sqlStr.Append(" @UPDATEDATETIME, ");
                sqlStr.Append(" @ENTERPRISECODE, ");
                sqlStr.Append(" @FILEHEADERGUID, ");
                sqlStr.Append(" @UPDEMPLOYEECODE, ");
                sqlStr.Append(" @UPDASSEMBLYID1, ");
                sqlStr.Append(" @UPDASSEMBLYID2, ");
                sqlStr.Append(" @LOGICALDELETECODE, ");
                sqlStr.Append(" @CUSTOMERCODE, ");
                sqlStr.Append(" @NOTEINFORF, ");
                sqlStr.Append(" @DISPLAYDIVCODERF) ");

                //コマンドの生成
                using (sqlCommand = new SqlCommand(sqlStr.ToString(), sqlConnection, sqlTransaction))
                {
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
                    SqlParameter paraNoteInfo = sqlCommand.Parameters.Add("@NOTEINFORF", SqlDbType.NVarChar);
                    SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODERF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apCustomerMemoWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apCustomerMemoWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apCustomerMemoWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apCustomerMemoWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apCustomerMemoWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apCustomerMemoWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apCustomerMemoWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apCustomerMemoWork.LogicalDeleteCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(apCustomerMemoWork.CustomerCode);
                    paraNoteInfo.Value = SqlDataMediator.SqlSetString(apCustomerMemoWork.NoteInfo);
                    paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt64(apCustomerMemoWork.DisplayDivCode);

                    // 得意先マスタ（メモ情報）データを登録する
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APCustomerMemoDB.InsertProc Exception=" + ex.Message);
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "APCustomerMemoDB.InsertProc Exception=" + e.Message);
            }
        }
        #endregion
    }
}

