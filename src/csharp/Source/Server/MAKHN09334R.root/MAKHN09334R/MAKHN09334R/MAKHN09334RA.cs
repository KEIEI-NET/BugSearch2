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
    /// 倉庫マスタメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 倉庫マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2006.12.20</br>
    /// <br></br>
    /// <br>Update Note: 2007.08.13 96050 横川 昌令 流通基幹への流用に於いての仕様変更を反映</br>
    /// <br>           :            倉庫コードを拠点でユニークでなく、企業でユニークとする</br>
    /// <br>Update Note: 2008.05.26 20081 疋田 勇人 ＰＭ.ＮＳ用に変更</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class WarehouseDB : RemoteDB, IWarehouseDB, IGetSyncdataList
    {
        /// <summary>
        /// 倉庫マスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>														   
        /// <br>Date       : 2006.12.20</br>
        /// </remarks>
        public WarehouseDB()
            :
        base("MAKHN09336D", "Broadleaf.Application.Remoting.ParamData.WarehouseWork", "WAREHOUSERF")
        {
        }

        #region [Read]
        /// <summary>
        /// 指定された条件の倉庫マスタを戻します
        /// </summary>
        /// <param name="parabyte">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
           int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                WarehouseWork warehouseWork = new WarehouseWork();

                // XMLの読み込み
                warehouseWork = (WarehouseWork)XmlByteSerializer.Deserialize(parabyte, typeof(WarehouseWork));
                if (warehouseWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref warehouseWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(warehouseWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WarehouseDB.Read");
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
        /// 指定された条件の倉庫マスタを戻します
        /// </summary>
        /// <param name="paraobj">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int Read(ref object paraobj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                WarehouseWork warehouseWork = paraobj as WarehouseWork;

                if (warehouseWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref warehouseWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WarehouseDB.Read");
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
        /// 指定された条件の倉庫マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int ReadProc(ref WarehouseWork warehouseWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref warehouseWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の倉庫マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        private int ReadProcProc( ref WarehouseWork warehouseWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // 2008.05.26 upd start -------------------------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM WAREHOUSERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE ", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.26 upd end ----------------------------------------------------------<<
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);    // 2008.05.26 del
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);                  // 2008.05.26 del
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        warehouseWork = CopyToWarehouseWorkFromReader(ref myReader);
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
        /// 倉庫マスタ情報を登録、更新します
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int Write(ref object warehouseWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(warehouseWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteWarehouseProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                warehouseWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WarehouseDB.Write(ref object warehouseWork)");
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
        /// 倉庫マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">WarehouseWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.13 96050 横川 昌令 流通基幹への流用に於いての仕様変更を反映</br>
        /// <br>           :            倉庫コードを拠点でユニークでなく、企業でユニークとする</br>
        /// <br></br>
        public int WriteWarehouseProc(ref ArrayList warehouseWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteWarehouseProcProc(ref warehouseWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 倉庫マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">WarehouseWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.13 96050 横川 昌令 流通基幹への流用に於いての仕様変更を反映</br>
        /// <br>           :            倉庫コードを拠点でユニークでなく、企業でユニークとする</br>
        /// <br></br>
        private int WriteWarehouseProcProc( ref ArrayList warehouseWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.26 add
            try
            {
                if (warehouseWorkList != null)
                {
                    for (int i = 0; i < warehouseWorkList.Count; i++)
                    {
                        WarehouseWork warehouseWork = warehouseWorkList[i] as WarehouseWork;

                        //2007.08.13 #1 Update Start
                        //  条件から拠点コード(SectionCode)をはずす
                        //Selectコマンドの生成
                        // 2008.05.26 upd start ----------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF FROM WAREHOUSERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                        sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.26 upd end -------------------------------------------<<
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                        //--ここから　変更前コード 2007.08.13
                        ////Selectコマンドの生成
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM WAREHOUSERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction);
                        //
                        ////Prameterオブジェクトの作成
                        //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        //SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        //
                        ////Parameterオブジェクトへ値設定
                        //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);
                        //findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);
                        //--ここまで　変更前コード 2007.08.13
                        //2007.08.13 #1 Update End

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != warehouseWork.UpdateDateTime)
                            {
                                //2007.08.13 #2 Update Start
                                string _sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); //拠点コード
                                //新規登録で該当データ有りの場合には重複
                                if (warehouseWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで拠点コード違いの場合は重複 (2007.08.13 #2 で追加) 
                                else if (_sectionCode != warehouseWork.SectionCode) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;

                                //--ここから　変更前コード 2007.08.13
                                ////新規登録で該当データ有りの場合には重複
                                //if (warehouseWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                ////既存データで更新日時違いの場合には排他
                                //else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                //sqlCommand.Cancel();
                                //if (myReader.IsClosed == false) myReader.Close();
                                //return status;
                                //--ここまで　変更前コード 2007.08.13
                                //2007.08.13 #2 Update End
                            }

                            //2007.08.13 #3 Update Start
                            //  条件から拠点コード(SectionCode)をはずす
                            // 2008.05.26 upd start--------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE WAREHOUSERF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , WAREHOUSECODERF=@WAREHOUSECODE , WAREHOUSENAMERF=@WAREHOUSENAME , WAREHOUSENOTE1RF=@WAREHOUSENOTE1 , WAREHOUSENOTE2RF=@WAREHOUSENOTE2 , WAREHOUSENOTE3RF=@WAREHOUSENOTE3 , WAREHOUSENOTE4RF=@WAREHOUSENOTE4 , WAREHOUSENOTE5RF=@WAREHOUSENOTE5 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE";
                            sqlTxt = string.Empty;
                            sqlTxt += "UPDATE WAREHOUSERF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            sqlTxt += " , WAREHOUSENAMERF=@WAREHOUSENAME" + Environment.NewLine;
                            sqlTxt += " , WAREHOUSENOTE1RF=@WAREHOUSENOTE1" + Environment.NewLine;
                            sqlTxt += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlTxt += " , MAINMNGWAREHOUSECDRF=@MAINMNGWAREHOUSECD" + Environment.NewLine;
                            sqlTxt += " , STOCKBLNKTREMARKRF=@STOCKBLNKTREMARK" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end ----------------------------------------<<

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                            //--ここから　変更前コード 2007.08.13
                            //sqlCommand.CommandText = "UPDATE WAREHOUSERF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , WAREHOUSECODERF=@WAREHOUSECODE , WAREHOUSENAMERF=@WAREHOUSENAME , WAREHOUSENOTE1RF=@WAREHOUSENOTE1 , WAREHOUSENOTE2RF=@WAREHOUSENOTE2 , WAREHOUSENOTE3RF=@WAREHOUSENOTE3 , WAREHOUSENOTE4RF=@WAREHOUSENOTE4 , WAREHOUSENOTE5RF=@WAREHOUSENOTE5 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE";
                            //
                            ////KEYコマンドを再設定
                            //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);
                            //findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);
                            //--ここまで　変更前コード 2007.08.13
                            //2007.08.13 #3 Update End

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)warehouseWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (warehouseWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 2008.05.26 upd start -------------------------------------->>
                            // 念のため
                            if (warehouseWork.MainMngWarehouseCd == null)
                            {
                                warehouseWork.MainMngWarehouseCd = string.Empty;
                            }

                            if (warehouseWork.StockBlnktRemark == null)
                            {
                                warehouseWork.StockBlnktRemark = string.Empty;
                            }
                            // 2008.05.26 upd end ----------------------------------------<<

                            //新規作成時のSQL文を生成
                            // 2008.05.26 upd start -------------------------------------->>
                            //sqlCommand.CommandText = "INSERT INTO WAREHOUSERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSENOTE1RF, WAREHOUSENOTE2RF, WAREHOUSENOTE3RF, WAREHOUSENOTE4RF, WAREHOUSENOTE5RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSENOTE1, @WAREHOUSENOTE2, @WAREHOUSENOTE3, @WAREHOUSENOTE4, @WAREHOUSENOTE5)";
                            sqlTxt = string.Empty;
                            sqlTxt += "INSERT INTO WAREHOUSERF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                            sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                            sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                            sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
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
                            sqlTxt += "    ,@WAREHOUSECODE" + Environment.NewLine;
                            sqlTxt += "    ,@WAREHOUSENAME" + Environment.NewLine;
                            sqlTxt += "    ,@WAREHOUSENOTE1" + Environment.NewLine;
                            sqlTxt += "    ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlTxt += "    ,@MAINMNGWAREHOUSECD" + Environment.NewLine;
                            sqlTxt += "    ,@STOCKBLNKTREMARK" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end ----------------------------------------<<
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)warehouseWork;
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
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseNote1 = sqlCommand.Parameters.Add("@WAREHOUSENOTE1", SqlDbType.NVarChar);
                        // 2008.05.26 upd start --------------------------->>
                        //SqlParameter paraWarehouseNote2 = sqlCommand.Parameters.Add("@WAREHOUSENOTE2", SqlDbType.NVarChar);
                        //SqlParameter paraWarehouseNote3 = sqlCommand.Parameters.Add("@WAREHOUSENOTE3", SqlDbType.NVarChar);
                        //SqlParameter paraWarehouseNote4 = sqlCommand.Parameters.Add("@WAREHOUSENOTE4", SqlDbType.NVarChar);
                        //SqlParameter paraWarehouseNote5 = sqlCommand.Parameters.Add("@WAREHOUSENOTE5", SqlDbType.NVarChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraMainMngWarehouseCd = sqlCommand.Parameters.Add("@MAINMNGWAREHOUSECD", SqlDbType.NChar);
                        SqlParameter paraStockBlnktRemark = sqlCommand.Parameters.Add("@STOCKBLNKTREMARK", SqlDbType.NChar);
                        // 2008.05.26 upd end -----------------------------<<
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(warehouseWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(warehouseWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(warehouseWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(warehouseWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseName);
                        paraWarehouseNote1.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote1);
                        // 2008.05.26 upd start --------------------------->>
                        //paraWarehouseNote2.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote2);
                        //paraWarehouseNote3.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote3);
                        //paraWarehouseNote4.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote4);
                        //paraWarehouseNote5.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote5);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(warehouseWork.CustomerCode);
                        paraMainMngWarehouseCd.Value = SqlDataMediator.SqlSetString(warehouseWork.MainMngWarehouseCd);
                        paraStockBlnktRemark.Value = SqlDataMediator.SqlSetString(warehouseWork.StockBlnktRemark);
                        // 2008.05.26 upd end -----------------------------<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(warehouseWork);
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

            warehouseWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の倉庫マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="warehouseWork">検索結果</param>
        /// <param name="parseWarehouseWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int Search(out object warehouseWork, object parseWarehouseWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            warehouseWork = null;
            //parseWarehouseWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchWarehouseProc(out warehouseWork, parseWarehouseWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WarehouseDB.Search");
                warehouseWork = new ArrayList();
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
        /// 指定された条件の倉庫マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objwarehouseWork">検索結果</param>
        /// <param name="parawarehouseWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int SearchWarehouseProc(out object objwarehouseWork, object parawarehouseWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            WarehouseWork warehouseWork = null;

            ArrayList warehouseWorkList = parawarehouseWork as ArrayList;
            if (warehouseWorkList == null)
            {
                warehouseWork = parawarehouseWork as WarehouseWork;
            }
            else
            {
                if (warehouseWorkList.Count > 0)
                    warehouseWork = warehouseWorkList[0] as WarehouseWork;
            }

            int status = SearchWarehouseProc(out warehouseWorkList, warehouseWork, readMode, logicalMode, ref sqlConnection);
            objwarehouseWork = warehouseWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の倉庫マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">検索結果</param>
        /// <param name="warehouseWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int SearchWarehouseProc(out ArrayList warehouseWorkList, WarehouseWork warehouseWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchWarehouseProcProc(out warehouseWorkList, warehouseWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の倉庫マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">検索結果</param>
        /// <param name="warehouseWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        private int SearchWarehouseProcProc( out ArrayList warehouseWorkList, WarehouseWork warehouseWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.26 upd start -------------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM WAREHOUSERF ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.26 upd end ----------------------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, warehouseWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToWarehouseWorkFromReader(ref myReader));

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

            warehouseWorkList = al;

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
        /// <br>Note       : 指定された条件の倉庫マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
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
        /// <br>Note       : 指定された条件の倉庫マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        private int GetSyncdataListProc( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.26 upd start -------------------------------------->>
                sqlCommand = new SqlCommand("SELECT * FROM WAREHOUSERF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.26 upd end ----------------------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToWarehouseWorkFromReader(ref myReader));

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
        /// 倉庫マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int LogicalDelete(ref object warehouseWork)
        {
            return LogicalDeleteWarehouse(ref warehouseWork, 0);
        }

        /// <summary>
        /// 論理削除倉庫マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除倉庫マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int RevivalLogicalDelete(ref object warehouseWork)
        {
            return LogicalDeleteWarehouse(ref warehouseWork, 1);
        }

        /// <summary>
        /// 倉庫マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        private int LogicalDeleteWarehouse(ref object warehouseWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(warehouseWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteWarehouseProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "WarehouseDB.LogicalDeleteCarrier :" + procModestr);

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
        /// 倉庫マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">WarehouseWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int LogicalDeleteWarehouseProc(ref ArrayList warehouseWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteWarehouseProcProc(ref warehouseWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 倉庫マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">WarehouseWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 倉庫マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        private int LogicalDeleteWarehouseProcProc( ref ArrayList warehouseWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.26 add
            try
            {
                if (warehouseWorkList != null)
                {
                    for (int i = 0; i < warehouseWorkList.Count; i++)
                    {
                        WarehouseWork warehouseWork = warehouseWorkList[i] as WarehouseWork;

                        //Selectコマンドの生成
                        // 2008.05.26 upd start ------------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM WAREHOUSERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                        sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                        sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                        sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                        sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                        sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        // 2008.05.26 upd end ---------------------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);     // 2008.05.26 del
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);  // 2008.05.26 del
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != warehouseWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // 2008.05.26 upd start --------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE WAREHOUSERF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE";
                            sqlTxt += "UPDATE WAREHOUSERF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.26 upd end -----------------------------------------<<

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                            //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode); // 2008.05.26 del
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)warehouseWork;
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
                            else if (logicalDelCd == 0) warehouseWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else warehouseWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) warehouseWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(warehouseWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(warehouseWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(warehouseWork);
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

            warehouseWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 倉庫マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">倉庫マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 倉庫マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
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

                status = DeleteWarehouseProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "WarehouseDB.Delete");
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
        /// 倉庫マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">倉庫マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 倉庫マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
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

                status = DeleteWarehouseProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "WarehouseDB.Delete");
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
        /// 倉庫マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">倉庫マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 倉庫マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        public int DeleteWarehouseProc(ArrayList warehouseWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteWarehouseProcProc(warehouseWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 倉庫マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">倉庫マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 倉庫マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        private int DeleteWarehouseProcProc( ArrayList warehouseWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty;  // 2008.05.26 add
            try
            {

                for (int i = 0; i < warehouseWorkList.Count; i++)
                {
                    WarehouseWork warehouseWork = warehouseWorkList[i] as WarehouseWork;
                    // 2008.05.26 upd start -------------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM WAREHOUSERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction);
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    sqlTxt = string.Empty;
                    // 2008.05.26 upd end ----------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.26 del
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);    // 2008.05.26 del
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != warehouseWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        // 2008.05.26 upd start ---------------------------------->>
                        //sqlCommand.CommandText = "DELETE FROM WAREHOUSERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        sqlTxt = string.Empty;
                        // 2008.05.26 upd end ------------------------------------<<
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);     // 2008.05.26 del
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);
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
        /// <param name="warehouseWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, WarehouseWork warehouseWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);

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

            // 2008.05.26 del start --------------------------------->>
            ////拠点コード
            //if (warehouseWork.SectionCode != "")
            //{
            //    retstring += "AND SECTIONCODERF=@FINDSECTIONCODE ";
            //    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            //    paraSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);
            //}
            // 2008.05.26 del end -----------------------------------<<

            //倉庫コード
            if (warehouseWork.WarehouseCode != "")
            {
                retstring += "AND WAREHOUSECODERF=@FINDWAREHOUSECODE ";
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);
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
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
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
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            WarehouseWork[] WarehouseWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is WarehouseWork)
                    {
                        WarehouseWork wkWarehouseWork = paraobj as WarehouseWork;
                        if (wkWarehouseWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkWarehouseWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            WarehouseWorkArray = (WarehouseWork[])XmlByteSerializer.Deserialize(byteArray, typeof(WarehouseWork[]));
                        }
                        catch (Exception) { }
                        if (WarehouseWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(WarehouseWorkArray);
                        }
                        else
                        {
                            try
                            {
                                WarehouseWork wkWarehouseWork = (WarehouseWork)XmlByteSerializer.Deserialize(byteArray, typeof(WarehouseWork));
                                if (wkWarehouseWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkWarehouseWork);
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
        /// クラス格納処理 Reader → WarehouseWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>WarehouseWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
        /// </remarks>
        private WarehouseWork CopyToWarehouseWorkFromReader(ref SqlDataReader myReader)
        {
            WarehouseWork wkWarehouseWork = new WarehouseWork();

            #region クラスへ格納
            wkWarehouseWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkWarehouseWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkWarehouseWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkWarehouseWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkWarehouseWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkWarehouseWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkWarehouseWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkWarehouseWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkWarehouseWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkWarehouseWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkWarehouseWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkWarehouseWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
            // 2008.05.26 upd start ----------------------------------->>
            //wkWarehouseWork.WarehouseNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE2RF"));
            //wkWarehouseWork.WarehouseNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE3RF"));
            //wkWarehouseWork.WarehouseNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE4RF"));
            //wkWarehouseWork.WarehouseNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE5RF"));
            wkWarehouseWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkWarehouseWork.MainMngWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAINMNGWAREHOUSECDRF"));
            wkWarehouseWork.StockBlnktRemark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKBLNKTREMARKRF"));
            // 2008.05.26 upd end -------------------------------------<<
            #endregion

            return wkWarehouseWork;
        }
        #endregion

    }
}