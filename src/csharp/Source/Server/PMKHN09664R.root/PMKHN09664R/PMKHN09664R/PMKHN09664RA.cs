//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リモート伝発設定マスタメンテ
// プログラム概要   : リモート伝発設定マスタメンテDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 欧方方
// 作 成 日  2011.08.03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note      :   2011.09.16 wangl2                               //
//                  :   1.PCC-UOEの対応、障害報告 #24982対応            //
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// リモート伝発設定マスタマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : リモート伝発設定マスタマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 欧方方</br>
    /// <br>Date       : 2011.08.03</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RmSlpPrtStDB : RemoteDB, IRmSlpPrtStDB
    {
        #region [クラスコンストラクタ]
        /// <summary>
        /// リモート伝発設定マスタマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public RmSlpPrtStDB()
            :
            base("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork", "RMSLPPRTSTRF")
        {
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件のリモート伝発設定マスタマスタ情報LISTの戻処理
        /// </summary>
        /// <param name="rmSlpPrtStWork">検索結果</param>
        /// <param name="pararmSlpPrtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のリモート伝発設定マスタマスタ情報LISTを戻します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int Search(out object rmSlpPrtStWork, RmSlpPrtStWork pararmSlpPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rmSlpPrtStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchRmSlpPrtStProc(out rmSlpPrtStWork, pararmSlpPrtStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RmSlpPrtStDB.Search");
                rmSlpPrtStWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件のリモート伝発設定マスタマスタ情報LISTの全て戻処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objrmSlpPrtStWork">検索結果</param>
        /// <param name="pararmSlpPrtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のリモート伝発設定マスタマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int SearchRmSlpPrtStProc(out object objrmSlpPrtStWork, RmSlpPrtStWork pararmSlpPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList rmSlpPrtStWorkList = new ArrayList();
            int status = SearchRmSlpPrtStProc(out rmSlpPrtStWorkList, pararmSlpPrtStWork, readMode, logicalMode, ref sqlConnection);
            objrmSlpPrtStWork = rmSlpPrtStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のリモート伝発設定マスタマスタ情報LISTの戻処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">検索結果</param>
        /// <param name="rmSlpPrtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のリモート伝発設定マスタマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int SearchRmSlpPrtStProc(out ArrayList rmSlpPrtStWorkList, RmSlpPrtStWork rmSlpPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchRmSlpPrtStProcProc(out rmSlpPrtStWorkList, rmSlpPrtStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のリモート伝発設定マスタマスタ情報LISTの戻処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">検索結果</param>
        /// <param name="rmSlpPrtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のリモート伝発設定マスタマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        private int SearchRmSlpPrtStProcProc(out ArrayList rmSlpPrtStWorkList, RmSlpPrtStWork rmSlpPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder();
                sqlTxt.Append("SELECT RMSLPPRT.CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.SLIPPRTKINDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.SLIPPRTSETPAPERIDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.RMTSLPPRTDIVRF").Append(Environment.NewLine);
                // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                sqlTxt.Append("    ,RMSLPPRT.TOPMARGINRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.LEFTMARGINRF").Append(Environment.NewLine);
                // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                sqlTxt.Append(" FROM RMSLPPRTSTRF RMSLPPRT WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rmSlpPrtStWork, logicalMode);
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                int createDateTime_ColIndex = 0;
                int updateDateTime_ColIndex = 0;
                int logicalDeleteCode_ColIndex = 0;
                int inqOriginalEpCd_ColIndex = 0;
                int inqOriginalSecCd_ColIndex = 0;
                int inqOtherEpCd_ColIndex = 0;
                int inqOtherSecCd_ColIndex = 0;
                int pccCompanyCode_ColIndex = 0;
                int rmtSlpPrtDiv_ColIndex = 0;
                int slipPrtSetPaperId_ColIndex = 0;
                int slipPrtKind_ColIndex = 0;
                // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                int topMargin_ColIndex = 0;
                int leftMargin_ColIndex = 0;
                // Add wangl2 on 2011.09.16 For 障害報告 #24982 END

                if (myReader.HasRows)
                {
                    createDateTime_ColIndex = myReader.GetOrdinal("CREATEDATETIMERF");
                    updateDateTime_ColIndex = myReader.GetOrdinal("UPDATEDATETIMERF");
                    logicalDeleteCode_ColIndex = myReader.GetOrdinal("LOGICALDELETECODERF");
                    inqOriginalEpCd_ColIndex = myReader.GetOrdinal("INQORIGINALEPCDRF");
                    inqOriginalSecCd_ColIndex = myReader.GetOrdinal("INQORIGINALSECCDRF");
                    inqOtherEpCd_ColIndex = myReader.GetOrdinal("INQOTHEREPCDRF");
                    inqOtherSecCd_ColIndex = myReader.GetOrdinal("INQOTHERSECCDRF");
                    pccCompanyCode_ColIndex = myReader.GetOrdinal("PCCCOMPANYCODERF");
                    rmtSlpPrtDiv_ColIndex = myReader.GetOrdinal("RMTSLPPRTDIVRF");
                    slipPrtSetPaperId_ColIndex = myReader.GetOrdinal("SLIPPRTSETPAPERIDRF");
                    slipPrtKind_ColIndex = myReader.GetOrdinal("SLIPPRTKINDRF");
                    // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                    topMargin_ColIndex = myReader.GetOrdinal("TOPMARGINRF");
                    leftMargin_ColIndex = myReader.GetOrdinal("LEFTMARGINRF");
                    // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                }

                while (myReader.Read())
                {
                    //SqlDataReader→速太郎作業部品集約設定ワークセット処理                   
                    RmSlpPrtStWork wkRmSlpPrtStWork = new RmSlpPrtStWork();

                    wkRmSlpPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, createDateTime_ColIndex);   // 作成日時
                    wkRmSlpPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, updateDateTime_ColIndex);   // 更新日時
                    wkRmSlpPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, logicalDeleteCode_ColIndex);         // 論理削除区分
                    wkRmSlpPrtStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, inqOriginalEpCd_ColIndex).Trim();     // 問合せ元企業コード//@@@@20230303
                    wkRmSlpPrtStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, inqOriginalSecCd_ColIndex);          // 問合せ元拠点コード
                    wkRmSlpPrtStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, inqOtherEpCd_ColIndex);                  // 問合せ先企業コード
                    wkRmSlpPrtStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, inqOtherSecCd_ColIndex);                // 問合せ先拠点コード
                    wkRmSlpPrtStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, pccCompanyCode_ColIndex);               // PCC自社コード
                    wkRmSlpPrtStWork.RmtSlpPrtDiv = SqlDataMediator.SqlGetInt32(myReader, rmtSlpPrtDiv_ColIndex);                   // 伝票印刷種別
                    wkRmSlpPrtStWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, slipPrtSetPaperId_ColIndex);        // 伝票印刷設定用帳票ID
                    wkRmSlpPrtStWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, slipPrtKind_ColIndex);                     // リモート伝発区分
                    // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                    wkRmSlpPrtStWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, topMargin_ColIndex);                        //上余白
                    wkRmSlpPrtStWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, leftMargin_ColIndex);                      //左余白
                    // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                    al.Add(wkRmSlpPrtStWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            rmSlpPrtStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のリモート伝発設定マスタマスタの戻処理
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のリモート伝発設定マスタマスタを戻します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int Read(ref RmSlpPrtStWork rmSlpPrtStWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref rmSlpPrtStWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RmSlpPrtStDB.Read");
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
        /// 指定された条件のリモート伝発設定マスタマスタの戻処理((外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のリモート伝発設定マスタマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        private int ReadProc(ref RmSlpPrtStWork rmSlpPrtStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, " +
                                                       "INQOTHEREPCDRF, INQOTHERSECCDRF, PCCCOMPANYCODERF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, RMTSLPPRTDIVRF,TOPMARGINRF,LEFTMARGINRF " +
                                                       "FROM RMSLPPRTSTRF WITH (READUNCOMMITTED) WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND " +
                                                       "INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND SLIPPRTKINDRF=@FINDSLIPPRTKIND", sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    int createDateTime_ColIndex = 0;
                    int updateDateTime_ColIndex = 0;
                    int logicalDeleteCode_ColIndex = 0;
                    int inqOriginalEpCd_ColIndex = 0;
                    int inqOriginalSecCd_ColIndex = 0;
                    int inqOtherEpCd_ColIndex = 0;
                    int inqOtherSecCd_ColIndex = 0;
                    int pccCompanyCode_ColIndex = 0;
                    int rmtSlpPrtDiv_ColIndex = 0;
                    int slipPrtSetPaperId_ColIndex = 0;
                    int slipPrtKind_ColIndex = 0;
                    // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                    int topMargin_ColIndex = 0;
                    int leftMargin_ColIndex = 0;
                    // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                    if (myReader.HasRows)
                    {
                        createDateTime_ColIndex = myReader.GetOrdinal("CREATEDATETIMERF");
                        updateDateTime_ColIndex = myReader.GetOrdinal("UPDATEDATETIMERF");
                        logicalDeleteCode_ColIndex = myReader.GetOrdinal("LOGICALDELETECODERF");
                        inqOriginalEpCd_ColIndex = myReader.GetOrdinal("INQORIGINALEPCDRF");
                        inqOriginalSecCd_ColIndex = myReader.GetOrdinal("INQORIGINALSECCDRF");
                        inqOtherEpCd_ColIndex = myReader.GetOrdinal("INQOTHEREPCDRF");
                        inqOtherSecCd_ColIndex = myReader.GetOrdinal("INQOTHERSECCDRF");
                        pccCompanyCode_ColIndex = myReader.GetOrdinal("PCCCOMPANYCODERF");
                        rmtSlpPrtDiv_ColIndex = myReader.GetOrdinal("RMTSLPPRTDIVRF");
                        slipPrtSetPaperId_ColIndex = myReader.GetOrdinal("SLIPPRTSETPAPERIDRF");
                        slipPrtKind_ColIndex = myReader.GetOrdinal("SLIPPRTKINDRF");
                        // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                        topMargin_ColIndex = myReader.GetOrdinal("TOPMARGINRF");
                        leftMargin_ColIndex = myReader.GetOrdinal("LEFTMARGINRF");
                        // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                    }

                    if (myReader.Read())
                    {
                        rmSlpPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, createDateTime_ColIndex);   // 作成日時
                        rmSlpPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, updateDateTime_ColIndex);   // 更新日時
                        rmSlpPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, logicalDeleteCode_ColIndex);         // 論理削除区分
                        rmSlpPrtStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, inqOriginalEpCd_ColIndex).Trim();     // 問合せ元企業コード//@@@@20230303
                        rmSlpPrtStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, inqOriginalSecCd_ColIndex);          // 問合せ元拠点コード
                        rmSlpPrtStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, inqOtherEpCd_ColIndex);                  // 問合せ先企業コード
                        rmSlpPrtStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, inqOtherSecCd_ColIndex);                // 問合せ先拠点コード
                        rmSlpPrtStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, pccCompanyCode_ColIndex);               // PCC自社コード
                        rmSlpPrtStWork.RmtSlpPrtDiv = SqlDataMediator.SqlGetInt32(myReader, rmtSlpPrtDiv_ColIndex);                   // 伝票印刷種別
                        rmSlpPrtStWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, slipPrtSetPaperId_ColIndex);        // 伝票印刷設定用帳票ID
                        rmSlpPrtStWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, slipPrtKind_ColIndex);
                        // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                        rmSlpPrtStWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, topMargin_ColIndex);                        //上余白
                        rmSlpPrtStWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, leftMargin_ColIndex);                      //左余白
                        // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// リモート伝発設定マスタマスタ情報の登録、更新処理
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報を登録、更新します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int Write(ref object rmSlpPrtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(rmSlpPrtStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);


                //write実行
                status = WriteRmSlpPrtStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                rmSlpPrtStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RmSlpPrtStDB.Write(ref object rmSlpPrtStWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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

        /// <summary>
        /// リモート伝発設定マスタマスタ情報の登録、更新処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">RmSlpPrtStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int WriteRmSlpPrtStProc(ref ArrayList rmSlpPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteRmSlpPrtStProcProc(ref rmSlpPrtStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// リモート伝発設定マスタマスタ情報の登録、更新処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">RmSlpPrtStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        private int WriteRmSlpPrtStProcProc(ref ArrayList rmSlpPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlTxt = new StringBuilder();
            try
            {
                if (rmSlpPrtStWorkList != null)
                {
                    for (int i = 0; i < rmSlpPrtStWorkList.Count; i++)
                    {
                        RmSlpPrtStWork rmSlpPrtStWork = rmSlpPrtStWorkList[i] as RmSlpPrtStWork;



                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,INQOTHEREPCDRF FROM RMSLPPRTSTRF " +
                                                               "WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND " +
                                                               "INQORIGINALSECCDRF = @FINDINQORIGINALSECCD AND " +
                                                               "INQOTHEREPCDRF = @FINDINQOTHEREPCD AND " +
                                                               "INQOTHERSECCDRF = @FINDINQOTHERSECCD AND " +
                                                               "SLIPPRTKINDRF=@FINDSLIPPRTKIND ", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != rmSlpPrtStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (rmSlpPrtStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //Updateコマンドの生成
                            StringBuilder sqlTxtsb = new StringBuilder();
                            sqlTxtsb.Append("UPDATE RMSLPPRTSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , PCCCOMPANYCODERF=@PCCCOMPANYCODE").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , SLIPPRTKINDRF=@SLIPPRTKIND").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , RMTSLPPRTDIVRF=@RMTSLPPRTDIV").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                            sqlTxtsb.Append(" , TOPMARGINRF=@TOPMARGIN").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , LEFTMARGINRF=@LEFTMARGIN").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                            sqlTxtsb.Append(" WHERE ").Append(Environment.NewLine);
                            sqlTxtsb.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("  AND SLIPPRTKINDRF = @FINDSLIPPRTKIND").Append(Environment.NewLine);

                            sqlCommand.CommandText = sqlTxtsb.ToString();


                            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                            rmSlpPrtStWork.UpdateDateTime = DateTime.Now;

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rmSlpPrtStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (rmSlpPrtStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            StringBuilder sqlTxtsb = new StringBuilder();
                            //新規作成時のSQL文を生成
                            sqlTxtsb.Append("INSERT INTO RMSLPPRTSTRF").Append(Environment.NewLine);
                            sqlTxtsb.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,SLIPPRTKINDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,SLIPPRTSETPAPERIDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,RMTSLPPRTDIVRF").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                            sqlTxtsb.Append("    ,TOPMARGINRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,LEFTMARGINRF").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                            sqlTxtsb.Append(" )").Append(Environment.NewLine);
                            sqlTxtsb.Append(" VALUES").Append(Environment.NewLine);
                            sqlTxtsb.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@PCCCOMPANYCODE").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@SLIPPRTKIND").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@SLIPPRTSETPAPERID").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@RMTSLPPRTDIV").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                            sqlTxtsb.Append("    ,@TOPMARGIN").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@LEFTMARGIN").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                            sqlTxtsb.Append(" )").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlTxtsb.ToString();

                            //登録ヘッダ情報を設定
                            rmSlpPrtStWork.UpdateDateTime = DateTime.Now;
                            rmSlpPrtStWork.CreateDateTime = DateTime.Now;
                            rmSlpPrtStWork.LogicalDeleteCode = 0;

                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rmSlpPrtStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter paraInqOriginalSeCd1 = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter paraInqOtherEpCd1 = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter paraInqOtherSeCd1 = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter paraPccCompanyCode = sqlCommand.Parameters.Add("@PCCCOMPANYCODE", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                        SqlParameter paraRmtSlpPrtDiv = sqlCommand.Parameters.Add("@RMTSLPPRTDIV", SqlDbType.Int);
                        // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                        SqlParameter paraTopMargin = sqlCommand.Parameters.Add("@TOPMARGIN", SqlDbType.Float);
                        SqlParameter paraLeftMargin = sqlCommand.Parameters.Add("@LEFTMARGIN", SqlDbType.Float);
                        // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                        //Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rmSlpPrtStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rmSlpPrtStWork.UpdateDateTime);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.LogicalDeleteCode);
                        paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                        paraInqOriginalSeCd1.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                        paraInqOtherEpCd1.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                        paraInqOtherSeCd1.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                        paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.PccCompanyCode);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.SlipPrtSetPaperId);
                        paraRmtSlpPrtDiv.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.RmtSlpPrtDiv);
                        // Add wangl2 on 2011.09.16 For 障害報告 #24982 STA
                        paraTopMargin.Value = SqlDataMediator.SqlSetDouble(rmSlpPrtStWork.TopMargin);
                        paraLeftMargin.Value = SqlDataMediator.SqlSetDouble(rmSlpPrtStWork.LeftMargin);
                        // Add wangl2 on 2011.09.16 For 障害報告 #24982 END
                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);


                        sqlCommand.ExecuteNonQuery();
                        al.Add(rmSlpPrtStWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rmSlpPrtStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// リモート伝発設定マスタマスタ情報の論理削除処理
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報を論理削除します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int LogicalDelete(ref object rmSlpPrtStWork)
        {
            return LogicalDeleteRmSlpPrtSt(ref rmSlpPrtStWork, 0);
        }

        /// <summary>
        /// 論理削除リモート伝発設定マスタマスタ情報の復活処理
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除リモート伝発設定マスタマスタ情報を復活します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int RevivalLogicalDelete(ref object rmSlpPrtStWork)
        {
            return LogicalDeleteRmSlpPrtSt(ref rmSlpPrtStWork, 1);
        }

        /// <summary>
        /// リモート伝発設定マスタマスタ情報の論理削除処理
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        private int LogicalDeleteRmSlpPrtSt(ref object rmSlpPrtStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(rmSlpPrtStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteRmSlpPrtStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "RmSlpPrtStDB.LogicalDeleteRmSlpPrtSt :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        /// <summary>
        /// リモート伝発設定マスタマスタ情報の論理削除処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">RmSlpPrtStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int LogicalDeleteRmSlpPrtStProc(ref ArrayList rmSlpPrtStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteRmSlpPrtStProcProc(ref rmSlpPrtStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// リモート伝発設定マスタマスタ情報の論理削除処理(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">RmSlpPrtStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        private int LogicalDeleteRmSlpPrtStProcProc(ref ArrayList rmSlpPrtStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlTxt = new StringBuilder();
            try
            {
                if (rmSlpPrtStWorkList != null)
                {
                    for (int i = 0; i < rmSlpPrtStWorkList.Count; i++)
                    {
                        RmSlpPrtStWork rmSlpPrtStWork = rmSlpPrtStWorkList[i] as RmSlpPrtStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,LOGICALDELETECODERF FROM RMSLPPRTSTRF " +
                                                               "WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND " +
                                                               "INQORIGINALSECCDRF = @FINDINQORIGINALSECCD AND " +
                                                               "INQOTHEREPCDRF = @FINDINQOTHEREPCD AND " +
                                                               "INQOTHERSECCDRF = @FINDINQOTHERSECCD AND " +
                                                               "SLIPPRTKINDRF=@FINDSLIPPRTKIND ", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);


                        //Parameterオブジェクトへ値設定
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);


                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != rmSlpPrtStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                            sqlTxt = new StringBuilder();
                            sqlTxt.Append("UPDATE RMSLPPRTSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                            sqlTxt.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                            sqlTxt.Append("    AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                            sqlTxt.Append("    AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                            sqlTxt.Append("    AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                            sqlTxt.Append("    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlTxt.ToString();

                            //Parameterオブジェクトへ値設定
                            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rmSlpPrtStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) rmSlpPrtStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else rmSlpPrtStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) rmSlpPrtStWork.LogicalDeleteCode = 0;   //論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  // 既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;   // 完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameterオブジェクトの作成(更新用)

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

                        //Parameterオブジェクトへ値設定(更新用)

                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.LogicalDeleteCode);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rmSlpPrtStWork.UpdateDateTime);

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);


                        sqlCommand.ExecuteNonQuery();
                        al.Add(rmSlpPrtStWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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

            rmSlpPrtStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// リモート伝発設定マスタマスタ情報の物理削除処理
        /// </summary>
        /// <param name="parabyte">リモート伝発設定マスタマスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報を物理削除します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteRmSlpPrtStProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RmSlpPrtStDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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

        /// <summary>
        /// リモート伝発設定マスタマスタ情報の物理削除処理(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">リモート伝発設定マスタマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        public int DeleteRmSlpPrtStProc(ArrayList rmSlpPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteRmSlpPrtStProcProc(rmSlpPrtStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// リモート伝発設定マスタマスタ情報の物理削除処理(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">リモート伝発設定マスタマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : リモート伝発設定マスタマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        private int DeleteRmSlpPrtStProcProc(ArrayList rmSlpPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlTxt = new StringBuilder();
            try
            {
                for (int i = 0; i < rmSlpPrtStWorkList.Count; i++)
                {
                    RmSlpPrtStWork rmSlpPrtStWork = rmSlpPrtStWorkList[i] as RmSlpPrtStWork;

                    //Selectコマンドの生成
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM RMSLPPRTSTRF " +
                                                           "WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND " +
                                                           "INQORIGINALSECCDRF = @FINDINQORIGINALSECCD AND " +
                                                           "INQOTHEREPCDRF = @FINDINQOTHEREPCD AND " +
                                                           "INQOTHERSECCDRF = @FINDINQOTHERSECCD AND " +
                                                           "SLIPPRTKINDRF=@FINDSLIPPRTKIND ", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != rmSlpPrtStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt.Append("DELETE").Append(Environment.NewLine);
                        sqlTxt.Append(" FROM RMSLPPRTSTRF").Append(Environment.NewLine);
                        sqlTxt.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                        sqlTxt.Append("    AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                        sqlTxt.Append("    AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlTxt.Append("    AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                        sqlTxt.Append("    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND").Append(Environment.NewLine);
                        sqlCommand.CommandText = sqlTxt.ToString();
                        sqlTxt = new StringBuilder();

                        //Parameterオブジェクトへ値設定
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rmSlpPrtStWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RmSlpPrtStWork rmSlpPrtStWork, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder("WHERE ");

            // 問合せ先企業コード
            retstring.Append(" RMSLPPRT.INQOTHEREPCDRF=@FINDINQOTHEREPCD ");
            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);


            // 問合せ元企業コード
            if (rmSlpPrtStWork.InqOriginalEpCd.Trim() != string.Empty)	//@@@@20230303
            {
                retstring.Append("AND RMSLPPRT.INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ");
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
            }

            // 問合せ元拠点コード
            if (rmSlpPrtStWork.InqOriginalSecCd != string.Empty)
            {
                retstring.Append("AND RMSLPPRT.INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ");
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
            }

            // 問合せ先拠点コード
            if (rmSlpPrtStWork.InqOtherSecCd != string.Empty)
            {
                retstring.Append("AND RMSLPPRT.INQOTHERSECCDRF=@FINDINQOTHERSECCD ");
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
            }

            // 伝票印刷種別
            if (rmSlpPrtStWork.SlipPrtKind != 0)
            {
                retstring.Append("AND RMSLPPRT.SLIPPRTKINDRF=@FINDSLIPPRTKIND ");
                SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);
            }

            if (retstring.ToString().Equals("WHERE "))
            {
                return "";
            }
            else
            {
                return retstring.ToString();
            }
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → RmSlpPrtStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RmSlpPrtStWork</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private RmSlpPrtStWork CopyToRmSlpPrtStWorkFromReader(ref SqlDataReader myReader)
        {
            RmSlpPrtStWork wkRmSlpPrtStWork = new RmSlpPrtStWork();

            #region クラスへ格納
            wkRmSlpPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkRmSlpPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkRmSlpPrtStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCD")).Trim();//@@@@20230303
            wkRmSlpPrtStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCD"));
            wkRmSlpPrtStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCD"));
            wkRmSlpPrtStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCD"));
            wkRmSlpPrtStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PCCCOMPANYCODE"));
            wkRmSlpPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkRmSlpPrtStWork.RmtSlpPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RMTSLPPRTDIV"));
            wkRmSlpPrtStWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERID"));
            wkRmSlpPrtStWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKIND"));
            #endregion

            return wkRmSlpPrtStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Note       : パラメータキャスト処理します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            RmSlpPrtStWork[] RmSlpPrtStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is RmSlpPrtStWork)
                    {
                        RmSlpPrtStWork wkRmSlpPrtStWork = paraobj as RmSlpPrtStWork;
                        if (wkRmSlpPrtStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkRmSlpPrtStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            RmSlpPrtStWorkArray = (RmSlpPrtStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(RmSlpPrtStWork[]));
                        }
                        catch (Exception) { }
                        if (RmSlpPrtStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(RmSlpPrtStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                RmSlpPrtStWork wkRmSlpPrtStWork = (RmSlpPrtStWork)XmlByteSerializer.Deserialize(byteArray, typeof(RmSlpPrtStWork));
                                if (wkRmSlpPrtStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkRmSlpPrtStWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection生成処理します</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
