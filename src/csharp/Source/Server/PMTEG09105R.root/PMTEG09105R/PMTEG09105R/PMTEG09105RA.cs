//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形データメンテナンス
// プログラム概要   : 手形データ設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
// 作 成 日  2010/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/10/18  修正内容 : 抽出条件の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 山路 芳郎
// 修 正 日  2012/10/26  修正内容 : 手持手形ガイド専用の抽出条件の変更(期日を"=" ⇒ ">="に変更)
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : zhuhh
// 修 正 日  2013/01/10  修正内容 : 2013/03/13配信分 Redmine #34123
//                                  手形データ重複した伝票番号の登録を出来る様にする
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受取手形データマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受取手形データマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// </remarks>
    [Serializable]
    public class RcvDraftDataDB : RemoteDB, IRcvDraftDataDB
    {
        /// <summary>
        /// 受取手形データマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public RcvDraftDataDB()
            : base("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork", "RcvDraftDataRF")
        {

        }

        # region [Search]
        /// <summary>
        /// 受取手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="paraRcvDraftDataWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタのキー値が一致する、全ての受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int Search(out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _rcvDraftDataList = null;
            RcvDraftDataWork rcvDraftDataWork = null;

            outRcvDraftDataList = new CustomSerializeArrayList();

            try
            {
                rcvDraftDataWork = paraRcvDraftDataWork as RcvDraftDataWork;
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchProc(out _rcvDraftDataList, rcvDraftDataWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDataDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RcvDraftDataDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            outRcvDraftDataList = _rcvDraftDataList;

            return status;
        }

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// 受取手形データマスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="rcvDraftDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データ番号値が一致する、受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithoutBabCd(out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RcvDraftDataWork rcvDraftDataWork = null;

            ArrayList al = new ArrayList();
            try
            {
                // コネクション生成
                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                rcvDraftDataWork = paraRcvDraftDataWork as RcvDraftDataWork;
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                // DBテープルの受取手形番号検索
                sqlText.Append("SELECT "+Environment.NewLine);
                sqlText.Append("CREATEDATETIMERF, ");
                sqlText.Append("UPDATEDATETIMERF, ");
                sqlText.Append("ENTERPRISECODERF, ");
                sqlText.Append("FILEHEADERGUIDRF, ");
                sqlText.Append("UPDEMPLOYEECODERF, ");
                sqlText.Append("UPDASSEMBLYID1RF, ");
                sqlText.Append("UPDASSEMBLYID2RF, ");
                sqlText.Append("LOGICALDELETECODERF, ");
                sqlText.Append("RCVDRAFTNORF, ");
                sqlText.Append("DRAFTKINDCDRF, ");
                sqlText.Append("DRAFTDIVIDERF, ");
                sqlText.Append("DEPOSITRF, ");
                sqlText.Append("BANKANDBRANCHCDRF, ");
                sqlText.Append("BANKANDBRANCHNMRF, ");
                sqlText.Append("SECTIONCODERF, ");
                sqlText.Append("ADDUPSECCODERF, ");
                sqlText.Append("CUSTOMERCODERF, ");
                sqlText.Append("CUSTOMERNAMERF, ");
                sqlText.Append("CUSTOMERNAME2RF, ");
                sqlText.Append("CUSTOMERSNMRF, ");
                sqlText.Append("PROCDATERF, ");
                sqlText.Append("DRAFTDRAWINGDATERF, ");
                sqlText.Append("VALIDITYTERMRF, ");
                sqlText.Append("DRAFTSTMNTDATERF, ");
                sqlText.Append("OUTLINE1RF, ");
                sqlText.Append("OUTLINE2RF, ");
                sqlText.Append("ACPTANODRSTATUSRF, ");
                sqlText.Append("DEPOSITSLIPNORF, ");
                sqlText.Append("DEPOSITROWNORF, ");
                sqlText.Append("DEPOSITDATERF "+Environment.NewLine);
                sqlText.Append("FROM RCVDRAFTDATARF " + Environment.NewLine);
                sqlText.Append("WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine);             

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;

                sqlCommand.CommandText += sqlText.ToString();
                // タイムアウト時間：600秒
                sqlCommand.CommandTimeout = 600;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToRcvDraftDataWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDataDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDataDB.SearchProc" + status);
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

            outRcvDraftDataList = al;

            return status;
        }

        /// <summary>
        /// 受取手形データマスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="rcvDraftDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データ番号値が一致する、受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithBabCd(out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RcvDraftDataWork rcvDraftDataWork = null;

            ArrayList al = new ArrayList();
            try
            {
                // コネクション生成
                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                rcvDraftDataWork = paraRcvDraftDataWork as RcvDraftDataWork;
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                // DBテープルの受取手形番号検索
                sqlText.Append("SELECT " + Environment.NewLine);
                sqlText.Append("CREATEDATETIMERF, ");
                sqlText.Append("UPDATEDATETIMERF, ");
                sqlText.Append("ENTERPRISECODERF, ");
                sqlText.Append("FILEHEADERGUIDRF, ");
                sqlText.Append("UPDEMPLOYEECODERF, ");
                sqlText.Append("UPDASSEMBLYID1RF, ");
                sqlText.Append("UPDASSEMBLYID2RF, ");
                sqlText.Append("LOGICALDELETECODERF, ");
                sqlText.Append("RCVDRAFTNORF, ");
                sqlText.Append("DRAFTKINDCDRF, ");
                sqlText.Append("DRAFTDIVIDERF, ");
                sqlText.Append("DEPOSITRF, ");
                sqlText.Append("BANKANDBRANCHCDRF, ");
                sqlText.Append("BANKANDBRANCHNMRF, ");
                sqlText.Append("SECTIONCODERF, ");
                sqlText.Append("ADDUPSECCODERF, ");
                sqlText.Append("CUSTOMERCODERF, ");
                sqlText.Append("CUSTOMERNAMERF, ");
                sqlText.Append("CUSTOMERNAME2RF, ");
                sqlText.Append("CUSTOMERSNMRF, ");
                sqlText.Append("PROCDATERF, ");
                sqlText.Append("DRAFTDRAWINGDATERF, ");
                sqlText.Append("VALIDITYTERMRF, ");
                sqlText.Append("DRAFTSTMNTDATERF, ");
                sqlText.Append("OUTLINE1RF, ");
                sqlText.Append("OUTLINE2RF, ");
                sqlText.Append("ACPTANODRSTATUSRF, ");
                sqlText.Append("DEPOSITSLIPNORF, ");
                sqlText.Append("DEPOSITROWNORF, ");
                sqlText.Append("DEPOSITDATERF " + Environment.NewLine);
                sqlText.Append("FROM RCVDRAFTDATARF " + Environment.NewLine);
                sqlText.Append("WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD" + Environment.NewLine);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD",SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;

                sqlCommand.CommandText += sqlText.ToString();
                // タイムアウト時間：600秒
                sqlCommand.CommandTimeout = 600;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToRcvDraftDataWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDataDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDataDB.SearchProc" + status);
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

            outRcvDraftDataList = al;

            return status;
        }

        /// <summary>
        /// 受取手形データマスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="rcvDraftDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データ番号値が一致する、受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithDrawingDate(out object outRcvDraftDataList, object paraRcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RcvDraftDataWork rcvDraftDataWork = null;

            ArrayList al = new ArrayList();
            try
            {
                // コネクション生成
                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                rcvDraftDataWork = paraRcvDraftDataWork as RcvDraftDataWork;
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                // DBテープルの受取手形番号検索
                sqlText.Append("SELECT " + Environment.NewLine);
                sqlText.Append("CREATEDATETIMERF, ");
                sqlText.Append("UPDATEDATETIMERF, ");
                sqlText.Append("ENTERPRISECODERF, ");
                sqlText.Append("FILEHEADERGUIDRF, ");
                sqlText.Append("UPDEMPLOYEECODERF, ");
                sqlText.Append("UPDASSEMBLYID1RF, ");
                sqlText.Append("UPDASSEMBLYID2RF, ");
                sqlText.Append("LOGICALDELETECODERF, ");
                sqlText.Append("RCVDRAFTNORF, ");
                sqlText.Append("DRAFTKINDCDRF, ");
                sqlText.Append("DRAFTDIVIDERF, ");
                sqlText.Append("DEPOSITRF, ");
                sqlText.Append("BANKANDBRANCHCDRF, ");
                sqlText.Append("BANKANDBRANCHNMRF, ");
                sqlText.Append("SECTIONCODERF, ");
                sqlText.Append("ADDUPSECCODERF, ");
                sqlText.Append("CUSTOMERCODERF, ");
                sqlText.Append("CUSTOMERNAMERF, ");
                sqlText.Append("CUSTOMERNAME2RF, ");
                sqlText.Append("CUSTOMERSNMRF, ");
                sqlText.Append("PROCDATERF, ");
                sqlText.Append("DRAFTDRAWINGDATERF, ");
                sqlText.Append("VALIDITYTERMRF, ");
                sqlText.Append("DRAFTSTMNTDATERF, ");
                sqlText.Append("OUTLINE1RF, ");
                sqlText.Append("OUTLINE2RF, ");
                sqlText.Append("ACPTANODRSTATUSRF, ");
                sqlText.Append("DEPOSITSLIPNORF, ");
                sqlText.Append("DEPOSITROWNORF, ");
                sqlText.Append("DEPOSITDATERF " + Environment.NewLine);
                sqlText.Append("FROM RCVDRAFTDATARF " + Environment.NewLine);
                sqlText.Append("WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);

                sqlCommand.CommandText += sqlText;
                // タイムアウト時間：600秒
                sqlCommand.CommandTimeout = 600;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToRcvDraftDataWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDataDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDataDB.SearchProc" + status);
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

            outRcvDraftDataList = al;

            return status;
        }

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

        /// <summary>
        /// 受取手形データマスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outRcvDraftDataList">検索結果</param>
        /// <param name="rcvDraftDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタのキー値が一致する、全ての受取手形データマスタ情報を取得します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int SearchProc(out ArrayList outRcvDraftDataList, RcvDraftDataWork rcvDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF" + Environment.NewLine;
                sqlText += "FROM RCVDRAFTDATARF" + Environment.NewLine;
                // DBテープルのPrimary Keyで検索
                if (readMode == 0)
                {
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine; // DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD",SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                }
                // 支払伝票番号に対する支払手形データを取得
                // --- UPD 2012/10/18 T.Nishi ----->>>>>
                //手持手形ガイド専用
                else if (readMode == 2)
                {
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DRAFTKINDCDRF=@DRAFTKINDCD AND LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaDraftKindCd.Value = rcvDraftDataWork.DraftKindCd ;
                    findParaLogicalDeleteCode.Value = 0;  //有効

                    if (rcvDraftDataWork.ValidityTerm != 0)
                    {
                        //2012/10/26 yamaji UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //sqlText += " AND VALIDITYTERMRF=@VALIDITYTERM " + Environment.NewLine;
                        sqlText += " AND VALIDITYTERMRF>=@VALIDITYTERM " + Environment.NewLine;
                        //2012/10/26 yamaji UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        //Prameterオブジェクトの作成
                        SqlParameter findParaValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                        //Parameterオブジェクトへ値設定
                        findParaValidityTerm.Value = rcvDraftDataWork.ValidityTerm;
                    }
                }
                // --- UPD 2012/10/18 T.Nishi -----<<<<<
                else
                {
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO" + Environment.NewLine;
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaDepositSlipNo.Value = rcvDraftDataWork.DepositSlipNo;
                }

                sqlCommand.CommandText += sqlText;

                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToRcvDraftDataWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDataDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDataDB.SearchProc" + status);
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

            outRcvDraftDataList = al;

            return status;
        }
        # endregion

        # region [Write]

        /// <summary>
        /// 受取手形データマスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="objRcvDraftDataWorkList">rcvDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタを追加・更新します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int Write(ref object objRcvDraftDataWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList rcvDraftDataWorkList = objRcvDraftDataWorkList as ArrayList;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteProc(ref rcvDraftDataWorkList, ref sqlConnection, ref sqlTransaction);

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDataDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RcvDraftDataDB.Write", status);
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

            //戻り値セット
            objRcvDraftDataWorkList = rcvDraftDataWorkList;

            return status;
        }

        /// <summary>
        /// 受取手形データマスタ情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="rcvDraftDataWorkList">受取手形データマスタ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタ情報を登録、更新します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int WriteProc(ref ArrayList rcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList ayList = new ArrayList();

            try
            {
                string sqlText = string.Empty;

                // 画面の入力データの処理
                for (int index = 0; index < rcvDraftDataWorkList.Count; index++)
                {
                    RcvDraftDataWork rcvDraftDataWork = rcvDraftDataWorkList[index] as RcvDraftDataWork;

                    using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                        //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine; // DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                        SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                        findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            DateTime comUpDateTime = rcvDraftDataWork.UpdateDateTime;

                            // 排他チェック
                            if (_updateDateTime != comUpDateTime)
                            {
                                //既存データで更新日時違いの場合には排他
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (!myReader.IsClosed)
                                {
                                    myReader.Close();
                                }
                                return status;
                            }
                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE RCVDRAFTDATARF " + Environment.NewLine;
                            sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , RCVDRAFTNORF=@RCVDRAFTNO , DRAFTKINDCDRF=@DRAFTKINDCD , DRAFTDIVIDERF=@DRAFTDIVIDE , DEPOSITRF=@DEPOSIT , BANKANDBRANCHCDRF=@BANKANDBRANCHCD , BANKANDBRANCHNMRF=@BANKANDBRANCHNM , SECTIONCODERF=@SECTIONCODE , ADDUPSECCODERF=@ADDUPSECCODE , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , CUSTOMERSNMRF=@CUSTOMERSNM , PROCDATERF=@PROCDATE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , VALIDITYTERMRF=@VALIDITYTERM , DRAFTSTMNTDATERF=@DRAFTSTMNTDATE , OUTLINE1RF=@OUTLINE1 , OUTLINE2RF=@OUTLINE2 , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITROWNORF=@DEPOSITROWNO , DEPOSITDATERF=@DEPOSITDATE " + Environment.NewLine;
                            //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                            findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                            findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (rcvDraftDataWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //　画面のデータ、insert処理
                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO RCVDRAFTDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @RCVDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @DEPOSIT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @ACPTANODRSTATUS, @DEPOSITSLIPNO, @DEPOSITROWNO, @DEPOSITDATE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (myReader.IsClosed == false) myReader.Close();

                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraRcvDraftNo = sqlCommand.Parameters.Add("@RCVDRAFTNO", SqlDbType.NVarChar);
                        SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
                        SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                        SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                        SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
                        SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                        SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
                        SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                        SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                        SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
                        SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
                        SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                        SqlParameter paraDepositRowNo = sqlCommand.Parameters.Add("@DEPOSITROWNO", SqlDbType.Int);
                        SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rcvDraftDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.LogicalDeleteCode);
                        paraRcvDraftNo.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.RcvDraftNo);
                        paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftKindCd);
                        paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftDivide);
                        paraDeposit.Value = SqlDataMediator.SqlSetInt64(rcvDraftDataWork.Deposit);
                        paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.BankAndBranchCd);
                        paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.BankAndBranchNm);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.SectionCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.AddUpSecCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.CustomerCode);
                        paraCustomerName.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName);
                        paraCustomerName2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName2);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerSnm);
                        paraProcDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ProcDate);
                        paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                        paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ValidityTerm);
                        paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftStmntDate);
                        paraOutline1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline1);
                        paraOutline2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline2);
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.AcptAnOdrStatus);
                        paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositSlipNo);
                        paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositRowNo);
                        paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DepositDate);

                        sqlCommand.ExecuteNonQuery();

                        ayList.Add(rcvDraftDataWork);
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDatatDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDatatDB.Write" + status);
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

            rcvDraftDataWorkList = ayList;

            return status;
        }
        # endregion

        #region [LogicalDelete]
        /// <summary>
        /// 受取手形データマスタ情報を論理削除します。
        /// </summary>
        /// <remarks>
        /// <param name="objRcvDraftDatatList">OrderPointWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタ情報を論理削除します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int LogicalDelete(ref object objRcvDraftDatatList)
        {
            return LogicalDelete(ref objRcvDraftDatatList, 1);
        }

        /// <summary>
        /// 論理削除受取手形データマスタ情報情報を復活します
        /// </summary>
        /// <remarks>
        /// <param name="objrcvDraftDatatList">EmpSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除受取手形データマスタ情報情報を復活します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object objrcvDraftDatatList)
        {
            return LogicalDelete(ref objrcvDraftDatatList, 0);
        }

        /// <summary>
        /// 受取手形データマスタ情報の論理削除を操作します
        /// </summary>
        /// <remarks>
        /// <param name="objRcvDraftDatatList">rcvDraftDataWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private int LogicalDelete(ref object objRcvDraftDatatList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList rcvDraftDataWorkList = objRcvDraftDatatList as ArrayList;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = LogicalDeleteProc(ref rcvDraftDataWorkList, procMode, ref sqlConnection, ref sqlTransaction);

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
                if (procMode == 1)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "EmpSalesTargetDB.LogicalDeleteEmpSalesTarget :" + procModestr);

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
        /// 受取手形データマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <remarks>
        /// <param name="rcvDraftDataWorkList">rcvDraftDataWorkオブジェクト</param>
        /// <param name="deleteMode">関数区分 1:論理削除 0:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受取手形データマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int LogicalDeleteProc(ref ArrayList rcvDraftDataWorkList, int deleteMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                for (int i = 0; i < rcvDraftDataWorkList.Count; i++)
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    RcvDraftDataWork rcvDraftDataWork = rcvDraftDataWorkList[i] as RcvDraftDataWork;

                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDrateDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDrateDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != rcvDraftDataWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        //現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE文]
                        sqlText = string.Empty;
                        //sqlText += "UPDATE RCVDRAFTDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "UPDATE RCVDRAFTDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                        findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                        findParaDrateDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
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
                    if (deleteMode == 1)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                            sqlCommand.Cancel();
                            return status;
                        }
                        else if (logicalDelCd == 0) rcvDraftDataWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else rcvDraftDataWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1) rcvDraftDataWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                            sqlCommand.Cancel();
                            return status;
                        }
                    }

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDatatDB.Write" + status);
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
        # endregion

        #region [Delete]
        /// <summary>
        /// 受取手形データマスタ情報を物理削除します
        /// </summary>
        /// <param name="objRcvDraftDatatList">rcvDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタ情報を物理削除します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int Delete(ref object objRcvDraftDatatList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                ArrayList rcvDraftDataWorkList = objRcvDraftDatatList as ArrayList;

                status = DeleteProc(rcvDraftDataWorkList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Delete");
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
        /// 受取手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="rcvDraftDataWorkList">受取手形データマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 受取手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int DeleteProc(ArrayList rcvDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            try
            {
                for (int i = 0; i < rcvDraftDataWorkList.Count; i++)
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    RcvDraftDataWork rcvDraftDataWork = rcvDraftDataWorkList[i] as RcvDraftDataWork;

                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != rcvDraftDataWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // データは全て削除
                        # region [DELETE文]
                        sqlText = string.Empty;
                        //sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DEPOSITDATERF=@FINDDEPOSITDATE";// DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE";// ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                        findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteProc");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → RcvDraftDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RcvDraftDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private RcvDraftDataWork CopyToRcvDraftDataWorkFromReader(ref SqlDataReader myReader)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();

            if (myReader != null && rcvDraftDataWork != null)
            {
                # region クラスへ格納
                rcvDraftDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                rcvDraftDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                rcvDraftDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                rcvDraftDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                rcvDraftDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                rcvDraftDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                rcvDraftDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                rcvDraftDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                rcvDraftDataWork.RcvDraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RCVDRAFTNORF"));
                rcvDraftDataWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
                rcvDraftDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                rcvDraftDataWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                rcvDraftDataWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
                rcvDraftDataWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
                //rcvDraftDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// DEL zhuhh 2013/01/10 for Redmine #34123
                rcvDraftDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")).Trim();// ADD zhuhh 2013/01/10 for Redmine #34123
                rcvDraftDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                rcvDraftDataWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                rcvDraftDataWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                rcvDraftDataWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                rcvDraftDataWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                rcvDraftDataWork.ProcDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDATERF"));
                rcvDraftDataWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                rcvDraftDataWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                rcvDraftDataWork.DraftStmntDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTSTMNTDATERF"));
                rcvDraftDataWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
                rcvDraftDataWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));
                rcvDraftDataWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                rcvDraftDataWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                rcvDraftDataWork.DepositRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
                rcvDraftDataWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));

                # endregion
            }
            return rcvDraftDataWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
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
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
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
        # endregion
    }
    /// <summary>
    /// 支払手形データマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払手形データマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 葛軍</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
    /// </remarks>
    [Serializable]
    public class PayDraftDataDB : RemoteDB, IPayDraftDataDB
    {
        /// <summary>
        /// 支払手形データマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public PayDraftDataDB()
            : base("PMTEG09107D", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork", "PayDraftDataRF")
        {

        }

        # region [Search]
        /// <summary>
        /// 支払手形データマスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="paraPayDraftDataWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int Search(out object outPayDraftDataList, object paraPayDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _payDraftDataList = null;
            PayDraftDataWork payDraftDataWork = null;

            outPayDraftDataList = new CustomSerializeArrayList();

            try
            {
                payDraftDataWork = paraPayDraftDataWork as PayDraftDataWork;
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchProc(out _payDraftDataList, payDraftDataWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDataDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PayDraftDataDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            outPayDraftDataList = _payDraftDataList;

            return status;
        }

        /// <summary>
        /// 支払手形データマスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="payDraftDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int SearchProc(out ArrayList outPayDraftDataList, PayDraftDataWork payDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF" + Environment.NewLine;
                sqlText += "FROM PAYDRAFTDATARF" + Environment.NewLine;
                // DBテープルのPrimary Keyで検索
                if (readMode == 0)
                {
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD",SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                }
                // 支払伝票番号に対する支払手形データを取得
                else
                {
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYMENTSLIPNORF=@FINDPAYMENTSLIPNO" + Environment.NewLine;
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPaymentSlipNo.Value = payDraftDataWork.PaymentSlipNo;
                }

                sqlCommand.CommandText += sqlText;

                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToPayDraftDataWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDataDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PayDraftDataDB.SearchProc" + status);
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

            outPayDraftDataList = al;

            return status;
        }

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// 支払手形データマスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="payDraftDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithoutBab(out object outPayDraftDataList, object paraPayDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            PayDraftDataWork payDraftDataWork = null;

            ArrayList al = new ArrayList();

            try
            {
                // コネクション生成
                SqlConnection sqlConnection = this.CreateSqlConnection(true);
                payDraftDataWork = paraPayDraftDataWork as PayDraftDataWork;
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append("SELECT "+Environment.NewLine);
                sqlText.Append("CREATEDATETIMERF, ");
                sqlText.Append("UPDATEDATETIMERF, ");
                sqlText.Append("ENTERPRISECODERF, ");
                sqlText.Append("FILEHEADERGUIDRF, ");
                sqlText.Append("UPDEMPLOYEECODERF, ");
                sqlText.Append("UPDASSEMBLYID1RF, ");
                sqlText.Append("UPDASSEMBLYID2RF, ");
                sqlText.Append("LOGICALDELETECODERF, ");
                sqlText.Append("PAYDRAFTNORF, ");
                sqlText.Append("DRAFTKINDCDRF, ");
                sqlText.Append("DRAFTDIVIDERF, ");
                sqlText.Append("PAYMENTRF, ");
                sqlText.Append("BANKANDBRANCHCDRF, ");
                sqlText.Append("BANKANDBRANCHNMRF, ");
                sqlText.Append("SECTIONCODERF, ");
                sqlText.Append("ADDUPSECCODERF, ");
                sqlText.Append("SUPPLIERCDRF, ");
                sqlText.Append("SUPPLIERNM1RF, ");
                sqlText.Append("SUPPLIERNM2RF, ");
                sqlText.Append("SUPPLIERSNMRF, ");
                sqlText.Append("PROCDATERF, ");
                sqlText.Append("DRAFTDRAWINGDATERF, ");
                sqlText.Append("VALIDITYTERMRF, ");
                sqlText.Append("DRAFTSTMNTDATERF, ");
                sqlText.Append("OUTLINE1RF, ");
                sqlText.Append("OUTLINE2RF, ");
                sqlText.Append("SUPPLIERFORMALRF, ");
                sqlText.Append("PAYMENTSLIPNORF, ");
                sqlText.Append("PAYMENTROWNORF, ");
                sqlText.Append("PAYMENTDATERF " + Environment.NewLine);
                sqlText.Append("FROM PAYDRAFTDATARF" + Environment.NewLine);
                sqlText.Append("WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;

                sqlCommand.CommandText += sqlText.ToString();
                // タイムアウト時間：600秒
                sqlCommand.CommandTimeout = 600;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToPayDraftDataWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDataDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PayDraftDataDB.SearchProc" + status);
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

            outPayDraftDataList = al;

            return status;
        }

        /// <summary>
        /// 支払手形データマスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="payDraftDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithBab(out object outPayDraftDataList, object paraPayDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            PayDraftDataWork payDraftDataWork = null;

            ArrayList al = new ArrayList();

            try
            {
                // コネクション生成
                SqlConnection sqlConnection = this.CreateSqlConnection(true);
                payDraftDataWork = paraPayDraftDataWork as PayDraftDataWork;
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append("SELECT " + Environment.NewLine);
                sqlText.Append("CREATEDATETIMERF, ");
                sqlText.Append("UPDATEDATETIMERF, ");
                sqlText.Append("ENTERPRISECODERF, ");
                sqlText.Append("FILEHEADERGUIDRF, ");
                sqlText.Append("UPDEMPLOYEECODERF, ");
                sqlText.Append("UPDASSEMBLYID1RF, ");
                sqlText.Append("UPDASSEMBLYID2RF, ");
                sqlText.Append("LOGICALDELETECODERF, ");
                sqlText.Append("PAYDRAFTNORF, ");
                sqlText.Append("DRAFTKINDCDRF, ");
                sqlText.Append("DRAFTDIVIDERF, ");
                sqlText.Append("PAYMENTRF, ");
                sqlText.Append("BANKANDBRANCHCDRF, ");
                sqlText.Append("BANKANDBRANCHNMRF, ");
                sqlText.Append("SECTIONCODERF, ");
                sqlText.Append("ADDUPSECCODERF, ");
                sqlText.Append("SUPPLIERCDRF, ");
                sqlText.Append("SUPPLIERNM1RF, ");
                sqlText.Append("SUPPLIERNM2RF, ");
                sqlText.Append("SUPPLIERSNMRF, ");
                sqlText.Append("PROCDATERF, ");
                sqlText.Append("DRAFTDRAWINGDATERF, ");
                sqlText.Append("VALIDITYTERMRF, ");
                sqlText.Append("DRAFTSTMNTDATERF, ");
                sqlText.Append("OUTLINE1RF, ");
                sqlText.Append("OUTLINE2RF, ");
                sqlText.Append("SUPPLIERFORMALRF, ");
                sqlText.Append("PAYMENTSLIPNORF, ");
                sqlText.Append("PAYMENTROWNORF, ");
                sqlText.Append("PAYMENTDATERF " + Environment.NewLine);
                sqlText.Append("FROM PAYDRAFTDATARF" + Environment.NewLine);
                sqlText.Append("WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD " + Environment.NewLine);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                    SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                    findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;

                sqlCommand.CommandText += sqlText.ToString();
                // タイムアウト時間：600秒
                sqlCommand.CommandTimeout = 600;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToPayDraftDataWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDataDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PayDraftDataDB.SearchProc" + status);
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

            outPayDraftDataList = al;

            return status;
        }

        /// <summary>
        /// 支払手形データマスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outPayDraftDataList">検索結果</param>
        /// <param name="payDraftDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタのキー値が一致する、全ての支払手形データマスタ情報を取得します。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分 Redmine#34123</br>
        /// <br>           : 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        public int SearchWithDrawingDate(out object outPayDraftDataList, object paraPayDraftDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            PayDraftDataWork payDraftDataWork = null;

            ArrayList al = new ArrayList();

            try
            {
                // コネクション生成
                SqlConnection sqlConnection = this.CreateSqlConnection(true);
                payDraftDataWork = paraPayDraftDataWork as PayDraftDataWork;
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append("SELECT " + Environment.NewLine);
                sqlText.Append("CREATEDATETIMERF, ");
                sqlText.Append("UPDATEDATETIMERF, ");
                sqlText.Append("ENTERPRISECODERF, ");
                sqlText.Append("FILEHEADERGUIDRF, ");
                sqlText.Append("UPDEMPLOYEECODERF, ");
                sqlText.Append("UPDASSEMBLYID1RF, ");
                sqlText.Append("UPDASSEMBLYID2RF, ");
                sqlText.Append("LOGICALDELETECODERF, ");
                sqlText.Append("PAYDRAFTNORF, ");
                sqlText.Append("DRAFTKINDCDRF, ");
                sqlText.Append("DRAFTDIVIDERF, ");
                sqlText.Append("PAYMENTRF, ");
                sqlText.Append("BANKANDBRANCHCDRF, ");
                sqlText.Append("BANKANDBRANCHNMRF, ");
                sqlText.Append("SECTIONCODERF, ");
                sqlText.Append("ADDUPSECCODERF, ");
                sqlText.Append("SUPPLIERCDRF, ");
                sqlText.Append("SUPPLIERNM1RF, ");
                sqlText.Append("SUPPLIERNM2RF, ");
                sqlText.Append("SUPPLIERSNMRF, ");
                sqlText.Append("PROCDATERF, ");
                sqlText.Append("DRAFTDRAWINGDATERF, ");
                sqlText.Append("VALIDITYTERMRF, ");
                sqlText.Append("DRAFTSTMNTDATERF, ");
                sqlText.Append("OUTLINE1RF, ");
                sqlText.Append("OUTLINE2RF, ");
                sqlText.Append("SUPPLIERFORMALRF, ");
                sqlText.Append("PAYMENTSLIPNORF, ");
                sqlText.Append("PAYMENTROWNORF, ");
                sqlText.Append("PAYMENTDATERF " + Environment.NewLine);
                sqlText.Append("FROM PAYDRAFTDATARF" + Environment.NewLine);
                sqlText.Append("WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);

                sqlCommand.CommandText += sqlText.ToString();
                // タイムアウト時間：600秒
                sqlCommand.CommandTimeout = 600;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToPayDraftDataWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDataDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PayDraftDataDB.SearchProc" + status);
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

            outPayDraftDataList = al;

            return status;
        }
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
        # endregion

        # region [Write]

        /// <summary>
        /// 支払手形データマスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="objPayDraftDataWorkList">payDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタを追加・更新します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int Write(ref object objPayDraftDataWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList payDraftDataWorkList = objPayDraftDataWorkList as ArrayList;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteProc(ref payDraftDataWorkList, ref sqlConnection, ref sqlTransaction);

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDataDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PayDraftDataDB.Write", status);
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

            //戻り値セット
            objPayDraftDataWorkList = payDraftDataWorkList;

            return status;
        }

        /// <summary>
        /// 支払手形データマスタ情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="payDraftDataWorkList">支払手形データマスタ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタ情報を登録、更新します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br> 
        /// </remarks>
        private int WriteProc(ref ArrayList payDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList ayList = new ArrayList();

            try
            {
                string sqlText = string.Empty;

                // 画面の入力データの処理
                for (int index = 0; index < payDraftDataWorkList.Count; index++)
                {
                    PayDraftDataWork payDraftDataWork = payDraftDataWorkList[index] as PayDraftDataWork;

                    using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM PAYDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                        //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD",SqlDbType.Int);
                        SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                        findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            DateTime comUpDateTime = payDraftDataWork.UpdateDateTime;

                            // 排他チェック
                            if (_updateDateTime != comUpDateTime)
                            {
                                //既存データで更新日時違いの場合には排他
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (!myReader.IsClosed)
                                {
                                    myReader.Close();
                                }
                                return status;
                            }
                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE PAYDRAFTDATARF " + Environment.NewLine;
                            sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PAYDRAFTNORF=@PAYDRAFTNO , DRAFTKINDCDRF=@DRAFTKINDCD , DRAFTDIVIDERF=@DRAFTDIVIDE , PAYMENTRF=@PAYMENT , BANKANDBRANCHCDRF=@BANKANDBRANCHCD , BANKANDBRANCHNMRF=@BANKANDBRANCHNM , SECTIONCODERF=@SECTIONCODE , ADDUPSECCODERF=@ADDUPSECCODE , SUPPLIERCDRF=@SUPPLIERCD , SUPPLIERNM1RF=@SUPPLIERNM1 , SUPPLIERNM2RF=@SUPPLIERNM2 , SUPPLIERSNMRF=@SUPPLIERSNM , PROCDATERF=@PROCDATE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , VALIDITYTERMRF=@VALIDITYTERM , DRAFTSTMNTDATERF=@DRAFTSTMNTDATE , OUTLINE1RF=@OUTLINE1 , OUTLINE2RF=@OUTLINE2 , SUPPLIERFORMALRF=@SUPPLIERFORMAL , PAYMENTSLIPNORF=@PAYMENTSLIPNO , PAYMENTROWNORF=@PAYMENTROWNO , PAYMENTDATERF=@PAYMENTDATE " + Environment.NewLine;
                            //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                            findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                            findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                            findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)payDraftDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (payDraftDataWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //　画面のデータ、insert処理
                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO PAYDRAFTDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PAYDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, PAYMENTRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, SUPPLIERFORMALRF, PAYMENTSLIPNORF, PAYMENTROWNORF, PAYMENTDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PAYDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @PAYMENT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @SUPPLIERFORMAL, @PAYMENTSLIPNO, @PAYMENTROWNO, @PAYMENTDATE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)payDraftDataWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (myReader.IsClosed == false) myReader.Close();

                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraPayDraftNo = sqlCommand.Parameters.Add("@PAYDRAFTNO", SqlDbType.NVarChar);
                        SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
                        SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                        SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                        SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
                        SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                        SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                        SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                        SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
                        SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                        SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                        SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
                        SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
                        SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
                        SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@PAYMENTSLIPNO", SqlDbType.Int);
                        SqlParameter paraPaymentRowNo = sqlCommand.Parameters.Add("@PAYMENTROWNO", SqlDbType.Int);
                        SqlParameter paraPaymentDate = sqlCommand.Parameters.Add("@PAYMENTDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(payDraftDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.LogicalDeleteCode);
                        paraPayDraftNo.Value = SqlDataMediator.SqlSetString(payDraftDataWork.PayDraftNo);
                        paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftKindCd);
                        paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftDivide);
                        paraPayment.Value = SqlDataMediator.SqlSetInt64(payDraftDataWork.Payment);
                        paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.BankAndBranchCd);
                        paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(payDraftDataWork.BankAndBranchNm);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SectionCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.AddUpSecCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.SupplierCd);
                        paraSupplierNm1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierNm1);
                        paraSupplierNm2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierNm2);
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(payDraftDataWork.SupplierSnm);
                        paraProcDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.ProcDate);
                        paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                        paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.ValidityTerm);
                        paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.DraftStmntDate);
                        paraOutline1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.Outline1);
                        paraOutline2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.Outline2);
                        paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.SupplierFormal);
                        paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentSlipNo);
                        paraPaymentRowNo.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.PaymentRowNo);
                        paraPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.PaymentDate);

                        sqlCommand.ExecuteNonQuery();

                        ayList.Add(payDraftDataWork);
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "PayDraftDatatDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PayDraftDatatDB.Write" + status);
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

            payDraftDataWorkList = ayList;

            return status;
        }
        # endregion

        #region [LogicalDelete]
        /// <summary>
        /// 支払手形データマスタ情報を論理削除します。
        /// </summary>
        /// <remarks>
        /// <param name="objPayDraftDatatList">PayDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタ情報を論理削除します。</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int LogicalDelete(ref object objPayDraftDatatList)
        {
            return LogicalDelete(ref objPayDraftDatatList, 1);
        }

        /// <summary>
        /// 論理削除支払手形データマスタ情報情報を復活します
        /// </summary>
        /// <remarks>
        /// <param name="objpayDraftDatatList">EmpSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除支払手形データマスタ情報情報を復活します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object objpayDraftDatatList)
        {
            return LogicalDelete(ref objpayDraftDatatList, 0);
        }

        /// <summary>
        /// 支払手形データマスタ情報の論理削除を操作します
        /// </summary>
        /// <remarks>
        /// <param name="objPayDraftDatatList">PayDraftDataWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private int LogicalDelete(ref object objPayDraftDatatList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList payDraftDataWorkList = objPayDraftDatatList as ArrayList;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = LogicalDeleteProc(ref payDraftDataWorkList, procMode, ref sqlConnection, ref sqlTransaction);

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
                if (procMode == 1)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "EmpSalesTargetDB.LogicalDeleteEmpSalesTarget :" + procModestr);

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
        /// 支払手形データマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <remarks>
        /// <param name="payDraftDataWorkList">payDraftDataWorkオブジェクト</param>
        /// <param name="deleteMode">関数区分 1:論理削除 0:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払手形データマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int LogicalDeleteProc(ref ArrayList payDraftDataWorkList, int deleteMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                for (int i = 0; i < payDraftDataWorkList.Count; i++)
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    PayDraftDataWork payDraftDataWork = payDraftDataWorkList[i] as PayDraftDataWork;

                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM PAYDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != payDraftDataWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        //現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE文]
                        sqlText = string.Empty;
                        //sqlText += "UPDATE PAYDRAFTDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "UPDATE PAYDRAFTDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                        findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)payDraftDataWork;
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
                    if (deleteMode == 1)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                            sqlCommand.Cancel();
                            return status;
                        }
                        else if (logicalDelCd == 0) payDraftDataWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else payDraftDataWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1) payDraftDataWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                            sqlCommand.Cancel();
                            return status;
                        }
                    }

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(payDraftDataWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(payDraftDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(payDraftDataWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "PayDraftDatatDB.Write" + status);
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
        # endregion

        #region [Delete]
        /// <summary>
        /// 支払手形データマスタ情報を物理削除します
        /// </summary>
        /// <param name="objPayDraftDatatList">PayDraftDataWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタ情報を物理削除します</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public int Delete(ref object objPayDraftDatatList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                ArrayList payDraftDataWorkList = objPayDraftDatatList as ArrayList;

                status = DeleteProc(payDraftDataWorkList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Delete");
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
        /// 支払手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="payDraftDataWorkList">支払手形データマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 支払手形データマスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private int DeleteProc(ArrayList payDraftDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            try
            {
                for (int i = 0; i < payDraftDataWorkList.Count; i++)
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    PayDraftDataWork payDraftDataWork = payDraftDataWorkList[i] as PayDraftDataWork;

                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM PAYDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayDraftNo = sqlCommand.Parameters.Add("@FINDPAYDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranch = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                    findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != payDraftDataWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // データは全て削除
                        # region [DELETE文]
                        sqlText = string.Empty;
                        //sqlText += "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO";// DEL zhuhh 2013/01/10 for Redmime #34123
                        sqlText += "DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PAYDRAFTNORF=@FINDPAYDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE";// ADD zhuhh 2013/01/10 for Redmime #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = payDraftDataWork.EnterpriseCode;
                        findParaPayDraftNo.Value = payDraftDataWork.PayDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranch.Value = payDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(payDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteProc");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PayDraftDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PayDraftDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>           : redmine #34123 手形データ重複した伝票番号の登録を出来る様にする</br>
        /// </remarks>
        private PayDraftDataWork CopyToPayDraftDataWorkFromReader(ref SqlDataReader myReader)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            if (myReader != null && payDraftDataWork != null)
            {
                # region クラスへ格納
                payDraftDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                payDraftDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                payDraftDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                payDraftDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                payDraftDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                payDraftDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                payDraftDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                payDraftDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                payDraftDataWork.PayDraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYDRAFTNORF"));
                payDraftDataWork.DraftKindCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDCDRF"));
                payDraftDataWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                payDraftDataWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
                payDraftDataWork.BankAndBranchCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKANDBRANCHCDRF"));
                payDraftDataWork.BankAndBranchNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKANDBRANCHNMRF"));
                //payDraftDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// DEL zhuhh 2013/01/10 for Redmine #34123
                payDraftDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")).Trim();// ADD zhuhh 2013/01/10 for Redmine #34123
                payDraftDataWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                payDraftDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                payDraftDataWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                payDraftDataWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                payDraftDataWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                payDraftDataWork.ProcDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDATERF"));
                payDraftDataWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                payDraftDataWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                payDraftDataWork.DraftStmntDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTSTMNTDATERF"));
                payDraftDataWork.Outline1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE1RF"));
                payDraftDataWork.Outline2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINE2RF"));
                payDraftDataWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                payDraftDataWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                payDraftDataWork.PaymentRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
                payDraftDataWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));

                # endregion
            }
            return payDraftDataWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
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
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 葛軍</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
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
        # endregion
    }
  
}
