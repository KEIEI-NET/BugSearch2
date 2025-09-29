//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : EDI連携設定マスタリモートオブジェクト
// プログラム概要   : EDI連携設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11370098-00  作成担当 : 陳艶丹
// 作 成 日  2017/11/16   修正内容 : 新規作成
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// EDI連携設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : EDI連携設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/11/16</br>
    /// </remarks>
    [Serializable]
    public class EDICooperatStDB : RemoteDB, IEDICooperatStDB
    {
        /// <summary>
        /// EDI連携設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public EDICooperatStDB()
            : base("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork", "EDICOOPERATSTRF")
        {

        }

        # region [Search]
        /// <summary>
        ///EDI連携設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="paraObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="refObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI連携設定マスタ情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public int Search(object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out object refObj)
        {
            SqlConnection sqlConnection = null;
            refObj = null;
            ArrayList eDICooperatStList = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    EDICooperatStWork paraWork = (EDICooperatStWork)paraObj;
                    // EDI連携設定マスタ対象取得
                    status = SearchProc(paraWork, readMode, logicalMode, out eDICooperatStList, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        refObj = (object)eDICooperatStList;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.Search Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        /// <summary>
        ///EDI連携設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="paraWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="eDICooperatStList">検索結果</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI連携設定マスタ情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private int SearchProc(EDICooperatStWork paraWork, int readMode, ConstantManagement.LogicalMode logicalMode, out ArrayList eDICooperatStList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            eDICooperatStList = new ArrayList();
            SqlCommand sqlCommand = null;
            using (sqlCommand = new SqlCommand("", sqlConnection))
             {
                 try
                 {
                     StringBuilder sqlText = new StringBuilder();
                     # region [SELECT文]
                     sqlText.AppendLine(" SELECT ");
                     sqlText.AppendLine(" CREATEDATETIMERF, ");      // 作成日時
                     sqlText.AppendLine(" ENTERPRISECODERF, ");      // 企業コード
                     sqlText.AppendLine(" FILEHEADERGUIDRF, ");      // GUID
                     sqlText.AppendLine(" UPDEMPLOYEECODERF, ");     // 更新従業員コード
                     sqlText.AppendLine(" UPDASSEMBLYID1RF, ");      // 更新アセンブリID1
                     sqlText.AppendLine(" UPDASSEMBLYID2RF, ");      // 更新アセンブリID2
                     sqlText.AppendLine(" UPDATEDATETIMERF, ");      // 更新日時
                     sqlText.AppendLine(" LOGICALDELETECODERF, ");   // 論理削除区分
                     sqlText.AppendLine(" SECTIONCODERF, ");         // 拠点コード
                     sqlText.AppendLine(" CUSTOMERCODERF, ");        // 得意先コード
                     sqlText.AppendLine(" GOODSKINDCODERF, ");       // 商品属性
                     sqlText.AppendLine(" COOPERATOFFICECODERF, ");  // 連携事業所コード
                     sqlText.AppendLine(" COOPERATCUSTCODERF,");     // 連携得意先コード
                     sqlText.AppendLine(" TRADCOMPCDRF, ");          // 部品商コード
                     sqlText.AppendLine(" TRADCOMPNAMERF, ");        // 部品商名称
                     sqlText.AppendLine(" GOODSCODERF, ");           // 商品コード
                     sqlText.AppendLine(" INCREASEBLGOODSCODERF, ");    // 値増BL商品コード
                     sqlText.AppendLine(" DISCOUNTBLGOODSCODERF ");    // 値引BL商品コード
                     sqlText.AppendLine(" FROM EDICOOPERATSTRF WITH (READUNCOMMITTED) ");        //EDI連携設定マスタ
                     sqlText.AppendLine(MakeWhereString(ref sqlCommand, paraWork, logicalMode));
                     # endregion

                     sqlCommand.CommandText = sqlText.ToString();
                     // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            EDICooperatStWork eDICooperatStWork = new EDICooperatStWork();
                            eDICooperatStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            eDICooperatStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            eDICooperatStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            eDICooperatStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            eDICooperatStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            eDICooperatStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            eDICooperatStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            eDICooperatStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            eDICooperatStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                            eDICooperatStWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                            eDICooperatStWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                            eDICooperatStWork.CooperatOfficeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COOPERATOFFICECODERF"));
                            eDICooperatStWork.CooperatCustCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COOPERATCUSTCODERF"));
                            eDICooperatStWork.TradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPCDRF"));
                            eDICooperatStWork.TradCompName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));
                            eDICooperatStWork.GoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCODERF"));
                            eDICooperatStWork.IncreaseBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INCREASEBLGOODSCODERF"));
                            eDICooperatStWork.DiscountBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISCOUNTBLGOODSCODERF"));
                            eDICooperatStList.Add(eDICooperatStWork);
                        }

                        // 検索結果がある場合
                        if (eDICooperatStList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }

                 }
                 catch (SqlException ex)
                 {
                     // 基底クラスに例外を渡して処理してもらう
                     status = base.WriteSQLErrorLog(ex);
                 }
                 catch (Exception ex)
                 {
                     status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                     base.WriteErrorLog(ex, "EDICooperatStDB.SearchProc Exception=" + ex.Message, status);
                 }
             }
             return status;
         }

        # endregion

        # region [Delete]
        /// <summary>
        /// EDI連携設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">EDICooperatStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI連携設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public int Delete(object parabyte)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    EDICooperatStWork eDICooperatStWork = parabyte as EDICooperatStWork;
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    // EDI連携設定マスタ対象物理削除
                    status = this.DeleteProc(eDICooperatStWork, ref sqlConnection, ref sqlTransaction);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.Delete Exception=" + ex.Message, status);
                }
                finally
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// EDI連携設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="eDICooperatStWork">EDI連携設定マスタ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI連携設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private int DeleteProc(EDICooperatStWork eDICooperatStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" UPDATEDATETIMERF ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" EDICOOPERATSTRF");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                    sqlText.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (updateDateTime != eDICooperatStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        StringBuilder sqlTextDel = new StringBuilder();
                        #region
                        sqlTextDel.AppendLine(" DELETE ");
                        sqlTextDel.AppendLine(" FROM ");
                        sqlTextDel.AppendLine(" EDICOOPERATSTRF");
                        sqlTextDel.AppendLine(" WHERE ");
                        sqlTextDel.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                        sqlTextDel.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                        sqlTextDel.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                        #endregion
                        sqlCommand.CommandText = sqlTextDel.ToString();

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);
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
                catch (SqlException ex)
                {
                    // 基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.DeleteProc Exception=" + ex.Message, status);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (myReader.IsClosed == false)
                        {
                            myReader.Close();
                        }
                    }
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }
            return status;
        }
        # endregion

        #region [write]
        /// <summary>
        /// EDI連携設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="eDICooperatStObj">EDI連携設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI連携設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        public int Write(ref object eDICooperatStObj)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    EDICooperatStWork eDICooperatStWork = (EDICooperatStWork)eDICooperatStObj;

                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    // EDI連携設定マスタデータ登録
                    status = WriteProc(ref eDICooperatStWork, ref sqlConnection, ref sqlTransaction);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.Write Exception=" + ex.Message, status);
                }
                finally
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// EDI連携設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="eDICooperatStWork">追加・更新するEDI連携設定マスタ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDICooperatStWork に格納されているEDI連携設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private int WriteProc(ref EDICooperatStWork eDICooperatStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (eDICooperatStWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" UPDATEDATETIMERF ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" EDICOOPERATSTRF");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                    sqlText.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                    #endregion
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (updateDateTime != eDICooperatStWork.UpdateDateTime)
                        {
                            if (eDICooperatStWork.UpdateDateTime == DateTime.MinValue)
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

                        StringBuilder sqlTextUp = new StringBuilder();
                        #region
                        sqlTextUp.AppendLine(" UPDATE ");
                        sqlTextUp.AppendLine(" EDICOOPERATSTRF");
                        sqlTextUp.AppendLine(" SET");
                        sqlTextUp.AppendLine(" CREATEDATETIMERF=@CREATEDATETIME");
                        sqlTextUp.AppendLine(" , UPDATEDATETIMERF=@UPDATEDATETIME");
                        sqlTextUp.AppendLine(" , ENTERPRISECODERF=@ENTERPRISECODE");
                        sqlTextUp.AppendLine(" , FILEHEADERGUIDRF=@FILEHEADERGUID");
                        sqlTextUp.AppendLine(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE");
                        sqlTextUp.AppendLine(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1");
                        sqlTextUp.AppendLine(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2");
                        sqlTextUp.AppendLine(" , LOGICALDELETECODERF=@LOGICALDELETECODE");
                        sqlTextUp.AppendLine(" , SECTIONCODERF=@SECTIONCODE");
                        sqlTextUp.AppendLine(" , CUSTOMERCODERF=@CUSTOMERCODE");
                        sqlTextUp.AppendLine(" , GOODSKINDCODERF=@GOODSKINDCODE");
                        sqlTextUp.AppendLine(" , COOPERATOFFICECODERF=@COOPERATOFFICECODE");
                        sqlTextUp.AppendLine(" , COOPERATCUSTCODERF=@COOPERATCUSTCODE");
                        sqlTextUp.AppendLine(" , TRADCOMPCDRF=@TRADCOMPCD");
                        sqlTextUp.AppendLine(" , TRADCOMPNAMERF=@TRADCOMPNAME");
                        sqlTextUp.AppendLine(" , GOODSCODERF=@GOODSCODE");
                        sqlTextUp.AppendLine(" , INCREASEBLGOODSCODERF=@INCREASEBLGOODSCODE");
                        sqlTextUp.AppendLine(" , DISCOUNTBLGOODSCODERF=@DISCOUNTBLGOODSCODE");
                        sqlTextUp.AppendLine(" WHERE ");
                        sqlTextUp.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                        sqlTextUp.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                        sqlTextUp.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                        #endregion
                        sqlCommand.CommandText = sqlTextUp.ToString();

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)eDICooperatStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (eDICooperatStWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        StringBuilder sqlTextIns = new StringBuilder();
                        #region
                        sqlTextIns.AppendLine(" INSERT INTO ");
                        sqlTextIns.AppendLine(" EDICOOPERATSTRF");
                        sqlTextIns.AppendLine(" (CREATEDATETIMERF");
                        sqlTextIns.AppendLine(" , UPDATEDATETIMERF");
                        sqlTextIns.AppendLine(" , ENTERPRISECODERF");
                        sqlTextIns.AppendLine(" , FILEHEADERGUIDRF");
                        sqlTextIns.AppendLine(" , UPDEMPLOYEECODERF");
                        sqlTextIns.AppendLine(" , UPDASSEMBLYID1RF");
                        sqlTextIns.AppendLine(" , UPDASSEMBLYID2RF");
                        sqlTextIns.AppendLine(" , LOGICALDELETECODERF");
                        sqlTextIns.AppendLine(" , SECTIONCODERF");
                        sqlTextIns.AppendLine(" , CUSTOMERCODERF");
                        sqlTextIns.AppendLine(" , GOODSKINDCODERF");
                        sqlTextIns.AppendLine(" , COOPERATOFFICECODERF");
                        sqlTextIns.AppendLine(" , COOPERATCUSTCODERF");
                        sqlTextIns.AppendLine(" , TRADCOMPCDRF");
                        sqlTextIns.AppendLine(" , TRADCOMPNAMERF");
                        sqlTextIns.AppendLine(" , GOODSCODERF");
                        sqlTextIns.AppendLine(" , INCREASEBLGOODSCODERF");
                        sqlTextIns.AppendLine(" , DISCOUNTBLGOODSCODERF");
                        sqlTextIns.AppendLine(" ) VALUES (");
                        sqlTextIns.AppendLine(" @CREATEDATETIME");
                        sqlTextIns.AppendLine(" , @UPDATEDATETIME");
                        sqlTextIns.AppendLine(" , @ENTERPRISECODE");
                        sqlTextIns.AppendLine(" , @FILEHEADERGUID");
                        sqlTextIns.AppendLine(" , @UPDEMPLOYEECODE");
                        sqlTextIns.AppendLine(" , @UPDASSEMBLYID1");
                        sqlTextIns.AppendLine(" , @UPDASSEMBLYID2");
                        sqlTextIns.AppendLine(" , @LOGICALDELETECODE");
                        sqlTextIns.AppendLine(" , @SECTIONCODE");
                        sqlTextIns.AppendLine(" , @CUSTOMERCODE");
                        sqlTextIns.AppendLine(" , @GOODSKINDCODE");
                        sqlTextIns.AppendLine(" , @COOPERATOFFICECODE");
                        sqlTextIns.AppendLine(" , @COOPERATCUSTCODE");
                        sqlTextIns.AppendLine(" , @TRADCOMPCD");
                        sqlTextIns.AppendLine(" , @TRADCOMPNAME");
                        sqlTextIns.AppendLine(" , @GOODSCODE");
                        sqlTextIns.AppendLine(" , @INCREASEBLGOODSCODE");
                        sqlTextIns.AppendLine(" , @DISCOUNTBLGOODSCODE )");
                        #endregion
                        sqlCommand.CommandText = sqlTextIns.ToString();
                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)eDICooperatStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

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
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                    SqlParameter paraCooperatOfficeCode = sqlCommand.Parameters.Add("@COOPERATOFFICECODE", SqlDbType.NVarChar);
                    SqlParameter paraCooperatCustCode = sqlCommand.Parameters.Add("@COOPERATCUSTCODE", SqlDbType.NVarChar);
                    SqlParameter paraTradCompCd = sqlCommand.Parameters.Add("@TRADCOMPCD", SqlDbType.NVarChar);
                    SqlParameter paraTradCompName = sqlCommand.Parameters.Add("@TRADCOMPNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsCode = sqlCommand.Parameters.Add("@GOODSCODE", SqlDbType.NVarChar);
                    SqlParameter paraIncreaseBLGoodsCode = sqlCommand.Parameters.Add("@INCREASEBLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraDiscountBLGoodsCode = sqlCommand.Parameters.Add("@DISCOUNTBLGOODSCODE", SqlDbType.Int);

                    # region Parameterオブジェクトへ値設定(更新用)
                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDICooperatStWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDICooperatStWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(eDICooperatStWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);
                    paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.GoodsKindCode);
                    paraCooperatOfficeCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.CooperatOfficeCode);
                    paraCooperatCustCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.CooperatCustCode);
                    paraTradCompCd.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.TradCompCd);
                    paraTradCompName.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.TradCompName);
                    paraGoodsCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.GoodsCode);
                    paraIncreaseBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.IncreaseBLGoodsCode);
                    paraDiscountBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.DiscountBLGoodsCode);
                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "EDICooperatStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EDICooperatStDB.WriteProc Exception=" + ex.Message, status);
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

        #region [LogicalDelete]
        /// <summary>
        /// EDI連携設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="eDICooperatStObj">論理削除するEDI連携設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : EDI連携設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        public int LogicalDelete(ref object eDICooperatStObj)
        {
            return this.LogicalDeleteProc(ref eDICooperatStObj, 0);
        }

        /// <summary>
        /// EDI連携設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="eDICooperatStObj">論理削除を解除するEDI連携設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :EDI連携設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        public int RevivalLogicalDelete(ref object eDICooperatStObj)
        {
            return this.LogicalDeleteProc(ref eDICooperatStObj, 1);
        }

        /// <summary>
        ///EDI連携設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="eDICooperatStObj">論理削除を操作するEDI連携設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : EDI連携設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        private int LogicalDeleteProc(ref object eDICooperatStObj, int procMode)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    EDICooperatStWork paraList = eDICooperatStObj as EDICooperatStWork;
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    // EDI連携設定マスタ対象論理削除
                    status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
                    // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                    eDICooperatStObj = paraList;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.LogicalDeleteProc Exception=" + ex.Message, status);
                }
                finally
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        ///EDI連携設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="eDICooperatStWork">論理削除を操作するEDI連携設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : EDI連携設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        private int LogicalDeleteProc(ref EDICooperatStWork eDICooperatStWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            int logicalDelCd = 0;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" UPDATEDATETIMERF ");
                    sqlText.AppendLine(" , LOGICALDELETECODERF ");
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" EDICOOPERATSTRF");
                    sqlText.AppendLine(" WHERE ");
                    sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlText.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                    sqlText.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (updateDateTime != eDICooperatStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        StringBuilder sqlTextUpd = new StringBuilder();
                        #region
                        sqlTextUpd.AppendLine(" UPDATE ");
                        sqlTextUpd.AppendLine(" EDICOOPERATSTRF");
                        sqlTextUpd.AppendLine(" SET ");
                        sqlTextUpd.AppendLine(" UPDATEDATETIMERF=@UPDATEDATETIME");
                        sqlTextUpd.AppendLine(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE");
                        sqlTextUpd.AppendLine(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1");
                        sqlTextUpd.AppendLine(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2");
                        sqlTextUpd.AppendLine(" , LOGICALDELETECODERF=@LOGICALDELETECODE");
                        sqlTextUpd.AppendLine(" WHERE ");
                        sqlTextUpd.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                        sqlTextUpd.AppendLine(" AND SECTIONCODERF=@FINDSECTIONCODE ");
                        sqlTextUpd.AppendLine(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE ");
                        #endregion
                        sqlCommand.CommandText = sqlTextUpd.ToString();

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)eDICooperatStWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    // 論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                            return status;
                        }
                        else if (logicalDelCd == 0) eDICooperatStWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                        else eDICooperatStWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            eDICooperatStWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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

                    // Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDICooperatStWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(eDICooperatStWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(eDICooperatStWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }
                catch (SqlException ex)
                {
                    // 基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.DeleteProc Exception=" + ex.Message, status);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (myReader.IsClosed == false)
                        {
                            myReader.Close();
                        }
                    }
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }
            return status;
        }
        #endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, EDICooperatStWork paraWork, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder SqlText = new StringBuilder();
            SqlText.AppendLine("WHERE ");

            // 企業コード
            SqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

            // 論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                SqlText.AppendLine(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                SqlText.AppendLine(" AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE");
            }

            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            SqlText.AppendLine(" ORDER BY SECTIONCODERF, CUSTOMERCODERF");

            return SqlText.ToString();
        }

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
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
        # endregion
    }
}
