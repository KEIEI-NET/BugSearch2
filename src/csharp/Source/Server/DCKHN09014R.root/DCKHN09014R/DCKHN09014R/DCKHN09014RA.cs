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
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 部門マスタメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部門マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 96050  横川　昌令</br>
    /// <br>Date       : 2007.08.16</br>
    /// <br></br>
    /// <br>Update Note: 20081  疋田 勇人</br>
    /// <br>Date       : 2008.05.26</br>
    /// <br>           : ＰＭ.ＮＳ用に変更</br>
    /// </remarks>
    [Serializable]
    public class SubSectionDB : RemoteDB, ISubSectionDB, IGetSyncdataList
    {
        /// <summary>
        /// 部門マスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 96050  横川　昌令</br>														   
        /// <br>Date       : 2007.08.16</br>
        /// </remarks>
        public SubSectionDB()
            :
        base("DCKHN09016D", "Broadleaf.Application.Remoting.ParamData.SubSectionWork", "SUBSECTIONRF")
        {
        }

        #region [Read]
        /// <summary>
        /// 指定された条件の部門マスタを戻します
        /// </summary>
        /// <param name="parabyte">SubSectionWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の部門マスタを戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                SubSectionWork subSectionWork = new SubSectionWork();

                // XMLの読み込み
                subSectionWork = (SubSectionWork)XmlByteSerializer.Deserialize(parabyte, typeof(SubSectionWork));
                if (subSectionWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref subSectionWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(subSectionWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SubSectionDB.Read");
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
        /// 指定された条件の部門マスタを戻します
        /// </summary>
        /// <param name="paraobj">SubSectionWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の部門マスタを戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        public int Read(ref object paraobj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                SubSectionWork subSectionWork = paraobj as SubSectionWork;

                if (subSectionWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref subSectionWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SubSectionDB.Read");
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
        /// 指定された条件の部門マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="subSectionWork">SubSectionWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の部門マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		public int ReadProc(ref SubSectionWork subSectionWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref subSectionWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の部門マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="subSectionWork">SubSectionWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の部門マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		private int ReadProcProc(ref SubSectionWork subSectionWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // 2008.05.26 upd start ---------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SUBSECTIONRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE ", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT SUBSEC.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SECINFO.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SUBSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlTxt += " FROM SUBSECTIONRF SUBSEC" + Environment.NewLine;
                sqlTxt += " LEFT JOIN SECINFOSETRF SECINFO ON SUBSEC.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND SUBSEC.SECTIONCODERF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += " WHERE SUBSEC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SUBSEC.SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.26 upd end ------------------------------------------<<
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);     // 2008.05.26 del
                    SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);
                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);                  // 2008.05.26 del
                    findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        subSectionWork = CopyToSubSectionWorkFromReader(ref myReader);
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
        /// 部門マスタ情報を登録、更新します
        /// </summary>
        /// <param name="subSectionWork">SubSectionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ情報を登録、更新します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        public int Write(ref object subSectionWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(subSectionWork);
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
                subSectionWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SubSectionDB.Write(ref object subSectionWork)");
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
        /// 部門マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">SubSectionWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		public int WriteSubSectionProc(ref ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteSubSectionProcProc(ref subSectionWorkList, ref sqlConnection, ref sqlTransaction);

		}

        /// <summary>
        /// 部門マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">SubSectionWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		private int WriteSubSectionProcProc(ref ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty;   // 2008.05.26 add

            try
            {
                if (subSectionWorkList != null)
                {
                    for (int i = 0; i < subSectionWorkList.Count; i++)
                    {
                        SubSectionWork subSectionWork = subSectionWorkList[i] as SubSectionWork;

                        //Selectコマンドの生成
                        // 2008.05.26 upd start ----------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SUBSECTIONRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE", sqlConnection, sqlTransaction);
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += " FROM SUBSECTIONRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        // 2008.05.26 upd end -------------------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);     // 2008.05.26 del
                        SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int );

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);                  // 2008.05.26 del
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != subSectionWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (subSectionWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 2008.05.26 upd start ------------------------------------------------>>
                            //sqlCommand.CommandText = "UPDATE SUBSECTIONRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , SECTIONGUIDENMRF=@SECTIONGUIDENM , SUBSECTIONCODERF=@SUBSECTIONCODE , SUBSECTIONNAMERF=@SUBSECTIONNAME  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE";
                            sqlTxt += "UPDATE SUBSECTIONRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += " , SUBSECTIONCODERF=@SUBSECTIONCODE" + Environment.NewLine;
                            sqlTxt += " , SUBSECTIONNAMERF=@SUBSECTIONNAME" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            sqlTxt = string.Empty;
                            // 2008.05.26 upd end --------------------------------------------------<<

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);     // 2008.05.26 del
                            findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)subSectionWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (subSectionWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            // 2008.05.26 upd stadrt -------------------------------------------->>
                            //sqlCommand.CommandText = "INSERT INTO SUBSECTIONRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SECTIONGUIDENMRF, SUBSECTIONCODERF, SUBSECTIONNAMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SECTIONGUIDENM, @SUBSECTIONCODE, @SUBSECTIONNAME)";
                            sqlTxt += "INSERT INTO SUBSECTIONRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SUBSECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,SUBSECTIONNAMERF" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlTxt += " VALUES" + Environment.NewLine;
                            sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += "    ,@SUBSECTIONCODE" + Environment.NewLine;
                            sqlTxt += "    ,@SUBSECTIONNAME" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            sqlTxt = string.Empty;
                            // 2008.05.26 upd end -----------------------------------------------<<
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)subSectionWork;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        //SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);  // 2008.05.26 del
                        SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter paraSubSectionName = sqlCommand.Parameters.Add("@SUBSECTIONNAME", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(subSectionWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(subSectionWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(subSectionWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(subSectionWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(subSectionWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(subSectionWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);
                        paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);
                        paraSubSectionName.Value = SqlDataMediator.SqlSetString(subSectionWork.SubSectionName);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(subSectionWork);
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
        /// 指定された条件の部門マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="subSectionWork">検索結果</param>
        /// <param name="parsesubSectionWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の部門マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        public int Search(out object subSectionWork, object parsesubSectionWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            subSectionWork = null;
            //parseSubSectionWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSubSectionProc(out subSectionWork, parsesubSectionWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SubSectionDB.Search");
                subSectionWork = new ArrayList();
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
        /// 指定された条件の部門マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objsubSectionWork">検索結果</param>
        /// <param name="parasubSectionWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の部門マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        public int SearchSubSectionProc(out object objsubSectionWork, object parasubSectionWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SubSectionWork subSectionWork = null;

            ArrayList subSectionWorkList = parasubSectionWork as ArrayList;
            if (subSectionWorkList == null)
            {
                subSectionWork = parasubSectionWork as SubSectionWork;
            }
            else
            {
                if (subSectionWorkList.Count > 0)
                    subSectionWork = subSectionWorkList[0] as SubSectionWork;
            }

            int status = SearchSubSectionProc(out subSectionWorkList, subSectionWork, readMode, logicalMode, ref sqlConnection);
            objsubSectionWork = subSectionWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の部門マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">検索結果</param>
        /// <param name="subSectionWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		public int SearchSubSectionProc(out ArrayList subSectionWorkList, SubSectionWork subSectionWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchSubSectionProcProc(out subSectionWorkList, subSectionWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の部門マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">検索結果</param>
        /// <param name="subSectionWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		private int SearchSubSectionProcProc(out ArrayList subSectionWorkList, SubSectionWork subSectionWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.26 upd start ---------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM SUBSECTIONRF ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT SUBSEC.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SECINFO.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SUBSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlTxt += " FROM SUBSECTIONRF SUBSEC" + Environment.NewLine;
                sqlTxt += " LEFT JOIN SECINFOSETRF SECINFO ON SUBSEC.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND SUBSEC.SECTIONCODERF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.26 upd end ------------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, subSectionWork, logicalMode);

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

        #region [GetSyncdataList]
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の部門マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
		{
			return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
		}

		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の部門マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.26 upd start ------------------------------>>
                //sqlCommand = new SqlCommand("SELECT * FROM SUBSECTIONRF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT SUBSEC.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SECINFO.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SUBSECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,SUBSEC.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlTxt += " FROM SUBSECTIONRF SUBSEC" + Environment.NewLine;
                sqlTxt += " LEFT JOIN SECINFOSETRF SECINFO ON SUBSEC.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND SUBSEC.SECTIONCODERF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.26 upd end --------------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

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

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 部門マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="subSectionWork">SubSectionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        public int LogicalDelete(ref object subSectionWork)
        {
            return LogicalDeleteSubSection(ref subSectionWork, 0);
        }

        /// <summary>
        /// 論理削除部門マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="subSectionWork">SubSectionWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除部門マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        public int RevivalLogicalDelete(ref object subSectionWork)
        {
            return LogicalDeleteSubSection(ref subSectionWork, 1);
        }

        /// <summary>
        /// 部門マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="subSectionWork">SubSectionWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        private int LogicalDeleteSubSection(ref object subSectionWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(subSectionWork);
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
                base.WriteErrorLog(ex, "SubSectionDB.LogicalDeleteCarrier :" + procModestr);

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
        /// 部門マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">SubSectionWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		public int LogicalDeleteSubSectionProc(ref ArrayList subSectionWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteSubSectionProcProc(ref subSectionWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}
		
		/// <summary>
        /// 部門マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">SubSectionWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部門マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		private int LogicalDeleteSubSectionProcProc(ref ArrayList subSectionWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.26 add

            try
            {
                if (subSectionWorkList != null)
                {
                    for (int i = 0; i < subSectionWorkList.Count; i++)
                    {
                        SubSectionWork subSectionWork = subSectionWorkList[i] as SubSectionWork;

                        //Selectコマンドの生成
                        // 2008.05.26 upd start ------------------------------------------>>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM SUBSECTIONRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += " FROM SUBSECTIONRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.26 upd end---------------------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);     // 2008.05.26 del
                        SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);                  // 2008.05.26 del
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != subSectionWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            // 2008.05.26 upd start ----------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE SUBSECTIONRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE";
                            sqlTxt = string.Empty;
                            sqlTxt += "UPDATE SUBSECTIONRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end -------------------------------------------<<

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);     // 2008.05.26 del
                            findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)subSectionWork;
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
                            else if (logicalDelCd == 0) subSectionWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else subSectionWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) subSectionWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(subSectionWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(subSectionWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(subSectionWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(subSectionWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(subSectionWork);
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
        /// 部門マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">部門マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 部門マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
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
                base.WriteErrorLog(ex, "SubSectionDB.Delete");
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
        /// 部門マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">部門マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 部門マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
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
                base.WriteErrorLog(ex, "SubSectionDB.Delete");
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
        /// 部門マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">部門マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 部門マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		public int DeleteSubSectionProc(ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteSubSectionProcProc(subSectionWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 部門マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="subSectionWorkList">部門マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 部門マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
		private int DeleteSubSectionProcProc(ArrayList subSectionWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty; // 2008.05.26 add

            try
            {

                for (int i = 0; i < subSectionWorkList.Count; i++)
                {
                    SubSectionWork subSectionWork = subSectionWorkList[i] as SubSectionWork;
                    // 2008.05.26 upd start --------------------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM SUBSECTIONRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE", sqlConnection, sqlTransaction);
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += " FROM SUBSECTIONRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    sqlTxt = string.Empty;
                    // 2008.05.26 upd end -----------------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);     // 2008.05.26 del
                    SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);
                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);                  // 2008.05.26 del
                    findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != subSectionWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // 2008.05.26 upd start -------------------------------------->>
                        //sqlCommand.CommandText = "DELETE FROM SUBSECTIONRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM SUBSECTIONRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        sqlTxt = string.Empty;
                        // 2008.05.26 upd end ----------------------------------------<<
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);     // 2008.05.26 del
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);
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
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
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
        /// <param name="subSectionWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SubSectionWork subSectionWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "SUBSEC.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(subSectionWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND SUBSEC.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND SUBSEC.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            // 2008.05.26 del start ----------------------------->>
            ////拠点コード
            //if (subSectionWork.SectionCode != "")
            //{
            //    retstring += "AND SECTIONCODERF=@FINDSECTIONCODE ";
            //    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            //    paraSectionCode.Value = SqlDataMediator.SqlSetString(subSectionWork.SectionCode);
            //}
            // 2008.05.26 del end ------------------------------<<

            //部門コード
            if (subSectionWork.SubSectionCode > 0)
            {
                retstring += "AND SUBSEC.SUBSECTIONCODERF=@FINDSUBSECTIONCODE ";
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(subSectionWork.SubSectionCode);
            }

            return retstring;
        }
        #endregion

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "SUBSEC.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND SUBSEC.UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND SUBSEC.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND SUBSEC.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SubSectionWork[] SubSectionWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SubSectionWork)
                    {
                        SubSectionWork wkSubSectionWork = paraobj as SubSectionWork;
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
                            SubSectionWorkArray = (SubSectionWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SubSectionWork[]));
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
                                SubSectionWork wkSubSectionWork = (SubSectionWork)XmlByteSerializer.Deserialize(byteArray, typeof(SubSectionWork));
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
        /// クラス格納処理 Reader → SubSectionWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SubSectionWork</returns>
        /// <remarks>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.08.16</br>
        /// </remarks>
        private SubSectionWork CopyToSubSectionWorkFromReader(ref SqlDataReader myReader)
        {
            SubSectionWork wkSubSectionWork = new SubSectionWork();

            #region クラスへ格納
            wkSubSectionWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSubSectionWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSubSectionWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSubSectionWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSubSectionWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSubSectionWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSubSectionWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSubSectionWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSubSectionWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkSubSectionWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkSubSectionWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkSubSectionWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            #endregion

            return wkSubSectionWork;
        }
        #endregion

    }
}