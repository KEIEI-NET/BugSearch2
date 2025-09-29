//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン売価優先設定マスタメンテナンス
// プログラム概要   : キャンペーン売価優先設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using System.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// キャンペーン売価優先設定DBリモートオブジェクト
	/// </summary>
	/// <remarks>
    /// <br>Note       : キャンペーン売価優先設定の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 鄧潘ハン</br>
	/// <br>Date       : 2011/04/25</br>
    /// </remarks>
	[Serializable]
    public class CampaignPrcPrStDB : RemoteDB, ICampaignPrcPrStDB
	{
        /// <summary>
        /// キャンペーン売価優先設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public CampaignPrcPrStDB()
            : base("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork", "CAMPAIGNPRCPRSTRF")
        {

        }

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CampaignPrcPrStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CampaignPrcPrStWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private CampaignPrcPrStWork CopyToCampaignPrcPrStWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();

            this.CopyToCampaignPrcPrStWorkFromReader(ref myReader, ref campaignPrcPrStWork);

            return campaignPrcPrStWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CampaignPrcPrStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="campaignPrcPrStWork">CampaignPrcPrStWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void CopyToCampaignPrcPrStWorkFromReader(ref SqlDataReader myReader, ref CampaignPrcPrStWork campaignPrcPrStWork)
        {
            if (myReader != null && campaignPrcPrStWork != null)
            {
                # region クラスへ格納
                campaignPrcPrStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                campaignPrcPrStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                campaignPrcPrStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                campaignPrcPrStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                campaignPrcPrStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                campaignPrcPrStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                campaignPrcPrStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                campaignPrcPrStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                campaignPrcPrStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                campaignPrcPrStWork.PrioritySettingCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD1RF"));
                campaignPrcPrStWork.PrioritySettingCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD2RF"));
                campaignPrcPrStWork.PrioritySettingCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD3RF"));
                campaignPrcPrStWork.PrioritySettingCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD4RF"));
                campaignPrcPrStWork.PrioritySettingCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD5RF"));
                campaignPrcPrStWork.PrioritySettingCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIORITYSETTINGCD6RF"));

                # endregion
            }
        }

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
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
        /// <param name="sqlConnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // トランザクションの生成(開始)
#if DEBUG
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            }

            return sqlTransaction;
        }
        # endregion [コネクション生成処理]


        #region ICampaignPrcPrStDB メンバ

        #region Search
        /// <summary>
        /// 指定された企業コードのキャンペーン売価優先設定LISTを全て戻します。
        /// </summary>
        /// <param name="outCampaignPrcPrSt">検索結果</param>
        /// <param name="paraCampaignPrcPrStWork">パラメー</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのキャンペーン売価優先設定LISTを全て戻します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Search(out object outCampaignPrcPrSt, object paraCampaignPrcPrStWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList campaignPrcPrStList = null;
            CampaignPrcPrStWork campaignPrcPrStWork = null;

            outCampaignPrcPrSt = new CustomSerializeArrayList();

            try
            {
                campaignPrcPrStWork = paraCampaignPrcPrStWork as CampaignPrcPrStWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = this.SearchProc(out campaignPrcPrStList, campaignPrcPrStWork, readMode, logicalMode, ref sqlConnection);

                if (campaignPrcPrStList != null)
                {
                    (outCampaignPrcPrSt as CustomSerializeArrayList).AddRange(campaignPrcPrStList);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.Search", status);
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
        /// 指定された企業コードのキャンペーン売価優先設定LISTを全て戻します。
        /// </summary>
        /// <param name="campaignPrcPrStList">検索結果</param>
        /// <param name="campaignPrcPrStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのキャンペーン売価優先設定LISTを全て戻します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int SearchProc(out ArrayList campaignPrcPrStList, CampaignPrcPrStWork campaignPrcPrStWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                String sqlText = null;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(this.CopyToCampaignPrcPrStWorkFromReader(ref myReader));
                }

                // 検索結果がある場合
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.SearchProc", status);
            }
            finally
            {
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
            }

            campaignPrcPrStList = al;

            return status;
        }

        /// <summary>
        /// 指定されたキャンペーン売価優先設定Guidのキャンペーン売価優先設定を戻します
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :  指定されたキャンペーン売価優先設定Guidのキャンペーン売価優先設定を戻します</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            return this.ReadProc(ref parabyte, readMode);
        }

        /// <summary>
        /// 指定されたキャンペーン売価優先設定Guidのキャンペーン売価優先設定を戻します
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :  指定されたキャンペーン売価優先設定Guidのキャンペーン売価優先設定を戻します</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            CampaignPrcPrStWork campaignPrcPrStWork = new CampaignPrcPrStWork();
            try
            {
                // XMLの読み込み
                campaignPrcPrStWork = (CampaignPrcPrStWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignPrcPrStWork));

                if (campaignPrcPrStWork == null)
                {
                    return status;
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                String sqlText = null;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    campaignPrcPrStWork = CopyToCampaignPrcPrStWorkFromReader(ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

               // XMLへ変換し、文字列のバイナリ化
               parabyte = XmlByteSerializer.Serialize(campaignPrcPrStWork);


            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MediationCampaignPrcPrStDB.Read Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
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
            }

            return status;
        }
        
        #endregion

        #region Delete

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWorkブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWorkブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        private int DeleteProc(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // XMLの読み込み
                CampaignPrcPrStWork campaignPrcPrStWork = (CampaignPrcPrStWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignPrcPrStWork));

                if (campaignPrcPrStWork == null)
                {
                    return status;
                }
                string sqlText = string.Empty;
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                    if (_updateDateTime != campaignPrcPrStWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    # region [DELETE文]
                    string sqlText_DELETE = string.Empty;
                    sqlText_DELETE += "DELETE FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                    sqlText_DELETE += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                    sqlText_DELETE += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText_DELETE;
                    # endregion

                    // KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);
                }
                else
                {
                    // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.Delete", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.DeleteProc", status);
            }
            finally
            {
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
            }

            return status;
        }

        #endregion Delete

        #region LogicalDelete

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="campaignPrcPrStWork">論理削除するキャンペーン売価優先設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int LogicalDelete(ref object campaignPrcPrStWork)
        {
            return this.LogicalDeleteProc(ref campaignPrcPrStWork, 0);
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="campaignPrcPrStWork">論理削除するキャンペーン売価優先設定マスタ情報</param>
        /// <param name="procMode">論理削除モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int LogicalDeleteProc(ref object campaignPrcPrStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CampaignPrcPrStWork paraList = campaignPrcPrStWork as CampaignPrcPrStWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                campaignPrcPrStWork = paraList;

            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "CampaignPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.LogicalDeleteProc", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
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
            }

            return status;
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="campaignPrcPrStWork">論理削除を解除するキャンペーン売価優先設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object campaignPrcPrStWork)
        {
            return this.LogicalDeleteProc(ref campaignPrcPrStWork, 1);
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="campaignPrcPrStWork">論理削除するキャンペーン売価優先設定マスタ情報</param>
        /// <param name="procMode">論理削除モード</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int LogicalDeleteProc(ref CampaignPrcPrStWork campaignPrcPrStWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (campaignPrcPrStWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                    sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                    sqlText += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != campaignPrcPrStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE文]
                        string sqlText_UPDATE = string.Empty;
                        sqlText_UPDATE += "UPDATE CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                        sqlText_UPDATE += "    SET UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine;


                        sqlText_UPDATE += "    ,LOGICALDELETECODERF=@LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText_UPDATE += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                        sqlText_UPDATE += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_UPDATE;
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignPrcPrStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    // 論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                            return status;
                        }
                        else if (logicalDelCd == 0) campaignPrcPrStWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                        else campaignPrcPrStWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            campaignPrcPrStWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // 既に復活している場合はそのまま正常を戻す
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                            }

                            return status;
                        }
                    }

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIMERF", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODERF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignPrcPrStWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt64(campaignPrcPrStWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(campaignPrcPrStWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqex, "CampaignPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.DeleteProc", status);
            }
            finally
            {
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
            }

            return status;
        }

        #endregion LogicalDelete
        
        #region Write
        
        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="campaignPrcPrStWorkbyte">追加・更新するキャンペーン売価優先設定マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public int Write(ref object campaignPrcPrStWorkbyte, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                CampaignPrcPrStWork campaignPrcPrStWork = campaignPrcPrStWorkbyte as CampaignPrcPrStWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = WriteProc(ref campaignPrcPrStWork, ref sqlConnection, ref sqlTransaction);

                // 戻り値セット
                campaignPrcPrStWorkbyte = campaignPrcPrStWork;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.Write", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
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
            }

            return status;
        }


        /// <summary>
        /// キャンペーン売価優先設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="campaignPrcPrStWork">追加・更新するキャンペーン売価優先設定マスタ情報</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価優先設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private int WriteProc(ref CampaignPrcPrStWork campaignPrcPrStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            CampaignPrcPrStWork al = new CampaignPrcPrStWork();

            try
            {
                if (campaignPrcPrStWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD1RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD2RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD3RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD4RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD5RF" + Environment.NewLine;
                    sqlText += "    ,PRIORITYSETTINGCD6RF" + Environment.NewLine;
                    sqlText += " FROM CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine;
                    sqlText += " AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != campaignPrcPrStWork.UpdateDateTime)
                        {
                            if (campaignPrcPrStWork.UpdateDateTime == DateTime.MinValue)
                            {
                                // 新規登録で該当データ有りの場合には重複
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            else
                            {
                                // 既存データで更新日時違いの場合には排他
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            return status;
                        }

                        # region [UPDATE文]
                        string sqlText_UPDATE = string.Empty;
                        sqlText_UPDATE += "UPDATE CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                        sqlText_UPDATE += "    SET PRIORITYSETTINGCD1RF=@PRIORITYSETTINGCD1," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD2RF=@PRIORITYSETTINGCD2," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD3RF=@PRIORITYSETTINGCD3," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD4RF=@PRIORITYSETTINGCD4," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD5RF=@PRIORITYSETTINGCD5," + Environment.NewLine;
                        sqlText_UPDATE += "    PRIORITYSETTINGCD6RF=@PRIORITYSETTINGCD6," + Environment.NewLine;
                        sqlText_UPDATE += "    UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText_UPDATE += " WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
                        sqlText_UPDATE += " AND SECTIONCODERF=@SECTIONCODE " + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_UPDATE;
                        # endregion

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignPrcPrStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (campaignPrcPrStWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT文]
                        string sqlText_INSERT =string.Empty;
                        sqlText_INSERT += "INSERT INTO CAMPAIGNPRCPRSTRF" + Environment.NewLine;
                        sqlText_INSERT += " (CREATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "  UPDATEDATETIMERF," + Environment.NewLine;
                        sqlText_INSERT += "  ENTERPRISECODERF," + Environment.NewLine;
                        sqlText_INSERT += "  FILEHEADERGUIDRF," + Environment.NewLine;
                        sqlText_INSERT += " UPDEMPLOYEECODERF," + Environment.NewLine;
                        sqlText_INSERT += "  UPDASSEMBLYID1RF," + Environment.NewLine;
                        sqlText_INSERT += "  UPDASSEMBLYID2RF," + Environment.NewLine;
                        sqlText_INSERT += " LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText_INSERT += "     SECTIONCODERF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD1RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD2RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD3RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD4RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD5RF," + Environment.NewLine;
                        sqlText_INSERT += "PRIORITYSETTINGCD6RF)" + Environment.NewLine;
                        sqlText_INSERT += "VALUES (@CREATEDATETIME," + Environment.NewLine;
                        sqlText_INSERT += "     @UPDATEDATETIMERF, " + Environment.NewLine;
                        sqlText_INSERT += "     @ENTERPRISECODE, " + Environment.NewLine;
                        sqlText_INSERT += "     @FILEHEADERGUID," + Environment.NewLine;
                        sqlText_INSERT += "     @UPDEMPLOYEECODE," + Environment.NewLine;
                        sqlText_INSERT += "     @UPDASSEMBLYID1, " + Environment.NewLine;
                        sqlText_INSERT += "     @UPDASSEMBLYID2, " + Environment.NewLine;
                        sqlText_INSERT += "     @LOGICALDELETECODE, " + Environment.NewLine;
                        sqlText_INSERT += "     @SECTIONCODE, " + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD1," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD2," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD3," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD4," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD5," + Environment.NewLine;
                        sqlText_INSERT += "     @PRIORITYSETTINGCD6)" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText_INSERT;
                        # endregion

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)campaignPrcPrStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIMERF", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraPrioritySettingCd1 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD1", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd2 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD2", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd3 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD3", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd4 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD4", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd5 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD5", SqlDbType.Int);
                    SqlParameter paraPrioritySettingCd6 = sqlCommand.Parameters.Add("@PRIORITYSETTINGCD6", SqlDbType.Int);


                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignPrcPrStWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignPrcPrStWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignPrcPrStWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignPrcPrStWork.SectionCode);
                    paraPrioritySettingCd1.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd1);
                    paraPrioritySettingCd2.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd2);
                    paraPrioritySettingCd3.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd3);
                    paraPrioritySettingCd4.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd4);
                    paraPrioritySettingCd5.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd5);
                    paraPrioritySettingCd6.Value = SqlDataMediator.SqlSetInt32(campaignPrcPrStWork.PrioritySettingCd6);

                    sqlCommand.ExecuteNonQuery();
                    al = campaignPrcPrStWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "CampaignPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "CampaignPrcPrStDB.WriteProc", status);
            }
            finally
            {
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
            }

            campaignPrcPrStWork = al;

            return status;
        }
        #endregion 

        #endregion ICampaignPrcPrStDB メンバ

    }
}
