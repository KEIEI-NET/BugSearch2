//**********************************************************************//
// システム         ：.NSシリーズ                                       //
// プログラム名称   ：PMTAB全体設定（得意先別）マスタ                   //
// プログラム概要   ：PMTAB全体設定（得意先別）の登録・修正・削除を行う //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 管理番号  10902622-01     作成担当：許培珠
// 修正日    2013/05/31　    修正内容：新規作成
// ---------------------------------------------------------------------//
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


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB全体設定マスタメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 許培珠</br>
    /// <br>Date       : 2013/05/31</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class PmTabTtlStCustDB : RemoteWithAppLockDB, IPmTabTtlStCustDB
    {
        /// <summary>
        /// PMTAB全体設定マスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 許培珠</br>														   
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PmTabTtlStCustDB()
            :
        base("PMTAB09116D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStCustWork", "PMTABTTLSTCUSTRF")
        {
        }
        
        #region [Write]
        /// <summary>
        /// PMTAB全体設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="pmTabTtlStCustWork">PmTabTtlStCustWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        public int Write(ref object pmTabTtlStCustWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(pmTabTtlStCustWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSubSectionProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                pmTabTtlStCustWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.Write(ref object pmTabTtlStCustWork)");
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
        /// PMTAB全体設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">PmTabTtlStCustWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        private int WriteSubSectionProc(ref ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlTxt = new StringBuilder();   

            try
            {
                if (subSectionWorkList != null)
                {
                    for (int i = 0; i < subSectionWorkList.Count; i++)
                    {
                        PmTabTtlStCustWork pmTabTtlStCustWork = subSectionWorkList[i] as PmTabTtlStCustWork;

                        sqlTxt.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine);
                        sqlTxt.Append(" ,ENTERPRISECODERF" + Environment.NewLine);
                        sqlTxt.Append(" FROM PMTABTTLSTCUSTRF" + Environment.NewLine);
                        sqlTxt.Append("WHERE ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                        sqlTxt.Append("AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine);
                        sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);
                        sqlTxt.Remove(0,sqlTxt.Length);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                        findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                        //タイムアウト時間の設定（秒）
                        sqlCommand.CommandTimeout = 600;

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != pmTabTtlStCustWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (pmTabTtlStCustWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlTxt.Append("UPDATE PMTABTTLSTCUSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine);
                            sqlTxt.Append(" , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine);
                            sqlTxt.Append(" , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine);
                            sqlTxt.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlTxt.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine);
                            sqlTxt.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine);
                            sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine);
                            sqlTxt.Append(" , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);
                            sqlTxt.Append(" , BLPSENDDIVRF=@BLPSENDDIV" + Environment.NewLine);
                            sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                            sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                            sqlCommand.CommandText = sqlTxt.ToString();
                            sqlTxt.Remove(0, sqlTxt.Length);

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                            findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabTtlStCustWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (pmTabTtlStCustWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成

                            sqlTxt.Append("INSERT INTO PMTABTTLSTCUSTRF" + Environment.NewLine);
                            sqlTxt.Append(" (CREATEDATETIMERF" + Environment.NewLine);
                            sqlTxt.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                            sqlTxt.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                            sqlTxt.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                            sqlTxt.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                            sqlTxt.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                            sqlTxt.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                            sqlTxt.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                            sqlTxt.Append("    ,CUSTOMERCODERF" + Environment.NewLine);
                            sqlTxt.Append("    ,BLPSENDDIVRF" + Environment.NewLine);
                            sqlTxt.Append(" )" + Environment.NewLine);
                            sqlTxt.Append(" VALUES" + Environment.NewLine);
                            sqlTxt.Append(" (@CREATEDATETIME" + Environment.NewLine);
                            sqlTxt.Append("    ,@UPDATEDATETIME" + Environment.NewLine);
                            sqlTxt.Append("    ,@ENTERPRISECODE" + Environment.NewLine);
                            sqlTxt.Append("    ,@FILEHEADERGUID" + Environment.NewLine);
                            sqlTxt.Append("    ,@UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlTxt.Append("    ,@UPDASSEMBLYID1" + Environment.NewLine);
                            sqlTxt.Append("    ,@UPDASSEMBLYID2" + Environment.NewLine);
                            sqlTxt.Append("    ,@LOGICALDELETECODE" + Environment.NewLine);
                            sqlTxt.Append("    ,@CUSTOMERCODE" + Environment.NewLine);
                            sqlTxt.Append("    ,@BLPSENDDIV )" + Environment.NewLine);

                            sqlCommand.CommandText = sqlTxt.ToString();
                            sqlTxt.Remove(0, sqlTxt.Length);

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabTtlStCustWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.NChar);
                        SqlParameter paraBlpSendDiv = sqlCommand.Parameters.Add("@BLPSENDDIV", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabTtlStCustWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabTtlStCustWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmTabTtlStCustWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);
                        paraBlpSendDiv.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.BlpSendDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabTtlStCustWork);
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

            subSectionWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件のPMTAB全体設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="pmTabTtlStCustWork">検索結果</param>
        /// <param name="parsesubSectionWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のPMTAB全体設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        public int Search(out object pmTabTtlStCustWork, object parsesubSectionWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            pmTabTtlStCustWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSubSection(out pmTabTtlStCustWork, parsesubSectionWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.Search");
                pmTabTtlStCustWork = new ArrayList();
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
        /// 指定された条件のPMTAB全体設定マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objsubSectionWork">検索結果</param>
        /// <param name="parasubSectionWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のPMTAB全体設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        public int SearchSubSection(out object objsubSectionWork, object parasubSectionWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            PmTabTtlStCustWork pmTabTtlStCustWork = null;

            ArrayList subSectionWorkList = parasubSectionWork as ArrayList;
            if (subSectionWorkList == null)
            {
                pmTabTtlStCustWork = parasubSectionWork as PmTabTtlStCustWork;
            }
            else
            {
                if (subSectionWorkList.Count > 0)
                    pmTabTtlStCustWork = subSectionWorkList[0] as PmTabTtlStCustWork;
            }

            int status = SearchSubSectionProc(out subSectionWorkList, pmTabTtlStCustWork, readMode, logicalMode, ref sqlConnection);
            objsubSectionWork = subSectionWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のPMTAB全体設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">検索結果</param>
        /// <param name="pmTabTtlStCustWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/30</br>
        private int SearchSubSectionProc(out ArrayList subSectionWorkList, PmTabTtlStCustWork pmTabTtlStCustWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder();

                sqlTxt.Append("SELECT" + Environment.NewLine);
                sqlTxt.Append(" PMTABTTLSTCUST.CREATEDATETIMERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.UPDATEDATETIMERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.ENTERPRISECODERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.FILEHEADERGUIDRF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.LOGICALDELETECODERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.CUSTOMERCODERF" + Environment.NewLine);
                sqlTxt.Append(" ,PMTABTTLSTCUST.BLPSENDDIVRF" + Environment.NewLine);
                sqlTxt.Append(" ,CUSTOM.CUSTOMERSNMRF" + Environment.NewLine);
                sqlTxt.Append(" FROM PMTABTTLSTCUSTRF PMTABTTLSTCUST WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlTxt.Append(" LEFT JOIN CUSTOMERRF CUSTOM WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlTxt.Append(" ON  CUSTOM.ENTERPRISECODERF=PMTABTTLSTCUST.ENTERPRISECODERF" + Environment.NewLine);
                sqlTxt.Append(" AND CUSTOM.CUSTOMERCODERF=PMTABTTLSTCUST.CUSTOMERCODERF" + Environment.NewLine);

                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, pmTabTtlStCustWork, logicalMode);

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSubSectionWorkFromReader(ref myReader));

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

            subSectionWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// PMTAB全体設定マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="pmTabTtlStCustWork">PmTabTtlStCustWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        public int LogicalDelete(ref object pmTabTtlStCustWork)
        {
            return LogicalDeleteSubSection(ref pmTabTtlStCustWork, 0);
        }

        /// <summary>
        /// 論理削除PMTAB全体設定マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="pmTabTtlStCustWork">PmTabTtlStCustWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除PMTAB全体設定マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        public int RevivalLogicalDelete(ref object pmTabTtlStCustWork)
        {
            return LogicalDeleteSubSection(ref pmTabTtlStCustWork, 1);
        }

        /// <summary>
        /// PMTAB全体設定マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="pmTabTtlStCustWork">PmTabTtlStCustWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        private int LogicalDeleteSubSection(ref object pmTabTtlStCustWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(pmTabTtlStCustWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSubSectionProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.LogicalDeleteCarrier :" + procModestr);

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
        /// PMTAB全体設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">PmTabTtlStCustWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        public int LogicalDeleteSubSectionProc(ref ArrayList subSectionWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSubSectionProcProc(ref subSectionWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// PMTAB全体設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">PmTabTtlStCustWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB全体設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        private int LogicalDeleteSubSectionProcProc(ref ArrayList subSectionWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlTxt = new StringBuilder();

            try
            {
                if (subSectionWorkList != null)
                {
                    for (int i = 0; i < subSectionWorkList.Count; i++)
                    {
                        PmTabTtlStCustWork pmTabTtlStCustWork = subSectionWorkList[i] as PmTabTtlStCustWork;

                        sqlTxt.Append(string.Empty);
                        sqlTxt.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine);
                        sqlTxt.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                        sqlTxt.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                        sqlTxt.Append(" FROM PMTABTTLSTCUSTRF" + Environment.NewLine);
                        sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                        sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                        sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCd = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                        findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                        //タイムアウト時間の設定（秒）
                        sqlCommand.CommandTimeout = 600;

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != pmTabTtlStCustWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            
                            sqlTxt.Append(string.Empty);
                            sqlTxt.Append("UPDATE PMTABTTLSTCUSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine);
                            sqlTxt.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlTxt.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine);
                            sqlTxt.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine);
                            sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine);
                            sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                            sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                            sqlCommand.CommandText = sqlTxt.ToString();

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                            findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmTabTtlStCustWork;
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
                            else if (logicalDelCd == 0) pmTabTtlStCustWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else pmTabTtlStCustWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) pmTabTtlStCustWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabTtlStCustWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabTtlStCustWork);
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

            subSectionWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// PMTAB全体設定マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">PMTAB全体設定マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : PMTAB全体設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
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

                status = DeleteSubSectionProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.Delete");
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
        /// PMTAB全体設定マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">PMTAB全体設定マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : PMTAB全体設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(paraobj);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteSubSectionProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "PmTabTtlStCustDB.Delete");
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
        /// PMTAB全体設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">PMTAB全体設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : PMTAB全体設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        public int DeleteSubSectionProc(ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSubSectionProcProc(subSectionWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// PMTAB全体設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">PMTAB全体設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : PMTAB全体設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        private int DeleteSubSectionProcProc(ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlTxt = new StringBuilder();

            try
            {

                for (int i = 0; i < subSectionWorkList.Count; i++)
                {
                    PmTabTtlStCustWork pmTabTtlStCustWork = subSectionWorkList[i] as PmTabTtlStCustWork;

                    sqlTxt.Append(string.Empty);
                    sqlTxt.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine);
                    sqlTxt.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                    sqlTxt.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                    sqlTxt.Append(" FROM PMTABTTLSTCUSTRF" + Environment.NewLine);
                    sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                    sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

                    sqlTxt.Remove(0,sqlTxt.Length);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCd= sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                    findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);

                    //タイムアウト時間の設定（秒）
                    sqlCommand.CommandTimeout = 600;

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != pmTabTtlStCustWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt.Append("DELETE" + Environment.NewLine);
                        sqlTxt.Append(" FROM PMTABTTLSTCUSTRF" + Environment.NewLine);
                        sqlTxt.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                        sqlTxt.Append("    AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine);

                        sqlCommand.CommandText = sqlTxt.ToString();
                        sqlTxt.Remove(0,sqlTxt.Length);

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);
                        findParaCustomerCd.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);
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

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="pmTabTtlStCustWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PmTabTtlStCustWork pmTabTtlStCustWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "PMTABTTLSTCUST.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabTtlStCustWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND PMTABTTLSTCUST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND PMTABTTLSTCUST.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //PMTAB全体設定得意先コード
            if (pmTabTtlStCustWork.CustomerCode != 0)
            {
                retstring += "AND PMTABTTLSTCUST.CUSTOMERCODERF=@CUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(pmTabTtlStCustWork.CustomerCode);
            }

            return retstring;
        }

        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            PmTabTtlStCustWork[] SubSectionWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is PmTabTtlStCustWork)
                    {
                        PmTabTtlStCustWork wkSubSectionWork = paraobj as PmTabTtlStCustWork;
                        if (wkSubSectionWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSubSectionWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SubSectionWorkArray = (PmTabTtlStCustWork[])XmlByteSerializer.Deserialize(byteArray, typeof(PmTabTtlStCustWork[]));
                        }
                        catch (Exception) { }
                        if (SubSectionWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SubSectionWorkArray);
                        }
                        else
                        {
                            try
                            {
                                PmTabTtlStCustWork wkSubSectionWork = (PmTabTtlStCustWork)XmlByteSerializer.Deserialize(byteArray, typeof(PmTabTtlStCustWork));
                                if (wkSubSectionWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSubSectionWork);
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

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PmTabTtlStCustWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmTabTtlStCustWork</returns>
        /// <remarks>
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStCustWork CopyToSubSectionWorkFromReader(ref SqlDataReader myReader)
        {
            PmTabTtlStCustWork wkSubSectionWork = new PmTabTtlStCustWork();

            #region クラスへ格納
            wkSubSectionWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSubSectionWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSubSectionWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSubSectionWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSubSectionWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSubSectionWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSubSectionWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSubSectionWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSubSectionWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkSubSectionWork.CustomerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkSubSectionWork.BlpSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLPSENDDIVRF"));
            #endregion

            return wkSubSectionWork;
        }

        #endregion

    }
}
