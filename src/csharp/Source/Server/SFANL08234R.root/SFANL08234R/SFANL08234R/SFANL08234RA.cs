//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ
// Sub System       :
// Program name     :   自由帳票印字位置設定　リモートオブジェクト
//                  :   SFANL08234R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   柏原　頼人
// Date             :   2007.05.24
//----------------------------------------------------------------------//
// Update Note      :
//----------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
	/// 自由帳票印字位置設定　リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票印字位置設定マスタ取得を行うクラスです。</br>
	/// <br>Programmer : 22011　柏原　頼人</br>
	/// <br>Date       : 2007.05.24</br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
    public class FrePrtPSetDLDB : RemoteDB, IFrePrtPSetDLDB
	{
		/// <summary>
		/// 自由帳票印字位置設定　リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22011 柏原　頼人</br>
		/// <br>Date       : 2007.05.24</br>
		/// </remarks>
		public FrePrtPSetDLDB()
//            : base("SFANL08123D", "Broadleaf.Application.Remoting.ParamData.FrePrtPSetWork", "FREPRTPSETRF")
		{
        }

        #region 自由帳票印字位置設定・背景画像の取得処理
        /// <summary>
        /// 自由帳票印字位置設定・背景画像の取得を行います。
        /// </summary>
        /// <param name="frePrtPSetWorkByte">自由帳票印字位置設定データパラメータ(キー値のみを指定)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票印字位置設定情報を取得します</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2007.05.24</br>
        /// </remarks>
        public int Read( ref byte[] frePrtPSetWorkByte, out bool msgDiv, out string errMsg )
        {
            return ReadProc( ref frePrtPSetWorkByte, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票印字位置設定・背景画像の取得を行います。
        /// </summary>
        /// <param name="frePrtPSetWorkByte">自由帳票印字位置設定データパラメータ(キー値のみを指定)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int ReadProc( ref byte[] frePrtPSetWorkByte, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msgDiv = false;
            errMsg = "";

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (_connectionText == null || _connectionText == "") return status;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;


            try
            {
                // XMLの読み込み
                FrePrtPSetWork frePrtPSetWork = (FrePrtPSetWork)XmlByteSerializer.Deserialize(frePrtPSetWorkByte, typeof(FrePrtPSetWork));

                //DB接続・トランザクション開始
                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 自由帳票印字位置取得処理メイン
                status = ReadFrePrtPSetWork(ref frePrtPSetWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLへ変換し、文字列のバイナリ化
                    frePrtPSetWorkByte = XmlByteSerializer.Serialize(frePrtPSetWork);
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "Read Exception\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票印字位置設定情報読込中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Read Exception\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 自由帳票印字位置設定・背景画像取得メイン処理
        /// </summary>
        /// <param name="frePrtPSetWork">自由帳票印字位置設定データパラメータ(キー値のみを指定)</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票印字位置設定情報を取得します</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2007.05.24</br>
        /// </remarks>
        private int ReadFrePrtPSetWork(ref FrePrtPSetWork frePrtPSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                // Selectコマンドの生成
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO AND SLIPORPRTPPRDIVCDRF=@FINDSLIPORPRTPPRDIVCD");

                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
                    SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);
                    SqlParameter findParaPrintPaperUseDivcd = sqlCommand.Parameters.Add("@FINDSLIPORPRTPPRDIVCD", SqlDbType.Int);
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //Parameterオブジェクトへ値設定
                    findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                    findParaPrintPaperUseDivcd.Value = frePrtPSetWork.PrintPaperUseDivcd;
                    findEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                    
                    //タイムアウト時間設定
                    RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        #region クラスへ代入
                        frePrtPSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        frePrtPSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        frePrtPSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        frePrtPSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        frePrtPSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        frePrtPSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        frePrtPSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        frePrtPSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        frePrtPSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                        frePrtPSetWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
                        frePrtPSetWork.PrintPaperUseDivcd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERUSEDIVCDRF"));
                        frePrtPSetWork.PrintPaperDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERDIVCDRF"));
                        frePrtPSetWork.ExtractionPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGIDRF"));
                        frePrtPSetWork.ExtractionPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGCLASSIDRF"));
                        frePrtPSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
                        frePrtPSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
                        frePrtPSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
                        frePrtPSetWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                        frePrtPSetWork.PrtPprUserDerivNoCmt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTPPRUSERDERIVNOCMTRF"));
                        frePrtPSetWork.PrintPositionVer = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPOSITIONVERRF"));
                        frePrtPSetWork.MergeablePrintPosVer = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MERGEABLEPRINTPOSVERRF"));
                        frePrtPSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                        frePrtPSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
                        frePrtPSetWork.FreePrtPprItemGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
                        frePrtPSetWork.FormFeedLineCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FORMFEEDLINECOUNTRF"));
                        frePrtPSetWork.EdgeCharProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDGECHARPROCDIVCDRF"));
                        frePrtPSetWork.PrtPprBgImageRowPos = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGEROWPOSRF"));
                        frePrtPSetWork.PrtPprBgImageColPos = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGECOLPOSRF"));
                        frePrtPSetWork.TakeInImageGroupCd = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("TAKEINIMAGEGROUPCDRF"));
                        frePrtPSetWork.FreePrtPprSpPrpseCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSPPRPSECDRF"));
                        frePrtPSetWork.PrintPosClassData = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("PRINTPOSCLASSDATARF"));
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        #endregion
                    }
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        #endregion

        #region 自由帳票印字位置設定検索処理
        /// <summary>
		/// 自由帳票印字位置設定検索処理
		/// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
		/// <param name="OutputFormFileName">出力ファイル名</param>
		/// <param name="frePrtPSetWorkListkByte">検索した自由帳票印字位置設定リスト</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票印字位置設定情報を検索します</br>
		/// <br>           : ※出力ファイル名未指定時、全リストを取得します</br>
		/// <br>Programmer : 22011 柏原　頼人</br>
		/// <br>Date        : 2007.05.24</br>
		/// </remarks>
        public int Search( string EnterpriseCode, string OutputFormFileName, out byte[] frePrtPSetWorkListkByte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
        {
            return SearchProc( EnterpriseCode, OutputFormFileName, out frePrtPSetWorkListkByte, readMode, logicalMode, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票印字位置設定検索処理
        /// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="OutputFormFileName">出力ファイル名</param>
        /// <param name="frePrtPSetWorkListkByte">検索した自由帳票印字位置設定リスト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int SearchProc( string EnterpriseCode, string OutputFormFileName, out byte[] frePrtPSetWorkListkByte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			frePrtPSetWorkListkByte = null;
            SqlConnection sqlConnection = null;
            msgDiv = false;
            errMsg = "";

            try
            {
                //コネクション文字列取得対応↓↓↓↓↓
                //※各publicメソッドの開始時にコネクション文字列を取得
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                ArrayList retobj;
                status = SearchProc(EnterpriseCode, OutputFormFileName, ref sqlConnection, out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLへ変換し、リストのバイナリ化
                    FrePrtPSetWork[] frePrtPSetWorkList = (FrePrtPSetWork[])retobj.ToArray(typeof(FrePrtPSetWork));
                    frePrtPSetWorkListkByte = XmlByteSerializer.Serialize(frePrtPSetWorkList);
                }
                else
                {
                    frePrtPSetWorkListkByte = null;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "Search SQLException\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票印字位置設定情報検索中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Search Exception\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
			return status;
		}

		/// <summary>
		/// 自由帳票印字位置設定検索処理メイン
		/// </summary>
        /// <param name="EnterpriseCode">企業コード</param>
		/// <param name="OutputFormFileName">出力ファイル名</param>
        /// <param name="sqlConnection">コネクション情報</param>
		/// <param name="retobj">検索した自由帳票印字位置設定リスト(ArrayList)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票印字位置設定情報を検索します</br>
		/// <br>           : ※出力ファイル名未指定時、全リストを取得します</br>
		/// <br>Programmer : 22011 柏原　頼人</br>
		/// <br>Date       : 2007.05.24</br>
		/// </remarks>
		private int SearchProc(string EnterpriseCode,string OutputFormFileName,ref SqlConnection sqlConnection, out ArrayList retobj)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			retobj = null;
			ArrayList al = new ArrayList();
			
            try 
			{				
				SqlCommand sqlCommand;

				//データ読込
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE");

				// 出力ファイル名指定がある場合は検索条件に入れる
				if( OutputFormFileName != null && OutputFormFileName != "")
				{
                    sb.Append(" AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME ");
				}
                sb.Append(" ORDER BY OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF"); 

				using(sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
				{
                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);                    
                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = EnterpriseCode;
                 
					// 出力ファイル名指定がある場合は検索条件に入れる
					if( OutputFormFileName != null && OutputFormFileName != "")
					{
						SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NChar);
						paraOutputFormFileName.Value = OutputFormFileName;
					}

                    //タイムアウト時間設定
                    RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);
					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						FrePrtPSetWork frePrtPSetWork = new FrePrtPSetWork();
                        frePrtPSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        frePrtPSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        frePrtPSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        frePrtPSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        frePrtPSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        frePrtPSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        frePrtPSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        frePrtPSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        frePrtPSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                        frePrtPSetWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
                        frePrtPSetWork.PrintPaperUseDivcd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERUSEDIVCDRF"));
                        frePrtPSetWork.PrintPaperDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERDIVCDRF"));
                        frePrtPSetWork.ExtractionPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGIDRF"));
                        frePrtPSetWork.ExtractionPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGCLASSIDRF"));
                        frePrtPSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
                        frePrtPSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
                        frePrtPSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
                        frePrtPSetWork.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                        frePrtPSetWork.PrtPprUserDerivNoCmt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTPPRUSERDERIVNOCMTRF"));
                        frePrtPSetWork.PrintPositionVer = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPOSITIONVERRF"));
                        frePrtPSetWork.MergeablePrintPosVer = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MERGEABLEPRINTPOSVERRF"));
                        frePrtPSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                        frePrtPSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
                        frePrtPSetWork.FreePrtPprItemGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
                        frePrtPSetWork.FormFeedLineCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FORMFEEDLINECOUNTRF"));
                        frePrtPSetWork.EdgeCharProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDGECHARPROCDIVCDRF"));
                        frePrtPSetWork.PrtPprBgImageRowPos = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGEROWPOSRF"));
                        frePrtPSetWork.PrtPprBgImageColPos = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGECOLPOSRF"));
                        frePrtPSetWork.TakeInImageGroupCd = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("TAKEINIMAGEGROUPCDRF"));
                        frePrtPSetWork.FreePrtPprSpPrpseCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSPPRPSECDRF"));
                        //frePrtPSetWork.PrintPosClassData = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("PRINTPOSCLASSDATARF"));
                        al.Add(frePrtPSetWork);
					}
                    if(al.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();
			
			retobj = al;
			return status;
        }
        #endregion

        #region 自由帳票選択ガイド情報検索処理
        /// <summary>
        /// 自由帳票選択ガイド情報検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="printPaperUseDivcd">帳票区分コード(1:帳票,2:伝票)</param>
        /// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
        /// <param name="dataInputSystem ">データ入力システム(0:共通,1:SF,2:BK,3:SH)</param>
        /// <param name="frePrtPSetSearchRetWork">印字位置設定ワーククラス配列</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定された自由帳票印字位置設定検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.05.09</br>
        /// <br>Update Note : 22011 柏原　頼人</br>
        /// <br>            : ガイドのサーチをDL用リモートに統合</br>
        /// </remarks>
        public int Search( string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem, out byte[] frePrtPSetSearchRetWork, out bool msgDiv, out string errMsg )
        {
            return SearchProc( enterpriseCode, printPaperUseDivcd, printPaperDivCd, dataInputSystem, out frePrtPSetSearchRetWork, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票選択ガイド情報検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="printPaperUseDivcd">帳票区分コード(1:帳票,2:伝票)</param>
        /// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
        /// <param name="dataInputSystem ">データ入力システム(0:共通,1:SF,2:BK,3:SH)</param>
        /// <param name="frePrtPSetSearchRetWork">印字位置設定ワーククラス配列</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchProc( string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem, out byte[] frePrtPSetSearchRetWork, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            msgDiv = false;
            errMsg = string.Empty;
            frePrtPSetSearchRetWork = null;

            SqlConnection sqlConnection = null;
            try
            {
                ArrayList retobj;

                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // メソッド固有情報とコネクションを渡してサービスジョブテーブルへ書き込み
                StringBuilder paraStr = new StringBuilder("Search Para: ");
                paraStr.Append("enterpriseCode ,").Append(enterpriseCode);
                paraStr.Append("printPaperUseDivcd ,").Append(printPaperUseDivcd);
                paraStr.Append("printPaperDivCd ,").Append(printPaperDivCd);
                if (dataInputSystem != null && dataInputSystem.Length > 0)
                {
                    paraStr.Append("dataInputSystem ");
                    foreach (int systemDivCd in dataInputSystem)
                        paraStr.Append(systemDivCd);
                }

                status = SearchFrePrtPSetProc(enterpriseCode, printPaperUseDivcd, printPaperDivCd, dataInputSystem, out retobj, sqlConnection);
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLへ変換し、リストのバイナリ化
                    FrePrtPSetWork[] frePrtPSetWorkList = (FrePrtPSetWork[])retobj.ToArray(typeof(FrePrtPSetWork));
                    frePrtPSetSearchRetWork = XmlByteSerializer.Serialize(frePrtPSetWorkList);
                }
                else
                {
                    frePrtPSetSearchRetWork = null;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePrtPSetDLDB_Search SQLException\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票選択ガイド情報取得処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePrtPSetDLDB_Search Exception\n"+ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null) sqlConnection.Close();
            }

            return status;
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// 自由帳票選択ガイド情報検索処理（メイン部）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="printPaperUseDivcd">帳票区分コード(1:帳票,2:伝票)</param>
        /// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
        /// <param name="dataInputSystem ">データ入力システム(0:共通,1:SF,2:BK,3:SH)</param>
        /// <param name="frePrtPSetSearchRetWork">印字位置設定ワーククラス配列</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定された自由帳票印字位置設定検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer	: 22024 寺坂　誉志</br>
        /// <br>Date		: 2007.05.09</br>
        /// <br>Update Note : 22011 柏原　頼人</br>
        /// <br>            : ガイドのサーチをDL用リモートに統合</br>
        /// </remarks>
        private int SearchFrePrtPSetProc(string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem, out ArrayList frePrtPSetSearchRetWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            frePrtPSetSearchRetWork = new ArrayList();

            try
            {
                //Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand("SELECT ENTERPRISECODERF, UPDATEDATETIMERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, DISPLAYNAMERF, FREEPRTPPRITEMGRPCDRF, PRTPPRUSERDERIVNOCMTRF, DATAINPUTSYSTEMRF FROM FREPRTPSETRF", sqlConnection);

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterpriseCode, printPaperUseDivcd, printPaperDivCd, dataInputSystem);

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    FrePrtPSetWork frePrtPSetSearchRetWk = new FrePrtPSetWork();

                    #region データのコピー
                    frePrtPSetSearchRetWk.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    frePrtPSetSearchRetWk.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    frePrtPSetSearchRetWk.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    frePrtPSetSearchRetWk.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
                    frePrtPSetSearchRetWk.DisplayName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
                    frePrtPSetSearchRetWk.FreePrtPprItemGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
                    frePrtPSetSearchRetWk.PrtPprUserDerivNoCmt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTPPRUSERDERIVNOCMTRF"));
                    frePrtPSetSearchRetWk.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                    #endregion

                    frePrtPSetSearchRetWork.Add(frePrtPSetSearchRetWk);
                }

                

                if (frePrtPSetSearchRetWork.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// WHERE文作成処理
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="printPaperUseDivcd">帳票区分コード(1:帳票,2:伝票)</param>
        /// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
        /// <param name="dataInputSystem ">データ入力システム(0:共通,1:SF,2:BK,3:SH)</param>
        /// <returns>WHERE文</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem)
        {
            StringBuilder whereString = new StringBuilder();

            // 企業コードは必須条件
            whereString.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = enterpriseCode;

            // 帳票区分コード(1:帳票,2:伝票)
            if (printPaperUseDivcd != 0)
            {
                whereString.Append(" AND ");
                whereString.Append("PRINTPAPERUSEDIVCDRF=@FINDPRINTPAPERUSEDIVCD");
                SqlParameter findParaPrintPaperUseDivcd = sqlCommand.Parameters.Add("@FINDPRINTPAPERUSEDIVCD", SqlDbType.Int);
                findParaPrintPaperUseDivcd.Value = printPaperUseDivcd;
            }

            // 帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)
            if (printPaperDivCd != 0)
            {
                whereString.Append(" AND ");
                whereString.Append("PRINTPAPERDIVCDRF=@FINDPRINTPAPERDIVCD");
                SqlParameter findParaPrintPaperDivCd = sqlCommand.Parameters.Add("@FINDPRINTPAPERDIVCD", SqlDbType.Int);
                findParaPrintPaperDivCd.Value = printPaperDivCd;
            }

            // データ入力システム(0:共通,1:SF,2:BK,3:SH)
            if (dataInputSystem != null && dataInputSystem.Length > 0)
            {
                whereString.Append(" AND ");
                whereString.Append("DATAINPUTSYSTEMRF IN (");
                StringBuilder wkStr = new StringBuilder();
                foreach (int systemDivCd in dataInputSystem)
                {
                    if (wkStr.Length > 0)
                        wkStr.Append(",");
                    wkStr.Append(systemDivCd);
                }
                whereString.Append(wkStr.ToString()).Append(")");
            }

            return whereString.ToString();
        }
        #endregion

        #region 印字位置物理削除
        /// <summary>
        /// 自由帳票印字位置情報を物理削除します
        /// </summary>
        /// <param name="parabyte">FrePrtPSetWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        public int DeleteFrePrtPSet( byte[] parabyte, out bool msgDiv, out string errMsg )
        {
            return DeleteFrePrtPSetProc( parabyte, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 自由帳票印字位置情報を物理削除します
        /// </summary>
        /// <param name="parabyte">FrePrtPSetWorkオブジェクト</param>
        /// <param name="msgDiv">メッセージ有無区分</param>
        /// <param name="errMsg">エラーメッセージ文字列</param>
        /// <returns>STATUS</returns>
        private int DeleteFrePrtPSetProc( byte[] parabyte, out bool msgDiv, out string errMsg )
        {
            int status;
            msgDiv = false;
            errMsg = "";
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
            List<SlipPrtSetWork> deleteSlipList = new List<SlipPrtSetWork>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
            
            sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // XMLの読み込み
                FrePrtPSetWork frePrtPSetWork = (FrePrtPSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(FrePrtPSetWork));

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                if ( frePrtPSetWork.PrintPaperUseDivcd == 2 )
                {
                    // 伝票印刷設定の抽出
                    deleteSlipList = SearchSlipPrtSet( frePrtPSetWork, ref sqlConnection );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 印字位置データ物理削除
                status = DeleteFrePrtPSetProc(frePrtPSetWork, sqlConnection, sqlTransaction);

                // ソート順物理削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteFrePprSrtOProc(frePrtPSetWork, sqlConnection, sqlTransaction);
                }
                // 抽出条件物理削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteFrePprECndProc(frePrtPSetWork, sqlConnection, sqlTransaction);
                }
                // 伝票印刷設定
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 伝票の時
                    if (frePrtPSetWork.PrintPaperUseDivcd == 2)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 DEL
                        //SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
                        ////status = slipPrtSetDB.Delete(frePrtPSetWork.EnterpriseCode, frePrtPSetWork.DataInputSystem, frePrtPSetWork.OutputFormFileName + frePrtPSetWork.UserPrtPprIdDerivNo.ToString(), sqlConnection, sqlTransaction);
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 ADD
                        //int slipPrtKind = 30;   // 30:売上伝票
                        //status = slipPrtSetDB.Delete( frePrtPSetWork.EnterpriseCode, frePrtPSetWork.DataInputSystem, slipPrtKind, frePrtPSetWork.OutputFormFileName + frePrtPSetWork.UserPrtPprIdDerivNo.ToString(), ref sqlConnection, ref sqlTransaction );
                        //if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR )
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        //}
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 ADD
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
                        DeleteSlipPrtSet( deleteSlipList, ref sqlConnection, ref sqlTransaction );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
                    }
                }
                // 印字位置振替情報削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //帳票の時
                    if (frePrtPSetWork.PrintPaperUseDivcd == 1)
                    {
                        FreePprGrpDB freePprGrpDB = new FreePprGrpDB();
                        status = freePprGrpDB.DeleteFrePprGrTrProc(frePrtPSetWork.EnterpriseCode, frePrtPSetWork.OutputFormFileName, frePrtPSetWork.UserPrtPprIdDerivNo, sqlConnection, sqlTransaction);
                    }
                }


                // コミットorロールバック処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null)
                        sqlTransaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                // ロールバック
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
                status = base.WriteSQLErrorLog(ex, "FreePprGrpDB.DeleteFrePrtPSet SQLException=" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票印字位置設定情報削除中にサーバーでタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                // ロールバック
                if (sqlTransaction.Connection != null)
                    sqlTransaction.Rollback();
                base.WriteErrorLog(ex, "FreePprGrpDB.DeleteFrePrtPSet Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null) sqlConnection.Close();
            }

            return status;
        }

        /// <summary>
        /// 伝票印刷設定削除対象抽出
        /// </summary>
        /// <param name="frePrtPSetWork"></param>
        /// <param name="sqlConnection"></param>
        private List<SlipPrtSetWork> SearchSlipPrtSet( FrePrtPSetWork frePrtPSetWork, ref SqlConnection sqlConnection )
        {
            List<SlipPrtSetWork> slipPrtSetWorkList = new List<SlipPrtSetWork>();

            SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();
            ArrayList retList;
            SlipPrtSetWork paraWork = new SlipPrtSetWork();
            paraWork.EnterpriseCode = frePrtPSetWork.EnterpriseCode;

            int status = slipPrtSetDB.Search( out retList, paraWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                foreach ( SlipPrtSetWork slipPrtSetWork in retList )
                {
                    //if ( slipPrtSetWork.EnterpriseCode == frePrtPSetWork.EnterpriseCode
                    //    && slipPrtSetWork.OutputFormFileName == frePrtPSetWork.OutputFormFileName
                    //    && slipPrtSetWork.SpecialPurpose2 == frePrtPSetWork.UserPrtPprIdDerivNo.ToString() )
                    if ( slipPrtSetWork.EnterpriseCode == frePrtPSetWork.EnterpriseCode
                        && slipPrtSetWork.OutputFormFileName == frePrtPSetWork.OutputFormFileName)
                    {
                        slipPrtSetWorkList.Add( slipPrtSetWork );
                    }
                }
            }

            return slipPrtSetWorkList;
        }

        /// <summary>
        /// 伝票印刷設定削除処理
        /// </summary>
        /// <param name="slipPrtSetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        private void DeleteSlipPrtSet( List<SlipPrtSetWork> slipPrtSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();

            foreach ( SlipPrtSetWork slipPrtSetWork in slipPrtSetWorkList )
            {
                // 削除
                slipPrtSetDB.Delete( slipPrtSetWork.EnterpriseCode, slipPrtSetWork.DataInputSystem, slipPrtSetWork.SlipPrtKind, slipPrtSetWork.SlipPrtSetPaperId, ref sqlConnection, ref sqlTransaction );
            }
        }

        #region 自由帳票印字位置情報を物理削除
        /// <summary>
        /// 自由帳票印字位置情報を物理削除します
        /// </summary>
        /// <param name="frePrtPSetWork">自由帳票印字位置ワーク</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteFrePrtPSetProc(FrePrtPSetWork frePrtPSetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO", sqlConnection, sqlTransaction);

                //Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);
                
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                
                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != frePrtPSetWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        if (!myReader.IsClosed) myReader.Close();
                        return status;
                    }

                    sqlCommand.CommandText = "DELETE FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                    findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePrtPSetDLDB.DeleteFreePprGrpProc SQLException=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePrtPSetDLDB.DeleteFreePprGrpProc Exception=" + ex.Message);
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

        #region 自由帳票ソート順情報を物理削除
        /// <summary>
        /// 自由帳票ソート順情報を物理削除します
        /// </summary>
        /// <param name="frePrtPSetWork">自由帳票印字位置ワーク</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteFrePprSrtOProc(FrePrtPSetWork frePrtPSetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("SELECT ENTERPRISECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPPRSRTORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO ", sqlConnection, sqlTransaction);

                //Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    sqlCommand.CommandText = "DELETE FROM FREPPRSRTORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                    findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePrtPSetDLDB.DeleteFrePprSrtOProc SQLException=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePrtPSetDLDB.DeleteFrePprSrtOProc Exception=" + ex.Message);
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

        #region 自由帳票抽出条件情報を物理削除
        /// <summary>
        /// 自由帳票抽出条件情報を物理削除します
        /// </summary>
        /// <param name="frePrtPSetWork">自由帳票印字位置ワーク</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int DeleteFrePprECndProc(FrePrtPSetWork frePrtPSetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("SELECT ENTERPRISECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF FROM FREPPRECNDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO ", sqlConnection, sqlTransaction);

                //Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
                SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;

                //タイムアウト時間設定
                RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    sqlCommand.CommandText = "DELETE FROM FREPPRECNDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
                    findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
                    findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;
                }
                if (!myReader.IsClosed) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePrtPSetDLDB.DeleteFrePprECndProc SQLException=" + ex.Message, status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePrtPSetDLDB.DeleteFrePprECndProc Exception=" + ex.Message);
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

    #endregion
    }
}