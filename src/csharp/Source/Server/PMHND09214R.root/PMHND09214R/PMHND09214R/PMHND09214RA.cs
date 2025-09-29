//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード関連付け DBリモートオブジェクト
// プログラム概要   : 商品バーコード関連付けテーブルに対して各操作処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11770181-00 作成担当 : 呉元嘯
// 修 正 日  2021/11/18  修正内容 : PJMIT-1499 OUT OF MEMORY対応(4GB対応) 恒久対応
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;// ADD 2021/11/18 呉元嘯 PJMIT-1499対応

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品バーコード関連付けマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付けマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br>Update Note: 2021/11/18 呉元嘯</br>
    /// <br>管理番号   : 11770181-00</br>
    /// <br>             PJMIT-1499　OUT OF MEMORY対応(4GB対応) 恒久対応</br>
    /// </remarks>
    [Serializable]
    public class GoodsBarCodeRevnDB : RemoteDB, IGoodsBarCodeRevnDB
    {
        /// <summary>
        /// 商品バーコード関連付けスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public GoodsBarCodeRevnDB()
            :
            base("PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork", "GOODSBARCODEREVNRF")
        {
        }

        #region [検索]
        /// <summary>
        /// 指定された条件の商品バーコード関連付けマスタ情報LISTを戻します
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWork">検索結果</param>
        /// <param name="objGoodsBarCodeRevnSearchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>検索処理結果  0:正常</returns>
        /// <br>Note       : 指定された条件の商品バーコード関連付けマスタ情報LISTを戻します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        public int Search(out object objGoodsBarCodeRevnWork, object objGoodsBarCodeRevnSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            objGoodsBarCodeRevnWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out objGoodsBarCodeRevnWork, objGoodsBarCodeRevnSearchParaWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsBarCodeRevnDB.Search");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 指定された条件の商品バーコード関連付けマスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWork">検索結果</param>
        /// <param name="objGoodsBarCodeRevnSearchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>検索処理結果  0:正常</returns>
        /// <br>Note       : 指定された条件の商品バーコード関連付けマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        private int SearchProc(out object objGoodsBarCodeRevnWork, object objGoodsBarCodeRevnSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            // obj ⇒ ワーク
            GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = objGoodsBarCodeRevnSearchParaWork as GoodsBarCodeRevnSearchParaWork;

            ArrayList goodsBarCodeRevnWorkList = new ArrayList();

            int status = SearchProc(out goodsBarCodeRevnWorkList, goodsBarCodeRevnSearchParaWork, readMode, logicalMode, ref sqlConnection);
            // ワークLIST ⇒ obj
            objGoodsBarCodeRevnWork = goodsBarCodeRevnWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の商品バーコード関連付けマスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsBarCodeRevnWorkList">検索結果</param>
        /// <param name="goodsBarCodeRevnSearchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>検索処理結果  0:正常</returns>
        /// <br>Note       : 指定された条件の商品バーコード関連付けマスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        private int SearchProc(out ArrayList goodsBarCodeRevnWorkList, GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            goodsBarCodeRevnWorkList = new ArrayList();
            try
            {
                StringBuilder sqlText = new StringBuilder();

                sqlText.Append(
                    " SELECT "+
                    " CREATEDATETIMERF, " +
                    " UPDATEDATETIMERF, " +
                    " ENTERPRISECODERF, " +
                    " FILEHEADERGUIDRF, " +
                    " UPDEMPLOYEECODERF, " +
                    " UPDASSEMBLYID1RF, " +
                    " UPDASSEMBLYID2RF, " +
                    " LOGICALDELETECODERF, " +
                    " GOODSMAKERCDRF, " +
                    " GOODSNORF, " +
                    " GOODSBARCODERF, " +
                    " GOODSBARCODEKINDRF, " +
                    " CHECKDIGITCODERF, " +
                    " OFFERDATERF, " +
                    " OFFERDATADIVRF " +
                    " FROM GOODSBARCODEREVNRF WITH (READUNCOMMITTED) "
                    );

                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);
                // Where文作成処理
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsBarCodeRevnSearchParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsBarCodeRevnWorkList.Add(CopyToGoodsBarCodeRevnWorkFromReader(ref myReader));
                }
                if (goodsBarCodeRevnWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

            return status;
        }
        #endregion

        // --- ADD 2021/11/18 呉元嘯 PJMIT-1499対応 恒久対応------>>>>>
        #region [ユーザー在庫商品検索]
        /// <summary>
        /// 指定された条件のユーザー在庫商品マスタ情報LISTを戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="condObj">検索パラメータ</param>
        /// <returns>検索処理結果  0:正常</returns>
        /// <br>Note       : 指定された条件のユーザー在庫商品マスタ情報LISTを戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2021/11/18</br>
        public int SearchStockGoods(out object retObj, object condObj)
        {
            retObj = null;
            SqlConnection sqlConnection = null;
            ArrayList retList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection())
            {
                try
                {
                    if (sqlConnection == null) return status;
                    sqlConnection.Open();

                    GoodsBarCodeRevnSearchParaWork condWork = (GoodsBarCodeRevnSearchParaWork)condObj;
                    // 検索条件がnullの場合
                    if (condWork == null)
                    {
                        base.WriteErrorLog("GoodsBarCodeRevnDB.SearchStockGoods" + "カスタムシリアライザ失敗");
                        return status;
                    }
                    // ユーザー在庫商品マスタ情報取得
                    status = SearchStockGoodsProc(condWork, ref retList, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retObj = (object)retList;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "GoodsBarCodeRevnDB.SearchStockGoods Exception=" + ex.ToString(), status);
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された条件のユーザー在庫商品マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="condWork">検索パラメータ</param>
        /// <param name="retList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>検索処理結果  0:正常</returns>
        /// <br>Note       : 指定された条件のユーザー在庫商品マスタ情報LISTを戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2021/11/18</br>
        private int SearchStockGoodsProc(GoodsBarCodeRevnSearchParaWork condWork, ref ArrayList retList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    #region [Select文作成]
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine(" STOCK.GOODSNORF AS GOODSNORF, ");   // 品番
                    sqlText.AppendLine(" STOCK.GOODSMAKERCDRF AS GOODSMAKERCDRF, ");   // メーカー
                    sqlText.AppendLine(" GOODS.GOODSNAMERF AS GOODSNAMERF,");  // 品名
                    sqlText.AppendLine(" MAK.MAKERNAMERF AS MAKERNAMERF, ");    // メーカー名称
                    sqlText.AppendLine(" GOODS.OFFERDATERF AS OFFERDATERF, ");   // 提供日付
                    sqlText.AppendLine(" GOODS.OFFERDATADIVRF AS OFFERDATADIVRF ");  // 提供データ区分
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" STOCKRF STOCK ");
                    sqlText.AppendLine(" INNER JOIN GOODSURF GOODS ");
                    sqlText.AppendLine(" ON GOODS.ENTERPRISECODERF = STOCK.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND GOODS.GOODSNORF = STOCK.GOODSNORF ");
                    sqlText.AppendLine(" AND GOODS.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" AND GOODS.LOGICALDELETECODERF = STOCK.LOGICALDELETECODERF ");
                    sqlText.AppendLine(" LEFT JOIN MAKERURF MAK ");
                    sqlText.AppendLine(" ON MAK.ENTERPRISECODERF = GOODS.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND MAK.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" AND MAK.LOGICALDELETECODERF = GOODS.LOGICALDELETECODERF ");
                    // WHERE文
                    sqlText.AppendLine(MakeStockGoodsWhereString(condWork, ref sqlCommand));
                    sqlText.AppendLine(" ORDER BY GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC");

                    #endregion

                    sqlCommand.CommandText = sqlText.ToString();


                    // クエリ実行時のタイムアウト時間を600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = new GoodsBarCodeRevnWork();
                            wkGoodsBarCodeRevnWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                            wkGoodsBarCodeRevnWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                            wkGoodsBarCodeRevnWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                            wkGoodsBarCodeRevnWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                            DateTime offerDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                            int intOfferDate = 0;
                            // 提供日付あるの場合
                            if (offerDate != DateTime.MinValue) Int32.TryParse(offerDate.ToString("yyyyMMdd"), out intOfferDate);
                            wkGoodsBarCodeRevnWork.OfferDate = intOfferDate;
                            wkGoodsBarCodeRevnWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

                            retList.Add(wkGoodsBarCodeRevnWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (retList.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // 基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "SearchStockGoodsProc.SearchStockGoodsProc Exception=" + ex.ToString(), status);
                }
            }
            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定（ユーザー在庫商品マスタ）
        /// </summary>
        /// <param name="condWork">検索条件格納クラス</param>
        /// <param name="sqlCommand">コマンド</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 検索条件文字列生成＋条件値設定</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2021/11/18</br>
        /// </remarks>
        private string MakeStockGoodsWhereString(GoodsBarCodeRevnSearchParaWork condWork, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();
            sqlText.AppendLine("WHERE ");

            // 企業コード
            sqlText.AppendLine(" STOCK.ENTERPRISECODERF=@ENTERPRISECODE");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);

            // 論理削除区分
            sqlText.AppendLine(" AND STOCK.LOGICALDELETECODERF=@LOGICALDELETECODE");
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

            // 商品メーカーコード
            if (condWork.GoodsMakerCd > 0)
            {
                sqlText.AppendLine(" AND STOCK.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(condWork.GoodsMakerCd);
            }

            // 商品品番
            if (!String.IsNullOrEmpty(condWork.GoodsNo))
            {
                //ハイフン無し品番に変換
                string goodsNoNoneHyphen = condWork.GoodsNo.Replace("-", "");
                goodsNoNoneHyphen = goodsNoNoneHyphen + "%";
                sqlText.AppendLine(" AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN");
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);
            }

            // 倉庫コード
            if (!String.IsNullOrEmpty(condWork.WarehouseCode))
            {
                sqlText.AppendLine(" AND STOCK.WAREHOUSECODERF=@FINDWAREHOUSECODE");
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
            }

            // 管理拠点コード
            if (!String.IsNullOrEmpty(condWork.SectionCode))
            {
                sqlText.AppendLine(" AND STOCK.SECTIONCODERF=@FINDSECTIONCODE");
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(condWork.SectionCode);
            }

            return sqlText.ToString();
        }
        #endregion
        // --- ADD 2021/11/18 呉元嘯 PJMIT-1499対応 恒久対応------<<<<<

        #region [取込]
        /// <summary>
        /// 商品バーコード関連付けマスタ情報を登録、更新します
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWorkList">GoodsBarCodeRevnWorkオブジェクト</param>
        /// <returns>取込処理結果  0:正常</returns>
        /// <br>Note       : 商品バーコード関連付けマスタ情報を登録、更新します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        public int WriteByInput(ref object objGoodsBarCodeRevnWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(objGoodsBarCodeRevnWorkList);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteByInputProc(paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) { 
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsBarCodeRevnDB.WriteByInput(object objGoodsBarCodeRevnWorkList)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 商品バーコード関連付けマスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="goodsBarCodeRevnWorkList">GoodsBarCodeRevnWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>取込処理結果  0:正常</returns>
        /// <br>Note       : 商品バーコード関連付けマスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        private int WriteByInputProc(ArrayList goodsBarCodeRevnWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (goodsBarCodeRevnWorkList != null && goodsBarCodeRevnWorkList.Count > 0)
                {
                    for (int i = 0; i < goodsBarCodeRevnWorkList.Count; i++)
                    {
                        GoodsBarCodeRevnWork goodsBarCodeRevnWork = goodsBarCodeRevnWorkList[i] as GoodsBarCodeRevnWork;

                        StringBuilder sqlText = new StringBuilder();

                        sqlText.Append(
                            " SELECT UPDATEDATETIMERF " +
                            " FROM GOODSBARCODEREVNRF " +
                            " WHERE " +
                            " ENTERPRISECODERF=@FINDENTERPRISECODE " +
                            " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " +
                            " AND GOODSNORF=@FINDGOODSNO "
                            );

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        sqlText.Length = 0;
                        if (myReader.Read())
                        {
                            sqlText.Append(
                                " UPDATE GOODSBARCODEREVNRF " +
                                " SET " +
                                " UPDATEDATETIMERF=@UPDATEDATETIME, " +
                                " UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, " +
                                " UPDASSEMBLYID1RF=@UPDASSEMBLYID1, " +
                                " UPDASSEMBLYID2RF=@UPDASSEMBLYID2, " +
                                " GOODSMAKERCDRF=@GOODSMAKERCD, " +
                                " GOODSNORF=@GOODSNO, " +
                                " GOODSBARCODERF=@GOODSBARCODE, " +
                                " GOODSBARCODEKINDRF=@GOODSBARCODEKIND, " +
                                " CHECKDIGITCODERF=@CHECKDIGITCODE, " +
                                " OFFERDATADIVRF=@OFFERDATADIV " +
                                " WHERE " +
                                " ENTERPRISECODERF=@FINDENTERPRISECODE " +
                                " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " +
                                " AND GOODSNORF=@FINDGOODSNO "
                                );
                            sqlCommand.CommandText = sqlText.ToString();
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.EnterpriseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsBarCodeRevnWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            sqlText.Append(
                                " INSERT INTO GOODSBARCODEREVNRF " +
                                " ( CREATEDATETIMERF, " +
                                " UPDATEDATETIMERF, " +
                                " ENTERPRISECODERF, " +
                                " FILEHEADERGUIDRF, " +
                                " UPDEMPLOYEECODERF, " +
                                " UPDASSEMBLYID1RF, " +
                                " UPDASSEMBLYID2RF, " +
                                " LOGICALDELETECODERF, " +
                                " GOODSMAKERCDRF, " +
                                " GOODSNORF, " +
                                " GOODSBARCODERF, " +
                                " GOODSBARCODEKINDRF, " +
                                " CHECKDIGITCODERF, " +
                                " OFFERDATADIVRF " +
                                " ) VALUES ( " +
                                " @CREATEDATETIME, " +
                                " @UPDATEDATETIME, " +
                                " @ENTERPRISECODE, " +
                                " @FILEHEADERGUID, " +
                                " @UPDEMPLOYEECODE, " +
                                " @UPDASSEMBLYID1, " +
                                " @UPDASSEMBLYID2, " +
                                " @LOGICALDELETECODE, " +
                                " @GOODSMAKERCD, " +
                                " @GOODSNO, " +
                                " @GOODSBARCODE, " +
                                " @GOODSBARCODEKIND, " +
                                " @CHECKDIGITCODE, " +
                                " @OFFERDATADIV )"
                                );

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = sqlText.ToString();


                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsBarCodeRevnWork;
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

                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsBarCode = sqlCommand.Parameters.Add("@GOODSBARCODE", SqlDbType.NVarChar);
                        SqlParameter paraGoodsBarCodeKind = sqlCommand.Parameters.Add("@GOODSBARCODEKIND", SqlDbType.Int);
                        SqlParameter paraCheckdigitCode = sqlCommand.Parameters.Add("@CHECKDIGITCODE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsBarCodeRevnWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsBarCodeRevnWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsBarCodeRevnWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.LogicalDeleteCode);

                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsNo);
                        paraGoodsBarCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsBarCode);
                        paraGoodsBarCodeKind.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsBarCodeKind);
                        paraCheckdigitCode.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.CheckdigitCode);
                        // 提供区分: 0:ユーザデータ[固定]
                        paraOfferDataDiv.Value = 0;
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #region [保存]
        /// <summary>
        /// 商品バーコード関連付けマスタ情報を保存します
        /// </summary>
        /// <param name="objSaveWorkList">保存用データList</param>
        /// <param name="objDeleteWorkList">削除用データList</param>
        /// <returns>保存処理結果 0:正常</returns>
        /// <br>Note       : 商品バーコード関連付けマスタ情報を保存します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        public int WriteBySave(ref object objSaveWorkList,ref object objDeleteWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //保存用パラメータのキャスト
                ArrayList paraSaveList = CastToArrayListFromPara(objSaveWorkList);
                //削除用パラメータのキャスト
                ArrayList paraDeleteList = CastToArrayListFromPara(objDeleteWorkList);

                if (paraSaveList == null || paraDeleteList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //保存実行
                status = SaveWorkProc(ref paraSaveList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //削除実行
                    status = DeleteWorkProc(ref paraDeleteList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    if (sqlTransaction.Connection != null) sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                objSaveWorkList = paraSaveList;
                objDeleteWorkList = paraDeleteList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsBarCodeRevnDB.WriteBySave(ref object objSaveWorkList, ref object objDeleteWorkList)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 商品バーコード関連付けマスタ情報を保存します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="saveWorkList">保存用データList</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>保存処理結果 0:正常</returns>
        /// <br>Note       : 商品バーコード関連付けマスタ情報を保存します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        private int SaveWorkProc(ref ArrayList saveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (saveWorkList != null && saveWorkList.Count > 0)
                {
                    for (int i = 0; i < saveWorkList.Count; i++)
                    {
                        GoodsBarCodeRevnWork saveWork = saveWorkList[i] as GoodsBarCodeRevnWork;
                        
                        StringBuilder sqlText = new StringBuilder();

                        sqlText.Append(
                            " SELECT UPDATEDATETIMERF "+
                            " FROM GOODSBARCODEREVNRF "+
                            " WHERE "+
                            " ENTERPRISECODERF=@FINDENTERPRISECODE "+
                            " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD "+
                            " AND GOODSNORF=@FINDGOODSNO "
                            );

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(saveWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(saveWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(saveWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        sqlText.Length = 0;
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != saveWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (saveWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlText.Append(
                                " UPDATE GOODSBARCODEREVNRF " +
                                " SET " +
                                " UPDATEDATETIMERF=@UPDATEDATETIME, " +
                                " UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, "+
                                " UPDASSEMBLYID1RF=@UPDASSEMBLYID1, " +
                                " UPDASSEMBLYID2RF=@UPDASSEMBLYID2, " +
                                " GOODSMAKERCDRF=@GOODSMAKERCD, " +
                                " GOODSNORF=@GOODSNO, " +
                                " GOODSBARCODERF=@GOODSBARCODE, " +
                                " GOODSBARCODEKINDRF=@GOODSBARCODEKIND, " +
                                " CHECKDIGITCODERF=@CHECKDIGITCODE, " +
                                " OFFERDATADIVRF=@OFFERDATADIV "+
                                " WHERE " +
                                " ENTERPRISECODERF=@FINDENTERPRISECODE " +
                                " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " +
                                " AND GOODSNORF=@FINDGOODSNO "
                                );
                            sqlCommand.CommandText = sqlText.ToString();
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(saveWork.EnterpriseCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(saveWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(saveWork.GoodsNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)saveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (saveWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlText.Append(
                                " INSERT INTO GOODSBARCODEREVNRF " +
                                " ( CREATEDATETIMERF, "+
                                " UPDATEDATETIMERF, "+
                                " ENTERPRISECODERF, "+
                                " FILEHEADERGUIDRF, "+
                                " UPDEMPLOYEECODERF, "+
                                " UPDASSEMBLYID1RF, "+
                                " UPDASSEMBLYID2RF, "+
                                " LOGICALDELETECODERF, "+
                                " GOODSMAKERCDRF, "+
                                " GOODSNORF, "+
                                " GOODSBARCODERF, " +
                                " GOODSBARCODEKINDRF, " +
                                " CHECKDIGITCODERF, "+
                                " OFFERDATADIVRF "+
                                " ) VALUES ( "+
                                " @CREATEDATETIME, "+
                                " @UPDATEDATETIME, "+
                                " @ENTERPRISECODE, "+
                                " @FILEHEADERGUID, "+
                                " @UPDEMPLOYEECODE, "+
                                " @UPDASSEMBLYID1, "+
                                " @UPDASSEMBLYID2, "+
                                " @LOGICALDELETECODE, "+
                                " @GOODSMAKERCD, "+
                                " @GOODSNO, "+
                                " @GOODSBARCODE, " +
                                " @GOODSBARCODEKIND, " +
                                " @CHECKDIGITCODE, "+
                                " @OFFERDATADIV )"
                                );

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = sqlText.ToString();


                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)saveWork;
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

                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsBarCode = sqlCommand.Parameters.Add("@GOODSBARCODE", SqlDbType.NVarChar);
                        SqlParameter paraGoodsBarCodeKind = sqlCommand.Parameters.Add("@GOODSBARCODEKIND", SqlDbType.Int);
                        SqlParameter paraCheckdigitCode = sqlCommand.Parameters.Add("@CHECKDIGITCODE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saveWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(saveWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(saveWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(saveWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(saveWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(saveWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(saveWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(saveWork.LogicalDeleteCode);

                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(saveWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(saveWork.GoodsNo);
                        paraGoodsBarCode.Value = SqlDataMediator.SqlSetString(saveWork.GoodsBarCode);
                        paraGoodsBarCodeKind.Value = SqlDataMediator.SqlSetInt32(saveWork.GoodsBarCodeKind);
                        paraCheckdigitCode.Value = SqlDataMediator.SqlSetInt32(saveWork.CheckdigitCode);
                        // 提供区分: 0:ユーザデータ[固定]
                        paraOfferDataDiv.Value = 0;
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(saveWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            saveWorkList = al;

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ情報を削除します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="deleteWorkList">削除用データList</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>削除処理結果 0:正常</returns>
        /// <br>Note       : 商品バーコード関連付けマスタ情報を削除します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        private int DeleteWorkProc(ref ArrayList deleteWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();
            try
            {
                if (deleteWorkList != null && deleteWorkList.Count > 0)
                {
                    for (int i = 0; i < deleteWorkList.Count; i++)
                    {
                        GoodsBarCodeRevnWork deleteWork = deleteWorkList[i] as GoodsBarCodeRevnWork;
                        if (deleteWork.CreateDateTime == DateTime.MinValue) continue;

                        StringBuilder sqlText = new StringBuilder();

                        sqlText.Append(
                            " SELECT UPDATEDATETIMERF " +
                            " FROM GOODSBARCODEREVNRF " +
                            " WHERE " +
                            " ENTERPRISECODERF=@FINDENTERPRISECODE " +
                            " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " +
                            " AND GOODSNORF=@FINDGOODSNO "
                            );

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(deleteWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(deleteWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(deleteWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();
                        sqlText.Length = 0;
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != deleteWork.UpdateDateTime)
                            {
                                //既存データで更新日時違いの場合には排他
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlText.Append(
                                " DELETE " +
                                " FROM GOODSBARCODEREVNRF " +
                                " WHERE " +
                                " ENTERPRISECODERF=@ENTERPRISECODE " +
                                " AND GOODSMAKERCDRF=@GOODSMAKERCD " +
                                " AND GOODSNORF=@GOODSNO "
                                );

                            //Selectコマンドの生成
                            sqlCommand.CommandText = sqlText.ToString();

                            //Prameterオブジェクトの作成
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);

                            //Parameterオブジェクトへ値設定
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(deleteWork.EnterpriseCode);
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(deleteWork.GoodsMakerCd);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(deleteWork.GoodsNo);
                            if (myReader.IsClosed == false) myReader.Close();
                            sqlCommand.ExecuteNonQuery();
                            al.Add(deleteWork);
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            deleteWorkList = al;
            return status;
        }

        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="goodsBarCodeRevnSearchParaWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            // 企業コード
            retstring += " ENTERPRISECODERF=@FINDENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnSearchParaWork.EnterpriseCode);

            // 商品メーカーコード
            if (goodsBarCodeRevnSearchParaWork.GoodsMakerCd != 0)
            {
                retstring += " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnSearchParaWork.GoodsMakerCd);
            }

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
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

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsBarCodeRevnWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsBarCodeRevnWork</returns>
        /// <remarks>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private GoodsBarCodeRevnWork CopyToGoodsBarCodeRevnWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = new GoodsBarCodeRevnWork();

            #region クラスへ格納
            wkGoodsBarCodeRevnWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsBarCodeRevnWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsBarCodeRevnWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsBarCodeRevnWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsBarCodeRevnWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsBarCodeRevnWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsBarCodeRevnWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsBarCodeRevnWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

            wkGoodsBarCodeRevnWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsBarCodeRevnWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsBarCodeRevnWork.GoodsBarCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSBARCODERF"));
            wkGoodsBarCodeRevnWork.GoodsBarCodeKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSBARCODEKINDRF"));
            wkGoodsBarCodeRevnWork.CheckdigitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKDIGITCODERF"));
            wkGoodsBarCodeRevnWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsBarCodeRevnWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            #endregion

            return wkGoodsBarCodeRevnWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsBarCodeRevnWork[] goodsBarCodeRevnWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is GoodsBarCodeRevnWork)
                    {
                        GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = paraobj as GoodsBarCodeRevnWork;
                        if (wkGoodsBarCodeRevnWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsBarCodeRevnWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            goodsBarCodeRevnWorkArray = (GoodsBarCodeRevnWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsBarCodeRevnWork[]));
                        }
                        catch (Exception) { }
                        if (goodsBarCodeRevnWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(goodsBarCodeRevnWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsBarCodeRevnWork wkGoodsBarCodeRevnWork = (GoodsBarCodeRevnWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsBarCodeRevnWork));
                                if (wkGoodsBarCodeRevnWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsBarCodeRevnWork);
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
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
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
