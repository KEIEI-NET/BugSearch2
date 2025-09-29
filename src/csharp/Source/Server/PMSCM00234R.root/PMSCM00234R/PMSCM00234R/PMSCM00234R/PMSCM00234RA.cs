//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オプション管理マスタリモートオブジェクト
// プログラム概要   : オプション管理マスタリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡
// 作 成 日  2014/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// オプション管理マスタDBをリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : オプション管理マスタの更新操作を行うクラスです。</br>
    /// <br>Programmer : limm</br>
    /// <br>Date       : 2014/08/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PMOptMngDB : RemoteDB,IPMOptMngDB
    {
        # region ■Constructor
        /// <summary>
        /// オプション管理マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        /// </remarks>
        public PMOptMngDB() 
        {

        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件のオプション管理マスタLISTを戻します
        /// </summary>
        /// <param name="pMOptMngWorkList">検索結果</param>
        /// <param name="parapMOptMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオプション管理マスタLISTを戻します</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        public int Search(out object pMOptMngWorkList, object parapMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            pMOptMngWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out pMOptMngWorkList, parapMOptMngWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMOptMngDB.Search");
                pMOptMngWorkList = new ArrayList();
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
        /// オプション管理マスタLISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objpMOptMngListWork">検索結果</param>
        /// <param name="parapMOptMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchProc(out object objpMOptMngListWork, object parapMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            PMOptMngWork parapMOptMngWk = null;
            ArrayList pMOptMngWorkList = new ArrayList();

            if (parapMOptMngWork == null)
            {
                parapMOptMngWk = new PMOptMngWork();
            }
            else
            {
                parapMOptMngWk = parapMOptMngWork as PMOptMngWork;
            }

            int status = SearchPMOptMngProc(out pMOptMngWorkList, parapMOptMngWk, readMode, logicalMode, ref sqlConnection);
            objpMOptMngListWork = pMOptMngWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のオプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="pMOptMngWorkList">検索結果</param>
        /// <param name="pMOptMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchPMOptMngProc(out ArrayList pMOptMngWorkList, PMOptMngWork pMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchPMOptMngProcProc(out pMOptMngWorkList, pMOptMngWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のオプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="pMOptMngWorkList">検索結果</param>
        /// <param name="pMOptMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchPMOptMngProcProc(out ArrayList pMOptMngWorkList, PMOptMngWork pMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder selectTxt = new StringBuilder(string.Empty);

                # region SELECT文
                selectTxt.Append("SELECT   CREATEDATETIMERF ");
                selectTxt.Append(" ,UPDATEDATETIMERF ").Append(Environment.NewLine);  
                selectTxt.Append(" ,ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,FILEHEADERGUIDRF ").Append(Environment.NewLine);
                selectTxt.Append(" ,UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                selectTxt.Append(" ,UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                selectTxt.Append(" ,LOGICALDELETECODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,SECTIONCODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,OPTIONCODERF ").Append(Environment.NewLine);
                selectTxt.Append(" ,OPTIONUSEDIVRF ").Append(Environment.NewLine);
                selectTxt.Append("  FROM PMOPTMNGRF  ").Append(Environment.NewLine);
                selectTxt.Append("  WITH (READUNCOMMITTED)").Append(Environment.NewLine);  
                #endregion

                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, pMOptMngWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToPMOptMngWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            pMOptMngWorkList = al;

            return status;
        }
        #endregion

        #region [SearchAll]
        /// <summary>
        /// オプション管理マスタLISTを戻します
        /// </summary>
        /// <param name="pMOptMngWorkList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオプション管理マスタLISTを戻します</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        public int SearchAll(out object pMOptMngWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            pMOptMngWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchAllProc(out pMOptMngWorkList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMOptMngDB.Search");
                pMOptMngWorkList = new ArrayList();
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
        /// オプション管理マスタLISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objpMOptMngListWork">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchAllProc(out object objpMOptMngListWork, ref SqlConnection sqlConnection)
        {
            ArrayList pMOptMngWorkList = new ArrayList();

            int status = SearchAllPMOptMngProc(out pMOptMngWorkList, ref sqlConnection);
            objpMOptMngListWork = pMOptMngWorkList;
            return status;
        }

        /// <summary>
        /// オプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="pMOptMngWorkList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchAllPMOptMngProc(out ArrayList pMOptMngWorkList, ref SqlConnection sqlConnection)
        {
            return this.SearchAllPMOptMngProcProc(out pMOptMngWorkList, ref sqlConnection);
        }

        /// <summary>
        /// オプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="pMOptMngWorkList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のオプション管理マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int SearchAllPMOptMngProcProc(out ArrayList pMOptMngWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                # region SELECT文
                string sqlText = string.Empty;
                sqlText = "SELECT CREATEDATETIMERF ,UPDATEDATETIMERF ,ENTERPRISECODERF ,FILEHEADERGUIDRF ,UPDEMPLOYEECODERF ,UPDASSEMBLYID1RF ,UPDASSEMBLYID2RF ,LOGICALDELETECODERF ,SECTIONCODERF ,OPTIONCODERF ,OPTIONUSEDIVRF FROM PMOPTMNGRF WITH (READUNCOMMITTED)";               
                #endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToPMOptMngWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            pMOptMngWorkList = al;

            return status;
        }
        #endregion

        # region [Write]
        /// <summary>
        /// オプション管理マスタを追加・更新します。
        /// </summary>
        /// <param name="pMOptMngWorkList">PMOptMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pMOptMngWork に格納されている更新リストを追加・更新します。</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        public int Write(ref object pMOptMngWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = pMOptMngWorkList as ArrayList; ;
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //追加・更新実行
                status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pMOptMngWorkList = paraList;
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMOptMngDB.Write(ref object pMOptMngWork)");// ?
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
        /// オプション管理マスタを追加・更新します(外部からのSqlConnection + SqlTranactionを使用)。
        /// </summary>
        /// <param name="pMOptMngWorkList">追加・更新する更新リストを含む ArrayList</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pMOptMngWorkList に格納されている更新リストを追加・更新します。</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
        private int WriteProc(ref ArrayList pMOptMngWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (pMOptMngWorkList != null)
                {
                    for (int i = 0; i < pMOptMngWorkList.Count; i++)
                    {
                        PMOptMngWork pMOptMngWork = pMOptMngWorkList[i] as PMOptMngWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM PMOPTMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND OPTIONCODERF=@FINDOPTIONCODERF ", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter findOptionCode = sqlCommand.Parameters.Add("@FINDOPTIONCODERF", SqlDbType.NChar);  // オプションコード
                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.EnterpriseCode);  // 企業コード
                        findSectionCode.Value = pMOptMngWork.SectionCode.Trim();   // 拠点コード
                        findOptionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.OptionCode);  // オプションコード

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            # region UPDATE文
                            string sqlText = string.Empty;
                            sqlText = "UPDATE PMOPTMNGRF SET UPDATEDATETIMERF = @UPDATEDATETIME , ENTERPRISECODERF = @ENTERPRISECODE , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 , LOGICALDELETECODERF = @LOGICALDELETECODE , OPTIONUSEDIVRF = @OPTIONUSEDIV WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND SECTIONCODERF = @FINDSECTIONCODE AND OPTIONCODERF = @FINDOPTIONCODERF ";

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.EnterpriseCode);  // 企業コード
                            findSectionCode.Value = pMOptMngWork.SectionCode.Trim();   // 拠点コード
                            findOptionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.OptionCode);  // オプションコード


                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pMOptMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (pMOptMngWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText = "INSERT INTO PMOPTMNGRF (CREATEDATETIMERF ,UPDATEDATETIMERF ,ENTERPRISECODERF ,FILEHEADERGUIDRF ,UPDEMPLOYEECODERF ,UPDASSEMBLYID1RF ,UPDASSEMBLYID2RF ,LOGICALDELETECODERF ,SECTIONCODERF ,OPTIONCODERF ,OPTIONUSEDIVRF ) VALUES (@CREATEDATETIME ,@UPDATEDATETIME ,@ENTERPRISECODE ,@FILEHEADERGUID ,@UPDEMPLOYEECODE ,@UPDASSEMBLYID1 ,@UPDASSEMBLYID2 ,@LOGICALDELETECODE ,@SECTIONCODE ,@OPTIONCODE ,@OPTIONUSEDIV ) ";

                            sqlCommand.CommandText = sqlText;

                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pMOptMngWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter paraOptionCode = sqlCommand.Parameters.Add("@OPTIONCODE", SqlDbType.NChar);  // オプションコード
                        SqlParameter paraOptionUseDiv = sqlCommand.Parameters.Add("@OPTIONUSEDIV", SqlDbType.Int);  // オプション利用区分
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMOptMngWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pMOptMngWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pMOptMngWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pMOptMngWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pMOptMngWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pMOptMngWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = pMOptMngWork.SectionCode.Trim();   // 拠点コード
                        paraOptionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.OptionCode);  // オプションコード
                        paraOptionUseDiv.Value = SqlDataMediator.SqlSetInt32(pMOptMngWork.OptionUseDiv);  // オプション利用区分
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pMOptMngWork);
                    }
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
                base.WriteErrorLog(ex, "WriteProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            pMOptMngWorkList = al;

            return status;
        }

        # endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="pMOptMngWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : limm　</br>
        /// <br>Date       : 2014/08/05</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PMOptMngWork pMOptMngWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(pMOptMngWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.SectionCode);
            }

            //オプションコード
            if (string.IsNullOrEmpty(pMOptMngWork.OptionCode) == false)
            {
                retstring += "AND OPTIONCODERF=@OPTIONCODE ";
                SqlParameter paraOptionCode = sqlCommand.Parameters.Add("@OPTIONCODE", SqlDbType.NChar);
                paraOptionCode.Value = SqlDataMediator.SqlSetString(pMOptMngWork.OptionCode);
            }

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PMOptMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PMOptMngWork</returns>
        /// <remarks>
        /// <br>Programmer : limm　</br>
        /// <br>Date       : 2014/08/05</br>
        /// </remarks>
        private PMOptMngWork CopyToPMOptMngWorkFromReader(ref SqlDataReader myReader)
        {
            PMOptMngWork wkPMOptMngWork = new PMOptMngWork();

            #region クラスへ格納
            wkPMOptMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkPMOptMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkPMOptMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkPMOptMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkPMOptMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkPMOptMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkPMOptMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkPMOptMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkPMOptMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkPMOptMngWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));  // オプションコード
            wkPMOptMngWork.OptionUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONUSEDIVRF"));  // オプション利用区分
            #endregion

            return wkPMOptMngWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/05</br>
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

    }
}
