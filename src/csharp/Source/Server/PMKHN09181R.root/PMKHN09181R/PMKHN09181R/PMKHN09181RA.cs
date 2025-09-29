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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 端末管理マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 端末管理マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    [Serializable]
    public class PosTerminalMgDB : RemoteDB, IPosTerminalMgDB
    {
        /// <summary>
        /// 端末管理マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public PosTerminalMgDB()
            :
            base("PMKHN09174D", "Broadleaf.Application.Remoting.ParamData.posTerminalMgWork", "POSTERMINALMGRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の端末管理マスタ情報LISTを戻します
        /// </summary>
        /// <param name="posTerminalMgWork">検索結果</param>
        /// <param name="paraposTerminalMgWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Search(out object posTerminalMgWork, object paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            posTerminalMgWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPosTerminalMgProc(out posTerminalMgWork, paraposTerminalMgWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PosTerminalMgDB.Search");
                posTerminalMgWork = new ArrayList();
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
        /// 指定された条件の端末管理マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objsposTerminalMgWork">検索結果</param>
        /// <param name="paraposTerminalMgWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchPosTerminalMgProc(out object objsposTerminalMgWork, object paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            PosTerminalMgServerWork posTerminalMgWork = null; 

            ArrayList posTerminalMgWorkList = paraposTerminalMgWork as ArrayList;
            if (posTerminalMgWorkList == null)
            {
                posTerminalMgWork = paraposTerminalMgWork as PosTerminalMgServerWork;
            }
            else
            {
                if (posTerminalMgWorkList.Count > 0)
                    posTerminalMgWork = posTerminalMgWorkList[0] as PosTerminalMgServerWork;
            }

            int status = SearchPosTerminalMgProc(out posTerminalMgWorkList, posTerminalMgWork, readMode, logicalMode, ref sqlConnection);
            objsposTerminalMgWork = posTerminalMgWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">検索結果</param>
        /// <param name="posTerminalMgWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int SearchPosTerminalMgProc(out ArrayList posTerminalMgWorkList, PosTerminalMgServerWork posTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchPosTerminalMgProcProc(out posTerminalMgWorkList, posTerminalMgWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">検索結果</param>
        /// <param name="posTerminalMgWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int SearchPosTerminalMgProcProc(out ArrayList posTerminalMgWorkList, PosTerminalMgServerWork posTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CASHREGISTERNORF " + Environment.NewLine;
                selectTxt += "         ,POSPCTERMCDRF " + Environment.NewLine;
                selectTxt += "         ,USELANGUAGEDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,USECULTUREDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,MACHINEIPADDRRF " + Environment.NewLine;
                selectTxt += "         ,MACHINENAMERF " + Environment.NewLine;
                selectTxt += "  FROM POSTERMINALMGRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, posTerminalMgWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {


                    al.Add(CopyToscmPriorStWorkFromReader(ref myReader));

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

            posTerminalMgWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のSCM優先設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">scmPriorStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                PosTerminalMgServerWork posTerminalMgWork = new PosTerminalMgServerWork();

                // XMLの読み込み
                posTerminalMgWork = (PosTerminalMgServerWork)XmlByteSerializer.Deserialize(parabyte, typeof(PosTerminalMgServerWork));
                if (posTerminalMgWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref posTerminalMgWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(posTerminalMgWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PosTerminalMgDB.Read");
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
        /// 指定された条件の端末管理マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="posTerminalMgWork">posTerminalMgWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のS端末管理マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int ReadProc(ref PosTerminalMgServerWork posTerminalMgWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref posTerminalMgWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の端末管理マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="posTerminalMgWork">posTerminalMgWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の端末管理マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int ReadProcProc(ref PosTerminalMgServerWork posTerminalMgWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CASHREGISTERNORF " + Environment.NewLine;
                selectTxt += "         ,POSPCTERMCDRF " + Environment.NewLine;
                selectTxt += "         ,USELANGUAGEDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,USECULTUREDIVCDRF " + Environment.NewLine;
                selectTxt += "         ,MACHINEIPADDRRF " + Environment.NewLine;
                selectTxt += "         ,MACHINENAMERF " + Environment.NewLine;
                selectTxt += "  FROM POSTERMINALMGRF " + Environment.NewLine;
                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND CASHREGISTERNORF = @FINDCASHREGISTERNO " + Environment.NewLine;
                #endregion　

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);  // マシン番号

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // 企業コード
                    findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // マシン番号

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        posTerminalMgWork = CopyToscmPriorStWorkFromReader(ref myReader);
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
        /// 端末管理マスタ情報を登録、更新します
        /// </summary>
        /// <param name="posTerminalMgWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int Write(ref object posTerminalMgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(posTerminalMgWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WritePosTerminalMgProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                PosTerminalMgServerWork paraWork = paraList[0] as PosTerminalMgServerWork;
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                posTerminalMgWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PosTerminalMgDB.Write(ref object posTerminalMgWork)");
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
        /// 端末管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int WritePosTerminalMgProc(ref ArrayList posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WritePosTerminalMgProcProc(ref posTerminalMgWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 端末管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int WritePosTerminalMgProcProc(ref ArrayList posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (posTerminalMgWorkList != null)
                {
                    foreach (PosTerminalMgServerWork posTerminalMgWork in posTerminalMgWorkList)
                    {
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CASHREGISTERNORF = @FINDCASHREGISTERNO", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);  // マシン番号

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // 企業コード
                        findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC端末使用区分

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != posTerminalMgWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (posTerminalMgWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region UPDATE文
                            string sqlText = string.Empty;

                            sqlText += " UPDATE POSTERMINALMGRF SET  " + Environment.NewLine;
                            sqlText += " CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , CASHREGISTERNORF = @CASHREGISTERNO " + Environment.NewLine;
                            sqlText += "  , POSPCTERMCDRF = @POSPCTERMCD " + Environment.NewLine;
                            sqlText += "  , USELANGUAGEDIVCDRF = @USELANGUAGEDIVCD " + Environment.NewLine;
                            sqlText += "  , USECULTUREDIVCDRF = @USECULTUREDIVCD " + Environment.NewLine;
                            sqlText += "  , MACHINEIPADDRRF = @MACHINEIPADDR " + Environment.NewLine;
                            sqlText += "  , MACHINENAMERF = @MACHINENAME " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND CASHREGISTERNORF = @FINDCASHREGISTERNO " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // 企業コード
                            findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // マシン番号

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posTerminalMgWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (posTerminalMgWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region INSERT文
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO POSTERMINALMGRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,CASHREGISTERNORF " + Environment.NewLine;
                            sqlText += "         ,POSPCTERMCDRF " + Environment.NewLine;
                            sqlText += "         ,USELANGUAGEDIVCDRF " + Environment.NewLine;
                            sqlText += "         ,USECULTUREDIVCDRF " + Environment.NewLine;
                            sqlText += "         ,MACHINEIPADDRRF " + Environment.NewLine;
                            sqlText += "         ,MACHINENAMERF " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "         ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "         ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "         ,@CASHREGISTERNO " + Environment.NewLine;
                            sqlText += "         ,@POSPCTERMCD " + Environment.NewLine;
                            sqlText += "         ,@USELANGUAGEDIVCD " + Environment.NewLine;
                            sqlText += "         ,@USECULTUREDIVCD " + Environment.NewLine;
                            sqlText += "         ,@MACHINEIPADDR " + Environment.NewLine;
                            sqlText += "         ,@MACHINENAME " + Environment.NewLine;
                            sqlText += "  )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posTerminalMgWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);  // レジ番号
                        SqlParameter paraPosPCTermCd = sqlCommand.Parameters.Add("@POSPCTERMCD", SqlDbType.Int);  // POS/PC端末使用区分
                        SqlParameter paraUseLanguageDivCd = sqlCommand.Parameters.Add("@USELANGUAGEDIVCD", SqlDbType.NVarChar);  // 使用言語区分
                        SqlParameter paraUseCultureDivCd = sqlCommand.Parameters.Add("@USECULTUREDIVCD", SqlDbType.NVarChar);  // 使用カルチャー区分
                        SqlParameter paraMachineIpAddr = sqlCommand.Parameters.Add("@MACHINEIPADDR", SqlDbType.NVarChar);  // 端末IPアドレス
                        SqlParameter paraMachineName = sqlCommand.Parameters.Add("@MACHINENAME", SqlDbType.NVarChar);  // 端末名称
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posTerminalMgWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posTerminalMgWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(posTerminalMgWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.LogicalDeleteCode);  // 論理削除区分
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // レジ番号
                        paraPosPCTermCd.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.PosPCTermCd);  // POS/PC端末使用区分
                        paraUseLanguageDivCd.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UseLanguageDivCd);  // 使用言語区分
                        paraUseCultureDivCd.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UseCultureDivCd);  // 使用カルチャー区分
                        paraMachineIpAddr.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.MachineIpAddr);  // 端末IPアドレス
                        paraMachineName.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.MachineName);  // 端末名称
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(posTerminalMgWork);
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

            posTerminalMgWorkList = al;

            return status;
        }

        

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 端末管理マスタ情報を論理削除します
        /// </summary>
        /// <param name="posTerminalMgWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDelete(ref object posTerminalMgWork)
        {
            return LogicalDeletePosTerminalMg(ref posTerminalMgWork, 0);
        }

        /// <summary>
        /// 論理削除端末管理マスタ情報を復活します
        /// </summary>
        /// <param name="posTerminalMgWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除端末管理マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int RevivalLogicalDelete(ref object posTerminalMgWork)
        {
            return LogicalDeletePosTerminalMg(ref posTerminalMgWork, 1);
        }

        /// <summary>
        /// 端末管理マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="posTerminalMgWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeletePosTerminalMg(ref object posTerminalMgWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(posTerminalMgWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeletePosTerminalMgProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "PosTerminalMgDB.LogicalDeletePosTerminalMg :" + procModestr);

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
        /// 端末管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 端末管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int LogicalDeletePosTerminalMgProc(ref ArrayList posTerminalMgWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeletePosTerminalMgProcProc(ref posTerminalMgWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 端末管理マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM優先設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int LogicalDeletePosTerminalMgProcProc(ref ArrayList posTerminalMgWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (posTerminalMgWorkList != null)
                {
                    foreach (PosTerminalMgServerWork posTerminalMgWork in posTerminalMgWorkList)
                    {
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CASHREGISTERNORF = @FINDCASHREGISTERNO ", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);  // POS/PC端末使用区分

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // 企業コード
                        findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC端末使用区分

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != posTerminalMgWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE POSTERMINALMGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND CASHREGISTERNORF = @FINDCASHREGISTERNO ";
                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // 企業コード
                            findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC端末使用区分

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)posTerminalMgWork;
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
                            else if (logicalDelCd == 0) posTerminalMgWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else posTerminalMgWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) posTerminalMgWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(posTerminalMgWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(posTerminalMgWork);
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

            posTerminalMgWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM優先設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SCM優先設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : SCM優先設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
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

                status = DeletePosTerminalMgProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMPriorStDB.Delete");
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
        /// SCM優先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">SCM優先設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM優先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        public int DeletePosTerminalMgProc(ArrayList posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeletePosTerminalMgProcProc(posTerminalMgWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM優先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="posTerminalMgWorkList">SCM優先設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM優先設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        private int DeletePosTerminalMgProcProc(ArrayList posTerminalMgWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                foreach (PosTerminalMgServerWork posTerminalMgWork in posTerminalMgWorkList)
                {
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CASHREGISTERNORF = @FINDCASHREGISTERNO", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);  // POS/PC端末使用区分

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // 企業コード
                    findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC端末使用区分

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != posTerminalMgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM POSTERMINALMGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CASHREGISTERNORF = @FINDCASHREGISTERNO";
                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);  // 企業コード
                        findCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);  // POS/PC端末使用区分
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

	    #region [Where文作成処理]
	    /// <summary>
	    /// 検索条件文字列生成＋条件値設定
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="posTerminalMgWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>POSPCTERMCDRF
        private string MakeWhereString(ref SqlCommand sqlCommand, PosTerminalMgServerWork posTerminalMgWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(posTerminalMgWork.EnterpriseCode);

            // マシン番号
            if (posTerminalMgWork.CashRegisterNo != 0)
            {
                retstring += " AND CASHREGISTERNORF=@CASHREGISTERNO ";
                SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(posTerminalMgWork.CashRegisterNo);
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
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

		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private PosTerminalMgServerWork CopyToscmPriorStWorkFromReader(ref SqlDataReader myReader)
        {
            PosTerminalMgServerWork wkposTerminalMgWork = new PosTerminalMgServerWork();

            #region クラスへ格納
            wkposTerminalMgWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkposTerminalMgWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkposTerminalMgWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkposTerminalMgWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkposTerminalMgWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkposTerminalMgWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkposTerminalMgWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkposTerminalMgWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkposTerminalMgWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));  // レジ番号
            wkposTerminalMgWork.PosPCTermCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSPCTERMCDRF"));  // POS/PC端末使用区分
            wkposTerminalMgWork.UseLanguageDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USELANGUAGEDIVCDRF"));  // 使用言語区分
            wkposTerminalMgWork.UseCultureDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USECULTUREDIVCDRF"));  // 使用カルチャー区分
            wkposTerminalMgWork.MachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINEIPADDRRF"));  // 端末IPアドレス
            wkposTerminalMgWork.MachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINENAMERF"));  // 端末名称
            #endregion

            return wkposTerminalMgWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            PosTerminalMgServerWork[] posTerminalMgWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is PosTerminalMgServerWork)
                    {
                        PosTerminalMgServerWork wkposTerminalMgWork = paraobj as PosTerminalMgServerWork;
                        if (wkposTerminalMgWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkposTerminalMgWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            posTerminalMgWorkArray = (PosTerminalMgServerWork[])XmlByteSerializer.Deserialize(byteArray, typeof(PosTerminalMgServerWork[]));
                        }
                        catch (Exception) { }
                        if (posTerminalMgWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(posTerminalMgWorkArray);
                        }
                        else
                        {
                            try
                            {
                                PosTerminalMgServerWork wkposTerminalMgWork = (PosTerminalMgServerWork)XmlByteSerializer.Deserialize(byteArray, typeof(PosTerminalMgServerWork));
                                if (wkposTerminalMgWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkposTerminalMgWork);
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
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
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
