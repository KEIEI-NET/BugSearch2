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
// ↓ 2008.02.07 980081 a
using Broadleaf.Application.Common;
// ↑ 2008.02.07 980081 a


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// メーカーマスタメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカーマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.13</br>
    /// </remarks>
    [Serializable]
    // ↓ 2008.02.07 980081 c
    //public class MakerUDB : RemoteDB, IMakerUDB
    public class MakerUDB : RemoteDB, IMakerUDB, IGetSyncdataList
    // ↑ 2008.02.07 980081 c
    {
        /// <summary>
        /// メーカーマスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 21024　佐々木　健</br>														   
        /// <br>Date       : 2007.08.13</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2008.02.07</br>
        /// <br>             ローカルシンク対応</br>
        /// </remarks>
        public MakerUDB()
            :
        base("MAKHN09116D", "Broadleaf.Application.Remoting.ParamData.MakerUWork", "MAKERURF")
        {
        }

        #region [Read]
        /// <summary>
        /// 指定された条件のメーカーマスタを戻します
        /// </summary>
        /// <param name="parabyte">MakerUWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメーカーマスタを戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int Read( ref byte[] parabyte, int readMode )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                MakerUWork makerUWork = new MakerUWork();

                // XMLの読み込み
                makerUWork = (MakerUWork)XmlByteSerializer.Deserialize(parabyte, typeof(MakerUWork));
                if (makerUWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref makerUWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(makerUWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MakerUDB.Read");
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
        /// 指定された条件のメーカーマスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="makerUWork">MakerUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメーカーマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int ReadProc( ref MakerUWork makerUWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            string sqlText = "";

            try
            {
                //Selectコマンドの生成
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  MAKER.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,MAKER.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,MAKER.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,MAKER.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,MAKER.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,MAKER.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,MAKER.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,MAKER.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,MAKER.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " ,MAKER.MAKERNAMERF" + Environment.NewLine;
                sqlText += " ,MAKER.MAKERSHORTNAMERF" + Environment.NewLine;
                sqlText += " ,MAKER.MAKERKANANAMERF" + Environment.NewLine;
                sqlText += " ,MAKER.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += " ,MAKER.OFFERDATERF" + Environment.NewLine;
                sqlText += " ,MAKER.OFFERDATADIVRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  MAKERURF AS MAKER" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  MAKER.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND MAKER.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;

                using ( SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection) )
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(makerUWork.GoodsMakerCd);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        makerUWork = CopyToMakerUWorkFromReader(ref myReader);
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
        /// メーカーマスタ情報を登録、更新します
        /// </summary>
        /// <param name="makerUWork">MakerUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカーマスタ情報を登録、更新します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int Write(ref object makerUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(makerUWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteMakerProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                makerUWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MakerUDB.Write(ref object makerUWork)");
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
        /// メーカーマスタ情報を登録、更新します(外部からのSqlConnectionとSqlTranactionを使用)
        /// </summary>
        /// <param name="makerUWorkList">MakerUWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカーマスタ情報を登録、更新します(外部からのSqlConnectionとSqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int WriteMakerProc( ref ArrayList makerUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = "";
            try
            {
                if (makerUWorkList != null)
                {
                    for (int i = 0; i < makerUWorkList.Count; i++)
                    {
                        MakerUWork makerUWork = makerUWorkList[i] as MakerUWork;

                        //Selectコマンドの生成
                        sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  MAKER.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MAKERURF AS MAKER" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  MAKER.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND MAKER.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(makerUWork.GoodsMakerCd);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != makerUWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (makerUWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //Selectコマンドの生成
                            sqlText = "";
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  MAKERURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,GOODSMAKERCDRF = @GOODSMAKERCD" + Environment.NewLine;
                            sqlText += " ,MAKERNAMERF = @MAKERNAME" + Environment.NewLine;
                            sqlText += " ,MAKERSHORTNAMERF = @MAKERSHORTNAME" + Environment.NewLine;
                            sqlText += " ,MAKERKANANAMERF = @MAKERKANANAME" + Environment.NewLine;
                            sqlText += " ,DISPLAYORDERRF = @DISPLAYORDER" + Environment.NewLine;
                            sqlText += " ,OFFERDATERF = @OFFERDATE" + Environment.NewLine;
                            sqlText += " ,OFFERDATADIVRF = @OFFERDATADIV" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                                                      
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(makerUWork.GoodsMakerCd);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)makerUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (makerUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //Selectコマンドの生成
                            sqlText = "";
                            sqlText += "INSERT INTO MAKERURF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlText += " ,MAKERNAMERF" + Environment.NewLine;
                            sqlText += " ,MAKERSHORTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAKERKANANAMERF" + Environment.NewLine;
                            sqlText += " ,DISPLAYORDERRF" + Environment.NewLine;
                            sqlText += " ,OFFERDATERF" + Environment.NewLine;
                            sqlText += " ,OFFERDATADIVRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += " ,@MAKERNAME" + Environment.NewLine;
                            sqlText += " ,@MAKERSHORTNAME" + Environment.NewLine;
                            sqlText += " ,@MAKERKANANAME" + Environment.NewLine;
                            sqlText += " ,@DISPLAYORDER" + Environment.NewLine;
                            sqlText += " ,@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,@OFFERDATADIV" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)makerUWork;
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
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraMakerShortName = sqlCommand.Parameters.Add("@MAKERSHORTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMakerKanaName = sqlCommand.Parameters.Add("@MAKERKANANAME", SqlDbType.NVarChar);
                        SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(makerUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(makerUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(makerUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(makerUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(makerUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(makerUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(makerUWork.LogicalDeleteCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(makerUWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(makerUWork.MakerName);
                        paraMakerShortName.Value = SqlDataMediator.SqlSetString(makerUWork.MakerShortName);
                        paraMakerKanaName.Value = SqlDataMediator.SqlSetString(makerUWork.MakerKanaName);
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(makerUWork.DisplayOrder);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(makerUWork.OfferDate);
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(makerUWork.OfferDataDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(makerUWork);
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

            makerUWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件のメーカーマスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="makerUWork">検索結果</param>
        /// <param name="parseMakerUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメーカーマスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int Search(out object makerUWork, object parseMakerUWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            makerUWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchMakerProc(out makerUWork, parseMakerUWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MakerUDB.Search");
                makerUWork = new ArrayList();
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
        /// 指定された条件のメーカーマスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objmakerUWork">検索結果</param>
        /// <param name="paramakerUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメーカーマスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int SearchMakerProc(out object objmakerUWork, object paramakerUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            MakerUWork makerUWork = null;

            ArrayList makerUWorkList = paramakerUWork as ArrayList;
            if (makerUWorkList == null)
            {
                makerUWork = paramakerUWork as MakerUWork;
            }
            else
            {
                if (makerUWorkList.Count > 0)
                    makerUWork = makerUWorkList[0] as MakerUWork;
            }

            int status = SearchMakerProc(out makerUWorkList, makerUWork, readMode, logicalMode, ref sqlConnection);
            objmakerUWork = makerUWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のメーカーマスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="makerUWorkList">検索結果</param>
        /// <param name="makerUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int SearchMakerProc( out ArrayList makerUWorkList, MakerUWork makerUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  MAKER.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,MAKER.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,MAKER.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,MAKER.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,MAKER.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,MAKER.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,MAKER.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,MAKER.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,MAKER.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " ,MAKER.MAKERNAMERF" + Environment.NewLine;
                sqlText += " ,MAKER.MAKERSHORTNAMERF" + Environment.NewLine;
                sqlText += " ,MAKER.MAKERKANANAMERF" + Environment.NewLine;
                sqlText += " ,MAKER.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += " ,MAKER.OFFERDATERF" + Environment.NewLine;
                sqlText += " ,MAKER.OFFERDATADIVRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  MAKERURF AS MAKER" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, makerUWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToMakerUWorkFromReader(ref myReader));

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

            makerUWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// メーカーマスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="makerUWork">MakerUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカーマスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int LogicalDelete(ref object makerUWork)
        {
            return LogicalDeleteMaker(ref makerUWork, 0);
        }

        /// <summary>
        /// 論理削除メーカーマスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="makerUWork">MakerUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除メーカーマスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int RevivalLogicalDelete(ref object makerUWork)
        {
            return LogicalDeleteMaker(ref makerUWork, 1);
        }

        /// <summary>
        /// メーカーマスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="makerUWork">MakerUWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカーマスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        private int LogicalDeleteMaker(ref object makerUWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(makerUWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteMakerProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "MakerUDB.LogicalDeleteMaker :" + procModestr);

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
        /// メーカーマスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnectionとSqlTranactionを使用)
        /// </summary>
        /// <param name="makerUWorkList">makerUWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカーマスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnectionとSqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int LogicalDeleteMakerProc( ref ArrayList makerUWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = "";

            try
            {
                if (makerUWorkList != null)
                {
                    for (int i = 0; i < makerUWorkList.Count; i++)
                    {
                        MakerUWork makerUWork = makerUWorkList[i] as MakerUWork;

                        //Selectコマンドの生成
                        sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  MAKER.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,MAKER.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MAKERURF AS MAKER" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  MAKER.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND MAKER.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(makerUWork.GoodsMakerCd);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != makerUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //Selectコマンドの生成
                            sqlText = "";
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  MAKERURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(makerUWork.GoodsMakerCd);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)makerUWork;
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
                            else if (logicalDelCd == 0) makerUWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else makerUWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) makerUWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(makerUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(makerUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(makerUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(makerUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(makerUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(makerUWork);
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

            makerUWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// メーカーマスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">メーカーマスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : メーカーマスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
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

                status = DeleteMakerProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "MakerUDB.Delete");
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
        /// メーカーマスタ戻りデータ情報を物理削除します(外部からのSqlConnectionとSqlTranactionを使用)
        /// </summary>
        /// <param name="makerUWorkList">メーカーマスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : メーカーマスタ戻りデータ情報を物理削除します(外部からのSqlConnectionとSqlTranactionを使用)</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        public int DeleteMakerProc(ArrayList makerUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";
            try
            {

                for (int i = 0; i < makerUWorkList.Count; i++)
                {
                    MakerUWork makerUWork = makerUWorkList[i] as MakerUWork;

                    sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  MAKER.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  MAKERURF AS MAKER" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  MAKER.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND MAKER.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(makerUWork.GoodsMakerCd);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != makerUWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MAKERURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(makerUWork.GoodsMakerCd);
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
        // ↓ 2008.02.07 980081 a
        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメーカーマスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.07</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM MAKERURF ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToMakerUWorkFromReader(ref myReader));
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

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.07</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += "ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF >= @FINDUPDATEDATETIMEST " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion
        // ↑ 2008.02.07 980081 a

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
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
        /// <param name="makerUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// </remarks>
        private string MakeWhereString( ref SqlCommand sqlCommand, MakerUWork makerUWork, ConstantManagement.LogicalMode logicalMode )
        {
            string wkstring = "";
            string retstring = "WHERE " + Environment.NewLine;

            //企業コード
            retstring += "  ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(makerUWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE " + Environment.NewLine;
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

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            MakerUWork[] MakerUWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is MakerUWork)
                    {
                        MakerUWork wkMakerUWork = paraobj as MakerUWork;
                        if (wkMakerUWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkMakerUWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            MakerUWorkArray = (MakerUWork[])XmlByteSerializer.Deserialize(byteArray, typeof(MakerUWork[]));
                        }
                        catch (Exception) { }
                        if (MakerUWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(MakerUWorkArray);
                        }
                        else
                        {
                            try
                            {
                                MakerUWork wkMakerUWork = (MakerUWork)XmlByteSerializer.Deserialize(byteArray, typeof(MakerUWork));
                                if (wkMakerUWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkMakerUWork);
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
        /// クラス格納処理 Reader → makerUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MakerUWork</returns>
        /// <remarks>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// </remarks>
        private MakerUWork CopyToMakerUWorkFromReader(ref SqlDataReader myReader)
        {
            MakerUWork wkMakerUWork = new MakerUWork();

            #region クラスへ格納
            wkMakerUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkMakerUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkMakerUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkMakerUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkMakerUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkMakerUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkMakerUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkMakerUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

            wkMakerUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkMakerUWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkMakerUWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
            wkMakerUWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
            wkMakerUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkMakerUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkMakerUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            #endregion

            return wkMakerUWork;
        }
        #endregion

    }
}