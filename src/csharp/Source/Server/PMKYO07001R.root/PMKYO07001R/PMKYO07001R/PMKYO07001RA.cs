//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/25  修正内容 : #23998　在庫移動データの受信区分変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/08  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/15  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/09/22  修正内容 : #25443　在庫移動のシェアチェックのフラグ設定不正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/01  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/12/06  修正内容 : Redmine#8293 画面の終了日付＋システム時刻仕様の変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : zhlj
// 修 正 日  2013/02/07  修正内容 : 10900690-00 2013/3/13配信分の緊急対応
//                                  Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応
//----------------------------------------------------------------------------//
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
using Broadleaf.Library.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// データ送信処理READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br></br>
    /// <br>Update Note: SCM対応 - 拠点管理(10704767-00) 受信時更新処理を追加</br>
    /// <br>Programmer : qijh</br>
    /// <br>Date       : 2011/08/10</br>
    /// <br>Update Note: Redmine#26228　拠点管理改良／伝票日付による抽出対応</br>
    /// <br>Programmer : 許培珠</br>
    /// <br>Date       : 2011/11/01</br>
    /// <br>Update Note: 10900690-00 2012/3/13配信分の緊急対応</br>
    /// <br>           : Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応</br>
    /// <br>Programmer : zhlj</br>
    /// <br>Date       : 2013/02/07</br>
    /// </remarks>
    [Serializable]
	public class APSendMessageDB : RemoteWithAppLockDB, IAPSendMessageDB
    {
        // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
        private SecMngSndRcvDB _SecMngSndRcvDB = null;
        /// <summary>
        /// 拠点管理送受信対象設定マスタリモートプロパティ
        /// </summary>
        private SecMngSndRcvDB ScMngSndRcvDB
        {
            get
            {
                if (this._SecMngSndRcvDB == null)
                    this._SecMngSndRcvDB = new SecMngSndRcvDB();
                return this._SecMngSndRcvDB;
            }
        }
        // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

        /// <summary>
        /// データ送信処理READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APSendMessageDB()
        {
        }

        #region ◆ データ送信の画面の初期化データ検索処理 ◆
        /// <summary>
        /// データ送信の画面の初期化データ検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
		/// <param name="secMngSetWorkList">検索パラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信画面の初期化データ検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
		//public int SearchLoadData(string enterpriseCodes, out APSecMngSetWork secMngSetWork, out string retMessage)
		public int SearchLoadData(string enterpriseCodes, out ArrayList secMngSetWorkList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;
			//secMngSetWork = new APSecMngSetWork();
			secMngSetWorkList = new ArrayList();

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

            sqlCommand = new SqlCommand("", sqlConnection);
            try
            {
                // Selectコマンドの生成
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				//sqlStr = "SELECT SECMNGSETRF.SECTIONCODERF, SECMNGSETRF.SYNCEXECDATERF, SECINFOSETRF.SECTIONGUIDENMRF FROM SECMNGSETRF, SECINFOSETRF WHERE SECMNGSETRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND SECMNGSETRF.KINDRF=@FINDKINDRF AND SECMNGSETRF.RECEIVECONDITIONRF=@FINDRECEIVECONDITIONRF AND SECMNGSETRF.ENTERPRISECODERF = SECINFOSETRF.ENTERPRISECODERF AND SECMNGSETRF.SECTIONCODERF = SECINFOSETRF.SECTIONCODERF AND SECMNGSETRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECINFOSETRF.LOGICALDELETECODERF=@FINDSECINFOLOGICALDELETECODE";
				sqlStr = "SELECT SECMNGSETRF.SECTIONCODERF, SECMNGSETRF.SENDDESTSECCODERF, SECMNGSETRF.SYNCEXECDATERF, SECMNGSETRF.AUTOSENDDIVRF FROM SECMNGSETRF  WHERE SECMNGSETRF.ENTERPRISECODERF=@FINDENTERPRISECODE  AND SECMNGSETRF.KINDRF=@FINDKINDRF  AND SECMNGSETRF.RECEIVECONDITIONRF=@FINDRECEIVECONDITIONRF  AND SECMNGSETRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY SECMNGSETRF.SECTIONCODERF, SECMNGSETRF.SENDDESTSECCODERF";
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);
                SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITIONRF", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				//SqlParameter paraSecinfoLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDSECINFOLOGICALDELETECODE", SqlDbType.Int);// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                paraKind.Value = SqlDataMediator.SqlSetInt32(0);
                paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(0);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
				//paraSecinfoLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）

                sqlCommand.CommandText = sqlStr;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
                {
					APSecMngSetWork secMngSetWork = new APSecMngSetWork();
                    secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
					//secMngSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					secMngSetWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));
					secMngSetWork.AutoSendFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
					secMngSetWorkList.Add(secMngSetWork);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion ◆ データ送信の画面の初期化データ検索処理 ◆

        #region ◆ 拠点管理設定マスタの更新処理 ◆
        /// <summary>
        /// 拠点管理設定マスタの更新処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="syncExecDt">実行時間</param>
        /// <param name="retMessage">エラーメッセージ</param>
		/// <param name="baseCode">baseCode</param>
		/// <param name="sendCode">sendCode</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタの更新処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
		// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>
		//public int UpdateSecMngSet(string enterpriseCodes, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
		public int UpdateSecMngSet(string enterpriseCodes, string updEmployeeCode, DateTime syncExecDt, out string retMessage, string baseCode, string sendCode)
		// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("", sqlConnection);

                if (string.IsNullOrEmpty(updEmployeeCode))
                {
                    // 拠点管理設定マスタを更新する
					// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>
					//sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
					sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SENDDESTSECCODERF=@FINDSENDDESTSECCODE";
                   // UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<

					//Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }
                else
                {
                    // 拠点管理設定マスタを更新する
					// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>
					//sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
					sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SENDDESTSECCODERF=@FINDSENDDESTSECCODE";
					// UPD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updEmployeeCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }



                //Parameterオブジェクトの作成(検索用)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>
				SqlParameter findParaSectionCd = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				SqlParameter findParaSectionDestCd = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<

                //Parameterオブジェクトへ値設定(検索用)
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaKind.Value = SqlDataMediator.SqlSetInt32(0);
                findParaReceiveCondition.Value = SqlDataMediator.SqlSetInt32(0);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>
				findParaSectionCd.Value = SqlDataMediator.SqlSetString(baseCode);
				findParaSectionDestCd.Value = SqlDataMediator.SqlSetString(sendCode);
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<


                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 拠点管理設定マスタを更新する
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.ShipmentDirections Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion ◆ 拠点管理設定マスタの更新処理 ◆

        #region ◆ データ送信のデータ検索処理 ◆
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        /// <summary>
        /// データ送信のデータ検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始時間</param>
        /// <param name="endingDate">終了時間</param>
        /// <param name="retCSAList">検索結果</param>
        /// <param name="fileIds">ファイルID配列</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
		public int SearchCustomSerializeArrayList(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, string[] fileIds, out string retMessage)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();



#if DEBUG
                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                retCSAList = new CustomSerializeArrayList();

                foreach (string fileId in fileIds)
                {
                    switch (fileId)
                    {
                        // 売上データ
                        case "SalesSlipRF":
                            // 売上データ抽出
                            ArrayList salesSlipArrList = new ArrayList();
                            APSalesSlipDB _salesSlipDB = new APSalesSlipDB();
                            status = _salesSlipDB.SearchSalesSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out salesSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(salesSlipArrList);
                            }
                            break;
                        // 売上明細データ
                        case "SalesDetailRF":
                            // 売上明細データ抽出
                            ArrayList salesDetailArrList = new ArrayList();
                            APSalesDetailDB _salesDetailDB = new APSalesDetailDB();
                            status = _salesDetailDB.SearchSalesDetail(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out salesDetailArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(salesDetailArrList);
                            }
                            break;
                        // 売上履歴データ
                        case "SalesHistoryRF":
                            // 売上履歴データ抽出
                            ArrayList salesHistoryArrList = new ArrayList();
                            APSalesHistoryDB _salesHistoryDB = new APSalesHistoryDB();
                            status = _salesHistoryDB.SearchSalesHistory(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out salesHistoryArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(salesHistoryArrList);
                            }
                            break;
                        // 売上履歴明細データ
                        case "SalesHistDtlRF":
                            // 売上履歴明細データ抽出
                            ArrayList salesHistDtlArrList = new ArrayList();
                            APSalesHistDtlDB _salesHistDtlDB = new APSalesHistDtlDB();
                            status = _salesHistDtlDB.SearchSalesHistDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out salesHistDtlArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(salesHistDtlArrList);
                            }
                            break;
                        // 入金データ
                        case "DepsitMainRF":
                            // 入金データ抽出
                            ArrayList depsitMainArrList = new ArrayList();
                            APDepsitMainDB _depsitMainDB = new APDepsitMainDB();
                            status = _depsitMainDB.SearchDepsitMain(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out depsitMainArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(depsitMainArrList);
                            }
                            break;
                        // 入金明細データ
                        case "DepsitDtlRF":
                            // 入金明細データ抽出
                            ArrayList depsitDtlArrList = new ArrayList();
                            APDepsitDtlDB _depsitDtlDB = new APDepsitDtlDB();
                            status = _depsitDtlDB.SearchDepsitDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out depsitDtlArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(depsitDtlArrList);
                            }
                            break;
                        // 仕入データ
                        case "StockSlipRF":
                            // 仕入データ抽出
                            ArrayList stockSlipArrList = new ArrayList();
                            APStockSlipDB _stockSlipDB = new APStockSlipDB();
                            status = _stockSlipDB.SearchStockSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockSlipArrList);
                            }
                            break;
                        // 仕入明細データ
                        case "StockDetailRF":
                            // 仕入明細データ抽出
                            ArrayList stockDetailArrList = new ArrayList();
                            APStockDetailDB _stockDetailDB = new APStockDetailDB();
                            status = _stockDetailDB.SearchStockDetail(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockDetailArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockDetailArrList);
                            }
                            break;
                        // 仕入履歴データ
                        case "StockSlipHistRF":
                            // 仕入履歴データ抽出
                            ArrayList stockSlipHistArrList = new ArrayList();
                            APStockSlipHistDB _stockSlipHistDB = new APStockSlipHistDB();
                            status = _stockSlipHistDB.SearchStockSlipHist(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockSlipHistArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockSlipHistArrList);
                            }
                            break;
                        // 仕入履歴明細データ
                        case "StockSlHistDtlRF":
                            // 仕入履歴明細データ抽出
                            ArrayList stockSlHistDtlArrList = new ArrayList();
                            APStockSlHistDtlDB _stockSlHistDtlDB = new APStockSlHistDtlDB();
                            status = _stockSlHistDtlDB.SearchStockSlHistDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockSlHistDtlArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockSlHistDtlArrList);
                            }
                            break;
                        // 支払伝票マスタ
                        case "PaymentSlpRF":
                            // 支払伝票マスタ抽出
                            ArrayList paymentSlpArrList = new ArrayList();
                            APPaymentSlpDB _paymentSlpDB = new APPaymentSlpDB();
                            status = _paymentSlpDB.SearchPaymentSlp(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out paymentSlpArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(paymentSlpArrList);
                            }
                            break;
                        // 支払明細データ
                        case "PaymentDtlRF":
                            // 支払明細データ抽出
                            ArrayList paymentDtlArrList = new ArrayList();
                            APPaymentDtlDB _paymentDtlDB = new APPaymentDtlDB();
                            status = _paymentDtlDB.SearchPaymentDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out paymentDtlArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(paymentDtlArrList);
                            }
                            break;
                        // 受注マスタ
                        case "AcceptOdrRF":
                            // 受注マスタ抽出
                            ArrayList acceptOdrArrList = new ArrayList();
                            APAcceptOdrDB _acceptOdrDB = new APAcceptOdrDB();
                            status = _acceptOdrDB.SearchAcceptOdr(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out acceptOdrArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(acceptOdrArrList);
                            }
                            break;
                        // 受注マスタ（車両）
                        case "AcceptOdrCarRF":
                            // 受注マスタ（車両）抽出
                            ArrayList acceptOdrCarArrList = new ArrayList();
                            APAcceptOdrCarDB _acceptOdrCarDB = new APAcceptOdrCarDB();
                            status = _acceptOdrCarDB.SearchAcceptOdrCar(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out acceptOdrCarArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(acceptOdrCarArrList);
                            }
                            break;
                        // 売上月次集計データ
                        case "MTtlSalesSlipRF":
                            // 売上月次集計データ抽出
                            ArrayList mTtlSalesSlipArrList = new ArrayList();
                            APMTtlSalesSlipDB _mTtlSalesSlipDB = new APMTtlSalesSlipDB();
                            status = _mTtlSalesSlipDB.SearchMTtlSalesSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out mTtlSalesSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(mTtlSalesSlipArrList);
                            }
                            break;
                        // 商品別売上月次集計データ
                        case "GoodsMTtlSaSlipRF":
                            // 商品別売上月次集計データ抽出
                            ArrayList goodsMTtlSaSlipArrList = new ArrayList();
                            APGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = new APGoodsMTtlSaSlipDB();
                            status = _goodsMTtlSaSlipDB.SearchGoodsMTtlSaSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsMTtlSaSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(goodsMTtlSaSlipArrList);
                            }
                            break;
                        // 仕入月次集計データ
                        case "MTtlStockSlipRF":
                            // 仕入月次集計データ
                            ArrayList mTtlStockSlipArrList = new ArrayList();
                            APMTtlStockSlipDB _mTtlStockSlipDB = new APMTtlStockSlipDB();
                            status = _mTtlStockSlipDB.SearchMTtlStockSlip(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out mTtlStockSlipArrList, out retMessage);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(mTtlStockSlipArrList);
                            }
                            break;
                        // 在庫調整データ
                        case "StockAdjustRF":
                            // 在庫調整データ
                            ArrayList stockAdjustArrList = new ArrayList();
                            APStockAdjustDB _stockAdjustDB = new APStockAdjustDB();
							status = _stockAdjustDB.SearchStockAdjust(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage); 
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockAdjustArrList);
                            }
                            break;
                        // 在庫調整明細データ
                        case "StockAdjustDtlRF":
                            // 在庫調整明細データ
                            ArrayList stockAdjustDtlArrList = new ArrayList();
							APStockAdjustDtlDB _stockAdjustDtlDB = new APStockAdjustDtlDB();
							status = _stockAdjustDtlDB.SearchStockAdjustDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockAdjustDtlArrList);
                            }
                            break;
                        // 在庫移動データ
                        case "StockMoveRF":
                            // 在庫移動データ
                            ArrayList stockMoveArrList = new ArrayList();
                            APStockMoveDB _stockMoveDB = new APStockMoveDB();
							status = _stockMoveDB.SearchStockMove(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockMoveArrList);
                            }
                            break;
                        // 在庫受払履歴データ
                        case "StockAcPayHistRF":
                            // 在庫受払履歴データ
                            ArrayList stockAcPayHistArrList = new ArrayList();
                            APStockAcPayHistDB _stockAcPayHistDB = new APStockAcPayHistDB();
							status = _stockAcPayHistDB.SearchStockAcPayHist(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockAcPayHistArrList, out retMessage);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retCSAList.Add(stockAcPayHistArrList);
                            }
                            break;
                    }
                }
                return status;
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
		*/
        // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
        /// データ送信のデータ検索処理
        /// </summary>
		/// <param name="retCSAList">検索結果</param>
		/// <param name="paraSendDataWork">送信データ</param>
		/// <param name="sectionCode">sectionCode</param>
        /// <param name="fileIds">ファイルID配列</param>
        /// <param name="retMessage">エラーメッセージ</param>
		/// <param name="sndRcvHisConsNo">sndRcvHisConsNo</param>
		/// <param name="updSectionCd">updSectionCd</param>
        /// <returns>STATUS</returns>
		public int SearchCustomSerializeArrayListSCM(out CustomSerializeArrayList retCSAList, APSendDataWork paraSendDataWork,
			string sectionCode, string[] fileIds, out string retMessage, out int sndRcvHisConsNo, string updSectionCd)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retCSAList = new CustomSerializeArrayList();
            retMessage = string.Empty;
			sndRcvHisConsNo = -1; 

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

