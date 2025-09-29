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
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 品番変換マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 品番変換マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2014/12/23</br>
    /// </remarks>
    [Serializable]
    public class GoodsNoChangeDB : RemoteDB, IGoodsNoChangeDB, IGetSyncdataList
    {
        /// <summary>
        /// 品番変換マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public GoodsNoChangeDB()
            :
            base("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork", "GOODSNOCHANGERF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の品番変換マスタ情報LISTを戻します
        /// </summary>
        /// <param name="goodsNoChangeWork">検索結果</param>
        /// <param name="paragoodsNoChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタ情報LISTを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int Search(out object goodsNoChangeWork, object paragoodsNoChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsNoChangeWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsNoChangeProc(out goodsNoChangeWork, paragoodsNoChangeWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsNoChangeDB.Search");
                goodsNoChangeWork = new ArrayList();
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
        /// 指定された条件の品番変換マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objgoodsNoChangeWork">検索結果</param>
        /// <param name="paragoodsNoChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int SearchGoodsNoChangeProc(out object objgoodsNoChangeWork, object paragoodsNoChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsNoChangeWork goodsNoChangeWork = null;

            ArrayList goodsNoChangeWorkList = paragoodsNoChangeWork as ArrayList;
            if (goodsNoChangeWorkList == null)
            {
                goodsNoChangeWork = paragoodsNoChangeWork as GoodsNoChangeWork;
            }
            else
            {
                if (goodsNoChangeWorkList.Count > 0)
                    goodsNoChangeWork = goodsNoChangeWorkList[0] as GoodsNoChangeWork;
            }

            int status = SearchGoodsNoChangeProcProc(out goodsNoChangeWorkList, goodsNoChangeWork, readMode, logicalMode, ref sqlConnection);
            objgoodsNoChangeWork = goodsNoChangeWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の品番変換マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">検索結果</param>
        /// <param name="goodsNoChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int SearchGoodsNoChange(out ArrayList goodsNoChangeWorkList, GoodsNoChangeWork goodsNoChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsNoChangeWorkList = new ArrayList();
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchGoodsNoChangeProcProc(out goodsNoChangeWorkList, goodsNoChangeWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsNoChangeDB.SearchGoodsNoChange");
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
        /// 指定された条件の品番変換マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">検索結果</param>
        /// <param name="goodsNoChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        private int SearchGoodsNoChangeProcProc(out ArrayList goodsNoChangeWorkList, GoodsNoChangeWork goodsNoChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand(string.Empty, sqlConnection);
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT " + Environment.NewLine
                        + " GDSCHG.CREATEDATETIMERF " + Environment.NewLine
                        + ",GDSCHG.UPDATEDATETIMERF " + Environment.NewLine
                        + ",GDSCHG.ENTERPRISECODERF " + Environment.NewLine
                        + ",GDSCHG.FILEHEADERGUIDRF " + Environment.NewLine
                        + ",GDSCHG.UPDEMPLOYEECODERF " + Environment.NewLine
                        + ",GDSCHG.UPDASSEMBLYID1RF " + Environment.NewLine
                        + ",GDSCHG.UPDASSEMBLYID2RF " + Environment.NewLine
                        + ",GDSCHG.LOGICALDELETECODERF " + Environment.NewLine
                        + ",GDSCHG.CHGSRCGOODSNORF " + Environment.NewLine
                        + ",GDSCHG.CHGDESTGOODSNORF " + Environment.NewLine
                        + ",GDSCHG.GOODSMAKERCDRF " + Environment.NewLine
                        + ",MAKER.MAKERNAMERF " + Environment.NewLine
                        + " FROM GOODSNOCHANGERF GDSCHG WITH(READUNCOMMITTED) " + Environment.NewLine
                        + " LEFT JOIN MAKERURF MAKER WITH(READUNCOMMITTED) " + Environment.NewLine
                        + "   ON MAKER.ENTERPRISECODERF = GDSCHG.ENTERPRISECODERF " + Environment.NewLine
                        + "   AND MAKER.GOODSMAKERCDRF = GDSCHG.GOODSMAKERCDRF " + Environment.NewLine
                        + " WHERE GDSCHG.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine);
                sqlCommand.CommandText = sb.ToString();
                
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);

                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToGoodsNoChangeWorkFromReader(ref myReader));

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

            goodsNoChangeWorkList = al;

            return status;
        }

        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の品番変換マスタを戻します
        /// </summary>
        /// <param name="parabyte">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタを戻します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();

                // XMLの読み込み
                goodsNoChangeWork = (GoodsNoChangeWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsNoChangeWork));
                if (goodsNoChangeWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsNoChangeWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(goodsNoChangeWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsNoChangeDB.Read");
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
        /// 指定された条件の品番変換マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int ReadProc(ref GoodsNoChangeWork goodsNoChangeWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref goodsNoChangeWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の品番変換マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWork"></param>
        /// <param name="readMode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int ReadProc(ref GoodsNoChangeWork goodsNoChangeWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProcProc( ref goodsNoChangeWork, readMode, ref sqlConnection, ref sqlTransaction );
        }

        /// <summary>
        /// 指定された条件の品番変換マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// <br></br>
        private int ReadProcProc( ref GoodsNoChangeWork goodsNoChangeWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // SELECT
                string sqlTxt = GetSqlTextForRead();
                
                // 変更点①：トランザクションを渡す
                sqlCommand = new SqlCommand( sqlTxt, sqlConnection, sqlTransaction );

                // SetParam
                SetParamForRead( ref sqlCommand, goodsNoChangeWork );

                // 変更点②：コネクションをクローズしない
                myReader = sqlCommand.ExecuteReader();
                if ( myReader.Read() )
                {
                    goodsNoChangeWork = CopyToGoodsNoChangeWorkFromReader( ref myReader );
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
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

            return status;
        }

        /// <summary>
        /// 指定された条件の品番変換マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の品番変換マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        private int ReadProcProc(ref GoodsNoChangeWork goodsNoChangeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // SELECT
                string sqlTxt = GetSqlTextForRead();
                
                sqlCommand = new SqlCommand( sqlTxt, sqlConnection );

                // SetParam
                SetParamForRead( ref sqlCommand, goodsNoChangeWork );

                myReader = sqlCommand.ExecuteReader( CommandBehavior.CloseConnection );
                if ( myReader.Read() )
                {
                    goodsNoChangeWork = CopyToGoodsNoChangeWorkFromReader( ref myReader );
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
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

            return status;
        }

        /// <summary>
        /// クエリ生成処理(Read用)
        /// </summary>
        /// <returns></returns>
        private string GetSqlTextForRead()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT " + Environment.NewLine
                    + " CREATEDATETIMERF " + Environment.NewLine
                    + ",UPDATEDATETIMERF " + Environment.NewLine
                    + ",ENTERPRISECODERF " + Environment.NewLine
                    + ",FILEHEADERGUIDRF " + Environment.NewLine
                    + ",UPDEMPLOYEECODERF " + Environment.NewLine
                    + ",UPDASSEMBLYID1RF " + Environment.NewLine
                    + ",UPDASSEMBLYID2RF " + Environment.NewLine
                    + ",LOGICALDELETECODERF " + Environment.NewLine
                    + ",CHGSRCGOODSNORF " + Environment.NewLine
                    + ",CHGDESTGOODSNORF " + Environment.NewLine
                    + ",GOODSMAKERCDRF " + Environment.NewLine
                    + " FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine
                    + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                    + "  AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO " + Environment.NewLine);
            return sb.ToString();
        }
        /// <summary>
        /// パラメータ設定処理(Read用)
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="goodsNoChangeWork"></param>
        private void SetParamForRead( ref SqlCommand sqlCommand, GoodsNoChangeWork goodsNoChangeWork )
        {
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            SqlParameter findParaOldGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( goodsNoChangeWork.EnterpriseCode );
            findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
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
        /// <br>Note       : 指定された条件の品番変換マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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
        /// <br>Note       : 指定された条件の品番変換マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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
                sqlTxt += "  ,CHGSRCGOODSNORF " + Environment.NewLine;
                sqlTxt += "  ,CHGDESTGOODSNORF " + Environment.NewLine;
                sqlTxt += "  ,GOODSMAKERCDRF " + Environment.NewLine;
                sqlTxt += "FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsNoChangeWorkFromReader(ref myReader));

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

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 品番変換マスタ情報を登録、更新します
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 品番変換マスタ情報を登録、更新します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int Write(ref object goodsNoChangeWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                //ArrayList paraList = CastToArrayListFromPara(goodsNoChangeWork);
                GoodsNoChangeWork goodsNoChangeWorkProc = goodsNoChangeWork as GoodsNoChangeWork;
                if (goodsNoChangeWorkProc == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteGoodsNoChangeProc(ref goodsNoChangeWorkProc, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                goodsNoChangeWork = goodsNoChangeWorkProc;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsNoChangeDB.Write");
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
        /// 品番変換マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 品番変換マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int WriteGoodsNoChangeProc(ref GoodsNoChangeWork goodsNoChangeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteGoodsNoChangeProcProc(ref goodsNoChangeWork,ref sqlConnection,ref sqlTransaction);
        }
        
        /// <summary>
        /// 品番変換マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 品番変換マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int WriteGoodsNoChangeProcProc(ref GoodsNoChangeWork goodsNoChangeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            try
            {
                string sqlTxt = "";
            
                sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT " + Environment.NewLine
                        + " UPDATEDATETIMERF " + Environment.NewLine
                        + " FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine
                        + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                        + "  AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine
                        + "  AND GOODSMAKERCDRF=@GOODSMAKERCDRF" + Environment.NewLine);

                sqlCommand.CommandText = sb.ToString();
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaOldGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaGoodsMakerCode = sqlCommand.Parameters.Add("@GOODSMAKERCDRF", SqlDbType.Int);
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                findParaGoodsMakerCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != goodsNoChangeWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (goodsNoChangeWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //既存データで更新日時違いの場合には排他
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }
                    
                    sqlTxt = "";
                    sqlTxt += "UPDATE GOODSNOCHANGERF SET " + Environment.NewLine;
                    sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME " + Environment.NewLine;
                    sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME " + Environment.NewLine;
                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID " + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE " + Environment.NewLine;
                    sqlTxt += " , CHGSRCGOODSNORF=@CHGSRCGOODSNO " + Environment.NewLine;
                    sqlTxt += " , CHGDESTGOODSNORF=@CHGDESTGOODSNO " + Environment.NewLine;
                    sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD " + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                    sqlTxt += "   AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                    sqlTxt += "   AND GOODSMAKERCDRF=@GOODSMAKERCDRF" + Environment.NewLine;
                    
                    sqlCommand.CommandText = sqlTxt;
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                    findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                    findParaGoodsMakerCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsNoChangeWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (goodsNoChangeWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }
                    
                    sqlTxt = "";
                    sqlTxt += "INSERT INTO GOODSNOCHANGERF" + Environment.NewLine;
                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += ", UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += ", ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += ", FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += ", UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += ", UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += ", UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += ", LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += ", CHGSRCGOODSNORF" + Environment.NewLine;
                    sqlTxt += ", CHGDESTGOODSNORF" + Environment.NewLine;
                    sqlTxt += ", GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += ") " + Environment.NewLine;
                    sqlTxt += "VALUES " + Environment.NewLine;
                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlTxt += ", @UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += ", @ENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += ", @FILEHEADERGUID" + Environment.NewLine;
                    sqlTxt += ", @UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += ", @UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += ", @UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += ", @LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += ", @CHGSRCGOODSNO" + Environment.NewLine;
                    sqlTxt += ", @CHGDESTGOODSNO" + Environment.NewLine;
                    sqlTxt += ", @GOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += ")" + Environment.NewLine;

                    //新規作成時のSQL文を生成
                    sqlCommand.CommandText = sqlTxt;
                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsNoChangeWork;
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
                SqlParameter paraOldGoodsNo = sqlCommand.Parameters.Add("@CHGSRCGOODSNO", SqlDbType.NVarChar);
                SqlParameter paraNewGoodsNo = sqlCommand.Parameters.Add("@CHGDESTGOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsNoChangeWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.LogicalDeleteCode);
                paraOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                // 新品番
                if (SqlDataMediator.SqlSetString(goodsNoChangeWork.NewGoodsNo) == DBNull.Value)
                {
                    paraNewGoodsNo.Value = "";
                }
                else
                {
                    paraNewGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.NewGoodsNo);
                }
                // メーカー
                if (SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd) == DBNull.Value)
                {
                    paraGoodsMakerCd.Value = 0;
                }
                else
                {
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);
                }
                #endregion

                sqlCommand.ExecuteNonQuery();

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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }        
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 品番変換マスタ情報を論理削除します
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 品番変換マスタ情報を論理削除します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int LogicalDelete(ref object goodsNoChangeWork)
        {
            return LogicalDeleteGoodsNoChange(ref goodsNoChangeWork, 0);
        }

        /// <summary>
        /// 論理削除品番変換マスタ情報を復活します
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除品番変換マスタ情報を復活します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int RevivalLogicalDelete(ref object goodsNoChangeWork)
        {
            return LogicalDeleteGoodsNoChange(ref goodsNoChangeWork, 1);
        }

        /// <summary>
        /// 品番変換マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="goodsNoChangeWork">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 品番変換マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        private int LogicalDeleteGoodsNoChange(ref object goodsNoChangeWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(goodsNoChangeWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsNoChangeProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GoodsNoChangeDB.LogicalDeleteGoodsMng :" + procModestr);

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
        /// 品番変換マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 品番変換マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int LogicalDeleteGoodsNoChangeProc(ref ArrayList goodsNoChangeWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteGoodsNoChangeProcProc(ref goodsNoChangeWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 品番変換マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">GoodsNoChangeWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 品番変換マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        private int LogicalDeleteGoodsNoChangeProcProc(ref ArrayList goodsNoChangeWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                string sqlTxt = "";

                if (goodsNoChangeWorkList != null)
                {
                    for (int i = 0; i < goodsNoChangeWorkList.Count; i++)
                    {
                        GoodsNoChangeWork goodsNoChangeWork = goodsNoChangeWorkList[i] as GoodsNoChangeWork;
                        sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);

                        StringBuilder sb = new StringBuilder();
                        sb.Append("SELECT " + Environment.NewLine
                                + " UPDATEDATETIMERF " + Environment.NewLine
                                + " ,LOGICALDELETECODERF " + Environment.NewLine
                                + " FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine
                                + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                                + "  AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine
                                + "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF" + Environment.NewLine);
                        sqlCommand.CommandText = sb.ToString();
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaOldGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsMaker = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                        findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                        findParaGoodsMaker.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != goodsNoChangeWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlTxt = "";
                            sqlTxt += "UPDATE GOODSNOCHANGERF" + Environment.NewLine;
                            sqlTxt += "SET" + Environment.NewLine;
                            sqlTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += "WHERE" + Environment.NewLine;
                            sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                            sqlTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF" + Environment.NewLine;

                            sqlCommand.CommandText = sqlTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                            findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                            findParaGoodsMaker.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsNoChangeWork;
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
                            else if (logicalDelCd == 0) goodsNoChangeWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else goodsNoChangeWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) goodsNoChangeWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsNoChangeWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsNoChangeWork);
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

            goodsNoChangeWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 品番変換マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">品番変換マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 品番変換マスタ情報を物理削除します</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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

                status = DeleteGoodsNoChangeProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsNoChangeDB.Delete");
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
        /// 品番変換マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">品番変換マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 品番変換マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        public int DeleteGoodsNoChangeProc(ArrayList goodsNoChangeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsNoChangeProcProc(goodsNoChangeWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 品番変換マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsNoChangeWorkList">品番変換マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 品番変換マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        private int DeleteGoodsNoChangeProcProc(ArrayList goodsNoChangeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string sqlTxt = "";

                for (int i = 0; i < goodsNoChangeWorkList.Count; i++)
                {
                    GoodsNoChangeWork goodsNoChangeWork = goodsNoChangeWorkList[i] as GoodsNoChangeWork;
                    sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT " + Environment.NewLine
                            + "  UPDATEDATETIMERF " + Environment.NewLine
                            + " ,LOGICALDELETECODERF " + Environment.NewLine
                            + " FROM GOODSNOCHANGERF WITH(READUNCOMMITTED) " + Environment.NewLine
                            + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                            + "  AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine
                            + "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF" + Environment.NewLine);
                    sqlCommand.CommandText = sb.ToString();
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaOldGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsMaker = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                    findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                    findParaGoodsMaker.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != goodsNoChangeWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt = "";
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += "FROM GOODSNOCHANGERF " + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO " + Environment.NewLine;
                        sqlTxt += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF" + Environment.NewLine;

                        sqlCommand.CommandText = sqlTxt;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.EnterpriseCode);
                        findParaOldGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoChangeWork.OldGoodsNo);
                        findParaGoodsMaker.Value = SqlDataMediator.SqlSetInt32(goodsNoChangeWork.GoodsMakerCd);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

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
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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
        /// クラス格納処理 Reader → GoodsNoChangeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsNoChangeWork</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private GoodsNoChangeWork CopyToGoodsNoChangeWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsNoChangeWork wkGoodsNoChangeWork = new GoodsNoChangeWork();

            #region クラスへ格納
            wkGoodsNoChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsNoChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsNoChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsNoChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsNoChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsNoChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsNoChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsNoChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsNoChangeWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
            wkGoodsNoChangeWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
            wkGoodsNoChangeWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsNoChangeWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            #endregion

            return wkGoodsNoChangeWork;
        }

        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsNoChangeWork[] GoodsNoChangeWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is GoodsNoChangeWork)
                    {
                        GoodsNoChangeWork wkGoodsNoChangeWork = paraobj as GoodsNoChangeWork;
                        if (wkGoodsNoChangeWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsNoChangeWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsNoChangeWorkArray = (GoodsNoChangeWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsNoChangeWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsNoChangeWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsNoChangeWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsNoChangeWork wkGoodsNoChangeWork = (GoodsNoChangeWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsNoChangeWork));
                                if (wkGoodsNoChangeWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsNoChangeWork);
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
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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
