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
using Broadleaf.Application.Common;
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受発注全体設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受発注全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081  山田 明友</br>
    /// <br>Date       : 2007.12.11</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 PM.NS用に修正</br>
    /// </remarks>
    [Serializable]
    public class AcptAnOdrTtlStDB : RemoteDB, IAcptAnOdrTtlStDB, IGetSyncdataList
    {
        /// <summary>
        /// 受発注全体設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        /// </remarks>
        public AcptAnOdrTtlStDB()
            :
            base("DCKHN09266D", "Broadleaf.Application.Remoting.ParamData.AcptAnOdrTtlStWork", "ACPTANODRTTLSTRF")
        {
        }

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata"></param>
        /// <param name="syncServiceWork"></param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
		{
			return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
		}
		
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata"></param>
        /// <param name="syncServiceWork"></param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM ACPTANODRTTLSTRF ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToAcptAnOdrTtlStWorkFromReader(ref myReader,1));

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
        /// <param name="syncServiceWork"></param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
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

        #region [Search]
        /// <summary>
        /// 指定された条件の受発注全体設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">検索結果</param>
        /// <param name="paraacptAnOdrTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int Search(out object acptAnOdrTtlStWork, object paraacptAnOdrTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            acptAnOdrTtlStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchAcptAnOdrTtlStProc(out acptAnOdrTtlStWork, paraacptAnOdrTtlStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcptAnOdrTtlStDB.Search");
                acptAnOdrTtlStWork = new ArrayList();
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
        /// 指定された条件の受発注全体設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objacptAnOdrTtlStWork">検索結果</param>
        /// <param name="searchAcptAnOdrTtlStParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int SearchAcptAnOdrTtlStProc(out object objacptAnOdrTtlStWork, object searchAcptAnOdrTtlStParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            //2008.06.11 del >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //SearchAcptAnOdrTtlStParaWork acptAnOdrTtlStParaWork = null;

            //ArrayList acptAnOdrTtlStWorkList = searchAcptAnOdrTtlStParaWork as ArrayList;
            //if (acptAnOdrTtlStWorkList == null)
            //{
            //    acptAnOdrTtlStParaWork = searchAcptAnOdrTtlStParaWork as SearchAcptAnOdrTtlStParaWork;
            //}
            //else
            //{
            //    if (acptAnOdrTtlStWorkList.Count > 0)
            //        acptAnOdrTtlStParaWork = acptAnOdrTtlStWorkList[0] as SearchAcptAnOdrTtlStParaWork;
            //}

            //SearchAcptAnOdrTtlStParaWork acptAnOdrTtlStParaWork = null;

            AcptAnOdrTtlStWork acptAnOdrTtlStParaWork = null;

            ArrayList acptAnOdrTtlStWorkList = searchAcptAnOdrTtlStParaWork as ArrayList;
            if (acptAnOdrTtlStWorkList == null)
            {
                acptAnOdrTtlStParaWork = searchAcptAnOdrTtlStParaWork as AcptAnOdrTtlStWork;
            }
            else
            {
                if (acptAnOdrTtlStWorkList.Count > 0)
                    acptAnOdrTtlStParaWork = acptAnOdrTtlStWorkList[0] as AcptAnOdrTtlStWork;
            }
            //2008.06.11 del <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            int status = SearchAcptAnOdrTtlStProc(out acptAnOdrTtlStWorkList, acptAnOdrTtlStParaWork, readMode, logicalMode, ref sqlConnection);
            objacptAnOdrTtlStWork = acptAnOdrTtlStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の受発注全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">検索結果</param>
        /// <param name="searchAcptAnOdrTtlStParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int SearchAcptAnOdrTtlStProc(out ArrayList acptAnOdrTtlStWorkList, AcptAnOdrTtlStWork searchAcptAnOdrTtlStParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchAcptAnOdrTtlStProcProc(out acptAnOdrTtlStWorkList, searchAcptAnOdrTtlStParaWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の受発注全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">検索結果</param>
        /// <param name="searchAcptAnOdrTtlStParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int SearchAcptAnOdrTtlStProcProc(out ArrayList acptAnOdrTtlStWorkList, AcptAnOdrTtlStWork searchAcptAnOdrTtlStParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT ACP.* , SEC.SECTIONGUIDENMRF FROM ACPTANODRTTLSTRF AS ACP LEFT JOIN SECINFOSETRF AS SEC ON ACP.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND ACP.SECTIONCODERF=SEC.SECTIONCODERF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchAcptAnOdrTtlStParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToAcptAnOdrTtlStWorkFromReader(ref myReader,0));

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

            acptAnOdrTtlStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の受発注全体設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();

                // XMLの読み込み
                acptAnOdrTtlStWork = (AcptAnOdrTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(AcptAnOdrTtlStWork));
                if (acptAnOdrTtlStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref acptAnOdrTtlStWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(acptAnOdrTtlStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcptAnOdrTtlStDB.Read");
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
        /// 指定された条件の受発注全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int ReadProc(ref AcptAnOdrTtlStWork acptAnOdrTtlStWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref acptAnOdrTtlStWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の受発注全体設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int ReadProcProc(ref AcptAnOdrTtlStWork acptAnOdrTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                SqlDataReader myReader = null;

                try
                {

                    //Selectコマンドの生成
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT ACP.* ,SEC.SECTIONGUIDENMRF FROM ACPTANODRTTLSTRF AS ACP "
                                                                   + "LEFT JOIN SECINFOSETRF AS SEC "
                                                                   + "ON "
                                                                   + "ACP.ENTERPRISECODERF=SEC.ENTERPRISECODERF "
                                                                   +"AND ACP.SECTIONCODERF=SEC.SECTIONCODERF "
                                                                   + "WHERE ACP.ENTERPRISECODERF=@FINDENTERPRISECODE AND ACP.SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                    {

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromReader(ref myReader, 0);
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
        /// 受発注全体設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受発注全体設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int Write(ref object acptAnOdrTtlStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(acptAnOdrTtlStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteAcptAnOdrTtlStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                acptAnOdrTtlStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcptAnOdrTtlStDB.Write(ref object acptAnOdrTtlStWork)");
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
        /// 受発注全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受発注全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int WriteAcptAnOdrTtlStProc(ref ArrayList acptAnOdrTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteAcptAnOdrTtlStProcProc(ref acptAnOdrTtlStWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 受発注全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受発注全体設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int WriteAcptAnOdrTtlStProcProc(ref ArrayList acptAnOdrTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (acptAnOdrTtlStWorkList != null)
                {
                    for (int i = 0; i < acptAnOdrTtlStWorkList.Count; i++)
                    {
                        AcptAnOdrTtlStWork acptAnOdrTtlStWork = acptAnOdrTtlStWorkList[i] as AcptAnOdrTtlStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != acptAnOdrTtlStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (acptAnOdrTtlStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE ACPTANODRTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , ESTMCOUNTREFLECTDIVRF=@ESTMCOUNTREFLECTDIV , ACPODRRSLIPPRTDIVRF=@ACPODRRSLIPPRTDIV , FAXORDERDIVRF=@FAXORDERDIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);
                            
                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acptAnOdrTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (acptAnOdrTtlStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO ACPTANODRTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, ESTMCOUNTREFLECTDIVRF, ACPODRRSLIPPRTDIVRF,  FAXORDERDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @ESTMCOUNTREFLECTDIV, @ACPODRRSLIPPRTDIV, @FAXORDERDIV)";
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acptAnOdrTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraEstmCountReflectDiv = sqlCommand.Parameters.Add("@ESTMCOUNTREFLECTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraFaxOrderDiv = sqlCommand.Parameters.Add("@FAXORDERDIV", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acptAnOdrTtlStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acptAnOdrTtlStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acptAnOdrTtlStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);
                        paraEstmCountReflectDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.EstmCountReflectDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.AcpOdrrSlipPrtDiv);
                        paraFaxOrderDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.FaxOrderDiv);
                        #endregion
                        
                        sqlCommand.ExecuteNonQuery();
                        al.Add(acptAnOdrTtlStWork);
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

            acptAnOdrTtlStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 受発注全体設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受発注全体設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int LogicalDelete(ref object acptAnOdrTtlStWork)
        {
            return LogicalDeleteAcptAnOdrTtlSt(ref acptAnOdrTtlStWork, 0);
        }

        /// <summary>
        /// 論理削除受発注全体設定マスタ情報を復活します
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除受発注全体設定マスタ情報を復活します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        public int RevivalLogicalDelete(ref object acptAnOdrTtlStWork)
        {
            return LogicalDeleteAcptAnOdrTtlSt(ref acptAnOdrTtlStWork, 1);
        }

        /// <summary>
        /// 受発注全体設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受発注全体設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        private int LogicalDeleteAcptAnOdrTtlSt(ref object acptAnOdrTtlStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(acptAnOdrTtlStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteAcptAnOdrTtlStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "AcptAnOdrTtlStDB.LogicalDeleteAcptAnOdrTtlSt :" + procModestr);

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
        /// 受発注全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受発注全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int LogicalDeleteAcptAnOdrTtlStProc(ref ArrayList acptAnOdrTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteAcptAnOdrTtlStProcProc(ref acptAnOdrTtlStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 受発注全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">AcptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受発注全体設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int LogicalDeleteAcptAnOdrTtlStProcProc(ref ArrayList acptAnOdrTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (acptAnOdrTtlStWorkList != null)
                {
                    for (int i = 0; i < acptAnOdrTtlStWorkList.Count; i++)
                    {
                        AcptAnOdrTtlStWork acptAnOdrTtlStWork = acptAnOdrTtlStWorkList[i] as AcptAnOdrTtlStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,SECTIONCODERF,LOGICALDELETECODERF FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        
                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != acptAnOdrTtlStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE ACPTANODRTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acptAnOdrTtlStWork;
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
                            else if (logicalDelCd == 0) acptAnOdrTtlStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else acptAnOdrTtlStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) acptAnOdrTtlStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;      //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acptAnOdrTtlStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.LogicalDeleteCode);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(acptAnOdrTtlStWork);
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

            acptAnOdrTtlStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 受発注全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">受発注全体設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 受発注全体設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
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

                status = DeleteAcptAnOdrTtlStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "AcptAnOdrTtlStDB.Delete");
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
        /// 受発注全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">受発注全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 受発注全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		public int DeleteAcptAnOdrTtlStProc(ArrayList acptAnOdrTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteAcptAnOdrTtlStProcProc(acptAnOdrTtlStWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 受発注全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">受発注全体設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 受発注全体設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
		private int DeleteAcptAnOdrTtlStProcProc(ArrayList acptAnOdrTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < acptAnOdrTtlStWorkList.Count; i++)
                {
                    AcptAnOdrTtlStWork acptAnOdrTtlStWork = acptAnOdrTtlStWorkList[i] as AcptAnOdrTtlStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != acptAnOdrTtlStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);
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
        /// <param name="searchAcptAnOdrTtlStParaWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AcptAnOdrTtlStWork searchAcptAnOdrTtlStParaWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ACP.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchAcptAnOdrTtlStParaWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(searchAcptAnOdrTtlStParaWork.SectionCode) == false)
            {
                retstring += "AND ACP.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(searchAcptAnOdrTtlStParaWork.SectionCode);
            }
            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND ACP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if    (    (logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND ACP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if(wkstring != "")
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
        /// クラス格納処理 Reader → AcptAnOdrTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode"></param>
        /// <returns>AcptAnOdrTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        /// </remarks>
        private AcptAnOdrTtlStWork CopyToAcptAnOdrTtlStWorkFromReader(ref SqlDataReader myReader,int mode)
        {
            AcptAnOdrTtlStWork wkAcptAnOdrTtlStWork = new AcptAnOdrTtlStWork();

            #region クラスへ格納
            wkAcptAnOdrTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
            wkAcptAnOdrTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkAcptAnOdrTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAcptAnOdrTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkAcptAnOdrTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkAcptAnOdrTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkAcptAnOdrTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkAcptAnOdrTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkAcptAnOdrTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
            wkAcptAnOdrTtlStWork.EstmCountReflectDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ESTMCOUNTREFLECTDIVRF"));
            wkAcptAnOdrTtlStWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
            wkAcptAnOdrTtlStWork.FaxOrderDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FAXORDERDIVRF"));
            
            if(mode == 0)
            {
                wkAcptAnOdrTtlStWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            }
            
            #endregion

            return wkAcptAnOdrTtlStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            AcptAnOdrTtlStWork[] AcptAnOdrTtlStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is AcptAnOdrTtlStWork)
                    {
                        AcptAnOdrTtlStWork wkAcptAnOdrTtlStWork = paraobj as AcptAnOdrTtlStWork;
                        if (wkAcptAnOdrTtlStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkAcptAnOdrTtlStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            AcptAnOdrTtlStWorkArray = (AcptAnOdrTtlStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(AcptAnOdrTtlStWork[]));
                        }
                        catch (Exception) { }
                        if (AcptAnOdrTtlStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(AcptAnOdrTtlStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                AcptAnOdrTtlStWork wkAcptAnOdrTtlStWork = (AcptAnOdrTtlStWork)XmlByteSerializer.Deserialize(byteArray, typeof(AcptAnOdrTtlStWork));
                                if (wkAcptAnOdrTtlStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkAcptAnOdrTtlStWork);
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
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.11</br>
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
