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
    /// 見積初期値設定マスタメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 見積初期値設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2007.09.26</br>
    /// <br>Update Note: 22008 長内 PM.NS用に修正</br>
    /// </remarks>
    [Serializable]
    public class EstimateDefSetDB : RemoteDB, IEstimateDefSetDB, IGetSyncdataList
    {
        /// <summary>
        /// 見積初期値設定マスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>														   
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        public EstimateDefSetDB()
            :
        base("DCMIT09016D", "Broadleaf.Application.Remoting.ParamData.EstimateDefSetWork", "ESTIMATEDEFSETRF")
        {
        }

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の見積初期値設定マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の見積初期値設定マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;

          ArrayList al = new ArrayList();
          try
          {
            string selectTxt = "";
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  CREATEDATETIMERF" + Environment.NewLine;
            selectTxt += " ,UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,FILEHEADERGUIDRF" + Environment.NewLine;
            selectTxt += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
            selectTxt += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
            selectTxt += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
            selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += " ,SECTIONCODERF" + Environment.NewLine;
            selectTxt += " ,CONSTAXPRINTDIVRF" + Environment.NewLine;
            selectTxt += " ,LISTPRICEPRINTDIVRF" + Environment.NewLine;
            selectTxt += " ,ESTMFORMNOPICKDIVRF" + Environment.NewLine;
           selectTxt += " ,ESTIMATETITLE1RF" + Environment.NewLine;
            selectTxt += " ,ESTIMATENOTE1RF" + Environment.NewLine;
            selectTxt += " ,ESTIMATENOTE2RF" + Environment.NewLine;
            selectTxt += " ,ESTIMATENOTE3RF" + Environment.NewLine;
            selectTxt += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
            selectTxt += " ,FAXESTIMATETDIVRF" + Environment.NewLine;
            selectTxt += " ,PARTSNOPRTCDRF" + Environment.NewLine;
            selectTxt += " ,OPTIONPRINGDIVCDRF" + Environment.NewLine;
            selectTxt += " ,PARTSSELECTDIVCDRF" + Environment.NewLine;
            selectTxt += " ,PARTSSEARCHDIVCDRF" + Environment.NewLine;
            selectTxt += " ,ESTIMATEDTCREATEDIVRF" + Environment.NewLine;
            selectTxt += " ,ESTIMATEVALIDITYTERMRF" + Environment.NewLine;
            selectTxt += " ,RATEUSECODERF" + Environment.NewLine;
            selectTxt += "FROM ESTIMATEDEFSETRF" + Environment.NewLine;
            
            sqlCommand = new SqlCommand(selectTxt, sqlConnection);

            sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {

              al.Add(CopyToEstimateDefSetWorkFromReader(ref myReader,1));

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

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
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

        #region [Read]
        /// <summary>
        /// 指定された条件の見積初期値設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">EstimateDefSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の見積初期値設定マスタを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();

                // XMLの読み込み
                estimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EstimateDefSetWork));
                if (estimateDefSetWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref estimateDefSetWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(estimateDefSetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EstimateDefSetDB.Read");
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
        /// 指定された条件の見積初期値設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="estimateDefSetWork">EstimateDefSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の見積初期値設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int ReadProc(ref EstimateDefSetWork estimateDefSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref estimateDefSetWork, readMode, ref sqlConnection);
        }
        /// <summary>
        /// 指定された条件の見積初期値設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="estimateDefSetWork">EstimateDefSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の見積初期値設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        private int ReadProcProc(ref EstimateDefSetWork estimateDefSetWork, int readMode, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  EST.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,EST.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,EST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,EST.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,EST.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,EST.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,EST.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,EST.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,EST.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += " ,EST.CONSTAXPRINTDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.LISTPRICEPRINTDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.ESTMFORMNOPICKDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATETITLE1RF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATENOTE1RF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATENOTE2RF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATENOTE3RF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.FAXESTIMATETDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.PARTSNOPRTCDRF" + Environment.NewLine;
                selectTxt += " ,EST.OPTIONPRINGDIVCDRF" + Environment.NewLine;
                selectTxt += " ,EST.PARTSSELECTDIVCDRF" + Environment.NewLine;
                selectTxt += " ,EST.PARTSSEARCHDIVCDRF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATEDTCREATEDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATEVALIDITYTERMRF" + Environment.NewLine;
                selectTxt += " ,EST.RATEUSECODERF" + Environment.NewLine;
                selectTxt += "FROM ESTIMATEDEFSETRF AS EST" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     EST.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND EST.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     EST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND EST.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        estimateDefSetWork = CopyToEstimateDefSetWorkFromReader(ref myReader,0);
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
        /// 見積初期値設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="estimateDefSetWork">EstimateDefSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int Write(ref object estimateDefSetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(estimateDefSetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteEstimateDefSetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                estimateDefSetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EstimateDefSetDB.Write(ref object estimateDefSetWork)");
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
        /// 見積初期値設定マスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="estimateDefSetWorkList">EstimateDefSetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int WriteEstimateDefSetProc(ref ArrayList estimateDefSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteEstimateDefSetProcProc(ref estimateDefSetWorkList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 見積初期値設定マスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="estimateDefSetWorkList">EstimateDefSetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        private int WriteEstimateDefSetProcProc(ref ArrayList estimateDefSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (estimateDefSetWorkList != null)
                {
                   string selectTxt = ""; 
                    
                    for (int i = 0; i < estimateDefSetWorkList.Count; i++)
                    {
                        EstimateDefSetWork estimateDefSetWork = estimateDefSetWorkList[i] as EstimateDefSetWork;
                        
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += "FROM ESTIMATEDEFSETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != estimateDefSetWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (estimateDefSetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = "";
                            selectTxt += "UPDATE ESTIMATEDEFSETRF SET" + Environment.NewLine;
                            selectTxt += "  CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += ", FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += ", SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += ", CONSTAXPRINTDIVRF=@CONSTAXPRINTDIV" + Environment.NewLine;
                            selectTxt += ", LISTPRICEPRINTDIVRF=@LISTPRICEPRINTDIV" + Environment.NewLine;
                            selectTxt += ", ESTMFORMNOPICKDIVRF=@ESTMFORMNOPICKDIV" + Environment.NewLine;
                            selectTxt += ", ESTIMATETITLE1RF=@ESTIMATETITLE1" + Environment.NewLine;
                            selectTxt += ", ESTIMATENOTE1RF=@ESTIMATENOTE1" + Environment.NewLine;
                            selectTxt += ", ESTIMATENOTE2RF=@ESTIMATENOTE2" + Environment.NewLine;
                            selectTxt += ", ESTIMATENOTE3RF=@ESTIMATENOTE3" + Environment.NewLine;
                            selectTxt += ", ESTIMATEPRTDIVRF=@ESTIMATEPRTDIV" + Environment.NewLine;
                            selectTxt += ", FAXESTIMATETDIVRF=@FAXESTIMATETDIV" + Environment.NewLine;
                            selectTxt += ", PARTSNOPRTCDRF=@PARTSNOPRTCD" + Environment.NewLine;
                            selectTxt += ", OPTIONPRINGDIVCDRF=@OPTIONPRINGDIVCD" + Environment.NewLine;
                            selectTxt += ", PARTSSELECTDIVCDRF=@PARTSSELECTDIVCD" + Environment.NewLine;
                            selectTxt += ", PARTSSEARCHDIVCDRF=@PARTSSEARCHDIVCD" + Environment.NewLine;
                            selectTxt += ", ESTIMATEDTCREATEDIVRF=@ESTIMATEDTCREATEDIV" + Environment.NewLine;
                            selectTxt += ", ESTIMATEVALIDITYTERMRF=@ESTIMATEVALIDITYTERM" + Environment.NewLine;
                            selectTxt += ", RATEUSECODERF=@RATEUSECODE" + Environment.NewLine;
                            selectTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                                                      
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)estimateDefSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (estimateDefSetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                              
                            selectTxt = "";
                            selectTxt += "INSERT INTO ESTIMATEDEFSETRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,CONSTAXPRINTDIVRF" + Environment.NewLine;
                            selectTxt += "  ,LISTPRICEPRINTDIVRF" + Environment.NewLine;
                            selectTxt += "  ,ESTMFORMNOPICKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,ESTIMATETITLE1RF" + Environment.NewLine;
                            selectTxt += "  ,ESTIMATENOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,ESTIMATENOTE2RF" + Environment.NewLine;
                            selectTxt += "  ,ESTIMATENOTE3RF" + Environment.NewLine;
                            selectTxt += "  ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            selectTxt += "  ,FAXESTIMATETDIVRF" + Environment.NewLine;
                            selectTxt += "  ,PARTSNOPRTCDRF" + Environment.NewLine;
                            selectTxt += "  ,OPTIONPRINGDIVCDRF" + Environment.NewLine;
                            selectTxt += "  ,PARTSSELECTDIVCDRF" + Environment.NewLine;
                            selectTxt += "  ,PARTSSEARCHDIVCDRF" + Environment.NewLine;
                            selectTxt += "  ,ESTIMATEDTCREATEDIVRF" + Environment.NewLine;
                            selectTxt += "  ,ESTIMATEVALIDITYTERMRF" + Environment.NewLine;
                            selectTxt += "  ,RATEUSECODERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@CONSTAXPRINTDIV" + Environment.NewLine;
                            selectTxt += "  ,@LISTPRICEPRINTDIV" + Environment.NewLine;
                            selectTxt += "  ,@ESTMFORMNOPICKDIV" + Environment.NewLine;
                            selectTxt += "  ,@ESTIMATETITLE1" + Environment.NewLine;
                            selectTxt += "  ,@ESTIMATENOTE1" + Environment.NewLine;
                            selectTxt += "  ,@ESTIMATENOTE2" + Environment.NewLine;
                            selectTxt += "  ,@ESTIMATENOTE3" + Environment.NewLine;
                            selectTxt += "  ,@ESTIMATEPRTDIV" + Environment.NewLine;
                            selectTxt += "  ,@FAXESTIMATETDIV" + Environment.NewLine;
                            selectTxt += "  ,@PARTSNOPRTCD" + Environment.NewLine;
                            selectTxt += "  ,@OPTIONPRINGDIVCD" + Environment.NewLine;
                            selectTxt += "  ,@PARTSSELECTDIVCD" + Environment.NewLine;
                            selectTxt += "  ,@PARTSSEARCHDIVCD" + Environment.NewLine;
                            selectTxt += "  ,@ESTIMATEDTCREATEDIV" + Environment.NewLine;
                            selectTxt += "  ,@ESTIMATEVALIDITYTERM" + Environment.NewLine;
                            selectTxt += "  ,@RATEUSECODE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = selectTxt;
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)estimateDefSetWork;
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
                        SqlParameter paraConsTaxPrintDiv = sqlCommand.Parameters.Add("@CONSTAXPRINTDIV", SqlDbType.Int);
                        SqlParameter paraListPricePrintDiv = sqlCommand.Parameters.Add("@LISTPRICEPRINTDIV", SqlDbType.Int);
                        SqlParameter paraEstmFormNoPickDiv = sqlCommand.Parameters.Add("@ESTMFORMNOPICKDIV", SqlDbType.Int);
                        SqlParameter paraEstimateTitle1 = sqlCommand.Parameters.Add("@ESTIMATETITLE1", SqlDbType.NVarChar);
                        SqlParameter paraEstimateNote1 = sqlCommand.Parameters.Add("@ESTIMATENOTE1", SqlDbType.NVarChar);
                        SqlParameter paraEstimateNote2 = sqlCommand.Parameters.Add("@ESTIMATENOTE2", SqlDbType.NVarChar);
                        SqlParameter paraEstimateNote3 = sqlCommand.Parameters.Add("@ESTIMATENOTE3", SqlDbType.NVarChar);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraFaxEstimatetDiv = sqlCommand.Parameters.Add("@FAXESTIMATETDIV", SqlDbType.Int);
                        SqlParameter paraPartsNoPrtCd = sqlCommand.Parameters.Add("@PARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraOptionPringDivCd = sqlCommand.Parameters.Add("@OPTIONPRINGDIVCD", SqlDbType.Int);
                        SqlParameter paraPartsSelectDivCd = sqlCommand.Parameters.Add("@PARTSSELECTDIVCD", SqlDbType.Int);
                        SqlParameter paraPartsSearchDivCd = sqlCommand.Parameters.Add("@PARTSSEARCHDIVCD", SqlDbType.Int);
                        SqlParameter paraEstimateDtCreateDiv = sqlCommand.Parameters.Add("@ESTIMATEDTCREATEDIV", SqlDbType.Int);
                        SqlParameter paraEstimateValidityTerm = sqlCommand.Parameters.Add("@ESTIMATEVALIDITYTERM", SqlDbType.Int);
                        SqlParameter paraRateUseCode = sqlCommand.Parameters.Add("@RATEUSECODE", SqlDbType.Int);
                        
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(estimateDefSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(estimateDefSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(estimateDefSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);
                        paraConsTaxPrintDiv.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.ConsTaxPrintDiv);
                        paraListPricePrintDiv.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.ListPricePrintDiv);
                        paraEstmFormNoPickDiv.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.EstmFormNoPickDiv);
                        paraEstimateTitle1.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EstimateTitle1);
                        paraEstimateNote1.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EstimateNote1);
                        paraEstimateNote2.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EstimateNote2);
                        paraEstimateNote3.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EstimateNote3);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.EstimatePrtDiv);
                        paraFaxEstimatetDiv.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.FaxEstimatetDiv);
                        paraPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.PartsNoPrtCd);
                        paraOptionPringDivCd.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.OptionPringDivCd);
                        paraPartsSelectDivCd.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.PartsSelectDivCd);
                        paraPartsSearchDivCd.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.PartsSearchDivCd);
                        paraEstimateDtCreateDiv.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.EstimateDtCreateDiv);
                        paraEstimateValidityTerm.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.EstimateValidityTerm);
                        paraRateUseCode.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.RateUseCode);
                        
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(estimateDefSetWork);
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

            estimateDefSetWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の見積初期値設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="estimateDefSetWork">検索結果</param>
        /// <param name="parseEstimateDefSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の見積初期値設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int Search(out object estimateDefSetWork, object parseEstimateDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            estimateDefSetWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchEstimateDefSetProc(out estimateDefSetWork, parseEstimateDefSetWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EstimateDefSetDB.Search");
                estimateDefSetWork = new ArrayList();
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
        /// 指定された条件の見積初期値設定マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objestimateDefSetWork">検索結果</param>
        /// <param name="paraEstimateDefSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の見積初期値設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int SearchEstimateDefSetProc(out object objestimateDefSetWork, object paraEstimateDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            EstimateDefSetWork estimateDefSetWork = null;

            ArrayList estimateDefSetWorkList = paraEstimateDefSetWork as ArrayList;
            if (estimateDefSetWorkList == null)
            {
                estimateDefSetWork = paraEstimateDefSetWork as EstimateDefSetWork;
            }
            else
            {
                if (estimateDefSetWorkList.Count > 0)
                    estimateDefSetWork = estimateDefSetWorkList[0] as EstimateDefSetWork;
            }

            int status = SearchEstimateDefSetProc(out estimateDefSetWorkList, estimateDefSetWork, readMode, logicalMode, ref sqlConnection);
            objestimateDefSetWork = estimateDefSetWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の見積初期値設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="estimateDefSetWorkList">検索結果</param>
        /// <param name="estimateDefSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int SearchEstimateDefSetProc(out ArrayList estimateDefSetWorkList, EstimateDefSetWork estimateDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchEstimateDefSetProcProc(out estimateDefSetWorkList, estimateDefSetWork, readMode, logicalMode, ref sqlConnection);
        }
        /// <summary>
        /// 指定された条件の見積初期値設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="estimateDefSetWorkList">検索結果</param>
        /// <param name="estimateDefSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        private int SearchEstimateDefSetProcProc(out ArrayList estimateDefSetWorkList, EstimateDefSetWork estimateDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  EST.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,EST.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,EST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,EST.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,EST.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,EST.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,EST.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,EST.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,EST.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += " ,EST.CONSTAXPRINTDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.LISTPRICEPRINTDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.ESTMFORMNOPICKDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATETITLE1RF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATENOTE1RF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATENOTE2RF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATENOTE3RF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.FAXESTIMATETDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.PARTSNOPRTCDRF" + Environment.NewLine;
                selectTxt += " ,EST.OPTIONPRINGDIVCDRF" + Environment.NewLine;
                selectTxt += " ,EST.PARTSSELECTDIVCDRF" + Environment.NewLine;
                selectTxt += " ,EST.PARTSSEARCHDIVCDRF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATEDTCREATEDIVRF" + Environment.NewLine;
                selectTxt += " ,EST.ESTIMATEVALIDITYTERMRF" + Environment.NewLine;
                selectTxt += " ,EST.RATEUSECODERF" + Environment.NewLine;
                selectTxt += "FROM ESTIMATEDEFSETRF AS EST" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     EST.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND EST.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                
                selectTxt = "";
                selectTxt += "WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " EST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                
                //拠点コード
                if (string.IsNullOrEmpty(estimateDefSetWork.SectionCode) == false)
                {
                    selectTxt += " AND EST.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);
                }

                string wkstring = "";
                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = " AND EST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = " AND EST.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    selectTxt += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlCommand.CommandText += selectTxt;
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToEstimateDefSetWorkFromReader(ref myReader,0));

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

            estimateDefSetWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 見積初期値設定マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="estimateDefSetWork">EstimateDefSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int LogicalDelete(ref object estimateDefSetWork)
        {
            return LogicalDeleteEstimateDefSet(ref estimateDefSetWork, 0);
        }

        /// <summary>
        /// 論理削除見積初期値設定マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="estimateDefSetWork">EstimateDefSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除見積初期値設定マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int RevivalLogicalDelete(ref object estimateDefSetWork)
        {
            return LogicalDeleteEstimateDefSet(ref estimateDefSetWork, 1);
        }

        /// <summary>
        /// 見積初期値設定マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="estimateDefSetWork">EstimateDefSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        private int LogicalDeleteEstimateDefSet(ref object estimateDefSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(estimateDefSetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteEstimateDefSetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "EstimateDefSetDB.LogicalDeleteEstimateDefSet :" + procModestr);

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
        /// 見積初期値設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="estimateDefSetWorkList">estimateDefSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int LogicalDeleteEstimateDefSetProc(ref ArrayList estimateDefSetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteEstimateDefSetProcProc(ref estimateDefSetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 見積初期値設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="estimateDefSetWorkList">estimateDefSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 見積初期値設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        private int LogicalDeleteEstimateDefSetProcProc(ref ArrayList estimateDefSetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string selectTxt = "";
            try
            {
                if (estimateDefSetWorkList != null) 
                {
                    for (int i = 0; i < estimateDefSetWorkList.Count; i++)
                    {
                        EstimateDefSetWork estimateDefSetWork = estimateDefSetWorkList[i] as EstimateDefSetWork;

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "FROM ESTIMATEDEFSETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != estimateDefSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            selectTxt = "";
                            selectTxt += "UPDATE ESTIMATEDEFSETRF" + Environment.NewLine;
                            selectTxt += "SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)estimateDefSetWork;
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
                            else if (logicalDelCd == 0) estimateDefSetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else estimateDefSetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) estimateDefSetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(estimateDefSetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(estimateDefSetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(estimateDefSetWork);
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

            estimateDefSetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 見積初期値設定マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">見積初期値設定マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 見積初期値設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
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

                status = DeleteEstimateDefSetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EstimateDefSetDB.Delete");
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
        /// 見積初期値設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="estimateDefSetWorkList">見積初期値設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 見積初期値設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        public int DeleteEstimateDefSetProc(ArrayList estimateDefSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteEstimateDefSetProcProc(estimateDefSetWorkList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 見積初期値設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="estimateDefSetWorkList">見積初期値設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 見積初期値設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        private int DeleteEstimateDefSetProcProc(ArrayList estimateDefSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectTxt ="";
                
                for (int i = 0; i < estimateDefSetWorkList.Count; i++)
                {
                    EstimateDefSetWork estimateDefSetWork = estimateDefSetWorkList[i] as EstimateDefSetWork;
                    
                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "FROM ESTIMATEDEFSETRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != estimateDefSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        selectTxt = "";

                        selectTxt += "DELETE" + Environment.NewLine;
                        selectTxt += "FROM ESTIMATEDEFSETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.SectionCode);
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
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
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
        /// <param name="estimateDefSetWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, EstimateDefSetWork estimateDefSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(estimateDefSetWork.EnterpriseCode);

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

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            EstimateDefSetWork[] EstimateDefSetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is EstimateDefSetWork)
                    {
                        EstimateDefSetWork wkEstimateDefSetWork = paraobj as EstimateDefSetWork;
                        if (wkEstimateDefSetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkEstimateDefSetWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            EstimateDefSetWorkArray = (EstimateDefSetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(EstimateDefSetWork[]));
                        }
                        catch (Exception) { }
                        if (EstimateDefSetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(EstimateDefSetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                EstimateDefSetWork wkEstimateDefSetWork = (EstimateDefSetWork)XmlByteSerializer.Deserialize(byteArray, typeof(EstimateDefSetWork));
                                if (wkEstimateDefSetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkEstimateDefSetWork);
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
        /// クラス格納処理 Reader → estimateDefSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">intr</param>
        /// <returns>estimateDefSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.09.26</br>
        /// </remarks>
        private EstimateDefSetWork CopyToEstimateDefSetWorkFromReader(ref SqlDataReader myReader,int mode)
        {
            EstimateDefSetWork wkEstimateDefSetWork = new EstimateDefSetWork();

            #region クラスへ格納
            wkEstimateDefSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEstimateDefSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEstimateDefSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEstimateDefSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEstimateDefSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEstimateDefSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEstimateDefSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEstimateDefSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkEstimateDefSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkEstimateDefSetWork.ConsTaxPrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXPRINTDIVRF"));
            wkEstimateDefSetWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
            wkEstimateDefSetWork.EstmFormNoPickDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMFORMNOPICKDIVRF"));
            wkEstimateDefSetWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));
            wkEstimateDefSetWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
            wkEstimateDefSetWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
            wkEstimateDefSetWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
            wkEstimateDefSetWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
            wkEstimateDefSetWork.FaxEstimatetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FAXESTIMATETDIVRF"));
            wkEstimateDefSetWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
            wkEstimateDefSetWork.OptionPringDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONPRINGDIVCDRF"));
            wkEstimateDefSetWork.PartsSelectDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSELECTDIVCDRF"));
            wkEstimateDefSetWork.PartsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSSEARCHDIVCDRF"));
            wkEstimateDefSetWork.EstimateDtCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDTCREATEDIVRF"));
            wkEstimateDefSetWork.EstimateValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEVALIDITYTERMRF"));
            wkEstimateDefSetWork.RateUseCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEUSECODERF"));
            
            if (mode == 0)
            {
                wkEstimateDefSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            }
            #endregion

            return wkEstimateDefSetWork;
        }
        #endregion

    }
}