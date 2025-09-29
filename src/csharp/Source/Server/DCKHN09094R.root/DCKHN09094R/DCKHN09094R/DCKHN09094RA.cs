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
    /// BLコードマスタメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコードマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2007.08.17</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 数馬 PM.NS用に修正</br>
    /// </remarks>
    [Serializable]
    public class BLGoodsCdUDB : RemoteDB, IBLGoodsCdUDB, IGetSyncdataList
    {
        /// <summary>
        /// BLコードマスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>														   
        /// <br>Date       : 2006.11.30</br>
        /// </remarks>
        public BLGoodsCdUDB()
            :
        base("DCKHN09096D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdUWork", "BLGOODSCDURF")
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
        /// <br>Note       : 指定された条件のBLコードマスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
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
        /// <br>Note       : 指定された条件のBLコードマスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;

          ArrayList al = new ArrayList();
          try
          {
            string sqlTxt = "";
            sqlTxt += "SELECT" + Environment.NewLine;
            sqlTxt += "   CREATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
            sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
            sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
            sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
            sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
            sqlTxt += "  ,BLGROUPCODERF" + Environment.NewLine;
            sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
            sqlTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
            sqlTxt += "  ,BLGOODSHALFNAMERF" + Environment.NewLine;
            sqlTxt += "  ,BLGOODSGENRECODERF" + Environment.NewLine;
            sqlTxt += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
            sqlTxt += " FROM BLGOODSCDURF" + Environment.NewLine;
            
            sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

            sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {

              al.Add(CopyToBLGoodsCdUWorkFromReader(ref myReader));

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
        /// <br>Date       : 2007.08.17</br>
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
        /// 指定された条件のBLコードマスタを戻します
        /// </summary>
        /// <param name="parabyte">BLGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();

                // XMLの読み込み
                bLGoodsCdUWork = (BLGoodsCdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(BLGoodsCdUWork));
                if (bLGoodsCdUWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref bLGoodsCdUWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(bLGoodsCdUWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdUDB.Read");
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
        /// 指定された条件のBLコードマスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWork">BLGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		public int ReadProc(ref BLGoodsCdUWork bLGoodsCdUWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref bLGoodsCdUWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件のBLコードマスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWork">BLGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		private int ReadProcProc(ref BLGoodsCdUWork bLGoodsCdUWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSHALFNAMERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSGENRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,OFFERDATADIVRF" + Environment.NewLine;
                sqlTxt += " FROM BLGOODSCDURF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        bLGoodsCdUWork = CopyToBLGoodsCdUWorkFromReader(ref myReader);
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
        /// BLコードマスタ情報を登録、更新します
        /// </summary>
        /// <param name="bLGoodsCdUWork">BLGoodsCdUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        public int Write(ref object bLGoodsCdUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(bLGoodsCdUWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteBLGoodsCdProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                bLGoodsCdUWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdUDB.Write(ref object bLGoodsCdUWork)");
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
        /// BLコードマスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWorkList">BLGoodsCdUWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		public int WriteBLGoodsCdProc(ref ArrayList bLGoodsCdUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteBLGoodsCdProcProc(ref bLGoodsCdUWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// BLコードマスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWorkList">BLGoodsCdUWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		private int WriteBLGoodsCdProcProc(ref ArrayList bLGoodsCdUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (bLGoodsCdUWorkList != null)
                {
                   string sqlTxt = ""; 
                    
                    for (int i = 0; i < bLGoodsCdUWorkList.Count; i++)
                    {
                        BLGoodsCdUWork bLGoodsCdUWork = bLGoodsCdUWorkList[i] as BLGoodsCdUWork;
                        sqlTxt = "";
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "  BLGOODS.CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += " ,BLGOODS.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "FROM BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     BLGOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND BLGOODS.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != bLGoodsCdUWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (bLGoodsCdUWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlTxt = "";
                            sqlTxt += "UPDATE BLGOODSCDURF SET" + Environment.NewLine;
                            sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                            sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlTxt += " , BLGOODSFULLNAMERF=@BLGOODSFULLNAME" + Environment.NewLine;
                            sqlTxt += " , BLGOODSHALFNAMERF=@BLGOODSHALFNAME" + Environment.NewLine;
                            sqlTxt += " , BLGOODSGENRECODERF=@BLGOODSGENRECODE" + Environment.NewLine;
                            sqlTxt += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                            sqlTxt += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                            sqlTxt += " , OFFERDATADIVRF=@OFFERDATADIV" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            
                            sqlCommand.CommandText = sqlTxt;
                                                      
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLGoodsCdUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            //提供データを修正した場合は提供データ区分に１をセットする
                            if ((bLGoodsCdUWork.OfferDate != DateTime.MinValue) && (bLGoodsCdUWork.OfferDataDiv == 0))
                            {
                                bLGoodsCdUWork.OfferDataDiv = 1;
                            }

                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (bLGoodsCdUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                              
                            sqlTxt = "";
                            sqlTxt += "INSERT INTO BLGOODSCDURF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "  ,BLGROUPCODERF" + Environment.NewLine;
                            sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                            sqlTxt += "  ,BLGOODSHALFNAMERF" + Environment.NewLine;
                            sqlTxt += "  ,BLGOODSGENRECODERF" + Environment.NewLine;
                            sqlTxt += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                            sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                            sqlTxt += "  ,OFFERDATADIVRF" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;
                            sqlTxt += " VALUES" + Environment.NewLine;
                            sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "  ,@BLGROUPCODE" + Environment.NewLine;
                            sqlTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlTxt += "  ,@BLGOODSFULLNAME" + Environment.NewLine;
                            sqlTxt += "  ,@BLGOODSHALFNAME" + Environment.NewLine;
                            sqlTxt += "  ,@BLGOODSGENRECODE" + Environment.NewLine;
                            sqlTxt += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                            sqlTxt += "  ,@OFFERDATE" + Environment.NewLine;
                            sqlTxt += "  ,@OFFERDATADIV" + Environment.NewLine;
                            sqlTxt += " )" + Environment.NewLine;

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = sqlTxt;
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLGoodsCdUWork;
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
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsHalfName = sqlCommand.Parameters.Add("@BLGOODSHALFNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsGenreCode = sqlCommand.Parameters.Add("@BLGOODSGENRECODE", SqlDbType.Int);
                        SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);
                        
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLGoodsCdUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLGoodsCdUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(bLGoodsCdUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.LogicalDeleteCode);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.BLGoodsFullName);
                        paraBLGoodsHalfName.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.BLGoodsHalfName);
                        paraBLGoodsGenreCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsGenreCode);
                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.GoodsRateGrpCode);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(bLGoodsCdUWork.OfferDate);
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.OfferDataDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(bLGoodsCdUWork);
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

            bLGoodsCdUWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件のBLコードマスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="bLGoodsCdUWork">検索結果</param>
        /// <param name="parseBLGoodsCdUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        public int Search(out object bLGoodsCdUWork, object parseBLGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            bLGoodsCdUWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchBLGoodsCdProc(out bLGoodsCdUWork, parseBLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdUDB.Search");
                bLGoodsCdUWork = new ArrayList();
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
        /// 指定された条件のBLコードマスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objbLGoodsCdUWork">検索結果</param>
        /// <param name="parabLGoodsCdUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        public int SearchBLGoodsCdProc(out object objbLGoodsCdUWork, object parabLGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            BLGoodsCdUWork bLGoodsCdUWork = null;

            ArrayList bLGoodsCdUWorkList = parabLGoodsCdUWork as ArrayList;
            if (bLGoodsCdUWorkList == null)
            {
                bLGoodsCdUWork = parabLGoodsCdUWork as BLGoodsCdUWork;
            }
            else
            {
                if (bLGoodsCdUWorkList.Count > 0)
                    bLGoodsCdUWork = bLGoodsCdUWorkList[0] as BLGoodsCdUWork;
            }

            int status = SearchBLGoodsCdProc(out bLGoodsCdUWorkList, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
            objbLGoodsCdUWork = bLGoodsCdUWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のBLコードマスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWorkList">検索結果</param>
        /// <param name="bLGoodsCdUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		public int SearchBLGoodsCdProc(out ArrayList bLGoodsCdUWorkList, BLGoodsCdUWork bLGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchBLGoodsCdProcProc(out bLGoodsCdUWorkList, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件のBLコードマスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWorkList">検索結果</param>
        /// <param name="bLGoodsCdUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		private int SearchBLGoodsCdProcProc(out ArrayList bLGoodsCdUWorkList, BLGoodsCdUWork bLGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSHALFNAMERF" + Environment.NewLine;
                sqlTxt += "  ,BLGOODSGENRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                sqlTxt += "  ,OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,OFFERDATADIVRF" + Environment.NewLine;
                sqlTxt += " FROM BLGOODSCDURF" + Environment.NewLine;
            
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //企業コード
                sqlTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                
                //BL商品コード
                if (bLGoodsCdUWork.BLGoodsCode != 0)
                {
                  sqlTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                  SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                  paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);
                }

                string wkstring = "";
                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                  wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                  wkstring = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                  sqlTxt += wkstring;
                  SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlCommand.CommandText += sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToBLGoodsCdUWorkFromReader(ref myReader));

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

            bLGoodsCdUWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// BLコードマスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="bLGoodsCdUWork">BLGoodsCdUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        public int LogicalDelete(ref object bLGoodsCdUWork)
        {
            return LogicalDeleteBLGoodsCd(ref bLGoodsCdUWork, 0);
        }

        /// <summary>
        /// 論理削除BLコードマスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="bLGoodsCdUWork">BLGoodsCdUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除BLコードマスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        public int RevivalLogicalDelete(ref object bLGoodsCdUWork)
        {
            return LogicalDeleteBLGoodsCd(ref bLGoodsCdUWork, 1);
        }

        /// <summary>
        /// BLコードマスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="bLGoodsCdUWork">BLGoodsCdUWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        private int LogicalDeleteBLGoodsCd(ref object bLGoodsCdUWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(bLGoodsCdUWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteBLGoodsCdProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "BLGoodsCdUDB.LogicalDeleteBLGoodsCd :" + procModestr);

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
        /// BLコードマスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWorkList">bLGoodsCdUWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		public int LogicalDeleteBLGoodsCdProc(ref ArrayList bLGoodsCdUWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteBLGoodsCdProcProc(ref bLGoodsCdUWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// BLコードマスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWorkList">bLGoodsCdUWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードマスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		private int LogicalDeleteBLGoodsCdProcProc(ref ArrayList bLGoodsCdUWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (bLGoodsCdUWorkList != null)
                {
                    for (int i = 0; i < bLGoodsCdUWorkList.Count; i++)
                    {
                        BLGoodsCdUWork bLGoodsCdUWork = bLGoodsCdUWorkList[i] as BLGoodsCdUWork;

                        string sqlTxt = "";
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "  BLGOODS.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += " ,BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += " ,BLGOODS.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "FROM BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     BLGOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND BLGOODS.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != bLGoodsCdUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlTxt = "";
                            sqlTxt += "UPDATE BLGOODSCDURF" + Environment.NewLine;
                            sqlTxt += "SET" + Environment.NewLine;
                            sqlTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "WHERE" + Environment.NewLine;
                            sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLGoodsCdUWork;
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
                            else if (logicalDelCd == 0) bLGoodsCdUWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else bLGoodsCdUWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) bLGoodsCdUWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLGoodsCdUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(bLGoodsCdUWork);
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

            bLGoodsCdUWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// BLコードマスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">BLコードマスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : BLコードマスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
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

                status = DeleteBLGoodsCdProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "BLGoodsCdUDB.Delete");
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
        /// BLコードマスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWorkList">BLコードマスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : BLコードマスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		public int DeleteBLGoodsCdProc(ArrayList bLGoodsCdUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteBLGoodsCdProcProc(bLGoodsCdUWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// BLコードマスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="bLGoodsCdUWorkList">BLコードマスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : BLコードマスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
		private int DeleteBLGoodsCdProcProc(ArrayList bLGoodsCdUWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt ="";
                
                for (int i = 0; i < bLGoodsCdUWorkList.Count; i++)
                {
                    BLGoodsCdUWork bLGoodsCdUWork = bLGoodsCdUWorkList[i] as BLGoodsCdUWork;
                    
                    sqlTxt = "";

                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "  BLGOODS.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += " ,BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += " ,BLGOODS.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "FROM BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                    sqlTxt += "WHERE" + Environment.NewLine;
                    sqlTxt += "     BLGOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " AND BLGOODS.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                    
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != bLGoodsCdUWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlTxt = "";

                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += "FROM BLGOODSCDURF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLGoodsCdUWork.EnterpriseCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLGoodsCdUWork.BLGoodsCode);
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
        /// <br>Date       : 2007.08.17</br>
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

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            BLGoodsCdUWork[] BLGoodsCdUWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is BLGoodsCdUWork)
                    {
                        BLGoodsCdUWork wkBLGoodsCdUWork = paraobj as BLGoodsCdUWork;
                        if (wkBLGoodsCdUWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkBLGoodsCdUWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            BLGoodsCdUWorkArray = (BLGoodsCdUWork[])XmlByteSerializer.Deserialize(byteArray, typeof(BLGoodsCdUWork[]));
                        }
                        catch (Exception) { }
                        if (BLGoodsCdUWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(BLGoodsCdUWorkArray);
                        }
                        else
                        {
                            try
                            {
                                BLGoodsCdUWork wkBLGoodsCdUWork = (BLGoodsCdUWork)XmlByteSerializer.Deserialize(byteArray, typeof(BLGoodsCdUWork));
                                if (wkBLGoodsCdUWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkBLGoodsCdUWork);
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
        /// クラス格納処理 Reader → bLGoodsCdUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLGoodsCdUWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.17</br>
        /// </remarks>
        private BLGoodsCdUWork CopyToBLGoodsCdUWorkFromReader(ref SqlDataReader myReader)
        {
            BLGoodsCdUWork wkBLGoodsCdUWork = new BLGoodsCdUWork();

            #region クラスへ格納
            wkBLGoodsCdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkBLGoodsCdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkBLGoodsCdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkBLGoodsCdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkBLGoodsCdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkBLGoodsCdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkBLGoodsCdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkBLGoodsCdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkBLGoodsCdUWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkBLGoodsCdUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkBLGoodsCdUWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkBLGoodsCdUWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            wkBLGoodsCdUWork.BLGoodsGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSGENRECODERF"));
            wkBLGoodsCdUWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkBLGoodsCdUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkBLGoodsCdUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            #endregion

            return wkBLGoodsCdUWork;
        }
        #endregion

    }
}