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
    /// 休業日設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 休業日設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20096 村瀬　勝也</br>
    /// <br>Date       : 2007.01.25</br>
    /// <br></br>
    /// <br>Update Note: 2007.02.19 村瀬　勝也 Search検索条件追加</br>
    /// </remarks>
    [Serializable]
    public class HolidaySettingDB : RemoteDB, IHolidaySettingDB
    {
        /// <summary>
        /// 休業日設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        public HolidaySettingDB()
            :
            base("MAKNT09146D", "Broadleaf.Application.Remoting.ParamData.HolidaySettingWork", "HOLIDAYSETTINGRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の休業日設定マスタ情報LISTを戻します

        /// </summary>
        /// <param name="HolidaySettingWork">検索結果</param>
        /// <param name="paraHolidaySettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の休業日設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int Search(out object HolidaySettingWork, object paraHolidaySettingWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            HolidaySettingWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchHolidaySettingRtDtProc(out HolidaySettingWork, paraHolidaySettingWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "HolidaySettingDB.Search");
                HolidaySettingWork = new ArrayList();
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
        /// 指定された条件の休業日設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objHolidaySettingWork">検索結果</param>
        /// <param name="paraHolidaySettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の休業日設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int SearchHolidaySettingRtDtProc(out object objHolidaySettingWork, object paraHolidaySettingWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            HolidaySettingWork holidaySetting = null;

            ArrayList HolidaySettingWorkList = paraHolidaySettingWork as ArrayList;
            if (HolidaySettingWorkList == null)
            {
                holidaySetting = paraHolidaySettingWork as HolidaySettingWork;
            }
            else
            {
                if (HolidaySettingWorkList.Count > 0)
                    holidaySetting = HolidaySettingWorkList[0] as HolidaySettingWork;
            }

            int status = SearchHolidaySettingRtDtProc(out HolidaySettingWorkList, holidaySetting, readMode, logicalMode, ref sqlConnection);
            objHolidaySettingWork = HolidaySettingWorkList;
            
            return status;
        }

        /// <summary>
        /// 指定された条件の休業日設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="holidaySettingList">検索結果</param>
        /// <param name="holidaySetting">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の休業日設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int SearchHolidaySettingRtDtProc(out ArrayList holidaySettingList, HolidaySettingWork holidaySetting, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM HOLIDAYSETTINGRF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, holidaySetting, logicalMode);
                sqlCommand.CommandText += "ORDER BY APPLYDATERF ";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToHolidaySettingWorkFromReader(ref myReader));

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

            holidaySettingList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の休業日設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">HolidaySettingWorkオブジェクト</param>
        /// <param name="parabyte">オブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の休業日設定マスタを戻します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                HolidaySettingWork holidaySetting = new HolidaySettingWork();

                // XMLの読み込み
                holidaySetting = (HolidaySettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(HolidaySettingWork));
                if (holidaySetting == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref holidaySetting, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(holidaySetting);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "HolidaySettingDB.Read");
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
        /// 指定された条件の休業日設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="parabyte">HolidaySettingWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の休業日設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int ReadProc(ref HolidaySettingWork holidaySettingWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, APPLYDATERF, APPLYDATECDRF FROM HOLIDAYSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND APPLYDATERF=@FINDAPPLYDATE ", sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaApplyDate = sqlCommand.Parameters.Add("@FINDAPPLYDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);
                    findParaApplyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyDate);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        holidaySettingWork = CopyToHolidaySettingWorkFromReader(ref myReader);
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
        /// 休業日設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="holidaySetting">HolidaySettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 休業日設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int Write(ref object holidaySetting)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(holidaySetting);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteHolidaySettingRtDtProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                holidaySetting = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "HolidaySettingDB.Write(ref object holidaySetting)");
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
        /// 休業日設定マスタ情報を登録、更新します(外部からのSqlConnection & SqlTranactionを使用)
        /// </summary>
        /// <param name="HolidaySettingWorkList">HolidaySettingWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 休業日設定マスタ情報を登録、更新します(外部からのSqlConnection & SqlTranactionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int WriteHolidaySettingRtDtProc(ref ArrayList holidaySettingList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (holidaySettingList != null)
                {
                    for (int i = 0; i < holidaySettingList.Count; i++)
                    {
                        HolidaySettingWork holidaySettingWork= holidaySettingList[i] as HolidaySettingWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, APPLYDATERF, APPLYDATECDRF FROM HOLIDAYSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND APPLYDATERF=@FINDAPPLYDATE ", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaApplyDate = sqlCommand.Parameters.Add("@FINDAPPLYDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);
                        findParaApplyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyDate);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != holidaySettingWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (holidaySettingWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE HOLIDAYSETTINGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , APPLYDATERF=@APPLYDATE , APPLYDATECDRF=@APPLYDATECD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND APPLYDATERF=@FINDAPPLYDATE";
                                                      
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);
                            findParaApplyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyDate);


                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)holidaySettingWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (holidaySettingWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO HOLIDAYSETTINGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, APPLYDATERF, APPLYDATECDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @APPLYDATE, @APPLYDATECD)";

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)holidaySettingWork;
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
                        SqlParameter paraApplyDate = sqlCommand.Parameters.Add("@APPLYDATE", SqlDbType.Int);
                        SqlParameter paraApplyDateCd = sqlCommand.Parameters.Add("@APPLYDATECD", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(holidaySettingWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(holidaySettingWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(holidaySettingWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(holidaySettingWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(holidaySettingWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(holidaySettingWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);
                        paraApplyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyDate);
                        paraApplyDateCd.Value = SqlDataMediator.SqlSetInt32(holidaySettingWork.ApplyDateCd);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(holidaySettingWork);
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

            holidaySettingList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 休業日設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="holidaySetting">HolidaySettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 休業日設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int LogicalDelete(ref object holidaySetting)
        {
            return LogicalDeleteHolidaySetting(ref holidaySetting, 0);
        }

        /// <summary>
        /// 論理削除休業日設定マスタ情報を復活します
        /// </summary>
        /// <param name="holidaySetting">HolidaySettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除休業日設定マスタ情報を復活します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int RevivalLogicalDelete(ref object holidaySetting)
        {
            return LogicalDeleteHolidaySetting(ref holidaySetting, 1);
        }

        /// <summary>
        /// 休業日設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="holidaySetting">holidaySettingオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 休業日設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        private int LogicalDeleteHolidaySetting(ref object holidaySetting, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(holidaySetting);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteHolidaySettingProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "HolidaySettingDB.LogicalDeleteHolidaySettingRtDt :" + procModestr);

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
        /// 休業日設定マスタ情報の論理削除を操作します(外部からのSqlConnection & SqlTranactionを使用)
        /// </summary>
        /// <param name="holidaySettingList">HolidaySettingWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 休業日設定マスタ情報の論理削除を操作します(外部からのSqlConnection & SqlTranactionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int LogicalDeleteHolidaySettingProc(ref ArrayList holidaySettingList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (holidaySettingList != null)
                {
                    for (int i = 0; i < holidaySettingList.Count; i++)
                    {
                        HolidaySettingWork holidaySettingWork = holidaySettingList[i] as HolidaySettingWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, APPLYDATERF, APPLYDATECDRF FROM HOLIDAYSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND APPLYDATERF=@FINDAPPLYDATE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaApplyDate = sqlCommand.Parameters.Add("@FINDAPPLYDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);
                        findParaApplyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyDate);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != holidaySettingWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE HOLIDAYSETTINGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND APPLYDATERF=@FINDAPPLYDATE";
                                                      
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);
                            findParaApplyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyDate);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)holidaySettingWork;
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
                            else if (logicalDelCd == 0) holidaySettingWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else holidaySettingWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) holidaySettingWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(holidaySettingWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(holidaySettingWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(holidaySettingWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(holidaySettingWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(holidaySettingWork);
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

            holidaySettingList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 休業日設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">休業日設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 休業日設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
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

                status = DeleteHolidaySettingRtDtProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "HolidaySettingDB.Delete");
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
        /// 休業日設定マスタ情報を物理削除します(外部からのSqlConnection & SqlTranactionを使用)
        /// </summary>
        /// <param name="HolidaySettingWorkList">休業日設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 休業日設定マスタ情報を物理削除します(外部からのSqlConnection & SqlTranactionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        public int DeleteHolidaySettingRtDtProc(ArrayList HolidaySettingWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < HolidaySettingWorkList.Count; i++)
                {
                    HolidaySettingWork holidaySettingWork = HolidaySettingWorkList[i] as HolidaySettingWork;
                    sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, APPLYDATERF, APPLYDATECDRF FROM HOLIDAYSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND APPLYDATERF=@FINDAPPLYDATE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaApplyDate = sqlCommand.Parameters.Add("@FINDAPPLYDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);
                    findParaApplyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyDate);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != holidaySettingWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM HOLIDAYSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND APPLYDATERF=@FINDAPPLYDATE";

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);
                        findParaApplyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyDate);

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

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="holidaySettingWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, HolidaySettingWork holidaySettingWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";
            string ApplyStaDatestr = "";
            string ApplyEndDatestr = "";
            string SectionCodestr = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.EnterpriseCode);

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

            //休業日設定条件追加
            if (holidaySettingWork.ApplyStaDate != DateTime.MinValue)
            {
                ApplyStaDatestr = "AND APPLYDATERF >= @FINDAPPLYSTARTDATE ";
                retstring += ApplyStaDatestr;
                SqlParameter paraApplyStaDateSt = sqlCommand.Parameters.Add("@FINDAPPLYSTARTDATE", SqlDbType.Int);
                paraApplyStaDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyStaDate);
            }

            if (holidaySettingWork.ApplyStaDate != DateTime.MaxValue)
            {
                ApplyEndDatestr = "AND APPLYDATERF <= @FINDAPPLYENDDATE ";
                retstring += ApplyEndDatestr;
                SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@FINDAPPLYENDDATE", SqlDbType.Int);
                paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingWork.ApplyEndDate);
            }
            
            //拠点コードの条件追加
            SectionCodestr = "AND SECTIONCODERF = @SECTIONCODE ";
            retstring += SectionCodestr;
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(holidaySettingWork.SectionCode);


            return retstring;
        }
        #endregion


        #region [SearchSecList]
        /// <summary>
        /// 指定された条件の休業日設定マスタ情報LIST(複数拠点対応版)を戻します

        /// </summary>
        /// <param name="HolidaySettingWork">検索結果</param>
        /// <param name="paraHolidaySettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の休業日設定マスタ情報LIST(複数拠点対応版)を戻します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.07.11</br>
        public int SearchSecList(out object HolidaySettingWork, object paraHolidaySettingWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            HolidaySettingWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSecListHolidaySettingRtDtProc(out HolidaySettingWork, paraHolidaySettingWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "HolidaySettingDB.SearchSecList");
                HolidaySettingWork = new ArrayList();
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
        /// 指定された条件の休業日設定マスタ情報LIST(複数拠点対応版)を全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objHolidaySettingWork">検索結果</param>
        /// <param name="paraHolidaySettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の休業日設定マスタ情報LIST(複数拠点対応版)を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.07.11</br>
        public int SearchSecListHolidaySettingRtDtProc(out object objHolidaySettingWork, object paraHolidaySettingWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            HolidaySettingSearchWork holidaySettingSearch = null;

            ArrayList HolidaySettingWorkList = paraHolidaySettingWork as ArrayList;
            if (HolidaySettingWorkList == null)
            {
                holidaySettingSearch = paraHolidaySettingWork as HolidaySettingSearchWork;
            }
            else
            {
                if (HolidaySettingWorkList.Count > 0)
                    holidaySettingSearch = HolidaySettingWorkList[0] as HolidaySettingSearchWork;
            }

            int status = SearchSecListHolidaySettingRtDtProc(out HolidaySettingWorkList, holidaySettingSearch, readMode, logicalMode, ref sqlConnection);
            objHolidaySettingWork = HolidaySettingWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の休業日設定マスタ情報LIST(複数拠点対応版)を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="holidaySettingList">検索結果</param>
        /// <param name="holidaySettingSearch">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の休業日設定マスタ情報LIST(複数拠点対応版)を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.07.11</br>
        public int SearchSecListHolidaySettingRtDtProc(out ArrayList holidaySettingList, HolidaySettingSearchWork holidaySettingSearch, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM HOLIDAYSETTINGRF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereSecListString(ref sqlCommand, holidaySettingSearch, logicalMode);
                sqlCommand.CommandText += "ORDER BY SECTIONCODERF,APPLYDATERF ";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToHolidaySettingWorkFromReader(ref myReader));

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

            holidaySettingList = al;

            return status;
        }
        #endregion

        #region [WhereSecList文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="holidaySettingSearchWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>SecList用Where条件文字列</returns>
        /// <br>Note       : SecList用Where句を作成して戻します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        private string MakeWhereSecListString(ref SqlCommand sqlCommand, HolidaySettingSearchWork holidaySettingSearchWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";
            string ApplyStaDatestr = "";
            string ApplyEndDatestr = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(holidaySettingSearchWork.EnterpriseCode);

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

            //休業日設定条件追加
            if (holidaySettingSearchWork.ApplyStaDate != DateTime.MinValue)
            {
                ApplyStaDatestr = "AND APPLYDATERF >= @FINDAPPLYSTARTDATE ";
                retstring += ApplyStaDatestr;
                SqlParameter paraApplyStaDateSt = sqlCommand.Parameters.Add("@FINDAPPLYSTARTDATE", SqlDbType.Int);
                paraApplyStaDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingSearchWork.ApplyStaDate);
            }

            if (holidaySettingSearchWork.ApplyStaDate != DateTime.MaxValue)
            {
                ApplyEndDatestr = "AND APPLYDATERF <= @FINDAPPLYENDDATE ";
                retstring += ApplyEndDatestr;
                SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@FINDAPPLYENDDATE", SqlDbType.Int);
                paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(holidaySettingSearchWork.ApplyEndDate);
            }

            //拠点コードの条件追加
            if (holidaySettingSearchWork.SectionCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in holidaySettingSearchWork.SectionCodeList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retstring += "AND SECTIONCODERF IN (" + sectionString + ") ";
                }
            }


            return retstring;
        }
        #endregion


        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → HolidaySettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>HolidaySettingWork</returns>
        /// <remarks>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        private HolidaySettingWork CopyToHolidaySettingWorkFromReader(ref SqlDataReader myReader)
        {
            HolidaySettingWork wkHolidaySettingWork = new HolidaySettingWork();

            #region クラスへ格納
            wkHolidaySettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkHolidaySettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkHolidaySettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkHolidaySettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkHolidaySettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkHolidaySettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkHolidaySettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkHolidaySettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkHolidaySettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkHolidaySettingWork.ApplyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYDATERF"));
            wkHolidaySettingWork.ApplyDateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYDATECDRF"));
            #endregion

            return wkHolidaySettingWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            HolidaySettingWork[] holidaySettingArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is HolidaySettingWork)
                    {
                        HolidaySettingWork wkHolidaySettingWork = paraobj as HolidaySettingWork;
                        if (wkHolidaySettingWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkHolidaySettingWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            holidaySettingArray = (HolidaySettingWork[])XmlByteSerializer.Deserialize(byteArray, typeof(HolidaySettingWork[]));
                        }
                        catch (Exception) { }
                        if (holidaySettingArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(holidaySettingArray);
                        }
                        else
                        {
                            try
                            {
                                HolidaySettingWork wkHolidaySettingWork = (HolidaySettingWork)XmlByteSerializer.Deserialize(byteArray, typeof(HolidaySettingWork));
                                if (wkHolidaySettingWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkHolidaySettingWork);
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
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
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
