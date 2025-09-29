//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ名称設定マスタ                    //
//                      リモートオブジェクト                            //
//                  :   PMKHN09725R.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
    /// ロールグループ名称設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ロールグループ名称設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30746 高川 悟</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RoleGroupNameStDB : RemoteDB, IRoleGroupNameStDB
    {
        /// <summary>
        /// ロールグループ名称設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public RoleGroupNameStDB()
            : base("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork", "ROLEGROUPNAMESTRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件のロールグループ名称設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="roleGroupNameStWork">検索結果</param>
        /// <param name="pararoleGroupNameStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のロールグループ名称設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Search(out object roleGroupNameStWork, object pararoleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            roleGroupNameStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchRoleGroupNameStProc(out roleGroupNameStWork, pararoleGroupNameStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RoleGroupNameStDB.Search");
                roleGroupNameStWork = new ArrayList();
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
        /// 指定された条件のロールグループ名称設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objroleGroupNameStWork">検索結果</param>
        /// <param name="pararoleGroupNameStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のロールグループ名称設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int SearchRoleGroupNameStProc(out object objroleGroupNameStWork, object pararoleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            RoleGroupNameStWork roleGroupNameStWork = null;

            ArrayList roleGroupNameStWorkList = pararoleGroupNameStWork as ArrayList;
            if (roleGroupNameStWorkList == null)
            {
                roleGroupNameStWork = pararoleGroupNameStWork as RoleGroupNameStWork;
            }
            else
            {
                if (roleGroupNameStWorkList.Count > 0)
                    roleGroupNameStWork = roleGroupNameStWorkList[0] as RoleGroupNameStWork;
            }

            int status = SearchRoleGroupNameStProc(out roleGroupNameStWorkList, roleGroupNameStWork, readMode, logicalMode, ref sqlConnection);
            objroleGroupNameStWork = roleGroupNameStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のロールグループ名称設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">検索結果</param>
        /// <param name="roleGroupNameStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のロールグループ名称設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int SearchRoleGroupNameStProc(out ArrayList roleGroupNameStWorkList, RoleGroupNameStWork roleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchRoleGroupNameStProcProc(out roleGroupNameStWorkList, roleGroupNameStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のロールグループ名称設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">検索結果</param>
        /// <param name="roleGroupNameStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のロールグループ名称設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int SearchRoleGroupNameStProcProc(out ArrayList roleGroupNameStWorkList, RoleGroupNameStWork roleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += "SELECT  CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPNAMERF" + Environment.NewLine;
                selectTxt += "FROM    ROLEGRPNAMESTRF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, roleGroupNameStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToRoleGroupNameStWorkFromReader(ref myReader));

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

            roleGroupNameStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のロールグループ名称設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">RoleGroupNameStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のロールグループ名称設定マスタを戻します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();

                // XMLの読み込み
                roleGroupNameStWork = (RoleGroupNameStWork)XmlByteSerializer.Deserialize(parabyte, typeof(RoleGroupNameStWork));
                if (roleGroupNameStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref roleGroupNameStWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(roleGroupNameStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RoleGroupNameStDB.Read");
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
        /// 指定された条件のロールグループ名称設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のロールグループ名称設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int ReadProc(ref RoleGroupNameStWork roleGroupNameStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref roleGroupNameStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件のロールグループ名称設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のロールグループ名称設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int ReadProcProc(ref RoleGroupNameStWork roleGroupNameStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += "SELECT  CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPNAMERF" + Environment.NewLine;
                selectTxt += "FROM    ROLEGRPNAMESTRF" + Environment.NewLine;
                selectTxt += "WHERE   ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND   ROLEGROUPCODERF  = @FINDROLEGROUPCODE" + Environment.NewLine;
                #endregion

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                    SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ロールグループコード

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);            // 企業コード
                    findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);               // ロールグループコード

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        roleGroupNameStWork = CopyToRoleGroupNameStWorkFromReader(ref myReader);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// ロールグループ名称設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int Write(ref object roleGroupNameStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(roleGroupNameStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteRoleGroupNameStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                RoleGroupNameStWork paraWork = paraList[0] as RoleGroupNameStWork;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                roleGroupNameStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RoleGroupNameStDB.Write(ref object roleGroupNameStWork)");
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
        /// ロールグループ名称設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int WriteRoleGroupNameStProc(ref ArrayList roleGroupNameStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteRoleGroupNameStProcProc(ref roleGroupNameStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ロールグループ名称設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int WriteRoleGroupNameStProcProc(ref ArrayList roleGroupNameStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (roleGroupNameStWorkList != null)
                {
                    foreach (RoleGroupNameStWork roleGroupNameStWork in roleGroupNameStWorkList)
                    {
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM ROLEGRPNAMESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                        SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ロールグループコード

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);            // 企業コード
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);               // ロールグループコード

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時
                            if (_updateDateTime != roleGroupNameStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (roleGroupNameStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += "UPDATE  ROLEGRPNAMESTRF" + Environment.NewLine;
                            sqlText += "SET     CREATEDATETIMERF    = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   UPDATEDATETIMERF    = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   ENTERPRISECODERF    = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,   FILEHEADERGUIDRF    = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,   UPDEMPLOYEECODERF   = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID1RF    = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID2RF    = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,   LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPCODERF     = @ROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPNAMERF     = @ROLEGROUPNAME" + Environment.NewLine;
                            sqlText += "WHERE   ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND   ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);    // 企業コード
                            findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);       // ロールグループコード

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupNameStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (roleGroupNameStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += "INSERT INTO ROLEGRPNAMESTRF (" + Environment.NewLine;
                            sqlText += "        CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPNAMERF" + Environment.NewLine;
                            sqlText += ") VALUES (" + Environment.NewLine;
                            sqlText += "        @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,   @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,   @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,   @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,   @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,   @ROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "    ,   @ROLEGROUPNAME" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupNameStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);           // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);           // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);            // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier); // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);          // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);         // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);         // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);        // 論理削除区分
                        SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@ROLEGROUPCODE", SqlDbType.Int);                // ロールグループコード
                        SqlParameter paraRoleGroupName = sqlCommand.Parameters.Add("@ROLEGROUPNAME", SqlDbType.NVarChar);           // ロールグループ名称
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupNameStWork.CreateDateTime);     // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupNameStWork.UpdateDateTime);     // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);                // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(roleGroupNameStWork.FileHeaderGuid);                  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdEmployeeCode);              // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdAssemblyId1);                // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdAssemblyId2);                // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.LogicalDeleteCode);           // 論理削除区分
                        paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);                   // ロールグループコード
                        paraRoleGroupName.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.RoleGroupName);                  // ロールグループ名称
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(roleGroupNameStWork);
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

            roleGroupNameStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// ロールグループ名称設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="roleGroupNameStWork">roleGroupNameStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int LogicalDelete(ref object roleGroupNameStWork)
        {
            return LogicalDeleteRoleGroupNameSt(ref roleGroupNameStWork, 0);
        }

        /// <summary>
        /// 論理削除ロールグループ名称設定マスタ情報を復活します
        /// </summary>
        /// <param name="roleGroupNameStWork">roleGroupNameStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除ロールグループ名称設定マスタ情報を復活します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int RevivalLogicalDelete(ref object roleGroupNameStWork)
        {
            return LogicalDeleteRoleGroupNameSt(ref roleGroupNameStWork, 1);
        }

        /// <summary>
        /// ロールグループ名称設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="roleGroupNameStWork">roleGroupNameStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int LogicalDeleteRoleGroupNameSt(ref object roleGroupNameStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(roleGroupNameStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteRoleGroupNameStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "RoleGroupNameStDB.LogicalDeleteRoleGroupNameSt :" + procModestr);

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
        /// ロールグループ名称設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">roleGroupNameStWorkListオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int LogicalDeleteRoleGroupNameStProc(ref ArrayList roleGroupNameStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteRoleGroupNameStProcProc(ref roleGroupNameStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ロールグループ名称設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">roleGroupNameStWorkListオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int LogicalDeleteRoleGroupNameStProcProc(ref ArrayList roleGroupNameStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (roleGroupNameStWorkList != null)
                {
                    for (int i = 0; i < roleGroupNameStWorkList.Count; i++)
                    {
                        RoleGroupNameStWork roleGroupNameStWork = roleGroupNameStWorkList[i] as RoleGroupNameStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM ROLEGRPNAMESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                        SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ロールグループコード

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);            // 企業コード
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);               // ロールグループコード

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != roleGroupNameStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE ROLEGRPNAMESTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE";

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);    // 企業コード
                            findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);       // ロールグループコード

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupNameStWork;
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
                            else if (logicalDelCd == 0) roleGroupNameStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else roleGroupNameStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) roleGroupNameStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;    //既に復活している場合はそのまま正常を戻す
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupNameStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(roleGroupNameStWork);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            roleGroupNameStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ロールグループ名称設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">ロールグループ名称設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
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

                status = DeleteRoleGroupNameStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "RoleGroupNameStDB.Delete");
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
        /// ロールグループ名称設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">ロールグループ名称設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        public int DeleteRoleGroupNameStProc(ArrayList roleGroupNameStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteRoleGroupNameStProcProc(roleGroupNameStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ロールグループ名称設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">ロールグループ名称設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ロールグループ名称設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private int DeleteRoleGroupNameStProcProc(ArrayList roleGroupNameStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < roleGroupNameStWorkList.Count; i++)
                {
                    RoleGroupNameStWork roleGroupNameStWork = roleGroupNameStWorkList[i] as RoleGroupNameStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM ROLEGRPNAMESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // 企業コード
                    SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ロールグループコード

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);            // 企業コード
                    findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);               // ロールグループコード

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != roleGroupNameStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM ROLEGRPNAMESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE";

                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);        // 企業コード
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);           // ロールグループコード
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

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="roleGroupNameStWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RoleGroupNameStWork roleGroupNameStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE   ";

            //企業コード
            retstring += "ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);

            //ロールグループコード
            if (roleGroupNameStWork.RoleGroupCode != 0)
            {
                retstring += "  AND   ROLEGROUPCODERF = @FINDROLEGROUPCODE" + Environment.NewLine;
                SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);
            }

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND   LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND   LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
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
        /// クラス格納処理 Reader → RoleGroupNameStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RoleGroupNameStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private RoleGroupNameStWork CopyToRoleGroupNameStWorkFromReader(ref SqlDataReader myReader)
        {
            RoleGroupNameStWork wkRoleGroupNameStWork = new RoleGroupNameStWork();

            #region クラスへ格納
            wkRoleGroupNameStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkRoleGroupNameStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkRoleGroupNameStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // 企業コード
            wkRoleGroupNameStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
            wkRoleGroupNameStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // 更新従業員コード
            wkRoleGroupNameStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // 更新アセンブリID1
            wkRoleGroupNameStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // 更新アセンブリID2
            wkRoleGroupNameStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // 論理削除区分
            wkRoleGroupNameStWork.RoleGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEGROUPCODERF"));               // ロールグループコード
            wkRoleGroupNameStWork.RoleGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ROLEGROUPNAMERF"));                // ロールグループ名称
            #endregion

            return wkRoleGroupNameStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            RoleGroupNameStWork[] RoleGroupNameStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is RoleGroupNameStWork)
                    {
                        RoleGroupNameStWork wkRoleGroupNameStWork = paraobj as RoleGroupNameStWork;
                        if (wkRoleGroupNameStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkRoleGroupNameStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            RoleGroupNameStWorkArray = (RoleGroupNameStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(RoleGroupNameStWork[]));
                        }
                        catch (Exception) { }
                        if (RoleGroupNameStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(RoleGroupNameStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                RoleGroupNameStWork wkRoleGroupNameStWork = (RoleGroupNameStWork)XmlByteSerializer.Deserialize(byteArray, typeof(RoleGroupNameStWork));
                                if (wkRoleGroupNameStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkRoleGroupNameStWork);
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
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2013/02/18</br>
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