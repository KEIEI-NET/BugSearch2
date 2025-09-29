using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上金額処理区分設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上金額処理区分設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.05.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SalesProcMoneyDB : RemoteDB, IGetSyncdataList, ISalesProcMoneyDB
    {
        /// <summary>
        /// 売上金額処理区分設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.22</br>
        /// </remarks>
        public SalesProcMoneyDB()
            :
            base("MAHNB06016D", "Broadleaf.Application.Remoting.ParamData.SalesProcMoneyWork", "SALESPROCMONEYRF")
        {
        }
        
        #region [Read]
        /// <summary>
        /// 指定された条件の仕入金額処理区分設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">SalesProcMoneyWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上金額処理区分設定マスタを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlConnection sqlConnection = null;

          try
          {
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

            // XMLの読み込み
            salesProcMoneyWork = (SalesProcMoneyWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalesProcMoneyWork));
            if (salesProcMoneyWork == null) return status;

            //コネクション生成
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            status = ReadProc(ref salesProcMoneyWork, readMode, ref sqlConnection);

            // XMLへ変換し、文字列のバイナリ化
            parabyte = XmlByteSerializer.Serialize(salesProcMoneyWork);
          }
          catch (Exception ex)
          {
            base.WriteErrorLog(ex, "SalesProcMoneyDB.Read");
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
        /// 指定された条件の売上金額処理区分設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上金額処理区分設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int ReadProc(ref SalesProcMoneyWork salesProcMoneyWork, int readMode, ref SqlConnection sqlConnection)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlDataReader myReader = null;

          try
          {
            string selectTxt = "";
            selectTxt += "SELECT * FROM SALESPROCMONEYRF ";
            selectTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
            
            //Selectコマンドの生成
            using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
            {

              //Prameterオブジェクトの作成
              SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

              //Parameterオブジェクトへ値設定
              findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);

              myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
              if (myReader.Read())
              {
                salesProcMoneyWork = CopyToSalesProcMoneyWorkFromReader(ref myReader);
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
        /// 売上金額処理区分設定マスタを読み込む
        /// </summary>
        /// <param name="salesProcMoneyWork">売上金額処理区分設定マスタ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns></returns>
        public int Read(ref SalesProcMoneyWork salesProcMoneyWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

          SqlDataReader myReader = null;
          try
          {
            string selectTxt = "";
            
            selectTxt += "SELECT ";
            selectTxt += "CREATEDATETIMERF";
            selectTxt += ",UPDATEDATETIMERF";
            selectTxt += ",ENTERPRISECODERF";
            selectTxt += ",FILEHEADERGUIDRF";
            selectTxt += ",UPDEMPLOYEECODERF";
            selectTxt += ",UPDASSEMBLYID1RF";
            selectTxt += ",UPDASSEMBLYID2RF";
            selectTxt += ",LOGICALDELETECODERF";
            selectTxt += ",FRACPROCMONEYDIVRF";
            selectTxt += ",FRACTIONPROCCDRF";
            selectTxt += ",FRACTIONPROCCODERF";
            selectTxt += ",UPPERLIMITPRICERF";
            selectTxt += ",FRACTIONPROCUNITRF";
            selectTxt += " FROM SALESPROCMONEYRF";
            selectTxt += " WHERE ";
            selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
            selectTxt += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
            selectTxt += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
            selectTxt += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";

            //Selectコマンドの生成
            using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction))
            {

              //Prameterオブジェクトの作成
              SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
              SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
              SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
              SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

              //Parameterオブジェクトへ値設定
              findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
              findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
              findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
              findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

              myReader = sqlCommand.ExecuteReader();
              if (myReader.Read())
              {
                salesProcMoneyWork = CopyToSalesProcMoneyWorkFromReader(ref myReader);
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
        /// 売上金額処理区分設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上金額処理区分設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int Write(ref object salesProcMoneyWork)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlConnection sqlConnection = null;
          SqlTransaction sqlTransaction = null;
          try
          {
            //パラメータのキャスト
            ArrayList paraList = CastToArrayListFromPara(salesProcMoneyWork);
            if (paraList == null) return status;

            //コネクション生成
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // トランザクション開始
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            //write実行
            status = WriteSalesProcMoneyProc(ref paraList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
              // コミット
              sqlTransaction.Commit();
            else
            {
              // ロールバック
              if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            //戻り値セット
            salesProcMoneyWork = paraList;
          }
          catch (Exception ex)
          {
            base.WriteErrorLog(ex, "SalesProcMoneyDB.Write(ref object salesProcMoneyWork)");
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
        /// 売上金額処理区分設定マスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="salesProcMoneyWorkList">SalesProcMoneyWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上金額処理区分設定マスタ情報を登録、更新します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int WriteSalesProcMoneyProc(ref ArrayList salesProcMoneyWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;
          ArrayList al = new ArrayList();
          try
          {
            if (salesProcMoneyWorkList != null)
            {
              string selectTxt = "";
              for (int i = 0; i < salesProcMoneyWorkList.Count; i++)
              {
                SalesProcMoneyWork salesProcMoneyWork = salesProcMoneyWorkList[i] as SalesProcMoneyWork;
                selectTxt = "";
                
                selectTxt += "SELECT ";
                selectTxt += "UPDATEDATETIMERF";
                selectTxt += ",ENTERPRISECODERF ";
                selectTxt += "FROM SALESPROCMONEYRF ";
                selectTxt += "WHERE ";
                selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE";
                selectTxt += " AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV";
                selectTxt += " AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE";
                selectTxt += " AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                
                //Selectコマンドの生成
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                  //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                  DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                  if (_updateDateTime != salesProcMoneyWork.UpdateDateTime)
                  {
                    //新規登録で該当データ有りの場合には重複
                    if (salesProcMoneyWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //既存データで更新日時違いの場合には排他
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                  }

                  sqlCommand.CommandText =  "UPDATE SALESPROCMONEYRF ";
                  sqlCommand.CommandText += "SET  UPDATEDATETIMERF=@UPDATEDATETIME";
                  sqlCommand.CommandText += ", ENTERPRISECODERF=@ENTERPRISECODE";
                  sqlCommand.CommandText += ", FILEHEADERGUIDRF=@FILEHEADERGUID";
                  sqlCommand.CommandText += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE";
                  sqlCommand.CommandText += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1";
                  sqlCommand.CommandText += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2";
                  sqlCommand.CommandText += ", LOGICALDELETECODERF=@LOGICALDELETECODE";
                  sqlCommand.CommandText += ", FRACPROCMONEYDIVRF=@FRACPROCMONEYDIV";
                  sqlCommand.CommandText += ", FRACTIONPROCCDRF=@FRACTIONPROCCD";
                  sqlCommand.CommandText += ", FRACTIONPROCCODERF=@FRACTIONPROCCODE";
                  sqlCommand.CommandText += ", UPPERLIMITPRICERF=@UPPERLIMITPRICE";
                  sqlCommand.CommandText += ", FRACTIONPROCUNITRF=@FRACTIONPROCUNIT ";
                  sqlCommand.CommandText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                  sqlCommand.CommandText += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                  sqlCommand.CommandText += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                  sqlCommand.CommandText += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                  
                  //KEYコマンドを再設定
                  findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                  findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                  findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                  findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

                  //更新ヘッダ情報を設定
                  object obj = (object)this;
                  IFileHeader flhd = (IFileHeader)salesProcMoneyWork;
                  FileHeader fileHeader = new FileHeader(obj);
                  fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                  //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                  if (salesProcMoneyWork.UpdateDateTime > DateTime.MinValue)
                  {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                  }

                  //新規作成時のSQL文を生成
                  sqlCommand.CommandText = "INSERT INTO SALESPROCMONEYRF ";
                  sqlCommand.CommandText += "(CREATEDATETIMERF";
                  sqlCommand.CommandText += ", UPDATEDATETIMERF";
                  sqlCommand.CommandText += ", ENTERPRISECODERF";
                  sqlCommand.CommandText += ", FILEHEADERGUIDRF";
                  sqlCommand.CommandText += ", UPDEMPLOYEECODERF";
                  sqlCommand.CommandText += ", UPDASSEMBLYID1RF";
                  sqlCommand.CommandText += ", UPDASSEMBLYID2RF";
                  sqlCommand.CommandText += ", LOGICALDELETECODERF";
                  sqlCommand.CommandText += ", FRACPROCMONEYDIVRF";
                  sqlCommand.CommandText += ", FRACTIONPROCCDRF";
                  sqlCommand.CommandText += ", FRACTIONPROCCODERF";
                  sqlCommand.CommandText += ", UPPERLIMITPRICERF";
                  sqlCommand.CommandText += ", FRACTIONPROCUNITRF) ";
                  sqlCommand.CommandText += "VALUES ";
                  sqlCommand.CommandText += "(@CREATEDATETIME";
                  sqlCommand.CommandText += ", @UPDATEDATETIME";
                  sqlCommand.CommandText += ", @ENTERPRISECODE";
                  sqlCommand.CommandText += ", @FILEHEADERGUID";
                  sqlCommand.CommandText += ", @UPDEMPLOYEECODE";
                  sqlCommand.CommandText += ", @UPDASSEMBLYID1";
                  sqlCommand.CommandText += ", @UPDASSEMBLYID2";
                  sqlCommand.CommandText += ", @LOGICALDELETECODE";
                  sqlCommand.CommandText += ", @FRACPROCMONEYDIV";
                  sqlCommand.CommandText += ", @FRACTIONPROCCD";
                  sqlCommand.CommandText += ", @FRACTIONPROCCODE";
                  sqlCommand.CommandText += ", @UPPERLIMITPRICE";
                  sqlCommand.CommandText += ", @FRACTIONPROCUNIT)";
                  
                  //登録ヘッダ情報を設定
                  object obj = (object)this;
                  IFileHeader flhd = (IFileHeader)salesProcMoneyWork;
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
                SqlParameter paraFracProcMoneyDiv = sqlCommand.Parameters.Add("@FRACPROCMONEYDIV", SqlDbType.Int);
                SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                SqlParameter paraFractionProcCode = sqlCommand.Parameters.Add("@FRACTIONPROCCODE", SqlDbType.Int);
                SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);
                SqlParameter paraFractionProcUnit = sqlCommand.Parameters.Add("@FRACTIONPROCUNIT", SqlDbType.Float);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesProcMoneyWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesProcMoneyWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesProcMoneyWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.LogicalDeleteCode);
                paraFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCd);
                paraFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);
                paraFractionProcUnit.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.FractionProcUnit);
                #endregion

                sqlCommand.ExecuteNonQuery();
                al.Add(salesProcMoneyWork);
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

          salesProcMoneyWorkList = al;

          return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の売上金額処理区分設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="salesProcMoneyWork">検索結果</param>
        /// <param name="parseSalesProcMoneyWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上金額処理区分設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int Search(out object salesProcMoneyWork, object parseSalesProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
          SqlConnection sqlConnection = null;
          salesProcMoneyWork = null;
          try
          {
            //コネクション生成
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            return SearchSalesProcMoneyProc(out salesProcMoneyWork, parseSalesProcMoneyWork, readMode, logicalMode, ref sqlConnection);

          }
          catch (Exception ex)
          {
            base.WriteErrorLog(ex, "SalesProcMoneyDB.Search");
            salesProcMoneyWork = new ArrayList();
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
        /// 指定された条件の売上金額処理区分設定マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objsalesProcMoneyWork">検索結果</param>
        /// <param name="parasalesProcMoneyWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上金額処理区分設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int SearchSalesProcMoneyProc(out object objsalesProcMoneyWork, object parasalesProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
          SalesProcMoneyWork salesProcMoneyWork = null;

          ArrayList salesProcMoneyWorkList = parasalesProcMoneyWork as ArrayList;
          if (salesProcMoneyWorkList == null)
          {
            salesProcMoneyWork = parasalesProcMoneyWork as SalesProcMoneyWork;
          }
          else
          {
            if (salesProcMoneyWorkList.Count > 0)
              salesProcMoneyWork = salesProcMoneyWorkList[0] as SalesProcMoneyWork;
          }

          int status = SearchSalesProcMoneyProc(out salesProcMoneyWorkList, salesProcMoneyWork, readMode, logicalMode, ref sqlConnection);
          objsalesProcMoneyWork = salesProcMoneyWorkList;
          return status;
        }

        /// <summary>
        /// 指定された条件の売上金額処理区分設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesProcMoneyWorkList">検索結果</param>
        /// <param name="salesProcMoneyWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上金額処理区分設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int SearchSalesProcMoneyProc(out ArrayList salesProcMoneyWorkList, SalesProcMoneyWork salesProcMoneyWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;

          ArrayList al = new ArrayList();
          try
          {
            sqlCommand = new SqlCommand("SELECT * FROM SALESPROCMONEYRF ", sqlConnection);

            sqlCommand.CommandText += MakeWhereString(ref sqlCommand, salesProcMoneyWork, logicalMode);

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {

              al.Add(CopyToSalesProcMoneyWorkFromReader(ref myReader));

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

          salesProcMoneyWorkList = al;

          return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 売上金額処理区分設定マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上金額処理区分設定マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int LogicalDelete(ref object salesProcMoneyWork)
        {
          return LogicalDeleteSalesProcMoney(ref salesProcMoneyWork, 0);
        }

        /// <summary>
        /// 論理削除売上金額処理区分設定マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除売上金額処理区分設定マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int RevivalLogicalDelete(ref object salesProcMoneyWork)
        {
          return LogicalDeleteSalesProcMoney(ref salesProcMoneyWork, 1);
        }

        /// <summary>
        /// 売上金額処理区分設定マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="salesProcMoneyWork">SalesProcMoneyWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上金額処理区分設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        private int LogicalDeleteSalesProcMoney(ref object salesProcMoneyWork, int procMode)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlConnection sqlConnection = null;
          SqlTransaction sqlTransaction = null;
          try
          {
            //パラメータのキャスト
            ArrayList paraList = CastToArrayListFromPara(salesProcMoneyWork);
            if (paraList == null) return status;

            //コネクション生成
            sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return status;
            sqlConnection.Open();

            // トランザクション開始
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            status = LogicalDeleteSalesProcMoneyProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
            base.WriteErrorLog(ex, "SalesProcMoneyDB.LogicalDeleteCarrier :" + procModestr);

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
        /// 売上金額処理区分設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="salesProcMoneyWorkList">SalesProcMoneyWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上金額処理区分設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int LogicalDeleteSalesProcMoneyProc(ref ArrayList salesProcMoneyWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          int logicalDelCd = 0;
          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;
          ArrayList al = new ArrayList();

          try
          {
            if (salesProcMoneyWorkList != null)
            {
              for (int i = 0; i < salesProcMoneyWorkList.Count; i++)
              {
                SalesProcMoneyWork salesProcMoneyWork = salesProcMoneyWorkList[i] as SalesProcMoneyWork;

                string selectTxt = "";
                selectTxt += "SELECT UPDATEDATETIMERF";
                selectTxt += ", ENTERPRISECODERF";
                selectTxt += ",LOGICALDELETECODERF ";
                selectTxt += "FROM SALESPROCMONEYRF ";
                selectTxt += "WHERE ";
                selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
                selectTxt += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                selectTxt += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                selectTxt += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
                SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                  //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                  DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                  if (_updateDateTime != salesProcMoneyWork.UpdateDateTime)
                  {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    return status;
                  }
                  //現在の論理削除区分を取得
                  logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                  sqlCommand.CommandText = "UPDATE SALESPROCMONEYRF ";
                  sqlCommand.CommandText += "SET UPDATEDATETIMERF=@UPDATEDATETIME ";
                  sqlCommand.CommandText += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE ";
                  sqlCommand.CommandText += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1 ";
                  sqlCommand.CommandText += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2 ";
                  sqlCommand.CommandText += ", LOGICALDELETECODERF=@LOGICALDELETECODE ";
                  sqlCommand.CommandText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                  sqlCommand.CommandText += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                  sqlCommand.CommandText += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                  sqlCommand.CommandText += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                  
                  //KEYコマンドを再設定
                  findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                  findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                  findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                  findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

                  //更新ヘッダ情報を設定
                  object obj = (object)this;
                  IFileHeader flhd = (IFileHeader)salesProcMoneyWork;
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
                  else if (logicalDelCd == 0) salesProcMoneyWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                  else salesProcMoneyWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                }
                else
                {
                  if (logicalDelCd == 1) salesProcMoneyWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesProcMoneyWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.LogicalDeleteCode);

                int ret = sqlCommand.ExecuteNonQuery();
                
                al.Add(salesProcMoneyWork);
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

          salesProcMoneyWorkList = al;

          return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 売上金額処理区分設定マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">売上金額処理区分設定マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 売上金額処理区分設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
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

            status = DeleteSalesProcMoneyProc(paraList, ref sqlConnection, ref sqlTransaction);
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
            base.WriteErrorLog(ex, "SalesProcMoneyDB.Delete");
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
        /// 売上金額処理区分設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="salesProcMoneyWorkList">売上金額処理区分設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 売上金額処理区分設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        public int DeleteSalesProcMoneyProc(ArrayList salesProcMoneyWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
          int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
          SqlDataReader myReader = null;
          SqlCommand sqlCommand = null;
          try
          {

            for (int i = 0; i < salesProcMoneyWorkList.Count; i++)
            {
              SalesProcMoneyWork salesProcMoneyWork = salesProcMoneyWorkList[i] as SalesProcMoneyWork;

              string selectTxt = "";
              selectTxt += "SELECT UPDATEDATETIMERF";
              selectTxt += ", ENTERPRISECODERF";
              selectTxt += ", LOGICALDELETECODERF ";
              selectTxt += "FROM SALESPROCMONEYRF ";
              selectTxt += "WHERE ";
              selectTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
              selectTxt += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
              selectTxt += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
              selectTxt += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";

              sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

              //Prameterオブジェクトの作成
              SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
              SqlParameter findParaFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
              SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
              SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

              //Parameterオブジェクトへ値設定
              findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
              findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
              findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
              findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);

              myReader = sqlCommand.ExecuteReader();
              if (myReader.Read())
              {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != salesProcMoneyWork.UpdateDateTime)
                {
                  status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                  sqlCommand.Cancel();
                  return status;
                }

                sqlCommand.CommandText = "DELETE FROM SALESPROCMONEYRF ";
                sqlCommand.CommandText += "WHERE ";
                sqlCommand.CommandText += "ENTERPRISECODERF=@FINDENTERPRISECODE ";
                sqlCommand.CommandText += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
                sqlCommand.CommandText += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                sqlCommand.CommandText += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                
                //KEYコマンドを再設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);
                findParaFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
                findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
                findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);
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
        /// <param name="salesProcMoneyWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesProcMoneyWork salesProcMoneyWork, ConstantManagement.LogicalMode logicalMode)
        {
          string wkstring = "";
          string retstring = "WHERE ";

          //企業コード
          retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
          SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
          paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesProcMoneyWork.EnterpriseCode);

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

          //端数処理対象金額区分
          if (salesProcMoneyWork.FracProcMoneyDiv >= 0)
          {
            retstring += "AND FRACPROCMONEYDIVRF=@FINDFRACPROCMONEYDIV ";
            SqlParameter paraFracProcMoneyDiv = sqlCommand.Parameters.Add("@FINDFRACPROCMONEYDIV", SqlDbType.Int);
            paraFracProcMoneyDiv.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FracProcMoneyDiv);
          }

          //端数処理コード
          if (salesProcMoneyWork.FractionProcCode >= 0)
          {
            retstring += "AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
            SqlParameter paraFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
            paraFractionProcCode.Value = SqlDataMediator.SqlSetInt32(salesProcMoneyWork.FractionProcCode);
          }

          //上限金額
          if (salesProcMoneyWork.UpperLimitPrice > 0)
          {
            retstring += "AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE ";
            SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Int);
            paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(salesProcMoneyWork.UpperLimitPrice);
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
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
          ArrayList retal = null;
          SalesProcMoneyWork[] SalesProcMoneyWorkArray = null;

          if (paraobj != null)
            try
            {
              //ArrayListの場合
              if (paraobj is ArrayList)
              {
                retal = paraobj as ArrayList;
              }

              //パラメータクラスの場合
              if (paraobj is SalesProcMoneyWork)
              {
                SalesProcMoneyWork wkSalesProcMoneyWork = paraobj as SalesProcMoneyWork;
                if (wkSalesProcMoneyWork != null)
                {
                  retal = new ArrayList();
                  retal.Add(wkSalesProcMoneyWork);
                }
              }

              //byte[]の場合
              if (paraobj is byte[])
              {
                byte[] byteArray = paraobj as byte[];
                try
                {
                  SalesProcMoneyWorkArray = (SalesProcMoneyWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SalesProcMoneyWork[]));
                }
                catch (Exception) { }
                if (SalesProcMoneyWorkArray != null)
                {
                  retal = new ArrayList();
                  retal.AddRange(SalesProcMoneyWorkArray);
                }
                else
                {
                  try
                  {
                    SalesProcMoneyWork wkSalesProcMoneyWork = (SalesProcMoneyWork)XmlByteSerializer.Deserialize(byteArray, typeof(SalesProcMoneyWork));
                    if (wkSalesProcMoneyWork != null)
                    {
                      retal = new ArrayList();
                      retal.Add(wkSalesProcMoneyWork);
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

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セット情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM SALESPROCMONEYRF ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSalesProcMoneyWorkFromReader(ref myReader));
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

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
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

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SalesProcMoneyWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesProcMoneyWork</returns>
        /// <remarks>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.22</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS用にレイアウト変更</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private SalesProcMoneyWork CopyToSalesProcMoneyWorkFromReader(ref SqlDataReader myReader)
        {
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

            #region クラスへ格納
            salesProcMoneyWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            salesProcMoneyWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            salesProcMoneyWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            salesProcMoneyWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            salesProcMoneyWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            salesProcMoneyWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            salesProcMoneyWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            salesProcMoneyWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            // 2007.08.14 Delete >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //salesProcMoneyWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // 2007.08.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            salesProcMoneyWork.FracProcMoneyDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCMONEYDIVRF"));
            salesProcMoneyWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));

            // 2007.08.14 Add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            salesProcMoneyWork.FractionProcCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCODERF"));
            salesProcMoneyWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPPERLIMITPRICERF"));
            salesProcMoneyWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));
            // 2007.08.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #endregion

            return salesProcMoneyWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.22</br>
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
