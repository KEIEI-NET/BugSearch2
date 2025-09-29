//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/09  修正内容 : マスタ送受信不備対応について 
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/07/26  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/08/20  修正内容 : myReaderからDクラスへ項目転記を行っている個所はメソッド化する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/08  修正内容 : #23777 ソースレビュー
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先マスタ（掛率グループ）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（掛率グループ）データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCCustRateGroupDB : RemoteDB
    {
        /// <summary>
        /// 得意先マスタ（掛率グループ）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCCustRateGroupDB()
            : base("PMKYO06451D", "Broadleaf.Application.Remoting.ParamData.DCCustRateGroupWork", "CUSTRATEGROUPRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 得意先マスタ（掛率グループ）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="custRateGroupArrList">得意先マスタ（掛率グループ）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（掛率グループ）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchCustRateGroup(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList custRateGroupArrList, out string retMessage)
        {
            return SearchCustRateGroupProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                    sqlTransaction, out custRateGroupArrList, out retMessage);
        }
        /// <summary>
        /// 得意先マスタ（掛率グループ）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="custRateGroupArrList">得意先マスタ（掛率グループ）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（掛率グループ）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchCustRateGroupProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList custRateGroupArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custRateGroupArrList = new ArrayList();
            DCCustRateGroupWork custRateGroupWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, PURECODERF, GOODSMAKERCDRF, CUSTRATEGRPCODERF FROM CUSTRATEGROUPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //得意先マスタ（掛率グループ）データ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    custRateGroupWork = new DCCustRateGroupWork();

                    custRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    custRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    custRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    custRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    custRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    custRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    custRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    custRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    custRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    custRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                    custRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    custRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));

                    custRateGroupArrList.Add(custRateGroupWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCCustRateGroupDB.SearchCustRateGroup Exception=" + ex.Message);
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
        #endregion

        # region [Delete]
        /// <summary>
        ///  得意先マスタ（掛率グループ）データ削除
        /// </summary>
        /// <param name="dcCustRateGroupWork">得意先マスタ（掛率グループ）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（掛率グループ）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCCustRateGroupWork dcCustRateGroupWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  得意先マスタ（掛率グループ）データ削除
        /// </summary>
        /// <param name="dcCustRateGroupWork">得意先マスタ（掛率グループ）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（掛率グループ）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCCustRateGroupWork dcCustRateGroupWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM CUSTRATEGROUPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
            //Prameterオブジェクトの作成
            // 企業コード
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            // 得意先コード
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcCustRateGroupWork.EnterpriseCode;
            findParaCustomerCode.Value = dcCustRateGroupWork.CustomerCode;

            // 得意先マスタ（掛率グループ）データを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 得意先マスタ（掛率グループ）登録
        /// </summary>
        /// <param name="dcCustRateGroupWork">得意先マスタ（掛率グループ）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（掛率グループ）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCCustRateGroupWork dcCustRateGroupWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 得意先マスタ（掛率グループ）登録
        /// </summary>
        /// <param name="dcCustRateGroupWork">得意先マスタ（掛率グループ）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（掛率グループ）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCCustRateGroupWork dcCustRateGroupWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO CUSTRATEGROUPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, PURECODERF, GOODSMAKERCDRF, CUSTRATEGRPCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @PURECODE, @GOODSMAKERCD, @CUSTRATEGRPCODE)";

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
            SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustRateGroupWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustRateGroupWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcCustRateGroupWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcCustRateGroupWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcCustRateGroupWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcCustRateGroupWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcCustRateGroupWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.LogicalDeleteCode);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.CustomerCode);
            paraPureCode.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.PureCode);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.GoodsMakerCd);
            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcCustRateGroupWork.CustRateGrpCode);

            // 得意先マスタ（掛率グループ）データを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 ソースレビュー
        ///// <summary>
        ///// 得意先マスタ（掛率グループ）の検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="paramList">検索条件</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="custRateGroupArrList">得意先マスタ（掛率グループ）データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先マスタ（掛率グループ）データREADLISTを全て戻します</br>
        ///// <br>Programmer : 孫東響</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int SearchCustRateGroup(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //   SqlTransaction sqlTransaction, out ArrayList custRateGroupArrList, out string retMessage)
        //{
        //    return SearchCustRateGroupProc(enterpriseCodes, paramList, sqlConnection,
        //                            sqlTransaction, out custRateGroupArrList, out retMessage);
        //}
        ///// <summary>
        ///// 得意先マスタ（掛率グループ）の検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="paramList">検索条件</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="custRateGroupArrList">得意先マスタ（掛率グループ）データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先マスタ（掛率グループ）データREADLISTを全て戻します</br>
        ///// <br>Programmer : 孫東響</br>
        ///// <br>Date       : 2011.07.26</br>
        //private int SearchCustRateGroupProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList custRateGroupArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    custRateGroupArrList = new ArrayList();
        //    //DCCustRateGroupWork custRateGroupWork = null;//DEL 2011/08/20 途中納品チェック
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    CustomerProcParamWork param = paramList as CustomerProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, PURECODERF, GOODSMAKERCDRF, CUSTRATEGRPCODERF FROM CUSTRATEGROUPRF ";
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

        //        //得意先マスタ（掛率グループ）データ用SQL
        //        sqlCommand.CommandText = sqlStr;

        //        // 読み込み
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        //            //custRateGroupWork = new DCCustRateGroupWork();

        //            //custRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //            //custRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            //custRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //            //custRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //            //custRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //            //custRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //            //custRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //            //custRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //            //custRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //            //custRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
        //            //custRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //            //custRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));

        //            //custRateGroupArrList.Add(custRateGroupWork);
        //            //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        //            #endregion DEL
        //            custRateGroupArrList.Add(CopyFromMyReaderToDCCustRateGroupWork(myReader));//ADD 2011/08/20 途中納品チェック
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "DCCustRateGroupDB.SearchCustRateGroup Exception=" + ex.Message);
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
        ///// 得意先マスタ（掛率グループ）データを取得
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>得意先マスタ（掛率グループ）データ</returns>
        ///// <br>Note       : 得意先マスタ（掛率グループ）データを戻します</br>
        ///// <br>Programmer : 馮文雄</br>
        ///// <br>Date       : 2011/08/20</br>
        //private DCCustRateGroupWork CopyFromMyReaderToDCCustRateGroupWork(SqlDataReader myReader)
        //{
        //    DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();

        //    custRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    custRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    custRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    custRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    custRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //    custRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //    custRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //    custRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    custRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    custRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
        //    custRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //    custRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));

        //    return custRateGroupWork;
        //}
        ////-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        #endregion
        #endregion
        #endregion 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）

        // ADD 2011.08.26 ---------->>>>>
		# region [Clear]
		// Rクラスの MethodでSQL文字が駄目
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			ClearProc(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
		}
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
		private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
			sqlCommand.CommandText = "DELETE FROM CUSTRATEGROUPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			//Parameterオブジェクトへ値設定
			findParaEnterpriseCode.Value = enterpriseCode;

			// 拠点情報設定マスタデータを削除する
			sqlCommand.ExecuteNonQuery();
		}
		#endregion
		// ADD 2011.08.26 ----------<<<<<
    }
}