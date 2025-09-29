//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送受信対象設定マスタメンテナンス
// プログラム概要   : 送受信対象設定の変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///送受信対象マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送受信対象マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.04.22</br>
    /// <br>Update Note: 2020/09/25 陳艶丹</br>
    /// <br>管理番号   : 11600006-00</br>
    /// <br>           : PMKOBETSU-3877の対応</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SecMngSndRcvDB : RemoteDB, ISendSetDB
    {
        /// <summary>
        /// 送受信対象マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public SecMngSndRcvDB()
            : base("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork", "SENDSET")
        {

        }

        # region [Search]
        /// <summary>
        /// 送受信対象マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSecMngSndRcvList">検索結果</param>
        /// <param name="paraSecMngSndRcvWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信対象マスタのキー値が一致する、全ての送受信対象マスタ情報を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        public int Search(out object outSecMngSndRcvList, object paraSecMngSndRcvWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _secMngSndRcvList = null;
            SecMngSndRcvWork secMngSndRcvWork = null;

            outSecMngSndRcvList = new CustomSerializeArrayList();

            try
            {
                secMngSndRcvWork = paraSecMngSndRcvWork as SecMngSndRcvWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchProc(out _secMngSndRcvList, secMngSndRcvWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

                if (_secMngSndRcvList != null)
                {
                    (outSecMngSndRcvList as CustomSerializeArrayList).AddRange(_secMngSndRcvList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SendSetDB.Search(out object, object, int, LogicalMode)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// 送受信対象詳細マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSecMngSndRcvDtlList">検索結果</param>
        /// <param name="paraSecMngSndRcvDtlWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信対象詳細マスタのキー値が一致する、全ての送受信対象詳細マスタ情報を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        public int SearchDtl(out object outSecMngSndRcvDtlList, object paraSecMngSndRcvDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _secMngSndRcvDtlList = null;
            SecMngSndRcvDtlWork secMngSndRcvDtlWork = null;

            outSecMngSndRcvDtlList = new CustomSerializeArrayList();

            try
            {
                secMngSndRcvDtlWork = paraSecMngSndRcvDtlWork as SecMngSndRcvDtlWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchDtlProc(out _secMngSndRcvDtlList, secMngSndRcvDtlWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

                if (_secMngSndRcvDtlList != null)
                {
                    (outSecMngSndRcvDtlList as CustomSerializeArrayList).AddRange(_secMngSndRcvDtlList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SendSetDB.SearchDtl(out object, object, int, LogicalMode)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// 送受信対象マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="secMngSndRcvList">送受信対象マスタ情報を格納する ArrayList</param>
        /// <param name="secMngSndRcvWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信対象マスタのキー値が一致する、全ての送受信対象マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
        private int SearchProc(out ArrayList secMngSndRcvList, SecMngSndRcvWork secMngSndRcvWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SUPL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,SUPL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += " ,SUPL.MASTERNAMERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.FILENMRF" + Environment.NewLine;
                sqlText += " ,SUPL.USERGUIDEDIVCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.SECMNGSENDDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.SECMNGRECVDIVRF" + Environment.NewLine;
                // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                sqlText += " ,SUPL.ACPTANODRSENDDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.ACPTANODRRECVDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.SHIPMENTSENDDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.SHIPMENTRECVDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.ESTIMATESENDDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.ESTIMATERECVDIVRF" + Environment.NewLine;
                // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSNDRCVRF AS SUPL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, secMngSndRcvWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSecMngSndSetWorkFromReader(ref myReader));
                }

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
                status = base.WriteSQLErrorLog(sqlex, "SendSetDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SendSetDB.SearchProc" + status);
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

            secMngSndRcvList = al;

            return status;

        }

        /// <summary>
        /// 送受信対象詳細マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="secMngSndRcvDtlList">送受信対象詳細マスタ情報を格納する ArrayList</param>
        /// <param name="secMngSndRcvDtlWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信対象詳細マスタのキー値が一致する、全ての送受信対象詳細マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        private int SearchDtlProc(out ArrayList secMngSndRcvDtlList, SecMngSndRcvDtlWork secMngSndRcvDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SUPL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,SUPL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.FILENMRF" + Environment.NewLine;
                sqlText += " ,SUPL.ITEMIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.ITEMNAMERF" + Environment.NewLine;
                sqlText += " ,SUPL.DATAUPDATEDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSNDRCVDTLRF AS SUPL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                sqlCommand.CommandText += MakeDtlWhereString(ref sqlCommand, secMngSndRcvDtlWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSecMngSndDtlSetWorkFromReader(ref myReader));
                }

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
                status = base.WriteSQLErrorLog(sqlex, "SendSetDB.SearchDtlProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SendSetDB.SearchDtlProc" + status);
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

            secMngSndRcvDtlList = al;

            return status;

        }

        # endregion

        # region [Write]
        /// <summary>
        /// 送受信対象マスタ情報を更新します。
        /// </summary>
        /// <param name="objsecMngSndRcvWorkList">更新する送受信対象マスタ情報</param>
        /// <param name="objsecMngSndRcvDtlWorkList">更新する送受信対象詳細マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objsecMngSndRcvWorkList に格納されている送受信対象マスタ情報を更新します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        public int Write(ref object objsecMngSndRcvWorkList, ref object objsecMngSndRcvDtlWorkList, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList secMngSndRcvWorkList = objsecMngSndRcvWorkList as ArrayList;

                ArrayList secMngSndRcvDtlWorkList = objsecMngSndRcvDtlWorkList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.WriteProc(ref secMngSndRcvWorkList, ref sqlConnection, ref sqlTransaction);

                if (status == 0)
                {
                    status = this.WriteProcDtl(ref secMngSndRcvDtlWorkList, ref sqlConnection, ref sqlTransaction);

                    // 戻り値セット
                    objsecMngSndRcvDtlWorkList = secMngSndRcvDtlWorkList;
                }

                // 戻り値セット
                objsecMngSndRcvWorkList = secMngSndRcvWorkList;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SendSetDB.Write(ref object)", status);
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
        /// 送受信対象マスタ情報を更新します。
        /// </summary>
        /// <param name="secMngSndRcvWorkList">更新する送受信対象マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SecMngSndRcvWork に格納されている送受信対象マスタ情報を更新します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
        private int WriteProc(ref ArrayList secMngSndRcvWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                foreach (SecMngSndRcvWork secMngSndRcvWork in secMngSndRcvWorkList)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SECMNGSNDRCVRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DISPLAYORDERRF = @FINDDISPLAYORDER" + Environment.NewLine;
                    sqlText += "  AND FILEIDRF = @FINDFILEID" + Environment.NewLine;
                    sqlText += "  AND USERGUIDEDIVCDRF = @FINDUSERGUIDEDIVCD" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion
                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findDisplayOrder = sqlCommand.Parameters.Add("@FINDDISPLAYORDER", SqlDbType.Int);
                    SqlParameter findFileId = sqlCommand.Parameters.Add("@FINDFILEID", SqlDbType.NChar);
                    SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.EnterpriseCode);
                    findDisplayOrder.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.DisplayOrder);
                    findFileId.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.FileId);
                    findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.UserGuideDivCd);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != secMngSndRcvWork.UpdateDateTime)
                        {
                            if (secMngSndRcvWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SECMNGSNDRCVRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,SECMNGSENDDIVRF = @SECMNGSENDDIV" + Environment.NewLine;
                        sqlText += " ,SECMNGRECVDIVRF = @SECMNGRECVDIV" + Environment.NewLine;
                        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                        sqlText += " ,ACPTANODRSENDDIVRF = @ACPTANODRSENDDIV" + Environment.NewLine;
                        sqlText += " ,ACPTANODRRECVDIVRF = @ACPTANODRRECVDIV" + Environment.NewLine;
                        sqlText += " ,SHIPMENTSENDDIVRF = @SHIPMENTSENDDIV" + Environment.NewLine;
                        sqlText += " ,SHIPMENTRECVDIVRF = @SHIPMENTRECVDIV" + Environment.NewLine;
                        sqlText += " ,ESTIMATESENDDIVRF = @ESTIMATESENDDIV" + Environment.NewLine;
                        sqlText += " ,ESTIMATERECVDIVRF = @ESTIMATERECVDIV" + Environment.NewLine;
                        // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND DISPLAYORDERRF = @FINDDISPLAYORDER" + Environment.NewLine;
                        sqlText += "  AND FILEIDRF = @FINDFILEID" + Environment.NewLine;
                        sqlText += "  AND USERGUIDEDIVCDRF = @FINDUSERGUIDEDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.EnterpriseCode);
                        findDisplayOrder.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.DisplayOrder);
                        findFileId.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.FileId);
                        findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.UserGuideDivCd);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)secMngSndRcvWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (secMngSndRcvWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    # region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSecMngSendDiv = sqlCommand.Parameters.Add("@SECMNGSENDDIV", SqlDbType.Int);
                    SqlParameter paraSecMngRecvDiv = sqlCommand.Parameters.Add("@SECMNGRECVDIV", SqlDbType.Int);
                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                    SqlParameter paraAcptAnOdrSendDiv = sqlCommand.Parameters.Add("@ACPTANODRSENDDIV", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrRecvDiv = sqlCommand.Parameters.Add("@ACPTANODRRECVDIV", SqlDbType.Int);
                    SqlParameter paraShipmentSendDiv = sqlCommand.Parameters.Add("@SHIPMENTSENDDIV", SqlDbType.Int);
                    SqlParameter paraShipmentRecvDiv = sqlCommand.Parameters.Add("@SHIPMENTRECVDIV", SqlDbType.Int);
                    SqlParameter paraEstimateSendDiv = sqlCommand.Parameters.Add("@ESTIMATESENDDIV", SqlDbType.Int);
                    SqlParameter paraEstimateRecvDiv = sqlCommand.Parameters.Add("@ESTIMATERECVDIV", SqlDbType.Int);
                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
                    # endregion

                    # region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSndRcvWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSndRcvWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secMngSndRcvWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.LogicalDeleteCode);
                    paraSecMngSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.SecMngSendDiv);
                    paraSecMngRecvDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.SecMngRecvDiv);
                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                    paraAcptAnOdrSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.AcptAnOdrSendDiv);
                    paraAcptAnOdrRecvDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.AcptAnOdrRecvDiv);
                    paraShipmentSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.ShipmentSendDiv);
                    paraShipmentRecvDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.ShipmentRecvDiv);
                    paraEstimateSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.EstimateSendDiv);
                    paraEstimateRecvDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvWork.EstimateRecvDiv);
                    // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al.Add(secMngSndRcvWork);

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SendSetDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SendSetDB.Write" + status);
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

            secMngSndRcvWorkList = al;

            return status;
        }

        /// <summary>
        /// 送受信対象詳細マスタ情報を更新します。
        /// </summary>
        /// <param name="secMngSndRcvDtlWorkList">更新する送受信対象詳細マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : enterpriseSetWork に格納されている送受信対象詳細マスタ情報を更新します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        private int WriteProcDtl(ref ArrayList secMngSndRcvDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in secMngSndRcvDtlWorkList)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SECMNGSNDRCVDTLRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND FILEIDRF = @FINDFILEID" + Environment.NewLine;
                    sqlText += "  AND ITEMIDRF = @FINDITEMID" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion
                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findFileId = sqlCommand.Parameters.Add("@FINDFILEID", SqlDbType.NChar);
                    SqlParameter findItemId = sqlCommand.Parameters.Add("@FINDITEMID", SqlDbType.NChar);

                    // Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.EnterpriseCode);
                    findFileId.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.FileId);
                    findItemId.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.ItemId);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != secMngSndRcvDtlWork.UpdateDateTime)
                        {
                            if (secMngSndRcvDtlWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SECMNGSNDRCVDTLRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,DATAUPDATEDIVRF = @DATAUPDATEDIVRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND FILEIDRF = @FINDFILEID" + Environment.NewLine;
                        sqlText += "  AND ITEMIDRF = @FINDITEMID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.EnterpriseCode);
                        findFileId.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.FileId);
                        findItemId.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.ItemId);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)secMngSndRcvDtlWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (secMngSndRcvDtlWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    # region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraDataUpdateDiv = sqlCommand.Parameters.Add("@DATAUPDATEDIVRF", SqlDbType.Int);
                    # endregion

                    # region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSndRcvDtlWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSndRcvDtlWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secMngSndRcvDtlWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvDtlWork.LogicalDeleteCode);
                    paraDataUpdateDiv.Value = SqlDataMediator.SqlSetInt32(secMngSndRcvDtlWork.DataUpdateDiv);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                    al.Add(secMngSndRcvDtlWork);

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SendSetDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SendSetDB.Write" + status);
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

            secMngSndRcvDtlWorkList = al;

            return status;
        }

        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="secMngSndRcvWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SecMngSndRcvWork secMngSndRcvWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  SUPL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY" + Environment.NewLine;
            retstring += " SUPL.DISPLAYORDERRF" + Environment.NewLine;

            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="secMngSndRcvDtlWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        private string MakeDtlWhereString(ref SqlCommand sqlCommand, SecMngSndRcvDtlWork secMngSndRcvDtlWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  SUPL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSndRcvDtlWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY" + Environment.NewLine;
            retstring += " SUPL.DISPLAYORDERRF, SUPL.FILEIDRF, SUPL.ITEMIDRF " + Environment.NewLine;

            return retstring;
        }

        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SecMngSndRcvWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngSndRcvWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
        /// </remarks>
        private SecMngSndRcvWork CopyToSecMngSndSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();

            if (myReader != null)
            {
                # region クラスへ格納
                secMngSndRcvWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                secMngSndRcvWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                secMngSndRcvWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                secMngSndRcvWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                secMngSndRcvWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                secMngSndRcvWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                secMngSndRcvWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                secMngSndRcvWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                secMngSndRcvWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                secMngSndRcvWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
                secMngSndRcvWork.FileNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
                secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                secMngSndRcvWork.SecMngSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGSENDDIVRF"));
                secMngSndRcvWork.SecMngRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGRECVDIVRF"));
                // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
                secMngSndRcvWork.AcptAnOdrSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSENDDIVRF"));
                secMngSndRcvWork.AcptAnOdrRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRRECVDIVRF"));
                secMngSndRcvWork.ShipmentSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTSENDDIVRF"));
                secMngSndRcvWork.ShipmentRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTRECVDIVRF"));
                secMngSndRcvWork.EstimateSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATESENDDIVRF"));
                secMngSndRcvWork.EstimateRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATERECVDIVRF"));
                // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
                # endregion
            }

            return secMngSndRcvWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → SecMngSndRcvDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        private SecMngSndRcvDtlWork CopyToSecMngSndDtlSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngSndRcvDtlWork secMngSndRcvDtlWork = new SecMngSndRcvDtlWork();

            if (myReader != null)
            {
                # region クラスへ格納
                secMngSndRcvDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                secMngSndRcvDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                secMngSndRcvDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                secMngSndRcvDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                secMngSndRcvDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                secMngSndRcvDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                secMngSndRcvDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                secMngSndRcvDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                secMngSndRcvDtlWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
                secMngSndRcvDtlWork.FileNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
                secMngSndRcvDtlWork.ItemId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMIDRF"));
                secMngSndRcvDtlWork.ItemName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMNAMERF"));
                secMngSndRcvDtlWork.DataUpdateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAUPDATEDIVRF"));
                secMngSndRcvDtlWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                # endregion
            }

            return secMngSndRcvDtlWork;
        }

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
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
