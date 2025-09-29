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
    /// 商品セットマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品セットマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.04.27</br>
    /// <br></br>
    /// <br>Update Note: 20081 疋田 勇人</br>
    /// <br>           : 2007.09.26 DC.NS用に変更</br>
    /// <br>Update Note: 2008.06.09 22008 長内 数馬</br>
    /// </remarks>
    [Serializable]
    public class GoodsSetDB : RemoteDB, IGoodsSetDB, IGetSyncdataList
    {
        /// <summary>
        /// 商品セットマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        /// </remarks>
        public GoodsSetDB()
            :
            base("MAKHN09626D", "Broadleaf.Application.Remoting.ParamData.GoodsSetWork", "GOODSSETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の商品セットマスタ情報LISTを戻します
        /// </summary>
        /// <param name="goodsSetWork">検索結果</param>
        /// <param name="paragoodsSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタ情報LISTを戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int Search(out object goodsSetWork, object paragoodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsSetWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsSetProc(out goodsSetWork, paragoodsSetWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetDB.Search");
                goodsSetWork = new ArrayList();
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
        /// 指定された条件の商品セットマスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objgoodsSetWork">検索結果</param>
        /// <param name="paragoodsSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int SearchGoodsSetProc(out object objgoodsSetWork, object paragoodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsSetWork goodsSetWork = null;

            ArrayList goodsSetWorkList = paragoodsSetWork as ArrayList;
            if (goodsSetWorkList == null)
            {
                goodsSetWork = paragoodsSetWork as GoodsSetWork;
            }
            else
            {
                if (goodsSetWorkList.Count > 0)
                    goodsSetWork = goodsSetWorkList[0] as GoodsSetWork;
            }

            int status = SearchGoodsSetProc(out goodsSetWorkList, goodsSetWork, readMode, logicalMode, ref sqlConnection);
            objgoodsSetWork = goodsSetWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の商品セットマスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">検索結果</param>
        /// <param name="goodsSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int SearchGoodsSetProc(out ArrayList goodsSetWorkList, GoodsSetWork goodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return SearchGoodsSetProc(out goodsSetWorkList, goodsSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の商品セットマスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">検索結果</param>
        /// <param name="goodsSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int SearchGoodsSetProc(out ArrayList goodsSetWorkList, GoodsSetWork goodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchGoodsSetProcProc(out goodsSetWorkList, goodsSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の商品セットマスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">検索結果</param>
        /// <param name="goodsSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        private int SearchGoodsSetProcProc( out ArrayList goodsSetWorkList, GoodsSetWork goodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   GSET.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GSET.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,GSET.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,GSET.PARENTGOODSNORF" + Environment.NewLine;
                sqlText += "  ,GSET.SUBGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,GSET.SUBGOODSNORF" + Environment.NewLine;
                sqlText += "  ,GSET.CNTFLRF" + Environment.NewLine;
                sqlText += "  ,GSET.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += "  ,GSET.SETSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GSET.CATALOGSHAPENORF" + Environment.NewLine;
                sqlText += "  ,GOODSP.GOODSNAMERF AS PARENTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS SUBGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERP.MAKERNAMERF AS PARENTMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS SUBMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM GOODSSETRF AS GSET" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSP" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=GOODSP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSNORF=GOODSP.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSMAKERCDRF=GOODSP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSP.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSNORF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSMAKERCDRF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERP" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=MAKERP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSMAKERCDRF=MAKERP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERP.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSMAKERCDRF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERS.LOGICALDELETECODERF=0" + Environment.NewLine;
                
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsSetWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsSetWorkFromReader(ref myReader,0));

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

            goodsSetWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の商品セットマスタを戻します
        /// </summary>
        /// <param name="parabyte">GoodsSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタを戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsSetWork goodsSetWork = new GoodsSetWork();

                // XMLの読み込み
                goodsSetWork = (GoodsSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsSetWork));
                if (goodsSetWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsSetWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(goodsSetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetDB.Read");
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
        /// 指定された条件の商品セットマスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int ReadProc(ref GoodsSetWork goodsSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadProc(ref goodsSetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の商品セットマスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int ReadProc(ref GoodsSetWork goodsSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref goodsSetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の商品セットマスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品セットマスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        private int ReadProcProc( ref GoodsSetWork goodsSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   GSET.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,GSET.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,GSET.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,GSET.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,GSET.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,GSET.PARENTGOODSNORF" + Environment.NewLine;
                sqlText += "  ,GSET.SUBGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,GSET.SUBGOODSNORF" + Environment.NewLine;
                sqlText += "  ,GSET.CNTFLRF" + Environment.NewLine;
                sqlText += "  ,GSET.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += "  ,GSET.SETSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GSET.CATALOGSHAPENORF" + Environment.NewLine;
                sqlText += "  ,GOODSP.GOODSNAMERF AS PARENTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS SUBGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERP.MAKERNAMERF AS PARENTMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS SUBMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM GOODSSETRF AS GSET" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSP" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=GOODSP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSNORF=GOODSP.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSMAKERCDRF=GOODSP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSNORF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSMAKERCDRF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERP" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=MAKERP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.PARENTGOODSMAKERCDRF=MAKERP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     GSET.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND GSET.SUBGOODSMAKERCDRF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " WHERE GSET.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GSET.PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GSET.PARENTGOODSNORF=@FINDPARENTGOODSNO" + Environment.NewLine;
                sqlText += "  AND GSET.SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GSET.SUBGOODSNORF=@FINDSUBGOODSNO" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection)) // 2007.09.26 hikita ADD
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                    findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                    findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                    findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                    findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        goodsSetWork = CopyToGoodsSetWorkFromReader(ref myReader,0);
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
        /// 商品セットマスタ情報を登録、更新します
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を登録、更新します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int Write(ref object goodsSetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(goodsSetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteGoodsSetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                goodsSetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetDB.Write(ref object goodsSetWork)");
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
        /// <br>商品セットマスタ情報を登録、更新します</br>
        /// <br>同一商品セットコードのデータをいったんDELETEし、新規で内容を登録します</br>
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="parentGoodsMakerCd">親メーカーコード</param>
        /// <param name="parentGoodsNo">親商品セットコード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を登録、更新します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.11</br>
        //public int Write(ref object goodsSetWork, string enterpriseCode, string goodsSetCode)  // 2007.09.26 hikita del
        public int Write(ref object goodsSetWork, string enterpriseCode, Int32 parentGoodsMakerCd, string parentGoodsNo)  // 2007.09.26 hikita add
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(goodsSetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //DELETE & INSERT でWrite実行
                status = DeleteInsert(ref paraList, enterpriseCode, parentGoodsMakerCd, parentGoodsNo, ref sqlConnection, ref sqlTransaction);  // 2007.09.26 hikita add

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    status = WriteGoodsSetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                goodsSetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsSetDB.Write(ref object goodsSetWork)");
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
        /// 商品セットマスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int WriteGoodsSetProc(ref ArrayList goodsSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteGoodsSetProcProc(ref goodsSetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品セットマスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        private int WriteGoodsSetProcProc( ref ArrayList goodsSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (goodsSetWorkList != null)
                {
                    for (int i = 0; i < goodsSetWorkList.Count; i++)
                    {
                        GoodsSetWork goodsSetWork = goodsSetWorkList[i] as GoodsSetWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO", sqlConnection, sqlTransaction); // 2007.09.26 hikita ADD

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != goodsSetWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (goodsSetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE GOODSSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , PARENTGOODSMAKERCDRF=@PARENTGOODSMAKERCD , PARENTGOODSNORF=@PARENTGOODSNO , SUBGOODSMAKERCDRF=@SUBGOODSMAKERCD , SUBGOODSNORF=@SUBGOODSNO , CNTFLRF=@CNTFL , DISPLAYORDERRF=@DISPLAYORDER , SETSPECIALNOTERF=@SETSPECIALNOTE , CATALOGSHAPENORF=@CATALOGSHAPENO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO"; // 2007.09.26 hikita add

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                            findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                            findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                            findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                            findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (goodsSetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO GOODSSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PARENTGOODSMAKERCDRF, PARENTGOODSNORF, SUBGOODSMAKERCDRF, SUBGOODSNORF, CNTFLRF, DISPLAYORDERRF, SETSPECIALNOTERF, CATALOGSHAPENORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PARENTGOODSMAKERCD, @PARENTGOODSNO, @SUBGOODSMAKERCD, @SUBGOODSNO, @CNTFL, @DISPLAYORDER, @SETSPECIALNOTE, @CATALOGSHAPENO)"; // 2007.09.26 hikita add

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsSetWork;
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
                        SqlParameter paraParentGoodsMakerCd = sqlCommand.Parameters.Add("@PARENTGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraParentGoodsNo = sqlCommand.Parameters.Add("@PARENTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraSubGoodsMakerCd = sqlCommand.Parameters.Add("@SUBGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraSubGoodsNo = sqlCommand.Parameters.Add("@SUBGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraCntFl = sqlCommand.Parameters.Add("@CNTFL", SqlDbType.Float);
                        SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                        SqlParameter paraSetSpecialNote = sqlCommand.Parameters.Add("@SETSPECIALNOTE", SqlDbType.NVarChar);
                        SqlParameter paraCatalogShapeNo = sqlCommand.Parameters.Add("@CATALOGSHAPENO", SqlDbType.NChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.LogicalDeleteCode);
                        paraParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        paraParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        paraSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        paraSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);
                        paraCntFl.Value = SqlDataMediator.SqlSetDouble(goodsSetWork.CntFl);
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.DisplayOrder);
                        paraSetSpecialNote.Value = SqlDataMediator.SqlSetString(goodsSetWork.SetSpecialNote);
                        paraCatalogShapeNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.CatalogShapeNo);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsSetWork);
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

            goodsSetWorkList = al;

            return status;
        }

        /// <summary>
        /// 商品セットコードを指定してデータをDELETEし、その後INSERTします
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="parentGoodsMakerCd">親メーカーコード</param>
        /// <param name="parentGoodsNo">親商品セットコード</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns></returns>
        public int DeleteInsert(ref ArrayList goodsSetWorkList, string enterpriseCode, Int32 parentGoodsMakerCd, string parentGoodsNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) 
        {
            return DeleteInsertProc(ref goodsSetWorkList, enterpriseCode, parentGoodsMakerCd, parentGoodsNo, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品セットコードを指定してデータをDELETEし、その後INSERTします
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="parentGoodsMakerCd">親メーカーコード</param>
        /// <param name="parentGoodsNo">親商品セットコード</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns></returns>
        private int DeleteInsertProc(ref ArrayList goodsSetWorkList, string enterpriseCode, Int32 parentGoodsMakerCd, string parentGoodsNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)   // 2007.09.26 hikita add
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (goodsSetWorkList != null)
                {
                    sqlCommand = new SqlCommand("DELETE FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO", sqlConnection, sqlTransaction);    // 2007.09.26 hikita add


                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(parentGoodsMakerCd);
                    findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(parentGoodsNo);

                    sqlCommand.ExecuteNonQuery();

                    //新規作成時のSQL文を生成
                    sqlCommand.CommandText = "INSERT INTO GOODSSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PARENTGOODSMAKERCDRF, PARENTGOODSNORF, SUBGOODSMAKERCDRF, SUBGOODSNORF, CNTFLRF, DISPLAYORDERRF, SETSPECIALNOTERF, CATALOGSHAPENORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PARENTGOODSMAKERCD, @PARENTGOODSNO, @SUBGOODSMAKERCD, @SUBGOODSNO, @CNTFL, @DISPLAYORDER, @SETSPECIALNOTE, @CATALOGSHAPENO)"; // 2007.09.26 hikita add

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraParentGoodsMakerCd = sqlCommand.Parameters.Add("@PARENTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraParentGoodsNo = sqlCommand.Parameters.Add("@PARENTGOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraSubGoodsMakerCd = sqlCommand.Parameters.Add("@SUBGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraSubGoodsNo = sqlCommand.Parameters.Add("@SUBGOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraCntFl = sqlCommand.Parameters.Add("@CNTFL", SqlDbType.Float);
                    SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                    SqlParameter paraSetSpecialNote = sqlCommand.Parameters.Add("@SETSPECIALNOTE", SqlDbType.NVarChar);
                    SqlParameter paraCatalogShapeNo = sqlCommand.Parameters.Add("@CATALOGSHAPENO", SqlDbType.NChar);
                    #endregion

                    for (int i = 0; i < goodsSetWorkList.Count; i++)
                    {
                        GoodsSetWork goodsSetWork = goodsSetWorkList[i] as GoodsSetWork;

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsSetWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.LogicalDeleteCode);
                        paraParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        paraParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        paraSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        paraSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);
                        paraCntFl.Value = SqlDataMediator.SqlSetDouble(goodsSetWork.CntFl);
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.DisplayOrder);
                        paraSetSpecialNote.Value = SqlDataMediator.SqlSetString(goodsSetWork.SetSpecialNote);
                        paraCatalogShapeNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.CatalogShapeNo);                        
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsSetWork);
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
        /// 商品セットマスタ情報を論理削除します
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報を論理削除します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int LogicalDelete(ref object goodsSetWork)
        {
            return LogicalDeleteGoodsSet(ref goodsSetWork, 0);
        }

        /// <summary>
        /// 論理削除商品セットマスタ情報を復活します
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除商品セットマスタ情報を復活します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int RevivalLogicalDelete(ref object goodsSetWork)
        {
            return LogicalDeleteGoodsSet(ref goodsSetWork, 1);
        }

        /// <summary>
        /// 商品セットマスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        private int LogicalDeleteGoodsSet(ref object goodsSetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(goodsSetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsSetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GoodsSetDB.LogicalDeleteGoodsSet :" + procModestr);

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
        /// 商品セットマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int LogicalDeleteGoodsSetProc(ref ArrayList goodsSetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteGoodsSetProcProc(ref goodsSetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品セットマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        private int LogicalDeleteGoodsSetProcProc( ref ArrayList goodsSetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (goodsSetWorkList != null)
                {
                    for (int i = 0; i < goodsSetWorkList.Count; i++)
                    {
                        GoodsSetWork goodsSetWork = goodsSetWorkList[i] as GoodsSetWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO", sqlConnection, sqlTransaction); // 2007.09.26 hikita add

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != goodsSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE GOODSSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO"; // 2007.09.26 hikita add

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                            findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                            findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                            findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                            findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsSetWork;
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
                            else if (logicalDelCd == 0) goodsSetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else goodsSetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) goodsSetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;      //既に復活している場合はそのまま正常を戻す
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsSetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsSetWork);
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

            goodsSetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 商品セットマスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">商品セットマスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 商品セットマスタ情報を物理削除します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
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

                status = DeleteGoodsSetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsSetDB.Delete");
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
        /// 商品セットマスタ情報を物理削除します(外部からのSqlConnection＆SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">商品セットマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 商品セットマスタ情報を物理削除します(外部からのSqlConnection＆SqlTranactionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        public int DeleteGoodsSetProc(ArrayList goodsSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsSetProcProc(goodsSetWorkList, ref sqlConnection, ref sqlTransaction);
        }
        
        /// <summary>
        /// 商品セットマスタ情報を物理削除します(外部からのSqlConnection＆SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsSetWorkList">商品セットマスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 商品セットマスタ情報を物理削除します(外部からのSqlConnection＆SqlTranactionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        private int DeleteGoodsSetProcProc(ArrayList goodsSetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < goodsSetWorkList.Count; i++)
                {
                    GoodsSetWork goodsSetWork = goodsSetWorkList[i] as GoodsSetWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO", sqlConnection, sqlTransaction); // 2007.09.26 hikita add

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                    findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                    findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                    findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                    findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != goodsSetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO AND SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD AND SUBGOODSNORF=@FINDSUBGOODSNO"; // 2007.09.26 hikita add

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                        findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                        findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
                        findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                        findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);
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
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

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
        private int GetSyncdataListProc( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM GOODSSETRF ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToGoodsSetWorkFromReader(ref myReader ,1));
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
        /// <param name="goodsSetWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsSetWork goodsSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //企業コード
            retstring.Append("GSET.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND GSET.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND GSET.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //親メーカーコード
            if (IsValidParameter(goodsSetWork.ParentGoodsMakerCd))
            {
                retstring.Append("AND GSET.PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD ");
                SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
            }
            //親商品コード
            if (IsValidParameter(goodsSetWork.ParentGoodsNo))
            {
                retstring.Append("AND GSET.PARENTGOODSNORF=@FINDPARENTGOODSNO ");
                SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                findParaParentGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.ParentGoodsNo);
            }
            //子メーカーコード
            if (IsValidParameter(goodsSetWork.SubGoodsMakerCd))
            {
                retstring.Append("AND GSET.SUBGOODSMAKERCDRF=@FINDSUBGOODSMAKERCD ");
                SqlParameter findSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                findSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
            }
            //子商品コード
            if (IsValidParameter(goodsSetWork.SubGoodsNo))
            {
                retstring.Append("AND GSET.SUBGOODSNORF=@FINDSUBGOODSNO ");
                SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);
                findParaSubGoodsNo.Value = SqlDataMediator.SqlSetString(goodsSetWork.SubGoodsNo);
            }
            //ORDER BY
            retstring.Append("ORDER BY GSET.ENTERPRISECODERF, GSET.DISPLAYORDERRF, GSET.PARENTGOODSMAKERCDRF, GSET.PARENTGOODSNORF, GSET.SUBGOODSMAKERCDRF, GSET.SUBGOODSNORF");

            return retstring.ToString();
        }

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

        /// <summary>
        /// stringが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter(string value)
        {
            return !String.IsNullOrEmpty(value);
        }
        /// <summary>
        /// intが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter(int value)
        {
            return value != 0;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">モード</param>
        /// <returns>GoodsSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        /// </remarks>
        private GoodsSetWork CopyToGoodsSetWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            GoodsSetWork wkGoodsSetWork = new GoodsSetWork();

            #region クラスへ格納
            wkGoodsSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
            wkGoodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
            wkGoodsSetWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
            wkGoodsSetWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
            wkGoodsSetWork.CntFl        = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
            wkGoodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsSetWork.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
            wkGoodsSetWork.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));
            #endregion

            if (mode == 0)
            {
                //シンク以外の場合は商品、メーカー名称をセット
                wkGoodsSetWork.ParentGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNAMERF"));
                wkGoodsSetWork.SubGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNAMERF"));
                wkGoodsSetWork.ParentMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTMAKERNAMERF"));
                wkGoodsSetWork.SubMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBMAKERNAMERF"));
            }

            return wkGoodsSetWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsSetWork[] GoodsSetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is GoodsSetWork)
                    {
                        GoodsSetWork wkGoodsSetWork = paraobj as GoodsSetWork;
                        if (wkGoodsSetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsSetWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsSetWorkArray = (GoodsSetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsSetWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsSetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsSetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsSetWork wkGoodsSetWork = (GoodsSetWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsSetWork));
                                if (wkGoodsSetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsSetWork);
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
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.27</br>
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
