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
    /// 伝票出力先設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 伝票出力先設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081  山田 明友</br>
    /// <br>Date       : 2007.12.10</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.02  20081 疋田 勇人</br>
    /// <br>             ＰＭ.ＮＳ用に変更</br>
    /// </remarks>
    [Serializable]
    public class SlipOutputSetDB : RemoteDB, ISlipOutputSetDB, IGetSyncdataList
    {
        /// <summary>
        /// 伝票出力先設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        public SlipOutputSetDB()
            :
            base("DCKHN09266D", "Broadleaf.Application.Remoting.ParamData.SlipOutputSetWork", "SLIPOUTPUTSETRF")
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
        /// <br>Note       : 指定された条件の伝票出力先設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
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
        /// <br>Note       : 指定された条件の伝票出力先設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.06.02 upd start -------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM SLIPOUTPUTSETRF ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += "    ,PRINTERMNGNORF" + Environment.NewLine;
                sqlTxt += " FROM SLIPOUTPUTSETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.06.02 upd end ----------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSlipOutputSetWorkFromReader(ref myReader));

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
        /// <br>Date       : 2007.12.10</br>
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
        /// 指定された条件の伝票出力先設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="slipOutputSetWork">検索結果</param>
        /// <param name="paraslipOutputSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票出力先設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        public int Search(out object slipOutputSetWork, object paraslipOutputSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            slipOutputSetWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSlipOutputSetProc(out slipOutputSetWork, paraslipOutputSetWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlipOutputSetDB.Search");
                slipOutputSetWork = new ArrayList();
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
        /// 指定された条件の伝票出力先設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objslipOutputSetWork">検索結果</param>
        /// <param name="searchSlipOutputSetParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票出力先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        public int SearchSlipOutputSetProc(out object objslipOutputSetWork, object searchSlipOutputSetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SearchSlipOutputSetParaWork slipOutputSetParaWork = null;

            ArrayList slipOutputSetWorkList = searchSlipOutputSetParaWork as ArrayList;
            if (slipOutputSetWorkList == null)
            {
                slipOutputSetParaWork = searchSlipOutputSetParaWork as SearchSlipOutputSetParaWork;
            }
            else
            {
                if (slipOutputSetWorkList.Count > 0)
                    slipOutputSetParaWork = slipOutputSetWorkList[0] as SearchSlipOutputSetParaWork;
            }

            int status = SearchSlipOutputSetProc(out slipOutputSetWorkList, slipOutputSetParaWork, readMode, logicalMode, ref sqlConnection);
            objslipOutputSetWork = slipOutputSetWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の伝票出力先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="slipOutputSetWorkList">検索結果</param>
        /// <param name="searchSlipOutputSetParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票出力先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		public int SearchSlipOutputSetProc(out ArrayList slipOutputSetWorkList, SearchSlipOutputSetParaWork searchSlipOutputSetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchSlipOutputSetProcProc(out slipOutputSetWorkList, searchSlipOutputSetParaWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の伝票出力先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="slipOutputSetWorkList">検索結果</param>
        /// <param name="searchSlipOutputSetParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票出力先設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		private int SearchSlipOutputSetProcProc(out ArrayList slipOutputSetWorkList, SearchSlipOutputSetParaWork searchSlipOutputSetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                
                // 2008.06.02 upd start -------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM SLIPOUTPUTSETRF ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += "    ,PRINTERMNGNORF" + Environment.NewLine;
                sqlTxt += " FROM SLIPOUTPUTSETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.06.02 upd end ----------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchSlipOutputSetParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSlipOutputSetWorkFromReader(ref myReader));

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

            slipOutputSetWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の伝票出力先設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">SlipOutputSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票出力先設定マスタを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                SlipOutputSetWork slipOutputSetWork = new SlipOutputSetWork();

                // XMLの読み込み
                slipOutputSetWork = (SlipOutputSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipOutputSetWork));
                if (slipOutputSetWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref slipOutputSetWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(slipOutputSetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlipOutputSetDB.Read");
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
        /// 指定された条件の伝票出力先設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票出力先設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		public int ReadProc(ref SlipOutputSetWork slipOutputSetWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref slipOutputSetWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の伝票出力先設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票出力先設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		private int ReadProcProc(ref SlipOutputSetWork slipOutputSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                SqlDataReader myReader = null;

                try
                {
                    //Selectコマンドの生成
                    // 2008.06.02 upd start ---------------------------------------->>
                    //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SLIPOUTPUTSETRF "
                    //                                            + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID ", sqlConnection))
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                    sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlTxt += "    ,PRINTERMNGNORF" + Environment.NewLine;
                    sqlTxt += " FROM SLIPOUTPUTSETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))                                            
                    // 2008.06.02 upd end ------------------------------------------<<
                    {

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // 2008.06.02 add
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            slipOutputSetWork = CopyToSlipOutputSetWorkFromReader(ref myReader);
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
        /// 伝票出力先設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 伝票出力先設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        public int Write(ref object slipOutputSetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(slipOutputSetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSlipOutputSetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                slipOutputSetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SlipOutputSetDB.Write(ref object slipOutputSetWork)");
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
        /// 伝票出力先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="slipOutputSetWorkList">SlipOutputSetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 伝票出力先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		public int WriteSlipOutputSetProc(ref ArrayList slipOutputSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteSlipOutputSetProcProc(ref slipOutputSetWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 伝票出力先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="slipOutputSetWorkList">SlipOutputSetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 伝票出力先設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		private int WriteSlipOutputSetProcProc(ref ArrayList slipOutputSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty; // 2008.06.02 add
            try
            {
                if (slipOutputSetWorkList != null)
                {
                    for (int i = 0; i < slipOutputSetWorkList.Count; i++)
                    {
                        SlipOutputSetWork slipOutputSetWork = slipOutputSetWorkList[i] as SlipOutputSetWork;

                        //Selectコマンドの生成
                        // 2008.06.02 upd start ------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SLIPOUTPUTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                        sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                        sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlTxt += "    ,PRINTERMNGNORF" + Environment.NewLine;
                        sqlTxt += " FROM SLIPOUTPUTSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.06.02 upd end ---------------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // 2008.06.02 add
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != slipOutputSetWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (slipOutputSetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 2008.06.02 upd start ------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE SLIPOUTPUTSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , PRINTERMNGNORF=@PRINTERMNGNO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                            sqlTxt = string.Empty;
                            sqlTxt += "UPDATE SLIPOUTPUTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            sqlTxt += " , CASHREGISTERNORF=@CASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += " , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTKINDRF=@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += " , PRINTERMNGNORF=@PRINTERMNGNO" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.06.02 upd end ---------------------------------------<<
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                            findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                            findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);
                            
                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)slipOutputSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (slipOutputSetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            
                            //新規作成時のSQL文を生成
                            // 2008.06.02 upd start ------------------------------------->>
                            //sqlCommand.CommandText = "INSERT INTO SLIPOUTPUTSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, PRINTERMNGNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CASHREGISTERNO, @DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @PRINTERMNGNO)";
                            sqlTxt = string.Empty;
                            sqlTxt += "INSERT INTO SLIPOUTPUTSETRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                            sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                            sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                            sqlTxt += "    ,PRINTERMNGNORF" + Environment.NewLine;
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
                            sqlTxt += "    ,@WAREHOUSECODE" + Environment.NewLine;
                            sqlTxt += "    ,@CASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += "    ,@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += "    ,@PRINTERMNGNO" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.06.02 upd end ---------------------------------------<<
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)slipOutputSetWork;
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
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar); // 2008.06.02 add
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                        SqlParameter paraPrinterMngNo = sqlCommand.Parameters.Add("@PRINTERMNGNO", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipOutputSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipOutputSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(slipOutputSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.LogicalDeleteCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);
                        paraPrinterMngNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.PrinterMngNo);
                        #endregion
                        
                        sqlCommand.ExecuteNonQuery();
                        al.Add(slipOutputSetWork);
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

            slipOutputSetWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 伝票出力先設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 伝票出力先設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        public int LogicalDelete(ref object slipOutputSetWork)
        {
            return LogicalDeleteSlipOutputSet(ref slipOutputSetWork, 0);
        }

        /// <summary>
        /// 論理削除伝票出力先設定マスタ情報を復活します
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除伝票出力先設定マスタ情報を復活します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        public int RevivalLogicalDelete(ref object slipOutputSetWork)
        {
            return LogicalDeleteSlipOutputSet(ref slipOutputSetWork, 1);
        }

        /// <summary>
        /// 伝票出力先設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 伝票出力先設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        private int LogicalDeleteSlipOutputSet(ref object slipOutputSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(slipOutputSetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSlipOutputSetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SlipOutputSetDB.LogicalDeleteSlipOutputSet :" + procModestr);

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
        /// 伝票出力先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="slipOutputSetWorkList">SlipOutputSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 伝票出力先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        public int LogicalDeleteSlipOutputSetProc(ref ArrayList slipOutputSetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteSlipOutputSetProcProc(ref slipOutputSetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 伝票出力先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="slipOutputSetWorkList">SlipOutputSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 伝票出力先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		private int LogicalDeleteSlipOutputSetProcProc(ref ArrayList slipOutputSetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlTxt = string.Empty; // 2008.06.02 add

            try
            {
                if (slipOutputSetWorkList != null)
                {
                    for (int i = 0; i < slipOutputSetWorkList.Count; i++)
                    {
                        SlipOutputSetWork slipOutputSetWork = slipOutputSetWorkList[i] as SlipOutputSetWork;

                        //Selectコマンドの生成
                        // 2008.06.02 upd start ------------------------------------->>
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM SLIPOUTPUTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection, sqlTransaction);
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                        sqlTxt += "    ,CASHREGISTERNORF" + Environment.NewLine;
                        sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlTxt += "    ,PRINTERMNGNORF" + Environment.NewLine;
                        sqlTxt += " FROM SLIPOUTPUTSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.06.02 upd end ---------------------------------------<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // 2008.06.02 add
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != slipOutputSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            // 2008.06.02 upd start ------------------------------------->>
                            //sqlCommand.CommandText = "UPDATE SLIPOUTPUTSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , PRINTERMNGNORF=@PRINTERMNGNO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                            sqlTxt = string.Empty;
                            sqlTxt += "UPDATE SLIPOUTPUTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            sqlTxt += " , CASHREGISTERNORF=@CASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += " , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTKINDRF=@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += " , PRINTERMNGNORF=@PRINTERMNGNO" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                            sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.06.02 upd end ---------------------------------------<<

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                            findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                            findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)slipOutputSetWork;
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
                            else if (logicalDelCd == 0) slipOutputSetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else slipOutputSetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) slipOutputSetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;      //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar); // 2008.06.02 add
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                        SqlParameter paraPrinterMngNo = sqlCommand.Parameters.Add("@PRINTERMNGNO", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipOutputSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipOutputSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(slipOutputSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.LogicalDeleteCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);
                        paraPrinterMngNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.PrinterMngNo);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(slipOutputSetWork);
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

            slipOutputSetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 伝票出力先設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">伝票出力先設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 伝票出力先設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
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

                status = DeleteSlipOutputSetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SlipOutputSetDB.Delete");
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
        /// 伝票出力先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="slipOutputSetWorkList">伝票出力先設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 伝票出力先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		public int DeleteSlipOutputSetProc(ArrayList slipOutputSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteSlipOutputSetProcProc(slipOutputSetWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 伝票出力先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="slipOutputSetWorkList">伝票出力先設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 伝票出力先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
		private int DeleteSlipOutputSetProcProc(ArrayList slipOutputSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlTxt = string.Empty; // 2008.06.02 add
            try
            {

                for (int i = 0; i < slipOutputSetWorkList.Count; i++)
                {
                    SlipOutputSetWork slipOutputSetWork = slipOutputSetWorkList[i] as SlipOutputSetWork;
                    // 2008.06.02 upd start ------------------------------------->>
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM SLIPOUTPUTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection, sqlTransaction);
                    sqlTxt = string.Empty;
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += " FROM SLIPOUTPUTSETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                    // 2008.06.02 upd end ---------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // 2008.06.02 add
                    SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                    findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                    findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != slipOutputSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // 2008.06.02 upd start ------------------------------------->>
                        //sqlCommand.CommandText = "DELETE FROM SLIPOUTPUTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                        sqlTxt = string.Empty;
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM SLIPOUTPUTSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                        sqlTxt += "    AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.06.02 upd end ---------------------------------------<<
                        
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.EnterpriseCode);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.WarehouseCode); // 2008.06.02 add
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.CashRegisterNo);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipOutputSetWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipOutputSetWork.SlipPrtSetPaperId);
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
        /// <param name="searchSlipOutputSetParaWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchSlipOutputSetParaWork searchSlipOutputSetParaWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchSlipOutputSetParaWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if    (    (logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 2008.06.02 del start --------------------------------->>
            ////拠点コード
            //if (searchSlipOutputSetParaWork.SelectSectCd != null)
            //{
            //    wkstring = "";
            //    foreach (string seccdstr in searchSlipOutputSetParaWork.SelectSectCd)
            //    {
            //        if (wkstring != "") wkstring += ",";
            //        wkstring += "'" + seccdstr + "'";
            //    }
            //    if (wkstring != "")
            //    {
            //        retstring += "AND SECTIONCODERF IN (" + wkstring + ") ";
            //    }
            //}
            // 2008.06.02 del end -----------------------------------<<

            // 2008.06.02 add start ------------------------>>
            //倉庫コード
            if (searchSlipOutputSetParaWork.WarehouseCode != "")
            {
                retstring += "AND WAREHOUSECODERF=@WAREHOUSECODE ";
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(searchSlipOutputSetParaWork.WarehouseCode);
            }
            // 2008.06.02 add end --------------------------<< 

            //レジ番号
            if (searchSlipOutputSetParaWork.CashRegisterNo >= 0)
            {
                retstring += "AND CASHREGISTERNORF=@CASHREGISTERNO ";
                SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(searchSlipOutputSetParaWork.CashRegisterNo);
            }

            //データ入力システム
            if (searchSlipOutputSetParaWork.DataInputSystem >= 0)
            {
                retstring += "AND DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM ";
                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(searchSlipOutputSetParaWork.DataInputSystem);
            }

            //伝票印刷種別
            if (searchSlipOutputSetParaWork.SlipPrtKind >= 0)
            {
                retstring += "AND SLIPPRTKINDRF=@SLIPPRTKIND ";
                SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(searchSlipOutputSetParaWork.SlipPrtKind);
            }

            //伝票印刷設定用帳票ID
            if (searchSlipOutputSetParaWork.SlipPrtSetPaperId != "")
            {
                retstring += "AND SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID ";
                SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NChar);
                paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(searchSlipOutputSetParaWork.SlipPrtSetPaperId);
            }

            //ソート順位
            retstring += "ORDER BY WAREHOUSECODERF,CASHREGISTERNORF,DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF,PRINTERMNGNORF ";

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SlipOutputSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SlipOutputSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private SlipOutputSetWork CopyToSlipOutputSetWorkFromReader(ref SqlDataReader myReader)
        {
            SlipOutputSetWork wkSlipOutputSetWork = new SlipOutputSetWork();

            #region クラスへ格納
            wkSlipOutputSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSlipOutputSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSlipOutputSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSlipOutputSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSlipOutputSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSlipOutputSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSlipOutputSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSlipOutputSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //wkSlipOutputSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));   // 2008.06.02 del
            wkSlipOutputSetWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF")); // 2008.06.02 add 
            wkSlipOutputSetWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            wkSlipOutputSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
            wkSlipOutputSetWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
            wkSlipOutputSetWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            wkSlipOutputSetWork.PrinterMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTERMNGNORF"));
            #endregion

            return wkSlipOutputSetWork;
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
        /// <br>Date       : 2007.12.10</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SlipOutputSetWork[] SlipOutputSetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SlipOutputSetWork)
                    {
                        SlipOutputSetWork wkSlipOutputSetWork = paraobj as SlipOutputSetWork;
                        if (wkSlipOutputSetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSlipOutputSetWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SlipOutputSetWorkArray = (SlipOutputSetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SlipOutputSetWork[]));
                        }
                        catch (Exception) { }
                        if (SlipOutputSetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SlipOutputSetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SlipOutputSetWork wkSlipOutputSetWork = (SlipOutputSetWork)XmlByteSerializer.Deserialize(byteArray, typeof(SlipOutputSetWork));
                                if (wkSlipOutputSetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSlipOutputSetWork);
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
        /// <br>Date       : 2007.12.10</br>
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
