//**********************************************************************//
// System           :   PM.NS　                                         //
// Sub System       :                                                   //
// Program name     :   マスタ送受信処理                           　　 //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06450R.DLL							        //
// Programmer       :   呉元嘯	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2009.06.12　							//
//                  :   public MethodでSQL文字が駄目対応について        //
//----------------------------------------------------------------------//
// Update Note      :   孫東響　2011.07.26　							//
//                  :   SCM対応-拠点管理（10704767-00）                 //
//----------------------------------------------------------------------//
// Update Note      :   馮文雄　2011.08.20　							//
//                  :   myReaderからDクラスへ項目転記を行っている個所   //
//                  :   はメソッド化する                                //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2011.08.26　							//
//                  :   DC履歴ログとDC各データのクリア処理を追加        //
//----------------------------------------------------------------------//
// Update Note      :   孫東響　2011.09.08　							//
//                  :   #23777 ソースレビュー                           //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
    /// 得意先マスタ（伝票管理）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（伝票管理）データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCCustSlipMngDB : RemoteDB
    {
        /// <summary>
        /// 得意先マスタ（伝票管理）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCCustSlipMngDB()
            : base("PMKYO06451D", "Broadleaf.Application.Remoting.ParamData.DCCustSlipMngWork", "CUSTSLIPMNGRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 得意先マスタ（伝票管理）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="custSlipMngArrList">得意先マスタ（伝票管理）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（伝票管理）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchCustSlipMng(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList custSlipMngArrList, out string retMessage)
        {
            return SearchCustSlipMngProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                          sqlTransaction, out custSlipMngArrList, out retMessage);
        }
        /// <summary>
        /// 得意先マスタ（伝票管理）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="custSlipMngArrList">得意先マスタ（伝票管理）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先マスタ（伝票管理）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchCustSlipMngProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList custSlipMngArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custSlipMngArrList = new ArrayList();
            DCCustSlipMngWork custSlipMngWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SECTIONCODERF, CUSTOMERCODERF, SLIPPRTSETPAPERIDRF FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //得意先マスタ（伝票管理）データ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    custSlipMngWork = new DCCustSlipMngWork();

                    custSlipMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    custSlipMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    custSlipMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    custSlipMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    custSlipMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    custSlipMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    custSlipMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    custSlipMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    custSlipMngWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                    custSlipMngWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
                    custSlipMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    custSlipMngWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    custSlipMngWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));

                    custSlipMngArrList.Add(custSlipMngWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCCustSlipMngDB.SearchCustSlipMng Exception=" + ex.Message);
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
        ///  得意先マスタ（伝票管理）データ削除
        /// </summary>
        /// <param name="dcCustSlipMngWork">得意先マスタ（伝票管理）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（伝票管理）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCCustSlipMngWork dcCustSlipMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcCustSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  得意先マスタ（伝票管理）データ削除
        /// </summary>
        /// <param name="dcCustSlipMngWork">得意先マスタ（伝票管理）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（伝票管理）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCCustSlipMngWork dcCustSlipMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SECTIONCODERF=@FINDSECTIONCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
            SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcCustSlipMngWork.EnterpriseCode;
            findParaDataInputSystem.Value = dcCustSlipMngWork.DataInputSystem;
            findParaSlipPrtKind.Value = dcCustSlipMngWork.SlipPrtKind;
            findParaSectionCode.Value = dcCustSlipMngWork.SectionCode;
            findParaCustomerCode.Value = dcCustSlipMngWork.CustomerCode;

            // 得意先マスタ（伝票管理）データを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 得意先マスタ（伝票管理）登録
        /// </summary>
        /// <param name="dcCustSlipMngWork">得意先マスタ（伝票管理）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（伝票管理）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCCustSlipMngWork dcCustSlipMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcCustSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 得意先マスタ（伝票管理）登録
        /// </summary>
        /// <param name="dcCustSlipMngWork">得意先マスタ（伝票管理）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 得意先マスタ（伝票管理）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCCustSlipMngWork dcCustSlipMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO CUSTSLIPMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SECTIONCODERF, CUSTOMERCODERF, SLIPPRTSETPAPERIDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @SECTIONCODE, @CUSTOMERCODE, @SLIPPRTSETPAPERID)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
            SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustSlipMngWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcCustSlipMngWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcCustSlipMngWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcCustSlipMngWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcCustSlipMngWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcCustSlipMngWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcCustSlipMngWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcCustSlipMngWork.LogicalDeleteCode);
            paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dcCustSlipMngWork.DataInputSystem);
            paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dcCustSlipMngWork.SlipPrtKind);
            if (string.IsNullOrEmpty(dcCustSlipMngWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = dcCustSlipMngWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcCustSlipMngWork.SectionCode);
            }
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcCustSlipMngWork.CustomerCode);
            if (string.IsNullOrEmpty(dcCustSlipMngWork.SlipPrtSetPaperId.Trim()))
            {
                paraSlipPrtSetPaperId.Value = dcCustSlipMngWork.SlipPrtSetPaperId;
            }
            else
            {
                paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dcCustSlipMngWork.SlipPrtSetPaperId);
            }

            // 得意先マスタ（伝票管理）データを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 ソースレビュー
        ///// <summary>
        ///// 得意先マスタ（伝票管理）の検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="paramList">検索条件</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="custSlipMngArrList">得意先マスタ（伝票管理）データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先マスタ（伝票管理）データREADLISTを全て戻します</br>
        ///// <br>Programmer : 孫東響</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int SearchCustSlipMng(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList custSlipMngArrList, out string retMessage)
        //{
        //    return SearchCustSlipMngProc(enterpriseCodes, paramList, sqlConnection,
        //                  sqlTransaction, out custSlipMngArrList, out retMessage);
        //}
        ///// <summary>
        ///// 得意先マスタ（伝票管理）の検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="paramList">検索条件</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="custSlipMngArrList">得意先マスタ（伝票管理）データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先マスタ（伝票管理）データREADLISTを全て戻します</br>
        ///// <br>Programmer : 孫東響</br>
        ///// <br>Date       : 2011.07.26</br>
        //private int SearchCustSlipMngProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList custSlipMngArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    custSlipMngArrList = new ArrayList();
        //    //DCCustSlipMngWork custSlipMngWork = null;//DEL 2011/08/20 途中納品チェック
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    CustomerProcParamWork param = paramList as CustomerProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SECTIONCODERF, CUSTOMERCODERF, SLIPPRTSETPAPERIDRF FROM CUSTSLIPMNGRF ";
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

        //        //得意先マスタ（伝票管理）データ用SQL
        //        sqlCommand.CommandText = sqlStr;

        //        // 読み込み
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        //            //custSlipMngWork = new DCCustSlipMngWork();

        //            //custSlipMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //            //custSlipMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            //custSlipMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //            //custSlipMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //            //custSlipMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //            //custSlipMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //            //custSlipMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //            //custSlipMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //            //custSlipMngWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
        //            //custSlipMngWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
        //            //custSlipMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
        //            //custSlipMngWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //            //custSlipMngWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));

        //            //custSlipMngArrList.Add(custSlipMngWork);
        //            //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        //            #endregion DEL
        //            custSlipMngArrList.Add(CopyFromMyReaderToDCCustSlipMngWork(myReader));//ADD 2011/08/20 途中納品チェック
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "DCCustSlipMngDB.SearchCustSlipMng Exception=" + ex.Message);
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
        ///// 得意先マスタ（伝票管理）データを取得
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>得意先マスタ（伝票管理）データ</returns>
        ///// <br>Note       : 得意先マスタ（伝票管理）データを戻します</br>
        ///// <br>Programmer : 馮文雄</br>
        ///// <br>Date       : 2011/08/20</br>
        //private DCCustSlipMngWork CopyFromMyReaderToDCCustSlipMngWork(SqlDataReader myReader)
        //{
        //    DCCustSlipMngWork custSlipMngWork = new DCCustSlipMngWork();

        //    custSlipMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    custSlipMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    custSlipMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    custSlipMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    custSlipMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //    custSlipMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //    custSlipMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //    custSlipMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    custSlipMngWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
        //    custSlipMngWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
        //    custSlipMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
        //    custSlipMngWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    custSlipMngWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));

        //    return custSlipMngWork;
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
			sqlCommand.CommandText = "DELETE FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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