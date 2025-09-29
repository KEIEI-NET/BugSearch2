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


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入金額処理区分設定マスタメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入金額処理区分設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2006.12.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class StockProcMoneyDB : RemoteDB, IStockProcMoneyDB
    {
        /// <summary>
        /// 仕入金額処理区分設定マスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        /// </remarks>
        public StockProcMoneyDB()
            :
        base("MAKON09306D", "Broadleaf.Application.Remoting.ParamData.StockProcMoneyWork", "STOCKPROCMONEYRF")
        {
        }

        #region [Read]
        /// <summary>
        /// 指定された条件の仕入金額処理区分設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">StockProcMoneyWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入金額処理区分設定マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();

                // XMLの読み込み
                stockProcMoneyWork = (StockProcMoneyWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockProcMoneyWork));
                if (stockProcMoneyWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockProcMoneyWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(stockProcMoneyWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockProcMoneyDB.Read");
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
        /// 指定された条件の仕入金額処理区分設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockProcMoneyWork">StockProcMoneyWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnectionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入金額処理区分設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int ReadProc(ref StockProcMoneyWork stockProcMoneyWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        stockProcMoneyWork = CopyToStockProcMoneyWorkFromReader(ref myReader);
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

        /// <summary>
        /// 仕入金額処理区分設定マスタを読み込む
        /// </summary>
        /// <param name="stockProcMoneyWork">仕入金額処理区分設定マスタ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns></returns>
        public int Read(ref StockProcMoneyWork stockProcMoneyWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            try
            {
                //Selectコマンドの生成
                // ↓ 20070821 980081 c
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERCDRF, FRACPROCMONEYDIVRF, FRACTIONPROCCDRF FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV", sqlConnection, sqlTransaction))
                using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FRACPROCMONEYDIVRF, FRACTIONPROCCODERF, UPPERLIMITPRICERF, FRACTIONPROCUNITRF, FRACTIONPROCCDRF FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE", sqlConnection, sqlTransaction))
                // ↑ 20070821 980081 c
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 20070821 980081 d
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    // ↑ 20070821 980081 d
                    SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                    // ↓ 20070821 980081 a
                    SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                    SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);
                    // ↑ 20070821 980081 a

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);
                    // ↓ 20070821 980081 d
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
                    // ↑ 20070821 980081 d
                    findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
                    // ↓ 20070821 980081 a
                    findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
                    findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
                    // ↑ 20070821 980081 a

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        stockProcMoneyWork = CopyToStockProcMoneyWorkFromReader(ref myReader);
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
        /// 仕入金額処理区分設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="stockProcMoneyWork">StockProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int Write(ref object stockProcMoneyWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(stockProcMoneyWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteStockProcMoneyProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                stockProcMoneyWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockProcMoneyDB.Write(ref object stockProcMoneyWork)");
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
        /// 仕入金額処理区分設定マスタ情報を登録、更新します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockProcMoneyWorkList">StockProcMoneyWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ情報を登録、更新します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int WriteStockProcMoneyProc(ref ArrayList stockProcMoneyWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (stockProcMoneyWorkList != null)
                {
                    for (int i = 0; i < stockProcMoneyWorkList.Count; i++)
                    {
                        StockProcMoneyWork stockProcMoneyWork = stockProcMoneyWorkList[i] as StockProcMoneyWork;

                        //Selectコマンドの生成
                        // ↓ 20070821 980081 c
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV", sqlConnection, sqlTransaction);
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE", sqlConnection, sqlTransaction);
                        // ↑ 20070821 980081 c

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        // ↓ 20070821 980081 d
                        //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        // ↑ 20070821 980081 d
                        SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                        // ↓ 20070821 980081 a
                        SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                        SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);
                        // ↑ 20070821 980081 a

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);
                        // ↓ 20070821 980081 d
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
                        // ↑ 20070821 980081 d
                        findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
                        // ↓ 20070821 980081 a
                        findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
                        findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
                        // ↑ 20070821 980081 a

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockProcMoneyWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (stockProcMoneyWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // ↓ 20070821 980081 c
                            //sqlCommand.CommandText = "UPDATE STOCKPROCMONEYRF SET  UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SUPPLIERCDRF=@SUPPLIERCD , FRACPROCMONEYDIVRF=@FRACPROCMONEYDIV , FRACTIONPROCCDRF=@FRACTIONPROCCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV";
                            sqlCommand.CommandText = "UPDATE STOCKPROCMONEYRF SET  UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FRACPROCMONEYDIVRF=@FRACPROCMONEYDIV , FRACTIONPROCCODERF=@FRACTIONPROCCODE , UPPERLIMITPRICERF=@UPPERLIMITPRICE , FRACTIONPROCUNITRF=@FRACTIONPROCUNIT , FRACTIONPROCCDRF=@FRACTIONPROCCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                            // ↑ 20070821 980081 c
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);
                            // ↓ 20070821 980081 d
                            //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
                            // ↑ 20070821 980081 d
                            findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
                            // ↓ 20070821 980081 a
                            findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
                            findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
                            // ↑ 20070821 980081 a

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockProcMoneyWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockProcMoneyWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            // ↓ 20070821 980081 c
                            //sqlCommand.CommandText = "INSERT INTO STOCKPROCMONEYRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERCDRF, FRACPROCMONEYDIVRF, FRACTIONPROCCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SUPPLIERCD, @FRACPROCMONEYDIV, @FRACTIONPROCCD)";
                            sqlCommand.CommandText = "INSERT INTO STOCKPROCMONEYRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FRACPROCMONEYDIVRF, FRACTIONPROCCODERF, UPPERLIMITPRICERF, FRACTIONPROCUNITRF, FRACTIONPROCCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FRACPROCMONEYDIV, @FRACTIONPROCCODE, @UPPERLIMITPRICE, @FRACTIONPROCUNIT, @FRACTIONPROCCD)";
                            // ↑ 20070821 980081 c
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockProcMoneyWork;
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
                        // ↓ 20070821 980081 d
                        //SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        // ↑ 20070821 980081 d
                        SqlParameter paraFracProcMoneyDiv = sqlCommand.Parameters.Add("@FRACPROCMONEYDIV", SqlDbType.Int);
                        // ↓ 20070821 980081 a
                        SqlParameter paraFractionProcCode = sqlCommand.Parameters.Add("@FRACTIONPROCCODE", SqlDbType.Int);
                        SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);
                        SqlParameter paraFractionProcUnit = sqlCommand.Parameters.Add("@FRACTIONPROCUNIT", SqlDbType.Float);
                        // ↑ 20070821 980081 a
                        SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockProcMoneyWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockProcMoneyWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockProcMoneyWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.LogicalDeleteCode);
                        // ↓ 20070821 980081 d
                        //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
                        // ↑ 20070821 980081 d
                        paraFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
                        // ↓ 20070821 980081 a
                        paraFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
                        paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
                        paraFractionProcUnit.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.FractionProcUnit);
                        // ↑ 20070821 980081 a
                        paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCd);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockProcMoneyWork);
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

            stockProcMoneyWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の仕入金額処理区分設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="stockProcMoneyWork">検索結果</param>
        /// <param name="parseStockProcMoneyWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入金額処理区分設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int Search(out object stockProcMoneyWork, object parseStockProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockProcMoneyWork = null;
            //parseStockProcMoneyWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockProcMoneyProc(out stockProcMoneyWork, parseStockProcMoneyWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockProcMoneyDB.Search");
                stockProcMoneyWork = new ArrayList();
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
        /// 指定された条件の仕入金額処理区分設定マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objstockProcMoneyWork">検索結果</param>
        /// <param name="parastockProcMoneyWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入金額処理区分設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int SearchStockProcMoneyProc(out object objstockProcMoneyWork, object parastockProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockProcMoneyWork stockProcMoneyWork = null;

            ArrayList stockProcMoneyWorkList = parastockProcMoneyWork as ArrayList;
            if (stockProcMoneyWorkList == null)
            {
                stockProcMoneyWork = parastockProcMoneyWork as StockProcMoneyWork;
            }
            else
            {
                if (stockProcMoneyWorkList.Count > 0)
                    stockProcMoneyWork = stockProcMoneyWorkList[0] as StockProcMoneyWork;
            }

            int status = SearchStockProcMoneyProc(out stockProcMoneyWorkList, stockProcMoneyWork, readMode, logicalMode, ref sqlConnection);
            objstockProcMoneyWork = stockProcMoneyWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の仕入金額処理区分設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockProcMoneyWorkList">検索結果</param>
        /// <param name="stockProcMoneyWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入金額処理区分設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int SearchStockProcMoneyProc(out ArrayList stockProcMoneyWorkList, StockProcMoneyWork stockProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM STOCKPROCMONEYRF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockProcMoneyWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockProcMoneyWorkFromReader(ref myReader));

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

            stockProcMoneyWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 仕入金額処理区分設定マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="stockProcMoneyWork">StockProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int LogicalDelete(ref object stockProcMoneyWork)
        {
            return LogicalDeleteStockProcMoney(ref stockProcMoneyWork, 0);
        }

        /// <summary>
        /// 論理削除仕入金額処理区分設定マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="stockProcMoneyWork">StockProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除仕入金額処理区分設定マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int RevivalLogicalDelete(ref object stockProcMoneyWork)
        {
            return LogicalDeleteStockProcMoney(ref stockProcMoneyWork, 1);
        }

        /// <summary>
        /// 仕入金額処理区分設定マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="stockProcMoneyWork">StockProcMoneyWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        private int LogicalDeleteStockProcMoney(ref object stockProcMoneyWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(stockProcMoneyWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteStockProcMoneyProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "StockProcMoneyDB.LogicalDeleteCarrier :" + procModestr);

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
        /// 仕入金額処理区分設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockProcMoneyWorkList">StockProcMoneyWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        public int LogicalDeleteStockProcMoneyProc(ref ArrayList stockProcMoneyWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (stockProcMoneyWorkList != null)
                {
                    for (int i = 0; i < stockProcMoneyWorkList.Count; i++)
                    {
                        StockProcMoneyWork stockProcMoneyWork = stockProcMoneyWorkList[i] as StockProcMoneyWork;

                        //Selectコマンドの生成
                        // ↓ 20070821 980081 c
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV", sqlConnection, sqlTransaction);
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE", sqlConnection, sqlTransaction);
                        // ↑ 20070821 980081 c

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        // ↓ 20070821 980081 d
                        //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        // ↑ 20070821 980081 d
                        SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                        // ↓ 20070821 980081 a
                        SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                        SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);
                        // ↑ 20070821 980081 a

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);
                        // ↓ 20070821 980081 d
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
                        // ↑ 20070821 980081 d
                        findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
                        // ↓ 20070821 980081 a
                        findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
                        findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
                        // ↑ 20070821 980081 a

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockProcMoneyWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // ↓ 20070821 980081 c
                            //sqlCommand.CommandText = "UPDATE STOCKPROCMONEYRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV";
                            sqlCommand.CommandText = "UPDATE STOCKPROCMONEYRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                            // ↑ 20070821 980081 c
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);
                            // ↓ 20070821 980081 d
                            //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
                            // ↑ 20070821 980081 d
                            findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
                            // ↓ 20070821 980081 a
                            findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
                            findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
                            // ↑ 20070821 980081 a

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockProcMoneyWork;
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
                            else if (logicalDelCd == 0) stockProcMoneyWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else stockProcMoneyWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockProcMoneyWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockProcMoneyWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockProcMoneyWork);
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

            stockProcMoneyWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 仕入金額処理区分設定マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">仕入金額処理区分設定マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
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

                status = DeleteStockProcMoneyProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "StockProcMoneyDB.Delete");
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
        /// 仕入金額処理区分設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockProcMoneyWorkList">仕入金額処理区分設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.04</br>
        public int DeleteStockProcMoneyProc(ArrayList stockProcMoneyWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < stockProcMoneyWorkList.Count; i++)
                {
                    StockProcMoneyWork stockProcMoneyWork = stockProcMoneyWorkList[i] as StockProcMoneyWork;
                    // ↓ 20070821 980081 c
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV", sqlConnection, sqlTransaction);
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE", sqlConnection, sqlTransaction);
                    // ↑ 20070821 980081 c

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 20070821 980081 d
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    // ↑ 20070821 980081 d
                    SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                    // ↓ 20070821 980081 a
                    SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                    SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);
                    // ↑ 20070821 980081 a

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);
                    // ↓ 20070821 980081 d
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
                    // ↑ 20070821 980081 d
                    findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
                    // ↓ 20070821 980081 a
                    findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
                    findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
                    // ↑ 20070821 980081 a


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockProcMoneyWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // ↓ 20070821 980081 c
                        //sqlCommand.CommandText = "DELETE FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERCDRF=@FINDSUPPLIERCD AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV";
                        sqlCommand.CommandText = "DELETE FROM STOCKPROCMONEYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                        // ↑ 20070821 980081 c
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);
                        // ↓ 20070821 980081 d
                        //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
                        // ↑ 20070821 980081 d
                        findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
                        // ↓ 20070821 980081 a
                        findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
                        findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
                        // ↑ 20070821 980081 a
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
        /// <br>Date       : 2006.12.12</br>
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
        /// <param name="stockProcMoneyWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockProcMoneyWork stockProcMoneyWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockProcMoneyWork.EnterpriseCode);

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

            // ↓ 20070821 980081 d
            /*
            //仕入先コード
            if (stockProcMoneyWork.SupplierCd > 0)
            {
                retstring += "AND SUPPLIERCDRF=@FINDSUPPLIERCD ";
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.SupplierCd);
            }
            */
            // ↑ 20070821 980081 d
            //端数処理対象金額区分
            // ↓ 20070821 980081 c
            //if (stockProcMoneyWork.FracProcMoneyDiv > 0)
            if (stockProcMoneyWork.FracProcMoneyDiv >= 0)
            // ↑ 20070821 980081 c
            {
                retstring += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                SqlParameter paraFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                paraFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FracProcMoneyDiv);
            }
            // ↓ 20070821 980081 a
            //端数処理コード
            if (stockProcMoneyWork.FractionProcCode >= 0)
            {
                retstring += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                SqlParameter paraFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                paraFractionProcCode.Value = SqlDataMediator.SqlSetInt32(stockProcMoneyWork.FractionProcCode);
            }
            //上限金額
            if (stockProcMoneyWork.UpperLimitPrice > 0)
            {
                retstring += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE ";
                SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);
                paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(stockProcMoneyWork.UpperLimitPrice);
            }
            // ↑ 20070821 980081 a


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
        /// <br>Date       : 2006.12.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockProcMoneyWork[] StockProcMoneyWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is StockProcMoneyWork)
                    {
                        StockProcMoneyWork wkStockProcMoneyWork = paraobj as StockProcMoneyWork;
                        if (wkStockProcMoneyWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockProcMoneyWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockProcMoneyWorkArray = (StockProcMoneyWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockProcMoneyWork[]));
                        }
                        catch (Exception) { }
                        if (StockProcMoneyWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockProcMoneyWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockProcMoneyWork wkStockProcMoneyWork = (StockProcMoneyWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockProcMoneyWork));
                                if (wkStockProcMoneyWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockProcMoneyWork);
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
        /// クラス格納処理 Reader → StockProcMoneyWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockProcMoneyWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        /// </remarks>
        private StockProcMoneyWork CopyToStockProcMoneyWorkFromReader(ref SqlDataReader myReader)
        {
            StockProcMoneyWork wkStockProcMoneyWork = new StockProcMoneyWork();

            #region クラスへ格納
            wkStockProcMoneyWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockProcMoneyWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockProcMoneyWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockProcMoneyWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockProcMoneyWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockProcMoneyWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockProcMoneyWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockProcMoneyWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            // ↓ 20070821 980081 d
            //wkStockProcMoneyWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            // ↑ 20070821 980081 d
            wkStockProcMoneyWork.FracProcMoneyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCMONEYDIVRF"));
            // ↓ 20070821 980081 a
            wkStockProcMoneyWork.FractionProcCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCODERF"));
            wkStockProcMoneyWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPPERLIMITPRICERF"));
            wkStockProcMoneyWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));
            // ↑ 20070821 980081 a
            wkStockProcMoneyWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            #endregion

            return wkStockProcMoneyWork;
        }
        #endregion

    }
}