#if DEBUG
                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

				ArrayList resultList = new ArrayList();
				ArrayList saleAcpOdrList = new ArrayList();
				ArrayList stockAcpOdrList = new ArrayList();

                foreach (string fileId in fileIds)
                {
                    switch (fileId)
                    {
						case "SalesSlipRF":
							{
								// 売上データ、売上明細データ、受注マスタ、受注マスタ（車両）
								APSalesSlipDB _salesSlipDB = new APSalesSlipDB();
								paraSendDataWork.DoSalesSlipFlg = true;
								paraSendDataWork.DoStockDetailFlg = true;
								paraSendDataWork.DoAcceptOdrFlg = true;
								paraSendDataWork.DoAcceptOdrCarFlg = true;

								status = _salesSlipDB.SearchSCM(out resultList,out saleAcpOdrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
								if (resultList != null && resultList.Count > 0)
								{
									for (int i = 0; i < resultList.Count; i++)
									{
										(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
									}
								}
							}
							break;
                        case "SalesHistoryRF":
							// 売上履歴データ、売上履歴明細データ
                            APSalesHistoryDB _salesHistoryDB = new APSalesHistoryDB();
							paraSendDataWork.DoSalesHistoryFlg = true;
							paraSendDataWork.DoSalesHistDtlFlg = true;
							status = _salesHistoryDB.SearchSCM(out resultList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
                            break;

                        case "DepsitMainRF":
							// 入金データ、入金明細データ
                            APDepsitMainDB _depsitMainDB = new APDepsitMainDB();
							paraSendDataWork.DoDepsitMainFlg = true;
							paraSendDataWork.DoDepsitDtlFlg = true;
							status = _depsitMainDB.SearchSCM(out resultList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
                            break;

                        case "StockSlipRF":
							// 仕入データ、仕入明細データ,受注マスタ
                            APStockSlipDB _stockSlipDB = new APStockSlipDB();
							paraSendDataWork.DoStockSlipFlg = true;
							paraSendDataWork.DoStockDetailFlg = true;
							paraSendDataWork.DoAcceptOdrFlg = true;
							//ArrayList newStockDtlList = new ArrayList();// DEL 2011/09/15
							//status = _stockSlipDB.SearchSCM(out resultList,out newStockDtlList, out stockAcpOdrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);// DEL 2011/09/15
							status = _stockSlipDB.SearchSCM(out resultList, out stockAcpOdrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);// ADD 2011/09/15
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
							// DEL 2011/09/15 ----------- >>>>>
							//// ADD 2011.09.08 ----------- >>>>>
							//// 仕入明細のみの場合
							//ArrayList onlyStockDtlList = new ArrayList();
							//APStockDetailDB aPSalesHistDtlDB = new APStockDetailDB();
							//string retMsg = string.Empty;
							//status = aPSalesHistDtlDB.SearchStockDetail(paraSendDataWork.PmSectionCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out onlyStockDtlList, out retMsg);
							//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							//{
							//    if (onlyStockDtlList != null && onlyStockDtlList.Count > 0)
							//    {
							//        foreach (APStockDetailWork tmpWork in onlyStockDtlList)
							//        {
							//            newStockDtlList.Add(tmpWork);
							//        }
							//    }
							//}
							//(retCSAList as CustomSerializeArrayList).Add(newStockDtlList);
							//// ADD 2011.09.08 ----------- <<<<<
							// DEL 2011/09/15 ----------- <<<<<
                            break;

                        case "StockSlipHistRF":
							// 仕入履歴データ、仕入履歴明細データ
                            APStockSlipHistDB _stockSlipHistDB = new APStockSlipHistDB();
							paraSendDataWork.DoStockSlipHistFlg = true;
							paraSendDataWork.DoStockSlHistDtlFlg = true;
							status = _stockSlipHistDB.SearchSCM(out resultList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
                            break;
                        case "PaymentSlpRF":
							// 支払伝票マスタ,、支払明細データ
                            APPaymentSlpDB _paymentSlpDB = new APPaymentSlpDB();
							paraSendDataWork.DoPaymentSlpFlg = true;
							paraSendDataWork.DoPaymentDtlFlg = true;
							status = _paymentSlpDB.SearchSCM(out resultList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
							if (resultList != null && resultList.Count > 0)
							{
								for (int i = 0; i < resultList.Count; i++)
								{
									(retCSAList as CustomSerializeArrayList).Add(resultList[i]);
								}
							}
                            break;

                        // ----- DEL 2011/11/01 xupz------->>>>>>
                        //// 在庫調整データ
                        //case "StockAdjustRF":
                        //    // 在庫調整データ
                        //    ArrayList stockAdjustArrList = new ArrayList();
                        //    APStockAdjustDB _stockAdjustDB = new APStockAdjustDB();
                        //    status = _stockAdjustDB.SearchStockAdjustSCM(paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage, paraSendDataWork.PmSectionCode);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        (retCSAList as CustomSerializeArrayList).Add(stockAdjustArrList);
                        //    }
                        //    break;
                        // ----- DEL 2011/11/01 xupz-------<<<<<<

                        // ----- ADD 2011/11/01 xupz------->>>>>>
                        // 在庫調整データ
                        case "StockAdjustRF":
                            // 在庫調整データ
                            ArrayList stockAdjustArrList = new ArrayList();
                            APStockAdjustDB _stockAdjustDB = new APStockAdjustDB();
                            //status = _stockAdjustDB.SearchStockAdjustSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage, paraSendDataWork.PmSectionCode);  // DEL 2011/11/30
                            //status = _stockAdjustDB.SearchStockAdjustSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/11/30 // DEL 2011/11/06
                            status = _stockAdjustDB.SearchStockAdjustSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, paraSendDataWork.EndDateTimeTicks, sqlConnection, sqlTransaction, out stockAdjustArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/12/06
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
								(retCSAList as CustomSerializeArrayList).Add(stockAdjustArrList);
                            }
                            break;
                        // ----- ADD 2011/11/01 xupz-------<<<<<<

                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        // 在庫調整明細データ
                        //case "StockAdjustDtlRF":
                        //    // 在庫調整明細データ
                        //    ArrayList stockAdjustDtlArrList = new ArrayList();
                        //    APStockAdjustDtlDB _stockAdjustDtlDB = new APStockAdjustDtlDB();
                        //    status = _stockAdjustDtlDB.SearchStockAdjustDtlSCM(paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage, paraSendDataWork.PmSectionCode);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        (retCSAList as CustomSerializeArrayList).Add(stockAdjustDtlArrList);
                        //    }
                        //    break;
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz------->>>>>>
                        // 在庫調整明細データ
                        case "StockAdjustDtlRF":
                            // 在庫調整明細データ
                            ArrayList stockAdjustDtlArrList = new ArrayList();
							APStockAdjustDtlDB _stockAdjustDtlDB = new APStockAdjustDtlDB();
                            //status = _stockAdjustDtlDB.SearchStockAdjustDtlSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage, paraSendDataWork.PmSectionCode);  // DEL 2011/11/30
                            //status = _stockAdjustDtlDB.SearchStockAdjustDtlSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/11/30 // DEL 2011/12/06
                            status = _stockAdjustDtlDB.SearchStockAdjustDtlSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, paraSendDataWork.EndDateTimeTicks, sqlConnection, sqlTransaction, out stockAdjustDtlArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/12/06
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                (retCSAList as CustomSerializeArrayList).Add(stockAdjustDtlArrList);
                            }
                            break;
                        // ----- ADD 2011/11/01 xupz-------<<<<<<

                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //// 在庫移動データ
                        //case "StockMoveRF":
                        //    // 在庫移動データ
                        //    ArrayList stockMoveArrList = new ArrayList();
                        //    APStockMoveDB _stockMoveDB = new APStockMoveDB();
                        //    status = _stockMoveDB.SearchStockMoveSCM(paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage, paraSendDataWork.PmSectionCode);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        (retCSAList as CustomSerializeArrayList).Add(stockMoveArrList);
                        //    }
                        //    break;
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz------->>>>>>
                        // 在庫移動データ
                        case "StockMoveRF":
                            // 在庫移動データ
                            ArrayList stockMoveArrList = new ArrayList();
                            APStockMoveDB _stockMoveDB = new APStockMoveDB();
                            //status = _stockMoveDB.SearchStockMoveSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage, paraSendDataWork.PmSectionCode);  // DEL 2011/11/30
                            //status = _stockMoveDB.SearchStockMoveSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/11/30 // DEL 2011/12/06
                            status = _stockMoveDB.SearchStockMoveSCM(paraSendDataWork.SndMesExtraCondDiv, paraSendDataWork.PmEnterpriseCode, paraSendDataWork.StartDateTime, paraSendDataWork.EndDateTime, paraSendDataWork.SyncExecDate, paraSendDataWork.EndDateTimeTicks, sqlConnection, sqlTransaction, out stockMoveArrList, out retMessage, paraSendDataWork.PmSectionCode);  // ADD 2011/12/06
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                (retCSAList as CustomSerializeArrayList).Add(stockMoveArrList);
                            }
                            break;					
                        // ----- ADD 2011/11/01 xupz-------<<<<<<

						case "DepositAlwRF":
							{
								// 入金引当マスタ
								ArrayList depositAlwArrList = new ArrayList();
								APDepositAlwDB _depositAlwDB = new APDepositAlwDB();
								status = _depositAlwDB.Search(out depositAlwArrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									(retCSAList as CustomSerializeArrayList).Add(depositAlwArrList);
								}
							}
							break;
						case "RcvDraftDataRF":
							{
								// 受取手形データ
								ArrayList rcvDraftDataArrList = new ArrayList();
								APRcvDraftDataDB _rcvDraftDataDB = new APRcvDraftDataDB();
								status = _rcvDraftDataDB.Search(out rcvDraftDataArrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									(retCSAList as CustomSerializeArrayList).Add(rcvDraftDataArrList);
								}
							}
							break;
						case "PayDraftDataRF":
							{
								// 支払手形データ
								ArrayList payDraftDataArrList = new ArrayList();
								APPayDraftDataDB _payDraftDataDB = new APPayDraftDataDB();
								status = _payDraftDataDB.Search(out payDraftDataArrList, paraSendDataWork, ref sqlConnection, ref sqlTransaction);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									(retCSAList as CustomSerializeArrayList).Add(payDraftDataArrList);
								}
							}
							break;

						default:
							break;

                    }
                }

				if(paraSendDataWork.DoAcceptOdrFlg)
				{
					for (int cnt = 0; cnt < stockAcpOdrList.Count; cnt++)
					{
						saleAcpOdrList.Add(stockAcpOdrList[cnt]);
					}

					(retCSAList as CustomSerializeArrayList).Add(saleAcpOdrList);
				}

                //if (retCSAList.Count > 0) // DEL 2013/02/07 zhlj For Redmine#34588
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
                // 送信番号を生成する場合(SndNoCreateDiv==0)
                if (retCSAList.Count > 0 && paraSendDataWork.SndNoCreateDiv == 0)
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
                {
                    //送受信履歴ログ送信番号
                    long no = -1;
                    NumberingManager numberingManager = new NumberingManager();
                    SerialNumberCode serialnumcd = SerialNumberCode.SndRcvHisConsNo;
                    status = numberingManager.GetSerialNumber(paraSendDataWork.PmEnterpriseCode, updSectionCd.Trim(), serialnumcd, out no);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && no != -1)
                    {
                        sndRcvHisConsNo = (int)no;
                    }
                }

                return status;
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
		// ADD 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<


        #endregion ◆ データ送信のデータ検索処理 ◆

        #region ◆ データ送信のデータ更新処理 ◆
        /// <summary>
        /// データ送信のデータ更新処理
        /// </summary>
        /// <param name="enterPriseCode">検索結果</param>
        /// <param name="receiveList">検索条件</param>
        /// <param name="sectionCodeList">拠点リスト</param>
        /// <param name="stockAcPayHistCount">数量</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信のデータ更新処理</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        public int UpdateCustomSerializeArrayList(string enterPriseCode, object receiveList, ArrayList sectionCodeList, ref int stockAcPayHistCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
			SqlCommand sqlCommand = null;// ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）

            ArrayList _salesSlipList = new ArrayList();                       // 売上データ
            ArrayList _salesDetailList = new ArrayList();                     // 売上明細データ
            ArrayList _salesHistoryList = new ArrayList();                    // 売上履歴データ
            ArrayList _salesHistDtlList = new ArrayList();                    // 売上履歴明細データ
            ArrayList _depsitMainList = new ArrayList();                      // 入金データ
            ArrayList _depsitDtlList = new ArrayList();                       // 入金明細データ
            ArrayList _stockSlipList = new ArrayList();                       // 仕入データ
            ArrayList _stockDetailList = new ArrayList();                     // 仕入明細データ
            ArrayList _stockSlipHistList = new ArrayList();                   // 仕入履歴データ
            ArrayList _stockSlHistDtlList = new ArrayList();                  // 仕入履歴明細データ
            ArrayList _paymentSlpList = new ArrayList();                      // 支払伝票マスタ
            ArrayList _paymentDtlList = new ArrayList();                      // 支払明細データ
            ArrayList _acceptOdrList = new ArrayList();                       // 受注マスタ
            ArrayList _acceptOdrCarList = new ArrayList();                    // 受注マスタ（車両）
            ArrayList _mTtlSalesSlipList = new ArrayList();                   // 売上月次集計データ
            ArrayList _goodsMTtlSaSlipList = new ArrayList();                 // 商品別売上月次集計データ
            ArrayList _mTtlStockSlipList = new ArrayList();                   // 仕入月次集計データ
            // ↓ 2009.04.29 liuyang add
            ArrayList _stockAdjustList = new ArrayList();                     // 在庫調整データ
            ArrayList _stockAdjustDtlList = new ArrayList();                  // 在庫調整明細データ
            ArrayList _stockMoveList = new ArrayList();                       // 在庫移動データ
            ArrayList _stockAcPayHistList = new ArrayList();                  // 在庫受払履歴データ
            // ↑ 2009.04.29 liuyang add
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			ArrayList _depositAlwList = new ArrayList();                      // 入金引当マスタ
			ArrayList _rcvDraftDataList = new ArrayList();                    // 受取手形データ
			ArrayList _payDraftDataList = new ArrayList();                    // 支払手形データデータ
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

            CustomSerializeArrayList outreceiveList = (CustomSerializeArrayList)receiveList;

            // 変更処理
            for (int i = 0; i < outreceiveList.Count; i++)
            {
                if (outreceiveList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)outreceiveList[i];

                    if (list.Count == 0) continue;

                    if (list[0] is APSalesSlipWork)
                    {
                        // 売上データ
                        _salesSlipList.AddRange(list);
                    }
                    else if (list[0] is APSalesDetailWork)
                    {
                        // 売上明細データ
                        _salesDetailList.AddRange(list);
                    }
                    else if (list[0] is APSalesHistoryWork)
                    {
                        // 売上履歴データ
                        _salesHistoryList.AddRange(list);
                    }
                    else if (list[0] is APSalesHistDtlWork)
                    {
                        // 売上履歴明細データ
                        _salesHistDtlList.AddRange(list);
                    }
                    else if (list[0] is APDepsitMainWork)
                    {
                        // 入金データ
                        _depsitMainList.AddRange(list);
                    }
                    else if (list[0] is APDepsitDtlWork)
                    {
                        // 入金明細データ
                        _depsitDtlList.AddRange(list);
                    }
                    else if (list[0] is APStockSlipWork)
                    {
                        // 仕入データ
                        _stockSlipList.AddRange(list);
                    }
                    else if (list[0] is APStockDetailWork)
                    {
                        // 仕入明細データ
                        _stockDetailList.AddRange(list);
                    }
                    else if (list[0] is APStockSlipHistWork)
                    {
                        // 仕入履歴データ
                        _stockSlipHistList.AddRange(list);
                    }
                    else if (list[0] is APStockSlHistDtlWork)
                    {
                        // 仕入履歴明細データ
                        _stockSlHistDtlList.AddRange(list);
                    }
                    else if (list[0] is APPaymentSlpWork)
                    {
                        // 支払伝票マスタ
                        _paymentSlpList.AddRange(list);
                    }
                    else if (list[0] is APPaymentDtlWork)
                    {
                        // 支払明細データ
                        _paymentDtlList.AddRange(list);
                    }
                    else if (list[0] is APAcceptOdrWork)
                    {
                        // 受注マスタ
                        _acceptOdrList.AddRange(list);
                    }
                    else if (list[0] is APAcceptOdrCarWork)
                    {
                        // 受注マスタ（車両）
                        _acceptOdrCarList.AddRange(list);
                    }
                    else if (list[0] is APMTtlSalesSlipWork)
                    {
                        // 売上月次別伝票データ
                        _mTtlSalesSlipList.AddRange(list);
                    }
                    else if (list[0] is APGoodsMTtlSaSlipWork)
                    {
                        // 商品月次別伝票データ
                        _goodsMTtlSaSlipList.AddRange(list);
                    }
                    else if (list[0] is APMTtlStockSlipWork)
                    {
                        // 仕入月次別伝票データ
                        _mTtlStockSlipList.AddRange(list);
                    }
                    // ↓ 2009.04.29 liuyang add
                    else if (list[0] is APStockAdjustWork)
                    {
                        // 在庫調整データ
                        _stockAdjustList.AddRange(list);
                    }
                    else if (list[0] is APStockAdjustDtlWork)
                    {
                        // 在庫調整明細データ
                        _stockAdjustDtlList.AddRange(list);
                    }
                    else if (list[0] is APStockMoveWork)
                    {
                        // 在庫移動データ
                        _stockMoveList.AddRange(list);
                    }
                    else if (list[0] is APStockAcPayHistWork)
                    {
                        // 在庫受払履歴データ
                        _stockAcPayHistList.AddRange(list);
                    }
                    // ↑ 2009.04.29 liuyang add

					//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
					else if (list[0] is APDepositAlwWork)
					{
						// 入金引当マスタ
						_depositAlwList.AddRange(list);
					}
					else if (list[0] is APRcvDraftDataWork)
					{
						// 受取手形マスタ
						_rcvDraftDataList.AddRange(list);
					}
					else if (list[0] is APPayDraftDataWork)
					{
						// 支払手形マスタ
						_payDraftDataList.AddRange(list);
					}

					//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

                }
            }

            string resNm = "";
