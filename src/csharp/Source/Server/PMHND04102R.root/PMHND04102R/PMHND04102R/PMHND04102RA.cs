//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナル在庫情報取得(通常)リモートオブジェクト
// プログラム概要   : ハンディターミナル在庫情報取得(通常)を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : ハンディターミナル二次開発 在庫仕入（出荷・入荷）の対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 作 成 日  2019/11/13  修正内容 : ハンディ６次改良
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル在庫情報取得(通常)リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫情報取得(通常)リモートオブジェクトです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/15</br>
    /// <br>Update Note: 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// <br>管理番号   : 11370074-00</br>
    /// <br>           : ハンディターミナル二次開発 在庫仕入（出荷・入荷）の対応</br>
    /// </remarks>
    [Serializable]
    public class HandyStockDB : RemoteDB, IHandyStockDB
    {
        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナル在庫情報取得(通常)リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public HandyStockDB()
        {
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// ハンディターミナル在庫情報取得(通常)処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫情報取得(通常)を検索します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public int Search(byte[] condByte, out byte[] retByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retByte = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // sqlConnectionがnullの場合、エラーを戻ります。
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyStockCondWork condWork = (HandyStockCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyStockCondWork));
                // 検索条件がnullの場合、
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyStockDB.Search" + "カスタムシリアライザ失敗");
                    return status;
                } 

                HandyStockWork handyStockWork = null;
                status = SearchProc(condWork, out handyStockWork, ref sqlConnection);
                // 検索結果ステータスが正常の場合、
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retByte = XmlByteSerializer.Serialize(handyStockWork);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockDB.Search" + ex.Message, status);
            }
            finally
            {
                // sqlConnectionがnullではない場合、
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// ハンディターミナル在庫情報取得(通常)処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫情報取得(通常)を検索します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int SearchHandy(byte[] condByte, out object retByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retByte = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // sqlConnectionがnullの場合、エラーを戻ります。
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyStockCondWork condWork = (HandyStockCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyStockCondWork));
                // 検索条件がnullの場合、
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyStockDB.Search" + "カスタムシリアライザ失敗");
                    return status;
                }

                ArrayList handyStockWork = null;
                status = SearchHandyProc(condWork, out handyStockWork, ref sqlConnection);
                // 検索結果ステータスが正常の場合、
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retByte = handyStockWork;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockDB.Search" + ex.Message, status);
            }
            finally
            {
                // sqlConnectionがnullではない場合、
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        // --- ADD 2019/11/13 ----------<<<<<


        #endregion

        #region [Private Methods]
        /// <summary>
        /// 指定された条件の在庫情報を戻します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handyStockWork">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の在庫情報を戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        //private int SearchProc(HandyStockCondWork condWork, out HandyStockWork handyStockWork, ref SqlConnection sqlConnection)
        public int SearchProc(HandyStockCondWork condWork, out HandyStockWork handyStockWork, ref SqlConnection sqlConnection)
        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyStockWork = null;
            StringBuilder sb = null;
            int[] indexs = null;
            // 企業コード
            SqlParameter findEnterpriseCode = null;
            // 倉庫コード
            SqlParameter findWarehouseCode = null;
            // 論理削除区分
            SqlParameter findLogicalDeleteCode = null;
            // 棚番
            SqlParameter findWarehouseShelfNo = null;
            // メーカーコード
            SqlParameter findGoodsMakerCd = null;
            // 商品番号
            SqlParameter findGoodsNo = null;
            // 相手先商品コード(JAN等)
            SqlParameter findGoodsBarCode = null;

            try
            {

                switch (condWork.OpDiv)
                {
                    // 入力パラメータ.取得区分が、0:"初回読込"の時
                    case 0:

                        # region SELECT句生成
                        // SQL文を生成
                        sb = new StringBuilder();
                        sb.AppendLine("SELECT ");
                        sb.AppendLine(" STOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine(" MAKERURF.MAKERNAMERF, ");
                        sb.AppendLine(" STOCKRF.GOODSNORF, ");
                        sb.AppendLine(" GOODSURF.GOODSNAMERF, ");
                        sb.AppendLine(" STOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine(" WAREHOUSERF.WAREHOUSENAMERF, ");
                        sb.AppendLine(" STOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine(" STOCKRF.SHIPMENTPOSCNTRF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        sb.AppendLine(" STOCKRF.STOCKSUPPLIERCODERF, ");
                        sb.AppendLine(" WAREHOUSERF.SECTIONCODERF, ");
                        sb.AppendLine(" GOODSURF.BLGOODSCODERF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        sb.AppendLine(" STOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine(" STOCKRF.LASTSTOCKDATERF ");
                        sb.AppendLine("FROM (");
                        sb.AppendLine(" SELECT ");
                        sb.AppendLine("  GOODSBARCODEREVNRF.GOODSMAKERCDRF, ");
                        sb.AppendLine("  GOODSBARCODEREVNRF.GOODSNORF, ");
                        sb.AppendLine("  GOODSBARCODEREVNRF.ENTERPRISECODERF, ");
                        sb.AppendLine("  GOODSBARCODEREVNRF.LOGICALDELETECODERF ");
                        sb.AppendLine(" FROM");
                        sb.AppendLine("  GOODSBARCODEREVNRF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" WHERE");
                        sb.AppendLine("  GOODSBARCODEREVNRF.ENTERPRISECODERF = @FINDENTERPRISECODE");
                        sb.AppendLine("  AND GOODSBARCODEREVNRF.GOODSBARCODERF = @FINDGOODSBARCODE");
                        sb.AppendLine("  AND GOODSBARCODEREVNRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                        sb.AppendLine("  ) SUB ");
                        sb.AppendLine(" INNER JOIN");
                        sb.AppendLine(" STOCKRF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUB.ENTERPRISECODERF = STOCKRF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUB.GOODSMAKERCDRF = STOCKRF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUB.GOODSNORF = STOCKRF.GOODSNORF ");
                        sb.AppendLine(" AND SUB.LOGICALDELETECODERF = STOCKRF.LOGICALDELETECODERF ");
                        sb.AppendLine(" AND STOCKRF.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" MAKERURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON STOCKRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND STOCKRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND STOCKRF.LOGICALDELETECODERF = MAKERURF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" WAREHOUSERF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON STOCKRF.ENTERPRISECODERF = WAREHOUSERF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND STOCKRF.WAREHOUSECODERF = WAREHOUSERF.WAREHOUSECODERF ");
                        sb.AppendLine(" AND STOCKRF.LOGICALDELETECODERF = WAREHOUSERF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" GOODSURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON STOCKRF.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND STOCKRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND STOCKRF.GOODSNORF = GOODSURF.GOODSNORF ");
                        sb.AppendLine(" AND STOCKRF.LOGICALDELETECODERF = GOODSURF.LOGICALDELETECODERF ");
                        # endregion
                        sb.AppendLine(" ORDER BY STOCKRF.GOODSMAKERCDRF,STOCKRF.GOODSNORF");// ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発
                        sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        #region パラメータ設定
                        // 企業コード
                        findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                        // 相手先商品コード(JAN等)
                        findGoodsBarCode = sqlCommand.Parameters.Add("@FINDGOODSBARCODE", SqlDbType.NVarChar);
                        findGoodsBarCode.Value = SqlDataMediator.SqlSetString(condWork.CustomerGoodsCode);
                        // 論理削除区分
                        findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                        // 倉庫コード
                        findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
                        #endregion

                        myReader = sqlCommand.ExecuteReader();

                        # region 検索結果設定
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        //indexs = new int[10];
                        indexs = new int[13];
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        // データが存在する場合、
                        if (myReader.HasRows)
                        {
                            int i = -1;
                            indexs[++i] = myReader.GetOrdinal("GOODSMAKERCDRF");
                            indexs[++i] = myReader.GetOrdinal("MAKERNAMERF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNORF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSECODERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSENAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSESHELFNORF");
                            indexs[++i] = myReader.GetOrdinal("SHIPMENTPOSCNTRF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                            indexs[++i] = myReader.GetOrdinal("STOCKSUPPLIERCODERF");
                            indexs[++i] = myReader.GetOrdinal("SECTIONCODERF");
                            indexs[++i] = myReader.GetOrdinal("BLGOODSCODERF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                            indexs[++i] = myReader.GetOrdinal("LASTSALESDATERF");
                            indexs[++i] = myReader.GetOrdinal("LASTSTOCKDATERF");
                        }
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        //while (myReader.Read())
                        if (myReader.Read())
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        {
                            handyStockWork = CopyToHandyStockWorkFromReader(indexs, ref myReader);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion

                        break;
                    // 入力パラメータ.処理区分が、1:"次"の時
                    case 1:

                        # region SELECT句生成
                        // SQL文を生成
                        sb = new StringBuilder();
                        sb.AppendLine("SELECT ");
                        sb.AppendLine(" SUBSTOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine(" MAKERURF.MAKERNAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.GOODSNORF, ");
                        sb.AppendLine(" GOODSURF.GOODSNAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine(" WAREHOUSERF.WAREHOUSENAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine(" SUBSTOCKRF.SHIPMENTPOSCNTRF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        sb.AppendLine(" SUBSTOCKRF.STOCKSUPPLIERCODERF, ");
                        sb.AppendLine(" WAREHOUSERF.SECTIONCODERF, ");
                        sb.AppendLine(" GOODSURF.BLGOODSCODERF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        sb.AppendLine(" SUBSTOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine(" SUBSTOCKRF.LASTSTOCKDATERF ");
                        sb.AppendLine("FROM (");
                        sb.AppendLine(" SELECT TOP 1 ");
                        sb.AppendLine("  STOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine("  STOCKRF.GOODSNORF, ");
                        sb.AppendLine("  STOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine("  STOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine("  STOCKRF.SHIPMENTPOSCNTRF, ");
                        sb.AppendLine("  STOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine("  STOCKRF.LASTSTOCKDATERF, ");
                        sb.AppendLine("  STOCKRF.ENTERPRISECODERF, ");
                        sb.AppendLine("  STOCKRF.STOCKSUPPLIERCODERF, ");// ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発
                        sb.AppendLine("  STOCKRF.LOGICALDELETECODERF ");
                        sb.AppendLine(" FROM ");
                        sb.AppendLine("  STOCKRF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" WHERE");
                        sb.AppendLine("  STOCKRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                        sb.AppendLine("  AND STOCKRF.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                        sb.AppendLine("  AND STOCKRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");

                        // 棚番は空の場合、メーカーと品番によって、在庫テーブルを検索して棚番を確定します、検索した棚番は"次"検索の検索条件とします。
                        if (string.IsNullOrEmpty(condWork.WarehouseShelfNo))
                        {
                            sb.AppendLine("  AND ((STOCKRF.WAREHOUSESHELFNORF IS NULL AND STOCKRF.GOODSMAKERCDRF = @FINDGOODSMAKERCD AND STOCKRF.GOODSNORF > @FINDGOODSNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF IS NULL AND STOCKRF.GOODSMAKERCDRF > @FINDGOODSMAKERCD) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF > '')) ");
                        }
                        else
                        {
                            sb.AppendLine("  AND ((STOCKRF.WAREHOUSESHELFNORF = @FINDWAREHOUSESHELFNO AND STOCKRF.GOODSMAKERCDRF = @FINDGOODSMAKERCD AND STOCKRF.GOODSNORF > @FINDGOODSNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF = @FINDWAREHOUSESHELFNO AND STOCKRF.GOODSMAKERCDRF > @FINDGOODSMAKERCD) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF > @FINDWAREHOUSESHELFNO)) ");
                        }

                        sb.AppendLine("  ORDER BY STOCKRF.WAREHOUSESHELFNORF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF ");
                        sb.AppendLine("  ) SUBSTOCKRF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" MAKERURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = MAKERURF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" WAREHOUSERF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = WAREHOUSERF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.WAREHOUSECODERF = WAREHOUSERF.WAREHOUSECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = WAREHOUSERF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" GOODSURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSNORF = GOODSURF.GOODSNORF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = GOODSURF.LOGICALDELETECODERF ");
                        # endregion

                        sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        #region パラメータ設定
                        // 企業コード
                        findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                        // 倉庫コード
                        findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
                        // 論理削除区分
                        findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                        // 棚番は空の場合、検索条件としない。
                        if (!string.IsNullOrEmpty(condWork.WarehouseShelfNo))
                        {
                            // 棚番
                            findWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            findWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(condWork.WarehouseShelfNo);
                        }
                        // メーカーコード
                        findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(condWork.GoodsMakerCd);
                        // 商品番号
                        findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(condWork.GoodsNo);
                        #endregion

                        myReader = sqlCommand.ExecuteReader();

                        # region 検索結果設定
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        //indexs = new int[10];
                        indexs = new int[13];
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        // データが存在する場合、
                        if (myReader.HasRows)
                        {
                            int i = -1;
                            indexs[++i] = myReader.GetOrdinal("GOODSMAKERCDRF");
                            indexs[++i] = myReader.GetOrdinal("MAKERNAMERF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNORF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSECODERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSENAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSESHELFNORF");
                            indexs[++i] = myReader.GetOrdinal("SHIPMENTPOSCNTRF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                            indexs[++i] = myReader.GetOrdinal("STOCKSUPPLIERCODERF");
                            indexs[++i] = myReader.GetOrdinal("SECTIONCODERF");
                            indexs[++i] = myReader.GetOrdinal("BLGOODSCODERF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                            indexs[++i] = myReader.GetOrdinal("LASTSALESDATERF");
                            indexs[++i] = myReader.GetOrdinal("LASTSTOCKDATERF");
                        }

                        while (myReader.Read())
                        {
                            handyStockWork = CopyToHandyStockWorkFromReader(indexs, ref myReader);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion

                        break;
                    // 入力パラメータ.処理区分が、2:"前"の時
                    case 2:

                        # region SELECT句生成
                        // SQL文を生成
                        sb = new StringBuilder();
                        sb.AppendLine("SELECT ");
                        sb.AppendLine(" SUBSTOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine(" MAKERURF.MAKERNAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.GOODSNORF, ");
                        sb.AppendLine(" GOODSURF.GOODSNAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine(" WAREHOUSERF.WAREHOUSENAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine(" SUBSTOCKRF.SHIPMENTPOSCNTRF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        sb.AppendLine(" SUBSTOCKRF.STOCKSUPPLIERCODERF, ");
                        sb.AppendLine(" WAREHOUSERF.SECTIONCODERF, ");
                        sb.AppendLine(" GOODSURF.BLGOODSCODERF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        sb.AppendLine(" SUBSTOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine(" SUBSTOCKRF.LASTSTOCKDATERF ");
                        sb.AppendLine("FROM (");
                        sb.AppendLine(" SELECT TOP 1 ");
                        sb.AppendLine("  STOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine("  STOCKRF.GOODSNORF, ");
                        sb.AppendLine("  STOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine("  STOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine("  STOCKRF.SHIPMENTPOSCNTRF, ");
                        sb.AppendLine("  STOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine("  STOCKRF.LASTSTOCKDATERF, ");
                        sb.AppendLine("  STOCKRF.ENTERPRISECODERF, ");
                        sb.AppendLine("  STOCKRF.STOCKSUPPLIERCODERF, ");// ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発
                        sb.AppendLine("  STOCKRF.LOGICALDELETECODERF ");
                        sb.AppendLine(" FROM ");
                        sb.AppendLine("  STOCKRF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" WHERE");
                        sb.AppendLine("  STOCKRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                        sb.AppendLine("  AND STOCKRF.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                        sb.AppendLine("  AND STOCKRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");

                        // 棚番は空の場合、メーカーと品番によって、在庫テーブルを検索して棚番を確定します、検索した棚番は"前"検索の検索条件とします。
                        if (string.IsNullOrEmpty(condWork.WarehouseShelfNo))
                        {
                            sb.AppendLine("  AND ((STOCKRF.WAREHOUSESHELFNORF IS NULL AND STOCKRF.GOODSMAKERCDRF = @FINDGOODSMAKERCD AND STOCKRF.GOODSNORF < @FINDGOODSNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF IS NULL AND STOCKRF.GOODSMAKERCDRF < @FINDGOODSMAKERCD)) ");
                        }
                        else
                        {
                            
                            sb.AppendLine("  AND ((STOCKRF.WAREHOUSESHELFNORF = @FINDWAREHOUSESHELFNO AND STOCKRF.GOODSMAKERCDRF = @FINDGOODSMAKERCD AND STOCKRF.GOODSNORF < @FINDGOODSNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF = @FINDWAREHOUSESHELFNO AND STOCKRF.GOODSMAKERCDRF < @FINDGOODSMAKERCD) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF IS NOT NULL AND STOCKRF.WAREHOUSESHELFNORF < @FINDWAREHOUSESHELFNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF IS NULL)) ");
                        }
                        
                        sb.AppendLine("  ORDER BY STOCKRF.WAREHOUSESHELFNORF DESC, STOCKRF.GOODSMAKERCDRF DESC, STOCKRF.GOODSNORF DESC ");
                        sb.AppendLine("  ) SUBSTOCKRF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" MAKERURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = MAKERURF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" WAREHOUSERF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = WAREHOUSERF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.WAREHOUSECODERF = WAREHOUSERF.WAREHOUSECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = WAREHOUSERF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" GOODSURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSNORF = GOODSURF.GOODSNORF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = GOODSURF.LOGICALDELETECODERF ");
                        # endregion

                        sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        #region パラメータ設定
                        // 企業コード
                        findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                        // 倉庫コード
                        findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
                        // 論理削除区分
                        findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                        // 棚番は空の場合、検索条件としない。
                        if (!string.IsNullOrEmpty(condWork.WarehouseShelfNo))
                        {
                            // 棚番
                            findWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            findWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(condWork.WarehouseShelfNo);
                        }
                        // メーカーコード
                        findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(condWork.GoodsMakerCd);
                        // 商品番号
                        findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(condWork.GoodsNo);
                        #endregion

                        myReader = sqlCommand.ExecuteReader();

                        # region 検索結果設定
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        //indexs = new int[10];
                        indexs = new int[13];
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        // データが存在する場合、
                        if (myReader.HasRows)
                        {
                            int i = -1;
                            indexs[++i] = myReader.GetOrdinal("GOODSMAKERCDRF");
                            indexs[++i] = myReader.GetOrdinal("MAKERNAMERF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNORF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSECODERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSENAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSESHELFNORF");
                            indexs[++i] = myReader.GetOrdinal("SHIPMENTPOSCNTRF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                            indexs[++i] = myReader.GetOrdinal("STOCKSUPPLIERCODERF");
                            indexs[++i] = myReader.GetOrdinal("SECTIONCODERF");
                            indexs[++i] = myReader.GetOrdinal("BLGOODSCODERF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                            indexs[++i] = myReader.GetOrdinal("LASTSALESDATERF");
                            indexs[++i] = myReader.GetOrdinal("LASTSTOCKDATERF");
                        }

                        while (myReader.Read())
                        {
                            handyStockWork = CopyToHandyStockWorkFromReader(indexs, ref myReader);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion

                        break;
                    // 入力パラメータ.処理区分が、「0、1、2」以外の時、エラーを戻ります。
                    default:
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog("HandyStockDB.SearchProc" + "入力パラメータ.処理区分エラー");
                        break;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockDB.SearchProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合、
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                // sqlCommandがnullではない場合、
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// 指定された条件の在庫情報を戻します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handyStockArray">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の在庫情報を戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public int SearchHandyProc(HandyStockCondWork condWork, out ArrayList handyStockArray, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyStockArray = null;
            StringBuilder sb = null;
            int[] indexs = null;
            // 企業コード
            SqlParameter findEnterpriseCode = null;
            // 倉庫コード
            SqlParameter findWarehouseCode = null;
            // 論理削除区分
            SqlParameter findLogicalDeleteCode = null;
            // 棚番
            SqlParameter findWarehouseShelfNo = null;
            // メーカーコード
            SqlParameter findGoodsMakerCd = null;
            // 商品番号
            SqlParameter findGoodsNo = null;
            // 相手先商品コード(JAN等)
            SqlParameter findGoodsBarCode = null;

            try
            {

                switch (condWork.OpDiv)
                {
                    // 入力パラメータ.取得区分が、0:"初回読込"の時
                    case 0:

                        # region SELECT句生成
                        // SQL文を生成
                        sb = new StringBuilder();
                        sb.AppendLine("SELECT ");
                        sb.AppendLine(" STOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine(" MAKERURF.MAKERNAMERF, ");
                        sb.AppendLine(" STOCKRF.GOODSNORF, ");
                        sb.AppendLine(" GOODSURF.GOODSNAMERF, ");
                        sb.AppendLine(" STOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine(" WAREHOUSERF.WAREHOUSENAMERF, ");
                        sb.AppendLine(" STOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine(" STOCKRF.SHIPMENTPOSCNTRF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        sb.AppendLine(" STOCKRF.STOCKSUPPLIERCODERF, ");
                        sb.AppendLine(" WAREHOUSERF.SECTIONCODERF, ");
                        sb.AppendLine(" GOODSURF.BLGOODSCODERF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        sb.AppendLine(" STOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine(" STOCKRF.LASTSTOCKDATERF ");
                        sb.AppendLine(" FROM ");
                        // -- 在庫マスタ
                        sb.AppendLine(" STOCKRF WITH (READUNCOMMITTED) ");
                        // -- バーコードマスタ
                        sb.AppendLine("LEFT OUTER JOIN ");
                        sb.AppendLine("  GOODSBARCODEREVNRF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON");
                        sb.AppendLine(" GOODSBARCODEREVNRF.ENTERPRISECODERF = STOCKRF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND GOODSBARCODEREVNRF.GOODSMAKERCDRF = STOCKRF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND GOODSBARCODEREVNRF.GOODSNORF = STOCKRF.GOODSNORF ");
                        sb.AppendLine(" AND GOODSBARCODEREVNRF.LOGICALDELETECODERF = STOCKRF.LOGICALDELETECODERF ");

                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" MAKERURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON STOCKRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND STOCKRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND STOCKRF.LOGICALDELETECODERF = MAKERURF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" WAREHOUSERF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON STOCKRF.ENTERPRISECODERF = WAREHOUSERF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND STOCKRF.WAREHOUSECODERF = WAREHOUSERF.WAREHOUSECODERF ");
                        sb.AppendLine(" AND STOCKRF.LOGICALDELETECODERF = WAREHOUSERF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" GOODSURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON STOCKRF.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND STOCKRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND STOCKRF.GOODSNORF = GOODSURF.GOODSNORF ");
                        sb.AppendLine(" AND STOCKRF.LOGICALDELETECODERF = GOODSURF.LOGICALDELETECODERF ");

                        sb.AppendLine(" WHERE STOCKRF.ENTERPRISECODERF = @FINDENTERPRISECODE "); 
                        sb.AppendLine(" AND STOCKRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                        sb.AppendLine(" AND STOCKRF.WAREHOUSECODERF = @FINDWAREHOUSECODE ");


                        if (string.IsNullOrEmpty(condWork.CustomerGoodsCode))
                        {
                            sb.AppendLine(" AND STOCKRF.GOODSNORF = @FINDGOODSNO ");
                        }
                        else
                        {
                            sb.AppendLine("  AND GOODSBARCODEREVNRF.GOODSBARCODERF = @FINDGOODSBARCODE");
                        }
                        # endregion
                        sb.AppendLine(" ORDER BY STOCKRF.GOODSMAKERCDRF,STOCKRF.GOODSNORF");// ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発
                        sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        #region パラメータ設定
                        // 企業コード
                        findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                        // 相手先商品コード(JAN等)
                        findGoodsBarCode = sqlCommand.Parameters.Add("@FINDGOODSBARCODE", SqlDbType.NVarChar);
                        findGoodsBarCode.Value = SqlDataMediator.SqlSetString(condWork.CustomerGoodsCode);
                        // 商品番号
                        findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(condWork.GoodsNo);
                        // 論理削除区分
                        findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                        // 倉庫コード
                        findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
                        #endregion

                        myReader = sqlCommand.ExecuteReader();

                        # region 検索結果設定
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        //indexs = new int[10];
                        indexs = new int[13];
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        // データが存在する場合、
                        if (myReader.HasRows)
                        {
                            int i = -1;
                            indexs[++i] = myReader.GetOrdinal("GOODSMAKERCDRF");
                            indexs[++i] = myReader.GetOrdinal("MAKERNAMERF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNORF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSECODERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSENAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSESHELFNORF");
                            indexs[++i] = myReader.GetOrdinal("SHIPMENTPOSCNTRF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                            indexs[++i] = myReader.GetOrdinal("STOCKSUPPLIERCODERF");
                            indexs[++i] = myReader.GetOrdinal("SECTIONCODERF");
                            indexs[++i] = myReader.GetOrdinal("BLGOODSCODERF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                            indexs[++i] = myReader.GetOrdinal("LASTSALESDATERF");
                            indexs[++i] = myReader.GetOrdinal("LASTSTOCKDATERF");
                        }
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        //while (myReader.Read())
                        while (myReader.Read())
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        {
                            if (handyStockArray == null)
                            {
                                handyStockArray = new ArrayList();
                            }

                            HandyStockWork handyStockWork = new HandyStockWork();

                            handyStockWork = CopyToHandyStockWorkFromReader(indexs, ref myReader);

                            handyStockArray.Add(handyStockWork);

                        }
                        #endregion

                        if (handyStockArray == null || handyStockArray.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        break;
                    // 入力パラメータ.処理区分が、1:"次"の時
                    case 1:

                        # region SELECT句生成
                        // SQL文を生成
                        sb = new StringBuilder();
                        sb.AppendLine("SELECT ");
                        sb.AppendLine(" SUBSTOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine(" MAKERURF.MAKERNAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.GOODSNORF, ");
                        sb.AppendLine(" GOODSURF.GOODSNAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine(" WAREHOUSERF.WAREHOUSENAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine(" SUBSTOCKRF.SHIPMENTPOSCNTRF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        sb.AppendLine(" SUBSTOCKRF.STOCKSUPPLIERCODERF, ");
                        sb.AppendLine(" WAREHOUSERF.SECTIONCODERF, ");
                        sb.AppendLine(" GOODSURF.BLGOODSCODERF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        sb.AppendLine(" SUBSTOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine(" SUBSTOCKRF.LASTSTOCKDATERF ");
                        sb.AppendLine("FROM (");
                        sb.AppendLine(" SELECT TOP 1 ");
                        sb.AppendLine("  STOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine("  STOCKRF.GOODSNORF, ");
                        sb.AppendLine("  STOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine("  STOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine("  STOCKRF.SHIPMENTPOSCNTRF, ");
                        sb.AppendLine("  STOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine("  STOCKRF.LASTSTOCKDATERF, ");
                        sb.AppendLine("  STOCKRF.ENTERPRISECODERF, ");
                        sb.AppendLine("  STOCKRF.STOCKSUPPLIERCODERF, ");// ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発
                        sb.AppendLine("  STOCKRF.LOGICALDELETECODERF ");
                        sb.AppendLine(" FROM ");
                        sb.AppendLine("  STOCKRF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" WHERE");
                        sb.AppendLine("  STOCKRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                        sb.AppendLine("  AND STOCKRF.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                        sb.AppendLine("  AND STOCKRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");

                        // 棚番は空の場合、メーカーと品番によって、在庫テーブルを検索して棚番を確定します、検索した棚番は"次"検索の検索条件とします。
                        if (string.IsNullOrEmpty(condWork.WarehouseShelfNo))
                        {
                            sb.AppendLine("  AND ((STOCKRF.WAREHOUSESHELFNORF IS NULL AND STOCKRF.GOODSMAKERCDRF = @FINDGOODSMAKERCD AND STOCKRF.GOODSNORF > @FINDGOODSNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF IS NULL AND STOCKRF.GOODSMAKERCDRF > @FINDGOODSMAKERCD) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF > '')) ");
                        }
                        else
                        {
                            sb.AppendLine("  AND ((STOCKRF.WAREHOUSESHELFNORF = @FINDWAREHOUSESHELFNO AND STOCKRF.GOODSMAKERCDRF = @FINDGOODSMAKERCD AND STOCKRF.GOODSNORF > @FINDGOODSNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF = @FINDWAREHOUSESHELFNO AND STOCKRF.GOODSMAKERCDRF > @FINDGOODSMAKERCD) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF > @FINDWAREHOUSESHELFNO)) ");
                        }

                        sb.AppendLine("  ORDER BY STOCKRF.WAREHOUSESHELFNORF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF ");
                        sb.AppendLine("  ) SUBSTOCKRF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" MAKERURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = MAKERURF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" WAREHOUSERF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = WAREHOUSERF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.WAREHOUSECODERF = WAREHOUSERF.WAREHOUSECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = WAREHOUSERF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" GOODSURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSNORF = GOODSURF.GOODSNORF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = GOODSURF.LOGICALDELETECODERF ");
                        # endregion

                        sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        #region パラメータ設定
                        // 企業コード
                        findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                        // 倉庫コード
                        findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
                        // 論理削除区分
                        findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                        // 棚番は空の場合、検索条件としない。
                        if (!string.IsNullOrEmpty(condWork.WarehouseShelfNo))
                        {
                            // 棚番
                            findWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            findWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(condWork.WarehouseShelfNo);
                        }
                        // メーカーコード
                        findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(condWork.GoodsMakerCd);
                        // 商品番号
                        findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(condWork.GoodsNo);
                        #endregion

                        myReader = sqlCommand.ExecuteReader();

                        # region 検索結果設定
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        //indexs = new int[10];
                        indexs = new int[13];
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        // データが存在する場合、
                        if (myReader.HasRows)
                        {
                            int i = -1;
                            indexs[++i] = myReader.GetOrdinal("GOODSMAKERCDRF");
                            indexs[++i] = myReader.GetOrdinal("MAKERNAMERF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNORF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSECODERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSENAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSESHELFNORF");
                            indexs[++i] = myReader.GetOrdinal("SHIPMENTPOSCNTRF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                            indexs[++i] = myReader.GetOrdinal("STOCKSUPPLIERCODERF");
                            indexs[++i] = myReader.GetOrdinal("SECTIONCODERF");
                            indexs[++i] = myReader.GetOrdinal("BLGOODSCODERF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                            indexs[++i] = myReader.GetOrdinal("LASTSALESDATERF");
                            indexs[++i] = myReader.GetOrdinal("LASTSTOCKDATERF");
                        }

                        while (myReader.Read())
                        {
                            if (handyStockArray == null)
                            {
                                handyStockArray = new ArrayList();
                            }

                            HandyStockWork handyStockWork = new HandyStockWork();

                            handyStockWork = CopyToHandyStockWorkFromReader(indexs, ref myReader);

                        }
                        #endregion

                        if (handyStockArray == null || handyStockArray.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        else
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        {
                        }

                        break;
                    // 入力パラメータ.処理区分が、2:"前"の時
                    case 2:

                        # region SELECT句生成
                        // SQL文を生成
                        sb = new StringBuilder();
                        sb.AppendLine("SELECT ");
                        sb.AppendLine(" SUBSTOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine(" MAKERURF.MAKERNAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.GOODSNORF, ");
                        sb.AppendLine(" GOODSURF.GOODSNAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine(" WAREHOUSERF.WAREHOUSENAMERF, ");
                        sb.AppendLine(" SUBSTOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine(" SUBSTOCKRF.SHIPMENTPOSCNTRF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        sb.AppendLine(" SUBSTOCKRF.STOCKSUPPLIERCODERF, ");
                        sb.AppendLine(" WAREHOUSERF.SECTIONCODERF, ");
                        sb.AppendLine(" GOODSURF.BLGOODSCODERF, ");
                        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        sb.AppendLine(" SUBSTOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine(" SUBSTOCKRF.LASTSTOCKDATERF ");
                        sb.AppendLine("FROM (");
                        sb.AppendLine(" SELECT TOP 1 ");
                        sb.AppendLine("  STOCKRF.GOODSMAKERCDRF, ");
                        sb.AppendLine("  STOCKRF.GOODSNORF, ");
                        sb.AppendLine("  STOCKRF.WAREHOUSECODERF, ");
                        sb.AppendLine("  STOCKRF.WAREHOUSESHELFNORF, ");
                        sb.AppendLine("  STOCKRF.SHIPMENTPOSCNTRF, ");
                        sb.AppendLine("  STOCKRF.LASTSALESDATERF, ");
                        sb.AppendLine("  STOCKRF.LASTSTOCKDATERF, ");
                        sb.AppendLine("  STOCKRF.ENTERPRISECODERF, ");
                        sb.AppendLine("  STOCKRF.STOCKSUPPLIERCODERF, ");// ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発
                        sb.AppendLine("  STOCKRF.LOGICALDELETECODERF ");
                        sb.AppendLine(" FROM ");
                        sb.AppendLine("  STOCKRF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" WHERE");
                        sb.AppendLine("  STOCKRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                        sb.AppendLine("  AND STOCKRF.WAREHOUSECODERF = @FINDWAREHOUSECODE ");
                        sb.AppendLine("  AND STOCKRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");

                        // 棚番は空の場合、メーカーと品番によって、在庫テーブルを検索して棚番を確定します、検索した棚番は"前"検索の検索条件とします。
                        if (string.IsNullOrEmpty(condWork.WarehouseShelfNo))
                        {
                            sb.AppendLine("  AND ((STOCKRF.WAREHOUSESHELFNORF IS NULL AND STOCKRF.GOODSMAKERCDRF = @FINDGOODSMAKERCD AND STOCKRF.GOODSNORF < @FINDGOODSNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF IS NULL AND STOCKRF.GOODSMAKERCDRF < @FINDGOODSMAKERCD)) ");
                        }
                        else
                        {

                            sb.AppendLine("  AND ((STOCKRF.WAREHOUSESHELFNORF = @FINDWAREHOUSESHELFNO AND STOCKRF.GOODSMAKERCDRF = @FINDGOODSMAKERCD AND STOCKRF.GOODSNORF < @FINDGOODSNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF = @FINDWAREHOUSESHELFNO AND STOCKRF.GOODSMAKERCDRF < @FINDGOODSMAKERCD) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF IS NOT NULL AND STOCKRF.WAREHOUSESHELFNORF < @FINDWAREHOUSESHELFNO) ");
                            sb.AppendLine("    OR (STOCKRF.WAREHOUSESHELFNORF IS NULL)) ");
                        }

                        sb.AppendLine("  ORDER BY STOCKRF.WAREHOUSESHELFNORF DESC, STOCKRF.GOODSMAKERCDRF DESC, STOCKRF.GOODSNORF DESC ");
                        sb.AppendLine("  ) SUBSTOCKRF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" MAKERURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = MAKERURF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" WAREHOUSERF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = WAREHOUSERF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.WAREHOUSECODERF = WAREHOUSERF.WAREHOUSECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = WAREHOUSERF.LOGICALDELETECODERF ");
                        sb.AppendLine(" LEFT JOIN");
                        sb.AppendLine(" GOODSURF WITH (READUNCOMMITTED) ");
                        sb.AppendLine(" ON SUBSTOCKRF.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF ");
                        sb.AppendLine(" AND SUBSTOCKRF.GOODSNORF = GOODSURF.GOODSNORF ");
                        sb.AppendLine(" AND SUBSTOCKRF.LOGICALDELETECODERF = GOODSURF.LOGICALDELETECODERF ");
                        # endregion

                        sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        #region パラメータ設定
                        // 企業コード
                        findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                        // 倉庫コード
                        findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(condWork.WarehouseCode);
                        // 論理削除区分
                        findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                        // 棚番は空の場合、検索条件としない。
                        if (!string.IsNullOrEmpty(condWork.WarehouseShelfNo))
                        {
                            // 棚番
                            findWarehouseShelfNo = sqlCommand.Parameters.Add("@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            findWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(condWork.WarehouseShelfNo);
                        }
                        // メーカーコード
                        findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(condWork.GoodsMakerCd);
                        // 商品番号
                        findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(condWork.GoodsNo);
                        #endregion

                        myReader = sqlCommand.ExecuteReader();

                        # region 検索結果設定
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                        //indexs = new int[10];
                        indexs = new int[13];
                        // ------ UPD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                        // データが存在する場合、
                        if (myReader.HasRows)
                        {
                            int i = -1;
                            indexs[++i] = myReader.GetOrdinal("GOODSMAKERCDRF");
                            indexs[++i] = myReader.GetOrdinal("MAKERNAMERF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNORF");
                            indexs[++i] = myReader.GetOrdinal("GOODSNAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSECODERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSENAMERF");
                            indexs[++i] = myReader.GetOrdinal("WAREHOUSESHELFNORF");
                            indexs[++i] = myReader.GetOrdinal("SHIPMENTPOSCNTRF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                            indexs[++i] = myReader.GetOrdinal("STOCKSUPPLIERCODERF");
                            indexs[++i] = myReader.GetOrdinal("SECTIONCODERF");
                            indexs[++i] = myReader.GetOrdinal("BLGOODSCODERF");
                            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                            indexs[++i] = myReader.GetOrdinal("LASTSALESDATERF");
                            indexs[++i] = myReader.GetOrdinal("LASTSTOCKDATERF");
                        }

                        while (myReader.Read())
                        {
                            if (handyStockArray == null)
                            {
                                handyStockArray = new ArrayList();
                            }

                            HandyStockWork handyStockWork = new HandyStockWork();

                            handyStockWork = CopyToHandyStockWorkFromReader(indexs, ref myReader);

                            handyStockArray.Add(handyStockWork);

                        }
                        #endregion

                        if (handyStockArray == null || handyStockArray.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        break;
                    // 入力パラメータ.処理区分が、「0、1、2」以外の時、エラーを戻ります。
                    default:
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog("HandyStockDB.SearchProc" + "入力パラメータ.処理区分エラー");
                        break;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockDB.SearchProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合、
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                // sqlCommandがnullではない場合、
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        // --- ADD 2019/11/13 ----------<<<<<

        /// <summary>
        /// クラス格納処理 Reader → HandyStockWork
        /// </summary>
        /// <param name="indexs">列の序数配列</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>HandyLoginInfoWork</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        private HandyStockWork CopyToHandyStockWorkFromReader(int[] indexs, ref SqlDataReader myReader)
        {
            HandyStockWork handyStockWork = new HandyStockWork();

            #region クラスへ格納
            int i = -1;
            handyStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyStockWork.MakerName = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyStockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyStockWork.GoodsName = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyStockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyStockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyStockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, indexs[++i]);
            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
            handyStockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyStockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyStockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
            handyStockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, indexs[++i]);
            handyStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, indexs[++i]);
            #endregion

            return handyStockWork;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnectionを生成します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            // SQLコネクション文字列が空場合、
            if (connectionText == null || connectionText == "")
            {
                base.WriteErrorLog("HandyStockDB.CreateSqlConnection" + "コネクション取得失敗");
                return null;
            } 

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
