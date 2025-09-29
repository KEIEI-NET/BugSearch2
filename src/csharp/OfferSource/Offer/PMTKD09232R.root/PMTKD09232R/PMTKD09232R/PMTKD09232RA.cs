//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : レコメンド商品関連設定マスタ（提供）
// プログラム概要   : レコメンド商品関連設定マスタ（提供）DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 作 成 日  2015.02.06  修正内容 : 新規作成
//----------------------------------------------------------------------------//

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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// レコメンド商品関連設定マスタ（提供）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : レコメンド商品関連設定マスタ（提供）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 西 毅</br>
    /// <br>Date       : 2015.02.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RecGoodsLkODB : RemoteDB, IRecGoodsLkODB
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public RecGoodsLkODB() : base("PMTKD09234D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkOWork", "RecGoodsLkORF")
        {
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [トランザクション生成処理]
        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction生成処理</br>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //トランザクション生成処理

        #region IRecGoodsLkODB メンバ

        /// <summary>
        /// レコメンド商品関連設定マスタ（提供）検索処理
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">レコメンド商品関連設定マスタ（提供）データリスト</param>
        /// <param name="parseRecGoodsLkOWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public int Search(out object RecGoodsLkOWorkList, RecGoodsLkOWork parseRecGoodsLkOWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            RecGoodsLkOWorkList = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out RecGoodsLkOWorkList, parseRecGoodsLkOWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkODB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// レコメンド商品関連設定マスタ（提供）検索処理
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">レコメンド商品関連設定マスタ（提供）データリスト</param>
        /// <param name="parseRecGoodsLkOWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public int SearchProc(out object RecGoodsLkOWorkList, RecGoodsLkOWork parseRecGoodsLkOWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkOWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT OFFERDATERF").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF").Append(Environment.NewLine);
                sqlTxt.Append("      FROM RECGOODSLKORF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromSearch(myReader, out al);

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkODB.SearchProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }


            RecGoodsLkOWorkList = al;

            return status;
        }

        /// <summary>
        /// レコメンド商品関連設定マスタ（提供）検索処理
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">レコメンド商品関連設定マスタ（提供）データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public int Read(ref object RecGoodsLkOWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref RecGoodsLkOWorkList, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkODB.Read");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// レコメンド商品関連設定マスタ（提供）検索処理
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">レコメンド商品関連設定マスタ（提供）データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        public int ReadProc(ref object RecGoodsLkOWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            RecGoodsLkOWork wkRecGoodsLkOWorkOld = null;
            RecGoodsLkOWork wkRecGoodsLkOWorkNew = null;
            ArrayList alOld = new ArrayList();
            if (RecGoodsLkOWorkList != null)
            {
                wkRecGoodsLkOWorkOld = RecGoodsLkOWorkList as RecGoodsLkOWork;
            }
            else
            {
                return status;
            }
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkOWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT OFFERDATERF").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF").Append(Environment.NewLine);
                sqlTxt.Append("      FROM RECGOODSLKORF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     RECSOURCEBLGOODSCDRF=@RECSOURCEBLGOODSCD ").Append(Environment.NewLine);
                sqlTxt.Append("     RECDESTBLGOODSCDRF=@RECDESTBLGOODSCD ").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();

                //Prameterオブジェクトの作成
                SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCD", SqlDbType.NChar);
                SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@RECDESTBLGOODSCD", SqlDbType.NChar);
                
                //KEYコマンドを再設定
                findParaRecSourceBLGoodsCd.Value = wkRecGoodsLkOWorkOld.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = wkRecGoodsLkOWorkOld.RecDestBLGoodsCd;
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromRead(myReader, ref wkRecGoodsLkOWorkNew);
                if (wkRecGoodsLkOWorkNew == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkODB.ReadProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }


            RecGoodsLkOWorkList = wkRecGoodsLkOWorkNew;

            return status;
        }

        #endregion

        #region 内部処理
        /// <summary>
        /// レコメンド商品関連設定マスタ（提供）取得処理
        /// </summary>
        /// <param name="myReader">レコメンド商品関連設定マスタ（提供）データReader</param>
        /// <param name="RecGoodsLkOWorkList">レコメンド商品関連設定マスタ（提供）データリスト</param>
        /// <returns>レコメンド商品関連設定マスタ（提供）データ</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        private int CopyListFromSearch(SqlDataReader myReader, out ArrayList RecGoodsLkOWorkList)
        {
            RecGoodsLkOWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //提供日付
            int colIndex_OfferDate = 0;
            //推奨元BL商品コード
            int colIndex_RecSourceBLGoodsCd = 0;
            //推奨先BL商品コード
            int colIndex_RecDestBLGoodsCd = 0;
            //商品コメント
            int colIndex_GoodsComment = 0;
            if (myReader.HasRows)
            {
                //提供日付
                colIndex_OfferDate = myReader.GetOrdinal("OFFERDATERF");
                //推奨元BL商品コード
                colIndex_RecSourceBLGoodsCd = myReader.GetOrdinal("RECSOURCEBLGOODSCDRF");
                //推奨先BL商品コード
                colIndex_RecDestBLGoodsCd = myReader.GetOrdinal("RECDESTBLGOODSCDRF");
                //商品コメント
                colIndex_GoodsComment = myReader.GetOrdinal("GOODSCOMMENTRF");
            }
            while (myReader.Read())
            {

                RecGoodsLkOWork RecGoodsLkOWork = new RecGoodsLkOWork();
                //提供日付
                RecGoodsLkOWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_OfferDate);
                //推奨元BL商品コード
                RecGoodsLkOWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecSourceBLGoodsCd);
                //推奨先BL商品コード
                RecGoodsLkOWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecDestBLGoodsCd);
                //商品コメント
                RecGoodsLkOWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsComment);

                RecGoodsLkOWorkList.Add(RecGoodsLkOWork);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// レコメンド商品関連設定マスタ（提供）データ取得処理
        /// </summary>
        /// <param name="myReader">レコメンド商品関連設定マスタ（提供）データReader</param>
        /// <param name="RecGoodsLkOWork">レコメンド商品関連設定マスタ（提供）データ</param>
        /// <returns>レコメンド商品関連設定マスタ（提供）データ</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.02.06</br>
        /// </remarks>
        private int CopyListFromRead(SqlDataReader myReader, ref RecGoodsLkOWork RecGoodsLkOWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //提供日付
            int colIndex_OfferDate = 0;
            //推奨元BL商品コード
            int colIndex_RecSourceBLGoodsCd = 0;
            //推奨先BL商品コード
            int colIndex_RecDestBLGoodsCd = 0;
            //商品コメント
            int colIndex_GoodsComment = 0;
            if (myReader.HasRows)
            {
                RecGoodsLkOWork = new RecGoodsLkOWork();
                //提供日付
                colIndex_OfferDate = myReader.GetOrdinal("OFFERDATERF");
                //推奨元BL商品コード
                colIndex_RecSourceBLGoodsCd = myReader.GetOrdinal("RECSOURCEBLGOODSCDRF");
                //推奨先BL商品コード
                colIndex_RecDestBLGoodsCd = myReader.GetOrdinal("RECDESTBLGOODSCDRF");
                //商品コメント
                colIndex_GoodsComment = myReader.GetOrdinal("GOODSCOMMENTRF");

            }
            if(myReader.Read())
            {

                //提供日付
                RecGoodsLkOWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_OfferDate);
                //推奨元BL商品コード
                RecGoodsLkOWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecSourceBLGoodsCd);
                //推奨先BL商品コード
                RecGoodsLkOWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecDestBLGoodsCd);
                //商品コメント
                RecGoodsLkOWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsComment);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }


        #endregion

    }
}
