//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注マスタリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払明細マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCAcceptOdrDB : RemoteDB
    {
        /// <summary>
        /// 受注マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCAcceptOdrDB()
            : base("PMKYO07531D", "Broadleaf.Application.Remoting.ParamData.DCAcceptOdrWork", "ACCEPTODRRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタデータ取得
        /// </summary>
        /// <param name="acceptOdrList">受注マスタデータ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList acceptOdrList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  acceptOdrList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタデータ取得
        /// </summary>
        /// <param name="acceptOdrList">受注マスタデータ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList acceptOdrList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            acceptOdrList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, DATAINPUTSYSTEMRF, COMMONSEQNORF, SLIPDTLNUMRF, SLIPDTLNUMDERIVNORF, SRCLINKDATACODERF, SRCSLIPDTLNUMRF FROM ACCEPTODRRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

            //Prameterオブジェクトの作成
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

            //Parameterオブジェクトへ値設定
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
            findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;

            // SQL文
            sqlCommand.CommandText = sqlText;

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                acceptOdrList.Add(this.CopyToAcceptOdrWorkFromReader(ref myReader));
            }

            if (acceptOdrList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            if (myReader != null)
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → acceptOdrWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private DCAcceptOdrWork CopyToAcceptOdrWorkFromReader(ref SqlDataReader myReader)
        {
            DCAcceptOdrWork acceptOdrWork = new DCAcceptOdrWork();

			this.CopyToAcceptOdrWorkFromReader(ref myReader, ref acceptOdrWork);

            return acceptOdrWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → acceptOdrWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="acceptOdrWork">acceptOdrWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private void CopyToAcceptOdrWorkFromReader(ref SqlDataReader myReader, ref DCAcceptOdrWork acceptOdrWork)
        {
            if (myReader != null && acceptOdrWork != null)
            {
				# region クラスへ格納
				acceptOdrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				acceptOdrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				acceptOdrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				acceptOdrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				acceptOdrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				acceptOdrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				acceptOdrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				acceptOdrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				acceptOdrWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				acceptOdrWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
				acceptOdrWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
				acceptOdrWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
				acceptOdrWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
				acceptOdrWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
				acceptOdrWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
				acceptOdrWork.SlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDTLNUMDERIVNORF"));
				acceptOdrWork.SrcLinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCLINKDATACODERF"));
				acceptOdrWork.SrcSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SRCSLIPDTLNUMRF"));
				# endregion
            }
        }
		*/
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// クラス格納処理 Reader → acceptOdrWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public DCAcceptOdrWork CopyToAcceptOdrWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCAcceptOdrWork acceptOdrWork = new DCAcceptOdrWork();

			this.CopyToAcceptOdrWorkFromReaderSCM(ref myReader, ref acceptOdrWork, tableNm);

			return acceptOdrWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → acceptOdrWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="acceptOdrWork">acceptOdrWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToAcceptOdrWorkFromReaderSCM(ref SqlDataReader myReader, ref DCAcceptOdrWork acceptOdrWork, string tableNm)
		{
			if (myReader != null && acceptOdrWork != null)
			{
				# region クラスへ格納
				acceptOdrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				acceptOdrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				acceptOdrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				acceptOdrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				acceptOdrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				acceptOdrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				acceptOdrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				acceptOdrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				acceptOdrWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				acceptOdrWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCEPTANORDERNORF"));
				acceptOdrWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				acceptOdrWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPNUMRF"));
				acceptOdrWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DATAINPUTSYSTEMRF"));
				acceptOdrWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "COMMONSEQNORF"));
				acceptOdrWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SLIPDTLNUMRF"));
				acceptOdrWork.SlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPDTLNUMDERIVNORF"));
				acceptOdrWork.SrcLinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SRCLINKDATACODERF"));
				acceptOdrWork.SrcSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SRCSLIPDTLNUMRF"));
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ削除
        /// </summary>
        /// <param name="dcAcceptOdrWorkList">受注マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcAcceptOdrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcAcceptOdrWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ削除
        /// </summary>
        /// <param name="dcAcceptOdrWorkList">受注マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcAcceptOdrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCAcceptOdrWork dcAcceptOdrWork in dcAcceptOdrWorkList)
            {


                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM ACCEPTODRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND COMMONSEQNORF=@FINDCOMMONSEQNO AND SLIPDTLNUMRF=@FINDSLIPDTLNUM AND SLIPDTLNUMDERIVNORF=@FINDSLIPDTLNUMDERIVNO";
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                SqlParameter findParaCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                SqlParameter findParaSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter findParaSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@FINDSLIPDTLNUMDERIVNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcAcceptOdrWork.EnterpriseCode;
                findParaSectionCode.Value = dcAcceptOdrWork.SectionCode;
                findParaAcptAnOdrStatus.Value = dcAcceptOdrWork.AcptAnOdrStatus;
                findParaDataInputSystem.Value = dcAcceptOdrWork.DataInputSystem;
                findParaCommonSeqNo.Value = dcAcceptOdrWork.CommonSeqNo;
                findParaSlipDtlNum.Value = dcAcceptOdrWork.SlipDtlNum;
                findParaSlipDtlNumDerivNo.Value = dcAcceptOdrWork.SlipDtlNumDerivNo;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 受注マスタを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ登録
        /// </summary>
        /// <param name="dcAcceptOdrWorkList">受注マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcAcceptOdrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcAcceptOdrWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ登録
        /// </summary>
        /// <param name="dcAcceptOdrWorkList">受注マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcAcceptOdrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCAcceptOdrWork dcAcceptOdrWork in dcAcceptOdrWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO ACCEPTODRRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, DATAINPUTSYSTEMRF, COMMONSEQNORF, SLIPDTLNUMRF, SLIPDTLNUMDERIVNORF, SRCLINKDATACODERF, SRCSLIPDTLNUMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @DATAINPUTSYSTEM, @COMMONSEQNO, @SLIPDTLNUM, @SLIPDTLNUMDERIVNO, @SRCLINKDATACODE, @SRCSLIPDTLNUM)";
                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                SqlParameter paraSlipDtlNum = sqlCommand.Parameters.Add("@SLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter paraSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@SLIPDTLNUMDERIVNO", SqlDbType.Int);
                SqlParameter paraSrcLinkDataCode = sqlCommand.Parameters.Add("@SRCLINKDATACODE", SqlDbType.Int);
                SqlParameter paraSrcSlipDtlNum = sqlCommand.Parameters.Add("@SRCSLIPDTLNUM", SqlDbType.BigInt);


                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcAcceptOdrWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcAcceptOdrWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcAcceptOdrWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcAcceptOdrWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcAcceptOdrWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcAcceptOdrWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcAcceptOdrWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcAcceptOdrWork.SectionCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrWork.AcceptAnOrderNo);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrWork.AcptAnOdrStatus);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(dcAcceptOdrWork.SalesSlipNum);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrWork.DataInputSystem);
                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(dcAcceptOdrWork.CommonSeqNo);
                paraSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dcAcceptOdrWork.SlipDtlNum);
                paraSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrWork.SlipDtlNumDerivNo);
                paraSrcLinkDataCode.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrWork.SrcLinkDataCode);
                paraSrcSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dcAcceptOdrWork.SrcSlipDtlNum);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 受注マスタを登録する
                sqlCommand.ExecuteNonQuery();
            }

        }
        #endregion

		// ADD 2011.08.26 張莉莉 ---------->>>>>
		# region [Clear]
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                       //DEL by Liangsd     2011/09/06
        public void Clear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
        {
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            ClearProc(sectionCode, enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
        }
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd     2011/09/06
        private void ClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
        {
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            //sqlCommand.CommandText = "DELETE FROM ACCEPTODRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE "; //DEL by Liangsd     2011/09/06
            //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ACCEPTODRRF WHERE   EXISTS ").Append(Environment.NewLine);
            sb.Append("(SELECT ACCEPTODRRF.ACCEPTANORDERNORF FROM SALESDETAILRF,SALESSLIPRF WHERE SALESSLIPRF.ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
            sb.Append(" AND SALESSLIPRF.ENTERPRISECODERF = SALESDETAILRF.ENTERPRISECODERF").Append(Environment.NewLine);
            sb.Append(" AND SALESSLIPRF.ACPTANODRSTATUSRF = SALESDETAILRF.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            sb.Append(" AND SALESSLIPRF.SALESSLIPNUMRF = SALESDETAILRF.SALESSLIPNUMRF ").Append(Environment.NewLine);
            sb.Append(" AND SALESDETAILRF.ENTERPRISECODERF = ACCEPTODRRF.ENTERPRISECODERF").Append(Environment.NewLine);
            sb.Append(" AND ((SALESDETAILRF.ACPTANODRSTATUSRF = 10 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 1)").Append(Environment.NewLine);
            sb.Append(" OR (SALESDETAILRF.ACPTANODRSTATUSRF = 20 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 3)").Append(Environment.NewLine);
            sb.Append(" OR (SALESDETAILRF.ACPTANODRSTATUSRF = 30 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 7)").Append(Environment.NewLine);
            sb.Append(" OR (SALESDETAILRF.ACPTANODRSTATUSRF = 40 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 5))").Append(Environment.NewLine);
            sb.Append(" AND SALESDETAILRF.SALESSLIPNUMRF = ACCEPTODRRF.SALESSLIPNUMRF ").Append(Environment.NewLine);
            sb.Append(" AND SALESSLIPRF.RESULTSADDUPSECCDRF = @FINDSECTIONCODERF)").Append(Environment.NewLine);
            sqlCommand.CommandText = sb.ToString();
            //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameterオブジェクトへ値設定
			findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // 売上データを削除する
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
		// ADD 2011.08.26 張莉莉 ----------<<<<<
        # region [Clear]
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// データクリア
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void StockClear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
        {
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            StockClearProc(sectionCode, enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
        }
        /// <summary>
        /// データクリア
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void StockClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
        {
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ACCEPTODRRF WHERE   EXISTS ").Append(Environment.NewLine);
            sb.Append("(SELECT ACCEPTODRRF.ACCEPTANORDERNORF FROM STOCKSLIPRF,STOCKDETAILRF WHERE STOCKSLIPRF.ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPRF.ENTERPRISECODERF = STOCKDETAILRF.ENTERPRISECODERF").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPRF.SUPPLIERFORMALRF = STOCKDETAILRF.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPRF.SUPPLIERSLIPNORF = STOCKDETAILRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKDETAILRF.ENTERPRISECODERF = ACCEPTODRRF.ENTERPRISECODERF").Append(Environment.NewLine);
            sb.Append(" AND ((STOCKDETAILRF.SUPPLIERFORMALRF = 0 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 6)").Append(Environment.NewLine);
            sb.Append(" OR (STOCKDETAILRF.SUPPLIERFORMALRF = 1 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 4)").Append(Environment.NewLine);
            sb.Append(" OR (STOCKDETAILRF.SUPPLIERFORMALRF = 2 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 2))").Append(Environment.NewLine);
            sb.Append(" AND STOCKDETAILRF.SUPPLIERSLIPNORF = ACCEPTODRRF.ACCEPTANORDERNORF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPRF.STOCKADDUPSECTIONCDRF = @FINDSECTIONCODERF)").Append(Environment.NewLine);
            sqlCommand.CommandText = sb.ToString();
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // 売上データを削除する
            sqlCommand.ExecuteNonQuery();

        }
        #endregion
    }
}