#if !DEBUG
            ShareCheckInfo shareCheckInfo = null;
            IntentExclusiveLockComponent intentLockObj = null;
#endif

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);
                sqlTransaction = this.CreateTransactionData(ref sqlConnection);

                // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
                // 拠点管理送受信対象マスタ情報を取得
                SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();
                secMngSndRcvWork.EnterpriseCode = enterPriseCode;
                object outSecMngSndRcvList = null;
                status = this.ScMngSndRcvDB.Search(out outSecMngSndRcvList, secMngSndRcvWork, 0, ConstantManagement.LogicalMode.GetData0);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;

                int salesSlipRecvDiv = -1; // 売上データ受信区分
                int stockMoveRecvDiv = -1; // 在庫移動データ受信区分
                int stockAdjustRecvDiv = -1; // 在庫調整データ受信区分
                int stockSlipRecvDiv = -1; // 仕入データ受信区分

                ArrayList secMngSndRcvList = outSecMngSndRcvList as ArrayList;
                foreach (SecMngSndRcvWork resultSecMngSndRcvWork in secMngSndRcvList)
                {
                    // 受信区分を取得
                    if (string.Equals("SalesSlipRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase))
                        salesSlipRecvDiv = resultSecMngSndRcvWork.SecMngRecvDiv;
                    else if (string.Equals("StockSlipRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase))
                        stockSlipRecvDiv = resultSecMngSndRcvWork.SecMngRecvDiv;
                    else if (string.Equals("StockMoveRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase))
                        stockMoveRecvDiv = resultSecMngSndRcvWork.SecMngRecvDiv;
                    else if (string.Equals("StockAdjustRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase))
                        stockAdjustRecvDiv = resultSecMngSndRcvWork.SecMngRecvDiv;
                    else
                        continue;
                }
                secMngSndRcvList.Clear(); // メモリをリリース
                secMngSndRcvList = null;

#if !DEBUG
                // シェアチェックを行う
                ArrayList paramShareCheckList = new ArrayList();
                paramShareCheckList.AddRange(_salesDetailList);   // 売上明細データ
                paramShareCheckList.AddRange(_stockDetailList);   // 仕入明細データ
                if (stockAdjustRecvDiv == 2)
                    // 在庫更新ありの場合
                    paramShareCheckList.AddRange(_stockAdjustDtlList);// 在庫調整明細データ
                // 売上、仕入、在庫調整のチェックインフォを作成
                this.ShareCheckInitialize(paramShareCheckList, ref shareCheckInfo, (salesSlipRecvDiv == 2), (stockSlipRecvDiv == 2));
                //if (1 == stockMoveRecvDiv)//DEL 2011/08/25 #25443
                if (2 == stockMoveRecvDiv)//ADD 2011/08/25 #25443
                    // 在庫移動のチェックインフォを作成
                    this.ShareCheckInitForStockMove(_stockMoveList, ref shareCheckInfo);

                paramShareCheckList.Clear(); // メモリをリリース
                paramShareCheckList = null;
                if (shareCheckInfo != null && shareCheckInfo.Keys != null && shareCheckInfo.Keys.Count > 0)
                {
                    status = this.ShareCheck(shareCheckInfo, LockControl.Locke, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;
                }
#endif
                // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

                resNm = GetResourceName(enterPriseCode);

                if (resNm != "")
                {
                    //ＡＰロック
                    // ↓ 2009.07.06 劉洋 modify
                    status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                    // ↑ 2009.07.06 劉洋 modify
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                }

                // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
#if !DEBUG
                // インテントロックを行う
                intentLockObj = new IntentExclusiveLockComponent(); // ロック部品をインスタンス
                // インテントロック対象を設定
                string[] targetTables = new string[]{"SALESSLIPRF", "ACCEPTODRCARRF", "SALESDETAILRF", "SALESHISTORYRF"       // 売上データ、受注マスタ（車両）、売上明細データ、売上履歴データ
                                    ,"SALESHISTDTLRF","STOCKSLIPRF", "STOCKDETAILRF","STOCKSLIPHISTRF"                        // 売上履歴明細データ、仕入データ、仕入明細データ、仕入履歴データ
                                    ,"STOCKSLHISTDTLRF", "STOCKADJUSTRF", "STOCKADJUSTDTLRF", "STOCKMOVERF", "ACCEPTODRRF"};  // 仕入履歴明細データ、在庫調整データ、在庫調整明細データ、在庫移動データ、受注マスタ
                status = intentLockObj.IntentLock(targetTables);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;
#endif

                // 実績系データの集計と更新処理を行い------------------------------------------------------------>

                // 受信仕入データ集計リモートオブジェクトをコール
                if (stockSlipRecvDiv > 0)
                {
                    // 仕入受信の場合
                    status = new APTotalizeStockSlip().TotalizeReceivedStockSlip(enterPriseCode, _stockSlipList, _stockDetailList, stockSlipRecvDiv, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        return status;
                }
				
				// 受信在庫調整データ集計リモートオブジェクトをコール
				string retMsg = string.Empty;
				if (2 == stockAdjustRecvDiv)
				{
					// 在庫更新あり
					status = new APTotalizeStockAdjustDB().TotalizeStokAdjust(enterPriseCode, _stockAdjustList, _stockAdjustDtlList, sqlConnection, sqlTransaction, out retMsg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
						return status;
				}
                
				// 受信在庫移動データ集計リモートオブジェクトをコール
                //if (1 == stockMoveRecvDiv)//DEL 2011/08/25 #23998　在庫移動データの受信区分変更
                if (2 == stockMoveRecvDiv)//ADD 2011/08/25 #23998　在庫移動データの受信区分変更
				{
					// 在庫更新あり
					status = new APTotalizeStockMoveDB().TotalizeStokMove(enterPriseCode, _stockMoveList, sqlConnection, sqlTransaction, out retMsg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
						return status;
				}				

                // 受信売上データ集計リモートオブジェクトをコール
                if (salesSlipRecvDiv > 0)
                {
                    // 売上受信の場合
                    status = new APTotalizeSalesSlip().TotalizeReceivedSalesSlip(enterPriseCode, _salesSlipList, _salesDetailList, salesSlipRecvDiv, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        return status;
                }

                // 実績系データの集計と更新処理を行い------------------------------------------------------------<
                // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

                // データ更新処理
                if (_salesSlipList != null && _salesSlipList.Count > 0)
                {
                    // 売上データ更新
                    APSalesSlipDB _salesSlipDB = new APSalesSlipDB();
                    status = _salesSlipDB.UpdateSalesSlip(enterPriseCode, _salesSlipList, ref sqlConnection, ref sqlTransaction);
                }
                // 売上明細データ更新
                if (_salesDetailList != null && _salesDetailList.Count > 0)
                {
                    APSalesDetailDB _salesDetailDB = new APSalesDetailDB();
                    status = _salesDetailDB.UpdateSalesDetail(enterPriseCode, _salesDetailList, ref sqlConnection, ref sqlTransaction);
                }
                // 売上履歴データ
                if (_salesHistoryList != null && _salesHistoryList.Count > 0)
                {
                    APSalesHistoryDB _salesHistoryDB = new APSalesHistoryDB();
                    status = _salesHistoryDB.UpdateSalesHistory(enterPriseCode, _salesHistoryList, ref sqlConnection, ref sqlTransaction);
                }
                // 売上履歴明細データ
                if (_salesHistDtlList != null && _salesHistDtlList.Count > 0)
                {
                    APSalesHistDtlDB _salesHistDtlDB = new APSalesHistDtlDB();
                    status = _salesHistDtlDB.UpdateSalesHistDtl(enterPriseCode, _salesHistDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // 入金データ
                if (_depsitMainList != null && _depsitMainList.Count > 0)
                {
                    APDepsitMainDB _depsitMainDB = new APDepsitMainDB();
                    status = _depsitMainDB.UpdateDepsitMain(enterPriseCode, _depsitMainList, ref sqlConnection, ref sqlTransaction);
                }
                // 入金明細データ
                if (_depsitDtlList != null && _depsitDtlList.Count > 0)
                {
                    APDepsitDtlDB _depsitDtlDB = new APDepsitDtlDB();
                    status = _depsitDtlDB.UpdateDepsitDtl(enterPriseCode, _depsitDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // 仕入データ
                if (_stockSlipList != null && _stockSlipList.Count > 0)
                {
                    APStockSlipDB _stockSlipDB = new APStockSlipDB();
                    status = _stockSlipDB.UpdateStockSlip(enterPriseCode, _stockSlipList, ref sqlConnection, ref sqlTransaction);
                }
                // 仕入明細データ
                if (_stockDetailList != null && _stockDetailList.Count > 0)
                {
                    APStockDetailDB _stockDetailDB = new APStockDetailDB();
                    status = _stockDetailDB.UpdateStockDetail(enterPriseCode, _stockDetailList, ref sqlConnection, ref sqlTransaction);
                }
                // 仕入履歴データ
                if (_stockSlipHistList != null && _stockSlipHistList.Count > 0)
                {
                    APStockSlipHistDB _stockSlipHistDB = new APStockSlipHistDB();
                    status = _stockSlipHistDB.UpdateStockSlipHist(enterPriseCode, _stockSlipHistList, ref sqlConnection, ref sqlTransaction);
                }
                // 仕入履歴明細データ
                if (_stockSlHistDtlList != null && _stockSlHistDtlList.Count > 0)
                {
                    APStockSlHistDtlDB _stockSlHistDtlDB = new APStockSlHistDtlDB();
                    status = _stockSlHistDtlDB.UpdateStockSlHistDtl(enterPriseCode, _stockSlHistDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // 支払伝票マスタ
                if (_paymentSlpList != null && _paymentSlpList.Count > 0)
                {
                    APPaymentSlpDB _paymentSlpDB = new APPaymentSlpDB();
                    status = _paymentSlpDB.UpdatePayementSlp(enterPriseCode, _paymentSlpList, ref sqlConnection, ref sqlTransaction);
                }
                // 支払明細データ
                if (_paymentDtlList != null && _paymentDtlList.Count > 0)
                {
                    APPaymentDtlDB _paymentDtlDB = new APPaymentDtlDB();
                    status = _paymentDtlDB.UpdatePayementDtl(enterPriseCode, _paymentDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // 受注マスタ
                if (_acceptOdrList != null && _acceptOdrList.Count > 0)
                {
                    APAcceptOdrDB _acceptOdrDB = new APAcceptOdrDB();
                    status = _acceptOdrDB.UpdateAcceptOdr(enterPriseCode, _acceptOdrList, ref sqlConnection, ref sqlTransaction);
                }
                // 受注マスタ（車両）
                if (_acceptOdrCarList != null && _acceptOdrCarList.Count > 0)
                {
                    APAcceptOdrCarDB _acceptOdrCarDB = new APAcceptOdrCarDB();
                    status = _acceptOdrCarDB.UpdateAcceptOdrCar(enterPriseCode, _acceptOdrCarList, ref sqlConnection, ref sqlTransaction);
                }
                #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
                // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
                /*
                // 売上月次別伝票データ
                if (_mTtlSalesSlipList != null && _mTtlSalesSlipList.Count > 0)
                {
                    APMTtlSalesSlipDB _mTtlSalesSlipDB = new APMTtlSalesSlipDB();
                    status = _mTtlSalesSlipDB.UpdateMTtlSalesSlip(enterPriseCode, _mTtlSalesSlipList, ref sqlConnection, ref sqlTransaction);
                }
                // 商品月次別伝票データ
                if (_goodsMTtlSaSlipList != null && _goodsMTtlSaSlipList.Count > 0)
                {
                    APGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = new APGoodsMTtlSaSlipDB();
                    status = _goodsMTtlSaSlipDB.UpdateGoodsMTtlSaSlip(enterPriseCode, _goodsMTtlSaSlipList, ref sqlConnection, ref sqlTransaction);
                }
                // 仕入月次別伝票データ
                if (_mTtlStockSlipList != null && _mTtlStockSlipList.Count > 0)
                {
                    APMTtlStockSlipDB _mTtlStockSlipDB = new APMTtlStockSlipDB();
                    status = _mTtlStockSlipDB.UpdateMTtlStockSlip(enterPriseCode, _mTtlStockSlipList, ref sqlConnection, ref sqlTransaction);
                }
				 */
                // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                #endregion [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]

                // ↓ 2009.04.29 liuyang add
                // 在庫調整データ
                if (_stockAdjustList != null && _stockAdjustList.Count > 0)
                {
                    APStockAdjustDB _stockAdjustDB = new APStockAdjustDB();
                    status = _stockAdjustDB.UpdateStockAdjust(enterPriseCode, _stockAdjustList, ref sqlConnection, ref sqlTransaction);
                }
                // 在庫調整明細データ
                if (_stockAdjustDtlList != null && _stockAdjustDtlList.Count > 0)
                {
                    APStockAdjustDtlDB _stockAdjustDtlDB = new APStockAdjustDtlDB();
                    status = _stockAdjustDtlDB.UpdateStockAdjustDtl(enterPriseCode, _stockAdjustDtlList, ref sqlConnection, ref sqlTransaction);
                }
                // 在庫移動データ
                if (_stockMoveList != null && _stockMoveList.Count > 0)
                {
                    APStockMoveDB _stockMoveDB = new APStockMoveDB();
                    status = _stockMoveDB.UpdateStockMove(enterPriseCode, _stockMoveList, ref sqlConnection, ref sqlTransaction);
                }
                #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
                // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
                /*
                // 在庫受払履歴データ
                if (_stockAcPayHistList != null && _stockAcPayHistList.Count > 0)
                {
                    // 対象外情報を判断する
                    ArrayList result = new ArrayList();
                    foreach (APStockAcPayHistWork stockAcPayHistWork in _stockAcPayHistList)
                    {
                        // 受払元伝票区分が30:移動出荷,31:移動入荷の場合
                        if (stockAcPayHistWork.AcPaySlipCd == 30 || stockAcPayHistWork.AcPaySlipCd == 31)
                        {
                            // 拠点存在判断
                            if (!ExistSectionCode(stockAcPayHistWork.BfSectionCode, sectionCodeList)
                                || !ExistSectionCode(stockAcPayHistWork.AfSectionCode, sectionCodeList))
                            {
                                // 在庫マスタ検索
                                APStockWork apStockWork = null;
                                int statusStock = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                statusStock = SearchStock(enterPriseCode, stockAcPayHistWork, out apStockWork, ref sqlConnection, ref sqlTransaction);
                                // 在庫マスタ登録しない場合
                                if (statusStock == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    result.Add(stockAcPayHistWork);
                                }
                            }
                            else
                            {
                                result.Add(stockAcPayHistWork);
                            }
                        }
                        else
                        {
                            result.Add(stockAcPayHistWork);
                        }
                    }

                    stockAcPayHistCount = result.Count;

                    APStockAcPayHistDB _stockAcPayHistDB = new APStockAcPayHistDB();
                    status = _stockAcPayHistDB.UpdateStockAcPayHist(enterPriseCode, result, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    stockAcPayHistCount = 0;
                }
                // ↑ 2009.04.29 liuyang add
				*/
                // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                #endregion [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]

                //-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				// 入金引当マスタ
				if (_depositAlwList != null && _depositAlwList.Count > 0)
				{
					APDepositAlwDB _depositAlwDB = new APDepositAlwDB();
					_depositAlwDB.Delete(_depositAlwList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
					_depositAlwDB.Insert(_depositAlwList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
				}
				// 受取手形マスタ
				if (_rcvDraftDataList != null && _rcvDraftDataList.Count > 0)
				{
					APRcvDraftDataDB _rcvDraftDataDB = new APRcvDraftDataDB();
					_rcvDraftDataDB.Delete(_rcvDraftDataList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
					_rcvDraftDataDB.Insert(_rcvDraftDataList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
				}
				// 支払手形マスタ
				if (_payDraftDataList != null && _payDraftDataList.Count > 0)
				{
					APPayDraftDataDB _payDraftDataDB = new APPayDraftDataDB();
					_payDraftDataDB.Delete(_payDraftDataList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
					_payDraftDataDB.Insert(_payDraftDataList, ref sqlConnection, ref sqlTransaction, ref sqlCommand, enterPriseCode);
				}
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "ExtraAndUpdControlDB.UpdateCustomSerializeArrayList(outreceiveList)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ExtraAndUpdControlDB.UpdateCustomSerializeArrayList(outreceiveList)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
#if !DEBUG
                if (null != intentLockObj) 
                {
                    // インテントロック解除
                    intentLockObj.UnLock();
                }
#endif
                // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

                if (resNm != "")
                {
                    // ↓ 2009.07.06 劉洋 modify
                    //ＡＰアンロック
                    int status2 = Release(resNm, sqlConnection, sqlTransaction);

                    if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    // ↑ 2009.07.06 劉洋 modify
                }

                // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
#if !DEBUG
                if (shareCheckInfo != null && shareCheckInfo.Keys != null && shareCheckInfo.Keys.Count > 0)
                    this.ShareCheck(shareCheckInfo, LockControl.Release, sqlConnection, sqlTransaction);
#endif
                // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				if (sqlCommand != null)
				{
					sqlCommand.Cancel();
					sqlCommand.Dispose();
				}
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
            }

            return status;
        }

        /// <summary>
        /// 拠点情報存在性チェック
        /// </summary>
        /// <param name="code">拠点コード</param>
        /// <param name="sectionCodeList">拠点リスト</param>
        /// <returns></returns>
        private bool ExistSectionCode(string code, ArrayList sectionCodeList)
        {
            bool isExist = false;

            for (int i = 0; i < sectionCodeList.Count; i++)
            {
                if (code.Equals((string)sectionCodeList[i]))
                {
                    isExist = true;
                    break;
                }
            }

            return isExist;
        }

        /// <summary>
        /// 在庫マスタ検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="stockAcPayHistWork">在庫受払履歴データ</param>
        /// <param name="stockWork">在庫マスタ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>ステータス</returns>
        private int SearchStock(string enterpriseCode, APStockAcPayHistWork stockAcPayHistWork, out APStockWork stockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockWork = new APStockWork();

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = enterpriseCode;
            findParaLogicalDeleteCode.Value = Convert.ToInt32(0);
            findParaWarehouseCode.Value = stockAcPayHistWork.WarehouseCode;
            findParaGoodsMakerCd.Value = stockAcPayHistWork.GoodsMakerCd;
            findParaGoodsNo.Value = stockAcPayHistWork.GoodsNo;

            // SQL文
            sqlCommand.CommandText = sqlText;
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
			
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                stockWork.StockCreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                stockWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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

        #endregion ◆ データ送信のデータ更新処理 ◆

        #region [初期化検索]
        /// <summary>
        /// データを取得する
        /// </summary>
        /// <param name="enterpriseCodes">拠点コード</param>
        /// <param name="secMngSetWorkList">拠点マスタ</param>
        /// <param name="retMessage">メッセージ</param>
        /// <returns></returns>
        public int SearchSecMngSetData(string enterpriseCodes, out ArrayList secMngSetWorkList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;
            secMngSetWorkList = new ArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // Selectコマンドの生成
                sqlText = "SELECT SECMNGSETRF.SECTIONCODERF, SECMNGSETRF.SYNCEXECDATERF, SECINFOSETRF.SECTIONGUIDENMRF, SECMNGEPSETRF.PMENTERPRISECODERF, SECMNGSETRF.UPDEMPLOYEECODERF  FROM SECMNGSETRF WITH (READUNCOMMITTED), SECINFOSETRF WITH (READUNCOMMITTED), SECMNGEPSETRF WITH (READUNCOMMITTED) WHERE SECMNGSETRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND SECMNGSETRF.KINDRF=@FINDKINDRF AND SECMNGSETRF.RECEIVECONDITIONRF=@FINDRECEIVECONDITIONRF AND SECMNGSETRF.ENTERPRISECODERF = SECINFOSETRF.ENTERPRISECODERF AND SECMNGSETRF.SECTIONCODERF = SECINFOSETRF.SECTIONCODERF AND SECMNGSETRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECMNGSETRF.LOGICALDELETECODERF = SECINFOSETRF.LOGICALDELETECODERF AND SECMNGEPSETRF.LOGICALDELETECODERF = SECMNGSETRF.LOGICALDELETECODERF AND SECMNGEPSETRF.ENTERPRISECODERF = SECMNGSETRF.ENTERPRISECODERF AND SECMNGEPSETRF.SECTIONCODERF = SECMNGSETRF.SECTIONCODERF";

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);
                SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITIONRF", SqlDbType.Int);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                paraKind.Value = SqlDataMediator.SqlSetInt32(0);
                paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(1);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
				
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    APSecMngSetWork secMngSetWork = new APSecMngSetWork();

                    secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
                    secMngSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secMngSetWork.PmEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMENTERPRISECODERF"));
                    secMngSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));

                    secMngSetWorkList.Add(secMngSetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "ExtraAndUpdControlDB.Search Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "ExtraAndUpdControlDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        #endregion

        #region

        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngEpSetWorkList">拠点情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchSecMngEpSetData(string enterpriseCode, out ArrayList secMngEpSetWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secMngEpSetWorkList = new ArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // Selectコマンドの生成
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, PMENTERPRISECODERF FROM SECMNGEPSETRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterpriseCode;

                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
				
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    APSecMngEpSetWork secMngEpSetWork = new APSecMngEpSetWork();

                    secMngEpSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    secMngEpSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    secMngEpSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    secMngEpSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    secMngEpSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    secMngEpSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    secMngEpSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    secMngEpSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    secMngEpSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secMngEpSetWork.PmEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMENTERPRISECODERF"));

                    secMngEpSetWorkList.Add(secMngEpSetWork);
                }

                // ステータス
                if (secMngEpSetWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "ExtraAndUpdControlDB.Search Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "ExtraAndUpdControlDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }


        /// <summary>
        /// 拠点情報を更新します。
        /// </summary>
        /// <param name="secMngSetWork">拠点マスタ</param>
        /// <param name="newSyncExecDate">シック日時</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        public int UpdateSecMngSetData(APSecMngSetWork secMngSetWork, Int64 newSyncExecDate)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // Selectコマンドの生成
                sqlText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND SECTIONCODERF=@FINDSECTIONCODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";

                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定(更新用)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSetWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.UpdEmployeeCode);
                paraSyncExecDate.Value = newSyncExecDate;

                //Parameterオブジェクトの作成(検索用)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeteleCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定(検索用)
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.EnterpriseCode);
                findParaKind.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.Kind);
                findParaReceiveCondition.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.ReceiveCondition);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.SectionCode);
                findParaLogicalDeteleCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
				
                // 実行
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "ExtraAndUpdControlDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "ExtraAndUpdControlDB.Search Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        #endregion

        # region ◆ [コネクション生成処理] ◆
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlTransaction CreateTransactionData(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion ◆ [コネクション生成処理] ◆

		#region IAPSendMessageDB メンバ

		#endregion

        # region [シェアチェック処理]
        // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// シェアチェック情報を取得
        /// </summary>
        /// <param name="param">チェック対象リスト</param>
        /// <param name="info">シェアチェック情報</param>
        /// <param name="isWdUpdForSales">売上在庫更新ありか(true:あり)</param>
        /// <param name="isWdUpdForStock">仕入在庫更新ありか(true:あり)</param>
        private void ShareCheckInitialize(ArrayList param, ref ShareCheckInfo info, bool isWdUpdForSales, bool isWdUpdForStock)
        {
            if (info == null)
            {
                info = new ShareCheckInfo();
            }

            ShareCheckKey dummyKey = new ShareCheckKey();

            foreach (object item in param)
            {
                if (item is ArrayList)
                {
                    this.ShareCheckInitialize((item as ArrayList), ref info, isWdUpdForSales, isWdUpdForStock);
                    continue;
                }

                // 売上明細データ
                if (item is APSalesDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as APSalesDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as APSalesDetailWork).SectionCode;
                    // 見積の場合は、倉庫ロックをしないように修正
                    if ((item as APSalesDetailWork).AcptAnOdrStatus != 10 && isWdUpdForSales)
                    {
                        dummyKey.WarehouseCode = (item as APSalesDetailWork).WarehouseCode;
                    }
                }
                // 仕入明細データ
                else if (item is APStockDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as APStockDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as APStockDetailWork).SectionCode;
                    if (isWdUpdForStock)
                        dummyKey.WarehouseCode = (item as APStockDetailWork).WarehouseCode;
                }
                // 在庫調整明細データ
                else if (item is APStockAdjustDtlWork)
                {
                    // 在庫更新なしの場合、当該在庫調整明細データなし
                    dummyKey.EnterpriseCode = (item as APStockAdjustDtlWork).EnterpriseCode;
                    dummyKey.WarehouseCode = (item as APStockAdjustDtlWork).WarehouseCode;
                }
                else
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(dummyKey.SectionCode))
                {
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.Type == ShareCheckType.Section &&
                                                     key.SectionCode == dummyKey.SectionCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.Section, dummyKey.SectionCode, "");
                    }

                    dummyKey.SectionCode = string.Empty;
                }
                if (!string.IsNullOrEmpty(dummyKey.WarehouseCode))
                {
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }

                    dummyKey.WarehouseCode = string.Empty;
                }
            }

        }

        /// <summary>
        /// 在庫移動のシェアチェック情報を取得
        /// </summary>
        /// <param name="stockMoveList">在庫移動データリスト</param>
        /// <param name="info">シェアチェック情報</param>
        private void ShareCheckInitForStockMove(ArrayList stockMoveList, ref ShareCheckInfo info)
        {
            if (info == null)
            {
                info = new ShareCheckInfo();
            }
            ShareCheckKey dummyKey = new ShareCheckKey();

            foreach (object item in stockMoveList)
            {
                // 在庫移動データ
                if (item is APStockMoveWork)
                {
                    // 在庫移動データの移動元倉庫コード
                    dummyKey.EnterpriseCode = (item as APStockMoveWork).EnterpriseCode;
                    dummyKey.WarehouseCode = (item as APStockMoveWork).BfEnterWarehCode;
                }
                else
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(dummyKey.WarehouseCode))
                {
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }
                }
            }
            foreach (object item in stockMoveList)
            {
                // 在庫移動データ
                if (item is APStockMoveWork)
                {
                    // 在庫移動データの移動先倉庫コード
                    dummyKey.EnterpriseCode = (item as APStockMoveWork).EnterpriseCode;
                    dummyKey.WarehouseCode = (item as APStockMoveWork).AfEnterWarehCode;
                }
                else
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(dummyKey.WarehouseCode))
                {
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }
                }
            }
        }
        // ADD 2011/08/10 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
        # endregion
    }
}
