//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理設定マスタメンテナンス
// プログラム概要   : 拠点管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 拠点管理設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点管理設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SecMngSetDB : RemoteDB, ISecMngSetDB
    {
        /// <summary>
        /// 拠点管理設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public SecMngSetDB()
            : base("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork", "SecMngSetRF")
        {

        }

        # region [Search]
        /// <summary>
        /// 拠点管理設定マスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outSecMngSetList">検索結果</param>
        /// <param name="paraSecMngSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタのキー値が一致する、全ての拠点管理設定マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Search(out object outSecMngSetList, object paraSecMngSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _secMngSetList = null;
            SecMngSetWork secMngSetWork = null;

            outSecMngSetList = new CustomSerializeArrayList();

            try
            {
                secMngSetWork = paraSecMngSetWork as SecMngSetWork;
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchProc(out _secMngSetList, secMngSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngSetDB.Search(out object, object, int, LogicalMode)", status);
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
            outSecMngSetList = _secMngSetList;
            return status;
        }

        /// <summary>
        /// 拠点管理設定マスタ情報のリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="secMngSetList">拠点管理設定マスタ情報を格納する ArrayList</param>
        /// <param name="secMngSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタのキー値が一致する、全ての拠点管理設定マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private int SearchProc(out ArrayList secMngSetList, SecMngSetWork secMngSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,KINDRF" + Environment.NewLine;
                sqlText += " ,RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SYNCEXECDATERF" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				sqlText += " ,SENDDESTSECCODERF" + Environment.NewLine;
				sqlText += " ,AUTOSENDDIVRF" + Environment.NewLine;
				sqlText += " ,SNDFINDATAEDDIVRF" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSETRF" + Environment.NewLine;
                sqlText += "WHERE " + Environment.NewLine;
                sqlText += "ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += " ORDER BY" + Environment.NewLine;
                sqlText += " SECTIONCODERF" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				sqlText += " ,SENDDESTSECCODERF" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;


                sqlCommand.CommandText += sqlText;
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSecMngSetWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SecMngSetDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngSetDB.SearchProc" + status);
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
            secMngSetList = al;

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// 拠点管理設定マスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWorkオブジェクト</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタを追加・更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Write(ref object paraSecMngSetWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XMLの読み込み
                //SecMngSetWork secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                SecMngSetWork secMngSetWork = paraSecMngSetWork as SecMngSetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteProc(secMngSetWork, writeMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                //parabyte = XmlByteSerializer.Serialize(secMngSetWork);
                paraSecMngSetWork = secMngSetWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngSetDB.Write(ref object)", status);
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
        /// 拠点管理設定マスタ情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="secMngSetWork">拠点管理設定マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private int WriteProc(SecMngSetWork secMngSetWork, int writeMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSETRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                # endregion

                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                    SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					SqlParameter findParaSendSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;
                    findParaKind.Value = secMngSetWork.Kind;
                    findParaReceiveCondition.Value = secMngSetWork.ReceiveCondition;
                    findParaSectionCode.Value = secMngSetWork.SectionCode;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					findParaSendSecCode.Value = secMngSetWork.SendDestSecCode;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != secMngSetWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (secMngSetWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            //既存データで更新日時違いの場合には排他
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                            return status;
                        }

                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SECMNGSETRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,SYNCEXECDATERF = @SYNCEXECDATE" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
						sqlText += " ,AUTOSENDDIVRF = @AUTOSENDDIV" + Environment.NewLine;
						sqlText += " ,SNDFINDATAEDDIVRF = @SNDFINDATAEDDIV" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                        sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
						sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;
                        findParaKind.Value = secMngSetWork.Kind;
                        findParaReceiveCondition.Value = secMngSetWork.ReceiveCondition;
                        findParaSectionCode.Value = secMngSetWork.SectionCode;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
						findParaSendSecCode.Value = secMngSetWork.SendDestSecCode;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)secMngSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (secMngSetWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT文]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO" + Environment.NewLine;
                        sqlText += "  SECMNGSETRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,KINDRF" + Environment.NewLine;
                        sqlText += "    ,RECEIVECONDITIONRF" + Environment.NewLine;
                        sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,SYNCEXECDATERF" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
						sqlText += "    ,SENDDESTSECCODERF" + Environment.NewLine;
						sqlText += "    ,AUTOSENDDIVRF" + Environment.NewLine;
						sqlText += "    ,SNDFINDATAEDDIVRF" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "    ,@KIND" + Environment.NewLine;
                        sqlText += "    ,@RECEIVECONDITION" + Environment.NewLine;
                        sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                        sqlText += "    ,@SYNCEXECDATE" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
						sqlText += "    ,@SENDDESTSECCODE" + Environment.NewLine;
						sqlText += "    ,@AUTOSENDDIV" + Environment.NewLine;
						sqlText += "    ,@SNDFINDATAEDDIV" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                        sqlText += " )" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)secMngSetWork;
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
                    SqlParameter paraKind = sqlCommand.Parameters.Add("@KIND", SqlDbType.Int);
                    SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@RECEIVECONDITION", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
					SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					SqlParameter paraSendDestSecCode = sqlCommand.Parameters.Add("@SENDDESTSECCODE", SqlDbType.NChar);
					SqlParameter paraAutoSendDiv = sqlCommand.Parameters.Add("@AUTOSENDDIV", SqlDbType.BigInt);
					SqlParameter paraSndFinDataEdDiv = sqlCommand.Parameters.Add("@SNDFINDATAEDDIV", SqlDbType.BigInt);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSetWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSetWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secMngSetWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secMngSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secMngSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.LogicalDeleteCode);
                    paraKind.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.Kind);
                    paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.ReceiveCondition);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.SectionCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngSetWork.SyncExecDate);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					paraSendDestSecCode.Value = SqlDataMediator.SqlSetString(secMngSetWork.SendDestSecCode);
					paraAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.AutoSendDiv);
					paraSndFinDataEdDiv.Value = SqlDataMediator.SqlSetInt32(secMngSetWork.SndFinDataEdDiv);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SecMngSetDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngSetDB.Write" + status);
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
        # endregion

        # region [Delete]
        /// <summary>
        ///  拠点管理設定マスタ情報を物理削除します
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタのキー値が一致する 拠点管理設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        public int Delete(ref object paraSecMngSetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XMLの読み込み
                //SecMngSetWork secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                SecMngSetWork secMngSetWork = paraSecMngSetWork as SecMngSetWork;


                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteProc(secMngSetWork, ref sqlConnection, ref sqlTransaction);

                paraSecMngSetWork = secMngSetWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngSetDB.Delete(ref object secMngSetWork)", status);
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
        /// 拠点管理設定マスタ情報を物理削除します
        /// </summary>
        /// <remarks>
        /// <param name="secMngSetWork">拠点管理設定マスタ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private int DeleteProc(SecMngSetWork secMngSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSETRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                sqlCommand.CommandText = sqlText;
                # endregion
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;
                findParaKind.Value = secMngSetWork.Kind;
                findParaReceiveCondition.Value = secMngSetWork.ReceiveCondition;
                findParaSectionCode.Value = secMngSetWork.SectionCode;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				findParaSendDestSecCode.Value = secMngSetWork.SendDestSecCode;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                    if (_updateDateTime != secMngSetWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }


                    # region [DELETE文]
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SECMNGSETRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                    sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = secMngSetWork.EnterpriseCode;
                    findParaKind.Value = secMngSetWork.Kind;
                    findParaReceiveCondition.Value = secMngSetWork.ReceiveCondition;
                    findParaSectionCode.Value = secMngSetWork.SectionCode;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					findParaSendDestSecCode.Value = secMngSetWork.SendDestSecCode;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
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
                status = base.WriteSQLErrorLog(sqlex, "SecMngSetDB.DeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngSetDB.DeleteProc" + status);
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
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 拠点管理設定マスタ情報を論理削除します。
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        public int LogicalDelete(ref object paraSecMngSetWork)
        {
            return this.LogicalDelete(ref paraSecMngSetWork, 0);
        }

        /// <summary>
        /// 拠点管理設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">論理削除を解除する拠点管理設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object paraSecMngSetWork)
        {
            return this.LogicalDelete(ref paraSecMngSetWork, 1);
        }

        /// <summary>
        /// 拠点管理設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">論理削除を操作する拠点管理設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている拠点管理設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private int LogicalDelete(ref object paraSecMngSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XMLの読み込み
                //SecMngSetWork secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                SecMngSetWork secMngSetWork = paraSecMngSetWork as SecMngSetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref secMngSetWork, procMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                //parabyte = XmlByteSerializer.Serialize(secMngSetWork);
                paraSecMngSetWork = secMngSetWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngSetDB.LogicalDelete(ref object, int[" + procMode.ToString() + "])", status);
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
        /// 拠点管理設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="paraSecMngSetWork">論理削除を操作する拠点管理設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている拠点管理設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        private int LogicalDeleteProc(ref SecMngSetWork paraSecMngSetWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SECMNGSETRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                # endregion
                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                    SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = paraSecMngSetWork.EnterpriseCode;
                    findParaKind.Value = paraSecMngSetWork.Kind;
                    findParaReceiveCondition.Value = paraSecMngSetWork.ReceiveCondition;
                    findParaSectionCode.Value = paraSecMngSetWork.SectionCode;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
					findParaSendDestSecCode.Value = paraSecMngSetWork.SendDestSecCode;
					// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != paraSecMngSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SECMNGSETRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND KINDRF = @FINDKIND" + Environment.NewLine;
                        sqlText += "  AND RECEIVECONDITIONRF = @FINDRECEIVECONDITION" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
						sqlText += "  AND SENDDESTSECCODERF = @FINDSENDDESTSECCODE" + Environment.NewLine;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = paraSecMngSetWork.EnterpriseCode;
                        findParaKind.Value = paraSecMngSetWork.Kind;
                        findParaReceiveCondition.Value = paraSecMngSetWork.ReceiveCondition;
                        findParaSectionCode.Value = paraSecMngSetWork.SectionCode;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
						findParaSendDestSecCode.Value = paraSecMngSetWork.SendDestSecCode;
						// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paraSecMngSetWork;
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
                        else if (logicalDelCd == 0) paraSecMngSetWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                        else paraSecMngSetWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            paraSecMngSetWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paraSecMngSetWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paraSecMngSetWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paraSecMngSetWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paraSecMngSetWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paraSecMngSetWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SecMngSetDB.LogicalDeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngSetDB.LogicalDeleteProc" + status);
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
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SecMngSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        private SecMngSetWork CopyToSecMngSetWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngSetWork secMngSetWork = new SecMngSetWork();

            if (myReader != null && secMngSetWork != null)
            {
                # region クラスへ格納
                secMngSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                secMngSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                secMngSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                secMngSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                secMngSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                secMngSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                secMngSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                secMngSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                secMngSetWork.Kind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("KINDRF"));
                secMngSetWork.ReceiveCondition = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIVECONDITIONRF"));
                secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				secMngSetWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));
				secMngSetWork.AutoSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
				secMngSetWork.SndFinDataEdDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDFINDATAEDDIVRF"));
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                # endregion
            }
            return secMngSetWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
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
